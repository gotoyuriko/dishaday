using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

namespace DishADay
{
    public partial class _15_admin_info_recipe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //LogIn LogOut
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
                PlaceHolder2.Controls.Add(new Literal { Text = html2.ToString() });

                this.Literal1.Text = "<li class='nav-item mx-3'><a href='19_logout.aspx' class='btn loginsignup-button' type='menu' >Log Out</a></li>";

                if (!this.IsPostBack)
                {
                    string searchkey = Request.QueryString["searchkey"];


                    //Populating a DataTable from database.
                    DataTable dt = this.GetRecipeData(searchkey);

                    //Building an HTML string.
                    StringBuilder html = new StringBuilder();

                    //Building the Data rows.
                    foreach (DataRow rowRecipe in dt.Rows)
                    {
                        //Take user id from Recipe table
                        int recipe_user_id = Convert.ToInt32(rowRecipe["user_id"]);
                        string recipe_username = "";

                        //=== Get username from Users table by user id
                        DataTable dtUser = this.GetUserData(recipe_user_id);
                        foreach (DataRow rowUser in dtUser.Rows)
                        {
                            recipe_username = rowUser["username"].ToString();
                        }

                        html.Append("<tr> ");
                        html.Append("<td>" + rowRecipe["recipe_id"] + "</td>");
                        html.Append("<td><a class='table-link' href='03_recipe.aspx?recipe_id=" + rowRecipe["recipe_id"] + "'>" + rowRecipe["recipe_title"] + "</a></td>");
                        html.Append("<td>" + recipe_username + "</td>");

                        DateTime dateAndTime = (DateTime)rowRecipe["date_published"];
                        var justDate = dateAndTime.ToString("yyyy-dd-MM");
                        html.Append("<td>" + justDate + "</td>");

                        html.Append("</tr> ");
                    }
                    //Append the HTML string to Placeholder.
                    PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

                }
            }
        }
        private DataTable GetRecipeData(string searchkey)
        {

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                //to restrive that belongs to user id after login
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM recipe WHERE verification_status=1 AND recipe_title LIKE '%" + searchkey + "%'"))

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


        //DataTable Users to get author's username
        private DataTable GetUserData(int recipe_user_id)
        {
            string constr2 = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con2 = new SqlConnection(constr2))
            {

                using (SqlCommand cmd2 = new SqlCommand("SELECT * FROM users WHERE Id='" + recipe_user_id + "'"))
                {
                    using (SqlDataAdapter sda2 = new SqlDataAdapter())
                    {
                        cmd2.Connection = con2;
                        sda2.SelectCommand = cmd2;
                        using (DataTable dtUser = new DataTable())
                        {
                            sda2.Fill(dtUser);
                            return dtUser;
                        }
                    }
                }
            }
        }
        protected void search_btn_Click(object sender, EventArgs e)
        {
            string searchKeyword = adminRecipeInfoSearch.Text;

            Response.Redirect("15_admin_info_recipe.aspx?searchkey=" + searchKeyword);
        }


    }
}