<%@ Page Title="" Language="C#" MasterPageFile="~/LojaMaster.Master" AutoEventWireup="true" CodeBehind="produtoDetalhe.aspx.cs" Inherits="LojaOnline.produtoDetalhe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="hero-wrap hero-wrap-2" style="background-image: url(&quot;images/bg_2.jpg&quot;); background-position: 50% 27.2109px;" data-stellar-background-ratio="0.5">
        <div class="overlay"></div>
        <div class="container">
            <div class="row no-gutters slider-text align-items-end justify-content-center">
                <div class="col-md-9 ftco-animate mb-5 text-center fadeInUp ftco-animated">
                    <h2 class="mb-0 bread">Detalhes</h2>
                </div>
            </div>
        </div>
    </section>

    <section class="ftco-section">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 mb-5 ftco-animate fadeInUp ftco-animated">
                    <asp:Image ID="imagem" class="img-fluid" alt="Colorlib Template" runat="server" />
                </div>
                <div class="col-lg-6 product-details pl-md-5 ftco-animate fadeInUp ftco-animated">
                    <h3>
                        <asp:Label ID="lbl_produto" runat="server" Text="Label"></asp:Label></h3>
                    <p class="price"><span>
                        <asp:Label ID="lbl_preco" runat="server" Text="Label"></asp:Label></span><asp:Label ID="lbl_precoRazorado" runat="server" Text="Label" Visible="false" Font-Strikeout="True"></asp:Label></p>
                    <asp:Label ID="lbl_descricao" runat="server" Text="Label"></asp:Label>
                        
                    <p><asp:Button ID="btn_adicionar" class="btn btn-primary py-3 px-5 mr-2" runat="server" Text="Adicionar ao Carrinho" OnClick="btn_adicionar_Click" />
                        <asp:Button ID="btn_checkout" class="btn btn-primary py-3 px-5" runat="server" Text="Ir ao Checkout" OnClick="btn_checkout_Click" /></p>
                </div>
            </div>




        </div>
    </section>
     <!--Start of Tawk.to Script-->
 <script type="text/javascript">
     var Tawk_API = Tawk_API || {}, Tawk_LoadStart = new Date();
     (function () {
         var s1 = document.createElement("script"), s0 = document.getElementsByTagName("script")[0];
         s1.async = true;
         s1.src = 'https://embed.tawk.to/65524099958be55aeaaf31bc/1hf4komc2';
         s1.charset = 'UTF-8';
         s1.setAttribute('crossorigin', '*');
         s0.parentNode.insertBefore(s1, s0);
     })();
 </script>
 <!--End of Tawk.to Script-->
</asp:Content>
