using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

namespace DishADay
{
    public partial class _13_admin_report_recipe : System.Web.UI.Page
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
                    DataTable dtReportRecipe = this.GetReportRecipe();

                    //Building HTML string.
                    StringBuilder html = new StringBuilder();

                    //Building Reported Recipe Table
                    foreach (DataRow rowReportRecipe in dtReportRecipe.Rows)
                    {
                        //take user id from Recipe table
                        int report_user_id = Convert.ToInt32(rowReportRecipe["user_id"]);
                        string report_username = "";

                        //=== Get username from Users table by user id
                        DataTable dtUser = this.GetReportUser(report_user_id);
                        foreach (DataRow rowUser in dtUser.Rows)
                        {
                            report_username = rowUser["username"].ToString();
                        }

                        html.Append("<tr> ");
                        html.Append("<td>" + rowReportRecipe["recipe_id"] + "</td>");
                        html.Append("<td><a class='table-link' href='03_recipe.aspx?recipe_id=" + rowReportRecipe["recipe_id"] + "'>" + rowReportRecipe["recipe_title"] + "</a></td>");
                        html.Append("<td>" + report_username + "</td>");

                        DateTime dateAndTime = (DateTime)rowReportRecipe["date_published"];
                        var justDate = dateAndTime.ToString("yyyy-dd-MM");
                        html.Append("<td>" + justDate + "</td>");

                        //--buttons
                        html.Append("<td><a class='admin-table-btn' href='21_recipe_skip_admin.aspx?recipe_id=" + rowReportRecipe["recipe_id"] + "'>skip</a>");

                        html.Append("<a class='admin-table-btn' onClick=\"return confirm('Are you sure want to delete this recipe?')\"" +
                            " href='22_recipe_delete_admin.aspx?recipe_id=" + rowReportRecipe["recipe_id"] + "'>delete</a></td>");

                        html.Append("</tr> ");
                    }
                    //Append the HTML string to Placeholder.
                    PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

                }
            }
        }

        //Data table reported recipe
        private DataTable GetReportRecipe()
        {

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM recipe WHERE recipe_report_status=1"))
                {

                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dtReportRecipe = new DataTable())
                        {
                            sda.Fill(dtReportRecipe);
                            return dtReportRecipe;
                        }
                    }

                }

            }
        }

        //DataTable Users to get username
        private DataTable GetReportUser(int report_user_id)
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