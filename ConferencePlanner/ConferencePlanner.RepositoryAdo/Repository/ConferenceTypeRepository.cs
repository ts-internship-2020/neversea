﻿using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class ConferenceTypeRepository : IConferenceTypeRepository
    {
        private readonly SqlConnection sqlConnection;

        public ConferenceTypeRepository(SqlConnection SqlConnection)
        {
            sqlConnection = SqlConnection;

        }

        public List<ConferenceTypeModel> getConferenceTypes()
        {

            List<ConferenceTypeModel> conferenceTypeModels = new List<ConferenceTypeModel>();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT DictionaryConferenceTypeId, DictionaryConferenceTypeName" +
                                     " FROM DictionaryConferenceType";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    conferenceTypeModels.Add(new ConferenceTypeModel()
                    {
                        conferenceTypeName = sqlDataReader.GetString("DictionaryConferenceTypeName"),
                        conferenceTypeId = sqlDataReader.GetInt32("DictionaryConferenceTypeId")
                    });
                }
            }

            sqlDataReader.Close();
            return conferenceTypeModels;
        }


        public List<ConferenceTypeModel> getConferenceTypes(string keyword)
        {

            List<ConferenceTypeModel> conferenceTypeModels = new List<ConferenceTypeModel>();


            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Key", keyword);

            
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "exec [spTypes_GetByKeyWord] @Key";
            sqlCommand.Parameters.Add(parameters[0]);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    conferenceTypeModels.Add(new ConferenceTypeModel()
                    {
                        conferenceTypeName = sqlDataReader.GetString("DictionaryConferenceTypeName"),
                        conferenceTypeId = sqlDataReader.GetInt32("DictionaryConferenceTypeId")
                    });
                }
            }

            sqlDataReader.Close();
            return conferenceTypeModels;
        }

        public void UpdateConferenceType(int conferenceTypeId, string conferenceTypeName)
        {

            SqlCommand sqlCommand = new SqlCommand("spConferenceTypes_Update", sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.Add(new SqlParameter("@DictionaryConferenceTypeId", conferenceTypeId));
            sqlCommand.Parameters.Add(new SqlParameter("@DictionaryConferenceTypeName", conferenceTypeName));

            sqlCommand.ExecuteNonQuery();
        }

        public void InsertConferenceType(string conferenceTypeName)
        {
            SqlCommand sqlCommandMaxId = sqlConnection.CreateCommand();
            sqlCommandMaxId.CommandText = $"SELECT MAX(DictionaryConferenceTypeId) AS DictionaryConferenceTypeId " +
                    $"                     FROM DictionaryConferenceType";
            SqlDataReader sqlDataReaderMaxId = sqlCommandMaxId.ExecuteReader();

            if (sqlDataReaderMaxId.HasRows)
            {
                sqlDataReaderMaxId.Read();
                int insertedId = sqlDataReaderMaxId.GetInt32("DictionaryConferenceTypeId") + 1;

                SqlCommand sqlCommandInsert = new SqlCommand("spConferenceTypes_Insert", sqlConnection);
                sqlCommandInsert.CommandType = CommandType.StoredProcedure;

                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryConferenceTypeId", insertedId));
                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryConferenceTypeName", conferenceTypeName));

                sqlCommandInsert.ExecuteNonQuery();
            }
            else
            {
                int insertedId = 1;

                SqlCommand sqlCommandInsert = new SqlCommand("spConferenceTypes_Insert", sqlConnection);
                sqlCommandInsert.CommandType = CommandType.StoredProcedure;

                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryConferenceTypeId", insertedId));
                sqlCommandInsert.Parameters.Add(new SqlParameter("@DictionaryConferenceTypeName", conferenceTypeName));

                sqlCommandInsert.ExecuteNonQuery();
            }
        }

        public void DeleteConferenceType(int conferenceTypeId)
        {
            SqlCommand sqlCommand = new SqlCommand("spConferenceTypes_Delete", sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.Add(new SqlParameter("@DictionaryConferenceTypeId", conferenceTypeId));

            sqlCommand.ExecuteNonQuery();
        }
    }
}

