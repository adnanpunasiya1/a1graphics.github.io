using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Portal.SolarSmart.Settings
{
  public partial class AddGeneralDocumentManagement : System.Web.UI.Page
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
            btnadd.Text = "Update GeneralDocument";
            GetDataById();
          }
          else if (Request.QueryString.AllKeys.Contains("Did") && Request.QueryString["Did"].ToString() != null)
          {
            string Flag = "";
            cls.CompanyId = CompanyId;
            cls.Id = Convert.ToInt32(Request.QueryString["Did"].ToString());
            Flag = cls.DeleteGeneralDocument();
            if (Flag == "-1")
            {
              clsGlobal.DisplayToast(this, "Alert!", "Already exsist.", "error");
            }
            else if (Flag == "1")
            {
              clsGlobal.DisplayToast(this, "Updated!", "GeneralDocument updated successfully .", "success", "/Settings/AddGeneralDocumentManagement");
            }
            else
            {
              clsGlobal.DisplayToast(this, "Alert!", "Something went wrong.", "error");
            }

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
        cls.Id = Convert.ToInt32(Request.QueryString["Eid"].ToString());
        dt = cls.GetAnnounceMentById();
        if (dt.Rows.Count > 0)
        {
          txtTitle.Text = dt.Rows[0]["Title"].ToString();
          txtdesc.Text = dt.Rows[0]["Description"].ToString();
        

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
        string Document = "";
        
        if (txtTitle.Text.Trim() != ""&& txtdesc.Text.Trim() != "")
        {
          if (fileDocument.HasFiles)
          {
            Stream fs = fileDocument.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            //Byte[] image = br.ReadBytes((Int32)fs.Length);


            string exten = System.IO.Path.GetExtension(fileDocument.FileName);
            string name = System.IO.Path.GetFileName(fileDocument.FileName);

            string ext1 = System.IO.Path.GetExtension(fileDocument.FileName);
            ext1 = ext1.Replace(".", "image/");

            Document = name;

            string path = clsGlobal.UserImageLocal + Document;
            fileDocument.SaveAs(path);
            cls.GeneralDocument = Document;


          }
          else
          {
            cls.Id = Convert.ToInt32(Request.QueryString["Eid"].ToString());
            DataTable VALUE = dbc.GetData("SELECT Document FROM Document WHERE id="+cls.Id+" ");
            if (VALUE.Rows.Count>0)
            {
              cls.GeneralDocument = VALUE.Rows[0]["Document"].ToString();
            }
          }
          cls.Title = txtTitle.Text.Trim();
          cls.Description = txtdesc.Text.Trim();
          if (Request.QueryString.AllKeys.Contains("Eid") && Request.QueryString["Eid"].ToString() != null)
          {
            cls.Id = Convert.ToInt32(Request.QueryString["Eid"].ToString());
            if (cls.UpdateGeneralDocument())
            {
              Clear();
              clsGlobal.DisplayToast(this, "Updated!", "GeneralDocument updated successfully.", "success", "/Settings/GeneralDocumentManagementList");
            }
            else
            {
              clsGlobal.DisplayToast(this, "Alert!", "Something went wrong.", "error");
            }
          }
          else
          {
            int rest = cls.AddGeneralDocument();
            if (rest > 0)
            {
              Clear();
              clsGlobal.DisplayToast(this, "Added!", "GeneralDocument added successfully.", "success", "/Settings/GeneralDocumentManagementList");

            }
            else
            {
              clsGlobal.DisplayToast(this, "Alert!", "Something went wrong.", "error");
            }

          }
        }
        else
        {
          ltrerr.Text = "Enter Title and Description.";
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
