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

        public int speakerId = 0;
        public FormAddConferenceSpeaker()
        {
            InitializeComponent();
        }

        private void dgvSpeakers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            speakerId = Convert.ToInt32(dgvSpeakers.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString());

        }

        private void FormAddConferenceSpeaker_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormAddConferenceGeneral.conference.ConferenceMainSpeaker = speakerId.ToString();

        }
    }
}
