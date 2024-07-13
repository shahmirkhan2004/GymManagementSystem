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

namespace VPproject
{
    public partial class Form3 : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\shahm\\VPproject\\VPproject\\Database1.mdf;Integrated Security=True";
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                
                if (!int.TryParse(textBox2.Text, out int memberId))
                {
                    textBox1.Text = "Please enter a valid member ID.";
                    return;
                }

              
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                   
                    string query = "SELECT Name, Email, JoiningDate, Address, Mobile FROM addmember WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                       
                        command.Parameters.AddWithValue("@Id", memberId);

                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                
                                textBox1.Text = $"Name: {reader["Name"]}\r\nEmail: {reader["Email"]}\r\nJoiningDate: {reader["JoiningDate"]}\r\nAddress: {reader["Address"]}\r\nMobile: {reader["Mobile"]}";
                            }
                            else
                            {
                                textBox1.Text = "Member not found.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)

            {

               
                textBox1.Text = $"Error: {ex.Message}";
            }
        }

                        void textBox1_TextChanged(object sender, EventArgs e)
                        {

                        }

                        void Form3_Load(object sender, EventArgs e)
                        {

                        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }
    }
                }
            

                





            

