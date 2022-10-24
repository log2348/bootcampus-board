using System.Data;
using System.Data.SqlClient;

namespace BootCampus.CMM.Notice.DSL
{
    public class NoticeDsl { 
        
        private const string _connectionString = "Data Source=localhost;Initial Catalog=BOOTCAMPUS;Integrated Security = SSPI";

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