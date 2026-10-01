using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Net;
using BussinessObject;

using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

public class Client_Master_New_cs
{

    public int result = 0, _totalRows = 0, _PayableId = 0, _ReceivableId = 0,_IMP_EXP_ID=0,_IMP_EXP_BRSLNO=0;

    private bool _A_C_UNLIMITED = false, _A_C_COD = false, _A_C_CHK_OVERDUE = false,
               _Check_CreditOnHold = false, _Check_OptionalCriteria = false, _CHK_Vendor_CLimit = false, _Chk_PaymentHold = false,
               _Check_SpecifiedPerson = false;

    private string _STANDARD_TYPE, _DEFAULT_ID, _YEAR, _flag, _IMP_EXP_NAME, _IMP_EXP_IECNO;



    public int totalRows { get { return _totalRows; } set { _totalRows = value; } }
    public int PayableId { get { return _PayableId; } set { _PayableId = value; } }
    public int ReceivableId { get { return _ReceivableId; } set { _ReceivableId = value; } }
    public int IMP_EXP_ID{ get { return _IMP_EXP_ID; } set { _IMP_EXP_ID = value; } }
    public int IMP_EXP_BRSLNO{ get { return _IMP_EXP_BRSLNO; } set { _IMP_EXP_BRSLNO = value; } }



