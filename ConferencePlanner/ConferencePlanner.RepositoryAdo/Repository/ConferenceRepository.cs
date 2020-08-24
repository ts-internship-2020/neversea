﻿using ConferencePlanner.Abstraction.Model;
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




        public void InsertParticipant(int conferenceId, string spectatorEmail)
        {
            SqlParameter[] parameters = new SqlParameter[2];   
            parameters[0] = new SqlParameter("@Id", conferenceId);
            parameters[1] = new SqlParameter("@Email", spectatorEmail);


            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"insert into ConferenceAttendance values(@Id,@Email, 2, NULL)";
            sqlCommand.Parameters.Add(parameters[0]);
            sqlCommand.Parameters.Add(parameters[1]);

            sqlCommand.ExecuteNonQuery();
                }

        public void ModifySpectatorStatusAttend(string conferenceName, string spectatorEmail)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Name", conferenceName);
            parameters[1] = new SqlParameter("@Email", spectatorEmail);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"update ConferenceAttendance set DictionaryParticipantStatusId = 2 where ParticipantEmailAddress = '@Email' and ConferenceId = (SELECT c.ConferenceId from Conference c where c.ConferenceName like '@Name')";
            sqlCommand.ExecuteNonQuery();
        }


        public void ModifySpectatorStatusJoin(string spectatorEmail, int conferenceId)
        {
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@Id", conferenceId);
            parameters[1] = new SqlParameter("@Email", spectatorEmail);

            sqlCommand.CommandText = $"update ConferenceAttendance set DictionaryParticipantStatusId = 1 where ParticipantEmailAddress = @Email and ConferenceId = @Id";
            sqlCommand.Parameters.Add(parameters[0]);
            sqlCommand.Parameters.Add(parameters[1]);
            sqlCommand.ExecuteNonQuery();
        }

      



        public void ModifySpectatorStatusWithdraw(string spectatorEmail, int conferenceId)
        {

            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Id", conferenceId);
            parameters[1] = new SqlParameter("@Email", spectatorEmail);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"update ConferenceAttendance set DictionaryParticipantStatusId = 3 where ParticipantEmailAddress = @Email and ConferenceId = @Id";
            sqlCommand.Parameters.Add(parameters[0]);
            sqlCommand.Parameters.Add(parameters[1]);

            sqlCommand.ExecuteNonQuery();
        }





        public List<ConferenceModel> GetConference(string name)
        {
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            if (name == "organiser") {

                sqlCommand.CommandText = "SELECT c.ConferenceName, c.ConferenceId, c.StartDate, c.EndDate,'', dct.DictionaryConferenceTypeName, dcc.DictionaryConferenceCategoryName, l.LocationAddress, s.DictionarySpeakerName" +
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
                        conferenceId = sqlDataReader.GetInt32("ConferenceId"),
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

        public List<ConferenceModel> GetConference(string name, DateTime startDate, DateTime endDate)
        {
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.Add(new SqlParameter("@Email", "aaaaaaaa@gmail.com"));

            sqlCommand.Parameters.Add(new SqlParameter("@StartDate", startDate));
            sqlCommand.Parameters.Add(new SqlParameter("@EndDate", endDate));

            sqlCommand.CommandText = "spConferences_GetByEmailOrdByStatus";


            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<ConferenceModel> conferences = new List<ConferenceModel>();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    conferences.Add(new ConferenceModel()
                    {
                        conferenceName = sqlDataReader.GetString("ConferenceName"),
                        conferenceId = sqlDataReader.GetInt32("ConferenceId"),
                        conferencePeriod = ((TimeSpan)(sqlDataReader.GetDateTime("EndDate") - sqlDataReader.GetDateTime("StartDate"))).Days,
                        conferenceType = sqlDataReader.GetString("DictionaryConferenceTypeName"),
                        conferenceCategory = sqlDataReader.GetString("DictionaryConferenceCategoryName"),
                        conferenceAddress = sqlDataReader.GetString("LocationAddress"),
                        conferenceMainSpeaker = sqlDataReader.GetString("DictionarySpeakerName")
                    }); ;
                }
            }

            sqlDataReader.Close();

            return conferences;
        }
    }
}
