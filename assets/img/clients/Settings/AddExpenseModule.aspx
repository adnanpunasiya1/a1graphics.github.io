<%@ Page Title="Add AddExpenseModule | Solar Smart" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="AddExpenseModule.aspx.cs" Inherits="Portal.SolarSmart.Settings.AddExpenseModule" %>

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
          <h1 class="m-0 text-dark">Add ExpenseModule</h1>
        </div>
        <!-- /.col -->
        <div class="col-sm-6">
          <ol class="breadcrumb float-sm-right">
            <li class="breadcrumb-item"><a href="/Dashboard/AccessDashboard">Home</a></li>
            <li class="breadcrumb-item active">Add ExpenseModule</li>
            <li class="breadcrumb-item"><a href="/Settings/ExpenseModuleList">ExpenseModuleList</a></li>
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
              <h3 class="card-title">Add ExpenseModule</h3>
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
                    <label>Name <span class="text-danger">*</span></label>
                    <asp:TextBox class="form-control" ID="txtname" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-md-4">
                  <div class="form-group">
                    <label>Details <span class="text-danger">*</span></label>
                    <asp:TextBox class="form-control" ID="txtdetails" TextMode="MultiLine" Rows="2" runat="server"></asp:TextBox>
                  </div>
                </div>
                  <div class="col-md-3">
                    <div class="form-group">
                      <label>Expense Category <span class="text-danger">*</span></label>
                      <asp:DropDownList ID="ddlcategory" class="form-control select2bs4" runat="server" AutoPostBack="false" Width="100%"></asp:DropDownList>
                    </div>
                  </div>
                <div class="col-md-1">
                    <div class="form-group">
                      <a href="/Settings/ExpenseCategoryMaster.aspx" target="_blank" class="btn btn-success"><i class="fa fa-plus"></i></a>
                      </div>
                </div>
                <div class="col-md-4">

                  <div class="form-group">
                    <label for="inputName">Expense Date <span class="text-danger">*</span></label>
                    <asp:TextBox ID="txtPaydate" runat="server" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender Format="dd-MM-yyyy" TodaysDateFormat="dd-MM-yyyy" ID="TextBox1_CalendarExtender" runat="server" BehaviorID="TextBox1_CalendarExtender" TargetControlID="txtPaydate" />
                  </div>
                </div>
                <div class="col-md-4">

                  <div class="form-group">
                    <label>Expense Amount <span class="text-danger">*</span></label>
                    <asp:TextBox class="form-control" ID="txtPayAmt" onkeypress="return isNumber(event);" runat="server"></asp:TextBox>
                  </div>
                </div>
                <div class="col-md-4">
                  <div class="form-group">
                    <label for="inputName">Added By <span class="text-danger">*</span></label><br />
                    <asp:TextBox ID="txtCallBy" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                  </div>
                </div>
              </div>

              <div class="form-group">
                <label for="inputName">Payment Mode <span class="text-danger">*</span></label><br />
                <asp:RadioButton ID="rbtCash" runat="server" Checked="true" Text="Cash" onclick="showHideDiv()" class="radio-inline" GroupName="inStatus" Style="margin-right: 10px" />
                <asp:RadioButton ID="rbtCheque" runat="server" Text="Cheque" class="radio-inline" onclick="showHideDiv()" GroupName="inStatus" Style="margin-right: 10px" />
                <asp:RadioButton ID="rbtNEFT" runat="server" Text="NEFT" class="radio-inline" onclick="showHideDiv()" GroupName="inStatus" Style="margin-right: 10px" />
              </div>
              <div class="row" id="divcheque" style="display: none;">
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
              </div>
              <div class="row" id="divNEFT" style="display: none;">
                <div class="col-md-4 form-group">
                  <label for="inputName">Transaction Date <span class="text-danger">*</span></label><br />
                  <asp:TextBox ID="txtTrnDate" runat="server" CssClass="form-control" Width="100%" AutoCompleteType="Disabled"></asp:TextBox>
                  <ajaxToolkit:CalendarExtender Format="dd-MM-yyyy" TodaysDateFormat="dd-MM-yyyy" ID="TextBox1_CalendarExtender2" runat="server" BehaviorID="TextBox1_CalendarExtender2" TargetControlID="txtTrnDate" />
                </div>
                <div class="col-md-4  form-group">
                  <label for="inputName">Transaction Number <span class="text-danger">*</span></label><br />

                  <asp:TextBox ID="txtTrnNo" runat="server" onkeypress="return isNumber(event);" class="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4  form-group">
                  <label for="inputName">Transaction Bank Name <span class="text-danger">*</span></label><br />

                  <asp:TextBox ID="txtTrnBankName" runat="server" class="form-control"></asp:TextBox>
                </div>
              </div>
              <div class="row">
                <div class="col-md-3 form-group">
                  <label for="inputStatus">Upload </label><br />

                  <asp:FileUpload ID="FileUploadPayment" runat="server" accept=".png,.jpg,.jpeg,.pdf" />
                  <br />
                  <span class="text-danger text-sm">Cash Receipt/Cheque Photo/Transaction Details</span>
                </div>
                <div class="col-md-4 form-group">
                  <img src="#" runat="server" id="imgdetails" style="width: 150px; height: 100px" visible="false"/>
              
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
                    <asp:LinkButton ID="btnadd" runat="server" class="btn btn-success float-right" OnClick="btnadd_Click"><i class="fas fa-save"  style="margin-right:8px"></i> Add ExpenseModule
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
      showHideDiv()

    });
    function showHideDiv() {
      if ($("#ContentPlaceHolder1_rbtCash").prop("checked") == true) {
        $("#divcheque").hide();
        $("#divNEFT").hide();
        //$("#divtext").show();
      }
      else if ($("#ContentPlaceHolder1_rbtCheque").prop("checked") == true) {
        $("#divcheque").show();
        $("#divNEFT").hide();
        //$("#divtext").hide();
      }
      else if ($("#ContentPlaceHolder1_rbtNEFT").prop("checked") == true) {
        $("#divNEFT").show();
        $("#divcheque").hide();
        //$("#divtext").hide();
      }
    }
  </script>
  <script>
    function RemoveEntry(id) {
      Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
      }).then((result) => {
        if (result.value) {
          $('#loading').show();
          $.ajax({
            type: "POST",
            url: "AddOrderPayment.aspx/RemoveEntry",
            data: '{Id: "' + id + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",

            success: function (response) {
              if (response.d == "1") {
                $('#loading').hide();
                DisplayToast("Send", "Payment Entry Removed Successfully.", "success");

              }
              else {
                $('#loading').hide();
                DisplayToast("Alert", "Somthing Wrong, Please try after sometime..!!", "error");
              }
            },
            failure: function (response) {
              $('#loading').hide();
              DisplayToast("Alert", "Somthing Wrong, Please try after sometime..!!", "error");
            }
          });
        }
      });


    }
  </script>
</asp:Content>
