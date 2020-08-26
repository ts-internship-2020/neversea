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
        private readonly ICountryRepository _getCountryRepository;
        private readonly IConferenceTypeRepository _conferenceTypeRepository;

        public List<ConferenceTypeModel> conferenceTypeModels { get; set; }
        List<TabPage> tabPanel = new List<TabPage>();
        int tabIndex = 0; 

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(ICountryRepository getCountryRepository)
        {

            _getCountryRepository = getCountryRepository;
            InitializeComponent();
            LoadCountries();
        }

        public Form2(IConferenceRepository getConferenceRepository)
        public Form2(IConferenceRepository getConferenceRepository, IConferenceTypeRepository conferenceTypeRepository)
        {

            _getConferenceRepository = getConferenceRepository;
            _conferenceTypeRepository = conferenceTypeRepository;
            InitializeComponent();
            LoadCountries();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {   

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
                lblBackCountry.Enabled = false;
            }
            if(lblNextCountry.Text == "Save")
            {
                lblNextCountry.Text = "Next";
            }
            progressBar1.Value -= 20;
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
            lblBackCountry.Enabled = true;

            if(tabIndex == 5)
            {
                lblNextCountry.Text = "Save";
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

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            dgvConferenceType.DataSource = _conferenceTypeRepository.getConferenceTypes();
            dgvConferenceType.Columns[0].HeaderText = "Conference Type Id";
            dgvConferenceType.Columns[1].HeaderText = "Conference Type Name";
            


        }

        private void dgvConferenceType_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           int counter = 1;
           // dgvConferenceType.Sort(dgvConferenceType.Columns[0], ListSortDirection.Ascending);
           // counter++;
            if (counter != 1)
            {
                if (counter % 2 == 0)
                {
                           dgvConferenceType.Sort(dgvConferenceType.Columns[0], ListSortDirection.Descending);

                }
                else
                { 
                    dgvConferenceType.Sort(dgvConferenceType.Columns[0], ListSortDirection.Ascending);

                }


            }

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblAddNewCountry_Click(object sender, EventArgs e)
        {

        }

        private void LoadCountries()
        {
            dgvCountries.DataSource = _getCountryRepository.GetCountry();
        }
    }
}
