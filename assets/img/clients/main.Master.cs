using System;
using System.Data;
using System.Linq;
using System.Web;

namespace Portal.SolarSmart
{
  public partial class main : System.Web.UI.MasterPage
  {
    MySQLDB dbCon = new MySQLDB();
    ClsDashboard clsdash = new ClsDashboard();
    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        lblDateTime.Text = String.Format("{0:ddd, MMM d, yyyy}", dbCon.getindiantime());

        if (!Request.Cookies.AllKeys.Contains(clsGlobal.CookiesGroupName))
        {
          Response.Redirect("~/login.aspx");
        }
        else
        {
          int userId = 0;
          int.TryParse(clsGlobal.GetCookiesData("UserId"), out userId);
          int RoleId = 0;
          int.TryParse(clsGlobal.GetCookiesData("RoleId"), out RoleId);
          int CompanyId = 0;
          int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);

          DataTable dtUser = dbCon.GetData("Select * from user where IsActive = 1 AND Id = " + userId);
          if (dtUser != null && dtUser.Rows.Count > 0)
          {
            if (String.IsNullOrEmpty(dtUser.Rows[0]["vCardCode"].ToString()))
            {

              txtContactLink.Text = clsGlobal.BaseURLWeb + "/vCard?uid=" + userId;
            }
            else
            {
              txtContactLink.Text = "https://ilit.cc/" + dtUser.Rows[0]["vCardCode"].ToString() + "";
            }
          }

          //lblUserName.InnerText = clsGlobal.GetCookiesData("Name").ToString();
          userName.Text = " <a href='/Settings/UserProfile.aspx?Id=" + userId + "'> <span id='lblUserName' class='d-block' runat='server'>" + clsGlobal.GetCookiesData("Name").ToString() + "</span></a>";

          GetPlannerData();
          CheckPlanDetails();

          string userImage = "";
          if (!string.IsNullOrEmpty(clsGlobal.GetCookiesData("UserPhoto").ToString()))
          {
            userImage = clsGlobal.UserImagePathWeb + clsGlobal.GetCookiesData("UserPhoto").ToString();
          }
          else
          {
            userImage = clsGlobal.UserImagePathWeb + clsGlobal.defaultUserImage;
          }

          imguserPhoto.Src = userImage;

          AdminPageTracking.PageLoadTrack(userId, clsGlobal.GetCookiesData("Name").ToString(), Request);
          UserTracking.UserActionTrack("Web Page Visit");

          CheckSetupProcess();

          //if (RoleId == 4)
          //{
          //  pageredirection.HRef = "/Dashboard/MainDashboardFeb.aspx";
          //}
          //else if (RoleId == 15)
          //{
          //  pageredirection.HRef = "/Dashboard/MainDashboardFeb.aspx";
          //}
          //else if (RoleId == 17 || RoleId == 13) //Service
          //{
          //  //Response.Redirect("~/Dashboard/MainDashboardServ.aspx");
          //  pageredirection.HRef = "/Dashboard/MainDashboardServ.aspx";
          //}
          //else
          //{
          //  pageredirection.HRef = "/Dashboard/Dashboard.aspx";
          //}

