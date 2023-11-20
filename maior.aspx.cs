using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LojaOnline
{
    public partial class maior : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_yes_Click(object sender, EventArgs e)
        {
            Session["18"] = 1;
            Response.Redirect("home.aspx");
        }

        protected void btns_no_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.google.pt/");
        }
    }
}