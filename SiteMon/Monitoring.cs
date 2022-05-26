using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace SiteMon {
    public class MonitorInstance
    {
        public class MonitorEndpoint {
            public string Name;
            public string Url;
            private string LastPageSource;
            private bool FirstRun;
            private string GetPageSource(WebClient WebInteraction) {
                string[] RawSourceLines = null;
                try {
                    RawSourceLines = WebInteraction.DownloadString(this.Url).Split('\n');
                }
                catch (Exception) {
                    return null;
                }
                string AdjustedSource = string.Empty;
                for (int i = 0; i < RawSourceLines.Length; i++) {
                    bool ShouldAddLine = true;
                    for (int j = 0; j < Configuration.Regexes.Length; j++) {
                        if (Configuration.Regexes[j] != null && Regex.IsMatch(RawSourceLines[i], Configuration.Regexes[j])) {
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
            public void RunMonitorCheck(WebClient WebInteraction) {
                string PageSource = GetPageSource(WebInteraction);
                if (!this.FirstRun && this.LastPageSource != null && PageSource != null && this.LastPageSource != PageSource) {
                    Configuration.Logs += $"{DateTime.Now.TimeOfDay.ToString()}: A change was detected in '{this.Name}' ('{this.Url}').\n";
                    SpawnNotification();
                    if (Configuration.ChangeLogs) {
                        // SHA1 isn't being used for cryptographic security.
                        SHA1 SHAInstance = SHA1.Create();
                        byte[] LastBytes = System.Text.Encoding.UTF8.GetBytes(this.LastPageSource);
                        string LastPageHash = BitConverter.ToString(SHAInstance.ComputeHash(LastBytes)).Replace("-", string.Empty);
                        byte[] NewBytes = System.Text.Encoding.UTF8.GetBytes(PageSource);
                        string NewPageHash = BitConverter.ToString(SHAInstance.ComputeHash(NewBytes)).Replace("-", string.Empty);

                        //if (System.IO.File.Exists()) // Don't bother with this check, just overwrite the file if it already exists.
                        SHAInstance.Dispose(); // Easier than a 'using' tag in this case.
                        SHAInstance = null; // Prevent accidental future use.
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
                this.FirstRun = false;
                this.LastPageSource = PageSource;
                Thread.Sleep(Configuration.Delay);
            }
            public MonitorEndpoint(KeyValuePair<string, string> EndpointInfo) {
                this.Name = EndpointInfo.Key;
                this.Url = EndpointInfo.Value;
                this.LastPageSource = null;
                this.FirstRun = true;
            }
        };
        private List<MonitorEndpoint> MonitorEndpoints = new List<MonitorEndpoint>(0);
        private void MonitoringLoop() {
            this.UpdateEndpoints();
            WebClient WebInteraction = new WebClient();
            if (Configuration.Proxy.Length >= 1) {
                WebInteraction.Proxy = new WebProxy(Configuration.Proxy);
            }
            Configuration.StartedAt = DateTime.Now;
            while (true) {
                foreach (MonitorEndpoint Endpoint in MonitorEndpoints) {
                    // https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/User-Agent
                    WebInteraction.Headers.Set("user-agent", (Configuration.UserAgent ==
                        "[AUTO]" || Configuration.UserAgent == string.Empty) ?
                        $"sitemon-bot/{Configuration.Version} (+https://github.com/michaellrowley/sitemon)" : Configuration.UserAgent);
                    Endpoint.RunMonitorCheck(WebInteraction);
                }
                Thread.Sleep(Configuration.Delay);
            }
        }
        private Thread MonitorThread;
        public MonitorInstance() {
            this.MonitorThread = new Thread(MonitoringLoop);
        }
        private void UpdateEndpoints() {
            MonitorEndpoints.Clear();
            foreach (KeyValuePair<string, string> EndpointInstance in Configuration.Endpoints) {
                MonitorEndpoints.Add(new MonitorEndpoint(EndpointInstance));
            }
        }
        public void StopMonitoring() {
            // TODO: Use a mutex to find a safer way of ending
            // the thread.
            this.MonitorThread.Abort();
        }
        public void StartMonitoring() {
            this.MonitorThread.Start();
        }
    };
}
