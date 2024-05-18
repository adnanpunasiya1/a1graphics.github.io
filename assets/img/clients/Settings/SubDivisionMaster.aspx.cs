using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Portal.SolarSmart.Settings
{
  public partial class SubDivisionMaster : System.Web.UI.Page
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
          ddldivisionlist = dbc.FillCombo(ddldivisionlist, "select Id, DivisionName from divisionmaster where IsDelete=0  order by Id asc", "DivisionName", "Id");

          ddldivisionlist.SelectedIndex = 0;
          if (Request.QueryString.AllKeys.Contains("Eid") && Request.QueryString["Eid"].ToString() != null)
          {
            btnadd.Text = "Update";
            btnDelete.Visible = true;
            GetDataById();
          }
          GetData();
        }
      }
      catch (Exception ee)
      {

      }
    }
    public void GetData()
    {
      try
      {
        dt = cls.GetSubDivision();
        if (dt.Rows.Count > 0)
        {
          string allRow = "";
          for (int i = 0; i < dt.Rows.Count; i++)
          {
            allRow += "<tr><td>" + dt.Rows[i]["DivisionName"].ToString() + "</td><td>" + dt.Rows[i]["SubDivisionName"].ToString() + "</td><td>" + dt.Rows[i]["Email"].ToString() + "</td><td>" + dt.Rows[i]["ContactPersonName"].ToString() + "</td><td>" + dt.Rows[i]["Mobile"].ToString() + "</td><td><a href='/Settings/SubDivisionMaster.aspx?Eid=" + dt.Rows[i]["Id"].ToString() + "'><i class='fas fa-edit' style=margine-right:8px;'></i></a></td></tr>";

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
        dt = cls.GetSubDivisionById();
        if (dt.Rows.Count > 0)
        {
          txtsubdiv.Text = dt.Rows[0]["SubDivisionName"].ToString();
          txtemail.Text = dt.Rows[0]["Email"].ToString();
          txtmobile.Text = dt.Rows[0]["Mobile"].ToString();
          txtcontactpersonname.Text = dt.Rows[0]["ContactPersonName"].ToString();
          ddldivisionlist.SelectedValue = dt.Rows[0]["DivisionId"].ToString();
        }
        else
        {
          Clear();
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
    public void Clear()
    {
      txtcontactpersonname.Text = "";
      txtemail.Text = "";
      txtmobile.Text = "";
      txtsubdiv.Text = "";
      ddldivisionlist = dbc.FillCombo(ddldivisionlist, "select Id, DivisionName from divisionmaster where IsDelete=0  order by Id asc", "DivisionName", "Id");
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
      try
      {
        ltrerr.Text = "";
        if (txtsubdiv.Text.Trim() != "")
        {
          cls.SubDivName = txtsubdiv.Text.Trim();
          cls.EmailId = txtemail.Text.Trim();
          cls.MobileNumber = txtmobile.Text.Trim();
          cls.ContactPersonName = txtcontactpersonname.Text.Trim();
          int DvisionId = 0;
          int.TryParse(ddldivisionlist.SelectedValue.ToString(), out DvisionId);
          cls.DivId = DvisionId;
          cls.Dom = dbc.getindiantime();

          dt = cls.GetSubDivision();
          if (dt != null && dt.Rows.Count > 0)
          {
            DataRow[] drAvail = dt.Select("SubDivisionName = '" + txtsubdiv.Text.Trim() + "' AND IsDelete = 0");
            if (drAvail != null && drAvail.Length > 0)
            {
              clsGlobal.DisplayToast(this, "Alert!", "Already Available " + txtsubdiv.Text.Trim(), "error");
              return;
            }
          }

          if (Request.QueryString.AllKeys.Contains("Eid") && Request.QueryString["Eid"].ToString() != null)
          {
            cls.Id = Convert.ToInt32(Request.QueryString["Eid"].ToString());
            if (cls.UpdateSubDivision())
            {
              GetData();
              clsGlobal.DisplayToast(this, "Updated!", "Sub Division updated successfully.", "success", "/Settings/SubDivisionMaster");
            }
            else
            {
              clsGlobal.DisplayToast(this, "Alert!", "Something went wrong.", "error");
            }
          }
          else
          {
            cls.Doc = dbc.getindiantime();
            int rest = cls.AddSubDivison();
            if (rest > 0)
            {
              GetData();
              Clear();
              clsGlobal.DisplayToast(this, "Added!", "Sub Division added successfully.", "success", "/Settings/SubDivisionMaster");

            }
            else
            {
              clsGlobal.DisplayToast(this, "Alert!", "Something went wrong.", "error");
            }

          }
        }
        else
        {
          ltrerr.Text = "Enter name of Sub Division.";
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
          if (cls.DeleteSubDivision())
          {
            GetData();
            clsGlobal.DisplayToast(this, "Updated!", "Sub-Division Deleted successfully.", "success", "/Settings/SubDivisionMaster");
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
