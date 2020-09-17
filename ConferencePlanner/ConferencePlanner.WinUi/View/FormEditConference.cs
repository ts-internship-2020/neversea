using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.WinUi.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi.View
{
    public partial class FormEditConference : Form
    {
        public FormEditConference()
        {
            InitializeComponent();
        }
        public FormEditConference(ConferenceModel updatedConference)
        {      

            InitializeComponent();
            InitializeComboboxes(updatedConference);
            textBox1.Text = updatedConference.ConferenceName;
            textBox4.Text = updatedConference.ConferenceLocation;
            dateTimePicker1.Value = updatedConference.ConferenceStartDate;
            dateTimePicker2.Value = updatedConference.ConferenceEndDate;
            comboBox4.SelectedItem = updatedConference.ConferenceCategory;
        }
        private async void InitializeComboboxes(ConferenceModel updatedConference)
        {
            //Category
            var url = "http://localhost:5000/api/ConferenceCategory/GetAllCategories";
            List<ConferenceCategoryModel> conferenceCategories = await HttpClientOperations.GetOperation<ConferenceCategoryModel>(url);
            foreach(ConferenceCategoryModel it in conferenceCategories)
            {
                comboBox4.Items.Add(it.conferenceCategoryName);
                if(it.conferenceCategoryName == updatedConference.ConferenceCategory)
                {
                    comboBox4.SelectedIndex = conferenceCategories.IndexOf(it);
                }    
            }

            //Type
            url = "http://localhost:5000/api/ConferenceType/GetAllTypes";
            List<ConferenceTypeModel> conferenceTypes = await HttpClientOperations.GetOperation<ConferenceTypeModel>(url);
            foreach (ConferenceTypeModel it in conferenceTypes)
            {
                comboBox5.Items.Add(it.conferenceTypeName);
                if (it.conferenceTypeName == updatedConference.ConferenceType)
                {
                    comboBox5.SelectedIndex = conferenceTypes.IndexOf(it);
                }
            }
            //Speaker
            url = "http://localhost:5000/GetConferenceSpeakers";
            List<SpeakerModel> conferenceSpeakers = await HttpClientOperations.GetOperation<SpeakerModel>(url);
            foreach (SpeakerModel it in conferenceSpeakers)
            {
                comboBox6.Items.Add(it.DictionarySpeakerName);
                if (it.DictionarySpeakerName == updatedConference.ConferenceMainSpeaker)
                {
                    comboBox6.SelectedIndex = conferenceSpeakers.IndexOf(it);
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
