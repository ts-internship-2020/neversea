using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class ConferenceCityRepository : IConferenceCityRepository
    {
        private readonly SqlConnection sqlConnection;

        public ConferenceCityRepository(SqlConnection SqlConnection)
        {
            sqlConnection = SqlConnection;
        }

        public List<ConferenceCityModel> GetConferenceCities(int districtId)
        {
            List<ConferenceCityModel> cities = new List<ConferenceCityModel>();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT DictionaryCityId, DictionaryCityName " +
                                     "FROM DictionaryCity " +
                                     "WHERE DictionaryDistrictId = '1'";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    cities.Add(new ConferenceCityModel()
                    {
                        ConferenceCityId = sqlDataReader.GetInt32("DictionaryCityId"),
                        ConferenceCityName = sqlDataReader.GetString("DictionaryCityName"),
                    });
                }
            }
            return cities;
        }
    }
}
