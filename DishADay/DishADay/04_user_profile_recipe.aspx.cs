using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

namespace DishADay
{
    public partial class _04_user_profile_recipe : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //=== anonymous users
            if (Session["user_name"] == null)
            {
                this.Literal1.Text = "<li class='nav-item mx-3'><a href='17_login.aspx' class='btn loginsignup-button' type='menu' >Log In / Sign Up</a></li>";
            }
            //=== registered users
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
                //Profile Users Icon
                html.Append("<i class=\"fa-solid fa-user\"></i></a></li>");
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

                //If the page is your profile
                int user_id = Convert.ToInt32(Request.QueryString["Id"]);
                if (user_id == Convert.ToInt32(Session["user_id"]))
                {
                    //Private Profile Option
                    this.LiteralProfileOption.Text = "<div class='private-profile-option'>" +
                        "<div class='btn-group'>" +
                        "<a href='04_user_profile_recipe.aspx?Id=" + Session["user_id"] + "' class='btn active' aria-current='page'>Recipe</a>" +
                        "<a href='05_user_profile_cooking_history.aspx?Id=" + Session["user_id"] + "' class='btn inactive'>Cooking History</a>" +
                        "</div></div>";
                    //Create Recipe
                    this.Literal3.Text = "<div class=\"profile-upload-recipe-btn\"><a class=\"btn\" href=\"06_recipe_upload.aspx?Id=" + Session["user_id"] + "\"> + Create Recipe </a></div>";
                }
                //Logout
                this.Literal1.Text = "<li class='nav-item mx-3'><a href='19_logout.aspx' class='btn loginsignup-button' type='menu' >Log Out</a></li>";

            }

            //================== Profile Info
            //From Users Table
            DataTable dt = this.GetDataUsers();
            StringBuilder html2 = new StringBuilder();
            string recipe_username = "";

            //Building the Data rows from Users table.
            foreach (DataRow row in dt.Rows)
            {
                recipe_username = row["username"].ToString();

                html2.Append("<h4 id=\"username\"><u>@" + recipe_username + "</u></h4>");
                html2.Append("<p><span id=\"first-name\">" + row["first_name"] + "</span><span class=\"ms-2\" id=\"last-name\">" + row["last_name"] + "</span></p>");

                DateTime dateandtime = (DateTime)row["birth_date"];
                var justdate = dateandtime.ToString("MM/dd/yyyy");
                html2.Append("<p>Birth Date: " + justdate + "</p>");

                html2.Append("<p>Total Recipe: <span>" + CountRecipe().ToString() + "</span></p>");
            }
            PlaceHolder3.Controls.Add(new Literal { Text = html2.ToString() });

            //================= Recipe Gallery of Selected Author
            DataTable dt2 = this.GetDataRecipe();
            StringBuilder html3 = new StringBuilder();
            foreach (DataRow row in dt2.Rows)
            {
                string recipe_pic = row["recipe_img"].ToString();

                html3.Append("<div class='col'> ");
                html3.Append("<a href='03_recipe.aspx?recipe_id=" + row["recipe_id"] + "' class='card h-100 recipe-gallery-option'>");
                html3.Append("<img src = \"assets/recipe_upload/" + recipe_pic + "\" alt=\"food\" class =\"card-img-top\"/>");
                html3.Append("<div class='card-body'>");
                html3.Append("<h5 class='card-title'>" + row["recipe_title"] + "</h5>");
                html3.Append("<p class='text-muted'> by " + recipe_username + "</p>");
                html3.Append("<p class='card-text'>" + row["recipe_caption"] + "</p>");
                html3.Append("</div>");
                html3.Append("</a>");
                html3.Append("</div>");
            }
            PlaceHolderRecipeGallery.Controls.Add(new Literal { Text = html3.ToString() });

        }

        private DataTable GetDataUsers()
        {
            //Query from URL
            string user_id = Request.QueryString["Id"];
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE Id='" + user_id + "' "))
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

        private DataTable GetDataRecipe()
        {
            //Query from URL
            string user_id = Request.QueryString["Id"];
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM recipe WHERE verification_status=1 AND user_id='" + user_id + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt2 = new DataTable())
                        {
                            sda.Fill(dt2);
                            return dt2;
                        }
                    }
                }
            }
        }

        private string CountRecipe()
        {
            string countStr = "";
            string user_id = Request.QueryString["Id"];
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS totalRecipes FROM recipe WHERE verification_status=1 AND user_id =" + user_id))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            foreach (DataRow row in dt.Rows)
                            {

                                countStr = row["totalRecipes"].ToString();

                            }
                        }
                    }
                }
            }
            return countStr;
        }
    }
}