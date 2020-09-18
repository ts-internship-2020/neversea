using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferencePlanner.Repository.Ef.Repository
{
    public class ConferenceXSpeakerRepository : IConferenceXSpeakerRepository
    {
        private readonly neverseaContext _dbContext;

        public ConferenceXSpeakerRepository(neverseaContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void AddSpeaker(int conferenceId, int speakerId, bool isMain)
        {
            List<ConferenceXspeaker> conferenceXspeakers = new List<ConferenceXspeaker>();
            //List<ConferenceXSpeakerModel> model = new List<ConferenceXSpeakerModel>();

            conferenceXspeakers = _dbContext.ConferenceXspeaker.ToList();
            _dbContext.ConferenceXspeaker.Add(new ConferenceXspeaker
            {
                ConferenceId = conferenceId,
                DictionarySpeakerId = speakerId,
                IsMain = isMain
            });
            _dbContext.SaveChanges();

        }
        public void updateConferenceXSpeaker(int conferenceId, int speakerId)
        {
            Console.WriteLine("In update speaker am primit speaker ID " + speakerId.ToString());
            ConferenceXspeaker editedRow = _dbContext.ConferenceXspeaker.Where(c => c.ConferenceId == conferenceId).FirstOrDefault();
            Console.WriteLine("Update speaker pentru conferinta nr : " + editedRow.ConferenceId);
            _dbContext.Remove(editedRow);
            _dbContext.SaveChanges();

            _dbContext.ConferenceXspeaker.Add(new ConferenceXspeaker
            {
                ConferenceId = conferenceId,
                DictionarySpeakerId = speakerId,
                IsMain = true
            });
            _dbContext.SaveChanges();
        }
    }
}
