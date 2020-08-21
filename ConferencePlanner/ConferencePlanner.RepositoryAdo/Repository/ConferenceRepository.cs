using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConferencePlanner.Repository.Ado.Repository
{
    class ConferenceRepository : IConferenceRepository
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
    }
}
