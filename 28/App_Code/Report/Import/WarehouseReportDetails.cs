using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
/// <summary>
/// Summary description for Class1
/// </summary>
public class WareHouseReportDetails
{

    #region public string

    public DataSet ds = new DataSet();

    public int result;
    private bool result1;
    //private string _JOBNO;
    private string _Ename;
    private string _Workingperiod;

    public string _JOBNO, _INVOICE_SLNO, _INVOICE_NO, _ITEM_SLNO, _ITEM_DESCRIPTION;
    public string _ITEM_QTY, _ITEM_QTY_CODE, _ITEM_UNIT_PRICE, _ITEM_UNIT_CODE;
    public string _ITEM_TOTAL_AMOUNT, _ITEM_AMOUNT_CODE, _BAL_QTY;

    public string _JOBDATE, _BE_TYPE, _CUSTOMS_HOUSE, _Importer_Name, _BE_NO, _BE_DATE, _IMPORTER_NAME;

    #region ITEM_DETAILS
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string ITEM_DESCRIPTION { get { return _ITEM_DESCRIPTION; } set { _ITEM_DESCRIPTION = value; } }
    public string ITEM_QTY { get { return _ITEM_QTY; } set { _ITEM_QTY = value; } }
    public string ITEM_QTY_CODE { get { return _ITEM_QTY_CODE; } set { _ITEM_QTY_CODE = value; } }
    public string ITEM_UNIT_PRICE { get { return _ITEM_UNIT_PRICE; } set { _ITEM_UNIT_PRICE = value; } }
    public string ITEM_UNIT_CODE { get { return _ITEM_UNIT_CODE; } set { _ITEM_UNIT_CODE = value; } }
    public string ITEM_TOTAL_AMOUNT { get { return _ITEM_TOTAL_AMOUNT; } set { _ITEM_TOTAL_AMOUNT = value; } }
    public string ITEM_AMOUNT_CODE { get { return _ITEM_AMOUNT_CODE; } set { _ITEM_AMOUNT_CODE = value; } }
    public string BAL_QTY { get { return _BAL_QTY; } set { _BAL_QTY = value; } }
    public string BE_NO { get { return _BE_NO; } set { _BE_NO = value; } }
    public string BE_DATE { get { return _BE_DATE; } set { _BE_DATE = value; } }


    public string JOBDATE { get { return _JOBDATE; } set { _JOBDATE = value; } }
    public string BE_TYPE { get { return _BE_TYPE; } set { _BE_TYPE = value; } }
    public string CUSTOMS_HOUSE { get { return _CUSTOMS_HOUSE; } set { _CUSTOMS_HOUSE = value; } }
    public string Importer_Name { get { return _Importer_Name; } set { _Importer_Name = value; } }
    public string IMPORTER_NAME { get { return _IMPORTER_NAME; } set { _IMPORTER_NAME = value; } }

    
    #endregion 

    #region WareHouse

    public string _EXBOND_INBOND_BE_NO, _EXBOND_INBOND_BE_DATE, _EXBOND_BOND_NO, _EXBOND_BOND_DATE;
    public string _EXBOND_WAREHOUSE_CUSTOMS, _EXBOND_WAREHOUSE_CUSTOMS_CODE, _EXBOND_NOOFPACKAGE, _EXBOND_NOOFPACKAGE_UNITCODE;
    //public string _EXBOND_GROSS_WEIGHT, _EXBOND_GROSS_WEIGHT_UNITCODE, _EXBOND_DIRECT_EXBONDING;



    public string EXBOND_INBOND_BE_NO { get { return _EXBOND_INBOND_BE_NO; } set { _EXBOND_INBOND_BE_NO = value; } }
    public string EXBOND_INBOND_BE_DATE { get { return _EXBOND_INBOND_BE_DATE; } set { _EXBOND_INBOND_BE_DATE = value; } }
    public string EXBOND_BOND_NO { get { return _EXBOND_BOND_NO; } set { _EXBOND_BOND_NO = value; } }
    public string EXBOND_BOND_DATE { get { return _EXBOND_BOND_DATE; } set { _EXBOND_BOND_DATE = value; } }
    public string EXBOND_WAREHOUSE_CUSTOMS { get { return _EXBOND_WAREHOUSE_CUSTOMS; } set { _EXBOND_WAREHOUSE_CUSTOMS = value; } }
    public string EXBOND_WAREHOUSE_CUSTOMS_CODE { get { return _EXBOND_WAREHOUSE_CUSTOMS_CODE; } set { _EXBOND_WAREHOUSE_CUSTOMS_CODE = value; } }

