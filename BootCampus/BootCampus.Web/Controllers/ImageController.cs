using BootCampus.CMM.Notice.BSL;
using BootCampus.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace BootCampus.Web.Controllers
{
    public class ImageController : Controller
    {
        /// <summary>
        /// 이미지 파일 저장
        /// </summary>
        public JavaScriptResult Create()
        {
            ImageBsl imageBsl = new ImageBsl();
            ImageModel imageModel = new ImageModel();
            int result = 0;


            if (HttpContext.Request.Files.Count > 0)
            {
                HttpContext.Request.Files["imageModel"].InputStream.Position = 0;
                byte[] bImage = this.ReadFully(HttpContext.Request.Files["imageModel"].InputStream);

                imageModel.FILE_NAME = HttpContext.Request.Files["imageModel"].FileName ?? "이미지";
                imageModel.IMAGE_DATA = bImage;
                result = imageBsl.CreateImage(imageModel);

            }

            JavaScriptResult jsr = new JavaScriptResult();
            if (result == 1)
            {
                jsr.Script = "<script>alert('이미지가 저장되었습니다.')</script>";
            }
            else
            {
                jsr.Script = "<script>alert('이미지가 저장되지 않았습니다.')</script>";
            }
            return jsr;

        }

        /// <summary>
        /// 이미지 파일 byte 변환
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public ImageModel Select(int imageSeq)
        {
            ImageBsl imageBsl = new ImageBsl();
            return imageBsl.SelectImage(imageSeq);

        }

    }
}