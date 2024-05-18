using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Portal.SolarSmart.Settings
{
  public partial class AddExpenseModule : System.Web.UI.Page
  {
    MySQLDB dbCon = new MySQLDB();
    ClsExpenseModule cls = new ClsExpenseModule();
    string ImageUrl = "";
    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        if (!IsPostBack)
        {
          ddlcategory = dbCon.FillCombo(ddlcategory, "select Id,CategoryName from expense_category_master where IsActive=1 order by Id asc", "CategoryName", "Id");

          ddlcategory.SelectedIndex = 0;
          if (Request.QueryString.AllKeys.Contains("Eid") && Request.QueryString["Eid"].ToString() != null)
          {

            btnadd.Text = "Update ExpenseModule";
            GetDataById();
          }
          if (Request.QueryString.AllKeys.Contains("ID") && Request.QueryString["ID"] != null)
          {
            txtPaydate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtDate1.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtTrnDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtCallBy.Text = clsGlobal.GetCookiesData("Username").ToString();

          }
        }
      }
      catch (Exception E)
      {
        ltrerr.Text = E.Message;
      }
    }

    public void GetDataById()
    {
      DataTable dt = new DataTable();
      try
      {
        int CompanyId = 0;
        int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);
        cls.CompanyId = CompanyId;
        cls.Id = Convert.ToInt32(Request.QueryString["Eid"].ToString());
        dt = cls.GetExpenseModuleById();
        if (dt.Rows.Count > 0)
        {
          txtname.Text = dt.Rows[0]["Name"].ToString();
          txtdetails.Text = dt.Rows[0]["Details"].ToString();
          ddlcategory.SelectedValue = dt.Rows[0]["ExpenseCategory"].ToString();
          txtPaydate.Text = DateTime.Parse(dt.Rows[0]["ExpenseDate"].ToString()).ToString("dd-MM-yyyy");
          txtPayAmt.Text = dt.Rows[0]["Amount"].ToString();
          string formattedDate = DateTime.Parse(dt.Rows[0]["ChequeDate"].ToString()).ToString("dd-MM-yyyy");
          imgdetails.Visible = true;
          srcltrerr.Text= dt.Rows[0]["UploadReceipt"].ToString(); ;
          imgdetails.Src= "/Data/PaymentReceipt/" + dt.Rows[0]["UploadReceipt"].ToString();
          if (dt.Rows[0]["PaymentMode"].ToString().ToLower() == "1")
          {
            rbtCash.Checked = true;
          }
          else if (dt.Rows[0]["PaymentMode"].ToString().ToLower() == "2")
          {
            rbtCheque.Checked = true;
            txtDate1.Text = formattedDate;
            txtBankName.Text = dt.Rows[0]["BankName"].ToString();
            txtChqueNo.Text = dt.Rows[0]["ChequeNo"].ToString();

          }
          else
          {
            rbtNEFT.Checked = true;
            txtTrnDate.Text = formattedDate;
            txtTrnNo.Text = dt.Rows[0]["ChequeNo"].ToString();
            txtTrnBankName.Text = dt.Rows[0]["BankName"].ToString();

          }
        }
        else
        {

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
    }

    public void View()
    {

      //btnupdate.Visible = false;

      ltrerr.Text = "";
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
      try
      {
        string ids = "";
        int CompanyId = 0;
        int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);

        int StatusId = 1;

        int Assign = 0;

        int modeid = 1;

        string chequeDate = "";
        string chequeNo = "";
        int cheqNo = 0;

        int InquiryId = 0;
        //  int.TryParse(Request.QueryString["ID"].ToString(), out InquiryId);
        string PaymentProof = "";
        bool isValidFile;
        if (String.IsNullOrEmpty(txtname.Text))
        {
          clsGlobal.DisplayToast(this, "Alert!", "Please Enter Name.", "error");
          return;
        }
        if (String.IsNullOrEmpty(txtdetails.Text))
        {
          clsGlobal.DisplayToast(this, "Alert!", "Please Enter Details.", "error");
          return;
        }
        if (ddlcategory.SelectedIndex == 0)
        {
          clsGlobal.DisplayToast(this, "Alert!", "Please Select Category.", "error");
          return;
        }
        if (FileUploadPayment.HasFile)
        {
          string ext = System.IO.Path.GetExtension(FileUploadPayment.PostedFile.FileName);
          string[] validFileTypes = { "png", "jpg", "jpeg", "pdf" };
          isValidFile = false;
          for (int i = 0; i < validFileTypes.Length; i++)
          {
            if (ext == "." + validFileTypes[i])
            {
              isValidFile = true;
              break;
            }
          }

          Stream fs = FileUploadPayment.PostedFile.InputStream;
          BinaryReader br = new BinaryReader(fs);
          //Byte[] image = br.ReadBytes((Int32)fs.Length);
          Byte[] image = null;

          string exten = System.IO.Path.GetExtension(FileUploadPayment.FileName);
          string name = System.IO.Path.GetFileName(FileUploadPayment.FileName);

          string ext1 = System.IO.Path.GetExtension(FileUploadPayment.FileName);
          ext1 = ext1.Replace(".", "image/");

          PaymentProof = InquiryId + "_" + DateTime.Now.Ticks + exten;

          string path = clsGlobal.CompanyPaymentImageLocal + PaymentProof;
          FileUploadPayment.SaveAs(path);
        }
        else
        { 
          PaymentProof = srcltrerr.Text;
        }

        if (rbtCash.Checked)
        {
          modeid = 1;
        }
        else if (rbtCheque.Checked)
        {
          modeid = 2;
          chequeDate = txtDate1.Text.ToString().Trim();
          chequeNo = txtChqueNo.Text.ToString().Trim();
          int.TryParse(chequeNo, out cheqNo);

          if (String.IsNullOrEmpty(chequeDate) || String.IsNullOrEmpty(chequeNo) || String.IsNullOrEmpty(txtBankName.Text.ToString().Trim()) || chequeDate.Equals("01-01-0001"))
          {
            clsGlobal.DisplayToast(this, "Alert!", "Please Enter Cheque Details.", "error");
            return;
          }
          cls.Address = txtBankName.Text.ToString().Trim();
          if (Request.QueryString.AllKeys.Contains("Eid") && Request.QueryString["Eid"].ToString() != null)
          {
            ids = " and id<>" + Request.QueryString["Eid"].ToString() + "";
          }
          DataTable dtCheckNo = dbCon.GetData("select * from expense_module where  ChequeNo = " + chequeNo + " "+ ids + ";");
          if (dtCheckNo != null && dtCheckNo.Rows.Count > 0)
          {
            clsGlobal.DisplayToast(this, "Alert!", "Same Cheque Details Already Added. Please Check Your expense Details.", "error");
            return;
          }
        }
        else
        {
          modeid = 3;
          chequeDate = txtTrnDate.Text.ToString().Trim();
          chequeNo = txtTrnNo.Text.ToString().Trim();
          int.TryParse(chequeNo, out cheqNo);

          if (String.IsNullOrEmpty(chequeDate) || String.IsNullOrEmpty(chequeNo) || String.IsNullOrEmpty(txtTrnBankName.Text.ToString().Trim()) || chequeDate.Equals("01-01-0001"))
          {
            clsGlobal.DisplayToast(this, "Alert!", "Please Enter Transaction Details.", "error");
            return;
          }
          cls.Address = txtTrnBankName.Text.ToString().Trim();
         
          if (Request.QueryString.AllKeys.Contains("Eid") && Request.QueryString["Eid"].ToString() != null)
          {
            ids = " and id<>"+ Request.QueryString["Eid"].ToString() + "";
          }

          DataTable dtCheckNo = dbCon.GetData("select * from expense_module where  ChequeNo = " + chequeNo + " "+ ids + " ;");
          if (dtCheckNo != null && dtCheckNo.Rows.Count > 0)
          {         
              clsGlobal.DisplayToast(this, "Alert!", "Same Transaction Details Already Added. Please Check Your Expense Details.", "error");
              return;
          }
        }
        //DataTable dtAllPayment = dbCon.GetData("select sum(PaymentAmount) as TotalPaid from paymentdetails where InquiryId = " + InquiryId + " and IsDelete = 0;");
        //if (dtAllPayment != null && dtAllPayment.Rows.Count > 0)
        //{
        //  DataTable dtInquiry = dbCon.GetData("select * from inquirydetails where Id = " + InquiryId + " and StatusId = 2;");

        //  double tillPaid = 0;
        //  double.TryParse(dtAllPayment.Rows[0][0].ToString(), out tillPaid);

        //  double ProjectCost = 0;
        //  double.TryParse(dtInquiry.Rows[0]["ProjectCost"].ToString(), out ProjectCost);
        //  double Discount = 0;
        //  double.TryParse(dtInquiry.Rows[0]["Discount"].ToString(), out Discount);

        //  double CurrentAmt = 0;
        //  double.TryParse(txtPayAmt.Text.ToString().Trim(), out CurrentAmt);

        //  double TotalPaid = CurrentAmt + tillPaid;
        //  double FinalProjectAmt = ProjectCost - Discount;
          
        //  if (FinalProjectAmt == 0)
        //  {
        //    clsGlobal.DisplayToast(this, "Alert!", "Project Cost is 0. So, You can't add payment.", "error");
        //    return;
        //  }

        //  if (TotalPaid > FinalProjectAmt)
        //  {
        //    clsGlobal.DisplayToast(this, "Alert!", "Total Payment can't be more then Project Cost.", "error");
        //    return;
        //  }
        //}

        int TypeId = 0;

        cls.Name = txtname.Text;
        cls.Details = txtdetails.Text;
        cls.Category = ddlcategory.SelectedValue;
        cls.CompanyId = CompanyId;
        cls.Id = InquiryId;
        cls.StatusId = cheqNo;
        cls.InquiryType = modeid;
        cls.EstimatedCost = txtPayAmt.Text.ToString().Trim();
        cls.ReminderDate = chequeDate;
        cls.HandledBy = Convert.ToInt32(clsGlobal.GetCookiesData("UserId").ToString());
        cls.InquiryDate = txtPaydate.Text.ToString().Trim();
        cls.Receipt = PaymentProof;
        if (txtPayAmt.Text.Trim() == null || txtPayAmt.Text.Trim() == "")
        {
          clsGlobal.DisplayToast(this, "Alert!", "Please Fill PayAmmount.", "error");
          return;
        }
        else
        {
          if (Request.QueryString.AllKeys.Contains("Eid") && Request.QueryString["Eid"].ToString() != null)
          {
            cls.Id = Convert.ToInt32(Request.QueryString["Eid"].ToString());
            if (cls.UpdateExpenseModule())
            {
              clsGlobal.DisplayToast(this, "Updated!", "ExpenseModule updated successfully.", "success", "/Settings/ExpenseModulelist");
            }
            else
            {
              clsGlobal.DisplayToast(this, "Alert!", "Something went wrong.", "error");
            }
          }
          else
          {
            int rest = cls.AddExpenseModule();
            if (rest == 0)
            {
              clsGlobal.DisplayToast(this, "Alert!", "Something Went Wrong !!", "error");
            }
            else
            {
              clsGlobal.DisplayToast(this, "Alert!", "ExpenseModule Added Successfully.", "success", "/Settings/ExpenseModulelist");
                         }
          }
         

        }
      }
      catch (Exception ex)
      {
        clsGlobal.DisplayToast(this, "Alert!", ex.Message, "error");
      }
    }

    [WebMethod]
    public static string RemoveEntry(string Id)
    {
      string ret = "0";
      MySQLDB dbCon = new MySQLDB();
      try
      {
        #region RemovePaymentEntry
        if (Id != null && Id != "")
        {
          ClsMarketingLead clsS = new ClsMarketingLead();
          int CompanyId = 0;
          int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);
          clsS.CompanyId = CompanyId;
          ret = clsS.RemovePaymentEntry(Id).ToString();
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
