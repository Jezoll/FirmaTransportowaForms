using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class UserAdding : Form
    {
        public UserAdding()
        {
            InitializeComponent();
        }

        private void UserAdding_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User();
            bool isAdmin = false;
            if (checkBox1.Checked)
            {
                isAdmin = true;
            }
            user.AddNewUser(textBox1.Text, textBox2.Text, isAdmin);
        }
    }
}
