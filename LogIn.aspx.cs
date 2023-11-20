using Df;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using ASPSnippets.GoogleAPI;
using System.Web.Script.Serialization;
using VisualStudioConfiguration;

namespace LojaOnline
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["18"] == null)
            {
                Response.Redirect("maior.aspx");
            }

            GoogleConnect.ClientId = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            GoogleConnect.ClientSecret = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
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
                    myCommand2.CommandText = "LogIn_Loja_google";

                    myCommand2.Connection = myConn2;
                    myCommand2.Parameters.AddWithValue("@util", profile.Email);

                    SqlParameter valor = new SqlParameter();
                    valor.ParameterName = "@retorno";
                    valor.Direction = ParameterDirection.Output;
                    valor.SqlDbType = SqlDbType.Int;

                    SqlParameter id = new SqlParameter();
                    id.ParameterName = "@id_utilizadores";
                    id.Direction = ParameterDirection.Output;
                    id.SqlDbType = SqlDbType.Int;

                    SqlParameter perfil = new SqlParameter();
                    perfil.ParameterName = "@cod_perfil";
                    perfil.Direction = ParameterDirection.Output;
                    perfil.SqlDbType = SqlDbType.Int;



                    myCommand2.Parameters.Add(valor);
                    myCommand2.Parameters.Add(id);
                    myCommand2.Parameters.Add(perfil);

                    myConn2.Open();
                    myCommand2.ExecuteNonQuery();
                    int respostaSP = Convert.ToInt32(myCommand2.Parameters["@retorno"].Value);
                    myConn2.Close();


                    if (respostaSP == 1)
                    {
                        //                   string Email = myCommand2.Parameters["email"].Value.ToString();
                        int userId = Convert.ToInt32(myCommand2.Parameters["@id_utilizadores"].Value);
                        int userPerfil = Convert.ToInt32(myCommand2.Parameters["@cod_perfil"].Value);
                        lbl_resposta.Text = "Sucesso";
                        Session["Utilizador"] = profile.Email;
                        Session["id_utilizador"] = userId;
                        Session["tipoPerfil"] = userPerfil;
                        //Session["mail"] = Email;

                        if (Session["TempId"] != null)
                        {
                            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

                            SqlCommand myCommand = new SqlCommand();

                            myCommand.CommandType = CommandType.StoredProcedure;
                            myCommand.CommandText = "UpdateCarrinho";

                            myCommand.Connection = myConn;
                            myCommand.Parameters.AddWithValue("@userId", userId);
                            myCommand.Parameters.AddWithValue("@TempId", Session["TempId"]);


                            myConn.Open();
                            myCommand.ExecuteNonQuery();
                            myConn.Close();
                            Response.Redirect("Checkout.aspx");
                        }
                        Response.Redirect("home.aspx");
                    }
                    else if (respostaSP == 2)
                    {
                        lbl_resposta.Text = "Inativo";
                    }
                    else
                    {
                        lbl_resposta.Text = "Fail";
                    }



                }
                if (Request.QueryString["error"] == "access_denied")
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Access denied.')", true);
                }
            }


        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "LogIn_Loja";

            myCommand.Connection = myConn;
            myCommand.Parameters.AddWithValue("@util", tb_nome.Text);
            myCommand.Parameters.AddWithValue("@pw", EncryptString(tb_pw.Text));

            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@retorno";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;

            SqlParameter id = new SqlParameter();
            id.ParameterName = "@id_utilizadores";
            id.Direction = ParameterDirection.Output;
            id.SqlDbType = SqlDbType.Int;

            SqlParameter perfil = new SqlParameter();
            perfil.ParameterName = "@cod_perfil";
            perfil.Direction = ParameterDirection.Output;
            perfil.SqlDbType = SqlDbType.Int;

            SqlParameter mail = new SqlParameter();
            mail.ParameterName = "@mail";
            mail.Direction = ParameterDirection.Output;
            mail.SqlDbType = SqlDbType.VarChar;
            mail.Size = 50;

            myCommand.Parameters.Add(valor);
            myCommand.Parameters.Add(id);
            myCommand.Parameters.Add(perfil);
            myCommand.Parameters.Add(mail);

            myConn.Open();
            myCommand.ExecuteNonQuery();
            int respostaSP = Convert.ToInt32(myCommand.Parameters["@retorno"].Value);


            if (respostaSP == 1)
            {
                int userId = Convert.ToInt32(myCommand.Parameters["@id_utilizadores"].Value);
                int userPerfil = Convert.ToInt32(myCommand.Parameters["@cod_perfil"].Value);
                string Email = myCommand.Parameters["@mail"].Value.ToString();
                lbl_resposta.Text = "Sucesso";
                Session["Utilizador"] = tb_nome.Text;
                Session["id_utilizador"] = userId;
                Session["tipoPerfil"] = userPerfil;
                Session["mail"] = Email;
                myConn.Close();

                if (Session["TempId"] != null)
                {
                    SqlConnection myConn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

                    SqlCommand myCommand2 = new SqlCommand();

                    myCommand2.CommandType = CommandType.StoredProcedure;
                    myCommand2.CommandText = "UpdateCarrinho";

                    myCommand2.Connection = myConn2;
                    myCommand2.Parameters.AddWithValue("@userId", userId);
                    myCommand2.Parameters.AddWithValue("@TempId", Session["TempId"]);


                    myConn2.Open();
                    myCommand2.ExecuteNonQuery();
                    myConn2.Close();
                    Response.Redirect("Checkout.aspx");
                }

                Response.Redirect("home.aspx");
            }
            else if (respostaSP == 2)
            {
                lbl_resposta.Text = "Inativo";
            }
            else
            {
                lbl_resposta.Text = "Fail";
            }

          

        }
        public static string EncryptString(string Message)
        {
            string enc = "";
            return enc;
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

            GoogleConnect.ClientId = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            GoogleConnect.ClientSecret = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
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
                    myCommand2.CommandText = "LogIn_Loja_google";

                    myCommand2.Connection = myConn2;
                    myCommand2.Parameters.AddWithValue("@util", profile.Email);

                    SqlParameter valor = new SqlParameter();
                    valor.ParameterName = "@retorno";
                    valor.Direction = ParameterDirection.Output;
                    valor.SqlDbType = SqlDbType.Int;

                    SqlParameter id = new SqlParameter();
                    id.ParameterName = "@id_utilizadores";
                    id.Direction = ParameterDirection.Output;
                    id.SqlDbType = SqlDbType.Int;

                    SqlParameter perfil = new SqlParameter();
                    perfil.ParameterName = "@cod_perfil";
                    perfil.Direction = ParameterDirection.Output;
                    perfil.SqlDbType = SqlDbType.Int;

                    

                    myCommand2.Parameters.Add(valor);
                    myCommand2.Parameters.Add(id);
                    myCommand2.Parameters.Add(perfil);

                    myConn2.Open();
                    myCommand2.ExecuteNonQuery();
                    int respostaSP = Convert.ToInt32(myCommand2.Parameters["@retorno"].Value);


                    if (respostaSP == 1)
                    {
     //                   string Email = myCommand2.Parameters["email"].Value.ToString();
                        int userId = Convert.ToInt32(myCommand2.Parameters["@id_utilizadores"].Value);
                        int userPerfil = Convert.ToInt32(myCommand2.Parameters["@cod_perfil"].Value);
                        lbl_resposta.Text = "Sucesso";
                        Session["Utilizador"] = profile.Email;
                        Session["id_utilizador"] = userId;
                        Session["tipoPerfil"] = userPerfil;
    //                    Session["mail"] = Email;
                        Response.Redirect("home.aspx");
                    }
                    else if (respostaSP == 2)
                    {
                        lbl_resposta.Text = "Inativo";
                    }
                    else
                    {
                        lbl_resposta.Text = "Fail";
                    }

                    myConn2.Close();

                }
                if (Request.QueryString["error"] == "access_denied")
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Access denied.')", true);
                }
            }

           

        }
       
    }
}