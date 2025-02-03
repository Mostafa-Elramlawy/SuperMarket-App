using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;

namespace Military
{
    public partial class SellForm : Form
    {
        // Declare the connection string at the class level
        private string connectionString = "Server=DESKTOP-ERGBU5D; Database=MilitaryDB; Trusted_Connection=True; TrustServerCertificate=True;";

        public SellForm()
        {
            InitializeComponent();
        }

        private void SellForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'militaryDBDataSet1.Sale' table. You can move, or remove it, as needed.
            this.saleTableAdapter.Fill(this.militaryDBDataSet1.Sale);
            LoadSoldersData();
            LoadProductTypes();
            LoadSaleData();
            label5.Text = DateTime.Now.ToString("yyyy-MM-dd");
            label6.Text = DateTime.Now.ToString("h:mm:ss tt");
        }

        // In SellForm (Form1)
        private AddForm addForm;

        public SellForm(AddForm passedAddForm)
        {
            InitializeComponent();
            addForm = passedAddForm;
        }

        // In SellForm, when opening AddForm
        private void ShowAddForm()
        {
            AddForm addForm = new AddForm();
            SellForm sellForm = new SellForm(addForm);
            sellForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Define the bounds for the row header where the row number will be displayed
            Rectangle headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top,
                                                   dataGridView3.RowHeadersWidth, e.RowBounds.Height);

            // Calculate the row number (adding 1 because row indices start at 0)
            string rowNumber = (e.RowIndex + 1).ToString();

