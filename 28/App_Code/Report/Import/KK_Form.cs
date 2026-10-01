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
using System.Web.ApplicationServices;

/// <summary>
/// Summary description for KK_Form
/// </summary>
public class KK_Form
{
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    adminmaster admin = new adminmaster();

    #region public string

    public int result=0, UPDATE_ID = 0;

    private string _Ename, _flag;
    //private string _Workingperiod, _flag, _BranchCode, _Year, _BRANCH_COMMON;

    public string Ename
    {
        get { return _Ename; }
        set { _Ename = value; }
    }

    public string flag { get { return _flag; } set { _flag = value; } }
   
    #endregion

    #region KK_Details

    public string _KK_Id,
_KK_JOBNO,
_KK_ChaName,
_KK_ChaAdd1,
_KK_ChaAdd2,
_KK_dealerName,
_KK_TIN,
_KK_CSTRegNo,
_KK_Designation,
_KK_Description,
_KK_Quality,
_KK_ValueOfGoods,
_KK_ClearingBENo,
_KK_Signature,
_KK_SignatureCl_Fwd,
_KK_TransportName,
_KK_deliveryOfTrans,
_KK_Place,
_KK_FOR,
_KK_Date,
_KK_BRANCHCODE,
_KK_YEAR,
_KK_WORKINGPERIOD,_KK_BRANCH_COMMON,
_KK_USERID, _KK_LOGINDATE;

    public string KK_JOBNO { get { return _KK_JOBNO; } set { _KK_JOBNO = value; } }
    public string KK_ChaName { get { return _KK_ChaName; } set { _KK_ChaName = value; } }
    public string KK_ChaAdd1 { get { return _KK_ChaAdd1; } set { _KK_ChaAdd1 = value; } }
    public string KK_ChaAdd2 { get { return _KK_ChaAdd2; } set { _KK_ChaAdd2 = value; } }
    public string KK_dealerName { get { return _KK_dealerName; } set { _KK_dealerName = value; } }
    public string KK_TIN { get { return _KK_TIN; } set { _KK_TIN = value; } }
    public string KK_CSTRegNo { get { return _KK_CSTRegNo; } set { _KK_CSTRegNo = value; } }
    public string KK_Designation { get { return _KK_Designation; } set { _KK_Designation = value; } }
    public string KK_Description { get { return _KK_Description; } set { _KK_Description = value; } }
    public string KK_Quality { get { return _KK_Quality; } set { _KK_Quality = value; } }
    public string KK_ValueOfGoods { get { return _KK_ValueOfGoods; } set { _KK_ValueOfGoods = value; } }
    public string KK_ClearingBENo { get { return _KK_ClearingBENo; } set { _KK_ClearingBENo = value; } }
    public string KK_Signature { get { return _KK_Signature; } set { _KK_Signature = value; } }
    public string KK_SignatureCl_Fwd { get { return _KK_SignatureCl_Fwd; } set { _KK_SignatureCl_Fwd = value; } }
    public string KK_TransportName { get { return _KK_TransportName; } set { _KK_TransportName = value; } }
    public string KK_deliveryOfTrans { get { return _KK_deliveryOfTrans; } set { _KK_deliveryOfTrans = value; } }
    public string KK_Place { get { return _KK_Place; } set { _KK_Place = value; } }
    public string KK_FOR { get { return _KK_FOR; } set { _KK_FOR = value; } }
    public string KK_Date { get { return _KK_Date; } set { _KK_Date = value; } }
    public string KK_BRANCHCODE { get { return _KK_BRANCHCODE; } set { _KK_BRANCHCODE = value; } }
    public string KK_YEAR { get { return _KK_YEAR; } set { _KK_YEAR = value; } }
    public string KK_WORKINGPERIOD { get { return _KK_WORKINGPERIOD; } set { _KK_WORKINGPERIOD = value; } }
    public string KK_BRANCH_COMMON { get { return _KK_BRANCH_COMMON; } set { _KK_BRANCH_COMMON = value; } }
    public string KK_USERID { get { return _KK_USERID; } set { _KK_USERID = value; } }
    public string KK_LOGINDATE { get { return _KK_LOGINDATE; } set { _KK_LOGINDATE = value; } }
    public string KK_Id { get { return _KK_Id; } set { _KK_Id = value; } }
   

