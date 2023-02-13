using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1.Models
{
    public class Przyczepa
    {
        public int id_przyczepy { get; set; }
        public string nr_rejestracyjny { get; set; }
        public int ładowność { get; set; }
        public int wysokość { get; set; }
        public int długość { get; set; }
        private int id_pojazdu { get; set; }
        public string nr_polisy { get; set; }
        public bool w_trasie { get; set; }
        public string pojazd { get; set; }

        public Przyczepa()
        {

        }
        public Przyczepa(int id_przyczepy, string nr_rejestracyjny, int ładowność, int wysokość, int długość, int id_pojazdu, string nr_polisy, bool w_trasie)
        {
            this.id_przyczepy = id_przyczepy;
            this.nr_rejestracyjny = nr_rejestracyjny;
            this.ładowność = ładowność;
            this.wysokość = wysokość;
            this.długość = długość;
            this.id_pojazdu = id_pojazdu;
            this.nr_polisy = nr_polisy;
            this.w_trasie = w_trasie;
            Connection connection = new Connection();

            connection.Connect();
            SqlCommand sqlCommand = new SqlCommand("SELECT marka,model,nr_rejestracyjny FROM Pojazd WHERE id_pojazdu = @id_pojazdu", connection.connection);
            sqlCommand.Parameters.AddWithValue("@id_pojazdu", id_pojazdu);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                this.pojazd = sqlDataReader["marka"]+" " + sqlDataReader["model"] +" "+sqlDataReader["nr_rejestracyjny"].ToString();
            }
        }
        public List<Przyczepa> GetAllPrzyczepy()
        {
            Connection connection = new Connection();
            connection.Connect();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Przyczepa", connection.connection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Przyczepa> przyczepaList = new List<Przyczepa>();
            while (sqlDataReader.Read())
            {
                Przyczepa przyczepa = new Przyczepa(Convert.ToInt32(sqlDataReader["id_przyczepy"]), sqlDataReader["nr_rejestracyjny"].ToString(), Convert.ToInt32(sqlDataReader["ładowność"]), Convert.ToInt32(sqlDataReader["wysokość"]), Convert.ToInt32(sqlDataReader["długość"]), Convert.ToInt32(sqlDataReader["id_pojazdu"]), sqlDataReader["nr_polisy"].ToString(), Convert.ToBoolean(sqlDataReader["w_trasie"]));
                przyczepaList.Add(przyczepa);
            }
            return przyczepaList;
        }
        public Przyczepa GetPrzyczepaByID(int id_przyczepy)
        {
            Connection connection = new Connection();
            connection.Connect();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Przyczepa WHERE id_przyczepy = @id_przyczepy", connection.connection);
            sqlCommand.Parameters.AddWithValue("@id_przyczepy", id_przyczepy);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            Przyczepa przyczepa = new Przyczepa();
            while (sqlDataReader.Read())
            {
                przyczepa = new Przyczepa(Convert.ToInt32(sqlDataReader["id_przyczepy"]), sqlDataReader["nr_rejestracyjny"].ToString(), Convert.ToInt32(sqlDataReader["ładowność"]), Convert.ToInt32(sqlDataReader["wysokość"]), Convert.ToInt32(sqlDataReader["długość"]), Convert.ToInt32(sqlDataReader["id_pojazdu"]), sqlDataReader["nr_polisy"].ToString(), Convert.ToBoolean(sqlDataReader["w_trasie"]));
            }
            return przyczepa;
        }
        public List<Przyczepa> GetAllPrzyczepyWolne()
        {
            Connection connection = new Connection();
            connection.Connect();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Przyczepa WHERE id_pojazdu IS NULL", connection.connection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Przyczepa> przyczepaList = new List<Przyczepa>();
            while (sqlDataReader.Read())
            {
                Przyczepa przyczepa = new Przyczepa(Convert.ToInt32(sqlDataReader["id_przyczepy"]), sqlDataReader["nr_rejestracyjny"].ToString(), Convert.ToInt32(sqlDataReader["ładowność"]), Convert.ToInt32(sqlDataReader["wysokość"]), Convert.ToInt32(sqlDataReader["długość"]), Convert.ToInt32(sqlDataReader["id_pojazdu"]), sqlDataReader["nr_polisy"].ToString(), Convert.ToBoolean(sqlDataReader["w_trasie"]));
                przyczepaList.Add(przyczepa);
            }
            return przyczepaList;
        }
    }
}
