using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DishADay
{
    public partial class _32_cooking_session_note : System.Web.UI.Page
    {
        //=== UPDATE STATUS TO 'COMPLETED'
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                //get personal latest cooking id from personal history table
                int latest_cooking_id = 0;
                DataTable dtHistory = this.GetPersonalLatestHistory();
                foreach (DataRow rowHistory in dtHistory.Rows)
                {
                    latest_cooking_id = Convert.ToInt32(rowHistory["cooking_id"]);
                }

                string query = "UPDATE cooking_history SET cooking_status='completed' WHERE cooking_id='" + latest_cooking_id + "'";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        private DataTable GetPersonalLatestHistory()
        {

            // Retrieve id value
            int user_id = Convert.ToInt32(Session["user_id"]);
            int recipe_id = Convert.ToInt32(Request.QueryString["recipe_id"]);

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                //Take latest cooking id
                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM cooking_history WHERE user_id='" + user_id + "'AND recipe_id='" + recipe_id + "' ORDER BY cooking_id DESC "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dtHistory = new DataTable())
                        {
                            sda.Fill(dtHistory);
                            return dtHistory;
                        }
                    }
                }
            }

        }

        //UPDATE NOTES
        protected void submitCookingSessionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int user_id = Convert.ToInt32(Session["user_id"]);
                int recipe_id = Convert.ToInt32(Request.QueryString["recipe_id"]);

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                string query = "UPDATE cooking_history SET cooking_notes=@cooking_notes WHERE cooking_status='completed' AND user_id='" + user_id + "'AND recipe_id='" + recipe_id + "'";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@cooking_notes", cookingSessionNote.Text);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();
                Response.Write("<script> alert('Your Cooking Note has been saved. You can check in the cooking history page.'); window.location.href='03_recipe.aspx?recipe_id=" + recipe_id + "'; </script>");
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void go_back_to_recipe_Click(object sender, EventArgs e)
        {
            string recipe_id = Request.QueryString["recipe_id"];
            Response.Redirect("03_recipe.aspx?recipe_id=" + recipe_id);
        }

    }
}