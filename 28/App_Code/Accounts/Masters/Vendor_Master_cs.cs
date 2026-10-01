using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

public class Vendor_Master_cs
{

    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;
   
    public DataSet GST_Vendor_Master_Select(Billing_UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@Vendor_ID", objUserBL.ID);
            param[1] = new SqlParameter("@Flag", objUserBL.Flag);
            param[2] = new SqlParameter("@Vendor_NAME", objUserBL.VENDOR_NAME);
            param[3] = new SqlParameter("@startRowIndex", objUserBL.Party_Ref);
            param[4] = new SqlParameter("@maximumRows", objUserBL.REMARKS);
            param[5] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@BR_CODE_LOCATION", objUserBL.BR_CODE_LOCATION);

            ds = Connection.Get_Dataset("ACC_GST_VENDOR_MASTER_SEARCH_SELECT", param);
            result = Convert.ToInt32(param[8].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet VendorMaster(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[40];

            param[0] = new SqlParameter("@VEN_ID", objUserBL.VENDOR_ID);
            param[1] = new SqlParameter("@VEN_CODE", objUserBL.VENDOR_CODE);
            param[2] = new SqlParameter("@VEN_NAME", objUserBL.VENDOR_NAME);
            param[3] = new SqlParameter("@UserID", Connection.Current_User());
            param[7] = new SqlParameter("@TAX_TYPE", objUserBL.TAX_TYPE);
            param[8] = new SqlParameter("@TAX_TYPE_ITC", objUserBL.TAX_TYPE_ITC);
            param[9] = new SqlParameter("@PAN_NO", objUserBL.PAN_NO);
            param[10] = new SqlParameter("@TAN_NO", objUserBL.TAN_NO);
            param[11] = new SqlParameter("@CIN_NO", objUserBL.CIN_NO);

            param[12] = new SqlParameter("@TDS_YES_NO", objUserBL.TDS_YES_NO);
            param[13] = new SqlParameter("@EXEMPTION_YES_NO", objUserBL.EXEMPTION_YES_NO);
            param[14] = new SqlParameter("@CERTIFICATE_NO", objUserBL.CERTIFICATE_NO);
            param[15] = new SqlParameter("@VALID_FROM", objUserBL.VALID_FROM);
            param[16] = new SqlParameter("@VALID_TO", objUserBL.VALID_TO);
            param[17] = new SqlParameter("@CREDIT_DAYS", objUserBL.CREDIT_DAYS);

            param[18] = new SqlParameter("@CREDIT_LIMITS", objUserBL.CREDIT_LIMITS);
            param[19] = new SqlParameter("@OPENING_BALANCE", objUserBL.OPENING_BALANCE);
            param[20] = new SqlParameter("@REGISTERED_VENDOR_YES_NO", objUserBL.REGISTERED_VENDOR_YES_NO);
            param[21] = new SqlParameter("@FOREIGN_VENDOR_YES_NO", objUserBL.FOREIGN_VENDOR_YES_NO);
            param[22] = new SqlParameter("@COUNTRY_NAME", objUserBL.COUNTRY_NAME);
            param[23] = new SqlParameter("@ACTIVE_YES_NO", objUserBL.ACTIVE_YES_NO);
            param[24] = new SqlParameter("@NARRATION", objUserBL.NARRATION);
            param[25] = new SqlParameter("@EXEMPTION_VALUE", objUserBL.EXEMPTION_VALUE);
            param[26] = new SqlParameter("@UNDER_NAME", objUserBL.charge_name);
            param[27] = new SqlParameter("@TDS_SECTION", objUserBL.TDS_SECTION);
            param[28] = new SqlParameter("@TDS_RATE", objUserBL.TDS_RATE);

            param[37] = new SqlParameter("@ENAME", objUserBL.ENAME);
            param[38] = new SqlParameter("@XML_DETAIL", objUserBL.XML_DETAIL);
            param[39] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[39].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_VENDOR_INS_UPD_DEL", param);
            result = Convert.ToInt32(param[39].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}