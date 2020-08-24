using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
   public interface IConferenceRepository
    {
        void InsertParticipant(int conferenceId, string spectatorEmail);
        void ModifySpectatorStatusAttend(string conferenceName, string spectatorEmail);

        void ModifySpectatorStatusWithdraw(string spectatorEmail, int conferenceId);
        void ModifySpectatorStatusJoin(string spectatorEmail, int conferenceId);
        public List<ConferenceModel> GetConference(string name);
        public List<ConferenceModel> GetConference(string name, DateTime startDate, DateTime endDate);
        
    }
}
