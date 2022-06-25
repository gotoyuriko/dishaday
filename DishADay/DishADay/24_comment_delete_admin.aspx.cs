using System;
using System.Configuration;
using System.Data.SqlClient;


namespace DishADay
{
    public partial class _24_comment_delete_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                // to retrive id value from URL
                int comment_id = Convert.ToInt32(Request.QueryString["comment_id"]);

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                string query = "DELETE FROM comments WHERE comment_id=" + comment_id;

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