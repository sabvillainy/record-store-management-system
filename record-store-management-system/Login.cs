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

namespace record_store_management_system
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void registerFromLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }
        SqlConnection myConnection = new SqlConnection("Data Source=SAB-ASUS\\SQLEXPRESS;Initial Catalog=SabsRecordStore_DB;Integrated Security=True;Encrypt=False");
        private void button1_Click(object sender, EventArgs e)
        {
            myConnection.Open();
            SqlCommand loginData = new SqlCommand("SELECT * FROM Users WHERE Username=@P1 AND [Password]=@P2 AND Role=@P3", myConnection);
            loginData.Parameters.AddWithValue("@P1", textBox1.Text);
            loginData.Parameters.AddWithValue("@P2", textBox2.Text);
            loginData.Parameters.AddWithValue("@P3", comboBox2.Text);
            SqlDataReader reader = loginData.ExecuteReader();
            if (reader.Read())
            {
                if (comboBox2.Text == "Admin") { 
                    EmployeesAdmin main = new EmployeesAdmin();
                    main.Show();
                    this.Hide();
                }
                else if (comboBox2.Text == "Employee")
                {
                    SalesEmployee a = new SalesEmployee();
                    a.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Wrong username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            myConnection.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sabsRecordStore_DBDataSet3.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.sabsRecordStore_DBDataSet3.Employees);
            // TODO: This line of code loads data into the 'sabsRecordStore_DBDataSet3.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.sabsRecordStore_DBDataSet3.Users);
        }
    }
}
