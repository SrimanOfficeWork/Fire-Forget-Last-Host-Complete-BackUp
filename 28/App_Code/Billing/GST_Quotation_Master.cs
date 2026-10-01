using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;

public class GST_Quotation_Master
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;

    public DataSet Quotation_Master_Select(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Client_Name", objUserBL.Imp_Name);
            param[2] = new SqlParameter("@MODE", objUserBL.MODE);
            param[3] = new SqlParameter("@Branch_No", objUserBL.DESTINATION);
            param[4] = new SqlParameter("@Flag", objUserBL.Flag);
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@Ref_ID", objUserBL.Ref_ID);
            param[7] = new SqlParameter("@SHIPMENT_TYPE", objUserBL.SHIPMENT_TYPE);
            param[8] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("GST_QUOTATION_MASTER_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public void Quotation_INS_UPD(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];
            param[0] = new SqlParameter("@ID", objUserBL.ID);
            param[1] = new SqlParameter("@CLIENT_NAME", objUserBL.Imp_Name);
            param[2] = new SqlParameter("@MODE", objUserBL.MODE);
            param[3] = new SqlParameter("@xmlString",objUserBL.Xml_D);
            param[4] = new SqlParameter("@Branch_No",objUserBL.DESTINATION);
            param[5] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[7] = new SqlParameter("@User_Id", Connection.Current_User());
            param[8] = new SqlParameter("@flag", objUserBL.Flag);
            param[9] = new SqlParameter("@Ref_ID", objUserBL.Ref_ID);
            param[10] = new SqlParameter("@SHIPMENT_TYPE", objUserBL.SHIPMENT_TYPE);

            param[11] = new SqlParameter("@To_CLIENT_NAME", objUserBL.SHIPPER_NAME);
            param[12] = new SqlParameter("@To_Branch_No", objUserBL.BRANCHSLNO);

            param[14] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[14].Direction = ParameterDirection.Output;

            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            param[16] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[16].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("GST_BILL_QUOTATION_MASTER_INS_UPD", param);
            result = Convert.ToInt32(param[14].Value.ToString());

            if (objUserBL.Flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[16].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public DataSet BILL_Quotation_Master_Search(Billing_UserBO objUserBL)
    {
        DataSet ds = new DataSet();
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
            param[1] = new SqlParameter("@Client_name", objUserBL.Imp_Name);
            param[2] = new SqlParameter("@Mode", objUserBL.MODE);
            param[3] = new SqlParameter("@from_date", objUserBL.from_date);
            param[4] = new SqlParameter("@to_date", objUserBL.todate);
            param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("GST_QUOTATION_MASTER_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}