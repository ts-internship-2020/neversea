using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi.View
{
    public partial class AddConferenceForm : Form
    {

        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        public AddConferenceForm()
        {
            InitializeComponent();
            random = new Random();
            /*tabMenuPanel.BackColor = Color.FromArgb(51, 51, 76);
            tabMenuPanel.ForeColor = Color.Gainsboro;
            panelTitle.BackColor = Color.FromArgb(51, 51, 76);
            panelTitle.ForeColor = Color.Gainsboro;*/
        }

        protected override void OnLoad(EventArgs e)
        {
            LoadTheme();
            base.OnLoad(e);

        }

        private void LoadTheme()
        {


            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    btnPrevious.ForeColor = color;
                    btnPrevious.BackColor = Color.White;
                    btnNext.ForeColor = color;
                    btnNext.BackColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                }
            }
        }

        private void DisableButton()
        {
            tabMenuPanel.BackColor = Color.FromArgb(51, 51, 76);
            tabMenuPanel.ForeColor = Color.Gainsboro;
            foreach (Control previousBtn in tabMenuPanel.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.Enabled = false;
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopAddConference.Controls.Add(childForm);
            this.panelDesktopAddConference.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        private void btnGeneral_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddConferenceGeneral(), sender);
        }

        private void btnCountry_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddConferenceCountry(), sender);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddConferenceCountry(), sender);
        }
    }
}
