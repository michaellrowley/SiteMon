using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiteMon {
    public partial class NotificationForm : Form {
        private string URL, Name;
        public NotificationForm(string URL, string Name) {
            this.URL = URL;
            this.Name = Name;
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void NotificationForm_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(this.URL);
        }
        private int QuitAtY = 0x0;
        private void NotificationForm_Load(object sender, EventArgs e) {
            this.BringToFront();

            int Width = Screen.FromControl(this).Bounds.Width;
            int Height = Screen.FromControl(this).Bounds.Height;
            this.QuitAtY = Height - this.Size.Height;
            this.Location = new Point(Width - this.Size.Width, Height);

            this.DescriptionLabel.Text = $"A change was detected in '{this.Name}'.";
        }

        private void AnimationTimer_Tick(object sender, EventArgs e) {
            if (this.Location.Y > this.QuitAtY) {
                this.Location = new Point(this.Location.X, this.Location.Y - 2);
                return;
            }
            this.Opacity -= 0.01;
            if (this.Opacity == 0) {
                this.Close();
            }
        }
    }
}