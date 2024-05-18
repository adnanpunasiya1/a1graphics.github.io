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
  public partial class UserManagerList : System.Web.UI.Page
  {
    MySQLDB dbCon = new MySQLDB();
    DataTable dt = new DataTable();
    ClsUser cls = new ClsUser();
    string actionTD = "<td><div class=\"input-group-prepend\"><button type=\"button\" class=\"btn btn-danger dropdown-toggle\" data-toggle=\"dropdown\" aria-expanded=\"false\">Action</button><ul class=\"dropdown-menu\" x-placement=\"bottom-start\" style=\"position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 48px, 0px);\"><li class=\"dropdown-item\"><a href=\"/CustomerQuotation/ProjectSchemaSubsidy?ID=XX&Flag=1\"><i class=\"far fa-edit\" style=\"margin-right: 8px\"></i>Edit</a></li><li style=\"color:#007bff\" class=\"dropdown-item\" onclick=\"Delete(XX)\"><i class=\"fa fa-trash\" style=\"margin-right: 8px\" aria-hidden=\"true\"></i>Delete</a></li></ul></div></td>";
    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        if (!IsPostBack)
        {
          int CompanyId = 0;
          int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);

          ddlManager = dbCon.FillCombo(ddlManager, "SELECT * FROM user where IsActive = 1 AND Id in (Select distinct ManagerId from user as manageruser) AND CompanyId = " + CompanyId + " order by Name asc", "Name", "Id");
          ddlManager.SelectedIndex = 0;
          
        }
      }
      catch (Exception ee)
      {
      }
    }
    public void GetDataSubsidy()
    {
      try
      {
        int CompanyId = 0;
        int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);
        cls.CompanyId = CompanyId;

        int ManagerId = 0;

        if (ddlManager.SelectedIndex > 0)
        {
          int.TryParse(ddlManager.SelectedValue, out ManagerId);
          
          dt = cls.GetUser_ManagerId(ManagerId.ToString());

          string allRow = "";

          if (dt != null && dt.Rows.Count > 0)
          {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
              allRow += "<tr><td>" + dt.Rows[i]["Name"].ToString() + "</td><td>" + dt.Rows[i]["Mobile"].ToString() + "</td><td>" + dt.Rows[i]["Username"].ToString() + "</td><td>" + dt.Rows[i]["Password"].ToString() + "</td><td>" + dt.Rows[i]["RoleName"].ToString() + "</td><td>" + dt.Rows[i]["ManagerName"].ToString() + "</td><td>" + dt.Rows[i]["email"].ToString() + "</td><td>" + dt.Rows[i]["Address"].ToString() + "</td><td>" + dt.Rows[i]["Commission"].ToString() + "</td></tr>";
            }
            rowData.Text = allRow;
          }
          else
          {
            rowData.Text = "";
          }
        }
        else
        {
          clsGlobal.DisplayToast(this, "Alert!", "Please Select Manager.", "error");
        }

      }
      catch (Exception ee)
      {
        ltrerr.Text = ee.Message;
      }
    }
    
    protected void btngo_Click(object sender, EventArgs e)
    {
      GetDataSubsidy();
    }
  }
}
