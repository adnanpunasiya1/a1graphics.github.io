<%@ Page Title="AnnounceMent List | Solar Smart" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="AddGeneralDocumentManagement.aspx.cs" Inherits="Portal.SolarSmart.Settings.AddGeneralDocumentManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <section class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-sm-6">
          <h1 class="m-0 text-dark">Add General Document Management </h1>
        </div>
        <!-- /.col -->
        <div class="col-sm-6">
          <ol class="breadcrumb float-sm-right">
            <li class="breadcrumb-item"><a href="/Dashboard/AccessDashboard">Home</a></li>
            <li class="breadcrumb-item active">Add General Document Management </li>
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
              <h3 class="card-title">Add GeneralDocumentManagement</h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-card-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fas fa-minus"></i>
                </button>

              </div>
            </div>
            <div class="card-body">
              <a href="/settings/GeneralDocumentManagementList" class="btn btn-success" style="float: inline-end; margin-bottom: 20px">List GDM</a>

              <div class="form-group">
                <label for="inputName">Title <span class="text-danger">*</span></label><br />

                <asp:TextBox ID="txtTitle" placeholder="Enter Title" runat="server" class="form-control"></asp:TextBox>

              </div>
              <div class="form-group">
                <label for="inputName">Description <span class="text-danger">*</span></label><br />
                <asp:TextBox ID="txtdesc" TextMode="MultiLine" placeholder="Enter Description" runat="server" class="form-control"></asp:TextBox>

              </div>
              <div class="form-group">

                <asp:Label runat="server" ID="lblftd" Text="Add Document:"></asp:Label><br />
                <asp:FileUpload ID="fileDocument" runat="server" />

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
                  <asp:LinkButton ID="btnadd" runat="server" OnClick="btnadd_Click" class="btn btn-success float-right"><i class="fas fa-save" style="margin-right:8px"></i> Add Document</asp:LinkButton>
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
    </div>
  </section>
  <script>
    $(document).ready(function () {
      $('#ContentPlaceHolder1_btnadd').attr('disabled', 'disabled');
    })
    function chkAE() {
      CheckAlreadyExsist();
    }
  </script>
</asp:Content>
