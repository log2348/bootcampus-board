﻿using BootCampus.Models;
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

        FileStream fs;
        BinaryReader br;
        BinaryWriter bw;

        string directory = @"D:\\test\\";

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
            FileStream fs = new FileStream(@"D:\test\data.bin", FileMode.Open, FileAccess.Read);
            byte[] bImage = new byte[fs.Length];
            fs.Read(bImage, 0, (int)fs.Length);

            //byte[] imageData = this.GetImageByte(imageModel);

            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[TB_IMAGE] (IMAGE_SEQ, FILE_NAME) VALUES(@IMAGE_SEQ, @FILE_NAME)", conn);
            cmd.Parameters.AddWithValue("@IMAGE_SEQ", 1);
            cmd.Parameters.AddWithValue("@FILE_NAME", imageModel.FILE_NAME);

            //fs.Close();

            return 0;
        }
        #endregion

        private byte[] GetImageByte(string filePath)
        {
            fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            br = new BinaryReader(fs);

            byte[] imageBytes = br.ReadBytes((int)fs.Length);

            br.Close();
            fs.Close();

            return imageBytes;
        }

        #region 게시글별 이미지 조회
        public ImageModel SelectImage(int boardSeq)
        {
            conn = DbConn();

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
