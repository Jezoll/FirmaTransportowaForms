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
            GetAllPrzyczepy();
            GetAllZestawy();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.ReadOnly = true;
            dataGridView2.MultiSelect = false;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.ReadOnly = true;
            dataGridView3.MultiSelect = false;
            dataGridView3.AllowUserToResizeColumns = false;
            dataGridView3.AllowUserToResizeRows = false;
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
            vehicles = vehicle.GetAllPojazdyWolne();

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
        private void GetAllPrzyczepy()
        {
            List<Przyczepa> przyczepy = new List<Przyczepa>();

            Przyczepa przyczepa = new Przyczepa();
            przyczepy = przyczepa.GetAllPrzyczepyWolne();

            dataGridView2.DataSource = przyczepy;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = null;
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            GetAllZestawy();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = null;
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = "pojazd";
            column.Name = "pojazd";
            dataGridView3.Columns.Add(column);
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "przyczepa";
            column2.Name = "przyczepa";
            dataGridView3.Columns.Add(column2);
            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            column3.HeaderText = "id_po";
            column3.Name = "id_po";
            dataGridView3.Columns.Add(column3);
            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
            column4.HeaderText = "id_przy";
            column4.Name = "id_przy";
            dataGridView3.Columns.Add(column4);
            dataGridView3.Columns[2].Visible = false;
            dataGridView3.Columns[3].Visible = false;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pojazd pojazd = new Pojazd();
            int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                dataGridView3.Rows[i].Cells[0].Value = pojazd.GetPojazdByID(id).marka + " " + pojazd.GetPojazdByID(id).model;
                dataGridView3.Rows[i].Cells[2].Value = id;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Przyczepa przyczepa = new Przyczepa();
            int id = (int)dataGridView2.SelectedRows[0].Cells[0].Value;
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                dataGridView3.Rows[i].Cells[1].Value = przyczepa.GetPrzyczepaByID(id).nr_rejestracyjny;
                dataGridView3.Rows[i].Cells[3].Value = id;

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu mainMenu = new Menu();
            mainMenu.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Zestaw zestaw = new Zestaw();
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                zestaw.AddZestaw((int)dataGridView3.Rows[i].Cells[2].Value,(int)dataGridView3.Rows[i].Cells[3].Value);
                

            }
        }
    }
}
