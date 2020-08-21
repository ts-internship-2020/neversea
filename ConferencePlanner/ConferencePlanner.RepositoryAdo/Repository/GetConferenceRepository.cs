using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class GetConferenceRepository : IGetConferenceRepository
    {
        private readonly SqlConnection _sqlConnection;

        public GetConferenceRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public List<ConferenceModel> GetConference(string name)
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT c.ConferenceName, c.StartDate, c.EndDate, dcp.DictionaryConferenceTypeName, dcp.DictionaryConferenceCategoryName, l.LocationAddress" +
                "                     FROM DictionarySpeaker s" +
                "                     INNER JOIN ConferenceXSpeaker cxs ON s.DictionarySpeakerId = cxs.DictionarySpeakerId AND cxs.IsMain = 1" +                                           
                "                     INNER JOIN Conference c ON cxs.ConferenceId = c.ConferenceId" +
                "                     INNER JOIN DictionaryConferenceType dcp ON c.DictionaryConferenceTypeId = dcp.DictionaryConferenceTypeId" +
                "                     INNER JOIN Location l ON c.LocationId = l.LocationId";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<ConferenceModel> conferences = new List<ConferenceModel>();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    conferences.Add(new ConferenceModel() { conferenceName = sqlDataReader.GetString("ConferenceName"), 
                                                            conferenceStartDate = sqlDataReader.GetDateTime("StartDate"),
                                                            conferenceEndDate = sqlDataReader.GetDateTime("EndDate"), 
                                                            conferencePeriod = ((TimeSpan)(sqlDataReader.GetDateTime("EndDate") - sqlDataReader.GetDateTime("StartDate"))).Days,
                                                            conferenceType = sqlDataReader.GetString("DictionaryConferenceTypeName"), 
                                                            conferenceCategory = sqlDataReader.GetString("DictionaryConferenceCategoryName"), 
                                                            conferenceAddress = sqlDataReader.GetString("LocationAddress"),
                                                            conferenceMainSpeaker = sqlDataReader.GetString("DictionarySpeakerName")
                    });
                }
            }

            sqlDataReader.Close();

            return conferences;
        }
    }
}
