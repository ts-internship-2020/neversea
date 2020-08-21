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

        }

     


        public HomePage()
        {
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            //  var conferences = this.Conferences;
            dgvConferences.DataSource = _getConferenceRepository.GetConference("spectator");
            dgvConferences.Columns[0].HeaderText = "Title";
            dgvConferences.Columns[1].HeaderText = "Starts";
            dgvConferences.Columns[2].HeaderText = "Ends";
            dgvConferences.Columns[3].HeaderText = "Duration";
            dgvConferences.Columns[4].HeaderText = "Type";
            dgvConferences.Columns[5].HeaderText = "Category";
            dgvConferences.Columns[6].HeaderText = "Address";
            dgvConferences.Columns[7].HeaderText = "Speaker";

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
    }
}

