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
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.MultiSelect = false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            string login = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            User user = new User();
            user.DeleteUser(login);
            LoadEmployees();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
