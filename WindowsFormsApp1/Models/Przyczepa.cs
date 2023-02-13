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
        private int? id_pojazdu { get; set; }
        public string nr_polisy { get; set; }
        public bool w_trasie { get; set; }
        public string pojazd { get; set; }

        public Przyczepa()
        {

        }
        public Przyczepa(int id_przyczepy, string nr_rejestracyjny, int ładowność, int wysokość, int długość, int? id_pojazdu, string nr_polisy, bool w_trasie)
        {
            if(id_pojazdu == null)
            {
                id_pojazdu = null;
            }
            else
            {
                Connection connection = new Connection();

                connection.Connect();
                SqlCommand sqlCommand = new SqlCommand("SELECT marka,model,nr_rejestracyjny FROM Pojazd WHERE id_pojazdu = @id_pojazdu", connection.connection);
                sqlCommand.Parameters.AddWithValue("@id_pojazdu", id_pojazdu);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    this.pojazd = sqlDataReader["marka"] + " " + sqlDataReader["model"] + " " + sqlDataReader["nr_rejestracyjny"].ToString();
                }
            }
            this.id_przyczepy = id_przyczepy;
            this.nr_rejestracyjny = nr_rejestracyjny;
            this.ładowność = ładowność;
            this.wysokość = wysokość;
            this.długość = długość;
            this.id_pojazdu = id_pojazdu;
            this.nr_polisy = nr_polisy;
            this.w_trasie = w_trasie;
            
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
                Przyczepa przyczepa = new Przyczepa(Convert.ToInt32(sqlDataReader["id_przyczepy"]), sqlDataReader["nr_rejestracyjny"].ToString(),
                    Convert.ToInt32(sqlDataReader["ładowność"]), Convert.ToInt32(sqlDataReader["wysokość"]),
                    Convert.ToInt32(sqlDataReader["długość"]), (int?)sqlDataReader["id_pojazdu"], sqlDataReader["nr_polisy"].ToString(),
                    Convert.ToBoolean(sqlDataReader["w_trasie"]));
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
                //if (id_pojazdu == null)
                //{
                //    id_pojazdu = null;
                //}
                //else
                //{

                //    id_pojazdu = Convert.ToInt32(sqlDataReader["id_pojazdu"]);

                //}
                    przyczepa = new Przyczepa(Convert.ToInt32(sqlDataReader["id_przyczepy"]), sqlDataReader["nr_rejestracyjny"].ToString(),
                    Convert.ToInt32(sqlDataReader["ładowność"]), Convert.ToInt32(sqlDataReader["wysokość"]), 
                    Convert.ToInt32(sqlDataReader["długość"]), (int?)sqlDataReader["id_pojazdu"], sqlDataReader["nr_polisy"].ToString(),
                    Convert.ToBoolean(sqlDataReader["w_trasie"]));
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
            while (sqlDataReader.Read()) { 
                if (id_pojazdu == null)
                {
                    id_pojazdu = null;
                }
                else
                {
                    id_pojazdu = Convert.ToInt32(sqlDataReader["id_pojazdu"]);
                }
                Przyczepa przyczepa = new Przyczepa(Convert.ToInt32(sqlDataReader["id_przyczepy"]), sqlDataReader["nr_rejestracyjny"].ToString(),
                    Convert.ToInt32(sqlDataReader["ładowność"]), Convert.ToInt32(sqlDataReader["wysokość"]),
                    Convert.ToInt32(sqlDataReader["długość"]), id_pojazdu, sqlDataReader["nr_polisy"].ToString(),
                    Convert.ToBoolean(sqlDataReader["w_trasie"]));


                przyczepaList.Add(przyczepa);
            }
            return przyczepaList;
        }
        public bool AddPrzyczepa(Przyczepa przyczepa)
        {
            Connection connection = new Connection();
            connection.Connect();
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Przyczepa(nr_rejestracyjny,ładowność,wysokość,długość,id_pojazdu,nr_polisy,w_trasie) VALUES(@nr_rejestracyjny,@ładowność,@wysokość,@długość,@id_pojazdu,@nr_polisy,@w_trasie)", connection.connection);
            sqlCommand.Parameters.AddWithValue("@nr_rejestracyjny", przyczepa.nr_rejestracyjny);
            sqlCommand.Parameters.AddWithValue("@ładowność", przyczepa.ładowność);
            sqlCommand.Parameters.AddWithValue("@wysokość", przyczepa.wysokość);
            sqlCommand.Parameters.AddWithValue("@długość", przyczepa.długość);
            sqlCommand.Parameters.AddWithValue("@id_pojazdu", przyczepa.id_pojazdu);
            sqlCommand.Parameters.AddWithValue("@nr_polisy", przyczepa.nr_polisy);
            sqlCommand.Parameters.AddWithValue("@w_trasie", przyczepa.w_trasie);
            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
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
