using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;


namespace Nort
{
    // if you decompiled that, you are a very big gay
    public partial class Form1 : Form
    {

        [DllImport(dllName: "user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowTextLength(IntPtr hwnd);


        [DllImport("user32.dll")]
        private static extern int GetWindowTextW([In] IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] [Out]
            StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern int GetWindowThreadProcessId([In] IntPtr hWnd, ref int lpdwProcessId);


        private const int LEFTUP = 0x0004;
        private const int LEFTDOWN = 0x0002;

        private string currentWindow = "";
        private int currentPID;
        private int mcpid;

        public Form1()
        {
            InitializeComponent();
        }

      

        

        public void GetForeGroundWindownInfo()
        {
            IntPtr foregroundWindow = GetForegroundWindow();
            if (!foregroundWindow.Equals(IntPtr.Zero))
            {
                int windowTextLenght = GetWindowTextLength(foregroundWindow);
                StringBuilder stringbuilder = new StringBuilder("", windowTextLenght + 1);
                if (windowTextLenght > 0)
                {
                    GetWindowTextW(foregroundWindow, stringbuilder, stringbuilder.Capacity);
                }

                int currentpid = 0;
                GetWindowThreadProcessId(foregroundWindow, ref currentpid);
                Process[] processbyName = Process.GetProcessesByName("javaw");
                foreach (Process process in processbyName)
                {
                    mcpid = process.Id;
                }

                currentWindow = stringbuilder.ToString();
                currentPID = currentpid;

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            label9.Text = $"{siticoneTrackBar1.Value}";
        }

        private void siticoneTrackBar2_Scroll(object sender, ScrollEventArgs e)
        {
            label10.Text = $"{siticoneTrackBar2.Value}";
        }

        private void siticoneTrackBar3_Scroll(object sender, ScrollEventArgs e)
        {
            label12.Text = $"{siticoneTrackBar3.Value}";
        }

        private void siticoneTrackBar4_Scroll(object sender, ScrollEventArgs e)
        {
            label13.Text = $"{siticoneTrackBar4.Value}";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void siticoneTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label9.Text = $"{siticoneTrackBar1.Value}";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //watermark wtrmark = new watermark();
            //wtrmark.Show();
            var anydesk = "anydesk";
            var target = Process.GetProcessesByName(anydesk).FirstOrDefault();

            if (target != null)
            {
                MessageBox.Show("ERROR: ADTEerr", "error");
            }
            this.Opacity = 0;
            //fadeanimation.Start();
            

        }

        private void Clicktimer_Tick(object sender, EventArgs e)
        {
            GetForeGroundWindownInfo();
            Random rnd = new Random();
            int maxcps = (int)Math.Round(1000.0 / (siticoneTrackBar1.Value + siticoneTrackBar2.Value * 0.2));
            int mincps = (int)Math.Round(1000.0 / (siticoneTrackBar1.Value + siticoneTrackBar2.Value * 0.4));
            try
            {
                Clicktimer.Interval = rnd.Next(mincps, maxcps);
            }
            catch
            {
                //Ignored
            }

            if (currentPID == Process.GetCurrentProcess().Id)
            {
                return;
            }

            if (siticoneToggleSwitch1.Checked && currentPID != mcpid && mcpid != 0)
            {
                return;
            }

            bool mousdown = MouseButtons == MouseButtons.Left;
            if (mousdown)
            {
                mouse_event(dwFlags: LEFTUP, dx: 0, dy: 0, cButtons: 0, dwExtraInfo: 0);
                Thread.Sleep(millisecondsTimeout: rnd.Next(1, 6));
                mouse_event(dwFlags: LEFTDOWN, dx: 0, dy: 0, cButtons: 0, dwExtraInfo: 0);
            }
        }

        private void siticoneRoundedButton1_Click(object sender, EventArgs e)
        {
            if (siticoneRoundedButton1.Text.Contains("On"))
            {
                Clicktimer.Start();
                siticoneRoundedButton1.Text = "Toogle: Off";
            }
            else
            {
                Clicktimer.Stop();
                siticoneRoundedButton1.Text = "Toogle: On";
            }
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void siticoneToggleSwitch2_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneToggleSwitch2.Checked)
            {
                siticoneTrackBar1.Maximum = 50;
                siticoneTrackBar2.Maximum = 50;
                siticoneTrackBar3.Maximum = 100;
                siticoneTrackBar4.Maximum = 100;
            }
            else
            {
                siticoneTrackBar1.Maximum = 20;
                siticoneTrackBar2.Maximum = 20;
                siticoneTrackBar3.Maximum = 30;
                siticoneTrackBar4.Maximum = 30;
            }
        }

        private void siticoneTrackBar3_Scroll_1(object sender, ScrollEventArgs e)
        {
            label12.Text = $"{siticoneTrackBar3.Value}";
        }

        private void siticoneTrackBar4_Scroll_1(object sender, ScrollEventArgs e)
        {
            label13.Text = $"{siticoneTrackBar4.Value}";
        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("clicker by rxvyonline#1337");
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            string exename = AppDomain.CurrentDomain.FriendlyName;
            DirectoryInfo d = new DirectoryInfo(@"C:\Windows\Prefetch");
            FileInfo[] Files = d.GetFiles(exename + "*");
            foreach (FileInfo file in Files)
            {
                File.Delete(file.FullName);
                
            }
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            listBox1.Visible = true;
            label14.Visible = true;
            panel2.Location = new Point(394, 52);
            listBox1.Location = new Point(394, 92);
        }

        private void siticoneButton5_Click(object sender, EventArgs e)
        {
            //panel2.Visible = false;
            //listBox1.Visible = false;
            //label14.Visible = false;
            panel2.Location = new Point(555, 52);
            listBox1.Location = new Point(555, 92);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == "Hypixel")
            {
                siticoneTrackBar1.Value = 12;
                label9.Text = "12";
                siticoneTrackBar2.Value = 8;
                label10.Text = "8";
                siticoneToggleSwitch1.Checked = true;
                string message = "Successfully loaded Hypixel config";
                string title = " ";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            }

            if (listBox1.SelectedItem == "Deafult")
            {
                siticoneTrackBar1.Value = 0;
                label9.Text = "0";
                siticoneTrackBar2.Value = 0;
                label10.Text = "0";
                siticoneToggleSwitch1.Checked = false;
                string message = "Successfully loaded Deafult config";
                string title = " ";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            }

            if (listBox1.SelectedItem == "Lunar")
            {
                siticoneTrackBar1.Value = 13;
                label9.Text = "13";
                siticoneTrackBar2.Value = 8;
                label10.Text = "8";
                siticoneToggleSwitch1.Checked = true;
                string message = "Successfully loaded Lunar config";
                string title = " ";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            }

            if (listBox1.SelectedItem == "Minemen Club")
            {
                siticoneTrackBar1.Value = 10;
                label9.Text = "10";
                siticoneTrackBar2.Value = 7;
                label10.Text = "7";
                siticoneToggleSwitch1.Checked = true;
                string message = "Successfully loaded Minemen Club config";
                string title = " ";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            }

            if (listBox1.SelectedItem == "dxvy")
            {
                siticoneTrackBar1.Value = 16;
                label9.Text = "16";
                siticoneTrackBar2.Value = 11;
                label10.Text = "11";
                siticoneToggleSwitch1.Checked = true;
                string message = "Successfully loaded dxvy Partner config";
                string title = " ";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton6_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            listBox2.Visible = true;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == "Pink")
            {
                siticoneTrackBar1.ThumbColor = Color.FromArgb(191, 14, 204);
                siticoneTrackBar2.ThumbColor = Color.FromArgb(191, 14, 204);
                siticoneTrackBar3.ThumbColor = Color.FromArgb(191, 14, 204);
                siticoneTrackBar4.ThumbColor = Color.FromArgb(191, 14, 204);
                siticoneButton1.HoverState.ForeColor = Color.FromArgb(191, 14, 204);
                siticoneButton2.HoverState.ForeColor = Color.FromArgb(191, 14, 204);
                siticoneButton3.HoverState.ForeColor = Color.FromArgb(191, 14, 204);
                siticoneButton4.HoverState.ForeColor = Color.FromArgb(191, 14, 204);
                siticoneButton5.HoverState.ForeColor = Color.FromArgb(191, 14, 204);
                siticoneButton6.HoverState.ForeColor = Color.FromArgb(191, 14, 204);
                siticoneToggleSwitch1.CheckedState.FillColor = Color.FromArgb(191, 14, 204);
                siticoneToggleSwitch2.CheckedState.FillColor = Color.FromArgb(191, 14, 204);
                siticoneButton8.HoverState.ForeColor = Color.FromArgb(191, 14, 204);
            }

            if (listBox2.SelectedItem == "Yellow")
            {
                siticoneTrackBar1.ThumbColor = Color.FromArgb(252, 218, 0);
                siticoneTrackBar2.ThumbColor = Color.FromArgb(252, 218, 0);
                siticoneTrackBar3.ThumbColor = Color.FromArgb(252, 218, 0);
                siticoneTrackBar4.ThumbColor = Color.FromArgb(252, 218, 0);
                siticoneButton1.HoverState.ForeColor = Color.FromArgb(252, 218, 0);
                siticoneButton2.HoverState.ForeColor = Color.FromArgb(252, 218, 0);
                siticoneButton3.HoverState.ForeColor = Color.FromArgb(252, 218, 0);
                siticoneButton4.HoverState.ForeColor = Color.FromArgb(252, 218, 0);
                siticoneButton5.HoverState.ForeColor = Color.FromArgb(252, 218, 0);
                siticoneButton6.HoverState.ForeColor = Color.FromArgb(252, 218, 0);
                siticoneToggleSwitch1.CheckedState.FillColor = Color.FromArgb(252, 218, 0);
                siticoneToggleSwitch2.CheckedState.FillColor = Color.FromArgb(252, 218, 0);
                siticoneButton8.HoverState.ForeColor = Color.FromArgb(252, 218, 0);
            }

            if (listBox2.SelectedItem == "Deafult (purple)")
            {
                siticoneTrackBar1.ThumbColor = Color.FromArgb(108, 0, 209);
                siticoneTrackBar2.ThumbColor = Color.FromArgb(108, 0, 209);
                siticoneTrackBar3.ThumbColor = Color.FromArgb(108, 0, 209);
                siticoneTrackBar4.ThumbColor = Color.FromArgb(108, 0, 209);
                siticoneButton1.HoverState.ForeColor = Color.FromArgb(108, 0, 209);
                siticoneButton2.HoverState.ForeColor = Color.FromArgb(108, 0, 209);
                siticoneButton3.HoverState.ForeColor = Color.FromArgb(108, 0, 209);
                siticoneButton4.HoverState.ForeColor = Color.FromArgb(108, 0, 209);
                siticoneButton5.HoverState.ForeColor = Color.FromArgb(108, 0, 209);
                siticoneButton6.HoverState.ForeColor = Color.FromArgb(108, 0, 209);
                siticoneToggleSwitch1.CheckedState.FillColor = Color.FromArgb(108, 0, 209);
                siticoneToggleSwitch2.CheckedState.FillColor = Color.FromArgb(108, 0, 209);
                siticoneButton8.HoverState.ForeColor = Color.FromArgb(108, 0, 209);
            }

            if (listBox2.SelectedItem == "Red")
            {
                siticoneTrackBar1.ThumbColor = Color.FromArgb(255, 71, 71);
                siticoneTrackBar2.ThumbColor = Color.FromArgb(255, 71, 71);
                siticoneTrackBar3.ThumbColor = Color.FromArgb(255, 71, 71);
                siticoneTrackBar4.ThumbColor = Color.FromArgb(255, 71, 71);
                siticoneButton1.HoverState.ForeColor = Color.FromArgb(255, 71, 71);
                siticoneButton2.HoverState.ForeColor = Color.FromArgb(255, 71, 71);
                siticoneButton3.HoverState.ForeColor = Color.FromArgb(255, 71, 71);
                siticoneButton4.HoverState.ForeColor = Color.FromArgb(255, 71, 71);
                siticoneButton5.HoverState.ForeColor = Color.FromArgb(255, 71, 71);
                siticoneButton6.HoverState.ForeColor = Color.FromArgb(255, 71, 71);
                siticoneToggleSwitch1.CheckedState.FillColor = Color.FromArgb(255, 71, 71);
                siticoneToggleSwitch2.CheckedState.FillColor = Color.FromArgb(255, 71, 71);
                siticoneButton8.HoverState.ForeColor = Color.FromArgb(255, 71, 71);
            }

            if (listBox2.SelectedItem == "Orange")
            {
                siticoneTrackBar1.ThumbColor = Color.FromArgb(255, 123, 71);
                siticoneTrackBar2.ThumbColor = Color.FromArgb(255, 123, 71);
                siticoneTrackBar3.ThumbColor = Color.FromArgb(255, 123, 71);
                siticoneTrackBar4.ThumbColor = Color.FromArgb(255, 123, 71);
                siticoneButton1.HoverState.ForeColor = Color.FromArgb(255, 123, 71);
                siticoneButton2.HoverState.ForeColor = Color.FromArgb(255, 123, 71);
                siticoneButton3.HoverState.ForeColor = Color.FromArgb(255, 123, 71);
                siticoneButton4.HoverState.ForeColor = Color.FromArgb(255, 123, 71);
                siticoneButton5.HoverState.ForeColor = Color.FromArgb(255, 123, 71);
                siticoneButton6.HoverState.ForeColor = Color.FromArgb(255, 123, 71);
                siticoneToggleSwitch1.CheckedState.FillColor = Color.FromArgb(255, 123, 71);
                siticoneToggleSwitch2.CheckedState.FillColor = Color.FromArgb(255, 123, 71);
                siticoneButton8.HoverState.ForeColor = Color.FromArgb(255, 123, 71);
            }
        }

        private void siticoneButton7_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            listBox2.Visible = false;
        }

        private void siticoneButton8_Click(object sender, EventArgs e)
        {
            settings settings = new settings();
            settings.Show();
            //MessageBox.Show("comming soon!", " ");
        }

        private void fadeanimation_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                fadeanimation.Stop();
            }
            Opacity += 2;

        }
    }
   
 }
