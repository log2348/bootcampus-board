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
        #region Board List 조회
        public List<BoardModel> SelectBoard()
        {
            BoardDsl boardDsl = new BoardDsl();
            DataSet ds = boardDsl.SelectBoard();

            DataTable dataTable = ds.Tables["Board"];

            List<BoardModel> boardList = new List<BoardModel>();
            foreach (DataRow dr in dataTable.Rows)
            {
                BoardModel boardModel = new BoardModel();
                boardModel.BOARD_SEQ = Convert.ToInt32(dr["BOARD_SEQ"]);

                boardList.Add(boardModel);
            }

            return boardList;
        }
        #endregion
    }
}
