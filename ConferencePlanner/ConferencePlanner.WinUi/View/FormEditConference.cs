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
            var url = "http://localhost:5000/GetConferenceCityByLocationId?locationId=" + updatedConference.ConferenceLocationId;
            ConferenceCityModel city = await HttpClientOperations.GetOperationOneElement<ConferenceCityModel>(url);
            
            url = "http://localhost:5000/GetConferenceDistrictByCityId?cityId=" + city.ConferenceCityId;
            DistrictModel district = await HttpClientOperations.GetOperationOneElement<DistrictModel>(url);
            
            url = "http://localhost:5000/GetConferenceCountryByDistrictId?districtId=" + district.DistrictId;
            CountryModel country = await HttpClientOperations.GetOperationOneElement<CountryModel>(url);

            //Category
            url = "http://localhost:5000/api/ConferenceCategory/GetAllCategories";
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
            //Country 
            url = "http://localhost:5000/GetCountry";
            List<CountryModel> countries = await HttpClientOperations.GetOperation<CountryModel>(url);
            foreach (CountryModel c in countries)
            {
                comboBox1.Items.Add(c);
                if (c.CountryId == country.CountryId)
                {
                    comboBox1.SelectedIndex = countries.IndexOf(c);
                }
            }
            //District
            url = "http://localhost:5000/GetConferenceDistrictByCountryId?countryId=" + country.CountryId;
            List<DistrictModel> districts = await HttpClientOperations.GetOperation<DistrictModel>(url);
            foreach (DistrictModel d in districts)
            {
                comboBox2.Items.Add(d);
                if (d.DistrictId == district.DistrictId)
                {
                    comboBox2.SelectedIndex = districts.IndexOf(d);
                }
            }
            //City
            url = "http://localhost:5000/GetConfereceCitiesById?districtId=" + city.ConferenceDistrictId;
            List<ConferenceCityModel> cities = await HttpClientOperations.GetOperation<ConferenceCityModel>(url);
            foreach (ConferenceCityModel c in cities)
            {
                comboBox3.Items.Add(c);
                if (c.ConferenceCityName == city.ConferenceCityName)
                {
                    comboBox3.SelectedIndex = cities.IndexOf(c);
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CountryModel newCountry = new CountryModel();
            newCountry = (CountryModel)comboBox1.SelectedItem;
            Console.WriteLine(newCountry.CountryName);
            comboBox2.Items.Clear();
            comboBox2.Items.Add("");
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            var url = "http://localhost:5000/GetConferenceDistrictByCountryId?countryId=" + newCountry.CountryId;
            List<DistrictModel> districts = await HttpClientOperations.GetOperation<DistrictModel>(url);
            if(districts.Count == 0)
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("");
                comboBox3.Items.Clear();
                comboBox3.Text = "";
            }
            else
            {
                foreach (DistrictModel d in districts)
                {
                    comboBox2.Items.Add(d);
                }
                try
                {
                    comboBox2.SelectedIndex = 0;
                }
                catch
                {
                    return;
                }
            }
            
        }

        private async void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DistrictModel newDistrict = new DistrictModel();
            newDistrict = (DistrictModel)comboBox2.SelectedItem;
            Console.WriteLine(newDistrict.DistrictName);
            comboBox3.Items.Clear();
            comboBox3.Items.Add("");
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            var url = "http://localhost:5000/GetConfereceCitiesById?districtId=" + newDistrict.DistrictId;
            List<ConferenceCityModel> cities = await HttpClientOperations.GetOperation<ConferenceCityModel>(url);
            foreach (ConferenceCityModel d in cities)
            {
                comboBox3.Items.Add(d);
            }
            try
            {
                comboBox3.SelectedIndex = 0;
            }
            catch
            {
                return;
            }
        }
    }
}
