using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonBank
{
    public class BankAccount
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }


        public void AddAmount(decimal amount)
        {
            Balance += amount;
        }

        public void WithdrawAmount(decimal amount)
        {
            Balance -= amount;
        }

        public int AddNumbers(int a, int b)
        {
            return a + b;
        }

        public decimal TransferAmount(int choice, int choice2, decimal sum, decimal newBalance, decimal newBalance2)
        {
            return newBalance;
        }

        
    }
}
