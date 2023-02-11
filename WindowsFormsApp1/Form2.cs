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
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
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
            Driver driver = new Driver();
            Validation validation = new Validation();
            try
            {
                DateTime data = DateTime.Parse(textBox3.Text);
                if (!validation.ValidatePerson(textBox1.Text, textBox2.Text, data, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text))
                {
                    MessageBox.Show("Walidacja nie powiodła się");
                }
                else
                {
                    driver.AddNewDriver(textBox1.Text, textBox2.Text, data, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text);
                }

            }catch (FormatException)
            {
                MessageBox.Show("Data urodzenia jest wymagana i musi być w formacie dd.MM.yyyy");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
