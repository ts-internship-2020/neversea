using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace ConferencePlanner.Repository.Ado.Repository
{
    public class ConferenceRepository : IConferenceRepository
    {


        private readonly SqlConnection sqlConnection;


        public ConferenceRepository(SqlConnection SqlConnection)
        {
            sqlConnection = SqlConnection;
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

        public void InsertParticipant(int conferenceId, string spectatorEmail, int spectatorCode)
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@Id", conferenceId);
            parameters[1] = new SqlParameter("@Email", spectatorEmail);
            parameters[2] = new SqlParameter("@Code", spectatorCode);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"insert into ConferenceAttendance values(@Id,@Email, 2, NULL )";
            sqlCommand.Parameters.Add(parameters[0]);
            sqlCommand.Parameters.Add(parameters[1]);
            sqlCommand.Parameters.Add(parameters[2]);


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
                    "                     AND c.OrganiserEmail = '" + emailOrganiser + "'" +
                    "                     ORDER BY c.StartDate;";
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

        public List<ConferenceModel> GetConference(string spectatorEmail, DateTime startDate, DateTime endDate, List<ConferenceAttendanceModel> conferenceAttendances)
        {
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "SELECT c.ConferenceId, c.ConferenceName, c.StartDate, c.EndDate,''," +
                " dct.DictionaryConferenceTypeName, dcc.DictionaryConferenceCategoryName, CONCAT(dci.DictionaryCityName,', ', " +
                " dd.DictionaryDistrictName, ', ', dco.DictionaryCountryName) AS ConferenceLocation, s.DictionarySpeakerName, s.DictionarySpeakerId  " +
                " FROM DictionarySpeaker s INNER JOIN ConferenceXSpeaker cxs ON s.DictionarySpeakerId = cxs.DictionarySpeakerId AND cxs.IsMain = 1 INNER JOIN Conference c ON cxs.ConferenceId = c.ConferenceId INNER JOIN DictionaryConferenceType dct ON c.DictionaryConferenceTypeId = dct.DictionaryConferenceTypeId INNER JOIN DictionaryConferenceCategory dcc ON c.DictionaryConferenceCategoryId = dcc.DictionaryConferenceCategoryId INNER JOIN[Location] l ON c.LocationId = l.LocationId INNER JOIN DictionaryCity dci ON l.DictionaryCityId = dci.DictionaryCityId INNER JOIN DictionaryDistrict dd ON dci.DictionaryDistrictId = dd.DictionaryDistrictId INNER JOIN DictionaryCountry dco ON dd.DictionaryCountryId = dco.DictionaryCountryId";

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
                        ConferenceType = sqlDataReader.GetString("DictionaryConferenceTypeName"),
                        ConferenceCategory = sqlDataReader.GetString("DictionaryConferenceCategoryName"),
                        ConferenceMainSpeaker = sqlDataReader.GetString("DictionarySpeakerName"),
                        ConferenceLocation = sqlDataReader.GetString("ConferenceLocation"),
                        SpeakerId = sqlDataReader.GetInt32("DictionarySpeakerId")
                    });
                }
            }

            sqlDataReader.Close();

            List<ConferenceModel> conferencesBetweenDates = new List<ConferenceModel>();
            conferencesBetweenDates = filterConferencesByDates(conferences, startDate, endDate);

            List<ConferenceModel> conferencesOrderedByStatus = new List<ConferenceModel>();

            conferencesOrderedByStatus = sortConferencesByStatus(conferencesBetweenDates, spectatorEmail, conferenceAttendances);

            return conferencesOrderedByStatus;
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



            sqlCommand.CommandText = $"SELECT ds.DictionarySpeakerName,ds.DictionarySpeakerRating, dc.DictionaryCountryNationality, ds.DictionarySpeakerImage "+
 "from DictionarySpeaker ds join ConferenceXSpeaker cs on cs.DictionarySpeakerId = ds.DictionarySpeakerId"+
 " join Conference c on cs.ConferenceId = c.ConferenceId"+
 " join Location l on l.LocationId = c.LocationId"+
 " join DictionaryCity dci on dci.DictionaryCityId = l.DictionaryCityId"+
 " join DictionaryDistrict dd on dd.DictionaryDistrictId = dci.DictionaryDistrictId"+
 " join DictionaryCountry dc on dc.DictionaryCountryId = dd.DictionaryCountryId"+
 " where ds.DictionarySpeakerId = @Id";



            sqlCommand.Parameters.Add(parameters[0]);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            SpeakerModel speaker = new SpeakerModel();



            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    speaker.DictionarySpeakerName = sqlDataReader.GetString("DictionarySpeakerName");
                    speaker.DictionarySpeakerNationality = sqlDataReader.GetString("DictionaryCountryNationality");
                    speaker.DictionarySpeakerRating =  (float)sqlDataReader.GetDouble("DictionarySpeakerRating");
                    speaker.DictionarySpeakerImage = new string(sqlDataReader.GetString("DictionarySpeakerImage"));
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
            int id = 0;
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


        public List<ConferenceModel> filterConferencesByDates(List<ConferenceModel> conferences, DateTime startDate, DateTime endDate)
        {
            List<ConferenceModel> result = new List<ConferenceModel>();

            foreach (ConferenceModel conference in conferences)
            {
                if (conference.ConferenceStartDate >= startDate && conference.ConferenceEndDate <= endDate)
                {
                    result.Add(conference);
                }
            }

            return result;
        }


        public List<ConferenceModel> sortConferencesByStatus(List<ConferenceModel> conferencesBetweenDates, string spectatorEmail, List<ConferenceAttendanceModel> conferenceAttendances)
        {
            var conferencesBetweenDatesIDs = new ArrayList();
            var conferencesAttendedIDs = new ArrayList();
            var conferencesJoinedIDs = new ArrayList();
            var conferencesWithdrawnIDs = new ArrayList();
            var conferencesOtherIDs = new ArrayList();

            foreach (ConferenceModel conference in conferencesBetweenDates)
            {
                if (conferencesBetweenDatesIDs.Contains(conference.ConferenceId))
                {
                    continue;
                }
                else
                {
                    conferencesBetweenDatesIDs.Add(conference.ConferenceId);
                }
            }

            var conferenceAttendancesBetweenDates = new List<ConferenceAttendanceModel>();

            for (int i = 0; i < conferencesBetweenDatesIDs.Count; i++)
            {
                conferenceAttendancesBetweenDates.AddRange(conferenceAttendances.FindAll(ca => ca.ConferenceId == (int)conferencesBetweenDatesIDs[i]));
            }


            List<ConferenceAttendanceModel> conferenceAttendancesBetweenDatesAttended = conferenceAttendancesBetweenDates.FindAll(cabd => cabd.ParticipantEmailAddress == spectatorEmail && cabd.DictionaryParticipantStatusId == 2);
            List<ConferenceAttendanceModel> conferenceAttendancesBetweenDatesJoined = conferenceAttendancesBetweenDates.FindAll(cabd => cabd.ParticipantEmailAddress == spectatorEmail && cabd.DictionaryParticipantStatusId == 1);
            List<ConferenceAttendanceModel> conferenceAttendancesBetweenDatesWithdrawn = conferenceAttendancesBetweenDates.FindAll(cabd => cabd.ParticipantEmailAddress == spectatorEmail && cabd.DictionaryParticipantStatusId == 3);
            List<ConferenceAttendanceModel> conferenceAttendancesBetweenDatesWithoutStatus = conferenceAttendancesBetweenDates.FindAll(cabd => cabd.ParticipantEmailAddress != spectatorEmail);

            foreach (ConferenceAttendanceModel caAttended in conferenceAttendancesBetweenDatesAttended)
            {
                if (conferencesAttendedIDs.Contains(caAttended.ConferenceId))
                {
                    continue;
                }
                else
                {
                    conferencesAttendedIDs.Add(caAttended.ConferenceId);
                }
            }

            foreach (ConferenceAttendanceModel caJoined in conferenceAttendancesBetweenDatesJoined)
            {
                if (conferencesJoinedIDs.Contains(caJoined.ConferenceId))
                {
                    continue;
                }
                else
                {
                    conferencesJoinedIDs.Add(caJoined.ConferenceId);
                }
            }

            foreach (ConferenceAttendanceModel caWithdrawn in conferenceAttendancesBetweenDatesWithdrawn)
            {
                if (conferencesWithdrawnIDs.Contains(caWithdrawn.ConferenceId))
                {
                    continue;
                }
                else
                {
                    conferencesWithdrawnIDs.Add(caWithdrawn.ConferenceId);
                }
            }

            for (int i = 0; i < conferenceAttendancesBetweenDatesWithoutStatus.Count; i++)
            {
                if (conferencesOtherIDs.Contains(conferenceAttendancesBetweenDatesWithoutStatus[i].ConferenceId))
                {
                    continue;
                }
                else
                {
                    conferencesOtherIDs.Add(conferenceAttendancesBetweenDatesWithoutStatus[i].ConferenceId);
                }
            }


            foreach (ConferenceAttendanceModel caOther in conferenceAttendancesBetweenDatesWithoutStatus)
            {
                if (conferencesOtherIDs.Contains(caOther.ConferenceId))
                {
                    continue;
                }
                else
                {
                    conferencesOtherIDs.Add(caOther.ConferenceId);
                }
            }


            var orderedConferencesIDs = new ArrayList();

            orderedConferencesIDs.AddRange(conferencesAttendedIDs);
            orderedConferencesIDs.AddRange(conferencesJoinedIDs);
            orderedConferencesIDs.AddRange(conferencesWithdrawnIDs);
            orderedConferencesIDs.AddRange(conferencesOtherIDs);


            List<ConferenceModel> orderedConferences = new List<ConferenceModel>();

            for (int i = 0; i < orderedConferencesIDs.Count; i++)
            {
                orderedConferences.Add(conferencesBetweenDates.Find(cbd => cbd.ConferenceId == (int)orderedConferencesIDs[i]));
            }

            List<ConferenceModel> conferencesWithoutStatus = new List<ConferenceModel>();

            foreach (ConferenceModel conference in conferencesBetweenDates)
            {
                if (orderedConferences.Contains(conference))
                {
                    Console.WriteLine("Conference already in the list");
                }
                else
                {
                    orderedConferences.Add(conference);
                }
            }

            return orderedConferences;
        }

        public void InsertConference(ConferenceModel model)
        {

            SqlParameter[] parameters = new SqlParameter[7];

            parameters[0] = new SqlParameter("@Name", model.ConferenceName);
            parameters[1] = new SqlParameter("@StartDate", model.ConferenceStartDate);
            parameters[2] = new SqlParameter("@EndDate", model.ConferenceEndDate);
            parameters[3] = new SqlParameter("@Type", model.ConferenceType);
            parameters[4] = new SqlParameter("@Category", model.ConferenceCategory);
            parameters[5] = new SqlParameter("@Speaker", model.ConferenceMainSpeaker);
            parameters[6] = new SqlParameter("@Location", model.ConferenceLocation);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = $"insert into Conference(ConferenceName, StartDate, EndDate, OrganiserEmail, LocationId, DictionaryConferenceTypeId, DictionaryConferenceCategoryId) " +
                $"values(@Name,@StartDate, @EndDate, @OrganiserEmail, @Location, CAST(@Type AS int), CAST(@Category AS int))";


            sqlCommand.Parameters.Add(parameters[0]);
            sqlCommand.Parameters.Add(parameters[1]);
            sqlCommand.Parameters.Add(parameters[2]);
            sqlCommand.Parameters.Add(parameters[3]);
            sqlCommand.Parameters.Add(parameters[4]);
            sqlCommand.Parameters.Add(parameters[5]);
            sqlCommand.Parameters.Add(parameters[6]);

            sqlCommand.ExecuteNonQuery();

        }

        public void InsertConferenceXSpeaker(ConferenceModel model, int speakerId)
        {

            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@ConfId", model.ConferenceId);
            parameters[1] = new SqlParameter("@SpeakerId", speakerId);
            //  parameters[2] = new SqlParameter("@EndDate", model.ConferenceEndDate);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"Insert into ConferenceXSpeaker values(@ConfId, @SpeakerId, 1)";

            sqlCommand.Parameters.Add(parameters[0]);
            sqlCommand.Parameters.Add(parameters[1]);

            sqlCommand.ExecuteNonQuery();



        }

        public void InsertConference(ConferenceModel conference, int locationId)
        {
            SqlParameter[] parameters = new SqlParameter[7];

            parameters[0] = new SqlParameter("@Name", conference.ConferenceName);
            parameters[1] = new SqlParameter("@StartDate", conference.ConferenceStartDate);
            parameters[2] = new SqlParameter("@EndDate", conference.ConferenceEndDate);
            parameters[3] = new SqlParameter("@OrganiserMail", conference.ConferenceOrganiserEmail);
            parameters[4] = new SqlParameter("@LocationId", locationId);
            parameters[5] = new SqlParameter("@TypeId", conference.ConferenceType);
            parameters[6] = new SqlParameter("@CategoryId", conference.ConferenceCategory);


            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"Insert into Conference(ConferenceName,StartDate, EndDate, OrganiserEmail," +
                $" LocationId,DictionaryConferenceTypeId, DictionaryConferenceCategoryId)" +
                $" values(@Name, @StartDate, @EndDate, @OrganiserMail,@LocationId, @TypeId, @CategoryId)";

            sqlCommand.Parameters.Add(parameters[0]);
            sqlCommand.Parameters.Add(parameters[1]);
            sqlCommand.Parameters.Add(parameters[2]);
            sqlCommand.Parameters.Add(parameters[3]);
            sqlCommand.Parameters.Add(parameters[4]);
            sqlCommand.Parameters.Add(parameters[5]);
            sqlCommand.Parameters.Add(parameters[6]);


            sqlCommand.ExecuteNonQuery();
        }
    }
};
