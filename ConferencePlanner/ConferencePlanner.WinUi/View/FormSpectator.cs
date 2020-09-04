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
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.Web.Http;
using HttpClient = System.Net.Http.HttpClient;
using HttpResponseMessage = System.Net.Http.HttpResponseMessage;
using HttpStatusCode = System.Net.HttpStatusCode;

namespace ConferencePlanner.WinUi.View
{
    public partial class FormSpectator : Form
    {
        private Form activeForm;
        private readonly IConferenceRepository conferenceRepository;
        public string emailCopyFromMainForm;
        private readonly IConferenceAttendanceRepository conferenceAttendanceRepository;
        List<ConferenceModel> conferenceModels = new List<ConferenceModel>();
        List<ConferenceAttendanceModel> conferenceAttendances = new List<ConferenceAttendanceModel>();


        public FormSpectator(IConferenceRepository _conferenceRepository, string emailCopy, IConferenceAttendanceRepository _conferenceAttendanceRepository)
        {
            conferenceRepository = _conferenceRepository;
            conferenceAttendanceRepository = _conferenceAttendanceRepository;
            emailCopyFromMainForm = emailCopy;

            InitializeComponent();

        }


        private async void WireUpSpectator(DateTime _startDate, DateTime _endDate)
        {

            dgvSpectator.Rows.Clear();
            dgvSpectator.Columns.Clear();


            string startDateStr = _startDate.ToString("yyyy-MM-dd");
            string endDateStr = _endDate.ToString("yyyy-MM-dd");

            string encodedEmail = HttpUtility.UrlEncode(emailCopyFromMainForm);



            var urlGetConference = $"http://localhost:2794/api/Conference/all/spectator/{encodedEmail}?startDateStr={startDateStr}&endDateStr={endDateStr}";

            conferenceModels = await HttpClientOperations.GetOperation<ConferenceModel>(urlGetConference);

            var urlGetConferenceAttendance = "http://localhost:2794/api/ConferenceAttendance/GetConferenceAttendance";
            conferenceAttendances = await HttpClientOperations.GetOperation<ConferenceAttendanceModel>(urlGetConferenceAttendance);

            dgvSpectator.DataSource = null;
            dgvSpectator.DataSource = conferenceModels;

            this.dgvSpectator.Columns[0].HeaderText = "Title";
            this.dgvSpectator.Columns[1].HeaderText = "Id";
            this.dgvSpectator.Columns[2].HeaderText = "Starts";
            this.dgvSpectator.Columns[3].HeaderText = "Ends";
            this.dgvSpectator.Columns[4].HeaderText = "Type";
            this.dgvSpectator.Columns[5].HeaderText = "Category";
            this.dgvSpectator.Columns[6].HeaderText = "Speaker";
            this.dgvSpectator.Columns[7].HeaderText = "Location";
            this.dgvSpectator.Columns[8].HeaderText = "SpeakerId";
            this.dgvSpectator.Columns[9].HeaderText = "OrganiserEmail";
            this.dgvSpectator.Columns[7].Visible = false;
            this.dgvSpectator.Columns[9].Visible = false;
            this.dgvSpectator.Columns[1].Visible = false;
            this.dgvSpectator.Columns[8].Visible = false;
            this.dgvSpectator.Columns[6].Name = "conferenceMainSpeaker";
            this.dgvSpectator.Columns[2].Name = "StartDate";
            this.dgvSpectator.Columns[3].Name = "EndDate";

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


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadTheme();
        }

        private async void FormSpectator_Load(object sender, EventArgs e)
        {
            dtpStart.Value = DateTime.Now.AddMonths(-1);
            dtpEnd.Value = DateTime.Now.AddMonths(1);

            WireUpSpectator(dtpStart.Value, dtpEnd.Value);


            btnPrevious.Visible = false;
            foreach (DataGridViewRow row in dgvSpectator.Rows)
            {
                int confId = Convert.ToInt32(row.Cells["conferenceId"].FormattedValue.ToString());

                if (!(await IsParticipating(emailCopyFromMainForm, confId)))
                    row.Cells["buttonJoinColumn"].Style.BackColor = System.Drawing.Color.Khaki;
            }
        }

        private async Task<bool> IsParticipating(string spectatorEmail, int confId)
        {
            HttpClient httpClient = HttpClientFactory.Create();
            var url = $"http://localhost:2794/api/ConferenceAttendance/GetIsParticipating?email={spectatorEmail}&id={confId}";
            HttpResponseMessage res = await httpClient.GetAsync(url);
            bool isParticipant = false;

            if (res.StatusCode == HttpStatusCode.OK)
            {
                var content = res.Content;
                var data = await content.ReadAsStringAsync();
                isParticipant = Convert.ToBoolean(JsonConvert.DeserializeObject(data));
                
            }

            return isParticipant;
        }



        private void dtpStart_CloseUp(Object sender, EventArgs e)
        {
            dgvSpectator.DataSource = null;
            dtpEnd.MinDate = dtpStart.Value;
            DateTime startDate = dtpStart.Value;
            DateTime endDate = dtpEnd.Value;

            WireUpSpectator(startDate, endDate);
        }

        private void dtpEnd_CloseUp(Object sender, EventArgs e)
        {
            dgvSpectator.DataSource = null;
            DateTime startDate = dtpStart.Value;
            DateTime endDate = dtpEnd.Value;

            WireUpSpectator(startDate, endDate);
        }


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

        private void InsertParticipant(int _conferenceId, string _spectatorEmail, int _participantStatusCode)
        {
            var url = "http://localhost:2794/Participant/new";

            HttpClientOperations.PostOperation<Object>(url, new {conferenceId = _conferenceId, spectatorEmail = _spectatorEmail, participantStatusCode = _participantStatusCode});
        }

        private async Task<bool> IsWithdrawn(string spectatorEmail, int conferenceId)
        {
            HttpClient httpClient = HttpClientFactory.Create();
            var url = $"http://localhost:2794/api/ConferenceAttendance/GetIsWithdrawn?email={spectatorEmail}&id={conferenceId}";
            HttpResponseMessage res = await httpClient.GetAsync(url);
            bool isWithdrawn = false;

            if (res.StatusCode == HttpStatusCode.OK)
            {
                var content = res.Content;
                var data = await content.ReadAsStringAsync();
                isWithdrawn = Convert.ToBoolean(JsonConvert.DeserializeObject(data));
            }

            return isWithdrawn;
        }

        private async void dgvSpectator_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
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
                        if (await IsParticipating(emailCopyFromMainForm, confId))
                        {
                            MessageBox.Show("Attending Already");
                        }
                        else
                        {
                            dgvSpectator.CurrentRow.Selected = true;
                            InsertParticipant(confId, emailCopyFromMainForm, 1);
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
                    var url = $"http://localhost:2794/api/Conference/withdraw";

                    HttpClientOperations.PutOperation(url, new ConferenceAttendanceModel { ParticipantEmailAddress = emailCopyFromMainForm, ConferenceId = confId });

                    dgvSpectator.CurrentRow.Selected = true;

                    if (await IsWithdrawn(emailCopyFromMainForm, confId))
                    {
                        MessageBox.Show("User has already withdrawn");
                    }
                    else
                    {
                        dgvSpectator.CurrentRow.Selected = true;
                        HttpClientOperations.PutOperation(url, new ConferenceAttendanceModel { ParticipantEmailAddress = emailCopyFromMainForm, ConferenceId = confId });
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
