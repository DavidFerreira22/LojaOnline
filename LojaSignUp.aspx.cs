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
using ASPSnippets.GoogleAPI;
using System.Web.Script.Serialization;
using System.EnterpriseServices;

namespace LojaOnline
{
    public partial class LojaSignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["18"] == null)
            {
                Response.Redirect("maior.aspx");
            }

            GoogleConnect.ClientId = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            GoogleConnect.ClientSecret = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            GoogleConnect.RedirectUri = Request.Url.AbsoluteUri.Split('?')[0];
            if (!this.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["code"]))
                {
                    string code = Request.QueryString["code"];
                    string json = GoogleConnect.Fetch("me", code);
                    GoogleProfile profile = new JavaScriptSerializer().Deserialize<GoogleProfile>(json);
                    SqlConnection myConn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

                    SqlCommand myCommand2 = new SqlCommand();


                    myCommand2.CommandType = CommandType.StoredProcedure;
                    myCommand2.CommandText = "inserir_utilizador_Loja_google";

                    myCommand2.Connection = myConn2;
                    myCommand2.Parameters.AddWithValue("@nome", profile.Email);
                    myCommand2.Parameters.AddWithValue("@password", utils.EncryptString("Google User"));
                    myCommand2.Parameters.AddWithValue("@email", profile.Email);


                    SqlParameter valor = new SqlParameter();
                    valor.ParameterName = "@retorno";
                    valor.Direction = ParameterDirection.Output;
                    valor.SqlDbType = SqlDbType.Int;

                    myCommand2.Parameters.Add(valor);

                    myConn2.Open();
                    myCommand2.ExecuteNonQuery();
                    int respostaSP = Convert.ToInt32(myCommand2.Parameters["@retorno"].Value);
                    myConn2.Close();

                    if (respostaSP == 1)
                    {
                        
                        Response.Redirect("LogIn.aspx");
                    }
                    else
                        lbl_resposta.Text = "Fail";

                    if (Request.QueryString["error"] == "access_denied")
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Access denied.')", true);
                    }


                }
            }

        }

        protected void btn_registo_Click(object sender, EventArgs e)
        {
            if (tb_pw.Text != tb_pwConfirm.Text)
            {
                lbl_resposta.Text = "Palavras passe não são iguais";
                return;
            }

            if (utils.Validar(tb_pw.Text) != true)
            {
                lbl_resposta.Text = "Escreve uma palavra passe forte";
                return;
            }

            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "inserir_utilizador_Loja";

            myCommand.Connection = myConn;
            myCommand.Parameters.AddWithValue("@nome", tb_nome.Text);
            myCommand.Parameters.AddWithValue("@password", utils.EncryptString(tb_pw.Text));
            myCommand.Parameters.AddWithValue("@email", tb_email.Text);


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
                lbl_resposta.Text = "Ativa no email";

                SmtpClient servidor = new SmtpClient();
                MailMessage email = new MailMessage();


                email.From = new MailAddress("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                email.To.Add(new MailAddress(tb_email.Text));
                email.Subject = "Ativação de conta";

                email.IsBodyHtml = true;
                email.Body = "<b>Obrigado pelo registo na nossa aplicação. <br> Para ativar sua conta clique <a href='https://localhost:44342/ativacao.aspx?user=" + utils.EncryptString(tb_nome.Text) + "'>aqui<a></b>";
                string siteURL = ConfigurationManager.AppSettings["SiteURL"];

                servidor.Host = ConfigurationManager.AppSettings["SMTP_URL"];
                servidor.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_PORT"]);

                string user = ConfigurationManager.AppSettings["SMTP_USER"];
                string pass = ConfigurationManager.AppSettings["SMTP_PASSWORD"];

                servidor.Credentials = new NetworkCredential(user, pass);
                servidor.EnableSsl = true;
                servidor.Send(email);
                Response.Redirect("LogIn.aspx");
            }
            else
                lbl_resposta.Text = "Fail";


        }

        public class GoogleProfile
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Picture { get; set; }
            public string Email { get; set; }
            public string Verified_Email { get; set; }
        }

        protected void btn_google_Click(object sender, EventArgs e)
        {

            GoogleConnect.Authorize("profile", "email");

            GoogleConnect.ClientId = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            GoogleConnect.ClientSecret = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            GoogleConnect.RedirectUri = Request.Url.AbsoluteUri.Split('?')[0];
            string code = Request.QueryString["code"];
            string json = GoogleConnect.Fetch("me", code);

            GoogleProfile profile = new JavaScriptSerializer().Deserialize<GoogleProfile>(json);
            Response.Redirect("LogIn.aspx");
            //SqlConnection myConn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

            //SqlCommand myCommand2 = new SqlCommand();


            //myCommand2.CommandType = CommandType.StoredProcedure;
            //myCommand2.CommandText = "inserir_utilizador_Loja";

            //myCommand2.Connection = myConn2;
            //myCommand2.Parameters.AddWithValue("@nome", profile.Email);
            //myCommand2.Parameters.AddWithValue("@password", utils.EncryptString("Google User"));
            //myCommand2.Parameters.AddWithValue("@email", profile.Email);


            //SqlParameter valor = new SqlParameter();
            //valor.ParameterName = "@retorno";
            //valor.Direction = ParameterDirection.Output;
            //valor.SqlDbType = SqlDbType.Int;

            //myCommand2.Parameters.Add(valor);

            //myConn2.Open();
            //myCommand2.ExecuteNonQuery();
            //int respostaSP = Convert.ToInt32(myCommand2.Parameters["@retorno"].Value);
            //myConn2.Close();

            //if (respostaSP == 1)
            //{
            //    lbl_resposta.Text = "Ativa no email";

            //    SmtpClient servidor = new SmtpClient();
            //    MailMessage email = new MailMessage();


            //    email.From = new MailAddress("david.ferreira.17652@formandos.cinel.pt");
            //    email.To.Add(new MailAddress(profile.Email));
            //    email.Subject = "Ativação de conta";

            //    email.IsBodyHtml = true;
            //    email.Body = "<b>Obrigado pelo registo na nossa aplicação. <br> Para ativar sua conta clique <a href='https://localhost:44342/ativacao.aspx?user=" + utils.EncryptString(tb_nome.Text) + "'>aqui<a></b>";
            //    string siteURL = ConfigurationManager.AppSettings["SiteURL"];

            //    servidor.Host = ConfigurationManager.AppSettings["SMTP_URL"];
            //    servidor.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_PORT"]);

            //    string user = ConfigurationManager.AppSettings["SMTP_USER"];
            //    string pass = ConfigurationManager.AppSettings["SMTP_PASSWORD"];

            //    servidor.Credentials = new NetworkCredential(user, pass);
            //    servidor.EnableSsl = true;
            //    servidor.Send(email);
            //    Response.Redirect("LogIn.aspx");
            //}
            //else
            //    lbl_resposta.Text = "Fail";
            //if (Request.QueryString["error"] == "access_denied")
            //{
            //    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Access denied.')", true);
            //}



        }
    }
}