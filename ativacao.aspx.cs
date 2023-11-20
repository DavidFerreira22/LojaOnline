using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Df;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace LojaOnline
{
    public partial class ativacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string utilizador = utils.DecryptString(Request.QueryString["user"]);
            //Response.Write(utilizador);
            //Response.End();
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "ativacao";

            myCommand.Connection = myConn;
            myCommand.Parameters.AddWithValue("@util", utilizador);

            myConn.Open();
            myCommand.ExecuteNonQuery();
            myConn.Close();
            Response.Redirect("LogIn.aspx");

        }
    }
}