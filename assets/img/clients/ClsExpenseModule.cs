using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
namespace Portal.SolarSmart
{
  public class ClsExpenseModule
  {
    MySQLDB dbCon = new MySQLDB();
    public string FileName = "ClsExpenseModule";

    public ClsExpenseModule()
    {
    }
    private DateTime _Doc;
    public DateTime Doc
    {
      get
      {
        return _Doc;
      }
      set
      {
        _Doc = value;
      }
    }
    private DateTime _Dom;
    public DateTime Dom
    {
      get
      {
        return _Dom;
      }
      set
      {
        _Dom = value;
      }
    }
    private string _Name;
    public string Name
    {
      get
      {
        return _Name;
      }
      set
      {
        _Name = value;
      }
    }
    private string _Category;
    public string Category
    {
      get
      {
        return _Category;
      }
      set
      {
        _Category = value;
      }
    }
    private string _Details;
    public string Details
    {
      get
      {
        return _Details;
      }
      set
      {
        _Details = value;
      }
    }
    private int _IsActive;
    public int IsActive
    {
      get
      {
        return _IsActive;
      }
      set
      {
        _IsActive = value;
      }
    }
    private int _Id;
    public int Id
    {
      get
      {
        return _Id;
      }
      set
      {
        _Id = value;
      }
    }
    private string _InquiryDate;
    public string InquiryDate
    {
      get
      {
        return _InquiryDate;
      }
      set
      {
        _InquiryDate = value;
      }
    }
    private string _Receipt;
    public string Receipt
    {
      get
      {
        return _Receipt;
      }
      set
      {
        _Receipt = value;
      }
    }
    private string _EstimatedCost;
    public string EstimatedCost
    {
      get
      {
        return _EstimatedCost;
      }
      set
      {
        _EstimatedCost = value;
      }
    }

    private int _InquiryType;
    public int InquiryType
    {
      get
      {
        return _InquiryType;
      }
      set
      {
        _InquiryType = value;
      }
    }
    private int _InquiryId;
    public int InquiryId
    {
      get
      {
        return _InquiryId;
      }
      set
      {
        _InquiryId = value;
      }
    }

    private int _HandledBy;
    public int HandledBy
    {
      get
      {
        return _HandledBy;
      }
      set
      {
        _HandledBy = value;
      }
    }
    private int _CompanyId;
    public int CompanyId
    {
      get
      {
        return _CompanyId;
      }
      set
      {
        _CompanyId = value;
      }
    }

