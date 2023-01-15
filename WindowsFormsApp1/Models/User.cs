using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1.Models
{
    public class User
    {
        private string login;
        private string password;
        private string active;
        private string lastActivity;

        public bool LogIn(string login, string password)
        {
            Connection connection = new Connection();

            using (connection.connection)
            {
                connection.Connect();
                SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Login = @Login AND Password = @Password", connection.connection);
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", password);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Zalogowano");
                    Form1 form1 = new Form1();
                    form1.Show();
                    return true;
                }
                else
                {
                    MessageBox.Show("Niepoprawny login lub hasło");
                    return false;
                }
            }
            

        }
        public void AddNewUser()
        {
            Connection conn = new Connection();

            using (conn.connection)
            {
                Environment.MachineName.ToString();
                conn.Connect();
                string queryTest;
                queryTest = String.Format("INSERT INTO dbo.users (login, password, active, lastActivity) VALUES ('{0}', '{1}','{2}', '{3}')", textBox1.Text, textBox2.Text, 1, DateTime.Now);
                SqlCommand command = new SqlCommand(queryTest, conn.connection);

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
    }
}