    #endregion 

    #region Calc

    public string _Subtotal, _Grandtotal, _RemainingQty;

    public string Subtotal { get { return _Subtotal; } set { _Subtotal = value; } }
    public string Grandtotal { get { return _Grandtotal; } set { _Grandtotal = value; } }
    public string RemainingQty { get { return _RemainingQty; } set { _RemainingQty = value; } }

    #endregion


    public string currentuser, ddlJobNo;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, working_period;


    public string Ename
    {
        get { return _Ename; }
        set { _Ename = value; }
    }
    public string Workingperiod
    {
        get { return _Workingperiod; }
        set { _Workingperiod = value; }
    }

    //System.Data.DataTable dtuser = new System.Data.DataTable();
    #endregion

    public List<WareHouseReportDetails> Load_WareHouse_General(DataTable dt)
    {
        List<WareHouseReportDetails> list = new List<WareHouseReportDetails>();
        list.Clear();
        int i = 0;

        while (dt.Rows.Count > i)
        {
            //string JOBNO = "5";
            DataRow row = dt.Rows[i];

            list.Add(new WareHouseReportDetails()
            {
                JOBNO = row["JOBNO"].ToString(),
                JOBDATE = row["JOBDATE"].ToString(),
                BE_TYPE = row["BE_TYPE"].ToString(),
                CUSTOMS_HOUSE = row["CUSTOMS_HOUSE"].ToString(),
                Importer_Name = row["IMPORTER_NAME"].ToString(),
                EXBOND_BOND_NO = row["EXBOND_BOND_NO"].ToString(),
                EXBOND_BOND_DATE = row["EXBOND_BOND_DATE"].ToString(),
                EXBOND_WAREHOUSE_CUSTOMS = row["EXBOND_WAREHOUSE_CUSTOMS"].ToString(),
                EXBOND_WAREHOUSE_CUSTOMS_CODE = row["EXBOND_WAREHOUSE_CUSTOMS_CODE"].ToString(),
                BE_NO = row["BE_NO"].ToString(),
                BE_DATE = row["BE_DATE"].ToString()
                //Workingperiod = ConvertWorkingPeriod(row["WORKINGPERIOD"].ToString())

            });
            i++;
        }

        return list;
    }

    public List<WareHouseReportDetails> Load_WareHouse_Inv_ItemDetails(DataTable dt)
    {

        List<WareHouseReportDetails> list = new List<WareHouseReportDetails>();

        list.Clear();
        int i = 0;

        while (dt.Rows.Count > i)
        {
            DataRow row = dt.Rows[i];

            list.Add(new WareHouseReportDetails()
            {

                JOBNO = row["JOBNO"].ToString(),
                INVOICE_SLNO = row["INVOICE_SLNO"].ToString(),
                INVOICE_NO = row["INVOICE_NO"].ToString(),
                ITEM_SLNO = row["ITEM_SLNO"].ToString(),
                ITEM_DESCRIPTION = row["ITEM_DESCRIPTION"].ToString(),
                ITEM_QTY = row["ITEM_QTY"].ToString(),
                ITEM_QTY_CODE = row["ITEM_QTY_CODE"].ToString(),
                ITEM_UNIT_PRICE = row["ITEM_UNIT_PRICE"].ToString(),
                ITEM_UNIT_CODE = row["ITEM_UNIT_CODE"].ToString(),
                ITEM_TOTAL_AMOUNT = row["ITEM_TOTAL_AMOUNT"].ToString(),
                ITEM_AMOUNT_CODE = row["ITEM_AMOUNT_CODE"].ToString(),
                IMPORTER_NAME = row["IMPORTER_NAME"].ToString(),
                BE_NO = row["BE_NO"].ToString(),
                BE_DATE = row["BE_DATE"].ToString()
                //Workingperiod = ConvertWorkingPeriod(row["WORKINGPERIOD"].ToString())

                //BAL_QTY = row["REMAINING_QTY"].ToString()
            });
            i++;
        }
        return list;
    }