    private string _ReminderDate;
    public string ReminderDate
    {
      get
      {
        return _ReminderDate;
      }
      set
      {
        _ReminderDate = value;
      }
    }
    private int _StatusId;
    public int StatusId
    {
      get
      {
        return _StatusId;
      }
      set
      {
        _StatusId = value;
      }
    }
    private string _Address;
    public string Address
    {
      get
      {
        return _Address;
      }
      set
      {
        _Address = value;
      }
    }
    private string _Remarks;
    public string Remarks
    {
      get
      {
        return _Remarks;
      }
      set
      {
        _Remarks = value;
      }
    }
    private string _CallBy;
    public string CallBy
    {
      get
      {
        return _CallBy;
      }
      set
      {
        _CallBy = value;
      }
    }
    private string _BankName;
    public string BankName
    {
      get
      {
        return _BankName;
      }
      set
      {
        _BankName = value;
      }
    }
    private string _BranchName;
    public string BranchName
    {
      get
      {
        return _BranchName;
      }
      set
      {
        _BranchName = value;
      }
    }
    private double _IFSCCode;
    public double IFSCCode
    {
      get
      {
        return _IFSCCode;
      }
      set
      {
        _IFSCCode = value;
      }
    }
    public int AddExpenseCategory()
    {
      try
      {

        string InsertRol = "Insert expense_category_master (CategoryName,IsActive,DOC,DOM) Values (?1,?2,NOW(),NOW())";
        string[] pram = { Name, IsActive.ToString() };
        int rest = dbCon.ExecuteQueryWithParams(InsertRol, pram);
        if (rest > 0)
        {
          UserTracking.UserActionTrack("Project ExpenseCategory Add");
          //UserTracking.UserActionTrack(Request, "Add ExpenseCategory");
          return 1;
        }
        else
        {
          return 0;
        }
      }
      catch (Exception)
      {
        return -1;

      }
      return 0;
    }
    public DataTable GetExpenseCategoryType()
    {
      DataTable dt = new DataTable();
      try
      {
        string getroL = "Select Id,CategoryName, case when IsActive=1 then 'Yes' else 'No' end as IsActive,DOC,DOM  from expense_category_master";
        dt = dbCon.GetData(getroL);
        return dt;
      }
      finally
      {
        dt.Dispose();
      }
    }
    public DataTable GetExpenseCategoryById()
    {
      DataTable dt = new DataTable();
      try
      {
        string getroL = "Select * from expense_category_master where Id=" + Id + "";
        dt = dbCon.GetData(getroL);
        return dt;
      }
      catch (Exception)
      {
        return dt;
      }
      finally
      {
        dt.Dispose();
      }
    }
    public bool UpdateExpenseCategory()
    {
      try
      {

        string updaterol = "Update expense_category_master set CategoryName=?1,IsActive=?2,DOM=NOW() Where Id=?3 ";
        string[] parm = { Name, IsActive.ToString(), Id.ToString() };
        int rest = dbCon.ExecuteQueryWithParams(updaterol, parm);
        if (rest > 0)
        {
          UserTracking.UserActionTrack("Project ExpenseCategory Update");
          //UserTracking.UserActionTrack(Request, "Update ExpenseCategory ");
          return true;
        }
        else
        {
          return false;
        }
      }
      catch (Exception ex)
      {
        return false;
      }
      return false;
    }
    public string DeleteExpenseCategory()
    {
      string result = "0";
      try
      {

        string[] pram = { Id.ToString() };
        string update = "Delete from expense_category_master Where Id=?1";
        //dbCon.OpenSQlConnection();
        int rest = dbCon.ExecuteQueryWithParams(update, pram);

        if (rest > 0)
        {
          UserTracking.UserActionTrack("Project ExpenseCategory Delete");
          result = "1";
        }
        else
        {
          result = "0";
        }

      }
      catch (Exception)
      {
        result = "0";
      }
      finally
      {
        dbCon.CloseSQlConnection();
        dbCon.disposeConnectionObj();
      }
      return result;
    }
    public string CheckExpenseCategoryExsist()
    {
      string Flag = "0";
      DataTable dt = new DataTable();
      try
      {
        string Str = " Select Id,CategoryName from expense_category_master where CategoryName='" + Name + "'";
        dt = dbCon.GetData(Str);
        if (dt != null && dt.Rows.Count > 0)
        {
          Flag = "1";
        }
        else
        {
          Flag = "-1";
        }
      }

      catch (Exception ee)
      {

      }
      return Flag;
    }
    public int AddExpenseModule()
    {
      //SqlConnection con = new SqlConnection();
      //con.ConnectionString = DbConnection.consString;
      try
      {
        string PaymentDate = dbCon.ConvertStringDate(_InquiryDate, '-').ToString("yyyy-MM-dd");
        int rest = 0;
        if (_InquiryType == 1) //Cash
        {
          string maint = "INSERT INTO expense_module(Name,Details,ExpenseCategory,ExpenseDate,Amount,PaymentMode,UploadReceipt,AddedBy,DOC,Dom)VALUES (?1,?2,?3,?4,?5,?6,?7,?8,NOW(),NOW())";
          string[] pram = { Name,Details,Category, PaymentDate,_EstimatedCost, _InquiryType.ToString(), Receipt ,_HandledBy.ToString() };
          rest = dbCon.ExecuteQueryWithParams(maint, pram);
        }
        else //Cheque
        {
          string ChequeDate = dbCon.ConvertStringDate(_ReminderDate, '-').ToString("yyyy-MM-dd");

          string maint = "INSERT INTO expense_module(Name,Details,ExpenseCategory,ExpenseDate,Amount,PaymentMode,UploadReceipt,AddedBy,DOC,Dom,ChequeDate,ChequeNo,BankName)VALUES (?1,?2,?3,?4,?5,?6,?7,?8,NOW(),NOW(),?9,?10,?11)";
          string[] pram = { Name, Details, Category, PaymentDate, _EstimatedCost, _InquiryType.ToString(), Receipt, _HandledBy.ToString(), ChequeDate, _StatusId.ToString(), _Address.ToString() };

          rest = dbCon.ExecuteQueryWithParams(maint, pram);
        }
        if (rest > 0)
        {
          UserTracking.UserActionTrack("Project ExpenseModule Add");
          return 1;
        }
        else
        {
          return 0;
        }
      }
      catch (Exception ex)
      {
        Logger.WriteCriticalLog(FileName + " :: 1379 :: AddExpenseModule() :: Error: " + ex.Message + " :: " + ex.StackTrace);
        return 0;
      }
      finally
      {
        dbCon.CloseSQlConnection();
        dbCon.disposeConnectionObj();
      }
    }
    public string DeleteExpenseModule()
    {
      string result = "0";
      try
      {

        string[] pram = {"1" ,Id.ToString() };
        string update = "update expense_module set IsDelete=?1 Where Id=?2";
        //dbCon.OpenSQlConnection();
        int rest = dbCon.ExecuteQueryWithParams(update, pram);

        if (rest > 0)
        {
          UserTracking.UserActionTrack("Project ExpenseModule Delete");
          result = "1";
        }
        else
        {
          result = "0";
        }

      }
      catch (Exception)
      {
        result = "0";
      }
      finally
      {
        dbCon.CloseSQlConnection();
        dbCon.disposeConnectionObj();
      }
      return result;
    }
    public DataTable GetExpenseModuleById()
    {
      DataTable dt = new DataTable();
      try
      {
        string getroL = "Select * from expense_module where Id=" + Id + "";
        dt = dbCon.GetData(getroL);
        return dt;
      }
      catch (Exception)
      {
        return dt;
      }
      finally
      {
        dt.Dispose();
      }
    }
    public bool UpdateExpenseModule()
    {
      try
      {
        string PaymentDate = dbCon.ConvertStringDate(_InquiryDate, '-').ToString("yyyy-MM-dd");
        int rest = 0;
        if (_InquiryType == 1) //Cash
        {
          string maint = "update expense_module set Name=?1,Details=?2,ExpenseCategory=?3,ExpenseDate=?4,Amount=?5,PaymentMode=?6,UploadReceipt=?7,AddedBy=?8,Dom=NOW() where id=?9";
          string[] pram = { Name, Details, Category, PaymentDate, _EstimatedCost, _InquiryType.ToString(), Receipt, _HandledBy.ToString(), Id.ToString() };
          rest = dbCon.ExecuteQueryWithParams(maint, pram);
        }
        else //Cheque
        {
          string ChequeDate = dbCon.ConvertStringDate(_ReminderDate, '-').ToString("yyyy-MM-dd");

          string maint = "update expense_module set Name=?1,Details=?2,ExpenseCategory=?3,ExpenseDate=?4,Amount=?5,PaymentMode=?6,UploadReceipt=?7,AddedBy=?8,Dom=NOW(),ChequeDate=?9,ChequeNo=?10,BankName=?11 where id=?12";
          string[] pram = { Name, Details, Category, PaymentDate, _EstimatedCost, _InquiryType.ToString(), Receipt, _HandledBy.ToString(), ChequeDate, _StatusId.ToString(), _Address.ToString(), Id.ToString() };

          rest = dbCon.ExecuteQueryWithParams(maint, pram);
        }
        if (rest > 0)
        {
          UserTracking.UserActionTrack("Project ExpenseModule Update");
          return true;
        }
        else
        {
          return false;
        }
      }
      catch (Exception ex)
      {
        Logger.WriteCriticalLog(FileName + " :: 1379 :: UpdateExpenseModule() :: Error: " + ex.Message + " :: " + ex.StackTrace);
        return false;
      }
      finally
      {
        dbCon.CloseSQlConnection();
        dbCon.disposeConnectionObj();
      }
      return false;
    }



