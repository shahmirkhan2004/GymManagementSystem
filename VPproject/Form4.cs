




using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VPproject
{
    public partial class Form4 : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\shahm\\VPproject\\VPproject\\Database1.mdf;Integrated Security=True";

        public Form4()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        void button2_Click(object sender, EventArgs e)
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

                    
                    string query = "DELETE FROM addmember WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        
                        command.Parameters.AddWithValue("@Id", memberId);

                       
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            textBox1.Text = "Member deleted successfully.";
                        }
                        else
                        {
                            textBox1.Text = "Member not found or already deleted.";
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

             void Form4_Load(object sender, EventArgs e)
            {

            }

             void button3_Click(object sender, EventArgs e)
            {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
            this.Close();
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
                               
                                textBox1.Text =
                                    $"Name: {reader["Name"]}\r\n" +
                                    $"Email: {reader["Email"]}\r\n" +
                                    $"JoiningDate: {reader["JoiningDate"]}\r\n" +
                                    $"Address: {reader["Address"]}\r\n" +
                                    $"Mobile: {reader["Mobile"]}";
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
    }



}
    





























