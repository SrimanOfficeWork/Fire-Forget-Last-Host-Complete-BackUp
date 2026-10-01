using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;
using System.Web;

public class Party_Master_CS
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;
    public string Xml_A;

    public DataSet Entry_Data_Search(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A2 != string.Empty && objUserBL.A2 != null)
            {
                arr = objUserBL.A2.Split('/');
                objUserBL.A2 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A3 != string.Empty && objUserBL.A3 != null)
            {
                arr2 = objUserBL.A3.Split('/');
                objUserBL.A3 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Party_Id", objUserBL.A1);
            param[2] = new SqlParameter("@from_date", objUserBL.A2);
            param[3] = new SqlParameter("@to_date", objUserBL.A3);
            param[4] = new SqlParameter("@Flag", objUserBL.A4);

            param[8] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("GST_BILL_PARTY_AMT_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Party_Data_Search(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A2 != string.Empty && objUserBL.A2 != null)
            {
                arr = objUserBL.A2.Split('/');
                objUserBL.A2 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A3 != string.Empty && objUserBL.A3 != null)
            {
                arr2 = objUserBL.A3.Split('/');
                objUserBL.A3 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Client_Id", objUserBL.A1);
            param[2] = new SqlParameter("@from_date", objUserBL.A2);
            param[3] = new SqlParameter("@to_date", objUserBL.A3);
            param[4] = new SqlParameter("@Branch_No", objUserBL.A4);
            param[5] = new SqlParameter("@Flag", objUserBL.A5);

            param[8] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("GST_BILL_PARTY_DATA_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    /*
    public DataSet Client_Master_Data(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Client_Name", objUserBL.A1);
            param[2] = new SqlParameter("@IECNo", objUserBL.A2);
            param[3] = new SqlParameter("@Branch_Name", objUserBL.A3);
            param[4] = new SqlParameter("@Br_Slno", objUserBL.A4);
            param[5] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[6] = new SqlParameter("@Flag", objUserBL.A5);

            param[10] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[11] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[12] = new SqlParameter("@User_Name", Connection.Current_User());
            param[13] = new SqlParameter("@COMPANY_ID", Connection.COMPANYID());

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("GST_CLIENT_MASTER_DATA", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    */
    public DataSet Party_Master_Data(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[1] = new SqlParameter("@Client_Name", objUserBL.A1);
            param[2] = new SqlParameter("@IECNo", objUserBL.A2);
            param[3] = new SqlParameter("@Branch_Name", objUserBL.A3);
            param[4] = new SqlParameter("@Br_Slno", objUserBL.A4);
            param[5] = new SqlParameter("@Add1", objUserBL.A5);
            param[6] = new SqlParameter("@Add2", objUserBL.A6);
            param[7] = new SqlParameter("@Add3", objUserBL.A7);
            param[8] = new SqlParameter("@Add4", objUserBL.A8);
            param[9] = new SqlParameter("@Add5", objUserBL.A9);
            
            param[18] = new SqlParameter("@Flag", objUserBL.A15);
            param[19] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[20] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[21] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[22] = new SqlParameter("@User_Name", Connection.Current_User());
            param[23] = new SqlParameter("@COMPANY_ID", Connection.COMPANYID());

            param[24] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[24].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("GST_CLIENT_MASTER_DATA", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Party_Master_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[41];
            param[1] = new SqlParameter("@Client_Name", objUserBL.A1);
            param[2] = new SqlParameter("@Client_Brno", objUserBL.A2);
            param[3] = new SqlParameter("@Client_BrName", objUserBL.A3);
            param[4] = new SqlParameter("@PartyName", objUserBL.A4);
            param[5] = new SqlParameter("@Party_BrName", objUserBL.A5);
            param[6] = new SqlParameter("@Party_Add_1", objUserBL.A6);
            param[7] = new SqlParameter("@Party_Add_2", objUserBL.A7);
            param[8] = new SqlParameter("@Party_Add_3", objUserBL.A8);
            param[9] = new SqlParameter("@Party_Add_4", objUserBL.A9);
            param[10] = new SqlParameter("@Party_Add_5", objUserBL.A10);
            param[11] = new SqlParameter("@Under", objUserBL.A11);
            param[12] = new SqlParameter("@BankDetails", objUserBL.A12);
            param[13] = new SqlParameter("@Pan_Tan_No", objUserBL.A13);
            param[14] = new SqlParameter("@GST_Reg_Type", objUserBL.A14);
            param[15] = new SqlParameter("@State_Name", objUserBL.A15);
            param[16] = new SqlParameter("@GSTNo", objUserBL.A16);
            param[17] = new SqlParameter("@Credit_Amt", objUserBL.A17);
            param[18] = new SqlParameter("@Debit_Amt", objUserBL.A18);
            param[19] = new SqlParameter("@TDS_YN", objUserBL.A19);
            param[20] = new SqlParameter("@TDS_Section", objUserBL.A20);
            param[21] = new SqlParameter("@TDS_Rate", objUserBL.A21);
            param[22] = new SqlParameter("@Flag", objUserBL.A22);
            
            if (objUserBL.A23 == "" || objUserBL.A23 == null)
            {
                objUserBL.A23 = "01/01/1900";
            }
            param[23] = new SqlParameter("@Amt_Date", Connection.DATE_FORMAT(objUserBL.A23));
            param[24] = new SqlParameter("@State_Code", objUserBL.A24);
            if (objUserBL.A25 == "" || objUserBL.A25 == null)
            {
                objUserBL.A25 = "01/01/1900";
            }
            param[25] = new SqlParameter("@End_Date", Connection.DATE_FORMAT(objUserBL.A25));


            param[34] = new SqlParameter("@Updated_Id", objUserBL.A34);
            param[35] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[36] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[37] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[38] = new SqlParameter("@User_Name", Connection.Current_User());
            param[39] = new SqlParameter("@COMPANY_ID", Connection.COMPANYID());

            param[40] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[40].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("GST_BILL_PARTY_DETAILS_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}