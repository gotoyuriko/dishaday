using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

namespace DishADay

{
    public partial class _03_recipe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_name"] == null)
            {
                this.Literal1.Text = "<li class='nav - item mx - 3'><a href='17_login.aspx' class='btn loginsignup-button' type='menu' >Log In / Sign Up</a></li>";

                //comment section
                commentTextBox.Style.Add("display", "none");
                submitComment.Style.Add("display", "none");
                editComment.Style.Add("display", "none");
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

                //Admin cannot comment
                if (Convert.ToInt32(Session["role"]) == 2)
                {
                    //comment section
                    commentTextBox.Style.Add("display", "block");
                    submitComment.Style.Add("display", "block");
                    editComment.Style.Add("display", "none");
                }
                else if (Convert.ToInt32(Session["role"]) == 1)
                {
                    //comment section
                    commentTextBox.Style.Add("display", "none");
                    submitComment.Style.Add("display", "none");
                    editComment.Style.Add("display", "none");
                }


            }

            if (!this.IsPostBack)
            {
                //Populating a DataTable from database.
                DataTable dtRecipe = this.GetDataRecipe();

                //Building an HTML string.
                StringBuilder html2 = new StringBuilder();

                //======= Building Recipe Content
                foreach (DataRow rowRecipe in dtRecipe.Rows)
                {
                    //Imgage
                    string recipe_pic = rowRecipe["recipe_img"].ToString();

                    //=== Get full name
                    //Take user id from the recipe table
                    int user_id = Convert.ToInt32(rowRecipe["user_id"]);
                    string full_name = "";
                    string recipe_username = "";

                    DataTable dtUser = this.GetDataUsers(user_id);
                    foreach (DataRow rowUser in dtUser.Rows)
                    {
                        string first_name = rowUser["first_name"].ToString();
                        string last_name = rowUser["last_name"].ToString();
                        full_name = first_name + ' ' + last_name;
                        recipe_username = rowUser["username"].ToString();
                    }

                    //Breadcrumb
                    html2.Append("<div style=\"--bs-breadcrumb-divider:'>'\" aria-label='breadcrumb'>");
                    html2.Append("<ol class='breadcrumb'>");
                    html2.Append("<li class='breadcrumb-item'>");
                    html2.Append("<a href='01_home.aspx'>Home</a>");
                    html2.Append("</li>");
                    html2.Append("<li class='breadcrumb-item'>");
                    html2.Append("<a href='02_recipe_gallery.aspx'>Recipe Gallery</a>");
                    html2.Append("</li>");
                    html2.Append("<li class='breadcrumb-item active' aria-current='page'>" + rowRecipe["recipe_title"] + "</li>");
                    html2.Append("</ol>");
                    html2.Append("</div>");

                    //If registered users
                    if (Session["user_name"] != null)
                    {
                        //=== recipe-top-of-image
                        html2.Append("<div class='recipe-top-of-image row p-3 d-flex flex-row justify-content-between align-items-center'>");

                        //=== start-cooking-session-button
                        html2.Append("<div class='start-cooking-session-button col' data-bs-toggle='tooltip' data-bs-placement='top'>");
                        html2.Append("<button type='button' class='btn' title='Start Cooking Session' data-bs-toggle='modal' data-bs-target='#startCookingSession'>Start Cooking Session</button>");
                        html2.Append("</div>");


                        //if the recipe belongs to yours
                        if (Convert.ToInt32(Session["user_id"]) == user_id)
                        {
                            html2.Append("<div class='col d-flex flex-row justify-content-end align-items-center'>");
                            html2.Append("<a class='edit-btn btn' href='07_recipe_modify.aspx?recipe_id=" + rowRecipe["recipe_id"] + "'>Edit</a>");
                            html2.Append("<a onClick=\"return confirm('Are you sure you want to delete your recipe?')\" class='delete-btn btn' href='20_recipe_delete_user.aspx?recipe_id=" + rowRecipe["recipe_id"] + "'>Delete</a>");
                            html2.Append("</div>");
                        }
                        else //if recipe belongs to others
                        {
                            html2.Append("<div class='option-btn col d-flex flex-row justify-content-end align-items-center'>");
                            html2.Append("<a class='report-btn btn' onClick=\"if(confirm('Are you sure want to report this recipe?')){ alert('Successfully Report !'); }\" href='28_report_recipe.aspx?recipe_id=" + rowRecipe["recipe_id"] + "'>Report</a>");
                            html2.Append("</div>");
                        }
                        html2.Append("</div>");
                        //close recipe-top-of-image
                    }

                    //recipe-content-item
                    html2.Append("<div class='recipe-hero-wrap'>");

                    //--- recipe image 
                    html2.Append("<div class='text-center'>");
                    html2.Append("<img src =\"assets/recipe_upload/" + recipe_pic + "\" alt=\"food\" class =\"img-fluid\"/>");
                    html2.Append("</div>");

                    //--- recipe content
                    html2.Append("<h1 class='p-3'>" + rowRecipe["recipe_title"] + "</h1>");

                    //------row
                    html2.Append("<div class='p-3 row container-fluid pl-0'>");
                    //------ col
                    html2.Append("<div class='col-sm align-self-center'>");
                    html2.Append("<p class='recipe-username'><a href='04_user_profile_recipe.aspx?Id=" + user_id + "'><em>@" + recipe_username + "</a></em></p>");
                    html2.Append("<p class='recipe-fullname'><em><b><span>" + full_name + "</span></b></em></p>");
                    html2.Append("</div>");

                    //------ col
                    html2.Append("<div class='col-sm align-self-center'>");
                    DateTime dateAndTime = (DateTime)rowRecipe["date_published"];
                    string justDate = dateAndTime.ToString("yyyy-dd-MM");
                    html2.Append("<p class='recipe-date'><em><b>Date: </b>" + justDate + "</em></p>");
                    html2.Append("<p class='recipe-cook'><em><b>Cook: </b><span>" + rowRecipe["cook_duration"] + "</span> minutes</em></p>");
                    html2.Append("</div>");

                    html2.Append("</div>");

                    //--- caption
                    html2.Append("<p class='p-3 recipe-caption'>" + rowRecipe["recipe_caption"] + "</p>");
                    html2.Append("</div>");
                    //recipe-content-item
                }
                //Append the HTML string to Placeholder.
                PlaceHolder2.Controls.Add(new Literal { Text = html2.ToString() });


                //=====================INGREDIENT
                StringBuilder html3 = new StringBuilder();
                //Building the Data rows from recipe table.
                foreach (DataRow rowRecipe in dtRecipe.Rows)
                {
                    string[] ingredients_array = rowRecipe["recipe_ingredients"].ToString().TrimStart().TrimEnd(';').Split(new string[] { ";," }, StringSplitOptions.None);

                    foreach (string ingredient in ingredients_array)
                    {
                        html3.Append("<li>" + ingredient + "</li>");
                    }
                }
                PlaceHolder3.Controls.Add(new Literal { Text = html3.ToString() });



                //====================== STEP
                StringBuilder html4 = new StringBuilder();
                //Building the Data rows from recipe table.
                foreach (DataRow rowRecipe in dtRecipe.Rows)
                {
                    string[] steps_array = rowRecipe["recipe_steps"].ToString().TrimStart().TrimEnd(';').Split(new string[] { ";," }, StringSplitOptions.None);

                    foreach (string step in steps_array)
                    {
                        html4.Append("<li>" + step + "</li>");
                    }

                    html4.Append("</ul></div>");
                }
                PlaceHolder4.Controls.Add(new Literal { Text = html4.ToString() });

                //====================== COOKING SESSION
                if (Session["user_name"] != null)
                {
                    StringBuilder html6 = new StringBuilder();
                    html6.Append("<div class='start-cooking-session-button row d-flex justify-content-center' data-bs-toggle='tooltip' data-bs-placement='top'>");
                    html6.Append("<button type='button'  class='btn col text-center' title='Start Cooking Session' data-bs-toggle='modal' data-bs-target='#startCookingSession'>Start Cooking Session</button>");
                    html6.Append("</div>");
                    PlaceHolder6.Controls.Add(new Literal { Text = html6.ToString() });
                }

                //====================== COMMENT 
                DataTable dtComment = this.GetCommentData();

                StringBuilder html5 = new StringBuilder();

                //Building Data rows from comment table.
                foreach (DataRow rowComment in dtComment.Rows)
                {
                    int comment_id_query = Convert.ToInt32(Request.QueryString["comment_id"]);
                    if (Convert.ToInt32(rowComment["comment_id"]) != comment_id_query)
                    {
                        //=== Get full name and username from Users table
                        int userComment_id = Convert.ToInt32(rowComment["user_id"]);
                        string full_name = "";
                        string username = "";

                        DataTable dtUser = this.GetDataUsers(userComment_id);
                        foreach (DataRow rowUser in dtUser.Rows)
                        {
                            //Take name from the User table 
                            username = rowUser["username"].ToString();
                            string first_name = rowUser["first_name"].ToString();
                            string last_name = rowUser["last_name"].ToString();
                            full_name = first_name + ' ' + last_name;
                        }

                        html5.Append("<div class='comment-card card'>");
                        html5.Append("<div class='card-body row'>");
                        html5.Append("<div class='col d-flex justify-content-between'>");
                        html5.Append("<a class='user-comment-name' href='04_user_profile_recipe.aspx?Id=" + userComment_id + "'>");
                        html5.Append("<p><b>" + full_name + "</b>");
                        html5.Append("<span class='username text-muted'> @" + username + "</span></p>");
                        html5.Append("</a>");
                        //<a href='04_user_profile_recipe.aspx?Id=" + user_id + "'><em>@" + recipe_username + "</a>


                        //== report and delete comment for registered user           
                        if (Session["user_name"] != null && Session["role"].ToString() == "2")
                        {
                            int comment_user_id = Convert.ToInt32(rowComment["user_id"]);
                            string recipe_id = Request.QueryString["recipe_id"];


                            html5.Append("<div class='option-btn col d-flex flex-row justify-content-end align-items-center'>");

                            //comments not belongs to user
                            if (Convert.ToInt32(Session["user_id"]) != comment_user_id)
                            {
                                html5.Append("<a class='report-btn btn' onClick=\"if(confirm('Are you sure want to report this comment?')){ alert('Successfully Report !'); }\" href='29_report_comment.aspx?comment_id=" + rowComment["comment_id"] + "'>Report</a>");
                            }
                            //comments belongs to user
                            else
                            {

                                html5.Append("<a class='edit-btn btn' href='03_recipe.aspx?comment_id=" + rowComment["comment_id"] + "&&recipe_id=" + recipe_id + "'>Edit</a>");
                                html5.Append("<a class='delete-btn btn' onClick=\"return confirm('Are you sure you want to delete your comment?')\" href='33_comment_delete_user.aspx?comment_id=" + rowComment["comment_id"] + "&&recipe_id=" + recipe_id + "'>Delete</a>");
                            }

                            html5.Append("</div>");
                        }
                        //== end report and delete comment for registered user        

                        html5.Append("</div>");

                        html5.Append("<p class='comment'>" + rowComment["comment_post"] + "</p>");
                        html5.Append("<p class='commentDate text-muted'><time>" + rowComment["date_posted"] + "</time></p>");
                        html5.Append("</div>");
                        html5.Append("</div>");
                    }
                    else
                    {
                        commentTextBox.Text = rowComment["comment_post"].ToString();
                        submitComment.Style.Add("display", "none");
                        editComment.Style.Add("display", "block");
                    }
                }
                PlaceHolder5.Controls.Add(new Literal { Text = html5.ToString() });
            }
        }

        private DataTable GetDataRecipe()
        {
            // Retrieve recipe id from URL
            string recipe_id = Request.QueryString["recipe_id"];

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM recipe WHERE recipe_id='" + recipe_id + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dtRecipe = new DataTable())
                        {
                            sda.Fill(dtRecipe);
                            return dtRecipe;
                        }
                    }
                }
            }

        }

        //DataTable Users to get full name and username
        private DataTable GetDataUsers(int user_id)
        {
            string constr2 = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con2 = new SqlConnection(constr2))
            {

                using (SqlCommand cmd2 = new SqlCommand("SELECT * FROM users WHERE Id='" + user_id + "'"))
                {
                    using (SqlDataAdapter sda2 = new SqlDataAdapter())
                    {
                        cmd2.Connection = con2;
                        sda2.SelectCommand = cmd2;
                        using (DataTable dtUser = new DataTable())
                        {
                            sda2.Fill(dtUser);
                            return dtUser;
                        }
                    }
                }
            }
        }

        private DataTable GetCommentData()
        {
            int recipe_id = Convert.ToInt32(Request.QueryString["recipe_id"]);
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                //to restrive that belongs to user id after login
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM comments WHERE recipe_id=" + recipe_id))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dtComment = new DataTable())
                        {
                            sda.Fill(dtComment);
                            return dtComment;
                        }
                    }
                }
            }
        }

        //Insert data into comments table
        protected void submitComment_Click(object sender, EventArgs e)
        {
            SqlConnection con4 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {
                con4.Open();

                string query = "INSERT INTO comments (user_id, comment_post, " +
                    "date_posted, comment_report_status, recipe_id) values (@user_id," +
                    " @comment_post, @date_posted,  '" + 0 + "', @recipe_id)";

                SqlCommand cmd = new SqlCommand(query, con4);

                int user_id = Convert.ToInt16(Session["user_id"]);
                int recipe_id = Convert.ToInt32(Request.QueryString["recipe_id"]);

                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@comment_post", commentTextBox.Text);
                cmd.Parameters.AddWithValue("@recipe_id", recipe_id);

                //Date and Time
                DateTime now = DateTime.Now;
                cmd.Parameters.AddWithValue("@date_posted", now);


                cmd.ExecuteNonQuery();

                Response.Write("<script> alert('Comment Added!'); window.location.href = '03_recipe.aspx?recipe_id=" + recipe_id + "';</script>");


                con4.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void editComment_Click(object sender, EventArgs e)
        {
            try
            {
                string editedComment = commentTextBox.Text;
                DateTime now = DateTime.Now;
                int comment_id_query = Convert.ToInt32(Request.QueryString["comment_id"]);
                int recipe_id_query = Convert.ToInt32(Request.QueryString["recipe_id"]);

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                string query = "UPDATE comments SET date_posted=@date_posted, comment_post=@comment_post WHERE comment_id=" + comment_id_query;

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@date_posted", now);
                cmd.Parameters.AddWithValue("@comment_post", editedComment);
                con.Open();

                cmd.ExecuteNonQuery();

                Response.Redirect("03_recipe.aspx?recipe_id=" + recipe_id_query);

                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        //Insert data into cooking_history table
        protected void start_cooking_session_btn_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            // get the id value from the session and URL
            int user_id = Convert.ToInt32(Session["user_id"]);
            int recipe_id = Convert.ToInt32(Request.QueryString["recipe_id"]);

            try
            {
                con.Open();

                string query = "INSERT INTO cooking_history (user_id, cooking_date ,cooking_notes, recipe_id, cooking_status) values ('" + user_id + "', @cooking_date, @cooking_notes, '" + recipe_id + "', @cooking_status)";

                SqlCommand cmd = new SqlCommand(query, con);

                //Date
                DateTime now = DateTime.Now;
                cmd.Parameters.AddWithValue("@cooking_date", now);

                //cooking_notes
                cmd.Parameters.AddWithValue("@cooking_notes", "-");

                //cooking_status
                cmd.Parameters.AddWithValue("@cooking_status", "uncompleted");

                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

            string id = Request.QueryString["recipe_id"];
            Response.Redirect("30_cooking_session.aspx?recipe_id=" + id);
        }

    }
}