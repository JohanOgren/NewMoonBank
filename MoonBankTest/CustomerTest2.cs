using MoonBank;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonBankTest
{

    [TestFixture]
    public class CustomerTest2
    {
        [TestCase(4)]

        public void TestAddAlotOfUsers(int expected)
        {
                Bank bank = new Bank();
                string name = "Testsson";
                int users = 4;
                bank.AddAlotOfUsers(users, name);
                int actual = bank.Customers.Count;
                Assert.AreEqual(expected, actual);
        }
    }
}
