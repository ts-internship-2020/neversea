using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface IGetDemoRepository
    {
        List<Demo> GetDemo(string name);
    }
}
