<%@ Page Title="Add/List BankAccountEntry | Solar Smart" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="BankAccountEntry.aspx.cs" Inherits="Portal.SolarSmart.Settings.BankAccountEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="overlay" style="display: none" id="loading">
    <img src="../../Logo/l1.gif" style="margin-left: auto; margin-right: auto; display: block; margin-top: 15%; /* margin-bottom: auto; */" />
  </div>
  <!-- Content Header (Page header) -->
  <section class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-sm-6">
          <h1 class="m-0 text-dark">Add/List BankAccountEntry</h1>
        </div>
        <!-- /.col -->
        <div class="col-sm-6">
          <ol class="breadcrumb float-sm-right">
            <li class="breadcrumb-item"><a href="/Dashboard/AccessDashboard">Home</a></li>
            <%--<li class="breadcrumb-item"><a href="/MarketingLead/MarketingLeadOrderView">Order List</a></li>--%>
            <li class="breadcrumb-item active">Add/List BankAccountEntry</li>
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

      <div class="row">
        <div class="col-md-12">
          <div class="card card-primary">
            <div class="card-header">
              <h3 class="card-title">Add BankAccountEntry</h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-card-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fas fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body">
              <div class="row">

                <div class="col-md-4">

                  <div class="form-group">
                    <label for="inputName">Payment Date <span class="text-danger">*</span></label>
                    <asp:TextBox ID="txtPaydate" runat="server" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender Format="dd-MM-yyyy" TodaysDateFormat="dd-MM-yyyy" ID="TextBox1_CalendarExtender" runat="server" BehaviorID="TextBox1_CalendarExtender" TargetControlID="txtPaydate" />
                  </div>
                </div>
                <div class="col-md-4">

                  <div class="form-group">
                    <label>Payment Amount <span class="text-danger">*</span></label>
                    <asp:TextBox class="form-control" ID="txtPayAmt" onkeypress="return isNumber(event);" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-md-4">
                  <div class="form-group">
                    <label for="inputName">Recieved By <span class="text-danger">*</span></label><br />
                    <asp:TextBox ID="txtCallBy" runat="server" class="form-control"></asp:TextBox>
                  </div>
                </div>

                <div class="col-md-4">
                  <div class="form-group">
                    <label>Note <span class="text-danger">*</span>(Show on Receipt)</label>
                    <asp:TextBox class="form-control" ID="txtnote" TextMode="MultiLine" Rows="2" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-md-4">
                  <div class="form-group">
                    <label>ReMark <span class="text-danger">*</span></label>
                    <asp:TextBox class="form-control" ID="txtremark" TextMode="MultiLine" Rows="2" runat="server"></asp:TextBox>
                  </div>
                </div>

              </div>

              <div class="callout callout-success">
                <div class="callout-title" style="margin-bottom: 20px">
                  <h3>Cheque Details</h3>
                </div>
                <div class="row" id="divcheque">
                  <div class="col-md-4 form-group">
                    <label for="inputName">Cheque Date <span class="text-danger">*</span></label><br />
                    <asp:TextBox ID="txtDate1" runat="server" CssClass="form-control" Width="100%" AutoCompleteType="Disabled"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender Format="dd-MM-yyyy" TodaysDateFormat="dd-MM-yyyy" ID="TextBox1_CalendarExtender1" runat="server" BehaviorID="TextBox1_CalendarExtender1" TargetControlID="txtDate1" />
                  </div>
                  <div class="col-md-4  form-group">
                    <label for="inputName">Cheque Number <span class="text-danger">*</span></label><br />

                    <asp:TextBox ID="txtChqueNo" runat="server" onkeypress="return isNumber(event);" class="form-control"></asp:TextBox>
                  </div>
                  <div class="col-md-4  form-group">
                    <label for="inputName">Bank Name <span class="text-danger">*</span></label><br />

                    <asp:TextBox ID="txtBankName" runat="server" class="form-control"></asp:TextBox>
                  </div>

                  <div class="col-md-4 form-group">

                    <label>Branch Name <span class="text-danger">*</span></label>
                    <asp:TextBox class="form-control" ID="txtbranchname" runat="server"></asp:TextBox>

                  </div>
                  <div class="col-md-4  form-group">
                    <label for="inputName">IFSCCode <span class="text-danger">*</span></label><br />

                    <asp:TextBox ID="txtifsccode" onkeypress="return isNumber(event);" runat="server" class="form-control"></asp:TextBox>

                  </div>

                </div>
              </div>
              <div class="row">
                <div class="col-md-4 form-group">
                  <label for="inputStatus">Upload</label><br />

                  <asp:FileUpload ID="FileUploadPayment" runat="server" accept=".png,.jpg,.jpeg,.pdf" />
                  <br />
                  <span class="text-danger text-sm">Cash Receipt/Cheque Photo/Transaction Details</span>
                </div>
                <div class="col-md-4 form-group">
                  <img src="#" runat="server" id="imgdetails" style="width: 150px; height: 100px" visible="false" />

                </div>
              </div>
              <div class="row">
                <div class="col-md-3">
                  <div class="form-group">
                    <a href="/MarketingLead/MaintenanceList.aspx" class="btn btn-secondary">Cancel</a>
                  </div>
                </div>
                <div class="col-md-9">
                  <div class="form-group">
                    <asp:LinkButton ID="btnadd" runat="server" class="btn btn-success float-right" OnClick="btnadd_Click"><i class="fas fa-save"  style="margin-right:8px"></i> Add BankAccountEntry
                    </asp:LinkButton>
                  </div>
                </div>
              </div>
              <div class="row">
                <asp:Literal runat="server" ID="ltrerr"></asp:Literal>
                <asp:Literal runat="server" ID="srcltrerr" Visible="false"></asp:Literal>
              </div>
            </div>
            <!-- /.card-body -->
          </div>

          <div class="card">
            <div class="card-header">
              <h3 class="card-title"><i class="fas fa-table" style="margin-right: 10px"></i>BankAccountEntry Data</h3>
            </div>
            <!-- /.card-header -->
            <div class="card-body">
              <table id="example2" class="table table-bordered table-striped table-responsive">
                <thead>
                  <tr>
                    <th>Id</th>
                    <th>ReceivedDate</th>
                    <th>ReceivedBy</th>
                    <th>Amount</th>
                    <th>Bank Name</th>
                    <th>Branch Name</th>
                    <th>Cheque Date</th>
                    <th>Cheque No</th>
                    <th>Note</th>
                    <th>Remark</th>
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
                    <th>ReceivedDate</th>
                    <th>ReceivedBy</th>
                    <th>Amount</th>
                    <th>Bank Name</th>
                    <th>Branch Name</th>
                    <th>Cheque Date</th>
                    <th>Cheque No</th>
                    <th>Note</th>
                    <th>Remark</th>
                    <th>Edit</th>
                    <th>Delete</th>
                  </tr>
                </tfoot>
              </table>
            </div>
            <!-- /.card-body -->
          </div>
          <!-- /.card -->
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
      });


    });

  </script>

</asp:Content>
