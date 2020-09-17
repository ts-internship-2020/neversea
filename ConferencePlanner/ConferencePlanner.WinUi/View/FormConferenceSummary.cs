using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ado.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using ConferencePlanner.WinUi.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ConferencePlanner.WinUi.View
{
    public partial class FormConferenceSummary : Form
    {
        public static ConferenceModel conferenceModel = new ConferenceModel();
        public static Conference conference = new Conference();
        public static string countryName;
        public static string districtName;
        public static string cityName;


        public FormConferenceSummary()
        {
            InitializeComponent();
        }

        private void FormConferenceSummary_Load(object sender, EventArgs e)
        {
            lbTitle.Text = conferenceModel.ConferenceName;
            lbEmail.Text = conferenceModel.ConferenceOrganiserEmail;
            lbStart.Text = conferenceModel.ConferenceStartDate.ToString(("MM-dd-yyyy"));
            lbEnd.Text = conferenceModel.ConferenceEndDate.ToString(("MM-dd-yyyy"));
            lbCountry.Text = countryName.ToString();
            lbDistrict.Text = districtName.ToString();
            lbCity.Text = cityName.ToString();
            lbType.Text = conferenceModel.ConferenceType.ToString();
            lbCategory.Text = conferenceModel.ConferenceCategory.ToString();
            lbSpeaker.Text = conferenceModel.ConferenceMainSpeaker.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
