using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Cargo
    {
        public int id_ładunku { get; set; }
        public int masa_ladunku { get; set; }
        public int dlugosc { get; set; }
        public string rodzaj { get; set; }
        public bool w_trasie { get; set; }
        private int id_klienta { get; set; }
        public string klient { get; set; }

        public Cargo()
        {

        }
        public Cargo(int id_ładunku, int masa_ladunku, int dlugosc, string rodzaj, bool w_trasie, int id_klienta)
        {
            this.id_ładunku = id_ładunku;
            this.masa_ladunku = masa_ladunku;
            this.dlugosc = dlugosc;
            this.rodzaj = rodzaj;
            this.w_trasie = w_trasie;
            this.id_klienta = id_klienta;
            Connection connection = new Connection();
            connection.Connect();
            using (connection.connection)
            {
                SqlCommand command = new SqlCommand("SELECT imie, nazwisko FROM Klient WHERE id_klienta = @id_klienta", connection.connection);
                command.Parameters.AddWithValue("@id_klienta", id_klienta);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    this.klient = reader["imie"].ToString() + " " + reader["nazwisko"].ToString();
                }
            }
        }
        public List<Cargo> GetAllCargo()
        {
            Connection connection = new Connection();
            connection.Connect();
            SqlCommand command = new SqlCommand("SELECT * FROM Ładunek", connection.connection);
            SqlDataReader reader = command.ExecuteReader();
            List <Cargo> cargoList = new List<Cargo>();
            while (reader.Read())
            {
                Cargo cargo = new Cargo(Convert.ToInt32(reader["id_ładunku"]), Convert.ToInt32(reader["masa_ładunku"]), Convert.ToInt32(reader["długość"]), reader["rodzaj"].ToString(), Convert.ToBoolean(reader["w_trasie"]), Convert.ToInt32(reader["id_klienta"]));
                
                cargoList.Add(cargo);
            }
            return cargoList;
        }
        public bool AddCargo(int masa_ladunku, int dlugosc, string rodzaj)
        {
            Connection connection = new Connection();
            connection.Connect();
            using (connection.connection)
            {
                SqlCommand command = new SqlCommand("INSERT INTO Ładunek (Masa_ladunku, Dlugosc, Rodzaj) VALUES (@Masa_ladunku, @Dlugosc, @Rodzaj)", connection.connection);
                command.Parameters.AddWithValue("@Masa_ladunku", masa_ladunku);
                command.Parameters.AddWithValue("@Dlugosc", dlugosc);
                command.Parameters.AddWithValue("@Rodzaj", rodzaj);
                if (command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
        }
        public bool UpdateCargo(int id_ładunku, int masa_ladunku, int dlugosc, string rodzaj, bool w_trasie, int id_klienta)
        {
            Connection connection = new Connection();
            connection.Connect();
            using (connection.connection)
            {
                SqlCommand command = new SqlCommand("UPDATE Ładunek SET Masa_ladunku = @Masa_ladunku, Dlugosc = @Dlugosc, Rodzaj = @Rodzaj, W_trasie = @W_trasie, Id_klienta = @Id_klienta WHERE Id_ładunku = @Id_ładunku", connection.connection);
                command.Parameters.AddWithValue("@Id_ładunku", id_ładunku);
                command.Parameters.AddWithValue("@Masa_ladunku", masa_ladunku);
                command.Parameters.AddWithValue("@Dlugosc", dlugosc);
                command.Parameters.AddWithValue("@Rodzaj", rodzaj);
                command.Parameters.AddWithValue("@W_trasie", w_trasie);
                command.Parameters.AddWithValue("@Id_klienta", id_klienta);
                if (command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool DeleteCargo(int id_ładunku)
        {
            Connection connection = new Connection();
            connection.Connect();
            using (connection.connection)
            {
                SqlCommand command = new SqlCommand("DELETE FROM Ładunek WHERE Id_ładunku = @Id_ładunku", connection.connection);
                command.Parameters.AddWithValue("@Id_ładunku", id_ładunku);
                if (command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
    
}
