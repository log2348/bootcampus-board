using System.Data;
using System.Data.SqlClient;

namespace BootCampus.CMM.Notice.DSL
{
    public class NoticeDsl
    {
        private const string _connectionString = @"server=121.162.252.2;database=CRONG_DB;pwd=affairs@1q2w3e;user id=affairsUser;Pooling=True;Min Pool Size=10;Max Pool Size=150;Load Balance Timeout=360;Connection Lifetime=360;Connect Timeout=30;Enlist=True;TrustServerCertificate=True";

        private SqlConnection conn = new SqlConnection(_connectionString);

        #region DataBase Connection
        public SqlConnection DbConn()
        {
            conn.Open();

            return conn;
        }
        #endregion

        #region Notice List 조회
        public DataSet SelectNoticeList()
        {
            conn = DbConn();

            SqlCommand cmd = new SqlCommand("dbo.SP_NoticeList_Select", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@page", 1);
            cmd.Parameters.AddWithValue("@pagesize", 5);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            dataAdapter.Fill(ds, "Notice");
            dataAdapter.Fill(ds, "Notice1");

            conn.Close();

            return ds;
        }
        #endregion
    }
}