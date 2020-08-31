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
            SqlCommand sqlCommand = new SqlCommand("spCountries_DeleteById", sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.Add(new SqlParameter("@DictionaryCountryId", countryId));

            sqlCommand.ExecuteNonQuery();
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
            SqlCommand sqlCommand = new SqlCommand("spCountries_GetByKeyword", sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.Add(new SqlParameter("@Keyword", keyword));

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

            sqlCommand.Parameters.Add(new SqlParameter("@DictionaryCountryId", countryId));
            sqlCommand.Parameters.Add(new SqlParameter("@DictionaryCountryName", countryName));
            sqlCommand.Parameters.Add(new SqlParameter("@DictionaryCountryCode", countryCode));
            sqlCommand.Parameters.Add(new SqlParameter("@DictionaryCountryNationality", nationality));

            sqlCommand.ExecuteNonQuery();
        }

        public void InsertCountry(string countryName, string countryCode, string nationality)
        {
            SqlCommand sqlCommandMaxId = sqlConnection.CreateCommand();
            sqlCommandMaxId.CommandText = $"SELECT MAX(DictionaryCountryId) AS DictionaryCountryId " +
                    $"                     FROM DictionaryCountry";
            SqlDataReader sqlDataReaderMaxId = sqlCommandMaxId.ExecuteReader();

            if (sqlDataReaderMaxId.HasRows)
            {
                sqlDataReaderMaxId.Read();
                int insertedId = sqlDataReaderMaxId.GetInt32("DictionaryCountryId") + 1;

                SqlCommand sqlCommandInsert = new SqlCommand("spCountries_Insert", sqlConnection);
                sqlCommandInsert.CommandType = CommandType.StoredProcedure;

                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryCountryId", insertedId));
                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryCountryName", countryName));
                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryCountryCode", countryCode));
                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryCountryNationality", nationality));

                sqlCommandInsert.ExecuteNonQuery();
            }
            else
            {
                int insertedId = 1;

                SqlCommand sqlCommandInsert = new SqlCommand("spCountries_Insert", sqlConnection);
                sqlCommandInsert.CommandType = CommandType.StoredProcedure;

                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryCountryId", insertedId));
                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryCountryName", countryName));
                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionartCountryCode", countryCode));
                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryCountryNationality", nationality));

                sqlCommandInsert.ExecuteNonQuery();
            }
        }


    }
}
