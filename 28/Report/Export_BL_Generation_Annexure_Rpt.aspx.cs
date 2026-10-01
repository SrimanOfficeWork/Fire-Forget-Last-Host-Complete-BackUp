

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Text;
using System.IO;
using System.Linq;

using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Microsoft.ApplicationBlocks.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Text;
using System.Drawing.Design;


using System.Data;

public partial class Export_BL_Generation_Annexure_Rpt : System.Web.UI.Page
{
    public string currentuser, ddlJobNo, SB_NO;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public string orig_dest;
    public string Marks,Desc;

    DataSet ds = new DataSet();
    AppSession aps = new AppSession();
    EXP_BL_Generation BL_gen = new EXP_BL_Generation();

    public int ii;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        LoginDate = HttpContext.Current.Session["LoginDate"].ToString();
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
        if (!IsPostBack)
        {
            try
            {

                if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
                {

                }
                else
                {
                    string Get_Type = Request.QueryString["Type"].ToString();
                  
                    List<ReportParameter> paramList = new List<ReportParameter>();
                    this.ReportViewer1.LocalReport.SetParameters(paramList);
                    ReportViewer1.LocalReport.DataSources.Clear();

                    EXP_BL_Generation BL = new EXP_BL_Generation();

                    BL.JOBNO = Request.QueryString["jobno"].ToString();
                    BL.BRANCHCODE = SELECT_BRANCH;
                    BL.REPORT_TYPE = Get_Type;
                    //ds = BL.BL_Rpt();

                    BL.Ename = "Select_BL_Annexure";
                    ds = BL.BL_Container_Select_All();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Marks = ds.Tables[0].Rows[0]["MARKS_NOS"].ToString();
                        Desc = ds.Tables[0].Rows[0]["GOODS_DESCRIPTION"].ToString();
 
                    }

                    ReportParameter param_m = new ReportParameter("Marks_nos", Marks);
                    ReportParameter param_d = new ReportParameter("Description", Marks);


                    ReportDataSource datasource = new ReportDataSource("EXPORT_BL_ANNEXURE_DataSet", ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Add(datasource);               

                    ReportViewer1.LocalReport.DisplayName = "BLGeneration_ANNEXURE";

                    ReportParameter[] p = { param_m, param_d };
                    ReportViewer1.LocalReport.SetParameters(p);

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
                }

            }
            catch (Exception ex)
            {
                ErrorLogs er = new ErrorLogs();

                er.makeLog
                    (ex.Message);
            }
        }
    }

    

}