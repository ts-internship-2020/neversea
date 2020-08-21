using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ado.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace ConferencePlanner.WinUi
{
    public partial class MainPage : Form

    {
        private readonly IGetConferenceRepository _getConferenceRepository;
        public List<ConferenceModel> Conferences { get; set; }
    
        public GetConferenceRepository GetConferenceRepository { get; set; }

        public MainPage(IGetConferenceRepository getConferenceRepository, GetConferenceRepository gcf, List<ConferenceModel> listuta)
        {
            GetConferenceRepository = gcf;
            Conferences = listuta;
            _getConferenceRepository = getConferenceRepository;

            InitializeComponent();

        }


        private void MainPage_Load(object sender, EventArgs e)
        {
            //  var conferences = this.Conferences;
            dgvConferences.DataSource = GetConferenceRepository.GetConference("");
        }
    }
}
