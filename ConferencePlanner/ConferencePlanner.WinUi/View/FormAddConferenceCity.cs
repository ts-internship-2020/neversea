using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.WinUi.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi.View
{
    public partial class FormAddConferenceCity : Form
    {
        public int locationId = 0;
        private readonly IConferenceCityRepository conferenceCityRepository;
        private readonly IConferenceLocationRepository conferenceLocationRepository;
        List<ConferenceCityModel> cities = new List<ConferenceCityModel>();
        public int range = 0;
        public int step = 4;
        public int shown = 4;
        public int maxrange;
        public FormAddConferenceCity(IConferenceCityRepository _conferenceCityRepository, IConferenceLocationRepository _conferenceLocationRepository)
        {
            conferenceLocationRepository = _conferenceLocationRepository;
            conferenceCityRepository = _conferenceCityRepository;
            InitializeComponent();
            LoadCities(1);
        }

        private async void LoadCities(int districtId)
        {
            //HttpClient httpClient = HttpClientFactory.Create();
            //var url = "http://localhost:5000/GetConfereceCitiesById?districtId=1";
            //HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

            //if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            //{
            //    var content = httpResponseMessage.Content;
            //    var data = await content.ReadAsStringAsync();

            //    cities = (List<ConferenceCityModel>)JsonConvert.DeserializeObject<IEnumerable<ConferenceCityModel>>(data);
            //}
            cities = conferenceCityRepository.GetConferenceCities(districtId);

            var url = "http://localhost:5000/GetConfereceCitiesById?districtId="
                + districtId.ToString();

            //cities = await HttpClientOperations.GetOperation<ConferenceCityModel>(url);
            dgvCities.ColumnCount = 3;
            dgvCities.Columns[0].Name = "Id";
            dgvCities.Columns[1].Name = "City";
            dgvCities.Columns[2].Name = "DistrictId";
            this.dgvCities.Columns[0].Visible = false;
            this.dgvCities.Columns[2].Visible = false;
            maxrange = cities.Count;
            WireUpCities();
        }

       
        private void dgvCities_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvCities.Columns[e.ColumnIndex].Name == "City")
            {
                try
                {
                    if (dgvCities.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value != null)
                    {
                        int indexCity = Convert.ToInt32(dgvCities.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString());
                        string nameCity = dgvCities.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        //conferenceCityRepository.UpdateCity(indexCity, nameCity, 1);
                        ConferenceCityModel cityUpdated = new ConferenceCityModel();
                        cityUpdated.ConferenceCityName = nameCity;
                        cityUpdated.ConferenceCityId = indexCity;
                        cityUpdated.ConferenceDistrictId = 1;
                        HttpClientOperations.PutOperation<ConferenceCityModel>("http://localhost:5000/UpdateCity", cityUpdated);
                        cities[e.RowIndex].ConferenceCityName = nameCity;
                    }
                    else
                    {
                        string nameCity = dgvCities.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        // conferenceCityRepository.InsertCity(nameCity, 1);
                        ConferenceCityModel city = new ConferenceCityModel();
                        city.ConferenceCityName = nameCity;
                        city.ConferenceDistrictId = 1;
                        HttpClientOperations.PostOperation<ConferenceCityModel>("http://localhost:5000/InsertCity", city);
                        dgvCities.Rows.Clear();
                        if (txtSearch.Text == null)
                            LoadCities(1);
                        else
                        {
                            LoadCities(1, txtSearch.Text);
                        }
                        
                    }
                }
                catch
                {
                    
                }
            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {   ///SEARCH CITY
            Console.WriteLine("text changed");
            
            range = 0;
            btnPreviousPage.Enabled = false;
            step = (int)comboBoxPagesCount.SelectedItem;
            shown = (int)comboBoxPagesCount.SelectedItem;
            string keyword = txtSearch.Text;
            if (keyword == "")
            {
                LoadCities(1);
            }
            else
            {
                LoadCities(1, keyword); // de inlocuit cu district Id ul selectat
            }
        }
        private async void LoadCities(int districtId, string keyword)
        {
            var url = "http://localhost:5000/GetConfereceCitiesByIdAndKeyword?districtId=" + districtId.ToString()+"&keyword="+keyword;
            cities = await HttpClientOperations.GetOperation<ConferenceCityModel>(url);
            Console.WriteLine("Lista cities are marimea " + cities.Count);
            //cities = conferenceCityRepository.GetConferenceCities(districtId, keyword);
            dgvCities.ColumnCount = 3;
            dgvCities.Columns[0].Name = "Id";
            dgvCities.Columns[1].Name = "City";
            dgvCities.Columns[2].Name = "DistrictId";
            this.dgvCities.Columns[0].Visible = false;
            this.dgvCities.Columns[2].Visible = false;
            maxrange = cities.Count;
            WireUpCities();
        }

        public void WireUpCities()
        {
            dgvCities.Rows.Clear();
            for (int i = range; i < step; i++)
            {
                if (i >= maxrange)
                {
                    Console.WriteLine("breaked");
                    break;
                }
                else
                {   
                    dgvCities.Rows.Add(cities[i].ConferenceCityId,
                            cities[i].ConferenceCityName,cities[i].ConferenceDistrictId);
                }
                if (cities.Count <= (int)comboBoxPagesCount.SelectedItem)
                {
                    btnNextPage.Enabled = false;
                }
                else if (step < maxrange)
                {
                    btnNextPage.Enabled = true;
                }

            }

            dgvCities.FirstDisplayedCell.Selected = false;


        }

        private void btnDelete_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvCities.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvCities.SelectedRows[0].Index;
                int cityId = Convert.ToInt32(dgvCities[0, selectedIndex].Value);
                int districtId = Convert.ToInt32(dgvCities[2, selectedIndex].Value);

                ConferenceCityModel model = new ConferenceCityModel();

                model.ConferenceCityId = cityId;
                model.ConferenceDistrictId = districtId;

                HttpClientOperations.DeleteOperation<ConferenceCityModel>("http://localhost:5000/DeleteCity", model);

                dgvCities.Rows.Clear();
                WireUpCities();
            }
        }

        private void FormAddConferenceCity_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormAddConferenceGeneral.location.CityId = locationId;
        }

        private void dgvCities_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            locationId = Convert.ToInt32(dgvCities.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString());
            FormAddConferenceGeneral.location.CityId = locationId;
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            dgvCities.Rows.Clear();
            range = step;
            step += shown;
            btnPreviousPage.Enabled = true;
            if (step >= maxrange)
            {
                btnNextPage.Enabled = false;
            }
            Console.WriteLine("Am dat Next: range=" + range + " si step=" + step);
            WireUpCities();
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            dgvCities.Rows.Clear();
            step = range;
            range -= shown;
            btnPreviousPage.Enabled = true;
            if (range == 0)
            {
                btnPreviousPage.Enabled = false;
            }
            Console.WriteLine("Am dat Back: range=" + range + " si step=" + step);
            WireUpCities();
        }

        private void comboBoxPagesCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvCities.Rows.Clear();
            range = 0;
            step = (int)comboBoxPagesCount.SelectedItem;
            shown = (int)comboBoxPagesCount.SelectedItem;
            btnPreviousPage.Enabled = false;
            WireUpCities();
        }
    }
}
