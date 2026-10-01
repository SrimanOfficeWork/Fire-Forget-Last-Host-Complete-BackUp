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

using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public class Import_ManualBE_LC
{

   

    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();
    SqlCommand cmd;
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();

    
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    public int result = 0;

    private string _JOBNO;
    private string _Ename, _Working_Period,_Branchcode;
    public int UPDATE_ID = 0;

    private string _ITEM_SLNO;
    private string _ITEM_DESCRIPTION;
    public string _IEC_NO;

    public string IEC_NO
    {
        get { return _IEC_NO; }
        set { _IEC_NO = value; }
    }

    public string JOBNO
    {
        get { return _JOBNO; }
        set { _JOBNO = value; }
    }
    public string Ename
    {
        get { return _Ename; }
        set { _Ename = value; }
    }
    public string Working_Period
    {
        get { return _Working_Period; }
        set { _Working_Period = value; }
    }
    public string Branchcode
    {
        get { return _Branchcode; }
        set { _Branchcode = value; }
    }
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string ITEM_DESCRIPTION { get { return _ITEM_DESCRIPTION; } set { _ITEM_DESCRIPTION = value; } }


    #region Manual_BE

    private string _M_ID ,_DATE1 ;
   

private string _IMPORTER,_IM_ADDRESS1,_IM_ADDRESS2,_IM_ADDRESS3,_IM_ADDRESS4,_IM_ADDRESS5;
private string _SUPPLIERNAME,_SUP_ADDRESS1,_SUP_ADDRESS2,_SUP_ADDRESS3,_SUP_ADDRESS4,_SUP_ADDRESS5;
private string _INCOME_TAX,_PRIOR_STAMP,_VESSEL_NAME,_LINE_NO,_PORT_SHIPMENT,_IMPORT_DEPT,_ROTATION_NO_DATE ;
private string _COUN_CONSIGNMENT,_COUN_ORIGIN,_AWBL_NO,_AWBL_DATE,_HAWB_NO,_HAWB_DATE ;
private string _GROSS_WEIGHT, _TOTAL_PKGS, _AGENCY_COMMISION, _MIS_CHARGES, _MIS_CURRENCY,_TERMS, _TOTAL_VAL, _LANDING_CHARGES, _DUTY_VALUE, _ASSBL_VAL;
private string _ITC_LICENSE, _INVOICE_NO_DATE, _DUTY_VAL_WORDS, _ASSBL_VAL_WORDS, _M_BRANCHCODE, _M_YEAR, _M_WORKINGPERIOD, _BRANCH_COMMON, _flag;

public string M_ID { get { return _M_ID; } set { _M_ID = value; } }
public string DATE1 { get { return _DATE1; } set { _DATE1 = value; } }

public string IMPORTER { get { return _IMPORTER; } set { _IMPORTER = value; } }
public string IM_ADDRESS1 { get { return _IM_ADDRESS1; } set { _IM_ADDRESS1 = value; } }
public string IM_ADDRESS2 { get { return _IM_ADDRESS2; } set { _IM_ADDRESS2 = value; } }
public string IM_ADDRESS3 { get { return _IM_ADDRESS3; } set { _IM_ADDRESS3 = value; } }
public string IM_ADDRESS4 { get { return _IM_ADDRESS4; } set { _IM_ADDRESS4 = value; } }
public string IM_ADDRESS5 { get { return _IM_ADDRESS5; } set { _IM_ADDRESS5 = value; } }

public string SUPPLIERNAME { get { return _SUPPLIERNAME; } set { _SUPPLIERNAME = value; } }
public string SUP_ADDRESS1 { get { return _SUP_ADDRESS1; } set { _SUP_ADDRESS1 = value; } }
public string SUP_ADDRESS2 { get { return _SUP_ADDRESS2; } set { _SUP_ADDRESS2 = value; } }
public string SUP_ADDRESS3 { get { return _SUP_ADDRESS3; } set { _SUP_ADDRESS3 = value; } }
public string SUP_ADDRESS4 { get { return _SUP_ADDRESS4; } set { _SUP_ADDRESS4 = value; } }
public string SUP_ADDRESS5 { get { return _SUP_ADDRESS5; } set { _SUP_ADDRESS5 = value; } }

public string INCOME_TAX { get { return _INCOME_TAX; } set { _INCOME_TAX = value; } }
public string PRIOR_STAMP { get { return _PRIOR_STAMP; } set { _PRIOR_STAMP = value; } }
public string VESSEL_NAME { get { return _VESSEL_NAME; } set { _VESSEL_NAME = value; } }
public string LINE_NO { get { return _LINE_NO; } set { _LINE_NO = value; } }
public string PORT_SHIPMENT { get { return _PORT_SHIPMENT; } set { _PORT_SHIPMENT = value; } }
public string IMPORT_DEPT { get { return _IMPORT_DEPT; } set { _IMPORT_DEPT = value; } }
public string ROTATION_NO_DATE { get { return _ROTATION_NO_DATE; } set { _ROTATION_NO_DATE = value; } }

public string COUN_CONSIGNMENT { get { return _COUN_CONSIGNMENT; } set { _COUN_CONSIGNMENT = value; } }
public string COUN_ORIGIN { get { return _COUN_ORIGIN; } set { _COUN_ORIGIN = value; } }
public string AWBL_NO { get { return _AWBL_NO; } set { _AWBL_NO = value; } }
public string AWBL_DATE { get { return _AWBL_DATE; } set { _AWBL_DATE = value; } }
public string HAWB_NO { get { return _HAWB_NO; } set { _HAWB_NO = value; } }
public string HAWB_DATE { get { return _HAWB_DATE; } set { _HAWB_DATE = value; } }

public string GROSS_WEIGHT { get { return _GROSS_WEIGHT; } set { _GROSS_WEIGHT = value; } }
public string TOTAL_PKGS { get { return _TOTAL_PKGS; } set { _TOTAL_PKGS = value; } }
public string AGENCY_COMMISION { get { return _AGENCY_COMMISION; } set { _AGENCY_COMMISION = value; } }
public string MIS_CHARGES { get { return _MIS_CHARGES; } set { _MIS_CHARGES = value; } }
public string MIS_CURRENCY { get { return _MIS_CURRENCY; } set { _MIS_CURRENCY = value; } }    
public string TERMS { get { return _TERMS; } set { _TERMS = value; } }
public string TOTAL_VAL { get { return _TOTAL_VAL; } set { _TOTAL_VAL = value; } }
public string LANDING_CHARGES { get { return _LANDING_CHARGES; } set { _LANDING_CHARGES = value; } }
public string DUTY_VALUE { get { return _DUTY_VALUE; } set { _DUTY_VALUE = value; } }
public string ASSBL_VAL { get { return _ASSBL_VAL; } set { _ASSBL_VAL = value; } }

public string ITC_LICENSE { get { return _ITC_LICENSE; } set { _ITC_LICENSE = value; } }
public string INVOICE_NO_DATE { get { return _INVOICE_NO_DATE; } set { _INVOICE_NO_DATE = value; } }
public string DUTY_VAL_WORDS { get { return _DUTY_VAL_WORDS; } set { _DUTY_VAL_WORDS = value; } }
public string ASSBL_VAL_WORDS { get { return _ASSBL_VAL_WORDS; } set { _ASSBL_VAL_WORDS = value; } }
public string M_BRANCHCODE { get { return _M_BRANCHCODE; } set { _M_BRANCHCODE = value; } }
public string M_YEAR { get { return _M_YEAR; } set { _M_YEAR = value; } }
public string M_WORKINGPERIOD { get { return _M_WORKINGPERIOD; } set { _M_WORKINGPERIOD = value; } }
public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }
public string flag { get { return _flag; } set { _flag = value; } }

 #endregion Manual_BE

