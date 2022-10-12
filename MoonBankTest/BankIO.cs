using MoonBank;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonBankTest
{
    [TestFixture]
    class TestingBankIO
    {
        private BankIO bankIO;
        private List<User> Customers;

        private string filepath = "TestingBankIO";

        [SetUp]
        public void Setup()
        {
            bankIO = new BankIO();
            Customers = new List<User>();

            BankAccount account = new BankAccount { Name = "Sparkonto", Balance = 1000m };
            User user = new User { UserId = 0, Name = "Adam", Accounts = new List<BankAccount>() };
            user.Accounts.Add(account);
            Customers.Add(user);

            BankAccount account1 = new BankAccount { Name = "Sparkonto1", Balance = 2000m };
            User user1 = new User { UserId = 1, Name = "Bertil", Accounts = new List<BankAccount>() };
            user1.Accounts.Add(account1);
            Customers.Add(user1);

            BankAccount account2 = new BankAccount { Name = "Sparkonto2", Balance = 3000m };
            User user2 = new User { UserId = 2, Name = "Ceasar", Accounts = new List<BankAccount>() };
            user2.Accounts.Add(account2);
            Customers.Add(user2);

            BankAccount account3 = new BankAccount { Name = "Sparkonto3", Balance = 3000m };
            User user3 = new User { UserId = 3, Name = "David", Accounts = new List<BankAccount>() };
            user3.Accounts.Add(account3);
            Customers.Add(user3);

            BankAccount account4 = new BankAccount { Name = "Sparkonto4", Balance = 3000m };
            User user4 = new User { UserId = 4, Name = "Erik", Accounts = new List<BankAccount>() };
            user4.Accounts.Add(account4);
            Customers.Add(user4);
        }

        [TestCase(1, 5, 0, "Adam", 1, 0, "Sparkonto", 1000)]
        [TestCase(2, 5, 3, "David", 2, 1, "SparkontoElite", 123111)]
        [TestCase(3, 5, 4, "Erik", 1, 0, "DärVarDetTomt", 0)]
        public void LoadingUsers(int testcase, int expectedUsersAmount, int testingUserNum, string testingUserName, int testingUserAccountAmount, int testingUserAccountNum, string testingUserAccountName, int testingUserAccountBalance)
        {
            StreamWriter sw = new StreamWriter("loadingTest" + filepath + testcase + ".txt");
            sw.Write("0;Adam;Sparkonto;1000;\n" +
                        "1;Bertil;Sparkonto;2000;\n" +
                        "2;Ceasar;Sparkonto;3000;\n" +
                        "3;David;SparkontoDeluxe;150000;SparkontoElite;123111;\n" +
                        "4;Erik;DärVarDetTomt;0;\n");

            sw.Close();

            List<User> users = bankIO.LoadData("loadingTest" + filepath + testcase + ".txt");

            Assert.AreEqual(expectedUsersAmount, users.Count);
            Assert.AreEqual(users[testingUserNum].Name, testingUserName);
            Assert.AreEqual(testingUserAccountAmount, users[testingUserNum].Accounts.Count);
            Assert.AreEqual(users[testingUserNum].Accounts[testingUserAccountNum].Name, testingUserAccountName);
            Assert.AreEqual(users[testingUserNum].Accounts[testingUserAccountNum].Balance, testingUserAccountBalance);
        }

        [Test]
        public void SavingUsers()
        {
            bankIO.SaveData("savingTest" + filepath + ".txt", Customers);

            StreamReader sw = new StreamReader("savingTest" + filepath + ".txt");
            string data = sw.ReadToEnd();

            Assert.AreEqual("0;Adam;Sparkonto;1000;\r\n"    +
                            "1;Bertil;Sparkonto1;2000;\r\n" +
                            "2;Ceasar;Sparkonto2;3000;\r\n" +
                            "3;David;Sparkonto3;3000;\r\n"  +
                            "4;Erik;Sparkonto4;3000;\r\n",  data);
        }




    }
}
