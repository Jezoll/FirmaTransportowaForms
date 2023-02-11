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
    public partial class UpdateUser : Form
    {
        public UpdateUser(string login, string password, bool isAdmin, bool isActive)
        {
            InitializeComponent();
            textBox1.Text = login;
            textBox2.Text = password;
            if (isAdmin)
            {
                checkBox1.Checked = true;
            }
            if (isActive)
            {
                checkBox2.Checked = true;
            }
        }

        private void UpdateUser_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User();

            if (user.UpdateUser(textBox1.Text, textBox2.Text, checkBox1.Checked, checkBox2.Checked))
            {
                
                
                    this.Hide();
                    AdminPanel form2 = new AdminPanel();
                    form2.ShowDialog();
                
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
