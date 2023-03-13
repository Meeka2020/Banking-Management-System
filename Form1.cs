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

        private void Form_Parent_Load(object sender, EventArgs e)
        {
            using (Loadingform loading = new Loadingform())
            {
                loading.Show();

            }
        }
    }
}
