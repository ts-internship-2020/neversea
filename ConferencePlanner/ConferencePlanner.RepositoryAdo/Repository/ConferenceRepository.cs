using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

        public List<ConferenceModel> GetConferenceBetweenDates(string emailOrganiser, DateTime startDate, DateTime endDate)
        {
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string sqlStartDate = startDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sqlEndDate = endDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
            sqlCommand.CommandText = "SELECT c.ConferenceId, c.ConferenceName, c.StartDate, c.EndDate,'', dct.DictionaryConferenceTypeName, dcc.DictionaryConferenceCategoryName, l.LocationAddress, s.DictionarySpeakerName" +
                    "                     FROM DictionarySpeaker s" +
                    "                     INNER JOIN ConferenceXSpeaker cxs ON s.DictionarySpeakerId = cxs.DictionarySpeakerId AND cxs.IsMain = 1" +
                    "                     INNER JOIN Conference c ON cxs.ConferenceId = c.ConferenceId" +
                    "                     INNER JOIN DictionaryConferenceType dct ON c.DictionaryConferenceTypeId = dct.DictionaryConferenceTypeId" +
                    "                     INNER JOIN DictionaryConferenceCategory dcc ON c.DictionaryConferenceCategoryId = dcc.DictionaryConferenceCategoryId" +
                    "                     INNER JOIN Location l ON c.LocationId = l.LocationId" +
                    "                     WHERE c.StartDate  > '" + sqlStartDate + "' and c.EndDate < '" + sqlEndDate + "' " +
                    "                     AND c.OrganiserEmail = '" + emailOrganiser +"';";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<ConferenceModel> conferences = new List<ConferenceModel>();
            Console.WriteLine(startDate);
            Console.WriteLine(endDate);
            Console.WriteLine(sqlDataReader.HasRows); //False
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    conferences.Add(new ConferenceModel()
                    {
                        ConferenceId = sqlDataReader.GetInt32("ConferenceId"),
                        ConferenceName = sqlDataReader.GetString("ConferenceName"),
                        ConferenceStartDate = sqlDataReader.GetDateTime("StartDate"),
                        ConferenceEndDate = sqlDataReader.GetDateTime("EndDate"),
                        ConferenceType = sqlDataReader.GetString("DictionaryConferenceTypeName"),
                        ConferenceCategory = sqlDataReader.GetString("DictionaryConferenceCategoryName"),
                        ConferenceLocation = sqlDataReader.GetString("LocationAddress"),
                        ConferenceMainSpeaker = sqlDataReader.GetString("DictionarySpeakerName")
                    });
                }
            }

            sqlDataReader.Close();
            return conferences;
        }

        public List<ConferenceModel> GetConference(string spectatorEmail, DateTime startDate, DateTime endDate)
        {
            SqlCommand sqlCommand = new SqlCommand("spConferences_GetByEmailOrdByStatus", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter("@Email", spectatorEmail));
            sqlCommand.Parameters.Add(new SqlParameter("@StartDate", startDate));
            sqlCommand.Parameters.Add(new SqlParameter("@EndDate", endDate));

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<ConferenceModel> conferences = new List<ConferenceModel>();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    conferences.Add(new ConferenceModel()
                    {
                        ConferenceName = sqlDataReader.GetString("ConferenceName"),
                        ConferenceId = sqlDataReader.GetInt32("ConferenceId"),
                        ConferenceStartDate = sqlDataReader.GetDateTime("StartDate"),
                        ConferenceEndDate = sqlDataReader.GetDateTime("EndDate"),
                        ConferenceCategory = sqlDataReader.GetString("DictionaryConferenceCategoryName"),
                        ConferenceType = sqlDataReader.GetString("DictionaryConferenceTypeName"),
                        ConferenceMainSpeaker = sqlDataReader.GetString("DictionarySpeakerName"), 
                        SpeakerId = sqlDataReader.GetInt32("DictionarySpeakerId"),
                        ConferenceLocation = sqlDataReader.GetString("ConferenceLocation"),
                    }); 
                }
            }

            sqlDataReader.Close();

            return conferences.GroupBy(x => x.ConferenceId).Select(grp => grp.First()).ToList();
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

       
        public SpeakerModel getSelectSpeakerDetails(int speakerId)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Id", speakerId);


            SqlCommand sqlCommand = sqlConnection.CreateCommand();



            sqlCommand.CommandText = $"SELECT ds.DictionarySpeakerName,ds.DictionarySpeakerRating, dc.DictionaryCountryNationality "+
 "from DictionarySpeaker ds join ConferenceXSpeaker cs on cs.DictionarySpeakerId = ds.DictionarySpeakerId"+
 " join Conference c on cs.ConferenceId = c.ConferenceId"+
 " join Location l on l.LocationId = c.LocationId"+
 " join DictionaryCity dci on dci.DictionaryCityId = l.DictionaryCityId"+
 " join DictionaryDistrict dd on dd.DictionaryDistrictId = dci.DictionaryDistrictId"+
 " join DictionaryCountry dc on dc.DictionaryCountryId = dd.DictionaryCountryId"+
 " where ds.DictionarySpeakerId = 1";



            sqlCommand.Parameters.Add(parameters[0]);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            SpeakerModel speaker = new SpeakerModel();



            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    speaker.DictionarySpeakerName = new string(sqlDataReader.GetString("DictionarySpeakerName"));
                    speaker.DictionarySpeakerNationality = new string(sqlDataReader.GetString("DictionaryCountryNationality"));
                    speaker.DictionarySpeakerRating =  (float)sqlDataReader.GetDouble("DictionarySpeakerRating");
                }
                
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