    #endregion 


    #region Duty_Worksheet

    public string _InvNo, _Inv_Cur;

    public string _SlNo, _Item_Desc, _Item_Qty, _Item_Unit, _Item_UnitPrice, _total_Value, _total_Value_INR, _OtherChgs, _Freight_cal, _Insurance_Calc;
    public string _Tot_CIF, _LandingChargs, _Ass_Val, _CTH_CETH, _BCD_notn, _BCD_Amt, _CVD_Notn, _CVD_Amt, _CessAmt, _CVDCessAmt, _Edu_Notn, _ECessAmt, _SAD, _Total;
    public string _BCD_Rate, _CVD_Rate, _Cess_rate, _SAD_Rate;

    public string _PRODUCT_CETH;

    public string InvNo { get { return _InvNo; } set { _InvNo = value; } }
    public string Inv_Cur { get { return _Inv_Cur; } set { _Inv_Cur = value; } }

    public string SlNo { get { return _SlNo; } set { _SlNo = value; } }
    public string Item_Desc { get { return _Item_Desc; } set { _Item_Desc = value; } }
    public string Item_Qty { get { return _Item_Qty; } set { _Item_Qty = value; } }
    public string Item_Unit { get { return _Item_Unit; } set { _Item_Unit = value; } }
    public string Item_UnitPrice { get { return _Item_UnitPrice; } set { _Item_UnitPrice = value; } }
    public string total_Value { get { return _total_Value; } set { _total_Value = value; } }
    public string total_Value_INR { get { return _total_Value_INR; } set { _total_Value_INR = value; } }
    public string OtherChgs { get { return _OtherChgs; } set { _OtherChgs = value; } }
    public string Freight_cal { get { return _Freight_cal; } set { _Freight_cal = value; } }
    public string Insurance_Calc { get { return _Insurance_Calc; } set { _Insurance_Calc = value; } }

    public string Tot_CIF { get { return _Tot_CIF; } set { _Tot_CIF = value; } }
    public string LandingChargs { get { return _LandingChargs; } set { _LandingChargs = value; } }
    public string Ass_Val { get { return _Ass_Val; } set { _Ass_Val = value; } }
    public string CTH_CETH { get { return _CTH_CETH; } set { _CTH_CETH = value; } }
    public string BCD_notn { get { return _BCD_notn; } set { _BCD_notn = value; } }
    public string BCD_Amt { get { return _BCD_Amt; } set { _BCD_Amt = value; } }
    public string CVD_Notn { get { return _CVD_Notn; } set { _CVD_Notn = value; } }
    public string CVD_Amt { get { return _CVD_Amt; } set { _CVD_Amt = value; } }
    public string CessAmt { get { return _CessAmt; } set { _CessAmt = value; } }
    public string CVDCessAmt { get { return _CVDCessAmt; } set { _CVDCessAmt = value; } }
    public string Edu_Notn { get { return _Edu_Notn; } set { _Edu_Notn = value; } }
    public string ECessAmt { get { return _ECessAmt; } set { _ECessAmt = value; } }
    public string SAD { get { return _SAD; } set { _SAD = value; } }
    public string Total { get { return _Total; } set { _Total = value; } }

    public string BCD_Rate { get { return _BCD_Rate; } set { _BCD_Rate = value; } }
    public string CVD_Rate { get { return _CVD_Rate; } set { _CVD_Rate = value; } }
    public string Cess_rate { get { return _Cess_rate; } set { _Cess_rate = value; } }
    public string SAD_Rate { get { return _SAD_Rate; } set { _SAD_Rate = value; } }

    public string PRODUCT_CETH { get { return _PRODUCT_CETH; } set { _PRODUCT_CETH = value; } }
  
    #endregion


    #region LTR_DOCUMENT_Details

