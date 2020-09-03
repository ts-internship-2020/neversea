using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferencePlanner.Repository.Ef.Repository
{
    public class GetDemoRepository : IGetDemoRepository
    {
        private readonly neverseaContext _dbContext;

        public GetDemoRepository(neverseaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<DemoModel> GetDemo(string name)
        {
            List<Conference> conferences = new List<Conference>();
             conferences = _dbContext.Conference.Include(a=>a.DictionaryConferenceType).ToList();
            //List<Conference> demos = _dbContext.Conference.FirstOrDefault();

            List<DemoModel> demoModels = conferences.Select(a => new DemoModel() { Id = a.DictionaryConferenceType.DictionaryConferenceTypeId, Name = a.DictionaryConferenceType.DictionaryConferenceTypeName }).ToList();

            return demoModels;
        }
    }
}
