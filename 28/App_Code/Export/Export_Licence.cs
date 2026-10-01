using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;


public class Export_Licence
{
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    SqlCommand cmd;
    int A1, A2;
   
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
    public int result, UPDATE_ID = 0;

    public string AFlag;

    private string _LICENSE_Lic,_LICENSE_IE_Lic;
    public string LICENSE_Lic { get { return _LICENSE_Lic; } set { _LICENSE_Lic = value; } }
    public string LICENSE_IE_Lic { get { return _LICENSE_IE_Lic; } set { _LICENSE_IE_Lic = value; } }
  
   
   
    # region Export_License_Details_private Attributes
    private string _JOB_NO, _LICENSE_ID, _LICENSE_IMP_EXP_ID;
    private string _INV_SL_NO;
    private string _ITEM_SL_NO;
    private string _SCHEME_CODE;
    private string _SCHEME;
    private string _LICENSE_R_SL_NO;
    private string _LICENSE_NO;
    private string _LICENSE_DATE;
    private string _LICENSE_E_SL_NO;
    private string _LICENSE_EXP_QTY;
    private string _LICENSE_EXP_UNIT;
    private string _LICENSE_IMP_ITEM_SL_NO;
    private string _LICENSE_IMP_DESC;
    private string _LICENSE_IMP_QTY;
    private string _LICENSE_IMP_UNIT;
    private string _LICENSE_IMP_TYPE;
    private string _xml_Lic;
    private string _USER_ID;
    private string _STATUS;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;
    private string _BRANCH_COMMON;
    private string _Ename;
    private string _AMENDMENT_TYPE, _AMENDMENT_STATUS, _JOBNO_PS;

                   
    #endregion
    # region Export_License_Details_public Attributes

