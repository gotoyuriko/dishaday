using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

namespace DishADay
{
    public partial class _11_admin_recipe_approval : System.Web.UI.Page
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
                StringBuilder html2 = new StringBuilder();
                html2.Append("<li class=\"nav-item mx-3\">");
                if (Convert.ToInt32(Session["role"]) == 1)
                {
                    //admin go to the admin home page
                    html2.Append("<a class='btn loginsignup-button' type='menu' href='09_admin_home.aspx'>");
                }
                else
                {
                    //users go to the user profile page
                    html2.Append("<a class='btn loginsignup-button' type='menu' href='04_user_profile_recipe.aspx?Id=" + Session["user_id"] + "'>");
                }
                html2.Append("<i class=\"fa-solid fa-user\"></i></a></li>");
                PlaceHolder1.Controls.Add(new Literal { Text = html2.ToString() });
                this.Literal1.Text = "<li class='nav-item mx-3'><a href='19_logout.aspx' class='btn loginsignup-button' type='menu' >Log Out</a></li>";
            }
            if (!this.IsPostBack)
            {
                //Populating a DataTable from database recipe.
                DataTable dt = this.GetData();

                //Building an HTML string.
                StringBuilder html2 = new StringBuilder();
                //Building the Data rows from recipe table.
                foreach (DataRow row in dt.Rows)
                {

                    //Imgage
                    string recipe_pic = row["recipe_img"].ToString();

                    //Full Name and username
                    string full_name = "fullname";
                    string recipe_username = "";


                    //Take user id from the recipe table
                    int user_id = Convert.ToInt32(row["user_id"]);

                    DataTable dtUser = this.GetRecipeUser(user_id);
                    foreach (DataRow rowUser in dtUser.Rows)
                    {
                        //Get full name from Users table by user id
                        string first_name = rowUser["first_name"].ToString();
                        string last_name = rowUser["last_name"].ToString();
                        full_name = first_name + ' ' + last_name;

                        //Get username from Users table by user id
                        recipe_username = rowUser["username"].ToString();

                    }


                    //recipe-content-item
                    html2.Append("<div class='recipe-hero-wrap'>");
                    //--- recipe image 
                    html2.Append("<div class='text-center'>");
                    html2.Append("<img src =\"assets/recipe_upload/" + recipe_pic + "\" alt=\"food\" class =\"img-fluid\"/>");
                    html2.Append("</div>");

                    //--- recipe content
                    html2.Append("<h1 class='p-3'>" + row["recipe_title"] + "</h1>");

                    //------row
                    html2.Append("<div class='p-3 row container-fluid pl-0'>");
                    //------ col
                    html2.Append("<div class='col-sm align-self-center'>");
                    html2.Append("<p class='recipe-username'><a href='04_user_profile_recipe.aspx?Id=" + user_id + "'><em>@" + recipe_username + "</a></em></p>");
                    html2.Append("<p class='recipe-fullname'><em><b><span>" + full_name + "</span></b></em></p>");
                    html2.Append("</div>");

                    //------ col
                    html2.Append("<div class='col-sm align-self-center'>");
                    DateTime dateAndTime = (DateTime)row["date_published"];
                    string justDate = dateAndTime.ToString("yyyy-dd-MM");
                    html2.Append("<p class='recipe-date'><em><b>Date: </b>" + justDate + "</em></p>");
                    html2.Append("<p class='recipe-cook'><em><b>Cook: </b><span>" + row["cook_duration"] + "</span> minutes</em></p>");
                    html2.Append("</div>");

                    html2.Append("</div>");

                    //--- caption
                    html2.Append("<p class='p-3 recipe-caption'>" + row["recipe_caption"] + "</p>");
                    html2.Append("</div>");
                    //close recipe-content-item
                }

                //Append the HTML string to Placeholder.
                PlaceHolder2.Controls.Add(new Literal { Text = html2.ToString() });


                //=====================INGREDIENT
                StringBuilder html3 = new StringBuilder();
                //Building the Data rows from recipe table.
                foreach (DataRow row in dt.Rows)
                {
                    string[] ingredients_array = row["recipe_ingredients"].ToString().TrimStart().TrimEnd(';').Split(new string[] { ";," }, StringSplitOptions.None);

                    foreach (string ingredient in ingredients_array)
                    {
                        html3.Append("<li>" + ingredient + "</li>");
                    }
                }
                PlaceHolder3.Controls.Add(new Literal { Text = html3.ToString() });



                //======================STEP
                StringBuilder html4 = new StringBuilder();
                //Building the Data rows from recipe table.
                foreach (DataRow row in dt.Rows)
                {
                    string[] steps_array = row["recipe_steps"].ToString().TrimStart().TrimEnd(';').Split(new string[] { ";," }, StringSplitOptions.None);

                    foreach (string step in steps_array)
                    {
                        html4.Append("<li>" + step + "</li>");
                    }

                    html4.Append("</ul></div>");
                }
                PlaceHolder4.Controls.Add(new Literal { Text = html4.ToString() });


                //buttons
                StringBuilder html5 = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    html5.Append("<div class='recipe-approval-action '>");
                    html5.Append("<a class='recipe-approval-action-btn' href='26_recipe_approve.aspx?recipe_id=" + row["recipe_id"] + "'>Approve</a>");
                    html5.Append("<a class='recipe-approval-action-btn' onClick=\"return confirm('Are you sure want to reject this recipe?')\" href='27_recipe_reject.aspx?recipe_id=" + row["recipe_id"] + "'>Reject</a>");
                    html5.Append("</div>");

                    PlaceHolder5.Controls.Add(new Literal { Text = html5.ToString() });
                }

            }
        }

        //Get Recipe_Id
        private DataTable GetData()
        {
            //recipe_id
            string recipe_id = Request.QueryString["recipe_id"];

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                //to restrive that belongs to user id after login
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM recipe WHERE recipe_id='" + recipe_id + "'"))
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

        //DataTable get Recipe author data
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
    }
}
