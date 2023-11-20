using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Df;

namespace LojaOnline
{
    public partial class loginBackOffice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "loginBack";

            myCommand.Connection = myConn;
            myCommand.Parameters.AddWithValue("@util", tb_nome.Text);
            myCommand.Parameters.AddWithValue("@pw", utils.EncryptString(tb_pw.Text));

            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@retorno";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;


            myCommand.Parameters.Add(valor);

            myConn.Open();
            myCommand.ExecuteNonQuery();
            int respostaSP = Convert.ToInt32(myCommand.Parameters["@retorno"].Value);


            if (respostaSP == 1)
            {
                lbl_resposta.Text = "Sucesso";
                Session["Utilizador"] = tb_nome.Text;
                Session["Admin"] = respostaSP + 1000;
                Response.Redirect("homeBackOffice.aspx");
            }
            else
            {
                lbl_resposta.Text = "Fail";

            }

            myConn.Close();

        }
    }
}