private string _Sl_No;
private string _Jobno;
private string _Numbers_Desc;
private string _Marks_Numbers;
private string _Item_Slno;
private string _Unit_Code;
private string _Weight;
private string _Goods_Description;
private string _CTH_No_Notn_no;
private string _Duty_Code;
private string _Assablevalue;
private string _CTH_Rate;
private string _CTH_AMT;
private string _CETH_Not;
private string _Col9_and_11;
private string _CETH_Rate;
private string _CETH_Amt;
private string _Total_Duty;
private string _Flag;
private string _USER_ID;

private string _Select_Type;

public string Sl_No { get { return _Sl_No; } set { _Sl_No = value; } }
public string Jobno { get { return _Jobno; } set { _Jobno = value; } }
public string Numbers_Desc { get { return _Numbers_Desc; } set { _Numbers_Desc = value; } }
public string Marks_Numbers { get { return _Marks_Numbers; } set { _Marks_Numbers = value; } }
public string Item_Slno { get { return _Item_Slno; } set { _Item_Slno = value; } }
public string Unit_Code { get { return _Unit_Code; } set { _Unit_Code = value; } }
public string Weight { get { return _Weight; } set { _Weight = value; } }
public string Goods_Description { get { return _Goods_Description; } set { _Goods_Description = value; } }
public string CTH_No_Notn_no { get { return _CTH_No_Notn_no; } set { _CTH_No_Notn_no = value; } }
public string Duty_Code { get { return _Duty_Code; } set { _Duty_Code = value; } }
public string Assablevalue { get { return _Assablevalue; } set { _Assablevalue = value; } }
public string CTH_Rate { get { return _CTH_Rate; } set { _CTH_Rate = value; } }
public string CTH_AMT { get { return _CTH_AMT; } set { _CTH_AMT = value; } }
public string CETH_Not { get { return _CETH_Not; } set { _CETH_Not = value; } }
public string Col9_and_11 { get { return _Col9_and_11; } set { _Col9_and_11 = value; } }
public string CETH_Rate { get { return _CETH_Rate; } set { _CETH_Rate = value; } }
public string CETH_Amt { get { return _CETH_Amt; } set { _CETH_Amt = value; } }
public string Total_Duty { get { return _Total_Duty; } set { _Total_Duty = value; } }

