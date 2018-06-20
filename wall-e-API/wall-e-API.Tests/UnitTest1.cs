using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace wall_e_API.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void tranfer_when_source_2000_des_1000_tran_2000_success()
        {
            //arrange
            walle_AccountInfo sour = new walle_AccountInfo
            {
                No = "123-456-789",
                Balance = 2000,
                walle_UserInfo = "1",
            };
            walle_AccountInfo des = new walle_AccountInfo
            {
                No = "234-567-890",
                Balance = 1000,
                walle_UserInfo = "2",
            };
            double tranferMoney = 2000;
            bool expected = true;
            

            //act
            AccountService api = new AccountService();
            bool actual = api.Tranfer(ref sour, ref des, tranferMoney);

            //assert
            Assert.AreEqual(expected, actual,"status");
            Assert.AreEqual(0, sour.Balance, "sour");
            Assert.AreEqual(3000, des.Balance, "des");
        }
        [TestMethod]
        public void tranfer_when_source_5000_des_2000_tran_3000_success()
        {
            //arrange
            walle_AccountInfo sour = new walle_AccountInfo
            {
                No = "123-456-789",
                Balance = 5000,
                walle_UserInfo = "1",
            };
            walle_AccountInfo des = new walle_AccountInfo
            {
                No = "234-567-890",
                Balance = 2000,
                walle_UserInfo = "2",
            };
            double tranferMoney = 3000;
            bool expected = true;


            //act
            AccountService api = new AccountService();
            bool actual = api.Tranfer(ref sour, ref des, tranferMoney);

            //assert
            Assert.AreEqual(expected, actual, "status");
            Assert.AreEqual(2000, sour.Balance, "sour");
            Assert.AreEqual(5000, des.Balance, "des");
        }
    }
}
