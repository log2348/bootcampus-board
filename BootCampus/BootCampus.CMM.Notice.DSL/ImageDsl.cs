using BootCampus.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampus.CMM.Notice.DSL
{
    public class ImageDsl
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

        #region 이미지 등록
        public int CreateImage(ImageModel imageModel)
        {
            conn = DbConn();

            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[TB_IMAGE] (FILE_NAME, IMAGE_DATA) VALUES(@FILE_NAME, @IMAGE_DATA)", conn);
            cmd.Parameters.AddWithValue("@IMAGE_DATA", imageModel.IMAGE_DATA);
            cmd.Parameters.AddWithValue("@FILE_NAME", imageModel.FILE_NAME);

            int result = cmd.ExecuteNonQuery();

            return result;
        }
        #endregion

        #region 이미지 조회
        public ImageModel SelectImage(int imageSeq)
        {
            conn = DbConn();

            SqlCommand cmd = new SqlCommand("SELECT Image FROM IMAGE WHERE IMAGE_SEQ = @IMAGE_SEQ", conn);
            cmd.Parameters.AddWithValue("@IMAGE_SEQ", imageSeq);

            SqlDataReader reader = cmd.ExecuteReader();

            byte[] bImage = null;

            while (reader.Read())
            {
                bImage = (byte[])reader[0];
            }

            ImageModel imageModel = new ImageModel();

            if (bImage != null)
                //imageModel.IMAGE_DATA = new Bitmap(new MemoryStream(bImage));

                reader.Close();

            conn.Close();

            return imageModel;
        }
        #endregion

    }
}
