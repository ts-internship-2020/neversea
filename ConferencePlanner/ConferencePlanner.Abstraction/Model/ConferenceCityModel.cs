using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
    public class ConferenceCityModel
    {
        public string ConferenceCityName { get; set; }
        public int ConferenceCityId { get; set; }
        public int ConferenceDistrictId { get; set; }
        public override string ToString()
        {
            return ConferenceCityName;
        }
    }
}
