using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;



namespace ConferencePlanner.Abstraction.Repository
{
    public interface IConferenceRepository
    {
        void InsertParticipant(int conferenceId, string spectatorEmail, int spectatorCode);

        public void InsertConference(ConferenceModel model);
        public void InsertConference(ConferenceModel model, int locationId);
        public void InsertConferenceXSpeaker(ConferenceModel model, int speakerId);
        public void InsertConferenceXSpeaker(int _conferenceId, int _speakerId);
        void ModifySpectatorStatusWithdraw(string spectatorEmail, int conferenceId);
        void ModifySpectatorStatusJoin(string spectatorEmail, int conferenceId);
        public List<ConferenceModel> GetConference(string name, DateTime startDate, DateTime endDate);


        public List<ConferenceModel> GetConference(string spectatorEmail, DateTime startDate, DateTime endDate, List<ConferenceAttendanceModel> conferenceAttendances);
        public SpeakerModel getSelectSpeakerDetails(int speakerId);

        public List<ConferenceModel> GetConferenceBetweenDates(string emailOrganiser, DateTime startDate, DateTime endDate);

        //public List<ConferenceModel> GetConference(string spectatorEmail, DateTime startDate, DateTime endDate);

        public void InsertConference(string conferenceName, DateTime startDate, DateTime endDate, string organiserEmail, int locationId, int conferenceTypeId, int conferenceCategoryId);

    }
}