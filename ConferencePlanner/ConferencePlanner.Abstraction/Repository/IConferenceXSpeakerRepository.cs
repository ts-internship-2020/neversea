using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
   public interface IConferenceXSpeakerRepository
    {

        public void AddSpeaker(int conferenceId, int speakerId, bool isMain);
        public void updateConferenceXSpeaker(int conferenceId, int speakerId);
    }
}
