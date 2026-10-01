using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Data.SqlClient;

using System.IO;
using Microsoft.ApplicationBlocks.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Web.UI.WebControls.WebParts;
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;

public partial class Export_Annexure_EOU_Report : System.Web.UI.Page
{
    eroyalmaster Imp_Exp = new eroyalmaster();
    //Export_CheckList CHKLIST = new Export_CheckList();
    Date_Time dt = new Date_Time();
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    public string currentuser, ddlJobNo;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string SELECT_TYPE, SELECT_BRANCH;
    public string LoginDate,RIGHT_SQUAREBRAKET=" ]",LEFT_SQUAREBRAKET="[ ";
    AppSession aps = new AppSession();
    public int Is_STR = 0, IS_ANNEXURE_MODE = 0;
    public string TICK_MARK = ((char)0x221A).ToString();


    public double text_Discount = 0, text_OTHER_DISCOUNT = 0, text_packing = 0;
    public string DBK_ROSL_RITC = "";
    string DBK_Chapter = "";
    int result = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();
        currentbranch = Session["currentbranch"].ToString();
        
    // commented for areawise implementation on 05-mar-2020
        /*

        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
            }
            else
            {
                SELECT_BRANCH = "";
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }
          * */
        SELECT_BRANCH = Connection.Get_Company_Type();
        if(!IsPostBack)
        {
            load_jobno();
        }

        if (!IsPostBack)
        {
            try
            {
                 /*
                if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
                {

                }
                else
                {
                    
                    Session["JobNo"] = Request.QueryString["jobno"].ToString();
                   
                    if (Request.QueryString["EXP_Anx"] == "Y")
                    {
                        Direct_Anx();
                        Response.Redirect("../Export_Annexure/Export_Annexure_Report.aspx?jobno=" + Request.QueryString["jobno"].ToString() + "&Annexure_Mode=" + Annexure_Mode + "&STR_Code=" + STR_Code + "");
                    }
                    else
                    {
                        Direct_Anx();
                        //Page_loaItem_Details();
                       // Btnrpt1_Click(sender, e);
                        //ddlrpt_type_SelectedIndexChanged(sender, e);
                    }
                     * 
                }
                    */
                Page_EOUDetails_Report();
            }
            catch (Exception ex)
            {
                ErrorLogs er = new ErrorLogs();

                er.makeLog
                    (ex.Message);
            }
        }
    }

    private void load_jobno()
    {
        ds1 = Retreive_all_Eou_Details_Report("Select_EOU_Jobno","");

        if (ds1.Tables[0].Rows.Count > 0)
        {
            ddl_Jobno.DataSource = ds1.Tables[0];
            ddl_Jobno.DataTextField = "ANNEX_JOBNO";
            ddl_Jobno.DataTextField = "ANNEX_JOBNO";
            ddl_Jobno.DataBind();
            ddl_Jobno.Items.Insert(0, "");

        }
    }


    private void Page_EOUDetails_Report()
    {

        LocalReport localReport = ReportViewer1.LocalReport;
        localReport.ReportPath = @"Report\Export_Annex_EOU_Report.rdlc";

        List<ReportParameter> paramList = new List<ReportParameter>(); this.ReportViewer1.LocalReport.SetParameters(paramList);

        ReportViewer1.LocalReport.DataSources.Clear();

        ds = Retreive_all_Eou_Details_Report("Select_EOU_Details", ddl_Jobno.SelectedItem.Text);
        if (ds.Tables[0].Rows.Count == 0)
        {

            ds.Tables[0].Rows.Add("");
        }

        ReportDataSource dataSource = new ReportDataSource("DataSet1", ds.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Add(dataSource);


        //--------------------------------------To Print------------------------------------------------------------------------------------//
        Warning[] warnings;
        string[] streamIds;
        string mimeType = string.Empty;
        string encoding = string.Empty;
        string extension = string.Empty;
        string fileName = "a";
        byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
        Session.Remove("report");
        Session["report"] = bytes;
        //--------------------------------------To Print------------------------------------------------------------------------------------//

        //}
    }


    
    protected void RDRpt_SelectedIndexChanged(object sender, EventArgs e)
    {
            //Page_loaItem_Details_General();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "Print_open();", true);     
    }
    protected void ddl_Jobno_SelectedIndexChanged(object sender, EventArgs e)
    {
        Page_EOUDetails_Report();
    }

    private DataSet Retreive_all_Eou_Details_Report(string flag, string Jobno)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", Jobno);
            param[1] = new SqlParameter("@name", flag);
            param[2] = new SqlParameter("@BranchCode", Connection.Current_Branch());
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
           
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            //param[6] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
            //param[7] = new SqlParameter("@CUSTOM_HOUSE", CUSTOM_HOUSE);

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_ANNEXURE_C1_EOU_DETAILS_RPT", param);
            result = Convert.ToInt32(param[3].Value.ToString());
            Is_STR = Convert.ToInt32(param[4].Value.ToString());
            string err = param[5].Value.ToString();


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