using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace ConferencePlanner.Repository.Ef.Repository
{
    public class ConferenceSpeakerRepository : IConferenceSpeakerRepository
    {

        private readonly neverseaContext _dbContext;

        public ConferenceSpeakerRepository(neverseaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<SpeakerModel> GetConferenceSpeakers()
        {
            List<DictionarySpeaker> speakers = _dbContext.DictionarySpeaker
                                    .Include(s => s.DictionaryCountry)
                                        .ToList();
            List<SpeakerModel> speakerModels = speakers.Select(c => new SpeakerModel()
            {
                DictionarySpeakerId = c.DictionarySpeakerId,
                DictionarySpeakerName = c.DictionarySpeakerName,
                DictionarySpeakerRating = c.DictionarySpeakerRating,
                DictionarySpeakerImage = c.DictionarySpeakerImage,
                DictionarySpeakerNationality = c.DictionaryCountry.DictionaryCountryNationality
            }).ToList();
            return speakerModels;
        }
        public List<SpeakerModel> GetConferenceSpeakers(string keyword)
        {
            List<DictionarySpeaker> speakers = _dbContext.DictionarySpeaker
                        .Include(s => s.DictionaryCountry)
                        .Where(c => c.DictionarySpeakerName
                            .Contains(keyword))
                        .ToList();
            List<SpeakerModel> speakerModels = speakers.Select(c => new SpeakerModel()
            {
                DictionarySpeakerId = c.DictionarySpeakerId,
                DictionarySpeakerName = c.DictionarySpeakerName,
                DictionarySpeakerRating = c.DictionarySpeakerRating,
                DictionarySpeakerImage = c.DictionarySpeakerImage,
                DictionarySpeakerNationality = c.DictionaryCountry.DictionaryCountryNationality
            }).ToList();
            return speakerModels;
        }
        public void DeleteSpeaker(int speakerId)
        {
            DictionarySpeaker speakerDeleted = _dbContext.DictionarySpeaker
                            .Where(s => s.DictionarySpeakerId == speakerId)
                            .FirstOrDefault();
            _dbContext.DictionarySpeaker.Remove(speakerDeleted);

            _dbContext.SaveChanges();
        }
        public void InsertSpeaker(string speakerName, string speakerNationality, double speakerRating, string speakerImage)
        {
            int id = 0;
            List<DictionarySpeaker> speakers = new List<DictionarySpeaker>();
            speakers = _dbContext.DictionarySpeaker.ToList();
            id = speakers.Max(d => d.DictionarySpeakerId);
            id += 1;

            int countryId = _dbContext.DictionaryCountry
                        .Where(c => c.DictionaryCountryNationality == speakerNationality)
                        .Select(c => c.DictionaryCountryId)
                        .FirstOrDefault();

            _dbContext.DictionarySpeaker.Add(new DictionarySpeaker()
            {
               DictionarySpeakerId = id,
               DictionarySpeakerName = speakerName,
               DictionaryCountryId = countryId,
               DictionarySpeakerRating = speakerRating,
               DictionarySpeakerImage = speakerImage

            });
            _dbContext.SaveChanges();
        }

        public void UpdateSpeaker(int speakerId, string speakerName, string speakerNationality, double speakerRating, string speakerImage)
        {
            int countryId = _dbContext.DictionaryCountry
                            .Where(c => c.DictionaryCountryNationality == speakerNationality)
                            .Select(c => c.DictionaryCountryId)
                            .FirstOrDefault();
            
            DictionarySpeaker speakerEdited = _dbContext.DictionarySpeaker.Find(speakerId);
            speakerEdited.DictionarySpeakerName = speakerName;
            speakerEdited.DictionaryCountryId = countryId;
            speakerEdited.DictionarySpeakerRating = speakerRating;
            speakerEdited.DictionarySpeakerImage = speakerImage;
            _dbContext.SaveChanges();
        }

    }
}