    public string
       _LTR_Id,
    _LTR_JOBNO,
    _LTR_CURRENT_DATE,
    _LTR_IMPORTER_NAME,
    _LTR_ADDRESS1,
    _LTR_ADDRESS2,
    _LTR_ADDRESS3,
    _LTR_ADDRESS4,
    _LTR_ADDRESS5,
    _LTR_NO_OF_PKGS,
    _LTR_PRODUCT_QUANTITY,
    _LTR_PRODUCT_DESCRIPTION,
    _LTR_VESSEL_FLIGHT_NO,
    _LTR_VOYAGE,
    _LTR_BE_NO,
    _LTR_BE_DATE,
    _LTR_COPY_BE_NO,
    _LTR_COPY_BE_DATE,
    _LTR_E_RECEIPT_NO,
    _LTR_E_RECEIPT_DATE,
    _LTR_MAWB_NO,
    _LTR_MAWB_DATE,
    _LTR_INVOICE_NO,
    _LTR_INVOICE_DATE,
    _LTR_PACK_INVOICE_DATE,
    _LTR_CERT_INVOICE_DATE,
    _LTR_CERT_WEIGHT_INVOICE_DATE,
    _LTR_INSURANCE_NO,
    _LTR_INSURANCE_DATE,
    _LTR_DO_NO,
    _LTR_DO_DATE,
    _LTR_J_CERT_NO,
    _LTR_J_CERT_DATE,
    _LTR_FOR,
    _LTR_Date,
    _LTR_BRANCHCODE,
    _LTR_YEAR,
    _LTR_WORKINGPERIOD,
    _LTR_USERID,
    _LTR_LOGINDATE,
    _LTR_BRANCHCOMMON;



    public string LTR_JOBNO { get { return _LTR_JOBNO; } set { _LTR_JOBNO = value; } }
    public string LTR_CURRENT_DATE { get { return _LTR_CURRENT_DATE; } set { _LTR_CURRENT_DATE = value; } }
    public string LTR_IMPORTER_NAME { get { return _LTR_IMPORTER_NAME; } set { _LTR_IMPORTER_NAME = value; } }
    public string LTR_ADDRESS1 { get { return _LTR_ADDRESS1; } set { _LTR_ADDRESS1 = value; } }
    public string LTR_ADDRESS2 { get { return _LTR_ADDRESS2; } set { _LTR_ADDRESS2 = value; } }
    public string LTR_ADDRESS3 { get { return _LTR_ADDRESS3; } set { _LTR_ADDRESS3 = value; } }
    public string LTR_ADDRESS4 { get { return _LTR_ADDRESS4; } set { _LTR_ADDRESS4 = value; } }
    public string LTR_ADDRESS5 { get { return _LTR_ADDRESS5; } set { _LTR_ADDRESS5 = value; } }
    public string LTR_NO_OF_PKGS { get { return _LTR_NO_OF_PKGS; } set { _LTR_NO_OF_PKGS = value; } }
    public string LTR_PRODUCT_QUANTITY { get { return _LTR_PRODUCT_QUANTITY; } set { _LTR_PRODUCT_QUANTITY = value; } }

    public string LTR_PRODUCT_DESCRIPTION { get { return _LTR_PRODUCT_DESCRIPTION; } set { _LTR_PRODUCT_DESCRIPTION = value; } }
    public string LTR_VESSEL_FLIGHT_NO { get { return _LTR_VESSEL_FLIGHT_NO; } set { _LTR_VESSEL_FLIGHT_NO = value; } }
    public string LTR_VOYAGE { get { return _LTR_VOYAGE; } set { _LTR_VOYAGE = value; } }
    public string LTR_BE_NO { get { return _LTR_BE_NO; } set { _LTR_BE_NO = value; } }
    public string LTR_BE_DATE { get { return _LTR_BE_DATE; } set { _LTR_BE_DATE = value; } }
    public string LTR_COPY_BE_NO { get { return _LTR_COPY_BE_NO; } set { _LTR_COPY_BE_NO = value; } }
    public string LTR_COPY_BE_DATE { get { return _LTR_COPY_BE_DATE; } set { _LTR_COPY_BE_DATE = value; } }
    public string LTR_E_RECEIPT_NO { get { return _LTR_E_RECEIPT_NO; } set { _LTR_E_RECEIPT_NO = value; } }
    public string LTR_E_RECEIPT_DATE { get { return _LTR_E_RECEIPT_DATE; } set { _LTR_E_RECEIPT_DATE = value; } }

