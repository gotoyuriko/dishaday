using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DishADay
{
    public partial class _23_comment_skip_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                // to retrieve id value from URL
                int comment_id = Convert.ToInt32(Request.QueryString["comment_id"]);

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                string query = "UPDATE comments SET comment_report_status = 0 WHERE comment_id=" + comment_id;

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                cmd.ExecuteNonQuery();

                Response.Redirect("14_admin_report_comment.aspx");
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

        }
    }
}