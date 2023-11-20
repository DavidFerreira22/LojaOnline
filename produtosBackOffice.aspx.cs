using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Df;


namespace LojaOnline
{
    public partial class produtosBackOffice : System.Web.UI.Page
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

            Stream imgStream = Imagem.PostedFile.InputStream;
            int tamanhoFich = Imagem.PostedFile.ContentLength;
            string contentType = Imagem.PostedFile.ContentType;

            byte[] imgBinaryData = new byte[tamanhoFich];
            imgStream.Read(imgBinaryData, 0, tamanhoFich);

            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "inserir_whisky_loja_admin";

            myCommand.Connection = myConn;
            myCommand.Parameters.AddWithValue("@nome", tb_nome.Text);
            myCommand.Parameters.AddWithValue("@idade", tb_idade.Text);
            myCommand.Parameters.AddWithValue("@preco", tb_preco.Text);
            myCommand.Parameters.AddWithValue("@tamanho", tb_tamanho.Text);
            myCommand.Parameters.AddWithValue("@abv", tb_abv.Text);
            myCommand.Parameters.AddWithValue("@stock", tb_quantidade.Text);
            myCommand.Parameters.AddWithValue("@regiao", ddl_regioes.SelectedValue);

            myCommand.Parameters.AddWithValue("@ct", contentType);
            myCommand.Parameters.AddWithValue("@imagem", imgBinaryData);
            myCommand.Parameters.AddWithValue("@descricao", tb_descricao.Text);



            myConn.Open();

            myCommand.ExecuteNonQuery();

            myConn.Close();


        }
    }
}