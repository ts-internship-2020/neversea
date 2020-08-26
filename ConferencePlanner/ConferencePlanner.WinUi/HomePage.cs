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
        private readonly IConferenceTypeRepository _conferenceTypeRepository;
      


        public List<ConferenceModel> Conferences { get; set; }
        public string emailCopyFromMainForm;


        public HomePage()
        {
            InitializeComponent();
            
        }
        public HomePage(IConferenceRepository getConferenceRepository, String emailCopy, IConferenceTypeRepository conferenceTypeRepository)
        {
           _conferenceTypeRepository = conferenceTypeRepository;
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


            DataGridViewImageColumn buttonJoinColumn = new DataGridViewImageColumn
            {
                HeaderText = "Join",
                Name = "buttonJoinColumn",
                ToolTipText = "Join Conference",
                //Text = "Join",
                // UseColumnTextForButtonValue = true
                Image = Properties.Resources.icons8_add_user_group_man_man_20
                
            };

         

            dgvConferences.Columns.Add(buttonJoinColumn);

            DataGridViewImageColumn buttonAttendColumn = new DataGridViewImageColumn
            {
                HeaderText = "Attend",
                Name = "buttonAttendColumn",
                ToolTipText = "Attend Conference",
                Image = Properties.Resources.icons8_event_accepted_20
            };
            // buttonAttendColumn.Text = "Attend";
            //buttonAttendColumn.UseColumnTextForButtonValue = true;


            dgvConferences.Columns.Add(buttonAttendColumn);



            DataGridViewImageColumn buttonWithdrawColumn = new DataGridViewImageColumn
            {
                HeaderText = "Withdraw",
                Name = "buttonWithdrawColumn",
                ToolTipText = "Withdraw from conference",
                DividerWidth = 0,
                Image = Properties.Resources.icons8_xbox_x_20

               
            };
            //   buttonWithdrawColumn.Text = "Withdraw";
            // buttonWithdrawColumn.UseColumnTextForButtonValue = true;
          
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 addConferinceForm = new Form2(_getConferenceRepository, _conferenceTypeRepository);
            addConferinceForm.ShowDialog();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

