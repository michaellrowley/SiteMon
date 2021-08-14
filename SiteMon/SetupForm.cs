using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SiteMon
{
    public partial class SetupForm : Form
    {
        public SetupForm() {
            InitializeComponent();
        }
        private MonitorInstance Monitoring;
        private void UpdateConfig() {
            string[] WhitelistRegexes = GridViewToArray<string>(this.RegexWhitelistGridView, 0);
            Configuration.Regexes = WhitelistRegexes;
            Configuration.UserAgent = this.UserAgentTextBox.Text;
            Configuration.Delay = Convert.ToInt32(this.DelayUpDown.Value);
            Configuration.ShowPopup = this.PopupWindowCheckBox.Checked;
            Configuration.ShowMessageBox = this.MessageBoxCheckBox.Checked;
            Configuration.OpenUrl = this.OpenUrlCheckBox.Checked;
            Configuration.PlaySound = this.PlaySoundCheckBox.Checked;
            Configuration.ChangeLogs = this.ChangeLoggingCheckBox.Checked;
            Configuration.ChangeLogsLocation = this.ChangeLogLocationDialog.SelectedPath;
            Configuration.Logs = this.LogsTextBox.Text;
            Configuration.Targets.Clear();
            for (int i = 0; i < MonitorListGridView.Rows.Count; i++) {
                if (MonitorListGridView.Rows[i].Cells.Count != 2 ||
                    MonitorListGridView.Rows[i].Cells[0].Value == null ||
                    MonitorListGridView.Rows[i].Cells[1].Value == null) {
                    continue;
                }
                string TargetName = MonitorListGridView.Rows[i].Cells[0].Value.ToString();
                string TargetURL = MonitorListGridView.Rows[i].Cells[1].Value.ToString();
                Configuration.Targets.Add(new KeyValuePair<string, string>(TargetName, TargetURL));
            }
        }
        private void UpdateForm() {
            this.UserAgentTextBox.Text = Configuration.UserAgent;
            this.DelayUpDown.Value = (this.DelayUpDown.Value > Configuration.Delay)
                ? this.DelayUpDown.Value : Configuration.Delay;
                RegexWhitelistGridView.Rows.Clear();
            foreach (string RegexInstance in Configuration.Regexes) {
                RegexWhitelistGridView.Rows.Add(new string[] { RegexInstance });
            }
            foreach (KeyValuePair<string, string> TargetInstance in Configuration.Targets) {
                MonitorListGridView.Rows.Add(TargetInstance.Key, TargetInstance.Value);
            }
            this.PopupWindowCheckBox.Checked = Configuration.ShowPopup;
            this.MessageBoxCheckBox.Checked = Configuration.ShowMessageBox;
            this.OpenUrlCheckBox.Checked = Configuration.OpenUrl;
            this.PlaySoundCheckBox.Checked = Configuration.PlaySound;
            this.ChangeLoggingCheckBox.Checked = Configuration.ChangeLogs;
            this.ChangeLogLocationDialog.SelectedPath = Configuration.ChangeLogsLocation;
            this.LogsTextBox.Text = Configuration.Logs;
        }
        private void MonitorListTab_Click(object sender, EventArgs e) {
            ((TabControl)sender).SelectedTab.Focus();
        }
        private void SetupForm_Load(object sender, EventArgs e) { }
        private T[] GridViewToArray<T>(DataGridView Source, int Index = 0, bool IgnoreLast = true) {
            List<T> Array = new List<T>(0);
            for (int i = 0; i < Source.Rows.Count - (IgnoreLast ? 1 : 0); i++) {
                Array.Add((T)Source.Rows[i].Cells[Index].Value);
            }
            return Array.ToArray();
        }
        private void LaunchButton_Click(object sender, EventArgs e) {
            if (Monitoring != null) {
                MessageBox.Show("Unable to start monitoring selected sites.", "Already monitoring.");
                return;
            }
            UpdateConfig();
            Monitoring = new MonitorInstance();
            Configuration.Targets.Clear();
            for (int i = 0; i < MonitorListGridView.Rows.Count; i++) {
                if (MonitorListGridView.Rows[i].Cells.Count != 2 ||
                    MonitorListGridView.Rows[i].Cells[0].Value == null ||
                    MonitorListGridView.Rows[i].Cells[1].Value == null) {
                    continue;
                }
                string TargetName = MonitorListGridView.Rows[i].Cells[0].Value.ToString();
                string TargetURL = MonitorListGridView.Rows[i].Cells[1].Value.ToString();
                Configuration.Targets.Add(new KeyValuePair<string, string>(TargetName, TargetURL));
                Monitoring.StartMonitoringTarget(TargetName, TargetURL);
            }
        }
        private void StopButton_Click(object sender, EventArgs e) {
            if (Monitoring == null) {
                return;
            }
            Monitoring.StopMonitoringAll();
            // TODO: Find out (and if required, do)
            // if I need to manually dispose each object
            // within the MonitoringInstance instance.
            Monitoring = null;
        }
        private void HideButton_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void UserAgentTextBox_Click(object sender, EventArgs e) {
            this.UserAgentTextBox.ReadOnly = this.UserAgentTextBox.Text == string.Empty &&
                                             !this.UserAgentTextBox.ReadOnly;
            if (this.UserAgentTextBox.ReadOnly) {
                this.UserAgentTextBox.Text = "[AUTO]";
                this.UserAgentTextBox.TextAlign = HorizontalAlignment.Center;
                this.label2.Focus();
            }
            else if (this.UserAgentTextBox.Text == "[AUTO]") {
                this.UserAgentTextBox.Text = string.Empty;
                this.UserAgentTextBox.TextAlign = HorizontalAlignment.Left;
            }
        }

        private void SetupForm_FormClosed(object sender, FormClosedEventArgs e) {
            StopButton_Click(sender, e);
        }

        private void ImportButton_Click(object sender, EventArgs e) {
            if (ImportConfigDialog.ShowDialog() != DialogResult.OK) {
                MessageBox.Show("Invalid location provided.");
                return;
            }
            string ConfigData = System.IO.File.ReadAllText(ImportConfigDialog.FileName);
            if (!Configuration.LoadFromConfig(ConfigData)) {
                MessageBox.Show("Unable to load config.");
                return;
            }
            UpdateForm();
            MessageBox.Show("Imported!");
        }

        private void ExportButton_Click(object sender, EventArgs e) {
            if (ExportConfigDialog.ShowDialog() != DialogResult.OK) {
                MessageBox.Show("Invalid location provided.");
                return;
            }

            UpdateConfig();
            string SerializedConfig = Configuration.Serialize();
            System.IO.File.WriteAllText(ExportConfigDialog.FileName, SerializedConfig);
            MessageBox.Show("Exported!");
        }

        private void ChangeLoggingCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (this.ChangeLoggingCheckBox.Checked) {
                if (this.ChangeLogLocationDialog.ShowDialog() != DialogResult.OK) {
                    MessageBox.Show("Invalid location.");
                    this.ChangeLoggingCheckBox.Checked = false;
                    return;
                }
                ChangeLogLocationTextBox.Text = ChangeLogLocationDialog.SelectedPath;
            }
        }

        private void ChangeLogLocationTextBox_Click(object sender, EventArgs e) {
            if (!this.ChangeLoggingCheckBox.Checked) {
                this.ChangeLoggingCheckBox.Checked = true;
            }
            else {
                ChangeLoggingCheckBox_CheckedChanged(null, null);
            }
            this.label2.Focus();
        }

        private void LogUpdater_Tick(object sender, EventArgs e) {
            // The Configuration.Log value is often updated outside
            // of the SetupForm UI thread meaning that a direct call
            // to update the relevant text box isn't always possible,
            // as a result of this - we have this timer that periodically
            // calls it in place of other threads trying to interact
            // with the UI one (which never ends well because this is a WinForm).
            this.LogsTextBox.Text = Configuration.Logs;
        }

        private void LogsTextBox_TextChanged(object sender, EventArgs e) {
            Configuration.Logs = this.LogsTextBox.Text;
        }
    }
}
public static class Configuration {
    public static string Version = "v0.7.2";
    public static string[] Regexes = new string[0];
    public static List<KeyValuePair<string, string>> Targets = new List<KeyValuePair<string, string>>(0); // { <NAME, URL> }
    public static string UserAgent;
    public static DateTime StartedAt;
    public static int Delay;
    public static bool ShowPopup;
    public static bool ShowMessageBox;
    public static bool OpenUrl;
    public static bool PlaySound;
    public static bool ChangeLogs;
    public static string ChangeLogsLocation;
    public static string Logs;
    private static string GenerateHeader() {
        string Header = string.Empty;
        Header += "// Project: HTTPS://GITHUB.COM/MICHAELLROWLEY/SITEMON\n";
        Header += $"// Version: {Configuration.Version}\n";
        Header += $"// Created: {DateTime.Now.ToString()}\n";
        Header += $"// All lines beginning with two slashes ('//') are optional.\n";
        return Header;
    }
    public static string Serialize() {
        // TODO: Consider using JSON Serialization/Deserialization
        // to make things simpler/easier for porting data?

        string SerializedData = GenerateHeader();

        // this.Delay
        SerializedData += "// Configuration.Delay:\n";
        SerializedData += Convert.ToString(Configuration.Delay) + "\n";

        // this.UserAgent
        SerializedData += "// Configuration.UserAgent:\n";
        SerializedData += Configuration.UserAgent + "\n";

        // this.ShowPopup
        SerializedData += "// Configuration.ShowPopup:\n";
        SerializedData += (Configuration.ShowPopup ? "true" : "false") + "\n";

        // this.ShowMessageBox
        SerializedData += "// Configuration.ShowMessageBox:\n";
        SerializedData += (Configuration.ShowMessageBox ? "true" : "false") + "\n";

        // this.OpenUrl
        SerializedData += "// Configuration.OpenUrl:\n";
        SerializedData += (Configuration.OpenUrl ? "true" : "false") + "\n";

        // this.PlaySound
        SerializedData += "// Configuration.PlaySound:\n";
        SerializedData += (Configuration.PlaySound ? "true" : "false") + "\n";

        // this.ChangeLogs
        SerializedData += "// Configuration.ChangeLogs:\n";
        SerializedData += (Configuration.ChangeLogs ? "true" : "false") + "\n";

        // this.ChangeLogsLocation
        SerializedData += "// Configuration.ChangeLogsLocation:\n";
        SerializedData += Configuration.ChangeLogsLocation + "\n";

        // this.Regexes
        SerializedData += "// Configuration.Regexes:";
        foreach (string RegexInstance in Configuration.Regexes) {
            SerializedData += "\n\t" + RegexInstance;
        }

        // this.Targets
        SerializedData += "\n\n// Configuration.Targets:";
        foreach (KeyValuePair<string, string> IterativeTarget in Configuration.Targets) {
            SerializedData += "\n\t" + IterativeTarget.Key + "\x00" + IterativeTarget.Value;
        }

        // this.Logs
        SerializedData += "\n\n// Configuration.Logs:";
        foreach (string LogLine in Configuration.Logs.Split('\n')) {
            SerializedData += "\n\t" + LogLine;
        }

        return SerializedData;
    }
    public static bool LoadFromConfig(string SerializedData) {
        int ParsingStage = 1;
        List<string> RegexList = new List<string>(0);
        foreach (string DataLine in SerializedData.Split('\n')) {
            if (DataLine.TrimStart().StartsWith("//") ||
                DataLine.Trim(new char[] { ' ', '\t' }) == string.Empty) {
                if ((ParsingStage == 9 || ParsingStage == 8 || ParsingStage == 10)
                    && DataLine == string.Empty) {
                    ParsingStage++;
                }
                continue;
            }
            switch (ParsingStage) {
                case 1: {
                        // this.Delay
                        if (!Int32.TryParse(DataLine, out Configuration.Delay)) {
                            return false;
                        }
                        ParsingStage++;
                    }
                    break;
                case 2: {
                        // this.UserAgent
                        Configuration.UserAgent = DataLine;
                        ParsingStage++;
                    }
                    break;
                case 3: {
                        // this.ShowPopup
                        Configuration.ShowPopup = DataLine == "true" ? true : false;
                        ParsingStage++;
                    }
                    break;
                case 4: {
                        // this.ShowMessageBox
                        Configuration.ShowMessageBox = DataLine == "true" ? true : false;
                        ParsingStage++;
                    }
                    break;
                case 5: {
                        // this.OpenUrl
                        Configuration.OpenUrl = DataLine == "true" ? true : false;
                        ParsingStage++;
                    }
                    break;
                case 6: {
                        // this.PlaySound
                        Configuration.PlaySound = DataLine == "true" ? true : false;
                        ParsingStage++;
                    }
                    break;
                case 7: {
                        // this.ChangeLogs
                        Configuration.ChangeLogs = DataLine == "true" ? true : false;
                        ParsingStage++;
                    }
                    break;
                case 8: {
                        // this.ChangeLogsLocation
                        Configuration.ChangeLogsLocation = DataLine;
                        ParsingStage++;
                    }
                    break;
                case 9: {
                        // this.Regexes
                        if (!DataLine.StartsWith("\t")) {
                            return false;
                        }
                        RegexList.Add(DataLine.TrimStart(new char[] { '\t' }));
                    }
                    break;
                case 10: {
                        // this.Targets
                        string[] DataSegments = DataLine.TrimStart(new char[] { '\t' }).Split('\x00');
                        if (DataSegments.Length != 2) {
                            return false;
                        }
                        Configuration.Targets.Add(new KeyValuePair<string, string>(
                            DataSegments[0],
                            DataSegments[1]
                        ));
                    }
                    break;
                case 11: {
                        Configuration.Logs += "\n" + DataLine.TrimStart(new char[] { '\t' });
                    }
                    break;
                default:
                    return false;
                    break; // Should never be hit.
            }
        }
            Configuration.Regexes = RegexList.ToArray();
        return ParsingStage == 11;
    }
}