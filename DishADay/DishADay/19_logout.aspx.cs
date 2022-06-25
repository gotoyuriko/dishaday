using System;

namespace DishADay
{
    public partial class _19_logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("01_home.aspx");
        }
    }
}