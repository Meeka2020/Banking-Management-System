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
    public partial class Register_New_Agents : Form
    {
        private readonly string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=bank;Integrated Security=True;";
        private DataGridView dataGridViewAgents;

        public Register_New_Agents()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadAgentData();
        }

        private void InitializeDataGridView()
        {
            dataGridViewAgents = new DataGridView();
            dataGridViewAgents.CellClick += DataGridViewAgents_CellClick_CellContentClick;

        }
        private void DataGridViewAgents_CellClick_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridViewAgents.Rows[e.RowIndex].Selected = true;
            }
        }

        private void submit_button_Click(object sender, EventArgs e)
        {
            string firstName = textFnameAG.Text;
            string lastName = textBxLNameAG.Text;
            string address = textBxAddressAG.Text;
            string phoneNumber = textBxPhoneAG.Text;
            string occupation = textBxOccAG.Text;
            string username = textBxUsernameAG.Text;
            string password = textBxPassAG.Text;

            // Check if any required field is empty

            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(phoneNumber) ||
                string.IsNullOrWhiteSpace(occupation) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter all the required fields.");
                return; // Exit the method if any required field is empty
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO teams_info (emp_firstname, emp_lastname, emp_address, emp_phone, user_password, job) " +
                                         "VALUES (@FirstName, @LastName, @Address, @PhoneNumber, @Password, @Job)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Job", occupation);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Agent registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to register agent.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Edit_btn_NA_Click(object sender, EventArgs e)
        {
            if (dataGridViewAgents.SelectedRows.Count > 0)
            {
                int selectedAgentId = Convert.ToInt32(dataGridViewAgents.SelectedRows[0].Cells["agent_id"].Value);

                string editedFirstName = textFnameAG.Text; // Use existing value
                string editedLastName = textBxLNameAG.Text; // Use existing value
                string editedAddress = textBxAddressAG.Text; // Use existing value
                string editedPhoneNumber = textBxPhoneAG.Text; // Use existing value
                string editedOccupation = textBxOccAG.Text; // Use existing value
                string editedEmpusername = textBxUsernameAG.Text; // Use existing value
                string editedPassword = textBxPassAG.Text; // Use existing value

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string updateQuery = "UPDATE teams_info SET emp_firstname = @EditedFirstName, " +
                                             "emp_lastname = @EditedLastName, emp_address = @EditedAddress, " +
                                             "emp_phone = @EditedPhoneNumber, emp_username = @EditedEmpusername user_password = @EditedPassword, " +
                                             "job = @EditedJob " +
                                             "WHERE agent_id = @AgentId";

                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@EditedFirstName", editedFirstName);
                            command.Parameters.AddWithValue("@EditedLastName", editedLastName);
                            command.Parameters.AddWithValue("@EditedAddress", editedAddress);
                            command.Parameters.AddWithValue("@EditedPhoneNumber", editedPhoneNumber);
                            command.Parameters.AddWithValue("@EditedEmpusername", editedEmpusername);
                            command.Parameters.AddWithValue("@EditedPassword", editedPassword);
                            command.Parameters.AddWithValue("@EditedJob", editedOccupation);
                            command.Parameters.AddWithValue("@AgentId", selectedAgentId);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Agent updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Failed to update agent.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // Refresh the DataGridView after editing an agent
                        LoadAgentData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an agent to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void LoadAgentData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string selectQuery = "SELECT agent_id, emp_firstname, emp_lastname, emp_address, emp_phone, job, emp_username, user_password FROM teams_info";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridViewAgents.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Delete_btn_NA_Click(object sender, EventArgs e)
        {
            if (dataGridViewAgents.SelectedRows.Count > 0)
            {
                int selectedAgentId = Convert.ToInt32(dataGridViewAgents.SelectedRows[0].Cells["agent_id"].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string deleteQuery = "DELETE FROM teams_info WHERE agent_id = @AgentId";

                        using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("@AgentId", selectedAgentId);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Agent deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete agent.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // Refresh the DataGridView after deleting an agent
                        LoadAgentData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an agent to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void Search_btn_NA_Click(object sender, EventArgs e)
        {
            string searchTerm = searchTextBoxNA.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Please enter a search term.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string searchQuery = "SELECT agent_id, emp_firstname, emp_lastname, emp_address, emp_phone, job, emp_username, user_password " +
                                         "FROM teams_info " +
                                         "WHERE emp_firstname LIKE @SearchTerm OR emp_lastname LIKE @SearchTerm OR emp_username LIKE @SearchTerm";

                    using (SqlCommand command = new SqlCommand(searchQuery, connection))
                    {
                        command.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            dataGridViewAgents.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show("No matching records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
}
    

   



   

