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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace record_store_management_system
{
    public partial class SalesEmployee : Form
    {
        public SalesEmployee()
        {
            InitializeComponent();
        }

        private void SalesEmployee_Load(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToString("dd MMMM yyyy");
            // TODO: This line of code loads data into the 'sabsRecordStore_DBDataSet3.Cart' table. You can move, or remove it, as needed.
            this.cartTableAdapter.Fill(this.sabsRecordStore_DBDataSet3.Cart);
            // TODO: This line of code loads data into the 'sabsRecordStore_DBDataSet3.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.sabsRecordStore_DBDataSet3.Products);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedId = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[selectedId].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[selectedId].Cells[5].Value.ToString();
            textBox3.Text = dataGridView1.Rows[selectedId].Cells[6].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(textBox2.Text);
            decimal price = decimal.Parse(textBox3.Text);
            decimal total = quantity * price;

            SqlConnection myConnection = new SqlConnection("Data Source=SAB-ASUS\\SQLEXPRESS;Initial Catalog=SabsRecordStore_DB;Integrated Security=True;Encrypt=False");
            myConnection.Open();
            SqlCommand sc = myConnection.CreateCommand();
            sc.Parameters.AddWithValue("@P1", textBox1.Text);
            sc.Parameters.AddWithValue("@P2", quantity);
            sc.Parameters.AddWithValue("@P3", price);
            sc.Parameters.AddWithValue("@P4", total);
            sc.CommandText = "INSERT INTO Cart([Name], Quantity, Price, Total) VALUES (@P1, @P2, @P3, @P4)";
            MessageBox.Show("The product you selected is added to cart successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            sc.ExecuteNonQuery();
            sc.Dispose();
            myConnection.Close();
            this.cartTableAdapter.Fill(this.sabsRecordStore_DBDataSet3.Cart);
            UpdateCartTotalLabel();
        }

        private decimal GetCartTotal()
        {
            decimal total = 0;
            string connectionString = "Data Source=SAB-ASUS\\SQLEXPRESS;Initial Catalog=SabsRecordStore_DB;Integrated Security=True;Encrypt=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT SUM(Total) FROM Cart";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        total = (decimal)result;
                    }
                }
            }
            return total;
        }

        private void UpdateCartTotalLabel()
        {
            decimal total = GetCartTotal();
            labelTotal.Text = total.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedId = Convert.ToInt32(dataGridView2.SelectedCells[0].Value);
            SqlConnection myConnection = new SqlConnection("Data Source=SAB-ASUS\\SQLEXPRESS;Initial Catalog=SabsRecordStore_DB;Integrated Security=True;Encrypt=False");
            myConnection.Open();
            SqlCommand sc = myConnection.CreateCommand();
            sc.Parameters.AddWithValue("@P1", selectedId);
            sc.CommandText = "DELETE FROM Cart WHERE Cart.ID=@P1";
            MessageBox.Show("The product you selected is deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            sc.ExecuteNonQuery();
            sc.Dispose();
            myConnection.Close();
            this.productsTableAdapter.Fill(this.sabsRecordStore_DBDataSet3.Products);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            decimal paidAmount = Convert.ToDecimal(textBox4.Text);
            decimal total = Convert.ToDecimal(labelTotal.Text);
            decimal change = paidAmount - total;
            label9.Text = change.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=SAB-ASUS\\SQLEXPRESS;Initial Catalog=SabsRecordStore_DB;Integrated Security=True;Encrypt=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // 1. Cart tablosundaki tüm verileri almak
                string selectCartQuery = "SELECT Name, Quantity FROM Cart";
                SqlCommand selectCartCommand = new SqlCommand(selectCartQuery, connection);

                List<(string productName, int quantitySold)> cartItems = new List<(string productName, int quantitySold)>();

                using (SqlDataReader reader = selectCartCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string productName = reader["Name"].ToString();
                        int quantitySold = (int)reader["Quantity"];
                        cartItems.Add((productName, quantitySold));
                    }
                }

                // 2. Products tablosundaki quantity'yi güncelle
                foreach (var item in cartItems)
                {
                    string updateProductQuery = "UPDATE Products SET Quantity = Quantity - @QuantitySold WHERE Name = @ProductName";
                    SqlCommand updateProductCommand = new SqlCommand(updateProductQuery, connection);
                    updateProductCommand.Parameters.AddWithValue("@QuantitySold", item.quantitySold);
                    updateProductCommand.Parameters.AddWithValue("@ProductName", item.productName);
                    updateProductCommand.ExecuteNonQuery();
                }

                // 3. Cart tablosundaki tüm verileri sil
                string deleteCartQuery = "DELETE FROM Cart";
                SqlCommand deleteCartCommand = new SqlCommand(deleteCartQuery, connection);
                deleteCartCommand.ExecuteNonQuery();

                // 4. Total ve Change label'larını sıfırla
                labelTotal.Text = "0";
                label9.Text = "0";

                MessageBox.Show("Transaction completed and cart has been cleared.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cart table adapter güncelle
                this.cartTableAdapter.Fill(this.sabsRecordStore_DBDataSet3.Cart);
                this.productsTableAdapter.Fill(this.sabsRecordStore_DBDataSet3.Products);
            }
        }
    }
}
