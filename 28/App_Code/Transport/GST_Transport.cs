using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text;


public class GST_Transport
{
	public GST_Transport()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;



    //public DataSet Select_IMP_INV(Transport_BO TOM)   //TOM  Means Transport Object Methods
    //{
    //    return ds;
    //}


    ////HIDE START
    //public void Imp_Billing_Invoice_INS_UPD(Billing_UserBO objUserBL)// THIS IS FOR SAMPLE
    //{
    //    try
    //    {
    //        SqlParameter[] param = new SqlParameter[140];
    //        param[0] = new SqlParameter("@ID", objUserBL.ID);
    //        param[1] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
    //        param[2] = new SqlParameter("@IMPORTER_NAME", objUserBL.IMPORTER_NAME);
    //        param[3] = new SqlParameter("@MODE", objUserBL.MODE);
    //        param[4] = new SqlParameter("@BILL_INV_NO", objUserBL.BILL_INV_NO);

    //        if (objUserBL.BILL_INV_DATE == null)
    //        {
    //            objUserBL.BILL_INV_DATE = string.Empty;
    //        }

    //        param[10] = new SqlParameter("@BILL_INV_DATE", Connection.DATE_FORMAT(objUserBL.BILL_INV_DATE == string.Empty ? "01/01/1900" : objUserBL.BILL_INV_DATE));
    //        param[11] = new SqlParameter("@INV_NO", objUserBL.INV_NO);
    //        if (objUserBL.INV_DATE == null)
    //        {
    //            objUserBL.INV_DATE = string.Empty;
    //        }
    //        param[12] = new SqlParameter("@INV_DATE", Connection.DATE_FORMAT(objUserBL.INV_DATE == string.Empty ? "01/01/1900" : objUserBL.INV_DATE));
    //        param[13] = new SqlParameter("@BE_NO", objUserBL.BE_NO);
    //        if (objUserBL.BE_DATE == null)
    //        {
    //            objUserBL.BE_DATE = string.Empty;
    //        }
    //        param[14] = new SqlParameter("@BE_DATE", Connection.DATE_FORMAT(objUserBL.BE_DATE == string.Empty ? "01/01/1900" : objUserBL.BE_DATE));
    //        param[15] = new SqlParameter("@MBL_NO", objUserBL.MBLNO);
    //        param[16] = new SqlParameter("@HBL_NO", objUserBL.HBLNO);
    //        param[17] = new SqlParameter("@CONTAINER_NO", objUserBL.CONTAINER_NO);
    //        param[18] = new SqlParameter("@NO_OF_PKG", objUserBL.NO_OF_PKG);
    //        param[19] = new SqlParameter("@GROSS_WGT", objUserBL.GROSS_WGT);
    //        param[20] = new SqlParameter("@NET_WGT", objUserBL.NET_WGT);
    //        param[21] = new SqlParameter("@PARTY_REF", objUserBL.Party_Ref);
    //        param[22] = new SqlParameter("@DUTY_VALUE", objUserBL.Duty_Value);
    //        param[23] = new SqlParameter("@VOLUME", objUserBL.VOLUME);
    //        param[24] = new SqlParameter("@VESSEL", objUserBL.VESSEL);
    //        param[25] = new SqlParameter("@DESTINATION", objUserBL.DESTINATION);
    //        param[26] = new SqlParameter("@COMMODITY", objUserBL.COMMODITY);
    //        param[27] = new SqlParameter("@FREIGHT_STATUS", objUserBL.FREIGHT_STATUS);
    //        param[28] = new SqlParameter("@AC_BEHALF", objUserBL.AC_BEHALF);
    //        param[29] = new SqlParameter("@SHIPPER_NAME", objUserBL.SHIPPER_NAME);
    //        param[30] = new SqlParameter("@SHIPPER_ADDRESS", objUserBL.SHIPPER_ADDRESS);
    //        param[31] = new SqlParameter("@CONSIGNEE_NAME", objUserBL.CONSIGNEE_NAME);
    //        param[32] = new SqlParameter("@CONSIGNEE_ADDRESS", objUserBL.CONSIGNEE_ADDRESS);
    //        param[33] = new SqlParameter("@NOTIFY_PARTY_1", objUserBL.NOTIFY_PARTY_1);
    //        param[34] = new SqlParameter("@NOTIFY_PARTY_1_ADDRESS", objUserBL.NOTIFY_PARTY_1_ADDRESS);
    //        param[35] = new SqlParameter("@NOTIFY_PARTY_2", objUserBL.NOTIFY_PARTY_2);
    //        param[36] = new SqlParameter("@NOTIFY_PARTY_2_ADDRESS", objUserBL.NOTIFY_PARTY_2_ADDRESS);
    //        param[37] = new SqlParameter("@REMARKS", objUserBL.REMARKS);
    //        param[38] = new SqlParameter("@NON_TAXABLE_AMT", objUserBL.NON_TAXABLE_AMT);
    //        param[39] = new SqlParameter("@TAXABLE_AMT", objUserBL.TAXABLE_AMT);
    //        param[44] = new SqlParameter("@TOTAL_TAX_AMT", objUserBL.TOTAL_TAX_AMT);
    //        param[45] = new SqlParameter("@TOTAL_AMT_TAX", objUserBL.TOTAL_AMT_TAX);
    //        param[46] = new SqlParameter("@CIF_VALUE", objUserBL.CIF_VALUE);
    //        param[47] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
    //        param[48] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
    //        param[49] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
    //        param[50] = new SqlParameter("@ADVANCE_AMT", objUserBL.ADVANCE_AMT);
    //        param[51] = new SqlParameter("@STATE_NAME", objUserBL.State_Name);
    //        param[52] = new SqlParameter("@GSTN_ID", objUserBL.GSTN_ID);
    //        param[55] = new SqlParameter("@FILE_REF_NO", objUserBL.FILE_REF_NO);
    //        param[57] = new SqlParameter("@CHARGE_WGT", objUserBL.CHARGE_WGT);
    //        param[58] = new SqlParameter("@CHARGE_TYPE", objUserBL.CHARGE_TYPE);

