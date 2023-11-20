<%@ Page Title="" Language="C#" MasterPageFile="~/BackOfficeMaster.Master" AutoEventWireup="true" CodeBehind="loginBackOffice.aspx.cs" Inherits="LojaOnline.loginBackOffice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="contact-wrap w-100 p-md-5 p-4">

    <div class="contactForm">
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <label class="label" for="name">Utilizador</label>
                    <asp:TextBox ID="tb_nome" class="form-control" placeholder="utilizador" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="tb_nome"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="col-md-12">
                <div class="form-group">
                    <label class="label" for="Password">Password</label>
                    <asp:TextBox ID="tb_pw" class="form-control" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="tb_pw"></asp:RequiredFieldValidator>
                
                </div>
            </div>

            <div class="col-md-12">
                <div class="form-group">
                    <asp:Button ID="btn_login" runat="server" Text="Login" class="btn btn-primary" OnClick="btn_login_Click" />
                    <div class="submitting"></div>
                </div>
            </div>
            <asp:Label ID="lbl_resposta" runat="server"></asp:Label>
            &nbsp;
        </div>
    </div>
</div>

</asp:Content>
