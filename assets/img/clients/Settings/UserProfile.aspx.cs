using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal.SolarSmart.Settings
{
  public partial class UserProfile : System.Web.UI.Page
  {
    MySQLDB dbCon = new MySQLDB();

    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        if (!IsPostBack)
        {
          string fromdate = dbCon.getDOCMtime();
          string todate = dbCon.getDOCMtime();

          txtDate.Text = (DateTime.Parse(fromdate.ToString())).ToString("dd-MM-yyyy");
          txtDate1.Text = (DateTime.Parse(todate.ToString())).ToString("dd-MM-yyyy");
          ddldoctype = dbCon.FillCombo(ddldoctype, "select Id, DocumentType from userdocumenttypemaster order by DocumentType asc", "DocumentType", "Id");
          GetData();
          GetUserActivityData();
          GetUserDcoument();
        }
      }
      catch (Exception)
      {

      }
    }
    public void GetData()
    {
      try
      {
        string user_id = "";
        if (Request.QueryString != null && Request.QueryString.AllKeys.Contains("Id") && !String.IsNullOrEmpty(Request.QueryString["Id"]))
        {
          user_id = Request.QueryString["Id"].ToString();

          int CompanyId = 0;
          int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);

          ClsUser cls = new ClsUser();
          cls.CompanyId = CompanyId;
          DataTable dtUser = cls.GetUserProfile(user_id);
          if (dtUser != null && dtUser.Rows.Count > 0)
          {
            string profilePic = "";
            if (!string.IsNullOrEmpty(dtUser.Rows[0]["UserPhoto"].ToString()))
            {
              profilePic = clsGlobal.UserImagePathWeb + dtUser.Rows[0]["UserPhoto"].ToString();
            }
            else
            {
              profilePic = clsGlobal.UserImagePathWeb + clsGlobal.defaultUserImage;
            }
            ltrProfilePic.Text = "<img class='profile-user-img img-fluid img-circle' src='" + profilePic + "' alt='User profile picture'>";
            ltrEmpName.Text = "<h3 class='profile-username text-center'>" + dtUser.Rows[0]["Name"].ToString() + "</h3>";
            ltrRole.Text = "<p class='text-muted text-center'>" + dtUser.Rows[0]["RoleName"].ToString() + "</p>";
            ltrUsername.Text = "<a class='float-right'>" + dtUser.Rows[0]["Username"].ToString() + "</a>";
            ltrMobile.Text = "<a class='float-right' href='tel:" + dtUser.Rows[0]["Mobile"].ToString() + "'>" + dtUser.Rows[0]["Mobile"].ToString() + "</a>";
            ltrEmail.Text = "<a class='float-right' href='mailto:" + dtUser.Rows[0]["email"].ToString() + "'>" + dtUser.Rows[0]["email"].ToString() + "</a>";
            ltrWhatsapp.Text = "<a href='https://wa.me/91" + dtUser.Rows[0]["Mobile"].ToString() + "' target='_blank' class='btn btn-success btn-block'><b><i class='fab fa-whatsapp'></i> Whatsapp</b></a>";
            ltrAddress.Text = "<p class='text-muted'>" + dtUser.Rows[0]["Address"].ToString() + "</p>";
            ltrDOB.Text = "<p class='text-muted'>" + dtUser.Rows[0]["DOBDisp"].ToString() + "</p>";
            ltrBG.Text = "<p class='text-muted'>" + dtUser.Rows[0]["blood"].ToString() + "</p>";


            if (clsGlobal.GetCookiesData("RoleId").ToString().Equals("16") && dtUser.Rows[0]["RoleId"].ToString().Equals("23"))
            {
              ltrPassword.Text = "<a class='float-right'>" + dtUser.Rows[0]["Password"].ToString() + "</a>";
              liPassword.Visible = true;
            }
            else
            {
              liPassword.Visible = false;
            }

          }
          else
          {
            clsGlobal.DisplayToast(this, "Alert!", "User Details Not Found !!", "error");
          }

          //if (clsGlobal.GetCookiesData("RoleId").ToString().Equals("3") || clsGlobal.GetCookiesData("RoleId").ToString().Equals("3") || !clsGlobal.GetCookiesData("RoleId").ToString().Equals("16"))
          //{
          //  AddUserTeam.Text = "<a href='/Settings/UsersTeam?Uid=" + user_id + "' class='btn btn-primary pull-right justify-content-center align-items-center'><i class='fa fa-user-plus' style='margin-right: 8px'></i>Add New Member</a>";

          //  DataTable dtTeam = cls.GetUserTeam(user_id);
          //  if (dtTeam != null && dtTeam.Rows.Count > 0)
          //  {
          //    string allrows = "";
          //    for (int i = 0; i < dtTeam.Rows.Count; i++)
          //    {
          //      string userImage = "";
          //      if (!string.IsNullOrEmpty(dtTeam.Rows[i]["UserPhoto"].ToString()))
          //      {
          //        userImage = clsGlobal.UserImagePathWeb + dtTeam.Rows[i]["UserPhoto"].ToString();
          //      }
          //      else
          //      {
          //        userImage = clsGlobal.UserImagePathWeb + clsGlobal.defaultUserImage;
          //      }

          //      allrows += "<div class=\"col-12 col-sm-6 col-md-4 d-flex align-items-stretch\"> <div class=\"card bg-light\"> <div class=\"card-header text-muted border-bottom-0\"></div> <div class=\"card-body pt-0\"> <div class=\"row\"> <div class=\"col-9\"> <h2 class=\"lead\"><b>" + dtTeam.Rows[i]["Name"].ToString() + "</b></h2> <ul class=\"ml-4 mb-0 fa-ul text-muted\"> <li class=\"small text-sm\"><span class=\"fa-li\"><i class=\"fas fa-sm fa-phone\"></i></span> Phone: <a href=\"tel:" + dtTeam.Rows[i]["Mobile"].ToString() + "\">" + dtTeam.Rows[i]["Mobile"].ToString() + "</a></li><li class=\"small text-sm\"><span class=\"fa-li\"><i class=\"fas fa-sm fa-building\"></i></span> Address: " + dtTeam.Rows[i]["Address"].ToString() + "</li> </ul> </div> <div class=\"col-3 text-center\"> <img src=\"" + userImage + "\" alt=\"\"  style=\"width: 100%;\" class=\"img-circle img-fluid elevation-2\"> </div> </div> </div> <div class=\"card-footer\"> <div class=\"text-right\"> <a href=\"/Settings/UsersTeam?Uid=" + user_id + "&Eid=" + dtTeam.Rows[i]["Id"].ToString() + "\" class=\"btn btn-sm bg-teal\"> <i class=\"fas fa-edit\"></i> </a> </div> </div> </div> </div>";
          //    }
          //    rowData.Text = allrows;
          //  }
          //}
          //else
          //{
            liTeam.Visible = false;
          //}

          if (clsGlobal.GetCookiesData("UserId").ToString().Equals(user_id))
          {
            liPwd.Visible = true;
          }
          else
          {
            liPwd.Visible = false;
          }


        }
        else
        {
          clsGlobal.DisplayToast(this, "Alert!", "User Id Not Found !!", "error", "/Settings/ContactList");
        }
      }
      catch (Exception ex)
      {
        clsGlobal.DisplayToast(this, "Alert!", "Error:" + ex.Message.ToString(), "error");
      }
    }
    protected void btnChange_Click(object sender, EventArgs e)
    {
      try
      {
        string user_id = "";
        if (Request.QueryString != null && Request.QueryString.AllKeys.Contains("Id") && !String.IsNullOrEmpty(Request.QueryString["Id"]))
        {
          user_id = Request.QueryString["Id"].ToString();

          if (String.IsNullOrEmpty(txtPasswordLogin.Text.ToString().Trim()) || String.IsNullOrEmpty(txtNewPassword.Text.ToString().Trim()) || String.IsNullOrEmpty(txtConfPassword.Text.ToString().Trim()))
          {
            clsGlobal.DisplayToast(this, "Alert!", "Please fill all details !!", "error");
            return;
          }

          if (!txtNewPassword.Text.ToString().Trim().Equals(txtConfPassword.Text.ToString().Trim()))
          {
            clsGlobal.DisplayToast(this, "Alert!", "New Password and Confirm Password is not match.!!", "error");
            return;
          }

          ClsUser cls = new ClsUser();
          int CompanyId = 0;
          int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);
          cls.CompanyId = CompanyId;
          DataTable dtUser = cls.GetUserProfile(user_id);
          if (dtUser != null && dtUser.Rows.Count > 0)
          {
            if (!dtUser.Rows[0]["Password"].ToString().Equals(txtPasswordLogin.Text.ToString().Trim()))
            {
              clsGlobal.DisplayToast(this, "Alert!", "Current Password is not valid.!!", "error");
              return;
            }

            cls.Password = txtNewPassword.Text.ToString().Trim();
            cls.Id = int.Parse(user_id);
            cls.CompanyId = CompanyId;
            if (cls.ChangePassword())
            {
              clsGlobal.DisplayToast(this, "Alert!", "Password Change Successfully.", "success", "/Settings/UserProfile?Id=" + user_id + "");
            }
            else
            {
              clsGlobal.DisplayToast(this, "Alert!", "Something went wrong. Please try after some time.", "error");
              return;
            }
          }
        }
        else
        {
          clsGlobal.DisplayToast(this, "Alert!", "User Id Not Found !!", "error", "/Settings/ContactList");
        }
      }
      catch (Exception ex)
      {
        clsGlobal.DisplayToast(this, "Alert!", "Error:" + ex.Message.ToString(), "error");
      }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
      GetUserActivityData();
    }

    public void GetUserActivityData()
    {
      try
      {
        #region Login Time
        string user_id = Request.QueryString["Id"].ToString();

        int CompanyId = 0;
        int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);
        string select = "SELECT * FROM usertracker where CompanyId = "+ CompanyId + " AND userid = " + user_id + " and ActionName ='Login' order by id desc limit 1;;";
        DataTable dt = dbCon.GetData(select);
        if (dt != null && dt.Rows.Count > 0)
        {
          long LoginTicks = 0;
          long.TryParse(dt.Rows[0]["DOM"].ToString(), out LoginTicks);

          string LoginTime = new DateTime(LoginTicks).ToString("dd-MMM-yyyy HH:mm");

          spLoginTime.InnerText = LoginTime;
        }
        else
        {
          spLoginTime.InnerText = "";
        }

        #endregion

        #region User Data

        string[] frmdate = txtDate.Text.Split('-');
        string[] todate = txtDate1.Text.Split('-');

        long Fromtime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).Ticks;
        long Totime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59).Ticks;

        if (frmdate != null && frmdate.Length == 3 && todate != null && todate.Length == 3)
        {
          int fdate, fmonth, fyear, tdate, tmonth, tyear = 0;

          int.TryParse(frmdate[0], out fdate);
          int.TryParse(frmdate[1], out fmonth);
          int.TryParse(frmdate[2], out fyear);
          int.TryParse(todate[0], out tdate);
          int.TryParse(todate[1], out tmonth);
          int.TryParse(todate[2], out tyear);

          Fromtime = new DateTime(fyear, fmonth, fdate, 0, 0, 0).Ticks;
          Totime = new DateTime(tyear, tmonth, tdate, 23, 59, 59).Ticks;
        }

        string selectActivities = "SELECT *,DATE_FORMAT( DATE_ADD('0001-01-01 00:00:00',  INTERVAL DOM/10000000 SECOND_MICROSECOND),'%d-%m-%Y') as Date, DATE_FORMAT( DATE_ADD('0001-01-01 00:00:00',  INTERVAL DOM/10000000 SECOND_MICROSECOND),'%H:%m') as Time FROM usertracker where userid = " + user_id + " and DOM >= " + Fromtime + " AND DOM <= " + Totime + " order by id desc;";
        DataTable dtActivities = dbCon.GetData(selectActivities);
        if (dtActivities != null && dtActivities.Rows.Count > 0)
        {
          string Activities = "";
          for (int i = 0; i < dtActivities.Rows.Count; i++)
          {
            Activities += "<tr><td>" + new DateTime(long.Parse(dtActivities.Rows[i]["DOM"].ToString())).ToString("dd-MMM-yyyy HH:mm") + "</td><td>" + dtActivities.Rows[i]["URL"].ToString() + "</td><td>" + dtActivities.Rows[i]["ActionName"].ToString() + "</td><td>" + dtActivities.Rows[i]["IPAddress"].ToString() + "</td><td>" + dtActivities.Rows[i]["browserName"].ToString() + "</td><td><a href='https://www.google.com/maps/search/?api=1&query=" + dtActivities.Rows[i]["Latitude"].ToString() + "," + dtActivities.Rows[i]["Longitude"].ToString() + "' target='_blank'><i class='fas fa-location-arrow' style=margine-right:8px;'></i></a></td></tr>";
          }
          ltrActivites.Text = Activities;
        }
        else
        {
          ltrActivites.Text = "";
        }
        #endregion
      }
      catch (Exception ex)
      {
        clsGlobal.DisplayToast(this, "Alert!", "Error:" + ex.Message.ToString(), "error");
      }
    }

    protected void btnupload_Click(object sender, EventArgs e)
    {
      ClsUser cls = new ClsUser();
      try
      {
        int UserId = 0;
        int.TryParse(Request.QueryString["ID"].ToString(), out UserId);
        cls.Id = UserId;

        int doctype = 0;
        int.TryParse(ddldoctype.SelectedValue.ToString(), out doctype);

        string workPhoto = "";
        if (fuworkupload.HasFile)
        {
          string ext = System.IO.Path.GetExtension(fuworkupload.PostedFile.FileName);
          string[] validFileTypes = { "png", "jpg", "jpeg", "pdf", "xls" };
          bool isValidFile = false;
          for (int i = 0; i < validFileTypes.Length; i++)
          {
            if (ext == "." + validFileTypes[i])
            {
              isValidFile = true;
              break;
            }
          }

          if (!isValidFile)
          {
            //ltrerr.Text = "<span style=\"margin-left:4%;margin-bottom:0%;margin-top:2%;color: red\"><i class=\"fa fa-exclamation\" style=\"margin-right:5px\"></i> Invalid File. Please upload valid Image file (.png, .jpg, .jpeg). </span><br/>";
            clsGlobal.DisplayToast(this, "Alter!", "Invalid File. Please upload valid Image file (.png, .jpg, .jpeg).", "error");
            return;
          }
          else
          {

            // byte[] image = File.ReadAllBytes(FileUploadControl.FileName);

            System.IO.Stream fs = fuworkupload.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            //Byte[] image = br.ReadBytes((Int32)fs.Length);
            Byte[] image = null;

            string exten = System.IO.Path.GetExtension(fuworkupload.FileName);
            string name = System.IO.Path.GetFileName(fuworkupload.FileName);

            string ext1 = System.IO.Path.GetExtension(fuworkupload.FileName);
            ext1 = ext1.Replace(".", "image/");

            workPhoto = DateTime.Now.Ticks + exten;

            string path = clsGlobal.UserImageLocal + workPhoto;
            fuworkupload.SaveAs(path);
          }
        }
        else
        {
          clsGlobal.DisplayToast(this, "Alter!", "Please upload valid Image file (.png, .jpg, .jpeg).", "error");
          return;
        }

        int CompanyId = 0;
        int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);
        cls.CompanyId = CompanyId;

        cls.doctype = doctype;
        cls.FileName = workPhoto;
        cls.Remarks = "";
        cls.Uploadby = int.Parse(clsGlobal.GetCookiesData("UserId").ToString());
        if (cls.UploadUserDocument())
        {
          clsGlobal.DisplayToast(this, "Updated!", "User Document Uploaded Successfully.", "success", "/Settings/UserProfile?Id=" + UserId);
          GetUserDcoument();
        }

        else
        {
          clsGlobal.DisplayToast(this, "Alter!", "Something Went Wrong !!", "error");
        }
      }
      catch (Exception ex)
      {

        clsGlobal.DisplayToast(this, "Alert!", "Error:" + ex.Message.ToString(), "error");
      }
    }

    public void GetUserDcoument()
    {
      try
      {
        int UserId = 0;
        int.TryParse(Request.QueryString["ID"].ToString(), out UserId);
        int CompanyId = 0;
        int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);
        
        string workdata = "SELECT userdocumentdetails.*,DATE_FORMAT(uploadDate, '%d-%m-%Y') as UploadOn, userdocumenttypemaster.DocumentType as StatusText,user.name as UploadByName FROM userdocumentdetails inner join userdocumenttypemaster on userdocumentdetails.DocType = userdocumenttypemaster.Id inner join User on userdocumentdetails.UploadBy = User.Id where IsDelete = 0 AND UserId = " + UserId + " AND userdocumentdetails.CompanyId = " + CompanyId + ";";

        DataTable dtWork = dbCon.GetData(workdata);
        if (dtWork != null && dtWork.Rows.Count > 0)
        {
          string allRow = "";
          for (int i = 0; i < dtWork.Rows.Count; i++)
          {
            string removeButton = "";
            if (clsGlobal.GetCookiesData("RoleId").ToString().Equals("16"))
            {
              removeButton = "<a onclick=\"RemoveEntry('" + dtWork.Rows[i]["Id"].ToString() + "')\" class=\"btn btn-sm btn-danger\" ><i class=\"fas fa-trash\" style='color: white;'></i></a>";
            }

            allRow += "<tr><td>" + dtWork.Rows[i]["StatusText"].ToString() + "</td><td>" + dtWork.Rows[i]["uploadbyname"].ToString() + "</td><td>" + dtWork.Rows[i]["UploadOn"].ToString() + "</td><td class=\"text-right py-0 align-middle\"><div class=\"btn-group btn-group-sm\"><a href=\"" + clsGlobal.UserImagePathWeb + dtWork.Rows[i]["DocName"].ToString() + "\" target=\"_blank\" class=\"btn btn-info\"><i class=\"fas fa-eye\"></i></a></div></td><td>" + removeButton + "</td></tr>";
          }

          rowWork.Text = allRow;
        }
        else
        {
          rowWork.Text = "";
        }

      }
      catch (Exception ex)
      {
        clsGlobal.DisplayToast(this, "Alert!", "Error:" + ex.Message.ToString(), "error");
      }
    }

    [WebMethod]
    public static string RemoveEntry(string Id)
    {
      string ret = "0";
      MySQLDB dbCon = new MySQLDB();
      try
      {
        #region RemoveStockEntry
        if (Id != null && Id != "")
        {
          ClsUser clsS = new ClsUser();
          
          ret = clsS.RemoveUserDcoument(Id).ToString();
        }
        #endregion

      }
      catch (Exception ex)
      {
        ret = "0";
      }
      finally
      {
      }
      return ret;
    }
  }
}
