using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
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
                DistrictCode=d.DictionaryDistrictCode
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
                 DistrictId= d.DictionaryDistrictId,
                DistrictName = d.DictionaryDistrictName,
                DistrictCode=d.DictionaryDistrictCode
            }).ToList();


            return districtsModel;
        }
        public void UpdateDistrict(int districtId, string districtName, string districtCode, int countryId)
        {

        }
        public void InsertDistrict(string districtName, string districtCode, int countryId)
        {

        }
        public void DeleteDistrict(int districtId, int countryId)
        {

        }
    }
}
