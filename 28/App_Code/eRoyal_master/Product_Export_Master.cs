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


public class Product_Export_Master
{
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet dtuser = new DataSet();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();
    SqlDataReader dr;
    SqlCommand cmd;
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

    public int i, result;


    public string _PRODUCT_EXPORT_ID, _PRODUCT_DESCRIPTION, _PRODUCT_RITC, _REWARD_YES_NO, _STR_YES_NO, _STR_CODE, _DBK_SL_NO, _REMARKS,_PARTNO;
    private string _flag;
    private string _startRowIndex;
    private string _maximumRows;
    private string _totalRows;
    private string _INFO_MSR;
    private string _INFO_UQC;

    public string PRODUCT_EXPORT_ID { get { return _PRODUCT_EXPORT_ID; } set { _PRODUCT_EXPORT_ID = value; } }
    public string PRODUCT_DESCRIPTION { get { return _PRODUCT_DESCRIPTION; } set { _PRODUCT_DESCRIPTION = value; } }
    public string PRODUCT_RITC { get { return _PRODUCT_RITC; } set { _PRODUCT_RITC = value; } }
    public string REWARD_YES_NO { get { return _REWARD_YES_NO; } set { _REWARD_YES_NO = value; } }
    public string STR_YES_NO { get { return _STR_YES_NO; } set { _STR_YES_NO = value; } }
    public string STR_CODE { get { return _STR_CODE; } set { _STR_CODE = value; } }
    public string DBK_SL_NO { get { return _DBK_SL_NO; } set { _DBK_SL_NO = value; } }
    public string REMARKS { get { return _REMARKS; } set { _REMARKS = value; } }
    public string PARTNO { get { return _PARTNO; } set { _PARTNO = value; } }


