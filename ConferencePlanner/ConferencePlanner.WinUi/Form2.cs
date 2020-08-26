using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ConferencePlanner.WinUi
{
    public partial class Form2 : Form
    {
        private readonly IConferenceRepository _getConferenceRepository;
        ConferenceModel model;
        int tabIndex = 0; 
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(IConferenceRepository getConferenceRepository, ConferenceModel conference)
        {
            _getConferenceRepository = getConferenceRepository;
            model = conference;
            InitializeComponent();
        }

        public Form2(IConferenceRepository getConferenceRepository)
        {

            _getConferenceRepository = getConferenceRepository;
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {   

            //dgvCountry.DataSource = _getConferenceRepository.GetCountry("add");
            //dgvCountry.Columns[0].HeaderText = "Country Name";


        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages[tabIndex].Enabled = false;
            tabIndex -= 1;
            tabControl1.TabPages[tabIndex].Enabled = true;

            tabControl1.SelectedIndex = tabIndex;
            if(tabIndex == 0)
            {
                button1.Enabled = false;
            }
            if(button2.Text == "Save")
            {
                button2.Text = "Next";
            }
            progressBar1.Value -= 20;
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tabIndex < 5) 
            {
                tabControl1.TabPages[tabIndex].Enabled = false;
                tabIndex += 1;
                tabControl1.TabPages[tabIndex].Enabled = true;
                progressBar1.Value += 20;
            }
            tabControl1.SelectedIndex = tabIndex;
            button1.Enabled = true;

            if(tabIndex == 5)
            {
                button2.Text = "Save";
            }
        }
        //private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (tabControl1.SelectedTab.Enabled == false)
        //    {
        //        tabControl1.SelectedTab = tabPage1;
        //        MessageBox.Show("You don't have permission !!", "Meera Academy");
        //    }
        //}

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1.SelectedTab.Enabled == false)
            {
                MessageBox.Show("Please navigate using 'Next' and 'Back' buttons!");
                e.Cancel = true;
            }
        }
        private void dgvCountry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
