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
        private Server server;
        private int page = 0;
        private int curr = -1;
        private ATM_Dialog dialog;

        public ATM(ATM_Form form, Server server)
        {
            this.form = form;
            this.server = server;
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
                        this.outputCash(20);
                        break;
                    case 2:
                        this.outputCash(50);
                        break;
                    case 3:
                        this.outputCash(100);
                        break;
                    case 4:
                        this.outputCash(200);
                        break;
                    case 5:
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
            if (this.server.getBalance(this.curr) > amount) {
                this.server.setBalance(this.curr, this.server.getBalance(this.curr) - amount);
                MessageBox.Show(amount.ToString() + " was withdrawn", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Insufficient Funds", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.page = 0;
            this.renderPage();
        }

        public void renderPage()
        {
            if (this.curr == -1)
            {
                this.form.label4.Text = "No Account Selected";
            } else
            {
                this.form.label4.Text = "Account: " + this.curr.ToString();
            }

            if (this.page == 0)
            {
                this.form.label1.Text = "Take Out Cash";
                this.form.label2.Text = "View Balance";
                this.form.label3.Text = "Exit";
                this.form.label5.Text = "";
                this.form.label6.Text = "";
                this.form.label7.Text = "";
            } else if (this.page == 1)
            {
                this.form.label1.Text = "10";
                this.form.label2.Text = "20";
                this.form.label3.Text = "50";
                this.form.label5.Text = "100";
                this.form.label6.Text = "200";
                this.form.label7.Text = "500";
            } else if (this.page == 2)
            {
                this.form.label1.Text = "Balance: " + this.server.getBalance(this.curr).ToString();
                this.form.label2.Text = "";
                this.form.label3.Text = "Menu";
                this.form.label5.Text = "";
                this.form.label6.Text = "";
                this.form.label7.Text = "";
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
                    //this.dialog.reset(); throws exception
                    return true;
                }
                return false;
            }

            if (!this.server.checkPin(number, pin))
            {
                var res = this.invalidCredentials();
                if (res == DialogResult.OK)
                {
                    this.dialog.reset(); 
                }
                return false;
            }

            // Login successful, open ATM_Form
            ATM_Form atmForm = new ATM_Form(this.server);
            atmForm.ShowDialog();
            this.curr = number;
            this.renderPage();
            return true;
        }


    }
}
