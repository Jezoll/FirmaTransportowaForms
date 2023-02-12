using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Przyczepa
    {
        private int id_przyczepy { get; set; }
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
        }
    }
}
