using BarcodeLib;
using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.WinUi.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.Web.Http;

namespace ConferencePlanner.WinUi.View
{
    public partial class FormSpectator : Form
    {
        private Form activeForm;
        private readonly IConferenceRepository conferenceRepository;
        public string emailCopyFromMainForm;
        private readonly IConferenceAttendanceRepository conferenceAttendanceRepository;


        public FormSpectator(IConferenceRepository _conferenceRepository, string emailCopy, IConferenceAttendanceRepository _conferenceAttendanceRepository)
        {
            conferenceRepository = _conferenceRepository;
            conferenceAttendanceRepository = _conferenceAttendanceRepository;
            emailCopyFromMainForm = emailCopy;

            InitializeComponent();

            DateTime now = DateTime.Now;
            dtpStart.Value = now.AddMonths(-1);
            dtpEnd.Value = now.AddMonths(1);

            WireUpSpectator(dtpStart.Value, dtpEnd.Value);

            btnPrevious.Visible = false;
            foreach (DataGridViewRow row in dgvSpectator.Rows)
            {
                int confId = Convert.ToInt32(row.Cells["conferenceId"].FormattedValue.ToString());

                if (conferenceAttendanceRepository.isParticipating(emailCopyFromMainForm, confId) == false)
                    row.Cells["buttonJoinColumn"].Style.BackColor = System.Drawing.Color.Khaki;
            }


        }

        private async Task WireUpSpectator(DateTime _startDate, DateTime _endDate)
        {
            btnNext.Visible = false;
            dgvSpectator.Rows.Clear();
            dgvSpectator.Columns.Clear();

            List<ConferenceModel> conferences = new List<ConferenceModel>();
            List<ConferenceAttendanceModel> conferenceAttendances = new List<ConferenceAttendanceModel>();

            var urlGetConference = $"http://localhost:2794/api/Conference/all/{emailCopyFromMainForm}?startDate={_startDate}&endDate={_endDate}";
            conferences = await HttpClientOperations.GetOperation<ConferenceModel>(urlGetConference);

            var urlGetConferenceAttendance = "http://localhost:2794/api/ConferenceAttendance/GetConferenceAttendance";
            conferenceAttendances = await HttpClientOperations.GetOperation<ConferenceAttendanceModel>(urlGetConferenceAttendance);

            //conferenceAttendances = conferenceAttendanceRepository.GetConferenceAttendance();
            //conferences = conferenceRepository.GetConference(emailCopyFromMainForm, startDate, endDate, conferenceAttendances);

            dgvSpectator.DataSource = null;
            dgvSpectator.DataSource = conferences;

            dgvSpectator.Columns[0].HeaderText = "Title";
            dgvSpectator.Columns[1].HeaderText = "Id";
            dgvSpectator.Columns[2].HeaderText = "Starts";
            dgvSpectator.Columns[3].HeaderText = "Ends";
            dgvSpectator.Columns[4].HeaderText = "Type";
            dgvSpectator.Columns[5].HeaderText = "Category";
            dgvSpectator.Columns[6].HeaderText = "Speaker";
            dgvSpectator.Columns[7].HeaderText = "Location";
            dgvSpectator.Columns[8].HeaderText = "SpeakerId";
            dgvSpectator.Columns[9].HeaderText = "OrganiserEmail";

            this.dgvSpectator.Columns[7].Visible = false;
            this.dgvSpectator.Columns[9].Visible = false;
            this.dgvSpectator.Columns[1].Visible = false;
            this.dgvSpectator.Columns[8].Visible = false;
            this.dgvSpectator.Columns[6].Name = "conferenceMainSpeaker";
            dgvSpectator.Columns[2].Name = "StartDate";
            dgvSpectator.Columns[3].Name = "EndDate";

            // Image img = Properties.Resources.icons8_cancel_32px;
            Image img2 = Properties.Resources.icons8_add_user_group_man_man_20;
            DataGridViewImageColumn buttonJoinColumn = new DataGridViewImageColumn
            {
                HeaderText = "Join",
                Name = "buttonJoinColumn",
                ToolTipText = "Join Conference",
                Image = img2,
                Description = "Press to Join"



            };

            comboBoxPagesNumber.SelectedIndex = 0;


            dgvSpectator.Columns.Add(buttonJoinColumn);

            DataGridViewImageColumn buttonAttendColumn = new DataGridViewImageColumn
            {
                HeaderText = "Attend",
                Name = "buttonAttendColumn",
                ToolTipText = "Attend Conference",
                Image = Properties.Resources.icons8_event_accepted_20,
                Description = "Press to Attend"


            };


            dgvSpectator.Columns.Add(buttonAttendColumn);


            DataGridViewImageColumn buttonWithdrawColumn = new DataGridViewImageColumn
            {
                HeaderText = "Withdraw",
                Name = "buttonWithdrawColumn",
                ToolTipText = "Withdraw from conference",
                DividerWidth = 0,
                Image = Properties.Resources.icons8_xbox_x_20,
                Description = "Press to Withdraw"

            };

            dgvSpectator.Columns.Add(buttonWithdrawColumn);


        }

