using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class ConferenceSpeakerRepository : IConferenceSpeakerRepository
    {
        private readonly SqlConnection sqlConnection;

        public ConferenceSpeakerRepository(SqlConnection SqlConnection)
        {
            sqlConnection = SqlConnection;
        }

        public List<SpeakerModel> GetConferenceSpeakers()
        {
            List<SpeakerModel> speakers = new List<SpeakerModel>();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"select ds.DictionarySpeakerId, ds.DictionarySpeakerName, dc.DictionaryCountryNationality, ds.DictionarySpeakerRating, ds.DictionarySpeakerImage " +
                                    "FROM DictionarySpeaker ds " +
                                    "JOIN DictionaryCountry dc " +
                                    "ON ds.DictionaryCountryId = dc.DictionaryCountryId ";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    speakers.Add(new SpeakerModel()
                    {
                        DictionarySpeakerId = sqlDataReader.GetInt32("DictionarySpeakerId"),
                        DictionarySpeakerName = sqlDataReader.GetString("DictionarySpeakerName"),
                        DictionarySpeakerNationality = sqlDataReader.GetString("DictionaryCountryNationality"),
                        DictionarySpeakerRating = (float)sqlDataReader.GetDouble("DictionarySpeakerRating"),
                        DictionarySpeakerImage = sqlDataReader.GetString("DictionarySpeakerImage"),
                    });
                }
            }
            return speakers;
        }

        public void UpdateSpeaker(int speakerId, string speakerName, string speakerNationality, float speakerRating, string speakerImage)
        {

            SqlCommand sqlCommand = new SqlCommand("spSpeakers_Update", sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.Add(new SqlParameter("@DictionarySpeakerId", speakerId));
            sqlCommand.Parameters.Add(new SqlParameter("@DictionarySpeakerName", speakerName));
            sqlCommand.Parameters.Add(new SqlParameter("@DictionaryCountryNationality", speakerNationality));
            sqlCommand.Parameters.Add(new SqlParameter("@DictionarySpeakerRating", speakerRating));
            sqlCommand.Parameters.Add(new SqlParameter("@DictionarySpeakerImage", speakerImage));

            sqlCommand.ExecuteNonQuery();
        }

        public void InsertSpeaker(string speakerName, string speakerNationality, float speakerRating, string speakerImage)
        {
            SqlCommand sqlCommandMaxId = sqlConnection.CreateCommand();
            sqlCommandMaxId.CommandText = $"SELECT MAX(DictionarySpeakerId) AS DictionarySpeakerId " +
                    $"                     FROM DictionarySpeaker";
            SqlDataReader sqlDataReaderMaxId = sqlCommandMaxId.ExecuteReader();

            if (sqlDataReaderMaxId.HasRows)
            {
                sqlDataReaderMaxId.Read();
                int insertedId = sqlDataReaderMaxId.GetInt32("DictionarySpeakerId") + 1;

                SqlCommand sqlCommandInsert = new SqlCommand("spSpeakers_Insert", sqlConnection);
                sqlCommandInsert.CommandType = CommandType.StoredProcedure;

                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionarySpeakerId", insertedId));
                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionarySpeakerName", speakerName));
                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryCountryNationality", speakerNationality));
                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionarySpeakerRating", speakerRating));
                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionarySpeakerImage", speakerImage));

                sqlCommandInsert.ExecuteNonQuery();
            }
            else
            {
                int insertedId = 1;

                SqlCommand sqlCommandInsert = new SqlCommand("spSpeakers_Insert", sqlConnection);
                sqlCommandInsert.CommandType = CommandType.StoredProcedure;

                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryCountryId", insertedId));
                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionarySpeakerName", speakerName));
                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryCountryNationality", speakerNationality));
                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionarySpeakerRating", speakerRating));
                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionarySpeakerImage", speakerImage));

                sqlCommandInsert.ExecuteNonQuery();
            }
        }

        public List<SpeakerModel> GetConferenceSpeakers(string keyword)
        {
            SqlCommand sqlCommand = new SqlCommand("spSpeakers_GetByKeyword", sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.Add(new SqlParameter("@Keyword", keyword));

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<SpeakerModel> speakers = new List<SpeakerModel>();


            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    speakers.Add(new SpeakerModel()
                    {
                        DictionarySpeakerId = sqlDataReader.GetInt32("DictionarySpeakerId"),
                        DictionarySpeakerName = sqlDataReader.GetString("DictionarySpeakerName"),
                        DictionarySpeakerNationality = sqlDataReader.GetString("DictionaryCountryNationality"),
                        DictionarySpeakerRating = (float)sqlDataReader.GetDouble("DictionarySpeakerRating"),
                        DictionarySpeakerImage = sqlDataReader.GetString("DictionarySpeakerImage"),
                    });
                }
            }
            return speakers;
        }

        public void DeleteSpeaker(int speakerId)
        {
            SqlCommand sqlCommand = new SqlCommand("spSpeakers_Delete", sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.Add(new SqlParameter("@DictionarySpeakerId", speakerId));

            sqlCommand.ExecuteNonQuery();
        }
    }
}