    public string LTR_MAWB_NO { get { return _LTR_MAWB_NO; } set { _LTR_MAWB_NO = value; } }
    public string LTR_MAWB_DATE { get { return _LTR_MAWB_DATE; } set { _LTR_MAWB_DATE = value; } }
    public string LTR_INVOICE_NO { get { return _LTR_INVOICE_NO; } set { _LTR_INVOICE_NO = value; } }
    public string LTR_INVOICE_DATE { get { return _LTR_INVOICE_DATE; } set { _LTR_INVOICE_DATE = value; } }
    public string LTR_PACK_INVOICE_DATE { get { return _LTR_PACK_INVOICE_DATE; } set { _LTR_PACK_INVOICE_DATE = value; } }
    public string LTR_CERT_INVOICE_DATE { get { return _LTR_CERT_INVOICE_DATE; } set { _LTR_CERT_INVOICE_DATE = value; } }
    public string LTR_CERT_WEIGHT_INVOICE_DATE { get { return _LTR_CERT_WEIGHT_INVOICE_DATE; } set { _LTR_CERT_WEIGHT_INVOICE_DATE = value; } }
    public string LTR_INSURANCE_NO { get { return _LTR_INSURANCE_NO; } set { _LTR_INSURANCE_NO = value; } }
    public string LTR_INSURANCE_DATE { get { return _LTR_INSURANCE_DATE; } set { _LTR_INSURANCE_DATE = value; } }

    public string LTR_DO_NO { get { return _LTR_DO_NO; } set { _LTR_DO_NO = value; } }
    public string LTR_DO_DATE { get { return _LTR_DO_DATE; } set { _LTR_DO_DATE = value; } }
    public string LTR_J_CERT_NO { get { return _LTR_J_CERT_NO; } set { _LTR_J_CERT_NO = value; } }
    public string LTR_J_CERT_DATE { get { return _LTR_J_CERT_DATE; } set { _LTR_J_CERT_DATE = value; } }
    public string LTR_FOR { get { return _LTR_FOR; } set { _LTR_FOR = value; } }
    public string LTR_Date { get { return _LTR_Date; } set { _LTR_Date = value; } }
    public string LTR_BRANCHCODE { get { return _LTR_BRANCHCODE; } set { _LTR_BRANCHCODE = value; } }
    public string LTR_YEAR { get { return _LTR_YEAR; } set { _LTR_YEAR = value; } }
    public string LTR_WORKINGPERIOD { get { return _LTR_WORKINGPERIOD; } set { _LTR_WORKINGPERIOD = value; } }
    public string LTR_USERID { get { return _LTR_USERID; } set { _LTR_USERID = value; } }
    public string LTR_LOGINDATE { get { return _LTR_LOGINDATE; } set { _LTR_LOGINDATE = value; } }
    public string LTR_BRANCHCOMMON { get { return _LTR_BRANCHCOMMON; } set { _LTR_BRANCHCOMMON = value; } }

    public string LTR_Id { get { return _LTR_Id; } set { _LTR_Id = value; } }


    #endregion 

    public DataSet RetrieveAll_KK_Details()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", KK_JOBNO);


            param[1] = new SqlParameter("@name", Ename);
            param[2] = new SqlParameter("@Branch", KK_BRANCHCODE);
            //param[3] = new SqlParameter("@name", Ename);
            param[4] = new SqlParameter("@Working_Period", KK_WORKINGPERIOD);

            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;


            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_Import_KK_FORM_Report", param);

            result = Convert.ToInt32(param[5].Value.ToString());
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public int KK_Insert_Update()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[45];

            param[0] = new SqlParameter("@KK_Id", KK_Id);
            param[1] = new SqlParameter("@KK_JOBNO", KK_JOBNO);
            param[2] = new SqlParameter("@KK_ChaName", KK_ChaName);
            param[3] = new SqlParameter("@KK_ChaAdd1", KK_ChaAdd1);
            param[4] = new SqlParameter("@KK_ChaAdd2", KK_ChaAdd2);
            param[5] = new SqlParameter("@KK_dealerName", KK_dealerName);
            param[6] = new SqlParameter("@KK_TIN", KK_TIN);
            param[7] = new SqlParameter("@KK_CSTRegNo", KK_CSTRegNo);
            param[8] = new SqlParameter("@KK_Designation", KK_Designation);
            param[9] = new SqlParameter("@KK_Description", KK_Description);
            param[10] = new SqlParameter("@KK_Quality", KK_Quality);
            param[11] = new SqlParameter("@KK_ValueOfGoods", KK_ValueOfGoods);
            param[12] = new SqlParameter("@KK_ClearingBENo", KK_ClearingBENo);
            param[13] = new SqlParameter("@KK_Signature", KK_Signature);
            param[14] = new SqlParameter("@KK_SignatureCl_Fwd", KK_SignatureCl_Fwd);
            param[15] = new SqlParameter("@KK_TransportName", KK_TransportName);
            param[16] = new SqlParameter("@KK_deliveryOfTrans", KK_deliveryOfTrans);
            param[17] = new SqlParameter("@KK_Place", KK_Place);
            param[18] = new SqlParameter("@KK_FOR", KK_FOR);
            param[19] = new SqlParameter("@KK_Date", KK_Date);

