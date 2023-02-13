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
    public partial class AddCargo : Form
    {
        public AddCargo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cargo cargo = new Cargo();
            cargo.AddCargo(((int)numericUpDown1.Value, (int)numericUpDown2.Value, textBox1.Text);
        }
    }
}
