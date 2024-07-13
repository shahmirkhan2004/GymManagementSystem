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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VPproject
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        
            private void button1_Click(object sender, EventArgs e)
            {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\shahm\\VPproject\\VPproject\\Database1.mdf;Integrated Security=True";
                string memberId = textBox1.Text; 
                string membershipDuration = comboBox1.Text; 
                bool trainer = radioButton1.Checked; 
                string fee = textBox2.Text; 

                if (string.IsNullOrWhiteSpace(memberId) || string.IsNullOrWhiteSpace(membershipDuration) || string.IsNullOrWhiteSpace(fee))
                {
                    MessageBox.Show("Please fill in all required fields.");
                    return;
                }

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        
                        string retrieveQuery = "SELECT * FROM addmember WHERE Id=@MemberId";
                        using (SqlCommand retrieveCmd = new SqlCommand(retrieveQuery, connection))
                        {
                            retrieveCmd.Parameters.AddWithValue("@MemberId", memberId);
                            using (SqlDataReader reader = retrieveCmd.ExecuteReader())
                            {
                                if (!reader.Read())
                                {
                                    MessageBox.Show("Member not found.");
                                    return;
                                }
                                
                               
                            }
                        }

                        
                        string insertQuery = "INSERT INTO membership (Id, MembershipDuration, Trainer, Fee) VALUES (@MemberId, @MembershipDuration, @Trainer, @Fee)";
                        using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@MemberId", memberId);
                            cmd.Parameters.AddWithValue("@MembershipDuration", membershipDuration);
                            cmd.Parameters.AddWithValue("@Trainer", trainer);
                            cmd.Parameters.AddWithValue("@Fee", fee);

                            int result = cmd.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show("Membership details added successfully!");
                              
                            }
                            else
                            {
                                MessageBox.Show("Failed to add membership details. Please try again.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

 
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
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
