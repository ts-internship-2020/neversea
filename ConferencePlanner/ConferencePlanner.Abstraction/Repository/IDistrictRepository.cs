using System;
using System.Collections.Generic;
using ConferencePlanner.Abstraction.Model;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface IDistrictRepository
    {
        public List<DistrictModel> GetDistrict();
        public List<DistrictModel> GetDistrict(string keyword);
        void ModifyDistrict(int countryId);
        void DeleteDistrict(int countryId);
        void InsertDistrict(int countryId, string countryName);
    }
}
