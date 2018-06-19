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

        public object getTranfer(context db, string AccountNo, string AccountNoTranfer, double Money)
        {
            bool status = false;
            string message = string.Empty;

            walle_AccountInfo lai = db.walle_AccountInfos
                .Where(o => o.No == AccountNo)
                .FirstOrDefault()
                ;
            walle_AccountInfo laiTran = null;
            walle_UserInfo user = null;
            walle_UserInfo userTran = null;

            if (lai != null) {
                if (lai.Balance >= Money) {

                    laiTran = db.walle_AccountInfos
                    .Where(o => o.No == AccountNoTranfer)
                    .FirstOrDefault()
                    ;

                    status = Tranfer(lai, laiTran, Money);
                    if (status) {
                        lai.Balance = lai.Balance - Money;
                        laiTran.Balance = laiTran.Balance + Money;
                        db.SaveChanges();
                    }

                    user = db.walle_UserInfos
                        .Where(o => o.ID == lai.walle_UserInfo)
                        .FirstOrDefault()
                        ;

                    userTran = db.walle_UserInfos
                        .Where(o => o.ID == laiTran.walle_UserInfo)
                        .FirstOrDefault()
                        ;

                } else {
                    status = false;
                    message = "Balance < Money*";
                }
            }

            return new
            {
                status = status,
                message = message,
                AccountNo = lai,
                AccountNoTranfer = laiTran,
                UserInfo = user,
                UserInfoTran = userTran,
                money = Money
            };
        }

        public bool Tranfer(walle_AccountInfo AccountNo, walle_AccountInfo AccountNoTranfer, double Money) {
            bool status = false;
            string message = string.Empty;
            double accountMaximum = 5000;

            if (AccountNo.Balance >= Money)
            {
                if ((AccountNoTranfer.Balance + Money) <= accountMaximum)
                {
                    //AccountNo.Balance = AccountNo.Balance - Money;
                    //AccountNoTranfer.Balance = AccountNoTranfer.Balance + Money;

                    status = true;
                    message = "success";
                }
                else {
                    status = false;
                    message = "over accountMaximum";
                }
            }
            else
            {
                status = false;
                message = "source < money";
            }

            return status;
        }
    }
}