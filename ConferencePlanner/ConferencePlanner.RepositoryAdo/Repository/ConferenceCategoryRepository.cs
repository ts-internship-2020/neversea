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

        public void DeleteConferenceCategory(int conferenceCategoryId)
        {
            SqlCommand sqlCommand = new SqlCommand("spConferenceCategories_Delete", sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.Add(new SqlParameter("@DictionaryConferenceCategoryId", conferenceCategoryId));

            sqlCommand.ExecuteNonQuery();
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

            sqlDataReader.Close();
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

            sqlDataReader.Close();
            return conferenceCategories;

        }

        public void InsertConferenceCategory(string conferenceCategoryName)
        {
            SqlCommand sqlCommandMaxId = sqlConnection.CreateCommand();
            sqlCommandMaxId.CommandText = $"SELECT MAX(DictionaryConferenceCategoryId) AS DictionaryConferenceCategoryId " +
                    $"                     FROM DictionaryConferenceCategory";
            SqlDataReader sqlDataReaderMaxId = sqlCommandMaxId.ExecuteReader();

            if (sqlDataReaderMaxId.HasRows)
            {
                sqlDataReaderMaxId.Read();
                int insertedId = sqlDataReaderMaxId.GetInt32("DictionaryConferenceCategoryId") + 1;

                SqlCommand sqlCommandInsert = new SqlCommand("spConferenceCategories_Insert", sqlConnection);
                sqlCommandInsert.CommandType = CommandType.StoredProcedure;

                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryConferenceCategoryId", insertedId));
                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryConferenceCategoryName", conferenceCategoryName));

                sqlCommandInsert.ExecuteNonQuery();
            }
            else
            {
                int insertedId = 1;

                SqlCommand sqlCommandInsert = new SqlCommand("spConferenceCategories_Insert", sqlConnection);
                sqlCommandInsert.CommandType = CommandType.StoredProcedure;

                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryConferenceCategoryId", insertedId));
                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryConferenceCategoryName", conferenceCategoryName));

                sqlCommandInsert.ExecuteNonQuery();
            }
        }

        public void UpdateConferenceCategory(int conferenceCategoryId, string conferenceCategoryName)
        {
            SqlCommand sqlCommand = new SqlCommand("spConferenceCategories_Update", sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.Add(new SqlParameter("@DictionaryConferenceCategoryId", conferenceCategoryId));
            sqlCommand.Parameters.Add(new SqlParameter("@DictionaryConferenceCategoryName", conferenceCategoryName));


            sqlCommand.ExecuteNonQuery();
        }
    }
}
