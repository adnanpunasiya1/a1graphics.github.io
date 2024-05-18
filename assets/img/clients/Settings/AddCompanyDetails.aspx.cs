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
  public partial class AddCompanyDetails : System.Web.UI.Page
  {
    MySQLDB dbCon = new MySQLDB();
    clsCompany cls = new clsCompany();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        if (!IsPostBack)
        {


          GetDataById();

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
        int CompanyId = 0;
        int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);

        dt = cls.GetComapnyDetails(CompanyId.ToString());

        if (dt.Rows.Count > 0)
        {
          txtname.Text = dt.Rows[0]["CompanyName"].ToString();
          txtadd.Text = dt.Rows[0]["CompanyAddress"].ToString();
          txtCity.Text = dt.Rows[0]["CompanyCity"].ToString();
          txtState.Text = dt.Rows[0]["CompanyState"].ToString();
          txtemail.Text = dt.Rows[0]["CompanyEmailId"].ToString();
          txtmobile.Text = dt.Rows[0]["CompanyContactNumber"].ToString();
          txtWebsite.Text = dt.Rows[0]["Website"].ToString();

          txtGSTNo.Text = dt.Rows[0]["GSTNo"].ToString();
          txtCompanyBankName.Text = dt.Rows[0]["CompanyBankName"].ToString();
          txtCompanyBankAccountName.Text = dt.Rows[0]["CompanyBankAccountName"].ToString();
          txtCompanyBankAccountNo.Text = dt.Rows[0]["CompanyBankAccountNo"].ToString();
          txtCompanyBankIFSCCode.Text = dt.Rows[0]["CompanyBankIFSCCode"].ToString();
          txtCompanyBankBranch.Text = dt.Rows[0]["CompanyBankBranch"].ToString();

          txtOwnerName.Text = dt.Rows[0]["OwnerName"].ToString();
          txtOwnerMobile.Text = dt.Rows[0]["OwnerMobileNumber"].ToString();
          txtOwnerEmail.Text = dt.Rows[0]["EmailId"].ToString();

          if (!String.IsNullOrEmpty(dt.Rows[0]["CompanyLogo"].ToString()))
          {
            hnd_Logo.Value = "1";
          }
          else
          {
            hnd_Logo.Value = "0";
          }

          if (!String.IsNullOrEmpty(dt.Rows[0]["Letterhead_Header"].ToString()))
          {
            hnd_Header.Value = "1";
          }
          else
          {
            hnd_Header.Value = "0";
          }

          if (!String.IsNullOrEmpty(dt.Rows[0]["Letterhead_Footer"].ToString()))
          {
            hnd_Footer.Value = "1";
          }
          else
          {
            hnd_Footer.Value = "0";
          }

          if (!String.IsNullOrEmpty(dt.Rows[0]["Letterhead_Watermark"].ToString()))
          {
            hnd_Watermark.Value = "1";
          }
          else
          {
            hnd_Watermark.Value = "0";
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
    protected void btnadd_Click(object sender, EventArgs e)
    {
      try
      {
        ltrerr.Text = "";
        
        int CompanyId = 0;
        int.TryParse(clsGlobal.GetCookiesData("CompanyId"), out CompanyId);

        CompanyDetails company = new CompanyDetails();
        company.CompanyID = CompanyId;

        if (txtname.Text.Trim() != "" && txtmobile.Text.Trim() != "" && txtemail.Text.Trim() != "" && txtadd.Text.Trim() != "" && txtCity.Text.Trim() != "" && txtState.Text.Trim() != "" && txtOwnerName.Text.Trim() != "" && txtOwnerEmail.Text.Trim() != "" && txtOwnerMobile.Text.Trim() != "" && (fuLogo.HasFile || hnd_Logo.Value.Equals("1")))
        {
          string CompanyLogoName = "";
          string Letterhead_HeaderName = "";
          string Letterhead_FooterName = "";
          string Letterhead_WatermarkName = "";



          if (fuLogo.HasFile)
          {
            string ext = System.IO.Path.GetExtension(fuLogo.PostedFile.FileName);
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

              Stream fs = fuLogo.PostedFile.InputStream;
              BinaryReader br = new BinaryReader(fs);
              //Byte[] image = br.ReadBytes((Int32)fs.Length);
              Byte[] image = null;

              string exten = System.IO.Path.GetExtension(fuLogo.FileName);
              string name = System.IO.Path.GetFileName(fuLogo.FileName);

              string ext1 = System.IO.Path.GetExtension(fuLogo.FileName);
              ext1 = ext1.Replace(".", "image/");

              CompanyLogoName = DateTime.Now.Ticks + exten;

              string path = clsGlobal.WorkLogoLocal + CompanyLogoName;
              fuLogo.SaveAs(path);
            }
          }


          if (fuHeader.HasFile)
          {
            string ext = System.IO.Path.GetExtension(fuHeader.PostedFile.FileName);
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

              Stream fs = fuHeader.PostedFile.InputStream;
              BinaryReader br = new BinaryReader(fs);
              //Byte[] image = br.ReadBytes((Int32)fs.Length);
              Byte[] image = null;

              string exten = System.IO.Path.GetExtension(fuHeader.FileName);
              string name = System.IO.Path.GetFileName(fuHeader.FileName);

              string ext1 = System.IO.Path.GetExtension(fuHeader.FileName);
              ext1 = ext1.Replace(".", "image/");

              Letterhead_HeaderName = DateTime.Now.Ticks + exten;

              string path = clsGlobal.WorkLogoLocal + Letterhead_HeaderName;
              fuHeader.SaveAs(path);
            }
          }


          if (fuFooter.HasFile)
          {
            string ext = System.IO.Path.GetExtension(fuFooter.PostedFile.FileName);
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

              Stream fs = fuFooter.PostedFile.InputStream;
              BinaryReader br = new BinaryReader(fs);
              //Byte[] image = br.ReadBytes((Int32)fs.Length);
              Byte[] image = null;

              string exten = System.IO.Path.GetExtension(fuFooter.FileName);
              string name = System.IO.Path.GetFileName(fuFooter.FileName);

              string ext1 = System.IO.Path.GetExtension(fuFooter.FileName);
              ext1 = ext1.Replace(".", "image/");

              Letterhead_FooterName = DateTime.Now.Ticks + exten;

              string path = clsGlobal.WorkLogoLocal + Letterhead_FooterName;
              fuFooter.SaveAs(path);
            }
          }


          if (fuWatermark.HasFile)
          {
            string ext = System.IO.Path.GetExtension(fuWatermark.PostedFile.FileName);
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

              Stream fs = fuWatermark.PostedFile.InputStream;
              BinaryReader br = new BinaryReader(fs);
              //Byte[] image = br.ReadBytes((Int32)fs.Length);
              Byte[] image = null;

              string exten = System.IO.Path.GetExtension(fuWatermark.FileName);
              string name = System.IO.Path.GetFileName(fuWatermark.FileName);

              string ext1 = System.IO.Path.GetExtension(fuWatermark.FileName);
              ext1 = ext1.Replace(".", "image/");

              Letterhead_WatermarkName = DateTime.Now.Ticks + exten;

              string path = clsGlobal.WorkLogoLocal + Letterhead_WatermarkName;
              fuWatermark.SaveAs(path);
            }
          }


          company.CompanyName = txtname.Text.Trim();
          company.CompanyAddress = txtadd.Text.Trim();
          company.CompanyCity = txtCity.Text.Trim();
          company.CompanyState = txtState.Text.Trim();
          company.CompanyEmailId = txtemail.Text.Trim();
          company.CompanyContactNumber = txtmobile.Text.Trim();
          company.Website = txtWebsite.Text.Trim();
          company.GSTNo = txtGSTNo.Text.Trim();
          company.CompanyBankName = txtCompanyBankName.Text.Trim();
          company.CompanyBankAccountName = txtCompanyBankAccountName.Text.Trim();
          company.CompanyBankAccountNo = txtCompanyBankAccountNo.Text.Trim();
          company.CompanyBankIFSCCode = txtCompanyBankIFSCCode.Text.Trim();
          company.CompanyBankBranch = txtCompanyBankBranch.Text.Trim();
          company.OwnerName = txtOwnerName.Text.Trim();
          company.EmailId = txtOwnerEmail.Text.Trim();
          company.Mobile = txtOwnerMobile.Text.Trim();
          company.CompanyLogo = CompanyLogoName;
          company.Letterhead_Header = Letterhead_HeaderName;
          company.Letterhead_Footer = Letterhead_FooterName;
          company.Letterhead_Watermark = Letterhead_WatermarkName;

          int rest = cls.UpdateCompanyDetails(company);
          if (rest > 0)
          {
            clsGlobal.DisplayToast(this, "Added!", "Company Details Added Successfully.", "success", "/Settings/CompanyProfile");
          }
          else
          {
            clsGlobal.DisplayToast(this, "Error!", "User Details Not Added, Please Try After Sometime.", "error");
          }
        }
      }
      catch (Exception ex)
      {
        ltrerr.Text = "<span style=\"margin-left:4%;margin-bottom:0%;margin-top:2%;color: red\"><i class=\"fa fa-exclamation\" style=\"margin-right:5px\"></i> Error: 158 : " + ex.Message + "</span><br/>";
      }
    }
    
  }
}
