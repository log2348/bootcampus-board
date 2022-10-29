using BootCampus.Models;
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

        #region 댓글 수정
        public int UpdateReply(ReplyModel replyModel)
        {
            conn = DbConn();

            SqlCommand cmd = new SqlCommand("[dbo].[UP_BOOTCAMPUS_REPLY_U]", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@REPLY_SEQ", replyModel.REPLY_SEQ);
            cmd.Parameters.AddWithValue("@REPLY_CONTENTS", replyModel.REPLY_CONTENTS);

            // 영향 받은 행 개수 반환, 오류 발생시 -1 반환
            int result = cmd.ExecuteNonQuery();

            return result;
        }
        #endregion

        #region 댓글 삭제
        public int DeleteReply(int replySeq)
        {
            conn = DbConn();

            SqlCommand cmd = new SqlCommand("[dbo].[UP_BOOTCAMPUS_REPLY_D]", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@REPLY_SEQ", replySeq);

            // 영향 받은 행 개수 반환, 오류 발생시 -1 반환
            int result = cmd.ExecuteNonQuery();

            return result;
        }
        #endregion

        #region 댓글 등록
        public int CreateReply(ReplyModel replyModel)
        {
            conn = DbConn();

            SqlCommand cmd = new SqlCommand("[dbo].[UP_BOOTCAMPUS_REPLY_C]", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            if (!replyModel.PARENT_SEQ.Equals(0))
            {
                cmd.Parameters.AddWithValue("@PARENT_SEQ", replyModel.PARENT_SEQ);

            }
            cmd.Parameters.AddWithValue("@BOARD_SEQ", replyModel.BOARD_SEQ);
            cmd.Parameters.AddWithValue("@USER_ID", replyModel.USER_ID);
            cmd.Parameters.AddWithValue("@REPLY_CONTENTS", replyModel.REPLY_CONTENTS);

            // 삽입 쿼리 사용시
            // 영향 받은 행 개수 반환, 오류 발생시 -1 반환
            int result = cmd.ExecuteNonQuery();

            return result;
        }
        #endregion

        #region 게시글 삭제시 댓글 전체 삭제
        public int DeleteAllReply(int boardSeq)
        {
            conn = DbConn();

            SqlCommand cmd = new SqlCommand("[dbo].[UP_BOOTCAMPUS_REPLY_D2]", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BOARD_SEQ", boardSeq);

            int result = cmd.ExecuteNonQuery();

            return result;
        }
        #endregion
    }
}
