using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;

public class ICode_CS
{
    public DataSet Get_Login_Details(string COMPANY_LICENSE, string WORKING_PERIOD, string Flag, string Imp_Exp, DataSet ds)
    {
        DataSet dss = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@COMPANY_LICENSE", COMPANY_LICENSE);
            param[2] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[3] = new SqlParameter("@General", Common_CS.ConvertDataTableToXML(ds.Tables[0]));
            param[4] = new SqlParameter("@Imp_Exp", Imp_Exp);
            param[5] = new SqlParameter("@Flag", Flag);
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            dss = SqlHelper.ExecuteDataset(Connection.Get_DSC_Con_String(COMPANY_LICENSE), CommandType.StoredProcedure, "LOGIN_DETAILS", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return dss;
    }
    public DataSet Ryal_Imp_Exp_Data(DataSet ds, string Imp_Exp)
    {
        DataSet ss = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@General", Common_CS.ConvertDataTableToXML(ds.Tables[1]));
            param[2] = new SqlParameter("@Imp_Exp", Imp_Exp);
            param[3] = new SqlParameter("@Branch_Common", ds.Tables[0].Rows[0][1].ToString());

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
           ss= SqlHelper.ExecuteDataset(ds.Tables[0].Rows[0][0].ToString(), CommandType.StoredProcedure, "I_FF_IMP_EXP_INS_UPD", param); 
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ss;
    }
    public DataSet Imp_Exp_Job_Search(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[1] = new SqlParameter("@Jobno", objUserBL.A1);
            param[2] = new SqlParameter("@Cus_name", objUserBL.A2);
            param[3] = new SqlParameter("@from_date", Connection.Search_Date(objUserBL.A3));
            param[4] = new SqlParameter("@to_date", Connection.Search_Date(objUserBL.A4));
            param[5] = new SqlParameter("@Imp_Exp", objUserBL.A5);

            param[6] = new SqlParameter("@Comp_ID", Connection.COMPANYID());
            param[7] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[8] = new SqlParameter("@Flag", objUserBL.A6);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ICODE_WEBSERVICE_IMP_EXP_JOB_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Get_ICode_Jobno_Select(string Jobno, string IMP_EXP, string flag, string FF_REF_NO, string FF_Company_Lic)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[21];
            param[1] = new SqlParameter("@Jobno", Jobno);
            param[4] = new SqlParameter("@Imp_Exp", IMP_EXP);
            param[5] = new SqlParameter("@Flag", flag);
            param[6] = new SqlParameter("@FF_REF_NO", FF_REF_NO);
            param[7] = new SqlParameter("@FF_Company_Lic", FF_Company_Lic);

            param[15] = new SqlParameter("@User", Connection.Current_User());
            param[16] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[17] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[18] = new SqlParameter("@Company_Lic", Connection.Company_License());
            param[19] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());

            param[20] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[20].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ICODE_FF_DATA_SELECT", param);

        }
        catch (Exception ex)
        {   
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}