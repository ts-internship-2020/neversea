using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
   public interface IConferenceLocationRepository
    {

        public void InsertLocation(int CityId, string address);
        public int GetLocationId(int CityId, string locationAddress);
        public void UpdateLocation(int cityId, string address, int newCityId, string newAddress);

    }
}
