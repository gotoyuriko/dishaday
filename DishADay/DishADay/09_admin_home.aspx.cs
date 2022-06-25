using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

namespace DishADay
{
    public partial class _09_admin_home : System.Web.UI.Page
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
                }
                html.Append("<i class=\"fa-solid fa-user\"></i></a></li>");
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
                this.Literal3.Text = "<span>" + Session["full_name"].ToString() + "</span>";
                this.Literal1.Text = "<li class='nav-item mx-3'><a href='19_logout.aspx' class='btn loginsignup-button' type='menu' >Log Out</a></li>";
            }

            //=== displaying count value
            StringBuilder html2 = new StringBuilder();
            html2.Append(CalcPendingRecipe().ToString());
            PlaceHolder2.Controls.Add(new Literal { Text = html2.ToString() });

            StringBuilder html3 = new StringBuilder();
            html3.Append(CalcEnquiry().ToString());
            PlaceHolder3.Controls.Add(new Literal { Text = html3.ToString() });

            StringBuilder html4 = new StringBuilder();
            html4.Append(CalcTotalReportRecipes().ToString());
            PlaceHolder4.Controls.Add(new Literal { Text = html4.ToString() });

            StringBuilder html5 = new StringBuilder();
            html5.Append(CalcTotalReportComments().ToString());
            PlaceHolder5.Controls.Add(new Literal { Text = html5.ToString() });

            StringBuilder html6 = new StringBuilder();
            html6.Append(CalcTotalRecipes().ToString());
            PlaceHolder6.Controls.Add(new Literal { Text = html6.ToString() });

            StringBuilder html7 = new StringBuilder();
            html7.Append(CalcTotalUsers().ToString());
            PlaceHolder7.Controls.Add(new Literal { Text = html7.ToString() });
        }

        private string CalcPendingRecipe()
        {
            string countStr = "";
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS pendingRecipe FROM recipe WHERE verification_status = 0"))
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

                                countStr = row["pendingRecipe"].ToString();

                            }
                        }
                    }
                }
            }
            return countStr;
        }

        private string CalcEnquiry()
        {
            string countStr = "";
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS totalEnquiry FROM enquiry "))
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

                                countStr = row["totalEnquiry"].ToString();

                            }
                        }
                    }
                }
            }
            return countStr;
        }

        private string CalcTotalReportRecipes()
        {
            string countStr = "";
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS totalReportRecipes FROM recipe WHERE recipe_report_status = 1"))
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

                                countStr = row["totalReportRecipes"].ToString();

                            }
                        }
                    }
                }
            }
            return countStr;
        }

        private string CalcTotalReportComments()
        {
            string countStr = "";
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS totalReportComments FROM comments WHERE comment_report_status = 1"))
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

                                countStr = row["totalReportComments"].ToString();

                            }
                        }
                    }
                }
            }
            return countStr;
        }

        private string CalcTotalRecipes()
        {
            string countStr = "";
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS totalRecipes FROM recipe WHERE verification_status = 1"))
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

        private string CalcTotalUsers()
        {
            string countStr = "";
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS totalUsers FROM users WHERE role = 2"))
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

                                countStr = row["totalUsers"].ToString();

                            }
                        }
                    }
                }
            }
            return countStr;
        }



    }
}