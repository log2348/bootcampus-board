using BootCampus.CMM.Notice.BSL;
using BootCampus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootCampus.Web.Controllers
{
    public class ReplyController : Controller
    {
        /// <summary>
        /// 게시글 별 댓글 목록 조회
        /// </summary>
        /// <param name="boardSeq"></param>
        /// <returns></returns>
        public ActionResult ReplyList(int boardSeq)
        {
            ReplyBsl replyBsl = new ReplyBsl();
            List<ReplyModel> replyList = replyBsl.SelectReplyList(boardSeq);

            return Json(replyList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 댓글 등록
        /// </summary>
        /// <param name="replyModel"></param>
        /// <returns></returns>
        public int Create(ReplyModel replyModel)
        {
            ReplyBsl replyBsl = new ReplyBsl();
            int result = replyBsl.CreateReply(replyModel);

            return result;
        }

        /// <summary>
        /// 댓글 수정
        /// </summary>
        /// <param name="replyModel"></param>
        /// <returns></returns>
        public int Update(ReplyModel replyModel)
        {
            ReplyBsl replyBsl = new ReplyBsl();
            int result = replyBsl.UpdateReply(replyModel);

            return result;
        }

        /// <summary>
        /// 댓글 삭제
        /// </summary>
        /// <param name="replySeq"></param>
        /// <returns></returns>
        public int Delete(int replySeq)
        {
            ReplyBsl replyBsl = new ReplyBsl();
            int result = replyBsl.DeleteReply(replySeq);

            return result;
        }

    }
}