using System;
using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly SqlConnection sqlConnection;

        public AdminRepository(SqlConnection SqlConnection)
        {
            sqlConnection = SqlConnection;
        }
        public List<AdminModel> GetAdmins()
        {

            List<AdminModel> admins = new List<AdminModel>();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT AdminId, AdminEmail " +
                                     " FROM Admin";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    admins.Add(new AdminModel()
                    {
                        AdminId = sqlDataReader.GetInt32("AdminId"),
                        AdminEmail = sqlDataReader.GetString("AdminEmail"),
                    });
                }
            }
            return admins;
        }
    }
}
