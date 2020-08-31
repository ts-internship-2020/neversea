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
        public FormAddConferenceSpeaker(IConferenceSpeakerRepository _conferenceSpeakerRepository)
        {
            conferenceSpeakerRepository = _conferenceSpeakerRepository;
            InitializeComponent();
            LoadSpeakers();
        }
        private void LoadSpeakers()
        {
            List<SpeakerModel> speakers = new List<SpeakerModel>();
            speakers = conferenceSpeakerRepository.GetConferenceSpeakers();
            WireUpSpeakers(speakers);
        }

        private void LoadSpeakers(string keyword)
        {
            List<SpeakerModel> speakers = new List<SpeakerModel>();
            speakers = conferenceSpeakerRepository.GetConferenceSpeakers(keyword);
            WireUpSpeakers(speakers);
        }
        private void WireUpSpeakers(List<SpeakerModel> speakers)
        {
            dgvSpeakers.Rows.Clear();
            dgvSpeakers.ColumnCount = 5;
            dgvSpeakers.Columns[0].Name = "Id";
            dgvSpeakers.Columns[1].Name = "Name";
            dgvSpeakers.Columns[2].Name = "Nationality";
            dgvSpeakers.Columns[3].Name = "Rating";
            dgvSpeakers.Columns[4].Name = "Image";
            this.dgvSpeakers.Columns[0].Visible = false;
            this.dgvSpeakers.Columns[0].Visible = false;
            for (int i = 0; i < speakers.Count; i++)
            {
                //if (i >= maxrange)
                //{
                //    Console.WriteLine("breaked");
                //    break;
                //}
                //else
                //{
                dgvSpeakers.Rows.Add(speakers[i].DictionarySpeakerId,
                            speakers[i].DictionarySpeakerName,
                            speakers[i].DictionarySpeakerNationality,
                            speakers[i].DictionarySpeakerRating,
                            speakers[i].DictionarySpeakerImage);
                //}


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
            string keyword = txtSearch.Text;
            LoadSpeakers(keyword);
        }

        private void dgvSpeakers_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int speakerId;
            string speakerName = "";
            string speakerNationality = "";
            float speakerRating;
            string speakerImage = "";

            try
            {
                if (dgvSpeakers.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    speakerId = Convert.ToInt32(dgvSpeakers.Rows[e.RowIndex].Cells[0].Value.ToString());
                    speakerName = dgvSpeakers.Rows[e.RowIndex].Cells[1].Value.ToString();
                    speakerNationality = dgvSpeakers.Rows[e.RowIndex].Cells[2].Value.ToString();
                    speakerRating = float.Parse(dgvSpeakers.Rows[e.RowIndex].Cells[3].Value.ToString());
                    speakerImage = dgvSpeakers.Rows[e.RowIndex].Cells[4].Value.ToString();
                    conferenceSpeakerRepository.UpdateSpeaker(speakerId, speakerName, speakerNationality, speakerRating, speakerImage);
                }

                else
                {
                    speakerName = dgvSpeakers.Rows[e.RowIndex].Cells[1].Value == null ? "" : dgvSpeakers.Rows[e.RowIndex].Cells[1].Value.ToString();
                    speakerNationality = dgvSpeakers.Rows[e.RowIndex].Cells[2].Value == null ? "" : dgvSpeakers.Rows[e.RowIndex].Cells[2].Value.ToString();
                    speakerRating = dgvSpeakers.Rows[e.RowIndex].Cells[3].Value == null ? 0 : float.Parse(dgvSpeakers.Rows[e.RowIndex].Cells[3].Value.ToString());
                    speakerImage = dgvSpeakers.Rows[e.RowIndex].Cells[4].Value == null ? "" : dgvSpeakers.Rows[e.RowIndex].Cells[4].Value.ToString();


                    conferenceSpeakerRepository.InsertSpeaker(speakerName, speakerNationality, speakerRating, speakerImage);
                    dgvSpeakers.Rows.Clear();
                }

                LoadSpeakers();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSpeakers.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvSpeakers.SelectedRows[0].Index;
                int speakerId = Convert.ToInt32(dgvSpeakers[0, selectedIndex].Value);
                conferenceSpeakerRepository.DeleteSpeaker(speakerId);
                LoadSpeakers();
            }
        }
    }
}
