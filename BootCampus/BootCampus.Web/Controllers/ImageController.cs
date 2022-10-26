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
        public int Create(ImageModel imageModel)
        {
            ImageBsl imageBsl = new ImageBsl();
            int result = imageBsl.CreateImage(imageModel);

            return result;
        }
    }
}