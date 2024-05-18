<%@ Page Title="User Profile | Solar Smart" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Portal.SolarSmart.Settings.UserProfile" %>
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
                    <h1 class="m-0 text-dark">User Profile</h1>
                </div>
                <!-- /.col -->
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="/Dashboard/AccessDashboard">Home</a></li>
                        <li class="breadcrumb-item"><a href="/Settings/ContactList.aspx">User List</a></li>
                        <li class="breadcrumb-item active">User Profile</li>
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


                            <asp:Literal runat="server" ID="ltrEmpName"></asp:Literal>

                            <asp:Literal runat="server" ID="ltrRole"></asp:Literal>


                            <ul class="list-group list-group-unbordered mb-3">
                                <li class="list-group-item">
                                    <b>Username</b>
                                    <asp:Literal runat="server" ID="ltrUsername"></asp:Literal>
                                </li>
                                <li class="list-group-item">
                                    <b>Mobile Number</b>
                                    <asp:Literal runat="server" ID="ltrMobile"></asp:Literal>
                                </li>
                                <li class="list-group-item">
                                    <b>Email</b>
                                    <asp:Literal runat="server" ID="ltrEmail"></asp:Literal>
                                </li>
                              <li class="list-group-item" id="liPassword" runat="server">
                                    <b>PWd:</b>
                                    <asp:Literal runat="server" ID="ltrPassword"></asp:Literal>
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

                            <strong><i class="fas fa-birthday-cake mr-1"></i>Date of Birth</strong>

                            <asp:Literal runat="server" ID="ltrDOB"></asp:Literal>

                            <hr>

                            <strong><i class="fas fa-tint mr-1"></i>Blood Group</strong>

                            <asp:Literal runat="server" ID="ltrBG"></asp:Literal>
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
                                <li class="nav-item"><a class="nav-link active" href="#activity" data-toggle="tab">Activity</a></li>
                                <li class="nav-item" id="liTeam" runat="server"><a class="nav-link" href="#team" data-toggle="tab">Team</a></li>
                                <li class="nav-item" id="liPwd" runat="server"><a class="nav-link" href="#pwd" data-toggle="tab">Change Password</a></li>
                                <li class="nav-item" id="liDoc" runat="server"><a class="nav-link" href="#Document" data-toggle="tab">Documents</a></li>
                            </ul>
                        </div>
                        <!-- /.card-header -->
                        <div class="card-body ">
                            <div class="tab-content">
                                <div class="active tab-pane" id="activity">
                                    <!-- Post -->
                                    <div class="post">
                                        <div class="callout callout-success">
                                            <h5>Login Time: <span runat="server" id="spLoginTime"></span></h5>
                                        </div>

                                        <div class="row col-md-12">
                                            <div class="card card-solid col-md-12 mt-3" id="div3" runat="server">
                                                <div class="card-header">
                                                    <h3 class="card-title"><i class="fas fa-tasks" style="margin-right: 10px;"></i>Activities</h3>

                                                    <div class="card-tools">
                                                        <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                                            <i class="fas fa-minus"></i>
                                                        </button>
                                                    </div>
                                                    <!-- /.card-tools -->
                                                </div>
                                                <div class="card-body">
                                                    <div class="row mb-5">
                                                        <div class="col-md-1">
                                                        </div>
                                                        <div class="col-md-3">

                                                            <asp:Label runat="server" ID="lblfrm" Text="From Date:"></asp:Label>

                                                            <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" Width="100%" AutoCompleteType="Disabled"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender Format="dd-MM-yyyy" TodaysDateFormat="dd-MM-yyyy" ID="TextBox1_CalendarExtender" runat="server" BehaviorID="TextBox1_CalendarExtender" TargetControlID="txtDate" />

                                                        </div>

                                                        <div class="col-md-3">

                                                            <asp:Label runat="server" ID="lblto" Text="To Date:"></asp:Label>

                                                            <asp:TextBox ID="txtDate1" runat="server" CssClass="form-control" Width="100%" AutoCompleteType="Disabled"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender Format="dd-MM-yyyy" TodaysDateFormat="dd-MM-yyyy" ID="TextBox1_CalendarExtender1" runat="server" BehaviorID="TextBox1_CalendarExtender1" TargetControlID="txtDate1" />

                                                        </div>
                                                        <div class="col-md-3">
                                                            <br />
                                                            <asp:LinkButton ID="btnSearch" runat="server" class="btn btn-primary" OnClick="btnSearch_Click" Width="100px"><i class="fa fa-search"></i> Search</asp:LinkButton>
                                                        </div>
                                                        <div class="col-md-1">
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <table id="example1" class="table table-bordered table-striped table-responsive mt-3">
                                                            <thead>
                                                                <tr>
                                                                    <th>Time</th>
                                                                    <th>URL</th>
                                                                    <th>Action</th>
                                                                    <th>IP Address</th>
                                                                    <th>Browser</th>
                                                                    <th>Location</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <asp:Literal runat="server" ID="ltrActivites"></asp:Literal>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.post -->
                                </div>
                                <!-- /.tab-pane -->
                                <div class="tab-pane" id="team">
                                    <!-- Default box -->
                                    <div class="card card-solid">
                                        <div class="card-body pb-0">
                                            <div class="row d-flex align-items-stretch">
                                                <asp:Literal runat="server" ID="rowData" EnableViewState="false"></asp:Literal>
                                            </div>
                                        </div>
                                        <!-- /.card-body -->
                                        <div class="card-footer">
                                            <asp:Literal runat="server" ID="AddUserTeam" EnableViewState="false"></asp:Literal>
                                        </div>
                                        <!-- /.card-footer -->
                                    </div>
                                    <!-- /.card -->
                                </div>
                                <!-- /.tab-pane -->

                                <div class="tab-pane" id="pwd">
                                    <div class="form-group row">
                                        <label class="col-sm-2 col-form-label">Current Password</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox TextMode="Password" runat="server" ID="txtPasswordLogin" MaxLength="50" CssClass="form-control" placeholder="Current Password"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-sm-2 col-form-label">New Password</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox TextMode="Password" runat="server" ID="txtNewPassword" MaxLength="50" CssClass="form-control" placeholder="New Password"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-sm-2 col-form-label">Confirm Password</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox TextMode="Password" runat="server" ID="txtConfPassword" MaxLength="50" CssClass="form-control" placeholder="New Password"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="offset-sm-2 col-sm-10">
                                            <asp:Button ID="btnChange" runat="server" class="btn btn-danger" Text="Change" OnClick="btnChange_Click" />
                                        </div>
                                    </div>

                                </div>
                                <!-- /.tab-pane -->

                                <div class="tab-pane" id="Document">
                                    <!-- Post -->
                                    <div class="post">
                                        <div class="row col-md-12">
                                            <div class="col-md-4 form-group">
                                                <label for="inputDescription">Document Type <span class="text-danger">*</span></label>
                                                <asp:DropDownList ID="ddldoctype" ClientIDMode="Static" class="form-control" runat="server" AutoPostBack="false" Width="100%"></asp:DropDownList>

                                            </div>
                                            <div class="col-md-4 form-group">
                                                <label for="inputStatus">Upload Document <span class="text-danger">*</span></label><br />
                                                <asp:FileUpload ID="fuworkupload" runat="server" accept=".png,.jpg,.jpeg,.pdf,.xls" />
                                                <br />
                                            </div>
                                            <div class="col-md-4 mt-3 form-group">
                                                <asp:LinkButton ID="btnupload" OnClick="btnupload_Click" runat="server" class="btn btn-success float-right"><i class="fas fa-save "  style="margin-right:8px"></i> Upload</asp:LinkButton>
                                            </div>
                                        </div>

                                       
                                            <div class="card card-warning mt-4">
                                                <div class="card-header">
                                                    <h3 class="card-title">User Document Files</h3>

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
                                                                <th>Upload By</th>
                                                                <th>Upload On</th>
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
