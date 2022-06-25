using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

namespace DishADay
{
    public partial class _02_recipe_gallery : System.Web.UI.Page
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

            if (!this.IsPostBack)
            {
                string searchkey = Request.QueryString["searchkey"];

                //Populating a DataTable from database.
                DataTable dt = this.GetDataRecipe(searchkey);

                //Building an HTML string.
                StringBuilder html2 = new StringBuilder();

                //Building Recipe Gallery
                foreach (DataRow row in dt.Rows)
                {
                    //image
                    string recipe_pic = row["recipe_img"].ToString();

                    //username
                    string recipe_username = "";

                    //Take user id from the recipe table
                    int user_id = Convert.ToInt32(row["user_id"]);

                    DataTable dtUser = this.GetRecipeUser(user_id);
                    foreach (DataRow rowUser in dtUser.Rows)
                    {

                        //Get username from Users table by user id
                        recipe_username = rowUser["username"].ToString();

                    }

                    html2.Append("<div class='col'> ");
                    html2.Append("<a href='03_recipe.aspx?recipe_id=" + row["recipe_id"] + "' class='card h-100 recipe-gallery-option'>");
                    html2.Append("<img src = \"assets/recipe_upload/" + recipe_pic + "\" alt=\"food\" class =\"card-img-top\"/>");
                    html2.Append("<div class='card-body'>");
                    html2.Append("<h5 class='card-title'>" + row["recipe_title"] + "</h5>");
                    html2.Append("<p class='text-muted'> by " + recipe_username + "</p>");
                    html2.Append("<p class='card-text'>" + row["recipe_caption"] + "</p>");
                    html2.Append("</div>");
                    html2.Append("</a>");
                    html2.Append("</div>");
                }
                //Append the HTML string to Placeholder.
                PlaceHolder2.Controls.Add(new Literal { Text = html2.ToString() });
            }

        }
        private DataTable GetDataRecipe(string searchkey)
        {

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {

                int search_user_id = 0;
                //Get user id from Users table by searched name
                DataTable dtUser = this.GetRecipeUserID(searchkey);
                foreach (DataRow rowUser in dtUser.Rows)
                {
                    //Get username from Users table by user id
                    search_user_id = Convert.ToInt32(rowUser["Id"]);
                }

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM recipe WHERE verification_status=1 AND (recipe_title LIKE '%" + searchkey + "%' OR user_id ='" + search_user_id + "')"))
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

        //Get user data by user id
        private DataTable GetRecipeUser(int user_id)
        {
            //Take User Name and Last Name
            string constr2 = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con2 = new SqlConnection(constr2))
            {
                //to restrive that belongs to user id after login
                using (SqlCommand cmd2 = new SqlCommand("SELECT * FROM users WHERE Id='" + user_id + "'"))
                {
                    using (SqlDataAdapter sda2 = new SqlDataAdapter())
                    {
                        cmd2.Connection = con2;
                        sda2.SelectCommand = cmd2;
                        using (DataTable dt2 = new DataTable())
                        {
                            sda2.Fill(dt2);
                            return dt2;
                        }
                    }
                }
            }
        }

        //Get user data by username
        private DataTable GetRecipeUserID(string searchkey)
        {
            //Take User Name and Last Name
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                //to restrive that belongs to user id after login
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE username LIKE '%" + searchkey + "%'"))
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
        protected void recipe_search_btn_Click(object sender, EventArgs e)
        {
            string searchKeyword = recipeGallerySearchTextBox.Text;

            Response.Redirect("02_recipe_gallery.aspx?searchkey=" + searchKeyword);

        }
    }
}