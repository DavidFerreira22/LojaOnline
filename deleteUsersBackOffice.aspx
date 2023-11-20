<%@ Page Title="" Language="C#" MasterPageFile="~/BackOfficeMaster.Master" AutoEventWireup="true" CodeBehind="deleteUsersBackOffice.aspx.cs" Inherits="LojaOnline.deleteUsersBackOffice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="main-panel">
    <div 
        <div class="row">
            <div class="col-md-6 grid-margin stretch-card">
                <div class="card">
                    <div class="card-body">

                        <h4 class="card-title">Apagar Utilizador</h4>
                         <p class="card-description"> </p>
                        <div class="forms-sample">
                            <div class="form-group">
                                <label for="exampleInputUsername1">Nome do Utilizador</label>
                                <asp:TextBox ID="tb_nome" class="form-control" runat="server" Width="500"></asp:TextBox>
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
