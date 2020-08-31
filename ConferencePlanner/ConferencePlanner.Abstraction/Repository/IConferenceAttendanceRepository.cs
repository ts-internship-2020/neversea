using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface IConferenceAttendanceRepository
    {
        public List<ConferenceAttendanceModel> GetConferenceAttendance();
        public bool isParticipating(string email, int id);
        public bool isWithdrawn(string email, int id);

    }
}
