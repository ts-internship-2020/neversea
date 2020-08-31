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

    }
}
