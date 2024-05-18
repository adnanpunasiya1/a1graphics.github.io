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
  public partial class DivisionMaster : System.Web.UI.Page
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
          if (Request.QueryString.AllKeys.Contains("Eid") && Request.QueryString["Eid"].ToString() != null)
          {
            btnadd.Text = "Update";
            btnDelete.Visible = true;
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
        dt = cls.GetDivision();
        if (dt.Rows.Count > 0)
        {
          string allRow = "";
          for (int i = 0; i < dt.Rows.Count; i++)
          {
            allRow += "<tr><td>" + dt.Rows[i]["DivisionName"].ToString() + "</td><td><a href='/Settings/DivisionMaster?Eid=" + dt.Rows[i]["Id"].ToString() + "'><i class='fas fa-edit' style=margine-right:8px;'></i></a></td></tr>";

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
        dt = cls.GetDivisionById();
        if (dt.Rows.Count > 0)
        {
          txtname.Text = dt.Rows[0]["DivisionName"].ToString();
        }
        else
        {
          txtname.Text = "";
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
          cls.Dom = dbc.getindiantime();

          dt = cls.GetDivision();
          if (dt != null && dt.Rows.Count > 0)
          {
            DataRow[] drAvail = dt.Select("DivisionName = '"+ txtname.Text.Trim() + "' AND IsDelete = 0");
            if (drAvail != null && drAvail.Length > 0)
            {
              clsGlobal.DisplayToast(this, "Alert!", "Already Available "+ txtname.Text.Trim(), "error");
              return;
            }
          }

          if (Request.QueryString.AllKeys.Contains("Eid") && Request.QueryString["Eid"].ToString() != null)
          {
            cls.Id = Convert.ToInt32(Request.QueryString["Eid"].ToString());
            if (cls.UpdateDivision())
            {
              GetData();
              clsGlobal.DisplayToast(this, "Updated!", "Division updated successfully.", "success", "/Settings/DivisionMaster");
            }
            else
            {
              clsGlobal.DisplayToast(this, "Alert!", "Something went wrong.", "error");
            }
          }
          else
          {
            int rest = cls.AddDivison();
            if (rest > 0)
            {
              GetData();
              txtname.Text = "";
              clsGlobal.DisplayToast(this, "Added!", "Division added successfully.", "success", "/Settings/DivisionMaster");

            }
            else
            {
             clsGlobal.DisplayToast(this, "Alert!", "Something went wrong.", "error");
            }

          }
        }
        else
        {
          ltrerr.Text = "Enter name of Division.";
        }
      }
      catch (Exception ex)
      {
        ltrerr.Text = ex.Message;
      }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      try
      {
        if (Request.QueryString.AllKeys.Contains("Eid") && Request.QueryString["Eid"].ToString() != null)
        {
          cls.Id = Convert.ToInt32(Request.QueryString["Eid"].ToString());
          if (cls.DeleteDivision())
          {
            GetData();
            clsGlobal.DisplayToast(this, "Updated!", "Division Deleted successfully.", "success", "/Settings/DivisionMaster");
          }
          else
          {
            clsGlobal.DisplayToast(this, "Alert!", "Something went wrong.", "error");
          }
        }
      }
      catch (Exception ex)
      {

        throw;
      }
    }
  }
}
