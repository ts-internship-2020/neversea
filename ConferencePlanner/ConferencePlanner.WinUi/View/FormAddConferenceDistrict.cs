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
    public partial class FormAddConferenceDistrict : Form
    {
        public int DistrictId;
        private readonly IDistrictRepository districtRepository;
        private readonly IConferenceLocationRepository conferenceLocationRepository;

        private BindingSource bsDistricts = new BindingSource();

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

        private void LoadDistricts()
        {
            List<DistrictModel> districts = new List<DistrictModel>();
            districts = districtRepository.GetDistricts();
            bsDistricts.AllowNew = true;
            bsDistricts.DataSource = null;
            bsDistricts.DataSource = districts;
            dgvDistricts.DataSource = bsDistricts;

            this.dgvDistricts.Columns[3].Visible = false;
            this.dgvDistricts.Columns[0].Visible = false;


            dgvDistricts.Columns[0].HeaderText = "Id";
            dgvDistricts.Columns[1].HeaderText = "District";
            dgvDistricts.Columns[2].HeaderText = "Code";
            dgvDistricts.Columns[3].HeaderText = "CountryId";
            dgvDistricts.Columns[0].Name = "Id";


        }

        private void LoadDistricts(string keyword)
        {
            List<DistrictModel> districts = new List<DistrictModel>();
            districts = districtRepository.GetDistricts(keyword);

            bsDistricts.AllowNew = true;
            bsDistricts.DataSource = null;
            bsDistricts.DataSource = districts;

            dgvDistricts.DataSource = bsDistricts;

            this.dgvDistricts.Columns[3].Visible = false;
            this.dgvDistricts.Columns[0].Visible = false;


            dgvDistricts.Columns[0].HeaderText = "Id";
            dgvDistricts.Columns[1].HeaderText = "District";
            dgvDistricts.Columns[2].HeaderText = "Code";
            dgvDistricts.Columns[3].HeaderText = "CountryId";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            LoadDistricts(keyword);
        }

        private void dgvDistricts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int districtId;
            string districtName = "";
            string districtCode = "";
            int countryId;

            try
            {
                if ((int)dgvDistricts.Rows[e.RowIndex].Cells[0].Value != 0)
                {
                    districtId = Convert.ToInt32(dgvDistricts.Rows[e.RowIndex].Cells[0].Value.ToString());
                    districtName = dgvDistricts.Rows[e.RowIndex].Cells[1].Value.ToString();
                    districtCode = dgvDistricts.Rows[e.RowIndex].Cells[2].Value.ToString();
                    countryId = Convert.ToInt32(dgvDistricts.Rows[e.RowIndex].Cells[3].Value.ToString());
                    districtRepository.UpdateDistrict(districtId, districtName, districtCode, countryId);
                }

                else
                {
                    districtName = dgvDistricts.Rows[e.RowIndex].Cells[1].Value == null ? "" : dgvDistricts.Rows[e.RowIndex].Cells[1].Value.ToString();
                    districtCode = dgvDistricts.Rows[e.RowIndex].Cells[2].Value == null ? "" : dgvDistricts.Rows[e.RowIndex].Cells[2].Value.ToString();
                    countryId = Convert.ToInt32(dgvDistricts.Rows[e.RowIndex].Cells[3].Value.ToString());


                    districtRepository.InsertDistrict(districtName, districtCode, countryId);
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
                districtRepository.DeleteDistrict(districtId, countryId);
                LoadDistricts();
            }
        }

        private void dgvDistricts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvDistricts.ClearSelection();
        }

        private void dgvDistricts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            DistrictId = Convert.ToInt32(dgvDistricts.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString());

        }

        private void FormAddConferenceDistrict_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormAddConferenceGeneral.districtId = DistrictId;
        }
    }
}
