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
        public MainPage()
        {
            InitializeComponent();
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
