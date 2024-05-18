<%@ Page Title="User List | Solar Smart" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="UserManagerList.aspx.cs" Inherits="Portal.SolarSmart.Settings.UserManagerList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <section class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-sm-6">
          <h1 class="m-0 text-dark">User List</h1>
        </div>
        <!-- /.col -->
        <div class="col-sm-6">
          <ol class="breadcrumb float-sm-right">
            <li class="breadcrumb-item"><a href="/Dashboard/AccessDashboard">Home</a></li>
            <li class="breadcrumb-item active">User List</li>
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
      <div class="card card-outline card-primary">
        <div class="card-header">
          <h3 class="card-title"><i class="fas fa-search" style="margin-right: 10px;"></i>Search Option</h3>
          <div class="card-tools">
            <button type="button" class="btn btn-tool" data-card-widget="collapse">
              <i class="fas fa-minus"></i>
            </button>
          </div>
          <!-- /.card-tools -->
        </div>
        <div class="card-body">
          <div class="row">

            <div class="col-md-3">
              <label for="inputDescription">Manager <span class="text-danger">*</span></label>
              <asp:DropDownList ID="ddlManager" class="form-control select2bs4" runat="server" AutoPostBack="true" Width="100%"></asp:DropDownList>
            </div>

            <div class="col-md-2" style="margin-top: 35px">
              <asp:LinkButton ID="btngo" runat="server" class="btn btn-primary" OnClick="btngo_Click" Width="100%"><i class="fa fa-search"></i> Search</asp:LinkButton>
              <span style="margin-right: 10%">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal></span>
            </div>

            <div class="col-md-2 d-none" style="margin-top: 35px">
              <span style="margin-right: 10%"></span>
            </div>
          </div>

          <div class="row">
            <asp:Literal ID="ltrerr" runat="server"></asp:Literal>
          </div>
          <br />
        </div>
      </div>
      <div class="card">
        <div class="card-header">
          <h3 class="card-title"><i class="fas fa-table" style="margin-right: 10px"></i>Project Subsidy Data </h3>
        </div>
        <!-- /.card-header -->
        <div class="card-body">
          <table id="example2" class="table table-bordered table-striped table-responsive">
            <thead>
              <tr>
                <th>Name</th>
                <th>Mobile</th>
                <th>Username</th>
                <th>Password</th>
                <th>Role</th>
                <th>Manager Name</th>
                <th>Email</th>
                <th>Address</th>
                <th>Commission</th>
              </tr>
            </thead>
            <tbody>
              <asp:Literal runat="server" ID="rowData"></asp:Literal>
            </tbody>
            <tfoot>
              <tr>
                <th>Name</th>
                <th>Mobile</th>
                <th>Username</th>
                <th>Password</th>
                <th>Role</th>
                <th>Manager Name</th>
                <th>Email</th>
                <th>Address</th>
                <th>Commission</th>
              </tr>
            </tfoot>
          </table>
        </div>
        <!-- /.card-body -->
      </div>
    </div>
  </section>
  <script>
    function Delete(Id) {
      $.ajax({
        type: "POST",
        url: "ProjectSchemaSubsidyList.aspx/ProjectSchemaSubsidyDelete",
        data: '{ProjectSchemaId: "' + Id + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
          if (response.d == "0") {
            DisplayToast("Alert", "Something went wrong.", "error");
          }
          else {
            DisplayToast("Deleted!", "Deleted successfully.", "success");
            setTimeout(function () {// wait for 5 secs(2)
              location.reload(); // then reload the page.(3)
            })
          }
        },
        failure: function (response) {
          alert("Somthing Wrong Error Message");
          DisplayToast("Alert", "Somthing Wrong Error Message..!!", "error");
        }
      });
    }
  </script>
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
