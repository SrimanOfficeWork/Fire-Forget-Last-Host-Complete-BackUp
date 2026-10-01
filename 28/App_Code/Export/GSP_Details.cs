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
/// Summary description for GSP_Details
/// </summary>
public class GSP_Details
{
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    SqlCommand cmd;
    int A1, A2;
    //SqlConnection con = new SqlConnection();
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
    public int result, UPDATE_ID = 0;
    private string _FROM_DATE, _TO_DATE;
    
    # region Private Attributes 
    
    //-------------------------------------//
        private string _GSPID;
        private string _JOBNO;
        private string _JOBID;
        private string _FILE_REF_NO;
  
        private string _EXPORTER_NAME;
        private string _BRANCH_NO;
        private string _IEC_NO;
        private string _ADDRESS1;
        private string _ADDRESS2;
        private string _ADDRESS3;
        private string _ADDRESS4;
        private string _ADDRESS5;
   
        private string _CONSIGNEE_NAME;
        private string _CONSIGNEE_ADD1;
        private string _CONSIGNEE_ADD2;
        private string _CONSIGNEE_ADD3;
        private string _CONSIGNEE_ADD4;
        private string _CONSIGNEE_ADD5;

        private string _EXPORTER_COUNTRY;
        private string _IMPORTER_COUNTRY;
        private string _PLACE_DATE;

        private string _ENTERED_BY;
        private string _DEPATURE_DATE;
        private string _VESSEL_AIRCRAFT_NAME;
        private string _PORT_DISCHARGE;
       
        private string _TRANSPORT_ROUTE;
        private string _ITEM_NO;
        private string _MARKS_NOS;
        private string _DESCRIPTION;
        private string _ORIGIN;
        private string _GROSS_WEIGHT;

        private string _INVOICE_NO_DATE;
        
        private string _DEC1;
        private string _DEC2;
        private string _DEC3;
        private string _SPE1;
        private string _SPE2;
        private string _SPE3;
        private string _SPE4;
        private string _SPE5;

        private string _SUB1;
        private string _SUB2;
        private string _SUB3;
        private string _SUB4;
        private string _REQ1;
        private string _REQ2;
        private string _REQ3;
        private string _REQ4;
        private string _REQ5;
        private string _REQ6;

        private string _flag;
        private string _USER_ID;
        private string _BRANCH_CODE;
        private string _YEAR;
        private string _WORKING_PERIOD;
        private string _BRANCH_COMMON;

        private string _Ename;
        private string _startRowIndex;
        private string _maximumRows;
        private string _totalRows;

    #endregion

    # region Public Attributes

