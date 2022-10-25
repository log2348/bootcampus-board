using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampus.CMM.Notice.DSL
{
    public class ReplyDsl
    {
        private const string _connectionString =
                "Data Source=localhost;Initial Catalog=BOOTCAMPUS;User Id=test;Password=1234";

        private SqlConnection conn = new SqlConnection(_connectionString);

        #region DataBase Connection
        public SqlConnection DbConn()
        {
            conn.Open();

            return conn;
        }
        #endregion

        #region 댓글 목록 전체 조회
        public DataSet SelectReplyList(int boardSeq)
        {
            conn = DbConn();

            SqlCommand cmd = new SqlCommand("[dbo].[UP_BOOTCAMPUS_REPLY_L]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BOARD_SEQ", boardSeq);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            dataAdapter.Fill(ds, "Reply");

            conn.Close();

            return ds;
        }
        #endregion
    }
}
