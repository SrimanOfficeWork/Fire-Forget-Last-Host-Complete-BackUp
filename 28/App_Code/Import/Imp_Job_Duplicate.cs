using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

public class Imp_Job_Duplicate
{
    public int result = 0;

    private string _OLD_JOBNO ,_NEW_JOBNO,_BRANCH_CODE,_USER_ID,_Ename,_WORKING_PERIOD,_JOBNO,_Branch_Old,_Branch_New,_CUSTOMS_HOUSE,_COMPANY_ID,_SELECT_BRANCH_CODE,
                   _JOB_PREFIX, _JOB_SUFFIX, _JOBNO_PS, _To_Tr_Mode, _Branch_Common, _PORT_ORIGIN, _PORT_SHIPMENT, _Convert_To, _DBS_Name, _Sp_name;

    public string OLD_JOBNO { get { return _OLD_JOBNO; } set { _OLD_JOBNO = value; } }
    public string NEW_JOBNO { get { return _NEW_JOBNO; } set { _NEW_JOBNO = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }

    public string Branch_Old { get { return _Branch_Old; } set { _Branch_Old = value; } }
    public string Branch_New { get { return _Branch_New; } set { _Branch_New = value; } }
    public string CUSTOMS_HOUSE { get { return _CUSTOMS_HOUSE; } set { _CUSTOMS_HOUSE = value; } }
    public string COMPANY_ID { get { return _COMPANY_ID; } set { _COMPANY_ID = value; } }
    public string SELECT_BRANCH_CODE { get { return _SELECT_BRANCH_CODE; } set { _SELECT_BRANCH_CODE = value; } }
    public string JOB_PREFIX { get { return _JOB_PREFIX; } set { _JOB_PREFIX = value; } }
    public string JOB_SUFFIX { get { return _JOB_SUFFIX; } set { _JOB_SUFFIX = value; } }
    public string JOBNO_PS { get { return _JOBNO_PS; } set { _JOBNO_PS = value; } }
    public string To_Tr_Mode { get { return _To_Tr_Mode; } set { _To_Tr_Mode = value; } }
    public string Branch_Common { get { return _Branch_Common; } set { _Branch_Common = value; } }

    public string PORT_ORIGIN { get { return _PORT_ORIGIN; } set { _PORT_ORIGIN = value; } }
    public string PORT_SHIPMENT { get { return _PORT_SHIPMENT; } set { _PORT_SHIPMENT = value; } }
    public string Convert_To { get { return _Convert_To; } set { _Convert_To = value; } }
    public string DBS_Name { get { return _DBS_Name; } set { _DBS_Name = value; } }
    public string Sp_name { get { return _Sp_name; } set { _Sp_name = value; } }
    
    
    DataSet ds = new DataSet();
    public int Generate_Duplicate_Job()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@JOBNO_Old", OLD_JOBNO);
            param[1] = new SqlParameter("@JOBNO_New", NEW_JOBNO);
            param[2] = new SqlParameter("@Branch_Old", Branch_Old);
            param[3] = new SqlParameter("@Branch_New", Branch_New);
            param[4] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[5] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);
            param[6] = new SqlParameter("@USER_ID", USER_ID);
            param[7] = new SqlParameter("@flag", Ename);
            param[8] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            if (Ename == "IMP_Job_Duplicate_Generate")
            {
                Connection.Get_Dataset("IMP_JOB_DUPLICATE_BRANCH_TO_BRANCH", param);
                result = Convert.ToInt32(param[8].Value.ToString());
            }
            else if (Ename == "EXP_Job_Duplicate_Generate")
            {
                Connection.Get_Dataset("EXP_JOB_DUPLICATE_BRANCH_TO_BRANCH", param);
                result = Convert.ToInt32(param[8].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }
    public int Generate_Duplicate_Job_Branch_Branch(string Connstr)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@JOBNO_Old", OLD_JOBNO);
            param[1] = new SqlParameter("@JOBNO_New", NEW_JOBNO);
            param[2] = new SqlParameter("@Branch_Old", Branch_Old);
            param[3] = new SqlParameter("@Branch_New", Branch_New);
            param[4] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[5] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);
            param[6] = new SqlParameter("@USER_ID", USER_ID);
            param[7] = new SqlParameter("@flag", Ename);

            param[8] = new SqlParameter("@JOB_PREFIX", JOB_PREFIX);
            param[9] = new SqlParameter("@JOB_SUFFIX", JOB_SUFFIX);
            param[10] = new SqlParameter("@JOBNO_PS", JOBNO_PS);

