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
  public partial class AnnounceMent : System.Web.UI.Page
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

          string todate = dbc.getDOCMtime();
          txttotillDate.Text = (DateTime.Parse(todate.ToString())).ToString("dd-MM-yyyy");
          txtfromtilldate.Text = (DateTime.Parse(todate.ToString())).ToString("dd-MM-yyyy");


          int CompanyId = 0;
          int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);

          if (Request.QueryString.AllKeys.Contains("Eid") && Request.QueryString["Eid"].ToString() != null)
          {
            btnadd.Text = "Update AnnounceMent";
            GetDataById();
          }
          else if (Request.QueryString.AllKeys.Contains("Did") && Request.QueryString["Did"].ToString() != null)
          {
            string Flag = "";
            cls.CompanyId = CompanyId;
            cls.Id = Convert.ToInt32(Request.QueryString["Did"].ToString());
            Flag = cls.DeleteAnnounceMent();
            if (Flag == "-1")
            {
              clsGlobal.DisplayToast(this, "Alert!", "Already exsist.", "error");
            }
            else if (Flag == "1")
            {
              clsGlobal.DisplayToast(this, "Updated!", "AnnounceMent updated successfully .", "success", "/Settings/AnnounceMent");
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
        dt = cls.GetAnnounceMentType();
        if (dt.Rows.Count > 0)
        {
          string allRow = "";
          for (int i = 0; i < dt.Rows.Count; i++)
          {
            allRow += "<tr><td>" + dt.Rows[i]["Id"].ToString() + "</td><td>" + dt.Rows[i]["Title"].ToString() + "</td><td>" + dt.Rows[i]["Description"].ToString() + "</td><td>" + dt.Rows[i]["ToTillDate"].ToString() + "</td><td>" + dt.Rows[i]["FromTillDate"].ToString() + "</td><td>" + dt.Rows[i]["IsActive"].ToString() + "</td><td>" + dt.Rows[i]["OpenAsPopup"].ToString() + "</td><td>" + dt.Rows[i]["CreateDate"].ToString() + "</td><td><a href='/Settings/AnnounceMent?Eid=" + dt.Rows[i]["Id"].ToString() + "'><i class='fas fa-edit' style=margine-right:8px;'></i>Edit</a></td><td><a href='/Settings/AnnounceMent?Did=" + dt.Rows[i]["Id"].ToString() + "' onclick=\"return confirm('Are You Sure Delete?')\"><i class='far fa-trash-alt' style=margine-right:8px;'></i> Delete</a></td></tr>";
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
        dt = cls.GetAnnounceMentById();
        if (dt.Rows.Count > 0)
        {
          txtTitle.Text = dt.Rows[0]["Title"].ToString();
          txtdesc.Text = dt.Rows[0]["Description"].ToString();
          txttotillDate.Text= (DateTime.Parse(dt.Rows[0]["ToTillDate"].ToString())).ToString("dd-MM-yyyy");
          txtfromtilldate.Text=(DateTime.Parse(dt.Rows[0]["FromTillDate"].ToString())).ToString("dd-MM-yyyy");

          if (dt.Rows[0]["IsActive"].ToString().ToLower() == "1")
          {
            chkisactive.Checked = true;
          }
          else
          {
            chkisactive.Checked = false;
          }

          if (dt.Rows[0]["OpenAsPopup"].ToString().ToLower() == "1")
          {
            chkOpenAsPopup.Checked = true;
          }
          else
          {
            chkOpenAsPopup.Checked = false;
          }


        }
        else
        {
          txtTitle.Text = "";
          txtdesc.Text = "";
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
      
        //cls.Request = Request;
        ltrerr.Text = "";
        if (txtTitle.Text.Trim() != ""&& txtdesc.Text.Trim() != "")
        {
          cls.Title = txtTitle.Text.Trim();
          cls.Description = txtdesc.Text.Trim();
          cls.ToTillDate =txttotillDate.Text;
          cls.FromTilllDate = txtfromtilldate.Text;
          if (chkisactive.Checked==true)
          {
            cls.IsActive = 1;
          }
          if (chkOpenAsPopup.Checked == true)
          {
            cls.OpenAsPopup = 1;
          }
          if (Request.QueryString.AllKeys.Contains("Eid") && Request.QueryString["Eid"].ToString() != null)
          {
            cls.Id = Convert.ToInt32(Request.QueryString["Eid"].ToString());
            if (cls.UpdateAnnounceMent())
            {
              Clear();
              GetData();
              clsGlobal.DisplayToast(this, "Updated!", "AnnounceMent updated successfully.", "success", "/Settings/AnnounceMent");
            }
            else
            {
              clsGlobal.DisplayToast(this, "Alert!", "Something went wrong.", "error");
            }
          }
          else
          {
            int rest = cls.AddAnnounceMent();
            if (rest > 0)
            {
              GetData();
              Clear();
              clsGlobal.DisplayToast(this, "Added!", "AnnounceMent added successfully.", "success", "/Settings/AnnounceMent");

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
        txtTitle.Text = "";
        txtdesc.Text = "";

      }
      catch (Exception ee)
      {
      }
    }
  }
}
