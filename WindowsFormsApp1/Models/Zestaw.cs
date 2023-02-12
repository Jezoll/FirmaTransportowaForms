using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace WindowsFormsApp1.Models
{
    public class Zestaw
    {
        private int id_zestawu { get; set; }
        private int id_pojazdu { get; set; }
        private int id_przyczepy { get; set; }
        public string pojazd { get; set; }
        public string przyczepa { get; set; }
        public Zestaw()
        {
        }
        public Zestaw(int id_zestawu, int id_pojazdu, int id_przyczepy)
        {
            this.id_zestawu = id_zestawu;
            this.id_pojazdu = id_pojazdu;
            this.id_przyczepy = id_przyczepy;
            Connection connection = new Connection();
            connection.Connect();
            using (connection.connection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Pojazd WHERE id_pojazdu = @id_pojazdu", connection.connection);
                command.Parameters.AddWithValue("@id_pojazdu", id_pojazdu);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    pojazd = reader["marka"].ToString() + " " + reader["model"].ToString();
                }
                reader.Close();
                command = new SqlCommand("SELECT * FROM Przyczepa WHERE id_przyczepy = @id_przyczepy", connection.connection);
                command.Parameters.AddWithValue("@id_przyczepy", id_przyczepy);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    przyczepa = reader["nr_rejestracyjny"].ToString();
                }
                reader.Close();
            }
        }
        public List<Zestaw> GetAllZestawy()
        {
            List<Zestaw> zestawy = new List<Zestaw>();
            Connection connection = new Connection();
            connection.Connect();
            using (connection.connection)
            {
                string query = "SELECT * FROM Zestaw";
                SqlCommand command = new SqlCommand(query, connection.connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Zestaw zestaw = new Zestaw(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));
                    
                    zestawy.Add(zestaw);
                }
            }
            return zestawy;
        }
    }
}
