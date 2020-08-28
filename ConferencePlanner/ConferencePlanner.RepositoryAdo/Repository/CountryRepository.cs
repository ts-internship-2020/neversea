using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class CountryRepository : ICountryRepository
    {


        private readonly SqlConnection sqlConnection;

        public CountryRepository(SqlConnection SqlConnection)
        {
            sqlConnection = SqlConnection;


        }



        public void DeleteCountry(int countryId)
        {
            throw new NotImplementedException();
        }

        public List<CountryModel> GetCountry()
        {
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT DictionaryCountryName, DictionaryCountryId, DictionaryCountryCode, " +
                                     "DictionaryCountryNationality " +
                                     "FROM DictionaryCountry";

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<CountryModel> countries = new List<CountryModel>();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    countries.Add(new CountryModel()
                    {
                        CountryName = sqlDataReader.GetString("DictionaryCountryName"),
                        CountryId = sqlDataReader.GetInt32("DictionaryCountryId"),
                        CountryCode = sqlDataReader.GetString("DictionaryCountryCode"), 
                        CountryNationality = sqlDataReader.GetString("DictionaryCountryNationality")
                    });
                }
            }

            sqlDataReader.Close();

            return countries;
        }

        public List<CountryModel> GetCountry(string keyword)
        {
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = $"EXEC spCountries_GetByKeyword " +
                                     $"@Keyword='{keyword}'";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<CountryModel> countries = new List<CountryModel>();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    countries.Add(new CountryModel()
                    {
                        CountryName = sqlDataReader.GetString("DictionaryCountryName"),
                        CountryId = sqlDataReader.GetInt32("DictionaryCountryId"),
                        CountryCode = sqlDataReader.GetString("DictionaryCountryCode"),
                        CountryNationality = sqlDataReader.GetString("DictionaryCountryNationality")
                    });
                }
            }

            sqlDataReader.Close();

            return countries;
        }




        public void UpdateCountry(int countryId, string countryName, string countryCode, string nationality)
        {

            SqlCommand sqlCommand = new SqlCommand("spCountries_Update", sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.Add(new SqlParameter("@DictionaryCountryId", SqlDbType.Int).Value = ValueOrNull(countryId));
            sqlCommand.Parameters.Add(new SqlParameter("@DictionaryCountryName", SqlDbType.NVarChar).Value = ValueOrNull(countryName));
            sqlCommand.Parameters.Add(new SqlParameter("@DictionaryCountryCode", SqlDbType.NVarChar).Value = ValueOrNull(countryCode));
            sqlCommand.Parameters.Add(new SqlParameter("@DictionaryCountryNationality", SqlDbType.NVarChar).Value = ValueOrNull(nationality));

            sqlCommand.ExecuteNonQuery();
        }

        protected object ValueOrNull(object value)
        {
            return value ?? DBNull.Value;
        }


    }
}
