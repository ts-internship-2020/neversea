using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi
{

    public partial class FormSpeakerDetails : Form
    {
        private readonly IConferenceRepository _getConferenceRepository;
        public FormSpeakerDetails(IConferenceRepository getConferenceRepository)
        {

            _getConferenceRepository = getConferenceRepository;

            InitializeComponent();
        }
        public FormSpeakerDetails()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxName_TextChanged(object sender, EventArgs e)
        {
            _getConferenceRepository.SelectSpeakerDetail(1);
        }

    }
}
