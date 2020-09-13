using BarcodeLib;
using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
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

        public int range = 0;
        public int step = 4;
        public int shown = 4;
        public int maxRange;


        public FormSpectator(IConferenceRepository _conferenceRepository, string emailCopy, IConferenceAttendanceRepository _conferenceAttendanceRepository)
        {
            conferenceRepository = _conferenceRepository;
            conferenceAttendanceRepository = _conferenceAttendanceRepository;
            emailCopyFromMainForm = emailCopy;

            InitializeComponent();

            //boBoxPagesNumber.SelectedIndex = 0;
        }

        private DataGridViewImageColumn GetActionButton(string action)
        {
            DataGridViewImageColumn buttonToAdd = new DataGridViewImageColumn();
            buttonToAdd.DefaultCellStyle.NullValue = null; 
            //buttonToAdd.Image = 

            if (action == "join")
            {
                buttonToAdd.HeaderText = "Join";
                buttonToAdd.Name = "buttonJoinColumn";
                buttonToAdd.ToolTipText = "Join Conference";
                buttonToAdd.Image = Properties.Resources.icons8_add_user_group_man_man_20;
                buttonToAdd.Description = "Press to Join";
            }

            else if (action == "attend")
            {
                buttonToAdd.HeaderText = "Attend";
                buttonToAdd.Name = "buttonAttendColumn";
                buttonToAdd.ToolTipText = "Attend Conference";
                buttonToAdd.Image = Properties.Resources.icons8_event_accepted_20;
                buttonToAdd.Description = "Press to Attend";
            }

            else if (action == "withdraw")
            {
                buttonToAdd.HeaderText = "Withdraw";
                buttonToAdd.Name = "buttonWithdrawColumn";
                buttonToAdd.ToolTipText = "Withdraw from conference";
                buttonToAdd.DividerWidth = 0;
                buttonToAdd.Image = Properties.Resources.icons8_xbox_x_20;
                buttonToAdd.Description = "Press to Withdraw";
            }

            return buttonToAdd;
        }

        private void InsertPaginatedList(List<ConferenceModel> _conferenceModels, int _range, int _step, int _shown)
        {
            dgvSpectator.Rows.Clear();
            dgvSpectator.Columns.Clear();

            maxRange = _conferenceModels.Count;

            if(maxRange <= _step)
            {
                btnNext.Enabled = true;
            }


            this.dgvSpectator.ColumnCount = 10;

            dgvSpectator.Columns.Add(GetActionButton("join"));
            dgvSpectator.Columns.Add(GetActionButton("attend"));
            dgvSpectator.Columns.Add(GetActionButton("withdraw"));



            for (int i = _range; i < _step; i++)
            {
                if (i >= maxRange)
                {
                    btnNext.Enabled = false;
                    break;
                }
                else
                {
                    btnNext.Enabled = true;
                    dgvSpectator.Rows.Add(_conferenceModels[i].ConferenceName,
                            _conferenceModels[i].ConferenceId,
                            _conferenceModels[i].ConferenceStartDate,
                            _conferenceModels[i].ConferenceEndDate,
                            _conferenceModels[i].ConferenceType,
                            _conferenceModels[i].ConferenceCategory,
                            _conferenceModels[i].ConferenceMainSpeaker,
                            _conferenceModels[i].ConferenceLocation,
                            _conferenceModels[i].SpeakerId,
                            _conferenceModels[i].ConferenceOrganiserEmail);

                }

                /*((DataGridViewImageColumn)this.dgvSpectator.Columns[10]).DefaultCellStyle.NullValue = null;
                ((DataGridViewImageColumn)this.dgvSpectator.Columns[11]).DefaultCellStyle.NullValue = null;
                ((DataGridViewImageColumn)this.dgvSpectator.Columns[12]).DefaultCellStyle.NullValue = null;*/

            }


            FormatHeaders();


        }

        private void FormatHeaders()
        {
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

            this.dgvSpectator.Columns[0].Name = "conferenceName";
            this.dgvSpectator.Columns[1].Name = "conferenceId";
            this.dgvSpectator.Columns[6].Name = "conferenceMainSpeaker";
            this.dgvSpectator.Columns[2].Name = "StartDate";
            this.dgvSpectator.Columns[3].Name = "EndDate";
            this.dgvSpectator.Columns[8].Name = "SpeakerId";


            this.dgvSpectator.Columns[7].Visible = false;
            this.dgvSpectator.Columns[9].Visible = false;
            this.dgvSpectator.Columns[1].Visible = false;
            this.dgvSpectator.Columns[8].Visible = false;
        }

        private async void WireUpSpectator(DateTime _startDate, DateTime _endDate)
        {

            string startDateStr = _startDate.ToString("yyyy-MM-dd");
            string endDateStr = _endDate.ToString("yyyy-MM-dd");

            string encodedEmail = HttpUtility.UrlEncode(emailCopyFromMainForm);



            var urlGetConference = $"http://localhost:5000/api/Conference/all/spectator/{encodedEmail}?startDateStr={startDateStr}&endDateStr={endDateStr}";

            conferenceModels = await HttpClientOperations.GetOperation<ConferenceModel>(urlGetConference);

            InsertPaginatedList(conferenceModels, range, step, shown);

            var urlGetConferenceAttendance = "http://localhost:5000/api/ConferenceAttendance/GetConferenceAttendance";
            conferenceAttendances = await HttpClientOperations.GetOperation<ConferenceAttendanceModel>(urlGetConferenceAttendance);

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


           btnPrevious.Enabled = false;
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

            string encodedEmail = HttpUtility.UrlEncode(spectatorEmail);
            var url = $"http://localhost:5000/api/ConferenceAttendance/GetIsParticipating?email={encodedEmail}&id={confId}";
            HttpResponseMessage res = await httpClient.GetAsync(url);
            bool isParticipant = true;

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
            dtpEnd.MinDate = dtpStart.Value;
            DateTime startDate = dtpStart.Value;
            DateTime endDate = dtpEnd.Value;

            WireUpSpectator(startDate, endDate);
        }

        private void dtpEnd_CloseUp(Object sender, EventArgs e)
        {
            DateTime startDate = dtpStart.Value;
            DateTime endDate = dtpEnd.Value;

            WireUpSpectator(startDate, endDate);
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
            var url = "http://localhost:5000/Participant/new";

            HttpClientOperations.PostOperation<Object>(url, new ConferenceAttendance {ConferenceId = _conferenceId, ParticipantEmailAddress = _spectatorEmail, DictionaryParticipantStatusId = _participantStatusCode});
        }

        private async Task<bool> IsWithdrawn(string spectatorEmail, int conferenceId)
        {
            HttpClient httpClient = HttpClientFactory.Create();
            string encodedEmail = HttpUtility.UrlEncode(spectatorEmail);

            var url = $"http://localhost:5000/api/ConferenceAttendance/GetIsWithdrawn?email={encodedEmail}&id={conferenceId}";
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
                            if(await IsWithdrawn(emailCopyFromMainForm, confId))
                            {
                                string url = "http://localhost:5000/api/Conference/attend";
                                HttpClientOperations.PutAsyncOperation(url, new ConferenceAttendanceModel { ParticipantEmailAddress = emailCopyFromMainForm, ConferenceId = confId, DictionaryParticipantStatusId = 3 });
                            }
                            else
                            {
                                InsertParticipant(confId, emailCopyFromMainForm, 1);
                                string conferenceName = dgvSpectator.Rows[e.RowIndex].Cells["conferenceName"].FormattedValue.ToString();
                                //sendEmail("User", emailCopyFromMainForm, conferenceName + " Participarion Code", conferenceName, 1);
                            }
                            dgvSpectator.Rows[e.RowIndex].Cells["buttonAttendColumn"].Style.BackColor = System.Drawing.Color.Khaki;
                        }
                    }
                }


                else if (dgvSpectator.Columns[e.ColumnIndex].Name == "buttonWithdrawColumn")
                {
                    dgvSpectator.CurrentRow.Selected = true;
                    confId = Convert.ToInt32(value: dgvSpectator.Rows[e.RowIndex].Cells["conferenceId"].FormattedValue.ToString());
                    var url = $"http://localhost:5000/api/Conference/withdraw";

                    //HttpClientOperations.PutOperation(url, new ConferenceAttendanceModel { ParticipantEmailAddress = emailCopyFromMainForm, ConferenceId = confId, DictionaryParticipantStatusId = 3 });

                    dgvSpectator.CurrentRow.Selected = true;

                    if (await IsWithdrawn(emailCopyFromMainForm, confId))
                    {
                        MessageBox.Show("User has already withdrawn");
                    }
                    else
                    {
                        dgvSpectator.CurrentRow.Selected = true;
                        HttpClientOperations.PutAsyncOperation(url, new ConferenceAttendanceModel { ParticipantEmailAddress = emailCopyFromMainForm, ConferenceId = confId, DictionaryParticipantStatusId = 3 });
                    }
                }
            }
        }

        private void comboBoxPagesNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            step = (int)comboBoxPagesNumber.SelectedItem;
            shown = (int)comboBoxPagesNumber.SelectedItem;
            InsertPaginatedList(conferenceModels, 0, step, shown);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            range = step;
            step += shown;

            btnPrevious.Enabled = true;

            if (step >= maxRange)
            {
                btnNext.Enabled = false;
            }


            InsertPaginatedList(conferenceModels, range, step, shown);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            step = range;
            range -= shown;

            btnPrevious.Enabled = true;

            if (range == 0)
            {
                btnPrevious.Enabled = false;
            }

            InsertPaginatedList(conferenceModels, range, step, shown);
        }


        private void dgvSpectator_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvSpectator.Rows[e.RowIndex].IsNewRow && e.ColumnIndex == 9)
            {
                e.Value = Properties.Resources.icons8_add_user_group_man_man_20;
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



