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
        public void updateCity(int index, string city, string mode)
        {
            if (mode == "city")
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[2];
                    parameters[0] = new SqlParameter("@Id", index);
                    parameters[1] = new SqlParameter("@City", city);

                    Console.WriteLine(index);
                    Console.WriteLine(city);
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandText = $"update DictionaryCity " +
                        $"                     set DictionaryCityName = @City " +
                        $"                     where DictionaryCityId = @Id ";
                    sqlCommand.Parameters.Add(parameters[0]);
                    sqlCommand.Parameters.Add(parameters[1]);
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine("Facui update");
                }
                catch
                {
                    Console.WriteLine("nu am putut face update");
                }
            }
        }
    }
}
