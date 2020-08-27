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

        public List<DistrictModel> GetDistrict()
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
    }
}
