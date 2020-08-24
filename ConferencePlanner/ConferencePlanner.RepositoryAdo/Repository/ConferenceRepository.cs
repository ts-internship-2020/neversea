using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class ConferenceRepository : IConferenceRepository
    {


        private readonly SqlConnection sqlConnection;


        public ConferenceRepository(SqlConnection SqlConnection)
        {
            sqlConnection = SqlConnection;

        }

        public void InsertParticipant(string conferenceName, string spectatorEmail)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Name", conferenceName);
            parameters[1] = new SqlParameter("@Email", spectatorEmail);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"insert into ConferenceAttendance values((select c.ConferenceId from Conference c where c.ConferenceName like '@Name'), '@Email', 2, NULL)";
            sqlCommand.ExecuteNonQuery();
        }

        public void ModifySpectatorStatusJoin(string spectatorEmail, string conferenceName)
        {
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"update ConferenceAttendance set DictionaryParticipantStatusId = 1 where ParticipantEmailAddress = '{spectatorEmail}' and ConferenceId = (SELECT c.ConferenceId from Conference c where c.ConferenceName like '%{conferenceName}%')";
            sqlCommand.ExecuteNonQuery();
        }


        public void ModifySpectatorStatusWithdraw(string spectatorEmail, string conferenceName)
        {

            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Name", conferenceName);
            parameters[1] = new SqlParameter("@Email", spectatorEmail);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"update ConferenceAttendance set DictionaryParticipantStatusId = 3 where ParticipantEmailAddress = '@Email' and ConferenceId = (SELECT c.ConferenceId from Conference c where c.ConferenceName like '@Name')";
            sqlCommand.ExecuteNonQuery();
        }

        public List<ConferenceModel> GetConference(string name)
        {
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            if (name == "spectator")
            {
                sqlCommand.CommandText = "SELECT c.ConferenceName, c.StartDate, c.EndDate,'', dct.DictionaryConferenceTypeName, dcc.DictionaryConferenceCategoryName, l.LocationAddress, s.DictionarySpeakerName" +
                    "                     FROM DictionarySpeaker s" +
                    "                     INNER JOIN ConferenceXSpeaker cxs ON s.DictionarySpeakerId = cxs.DictionarySpeakerId AND cxs.IsMain = 1" +
                    "                     INNER JOIN Conference c ON cxs.ConferenceId = c.ConferenceId" +
                    "                     INNER JOIN DictionaryConferenceType dct ON c.DictionaryConferenceTypeId = dct.DictionaryConferenceTypeId" +
                    "                     INNER JOIN DictionaryConferenceCategory dcc ON c.DictionaryConferenceCategoryId = dcc.DictionaryConferenceCategoryId" +
                    "                     INNER JOIN Location l ON c.LocationId = l.LocationId";
            }

            if (name == "organiser")
            {
                sqlCommand.CommandText = "SELECT c.ConferenceName, c.StartDate, c.EndDate,'', dct.DictionaryConferenceTypeName, dcc.DictionaryConferenceCategoryName, l.LocationAddress, s.DictionarySpeakerName" +
                    "                     FROM DictionarySpeaker s" +
                    "                     INNER JOIN ConferenceXSpeaker cxs ON s.DictionarySpeakerId = cxs.DictionarySpeakerId AND cxs.IsMain = 1" +
                    "                     INNER JOIN Conference c ON cxs.ConferenceId = c.ConferenceId" +
                    "                     INNER JOIN DictionaryConferenceType dct ON c.DictionaryConferenceTypeId = dct.DictionaryConferenceTypeId" +
                    "                     INNER JOIN DictionaryConferenceCategory dcc ON c.DictionaryConferenceCategoryId = dcc.DictionaryConferenceCategoryId" +
                    "                     INNER JOIN Location l ON c.LocationId = l.LocationId" +
                    "                     WHERE C.OrganiserEmail = 'paul.popescu@gmail.com' ";
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<ConferenceModel> conferences = new List<ConferenceModel>();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    conferences.Add(new ConferenceModel()
                    {
                        conferenceName = sqlDataReader.GetString("ConferenceName"),
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

        public List<string> GetCountry(string name)
        {
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            if (name == "add")
            {
                sqlCommand.CommandText = "SELECT DictionaryCountryName" +
                    "                     FROM DictionaryCountry";
            }
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<string> countries = new List<string>();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    countries.Add(new string(sqlDataReader.GetString("DictioanryCountryName")));
                }

            }
            sqlDataReader.Close();
            return countries;
        }
    }
}
