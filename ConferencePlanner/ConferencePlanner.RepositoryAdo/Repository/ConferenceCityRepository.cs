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
        public void UpdateCity(int index, string city, int districtId)
        {
            try
            {
                SqlParameter[] parametersUp = new SqlParameter[3];
                parametersUp[0] = new SqlParameter("@Id", index);
                parametersUp[1] = new SqlParameter("@City", city);
                parametersUp[2] = new SqlParameter("@DistrictId", districtId);

                Console.WriteLine(index);
                Console.WriteLine(city);
                SqlCommand sqlCommandUp = sqlConnection.CreateCommand();
                sqlCommandUp.CommandText = $"update DictionaryCity " +
                    $"                     set DictionaryCityName = @City " +
                    $"                     where DictionaryCityId = @Id " +
                    $"                     AND DictionaryDistrictId = @DistrictId";
                sqlCommandUp.Parameters.Add(parametersUp[0]);
                sqlCommandUp.Parameters.Add(parametersUp[1]);
                sqlCommandUp.Parameters.Add(parametersUp[2]);
                sqlCommandUp.ExecuteNonQuery();
                Console.WriteLine("Facui update");
            }
            catch
            {
                Console.WriteLine("nu am putut face update");
            }
        }
        public void InsertCity(string city, int districtId)
        {
            SqlCommand sqlCommandMaxIndex = sqlConnection.CreateCommand();
            sqlCommandMaxIndex.CommandText = $"select Max(DictionaryCityId) as DictionaryCityId " +
                    $"                     from DictionaryCity";
            SqlDataReader sqlDataReaderMaxIndex = sqlCommandMaxIndex.ExecuteReader();
            Console.WriteLine(sqlDataReaderMaxIndex.HasRows);
            if (sqlDataReaderMaxIndex.HasRows)
            { // In cazul in care am gasit indexul cel mai mare, fac insert;
                Console.WriteLine(sqlDataReaderMaxIndex.Read());
                int insertIndex = sqlDataReaderMaxIndex.GetInt32("DictionaryCityId") + 1;
                SqlParameter[] parametersInsert = new SqlParameter[3];
                parametersInsert[0] = new SqlParameter("@Id", insertIndex);
                parametersInsert[1] = new SqlParameter("@CityName", city);
                parametersInsert[2] = new SqlParameter("@DistrictId", districtId);
                SqlCommand sqlCommandInsert = sqlConnection.CreateCommand();
                sqlCommandInsert.CommandText = $"INSERT into DictionaryCity(DictionaryCityId, DictionaryCityName, DictionaryDistrictId) " +
                        $"                     VALUES (@Id, @CityName, @DistrictId)";
                sqlCommandInsert.Parameters.Add(parametersInsert[0]);
                sqlCommandInsert.Parameters.Add(parametersInsert[1]);
                sqlCommandInsert.Parameters.Add(parametersInsert[2]);
                sqlCommandInsert.ExecuteNonQuery();
            }
            else
            {
                int insertIndex = 1;
                SqlParameter[] parametersInsert = new SqlParameter[3];
                parametersInsert[0] = new SqlParameter("@Id", insertIndex);
                parametersInsert[1] = new SqlParameter("@CityName", city);
                parametersInsert[2] = new SqlParameter("@DistrictId", districtId);
                SqlCommand sqlCommandInsert = sqlConnection.CreateCommand();
                sqlCommandInsert.CommandText = $"INSERT into DictionaryCity(DictionaryCityId, DictionaryCityName, DictionaryDistrictId) " +
                        $"                     VALUES (@Id, @CityName, @DistrictId)";
                sqlCommandInsert.Parameters.Add(parametersInsert[0]);
                sqlCommandInsert.Parameters.Add(parametersInsert[1]);
                sqlCommandInsert.Parameters.Add(parametersInsert[2]);
                sqlCommandInsert.ExecuteNonQuery();
            }
        }

        public void DeleteCity(int cityId, int districtId)
        {
            SqlCommand sqlCommand = new SqlCommand("spCities_Delete", sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.Add(new SqlParameter("@DictionaryCityId", cityId));
            sqlCommand.Parameters.Add(new SqlParameter("@DictionaryDistrictId", districtId));


            sqlCommand.ExecuteNonQuery();
        }

        public List<ConferenceCityModel> GetConferenceCities(int districtId, string keyword)
        {
            SqlCommand sqlCommand = new SqlCommand("spCities_GetByKeyword", sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.Add(new SqlParameter("@Keyword", keyword));
            sqlCommand.Parameters.Add(new SqlParameter("@DictionaryDistrictId", districtId));

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<ConferenceCityModel> cities = new List<ConferenceCityModel>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    cities.Add(new ConferenceCityModel()
                    {
                        ConferenceCityId = sqlDataReader.GetInt32("DictionaryCityId"),
                        ConferenceCityName = sqlDataReader.GetString("DictionaryCityName")
                    });
                }
            }
            Console.WriteLine("Am returnat un nr de :" + cities.Count);
            sqlDataReader.Close();
            return cities;

        }
    }
}
