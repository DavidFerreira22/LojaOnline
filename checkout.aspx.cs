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
using System.Net.Mail;
using System.Net;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text;

namespace LojaOnline
{
    public partial class checkout : System.Web.UI.Page
    {
        int respostaSP = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Utilizador"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }

            ChecaStock();

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
            lbl_preco.Text = (PrecoSum / 100).ToString();

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

            lbl_precoFinal.Text = ((PrecoSum * desconto) / 10000).ToString();

            myConn2.Close();
        }

        private void listaCarrinho()
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

                StringBuilder productList = new StringBuilder();

                while (dr.Read())
                {
                    string productName = dr["nome"].ToString();
                    int productQuantity = Convert.ToInt32(dr["quantidade"]);

                    productList.AppendLine($"Product: {productName}, Quantity: {productQuantity}\n");
                }

                dr.Close();

                l_lista.Text = productList.ToString();
            }
            else
            {
                Response.Redirect("montra.aspx");
            }

            myConn.Close();
        }

        private void ChecaStock()
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();

            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "CheckStock";

            myCommand.Connection = myConn;
            myCommand.Parameters.AddWithValue("@cod_utilizador", Session["id_utilizador"]);

            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@retorno";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;

            myCommand.Parameters.Add(valor);

            myConn.Open();
            myCommand.ExecuteNonQuery();
            respostaSP = Convert.ToInt32(myCommand.Parameters["@retorno"].Value);
            myConn.Close();
            if (respostaSP == 1)
            {
                return;
            }
            else
            {
                DataTable stockInfo = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
                dataAdapter.Fill(stockInfo);
                string stockMessage = "Insufficient stock ";
                lbl_stock.Text = stockMessage;
            }
        }
        private void UpdateStock()
        {
            SqlConnection myConn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

            SqlCommand myCommand2 = new SqlCommand();

            myCommand2.CommandType = CommandType.StoredProcedure;
            myCommand2.CommandText = "UpdateWhisky";

            myCommand2.Connection = myConn2;
            myCommand2.Parameters.AddWithValue("@cod_utilizador", Session["id_utilizador"]);


            myConn2.Open();
            myCommand2.ExecuteNonQuery();
            myConn2.Close();
        }
        protected void btn_confirm_Click(object sender, EventArgs e)
        {


            if (respostaSP == 1)
            {

                listaCarrinho();
                UpdateStock();
                // lbl_resposta.Text = "Ativa no email";

                SmtpClient servidor = new SmtpClient();
                MailMessage email = new MailMessage();


                email.From = new MailAddress("EMAIL");
                email.To.Add(new MailAddress(tb_email.Text));
                email.Subject = "Finalização da encomenda";

                email.IsBodyHtml = true;
                email.Body = "<b>Obrigado pela encomenda, agora espera sentado que vamos tratar de tudo para si. Enviamos em Anexo o recibo da sua encomenda</b>";
                string caminhosPDFS = ConfigurationManager.AppSettings["PathPDFS"];
                string siteURL = ConfigurationManager.AppSettings["SiteURL"];

                string pdfTemplate = caminhosPDFS + "Template\\form_template.pdf";

                string nomePDF = utils.EncryptString(DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "")) + ".pdf";

                string novoFicheiro = caminhosPDFS + "PDFs Gerados\\" + nomePDF;

                PdfReader preader = new PdfReader(pdfTemplate);
                PdfStamper pstamper = new PdfStamper(preader, new FileStream(novoFicheiro, FileMode.Create));

                AcroFields pdfFields = pstamper.AcroFields;

                pdfFields.SetField("Nome", tb_nomePrimeiro.Text);
                pdfFields.SetField("Ultimo nome", tb_nomeUltimo.Text);
                pdfFields.SetField("Pais", ddl_pais.SelectedItem.Text);
                pdfFields.SetField("Rua", tb_rua.Text);
                pdfFields.SetField("Cidade", tb_cidade.Text);
                pdfFields.SetField("Codigo Postal", tb_codPostal.Text);
                pdfFields.SetField("Telefone", tb_tlm.Text);
                pdfFields.SetField("Email", tb_email.Text);
                pdfFields.SetField("Pagamento", rbl_formaPagamento.SelectedItem.Text);
                pdfFields.SetField("Lista", l_lista.Text);
                pdfFields.SetField("Total", lbl_precoFinal.Text + "€");


                pstamper.Close();

                Attachment anexo = new Attachment(novoFicheiro);
                email.Attachments.Add(anexo);

                servidor.Host = ConfigurationManager.AppSettings["SMTP_URL"];
                servidor.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_PORT"]);

                string user = ConfigurationManager.AppSettings["SMTP_USER"];
                string pass = ConfigurationManager.AppSettings["SMTP_PASSWORD"];

                servidor.Credentials = new NetworkCredential(user, pass);
                servidor.EnableSsl = true;
                servidor.Send(email);

                SqlConnection myConn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_WhiskyConnectionString"].ConnectionString);

                SqlCommand myCommand2 = new SqlCommand();

                myCommand2.CommandType = CommandType.StoredProcedure;
                myCommand2.CommandText = "ApagarCarrinho";

                myCommand2.Connection = myConn2;
                myCommand2.Parameters.AddWithValue("@cod_utilizador", Session["id_utilizador"]);


                myConn2.Open();
                myCommand2.ExecuteNonQuery();
                myConn2.Close();
                Response.Redirect("home.aspx");
            }
            else
            {
                string stockMessage = "Insufficient stock for the following products:\n";
                lbl_stock.Text = stockMessage;

            }
        }
    }
}