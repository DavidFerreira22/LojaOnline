using Df;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LojaOnline
{
    public partial class RecuperarPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["18"] == null)
            {
                Response.Redirect("maior.aspx");
            }
        }

        protected void btn_recuperar_Click(object sender, EventArgs e)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "recuperar_Loja";

            myCommand.Connection = myConn;
            myCommand.Parameters.AddWithValue("@email",tb_email.Text);
            //myCommand.Parameters.AddWithValue("@pw", utils.EncryptString(newPW));

            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@retorno";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;

            myCommand.Parameters.Add(valor);

            myConn.Open();
            myCommand.ExecuteNonQuery();
            int respostaSP = Convert.ToInt32(myCommand.Parameters["@retorno"].Value);
            myConn.Close();

            if (respostaSP == 1)
            {

                SqlConnection myConn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

                SqlCommand myCommand2 = new SqlCommand();

                myCommand.CommandType = CommandType.StoredProcedure;

                myCommand2.CommandType = CommandType.StoredProcedure;
                myCommand2.CommandText = "mudarPW_Loja";

                myCommand2.Connection = myConn2;
                myCommand2.Parameters.AddWithValue("@email", tb_email.Text);
                myCommand2.Parameters.AddWithValue("@pw", utils.EncryptString(tb_pw.Text));
                myConn2.Open();
                myCommand2.ExecuteNonQuery();
                myConn2.Close();

                SmtpClient servidor = new SmtpClient();
                MailMessage email = new MailMessage();


                email.From = new MailAddress("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                email.To.Add(new MailAddress(tb_email.Text));
                email.Subject = "Recuperação de Palavra Passe";

                email.IsBodyHtml = true;
                email.Body = $"<b> Foi atualizada a sua palavra passe com sucesso. </b>";
                string siteURL = ConfigurationManager.AppSettings["SiteURL"];

                servidor.Host = ConfigurationManager.AppSettings["SMTP_URL"];
                servidor.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_PORT"]);

                string user = ConfigurationManager.AppSettings["SMTP_USER"];
                string pass = ConfigurationManager.AppSettings["SMTP_PASSWORD"];

                servidor.Credentials = new NetworkCredential(user, pass);
                servidor.EnableSsl = true;
                servidor.Send(email);

                lbl_resposta.Text = "Vê o email!";

                Response.Redirect("logIn.aspx");
            }
            else if (respostaSP == 2)
            {
                lbl_resposta.Text = "Inativo vai ativar a conta primeiro";

            }
            else
                lbl_resposta.Text = "Não existes";


        }
    }
}