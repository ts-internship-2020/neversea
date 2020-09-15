﻿using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ado.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using ConferencePlanner.WinUi.Utilities;
using Newtonsoft.Json;
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
    public partial class FormAddConferenceGeneral : Form
    {
        public static int districtId = new int();
        public   int locId = 0;
        //public static int locationId = new int();
        public static string locationAddress = new string("");
        public static int countryId = new int();
       // public static int typeId = new int();
        public static LocationModel location = new LocationModel();
        public static ConferenceModel conferenceModel = new ConferenceModel();
        public static Conference conference = new Conference();
        private readonly IConferenceRepository conferenceRepository;
        private readonly IConferenceAttendanceRepository conferenceAttendanceRepository;
        private readonly ICountryRepository countryRepository;
        private readonly IDistrictRepository districtRepository;
        private readonly IConferenceCityRepository conferenceCityRepository;
        private readonly IConferenceTypeRepository conferenceTypeRepository;
        private readonly IConferenceCategoryRepository conferenceCategoryRepository;
        private readonly IConferenceSpeakerRepository conferenceSpeakerRepository;



        private readonly IConferenceLocationRepository _conferenceLocationRepository;
        private int tabCount = 1;
        private Form activeForm;


        public FormAddConferenceGeneral(object sender, ICountryRepository _countryRepository, IDistrictRepository _districtRepository, IConferenceCityRepository _conferenceCityRepository, IConferenceTypeRepository _conferenceTypeRepository, IConferenceCategoryRepository _conferenceCategoryRepository, IConferenceLocationRepository conferenceLocationRepository, IConferenceSpeakerRepository _conferenceSpeakerRepository, IConferenceRepository _conferenceRepository)
        {
            countryRepository = _countryRepository;
            districtRepository = _districtRepository;
            conferenceCityRepository = _conferenceCityRepository;
            conferenceTypeRepository = _conferenceTypeRepository;
            conferenceCategoryRepository = _conferenceCategoryRepository;
            _conferenceLocationRepository = conferenceLocationRepository;
            conferenceSpeakerRepository = _conferenceSpeakerRepository;
            conferenceRepository = _conferenceRepository;


            InitializeComponent();
            OpenChildForm(new FormAddConferenceGeneralDetails(), sender);
        }


        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelAddDetails.Controls.Add(childForm);
            this.panelAddDetails.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void addCurrentStepButtonStyle(Button btn)
        {
            btn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        private void addFutureStepButtonStyle(Button btn)
        {
            btn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn.ForeColor = btnStep1.ForeColor = System.Drawing.SystemColors.ControlDark;
        }

        private void addPreviousStepButtonStyle(Button btn)
        {
            btn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn.ForeColor = btnStep1.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        private void formatRoadMap(int tabCount)
        {


            switch (tabCount)
            {
                case 1:
                    {
                        btnStep1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        btnStep1.ForeColor = System.Drawing.SystemColors.ControlText;
                        foreach (Control ctrl in panelRoadmap.Controls)
                        {
                            if (ctrl.GetType() == typeof(Button))
                            {
                                Button btn = (Button)ctrl;
                                if (btn.Name == "btnStep1")
                                {
                                    addCurrentStepButtonStyle(btn);
                                }
                                else
                                {
                                    addFutureStepButtonStyle(btn);
                                }
                            }
                        }
                    }
                    break;
                case 2:
                    {
                        addPreviousStepButtonStyle(btnStep1);
                        addCurrentStepButtonStyle(btnStep2);
                        addFutureStepButtonStyle(btnStep3);
                        addFutureStepButtonStyle(btnStep4);
                        addFutureStepButtonStyle(btnStep5);
                        addFutureStepButtonStyle(btnStep6);
                        addFutureStepButtonStyle(btnStep7);
                        btnPrevious.Visible = true;
                        btnNext.Visible = true;
                    }
                    break;
                case 3:
                    {
                        addPreviousStepButtonStyle(btnStep2);
                        addCurrentStepButtonStyle(btnStep3);
                        addFutureStepButtonStyle(btnStep4);
                        addFutureStepButtonStyle(btnStep5);
                        addFutureStepButtonStyle(btnStep6);
                        addFutureStepButtonStyle(btnStep7);
                        btnPrevious.Visible = true;
                        btnNext.Visible = true;
                    }
                    break;
                case 4:
                    {
                        addPreviousStepButtonStyle(btnStep3);
                        addCurrentStepButtonStyle(btnStep4);
                        addFutureStepButtonStyle(btnStep5);
                        addFutureStepButtonStyle(btnStep6);
                        addFutureStepButtonStyle(btnStep7);
                        btnPrevious.Visible = true;
                        btnNext.Visible = true;
                    }
                    break;
                case 5:
                    {
                        addPreviousStepButtonStyle(btnStep4);
                        addCurrentStepButtonStyle(btnStep5);
                        addFutureStepButtonStyle(btnStep6);
                        addFutureStepButtonStyle(btnStep7);
                        btnPrevious.Visible = true;
                        btnNext.Visible = true;
                    }
                    break;
                case 6:
                    {
                        addPreviousStepButtonStyle(btnStep5);
                        addCurrentStepButtonStyle(btnStep6);
                        addFutureStepButtonStyle(btnStep7);
                        btnPrevious.Visible = true; 
                        btnNext.Visible = true;
                    }
                    break;
                case 7:
                    {   
                        addPreviousStepButtonStyle(btnStep6);
                        addCurrentStepButtonStyle(btnStep7);
                        btnNext.Visible = false;
                    }
                    break;
            }
        }



        private void switchTabs(int tabCount, object sender)
        {
            if (tabCount == 8)
            {
                tabCount = 7;
            }


            formatRoadMap(tabCount);

            addPreviousStepButtonStyle(btnStep1);

            switch (tabCount)
            {
                case 1:
                    {
                        FormAddConferenceGeneralDetails formAddDetails = new FormAddConferenceGeneralDetails();
                        OpenChildForm(formAddDetails, sender);
                        btnPrevious.Visible = false;
                        btnNext.Visible = true;
                        addCurrentStepButtonStyle(btnStep1);
                    }
                    break;
                case 2:
                    {
                        FormAddConferenceCountry formAddConferenceCountry = new FormAddConferenceCountry(countryRepository, _conferenceLocationRepository);

                        OpenChildForm(formAddConferenceCountry, sender);
                            btnPrevious.Visible = true;
                        
                    }
                    break;
                case 3:
                    {
                        FormAddConferenceDistrict formAddConferenceDistrict = new FormAddConferenceDistrict(districtRepository, _conferenceLocationRepository);
  
                            OpenChildForm(formAddConferenceDistrict, sender);
                        
                    }
                    break;
                case 4:
                    {
                        FormAddConferenceCity formAddConferenceCity = new FormAddConferenceCity(conferenceCityRepository, _conferenceLocationRepository);
                        OpenChildForm(formAddConferenceCity, sender);
                    }
                    break;
                case 5:
                    {
                        FormAddConferenceType formAddConferenceType = new FormAddConferenceType(conferenceTypeRepository);
                        OpenChildForm(formAddConferenceType, sender);
                    }
                    break;
                case 6:
                    {
                        FormAddConferenceCategory formAddConferenceCategory = new FormAddConferenceCategory(conferenceCategoryRepository);
                        OpenChildForm(formAddConferenceCategory, sender);
                    }
                    break;
                case 7:
                    {
                        FormAddConferenceSpeaker formAddConferenceSpeaker = new FormAddConferenceSpeaker(conferenceSpeakerRepository);
                        OpenChildForm(formAddConferenceSpeaker, sender);
                    }
                    break;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //tabCount++;
            //switchTabs(tabCount, sender);

            // in lucru pt validari
            if (tabCount == 1)
            {
                if (conferenceModel.ConferenceName == null || conferenceModel.ConferenceOrganiserEmail == null || conferenceModel.ConferenceLocation == null)
                {
                    this.Alert("Fill in all fields");
                }
                else
                {
                    tabCount++;
                    switchTabs(tabCount, sender);
                }
            }
            else if (tabCount == 2)
            {
                if (countryId == 0)
                {

                    this.Alert("Select a Country");
                }
                else
                {
                    tabCount++;
                    switchTabs(tabCount, sender);
                }
            }
            else if (tabCount == 3)
            {
                if (districtId == 0)
                {

                    this.Alert("Select a District");
                }
                else
                {
                    tabCount++;
                    switchTabs(tabCount, sender);
                }
            }
            else if (tabCount == 4)
            {

                if (location.CityId== 0)
                {

                    this.Alert("Select a City");
                }
                else
                {
                    tabCount++;
                    switchTabs(tabCount, sender);
                }
            }
            else if (tabCount == 5)
            {

                if (conference.DictionaryConferenceTypeId == 0)
                {

                    this.Alert("Select a Type");
                }
                else
                {
                    tabCount++;
                    switchTabs(tabCount, sender);
                }
            }
            else if (tabCount == 6)
            {
                if (conference.DictionaryConferenceCategoryId == 0)
                {

                    this.Alert("Select a Category");
                }
                else
                {
                    tabCount++;
                    switchTabs(tabCount, sender);
                }
            }
            else if (tabCount == 7)
            {
                if (conferenceModel.SpeakerId == 0)
                {

                    this.Alert("Select a Speaker");
                }
                else
                {
                    //tabCount++;
                    //switchTabs(tabCount, sender);
                }
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            tabCount--;

            switchTabs(tabCount, sender);
        }

        private void Add_Click(object sender, EventArgs e)
        {
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var urlLocation = "http://localhost:5000/location/new";

            Location locationModel = new Location{ DictionaryCityId = location.CityId, LocationAddress = locationAddress };

            HttpClientOperations.PostOperation<Location>(urlLocation, locationModel);

            locId = await GetLocationId(location.CityId, conferenceModel.ConferenceLocation);

            var urlConference = "http://localhost:5000/api/Conference/new";

            Conference conferenceToAdd = new Conference
            { ConferenceId = conferenceModel.ConferenceId,
              ConferenceName = conferenceModel.ConferenceName, 
              StartDate = conferenceModel.ConferenceStartDate, 
              EndDate = conferenceModel.ConferenceEndDate, 
              OrganiserEmail = conferenceModel.ConferenceOrganiserEmail, 
              LocationId = locId, 
              DictionaryConferenceCategoryId = 1, 
              DictionaryConferenceTypeId = 1};

            HttpClientOperations.PostOperation(urlConference, conferenceToAdd);

            ConferenceXspeaker mainSpeakerToAdd = new ConferenceXspeaker
            { DictionarySpeakerId = conferenceModel.SpeakerId, 
              ConferenceId = conferenceModel.ConferenceId, 
              IsMain = true};

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
        public void Alert(string msg)
        {
            FormAlert frm = new FormAlert();
            frm.ShowAlert(msg);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Right))
            {
                btnNext_Click(btnNext, new System.EventArgs());
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
