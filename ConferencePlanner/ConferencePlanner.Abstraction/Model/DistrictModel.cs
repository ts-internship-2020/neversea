﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
   public class DistrictModel
    {
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }

        public string DistrictCode { get; set; }
        public int CountryId { get; set; }
    }
}
