using RestSharp;
using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;


namespace VPproject
{
    public partial class Form1 : Form
    {
        string Weather;
        string Temperature;
        string wind;
        string Humidity;

        public Form1()
        {
            InitializeComponent();
        }

        private void GetWeatherData(string location)

        {
            var client = new RestClient();
            var request = new RestRequest();
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                string[] weatherParameters = Regex.Split(response.Content, "");

                Weather = weatherParameters[0];
                Temperature = weatherParameters[1];
                wind = weatherParameters[2];
                Humidity = weatherParameters[3];

                //Console.WriteLine("Weather in :" + location);
                //Console.WriteLine("Weather:" + weatherParameters[0]);
                //Console.WriteLine("Temperture:" + weatherParameters[1]);
                //Console.WriteLine("Wind:" + weatherParameters[2]);
                //Console.WriteLine("Humidity:" + weatherParameters[3]);
                ////Console.WriteLine("Moon phase:" + weatherParameters[0]);
            }
            else
            {
                MessageBox.Show("Error:" + response.StatusCode);
            }

        }

       

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var img = Resource1.gimmi;
            var img1 = Resource1.images;

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddMember addmember = new AddMember();
            addmember.ShowDialog();
            this.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddStaff addStaff = new AddStaff();
            addStaff.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Equipments equip = new Equipments ();
            equip.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form = new Form3();
            form.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form = new Form4();
            form.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 formz = new Form5();
            formz.ShowDialog();
            this.Close();
        }

      

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

       
    }
}
