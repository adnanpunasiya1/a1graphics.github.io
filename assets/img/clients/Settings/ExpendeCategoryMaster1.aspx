<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="ExpendeCategoryMaster1.aspx.cs" Inherits="Portal.SolarSmart.Settings.ExpendeCategoryMaster1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-sm-6">
          <h1 class="m-0 text-dark">ExpenseCategoryMaster List</h1>
        </div>
        <!-- /.col -->
        <div class="col-sm-6">
          <ol class="breadcrumb float-sm-right">
            <li class="breadcrumb-item"><a href="/Dashboard/AccessDashboard">Home</a></li>
            <li class="breadcrumb-item active">ExpenseCategoryMaster List</li>
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
              <h3 class="card-title">Add ExpenseCategory</h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-card-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fas fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body">
              <div class="form-group">
                <label for="inputName">Category Name <span class="text-danger">*</span></label><br />

                <asp:TextBox ID="txtname" onkeyup="chkAE()" onchange="CheckAlreadyExsist()" runat="server" class="form-control"></asp:TextBox>

              </div>
              <div class="row">
                <div class="col-md-5">
                  <div class="form-group">
                    <label for="inputDescription">Is Active</label>
                    <asp:CheckBox ID="chkactive" class="cbox"  runat="server"></asp:CheckBox>
                  </div>
                </div>

              </div>

              <div class="row">
                <div class="col-md-4">
                  <div class="form-group">
                    <a href="/Settings/ExpenseCategoryMaster.aspx" class="btn btn-secondary">Cancel</a>
                  </div>
                </div>
                <div class="col-md-8">
                  <div class="form-group">
                    <asp:LinkButton ID="btnadd" runat="server" OnClick="btnadd_Click" class="btn btn-success float-right"><i class="fas fa-save" style="margin-right:8px"></i> Add ExpenseCategory</asp:LinkButton>
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
              <h3 class="card-title">ExpenseCategory Details</h3>

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
                    <th>Id</th>
                    <th>Category Name</th>
                    <th>Is Active</th>
                    <th>Create Date</th>
                    <th>Edit</th>
                    <th>Delete</th>
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
    function chkAE() {
      CheckAlreadyExsist();
    }

    function CheckAlreadyExsist() {
      try {

        $('#ContentPlaceHolder1_txtname').on("cut copy paste", function (e) {
          e.preventDefault();
        });
        var ExpenseCategoryName = $("#ContentPlaceHolder1_txtname").val();
        if ($("#ContentPlaceHolder1_txtname").val().length != 0) {
          $.ajax({
            type: "POST",
            url: "ExpenseCategoryMaster.aspx/CheckSchemeName",
            data: '{ExpenseCategoryName:"' + ExpenseCategoryName + '"}',
            contentType: "application/json; charset=utf-8", 
            dataType: "json",
            success: function (Response) {
              var res = Response.d;
              if (res == "1") {
                DisplayToast("!", "" + ExpenseCategoryName + " already exsist .", "");
                $("#ContentPlaceHolder1_txtname").val('');
                $('#ContentPlaceHolder1_chkactive').attr("disabled", true);
                $("#ContentPlaceHolder1_btnadd").attr("disabled", true);
              }
              else if (res == "-1") {
                $('#ContentPlaceHolder1_btnadd').removeAttr('disabled');
                $('#ContentPlaceHolder1_chkactive').attr("disabled", false);
                
              }
            },
            failure: function (response) {
            }
          })
        }
        else {
          DisplayToast("  ", "please Enter ExpenseCategory Name", "error");
          return;
        }
      } catch (exp) {
        console.log(exp);
      }
    }
  </script>
</asp:Content>