    public List<WareHouseReportDetails> Load_WareHouse_Inv_Item_ALLDetails(DataTable dt)
    {

        List<WareHouseReportDetails> list = new List<WareHouseReportDetails>();

        list.Clear();
        int i = 0;

        while (dt.Rows.Count > i)
        {
            DataRow row = dt.Rows[i];

            list.Add(new WareHouseReportDetails()
            {

                JOBNO = row["JOBNO"].ToString(),
                INVOICE_SLNO = row["INVOICE_SLNO"].ToString(),
                INVOICE_NO = row["INVOICE_NO"].ToString(),
                ITEM_SLNO = row["ITEM_SLNO"].ToString(),
                ITEM_DESCRIPTION = row["ITEM_DESCRIPTION"].ToString(),
                ITEM_QTY = row["ITEM_QTY"].ToString(),
                ITEM_QTY_CODE = row["ITEM_QTY_CODE"].ToString(),
                //ITEM_UNIT_PRICE = row["ITEM_UNIT_PRICE"].ToString(),
                //ITEM_UNIT_CODE = row["ITEM_UNIT_CODE"].ToString(),
                //ITEM_TOTAL_AMOUNT = row["ITEM_TOTAL_AMOUNT"].ToString(),
                //ITEM_AMOUNT_CODE = row["ITEM_AMOUNT_CODE"].ToString(),
                BAL_QTY = row["REMAINING_QTY"].ToString()

            });
            i++;
        }
        return list;
    }

    public List<WareHouseReportDetails> Load_WareHouse_General_1(DataTable dt)
    {
        List<WareHouseReportDetails> list = new List<WareHouseReportDetails>();
        list.Clear();
        int i = 0;

        while (dt.Rows.Count > i)
        {
            //string JOBNO = "5";
            DataRow row = dt.Rows[i];

            list.Add(new WareHouseReportDetails()
            {
                JOBNO = row["JOBNO"].ToString(),
                JOBDATE = row["JOBDATE"].ToString(),
                BE_TYPE = row["BE_TYPE"].ToString(),
                CUSTOMS_HOUSE = row["CUSTOMS_HOUSE"].ToString(),
                Importer_Name = row["IMPORTER_NAME"].ToString(),
                EXBOND_BOND_NO=row["EXBOND_BOND_NO"].ToString(),
                EXBOND_BOND_DATE = row["EXBOND_BOND_DATE"].ToString(),
                EXBOND_WAREHOUSE_CUSTOMS = row["EXBOND_WAREHOUSE_CUSTOMS"].ToString(),
                EXBOND_WAREHOUSE_CUSTOMS_CODE = row["EXBOND_WAREHOUSE_CUSTOMS_CODE"].ToString(),
                BE_NO = row["BE_NO"].ToString(),
                BE_DATE = row["BE_DATE"].ToString(),
                Workingperiod = ConvertWorkingPeriod(row["WORKINGPERIOD"].ToString())

            });
            i++;
        }

        return list;
    }

    public List<WareHouseReportDetails> Load_WareHouse_Inv_ItemDetails_1(DataTable dt)
    {

        List<WareHouseReportDetails> list = new List<WareHouseReportDetails>();

        list.Clear();
        int i = 0;

        while (dt.Rows.Count > i)
        {
            DataRow row = dt.Rows[i];

            list.Add(new WareHouseReportDetails()
            {

                JOBNO = row["JOBNO"].ToString(),
                INVOICE_SLNO = row["INVOICE_SLNO"].ToString(),
                INVOICE_NO = row["INVOICE_NO"].ToString(),
                ITEM_SLNO = row["ITEM_SLNO"].ToString(),
                ITEM_DESCRIPTION = row["ITEM_DESCRIPTION"].ToString(),
                ITEM_QTY = row["ITEM_QTY"].ToString(),
                ITEM_QTY_CODE = row["ITEM_QTY_CODE"].ToString(),
                ITEM_UNIT_PRICE = row["ITEM_UNIT_PRICE"].ToString(),
                ITEM_UNIT_CODE = row["ITEM_UNIT_CODE"].ToString(),
                ITEM_TOTAL_AMOUNT = row["ITEM_TOTAL_AMOUNT"].ToString(),
                ITEM_AMOUNT_CODE = row["ITEM_AMOUNT_CODE"].ToString(),
                IMPORTER_NAME = row["IMPORTER_NAME"].ToString(),
                BE_NO = row["BE_NO"].ToString(),
                BE_DATE = row["BE_DATE"].ToString(),
                Workingperiod = ConvertWorkingPeriod(row["WORKINGPERIOD"].ToString())

                //BAL_QTY = row["REMAINING_QTY"].ToString()
            });
            i++;
        }
        return list;
    }


