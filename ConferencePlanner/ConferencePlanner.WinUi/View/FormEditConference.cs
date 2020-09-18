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
        public int conferenceId;
        public int locationId;
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
            conferenceId = updatedConference.ConferenceId;
            locationId = updatedConference.ConferenceLocationId;
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
                comboBox4.Items.Add(it);
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
                comboBox5.Items.Add(it);
                if (it.conferenceTypeName == updatedConference.ConferenceType)
                {
                    comboBox5.SelectedIndex = conferenceTypes.IndexOf(it);
                }
            }
            //Speaker
            url = "http://localhost:5000/GetConferenceSpeakers";
            List<SpeakerModel> conferenceSpeakers = await HttpClientOperations.GetOperation<SpeakerModel>(url);
            if (conferenceSpeakers.Count != 0)
                foreach (SpeakerModel it in conferenceSpeakers)
                {
                    comboBox6.Items.Add(it);
                    if (it.DictionarySpeakerName == updatedConference.ConferenceMainSpeaker)
                    {
                        comboBox6.SelectedIndex = conferenceSpeakers.IndexOf(it);
                    }
                }
            else
            {
                comboBox6.Items.Add("");
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
        public void Alert(string msg)
        {
            FormAlert frm = new FormAlert();
            frm.ShowAlert(msg);
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            ConferenceModel conferenceUpdated = new ConferenceModel();
            ConferenceTypeModel newType = new ConferenceTypeModel();
            newType = (ConferenceTypeModel)comboBox5.SelectedItem;
            ConferenceCategoryModel newCategory = new ConferenceCategoryModel();
            newCategory = (ConferenceCategoryModel)comboBox4.SelectedItem;
            ConferenceCityModel newCity = (ConferenceCityModel)comboBox3.SelectedItem;
            ConferenceXSpeakerModel newCxs = new ConferenceXSpeakerModel();
            SpeakerModel newSpeaker = new SpeakerModel();
            newSpeaker = (SpeakerModel)comboBox6.SelectedItem;
            Console.WriteLine(newSpeaker.DictionarySpeakerId);
            conferenceUpdated.ConferenceId = conferenceId;
            conferenceUpdated.ConferenceName = textBox1.Text;
            
            conferenceUpdated.ConferenceStartDate = dateTimePicker1.Value;
            conferenceUpdated.ConferenceEndDate = dateTimePicker2.Value;
            conferenceUpdated.ConferenceTypeId = newType.conferenceTypeId;
            conferenceUpdated.ConferenceCategoryId = newCategory.conferenceCategoryId;

            newCxs.conferenceId = conferenceUpdated.ConferenceId;
            newCxs.DictionarySpeakerId = newSpeaker.DictionarySpeakerId;
            newCxs.isMain = true;

            
            conferenceUpdated.ConferenceTypeId = newType.conferenceTypeId;
            conferenceUpdated.ConferenceCategoryId = newCategory.conferenceCategoryId;
            if (conferenceUpdated.ConferenceName == "" || textBox4.Text=="" || comboBox3.Text==""|| comboBox2.Text == "")
            {
                this.Alert("Please, fill in all fields.");
            }
            else if (conferenceUpdated.ConferenceStartDate >= conferenceUpdated.ConferenceEndDate)
            {
                this.Alert("The dates entered are invalid.");
            }
            else
            {
                HttpClientOperations.PutOperation<ConferenceXSpeakerModel>("http://localhost:5000/api/ConferenceXSpeaker/updateSpeaker", newCxs);
                HttpClientOperations.PutOperation<ConferenceModel>("http://localhost:5000/api/Conference/update", conferenceUpdated);
                this.Close(); 
;            }
            LocationModel newLocation = new LocationModel();
            newLocation.LocationId = locationId;
            newLocation.LocationAddress = textBox4.Text.ToString();
            newLocation.DictionaryCityId = newCity.ConferenceCityId;
            HttpClientOperations.PutOperation<LocationModel>("http://localhost:5000/location/update", newLocation);
            HttpClientOperations.PutOperation<ConferenceXSpeakerModel>("http://localhost:5000/api/ConferenceXSpeaker/updateSpeaker", newCxs);
            HttpClientOperations.PutOperation<ConferenceModel>("http://localhost:5000/api/Conference/update", conferenceUpdated);

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
