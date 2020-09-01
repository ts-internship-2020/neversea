using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class DictionaryParticipantStatus
    {
        public DictionaryParticipantStatus()
        {
            ConferenceAttendance = new HashSet<ConferenceAttendance>();
        }

        public int DictionaryParticipantStatusId { get; set; }
        public string DictionaryParticipantStatusName { get; set; }

        public virtual ICollection<ConferenceAttendance> ConferenceAttendance { get; set; }
    }
}
