using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Models
{
    public class Departures
    {
        private int Id_trasy { get; set; }
        public string Miejsce_załadunku { get; set; }
        public string Miejsca_rozładunku { get; set; }
        public int Długość_trasy { get; set; }
        private int Id_klient { get; set; }
        private int Id_kierowcy { get; set; }
        private int Id_pojazdu { get; set; }
        private int Id_ładunku { get; set; }
        private int Id_przyczepy { get; set; }
        public bool Wykonana { get; set; }
        public string Nazwa_klient { get; set; }
        public string Nazwa_kierowcy { get; set; }
        public string Nazwa_pojazdu { get; set; }
        public string Nazwa_ładunku { get; set; }
        public string Nazwa_przyczepy { get; set; }
        public Departures()
        {

        }
        public Departures(int id_trasy, string miejsce_załadunku, string miejsca_rozładunku, int długość_trasy, int id_klient, int id_kierowcy, int id_pojazdu, int id_ładunku, int id_przyczepy, bool wykonana)
        {
            Id_trasy = id_trasy;
            Miejsce_załadunku = miejsce_załadunku;
            Miejsca_rozładunku = miejsca_rozładunku;
            Długość_trasy = długość_trasy;
            Id_klient = id_klient;
            Id_kierowcy = id_kierowcy;
            Id_pojazdu = id_pojazdu;
            Id_ładunku = id_ładunku;
            Id_przyczepy = id_przyczepy;
            Wykonana = wykonana;
            Connection connection = new Connection();
            connection.Connect();
            using (connection.connection)
            {
                SqlCommand command = new SqlCommand("SELECT Imie, Nazwisko, Miasto, Nip FROM Klient WHERE Id_klienta = @id_klient", connection.connection);
                command.Parameters.AddWithValue("@id_klient", Id_klient);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Nazwa_klient = reader["Imie"].ToString() + " " + reader["Nazwisko"].ToString() + "" + reader["Miasto"].ToString() + "" + reader["Nip"].ToString();
                }
                reader.Close();
                command = new SqlCommand("SELECT Imie, Nazwisko, Pesel FROM Kierowca WHERE Id_kierowcy = @id_kierowcy", connection.connection);
                command.Parameters.AddWithValue("@id_kierowcy", Id_kierowcy);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Nazwa_kierowcy = reader["Imie"].ToString() + " " + reader["Nazwisko"].ToString() + " " + reader["Pesel"].ToString();
                }
                reader.Close();
                command = new SqlCommand("SELECT Model,Marka,nr_rejestracyjny FROM Pojazd WHERE Id_pojazdu = @id_pojazdu", connection.connection);
                command.Parameters.AddWithValue("@id_pojazdu", Id_pojazdu);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Nazwa_pojazdu = reader["Model"].ToString() + " " + reader["Marka"].ToString() + " " + reader["nr_rejestracyjny"].ToString();
                }
                reader.Close();
                command = new SqlCommand("SELECT Rodzaj FROM Ładunek WHERE Id_ładunku = @id_ładunku", connection.connection);
                command.Parameters.AddWithValue("@id_ładunku", Id_ładunku);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Nazwa_ładunku = reader["Rodzaj"].ToString();
                }
                reader.Close();
                command = new SqlCommand("SELECT nr_rejestracyjny FROM Przyczepa WHERE Id_przyczepy = @id_przyczepy", connection.connection);
                command.Parameters.AddWithValue("@id_przyczepy", Id_przyczepy);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Nazwa_przyczepy = reader["nr_rejestracyjny"].ToString();
                }
                reader.Close();
            }

        }




        public List<Departures> GetTrasy()
        {

            Connection connection = new Connection();
            connection.Connect();
            using (var command = connection.connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Trasa";
                List<Departures> departures = new List<Departures>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        departures.Add(new Departures((int)reader["id_trasy"], reader["miejsce_załadunku"].ToString(), reader["miejsca_rozładunku"].ToString(), (int)reader["długość_trasy"], (int)reader["id_klient"], (int)reader["id_kierowcy"], (int)reader["id_pojazdu"], (int)reader["id_ładunku"], (int)reader["id_przyczepy"], (bool)reader["wykonana"]));
                    }
                    return departures;
                }


            }

        }

        public bool AddNewDeparture(string miejsce_załadunku, string miejsca_rozładunku, int długość_trasy, int id_klient, int id_kierowcy, int id_pojazdu, int id_ładunku, int id_przyczepy, bool wykonana)
        {
            Connection connection = new Connection();
            connection.Connect();
            using (var command = connection.connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO trasa (miejsce_załadunku, miejsca_rozładunku, długość_trasy, id_klient, id_kierowcy, id_pojazdu, id_ładunku, id_przyczepy, wykonana) VALUES (@id_trasy, @miejsce_załadunku, @miejsca_rozładunku, @długość_trasy, @id_klient, @id_kierowcy, @id_pojazdu, @id_ładunku, @id_przyczepy, @wykonana)";

                command.Parameters.AddWithValue("@miejsce_załadunku", miejsce_załadunku);
                command.Parameters.AddWithValue("@miejsca_rozładunku", miejsca_rozładunku);
                command.Parameters.AddWithValue("@długość_trasy", długość_trasy);
                command.Parameters.AddWithValue("@id_klient", id_klient);
                command.Parameters.AddWithValue("@id_kierowcy", id_kierowcy);
                command.Parameters.AddWithValue("@id_pojazdu", id_pojazdu);
                command.Parameters.AddWithValue("@id_ładunku", id_ładunku);
                command.Parameters.AddWithValue("@id_przyczepy", id_przyczepy);
                command.Parameters.AddWithValue("@wykonana", wykonana);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Dodano nową trasę");
                    return true;
                }
                else
                {
                    MessageBox.Show("Nie udało się dodać nowej trasy");
                    return false;
                }
            }
        }

        public bool EditDeparture(string Miejsce_załadunku, string Miejsca_rozładunku, int Długość_trasy, int Id_klient, int Id_kierowcy, int Id_pojazdu, int Id_ładunku, int Id_przyczepy, bool Wykonana)
        {
            Connection connection = new Connection();
            connection.Connect();
            using (var command = connection.connection.CreateCommand())
            {
                command.CommandText = "UPDATE trasa SET Miejsce_załadunku = @Miejsce_załadunku, Miejsca_rozładunku = @Miejsca_rozładunku, Długość_trasy = @Długość_trasy, Id_klient = @Id_klient, Id_kierowcy = @Id_kierowcy, Id_pojazdu = @Id_pojazdu, Id_ładunku = @Id_ładunku, Id_przyczepy = @Id_przyczepy, Wykonana = @Wykonana WHERE Id_trasy = @Id_trasy";

                command.Parameters.AddWithValue("@Miejsce_załadunku", Miejsce_załadunku);
                command.Parameters.AddWithValue("@Miejsca_rozładunku", Miejsca_rozładunku);
                command.Parameters.AddWithValue("@Długość_trasy", Długość_trasy);
                command.Parameters.AddWithValue("@Id_klient", Id_klient);
                command.Parameters.AddWithValue("@Id_kierowcy", Id_kierowcy);
                command.Parameters.AddWithValue("@Id_pojazdu", Id_pojazdu);
                command.Parameters.AddWithValue("@Id_ładunku", Id_ładunku);
                command.Parameters.AddWithValue("@Id_przyczepy", Id_przyczepy);
                command.Parameters.AddWithValue("@Wykonana", Wykonana);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Edytowano trasę");
                    return true;
                }
                else
                {
                    MessageBox.Show("Nie udało się edytować trasy");
                    return false;
                }
            }
        }
        public bool DeleteDeparture(int id)
        {
            Connection connection = new Connection();
            connection.Connect();
            using (var command = connection.connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM trasa WHERE Id = @id";
                command.Parameters.AddWithValue("@Id", id);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Usunięto trase");
                    return true;
                }
                else
                {
                    MessageBox.Show("Nie udało się usunąć trasy");
                    return false;
                }

            }
        }
    }

}