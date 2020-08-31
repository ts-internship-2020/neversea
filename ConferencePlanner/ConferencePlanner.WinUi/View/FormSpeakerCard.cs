using ConferencePlanner.Abstraction.Model;
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
    public partial class FormSpeakerCard : Form
    {
        int speakerId;
        SpeakerModel speaker = new SpeakerModel();
        private readonly IConferenceRepository conferenceRepository;

        public FormSpeakerCard(IConferenceRepository _conferenceRepository, int speakerId)
        {
            speakerId = speakerId;
            conferenceRepository = _conferenceRepository;

            InitializeComponent();
        }

        private void FormSpeakerDetails_Load(object sender, EventArgs e)
        {

            speaker = conferenceRepository.getSelectSpeakerDetails(speakerId);
            lblName.Text = speaker.DictionarySpeakerName.ToString();
            lblNationality.Text = speaker.DictionarySpeakerNationality.ToString();
            pictureBoxSpeaker.LoadAsync(speaker.DictionarySpeakerImage.ToString());
            float rating = float.Parse(speaker.DictionarySpeakerRating.ToString());

            if (rating == 1 || rating < 2)
            {
                pictureBoxLike1.Image = Properties.Resources.icons8_facebook_like_48px;

            }
            else if (rating < 2 || rating == 2 || rating > 2 && rating < 3)
            {
                pictureBoxLike1.Image = Properties.Resources.icons8_facebook_like_48px;
                pictureBoxLike2.Image = Properties.Resources.icons8_facebook_like_48px;

            }
            else if (rating == 3 || rating > 3 && rating < 4)
            {
                pictureBoxLike1.Image = Properties.Resources.icons8_facebook_like_48px;
                pictureBoxLike2.Image = Properties.Resources.icons8_facebook_like_48px;
                pictureBoxLike3.Image = Properties.Resources.icons8_facebook_like_48px;

            }
            else if (rating == 4 || rating > 4 && rating < 5)
            {
                pictureBoxLike1.Image = Properties.Resources.icons8_facebook_like_48px;
                pictureBoxLike2.Image = Properties.Resources.icons8_facebook_like_48px;
                pictureBoxLike3.Image = Properties.Resources.icons8_facebook_like_48px;
                pictureBoxLike4.Image = Properties.Resources.icons8_facebook_like_48px;
            }
            else if (rating == 5)
            {
                pictureBoxLike1.Image = Properties.Resources.icons8_facebook_like_48px;
                pictureBoxLike2.Image = Properties.Resources.icons8_facebook_like_48px;
                pictureBoxLike3.Image = Properties.Resources.icons8_facebook_like_48px;
                pictureBoxLike4.Image = Properties.Resources.icons8_facebook_like_48px;
                pictureBoxLike5.Image = Properties.Resources.icons8_facebook_like_48px;
            }
        }
    }
}
