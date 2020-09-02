using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferencePlanner.Repository.Ef.Repository
{
    public class ConferenceRepository : IConferenceRepository
    {

        private readonly neverseaContext dbContext;

        public ConferenceRepository(neverseaContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<ConferenceModel> GetConference(string name, DateTime startDate, DateTime endDate, List<ConferenceAttendanceModel> conferenceAttendances)
        {
            List<Conference> conferences = dbContext.Conference
                                            .Include(c => c.DictionaryConferenceType)
                                            .Include(c => c.DictionaryConferenceCategory)
                                            .Include(c => c.ConferenceXspeaker)
                                                 .ThenInclude(cxs => cxs.DictionarySpeaker)
                                            .Include(c => c.Location)
                                                .ThenInclude(l => l.DictionaryCity)
                                                    .ThenInclude(ci => ci.DictionaryDistrict)
                                                        .ThenInclude(di => di.DictionaryCountry)
                                            .Include(c => c.ConferenceAttendance)
                                                 .ToList();

            List<ConferenceModel> conferenceModels = conferences
                                                        .Where(c => c.StartDate >= startDate && c.EndDate <= endDate)
                                                        .OrderBy(c => c.ConferenceAttendance.FirstOrDefault().DictionaryParticipantStatus).ThenBy(c => c.ConferenceName)
                                                        .Select(m => new ConferenceModel()
                                                              {
                                                                ConferenceName = m.ConferenceName,
                                                                ConferenceId = m.ConferenceId,
                                                                ConferenceStartDate = m.StartDate,
                                                                ConferenceEndDate = m.EndDate,
                                                                ConferenceType = m.DictionaryConferenceType.DictionaryConferenceTypeName,
                                                                ConferenceCategory = m.DictionaryConferenceCategory.DictionaryConferenceCategoryName, 
                                                                ConferenceMainSpeaker = m.ConferenceXspeaker
                                                                                         .Where(x => x.IsMain)
                                                                                         .FirstOrDefault()
                                                                                         .DictionarySpeaker.DictionarySpeakerName,
                                                                ConferenceLocation = m.Location.DictionaryCity.DictionaryCityName
                                                                                        + ", " + m.Location.DictionaryCity.DictionaryDistrict
                                                                                        + ", " + m.Location.DictionaryCity.DictionaryDistrict.DictionaryDistrictName
                                                                                        + ", " + m.Location.DictionaryCity.DictionaryDistrict.DictionaryCountry.DictionaryCountryName, 
                                                                SpeakerId = m.ConferenceXspeaker
                                                                                .Where(x => x.IsMain)
                                                                                .FirstOrDefault()
                                                                                .DictionarySpeaker.DictionarySpeakerId,   
                                                                ConferenceOrganiserEmail = m.OrganiserEmail
                                                              }).ToList();

           
            return conferenceModels;
        }

        public List<ConferenceModel> GetConferenceBetweenDates(string emailOrganiser, DateTime startDate, DateTime endDate)
        {
            List<Conference> conferences = dbContext.Conference
                                .Include(c => c.DictionaryConferenceType)
                                .Include(c => c.DictionaryConferenceCategory)
                                .Include(c => c.ConferenceXspeaker)
                                     .ThenInclude(cxs => cxs.DictionarySpeaker)
                                .Include(c => c.Location)
                                     .ToList();

            List<ConferenceModel> conferenceModels = conferences
                                            .Where(c => c.StartDate >= startDate && c.EndDate <= endDate && c.OrganiserEmail == emailOrganiser)
                                            .OrderBy(c => c.StartDate).ThenBy(c => c.ConferenceName)
                                            .Select(m => new ConferenceModel()
                                            {
                                                ConferenceName = m.ConferenceName,
                                                ConferenceId = m.ConferenceId,
                                                ConferenceStartDate = m.StartDate,
                                                ConferenceEndDate = m.EndDate,
                                                ConferenceType = m.DictionaryConferenceType.DictionaryConferenceTypeName,
                                                ConferenceCategory = m.DictionaryConferenceCategory.DictionaryConferenceCategoryName,
                                                ConferenceMainSpeaker = m.ConferenceXspeaker
                                                                             .Where(x => x.IsMain)
                                                                             .FirstOrDefault()
                                                                             .DictionarySpeaker.DictionarySpeakerName,
                                                ConferenceLocation = m.Location.LocationAddress,
                                                SpeakerId = m.ConferenceXspeaker
                                                                    .Where(x => x.IsMain)
                                                                    .FirstOrDefault()
                                                                    .DictionarySpeaker.DictionarySpeakerId,
                                                ConferenceOrganiserEmail = m.OrganiserEmail
                                            }).ToList();

            return conferenceModels;
        }


        public SpeakerModel getSelectSpeakerDetails(int speakerId)
        {
            List<DictionarySpeaker> speakers = dbContext.DictionarySpeaker
                                                    .Include(s => s.DictionaryCountry)
                                                    .ToList();
            SpeakerModel speakerModel = speakers
                                                  .Where(s => s.DictionarySpeakerId == speakerId)
                                                  .Select(m => new SpeakerModel()
                                                  {
                                                      DictionarySpeakerName = m.DictionarySpeakerName,
                                                      DictionarySpeakerNationality = m.DictionaryCountry.DictionaryCountryNationality,
                                                      DictionarySpeakerRating = m.DictionarySpeakerRating,
                                                      DictionarySpeakerImage = m.DictionarySpeakerImage
                                                  })
                                                  .FirstOrDefault();
                   
            return speakerModel; 
        }

        public void InsertConference(ConferenceModel model)
        {
            var conference = new Conference
            {
                ConferenceName = model.ConferenceName, 
                StartDate = model.ConferenceStartDate, 
                EndDate = model.ConferenceEndDate, 
                OrganiserEmail = model.ConferenceOrganiserEmail, 
                LocationId = Int32.Parse(model.ConferenceLocation), 
                DictionaryConferenceTypeId = Int32.Parse(model.ConferenceType), 
                DictionaryConferenceCategoryId = Int32.Parse(model.ConferenceCategory)
            };

            dbContext.Conference.Add(conference);
            dbContext.SaveChanges();
        }

        public void InsertConference(ConferenceModel model, int locationId)
        {
            var conference = new Conference
            {
                ConferenceName = model.ConferenceName,
                StartDate = model.ConferenceStartDate,
                EndDate = model.ConferenceEndDate,
                OrganiserEmail = model.ConferenceOrganiserEmail,
                LocationId = locationId,
                DictionaryConferenceTypeId = Int32.Parse(model.ConferenceType),
                DictionaryConferenceCategoryId = Int32.Parse(model.ConferenceCategory)
            };

            dbContext.Conference.Add(conference);
            dbContext.SaveChanges();
        }

        public void InsertConferenceXSpeaker(ConferenceModel model, int speakerId)
        {
            var conferenceXSpeaker = new ConferenceXspeaker
            {
                DictionarySpeakerId = speakerId,
                ConferenceId = model.ConferenceId,
                IsMain = true
            };

            dbContext.ConferenceXspeaker.Add(conferenceXSpeaker);
            dbContext.SaveChanges();
        }

        public void InsertParticipant(int conferenceId, string spectatorEmail, int spectatorCode)
        {
            var conferenceAttendance = new ConferenceAttendance
            {
                ConferenceId = conferenceId, 
                ParticipantEmailAddress = spectatorEmail, 
                DictionaryParticipantStatusId = 2
            };

            dbContext.ConferenceAttendance.Add(conferenceAttendance);
            dbContext.SaveChanges();
        }


        public void ModifySpectatorStatusJoin(string spectatorEmail, int conferenceId)
        {
            var entryToUpdate = dbContext.ConferenceAttendance.FirstOrDefault(a => a.ConferenceId == conferenceId && a.ParticipantEmailAddress == spectatorEmail);
            
            if (entryToUpdate != null)
            {
                entryToUpdate.DictionaryParticipantStatusId = 1;

                dbContext.ConferenceAttendance.Update(entryToUpdate);
                dbContext.SaveChanges();
            }
        }

        public void ModifySpectatorStatusWithdraw(string spectatorEmail, int conferenceId)
        {
            var entryToUpdate = dbContext.ConferenceAttendance.FirstOrDefault(a => a.ConferenceId == conferenceId && a.ParticipantEmailAddress == spectatorEmail);

            if (entryToUpdate != null)
            {
                entryToUpdate.DictionaryParticipantStatusId = 3;

                dbContext.ConferenceAttendance.Update(entryToUpdate);
                dbContext.SaveChanges();
            }
        }
    }
}
