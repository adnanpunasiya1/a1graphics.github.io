<%@ Page Title="Role Access List | Solar Smart" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="RoleAccessList.aspx.cs" Inherits="Portal.SolarSmart.Settings.RoleAccessList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <section class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-sm-6">
          <h1 class="m-0 text-dark">Role Access List</h1>
        </div>
        <!-- /.col -->
        <div class="col-sm-6">
          <ol class="breadcrumb float-sm-right">
            <li class="breadcrumb-item"><a href="/Dashboard/MainDashboard">Home</a></li>
            <li class="breadcrumb-item active">Role Access List</li>
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
          <div class="card card-secondary">
            <div class="card-header">
              <h3 class="card-title">Role Access Details</h3>

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
                    <th>Module</th>
                    <th>Access</th>
                    <th>Administration</th>
                    <th>Office Assistant</th>
                    <th>Marketing Assistant</th>
                    <th>Site Engineer</th>

                  </tr>
                </thead>
                <tbody>

                  <tr>
                    <td>Inquiry Management</td>
                    <td>Add Quick Inquiry</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Inquiry Management</td>
                    <td>Add New Inquiry</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Inquiry Management</td>
                    <td>View Inquiry</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Inquiry Management</td>
                    <td>Edit Inquiry</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Inquiry Management</td>
                    <td>Inquiry List</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Inquiry Management</td>
                    <td>Inquiry Follow-Up List</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Inquiry Management</td>
                    <td>Add Inquiry Follow Up Call</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Inquiry Management</td>
                    <td>Inquiry Call List</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Inquiry Management</td>
                    <td>Upload Documents in Inquiry</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Inquiry Management</td>
                    <td>Dead Inquiry List</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Inquiry Management</td>
                    <td>Generate Quotation</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Inquiry Management</td>
                    <td>Quotation List</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>

                  <tr>
                    <td>Order Management</td>
                    <td>Confirm List</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Order Management</td>
                    <td>Customer Order List</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Order Management</td>
                    <td>View Customer Order</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Order Management</td>
                    <td>Edit Customer Order</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Order Management</td>
                    <td>Upload Order Documents</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Order Management</td>
                    <td>Delete Order Documents</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Order Management</td>
                    <td>Add Order Payment</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Order Management</td>
                    <td>Remove Order Payment</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Order Management</td>
                    <td>Payment List</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Order Management</td>
                    <td>Outstanding Order List</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Order Management</td>
                    <td>Payment Follow-Up List</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Order Management</td>
                    <td>Add Payment Follow-Up Call</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Order Management</td>
                    <td>Add Payment Call List</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Order Management</td>
                    <td>Generate Delivery Challan</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Order Management</td>
                    <td>Delete Delivery Challan</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Order Management</td>
                    <td>Delivery Challan List</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>

                  <tr>
                    <td>Order Management</td>
                    <td>Assign Project Work</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Order Management</td>
                    <td>Revert Assign Project Work</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Order Management</td>
                    <td>Add Stamp Paper</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Order Management</td>
                    <td>Add Stamp Paper</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Order Management</td>
                    <td>Netmeter Apply</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Order Management</td>
                    <td>Netmeter Install</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Order Management</td>
                    <td>Subsidy Document</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Order Management</td>
                    <td>Subsidy Claim</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Order Management</td>
                    <td>Order Reports and TFR Process</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>

                  <tr>
                    <td>Service Management</td>
                    <td>Add Quick Service</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Service Management</td>
                    <td>Add Order Service Call</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Service Management</td>
                    <td>Service List</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Service Management</td>
                    <td>Add Service Visit</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Service Management</td>
                    <td>Service Visit List</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Service Management</td>
                    <td>Service OTP List</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Service Management</td>
                    <td>Resend Service OTP</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Fabricator Work</td>
                    <td>Fabricator Work List</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Fabricator Work</td>
                    <td>Upload Work Data</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Foundation Work</td>
                    <td>Foundation Work List</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Foundation Work</td>
                    <td>Upload Work Data</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Installer Work</td>
                    <td>Installer Work List</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Installer Work</td>
                    <td>Upload Work Data</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                  </tr>

                  <tr>
                    <td>Procurement</td>
                    <td>Add/Edit Product</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                   <tr>
                    <td>Procurement</td>
                    <td>Product Stock List</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Procurement</td>
                    <td>Inward Product Stock</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Procurement</td>
                    <td>Delete Inward Product Stock</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Procurement</td>
                    <td>Delete Outward Product Stock</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Procurement</td>
                    <td>Procurement Reports</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>

                  <tr>
                    <td>Setting</td>
                    <td>View Company Profile</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Setting</td>
                    <td>Update Company Profile</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Setting</td>
                    <td>Add/Edit New User</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                   <tr>
                    <td>Setting</td>
                    <td>User List</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Setting</td>
                    <td>Add/Edit Scheme</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Setting</td>
                    <td>Scheme List</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Setting</td>
                    <td>Add/Edit Project Subsidy</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Setting</td>
                    <td>Project Subsidy List</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Project Calculator</td>
                    <td>Project Calculator</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>
                  <tr>
                    <td>Surya Gujarat</td>
                    <td>Surya Gujarat</td>
                    <td><%--Administration--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Office Assistant--%>
                      <img src='../../dist/img/Checked.svg' style='width: 30px;' /></td>
                    <td><%--Marketing Assistant--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                    <td><%--Site Engineer--%>
                      <img src='../../dist/img/Unchecked.svg' style='width: 30px;' /></td>
                  </tr>



                </tbody>
              </table>
            </div>
            <!-- /.card-body -->
          </div>
        </div>
      </div>
    </div>
  </section>
</asp:Content>
