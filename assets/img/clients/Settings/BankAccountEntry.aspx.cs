using Org.BouncyCastle.Utilities.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
  public partial class BankAccountEntry : System.Web.UI.Page
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
          if (Request.QueryString.AllKeys.Contains("Eid") && Request.QueryString["Eid"].ToString() != null)
          {
            btnadd.Text = "Update BankAccountEntry";
            GetDataById();
          }
          if (Request.QueryString.AllKeys.Contains("Did") && Request.QueryString["Did"].ToString() != null)
          {
            RemoveData();
          }
            txtPaydate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtDate1.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtCallBy.Text = clsGlobal.GetCookiesData("Username").ToString();
          GetData();
        }
      }
      catch (Exception E)
      {
        ltrerr.Text = E.Message;
      }
    }
    public void RemoveData()
    {
      try
      {
        string Flag = "";
        cls.Id = Convert.ToInt32(Request.QueryString["Did"].ToString());
        Flag = cls.DeleteBankAccountEntry();
        if (Flag == "-1")
        {
          clsGlobal.DisplayToast(this, "Alert!", "Already exsist.", "error");
        }
        else if (Flag == "1")
        {
          clsGlobal.DisplayToast(this, "Updated!", "BankAccountEntry Deleted successfully .", "success", "/Settings/BankAccountEntry");
        }
        else
        {
          clsGlobal.DisplayToast(this, "Alert!", "Something went wrong.", "error");
        }
      }
      catch (Exception ex)
      {
        throw;
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
        dt = cls.GetBankAccountEntryById();
        if (dt.Rows.Count > 0)
        {
          txtPaydate.Text = DateTime.Parse(dt.Rows[0]["PaymentDate"].ToString()).ToString("dd-MM-yyyy");
          txtPayAmt.Text = dt.Rows[0]["Amount"].ToString();
          txtDate1.Text = DateTime.Parse(dt.Rows[0]["ChequeDate"].ToString()).ToString("dd-MM-yyyy");
          txtBankName.Text = dt.Rows[0]["BankName"].ToString();
          txtChqueNo.Text = dt.Rows[0]["ChequeNo"].ToString();
          txtbranchname.Text= dt.Rows[0]["BranchName"].ToString();
          txtifsccode.Text= dt.Rows[0]["IFSCcode"].ToString();
          txtnote.Text = dt.Rows[0]["Notes"].ToString();
          txtremark.Text= dt.Rows[0]["ReMarks"].ToString();
          txtCallBy.Text = dt.Rows[0]["ReceivedBy"].ToString();
          imgdetails.Visible = true;
          srcltrerr.Text = dt.Rows[0]["ChequePhoto"].ToString(); ;
          imgdetails.Src = "/Data/PaymentReceipt/" + dt.Rows[0]["ChequePhoto"].ToString();
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
    
    protected void btnadd_Click(object sender, EventArgs e)
    {
      try
      {
        int CompanyId = 0;
        int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);

        string ids = "";
        string chequeDate = "";
        string chequeNo = "";
        int cheqNo = 0;

        string PaymentProof = "";
        bool isValidFile;
        if (txtPayAmt.Text.Trim() == null || txtPayAmt.Text.Trim() == "")
        {
          clsGlobal.DisplayToast(this, "Alert!", "Please Enter Payment Ammount.", "error");
          return;
        }
        if (String.IsNullOrEmpty(txtCallBy.Text))
        {
          clsGlobal.DisplayToast(this, "Alert!", "Please Enter Recieved By.", "error");
          return;
        }
        if (String.IsNullOrEmpty(txtnote.Text))
        {
          clsGlobal.DisplayToast(this, "Alert!", "Please Enter Note.", "error");
          return;
        }
        if (String.IsNullOrEmpty(txtremark.Text))
        {
          clsGlobal.DisplayToast(this, "Alert!", "Please Enter ReMarks.", "error");
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

          PaymentProof =  DateTime.Now.Ticks + exten;

          string path = clsGlobal.CompanyPaymentImageLocal + PaymentProof;
          FileUploadPayment.SaveAs(path);
        }
        else
        {
          PaymentProof = srcltrerr.Text;
        }
        chequeDate = txtDate1.Text.ToString().Trim();
        chequeNo = txtChqueNo.Text.ToString().Trim();
        int.TryParse(chequeNo, out cheqNo);

        if (String.IsNullOrEmpty(chequeDate) || String.IsNullOrEmpty(chequeNo) || String.IsNullOrEmpty(txtBankName.Text.ToString().Trim()) || chequeDate.Equals("01-01-0001")|| String.IsNullOrEmpty(txtbranchname.Text.ToString().Trim()) || String.IsNullOrEmpty(txtifsccode.Text.ToString().Trim()))
        {
          clsGlobal.DisplayToast(this, "Alert!", "Please Enter Cheque Details.", "error");
          return;
        }
        if (Request.QueryString.AllKeys.Contains("Eid") && Request.QueryString["Eid"].ToString() != null)
        {
          ids = " and id<>" + Request.QueryString["Eid"].ToString() + "";
        }
        DataTable dtCheckNo = dbCon.GetData("select * from expense_module where  ChequeNo = " + chequeNo + " "+ ids + " ;");
        if (dtCheckNo != null && dtCheckNo.Rows.Count > 0)
        {
          clsGlobal.DisplayToast(this, "Alert!", "Same Cheque Details Already Added. Please Check Your expense Details.", "error");
          return;
        }

        cls.InquiryDate = txtPaydate.Text.ToString().Trim();
        cls.EstimatedCost = txtPayAmt.Text.ToString().Trim();
        cls.CallBy = txtCallBy.Text;
        cls.Details = txtnote.Text;
        cls.Remarks = txtremark.Text;
        cls.ReminderDate = chequeDate;
        cls.StatusId = cheqNo;
        cls.BankName = txtBankName.Text.ToString().Trim();
        cls.BranchName = txtbranchname.Text.ToString().Trim();
        cls.IFSCCode=double.Parse( txtifsccode.Text);
        cls.CompanyId = CompanyId;
        cls.Receipt = PaymentProof; 
        
          if (Request.QueryString.AllKeys.Contains("Eid") && Request.QueryString["Eid"].ToString() != null)
          {
            cls.Id = Convert.ToInt32(Request.QueryString["Eid"].ToString());
            if (cls.UpdateBankAccountEntry())
            {
              clsGlobal.DisplayToast(this, "Updated!", "BankAccountEntry updated successfully.", "success", "/Settings/BankAccountEntry");
            }
            else
            {
              clsGlobal.DisplayToast(this, "Alert!", "Something went wrong.", "error");
            }
          }
          else
          {
            int rest = cls.AddBankAccountEntry();
            if (rest == 0)
            {
              clsGlobal.DisplayToast(this, "Alert!", "Something Went Wrong !!", "error");
            }
            else
            {
              clsGlobal.DisplayToast(this, "Alert!", "BankAccountEntry Added Successfully.", "   ", "/Settings/BankAccountEntry");
            }
          }

      }
      catch (Exception ex)
      {
        clsGlobal.DisplayToast(this, "Alert!", ex.Message, "error");
      }
    }
    public void GetData()
    {
        DataTable dt = new DataTable();
      try
      {
        int CompanyId = 0;
        int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);
        cls.CompanyId = CompanyId;
        dt = cls.GetBankAccountEntryType();
        if (dt.Rows.Count > 0)
        {
          string allRow = "";
          for (int i = 0; i < dt.Rows.Count; i++)
          {
            allRow += "<tr><td>" + dt.Rows[i]["Id"].ToString() + "</td><td>" + dt.Rows[i]["ReceivedDate"].ToString() + "</td><td>" + dt.Rows[i]["ReceivedBy"].ToString() + "</td><td>" + dt.Rows[i]["Amount"].ToString() + "</td><td>" + dt.Rows[i]["BankName"].ToString() + "</td><td>" + dt.Rows[i]["BranchName"].ToString() + "</td><td>" + dt.Rows[i]["ChequeDate"].ToString() + "</td><td>" + dt.Rows[i]["ChequeNo"].ToString() + "</td><td>" + dt.Rows[i]["Notes"].ToString() + "</td><td>" + dt.Rows[i]["ReMarks"].ToString() + "</td><td><a href='/Settings/BankAccountEntry?Eid=" + dt.Rows[i]["Id"].ToString() + "'><i class='fas fa-edit' style=margine-right:8px;'></i></a></td><td><a href='/Settings/BankAccountEntry?Did=" + dt.Rows[i]["Id"].ToString() + "'><i class='far fa-trash-alt' style=margine-right:8px;'></i></a></td></tr>";
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
    }
  }
}
