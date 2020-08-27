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
            lblNationality.Text = speaker.DictionarySpeakerNationality.ToString();
            lblRating.Text = speaker.DictionarySpeakerRating.ToString();
            float rating = float.Parse(lblRating.Text);

            if (rating == 1 || rating < 2)
            {
                picBoxLike1.Image = Properties.Resources.icons8_facebook_like_48px;

            }
            else if (rating < 2 || rating == 2 || rating > 2 && rating < 3)
            {
                picBoxLike1.Image = Properties.Resources.icons8_facebook_like_48px;
                picBoxLike2.Image = Properties.Resources.icons8_facebook_like_48px;

            }
            else if (rating == 3 || rating > 3 && rating < 4)
            {
                picBoxLike1.Image = Properties.Resources.icons8_facebook_like_48px;
                picBoxLike2.Image = Properties.Resources.icons8_facebook_like_48px;
                picBoxLike3.Image = Properties.Resources.icons8_facebook_like_48px;

            }
            else if (rating == 4 || rating > 4 && rating < 5)
            {
                picBoxLike1.Image = Properties.Resources.icons8_facebook_like_48px;
                picBoxLike2.Image = Properties.Resources.icons8_facebook_like_48px;
                picBoxLike3.Image = Properties.Resources.icons8_facebook_like_48px;
                picBoxLike4.Image = Properties.Resources.icons8_facebook_like_48px;
            }
            else if ( rating == 5)
            {
                picBoxLike1.Image = Properties.Resources.icons8_facebook_like_48px;
                picBoxLike2.Image = Properties.Resources.icons8_facebook_like_48px;
                picBoxLike3.Image = Properties.Resources.icons8_facebook_like_48px;
                picBoxLike4.Image = Properties.Resources.icons8_facebook_like_48px;
                picBoxLike5.Image = Properties.Resources.icons8_facebook_like_48px;
            }
        }

        private void picBoxLike1_Click(object sender, EventArgs e)
        {
            
        }

        private void picBoxLike2_Click(object sender, EventArgs e)
        {

        }

    }
}
