using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootCampus.Models;

namespace BootCampus.CMM.Notice.DSL
{
    public class BoardDsl
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

        #region Board 조회
        public DataSet SelectBoard()
        {
            conn = DbConn();

            SqlCommand cmd = new SqlCommand("dbo.UP_BOOTCAMPUS_BOARD_R", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BOARD_SEQ", 5);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            dataAdapter.Fill(ds, "Board");

            conn.Close();

            return ds;
        }
        #endregion

        #region Board List 조회
        public DataSet SelectBoardList()
        {
            conn = DbConn();

            string sql = "SELECT * FROM dbo.TB_BOARD";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            dataAdapter.Fill(ds, "Board");

            conn.Close();

            return ds;
        }
        #endregion

        #region Board 등록
        #endregion
    }
}
