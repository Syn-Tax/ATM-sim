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
    public partial class ATM_Form : Form
    {
        private Account[] ac = new Account[3];
        private ATM atm;

        public ATM_Form()
        {
            InitializeComponent();


            ac[0] = new Account(300, 1111, 111111);
            ac[1] = new Account(750, 2222, 222222);
            ac[2] = new Account(3000, 3333, 333333);

            atm = new ATM(this, ac);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            atm.optionClicked(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            atm.optionClicked(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            atm.optionClicked(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            atm.selectAccount();
        }
    }
}
