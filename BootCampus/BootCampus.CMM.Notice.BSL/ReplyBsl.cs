using BootCampus.CMM.Notice.DSL;
using BootCampus.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampus.CMM.Notice.BSL
{
    public class ReplyBsl
    {
        public List<ReplyModel> SelectReplyList(int boardSeq)
        {
            ReplyDsl replyDsl = new ReplyDsl();
            DataSet ds = replyDsl.SelectReplyList(boardSeq);

            DataTable dataTable = ds.Tables["Reply"];

            List<ReplyModel> replyList = new List<ReplyModel>();
            foreach (DataRow dr in dataTable.Rows)
            {
                ReplyModel replyModel = new ReplyModel();
                replyModel.BOARD_SEQ = Convert.ToInt32(dr["BOARD_SEQ"]);

                replyList.Add(replyModel);
            }

            return replyList;
        }
    }
}
