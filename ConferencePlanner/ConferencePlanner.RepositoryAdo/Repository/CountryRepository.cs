using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            sqlCommand.CommandText = "SELECT DictionaryCountryName, DictionaryCountryId, DictionaryCountryCode " +
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
                        CountryCode = sqlDataReader.GetString("DictionaryCountryCode")
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
                                     $"@Keyword={keyword}";
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
                        CountryCode = sqlDataReader.GetString("DictionaryCountryCode")
                    });
                }
            }

            sqlDataReader.Close();

            return countries;
        }

        public void InsertCountry(int countryId, string countryName, string countryCode, string nationality)
        {
            //TODO insert country
        }

        public void ModifyCountry(int countryId)
        {
            //TODO modify country
        }
    }
}
