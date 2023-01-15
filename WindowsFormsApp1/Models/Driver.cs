using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public class Driver
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime Data_ur { get; set; }
        public string Pesel { get; set; }
        public string Kod_pocztowy { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }
        public string Numer_domu { get; set; }
        public string Numer_mieszkania { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }

        public Driver()
        {
            
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
        public List<string> GetAllDrivers()
        {
            Connection connection = new Connection();
            connection.Connect();
            using (var command = connection.connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM kierowca";
                using (var reader = command.ExecuteReader())
                {
                    List<string> drivers = new List<string>();
                    while (reader.Read())
                    {
                        drivers.Add(reader.GetString(1));
                        drivers.Add(reader.GetString(2));
                        drivers.Add(reader.GetDateTime(3).ToShortDateString());
                        drivers.Add(reader.GetString(4));
                        drivers.Add(reader.GetString(5));
                        drivers.Add(reader.GetString(6));
                        drivers.Add(reader.GetString(7));
                        drivers.Add(reader.GetString(8));
                        drivers.Add(reader.GetString(9));
                        drivers.Add(reader.GetString(10));
                        drivers.Add(reader.GetString(11));
                    }
                    return drivers;
                }
            }
            
        }
    }
    
}
