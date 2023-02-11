using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Departures
    {
        public int Id_trasy { get; set; }
        public string Miejsce_załadunku { get; set; }
        public string Miejsca_rozładunku { get; set; }
        public int Długość_trasy { get; set; }
        public int Id_klient { get; set; }
        public int Id_kierowcy { get; set; }
        public int Id_pojazdu { get; set; }
        public int Id_ładunku { get; set; }
        public int Id_przyczepy { get; set; }
        public bool Wykonana { get; set; }
        public List<Departures> departuresList = new List<Departures>();
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
                            departures.Add(new Departures((int)reader["id_trasy"], reader["miejsce_załadunku"].ToString(), reader["miejsca_rozładunku"].ToString(), (int)reader["długość_trasy"], (int)reader["id_klient"], (int)reader["id_kierowcy"], (int)reader["id_pojazdu"], (int)reader["id_ładunku"], (int)reader["id_przyczepy"], (bool)reader["wykonana"])) ;
                        }
                        return departures;
                    }
                   
                
            }

        }
    }   
}
