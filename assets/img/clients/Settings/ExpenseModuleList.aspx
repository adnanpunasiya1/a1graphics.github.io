<%@ Page Title="ExpenseModuleList List | Solar Smart" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="ExpenseModuleList.aspx.cs" Inherits="Portal.SolarSmart.Settings.ExpenseModuleList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <section class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-sm-6">
          <h1 class="m-0 text-dark">ExpenseModuleList List</h1>
        </div>
        <!-- /.col -->
        <div class="col-sm-6">
          <ol class="breadcrumb float-sm-right">
            <li class="breadcrumb-item"><a href="/Dashboard/AccessDashboard">Home</a></li>
            <li class="breadcrumb-item"><a href="/Settings/AddExpenseModule">Add ExpenseModule</a></li>
            <li class="breadcrumb-item active">ExpenseModuleList List</li>
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
        <!-- /.card-header -->
        <div class="card-body">
          <div class="row">
            <div class="col-md-2">
              <asp:Label runat="server" ID="lblfrm" Text="From Date:"></asp:Label>
              <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" Width="100%" AutoCompleteType="Disabled"></asp:TextBox>
              <ajaxToolkit:CalendarExtender Format="dd-MM-yyyy" TodaysDateFormat="dd-MM-yyyy" ID="TextBox1_CalendarExtender" runat="server" BehaviorID="TextBox1_CalendarExtender" TargetControlID="txtDate" />
            </div>

            <div class="col-md-2">
              <asp:Label runat="server" ID="lblto" Text="To Date:"></asp:Label>
              <asp:TextBox ID="txtDate1" runat="server" CssClass="form-control" Width="100%" AutoCompleteType="Disabled"></asp:TextBox>
              <ajaxToolkit:CalendarExtender Format="dd-MM-yyyy" TodaysDateFormat="dd-MM-yyyy" ID="TextBox1_CalendarExtender1" runat="server" BehaviorID="TextBox1_CalendarExtender1" TargetControlID="txtDate1" />
            </div>

           
            <div class="col-md-4">
              <div class="form-group">
                <asp:Label runat="server" Text="Expense Category:"></asp:Label>
                <asp:DropDownList ID="ddlExpenseCategory" runat="server" class="form-control select2bs4">
                </asp:DropDownList>
              </div>
            </div>

            <div class="col-md-3">
              <div class="form-group">
                <asp:Label runat="server" Text="AddedBy"></asp:Label>
                <asp:DropDownList ID="ddlAddedBy" runat="server" class="form-control select2bs4">
                </asp:DropDownList>
              </div>
            </div>

            <div class="col-md-2">
              <br />
              <asp:LinkButton ID="btngo" runat="server" class="btn btn-primary" OnClick="btngo_Click" Width="100%"><i class="fa fa-search"></i> Search</asp:LinkButton>
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
          <h3 class="card-title"><i class="fas fa-table" style="margin-right: 10px"></i>ExpenseModule Data</h3>
        </div>
        <!-- /.card-header -->
        <div class="card-body">
          <table id="example2" class="table table-bordered table-striped table-responsive">
            <thead>
              <tr>
                <th>Id</th>
                <th>Name</th>
                <th>Details</th>
                <th>Category</th>
                <th>Payment Date</th>
                <th>Amount</th>
                <th>Mode</th>
                <th>Cheque Date</th>
                <th>Cheque No</th>
                <th>Bank Name</th>
                <th>Added By</th>
                <th>View</th>
                <th>Edit</th>
                <th>Delete</th>  
              </tr>
            </thead>
            <tbody>
              <asp:Literal runat="server" ID="rowData"></asp:Literal>
            </tbody>
            <tfoot>
              <tr>
               
                <th>Id</th>
                <th>Name</th>
                <th>Details</th>
                <th>Category</th>
                <th>Payment Date</th>
                <th>Amount</th>
                <th>Mode</th>
                <th>Cheque Date</th>
                <th>Cheque No</th>
                <th>Bank Name</th>
                <th>Added By</th>
                <th>View</th>
                <th>Edit</th>
                <th>Delete</th>  </tr>
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
