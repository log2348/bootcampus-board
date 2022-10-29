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

        #region 게시글별 댓글 목록 조회
        public List<ReplyModel> SelectReplyList(int boardSeq)
        {
            ReplyDsl replyDsl = new ReplyDsl();
            DataSet ds = replyDsl.SelectReplyList(boardSeq);

            DataTable dataTable = ds.Tables["Reply"];

            List<ReplyModel> replyList = new List<ReplyModel>();
            foreach (DataRow dr in dataTable.Rows)
            {
                ReplyModel replyModel = new ReplyModel();
                replyModel.LEVEL = Convert.ToInt32(dr["LEVEL"]);
                replyModel.USER_ID = Convert.ToString(dr["USER_ID"]);
                replyModel.REPLY_SEQ = Convert.ToInt32(dr["REPLY_SEQ"]);
                replyModel.BOARD_SEQ = Convert.ToInt32(dr["BOARD_SEQ"]);
                replyModel.WRITE_DATE = Convert.ToString(dr["CREATE_DATE"]);
                replyModel.REPLY_CONTENTS = Convert.ToString(dr["REPLY_CONTENTS"]);

                if (Convert.ToString(dr["PARENT_SEQ"]) != "")
                {
                    replyModel.PARENT_SEQ = Convert.ToInt32(dr["PARENT_SEQ"]);
                }

                replyList.Add(replyModel);
            }

            return replyList;
        }
        #endregion

        #region 댓글 수정
        public int UpdateReply(ReplyModel replyModel)
        {
            ReplyDsl replyDsl = new ReplyDsl();
            int result = replyDsl.UpdateReply(replyModel);

            return result;
        }
        #endregion

        #region 댓글 삭제
        public int DeleteReply(int replySeq)
        {
            ReplyDsl replyDsl = new ReplyDsl();
            int result = replyDsl.DeleteReply(replySeq);

            return result;
        }
        #endregion

        #region 댓글 등록
        public int CreateReply(ReplyModel replyModel)
        {
            ReplyDsl replyDsl = new ReplyDsl();
            int result = replyDsl.CreateReply(replyModel);

            return result;
        }
        #endregion
    }
}
