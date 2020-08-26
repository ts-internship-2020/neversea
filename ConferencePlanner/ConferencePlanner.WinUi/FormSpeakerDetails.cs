using ConferencePlanner.Abstraction.Model;
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
        int SpeakerId;
        SpeakerModel speaker = new SpeakerModel();
        private readonly IConferenceRepository _getConferenceRepository;
        public FormSpeakerDetails(IConferenceRepository getConferenceRepository, int speakerId)
        {
            SpeakerId = speakerId;
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

        private void FormSpeakerDetails_Load(object sender, EventArgs e)
        {

            speaker = _getConferenceRepository.getSelectSpeakerDetails(SpeakerId);
            lblName.Text = speaker.DictionarySpeakerName.ToString();
            //lblNationality.Text = speaker.DictionarySpeakerNationality.ToString();
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }
    }
}
