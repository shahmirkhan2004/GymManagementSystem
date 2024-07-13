using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VPproject
{
    public partial class Login : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\shahm\\VPproject\\VPproject\\Database1.mdf;Integrated Security=True";

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginA();
        }

        private void LoginA()
        {
            string username = tbName.Text;
            string password = tbPass.Text;

            
            bool isAdmin = CheckAdminCredentials(username, password);

            if (isAdmin)
            {
                this.Close();
              Form1 form1 = new Form1(); 
                form1.Show(); 
            }
            else
            {
                MessageBox.Show("Incorrect admin credentials. Please try again.");
                tbName.Clear();
                tbPass.Clear();
                tbName.Focus();
            }
        }

        
        private bool CheckAdminCredentials(string username, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    
                    string query = "SELECT COUNT(*) FROM signup WHERE Name = @Username AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        int adminExists = (int)cmd.ExecuteScalar();
                        return adminExists > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                return false;
            }
        }

       
        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        
        private void tbName_TextChanged(object sender, EventArgs e)
        {
          
        }

        
        private void tbPass_TextChanged(object sender, EventArgs e)
        {
            tbPass.PasswordChar = '*';
        }

       
        private void tbPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoginA();
            }
        }
    





private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            SignUp signUpForm = new SignUp();
            signUpForm.Show(); 
            this.Hide(); 
        }
    }
}
