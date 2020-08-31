using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface IConferenceSpeakerRepository
    {
        public List<SpeakerModel> GetConferenceSpeakers();
        //public void updateSpeaker(int speakerId, string speakerName, string speakerNationality, float speakerRating, string speakerImage);
        //public void insertSpeaker(string speakerName, string speakerNationality, float speakerRating, string speakerImage);
        public List<SpeakerModel> GetConferenceSpeakers(string keyword);
    }
}
