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
    public partial class DriversPanel : Form
    {
        public DriversPanel()
        {
            InitializeComponent();
            
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
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
            AddingDriver form2 = new AddingDriver();
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

        private void button4_Click(object sender, EventArgs e)
        {
            Menu form = new Menu();
            form.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Driver driver = new Driver();
            
            List<Driver> filtr = new List<Driver>();
            foreach (Driver item in driver.GetAllDrivers())
            {
                if (item.Nazwisko.Contains(textBox1.Text))
                {
                    filtr.Add(item);
                }
                
            }
            dataGridView1.DataSource = filtr;
        }
    }
}
