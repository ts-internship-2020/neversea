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
    public partial class FormAddConferenceCategory : Form
    {
        private readonly IConferenceCategoryRepository conferenceCategoryRepository;
        private BindingSource bsCategories = new BindingSource();
        public List<ConferenceCategoryModel> conferenceCategories = new List<ConferenceCategoryModel>();

        public FormAddConferenceCategory(IConferenceCategoryRepository _conferenceCategoryRepository)
        {
            conferenceCategoryRepository = _conferenceCategoryRepository;
            InitializeComponent();
            LoadConferenceCategories();
        }

        private void LoadConferenceCategories()
        {
            conferenceCategories = conferenceCategoryRepository.GetConferenceCategories();
            bsCategories.AllowNew = true;
            bsCategories.DataSource = null;
            bsCategories.DataSource = conferenceCategories;

            dgvConferenceCategories.DataSource = bsCategories;


            dgvConferenceCategories.Columns[0].HeaderText = "Name";
            dgvConferenceCategories.Columns[1].HeaderText = "Id";

            dgvConferenceCategories.Columns[1].Visible = false;
        }

        public void LoadConferenceCategories(string keyword)
        {
            conferenceCategories = conferenceCategoryRepository.GetConferenceCategories(keyword);

            bsCategories.AllowNew = true;
            bsCategories.DataSource = null;
            bsCategories.DataSource = conferenceCategories;

            dgvConferenceCategories.DataSource = bsCategories;


            dgvConferenceCategories.Columns[0].HeaderText = "Name";
            dgvConferenceCategories.Columns[1].HeaderText = "Id";

            dgvConferenceCategories.Columns[1].Visible = false;
        }

        private void dgvConferenceCategories_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int conferenceCategoryId;
            string conferenceCategoryName = "";

            try
            {
                if ((int)dgvConferenceCategories.Rows[e.RowIndex].Cells[1].Value != 0)
                {
                    conferenceCategoryId = Convert.ToInt32(dgvConferenceCategories.Rows[e.RowIndex].Cells[1].Value.ToString());
                    conferenceCategoryName = dgvConferenceCategories.Rows[e.RowIndex].Cells[0].Value.ToString();
                    conferenceCategoryRepository.UpdateConferenceCategory(conferenceCategoryId, conferenceCategoryName);
                }

                else
                {
                    conferenceCategoryName = dgvConferenceCategories.Rows[e.RowIndex].Cells[0].Value.ToString();

                    conferenceCategoryRepository.InsertConferenceCategory(conferenceCategoryName);
                    dgvConferenceCategories.Rows.Clear();
                    LoadConferenceCategories();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void btnDelete_MouseClick(object sender, MouseEventArgs e)
        {
            int selectedIndex = dgvConferenceCategories.SelectedRows[0].Index;
            int conferenceCategoryId = Convert.ToInt32(dgvConferenceCategories[1, selectedIndex].Value);
            conferenceCategoryRepository.DeleteConferenceCategory(conferenceCategoryId);
            LoadConferenceCategories();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            LoadConferenceCategories(keyword);
        }
    }
}