            param[13] = new SqlParameter("@To_Tr_Mode", To_Tr_Mode);
                                    
            param[11] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[12].Direction = ParameterDirection.Output;

            if (Ename == "IMP_Job_Duplicate_Generate")
            {
                param[14] = new SqlParameter("@PORT_ORIGIN", PORT_ORIGIN);
                param[15] = new SqlParameter("@PORT_SHIPMENT", PORT_SHIPMENT);

                if (Branch_Common != "")
                {
                    SqlHelper.ExecuteDataset(Connstr, CommandType.StoredProcedure, "IMP_JOB_DUPLICATE_BRANCH_TO_BRANCH", param);
                    
                }
                else
                {
                    SqlHelper.ExecuteDataset(Connstr, CommandType.StoredProcedure, "IMP_JOB_DUPLICATE_BRANCH_TO_BRANCH_COMMON", param);
                }
                result = Convert.ToInt32(param[11].Value.ToString());
            }
            else if (Ename == "EXP_Job_Duplicate_Generate")
            {
                param[14] = new SqlParameter("@PORT_DISCHARGE", PORT_ORIGIN);
                param[15] = new SqlParameter("@PORT_FINAL_DEST", PORT_SHIPMENT);

                if (Branch_Common != "")
                {
                    SqlHelper.ExecuteDataset(Connstr, CommandType.StoredProcedure, "EXP_JOB_DUPLICATE_BRANCH_TO_BRANCH", param);
                }
                else
                {
                    SqlHelper.ExecuteDataset(Connstr, CommandType.StoredProcedure, "EXP_JOB_DUPLICATE_BRANCH_TO_BRANCH_COMMON", param);
                }
                result = Convert.ToInt32(param[11].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }
    public DataSet Select_Job_No()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@Convert_To", Convert_To);
            param[3] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);
            param[4] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@Mflag", Ename);

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

