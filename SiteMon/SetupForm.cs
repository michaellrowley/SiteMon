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
            this.DelayUpDown.Value = Configuration.Delay;
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
    }
}
public static class Configuration {
    public static string Version = "v0.2";
    public static string[] Regexes;
    public static List<KeyValuePair<string, string>> Targets = new List<KeyValuePair<string, string>>(0); // { <NAME, URL> }
    public static string UserAgent;
    public static DateTime StartedAt;
    public static int Delay;
    public static bool ShowPopup;
    public static bool ShowMessageBox;
    public static bool OpenUrl;
    public static bool PlaySound;
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

        return SerializedData;
    }
    public static bool LoadFromConfig(string SerializedData) {
        int ParsingStage = 1;
        List<string> RegexList = new List<string>(0);
        foreach (string DataLine in SerializedData.Split('\n')) {
            if (DataLine.TrimStart().StartsWith("//") ||
                DataLine.Trim(new char[] { ' ', '\t' }) == string.Empty) {
                if (ParsingStage == 7 && DataLine == string.Empty) {
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
                        // this.Regexes
                        if (!DataLine.StartsWith("\t")) {
                            return false;
                        }
                        RegexList.Add(DataLine.TrimStart(new char[] { '\t' }));
                    }
                    break;
                case 8: {
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
                default:
                    return false;
                    break; // Should never be hit.
            }
        }
            Configuration.Regexes = RegexList.ToArray();
        return ParsingStage == 8;
    }
}