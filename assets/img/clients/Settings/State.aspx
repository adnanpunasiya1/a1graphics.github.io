<%@ Page Title="State List | Solar Smart" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="State.aspx.cs" Inherits="Portal.SolarSmart.Settings.State" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <section class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-sm-6">
          <h1 class="m-0 text-dark">State List</h1>
        </div>
        <!-- /.col -->
        <div class="col-sm-6">
          <ol class="breadcrumb float-sm-right">
            <li class="breadcrumb-item"><a href="/Dashboard/AccessDashboard">Home</a></li>
            <li class="breadcrumb-item active">State List</li>
          </ol>
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->
    </div>
    <!-- /.container-fluid -->
  </section>
  <section class="content">
    <div class="container-fluid">

      <div class="row">
        <div class="col-md-4">
          <div class="card card-primary">
            <div class="card-header">
              <h3 class="card-title">Add State</h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-card-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fas fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body">
              <div class="form-group">
                <label for="inputName">State Name <span class="text-danger">*</span></label><br />
                <asp:TextBox ID="txtname" runat="server" class="form-control"></asp:TextBox>
              </div>
              <div class="row">
                <div class="col-md-3">
                  <div class="form-group">
                    <label for="inputDescription">Is Active</label>
                    <asp:CheckBox ID="chkdefault" class="cbox" Enabled="false" runat="server"></asp:CheckBox>
                  </div>
                </div>
              </div>

              <div class="row">
                <div class="col-md-6">
                  <div class="form-group">
                    <a href="/Settings/State.aspx" class="btn btn-secondary">Cancel</a>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <asp:LinkButton ID="btnadd" runat="server" OnClick="btnadd_Click" class="btn btn-success float-right"><i class="fas fa-save" style="margin-right:8px"></i> Add State</asp:LinkButton>
                  </div>
                </div>
              </div>
              <div class="row">
                <asp:Literal runat="server" ID="ltrerr"></asp:Literal>
              </div>
            </div>
            <!-- /.card-body -->
          </div>
          <!-- /.card -->
        </div>
        <div class="col-md-8">
          <div class="card card-secondary">
            <div class="card-header">
              <h3 class="card-title">State Details</h3>

              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-card-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fas fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body">
              <table id="example1" class="table table-bordered table-striped table-responsive">
                <thead>
                  <tr>
                    <th>State Id</th>
                    <th>State Name</th>
                    <th>Is Active</th>
                    <th></th>
                  </tr>
                </thead>
                <tbody>
                  <asp:Literal runat="server" ID="rowData"></asp:Literal>
                </tbody>
              </table>
            </div>
            <!-- /.card-body -->
          </div>
        </div>
      </div>
    </div>
  </section>
  <script>
    $(document).ready(function () {
      $('#ContentPlaceHolder1_btnadd').attr('disabled', 'disabled');
    })
  </script>
</asp:Content>
