using BootCampus.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

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
        public string SelectImage(int imageSeq)
        {
            conn = DbConn();

            ImageModel imageModel = new ImageModel();

            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[TB_IMAGE] WHERE [IMAGE_SEQ] = (SELECT MAX([IMAGE_SEQ]) FROM [dbo].[TB_IMAGE])", conn);
            //cmd.Parameters.AddWithValue("@IMAGE_SEQ", imageSeq);

            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            string base64Data = "";

            if (sqlDataReader.Read())
            {
                byte[] data = GetFileBinary(Convert.ToString(sqlDataReader["FILE_NAME"]));
                base64Data = Convert.ToBase64String(data);
            }

            return base64Data;
        }
        #endregion

        #region byte 변환
        public byte[] GetFileBinary(String filepath)
        {
            var file = new FileInfo(filepath);
            var data = new byte[file.Length];
            using (var stream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
            {
                stream.Read(data, 0, (int)data.Length);
            }
            return data;
        }
        #endregion

    }
}
