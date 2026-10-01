using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;
using System.Web;

public class Sales_Inv_Json_cs
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;
    Global_variables ObjUBO = new Global_variables();
   
    public DataSet Data_Json(string Inv_Id, string Invno)
    {
            try
                {
                    SqlParameter[] param = new SqlParameter[11];
                    
                    param[1] = new SqlParameter("@Bill_Id", Inv_Id);
                    param[2] = new SqlParameter("@Bill_Inv_No", Invno);
                    param[3] = new SqlParameter("@flag", "Sales_Json_Data");
                    param[4] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
                    param[5] = new SqlParameter("@User_Name", Connection.Current_User());
                    param[6] = new SqlParameter("@Company_License", Connection.Company_License());

                    param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
                    param[10].Direction = ParameterDirection.Output;
                    ds = Connection.Get_Dataset("ACC_GST_SALES_BILL_JSON_DATA", param);
                }
                catch (Exception ex)
                {
                    Connection.Error_Msg(ex.Message);
                }
                return ds;
    }

    public DataSet E_Invoice_Ins_Upd(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[1] = new SqlParameter("@E_ID", objUserBL.A201);  //JOB_ID
            param[2] = new SqlParameter("@I_E", objUserBL.A202); //JOB_TYPE
            param[3] = new SqlParameter("@BILL_INV_NO", objUserBL.A203); //INV_No
            param[4] = new SqlParameter("@IRN_No", objUserBL.A204); //IRN_No
            param[5] = new SqlParameter("@ACKNO", objUserBL.A205); //ACK_No
            if (objUserBL.A206 == "" || objUserBL.A206 == null)
            {
                objUserBL.A206 = "01/01/1900";
            }
            param[6] = new SqlParameter("@ACKDT", Connection.DATE_FORMAT(objUserBL.A206 == string.Empty ? "01/01/1900" : objUserBL.A206)); //ACK_Dt
            param[7] = new SqlParameter("@SignedQRCodeImage", objUserBL.A207); //SignedQRCodeImage
            param[8] = new SqlParameter("@SignedQRCode", objUserBL.A208); //SignedQRCode
            param[9] = new SqlParameter("@INV_STATUS", objUserBL.A209); //STATUS
            param[10] = new SqlParameter("@QRCode_ImgPath", objUserBL.A210); //QRCode_ImgPath
            param[11] = new SqlParameter("@FILE_PATH", objUserBL.A211); //InvFile_Path
            param[12] = new SqlParameter("@SOURCE_FILE", objUserBL.A212); //InvFile_Path
            param[13] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A213);//InvFile_Path
            param[14] = new SqlParameter("@Mflag", objUserBL.A214);
            param[15] = new SqlParameter("@USERNAME", Connection.Current_User());
            param[16] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[17] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[18] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            ds = Connection.Get_Dataset("ACC_GST_E_INVOICE_IRN_INSERT_UPDATE", param);  
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

        
}