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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace record_store_management_system
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == textBox4.Text)
            {
                SqlConnection myConnection = new SqlConnection("Data Source=SAB-ASUS\\SQLEXPRESS;Initial Catalog=SabsRecordStore_DB;Integrated Security=True;Encrypt=False");
                myConnection.Open();
                SqlCommand registerData = myConnection.CreateCommand();
                registerData.Parameters.AddWithValue("@P1", textBox1.Text);
                registerData.Parameters.AddWithValue("@P2", textBox3.Text);
                registerData.CommandText = "INSERT INTO Users(Username, [Password], [Role]) VALUES (@P1, @P2, 'Admin')";
                MessageBox.Show("You registered successfully.","Success",MessageBoxButtons.OK, MessageBoxIcon.Information);
                registerData.ExecuteNonQuery();
                registerData.Dispose();
                myConnection.Close();
            }
            else
            {
                MessageBox.Show("Passwords doesn't match. Try again.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
