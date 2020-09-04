using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferencePlanner.Repository.Ef.Repository
{
    public class ConferenceTypeRepository: IConferenceTypeRepository
    {

        private readonly neverseaContext _dbContext;

        public ConferenceTypeRepository(neverseaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteConferenceType(int conferenceTypeId)
        {
            List<DictionaryConferenceType> dictionaryConferenceTypes = new List<DictionaryConferenceType>();
            dictionaryConferenceTypes = _dbContext.DictionaryConferenceType.Select(a => new DictionaryConferenceType() { 
            DictionaryConferenceTypeId = a.DictionaryConferenceTypeId, DictionaryConferenceTypeName = a.DictionaryConferenceTypeName}).Where(a => a.DictionaryConferenceTypeId == conferenceTypeId).ToList();

            List<ConferenceTypeModel> maxIdConference = dictionaryConferenceTypes.Select(a => new ConferenceTypeModel()
            {
                conferenceTypeId = a.DictionaryConferenceTypeId,
                conferenceTypeName = a.DictionaryConferenceTypeName
            }).Where(a => a.conferenceTypeId == conferenceTypeId).ToList();

            ;
            DictionaryConferenceType conferenceType = new DictionaryConferenceType();
            
            _dbContext.Remove(dictionaryConferenceTypes[0]);
            _dbContext.SaveChanges();
         }


        public List<ConferenceTypeModel> getConferenceTypes()
        {

            List<DictionaryConferenceType> dictionaryConferenceTypes = new List<DictionaryConferenceType>();
            dictionaryConferenceTypes = _dbContext.DictionaryConferenceType.ToList();

            List<ConferenceTypeModel> conferenceTypeModels = dictionaryConferenceTypes.Select(a => new ConferenceTypeModel() {conferenceTypeId = a.DictionaryConferenceTypeId, conferenceTypeName = a.DictionaryConferenceTypeName }).ToList();
            return conferenceTypeModels;

        }

        public List<ConferenceTypeModel> getConferenceTypes(string keyword)
        {
            List<DictionaryConferenceType> dictionaryConferenceTypes = new List<DictionaryConferenceType>();
            dictionaryConferenceTypes = _dbContext.DictionaryConferenceType.Where(a => a.DictionaryConferenceTypeName.Contains(keyword)).ToList();

            List<ConferenceTypeModel> conferenceTypeModels = dictionaryConferenceTypes.Select(a => new ConferenceTypeModel() { conferenceTypeId = a.DictionaryConferenceTypeId, conferenceTypeName = a.DictionaryConferenceTypeName }).ToList();
            return conferenceTypeModels;
        }


        public void InsertConferenceType(string conferenceTypeName)
        {
            int id = 0;
            List<DictionaryConferenceType> dictionaryConferenceTypes = new List<DictionaryConferenceType>();
            dictionaryConferenceTypes = _dbContext.DictionaryConferenceType.ToList();
          
           id =  dictionaryConferenceTypes.Max(x => x.DictionaryConferenceTypeId);
            id += 1;
           

            _dbContext.DictionaryConferenceType.Add(new DictionaryConferenceType()
            {
                DictionaryConferenceTypeId = id,
                DictionaryConferenceTypeName = conferenceTypeName
            }) ;

            _dbContext.SaveChanges();


        }

        public void UpdateConferenceType(int conferenceTypeId, string conferenceTypeName)
        {
            //List<DictionaryConferenceType> dictionaryConferenceTypes = new List<DictionaryConferenceType>();
            var dictionaryConferenceTypes = _dbContext.DictionaryConferenceType.Where(a => a.DictionaryConferenceTypeId == conferenceTypeId).FirstOrDefault<DictionaryConferenceType>();
    
           if(dictionaryConferenceTypes != null)
            {
                dictionaryConferenceTypes.DictionaryConferenceTypeName = conferenceTypeName;
                _dbContext.SaveChanges();
            }
         
           
        }
    }
}