    public string GSPID { get { return _GSPID; } set { _GSPID = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string FILE_REF_NO { get { return _FILE_REF_NO; } set { _FILE_REF_NO = value; } }
    
    public string EXPORTER_NAME { get { return _EXPORTER_NAME; } set { _EXPORTER_NAME = value; } }
    public string BRANCH_NO { get { return _BRANCH_NO; } set { _BRANCH_NO = value; } }
    public string IEC_NO { get { return _IEC_NO; } set { _IEC_NO = value; } }
    public string ADDRESS1 { get { return _ADDRESS1; } set { _ADDRESS1 = value; } }
    public string ADDRESS2 { get { return _ADDRESS2; } set { _ADDRESS2 = value; } }
    public string ADDRESS3 { get { return _ADDRESS3; } set { _ADDRESS3 = value; } }
    public string ADDRESS4 { get { return _ADDRESS4; } set { _ADDRESS4 = value; } }
    public string ADDRESS5 { get { return _ADDRESS5; } set { _ADDRESS5 = value; } }
   
    public string CONSIGNEE_NAME { get { return _CONSIGNEE_NAME; } set { _CONSIGNEE_NAME = value; } }
    public string CONSIGNEE_ADD1 { get { return _CONSIGNEE_ADD1; } set { _CONSIGNEE_ADD1 = value; } }
    public string CONSIGNEE_ADD2 { get { return _CONSIGNEE_ADD2; } set { _CONSIGNEE_ADD2 = value; } }
    public string CONSIGNEE_ADD3 { get { return _CONSIGNEE_ADD3; } set { _CONSIGNEE_ADD3 = value; } }
    public string CONSIGNEE_ADD4 { get { return _CONSIGNEE_ADD4; } set { _CONSIGNEE_ADD4 = value; } }
    public string CONSIGNEE_ADD5 { get { return _CONSIGNEE_ADD5; } set { _CONSIGNEE_ADD5 = value; } }

    public string EXPORTER_COUNTRY { get { return _EXPORTER_COUNTRY; } set { _EXPORTER_COUNTRY = value; } }
    public string IMPORTER_COUNTRY { get { return _IMPORTER_COUNTRY; } set { _IMPORTER_COUNTRY = value; } }
    public string PLACE_DATE { get { return _PLACE_DATE; } set { _PLACE_DATE = value; } }
       
    public string ENTERED_BY { get { return _ENTERED_BY; } set { _ENTERED_BY = value; } }
    public string DEPATURE_DATE { get { return _DEPATURE_DATE; } set { _DEPATURE_DATE = value; } }
    public string VESSEL_AIRCRAFT_NAME { get { return _VESSEL_AIRCRAFT_NAME; } set { _VESSEL_AIRCRAFT_NAME = value; } }
    public string PORT_DISCHARGE { get { return _PORT_DISCHARGE; } set { _PORT_DISCHARGE = value; } }
  
    public string TRANSPORT_ROUTE { get { return _TRANSPORT_ROUTE; } set { _TRANSPORT_ROUTE = value; } }
    public string ITEM_NO { get { return _ITEM_NO; } set { _ITEM_NO = value; } }
    public string MARKS_NOS { get { return _MARKS_NOS; } set { _MARKS_NOS = value; } }
    public string DESCRIPTION { get { return _DESCRIPTION; } set { _DESCRIPTION = value; } }
    public string ORIGIN { get { return _ORIGIN; } set { _ORIGIN = value; } }
    public string GROSS_WEIGHT { get { return _GROSS_WEIGHT; } set { _GROSS_WEIGHT = value; } }
    public string INVOICE_NO_DATE { get { return _INVOICE_NO_DATE; } set { _INVOICE_NO_DATE = value; } }
   
    public string DEC1 { get { return _DEC1; } set { _DEC1 = value; } }
    public string DEC2 { get { return _DEC2; } set { _DEC2 = value; } }
    public string DEC3 { get { return _DEC3; } set { _DEC3 = value; } }
    public string SPE1 { get { return _SPE1; } set { _SPE1 = value; } }
    public string SPE2 { get { return _SPE2; } set { _SPE2 = value; } }
    public string SPE3 { get { return _SPE3; } set { _SPE3 = value; } }
    public string SPE4 { get { return _SPE4; } set { _SPE4 = value; } }
    public string SPE5 { get { return _SPE5; } set { _SPE5 = value; } }

    public string SUB1 { get { return _SUB1; } set { _SUB1 = value; } }
    public string SUB2 { get { return _SUB2; } set { _SUB2 = value; } }
    public string SUB3 { get { return _SUB3; } set { _SUB3 = value; } }
    public string SUB4 { get { return _SUB4; } set { _SUB4 = value; } }
    public string REQ1 { get { return _REQ1; } set { _REQ1 = value; } }
    public string REQ2 { get { return _REQ2; } set { _REQ2 = value; } }

    public string REQ3 { get { return _REQ3; } set { _REQ3 = value; } }
    public string REQ4 { get { return _REQ4; } set { _REQ4 = value; } }
    public string REQ5 { get { return _REQ5; } set { _REQ5 = value; } }
    public string REQ6 { get { return _REQ6; } set { _REQ6 = value; } }

    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }
   
    public string Ename { get { return _Ename; } set { _Ename = value; } }

    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }

    public string FROM_DATE { get { return _FROM_DATE; } set { _FROM_DATE = value; } }
    public string TO_DATE { get { return _TO_DATE; } set { _TO_DATE = value; } }
    
    #endregion

    #region Insert & Update

    public int GSP_details_insertupdate()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[100];

            //param[0] = new SqlParameter("@JOBID", GSPID);

            param[1] = new SqlParameter("@JOBNO", JOBNO);

            param[2] = new SqlParameter("@FILE_REF_NO", FILE_REF_NO);

            param[3] = new SqlParameter("@EXPORTER_NAME", EXPORTER_NAME);

            param[4] = new SqlParameter("@BRANCH_NO", BRANCH_NO);

            param[5] = new SqlParameter("@IEC_NO", IEC_NO);

            param[6] = new SqlParameter("@ADDRESS1", ADDRESS1);

            param[7] = new SqlParameter("@ADDRESS2", ADDRESS2);
                    
            param[8] = new SqlParameter("@ADDRESS3", ADDRESS3);

            param[9] = new SqlParameter("@ADDRESS4", ADDRESS4);

            param[10] = new SqlParameter("@ADDRESS5", ADDRESS5);
           
            param[11] = new SqlParameter("@CONSIGNEE_NAME", CONSIGNEE_NAME);

