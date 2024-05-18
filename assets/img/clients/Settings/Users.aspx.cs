using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Portal.SolarSmart.ModelCompany;

namespace Portal.SolarSmart.Settings
{
  public partial class Users : System.Web.UI.Page
  {
    MySQLDB dbCon = new MySQLDB();
    ClsUser cls = new ClsUser();
    ClsRole cls_role = new ClsRole();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        if (!IsPostBack)
        {
          ddlrole = dbCon.FillCombo(ddlrole, "select * from role where isactive=1 order by name", "name", "id");

          ddlManager = dbCon.FillCombo(ddlManager, "SELECT Id, concat(Name,' (',Mobile,')') as NameMobile FROM user where IsActive = 1 order by name;", "NameMobile", "Id");

          DataTable dtBlood = new DataTable();
          dtBlood.Columns.Add("Id");
          dtBlood.Columns.Add("Name");

          dtBlood.Rows.Add("0", "-- Select --");
          dtBlood.Rows.Add("-1", "NA");
          dtBlood.Rows.Add("1", "A+");
          dtBlood.Rows.Add("2", "A-");
          dtBlood.Rows.Add("3", "B+");
          dtBlood.Rows.Add("4", "B-");
          dtBlood.Rows.Add("5", "AB+");
          dtBlood.Rows.Add("6", "AB-");
          dtBlood.Rows.Add("7", "O+");
          dtBlood.Rows.Add("8", "O-");

          ddlBlood.DataSource = dtBlood;
          ddlBlood.DataTextField = "Name";
          ddlBlood.DataValueField = "Name";
          ddlBlood.DataBind();

          ddlBlood.SelectedValue = "-1";

          if (Request.QueryString.AllKeys.Contains("Eid") && Request.QueryString["Eid"].ToString() != null)
          {
            txtpwd.ReadOnly = true;
            lblupdatepass.Visible = true;
            btnadd.Text = "Update User";
            GetDataById();
          }
        }
        BindState();
        //GetDataById();
        BindUserState();
      }
      catch (Exception E)
      {
        ltrerr.Text = E.Message;
      }
    }

    public void BindState()
    {
      try
      {
        DataTable dtdata = cls_role.GetStateList(true);
        if (dtdata.Rows.Count > 0)
        {
          grd.Caption = "State List: " + dtdata.Rows.Count; ;
          grd.DataSource = dtdata;
          grd.DataBind();
        }
        else
        {
          dtdata = new DataTable();
          grd.Caption = "State List: " + dtdata.Rows.Count; ;
          grd.DataSource = dtdata;
          grd.DataBind();
          ltrerr.Text = "No Pages are found.";
        }
      }
      catch (Exception ex)
      {
        ltrerr.Text = ex.Message;
      }
    }


    public void GetDataById()
    {
      try
      {

        int CompanyId = 0;
        int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);
        cls.CompanyId = CompanyId;
        if (Request.QueryString.AllKeys.Contains("Eid") && Request.QueryString["Eid"].ToString() != null)
        {
          cls.Id = Convert.ToInt32(Request.QueryString["Eid"].ToString());
          dt = cls.GetUserById();
          if (dt.Rows.Count > 0)
          {

            txtname.Text = dt.Rows[0]["Name"].ToString();
            if (dt.Rows[0]["Isactive"].ToString().ToLower() == "1")
            {
              chkactive.Checked = true;
            }
            else
            {
              chkactive.Checked = false;
            }
            if (dt.Rows[0]["IsTwoFactAuth"].ToString().ToLower() == "1")
            {
              chkTwoFact.Checked = true;
            }
            else
            {
              chkTwoFact.Checked = false;
            }
            //txtusername.Text = dt.Rows[0]["username"].ToString();
            //txtpwd.Text = dt.Rows[0]["Password"].ToString();
            txtmobile.Text = dt.Rows[0]["Mobile"].ToString();
            txtClickToCallNumber.Text = dt.Rows[0]["Agent_Number"].ToString();
            ddlrole.SelectedValue = dt.Rows[0]["RoleId"].ToString();
            txtadd.Text = dt.Rows[0]["Address"].ToString();
            txtemail.Text = dt.Rows[0]["email"].ToString();
            txtDate1.Text = dt.Rows[0]["DisplayDOB"].ToString();
            txtDate1.Text = dt.Rows[0]["DisplayDOB"].ToString();
            ddlBlood.Text = dt.Rows[0]["blood"].ToString();

            txtCommission.Text = dt.Rows[0]["Commission"].ToString();
            if (!dt.Rows[0]["Commission"].ToString().Equals("0"))
            {
              txtCommission.Enabled = false;
            }

            if (!String.IsNullOrEmpty(dt.Rows[0]["UserPhoto"].ToString()))
            {
              imgproduct.ImageUrl = clsGlobal.UserImagePathWeb + dt.Rows[0]["UserPhoto"].ToString();
            }

            if (!String.IsNullOrEmpty(dt.Rows[0]["ManagerId"].ToString()) && !dt.Rows[0]["ManagerId"].ToString().Equals("0"))
            {
              ddlManager.SelectedValue = dt.Rows[0]["ManagerId"].ToString();
            }
            else
            {
              ddlManager.SelectedValue = "-1";
            }

            BindUserState();
          }
          else
          {
            txtname.Text = "";
            txtmobile.Text = "";
            chkactive.Checked = false;


            clsGlobal.DisplayToast(this, "Alert!", "User data not found. Please try again.", "error");
            //.else.ltrerr.Text = "<span style=\"margin-left:4%;margin-bottom:0%;margin-top:2%;color: red\"><i class=\"fa fa-exclamation\" style=\"margin-right:5px\"></i> User data not found. Please try again.</span><br/>";
          }
        }
      }
      catch (Exception E)
      {
        ltrerr.Text = "<span style=\"margin-left:4%;margin-bottom:0%;margin-top:2%;color: red\"><i class=\"fa fa-exclamation\" style=\"margin-right:5px\"></i> Error: 95 : " + E.Message + "</span><br/>";
      }
      finally
      {
        dt.Dispose();
      }
    }

    public void BindUserState()
    {
      try
      {
        int CompanyId = 0;
        int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);
        cls.CompanyId = CompanyId;
        cls.Id = Convert.ToInt32(Request.QueryString["Eid"].ToString());
        if (Request.QueryString.AllKeys.Contains("Eid") && Request.QueryString["Eid"].ToString() != null)
        {
          dt = cls.GetUserStateList();
          if (dt.Rows.Count > 0)
          {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
              foreach (GridViewRow row in grd.Rows)
              {
                Label lbl = (Label)row.FindControl("lblid");
                if (lbl.Text == dt.Rows[i]["StateId"].ToString())
                {
                  CheckBox chk = (CheckBox)row.FindControl("chkRow");
                  chk.Checked = true;
                  break;
                }
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        ltrerr.Text = ex.Message;
      }
    }

    protected  void btnadd_Click(object sender, EventArgs e)
    {
      try
      {
        ltrerr.Text = "";
        //ltrmsg.Text = "";

        int CompanyId = 0;
        int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);
        cls.CompanyId = CompanyId;

        if (txtname.Text.Trim() != "" && txtmobile.Text.Trim() != "" && txtemail.Text.Trim() != "" && ddlrole.SelectedIndex > 0 && txtadd.Text.Trim() != "" && txtDate1.Text.Trim() != "")
        {
          string ids = string.Empty;
          foreach (GridViewRow gvrow in grd.Rows)
          {
            CheckBox chk = (CheckBox)gvrow.FindControl("chkRow");
            if (chk != null & chk.Checked)
            {
              Label lbl = (Label)gvrow.FindControl("lblid");
              ids += lbl.Text + ",";
            }
          }
          ids = ids.TrimEnd(','); 
          if (string.IsNullOrEmpty(ids))
          {
            clsGlobal.DisplayToast(this, "Error!", "Please select state for particular user.!", "error");
            return;
          }

          cls.StateIds = ids;
          cls.Name = txtname.Text.Trim();
          cls.Username = txtemail.Text.Trim();
          cls.Password = txtpwd.Text.Trim();
          if (chkactive.Checked)
          {
            cls.IsActive = 1;
          }
          else
          {
            cls.IsActive = 0;
          }
          if (chkTwoFact.Checked)
          {
            cls.TwoFactAuth = 1;
          }
          else
          {
            cls.TwoFactAuth = 0;
          }

          if (!ddlManager.SelectedValue.Equals("-1"))
          {
            cls.ManagerId = ddlManager.SelectedValue;
          }
          else
          {
            cls.ManagerId = "0";
          }

          cls.Dom = dbCon.getindiantime();
          cls.Mobile = txtmobile.Text.Trim();
          cls.RoleId = Convert.ToInt32(ddlrole.SelectedValue.ToString());
          cls.email = txtemail.Text.Trim();
          cls.Blood = ddlBlood.SelectedItem.Text;
          cls.DOB = txtDate1.Text.Trim();
          cls.Address = txtadd.Text.Trim();
          cls.Agent_Number = txtClickToCallNumber.Text.Trim();

          double Commission = 0;
          double.TryParse(txtCommission.Text, out Commission);
          cls.Commission = Commission;

          string employeePhoto = "";
          if (FileUploadControl.HasFile)
          {
            string ext = System.IO.Path.GetExtension(FileUploadControl.PostedFile.FileName);
            string[] validFileTypes = { "png", "jpg", "jpeg" };
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
              ltrerr.Text = "<span style=\"margin-left:4%;margin-bottom:0%;margin-top:2%;color: red\"><i class=\"fa fa-exclamation\" style=\"margin-right:5px\"></i> Invalid File. Please upload valid Image file (.png, .jpg, .jpeg). </span><br/>";
              return;
            }
            else
            {

              // byte[] image = File.ReadAllBytes(FileUploadControl.FileName);

              Stream fs = FileUploadControl.PostedFile.InputStream;
              BinaryReader br = new BinaryReader(fs);
              //Byte[] image = br.ReadBytes((Int32)fs.Length);
              Byte[] image = null;

              string exten = System.IO.Path.GetExtension(FileUploadControl.FileName);
              string name = System.IO.Path.GetFileName(FileUploadControl.FileName);

              string ext1 = System.IO.Path.GetExtension(FileUploadControl.FileName);
              ext1 = ext1.Replace(".", "image/");

              employeePhoto = DateTime.Now.Ticks + exten;

              string path = clsGlobal.UserImageLocal + employeePhoto;
              FileUploadControl.SaveAs(path);
            }
          }

          cls.UserPhoto = employeePhoto;

          if (Request.QueryString.AllKeys.Contains("Eid") && Request.QueryString["Eid"].ToString() != null)
          {
            cls.Id = Convert.ToInt32(Request.QueryString["Eid"].ToString());
            if (cls.CheckUserEmailMobile(txtemail.Text.Trim(), txtmobile.Text.Trim(), Request.QueryString["Eid"].ToString()))
            {
              if (cls.UpdateUser())
              {
                clsGlobal.DisplayToast(this, "Updated!", "User Details Update Successfully.", "success", "/Settings/ContactList");
              }
              else
              {
                clsGlobal.DisplayToast(this, "Error!", "User Details Not Updated, Please Try After Sometime.", "error");
              }
            
            }
            else
            {
              clsGlobal.DisplayToast(this, "Error!", "Email id or mobile number already exist!", "error");
            }

            //Response.Redirect("~/Settings/Users");
          }
          else
          {
            if (String.IsNullOrEmpty(txtpwd.Text.Trim()))
            {
              clsGlobal.DisplayToast(this, "Alert!", "Please fill all data.", "error");
              return;
            }
            cls.Doc = dbCon.getindiantime();

            if (cls.CheckUserEmailMobile(txtemail.Text.Trim(), txtmobile.Text.Trim()))
            {

              clsCompany company = new clsCompany();
              CompanyPlanDetails companyPlan = company.GetComapnyPlanDetails(CompanyId);
              if (companyPlan != null && companyPlan.LeftUserCount > 0)
              {
                int rest = cls.AddUser();
                if (rest > 0)
                {
                  clsGlobal.DisplayToast(this, "Added!", "User Details Added Successfully.", "success", "/Settings/ContactList");
                }
                else
                {
                  clsGlobal.DisplayToast(this, "Error!", "User Details Not Added, Please Try After Sometime.", "error");
                }
                //GetData();
                //txtname.Text = "";
                //txtmobile.Text = "";
                ////txtusername.Text = "";
                //txtpwd.Text = "";
                //txtadd.Text = "";
                //txtemail.Text = "";
                //txtDate1.Text = "";
                //chkactive.Checked = false;
                //ddlrole.SelectedIndex = 0;
                //ddlBlood.SelectedIndex = 0;
              }
              else
              {
                clsGlobal.DisplayToast(this, "Error!", "User limit exceeded! Please check your Plan details.", "error");
                ltrerr.Text = "<span style=\"margin-left:4%;margin-bottom:0%;margin-top:2%;color: red\"><i class=\"fa fa-exclamation\" style=\"margin-right:5px\"></i> Error! User limit exceeded! Please check your Plan detail.</span><br/>";
              }
            }
            else
            {
              clsGlobal.DisplayToast(this, "Error!", "Email id or mobile number already exist!", "error");
              ltrerr.Text = "<span style=\"margin-left:4%;margin-bottom:0%;margin-top:2%;color: red\"><i class=\"fa fa-exclamation\" style=\"margin-right:5px\"></i> Error! Email id or mobile number already exist!</span><br/>";
            }

            //ltrmsg.Text = "User added successfully.";
          }
        }
        else
        {
          //ltrerr.Text = "<span style=\"margin-left:4%;margin-bottom:0%;margin-top:2%;color: red\"><i class=\"fa fa-exclamation\" style=\"margin-right:5px\"></i> Please fill all data.</span><br/>";
          clsGlobal.DisplayToast(this, "Alert!", "Please fill all data.", "error");
        }
      }
      catch (Exception ex)
      {
        Logger.WriteCriticalLog("User.aspx :: 158 :: btnadd_Click() :: Error: " + ex.Message + " :: " + ex.StackTrace);
        ltrerr.Text = "<span style=\"margin-left:4%;margin-bottom:0%;margin-top:2%;color: red\"><i class=\"fa fa-exclamation\" style=\"margin-right:5px\"></i> Error: 158 : " + ex.Message + " :: " + ex.StackTrace + "</span><br/>";
      }
    }
    protected void FileUploadControl_Init(object sender, EventArgs e)
    {
      try
      {
        if (FileUploadControl.HasFile)
        {
          imgproduct.ImageUrl = FileUploadControl.FileName;
        }
      }
      catch (Exception ex)
      {
        ltrerr.Text = "Line : 324 : " + ex.Message;
      }
    }
    protected void FileUploadControl_DataBinding(object sender, EventArgs e)
    {
      try
      {
        if (FileUploadControl.HasFile)
        {
          imgproduct.ImageUrl = FileUploadControl.FileName;
        }
      }
      catch (Exception ex)
      {
        ltrerr.Text = "Line : 324 : " + ex.Message;
      }
    }
    protected void FileUploadControl_Load(object sender, EventArgs e)
    {
      try
      {
        if (FileUploadControl.HasFile)
        {
          imgproduct.ImageUrl = FileUploadControl.FileName;
        }
      }
      catch (Exception ex)
      {
        ltrerr.Text = "Line : 324 : " + ex.Message;
      }
    }
  }
}
