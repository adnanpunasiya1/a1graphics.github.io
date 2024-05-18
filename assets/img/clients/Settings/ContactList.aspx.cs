using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal.SolarSmart.Settings
{
  public partial class ContactList : System.Web.UI.Page
  {
    MySQLDB dbCon = new MySQLDB();
    ClsUser cls = new ClsUser();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        if (!IsPostBack)
        {

          GetData();

          if (Request.QueryString.AllKeys.Contains("Callid") && Request.QueryString["Callid"].ToString() != null)
          {
            try
            {
              string userid = "0";
              try
              {
                userid = clsGlobal.GetCookiesData("UserId").ToString();
                if (userid == null || String.IsNullOrEmpty(userid))
                {
                  userid = "0";
                }
              }
              catch (Exception)
              {
                userid = "0";
              }

              string mobileNumber = Request.QueryString["Callid"].ToString().Replace(" ", "");
              if (!String.IsNullOrEmpty(mobileNumber) && mobileNumber.Trim().Length == 10 && !userid.Equals("0"))
              {
                MySQLDB dbCon = new MySQLDB();
                bool rest = dbCon.ClickToCallUserID(userid, mobileNumber);
                if (rest)
                {
                  clsGlobal.DisplayToast(this, "Alert!", "Wait, Call in Process.", "error");
                }
                else
                {
                  clsGlobal.DisplayToast(this, "Alert!", "Something went wrong.", "error");
                }
              }
              else
              {
                clsGlobal.DisplayToast(this, "Alert!", "Please Enter Valid Mobile Number", "error");
              }
            }
            catch (Exception ex)
            {
              //ltrerr.Text = ex.Message;
            }
          }
        }
      }
      catch (Exception)
      {

      }
    }

    public void GetData(string isActive = "1")
    {
      try
      {
        int CompanyId = 0;
        int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);
        cls.CompanyId = CompanyId;
        dt = cls.GetUser(isActive);
        string allRow = "";
        string febRow = "";
        string instRow = "";
        string dealerRow = "";
        if (dt != null && dt.Rows.Count > 0)
        {

          for (int i = 0; i < dt.Rows.Count; i++)
          {
            string userImage = "";
            if (!string.IsNullOrEmpty(dt.Rows[i]["UserPhoto"].ToString()))
            {
              userImage = clsGlobal.UserImagePathWeb + dt.Rows[i]["UserPhoto"].ToString();
            }
            else
            {
              userImage = clsGlobal.UserImagePathWeb + clsGlobal.defaultUserImage;
            }

            string editRights = "<a href='https://wa.me/91" + dt.Rows[i]["Mobile"].ToString() + "' target='_blank' class='btn btn-sm btn-success'><i class='fab fa-whatsapp'></i></a> <a href=\"tel:" + dt.Rows[i]["Mobile"].ToString() + "\" class=\"btn btn-sm bg-primary\"> <i class=\"fas fa-phone-alt\"></i> </a> ";
            if (clsGlobal.GetCookiesData("RoleId").ToString().Equals("16"))
            {
              editRights += "<a href=\"/Settings/Users?Eid=" + dt.Rows[i]["Id"].ToString() + "\" class=\"btn btn-sm bg-teal\"> <i class=\"fas fa-edit\"></i> </a>";
            }
            else
            {
              editRights += "";
            }
            //<li class=\"small text-sm\"><span class=\"fa-li\"><i class=\"fas fa-sm fa-building\"></i></span> Address: " + dt.Rows[i]["Address"].ToString() + "</li> <li class=\"small text-sm\"><span class=\"fa-li\"><i class=\"fas fa-sm fa-tint\"></i></span> Blood Group: " + dt.Rows[i]["blood"].ToString() + "</li> <li class=\"small text-sm\"><span class=\"fa-li\"><i class=\"fas fa-sm fa-birthday-cake\"></i></span> DOB: " + dt.Rows[i]["DOB"].ToString() + "</li> 

            string deactiverebin = "";
            if (dt.Rows[i]["isactive"].ToString().Equals("No"))
            {
              deactiverebin = "<div class='ribbon-wrapper ribbon-lg'><div class='ribbon bg-danger'>Deactivated</div></div>";
            }
            
              allRow += "<div class=\"col-12 col-sm-6 col-md-4 d-flex align-items-stretch\"> <div class=\"card bg-light\"> <div class=\"card-header text-muted border-bottom-0\"> " + deactiverebin + " " + dt.Rows[i]["RoleName"].ToString() + " </div> <div class=\"card-body pt-0\"> <div class=\"row\"> <div class=\"col-9\"> <h2 class=\"lead\"><b>" + dt.Rows[i]["Name"].ToString() + "</b></h2> <ul class=\"ml-4 mb-0 fa-ul text-muted\"> <li class=\"small text-sm\"><span class=\"fa-li\"><i class=\"fas fa-sm fa-envelope\"></i></span> <a href=\"mailto:" + dt.Rows[i]["email"].ToString() + "\">" + dt.Rows[i]["email"].ToString() + "</a></li> <li class=\"small text-sm\"><span class=\"fa-li\"><i class=\"fas fa-sm fa-phone\"></i></span> Phone: <a href=\"tel:" + dt.Rows[i]["Mobile"].ToString() + "\">" + dt.Rows[i]["Mobile"].ToString() + "</a></li> </ul> </div> <div class=\"col-3 text-center\"> <img src=\"" + userImage + "\" alt=\"\"  style=\"width: 100%;\" class=\"img-circle img-fluid elevation-2\"> </div> </div> </div> <div class=\"card-footer\"> <div class=\"text-right\"> " + editRights + " <a href=\"/Settings/UserProfile?Id=" + dt.Rows[i]["Id"].ToString() + "\" class=\"btn btn-sm btn-info\"> <i class=\"fas fa-user\"></i> View Profile </a> </div> </div> </div> </div>";
            
          }
          rowData.Text = allRow;
         
        }
        else
        {
          allRow = "";
          rowData.Text = allRow;
          

        }
      }
      catch (Exception E)
      {
        //ltrerr.Text = E.Message;
      }
      finally
      {
        dt.Dispose();
      }
    }



    protected void btnadd_Click(object sender, EventArgs e)
    {

    }

    protected void btnadd_Click1(object sender, EventArgs e)
    {
      GetData("0");
    }
  }
}
