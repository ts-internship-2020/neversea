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
    public class ConferenceCityRepository : IConferenceCityRepository
    {
        private readonly neverseaContext _dbContext;

        public ConferenceCityRepository(neverseaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ConferenceCityModel> GetConferenceCities(int districtId)
        {
            List<DictionaryCity> cities = new List<DictionaryCity>();
            List<ConferenceCityModel> citiesModel = new List<ConferenceCityModel>();
            cities = _dbContext.DictionaryCity.ToList();

            citiesModel = cities.Select(c => new ConferenceCityModel()
            {
                ConferenceCityId = c.DictionaryCityId,
                ConferenceCityName = c.DictionaryCityName
            }).ToList();


            return citiesModel;
        }
        public List<ConferenceCityModel> GetConferenceCities(int districtId, string keyword)
        {
            List<DictionaryCity> cities = new List<DictionaryCity>();
            List<ConferenceCityModel> citiesModel = new List<ConferenceCityModel>();
            cities = _dbContext.DictionaryCity.ToList();

            citiesModel = cities.Select(c => new ConferenceCityModel()
            {
                ConferenceCityId = c.DictionaryCityId,
                ConferenceCityName = c.DictionaryCityName
            }).ToList();


            return citiesModel;
        }
        public void updateCity(int index, string city, int districtId)
        {

        }
        public void insertCity(string city, int districtId)
        {

        }
        public void DeleteCity(int cityId, int districtId)
        {

        }
    }
}
