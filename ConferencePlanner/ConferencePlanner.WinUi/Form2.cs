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
        private readonly IConferenceCityRepository _getConferenceCityRepository;
        private readonly ICountryRepository _getCountryRepository;
        private BindingSource bsCountries = new BindingSource();
        private BindingSource bsCategories = new BindingSource();
        private BindingSource bsTypes = new BindingSource();

        private readonly IConferenceTypeRepository _conferenceTypeRepository;
        private readonly IDistrictRepository _districtRepository;
        private BindingSource bsDistricts = new BindingSource();
        private readonly IConferenceAttendanceRepository _conferenceAttendanceRepository;



        public List<ConferenceTypeModel> conferenceTypeModels { get; set; }
        public List<ConferenceCategoryModel> conferenceCategoriesModels { get; set; }

        List<TabPage> tabPanel = new List<TabPage>();
        ConferenceModel model;
        int tabIndex = 0;
        public string emailCopyFromMainForm;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(ICountryRepository getCountryRepository)
        {

            _getCountryRepository = getCountryRepository;

            InitializeComponent();
            LoadConferenceCategories();
            LoadConferenceTypes();
            LoadCountries();
            LoadDistricts();
        }

        public Form2(IConferenceRepository getConferenceRepository, ConferenceModel conference)
        {
            _getConferenceRepository = getConferenceRepository;
            model = conference;

            InitializeComponent();
            LoadConferenceCategories();
            LoadConferenceTypes();
            LoadCountries();
            LoadDistricts();
        }

        //   public Form2(IConferenceRepository getConferenceRepository) { }
        public Form2(string email, IConferenceRepository getConferenceRepository, IConferenceTypeRepository conferenceTypeRepository, ICountryRepository getCountryRepository, IConferenceCategoryRepository conferenceCategoryRepository, IDistrictRepository districtRepository, IConferenceCityRepository conferenceCityRepository, IConferenceAttendanceRepository conferenceAttendanceRepository, IConferenceSpeakerRepository conferenceSpeakerRepository)
        {
            _getCountryRepository = getCountryRepository;
            _getConferenceRepository = getConferenceRepository;
            _conferenceTypeRepository = conferenceTypeRepository;
            _getConferenceCategoryRepository = conferenceCategoryRepository;
            _conferenceAttendanceRepository = conferenceAttendanceRepository;
            _getConferenceCityRepository = conferenceCityRepository;
            emailCopyFromMainForm = email;
            _districtRepository = districtRepository;
            InitializeComponent();
            LoadConferenceCategories();
            LoadConferenceTypes();
            LoadCountries();
            LoadDistricts();
            LoadCities();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void LoadCities()
        {
            List<ConferenceCityModel> cities = new List<ConferenceCityModel>();
            cities = _getConferenceCityRepository.GetConferenceCities(1);
            dgvCity.ColumnCount = 2;
            dgvCity.Columns[0].Name = "Id";
            dgvCity.Columns[1].Name = "City";
            this.dgvCity.Columns[0].Visible = false;
            for (int i = 0; i < cities.Count; i++)
            {
                //if (i >= maxrange)
                //{
                //    Console.WriteLine("breaked");
                //    break;
                //}
                //else
                //{
                dgvCity.Rows.Add(cities[i].ConferenceCityId,
                            cities[i].ConferenceCityName);
                //}

            }
            Console.WriteLine(dgvCity.ColumnCount);
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
            if (tabIndex == 0)
            {
                lblBackCountry.Enabled = false;
            }
            if (lblNextCountry.Text == "Save")
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

            if (tabIndex == tabControl1.TabCount)
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







        }

        private void dgvCountries_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int countryId;
            string countryName = "";
            string countryCode = "";
            string nationality = "";

            /*if (dgvCountries.Columns[e.ColumnIndex].Name == "dgvCountries")
            {*/
            try
            {
                if ((int)dgvCountries.Rows[e.RowIndex].Cells[1].Value != 0)
                {
                    countryId = Convert.ToInt32(dgvCountries.Rows[e.RowIndex].Cells[1].Value.ToString());
                    countryName = dgvCountries.Rows[e.RowIndex].Cells[0].Value.ToString();
                    countryCode = dgvCountries.Rows[e.RowIndex].Cells[2].Value.ToString();
                    nationality = dgvCountries.Rows[e.RowIndex].Cells[3].Value.ToString();
                    _getCountryRepository.UpdateCountry(countryId, countryName, countryCode, nationality);
                }

                else
                {
                    countryName = dgvCountries.Rows[e.RowIndex].Cells[0].Value.ToString();
                    countryCode = dgvCountries.Rows[e.RowIndex].Cells[2].Value == null ? "" : dgvCountries.Rows[e.RowIndex].Cells[2].Value.ToString();
                    nationality = dgvCountries.Rows[e.RowIndex].Cells[3].Value == null ? "" : dgvCountries.Rows[e.RowIndex].Cells[3].Value.ToString();

                    _getCountryRepository.InsertCountry(countryName, countryCode, nationality);
                    dgvCountries.Rows.Clear();
                    LoadCountries();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //}

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
        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "City")
            {
                Console.WriteLine("Am intrat in tabul city");
                if (emailCopyFromMainForm != "paul.popescu@gmail.com")
                {
                    button2.Visible = false;
                }
            }
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
        private void dgvCity_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCity.Columns[e.ColumnIndex].Name == "City")
            {
                try
                {
                    if (dgvCity.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value != null)
                    {
                        int indexCity = Convert.ToInt32(dgvCity.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString());
                        string nameCity = dgvCity.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        _getConferenceCityRepository.updateCity(indexCity, nameCity, 1);
                    }
                    else
                    {
                        string nameCity = dgvCity.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        _getConferenceCityRepository.insertCity(nameCity, 1);
                        dgvCity.Rows.Clear();
                        LoadCities();
                    }
                }
                catch
                {

                }
            }
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

        private void LoadConferenceCategories(string keyword)
        {
            List<ConferenceCategoryModel> conferenceCategories = new List<ConferenceCategoryModel>();
            conferenceCategories = _getConferenceCategoryRepository.GetConferenceCategories(keyword);
            bsCategories.AllowNew = true;
            bsCategories.DataSource = null;
            bsCategories.DataSource = conferenceCategories;

            dgvConferenceCategory.DataSource = bsCategories;


            dgvConferenceCategory.Columns[0].HeaderText = "Name";
            dgvConferenceCategory.Columns[1].HeaderText = "Id";
        }


        public void LoadConferenceTypes()
        {
            List<ConferenceTypeModel> conferenceTypes = new List<ConferenceTypeModel>();
            conferenceTypes = _conferenceTypeRepository.getConferenceTypes();
            bsTypes.AllowNew = true;
            bsTypes.DataSource = null;
            bsTypes.DataSource = conferenceTypes;

            dgvConferenceType.DataSource = bsTypes;


            dgvConferenceType.Columns[0].HeaderText = "Name";
            dgvConferenceType.Columns[1].HeaderText = "Id";
        }
        public void LoadConferenceTypes(string keyword)
        {
            List<ConferenceTypeModel> conferenceTypes = new List<ConferenceTypeModel>();
            conferenceTypes = _conferenceTypeRepository.getConferenceTypes(keyword);
            bsTypes.AllowNew = true;
            bsTypes.DataSource = null;
            bsTypes.DataSource = conferenceTypes;

            dgvConferenceType.DataSource = bsTypes;


            dgvConferenceType.Columns[0].HeaderText = "Name";
            dgvConferenceType.Columns[1].HeaderText = "Id";
        }


        private void tbCategory_TextChanged(object sender, EventArgs e)
        {
            string keyword = tbCategory.Text;
            LoadConferenceCategories(keyword);
        }

        private void tbConferenceType_TextChanged(object sender, EventArgs e)
        {
            string keyword = tbConferenceType.Text;
            LoadConferenceTypes(keyword);

        }

        private void dgvConferenceType_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            Console.WriteLine("Row Added");
        }

        private void dgvConferenceCategory_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            Console.WriteLine("Row Added");

        }

        private void dgvConferenceCategory_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Console.WriteLine("Row Added Corectly");

        }

        public ConferenceModel AddConference()
        {
            ConferenceModel conference = new ConferenceModel();

            //foreach(DataGridViewRow row in dgvConferenceCategory.SelectedRows)
            //{
            //    conference.ConferenceCategory = row.Cells[0].Value.ToString();
            //    Console.WriteLine(conference.ConferenceCategory);
            //}
            // if (dgvConferenceCategory.SelectedRows != null)
            // {
            //  conference.ConferenceCategory = dgvConferenceCategory.SelectedRows[0].Cells[0].Value.ToString();
            //}
            // Console.WriteLine(conference.ConferenceCategory);

            return conference;

        }

        private void dgvConferenceCategory_SelectionChanged(object sender, EventArgs e)
        {
            AddConference();
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            int selectedIndex = dgvCountries.SelectedRows[0].Index;
            int countryId = Convert.ToInt32(dgvCountries[1, selectedIndex].Value);
            _getCountryRepository.DeleteCountry(countryId);
            LoadCountries();
        }
    }



}