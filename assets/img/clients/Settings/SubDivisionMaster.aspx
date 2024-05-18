<%@ Page Title="Sub-Division List | Solar Smart" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="SubDivisionMaster.aspx.cs" Inherits="Portal.SolarSmart.Settings.SubDivisionMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <section class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-sm-6">
          <h1 class="m-0 text-dark">Sub-Division List</h1>
        </div>
        <!-- /.col -->
        <div class="col-sm-6">
          <ol class="breadcrumb float-sm-right">
            <li class="breadcrumb-item"><a href="/Dashboard/AccessDashboard">Home</a></li>
            <li class="breadcrumb-item active">Sub-Division List</li>
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
        <div class="col-md-12">
          <div class="card card-primary">
            <div class="card-header">
              <h3 class="card-title">Add Sub Division</h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-card-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fas fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body">
              <div class="row">
                <div class="col-md-3">
                  <div class="form-group">
                    <label for="inputDescription">Division For <span class="text-danger">*</span></label>
                    <asp:DropDownList ID="ddldivisionlist" class="form-control" runat="server" AutoPostBack="false" Width="100%"></asp:DropDownList>
                  </div>
                </div>


                <div class="col-md-3">
                  <div class="form-group">
                    <label for="inputStatus">Sub Division Name <span class="text-danger">*</span></label>
                    <asp:TextBox class="form-control pull-right" ID="txtsubdiv" AutoCompleteType="Disabled" runat="server"></asp:TextBox>
                  </div>
                </div>


                <div class="col-md-3">
                  <div class="form-group">
                    <label for="inputStatus">Email Id</label>
                    <asp:TextBox class="form-control pull-right" ID="txtemail" AutoCompleteType="Disabled" runat="server"></asp:TextBox>
                  </div>
                </div>

                <div class="col-md-3">
                  <div class="form-group">
                    <label for="inputStatus">Mobile Number </label>
                    <asp:TextBox class="form-control pull-right" ID="txtmobile" AutoCompleteType="Disabled" runat="server"></asp:TextBox>
                  </div>
                </div>

                <div class="col-md-3">
                  <div class="form-group">
                    <label for="inputStatus">Contact Person Name </label>
                    <asp:TextBox class="form-control pull-right" ID="txtcontactpersonname" AutoCompleteType="Disabled" runat="server"></asp:TextBox>
                  </div>
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <div class="form-group">
                    <a href="/Settings/SubDivisionMaster.aspx" class="btn btn-secondary">Cancel</a>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-group">
                    <asp:LinkButton ID="btnadd" runat="server" OnClick="btnadd_Click" class="btn btn-success float-right"><i class="fas fa-save"  style="margin-right:8px"></i> Add Sub Division</asp:LinkButton>
                  </div>
                  <div class="form-group" style="margin-top: 50px;">
                    <asp:LinkButton ID="btnDelete" Visible="false" runat="server" class="btn btn-danger float-right" OnClick="btnDelete_Click"><i class="fas fa-trash"  style="margin-right:8px"></i> Delete</asp:LinkButton>
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
      </div>
      <div class="row">
        <div class="col-md-12">
          <div class="card card-secondary">
            <div class="card-header">
              <h3 class="card-title">Sub Division Details</h3>

              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-card-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fas fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body">
              <table id="example2" class="table table-bordered table-striped table-responsive-sm">
                <thead>
                  <tr>
                    <th>Division Name</th>
                    <th>Sub Division Name</th>
                    <th>Email Id</th>
                    <th>Contact Person Name</th>
                    <th>Mobile Number</th>
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
