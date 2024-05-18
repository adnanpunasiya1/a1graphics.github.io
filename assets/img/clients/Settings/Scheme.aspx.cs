using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal.SolarSmart.Settings
{
  public partial class Scheme : System.Web.UI.Page
  {
    MySQLDB dbc = new MySQLDB();
    ClsRole cls = new ClsRole();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        if (!IsPostBack)
        {
          int CompanyId = 0;
          int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);

          if (Request.QueryString.AllKeys.Contains("Eid") && Request.QueryString["Eid"].ToString() != null)
          {
            chkalloworder.Enabled = true;
            chkallowinquiry.Enabled = true;
            chkdefault.Enabled = true;
            btnadd.Text = "Update Scheme";
            GetDataById();
          }
          else if (Request.QueryString.AllKeys.Contains("Did") && Request.QueryString["Did"].ToString() != null)
          {
            string Flag = "";
            cls.CompanyId = CompanyId;
            cls.Id = Convert.ToInt32(Request.QueryString["Did"].ToString());
            Flag = cls.DeleteScheme();
            if (Flag == "-1")
            {
              clsGlobal.DisplayToast(this, "Alert!", "Already exsist.", "error");
            }
            else if (Flag == "1")
            {
              clsGlobal.DisplayToast(this, "Updated!", "Scheme updated successfully .", "success", "/Settings/Scheme");
            }
            else
            {
              clsGlobal.DisplayToast(this, "Alert!", "Something went wrong.", "error");
            }


          }
          GetData();
        }
      }
      catch (Exception E)
      {
        ltrerr.Text = E.Message;
      }
    }
    public void GetData()
    {
      try
      {
        int CompanyId = 0;
        int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);
        cls.CompanyId = CompanyId;
        dt = cls.GetSchemeType();
        if (dt.Rows.Count > 0)
        {
          string allRow = "";
          for (int i = 0; i < dt.Rows.Count; i++)
          {
            allRow += "<tr><td>" + dt.Rows[i]["SchemeName"].ToString() + "</td><td>" + dt.Rows[i]["IsDefault"].ToString() + "</td><td>" + dt.Rows[i]["IsAllowInquiry"].ToString() + "</td><td>" + dt.Rows[i]["IsAllowOrder"].ToString() + "</td><td><a href='/Settings/Scheme?Eid=" + dt.Rows[i]["SchemeId"].ToString() + "'><i class='fas fa-edit' style=margine-right:8px;'></i></a></td><td><a href='/Settings/Scheme?Did=" + dt.Rows[i]["SchemeId"].ToString() + "'><i class='far fa-trash-alt' style=margine-right:8px;'></i></a></td></tr>";
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
    public void GetDataById()
    {
      try
      {
        int CompanyId = 0;
        int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);
        cls.CompanyId = CompanyId;
        cls.Id = Convert.ToInt32(Request.QueryString["Eid"].ToString());
        dt = cls.GetSchemeById();
        if (dt.Rows.Count > 0)
        {
          txtname.Text = dt.Rows[0]["SchemeName"].ToString();
          if (dt.Rows[0]["IsDefault"].ToString().ToLower() == "1")
          {
            chkdefault.Checked = true;
          }
          else
          {
            chkdefault.Checked = false;
          }
          if (dt.Rows[0]["IsAllowInquiry"].ToString().ToLower() == "1")
          {
            chkallowinquiry.Checked = true;
          }
          else
          {
            chkallowinquiry.Checked = false;
          }
          if (dt.Rows[0]["IsAllowOrder"].ToString().ToLower() == "1")
          {
            chkalloworder.Checked = true;
          }
          else
          {
            chkalloworder.Checked = false;
          }
        }
        else
        {
          txtname.Text = "";
          chkdefault.Checked = false;
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
        cls.CompanyId = CompanyId;

        //cls.Request = Request;
        ltrerr.Text = "";
        if (txtname.Text.Trim() != "")
        {
          cls.Name = txtname.Text.Trim();
          if (chkdefault.Checked)
          {
            cls.IsDefault = 1;
          }
          else
          {
            cls.IsDefault = 0;
          }
          if (chkallowinquiry.Checked)
          {
            cls.IsAllowInquiry = 1;
          }
          else
          {
            cls.IsAllowInquiry = 0;
          }
          if (chkalloworder.Checked)
          {
            cls.IsAllowOrder = 1;
          }
          else
          {
            cls.IsAllowOrder = 0;
          }
          cls.Dom = dbc.getindiantime();

          if (Request.QueryString.AllKeys.Contains("Eid") && Request.QueryString["Eid"].ToString() != null)
          {
            cls.Id = Convert.ToInt32(Request.QueryString["Eid"].ToString());
            if (cls.UpdateScheme())
            {
              Clear();
              GetData();
              clsGlobal.DisplayToast(this, "Updated!", "Scheme updated successfully.", "success", "/Settings/Scheme");
            }
            else
            {
              clsGlobal.DisplayToast(this, "Alert!", "Something went wrong.", "error");
            }
          }
          else
          {
            cls.Doc = dbc.getindiantime();
            int rest = cls.AddScheme();
            if (rest > 0)
            {
              GetData();
              Clear();
              clsGlobal.DisplayToast(this, "Added!", "Scheme added successfully.", "success", "/Settings/Scheme");

            }
            else
            {
              clsGlobal.DisplayToast(this, "Alert!", "Something went wrong.", "error");
            }

          }
        }
        else
        {
          ltrerr.Text = "Enter name of Scheme.";
        }
      }
      catch (Exception ex)
      {
        ltrerr.Text = ex.Message;
      }
    }
    [WebMethod]
    public static string CheckSchemeName(string SchemeName)
    {
      string flag = "0";
      MySQLDB dbc = new MySQLDB();
      ClsRole cls = new ClsRole();
      try
      {
        int CompanyId = 0;
        int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);
        cls.CompanyId = CompanyId;
        cls.Name = SchemeName;
        flag = cls.CheckSchemeExsist();
        if (flag == "1")
        {
          flag = "1";
        }
        else
        {
          flag = "-1";
        }
      }
      catch (Exception ee)
      {
      }
      return flag;
    }
    public void Clear()
    {
      try
      {
        txtname.Text = "";
        chkallowinquiry.Checked = false;
        chkalloworder.Checked = false;
        chkdefault.Checked = false;
      }
      catch (Exception ee)
      {
      }
    }
  }
}
