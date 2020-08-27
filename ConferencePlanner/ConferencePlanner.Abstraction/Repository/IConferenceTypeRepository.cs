using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface IConferenceTypeRepository
    {
        public List<ConferenceTypeModel> getConferenceTypes();
        public List<ConferenceTypeModel> getConferenceTypes(string keyword);


    }
}