    public string STANDARD_TYPE { get { return _STANDARD_TYPE; } set { _STANDARD_TYPE = value; } }
    public string DEFAULT_ID { get { return _DEFAULT_ID; } set { _DEFAULT_ID = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }



    public bool A_C_UNLIMITED { get { return _A_C_UNLIMITED; } set { _A_C_UNLIMITED = value; } }
    public bool A_C_COD { get { return _A_C_COD; } set { _A_C_COD = value; } }
    public bool A_C_CHK_OVERDUE { get { return _A_C_CHK_OVERDUE; } set { _A_C_CHK_OVERDUE = value; } }
    public bool CHECK_CREDITONHOLD { get { return _Check_CreditOnHold; } set { _Check_CreditOnHold = value; } }
    public bool Check_OptionalCriteria { get { return _Check_OptionalCriteria; } set { _Check_OptionalCriteria = value; } }
    public bool CHK_Vendor_CLimit { get { return _CHK_Vendor_CLimit; } set { _CHK_Vendor_CLimit = value; } }
    public bool CHK_PaymentHold { get { return _Chk_PaymentHold; } set { _Chk_PaymentHold = value; } }
    public bool CHK_SpecifiedPerson { get { return _Check_SpecifiedPerson; } set { _Check_SpecifiedPerson = value; } }
   

    DataTable dt = new DataTable();
    DataSet ds = new DataSet();

    
    public DataSet ClientMaster_Search(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@ClientName", objUserBL.A1); //Eimp_exp_name
            param[1] = new SqlParameter("@IEC_No", objUserBL.A2);//Eimp_exp_iecno
            param[2] = new SqlParameter("@startRowIndex", string.IsNullOrEmpty(objUserBL.A3) ? 1 : int.Parse(objUserBL.A3));//startRowIndex
            param[3] = new SqlParameter("@maximumRows", string.IsNullOrEmpty(objUserBL.A4) ? 10 : int.Parse(objUserBL.A4));//maximumRows
            param[4] = new SqlParameter("@STANDARD_TYPE", objUserBL.A5); 
            param[5] = new SqlParameter("@M_COMMERCIAL_TAX_STATECODE", objUserBL.A6);

            param[19] = new SqlParameter("@totalRows", SqlDbType.Int);
            param[19].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("CLIENTMASTER_SEARCH_NEW", param);//CLIENTMASTER_SEARCH_NEW
            if (param[19].Value != null && param[19].Value != DBNull.Value)
                result = Convert.ToInt32(param[19].Value);
            else
                result = 0;


            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                ds.Tables.Add(new DataTable());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet ClientMaster_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[21];
            param[2] = new SqlParameter("@IMP_EXP_ID", objUserBL.A1);
            param[3] = new SqlParameter("@IMP_EXP_BRSLNO", objUserBL.A2);
            param[4] = new SqlParameter("@IMP_EXP_IECNO", objUserBL.A3);
            param[5] = new SqlParameter("@IMP_EXP_NAME", objUserBL.A4);
            param[6] = new SqlParameter("@STANDARD_TYPE", objUserBL.A5);

            param[14] = new SqlParameter("@flag", objUserBL.A20);

            param[16] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[17] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[18] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[19] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[20] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[20].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("CLIENTMASTER_BRANCH_SELECT", param);
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                ds.Tables.Add(new DataTable());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public DataSet Imp_Exp_Master_Insert_update_STD(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[210];
            param[0] = new SqlParameter("@IMP_EXP_ID", objUserBL.A1);  //IMP_EXP_ID
            param[1] = new SqlParameter("@IMP_EXP_NAME", objUserBL.A2);//IMP_EXP_NAME

            param[2] = new SqlParameter("@IMP_EXP_IECNO", objUserBL.A3);//IMP_EXP_IECNO
            param[3] = new SqlParameter("@IMP_EXP_BRSLNO", objUserBL.A4);//IMP_EXP_BRSLNO
            param[4] = new SqlParameter("@IMP_EXP_TYPE", objUserBL.A5);//IMP_EXP_TYPE
            param[5] = new SqlParameter("@IMP_EXP_ADD1", objUserBL.A6);//IMP_EXP_ADD1
            param[6] = new SqlParameter("@IMP_EXP_ADD2", objUserBL.A7);//IMP_EXP_ADD2
            param[7] = new SqlParameter("@IMP_EXP_ADD3", objUserBL.A8);//IMP_EXP_ADD3
            param[8] = new SqlParameter("@IMP_EXP_ADD4", objUserBL.A9);//IMP_EXP_ADD4

            param[9] = new SqlParameter("@IMP_EXP_PIN_CODE", objUserBL.A10);//IMP_EXP_PIN_CODE
            param[10] = new SqlParameter("@IMP_EXP_CONTACT_PERSON", objUserBL.A11);//IMP_EXP_CONTACT_PERSON
            param[11] = new SqlParameter("@IMP_EXP_PHONE", objUserBL.A12);//IMP_EXP_PHONE
            param[12] = new SqlParameter("@IMP_EXP_EMAIL", objUserBL.A13);//IMP_EXP_EMAIL
            param[13] = new SqlParameter("@IMP_EXP_BINNO", objUserBL.A14);//IMP_EXP_BINNO
            param[14] = new SqlParameter("@IMP_EXP_REMARKS", objUserBL.A15);//IMP_EXP_REMARKS
            param[15] = new SqlParameter("@IMP_EXP_DRAWBACK_AC_NO", objUserBL.A16);//IMP_EXP_DRAWBACK_AC_NO

            param[16] = new SqlParameter("@IMP_EXP_PAN_NO", objUserBL.A17);//IMP_EXP_PAN_NO

            param[17] = new SqlParameter("@STANDARD_TYPE", objUserBL.A18);//STANDARD_TYPE
            param[18] = new SqlParameter("@TIN_NO", objUserBL.A19);//TIN_NO
            param[19] = new SqlParameter("@STATE_CODE", objUserBL.A20);//STATE_CODE


            param[20] = new SqlParameter("@IMP_EXP_FAX", objUserBL.A21);//IMP_EXP_FAX

            param[21] = new SqlParameter("@EXP_STR_YN", objUserBL.A22);//EXP_STR_YN
            param[22] = new SqlParameter("@TYPE_OF_EXPORTER", objUserBL.A23);//TYPE_OF_EXPORTER
            param[23] = new SqlParameter("@MARKS_NO", objUserBL.A24);//MARKS_NO

            param[24] = new SqlParameter("@COMMERCIAL_DETAILS_STATUS", objUserBL.A25);//COMMERCIAL_DETAILS_STATUS
            param[25] = new SqlParameter("@COMMERCIAL_TAX_STATENAME", objUserBL.A26);//COMMERCIAL_TAX_STATENAME
            param[26] = new SqlParameter("@COMMERCIAL_TAX_STATECODE", objUserBL.A27);//COMMERCIAL_TAX_STATECODE
            param[27] = new SqlParameter("@COMMERCIAL_TAX_TYPE", objUserBL.A28);//COMMERCIAL_TAX_TYPE
            param[28] = new SqlParameter("@COMMERCIAL_TAX_REGISTRATION_NO", objUserBL.A29);//COMMERCIAL_TAX_REGISTRATION_NO

            param[29] = new SqlParameter("@GSTN_TYPE", objUserBL.A30);//GSTN_TYPE
            param[30] = new SqlParameter("@GSTN_ID", objUserBL.A31);//GSTN_ID          
            param[31] = new SqlParameter("@DISTRICT", objUserBL.A32);//DISTRICT
            param[32] = new SqlParameter("@EXP_DBK_DECL_CHK", objUserBL.A33);//EXP_DBK_DECL_CHK
            param[33] = new SqlParameter("@SEZ_ICEGATE_ID", objUserBL.A34);//SEZ_ICEGATE_ID
            param[34] = new SqlParameter("@SEZ_PAN_NO", objUserBL.A35);//SEZ_PAN_NO
            param[35] = new SqlParameter("@SEZ_AP_ID", objUserBL.A36);//SEZ_AP_ID
            param[36] = new SqlParameter("@SEZ_AP_NAME", objUserBL.A37);//SEZ_AP_NAME
            param[37] = new SqlParameter("@WAREHOUSE_CODE", objUserBL.A38);//WAREHOUSE_CODE
            param[38] = new SqlParameter("@PAYMENT_METHOD_CODE", objUserBL.A39);//PAYMEMT_METHOD
            param[39] = new SqlParameter("@ITEM_END_USE", objUserBL.A40);//PRODUCT_END_USE
            param[40] = new SqlParameter("@CLIENT_INSURANCE_RATE", objUserBL.A41);//INSURANCE_RATE
            param[41] = new SqlParameter("@TAN_NUMBER", objUserBL.A42);//TAN_NUMBER
            param[42] = new SqlParameter("@TDS_CODE", objUserBL.A43);//TDS_CODE
            param[43] = new SqlParameter("@TDS_RATE", objUserBL.A44);//TDS_RATE

            param[44] = new SqlParameter("@NATURE_OF_TRANS", objUserBL.A45); // Added by shanthini on 12-06-2026   NATURE_OF_TRANS
            param[45] = new SqlParameter("@NATURE_OF_PAYMENT", objUserBL.A46);//NATURE_OF_PAYMENT
            param[46] = new SqlParameter("@VALUATION_METHOD", objUserBL.A47); //VALUATION_METHOD


            //Customer param
            param[47] = new SqlParameter("@A_C_CREDITLIMIT", objUserBL.A48);//A_C_CREDITLIMIT
            param[48] = new SqlParameter("@A_C_CUR", objUserBL.A49);//A_C_CUR
            param[49] = new SqlParameter("@A_C_UNLIMITED", A_C_UNLIMITED);
            param[50] = new SqlParameter("@A_C_COD", A_C_COD);
            param[51] = new SqlParameter("@A_C_CHK_OVERDUE", A_C_CHK_OVERDUE);
            param[52] = new SqlParameter("@A_C_OVERDUE_RESTRICTION", objUserBL.A50);
            param[53] = new SqlParameter("@A_C_CHK_CRD_HOLD", CHECK_CREDITONHOLD);
            param[54] = new SqlParameter("@A_C_CREDITONHOLD", objUserBL.A51);
            param[55] = new SqlParameter("@A_C_REC_CRE_PERIOD_DDL", objUserBL.A52);
            param[56] = new SqlParameter("@A_C_REC_CRE_PERIOD_DAYS", objUserBL.A53);
            param[57] = new SqlParameter("@A_C_CUSTOMER_GL", objUserBL.A54);
            param[58] = new SqlParameter("@A_C_NOT_EMAIL", objUserBL.A55);
            param[59] = new SqlParameter("@A_C_CHK_OPT_CRITERIA", Check_OptionalCriteria);
            param[60] = new SqlParameter("@A_C_REC_DDL", objUserBL.A56);
            param[61] = new SqlParameter("@A_C_REC_NO_DAYS", objUserBL.A57);
            param[62] = new SqlParameter("@A_C_REC_TXTBOX", objUserBL.A58);
            param[63] = new SqlParameter("@A_C_CUR2", objUserBL.A59);
            //vendor params
            param[64] = new SqlParameter("@A_V_UNLIMITED", CHK_Vendor_CLimit);
            param[65] = new SqlParameter("@A_V_CREDITLIMIT", objUserBL.A60);
            param[66] = new SqlParameter("@A_V_CUR", objUserBL.A61);
            param[67] = new SqlParameter("@A_V_PAY_CRE_PERIOD_DDL", objUserBL.A62);
            param[68] = new SqlParameter("@A_V_PAY_CRE_PERIOD_TXT", objUserBL.A63);
            param[69] = new SqlParameter("@A_V_DUEDATE_CAL", objUserBL.A64);
            param[70] = new SqlParameter("@A_V_CUR2", objUserBL.A65);
            param[71] = new SqlParameter("@A_V_VENDORGL", objUserBL.A66);
            param[72] = new SqlParameter("@A_V_NOTIFIC_MAIL", objUserBL.A67);
            param[73] = new SqlParameter("@A_V_PAYMENT_CHK", CHK_PaymentHold);
            param[74] = new SqlParameter("@A_V_PAYMENTON_HOLD", objUserBL.A68);
            //------------------------------------------------------------------------------------------------------------
            //TDS CONTROLS
            param[75] = new SqlParameter("@A_T_FISCALYEAR", objUserBL.A69);
            param[76] = new SqlParameter("@A_T_ORG_TYPE", objUserBL.A70);
            param[77] = new SqlParameter("@A_T_SPC_PERSON", CHK_SpecifiedPerson);
            param[78] = new SqlParameter("@A_T_TDS_RECEIVABLE", objUserBL.A71);
            param[79] = new SqlParameter("@A_C_Code", objUserBL.A72);
            param[80] = new SqlParameter("@A_V_Code", objUserBL.A73);
            param[192] = new SqlParameter("@Mflag", objUserBL.A200);//flag
            param[193] = new SqlParameter("@IMP_EXP_YEAR", objUserBL.A201);//YEAR
            param[194] = new SqlParameter("@IMP_EXP_USER_ID", Connection.Current_User());
            param[195] = new SqlParameter("@IMP_EXP_BRANCH_CODE", Connection.Current_Branch());
            //  param[196] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[196] = new SqlParameter("@IMP_EXP_WORKING_PERIOD", Connection.WorkingPeriod());
            //param[198] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[197] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[197].Direction = ParameterDirection.Output;

            param[198] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[198].Direction = ParameterDirection.Output;
            param[199] = new SqlParameter("@GST_PAYMENT_METHOD", objUserBL.A202);//YEAR
            ds = Connection.Get_Dataset("SP_IMP_EXP_MASTER_INSERT_UPDATE_STD", param);
            objUserBL.A197 = param[197].Value.ToString();

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;

    }

    public DataSet PAYABLE_DETAILS_INSERT_UPADATE(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];
            param[0] = new SqlParameter("@ACC_ORG_NAME", objUserBL.A1);
            param[1] = new SqlParameter("@ACC_BANKNAME", objUserBL.A2);
            param[2] = new SqlParameter("@ACC_BRANCH", objUserBL.A3);
            param[3] = new SqlParameter("@ACC_AC_NO", objUserBL.A4);
            param[4] = new SqlParameter("@ACC_IFSC_CODE", objUserBL.A5);
            param[5] = new SqlParameter("@ACC_ADDRESS1", objUserBL.A6);
            param[6] = new SqlParameter("@ACC_ADDRESS2", objUserBL.A7);
            param[7] = new SqlParameter("@ACC_DISTRICT", objUserBL.A8);
            param[8] = new SqlParameter("@ACC_STATE", objUserBL.A9);
            param[9] = new SqlParameter("@ACC_PINCODE", objUserBL.A10);
            param[10] = new SqlParameter("@ACC_IECNO", objUserBL.A11);
            param[11] = new SqlParameter("@ACC_BRSLNO", objUserBL.A12);
            param[12] = new SqlParameter("@Payable_ID", PayableId);
            param[13] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[14] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[15] = new SqlParameter("@CREATEDON", DateTime.Now);
            param[16] = new SqlParameter("@CREATEDBY", Connection.Current_User());
            param[17] = new SqlParameter("@MODIFIEDBY", Connection.Current_User());
            param[18] = new SqlParameter("@MODIFIEDON", DateTime.Now);
            param[19] = new SqlParameter("@Flag", objUserBL.A30);
            param[20] = new SqlParameter("@Status", SqlDbType.Int);
            param[20].Direction = ParameterDirection.Output;
            param[21] = new SqlParameter("@_PAYABLE_ID", SqlDbType.Int);
            param[21].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_BANK_PAYABLE_DETAILS_INSERT_UPDATE", param);
            objUserBL.A13 = param[20].Value.ToString();
            objUserBL.A14 = param[21].Value.ToString();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Receivable_Insert_Update(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];
            param[0] = new SqlParameter("@ACC_REC_ORG_NAME", objUserBL.A1);
            param[1] = new SqlParameter("@ACC_REC_BANKNAME", objUserBL.A2);
            param[2] = new SqlParameter("@ACC_REC_BRANCH", objUserBL.A3);
            param[3] = new SqlParameter("@ACC_REC_AC_NO", objUserBL.A4);
            param[4] = new SqlParameter("@ACC_REC_IFSC_CODE", objUserBL.A5);
            param[5] = new SqlParameter("@ACC_REC_ADDRESS1", objUserBL.A6);
            param[6] = new SqlParameter("@ACC_REC_ADDRESS2", objUserBL.A7);
            param[7] = new SqlParameter("@ACC_REC_DISTRICT", objUserBL.A8);
            param[8] = new SqlParameter("@ACC_REC_STATE", objUserBL.A9);
            param[9] = new SqlParameter("@ACC_REC_PINCODE", objUserBL.A10);
            param[10] = new SqlParameter("@ACC_REC_IECNO", objUserBL.A11);
            param[11] = new SqlParameter("@ACC_REC_BRSLNO", objUserBL.A12);
            param[12] = new SqlParameter("@RECEIVABLEID", ReceivableId);
            param[13] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[14] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[15] = new SqlParameter("@CREATEDON", DateTime.Now);
            param[16] = new SqlParameter("@CREATEDBY", Connection.Current_User());
            param[17] = new SqlParameter("@MODIFIEDBY", Connection.Current_User());
            param[18] = new SqlParameter("@MODIFIEDON", DateTime.Now);
            param[19] = new SqlParameter("@Flag", objUserBL.A30);
            param[20] = new SqlParameter("@Status", SqlDbType.Int);
            param[20].Direction = ParameterDirection.Output;
            param[21] = new SqlParameter("@_RECEIVABLE_ID", SqlDbType.Int);
            param[21].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_BANK_RECEIVABLE_DETAILS_INSERT_UPDATE", param);
            objUserBL.A13 = param[20].Value.ToString();
            objUserBL.A14 = param[21].Value.ToString();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Client_DefaultSettings_Insert_Update()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@DEFAULT_ID", DEFAULT_ID);
            param[1] = new SqlParameter("@STANDARD_TYPE", STANDARD_TYPE);
            param[2] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[3] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[4] = new SqlParameter("@YEAR", YEAR);
            param[5] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[6] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[7] = new SqlParameter("@Mflag", flag);

            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("CLIENT_DEFAULT_SETTINGS_INSERT_UPDATE", param);
            result = Convert.ToInt32(param[8].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }

    public DataSet CheckIECNO_BrSlno_Name(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@IMP_EXP_ID", objUserBL.A100);
            param[1] = new SqlParameter("@IMP_EXP_NAME", objUserBL.A101);
            param[2] = new SqlParameter("@IMP_EXP_IECNO", objUserBL.A102);
            param[3] = new SqlParameter("@IMP_EXP_BRSLNO", objUserBL.A103);
            param[4] = new SqlParameter("@STANDARD_TYPE", objUserBL.A104);
            param[5] = new SqlParameter("@Status", SqlDbType.Int);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@BlockReason", SqlDbType.NVarChar,200);
            param[6].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("CHECK_IECNO_CLIENTNAME_BRSLNO", param);
            objUserBL.A105 = (param[5].Value != null && param[5].Value != DBNull.Value)
                           ? param[5].Value.ToString()
                           : "0";

            objUserBL.A106 = (param[6].Value != null && param[6].Value != DBNull.Value)
                                ? param[6].Value.ToString()
                                : string.Empty;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
            objUserBL.A105 = "-1";
            objUserBL.A106 = ex.Message;
        }
        return ds;
    }
}