            // Draw the row number inside the row header
            TextRenderer.DrawText(e.Graphics, rowNumber,
                                  dataGridView3.RowHeadersDefaultCellStyle.Font,
                                  headerBounds,
                                  dataGridView3.RowHeadersDefaultCellStyle.ForeColor,
                                  TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void LoadSoldersData()
        {
            string query = "SELECT Name FROM Solders"; // Adjust this if your column name is different

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Assuming the Type is in the first column of the result
                                comboBox2.Items.Add(reader["Name"].ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading data: {ex.Message}");
                    }
                }
            }
        }


        private void LoadProductTypes()
        {
            // SQL query to select the "Type" column from the "Products" table
            string query = "SELECT Type FROM Products";

            // Clear existing items in comboBox1
            comboBox1.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Add each "Type" value to comboBox1
                            comboBox1.Items.Add(reader["Type"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading product types: {ex.Message}");
                }
            }
            if (comboBox1.Items.Count == 0)
            {
                MessageBox.Show("No items were added to comboBox1.");
            }
        }

        private void LoadSaleData()
        {
            // Your code to retrieve data from the Sale table
            string query = "SELECT * FROM Sale"; // Adjust the query to select only the required columns if needed

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridView3.DataSource = dataTable;

                            // Hide the ID column (replace "ID" with the actual column name if necessary)
                            if (dataGridView3.Columns["ID"] != null)
                            {
                                dataGridView3.Columns["ID"].Visible = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading sale data: {ex.Message}");
                    }
                }
            }
        }




        private void button3_Click(object sender, EventArgs e)
        {
            // Create and show AddForm (Form2)
            SellForm sellForm = new SellForm();


            // Prompt the user to enter a password
            string password = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter password to access this feature:", "Password Required");

            // Define the correct password (for example, "admin123")
            string correctPassword = "123";

            // Check if the entered password is correct
            if (password == correctPassword)
            {
                // If the password is correct, open AddForm
                AddForm addForm = new AddForm();
                addForm.Show();

                // Close SellForm
                this.Hide();
            }
            else
            {
                // Show an error message if the password is incorrect
                MessageBox.Show("Incorrect password. Access denied.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            // Get the selected name from comboBox2
            string selectedName = comboBox2.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(selectedName))
            {
                MessageBox.Show("Please select a name from the list.");
                return;
            }

            // Get the type (to find the price and update the quantity)
            string selectedType = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(selectedType))
            {
                MessageBox.Show("Please select a type from the list.");
                return;
            }

            // Retrieve the price from the Products table based on the selected type
            decimal price = 0;
            string query = "SELECT Price FROM Products WHERE Type = @Type";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Type", selectedType);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && decimal.TryParse(result.ToString(), out price))
                        {
                            // Price successfully retrieved
                        }
                        else
                        {
                            MessageBox.Show("Error retrieving price for the selected product.");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error retrieving price: {ex.Message}");
                        return;
                    }
                }
            }

            // Calculate the final cost based on the domainUpDown2 value
            decimal quantity = 1;
            if (decimal.TryParse(domainUpDown2.Text, out decimal parsedValue))
            {
                quantity = parsedValue;
            }
            else
            {
                MessageBox.Show("Invalid quantity. Please enter a valid number.");
                return;
            }

            decimal finalCost = price * quantity;

            // Check if a record with the selected name already exists in the Sale table
            string checkQuery = "SELECT Cost FROM Sale WHERE Name = @Name";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@Name", selectedName);

                    try
                    {
                        connection.Open();
                        object existingCostObj = checkCommand.ExecuteScalar();

                        if (existingCostObj != null)
                        {
                            // If record exists, update the existing cost by adding the finalCost
                            decimal existingCost = Convert.ToDecimal(existingCostObj);
                            decimal updatedCost = existingCost + finalCost;

                            string updateQuery = "UPDATE Sale SET Cost = @UpdatedCost WHERE Name = @Name";
                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@UpdatedCost", updatedCost);
                                updateCommand.Parameters.AddWithValue("@Name", selectedName);

                                updateCommand.ExecuteNonQuery();
                                MessageBox.Show("Cost updated successfully.");
                            }
                        }
                        else
                        {
                            // If record does not exist, insert a new record
                            string insertQuery = "INSERT INTO Sale (Name, Cost) VALUES (@Name, @Cost)";
                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@Name", selectedName);
                                insertCommand.Parameters.AddWithValue("@Cost", finalCost);

                                insertCommand.ExecuteNonQuery();
                                MessageBox.Show("Record added successfully.");
                            }
                        }

                        // Step 3: Update the product's quantity in the Products table
                        string updateQuantityQuery = "UPDATE Products SET Quantity = Quantity - @Quantity WHERE Type = @Type";
                        using (SqlCommand updateQuantityCommand = new SqlCommand(updateQuantityQuery, connection))
                        {
                            updateQuantityCommand.Parameters.AddWithValue("@Quantity", quantity);
                            updateQuantityCommand.Parameters.AddWithValue("@Type", selectedType);

                            int rowsAffected = updateQuantityCommand.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                //MessageBox.Show("Product quantity updated successfully.");
                            }
                            else
                            {
                                MessageBox.Show("Failed to update product quantity.");
                            }
                        }

                        // Reload data in the DataGridView after insert/update
                        LoadSaleData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error adding or updating record: {ex.Message}");
                    }
                }
            }
        }


       private void button1_Click(object sender, EventArgs e)
{
    // Get the selected name from comboBox2
    string selectedName = comboBox2.SelectedItem?.ToString();

    if (string.IsNullOrWhiteSpace(selectedName))
    {
        MessageBox.Show("Please select a name from the list.");
        return;
    }

    // Get the type (to find the price)
    string selectedType = comboBox1.SelectedItem?.ToString();
    if (string.IsNullOrWhiteSpace(selectedType))
    {
        MessageBox.Show("Please select a type from the list.");
        return;
    }

    // Retrieve the price from the Products table based on the selected type
    decimal price = 0;
    string query = "SELECT Price FROM Products WHERE Type = @Type";

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Type", selectedType);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && decimal.TryParse(result.ToString(), out price))
                {
                    // Price retrieved successfully
                }
                else
                {
                    MessageBox.Show("Error retrieving price for the selected product.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving price: {ex.Message}");
                return;
            }
        }
    }

    // Calculate the cost to subtract based on domainUpDown2 value
    decimal quantity = 1;
    if (!decimal.TryParse(domainUpDown2.Text, out quantity))
    {
        MessageBox.Show("Invalid quantity. Please enter a valid number.");
        return;
    }

    decimal subtractCost = price * quantity;

    // Check if the record with the selected name already exists in the Sale table
    string checkQuery = "SELECT Cost FROM Sale WHERE Name = @Name";

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        using (SqlCommand command = new SqlCommand(checkQuery, connection))
        {
            command.Parameters.AddWithValue("@Name", selectedName);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && decimal.TryParse(result.ToString(), out decimal currentCost))
                {
                    // Subtract the cost from the existing cost
                    decimal newCost = currentCost - subtractCost;

                    // Update the Sale table with the new cost, ensuring it doesn't go below zero
                    string updateQuery = "UPDATE Sale SET Cost = @NewCost WHERE Name = @Name";
                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@NewCost", Math.Max(newCost, 0)); // Ensures Cost doesn't go negative
                        updateCommand.Parameters.AddWithValue("@Name", selectedName);
                        updateCommand.ExecuteNonQuery();
                    }

                    // Delete records where the final cost is zero
                    string deleteQuery = "DELETE FROM Sale WHERE Cost = 0";
                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                    {
                        deleteCommand.ExecuteNonQuery();
                    }

                    // Update the quantity in the Products table
                    string updateQuantityQuery = "UPDATE Products SET Quantity = Quantity + @Quantity WHERE Type = @Type";
                    using (SqlCommand updateQuantityCommand = new SqlCommand(updateQuantityQuery, connection))
                    {
                        updateQuantityCommand.Parameters.AddWithValue("@Quantity", quantity);
                        updateQuantityCommand.Parameters.AddWithValue("@Type", selectedType);
                        updateQuantityCommand.ExecuteNonQuery();
                    }

                    //MessageBox.Show("Cost subtracted and quantity updated successfully.");
                    LoadSaleData();
                }
                else
                {
                    MessageBox.Show("Record not found for the selected name.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating record: {ex.Message}");
            }
        }
    }
}


        private void button2_Click(object sender, EventArgs e)
        {
            // Get the type (to find the price)
            string selectedType = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(selectedType))
            {
                MessageBox.Show("Please select a type from the list.");
                return;
            }

            // Retrieve the price from the Products table based on the selected type
            decimal price = 0;
            string query = "SELECT Price FROM Products WHERE Type = @Type";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Type", selectedType);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && decimal.TryParse(result.ToString(), out price))
                        {
                            // Price successfully retrieved
                        }
                        else
                        {
                            MessageBox.Show("Error retrieving price for the selected product.");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error retrieving price: {ex.Message}");
                        return;
                    }
                }
            }

            // Calculate the final cash payment based on the domainUpDown2 value
            decimal quantity = 1; // Default quantity
            if (decimal.TryParse(domainUpDown2.Text, out decimal parsedValue))
            {
                quantity = parsedValue;
            }
            else
            {
                MessageBox.Show("Invalid quantity. Please enter a valid number.");
                return;
            }

            decimal cashPay = price * quantity;

            // Insert the cashPay into the Cash table
            string insertQuery = "INSERT INTO Cash (CashPay) VALUES (@CashPay)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@CashPay", cashPay);

                    try
                    {
                        connection.Open();
                        insertCommand.ExecuteNonQuery();
                        MessageBox.Show("Cash payment recorded successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error recording cash payment: {ex.Message}");
                    }
                }
            }

            // Update the quantity in the Products table
            string updateQuantityQuery = "UPDATE Products SET Quantity = Quantity - @Quantity WHERE Type = @Type";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand updateCommand = new SqlCommand(updateQuantityQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@Quantity", quantity);
                    updateCommand.Parameters.AddWithValue("@Type", selectedType);

                    try
                    {
                        connection.Open();
                        int rowsAffected = updateCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            //MessageBox.Show("Product quantity updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update product quantity.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating product quantity: {ex.Message}");
                    }

                    // Optionally, reload data in the DataGridView or other controls as needed
                    LoadSaleData();
                }
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
