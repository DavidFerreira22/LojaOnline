using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LojaOnline
{
    public partial class montra : System.Web.UI.Page
    {

        int pageSize = 6;
        int currentPage = 0;
        List<Product> lst_Produtos = new List<Product>();

        private void PrecoRazorado()
        {
            if (Session["id_utilizadores"] != null)
            {
                Label razorar = (Label)FindControl("razorar");
                Label naoRazorado = (Label)FindControl("naoRazorado");


                int id_user = Convert.ToInt32(Session["id_utilizadores"]);


                SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);
                SqlCommand myCommand = new SqlCommand();

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "checarPerfil";

                myCommand.Connection = myConn;
                myCommand.Parameters.AddWithValue("@cod_utilizador", id_user);
                SqlParameter valor = new SqlParameter();
                valor.ParameterName = "@retorno";
                valor.Direction = ParameterDirection.Output;
                valor.SqlDbType = SqlDbType.Int;

                myCommand.Parameters.Add(valor);

                myConn.Open();
                myCommand.ExecuteNonQuery();
                int respostaSP = Convert.ToInt32(myCommand.Parameters["@retorno"].Value);

                if (respostaSP == 3)
                {
                    //admin
                    razorar.Style.Add("text-decoration", "line-through");
                    naoRazorado.Visible = true;
                }
                else if (respostaSP == 2)
                {
                    //revenda
                    razorar.Style.Add("text-decoration", "line-through");
                    naoRazorado.Visible = true;
                }
                else
                {
                    //comum
                    naoRazorado.Visible = false;
                    return;
                }


                myConn.Close();


            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["18"] == null)
            {
                Response.Redirect("maior.aspx");
            }

            if (Session["Utilizador"] == null && Session["TempId"] == null)
            {
                Guid guid = Guid.NewGuid();
                int TempId = guid.GetHashCode();
                Session["TempId"] = TempId;
            }

            int count = 0;

            string query = "SELECT id_whisky, nome, preco, imagem FROM Whisky";

            if (!string.IsNullOrEmpty(tb_procura.Text))
            {
                query += " WHERE nome LIKE '%" + tb_procura.Text + "%'";
            }

            if (ddl_filtros.SelectedItem.ToString() == "AZ")
            {
                query += " ORDER BY nome ASC";
            }
            else if (ddl_filtros.SelectedItem.ToString() == "ZA")
            {
                query += " ORDER BY nome DESC";

            }
            else if (ddl_filtros.SelectedItem.ToString() == "Preço menor - maior")
            {
                query += " ORDER BY preco ASC";

            }
            else if (ddl_filtros.SelectedItem.ToString() == "Preço maior - menor")
            {
                query += " ORDER BY preco DESC";

            }


            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand(query, myConn);


            myConn.Open();


            var reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                count++;
                Product show = new Product();

                show.ProductID = reader.GetInt32(0);
                show.Nome = reader.GetString(1);
                show.Preco = (reader.GetInt32(2)) / 100;
                show.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String((byte[])reader["imagem"]);



                lst_Produtos.Add(show);
            }

            myConn.Close();

            int totalItems = lst_Produtos.Count;
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            Session["TotalPages"] = totalPages;
            BindData();

        }

        private void BindData()
        {
            int currentPage = Convert.ToInt32(Session["CurrentPage"] ?? "0");
            int startIndex = currentPage * pageSize;
            var itemsToDisplay = lst_Produtos.Skip(startIndex).Take(pageSize);
            Repeater1.DataSource = itemsToDisplay;
            Repeater1.DataBind();

            // Update navigation buttons visibility
            lnkPrev.Visible = currentPage > 0;
            lnkNext.Visible = currentPage < (int)Session["TotalPages"] - 1;

            PrecoRazorado();

        }

        protected void lnkPrev_Click(object sender, EventArgs e)
        {
            int currentPage = Convert.ToInt32(Session["CurrentPage"] ?? "0");
            if (currentPage > 0)
            {
                currentPage--;
                Session["CurrentPage"] = currentPage;
                BindData();
            }
        }


        protected void lnkNext_Click(object sender, EventArgs e)
        {
            int currentPage = Convert.ToInt32(Session["CurrentPage"] ?? "0");
            if (currentPage < (int)Session["TotalPages"] - 1)
            {
                currentPage++;
                Session["CurrentPage"] = currentPage;
                BindData();
            }
        }

        protected void btn_carrinho_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("carrinho.aspx");
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Ze")
            {
                if (Session["Utilizador"] == null)
                {
                    int ProductID = Convert.ToInt32(e.CommandArgument);

                    Response.Write("ProductID: " + ProductID);

                    SqlConnection myConn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

                    SqlCommand myCommand2 = new SqlCommand();

                    myCommand2.CommandType = CommandType.StoredProcedure;
                    myCommand2.CommandText = "inserir_carrinhoTemp";

                    myCommand2.Connection = myConn2;
                    myCommand2.Parameters.AddWithValue("@cod_Temp", Session["TempId"]);

                    //myCommand2.Parameters.AddWithValue("@cod_utilizador", Convert.ToInt32(Session["Utilizador"]));
                    myCommand2.Parameters.AddWithValue("@cod_produto", ProductID);

                    myConn2.Open();

                    myCommand2.ExecuteNonQuery();

                    myConn2.Close();
                }
                else
                {
                    int ProductID = Convert.ToInt32(e.CommandArgument);

                    Response.Write("ProductID: " + ProductID);

                    SqlConnection myConn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

                    SqlCommand myCommand2 = new SqlCommand();

                    myCommand2.CommandType = CommandType.StoredProcedure;
                    myCommand2.CommandText = "inserir_carrinho";

                    myCommand2.Connection = myConn2;
                    myCommand2.Parameters.AddWithValue("@cod_utilizador", Session["id_utilizador"]);

                    //myCommand2.Parameters.AddWithValue("@cod_utilizador", Convert.ToInt32(Session["Utilizador"]));
                    myCommand2.Parameters.AddWithValue("@cod_produto", ProductID);

                    myConn2.Open();

                    myCommand2.ExecuteNonQuery();

                    myConn2.Close();
                }


            }

        }

    }
    public class Product
    {
        public int ProductID { get; set; }
        public string Nome { get; set; }
        public int Preco { get; set; }
        public string ImageUrl { get; set; }
    }
}