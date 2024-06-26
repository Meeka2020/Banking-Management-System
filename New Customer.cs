﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Banking_Management_System
{
    public partial class New_Customer : Form
    {
        private readonly string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=bank;Integrated Security=True;";
        private DataGridView dataGridView4NC;

        public New_Customer()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadCustomerData();

        }

        private void InitializeDataGridView()
        {
            dataGridView4NC = new DataGridView();  // Using dataGridViewNewCust
            dataGridView4NC.CellClick += DataGridView4NC_CellContentClick;
        }

        private void LoadCustomerData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string selectQuery = "SELECT Cust_id, Cust_Firstname, Cust_Lastname, Date_of_Birth, Gender, TRN_num, " +
                                         "Cust_Phone, Cust_Address, Occupation, Deposit_amt, Date_of_Birth " +
                                         "FROM Customer";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Assuming dataGridViewNewCust is the name of your DataGridView
                    dataGridView4NC.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DataGridView4NC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView4NC.Rows[e.RowIndex].Selected = true;
            }
        }
        //private void Submit_Btn_Cust_Click(object sender, EventArgs e)
        //{
        //    // Retrieve data from form controls
        //    string firstName = textFnameNC.Text;
        //    string lastName = textLNameNC.Text;
        //    string dateOfBirth = datebirthTimePicker1NC.Value.ToString("yyyy-MM-dd");
        //    string gender = comboBox1SEXNC.SelectedItem.ToString();
        //    string trnNum = textTRNNumNC.Text;
        //    string phoneNumber = PhoneNumNC.Text;
        //    string address = textaddAccnewNC.Text;
        //    string occupation = textOccAccnewNC.Text;
        //    string depositAmount = Txt_DepositIncomeNC.Text;
        //    string dateOfDeposit = dateTimePickerCustFirstdbt.Value.ToString("yyyy-MM-dd");

        //    // Check if any required field is empty
        //    if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(dateOfBirth) ||
        //        string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(trnNum) || string.IsNullOrWhiteSpace(phoneNumber) ||
        //        string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(occupation))
        //    {
        //        MessageBox.Show("Please enter all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();

        //            // Define your SQL query for inserting a new customer
        //            string insertQuery = "INSERT INTO Customer (cust_firstname, cust_lastname, date_of_birth, gender, trn_num, " +
        //                                 "cust_phone, cust_address, occupation, deposit_amount, date_of_deposit) " +
        //                                 "VALUES (@FirstName, @LastName, @DateOfBirth, @Gender, @TrnNum, @PhoneNumber, " +
        //                                 "@Address, @Occupation, @DepositAmount, @DateOfDeposit)";

        //            using (SqlCommand command = new SqlCommand(insertQuery, connection))
        //            {
        //                // Add parameters for other fields
        //                command.Parameters.AddWithValue("@FirstName", firstName);
        //                command.Parameters.AddWithValue("@LastName", lastName);
        //                command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
        //                command.Parameters.AddWithValue("@Gender", gender);
        //                command.Parameters.AddWithValue("@TrnNum", trnNum);
        //                command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
        //                command.Parameters.AddWithValue("@Address", address);
        //                command.Parameters.AddWithValue("@Occupation", occupation);
        //                command.Parameters.AddWithValue("@DepositAmount", depositAmount);
        //                command.Parameters.AddWithValue("@DateOfDeposit", dateOfDeposit);

        //                // Execute the query
        //                int rowsAffected = command.ExecuteNonQuery();

        //                if (rowsAffected > 0)
        //                {
        //                    MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Failed to add customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                }
        //            }

        //            // generate account number

        //            // create account record attached to newly created customer


        //            // create new deposit transaction record for account using the initial deposit amount
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}
        private void Submit_Btn_Cust_Click(object sender, EventArgs e)
        {
            // Retrieve data from form controls
            string firstName = textFnameNC.Text;
            string lastName = textLNameNC.Text;
            string dateOfBirth = datebirthTimePicker1NC.Value.ToString("yyyy-MM-dd");
            string gender = comboBox1SEXNC.SelectedItem.ToString();
            string trnNum = textTRNNumNC.Text;
            string phoneNumber = PhoneNumNC.Text;
            string address = textaddAccnewNC.Text;
            string occupation = textOccAccnewNC.Text;
            string depositAmount = Txt_DepositIncomeNC.Text;
            string dateOfDeposit = dateTimePickerCustFirstdbt.Value.ToString("yyyy-MM-dd");

            // Check if any required field is empty
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(dateOfBirth) ||
                string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(trnNum) || string.IsNullOrWhiteSpace(phoneNumber) ||
                string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(occupation))
            {
                MessageBox.Show("Please enter all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Define your SQL query for inserting a new customer
                    string insertQuery = "INSERT INTO Customer (cust_firstname, cust_lastname, date_of_birth, gender, trn_num, " +
                                         "cust_phone, cust_address, occupation, Deposit_amt, date_of_deposit) " +
                                         "VALUES (@FirstName, @LastName, @DateOfBirth, @Gender, @TrnNum, @PhoneNumber, " +
                                         "@Address, @Occupation, @DepositAmount, @DateOfDeposit)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters for other fields
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@TrnNum", trnNum);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@Occupation", occupation);
                        command.Parameters.AddWithValue("@DepositAmount", depositAmount);
                        command.Parameters.AddWithValue("@DateOfDeposit", dateOfDeposit);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to add customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                        // Step 1: Generate a unique account number
                        string accountNumber = GenerateAccountNumber();

                        // Step 2: Insert a new account record associated with the newly created customer
                        string insertAccountQuery = "INSERT INTO Accounts (cust_id, Account_Number, Balance) " +
                                                    "VALUES (@CustomerId, @AccountNumber, @Balance)";

                        using (SqlCommand accountCommand = new SqlCommand(insertAccountQuery, connection))
                        {
                            accountCommand.Parameters.AddWithValue("@CustomerId", GetLastInsertedCustomerId(connection));
                            accountCommand.Parameters.AddWithValue("@AccountNumber", accountNumber);
                            accountCommand.Parameters.AddWithValue("@Balance", depositAmount);

                            int accountRowsAffected = accountCommand.ExecuteNonQuery();

                            if (accountRowsAffected > 0)
                            {
                                // Step 3: Create a new deposit transaction record for the account
                                string insertTransactionQuery = "INSERT INTO BankTransaction (acc_num, Transaction_Type, Amount, Transaction_Date) " +
                                                                "VALUES (@AccountNumber, 'Deposit', @DepositAmount, @TransactionDate)";

                                using (SqlCommand transactionCommand = new SqlCommand(insertTransactionQuery, connection))
                                {
                                    transactionCommand.Parameters.AddWithValue("@AccountNumber", accountNumber);
                                    transactionCommand.Parameters.AddWithValue("@DepositAmount", depositAmount);
                                    transactionCommand.Parameters.AddWithValue("@TransactionDate", DateTime.Now);

                                    int transactionRowsAffected = transactionCommand.ExecuteNonQuery();

                                    if (transactionRowsAffected > 0)
                                    {
                                        MessageBox.Show("Customer added successfully with account and deposit!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to add deposit transaction.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Failed to add account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    // Success message here

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Helper method to generate a unique account number
        private string GenerateAccountNumber()
        {
            // Implement your logic to generate a unique account number
            // For simplicity, you can use a combination of DateTime and a random number, but in a real-world scenario, consider using a more robust approach.
            return DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(1000, 9999);
        }

        // Helper method to get the last inserted customer's ID
        private int GetLastInsertedCustomerId(SqlConnection connection)
        {
            string selectQuery = "SELECT IDENT_CURRENT('Customer') AS LastCustomerId";

            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {
                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }

                return -1; // Handle the case when there is no customer ID available
            }
        }

        private void Edit_Cust_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridView4NC.SelectedRows.Count > 0)
            {
                // Get the selected customer's ID
                int selectedCustomerId = Convert.ToInt32(dataGridView4NC.SelectedRows[0].Cells["cust_id"].Value);

                // Retrieve data from form controls
                string firstName = textFnameNC.Text;
                string lastName = textLNameNC.Text;
                string dateOfBirth = datebirthTimePicker1NC.Value.ToString("yyyy-MM-dd");
                string gender = comboBox1SEXNC.SelectedItem.ToString();
                string trnNum = textTRNNumNC.Text;
                string phoneNumber = PhoneNumNC.Text;
                string address = textaddAccnewNC.Text;
                string occupation = textOccAccnewNC.Text;
                string depositAmount = Txt_DepositIncomeNC.Text;
                string dateOfDeposit = dateTimePickerCustFirstdbt.Value.ToString("yyyy-MM-dd");

                // Check if any required field is empty
                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(dateOfBirth) ||
                    string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(trnNum) || string.IsNullOrWhiteSpace(phoneNumber) ||
                    string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(occupation))
                {
                    MessageBox.Show("Please enter all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        // Define your SQL query for updating the selected customer
                        string updateQuery = "UPDATE customer_table SET cust_firstname = @FirstName, cust_lastname = @LastName, " +
                                             "date_of_birth = @DateOfBirth, gender = @Gender, trn_num = @TrnNum, cust_phone = @PhoneNumber, " +
                                             "cust_address = @Address, occupation = @Occupation, Deposit_amt = @DepositAmount, " +
                                             "date_of_deposit = @DateOfDeposit WHERE cust_id = @CustomerId";

                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            // Add parameters for other fields
                            command.Parameters.AddWithValue("@FirstName", firstName);
                            command.Parameters.AddWithValue("@LastName", lastName);
                            command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                            command.Parameters.AddWithValue("@Gender", gender);
                            command.Parameters.AddWithValue("@TrnNum", trnNum);
                            command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                            command.Parameters.AddWithValue("@Address", address);
                            command.Parameters.AddWithValue("@Occupation", occupation);
                            command.Parameters.AddWithValue("@DepositAmount", depositAmount);
                            command.Parameters.AddWithValue("@DateOfDeposit", dateOfDeposit);
                            command.Parameters.AddWithValue("@CustomerId", selectedCustomerId);

                            // Execute the query
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Failed to update customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // Refresh the DataGridView after editing a customer
                        LoadCustomerData();
                    }
                }
            }
        }

        private void Delete_Cust_Click(object sender, EventArgs e)
        {
            if (dataGridView4NC.SelectedRows.Count > 0)
            {
                // Get the selected customer's ID
                int selectedCustomerId = Convert.ToInt32(dataGridView4NC.SelectedRows[0].Cells["cust_id"].Value);

                // Display a confirmation dialog before deletion
                DialogResult result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();

                            // Define your SQL query for deleting the selected customer
                            string deleteQuery = "DELETE FROM customer_table WHERE cust_id = @CustomerId";

                            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                            {
                                // Add parameter for the customer ID
                                command.Parameters.AddWithValue("@CustomerId", selectedCustomerId);

                                // Execute the query
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Failed to delete customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            // Refresh the DataGridView after deleting a customer
                            LoadCustomerData();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Search_Cust_Click(object sender, EventArgs e)
        {
            // Retrieve the search keyword
            string searchKeyword = searchTextBoxNC.Text;

            // Check if the search keyword is not empty
            if (!string.IsNullOrWhiteSpace(searchKeyword))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        // Define your SQL query for searching customers
                        string searchQuery = "SELECT cust_id, cust_firstname, cust_lastname, date_of_birth, gender, trn_num, " +
                                             "cust_phone, cust_address, occupation, deposit_amount, date_of_deposit " +
                                             "FROM customer_table " +
                                             "WHERE cust_firstname LIKE @SearchKeyword OR cust_lastname LIKE @SearchKeyword";

                        using (SqlCommand command = new SqlCommand(searchQuery, connection))
                        {
                            // Add parameter for the search keyword
                            command.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword + "%");

                            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);

                            // Assuming dataGridViewNewCust is the name of your DataGridView
                            dataGridView4NC.DataSource = dataTable;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a search keyword.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textFnameNC_TextChanged(object sender, EventArgs e)
        {

        }

        private void New_Customer_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1SEXNC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}




