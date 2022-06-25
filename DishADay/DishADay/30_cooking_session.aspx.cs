using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DishADay
{
    public partial class _30_cooking_session : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_name"] == null)
            {
                Response.Redirect("17_login.aspx");
            }
            else
            {
                DataTable dt = this.GetData();
                foreach (DataRow row in dt.Rows)
                {
                    //Pass C# Array Data to JS
                    string steps_array_modal = row["recipe_steps"].ToString();
                    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    var js_step_array = serializer.Serialize(steps_array_modal);
                    modal_steps_array.Value = js_step_array;
                }

            }

        }

        //Get Recipe_Id
        private DataTable GetData()
        {
            //recipe_id
            string recipe_id = Request.QueryString["recipe_id"];

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                //to restrive that belongs to user id after login
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM recipe WHERE recipe_id='" + recipe_id + "'"))
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

        protected void finishBtn_Click(object sender, EventArgs e)
        {
            string recipe_id = Request.QueryString["recipe_id"];
            Response.Redirect("32_cooking_session_note.aspx?recipe_id=" + recipe_id);
        }

        protected void go_to_timer_btn_Click(object sender, EventArgs e)
        {
            string timer_min = timerMinHiddenControl.Value;
            string timer_step = timerStepHiddenControl.Value;
            Response.Redirect("31_cooking_session_timer.aspx?timer_min=" + timer_min + "&&timer_step=" + timer_step);
        }

        protected void go_back_to_recipe_Click(object sender, EventArgs e)
        {
            string recipe_id = Request.QueryString["recipe_id"];
            Response.Redirect("03_recipe.aspx?recipe_id=" + recipe_id);
        }
    }
}