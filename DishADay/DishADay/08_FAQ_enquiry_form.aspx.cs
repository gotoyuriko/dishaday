using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;


namespace DishADay
{
    public partial class _08_FAQ_enquiry_form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_name"] == null)
            {
                this.Literal1.Text = "<li class='nav - item mx - 3'><a href='17_login.aspx' class='btn loginsignup-button' type='menu' >Log In / Sign Up</a></li>";
            }
            else
            {
                //generate profile icons
                StringBuilder html = new StringBuilder();
                html.Append("<li class=\"nav-item mx-3\">");
                if (Convert.ToInt32(Session["role"]) == 1)
                {
                    //admin go to the admin home page
                    html.Append("<a class='btn loginsignup-button' type='menu' href='09_admin_home.aspx'>");
                }
                else
                {
                    //users go to the user profile page
                    html.Append("<a class='btn loginsignup-button' type='menu' href='04_user_profile_recipe.aspx?Id=" + Session["user_id"] + "'>");
                }
                html.Append("<i class=\"fa-solid fa-user\"></i></a></li>");
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
                this.Literal1.Text = "<li class='nav-item mx-3'><a href='19_logout.aspx' class='btn loginsignup-button' type='menu' >Log Out</a></li>";
            }
        }

        protected void enquirySubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {
                con.Open();

                string query = "INSERT INTO enquiry (enquiry ,enquiry_name, enquiry_email, " +
                    "enquiry_date) values (@enquiry, @enquiry_name, @enquiry_email, @enquiry_date)";

                SqlCommand cmd = new SqlCommand(query, con);

                //Date and Time
                DateTime now = DateTime.Now;
                string now_string = now.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("@enquiry_date", now_string);

                cmd.Parameters.AddWithValue("@enquiry", enquiry.Text);
                cmd.Parameters.AddWithValue("@enquiry_name", enquiryName.Text);
                cmd.Parameters.AddWithValue("@enquiry_email", enquiryEmail.Text);

                cmd.ExecuteNonQuery();

                Response.Write("<script> alert('Enquiry Sent!'); window.location.href = '08_FAQ_enquiry_form.aspx'; </script>");

                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }


    }
}