using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal.SolarSmart.Settings
{
  public partial class CompanyProfile : System.Web.UI.Page
  {
    MySQLDB dbCon = new MySQLDB();
    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        if (!IsPostBack)
        {

          GetData();

        }
      }
      catch (Exception)
      {

      }
    }

    public void GetData()
    {
      try
      {
        int CompanyId = 0;
        int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);

        clsCompany cls = new clsCompany();
        DataTable dt = cls.GetComapnyDetails(CompanyId.ToString());

        if (dt.Rows.Count > 0)
        {
          string profilePic = "";
          if (!string.IsNullOrEmpty(dt.Rows[0]["CompanyLogo"].ToString()))
          {
            profilePic = clsGlobal.WorkLogoPathWeb + dt.Rows[0]["CompanyLogo"].ToString();
          }
          else
          {
            profilePic = clsGlobal.UserImagePathWeb + clsGlobal.defaultUserImage;
          }
          ltrProfilePic.Text = "<img class='profile-user-img img-fluid' src='" + profilePic + "' alt='User profile picture'>";

          ltrComapnyName.Text = "<h3 class='profile-username text-center'>" + dt.Rows[0]["CompanyName"].ToString() + "</h3>";
          ltrCustomerCode.Text = "<p class='text-muted text-center'>" + dt.Rows[0]["CustomerCode"].ToString() + "</p>";

          ltrUsername.Text = "<a class='float-right'>" + dt.Rows[0]["OwnerName"].ToString() + "</a>";
          ltrMobile.Text = "<a class='float-right'>" + dt.Rows[0]["OwnerMobileNumber"].ToString() + "</a>";
          ltrEmail.Text = "<a class='float-right'>" + dt.Rows[0]["EmailId"].ToString() + "</a>";

          ltrAddress.Text = "<p class='text-muted'>"+dt.Rows[0]["CompanyAddress"].ToString() + ", " + dt.Rows[0]["CompanyCity"].ToString() + ", " + dt.Rows[0]["CompanyState"].ToString() + "</p>";

          ltrComapnyContactNo.Text = "<p class='text-muted'>"+dt.Rows[0]["CompanyContactNumber"].ToString() + "</p>";
          ltrComapnyEmailId.Text = "<p class='text-muted'>"+dt.Rows[0]["CompanyEmailId"].ToString() + "</p>";
          ltrWebsite.Text = "<p class='text-muted'>"+dt.Rows[0]["Website"].ToString() + "</p>";

          ltrGSTNo.Text = dt.Rows[0]["GSTNo"].ToString();
          ltrCompanyBankName.Text = dt.Rows[0]["CompanyBankName"].ToString();
          ltrCompanyBankAccountName.Text = dt.Rows[0]["CompanyBankAccountName"].ToString();
          ltrCompanyBankAccountNo.Text = dt.Rows[0]["CompanyBankAccountNo"].ToString();
          ltrCompanyBankIFSCCode.Text = dt.Rows[0]["CompanyBankIFSCCode"].ToString();
          ltrCompanyBankBranch.Text = dt.Rows[0]["CompanyBankBranch"].ToString();

          string allRow = "";

          if (!String.IsNullOrEmpty(dt.Rows[0]["Letterhead_Header"].ToString()))
          {
            allRow += "<tr><td>Letterhead Header</td><td class=\"text-right py-0 align-middle\"><div class=\"btn-group btn-group-sm\"><a href=\"" + clsGlobal.WorkLogoPathWeb + dt.Rows[0]["Letterhead_Header"].ToString() + "\" target=\"_blank\" class=\"btn btn-info\"><i class=\"fas fa-eye\"></i></a></div></td><td><a onclick=\"RemoveEntry('1')\" class=\"btn btn-sm btn-danger\" ><i class=\"fas fa-trash\" style='color: white;'></i></a></td></tr>";
          }

          if (!String.IsNullOrEmpty(dt.Rows[0]["Letterhead_Footer"].ToString()))
          {
            allRow += "<tr><td>Letterhead Footer</td><td class=\"text-right py-0 align-middle\"><div class=\"btn-group btn-group-sm\"><a href=\"" + clsGlobal.WorkLogoPathWeb + dt.Rows[0]["Letterhead_Footer"].ToString() + "\" target=\"_blank\" class=\"btn btn-info\"><i class=\"fas fa-eye\"></i></a></div></td><td><a onclick=\"RemoveEntry('2')\" class=\"btn btn-sm btn-danger\" ><i class=\"fas fa-trash\" style='color: white;'></i></a></td></tr>";
          }
          if (!String.IsNullOrEmpty(dt.Rows[0]["Letterhead_Watermark"].ToString()))
          {
            allRow += "<tr><td>Letterhead Watermark</td><td class=\"text-right py-0 align-middle\"><div class=\"btn-group btn-group-sm\"><a href=\"" + clsGlobal.WorkLogoPathWeb + dt.Rows[0]["Letterhead_Watermark"].ToString() + "\" target=\"_blank\" class=\"btn btn-info\"><i class=\"fas fa-eye\"></i></a></div></td><td><a onclick=\"RemoveEntry('3')\" class=\"btn btn-sm btn-danger\" ><i class=\"fas fa-trash\" style='color: white;'></i></a></td></tr>";
          }
          rowWork.Text = allRow;

        }
      }
      catch (Exception ex)
      {
        clsGlobal.DisplayToast(this, "Alert!", "Error:" + ex.Message.ToString(), "error");
      }
    }
    
    [WebMethod]
    public static string RemoveEntry(string Id)
    {
      string ret = "0";
      MySQLDB dbCon = new MySQLDB();
      try
      {
        #region RemoveStockEntry
        if (Id != null && Id != "")
        {
          int CompanyId = 0;
          int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);

          clsCompany clsS = new clsCompany();

          ret = clsS.RemoveComapnyDcoument(Id, CompanyId.ToString()).ToString();
        }
        #endregion

      }
      catch (Exception ex)
      {
        ret = "0";
      }
      finally
      {
      }
      return ret;
    }
  }
}