    //        if (objUserBL.JOBDATE == null)
    //        {
    //            objUserBL.JOBDATE = string.Empty;
    //        }
    //        param[59] = new SqlParameter("@JOB_DATE", Connection.DATE_FORMAT(objUserBL.JOBDATE == string.Empty ? "01/01/1900" : objUserBL.JOBDATE));

    //        param[60] = new SqlParameter("@ASS_VALUE", objUserBL.Ass_Value);
    //        param[61] = new SqlParameter("@USERID", Connection.Current_User());
    //        param[62] = new SqlParameter("@BILL_TYPE", objUserBL.BILL_TYPE);
    //        param[63] = new SqlParameter("@HBL_NO_DATE", Connection.DATE_FORMAT(objUserBL.HBL_NO_DATE == string.Empty ? "01/01/1900" : objUserBL.HBL_NO_DATE));
    //        param[64] = new SqlParameter("@MBL_NO_DATE", Connection.DATE_FORMAT(objUserBL.MBL_NO_DATE == string.Empty ? "01/01/1900" : objUserBL.MBL_NO_DATE));
    //        param[65] = new SqlParameter("@FLIGHT_ARAIVAL_DATE", Connection.DATE_FORMAT(objUserBL.FLIGHT_ARAIVAL_DATE == string.Empty ? "01/01/1900" : objUserBL.FLIGHT_ARAIVAL_DATE));
    //        param[66] = new SqlParameter("@CONTAINER_SIZE", objUserBL.CONTAINER_SIZE);
    //        param[67] = new SqlParameter("@BOND_NO", objUserBL.BOND_NO);
    //        param[68] = new SqlParameter("@BOND_DATE", Connection.DATE_FORMAT(objUserBL.BOND_DATE == string.Empty ? "01/01/1900" : objUserBL.BOND_DATE));
    //        param[69] = new SqlParameter("@TOT_REVERSE_TAX_AMT", objUserBL.TOT_REVERSE_TAX_AMT);
    //        param[70] = new SqlParameter("@FROM_QUOTATION", objUserBL.FROM_QUOTATION);

