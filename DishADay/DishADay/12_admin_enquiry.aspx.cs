using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

namespace DishADay
{
    public partial class _12_admin_enquiry : System.Web.UI.Page
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
                        html.Append("<tr> ");
                        html.Append("<td>" + row["enquiry_id"] + "</td>");
                        html.Append("<td class='td_enquiry'><a class='table-link' data-bs-toggle=\"modal\" data-bs-target=\"#viewEnquiriesModal\">"
                            + row["enquiry"] + "</a></td>");
                        html.Append("<td class='td_name'>" + row["enquiry_name"] + "</td>");
                        html.Append("<td class='td_email'>" + row["enquiry_email"] + "</td>");

                        DateTime dateAndTime = (DateTime)row["enquiry_date"];
                        var justDate = dateAndTime.ToString("yyyy-dd-MM");
                        html.Append("<td>" + justDate + "</td>");

                        html.Append("<td><a class='admin-table-btn' onClick=\"return confirm('Are you sure want to delete this enquiry?')\" href='25_enquiry_delete_admin.aspx?enquiry_id=" + row["enquiry_id"] + "'>delete</td>");

                        html.Append("</tr>");
                    }

                    //Append the HTML string to Placeholder.
                    PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
                }
            }
        }
        private DataTable GetData()
        {

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM enquiry"))
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