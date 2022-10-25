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

        #region 게시글 상세 조회
        public BoardModel SelectBoard(int seq)
        {
            conn = DbConn();

            string sql = "SELECT * FROM [dbo].[TB_BOARD] WHERE BOARD_SEQ = @BOARD_SEQ";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@BOARD_SEQ", seq);
            cmd.CommandType = CommandType.Text;

            BoardModel model = new BoardModel();

            // 쿼리 결과 불러와서 저장
            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            if (sqlDataReader.Read())
            {
                model.BOARD_SEQ = Convert.ToInt32(sqlDataReader["BOARD_SEQ"]);
                model.STATE = Convert.ToString(sqlDataReader["STATE"]);
                model.TITLE = Convert.ToString(sqlDataReader["TITLE"]);
                model.CONTENTS = Convert.ToString(sqlDataReader["CONTENTS"]);
                model.WRITE_DATE = Convert.ToDateTime(sqlDataReader["WRITE_DATE"]);
                model.USER_ID = Convert.ToString(sqlDataReader["USER_ID"]);
                model.VIEW_COUNT = Convert.ToInt32(sqlDataReader["VIEW_COUNT"]);

            }

            conn.Close();

            return model;
        }
        #endregion

        #region Board List 조회
        public DataSet SelectBoardList()
        {
            conn = DbConn();

            SqlCommand cmd = new SqlCommand("[dbo].[UP_BOOTCAMPUS_BOARD_L]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            dataAdapter.Fill(ds, "Board");

            conn.Close();

            return ds;
        }
        #endregion

        #region Board 등록
        #endregion

        #region 게시글 상태별 검색
        public DataSet SelectBoardByState(string state)
        {
            conn = DbConn();

            SqlCommand cmd = new SqlCommand("[dbo].[UP_BOOTCAMPUS_BOARD_L]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (state != null)
            {
                cmd.Parameters.AddWithValue("@STATE", state);
            }

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            dataAdapter.Fill(ds, "Board");

            conn.Close();

            return ds;
        }

        #endregion

        #region 게시글 검색
        public DataSet SearchList(string searchType, string searchWord)
        {
            conn = DbConn();

            SqlCommand cmd = new SqlCommand("[dbo].[UP_BOOTCAMPUS_BOARD_L]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SEARCH_TYPE", searchType);
            cmd.Parameters.AddWithValue("@SEARCH_WORD", searchWord);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            dataAdapter.Fill(ds, "Board");

            conn.Close();

            return ds;
        }
        #endregion

        #region 게시글 페이징
        public DataSet SelectPage(int pageNumber)
        {
            conn = DbConn();

            SqlCommand cmd = new SqlCommand("[dbo].[UP_BOOTCAMPUS_BOARD_L]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PAGE", pageNumber);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            dataAdapter.Fill(ds, "Board");

            conn.Close();

            return ds;
        }
        #endregion
    }
}
