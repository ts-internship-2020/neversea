using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class DictionarySpeaker
    {
        public DictionarySpeaker()
        {
            ConferenceXspeaker = new HashSet<ConferenceXspeaker>();
        }

        public int DictionarySpeakerId { get; set; }
        public string DictionarySpeakerName { get; set; }
        public int DictionaryCountryId { get; set; }
        public float DictionarySpeakerRating { get; set; }
        public int? DictionarySpeakerRatingCount { get; set; }
        public string DictionarySpeakerImage { get; set; }
        public string DictionarySpeakerNationality { get; set; }

        public virtual DictionaryCountry DictionaryCountry { get; set; }
        public virtual ICollection<ConferenceXspeaker> ConferenceXspeaker { get; set; }
    }
}
