using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DishADay
{
    public partial class _22_recipe_delete_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                // to retrive id value from URL
                int recipe_id = Convert.ToInt32(Request.QueryString["recipe_id"]);

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                string query = "DELETE FROM comments WHERE recipe_id=" + recipe_id +
                    "; DELETE FROM cooking_history WHERE recipe_id=" + recipe_id +
                    "; DELETE FROM recipe WHERE recipe_id=" + recipe_id;

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