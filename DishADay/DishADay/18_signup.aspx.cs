using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DishADay
{
    public partial class _18_signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (password.Text == registerRepeatPassword.Text)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                string user_name = this.registerUsername.Text;

                con.Open();

                string query1 = "SELECT * FROM users WHERE username ='" + user_name + "'";

                SqlCommand cmd1 = new SqlCommand(query1, con);

                cmd1.CommandType = CommandType.Text;

                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);

                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);

                cmd1.ExecuteNonQuery();

                if (dt1.Rows.Count > 0)
                {
                    usernameError.Text = "Username is already taken. Please choose another one";
                    usernameError.ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    try
                    {
                        con.Close();
                        con.Open();

                        string query = "INSERT INTO Users (username, password, email, birth_date, first_name, last_name) values (@username, @password, @email, @birth_date, @first_name, @last_name)";

                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@username", registerUsername.Text);
                        cmd.Parameters.AddWithValue("@password", password.Text);
                        cmd.Parameters.AddWithValue("@email", registerEmail.Text);
                        cmd.Parameters.AddWithValue("@first_name", firstName.Text);
                        cmd.Parameters.AddWithValue("@birth_date", birthDate.Text);
                        cmd.Parameters.AddWithValue("@last_name", lastName.Text);

                        cmd.ExecuteNonQuery();

                        Response.Redirect("01_home.aspx");

                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.ToString());
                    }
                }
            }
            else
            {
                registerRepeatPasswordErrorMsg.Text = "The confirm passowrd does not match. Please try again";
                registerRepeatPasswordErrorMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}