        /*private void WireUpSpectator(DateTime startDate, DateTime endDate)
        {
            btnNext.Visible = false;
            dgvSpectator.Rows.Clear();
            dgvSpectator.Columns.Clear();

            List<ConferenceModel> conferences = new List<ConferenceModel>();
            List<ConferenceAttendanceModel> conferenceAttendances = new List<ConferenceAttendanceModel>();

            conferenceAttendances = conferenceAttendanceRepository.GetConferenceAttendance();


            conferences = conferenceRepository.GetConference(emailCopyFromMainForm, startDate, endDate, conferenceAttendances);

            dgvSpectator.DataSource = null;
            dgvSpectator.DataSource = conferences;

            dgvSpectator.Columns[0].HeaderText = "Title";
            dgvSpectator.Columns[1].HeaderText = "Id";
            dgvSpectator.Columns[2].HeaderText = "Starts";
            dgvSpectator.Columns[3].HeaderText = "Ends";
            dgvSpectator.Columns[4].HeaderText = "Type";
            dgvSpectator.Columns[5].HeaderText = "Category";
            dgvSpectator.Columns[6].HeaderText = "Speaker";
            dgvSpectator.Columns[7].HeaderText = "Location";
            dgvSpectator.Columns[8].HeaderText = "SpeakerId";
            dgvSpectator.Columns[9].HeaderText = "OrganiserEmail";

            this.dgvSpectator.Columns[7].Visible = false;
            this.dgvSpectator.Columns[9].Visible = false;
            this.dgvSpectator.Columns[1].Visible = false;
            this.dgvSpectator.Columns[8].Visible = false;
            this.dgvSpectator.Columns[6].Name = "conferenceMainSpeaker";
            dgvSpectator.Columns[2].Name = "StartDate";
            dgvSpectator.Columns[3].Name = "EndDate";

            // Image img = Properties.Resources.icons8_cancel_32px;
            Image img2 = Properties.Resources.icons8_add_user_group_man_man_20;
            DataGridViewImageColumn buttonJoinColumn = new DataGridViewImageColumn
            {
                HeaderText = "Join",
                Name = "buttonJoinColumn",
                ToolTipText = "Join Conference",
                Image = img2,
                Description = "Press to Join"



            };

            comboBoxPagesNumber.SelectedIndex = 0;


            dgvSpectator.Columns.Add(buttonJoinColumn);

            DataGridViewImageColumn buttonAttendColumn = new DataGridViewImageColumn
            {
                HeaderText = "Attend",
                Name = "buttonAttendColumn",
                ToolTipText = "Attend Conference",
                Image = Properties.Resources.icons8_event_accepted_20,
                Description = "Press to Attend"


            };


            dgvSpectator.Columns.Add(buttonAttendColumn);


            DataGridViewImageColumn buttonWithdrawColumn = new DataGridViewImageColumn
            {
                HeaderText = "Withdraw",
                Name = "buttonWithdrawColumn",
                ToolTipText = "Withdraw from conference",
                DividerWidth = 0,
                Image = Properties.Resources.icons8_xbox_x_20,
                Description = "Press to Withdraw"

            };

            dgvSpectator.Columns.Add(buttonWithdrawColumn);

         
        }*/

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelSpeaker.Controls.Add(childForm);
            this.panelSpeaker.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    /*btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;*/
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadTheme();

        }

