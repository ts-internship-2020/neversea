﻿using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ado.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi.View
{
    public partial class FormLogin : Form
    {
      //  System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        private readonly IConferenceRepository conferenceRepository;
        private readonly ICountryRepository countryRepository;
        private readonly IConferenceAttendanceRepository conferenceAttendanceRepository;
        private readonly IConferenceTypeRepository _conferenceTypeRepository;
        private readonly IConferenceCategoryRepository _conferenceCategoryRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly IConferenceCityRepository _conferenceCityRepository;
        private readonly IConferenceSpeakerRepository _conferenceSpeakerRepository;
        private readonly IConferenceLocationRepository _conferenceLocationRepository;

        public FormLogin(IConferenceRepository ConferenceRepository, ICountryRepository CountryRepository, IConferenceTypeRepository conferenceTypeRepository, IConferenceCategoryRepository conferenceCategoryRepository, IDistrictRepository districtRepository, IConferenceCityRepository conferenceCityRepository, IConferenceAttendanceRepository ConferenceAttendanceRepository, IConferenceLocationRepository conferenceLocationRepository, IConferenceSpeakerRepository conferenceSpeakerRepository)
        {
           // player.SoundLocation = @"C:\Users\andrei.stancescu\Downloads\chelutuwav.wav";
            _conferenceTypeRepository = conferenceTypeRepository;
            conferenceRepository = ConferenceRepository;
            countryRepository = CountryRepository;
            conferenceAttendanceRepository = ConferenceAttendanceRepository;

            _conferenceCategoryRepository = conferenceCategoryRepository;
            _districtRepository = districtRepository;
            _conferenceCityRepository = conferenceCityRepository;
            _conferenceSpeakerRepository = conferenceSpeakerRepository;
            _conferenceLocationRepository = conferenceLocationRepository;

            InitializeComponent();

            this.Text = string.Empty;
            this.ControlBox = false;

        }
        public void Alert(string msg)
        {
            FormAlert frm = new FormAlert();
            frm.ShowAlert(msg);
        }
        private void button1_Click(object sender, EventArgs e)
        {

            string pattern = "^([\\w-]+(?:\\.[\\w-]+)*)@((?:[\\w-]+\\.)*\\w[\\w-]{0,66})\\.([A-Za-z]{2,6}(?:\\.[A-Za-z]{2,6})?)$";
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

            FormHomePage homePage = new FormHomePage(conferenceRepository, emailCopy, _conferenceTypeRepository, countryRepository, _conferenceCategoryRepository, _districtRepository, _conferenceCityRepository, conferenceAttendanceRepository, _conferenceSpeakerRepository, _conferenceLocationRepository);
            if (Regex.IsMatch(tb_email.Text, pattern))
            {
                //           addConferenceForm.Show();
                //          tabSpectOrg.Show();
                homePage.Show();
                this.Hide();
            }
            if (tb_email.Text == ""||tb_email==null)
            {
                this.Alert("Email is empty");
                errorProvider2.Clear();

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
            string pattern = "^([\\w-]+(?:\\.[\\w-]+)*)@((?:[\\w-]+\\.)*\\w[\\w-]{0,66})\\.([A-Za-z]{2,6}(?:\\.[A-Za-z]{2,6})?)$";
            if (Regex.IsMatch(tb_email.Text, pattern))
            {
                errorProvider2.Clear(); 
                
            }
            else
            {
                errorProvider2.SetError(this.tb_email, " Please provide a valid Mail Address");
                SystemSounds.Hand.Play();
                return;
            }
         
         if (tb_email.Text.Trim() == "") { 
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
            errorProvider2.Clear();
        }

        private void btnExit_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void tb_email_TextChanged_1(object sender, EventArgs e)
        {
            
                errorProvider2.Clear();
        }
    }
}
