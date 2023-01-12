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
            LoadEmployees();
        
        }
        private void LoadEmployees()
        {
            dataGridView1.Columns.Add("Imie", "Imie");
            dataGridView1.Columns.Add("Nazwisko", "Nazwisko");
            dataGridView1.Columns.Add("Data urodzenia", "Data urodzenia");
            dataGridView1.Columns.Add("Pesel", "Pesel");
            dataGridView1.Columns.Add("Kod pocztowy", "Kod pocztowy");
            dataGridView1.Columns.Add("Miasto", "Miasto");
            dataGridView1.Columns.Add("Ulica", "Ulica");
            dataGridView1.Columns.Add("Numer domu", "Numer domu");
            dataGridView1.Columns.Add("Numer mieszkania", "Numer mieszkania");
            dataGridView1.Columns.Add("Telefon", "Telefon");
            dataGridView1.Columns.Add("Email", "Email");
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=DESKTOP-MS2A1CD;Database=Firma_Transportowa;Trusted_Connection=true";
            using (SqlConnection conn = new SqlConnection(connection.ConnectionString))
            {



                conn.Open();
                string wynik;
                string queryTest;
                queryTest = "SELECT * FROM dbo.Kierowca";
                SqlCommand command = new SqlCommand(queryTest, conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<string> rows = new List<string>();
                    while (reader.Read())
                    {
                        wynik = reader["Imie"].ToString();
                        rows.Add(wynik);
                        wynik = reader["Nazwisko"].ToString();
                        rows.Add(wynik);
                        wynik = reader["data_ur"].ToString();
                        rows.Add(wynik);
                        wynik = reader["Pesel"].ToString();
                        rows.Add(wynik);
                        wynik = reader["Kod_pocztowy"].ToString();
                        rows.Add(wynik);
                        wynik = reader["Miasto"].ToString();
                        rows.Add(wynik);
                        wynik = reader["Ulica"].ToString();
                        rows.Add(wynik);
                        wynik = reader["Nr_domu"].ToString();
                        rows.Add(wynik);
                        wynik = reader["Nr_lokalu"].ToString();
                        rows.Add(wynik);
                        wynik = reader["Telefon"].ToString();
                        rows.Add(wynik);
                        wynik = reader["mail"].ToString();
                        rows.Add(wynik);

                        dataGridView1.Rows.Add(rows.ToArray());
                        rows.Clear();
                    }


                }

            }
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
    }
}
