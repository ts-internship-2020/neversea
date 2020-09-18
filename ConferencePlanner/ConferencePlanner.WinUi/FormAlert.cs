using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi
{
    public partial class FormAlert : Form
    {
        public FormAlert()
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(24)))), ((int)(((byte)(158)))));

        }
        public enum enmAction
        {
            wait,
            start,
            close
        }
        private FormAlert.enmAction action;

        public int x { get; private set; }
        public int y { get; private set; }

        public void ShowAlert(string msg)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 0; i < 2; i++)
            {
                fname = "alert" + i.ToString();
                FormAlert frm = (FormAlert)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i;
                    break;
                }
            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            this.lb_msgText.Text = msg;

            this.Show();
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            action = enmAction.close;
        }
        public partial class LowerRightForm : Form
        {

            protected override void OnLoad(EventArgs e)
            {
                PlaceLowerRight();
                base.OnLoad(e);
            }

            private void PlaceLowerRight()
            {
                //Determine "rightmost" screen
                Screen rightmost = Screen.AllScreens[0];
                foreach (Screen screen in Screen.AllScreens)
                {
                    if (screen.WorkingArea.Right > rightmost.WorkingArea.Right)
                        rightmost = screen;
                }

                this.Left = rightmost.WorkingArea.Right - this.Width;
                this.Top = rightmost.WorkingArea.Bottom - this.Height;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timer1.Interval = 2500;
                    action = enmAction.close;
                    break;

                case enmAction.start:
                    timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = enmAction.wait;
                        }
                    }
                    break;
                case enmAction.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

    }
}
