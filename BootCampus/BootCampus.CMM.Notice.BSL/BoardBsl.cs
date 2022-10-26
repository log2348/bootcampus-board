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
    public class BoardBsl
    {
        #region Board 단건 조회
        public BoardModel SelectBoard(int seq)
        {
            BoardDsl boardDsl = new BoardDsl();
            BoardModel boardModel = boardDsl.SelectBoard(seq);

            return boardModel;
        }
        #endregion

        #region 전체 Board List 조회
        public List<BoardModel> SelectBoardList()
        {
            BoardDsl boardDsl = new BoardDsl();
            DataSet ds = boardDsl.SelectBoardList();

            DataTable dataTable = ds.Tables["Board"];

            List<BoardModel> boardList = new List<BoardModel>();
            foreach (DataRow dr in dataTable.Rows)
            {
                BoardModel boardModel = new BoardModel();
                boardModel.BOARD_SEQ = Convert.ToInt32(dr["BOARD_SEQ"]);
                boardModel.STATE = Convert.ToString(dr["STATE"]);
                boardModel.TITLE = Convert.ToString(dr["TITLE"]);
                boardModel.USER_ID = Convert.ToString(dr["USER_ID"]);
                boardModel.WRITE_DATE = Convert.ToString(dr["WRITE_DATE"]);
                boardModel.VIEW_COUNT = Convert.ToInt32(dr["VIEW_COUNT"]);

                boardList.Add(boardModel);
            }

            return boardList;
        }
        #endregion

        #region 게시글 등록
        public int CreateBoard(BoardModel board)
        {
            BoardDsl boardDsl = new BoardDsl();
            int result = boardDsl.CreateBoard(board);

            return result;

        }
        #endregion

        #region 상태별 게시글 조회
        public List<BoardModel> SelectBoardListByState(string state)
        {
            BoardDsl boardDsl = new BoardDsl();
            DataSet ds = boardDsl.SelectBoardByState(state);

            DataTable dataTable = ds.Tables["Board"];

            List<BoardModel> boardList = new List<BoardModel>();
            foreach (DataRow dr in dataTable.Rows)
            {
                BoardModel boardModel = new BoardModel();
                boardModel.BOARD_SEQ = Convert.ToInt32(dr["BOARD_SEQ"]);
                boardModel.STATE = Convert.ToString(dr["STATE"]);
                boardModel.TITLE = Convert.ToString(dr["TITLE"]);
                boardModel.USER_ID = Convert.ToString(dr["USER_ID"]);
                boardModel.WRITE_DATE = Convert.ToString(dr["WRITE_DATE"]);
                boardModel.VIEW_COUNT = Convert.ToInt32(dr["VIEW_COUNT"]);

                boardList.Add(boardModel);
            }

            return boardList;
        }

        #endregion

        #region 게시글 검색
        public List<BoardModel> SearchList(string searchType, string searchWord)
        {
            BoardDsl boardDsl = new BoardDsl();
            DataSet ds = boardDsl.SearchList(searchType, searchWord);

            DataTable dataTable = ds.Tables["Board"];

            List<BoardModel> boardList = new List<BoardModel>();
            foreach (DataRow dr in dataTable.Rows)
            {
                BoardModel boardModel = new BoardModel();
                boardModel.BOARD_SEQ = Convert.ToInt32(dr["BOARD_SEQ"]);
                boardModel.STATE = Convert.ToString(dr["STATE"]);
                boardModel.TITLE = Convert.ToString(dr["TITLE"]);
                boardModel.USER_ID = Convert.ToString(dr["USER_ID"]);
                boardModel.WRITE_DATE = Convert.ToString(dr["WRITE_DATE"]);
                boardModel.VIEW_COUNT = Convert.ToInt32(dr["VIEW_COUNT"]);

                boardList.Add(boardModel);
            }

            return boardList;
        }

        #endregion

        #region 게시글 페이징
        public List<BoardModel> SelectPage(int pageNumber)
        {
            BoardDsl boardDsl = new BoardDsl();
            DataSet ds = boardDsl.SelectPage(pageNumber);

            DataTable dataTable = ds.Tables["Board"];

            List<BoardModel> boardList = new List<BoardModel>();
            foreach (DataRow dr in dataTable.Rows)
            {
                BoardModel boardModel = new BoardModel();
                boardModel.BOARD_SEQ = Convert.ToInt32(dr["BOARD_SEQ"]);
                boardModel.STATE = Convert.ToString(dr["STATE"]);
                boardModel.TITLE = Convert.ToString(dr["TITLE"]);
                boardModel.USER_ID = Convert.ToString(dr["USER_ID"]);
                boardModel.WRITE_DATE = Convert.ToString(dr["WRITE_DATE"]);
                boardModel.VIEW_COUNT = Convert.ToInt32(dr["VIEW_COUNT"]);

                boardList.Add(boardModel);
            }

            return boardList;
        }

        #endregion

        #region 게시글 삭제
        public int DeleteBoard(int boardSeq)
        {
            BoardDsl boardDsl = new BoardDsl();
            int result = boardDsl.DeleteBoard(boardSeq);

            return result;

        }

        public int UpdateBoard(BoardModel boardModel)
        {
            BoardDsl boardDsl = new BoardDsl();
            int result = boardDsl.UpdateBoard(boardModel);

            return result;
        }
        #endregion
    }

}
