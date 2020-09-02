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

        }
        public void InsertSpeaker(string speakerName, string speakerNationality, float speakerRating, string speakerImage)
        {

        }

        public void UpdateSpeaker(int speakerId, string speakerName, string speakerNationality, float speakerRating, string speakerImage)
        {

        }

    }
}
