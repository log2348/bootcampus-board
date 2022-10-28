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
                model.WRITE_DATE = Convert.ToString(sqlDataReader["WRITE_DATE"]);
                model.USER_ID = Convert.ToString(sqlDataReader["USER_ID"]);
                model.VIEW_COUNT = Convert.ToInt32(sqlDataReader["VIEW_COUNT"]);

            }

            conn.Close();

            return model;
        }
        #endregion

        #region 게시글 전체 목록 조회
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

        #region 게시글 상태별 검색
        public DataSet SelectBoardByState(string state)
        {
            conn = DbConn();

            SqlCommand cmd = new SqlCommand("[dbo].[UP_BOOTCAMPUS_BOARD_L]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@STATE", state);
            cmd.Parameters.AddWithValue("@ROW_COUNT", 5);

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

        #region 게시글 등록
        public int CreateBoard(BoardModel newBoard)
        {
            conn = DbConn();

            SqlCommand cmd = new SqlCommand("[dbo].[UP_BOOTCAMPUS_BOARD_C]", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@STATE", "접수됨");
            cmd.Parameters.AddWithValue("@TITLE", newBoard.TITLE);
            cmd.Parameters.AddWithValue("@CONTENTS", newBoard.CONTENTS);
            cmd.Parameters.AddWithValue("@USER_ID", newBoard.USER_ID);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            dataAdapter.Fill(ds, "Board");

            conn.Close();

            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }
        #endregion

        #region 게시글 삭제
        public int DeleteBoard(int boardSeq)
        {
            conn = DbConn();

            SqlCommand cmd = new SqlCommand("[dbo].[UP_BOOTCAMPUS_BOARD_D]", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BOARD_SEQ", boardSeq);

            // 영향 받은 행 개수 반환, 오류 발생시 -1 반환
            int result = cmd.ExecuteNonQuery();

            return result;
        }
        #endregion

        #region 게시글 수정
        public int UpdateBoard(BoardModel boardModel)
        {
            conn = DbConn();

            SqlCommand cmd = new SqlCommand("[dbo].[UP_BOOTCAMPUS_BOARD_U]", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@STATE", boardModel.STATE);
            cmd.Parameters.AddWithValue("@TITLE", boardModel.TITLE);
            cmd.Parameters.AddWithValue("@USER_ID", boardModel.USER_ID);
            cmd.Parameters.AddWithValue("@CONTENTS", boardModel.CONTENTS);
            cmd.Parameters.AddWithValue("@BOARD_SEQ", boardModel.BOARD_SEQ);

            // 영향 받은 행 개수 반환, 오류 발생시 -1 반환
            int result = cmd.ExecuteNonQuery();

            return result;
        }
        #endregion

        #region 게시글 상태 수정
        public int UpdateState(int boardSeq, string state)
        {
            conn = DbConn();

            SqlCommand cmd = new SqlCommand("[dbo].[UP_BOOTCAMPUS_BOARD_STATE_U]", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BOARD_SEQ", boardSeq);
            cmd.Parameters.AddWithValue("@STATE", state);

            int result = cmd.ExecuteNonQuery();

            return result;
        }
        #endregion

        #region 테이블의 총 행 개수 반환
        public int GetTotalRowCount()
        {
            conn = DbConn();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[TB_BOARD]", conn);

            cmd.CommandType = CommandType.Text;

            int result = Convert.ToInt32(cmd.ExecuteScalar());

            return result;
        }
        #endregion
    }
}
