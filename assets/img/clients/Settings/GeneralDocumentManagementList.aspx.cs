using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Portal.SolarSmart.Settings
{
  public partial class GeneralDocumentManagementList : System.Web.UI.Page
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
          if (Request.QueryString.AllKeys.Contains("Did") && Request.QueryString["Did"].ToString() != null)
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
              clsGlobal.DisplayToast(this, "Updated!", "GeneralDocument updated successfully .", "success", "/Settings/GeneralDocumentManagementList");
            }
            else
            {
              clsGlobal.DisplayToast(this, "Alert!", "Something went wrong.", "error");
            }

          }
        }
        GetData();
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
        dt = cls.GetGeneralDocumentType();
        if (dt.Rows.Count > 0)
        {
          string allRow = "";
          string actionTD = "<td><div class=\"input-group-prepend\"><button type=\"button\" class=\"btn btn-danger dropdown-toggle\" data-toggle=\"dropdown\" aria-expanded=\"false\">Action</button><ul class=\"dropdown-menu\" x-placement=\"bottom-start\" style=\"position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 48px, 0px);\"><li class=\"dropdown-item\"><a onclick=\"downloadFile('FileDocumenet')\"><i class=\"far fa-file\" style=\"margin-right: 8px\"></i>Download</a></li><li class=\"dropdown-item\"><a onclick=\"share('FileDocumenet')\" style=\"cursor: pointer\"><i class=\"far fa-edit\" style=\"margin-right: 8px\"></i>Share</a></li></ul></div></td>";

          for (int i = 0; i < dt.Rows.Count; i++)
          {
            string tdactionTD = actionTD;
            string document = "Data/UserPhotos/" +dt.Rows[i]["Document"].ToString();
            string FullPath = clsGlobal.UserImageLocal + document;
            tdactionTD = tdactionTD.Replace("XX", dt.Rows[i]["Id"].ToString());
            tdactionTD = tdactionTD.Replace("FileDocumenet", document);
            allRow += "<tr>" + tdactionTD+ "<td>" + dt.Rows[i]["Id"].ToString() + "</td><td>" + dt.Rows[i]["Title"].ToString() + "</td><td>" + dt.Rows[i]["Description"].ToString() + "</td><td>" + dt.Rows[i]["Document"].ToString() + "</td><td>" + dt.Rows[i]["CreateDate"].ToString() + "</td><td><a href='/"+ document + "' target=\"_blank\"><i class='fas fa-eye' style=margine-right:8px; ></i>View</a></td><td><a href='/Settings/AddGeneralDocumentManagement?Eid=" + dt.Rows[i]["Id"].ToString() + "'><i class='fas fa-edit' style=margine-right:8px;></i>Edit</a></td><td><a href='/Settings/GeneralDocumentManagementList?Did=" + dt.Rows[i]["Id"].ToString() + "' onclick=\"return confirm('Are You Sure Delete?')\"><i class='far fa-trash-alt' style=margine-right:8px;></i>Delete</a></td></tr>";
          }
          //<a href="/" + document + "><i class="fas fa-eye" style="margin-right: 8px;"></i></a>

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

    [WebMethod]
    public  void DownLoadFile(string FileName)
    {
      JavaScriptSerializer js = new JavaScriptSerializer();
      HttpContext.Current.Response.Clear();
      HttpContext.Current.Response.ContentType = "application/json";
      string folderPath = clsGlobal.UserImageLocal;
      string filePath = Path.Combine(folderPath, FileName);

      FileInfo file = new FileInfo(filePath);
      if (file.Exists)
      {
        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
        Response.AddHeader("Content-Length", file.Length.ToString());
        Response.ContentType = "text/plain";
        Response.Flush();
        Response.TransmitFile(file.FullName);
        Response.End();
      }
      else
      {
        // File not found, handle the error
        Response.Write("File not found.");
      }
      //Context.Response.Write(js.Serialize(obj));
    }
  }
}
