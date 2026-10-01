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



public class Self_Exporter
{
	
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;


    public DataSet SELF_EXPORTER_INVOICE_CUM_PACKING_LIST_SEARCH(Billing_UserBO objUserBL) 
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

            ds = Connection.Get_Dataset("SELF_EXPORTER_INVOICE_CUM_PACKING_LIST_SEARCH", param); 

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }    

    public void SELF_EXPORTER_INVOICE_CUM_PACKING_LIST_INS_UPD(Self_Exporter_BO SEBOV)
    {
        
        try
        {
            SqlParameter[] param = new SqlParameter[140];
            param[0] = new SqlParameter("@ID", SEBOV.ID);            
            param[1] = new SqlParameter("@BILL_INV_NO", SEBOV.BILL_INV_NO);
            param[2] = new SqlParameter("@BILL_INV_DATE", SEBOV.BILL_INV_DATE);
            
            if (SEBOV.BILL_INV_DATE == null)
            {
                SEBOV.BILL_INV_DATE = string.Empty;
            }
            
            param[2] = new SqlParameter("@BILL_INV_DATE", Connection.DATE_FORMAT(SEBOV.BILL_INV_DATE == string.Empty ? "01/01/1900" : SEBOV.BILL_INV_DATE));

            param[3] = new SqlParameter("@flag", SEBOV.Flag);
            param[4] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@xmlString", SEBOV.Xml_D);

            param[6] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;


            param[9] = new SqlParameter("@JOBNO", SEBOV.JOBNO);
            param[10] = new SqlParameter("@INVOICE_NO", SEBOV.INVOICE_NO);
            param[11] = new SqlParameter("@INVOICE_DATE", SEBOV.INVOICE_DATE);

            if (SEBOV.INVOICE_DATE == null)
            {
                SEBOV.INVOICE_DATE = string.Empty;
            }
            param[11] = new SqlParameter("@INVOICE_DATE", Connection.DATE_FORMAT(SEBOV.INVOICE_DATE == string.Empty ? "01/01/1900" : SEBOV.INVOICE_DATE));


            param[12] = new SqlParameter("@EXPORTERS_REF", SEBOV.EXPORTERS_REF);
            param[13] = new SqlParameter("@BUYER_ORDER_NO_DATE", SEBOV.BUYER_ORDER_NO_DATE);
            param[14] = new SqlParameter("@OTHER_REFERENCES", SEBOV.OTHER_REFERENCES);
            param[15] = new SqlParameter("@INVOICE_NAME", SEBOV.INVOICE_NAME);


            param[16] = new SqlParameter("@EXPORTER_NAME", SEBOV.EXPORTER_NAME);
            param[17] = new SqlParameter("@EXPORTER_BRANCH_NO", SEBOV.EXPORTER_BRANCH_NO);
            param[18] = new SqlParameter("@EXPORTER_IEC_NO", SEBOV.EXPORTER_IEC_NO);
            param[19] = new SqlParameter("@EXPORTER_ADD1", SEBOV.EXPORTER_ADD1);
            param[20] = new SqlParameter("@CONSIGNEE_NAME", SEBOV.CONSIGNEE_NAME);

            param[21] = new SqlParameter("@CONSIGNEE_BRANCH_NO", SEBOV.CONSIGNEE_BRANCH_NO);
            param[22] = new SqlParameter("@CONSIGNEE_ADD1", SEBOV.CONSIGNEE_ADD1);
            param[23] = new SqlParameter("@BUYER_NAME", SEBOV.BUYER_NAME);
            param[24] = new SqlParameter("@BUYER_BRANCH_NO", SEBOV.BUYER_BRANCH_NO);
            param[25] = new SqlParameter("@BUYER_ADD1", SEBOV.BUYER_ADD1);

            param[26] = new SqlParameter("@NOTIFY_NAME", SEBOV.NOTIFY_NAME);
            param[27] = new SqlParameter("@NOTIFY_BRANCH_NO", SEBOV.NOTIFY_BRANCH_NO);
            param[28] = new SqlParameter("@NOTIFY_ADD1", SEBOV.NOTIFY_ADD1);
            param[29] = new SqlParameter("@PRE_CARRIAGE_BY", SEBOV.PRE_CARRIAGE_BY);
            param[30] = new SqlParameter("@PLACE_OF_RECEIPT", SEBOV.PLACE_OF_RECEIPT);



            param[31] = new SqlParameter("@VESSEL_FLIGHT_NO", SEBOV.VESSEL_FLIGHT_NO);
            param[32] = new SqlParameter("@PORT_OF_DISCHARGE", SEBOV.PORT_OF_DISCHARGE);
            param[33] = new SqlParameter("@PORT_OF_LOADING", SEBOV.PORT_OF_LOADING);
            param[34] = new SqlParameter("@FINAL_DEST", SEBOV.FINAL_DEST);
            param[35] = new SqlParameter("@COUNTRY_OF_ORIGIN", SEBOV.COUNTRY_OF_ORIGIN);

            param[36] = new SqlParameter("@COUNTRY_OF_FINAL_DEST", SEBOV.COUNTRY_OF_FINAL_DEST);
            param[37] = new SqlParameter("@TERMS_OF_DELIVERY_PAYMENT", SEBOV.TERMS_OF_DELIVERY_PAYMENT);
            param[38] = new SqlParameter("@CURRENCY", SEBOV.CURRENCY);
            param[39] = new SqlParameter("@CUR_VALUE", SEBOV.CUR_VALUE);
            param[40] = new SqlParameter("@COMMON_PERCENTAGE", SEBOV.COMMON_PERCENTAGE);


            param[41] = new SqlParameter("@TOTAL_PACKAGES", SEBOV.TOTAL_PACKAGES);
            param[42] = new SqlParameter("@TOTAL_PACKAGES_UNIT", SEBOV.TOTAL_PACKAGES_UNIT);
            param[43] = new SqlParameter("@TOTAL_NET_WT", SEBOV.TOTAL_NET_WT);
            param[44] = new SqlParameter("@TOTAL_GR_WT", SEBOV.TOTAL_GR_WT);
            param[45] = new SqlParameter("@TOTAL_CIF", SEBOV.TOTAL_CIF);

            param[46] = new SqlParameter("@WORDS", SEBOV.WORDS);
            param[47] = new SqlParameter("@PACKAGE_RANGE", SEBOV.PACKAGE_RANGE);
            param[48] = new SqlParameter("@CIF_FOREIGN", SEBOV.CIF_FOREIGN);
            param[49] = new SqlParameter("@CIF_LOCAL", SEBOV.CIF_LOCAL);
            param[50] = new SqlParameter("@FRT_FOREIGN", SEBOV.FRT_FOREIGN);



            param[51] = new SqlParameter("@FRT_LOCAL", SEBOV.FRT_LOCAL);
            param[52] = new SqlParameter("@INS_FOREIGN", SEBOV.INS_FOREIGN);
            param[53] = new SqlParameter("@INS_LOCAL", SEBOV.INS_LOCAL);
            param[54] = new SqlParameter("@FOB_FOREIGN", SEBOV.FOB_FOREIGN);
            param[55] = new SqlParameter("@FOB_LOCAL", SEBOV.FOB_LOCAL);

            param[56] = new SqlParameter("@REMARKS", SEBOV.REMARKS);
            param[57] = new SqlParameter("@BRANCH_CODE", Connection.Get_Company_Type());
            param[58] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[59] = new SqlParameter("@CREATEDON", SEBOV.CREATEDON);
            param[60] = new SqlParameter("@CREATEDBY", SEBOV.CREATEDBY);
            param[61] = new SqlParameter("@MODIFIEDBY", SEBOV.MODIFIEDBY);
            param[62] = new SqlParameter("@MODIFIEDON", SEBOV.MODIFIEDON);

            Connection.Get_Dataset("SELF_EXPORTER_INVOICE_CUM_PACKING_LIST_INS_UPD", param);
            result = Convert.ToInt32(param[6].Value.ToString());

            if (SEBOV.Flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[8].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public DataSet SELECT_SELF_EXPORTER_INV_CUM_PACKING_LIST(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@Exp_Name", objUserBL.Imp_Name);
            param[1] = new SqlParameter("@Jobno", objUserBL.JOBNO);            
            param[2] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[3] = new SqlParameter("@Mflag", objUserBL.Flag);

            param[4] = new SqlParameter("@FROM_QUOTATION", objUserBL.FROM_QUOTATION);
            param[5] = new SqlParameter("@Bill_invno", objUserBL.BILL_INV_NO);            
            param[6] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[7] = new SqlParameter("@Trans_Mode", objUserBL.MODE);
            param[8] = new SqlParameter("@Branch_No", objUserBL.Branch_No);
            param[9] = new SqlParameter("@SHIPMENT_TYPE", objUserBL.SHIPMENT_TYPE);
            param[10] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.JOB_WORKINGPERIOD);
            param[11] = new SqlParameter("@User_Id", Connection.Current_User());

            param[12] = new SqlParameter("@BILL_TYPE", objUserBL.BILL_TYPE);
            param[13] = new SqlParameter("@DEFAULT_CUR", objUserBL.DEFAULT_CUR);
            param[14] = new SqlParameter("@EX_RATE", objUserBL.EX_RATE);
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;            
            ds = Connection.Get_Dataset("SELF_EXPORTER_INVOICE_CUM_PACKING_LIST_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Self_Exporter_Invoice_Cum_Packing_List_Rpt_data(Billing_UserBO objUserBL)
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

   
}