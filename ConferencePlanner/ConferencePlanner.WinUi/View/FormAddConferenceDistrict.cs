using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Web.Http;
using HttpClient = System.Net.Http.HttpClient;
using HttpResponseMessage = System.Net.Http.HttpResponseMessage;
using Newtonsoft.Json;
using ConferencePlanner.WinUi.Utilities;

namespace ConferencePlanner.WinUi.View
{
    public partial class FormAddConferenceDistrict : Form
    {
        public int DistrictId;
        private readonly IDistrictRepository districtRepository;
        private readonly IConferenceLocationRepository conferenceLocationRepository;
        List<DistrictModel> districts = new List<DistrictModel>();
        public int range = 0;
        public int step = 4;
        public int shown = 4;
        public int maxrange;

        public FormAddConferenceDistrict(IDistrictRepository _districtRepository, IConferenceLocationRepository _conferenceLocationRepository)
        {
            conferenceLocationRepository = _conferenceLocationRepository;
            districtRepository = _districtRepository;
            InitializeComponent();
            foreach(Control ctrl in dgvDistricts.Controls)
            {
                if (ctrl.GetType() == typeof(ScrollBar))
                {
                    ctrl.BackColor = Color.Transparent;
                }
            }
            LoadDistricts();
        }

        private async void LoadDistricts()
        {
            //districts = districtRepository.GetDistricts();
            var url = "http://localhost:5000/api/District";
            districts = await HttpClientOperations.GetOperation<DistrictModel>(url);
            dgvDistricts.ColumnCount = 4;

            this.dgvDistricts.Columns[3].Visible = false;
            this.dgvDistricts.Columns[0].Visible = false;
            button2.Enabled = false;
            dgvDistricts.Columns[0].Name = "Id";
            dgvDistricts.Columns[1].Name = "District";
            dgvDistricts.Columns[2].Name = "Code";
            dgvDistricts.Columns[3].Name = "CountryId";
            maxrange = districts.Count;
            WireUpDistricts();
        }

