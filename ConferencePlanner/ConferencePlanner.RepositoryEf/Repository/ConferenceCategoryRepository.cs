using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferencePlanner.Repository.Ef.Repository
{
   public class ConferenceCategoryRepository : IConferenceCategoryRepository
    {

        private readonly neverseaContext _dbContext;

        public ConferenceCategoryRepository(neverseaContext dbContext)
        {
            _dbContext = dbContext;
        }



        public void DeleteConferenceCategory(int conferenceCategoryId)
        {



            List<DictionaryConferenceCategory> dictionaryConferenceCategories = new List<DictionaryConferenceCategory>();
            dictionaryConferenceCategories = _dbContext.DictionaryConferenceCategory.Select(a => new DictionaryConferenceCategory()
            {
                DictionaryConferenceCategoryId = a.DictionaryConferenceCategoryId,
                DictionaryConferenceCategoryName = a.DictionaryConferenceCategoryName
            }).Where(a => a.DictionaryConferenceCategoryId == conferenceCategoryId).ToList();

            List<ConferenceCategoryModel> conferences = dictionaryConferenceCategories.Select(a => new ConferenceCategoryModel()
            {
                conferenceCategoryId = a.DictionaryConferenceCategoryId,
                conferenceCategoryName = a.DictionaryConferenceCategoryName
            }).Where(a => a.conferenceCategoryId == conferenceCategoryId).ToList();

            
            DictionaryConferenceCategory conferenceCategory = new DictionaryConferenceCategory();

            _dbContext.Remove(dictionaryConferenceCategories[0]);
            _dbContext.SaveChanges();

        }

        public List<ConferenceCategoryModel> GetConferenceCategories()
        {
            List<DictionaryConferenceCategory> dictionaryConferenceCategories = new List<DictionaryConferenceCategory>();
            dictionaryConferenceCategories = _dbContext.DictionaryConferenceCategory.ToList();

            List<ConferenceCategoryModel> conferenceCategoryModels = dictionaryConferenceCategories.Select(a => new ConferenceCategoryModel() { conferenceCategoryId = a.DictionaryConferenceCategoryId, conferenceCategoryName = a.DictionaryConferenceCategoryName }).ToList();
            return conferenceCategoryModels;
        }

        public List<ConferenceCategoryModel> GetConferenceCategories(string searchKey)
        {

            List<DictionaryConferenceCategory> dictionaryConferenceCategories = new List<DictionaryConferenceCategory>();
            dictionaryConferenceCategories = _dbContext.DictionaryConferenceCategory.Where(c => c.DictionaryConferenceCategoryName.Contains(searchKey)).ToList();

            List<ConferenceCategoryModel> conferenceCategoryModels = dictionaryConferenceCategories.Select(a => new ConferenceCategoryModel() { conferenceCategoryId = a.DictionaryConferenceCategoryId, conferenceCategoryName = a.DictionaryConferenceCategoryName }).ToList();
            return conferenceCategoryModels;
      
        }

        public void InsertConferenceCategory(string conferenceCategoryName)
        {

            int id = 0;
            List<DictionaryConferenceCategory> dictionaryConferenceCategories = new List<DictionaryConferenceCategory>();
            dictionaryConferenceCategories = _dbContext.DictionaryConferenceCategory.ToList();
            id = dictionaryConferenceCategories.Max(a => a.DictionaryConferenceCategoryId);
           id = id + 1;

            _dbContext.DictionaryConferenceCategory.Add(new DictionaryConferenceCategory()
            {
                DictionaryConferenceCategoryId = id,
                DictionaryConferenceCategoryName = conferenceCategoryName
            });
            _dbContext.SaveChanges();


        }

        public void UpdateConferenceCategory(int conferenceCategoryId, string conferenceCategoryName)
        {

            var dictionaryConferenceCategory = _dbContext.DictionaryConferenceCategory.Where(a => a.DictionaryConferenceCategoryId == conferenceCategoryId).FirstOrDefault<DictionaryConferenceCategory>();
            if(dictionaryConferenceCategory != null)
            {
                dictionaryConferenceCategory.DictionaryConferenceCategoryName = conferenceCategoryName;
                _dbContext.SaveChanges();
            }


        }
    }
}
