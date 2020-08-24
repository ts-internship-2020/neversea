using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ado.Repository;
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


        public HomePage(IConferenceRepository getConferenceRepository)
        {

            _getConferenceRepository = getConferenceRepository;

            InitializeComponent();


            DateTime now = DateTime.Now;

            dtpStart.Value = now.AddMonths(-1);
            dtpEnd.Value = now.AddMonths(1);


        }

     
        public HomePage()
        {
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            WireUpSpectator();

            dgvOrganiser.DataSource = _getConferenceRepository.GetConference("organiser");
            dgvOrganiser.Columns[0].HeaderText = "Title";
            dgvOrganiser.Columns[1].HeaderText = "Type";
            dgvOrganiser.Columns[2].HeaderText = "Duration";
            dgvOrganiser.Columns[3].HeaderText = "Category";
            dgvOrganiser.Columns[4].HeaderText = "Address";
            dgvOrganiser.Columns[5].HeaderText = "Speaker";

//            DataGridViewButtonColumn buttonJoinColumn = new DataGridViewButtonColumn();
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


        private void dtpStart_ValueChanged(Object sender, EventArgs e)
        {
            dtpEnd.MinDate = dtpStart.Value;
            WireUpSpectator();
        }

        private void dtpEnd_ValueChanged(Object sender, EventArgs e)
        {
            WireUpSpectator();
        }



        private void dgvConferences_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvConferences.Columns[e.ColumnIndex].Name == "buttonJoinColumn")
            {

            }

            else if (dgvConferences.Columns[e.ColumnIndex].Name == "buttonAttendColumn")
            {
               
            }

            else if (dgvConferences.Columns[e.ColumnIndex].Name == "buttonWithdrawColumn")
            {

            }
        }

        private void WireUpSpectator()
        {
            dgvConferences.DataSource = _getConferenceRepository.GetConference("spectator", dtpStart.Value, dtpEnd.Value);

            this.dgvConferences.Columns[1].Visible = false;

            dgvConferences.Columns[0].HeaderText = "Title";
            dgvConferences.Columns[1].HeaderText = "Id";
            dgvConferences.Columns[2].HeaderText = "Type";
            dgvConferences.Columns[3].HeaderText = "Duration";
            dgvConferences.Columns[4].HeaderText = "Category";
            dgvConferences.Columns[5].HeaderText = "Address";
            dgvConferences.Columns[6].HeaderText = "Speaker";
        }
    }
}

