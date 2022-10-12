using NUnit.Framework;
using MoonBank;

namespace MoonBankTest
{
    [TestFixture]
    public class Tests2
    {
        private BankAccount account;

        private User user;

        [SetUp]
        public void Setup()
        {
            account = new BankAccount();
            user = new User();

        }        

        [TestCase(0, 0, 1, 1000, 0, 4000)]
        [TestCase(500, 0, 1, 500, 500, 3500)]
        [TestCase(700, 0, 1, 300, 700, 3300)]
        [TestCase(2500, 1, 0, 500, 2500, 1500)]
        [TestCase(1500, 1, 0, 1500, 1500, 2500)]
        [TestCase(600, 0, 1, 400, 600, 3400)]

        public void Test1(int expected, int fromAccount, int toAccount, decimal transferSum, decimal NewBalanceFromAccount, decimal NewBalanceToAccount)
        {
            decimal actual = account.TransferAmount(fromAccount, toAccount, transferSum, NewBalanceFromAccount, NewBalanceToAccount);

            Assert.AreEqual(expected, actual);
        }


    }

}