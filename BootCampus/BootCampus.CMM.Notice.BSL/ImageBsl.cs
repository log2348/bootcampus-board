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
        #region
        public int CreateImage(ImageModel imageModel)
        {
            ImageDsl imageDsl = new ImageDsl();
            int result = imageDsl.CreateImage(imageModel);

            return result;
        }
        #endregion
    }
}
