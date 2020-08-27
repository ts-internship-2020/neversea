using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class ConferenceAttendanceRepository : IConferenceAttendanceRepository
    {
        private readonly SqlConnection sqlConnection;


        public ConferenceAttendanceRepository(SqlConnection SqlConnection)
        {
            sqlConnection = SqlConnection;
        }

        public List<ConferenceAttendanceModel> GetConferenceAttendance()
        {
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "SELECT ConferenceId, ParticipantEmailAddress, DictionaryParticipantStatusId, ISNULL(ParticipationCode,'00000000-0000-0000-0000-000000000000') AS ParticipationCode FROM ConferenceAttendance";

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<ConferenceAttendanceModel> conferenceAttendances = new List<ConferenceAttendanceModel>();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    conferenceAttendances.Add(new ConferenceAttendanceModel()
                    {
                        ConferenceId = sqlDataReader.GetInt32("ConferenceId"),
                        ParticipantEmailAddress = sqlDataReader.GetString("ParticipantEmailAddress"),
                        DictionaryParticipantStatusId = sqlDataReader.GetInt32("DictionaryParticipantStatusId"),
                        ParticipationCode = sqlDataReader.GetGuid("ParticipationCode")
                    }); 
                }
            }

            sqlDataReader.Close();


            return conferenceAttendances;
        }
    }
}
