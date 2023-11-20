<%@ Page Title="" Language="C#" MasterPageFile="~/LojaMaster.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="LojaOnline.LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="hero-wrap hero-wrap-2" style="background-image: url(&quot;images/bg_2.jpg&quot;); background-position: 50% 50%;" data-stellar-background-ratio="0.5">
        <div class="overlay"></div>
        <div class="container">
            <div class="row no-gutters slider-text align-items-end justify-content-center">
                <div class="col-md-9 ftco-animate mb-5 text-center fadeInUp ftco-animated">
                    <h2 class="mb-0 bread">Log In</h2>
                </div>
            </div>
        </div>
    </section>

    <div class="contact-wrap w-100 p-md-5 p-4">

        <div class="contactForm">
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="label" for="name">Utilizador</label>
                        <asp:TextBox ID="tb_nome" class="form-control" placeholder="utilizador" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-12">
                    <div class="form-group">
                        <label class="label" for="Password">Password</label>
                        <asp:TextBox ID="tb_pw" class="form-control" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-12">
                    <div class="form-group">
                        <asp:Button ID="btn_login" runat="server" Text="Login" class="btn btn-primary" OnClick="btn_login_Click" />
                        <div class="submitting"></div>
                    </div>
                </div>
                <asp:Label ID="lbl_resposta" runat="server"></asp:Label>
                <a href="RecuperarPass.aspx">Esqueceu a palavra passe? </a>
                <asp:Button CssClass="btn btn-default" ID="btn_google" runat="server" Text="Login with Google account" OnClick="btn_google_Click"></asp:Button>
                &nbsp;
            </div>
        </div>
    </div>

</asp:Content>
