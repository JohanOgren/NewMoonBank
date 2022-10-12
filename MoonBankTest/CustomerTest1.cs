using Microsoft.VisualStudio.TestPlatform.TestHost;
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
    public class CustomerTest1
    {
        [TestCase(1)]

        public void TestAddNewCustomer(int expected)
        {
            Bank bank = new Bank();
            string name = "Testsson";
            decimal pengar = 1000m;

            bank.AddNewUser(name,pengar);

            int actual = bank.Customers.Count;
            Assert.AreEqual(expected, actual);
        }
    }
}
