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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

             private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\shahm\\VPproject\\VPproject\\Database1.mdf;Integrated Security=True";
            string username = tbName.Text;
            string password = tbPass.Text;
            string email = tbEmail.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                   
                    using (SqlCommand checkUserExistCommand = new SqlCommand("SELECT COUNT(*) FROM [signup] WHERE [Name] = @Username", conn))
                    {
                        checkUserExistCommand.Parameters.AddWithValue("@Username", username);
                        int userExists = (int)checkUserExistCommand.ExecuteScalar();

                        if (userExists > 0)
                        {
                            MessageBox.Show("Username already exists. Please choose a different username.");
                            return;
                        }
                    }

                    
                    string query = "INSERT INTO signup (Name, Email, Password) VALUES (@Username, @Email, @Password)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Signup successful!");

                            
                            this.Close();

                            
                            Login loginForm = new Login();
                            loginForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Signup failed. Please try again.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }



        private void SignUp_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            string email = tbEmail.Text;
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (System.Text.RegularExpressions.Regex.IsMatch(email, pattern))
            {
                
                tbEmail.BackColor = System.Drawing.Color.White; 
            }
            else
            {
                
                tbEmail.BackColor = System.Drawing.Color.Pink; 
            }
        }


        private void tbPass_TextChanged(object sender, EventArgs e)
        {
            
            tbPass.PasswordChar = '*';
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            Login loginForm = new Login();
            loginForm.Show(); 
            this.Close();
        }

       

        
    }
    
}
