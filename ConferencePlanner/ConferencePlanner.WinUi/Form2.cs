﻿using ConferencePlanner.Abstraction.Model;
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
        private readonly ICountryRepository _getCountryRepository;
        private BindingSource bsCountries = new BindingSource();

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
            LoadCountries();
        }

        public Form2(IConferenceRepository getConferenceRepository, ConferenceModel conference)
        {
            _getConferenceRepository = getConferenceRepository;
            model = conference;
            InitializeComponent();
        }

        public Form2(IConferenceRepository getConferenceRepository)
        {

            _getConferenceRepository = getConferenceRepository;
            InitializeComponent();
            LoadCountries();
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
            if (tabIndex < 5) 
            {
                tabControl1.TabPages[tabIndex].Enabled = false;
                tabIndex += 1;
                tabControl1.TabPages[tabIndex].Enabled = true;
                progressBar1.Value += 20;
            }
            tabControl1.SelectedIndex = tabIndex;
            lblBackCountry.Enabled = true;

            if(tabIndex == 5)
            {
                lblNextCountry.Text = "Save";
            }
        }
        //private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (tabControl1.SelectedTab.Enabled == false)
        //    {
        //        tabControl1.SelectedTab = tabPage1;
        //        MessageBox.Show("You don't have permission !!", "Meera Academy");
        //    }
        //}

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
    }
}
