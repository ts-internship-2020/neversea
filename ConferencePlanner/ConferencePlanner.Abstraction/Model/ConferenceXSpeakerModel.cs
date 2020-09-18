using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
   public class ConferenceXSpeakerModel
    {
        public int DictionarySpeakerId { get; set; }
        public int conferenceId { get; set; }
        public bool isMain { get; set; }




    }
}
