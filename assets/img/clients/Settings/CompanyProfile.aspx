<%@ Page Title="Comapny Profile | Solar Smart" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="CompanyProfile.aspx.cs" Inherits="Portal.SolarSmart.Settings.CompanyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="overlay" style="display: none" id="loading">
    <img src="../../Logo/l1.gif" style="margin-left: auto; margin-right: auto; display: block; margin-top: 15%; /* margin-bottom: auto; */" />
  </div>
  <section class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-sm-6">
          <h1 class="m-0 text-dark">Comapny Profile</h1>
        </div>
        <!-- /.col -->
        <div class="col-sm-6">
          <ol class="breadcrumb float-sm-right">
            <li class="breadcrumb-item"><a href="/Dashboard/AccessDashboard">Home</a></li>
            <li class="breadcrumb-item active">Comapny Profile</li>
          </ol>
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->
    </div>
    <!-- /.container-fluid -->
  </section>
  <!-- /.content-header -->

  <!-- Main content -->
  <section class="content">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-4">

          <!-- Profile Image -->
          <div class="card card-primary card-outline">
            <div class="card-body box-profile">
              <div class="text-center">
                <asp:Literal runat="server" ID="ltrProfilePic"></asp:Literal>
              </div>


              <asp:Literal runat="server" ID="ltrComapnyName"></asp:Literal>

              <asp:Literal runat="server" ID="ltrCustomerCode"></asp:Literal>


              <ul class="list-group list-group-unbordered mb-3">
                <li class="list-group-item">
                  <b>Owner Name</b>
                  <asp:Literal runat="server" ID="ltrUsername"></asp:Literal>
                </li>
                <li class="list-group-item">
                  <b>Owner Number</b>
                  <asp:Literal runat="server" ID="ltrMobile"></asp:Literal>
                </li>
                <li class="list-group-item">
                  <b>Owner Email</b>
                  <asp:Literal runat="server" ID="ltrEmail"></asp:Literal>
                </li>
              </ul>


              <asp:Literal runat="server" ID="ltrWhatsapp"></asp:Literal>
            </div>
            <!-- /.card-body -->
          </div>
          <!-- /.card -->

          <!-- About Me Box -->
          <div class="card card-primary">
            <div class="card-header">
              <h3 class="card-title">About Me</h3>
            </div>
            <!-- /.card-header -->
            <div class="card-body">
              <strong><i class="fas fa-map-marker-alt mr-1"></i>Address</strong>


              <asp:Literal runat="server" ID="ltrAddress"></asp:Literal>
              <hr>

              <strong><i class="fas fa-phone mr-1"></i>Contact Number</strong>

              <asp:Literal runat="server" ID="ltrComapnyContactNo"></asp:Literal>

              <hr>

              <strong><i class="fas fa-envelope mr-1"></i>Company EmailId</strong>

              <asp:Literal runat="server" ID="ltrComapnyEmailId"></asp:Literal>
              <hr>

              <strong><i class="fas  fa-globe mr-1"></i>Company Website</strong>

              <asp:Literal runat="server" ID="ltrWebsite"></asp:Literal>
            </div>
            <!-- /.card-body -->
          </div>
          <!-- /.card -->
        </div>
        <!-- /.col -->
        <div class="col-md-8">
          <div class="card">
            <div class="card-header p-2">
              <ul class="nav nav-pills">
                <li class="nav-item"><a class="nav-link active" href="#activity" data-toggle="tab">Bank Details</a></li>
                <li class="nav-item" id="liDoc" runat="server"><a class="nav-link" href="#Document" data-toggle="tab">Letterhead Images</a></li>
              </ul>
            </div>
            <!-- /.card-header -->
            <div class="card-body ">
              <div class="tab-content">
                <div class="active tab-pane" id="activity">
                  <!-- Post -->
                  <div class="post">

                    <strong><i class="far fa-file-alt  mr-1"></i>GST Number</strong>


                    <asp:Literal runat="server" ID="ltrGSTNo"></asp:Literal>
                    <hr>

                    <strong><i class="far fa-file-alt mr-1"></i>CompanyBankName</strong>

                    <asp:Literal runat="server" ID="ltrCompanyBankName"></asp:Literal>

                    <hr>

                    <strong><i class="far fa-file-alt mr-1"></i>CompanyBankAccountName</strong>

                    <asp:Literal runat="server" ID="ltrCompanyBankAccountName"></asp:Literal>
                    <hr>

                    <strong><i class="far fa-file-alt mr-1"></i>CompanyBankAccountNo</strong>

                    <asp:Literal runat="server" ID="ltrCompanyBankAccountNo"></asp:Literal>
                    <hr>

                    <strong><i class="far fa-file-alt mr-1"></i>CompanyBankIFSCCode</strong>

                    <asp:Literal runat="server" ID="ltrCompanyBankIFSCCode"></asp:Literal>

                    <hr>

                    <strong><i class="far fa-file-alt mr-1"></i>CompanyBankBranch</strong>

                    <asp:Literal runat="server" ID="ltrCompanyBankBranch"></asp:Literal>


                  </div>
                  <!-- /.post -->
                </div>
                <!-- /.tab-pane -->
               

             

                <div class="tab-pane" id="Document">
                  <!-- Post -->
                  <div class="post">
                    

                    <div class="card card-warning mt-4">
                      <div class="card-header">
                        <h3 class="card-title">Letterhead Images</h3>

                        <div class="card-tools">
                          <button type="button" class="btn btn-tool" data-card-widget="collapse" data-toggle="tooltip" title="Collapse">
                            <i class="fas fa-minus"></i>
                          </button>
                        </div>
                      </div>
                      <div class="card-body p-0">
                        <table class="table table-responsive">
                          <thead>
                            <tr>
                              <th>Type</th>
                              <th></th>
                              <th></th>
                            </tr>
                          </thead>
                          <tbody>

                            <asp:Literal runat="server" ID="rowWork"></asp:Literal>

                          </tbody>
                        </table>
                      </div>
                      <!-- /.card-body -->
                    </div>

                  </div>
                  <!-- /.post -->
                </div>
                <!-- /.tab-pane -->
              </div>
              <!-- /.tab-content -->
            </div>
            <!-- /.card-body -->
          </div>
          <!-- /.nav-tabs-custom -->
          <a href="/Settings/AddCompanyDetails" class="btn btn-secondary">Update Details</a>
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->
    </div>
    <!-- /.container-fluid -->
  </section>
  <!-- /.content -->

  <script>
    $(function () {
      $("#example2").DataTable();
      $('#example1').DataTable({
        "paging": true,
        "lengthChange": true,
        "searching": false,
        "ordering": true,
        "order": [[0, "desc"]],
        "info": true,
        "autoWidth": false,
      });
    });
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
            url: "UserProfile.aspx/RemoveEntry",
            data: '{Id: "' + id + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",

            success: function (response) {
              if (response.d == "1") {
                $('#loading').hide();
                DisplayToast("Send", "Document Removed Successfully.", "success");

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