            param[20] = new SqlParameter("@KK_BRANCHCODE", KK_BRANCHCODE);
            param[21] = new SqlParameter("@KK_YEAR", KK_YEAR);
            param[22] = new SqlParameter("@KK_WORKINGPERIOD", KK_WORKINGPERIOD);

            param[26] = new SqlParameter("@KK_BRANCHCOMMON", KK_BRANCH_COMMON);
            param[27] = new SqlParameter("@KK_USERID", KK_USERID);
            param[28] = new SqlParameter("@KK_LOGINDATE", KK_LOGINDATE);




            param[23] = new SqlParameter("@Ename", Ename);
            param[24] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[24].Direction = ParameterDirection.Output;
            param[25] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[25].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "KK_FORM_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[24].Value.ToString());

            if (flag == "S")

                UPDATE_ID = Convert.ToInt32(param[32].Value.ToString());
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

        return result;
    }

    public DataSet RetrieveAll_DutyWorkSheet_Details()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", KK_JOBNO);


            param[1] = new SqlParameter("@name", Ename);
            param[2] = new SqlParameter("@Branch", KK_BRANCHCODE);
            //param[3] = new SqlParameter("@name", Ename);
            param[4] = new SqlParameter("@Working_Period", KK_WORKINGPERIOD);

            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;


            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_Import_Duty_workSht_Report", param);

            result = Convert.ToInt32(param[5].Value.ToString());
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_CheckList_Cess_Import()
    {
        DataSet ds = new DataSet();
        try
        {

            SqlParameter[] param = new SqlParameter[10];


            //param[0] = new SqlParameter("@SCHEME_NOTN", SCHEME_NOTN);
            //param[1] = new SqlParameter("@SCHEME_IMPORT_CODE", SCHEME_IMPORT_CODE);
            param[0] = new SqlParameter("@PRODUCT_CETH", PRODUCT_CETH);

            param[2] = new SqlParameter("@name", Ename);

            //param[5] = new SqlParameter("@SCHEME_NOTN_SLNO", SCHEME_NOTN_SLNO);
            //param[6] = new SqlParameter("@SCHEME_IMPORT_NAME", SCHEME_IMPORT_NAME);

            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            //if (Name == "SCHEME_NOTN_RATE")
            //{
            //return SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_SCHEME_IMPORT", param);
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_CETH_CESS_RATE", param);
            //}

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

    public int LTR_DOC_Insert_Update()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[45];

                 param[0]=new SqlParameter("@LTR_Id",LTR_Id);
                 param[1]=new SqlParameter("@LTR_JOBNO", LTR_JOBNO);
                 param[2]=new SqlParameter("@LTR_CURRENT_DATE", LTR_CURRENT_DATE);
                 param[3]=new SqlParameter("@LTR_IMPORTER_NAME" ,LTR_IMPORTER_NAME );
                 param[4]=new SqlParameter("@LTR_ADDRESS1", LTR_ADDRESS1 );
                 param[5]=new SqlParameter("@LTR_ADDRESS2", LTR_ADDRESS2 );
                 param[6]=new SqlParameter("@LTR_ADDRESS3",LTR_ADDRESS3 );
                 param[7]=new SqlParameter("@LTR_ADDRESS4", LTR_ADDRESS4 );
                 param[8]=new SqlParameter("@LTR_ADDRESS5", LTR_ADDRESS5 );
                 param[9]=new SqlParameter("@LTR_NO_OF_PKGS", LTR_NO_OF_PKGS );
                 param[10]=new SqlParameter("@LTR_PRODUCT_QUANTITY",LTR_PRODUCT_QUANTITY );
                 param[11]=new SqlParameter("@LTR_PRODUCT_DESCRIPTION",LTR_PRODUCT_DESCRIPTION );
                 param[12]=new SqlParameter("@LTR_VESSEL_FLIGHT_NO",LTR_VESSEL_FLIGHT_NO );
                 param[13]=new SqlParameter("@LTR_VOYAGE",LTR_VOYAGE );
                 param[14]=new SqlParameter("@LTR_BE_NO",LTR_BE_NO );
                 param[15]=new SqlParameter("@LTR_BE_DATE" ,LTR_BE_DATE );
                 param[16]=new SqlParameter("@LTR_COPY_BE_NO",LTR_COPY_BE_NO );
                 param[17]=new SqlParameter("@LTR_COPY_BE_DATE",LTR_COPY_BE_DATE );
                 param[18]=new SqlParameter("@LTR_E_RECEIPT_NO",LTR_E_RECEIPT_NO );
                 param[19]=new SqlParameter("@LTR_E_RECEIPT_DATE" ,LTR_E_RECEIPT_DATE );
                 param[20]=new SqlParameter("@LTR_MAWB_NO",LTR_MAWB_NO );
                 param[21]=new SqlParameter("@LTR_MAWB_DATE",LTR_MAWB_DATE );
                 param[22]=new SqlParameter("@LTR_INVOICE_NO",LTR_INVOICE_NO );
                 param[23]=new SqlParameter("@LTR_INVOICE_DATE",LTR_INVOICE_DATE );
                 param[24]=new SqlParameter("@LTR_PACK_INVOICE_DATE",LTR_PACK_INVOICE_DATE );
                 param[25]=new SqlParameter("@LTR_CERT_INVOICE_DATE",LTR_CERT_INVOICE_DATE );
                 param[26]=new SqlParameter("@LTR_CERT_WEIGHT_INVOICE_DATE",LTR_CERT_WEIGHT_INVOICE_DATE );
                 param[27]=new SqlParameter("@LTR_INSURANCE_NO",LTR_INSURANCE_NO );
                 param[28]=new SqlParameter("@LTR_INSURANCE_DATE",LTR_INSURANCE_DATE );
                 param[29]=new SqlParameter("@LTR_DO_NO",LTR_DO_NO );
                 param[30]=new SqlParameter("@LTR_DO_DATE",LTR_DO_DATE );
                 param[31]=new SqlParameter("@LTR_J_CERT_NO",LTR_J_CERT_NO );
                 param[32]=new SqlParameter("@LTR_J_CERT_DATE",LTR_J_CERT_DATE );

                 param[33]=new SqlParameter("@LTR_FOR",LTR_FOR );
                 param[34]=new SqlParameter("@LTR_Date",LTR_Date );
                 param[35]=new SqlParameter("@LTR_BRANCHCODE",LTR_BRANCHCODE);
                 param[36]=new SqlParameter("@LTR_YEAR",LTR_YEAR);
                 param[37]=new SqlParameter("@LTR_WORKINGPERIOD",LTR_WORKINGPERIOD);
                 param[38]=new SqlParameter("@LTR_USERID",LTR_USERID );
                 param[39]=new SqlParameter("@LTR_LOGINDATE",LTR_LOGINDATE);
                 param[42] = new SqlParameter("@LTR_BRANCHCOMMON", LTR_BRANCHCOMMON);



            param[43] = new SqlParameter("@Ename", Ename);
            param[40] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[40].Direction = ParameterDirection.Output;
            param[41] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[41].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_LTR_DOCUMENT_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[40].Value.ToString());

            if (flag == "S")

                UPDATE_ID = Convert.ToInt32(param[32].Value.ToString());
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

        return result;
    }

    public DataSet RetrieveAll_LTR_DOCUMENT_Details()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", LTR_JOBNO);


            param[1] = new SqlParameter("@name", Ename);
            param[2] = new SqlParameter("@Branch", LTR_BRANCHCOMMON);
            //param[3] = new SqlParameter("@name", Ename);
            param[4] = new SqlParameter("@Working_Period", LTR_WORKINGPERIOD);

            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;


            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_LTR_DOCUMENT_REPORT", param);

            result = Convert.ToInt32(param[5].Value.ToString());
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public List<KK_Form> Load_KK_Form_Details(DataTable dt)
    {
        List<KK_Form> list = new List<KK_Form>();

        int i = 0;

        while (dt.Rows.Count > i)
        {
            DataRow row = dt.Rows[i];

            list.Add(new KK_Form()
            {
                KK_JOBNO = row["KK_JOBNO"].ToString(),
                KK_ChaName = row["KK_ChaName"].ToString(),
                KK_ChaAdd1 = row["KK_ChaAdd1"].ToString(),
                KK_ChaAdd2 = row["KK_ChaAdd2"].ToString(),
                KK_dealerName = row["KK_dealerName"].ToString(),
                KK_TIN = row["KK_TIN"].ToString(),
                KK_CSTRegNo = row["KK_CSTRegNo"].ToString(),
                KK_Designation = row["KK_Designation"].ToString(),
                KK_Description = row["KK_Description"].ToString(),
                KK_Quality = row["KK_Quality"].ToString(),
                KK_ValueOfGoods = row["KK_ValueOfGoods"].ToString(),
                KK_ClearingBENo = row["KK_ClearingBENo"].ToString(),
                KK_Signature = row["KK_Signature"].ToString(),
                KK_SignatureCl_Fwd = row["KK_SignatureCl_Fwd"].ToString(),
                KK_TransportName = row["KK_TransportName"].ToString(),
                KK_deliveryOfTrans = row["KK_deliveryOfTrans"].ToString(),
                KK_Place = row["KK_Place"].ToString(),
                KK_FOR = row["KK_FOR"].ToString(),
                KK_Date = row["KK_Date"].ToString()
             

            });
            i++;
        }

        return list;
    }

    public List<KK_Form> Load_DutyWorkSheet_Details(DataTable dt)
    {
        List<KK_Form> list = new List<KK_Form>();

        int i = 0;

        while (dt.Rows.Count > i)
        {
            DataRow row = dt.Rows[i];

            list.Add(new KK_Form()
            {
                SlNo = row["ITEM_SLNO"].ToString(),
                Item_Desc = row["ITEM_DESCRIPTION"].ToString(),
                Item_Qty = row["ITEM_QTY"].ToString(),
                Item_Unit = row["ITEM_QTY_CODE"].ToString(),
                Item_UnitPrice = row["ITEM_UNIT_PRICE"].ToString(),
                total_Value = row["ITEM_TOTAL_AMOUNT"].ToString(),
                total_Value_INR = row["ITEM_TOTAL_AMOUNT_INR"].ToString(),
                OtherChgs = row["OtherChgs"].ToString(),
                Freight_cal = row["Freight_cal"].ToString(),
                Insurance_Calc = row["Insurance_Calc"].ToString(),
                Tot_CIF = row["CIF_VALUE"].ToString(),
                LandingChargs = row["Landing_Charges"].ToString(),
                Ass_Val = row["ASSESSABLE_VALUE"].ToString(),

                CTH_CETH = row["CTH_NO"].ToString(),
                BCD_notn = row["PRODUCT_BCD_NOTN"].ToString(),
                BCD_Amt = row["BASIC_VALUE"].ToString(),
                CVD_Notn = row["PRODUCT_CVD_NOTN"].ToString(),
                CVD_Amt = row["CVD_VALUE"].ToString(),
                CessAmt = row["CessAmt"].ToString(),
                CVDCessAmt = row["CVDCessAmt"].ToString(),
                Edu_Notn = row["CVDCessAmt"].ToString(),
                ECessAmt = row["CHEC_VALUE"].ToString(),
                SAD = row["ADD_DUTY_VALUE"].ToString(),
                Total = row["DUTY_VALUE"].ToString(),

                BCD_Rate = row["PRODUCT_BCD_RATE"].ToString(),
                CVD_Rate = row["PRODUCT_CVD_RATE"].ToString(),
                Cess_rate = row["PRODUCT_EDU_CESS_RATE"].ToString(),
                SAD_Rate = row["PRODUCT_ADDL_DUTY_RATE"].ToString(),

                InvNo = row["INVOICE_NO"].ToString(),
                Inv_Cur = row["INVOICE_SLNO"].ToString()

            });
            i++;
        }

        return list;
    }


    public List<KK_Form> Load_LTR_DOCUMENT_Details(DataTable dt)
    {
        List<KK_Form> list = new List<KK_Form>();

        int i = 0;

        while (dt.Rows.Count > i)
        {
            DataRow row = dt.Rows[i];

            list.Add(new KK_Form()
            {
                    LTR_JOBNO=row["LTR_JOBNO"].ToString(),
                    LTR_CURRENT_DATE=row["LTR_CURRENT_DATE"].ToString(),
                    LTR_IMPORTER_NAME =row["LTR_IMPORTER_NAME"].ToString(),
                    LTR_ADDRESS1 =row["LTR_ADDRESS1"].ToString(),
                    LTR_ADDRESS2 =row["LTR_ADDRESS2"].ToString(), 
                    LTR_ADDRESS3 =row["LTR_ADDRESS3"].ToString(), 
                    LTR_ADDRESS4 =row["LTR_ADDRESS4"].ToString(), 
                    LTR_ADDRESS5 =row["LTR_ADDRESS5"].ToString(), 
                    LTR_NO_OF_PKGS =row["LTR_NO_OF_PKGS"].ToString(), 
                    LTR_PRODUCT_QUANTITY =row["LTR_PRODUCT_QUANTITY"].ToString(), 
                    LTR_PRODUCT_DESCRIPTION =row["LTR_PRODUCT_DESCRIPTION"].ToString(), 
                    LTR_VESSEL_FLIGHT_NO =row["LTR_VESSEL_FLIGHT_NO"].ToString(), 
                    LTR_VOYAGE =row["LTR_VOYAGE"].ToString(), 
                    LTR_BE_NO =row["LTR_BE_NO"].ToString(),
                    LTR_BE_DATE =row["LTR_BE_DATE"].ToString(), 
                    LTR_COPY_BE_NO =row["LTR_COPY_BE_NO"].ToString(), 
                    LTR_COPY_BE_DATE =row["LTR_COPY_BE_DATE"].ToString(), 
                    LTR_E_RECEIPT_NO =row["LTR_E_RECEIPT_NO"].ToString(), 
                    LTR_E_RECEIPT_DATE =row["LTR_E_RECEIPT_DATE"].ToString(), 
                    LTR_MAWB_NO =row["LTR_MAWB_NO"].ToString(), 
                    LTR_MAWB_DATE =row["LTR_MAWB_DATE"].ToString(), 
                    LTR_INVOICE_NO =row["LTR_INVOICE_NO"].ToString(), 
                    LTR_INVOICE_DATE =row["LTR_INVOICE_DATE"].ToString(), 
                    LTR_PACK_INVOICE_DATE =row["LTR_PACK_INVOICE_DATE"].ToString(), 
                    LTR_CERT_INVOICE_DATE =row["LTR_CERT_INVOICE_DATE"].ToString(), 
                    LTR_CERT_WEIGHT_INVOICE_DATE =row["LTR_CERT_WEIGHT_INVOICE_DATE"].ToString(), 
                    LTR_INSURANCE_NO =row["LTR_INSURANCE_NO"].ToString(), 
                    LTR_INSURANCE_DATE =row["LTR_INSURANCE_DATE"].ToString(), 
                    LTR_DO_NO =row["LTR_DO_NO"].ToString(), 
                    LTR_DO_DATE =row["LTR_DO_DATE"].ToString(), 
                    LTR_J_CERT_NO =row["LTR_J_CERT_NO"].ToString(), 
                    LTR_J_CERT_DATE =row["LTR_J_CERT_DATE"].ToString(),
                    LTR_FOR =row["LTR_FOR"].ToString(), 
                    LTR_Date =row["LTR_Date"].ToString(), 
                    LTR_BRANCHCODE=row["LTR_BRANCHCODE"].ToString(),
                    LTR_YEAR=row["LTR_YEAR"].ToString(),
                    LTR_WORKINGPERIOD=row["LTR_WORKINGPERIOD"].ToString(),
                    LTR_USERID =row["LTR_USERID"].ToString(), 
                    LTR_LOGINDATE=row["LTR_LOGINDATE"].ToString()

                
            });
            i++;
        }

        return list;
    }
}



