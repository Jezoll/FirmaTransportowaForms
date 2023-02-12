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
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
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
            this.Hide();
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
            string login = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string password = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            bool isAdmin = (bool)dataGridView1.SelectedRows[0].Cells[4].Value;
            bool isActive = (bool)dataGridView1.SelectedRows[0].Cells[2].Value;
            this.Hide();
            UpdateUser form3 = new UpdateUser(login, password, isAdmin, isActive);
            form3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginPanel form = new LoginPanel();
            this.Hide();
            form.ShowDialog();
        }
    }
}