    public List<WareHouseReportDetails> Load_WareHouse_Inv_Item_ALLDetails_1(DataTable dt)
    {

        List<WareHouseReportDetails> list = new List<WareHouseReportDetails>();

        list.Clear();
        int i = 0;

        while (dt.Rows.Count > i)
        {
            DataRow row = dt.Rows[i];

            list.Add(new WareHouseReportDetails()
            {

                JOBNO = row["JOBNO"].ToString(),
                INVOICE_SLNO = row["INVOICE_SLNO"].ToString(),
                INVOICE_NO = row["INVOICE_NO"].ToString(),
                ITEM_SLNO = row["ITEM_SLNO"].ToString(),
                ITEM_DESCRIPTION = row["ITEM_DESCRIPTION"].ToString(),
                ITEM_QTY = row["ITEM_QTY"].ToString(),
                ITEM_QTY_CODE = row["ITEM_QTY_CODE"].ToString(),
                //ITEM_UNIT_PRICE = row["ITEM_UNIT_PRICE"].ToString(),
                //ITEM_UNIT_CODE = row["ITEM_UNIT_CODE"].ToString(),
                //ITEM_TOTAL_AMOUNT = row["ITEM_TOTAL_AMOUNT"].ToString(),
                //ITEM_AMOUNT_CODE = row["ITEM_AMOUNT_CODE"].ToString(),
                BAL_QTY = row["REMAINING_QTY"].ToString()

            });
            i++;
        }
        return list;
    }

    private string ConvertWorkingPeriod(string workingPeriod)
    {
        try
        {
            if (string.IsNullOrEmpty(workingPeriod)) return "";
            // "01-Apr-2026 - 31-Mar-2027"
            string[] parts = workingPeriod.Split('-');
            // parts[2] = "2026 " , parts[5] = "2027"
            string fromYear = parts[2].Trim().Split(' ')[0].Trim(); // "2026"
            string toYear = parts[parts.Length - 1].Trim();       // "2027"
            return fromYear + "-" + toYear; // "2026-2027"
        }
        catch
        {
            return workingPeriod;
        }
    }

    public DataSet RetrieveAll_WareHouse_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@name", Ename);
            param[2] = new SqlParameter("@Working_Period",Connection.WorkingPeriod());
            param[4] = new SqlParameter("@BRANCHCODE", Connection.Current_Branch());
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_WareHouse_Report_LCD", param);

            result = Convert.ToInt32(param[5].Value.ToString());
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@name", Ename);
            param[2] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[4] = new SqlParameter("@BRANCHCODE", Connection.Current_Branch());
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_WareHouse_Report_LCD", param);
            //string err = param[5].Value.ToString();
            //result = Convert.ToInt32(param[3].Value.ToString());
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

        public DataSet Get_Login_Details(string WORKING_PERIOD, string Flag)
        {
            DataSet dss = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[10];
                param[1] = new SqlParameter("@COMPANY_LICENSE",Connection.Company_License());
                param[2] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
                param[3] = new SqlParameter("@General", "");
                param[4] = new SqlParameter("@Imp_Exp", "");
                param[5] = new SqlParameter("@Flag", Flag);
                param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
                param[9].Direction = ParameterDirection.Output;
                dss = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "LOGIN_DETAILS", param);
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
            return dss;
        }
}