using BootCampus.CMM.Notice.DSL;
using BootCampus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampus.CMM.Notice.BSL
{
    public class UserBsl
    {
        #region 로그인
        public UserModel Login(UserModel userModel)
        {
            UserDsl userDsl = new UserDsl();
            UserModel um = userDsl.Login(userModel);


            return userModel;

        }
        #endregion
    }
}
