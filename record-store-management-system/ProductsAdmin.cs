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
    public partial class ProductsAdmin : Form
    {
        public ProductsAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeesAdmin employees = new EmployeesAdmin();
            employees.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GenresAdmin genres = new GenresAdmin();
            genres.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ArtistsAdmin a = new ArtistsAdmin();
            a.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already in this section.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void ProductsAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sabsRecordStore_DBDataSet3.Genres' table. You can move, or remove it, as needed.
            this.genresTableAdapter.Fill(this.sabsRecordStore_DBDataSet3.Genres);
            // TODO: This line of code loads data into the 'sabsRecordStore_DBDataSet3.Artists' table. You can move, or remove it, as needed.
            this.artistsTableAdapter.Fill(this.sabsRecordStore_DBDataSet3.Artists);
            // TODO: This line of code loads data into the 'sabsRecordStore_DBDataSet3.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.sabsRecordStore_DBDataSet3.Products);
            // TODO: This line of code loads data into the 'sabsRecordStore_DBDataSet3.ProductTypes' table. You can move, or remove it, as needed.
            this.productTypesTableAdapter.Fill(this.sabsRecordStore_DBDataSet3.ProductTypes);

        }

        private void addProduct_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection("Data Source=SAB-ASUS\\SQLEXPRESS;Initial Catalog=SabsRecordStore_DB;Integrated Security=True;Encrypt=False");
            myConnection.Open();
            SqlCommand sc = myConnection.CreateCommand();
            sc.Parameters.AddWithValue("@P1", textBox1.Text);
            sc.Parameters.AddWithValue("@P2", comboBox2.Text);
            sc.Parameters.AddWithValue("@P3", comboBox1.Text);
            sc.Parameters.AddWithValue("@P4", comboBox3.Text);
            sc.Parameters.AddWithValue("@P5", textBox5.Text);
            sc.Parameters.AddWithValue("@P6", textBox6.Text);
            sc.CommandText = "INSERT INTO Products([Name], ProdType, Genre, Artist, Quantity, Price) VALUES (@P1, @P2, @P3, @P4, @P5, @P6)";
            MessageBox.Show("New product added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            sc.ExecuteNonQuery();
            sc.Dispose();
            myConnection.Close();
            this.productsTableAdapter.Fill(this.sabsRecordStore_DBDataSet3.Products);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int selectedId = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            SqlConnection myConnection = new SqlConnection("Data Source=SAB-ASUS\\SQLEXPRESS;Initial Catalog=SabsRecordStore_DB;Integrated Security=True;Encrypt=False");
            myConnection.Open();
            SqlCommand sc = myConnection.CreateCommand();
            sc.Parameters.AddWithValue("@P1", selectedId);
            sc.CommandText = "DELETE FROM Products WHERE Products.ID=@P1";
            MessageBox.Show("The product you selected is deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            sc.ExecuteNonQuery();
            sc.Dispose();
            myConnection.Close();
            this.productsTableAdapter.Fill(this.sabsRecordStore_DBDataSet3.Products);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int selectedId = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            SqlConnection myConnection = new SqlConnection("Data Source=SAB-ASUS\\SQLEXPRESS;Initial Catalog=SabsRecordStore_DB;Integrated Security=True;Encrypt=False");
            myConnection.Open();
            SqlCommand sc = myConnection.CreateCommand();
            sc.Parameters.AddWithValue("@P1", textBox1.Text);
            sc.Parameters.AddWithValue("@P2", comboBox2.Text);
            sc.Parameters.AddWithValue("@P3", comboBox1.Text);
            sc.Parameters.AddWithValue("@P4", comboBox3.Text);
            sc.Parameters.AddWithValue("@P5", textBox5.Text);
            sc.Parameters.AddWithValue("@P6", textBox6.Text);
            sc.Parameters.AddWithValue("@P7", selectedId);
            sc.CommandText = "UPDATE Products SET [Name]=@P1, ProdType=@P2, Genre=@P3, Artist=@P4, Quantity=@P5, Price=@P6 WHERE Products.ID=@P7";
            MessageBox.Show("The product you selected is updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            sc.ExecuteNonQuery();
            sc.Dispose();
            myConnection.Close();
            this.productsTableAdapter.Fill(this.sabsRecordStore_DBDataSet3.Products);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox2.Text = "";
            comboBox1.Text = "";
            comboBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedId = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[selectedId].Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[selectedId].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[selectedId].Cells[3].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[selectedId].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[selectedId].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[selectedId].Cells[6].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
