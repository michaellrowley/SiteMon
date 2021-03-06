
namespace SiteMon
{
    partial class SetupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MonitorListGridView = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.URLColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonitorListTab = new System.Windows.Forms.TabControl();
            this.MonitorListTabPage = new System.Windows.Forms.TabPage();
            this.GeneralConfigTabPage = new System.Windows.Forms.TabPage();
            this.NotificationsGroupBox = new System.Windows.Forms.GroupBox();
            this.MessageBoxCheckBox = new System.Windows.Forms.CheckBox();
            this.PlaySoundCheckBox = new System.Windows.Forms.CheckBox();
            this.OpenUrlCheckBox = new System.Windows.Forms.CheckBox();
            this.PopupWindowCheckBox = new System.Windows.Forms.CheckBox();
            this.IoGroupBox = new System.Windows.Forms.GroupBox();
            this.ToggleEncKeyVisibilityBtn = new System.Windows.Forms.Button();
            this.GenEncKeyButton = new System.Windows.Forms.Button();
            this.EncryptionKeyTextBox = new System.Windows.Forms.TextBox();
            this.ChangeLogLocationTextBox = new System.Windows.Forms.TextBox();
            this.ChangeLoggingCheckBox = new System.Windows.Forms.CheckBox();
            this.ExportButton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ProxyTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UserAgentTextBox = new System.Windows.Forms.TextBox();
            this.DelayUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.WhitelistGroupBox = new System.Windows.Forms.GroupBox();
            this.RegexWhitelistGridView = new System.Windows.Forms.DataGridView();
            this.RegexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoggingPage = new System.Windows.Forms.TabPage();
            this.LogsTextBox = new System.Windows.Forms.RichTextBox();
            this.LaunchButton = new System.Windows.Forms.Button();
            this.HideButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.ExportConfigDialog = new System.Windows.Forms.SaveFileDialog();
            this.ImportConfigDialog = new System.Windows.Forms.OpenFileDialog();
            this.ChangeLogLocationDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.LogUpdater = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MonitorListGridView)).BeginInit();
            this.MonitorListTab.SuspendLayout();
            this.MonitorListTabPage.SuspendLayout();
            this.GeneralConfigTabPage.SuspendLayout();
            this.NotificationsGroupBox.SuspendLayout();
            this.IoGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DelayUpDown)).BeginInit();
            this.WhitelistGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RegexWhitelistGridView)).BeginInit();
            this.LoggingPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // MonitorListGridView
            // 
            this.MonitorListGridView.AllowUserToResizeColumns = false;
            this.MonitorListGridView.AllowUserToResizeRows = false;
            this.MonitorListGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MonitorListGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MonitorListGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.URLColumn});
            this.MonitorListGridView.Location = new System.Drawing.Point(3, 3);
            this.MonitorListGridView.Name = "MonitorListGridView";
            this.MonitorListGridView.RowHeadersWidth = 47;
            this.MonitorListGridView.Size = new System.Drawing.Size(385, 256);
            this.MonitorListGridView.TabIndex = 0;
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.MaxInputLength = 2048;
            this.NameColumn.MinimumWidth = 6;
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.Width = 115;
            // 
            // URLColumn
            // 
            this.URLColumn.HeaderText = "URL";
            this.URLColumn.MaxInputLength = 256;
            this.URLColumn.MinimumWidth = 6;
            this.URLColumn.Name = "URLColumn";
            this.URLColumn.Width = 210;
            // 
            // MonitorListTab
            // 
            this.MonitorListTab.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MonitorListTab.Controls.Add(this.MonitorListTabPage);
            this.MonitorListTab.Controls.Add(this.GeneralConfigTabPage);
            this.MonitorListTab.Controls.Add(this.LoggingPage);
            this.MonitorListTab.Location = new System.Drawing.Point(3, 30);
            this.MonitorListTab.Name = "MonitorListTab";
            this.MonitorListTab.SelectedIndex = 0;
            this.MonitorListTab.Size = new System.Drawing.Size(399, 288);
            this.MonitorListTab.TabIndex = 1;
            this.MonitorListTab.Tag = "";
            this.MonitorListTab.Click += new System.EventHandler(this.MonitorListTab_Click);
            // 
            // MonitorListTabPage
            // 
            this.MonitorListTabPage.Controls.Add(this.MonitorListGridView);
            this.MonitorListTabPage.Location = new System.Drawing.Point(4, 22);
            this.MonitorListTabPage.Name = "MonitorListTabPage";
            this.MonitorListTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MonitorListTabPage.Size = new System.Drawing.Size(391, 262);
            this.MonitorListTabPage.TabIndex = 0;
            this.MonitorListTabPage.Text = "Monitor list";
            this.MonitorListTabPage.UseVisualStyleBackColor = true;
            // 
            // GeneralConfigTabPage
            // 
            this.GeneralConfigTabPage.Controls.Add(this.NotificationsGroupBox);
            this.GeneralConfigTabPage.Controls.Add(this.IoGroupBox);
            this.GeneralConfigTabPage.Controls.Add(this.groupBox1);
            this.GeneralConfigTabPage.Controls.Add(this.WhitelistGroupBox);
            this.GeneralConfigTabPage.Location = new System.Drawing.Point(4, 22);
            this.GeneralConfigTabPage.Name = "GeneralConfigTabPage";
            this.GeneralConfigTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralConfigTabPage.Size = new System.Drawing.Size(391, 262);
            this.GeneralConfigTabPage.TabIndex = 1;
            this.GeneralConfigTabPage.Text = "Configuration";
            this.GeneralConfigTabPage.UseVisualStyleBackColor = true;
            // 
            // NotificationsGroupBox
            // 
            this.NotificationsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NotificationsGroupBox.Controls.Add(this.MessageBoxCheckBox);
            this.NotificationsGroupBox.Controls.Add(this.PlaySoundCheckBox);
            this.NotificationsGroupBox.Controls.Add(this.OpenUrlCheckBox);
            this.NotificationsGroupBox.Controls.Add(this.PopupWindowCheckBox);
            this.NotificationsGroupBox.Location = new System.Drawing.Point(6, 3);
            this.NotificationsGroupBox.Name = "NotificationsGroupBox";
            this.NotificationsGroupBox.Size = new System.Drawing.Size(373, 38);
            this.NotificationsGroupBox.TabIndex = 8;
            this.NotificationsGroupBox.TabStop = false;
            this.NotificationsGroupBox.Text = "Notification";
            // 
            // MessageBoxCheckBox
            // 
            this.MessageBoxCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageBoxCheckBox.AutoSize = true;
            this.MessageBoxCheckBox.Location = new System.Drawing.Point(282, 15);
            this.MessageBoxCheckBox.Name = "MessageBoxCheckBox";
            this.MessageBoxCheckBox.Size = new System.Drawing.Size(89, 17);
            this.MessageBoxCheckBox.TabIndex = 3;
            this.MessageBoxCheckBox.Text = "Message-box";
            this.MessageBoxCheckBox.UseVisualStyleBackColor = true;
            // 
            // PlaySoundCheckBox
            // 
            this.PlaySoundCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlaySoundCheckBox.AutoSize = true;
            this.PlaySoundCheckBox.Location = new System.Drawing.Point(197, 15);
            this.PlaySoundCheckBox.Name = "PlaySoundCheckBox";
            this.PlaySoundCheckBox.Size = new System.Drawing.Size(79, 17);
            this.PlaySoundCheckBox.TabIndex = 2;
            this.PlaySoundCheckBox.Text = "Alert sound";
            this.PlaySoundCheckBox.UseVisualStyleBackColor = true;
            // 
            // OpenUrlCheckBox
            // 
            this.OpenUrlCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenUrlCheckBox.AutoSize = true;
            this.OpenUrlCheckBox.Location = new System.Drawing.Point(114, 15);
            this.OpenUrlCheckBox.Name = "OpenUrlCheckBox";
            this.OpenUrlCheckBox.Size = new System.Drawing.Size(77, 17);
            this.OpenUrlCheckBox.TabIndex = 1;
            this.OpenUrlCheckBox.Text = "Open URL";
            this.OpenUrlCheckBox.UseVisualStyleBackColor = true;
            // 
            // PopupWindowCheckBox
            // 
            this.PopupWindowCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PopupWindowCheckBox.AutoSize = true;
            this.PopupWindowCheckBox.Enabled = false;
            this.PopupWindowCheckBox.Location = new System.Drawing.Point(12, 15);
            this.PopupWindowCheckBox.Name = "PopupWindowCheckBox";
            this.PopupWindowCheckBox.Size = new System.Drawing.Size(96, 17);
            this.PopupWindowCheckBox.TabIndex = 0;
            this.PopupWindowCheckBox.Text = "Popup window";
            this.PopupWindowCheckBox.UseVisualStyleBackColor = true;
            // 
            // IoGroupBox
            // 
            this.IoGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IoGroupBox.Controls.Add(this.ToggleEncKeyVisibilityBtn);
            this.IoGroupBox.Controls.Add(this.GenEncKeyButton);
            this.IoGroupBox.Controls.Add(this.EncryptionKeyTextBox);
            this.IoGroupBox.Controls.Add(this.ChangeLogLocationTextBox);
            this.IoGroupBox.Controls.Add(this.ChangeLoggingCheckBox);
            this.IoGroupBox.Controls.Add(this.ExportButton);
            this.IoGroupBox.Controls.Add(this.ImportButton);
            this.IoGroupBox.Location = new System.Drawing.Point(5, 47);
            this.IoGroupBox.Name = "IoGroupBox";
            this.IoGroupBox.Size = new System.Drawing.Size(205, 109);
            this.IoGroupBox.TabIndex = 7;
            this.IoGroupBox.TabStop = false;
            this.IoGroupBox.Text = "IO";
            // 
            // ToggleEncKeyVisibilityBtn
            // 
            this.ToggleEncKeyVisibilityBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ToggleEncKeyVisibilityBtn.Location = new System.Drawing.Point(170, 78);
            this.ToggleEncKeyVisibilityBtn.Name = "ToggleEncKeyVisibilityBtn";
            this.ToggleEncKeyVisibilityBtn.Size = new System.Drawing.Size(25, 23);
            this.ToggleEncKeyVisibilityBtn.TabIndex = 8;
            this.ToggleEncKeyVisibilityBtn.Text = "👀";
            this.ToggleEncKeyVisibilityBtn.UseVisualStyleBackColor = true;
            this.ToggleEncKeyVisibilityBtn.Click += new System.EventHandler(this.ToggleEncKeyVisibilityBtn_Click);
            // 
            // GenEncKeyButton
            // 
            this.GenEncKeyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.GenEncKeyButton.Location = new System.Drawing.Point(9, 78);
            this.GenEncKeyButton.Name = "GenEncKeyButton";
            this.GenEncKeyButton.Size = new System.Drawing.Size(25, 23);
            this.GenEncKeyButton.TabIndex = 6;
            this.GenEncKeyButton.Text = "🔮";
            this.GenEncKeyButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.GenEncKeyButton.UseVisualStyleBackColor = true;
            this.GenEncKeyButton.Click += new System.EventHandler(this.GenEncKeyButton_Click);
            // 
            // EncryptionKeyTextBox
            // 
            this.EncryptionKeyTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.EncryptionKeyTextBox.Location = new System.Drawing.Point(40, 80);
            this.EncryptionKeyTextBox.MaxLength = 16;
            this.EncryptionKeyTextBox.Name = "EncryptionKeyTextBox";
            this.EncryptionKeyTextBox.Size = new System.Drawing.Size(124, 20);
            this.EncryptionKeyTextBox.TabIndex = 4;
            this.EncryptionKeyTextBox.UseSystemPasswordChar = true;
            // 
            // ChangeLogLocationTextBox
            // 
            this.ChangeLogLocationTextBox.Location = new System.Drawing.Point(95, 48);
            this.ChangeLogLocationTextBox.Name = "ChangeLogLocationTextBox";
            this.ChangeLogLocationTextBox.ReadOnly = true;
            this.ChangeLogLocationTextBox.Size = new System.Drawing.Size(100, 20);
            this.ChangeLogLocationTextBox.TabIndex = 3;
            this.ChangeLogLocationTextBox.Click += new System.EventHandler(this.ChangeLogLocationTextBox_Click);
            // 
            // ChangeLoggingCheckBox
            // 
            this.ChangeLoggingCheckBox.AutoSize = true;
            this.ChangeLoggingCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.ChangeLoggingCheckBox.Location = new System.Drawing.Point(95, 24);
            this.ChangeLoggingCheckBox.Name = "ChangeLoggingCheckBox";
            this.ChangeLoggingCheckBox.Size = new System.Drawing.Size(100, 17);
            this.ChangeLoggingCheckBox.TabIndex = 2;
            this.ChangeLoggingCheckBox.Text = "Change-logging";
            this.ChangeLoggingCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChangeLoggingCheckBox.UseVisualStyleBackColor = true;
            this.ChangeLoggingCheckBox.CheckedChanged += new System.EventHandler(this.ChangeLoggingCheckBox_CheckedChanged);
            // 
            // ExportButton
            // 
            this.ExportButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ExportButton.Location = new System.Drawing.Point(9, 19);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(71, 23);
            this.ExportButton.TabIndex = 1;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // ImportButton
            // 
            this.ImportButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ImportButton.Location = new System.Drawing.Point(9, 48);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(71, 23);
            this.ImportButton.TabIndex = 0;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ProxyTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.UserAgentTextBox);
            this.groupBox1.Controls.Add(this.DelayUpDown);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 162);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Networking";
            // 
            // ProxyTextBox
            // 
            this.ProxyTextBox.AcceptsReturn = true;
            this.ProxyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProxyTextBox.BackColor = System.Drawing.Color.White;
            this.ProxyTextBox.Location = new System.Drawing.Point(45, 74);
            this.ProxyTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.ProxyTextBox.Name = "ProxyTextBox";
            this.ProxyTextBox.Size = new System.Drawing.Size(153, 20);
            this.ProxyTextBox.TabIndex = 8;
            this.ProxyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Proxy:";
            // 
            // UserAgentTextBox
            // 
            this.UserAgentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserAgentTextBox.Location = new System.Drawing.Point(74, 18);
            this.UserAgentTextBox.Name = "UserAgentTextBox";
            this.UserAgentTextBox.ReadOnly = true;
            this.UserAgentTextBox.Size = new System.Drawing.Size(124, 20);
            this.UserAgentTextBox.TabIndex = 3;
            this.UserAgentTextBox.Text = "[AUTO]";
            this.UserAgentTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UserAgentTextBox.Click += new System.EventHandler(this.UserAgentTextBox_Click);
            // 
            // DelayUpDown
            // 
            this.DelayUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DelayUpDown.Location = new System.Drawing.Point(71, 49);
            this.DelayUpDown.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.DelayUpDown.Minimum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.DelayUpDown.Name = "DelayUpDown";
            this.DelayUpDown.Size = new System.Drawing.Size(127, 20);
            this.DelayUpDown.TabIndex = 6;
            this.DelayUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DelayUpDown.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.854545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Delay (ms):";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.854545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "User-agent:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // WhitelistGroupBox
            // 
            this.WhitelistGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WhitelistGroupBox.Controls.Add(this.RegexWhitelistGridView);
            this.WhitelistGroupBox.Location = new System.Drawing.Point(217, 47);
            this.WhitelistGroupBox.Name = "WhitelistGroupBox";
            this.WhitelistGroupBox.Size = new System.Drawing.Size(168, 215);
            this.WhitelistGroupBox.TabIndex = 2;
            this.WhitelistGroupBox.TabStop = false;
            this.WhitelistGroupBox.Text = "Whitelist";
            // 
            // RegexWhitelistGridView
            // 
            this.RegexWhitelistGridView.AllowUserToOrderColumns = true;
            this.RegexWhitelistGridView.AllowUserToResizeColumns = false;
            this.RegexWhitelistGridView.AllowUserToResizeRows = false;
            this.RegexWhitelistGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RegexWhitelistGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RegexWhitelistGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RegexColumn});
            this.RegexWhitelistGridView.Location = new System.Drawing.Point(6, 19);
            this.RegexWhitelistGridView.Name = "RegexWhitelistGridView";
            this.RegexWhitelistGridView.RowHeadersWidth = 47;
            this.RegexWhitelistGridView.Size = new System.Drawing.Size(156, 190);
            this.RegexWhitelistGridView.TabIndex = 0;
            // 
            // RegexColumn
            // 
            this.RegexColumn.HeaderText = "Regex";
            this.RegexColumn.MinimumWidth = 6;
            this.RegexColumn.Name = "RegexColumn";
            this.RegexColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RegexColumn.Width = 105;
            // 
            // LoggingPage
            // 
            this.LoggingPage.Controls.Add(this.LogsTextBox);
            this.LoggingPage.Location = new System.Drawing.Point(4, 22);
            this.LoggingPage.Name = "LoggingPage";
            this.LoggingPage.Size = new System.Drawing.Size(391, 262);
            this.LoggingPage.TabIndex = 2;
            this.LoggingPage.Text = "Logs";
            this.LoggingPage.UseVisualStyleBackColor = true;
            // 
            // LogsTextBox
            // 
            this.LogsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogsTextBox.Location = new System.Drawing.Point(3, 3);
            this.LogsTextBox.Name = "LogsTextBox";
            this.LogsTextBox.Size = new System.Drawing.Size(383, 256);
            this.LogsTextBox.TabIndex = 0;
            this.LogsTextBox.Text = "";
            this.LogsTextBox.TextChanged += new System.EventHandler(this.LogsTextBox_TextChanged);
            // 
            // LaunchButton
            // 
            this.LaunchButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LaunchButton.Location = new System.Drawing.Point(98, 3);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(60, 23);
            this.LaunchButton.TabIndex = 2;
            this.LaunchButton.Text = "Launch";
            this.LaunchButton.UseVisualStyleBackColor = true;
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // HideButton
            // 
            this.HideButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HideButton.Location = new System.Drawing.Point(164, 3);
            this.HideButton.Name = "HideButton";
            this.HideButton.Size = new System.Drawing.Size(60, 23);
            this.HideButton.TabIndex = 3;
            this.HideButton.Text = "Hide";
            this.HideButton.UseVisualStyleBackColor = true;
            this.HideButton.Click += new System.EventHandler(this.HideButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StopButton.Location = new System.Drawing.Point(230, 3);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(59, 23);
            this.StopButton.TabIndex = 4;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // ExportConfigDialog
            // 
            this.ExportConfigDialog.FileName = "config.sm";
            // 
            // ImportConfigDialog
            // 
            this.ImportConfigDialog.FileName = "config.sm";
            // 
            // LogUpdater
            // 
            this.LogUpdater.Enabled = true;
            this.LogUpdater.Interval = 1500;
            this.LogUpdater.Tick += new System.EventHandler(this.LogUpdater_Tick);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 320);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.HideButton);
            this.Controls.Add(this.LaunchButton);
            this.Controls.Add(this.MonitorListTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SetupForm";
            this.Text = "Site monitor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SetupForm_FormClosed);
            this.Load += new System.EventHandler(this.SetupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MonitorListGridView)).EndInit();
            this.MonitorListTab.ResumeLayout(false);
            this.MonitorListTabPage.ResumeLayout(false);
            this.GeneralConfigTabPage.ResumeLayout(false);
            this.NotificationsGroupBox.ResumeLayout(false);
            this.NotificationsGroupBox.PerformLayout();
            this.IoGroupBox.ResumeLayout(false);
            this.IoGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DelayUpDown)).EndInit();
            this.WhitelistGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RegexWhitelistGridView)).EndInit();
            this.LoggingPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView MonitorListGridView;
        private System.Windows.Forms.TabControl MonitorListTab;
        private System.Windows.Forms.TabPage MonitorListTabPage;
        private System.Windows.Forms.TabPage GeneralConfigTabPage;
        private System.Windows.Forms.Button LaunchButton;
        private System.Windows.Forms.DataGridView RegexWhitelistGridView;
        private System.Windows.Forms.GroupBox WhitelistGroupBox;
        private System.Windows.Forms.Button HideButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.TextBox UserAgentTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown DelayUpDown;
        private System.Windows.Forms.GroupBox IoGroupBox;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.SaveFileDialog ExportConfigDialog;
        private System.Windows.Forms.OpenFileDialog ImportConfigDialog;
        private System.Windows.Forms.GroupBox NotificationsGroupBox;
        private System.Windows.Forms.CheckBox PopupWindowCheckBox;
        private System.Windows.Forms.CheckBox OpenUrlCheckBox;
        private System.Windows.Forms.CheckBox PlaySoundCheckBox;
        private System.Windows.Forms.CheckBox MessageBoxCheckBox;
        private System.Windows.Forms.CheckBox ChangeLoggingCheckBox;
        private System.Windows.Forms.FolderBrowserDialog ChangeLogLocationDialog;
        private System.Windows.Forms.TextBox ChangeLogLocationTextBox;
        private System.Windows.Forms.TabPage LoggingPage;
        private System.Windows.Forms.RichTextBox LogsTextBox;
        private System.Windows.Forms.Timer LogUpdater;
        private System.Windows.Forms.TextBox EncryptionKeyTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn URLColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegexColumn;
        private System.Windows.Forms.Button GenEncKeyButton;
        private System.Windows.Forms.Button ToggleEncKeyVisibilityBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ProxyTextBox;
    }
}