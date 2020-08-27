using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
    public class ConferenceAttendanceModel
    {
        public int ConferenceId { get; set; }
        public string ParticipantEmailAddress { get; set; }
        public int DictionaryParticipantStatusId { get; set; }
        public Guid? ParticipationCode { get; set; }
    }
}
