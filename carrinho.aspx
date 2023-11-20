<%@ Page Title="" Language="C#" MasterPageFile="~/LojaMaster.Master" AutoEventWireup="true" CodeBehind="carrinho.aspx.cs" Inherits="LojaOnline.carrinho" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="hero-wrap hero-wrap-2" style="background-image: url(&quot;images/bg_2.jpg&quot;); background-position: 50% 110px;" data-stellar-background-ratio="0.5">
        <div class="overlay"></div>
        <div class="container">
            <div class="row no-gutters slider-text align-items-end justify-content-center">
                <div class="col-md-9 ftco-animate mb-5 text-center fadeInUp ftco-animated">
                    <h2 class="mb-0 bread">My Cart</h2>
                </div>
            </div>
        </div>
    </section>

    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">

        <HeaderTemplate>

            <section class="ftco-section">
                <div class="container">
                    <div class="row">
                        <div class="table-wrap">
                            <table class="table">
                                <thead class="thead-primary">
                                    <tr>
                                        
                                        <th>&nbsp;</th>
                                        <th>Product</th>
                                        <th>Price</th>
                                        <th>Quantity</th>
                                        <th>&nbsp;</th>
                                        <th>&nbsp;</th>
                                    </tr>
                                </thead>
        </HeaderTemplate>

        <ItemTemplate>
            <tr class="alert" role="alert">
                
                <td>
                    <asp:Image ID="img" runat="server" Style="max-width: 100px; max-height: 100px;" />
                </td>
                <td>
                    <div class="email">
                        <span>
                            <asp:Label ID="lbl_produtoNome" runat="server"></asp:Label>
                        </span>
                    </div>
                </td>
                <td>
                    <asp:Label ID="lbl_preco" runat="server"></asp:Label>
                </td>
                <td class="quantity">
                    <div class="input-group">
                        <asp:Label ID="lbl_quantidade" runat="server" Text="quantidade" class="quantity form-control input-number" min="1"></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:Button ID="btn_apagar" runat="server" Text="Tirar 1" class="close" data-dismiss="alert" aria-label="Close" CommandName="Tirar" ViewStateMode="Enabled" UseSubmitBehavior="False" />
                </td>
                <td>
                    <asp:Button ID="btn_adicionar" runat="server" Text="Adicionar" class="close" data-dismiss="alert" aria-label="Close" CommandName="Adicionar" ViewStateMode="Enabled" UseSubmitBehavior="False" />
                </td>
            </tr>
        </ItemTemplate>

        <AlternatingItemTemplate>

            <tr class="alert" role="alert">
               
                <td>
                    <asp:Image ID="img" runat="server" Style="max-width: 100px; max-height: 100px;" />
                </td>
                <td>
                    <div class="email">
                        <span>
                            <asp:Label ID="lbl_produtoNome" runat="server"></asp:Label>
                        </span>
                    </div>
                </td>
                <td>
                    <asp:Label ID="lbl_preco" runat="server"></asp:Label>
                </td>
                <td class="quantity">
                    <div class="input-group">
                        <asp:Label ID="lbl_quantidade" runat="server" Text="quantidade"></asp:Label>
                    </div>
                </td>
                <td>
                    <asp:Button ID="btn_apagar" runat="server" Text="Tirar 1" class="close" data-dismiss="alert" aria-label="Close" CommandName="Tirar" ViewStateMode="Enabled" UseSubmitBehavior="False" />
                </td>
                <td>
                    <asp:Button ID="btn_adicionar" runat="server" Text="Adicionar" class="close" data-dismiss="alert" aria-label="Close" CommandName="Adicionar" ViewStateMode="Enabled" UseSubmitBehavior="False" />
                </td>
            </tr>

        </AlternatingItemTemplate>

        <FooterTemplate>
            </tbody>
    </table>
   </div>
            </div>
                </div>
    </section>
        </FooterTemplate>

    </asp:Repeater>



    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DB_WhiskyConnectionString %>' ProviderName='<%$ ConnectionStrings:DB_WhiskyConnectionString.ProviderName %>'></asp:SqlDataSource>
    <div class="row justify-content-end">
        <div class="col col-lg-5 col-md-6 mt-5 cart-wrap ftco-animate fadeInUp ftco-animated">
            <div class="cart-total mb-3">
                <h3>Cart Totals </h3>
                <p class="d-flex">
                    <span>Subtotal</span>
                    <span>
                        <asp:Label ID="lbl_subTotal" runat="server" Text="Label"></asp:Label></span>
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
                        <asp:Label ID="lbl_total" runat="server" Text="Label"></asp:Label></span>
                </p>
            </div>
            <p class="text-center">
                <asp:Button ID="btn_checkout" runat="server" Text="Proceed to Checkout" class="btn btn-primary py-3 px-4" OnClick="btn_checkout_Click" />
            </p>
        </div>
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
