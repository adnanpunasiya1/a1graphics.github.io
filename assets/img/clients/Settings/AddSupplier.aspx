<%@ Page Title="Add Supplier | Solar Smart" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="AddSupplier.aspx.cs" Inherits="Portal.SolarSmart.Settings.AddSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <section class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-sm-6">
          <h1>Add Supplier</h1>
        </div>
        <div class="col-sm-6">
          <ol class="breadcrumb float-sm-right">
            <li class="breadcrumb-item"><a href="/Settings/SupplierList">Supplier List</a></li>
            <li class="breadcrumb-item active">Add Supplier</li>
          </ol>
        </div>
      </div>
    </div>
    <!-- /.container-fluid -->
  </section>
  <!-- Main content -->
  <section class="content" style="padding-bottom: 2%">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-6">
          <div class="card card-primary">
            <div class="card-header">
              <h3 class="card-title">General Details</h3>

              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-card-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fas fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body">
              <div class="form-group">
                <label for="inputName">Name <span class="text-danger">*</span></label>
                <asp:TextBox ID="txtname" MaxLength="50" runat="server" class="form-control"></asp:TextBox>
              </div>
              <div class="form-group">
                <label for="inputDescription">Address <span class="text-danger">*</span></label>
                <asp:TextBox ID="txtadd" TextMode="MultiLine" runat="server" class="form-control" Rows="3" MaxLength="100"></asp:TextBox>
              </div>
              <div class="form-group">
                <label for="inputProjectLeader">Mobile Number <span class="text-danger">*</span></label>
                <asp:TextBox ID="txtmobile" runat="server" class="form-control" onkeypress="return isNumber(event);" MaxLength="10"></asp:TextBox>
              </div>
              <div class="form-group">
                <label for="inputProjectLeader">Phone Number</label>
                <asp:TextBox ID="txtPhoneNo" runat="server" class="form-control" onkeypress="return isNumber(event);" MaxLength="10"></asp:TextBox>
              </div>
              <div class="form-group">
                <label for="inputProjectLeader">EmailId</label>
                <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
              </div>
              <div class="form-group">
                <label for="inputName">GST No</label>
                <asp:TextBox ID="txtGSTNo" MaxLength="50" runat="server" class="form-control"></asp:TextBox>
              </div>
              <div class="form-group">
                <asp:CheckBox ID="chkactive" runat="server" Text=" Is Active"></asp:CheckBox>
              </div>
            </div>
            <!-- /.card-body -->
            <div class="card-footer">
              <div class="row">
                <div class="col-12">
                  <a href="/Settings/SupplierList" class="btn btn-secondary">Cancel</a>
                  <asp:LinkButton ID="btnadd" runat="server" class="btn btn-success float-right" OnClick="btnadd_Click"><i class="fas fa-save"  style="margin-right:8px"></i> Save</asp:LinkButton>
                </div>
              </div>
            </div>
          </div>
          <!-- /.card -->
        </div>

      </div>
      <div class="row">
        <asp:Literal ID="ltrerr" runat="server" EnableViewState="false"></asp:Literal>
      </div>
      <br />

    </div>
  </section>
  <!-- /.content -->
</asp:Content>
