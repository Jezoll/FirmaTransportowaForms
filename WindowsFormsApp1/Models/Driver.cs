using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;


namespace WindowsFormsApp1
{
    public class Driver
    {
        [System.ComponentModel.DisplayName("Imię")]
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        [System.ComponentModel.DisplayName("Data urodzenia")]
        public DateTime Data_ur { get; set; }
        public string Pesel { get; set; }
        [System.ComponentModel.DisplayName("Kod pocztowy")]
        public string Kod_pocztowy { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }
        [System.ComponentModel.DisplayName("Numer domu")]
        public string Numer_domu { get; set; }
        [System.ComponentModel.DisplayName("Numer lokalu")]
        public string Numer_mieszkania { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        private Validation validation;

        public Driver()
        {
            validation = new Validation();

        }

        public Driver(string imie, string nazwisko, DateTime data_ur, string pesel, string kod_pocztowy, string miasto, string ulica, string numer_domu, string numer_mieszkania, string telefon, string email)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Data_ur = data_ur;
            Pesel = pesel;
            Kod_pocztowy = kod_pocztowy;
            Miasto = miasto;
            Ulica = ulica;
            Numer_domu = numer_domu;
            Numer_mieszkania = numer_mieszkania;
            Telefon = telefon;
            Email = email;
        }
        public List<Driver> GetAllDrivers()
        {
            Connection connection = new Connection();
            connection.Connect();
            using (var command = connection.connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM kierowca";
                using (var reader = command.ExecuteReader())
                {
                    List<Driver> drivers = new List<Driver>();
                    while (reader.Read())
                    {
                        drivers.Add(new Driver(reader["Imie"].ToString(), reader["Nazwisko"].ToString(),
                        DateTime.Parse(reader["Data_ur"].ToString()), reader["Pesel"].ToString(),
                        reader["Kod_pocztowy"].ToString(), reader["Miasto"].ToString(), reader["Ulica"].ToString(),
                        reader["nr_domu"].ToString(), reader["nr_lokalu"].ToString(), reader["Telefon"].ToString(),
                        reader["mail"].ToString()));
                        
                    }
                    return drivers;
                }
            }
            
        }
        public bool AddNewDriver(string Imie, string Nazwisko, DateTime Data_ur, string Pesel, string Kod_pocztowy, string Miasto, string Ulica, string Numer_domu, string Numer_mieszkania, string Telefon, string Email)
        {
            Connection connection = new Connection();
            connection.Connect();
            using (var command = connection.connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO kierowca (Imie, Nazwisko, Data_ur, Pesel, Kod_pocztowy, Miasto, Ulica, nr_domu, nr_lokalu, Telefon, mail) VALUES (@Imie, @Nazwisko, @Data_ur, @Pesel, @Kod_pocztowy, @Miasto, @Ulica, @Numer_domu, @Numer_mieszkania, @Telefon, @Email)";
                command.Parameters.AddWithValue("@Imie", Imie);
                command.Parameters.AddWithValue("@Nazwisko", Nazwisko);
                command.Parameters.AddWithValue("@Data_ur", Data_ur);
                command.Parameters.AddWithValue("@Pesel", Pesel);
                command.Parameters.AddWithValue("@Kod_pocztowy", Kod_pocztowy);
                command.Parameters.AddWithValue("@Miasto", Miasto);
                command.Parameters.AddWithValue("@Ulica", Ulica);
                command.Parameters.AddWithValue("@Numer_domu", Numer_domu);
                command.Parameters.AddWithValue("@Numer_mieszkania", Numer_mieszkania);
                command.Parameters.AddWithValue("@Telefon", Telefon);
                command.Parameters.AddWithValue("@Email", Email);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Dodano nowego kierowcę");
                    return true;

                }
                else
                {
                    MessageBox.Show("Nie udało się dodać nowego kierowcy");
                    return false;
                }
            }
        }
        public bool UpdateDriver(string Imie, string Nazwisko, DateTime Data_ur, string Pesel, string Kod_pocztowy, string Miasto, string Ulica, string Numer_domu, string Numer_mieszkania, string Telefon, string Email)
        {
            Connection connection = new Connection();
            connection.Connect();
            using (var command = connection.connection.CreateCommand())
            {
                command.CommandText = "UPDATE kierowca SET Imie = @Imie, Nazwisko = @Nazwisko, Data_ur = @Data_ur, Pesel = @Pesel, Kod_pocztowy = @Kod_pocztowy, Miasto = @Miasto, Ulica = @Ulica, nr_domu = @Numer_domu, nr_lokalu = @Numer_mieszkania, Telefon = @Telefon, mail = @Email WHERE Pesel = @Pesel";
                command.Parameters.AddWithValue("@Imie", Imie);
                command.Parameters.AddWithValue("@Nazwisko", Nazwisko);
                command.Parameters.AddWithValue("@Data_ur", Data_ur);
                command.Parameters.AddWithValue("@Pesel", Pesel);
                command.Parameters.AddWithValue("@Kod_pocztowy", Kod_pocztowy);
                command.Parameters.AddWithValue("@Miasto", Miasto);
                command.Parameters.AddWithValue("@Ulica", Ulica);
                command.Parameters.AddWithValue("@Numer_domu", Numer_domu);
                command.Parameters.AddWithValue("@Numer_mieszkania", Numer_mieszkania);
                command.Parameters.AddWithValue("@Telefon", Telefon);
                command.Parameters.AddWithValue("@Email", Email);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Zaktualizowano dane kierowcy");
                    return true;
                }
                else
                {
                    MessageBox.Show("Nie udało się zaktualizować danych kierowcy");
                    return false;
                }
                
            }
        }
        public bool DeleteDriver(string Pesel)
        {
            Connection connection = new Connection();
            connection.Connect();
            using (var command = connection.connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM kierowca WHERE Pesel = @Pesel";
                command.Parameters.AddWithValue("@Pesel", Pesel);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Usunięto kierowcę");
                    return true;
                }
                else
                {
                    MessageBox.Show("Nie udało się usunąć kierowcy");
                    return false;
                }
                
            }
        }

        
    }
    
}
