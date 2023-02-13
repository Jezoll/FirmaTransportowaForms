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
    public partial class CargoPanel : Form
    {
        public CargoPanel()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            
            GetAllCargo();
            dataGridView1.Columns[0].Visible = false;
        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void GetAllCargo()
        {
            Cargo cargo = new Cargo();
            dataGridView1.DataSource = cargo.GetAllCargo();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu form1 = new Menu();
            form1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ladunek = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            Cargo cargo = new Cargo();
            if (ladunek != null){
                if (MessageBox.Show("Czy chcesz usunać ten ładunek?", "Uwaga", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cargo.DeleteCargo(Convert.ToInt32(ladunek));
                    GetAllCargo();
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano ładunku do usunięcia");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
