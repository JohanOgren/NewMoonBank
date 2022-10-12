using NUnit.Framework;
using MoonBank;

namespace MoonBankTest
{
    [TestFixture]
    public class Tests
    {
        private BankAccount account;

        [SetUp]
        public void Setup()
        {
            account = new BankAccount();
        }

        [TestCase(9, 5, 4)]
        [TestCase(6, 2, 4)]
        [TestCase(12, 8, 4)]
        [TestCase(5, 2, 3)]
        [TestCase(4, 1, 3)]
        [TestCase(9, 9, 0)]
        public void Test1(int expected, int a, int b)
        {
            int actual = account.AddNumbers(a, b);

            Assert.AreEqual(expected, actual);
        }
    }
}