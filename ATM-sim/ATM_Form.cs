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
        private ATM atm;

        public ATM_Form(Server server)
        {
            InitializeComponent();



            atm = new ATM(this, server);
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

        private void button7_Click(object sender, EventArgs e)
        {
            atm.optionClicked(3);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            atm.optionClicked(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            atm.optionClicked(5);
        }

        private void ATM_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
