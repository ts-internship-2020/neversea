using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
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

    
        private void FormSpeakerDetails_Load(object sender, EventArgs e)
        {
            
            speaker = _getConferenceRepository.getSelectSpeakerDetails(SpeakerId);
            lblName.Text = speaker.DictionarySpeakerName.ToString();
            lblNationality.Text = speaker.DictionarySpeakerNationality.ToString();
            lblRating.Text = speaker.DictionarySpeakerRating.ToString();

            picBoxSpeaker.LoadAsync(speaker.DictionarySpeakerImage.ToString());
            float rating = float.Parse(lblRating.Text);

            if ( rating < 2)
            {
                picBoxLike1.Image = Properties.Resources.icons8_facebook_like_48px;

            }
            else if (rating >= 2 && rating < 3)
            {
                picBoxLike1.Image = Properties.Resources.icons8_facebook_like_48px;
                picBoxLike2.Image = Properties.Resources.icons8_facebook_like_48px;

            }
            else if (rating >= 3 && rating < 4)
            {
                picBoxLike1.Image = Properties.Resources.icons8_facebook_like_48px;
                picBoxLike2.Image = Properties.Resources.icons8_facebook_like_48px;
                picBoxLike3.Image = Properties.Resources.icons8_facebook_like_48px;

            }
            else if (rating >= 4 && rating < 5)
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

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            action = enmAction.close;
        }
        public enum enmAction
        {
            wait,
            start,
            close
        }
        private FormSpeakerDetails.enmAction action;
        public int x { get; private set; }
        public int y { get; private set; }
        public void ShowSpeakerDetails()
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
         
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            this.Show();
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timer1.Interval = 5000;
                    action = enmAction.close;
                    break;

                case enmAction.start:
                    timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = enmAction.wait;
                        }
                    }
                    break;
                case enmAction.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        private void FormSpeakerDetails_KeyDown(object sender, KeyEventArgs e)
        {
            button2.PerformClick();
        }

    }
}
