﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            DeparturesPanel form5 = new DeparturesPanel();
            form5.ShowDialog();
        }

        private void buttonWyjdz_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginPanel form3 = new LoginPanel();
            form3.ShowDialog();
        }

        private void Ludzie_Click(object sender, EventArgs e)
        {
            this.Close();
            DriversPanel form1 = new DriversPanel();
            form1.ShowDialog();
        }
    }
}
