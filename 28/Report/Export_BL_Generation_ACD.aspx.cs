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
//using Microsoft.Reporting.WinForms;
using System.Web.UI.WebControls.WebParts;
//using ReportViewerLib;
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Linq;



public partial class Export_BL_Generation_ACD : System.Web.UI.Page
{
    //---------------------ITEM ATTRIBUTES-----------------//
    
    public string working_period;
    public string SELECT_TYPE, SELECT_BRANCH;

    AppSession aps = new AppSession();
    Transaction Transact = new Transaction();
    adminmaster adm = new adminmaster();
    EXP_BL_Generation BL_Gen = new EXP_BL_Generation();

    private string _Workingperiod;
    
    DataSet ds = new DataSet();
    DataSet DSS = new DataSet();

    public string Workingperiod
    {
        get { return _Workingperiod; }
        set { _Workingperiod = value; }
    }

    public string currentuser, ddlJobNo;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;

    public string ExporterName, consignee_name, buyerName;
    public string Marks_Nos, NoPkgs,Goods_desc,Total_pkgs,Gross_wt,Unit_total_pkgs,No_Of_Packages;
    public string ContainerNo, container_bind,Container_Type,SealNo;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
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
            jobno_load();
            Load_BL_Gen_ACD_Report();

            btn_print.Visible = false;
            btnSend.Visible = false;             
        }
    }

    private void jobno_load()
    {
        BL_Gen.JOBNO = "";
        BL_Gen.WORKINGPERIOD = SELECT_BRANCH;
        BL_Gen.Ename = "select_BL_Details_Grid";
        ds = BL_Gen.BL_Select_All();

        ddlJob_No.DataSource = ds.Tables[1];
        ddlJob_No.DataValueField = "JOBNO";
        ddlJob_No.DataTextField = "JOBNO";
        ddlJob_No.DataBind();
        ddlJob_No.Items.Remove("0");
        ddlJob_No.Items.Insert(0, "Select");
        
    }

    public void Load_BL_Gen_ACD_Report()
    {
        try
        {
            if (ddlJob_No.SelectedItem.Text != "Select")
            {
                

                List<ReportParameter> paramList = new List<ReportParameter>();
                this.ReportViewer1.LocalReport.SetParameters(paramList);
                ReportViewer1.LocalReport.DataSources.Clear();

                BL_Gen.JOBNO = ddlJob_No.SelectedItem.Text;
                BL_Gen.WORKINGPERIOD = SELECT_BRANCH;
                //ds = BL_Gen.BL_Rpt();
                BL_Gen.Ename = "Select_All_Details";
                ds = BL_Gen.BL_Select_All();

                Container_Details();
                ExporterName = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString() + Environment.NewLine + ds.Tables[0].Rows[0]["ADDRESS1"].ToString() + Environment.NewLine + ds.Tables[0].Rows[0]["ADDRESS2"].ToString() + Environment.NewLine + ds.Tables[0].Rows[0]["ADDRESS3"].ToString() + Environment.NewLine + ds.Tables[0].Rows[0]["ADDRESS4"].ToString() + ds.Tables[0].Rows[0]["ADDRESS5"].ToString();
                consignee_name = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString() + Environment.NewLine + ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString() + Environment.NewLine + ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString() + Environment.NewLine + ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString() + Environment.NewLine + ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString();
                buyerName = ds.Tables[0].Rows[0]["BUYER_NAME"].ToString() + Environment.NewLine + ds.Tables[0].Rows[0]["BUYER_ADDRESS"].ToString() + Environment.NewLine + ds.Tables[0].Rows[0]["BUYER_ADDRESS1"].ToString() + Environment.NewLine + ds.Tables[0].Rows[0]["BUYER_ADDRESS2"].ToString() + Environment.NewLine + ds.Tables[0].Rows[0]["BUYER_ADDRESS3"].ToString();
                string Unit_tot_packages = ds.Tables[0].Rows[0]["TOT_PKGS_UNIT"].ToString();

                string InvoiceNo = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString();
                string SBNo = ds.Tables[0].Rows[0]["SB_NO"].ToString();
                string IEC_No = ds.Tables[0].Rows[0]["IEC_NO"].ToString();


                Goods_desc = ds.Tables[1].Rows[0]["desc"].ToString() + Environment.NewLine + Environment.NewLine + "INV NO:" + InvoiceNo + Environment.NewLine + "SB NO:" + SBNo + Environment.NewLine + "IEC NO:" + IEC_No;
                Marks_Nos = ds.Tables[1].Rows[0]["Mark_No"].ToString();
                NoPkgs = ds.Tables[1].Rows[0]["no_pkg"].ToString();
                Gross_wt = ds.Tables[1].Rows[0]["gross_wgt"].ToString();

                if (NoPkgs != "")
                {
                    if (Unit_tot_packages != "")
                    {
                        string p1=Unit_tot_packages;
                        string[] part1 = p1.Split('-');
                        Unit_total_pkgs = part1[1];
                    }
                    else
                    {
                        if (NoPkgs.Contains('/'))
                        {
                            string unit = NoPkgs;
                            string[] unit1 = unit.Split('/');
                            string unit2 = unit1[1].Substring(0, 3).Trim();
                            Unit_total_pkgs = unit2;

                            No_Of_Packages = unit1[0];
                            NoPkgs = No_Of_Packages;
                        }
                        else
                        {
                            
                        }
                    }
                    No_Of_Packages = NoPkgs;
                }

                //****************** CONTAINER START*********************//

                if (DSS.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < DSS.Tables[0].Rows.Count; i++)
                    {
                        container_bind += DSS.Tables[0].Rows[i]["CONTAINER_NO"].ToString() + Environment.NewLine + DSS.Tables[0].Rows[i]["TYPE"].ToString() + Environment.NewLine + Environment.NewLine;
                        SealNo += DSS.Tables[0].Rows[i]["SEAL_NO"].ToString() + Environment.NewLine;
                    }
                    ContainerNo = "Container No's & Type" + Environment.NewLine + "-------------------------" + Environment.NewLine + container_bind + Environment.NewLine + "Line Seal No" + Environment.NewLine + "---------------------" + Environment.NewLine + SealNo + Environment.NewLine + "Custom Seal No" + Environment.NewLine + "-----------------------" + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                }

                //****************** CONTAINER END*********************//

                ReportParameter exp_name = new ReportParameter("Exp_name1", ExporterName);
                ReportParameter consignee_name1 = new ReportParameter("consignee_name", consignee_name);
                ReportParameter Buyer_name = new ReportParameter("Buyer_name", buyerName);
                ReportParameter Goods_Description = new ReportParameter("Goods_desc", Goods_desc);
                ReportParameter Marks_Nos1 = new ReportParameter("Marks_Nos", Marks_Nos + Environment.NewLine + Environment.NewLine + ContainerNo);
                ReportParameter total_packages = new ReportParameter("NoPkgs", No_Of_Packages);
                ReportParameter gross_weight = new ReportParameter("Gross_wt", Gross_wt);
                ReportParameter unit_pkgs = new ReportParameter("Unit_total_pkgs", Unit_total_pkgs);
               
                ReportDataSource datasource = new ReportDataSource("Export_BL_Gen_ACD_DataSet", ds.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Add(datasource);

                ReportParameter[] p = { exp_name, consignee_name1, Buyer_name, Goods_Description, Marks_Nos1, total_packages, gross_weight, unit_pkgs };
                ReportViewer1.LocalReport.SetParameters(p);

                ReportViewer1.LocalReport.DisplayName = "BL Generation- ACD Report";

                //--------------------------------------To Print------------------------------------------------------------------------------------//
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;

                byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                Session.Remove("report");
                Session["report"] = bytes;

                btn_print.Visible = true;
                btnSend.Visible = true;
                ReportViewer1.Visible = true;
            }
            else
            {
                btn_print.Visible = false;
                btnSend.Visible = false;

                ReportViewer1.Visible = false;
            }
        }

        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
    }
    public void Container_Details()
    {
        BL_Gen.JOBNO = ddlJob_No.SelectedItem.Text;
        BL_Gen.WORKINGPERIOD = SELECT_BRANCH;
        //ds = BL_Gen.BL_Rpt();
        BL_Gen.Ename = "Select_Details";
        DSS = BL_Gen.BL_Container_Select_All();
    }

    protected void ddlJob_No_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_BL_Gen_ACD_Report();
    }

}