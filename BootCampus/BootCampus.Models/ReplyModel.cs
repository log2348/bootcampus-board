using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampus.Models
{
    public class ReplyModel
    {
        public int REPLY_SEQ { get; set; }

        public int PARENT_ID { get; set; }

        public int BOARD_SEQ { get; set; }

        public string REPLY_CONTENTS { get; set; }

        public string USER_ID { get; set; }

        public DateTime WRITE_DATE { get; set; }

    }
}