public string Flag { get { return _Flag; } set { _Flag = value; } }
public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }

public string Select_Type { get { return _Select_Type; } set { _Select_Type = value; } }




public DataSet ManualBE_Rpt()
    {

        try
        {
           
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@JobNo", JOBNO);
            param[6]=new SqlParameter("@Branch",Branchcode);
            param[1] = new SqlParameter("@name", Ename);
            param[2]=new SqlParameter("@Working_Period",Working_Period);
            param[3] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ManualBE", param);
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_MANUAL_BE_GENERAL", param);

            result = Convert.ToInt32(param[3].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }


public int ManaulBE_Insert_Update()
{
    DataSet dss = new DataSet();

    try
    {

        SqlParameter[] param = new SqlParameter[60];

        param[1] = new SqlParameter("@M_ID", M_ID);
        param[2] = new SqlParameter("@JOBNO", JOBNO);
        param[3] = new SqlParameter("@DATE1", DATE1);
        param[4] = new SqlParameter("@IMPORTER", IMPORTER);
        param[5] = new SqlParameter("@IM_ADDRESS1", IM_ADDRESS1);
        param[6] = new SqlParameter("@IM_ADDRESS2", IM_ADDRESS2);
        param[7] = new SqlParameter("@IM_ADDRESS3", IM_ADDRESS3);
        param[8] = new SqlParameter("@IM_ADDRESS4", IM_ADDRESS4);
        param[9] = new SqlParameter("@IM_ADDRESS5", IM_ADDRESS5);
        param[10] = new SqlParameter("@SUPPLIERNAME", SUPPLIERNAME);
        param[11] = new SqlParameter("@SUP_ADDRESS1", SUP_ADDRESS1);
        param[12] = new SqlParameter("@SUP_ADDRESS2", SUP_ADDRESS2);
        param[13] = new SqlParameter("@SUP_ADDRESS3", SUP_ADDRESS3);
        param[14] = new SqlParameter("@SUP_ADDRESS4", SUP_ADDRESS4);
        param[15] = new SqlParameter("@SUP_ADDRESS5", SUP_ADDRESS5);

        param[16] = new SqlParameter("@INCOME_TAX", INCOME_TAX);
        param[17] = new SqlParameter("@PRIOR_STAMP", PRIOR_STAMP);
        param[18] = new SqlParameter("@VESSEL_NAME", VESSEL_NAME);
        param[19] = new SqlParameter("@LINE_NO", LINE_NO);
        param[20] = new SqlParameter("@PORT_SHIPMENT", PORT_SHIPMENT);
        param[21] = new SqlParameter("@IMPORT_DEPT", IMPORT_DEPT);
        param[22] = new SqlParameter("@ROTATION_NO_DATE", ROTATION_NO_DATE);
        param[23] = new SqlParameter("@COUN_CONSIGNMENT", COUN_CONSIGNMENT);
        param[24] = new SqlParameter("@COUN_ORIGIN", COUN_ORIGIN);
        param[25] = new SqlParameter("@AWBL_NO", AWBL_NO);
        param[26] = new SqlParameter("@AWBL_DATE", AWBL_DATE);
        param[27] = new SqlParameter("@HAWB_NO", HAWB_NO);
        param[28] = new SqlParameter("@HAWB_DATE", HAWB_DATE);

        param[29] = new SqlParameter("@GROSS_WEIGHT", GROSS_WEIGHT);
        param[30] = new SqlParameter("@TOTAL_PKGS", TOTAL_PKGS);
        param[31] = new SqlParameter("@AGENCY_COMMISION", AGENCY_COMMISION);
        param[32] = new SqlParameter("@MIS_CHARGES", MIS_CHARGES);
        param[33] = new SqlParameter("@MIS_CURRENCY", MIS_CURRENCY);
        param[34] = new SqlParameter("@TERMS", TERMS);
        param[35] = new SqlParameter("@TOTAL_VAL", TOTAL_VAL);
        param[36] = new SqlParameter("@LANDING_CHARGES", LANDING_CHARGES);
        param[37] = new SqlParameter("@DUTY_VALUE", DUTY_VALUE);
        param[38] = new SqlParameter("@ASSBL_VAL", ASSBL_VAL);

        param[39] = new SqlParameter("@ITC_LICENSE", ITC_LICENSE);
        param[40] = new SqlParameter("@INVOICE_NO_DATE", INVOICE_NO_DATE);
        param[41] = new SqlParameter("@DUTY_VAL_WORDS", DUTY_VAL_WORDS);
        param[42] = new SqlParameter("@ASSBL_VAL_WORDS", ASSBL_VAL_WORDS);
        param[43] = new SqlParameter("@M_BRANCHCODE", M_BRANCHCODE);
        param[44] = new SqlParameter("@M_YEAR", M_YEAR);
        param[45] = new SqlParameter("@M_WORKINGPERIOD", M_WORKINGPERIOD);
        param[46] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

        param[47] = new SqlParameter("@Mflag", flag);
        param[48] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
        param[48].Direction = ParameterDirection.Output;
        param[49] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[49].Direction = ParameterDirection.Output;
        param[50] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
        param[50].Direction = ParameterDirection.Output;

        param[51] = new SqlParameter("@IEC_NO", IEC_NO);

        SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_ManuallBE_INSERT_UPDATE", param);

        result = Convert.ToInt32(param[48].Value.ToString());
        if (flag == "S")
            UPDATE_ID = Convert.ToInt32(param[50].Value.ToString());
       

    }
    catch(Exception ex)
    {
        er.makeLog(ex.Message);
    }
    return result;
}

public List<Import_ManualBE_LC> Load_ManualBE_AllDetails(DataTable dt)
{
    List<Import_ManualBE_LC> list = new List<Import_ManualBE_LC>();

    int i = 0;

    while (dt.Rows.Count > i)
    {
        DataRow row = dt.Rows[i];
        list.Add(new Import_ManualBE_LC()
        {
            JOBNO = row["JOBNO"].ToString(),
            DATE1 = row["DATE1"].ToString(),
            IMPORTER = row["IMPORTER"].ToString(),
            IM_ADDRESS1 = row["IM_ADDRESS1"].ToString(),
            IM_ADDRESS2 = row["IM_ADDRESS2"].ToString(),
            IM_ADDRESS3 = row["IM_ADDRESS3"].ToString(),
            IM_ADDRESS4 = row["IM_ADDRESS4"].ToString(),
            IM_ADDRESS5 = row["IM_ADDRESS5"].ToString(),
            SUPPLIERNAME = row["SUPPLIERNAME"].ToString(),
            SUP_ADDRESS1 = row["SUP_ADDRESS1"].ToString(),
            SUP_ADDRESS2 = row["SUP_ADDRESS2"].ToString(),
            SUP_ADDRESS3 = row["SUP_ADDRESS3"].ToString(),
            SUP_ADDRESS4 = row["SUP_ADDRESS4"].ToString(),
            SUP_ADDRESS5 = row["SUP_ADDRESS5"].ToString(),
            INCOME_TAX = row["INCOME_TAX"].ToString(),
            PRIOR_STAMP = row["PRIOR_STAMP"].ToString(),
            VESSEL_NAME = row["VESSEL_NAME"].ToString(),
            LINE_NO = row["LINE_NO"].ToString(),
            PORT_SHIPMENT = row["PORT_SHIPMENT"].ToString(),
            IMPORT_DEPT = row["IMPORT_DEPT"].ToString(),
            ROTATION_NO_DATE = row["ROTATION_NO_DATE"].ToString(),
            COUN_CONSIGNMENT = row["COUN_CONSIGNMENT"].ToString(),
            COUN_ORIGIN = row["COUN_ORIGIN"].ToString(),
            AWBL_NO = row["AWBL_NO"].ToString(),
            AWBL_DATE = row["AWBL_DATE"].ToString(),
            HAWB_NO = row["HAWB_NO"].ToString(),
            HAWB_DATE = row["HAWB_DATE"].ToString(),
            GROSS_WEIGHT = row["GROSS_WEIGHT"].ToString(),
            TOTAL_PKGS = row["TOTAL_PKGS"].ToString(),
            AGENCY_COMMISION = row["AGENCY_COMMISION"].ToString(),
            MIS_CHARGES = row["MIS_CHARGES"].ToString(),
            MIS_CURRENCY = row["MIS_CURRENCY"].ToString(),
            TERMS = row["TERMS"].ToString(),
            TOTAL_VAL = row["TOTAL_VAL"].ToString(),
            LANDING_CHARGES = row["LANDING_CHARGES"].ToString(),
            DUTY_VALUE = row["DUTY_VALUE"].ToString(),
            ASSBL_VAL = row["ASSBL_VAL"].ToString(),
            ITC_LICENSE = row["ITC_LICENSE"].ToString(),
            INVOICE_NO_DATE = row["INVOICE_NO_DATE"].ToString(),
            DUTY_VAL_WORDS = row["DUTY_VAL_WORDS"].ToString(),
            ASSBL_VAL_WORDS = row["ASSBL_VAL_WORDS"].ToString(),
            M_BRANCHCODE = row["M_BRANCHCODE"].ToString(),
            M_YEAR = row["M_YEAR"].ToString(),
            M_WORKINGPERIOD = row["M_WORKINGPERIOD"].ToString()

        });
        i++;
    }

    return list;
}

 public List<Import_ManualBE_LC> Load_ManualBE_Details(DataTable dt)
    {
        List<Import_ManualBE_LC> list = new List<Import_ManualBE_LC>();

        dt.Columns.Add("PageBreak");
        int i = 0;
     
        while (dt.Rows.Count > i)
        {
            DataRow row = dt.Rows[i];
            for (i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(new Import_ManualBE_LC()
                    {
                        JOBNO = row["JOBNO"].ToString(),
                        ITEM_SLNO = row["ITEM_SLNO"].ToString(),
                        ITEM_DESCRIPTION = row["ITEM_DESCRIPTION"].ToString()

                    });

                dt.Rows[i]["PageBreak"] = i + 1;

                //i++;
            }
           
        }
        return list;
    }
 public DataSet Manual_BE_grid()
 {

     try
     {

         SqlParameter[] param = new SqlParameter[10];

         param[0] = new SqlParameter("@JobNo", JOBNO);
         param[1] = new SqlParameter("@Select_Type", Select_Type);
         
         param[2] = new SqlParameter("@Branch_Code", M_BRANCHCODE);

         param[3] = new SqlParameter("@Working_Period", Working_Period);
         param[4] = new SqlParameter("@USER_ID", USER_ID);

         param[5] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
         param[5].Direction = ParameterDirection.Output;
         param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
         param[6].Direction = ParameterDirection.Output;

         ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "Sp_IMP_MANUAL_BE_GRID", param);
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


 public int Manual_BE_insertupdate()
 {
     try
     {


         SqlParameter[] param = new SqlParameter[80];
         param[0] = new SqlParameter("@Sl_No", Sl_No);
         param[1] = new SqlParameter("@Jobno", Jobno);
         param[2] = new SqlParameter("@Numbers_Desc ", Numbers_Desc);
         param[3] = new SqlParameter("@Marks_Numbers ", Marks_Numbers);
         param[4] = new SqlParameter("@Item_Slno ", Item_Slno);
         param[5] = new SqlParameter("@Unit_Code", Unit_Code);
         param[6] = new SqlParameter("@weight ", Weight);
         param[7] = new SqlParameter("@Goods_Description ", Goods_Description);
         param[8] = new SqlParameter("@CTH_No_Notn_no ", CTH_No_Notn_no);
         param[9] = new SqlParameter("@Duty_Code ", Duty_Code);
         param[10] = new SqlParameter("@Assablevalue ", Assablevalue);
         param[11] = new SqlParameter("@CTH_Rate ", CTH_Rate);
         param[12] = new SqlParameter("@CTH_AMT ", CTH_AMT);

         param[13] = new SqlParameter("@CETH_Not ", CETH_Not);
         param[14] = new SqlParameter("@Col9_and_11 ", Col9_and_11);
         param[15] = new SqlParameter("@CETH_Rate ", CETH_Rate);
         param[16] = new SqlParameter("@CETH_Amt ", CETH_Amt);
         param[17] = new SqlParameter("@Total_Duty ", Total_Duty);
         param[18] = new SqlParameter("@Branch_code ", M_BRANCHCODE);
         param[19] = new SqlParameter("@Working_Period ", M_WORKINGPERIOD);
         param[20] = new SqlParameter("@User_Id ", USER_ID);
         param[21] = new SqlParameter("@Flag ", Flag);

         param[22] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
         param[22].Direction = ParameterDirection.Output;
         param[23] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
         param[23].Direction = ParameterDirection.Output;


         SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_Imp_ManualBe_ins_upd", param);
         result = Convert.ToInt32(param[22].Value.ToString());
     }
     catch (Exception ex)
     {
         ErrorLogs er = new ErrorLogs();
         er.makeLog(ex.Message);
         //throw new ArgumentException(ex.Message);
     }
     return result;
 }

 public DataSet Manual_BE_rpt()
 {

     try
     {

         SqlParameter[] param = new SqlParameter[10];

         param[0] = new SqlParameter("@jobno", Jobno);
         param[1] = new SqlParameter("@Branch_Code", M_BRANCHCODE);
         param[2] = new SqlParameter("@Working_period", Working_Period);

         param[3] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
         param[3].Direction = ParameterDirection.Output;
         param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
         param[4].Direction = ParameterDirection.Output;

         ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "Sp_IMP_ManualBE_invoice_Rpt", param);
         result = Convert.ToInt32(param[3].Value.ToString());

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