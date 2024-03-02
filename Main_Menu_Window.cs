using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banking_Management_System
{
    public partial class Main_Menu_Window : Form
    {
        public Main_Menu_Window()
        {
            InitializeComponent();
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
           New_Customer new_customer = new New_Customer();
            new_customer.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WithdrawalsorDebit withdrawalsorDebit = new WithdrawalsorDebit();
            withdrawalsorDebit.Show();
        }
    }
}
