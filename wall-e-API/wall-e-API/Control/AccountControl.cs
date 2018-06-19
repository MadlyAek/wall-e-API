using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Nancy;
using System.Threading.Tasks;

namespace wall_e_API.Control
{
    public class AccountControl : NancyModule
    {
        public AccountControl():base("/Account")
        {
            Get["/", runAsync: true] = async (param, token) =>
            {
                await Task.Delay(0);
                return this.Response.AsJson(new
                {
                    status = true,
                    message = "Account",
                });
            };

            Get["/getBalance/{id}", runAsync: true] = async (param, token) =>
            {
                await Task.Delay(0);

                //init
                bool status = false;
                string message = string.Empty;
                object obj = null;

                //process
                string userID = param.id;
                if (string.IsNullOrEmpty(userID))
                {
                    status = false;
                    message = "id*";
                }
                else
                {
                    status = true;
                    context db = new context();
                    AccountService accser= new AccountService();
                    obj = accser.getBalance(db, userID);
                }

                return this.Response.AsJson(new
                {
                    status = status,
                    message = message,
                    content = obj,
                });
            };
            Get["/getTranfer/{accountNo}/{accountNoTranfer}/{money}", runAsync: true] = async (param, token) =>
            {
                await Task.Delay(0);
                //init
                bool status = false;
                string message = string.Empty;
                object obj = null;

                string AccountNo = param.accountNo;
                string AccountNoTranfer = param.accountNoTranfer;
                string MoneyTmp = param.money;
                double Money = -1;

                //process
                if (string.IsNullOrEmpty(AccountNo) || string.IsNullOrEmpty(AccountNoTranfer) || string.IsNullOrEmpty(MoneyTmp))
                {
                    status = false;
                    message = "accountNo || accountNoTranfer || money*";
                }
                else
                {
                    status = true;
                    context db = new context();

                    Money = Convert.ToDouble(MoneyTmp);
                    AccountService accser = new AccountService();
                    obj = accser.getTranfer(db, AccountNo, AccountNoTranfer, Money);
                }

                return this.Response.AsJson(new
                {
                    status = status,
                    message = message,
                    content = obj,
                });
            };
        }
    }
}