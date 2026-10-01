using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;
using System.Web;

public class Staff_Master_cs
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;
    public string Xml_A;
    //ACC_GST_STAFF_MASTER
    public DataSet Staff_Master_Search(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Emp_Id", objUserBL.A1);
            param[2] = new SqlParameter("@Staff_Name", objUserBL.A2);
            param[3] = new SqlParameter("@Mobileno", objUserBL.A3);
           
            param[4] = new SqlParameter("@Flag", objUserBL.A4);
            param[8] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_STAFF_MASTER_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Staff_Master_Data(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Staff_Id", objUserBL.A1);
            param[2] = new SqlParameter("@Emp_Id", objUserBL.A2);
            param[3] = new SqlParameter("@Staff_Name", objUserBL.A3);
            param[4] = new SqlParameter("@Mobileno", objUserBL.A4);
           
            param[12] = new SqlParameter("@Flag", objUserBL.A15);
            param[13] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_STAFF_MASTER_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Staff_Master_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[41];
            param[1] = new SqlParameter("@STAFF_ID", objUserBL.A1);
            param[2] = new SqlParameter("@STAFF_CODE", objUserBL.A2);
            param[3] = new SqlParameter("@STAFF_FULL_NAME", objUserBL.A3);
            param[4] = new SqlParameter("@STAFF_NAME", objUserBL.A4);
            param[5] = new SqlParameter("@EMPLOYEE_ID", objUserBL.A5);
            param[6] = new SqlParameter("@AADHAR_ID", objUserBL.A6);
            param[7] = new SqlParameter("@PAN_ID", objUserBL.A7);
            param[8] = new SqlParameter("@MOBILE_NO", objUserBL.A8);
            param[9] = new SqlParameter("@OTHER_ID_TYPE", objUserBL.A9);
            param[10] = new SqlParameter("@OTHER_ID_NO", objUserBL.A10);

            if (objUserBL.A11 == "" || objUserBL.A11 == null)
            {
                objUserBL.A11 = "01/01/1900";
            }
            param[11] = new SqlParameter("@ENTRY_DATE", Connection.DATE_FORMAT(objUserBL.A11));
            param[12] = new SqlParameter("@BANK_DETAILS", objUserBL.A12);

            if (objUserBL.A13 == "" || objUserBL.A13 == null)
            {
                objUserBL.A13 = "01/01/1900";
            }
            param[13] = new SqlParameter("@DOJ", Connection.DATE_FORMAT(objUserBL.A13));
            param[14] = new SqlParameter("@REMARKS", objUserBL.A14);
            param[15] = new SqlParameter("@DRIVING_LICENSE", objUserBL.A15);
            param[16] = new SqlParameter("@PASSPORT", objUserBL.A16);
            param[17] = new SqlParameter("@REASON", objUserBL.A17);
            param[18] = new SqlParameter("@BANK_NAME", objUserBL.A18);
            param[19] = new SqlParameter("@ACCOUNT_NO", objUserBL.A19);
            param[20] = new SqlParameter("@BANK_USER_NAME", objUserBL.A20);
            param[21] = new SqlParameter("@IFSC_CODE", objUserBL.A21);
            param[22] = new SqlParameter("@BANK_BRANCH_NAME", objUserBL.A22);
            param[23] = new SqlParameter("@SWIFT_CODE", objUserBL.A23);
            param[24] = new SqlParameter("@EMP_STATUS", objUserBL.A24);
            if (objUserBL.A25 == "" || objUserBL.A25 == null)
            {
                objUserBL.A25 = "01/01/1900";
            }
            param[25] = new SqlParameter("@INACTIVE_DATE", Connection.DATE_FORMAT(objUserBL.A25));
            
            param[34] = new SqlParameter("@Flag", objUserBL.A27);
            param[35] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[36] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[37] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[38] = new SqlParameter("@User_Name", Connection.Current_User());
            param[39] = new SqlParameter("@COMPANY_ID", Connection.COMPANYID());

            param[40] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[40].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_STAFF_MASTER_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}