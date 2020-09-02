using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace ConferencePlanner.Repository.Ef.Repository
{
    public class GetDemoRepository : IGetDemoRepository
    {
        private readonly neverseaContext _neverseaContext;

        public GetDemoRepository(neverseaContext dbContext)
        {
            _neverseaContext = dbContext;
        }

        public List<DemoModel> GetDemo(string name)
        {
            List<Demo> demos = _neverseaContext.Demo.ToList();
            List<Conference> conferences = _neverseaContext.Conference.Include(x => x.ConferenceXspeaker).ToList(); //join Include
            List<DemoModel> demoModels = demos.Select(a => new DemoModel() { Id = a.Id, Name = a.Name }).ToList();
            Conference conference = _neverseaContext.Conference.FirstOrDefault();
            return demoModels;
        }
    }
}
