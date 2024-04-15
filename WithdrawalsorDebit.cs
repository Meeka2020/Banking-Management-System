using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Banking_Management_System
{
    public partial class WithdrawalsorDebit : Form
    {
        private readonly string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=bank;Integrated Security=True;";



        public WithdrawalsorDebit()
        {
            InitializeComponent();
        }

        private void check_Bal_butn_Click(object sender, EventArgs e)
        {
            string accountNumber = ChecktxtBx.Text;

            if (!string.IsNullOrWhiteSpace(accountNumber))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string selectQuery = "SELECT Balance FROM Accounts WHERE Account_Number = @AccountNumber";

                        using (SqlCommand command = new SqlCommand(selectQuery, connection))
                        {
                            command.Parameters.AddWithValue("@AccountNumber", accountNumber);

                            object result = command.ExecuteScalar();

                            if (result != null && result != DBNull.Value)
                            {
                                decimal balance = Convert.ToDecimal(result);
                                ResttxtBx.Text = balance.ToString("C2"); // Format the balance as currency
                            }
                            else
                            {
                                ResttxtBx.Text = "Account not found!";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter an account number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Withdraw_button_Click(object sender, EventArgs e)
        {
            string accountNumber = Account_Withdraw_textBox.Text;
            string withdrawAmountText = Amount_Withdraw_textBox.Text;

            if (string.IsNullOrWhiteSpace(accountNumber) || string.IsNullOrWhiteSpace(withdrawAmountText))
            {
                MessageBox.Show("Please enter both account number and withdrawal amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(withdrawAmountText, out decimal withdrawAmount))
            {
                MessageBox.Show("Please enter a valid withdrawal amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Check if the account exists and has sufficient balance
                    string selectQuery = "SELECT Balance FROM Accounts WHERE Account_Number = @AccountNumber";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@AccountNumber", accountNumber);

                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            decimal balance = Convert.ToDecimal(result);
                            if (balance < withdrawAmount)
                            {
                                MessageBox.Show("Insufficient balance!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Account not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Check if withdrawal amount exceeds the balance
                    if (withdrawAmount > 0)
                    {
                        // Update the account balance after withdrawal
                        string updateQuery = "UPDATE Accounts SET Balance = CASE WHEN Balance - @WithdrawAmount < 0 THEN 0 ELSE Balance - @WithdrawAmount END WHERE Account_Number = @AccountNumber";
                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@WithdrawAmount", withdrawAmount);
                            command.Parameters.AddWithValue("@AccountNumber", accountNumber);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Withdrawal successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Update the balance display
                                check_Bal_butn_Click(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("Failed to withdraw money.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Withdrawal amount must be greater than zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    
}