        private void FormSpectator_Load(object sender, EventArgs e)
        {

        }



        private async Task dtpStart_CloseUp(Object sender, EventArgs e)
        {
            dgvSpectator.DataSource = null;
            dtpEnd.MinDate = dtpStart.Value;
            DateTime startDate = dtpStart.Value;
            DateTime endDate = dtpEnd.Value;

            await WireUpSpectator(startDate, endDate);
        }

        private async Task dtpEnd_CloseUp(Object sender, EventArgs e)
        {
            dgvSpectator.DataSource = null;
            DateTime startDate = dtpStart.Value;
            DateTime endDate = dtpEnd.Value;

            await WireUpSpectator(startDate, endDate);
        }

        //private void dgvSpectator_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    string confName;
        //    int confId;
        //    if (e.RowIndex == -1) return;

        //    if (dgvSpectator.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
        //    {
        //        if (e.RowIndex == -1) return;

        //        if (dgvSpectator.Columns[e.ColumnIndex].Name == "conferenceMainSpeaker")
        //        {
        //            if (e.RowIndex == -1) return;

        //            string speakerName = dgvSpectator.Rows[e.RowIndex].Cells["conferenceMainSpeaker"].FormattedValue.ToString();
        //            int speakerId = Convert.ToInt32(value: dgvSpectator.Rows[e.RowIndex].Cells["SpeakerId"].FormattedValue.ToString());
        //            FormSpeakerDetails formSpeakerDetail = new FormSpeakerDetails(conferenceRepository, speakerId);
        //            formSpeakerDetail.Show();
        //        }
        //        else if (dgvSpectator.Columns[e.ColumnIndex].Name == "buttonJoinColumn")
        //        {
        //            DateTime sDate = Convert.ToDateTime(dgvSpectator.Rows[e.RowIndex].Cells["StartDate"].FormattedValue.ToString());
        //            if (e.RowIndex == -1) return;
        //            if (DateTime.Now.Minute >= sDate.AddMinutes(-5).Minute && DateTime.Now.Minute <= sDate.Minute)
        //            {
        //                WebViewForm webViewForm = new WebViewForm();
        //                webViewForm.Show();
        //            }
        //            else
        //            {
        //                MessageBox.Show("You can only join if there are 5 more minutes ");
        //            }
        //        }

        //        else if (dgvSpectator.Columns[e.ColumnIndex].Name == "buttonAttendColumn")
        //        {
        //            if (e.RowIndex == -1) return;
        //            else
        //            {

        //                confId = Convert.ToInt32(value: dgvSpectator.Rows[e.RowIndex].Cells["conferenceId"].FormattedValue.ToString());
        //                if (conferenceAttendanceRepository.isParticipating(emailCopyFromMainForm, confId) == true)
        //                {
        //                    MessageBox.Show("Attending Already");
        //                }
        //                else
        //                {


        //                    dgvSpectator.CurrentRow.Selected = true;
        //                    conferenceRepository.InsertParticipant(confId, emailCopyFromMainForm, 1);
        //                    string conferenceName = dgvSpectator.Rows[e.RowIndex].Cells["conferenceName"].FormattedValue.ToString();
        //                    sendEmail("User", emailCopyFromMainForm, conferenceName + " Participarion Code", conferenceName, 1);
        //                }
        //            }
        //        }


        //        else if (dgvSpectator.Columns[e.ColumnIndex].Name == "buttonWithdrawColumn")
        //        {
        //            dgvSpectator.CurrentRow.Selected = true;
        //            confId = Convert.ToInt32(value: dgvSpectator.Rows[e.RowIndex].Cells["conferenceId"].FormattedValue.ToString());
        //            conferenceRepository.ModifySpectatorStatusWithdraw(emailCopyFromMainForm, confId);



