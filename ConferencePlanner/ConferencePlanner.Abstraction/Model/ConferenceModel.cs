using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferencePlanner.Abstraction.Model
{
    public class ConferenceModel
    {
        public String conferenceName { get; set; }

        public DateTime conferenceStartDate { get; set; }
        public DateTime conferenceEndDate { get; set; }
        public int conferencePeriod { get; set; }
        public String conferenceType { get; set; }
        public String conferenceCategory { get; set; }
        public String conferenceAddress { get; set; }
        public String conferenceMainSpeaker { get; set; }
    }
}
