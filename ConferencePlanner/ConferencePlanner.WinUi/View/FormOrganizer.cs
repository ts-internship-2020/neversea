﻿using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.WinUi.Utilities;
using MimeKit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Windows.Web.Http;

namespace ConferencePlanner.WinUi.View
{
    public partial class FormOrganizer : Form
    {
        private readonly IConferenceRepository _conferenceRepository;

        public List<ConferenceModel> Conferences { get; set; }
        public string emailCopyFromMainForm;
        public int range = 0;
        public int step = 4;
        public int shown = 4;
        public int maxrange;

        public FormOrganizer(IConferenceRepository conferenceRepository, string emailCopy)
        {
            _conferenceRepository = conferenceRepository;
            emailCopyFromMainForm = emailCopy;
            InitializeComponent();

            /*DateTime now = DateTime.Now;
            dtpStart.Value = now.AddMonths(-1);
            dtpEnd.Value = now.AddMonths(1);*/

            DateTime initialStart = DateTime.Parse("01.01.1900 00:00:00");
            DateTime initialEnd = DateTime.Parse("01.01.2100 00:00:00");

            //WireUpOrganiser();

            DataGridViewButtonColumn buttonEditColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Edit",
                Name = "buttonEditColumn",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            };
            dgvOrganiser.Columns.Add(buttonEditColumn);
        }

        private async Task LoadConferences(DateTime _startDate, DateTime _endDate)
        {

            //List<ConferenceModel> conferences = new List<ConferenceModel>();
            List<ConferenceAttendanceModel> conferenceAttendances = new List<ConferenceAttendanceModel>();

            var url = $"http://localhost:2794/api/Conference/organized/all/{emailCopyFromMainForm}?startDate={_startDate}&endDate={_endDate}";

            Conferences = await HttpClientOperations.GetOperation<ConferenceModel>(url);

            //Conferences = _conferenceRepository.GetConferenceBetweenDates(emailCopyFromMainForm, initialStart, initialEnd);

            comboBoxPagesNumber.SelectedIndex = 0;
            //Conferences = _conferenceRepository.GetConferenceBetweenDates(emailCopyFromMainForm, initialStart, initialEnd);

            maxrange = Conferences.Count;
            btnPrevious.Visible = false;
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
        }

