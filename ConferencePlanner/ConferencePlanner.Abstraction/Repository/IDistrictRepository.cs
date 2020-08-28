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
    }
}
