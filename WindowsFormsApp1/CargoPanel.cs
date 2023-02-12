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
            Cargo cargo = new Cargo();
            dataGridView1.DataSource = cargo.GetAllCargo();
        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu form1 = new Menu();
            form1.ShowDialog();
        }
    }
}
