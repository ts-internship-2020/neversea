﻿using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ado.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi
{
    public partial class MainForm : Form
    {
        private readonly IConferenceRepository conferenceRepository;

        public MainForm(IConferenceRepository ConferenceRepository)
        {
            conferenceRepository = ConferenceRepository;

            InitializeComponent();

        }
        public void Alert(string msg)
        {
            FormAlert frm = new FormAlert();
            frm.showAlert(msg);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            string pattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            if ((chkb_email.Checked) && (Regex.IsMatch(tb_email.Text, pattern)))
            {
                Properties.Settings.Default.Email = tb_email.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Email = "";
                Properties.Settings.Default.Save();
            }
            HomePage homePage = new HomePage(conferenceRepository);
            if (Regex.IsMatch(tb_email.Text, pattern))
            {
                string emailCopy = this.tb_email.Text;
                HomePage homepage = new HomePage(emailCopy);
                homePage.Show();
                this.Hide();
            }
            if (tb_email.Text=="")
            {
                this.Alert("Email is empty");
            }
           
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Email != string.Empty)
            {
                tb_email.Text = Properties.Settings.Default.Email;
            }
            this.tb_email.Enter += new EventHandler(tb_email_Enter);
            this.tb_email.Leave += new EventHandler(tb_email_Leave);
            tb_email_SetText();
        }

        private void tb_email_Leave(object sender, EventArgs e)
        {
            string pattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            if (Regex.IsMatch(tb_email.Text, pattern))
            {
                errorProvider2.Clear();
            }
            else
            {
                errorProvider2.SetError(this.tb_email, " Please provide a valid Mail Address");
                return;
            }
            {
                if (tb_email.Text.Trim() == "")
                    tb_email_SetText();
            }
        }

        protected void tb_email_SetText()
        {
            this.tb_email.Text = "Type an email...";
            tb_email.ForeColor = Color.Gray;
        }

        private void tb_email_Enter(object sender, EventArgs e)
        {
            if (tb_email.ForeColor == Color.Black)
                return;
            tb_email.Text = "";
            tb_email.ForeColor = Color.Black;

        }
    }
}
