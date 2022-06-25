using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DishADay
{
    public partial class _25_enquiry_delete_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                // to retrive id value from URL
                int enquiry_id = Convert.ToInt32(Request.QueryString["enquiry_id"]);

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                string query = "DELETE FROM enquiry WHERE enquiry_id=" + enquiry_id;

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                cmd.ExecuteNonQuery();

                Response.Redirect("12_admin_enquiry.aspx");
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

        }
    }
}