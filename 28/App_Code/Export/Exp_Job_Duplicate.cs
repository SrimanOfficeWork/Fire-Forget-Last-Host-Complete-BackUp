using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;

public class Exp_Job_Duplicate
{
    DataSet ds = new DataSet();
    public int result = 0;
    public DataSet Load_Company_Branch(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@COMPANY_ID", Connection.COMPANYID());
            param[2] = new SqlParameter("@SELECT_BRANCH_CODE", objUserBL.A1);
            param[3] = new SqlParameter("@Working_Period", objUserBL.A2);
            param[4] = new SqlParameter("@name", objUserBL.A3);

            param[5] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "COMPANY_BRANCH_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Select_Job_No(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@JOBNO", objUserBL.A1);
            param[2] = new SqlParameter("@Convert_To", objUserBL.A2);
            param[3] = new SqlParameter("@BRANCHCODE", objUserBL.A3);
            param[4] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@Mflag", objUserBL.A4);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("IMP_EXP_JOB_DUPLICATE_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Select_Job_No(string Connstr, Global_variables objUserBL )
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@JOBNO", objUserBL.A1);
            param[2] = new SqlParameter("@Convert_To", objUserBL.A2);
            param[3] = new SqlParameter("@BRANCHCODE", objUserBL.A3);
            param[4] = new SqlParameter("@Mflag", objUserBL.A4);
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(Connstr, CommandType.StoredProcedure, "IMP_EXP_JOB_DUPLICATE_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public int Generate_Duplicate_Job(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[16];
            param[0] = new SqlParameter("@OLD_JOBNO", objUserBL.A1); 
            param[1] = new SqlParameter("@CURRENT_JOBNO", objUserBL.A2); 
            param[2] = new SqlParameter("@BRANCHCODE", objUserBL.A3); 
            param[3] = new SqlParameter("@name", objUserBL.A4); 
            param[4] = new SqlParameter("@DB_Name", objUserBL.A5);

            param[11] = new SqlParameter("@Job_Prefix", objUserBL.A6);
            param[12] = new SqlParameter("@Job_Suffix", objUserBL.A7);

            param[5] = new SqlParameter("@USERID", Connection.Current_User()); 
            param[6] = new SqlParameter("@Working_Period", Connection.Get_Company_Type()); 
            param[7] = new SqlParameter("@Current_Working_Period", Connection.WorkingPeriod());

            param[9] = new SqlParameter("@Company_license", Connection.Company_License());
            param[10] = new SqlParameter("@Current_Branch", Connection.Current_Branch());

            param[14] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[14].Direction = ParameterDirection.Output;
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            Connection.Get_Dataset(objUserBL.A10, param);
            result = Convert.ToInt32(param[14].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }
    public int Common_Location_Change(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@JOBNO", objUserBL.A1);
            param[2] = new SqlParameter("@CUSTOMS_HOUSE", objUserBL.A2); 
            param[3] = new SqlParameter("@PORT_DISCHARGE", objUserBL.A3); 
            param[4] = new SqlParameter("@PORT_FINAL_DEST", objUserBL.A4); 
            param[5] = new SqlParameter("@Tr_Mode", objUserBL.A5); 
            param[6] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[7] = new SqlParameter("@Ename", objUserBL.A6);
            param[8] = new SqlParameter("@Branch_Common", objUserBL.A7);
            param[9] = new SqlParameter("@JOB_PREFIX", objUserBL.A8);
            param[10] = new SqlParameter("@JOB_SUFFIX", objUserBL.A9);

            param[13] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            Connection.Get_Dataset(objUserBL.A10, param);
            result = Convert.ToInt32(param[13].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }

    public int Job_Copy(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[1] = new SqlParameter("@JOBNO_Old", objUserBL.A1); 
            param[2] = new SqlParameter("@JOBNO_New", objUserBL.A2); 
            param[3] = new SqlParameter("@JOB_PREFIX", objUserBL.A3); 
            param[4] = new SqlParameter("@JOB_SUFFIX", objUserBL.A4); 
            param[5] = new SqlParameter("@JOBNO_PS", objUserBL.A5); 
            param[6] = new SqlParameter("@CUSTOMS_HOUSE", objUserBL.A6);
            param[7] = new SqlParameter("@To_Tr_Mode", objUserBL.A7);
            param[8] = new SqlParameter("@PORT_DISCHARGE", objUserBL.A8); 
            param[9] = new SqlParameter("@PORT_FINAL_DEST", objUserBL.A9); 

            param[10] = new SqlParameter("@Branch_Old", objUserBL.A10); 
            param[11] = new SqlParameter("@Branch_New", Connection.Get_Company_Type());
            param[12] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[13] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());

            param[14] = new SqlParameter("@flag", objUserBL.A11); 
            param[15] = new SqlParameter("@DB_Name", objUserBL.A12); 


            param[23] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[23].Direction = ParameterDirection.Output;
            param[24] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[24].Direction = ParameterDirection.Output;

            Connection.Get_Dataset(objUserBL.A13, param);
            result = Convert.ToInt32(param[23].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }
    public int Job_Copy_Wrk(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[1] = new SqlParameter("@OLD_JOBNO", objUserBL.A1); 
            param[2] = new SqlParameter("@CURRENT_JOBNO", objUserBL.A2); 
            param[3] = new SqlParameter("@Cus_Code", objUserBL.A3); 
            param[4] = new SqlParameter("@Tr_Mode", objUserBL.A4); 
            param[5] = new SqlParameter("@PORT_ORIGIN", objUserBL.A5); 
            param[6] = new SqlParameter("@PORT_SHIPMENT", objUserBL.A6); 
            param[7] = new SqlParameter("@BRANCHCODE", Connection.Get_Company_Type());
            param[8] = new SqlParameter("@Selected_Branch", objUserBL.A7); 
            param[9] = new SqlParameter("@USERID", Connection.Current_User());
            param[10] = new SqlParameter("@DB_Name", objUserBL.A8); 
            param[11] = new SqlParameter("@Current_Working_Period", Connection.WorkingPeriod());

            param[23] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[23].Direction = ParameterDirection.Output;
            param[24] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[24].Direction = ParameterDirection.Output;

            Connection.Get_Dataset(objUserBL.A10, param);
            result = Convert.ToInt32(param[23].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }

    public int Job_Transfer(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[1] = new SqlParameter("@OLD_JOBNO", objUserBL.A1); 
            param[2] = new SqlParameter("@CURRENT_JOBNO", objUserBL.A2); 
            param[3] = new SqlParameter("@Selected_Branch", objUserBL.A3); 
            param[4] = new SqlParameter("@CUSTOMS_HOUSE", objUserBL.A4); 
            param[5] = new SqlParameter("@To_Tr_Mode", objUserBL.A5); 

            param[6] = new SqlParameter("@JOBNO_PS", objUserBL.A6); 
            param[7] = new SqlParameter("@JOB_PREFIX", objUserBL.A7); 
            param[8] = new SqlParameter("@JOB_SUFFIX", objUserBL.A8);

            param[9] = new SqlParameter("@PORT_DISCHARGE", objUserBL.A9);
            param[10] = new SqlParameter("@PORT_FINAL_DEST", objUserBL.A10); 

            param[15] = new SqlParameter("@BRANCHCODE", Connection.Get_Company_Type());
            param[16] = new SqlParameter("@USERID", Connection.Current_User());
            param[17] = new SqlParameter("@Ename", objUserBL.A11); 

            param[18] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;
            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;

            Connection.Get_Dataset(objUserBL.A13, param);
            result = Convert.ToInt32(param[18].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }
}