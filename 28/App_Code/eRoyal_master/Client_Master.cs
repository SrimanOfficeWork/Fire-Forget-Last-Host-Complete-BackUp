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

using System.IO;

/// <summary>
/// Summary description for ClientMaster
/// </summary>
public class Client_Master
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
    public int result = 0;

    #region private Attributes

    private string _IMP_EXP_ID;
    private string _IMP_EXP_NAME;
    private string _IMP_EXP_IECNO;
    private string _IMP_EXP_BRSLNO;
    private string _IMP_EXP_TYPE;
    private string _IMP_EXP_ADD1;
    private string _IMP_EXP_ADD2;
    private string _IMP_EXP_ADD3;
    private string _IMP_EXP_ADD4;
    private string _IMP_EXP_PIN_CODE;
    private string _IMP_EXP_CONTACT_PERSON;
    private string _IMP_EXP_PHONE;
    private string _IMP_EXP_FAX;
    private string _IMP_EXP_EMAIL;
    private string _IMP_EXP_BINNO;
    private string _IMP_EXP_REMARKS;

    private string _flag;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _EWorking_Period;


    private string _Eimp_exp_id;
    private string _Eimp_exp_iecno;
    private string _Eimp_exp_brslno;
    private string _Eimp_exp_name;
    private string _Ename;

    #endregion

    #region Insert,Update Attributes

    public string IMP_EXP_ID { get { return _IMP_EXP_ID; } set { _IMP_EXP_ID = value; } }
    public string IMP_EXP_NAME { get { return _IMP_EXP_NAME; } set { _IMP_EXP_NAME = value; } }
    public string IMP_EXP_IECNO { get { return _IMP_EXP_IECNO; } set { _IMP_EXP_IECNO = value; } }
    public string IMP_EXP_BRSLNO { get { return _IMP_EXP_BRSLNO; } set { _IMP_EXP_BRSLNO = value; } }
    public string IMP_EXP_TYPE { get { return _IMP_EXP_TYPE; } set { _IMP_EXP_TYPE = value; } }
    public string IMP_EXP_ADD1 { get { return _IMP_EXP_ADD1; } set { _IMP_EXP_ADD1 = value; } }
    public string IMP_EXP_ADD2 { get { return _IMP_EXP_ADD2; } set { _IMP_EXP_ADD2 = value; } }
    public string IMP_EXP_ADD3 { get { return _IMP_EXP_ADD3; } set { _IMP_EXP_ADD3 = value; } }
    public string IMP_EXP_ADD4 { get { return _IMP_EXP_ADD4; } set { _IMP_EXP_ADD4 = value; } }
    public string IMP_EXP_PIN_CODE { get { return _IMP_EXP_PIN_CODE; } set { _IMP_EXP_PIN_CODE = value; } }
    public string IMP_EXP_CONTACT_PERSON { get { return _IMP_EXP_CONTACT_PERSON; } set { _IMP_EXP_CONTACT_PERSON = value; } }
    public string IMP_EXP_PHONE { get { return _IMP_EXP_PHONE; } set { _IMP_EXP_PHONE = value; } }
    public string IMP_EXP_FAX { get { return _IMP_EXP_FAX; } set { _IMP_EXP_FAX = value; } }
    public string IMP_EXP_EMAIL { get { return _IMP_EXP_EMAIL; } set { _IMP_EXP_EMAIL = value; } }
    public string IMP_EXP_BINNO { get { return _IMP_EXP_BINNO; } set { _IMP_EXP_BINNO = value; } }
    public string IMP_EXP_REMARKS { get { return _IMP_EXP_REMARKS; } set { _IMP_EXP_REMARKS = value; } }

    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string EWorking_Period { get { return _EWorking_Period; } set { _EWorking_Period = value; } }

    #endregion


    #region Retrieve Attributes

    public string Eimp_exp_id { get { return _Eimp_exp_id; } set { _Eimp_exp_id = value; } }
    public string Eimp_exp_iecno { get { return _Eimp_exp_iecno; } set { _Eimp_exp_iecno = value; } }
    public string Eimp_exp_brslno { get { return _Eimp_exp_brslno; } set { _Eimp_exp_brslno = value; } }
    public string Eimp_exp_name { get { return _Eimp_exp_name; } set { _Eimp_exp_name = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }

    #endregion

    #region Insert & Update
    public int Imp_Exp_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[25];

            param[0] = new SqlParameter("@IMP_EXP_ID", IMP_EXP_ID);
            param[1] = new SqlParameter("@IMP_EXP_NAME", IMP_EXP_NAME);

            param[2] = new SqlParameter("@IMP_EXP_IECNO", IMP_EXP_IECNO);
            param[3] = new SqlParameter("@IMP_EXP_BRSLNO", IMP_EXP_BRSLNO);
            param[4] = new SqlParameter("@IMP_EXP_TYPE", IMP_EXP_TYPE);
            param[5] = new SqlParameter("@IMP_EXP_ADD1", IMP_EXP_ADD1);
            param[6] = new SqlParameter("@IMP_EXP_ADD2", IMP_EXP_ADD2);
            param[7] = new SqlParameter("@IMP_EXP_ADD3", IMP_EXP_ADD3);
            param[8] = new SqlParameter("@IMP_EXP_ADD4", IMP_EXP_ADD4);

            param[9] = new SqlParameter("@IMP_EXP_PIN_CODE", IMP_EXP_PIN_CODE);
            param[10] = new SqlParameter("@IMP_EXP_CONTACT_PERSON", IMP_EXP_CONTACT_PERSON);
            param[11] = new SqlParameter("@IMP_EXP_PHONE", IMP_EXP_PHONE);
            param[12] = new SqlParameter("@IMP_EXP_EMAIL", IMP_EXP_EMAIL);
            param[13] = new SqlParameter("@IMP_EXP_BINNO", IMP_EXP_BINNO);
            param[14] = new SqlParameter("@IMP_EXP_REMARKS", IMP_EXP_REMARKS);
            param[15] = new SqlParameter("@IMP_EXP_USER_ID", USER_ID);
            param[16] = new SqlParameter("@IMP_EXP_BRANCH_CODE", BRANCH_CODE);
            param[17] = new SqlParameter("@IMP_EXP_YEAR", YEAR);
            param[18] = new SqlParameter("@IMP_EXP_WORKING_PERIOD", EWorking_Period);
            param[22] = new SqlParameter("@IMP_EXP_FAX", IMP_EXP_FAX);
            param[19] = new SqlParameter("@Mflag", flag);



            param[20] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[20].Direction = ParameterDirection.Output;

            param[21] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[21].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_EXP_MASTER_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[20].Value.ToString());



        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }


        return result;

    }
    #endregion

    public DataSet RetrieveAll_Imp_exp_master()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@IMP_EXP_ID", Eimp_exp_id);
            param[1] = new SqlParameter("@Working_Period", EWorking_Period);

            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@IMP_EXP_IECNO", Eimp_exp_iecno);
            param[4] = new SqlParameter("@IMP_EXP_BRSLNO", Eimp_exp_brslno);
            param[5] = new SqlParameter("@IMP_EXP_NAME", Eimp_exp_name);


            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[6].Direction = ParameterDirection.Output;

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@startRowIndex", startRowIndex);

            param[9] = new SqlParameter("@maximumRows", maximumRows);

            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_EXP_MASTER", param);
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_EXP_MASTER_SEARCH_SELECT", param);

                result = Convert.ToInt32(param[6].Value.ToString());


            }
            else if (Ename == "autoid")
            {
                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_EXP_MASTER", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_EXP_MASTER_SEARCH_SELECT", param);

                result = Convert.ToInt32(param[6].Value.ToString());
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

            else
            {
                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_EXP_MASTER", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_EXP_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[10].Value.ToString());

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

    public void Open_CHA_CLIENT_LIST_TO_EXCEL()
    {
        //Billing_UserBO objUserBL = new Billing_UserBO();
        eroyalmaster erm = new eroyalmaster();
        HttpResponse Response = HttpContext.Current.Response;
        DataSet dss = new DataSet();
        string Filename = "";

        erm.Eimp_exp_id = "";
        erm.Eimp_exp_name = "";
        erm.Eimp_exp_iecno = "";
        erm.Eimp_exp_brslno = "";
        erm.Ename = "select_ADcode_STD_Search";
        //erm.EWorking_Period = EWorking_Period;//Working_Period;
        erm.EWorking_Period = Connection.WorkingPeriod();
        erm.STANDARD_TYPE = "";
        //erm.startRowIndex = Convert.ToString(currentPageNumber1);
        //erm.maximumRows = Convert.ToString(gvdetails.PageSize);
        erm.startRowIndex = "1";
        erm.maximumRows = "1000";

        dss = erm.RetrieveAll_Imp_exp_master_STD_TYPE();

        DataTable dt = new DataTable();
        dt = dss.Tables[0];

        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss

        string strrptNametime = Filename + "_" + s;

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView gv = new GridView();
            gv.AllowPaging = false;
            gv.DataSource = dt;
            gv.DataBind();

            if (gv.Rows.Count > 0)
            {
                foreach (TableCell cell in gv.HeaderRow.Cells)
                {
                    cell.BackColor = gv.HeaderStyle.BackColor;
                }
                for (int i = 0; i < gv.HeaderRow.Cells.Count; i++)
                {
                    gv.HeaderRow.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#D8D8D8");
                }
                gv.RenderControl(hw);
            }
            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
}