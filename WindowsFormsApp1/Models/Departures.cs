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
        private int id_trasy;
        public string miejsce_załadunku;
        public string miejsca_rozładunku;
        public int długość_trasy;
        private int id_klient;
        private int id_kierowcy;
        private int id_pojazdu;
        private int id_ładunku;
        private int id_przyczepy;
        public bool wykonana;
        
        public List<Departures> GetTrasy(){
            
            Connection connection = new Connection();
            connection.Connect();

            using (connection.connection)
            {
                List<Departures> departures = new List<Departures>();

                SqlCommand command = new SqlCommand("SELECT * FROM Trasa", connection.connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Departures departure = new Departures();
                    departure.id_trasy = reader.GetInt32(0);
                    departure.miejsce_załadunku = reader.GetString(1);
                    departure.miejsca_rozładunku = reader.GetString(2);
                    departure.długość_trasy = reader.GetInt32(3);
                    departure.id_klient = reader.GetInt32(4);
                    departure.id_kierowcy = reader.GetInt32(5);
                    departure.id_pojazdu = reader.GetInt32(6);
                    departure.id_ładunku = reader.GetInt32(7);
                    departure.id_przyczepy = reader.GetInt32(8);
                    departure.wykonana = reader.GetBoolean(9);
                    departures.Add(departure);

                }
                return departures;
            }
            
        }
        }
}
