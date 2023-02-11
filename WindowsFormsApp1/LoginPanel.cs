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
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class LoginPanel : Form
    {
        public LoginPanel()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User();
            if(user.LogIn(textBox1.Text, textBox2.Text) == true)
            {
                this.Hide();
                Menu form4 = new Menu();
                form4.ShowDialog();
            }
            else
            {
                MessageBox.Show("Błędne dane!");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            User user = new User();
            if (user.LogInAsAdmin(textBox1.Text, textBox2.Text) == true)
            {
                this.Hide();
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.ShowDialog();
            }
            else
            {
                MessageBox.Show("Błędne dane!");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            CargoPanel cargo = new CargoPanel();
            cargo.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
