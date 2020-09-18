using System;
using System.Collections.Generic;
using ConferencePlanner.Abstraction.Model;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface IDistrictRepository
    {
        public List<DistrictModel> GetDistricts();
        public List<DistrictModel> GetDistricts(string keyword);

        public void InsertDistrict(string districtName, string districtCode, int countryId);
        public void UpdateDistrict(int districtId, string districtName, string districtCode, int countryId);
        public void DeleteDistrict(int districtId, int countryId);
        public List<DistrictModel> GetDistrictsByCountryId(int key);
    }
}
