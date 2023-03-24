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
    public partial class ATM_Dialog : Form
    {
        private ATM atm;

        public ATM_Dialog(ATM atm)
        {
            InitializeComponent();
            this.atm = atm;
            this.textBox2.UseSystemPasswordChar = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool res = false;
            try
            {
                res = this.atm.submitAccount(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
            }
            catch (Exception ex)
            {
                res = this.atm.submitAccount(-1, -1);
            }
            if (res)
            {
                this.Close();
            }
        }

        public void reset()
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
        }

        private void ATM_Dialog_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.textBox2.UseSystemPasswordChar = true;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            this.textBox2.UseSystemPasswordChar = false;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            this.textBox2.UseSystemPasswordChar = true;
        }
    }
}

