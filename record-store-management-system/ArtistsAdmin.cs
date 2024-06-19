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
    public partial class ArtistsAdmin : Form
    {
        public ArtistsAdmin()
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
            MessageBox.Show("You are already in this section.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ProductsAdmin products = new ProductsAdmin();
            products.Show();
            this.Close();
        }

        private void ArtistsAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sabsRecordStore_DBDataSet3.Artists' table. You can move, or remove it, as needed.
            this.artistsTableAdapter.Fill(this.sabsRecordStore_DBDataSet3.Artists);
            try
            {
                this.artistsTableAdapter.FillBy(this.sabsRecordStore_DBDataSet3.Artists);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void addArtist_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection("Data Source=SAB-ASUS\\SQLEXPRESS;Initial Catalog=SabsRecordStore_DB;Integrated Security=True;Encrypt=False");
            myConnection.Open();
            SqlCommand sc = myConnection.CreateCommand();
            sc.Parameters.AddWithValue("@P1", textBox1.Text);
            sc.CommandText = "INSERT INTO Artists([Name]) VALUES (@P1)";
            MessageBox.Show("New artist added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            sc.ExecuteNonQuery();
            myConnection.Close();
            this.artistsTableAdapter.Fill(this.sabsRecordStore_DBDataSet3.Artists);
            try
            {
                this.artistsTableAdapter.FillBy(this.sabsRecordStore_DBDataSet3.Artists);
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
            sc.CommandText = "UPDATE Artists SET [Name]=@P1 WHERE ID=@P2";
            sc.ExecuteNonQuery();
            MessageBox.Show("Artist updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            myConnection.Close();
            this.artistsTableAdapter.Fill(this.sabsRecordStore_DBDataSet3.Artists);
            try
            {
                this.artistsTableAdapter.FillBy(this.sabsRecordStore_DBDataSet3.Artists);
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
            sc.CommandText = "DELETE FROM Artists WHERE Artists.ID=@P1";
            sc.ExecuteNonQuery();
            MessageBox.Show("Artist deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            sc.ExecuteNonQuery();
            myConnection.Close();
            this.artistsTableAdapter.Fill(this.sabsRecordStore_DBDataSet3.Artists);
            try
            {
                this.artistsTableAdapter.FillBy(this.sabsRecordStore_DBDataSet3.Artists);
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
                this.artistsTableAdapter.FillBy(this.sabsRecordStore_DBDataSet3.Artists);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

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
