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
    public partial class AddMember : Form
    {
        public AddMember()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var registration = new Registration();
            registration.Show();
            this.Hide();
        }
    }
}