          public string LICENSE_ID { get { return _LICENSE_ID; } set { _LICENSE_ID = value; } }
          public string LICENSE_IMP_EXP_ID { get { return _LICENSE_IMP_EXP_ID; } set { _LICENSE_IMP_EXP_ID = value; } }
          public string JOB_NO {get { return _JOB_NO; }set { _JOB_NO = value; }}
          public string INV_SL_NO {get { return _INV_SL_NO; }set { _INV_SL_NO = value; }}
          public string ITEM_SL_NO {get { return _ITEM_SL_NO; }set { _ITEM_SL_NO = value; }}
          public string SCHEME_CODE {get { return _SCHEME_CODE; }set { _SCHEME_CODE = value; }}
          public string SCHEME { get { return _SCHEME; } set { _SCHEME = value; } }
          public string LICENSE_R_SL_NO {get { return _LICENSE_R_SL_NO; }set { _LICENSE_R_SL_NO = value; }}
          public string LICENSE_NO {get { return _LICENSE_NO; }set { _LICENSE_NO = value; }}
          public string LICENSE_DATE {get { return _LICENSE_DATE; }set { _LICENSE_DATE = value; }}
          public string LICENSE_E_SL_NO {get { return _LICENSE_E_SL_NO; }set { _LICENSE_E_SL_NO = value; }}
          public string LICENSE_EXP_QTY {get { return _LICENSE_EXP_QTY; }set { _LICENSE_EXP_QTY = value; }}
          public string LICENSE_EXP_UNIT {get { return _LICENSE_EXP_UNIT; }set { _LICENSE_EXP_UNIT = value; }}
          public string LICENSE_IMP_ITEM_SL_NO {get { return _LICENSE_IMP_ITEM_SL_NO; }set { _LICENSE_IMP_ITEM_SL_NO = value; }}
          public string LICENSE_IMP_DESC {get { return _LICENSE_IMP_DESC; }set { _LICENSE_IMP_DESC = value; }}
          public string LICENSE_IMP_QTY {get { return _LICENSE_IMP_QTY; }set { _LICENSE_IMP_QTY = value; }}
          public string LICENSE_IMP_UNIT {get { return _LICENSE_IMP_UNIT; }set { _LICENSE_IMP_UNIT = value; }}
          public string LICENSE_IMP_TYPE {get { return _LICENSE_IMP_TYPE; }set { _LICENSE_IMP_TYPE = value; }}
          public string USER_ID {get { return _USER_ID; }set { _USER_ID = value; }}          
          public string STATUS {get { return _STATUS; }set { _STATUS = value; }}
          public string BRANCH_CODE {get { return _BRANCH_CODE; }set { _BRANCH_CODE = value; }}
          public string YEAR {get { return _YEAR; }set { _YEAR = value; }}
          public string WORKING_PERIOD {get { return _WORKING_PERIOD; }set { _WORKING_PERIOD = value; }}
          public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }
          public string xml_Lic { get { return _xml_Lic; } set { _xml_Lic = value; } }
          public string AMENDMENT_TYPE { get { return _AMENDMENT_TYPE; } set { _AMENDMENT_TYPE = value; } }
          public string AMENDMENT_STATUS { get { return _AMENDMENT_STATUS; } set { _AMENDMENT_STATUS = value; } }
          public string Ename { get { return _Ename; } set { _Ename = value; } }
          public string JOBNO_PS { get { return _JOBNO_PS; } set { _JOBNO_PS = value; } }

    #endregion

          public DataSet Export_License_Imp_Exp_Details_Insert_Update()
          {
              try
              {
                  SqlParameter[] param = new SqlParameter[35];

                  param[0] = new SqlParameter("@LICENSE_IMP_EXP_ID", LICENSE_IMP_EXP_ID);
                  param[1] = new SqlParameter("@JOB_NO", JOB_NO);
                  param[19] = new SqlParameter("@LICENSE_REG_SLNO", LICENSE_R_SL_NO);
                  param[2] = new SqlParameter("@LICENSE_NO", LICENSE_NO);
                  param[3] = new SqlParameter("@LICENSE_E_SL_NO", LICENSE_E_SL_NO);
                  param[4] = new SqlParameter("@LICENSE_EXP_QTY", LICENSE_EXP_QTY);
                  param[5] = new SqlParameter("@LICENSE_EXP_UNIT", LICENSE_EXP_UNIT);
                  param[6] = new SqlParameter("@LICENSE_IMP_ITEM_SL_NO", LICENSE_IMP_ITEM_SL_NO);
                  param[7] = new SqlParameter("@LICENSE_IMP_DESC", LICENSE_IMP_DESC);
                  param[8] = new SqlParameter("@LICENSE_IMP_QTY", LICENSE_IMP_QTY);
                  param[9] = new SqlParameter("@LICENSE_IMP_UNIT", LICENSE_IMP_UNIT);
                  param[10] = new SqlParameter("@LICENSE_IMP_TYPE", LICENSE_IMP_TYPE);
                
                  param[11] = new SqlParameter("@USER_ID", USER_ID);
                  param[12] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
                  param[13] = new SqlParameter("@YEAR", YEAR);
                  param[14] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
                  param[20] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

                  param[21] = new SqlParameter("@INV_SL_NO", INV_SL_NO);
                  param[22] = new SqlParameter("@ITEM_SL_NO", ITEM_SL_NO);
                  param[23] = new SqlParameter("@SCHEME", SCHEME);
                  param[24] = new SqlParameter("@AMENDMENT_TYPE", AMENDMENT_TYPE);
                  param[25] = new SqlParameter("@AMENDMENT_STATUS", AMENDMENT_STATUS);
                  param[26] = new SqlParameter("@JOBNO_PS", JOBNO_PS);

                  param[15] = new SqlParameter("@Mflag", AFlag);
                  param[16] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
                  param[16].Direction = ParameterDirection.Output;
                  param[17] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
                  param[17].Direction = ParameterDirection.Output;
                  param[18] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
                  param[18].Direction = ParameterDirection.Output;

                  ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_LICENSE_IMP_EXP_DETAILS_INSERT_UPDATE", param);
                  result = Convert.ToInt32(param[16].Value.ToString());
                  if (AFlag == "S")
                      UPDATE_ID = Convert.ToInt32(param[18].Value.ToString());
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
                 
              }
              return ds;
          }

          public DataSet Export_License_Details_Insert_Update()
          {
              try
              {
                  SqlParameter[] param = new SqlParameter[25];

                  param[0] = new SqlParameter("@LICENSE_ID", LICENSE_ID);

                  param[1] = new SqlParameter("@JOB_NO", JOB_NO);
                  param[2] = new SqlParameter("@INV_SL_NO", INV_SL_NO);
                  param[3] = new SqlParameter("@ITEM_SL_NO", ITEM_SL_NO);
                  param[4] = new SqlParameter("@SCHEME_CODE", SCHEME_CODE);
                  param[5] = new SqlParameter("@SCHEME", SCHEME);
                  param[6] = new SqlParameter("@LICENSE_R_SL_NO", LICENSE_R_SL_NO);
                  param[7] = new SqlParameter("@LICENSE_NO", LICENSE_NO);
                  param[8] = new SqlParameter("@LICENSE_DATE", DateTime.Parse(LICENSE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
                  param[9] = new SqlParameter("@USER_ID", USER_ID);
                  param[10] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
                  param[11] = new SqlParameter("@YEAR", YEAR);
                  param[12] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
                  param[13] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
                  param[18] = new SqlParameter("@JOBNO_PS", JOBNO_PS);

                  param[14] = new SqlParameter("@Mflag", AFlag);
                  param[15] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
                  param[15].Direction = ParameterDirection.Output;
                  param[16] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
                  param[16].Direction = ParameterDirection.Output;
                  param[17] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
                  param[17].Direction = ParameterDirection.Output;
                

                  ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_LICENSE_DETAILS_INSERT_UPDATE", param);
                  result = Convert.ToInt32(param[15].Value.ToString());

                  int i = 0;
                      i= Convert.ToInt32(param[15].Value.ToString());

               if (AFlag == "S" && result != 0 )
                  {
                      UPDATE_ID = Convert.ToInt32(param[17].Value.ToString());
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
              }
              return ds;
          }

          public DataSet Export_License_Details_Select()
          {
              DataSet ds = new DataSet();
              try
              {

                  SqlParameter[] param = new SqlParameter[15];

                  param[0] = new SqlParameter("@LICENSE_ID", LICENSE_ID);

                  param[1] = new SqlParameter("@JOBNO", JOB_NO);

                  param[2] = new SqlParameter("@INVOICE_SLNO", INV_SL_NO);

                  param[3] = new SqlParameter("@ITEM_SLNO", ITEM_SL_NO);

                  param[4] = new SqlParameter("@SCHEME_CODE", SCHEME_CODE);

                  param[10] = new SqlParameter("@SCHEME", SCHEME);

                  param[5] = new SqlParameter("@Working_Period", WORKING_PERIOD);
                 
                  param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
                  param[6].Direction = ParameterDirection.Output;
                  param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
                  param[7].Direction = ParameterDirection.Output;
                  param[9] = new SqlParameter("@name", Ename);

                  if (Ename == "select_con" || Ename == "GET_EXPORT_LICENSE_ID_MAX")
                  {
                      ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_LICENSE_DETAILS_SELECT", param);
                      string err = param[7].Value.ToString();

                  }
                  else if (Ename == "delete")
                  {
                      ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_LICENSE_DETAILS_SELECT", param);
                      //string err = param[5].Value.ToString();
                      //string status = param[4].Value.ToString();
                      result = Convert.ToInt32(param[6].Value.ToString());
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
                  //throw new ArgumentException(ex.Message);
              }
              return ds;
          }

          public DataSet Export_License_Imp_Exp_Details_Select()
          {
              DataSet ds = new DataSet();
              DataTable dtt = new DataTable();
              try
              {                  
                  SqlParameter[] param = new SqlParameter[10];

                  param[0] = new SqlParameter("@LICENSE_IMP_EXP_ID", LICENSE_IMP_EXP_ID);
                  param[1] = new SqlParameter("@JOBNO", JOB_NO);
                  param[2] = new SqlParameter("@LICENSE_NO", LICENSE_NO);

                  param[5] = new SqlParameter("@Working_Period", WORKING_PERIOD);
                  param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
                  param[6].Direction = ParameterDirection.Output;
                  param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
                  param[7].Direction = ParameterDirection.Output;
                  param[9] = new SqlParameter("@name", Ename);

                  if (Ename == "select_con" || Ename=="Select_License_Details_IMP_EXP")
                  {
                      ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_LICENSE_IMP_EXP_DETAILS_SELECT", param);
                      string err = param[7].Value.ToString();

                  }
                  else if (Ename == "delete")
                  {
                      ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_LICENSE_IMP_EXP_DETAILS_SELECT", param);
                      result = Convert.ToInt32(param[6].Value.ToString());
                  }
                  if (ds.Tables.Count > 0)
                  {
                      if (ds.Tables[0].Rows.Count > 0)
                      {
                      }
                      else
                          ds.Tables.Add(dtt);

                  }
                  else
                      ds.Tables.Add(dtt);

              }
              catch (Exception ex)
              {
                  ErrorLogs er = new ErrorLogs();
                  er.makeLog(ex.Message);
              }
              return ds;
          }

          public DataSet Export_License_Master_Select()
          {
              DataSet ds = new DataSet();
              try
              {
                  SqlParameter[] param = new SqlParameter[16];
                  param[1] = new SqlParameter("@EXP_JOBNO", Connection.EXP_Jobno());
                  param[2] = new SqlParameter("@EXP_JOBNO_PS", Connection.EXP_Jobno());
                  param[3] = new SqlParameter("@LICENSE_NO", LICENSE_NO);
                  param[4] = new SqlParameter("@xmlString_Lic", LICENSE_Lic);
                  param[5] = new SqlParameter("@xmlString_IE_Lic", LICENSE_IE_Lic);

                  param[10] = new SqlParameter("@USER_NAME", Connection.Current_User());
                  param[11] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
                  param[12] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
                  param[13] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());

                  param[14] = new SqlParameter("@name", Ename);
                  param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
                  param[15].Direction = ParameterDirection.Output;
                  ds = Connection.Get_Dataset("EXPORT_LICENSE_MASTER_SELECT", param);
              }
              catch (Exception ex)
              {
                  Connection.Error_Msg(ex.Message);
              }
              return ds;
          }


          public DataSet Export_License_Details_PopUp_Insert()
          {

              try
              {
                  SqlParameter[] param = new SqlParameter[35];


                  param[1] = new SqlParameter("@JOB_NO", JOB_NO);

                  param[2] = new SqlParameter("@USER_ID", USER_ID);
                  param[3] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
                  param[4] = new SqlParameter("@YEAR", YEAR);
                  param[5] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

                  param[6] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

                  param[7] = new SqlParameter("@INV_SL_NO", INV_SL_NO);
                  param[8] = new SqlParameter("@ITEM_SL_NO", ITEM_SL_NO);
                  param[9] = new SqlParameter("@SCHEME", SCHEME);
                  param[13] = new SqlParameter("@SCHEME_CODE", SCHEME_CODE);
                  param[12] = new SqlParameter("@Xml_Lic", xml_Lic);
                  param[10] = new SqlParameter("@Mflag", AFlag);
                  param[11] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
                  param[11].Direction = ParameterDirection.Output;


                  ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_LICENSE_DETAILS_POPUP_BULK_INSERT", param);
              }
              catch (Exception ex)
              {

              }
              return ds;
          }
}