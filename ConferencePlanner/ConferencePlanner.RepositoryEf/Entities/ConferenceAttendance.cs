using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class ConferenceAttendance
    {
        public int ConferenceId { get; set; }
        public string ParticipantEmailAddress { get; set; }
        public int DictionaryParticipantStatusId { get; set; }
        public Guid? ParticipationCode { get; set; }

        public virtual Conference Conference { get; set; }
        public virtual DictionaryParticipantStatus DictionaryParticipantStatus { get; set; }
    }
}
