using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;

public class Exp_e_Way_Bill
{
    DataSet ds = new DataSet();
    public int result = 0, UPDATE_ID = 0;

    public DataSet E_Way_Bill(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@Jobno", objUserBL.A1);
            param[1] = new SqlParameter("@From_Name", objUserBL.A2);
            param[2] = new SqlParameter("@From_GSTN_Id", objUserBL.A3);
            param[3] = new SqlParameter("@From_State", objUserBL.A4);
            param[4] = new SqlParameter("@From_Add1", objUserBL.A5);
            param[5] = new SqlParameter("@From_Add2", objUserBL.A6);
            param[6] = new SqlParameter("@From_Place", objUserBL.A7);
            param[7] = new SqlParameter("@From_Pincode", objUserBL.A8);
            param[8] = new SqlParameter("@To_Name", objUserBL.A9);
            param[9] = new SqlParameter("@To_GSTN_Id", objUserBL.A10);
            param[10] = new SqlParameter("@To_State", objUserBL.A11);
            param[11] = new SqlParameter("@To_Add1", objUserBL.A12);
            param[12] = new SqlParameter("@To_Add2", objUserBL.A13);
            param[13] = new SqlParameter("@To_Place", objUserBL.A14);
            param[14] = new SqlParameter("@To_Pincode", objUserBL.A15);
            param[15] = new SqlParameter("@Tr_Name", objUserBL.A16);
            param[16] = new SqlParameter("@Tr_Id", objUserBL.A17);
            param[17] = new SqlParameter("@Tr_Distance_Kms", objUserBL.A18);
            param[18] = new SqlParameter("@Tr_Mode", objUserBL.A19);
            param[19] = new SqlParameter("@Tr_Doc_No", objUserBL.A20);
            param[20] = new SqlParameter("@Vechile_No", objUserBL.A21);
            param[21] = new SqlParameter("@Vechile_Type", objUserBL.A22);
            param[22] = new SqlParameter("@Tr_Date", Connection.DATE_FORMAT(objUserBL.A23));
            param[23] = new SqlParameter("@USER_GSTN_ID", objUserBL.A24);
            param[24] = new SqlParameter("@Flag", objUserBL.A25);

            param[47] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[48] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[49] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[49].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("EXP_E_WAY_BILL_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}