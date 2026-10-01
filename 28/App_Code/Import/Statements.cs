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
/// Summary description for Statements
/// </summary>
public class Statements
{
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();

    DataTable dt = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    SqlCommand cmd;
    int A1, A2;
    //SqlConnection con = new SqlConnection();
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);


    public int result = 0;
    public string date2;
    # region Common_Private_Attributes

    private string  _flag;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;
    private string _JOBNO;
    private string _Workingperiod;
    private string _Ename;
    private string _IMPORTER_NAME;
    private string _BRANCH;
    private string _FROMDATE;
    private string _TODATE;
    private string _JOB_TYPE;
    private string _SUPPLIER_NAME;
  
    public string Jobdate { get; set; }
    public string Transport_mode { get; set; }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string Workingperiod { get { return _Workingperiod; } set { _Workingperiod = value; } }
    public string IMPORTER_NAME { get { return _IMPORTER_NAME; } set { _IMPORTER_NAME = value; } }
    public string BRANCH { get { return _BRANCH; } set { _BRANCH = value; } }
    public string SUPPLIER_NAME { get { return _SUPPLIER_NAME; } set { _SUPPLIER_NAME = value; } }
    public string JOB_TYPE { get { return _JOB_TYPE; } set { _JOB_TYPE = value; } }



    public string FROMDATE { get { return _FROMDATE; } set { _FROMDATE = value; } }
    public string TODATE { get { return _TODATE; } set { _TODATE = value; } }
   
    #endregion

    #region Statement II Attributes


    public string _id,_Jobno,_CustomHouse, _JobDate, _BE_TYPE, _Imp_Name, _Port_Origin, _Mode, _BRANCHCODE, _IGM_SLNO, __IGM_FLIGHTNO_VESSELNO, __IGM_FLIGHT_VESSELDATE;
    public string _IGM_MAWB_MBL, _IGM_MAWB_MBLDATE, _IGM_NO, _IGM_DATE, _IGM_GROSSWEIGHT, _IGM_TYPEOFWEIGHT, _IGM_NOOFPACKAGE, _IGM_PACKAGETYPE, _IGM_MARKSNOS, _InvoiceNo, _InvoiceValue, _ExRate;
    public string _Item_description, _ITEM_TOTAL_AMOUNT, _CIF_VALUE, _ASSESSABLE_VALUE, _DUTY_VALUE;

    public string id { get { return _id; } set { _id = value; } }
    public string Jobno { get { return _Jobno; } set { _Jobno = value; } }
    public string CustomHouse { get { return _CustomHouse; } set { _CustomHouse = value; } }
    public string JobDate { get { return _JobDate; } set { _JobDate = value; } }
    public string BE_TYPE { get { return _BE_TYPE; } set { _BE_TYPE = value; } }
    public string Imp_Name { get { return _Imp_Name; } set { _Imp_Name = value; } }
    public string Port_Origin { get { return _Port_Origin; } set { _Port_Origin = value; } }
    public string Mode { get { return _Mode; } set { _Mode = value; } }
    public string BRANCHCODE { get { return _BRANCHCODE; } set { _BRANCHCODE = value; } }
    public string IGM_SLNO { get { return _IGM_SLNO; } set { _IGM_SLNO = value; } }
    public string IGM_FLIGHTNO_VESSELNO { get { return __IGM_FLIGHTNO_VESSELNO; } set { __IGM_FLIGHTNO_VESSELNO = value; } }
    public string IGM_FLIGHT_VESSELDATE { get { return __IGM_FLIGHT_VESSELDATE; } set { __IGM_FLIGHT_VESSELDATE = value; } }

    public string IGM_MAWB_MBL { get { return _IGM_MAWB_MBL; } set { _IGM_MAWB_MBL = value; } }
    public string IGM_MAWB_MBLDATE { get { return _IGM_MAWB_MBLDATE; } set { _IGM_MAWB_MBLDATE = value; } }
    public string IGM_NO { get { return _IGM_NO; } set { _IGM_NO = value; } }
    public string IGM_DATE { get { return _IGM_DATE; } set { _IGM_DATE = value; } }
    public string IGM_GROSSWEIGHT { get { return _IGM_GROSSWEIGHT; } set { _IGM_GROSSWEIGHT = value; } }
    public string IGM_TYPEOFWEIGHT { get { return _IGM_TYPEOFWEIGHT; } set { _IGM_TYPEOFWEIGHT = value; } }
    public string IGM_NOOFPACKAGE { get { return _IGM_NOOFPACKAGE; } set { _IGM_NOOFPACKAGE = value; } }
    public string IGM_PACKAGETYPE { get { return _IGM_PACKAGETYPE; } set { _IGM_PACKAGETYPE = value; } }
    public string IGM_MARKSNOS { get { return _IGM_MARKSNOS; } set { _IGM_MARKSNOS = value; } }
    public string InvoiceNo { get { return _InvoiceNo; } set { _InvoiceNo = value; } }
    public string InvoiceValue { get { return _InvoiceValue; } set { _InvoiceValue = value; } }
    public string ExRate { get { return _ExRate; } set { _ExRate = value; } }

    public string Item_description { get { return _Item_description; } set { _Item_description = value; } }
    public string ITEM_TOTAL_AMOUNT { get { return _ITEM_TOTAL_AMOUNT; } set { _ITEM_TOTAL_AMOUNT = value; } }
    public string CIF_VALUE { get { return _CIF_VALUE; } set { _CIF_VALUE = value; } }
    public string ASSESSABLE_VALUE { get { return _ASSESSABLE_VALUE; } set { _ASSESSABLE_VALUE = value; } }
    public string DUTY_VALUE { get { return _DUTY_VALUE; } set { _DUTY_VALUE = value; } }


    #endregion Statement II Attributes

    public DataTable RetrieveAll_Details()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNO);

            param[1] = new SqlParameter("@IMPORTER_NAME", IMPORTER_NAME);

            param[2] = new SqlParameter("@SUPPLIER_NAME", SUPPLIER_NAME);

            //param[8] = new SqlParameter("@FROMDATE", FROMDATE);

            //param[9] = new SqlParameter("@TODATE", TODATE);

            if (!string.IsNullOrEmpty(FROMDATE))
                param[3] = new SqlParameter("@FROMDATE", DateTime.Parse(Convert.ToString(FROMDATE), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            else
            {
                param[3] = new SqlParameter("@FROMDATE", FROMDATE);
            }
            if (!string.IsNullOrEmpty(TODATE))
                param[4] = new SqlParameter("@TODATE", DateTime.Parse(Convert.ToString(toDate((TODATE))), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            else
            {
                param[4] = new SqlParameter("@TODATE", TODATE);
            }
            
            param[5] = new SqlParameter("@name", Ename);
                        
            param[6] = new SqlParameter("@Working_Period", Workingperiod);


            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            if (!string.IsNullOrEmpty(Jobdate))
                param[9] = new SqlParameter("@JOBDATE", DateTime.Parse(Convert.ToString(Jobdate), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            else
            {
                param[9] = new SqlParameter("@JOBDATE", Jobdate);
            }
            param[10] = new SqlParameter("@TRANSPORT_MODE", Transport_mode);

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_JOB_STATEMENT_SEARCH_SELECT", param);
            string err = param[8].Value.ToString();
             dt = ds.Tables[0];
           
            
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return dt;

    }
    public string toDate(string dt)
    {
        string[] s1 = dt.Split(new string[] { "/" }, StringSplitOptions.None);
        double s = Convert.ToDouble(s1[0].ToString());
        // s = s + 1;
        if (s < 31)
        {
            s = s + 1;
        }

        if (Convert.ToString(s).Length == 1)
            date2 = "0" + Convert.ToString(s);
        else if (Convert.ToString(s).Length == 2)
            date2 = Convert.ToString(s);

        return date2 = date2 + "/" + s1[1].ToString() + "/" + s1[2].ToString();
    }

    public DataSet Retreive_All_Statement_II()
    {
        try
        {
            FROMDATE = FROMDATE == null ? string.Empty : FROMDATE;
            TODATE = TODATE == null ? string.Empty : TODATE;
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (FROMDATE != string.Empty && FROMDATE != null)
            {
                arr = FROMDATE.Split('/');
                FROMDATE = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (TODATE != string.Empty && TODATE != null)
            {
                arr2 = TODATE.Split('/');
                TODATE = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] p = new SqlParameter[20];

            p[0] = new SqlParameter("@imp_name", IMPORTER_NAME=IMPORTER_NAME=="All"? string.Empty:IMPORTER_NAME);
            p[1] = new SqlParameter("@from_date", FROMDATE);
            p[2] = new SqlParameter("@to_date", TODATE);
            p[3] = new SqlParameter("@Tr_mode", Transport_mode=Transport_mode=="All"? string.Empty:Transport_mode);
            p[4] = new SqlParameter("@Branch", BRANCH=BRANCH=="All"? string.Empty:BRANCH);
            p[5] = new SqlParameter("@JobType", JOB_TYPE);
            p[6] = new SqlParameter("@name", Ename);

            p[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            p[7].Direction = ParameterDirection.Output;

            p[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            p[8].Direction = ParameterDirection.Output;


            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_Import_Statement_2", p);

           
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }


    public List<Statements> Load_Statement_II(DataTable dt)
    {
        List<Statements> list = new List<Statements>();

        int i = 0;

        while (dt.Rows.Count > i)
        {
        DataRow row = dt.Rows[i];

        list.Add(new Statements()
        {
            id = row["id"].ToString(),
            Jobno = row["Jobno"].ToString(),
            Imp_Name = row["Imp_Name"].ToString(),
            CustomHouse=row["CustomHouse"].ToString(),
            JobDate = row["JobDate"].ToString(),
            Mode = row["Mode"].ToString(),
            BE_TYPE = row["BE_TYPE"].ToString(),
            Port_Origin = row["Port_Origin"].ToString(),
            BRANCHCODE = row["BRANCHCODE"].ToString(),
            IGM_SLNO = row["IGM_SLNO"].ToString(),
            IGM_FLIGHTNO_VESSELNO = row["IGM_FLIGHTNO_VESSELNO"].ToString(),
            IGM_FLIGHT_VESSELDATE = row["IGM_FLIGHT_VESSELDATE"].ToString(),
            IGM_MAWB_MBL = row["IGM_MAWB_MBL"].ToString(),
            IGM_MAWB_MBLDATE = row["IGM_MAWB_MBLDATE"].ToString(),
            IGM_NO = row["IGM_NO"].ToString(),
            IGM_DATE = row["IGM_DATE"].ToString(),
            IGM_GROSSWEIGHT = row["IGM_GROSSWEIGHT"].ToString(),
            IGM_TYPEOFWEIGHT = row["IGM_TYPEOFWEIGHT"].ToString(),
            IGM_NOOFPACKAGE = row["IGM_NOOFPACKAGE"].ToString(),
            IGM_PACKAGETYPE = row["IGM_PACKAGETYPE"].ToString(),
            IGM_MARKSNOS = row["IGM_MARKSNOS"].ToString(),
            InvoiceNo = row["InvoiceNo"].ToString(),
            InvoiceValue = row["InvoiceValue"].ToString(),
            ExRate = row["ExRate"].ToString(),
            Item_description = row["Item_description"].ToString(),
            ITEM_TOTAL_AMOUNT = row["ITEM_TOTAL_AMOUNT"].ToString(),
            CIF_VALUE = row["CIF_VALUE"].ToString(),
            ASSESSABLE_VALUE = row["ASSESSABLE_VALUE"].ToString(),
            DUTY_VALUE = row["DUTY_VALUE"].ToString()

        });
        i++;
        }

        return list;
    }
}