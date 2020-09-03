using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Repository.Ef.Repository
{
    class ConferenceRepository : IConferenceRepository
    {
        private readonly neverseaContext _dbContext;

        public ConferenceRepository(neverseaContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<ConferenceModel> GetConference(string name, DateTime startDate, DateTime endDate, List<ConferenceAttendanceModel> conferenceAttendances)
        {
            throw new NotImplementedException();


        }

        public List<ConferenceModel> GetConferenceBetweenDates(string emailOrganiser, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public List<string> GetCountry(string name)
        {
            throw new NotImplementedException();
        }

        public SpeakerModel getSelectSpeakerDetails(int speakerId)
        {
            throw new NotImplementedException();
        }

        public void InsertConference(ConferenceModel model)
        {
            throw new NotImplementedException();
        }

        public void InsertConference(ConferenceModel conference, int locationId)
        {
            throw new NotImplementedException();
        }

        public void InsertConferenceXSpeaker(ConferenceModel model, int speakerId)
        {
            throw new NotImplementedException();
        }

        public void InsertParticipant(int conferenceId, string spectatorEmail, int spectatorCode)
        {
            throw new NotImplementedException();
        }

        public void ModifySpectatorStatusAttend(string conferenceName, string spectatorEmail)
        {
            throw new NotImplementedException();
        }

        public void ModifySpectatorStatusJoin(string spectatorEmail, int conferenceId)
        {
            throw new NotImplementedException();
        }

        public void ModifySpectatorStatusWithdraw(string spectatorEmail, int conferenceId)
        {
            throw new NotImplementedException();
        }
    }
}
