using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Net;


public class Svb_Relation
{
    public int result = 0, UPDATE_ID = 0;
    ErrorLogs er = new ErrorLogs();

    DataSet ds = new DataSet();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);


    private string _SVB_ID_N;
    private string _IMP_NAME;
    private string _SUPPLIER_NAME;
    private string _RELATION;
    private string _BASE;
    private string _CONDITION;
    private string _SVB_RELATION;
    private string _SVB_REF_NO;
    private string _SVB_REF_DATE;
    private string _SVB_CUSTOM_HOUSE;
    private string _SVB_LOADING_ON;
    private string _SVB_ASSESABLE_RATE;
    private string _SVB_DUTY_RATE;
    private string _SVB_ASSESABLE_STATUS;
    private string _SVB_DUTY_STATUS;
    private string _USER_ID;
    
    private string _BRANCH_CODE;
    private string _WORKING_PERIOD;
    private string _flag;
    
    private string _BOND_NO;
    private string _BOND_LOCATION;
    private string _BOND_TYPE;
    private string _SVB_APPLICABLE_ALL_SUPP;


    public string SVB_ID_N { get { return _SVB_ID_N; } set { _SVB_ID_N = value; } }

    public string IMP_NAME { get { return _IMP_NAME; } set { _IMP_NAME = value; } }
    public string SUPPLIER_NAME { get { return _SUPPLIER_NAME; } set { _SUPPLIER_NAME = value; } }
    public string RELATION { get { return _RELATION; } set { _RELATION = value; } }
    public string BASE { get { return _BASE; } set { _BASE = value; } }
    public string CONDITION { get { return _CONDITION; } set { _CONDITION = value; } }
    public string SVB_RELATION { get { return _SVB_RELATION; } set { _SVB_RELATION = value; } }
    public string SVB_REF_NO { get { return _SVB_REF_NO; } set { _SVB_REF_NO = value; } }
    public string SVB_REF_DATE { get { return _SVB_REF_DATE; } set { _SVB_REF_DATE = value; } }
    public string SVB_CUSTOM_HOUSE { get { return _SVB_CUSTOM_HOUSE; } set { _SVB_CUSTOM_HOUSE = value; } }
    public string SVB_LOADING_ON { get { return _SVB_LOADING_ON; } set { _SVB_LOADING_ON = value; } }
    public string SVB_ASSESABLE_RATE { get { return _SVB_ASSESABLE_RATE; } set { _SVB_ASSESABLE_RATE = value; } }
    public string SVB_DUTY_RATE { get { return _SVB_DUTY_RATE; } set { _SVB_DUTY_RATE = value; } }
    public string SVB_ASSESABLE_STATUS { get { return _SVB_ASSESABLE_STATUS; } set { _SVB_ASSESABLE_STATUS = value; } }
    public string SVB_DUTY_STATUS { get { return _SVB_DUTY_STATUS; } set { _SVB_DUTY_STATUS = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
   
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }

    public string BOND_NO { get { return _BOND_NO; } set { _BOND_NO = value; } }
    public string BOND_LOCATION { get { return _BOND_LOCATION; } set { _BOND_LOCATION = value; } }
    public string BOND_TYPE { get { return _BOND_TYPE; } set { _BOND_TYPE = value; } }
    public string SVB_APPLICABLE_ALL_SUPP { get { return _SVB_APPLICABLE_ALL_SUPP; } set { _SVB_APPLICABLE_ALL_SUPP = value; } }

    public string flag { get { return _flag; } set { _flag = value; } }
    
    public int SVB_Relation_Insert_update()
    {
        DataSet ds = new DataSet();
        string date = string.Empty;
        try
        {
            SqlParameter[] param = new SqlParameter[30];

            param[21] = new SqlParameter("@SVB_ID_N", SVB_ID_N);
            param[0] = new SqlParameter("@IMP_NAME", IMP_NAME);
            param[1] = new SqlParameter("@SUPPLIER_NAME", SUPPLIER_NAME);
            param[2] = new SqlParameter("@RELATION", RELATION);
            param[3] = new SqlParameter("@BASE", BASE);
            param[4] = new SqlParameter("@CONDITION", CONDITION);
            param[5] = new SqlParameter("@SVB_RELATION", SVB_RELATION);
            param[6] = new SqlParameter("@SVB_REF_NO", SVB_REF_NO);
                if(SVB_REF_DATE=="")
                {
                param[7] = new SqlParameter("@SVB_REF_DATE", null);
                }
                else
                {
                    param[7] = new SqlParameter("@SVB_REF_DATE", DateTime.Parse(SVB_REF_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
                }
            param[8] = new SqlParameter("@SVB_CUSTOM_HOUSE", SVB_CUSTOM_HOUSE);
            param[9] = new SqlParameter("@SVB_LOADING_ON", SVB_LOADING_ON);
            param[10] = new SqlParameter("@SVB_ASSESABLE_RATE", SVB_ASSESABLE_RATE);
            param[11] = new SqlParameter("@SVB_DUTY_RATE", SVB_DUTY_RATE);
            param[12] = new SqlParameter("@SVB_ASSESABLE_STATUS", SVB_ASSESABLE_STATUS);
            param[13] = new SqlParameter("@SVB_DUTY_STATUS", SVB_DUTY_STATUS);
            param[14] = new SqlParameter("@USER_ID", USER_ID);
            
            param[15] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[16] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[22] = new SqlParameter("@BOND_NO", BOND_NO);
            param[23] = new SqlParameter("@BOND_LOCATION", BOND_LOCATION);
            param[24] = new SqlParameter("@BOND_TYPE", BOND_TYPE);
            param[25] = new SqlParameter("@SVB_APPLICABLE_ALL_SUPP", SVB_APPLICABLE_ALL_SUPP);

            param[17] = new SqlParameter("@flag", flag);

            param[18] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;

            param[20] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[20].Direction = ParameterDirection.Output;

            if (Connection.COMPANYID() == "1532")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SVB_RELATION_INS_UPD_MULTIPLE_BOND", param);
            }
            else
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SVB_RELATION_INS_UPD", param);
            }

            result = Convert.ToInt32(param[18].Value.ToString());
            if (flag == "S" || flag == "S_All_Suppliers")
            {
                UPDATE_ID = Convert.ToInt32(param[20].Value.ToString());
            }

        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }

        return result;

    }

    public DataSet SVB_Select()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];
            param[21] = new SqlParameter("@SVB_ID_N", SVB_ID_N);
            param[0] = new SqlParameter("@IMP_NAME", "");
            param[1] = new SqlParameter("@SUPPLIER_NAME", "");
            param[2] = new SqlParameter("@RELATION", "");
            param[3] = new SqlParameter("@BASE", "");
            param[4] = new SqlParameter("@CONDITION", "");
            param[5] = new SqlParameter("@SVB_RELATION", "");
            param[6] = new SqlParameter("@SVB_REF_NO", "");
            param[7] = new SqlParameter("@SVB_REF_DATE", "");
            param[8] = new SqlParameter("@SVB_CUSTOM_HOUSE", "");
            param[9] = new SqlParameter("@SVB_LOADING_ON", "");
            param[10] = new SqlParameter("@SVB_ASSESABLE_RATE", "");
            param[11] = new SqlParameter("@SVB_DUTY_RATE", "");
            param[12] = new SqlParameter("@SVB_ASSESABLE_STATUS", "");
            param[13] = new SqlParameter("@SVB_DUTY_STATUS", "");
            param[14] = new SqlParameter("@USER_ID", "");


            param[22] = new SqlParameter("@BOND_NO", "");
            param[23] = new SqlParameter("@BOND_LOCATION", "");
            param[24] = new SqlParameter("@BOND_TYPE", "");
            param[25] = new SqlParameter("@SVB_APPLICABLE_ALL_SUPP", "");


            param[15] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[16] = new SqlParameter("@WORKING_PERIOD", "");
            param[17] = new SqlParameter("@flag", flag);

            param[18] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;

            param[20] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[20].Direction = ParameterDirection.Output;

            ds= SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SVB_RELATION_INS_UPD", param);
            result = Convert.ToInt32(param[18].Value.ToString());
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;

    }
}