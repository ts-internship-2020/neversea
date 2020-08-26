using System;
using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class DistrictRepository: IDistrictRepository
    {
            private readonly SqlConnection sqlConnection;

        public DistrictRepository(SqlConnection SqlConnection)
        {
            sqlConnection = SqlConnection;

        }

            public void DeleteDistrict(int districtId)
            {
                throw new NotImplementedException();
            }

            public List<DistrictModel> GetDistrict()
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = $"SELECT DictionaryDistrictName, DictionaryDistrictId" +
                                         $"FROM DictionaryDistrict";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<DistrictModel> districts = new List<DistrictModel>();

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        districts.Add(new DistrictModel()
                        {
                            DistrictId = sqlDataReader.GetInt32("DictionaryDistrictId"),
                            DistrictName = sqlDataReader.GetString("DictionaryDistrictName"),
                        });
                    }
                }

                sqlDataReader.Close();

                return districts;
            }

            public List<DistrictModel> GetDistrict(string keyword)
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = $"EXEC spDistricts_GetByKeyword " +
                                         $"@Keyword={keyword}";
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
                        });
                    }
                }

                sqlDataReader.Close();

                return districts;
            }

            public void InsertDistrict(int districtId, string districtName)
            {

            }
            public void ModifyDistrict(int districtId)
            {
            
            }
        }
    }
