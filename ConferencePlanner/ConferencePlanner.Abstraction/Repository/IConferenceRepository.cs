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
        public void InsertConferenceXSpeaker(ConferenceModel model, int speakerId);
        void ModifySpectatorStatusWithdraw(string spectatorEmail, int conferenceId);
        void ModifySpectatorStatusJoin(string spectatorEmail, int conferenceId);

        public List<ConferenceModel> GetConference(string spectatorEmail, DateTime startDate, DateTime endDate, List<ConferenceAttendanceModel> conferenceAttendances);
        public SpeakerModel getSelectSpeakerDetails(int speakerId);

        public List<ConferenceModel> GetConferenceBetweenDates(string emailOrganiser, DateTime startDate, DateTime endDate);

        //public List<ConferenceModel> GetConference(string spectatorEmail, DateTime startDate, DateTime endDate);

        public void InsertConference(ConferenceModel conference, int locationId);

    }
}