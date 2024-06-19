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

namespace record_store_management_system
{
    public partial class EmployeesAdmin : Form
    {
        public EmployeesAdmin()
        {
            InitializeComponent();
        }

        private void addEmployee_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection("Data Source=SAB-ASUS\\SQLEXPRESS;Initial Catalog=SabsRecordStore_DB;Integrated Security=True;Encrypt=False");
            myConnection.Open();
            SqlCommand sc = myConnection.CreateCommand();
            sc.Parameters.AddWithValue("@P1", textBox1.Text);
            sc.Parameters.AddWithValue("@P2", textBox2.Text);
            sc.Parameters.AddWithValue("@P3", textBox3.Text);
            sc.Parameters.AddWithValue("@P4", textBox4.Text);
            sc.Parameters.AddWithValue("@P5", textBox5.Text);
            sc.CommandText = "INSERT INTO Users(Username, [Password], [Role]) VALUES (@P1, @P5, 'Employee')";
            sc.ExecuteNonQuery();
            sc.CommandText = "INSERT INTO Employees(Number, [Name], [Surname], Age, [Password]) VALUES (@P1, @P2, @P3, @P4, @P5)";
            MessageBox.Show("New employee added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            sc.ExecuteNonQuery();
            
            myConnection.Close();
            this.employeesTableAdapter1.Fill(this.sabsRecordStore_DBDataSet3.Employees);
        }

        private void EmployeesAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sabsRecordStore_DBDataSet3.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter1.Fill(this.sabsRecordStore_DBDataSet3.Employees);
            // TODO: This line of code loads data into the 'sabsRecordStore_DBDataSet1.Employees' table. You can move, or remove it, as needed.
            //this.employeesTableAdapter.Fill(this.sabsRecordStore_DBDataSet1.Employees);
            // TODO: This line of code loads data into the 'sabsRecordStore_DBDataSet1.Employees' table. You can move, or remove it, as needed.
            //this.employeesTableAdapter.Fill(this.sabsRecordStore_DBDataSet1.Employees);
            // TODO: This line of code loads data into the 'sabsRecordStore_DBDataSet11.Employees' table. You can move, or remove it, as needed.
            //this.employeesTableAdapter.Fill(this.sabsRecordStore_DBDataSet11.Employees);
            // TODO: This line of code loads data into the 'sabsRecordStore_DBDataSet1.Employees' table. You can move, or remove it, as needed.
            //this.employeesTableAdapter.Fill(this.sabsRecordStore_DBDataSet1.Employees);
            // TODO: This line of code loads data into the 'sabsRecordStore_DBDataSet1.Employees' table. You can move, or remove it, as needed.
            //this.employeesTableAdapter.Fill(this.sabsRecordStore_DBDataSet1.Employees);
            // TODO: This line of code loads data into the 'sabsRecordStore_DBDataSet1.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.sabsRecordStore_DBDataSet1.Users);


        }

        private void button7_Click(object sender, EventArgs e)
        {
            int selectedId = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            SqlConnection myConnection = new SqlConnection("Data Source=SAB-ASUS\\SQLEXPRESS;Initial Catalog=SabsRecordStore_DB;Integrated Security=True;Encrypt=False");
            myConnection.Open();
            SqlCommand sc = myConnection.CreateCommand();
            sc.Parameters.AddWithValue("@P1", textBox1.Text);
            sc.Parameters.AddWithValue("@P2", textBox2.Text);
            sc.Parameters.AddWithValue("@P3", textBox3.Text);
            sc.Parameters.AddWithValue("@P4", textBox4.Text);
            sc.Parameters.AddWithValue("@P5", textBox5.Text);
            sc.Parameters.AddWithValue("@P6", selectedId);
            sc.CommandText = "UPDATE Users SET Username=@P1,[Password]=@P5 WHERE ID=@P6";
            sc.ExecuteNonQuery();
            sc.CommandText = "UPDATE Employees SET Number=@P1, [Name]=@P2, [Surname]=@P3, Age=@P4, [Password]=@P5 WHERE ID=@P6";
            MessageBox.Show("The employee you selected is updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            sc.ExecuteNonQuery();
            
            myConnection.Close();
            this.employeesTableAdapter1.Fill(this.sabsRecordStore_DBDataSet3.Employees);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int selectedId = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            string number = "";
            SqlConnection myConnection = new SqlConnection("Data Source=SAB-ASUS\\SQLEXPRESS;Initial Catalog=SabsRecordStore_DB;Integrated Security=True;Encrypt=False");
            myConnection.Open();
            SqlCommand sc = myConnection.CreateCommand();
            sc.Parameters.AddWithValue("@P1", selectedId);
            sc.CommandText = "SELECT * FROM Employees WHERE Employees.ID=@P1";
            SqlDataReader reader = sc.ExecuteReader();
            if (reader.Read())
            {
                number = reader["Number"].ToString();
            }
            sc.Parameters.AddWithValue("@P2", number);
            reader.Close();
            DialogResult mesaj = new DialogResult();
            mesaj = MessageBox.Show("Are you sure you want to delete "+number+"?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (mesaj == DialogResult.Yes)
            {
                sc.CommandText = "DELETE from Employees where Employees.ID=@P1";
                sc.ExecuteNonQuery();
                sc.CommandText = "DELETE FROM Users WHERE Users.Username=@P2";
                sc.ExecuteNonQuery();
            }
            myConnection.Close();
            this.employeesTableAdapter1.Fill(this.sabsRecordStore_DBDataSet3.Employees);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GenresAdmin genres = new GenresAdmin();
            genres.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ProductsAdmin products = new ProductsAdmin();
            products.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ArtistsAdmin a = new ArtistsAdmin();
            a.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already in this section.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedId = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[selectedId].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[selectedId].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[selectedId].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[selectedId].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[selectedId].Cells[5].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}