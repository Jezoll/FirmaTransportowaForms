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
        public string login { get; set; }
        public string password{ get; set; }
        public bool active{ get; set; }
        public DateTime lastActivity { get; set; }
        public bool isAdmin { get; set; }

        public User()
        {
            
        }
        public User(string login, string password, bool active, DateTime lastActivity, bool isAdmin)
        {
            this.login = login;
            this.password = password;
            this.active = active;
            this.lastActivity = lastActivity;
            this.isAdmin = isAdmin;
        }

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
                    return true;
                }
                else
                {
                    MessageBox.Show("Niepoprawny login lub hasło");
                    return false;
                }
            }
            

        }
        public void AddNewUser(string login, string password, bool isAdmin)
        {
            Connection conn = new Connection();

            using (conn.connection)
            {
                Environment.MachineName.ToString();
                conn.Connect();
                string queryTest;
                queryTest = String.Format("INSERT INTO dbo.users (login, password, active, lastActivity, isAdmin) VALUES ('{0}', '{1}','{2}', '{3}', '{4}')", login, password, 1, DateTime.Now, isAdmin);
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
        public bool LogInAsAdmin(string login, string password)
        {
            Connection connection = new Connection();

            using (connection.connection)
            {
                connection.Connect();
                SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Login = @Login AND Password = @Password AND isAdmin = @isAdmin", connection.connection);
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@isAdmin", 1);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Zalogowano jako administrator");
                    return true;
                }
                else
                {
                    MessageBox.Show("Niepoprawny login lub hasło");
                    return false;
                }
            }
        }
        public List<User> GetAllUsers()
        {
            Connection connection = new Connection();
            connection.Connect();
            using (var command = connection.connection.CreateCommand())
            {
                command.CommandText = "SELECT login,password,active,lastActivity,isAdmin FROM Users";
                using (var reader = command.ExecuteReader())
                {
                    List<User> users = new List<User>();
                    while (reader.Read())
                    {
                        users.Add(new User(reader["login"].ToString(), reader["password"].ToString(), Convert.ToBoolean(reader["active"]), Convert.ToDateTime(reader["lastActivity"]), Convert.ToBoolean(reader["isAdmin"])));
                    }
                    return users;
                }
            }
            //using (connection.connection)
            //{
            //    List<User> users = new List<User>();

            //    SqlCommand command = new SqlCommand("SELECT login,password,active,lastActivity,isAdmin FROM users", connection.connection);
            //    SqlDataReader reader = command.ExecuteReader();
            //    while (reader.Read())
            //    {

            //        users.Add(new User(reader["login"].ToString(), reader["password"].ToString(), Convert.ToBoolean(reader["active"]), Convert.ToDateTime(reader["lastActivity"]), Convert.ToBoolean(reader["isAdmin"])));

            //    }
            //    return users;
            //}
        }
        public void DeleteUser(string login)
        {
            Connection connection = new Connection();
            connection.Connect();
            using (var command = connection.connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Users WHERE login = @login";
                command.Parameters.AddWithValue("@login", login);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Usunięto użytkownika");
                }
                else
                {
                    MessageBox.Show("Nie usunięto użytkownika");
                }
            }
        }
        public bool UpdateUser(string login, string password, bool active, bool isAdmin)
        {
            Connection connection = new Connection();
            connection.Connect();
            using (var command = connection.connection.CreateCommand())
            {
                command.CommandText = "UPDATE Users SET password = @password, active = @active, isAdmin = @isAdmin WHERE login = @login";
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@active", active);
                command.Parameters.AddWithValue("@isAdmin", isAdmin);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Zaktualizowano użytkownika");
                    return true;
                }
                else
                {
                    MessageBox.Show("Nie zaktualizowano użytkownika");
                    return false;
                }
            }
        }
    }
}
