using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampus.Models
{
    public class BoardAndImageModel
    {
        public int BOARD_SEQ { get; set; }

        public string STATE { get; set; }

        public string TITLE { get; set; }

        public string CONTENTS { get; set; }

        public string USER_ID { get; set; }

        public DateTime WRITE_DATE { get; set; }

        public int VIEW_COUNT { get; set; }

        public int IMAGE_SEQ { get; set; }

        public string FILE_NAME { get; set; }

        public string IMAGE_DATA { get; set; }


    }
}
