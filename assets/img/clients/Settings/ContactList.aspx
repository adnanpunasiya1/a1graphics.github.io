<%@ Page Title="User List | Solar Smart" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="ContactList.aspx.cs" Inherits="Portal.SolarSmart.Settings.ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <!-- Content Header (Page header) -->
  <section class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-sm-6">
          <h1>User List</h1>
        </div>
        <div class="col-sm-6">
          <ol class="breadcrumb float-sm-right">
            <li class="breadcrumb-item"><a href="/Dashboard/AccessDashboard">Home</a></li>
            <li class="breadcrumb-item active">User List</li>
          </ol>
        </div>
      </div>
    </div>
    <!-- /.container-fluid -->
  </section>
  <section class="content">
    <div class="container-fluid">

      <div class="row mb-3">
        <div class="col-md-12">

          <div class="form-group">
            <asp:LinkButton ID="btnadd" runat="server" class="btn btn-info float-right mr-2 mt-3" OnClick="btnadd_Click1"><i class="fas fa-eye"  style="margin-right:8px"></i> Display All</asp:LinkButton>
          </div>
          <div class="form-group">
            <a href="/Settings/UserManagerList" class="btn btn-warning float-right  mr-2"><i class="fas fa-file-export" style="margin-right: 8px"></i>Export User</a>
          </div>
          <div class="form-group">
            <a href="/Settings/Users" class="btn btn-primary float-right  mr-2"><i class="fa fa-user-plus" style="margin-right: 8px"></i>Add New User</a>
          </div>
        </div>
      </div>

      <!-- Default box -->
      <div class="card card-solid">
        <div class="card-header">
          <h3 class="card-title"><i class="fas fa-users" style="margin-right: 10px;"></i>Users</h3>

          <div class="card-tools">
            <button type="button" class="btn btn-tool" data-card-widget="collapse">
              <i class="fas fa-minus"></i>
            </button>
          </div>
          <!-- /.card-tools -->
        </div>
        <div class="card-body pb-0">
          <div class="row d-flex align-items-stretch">
            <asp:Literal runat="server" ID="rowData" EnableViewState="false"></asp:Literal>
          </div>
        </div>
        <!-- /.card-body -->
        <div class="card-footer">
          <a href="/Settings/Users" class="btn btn-primary pull-right justify-content-center align-items-center"><i class="fa fa-user-plus" style="margin-right: 8px"></i>Add New User</a>
        </div>
        <!-- /.card-footer -->
      </div>
      <!-- /.card -->
    </div>
  </section>
</asp:Content>
