using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;



public class IMP_JobEdit
{
    private string _Jobno,_BRANCH_CODE,_flag,_Old_Jobno,_Current_Jobno,_UserId,_PS,_JOB_PREFIX,_JOB_SUFFIX;

    public string Jobno { get { return _Jobno; } set { _Jobno = value; } } 
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }


    public string Old_Jobno { get { return _Old_Jobno; } set { _Old_Jobno = value; } }
    public string Current_Jobno { get { return _Current_Jobno; } set { _Current_Jobno = value; } }
    public string UserId { get { return _UserId; } set { _UserId = value; } }
    public string PS { get { return _PS; } set { _PS = value; } }
    public string JOB_PREFIX { get { return _JOB_PREFIX; } set { _JOB_PREFIX = value; } }
    public string JOB_SUFFIX { get { return _JOB_SUFFIX; } set { _JOB_SUFFIX = value; } } 

    public int result = 0;
    public string SELECT_TYPE, SELECT_BRANCH;
    public string currentbranch;

    public int Imp_jobedit_det()
    {
        try
        {
            currentbranch = HttpContext.Current.Session["currentbranch"].ToString();

              // commented for areawise implementation on 05-mar-2020
        /*
            if (HttpContext.Current.Session["SELECT_TYPE"] != null)
            {
                SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();

                if (SELECT_TYPE == "Branchwise Job")
                {
                    SELECT_BRANCH = currentbranch;
                }
                else
                {
                    SELECT_BRANCH = "";
                }
            }
            else
            {
                SELECT_BRANCH = "";
            }

             * */
            SELECT_BRANCH = Connection.Get_Company_Type();
            SqlParameter[] param = new SqlParameter[80];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@Branch_code", SELECT_BRANCH);

            param[2] = new SqlParameter("@Mflag", flag);

            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;

            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_JOBEDIT", param);
            result = Convert.ToInt32(param[3].Value.ToString());
           
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return result;
    }

    public int JopUpdate()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Old_Jobno", Old_Jobno);
            param[1] = new SqlParameter("@Current_Jobno", Current_Jobno);

            param[2] = new SqlParameter("@Branch_Code", BRANCH_CODE);
            param[3] = new SqlParameter("@UserId", UserId);

            param[4] = new SqlParameter("@Mflag", flag);
            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@PS", PS);
            param[8] = new SqlParameter("@JOB_PREFIX", JOB_PREFIX);
            param[9] = new SqlParameter("@JOB_SUFFIX", JOB_SUFFIX);

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_JobEdit_update", param);
            result = Convert.ToInt32(param[5].Value.ToString());
            
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return result;
    }
}