using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

namespace DishADay
{
    public partial class _10_admin_recipe_approval_list : System.Web.UI.Page
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
                    //Populating a DataTable from database.
                    DataTable dt = this.GetData();

                    //Building an HTML string.
                    StringBuilder html = new StringBuilder();

                    //Building the Data rows.
                    foreach (DataRow row in dt.Rows)
                    {
                        //Take user id from recipe table
                        int recipe_user_id = Convert.ToInt32(row["user_id"]);
                        string recipe_username = "";

                        //=== Get username from Users table by user id
                        DataTable dtUser = this.GetRecipeUser(recipe_user_id);
                        foreach (DataRow rowUser in dtUser.Rows)
                        {
                            recipe_username = rowUser["username"].ToString();
                        }

                        html.Append("<tr> ");
                        html.Append("<td>" + row["recipe_id"] + "</td>");
                        html.Append("<td><a class='table-link' href='11_admin_recipe_approval.aspx?recipe_id=" + row["recipe_id"] + "'>" + row["recipe_title"] + "</a></td>");
                        html.Append("<td>" + recipe_username + "</td>");

                        DateTime dateAndTime = (DateTime)row["date_published"];
                        var justDate = dateAndTime.ToString("yyyy-dd-MM");
                        html.Append("<td>" + justDate + "</td>");

                        html.Append("</tr> ");
                    }
                    //Append the HTML string to Placeholder.
                    PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

                }
            }
        }

        //Data table recipe pending approved
        private DataTable GetData()
        {

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM recipe WHERE verification_status=0"))
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


        //DataTable Users to get username
        private DataTable GetRecipeUser(int report_user_id)
        {
            string constr2 = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con2 = new SqlConnection(constr2))
            {

                using (SqlCommand cmd2 = new SqlCommand("SELECT * FROM users WHERE Id='" + report_user_id + "'"))
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
    }
}

