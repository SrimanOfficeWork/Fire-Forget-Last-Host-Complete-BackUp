using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;

public class Elogix_Masters
{
    
    public DataSet Company_Details(string COMPANY_LICENSE, string WORKING_PERIOD)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@COMPANY_LICENSE", COMPANY_LICENSE);
            param[2] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[3] = new SqlParameter("@name", "Company_details");

            param[4] = new SqlParameter("@Tr_mode", "");
            param[5] = new SqlParameter("@Customs_House", "");
            param[6] = new SqlParameter("@Port_Destination", "");
            param[7] = new SqlParameter("@Port_Of_Discharge", "");

            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;


            ds = SqlHelper.ExecuteDataset(Connection.Get_DSC_Con_String(COMPANY_LICENSE), CommandType.StoredProcedure, "E_LOGIX_ADMIN_DETAILS", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Company_Details(string COMPANY_LICENSE, string WORKING_PERIOD, string Tr_mode, string Customs_House, string Port_Destination, string Port_Of_Discharge, string Flag)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@COMPANY_LICENSE", COMPANY_LICENSE);
            param[2] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[3] = new SqlParameter("@Tr_mode", Tr_mode);
            param[4] = new SqlParameter("@Customs_House", Customs_House);
            param[5] = new SqlParameter("@Port_Destination", Port_Destination);
            param[6] = new SqlParameter("@Port_Of_Discharge", Port_Of_Discharge);
            param[7] = new SqlParameter("@name", Flag);

            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(Connection.Get_DSC_Con_String(COMPANY_LICENSE), CommandType.StoredProcedure, "E_LOGIX_ADMIN_DETAILS", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public void BUYER_MASTER(string BUYER_NAME, string BUYER_ADD1, string BUYER_ADD2, string BUYER_ADD3, string BUYER_COUNTRY_NAME, string BUYER_COUNTRY_CODE, string WORKING_PERIOD,string Flag, string User_ID,string Login)
    {
            try
            {
                    SqlParameter[] param = new SqlParameter[15];

                    param[1] = new SqlParameter("@BUYER_NAME", BUYER_NAME);
                    param[2] = new SqlParameter("@BUYER_ADD1", BUYER_ADD1);
                    param[3] = new SqlParameter("@BUYER_ADD2", BUYER_ADD2);
                    param[4] = new SqlParameter("@BUYER_ADD3", BUYER_ADD3);
                    param[5] = new SqlParameter("@BUYER_COUNTRY_NAME", BUYER_COUNTRY_NAME);
                    param[6] = new SqlParameter("@BUYER_COUNTRY_CODE", BUYER_COUNTRY_CODE);
                    param[7] = new SqlParameter("@User_ID", User_ID);
                    param[8] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
                    param[9] = new SqlParameter("@Mflag", Flag);

                    param[13] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
                    param[13].Direction = ParameterDirection.Output;
                    param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
                    param[14].Direction = ParameterDirection.Output;

                    SqlHelper.ExecuteDataset(Login, CommandType.StoredProcedure, "E_LOGIX_BUYER_MASTER_INSERT_UPDATE", param);
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
    }
    public void CONSIGNEE_MASTER(string CONSIGNEE_NAME,string CONSIGNEE_ADD1,string CONSIGNEE_ADD2,string CONSIGNEE_ADD3,string CONSIGNEE_COUNTRY_NAME,string CONSIGNEE_COUNTRY_CODE, string WORKING_PERIOD, string Flag, string User_ID, string Login)
    {
            try
            {
                    SqlParameter[] param = new SqlParameter[15];

                    param[1] = new SqlParameter("@CONSIGNEE_NAME", CONSIGNEE_NAME);
                    param[2] = new SqlParameter("@CONSIGNEE_ADD1", CONSIGNEE_ADD1);
                    param[3] = new SqlParameter("@CONSIGNEE_ADD2", CONSIGNEE_ADD2);
                    param[4] = new SqlParameter("@CONSIGNEE_ADD3", CONSIGNEE_ADD3);
                    param[5] = new SqlParameter("@CONSIGNEE_COUNTRY_NAME", CONSIGNEE_COUNTRY_NAME);
                    param[6] = new SqlParameter("@CONSIGNEE_COUNTRY_CODE", CONSIGNEE_COUNTRY_CODE);

                    param[7] = new SqlParameter("@User_ID", User_ID); 
                    param[8] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
                    param[9] = new SqlParameter("@Mflag", Flag);

                    param[13] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
                    param[13].Direction = ParameterDirection.Output;
                    param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
                    param[14].Direction = ParameterDirection.Output;

                    SqlHelper.ExecuteDataset(Login, CommandType.StoredProcedure, "E_LOGIX_CONSIGNEE_MASTER_INSERT_UPDATE", param);
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
    }
    public void SUP_MASTER(string SUP_NAME, string SUP_ADD1, string SUP_ADD2,string SUP_ADD3,string SUP_COUNTRY_NAME, string SUP_COUNTRY_CODE, string WORKING_PERIOD, string Flag, string User_ID, string Login)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[1] = new SqlParameter("@SUP_NAME", SUP_NAME);
            param[2] = new SqlParameter("@SUP_ADD1", SUP_ADD1);
            param[3] = new SqlParameter("@SUP_ADD2", SUP_ADD2);
            param[4] = new SqlParameter("@SUP_ADD3", SUP_ADD3);
            param[5] = new SqlParameter("@SUP_COUNTRY_NAME", SUP_COUNTRY_NAME);
            param[6] = new SqlParameter("@SUP_COUNTRY_CODE", SUP_COUNTRY_CODE);

            param[7] = new SqlParameter("@User_ID", User_ID);
            param[8] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[9] = new SqlParameter("@Mflag", Flag);

            param[13] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(Login, CommandType.StoredProcedure, "E_LOGIX_SUPPLIER_MASTER_INSERT_UPDATE", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public void SHIPPER_MASTER(string IMP_EXP_NAME, string IMP_EXP_IECNO, string IMP_EXP_BRSLNO, string IMP_EXP_TYPE
        , string IMP_EXP_ADD1 , string IMP_EXP_ADD2, string IMP_EXP_ADD3, string IMP_EXP_ADD4, string IMP_EXP_PIN_CODE
        , string STATE_CODE, string TYPE_OF_EXPORTER, string M_COMMERCIAL_DETAILS_STATUS, string M_COMMERCIAL_TAX_STATENAME, string M_COMMERCIAL_TAX_STATECODE, string M_COMMERCIAL_TAX_TYPE, string M_COMMERCIAL_TAX_REGISTRATION_NO, string GSTN_TYPE, string GSTN_ID, string COMPANY_LICENSE, string WORKING_PERIOD, string Flag, string User_ID, string Login)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[35];

            param[1] = new SqlParameter("@IMP_EXP_NAME", IMP_EXP_NAME);
            param[2] = new SqlParameter("@IMP_EXP_IECNO", IMP_EXP_IECNO);
            param[3] = new SqlParameter("@IMP_EXP_BRSLNO", IMP_EXP_BRSLNO);
            param[4] = new SqlParameter("@IMP_EXP_TYPE", IMP_EXP_TYPE);

            param[5] = new SqlParameter("@IMP_EXP_ADD1", IMP_EXP_ADD1);
            param[6] = new SqlParameter("@IMP_EXP_ADD2", IMP_EXP_ADD2);
            param[7] = new SqlParameter("@IMP_EXP_ADD3", IMP_EXP_ADD3);
            param[8] = new SqlParameter("@IMP_EXP_ADD4", IMP_EXP_ADD4);
            param[9] = new SqlParameter("@IMP_EXP_PIN_CODE", IMP_EXP_PIN_CODE);

            param[10] = new SqlParameter("@STATE_CODE", STATE_CODE);
            param[11] = new SqlParameter("@TYPE_OF_EXPORTER", TYPE_OF_EXPORTER);

            param[12] = new SqlParameter("@M_COMMERCIAL_DETAILS_STATUS", M_COMMERCIAL_DETAILS_STATUS);
            param[13] = new SqlParameter("@M_COMMERCIAL_TAX_STATENAME", M_COMMERCIAL_TAX_STATENAME);
            param[14] = new SqlParameter("@M_COMMERCIAL_TAX_STATECODE", M_COMMERCIAL_TAX_STATECODE);
            param[15] = new SqlParameter("@M_COMMERCIAL_TAX_TYPE", M_COMMERCIAL_TAX_TYPE);

            param[20] = new SqlParameter("@M_COMMERCIAL_TAX_REGISTRATION_NO", M_COMMERCIAL_TAX_REGISTRATION_NO);
            param[21] = new SqlParameter("@GSTN_TYPE", GSTN_TYPE);
            param[22] = new SqlParameter("@GSTN_ID", GSTN_ID);

            param[26] = new SqlParameter("@User_ID", User_ID);
            param[27] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[28] = new SqlParameter("@Mflag", Flag);

            param[30] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[30].Direction = ParameterDirection.Output;
            param[31] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[31].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(Login, CommandType.StoredProcedure, "E_LOGIX_IMP_EXP_MASTER_INSERT_UPDATE", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public void ADCODE_MASTER(string ADCODE_IEC_CODE, string ADCODE_IEC_NAME, string ADCODE_IEC_ADCODE, string COMPANY_LICENSE, string WORKING_PERIOD, string Flag, string User_ID, string Login)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@ADCODE_IEC_CODE", ADCODE_IEC_CODE);
            param[2] = new SqlParameter("@ADCODE_IEC_NAME", ADCODE_IEC_NAME);
            param[3] = new SqlParameter("@ADCODE_IEC_ADCODE", ADCODE_IEC_ADCODE);

            param[7] = new SqlParameter("@User_ID", User_ID);
            param[8] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[9] = new SqlParameter("@Mflag", Flag);

            param[13] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(Login, CommandType.StoredProcedure, "E_LOGIX_ADCODE_MASTER_INSERT_UPDATE", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public void IMP_EXP_File_Ref_Update(string Jobno, string File_Ref_No, string Branch_Code, string IMP_EXP_Type, string WORKING_PERIOD, string User_ID, string Login, string Branch_Common)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Jobno", Jobno);
            param[2] = new SqlParameter("@File_Ref_No", File_Ref_No);
            param[3] = new SqlParameter("@Branch_Code", Branch_Code);
            param[4] = new SqlParameter("@Branch_Common", Branch_Common);
            param[5] = new SqlParameter("@User_ID", User_ID);
            param[7] = new SqlParameter("@Mflag", IMP_EXP_Type);

            param[13] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(Login, CommandType.StoredProcedure, "E_LOGIX_IMP_EXP_JOB_FILE_REF_NO_UPDATE", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public void EXP_DML_CMD(
                 string File_Ref_No 
                ,string Tr_mode
                ,string Jobdate
                ,string IEC_NO
                ,string Branch_No
                ,string Consignee_Name
                ,string Customs_House
                ,string Port_Destination 
                ,string Port_Of_Discharge
                ,string Gross_Wgt
                ,string Net_Wgt
                ,string Pkg
                ,string Uint_Code
                ,string Inv_No
                ,string Inv_Date
                ,string Inv_Cur
                ,string Terms
                ,string Inv_Value
                
                ,string Branch_Code
                ,string User_Id
                ,string Flag
                ,string Login
                ,string Branch_Common
                ,string WORKINGPERIOD
        )
    {
        try
        {
            SqlParameter[] param = new SqlParameter[35];
            param[1] = new SqlParameter("@File_Ref_No", File_Ref_No);
            param[2] = new SqlParameter("@Tr_mode", Tr_mode);

            param[3] = new SqlParameter("@Jobdate", Jobdate);
            param[4] = new SqlParameter("@IEC_NO", IEC_NO);
            param[5] = new SqlParameter("@Branch_No", Branch_No);
            param[6] = new SqlParameter("@Consignee_Name", Consignee_Name);
            param[7] = new SqlParameter("@Customs_House", Customs_House);
            param[8] = new SqlParameter("@Port_Destination", Port_Destination);
            param[9] = new SqlParameter("@Port_Of_Discharge", Port_Of_Discharge);

            param[10] = new SqlParameter("@Gross_Wgt", Gross_Wgt);
            param[11] = new SqlParameter("@Net_Wgt", Net_Wgt);
            param[12] = new SqlParameter("@Pkg", Pkg);
            param[13] = new SqlParameter("@Uint_Code", Uint_Code);

            param[14] = new SqlParameter("@Inv_No", Inv_No);
            param[15] = new SqlParameter("@Inv_Date", Inv_Date);

            param[16] = new SqlParameter("@Inv_Cur", Inv_Cur);
            param[17] = new SqlParameter("@Terms", Terms);
            param[18] = new SqlParameter("@Inv_Value", Inv_Value);
            param[19] = new SqlParameter("@Branch_Code", Branch_Code);
            param[20] = new SqlParameter("@User_Id", User_Id);

            param[21] = new SqlParameter("@Mflag", Flag);
            param[22] = new SqlParameter("@Branch_Common", Branch_Common);
            param[23] = new SqlParameter("@WORKINGPERIOD", WORKINGPERIOD);
            

            param[33] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[33].Direction = ParameterDirection.Output;
            param[34] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[34].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(Login, CommandType.StoredProcedure, "E_LOGIX_EXP_DML_CMD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public void IMP_DML_CMD(string File_Ref_No
                , string JOBDATE, string TRANSPORT_MODE, string BRANCH_NO, string IEC_NO, string CUSTOMS_HOUSE
                , string IGM_NO, string IGM_DATE, string IGM_MAWB_MBL, string IGM_MAWB_MBLDATE, string IGM_HAWB_HBLNO, string IGM_HAWB_HBLDATE
                , string IGM_NOOFPACKAGE, string IGM_PACKAGETYPE, string IGM_GROSSWEIGHT, string IGM_TYPEOFWEIGHT, string IGM_FLIGHT_VESSELDATE
                , string INVOICE_NO, string INVOICE_DATE, string INVOICE_CURRENCY, string INVOICE_VALUE

                , string Branch_Code
                , string User_Id
                , string Flag
                , string Login
                , string Branch_Common
                , string WORKINGPERIOD
        )
    {
        try
        {
            SqlParameter[] param = new SqlParameter[60];
            param[1] = new SqlParameter("@File_Ref_No", File_Ref_No);
            param[2] = new SqlParameter("@JOBDATE", JOBDATE);

            param[3] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
            param[4] = new SqlParameter("@BRANCH_NO", BRANCH_NO);
            param[5] = new SqlParameter("@IEC_NO", IEC_NO);

            param[6] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);
            param[7] = new SqlParameter("@IGM_NO", IGM_NO);
            param[8] = new SqlParameter("@IGM_DATE", IGM_DATE);
            param[9] = new SqlParameter("@IGM_MAWB_MBL", IGM_MAWB_MBL);

            param[10] = new SqlParameter("@IGM_MAWB_MBLDATE", IGM_MAWB_MBLDATE);
            param[11] = new SqlParameter("@IGM_HAWB_HBLNO", IGM_HAWB_HBLNO);
            param[12] = new SqlParameter("@IGM_HAWB_HBLDATE", IGM_HAWB_HBLDATE);
            param[13] = new SqlParameter("@IGM_NOOFPACKAGE", IGM_NOOFPACKAGE);

            param[14] = new SqlParameter("@IGM_PACKAGETYPE", IGM_PACKAGETYPE);
            param[15] = new SqlParameter("@IGM_GROSSWEIGHT", IGM_GROSSWEIGHT);

            param[16] = new SqlParameter("@IGM_TYPEOFWEIGHT", IGM_TYPEOFWEIGHT);
            param[17] = new SqlParameter("@IGM_FLIGHT_VESSELDATE", IGM_FLIGHT_VESSELDATE);
            param[18] = new SqlParameter("@INVOICE_NO", INVOICE_NO);
            param[19] = new SqlParameter("@INVOICE_DATE", INVOICE_DATE);
            param[20] = new SqlParameter("@INVOICE_CURRENCY", INVOICE_CURRENCY);
            param[21] = new SqlParameter("@INVOICE_VALUE", INVOICE_VALUE);

            param[44] = new SqlParameter("@Branch_Code", Branch_Code);
            param[45] = new SqlParameter("@User_Id", User_Id);
            param[46] = new SqlParameter("@Mflag", Flag);
            param[47] = new SqlParameter("@Branch_Common", Branch_Common);
            param[48] = new SqlParameter("@WORKINGPERIOD", WORKINGPERIOD);

            param[57] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[57].Direction = ParameterDirection.Output;
            param[58] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[58].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(Login, CommandType.StoredProcedure, "E_LOGIX_IMP_DML_CMD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    public DataSet DSC(string Flag,string User_ID, string Password, string Login, string Branch_Common
        , string From_Date
        , string To_Date
        , string Type
        )
    {
        DataSet dss = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[1] = new SqlParameter("@User_ID", User_ID);
            param[2] = new SqlParameter("@Branch_Common", Branch_Common);
            param[3] = new SqlParameter("@Password", Password);

            param[4] = new SqlParameter("@From_Date", From_Date);
            param[5] = new SqlParameter("@To_Date", To_Date);
            param[6] = new SqlParameter("@Type", Type);

            param[7] = new SqlParameter("@Mflag", Flag);
        
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;

            dss = SqlHelper.ExecuteDataset(Login, CommandType.StoredProcedure, "DSC_LOGIN_CHECK", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return dss;
    }
}