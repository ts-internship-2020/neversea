using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi.View
{
    public partial class FormAddConferenceSpeaker : Form
    {
        public FormAddConferenceSpeaker()
        {
            InitializeComponent();
        }

        private void dgvSpeakers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSpeakers.ClearSelection();
        }
    }
}
