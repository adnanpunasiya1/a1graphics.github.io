
<%@ Page Title="AnnounceMent List | Solar Smart" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="GeneralDocumentManagementList.aspx.cs" Inherits="Portal.SolarSmart.Settings.GeneralDocumentManagementList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <section class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-sm-6">
          <h1 class="m-0 text-dark"> Document Management List</h1>
        </div>
        <!-- /.col -->
        <div class="col-sm-6">
          <ol class="breadcrumb float-sm-right">
            <li class="breadcrumb-item"><a href="/Dashboard/AccessDashboard">Home</a></li>
            <li class="breadcrumb-item active"> Document Management List</li>
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
   <asp:Literal runat="server" ID="ltrerr"></asp:Literal>
 </div>
      <div class="row">
        
           <div class="col-md-12">
     <div class="card card-secondary">
       <div class="card-header">
         <h3 class="card-title">DocumentManagementList</h3>

         <div class="card-tools">
           <button type="button" class="btn btn-tool" data-card-widget="collapse" data-toggle="tooltip" title="Collapse">
             <i class="fas fa-minus"></i>
           </button>
         </div>
       </div>
       <div class="card-body">
         <a href="/settings/AddGeneralDocumentManagement" class="btn btn-success" style="float:inline-end;margin-bottom:20px"><i class="fa fa-plus "></i> Add GDM</a>
         <table id="example1" class="table table-bordered table-striped table-responsive">
           <thead>
             <tr>
               <th>Action</th>
               <th>ID</th>
               <th>Title</th>
               <th>Description</th>
               <th>Document </th>
               <th>CreateDate </th>
               <th>View </th>
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
    function share(Documents) {

      var urlToShare = "https://crm.solarsmart.co.in/" + Documents;
          navigator.share({ url: urlToShare })
        .then(() => console.log('Successful share'))
        .catch((error) => console.log('Error sharing:', error));
    }
    function downloadFile(fileName) {
      $.ajax({
        type: "POST",
        url: "GeneralDocumentManagementList/DownLoadFile",
        data: JSON.stringify({ FileName: fileName }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
          // Handle success, if needed
          console.log("File downloaded successfully.");
        },
        error: function (xhr, textStatus, errorThrown) {
          // Handle error, if needed
          console.error("Error downloading file:", errorThrown);
        }
      });
    }

  </script>
</asp:Content>
