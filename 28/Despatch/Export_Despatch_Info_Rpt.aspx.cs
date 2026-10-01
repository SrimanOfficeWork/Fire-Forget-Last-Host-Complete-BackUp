
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

public partial class Export_Despatch_Info_Rpt : System.Web.UI.Page
{
    public string currentuser, ddlJobNo, SB_NO;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public string orig_dest;
    string Container, items, items_description, item_grsWt, If_Notify, items_Marks_nos, Item_value;
    public string INVNO, SBNO, IECNO, HSCODENO, LCNO, JobDate1, BLNumber, Tot_Volume,Tot_pkg_Units;
    public string ORDER_NO;
    DataSet ds = new DataSet();
    AppSession aps = new AppSession();
    EXP_BL_Generation BL_gen = new EXP_BL_Generation();
    string imp_name, Address;

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

        if (!IsPostBack)
        {
            try
            {            
                if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
                {
                }
                else
                {
                    string CHA_NAME = HttpContext.Current.Session["CHA_NAME"].ToString();
                    string cha_add1 = HttpContext.Current.Session["CHA_ADDRESS"].ToString();
                    string cha_add2 = HttpContext.Current.Session["CHA_ADDRESS1"].ToString();
                    string cha_add3 = HttpContext.Current.Session["CHA_ADDRESS2"].ToString() + " " + HttpContext.Current.Session["CHA_ADDRESS3"].ToString();
                    //string cha_add4 = HttpContext.Current.Session["CHA_ADDRESS3"].ToString();

                    //string CHA_DETAILS1 = CHA_NAME + Environment.NewLine + cha_add1 + Environment.NewLine + cha_add2 + Environment.NewLine + cha_add3 + " " + cha_add4;
                    //ReportParameter CHA_DETAILS = new ReportParameter("CHA_DETAILS", CHA_DETAILS1);
                   
                    List<ReportParameter> paramList = new List<ReportParameter>();
                    this.ReportViewer1.LocalReport.SetParameters(paramList);
                    ReportViewer1.LocalReport.DataSources.Clear();

                    Despatch DSP = new Despatch();

                    DSP.ID = Request.QueryString["jobno"].ToString();
                    DSP.BRANCHCODE = SELECT_BRANCH;
                    DSP.flag = "Despatch_Report";
                    DSP.MODE = Request.QueryString["Mode"].ToString();
                    ds = DSP.Export_Despatch_Name();

                    ReportParameter To_ADD1 = new ReportParameter("To_ADD1", ds.Tables[0].Rows[0]["TO_ADD1"].ToString());
                    ReportParameter To_ADD2 = new ReportParameter("To_ADD2", ds.Tables[0].Rows[0]["TO_ADD2"].ToString());
                    ReportParameter CHA_NAME1 = new ReportParameter("CHA_NAME", CHA_NAME);
                    ReportParameter cha_add11 = new ReportParameter("cha_add1", cha_add1);
                    ReportParameter cha_add22 = new ReportParameter("cha_add2", cha_add2);
                    ReportParameter cha_add33 = new ReportParameter("cha_add3", cha_add3);
                    ReportParameter JOBNO = new ReportParameter("JOBNO", ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString());
                    ReportParameter EXPORTER_NAME = new ReportParameter("EXPORTER_NAME", ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString());
                    ReportParameter PORT_OF_DISCHARGE = new ReportParameter("PORT_OF_DISCHARGE", ds.Tables[0].Rows[0]["PORT_OF_DISCHARGE"].ToString());
                    ReportParameter PACKAGES = new ReportParameter("PACKAGES", ds.Tables[0].Rows[0]["PACKAGES"].ToString());
                    ReportParameter DESCRIPTION = new ReportParameter("DESCRIPTION", ds.Tables[0].Rows[0]["DESCRIPTION"].ToString());
                   
                    //string Importer=ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                  
                    //if (Importer.Contains(','))
                    //{
                    //    string[] imp = Importer.Split(',');
                    //     imp_name = imp[0];
                    //     Address = imp[1];

                    //}

                    //ReportParameter Importer_Name1 = new ReportParameter("imp_name", imp_name);
                    //ReportParameter Address1 = new ReportParameter("Address", Address);

                    ReportViewer1.LocalReport.DisplayName = "Dispatch Information";

                    ReportParameter[] p = { To_ADD1, To_ADD2, CHA_NAME1, cha_add11, cha_add22, cha_add33, JOBNO, PORT_OF_DISCHARGE, PACKAGES, DESCRIPTION, EXPORTER_NAME };
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