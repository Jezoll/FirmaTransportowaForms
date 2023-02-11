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
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
            LoadEmployees();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadEmployees()
        {
            User user = new User();
            dataGridView1.DataSource = user.GetAllUsers();
        }

        private void button_Dodaj_Click(object sender, EventArgs e)
        {
            this.Close();
            UserAdding form2 = new UserAdding();
            form2.ShowDialog();
        }
    }
}
