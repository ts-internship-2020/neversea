using BarcodeLib;
using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ado.Repository;
using MailKit.Net.Smtp;
using Microsoft.Toolkit.Forms.UI.Controls;
using Microsoft.Toolkit.Win32.UI.Controls;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
//using System.Net.Mime;
using System.Text;
using System.Windows.Forms;


namespace ConferencePlanner.WinUi
{
    public partial class HomePage : Form

    {
        private readonly IConferenceRepository _getConferenceRepository;
        private readonly IConferenceTypeRepository _conferenceTypeRepository;
        private readonly IConferenceCategoryRepository conferenceCategoryRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly IConferenceCityRepository conferenceCityRepository;
        private readonly IConferenceSpeakerRepository conferenceSpeakerRepository;
        private readonly IConferenceAttendanceRepository _conferenceAttendanceRepository;


        private readonly IConferenceCategoryRepository _conferenceCategoryRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly Random random = new Random();


        public List<ConferenceModel> Conferences { get; set; }
        public string emailCopyFromMainForm;

        public int counterEmails = 0;
        public int range = 0;
        public int step = 4;
        public int shown = 4;
        public int maxrange;
        public HomePage()
        {
            InitializeComponent();
        }

        public HomePage(IConferenceRepository getConferenceRepository, String emailCopy, IConferenceTypeRepository conferenceTypeRepository,ICountryRepository countryRepository, IConferenceCategoryRepository _conferenceCategoryRepository,IDistrictRepository districtRepository, IConferenceCityRepository _conferenceCityRepository, IConferenceAttendanceRepository conferenceAttendanceRepository, IConferenceSpeakerRepository _conferenceSpeakerRepository)
        {
            _conferenceTypeRepository = conferenceTypeRepository;
            _getConferenceRepository = getConferenceRepository;
            _countryRepository = countryRepository;
            _conferenceAttendanceRepository = conferenceAttendanceRepository;

            conferenceCategoryRepository = _conferenceCategoryRepository;
            conferenceCityRepository = _conferenceCityRepository;
            emailCopyFromMainForm = emailCopy;
            _districtRepository = districtRepository;
            conferenceSpeakerRepository = _conferenceSpeakerRepository;
            InitializeComponent();

            DateTime now = DateTime.Now;

            dtpStart.Value = now.AddMonths(-1);
            dtpEnd.Value = now.AddMonths(1);
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            
            WireUpSpectator(dtpStart.Value, dtpEnd.Value);

            LoadOrganiser();

            DataGridViewButtonColumn buttonEditColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Edit",
                Name = "buttonEditColumn",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            };
            dgvOrganiser.Columns.Add(buttonEditColumn);

            DataGridViewImageColumn buttonJoinColumn = new DataGridViewImageColumn
            {
                HeaderText = "Join",
                Name = "buttonJoinColumn",
                ToolTipText = "Join Conference",
                //Text = "Join",
                // UseColumnTextForButtonValue = true
                Image = Properties.Resources.icons8_add_user_group_man_man_20
                
            };

         

            dgvConferences.Columns.Add(buttonJoinColumn);

            DataGridViewImageColumn buttonAttendColumn = new DataGridViewImageColumn
            {
                HeaderText = "Attend",
                Name = "buttonAttendColumn",
                ToolTipText = "Attend Conference",
                Image = Properties.Resources.icons8_event_accepted_20
            };
            // buttonAttendColumn.Text = "Attend";
            //buttonAttendColumn.UseColumnTextForButtonValue = true;


            dgvConferences.Columns.Add(buttonAttendColumn);



            DataGridViewImageColumn buttonWithdrawColumn = new DataGridViewImageColumn
            {
                HeaderText = "Withdraw",
                Name = "buttonWithdrawColumn",
                ToolTipText = "Withdraw from conference",
                DividerWidth = 0,
                Image = Properties.Resources.icons8_xbox_x_20

               
            };
            //   buttonWithdrawColumn.Text = "Withdraw";
            // buttonWithdrawColumn.UseColumnTextForButtonValue = true;
          
