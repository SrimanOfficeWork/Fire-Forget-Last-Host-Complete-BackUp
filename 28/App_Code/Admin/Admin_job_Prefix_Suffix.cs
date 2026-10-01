using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class Admin_job_Prefix_Suffix
{
    public int result = 0, UPDATE_ID = 0, Imp_result = 0;

    private string _Branch;
    private string _Ename;

    private string _I_PREFIX;
    private string _I_Jobno;
    private string _I_Suffix;
    private string _E_PREFIX;
    private string _E_Jobno;
    private string _E_Suffix;
    private string _user_Id;

    private string _Working_period;
    private string _Flag;
    private string _Tr_mode;
    private string _GroupName, _CusHouse, _BranchType;
    
    public string Tr_mode { get { return _Tr_mode; } set { _Tr_mode = value; } }
    public string Branch { get { return _Branch; } set { _Branch = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string BranchType { get { return _BranchType; } set { _BranchType = value; } }


    public string I_PREFIX { get { return _I_PREFIX; } set { _I_PREFIX = value; } }
    public string I_Jobno { get { return _I_Jobno; } set { _I_Jobno = value; } }
    public string I_Suffix { get { return _I_Suffix; } set { _I_Suffix = value; } }
    public string E_PREFIX { get { return _E_PREFIX; } set { _E_PREFIX = value; } }
    public string E_Jobno { get { return _E_Jobno; } set { _E_Jobno = value; } }
    public string E_Suffix { get { return _E_Suffix; } set { _E_Suffix = value; } }
    public string user_Id { get { return _user_Id; } set { _user_Id = value; } }
    public string Working_period { get { return _Working_period; } set { _Working_period = value; } }
    public string Flag { get { return _Flag; } set { _Flag = value; } }
    public string GroupName { get { return _GroupName; } set { _GroupName = value; } }
    public string CusHouse { get { return _CusHouse; } set { _CusHouse = value; } }

    private string _ICA_PREFIX;
    private string _ICA_Suffix;

    private string _ICS_PREFIX;
    private string _ICS_Suffix;

    private string _ICL_PREFIX;
    private string _ICL_Suffix;

    private string _ECA_PREFIX;
    private string _ECA_Suffix;

    private string _ECS_PREFIX;
    private string _ECS_Suffix;

    private string _ECL_PREFIX;
    private string _ECL_Suffix;
    private string _I_Common_job;
    private string _E_Common_job;

    public string ICA_PREFIX { get { return _ICA_PREFIX; } set { _ICA_PREFIX = value; } }
    public string ICA_Suffix { get { return _ICA_Suffix; } set { _ICA_Suffix = value; } }

    public string ICS_PREFIX { get { return _ICS_PREFIX; } set { _ICS_PREFIX = value; } }
    public string ICS_Suffix { get { return _ICS_Suffix; } set { _ICS_Suffix = value; } }

    public string ICL_PREFIX { get { return _ICL_PREFIX; } set { _ICL_PREFIX = value; } }
    public string ICL_Suffix { get { return _ICL_Suffix; } set { _ICL_Suffix = value; } }

    public string ECA_PREFIX { get { return _ECA_PREFIX; } set { _ECA_PREFIX = value; } }
    public string ECA_Suffix { get { return _ECA_Suffix; } set { _ECA_Suffix = value; } }
    public string ECS_PREFIX { get { return _ECS_PREFIX; } set { _ECS_PREFIX = value; } }
    public string ECS_Suffix { get { return _ECS_Suffix; } set { _ECS_Suffix = value; } }

    public string ECL_PREFIX { get { return _ECL_PREFIX; } set { _ECL_PREFIX = value; } }
    public string ECL_Suffix { get { return _ECL_Suffix; } set { _ECL_Suffix = value; } }

    public string I_Common_job { get { return _I_Common_job; } set { _I_Common_job = value; } }
    public string E_Common_job { get { return _E_Common_job; } set { _E_Common_job = value; } }

    DataSet ds = new DataSet();
    public DataSet Job_prefix_Suffix_Select()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Branch", Branch);
            param[1] = new SqlParameter("@Tr_mode", Tr_mode);
            param[2] = new SqlParameter("@Ename", Ename);
            param[3] = new SqlParameter("@Branch_code", Connection.Current_Branch());
            param[4] = new SqlParameter("@Company_license", Connection.Company_License());

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "ADMIN_JOBNO_PREFIX_SUFFIX_SELECT", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }
    public void IMP_EXP_Branch_INS_UPD()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@I_PREFIX", I_PREFIX);
            param[1] = new SqlParameter("@I_Jobno", I_Jobno);
            param[2] = new SqlParameter("@I_Suffix", I_Suffix);

            param[3] = new SqlParameter("@E_PREFIX", E_PREFIX);
            param[4] = new SqlParameter("@E_Jobno", E_Jobno);
            param[5] = new SqlParameter("@E_Suffix", E_Suffix);

            param[6] = new SqlParameter("@Branch", Branch);
            param[7] = new SqlParameter("@user_Id", user_Id);
            param[8] = new SqlParameter("@Working_period", Working_period);

            param[9] = new SqlParameter("@flag", Flag);
            param[13] = new SqlParameter("@TrMode", Tr_mode);

            param[10] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "ADMIN_JOBNO_PREFIX_SUFFIX_INS_UPD", param);
            result = Convert.ToInt32(param[10].Value.ToString());
          
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }
    public void IMP_EXP_Common_INS_UPD()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@I_Common_job", I_Common_job);
            param[1] = new SqlParameter("@E_Common_job", E_Common_job);

            param[2] = new SqlParameter("@ICA_PREFIX", ICA_PREFIX);
            param[3] = new SqlParameter("@ICA_Suffix", ICA_Suffix);

            param[4] = new SqlParameter("@ICS_PREFIX", ICS_PREFIX);
            param[5] = new SqlParameter("@ICS_Suffix", ICS_Suffix);

            param[6] = new SqlParameter("@ICL_PREFIX", ICL_PREFIX);
            param[7] = new SqlParameter("@ICL_Suffix", ICL_Suffix);

            param[8] = new SqlParameter("@ECA_PREFIX", ECA_PREFIX);
            param[9] = new SqlParameter("@ECA_Suffix", ECA_Suffix);

            param[10] = new SqlParameter("@ECS_PREFIX", ECS_PREFIX);
            param[11] = new SqlParameter("@ECS_Suffix", ECS_Suffix);

            param[12] = new SqlParameter("@ECL_PREFIX", ECL_PREFIX);
            param[13] = new SqlParameter("@ECL_Suffix", ECL_Suffix);

            //param[6] = new SqlParameter("@Branch", Branch);
            param[14] = new SqlParameter("@user_Id", user_Id);
            param[15] = new SqlParameter("@Working_period", Working_period);

            param[16] = new SqlParameter("@flag", Flag);

            param[17] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[17].Direction = ParameterDirection.Output;

            param[18] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[18].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "ADMIN_JOBNO_PREFIX_SUFFIX_INS_UPD_COMMON", param);
            result = Convert.ToInt32(param[10].Value.ToString());

            if (Flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[11].Value.ToString());
            }

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }


    public void IMP_EXP_Areawise_INS_UPD()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];


            param[1] = new SqlParameter("@I_Jobno", I_Jobno);
            param[2] = new SqlParameter("@E_Jobno", E_Jobno);

            param[3] = new SqlParameter("@ICA_PREFIX", ICA_PREFIX);
            param[4] = new SqlParameter("@ICA_Suffix", ICA_Suffix);

            param[5] = new SqlParameter("@ICS_PREFIX", ICS_PREFIX);
            param[6] = new SqlParameter("@ICS_Suffix", ICS_Suffix);

            param[7] = new SqlParameter("@ICL_PREFIX", ICL_PREFIX);
            param[8] = new SqlParameter("@ICL_Suffix", ICL_Suffix);

            param[9] = new SqlParameter("@ECA_PREFIX", ECA_PREFIX);
            param[10] = new SqlParameter("@ECA_Suffix", ECA_Suffix);

            param[11] = new SqlParameter("@ECS_PREFIX", ECS_PREFIX);
            param[12] = new SqlParameter("@ECS_Suffix", ECS_Suffix);

            param[13] = new SqlParameter("@ECL_PREFIX", ECL_PREFIX);
            param[14] = new SqlParameter("@ECL_Suffix", ECL_Suffix);

            param[15] = new SqlParameter("@Branch", Branch);
            param[16] = new SqlParameter("@user_Id", user_Id);
            param[17] = new SqlParameter("@Working_period", Working_period);

            param[18] = new SqlParameter("@TrMode", Tr_mode);
            param[19] = new SqlParameter("@GroupName", GroupName);
            param[20] = new SqlParameter("@CusHouse", CusHouse);
            param[24] = new SqlParameter("@Branch_Type", BranchType);

            param[21] = new SqlParameter("@flag", Flag);
            param[22] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[22].Direction = ParameterDirection.Output;

            param[23] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[23].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "ADMIN_JOBNO_PREFIX_SUFFIX_INS_UPD_AREAWISE", param);
            result = Convert.ToInt32(param[22].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public DataSet Job_prefix_Suffix_Select_Areawise()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Branch", Branch);
            param[1] = new SqlParameter("@Tr_mode", Tr_mode);
            param[2] = new SqlParameter("@GroupName", GroupName);
            param[3] = new SqlParameter("@CusHouse", CusHouse);
            param[4] = new SqlParameter("@Company_license", Connection.Company_License());
            param[7] = new SqlParameter("@Branch_Type", BranchType);
            param[5] = new SqlParameter("@Ename", Ename);

            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "ADMIN_JOBNO_PREFIX_SUFFIX_SELECT_AREAWISE", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

}