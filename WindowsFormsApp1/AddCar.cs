using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class AddCar : Form
    {
        public AddCar()
        {
            InitializeComponent();
            GetAllPrzyczepyWolne();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void GetAllPrzyczepyWolne()
        {
            List<Przyczepa> przyczepy = new List<Przyczepa>();

            Przyczepa przyczepa = new Przyczepa();
            przyczepy = przyczepa.GetAllPrzyczepyWolne();

            listBox1.DataSource = przyczepy;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pojazd pojazd = new Pojazd();
            pojazd.marka = textBox1.Text;
            pojazd.model = textBox2.Text;
            pojazd.nr_rejestracyjny = textBox3.Text;
            pojazd.nr_vin = textBox4.Text;
            pojazd.rok_produkcji = DateTime.TryParse(textBox5.Text, out DateTime result) ? result : DateTime.Now;
            pojazd.przebieg = Int32.TryParse(textBox6.Text, out int resultprzebieg) ? resultprzebieg : 0;
            pojazd.rodzaj_pojazdu = textBox7.Text;
            pojazd.emisja_spalin = textBox8.Text;
            pojazd.nr_polisy = textBox9.Text;
            pojazd.id_przyczepy = (int)listBox1.SelectedItem;


        }
    }
}
