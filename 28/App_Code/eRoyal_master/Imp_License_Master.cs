using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Net;
/// <summary>
/// Summary description for Licence_Details
/// </summary>
public class Imp_License_Master
{

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet dtuser = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();
    SqlDataReader dr;
    SqlCommand cmd;
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);


    #region Private_Attributes

    private string _LICENSE_ID,
                    _REGISTRATION_NO,
                    _REGISTRATION_DATE,
                    _LICENSE_NO,
                    _LICENSE_DATE,
                    _EXCEMPTION,
                    _LICENSE_TYPE,
                    _TOTAL_DEBIT_AMT,
                    _REMAINING_AMT,
                    _TOTAL_DEBIT_QTY,
                    _UNIT_QTY,
                    _LICENSE_ITEM_NO,
                    _PORT_OF_LICENSE,
                    _USER_ID,
                    _DATE_TIME,
                    _STATUS,
                    _BRANCH_CODE,
                    _YEAR,
                    _WORKING_PERIOD,
                    _MODIFIEDBY,
                    _MODIFIEDON,
                    _flag,
                    _REMAINING_QTY,
                    _PARTY_NAME,
                    _LICENSE_DESC,
                    _SINGLE_DUTY_Y_N,
                    _TOTAL_FC_VALUE,
                    _REMAINING_FC,
                    _EX_RATE,
                    _TOTAL_CIF_VALUE,
                    _REMAINING_CIF,
                    _LICENSE_CURRENCY,
                    _LICENSE_BROKER_NAME,
                    _LICENSE_TRANSFERED_TO,
                    _LICENSE_RECEIVED_DATE,
                    _BOND_NO,
                    _BOND_DATE,
                    _BOND_TYPE,
                    _DATE_OF_SURRENDER,
                    _PART_NO,
                    _LICENSE_EXPIRY_DATE,
                    _BOND_LOCATION;
   
  
    public int licen_slno;

    #endregion
    #region Public_Attributes
    
    //LICENCE_DETAILS
    public string LICENSE_ID { get { return _LICENSE_ID; } set { _LICENSE_ID = value; } }
    public string REGISTRATION_NO { get { return _REGISTRATION_NO; } set { _REGISTRATION_NO = value; } }
    public string REGISTRATION_DATE { get { return _REGISTRATION_DATE; } set { _REGISTRATION_DATE = value; } }
    public string LICENSE_NO { get { return _LICENSE_NO; } set { _LICENSE_NO = value; } }
    public string LICENSE_DATE { get { return _LICENSE_DATE; } set { _LICENSE_DATE = value; } }
    public string EXCEMPTION { get { return _EXCEMPTION; } set { _EXCEMPTION = value; } }
    public string LICENSE_TYPE { get { return _LICENSE_TYPE; } set { _LICENSE_TYPE = value; } }
    public string TOTAL_DEBIT_AMT { get { return _TOTAL_DEBIT_AMT; } set { _TOTAL_DEBIT_AMT = value; } }
    public string REMAINING_AMT { get { return _REMAINING_AMT; } set { _REMAINING_AMT = value; } }
    public string TOTAL_DEBIT_QTY { get { return _TOTAL_DEBIT_QTY; } set { _TOTAL_DEBIT_QTY = value; } }
    public string UNIT_QTY { get { return _UNIT_QTY; } set { _UNIT_QTY = value; } }
    public string LICENSE_ITEM_NO { get { return _LICENSE_ITEM_NO; } set { _LICENSE_ITEM_NO = value; } }
    public string PORT_OF_LICENSE { get { return _PORT_OF_LICENSE; } set { _PORT_OF_LICENSE = value; } }
    
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string DATE_TIME { get { return _DATE_TIME; } set { _DATE_TIME = value; } }
    public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }

    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }                      
    public string MODIFIEDBY { get { return _MODIFIEDBY; } set { _MODIFIEDBY = value; } }
    public string MODIFIEDON { get { return _MODIFIEDON; } set { _MODIFIEDON = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }
    public string REMAINING_QTY { get { return _REMAINING_QTY; } set { _REMAINING_QTY = value; } }
    public string PARTY_NAME { get { return _PARTY_NAME; } set { _PARTY_NAME = value; } }
    public string LICENSE_DESC { get { return _LICENSE_DESC; } set { _LICENSE_DESC = value; } }
    public string SINGLE_DUTY_Y_N { get { return _SINGLE_DUTY_Y_N; } set { _SINGLE_DUTY_Y_N = value; } }
    public string TOTAL_FC_VALUE { get { return _TOTAL_FC_VALUE; } set { _TOTAL_FC_VALUE = value; } }
    public string REMAINING_FC { get { return _REMAINING_FC; } set { _REMAINING_FC = value; } }
    public string EX_RATE { get { return _EX_RATE; } set { _EX_RATE = value; } }
    public string TOTAL_CIF_VALUE { get { return _TOTAL_CIF_VALUE; } set { _TOTAL_CIF_VALUE = value; } }
    public string REMAINING_CIF { get { return _REMAINING_CIF; } set { _REMAINING_CIF = value; } }
    public string LICENSE_CURRENCY { get { return _LICENSE_CURRENCY; } set { _LICENSE_CURRENCY = value; } }

    public string LICENSE_BROKER_NAME { get { return _LICENSE_BROKER_NAME; } set { _LICENSE_BROKER_NAME = value; } }
    public string LICENSE_TRANSFERED_TO { get { return _LICENSE_TRANSFERED_TO; } set { _LICENSE_TRANSFERED_TO = value; } }
    public string LICENSE_RECEIVED_DATE { get { return _LICENSE_RECEIVED_DATE; } set { _LICENSE_RECEIVED_DATE = value; } }
    public string BOND_NO { get { return _BOND_NO; } set { _BOND_NO = value; } }
    public string BOND_DATE { get { return _BOND_DATE; } set { _BOND_DATE = value; } }
    public string BOND_TYPE { get { return _BOND_TYPE; } set { _BOND_TYPE = value; } }
    public string DATE_OF_SURRENDER { get { return _DATE_OF_SURRENDER; } set { _DATE_OF_SURRENDER = value; } }
    public string PART_NO { get { return _PART_NO; } set { _PART_NO = value; } }
    public string LICENSE_EXPIRY_DATE { get { return _LICENSE_EXPIRY_DATE; } set { _LICENSE_EXPIRY_DATE = value; } }
    public string BOND_LOCATION { get { return _BOND_LOCATION; } set { _BOND_LOCATION = value; } }
  
   public int result, UPDATE_ID;
   
    #endregion

   public int Import_License_Master_Insert_update()
   {
       DataSet ds = new DataSet();
       try
       {
           //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
           SqlParameter[] param = new SqlParameter[45];

           param[0] = new SqlParameter("@LICENSE_ID", LICENSE_ID);
           param[1] = new SqlParameter("@REGISTRATION_NO", REGISTRATION_NO);

           param[2] = new SqlParameter("@REGISTRATION_DATE", DateTime.Parse(REGISTRATION_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
           param[3] = new SqlParameter("@LICENSE_NO", LICENSE_NO);
           param[4] = new SqlParameter("@LICENSE_DATE", DateTime.Parse(LICENSE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
           param[5] = new SqlParameter("@EXCEMPTION", EXCEMPTION);
           param[6] = new SqlParameter("@LICENSE_TYPE", LICENSE_TYPE);
           param[7] = new SqlParameter("@TOTAL_DEBIT_AMT", TOTAL_DEBIT_AMT);
           param[8] = new SqlParameter("@REMAINING_AMT", REMAINING_AMT);
           param[9] = new SqlParameter("@TOTAL_DEBIT_QTY", TOTAL_DEBIT_QTY);
           param[10] = new SqlParameter("@UNIT_QTY", UNIT_QTY);
           param[11] = new SqlParameter("@LICENSE_ITEM_NO", LICENSE_ITEM_NO);
           param[12] = new SqlParameter("@PORT_OF_LICENSE", PORT_OF_LICENSE);
           param[13] = new SqlParameter("@USER_ID", USER_ID);
           param[14] = new SqlParameter("@DATE_TIME", DateTime.Parse(DATE_TIME, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
           param[15] = new SqlParameter("@STATUS", STATUS);
           param[16] = new SqlParameter("@Mflag", flag);
           param[17] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
           param[18] = new SqlParameter("@YEAR", YEAR);
           param[19] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
           param[20] = new SqlParameter("@MODIFIEDBY", MODIFIEDBY);
           param[21] = new SqlParameter("@MODIFIEDON", DateTime.Parse(MODIFIEDON, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
           param[25] = new SqlParameter("@REMAINING_QTY", REMAINING_QTY);
           param[26] = new SqlParameter("@PARTY_NAME", PARTY_NAME);
           param[27] = new SqlParameter("@LICENSE_DESC", LICENSE_DESC);
           param[28] = new SqlParameter("@SINGLE_DUTY_Y_N", SINGLE_DUTY_Y_N);

           param[29] = new SqlParameter("@TOTAL_FC_VALUE", TOTAL_FC_VALUE);
           param[30] = new SqlParameter("@REMAINING_FC", REMAINING_FC);
           param[31] = new SqlParameter("@EX_RATE", EX_RATE);
           param[32] = new SqlParameter("@TOTAL_CIF_VALUE", TOTAL_CIF_VALUE);
           param[33] = new SqlParameter("@REMAINING_CIF", REMAINING_CIF);
           param[34] = new SqlParameter("@LICENSE_CURRENCY", LICENSE_CURRENCY);

           param[35] = new SqlParameter("@LICENSE_BROKER_NAME", LICENSE_BROKER_NAME);
           param[36] = new SqlParameter("@LICENSE_TRANSFERED_TO", LICENSE_TRANSFERED_TO);
           param[37] = new SqlParameter("@LICENSE_RECEIVED_DATE", LICENSE_RECEIVED_DATE);
           param[38] = new SqlParameter("@BOND_NO", BOND_NO);
           param[39] = new SqlParameter("@BOND_DATE", BOND_DATE);
           param[40] = new SqlParameter("@BOND_TYPE", BOND_TYPE);
           param[41] = new SqlParameter("@DATE_OF_SURRENDER", DATE_OF_SURRENDER);
           param[42] = new SqlParameter("@PART_NO", PART_NO);
           param[43] = new SqlParameter("@LICENSE_EXPIRY_DATE", LICENSE_EXPIRY_DATE);
           param[44] = new SqlParameter("@BOND_LOCATION", BOND_LOCATION);

           param[22] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
           param[22].Direction = ParameterDirection.Output;

           param[23] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
           param[23].Direction = ParameterDirection.Output;
           param[24] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
           param[24].Direction = ParameterDirection.Output;

           SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_LICENSE_MASTER_INSERT_UPDATE", param);

           result = Convert.ToInt32(param[22].Value.ToString());
           if (flag == "S")
               UPDATE_ID = Convert.ToInt32(param[24].Value.ToString());

       }
       catch (Exception ex)
       {
           er.makeLog(ex.Message);
       }
       return result;

   }



}