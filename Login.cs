using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Banking_Management_System
{
    public partial class Login : Form
    {
        string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=bank;Integrated Security=True;";
        
        public Login()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            txtPassword.MaxLength = 10;
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click_Click(object sender, EventArgs e)
        {
            var role = cmbRole.Text;
            var username = txtUsername.Text;
            var password = txtPassword.Text;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(role) && !string.IsNullOrEmpty(password))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string sqlQuery = "SELECT COUNT(*) FROM Pcwin_logs   WHERE username = @username AND job = @role AND user_password = @password";
                        SqlCommand command = new SqlCommand(sqlQuery, connection);
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@role", role);
                        command.Parameters.AddWithValue("@password", password);

                        int result = (int)command.ExecuteScalar();

                        if (result > 0)
                        {
                            this.Hide();
                            Main_Menu_Window main_Menu_Window = new Main_Menu_Window();
                            main_Menu_Window.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter all the required fields.");
            }
        }
    }
}