    public DataSet Select_Job_No(string Connstr, string JobType)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@Convert_To", Convert_To);
            param[3] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);
            param[4] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@Mflag", Ename);
            param[6] = new SqlParameter("@JobType", JobType);
            param[7] = new SqlParameter("@UserCreation_ID", HttpContext.Current.Session["USER_CREATION_ID"].ToString());

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            //ds = SqlHelper.ExecuteDataset(Connstr, CommandType.StoredProcedure, "IMP_EXP_JOB_DUPLICATE_SELECT", param); //hide on 17-08-2026
            ds = SqlHelper.ExecuteDataset(Connstr, CommandType.StoredProcedure, "IMP_EXP_JOB_DUPLICATE_SELECT_USERWISE_IEC_BASED_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Load_Company_Branch()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@COMPANY_ID", Connection.COMPANYID());
            param[2] = new SqlParameter("@SELECT_BRANCH_CODE", SELECT_BRANCH_CODE);
            param[3] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());

            param[4] = new SqlParameter("@Working_Period", WORKING_PERIOD);
            param[5] = new SqlParameter("@name", Ename);
           
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


    public int Gen_Duplicate_Job()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[26];
            param[1] = new SqlParameter("@OLD_JOBNO", OLD_JOBNO);
            param[2] = new SqlParameter("@CURRENT_JOBNO", JOBNO);
            param[3] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);
            param[4] = new SqlParameter("@name", Ename);
            param[5] = new SqlParameter("@DB_Name", DBS_Name);

            param[11] = new SqlParameter("@Job_Prefix", JOB_PREFIX);
            param[12] = new SqlParameter("@Job_Suffix", JOB_SUFFIX);

            param[6] = new SqlParameter("@USERID", Connection.Current_User());
            param[7] = new SqlParameter("@Working_Period", Connection.Get_Company_Type());
            param[8] = new SqlParameter("@Current_Working_Period", Connection.WorkingPeriod());
            param[9] = new SqlParameter("@Company_license", Connection.Company_License());
            param[10] = new SqlParameter("@Current_Branch", Connection.Current_Branch());

            param[24] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[24].Direction = ParameterDirection.Output;
            param[25] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[25].Direction = ParameterDirection.Output;

            if (Ename == "Duplicate_Job")
            {
                Connection.Get_Dataset(Sp_name, param);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }

    public int Common_Location_Change()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);
            param[3] = new SqlParameter("@PORT_ORIGIN", PORT_ORIGIN);
            param[4] = new SqlParameter("@PORT_SHIPMENT", PORT_SHIPMENT);
            param[5] = new SqlParameter("@Tr_Mode", To_Tr_Mode);
            param[6] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[7] = new SqlParameter("@Ename",Ename);
            param[8] = new SqlParameter("@Branch_Common", Branch_Common);

            param[9] = new SqlParameter("@JOB_PREFIX", JOB_PREFIX);
            param[10] = new SqlParameter("@JOB_SUFFIX", JOB_SUFFIX);

            param[13] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            Connection.Get_Dataset(Sp_name, param);
            result = Convert.ToInt32(param[13].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }


    public int Job_Copy()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[1] = new SqlParameter("@JOBNO_Old", OLD_JOBNO);
            param[2] = new SqlParameter("@JOBNO_New", JOBNO);
            param[3] = new SqlParameter("@JOB_PREFIX", JOB_PREFIX);
            param[4] = new SqlParameter("@JOB_SUFFIX", JOB_SUFFIX);
            param[5] = new SqlParameter("@JOBNO_PS", JOBNO_PS);
            param[6] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);
            param[7] = new SqlParameter("@To_Tr_Mode", To_Tr_Mode);
            param[8] = new SqlParameter("@PORT_ORIGIN", PORT_ORIGIN);
            param[9] = new SqlParameter("@PORT_SHIPMENT", PORT_SHIPMENT);

            param[10] = new SqlParameter("@Branch_Old", BRANCH_CODE);
            param[11] = new SqlParameter("@Branch_New", Connection.Get_Company_Type());
            param[12] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[13] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());

            param[14] = new SqlParameter("@flag", Ename);
            param[15] = new SqlParameter("@DB_Name", DBS_Name);


            param[23] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[23].Direction = ParameterDirection.Output;
            param[24] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[24].Direction = ParameterDirection.Output;

           Connection.Get_Dataset(Sp_name, param);
           result = Convert.ToInt32(param[23].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }
    public int Job_Copy_Wrk()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[1] = new SqlParameter("@OLD_JOBNO", OLD_JOBNO);
            param[2] = new SqlParameter("@CURRENT_JOBNO", JOBNO);
            param[3] = new SqlParameter("@Cus_Code", CUSTOMS_HOUSE);
            param[4] = new SqlParameter("@Tr_Mode",  To_Tr_Mode);
            param[5] = new SqlParameter("@PORT_ORIGIN", PORT_ORIGIN);
            param[6] = new SqlParameter("@PORT_SHIPMENT", PORT_SHIPMENT);
            param[7] = new SqlParameter("@BRANCHCODE",Connection.Get_Company_Type());
            param[8] = new SqlParameter("@Selected_Branch", BRANCH_CODE);
            param[9] = new SqlParameter("@USERID", Connection.Current_User());
            param[10] = new SqlParameter("@DB_Name", DBS_Name);
            param[11] = new SqlParameter("@Current_Working_Period", Connection.WorkingPeriod());

            param[23] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[23].Direction = ParameterDirection.Output;
            param[24] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[24].Direction = ParameterDirection.Output;

            Connection.Get_Dataset(Sp_name, param);
            result = Convert.ToInt32(param[23].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }
    public int Job_Transfer()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[1] = new SqlParameter("@OLD_JOBNO", OLD_JOBNO);
            param[2] = new SqlParameter("@CURRENT_JOBNO", JOBNO);
            param[3] = new SqlParameter("@Selected_Branch", BRANCH_CODE);
            param[4] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);
            param[5] = new SqlParameter("@To_Tr_Mode", To_Tr_Mode);

            param[6] = new SqlParameter("@JOBNO_PS", JOBNO_PS);
            param[7] = new SqlParameter("@JOB_PREFIX", JOB_PREFIX);
            param[8] = new SqlParameter("@JOB_SUFFIX", JOB_SUFFIX);

            param[9] = new SqlParameter("@PORT_ORIGIN", PORT_ORIGIN);
            param[10] = new SqlParameter("@PORT_SHIPMENT", PORT_SHIPMENT);

            param[15] = new SqlParameter("@BRANCHCODE", Connection.Get_Company_Type());
            param[16] = new SqlParameter("@USERID", Connection.Current_User());
            param[17] = new SqlParameter("@Ename", Ename);
            
            param[18] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;
            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;

            Connection.Get_Dataset(Sp_name, param);
            result = Convert.ToInt32(param[18].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }
}