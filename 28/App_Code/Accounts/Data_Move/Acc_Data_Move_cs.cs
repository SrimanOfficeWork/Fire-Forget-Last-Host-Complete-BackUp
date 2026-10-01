using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using BussinessObject;
using Microsoft.ApplicationBlocks.Data;

public class Acc_Data_Move_cs
{
    public DataSet JobData_Select(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        DataSet dss = new DataSet();

        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@J_ID", objUserBL.A1);
            param[2] = new SqlParameter("@JOBNO", objUserBL.A2);
            param[3] = new SqlParameter("@JOBNO_PS", objUserBL.A3);
            param[4] = new SqlParameter("@IMP_EXP", objUserBL.A4);

            param[9] = new SqlParameter("@Ename", objUserBL.A8);
            param[10] = new SqlParameter("@Flag", objUserBL.A9);
            param[11] = new SqlParameter("@User", Connection.Current_User());
            param[12] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[13] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_IMP_EXP_DATA_SERVICES", param);
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (objUserBL.A4 == "I")
                {
                    dss = Import_Ins_Upd(ds, objUserBL.A8, objUserBL.A2, objUserBL.A3);
                }
                else if (objUserBL.A4 == "E")
                {
                    dss = Export_Ins_Upd(ds, objUserBL.A8, objUserBL.A2, objUserBL.A3);
                }
            }
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return dss;
    }
    public DataSet Import_Ins_Upd(DataSet ds, string Flag, string Jobno, string Jobno_Ps)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[1] = new SqlParameter("@xmlString_Gen", Common_CS.ConvertDataTableToXML(ds.Tables[0]));
            param[2] = new SqlParameter("@xmlString_IGM", Common_CS.ConvertDataTableToXML(ds.Tables[1]));
            param[3] = new SqlParameter("@xmlString_Con", Common_CS.ConvertDataTableToXML(ds.Tables[2]));
            param[4] = new SqlParameter("@xmlString_Inv", Common_CS.ConvertDataTableToXML(ds.Tables[3]));
            param[5] = new SqlParameter("@xmlString_Item", Common_CS.ConvertDataTableToXML(ds.Tables[4]));
            param[6] = new SqlParameter("@xmlString_BE", Common_CS.ConvertDataTableToXML(ds.Tables[5]));
            param[7] = new SqlParameter("@xmlString_Bill_Gen", Common_CS.ConvertDataTableToXML(ds.Tables[6]));
            param[8] = new SqlParameter("@xmlString_Bill_Ch", Common_CS.ConvertDataTableToXML(ds.Tables[7]));
            param[9] = new SqlParameter("@Flag", Flag);
            param[10] = new SqlParameter("@JOBNO", Jobno);
            param[11] = new SqlParameter("@JOBNO_PS", Jobno_Ps);

            param[19] = new SqlParameter("@Company_Lic", Connection.Company_License());
            param[20] = new SqlParameter("@USER_NAME", Connection.Current_User());
            param[21] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[22] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[23] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());

            param[24] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[24].Direction = ParameterDirection.Output;
            ds = ParaMount_Connection.Get_Combined_Acc_Con("ACC_GST_BILL_IMP_INVOICE_DATA_SERVICES", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Export_Ins_Upd(DataSet ds, string Flag, string Jobno, string Jobno_Ps)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[26];

            param[1] = new SqlParameter("@xmlString_Gen", Common_CS.ConvertDataTableToXML(ds.Tables[0]));
            param[2] = new SqlParameter("@xmlString_Anx_A", Common_CS.ConvertDataTableToXML(ds.Tables[1]));
            param[3] = new SqlParameter("@xmlString_Anx_S", Common_CS.ConvertDataTableToXML(ds.Tables[2]));
            param[4] = new SqlParameter("@xmlString_S_C", Common_CS.ConvertDataTableToXML(ds.Tables[3]));
            param[5] = new SqlParameter("@xmlString_Inv", Common_CS.ConvertDataTableToXML(ds.Tables[4]));
            param[6] = new SqlParameter("@xmlString_Item", Common_CS.ConvertDataTableToXML(ds.Tables[5]));
            param[7] = new SqlParameter("@xmlString_SB", Common_CS.ConvertDataTableToXML(ds.Tables[6]));
            param[8] = new SqlParameter("@xmlString_Bill_Gen", Common_CS.ConvertDataTableToXML(ds.Tables[7]));
            param[9] = new SqlParameter("@xmlString_Bill_Ch", Common_CS.ConvertDataTableToXML(ds.Tables[8]));
            param[10] = new SqlParameter("@Flag", Flag);
            param[11] = new SqlParameter("@JOBNO", Jobno);
            param[12] = new SqlParameter("@JOBNO_PS", Jobno_Ps);

            param[20] = new SqlParameter("@Company_Lic", Connection.Company_License());
            param[21] = new SqlParameter("@USER_NAME", Connection.Current_User());
            param[22] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[23] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[24] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());

            param[25] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[25].Direction = ParameterDirection.Output;
            ds = ParaMount_Connection.Get_Combined_Acc_Con("ACC_GST_BILL_EXP_INVOICE_DATA_SERVICES", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

}