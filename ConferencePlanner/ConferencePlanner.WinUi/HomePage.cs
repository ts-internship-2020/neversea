﻿using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ado.Repository;
using Microsoft.Toolkit.Forms.UI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace ConferencePlanner.WinUi
{
    public partial class HomePage : Form

    {
        private readonly IConferenceRepository _getConferenceRepository;
        public List<ConferenceModel> Conferences { get; set; }

        public HomePage(String emailCopy)
        {
            InitializeComponent();
            string emailCopyFromMainForm;
        }
        public HomePage(IConferenceRepository getConferenceRepository)
        {

            _getConferenceRepository = getConferenceRepository;

            InitializeComponent();

            /*
             * URMEAZA SA IMPLEMENTEZ, NU STERGETI PLS
            DateTime now = DateTime.Now;
            dtpStart.Value = now.AddMonths(-1);
            dtpEnd.Value = now.AddMonths(1);
            */


        }

     


        public HomePage()
        {
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            dgvConferences.DataSource = _getConferenceRepository.GetConference("spectator", dtpStart.Value, dtpEnd.Value);
            //           dgvConferences.DataSource = _getConferenceRepository.GetConference("spectator");
            this.dgvConferences.Columns[1].Visible = false;

            dgvConferences.Columns[0].HeaderText = "Title";
            dgvConferences.Columns[1].HeaderText = "Id";
            dgvConferences.Columns[2].HeaderText = "Type";
            dgvConferences.Columns[3].HeaderText = "Duration";
            dgvConferences.Columns[4].HeaderText = "Category";
            dgvConferences.Columns[5].HeaderText = "Address";
            dgvConferences.Columns[6].HeaderText = "Speaker";

            dgvOrganiser.DataSource = _getConferenceRepository.GetConference("organiser");
            dgvOrganiser.Columns[0].HeaderText = "Title";
            dgvOrganiser.Columns[1].HeaderText = "Type";
            dgvOrganiser.Columns[2].HeaderText = "Duration";
            dgvOrganiser.Columns[3].HeaderText = "Category";
            dgvOrganiser.Columns[4].HeaderText = "Address";
            dgvOrganiser.Columns[5].HeaderText = "Speaker";


            DataGridViewButtonColumn buttonJoinColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Join",
                Name = "buttonJoinColumn",
                Text = "Join",
                UseColumnTextForButtonValue = true
            };

            dgvConferences.Columns.Add(buttonJoinColumn);

            DataGridViewButtonColumn buttonAttendColumn = new DataGridViewButtonColumn();

            buttonAttendColumn.HeaderText = "Attend";
            buttonAttendColumn.Name = "buttonAttendColumn";
            buttonAttendColumn.Text = "Attend";
            buttonAttendColumn.UseColumnTextForButtonValue = true;

            dgvConferences.Columns.Add(buttonAttendColumn);



            DataGridViewButtonColumn buttonWithdrawColumn = new DataGridViewButtonColumn();

            buttonWithdrawColumn.HeaderText = "Withdraw";
            buttonWithdrawColumn.Name = "buttonWithdrawColumn";
            buttonWithdrawColumn.Text = "Withdraw";
            buttonWithdrawColumn.UseColumnTextForButtonValue = true;

            dgvConferences.Columns.Add(buttonWithdrawColumn);

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

     

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        

        }

        private void OrganizerTab_Click(object sender, EventArgs e)
        {

        }

        private void dgvConferences_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string email = "Andrei.Stancescu@totalsoft.ro";
            string confName;

            if (dgvConferences.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                if (dgvConferences.Columns[e.ColumnIndex].Name == "buttonJoinColumn")
                {
                    WebView webView = new WebView();
                    webView.Show();
                    webView.Navigate(new Uri(@"www.google.com"));

                }

                else if (dgvConferences.Columns[e.ColumnIndex].Name == "buttonAttendColumn")
                {
                    dgvConferences.CurrentRow.Selected = true;
                    confName = dgvConferences.Rows[e.RowIndex].Cells["conferenceName"].FormattedValue.ToString();
                    _getConferenceRepository.InsertParticipant(confName, email);
                    _getConferenceRepository.ModifySpectatorStatusAttend(confName, email);


                }

                else if (dgvConferences.Columns[e.ColumnIndex].Name == "buttonWithdrawColumn")
                {
                    dgvConferences.CurrentRow.Selected = true;
                    confName = dgvConferences.Rows[e.RowIndex].Cells["conferenceName"].FormattedValue.ToString();
                    _getConferenceRepository.ModifySpectatorStatusWithdraw(confName, email);
                }
            }
        }
    }
}

