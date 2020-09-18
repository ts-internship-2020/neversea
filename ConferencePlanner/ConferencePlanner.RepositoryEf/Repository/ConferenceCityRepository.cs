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
            cities = _dbContext.DictionaryCity
                .Where(dc => dc.DictionaryDistrictId == districtId)
                .ToList();

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
            cities = _dbContext.DictionaryCity
                .Where(dc => dc.DictionaryDistrictId == districtId)
                .Where(dc => dc.DictionaryCityName.Contains(keyword))
                .ToList();

            citiesModel = cities.Select(c => new ConferenceCityModel()
            {
                ConferenceCityId = c.DictionaryCityId,
                ConferenceCityName = c.DictionaryCityName
            }).ToList();

            return citiesModel;
        }

        public void UpdateCity(int index, string city, int districtId)
        {
            DictionaryCity cityEdited = _dbContext.DictionaryCity.Find(index);
            cityEdited.DictionaryCityName = city;
            cityEdited.DictionaryDistrictId = districtId;
            _dbContext.SaveChanges();
        }
            
        
        public void InsertCity(string city, int districtId)
        {
            int id = 0;
            List<DictionaryCity> cities = new List<DictionaryCity>();
            cities = _dbContext.DictionaryCity.ToList();
            id = cities.Max(d => d.DictionaryCityId);
            id += 1;

            _dbContext.DictionaryCity.Add(new DictionaryCity()
            {
                DictionaryCityId = id,
                DictionaryCityName = city,
                DictionaryDistrictId = districtId
            });

            _dbContext.SaveChanges();

        }
        public void DeleteCity(int cityId,int districtId)
        {
            
            DictionaryCity cityDeleted = _dbContext.DictionaryCity
                            .Where(c => c.DictionaryCityId == cityId)
                            .Where(c=>c.DictionaryDistrictId==districtId)
                            .FirstOrDefault();
            _dbContext.DictionaryCity.Remove(cityDeleted);

            _dbContext.SaveChanges();
        }
    }
}
