using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
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
                        if (Regex.IsMatch(RawSourceLines[i], Configuration.Regexes[j])) {
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
                    if (this.LastPageSource != PageSource) {
                        SpawnNotification();
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
                // sitemon / 0.1 / delay:4000ms / start:13/08/2021
                string UserAgent = $"sitemon / {Configuration.Version} / delay:" +
                    $"{Configuration.Delay} / start:" +
                    $"{Configuration.StartedAt.ToString().Replace(' ', '-')}";
                return UserAgent;
            }
            public MonitorTarget(string Name, string Url) {

                this.Name = Name;
                this.Url = Url;
                this.MonitoringThread = null;
                this.StopMonitoring = false;
                this.WebInteraction = new WebClient();
                this.LastPageSource = null;
                this.LastPageSource = this.GetPageSource();
                this.MonitoringThread = new Thread(this.Monitor);
                Configuration.StartedAt = DateTime.Now;
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
