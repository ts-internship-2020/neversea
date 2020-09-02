using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
namespace ConferencePlanner.Repository.Ef.Repository
{
    public class ConferenceCountryRepository : ICountryRepository
    {
        private readonly neverseaContext _dbContext;

        public ConferenceCountryRepository(neverseaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<CountryModel> GetCountry()
        {
            List<DictionaryCountry> countries = new List<DictionaryCountry>();
            List<CountryModel> countriesModel = new List<CountryModel>();
            countries = _dbContext.DictionaryCountry.ToList();

            countriesModel = countries.Select(c => new CountryModel()
            {
                CountryId = c.DictionaryCountryId,
                CountryName = c.DictionaryCountryName,
                CountryNationality = c.DictionaryCountryNationality,
                CountryCode = c.DictionaryCountryCode
            }).ToList();

            return countriesModel;

        }
        public List<CountryModel> GetCountry(string keyword)
        {
            List<DictionaryCountry> countries = new List<DictionaryCountry>();
            List<CountryModel> countriesModel = new List<CountryModel>();
            countries = _dbContext.DictionaryCountry.ToList();

            countriesModel = countries.Select(c => new CountryModel()
            {
                CountryId = c.DictionaryCountryId,
                CountryName = c.DictionaryCountryName,
                CountryNationality = c.DictionaryCountryNationality,
                CountryCode = c.DictionaryCountryCode
            }).ToList();

            return countriesModel;
        }
        public void DeleteCountry(int countryId)
        {

        }
        public void UpdateCountry(int countryId, string countryName, string countryCode, string nationality)
        {
             
        }
        public void InsertCountry(string countryName, string countryCode, string nationality)
        {

        }
    }
}
