using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DishADay
{
    public partial class _17_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //To get the input value from textbox
            string user_name = this.emailUsername.Text;
            string user_password = this.loginPassword.Text;

            // to store the user Id read from DB
            string user_id = "";

            string first_name = "";
            string last_name = "";
            int role = 0;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            con.Open();
            //SQL Query
            string query = "SELECT *  FROM Users WHERE (username='" + user_name + "' COLLATE SQL_Latin1_General_CP1_CS_AS OR email='" + user_name + "' COLLATE SQL_Latin1_General_CP1_CS_AS) AND password='" + user_password + "' COLLATE SQL_Latin1_General_CP1_CS_AS";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.CommandType = CommandType.Text;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            cmd.ExecuteNonQuery();

            if (dt.Rows.Count > 0)
            {

                //registered user part
                foreach (DataRow row in dt.Rows)
                {
                    //user id fetch from DB, and assign to a variable
                    user_id = row["Id"].ToString();
                    first_name = row["first_name"].ToString();
                    last_name = row["last_name"].ToString();
                    role = Convert.ToInt32(row["role"]);
                }


                if (role == 1)
                {
                    //admin part
                    this.Session["user_id"] = user_id;
                    this.Session["user_name"] = user_name;
                    this.Session["full_name"] = first_name + " " + last_name;
                    this.Session["role"] = role;
                    Response.Redirect("09_admin_home.aspx");
                }
                else if (role == 2)
                {
                    //registered user
                    //session created if login successful
                    this.Session["user_id"] = user_id;
                    this.Session["user_name"] = user_name;
                    this.Session["full_name"] = first_name + " " + last_name;
                    this.Session["role"] = role;
                    Response.Redirect("01_home.aspx");
                }


            }
            else
            {
                //Notification message if login is not successful
                Label1.Text = "Your username or password is incorrect";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            con.Close();
        }
    }
}

