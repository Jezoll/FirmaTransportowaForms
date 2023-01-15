using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class CargoClass
    {
        public int masa_ladunku { get; set; }
        public int dlugosc { get; set; }
        public string rodzaj { get; set; }
        
        public List<CargoClass> GetAllCargo()
        {
            Connection connection = new Connection();
            connection.Connect();
            SqlCommand command = new SqlCommand("SELECT * FROM Ładunek", connection.connection);
            SqlDataReader reader = command.ExecuteReader();
            List <CargoClass> cargoList = new List<CargoClass>();
            while (reader.Read())
            {
                CargoClass cargo = new CargoClass();
                cargo.masa_ladunku = reader.GetInt32(1);
                cargo.dlugosc = reader.GetInt32(2);
                cargo.rodzaj = reader.GetString(3);
                cargoList.Add(cargo);
            }
            return cargoList;
        }

    }
    
}
