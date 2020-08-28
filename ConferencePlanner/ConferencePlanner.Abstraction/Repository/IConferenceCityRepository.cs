using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface IConferenceCityRepository
    {
        public List<ConferenceCityModel> GetConferenceCities(int districtId);
        public List<ConferenceCityModel> GetConferenceCities(int districtId, string keyword);
        public void updateCity(int index, string city, int districtId);
        public void insertCity(string city, int districtId);
    }
}
