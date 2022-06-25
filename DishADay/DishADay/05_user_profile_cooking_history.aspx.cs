using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

namespace DishADay
{
    public partial class _05_user_profile_cooking_history : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_name"] == null)
            {
                Response.Redirect("17_login.aspx");
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
                    //Private Profile Option
                    this.LiteralProfileOption.Text = "<div class='private-profile-option'>" +
                        "<div class='btn-group'>" +
                        "<a href='04_user_profile_recipe.aspx?Id=" + Session["user_id"] + "' class='btn inactive' aria-current='page'>Recipe</a>" +
                        "<a href='05_user_profile_cooking_history.aspx?Id=" + Session["user_id"] + "' class='btn active'>Cooking History</a>" +
                        "</div></div>";
                }

                html.Append("<i class=\"fa-solid fa-user\"></i></a></li>");
                this.userProfileLiteral.Text = "<div class=\"profile-upload-recipe-btn\"><a class=\"btn\" href=\"06_recipe_upload.aspx?Id=" + Session["user_id"] + "\"> + Create Recipe </a></div>";
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
                this.Literal1.Text = "<li class='nav-item mx-3'><a href='19_logout.aspx' class='btn loginsignup-button' type='menu' >Log Out</a></li>";

                //================== Profile Info
                //From Users Table
                DataTable dt = this.GetDataUsers();
                StringBuilder html3 = new StringBuilder();

                //Building the Data rows from Users table
                foreach (DataRow row in dt.Rows)
                {
                    html3.Append("<h4 id=\"username\"><u>@" + row["username"] + "</u></h4>");
                    html3.Append("<p><span id=\"first-name\">" + row["first_name"] + "</span><span class=\"ms-2\" id=\"last-name\">" + row["last_name"] + "</span></p>");

                    DateTime dateandtime = (DateTime)row["birth_date"];
                    var justdate = dateandtime.ToString("MM/dd/yyyy");
                    html3.Append("<p>Birth Date: " + justdate + "</p>");

                    html3.Append("<p>Total Recipe: <span>" + CountRecipe().ToString() + "</span></p>");
                }
                userProfilePlaceholder.Controls.Add(new Literal { Text = html3.ToString() });


                //================== Cooking History
                if (!this.IsPostBack)
                {
                    //Populating DataTable from database.
                    DataTable dtCookingHistory = this.GetDataCookingHistory();

                    //Building HTML string.
                    StringBuilder html2 = new StringBuilder();

                    html2.Append("<div class='d-flex flex-row justify-content-end'>");
                    html2.Append("<a onClick=\"return confirm('Are you sure you want to delete all cooking history?')\" class='clear-btn btn' href='34_history_delete_user.aspx'>Clear All History</a>");
                    html2.Append("</div>");

                    //Building Cooking History data rows.
                    foreach (DataRow row in dtCookingHistory.Rows)
                    {

                        int recipe_id = Convert.ToInt32(row["recipe_id"]);
                        string recipe_title = "";
                        string recipe_pic = "";

                        //Take recipe title from the recipe table
                        DataTable dtRecipe = this.GetDataRecipe(recipe_id);
                        foreach (DataRow row2 in dtRecipe.Rows)
                        {
                            recipe_title = row2["recipe_title"].ToString();
                        }

                        DataTable dtRecipe2 = this.GetDataRecipe(recipe_id);
                        foreach (DataRow row2 in dtRecipe2.Rows)
                        {

                            recipe_pic = row2["recipe_img"].ToString();
                        }

                        html2.Append("<tr>");
                        html2.Append("<td>");
                        html2.Append("<a class='title' href='03_recipe.aspx?recipe_id=" + recipe_id + "'>");
                        html2.Append("<img src ='assets/recipe_upload/" + recipe_pic + "' alt='recipe image'/>");
                        html2.Append("<span><b>" + recipe_title + "</b></span></a>");
                        html2.Append("</td>");
                        html2.Append("<td>" + row["cooking_date"] + "</td>");
                        html2.Append("<td>" + row["cooking_status"] + "</td>");
                        html2.Append("<td class='history-notes'>" + row["cooking_notes"] + "</td>");
                        html2.Append("</tr>");

                    }

                    //Append the HTML string to Placeholder.
                    PlaceHolderCookingHistory.Controls.Add(new Literal { Text = html2.ToString() });
                }
            }
        }
        private DataTable GetDataCookingHistory()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM cooking_history WHERE user_id=" + Session["user_id"]))
                {

                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dtCookingHistory = new DataTable())
                        {
                            sda.Fill(dtCookingHistory);
                            return dtCookingHistory;
                        }
                    }

                }

            }
        }

        private DataTable GetDataRecipe(int recipe_id)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM recipe WHERE recipe_id=" + recipe_id))
                {

                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dtRecipe = new DataTable())
                        {
                            sda.Fill(dtRecipe);
                            return dtRecipe;
                        }
                    }

                }

            }
        }

        protected void filterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("05_user_profile_cooking_history.aspx?Id = " + Session["user_id"]);
        }

        private DataTable GetDataUsers()
        {
            //Query from URL
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE Id=" + Session["user_id"]))
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

        private string CountRecipe()
        {
            string countStr = "";
            //string user_id = Request.QueryString["Id"];
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS totalRecipes FROM recipe WHERE verification_status=1 AND user_id =" + Session["user_id"]))
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