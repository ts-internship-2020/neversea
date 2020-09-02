using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
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
            countries = _dbContext.DictionaryCountry
                .Where(c => c.DictionaryCountryName
                    .Contains(keyword))
                .ToList();

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
            DictionaryCountry countryDeleted = _dbContext.DictionaryCountry
                            .Where(c => c.DictionaryCountryId == countryId)
                            .FirstOrDefault();
            _dbContext.DictionaryCountry.Remove(countryDeleted);

            _dbContext.SaveChanges();
        }
        public void UpdateCountry(int countryId, string countryName, string countryCode, string nationality)
        {
            DictionaryCountry countryEdited = _dbContext.DictionaryCountry.Find(countryId);
            countryEdited.DictionaryCountryName = countryName;
            countryEdited.DictionaryCountryCode = countryCode;
            countryEdited.DictionaryCountryNationality = nationality;
            _dbContext.SaveChanges();
        }
        public void InsertCountry(string countryName, string countryCode, string nationality)
        {
            int id = 0;
            List<DictionaryCountry> countries = new List<DictionaryCountry>();
            countries = _dbContext.DictionaryCountry.ToList();
            id = countries.Max(c => c.DictionaryCountryId);
            id += 1;
            
            _dbContext.DictionaryCountry.Add(new DictionaryCountry()
            {
                DictionaryCountryId = id,
                DictionaryCountryName = countryName,
                DictionaryCountryCode = countryCode,
                DictionaryCountryNationality = nationality
            });

            _dbContext.SaveChanges();
        }
    }
}
