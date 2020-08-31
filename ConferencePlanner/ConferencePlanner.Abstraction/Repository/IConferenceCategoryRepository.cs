using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
   public interface IConferenceCategoryRepository
    {
        public List<ConferenceCategoryModel> GetConferenceCategories();
        public List<ConferenceCategoryModel> GetConferenceCategories(string searchKey);

        public void UpdateConferenceCategory(int conferenceCategoryId, string conferenceCategoryName);
        public void InsertConferenceCategory(string conferenceCategoryName);
        public void DeleteConferenceCategory(int conferenceCategoryId);


    }
}

