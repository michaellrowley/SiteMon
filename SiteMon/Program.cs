using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SiteMon {
    static class Program {

        [STAThread]
        static void Main() {
            string[] ArgArray = Environment.GetCommandLineArgs();
            //for (int i = 0; i < ArgArray.Length; i++) {
            //    Console.WriteLine(ArgArray[i]);
            //}
            if (ArgArray.Length == 2) {
                string ConfigLocation = ArgArray[1];
                string ConfigData = System.IO.File.ReadAllText(ConfigLocation);
                if (!Configuration.LoadFromConfig(ConfigData)) {
                    MessageBox.Show("Invalid config provided.");
                    return;
                }
                MonitorInstance Monitoring = new MonitorInstance();
                foreach (KeyValuePair<string, string> Target in Configuration.Targets) {
                    Monitoring.StartMonitoringTarget(Target.Key, Target.Value);
                }
                MessageBox.Show("Started monitoring.");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SetupForm());
        }
    }
}