    public int AddBankAccountEntry()
    {
      try
      {
        string ChequeDate = dbCon.ConvertStringDate(_ReminderDate, '-').ToString("yyyy-MM-dd");
        string PaymentDate = dbCon.ConvertStringDate(_InquiryDate, '-').ToString("yyyy-MM-dd");
        string InsertRol = "Insert bank_account_entries (PaymentDate,Amount,ChequeNo,ChequeDate,BankName,BranchName,IFSCcode,ChequePhoto,Notes,ReMarks,ReceivedBy,DOC,DOM) Values (?1,?2,?3,?4,?5,?6,?7,?8,?9,?10,?11,NOW(),NOW())";
        string[] pram = { PaymentDate, EstimatedCost, StatusId.ToString(), ChequeDate, BankName,BranchName,IFSCCode.ToString(),Receipt,Details,Remarks, CallBy };
        int rest = dbCon.ExecuteQueryWithParams(InsertRol, pram);
        if (rest > 0)
        {
          UserTracking.UserActionTrack("Project BankAccountEntry Add");
          //UserTracking.UserActionTrack(Request, "Add ExpenseCategory");
          return 1;
        }
        else
        {

        }
        {
          return 0;
        }
      }
      catch (Exception)
      {
        return -1;

      }
      return 0;
    }
    public DataTable GetBankAccountEntryType()
    {
      DataTable dt = new DataTable();
      try
      {
        string getroL = "SELECT id,PaymentDate as ReceivedDate,ReceivedBy,Amount,BankName,BranchName,ChequeDate,ChequeNo,Notes,ReMarks FROM bank_account_entries where IsDelete=0;";
        dt = dbCon.GetData(getroL);
        return dt;
      }
      finally
      {
        dt.Dispose();
      }
    }
    public DataTable GetBankAccountEntryById()
    {
      DataTable dt = new DataTable();
      try
      {
        string getroL = "Select * from bank_account_entries where IsDelete=0 And Id=" + Id + "";
        dt = dbCon.GetData(getroL);
        return dt;
      }
      catch (Exception)
      {
        return dt;
      }
      finally
      {
        dt.Dispose();
      }
    }
    public bool UpdateBankAccountEntry()
    {
      try
      {
        string PaymentDate = dbCon.ConvertStringDate(_InquiryDate, '-').ToString("yyyy-MM-dd");
        string updaterol = "update bank_account_entries  set PaymentDate=?1,Amount=?2,ChequeNo=?3,ChequeDate=?4,BankName=?5,BranchName=?6,IFSCcod=?7,ChequePhoto=?8,Notes=?9,ReMarks=?10,ReceivedBy=?11,DOM=NOW() Where Id=?12 ";
        string[] parm = { PaymentDate, EstimatedCost, StatusId.ToString(), ReminderDate, BankName, BranchName, IFSCCode.ToString(), Receipt, Details, Remarks, CallBy,Id.ToString() };
        int rest = dbCon.ExecuteQueryWithParams(updaterol, parm);
        if (rest > 0)
        {
          UserTracking.UserActionTrack("Project BankAccountEntry Update");
          //UserTracking.UserActionTrack(Request, "Update ExpenseCategory ");
          return true;
        }
        else
        {
          return false;
        }
      }
      catch (Exception ex)
      {
        return false;
      }
      return false;
    }
    public string DeleteBankAccountEntry()
    {
      string result = "0";
      try
      {
        string[] pram = { Id.ToString() };
        string update = "update bank_account_entries set IsDelete=1 Where Id=?1";
        //dbCon.OpenSQlConnection();
        int rest = dbCon.ExecuteQueryWithParams(update, pram);

        if (rest > 0)
        {
          UserTracking.UserActionTrack("Project ExpenseCategory Delete");
          result = "1";
        }
        else
        {
          result = "0";
        }

      }
      catch (Exception)
      {
        result = "0";
      }
      finally
      {
        dbCon.CloseSQlConnection();
        dbCon.disposeConnectionObj();
      }
      return result;
    }
  }
}
