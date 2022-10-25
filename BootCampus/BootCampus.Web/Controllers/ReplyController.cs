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
    }
}