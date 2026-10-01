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
/// Summary description for Report_Client_Master
/// </summary>
public class Rpt_Client_Master
{

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();
    SqlDataReader dr;
    SqlCommand cmd;
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

    public int result = 0, UPDATE_ID = 0;
    private string _RPT_ID;
    private string _CLIENT_NAME;
    private string _CLIENT_BRSLNO;
    private string _CLIENT_ADD1;
    private string _CLIENT_ADD2;
    private string _CLIENT_ADD3;
    private string _CLIENT_ADD4;
    private string _CLIENT_COUNTRY_NAME;
    private string _CLIENT_PINCODE;
    private string _CLIENT_PHONE;
    private string _CLIENT_eMAIL;
    private string _OCEANVESSEL;
    private string _CLIENT_TYPE;
    private string _CLIENT_REMARKS;
    private string _CLIENT_USER_ID;
    private string _CLIENT_DATE_TIME;
    private string _CLIENT_STATUS;
    private string _CLIENT_BRANCH_CODE;
    private string _CLIENT_WORKING_PERIOD;
    private string _CLIENT_GSTN_NO;


    private string _flag, _Ename;
    private string _startRowIndex;
    private string _maximumRows;
    private string _totalRows;
  
    public string RPT_ID { get { return _RPT_ID; } set { _RPT_ID = value; } }
    public string CLIENT_NAME { get { return _CLIENT_NAME; } set { _CLIENT_NAME = value; } }
    public string CLIENT_BRSLNO { get { return _CLIENT_BRSLNO; } set { _CLIENT_BRSLNO = value; } }

    public string CLIENT_ADD1 { get { return _CLIENT_ADD1; } set { _CLIENT_ADD1 = value; } }
    public string CLIENT_ADD2 { get { return _CLIENT_ADD2; } set { _CLIENT_ADD2 = value; } }
    public string CLIENT_ADD3 { get { return _CLIENT_ADD3; } set { _CLIENT_ADD3 = value; } }
    public string CLIENT_ADD4 { get { return _CLIENT_ADD4; } set { _CLIENT_ADD4 = value; } }
    public string CLIENT_COUNTRY_NAME { get { return _CLIENT_COUNTRY_NAME; } set { _CLIENT_COUNTRY_NAME = value; } }
    public string CLIENT_PINCODE { get { return _CLIENT_PINCODE; } set { _CLIENT_PINCODE = value; } }
    public string CLIENT_PHONE { get { return _CLIENT_PHONE; } set { _CLIENT_PHONE = value; } }
    public string CLIENT_eMAIL { get { return _CLIENT_eMAIL; } set { _CLIENT_eMAIL = value; } }
    public string OCEANVESSEL { get { return _OCEANVESSEL; } set { _OCEANVESSEL = value; } }
    public string CLIENT_TYPE { get { return _CLIENT_TYPE; } set { _CLIENT_TYPE = value; } }
    public string CLIENT_REMARKS { get { return _CLIENT_REMARKS; } set { _CLIENT_REMARKS = value; } }
    public string CLIENT_USER_ID { get { return _CLIENT_USER_ID; } set { _CLIENT_USER_ID = value; } }
    public string CLIENT_DATE_TIME { get { return _CLIENT_DATE_TIME; } set { _CLIENT_DATE_TIME = value; } }
    public string CLIENT_STATUS { get { return _CLIENT_STATUS; } set { _CLIENT_STATUS = value; } }
    public string CLIENT_BRANCH_CODE { get { return _CLIENT_BRANCH_CODE; } set { _CLIENT_BRANCH_CODE = value; } }
    public string CLIENT_WORKING_PERIOD { get { return _CLIENT_WORKING_PERIOD; } set { _CLIENT_WORKING_PERIOD = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string CLIENT_GSTN_NO { get { return _CLIENT_GSTN_NO; } set { _CLIENT_GSTN_NO = value; } }


    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }

    public Rpt_Client_Master()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int Report_Client_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@RPT_ID", RPT_ID);
            param[1] = new SqlParameter("@CLIENT_NAME", CLIENT_NAME);
            param[2] = new SqlParameter("@CLIENT_BRSLNO", CLIENT_BRSLNO);
            param[3] = new SqlParameter("@CLIENT_ADD1", CLIENT_ADD1);
            param[4] = new SqlParameter("@CLIENT_ADD2", CLIENT_ADD2);
            param[5] = new SqlParameter("@CLIENT_ADD3", CLIENT_ADD3);
            param[6] = new SqlParameter("@CLIENT_ADD4", CLIENT_ADD4);
            param[7] = new SqlParameter("@CLIENT_COUNTRY_NAME", CLIENT_COUNTRY_NAME);
            param[8] = new SqlParameter("@CLIENT_PINCODE", CLIENT_PINCODE);
            param[9] = new SqlParameter("@CLIENT_TYPE", CLIENT_TYPE);
            param[10] = new SqlParameter("@CLIENT_REMARKS", CLIENT_REMARKS);
            param[11] = new SqlParameter("@CLIENT_USER_ID", CLIENT_USER_ID);
            //param[12] = new SqlParameter("@CLIENT_DATE_TIME", CLIENT_DATE_TIME);
            //param[13] = new SqlParameter("@CLIENT_STATUS", CLIENT_STATUS);
            param[14] = new SqlParameter("@CLIENT_BRANCH_CODE", CLIENT_BRANCH_CODE);
            param[15] = new SqlParameter("@CLIENT_WORKING_PERIOD", CLIENT_WORKING_PERIOD);
          
            param[16] = new SqlParameter("@Mflag", flag);

            param[17] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[17].Direction = ParameterDirection.Output;
            param[18] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[18].Direction = ParameterDirection.Output;
            param[19] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[19].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_REPORT_CLIENT_MASTER_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[17].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[19].Value.ToString());

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

