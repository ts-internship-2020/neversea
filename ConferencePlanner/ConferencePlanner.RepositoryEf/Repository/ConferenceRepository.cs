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
        private readonly IConferenceLocationRepository conferenceLocationRepository;

        public ConferenceRepository(neverseaContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<ConferenceModel> GetConference(string _spectatorEmail, DateTime _startDate, DateTime _endDate, List<ConferenceAttendanceModel> _conferenceAttendanceModels)
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
                                                        .Where(c => c.StartDate >= _startDate && c.EndDate <= _endDate)
                                                        //.OrderByDescending(c => c.ConferenceAttendance.Where(ca => ca.ParticipantEmailAddress == _spectatorEmail && ca.DictionaryParticipantStatusId != 0))
                                                        .OrderBy(c => c.ConferenceAttendance.Where(ca => ca.ParticipantEmailAddress == _spectatorEmail).OrderBy(ca => ca.DictionaryParticipantStatusId != 0).ThenBy(ca => ca.DictionaryParticipantStatus.DictionaryParticipantStatusName))
                                                       // .OrderBy(c => c.ConferenceAttendance.Where(ca => ca.ParticipantEmailAddress == _spectatorEmail).FirstOrDefault().OrderBy(ca => ca.DictionaryParticipantStatus.HasValue)).ThenBy(c => c.ConferenceName)
                                                      //.OrderBy(c => c.ConferenceAttendance.Where(ca => ca.ParticipantEmailAddress == _spectatorEmail).FirstOrDefault().DictionaryParticipantStatus.OrderBy(ca => ca.DictionaryParticipantStatus.HasValue)).ThenBy(c => c.ConferenceName)
                                                                                                               //.OrderBy(c => c.ConferenceAttendance.Where(ca => ca.ParticipantEmailAddress == _spectatorEmail).FirstOrDefault().DictionaryParticipantStatus.OrderBy(ca => ca.DictionaryParticipantStatus.HasValue)).ThenBy(c => c.ConferenceName).OrderBy(c => c.ConferenceAttendance.Where(ca => ca.ParticipantEmailAddress == _spectatorEmail).FirstOrDefault().DictionaryParticipantStatus.OrderBy(ca => ca.DictionaryParticipantStatus.HasValue)).ThenBy(c => c.ConferenceName)

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
                                                                                        /*+ ", " + m.Location.DictionaryCity.DictionaryDistrict
                                                                                        + ", " + m.Location.DictionaryCity.DictionaryDistrict.DictionaryDistrictName*/
                                                                                        + ", " + m.Location.DictionaryCity.DictionaryDistrict.DictionaryCountry.DictionaryCountryName, 
                                                                SpeakerId = m.ConferenceXspeaker
                                                                                .Where(x => x.IsMain)
                                                                                .FirstOrDefault()
                                                                                .DictionarySpeaker.DictionarySpeakerId,   
                                                                ConferenceOrganiserEmail = m.OrganiserEmail
                                                              })
                                                        .ToList();

           
            return conferenceModels;
        }

        public List<ConferenceModel> GetConference(string _spectatorEmail, DateTime _startDate, DateTime _endDate)
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
                                                .ThenInclude(ca => ca.DictionaryParticipantStatus)
                                            .ToList();

            List<ConferenceModel> conferenceModels = conferences
                                            .Where(c => c.StartDate >= _startDate && c.EndDate <= _endDate)
                                            .OrderByDescending(c => c.ConferenceAttendance.Where(ca => ca.ParticipantEmailAddress == _spectatorEmail && ca.DictionaryParticipantStatusId == 2)
                                                                                          .OrderByDescending(ca => ca.ParticipantEmailAddress == _spectatorEmail ? 1 : 0)
                                                                                          .Select(x => x.DictionaryParticipantStatus.DictionaryParticipantStatusName)
                                                                                          .FirstOrDefault())
                                            .ThenByDescending(c => c.ConferenceAttendance.Where(ca => ca.ParticipantEmailAddress == _spectatorEmail && ca.DictionaryParticipantStatusId == 1)
                                                                                         .OrderByDescending(ca => ca.ParticipantEmailAddress == _spectatorEmail ? 1 : 0)
                                                                                         .Select(x => x.DictionaryParticipantStatus.DictionaryParticipantStatusName)
                                                                                         .FirstOrDefault())
                                            .ThenByDescending(c => c.ConferenceAttendance.Where(ca => ca.ParticipantEmailAddress == _spectatorEmail && ca.DictionaryParticipantStatusId == 3)
                                                                                         .OrderByDescending(ca => ca.ParticipantEmailAddress == _spectatorEmail ? 1 : 0)
                                                                                         .Select(x => x.DictionaryParticipantStatus.DictionaryParticipantStatusName)
                                                                                         .FirstOrDefault())      
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
                                                                             .Select(x => x.DictionarySpeaker.DictionarySpeakerName)
                                                                             .FirstOrDefault(),
                                                ConferenceLocation = m.Location.DictionaryCity.DictionaryCityName
                                                                            //+ ", " + m.Location.DictionaryCity.DictionaryCityName
                                                                            //+ ", " + m.Location.DictionaryCity.DictionaryDistrict.DictionaryDistrictName
                                                                            + ", " + m.Location.DictionaryCity.DictionaryDistrict.DictionaryCountry.DictionaryCountryName,
                                                SpeakerId = m.ConferenceXspeaker
                                                                    .Where(x => x.IsMain)
                                                                    .Select(x => x.DictionarySpeakerId)
                                                                    .FirstOrDefault(),
                                                ConferenceOrganiserEmail = m.OrganiserEmail
                                            })
                                            .ToList();



            return conferenceModels;
        }

        public List<ConferenceModel> GetConferenceBetweenDates(string _emailOrganiser, DateTime _startDate, DateTime _endDate)
        {
            List<Conference> conferences = dbContext.Conference
                                .Include(c => c.DictionaryConferenceType)
                                .Include(c => c.DictionaryConferenceCategory)
                                .Include(c => c.ConferenceXspeaker)
                                     .ThenInclude(cxs => cxs.DictionarySpeaker)
                                .Include(c => c.Location)
                                     .ToList();

            List<ConferenceModel> conferenceModels = conferences
                                            .Where(c => c.StartDate >= _startDate && c.EndDate <= _endDate && c.OrganiserEmail == _emailOrganiser)
                                            .OrderBy(c => c.StartDate).ThenBy(c => c.ConferenceName)
                                            .Select(m => new ConferenceModel()
                                            {
                                                ConferenceName = m.ConferenceName,
                                                ConferenceId = m.ConferenceId,
                                                ConferenceStartDate = m.StartDate,
                                                ConferenceEndDate = m.EndDate,
                                                ConferenceLocationId = m.LocationId,
                                                ConferenceType = m.DictionaryConferenceType.DictionaryConferenceTypeName,
                                                ConferenceCategory = m.DictionaryConferenceCategory.DictionaryConferenceCategoryName,
                                                ConferenceMainSpeaker = m.ConferenceXspeaker
                                                                             .Where(x => x.IsMain)
                                                                             .Select(x => x.DictionarySpeaker.DictionarySpeakerName)
                                                                             .FirstOrDefault(),
                                                ConferenceLocation = m.Location.LocationAddress,
                                                SpeakerId = m.ConferenceXspeaker
                                                                    .Where(x => x.IsMain)
                                                                    .Select(x => x.DictionarySpeakerId)
                                                                    .FirstOrDefault(),
                                                ConferenceOrganiserEmail = m.OrganiserEmail
                                            }).ToList();

            return conferenceModels;
        }


        public SpeakerModel getSelectSpeakerDetails(int _speakerId)
        {
            List<DictionarySpeaker> speakers = dbContext.DictionarySpeaker
                                                    .Include(s => s.DictionaryCountry)
                                                    .ToList();
            SpeakerModel speakerModel = speakers
                                                  .Where(s => s.DictionarySpeakerId == _speakerId)
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

        public void InsertConference(ConferenceModel _model)
        {
            int conferenceTypeId = dbContext.DictionaryConferenceType
                                       .Where(d => d.DictionaryConferenceTypeName == _model.ConferenceType)
                                       .Select(d => d.DictionaryConferenceTypeId)
                                       .FirstOrDefault();

            var conference = new Conference
            {
                ConferenceName = _model.ConferenceName, 
                StartDate = _model.ConferenceStartDate, 
                EndDate = _model.ConferenceEndDate, 
                OrganiserEmail = _model.ConferenceOrganiserEmail, 
                LocationId = Int32.Parse(_model.ConferenceLocation), 
                DictionaryConferenceTypeId = conferenceTypeId, 
                DictionaryConferenceCategoryId = Int32.Parse(_model.ConferenceCategory)
            };

            dbContext.Conference.Add(conference);
            dbContext.SaveChanges();
        }

        public void InsertConference(string _conferenceName, DateTime _startDate, DateTime _endDate, string _organiserEmail, int _locationId, int _conferenceTypeId, int _conferenceCategoryId)
        {

            var conference = new Conference
            {
                ConferenceName = _conferenceName,
                StartDate = _startDate,
                EndDate = _endDate,
                OrganiserEmail = _organiserEmail,
                LocationId = _locationId,
                DictionaryConferenceTypeId = _conferenceTypeId,
                DictionaryConferenceCategoryId = _conferenceCategoryId
            };

            dbContext.Conference.Add(conference);
            dbContext.SaveChanges();
        }

        public void InsertConference(ConferenceModel _model, int locationId)
        {
            int conferenceTypeId = dbContext.DictionaryConferenceType
                           .Where(d => d.DictionaryConferenceTypeName == _model.ConferenceType)
                           .Select(d => d.DictionaryConferenceTypeId)
                           .FirstOrDefault();

            var conference = new Conference
            {
                ConferenceName = _model.ConferenceName,
                StartDate = _model.ConferenceStartDate,
                EndDate = _model.ConferenceEndDate,
                OrganiserEmail = _model.ConferenceOrganiserEmail,
                LocationId = locationId,
                DictionaryConferenceTypeId = conferenceTypeId,
                DictionaryConferenceCategoryId = Int32.Parse(_model.ConferenceCategory)
            };

            dbContext.Conference.Add(conference);
            dbContext.SaveChanges();
        }

        public void InsertConferenceXSpeaker(ConferenceModel _model, int _speakerId)
        {
            var conferenceXSpeaker = new ConferenceXspeaker
            {
                DictionarySpeakerId = _speakerId,
                ConferenceId = _model.ConferenceId,
                IsMain = true
            };

            dbContext.ConferenceXspeaker.Add(conferenceXSpeaker);
            dbContext.SaveChanges();
        }

        public void InsertConferenceXSpeaker(int _conferenceId, int _speakerId)
        {
            var conferenceXSpeaker = new ConferenceXspeaker
            {
                DictionarySpeakerId = _speakerId,
                ConferenceId = _conferenceId,
                IsMain = true
            };

            dbContext.ConferenceXspeaker.Add(conferenceXSpeaker);
            dbContext.SaveChanges();
        }



        public void InsertParticipant(int _conferenceId, string _spectatorEmail, int _spectatorCode)
        {
            var conferenceAttendance = new ConferenceAttendance
            {
                ConferenceId = _conferenceId, 
                ParticipantEmailAddress = _spectatorEmail, 
                DictionaryParticipantStatusId = 2, 
                ParticipationCode = null
            };

            dbContext.ConferenceAttendance.Add(conferenceAttendance);
            dbContext.SaveChanges();
        }


        public void ModifySpectatorStatusJoin(string _spectatorEmail, int _conferenceId)
        {
            var entryToUpdate = dbContext.ConferenceAttendance.FirstOrDefault(a => a.ConferenceId == _conferenceId && a.ParticipantEmailAddress == _spectatorEmail);
            
            if (entryToUpdate != null)
            {
                entryToUpdate.DictionaryParticipantStatusId = 1;

                dbContext.ConferenceAttendance.Update(entryToUpdate);
                dbContext.SaveChanges();
            }
        }

        public void ModifySpectatorStatusAttend(string _spectatorEmail, int _conferenceId)
        {
            var entryToUpdate = dbContext.ConferenceAttendance.FirstOrDefault(a => a.ConferenceId == _conferenceId && a.ParticipantEmailAddress == _spectatorEmail);

            if (entryToUpdate != null)
            {
                entryToUpdate.DictionaryParticipantStatusId = 2;

                dbContext.ConferenceAttendance.Update(entryToUpdate);
                dbContext.SaveChanges();
            }
        }

        public void ModifySpectatorStatusWithdraw(string _spectatorEmail, int _conferenceId)
        {
            var entryToUpdate = dbContext.ConferenceAttendance.FirstOrDefault(a => a.ConferenceId == _conferenceId && a.ParticipantEmailAddress == _spectatorEmail);

            if (entryToUpdate != null)
            {
                entryToUpdate.DictionaryParticipantStatusId = 3;

                dbContext.ConferenceAttendance.Update(entryToUpdate);
                dbContext.SaveChanges();
            }
        }
        public int GetLastConferenceId()
        {
            List<Conference> conferences = dbContext.Conference.ToList();

            Conference conference = conferences.Last();

            return conference.ConferenceId;
        }

        public void updateConference(int conferenceId, string conferenceName, string startDate, string endDate, int categoryId, int typeId)
        {
            DateTime _startDate = Convert.ToDateTime(startDate);
            DateTime _endDate = Convert.ToDateTime(endDate);
            Conference conferenceEdited = new Conference();
            conferenceEdited = dbContext.Conference.Find(conferenceId);
            conferenceEdited.ConferenceName = conferenceName;
            conferenceEdited.StartDate = _startDate;
            conferenceEdited.EndDate = _endDate;
            conferenceEdited.DictionaryConferenceCategoryId = categoryId;
            conferenceEdited.DictionaryConferenceTypeId = typeId;
            Console.WriteLine(_startDate);
            Console.WriteLine(_endDate);
            Console.WriteLine(conferenceEdited.DictionaryConferenceCategoryId);
            dbContext.SaveChanges();
        }

        public void updateConference(int conferenceId, string conferenceName, string startDate, string endDate)
        {
            //implementare
        }
    }
}
