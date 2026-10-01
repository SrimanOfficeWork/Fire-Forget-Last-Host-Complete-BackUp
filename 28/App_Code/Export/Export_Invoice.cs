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
using System.IO;


/// <summary>
/// Summary description for Export_Invoice_Details
/// </summary>
public class Export_Invoice
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
    public string Inv_result = "";

    public int license_ID_Max = 0;

    # region Private Attributes


    private string _INVOICE_ID;
    private string _JOBNO;
    private string _JOBDATE;
    private string _INVOICE_SLNO;
    private string _INVOICE_NO;
    private string _INVOICE_DATE;
    private string _PAYMENT_METHOD;
    private string _PERIOD_PAYMENT;
    private string _INVOICE_VALUE;
    private string _INVOICE_CURRENCY;
    private string _EXCHANGE_RATE;
    private string _CONTRACT_NO;
    private string _TERMS;
    private string _BUYER;
    private string _BUYER_NAME;
    private string _BUYER_ADDRESS;
    private string _BUYER_ADDRESS1;
    private string _BUYER_ADDRESS2;
    private string _BUYER_ADDRESS3;
    private string _BUYER_ADDRESS4;
    private string _COMMISSION_RATE;
    private string _COMMISSION_CHARGES;
    private string _COMMISSION_CURRENCY;
    private string _FOB_RATE;
    private string _FOB_CHARGES;
    private string _FOB_CURRENCY;
    private string _PACKMISC_RATE;
    private string _PACKMISC_CHARGES;
    private string _PACKMISC_CURRENCY;
    private string _OTHER_DEDUCTION_RATE;
    private string _OTHER_DEDUCTION_CHARGES;
    private string _OTHER_DEDUCTION_CURRENCY;
    private string _FREIGHT_RATE;
    private string _FREIGHT_CHARGES;
    private string _FREIGHT_CURRENCY, _FREIGHT_EXRATE;
    private string _INSURANCE_RATE;
    private string _INSURANCE_CHARGES;
    private string _INSURANCE_CURRENCY, _INSURANCE_EXRATE;
    private string _WHEATHER_UNIT_PRICE;

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
    private string _NON_STD_EFFECT_DT_EXP, _NON_STD_BANKNAME, _NON_STD_CERTIFICATE_NO, _NON_STD_CERTIFICATE_DATE, _DOC_RECD_DATE;
    private string _AMENDMENT_TYPE, _AMENDMENT_STATUS, _JOBNO_PS;	
    private string _CONTRACT_DATE;    
    #endregion

    #region Single_Window_Details_Private_Attributes

    private string _TERMS_PLACE,
                    _THIRDPARTY_NAME,
                    _THIRDPARTY_ADD1,
                    _THIRDPARTY_ADD2,
                    _THIRDPARTY_CITY,
                    _T_PARTY_COUNTRY_SUB_DIV,
                    _T_PARTY_COUNTRY_CODE,
                    _T_PARTY_PIN,
                    _AUTHORIZED_ECONOMIC_OPERATOR_CODE,
                    _A_E_O_COUNTRY,
                    _AUTHORIZED_ECONOMIC_OPERATOR,

                    _NOTIFY_NAME, _NOTIFY_ADDRESS_1, _NOTIFY_ADDRESS_2, _NOTIFY_ADDRESS_3, _NOTIFY_ADDRESS_COUNTRY;
                    
    #endregion      

    #region Single_Window_Details_Public_Attributes

    public string TERMS_PLACE { get { return _TERMS_PLACE; } set { _TERMS_PLACE = value; } }
    public string THIRDPARTY_NAME { get { return _THIRDPARTY_NAME; } set { _THIRDPARTY_NAME = value; } }
    public string THIRDPARTY_ADD1 { get { return _THIRDPARTY_ADD1; } set { _THIRDPARTY_ADD1 = value; } }
    public string THIRDPARTY_ADD2 { get { return _THIRDPARTY_ADD2; } set { _THIRDPARTY_ADD2 = value; } }
    public string THIRDPARTY_CITY { get { return _THIRDPARTY_CITY; } set { _THIRDPARTY_CITY = value; } }
    public string T_PARTY_COUNTRY_SUB_DIV { get { return _T_PARTY_COUNTRY_SUB_DIV; } set { _T_PARTY_COUNTRY_SUB_DIV = value; } }
    public string T_PARTY_COUNTRY_CODE { get { return _T_PARTY_COUNTRY_CODE; } set { _T_PARTY_COUNTRY_CODE = value; } }
    public string T_PARTY_PIN { get { return _T_PARTY_PIN; } set { _T_PARTY_PIN = value; } }
    public string AUTHORIZED_ECONOMIC_OPERATOR_CODE { get { return _AUTHORIZED_ECONOMIC_OPERATOR_CODE; } set { _AUTHORIZED_ECONOMIC_OPERATOR_CODE = value; } }
    public string A_E_O_COUNTRY { get { return _A_E_O_COUNTRY; } set { _A_E_O_COUNTRY = value; } }
    public string AUTHORIZED_ECONOMIC_OPERATOR { get { return _AUTHORIZED_ECONOMIC_OPERATOR; } set { _AUTHORIZED_ECONOMIC_OPERATOR = value; } }


    public string NOTIFY_NAME { get { return _NOTIFY_NAME; } set { _NOTIFY_NAME = value; } }
    public string NOTIFY_ADDRESS_1 { get { return _NOTIFY_ADDRESS_1; } set { _NOTIFY_ADDRESS_1 = value; } } 
    public string NOTIFY_ADDRESS_2 { get { return _NOTIFY_ADDRESS_2; } set { _NOTIFY_ADDRESS_2 = value; } }
    public string NOTIFY_ADDRESS_3 { get { return _NOTIFY_ADDRESS_3; } set { _NOTIFY_ADDRESS_3 = value; } }
    public string NOTIFY_ADDRESS_COUNTRY { get { return _NOTIFY_ADDRESS_COUNTRY; } set { _NOTIFY_ADDRESS_COUNTRY = value; } }

   
    #endregion

    # region Public Attributes

    public string INVOICE_ID { get { return _INVOICE_ID; } set { _INVOICE_ID = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string JOBDATE { get { return _JOBDATE; } set { _JOBDATE = value; } }
    
    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
    public string INVOICE_DATE { get { return _INVOICE_DATE; } set { _INVOICE_DATE = value; } }
    public string PAYMENT_METHOD { get { return _PAYMENT_METHOD; } set { _PAYMENT_METHOD = value; } }
    public string PERIOD_PAYMENT { get { return _PERIOD_PAYMENT; } set { _PERIOD_PAYMENT = value; } }
    public string INVOICE_VALUE { get { return _INVOICE_VALUE; } set { _INVOICE_VALUE = value; } }
    public string INVOICE_CURRENCY { get { return _INVOICE_CURRENCY; } set { _INVOICE_CURRENCY = value; } }
    public string EXCHANGE_RATE { get { return _EXCHANGE_RATE; } set { _EXCHANGE_RATE = value; } }
    public string CONTRACT_NO { get { return _CONTRACT_NO; } set { _CONTRACT_NO = value; } }
    public string TERMS { get { return _TERMS; } set { _TERMS = value; } }
    public string BUYER { get { return _BUYER; } set { _BUYER = value; } }
    public string BUYER_NAME { get { return _BUYER_NAME; } set { _BUYER_NAME = value; } }
    public string BUYER_ADDRESS { get { return _BUYER_ADDRESS; } set { _BUYER_ADDRESS = value; } }
    public string BUYER_ADDRESS1 { get { return _BUYER_ADDRESS1; } set { _BUYER_ADDRESS1 = value; } }
    public string BUYER_ADDRESS2 { get { return _BUYER_ADDRESS2; } set { _BUYER_ADDRESS2 = value; } }
    public string BUYER_ADDRESS3 { get { return _BUYER_ADDRESS3; } set { _BUYER_ADDRESS3 = value; } }
    public string BUYER_ADDRESS4 { get { return _BUYER_ADDRESS4; } set { _BUYER_ADDRESS4 = value; } }
    public string COMMISSION_RATE { get { return _COMMISSION_RATE; } set { _COMMISSION_RATE = value; } }
    public string COMMISSION_CHARGES { get { return _COMMISSION_CHARGES; } set { _COMMISSION_CHARGES = value; } }
    public string COMMISSION_CURRENCY { get { return _COMMISSION_CURRENCY; } set { _COMMISSION_CURRENCY = value; } }
    public string FOB_RATE { get { return _FOB_RATE; } set { _FOB_RATE = value; } }
    public string FOB_CHARGES { get { return _FOB_CHARGES; } set { _FOB_CHARGES = value; } }
    public string FOB_CURRENCY { get { return _FOB_CURRENCY; } set { _FOB_CURRENCY = value; } }
    public string PACKMISC_RATE { get { return _PACKMISC_RATE; } set { _PACKMISC_RATE = value; } }
    public string PACKMISC_CHARGES { get { return _PACKMISC_CHARGES; } set { _PACKMISC_CHARGES = value; } }
    public string PACKMISC_CURRENCY { get { return _PACKMISC_CURRENCY; } set { _PACKMISC_CURRENCY = value; } }
    public string OTHER_DEDUCTION_RATE { get { return _OTHER_DEDUCTION_RATE; } set { _OTHER_DEDUCTION_RATE = value; } }
    public string OTHER_DEDUCTION_CHARGES { get { return _OTHER_DEDUCTION_CHARGES; } set { _OTHER_DEDUCTION_CHARGES = value; } }
    public string OTHER_DEDUCTION_CURRENCY { get { return _OTHER_DEDUCTION_CURRENCY; } set { _OTHER_DEDUCTION_CURRENCY = value; } }
    public string FREIGHT_RATE { get { return _FREIGHT_RATE; } set { _FREIGHT_RATE = value; } }
    public string FREIGHT_CHARGES { get { return _FREIGHT_CHARGES; } set { _FREIGHT_CHARGES = value; } }
    
    public string FREIGHT_CURRENCY { get { return _FREIGHT_CURRENCY; } set { _FREIGHT_CURRENCY = value; } }
    public string FREIGHT_EXRATE { get { return _FREIGHT_EXRATE; } set { _FREIGHT_EXRATE = value; } }

    public string INSURANCE_RATE { get { return _INSURANCE_RATE; } set { _INSURANCE_RATE = value; } }

    public string INSURANCE_CHARGES { get { return _INSURANCE_CHARGES; } set { _INSURANCE_CHARGES = value; } }
    public string INSURANCE_CURRENCY { get { return _INSURANCE_CURRENCY; } set { _INSURANCE_CURRENCY = value; } }
    public string INSURANCE_EXRATE { get { return _INSURANCE_EXRATE; } set { _INSURANCE_EXRATE = value; } }
    public string WHEATHER_UNIT_PRICE { get { return _WHEATHER_UNIT_PRICE; } set { _WHEATHER_UNIT_PRICE = value; } }
  
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
    public string NON_STD_EFFECT_DT_EXP { get { return _NON_STD_EFFECT_DT_EXP; } set { _NON_STD_EFFECT_DT_EXP = value; } }
    public string NON_STD_BANKNAME { get { return _NON_STD_BANKNAME; } set { _NON_STD_BANKNAME = value; } }
    public string NON_STD_CERTIFICATE_NO { get { return _NON_STD_CERTIFICATE_NO; } set { _NON_STD_CERTIFICATE_NO = value; } }
    public string NON_STD_CERTIFICATE_DATE { get { return _NON_STD_CERTIFICATE_DATE; } set { _NON_STD_CERTIFICATE_DATE = value; } }
    public string DOC_RECD_DATE { get { return _DOC_RECD_DATE; } set { _DOC_RECD_DATE = value; } }

    public string AMENDMENT_TYPE { get { return _AMENDMENT_TYPE; } set { _AMENDMENT_TYPE = value; } }
    public string AMENDMENT_STATUS { get { return _AMENDMENT_STATUS; } set { _AMENDMENT_STATUS = value; } }
    public string JOBNO_PS { get { return _JOBNO_PS; } set { _JOBNO_PS = value; } }

    public string CONTRACT_DATE { get { return _CONTRACT_DATE; } set { _CONTRACT_DATE = value; } }
    
    #endregion

    #region Insert & Update

    public DataSet Export_Invoice_Details_insertupdate()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[76];

             param[0] = new SqlParameter("@INVOICE_ID", INVOICE_ID);

            param[1] = new SqlParameter("@JOBNO", JOBNO);

            param[2] = new SqlParameter("@JOBDATE", DateTime.Parse(JOBDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[3] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);

            param[4] = new SqlParameter("@INVOICE_NO", INVOICE_NO);

            param[5] = new SqlParameter("@INVOICE_DATE", DateTime.Parse(INVOICE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[6] = new SqlParameter("@PAYMENT_METHOD", PAYMENT_METHOD);

            param[7] = new SqlParameter("@PERIOD_PAYMENT", PERIOD_PAYMENT);

            param[8] = new SqlParameter("@INVOICE_VALUE", INVOICE_VALUE);

            param[9] = new SqlParameter("@INVOICE_CURRENCY", INVOICE_CURRENCY);

            param[10] = new SqlParameter("@EXCHANGE_RATE", EXCHANGE_RATE);

            param[11] = new SqlParameter("@CONTRACT_NO", CONTRACT_NO);

            param[12] = new SqlParameter("@TERMS", TERMS);

            param[13] = new SqlParameter("@BUYER", BUYER);

            param[14] = new SqlParameter("@BUYER_NAME", BUYER_NAME);

            param[15] = new SqlParameter("@BUYER_ADDRESS", BUYER_ADDRESS);

            param[16] = new SqlParameter("@BUYER_ADDRESS1", BUYER_ADDRESS1);

            param[17] = new SqlParameter("@BUYER_ADDRESS2", BUYER_ADDRESS2);

            param[18] = new SqlParameter("@BUYER_ADDRESS3", BUYER_ADDRESS3);

            param[19] = new SqlParameter("@BUYER_ADDRESS4", BUYER_ADDRESS4);

            param[20] = new SqlParameter("@COMMISSION_RATE", COMMISSION_RATE);

            param[21] = new SqlParameter("@COMMISSION_CHARGES", COMMISSION_CHARGES);

            param[22] = new SqlParameter("@COMMISSION_CURRENCY", COMMISSION_CURRENCY);

            param[23] = new SqlParameter("@FOB_RATE", FOB_RATE);

            param[24] = new SqlParameter("@FOB_CHARGES", FOB_CHARGES);

            param[25] = new SqlParameter("@FOB_CURRENCY", FOB_CURRENCY);

            param[26] = new SqlParameter("@PACKMISC_RATE", PACKMISC_RATE);

            param[27] = new SqlParameter("@PACKMISC_CHARGES", PACKMISC_CHARGES);

            param[28] = new SqlParameter("@PACKMISC_CURRENCY", PACKMISC_CURRENCY);

            param[29] = new SqlParameter("@OTHER_DEDUCTION_RATE", OTHER_DEDUCTION_RATE);

            param[30] = new SqlParameter("@OTHER_DEDUCTION_CHARGES", OTHER_DEDUCTION_CHARGES);

            param[31] = new SqlParameter("@OTHER_DEDUCTION_CURRENCY", OTHER_DEDUCTION_CURRENCY);

            param[32] = new SqlParameter("@FREIGHT_RATE", FREIGHT_RATE);

            param[33] = new SqlParameter("@FREIGHT_CHARGES", FREIGHT_CHARGES);

            param[34] = new SqlParameter("@FREIGHT_CURRENCY", FREIGHT_CURRENCY);

            param[35] = new SqlParameter("@INSURANCE_RATE", INSURANCE_RATE);

            param[36] = new SqlParameter("@INSURANCE_CHARGES", INSURANCE_CHARGES);

            param[37] = new SqlParameter("@INSURANCE_CURRENCY", INSURANCE_CURRENCY);

            param[38] = new SqlParameter("@WHEATHER_UNIT_PRICE", WHEATHER_UNIT_PRICE);

            param[39] = new SqlParameter("@USER_ID", USER_ID);

            param[40] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);

            param[41] = new SqlParameter("@YEAR", YEAR);

            param[42] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[53] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[43] = new SqlParameter("@Mflag", flag);

            param[44] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[44].Direction = ParameterDirection.Output;

            param[45] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);

            param[45].Direction = ParameterDirection.Output;
            param[46] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[46].Direction = ParameterDirection.Output;
            param[47] = new SqlParameter("@FREIGHT_EXRATE", FREIGHT_EXRATE);

            param[48] = new SqlParameter("@INSURANCE_EXRATE", INSURANCE_EXRATE);
            if (string.IsNullOrEmpty(NON_STD_EFFECT_DT_EXP))
            {
                NON_STD_EFFECT_DT_EXP = "01/01/1900";
            }
            if (string.IsNullOrEmpty(NON_STD_CERTIFICATE_DATE))
            {
                NON_STD_CERTIFICATE_DATE = "01/01/1900";
            }
            param[49] = new SqlParameter("@NON_STD_EFFECT_DT_EXP", DateTime.Parse(NON_STD_EFFECT_DT_EXP, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[50] = new SqlParameter("@NON_STD_BANKNAME", NON_STD_BANKNAME);
            param[51] = new SqlParameter("@NON_STD_CERTIFICATE_NO", NON_STD_CERTIFICATE_NO);
            param[52] = new SqlParameter("@NON_STD_CERTIFICATE_DATE", DateTime.Parse(NON_STD_CERTIFICATE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[64] = new SqlParameter("@TERMS_PLACE", TERMS_PLACE);
            param[54] = new SqlParameter("@THIRDPARTY_NAME", THIRDPARTY_NAME);
            param[55] = new SqlParameter("@THIRDPARTY_ADD1", THIRDPARTY_ADD1);

            param[56] = new SqlParameter("@THIRDPARTY_ADD2", THIRDPARTY_ADD2);
            param[57] = new SqlParameter("@THIRDPARTY_CITY", THIRDPARTY_CITY);
            param[58] = new SqlParameter("@T_PARTY_COUNTRY_SUB_DIV", T_PARTY_COUNTRY_SUB_DIV);
            param[59] = new SqlParameter("@T_PARTY_COUNTRY_CODE", T_PARTY_COUNTRY_CODE);
            param[60] = new SqlParameter("@T_PARTY_PIN", T_PARTY_PIN);
            param[61] = new SqlParameter("@AUTHORIZED_ECONOMIC_OPERATOR_CODE", AUTHORIZED_ECONOMIC_OPERATOR_CODE);
            param[62] = new SqlParameter("@A_E_O_COUNTRY", A_E_O_COUNTRY);
            param[63] = new SqlParameter("@AUTHORIZED_ECONOMIC_OPERATOR", AUTHORIZED_ECONOMIC_OPERATOR);
            param[65] = new SqlParameter("@DOC_RECD_DATE", DOC_RECD_DATE);

            param[66] = new SqlParameter("@AMENDMENT_TYPE", AMENDMENT_TYPE);
            param[67] = new SqlParameter("@AMENDMENT_STATUS", AMENDMENT_STATUS);
            param[68] = new SqlParameter("@JOBNO_PS", JOBNO_PS);

            //param[69] = new SqlParameter("@CONTRACT_DATE", DateTime.Parse(CONTRACT_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            //param[69] = new SqlParameter("@CONTRACT_DATE", string.IsNullOrWhiteSpace(CONTRACT_DATE) ? (object)DBNull.Value : (object)DateTime.Parse(CONTRACT_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            if (CONTRACT_DATE == "00:00:00" || string.IsNullOrWhiteSpace(CONTRACT_DATE) || string.IsNullOrWhiteSpace(CONTRACT_DATE.Replace("&nbsp;", "").Trim()))
            {
                CONTRACT_DATE = "01/01/1900";
            }
            param[69] = new SqlParameter("@CONTRACT_DATE", DateTime.Parse(CONTRACT_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));


            param[70] = new SqlParameter("@NOTIFY_NAME", NOTIFY_NAME); 
            param[71] = new SqlParameter("@NOTIFY_ADDRESS_1", NOTIFY_ADDRESS_1);
            param[72] = new SqlParameter("@NOTIFY_ADDRESS_2", NOTIFY_ADDRESS_2);
            param[73] = new SqlParameter("@NOTIFY_ADDRESS_3", NOTIFY_ADDRESS_3);
            param[74] = new SqlParameter("@NOTIFY_ADDRESS_COUNTRY", NOTIFY_ADDRESS_COUNTRY);

            ds=SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_INVOICE_DETAILS_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[44].Value.ToString());
            string err = param[45].Value.ToString();

            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[46].Value.ToString());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {

            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    #endregion

    public DataSet RetrieveAll_Invoice_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[7] = new SqlParameter("@INVOICE_NO", INVOICE_NO);
            param[8] = new SqlParameter("@TERMS", TERMS);
            param[9] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);

            param[1] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[2] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[2].Direction = ParameterDirection.Output;
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            param[4] = new SqlParameter("@ALL_FREIGHT_TOTAL", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ALL_INSURANCE_TOTAL", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@Mflag", flag);

            if (flag == "INVOICE_NO")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_INVOICE_DETAILS_SELECT", param);

            }
            else if (flag == "SELECT" || flag=="Bind_Invoice_DropdownSelect")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_INVOICE_DETAILS_SELECT", param);

            }
            else if (flag == "INVOICE_VALUE")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_INVOICE_DETAILS_SELECT", param);

            }
            else if (flag == "Delete" || flag == "Delete_Excel")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_INVOICE_DETAILS_SELECT", param);
                result = Convert.ToInt32(param[2].Value.ToString());

            }
            else if (flag == "Distinct_Invoice_Currency_List" || flag == "Update_Invoice_exRate_Currency_List")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_INVOICE_DETAILS_SELECT", param);
                string s = param[3].Value.ToString();

                result = Convert.ToInt32(param[2].Value.ToString());

            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_INVOICE_DETAILS_SELECT", param);

                //string Freight = param[4].Value.ToString();
                //string Insurance = param[5].Value.ToString();

                //if (Freight != "")
                //{
                //    //ALL_FREIGHT_TOTAL = Convert.ToDouble(param[4].Value.ToString());
                //    //ALL_INSURANCE_TOTAL = Convert.ToDouble(param[5].Value.ToString());

                //    ALL_FREIGHT_TOTAL = Convert.ToDouble(Freight);

                //}
                //if (Insurance != "")
                //{
                //    //ALL_FREIGHT_TOTAL = Convert.ToDouble(param[4].Value.ToString());
                //    //ALL_INSURANCE_TOTAL = Convert.ToDouble(param[5].Value.ToString());

                //    ALL_INSURANCE_TOTAL = Convert.ToDouble(Insurance);

                //}
            }
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Inv_result = "1";

                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);


        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    //public DataSet Bulk_Item_Excel_Upload(DataSet ds,string mode)
    //{
    //    try
    //    {


    //        SqlParameter[] param = new SqlParameter[15];

    //        param[0] = new SqlParameter("@Mode", mode);

    //        //param[1] = new SqlParameter("@Emailid", Emailid);
    //        param[2] = new SqlParameter("@InvoiceDetails", ds.GetXml());
    //       // param[3] = new SqlParameter("@COMPANY_ID", COMPANY_ID);
    //        //param[4] = new SqlParameter("@USER_CREATION_ID", USER_CREATION_ID);
    //       // param[5] = new SqlParameter("@CUSTOM_HOUSE", CUSTOM_HOUSE_ID);

    //        param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
    //        param[8].Direction = ParameterDirection.Output;
    //        param[11] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
    //        param[11].Direction = ParameterDirection.Output;
    //        SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXPORT_BULK_ITEM_EXCEL_UPLOAD", param);
    //        string s = param[8].Value.ToString();
    //        result = Convert.ToInt32(param[11].Value.ToString());


    //    }
    //    catch (Exception ex)
    //    {
    //        ErrorLogs er = new ErrorLogs();
    //        er.makeLog(ex.Message);

    //    }
    //    return ds;
    //}


    public DataSet Bulk_Item_Excel_Upload1(DataSet ds, string mode)
    {
        // String strConnString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

        SqlConnection con = new SqlConnection(HttpContext.Current.Session["currentcomp_db"].ToString());

        SqlCommand cmd = new SqlCommand();

        cmd.CommandTimeout = 0;
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.CommandText = "EXPORT_BULK_ITEM_EXCEL_UPLOAD";

        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 100).Value = mode.Trim();

        cmd.Parameters.Add("@InvoiceDetails", SqlDbType.Xml).Value = ds.GetXml();



        cmd.Parameters.Add("@ErrorMsg", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@Mstatus", SqlDbType.Int, 10).Direction = ParameterDirection.Output;

        cmd.Connection = con;

        try
        {

            con.Open();

            cmd.ExecuteNonQuery();

            result = Convert.ToInt32(cmd.Parameters["@Mstatus"].Value.ToString());

            //lblMessage.Text = "Record inserted successfully. ID = " + id;

        }

        catch (Exception ex)
        {

            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);

        }

        finally
        {

            con.Close();

            con.Dispose();

        }
        return ds;
    }
    public void Bulk_Item_Excel_Upload(DataTable dt, DataTable dt1, DataTable dt2, DataTable dt3, string mode)
    {
        SqlConnection conn;
        try
        {
            

            //using (SqlBulkCopy bulkCopy = new SqlBulkCopy(HttpContext.Current.Session["currentcomp_db"].ToString(), SqlBulkCopyOptions.KeepIdentity))
            //{
            cmd = new SqlCommand();

            conn = new SqlConnection(HttpContext.Current.Session["currentcomp_db"].ToString());

            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "EXPORT_BULK_ITEM_EXCEL_UPLOAD_NEW";

            cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 100).Value = mode.Trim();

            cmd.Parameters.Add("@InvoiceDetails", SqlDbType.Xml).Value = ConvertDatatableToXML(dt);
            cmd.Parameters.Add("@ItemDetails", SqlDbType.Xml).Value = ConvertDatatableToXML(dt1);
            cmd.Parameters.Add("@DrawbackDetails", SqlDbType.Xml).Value = ConvertDatatableToXML(dt2);
            cmd.Parameters.Add("@LicenseDetails", SqlDbType.Xml).Value = ConvertDatatableToXML(dt3);

            cmd.Parameters.Add("@ErrorMsg", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Mstatus", SqlDbType.Int, 10).Direction = ParameterDirection.Output;

            cmd.Connection = conn;

            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            string result1 = cmd.Parameters["@ErrorMsg"].Value.ToString();

            result = Convert.ToInt32(cmd.Parameters["@Mstatus"].Value.ToString());
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(HttpContext.Current.Session["currentcomp_db"].ToString(), SqlBulkCopyOptions.KeepIdentity))
            {
                bulkCopy.DestinationTableName = "EXPORT_INVOICE_DETAILS";
                bulkCopy.WriteToServer(ds.Tables[0]);
                bulkCopy.DestinationTableName = "EXPORT_ITEM_DETAILS";
                bulkCopy.WriteToServer(ds.Tables[1]);
                bulkCopy.DestinationTableName = "EXPORT_DRAWBACK_DETAILS";
                bulkCopy.WriteToServer(ds.Tables[2]);
                bulkCopy.DestinationTableName = "EXPORT_LICENSE_DETAILS";

                DataTable dtt = new DataTable();

                dtt = ds.Tables[3];
                DataView dv=new DataView(ds.Tables[3]);
                DataTable d_new = dtt.DefaultView.ToTable(true, "LICENSE_ID", "JOBNO", "INV_SL_NO", "ITEM_SL_NO", "SCHEME_CODE", "SCHEME", "LICENSE_R_SL_NO", "LICENSE_NO", "LICENSE_DATE", "USER_ID", "Column1", "STATUS", "BRANCH_CODE", "YEAR", "WORKING_PERIOD");

                DataSet dss_License = new DataSet();
                dss_License.Tables.Add(d_new);
                
                bulkCopy.WriteToServer(dss_License.Tables[0]);
                bulkCopy.DestinationTableName = "EXPORT_LICENSE_IMP_EXP_DETAILS";
                bulkCopy.WriteToServer(ds.Tables[4]);
                bulkCopy.Close();
            }
            conn.Dispose();
            conn.Close();
            
        }

        catch (Exception ex)
        {

            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);

        }

        finally
        {

        }

        //return ds;
    }
    
    public string ConvertDatatableToXML(DataTable dt)
    {
        MemoryStream str = new MemoryStream();
        dt.WriteXml(str, true);
        str.Seek(0, SeekOrigin.Begin);
        StreamReader sr = new StreamReader(str);
        string xmlstr;
        xmlstr = sr.ReadToEnd();
        return (xmlstr);
    }
}