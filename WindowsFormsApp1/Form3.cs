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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.LogIn(textBox1.Text, textBox2.Text);
            
        }
       
        private void AddNewUser()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=DESKTOP-MS2A1CD;Database=Firma_Transportowa;Trusted_Connection=true";
            using (SqlConnection conn = new SqlConnection(connection.ConnectionString))
            {
                Environment.MachineName.ToString();
                conn.Open();
                string queryTest;
                queryTest = String.Format("INSERT INTO dbo.users (login, password, active, lastActivity) VALUES ('{0}', '{1}','{2}', '{3}')", textBox1.Text, textBox2.Text,1,DateTime.Now);
                SqlCommand command = new SqlCommand(queryTest, conn);
                
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Dodano użytkownika");
                }
                else
                {
                    MessageBox.Show("Nie dodano użytkownika");
                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddNewUser();
        }
    }
}
