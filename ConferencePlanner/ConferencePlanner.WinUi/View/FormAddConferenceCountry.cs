using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.WinUi.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Windows.UI.Xaml.Documents;

namespace ConferencePlanner.WinUi.View
{
    public partial class FormAddConferenceCountry : Form
    {
        public int id = 0;
        private readonly ICountryRepository countryRepository;
        private readonly IConferenceLocationRepository conferenceLocationRepository;
        public List<CountryModel> countries { get; set; }
        public int range = 0;
        public int step = 4;
        public int shown = 4;
        public int maxrange;

        public FormAddConferenceCountry(ICountryRepository _countryRepository, IConferenceLocationRepository _conferenceLocationRepository)
        {
            conferenceLocationRepository = _conferenceLocationRepository;
            countryRepository = _countryRepository;
            InitializeComponent();
            LoadCountries();
        }

        private async void LoadCountries()
        {
            //countries = countryRepository.GetCountry();
            var url = "http://localhost:5000/GetCountry";
            countries = await HttpClientOperations.GetOperation<CountryModel>(url);

            this.dgvCountries.ColumnCount = 4;
            this.dgvCountries.Columns[1].Visible = false;

            dgvCountries.Columns[0].Name = "Country";
            dgvCountries.Columns[1].Name = "Id";
            dgvCountries.Columns[2].Name = "Code";
            dgvCountries.Columns[3].Name = "Nationality";
            maxrange = countries.Count;
            WireUpCountries();
        }

        private void LoadCountries(string keyword)
        {
            countries = countryRepository.GetCountry(keyword);

            this.dgvCountries.ColumnCount = 4;
            this.dgvCountries.Columns[1].Visible = false;

            dgvCountries.Columns[0].Name = "Country";
            dgvCountries.Columns[1].Name = "Id";
            dgvCountries.Columns[2].Name = "Code";
            dgvCountries.Columns[3].Name = "Nationality";
            maxrange = countries.Count;
            WireUpCountries();
        }

        public void WireUpCountries()
        {
            dgvCountries.Rows.Clear();
            for (int i = range; i < step; i++)
            {
                if (i >= maxrange)
                {
                    Console.WriteLine("breaked");
                    break;
                }
                else
                {
                    dgvCountries.Rows.Add(countries[i].CountryName,
                            countries[i].CountryId,
                            countries[i].CountryCode,
                            countries[i].CountryNationality);
                }
                if (countries.Count <= (int)comboBoxPagesNumber.SelectedItem)
                {
                    button2.Enabled = false;
                }
                else if (step < maxrange)
                {
                    button2.Enabled = true;
                }

            }
        }
        private void dgvCountries_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int countryId;
            string countryName = "";
            string countryCode = "";
            string nationality = "";

            try
            {
                if (dgvCountries.Rows[e.RowIndex].Cells["Id"].Value != null)
                {
                    countryId = Convert.ToInt32(dgvCountries.Rows[e.RowIndex].Cells[1].Value.ToString());
                    countryName = dgvCountries.Rows[e.RowIndex].Cells[0].Value == null ? "" : dgvCountries.Rows[e.RowIndex].Cells[0].Value.ToString();
                    countryCode = dgvCountries.Rows[e.RowIndex].Cells[2].Value == null ? "" : dgvCountries.Rows[e.RowIndex].Cells[2].Value.ToString();
                    nationality = dgvCountries.Rows[e.RowIndex].Cells[3].Value == null ? "" : dgvCountries.Rows[e.RowIndex].Cells[3].Value.ToString();
                    countryRepository.UpdateCountry(countryId, countryName, countryCode, nationality);
                    LoadCountries();
                }

                else
                {
                    countryName = dgvCountries.Rows[e.RowIndex].Cells[0].Value == null ? "" : dgvCountries.Rows[e.RowIndex].Cells[0].Value.ToString();
                    countryCode = dgvCountries.Rows[e.RowIndex].Cells[2].Value == null ? "" : dgvCountries.Rows[e.RowIndex].Cells[2].Value.ToString();
                    nationality = dgvCountries.Rows[e.RowIndex].Cells[3].Value == null ? "" : dgvCountries.Rows[e.RowIndex].Cells[3].Value.ToString();
                    CountryModel country = new CountryModel();
                    country.CountryName = countryName;
                    country.CountryNationality = nationality;
                    country.CountryCode = countryCode;
                    HttpClientOperations.PostOperation<CountryModel>("http://localhost:5000/InsertCountry", country);
                    // countryRepository.InsertCountry(countryName, countryCode, nationality);
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
            if(dgvCountries.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvCountries.SelectedRows[0].Index;
                int countryId = Convert.ToInt32(dgvCountries[1, selectedIndex].Value);
                //countryRepository.DeleteCountry(countryId);
                CountryModel model = new CountryModel();

                model.CountryId = countryId;

                HttpClientOperations.DeleteOperation<CountryModel>("", model);
                LoadCountries();
            }   

        }

        private void dgvCountries_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvCountries.ClearSelection();
        }

        private void FormAddConferenceCountry_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadCountries();

            for (int i = 0; i < dgvCountries.Rows.Count - 1; i++)
            {
                foreach(DataGridViewColumn column in dgvCountries.Columns)
                {
                    if(dgvCountries.Rows[i].Cells[column.Name] == null)
                    {
                        e.Cancel = true;
                        break;
                    }
                }
            }

            if (e.Cancel == true)
            {
                MessageBox.Show("You must fill in all the fields.");
            }
            else 
            {
                FormAddConferenceGeneral.countryId = id;
            }

        }

        private void dgvCountries_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvCountries.Rows[e.RowIndex].Cells["Id"].Value.ToString() != null) { 
             id= Convert.ToInt32(dgvCountries.Rows[e.RowIndex].Cells["Id"].Value.ToString());
             }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvCountries.Rows.Clear();
            range = step;
            step += shown;
            btnPreviousPage.Visible = true;
            if (step >= maxrange)
            {
                button2.Enabled = false;
            }
            Console.WriteLine("Am dat Next: range=" + range + " si step=" + step);
            WireUpCountries();

        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            dgvCountries.Rows.Clear();
            step = range;
            range -= shown;
            btnPreviousPage.Visible = true;
            if (range == 0)
            {
                btnPreviousPage.Visible = false;
            }
            Console.WriteLine("Am dat Back: range=" + range + " si step=" + step);
            WireUpCountries();
        }

        private void comboBoxPagesNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvCountries.Rows.Clear();
            range = 0;
            step = (int)comboBoxPagesNumber.SelectedItem;
            shown = (int)comboBoxPagesNumber.SelectedItem;
            btnPreviousPage.Visible = false;
            WireUpCountries();

        }
    }
}