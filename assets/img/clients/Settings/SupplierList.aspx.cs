using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal.SolarSmart.Settings
{
  public partial class SupplierList : System.Web.UI.Page
  {
    MySQLDB dbCon = new MySQLDB();

    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        if (!IsPostBack)
        {

          //ddlProductType = dbCon.FillCombo(ddlProductType, "select TransportProductId, Name from transportproductmaster order by TransportProductId asc", "Name", "TransportProductId");
          //ddlProductType.SelectedIndex = 0;

          GetData();

        }
      }
      catch (Exception E)
      {
        ltrerr.Text = E.Message;
      }
    }

    public DataTable GetData()
    {
      try
      {
        int CompanyId = 0;
        int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);

        string select = "SELECT * from suppliermaster where IsActive = 1 AND CompanyId ="+ CompanyId + ";";
        dt = dbCon.GetData(select);
        if (dt != null && dt.Rows.Count > 0)
        {
          string NoViewactionTD = "<td><div class=\"input-group-prepend\"><button type=\"button\" class=\"btn btn-danger dropdown-toggle\" data-toggle=\"dropdown\" aria-expanded=\"false\">Action</button><ul class=\"dropdown-menu\" x-placement=\"bottom-start\" style=\"position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 48px, 0px);\"><li class=\"dropdown-item\"><a href=\"/Settings/AddSupplier?ID=XX\"><i class=\"fas fa-edit\" style=\"margin-right: 8px\"></i>Edit</a></li></ul></div></td>";

          string allRow = "";

          for (int i = 0; i < dt.Rows.Count; i++)
          {
            allRow += "<tr>" + NoViewactionTD.Replace("XX", dt.Rows[i]["Id"].ToString()) + "<td>" + dt.Rows[i]["Name"].ToString() + "</td><td>" + dt.Rows[i]["Mobile"].ToString() + "</td><td>" + dt.Rows[i]["PhoneNo"].ToString() + "</td><td>" + dt.Rows[i]["Address"].ToString() + "</td><td>" + dt.Rows[i]["EmailId"].ToString() + "</td><td>" + dt.Rows[i]["GSTNo"].ToString() + "</td></tr>";
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
      return dt;
    }

    protected void btngo_Click(object sender, EventArgs e)
    {
      GetData();
    }
  }
}
