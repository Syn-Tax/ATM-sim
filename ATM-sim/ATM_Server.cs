using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_sim
{
    public partial class ATM_Server : Form
    {
        private Server server;
        public ATM_Server()
        {
            InitializeComponent();
            this.server = new Server();
        }

        public void updateLabels()
        {
            this.label1.Text = this.server.accounts[0].getAccountNum().ToString() + ": " + this.server.accounts[0].getBalance().ToString();
            this.label2.Text = this.server.accounts[1].getAccountNum().ToString() + ": " + this.server.accounts[1].getBalance().ToString();
            this.label3.Text = this.server.accounts[2].getAccountNum().ToString() + ": " + this.server.accounts[2].getBalance().ToString();
        }
    }
}