      return result;

    }


    public DataSet RetrieveAll_Rpt_Client_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@RPT_ID", RPT_ID);
            param[1] = new SqlParameter("@CLIENT_NAME", CLIENT_NAME);

            param[2] = new SqlParameter("@TYPE", CLIENT_TYPE);
            param[3] = new SqlParameter("@BRANCH", CLIENT_BRANCH_CODE);

            param[4] = new SqlParameter("@name", Ename);
            param[5] = new SqlParameter("@WORKING_PERIOD", CLIENT_WORKING_PERIOD);

            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@startRowIndex", startRowIndex);

            param[9] = new SqlParameter("@maximumRows", maximumRows);

            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            //param[6] = new SqlParameter("@Mflag", flag);

            if (Ename == "Bind_All_Rrt_Client_Details" || Ename == "BindAll_Report_Client" || Ename == "Bind_Report_ClientName_Type" || Ename=="Bind_Agent_Vessel_Report" || Ename=="Bind_All_Rrt_Agent_Vessel_Details" || Ename=="Bind_Gridview_Details" || Ename=="Bind_Gridview_Details_AGENT")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_REPORT_CLIENT_MASTER_SELECT", param);
                string err = param[5].Value.ToString();
                result = Convert.ToInt32(param[6].Value.ToString());

            }
            else if (Ename == "select_con" || Ename=="select_con_Rpt_AgentVessel")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_REPORT_CLIENT_MASTER_SELECT", param);
                //string err = param[5].Value.ToString();
                result = Convert.ToInt32(param[10].Value.ToString());
            }
            else if (Ename == "delete" || Ename == "delete_Rrt_Agent_Vessel")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_REPORT_CLIENT_MASTER_SELECT", param);
                result = Convert.ToInt32(param[6].Value.ToString());
            }
            else if (Ename == "Check_Consignee_Name" || Ename=="Check_OceanVessel")
            {
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_REPORT_CLIENT_MASTER_SELECT", param);
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

    #region Agent_VesselMaster_Start

    public int Report_Agent_Vessel_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@RPT_ID", RPT_ID);
            param[1] = new SqlParameter("@AGENT_NAME", CLIENT_NAME);
            param[2] = new SqlParameter("@AGENT_BRSLNO", CLIENT_BRSLNO);
            param[3] = new SqlParameter("@AGENT_ADD1", CLIENT_ADD1);
            param[4] = new SqlParameter("@AGENT_ADD2", CLIENT_ADD2);
            param[5] = new SqlParameter("@AGENT_ADD3", CLIENT_ADD3);
            param[6] = new SqlParameter("@AGENT_ADD4", CLIENT_ADD4);
            param[7] = new SqlParameter("@AGENT_COUNTRY_NAME", CLIENT_COUNTRY_NAME);
            param[8] = new SqlParameter("@AGENT_PINCODE", CLIENT_PINCODE);
            param[20] = new SqlParameter("@AGENT_PHONE", CLIENT_PHONE);
            param[21] = new SqlParameter("@AGENT_EMAIL", CLIENT_eMAIL);
            param[22] = new SqlParameter("@OCEANVESSEL", OCEANVESSEL);
            param[9] = new SqlParameter("@AGENT_TYPE", CLIENT_TYPE);
            param[10] = new SqlParameter("@AGENT_REMARKS", CLIENT_REMARKS);
            param[11] = new SqlParameter("@AGENT_USER_ID", CLIENT_USER_ID);
            //param[12] = new SqlParameter("@CLIENT_DATE_TIME", CLIENT_DATE_TIME);
            //param[13] = new SqlParameter("@CLIENT_STATUS", CLIENT_STATUS);
            param[14] = new SqlParameter("@AGENT_BRANCH_CODE", CLIENT_BRANCH_CODE);
            param[15] = new SqlParameter("@AGENT_WORKING_PERIOD", CLIENT_WORKING_PERIOD);
            param[23] = new SqlParameter("@AGENT_GSTN_NO", CLIENT_GSTN_NO);

            param[16] = new SqlParameter("@Mflag", flag);

            param[17] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[17].Direction = ParameterDirection.Output;
            param[18] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[18].Direction = ParameterDirection.Output;
            param[19] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[19].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_REPORT_AGENT_VESSEL_MASTER_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[17].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[19].Value.ToString());

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        return result;

    }

    #endregion

}