using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace SiteMon {
    public class MonitorInstance {
        public struct MonitorTarget {
            private Thread MonitoringThread;
            public string Name;
            public string Url;
            private bool StopMonitoring;
            private WebClient WebInteraction;
            private string LastPageSource;
            private string GetPageSource() {
                string[] RawSourceLines = null;
                try {
                    this.WebInteraction.Headers.Set("user-agent",
                        (Configuration.UserAgent == "[AUTO]" || Configuration.UserAgent == string.Empty)
                            ? GenUA() : Configuration.UserAgent);
                    //this.WebInteraction.Headers.Set("User-Agent", "v0.1, https://github.com/michaellrowley/sitemon");
                    RawSourceLines = this.WebInteraction.DownloadString(this.Url).Split('\n');
                }
                catch (Exception exc) {
                    return null;
                }
                string AdjustedSource = string.Empty;
                for (int i = 0; i < RawSourceLines.Length; i++) {
                    bool ShouldAddLine = true;
                    for (int j = 0; j < Configuration.Regexes.Length; j++) {
                        if (Configuration.Regexes[i] != null &&
                            Regex.IsMatch(RawSourceLines[i], Configuration.Regexes[j])) {
                            ShouldAddLine = false; // Ignore this line
                            break;
                        }
                    }
                    if (!ShouldAddLine) {
                        continue;
                    }
                    AdjustedSource += RawSourceLines[i] + "\n";
                }
                return AdjustedSource;
            }
            private void SpawnNotification() {
                // The NotificationForm cannot display over some fullscreen windows
                // that I use frequently so I needed something more obvious to catch
                // my attention (aside from the MessageBox and browser-opening) hence
                // the sound.

                // Running a new form blocks the current thread until it closes
                // and MessageBox.Show also blocks the current thread until it is
                // closed.
                if (Configuration.PlaySound) {
                    System.Media.SystemSounds.Beep.Play(); // Can be disabled via system sounds in Windows settings.
                }    
                if (Configuration.ShowPopup) {
                    new Thread(new ParameterizedThreadStart(
                        (ARGS) => Application.Run(new NotificationForm(ARGS.ToString().Split('\x00')[0],
                                                  ARGS.ToString().Split('\x00')[1]))
                    )).Start(this.Url + '\x00' + this.Name);
                }
                if (Configuration.ShowMessageBox) {
                    new Thread(new ParameterizedThreadStart(
                        (NAME) => MessageBox.Show($"A change has been detected in page '{NAME}'.")
                    )).Start(this.Name);
                }
                if (Configuration.OpenUrl) {
                    System.Diagnostics.Process.Start(this.Url);
                }
            }
            private void Monitor() {
                while (!StopMonitoring) {
                    string PageSource = GetPageSource();
                    if (this.LastPageSource != null && 
                        PageSource != null &&
                        this.LastPageSource != PageSource) {

                        Configuration.Logs += $"{DateTime.Now.ToString()}: A change was detected in '{this.Name}' ('{this.Url}').\n";

                        SpawnNotification();

                        if (Configuration.ChangeLogs) {
                            // SHA1 is used because I can't
                            // find a native CRC (or similar)
                            // checksum/hashing algorithm for
                            // C# .NET, not for anything security
                            // related.
                            // If the tech-debt becomes too large (performance gets too slow) I'll write (or more realistically, copy) a CRC32 or basic checksum implementation and use that.
                            SHA1 SHAInstance = SHA1.Create();
                            byte[] LastBytes = System.Text.Encoding.UTF8.GetBytes(this.LastPageSource);
                            string LastPageHash = BitConverter.ToString(SHAInstance.ComputeHash(LastBytes)).Replace("-", string.Empty);
                            byte[] NewBytes = System.Text.Encoding.UTF8.GetBytes(PageSource);
                            string NewPageHash = BitConverter.ToString(SHAInstance.ComputeHash(NewBytes)).Replace("-", string.Empty);
                            //if (System.IO.File.Exists()) // Don't bother with this check, just overwrite the file if it already exists.
                            SHAInstance.Dispose(); // Easier than a 'using' tag in this case.
                            SHAInstance = null; // Prevent future accidental use.
                            string CurrentDateTimeFormatted = DateTime.Now.ToString().Replace(" ",
                                "_").Replace(':', '-').Replace('/', '-');
                            System.IO.File.WriteAllText(Configuration.ChangeLogsLocation +
                                $"\\{LastPageHash}-{CurrentDateTimeFormatted}",
                                this.LastPageSource);

                            System.IO.File.WriteAllText(Configuration.ChangeLogsLocation +
                                $"/{NewPageHash}-{CurrentDateTimeFormatted}",
                                PageSource);
                        }

                    }
                    this.LastPageSource = PageSource;

                    Thread.Sleep(Configuration.Delay);
                }
            }
            public void Start() {
                this.StopMonitoring = false;
                this.MonitoringThread.Start();
            }
            public void Stop() {
                this.StopMonitoring = true;
                // TODO: Switch from Thread::Abort()
                // to a more 'elegant' way of killing
                // threads (see: https://stackoverflow.com/questions/2251964/)
                this.MonitoringThread.Abort();
            }
            private string GenUA() {
                //    (https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent)
                string UserAgent = $"sitemon-bot/{Configuration.Version} (+https://github.com/michaellrowley/sitemon)";
                return UserAgent;
            }
            public MonitorTarget(string Name, string Url) {
                this.Name = Name;
                this.Url = Url;
                this.MonitoringThread = null;
                this.StopMonitoring = false;
                this.WebInteraction = new WebClient();
                this.LastPageSource = null;
                this.MonitoringThread = new Thread(this.Monitor);
                Configuration.StartedAt = DateTime.Now;
                this.LastPageSource = this.GetPageSource();
            }
        };
        private List<MonitorTarget> MonitorTargets = new List<MonitorTarget>(0);
        public MonitorInstance() {
        }
        public void StopMonitoringAll() {
            for (int i = 0; i < MonitorTargets.Count; i++) {
                this.MonitorTargets[i].Stop();
                this.MonitorTargets.RemoveAt(i);
            }
            if (this.MonitorTargets.Count != 0) {
                this.MonitorTargets.Clear();
            }
        }
        public bool StopMonitoringTarget(string Name, string Url) {
            // Either Name or Url can be null, not both (obviously).
            if (Name == null && Url == null) {
                return false;
            }
            for (int i = 0; i < this.MonitorTargets.Count; i++) {
                if (Name == null ? (this.MonitorTargets[i].Url != Url) : (this.MonitorTargets[i].Name != Name)) {
                    continue;
                }
                this.MonitorTargets[i].Stop();
                return true;
            }
            return false;
        }
        public void StartMonitoringTarget(string Name, string Url) {
            MonitorTargets.Add(new MonitorTarget(Name, Url));
            MonitorTargets[MonitorTargets.Count - 1].Start();
        }
    };
}
