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
        public int Create(BoardModel newBoard)
        {
            BoardBsl boardBsl = new BoardBsl();
            int result = boardBsl.CreateBoard(newBoard);

            return result;
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
        /// 게시글 검색
        /// </summary>
        /// <param name="searchType"></param>
        /// <param name="searchWord"></param>
        /// <returns></returns>
        public ActionResult Search(string searchType, string searchWord)
        {
            BoardBsl boardBsl = new BoardBsl();
            List<BoardModel> boardList = boardBsl.SearchList(searchType, searchWord);
            return Json(boardList, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// 게시글 목록 페이징
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public ActionResult BoardPage(int pageNumber)
        {
            BoardBsl boardBsl = new BoardBsl();
            List<BoardModel> boardList = boardBsl.SelectPage(pageNumber);

            return Json(boardList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 게시글 삭제
        /// </summary>
        /// <param name="boardSeq"></param>
        /// <returns></returns>
        public int Delete(int boardSeq)
        {
            BoardBsl boardBsl = new BoardBsl();
            int result = boardBsl.DeleteBoard(boardSeq);

            return result;
        }

        /// <summary>
        /// 게시글 수정
        /// </summary>
        /// <param name="boardModel"></param>
        /// <returns></returns>
        public int Update(BoardModel boardModel)
        {
            BoardBsl boardBsl = new BoardBsl();
            int result = boardBsl.UpdateBoard(boardModel);

            return result;
        }

        /// <summary>
        /// 게시글 상태 수정
        /// </summary>
        /// <param name="boardModel"></param>
        /// <returns></returns>
        public int UpdateState(int boardSeq, string state)
        {
            BoardBsl boardBsl = new BoardBsl();
            int result = boardBsl.UpdateState(boardSeq, state);

            return result;
        }

    }
}