        /*private void LoadConferences()
        {
            Conferences = _conferenceRepository.GetConferenceBetweenDates(emailCopyFromMainForm, initialStart, initialEnd);

            comboBoxPagesNumber.SelectedIndex = 0;
            Conferences = _conferenceRepository.GetConferenceBetweenDates(emailCopyFromMainForm, initialStart, initialEnd);

            maxrange = Conferences.Count;
            btnPrevious.Visible = false;
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
        }*/

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadTheme();
        }

        private async Task FormSpectator_Load(object sender, EventArgs e)
        {
            DateTime initialStart = DateTime.Parse("01.01.1900 00:00:00");
            DateTime initialEnd = DateTime.Parse("01.01.2100 00:00:00");
            //Conferences = _conferenceRepository.GetConferenceBetweenDates(emailCopyFromMainForm, initialStart, initialEnd);
            await LoadConferences(initialStart, initialEnd);

            comboBoxPagesNumber.SelectedIndex = 0;
            //Conferences = _conferenceRepository.GetConferenceBetweenDates(emailCopyFromMainForm, initialStart, initialEnd);

            maxrange = Conferences.Count;
            btnPrevious.Visible = false;
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
        }

        private void WireUpOrganiser()
        {

            for (int i = range; i < step; i++)
            {
                if (i >= maxrange)
                {
                    Console.WriteLine("breaked");
                    break;
                }
                else
                {
                    dgvOrganiser.Rows.Add(Conferences[i].ConferenceId,
                                Conferences[i].ConferenceName,
                                Conferences[i].ConferenceStartDate,
                                Conferences[i].ConferenceEndDate,
                                Conferences[i].ConferenceType,
                                Conferences[i].ConferenceCategory,
                                Conferences[i].ConferenceLocation,
                                Conferences[i].ConferenceMainSpeaker);
                }

                if (Conferences.Count <= (int)comboBoxPagesNumber.SelectedItem)
                {
                    btnNext.Enabled = false;
                }
                else if (step < maxrange)
                {
                    btnNext.Enabled = true;
                }
            }
    }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    /*btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;*/
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }


        private async Task dtpStart_ValueChanged_1(object sender, EventArgs e)
        {
            Console.WriteLine(dtpStart.Value);
            dgvOrganiser.Rows.Clear();
            Conferences.Clear();
            await LoadConferences(dtpStart.Value, dtpEnd.Value);
            //Conferences = _conferenceRepository.GetConferenceBetweenDates(emailCopyFromMainForm, dtpStart.Value, dtpEnd.Value);
            Console.WriteLine(Conferences.Count);
            maxrange = Conferences.Count;
            range = 0;
            btnPrevious.Visible = false;
            step = (int)comboBoxPagesNumber.SelectedItem;
            shown = (int)comboBoxPagesNumber.SelectedItem;
            btnPrevious.Visible = false;
            WireUpOrganiser();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            dgvOrganiser.Rows.Clear();
            range = step;
            step += shown;
            btnPrevious.Visible = true;
            if (step >= maxrange)
            {
                btnNext.Enabled = false;
            }
            Console.WriteLine("Am dat Next: range=" + range + " si step=" + step);
            WireUpOrganiser();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            dgvOrganiser.Rows.Clear();
            step = range;
            range -= shown;
            btnPrevious.Visible = true;
            if (range == 0)
            {
                btnPrevious.Visible = false;
            }
            Console.WriteLine("Am dat Back: range=" + range + " si step=" + step);
            WireUpOrganiser();
        }

        private void comboBoxPagesNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvOrganiser.Rows.Clear();
            range = 0;
            step = (int)comboBoxPagesNumber.SelectedItem;
            shown = (int)comboBoxPagesNumber.SelectedItem;
            btnPrevious.Visible = false;
            WireUpOrganiser();
        }

        private void dgvOrganiser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrganiser.Columns[e.ColumnIndex].Name == "buttonEditColumn")
            {
                ConferenceModel conf = new ConferenceModel();
                int confId;
                string confName;

                dgvOrganiser.CurrentRow.Selected = true;
                confId = Convert.ToInt32(value: dgvOrganiser.Rows[e.RowIndex].Cells["ConferenceId"].FormattedValue.ToString());
                confName = dgvOrganiser.Rows[e.RowIndex].Cells["ConferenceName"].FormattedValue.ToString();
                Console.WriteLine(confId);
                Form2 editConferenceForm = new Form2(_conferenceRepository, conf);
                editConferenceForm.ShowDialog();
            }

        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            dgvOrganiser.Rows.Clear();
            range = step;
            step += shown;
            btnPrevious.Visible = true;
            if (step >= maxrange)
            {
                btnNext.Enabled = false;
            }
            Console.WriteLine("Am dat Next: range=" + range + " si step=" + step);
            WireUpOrganiser();
        }

        private void btnPrevious_Click_1(object sender, EventArgs e)
        {
            dgvOrganiser.Rows.Clear();
            step = range;
            range -= shown;
            btnPrevious.Visible = true;
            if (range == 0)
            {
                btnPrevious.Visible = false;
            }
            Console.WriteLine("Am dat Back: range=" + range + " si step=" + step);
            WireUpOrganiser();
        }

        private void comboBoxPagesNumber_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            dgvOrganiser.Rows.Clear();
            range = 0;
            step = (int)comboBoxPagesNumber.SelectedItem;
            shown = (int)comboBoxPagesNumber.SelectedItem;
            //btnNext.Enabled = false;
            btnPrevious.Visible = false;
            WireUpOrganiser();
        }

        private void dtpEnd_ValueChanged_1(object sender, EventArgs e)
        {
            dgvOrganiser.Rows.Clear();
            Conferences.Clear();
            Conferences = _conferenceRepository.GetConferenceBetweenDates(emailCopyFromMainForm, dtpStart.Value, dtpEnd.Value);
            Console.WriteLine(Conferences.Count);
            maxrange = Conferences.Count;
            range = 0;
            btnPrevious.Visible = false;
            step = (int)comboBoxPagesNumber.SelectedItem;
            shown = (int)comboBoxPagesNumber.SelectedItem;
            btnNext.Enabled = false;
            WireUpOrganiser();
        }
        private void dgvOrganiser_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvOrganiser.ClearSelection();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("test");
        }
    }
}

