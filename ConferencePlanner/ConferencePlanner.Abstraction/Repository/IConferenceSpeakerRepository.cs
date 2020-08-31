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
        //public void updateSpeaker(int index, string city, int districtId);
        //public void insertSpeaker(string city, int districtId);
        public List<SpeakerModel> GetConferenceSpeakers(string keyword);
        void DeleteSpeaker(int speakerId);
        public void InsertSpeaker(string speakerName, string speakerNationality, float speakerRating, string speakerImage);

        public void UpdateSpeaker(int speakerId, string speakerName, string speakerNationality, float speakerRating, string speakerImage);
    }
}
