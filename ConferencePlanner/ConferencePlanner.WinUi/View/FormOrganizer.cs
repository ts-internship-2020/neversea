using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.WinUi.Utilities;
using MimeKit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
//using Windows.Web.Http;

namespace ConferencePlanner.WinUi.View
{
    public partial class FormOrganizer : Form
    {
        private readonly IConferenceRepository _conferenceRepository;

        public List<ConferenceModel> conferenceModels;
        public string emailCopyFromMainForm;
        public int range = 0;
        public int step = 4;
        public int shown = 4;
        public int maxrange;

        public FormOrganizer(IConferenceRepository conferenceRepository, string emailCopy)
        {
            _conferenceRepository = conferenceRepository;
            emailCopyFromMainForm = emailCopy;
            InitializeComponent();

            /*DateTime now = DateTime.Now;
            dtpStart.Value = now.AddMonths(-1);
            dtpEnd.Value = now.AddMonths(1);*/

            
            List<ConferenceAttendanceModel> conferenceAttendances = new List<ConferenceAttendanceModel>();
            //WireUpOrganiser();


            LoadConferences();
        }

        private async void LoadConferences()
        { 
 
            string encodedEmail = HttpUtility.UrlEncode(emailCopyFromMainForm);
            DateTime _startDateStr = DateTime.Parse("01.01.1900 00:00:00");
            DateTime _endDateStr = DateTime.Parse("01.01.2100 00:00:00");
            var url = $"http://localhost:5000/api/Conference/all/organizer/{encodedEmail}?startDateStr={_startDateStr}&endDateStr={_endDateStr}";

            conferenceModels = await HttpClientOperations.GetOperation<ConferenceModel>(url);
            maxrange = conferenceModels.Count;
            dgvOrganiser.ColumnCount = 9;
            dgvOrganiser.Columns[0].Name = "Id";
            dgvOrganiser.Columns[1].Name = "Title";
            dgvOrganiser.Columns[2].Name = "StartDate";
            dgvOrganiser.Columns[3].Name = "EndDate";
            dgvOrganiser.Columns[4].Name = "Type";
            dgvOrganiser.Columns[5].Name = "Category";
            dgvOrganiser.Columns[6].Name = "Address";
            dgvOrganiser.Columns[7].Name = "Speaker";
            dgvOrganiser.Columns[8].Name = "LocationId";
            this.dgvOrganiser.Columns[0].Visible = false;
            this.dgvOrganiser.Columns[8].Visible = false;
            DataGridViewButtonColumn buttonEditColumn = new DataGridViewButtonColumn
            {   
                HeaderText = "Edit",
                Name = "buttonEditColumn",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            };
            dgvOrganiser.Columns.Add(buttonEditColumn);
            WireUpOrganiser();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadTheme();
        }

        private void WireUpOrganiser()
        {
            dgvOrganiser.Rows.Clear();
            //comboBoxPagesNumber.SelectedIndex = 0;

            for (int i = range; i < step; i++)
            {
                if (i >= maxrange)
                {
                    Console.WriteLine("breaked");
                    break;
                }
                else
                {
                    dgvOrganiser.Rows.Add(conferenceModels[i].ConferenceId,
                                conferenceModels[i].ConferenceName,
                                conferenceModels[i].ConferenceStartDate,
                                conferenceModels[i].ConferenceEndDate,
                                conferenceModels[i].ConferenceType,
                                conferenceModels[i].ConferenceCategory,
                                conferenceModels[i].ConferenceLocation,
                                conferenceModels[i].ConferenceMainSpeaker,
                                conferenceModels[i].ConferenceLocationId);
                }

                if (conferenceModels.Count <= (int)comboBoxPagesNumber.SelectedItem)
                {
                    btnNext.Enabled = false;
                }
                else if (step < maxrange)
                {
                    btnNext.Enabled = true;
                }
            }
            //dgvOrganiser.Rows[0].Cells[0].Selected = false;
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }


        //private async void dtpStart_ValueChanged_1(object sender, EventArgs e)
        //{
        //    dgvOrganiser.Rows.Clear();

        //    DateTime _startDate = dtpStart.Value;
        //    DateTime _endDate = dtpEnd.Value;
        //    string encodedEmail = HttpUtility.UrlEncode(emailCopyFromMainForm);
        //    Console.WriteLine(encodedEmail);
        //    var url = $"http://localhost:5000/api/Conference/all/organizer/{encodedEmail}?startDateStr={_startDate}&endDateStr={_endDate}";

        //    //conferenceModels = await HttpClientOperations.GetOperation<ConferenceModel>(url);
        //    conferenceModels = _conferenceRepository.GetConferenceBetweenDates(emailCopyFromMainForm, _startDate, _endDate);
        //    maxrange = conferenceModels.Count;
        //    range = 0;
        //    btnPrevious.Enabled = false;
        //    step = (int)comboBoxPagesNumber.SelectedItem;
        //    shown = (int)comboBoxPagesNumber.SelectedItem;
        //    btnPrevious.Enabled = false;
        //    Console.WriteLine("Lista dintre " + _startDate.ToString() + " si " + _endDate.ToString() + " are lungimea " + conferenceModels.Count);
        //    WireUpOrganiser();
        //}
        private void comboBoxPagesNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvOrganiser.Rows.Clear();
            range = 0;
            step = (int)comboBoxPagesNumber.SelectedItem;
            shown = (int)comboBoxPagesNumber.SelectedItem;
            btnPrevious.Enabled = false;

