using BootCampus.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampus.CMM.Notice.DSL
{
    public class UserDsl
    {
        private const string _connectionString =
                "Data Source=localhost;Initial Catalog=BOOTCAMPUS;User Id=test;Password=1234";

        private SqlConnection conn = new SqlConnection(_connectionString);

        public SqlConnection DbConn()
        {
            conn.Open();

            return conn;
        }

        public int Login(UserModel userModel)
        {
            conn = DbConn();

            string sql = "SELECT PASSWORD FROM [dbo].[TB_USER] WHERE USERNAME = " + userModel.USERNAME;

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            conn.Close();

            return 0;

        }
    }
}