            param[12] = new SqlParameter("@CONSIGNEE_ADD1", CONSIGNEE_ADD1);

            param[13] = new SqlParameter("@CONSIGNEE_ADD2", CONSIGNEE_ADD2);

            param[14] = new SqlParameter("@CONSIGNEE_ADD3", CONSIGNEE_ADD3);

            param[15] = new SqlParameter("@CONSIGNEE_ADD4", CONSIGNEE_ADD4);

            param[16] = new SqlParameter("@CONSIGNEE_ADD5", CONSIGNEE_ADD5);

            param[17] = new SqlParameter("@EXPORTER_COUNTRY", EXPORTER_COUNTRY);

            param[18] = new SqlParameter("@IMPORTER_COUNTRY", IMPORTER_COUNTRY);

            param[19] = new SqlParameter("@PLACE_DATE", PLACE_DATE);

            param[51] = new SqlParameter("@ENTERED_BY", ENTERED_BY);

            param[52] = new SqlParameter("@DEPATURE_DATE", DateTime.Parse(DEPATURE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            //param[52] = new SqlParameter("@DEPATURE_DATE", DEPATURE_DATE);

            param[53] = new SqlParameter("@VESSEL_AIRCRAFT_NAME", VESSEL_AIRCRAFT_NAME);

            param[54] = new SqlParameter("@PORT_DISCHARGE", PORT_DISCHARGE);


            param[21] = new SqlParameter("@TRANSPORT_ROUTE", TRANSPORT_ROUTE);

            param[22] = new SqlParameter("@ITEM_NO", ITEM_NO);

            param[23] = new SqlParameter("@MARKS_NOS", MARKS_NOS);

            param[24] = new SqlParameter("@DESCRIPTION", DESCRIPTION);

            param[25] = new SqlParameter("@ORIGIN", ORIGIN);

            param[26] = new SqlParameter("@GROSS_WEIGHT", GROSS_WEIGHT);

            param[27] = new SqlParameter("@INVOICE_NO_DATE", INVOICE_NO_DATE);

            //param[27] = new SqlParameter("@INVOICE_NO_DATE", "01/02/2015");
         
            param[29] = new SqlParameter("@DEC1", DEC1);

            param[30] = new SqlParameter("@DEC2", DEC2);

            param[31] = new SqlParameter("@DEC3", DEC3);

            param[32] = new SqlParameter("@SPE1", SPE1);

            param[33] = new SqlParameter("@SPE2", SPE2);

            param[34] = new SqlParameter("@SPE3", SPE3);

            param[58] = new SqlParameter("@SPE4", SPE4);

            param[59] = new SqlParameter("@SPE5", SPE5);

            param[35] = new SqlParameter("@SUB1", SUB1);

            param[36] = new SqlParameter("@SUB2", SUB2);

            param[37] = new SqlParameter("@SUB3", SUB3);

            param[38] = new SqlParameter("@SUB4", SUB4);

            param[39] = new SqlParameter("@REQ1", REQ1);

            param[40] = new SqlParameter("@REQ2", REQ2);

            param[41] = new SqlParameter("@REQ3", REQ3);

            param[42] = new SqlParameter("@REQ4", REQ4);

            param[56] = new SqlParameter("@REQ5", REQ5);

            param[57] = new SqlParameter("@REQ6", REQ6);

            param[43] = new SqlParameter("@USERID", USER_ID);

            param[44] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);

            param[50] = new SqlParameter("@YEAR", YEAR);

            param[45] = new SqlParameter("@WORKINGPERIOD", WORKING_PERIOD);
            
            param[55] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[46] = new SqlParameter("@Mflag", flag);

            param[47] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[47].Direction = ParameterDirection.Output;

            param[48] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[48].Direction = ParameterDirection.Output;
            param[49] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[49].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXPORT_GSP_DETAILS_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[47].Value.ToString());
            string err = param[48].Value.ToString();
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[49].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return result;
    }
  #endregion


    public DataSet RetrieveAll_GSP_Details()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNO);

            param[1] = new SqlParameter("@flag", Ename);

            param[2] = new SqlParameter("@WORKINGPERIOD", WORKING_PERIOD);

            param[6] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);

            param[7] = new SqlParameter("@REPORT_TYPE", "");

            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            //param[4] = new SqlParameter("@STR_Status", SqlDbType.Int, 1);
            //param[4].Direction = ParameterDirection.Output;


            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
         
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_BL_GENERATION_CONTAINER_SELECT", param);
            //result = Convert.ToInt32(param[3].Value.ToString());
            
            string err = param[5].Value.ToString();
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }


    public List<GSP_Details> Load_GSP_Details(DataTable dt)
    {
        List<GSP_Details> list = new List<GSP_Details>();

        int i = 0;

        while (dt.Rows.Count > i)
        {
            DataRow row = dt.Rows[i];

            list.Add(new GSP_Details()
            {
                JOBNO = row["JOBNO"].ToString(),
                FILE_REF_NO = row["FILE_REF_NO"].ToString(),
                EXPORTER_NAME = row["EXPORTER_NAME"].ToString(),
                BRANCH_NO = row["BRANCH_NO"].ToString(),
                IEC_NO = row["IEC_NO"].ToString(),
                ADDRESS1 = row["ADDRESS1"].ToString(),
                ADDRESS2 = row["ADDRESS2"].ToString(),
                ADDRESS3 = row["ADDRESS3"].ToString(),
                ADDRESS4 = row["ADDRESS4"].ToString(),
                ADDRESS5 = row["ADDRESS5"].ToString(),
                CONSIGNEE_NAME = row["CONSIGNEE_NAME"].ToString(),
                CONSIGNEE_ADD1 = row["CONSIGNEE_ADD1"].ToString(),
                CONSIGNEE_ADD2 = row["CONSIGNEE_ADD2"].ToString(),
                CONSIGNEE_ADD3 = row["CONSIGNEE_ADD3"].ToString(),
                CONSIGNEE_ADD4 = row["CONSIGNEE_ADD4"].ToString(),
                CONSIGNEE_ADD5 = row["CONSIGNEE_ADD5"].ToString(),
                EXPORTER_COUNTRY = row["EXPORTER_COUNTRY"].ToString(),
                IMPORTER_COUNTRY = row["IMPORTER_COUNTRY"].ToString(),
                PLACE_DATE = row["PLACE_DATE"].ToString(),
                ENTERED_BY = row["ENTERED_BY"].ToString(),
                DEPATURE_DATE = row["DEPATURE_DATE"].ToString(),
                VESSEL_AIRCRAFT_NAME = row["VESSEL_AIRCRAFT_NAME"].ToString(),
                PORT_DISCHARGE = row["PORT_DISCHARGE"].ToString(),
                TRANSPORT_ROUTE = row["TRANSPORT_ROUTE"].ToString(),
                ITEM_NO = row["ITEM_NO"].ToString(),
                MARKS_NOS = row["MARKS_NOS"].ToString(),
                DESCRIPTION = row["DESCRIPTION"].ToString(),
                ORIGIN = row["ORIGIN"].ToString(),
                GROSS_WEIGHT = row["GROSS_WEIGHT"].ToString(),
                INVOICE_NO_DATE = row["INVOICE_NO_DATE"].ToString(),
                DEC1 = row["DEC1"].ToString(),
                DEC2 = row["DEC2"].ToString(),
                DEC3 = row["DEC3"].ToString(),
                SPE1 = row["SPE1"].ToString(),
                SPE2 = row["SPE2"].ToString(),
                SPE3 = row["SPE3"].ToString(),
                //SPE4 = row["SPE4"].ToString(),
                //SPE5 = row["SPE5"].ToString(),
                SUB1 = row["SUB1"].ToString(),
                SUB2 = row["SUB2"].ToString(),
                SUB3 = row["SUB3"].ToString(),
                SUB4 = row["SUB4"].ToString(),
                REQ1 = row["REQ1"].ToString(),
                REQ2 = row["REQ2"].ToString(),
                REQ3 = row["REQ3"].ToString(),
                REQ4 = row["REQ4"].ToString()
               

            });
            i++;
        }

        return list;
    }


    public DataSet GSP_NORMAL_SEARCH()
    {
        try
        {
            FROM_DATE = FROM_DATE == null ? string.Empty : FROM_DATE;
            TO_DATE = TO_DATE == null ? string.Empty : TO_DATE;
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (FROM_DATE != string.Empty && FROM_DATE != null)
            {
                arr = FROM_DATE.Split('/');
                FROM_DATE = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (TO_DATE != string.Empty && TO_DATE != null)
            {
                arr2 = TO_DATE.Split('/');
                TO_DATE = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@ExporterName", EXPORTER_NAME);
            param[2] = new SqlParameter("@from_date", FROM_DATE);
            param[3] = new SqlParameter("@to_date", TO_DATE);
            param[4] = new SqlParameter("@Working_Period", BRANCH_CODE);
            param[8] = new SqlParameter("@Branch", BRANCH_CODE);
            param[5] = new SqlParameter("@Ename", Ename);


            param[6] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXPORT_GSP_NORMAL_SEARCH", param);
            result = Convert.ToInt32(param[6].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }
}