        //            if (conferenceAttendanceRepository.isWithdrawn(emailCopyFromMainForm, confId))
        //            {
        //                MessageBox.Show("User has already withdrawn");
        //            }
        //            else
        //            {
        //                dgvSpectator.CurrentRow.Selected = true;
        //                conferenceRepository.ModifySpectatorStatusWithdraw(emailCopyFromMainForm, confId);
        //            }
        //        }
        //    }
        //}

        //private void dgvSpectator_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        //{
        //    string confName;
        //    int confId;
        //    if (e.RowIndex == -1) return;

        //    if (dgvSpectator.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
        //    {
        //        if (e.RowIndex == -1) return;

        //        if (dgvSpectator.Columns[e.ColumnIndex].Name == "conferenceMainSpeaker")
        //        {
        //            if (e.RowIndex == -1) return;

        //            string speakerName = dgvSpectator.Rows[e.RowIndex].Cells["conferenceMainSpeaker"].FormattedValue.ToString();
        //            int speakerId = Convert.ToInt32(value: dgvSpectator.Rows[e.RowIndex].Cells["SpeakerId"].FormattedValue.ToString());
        //            FormSpeakerDetails formSpeakerDetails = new FormSpeakerDetails(conferenceRepository, speakerId);
        //            formSpeakerDetails.ShowSpeakerDetails();
        //            FormSpeakerDetails frmSpeakerDetails = new FormSpeakerDetails();
        //            frmSpeakerDetails.Focus();
        //        }
        //        else if (dgvSpectator.Columns[e.ColumnIndex].Name == "buttonJoinColumn")
        //        {
        //            if (e.RowIndex == -1) return;


        //            WebViewForm webViewForm = new WebViewForm();
        //            webViewForm.Show();

        //        }

        //        else if (dgvSpectator.Columns[e.ColumnIndex].Name == "buttonAttendColumn")
        //        {
        //            if (e.RowIndex == -1) return;

        //            dgvSpectator.CurrentRow.Selected = true;
        //            confId = Convert.ToInt32(value: dgvSpectator.Rows[e.RowIndex].Cells["conferenceId"].FormattedValue.ToString());
        //            //conferenceRepository.InsertParticipant(confId, emailCopyFromMainForm);
        //            //_getConferenceRepository.ModifySpectatorStatusAttend(confName, email);


        //        }

        //        else if (dgvSpectator.Columns[e.ColumnIndex].Name == "buttonWithdrawColumn")
        //        {
        //            dgvSpectator.CurrentRow.Selected = true;
        //            confId = Convert.ToInt32(value: dgvSpectator.Rows[e.RowIndex].Cells["conferenceId"].FormattedValue.ToString());
        //            conferenceRepository.ModifySpectatorStatusWithdraw(emailCopyFromMainForm, confId);
        //        }
        //    }
        //}