        private async void LoadDistricts(string keyword)
        {
            //districts = districtRepository.GetDistricts(keyword);
            var url = "http://localhost:5000/api/District/getDistrictsFiltered?keyword="+keyword;
            districts = await HttpClientOperations.GetOperation<DistrictModel>(url);
            dgvDistricts.ColumnCount = 4;
            this.dgvDistricts.Columns[3].Visible = false;
            this.dgvDistricts.Columns[0].Visible = false;
            
            dgvDistricts.Columns[0].Name = "Id";
            dgvDistricts.Columns[1].Name = "District";
            dgvDistricts.Columns[2].Name = "Code";
            dgvDistricts.Columns[3].Name = "CountryId";
            maxrange = districts.Count;
            WireUpDistricts();
        }
        private void WireUpDistricts()
        {   
            comboBoxPagesNumber.SelectedIndex = 0;
            dgvDistricts.Rows.Clear();
            for (int i = range; i < step; i++)
            {
                if (i >= maxrange)
                {
                    Console.WriteLine("breaked");
                    break;
                }
                else
                {
                    dgvDistricts.Rows.Add(districts[i].DistrictId,
                            districts[i].DistrictName,
                            districts[i].DistrictCode,
                            districts[i].CountryId);
                }
                if (districts.Count <= (int)comboBoxPagesNumber.SelectedItem)
                {
                  button1.Visible = false;
                }
                else if (step < maxrange)
                {
                  button2.Visible = true;
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            if (keyword == "")
            {
                LoadDistricts();
            }
            else
            {
                LoadDistricts(keyword);
            }
            
        }

        private void dgvDistricts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int districtId;
            string districtName = "";
            string districtCode = "";
            int countryId;

            try
            {
                if ((dgvDistricts.Rows[e.RowIndex].Cells["Id"].Value != null) && (Convert.ToInt32(dgvDistricts.Rows[e.RowIndex].Cells["Id"].Value.ToString()) != 0))
                {
                    districtId = Convert.ToInt32(dgvDistricts.Rows[e.RowIndex].Cells[0].Value.ToString());
                    districtName = dgvDistricts.Rows[e.RowIndex].Cells[1].Value == null ? "" : dgvDistricts.Rows[e.RowIndex].Cells[1].Value.ToString();
                    districtCode = dgvDistricts.Rows[e.RowIndex].Cells[2].Value == null ? "" : dgvDistricts.Rows[e.RowIndex].Cells[2].Value.ToString();
                    countryId = dgvDistricts.Rows[e.RowIndex].Cells[3].Value == null ? 0 : Convert.ToInt32(dgvDistricts.Rows[e.RowIndex].Cells[3].Value.ToString());
                    districtRepository.UpdateDistrict(districtId, districtName, districtCode, countryId);
                }

                else
                {
                    districtName = dgvDistricts.Rows[e.RowIndex].Cells[1].Value == null ? "" : dgvDistricts.Rows[e.RowIndex].Cells[1].Value.ToString();
                    districtCode = dgvDistricts.Rows[e.RowIndex].Cells[2].Value == null ? "" : dgvDistricts.Rows[e.RowIndex].Cells[2].Value.ToString();
                   // countryId = Convert.ToInt32(dgvDistricts.Rows[e.RowIndex].Cells[3].Value.ToString());

                    DistrictModel model = new DistrictModel();
                    model.DistrictName = districtCode;
                    model.DistrictCode = districtCode;
                    model.CountryId = 1;
                   // model.CountryId = countryId;

                    HttpClientOperations.PostOperation<DistrictModel>("http://localhost:5000/api/District/insertDistrict", model);
                    // districtRepository.InsertDistrict(districtName, districtCode, 1);
                    dgvDistricts.Rows.Clear();
                    LoadDistricts();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnDelete_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvDistricts.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvDistricts.SelectedRows[0].Index;
                int districtId = Convert.ToInt32(dgvDistricts[0, selectedIndex].Value);
                int countryId = Convert.ToInt32(dgvDistricts[3, selectedIndex].Value);
                DistrictModel model = new DistrictModel();
                model.DistrictId = districtId;
                model.CountryId = countryId;
                HttpClientOperations.DeleteOperation<DistrictModel>("http://localhost:5000/api/District/deleteDistrict", model);
                // districtRepository.DeleteDistrict(districtId, countryId);
                LoadDistricts();
            }

        }

        private void dgvDistricts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvDistricts.ClearSelection();
        }

        private void dgvDistricts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvDistricts.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString() != null) { 
            DistrictId = Convert.ToInt32(dgvDistricts.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString());
            }
        }

        private void FormAddConferenceDistrict_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormAddConferenceGeneral.districtId = DistrictId;
        }
        private void comboBoxPagesNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDistricts.Rows.Clear();
            range = 0;
            step = (int)comboBoxPagesNumber.SelectedItem;
            shown = (int)comboBoxPagesNumber.SelectedItem;
            //btnBackDistrict.Visible = false;
            WireUpDistricts();
        }
        private void btnBackDistrict_Click(object sender, EventArgs e)
        {

        }
        private void btnNextDistrict_Click(object sender, EventArgs e)
        {
    

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvDistricts.Rows.Clear();
            range = step;
            step += shown;
            button2.Enabled = true;
            if (step >= maxrange)
            {
                button1.Enabled = false;
            }
            Console.WriteLine("Am dat Next: range=" + range + " si step=" + step);
            WireUpDistricts();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvDistricts.Rows.Clear();
            step = range;
            range -= shown;
            button1.Enabled = true;
            if (range == 0)
            {
                button2.Enabled = false;
            }
            Console.WriteLine("Am dat Back: range=" + range + " si step=" + step);
            WireUpDistricts();
        }
    }
}