    //        param[71] = new SqlParameter("@TYPE_OF_INVOICE", objUserBL.TYPE_OF_INVOICE);
    //        param[72] = new SqlParameter("@YOUR_REF", objUserBL.YOUR_REF);
    //        param[73] = new SqlParameter("@NO_OF_PKG_TYPE", objUserBL.NO_OF_PKG_TYPE);
    //        param[74] = new SqlParameter("@GROSS_WGT_TYPE", objUserBL.GROSS_WGT_TYPE);
    //        param[75] = new SqlParameter("@NET_WGT_TYPE", objUserBL.NET_WGT_TYPE);
    //        param[76] = new SqlParameter("@ITEM_DESC", objUserBL.ITEM_DESC);
    //        param[77] = new SqlParameter("@SHIPMENT_TYPE", objUserBL.SHIPMENT_TYPE);

    //        param[78] = new SqlParameter("@BRANCH_NO", objUserBL.Branch_No);
    //        param[79] = new SqlParameter("@BRANCH_NO_LOC", objUserBL.Branch_No_Loc);

    //        param[80] = new SqlParameter("@flag", objUserBL.Flag);
    //        param[81] = new SqlParameter("@xmlString", objUserBL.Xml_D);
    //        param[82] = new SqlParameter("@VENDOR_CODE", objUserBL.VENDOR_CODE);
    //        param[83] = new SqlParameter("@EXPENSE_AMT", objUserBL.EXPENSE_AMT);
    //        param[84] = new SqlParameter("@JOB_STATUS", objUserBL.JOB_STATUS);
    //        param[85] = new SqlParameter("@UNAPPROVAL_APPROVED", objUserBL.UNAPPROVAL_APPROVED);

    //        param[86] = new SqlParameter("@COUNTRY_SHIPMENT", objUserBL.COUNTRY_SHIPMENT);
    //        param[87] = new SqlParameter("@PORT_SHIPMENT", objUserBL.PORT_SHIPMENT);
    //        param[88] = new SqlParameter("@TR_DETAILS", objUserBL.TR_DETAILS);
    //        param[89] = new SqlParameter("@TAX_NONTAX", objUserBL.TAX_NONTAX);

    //        param[90] = new SqlParameter("@CFS_CHARGE", objUserBL.CFS_CHARGE);
    //        param[91] = new SqlParameter("@ATTACHMENT_DET", objUserBL.ATTACHMENT_DET);
    //        param[92] = new SqlParameter("@PO_NO", objUserBL.PO_NO);

    //        param[93] = new SqlParameter("@LCL_FCL", objUserBL.LCL_FCL);
    //        param[94] = new SqlParameter("@TWENTY_FEET_CNT", objUserBL.TWENTY_FEET_CNT);
    //        param[95] = new SqlParameter("@FORTY_FEET_CNT", objUserBL.FORTY_FEET_CNT);
    //        param[96] = new SqlParameter("@INV_TYPE", objUserBL.INV_TYPE);
    //        param[97] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.JOB_WORKINGPERIOD);
    //        param[98] = new SqlParameter("@TERMS", objUserBL.TERMS);

    //        param[116] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
    //        param[116].Direction = ParameterDirection.Output;

    //        param[117] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
    //        param[117].Direction = ParameterDirection.Output;

    //        param[118] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
    //        param[118].Direction = ParameterDirection.Output;

    //        Connection.Get_Dataset("GST_BILL_IMP_JOB_INVOICE_INS_UPD", param);
    //        result = Convert.ToInt32(param[116].Value.ToString());

