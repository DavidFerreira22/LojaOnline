<%@ Page Title="" Language="C#" MasterPageFile="~/LojaMaster.Master" AutoEventWireup="true" CodeBehind="montra.aspx.cs" Inherits="LojaOnline.montra" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <section class="hero-wrap hero-wrap-2" style="background-image: url(&quot;images/bg_2.jpg&quot;); background-position: 50% -37.5px;" data-stellar-background-ratio="0.5">
        <div class="overlay"></div>
        <div class="container">
            <div class="row no-gutters slider-text align-items-end justify-content-center">
                <div class="col-md-9 ftco-animate mb-5 text-center fadeInUp ftco-animated">
                    <h2 class="mb-0 bread">Produtos</h2>
                </div>
            </div>
        </div>
    </section>

    <div class="text-center">
        <asp:DropDownList ID="ddl_filtros" runat="server" AutoPostBack="True" CssClass="form-select">
            <asp:ListItem>AZ</asp:ListItem>
            <asp:ListItem>ZA</asp:ListItem>
            <asp:ListItem>Pre&#231;o menor - maior</asp:ListItem>
            <asp:ListItem>Pre&#231;o maior - menor</asp:ListItem>
        </asp:DropDownList>

        <asp:TextBox ID="tb_procura" runat="server"></asp:TextBox>

        <asp:Button ID="btn_procura" runat="server"  Text="Procura" />

    </div>

    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
        <HeaderTemplate>
            <div class="container">
                <div class="row mb-3">
        </HeaderTemplate>

        <ItemTemplate>
            <div class="col-md-4 mb-4">
                <div class="card h-100">
                    <img src='<%# Eval("ImageUrl") %>' class="card-img-top" alt='<%# Eval("Nome") %>' style="object-fit: cover; height: 200px;" />
                    <div class="card-body">
                        <h5 class="card-title"><%# Eval("Nome") %></h5>
                        <p class="card-text" id="razorar">Price: <%# Eval("Preco") %></p>
                        <p class="card-text" id="nãoRazorado" style="display: none;"> Price: <%# (Convert.ToInt32(Eval("Preco"))*100)/120 %></p>

                        <a href="https://localhost:44342/produtoDetalhe.aspx?id=<%# Eval("ProductID") %>" target="_blank" class="btn btn-primary">Detalhe</a>
                        <asp:Button ID="btn_adicionar" runat="server" Text="Adicionar Carrinho" CommandArgument='<%# Eval("ProductID") %>' CommandName="Ze" ViewStateMode="Enabled" UseSubmitBehavior="False" />

                    </div>
                </div>
            </div>
        </ItemTemplate>

        <AlternatingItemTemplate>
            <div class="col-md-4 mb-4">
                <div class="card h-100">
                    <img src='<%# Eval("ImageUrl") %>' class="card-img-top" alt='<%# Eval("Nome") %>' style="object-fit: cover; height: 200px;" />
                    <div class="card-body">
                        <h5 class="card-title"><%# Eval("Nome") %></h5>
                        <p class="card-text" id="razorar">Price: <%# Eval("Preco") %></p>
                        <p class="card-text" id="naoRazorado" style="display: none;"> Price: <%# (Convert.ToInt32(Eval("Preco"))*100)/120 %></p>

                        <a href="https://localhost:44342/produtoDetalhe.aspx?id=<%# Eval("ProductID") %>" target="_blank" class="btn btn-primary">Detalhe</a>
                        <asp:Button ID="btn_adicionar2" runat="server" Text="Adicionar Carrinho" CommandArgument='<%# Eval("ProductID") %>' CommandName="Ze" ViewStateMode="Enabled" UseSubmitBehavior="False" />

                    </div>
                </div>
            </div>
        </AlternatingItemTemplate>

        <FooterTemplate>
            </div>
        </div>
        </FooterTemplate>
    </asp:Repeater>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DB_WhiskyConnectionString %>"></asp:SqlDataSource>

    <div class="text-center">
        <asp:Button ID="btn_carrinho" runat="server" Text="Ir Carrinho" OnClick="btn_carrinho_Click" CssClass="btn btn-primary" />
    </div>
    <div>
        <asp:LinkButton ID="lnkPrev" runat="server" Text="Previous" OnClick="lnkPrev_Click" />
        <asp:LinkButton ID="lnkNext" runat="server" Text="Next" OnClick="lnkNext_Click" />
    </div>











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
