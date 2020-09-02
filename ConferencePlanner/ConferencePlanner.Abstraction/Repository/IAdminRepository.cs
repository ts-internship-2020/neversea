using System;
using System.Collections.Generic;
using ConferencePlanner.Abstraction.Model;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface IAdminRepository
    {
        public List<AdminModel> GetAdmins();
    }
}
