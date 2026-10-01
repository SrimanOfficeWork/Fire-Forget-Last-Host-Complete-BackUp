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


/// <summary>
/// Summary description for Login
/// </summary>
public class Login
{
    ErrorLogs er = new ErrorLogs();
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();

    DataTable dt = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    SqlCommand cmd;
    int A1, A2;
    //SqlConnection con = new SqlConnection();
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

    #region Private_Attributes

    private string _LOGIN_ID;

    private string _COMPANY_LICENSE;
    private string _USERNAME;
    private string _PWD;
    private string _Ename;
    private string _flag;
    private string _ISLOGIN;

    #endregion

    #region Public_Attribute

    public string LOGIN_ID { get { return _LOGIN_ID; } set { _LOGIN_ID = value; } }
    public string COMPANY_LICENSE { get { return _COMPANY_LICENSE; } set { _COMPANY_LICENSE = value; } }
    public string USERNAME { get { return _USERNAME; } set { _USERNAME = value; } }
    public string PWD { get { return _PWD; } set { _PWD = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string ISLOGIN { get { return _ISLOGIN; } set { _ISLOGIN = value; } }

    public string flag { get { return _flag; } set { _flag = value; } }

    public int result = 0;
  
    #endregion
    public string usrid, passwd, COMPANY_ID, BRANCH, USER_RANDOM_ID, startdt, expdt;
    public int Result = 0;
    public DataSet Check_Login_Details()
    {

        try
        {
            
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@LOGIN_ID", LOGIN_ID);

            param[1] = new SqlParameter("@COMPANY_LICENSE", COMPANY_LICENSE);

            param[2] = new SqlParameter("@USERNAME", USERNAME);

            param[3] = new SqlParameter("@PWD", PWD);

            param[4] = new SqlParameter("@ISLOGIN", ISLOGIN);

            param[5] = new SqlParameter("@name", Ename);

            //param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);


            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;

            //param[10] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            //param[10].Direction = ParameterDirection.Output;

            if (Ename == "delete" || Ename == "S" || Ename == "U")
            {

                SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_LOGIN_MASTER_CHECKING", param);
                result = Convert.ToInt32(param[7].Value.ToString());
                //if (Ename == "S")
                    //Update_Id = Convert.ToInt32(param[10].Value.ToString());


            }
            else if (Ename == "Select_Login_Details")
            {

                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_LOGIN_MASTER_CHECKING", param);
                result = Convert.ToInt32(param[7].Value.ToString());
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

    public DataSet Check_User_Login_Details()
    {        
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@usrid", usrid);
            param[1] = new SqlParameter("@passwd", passwd);
            param[2] = new SqlParameter("@COMPANY_ID", COMPANY_ID);
            param[3] = new SqlParameter("@BRANCH", BRANCH);
            param[4] = new SqlParameter("@Mflag", flag);

            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@MRandom_Id", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@START_DT", DateTime.Parse(startdt, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[11] = new SqlParameter("@EXPIRE_DT", DateTime.Parse(expdt, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            //--------------Start Modified on 19Sep2017----------------------//
            string startdt1 = DateTime.Parse(startdt, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).ToString();
            string expdt1 = DateTime.Parse(expdt, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).ToString();

            //string startdt1 = DateTime.ParseExact(startdt, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            //string expdt1 = DateTime.ParseExact(expdt, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");

            //param[10] = new SqlParameter("@START_DT", startdt1);
            //param[11] = new SqlParameter("@EXPIRE_DT", expdt1);

            //--------------End Modified on 19Sep2017----------------------//


            if (flag == "Sign_out" || flag=="CheckOut_Random_Id")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "chkuser", param);
               if(flag == "CheckOut_Random_Id")
                   USER_RANDOM_ID = param[9].Value.ToString();

            }

            else if (flag == "Update_ISLogin_Status" || flag == "Check_Branch_Permission_User" || flag == "Check_Branch_Permission_User_New")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "chkuser", param);
            }

            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "chkuser", param);
                string err = param[8].Value.ToString();
                //-------------------------For User LogOut - ISLogin Process-------------------//
                USER_RANDOM_ID = param[9].Value.ToString();
                HttpContext.Current.Session["USER_ISLOGIN_RANDOM_ID"] = USER_RANDOM_ID;
                //-------------------------For User LogOut - ISLogin Process-------------------//

            }
            result = Convert.ToInt32(param[7].Value.ToString());
            
             
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }


    public DataSet Check_RTSElogixMapping()
    {

        try
        {

            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@MTID", LOGIN_ID);
            param[1] = new SqlParameter("@Username", usrid);
            param[2] = new SqlParameter("@CompLicense", COMPANY_LICENSE);

            param[5] = new SqlParameter("@Mode", Ename);


            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;



            if (Ename == "select_MTID" || Ename == "MTID-Fetch")  // admin impex DB 
            {

                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_MappingMaster_Select", param);


            }
            else if (Ename == "select_MapUser")  // End user DB 
            {

                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_MappingUser_Check", param);


            }


        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);

        }
        return ds;
    }

}