using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data; 


public class EXP_Quota
{

    private string _QUOTA_ID;
    private string _JOBNO;
    private string _INVOICE_SLNO;
    private string _ITEM_SLNO;
    private string _AGENCY_CODE;
    private string _AGENCY_NAME;
    private string _ALLOCATION_NO;
    private string _EXPIRY_DATE;

    private string _flag;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _WORKING_PERIOD;
    private string _BRANCH_COMMON;

    private string _Ename;
    

    public int result, Update_id;
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
   

    public string QUOTA_ID { get { return _QUOTA_ID; } set { _QUOTA_ID = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string AGENCY_CODE { get { return _AGENCY_CODE; } set { _AGENCY_CODE = value; } }
    public string AGENCY_NAME { get { return _AGENCY_NAME; } set { _AGENCY_NAME = value; } }
    public string ALLOCATION_NO { get { return _ALLOCATION_NO; } set { _ALLOCATION_NO = value; } }
    public string EXPIRY_DATE { get { return _EXPIRY_DATE; } set { _EXPIRY_DATE = value; } }

    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }

    public string Ename { get { return _Ename; } set { _Ename = value; } }
    


    public DataSet Export_Quota_details_insertupdate()
    {
        try
        {
            if (EXPIRY_DATE == null || EXPIRY_DATE == "")
            {
                EXPIRY_DATE = "01/01/1900";
            }

            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@QUOTA_ID", QUOTA_ID);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[3] = new SqlParameter("@ITEM_SL_NO", ITEM_SLNO);
            param[4] = new SqlParameter("@AGENCY_CODE", AGENCY_CODE);
            param[5] = new SqlParameter("@AGENCY_NAME", AGENCY_NAME);
            param[6] = new SqlParameter("@ALLOCATION_NO", ALLOCATION_NO);
            param[7] = new SqlParameter("@EXPIRY_DATE", DateTime.Parse(EXPIRY_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[8] = new SqlParameter("@USER_ID", USER_ID);
            param[9] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[10] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[11] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
           
            param[12] = new SqlParameter("@Mflag", flag);

            param[13] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            param[15] = new SqlParameter("@Update_id", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            param[16] = new SqlParameter("@Ename", Ename);

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXP_QUOTA_INS_UPD_SELECT", param);
            if (Ename == "Select")
            { 
            
            }
            else if (Ename == "INS_UPD")
            {
                result = Convert.ToInt32(param[13].Value.ToString());
                if (result != 2)
                {
                    Update_id = Convert.ToInt32(param[15].Value.ToString());
                }
                string err = param[14].Value.ToString();
            }
            else if (Ename == "Delete")
            {
                result =Convert.ToInt32(param[13].Value.ToString());
            }
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }
}