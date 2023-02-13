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
    public partial class AddDepartures : Form
    {
        public AddDepartures()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Departures departures = new Departures();
            departures.AddNewDeparture(textBox1.Text, textBox2.Text, (int)numericUpDown1.Value, (int)comboBox1.SelectedValue, (int)comboBox2.SelectedValue, (int)comboBox3.SelectedValue, (int)comboBox4.SelectedValue, (int)comboBox5.SelectedValue, checkBox1.Checked);
        }

        private void AddDepartures_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeparturesPanel form1 = new DeparturesPanel();
            form1.Show();
            this.Hide();
        }
    }
}
