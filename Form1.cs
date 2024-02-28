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

namespace Mess_Fellows
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=DESKTOP-M2VK1OU\\SQLEXPRESS;Initial Catalog=Mess;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();

            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM admin WHERE username = @username AND password = @password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", (password)); // Hash the password before comparing

                    int matchingUsersCount = (int)command.ExecuteScalar();

                    if (matchingUsersCount > 0)
                    {
                        // Successful login
                        MessageBox.Show("Login successful!");
                        // Open the next form or perform any required actions here
                    }
                    else
                    {
                        // Failed login
                        MessageBox.Show("Invalid username or password.");
                    }
                }

                var Interface = new Interface();
                Interface.Show();
                this.Hide();
            }
        }
    }
}
