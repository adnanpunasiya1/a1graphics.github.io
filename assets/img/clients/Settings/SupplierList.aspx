<%@ Page Title="Supplier List | Solar Smart" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="SupplierList.aspx.cs" Inherits="Portal.SolarSmart.Settings.SupplierList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <section class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-sm-6">
          <h1 class="m-0 text-dark">Supplier List</h1>
        </div>
        <!-- /.col -->
        <div class="col-sm-6">
          <ol class="breadcrumb float-sm-right">
            <li class="breadcrumb-item"><a href="/Dashboard/AccessDashboard">Home</a></li>
            <li class="breadcrumb-item active">Supplier List</li>
          </ol>
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->
    </div>
    <!-- /.container-fluid -->
  </section>
  <!-- /.content-header -->
  <section class="content">
    <div class="container-fluid">

      <div class="card card-outline card-primary d-none">
        <div class="card-header">
          <h3 class="card-title"><i class="fas fa-search" style="margin-right: 10px;"></i>Search Option</h3>

          <div class="card-tools">
            <button type="button" class="btn btn-tool" data-card-widget="collapse">
              <i class="fas fa-minus"></i>
            </button>
          </div>
          <!-- /.card-tools -->
        </div>
        <!-- /.card-header -->
        <div class="card-body">
          <div class="row">

            <div class="col-md-2">

              <asp:Label ID="Label3" Style="margin-top: 10px" class="control-label" runat="server" Text="Product Type:"></asp:Label>

              <asp:DropDownList ID="ddlProductType" runat="server" class="form-control">
              </asp:DropDownList>

            </div>
            <div class="col-md-2">
              <br />
              <asp:LinkButton ID="btngo" runat="server" class="btn btn-primary" OnClick="btngo_Click" Width="100%"><i class="fa fa-search"></i> Search</asp:LinkButton>
              <span style="margin-right: 10%">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal></span>
            </div>
          </div>
          <div class="row">
            <asp:Literal ID="ltrerr" runat="server"></asp:Literal>
          </div>
        </div>
        <!-- /.card-body -->
      </div>
      <!-- /.card -->

      <div class="card">
        <div class="card-header">
          <h3 class="card-title"><i class="fas fa-table" style="margin-right: 10px"></i>Supplier Data</h3>
        </div>
        <!-- /.card-header -->
        <div class="card-body">
          <a href="AddSupplier" class="btn btn-info mb-4"><i class="fa fa-user-plus mr-3"></i>Add New Supplier</a>

          <table id="example2" class="table table-bordered table-striped table-responsive ">
            <thead>
              <tr>
                <th>Action</th>
                <th>Name</th>
                <th>Mobile</th>
                <th>PhoneNo</th>
                <th>Address</th>
                <th>EmailId</th>
                <th>GSTNo</th>
              </tr>
            </thead>
            <tbody>
              <asp:Literal runat="server" ID="rowData" EnableViewState="false"></asp:Literal>
            </tbody>
            <tfoot>
              <tr>
                <th>Action</th>
                <th>Name</th>
                <th>Mobile</th>
                <th>PhoneNo</th>
                <th>Address</th>
                <th>EmailId</th>
                <th>GSTNo</th>
              </tr>
            </tfoot>
          </table>
        </div>
        <!-- /.card-body -->
      </div>
    </div>
  </section>
  <script>
    $(function () {
      $("#example1").DataTable();
      $('#example2').DataTable({
        "paging": true,
        "lengthChange": false,
        "searching": true,
        "ordering": true,
        "info": true,
        "autoWidth": false,
        dom: 'Bfrtip',
        "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"]
      });
    });
  </script>
</asp:Content>
