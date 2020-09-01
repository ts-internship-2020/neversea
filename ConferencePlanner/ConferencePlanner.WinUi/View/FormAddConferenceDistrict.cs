﻿using ConferencePlanner.Abstraction.Model;
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

        private void LoadDistricts()
        {
            districts = districtRepository.GetDistricts();
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

        private void LoadDistricts(string keyword)
        {
            districts = districtRepository.GetDistricts(keyword);

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
                    btnNextDistrict.Enabled = false;
                }
                else if (step < maxrange)
                {
                    btnNextDistrict.Enabled = true;
                }
            }
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            dgvDistricts.Rows.Clear();
            range = step;
            step += shown;
            btnPreviousPage.Visible = true;
            if (step >= maxrange)
            {
                btnNext.Enabled = false;
            }
            Console.WriteLine("Am dat Next: range=" + range + " si step=" + step);
            WireUpDistricts();

        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            dgvDistricts.Rows.Clear();
            step = range;
            range -= shown;
            btnPreviousPage.Visible = true;
            if (range == 0)
            {
                btnPreviousPage.Visible = false;
            }
            Console.WriteLine("Am dat Back: range=" + range + " si step=" + step);
            WireUpDistricts();

        }

        private void comboBoxPagesNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDistricts.Rows.Clear();
            range = 0;
            step = (int)comboBoxPagesNumber.SelectedItem;
            shown = (int)comboBoxPagesNumber.SelectedItem;
            btnBackDistrict.Visible = false;
            WireUpDistricts();
        }

        private void btnNextDistrict_Click(object sender, EventArgs e)
        {
            dgvDistricts.Rows.Clear();
            range = step;
            step += shown;
            btnBackDistrict.Visible = true;
            if (step >= maxrange)
            {
                btnNextDistrict.Enabled = false;
            }
            Console.WriteLine("Am dat Next: range=" + range + " si step=" + step);
            WireUpDistricts();

        }

        private void btnBackDistrict_Click(object sender, EventArgs e)
        {
            dgvDistricts.Rows.Clear();
            step = range;
            range -= shown;
            btnBackDistrict.Visible = true;
            if (range == 0)
            {
                btnBackDistrict.Visible = false;
            }
            Console.WriteLine("Am dat Back: range=" + range + " si step=" + step);
            WireUpDistricts();
        }
    }
}
