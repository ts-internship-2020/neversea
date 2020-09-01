using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class DictionaryCountry
    {
        public DictionaryCountry()
        {
            DictionaryDistrict = new HashSet<DictionaryDistrict>();
            DictionarySpeaker = new HashSet<DictionarySpeaker>();
        }

        public int DictionaryCountryId { get; set; }
        public string DictionaryCountryName { get; set; }
        public string DictionaryCountryCode { get; set; }
        public string DictionaryCountryNationality { get; set; }

        public virtual ICollection<DictionaryDistrict> DictionaryDistrict { get; set; }
        public virtual ICollection<DictionarySpeaker> DictionarySpeaker { get; set; }
    }
}
