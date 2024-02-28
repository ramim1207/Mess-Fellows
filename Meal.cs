﻿using System;
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
    public partial class Meal : Form
    {
        private const string ConnectionString = "Data Source=DESKTOP-M2VK1OU\\SQLEXPRESS;Initial Catalog=Mess;Integrated Security=True";

        private string UserName;

        public Meal(string UserName)
        {
            InitializeComponent();
            this.UserName = UserName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedMealCount = 0;
            if (checkBox1.Checked) selectedMealCount++;
            if (checkBox2.Checked) selectedMealCount++;
            if (checkBox3.Checked) selectedMealCount++;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "INSERT INTO meals (username, date, meals) VALUES (@UserName, @date, @meals)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", UserName);
                    command.Parameters.AddWithValue("@date", DateTime.Today);
                    command.Parameters.AddWithValue("@meals", selectedMealCount);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Meal selection saved.");
            UserInterface userinterface = new UserInterface(UserName);
            userinterface.Show();
            this.Hide();
        }
    }
}
