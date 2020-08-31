using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi.View
{
    public partial class FormHomePage : Form
    {
        private readonly IConferenceRepository conferenceRepository;
        private readonly IConferenceTypeRepository conferenceTypeRepository;
        private readonly IConferenceCategoryRepository conferenceCategoryRepository;
        private readonly IDistrictRepository districtRepository;
        private readonly IConferenceCityRepository conferenceCityRepository;
        private readonly IConferenceAttendanceRepository conferenceAttendanceRepository;
        private readonly ICountryRepository countryRepository;

        public string emailCopyFromMainForm;

        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;


        public FormHomePage(IConferenceRepository _conferenceRepository, String emailCopy, IConferenceTypeRepository _conferenceTypeRepository, ICountryRepository _countryRepository, IConferenceCategoryRepository _conferenceCategoryRepository, IDistrictRepository _districtRepository, IConferenceCityRepository _conferenceCityRepository, IConferenceAttendanceRepository _conferenceAttendanceRepository)
        {

            conferenceRepository = _conferenceRepository;
            conferenceAttendanceRepository = _conferenceAttendanceRepository;
            countryRepository = _countryRepository;
            districtRepository = _districtRepository;
            conferenceCityRepository = _conferenceCityRepository;
            conferenceTypeRepository = _conferenceTypeRepository;
            conferenceCategoryRepository = _conferenceCategoryRepository;
            //conferenceCityRepository = _conferenceCityRepository;
            emailCopyFromMainForm = emailCopy;
            //_districtRepository = districtRepository;
            InitializeComponent();

            customizeDesign();
            random = new Random();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void customizeDesign()
        {
            panelOrganizerSubmenu.Visible = false;
        }

        private void hideSubmenu()
        {
            if (panelOrganizerSubmenu.Visible == true)
            {
                panelOrganizerSubmenu.Visible = false;
            }
        }

        private void showSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
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
                    currentButton.Font = new System.Drawing.Font("Century Gothic", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = ThemeColor.ChangeColorBrightness(color, -0.2);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.2);
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelSidebarMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = ColorTranslator.FromHtml("#39189E");
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }

            foreach (Control previousBtn in panelOrganizerSubmenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = ColorTranslator.FromHtml("#39189E");
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text.ToUpper();
        }

        private void btnSpectator_Click(object sender, EventArgs e)
        {
            FormSpectator formSpectator = new FormSpectator(conferenceRepository, emailCopyFromMainForm, conferenceAttendanceRepository);

            OpenChildForm(formSpectator, sender);
        }

        private void btnConferences_Click(object sender, EventArgs e)
        {

            FormOrganizer formOrganizer = new FormOrganizer(conferenceRepository, emailCopyFromMainForm);

            OpenChildForm(formOrganizer, sender);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FormAddConferenceGeneral formAddConferenceGeneral = new FormAddConferenceGeneral(sender, countryRepository, districtRepository, conferenceCityRepository, conferenceTypeRepository, conferenceCategoryRepository);
            OpenChildForm(formAddConferenceGeneral, sender);
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnOrganizer_MouseHover(object sender, EventArgs e)
        {
            showSubmenu(panelOrganizerSubmenu);
        }

        private void btnOrganizer_Click(object sender, EventArgs e)
        {
            showSubmenu(panelOrganizerSubmenu);
        }

        private void panelTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelTitleBar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}

