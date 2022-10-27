using BootCampus.CMM.Notice.DSL;
using BootCampus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampus.CMM.Notice.BSL
{
    public class ImageBsl
    {
        #region 이미지 저장
        public int CreateImage(string fileName)
        {
            ImageDsl imageDsl = new ImageDsl();
            int result = imageDsl.CreateImage(fileName);

            return result;
        }
        #endregion
    }
}
