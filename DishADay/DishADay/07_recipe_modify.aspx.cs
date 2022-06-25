using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

namespace DishADay
{
    public partial class _07_recipe_modify : System.Web.UI.Page
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
                //close generate profile icon

                if (!IsPostBack)
                {
                    //retrieve id value from URL
                    string recipe_id = Request.QueryString["recipe_id"];
                    int intRecipe = Convert.ToInt32(recipe_id); //convert to integer

                    back_btn_literal.Text = "<a type='button' href='03_recipe.aspx?recipe_id=" + recipe_id +
                        "' class='btn btn-back' title='Go Back'><i class='fa-solid fa-angle-left'></i>Go Back</a>";


                    string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))

                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM recipe WHERE recipe_id=" + intRecipe))
                        {
                            using (SqlDataAdapter sda = new SqlDataAdapter())
                            {
                                cmd.Connection = con;
                                sda.SelectCommand = cmd;
                                using (DataTable dt = new DataTable())
                                {
                                    sda.Fill(dt);

                                    foreach (DataRow row in dt.Rows)
                                    {
                                        //Assign value from database to variable
                                        string recipe_img = row["recipe_img"].ToString();
                                        string recipe_title = row["recipe_title"].ToString();
                                        string recipe_caption = row["recipe_caption"].ToString();
                                        string cook_duration = row["cook_duration"].ToString();

                                        //Display image
                                        StringBuilder html2 = new StringBuilder();
                                        if (recipe_img == null || recipe_img == "")
                                        {
                                            recipe_img = "DishADayUploadImageDefalut.png";
                                        }
                                        html2.Append("<img id='frame' src='assets/recipe_upload/" + recipe_img + "' alt='image uploaded' class='img-fluid'/>");
                                        PlaceHolderImage.Controls.Add(new Literal { Text = html2.ToString() });

                                        //Display value in textbox
                                        this.HiddenField_id.Value = recipe_id;
                                        this.recipeTitle.Text = recipe_title;
                                        this.recipeDescription.Text = recipe_caption;
                                        this.durationTime.Text = cook_duration;

                                        //Display Ingredients
                                        StringBuilder html3 = new StringBuilder();
                                        string[] ingredients_array = row["recipe_ingredients"].ToString().TrimStart().TrimEnd(';').Split(new string[] { ";," }, StringSplitOptions.None);
                                        foreach (string ingredient in ingredients_array)
                                        {
                                            html3.Append("<li class='recipe-ingredient-list-item'>");
                                            html3.Append("<span class='span-recipe-ingredient'>" + ingredient + "</span>");
                                            html3.Append("</li>");
                                        }
                                        PlaceHolderIngredient.Controls.Add(new Literal { Text = html3.ToString() });

                                        //Display Steps
                                        StringBuilder html4 = new StringBuilder();
                                        string[] steps_array = row["recipe_steps"].ToString().TrimStart().TrimEnd(';').Split(new string[] { ";," }, StringSplitOptions.None);

                                        foreach (string step in steps_array)
                                        {
                                            html4.Append("<li class='recipe-step-list-item'>");
                                            html4.Append("<span class='span-recipe-step'>" + step + "</span>");
                                            html4.Append("</li>");
                                        }
                                        PlaceHolderStep.Controls.Add(new Literal { Text = html4.ToString() });

                                    }
                                }
                            }
                        }
                    }
                }


            }

        }

        protected void modify_Click(object sender, EventArgs e)
        {
            string recipe_id = Request.QueryString["recipe_id"];
            try
            {

                string ingredients = data_ingredient_array.Value;
                string steps = data_step_array.Value;

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                string query = "UPDATE recipe SET date_published=@date_published, recipe_title=@recipe_title, " +
                    "recipe_caption=@recipe_caption, cook_duration=@cook_duration, recipe_ingredients=@recipe_ingredients, " +
                    "recipe_steps=@recipe_steps WHERE recipe_id=@recipe_id ";

                SqlCommand cmd = new SqlCommand(query, con);

                //Date and Time Published
                DateTime now = DateTime.Now;
                cmd.Parameters.AddWithValue("@date_published", now);

                //others
                cmd.Parameters.AddWithValue("@recipe_id", HiddenField_id.Value);
                cmd.Parameters.AddWithValue("@recipe_title", recipeTitle.Text);
                cmd.Parameters.AddWithValue("@recipe_caption", recipeDescription.Text);
                cmd.Parameters.AddWithValue("@cook_duration", durationTime.Text);
                cmd.Parameters.AddWithValue("@recipe_ingredients", ingredients);
                cmd.Parameters.AddWithValue("@recipe_steps", steps);

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
