using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi.View
{
    public partial class FormAddConferenceGeneralDetails : Form
    {
        public static string address;
        public static string title;
        public static DateTime startDate;
        public static DateTime endDate;
        public static string email;
        public FormAddConferenceGeneral formGeneral;
        public FormAddConferenceGeneralDetails()
        {
            InitializeComponent();
        }

        private void FormAddConferenceGeneralDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            title = txtTitle.Text.ToString();
            email = txtEmail.Text.ToString();
            startDate = dtpStart.Value;
            endDate = dtpEnd.Value;
            address = txtLocation.Text.ToString();
            FormAddConferenceGeneral.conferenceModel.ConferenceName = title;
            FormAddConferenceGeneral.conferenceModel.ConferenceOrganiserEmail = email;

            FormAddConferenceGeneral.conferenceModel.ConferenceStartDate = startDate;
            FormAddConferenceGeneral.conferenceModel.ConferenceEndDate = endDate;
            FormAddConferenceGeneral.conferenceModel.ConferenceLocation = address;


        }
    }
}
