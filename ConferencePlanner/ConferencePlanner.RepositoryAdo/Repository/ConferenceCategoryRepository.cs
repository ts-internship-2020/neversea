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

        public List<ConferenceCategoryModel> GetConferenceCategories(string searchKey)
        {
            List<ConferenceCategoryModel> conferenceCategories = new List<ConferenceCategoryModel>();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();


            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Key", searchKey);

            sqlCommand.Parameters.Add(parameters[0]);


            sqlCommand.CommandText = "exec spCategories_GetByKeyWord @Key";
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
