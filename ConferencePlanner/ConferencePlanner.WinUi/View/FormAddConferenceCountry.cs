using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi.View
{
    public partial class FormAddConferenceCountry : Form
    {
        public int id = 0;
        private readonly ICountryRepository countryRepository;
        private readonly IConferenceLocationRepository conferenceLocationRepository;
        private BindingSource bsCountries = new BindingSource();

        public List<CountryModel> countries { get; set; }

        public FormAddConferenceCountry(ICountryRepository _countryRepository, IConferenceLocationRepository _conferenceLocationRepository)
        {
            conferenceLocationRepository = _conferenceLocationRepository;
            countryRepository = _countryRepository;
            InitializeComponent();
            LoadCountries();
        }

        private void LoadCountries()
        {
            countries = countryRepository.GetCountry();

            bsCountries.AllowNew = true;
            bsCountries.DataSource = null;
            bsCountries.DataSource = countries;

            dgvCountries.DataSource = bsCountries;

            this.dgvCountries.Columns[1].Visible = false;


            dgvCountries.Columns[0].HeaderText = "Name";
            dgvCountries.Columns[1].HeaderText = "Id";
            dgvCountries.Columns[2].HeaderText = "Code";
            dgvCountries.Columns[3].HeaderText = "Nationality";
            dgvCountries.Columns[1].Name = "Id";


        }

        private void LoadCountries(string keyword)
        {
            countries = countryRepository.GetCountry(keyword);

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


        private void dgvCountries_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int countryId;
            string countryName = "";
            string countryCode = "";
            string nationality = "";

            try
            {
                if ((int)dgvCountries.Rows[e.RowIndex].Cells[1].Value != 0)
                {
                    countryId = Convert.ToInt32(dgvCountries.Rows[e.RowIndex].Cells[1].Value.ToString());
                    countryName = dgvCountries.Rows[e.RowIndex].Cells[0].Value.ToString();
                    countryCode = dgvCountries.Rows[e.RowIndex].Cells[2].Value.ToString();
                    nationality = dgvCountries.Rows[e.RowIndex].Cells[3].Value.ToString();
                    countryRepository.UpdateCountry(countryId, countryName, countryCode, nationality);
                }

                else
                {
                    countryName = dgvCountries.Rows[e.RowIndex].Cells[0].Value.ToString();
                    countryCode = dgvCountries.Rows[e.RowIndex].Cells[2].Value == null ? "" : dgvCountries.Rows[e.RowIndex].Cells[2].Value.ToString();
                    nationality = dgvCountries.Rows[e.RowIndex].Cells[3].Value == null ? "" : dgvCountries.Rows[e.RowIndex].Cells[3].Value.ToString();

                    countryRepository.InsertCountry(countryName, countryCode, nationality);
                    dgvCountries.Rows.Clear();
                    LoadCountries();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearchBar.Text;
            LoadCountries(keyword);
        }

        private void btnDeleteSelected_MouseClick(object sender, MouseEventArgs e)
        {
            int selectedIndex = dgvCountries.SelectedRows[0].Index;
            int countryId = Convert.ToInt32(dgvCountries[1, selectedIndex].Value);
            countryRepository.DeleteCountry(countryId);
            LoadCountries();
        }

        private void FormAddConferenceCountry_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormAddConferenceGeneral.countryId = id;

        }

        private void dgvCountries_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             id= Convert.ToInt32(dgvCountries.Rows[e.RowIndex].Cells["Id"].Value.ToString());
        }
    }
}