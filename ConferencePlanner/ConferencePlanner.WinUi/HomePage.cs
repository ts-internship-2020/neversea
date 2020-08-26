﻿using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ado.Repository;
using Microsoft.Toolkit.Forms.UI.Controls;
using Microsoft.Toolkit.Win32.UI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ConferencePlanner.WinUi
{
    public partial class HomePage : Form

    {
        private readonly IConferenceRepository _getConferenceRepository;
        private readonly ICountryRepository _countryRepository;

        public List<ConferenceModel> Conferences { get; set; }
        public string emailCopyFromMainForm;
        int pageSize = 20;
        int pageNumber = 1;


        public int range = 0;
        public int step = 4;
        public int shown = 4;
        public int maxrange;
        public HomePage()
        {
            InitializeComponent();
        }
        public HomePage(IConferenceRepository getConferenceRepository, String emailCopy, ICountryRepository countryRepository)
        {
            _getConferenceRepository = getConferenceRepository;
            _countryRepository = countryRepository;
            emailCopyFromMainForm = emailCopy;
            InitializeComponent();

            DateTime now = DateTime.Now;

            dtpStart.Value = now.AddMonths(-1);
            dtpEnd.Value = now.AddMonths(1);
        }

        private void MainPage_Load(object sender, EventArgs e)
        {   
            WireUpSpectator();
            dgvConferences.DataSource = _getConferenceRepository.GetConference("spectator", dtpStart.Value, dtpEnd.Value);
            comboBox1.SelectedItem = 4;
            DateTime initialStart = DateTime.Parse("01.01.1900 00:00:00");
            DateTime initialEnd = DateTime.Parse("01.01.2100 00:00:00");
            Conferences = _getConferenceRepository.GetConferenceBetweenDates(emailCopyFromMainForm, initialStart, initialEnd);
            maxrange = Conferences.Count;
            button2.Enabled = false;
            dgvOrganiser.ColumnCount = 8;
            dgvOrganiser.Columns[0].Name = "Id";
            dgvOrganiser.Columns[1].Name = "Title";
            dgvOrganiser.Columns[2].Name = "StartDate";
            dgvOrganiser.Columns[3].Name = "EndDate";
            dgvOrganiser.Columns[4].Name = "Type";
            dgvOrganiser.Columns[5].Name = "Category";
            dgvOrganiser.Columns[6].Name = "Address";
            dgvOrganiser.Columns[7].Name = "Speaker";
            this.dgvOrganiser.Columns[0].Visible = false;
            WireUpOrganiser();

            DataGridViewButtonColumn buttonEditColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Edit",
                Name = "buttonEditColumn",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            };
            dgvOrganiser.Columns.Add(buttonEditColumn);

            DataGridViewImageColumn buttonJoinColumn = new DataGridViewImageColumn
            {
                HeaderText = "Join",
                Name = "buttonJoinColumn",
                //Text = "Join",
                // UseColumnTextForButtonValue = true
                Image = Properties.Resources.icons8_add_user_group_man_man_20
            };

            //DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            //{
            //    HeaderText = "Hey",
            //    Name = "Imag",
            //    Image = Properties.Resources.icons8_cancel_32px

            //};

         //   dgvConferences.Columns.Add(imageColumn);

            dgvConferences.Columns.Add(buttonJoinColumn);

            DataGridViewImageColumn buttonAttendColumn = new DataGridViewImageColumn
            {
                HeaderText = "Attend",
                Name = "buttonAttendColumn",
                Image = Properties.Resources.icons8_event_accepted_20
            };
            // buttonAttendColumn.Text = "Attend";
            //buttonAttendColumn.UseColumnTextForButtonValue = true;


            dgvConferences.Columns.Add(buttonAttendColumn);



            DataGridViewImageColumn buttonWithdrawColumn = new DataGridViewImageColumn
            {
                HeaderText = "Withdraw",
                Name = "buttonWithdrawColumn",
                Image = Properties.Resources.icons8_xbox_x_20
            };
            //   buttonWithdrawColumn.Text = "Withdraw";
            // buttonWithdrawColumn.UseColumnTextForButtonValue = true;
          
            dgvConferences.Columns.Add(buttonWithdrawColumn);
        }
        
        private void WireUpOrganiser()
        {
            for (int i = range; i<step; i++)
            {   
                if (i >= maxrange)
                {
                    Console.WriteLine("breaked");
                    break;
                }
                else
                {
                        dgvOrganiser.Rows.Add(Conferences[i].conferenceId,
                                    Conferences[i].conferenceName,
                                    Conferences[i].conferenceStartDate,
                                    Conferences[i].conferenceEndDate,
                                    Conferences[i].conferenceType,
                                    Conferences[i].conferenceCategory,
                                    Conferences[i].conferenceAddress,
                                    Conferences[i].conferenceMainSpeaker);
                }

                if (Conferences.Count <= (int)comboBox1.SelectedItem)
                {
                    button3.Enabled = false;
                }
                else if (step < maxrange)
                {
                    button3.Enabled = true;
                }
            }
        }
        private void dtpStart_ValueChanged(Object sender, EventArgs e)
        {
            dtpEnd.MinDate = dtpStart.Value;
            WireUpSpectator();
        }

        private void dtpEnd_ValueChanged(Object sender, EventArgs e)
        {
            WireUpSpectator();
        }

      

        private void WireUpSpectator()
        {
            List<ConferenceModel> conferences = new List<ConferenceModel>();
            conferences = _getConferenceRepository.GetConference(emailCopyFromMainForm, dtpStart.Value, dtpEnd.Value);

            int pageCount = (int)Math.Ceiling((double)(conferences.Count / pageSize + 1));

            if (pageNumber >= 1 && pageNumber <= pageCount)
            {
                IEnumerable<ConferenceModel> conferencesDisplayed = conferences.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                dgvConferences.DataSource = conferencesDisplayed;
            }


            this.dgvConferences.Columns[1].Visible = false;

            dgvConferences.Columns[0].HeaderText = "Title";
            dgvConferences.Columns[1].HeaderText = "Id";
            dgvConferences.Columns[2].HeaderText = "Starts";
            dgvConferences.Columns[3].HeaderText = "Ends";
            dgvConferences.Columns[4].HeaderText = "Category";
            dgvConferences.Columns[5].HeaderText = "Location";
            dgvConferences.Columns[6].HeaderText = "Speaker";
        }

        private void dgvConferences_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string confName;
            int confId;

            if (dgvConferences.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                if (dgvConferences.Columns[e.ColumnIndex].Name == "conferenceMainSpeaker")
                {
                    string speakerName =  dgvConferences.Rows[e.RowIndex].Cells["conferenceMainSpeaker"].FormattedValue.ToString();
                    int speakerId = _getConferenceRepository.getSpeakerId(speakerName);
                    FormSpeakerDetails formSpeakerDetail = new FormSpeakerDetails(_getConferenceRepository, speakerId);
                    formSpeakerDetail.Show();
                }
                    if (dgvConferences.Columns[e.ColumnIndex].Name == "buttonJoinColumn")
                {

                    WebViewForm webViewForm = new WebViewForm();
                    webViewForm.Show();

                }

                else if (dgvConferences.Columns[e.ColumnIndex].Name == "buttonAttendColumn")
                {
                    dgvConferences.CurrentRow.Selected = true;
                    confId = Convert.ToInt32(value: dgvConferences.Rows[e.RowIndex].Cells["conferenceId"].FormattedValue.ToString());
                    _getConferenceRepository.InsertParticipant(confId, emailCopyFromMainForm);
                    //_getConferenceRepository.ModifySpectatorStatusAttend(confName, email);


                }

                else if (dgvConferences.Columns[e.ColumnIndex].Name == "buttonWithdrawColumn")
                {
                    dgvConferences.CurrentRow.Selected = true;
                    confId = Convert.ToInt32(value: dgvConferences.Rows[e.RowIndex].Cells["conferenceId"].FormattedValue.ToString());
                    _getConferenceRepository.ModifySpectatorStatusWithdraw( emailCopyFromMainForm,confId);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddConference();
        }

        private void dgvOrganiser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrganiser.Columns[e.ColumnIndex].Name == "buttonEditColumn")
            {
                ConferenceModel conf = new ConferenceModel();
                int confId;
                string confName;
                
                dgvOrganiser.CurrentRow.Selected = true;
                confId = Convert.ToInt32(value: dgvOrganiser.Rows[e.RowIndex].Cells["conferenceId"].FormattedValue.ToString());
                confName = dgvOrganiser.Rows[e.RowIndex].Cells["conferenceName"].FormattedValue.ToString();
                //confStartDate = dgvOrganiser.Rows[e.RowIndex].Cells["StartDate"].FormattedValue.ToDate();
                //confEndDate = dgvOrganiser.Rows[e.RowIndex].Cells["EndDate"].FormattedValue.ToDate();
                Console.WriteLine(confId);
                Form2 editConferenceForm = new Form2(_getConferenceRepository, conf);
                editConferenceForm.ShowDialog();
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine(dateTimePicker1.Value);
            dgvOrganiser.Rows.Clear();
            Conferences.Clear();
            Conferences = _getConferenceRepository.GetConferenceBetweenDates(emailCopyFromMainForm, dateTimePicker1.Value, dateTimePicker2.Value);
            maxrange = Conferences.Count;
            range = 0;
            shown = 4;
            step = 4;
            WireUpOrganiser();
        }

        private void AddConference()
        {
            Form2 addConferenceForm = new Form2(_countryRepository);
            addConferenceForm.ShowDialog();
        }

        private void MainPageTab_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dgvOrganiser.Rows.Clear();
            range = 0;
            shown = 4;
            step = 4;
            Conferences.Clear();
            Conferences = _getConferenceRepository.GetConferenceBetweenDates(emailCopyFromMainForm, dateTimePicker1.Value, dateTimePicker2.Value);
            maxrange = Conferences.Count;
            WireUpOrganiser();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dgvOrganiser.Rows.Clear();
            range = step;
            step += shown;
            button2.Enabled = true;
            if (step >= maxrange)
            {
                button3.Enabled = false;
            }
            Console.WriteLine("Am dat Next: range=" + range + " si step=" + step);
            WireUpOrganiser();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvOrganiser.Rows.Clear();
            step = range;
            range -= shown;
            button3.Enabled = true;
            if (range == 0)
            {
                button2.Enabled = false;
            }
            Console.WriteLine("Am dat Back: range=" + range + " si step=" + step);
            WireUpOrganiser();
        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvOrganiser.Rows.Clear();
            range = 0;
            step = (int)comboBox1.SelectedItem;
            shown = (int)comboBox1.SelectedItem;
            button2.Enabled = false;
            WireUpOrganiser();

        }

        private void pageSizeLabel_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pageNumber++;

            btnBack.Enabled = true;

            WireUpSpectator();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pageNumber--;

            if (pageNumber < 0)
            {
                pageNumber = 0;
                btnBack.Enabled = false;
            }

            WireUpSpectator();
            
        }
    }
}

