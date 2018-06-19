using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wall_e_API
{
    public class AccountService
    {
        public object getBalance(context db,string userID) {
            List<walle_UserInfo> lui = db.walle_UserInfos.AsNoTracking()
                .Where(o=>o.ID==userID)
                .ToList()
                ;
            List<walle_AccountInfo> lai = db.walle_AccountInfos.AsNoTracking()
                .Where(o => o.walle_UserInfo == userID)
                .ToList()
                ;

            return new {
                lwalle_UserInfo = lui,
                lwalle_AccountInfo = lai
            };
        }
    }
}