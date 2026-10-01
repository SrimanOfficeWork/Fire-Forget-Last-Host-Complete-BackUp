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

/// <summary>
/// Summary description for Goods_Reg_EOU
/// </summary>
public class Goods_Reg_EOU
{
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    SqlCommand cmd;
    int A1, A2;
    //SqlConnection con = new SqlConnection();
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
    public int result;

    # region Private Attributes

    private string _GOODS_EOU_ID;
    private string _GOODS_EOU_JOBNO;
    private string _GOODS_EOU_EXAM_DATE;
    private string _GOODS_EOU_EXAM_OFFICER;
    private string _GOODS_EOU_EXAM_DESIGN;
    private string _GOODS_EOU_SUPER_NAME;
    private string _GOODS_EOU_SUPER_DESIGN;
    private string _GOODS_EOU_COMMISSION_RATE;
    private string _GOODS_EOU_DIVISION;
    private string _GOODS_EOU_DRAWN;
    private string _GOODS_EOU_RANGE;
    private string _GOODS_EOU_SEAL_NO;
    private string _GOODS_EOU_DECLARED_VALUE_VERI;
  
    private string _flag;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;
    private string _BRANCH_COMMON;

    private string _Ename;

    private string _startRowIndex;

    private string _maximumRows;
    private string _totalRows;

    #endregion

    # region Public Attributes

    public string GOODS_EOU_ID { get { return _GOODS_EOU_ID; } set { _GOODS_EOU_ID = value; } }
    public string GOODS_EOU_JOBNO { get { return _GOODS_EOU_JOBNO; } set { _GOODS_EOU_JOBNO = value; } }
    public string GOODS_EOU_EXAM_DATE { get { return _GOODS_EOU_EXAM_DATE; } set { _GOODS_EOU_EXAM_DATE = value; } }
    public string GOODS_EOU_EXAM_OFFICER { get { return _GOODS_EOU_EXAM_OFFICER; } set { _GOODS_EOU_EXAM_OFFICER = value; } }
    public string GOODS_EOU_EXAM_DESIGN { get { return _GOODS_EOU_EXAM_DESIGN; } set { _GOODS_EOU_EXAM_DESIGN = value; } }
    public string GOODS_EOU_SUPER_NAME { get { return _GOODS_EOU_SUPER_NAME; } set { _GOODS_EOU_SUPER_NAME = value; } }
    public string GOODS_EOU_SUPER_DESIGN { get { return _GOODS_EOU_SUPER_DESIGN; } set { _GOODS_EOU_SUPER_DESIGN = value; } }
    public string GOODS_EOU_COMMISSION_RATE { get { return _GOODS_EOU_COMMISSION_RATE; } set { _GOODS_EOU_COMMISSION_RATE = value; } }
    public string GOODS_EOU_DIVISION { get { return _GOODS_EOU_DIVISION; } set { _GOODS_EOU_DIVISION = value; } }
    public string GOODS_EOU_DRAWN { get { return _GOODS_EOU_DRAWN; } set { _GOODS_EOU_DRAWN = value; } }
    public string GOODS_EOU_RANGE { get { return _GOODS_EOU_RANGE; } set { _GOODS_EOU_RANGE = value; } }
    public string GOODS_EOU_SEAL_NO { get { return _GOODS_EOU_SEAL_NO; } set { _GOODS_EOU_SEAL_NO = value; } }
    public string GOODS_EOU_DECLARED_VALUE_VERI { get { return _GOODS_EOU_DECLARED_VALUE_VERI; } set { _GOODS_EOU_DECLARED_VALUE_VERI = value; } }
  
    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }

    
    public string Ename { get { return _Ename; } set { _Ename = value; } }

    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }

    #endregion


    #region Insert & Update

    public int Goods_Reg_EOU_details_insertupdate()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[50];

            // param[0] = new SqlParameter("@GOODS_EOU_ID", GOODS_EOU_ID);

            param[1] = new SqlParameter("@GOODS_EOU_JOBNO", GOODS_EOU_JOBNO);

            param[2] = new SqlParameter("@GOODS_EOU_EXAM_DATE", DateTime.Parse(GOODS_EOU_EXAM_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[3] = new SqlParameter("@GOODS_EOU_EXAM_OFFICER", GOODS_EOU_EXAM_OFFICER);

            param[4] = new SqlParameter("@GOODS_EOU_EXAM_DESIGN", GOODS_EOU_EXAM_DESIGN);

            param[5] = new SqlParameter("@GOODS_EOU_SUPER_NAME", GOODS_EOU_SUPER_NAME);

            param[6] = new SqlParameter("@GOODS_EOU_SUPER_DESIGN", GOODS_EOU_SUPER_DESIGN);

            param[7] = new SqlParameter("@GOODS_EOU_COMMISSION_RATE", GOODS_EOU_COMMISSION_RATE);

            param[8] = new SqlParameter("@GOODS_EOU_DIVISION", GOODS_EOU_DIVISION);

            param[9] = new SqlParameter("@GOODS_EOU_DRAWN", GOODS_EOU_DRAWN);

            param[10] = new SqlParameter("@GOODS_EOU_RANGE", GOODS_EOU_RANGE);

            param[11] = new SqlParameter("@GOODS_EOU_SEAL_NO", GOODS_EOU_SEAL_NO);

            param[12] = new SqlParameter("@GOODS_EOU_DECLARED_VALUE_VERI", GOODS_EOU_DECLARED_VALUE_VERI);
           
            param[13] = new SqlParameter("@USER_ID", USER_ID);

            param[14] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);

            param[15] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[20] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[16] = new SqlParameter("@YEAR", YEAR);

            param[17] = new SqlParameter("@Mflag", flag);

            param[18] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[18].Direction = ParameterDirection.Output;

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);

            param[19].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_GOODS_REG_EOU_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[18].Value.ToString());
            string err = param[19].Value.ToString();

        }
        catch (Exception ex)
        {

            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return result;
    }

    #endregion

    public DataSet RetrieveAll_Annexure_Details()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[10];

            //param[0] = new SqlParameter("@ANNEX_ID", ANNEX_ID);

            param[1] = new SqlParameter("@GOODS_EOU_JOBNO", GOODS_EOU_JOBNO);

            param[2] = new SqlParameter("@name", Ename);

            param[3] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);


            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;


            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH", param);
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_GOODS_EOU_DETAILS", param);

                result = Convert.ToInt32(param[4].Value.ToString());


            }
            else if (Ename == "select")
            {

                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_GOODS_EOU_DETAILS", param);

                string err = param[5].Value.ToString();
                //result = Convert.ToInt32(param[11].Value.ToString());
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
                //string err = param[8].Value.ToString();
            }


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