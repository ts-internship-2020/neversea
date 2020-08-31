using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface ICountryRepository
    {
        public List<CountryModel> GetCountry();
        public List<CountryModel> GetCountry(string keyword);
        void DeleteCountry(int countryId);
        void UpdateCountry(int countryId, string countryName, string countryCode, string nationality);
        void InsertCountry(string countryName, string countryCode, string nationality);
    }
}
