<%@ Page Title="" Language="C#" MasterPageFile="~/LojaMaster.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="LojaOnline.checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="hero-wrap hero-wrap-2" style="background-image: url(&quot;images/bg_2.jpg&quot;); background-position: 50% 0%;" data-stellar-background-ratio="0.5">
        <div class="overlay"></div>
        <div class="container">
            <div class="row no-gutters slider-text align-items-end justify-content-center">
                <div class="col-md-9 ftco-animate mb-5 text-center fadeInUp ftco-animated">
                    <h2 class="mb-0 bread">Checkout</h2>
                </div>
            </div>
        </div>
    </section>

    <section class="ftco-section">
        <div class="container" enabletheming="False">
            <div class="row justify-content-center">
                <div class="col-xl-10 ftco-animate fadeInUp ftco-animated">
                    <div action="#" class="billing-form">
                        <h3 class="mb-4 billing-heading">Detalhes de Faturação</h3>
                        <div class="row align-items-end">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="firstname">Primeiro Nome</label>
                                    <asp:TextBox ID="tb_nomePrimeiro" runat="server" class="form-control" ControlToValidate="tb_nomePrimeiro" ></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Precisamos Do Nome" ControlToValidate="tb_nomePrimeiro"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="lastname">Ultimo Nome</label>
                                    <asp:TextBox ID="tb_nomeUltimo" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="w-100"></div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="country">País</label>
                                    <div class="select-wrap">
                                        <div class="icon"><span class="ion-ios-arrow-down"></span></div>
                                        <asp:DropDownList ID="ddl_pais" class="form-control" runat="server" AutoPostBack="False">
                                            <asp:ListItem>Portugal</asp:ListItem>
                                            <asp:ListItem>Espanha</asp:ListItem>
                                            <asp:ListItem>Fran&#231;a</asp:ListItem>
                                            <asp:ListItem>Andorra</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                            </div>
                            <div class="w-100"></div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="streetaddress">Rua</label>
                                    <asp:TextBox ID="tb_rua" runat="server" class="form-control" placeholder="numero da casa e rua" ControlToValidate="tb_rua"></asp:TextBox></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Precisamos Da Rua" ControlToValidate="tb_rua"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox ID="tb_detalhes" runat="server" class="form-control" placeholder="indicações e entrega (opcional)"></asp:TextBox>
                                </div>
                            </div>
                            <div class="w-100"></div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="towncity">Cidade</label>
                                    <asp:TextBox ID="tb_cidade" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="postcodezip">Codigo Postal</label>
                                    <asp:TextBox ID="tb_codPostal" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="w-100"></div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="phone">Telefone</label>
                                    <asp:TextBox ID="tb_tlm" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="emailaddress">Email</label>
                                    <asp:TextBox ID="tb_email" runat="server" class="form-control"></asp:TextBox></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Precisamos Do Email" ControlToValidate="tb_email"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="w-100"></div>
                            <div class="col-md-12">
                            </div>
                        </div>
                    </div>
                    <!-- END -->



                    <div class="row mt-5 pt-3 d-flex">
                        <div class="col-md-6 d-flex">
                            <div class="cart-detail cart-total p-3 p-md-4">
                                <h3 class="billing-heading mb-4">Cart Total</h3>
                                <p class="d-flex">
                                    <span>Subtotal</span>
                                    <span>
                                        <asp:Label ID="lbl_preco" runat="server" Text="Label"></asp:Label></span>
                                </p>
                                <p class="d-flex">
                                    <span>Delivery</span>
                                    <span>$0.00</span>
                                </p>
                                <p class="d-flex">
                                    <span>Discount</span>
                                    <span>
                                        <asp:Label ID="lbl_desconto" runat="server" Text="Label"></asp:Label></span>
                                </p>
                                <hr>
                                <p class="d-flex total-price">
                                    <span>Total</span>
                                    <span>
                                        <asp:Label ID="lbl_precoFinal" runat="server" Text="Label"></asp:Label></span>
                                </p>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="cart-detail p-3 p-md-4">
                                <h3 class="billing-heading mb-4">Payment Method</h3>
                                <asp:RadioButtonList ID="rbl_formaPagamento" class="form-group" runat="server">
                                    <asp:ListItem class="radio">Transfer&#234;ncia Bancaria</asp:ListItem>
                                    <asp:ListItem class="radio">MB Way</asp:ListItem>
                                    <asp:ListItem class="radio">BitCoin</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Button ID="btn_confirm" runat="server" class="btn btn-primary py-3 px-4" Text="Encomendar" OnClick="btn_confirm_Click" />
                                <asp:Label ID="lbl_stock" runat="server" Text=""></asp:Label>
                                <asp:Literal ID="l_lista" runat="server" Visible="False"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- .col-md-8 -->
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
