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
    public partial class GenresAdmin : Form
    {
        public GenresAdmin()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already in this section.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeesAdmin employees = new EmployeesAdmin();
            employees.Show();
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
            ProductsAdmin products = new ProductsAdmin();
            products.Show();
            this.Close();
        }

        private void addGenre_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection("Data Source=SAB-ASUS\\SQLEXPRESS;Initial Catalog=SabsRecordStore_DB;Integrated Security=True;Encrypt=False");
            myConnection.Open();
            SqlCommand sc = myConnection.CreateCommand();
            sc.Parameters.AddWithValue("@P1", textBox1.Text);
            sc.CommandText = "INSERT INTO Genres([Name]) VALUES (@P1)";
            MessageBox.Show("New genre added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            sc.ExecuteNonQuery();
            sc.Dispose();
            myConnection.Close();
            this.genresTableAdapter.Fill(this.sabsRecordStore_DBDataSet3.Genres);
            try
            {
                this.genresTableAdapter.FillBy(this.sabsRecordStore_DBDataSet3.Genres);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void GenresAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sabsRecordStore_DBDataSet3.Genres' table. You can move, or remove it, as needed.
            this.genresTableAdapter.Fill(this.sabsRecordStore_DBDataSet3.Genres);
            try
            {
                this.genresTableAdapter.FillBy(this.sabsRecordStore_DBDataSet3.Genres);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int selectedId = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            SqlConnection myConnection = new SqlConnection("Data Source=SAB-ASUS\\SQLEXPRESS;Initial Catalog=SabsRecordStore_DB;Integrated Security=True;Encrypt=False");
            myConnection.Open();
            SqlCommand sc = myConnection.CreateCommand();
            sc.Parameters.AddWithValue("@P1", selectedId);
            sc.CommandText = "DELETE FROM Genres WHERE Genres.ID=@P1";
            sc.ExecuteNonQuery();
            MessageBox.Show("Genre deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            sc.ExecuteNonQuery();
            sc.Dispose();
            myConnection.Close();
            this.genresTableAdapter.Fill(this.sabsRecordStore_DBDataSet3.Genres);
            try
            {
                this.genresTableAdapter.FillBy(this.sabsRecordStore_DBDataSet3.Genres);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int selectedId = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            SqlConnection myConnection = new SqlConnection("Data Source=SAB-ASUS\\SQLEXPRESS;Initial Catalog=SabsRecordStore_DB;Integrated Security=True;Encrypt=False");
            myConnection.Open();
            SqlCommand sc = myConnection.CreateCommand();
            sc.Parameters.AddWithValue("@P1", textBox1.Text);
            sc.Parameters.AddWithValue("@P2", selectedId);
            sc.CommandText = "UPDATE Genres SET [Name]=@P1 WHERE Genres.ID=@P2";
            sc.ExecuteNonQuery();
            MessageBox.Show("Genre updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            sc.Dispose();
            myConnection.Close();
            this.genresTableAdapter.Fill(this.sabsRecordStore_DBDataSet3.Genres);
            try
            {
                this.genresTableAdapter.FillBy(this.sabsRecordStore_DBDataSet3.Genres);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.genresTableAdapter.FillBy(this.sabsRecordStore_DBDataSet3.Genres);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedId = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[selectedId].Cells[1].Value.ToString();
        }
    }
}
