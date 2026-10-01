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
using BussinessObject;


public class Delivery_Challan_Carchit
{
  
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
    public int result, UPDATE_ID = 0, UpdateId=0;

    # region Private Attributes


    private string _DC_ID;
	private string _JOBNO;
	private string _FILE_REF_NO;
	private string _CHA_NO;
	private string _CHA_NAME;
	private string _CHA_ADDRESS;
	private string _PHONE;
	private string _TELEX;
	private string _BE_No;
	private string _BE_DATE;
	private string _I_A_NO;
	private string _I_A_DATE;
	private string _WAYBILL_NO;
	private string _WAYBILL_DATE;
	private string _VEHICLE;
	private string _STEAMER;
	private string _INVOICE_NO;
	private string _QUANTITY;
	private string _DESC_GOODS;
	private string _MARKSNOS;
	private string _NO_OF_PACKAGE;
	private string _CONDITION_GOODS;
	private string _TRANSPORTER_NAME;
	private string _DRIVER_NAME;
	private string _PLACE_OF_DESPATCH;
	private string _GODOWN_ADDRESS;
	private string _DELIVERED_PERSON_NAME;
	private string _DELIVERED_PERSON_ADDRESS1;
	private string _DELIVERED_PERSON_ADDRESS2;
	private string _DELIVERED_PERSON_ADDRESS3;
	private string _BE_IA_QTY;
	private string _CLEAR_TILL_DATE;
	private string _BALANCE;
	private string _DATE_OF_SIGNATURE;
	private string _USER_ID;
	
	private string _BRANCH_CODE;
	private string _YEAR;
    private string _WORKING_PERIOD;   
    private string _flag;   
    private string _BRANCH_COMMON;
    private string _Ename;
    private string _startRowIndex;
    private string _maximumRows;
    private string _totalRows;
    private string _JOBNO_PS;

    #endregion

    # region Public Attributes
    
