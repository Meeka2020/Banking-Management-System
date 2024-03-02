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
    public partial class WithdrawalsorDebit : Form
    {
        private readonly bankEntities1 dbContext = new bankEntities1();
        private int currentCustomerId;


        public WithdrawalsorDebit()
        {
            InitializeComponent();
        }

        private void check_Bal_butn_Click(object sender, EventArgs e)
        {
            var account = dbContext.cust_newaccounts.FirstOrDefault(a => a.Cust_id == currentCustomerId);

            if (account != null)
            {
                ChecktxtBx.Text = account.Balance.ToString("C");
            }
            else
            {
                MessageBox.Show("Account not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reset_Bal_butn_Click(object sender, EventArgs e)
        {
            ResttxtBx.Text = string.Empty;
        }
    }
}
