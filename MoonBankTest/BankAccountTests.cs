using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MoonBank;

namespace MoonBankTest
{
    [TestFixture]
    class BankAccountTests
    {
        [Test]
        public void ShouldAddNewBankAccount()
        {
            User user = new User();

            int expected = user.Accounts.Count + 1;
            Bank.CreateNewBankAccount(user);

            int actual = user.Accounts.Count;
            Assert.AreEqual(expected, actual);
        }
    }
}
