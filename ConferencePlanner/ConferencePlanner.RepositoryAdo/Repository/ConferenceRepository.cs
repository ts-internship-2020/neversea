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
            sqlCommand.CommandText = $"update ConferenceAttendance set DictionaryParticipantStatusId = 2" +
                $" where ParticipantEmailAddress = '@Email' and ConferenceId = (SELECT c.ConferenceId from Conference c where c.ConferenceName like '@Name')";
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
            sqlCommand.CommandText = $"EXEC spConferences_GetByEmailOrdByStatus " +
                  $"                       @Email='aaaaaaaa@gmail.com', " +
                  $"                       @StartDate = '20100101', " +
                  $"                       @EndDate = '20210101'";
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

        public SpeakerModel SelectSpeakerDetails(int speakerId)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Id", speakerId);
            
            
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"SELECT DictionarySpeakerName,DictionarySpeakerRating " +
                                     $"from DictionarySpeaker where DictionarySpeakerId = @Id";
            sqlCommand.Parameters.Add(parameters[0]);
        
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            SpeakerModel speaker = new SpeakerModel();
            if (sqlDataReader.HasRows)
            {
                speaker.DictionarySpeakerName = new string(sqlDataReader.GetString("DictionarySpeakerName"));
                //speaker.DictionarySpeakerNationality = new string(sqlDataReader.GetString("DictionarySpeakerCountry"));
                //speaker.DictionarySpeakerRating = new float.Parse(sqlDataReader.GetString("DictionarySpeakerRating"));
            }
            return speaker;
        }
        public int getSpeakerId(string speakerName)
        {

            //SqlParameter[] parameters = new SqlParameter[2];
            //parameters[0] = new SqlParameter("@Id", conferenceId);
            //parameters[1] = new SqlParameter("@Email", spectatorEmail);



            //SqlCommand sqlCommand = sqlConnection.CreateCommand();
            //sqlCommand.CommandText = $"update ConferenceAttendance set DictionaryParticipantStatusId = 3 where ParticipantEmailAddress = @Email and ConferenceId = @Id";
            //sqlCommand.Parameters.Add(parameters[0]);
            //sqlCommand.Parameters.Add(parameters[1]);
            int id=0;
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Name", speakerName);


            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"SELECT DictionarySpeakerId " +
                                     $"from DictionarySpeaker where DictionarySpeakerName = '@Name'";

            sqlCommand.Parameters.Add(parameters[0]);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            { 
            id = sqlDataReader.GetInt32("DictionarySpeakerId");
            }
            return id;
        }
        
    }
 };
