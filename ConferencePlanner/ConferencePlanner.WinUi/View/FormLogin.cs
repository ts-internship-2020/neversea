using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi.View
{
    public partial class FormLogin : Form
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        private readonly IConferenceRepository conferenceRepository;
        private readonly ICountryRepository countryRepository;
        private readonly IConferenceAttendanceRepository conferenceAttendanceRepository;
        private readonly IConferenceTypeRepository _conferenceTypeRepository;
        private readonly IConferenceCategoryRepository _conferenceCategoryRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly IConferenceCityRepository _conferenceCityRepository;

        public FormLogin(IConferenceRepository ConferenceRepository, ICountryRepository CountryRepository, IConferenceTypeRepository conferenceTypeRepository, IConferenceCategoryRepository conferenceCategoryRepository, IDistrictRepository districtRepository, IConferenceCityRepository conferenceCityRepository, IConferenceAttendanceRepository ConferenceAttendanceRepository)
        {
            player.SoundLocation = @"C:\Users\andrei.stancescu\Downloads\chelutuwav.wav";
            _conferenceTypeRepository = conferenceTypeRepository;
            conferenceRepository = ConferenceRepository;
            countryRepository = CountryRepository;
            conferenceAttendanceRepository = ConferenceAttendanceRepository;

            _conferenceCategoryRepository = conferenceCategoryRepository;
            _districtRepository = districtRepository;
            _conferenceCityRepository = conferenceCityRepository;
            InitializeComponent();

        }
        public void Alert(string msg)
        {
            FormAlert frm = new FormAlert();
            //frm.showAlert(msg);
        }
        private void button1_Click(object sender, EventArgs e)
        {

            string pattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            if ((chkb_email.Checked) && (Regex.IsMatch(tb_email.Text, pattern)))
            {
                Properties.Settings.Default.Email = tb_email.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Email = "";
                Properties.Settings.Default.Save();
            }
            string emailCopy = this.tb_email.Text;
            //      TabSpectOrg tabSpectOrg = new TabSpectOrg();
            //AddConferenceForm addConferenceForm = new AddConferenceForm();

            FormHomePage homePage = new FormHomePage(conferenceRepository, emailCopy, _conferenceTypeRepository, countryRepository, _conferenceCategoryRepository, _districtRepository, _conferenceCityRepository, conferenceAttendanceRepository);
            if (Regex.IsMatch(tb_email.Text, pattern))
            {
                //           addConferenceForm.Show();
                //          tabSpectOrg.Show();
                homePage.Show();
                this.Hide();
            }
            if (tb_email.Text == "")
            {
                this.Alert("Email is empty");
            }

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            //tb_email.Text = "admin@admin.com";
            // player.Play();
            if (Properties.Settings.Default.Email != string.Empty)
            {
                tb_email.Text = Properties.Settings.Default.Email;
            }
            this.tb_email.Enter += new EventHandler(tb_email_Enter);
            this.tb_email.Leave += new EventHandler(tb_email_Leave);
            tb_email_SetText();
        }

        private void tb_email_Leave(object sender, EventArgs e)
        {
            string pattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            if (Regex.IsMatch(tb_email.Text, pattern))
            {
                errorProvider2.Clear();
            }
            else
            {
                errorProvider2.SetError(this.tb_email, " Please provide a valid Mail Address");
                return;
            }
            {
                if (tb_email.Text.Trim() == "")
                    tb_email_SetText();
            }
        }

        protected void tb_email_SetText()
        {
            this.tb_email.Text = "Type an email...";
            tb_email.ForeColor = Color.Gray;
        }

        private void tb_email_Enter(object sender, EventArgs e)
        {
            if (tb_email.ForeColor == Color.Black)
                return;
            tb_email.Text = "";
            tb_email.ForeColor = Color.Black;

        }

        private void tb_email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_enterEmail.PerformClick();
            }
        }

        private void tb_email_TextChanged(object sender, EventArgs e)
        {
            tb_email.Text = "paul.popescu@gmail.com";
        }
    }
}
