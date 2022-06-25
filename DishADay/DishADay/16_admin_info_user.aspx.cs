using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

namespace DishADay
{
    public partial class _16_admin_info_user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //LogIn Log Out
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
                    DataTable dt = this.GetData(searchkey);

                    //Building an HTML string.
                    StringBuilder html = new StringBuilder();

                    //Building user info table
                    foreach (DataRow row in dt.Rows)
                    {
                        html.Append("<tr> ");
                        html.Append("<td>" + row["Id"] + "</td>");
                        html.Append("<td><a class='table-link' href='04_user_profile_recipe.aspx?Id=" + row["Id"] + "'>" + row["username"] + "</a></td>");
                        html.Append("<td>" + row["email"] + "</td>");

                        DateTime dateAndTime = (DateTime)row["birth_date"];
                        var justDate = dateAndTime.ToString("yyyy-dd-MM");
                        html.Append("<td>" + justDate + "</td>");

                        string user_id = row["Id"].ToString();
                        html.Append("<td>" + CalcRecipe(user_id) + "</td>");

                        html.Append("</tr> ");
                    }
                    //Append the HTML string to Placeholder.
                    PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

                }
            }
        }

        private DataTable GetData(string searchkey)
        {

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                //to restrive that belongs to user id after login
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE role =2 AND username LIKE '%" + searchkey + "%'"))

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

        protected void search_btn_Click(object sender, EventArgs e)
        {
            string searchKeyword = adminUserInfoSearch.Text;

            Response.Redirect("16_admin_info_user.aspx?searchkey=" + searchKeyword);
        }

        private string CalcRecipe(string user_id)
        {
            string countStr = "";
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