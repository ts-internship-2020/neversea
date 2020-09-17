using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
    public class CountryModel
    {
        public string CountryName { get; set; }
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CountryNationality { get; set; }
        public override string ToString()
        {
            return CountryName;
        }
    }
}
