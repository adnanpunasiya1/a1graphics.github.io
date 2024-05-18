<%@ Page Title="Update Company Profile | Solar Smart" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="AddCompanyDetails.aspx.cs" Inherits="Portal.SolarSmart.Settings.AddCompanyDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <section class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-sm-6">
          <h1>Update Company Profile</h1>
        </div>
        <div class="col-sm-6">
          <ol class="breadcrumb float-sm-right">
            <li class="breadcrumb-item"><a href="/Dashboard/AccessDashboard.aspx">Home</a></li>
            <li class="breadcrumb-item"><a href="/Settings/CompanyProfile">Company Profile</a></li>
            <li class="breadcrumb-item active">Update Company Profile</li>
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
              <h3 class="card-title">Company Details</h3>

              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-card-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fas fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body">
              <div class="form-group">
                <label for="inputName">Company Name <span class="text-danger">*</span></label>
                <asp:TextBox ID="txtname" MaxLength="75" runat="server" class="form-control"></asp:TextBox>
              </div>
              <div class="form-group">
                <label for="inputDescription">Company Address <span class="text-danger">*</span></label>
                <asp:TextBox ID="txtadd" TextMode="MultiLine" runat="server" class="form-control" Rows="3" MaxLength="100"></asp:TextBox>
              </div>
              <div class="form-group">
                <label for="inputName">Company City <span class="text-danger">*</span></label>
                <asp:TextBox ID="txtCity" MaxLength="75" runat="server" class="form-control"></asp:TextBox>
              </div>
              <div class="form-group">
                <label for="inputName">Company State <span class="text-danger">*</span></label>
                <asp:TextBox ID="txtState" MaxLength="75" runat="server" class="form-control"></asp:TextBox>
              </div>
              <div class="form-group">
                <label for="inputClientCompany">Company Email Id <span class="text-danger">*</span></label>
                <asp:TextBox ID="txtemail" runat="server" TextMode="Email" class="form-control" MaxLength="50"></asp:TextBox>
              </div>
              <div class="form-group">
                <label for="inputProjectLeader">Company Contact Number <span class="text-danger">*</span></label>
                <asp:TextBox ID="txtmobile" runat="server" class="form-control" onkeypress="return isNumber(event);" MaxLength="10"></asp:TextBox>
              </div>
              <div class="form-group">
                <label for="inputName">Company Website</label>
                <asp:TextBox ID="txtWebsite" runat="server" class="form-control"></asp:TextBox>
              </div>

            </div>
            <!-- /.card-body -->
          </div>
          <!-- /.card -->
        </div>
        <div class="col-md-6">
          <div class="card card-primary">
            <div class="card-header">
              <h3 class="card-title">Company Bank Details</h3>

              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-card-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fas fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body">
              <div class="form-group">
                <label for="inputName">GST Number</label>
                <asp:TextBox ID="txtGSTNo" MaxLength="75" runat="server" class="form-control"></asp:TextBox>
              </div>
              <div class="form-group">
                <label for="inputDescription">Company Bank Name</label>
                <asp:TextBox ID="txtCompanyBankName" runat="server" class="form-control"></asp:TextBox>
              </div>
              <div class="form-group">
                <label for="inputName">Company Bank Account Name</label>
                <asp:TextBox ID="txtCompanyBankAccountName" runat="server" class="form-control"></asp:TextBox>
              </div>
              <div class="form-group">
                <label for="inputName">Company Bank Account No</label>
                <asp:TextBox ID="txtCompanyBankAccountNo" runat="server" class="form-control"></asp:TextBox>
              </div>
              <div class="form-group">
                <label for="inputClientCompany">Company Bank IFSC Code</label>
                <asp:TextBox ID="txtCompanyBankIFSCCode" runat="server" class="form-control"></asp:TextBox>
              </div>
              <div class="form-group">
                <label for="inputProjectLeader">Company Bank Branch</label>
                <asp:TextBox ID="txtCompanyBankBranch" runat="server" class="form-control"></asp:TextBox>
              </div>
            </div>
            <!-- /.card-body -->
          </div>
          <!-- /.card -->
        </div>
        <div class="col-md-6">
          <div class="card card-secondary">
            <div class="card-header">
              <h3 class="card-title">Owner Details</h3>

              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-card-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fas fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body">
              <div class="form-group">
                <label for="inputEstimatedBudget">Owner Name <span class="text-danger">*</span></label>
                <asp:TextBox ID="txtOwnerName" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
              </div>
              <div class="form-group">
                <label for="inputClientCompany">Owner Email Id <span class="text-danger">*</span></label>
                <asp:TextBox ID="txtOwnerEmail" runat="server" TextMode="Email" class="form-control" MaxLength="50" ReadOnly="true"></asp:TextBox>
              </div>
              <div class="form-group">
                <label for="inputProjectLeader">Owner Contact Number <span class="text-danger">*</span></label>
                <asp:TextBox ID="txtOwnerMobile" runat="server" class="form-control" onkeypress="return isNumber(event);" MaxLength="10" ReadOnly="true"></asp:TextBox>
              </div>
            </div>
            <!-- /.card-body -->
          </div>
          <!-- /.card -->
        </div>

        <div class="col-md-6">
          <div class="card card-secondary">
            <div class="card-header">
              <h3 class="card-title">Logo and Letterhead Details</h3>

              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-card-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fas fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body">
              <div class="form-group">
                <label for="inputStatus">Company Logo <span class="text-danger">*</span></label><br />
                <asp:FileUpload ID="fuLogo" runat="server" accept=".png,.jpg,.jpeg" />
                <asp:HiddenField ID="hnd_Logo" runat="server" />
                <br />
                <span class="text-danger text-sm">Recommended: Image size 600(w) x 600(h) px</span>
              </div>
              <div class="form-group">
                <label for="inputStatus">Letterhead Header</label><br />
                <asp:FileUpload ID="fuHeader" runat="server" accept=".png,.jpg,.jpeg" />
                <asp:HiddenField ID="hnd_Header" runat="server" />
                <br />
                <span class="text-danger text-sm">Recommended: Image size 1900(w) x 300(h) px</span>
              </div>
              <div class="form-group">
                <label for="inputStatus">Letterhead Footer</label><br />
                <asp:FileUpload ID="fuFooter" runat="server" accept=".png,.jpg,.jpeg" />
                <asp:HiddenField ID="hnd_Footer" runat="server" />
                <br />
                <span class="text-danger text-sm">Recommended: Image size 1900(w) x 300(h) px</span>
              </div>
              <div class="form-group">
                <label for="inputStatus">Letterhead Watermark</label><br />
                <asp:FileUpload ID="fuWatermark" runat="server" accept=".png,.jpg,.jpeg" />
                <asp:HiddenField ID="hnd_Watermark" runat="server" />
                <br />
                <span class="text-danger text-sm">Recommended: Image size 600(w) x 600(h) px</span>
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
          <asp:LinkButton ID="btnadd" runat="server" class="btn btn-success float-right" OnClick="btnadd_Click"><i class="fas fa-save"  style="margin-right:8px"></i> Update</asp:LinkButton>
        </div>
      </div>
    </div>
  </section>
  <!-- /.content -->
</asp:Content>
