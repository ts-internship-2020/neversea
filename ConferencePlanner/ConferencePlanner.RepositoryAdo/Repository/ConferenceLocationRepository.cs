using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class ConferenceLocationRepository : IConferenceLocationRepository
    {

        private readonly SqlConnection sqlConnection;
        public ConferenceLocationRepository(SqlConnection SqlConnection)
        {
            sqlConnection = SqlConnection;

        }

        public void InsertLocation(int CityId)
        {

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Id", CityId);


            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"insert into Location(DictionaryCityId, LocationAddress) values(@Id, 'aa')";
            sqlCommand.Parameters.Add(parameters[0]);


            sqlCommand.ExecuteNonQuery();


        }
        public int GetLocationId(int CityId, string locationAddress)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Id", CityId);
            parameters[1] = new SqlParameter("@Address", locationAddress);



            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"select LocationId from Location where DictionaryCityId = @Id and LocationAddress = @Address";
            sqlCommand.Parameters.Add(parameters[0]);
            sqlCommand.Parameters.Add(parameters[1]);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            int locationId = 0;
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    locationId = sqlDataReader.GetInt32("LocationId");
                }
            }

            return locationId;
        }
    }
}
