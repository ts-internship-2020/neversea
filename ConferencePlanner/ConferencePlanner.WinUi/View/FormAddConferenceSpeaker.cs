using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;

namespace ConferencePlanner.WinUi.View
{
    public partial class FormAddConferenceSpeaker : Form
    {
        private readonly IConferenceSpeakerRepository conferenceSpeakerRepository;
       

        public int speakerId = 0;
        List<SpeakerModel> speakers = new List<SpeakerModel>();
        public int range = 0;
        public int step = 4;
        public int shown = 4;
        public int maxrange;
        public FormAddConferenceSpeaker(IConferenceSpeakerRepository _conferenceSpeakerRepository)
        {
            conferenceSpeakerRepository = _conferenceSpeakerRepository;
            InitializeComponent();
            LoadSpeakers();
        }
        private void LoadSpeakers()
        {
            speakers = conferenceSpeakerRepository.GetConferenceSpeakers();
            dgvSpeakers.ColumnCount = 5;
            dgvSpeakers.Columns[0].Name = "Id";
            dgvSpeakers.Columns[1].Name = "Name";
            dgvSpeakers.Columns[2].Name = "Nationality";
            dgvSpeakers.Columns[3].Name = "Rating";
            dgvSpeakers.Columns[4].Name = "Image";
            this.dgvSpeakers.Columns[0].Visible = false;
            maxrange = speakers.Count;
            WireUpSpeakers();
        }

        private void LoadSpeakers(string keyword)
        {
            List<SpeakerModel> speakers = new List<SpeakerModel>();
            speakers = conferenceSpeakerRepository.GetConferenceSpeakers(keyword);
            maxrange = speakers.Count;
            WireUpSpeakers();
        }
        private void WireUpSpeakers()
        {
            dgvSpeakers.Rows.Clear();
            for (int i = range; i < step; i++)
            {
                if (i >= maxrange)
                {
                    Console.WriteLine("breaked");
                    break;
                }
                else
                {
                    dgvSpeakers.Rows.Add(speakers[i].DictionarySpeakerId,
                            speakers[i].DictionarySpeakerName,
                            speakers[i].DictionarySpeakerNationality,
                            speakers[i].DictionarySpeakerRating,
                            speakers[i].DictionarySpeakerImage);
                }
                if (speakers.Count <= (int)comboBoxPagesNumber.SelectedItem)
                {
                    button3.Enabled = false;
                }
                else if (step < maxrange)
                {
                    button3.Enabled = true;
                }
            }
        }
        private void dgvSpeakers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSpeakers.ClearSelection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            range = 0;
            btnPrevious.Visible = false;
            step = (int)comboBoxPagesNumber.SelectedItem;
            shown = (int)comboBoxPagesNumber.SelectedItem;
            string keyword = txtSearch.Text;
            LoadSpeakers(keyword);
        }

        private void dgvSpeakers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            speakerId = Convert.ToInt32(dgvSpeakers.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString());

        }

        private void FormAddConferenceSpeaker_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormAddConferenceGeneral.conference.ConferenceMainSpeaker = speakerId.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dgvSpeakers.Rows.Clear();
            range = step;
            step += shown;
            btnPrevious.Visible = true;
            if (step >= maxrange)
            {
                button3.Enabled = false;
            }
            Console.WriteLine("Am dat Next: range=" + range + " si step=" + step);
            WireUpSpeakers();

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            dgvSpeakers.Rows.Clear();
            step = range;
            range -= shown;
            btnPrevious.Visible = true;
            if (range == 0)
            {
                btnPrevious.Visible = false;
            }
            Console.WriteLine("Am dat Back: range=" + range + " si step=" + step);
            WireUpSpeakers();
        }

        private void comboBoxPagesNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvSpeakers.Rows.Clear();
            range = 0;
            step = (int)comboBoxPagesNumber.SelectedItem;
            shown = (int)comboBoxPagesNumber.SelectedItem;
            btnPrevious.Visible = false;
            WireUpSpeakers();
        }
    }
}
