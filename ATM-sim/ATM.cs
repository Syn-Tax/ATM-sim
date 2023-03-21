using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_sim
{
    public class ATM
    {
        private ATM_Form form;
        private Account[] accounts;
        private int page = 0;
        private int curr = -1;
        private ATM_Dialog dialog;

        public ATM(ATM_Form form, Account[] accounts)
        {
            this.form = form;
            this.accounts = accounts;
            this.renderPage();
        }

        public void optionClicked(int option)
        {
            if (curr == -1)
            {
                this.selectAccount();
                return;
            }

            if (this.page == 0)
            {
                switch (option)
                {
                    case 0:
                        this.page = 1;
                        this.renderPage();
                        break;
                    case 1:
                        this.page = 2;
                        this.renderPage();
                        break;
                    case 2:
                        this.page = 0;
                        this.curr = -1;
                        this.renderPage();
                        break;
                }
            }
            else if (this.page == 1)
            {
                switch (option)
                {
                    case 0:
                        this.outputCash(10);
                        break;
                    case 1:
                        this.outputCash(50);
                        break;
                    case 2:
                        this.outputCash(500);
                        break;
                }
            }
            else if (this.page == 2)
            {
                switch (option)
                {
                    case 2:
                        this.page = 0;
                        this.renderPage();
                        break;
                }
            }
        }

        private void outputCash(int amount)
        {
            bool res = this.accounts[this.curr].decrementBalance(amount);
            this.page = 2;
            this.renderPage();
        }

        public void renderPage()
        {
            if (this.curr == -1)
            {
                this.form.label4.Text = "No Account Selected";
            } else
            {
                this.form.label4.Text = "Account: " + this.accounts[this.curr].getAccountNum().ToString();
            }

            if (this.page == 0)
            {
                this.form.label1.Text = "Take Out Cash";
                this.form.label2.Text = "View Balance";
                this.form.label3.Text = "Exit";
            } else if (this.page == 1)
            {
                this.form.label1.Text = "10";
                this.form.label2.Text = "50";
                this.form.label3.Text = "500";
            } else if (this.page == 2)
            {
                this.form.label1.Text = "Balance: " + this.accounts[this.curr].getBalance().ToString();
                this.form.label2.Text = "";
                this.form.label3.Text = "Menu";
            }
        }

        public void selectAccount()
        {
            this.dialog = new ATM_Dialog(this);
            this.dialog.ShowDialog();
        }

        private DialogResult invalidCredentials()
        {
            var res = MessageBox.Show("Invalid Account Number or PIN", "Invalid Credentials", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            return res;
        }

        public bool submitAccount(int number, int pin)
        {
            if (number < 0 || number > 999999 || pin < 0 || pin > 9999)
            {
                var res = this.invalidCredentials();
                if (res == DialogResult.OK)
                {
                    this.dialog.reset();
                }
                return false;
            }
            int index = findAccount(number);
            if (index == -1)
            {
                var res = this.invalidCredentials();
                if (res == DialogResult.OK)
                {
                    this.dialog.reset();
                }
                return false;
            }

            if (!this.accounts[index].checkPin(pin))
            {
                var res = this.invalidCredentials();
                if (res == DialogResult.OK)
                {
                    this.dialog.reset();
                }
                return false;
            }
            this.curr = index;
            this.renderPage();
            return true;
        }

        private int findAccount(int number)
        {
            int index = -1;
            for (int i=0; i<this.accounts.Length; i++)
            {
                if (this.accounts[i].getAccountNum() == number) { index = i; }
            }

            return index;
        }
    }
}