            WireUpOrganiser();
        }

        private void dgvOrganiser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("Test");
            if (dgvOrganiser.Columns[e.ColumnIndex].Name == "buttonEditColumn")
            {
                ConferenceModel updatedConference = new ConferenceModel();
                dgvOrganiser.CurrentRow.Selected = true;
                updatedConference.ConferenceId = Convert.ToInt32(value: dgvOrganiser.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString());
                updatedConference.ConferenceName = dgvOrganiser.Rows[e.RowIndex].Cells["Title"].FormattedValue.ToString();
                updatedConference.ConferenceStartDate = Convert.ToDateTime(dgvOrganiser.Rows[e.RowIndex].Cells["StartDate"].FormattedValue.ToString());
                updatedConference.ConferenceEndDate = Convert.ToDateTime(dgvOrganiser.Rows[e.RowIndex].Cells["EndDate"].FormattedValue.ToString());
                updatedConference.ConferenceType = dgvOrganiser.Rows[e.RowIndex].Cells["Type"].FormattedValue.ToString();
                updatedConference.ConferenceCategory = dgvOrganiser.Rows[e.RowIndex].Cells["Category"].FormattedValue.ToString();
                updatedConference.ConferenceLocation = dgvOrganiser.Rows[e.RowIndex].Cells["Address"].FormattedValue.ToString();
                updatedConference.ConferenceMainSpeaker = dgvOrganiser.Rows[e.RowIndex].Cells["Speaker"].FormattedValue.ToString();
                updatedConference.ConferenceLocationId = Convert.ToInt32(value: dgvOrganiser.Rows[e.RowIndex].Cells["LocationId"].FormattedValue.ToString());
                FormEditConference editForm = new FormEditConference(updatedConference);
                editForm.TopLevel = false;
                editForm.Dock = DockStyle.Fill;
                this.Controls.Add(editForm);
                this.Tag = editForm;
                editForm.BringToFront();
                editForm.Show();
                Console.WriteLine("I m in edit mode");
            }
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            dgvOrganiser.Rows.Clear();
            range = step;
            step += shown;
            btnPrevious.Enabled = true;
            if (step >= maxrange)
            {
                btnNext.Enabled = false;
            }
            Console.WriteLine("Am dat Next: range=" + range + " si step=" + step);

            WireUpOrganiser();
        }

        private void btnPrevious_Click_1(object sender, EventArgs e)
        {
            dgvOrganiser.Rows.Clear();
            step = range;
            range -= shown;
            btnPrevious.Enabled = true;
            if (range == 0)
            {
                btnPrevious.Enabled = false;
            }
            Console.WriteLine("Am dat Back: range=" + range + " si step=" + step);

            WireUpOrganiser();
        }

        private void comboBoxPagesNumber_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            dgvOrganiser.Rows.Clear();
            range = 0;
            step = (int)comboBoxPagesNumber.SelectedItem;
            shown = (int)comboBoxPagesNumber.SelectedItem;
            btnPrevious.Enabled = false;

            WireUpOrganiser();
        }

        private async void dtpEnd_ValueChanged_1(object sender, EventArgs e)
        {
            DateTime _startDate = dtpStart.Value;
            DateTime _endDate = dtpEnd.Value;
            dgvOrganiser.Rows.Clear();
            string encodedEmail = HttpUtility.UrlEncode(emailCopyFromMainForm);
          
            var url = $"http://localhost:5000/api/Conference/all/organizer/{encodedEmail}?startDateStr={_startDate}&endDateStr={_endDate}";

            conferenceModels = await HttpClientOperations.GetOperation<ConferenceModel>(url);
            //conferenceModels = _conferenceRepository.GetConferenceBetweenDates(encodedEmail, _startDate, _endDate);
            maxrange = conferenceModels.Count;
            range = 0;
            btnPrevious.Enabled = false;
            step = (int)comboBoxPagesNumber.SelectedItem;
            shown = (int)comboBoxPagesNumber.SelectedItem;
            btnNext.Enabled = false;
            Console.WriteLine("Lista dintre " + _startDate.ToString() + " si " + _endDate.ToString() + " are lungimea " + conferenceModels.Count);
            WireUpOrganiser();
        }
        private void dgvOrganiser_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvOrganiser.ClearSelection();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("test");
        }

        private async void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            dgvOrganiser.Rows.Clear();

            DateTime _startDate = dtpStart.Value;
            DateTime _endDate = dtpEnd.Value;
            string encodedEmail = HttpUtility.UrlEncode(emailCopyFromMainForm);
            var url = $"http://localhost:5000/api/Conference/all/organizer/{encodedEmail}?startDateStr={_startDate}&endDateStr={_endDate}";
            Console.WriteLine(encodedEmail);
            conferenceModels = await HttpClientOperations.GetOperation<ConferenceModel>(url);
            //conferenceModels = _conferenceRepository.GetConferenceBetweenDates(emailCopyFromMainForm, _startDate, _endDate);
            maxrange = conferenceModels.Count;
            range = 0;
            btnPrevious.Enabled = false;
            step = (int)comboBoxPagesNumber.SelectedItem;
            shown = (int)comboBoxPagesNumber.SelectedItem;
            btnPrevious.Enabled = false;
            Console.WriteLine("Lista dintre " + _startDate.ToString() + " si " + _endDate.ToString() + " are lungimea " + conferenceModels.Count);
            WireUpOrganiser();
        }
    }
}

