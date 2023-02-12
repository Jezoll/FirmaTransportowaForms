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
    public partial class VehiclesPrzyczepaZestawyForm : Form
    {
        public VehiclesPrzyczepaZestawyForm()
        {
            InitializeComponent();
            GetAllPojazdy();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void GetAllPojazdy()
        {
            List<Pojazd> vehicles = new List<Pojazd>();

            Pojazd vehicle = new Pojazd();
            vehicles = vehicle.GetAllPojazdy();

            dataGridView1.DataSource = vehicles;
        }
        private void GetAllZestawy()
        {
            List<Zestaw> zestawy = new List<Zestaw>();

            Zestaw zestaw = new Zestaw();
            zestawy = zestaw.GetAllZestawy();

            dataGridView3.DataSource = zestawy;
            
        }
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            GetAllZestawy();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = null;
        }
    }
}
