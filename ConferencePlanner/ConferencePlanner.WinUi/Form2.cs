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
        private readonly IConferenceCategoryRepository _getConferenceCategoryRepository;
        private readonly ICountryRepository _getCountryRepository;
        private BindingSource bsCountries = new BindingSource();
        private BindingSource bsCategories = new BindingSource();
        private readonly IConferenceTypeRepository _conferenceTypeRepository;
        private readonly IDistrictRepository _districtRepository;
        private BindingSource bsDistricts = new BindingSource();

        public List<ConferenceTypeModel> conferenceTypeModels { get; set; }
        public List<ConferenceCategoryModel> conferenceCategoriesModels { get; set; }

        List<TabPage> tabPanel = new List<TabPage>();
        ConferenceModel model;
        int tabIndex = 0; 

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(ICountryRepository getCountryRepository)
        {

            _getCountryRepository = getCountryRepository;
            InitializeComponent();
            LoadConferenceCategories();
            LoadCountries();
            LoadDistricts();
        }

        public Form2(IConferenceRepository getConferenceRepository, ConferenceModel conference)
        {
            _getConferenceRepository = getConferenceRepository;
            model = conference;
           
            InitializeComponent(); 
            LoadConferenceCategories();
            LoadCountries();
            LoadDistricts();
        }

     //   public Form2(IConferenceRepository getConferenceRepository) { }
        public Form2(IConferenceRepository getConferenceRepository, IConferenceTypeRepository conferenceTypeRepository, ICountryRepository getCountryRepository, IConferenceCategoryRepository conferenceCategoryRepository,IDistrictRepository districtRepository)
        {
            _getCountryRepository = getCountryRepository;
            _getConferenceRepository = getConferenceRepository;
            _conferenceTypeRepository = conferenceTypeRepository;
            _getConferenceCategoryRepository = conferenceCategoryRepository;
            _districtRepository = districtRepository;
            InitializeComponent();
            LoadConferenceCategories();
            LoadCountries();
            LoadDistricts();
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
            if (tabIndex < tabControl1.TabCount - 1) 
            {
                tabControl1.TabPages[tabIndex].Enabled = false;
                tabIndex += 1;
                tabControl1.TabPages[tabIndex].Enabled = true;
                progressBar1.Value += 20;
            }
            tabControl1.SelectedIndex = tabIndex;
            lblBackCountry.Enabled = true;

            if(tabIndex == tabControl1.TabCount)
            {
                lblNextCountry.Text = "Save";
            }
        }

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

          //  var myBindingSource = new SortedBindingList<ConferenceTypeModel>(conferenceTypeModels);
           // myBindingSource.ApplySort(propertyName, ListSortDirection.Ascending);
          //  var bindingSource = new BindingSource();
            conferenceTypeModels = _conferenceTypeRepository.getConferenceTypes();
         //   dgvConferenceType.DataSource = _conferenceTypeRepository.getConferenceTypes();
            dgvConferenceType.DataSource = conferenceTypeModels;
           // dgvConferenceType.DataSource = _conferenceTypeRepository.getConferenceTypes();
            dgvConferenceType.Columns[0].HeaderText = "Conference Type Name";
            dgvConferenceType.Columns[1].HeaderText = "Conference Type Id";
            




        }

        private void dgvConferenceType_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
           int counter = 1;

            //dgvConferenceType.Sort(dgvConferenceType.Columns[0], ListSortDirection.Descending);


            if (counter == 1)
            {
               
                dgvConferenceType.DataSource = null; 
                conferenceTypeModels.Sort();
                dgvConferenceType.DataSource = conferenceTypeModels;
                dgvConferenceType.Refresh();
                counter++;
            }
            else
            {
                dgvConferenceType.DataSource = null;
                conferenceTypeModels.Reverse();
                dgvConferenceType.DataSource = conferenceTypeModels;
                dgvConferenceType.Refresh();


            }


        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblAddNewCountry_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchCountry_KeyPress(object sender, KeyPressEventArgs e)
        {
            string keyword = txtSearchCountry.Text;


            if (e.KeyChar == (char)Keys.Back)
            {
                this.txtSearchCountry.Text = keyword.Remove(keyword.Length - 1);
            }
        }

        private void LoadConferenceCategories()
        {
            List<ConferenceCategoryModel> conferenceCategories = new List<ConferenceCategoryModel>();
            conferenceCategories = _getConferenceCategoryRepository.GetConferenceCategories();
            bsCategories.AllowNew = true;
            bsCategories.DataSource = null;
            bsCategories.DataSource = conferenceCategories;

            //dgvConferenceCategory.DataSource = bsCategories;

            
            //dgvConferenceCategory.Columns[0].HeaderText = "Name";
           // dgvConferenceCategory.Columns[1].HeaderText = "Id";


        }

        private void LoadCountries()
        {
            List<CountryModel> countries = new List<CountryModel>();
            countries = _getCountryRepository.GetCountry();

            bsCountries.AllowNew = true;
            bsCountries.DataSource = null;
            bsCountries.DataSource = countries; 

            dgvCountries.DataSource = bsCountries;

            this.dgvCountries.Columns[1].Visible = false;


            dgvCountries.Columns[0].HeaderText = "Name";
            dgvCountries.Columns[1].HeaderText = "Id";
            dgvCountries.Columns[2].HeaderText = "Code";
            dgvCountries.Columns[3].HeaderText = "Nationality";
        }

        private void txtSearchCountry_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearchCountry.Text;
            LoadCountries(keyword);
        }
        

        private void LoadCountries(string keyword)
        {
            List<CountryModel> countries = new List<CountryModel>();
            countries = _getCountryRepository.GetCountry(keyword);

            bsCountries.AllowNew = true;
            bsCountries.DataSource = null;
            bsCountries.DataSource = countries;

            dgvCountries.DataSource = bsCountries;

            this.dgvCountries.Columns[1].Visible = false;


            dgvCountries.Columns[0].HeaderText = "Name";
            dgvCountries.Columns[1].HeaderText = "Id";
            dgvCountries.Columns[2].HeaderText = "Code";
            dgvCountries.Columns[3].HeaderText = "Nationality";
        }

        private void LoadDistricts()
        {
            List<DistrictModel> districts = new List<DistrictModel>();
            districts = _districtRepository.GetDistricts();
            bsDistricts.AllowNew = true;
            bsDistricts.DataSource = null;
            bsDistricts.DataSource = districts;
            dgvDistrict.DataSource = bsDistricts;

            this.dgvDistrict.Columns[3].Visible = false;
            this.dgvDistrict.Columns[0].Visible = false;


            dgvDistrict.Columns[0].HeaderText = "Id";
            dgvDistrict.Columns[1].HeaderText = "District Name";
            dgvDistrict.Columns[2].HeaderText = "Code";
            dgvDistrict.Columns[3].HeaderText = "CountryId";

        }
        private void LoadDistricts(string keyword)
        {
            List<DistrictModel> districts = new List<DistrictModel>();
            districts = _districtRepository.GetDistricts(keyword);

            bsDistricts.AllowNew = true;
            bsDistricts.DataSource = null;
            bsDistricts.DataSource = districts;

            dgvDistrict.DataSource = bsDistricts;

            this.dgvDistrict.Columns[3].Visible = false;
            this.dgvDistrict.Columns[0].Visible = false;


            dgvDistrict.Columns[0].HeaderText = "Id";
            dgvDistrict.Columns[1].HeaderText = "District Name";
            dgvDistrict.Columns[2].HeaderText = "Code";
            dgvDistrict.Columns[3].HeaderText = "CountryId";
        }
        private void txtB_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtBoxFitru.Text;
            LoadDistricts(keyword);
        }
    }
}
