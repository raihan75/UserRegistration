using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserRegistration
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Registration(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        protected void Login(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

    }
}