          if (RoleId != 16)
          {
            liDashboard.Visible = false;
            liAccessDashboard.Visible = false;
            liProjectDashboard.Visible = false;
            liDailyWorkDashboard.Visible = false;
            liInquiryDashboard.Visible = false;
            liInquiryAnalysis.Visible = false;
            liServiceAnalysis.Visible = false;

            liQuickLead.Visible = false;

            liPlanner.Visible = false;

            liMarketing.Visible = false;
            liMarketingAdd.Visible = false;
            liMarketingList.Visible = false;
            liMarketingReminderList.Visible = false;
            liCallList.Visible = false;
            liDeadInquiry.Visible = false;
            liAssignInquiry.Visible = false;
            liBulkInquiryImport.Visible = false;
            liClientQuotList.Visible = false;

            liCustomerOrder.Visible = false;
            liConfirmList.Visible = false;
            liOrderList.Visible = false;
            liOrderStatusReport.Visible = false;
            liOrderDeliveryStatusReport.Visible = false;
            liOrderStatusDeliveryStatusReport.Visible = false;
            liOrderDeliveryList.Visible = false;
            liCancelOrder.Visible = false;
            liInvoiceList.Visible = false;

            liReport.Visible = false;
            liDailyOrderActivity.Visible = false;
            liStampPaper.Visible = false;
            liOrderSubsidyDocumentReport.Visible = false;
            liSubdivisionCount.Visible = false;
            liSubdivisionList.Visible = false;

            liPaymentManagement.Visible = false;
            liPaymentList.Visible = false;
            liOutstandingList.Visible = false;
            liPaymentReminderList.Visible = false;
            liPaymentCallList.Visible = false;
            liPaymentAuditReport.Visible = false;

            liQuickService.Visible = false;

            liServiceManage.Visible = false;
            liMainteList.Visible = false;
            liServiceVisitList.Visible = false;
            liServiceOTPList.Visible = false;
            liAssignServiceVisit.Visible = false;

            //liFebWork.Visible = false;
            //liFebWorkList.Visible = false;
            //liFabServiceList.Visible = false;

            //liFoundation.Visible = false;
            //liFoundationList.Visible = false;

            liInstalWork.Visible = false;
            liInstalWorkList.Visible = false;
            //liInstallerServiceList.Visible = false;

            liProcurement.Visible = false;
            liProductAdd.Visible = false;
            liProductStock.Visible = false;
            liGenerateStockInward.Visible = false;
            liStockInwardChallanList.Visible = false;
            liStockAddedList.Visible = false;
            liStockUsageList.Visible = false;
            liProductSerialNoList.Visible = false;
            liImportPanelSerialNo.Visible = false;

            liSettings.Visible = false;
            licompanyProfile.Visible = false;
            usermgmt.Visible = false;
            liSchema.Visible = false;
            liState.Visible = false;
            liSubsidyList.Visible = false;
            liSupplierList.Visible = false;
            liDivisionMaster.Visible = false;
            liSubDivisionMaster.Visible = false;

            if (RoleId == 3)
            {
              liProjectCalculator.Visible = false;
              liSuryaGujarat.Visible = false;
            }
            if (RoleId == 2)
            {
              liSuryaGujarat.Visible = false;
            }


            if (!getCurrentPageName().Contains("/noaccess") && !getCurrentPageName().Contains("/settings/roleaccesslist") && !getCurrentPageName().Contains("/settings/userprofile"))
            {
              bool showPage = isPageAccessible(userId, getCurrentPageName());
              if (showPage == false)
              {
                Response.Redirect("~/noaccess");
              }
            }

            clsdash.CustomerId = CompanyId;
            clsdash.UserId = RoleId;
            DataTable dtpages = clsdash.DataPagesByRoleId();
            for (int i = 0; i < dtpages.Rows.Count; i++)
            {
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/dashboard/accessdashboard"))
              {
                liDashboard.Visible = true;
                liAccessDashboard.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/dashboard/projectdashboard"))
              {
                liDashboard.Visible = true;
                liProjectDashboard.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/dashboard/dailyworkdashboard"))
              {
                liDashboard.Visible = true;
                liDailyWorkDashboard.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/dashboard/inquirydashboard"))
              {
                liDashboard.Visible = true;
                liInquiryDashboard.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/dashboard/inquiryanalysis"))
              {
                liDashboard.Visible = true;
                liInquiryAnalysis.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/dashboard/serviceanalysis"))
              {
                liDashboard.Visible = true;
                liServiceAnalysis.Visible = true;
              }

              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/addmarketingleadquick"))
              {
                liQuickLead.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/planner/plannercalendar"))
              {
                liPlanner.Visible = true;
              }

              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/addmarketinglead"))
              {
                liMarketing.Visible = true;
                liMarketingAdd.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/marketingleadlist"))
              {
                liMarketing.Visible = true;
                liMarketingList.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/marketingleadreminderlist"))
              {
                liMarketing.Visible = true;
                liMarketingReminderList.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/marketingleadcalllist"))
              {
                liMarketing.Visible = true;
                liCallList.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/marketingleaddeadlist"))
              {
                liMarketing.Visible = true;
                liDeadInquiry.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/assignmarketinglead"))
              {
                liMarketing.Visible = true;
                liAssignInquiry.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/bulkimportmarketinglead"))
              {
                liMarketing.Visible = true;
                liBulkInquiryImport.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/customerquotation/clientquotationlist"))
              {
                liMarketing.Visible = true;
                liClientQuotList.Visible = true;
              }

              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/marketingleadconfirmlist"))
              {
                liCustomerOrder.Visible = true;
                liConfirmList.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/marketingleadorderview"))
              {
                liCustomerOrder.Visible = true;
                liOrderList.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/orderstatusreport"))
              {
                liCustomerOrder.Visible = true;
                liOrderStatusReport.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/orderdeliverystatusreport"))
              {
                liCustomerOrder.Visible = true;
                liOrderDeliveryStatusReport.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/orderstatusdeliverystatusreport"))
              {
                liCustomerOrder.Visible = true;
                liOrderStatusDeliveryStatusReport.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/orderdeliverylist"))
              {
                liCustomerOrder.Visible = true;
                liOrderDeliveryList.Visible = true;
              }
            
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/cancelorderlist"))
              {
                liCustomerOrder.Visible = true;
                liCancelOrder.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/invoicelist"))
              {
                liCustomerOrder.Visible = true;
                liInvoiceList.Visible = true;
              }

              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/dailyorderactivitylist"))
              {
                liReport.Visible = true;
                liDailyOrderActivity.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/stamppaperreport"))
              {
                liReport.Visible = true;
                liStampPaper.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/ordersubsidydocumentreport"))
              {
                liReport.Visible = true;
                liOrderSubsidyDocumentReport.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/ordersubdivisionnetmeterpending"))
              {
                liReport.Visible = true;
                liSubdivisionCount.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/ordersubdivisionnetmeterpendinglist"))
              {
                liReport.Visible = true;
                liSubdivisionList.Visible = true;
              }

              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/paymentlist"))
              {
                liPaymentManagement.Visible = true;
                liPaymentList.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/outstandingorderlist"))
              {
                liPaymentManagement.Visible = true;
                liOutstandingList.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/orderpaymentreminderlist"))
              {
                liPaymentManagement.Visible = true;
                liPaymentReminderList.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/orderpaymentcalllist"))
              {
                liPaymentManagement.Visible = true;
                liPaymentCallList.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/paymentauditreport"))
              {
                liPaymentManagement.Visible = true;
                liPaymentAuditReport.Visible = true;
              }

              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/addquickservice"))
              {
                liQuickService.Visible = true;
              }

              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/maintenancelist"))
              {
                liServiceManage.Visible = true;
                liMainteList.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/maintenancevisitlist"))
              {
                liServiceManage.Visible = true;
                liServiceVisitList.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/serviceotplist"))
              {
                liServiceManage.Visible = true;
                liServiceOTPList.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/assignservicevisit"))
              {
                liServiceManage.Visible = true;
                liAssignServiceVisit.Visible = true;
              }

              //if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/fabricatorworklist"))
              //{
              //  liFebWork.Visible = true;
              //  liFebWorkList.Visible = true;
              //}
              //if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/fabricatormaintenancelist"))
              //{
              //  liInstalWorkList.Visible = true;
              //  liFabServiceList.Visible = true;
              //}

              //if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/foundation/foundationworklist"))
              //{
              //  liFoundation.Visible = true;
              //  liFoundationList.Visible = true;
              //}

              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/installerworklist"))
              {
                liInstalWork.Visible = true;
                liInstalWorkList.Visible = true;
              }
              //if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/marketinglead/installermaintenancelist"))
              //{
              //  liInstalWork.Visible = true;
              //  liInstallerServiceList.Visible = true;
              //}

              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/stock/addproduct"))
              {
                liProcurement.Visible = true;
                liProductAdd.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/stock/productlist"))
              {
                liProcurement.Visible = true;
                liProductStock.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/stock/generatestockinward"))
              {
                liProcurement.Visible = true;
                liGenerateStockInward.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/stock/stockinwardchallanlist"))
              {
                liProcurement.Visible = true;
                liStockInwardChallanList.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/stock/addstocklist"))
              {
                liProcurement.Visible = true;
                liStockAddedList.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/stock/usestocklist"))
              {
                liProcurement.Visible = true;
                liStockUsageList.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/stock/productserialreport"))
              {
                liProcurement.Visible = true;
                liProductSerialNoList.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/stock/importpanelserialno"))
              {
                liProcurement.Visible = true;
                liImportPanelSerialNo.Visible = true;
              }

              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/settings/companyprofile"))
              {
                liSettings.Visible = true;
                licompanyProfile.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/settings/contactlist"))
              {
                liSettings.Visible = true;
                usermgmt.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/settings/scheme"))
              {
                liSettings.Visible = true;
                liSchema.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/settings/state"))
              {
                liSettings.Visible = true;
                liState.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/customerquotation/projectschemasubsidylist"))
              {
                liSettings.Visible = true;
                liSubsidyList.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/settings/supplierlist"))
              {
                liSettings.Visible = true;
                liSupplierList.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/settings/divisionmaster"))
              {
                liSettings.Visible = true;
                liDivisionMaster.Visible = true;
              }
              if (dtpages.Rows[i]["pageurl"].ToString().ToLower().Contains("/settings/subdivisionmaster"))
              {
                liSettings.Visible = true;
                liSubDivisionMaster.Visible = true;
              }
            }
          }

          //Temp Hide
          //liQuickLead.Visible = false;
        }
      }
      catch (Exception ex)
      {

        throw;
      }
    }

    private bool isPageAccessible(int userId, string url)
    {
      if (url.ToLower().Contains("noaccess") || url.ToLower().Contains("plannercalendar") || url.ToLower().Contains("contactus") || url.ToLower().Contains("dashboard/accessdashboard") || url.ToLower().Contains("/settings/userprofile"))
      {
        return true;
      }
      else
      {
        int RoleId = 0;
        int.TryParse(clsGlobal.GetCookiesData("RoleId"), out RoleId);
        clsdash.UserId = RoleId;
        clsdash.PageUrl = url;
        DataTable dtpages = clsdash.DataPagesByRoleId_URL();
        if (dtpages.Rows.Count > 0)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    public void GetPlannerData()
    {
      try
      {
        ClsPlanner cls = new ClsPlanner();
        DateTime FDate = dbCon.ConvertStringToDateTime(DateTime.Now.ToString("dd-MM-yyyy"));
        DateTime TDate = dbCon.ConvertStringToDateTime(DateTime.Now.ToString("dd-MM-yyyy"));

        cls.FromDate = FDate.Ticks;
        cls.ToDate = TDate.Ticks;

        int userId = 0;
        int.TryParse(clsGlobal.GetCookiesData("UserId"), out userId);
        cls.EmpBy = userId;

        int CompanyId = 0;
        int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);
        cls.CompanyId = CompanyId;

        DataTable dt = cls.GetPlanner();

        if (dt != null && dt.Rows.Count > 0)
        {

          ltrplanercount.Text = "<span class='badge badge-info right'>" + dt.Rows.Count + "</span>";
        }
        else
        {
          ltrplanercount.Text = "";
        }
      }
      catch (Exception ex)
      {

      }
    }

    private string getCurrentPageName()
    {
      string url = HttpContext.Current.Request.Url.AbsoluteUri;
      // http://localhost:1302/TESTERS/Default6.aspx

      string path = HttpContext.Current.Request.Url.AbsolutePath;
      // /TESTERS/Default6.aspx

      string host = HttpContext.Current.Request.Url.Host;
      // localhost

      return path;
    }

    public void CheckSetupProcess()
    {
      try
      {
        int CompanyId = 0;
        int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);

        clsCompany company = new clsCompany();
        Tuple<int, int,int> rest = company.CheckSetupProcess(CompanyId.ToString());
        if (rest.Item1 == 0 || rest.Item2 == 0 || rest.Item3 == 0)
        {
          //Setup Pending

          if (!getCurrentPageName().ToLower().Equals("/settings/addcompanydetails") && !getCurrentPageName().ToLower().Equals("/settings/users") && !getCurrentPageName().ToLower().Equals("/settings/scheme") && !getCurrentPageName().ToLower().Equals("/setup") && !getCurrentPageName().ToLower().Equals("/planpayment"))
          {
             Response.Redirect("~/setup");
          }
        }
        else
        {
          //Setup Done
        }
      }
      catch (Exception ex)
      {

      }
    }

    public void CheckPlanDetails()
    {
      try
      {
        int CompanyId = 0;
        int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);

        clsCompany company = new clsCompany();

        if (company.CheckComapnyPlanDetails(CompanyId))
        {
          //Plan isActive
        }
        else
        {
          if (!getCurrentPageName().ToLower().Equals("/plan") && !getCurrentPageName().ToLower().Equals("/planpayment") && !getCurrentPageName().ToLower().Equals("/planexpried"))
          {
            Response.Redirect("~/PlanExpried");
          }
        }
      }
      catch (Exception ex)
      {

      }
    }


  }
}
