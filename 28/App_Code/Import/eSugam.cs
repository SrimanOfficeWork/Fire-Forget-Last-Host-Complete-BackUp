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
/// Summary description for Duty_Intimation
/// </summary>
public class e_Sugam
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

    # region Private Attributes

private string _ID;
private string _JOBNO;
private string _IMPORTER_NAME;
private string _ADDRESS1;
private string _ADDRESS2;
private string _ADDRESS3;
private string _ADDRESS4;
private string _ADDRESS5;
private string _IMP_TIN_NO;
private string _SUPPLIER_NAME;
private string _SUPPLIER_ADDRESS1;
private string _SUPPLIER_ADDRESS2;
private string _SUPPLIER_ADDRESS3;
private string _SUPPLIER_ADDRESS4;
private string _SUPPLIER_TINNO;
private string _DESPATCH_GOODS;
private string _DOCUMENT_TYPE;
private string _DOCUMENT_NO;
private string _DOCUMENT_DATE;
private string _QUANTITY;
private string _TOTAL_VALUE;
private string _VAT_CST_VALUE;
private string _OTHER_AMOUNT;
private string _TOTAL_INVOICE_VALUE;
private string _DESPATCH_DATE;
private string _NATURE_TRANSACTION;
private string _COMMODITY;
private string _TRANSPORTER_NAME;
private string _VEHICLE_NO;
private string _LG_GR;
private string _RECEIPT_DATE;
private string _USER_ID;
private string _DATE_TIME;
private string _BRANCH_CODE;
private string _WORKING_PERIOD, _BRANCH_COMMON,_BRANCH_NO;

