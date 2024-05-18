using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal.SolarSmart.Settings
{
  public partial class SendSMSList : System.Web.UI.Page
  {
    MySQLDB dbCon = new MySQLDB();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        string fromdate = dbCon.getDOCMtime();
        string todate = dbCon.getDOCMtime();

        txtDate.Text = (DateTime.Parse(fromdate.ToString())).ToString("dd-MM-yyyy");
        txtDate1.Text = (DateTime.Parse(todate.ToString())).ToString("dd-MM-yyyy");

        GetData();
      }
    }
    public DataTable GetData()
    {
      try
      {
        int CompanyId = 0;
        int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);

        string FromDate = dbCon.ConvertStringToDateTime(txtDate.Text.ToString().Trim()).ToString("yyyy-MM-dd") + " 00:00:00";
        string ToDate = dbCon.ConvertStringToDateTime(txtDate1.Text.ToString().Trim()).ToString("yyyy-MM-dd") + " 23:59:59";

        string select = "SELECT *,DATE_FORMAT(doc, '%d-%m-%Y %H:%i') as SMSDate,if(UserId=0,'Scheduler',(select Name from User where id = sms_history.Userid AND User.CompanyId=" + CompanyId + ")) as Username FROM sms_history where doc >= '" + FromDate + "' AND doc <= '" + ToDate + "' AND CompanyId=" + CompanyId + " Order by doc desc;";

        dt = dbCon.GetData(select);

        if (dt != null && dt.Rows.Count > 0)
        {
          string allRow = "";
          for (int i = 0; i < dt.Rows.Count; i++)
          {
            string Sms = System.Web.HttpUtility.UrlDecode(dt.Rows[i]["SmsText"].ToString());
            allRow += "<tr><td>" + dt.Rows[i]["SMSDate"].ToString() + "</td><td>" + dt.Rows[i]["Sentto"].ToString() + "</td><td>" + Sms + "</td><td>" + dt.Rows[i]["SmsLength"].ToString() + "</td><td>" + dt.Rows[i]["SmsCount"].ToString() + "</td><td>" + dt.Rows[i]["Username"].ToString() + "</td></tr>";
          }
          rowData.Text = allRow;
        }
      }
      catch (Exception ex)
      {

      }
      return dt;
    }
    protected void btngo_Click(object sender, EventArgs e)
    {
      GetData();
    }
  }
}
