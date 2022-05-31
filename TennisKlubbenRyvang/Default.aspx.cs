using System;
using System.Data;
using System.Web.UI;
using System.Configuration;
using System.Data.SqlClient;

namespace TennisKlubbenRyvang
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string name = navnTextBox.Text;
            string bday = bdayTextBox.Text;
            string address = adresseTextBox.Text;
            string phone = telefonTextBox.Text;
            string userEmail = emailTextBox.Text;
            string password = pswTextBox.Text;
            string repeatedPassword = pswRepeatTextBox.Text;

            FormatDateTime(bday);

            bool checker = false;

            if (password == repeatedPassword)
            {
                AddNewPerson(name, bday, address, phone);
                AddNewLogin(userEmail, password);
                checker = true;
            }
            else
            {
                warningText.Visible = true;
                warningText.Text = "Kodeordene matcher ikke.";
            }

            if (checker == true)
            {
                GoToHomePage();
            }
        }

        private void GoToHomePage()
        {
            Response.Redirect("About.aspx");
        }

        private void AddNewPerson(string name, string bday, string address, string phone)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Person"].ConnectionString;                

                using (SqlCommand cmd = new SqlCommand("CreatePerson", conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@navn", SqlDbType.NVarChar).Value = name;
                    cmd.Parameters.AddWithValue("@fødselsdato", SqlDbType.DateTime).Value = bday;
                    cmd.Parameters.AddWithValue("@adresse", SqlDbType.NVarChar).Value = address;
                    cmd.Parameters.AddWithValue("@telefon", SqlDbType.NVarChar).Value = phone;
                    cmd.ExecuteNonQuery();
                    conn.Dispose();
                    conn.Close();
                }
            }
        }

        private void FormatDateTime(string date)
        {
            Convert.ToDateTime(date);
        }

        private void AddNewLogin(string userEmail, string password)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Login"].ConnectionString;                

                using (SqlCommand cmd = new SqlCommand("CreateLogin", conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(@"personId", SqlDbType.Int).Value = 1; /* GetPersonId() */
                    cmd.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = userEmail;
                    cmd.Parameters.AddWithValue("@password", SqlDbType.NVarChar).Value = password;
                    cmd.ExecuteNonQuery();
                    conn.Dispose();
                    conn.Close();                    
                }
            }
        }

        private void GetPersonId(string name, string address, string phone)
        {
            // Didnt have time to finish this method
            string sql = $"SELECT personId FROM Person WHERE navn=@{name}, adresse=@{address}, telefon=@{phone}";
        }
    }
}