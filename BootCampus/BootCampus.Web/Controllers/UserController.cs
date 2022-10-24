using BootCampus.CMM.Notice.BSL;
using BootCampus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootCampus.Web.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// 로그인
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public int Login(UserModel userModel)
        {
            UserBsl userBsl = new UserBsl();
            int result = userBsl.Login(userModel);

            return result;
        }
    }
}