        private void dgvSpectator_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSpectator.ClearSelection();
        }

        private void sendEmail(string name, string email, string subject, string confName, long code)
        {



            var smtpClient = new System.Net.Mail.SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("ConferencePlannerNeverSea2020@gmail.com", "Neversea2020"),
                EnableSsl = true,
            };

            var mailMessage1 = new MailMessage
            {
                From = new MailAddress("ConferencePlannerNeverSea2020@gmail.com"),
                Subject = "subject",
                Body = "<h1>Hello there</h1>",
                IsBodyHtml = true,
            };




            Image img = generateBarcode(code);
            Attachment attachment1 = new Attachment(@"C:\NeverseaBugs\neversea-develop\neversea-develop\ConferencePlanner\Image.jpeg");
            mailMessage1.Attachments.Add(attachment1);
            mailMessage1.To.Add(email);
            smtpClient.Send(mailMessage1);

        }
        public Image generateBarcode(long code)
        {

            Barcode barcode = new Barcode();
            Color foreColor = Color.Black;
            Color backColor = Color.White;
            Image image = barcode.Encode(TYPE.CODE39, code.ToString(), foreColor, backColor, 900, 900);
            image.Save(@"C:\NeverseaBugs\neversea-develop\neversea-develop\ConferencePlanner\Image.jpeg", ImageFormat.Jpeg);

            return image;
        }

        private async Task InsertParticipantAsync(int conferenceId, string spectatorEmail, int participantStatusCode)
        {

        }

        private void dgvSpectator_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            string confName;
            int confId;
            if (e.RowIndex == -1) return;

            if (dgvSpectator.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                if (e.RowIndex == -1) return;

                if (dgvSpectator.Columns[e.ColumnIndex].Name == "conferenceMainSpeaker")
                {
                    if (e.RowIndex == -1) return;

                    string speakerName = dgvSpectator.Rows[e.RowIndex].Cells["conferenceMainSpeaker"].FormattedValue.ToString();
                    int speakerId = Convert.ToInt32(value: dgvSpectator.Rows[e.RowIndex].Cells["SpeakerId"].FormattedValue.ToString());
                    FormSpeakerDetails formSpeakerDetail = new FormSpeakerDetails(conferenceRepository, speakerId);
                    formSpeakerDetail.ShowSpeakerDetails();
                   FormSpeakerDetails frmSpeakerDetails = new FormSpeakerDetails();
                   frmSpeakerDetails.Focus();

                }
                else if (dgvSpectator.Columns[e.ColumnIndex].Name == "buttonJoinColumn")
                {
                    DateTime sDate = Convert.ToDateTime(dgvSpectator.Rows[e.RowIndex].Cells["StartDate"].FormattedValue.ToString());
                    if (e.RowIndex == -1) return;
                    dgvSpectator.CurrentRow.Selected = true;

                    if (DateTime.Now.Minute >= sDate.AddMinutes(-5).Minute && DateTime.Now.Minute <= sDate.Minute)
                    {
                        WebViewForm webViewForm = new WebViewForm();
                        webViewForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("You can only join if there are 5 more minutes ");
                    }
                }

                else if (dgvSpectator.Columns[e.ColumnIndex].Name == "buttonAttendColumn")
                {
                    if (e.RowIndex == -1) return;
                    else
                    {
                        dgvSpectator.CurrentRow.Selected = true;

                        confId = Convert.ToInt32(value: dgvSpectator.Rows[e.RowIndex].Cells["conferenceId"].FormattedValue.ToString());
                        if (conferenceAttendanceRepository.isParticipating(emailCopyFromMainForm, confId) == true)
                        {
                            MessageBox.Show("Attending Already");
                        }
                        else
                        {


                            dgvSpectator.CurrentRow.Selected = true;
                            conferenceRepository.InsertParticipant(confId, emailCopyFromMainForm, 1);
                            string conferenceName = dgvSpectator.Rows[e.RowIndex].Cells["conferenceName"].FormattedValue.ToString();
                            //sendEmail("User", emailCopyFromMainForm, conferenceName + " Participarion Code", conferenceName, 1);
                            dgvSpectator.Rows[e.RowIndex].Cells["buttonAttendColumn"].Style.BackColor = System.Drawing.Color.Khaki;
                        }
                    }
                }


                else if (dgvSpectator.Columns[e.ColumnIndex].Name == "buttonWithdrawColumn")
                {
                    dgvSpectator.CurrentRow.Selected = true;
                    confId = Convert.ToInt32(value: dgvSpectator.Rows[e.RowIndex].Cells["conferenceId"].FormattedValue.ToString());
                    conferenceRepository.ModifySpectatorStatusWithdraw(emailCopyFromMainForm, confId);

                    dgvSpectator.CurrentRow.Selected = true;


                    if (conferenceAttendanceRepository.isWithdrawn(emailCopyFromMainForm, confId))
                    {
                        MessageBox.Show("User has already withdrawn");
                    }
                    else
                    {
                        dgvSpectator.CurrentRow.Selected = true;
                        conferenceRepository.ModifySpectatorStatusWithdraw(emailCopyFromMainForm, confId);
                    }
                }
            }
        }

        //public async System.Threading.Tasks.Task<List<string>> getStrtingTestAsync(string path)
        //{
        //    List<string> listStrings = null;

        //    HttpResponseMessage msg = await httpClient.GetAsync(path);

        //    if (msg.IsSuccessStatusCode)
        //    {
        //        listStrings = await msg.Content.ReadAsStringAsync<List<string>>();
        //    }

        //    return listStrings;
        //}

    }
}
