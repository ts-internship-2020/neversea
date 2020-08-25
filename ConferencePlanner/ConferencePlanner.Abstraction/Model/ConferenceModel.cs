using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
   public class ConferenceModel
    {

        public String ConferenceName { get; set; }
        public int ConferenceId { get; set; }
        public String ConferenceType { get; set; }
        public DateTime ConferenceStartDate { get; set; }
        public DateTime ConferenceEndDate { get; set; }
        public String ConferenceCategory { get; set; }
        public String ConferenceLocation { get; set; }
        public String ConferenceMainSpeaker { get; set; }

    }
}
