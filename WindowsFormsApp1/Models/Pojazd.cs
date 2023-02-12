﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace WindowsFormsApp1.Models
{
    public class Pojazd
    {
        private int id_pojazdu { get; set; }
        public string marka { get; set; }
        public string model { get; set; }
        public string nr_rejestracyjny { get; set; }
        public string nr_vin { get; set; }
        public DateTime rok_produkcji { get; set; }
        public int przebieg { get; set; }
        public string rodzaj_pojazdu { get; set; }
        public string emisja_spalin { get; set; }
        public string nr_polisy { get; set; }
        public int id_przyczepy { get; set; }
        public bool w_trasie { get; set; }
        
        public Pojazd()
        {
            
        }
        public Pojazd(int id_pojazdu, string marka, string model, string nr_rejestracyjny, string nr_vin, DateTime rok_produkcji, int przebieg, string rodzaj_pojazdu, string emisja_spalin, string nr_polisy, int id_przyczepy, bool w_trasie)
        {
            this.id_pojazdu = id_pojazdu;
            this.marka = marka;
            this.model = model;
            this.nr_rejestracyjny = nr_rejestracyjny;
            this.nr_vin = nr_vin;
            this.rok_produkcji = rok_produkcji;
            this.przebieg = przebieg;
            this.rodzaj_pojazdu = rodzaj_pojazdu;
            this.emisja_spalin = emisja_spalin;
            this.nr_polisy = nr_polisy;
            this.id_przyczepy = id_przyczepy;
            this.w_trasie = w_trasie;
        }

        public List<Pojazd> GetAllPojazdy()
        {
            Connection connection = new Connection();
            connection.Connect();
            SqlCommand command = new SqlCommand("SELECT * FROM Pojazd", connection.connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Pojazd> pojazdList = new List<Pojazd>();
            while (reader.Read())
            {
                Pojazd pojazd = new Pojazd(Convert.ToInt32(reader["id_pojazdu"]), reader["marka"].ToString(), reader["model"].ToString(), reader["nr_rejestracyjny"].ToString(), reader["nr_vin"].ToString(), Convert.ToDateTime(reader["rok_produkcji"]), Convert.ToInt32(reader["przebieg"]), reader["rodzaj_pojazdu"].ToString(), reader["emisja_spalin"].ToString(), reader["nr_polisy"].ToString(), Convert.ToInt32(reader["id_przyczepy"]), Convert.ToBoolean(reader["w_trasie"]));
                pojazdList.Add(pojazd);
            }
            return pojazdList;
        }
    }
}