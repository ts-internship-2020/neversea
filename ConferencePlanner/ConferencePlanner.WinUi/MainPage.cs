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
    public partial class MainPage : Form

    {
        private readonly IGetConferenceRepository _getConferenceRepository;
        public List<ConferenceModel> Conferences { get; set; }
    
        public GetConferenceRepository GetConferenceRepository { get; set; }

        public MainPage(IGetConferenceRepository getConferenceRepository, GetConferenceRepository gcf, List<ConferenceModel> listuta)
        {
            GetConferenceRepository = gcf;
            Conferences = listuta;
            _getConferenceRepository = getConferenceRepository;

            InitializeComponent();

        }


        private void MainPage_Load(object sender, EventArgs e)
        {
            //  var conferences = this.Conferences;
            dgvConferences.DataSource = GetConferenceRepository.GetConference("");
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void update()
        {
            DataGridViewButtonColumn buttonJoinColumn = new DataGridViewButtonColumn();

            buttonJoinColumn.HeaderText = "Join";
            buttonJoinColumn.Name = "buttonJoinColumn";
            buttonJoinColumn.UseColumnTextForButtonValue = true;

            dgvOrganizerEvents.Columns.Add(buttonJoinColumn);



            DataGridViewButtonColumn buttonAttendColumn = new DataGridViewButtonColumn();

            buttonJoinColumn.HeaderText = "Attend";
            buttonJoinColumn.Name = "buttonAttendColumn";
            buttonJoinColumn.UseColumnTextForButtonValue = true;

            dgvOrganizerEvents.Columns.Add(buttonAttendColumn);



            DataGridViewButtonColumn buttonWithdrawColumn = new DataGridViewButtonColumn();

            buttonJoinColumn.HeaderText = "Withdraw";
            buttonJoinColumn.Name = "buttonWithdrawColumn";
            buttonJoinColumn.UseColumnTextForButtonValue = true;

            dgvOrganizerEvents.Columns.Add(buttonWithdrawColumn);





        }






        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrganizerEvents.Columns[e.ColumnIndex].Name == "buttonJoinColumn")
            {
                
            }

            else if(dgvOrganizerEvents.Columns[e.ColumnIndex].Name == "buttonAttendColumn")
            {

            }

            else if (dgvOrganizerEvents.Columns[e.ColumnIndex].Name == "buttonWithdrawColumn")
            {

            }

        }

        private void OrganizerTab_Click(object sender, EventArgs e)
        {

        }
    }
}
