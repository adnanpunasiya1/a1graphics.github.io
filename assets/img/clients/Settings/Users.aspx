<%@ Page Title="Add/Edit User | Solar Smart" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Portal.SolarSmart.Settings.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <section class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-sm-6">
          <h1>User Details</h1>
        </div>
        <div class="col-sm-6">
          <ol class="breadcrumb float-sm-right">
            <li class="breadcrumb-item"><a href="/Dashboard/AccessDashboard.aspx">Home</a></li>
            <li class="breadcrumb-item"><a href="/Settings/ContactList.aspx">User List</a></li>
            <li class="breadcrumb-item active">Add/Edit User</li>
          </ol>
        </div>
      </div>
    </div>
    <!-- /.container-fluid -->
  </section>

  <!-- Main content -->
  <section class="content" style="padding-bottom: 2%">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-6">
          <div class="card card-primary">
            <div class="card-header">
              <h3 class="card-title">General Details</h3>

              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-card-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fas fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body">
              <div class="form-group">
                <label for="inputName">Name <span class="text-danger">*</span></label>
                <asp:TextBox ID="txtname" MaxLength="25" runat="server" class="form-control"></asp:TextBox>
              </div>
              <div class="form-group">
                <label for="inputDescription">Address <span class="text-danger">*</span></label>
                <asp:TextBox ID="txtadd" TextMode="MultiLine" runat="server" class="form-control" Rows="3" MaxLength="100"></asp:TextBox>
              </div>

              <div class="form-group">
                <label for="inputClientCompany">Email Id <span class="text-danger">*</span></label>
                <asp:TextBox ID="txtemail" runat="server" TextMode="Email" class="form-control" MaxLength="50"></asp:TextBox>
              </div>
              <div class="form-group">
                <label for="inputProjectLeader">Mobile Number <span class="text-danger">*</span></label>
                <asp:TextBox ID="txtmobile" runat="server" class="form-control" onkeypress="return isNumber(event);" MaxLength="10"></asp:TextBox>
              </div>
              <div class="form-group d-none">
                <label for="inputStatus">Blood Group <span class="text-danger">*</span></label>
                <asp:DropDownList ID="ddlBlood" class="form-control" runat="server" AutoPostBack="false" Width="100%"></asp:DropDownList>
              </div>
              <div class="form-group">
                <label for="inputStatus">Date of Birth <span class="text-danger">*</span></label>
                <asp:TextBox ID="txtDate1" runat="server" CssClass="form-control" Width="100%" AutoCompleteType="Disabled"></asp:TextBox>
                <ajaxToolkit:CalendarExtender Format="dd-MM-yyyy" TodaysDateFormat="dd-MM-yyyy" ID="TextBox1_CalendarExtender1" runat="server" BehaviorID="TextBox1_CalendarExtender1" TargetControlID="txtDate1" />
              </div>
              <hr />
              <div class="form-group">
                <label for="inputProjectLeader">Click To Call Number</label>
                <asp:TextBox ID="txtClickToCallNumber" runat="server" class="form-control" onkeypress="return isNumber(event);" MaxLength="13"></asp:TextBox>
              </div>
            </div>
            <!-- /.card-body -->
          </div>
          <!-- /.card -->

          <div class="card card-info">
            <div class="card-header">
              <h3 class="card-title">State Details</h3>

              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-card-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fas fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body">
              <div class="row">
                <div class="box-body table-responsive">
                  <asp:GridView runat="server" class="table table-bordered dataTable" AlternatingRowStyle-BackColor="#F5F5F5" HeaderStyle-BackColor="#ede8e8" HeaderStyle-HorizontalAlign="Center" EnableViewState="false" ID="grd" AutoGenerateColumns="false">
                    <Columns>

                      <asp:TemplateField HeaderText="Select">

                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <%--<HeaderTemplate>
                          <asp:CheckBox ID="chkboxSelectAll" runat="server" onclick="CheckAllEmp(this);" />
                        </HeaderTemplate>--%>
                        <ItemTemplate>
                          <asp:CheckBox ID="chkRow" runat="server" />
                          <asp:Label runat="server" Visible="false" ID="lblid" Text='<%#Eval("Id") %>'></asp:Label>
                        </ItemTemplate>
                      </asp:TemplateField>
                      <asp:BoundField DataField="StateName" HeaderText="State"></asp:BoundField>
                    </Columns>
                  </asp:GridView>
                </div>
              </div>
            </div>
            <!-- /.card-body -->
          </div>

        </div>
        <div class="col-md-6">
          <div class="card card-secondary">
            <div class="card-header">
              <h3 class="card-title">Login Details</h3>

              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-card-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fas fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body">
              <%--  <div class="form-group">
                                <label for="inputEstimatedBudget">User Name</label>
                                <asp:TextBox ID="txtusername" runat="server" class="form-control"></asp:TextBox>
                            </div>--%>
              <div class="form-group">
                <label for="inputSpentBudget">Password <span class="text-danger">*</span></label>
                <asp:TextBox ID="txtpwd" TextMode="Password" runat="server" class="form-control"></asp:TextBox>
                <label for="inputSpentBudget" id="lblupdatepass" runat="server" visible="false"><span class="text-danger">Password not Required at the time of update user details</span></label>
              </div>
              <div class="form-group">
                <label for="inputStatus">Employee Role <span class="text-danger">*</span></label>
                <asp:DropDownList ID="ddlrole" class="form-control" runat="server" AutoPostBack="false" Width="100%"></asp:DropDownList>
                <a href="RoleAccessList.aspx">View Role Base Access List</a>
              </div>
              <div class="form-group">
                <label for="inputStatus">Manager</label>
                <asp:DropDownList ID="ddlManager" class="form-control" runat="server" AutoPostBack="false" Width="100%"></asp:DropDownList>
              </div>
              <div class="form-group">
                <label for="inputProjectLeader">Pre KW Commission </label>
                <asp:TextBox ID="txtCommission" runat="server" class="form-control" onkeypress="return isNumber(event);" MaxLength="5"></asp:TextBox>
              </div>
              <div class="row">
                <div class="col-md-3">
                  <div class="form-group">
                    <asp:CheckBox ID="chkactive" Checked runat="server" Text=" Is Active"></asp:CheckBox>
                  </div>
                </div>
                <div class="col-md-9 d-none">
                  <div class="form-group">
                    <asp:CheckBox ID="chkTwoFact" runat="server" Text=" Use Two Factor Authentication (OTP)"></asp:CheckBox>
                  </div>
                </div>
              </div>
              <div class="form-group">
                <label for="inputStatus">Employee Photo</label><br />
                <asp:Image ID="imgproduct" Width="158px" Height="158px" runat="server" /><br />
                <br />
                <asp:FileUpload ID="FileUploadControl" OnDataBinding="FileUploadControl_DataBinding" OnLoad="FileUploadControl_Load" OnInit="FileUploadControl_Init" runat="server" accept=".png,.jpg,.jpeg" />
                <br />
                <span class="text-danger text-sm">Recommended: Image size 600 x 600</span>
              </div>
            </div>
            <!-- /.card-body -->
          </div>
          <!-- /.card -->
        </div>
      </div>
      <div class="row">
        <asp:Literal ID="ltrerr" runat="server"></asp:Literal>
      </div>
      <br />
      <div class="row">
        <div class="col-12">
          <a href="/Settings/ContactList.aspx" class="btn btn-secondary">Cancel</a>
          <asp:LinkButton ID="btnadd" runat="server" class="btn btn-success float-right" OnClick="btnadd_Click"><i class="fas fa-save"  style="margin-right:8px"></i> Add User</asp:LinkButton>
        </div>
      </div>
    </div>
  </section>
  <!-- /.content -->
</asp:Content>
