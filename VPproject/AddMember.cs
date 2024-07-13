using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VPproject
{
    public partial class AddMember : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\shahm\\VPproject\\VPproject\\Database1.mdf;Integrated Security=True";

        public AddMember()
        {
            InitializeComponent();
        }
        private void AddMember_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string email = textBox2.Text;
            string joiningDate = textBox3.Text;
            string address = textBox4.Text;
            string mobileNumber = textBox5.Text;
            string Idnumber = textBox6.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(joiningDate) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(mobileNumber) || string.IsNullOrWhiteSpace(Idnumber))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO addmember (Name, Email, JoiningDate, Address, Mobile, Id) VALUES (@Name, @Email, @JoiningDate, @Address, @Mobile,@Id)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@JoiningDate", joiningDate);
                        cmd.Parameters.AddWithValue("@Address", address);
                        cmd.Parameters.AddWithValue("@Mobile", mobileNumber);
                        cmd.Parameters.AddWithValue("@Id", Idnumber);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Member added successfully!");
                           
                        }
                        else
                        {
                            MessageBox.Show("Failed to add member. Please try again.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            showmember show = new showmember();
            show.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
           Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }
    } 

    }
