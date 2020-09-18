using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
   public class LocationModel
    {   
        public int LocationId { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }  
        public int DictionaryCityId { get; set; }
        public string LocationAddress { get; set; }

    }
}
