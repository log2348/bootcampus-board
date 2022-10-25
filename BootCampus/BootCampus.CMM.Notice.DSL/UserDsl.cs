using BootCampus.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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

            SqlCommand cmd = new SqlCommand("SELECT PASSWORD FROM [dbo].[TB_USER] WHERE USER_ID = @USER_ID", conn);
            cmd.Parameters.AddWithValue("@USER_ID", userModel.USER_ID);

            // 쿼리 결과 담기
            SqlDataReader reader = cmd.ExecuteReader();

            // 다음 항목 유무 true/false 반환
            if (reader.Read())
            {
                if (reader["PASSWORD"].Equals(userModel.PASSWORD))
                {
                    // 로그인 성공   
                    return 1;
                } else
                {
                    // 비밀번호 불일치
                    return 0;
                }
            } else
            {
                // 아이디 존재하지 않음
                return -1;
            }

            conn.Close();

        }
    }
}
