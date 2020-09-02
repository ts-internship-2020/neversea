using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferencePlanner.Repository.Ef.Repository
{
   public class AdminRepository : IAdminRepository
    {
        private readonly neverseaContext _dbContext;

        public AdminRepository(neverseaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<AdminModel> GetAdmins()
        {
            List<Admin> admins = new List<Admin>();
            List<AdminModel> adminModel = new List<AdminModel>();
            admins = _dbContext.Admin.ToList();

            adminModel = admins.Select(a => new AdminModel()
            {
                AdminId = a.AdminId,
                AdminEmail = a.AdminEmail
            }).ToList();


            return adminModel;
        }
    }
}
