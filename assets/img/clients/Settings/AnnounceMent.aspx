<%@ Page Title="AnnounceMent List | Solar Smart" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="AnnounceMent.aspx.cs" Inherits="Portal.SolarSmart.Settings.AnnounceMent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <section class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-sm-6">
          <h1 class="m-0 text-dark">AnnounceMent List</h1>
        </div>
        <!-- /.col -->
        <div class="col-sm-6">
          <ol class="breadcrumb float-sm-right">
            <li class="breadcrumb-item"><a href="/Dashboard/AccessDashboard">Home</a></li>
            <li class="breadcrumb-item active">AnnounceMent List</li>
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
              <h3 class="card-title">Add AnnounceMent</h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-card-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fas fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body">
              <div class="form-group">
                <label for="inputName">AnnounceMent Title <span class="text-danger">*</span></label><br />

                <asp:TextBox ID="txtTitle" placeholder="Enter Title" runat="server" class="form-control"></asp:TextBox>

              </div>
              <div class="form-group">
                <label for="inputName">AnnounceMent Desc <span class="text-danger">*</span></label><br />
                <asp:TextBox ID="txtdesc" TextMode="MultiLine" placeholder="Enter Description" runat="server" class="form-control"></asp:TextBox>

              </div>
              <div class="form-group">

                <asp:Label runat="server" ID="lblfrm" Text="To TillDate:"></asp:Label>
                <asp:TextBox ID="txttotillDate" runat="server" CssClass="form-control" Width="100%" AutoCompleteType="Disabled"></asp:TextBox>
                <ajaxToolkit:CalendarExtender Format="dd-MM-yyyy" TodaysDateFormat="dd-MM-yyyy" ID="TextBox1_CalendarExtender" runat="server" BehaviorID="TextBox1_CalendarExtender" TargetControlID="txttotillDate" />

              </div>
              <div class="form-group">

                <asp:Label runat="server" ID="lblftd" Text="FromTillDate:"></asp:Label>
                <asp:TextBox ID="txtfromtilldate" runat="server" CssClass="form-control" Width="100%" AutoCompleteType="Disabled"></asp:TextBox>
                <ajaxToolkit:CalendarExtender Format="dd-MM-yyyy" TodaysDateFormat="dd-MM-yyyy" ID="CalendarExtender1" runat="server" BehaviorID="TextBox1_CalendarExtender" TargetControlID="txtfromtilldate" />

              </div>


              <div class="row">
                <div class="col-md-3">
                  <div class="form-group">
                    <label for="inputActive">IsActive</label>
                    <asp:CheckBox ID="chkisactive" class="cbox" runat="server"></asp:CheckBox>
                  </div>
                </div>
                <div class="col-md-5">
                  <label for="inputOpenAsPopup">OpenAsPopup</label>
                  <asp:CheckBox ID="chkOpenAsPopup" class="cbox" runat="server"></asp:CheckBox>
                </div>
                <%--<div class="col-md-4">
                  <label for="inputDescription">Is Allow Order</label>
                  <asp:CheckBox ID="chkalloworder" class="cbox" Enabled="false" runat="server"></asp:CheckBox>
                </div>--%>
              </div>

              <div class="row">
                <div class="col-md-4">
                  <div class="form-group">
                    <a href="/Settings/Scheme.aspx" class="btn btn-secondary">Cancel</a>
                  </div>
                </div>
                <div class="col-md-8">
                  <div class="form-group">
                    <asp:LinkButton ID="btnadd" runat="server" OnClick="btnadd_Click" class="btn btn-success float-right"><i class="fas fa-save" style="margin-right:8px"></i> Add Announcement</asp:LinkButton>
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
              <h3 class="card-title">AnnounceMent Details</h3>

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
                    <th>ID</th>
                    <th>Title</th>
                    <th>Description</th>
                    <th>ToTillDate </th>
                    <th>FromTillDate </th>
                    <th>IsActive </th>
                    <th>OpenAsPopup </th>
                    <th>CreateDate </th>

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

    //function CheckAlreadyExsist() {
    //  try {

    //    $('#ContentPlaceHolder1_txtname').on("cut copy paste", function (e) {
    //      e.preventDefault();
    //    });
    //    var Scheme = $("#ContentPlaceHolder1_txtname").val();
    //    if ($("#ContentPlaceHolder1_txtname").val().length != 0) {
    //      $.ajax({
    //        type: "POST",
    //        url: "Scheme.aspx/CheckSchemeName",
    //        data: '{SchemeName:"' + Scheme + '"}',
    //        contentType: "application/json; charset=utf-8ltrerr
    //        dataType: "json",
    //        success: function (Response) {
    //          var res = Response.d;
    //          if (res == "1") {
    //            DisplayToast("!", "" + Scheme + " already exsist .", "");
    //            $("#ContentPlaceHolder1_txtname").val('');
    //            $('#ContentPlaceHolder1_chkdefault').attr("disabled", true);
    //            $('#ContentPlaceHolder1_chkallowinquiry').attr("disabled", true);
    //            $('#ContentPlaceHolder1_chkalloworder').attr("disabled", true);
    //            $("#ContentPlaceHolder1_btnadd").attr("disabled", true);
    //          }
    //          else if (res == "-1") {
    //            $('#ContentPlaceHolder1_btnadd').removeAttr('disabled');
    //            $('#ContentPlaceHolder1_chkdefault').attr("disabled", false);
    //            $('#ContentPlaceHolder1_chkallowinquiry').attr("disabled", false);
    //            $('#ContentPlaceHolder1_chkalloworder').attr("disabled", false);
    //          }
    //        },
    //        failure: function (response) {
    //        }
    //      })
    //    }
    //    else {
    //      DisplayToast("  ", "please Enter Scheme Name", "error");
    //      return;
    //    }
    //  } catch (exp) {
    //    console.log(exp);
    //  }
    //}
  </script>
</asp:Content>
