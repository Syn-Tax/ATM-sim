using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_sim
{
    public class Server
    {
        public Account[] accounts = new Account[3];
        public Server()
        {
            accounts[0] = new Account(300, 1111, 111111);
            accounts[1] = new Account(750, 2222, 222222);
            accounts[2] = new Account(3000, 3333, 333333);
        }

        public int getBalance(int number)
        {
            int amount = -1;
            foreach (Account account in accounts)
            {
                if (account.getAccountNum() == number)
                {
                    amount = account.getBalance();
                    break;
                }
            }
            return amount;
        }

        public void setBalance(int number, int amount)
        {

            foreach (Account account in accounts)
            {
                if (account.getAccountNum() == number)
                {
                    account.setBalance(amount);
                    break;
                }
            }
        }

        public bool checkPin(int number, int pin)
        {
            bool correct = false;
            foreach (Account account in accounts)
            {
                if (account.getAccountNum() == number)
                {
                    correct = account.checkPin(pin);
                    break;
                }

            }
            return correct;
        }
    }
}
