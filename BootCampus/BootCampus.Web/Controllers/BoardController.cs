using BootCampus.CMM.Notice.BSL;
using BootCampus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootCampus.Web.Controllers
{
    public class BoardController : Controller
    {
        // GET: Board
        public string Index()
        {
            return "test";
        }

        /// <summary>
        /// 게시글 목록 조회
        /// </summary>
        /// <returns></returns>
        public ActionResult Board()
        {
            BoardBsl boardBsl = new BoardBsl();
            List<BoardModel> list = boardBsl.SelectBoard();

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}