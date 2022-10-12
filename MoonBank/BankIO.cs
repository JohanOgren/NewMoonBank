using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonBank
{
    static public class Filehandling
    {
        static public string LoadFile(string filepath)
        {
            StreamReader sr = new StreamReader(filepath);
            string data = sr.ReadToEnd();

            sr.Close();

            return data;
        }

        static public void SaveFile(string filepath, List<User> users)
        {
            StreamWriter sw = new StreamWriter(filepath);

            foreach(User user in users)
            {
                sw.Write(user.UserId + ";");
                sw.Write(user.Name + ";");

                foreach(BankAccount account in user.Accounts)
                {
                    sw.Write(account.Name + ";");
                    sw.WriteLine(account.Balance + ";");
                }
            }

            sw.Close();
        }

    }

    public class BankIO
    {
        public List<User> LoadData(string filepath)
        {
            string data = Filehandling.LoadFile(filepath);

            if(data == null)
            {
                throw null;
            }

            List<User> users = new List<User>();

            string[] splitdata = data.Split('\n');

            for(int i = 0; i < splitdata.Length - 1; i++)
            {
                User user = new User();
                string[] splituser = splitdata[i].Split(';');

                user.UserId = int.Parse(splituser[0]);
                user.Name = splituser[1];

                for (int j = 2; j < splituser.Length - 1; j++)
                {
                    if(j % 2 == 0)
                    {
                        BankAccount account = new BankAccount();
                        account.Name = splituser[j];
                        account.Balance = decimal.Parse(splituser[j + 1]);
                        user.Accounts.Add(account);
                    }
                }

                users.Add(user);
            }

            
            return users;
        }

        public void SaveData(string filepath, List<User> users)
        {
            Filehandling.SaveFile(filepath, users);
        }


    }
}
