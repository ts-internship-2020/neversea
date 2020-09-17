using System;
using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class DistrictRepository : IDistrictRepository
    {


            private readonly SqlConnection sqlConnection;
    
        public DistrictRepository(SqlConnection SqlConnection)
        {
            sqlConnection = SqlConnection;
        }

        public void DeleteDistrict(int districtId, int countryId)
        {
            SqlCommand sqlCommand = new SqlCommand("spDistricts_Delete", sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.Add(new SqlParameter("@DictionaryDistrictId", districtId));
            sqlCommand.Parameters.Add(new SqlParameter("@DictionaryCountryId", countryId));

            sqlCommand.ExecuteNonQuery();
        }

        public DistrictModel GetConferenceDistrictByCityId(int cityId)
        {
            DistrictModel d1 = new DistrictModel();
            return d1;
        }
        public List<DistrictModel> GetConferenceDistrictByCountryId(int countryId)
        {
            List<DistrictModel> d1 = new List<DistrictModel>();
            return d1;
        }
        public List<DistrictModel> GetDistricts()
        {

            List<DistrictModel> ConferenceDistrict = new List<DistrictModel>();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT DictionaryDistrictId, DictionaryDistrictName, DictionaryDistrictCode, DictionaryCountryId " +
                                     " FROM DictionaryDistrict";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    ConferenceDistrict.Add(new DistrictModel()
                    {
                        DistrictName = sqlDataReader.GetString("DictionaryDistrictName"),
                        DistrictId = sqlDataReader.GetInt32("DictionaryDistrictId"),
                        DistrictCode = sqlDataReader.GetString("DictionaryDistrictCode"),
                        CountryId=sqlDataReader.GetInt32("DictionaryCountryId")
                    });
                }
            }

            return ConferenceDistrict;
        }
        public List<DistrictModel> GetDistricts(string keyword)
        {
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = $"EXEC spDistricts_GetByKeyWord " +
                                     $"@Keyword='{keyword}'";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<DistrictModel> districts = new List<DistrictModel>();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    districts.Add(new DistrictModel()
                    {
                        DistrictName = sqlDataReader.GetString("DictionaryDistrictName"),
                        DistrictId = sqlDataReader.GetInt32("DictionaryDistrictId"),
                        DistrictCode = sqlDataReader.GetString("DictionaryDistrictCode"),
                        CountryId = sqlDataReader.GetInt32("DictionaryCountryId")
                    });
                }
            }

            sqlDataReader.Close();

            return districts;
        }

        public void InsertDistrict(string districtName, string districtCode, int countryId)
        {
            SqlCommand sqlCommandMaxId = sqlConnection.CreateCommand();
            sqlCommandMaxId.CommandText = $"SELECT MAX(DictionaryDistrictId) AS DictionaryDistrictId " +
                    $"                     FROM DictionaryDistrict";
            SqlDataReader sqlDataReaderMaxId = sqlCommandMaxId.ExecuteReader();

            if (sqlDataReaderMaxId.HasRows)
            {
                sqlDataReaderMaxId.Read();
                int insertedId = sqlDataReaderMaxId.GetInt32("DictionaryDistrictId") + 1;

                SqlCommand sqlCommandInsert = new SqlCommand("spDistricts_Insert", sqlConnection);
                sqlCommandInsert.CommandType = CommandType.StoredProcedure;

                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryDistrictId", insertedId));
                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryDistrictName", districtName));
                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryDistrictCode", districtCode));
                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryCountryId", countryId));

                sqlCommandInsert.ExecuteNonQuery();
            }
            else
            {
                int insertedId = 1;

                SqlCommand sqlCommandInsert = new SqlCommand("spDistricts_Insert", sqlConnection);
                sqlCommandInsert.CommandType = CommandType.StoredProcedure;

                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryDistrictId", insertedId));
                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryDistrictName", districtName));
                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryDistrictCode", districtCode));
                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryCountryId", countryId));

                sqlCommandInsert.ExecuteNonQuery();
            }
        }

        public void UpdateDistrict(int districtId, string districtName, string districtCode, int countryId)
        {
            SqlCommand sqlCommand = new SqlCommand("spDistricts_Update", sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.Add(new SqlParameter("@DictionaryDistrictId", districtId));
            sqlCommand.Parameters.Add(new SqlParameter("@DictionaryDistrictName", districtName));
            sqlCommand.Parameters.Add(new SqlParameter("@DictionaryDistrictCode", districtCode));
            sqlCommand.Parameters.Add(new SqlParameter("@DictionaryCountryId", countryId));

            sqlCommand.ExecuteNonQuery();
        }
    }
}
