using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface ICountryRepository
    {
        public List<CountryModel> GetCountry();
        public List<CountryModel> GetCountry(string keyword);
      //  void ModifyCountry(int countryId);
        void DeleteCountry(int countryId);
       // void InsertCountry(int countryId, string countryName, string countryCode, string nationality);
        void UpdateCountry(int countryId, string countryName, string countryCode, string nationality);
        void InsertCountry(string countryName, string countryCode, string nationality);
    }
}
