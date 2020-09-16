using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
    public class ConferenceModelDB
    {
        public String ConferenceName { get; set; }
        public int ConferenceId { get; set; }
        public DateTime ConferenceStartDate { get; set; }
        public DateTime ConferenceEndDate { get; set; }
        public int ConferenceTypeId { get; set; }
        public int ConferenceCategoryId { get; set; }
        public int ConferenceMainSpeakerId { get; set; }
        public int ConferenceLocationId { get; set; }
        public int SpeakerId { get; set; }
        public String ConferenceOrganiserEmail { get; set; }
    }
}
