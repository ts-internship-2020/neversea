using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferencePlanner.Repository.Ef.Repository
{
    public class ConferenceDistrictRepository : IDistrictRepository
    {
        private readonly neverseaContext _dbContext;

        public ConferenceDistrictRepository(neverseaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<DistrictModel> GetDistricts()
        {
            List<DictionaryDistrict> districts = new List<DictionaryDistrict>();
            List<DistrictModel> districtsModel = new List<DistrictModel>();
            districts = _dbContext.DictionaryDistrict.ToList();

            districtsModel = districts.Select(d => new DistrictModel()
            {
                DistrictId = d.DictionaryDistrictId,
                DistrictName = d.DictionaryDistrictName,
                DistrictCode = d.DictionaryDistrictCode
            }).ToList();


            return districtsModel;
        }
        public List<DistrictModel> GetDistricts(string keyword)
        {
            List<DictionaryDistrict> districts = new List<DictionaryDistrict>();
            List<DistrictModel> districtsModel = new List<DistrictModel>();
            districts = _dbContext.DictionaryDistrict.Where(d => d.DictionaryDistrictCode.Contains(keyword) || d.DictionaryDistrictName.Contains(keyword)).ToList();

            districtsModel = districts.Select(d => new DistrictModel()
            {
                DistrictId = d.DictionaryDistrictId,
                DistrictName = d.DictionaryDistrictName,
                DistrictCode = d.DictionaryDistrictCode
            }).ToList();


            return districtsModel;
        }
        public void UpdateDistrict(int districtId, string districtName, string districtCode, int countryId)
        {
            List<DictionaryDistrict> districts = new List<DictionaryDistrict>();
            
            districts = _dbContext.DictionaryDistrict.ToList();
            var existingDistrict = _dbContext.DictionaryDistrict.Where(d => d.DictionaryDistrictId == districtId).FirstOrDefault<DictionaryDistrict>();
            if (existingDistrict != null)
            {
                existingDistrict.DictionaryDistrictName = districtName;
                existingDistrict.DictionaryDistrictCode = districtCode;
                existingDistrict.DictionaryCountryId = countryId;
                _dbContext.SaveChanges();
            }
           
            

        }
        public void InsertDistrict(string districtName, string districtCode, int countryId)
        {
            int id = 0;
            List<DictionaryDistrict> districts = new List<DictionaryDistrict>();
            districts = _dbContext.DictionaryDistrict.ToList();
            id = districts.Max(d => d.DictionaryDistrictId);
            id ++;

            _dbContext.DictionaryDistrict.Add(new DictionaryDistrict()
            {
                DictionaryDistrictId = id,
                DictionaryDistrictName = districtName,
                DictionaryDistrictCode=districtCode,
                DictionaryCountryId=countryId
            }) ;

            _dbContext.SaveChanges();
        }

 
        public void DeleteDistrict(int districtId, int countryId)
        {
            List<DictionaryDistrict> dictionaryDistrict = new List<DictionaryDistrict>();

            dictionaryDistrict = _dbContext.DictionaryDistrict.Select(d => new DictionaryDistrict()
            {

                DictionaryDistrictId = d.DictionaryDistrictId,
                DictionaryCountryId = d.DictionaryCountryId
            }).Where(d => d.DictionaryDistrictId == districtId && d.DictionaryCountryId==countryId).ToList();

            List<DistrictModel> maxId = dictionaryDistrict.Select(d => new DistrictModel()

            {
                DistrictId = d.DictionaryDistrictId,
                DistrictName = d.DictionaryDistrictName
            }).Where(d => d.DistrictId == districtId).ToList();

            DictionaryDistrict district = new DictionaryDistrict();
            _dbContext.Remove(dictionaryDistrict[0]);

            _dbContext.SaveChanges();
        }
    }
}
