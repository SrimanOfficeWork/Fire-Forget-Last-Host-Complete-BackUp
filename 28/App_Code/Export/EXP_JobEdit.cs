using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class EXP_JobEdit
{
    private string _Jobno, _BRANCH_CODE, _flag, _Old_Jobno, _Current_Jobno, _UserId, _PS, _JOB_PREFIX, _JOB_SUFFIX;

    public string Jobno { get { return _Jobno; } set { _Jobno = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }
    public string PS { get { return _PS; } set { _PS = value; } } 
    public string Old_Jobno { get { return _Old_Jobno; } set { _Old_Jobno = value; } }
    public string Current_Jobno { get { return _Current_Jobno; } set { _Current_Jobno = value; } }
    public string UserId { get { return _UserId; } set { _UserId = value; } }

    public string JOB_PREFIX { get { return _JOB_PREFIX; } set { _JOB_PREFIX = value; } }
    public string JOB_SUFFIX { get { return _JOB_SUFFIX; } set { _JOB_SUFFIX = value; } }

    public int result = 0;

    public int Exp_jobedit_det()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[80];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@Branch_code", Connection.Get_Company_Type());
            param[2] = new SqlParameter("@Mflag", flag);
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("EXPORT_JOBEDIT", param);
            result = Convert.ToInt32(param[3].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
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

            Connection.Get_Dataset("EXP_JOBEDIT_UPDATE", param);
            result = Convert.ToInt32(param[5].Value.ToString());

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }

}