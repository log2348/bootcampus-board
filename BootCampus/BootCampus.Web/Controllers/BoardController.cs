using BootCampus.CMM.Notice.BSL;
using BootCampus.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootCampus.Web.Controllers
{
    public class BoardController : Controller
    {
        /// <summary>
        /// 게시글 상세 조회
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail(int seq)
        {
            BoardBsl boardBsl = new BoardBsl();
            BoardModel target = boardBsl.SelectBoard(seq);

            return Json(target, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 전체 게시글 목록 조회
        /// </summary>
        /// <returns></returns>
        public ActionResult BoardList()
        {
            BoardBsl boardBsl = new BoardBsl();
            List<BoardModel> boardList = boardBsl.SelectBoardList();

            return Json(boardList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 게시글 등록
        /// </summary>
        public void Create(BoardModel newBoard)
        {
            BoardBsl boardBsl = new BoardBsl();
            BoardModel boardModel = boardBsl.CreateBoard(newBoard);

        }

        /// <summary>
        /// 상태별 게시글 목록 조회
        /// </summary>
        /// <returns></returns>
        public ActionResult BoardListByState(string state)
        {
            BoardBsl boardBsl = new BoardBsl();
            List<BoardModel> boardList = boardBsl.SelectBoardListByState(state);
            return Json(boardList, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// 엑셀 파일 다운로드
        /// </summary>
        /// <returns></returns>
        public FileStreamResult FileDownload()
        {
            FileStream fs = new FileStream(@"D:\Log\ServiceLayer\20150321.__Anonymous.1.log", FileMode.Open);​

            FileStreamResult fsr = new FileStreamResult(fs, System.Net.Mime.MediaTypeNames.Application.Octet.ToString());​

            fsr.FileDownloadName = "myfile.log";​

            return fsr;​
        }

    }
}