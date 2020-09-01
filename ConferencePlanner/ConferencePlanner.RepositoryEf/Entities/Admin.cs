using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class Admin
    {
        public int AdminId { get; set; }
        public string AdminEmail { get; set; }
    }
}
