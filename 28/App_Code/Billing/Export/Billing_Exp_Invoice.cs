using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;

using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;


public class Billing_Exp_Invoice
{

    public int result = 0, UPDATE_ID = 0;

    private string _Mode,_Branch,_Mflag,_ID,_JOBNO,_EXPORTER_NAME,_MODE,_BILL_INV_NO,_BILL_INV_DATE,_AC_MAINTAINING_BRANCH,_INV_NO,_INV_DATE,_SB_NO
                   ,_SB_DATE,_MAWB_NO,_HAWB_NO,_CONTAINER_NO,_NO_OF_PKG,_GROSS_WGT,_NET_WGT,_VOLUME,_VESSEL,_DESTINATION,_COMMODITY,_FREIGHT_STATUS
                   ,_AC_BEHALF,_SHIPPER_NAME,_SHIPPER_ADDRESS,_CONSIGNEE_NAME,_CONSIGNEE_ADDRESS,_NOTIFY_PARTY_1,_NOTIFY_PARTY_1_ADDRESS,_NOTIFY_PARTY_2
                   ,_NOTIFY_PARTY_2_ADDRESS,_REMARKS,_NON_TAXABLE_AMT,_TAXABLE_AMT,_TAX_LEDGER_1,_LEDGER_1_TAX,_LEDGER_1_TAX_AMT,_TAX_LEDGER_2,_LEDGER_2_TAX
                   ,_LEDGER_2_TAX_AMT,_TAX_LEDGER_3,_LEDGER_3_TAX,_LEDGER_3_TAX_AMT,_TOTAL_TAX_AMT,_TOTAL_AMT_TAX,_DESCRIPTION,_BRANCH_CODE,_WORKINGPERIOD
                   ,_Exp_Name,_Flag,_from_date,_todate,_Ac_Branch,_USERID,_Bill_No,_Branch_Type,_Tax_Mode,_CHARGE_WGT,_CHARGE_TYPE,_JOB_DATE,_BILL_STATUS
                   ,_Branch_No,_TAX_LEDGER_4,_LEDGER_4_TAX,_LEDGER_4_TAX_AMT;

    public string CHARGE_TYPE {get { return _CHARGE_TYPE; } set { _CHARGE_TYPE = value; }}
    public string CHARGE_WGT { get { return _CHARGE_WGT; } set { _CHARGE_WGT = value; }}
    public string JOB_DATE {get { return _JOB_DATE; }set { _JOB_DATE = value; }}
    public string BILL_STATUS { get { return _BILL_STATUS; } set { _BILL_STATUS = value; } }
    public string Tax_Mode { get { return _Tax_Mode; } set { _Tax_Mode = value; } }
    public string Bill_No { get { return _Bill_No; } set { _Bill_No = value; } }
    public string Branch_Type { get { return _Branch_Type; } set { _Branch_Type = value; } }
    public string from_date { get { return _from_date; } set { _from_date = value; } }
    public string todate { get { return _todate; } set { _todate = value; } }
    public string Ac_Branch { get { return _Ac_Branch; } set { _Ac_Branch = value; } }

    public string Mode { get { return _Mode; } set { _Mode = value; } }
    public string Branch { get { return _Branch; } set { _Branch = value; } }
    public string Mflag { get { return _Mflag; } set { _Mflag = value; } }

