using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

public class AWB_Export_CS
{
    public int result, UPDATE_ID = 0;
    public String Xml_D;
    
    public int Export_Item_Details_insertupdate(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[100];
            param[3] = new SqlParameter("@ID", objUserBL.ITEM_ID);
            param[4] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[5] = new SqlParameter("@AWB_INV_NO", objUserBL.AWB_INV_NO);
            param[6] = new SqlParameter("@EXPORTER_NAME", objUserBL.ITEM_EXPORTER_NAME);
            param[7] = new SqlParameter("@AWB_TYPE", objUserBL.AWB_TYPE);
            param[8] = new SqlParameter("@MASTER_AWB_NO_1", objUserBL.MASTER_AWB_NO_1);
            param[9] = new SqlParameter("@MASTER_AWB_NO_2", objUserBL.MASTER_AWB_NO_2);
            param[10] = new SqlParameter("@HOUSE_AWB_NO", objUserBL.HOUSE_AWB_NO);
            param[11] = new SqlParameter("@AWB_DATE", Connection.DATE_FORMAT(objUserBL.AWB_DATE == null ? "01/01/1900" : objUserBL.AWB_DATE));
            param[12] = new SqlParameter("@DSR_DATE", Connection.DATE_FORMAT(objUserBL.DSR_DATE == null ? "01/01/1900" : objUserBL.DSR_DATE));
            param[13] = new SqlParameter("@SHIPPER_ACNO", objUserBL.SHIPPER_ACNO);
            param[14] = new SqlParameter("@SHIPPER_NAME", objUserBL.SHIPPER_NAME);
            param[15] = new SqlParameter("@SHIPPER_ADD_1", objUserBL.SHIPPER_ADD_1);
            param[16] = new SqlParameter("@SHIPPER_ADD_2", objUserBL.SHIPPER_ADD_2);
            param[17] = new SqlParameter("@SHIPPER_ADD_3", objUserBL.SHIPPER_ADD_3);
            param[18] = new SqlParameter("@SHIPPER_ADD_4", objUserBL.SHIPPER_ADD_4);
            param[19] = new SqlParameter("@CONSIGNEE_ACNO", objUserBL.CONSIGNEE_ACNO);
            param[20] = new SqlParameter("@CONSIGNEE_LCNO", objUserBL.CONSIGNEE_LCNO);
            param[21] = new SqlParameter("@CONSIGNEE_NAME", objUserBL.CONSIGNEE_NAME);
            param[22] = new SqlParameter("@CONSIGNEE_ADD_1", objUserBL.CONSIGNEE_ADD_1);
            param[23] = new SqlParameter("@CONSIGNEE_ADD_2", objUserBL.CONSIGNEE_ADD_2);
            param[24] = new SqlParameter("@CONSIGNEE_ADD_3", objUserBL.CONSIGNEE_ADD_3);
            param[25] = new SqlParameter("@CONSIGNEE_ADD_4", objUserBL.CONSIGNEE_ADD_4);
            param[26] = new SqlParameter("@AGENT_NAME", objUserBL.AGENT_NAME);
            param[27] = new SqlParameter("@AGENT_CITY", objUserBL.AGENT_CITY);
            param[28] = new SqlParameter("@AGENT_IATA_CODE", objUserBL.AGENT_IATA_CODE);
            param[29] = new SqlParameter("@AGENT_ACNO", objUserBL.AGENT_ACNO);
            param[30] = new SqlParameter("@AGENT_AC_INFO", objUserBL.AGENT_AC_INFO);
            param[31] = new SqlParameter("@AIRPORT_DEPATURE_REQ_ROUTING", objUserBL.AIRPORT_DEPATURE_REQ_ROUTING);
            param[32] = new SqlParameter("@AIRPORT_DESTINATION", objUserBL.AIRPORT_DESTINATION);
            param[33] = new SqlParameter("@FLIGHT_NO", objUserBL.FLIGHT_NO);
            param[34] = new SqlParameter("@FLIGHT_DATE", Connection.DATE_FORMAT(objUserBL.FLIGHT_DATE == null ? "01/01/1900" : objUserBL.FLIGHT_DATE));
            param[35] = new SqlParameter("@AMT_OF_INSURANCE", objUserBL.AMT_OF_INSURANCE);
            param[36] = new SqlParameter("@DV_FOR_CARRIAGE", objUserBL.DV_FOR_CARRIAGE);
            param[37] = new SqlParameter("@DV_FOR_CUSTOMS", objUserBL.DV_FOR_CUSTOMS);
            param[38] = new SqlParameter("@HANDLING_INFO", objUserBL.HANDLING_INFO);
            param[39] = new SqlParameter("@ISSUED_BY", objUserBL.ISSUED_BY);
            param[40] = new SqlParameter("@R_D_TO_1", objUserBL.R_D_TO_1);
            param[41] = new SqlParameter("@R_D_BY_1", objUserBL.R_D_BY_1);
            param[42] = new SqlParameter("@R_D_TO_2", objUserBL.R_D_TO_2);
            param[43] = new SqlParameter("@R_D_BY_2", objUserBL.R_D_BY_2);
            param[44] = new SqlParameter("@R_D_TO_3", objUserBL.R_D_TO_3);
            param[45] = new SqlParameter("@R_D_BY_3", objUserBL.R_D_BY_3);
            param[46] = new SqlParameter("@CURRENCY", objUserBL.CURRENCY);
            param[47] = new SqlParameter("@CHGS_CODE", objUserBL.CHGS_CODE);
            param[48] = new SqlParameter("@WT_VAL", objUserBL.WT_VAL);
            param[49] = new SqlParameter("@OTHER", objUserBL.OTHER);
            param[50] = new SqlParameter("@CH_NO_OF_PIECES_RCP", objUserBL.CH_NO_OF_PIECES_RCP);
            param[51] = new SqlParameter("@CH_GROSS_WGT", objUserBL.CH_GROSS_WGT);
            param[52] = new SqlParameter("@CH_TOTAL", objUserBL.CH_TOTAL);
            param[53] = new SqlParameter("@PP_WGT_CHARGE", objUserBL.PP_WGT_CHARGE);
            param[54] = new SqlParameter("@CC_WGT_CHARGE", objUserBL.CC_WGT_CHARGE);
            param[55] = new SqlParameter("@PP_VALUATION_CHARGE", objUserBL.PP_VALUATION_CHARGE);
            param[56] = new SqlParameter("@CC_VALUATION_CHARGE", objUserBL.CC_VALUATION_CHARGE);
            param[57] = new SqlParameter("@PP_TAX", objUserBL.PP_TAX);
            param[58] = new SqlParameter("@CC_TAX", objUserBL.CC_TAX);
            param[59] = new SqlParameter("@PP_TOTAL_OTH_CH_DUE_AGENT", objUserBL.PP_TOTAL_OTH_CH_DUE_AGENT);
            param[60] = new SqlParameter("@CC_TOTAL_OTH_CH_DUE_AGENT", objUserBL.CC_TOTAL_OTH_CH_DUE_AGENT);
            param[61] = new SqlParameter("@PP_TOTAL_OTH_CH_DUE_CARRIER", objUserBL.PP_TOTAL_OTH_CH_DUE_CARRIER);
            param[62] = new SqlParameter("@CC_TOTAL_OTH_CH_DUE_CARRIER", objUserBL.CC_TOTAL_OTH_CH_DUE_CARRIER);
            param[63] = new SqlParameter("@PP_TOTAL", objUserBL.PP_TOTAL);
            param[64] = new SqlParameter("@CC_TOTAL", objUserBL.CC_TOTAL);
            param[65] = new SqlParameter("@NOTIFY", objUserBL.NOTIFY);
            param[66] = new SqlParameter("@OTHER_CHARGES", objUserBL.OTHER_CHARGES);
            param[67] = new SqlParameter("@SIGN_OF_SHIPPER", objUserBL.SIGN_OF_SHIPPER);
            param[68] = new SqlParameter("@EXECUTED_ON", Connection.DATE_FORMAT(objUserBL.EXECUTED_ON == null ? "01/01/1900" : objUserBL.EXECUTED_ON));
            param[69] = new SqlParameter("@PLACE_AT", objUserBL.PLACE_AT);
            param[70] = new SqlParameter("@SIGN_OF_ISS_CARRIER", objUserBL.SIGN_OF_ISS_CARRIER);
            param[71] = new SqlParameter("@TOTAL_COLLECT_CHARGES", objUserBL.TOTAL_COLLECT_CHARGES);

            param[72] = new SqlParameter("@USER_ID", objUserBL.USER_ID);
            param[73] = new SqlParameter("@BRANCH_CODE", objUserBL.BRANCH_CODE);
            param[74] = new SqlParameter("@WORKINGPERIOD", objUserBL.WORKING_PERIOD);
            param[75] = new SqlParameter("@Branch_Common", objUserBL.BRANCH_COMMON);
            param[76] = new SqlParameter("@flag", objUserBL.flag);
            param[77] = new SqlParameter("@xmlString", Xml_D);

            param[85] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[85].Direction = ParameterDirection.Output;
            param[86] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[86].Direction = ParameterDirection.Output;
            param[87] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[87].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("AWB_EXP_INS_UPD", param);
            result = Convert.ToInt32(param[85].Value.ToString());

            if (objUserBL.flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[87].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return result;
    }
    
    public DataSet AWB_EXPORT_INV_SELECT(UserBO objUserBL)
    {
        DataSet ds = new DataSet(); 
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[0] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[2] = new SqlParameter("@Exp_Name", objUserBL.ITEM_EXPORTER_NAME);
            param[3] = new SqlParameter("@Branch_Type", objUserBL.BRANCH_COMMON);
            param[4] = new SqlParameter("@Mflag", objUserBL.flag);

            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            if (objUserBL.flag == "Grid_Search")
            {
                string[] arr = new string[] { };
                string[] arr2 = new string[] { };

                if (objUserBL.From_date != string.Empty && objUserBL.From_date != null)
                {
                    arr = objUserBL.From_date.Split('/');
                    objUserBL.From_date = arr[1] + '/' + arr[0] + '/' + arr[2];
                }
                if (objUserBL.Todate != string.Empty && objUserBL.Todate != null)
                {
                    arr2 = objUserBL.Todate.Split('/');
                    objUserBL.Todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
                }

               param[9] = new SqlParameter("@AWB_TYPE", objUserBL.AWB_TYPE);
               param[10] = new SqlParameter("@from_date", objUserBL.From_date);
               param[11] = new SqlParameter("@to_date", objUserBL.Todate);
               ds = Connection.Get_Dataset("AWB_EXPORT_SEARCH", param);
            }
            else
            {
                param[1] = new SqlParameter("@Inv_no", objUserBL.INVOICE_SLNO);
                ds = Connection.Get_Dataset("AWB_EXPORT_INV_SELECT", param);
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }
}