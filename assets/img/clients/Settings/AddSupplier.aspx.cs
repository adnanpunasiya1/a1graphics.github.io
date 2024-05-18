using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal.SolarSmart.Settings
{
  public partial class AddSupplier : System.Web.UI.Page
  {
    MySQLDB dbCon = new MySQLDB();
    ClsStock cls = new ClsStock();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        if (!IsPostBack)
        {
          if (Request.QueryString.AllKeys.Contains("ID") && Request.QueryString["ID"].ToString() != null)
          {
            btnadd.Text = "Update";
            GetDataById();
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
      try
      {
        string Agencyid = "";
        if (Request.QueryString.AllKeys.Contains("ID") && Request.QueryString["ID"].ToString() != null)
        {
          Agencyid = Request.QueryString["ID"].ToString();
        }
        else
        {
          clsGlobal.DisplayToast(this, "Error!", "Supplier Id Not Found, Please Try After Sometime.", "error");
          return;
        }


        dt = dbCon.GetData("Select * from suppliermaster where Id = " + Agencyid + "");
        if (dt.Rows.Count > 0)
        {
          txtname.Text = dt.Rows[0]["Name"].ToString();
          if (dt.Rows[0]["Isactive"].ToString().ToLower() == "1")
          {
            chkactive.Checked = true;
          }
          else
          {
            chkactive.Checked = false;
          }
          txtmobile.Text = dt.Rows[0]["Mobile"].ToString();
          txtadd.Text = dt.Rows[0]["Address"].ToString();
          txtPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();
          txtEmail.Text = dt.Rows[0]["EmailId"].ToString();
          txtGSTNo.Text = dt.Rows[0]["GSTNo"].ToString();
        }
        else
        {

          clsGlobal.DisplayToast(this, "Alert!", "Supplier data not found. Please try again.", "error");
        }
      }
      catch (Exception E)
      {
        ltrerr.Text = "<span style=\"margin-left:4%;margin-bottom:0%;margin-top:2%;color: red\"><i class=\"fa fa-exclamation\" style=\"margin-right:5px\"></i> Error: 95 : " + E.Message + "</span><br/>";
        clsGlobal.DisplayToast(this, "Alert!", E.Message, "error");
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

        if (btnadd.Text.Equals("Update"))
        {
          string userid = "";
          if (Request.QueryString.AllKeys.Contains("ID") && Request.QueryString["ID"].ToString() != null)
          {
            userid = Request.QueryString["ID"].ToString();
          }
          else
          {
            clsGlobal.DisplayToast(this, "Error!", "User Id Not Found, Please Try After Sometime.", "error");
            return;
          }
          if (txtname.Text.Trim() != "" && txtmobile.Text.Trim() != "" && txtadd.Text.Trim() != "")
          {
            cls.AgencyName = txtname.Text.Trim();

            if (chkactive.Checked)
            {
              cls.IsActive = 1;
            }
            else
            {
              cls.IsActive = 0;
            }
            cls.CompanyId = CompanyId;
            cls.AgencyId = int.Parse(userid);
            cls.AgencyMobile = txtmobile.Text.Trim();
            cls.AgencyPhone = txtPhoneNo.Text.Trim();
            cls.AgencyEmail = txtEmail.Text.Trim();
            cls.AgencyAddress = txtadd.Text.Trim();
            cls.AgencyGSTNo = txtGSTNo.Text.Trim();
            int rest = cls.UpdateSupplier();
            if (rest > 0)
            {
              clsGlobal.DisplayToast(this, "Added!", "Supplier Details Updated Successfully.", "success", "/Settings/SupplierList");
            }
            else
            {
              clsGlobal.DisplayToast(this, "Error!", "Supplier Details Not Updated., Please Try After Sometime.", "error");
            }
          }
          else
          {
            clsGlobal.DisplayToast(this, "Error!", "Please Fill All Details.", "error");
          }
        }
        else
        {
          if (txtname.Text.Trim() != "" && txtmobile.Text.Trim() != "" && txtadd.Text.Trim() != "" && txtGSTNo.Text.Trim() != "")
          {
            cls.AgencyName = txtname.Text.Trim();

            if (chkactive.Checked)
            {
              cls.IsActive = 1;
            }
            else
            {
              cls.IsActive = 0;
            }
            cls.CompanyId = CompanyId;
            cls.AgencyMobile = txtmobile.Text.Trim();
            cls.AgencyPhone = txtPhoneNo.Text.Trim();
            cls.AgencyEmail = txtEmail.Text.Trim();
            cls.AgencyAddress = txtadd.Text.Trim();
            cls.AgencyGSTNo = txtGSTNo.Text.Trim();
            int rest = cls.AddSupplier();
            if (rest > 0)
            {
              clsGlobal.DisplayToast(this, "Added!", "Supplier Details Added Successfully.", "success", "/Settings/SupplierList");
            }
            else
            {
              clsGlobal.DisplayToast(this, "Error!", "Supplier Details Not Added, Please Try After Sometime.", "error");
            }
          }
          else
          {
            clsGlobal.DisplayToast(this, "Error!", "Please Fill All Details.", "error");
          }
        }
      }
      catch (Exception ex)
      {
        ltrerr.Text = "<span style=\"margin-left:4%;margin-bottom:0%;margin-top:2%;color: red\"><i class=\"fa fa-exclamation\" style=\"margin-right:5px\"></i> Error: 158 : " + ex.Message + "</span><br/>";
      }
    }
  }
}
