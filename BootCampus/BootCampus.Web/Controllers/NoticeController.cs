using BootCampus.CMM.Notice.BSL;
using BootCampus.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BootCampus.Web.Controllers
{
    public class NoticeController : Controller
    {
        #region Notice List 조회
        /// <summary>
        /// 공지사항 조회
        /// </summary>
        /// <returns></returns>
        public ActionResult NoticeList()
        {
            NoticeBsl noticeBsl = new NoticeBsl();
            List<NoticeModel> list = noticeBsl.SelectNoticeList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}