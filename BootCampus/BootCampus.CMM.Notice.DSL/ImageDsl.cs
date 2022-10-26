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
            FileStream fs = new FileStream(@"D:\test", FileMode.Open, FileAccess.Read);
            byte[] bImage = new byte[fs.Length];
            fs.Read(bImage, 0, (int)fs.Length);

            SqlCommand cmd = new SqlCommand("INSERT INTO IMAGE (IMAGE_SEQ, FILE_NAME) VALUES(@IMAGE_SEQ, @FILE_NAME)", conn);
            cmd.Parameters.AddWithValue("@IMAGE_SEQ", 1);
            cmd.Parameters.AddWithValue("@FILE_NAME", bImage);

            fs.Close();

            return 0;
        }
        #endregion

        #region 게시글별 이미지 조회
        public ImageModel SelectImage(int boardSeq)
        {
            SqlCommand cmd = new SqlCommand("SELECT Image FROM IMAGE WHERE ImageNo=@ImageNo", conn);
            cmd.Parameters.AddWithValue("@ImageNo", 1);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            byte[] bImage = null;

            while (reader.Read())
            {
                bImage = (byte[])reader[0];
            }

            ImageModel imageModel = new ImageModel();   

            if (bImage != null)
                // imageModel.FILE_NAME = new Bitmap(new MemoryStream(bImage));

            reader.Close();
            conn.Close();

            return imageModel;
        }
        #endregion

    }
}
