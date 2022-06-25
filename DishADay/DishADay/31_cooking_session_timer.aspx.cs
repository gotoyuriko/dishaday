using System;

namespace DishADay
{
    public partial class _31_cooking_session_timer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_name"] == null)
            {
                Response.Redirect("17_login.aspx");
            }
            else
            {
                string timer_min = Request.QueryString["timer_min"];
                string timer_step = Request.QueryString["timer_step"];

                timer_min_id.Value = timer_min;
                timer_step_id.Value = timer_step;

            }
        }
    }
}