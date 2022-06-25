using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

namespace DishADay
{
    public partial class _06_recipe_upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_name"] == null)
            {
                Response.Redirect("17_login.aspx");
            }
            else
            {
                //generate profile icons
                StringBuilder html = new StringBuilder();
                html.Append("<li class=\"nav-item mx-3\">");
                if (Convert.ToInt32(Session["role"]) == 1)
                {
                    //admin go to the admin home page
                    html.Append("<a class='btn loginsignup-button' type='menu' href='09_admin_home.aspx'>");
                }
                else
                {
                    //users go to the user profile page
                    html.Append("<a class='btn loginsignup-button' type='menu' href='04_user_profile_recipe.aspx?Id=" + Session["user_id"] + "'>");
                }
                html.Append("<i class=\"fa-solid fa-user\"></i></a></li>");
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
                this.Literal1.Text = "<li class='nav-item mx-3'><a href='19_logout.aspx' class='btn loginsignup-button' type='menu' >Log Out</a></li>";
                back_btn_literal.Text = "<a type='button' href='04_user_profile_recipe.aspx?Id=" + Session["user_id"] + "' class='btn btn-back' title='Go Back'><i class='fa-solid fa-angle-left'></i>Go Back</a>";
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            //to get the user id value from the session
            int user_id = Convert.ToInt16(Session["user_id"]);
            string ingredients = data_ingredient_array.Value;
            string steps = data_step_array.Value;

            try
            {
                con.Open();

                string query = "INSERT INTO recipe (user_id, date_published, recipe_img, recipe_title, recipe_caption, cook_duration, recipe_ingredients, recipe_steps, verification_status, recipe_report_status) values ('" + user_id + "', @date_published, @recipe_img, @recipe_title, @recipe_caption, @cook_duration, @recipe_ingredients, @recipe_steps, '" + 0 + "', '" + 0 + "')";

                SqlCommand cmd = new SqlCommand(query, con);

                //Date and Time Published
                DateTime now = DateTime.Now;
                cmd.Parameters.AddWithValue("@date_published", now);
                //recipe_img
                string file_name = formFile.FileName.ToString();
                formFile.PostedFile.SaveAs(Server.MapPath("~/assets/recipe_upload/") + file_name);
                cmd.Parameters.AddWithValue("@recipe_img", file_name);

                //recipe_title, recipe_caption, cook_duration
                cmd.Parameters.AddWithValue("@recipe_title", recipeTitle.Text);
                cmd.Parameters.AddWithValue("@recipe_caption", recipeDescription.Text);
                cmd.Parameters.AddWithValue("@cook_duration", durationTime.Text);

                //Recipe Ingredients, Recipe Steps
                cmd.Parameters.AddWithValue("@recipe_ingredients", ingredients);
                cmd.Parameters.AddWithValue("@recipe_steps", steps);

                cmd.ExecuteNonQuery();

                Response.Write("<script> alert('Successfully Submitted! Please wait until admin approve your recipe.'); window.location.href = '04_user_profile_recipe.aspx?Id=" + Session["user_id"] + "';</script>");

                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void confirm_clear_Click(object sender, EventArgs e)
        {
            recipeTitle.Text = "";
            recipeDescription.Text = "";
            durationTime.Text = "";
        }


    }

}