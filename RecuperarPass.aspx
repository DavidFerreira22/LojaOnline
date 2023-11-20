<%@ Page Title="" Language="C#" MasterPageFile="~/LojaMaster.Master" AutoEventWireup="true" CodeBehind="RecuperarPass.aspx.cs" Inherits="LojaOnline.RecuperarPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="hero-wrap hero-wrap-2" style="background-image: url(&quot;images/bg_2.jpg&quot;); background-position: 50% 50%;" data-stellar-background-ratio="0.5">
        <div class="overlay"></div>
        <div class="container">
            <div class="row no-gutters slider-text align-items-end justify-content-center">
                <div class="col-md-9 ftco-animate mb-5 text-center fadeInUp ftco-animated">
                    <h2 class="mb-0 bread">Recuperar Passe</h2>
                </div>
            </div>
        </div>
    </section>
    <div class="col-md-12">
        <div class="form-group">
            <label class="label" for="Email">Email</label>
            <asp:TextBox ID="tb_email" class="form-control" placeholder="email" runat="server" TextMode="email"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-12">
        <div class="form-group">
            <label class="label" for="Password">Nova Password</label>
            <asp:TextBox ID="tb_pw" class="form-control" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-12">
        <div class="form-group">
            <asp:Button ID="btn_recuperar" runat="server" Text="Pedir Recuperação" class="btn btn-primary" OnClick="btn_recuperar_Click" />
            <div class="submitting"></div>
        </div>
    </div>
    <asp:Label ID="lbl_resposta" runat="server"></asp:Label>

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
