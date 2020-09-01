using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class Conference
    {
        public Conference()
        {
            ConferenceAttendance = new HashSet<ConferenceAttendance>();
            ConferenceXspeaker = new HashSet<ConferenceXspeaker>();
        }

        public int ConferenceId { get; set; }
        public string ConferenceName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string OrganiserEmail { get; set; }
        public int LocationId { get; set; }
        public int DictionaryConferenceTypeId { get; set; }
        public int DictionaryConferenceCategoryId { get; set; }

        public virtual DictionaryConferenceCategory DictionaryConferenceCategory { get; set; }
        public virtual DictionaryConferenceType DictionaryConferenceType { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<ConferenceAttendance> ConferenceAttendance { get; set; }
        public virtual ICollection<ConferenceXspeaker> ConferenceXspeaker { get; set; }
    }
}
