using BootCampus.CMM.Notice.DSL;
using BootCampus.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace BootCampus.CMM.Notice.BSL
{
    public class NoticeBsl
    {
        #region Notice List 조회
        public List<NoticeModel> SelectNoticeList()
        {
            NoticeDsl noticeDsl = new NoticeDsl();
            DataSet ds = noticeDsl.SelectNoticeList();

            DataTable dataTable = ds.Tables["Notice"];

            List<NoticeModel> list = new List<NoticeModel>();
            foreach (DataRow dr in dataTable.Rows)
            {
                NoticeModel noticeModel = new NoticeModel();
                noticeModel.BOARD_SEQ = Convert.ToInt32(dr["RowId"]);

                list.Add(noticeModel);
            }

            return list;
        }
        #endregion
    }
}