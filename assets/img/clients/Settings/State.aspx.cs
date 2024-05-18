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
  public partial class State : System.Web.UI.Page
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
            chkdefault.Enabled = true;
            btnadd.Text = "Update State";
            GetDataById();
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
        dt = cls.GetState();
        if (dt.Rows.Count > 0)
        {
          string allRow = "";
          for (int i = 0; i < dt.Rows.Count; i++)
          {
            allRow += "<tr><td>" + dt.Rows[i]["Id"].ToString() + "</td><td>" + dt.Rows[i]["StateName"].ToString() + "</td><td>" + dt.Rows[i]["IsActiveName"].ToString() + "</td><td><a href='/Settings/State?Eid=" + dt.Rows[i]["Id"].ToString() + "'><i class='fas fa-edit' style=margine-right:8px;'></i></a></td></tr>";
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
        cls.Id = Convert.ToInt32(Request.QueryString["Eid"].ToString());
        dt = cls.GetStateById();
        if (dt.Rows.Count > 0)
        {
          txtname.Text = dt.Rows[0]["StateName"].ToString();
          if (dt.Rows[0]["IsActive"].ToString().ToLower() == "1")
          {
            chkdefault.Checked = true;
          }
          else
          {
            chkdefault.Checked = false;
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
        ltrerr.Text = "";
        if (txtname.Text.Trim() != "")
        {
          cls.Name = txtname.Text.Trim();
          if (chkdefault.Checked)
          {
            cls.IsActive = 1;
          }
          else
          {
            cls.IsActive = 0;
          }
          
          cls.Dom = dbc.getindiantime();

          if (Request.QueryString.AllKeys.Contains("Eid") && Request.QueryString["Eid"].ToString() != null)
          {
            cls.Id = Convert.ToInt32(Request.QueryString["Eid"].ToString());
            if (cls.UpdateState())
            {
              Clear();
              GetData();
              clsGlobal.DisplayToast(this, "Updated!", "State updated successfully.", "success", "/Settings/State");
            }
            else
            {
              clsGlobal.DisplayToast(this, "Alert!", "Something went wrong.", "error");
            }
          }
          else
          {
            cls.Doc = dbc.getindiantime();
            int rest = cls.AddState();
            if (rest > 0)
            {
              GetData();
              Clear();
              clsGlobal.DisplayToast(this, "Added!", "State added successfully.", "success", "/Settings/State");

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
    
    public void Clear()
    {
      try
      {
        txtname.Text = "";
        chkdefault.Checked = false;
      }
      catch (Exception ee)
      {
      }
    }
  }
}
