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

namespace LojaOnline
{
    public partial class carrinho : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["18"] == null)
            {
                Response.Redirect("maior.aspx");
            }

            if (Session["Utilizador"] == null)
            {
                SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

                SqlCommand myCommand = new SqlCommand();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "BuscarCarrinhoDoTemp";

                myCommand.Connection = myConn;
                myCommand.Parameters.AddWithValue("@cod_Temp", Convert.ToInt32(Session["TempId"]));

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
                    SqlDataReader dr = myCommand.ExecuteReader();
                    Repeater1.DataSource = dr;
                    Repeater1.DataBind();
                    dr.Close();
                }
                else
                {
                    Response.Redirect("montra.aspx");
                }

                myConn.Close();

                SqlConnection myConn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

                SqlCommand myCommand2 = new SqlCommand();
                myCommand2.CommandType = CommandType.StoredProcedure;
                myCommand2.CommandText = "ContarDividaTemp";
                myCommand2.Connection = myConn2;
                myCommand2.Parameters.AddWithValue("@cod_Temp", Session["TempId"]);

                SqlParameter valor2 = new SqlParameter();
                valor2.ParameterName = "@SumPreco";
                valor2.Direction = ParameterDirection.Output;
                valor2.SqlDbType = SqlDbType.Int;

                myCommand2.Parameters.Add(valor2);

                myConn2.Open();
                myCommand2.ExecuteNonQuery();

                int PrecoSum = Convert.ToInt32(valor2.Value);
                lbl_subTotal.Text = (PrecoSum / 100).ToString();

                lbl_total.Text = ((PrecoSum * 100) / 10000).ToString();

                myConn2.Close();
            }
            else
            {
                SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

                SqlCommand myCommand = new SqlCommand();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "BuscarCarrinhoDoUtilizador";

                myCommand.Connection = myConn;
                myCommand.Parameters.AddWithValue("@cod_utilizador", Session["id_utilizador"]);

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
                    SqlDataReader dr = myCommand.ExecuteReader();
                    Repeater1.DataSource = dr;
                    Repeater1.DataBind();
                    dr.Close();
                }
                else
                {
                    Response.Redirect("montra.aspx");
                }

                myConn.Close();

                SqlConnection myConn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

                SqlCommand myCommand2 = new SqlCommand();
                myCommand2.CommandType = CommandType.StoredProcedure;
                myCommand2.CommandText = "ContarDivida";
                myCommand2.Connection = myConn2;
                myCommand2.Parameters.AddWithValue("@cod_utilizador", Session["id_utilizador"]);

                SqlParameter valor2 = new SqlParameter();
                valor2.ParameterName = "@SumPreco";
                valor2.Direction = ParameterDirection.Output;
                valor2.SqlDbType = SqlDbType.Int;

                myCommand2.Parameters.Add(valor2);

                myConn2.Open();
                myCommand2.ExecuteNonQuery();

                int PrecoSum = Convert.ToInt32(valor2.Value);
                lbl_subTotal.Text = (PrecoSum / 100).ToString();

                int desconto;
                if (Convert.ToInt32(Session["tipoPerfil"]) == 3)
                {
                    desconto = 100;
                    lbl_desconto.Text = "0%";
                }
                else
                {
                    desconto = 80;
                    lbl_desconto.Text = "20%";
                }

                lbl_total.Text = ((PrecoSum * desconto) / 10000).ToString();

                myConn2.Close();
            }

        }



        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Tirar")
            {
                if (Session["Utilizador"] == null)
                {
                    int id_carrinho = Convert.ToInt32(e.CommandArgument);

                    Response.Write("ProductID: " + id_carrinho);

                    SqlConnection myConn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

                    SqlCommand myCommand2 = new SqlCommand();

                    myCommand2.CommandType = CommandType.StoredProcedure;
                    myCommand2.CommandText = "tirar_carrinhoTemp";

                    myCommand2.Connection = myConn2;
                    myCommand2.Parameters.AddWithValue("@id_carrinho", id_carrinho);

                    myConn2.Open();

                    myCommand2.ExecuteNonQuery();

                    myConn2.Close();
                }
                else
                {
                    int id_carrinho = Convert.ToInt32(e.CommandArgument);

                    Response.Write("ProductID: " + id_carrinho);

                    SqlConnection myConn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

                    SqlCommand myCommand2 = new SqlCommand();

                    myCommand2.CommandType = CommandType.StoredProcedure;
                    myCommand2.CommandText = "tirar_carrinho";

                    myCommand2.Connection = myConn2;
                    myCommand2.Parameters.AddWithValue("@id_carrinho", id_carrinho);

                    myConn2.Open();

                    myCommand2.ExecuteNonQuery();

                    myConn2.Close();
                }

            }
            if (e.CommandName == "Adicionar")
            {
                if (Session["Utilizador"] == null)
                {
                    int id_carrinho = Convert.ToInt32(e.CommandArgument);

                    Response.Write("ProductID: " + id_carrinho);

                    SqlConnection myConn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

                    SqlCommand myCommand2 = new SqlCommand();

                    myCommand2.CommandType = CommandType.StoredProcedure;
                    myCommand2.CommandText = "adicionar_carrinhoTemp";

                    myCommand2.Connection = myConn2;

                    //myCommand2.Parameters.AddWithValue("@cod_utilizador", Convert.ToInt32(Session["Utilizador"]));
                    myCommand2.Parameters.AddWithValue("@id_carrinho", id_carrinho);

                    myConn2.Open();

                    myCommand2.ExecuteNonQuery();

                    myConn2.Close();
                }
                else
                {
                    int id_carrinho = Convert.ToInt32(e.CommandArgument);

                    Response.Write("ProductID: " + id_carrinho);

                    SqlConnection myConn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

                    SqlCommand myCommand2 = new SqlCommand();

                    myCommand2.CommandType = CommandType.StoredProcedure;
                    myCommand2.CommandText = "adicionar_carrinho";

                    myCommand2.Connection = myConn2;

                    //myCommand2.Parameters.AddWithValue("@cod_utilizador", Convert.ToInt32(Session["Utilizador"]));
                    myCommand2.Parameters.AddWithValue("@id_carrinho", id_carrinho);

                    myConn2.Open();

                    myCommand2.ExecuteNonQuery();

                    myConn2.Close();
                }


            }
            Response.Redirect("carrinho.aspx");
        }

        //Dictionary<string, int> ProdutosAdicionados = new Dictionary<string, int>();

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (Session["Utilizador"] == null)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    if (e.Item.DataItem is IDataRecord dr)
                    {

                        ((Label)e.Item.FindControl("lbl_produtoNome")).Text = dr["nome"].ToString();
                        ((Label)e.Item.FindControl("lbl_preco")).Text = (Convert.ToDouble(dr["preco"]) / 100).ToString();
                        ((Label)e.Item.FindControl("lbl_quantidade")).Text = dr["quantidade"].ToString();
                        Image img = (Image)e.Item.FindControl("img");
                        byte[] imageData = (byte[])dr["imagem"];
                        string base64String = Convert.ToBase64String(imageData);
                        img.ImageUrl = "data:image/png;base64," + base64String;
                        ((Button)e.Item.FindControl("btn_adicionar")).CommandArgument = dr["id_carrinhoTemp"].ToString();
                        ((Button)e.Item.FindControl("btn_apagar")).CommandArgument = dr["id_carrinhoTemp"].ToString();
                    }
                }
            }
            else
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    if (e.Item.DataItem is IDataRecord dr)
                    {

                        ((Label)e.Item.FindControl("lbl_produtoNome")).Text = dr["nome"].ToString();
                        ((Label)e.Item.FindControl("lbl_preco")).Text = (Convert.ToDouble(dr["preco"]) / 100).ToString();
                        ((Label)e.Item.FindControl("lbl_quantidade")).Text = dr["quantidade"].ToString();
                        Image img = (Image)e.Item.FindControl("img");
                        byte[] imageData = (byte[])dr["imagem"];
                        string base64String = Convert.ToBase64String(imageData);
                        img.ImageUrl = "data:image/png;base64," + base64String;
                        ((Button)e.Item.FindControl("btn_adicionar")).CommandArgument = dr["id_carrinho"].ToString();
                        ((Button)e.Item.FindControl("btn_apagar")).CommandArgument = dr["id_carrinho"].ToString();
                    }
                }
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