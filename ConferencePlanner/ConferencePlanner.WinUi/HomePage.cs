using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ado.Repository;
using Microsoft.Toolkit.Forms.UI.Controls;
using Microsoft.Toolkit.Win32.UI.Controls;
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
        public string emailCopyFromMainForm;


        public HomePage()
        {
            InitializeComponent();
            
        }
        public HomePage(IConferenceRepository getConferenceRepository, String emailCopy)
        {

            _getConferenceRepository = getConferenceRepository;
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
               // dgvConferences.DataSource = _getConferenceRepository.GetConference("spectator");
            this.dgvConferences.Columns[1].Visible = false;

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

        private void dgvConferences_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string email = "Andrei.Stancescu@totalsoft.ro";
            string confName;
            int confId;

            if (dgvConferences.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                if (dgvConferences.Columns[e.ColumnIndex].Name == "buttonJoinColumn")
                {

                    WebViewForm webViewForm = new WebViewForm();
                    webViewForm.Show();

                }

                else if (dgvConferences.Columns[e.ColumnIndex].Name == "buttonAttendColumn")
                {
                    dgvConferences.CurrentRow.Selected = true;
                    confId = Convert.ToInt32(value: dgvConferences.Rows[e.RowIndex].Cells["conferenceId"].FormattedValue.ToString());
                    //confName = dgvConferences.Rows[e.RowIndex].Cells["conferenceName"].FormattedValue.ToString();
                    _getConferenceRepository.InsertParticipant(confId, emailCopyFromMainForm);
                    //_getConferenceRepository.ModifySpectatorStatusAttend(confName, email);



                }

                else if (dgvConferences.Columns[e.ColumnIndex].Name == "buttonWithdrawColumn")
                {
                    dgvConferences.CurrentRow.Selected = true;
                    confId = Convert.ToInt32(value: dgvConferences.Rows[e.RowIndex].Cells["conferenceId"].FormattedValue.ToString());
                   // confName = dgvConferences.Rows[e.RowIndex].Cells["conferenceName"].FormattedValue.ToString();
                    _getConferenceRepository.ModifySpectatorStatusWithdraw( emailCopyFromMainForm,confId);
                }
            }
   
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 addConferinceForm = new Form2();
            addConferinceForm.ShowDialog();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvConferences_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