            dgvConferences.Columns.Add(buttonWithdrawColumn);
        }
        
        private void LoadOrganiser()
        {
            comboBox1.SelectedItem = 4;
            DateTime initialStart = DateTime.Parse("01.01.1900 00:00:00");
            DateTime initialEnd = DateTime.Parse("01.01.2100 00:00:00");
            Conferences = _getConferenceRepository.GetConferenceBetweenDates(emailCopyFromMainForm, initialStart, initialEnd);

            maxrange = Conferences.Count;
            button2.Enabled = false;
            dgvOrganiser.ColumnCount = 8;
            dgvOrganiser.Columns[0].Name = "Id";
            dgvOrganiser.Columns[1].Name = "Title";
            dgvOrganiser.Columns[2].Name = "StartDate";
            dgvOrganiser.Columns[3].Name = "EndDate";
            dgvOrganiser.Columns[4].Name = "Type";
            dgvOrganiser.Columns[5].Name = "Category";
            dgvOrganiser.Columns[6].Name = "Address";
            dgvOrganiser.Columns[7].Name = "Speaker";
            this.dgvOrganiser.Columns[0].Visible = false;
            WireUpOrganiser();
        }
        private void WireUpOrganiser()
        {
            for (int i = range; i<step; i++)
            {   
                if (i >= maxrange)
                {
                    Console.WriteLine("breaked");
                    break;
                }
                else
                {
                        dgvOrganiser.Rows.Add(Conferences[i].ConferenceId,
                                    Conferences[i].ConferenceName,
                                    Conferences[i].ConferenceStartDate,
                                    Conferences[i].ConferenceEndDate,
                                    Conferences[i].ConferenceType,
                                    Conferences[i].ConferenceCategory,
                                    Conferences[i].ConferenceLocation,
                                    Conferences[i].ConferenceMainSpeaker);
                }

                if (Conferences.Count <= (int)comboBox1.SelectedItem)
                {
                    button3.Enabled = false;
                }
                else if (step < maxrange)
                {
                    button3.Enabled = true;
                }
                //d/*gvOrganiser.Rows.RemoveAt(dgvOrganiser.Rows.Count - 1);*/
            }
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

      

        private void WireUpSpectator(DateTime startDate, DateTime endDate)
        {
            List<ConferenceModel> conferences = new List<ConferenceModel>();
            List<ConferenceAttendanceModel> conferenceAttendances = new List<ConferenceAttendanceModel>();

            conferenceAttendances = _conferenceAttendanceRepository.GetConferenceAttendance();


            conferences = _getConferenceRepository.GetConference(emailCopyFromMainForm, startDate, endDate, conferenceAttendances);

            dgvConferences.DataSource = null;
            
            dgvConferences.DataSource = conferences;



            dgvConferences.Columns[0].HeaderText = "Title";
            dgvConferences.Columns[1].HeaderText = "Id";
            dgvConferences.Columns[2].HeaderText = "Starts";
            dgvConferences.Columns[3].HeaderText = "Ends";
            dgvConferences.Columns[4].HeaderText = "Type";
            dgvConferences.Columns[5].HeaderText = "Category";
            dgvConferences.Columns[6].HeaderText = "Speaker";
            dgvConferences.Columns[7].HeaderText = "Location";
            dgvConferences.Columns[8].HeaderText = "SpeakerId";

            dgvConferences.Columns[2].Name = "StartDate";
            dgvConferences.Columns[3].Name = "EndDate";




            this.dgvConferences.Columns[1].Visible = false;

            this.dgvConferences.Columns[8].Visible = false;

            this.dgvConferences.Columns[6].Name = "conferenceMainSpeaker";
        }

        private void dgvConferences_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string confName;
            int confId;
            if (e.RowIndex == -1) return;

            if (dgvConferences.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                if (e.RowIndex == -1) return;

                if (dgvConferences.Columns[e.ColumnIndex].Name == "conferenceMainSpeaker")
                {
                    if (e.RowIndex == -1) return;

                    string speakerName =  dgvConferences.Rows[e.RowIndex].Cells["conferenceMainSpeaker"].FormattedValue.ToString();
                    int speakerId = Convert.ToInt32(value: dgvConferences.Rows[e.RowIndex].Cells["SpeakerId"].FormattedValue.ToString());
                    FormSpeakerDetails formSpeakerDetail = new FormSpeakerDetails(_getConferenceRepository,speakerId);
                    formSpeakerDetail.ShowSpeakerDetails();
                    FormSpeakerDetails frSpeakerDetail = new FormSpeakerDetails();
                    frSpeakerDetail.Focus();

                }
                   else if (dgvConferences.Columns[e.ColumnIndex].Name == "buttonJoinColumn")
                {
                   DateTime sDate =  Convert.ToDateTime(dgvConferences.Rows[e.RowIndex].Cells["StartDate"].FormattedValue.ToString());
                    if (e.RowIndex == -1) return;
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

                  else if (dgvConferences.Columns[e.ColumnIndex].Name == "buttonAttendColumn")
                    {
                    if (e.RowIndex == -1) return;
                     else { 
                    confId = Convert.ToInt32(value: dgvConferences.Rows[e.RowIndex].Cells["conferenceId"].FormattedValue.ToString());

                    if (_conferenceAttendanceRepository.isParticipating(emailCopyFromMainForm, confId) == true) 
                        {
                            MessageBox.Show("You are already attending this conference");
                        }
                    
                        
                        else
                        {

                            dgvConferences.CurrentRow.Selected = true;
                            int minCode = int.MinValue;
                            int maxCode = int.MaxValue;
                            //confId = Convert.ToInt32(value: dgvConferences.Rows[e.RowIndex].Cells["conferenceId"].FormattedValue.ToString());
                            _getConferenceRepository.InsertParticipant(confId, emailCopyFromMainForm, random.Next(minCode, maxCode));
                            //_getConferenceRepository.ModifySpectatorStatusAttend(confName, email);
                            string conferenceName = dgvConferences.Rows[e.RowIndex].Cells["conferenceName"].FormattedValue.ToString();
                            sendEmail("User", emailCopyFromMainForm, conferenceName + " Participarion Code", conferenceName, 1);
                            // dgvConferences.Rows[e.RowIndex].Cells["buttonAttendColumn"].Visible = true;

                        }
                    }


                }

                else if (dgvConferences.Columns[e.ColumnIndex].Name == "buttonWithdrawColumn")
                {
                    confId = Convert.ToInt32(value: dgvConferences.Rows[e.RowIndex].Cells["conferenceId"].FormattedValue.ToString());

                    if (_conferenceAttendanceRepository.isWithdrawn(emailCopyFromMainForm, confId))
                    {
                        MessageBox.Show("User has already withdrawn");
                    }
                    else
                    {
                        dgvConferences.CurrentRow.Selected = true;
                        _getConferenceRepository.ModifySpectatorStatusWithdraw(emailCopyFromMainForm, confId);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddConference();
        }

        private void dgvOrganiser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrganiser.Columns[e.ColumnIndex].Name == "buttonEditColumn")
            {
                ConferenceModel conf = new ConferenceModel();
                int confId;
                string confName;
                
                dgvOrganiser.CurrentRow.Selected = true;
                confId = Convert.ToInt32(value: dgvOrganiser.Rows[e.RowIndex].Cells["ConferenceId"].FormattedValue.ToString());
                confName = dgvOrganiser.Rows[e.RowIndex].Cells["ConferenceName"].FormattedValue.ToString();
                //confStartDate = dgvOrganiser.Rows[e.RowIndex].Cells["StartDate"].FormattedValue.ToDate();
                //confEndDate = dgvOrganiser.Rows[e.RowIndex].Cells["EndDate"].FormattedValue.ToDate();
                Console.WriteLine(confId);
                Form2 editConferenceForm = new Form2(_getConferenceRepository, conf);
                editConferenceForm.ShowDialog();
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine(dateTimePicker1.Value);
            dgvOrganiser.Rows.Clear();
            Conferences.Clear();
            Conferences = _getConferenceRepository.GetConferenceBetweenDates(emailCopyFromMainForm, dateTimePicker1.Value, dateTimePicker2.Value);
            Console.WriteLine(Conferences.Count);
            maxrange = Conferences.Count;
            step = (int)comboBox1.SelectedItem;
            shown = (int)comboBox1.SelectedItem;
            button2.Enabled = false;
            WireUpOrganiser();
        }

        private void AddConference()
        {
         //   Form2 addConferenceForm = new Form2(_countryRepository);
        
            Form2 addConferenceForm = new Form2(emailCopyFromMainForm, _getConferenceRepository,  _conferenceTypeRepository, _countryRepository, conferenceCategoryRepository, _districtRepository, conferenceCityRepository, _conferenceAttendanceRepository, conferenceSpeakerRepository);
            addConferenceForm.ShowDialog();
        }

        private void MainPageTab_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dgvOrganiser.Rows.Clear();
            dgvOrganiser.Rows.Clear();
            Conferences.Clear();
            Conferences = _getConferenceRepository.GetConferenceBetweenDates(emailCopyFromMainForm, dateTimePicker1.Value, dateTimePicker2.Value);
            Console.WriteLine(Conferences.Count);
            maxrange = Conferences.Count;
            step = (int)comboBox1.SelectedItem;
            shown = (int)comboBox1.SelectedItem;
            button2.Enabled = false;
            WireUpOrganiser();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dgvOrganiser.Rows.Clear();
            range = step;
            step += shown;
            button2.Enabled = true;
            if (step >= maxrange)
            {
                button3.Enabled = false;
            }
            Console.WriteLine("Am dat Next: range=" + range + " si step=" + step);
            WireUpOrganiser();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvOrganiser.Rows.Clear();
            step = range;
            range -= shown;
            button3.Enabled = true;
            if (range == 0)
            {
                button2.Enabled = false;
            }
            Console.WriteLine("Am dat Back: range=" + range + " si step=" + step);
            WireUpOrganiser();
        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvOrganiser.Rows.Clear();
            range = 0;
            step = (int)comboBox1.SelectedItem;
            shown = (int)comboBox1.SelectedItem;
            button2.Enabled = false;
            WireUpOrganiser();

        }

        private void pageSizeLabel_Click(object sender, EventArgs e)
        {

     
        
        }


        private void sendEmail(string name, string email, string subject, string confName, long code)
        {
            //var mailMessage = new MimeMessage();
            //mailMessage.From.Add(new MailboxAddress("NeverSea", "ConferencePlannerNeverSea2020@gmail.com"));
            //mailMessage.To.Add(new MailboxAddress(name, email));
            //mailMessage.Subject = subject;
            //mailMessage.Body = new TextPart("plain")
            //{
            //    Text = "Hello, " + name + "," + "\n You received this email because you subscribed for " + confName + ". \n You have attached below the room code and a barcode for it, thanks for using our platform!"


            //};
            



            //using (var smtpClient = new MailKit.Net.Smtp.SmtpClient())
            //{
            //    smtpClient.Connect("smtp.gmail.com", 587, true);
            //    smtpClient.Authenticate("ConferencePlannerNeverSea2020@gmail.com", "Neversea2020");
            //    smtpClient.Send(mailMessage);
            //    smtpClient.Disconnect(true);
            //}


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

            
            //using (var stream = new System.IO.MemoryStream())
            //{
               // Bitmap bitmap = (Bitmap)
            Image img = generateBarcode(code);
            //img.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            Attachment attachment1 = new Attachment(@"C:\NeverseaBugs\neversea-develop\neversea-develop\ConferencePlanner\Image.jpeg");
            mailMessage1.Attachments.Add(attachment1);
            mailMessage1.To.Add(email);
            smtpClient.Send(mailMessage1);
            //}
            //  var attachment = new Attachment("Barcode.png", MediaTypeNames.Image.Jpeg);
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

        public long generateCode(int min, int max)
        {
                        
            return random.Next(min, max);
        }

    }
}

