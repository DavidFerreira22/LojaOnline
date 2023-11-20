using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Df;

namespace LojaOnline
{
    public partial class utilizadoresBackOffice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("home.aspx");
            }
        }

        protected void btn_submeter_Click(object sender, EventArgs e)
        {

            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "inserir_utilizador_admin";

            myCommand.Connection = myConn;
            myCommand.Parameters.AddWithValue("@nome", tb_nome.Text);
            myCommand.Parameters.AddWithValue("@cod_perfil", ddl_perfil.SelectedValue);
            myCommand.Parameters.AddWithValue("@email", tb_email.Text);
            myCommand.Parameters.AddWithValue("@pw", utils.EncryptString(tb_pw.Text));

            myConn.Open();

            myCommand.ExecuteNonQuery();

            myConn.Close();


           

           
        }
    }
}