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
        public int categoryId = 0;
        private readonly IConferenceCategoryRepository conferenceCategoryRepository;
        
        public List<ConferenceCategoryModel> conferenceCategories = new List<ConferenceCategoryModel>();
        public int range = 0;
        public int step = 4;
        public int shown = 4;
        public int maxrange;
        public FormAddConferenceCategory(IConferenceCategoryRepository _conferenceCategoryRepository)
        {
            conferenceCategoryRepository = _conferenceCategoryRepository;
            InitializeComponent();
            LoadConferenceCategories();
        }

        private void LoadConferenceCategories()
        {
            conferenceCategories = conferenceCategoryRepository.GetConferenceCategories();
            dgvConferenceCategories.ColumnCount = 2;
            dgvConferenceCategories.Columns[0].Name = "Category";
            dgvConferenceCategories.Columns[1].Name = "Id";
            dgvConferenceCategories.Columns[1].Visible = false;
            maxrange = conferenceCategories.Count;
            WireUpCategories();
        }

        public void LoadConferenceCategories(string keyword)
        {
            conferenceCategories = conferenceCategoryRepository.GetConferenceCategories(keyword);
            dgvConferenceCategories.ColumnCount = 2;
            dgvConferenceCategories.Columns[0].Name = "Category";
            dgvConferenceCategories.Columns[1].Name = "Id";
            dgvConferenceCategories.Columns[1].Visible = false;
            maxrange = conferenceCategories.Count;
            WireUpCategories();
        }
        private void WireUpCategories()
        {
            dgvConferenceCategories.Rows.Clear();
            for (int i = range; i < step; i++)
            {
                if (i >= maxrange)
                {
                    Console.WriteLine("breaked");
                    break;
                }
                else
                {
                    dgvConferenceCategories.Rows.Add(conferenceCategories[i].conferenceCategoryName,
                            conferenceCategories[i].conferenceCategoryId);
                }
                if (conferenceCategories.Count <= (int)comboBoxPagesNumber.SelectedItem)
                {
                    button2.Enabled = false;
                }
                else if (step < maxrange)
                {
                    button2.Enabled = true;
                }
            }

        }
        private void dgvConferenceCategories_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int conferenceCategoryId;
            string conferenceCategoryName = "";

            try
            {
                if (dgvConferenceCategories.Rows[e.RowIndex].Cells[1].Value != null)
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
            if (dgvConferenceCategories.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvConferenceCategories.SelectedRows[0].Index;
                int conferenceCategoryId = Convert.ToInt32(dgvConferenceCategories[1, selectedIndex].Value);
                conferenceCategoryRepository.DeleteConferenceCategory(conferenceCategoryId);
                LoadConferenceCategories();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            range = 0;
            btnPrevious.Visible = false;
            step = (int)comboBoxPagesNumber.SelectedItem;
            shown = (int)comboBoxPagesNumber.SelectedItem;
            LoadConferenceCategories(keyword);
        }

        private void dgvConferenceCategories_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvConferenceCategories.ClearSelection();
        }

        private void dgvConferenceCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            categoryId = Convert.ToInt32(dgvConferenceCategories.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString());
        }

        private void FormAddConferenceCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormAddConferenceGeneral.conference.ConferenceCategory = categoryId.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvConferenceCategories.Rows.Clear();
            range = step;
            step += shown;
            btnPrevious.Visible = true;
            if (step >= maxrange)
            {
                button2.Enabled = false;
            }
            WireUpCategories();

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            dgvConferenceCategories.Rows.Clear();
            step = range;
            range -= shown;
            btnPrevious.Visible = true;
            if (range == 0)
            {
                btnPrevious.Visible = false;
            }
            WireUpCategories();

        }
        private void comboBoxPagesNumber_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Console.WriteLine("Am schimbat index");
            dgvConferenceCategories.Rows.Clear();
            range = 0;
            step = (int)comboBoxPagesNumber.SelectedItem;
            shown = (int)comboBoxPagesNumber.SelectedItem;
            btnPrevious.Visible = false;
            WireUpCategories();
        }
    }
}
