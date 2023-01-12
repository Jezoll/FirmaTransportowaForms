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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void AddNewDriver()
        {
            Driver driver = new Driver();
            driver.Imie = textBox1.Text;
            driver.Nazwisko = textBox2.Text;
            driver.Data_ur = textBox3.Text;
            driver.Pesel = textBox4.Text;
            driver.Kod_pocztowy = textBox5.Text;
            driver.Miasto = textBox6.Text;
            driver.Ulica = textBox7.Text;
            driver.Numer_domu = textBox8.Text;
            driver.Numer_mieszkania = textBox9.Text;
            driver.Telefon = textBox10.Text;
            driver.Email = textBox11.Text;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=DESKTOP-MS2A1CD;Database=Firma_Transportowa;Trusted_Connection=true";
            using (SqlConnection conn = new SqlConnection(connection.ConnectionString))
            {
                conn.Open();
                string queryTest;
                queryTest = "INSERT INTO dbo.Kierowca (Imie, Nazwisko, data_ur, pesel, kod_pocztowy, miasto, ulica, nr_domu, nr_lokalu, telefon, mail) VALUES ('" + driver.Imie + "', '" + driver.Nazwisko + "', '" + driver.Data_ur + "', '" + driver.Pesel + "', '" + driver.Kod_pocztowy + "', '" + driver.Miasto + "', '" + driver.Ulica + "', '" + driver.Numer_domu + "', '" + driver.Numer_mieszkania + "', '" + driver.Telefon + "', '" + driver.Email + "')";
                SqlCommand command = new SqlCommand(queryTest, conn);
                command.ExecuteNonQuery();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewDriver();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
