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
    public partial class Form_Parent : Form
    {
        public Form_Parent()
        {
            InitializeComponent();
        }

      
        private void loginSignUpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var login = new Login();
            login.MdiParent = this;
            login.Show();
        }

        private void addNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var new_customer = new New_Customer();
            new_customer.MdiParent = this;
            new_customer.Show();
        }

        private void registerNewAgentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var register_new_agents = new Register_New_Agents();
            register_new_agents.MdiParent = this;
            register_new_agents.Show();
        } 

        private void mainMenuWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Main_Menu_Window = new Main_Menu_Window();
            Main_Menu_Window.MdiParent = this;
            Main_Menu_Window.Show();
        }

        private void withdrawalsDebitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var WithdrawalsorDebit = new WithdrawalsorDebit();
            WithdrawalsorDebit.MdiParent = this;
            WithdrawalsorDebit.Show();
        }
    }
    }
