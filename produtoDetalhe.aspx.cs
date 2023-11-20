using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LojaOnline
{
    public partial class produtoDetalhe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["18"] == null)
            {
                Response.Redirect("maior.aspx");
            }

            string ProductID = Request.QueryString["id"];

            int Perfil = Convert.ToInt32(Session["tipoPerfil"]);

            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "Produto_Detalhe";

            myCommand.Connection = myConn;
            myCommand.Parameters.AddWithValue("@ID", ProductID);



            myConn.Open();
            SqlDataReader dr = myCommand.ExecuteReader();
            if (dr.Read())
            {
                lbl_produto.Text = dr["nome"].ToString();

                if (Perfil == 2 || Perfil == 1)
                {
                    lbl_precoRazorado.Visible = true;
                    lbl_precoRazorado.Text = Math.Round((Convert.ToDouble(dr["preco"]) / 100), 2).ToString() + "€";
                    lbl_preco.Text = Math.Round((Convert.ToDouble(dr["preco"]) / 123)).ToString() + "€";
                }
                else
                {
                    lbl_preco.Text = (Convert.ToDouble(dr["preco"]) / 100).ToString() + "€";
                    lbl_precoRazorado.Visible = false;
                }
                lbl_descricao.Text = dr["descricao"].ToString();

                byte[] imageData = (byte[])dr["imagem"];
                string base64String = Convert.ToBase64String(imageData);
                imagem.ImageUrl = "data:image/png;base64," + base64String;
            }
            //myCommand.ExecuteNonQuery();

            myConn.Close();
        }

        protected void btn_adicionar_Click(object sender, EventArgs e)
        {
            if (Session["Utilizador"] == null)
            {
                int ProductID = int.Parse(Request.QueryString["id"]);

                SqlConnection myConn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

                SqlCommand myCommand2 = new SqlCommand();

                myCommand2.CommandType = CommandType.StoredProcedure;
                myCommand2.CommandText = "inserir_carrinhoTemp";

                myCommand2.Connection = myConn2;
                myCommand2.Parameters.AddWithValue("@cod_Temp", Session["TempId"]);
                myCommand2.Parameters.AddWithValue("@cod_produto", ProductID);

                myConn2.Open();

                myCommand2.ExecuteNonQuery();

                myConn2.Close();

                Response.Redirect("carrinho.aspx");
            }
            else 
            {
                int ProductID = int.Parse(Request.QueryString["id"]);

                SqlConnection myConn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

                SqlCommand myCommand2 = new SqlCommand();

                myCommand2.CommandType = CommandType.StoredProcedure;
                myCommand2.CommandText = "inserir_carrinho";

                myCommand2.Connection = myConn2;
                myCommand2.Parameters.AddWithValue("@cod_utilizador", Session["id_utilizador"]);
                myCommand2.Parameters.AddWithValue("@cod_produto", ProductID);

                myConn2.Open();

                myCommand2.ExecuteNonQuery();

                myConn2.Close();

                Response.Redirect("carrinho.aspx");
            }
            
        }

        protected void btn_checkout_Click(object sender, EventArgs e)
        {
            if (Session["Utilizador"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }

            Response.Redirect("checkout.aspx");
        }
    }
}