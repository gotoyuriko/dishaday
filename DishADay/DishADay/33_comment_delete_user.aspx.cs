using System;
using System.Configuration;
using System.Data.SqlClient;


namespace DishADay
{
    public partial class _33_comment_delete_user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                // to retrieve id value from URL
                int comment_id = Convert.ToInt32(Request.QueryString["comment_id"]);
                string recipe_id = Request.QueryString["recipe_id"];


                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                string query = "DELETE FROM comments WHERE comment_id=" + comment_id;

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                cmd.ExecuteNonQuery();

                Response.Redirect("03_recipe.aspx?recipe_id=" + recipe_id);



                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

        }

    }
}