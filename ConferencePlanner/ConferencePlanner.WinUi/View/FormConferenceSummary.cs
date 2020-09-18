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
using Newtonsoft.Json;

namespace ConferencePlanner.WinUi.View
{
    public partial class FormConferenceSummary : Form
    {
        public static LocationModel location2 = new LocationModel();
       
        public static ConferenceModel conferenceModel = new ConferenceModel();
        public static Conference conference = new Conference();
        public static string countryName;
        public static string districtName;
        public static string cityName;
        public static int districtId = new int();
        public int locId = 0;
        public int confId = 0;


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
            location2 = FormAddConferenceGeneral.location;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_ClickAsync(object sender, EventArgs e)
        {
            var urlLocation = "http://localhost:5000/location/new";

            LocationModel locationModel = new LocationModel() { CityId = location2.CityId, Address = FormAddConferenceGeneral.locationAddress };

            HttpClientOperations.PostOperation(urlLocation, locationModel);

            locId = await GetLocationId(locationModel.CityId, locationModel.Address);
            confId = await GetLastConferenceId();
            var urlConference = "http://localhost:5000/api/Conference/new";

            ConferenceModelDB conferenceToAdd = new ConferenceModelDB
            {
                ConferenceName = conferenceModel.ConferenceName,
                ConferenceStartDate = conferenceModel.ConferenceStartDate,
                ConferenceEndDate = conferenceModel.ConferenceEndDate,
                ConferenceOrganiserEmail = conferenceModel.ConferenceOrganiserEmail,
                ConferenceLocationId = locId,
                ConferenceCategoryId = conferenceModel.ConferenceCategoryId,
                ConferenceTypeId = conferenceModel.ConferenceTypeId,
                ConferenceMainSpeakerId = conferenceModel.SpeakerId
            };

            HttpClientOperations.PostOperation(urlConference, conferenceToAdd);

            confId = await GetLastConferenceId();

            ConferenceXspeaker mainSpeakerToAdd = new ConferenceXspeaker
            {
                DictionarySpeakerId = conferenceModel.SpeakerId,
                ConferenceId = confId,
                IsMain = true
            };

            var urlSpeaker = "http://localhost:5000//api/ConferenceXSpeaker/AddSpeakerInConference";

            HttpClientOperations.PostOperation(urlSpeaker, mainSpeakerToAdd);
        }
        private async Task<int> GetLocationId(int cityId, string locationAddress)
        {
            int locationId = 0;
            HttpClient httpClient = HttpClientFactory.Create();
            var url = $"http://localhost:5000/location/getid?cityId={cityId}&address={locationAddress}";
            HttpResponseMessage res = await httpClient.GetAsync(url);

            if (res.StatusCode == HttpStatusCode.OK)
            {
                var content = res.Content;
                var data = await content.ReadAsStringAsync();
                locationId = Convert.ToInt32(JsonConvert.DeserializeObject(data));
            }

            return locationId;
        }
        private async Task<int> GetLastConferenceId()
        {
            int conferenceId = 0;
            HttpClient httpClient = HttpClientFactory.Create();
            var url = $"http://localhost:5000/api/Conference/getLastConferenceId";
            HttpResponseMessage res = await httpClient.GetAsync(url);

            if (res.StatusCode == HttpStatusCode.OK)
            {
                var content = res.Content;
                var data = await content.ReadAsStringAsync();
                conferenceId = Convert.ToInt32(JsonConvert.DeserializeObject(data));
            }

            return conferenceId;
        }
    }
}
