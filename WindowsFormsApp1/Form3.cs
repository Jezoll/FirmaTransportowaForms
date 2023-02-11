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
    public partial class Form3 : Form
    {
        public Form3()
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
                Form4 form4 = new Form4();
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
            user.AddNewUser(textBox1.Text, textBox2.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cargo cargo = new Cargo();
            cargo.Show();

        }
    }
}
