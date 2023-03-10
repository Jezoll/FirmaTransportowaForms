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
    public partial class DeparturesPanel : Form
    {
        public DeparturesPanel()
        {
            InitializeComponent();
            RenderDepartures();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void RenderDepartures()
        {
            List<Departures> departure = new List<Departures>();

            Departures dep = new Departures();
            departure = dep.GetTrasy();

            dataGridView1.DataSource = departure;
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu form1 = new Menu();
            form1.ShowDialog();
        }
    }
}
