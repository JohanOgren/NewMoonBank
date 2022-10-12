using NUnit.Framework;
using MoonBank;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoonBankTest
{
    [TestFixture]
    public class TransferLogTest
    {
              
        [TestCase(1, 3000, "Sparkonto 1", "Sparkonto 2")]
        
        public void Test1(int expected, decimal sum, string fromAccount, string toAccount)
        {
            List<string> testList = new List<string>();

            string logTest = "Överföring av " + sum + "kr från " + fromAccount + " till " + toAccount + " genomfördes " + DateTime.Now;
            
            testList.Add(logTest);

            int actual = testList.Count();

            Assert.AreEqual(expected, actual);
        }
    }
}