using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;



/// <summary>
/// Summary description for Non_stand_Cur_master
/// </summary>
public class Non_stand_Cur_master
{
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet dtuser = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();
    SqlDataReader dr;
    SqlCommand cmd;
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
    private string _startRowIndex;
    private string _maximumRows;
    private string _totalRows;

    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }
    public int result = 0, UPDATE_ID=0;

    #region private Attributes

    private string _NON_STD_ID;
    private string _NON_STD_EFFECT_DT_IMP;
    private string _NON_STD_EFFECT_DT_EXP;
    private string _NON_STD_CERTIFICATE_NO;
    private string _NON_STD_CERTIFICATE_DATE;
    private string _NON_STD_CUR_CODE;
    private string _NON_STD_NAME;
    private string _NON_STD_BANKNAME;
    private string _NON_STD_RATE_IMPORT;
    private string _NON_STD_RATE_EXPORT;
    private string _NON_STD_S_OR_N;

    private string _flag;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _EWorking_Period;

    private string _NON_STD_id;
  

    private string _Ename;


    #endregion

    #region Public Attributes

    public string NON_STD_ID { get { return _NON_STD_ID; } set { _NON_STD_ID = value; } }
    public string NON_STD_EFFECT_DT_IMP { get { return _NON_STD_EFFECT_DT_IMP; } set { _NON_STD_EFFECT_DT_IMP = value; } }
    public string NON_STD_EFFECT_DT_EXP { get { return _NON_STD_EFFECT_DT_EXP; } set { _NON_STD_EFFECT_DT_EXP = value; } }
    public string NON_STD_CERTIFICATE_NO { get { return _NON_STD_CERTIFICATE_NO; } set { _NON_STD_CERTIFICATE_NO = value; } }
    public string NON_STD_CERTIFICATE_DATE { get { return _NON_STD_CERTIFICATE_DATE; } set { _NON_STD_CERTIFICATE_DATE = value; } }
    public string NON_STD_CUR_CODE { get { return _NON_STD_CUR_CODE; } set { _NON_STD_CUR_CODE = value; } }
    public string NON_STD_NAME { get { return _NON_STD_NAME; } set { _NON_STD_NAME = value; } }
    public string NON_STD_BANKNAME { get { return _NON_STD_BANKNAME; } set { _NON_STD_BANKNAME = value; } }
    public string NON_STD_RATE_IMPORT { get { return _NON_STD_RATE_IMPORT; } set { _NON_STD_RATE_IMPORT = value; } }
    public string NON_STD_RATE_EXPORT { get { return _NON_STD_RATE_EXPORT; } set { _NON_STD_RATE_EXPORT = value; } }
    public string NON_STD_S_OR_N { get { return _NON_STD_S_OR_N; } set { _NON_STD_S_OR_N = value; } }

    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string EWorking_Period { get { return _EWorking_Period; } set { _EWorking_Period = value; } }

    #endregion

    #region Retrieve Attributes

    public string NON_STD_id { get { return _NON_STD_id; } set { _NON_STD_id = value; } }
   
    public string Ename { get { return _Ename; } set { _Ename = value; } }


    #endregion

    #region Insert & Update

    public int NON_STD_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@NON_STD_ID", NON_STD_ID);
            param[1] = new SqlParameter("@NON_STD_EFFECT_DT_IMP",DateTime.Parse(NON_STD_EFFECT_DT_IMP, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[2] = new SqlParameter("@NON_STD_EFFECT_DT_EXP",DateTime.Parse(NON_STD_EFFECT_DT_EXP, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[3] = new SqlParameter("@NON_STD_CERTIFICATE_NO", NON_STD_CERTIFICATE_NO);
            param[4] = new SqlParameter("@NON_STD_CERTIFICATE_DATE", DateTime.Parse(NON_STD_CERTIFICATE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[5] = new SqlParameter("@NON_STD_CUR_CODE", NON_STD_CUR_CODE);
            param[6] = new SqlParameter("@NON_STD_NAME", NON_STD_NAME);
            param[7] = new SqlParameter("@NON_STD_BANKNAME", NON_STD_BANKNAME);
            param[8] = new SqlParameter("@NON_STD_RATE_IMPORT", NON_STD_RATE_IMPORT);
            param[9] = new SqlParameter("@NON_STD_RATE_EXPORT", NON_STD_RATE_EXPORT);
           // param[10] = new SqlParameter("@NON_STD_S_OR_N", NON_STD_S_OR_N);

            param[11] = new SqlParameter("@NON_STD_USER_ID", USER_ID);
            param[17] = new SqlParameter("@NON_STD_BRANCH_CODE", BRANCH_CODE);
            param[12] = new SqlParameter("@NON_STD_YEAR", YEAR);
            param[13] = new SqlParameter("@NON_STD_WORKING_PERIOD", EWorking_Period);
            param[14] = new SqlParameter("@Mflag", flag);



            param[15] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[15].Direction = ParameterDirection.Output;

            param[16] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[16].Direction = ParameterDirection.Output;

            param[18] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "NON_STANDARD_CUR_MASTER_INSERT_UPDATE", param);

            string ss = param[16].Value.ToString();
            result = Convert.ToInt32(param[15].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[18].Value.ToString());


        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }


        return result;

    }

    #endregion

    #region Retrieve Record

    public DataSet RetrieveAll_NON_STD_master()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@NON_STD_ID", NON_STD_ID);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);

            param[3] = new SqlParameter("@NON_STD_CUR_CODE", NON_STD_CUR_CODE);

            param[4] = new SqlParameter("@NON_STD_NAME", NON_STD_NAME);


            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@startRowIndex", startRowIndex);

            param[10] = new SqlParameter("@maximumRows", maximumRows);

            param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "NON_STANDARD_CUR_MASTER_SEARCH_SELECT", param);

                result = Convert.ToInt32(param[7].Value.ToString());


            }


            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "NON_STANDARD_CUR_MASTER_SEARCH_SELECT", param);
                string s = param[8].Value.ToString();
                result = Convert.ToInt32(param[11].Value.ToString());


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
        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }

        return ds;


    }

    #endregion
}