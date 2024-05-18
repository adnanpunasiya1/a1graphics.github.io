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
  public partial class ExpendeCategoryMaster1 : System.Web.UI.Page
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

            chkactive.Enabled = true;
            btnadd.Text = "Update ExpenseCategory";
            GetDataById();
          }
          else if (Request.QueryString.AllKeys.Contains("Did") && Request.QueryString["Did"].ToString() != null)
          {
            string Flag = "";
            cls.CompanyId = CompanyId;
            cls.Id = Convert.ToInt32(Request.QueryString["Did"].ToString());
            Flag = cls.DeleteExpenseCategory();
            if (Flag == "-1")
            {
              clsGlobal.DisplayToast(this, "Alert!", "Already exsist.", "error");
            }
            else if (Flag == "1")
            {
              clsGlobal.DisplayToast(this, "Updated!", "ExpenseCategory updated successfully .", "success", "/Settings/ExpenseCategoryMaster");
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
        dt = cls.GetExpenseCategoryType();
        if (dt.Rows.Count > 0)
        {
          string allRow = "";
          for (int i = 0; i < dt.Rows.Count; i++)
          {
            allRow += "<tr><td>" + dt.Rows[i]["Id"].ToString() + "</td><td>" + dt.Rows[i]["CategoryName"].ToString() + "</td><td>" + dt.Rows[i]["IsActive"].ToString() + "</td><td>" + dt.Rows[i]["DOC"].ToString() + "</td><td><a href='/Settings/ExpenseCategoryMaster?Eid=" + dt.Rows[i]["Id"].ToString() + "'><i class='fas fa-edit' style=margine-right:8px;'></i></a></td><td><a href='/Settings/ExpenseCategoryMaster?Did=" + dt.Rows[i]["Id"].ToString() + "'><i class='far fa-trash-alt' style=margine-right:8px;'></i></a></td></tr>";
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
        dt = cls.GetExpenseCategoryById();
        if (dt.Rows.Count > 0)
        {
          txtname.Text = dt.Rows[0]["CategoryName"].ToString();
          if (dt.Rows[0]["IsActive"].ToString().ToLower() == "1")
          {
            chkactive.Checked = true;
          }
          else
          {
            chkactive.Checked = false;
          }
        }
        else
        {
          txtname.Text = "";
          chkactive.Checked = false;
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
        if (txtname.Text.Trim() != "")
        {
          cls.Name = txtname.Text.Trim();
          if (chkactive.Checked)
          {
            cls.IsActive = 1;
          }
          else
          {
            cls.IsActive = 0;
          }

          cls.Dom = dbc.getindiantime();

          if (Request.QueryString.AllKeys.Contains("Eid") && Request.QueryString["Eid"].ToString() != null)
          {
            cls.Id = Convert.ToInt32(Request.QueryString["Eid"].ToString());
            if (cls.UpdateExpenseCategory())
            {
              Clear();
              GetData();
              clsGlobal.DisplayToast(this, "Updated!", "ExpenseCategory updated successfully.", "success", "/Settings/ExpenseCategoryMaster");
            }
            else
            {
              clsGlobal.DisplayToast(this, "Alert!", "Something went wrong.", "error");
            }
          }
          else
          {
            cls.Doc = dbc.getindiantime();
            int rest = cls.AddExpenseCategory();
            if (rest > 0)
            {
              GetData();
              Clear();
              clsGlobal.DisplayToast(this, "Added!", "ExpenseCategory added successfully.", "success", "/Settings/ExpenseCategoryMaster");

            }
            else
            {
              clsGlobal.DisplayToast(this, "Alert!", "Something went wrong.", "error");
            }

          }
        }
        else
        {
          ltrerr.Text = "Enter name of ExpenseCategory.";
        }
      }
      catch (Exception ex)
      {
        ltrerr.Text = ex.Message;
      }
    }

    [WebMethod]
    public static string CheckSchemeName(string ExpenseCategoryName)
    {
      string flag = "0";
      MySQLDB dbc = new MySQLDB();
      ClsRole cls = new ClsRole();
      try
      {

        cls.Name = ExpenseCategoryName;
        flag = cls.CheckExpenseCategoryExsist();
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
        txtname.Text = "";
        chkactive.Checked = false;
      }
      catch (Exception ee)
      {
      }
    }
  }
}
