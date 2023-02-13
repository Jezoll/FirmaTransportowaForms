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
    public partial class AddingDriver : Form
    {
        public AddingDriver()
        {
            InitializeComponent();
            SetFormBackgroundImage(@"C:\Users\Dawid\source\repos\WindowsFormsApp1\tlo.jpg");
        }
        private void SetFormBackgroundImage(string imagePath)
        {
            this.BackgroundImage = Image.FromFile(imagePath);
            this.BackgroundImageLayout = ImageLayout.Stretch;
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
            
            //driver.AddNewDriver(textBox1.Text, textBox2.Text, data, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text);
            Validation validation = new Validation();

            DateTime data = DateTime.TryParse(textBox3.Text, out data) ? data : DateTime.Now;
            if (data == null)
            {
                data = DateTime.MinValue;
            }
            if (!validation.ValidatePerson(textBox1.Text, textBox2.Text, data, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text))
                {
                    MessageBox.Show("Walidacja nie powiodła się");
                }
                else
                {
                    driver.AddNewDriver(textBox1.Text, textBox2.Text, data, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text);
                }

            }
            
        

        private void button2_Click(object sender, EventArgs e)
        {
            DriversPanel form1 = new DriversPanel();
            form1.Show();
            this.Hide();
        }
    }
}
