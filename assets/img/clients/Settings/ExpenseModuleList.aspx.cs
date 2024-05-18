using Portal.SolarSmart.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal.SolarSmart.Settings
{
  public partial class ExpenseModuleList : System.Web.UI.Page
  {
    MySQLDB dbCon = new MySQLDB();
    ClsExpenseModule cls = new ClsExpenseModule();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        if (!IsPostBack)
        {

          ddlExpenseCategory = dbCon.FillCombo(ddlExpenseCategory, "select Id, CategoryName from expense_category_master where IsActive=1 order by Id asc", "CategoryName", "Id");

          ddlExpenseCategory.SelectedIndex = 0; 
          string fromdate = dbCon.getDOCMtime();
          string todate = dbCon.getDOCMtime();
          int CompanyId = 0;
          int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);

          if (Request.QueryString.AllKeys.Contains("Did") && Request.QueryString["Did"].ToString() != null)
          {
            string Flag = "";
            cls.CompanyId = CompanyId;
            cls.Id = Convert.ToInt32(Request.QueryString["Did"].ToString());
            Flag = cls.DeleteExpenseModule();
            if (Flag == "-1")
            {
              clsGlobal.DisplayToast(this, "Alert!", "Already exsist.", "error");
            }
            else if (Flag == "1")
            {
              clsGlobal.DisplayToast(this, "Updated!", "ExpenseModule updated successfully .", "success", "/Settings/ExpenseModuleList");
            }
            else
            {
              clsGlobal.DisplayToast(this, "Alert!", "Something went wrong.", "error");
            }
          }
            if (Request.QueryString.AllKeys.Contains("fd") && Request.QueryString["fd"] != null && Request.QueryString.AllKeys.Contains("td") && Request.QueryString["td"] != null)
          {
            txtDate.Text = (DateTime.Parse(Request.QueryString["fd"].ToString())).ToString("dd-MM-yyyy");
            txtDate1.Text = (DateTime.Parse(Request.QueryString["td"].ToString())).ToString("dd-MM-yyyy");
          }
          else
          {
            txtDate.Text = (DateTime.Parse(fromdate.ToString())).ToString("dd-MM-yyyy");
            txtDate1.Text = (DateTime.Parse(todate.ToString())).ToString("dd-MM-yyyy");
          }
          //ddlInqFor = dbCon.FillCombo(ddlInqFor, "select Id, Name from InquiryForMaster where IsActive=1 order by Id asc", "Name", "Id");

          //ddlInqFor.SelectedIndex = 0;

          DataTable dtScheme = dbCon.GetData("select SchemeId, SchemeName from schememaster where IsDelete=0 AND IsDefault = 1 AND CompanyId = " + CompanyId + " order by IsDefault desc,SchemeId desc");

          ddlAddedBy = dbCon.FillCombo(ddlAddedBy, "select distinct user.Name,user.id from expense_module INNER join user on user.id=expense_module.AddedBy;", "Name", "Id");
          ddlAddedBy.SelectedIndex = 0;

         
          GetData();
        }
      }
      catch (Exception E)
      {
        ltrerr.Text = E.Message;
      }
    }
    public DataTable GetData()
    {
      try
      {
        int CompanyId = 0;
        int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);

        string Where = "";

        //if (clsGlobal.GetCookiesData("RoleId").ToString().Equals("23"))
        //{
        //  Where += " AND inquirydetails.ChannelPartnerId = " + clsGlobal.GetCookiesData("UserId").ToString();
        //}

        if (ddlAddedBy.SelectedIndex>0)
        {
          Where += " AND user.name='"+ ddlAddedBy.SelectedItem+"'";
        }
        if (ddlExpenseCategory.SelectedIndex>0)
        {
          Where += " AND expense_module.ExpenseCategory='" + ddlExpenseCategory.SelectedItem + "'";

        }
        string FromDate = dbCon.ConvertStringToDateTime(txtDate.Text.ToString().Trim()).ToString("yyyy-MM-dd") + " 00:00:00";
        string ToDate = dbCon.ConvertStringToDateTime(txtDate1.Text.ToString().Trim()).ToString("yyyy-MM-dd") + " 23:59:59";
        //inquirydetails.StatusId = 2 AND
        string select = "sELECT expense_module.*,(SELECT CategoryName FROM expense_category_master WHERE ID=expense_module.ExpenseCategory) as ExpenseCategoryname,user.name as AddedByName, DATE_FORMAT(ExpenseDate, '%d-%m-%Y') as AddedDateDis, DATE_FORMAT(ChequeDate, '%d-%m-%Y') as ChequeDateDis, case when PaymentMode=1 then 'Cash' when PaymentMode=2 then 'Cheque' when PaymentMode=3 then 'NEFT' else 'Cash' end as ModeText FROM expense_module join user on expense_module.AddedBy = user.Id where  ExpenseDate >= '" + FromDate + "' AND ExpenseDate <= '" + ToDate + "'AND expense_module.IsDelete = 0 " + Where + " Order by expense_module.id desc;";

        dt = dbCon.GetData(select);

        if (dt != null && dt.Rows.Count > 0)
        {
          string allRow = "";

          for (int i = 0; i < dt.Rows.Count; i++)
          {
            string Image = "";
            string innerTD = "";
            if (!String.IsNullOrEmpty(dt.Rows[i]["UploadReceipt"].ToString()))
            {
              Image = clsGlobal.CompanyPaymentImagePathWeb + dt.Rows[i]["UploadReceipt"].ToString();
              innerTD = "<a href='" + Image + "' target=\"_blank\"><i class=\"fas fa-eye\"></i></a>";
            }

            string Image2 = "";
            string innerTD2 = "";
            
            allRow += "<tr><td><a href='/MarketingLead/ViewOrderDetails?ID=" + dt.Rows[i]["Id"].ToString() + "&Flag=0'>" + dt.Rows[i]["Id"].ToString() + "</a></td><td>" + dt.Rows[i]["Name"].ToString() + "</td><td>" + dt.Rows[i]["Details"].ToString() + "</td><td>" + dt.Rows[i]["ExpenseCategoryname"].ToString() + "</td><td>" + dt.Rows[i]["AddedDateDis"].ToString() + "</td><td>" + dt.Rows[i]["Amount"].ToString() + "</td><td>" + dt.Rows[i]["ModeText"].ToString() + "</td><td>" + dt.Rows[i]["ChequeDateDis"].ToString() + "</td><td>" + dt.Rows[i]["ChequeNo"].ToString() + "</td><td>" + dt.Rows[i]["BankName"].ToString() + "</td><td>" + dt.Rows[i]["AddedByName"].ToString() + "</td><td class=\"py-0 align-middle\">" + innerTD + "</td><td><a href='/Settings/AddExpenseModule?Eid=" + dt.Rows[i]["Id"].ToString() + "'><i class='fas fa-edit' style=margine-right:8px;'></i></a></td><td><a href='/Settings/ExpenseModuleList?Did=" + dt.Rows[i]["Id"].ToString() + "'><i class='far fa-trash-alt' style=margine-right:8px;'></i></a></td></tr>";
          }
          rowData.Text = allRow;

        }
        else
        {
          rowData.Text = "";
        }
      }
      catch (Exception E)
      {
        ltrerr.Text = E.Message;
      }
      finally
      {
        dt.Dispose();
      }
      return dt;
    }
    protected void btngo_Click(object sender, EventArgs e)
    {
      GetData();
    }

  }
}
