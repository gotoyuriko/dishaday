using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DishADay
{
    public partial class _21_recipe_skip_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                // to retrieve id value from URL
                int recipe_id = Convert.ToInt32(Request.QueryString["recipe_id"]);

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                string query = "UPDATE recipe SET recipe_report_status = 0 WHERE recipe_id=" + recipe_id;

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                cmd.ExecuteNonQuery();

                Response.Redirect("13_admin_report_recipe.aspx");
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

        }
    }
}