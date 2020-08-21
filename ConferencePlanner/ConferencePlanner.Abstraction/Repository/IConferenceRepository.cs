using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
   public interface IConferenceRepository
    {
        void InsertParticipant(string conferenceName, string spectatorEmail);
        void ModifySpectatorStatusWithdraw(string spectatorEmail, string conferenceName);
        void ModifySpectatorStatusJoin(string spectatorEmail, string conferenceName);
        
    }
}
using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace ConferencePlanner.Abstraction.Repository
{
    public interface IConferenceRepository
    {
        List<ConferenceModel> GetConference(string name);
    }
}