private string _Ename;


    #endregion

    # region Public Attributes



    public string ID { get { return _ID; } set { _ID = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string IMPORTER_NAME { get { return _IMPORTER_NAME; } set { _IMPORTER_NAME = value; } }
    public string ADDRESS1 { get { return _ADDRESS1; } set { _ADDRESS1 = value; } }
    public string ADDRESS2 { get { return _ADDRESS2; } set { _ADDRESS2 = value; } }
    public string ADDRESS3 { get { return _ADDRESS3; } set { _ADDRESS3 = value; } }
    public string ADDRESS4 { get { return _ADDRESS4; } set { _ADDRESS4 = value; } }
    public string ADDRESS5 { get { return _ADDRESS5; } set { _ADDRESS5 = value; } }

    public string IMP_TIN_NO { get { return _IMP_TIN_NO; } set { _IMP_TIN_NO = value; } }
    public string SUPPLIER_NAME { get { return _SUPPLIER_NAME; } set { _SUPPLIER_NAME = value; } }
    public string SUPPLIER_ADDRESS1 { get { return _SUPPLIER_ADDRESS1; } set { _SUPPLIER_ADDRESS1 = value; } }
    public string SUPPLIER_ADDRESS2 { get { return _SUPPLIER_ADDRESS2; } set { _SUPPLIER_ADDRESS2 = value; } }
    public string SUPPLIER_ADDRESS3 { get { return _SUPPLIER_ADDRESS3; } set { _SUPPLIER_ADDRESS3 = value; } }
    public string SUPPLIER_ADDRESS4 { get { return _SUPPLIER_ADDRESS4; } set { _SUPPLIER_ADDRESS4 = value; } }
    public string SUPPLIER_TINNO { get { return _SUPPLIER_TINNO; } set { _SUPPLIER_TINNO = value; } }
    public string DESPATCH_GOODS { get { return _DESPATCH_GOODS; } set { _DESPATCH_GOODS = value; } }

    public string DOCUMENT_TYPE { get { return _DOCUMENT_TYPE; } set { _DOCUMENT_TYPE = value; } }
    public string DOCUMENT_NO { get { return _DOCUMENT_NO; } set { _DOCUMENT_NO = value; } }
    public string DOCUMENT_DATE { get { return _DOCUMENT_DATE; } set { _DOCUMENT_DATE = value; } }
    public string QUANTITY { get { return _QUANTITY; } set { _QUANTITY = value; } }
    public string TOTAL_VALUE { get { return _TOTAL_VALUE; } set { _TOTAL_VALUE = value; } }
    public string VAT_CST_VALUE { get { return _VAT_CST_VALUE; } set { _VAT_CST_VALUE = value; } }
    public string OTHER_AMOUNT { get { return _OTHER_AMOUNT; } set { _OTHER_AMOUNT = value; } }
    public string TOTAL_INVOICE_VALUE { get { return _TOTAL_INVOICE_VALUE; } set { _TOTAL_INVOICE_VALUE = value; } }
    public string DESPATCH_DATE { get { return _DESPATCH_DATE; } set { _DESPATCH_DATE = value; } }
    public string NATURE_TRANSACTION { get { return _NATURE_TRANSACTION; } set { _NATURE_TRANSACTION = value; } }

    public string COMMODITY { get { return _COMMODITY; } set { _COMMODITY = value; } }
    public string TRANSPORTER_NAME { get { return _TRANSPORTER_NAME; } set { _TRANSPORTER_NAME = value; } }
    public string VEHICLE_NO { get { return _VEHICLE_NO; } set { _VEHICLE_NO = value; } }
    public string LG_GR { get { return _LG_GR; } set { _LG_GR = value; } }
    public string RECEIPT_DATE { get { return _RECEIPT_DATE; } set { _RECEIPT_DATE = value; } }

    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string DATE_TIME { get { return _DATE_TIME; } set { _DATE_TIME = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }
    public string BRANCH_NO { get { return _BRANCH_NO; } set { _BRANCH_NO = value; } }
    
    public string Ename { get { return _Ename; } set { _Ename = value; } }

  
    #endregion

    #region Insert & Update

    public int e_Sugam_Details_insertupdate()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[50];

            param[1] = new SqlParameter("@ID", ID);
            param[2] = new SqlParameter("@JOBNO", JOBNO);
            param[3] = new SqlParameter("@IMPORTER_NAME", IMPORTER_NAME);
            param[4] = new SqlParameter("@ADDRESS1", ADDRESS1);
            param[5] = new SqlParameter("@ADDRESS2", ADDRESS2);
            param[6] = new SqlParameter("@ADDRESS3", ADDRESS3);
            param[7] = new SqlParameter("@ADDRESS4", ADDRESS4);
            param[8] = new SqlParameter("@ADDRESS5", ADDRESS5);
            param[9] = new SqlParameter("@IMP_TIN_NO", IMP_TIN_NO);
            param[10] = new SqlParameter("@SUPPLIER_NAME", SUPPLIER_NAME);
            param[11] = new SqlParameter("@SUPPLIER_ADDRESS1", SUPPLIER_ADDRESS1);
            param[12] = new SqlParameter("@SUPPLIER_ADDRESS2", SUPPLIER_ADDRESS2);
            param[13] = new SqlParameter("@SUPPLIER_ADDRESS3", SUPPLIER_ADDRESS3);
            param[14] = new SqlParameter("@SUPPLIER_ADDRESS4", SUPPLIER_ADDRESS4);
            param[15] = new SqlParameter("@SUPPLIER_TINNO", SUPPLIER_TINNO);
            param[16] = new SqlParameter("@DESPATCH_GOODS", DESPATCH_GOODS);
            param[17] = new SqlParameter("@DOCUMENT_TYPE", DOCUMENT_TYPE);
            param[18] = new SqlParameter("@DOCUMENT_NO", DOCUMENT_NO);
            param[19] = new SqlParameter("@DOCUMENT_DATE", DOCUMENT_DATE);
            param[20] = new SqlParameter("@QUANTITY", QUANTITY);
            param[21] = new SqlParameter("@TOTAL_VALUE", TOTAL_VALUE);
            param[22] = new SqlParameter("@VAT_CST_VALUE", VAT_CST_VALUE);
            param[23] = new SqlParameter("@OTHER_AMOUNT", OTHER_AMOUNT);
            param[24] = new SqlParameter("@TOTAL_INVOICE_VALUE", TOTAL_INVOICE_VALUE);
            param[25] = new SqlParameter("@DESPATCH_DATE", DESPATCH_DATE);
            param[26] = new SqlParameter("@NATURE_TRANSACTION", NATURE_TRANSACTION);
            param[27] = new SqlParameter("@COMMODITY", COMMODITY);
            param[28] = new SqlParameter("@TRANSPORTER_NAME", TRANSPORTER_NAME);
            param[29] = new SqlParameter("@VEHICLE_NO", VEHICLE_NO);
            param[30] = new SqlParameter("@LG_GR", LG_GR);
            param[31] = new SqlParameter("@RECEIPT_DATE", RECEIPT_DATE);
            param[32] = new SqlParameter("@USER_ID", USER_ID);
            //param[33] = new SqlParameter("@DATE_TIME", DATE_TIME);
             param[33] = new SqlParameter("@DATE_TIME", DateTime.Parse(DATE_TIME, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[34] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[35] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[40] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[41] = new SqlParameter("@BRANCH_NO", BRANCH_NO);
       
            //param[14] = new SqlParameter("@INVOICE_DATE", DateTime.Parse(INVOICE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[36] = new SqlParameter("@Mflag", Ename);

            param[37] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[37].Direction = ParameterDirection.Output;

            param[38] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[38].Direction = ParameterDirection.Output;

            param[39] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[39].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "e_SUGAM_DETAILS_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[37].Value.ToString());
            string err = param[29].Value.ToString();
            if (Ename == "S")
                UPDATE_ID = Convert.ToInt32(param[39].Value.ToString());

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


    public DataSet RetrieveAll_eSugam_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@name", Ename);
            param[2] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);

            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "e_SUGAM_DETAILS_SEARCH_SELECT", param);
            string err = param[5].Value.ToString();
            result = Convert.ToInt32(param[3].Value.ToString());
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }


    public List<e_Sugam> Load_eSugam_Details(DataTable dt)
    {
        List<e_Sugam> list = new List<e_Sugam>();

        int i = 0;

        while (dt.Rows.Count > i)
        {
            DataRow row = dt.Rows[i];

            list.Add(new e_Sugam()
            {
                JOBNO = row["JOBNO"].ToString(),
                IMPORTER_NAME = row["IMPORTER_NAME"].ToString(),
                ADDRESS1 = row["ADDRESS1"].ToString(),
                ADDRESS2 = row["ADDRESS2"].ToString(),
                ADDRESS3 = row["ADDRESS3"].ToString(),
                ADDRESS4 = row["ADDRESS4"].ToString(),
                ADDRESS5 = row["ADDRESS5"].ToString(),
                IMP_TIN_NO = row["IMP_TIN_NO"].ToString(),
                SUPPLIER_NAME = row["SUPPLIER_NAME"].ToString(),
                SUPPLIER_ADDRESS1 = row["SUPPLIER_ADDRESS1"].ToString(),
                SUPPLIER_ADDRESS2 = row["SUPPLIER_ADDRESS2"].ToString(),
                SUPPLIER_ADDRESS3 = row["SUPPLIER_ADDRESS3"].ToString(),
                SUPPLIER_ADDRESS4 = row["SUPPLIER_ADDRESS4"].ToString(),
                SUPPLIER_TINNO = row["SUPPLIER_TINNO"].ToString(),
                DESPATCH_GOODS = row["DESPATCH_GOODS"].ToString(),
                DOCUMENT_TYPE = row["DOCUMENT_TYPE"].ToString(),
                DOCUMENT_NO = row["DOCUMENT_NO"].ToString(),
                DOCUMENT_DATE = row["DOCUMENT_DATE"].ToString(),
                QUANTITY = row["QUANTITY"].ToString(),
                TOTAL_VALUE = row["TOTAL_VALUE"].ToString(),
                VAT_CST_VALUE = row["VAT_CST_VALUE"].ToString(),
                OTHER_AMOUNT = row["OTHER_AMOUNT"].ToString(),
                TOTAL_INVOICE_VALUE = row["TOTAL_INVOICE_VALUE"].ToString(),
                DESPATCH_DATE = row["DESPATCH_DATE"].ToString(),
                NATURE_TRANSACTION = row["NATURE_TRANSACTION"].ToString(),
                COMMODITY = row["COMMODITY"].ToString(),
                TRANSPORTER_NAME = row["TRANSPORTER_NAME"].ToString(),
                VEHICLE_NO = row["VEHICLE_NO"].ToString(),
                LG_GR = row["LG_GR"].ToString(),
                RECEIPT_DATE = row["RECEIPT_DATE"].ToString(),
                BRANCH_NO = row["BRANCH_NO"].ToString()
             

            });
            i++;
        }

        return list;
    }
}