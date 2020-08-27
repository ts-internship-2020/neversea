﻿using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface IConferenceCityRepository
    {
        public List<ConferenceCityModel> GetConferenceCities(int districtId);
    }
}