    //        if (objUserBL.Flag == "S")
    //        {
    //            UPDATE_ID = Convert.ToInt32(param[118].Value.ToString());
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Connection.Error_Msg(ex.Message);
    //    }
    //}
    ////HIDE END
    public void Transport_Billing_INS_UPD(Transport_BO TBOV)
    {
        
        try
        {
            SqlParameter[] param = new SqlParameter[140];
            param[0] = new SqlParameter("@ID", TBOV.ID);            
            param[1] = new SqlParameter("@BILL_INV_NO", TBOV.BILL_INV_NO);
            param[2] = new SqlParameter("@BILL_INV_DATE", TBOV.BILL_INV_DATE);
            
            if (TBOV.BILL_INV_DATE == null)
            {
                TBOV.BILL_INV_DATE = string.Empty;
            }
            
            param[2] = new SqlParameter("@BILL_INV_DATE", Connection.DATE_FORMAT(TBOV.BILL_INV_DATE == string.Empty ? "01/01/1900" : TBOV.BILL_INV_DATE));
            param[3] = new SqlParameter("@flag", TBOV.Flag);
            param[4] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@xmlString", TBOV.Xml_D);

            param[6] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;

            //Additional Fields are added Start
            param[9]  = new SqlParameter("@DESTINATION_FROM", TBOV.DESTINATION_FROM);
            param[10] = new SqlParameter("@BILLFROM_NAME", TBOV.BILLFROM_NAME);
            param[11] = new SqlParameter("@BILLFROM_ADDRESS", TBOV.BILLFROM_ADDRESS);
            param[12] = new SqlParameter("@BILLTO_NAME", TBOV.BILLTO_NAME);
            param[13] = new SqlParameter("@BILLTO_ADDRESS", TBOV.BILLTO_ADDRESS);
            param[14] = new SqlParameter("@REMARKS", TBOV.REMARKS);

            param[15] = new SqlParameter("@BRANCH_CODE", Connection.Get_Company_Type());
            param[16] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            
            param[17] = new SqlParameter("@CREATEDON", TBOV.CREATEDON);
            param[18] = new SqlParameter("@CREATEDBY", TBOV.CREATEDBY);
            param[19] = new SqlParameter("@MODIFIEDBY", TBOV.MODIFIEDBY);
            param[20] = new SqlParameter("@MODIFIEDON", TBOV.MODIFIEDON);

            param[21] = new SqlParameter("@BRANCH_NO", Connection.Get_Company_Type());
            param[22] = new SqlParameter("@BRANCH_NO_LOC", Connection.Get_Company_Type());
            param[23] = new SqlParameter("@JOB_WORKINGPERIOD", Connection.WorkingPeriod());

            param[24] = new SqlParameter("@DESTINATION_TO", TBOV.DESTINATION_TO);
            param[25] = new SqlParameter("@BILLFROM_BRANCH_NO", TBOV.BILLFROM_BRANCH_NO);
            param[26] = new SqlParameter("@BILLFROM_BRANCH_NO_LOC", TBOV.BILLFROM_BRANCH_NO_LOC);
            param[27] = new SqlParameter("@BILLFROM_STATE_NAME", TBOV.BILLFROM_STATE_NAME);
            param[28] = new SqlParameter("@BILLFROM_GSTN_ID", TBOV.BILLFROM_GSTN_ID);

            param[29] = new SqlParameter("@BILLTO_BRANCH_NO", TBOV.BILLTO_BRANCH_NO);
            param[30] = new SqlParameter("@BILLTO_BRANCH_NO_LOC", TBOV.BILLTO_BRANCH_NO_LOC);
            param[31] = new SqlParameter("@BILLTO_STATE_NAME", TBOV.BILLTO_STATE_NAME);
            param[32] = new SqlParameter("@BILLTO_GSTN_ID", TBOV.BILLTO_GSTN_ID);
            param[33] = new SqlParameter("@HSN_SACODE", TBOV.HSN_SACODE);

            param[34] = new SqlParameter("@ACCOUNTS_TYPE", TBOV.ACCOUNTS_TYPE);
            param[35] = new SqlParameter("@BILL_TYPE", TBOV.BILL_TYPE);
            param[36] = new SqlParameter("@INV_TYPE", TBOV.INV_TYPE);
            param[37] = new SqlParameter("@TAX_NONTAX", TBOV.MAIN_TAX_NONTAX);
            param[38] = new SqlParameter("@RCM_YN", TBOV.RCM_YN);
            param[39] = new SqlParameter("@TOTAL_AMT", TBOV.TOTAL_AMT);
            param[40] = new SqlParameter("@NON_TAXABLE_AMT", TBOV.NON_TAXABLE_AMT);
            param[41] = new SqlParameter("@TAXABLE_AMT", TBOV.TAXABLE_AMT);

            param[42] = new SqlParameter("@CGST_RATE", TBOV.MAIN_CGST_RATE );
            param[43] = new SqlParameter("@CGST_AMT",  TBOV.MAIN_CGST_AMT);
            param[44] = new SqlParameter("@SGST_RATE", TBOV.MAIN_SGST_RATE);
            param[45] = new SqlParameter("@SGST_AMT",  TBOV.MAIN_SGST_AMT);
            param[46] = new SqlParameter("@IGST_RATE", TBOV.MAIN_IGST_RATE);
            param[47] = new SqlParameter("@IGST_AMT",  TBOV.MAIN_IGST_AMT);

            param[48] = new SqlParameter("@RCM_AMT", TBOV.RCM_AMT);
            param[49] = new SqlParameter("@TOTAL_BILL_AMT", TBOV.TOTAL_BILL_AMT);
            param[50] = new SqlParameter("@TOTAL_BILL_WORD", TBOV.TOTAL_BILL_WORD);
            param[51] = new SqlParameter("@ADVANCE_AMT", TBOV.ADVANCE_AMT);
            param[52] = new SqlParameter("@BALANCE_AMT", TBOV.BALANCE_AMT);

            param[53] = new SqlParameter("@MARKET_CGST_RATE", TBOV.MARKET_CGST_RATE);
            param[54] = new SqlParameter("@MARKET_SGST_RATE", TBOV.MARKET_SGST_RATE);
            param[55] = new SqlParameter("@MARKET_IGST_RATE", TBOV.MARKET_IGST_RATE);

            param[56] = new SqlParameter("@BILLTO_CODE", TBOV.BILLTO_CODE);
            param[57] = new SqlParameter("@BILLTO_RNO", TBOV.BILLTO_RNO);
            param[58] = new SqlParameter("@BILL_RNO", TBOV.BILL_RNO);
            param[59] = new SqlParameter("@FINYEAR_CODE", TBOV.FINYEAR_CODE);
            param[60] = new SqlParameter("@AC_NAME", TBOV.AC_NAME);
            param[61] = new SqlParameter("@BRANCH", TBOV.BRANCH);
            param[62] = new SqlParameter("@MODEL_BULK_CONTAINER", TBOV.MODEL_BULK_CONTAINER);
            param[63] = new SqlParameter("@MINIMUM_QTY", TBOV.MINIMUM_QTY);
            param[64] = new SqlParameter("@Round_off", TBOV.Round_off);
        
            
            
            
            
            
            //param[10] = new SqlParameter("@DESTINATION_TO", TBOV.DESTINATION_TO);

            //Additional Fields are added End

            Connection.Get_Dataset("GST_BILL_TRANSPORT_JOB_INS_UPD", param);
            result = Convert.ToInt32(param[6].Value.ToString());




            if (TBOV.Flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[8].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    public DataSet Select_TRA_INV(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@Branch_No", objUserBL.Branch_No);
            param[1] = new SqlParameter("@Trans_Mode", objUserBL.MODE);
            param[2] = new SqlParameter("@Imp_Name", objUserBL.Imp_Name);
            param[3] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[4] = new SqlParameter("@Mflag", objUserBL.Flag);
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@Bill_invno", objUserBL.BILL_INV_NO);
            param[7] = new SqlParameter("@FROM_QUOTATION", objUserBL.FROM_QUOTATION);
            param[9] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[10] = new SqlParameter("@J_ASS_VALUE", objUserBL.Ass_Value);
            param[11] = new SqlParameter("@J_CIF_VALUE", objUserBL.CIF_VALUE);
            param[12] = new SqlParameter("@SHIPMENT_TYPE", objUserBL.SHIPMENT_TYPE);

            param[13] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.JOB_WORKINGPERIOD);
            param[14] = new SqlParameter("@BILL_TYPE", objUserBL.BILL_TYPE);

            param[15] = new SqlParameter("@DEFAULT_CUR", objUserBL.DEFAULT_CUR);
            param[16] = new SqlParameter("@EX_RATE", objUserBL.EX_RATE);

            param[24] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[24].Direction = ParameterDirection.Output;
            //ds = Connection.Get_Dataset("GST_BILL_IMPORT_INV_SELECT", param);//Change sp name GST_BILL_TRANSPORT_JOB_INV_SEARCH
            ds = Connection.Get_Dataset("GST_BILL_TRANSPORT_INV_SELECT", param);               
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet BILL_TRANSPORT_JOB_INV_SEARCH_TALLY_DATA(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Shipper_name", objUserBL.Imp_Name);
            param[2] = new SqlParameter("@from_date", objUserBL.from_date);
            param[3] = new SqlParameter("@to_date", objUserBL.todate);
            param[4] = new SqlParameter("@Search_Cat", objUserBL.CHARGE_NAME);
            param[5] = new SqlParameter("@Search_Item", objUserBL.CONSIGNEE_NAME);
            param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[7] = new SqlParameter("@Flag", objUserBL.Flag);
            param[10] = new SqlParameter("@Company_License", Connection.Company_License().ToLower());

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            //ds = Connection.Get_Dataset("GST_BILL_IMPORT_TALLY_DATA", param);
            ds = Connection.Get_Dataset("GST_BILL_TRANSPORT_TALLY_DATA", param);
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public DataSet BILL_TRANSPORT_JOB_INV_SEARCH(Billing_UserBO objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Shipper_name", objUserBL.Imp_Name);
            param[2] = new SqlParameter("@from_date", objUserBL.from_date);
            param[3] = new SqlParameter("@to_date", objUserBL.todate);
            param[4] = new SqlParameter("@Search_Cat", objUserBL.CHARGE_NAME);
            param[5] = new SqlParameter("@Search_Item", objUserBL.CONSIGNEE_NAME);
            param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[7] = new SqlParameter("@Flag", objUserBL.Flag);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("GST_BILL_TRANSPORT_JOB_INV_SEARCH", param);            
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet CHARGE_DETAILS(Transport_BO TBOV)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Shipper_name", TBOV.BILLFROM_NAME);//NOT REQUIRED
            param[2] = new SqlParameter("@from_date", TBOV.BILLFROM_NAME);   //NOT REQUIRED
            param[3] = new SqlParameter("@to_date", TBOV.BILLFROM_NAME);     //NOT REQUIRED
            param[4] = new SqlParameter("@Search_Cat", TBOV.CHARGE_NAME);
            param[5] = new SqlParameter("@Search_Item", TBOV.BILLFROM_NAME); //NOT REQUIRED
            param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[7] = new SqlParameter("@Flag", TBOV.Flag);
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("GST_BILL_TRANSPORT_JOB_INV_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet TRANSPORT_RUNNING_BILL_NO(Transport_BO TBOV)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Shipper_name", Connection.COMPANYID_Upper());
            //param[2] = new SqlParameter("@from_date", TBOV.BILLFROM_NAME);   //NOT REQUIRED
            param[2] = new SqlParameter("@from_date", TBOV.ACCOUNTS_TYPE);   //previous not required, so added this ACCOUNTS_TYPE            
            param[3] = new SqlParameter("@to_date", TBOV.BILLFROM_NAME);     //NOT REQUIRED
            param[4] = new SqlParameter("@Search_Cat", TBOV.BILLTO_BRANCH_NO);
            param[5] = new SqlParameter("@Search_Item", TBOV.BILLTO_NAME); 
            param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[7] = new SqlParameter("@Flag", TBOV.Flag);
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("GST_BILL_TRANSPORT_JOB_INV_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
        
    }

    public DataSet Invoice_Job_Rpt_data(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Bill_Inv_No", objUserBL.BILL_INV_NO);
            param[1] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset(objUserBL.Sp_Name, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public void Open_Transport_Tally_Data(string ddlSearch_Cat_, string txtsearch_, string Imp_name_, string Fromdate_, string Todate_, string Month_, string _Type)
    {
        Billing_UserBO ObjUBO = new Billing_UserBO();
        HttpResponse Response = HttpContext.Current.Response;
        DataSet dss = new DataSet();
        string Filename = "";

        if (Fromdate_ != string.Empty || Todate_ != string.Empty)
        {
            ObjUBO.from_date = Fromdate_;
            ObjUBO.todate = Todate_;
        }
        else
        {
            if (Month_ != string.Empty)
            {
                string[] arr_Month = new string[] { };
                arr_Month = Month_.Split('-');
                ObjUBO.from_date = arr_Month[0];
                ObjUBO.todate = arr_Month[1];
            }
            else
            {
                ObjUBO.from_date = Fromdate_;
                ObjUBO.todate = Todate_;
            }
        }

        if (ddlSearch_Cat_ == "0" || txtsearch_ == "")
        {
            ObjUBO.CHARGE_NAME = "";
            ObjUBO.CONSIGNEE_NAME = "";
        }
        else
        {
            ObjUBO.CHARGE_NAME = ddlSearch_Cat_;
            ObjUBO.CONSIGNEE_NAME = txtsearch_;
        }

        ObjUBO.Imp_Name = Imp_name_;

        if (_Type == "T")
        {
            ObjUBO.Flag = "Tally_Data";
            Filename = "IMPORT_TALLY_DATA";

            //BILL_IMPORT_JOB_INV_SEARCH_TALLY_DATA  REFER THIS METHOD   & SP NAME : OLD SP:  GST_BILL_IMPORT_TALLY_DATA   NEW SP: GST_BILL_TRANSPORT_TALLY_DATA
            //dss = BILL_TRANSPORT_JOB_INV_SEARCH(ObjUBO);//DISABLE ONLY, DONT REMOVE
            dss = BILL_TRANSPORT_JOB_INV_SEARCH_TALLY_DATA(ObjUBO);// ENABLE IT
                    

        }
        else
        {
            ObjUBO.CHARGE_NAME = Connection.Company_License();
            ObjUBO.Flag = "Grid_Search";
            Filename = "IMPORT_Grid_Data";
            //dss = BILL_TRANSPORT_JOB_INV_SEARCH(ObjUBO);//DISABLE ONLY, DONT REMOVE
            dss = BILL_TRANSPORT_JOB_INV_SEARCH_TALLY_DATA(ObjUBO);// ENABLE IT
        }


        DataTable dt = new DataTable();
        dt = dss.Tables[0];

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss

        string strrptNametime = Filename + "_" + s;

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xls");
        Response.Charset = "";
        //Response.ContentType = "application/vnd.ms-excel";
        Response.ContentType = "application/text";
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
                    gv.HeaderRow.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#D8D8D8");
                }

                for (int i = 0; i < gv.Rows.Count; i++)
                {
                    GridViewRow row = gv.Rows[i];
                    gv.Rows[i].Cells[3].Attributes.Add("class", "textmode");
                    row.Attributes.Add("class", "textmode");
                }
                gv.RenderControl(hw);
            }
            //style to format numbers to string
            //string style = @"<style> .textmode { } </style>";
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
    public void Submission_Imp_Json(string Jobno, string Imp_Exp)
    {
        HttpResponse Response = HttpContext.Current.Response;
        try
        {
            DateTime date = System.DateTime.Now;
            string yy = Convert.ToDateTime(date).ToString("yyyyMMdd").ToString();
            string logFileName;
            if (Imp_Exp == "I")
            {
                logFileName = "BE" + Jobno + DateTime.Now.Year.ToString() + ".json";
            }
            else
            {
                logFileName = "SB" + Jobno + DateTime.Now.Year.ToString() + ".json";
            }
            string com_id = Connection.COMPANYID();
            string com_branch = Connection.Current_Branch();
            string com_user = Connection.Current_User();
            string errorFolder = HttpContext.Current.Server.MapPath("~/Submission/" + com_id + "/" + com_branch + "/" + com_user + "/" + "json" + "/");
            string filePath = Path.Combine(errorFolder, logFileName);

            if (!File.Exists(filePath))
            {
                Connection.Error_Msg("JSON file not found. Please generate it first.");
                return;
            }

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));

            Response.Clear();
            Response.Buffer = true;
            Response.ClearHeaders();
            Response.ClearContent();

            FileInfo fi = new FileInfo(filePath);

            Response.ContentType = "application/json";
            Response.AddHeader("Content-Disposition", "attachment; filename=\"" + fi.Name + "\"");
            Response.AddHeader("Content-Length", fi.Length.ToString());

            Response.WriteFile(fi.FullName);

            Response.Flush();
            Response.End();
        }

        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }

}