    public string ID { get { return _ID; } set { _ID = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string EXPORTER_NAME { get { return _EXPORTER_NAME; } set { _EXPORTER_NAME = value; } }
    public string MODE { get { return _MODE; } set { _MODE = value; } }
    public string BILL_INV_NO { get { return _BILL_INV_NO; } set { _BILL_INV_NO = value; } }
    public string BILL_INV_DATE { get { return _BILL_INV_DATE; } set { _BILL_INV_DATE = value; } }
    public string AC_MAINTAINING_BRANCH { get { return _AC_MAINTAINING_BRANCH; } set { _AC_MAINTAINING_BRANCH = value; } }
    public string INV_NO { get { return _INV_NO; } set { _INV_NO = value; } }
    public string INV_DATE { get { return _INV_DATE; } set { _INV_DATE = value; } }
    public string SB_NO { get { return _SB_NO; } set { _SB_NO = value; } }
    public string SB_DATE { get { return _SB_DATE; } set { _SB_DATE = value; } }

    public string MAWB_NO { get { return _MAWB_NO; } set { _MAWB_NO = value; } }
    public string HAWB_NO { get { return _HAWB_NO; } set { _HAWB_NO = value; } }
    public string CONTAINER_NO { get { return _CONTAINER_NO; } set { _CONTAINER_NO = value; } }
    public string NO_OF_PKG { get { return _NO_OF_PKG; } set { _NO_OF_PKG = value; } }
    public string GROSS_WGT { get { return _GROSS_WGT; } set { _GROSS_WGT = value; } }
    public string NET_WGT { get { return _NET_WGT; } set { _NET_WGT = value; } }
    public string VOLUME { get { return _VOLUME; } set { _VOLUME = value; } }
    public string VESSEL { get { return _VESSEL; } set { _VESSEL = value; } }

    public string DESTINATION { get { return _DESTINATION; } set { _DESTINATION = value; } }
    public string COMMODITY { get { return _COMMODITY; } set { _COMMODITY = value; } }
    public string FREIGHT_STATUS { get { return _FREIGHT_STATUS; } set { _FREIGHT_STATUS = value; } }
    public string AC_BEHALF { get { return _AC_BEHALF; } set { _AC_BEHALF = value; } }
    public string SHIPPER_NAME { get { return _SHIPPER_NAME; } set { _SHIPPER_NAME = value; } }

    public string SHIPPER_ADDRESS { get { return _SHIPPER_ADDRESS; } set { _SHIPPER_ADDRESS = value; } }
    public string CONSIGNEE_NAME { get { return _CONSIGNEE_NAME; } set { _CONSIGNEE_NAME = value; } }
    public string CONSIGNEE_ADDRESS { get { return _CONSIGNEE_ADDRESS; } set { _CONSIGNEE_ADDRESS = value; } }
    public string NOTIFY_PARTY_1 { get { return _NOTIFY_PARTY_1; } set { _NOTIFY_PARTY_1 = value; } }
    public string NOTIFY_PARTY_1_ADDRESS { get { return _NOTIFY_PARTY_1_ADDRESS; } set { _NOTIFY_PARTY_1_ADDRESS = value; } }
    public string NOTIFY_PARTY_2 { get { return _NOTIFY_PARTY_2; } set { _NOTIFY_PARTY_2 = value; } }
    public string NOTIFY_PARTY_2_ADDRESS { get { return _NOTIFY_PARTY_2_ADDRESS; } set { _NOTIFY_PARTY_2_ADDRESS = value; } }
    public string REMARKS { get { return _REMARKS; } set { _REMARKS = value; } }

    public string NON_TAXABLE_AMT { get { return _NON_TAXABLE_AMT; } set { _NON_TAXABLE_AMT = value; } }
    public string TAXABLE_AMT { get { return _TAXABLE_AMT; } set { _TAXABLE_AMT = value; } }
    public string TAX_LEDGER_1 { get { return _TAX_LEDGER_1; } set { _TAX_LEDGER_1 = value; } }
    public string LEDGER_1_TAX { get { return _LEDGER_1_TAX; } set { _LEDGER_1_TAX = value; } }
    public string LEDGER_1_TAX_AMT { get { return _LEDGER_1_TAX_AMT; } set { _LEDGER_1_TAX_AMT = value; } }
    public string TAX_LEDGER_2 { get { return _TAX_LEDGER_2; } set { _TAX_LEDGER_2 = value; } }
    public string LEDGER_2_TAX { get { return _LEDGER_2_TAX; } set { _LEDGER_2_TAX = value; } }
    public string LEDGER_2_TAX_AMT { get { return _LEDGER_2_TAX_AMT; } set { _LEDGER_2_TAX_AMT = value; } }
    public string TAX_LEDGER_3 { get { return _TAX_LEDGER_3; } set { _TAX_LEDGER_3 = value; } }
    public string LEDGER_3_TAX { get { return _LEDGER_3_TAX; } set { _LEDGER_3_TAX = value; } }
    public string LEDGER_3_TAX_AMT { get { return _LEDGER_3_TAX_AMT; } set { _LEDGER_3_TAX_AMT = value; } }
    public string TOTAL_TAX_AMT { get { return _TOTAL_TAX_AMT; } set { _TOTAL_TAX_AMT = value; } }

    public string DESCRIPTION { get { return _DESCRIPTION; } set { _DESCRIPTION = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string WORKINGPERIOD { get { return _WORKINGPERIOD; } set { _WORKINGPERIOD = value; } }
    public string USERID { get { return _USERID; } set { _USERID = value; } }
    public string TOTAL_AMT_TAX { get { return _TOTAL_AMT_TAX; } set { _TOTAL_AMT_TAX = value; } }
    public string Flag { get { return _Flag; } set { _Flag = value; } }
    public string Exp_Name { get { return _Exp_Name; } set { _Exp_Name = value; } }
    public string Branch_No { get { return _Branch_No; } set { _Branch_No = value; } }

    private string _FILE_REF_NO,_Inv_Type,_EXP_BRANCH_SLNO,_NOTIFY_PARTY_1_BR_SLNO,_Shipment_Type,_FROM_QUOTATION,_ADVANCE_AMT,_COMPANY_LICENSE,_FOB_Value;
    
    public string EXP_BRANCH_SLNO { get { return _EXP_BRANCH_SLNO; } set { _EXP_BRANCH_SLNO = value; } }
    public string NOTIFY_PARTY_1_BR_SLNO { get { return _NOTIFY_PARTY_1_BR_SLNO; } set { _NOTIFY_PARTY_1_BR_SLNO = value; } }
    public string Inv_Type  { get { return _Inv_Type; } set { _Inv_Type = value; } }
    public string FILE_REF_NO {get { return _FILE_REF_NO; } set { _FILE_REF_NO = value; }}
    public string Shipment_Type { get { return _Shipment_Type; } set { _Shipment_Type = value; } }
    public string FROM_QUOTATION { get { return _FROM_QUOTATION; } set { _FROM_QUOTATION = value; } }
    public string ADVANCE_AMT { get { return _ADVANCE_AMT; } set { _ADVANCE_AMT = value; } }
    public string COMPANY_LICENSE { get { return _COMPANY_LICENSE; } set { _COMPANY_LICENSE = value; } }

    public string TAX_LEDGER_4 { get { return _TAX_LEDGER_4; } set { _TAX_LEDGER_4 = value; } }
    public string LEDGER_4_TAX { get { return _LEDGER_4_TAX; } set { _LEDGER_4_TAX = value; } }
    public string LEDGER_4_TAX_AMT { get { return _LEDGER_4_TAX_AMT; } set { _LEDGER_4_TAX_AMT = value; } }
    public string FOB_Value { get { return _FOB_Value; } set { _FOB_Value = value; } }

    public String Xml_D;
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet ds = new DataSet();
    public DataSet Select_Exp_INV()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Tr_mode", Mode);
            param[1] = new SqlParameter("@Branch", Branch);
            param[2] = new SqlParameter("@Exp_Name", Exp_Name);
            param[3] = new SqlParameter("@Jobno", JOBNO);
            param[4] = new SqlParameter("@Mflag", Mflag);
            param[5] = new SqlParameter("@Branch_Type", Branch_Type);
            param[6] = new SqlParameter("@Bill_invno", BILL_INV_NO);
            param[7] = new SqlParameter("@Inv_Type", Inv_Type);
            param[8] = new SqlParameter("@Shipment_Type", Shipment_Type);
            param[9] = new SqlParameter("@FROM_QUOTATION", FROM_QUOTATION);
            param[10] = new SqlParameter("@COMPANY_LICENSE", COMPANY_LICENSE);
            
            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("BILL_EXPORT_INV_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Select_Exp_INV(string constr)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Tr_mode", Mode);
            param[1] = new SqlParameter("@Branch", Branch);
            param[2] = new SqlParameter("@Exp_Name", Exp_Name);
            param[3] = new SqlParameter("@Jobno", JOBNO);
            param[4] = new SqlParameter("@Mflag", Mflag);
            param[5] = new SqlParameter("@Branch_Type", Branch_Type);
            param[6] = new SqlParameter("@Bill_invno", BILL_INV_NO);
            param[7] = new SqlParameter("@Inv_Type", Inv_Type);
            param[8] = new SqlParameter("@Shipment_Type", Shipment_Type);
            param[9] = new SqlParameter("@FROM_QUOTATION", FROM_QUOTATION);
            param[10] = new SqlParameter("@COMPANY_LICENSE", COMPANY_LICENSE);

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(constr, CommandType.StoredProcedure, "BILL_EXPORT_INV_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Select_Exp_INV_QS()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Tr_mode", Mode);
            param[1] = new SqlParameter("@Branch", Branch);
            param[2] = new SqlParameter("@Exp_Name", Exp_Name);
            param[3] = new SqlParameter("@Jobno", JOBNO);
            param[4] = new SqlParameter("@Mflag", Mflag);
            param[5] = new SqlParameter("@Branch_Type", Branch_Type);
            param[6] = new SqlParameter("@Bill_invno", BILL_INV_NO);

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@BILL_STATUS", BILL_STATUS);

            ds = Connection.Get_Dataset("BILL_EXPORT_INV_QUICK_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public DataSet Invoice_Job_Rpt_data()
    {
        string SP_Name = string.Empty;
        string C_lic = string.Empty;
        C_lic = Connection.Company_License().ToLower();

        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Bill_Inv_No", BILL_INV_NO);
            param[1] = new SqlParameter("@Brach", Branch);
            param[2] = new SqlParameter("@Tax_Mode", Tax_Mode);
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            if (C_lic == "eri00247" || C_lic.ToLower() == "eri00010")
            {
                SP_Name = "BILL_EXPORT_JOB_RPT_BAS";
            }
            else if (C_lic.ToLower() == "eri00314")
            {
                SP_Name = "BILL_EXPORT_JOB_RPT_SABARI";
            }
            else
            {
                SP_Name = "BILL_EXPORT_JOB_RPT";
            }
            ds = Connection.Get_Dataset(SP_Name, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public void Exp_Billing_Invoice_INS_UPD()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[100];

            param[0] = new SqlParameter("@ID", ID);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@EXPORTER_NAME", EXPORTER_NAME);
            param[3] = new SqlParameter("@MODE", MODE);
            param[4] = new SqlParameter("@BILL_INV_NO",BILL_INV_NO ); 

            if (BILL_INV_DATE == "" || BILL_INV_DATE == null)
            {
                BILL_INV_DATE = "01/01/1900";
            }
            param[5] = new SqlParameter("@BILL_INV_DATE", DateTime.Parse(BILL_INV_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[6] = new SqlParameter("@AC_MAINTAINING_BRANCH", AC_MAINTAINING_BRANCH);
            param[7] = new SqlParameter("@INV_NO", INV_NO);

            if (INV_DATE == "" || INV_DATE == null)
            {
                INV_DATE = "01/01/1900";
            }

            param[8] = new SqlParameter("@INV_DATE", DateTime.Parse(INV_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[9] = new SqlParameter("@SB_NO", SB_NO);

            if (SB_DATE == "" || SB_DATE == null)
            {
                SB_DATE = "01/01/1900";
            }
            param[10] = new SqlParameter("@SB_DATE", DateTime.Parse(SB_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[11] = new SqlParameter("@MAWB_NO", MAWB_NO);
            param[12] = new SqlParameter("@HAWB_NO", HAWB_NO);
            param[13] = new SqlParameter("@CONTAINER_NO", CONTAINER_NO);
            param[14] = new SqlParameter("@NO_OF_PKG", NO_OF_PKG);

            param[15] = new SqlParameter("@GROSS_WGT", GROSS_WGT);
            param[16] = new SqlParameter("@NET_WGT", NET_WGT);
            param[17] = new SqlParameter("@VOLUME", VOLUME);
            param[18] = new SqlParameter("@VESSEL", VESSEL);
            param[19] = new SqlParameter("@DESTINATION", DESTINATION);
            param[20] = new SqlParameter("@COMMODITY", COMMODITY);

            param[21] = new SqlParameter("@FREIGHT_STATUS", FREIGHT_STATUS);
            param[22] = new SqlParameter("@AC_BEHALF", AC_BEHALF);
            param[23] = new SqlParameter("@SHIPPER_NAME", SHIPPER_NAME);
            param[24] = new SqlParameter("@SHIPPER_ADDRESS", SHIPPER_ADDRESS);
            param[25] = new SqlParameter("@CONSIGNEE_NAME", CONSIGNEE_NAME);

            param[26] = new SqlParameter("@CONSIGNEE_ADDRESS", CONSIGNEE_ADDRESS);
            param[27] = new SqlParameter("@NOTIFY_PARTY_1", NOTIFY_PARTY_1);
            param[29] = new SqlParameter("@NOTIFY_PARTY_1_ADDRESS", NOTIFY_PARTY_1_ADDRESS);
            param[30] = new SqlParameter("@NOTIFY_PARTY_2", NOTIFY_PARTY_2);
            param[31] = new SqlParameter("@NOTIFY_PARTY_2_ADDRESS", NOTIFY_PARTY_2_ADDRESS);
            param[32] = new SqlParameter("@REMARKS", REMARKS);
            param[33] = new SqlParameter("@NON_TAXABLE_AMT", NON_TAXABLE_AMT);
            param[34] = new SqlParameter("@TAXABLE_AMT", TAXABLE_AMT);
            param[35] = new SqlParameter("@TAX_LEDGER_1", TAX_LEDGER_1);
            param[36] = new SqlParameter("@LEDGER_1_TAX", LEDGER_1_TAX);
            param[37] = new SqlParameter("@LEDGER_1_TAX_AMT", LEDGER_1_TAX_AMT);

            param[38] = new SqlParameter("@TAX_LEDGER_2", TAX_LEDGER_2);
            param[39] = new SqlParameter("@LEDGER_2_TAX", LEDGER_2_TAX);
            param[40] = new SqlParameter("@LEDGER_2_TAX_AMT", LEDGER_2_TAX_AMT);
            param[41] = new SqlParameter("@TAX_LEDGER_3", TAX_LEDGER_3);
            param[42] = new SqlParameter("@LEDGER_3_TAX", LEDGER_3_TAX);
            param[43] = new SqlParameter("@LEDGER_3_TAX_AMT", LEDGER_3_TAX_AMT);
            param[44] = new SqlParameter("@TOTAL_TAX_AMT", TOTAL_TAX_AMT);
            param[45] = new SqlParameter("@TOTAL_AMT_TAX", TOTAL_AMT_TAX);

            param[46] = new SqlParameter("@DESCRIPTION", DESCRIPTION);
            param[47] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[48] = new SqlParameter("@WORKINGPERIOD", WORKINGPERIOD);

            param[49] = new SqlParameter("@USERID", USERID);
          
            param[53] = new SqlParameter("@Branch", Branch);
            param[54] = new SqlParameter("@flag", Flag);

            param[55] = new SqlParameter("@FILE_REF_NO", FILE_REF_NO);
            param[56] = new SqlParameter("@xmlString", Xml_D);
           // param[56] = new SqlParameter("@XML_Con_data", XML_Con_data);
            param[57] = new SqlParameter("@CHARGE_WGT", CHARGE_WGT);
            param[58] = new SqlParameter("@CHARGE_TYPE", CHARGE_TYPE);
            
            if (JOB_DATE == "" || JOB_DATE == null)
            {
                JOB_DATE = "01/01/1900";
            }
            param[59] = new SqlParameter("@JOB_DATE", DateTime.Parse(JOB_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[60] = new SqlParameter("@INV_TYPE", Inv_Type);


            param[61] = new SqlParameter("@EXP_BRANCH_SLNO", EXP_BRANCH_SLNO);
            param[62] = new SqlParameter("@NOTIFY_PARTY_1_BR_SLNO", NOTIFY_PARTY_1_BR_SLNO);


            param[71] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[71].Direction = ParameterDirection.Output;

            param[72] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[72].Direction = ParameterDirection.Output;

            param[73] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[73].Direction = ParameterDirection.Output;

            param[74] = new SqlParameter("@BILL_STATUS ", BILL_STATUS);
            param[75] = new SqlParameter("@SHIPMENT_TYPE", Shipment_Type);
            param[76] = new SqlParameter("@FROM_QUOTATION", FROM_QUOTATION);
            param[77] = new SqlParameter("@ADVANCE_AMT", ADVANCE_AMT);
            param[78] = new SqlParameter("@Branch_No", Branch_No);

            param[79] = new SqlParameter("@TAX_LEDGER_4", TAX_LEDGER_4);
            param[80] = new SqlParameter("@LEDGER_4_TAX", LEDGER_4_TAX);
            param[81] = new SqlParameter("@LEDGER_4_TAX_AMT", LEDGER_4_TAX_AMT);
            param[82] = new SqlParameter("@FOB_Value", FOB_Value);
            

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "BILL_EXP_JOB_INVOICE_INS_UPD", param);
            result = Convert.ToInt32(param[71].Value.ToString());

            if (Flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[73].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public DataSet BILL_EXPORT_JOB_INV_SEARCH()
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (from_date != string.Empty && from_date != null)
            {
                arr = from_date.Split('/');
                from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (todate != string.Empty && todate != null)
            {
                arr2 = todate.Split('/');
                todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Ac_Branch", Ac_Branch);
            param[1] = new SqlParameter("@Shipper_name", Exp_Name);
            param[2] = new SqlParameter("@jobno", JOBNO);
            param[3] = new SqlParameter("@from_date", from_date);
            param[4] = new SqlParameter("@to_date", todate);
            param[5] = new SqlParameter("@Tr_mode", Mode);
            param[6] = new SqlParameter("@Branch", Branch);
            param[7] = new SqlParameter("@Bill_No", Bill_No);
            param[8] = new SqlParameter("@Flag", Flag);
         
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@BILL_STATUS", BILL_STATUS);
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "BILL_EXPORT_JOB_INV_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public void Open_Export_Jobinv_XLs_Report(string ddlAC_Branch_, string Exp_name_, string Jobno_, string Fromdate_
                                  , string Todate_, string Mode_, string Branch_, string Type_, string Bill_No_, string Month_, string BILL_STATUS_)
    {
        
        if (Fromdate_ != string.Empty || Todate_ != string.Empty)
        {
            from_date = Fromdate_;
            todate = Todate_;
        }
        else
        {
            if (Month_ != string.Empty)
            {
                string[] arr_Month = new string[] { };
                arr_Month = Month_.Split('-');
                from_date = arr_Month[0];
                todate = arr_Month[1];
            }
            else
            {
                from_date = Fromdate_;
                todate = Todate_;
            }
        }

        HttpResponse Response = HttpContext.Current.Response;
        Ac_Branch = ddlAC_Branch_;
        Exp_Name = Exp_name_;
        JOBNO = Jobno_;
        //from_date = Fromdate_;
       //todate = Todate_;
        Mode = Mode_;
        Branch = Branch_;
        Bill_No = Bill_No_;
        BILL_STATUS = BILL_STATUS_;
        Flag = "Excel_Export";


        DataTable dt;
        if (HttpContext.Current.Session["Bill_EXP_MASTER_XL"] != null && HttpContext.Current.Session["Bill_EXP_MASTER_XL"] != string.Empty)
        {
            dt = (DataTable)HttpContext.Current.Session["Bill_EXP_MASTER_XL"]; 
        }
        else
        {
             DataSet dss = BILL_EXPORT_JOB_INV_SEARCH();
             dt = dss.Tables[0];
        }
        
        int lastRowIndex = 0;

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "EXPORTJOBINVOICE";
        string strrptNametime = Filename + "_" + s;

        if (Type_ == "excel")
        {

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridView gv = new GridView();
                gv.AllowPaging = false;
                gv.DataSource = dt;
                gv.DataBind();

                if (gv.Rows.Count > 0)
                {
                    foreach (TableCell cell in gv.HeaderRow.Cells)
                    {
                        cell.BackColor = gv.HeaderStyle.BackColor;
                    }
                    for (int i = 0; i < gv.HeaderRow.Cells.Count; i++)
                    {
                        gv.HeaderRow.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#D8D8D8 ");
                    }
                    gv.RenderControl(hw);
                }

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }

        }
        if (Type_ == "Pdf")
        {
           

        }

    }

    public void Open_Export_Jobinv_XLs_Report_tally(string ddlAC_Branch_, string Exp_name_, string Jobno_, string Fromdate_
                                  , string Todate_, string Mode_, string Branch_, string Type_, string Bill_No_, string Month_, string BILL_STATUS_)
    {

        if (Fromdate_ != string.Empty || Todate_ != string.Empty)
        {
            from_date = Fromdate_;
            todate = Todate_;
        }
        else
        {
            if (Month_ != string.Empty)
            {
                string[] arr_Month = new string[] { };
                arr_Month = Month_.Split('-');
                from_date = arr_Month[0];
                todate = arr_Month[1];
            }
            else
            {
                from_date = Fromdate_;
                todate = Todate_;
            }
        }


        HttpResponse Response = HttpContext.Current.Response;
        Ac_Branch = ddlAC_Branch_;
        Exp_Name = Exp_name_;
        JOBNO = Jobno_;
        //from_date = Fromdate_;
        //todate = Todate_;
        Mode = Mode_;
        Bill_No = Bill_No_;
        Branch = Branch_;
        BILL_STATUS = BILL_STATUS_;
        Flag = "Excel_Tally";

        DataTable dt;
        if (HttpContext.Current.Session["Bill_EXP_MASTER_Tally"] != null && HttpContext.Current.Session["Bill_EXP_MASTER_Tally"] != string.Empty)
        {
            //DataSet dss = (DataSet)HttpContext.Current.Session["Bill_EXP_MASTER_Tally"];
            //dt = dss.Tables[0];
            dt = (DataTable)HttpContext.Current.Session["Bill_EXP_MASTER_Tally"]; 
        }
        else
        {
            DataSet dss = BILL_EXPORT_JOB_INV_SEARCH();
            dt = dss.Tables[0];
        }
        int lastRowIndex = 0;

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "EXPORT_TALLY_DATA";
        string strrptNametime = Filename + "_" + s;

        if (Type_ == "Tally")
        {

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridView gv = new GridView();
                gv.AllowPaging = false;
                gv.DataSource = dt;
                gv.DataBind();

                if (gv.Rows.Count > 0)
                {
                    foreach (TableCell cell in gv.HeaderRow.Cells)
                    {
                        cell.BackColor = gv.HeaderStyle.BackColor;
                    }
                    for (int i = 0; i < gv.HeaderRow.Cells.Count; i++)
                    {
                        gv.HeaderRow.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#D8D8D8 ");
                    }
                    gv.RenderControl(hw);
                }
                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }

        }
        if (Type_ == "Pdf")
        {


        }

    }

}