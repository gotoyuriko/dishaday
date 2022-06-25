using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

namespace DishADay
{
    public partial class _01_home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_name"] == null)
            {
                this.Literal3.Text = "<h1>Hi! Welcome to Dish A Day</h1>";
                this.Literal1.Text = "<li class='nav-item mx-3'><a href='17_login.aspx' class='btn loginsignup-button' type='menu' >Log In / Sign Up</a></li>";
            }
            else
            {
                DateTime now = DateTime.Now;
                int currentHour = now.Hour;
                //int currentHour = 7;
                string msg;

                if (currentHour >= 6 && currentHour < 12)
                {
                    msg = "Good Morning";
                }
                else if (currentHour >= 12 && currentHour < 17)
                {
                    msg = "Good Afternoon";
                }
                else if (currentHour >= 17 && currentHour < 22)
                {
                    msg = "Good Evening";
                }
                else
                {
                    msg = "Good Night";
                }

                this.Literal3.Text = "<h1>" + msg + ", " + Session["full_name"] + "</h1>";

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



            //generate profile icons
            StringBuilder html2 = new StringBuilder();
            DataTable dt = this.GetLatestRecipe();
            foreach (DataRow row in dt.Rows)
            {
                html2.Append("<div class='col-sm d-flex flex-column justify-content-center align-items-center'>");
                string recipe_pic = row["recipe_img"].ToString();
                html2.Append("<a href=\"03_recipe.aspx?recipe_id=" + row["recipe_id"] + "\">");
                html2.Append("<img class=\"home-img-animation img-fluid\" src=\"assets/recipe_upload/" + recipe_pic + "\" alt=\"food\"/>");
                html2.Append("<div class=\"home-recipe-text\">" + row["recipe_title"] + "</div>");
                html2.Append("</a>");
                html2.Append("</div>");
            }
            PlaceHolder2.Controls.Add(new Literal { Text = html2.ToString() });

        }

        protected void homeSearchButton_Click(object sender, EventArgs e)
        {
            string searchKeyword = homeSearchTextBox.Text;

            Response.Redirect("02_recipe_gallery.aspx?searchkey=" + searchKeyword);
        }

        //Latest RECIPE
        private DataTable GetLatestRecipe()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {

                using (SqlCommand cmd = new SqlCommand("SELECT TOP 3 * FROM recipe WHERE verification_status=1 ORDER BY date_published DESC"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
    }
}