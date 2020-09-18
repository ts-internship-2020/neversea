using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferencePlanner.Repository.Ef.Repository
{
    public class ConferenceLocationRepository : IConferenceLocationRepository
    {
        private readonly neverseaContext dbContext;

        public ConferenceLocationRepository(neverseaContext _dbContext)
        {
            dbContext = _dbContext;
        }


        public int GetLocationId(int cityId, string locationAddress)
        {
            List<Location> locations = dbContext.Location.ToList();

            Location location = locations.Where(l => l.DictionaryCityId == cityId && l.LocationAddress == locationAddress).FirstOrDefault();

            return location.LocationId;
        }

        public void InsertLocation(int cityId, string address)
        {
            var location = new Location 
            {
                DictionaryCityId = cityId,
                LocationAddress = address
            };

            dbContext.Location.Add(location);
            dbContext.SaveChanges();
        }
        public void updateLocation(int locationId, int cityId, string address)
        {
            Location newLocation = new Location();
            newLocation = dbContext.Location.Find(locationId);
            newLocation.DictionaryCityId = cityId;
            newLocation.LocationAddress = address;
            dbContext.SaveChanges();
        }
    }
}
