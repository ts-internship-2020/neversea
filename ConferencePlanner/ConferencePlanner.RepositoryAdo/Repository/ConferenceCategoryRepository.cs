using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class ConferenceCategoryRepository : IConferenceCategoryRepository
    {


        private readonly SqlConnection sqlConnection;

        public ConferenceCategoryRepository(SqlConnection SqlConnection)
        {
            sqlConnection = SqlConnection;
        }

            public List<ConferenceCategoryModel> GetConferenceCategories()
        {

            List<ConferenceCategoryModel> conferenceCategories = new List<ConferenceCategoryModel>();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT DictionaryConferenceCategoryId, DictionaryConferenceCategoryName" +
                                     " FROM DictionaryConferenceCategory";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    conferenceCategories.Add(new ConferenceCategoryModel()
                    {
                        conferenceCategoryName = sqlDataReader.GetString("DictionaryConferenceCategoryName"),
                        conferenceCategoryId = sqlDataReader.GetInt32("DictionaryConferenceCategoryId")
                    });
                }
            }


            return conferenceCategories;


        }
    }
}
