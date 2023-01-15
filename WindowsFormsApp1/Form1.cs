using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            LoadEmployees();
        }
        private void LoadEmployees()
        {
            Driver driver = new Driver();
            dataGridView1.DataSource = driver.GetAllDrivers();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Driver driver = new Driver();
            driver.DeleteDriver(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            LoadEmployees();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
