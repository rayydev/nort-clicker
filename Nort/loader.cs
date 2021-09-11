using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;

namespace Nort
{
    public partial class loader : Form
    {
        public loader()
        {
            InitializeComponent();
        }

        private void loader_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            WebClient webclient = new WebClient();
            if (webclient.DownloadString("https://pastebin.com/raw/Ls7vhw5S").Contains("1.1"))
            {
                this.Hide();
                timer1.Enabled = false;
                string message = "Update found, would you like to download it?";
                string title = "Nort Clicker Updater";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Hide();
                    System.Diagnostics.Process.Start("www.google.com");
                    this.Close();
                }
                else
                {
                    this.Show();
                    timer1.Enabled = true;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            siticoneProgressBar1.Increment(1);
            if (siticoneProgressBar1.Value == 100)
            {
                this.Hide();
                Form1 main = new Form1();
                timer1.Enabled = false;
                main.Show();
            }
        }
    }
}
