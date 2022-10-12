using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonBank
{
    public class Bank
    {
        public List<User> Customers = new List<User>();

        private User LoggedInUser = null;

        private BankIO bankIO = new BankIO();


        public Bank()
        {
            //BankAccount account = new BankAccount { Name = "Sparkonto", Balance = 1000m };
            //User user = new User { Name = "Adam", Accounts = new List<BankAccount>() };
            //user.Accounts.Add(account);
            //Customers.Add(user);

            //BankAccount account1 = new BankAccount { Name = "Sparkonto", Balance = 2000m };
            //User user1 = new User { Name = "Bertil", Accounts = new List<BankAccount>() };
            //user1.Accounts.Add(account1);
            //Customers.Add(user1);

            //BankAccount account2 = new BankAccount { Name = "Sparkonto", Balance = 3000m };
            //User user2 = new User { Name = "Ceasar", Accounts = new List<BankAccount>() };
            //user2.Accounts.Add(account2);
            //Customers.Add(user2);
        }

        public void Run()
        {
            if (Login())
                Menu();
            
        }

        private bool Login()
        {
            Console.WriteLine("Välkommen till Månbanken\n");

            for(int i = 0; i < Customers.Count; i++)
            {
                Console.WriteLine("Kund " + Customers[i].UserId + ": " + Customers[i].Name);
            }

            Console.Write("Välj vem du ska logga in som med siffra: ");
            Console.WriteLine("Eller skriv 101 för att skapa en ny kund");
            Console.WriteLine("Eller skriv 111 för att skapa flera nya kunder");
            
            int choice = int.Parse(Console.ReadLine());
            if (choice == 101)
            {
                Console.Write("Var är den nya Kundens namn: ");
                string name = Console.ReadLine();
                Console.Write("Hur mycket vill användaren sätta in: ");
                decimal summa = int.Parse(Console.ReadLine());
                AddNewUser(name,summa);
                Console.Clear();
                return Login();
            }

            if (choice == 111)
            {
                Console.Write("How many new users do you want to add?: ");
                int howMany = int.Parse(Console.ReadLine());
                Console.Write("Namn: ");
                String Names = Console.ReadLine();
                AddAlotOfUsers(howMany, Names);
                Console.Clear();
                return Login();
            }

            if (choice >= 0 && choice < Customers.Count)
            {
                LoggedInUser = Customers[choice];
            }

            if(LoggedInUser == null)
            {
                Console.WriteLine("Fel användare.");
                return false;
            }

            for(int i = 0; i < LoggedInUser.Accounts.Count; i++)
            {
                Console.WriteLine("Konto " + LoggedInUser.Accounts[i].Name + " - " + LoggedInUser.Accounts[i].Balance + "kr");
            }
            return true;
        }

        private void Menu()
        {
            Console.Clear();
            int choice;
            while(true)
            {
                Console.WriteLine(LoggedInUser.Name + " är nu inloggad");

                Console.WriteLine("1. Se konton");
                Console.WriteLine("2. Sätta in pengar.");
                Console.WriteLine("3. Ta ut pengar.");
                Console.WriteLine("4. Överföra pengar.");
                Console.WriteLine("5. Logga ut");
                Console.WriteLine("6. Öppna upp nytt sparkonto");

                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                    ShowAccounts();

                else if (choice == 2)
                    AddAmount();

                else if (choice == 3)
                    WithdrawAmount();

                else if (choice == 4)
                    TransferAmount();

                else if (choice == 5)
                    return;

                else if (choice == 6)
                    CreateNewBankAccount(LoggedInUser);
                 

            }
        }

        private void ShowAccounts()
        {
            for(int i = 0; i < LoggedInUser.Accounts.Count; i++)
            {
                Console.WriteLine("\t" + LoggedInUser.Accounts[i].Name + " - " + LoggedInUser.Accounts[i].Balance + "kr");
            }
            Console.ReadKey(true);
        }

        private void AddAmount()
        {
            int choice, sum;
            for (int i = 0; i < LoggedInUser.Accounts.Count; i++)
            {
                Console.WriteLine(i + " - " + LoggedInUser.Accounts[i].Name);
            }

            Console.WriteLine("Välj konto att sätta in pengar på");
            choice = int.Parse(Console.ReadLine());

            Console.WriteLine("Hur mycket pengar ska sättas in?");
            sum = int.Parse(Console.ReadLine());

            LoggedInUser.Accounts[choice].AddAmount(sum);
        }

        private void WithdrawAmount()
        {
            int choice, sum;
            for (int i = 0; i < LoggedInUser.Accounts.Count; i++)
            {
                Console.WriteLine(i + " - " + LoggedInUser.Accounts[i].Name);
            }

            Console.WriteLine("Välj konto att ta ut pengar på");
            choice = int.Parse(Console.ReadLine());

            Console.WriteLine("Hur mycket pengar vill du ta ut?");
            sum = int.Parse(Console.ReadLine());

            LoggedInUser.Accounts[choice].WithdrawAmount(sum);
        }
        public static void CreateNewBankAccount(User user)
        {
            BankAccount bankAccount = new BankAccount();

            bankAccount.Name = "Sparkonto";
            bankAccount.Balance = 0m;

            user.Accounts.Add(bankAccount);
        }
        public void AddNewUser(string x, decimal y)
        {
            User newUser = new() { Name = x, Accounts = new List<BankAccount>()};
            BankAccount newBankAccount = new() { Name = "SparkKonto", Balance = y };
            newUser.Accounts.Add(newBankAccount);
            Customers.Add(newUser);
       }
       
        private void TransferAmount()
        {
            int choice = 0, choice2 = 0;
            decimal newBalanceFromAccount, newBalanceToAccount, sum = 0;


            for (int i = 0; i < LoggedInUser.Accounts.Count; i++)
            {
                Console.WriteLine("\t" + i + " " + LoggedInUser.Accounts[i].Name + " - " + LoggedInUser.Accounts[i].Balance + "kr");
            }

            bool keepLooping = true;
            while (keepLooping)
            {
                try
                {
                    Console.WriteLine("Välj konto att överföra pengar ifrån");
                    choice = int.Parse(Console.ReadLine());

                    if (choice < LoggedInUser.Accounts.Count)
                    {
                        Console.WriteLine("Du valde frånkontot: " + LoggedInUser.Accounts[choice].Name + " - " + LoggedInUser.Accounts[choice].Balance + "kr");
                        keepLooping = false;
                    }
                    else
                    {
                        Console.WriteLine("Kontot finns inte. Försök igen.\n");
                    }

                }
                catch
                {
                    Console.WriteLine("Endast siffror är tillåtna. Försök igen.\n");
                }
            }

            bool keepLooping2 = true;
            while (keepLooping2)
            {
                try
                {
                    Console.WriteLine("Välj konto att överföra pengar till");
                    choice2 = int.Parse(Console.ReadLine());

                    if (choice2 < LoggedInUser.Accounts.Count)
                    {
                        Console.WriteLine("Du valde tillkontot: " + LoggedInUser.Accounts[choice2].Name + " - " + LoggedInUser.Accounts[choice2].Balance + "kr");
                        keepLooping2 = false;
                    }
                    else
                    {
                        Console.WriteLine("Kontot finns inte. Försök igen.\n");
                    }
                }
                catch
                {
                    Console.WriteLine("Endast siffror är tillåtna. Försök igen.\n");
                }

            }

            bool keepLooping3 = true;
            while (keepLooping3)
            {
                try
                {
                    Console.WriteLine("Hur mycket pengar vill du överföra?");
                    sum = decimal.Parse(Console.ReadLine());

                    if (sum <= LoggedInUser.Accounts[choice].Balance)
                    {
                        Console.WriteLine("Du har valt att överföra " + sum + " " + "kr");
                        keepLooping3 = false;
                    }
                    else
                    {
                        Console.WriteLine("Du har angett värde som är högre än saldot.\n");
                    }


                }
                catch
                {
                    Console.WriteLine("Endast siffror är tillåtna. Försök igen.\n");
                }


            }

            newBalanceFromAccount = LoggedInUser.Accounts[choice].Balance - sum;
            newBalanceToAccount = LoggedInUser.Accounts[choice2].Balance + sum;

            Console.WriteLine();

            Console.WriteLine("Saldot på " + LoggedInUser.Accounts[choice].Name + " " + newBalanceFromAccount);
            Console.WriteLine("Saldot på " + LoggedInUser.Accounts[choice2].Name + " " + newBalanceToAccount);

            Console.WriteLine();

            LoggedInUser.Accounts[choice].Balance = newBalanceFromAccount;
            LoggedInUser.Accounts[choice2].Balance = newBalanceToAccount;

        }

        public void AddAlotOfUsers(int x, string y)
        {
            for (int i = 0; i < x; i++)
            {
                User newUser = new() { Name = y, Accounts = new List<BankAccount>() };
                BankAccount newBankAccount = new() { Name = "SparkKonto" };
                newUser.Accounts.Add(newBankAccount);
                Customers.Add(newUser);
            }
        }
    }
}
