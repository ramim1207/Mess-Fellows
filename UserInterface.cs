using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mess_Fellows
{
    public partial class UserInterface : Form
    {
        private string UserName;
        public UserInterface(string UserName)
        {
            InitializeComponent();
            this.UserName = UserName;
        }

        private void OpenMeal()
        {
            Meal meal = new Meal(UserName);
            meal.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            var deposite = new Deposite();
            deposite.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            var deposite = new Deposite();
            deposite.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            OpenMeal();
            this.Hide();

        }
        private void label2_Click(object sender, EventArgs e)
        {
            OpenMeal();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