    public string DC_ID { get { return _DC_ID; } set { _DC_ID = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string FILE_REF_NO { get { return _FILE_REF_NO; } set { _FILE_REF_NO = value; } }
    public string PHONE { get { return _PHONE; } set { _PHONE = value; } }
    public string CHA_NAME { get { return _CHA_NAME; } set { _CHA_NAME = value; } }
    public string CHA_NO { get { return _CHA_NO; } set { _CHA_NO = value; } }
    public string CHA_ADDRESS { get { return _CHA_ADDRESS; } set { _CHA_ADDRESS = value; } }
    public string TELEX { get { return _TELEX; } set { _TELEX = value; } }
    public string BE_No { get { return _BE_No; } set { _BE_No = value; } }
    public string BE_DATE { get { return _BE_DATE; } set { _BE_DATE = value; } }
    public string I_A_NO { get { return _I_A_NO; } set { _I_A_NO = value; } }
    public string I_A_DATE { get { return _I_A_DATE; } set { _I_A_DATE = value; } }

    public string WAYBILL_NO { get { return _WAYBILL_NO; } set { _WAYBILL_NO = value; } }
    public string WAYBILL_DATE { get { return _WAYBILL_DATE; } set { _WAYBILL_DATE = value; } }
    public string VEHICLE { get { return _VEHICLE; } set { _VEHICLE = value; } }
    public string STEAMER { get { return _STEAMER; } set { _STEAMER   = value; } }
    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }

    public string QUANTITY { get { return _QUANTITY; } set { _QUANTITY = value; } }
    public string DESC_GOODS { get { return _DESC_GOODS; } set { _DESC_GOODS = value; } }
    public string MARKSNOS { get { return _MARKSNOS; } set { _MARKSNOS = value; } }
    public string NO_OF_PACKAGE { get { return _NO_OF_PACKAGE; } set { _NO_OF_PACKAGE = value; } }
    public string CONDITION_GOODS { get { return _CONDITION_GOODS; } set { _CONDITION_GOODS = value; } }
    public string TRANSPORTER_NAME { get { return _TRANSPORTER_NAME; } set { _TRANSPORTER_NAME = value; } }
    public string DRIVER_NAME { get { return _DRIVER_NAME; } set { _DRIVER_NAME = value; } }
    public string PLACE_OF_DESPATCH { get { return _PLACE_OF_DESPATCH; } set { _PLACE_OF_DESPATCH = value; } }
    public string GODOWN_ADDRESS { get { return _GODOWN_ADDRESS; } set { _GODOWN_ADDRESS = value; } }
     
    public string DELIVERED_PERSON_NAME { get { return _DELIVERED_PERSON_NAME; } set { _DELIVERED_PERSON_NAME = value; } }
    public string DELIVERED_PERSON_ADDRESS1 { get { return _DELIVERED_PERSON_ADDRESS1; } set { _DELIVERED_PERSON_ADDRESS1 = value; } }
    public string DELIVERED_PERSON_ADDRESS2 { get { return _DELIVERED_PERSON_ADDRESS2; } set { _DELIVERED_PERSON_ADDRESS2 = value; } }
    public string DELIVERED_PERSON_ADDRESS3 { get { return _DELIVERED_PERSON_ADDRESS3; } set { _DELIVERED_PERSON_ADDRESS3 = value; } }
    public string BE_IA_QTY { get { return _BE_IA_QTY; } set { _BE_IA_QTY = value; } }
    public string CLEAR_TILL_DATE { get { return _CLEAR_TILL_DATE; } set { _CLEAR_TILL_DATE = value; } }
    public string BALANCE { get { return _BALANCE; } set { _BALANCE = value; } }
    public string DATE_OF_SIGNATURE { get { return _DATE_OF_SIGNATURE; } set { _DATE_OF_SIGNATURE = value; } }
    public string JOBNO_PS { get { return _JOBNO_PS; } set { _JOBNO_PS = value; } }
    
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

    #endregion
  
   

    public DataSet Delivery_Challan_Carchit_Insert_Update()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[55];

            param[0] = new SqlParameter("@DC_ID", DC_ID);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@FILE_REF_NO", FILE_REF_NO);
            //param[3] = new SqlParameter("@DC_DATE", DateTime.Parse(DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[4] = new SqlParameter("@CHA_NO", CHA_NO);
            param[5] = new SqlParameter("@CHA_NAME", CHA_NAME);
            param[6] = new SqlParameter("@CHA_ADDRESS", CHA_ADDRESS);
            param[7] = new SqlParameter("@PHONE", PHONE);
            param[8] = new SqlParameter("@TELEX", TELEX);
            param[9] = new SqlParameter("@BE_No", BE_No);

            param[10] = new SqlParameter("@BE_DATE", BE_DATE);
            param[11] = new SqlParameter("@I_A_NO", I_A_NO);
            param[12] = new SqlParameter("@I_A_DATE", I_A_DATE);
            param[13] = new SqlParameter("@WAYBILL_NO", WAYBILL_NO);
            param[14] = new SqlParameter("@WAYBILL_DATE", WAYBILL_DATE);

            param[15] = new SqlParameter("@VEHICLE", VEHICLE);
            param[16] = new SqlParameter("@STEAMER", STEAMER);
            param[17] = new SqlParameter("@INVOICE_NO", INVOICE_NO);

            param[18] = new SqlParameter("@QUANTITY", QUANTITY);
            param[19] = new SqlParameter("@DESC_GOODS", DESC_GOODS);
            param[20] = new SqlParameter("@MARKSNOS", MARKSNOS);
            param[21] = new SqlParameter("@NO_OF_PACKAGE", NO_OF_PACKAGE);
            param[22] = new SqlParameter("@CONDITION_GOODS", CONDITION_GOODS);
            param[23] = new SqlParameter("@TRANSPORTER_NAME", TRANSPORTER_NAME);
            param[24] = new SqlParameter("@DRIVER_NAME", DRIVER_NAME);
            param[25] = new SqlParameter("@PLACE_OF_DESPATCH", PLACE_OF_DESPATCH);
            param[26] = new SqlParameter("@GODOWN_ADDRESS", GODOWN_ADDRESS);
            param[35] = new SqlParameter("@DELIVERED_PERSON_NAME", DELIVERED_PERSON_NAME);

            param[36] = new SqlParameter("@DELIVERED_PERSON_ADDRESS1", DELIVERED_PERSON_ADDRESS1);
            param[37] = new SqlParameter("@DELIVERED_PERSON_ADDRESS2", DELIVERED_PERSON_ADDRESS2);
            param[38] = new SqlParameter("@DELIVERED_PERSON_ADDRESS3", DELIVERED_PERSON_ADDRESS3);
            param[39] = new SqlParameter("@BE_IA_QTY", BE_IA_QTY);
            param[40] = new SqlParameter("@CLEAR_TILL_DATE", CLEAR_TILL_DATE);
            param[41] = new SqlParameter("@BALANCE", BALANCE);
            param[42] = new SqlParameter("@DATE_OF_SIGNATURE", DATE_OF_SIGNATURE);
            param[43] = new SqlParameter("@JOBNO_PS", JOBNO_PS);

            param[27] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[28] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[29] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[30] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());

            param[31] = new SqlParameter("@Mflag", flag);
            param[32] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[32].Direction = ParameterDirection.Output;

            param[33] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[33].Direction = ParameterDirection.Output;

            param[34] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[34].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "DELIVERY_CHALLAN_CARCHIT_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[32].Value.ToString());
            string err = param[33].Value.ToString();
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[34].Value.ToString());

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