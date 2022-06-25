using System;
using System.Configuration;
using System.Data.SqlClient;


namespace DishADay
{
    public partial class _26_recipe_approve : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                // to retrive id value from URL
                int recipe_id = Convert.ToInt32(Request.QueryString["recipe_id"]);

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                string query = "UPDATE recipe SET verification_status = 1 WHERE recipe_id=" + recipe_id;

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                cmd.ExecuteNonQuery();

                Response.Redirect("10_admin_recipe_approval_list.aspx");
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

        }
    }
}