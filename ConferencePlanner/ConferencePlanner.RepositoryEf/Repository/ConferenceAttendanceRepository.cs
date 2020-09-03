using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferencePlanner.Repository.Ef.Repository
{
   public class ConferenceAttendanceRepository : IConferenceAttendanceRepository
    {

        private readonly neverseaContext _dbContext;

        public ConferenceAttendanceRepository(neverseaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ConferenceAttendanceModel> GetConferenceAttendance()
        {
            List<ConferenceAttendanceModel> conferenceAttendanceModels = new List<ConferenceAttendanceModel>();
            List<ConferenceAttendance> conferenceAttendance= new List<ConferenceAttendance>();
            conferenceAttendance = _dbContext.ConferenceAttendance.ToList();
            conferenceAttendanceModels = conferenceAttendance.Select(a => new ConferenceAttendanceModel()
            {
                ParticipantEmailAddress = a.ParticipantEmailAddress,
                ConferenceId = a.ConferenceId,
                DictionaryParticipantStatusId = a.DictionaryParticipantStatusId,
                ParticipationCode = a.ParticipationCode
            }).ToList();

            return conferenceAttendanceModels;

        }

        public bool isParticipating(string email, int id)
        {
            List<ConferenceAttendanceModel> conferenceAttendanceModels = new List<ConferenceAttendanceModel>();
            List<ConferenceAttendance> conferenceAttendance = new List<ConferenceAttendance>();
            conferenceAttendance = _dbContext.ConferenceAttendance.ToList();
            conferenceAttendanceModels = conferenceAttendance.Select(a => new ConferenceAttendanceModel()
            {
                ParticipantEmailAddress = a.ParticipantEmailAddress,
                ConferenceId = a.ConferenceId,
                DictionaryParticipantStatusId = a.DictionaryParticipantStatusId,
                ParticipationCode = a.ParticipationCode
            }).Where(a=>a.ParticipantEmailAddress == email && a.ConferenceId == id).ToList();

            if(conferenceAttendanceModels != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isWithdrawn(string email, int id)
        {   
            
            int code = 0;
            List<ConferenceAttendanceModel> conferenceAttendanceModels = new List<ConferenceAttendanceModel>();
            List<ConferenceAttendance> conferenceAttendance = new List<ConferenceAttendance>();
            conferenceAttendance = _dbContext.ConferenceAttendance.ToList();
            conferenceAttendanceModels = conferenceAttendance.Select(a => new ConferenceAttendanceModel()
            {
                ParticipantEmailAddress = a.ParticipantEmailAddress,
                ConferenceId = a.ConferenceId,
                DictionaryParticipantStatusId = a.DictionaryParticipantStatusId,
                ParticipationCode = a.ParticipationCode
            }).Where(a => a.ParticipantEmailAddress == email && a.ConferenceId == id).ToList();
            
            if(conferenceAttendanceModels != null)
            {
                id = conferenceAttendanceModels[0].DictionaryParticipantStatusId;
             
            }
             if(id == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            
        }
    }
}
