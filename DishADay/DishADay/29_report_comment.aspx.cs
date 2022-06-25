using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DishADay
{
    public partial class _29_report_comment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                // to retrieve id value from URL
                int comment_id = Convert.ToInt32(Request.QueryString["comment_id"]);

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                string query = "UPDATE comments SET comment_report_status = 1 WHERE comment_id=" + comment_id;

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                cmd.ExecuteNonQuery();

                //get recipe id from comment table
                DataTable dt = this.GetCommentsData();
                foreach (DataRow row in dt.Rows)
                {
                    Response.Redirect("03_recipe.aspx?recipe_id=" + row["recipe_id"]);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

        }

        private DataTable GetCommentsData()
        {
            int comment_id = Convert.ToInt32(Request.QueryString["comment_id"]);

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM comments WHERE comment_id=" + comment_id))
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