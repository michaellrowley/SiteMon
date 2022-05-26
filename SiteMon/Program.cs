using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SiteMon {
    static class Program {

        [STAThread]
        static void Main() {
            string[] ArgArray = Environment.GetCommandLineArgs();
            if (ArgArray.Length == 2) {
                string ConfigLocation = ArgArray[1];
                string ConfigData = System.IO.File.ReadAllText(ConfigLocation);
                if (!Configuration.LoadFromConfig(ConfigData)) {
                    MessageBox.Show("Invalid config provided.");
                    return;
                }
                MonitorInstance Monitoring = new MonitorInstance();
                Monitoring.StartMonitoring();
                MessageBox.Show("Started monitoring.");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SetupForm());
        }
    }
}
