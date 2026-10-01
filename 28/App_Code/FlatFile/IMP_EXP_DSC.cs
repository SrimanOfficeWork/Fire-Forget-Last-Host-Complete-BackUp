using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Web;

public class IMP_EXP_DSC
{
    public int result = 0;
    ErrorLogs er = new ErrorLogs();


    private string _FILE_PATH;
    private string _IMP_EXP;
    private string _BRANCH_CODE;
    private string _BRANCH_COMMON;
    private string _USER_ID;
    private string _FLAG;

    public string FILE_PATH { get { return _FILE_PATH; } set { _FILE_PATH = value; } }
    public string IMP_EXP { get { return _IMP_EXP; } set { _IMP_EXP = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string FLAG { get { return _FLAG; } set { _FLAG = value; } }

    public DataSet DSC_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[22];

            param[0] = new SqlParameter("@FILE_PATH", FILE_PATH);
            param[1] = new SqlParameter("@IMP_EXP", IMP_EXP);
            param[2] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[3] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[4] = new SqlParameter("@USER_ID", USER_ID);
            param[5] = new SqlParameter("@FLAG", FLAG);
            

            param[10] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;

          ds= SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "DSC_IMP_EXP_CLIENT_FILE_PATH_INS_UPD", param);
            result = Convert.ToInt32(param[10].Value.ToString());

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }

    
}