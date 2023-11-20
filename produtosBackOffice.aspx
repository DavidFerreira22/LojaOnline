<%@ Page Title="" Language="C#" MasterPageFile="~/BackOfficeMaster.Master" AutoEventWireup="true" CodeBehind="produtosBackOffice.aspx.cs" Inherits="LojaOnline.produtosBackOffice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >

    <div class="main-panel">
        <div 
            <div class="row">
                <div class="col-md-6 grid-margin stretch-card">
                    <div class="card">
                        <div class="card-body">

                            <h4 class="card-title">Adicionar Produtos</h4>
                             <p class="card-description"> </p>
                            <div class="forms-sample">
                                <div class="form-group">
                                    <label for="exampleInputUsername1">Nome do Whisky</label>
                                    <asp:TextBox ID="tb_nome" class="form-control" runat="server" Width="500"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Idade</label>
                                    <asp:TextBox ID="tb_idade" class="form-control" runat="server" placeholder="Numero ou NAS(No Age Statement)" Width="500"></asp:TextBox>

                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Preço</label>
                                    <asp:TextBox ID="tb_preco" class="form-control" runat="server" placeholder="Numero inteiro" Width="500"></asp:TextBox>

                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Tamanho da Garrafa</label>
                                    <asp:TextBox ID="tb_tamanho" class="form-control" runat="server" Width="500"></asp:TextBox>

                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Percentagem de Alcool</label>
                                    <asp:TextBox ID="tb_abv" class="form-control" runat="server" placeholder="Numero inteiro" Width="500"></asp:TextBox>

                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Quantidade</label>
                                    <asp:TextBox ID="tb_quantidade" class="form-control" runat="server" placeholder="Numero garrafas" Width="500"></asp:TextBox>

                                </div>
                                 <div class="form-group">
                                    <label for="exampleInputEmail1">Região</label>
                                     <asp:DropDownList ID="ddl_regioes" runat="server" Width="500" AutoPostBack="True">
                                         <asp:ListItem Value="1">Esc&#243;cia</asp:ListItem>
                                         <asp:ListItem Value="2">USA</asp:ListItem>
                                         <asp:ListItem Value="3">Irlanda</asp:ListItem>
                                         <asp:ListItem Value="4">Jap&#227;o</asp:ListItem>
                                         <asp:ListItem Value="5">Resto Mundo</asp:ListItem>
                                     </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Imagem</label>
                                    <asp:FileUpload ID="Imagem" runat="server" Width="500" />
                                </div>

                                 <div class="form-group">
                                    <label for="exampleInputEmail1">Quantidade</label>
                                    <asp:TextBox ID="tb_descricao" class="form-control" runat="server" placeholder="Apresentação do Produto" Width="650px" TextMode="MultiLine" Height="350px"></asp:TextBox>

                                </div>

                                <asp:Button ID="btn_submeter" runat="server" class="btn btn-primary mr-2" Text="Submit" OnClick="btn_submeter_Click" />

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- content-wrapper ends -->
        <!-- partial:../../partials/_footer.html -->
        <!-- plugins:js -->
        <script src="../../assets/vendors/js/vendor.bundle.base.js"></script>
        <!-- endinject -->
        <!-- Plugin js for this page -->
        <script src="../../assets/vendors/select2/select2.min.js"></script>
        <script src="../../assets/vendors/typeahead.js/typeahead.bundle.min.js"></script>
        <!-- End plugin js for this page -->
        <!-- inject:js -->
        <script src="../../assets/js/off-canvas.js"></script>
        <script src="../../assets/js/hoverable-collapse.js"></script>
        <script src="../../assets/js/misc.js"></script>
        <script src="../../assets/js/settings.js"></script>
        <script src="../../assets/js/todolist.js"></script>
        <!-- endinject -->
        <!-- Custom js for this page -->
        <script src="../../assets/js/file-upload.js"></script>
        <script src="../../assets/js/typeahead.js"></script>
        <script src="../../assets/js/select2.js"></script>
        <!-- End custom js for this page -->
        <!-- partial -->
    </div>

</asp:Content>