    public string flag { get { return _flag; } set { _flag = value; } }
    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }
    public string INFO_MSR { get { return _INFO_MSR; } set { _INFO_MSR = value; } }
    public string INFO_UQC { get { return _INFO_UQC; } set { _INFO_UQC = value; } }

    private string _JOBNO;
    private string _INV_SLNO;
    private string _ITEM_SLNO;
    private string _BRANCH_CODE;

    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string INV_SLNO { get { return _INV_SLNO; } set { _INV_SLNO = value; } }
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }

    #region EXPORT_PDF
    
    private string  _ID,_EXPORTER_NAME, _IEC_NO, _BRANCH_NO, _TYPE_OF_EXPORTER, _PRODUCT_PARTNO, _RITC_NO, _ITEM_DESC, _RODTEP, _CESS_YN, _SCHEME_CODE, _END_USE_OF_ITEM,
                    _UNDER_PTA_FTA, _IGST_PAYMENT, _IGST_RATE, _DBK_UNIT, _DBK_DECLARATION, _SQC_UOM, _ITEM_ACCESSORIES_DESC, _TP_EXPORTER_NAME, _TP_ITEM_IECCODE, _TP_BR_SLNO,
                    _TP_ADDRESS1, _TP_ADDRESS2, _TP_ADDRESS3, _TP_ADDRESS4, _TP_ADDRESS5, _GSTN_TYPE, _GSTN_ID, _MANUFACTURER_PRODUCER, _M_P_GROWER_CODE, _M_P_GROWER_ADD1, _M_P_GROWER_ADD2,
                    _M_P_GROWER_CITY, _M_P_GROWER_COUNTRY_SUBDIV, _M_P_GROWER_PIN, _M_P_GROWER_COUNTRY, _SOURCE_STATE, _TRANSIT_COUNTRY, _ACCESSORY_STATUS, _HAWB_NO, _TOTAL_PKGS, _ADCODE;

   

    public string ID { get { return _ID; } set { _ID = value; } }
    public string EXPORTER_NAME { get { return _EXPORTER_NAME; } set { _EXPORTER_NAME = value; } }
    public string IEC_NO { get { return _IEC_NO; } set { _IEC_NO = value; } }
    public string BRANCH_NO { get { return _BRANCH_NO; } set { _BRANCH_NO = value; } }
    public string TYPE_OF_EXPORTER { get { return _TYPE_OF_EXPORTER; } set { _TYPE_OF_EXPORTER = value; } }
    public string PRODUCT_PARTNO { get { return _PRODUCT_PARTNO; } set { _PRODUCT_PARTNO = value; } }
    public string RITC_NO { get { return _RITC_NO; } set { _RITC_NO = value; } }
    public string ITEM_DESC { get { return _ITEM_DESC; } set { _ITEM_DESC = value; } }
    public string RODTEP { get { return _RODTEP; } set { _RODTEP = value; } }
    public string CESS_YN { get { return _CESS_YN; } set { _CESS_YN = value; } }
    public string SCHEME_CODE { get { return _SCHEME_CODE; } set { _SCHEME_CODE = value; } }
    public string END_USE_OF_ITEM { get { return _END_USE_OF_ITEM; } set { _END_USE_OF_ITEM = value; } }
    public string UNDER_PTA_FTA { get { return _UNDER_PTA_FTA; } set { _UNDER_PTA_FTA = value; } }
    public string IGST_PAYMENT { get { return _IGST_PAYMENT; } set { _IGST_PAYMENT = value; } }
    public string IGST_RATE { get { return _IGST_RATE; } set { _IGST_RATE = value; } }
    public string DBK_UNIT { get { return _DBK_UNIT; } set { _DBK_UNIT = value; } }
    public string DBK_DECLARATION { get { return _DBK_DECLARATION; } set { _DBK_DECLARATION = value; } }
    public string SQC_UOM { get { return _SQC_UOM; } set { _SQC_UOM = value; } }
    public string ITEM_ACCESSORIES_DESC { get { return _ITEM_ACCESSORIES_DESC; } set { _ITEM_ACCESSORIES_DESC = value; } }
    public string TP_EXPORTER_NAME { get { return _TP_EXPORTER_NAME; } set { _TP_EXPORTER_NAME = value; } }
    public string TP_ITEM_IECCODE { get { return _TP_ITEM_IECCODE; } set { _TP_ITEM_IECCODE = value; } }
    public string TP_BR_SLNO { get { return _TP_BR_SLNO; } set { _TP_BR_SLNO = value; } }
    public string TP_ADDRESS1 { get { return _TP_ADDRESS1; } set { _TP_ADDRESS1 = value; } }
    public string TP_ADDRESS2 { get { return _TP_ADDRESS2; } set { _TP_ADDRESS2 = value; } }
    public string TP_ADDRESS3 { get { return _TP_ADDRESS3; } set { _TP_ADDRESS3 = value; } }
    public string TP_ADDRESS4 { get { return _TP_ADDRESS4; } set { _TP_ADDRESS4 = value; } }
    public string TP_ADDRESS5 { get { return _TP_ADDRESS5; } set { _TP_ADDRESS5 = value; } }
    public string GSTN_TYPE { get { return _GSTN_TYPE; } set { _GSTN_TYPE = value; } }
    public string GSTN_ID { get { return _GSTN_ID; } set { _GSTN_ID = value; } }
    public string MANUFACTURER_PRODUCER { get { return _MANUFACTURER_PRODUCER; } set { _MANUFACTURER_PRODUCER = value; } }
    public string M_P_GROWER_CODE { get { return _M_P_GROWER_CODE; } set { _M_P_GROWER_CODE = value; } }
    public string M_P_GROWER_ADD1 { get { return _M_P_GROWER_ADD1; } set { _M_P_GROWER_ADD1 = value; } }
    public string M_P_GROWER_ADD2 { get { return _M_P_GROWER_ADD2; } set { _M_P_GROWER_ADD2 = value; } }
    public string M_P_GROWER_CITY { get { return _M_P_GROWER_CITY; } set { _M_P_GROWER_CITY = value; } }
    public string M_P_GROWER_COUNTRY_SUBDIV { get { return _M_P_GROWER_COUNTRY_SUBDIV; } set { _M_P_GROWER_COUNTRY_SUBDIV = value; } }
    public string M_P_GROWER_PIN { get { return _M_P_GROWER_PIN; } set { _M_P_GROWER_PIN = value; } }
    public string M_P_GROWER_COUNTRY { get { return _M_P_GROWER_COUNTRY; } set { _M_P_GROWER_COUNTRY = value; } }
    public string SOURCE_STATE { get { return _SOURCE_STATE; } set { _SOURCE_STATE = value; } }
    public string TRANSIT_COUNTRY { get { return _TRANSIT_COUNTRY; } set { _TRANSIT_COUNTRY = value; } }
    public string ACCESSORY_STATUS { get { return _ACCESSORY_STATUS; } set { _ACCESSORY_STATUS = value; } }
    public string HAWB_NO { get { return _HAWB_NO; } set { _HAWB_NO = value; } }
    public string TOTAL_PKGS { get { return _TOTAL_PKGS; } set { _TOTAL_PKGS = value; } }
    public string ADCODE { get { return _ADCODE; } set { _ADCODE = value; } }

    #endregion EXPORT_PDF

    public int Product_Export_Insert_Update()
    {
        SqlParameter[] param = new SqlParameter[15];

        param[0] = new SqlParameter("@PRODUCT_EXPORT_ID",PRODUCT_EXPORT_ID);
        param[1] = new SqlParameter("@PRODUCT_DESCRIPTION", PRODUCT_DESCRIPTION);
        param[2] = new SqlParameter("@PRODUCT_RITC", PRODUCT_RITC);
        param[3] = new SqlParameter("@REWARD_YES_NO", REWARD_YES_NO);
        param[4] = new SqlParameter("@STR_YES_NO", STR_YES_NO);
        param[5] = new SqlParameter("@STR_CODE", STR_CODE);
        param[9] = new SqlParameter("@DBK_SL_NO", DBK_SL_NO);
        param[11] = new SqlParameter("@REMARKS", REMARKS);
        param[12] = new SqlParameter("@PARTNO", PARTNO);
        param[6] = new SqlParameter("@Mflag", flag);

        param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
        param[7].Direction = ParameterDirection.Output;

        param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[8].Direction = ParameterDirection.Output;

        param[10] = new SqlParameter("@Update_Id", SqlDbType.NVarChar, 1000);
        param[10].Direction = ParameterDirection.Output;

        SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_PRODUCT_EXPORT_MASTER_INSERT_UPDATE", param);

        result = Convert.ToInt32(param[7].Value.ToString());

        return result;
    }

    

    public DataSet Retrive_Export_ProductMaster()
    {
        SqlParameter[] param = new SqlParameter[20];


        param[0] = new SqlParameter("@PRODUCT_EXPORT_ID", PRODUCT_EXPORT_ID);
        param[1] = new SqlParameter("@PRODUCT_DESCRIPTION", PRODUCT_DESCRIPTION);
        param[2] = new SqlParameter("@PRODUCT_RITC", PRODUCT_RITC);
        param[12] = new SqlParameter("@PARTNO", PARTNO);

        param[3] = new SqlParameter("@name", flag);

        param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
        param[7].Direction = ParameterDirection.Output;

        param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[8].Direction = ParameterDirection.Output;
        param[9] = new SqlParameter("@startRowIndex", startRowIndex);

        param[10] = new SqlParameter("@maximumRows", maximumRows);

        param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
        param[11].Direction = ParameterDirection.Output;


        if (flag == "Select_bind_id" || flag=="delete")
        {
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_PRODUCT_EXPORT_MASTER_SEARCH_SELECT", param);
            result = Convert.ToInt32(param[7].Value.ToString());
        }
        else
        {
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_PRODUCT_EXPORT_MASTER_SEARCH_SELECT", param);
            result = Convert.ToInt32(param[11].Value.ToString());
        }

        return ds;
    }

    public DataSet Export_ProductMaster_Select()
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@JOBNO", JOBNO);
        param[1] = new SqlParameter("@INV_SLNO", INV_SLNO);
        param[2] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);
        param[3] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
        param[4] = new SqlParameter("@Mflag", flag);

        param[7] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
        param[7].Direction = ParameterDirection.Output;

        param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[8].Direction = ParameterDirection.Output;

        ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_PRODUCT_EXPORT_MASTER_INSERT_UPDATE_BULK", param);
        return ds;
    }
    public int Product_Export_Insert_Update_Bulk()
    {
        SqlParameter[] param = new SqlParameter[15];

        param[0] = new SqlParameter("@JOBNO", JOBNO);
        param[1] = new SqlParameter("@INV_SLNO", INV_SLNO);
        param[2] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);
        param[3] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
        param[6] = new SqlParameter("@Mflag", flag);

        param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
        param[7].Direction = ParameterDirection.Output;

        param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[8].Direction = ParameterDirection.Output;

        SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_PRODUCT_EXPORT_MASTER_INSERT_UPDATE_BULK", param);
       // result = Convert.ToInt32(param[7].Value.ToString());

        return result;
    }



    public int EXPORT_PDF_SETTINGS_MASTER_Insert_Update()
    {
        SqlParameter[] param = new SqlParameter[80];

        param[51] = new SqlParameter("@ID", ID);
        param[0] = new SqlParameter("@EXPORTER_NAME", EXPORTER_NAME);
        param[1] = new SqlParameter("@IEC_NO", IEC_NO);
        param[2] = new SqlParameter("@BRANCH_NO", BRANCH_NO);
        param[3] = new SqlParameter("@TYPE_OF_EXPORTER", TYPE_OF_EXPORTER);
        param[4] = new SqlParameter("@PRODUCT_PARTNO", PRODUCT_PARTNO);
        param[5] = new SqlParameter("@RITC_NO", RITC_NO);
        param[6] = new SqlParameter("@ITEM_DESC", ITEM_DESC);
        param[7] = new SqlParameter("@REWARD_YES_NO", REWARD_YES_NO);
        param[8] = new SqlParameter("@STR_YES_NO", STR_YES_NO);
        param[9] = new SqlParameter("@STR_CODE", STR_CODE);
        param[10] = new SqlParameter("@RODTEP", RODTEP);
        param[11] = new SqlParameter("@CESS_YN", CESS_YN);
        param[12] = new SqlParameter("@SCHEME_CODE", SCHEME_CODE);
        param[13] = new SqlParameter("@END_USE_OF_ITEM", END_USE_OF_ITEM);
        param[14] = new SqlParameter("@UNDER_PTA_FTA", UNDER_PTA_FTA);
        param[15] = new SqlParameter("@IGST_PAYMENT", IGST_PAYMENT);
        param[16] = new SqlParameter("@IGST_RATE", IGST_RATE);
        param[17] = new SqlParameter("@DBK_SL_NO", DBK_SL_NO);
        param[18] = new SqlParameter("@DBK_UNIT", DBK_UNIT);
        param[19] = new SqlParameter("@DBK_DECLARATION", DBK_DECLARATION);
        param[20] = new SqlParameter("@SQC_UOM", SQC_UOM);
        param[21] = new SqlParameter("@ITEM_ACCESSORIES_DESC", ITEM_ACCESSORIES_DESC);
        param[22] = new SqlParameter("@TP_EXPORTER_NAME", TP_EXPORTER_NAME);
        param[23] = new SqlParameter("@TP_ITEM_IECCODE", TP_ITEM_IECCODE);
        param[24] = new SqlParameter("@TP_BR_SLNO", TP_BR_SLNO);
        param[25] = new SqlParameter("@TP_ADDRESS1", TP_ADDRESS1);
        param[26] = new SqlParameter("@TP_ADDRESS2", TP_ADDRESS2);
        param[27] = new SqlParameter("@TP_ADDRESS3", TP_ADDRESS3);
        param[28] = new SqlParameter("@TP_ADDRESS4", TP_ADDRESS4);
        param[29] = new SqlParameter("@TP_ADDRESS5", TP_ADDRESS5);
        param[30] = new SqlParameter("@GSTN_TYPE", GSTN_TYPE);
        param[31] = new SqlParameter("@GSTN_ID", GSTN_ID);
        param[32] = new SqlParameter("@MANUFACTURER_PRODUCER", MANUFACTURER_PRODUCER);
        param[33] = new SqlParameter("@M_P_GROWER_CODE", M_P_GROWER_CODE);
        param[34] = new SqlParameter("@M_P_GROWER_ADD1", M_P_GROWER_ADD1);
        param[35] = new SqlParameter("@M_P_GROWER_ADD2", M_P_GROWER_ADD2);
        param[36] = new SqlParameter("@M_P_GROWER_CITY", M_P_GROWER_CITY);
        param[37] = new SqlParameter("@M_P_GROWER_COUNTRY_SUBDIV", M_P_GROWER_COUNTRY_SUBDIV);
        param[38] = new SqlParameter("@M_P_GROWER_PIN", M_P_GROWER_PIN);
        param[39] = new SqlParameter("@M_P_GROWER_COUNTRY", M_P_GROWER_COUNTRY);
        param[40] = new SqlParameter("@SOURCE_STATE", SOURCE_STATE);
        param[41] = new SqlParameter("@TRANSIT_COUNTRY", TRANSIT_COUNTRY);
        param[42] = new SqlParameter("@ACCESSORY_STATUS", ACCESSORY_STATUS);
        param[43] = new SqlParameter("@HAWB_NO", HAWB_NO);
        param[44] = new SqlParameter("@TOTAL_PKGS", TOTAL_PKGS);
        param[45] = new SqlParameter("@REMARKS", REMARKS);

        param[52] = new SqlParameter("@USER_ID", Connection.Current_User());
        param[53] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
        param[54] = new SqlParameter("@ADCODE", ADCODE);
        param[55] = new SqlParameter("@INFO_MSR", INFO_MSR);
        param[56] = new SqlParameter("@INFO_UQC", INFO_UQC);

        param[46] = new SqlParameter("@Mflag", flag);

        param[47] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
        param[47].Direction = ParameterDirection.Output;

        param[48] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[48].Direction = ParameterDirection.Output;

        param[50] = new SqlParameter("@Update_Id", SqlDbType.NVarChar, 1000);
        param[50].Direction = ParameterDirection.Output;

        SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_PDF_SETTINGS_MASTER_INSERT_UPDATE", param);

        result = Convert.ToInt32(param[47].Value.ToString());

        return result;
    }

}