using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonBank
{
    

    public class User
    {
        public int UserId;

        public string Name;

        public List<BankAccount> Accounts = new List<BankAccount>();

        public List<string> Transfers = new List<string>();


    }
}
