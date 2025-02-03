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
using System.Windows.Forms;

namespace Military
{
    public partial class AddForm : Form
    {
        private string connectionString = "Server=DESKTOP-ERGBU5D; Database=MilitaryDB; Trusted_Connection=True; TrustServerCertificate=True;";

        public AddForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(AddForm_Load); // Attach Load event
        }

        // Load event for AddForm to populate data on startup
        private void AddForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'militaryDBDataSet.Solders' table. You can move, or remove it, as needed.
            this.soldersTableAdapter.Fill(this.militaryDBDataSet.Solders);
            LoadProductsData();
            LoadSoldersData();
            LoadTotalCost();
            LoadTotalCashPay();
            LoadTotalCostAndCashPay(); 
            LoadNamesIntoComboBox();
        }

        private void LoadTotalCost()
        {
            string query = "SELECT SUM(Cost) FROM Sale";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        //MessageBox.Show($"Total Cost Retrieved: {result}"); // Test message
                        textBox4.Text = result != null ? result.ToString() : "0";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error retrieving total cost: {ex.Message}");
                    }
                }
            }
        }

        private void LoadTotalCashPay()
        {
            string query = "SELECT SUM(CashPay) FROM Cash";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        textBox1.Text = result != null ? result.ToString() : "0";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error retrieving total cash pay: {ex.Message}");
                    }
                }
            }
        }

        private void LoadTotalCostAndCashPay()
        {
            // SQL query to sum both Cost and CashPay
            string query = @"
        SELECT 
            (SELECT SUM(Cost) FROM Sale) AS TotalCost,
            (SELECT SUM(CashPay) FROM Cash) AS TotalCashPay";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Read the results
                            {
                                decimal totalCost = reader.IsDBNull(0) ? 0 : reader.GetDecimal(0); // Get TotalCost
                                decimal totalCashPay = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1); // Get TotalCashPay

                                // Calculate the total sum
                                decimal totalSum = totalCost + totalCashPay;

                                // Display the result in textBox3
                                textBox3.Text = totalSum.ToString("F2"); // Display with two decimal places
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error retrieving total cost and cash pay: {ex.Message}");
                    }
                }
            }
        }

        private void LoadNamesIntoComboBox()
        {
            string query = "SELECT Name FROM Sale"; // SQL query to select names

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            comboBox2.Items.Clear(); // Clear existing items in comboBox2

                            while (reader.Read()) // Read through the results
                            {
                                // Check if the Name column is not NULL and add to the ComboBox
                                if (!reader.IsDBNull(0))
                                {
                                    string name = reader.GetString(0);
                                    comboBox2.Items.Add(name); // Add the name to the ComboBox
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading names into ComboBox: {ex.Message}");
                    }
                }
            }
        }


        // Load Data into DataGridView from SQL Database
        private void LoadProductsData()
        {
            string query = "SELECT * FROM Products"; // Adjust to match your table name and structure

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;

                    // Hide the Id column
                    if (dataGridView1.Columns["Id"] != null)
                    {
                        dataGridView1.Columns["id"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        // Load Data into dataGridView2 from Soldiers table
        private void LoadSoldersData()
        {
            string query = "SELECT * FROM Solders";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable soldersTable = new DataTable();
                    adapter.Fill(soldersTable);
                    dataGridView2.DataSource = soldersTable;

                    // Hide the Id column
                    if (dataGridView2.Columns["Id"] != null)
                    {
                        dataGridView2.Columns["Id"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Solders data: {ex.Message}");
            }
        }

        //// Fetch data from the first column of dataGridView1
        //public List<string> GetDataFromFirstColumn()
        //{
        //    List<string> data = new List<string>();

        //    foreach (DataGridViewRow row in dataGridView1.Rows)
        //    {
        //        if (row.Cells[0].Value != null)
        //        {
        //            data.Add(row.Cells[0].Value.ToString());
        //        }
        //    }

        //    return data;
        //}

        // Add a new row using data from txt2 and domainUpDown controls
        private void Addbtn_Click(object sender, EventArgs e)
        {
            // Get data from the input fields
            string inputText = txt2.Text;
            string selectedDomainValue1 = domainUpDown1.Text;
            string selectedDomainValue2 = domainUpDown2.Text;

            // Ensure the input text is not empty
            if (!string.IsNullOrWhiteSpace(inputText))
            {
                // Define a query to check if the type already exists in the Products table
                string checkQuery = "SELECT COUNT(*) FROM Products WHERE Type = @Type";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@Type", inputText);

                    try
                    {
                        connection.Open();
                        int count = (int)checkCommand.ExecuteScalar(); // Get the count of existing types

                        if (count > 0)
                        {
                            // If count is greater than 0, the type already exists
                            MessageBox.Show("This type already exists in the database.");
                        }
                        else
                        {
                            // Insert the new record since the type does not exist
                            string insertQuery = "INSERT INTO Products (Type, Quantity, Price) VALUES (@Type, @Quantity, @Price)";

                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@Type", inputText);
                                insertCommand.Parameters.AddWithValue("@Quantity", selectedDomainValue1);
                                insertCommand.Parameters.AddWithValue("@Price", selectedDomainValue2);

                                insertCommand.ExecuteNonQuery();

                                // Reload data from the database to show the new entry
                                LoadProductsData();

                                // Clear input fields
                                txt2.Clear();
                                domainUpDown1.SelectedItem = null;
                                domainUpDown2.SelectedItem = null;

                                MessageBox.Show("Data added successfully to the database.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error adding data to database: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a value before adding.");
            }
        }



        // Delete a row based on matching txt2 content
        private void button1_Click(object sender, EventArgs e)
        {
            string inputText = txt2.Text;

            if (!string.IsNullOrWhiteSpace(inputText))
            {
                // Define the SQL DELETE query
                string query = "DELETE FROM Products WHERE Type = @Type";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Type", inputText); // Parameterize the input

                    try
                    {
                        connection.Open();

                        // Execute the SQL DELETE command
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // If a row was found and deleted in the database
                            MessageBox.Show("Record deleted successfully.");

                            // Refresh dataGridView1 to show updated table
                            LoadProductsData();
                        }
                        else
                        {
                            MessageBox.Show("No matching record found in the database.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting data: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a value to delete.");
            }
        }



        // Add textBox2 content to dataGridView2
        private void button3_Click(object sender, EventArgs e)
        {
            string inputText = textBox2.Text;

            if (!string.IsNullOrWhiteSpace(inputText))
            {
                // Define the SQL query to check if the name already exists in the Solders table
                string checkQuery = "SELECT COUNT(*) FROM Solders WHERE Name = @Name";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Name", inputText);

                        try
                        {
                            connection.Open();
                            int count = (int)checkCommand.ExecuteScalar(); // Get the count of existing names

                            if (count > 0)
                            {
                                // If count is greater than 0, the name already exists
                                MessageBox.Show("This name already exists in the database.");
                            }
                            else
                            {
                                // Define the SQL query to insert data into the Solders table
                                string insertQuery = "INSERT INTO Solders (Name) VALUES (@Name)";

                                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@Name", inputText);
                                    insertCommand.ExecuteNonQuery(); // Execute the insert command

                                    MessageBox.Show("Data successfully added to the database.");
                                    textBox2.Clear(); // Clear the text box after insertion
                                    LoadSoldersData(); // Reload data to show the updated table in dataGridView2
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error adding data: {ex.Message}");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a value before adding.");
            }
        }


        // Delete row from dataGridView2 based on textBox2 content
        // Delete row from the Soldiers table in the database based on textBox2 content
        private void button2_Click(object sender, EventArgs e)
        {
            string inputText = textBox2.Text;

            if (!string.IsNullOrWhiteSpace(inputText))
            {
                // Define the SQL query to delete data from the Soldiers table
                string query = "DELETE FROM Solders WHERE Name = @Name"; // Adjust column name if needed

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", inputText);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data successfully deleted from the database.");
                            LoadSoldersData(); // Refresh dataGridView2 to show updated table
                        }
                        else
                        {
                            MessageBox.Show("No matching record found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting data: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a value to delete.");
            }
        }


        // Button to open SellForm and close AddForm
        private void button4_Click(object sender, EventArgs e)
        {
            SellForm sellForm = new SellForm();
            sellForm.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                // Check if a row is selected and avoid header clicks
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Get the selected cell value and display it in textBox2
                    textBox2.Text = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the row index is valid
            if (e.RowIndex >= 0)
            {
                // Retrieve values from the selected row
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Assign the 'Type' value to txt2
                txt2.Text = selectedRow.Cells["Type"].Value?.ToString();

                // Assign the 'Quantity' value to domainUpDown1 (ensure the column name is correct)
                domainUpDown1.Text = selectedRow.Cells["Quantity"].Value?.ToString();

                // Assign the 'Price' value to domainUpDown2 (ensure the column name is correct)
                domainUpDown2.Text = selectedRow.Cells["Price"].Value?.ToString();
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            // Ensure there is a selected row in the DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get data from the input fields
                string newType = txt2.Text;
                string newQuantity = domainUpDown1.Text;
                string newPrice = domainUpDown2.Text;

                if (string.IsNullOrWhiteSpace(newType))
                {
                    MessageBox.Show("Please enter a valid Type.");
                    return;
                }

                // Get the original Type value from the selected row
                string originalType = dataGridView1.SelectedRows[0].Cells["Type"].Value?.ToString();

                // Define the query to update the record
                string updateQuery = "UPDATE Products SET Type = @NewType, Quantity = @NewQuantity, Price = @NewPrice WHERE Type = @OriginalType";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    // Set parameter values
                    updateCommand.Parameters.AddWithValue("@NewType", newType);
                    updateCommand.Parameters.AddWithValue("@NewQuantity", newQuantity);
                    updateCommand.Parameters.AddWithValue("@NewPrice", newPrice);
                    updateCommand.Parameters.AddWithValue("@OriginalType", originalType);

                    try
                    {
                        // Open the connection and execute the update query
                        connection.Open();
                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record updated successfully.");

                            // Reload data from the database to reflect the changes
                            LoadProductsData();

                            // Clear input fields
                            txt2.Clear();
                            domainUpDown1.SelectedItem = null;
                            domainUpDown2.SelectedItem = null;
                        }
                        else
                        {
                            MessageBox.Show("Error: No record was updated.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating record: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a record to edit.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Get the selected name from comboBox2
            string selectedName = comboBox2.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(selectedName))
            {
                MessageBox.Show("Please select a name from the list.");
                return;
            }

            decimal costToRemove = 0;

            // Step 1: Retrieve the cost for the selected name
            string selectQuery = "SELECT Cost FROM Sale WHERE Name = @Name";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@Name", selectedName);

                    try
                    {
                        connection.Open();
                        object result = selectCommand.ExecuteScalar();

                        if (result != null && decimal.TryParse(result.ToString(), out costToRemove))
                        {
                            // Step 2: Delete the row from Sale table
                            string deleteQuery = "DELETE FROM Sale WHERE Name = @Name";
                            using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                            {
                                deleteCommand.Parameters.AddWithValue("@Name", selectedName);
                                deleteCommand.ExecuteNonQuery();
                            }

                            // Step 3: Insert the cost into Cash table
                            string insertQuery = "INSERT INTO Cash (CashPay) VALUES (@CashPay)";
                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@CashPay", costToRemove);
                                insertCommand.ExecuteNonQuery();
                            }

                            MessageBox.Show("Row removed and cost added to Cash successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Error retrieving cost for the selected name.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error processing request: {ex.Message}");
                    }
                }
            }

            // Optionally, reload data in the DataGridView or other controls as needed
            LoadNamesIntoComboBox(); // Refresh the ComboBox after deletion
            LoadTotalCost();
            LoadTotalCashPay();
            LoadTotalCostAndCashPay();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Show a confirmation dialog
            DialogResult result = MessageBox.Show("Are you sure you want to delete all rows from the CashPay column in the Cash table?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Check if the user clicked 'Yes'
            if (result == DialogResult.Yes)
            {
                // SQL query to delete all rows from the Cash table
                string query = "DELETE FROM Cash";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            MessageBox.Show($"{rowsAffected} rows deleted from the Cash table.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error deleting rows: {ex.Message}");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Delete operation cancelled.");
            }
            LoadTotalCost();
            LoadTotalCashPay();
            LoadTotalCostAndCashPay();
        }
    }
}
