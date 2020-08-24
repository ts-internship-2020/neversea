using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
   public class ConferenceModel
    {
        public String conferenceName { get; set; }

        public String conferenceType { get; set; }

        public int conferencePeriod { get; set; }
        public String conferenceCategory { get; set; }
        public String conferenceAddress { get; set; }
        public String conferenceMainSpeaker { get; set; }

    }
}
