
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

public partial class Report_Export_BL_Generation_Rpt : System.Web.UI.Page
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
    public string INVNO, SBNO, IECNO, HSCODENO, LCNO, JobDate1, BLNumber, Tot_Volume, Tot_pkg_Units, all_det = "", AgentName = "", item_desc_all = "";
    public string ORDER_NO, PKGS_WORDS;
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
                string Btn_Type = string.Empty;
                Btn_Type = Request.QueryString["Type"].ToString();

                if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
                {

                }
                else
                {
                    if (Btn_Type == "Direct")
                    {
                        LocalReport localReport = ReportViewer1.LocalReport;
                        localReport.ReportPath = @"Report/Export_BL_Generation_Direct_Rpt.rdlc";
                    }
                    if (Btn_Type == "Manual")
                    {
                        if (Connection.COMPANYID() == "1065")
                        {
                            LocalReport localReport = ReportViewer1.LocalReport;
                            localReport.ReportPath = @"Report/Export_BL_Generation_Rpt_INDOGLOBE.rdlc";
                        }
                        else
                        {
                            LocalReport localReport = ReportViewer1.LocalReport;
                            localReport.ReportPath = @"Report/Export_BL_Generation_Rpt.rdlc";
                        }
                    }

                    List<ReportParameter> paramList = new List<ReportParameter>();
                    this.ReportViewer1.LocalReport.SetParameters(paramList);
                    ReportViewer1.LocalReport.DataSources.Clear();

                    EXP_BL_Generation BL = new EXP_BL_Generation();

                    BL.JOBNO = Request.QueryString["jobno"].ToString();
                    BL.BRANCHCODE = SELECT_BRANCH;
                    ds = BL.BL_Rpt();

                    string origin_dest = ds.Tables[0].Rows[0]["FREIGHT_PRE_COL"].ToString();
                    Tot_pkg_Units = ds.Tables[0].Rows[0]["TOT_PKGS_UNIT"].ToString();


                    if (origin_dest == "FREIGHT COLLECT")
                    {
                        orig_dest = "DESTINATION";
                    }
                    if (origin_dest == "FREIGHT PREPAID")
                    {
                        orig_dest = "ORIGIN";
                    }

                    //BL.Ename = "select";
                    //ds = BL.BL_Select_All();

                    ReportDataSource datasource = new ReportDataSource("Export_BL_Item", ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Add(datasource);

                    string Frieght_Col = ds.Tables[0].Rows[0]["FREIGHT_PRE_COL"].ToString();

                    string check_total_vol = ds.Tables[0].Rows[0]["TOTALVOLUME"].ToString();

                    if (check_total_vol != "")
                    {
                        Tot_Volume = "TOTAL VOLUME:" +Environment.NewLine +ds.Tables[0].Rows[0]["TOTALVOLUME"].ToString() + " " + ds.Tables[0].Rows[0]["TOT_VOL_UNIT"].ToString();
                    }
                    else
                    {
                         Tot_Volume ="";
                    }
                   
                    string NotifyAddress4 = ds.Tables[0].Rows[0]["NOTIFY_1_4"].ToString() + "," + ds.Tables[0].Rows[0]["NOTIFY_1_5"].ToString();

                    //********************************** SHOW JOB_DATE ********************************

                    //if (ds.Tables[0].Rows[0]["JOB_DATE"].ToString() != "01/01/1900")
                    //{
                    //    JobDate1 = "Job Date :" + ds.Tables[0].Rows[0]["JOB_DATE"].ToString();
                    //}
                    //else
                    //{
                    //    JobDate1 = "";
                    //}

                    //********************************** SHOW JOB_DATE ********************************

                    if (ds.Tables[0].Rows[0]["SHIP_REF_NO"].ToString() != "")
                    {
                        JobDate1 = "Booking No :" + ds.Tables[0].Rows[0]["SHIP_REF_NO"].ToString();
                    }
                    else
                    {
                        JobDate1 = "";
                    }

                    if (ds.Tables[0].Rows[0]["BL_NUMBER"].ToString() != "")
                    {
                        BLNumber = "BL Number :" + ds.Tables[0].Rows[0]["BL_NUMBER"].ToString();
                    }
                    else
                    {
                        BLNumber = "";
                    }

                    if (ds.Tables[0].Rows[0]["INVOICE_NO"].ToString() != "")
                    {
                        INVNO = "INV NO :" + ds.Tables[0].Rows[0]["INVOICE_NO"].ToString();
                    }
                    else
                    {
                        INVNO = "";
                    }

                    if (ds.Tables[0].Rows[0]["SB_NO"].ToString() != "")
                    {
                        SBNO = "SB NO :" + ds.Tables[0].Rows[0]["SB_NO"].ToString();
                    }
                    else
                    {
                        SBNO = "";
                    }

                    if (ds.Tables[0].Rows[0]["IEC_NO"].ToString() != "")
                    {
                        IECNO = "IEC NO :" + ds.Tables[0].Rows[0]["IEC_NO"].ToString();
                    }
                    else
                    {
                        IECNO = "";
                    }

                    if (ds.Tables[0].Rows[0]["HSS_CODE_NO"].ToString() != "")
                    {
                        HSCODENO = "HS CODE NO :" + ds.Tables[0].Rows[0]["HSS_CODE_NO"].ToString();
                    }
                    else
                    {
                        HSCODENO = "";
                    }

                    if (ds.Tables[0].Rows[0]["LC_NO"].ToString() != "")
                    {
                        LCNO = "LC NO :" + ds.Tables[0].Rows[0]["LC_NO"].ToString();
                    }
                    else
                    {
                        LCNO = "";
                    }

                    if (ds.Tables[0].Rows[0]["ORDER_NO"].ToString() != "")
                    {
                        ORDER_NO = "ORDER NO :" + ds.Tables[0].Rows[0]["ORDER_NO"].ToString();
                    }
                    else
                    {
                        ORDER_NO = "";
                    }

                    //if (ds.Tables[0].Rows[0]["PKGS_WORDS"].ToString() != "")
                    //{
                    //    PKGS_WORDS = ds.Tables[0].Rows[0]["PKGS_WORDS"].ToString().Replace("RUPEES", Tot_pkg_Units);
                    //}
                    //else
                    //{
                    //    PKGS_WORDS = "";
                    //}


                    if (ds.Tables[0].Rows[0]["NOTIFY_1_1"].ToString() != "")
                    {
                        If_Notify = "2 ND NOTIFY :" + Environment.NewLine + ds.Tables[0].Rows[0]["NOTIFY_1_1"].ToString() + Environment.NewLine + ds.Tables[0].Rows[0]["NOTIFY_1_2"].ToString() + Environment.NewLine + ds.Tables[0].Rows[0]["NOTIFY_1_3"].ToString() + Environment.NewLine + NotifyAddress4;
                    }
                    else
                    {
                        If_Notify = "";
                    }

                    if (ds.Tables[0].Rows[0]["AGENTS_NAEE_REFNO"].ToString() != "")
                    {
                        if (ds.Tables[0].Rows[0]["AGENTS_NAEE_REFNO"].ToString().Contains("~"))
                        {
                            //AgentName = ds.Tables[0].Rows[0]["AGENTS_NAEE_REFNO"].ToString().Replace("~", Environment.NewLine).Replace("\r\n\r\n\r\n", "\r\n");
                            AgentName = ds.Tables[0].Rows[0]["AGENTS_NAEE_REFNO"].ToString().Replace("~~", "~").Replace("~~~", "~");
                            string[] aa = AgentName.Split('~');
                            int cnt=aa.Count();

                            if (cnt == 7 || cnt >= 7)
                            {
                                AgentName = aa[0] + Environment.NewLine + aa[1] + " " + aa[2] + Environment.NewLine + aa[3] + " " + aa[4] + Environment.NewLine + aa[5] + Environment.NewLine + aa[6];
                            }
                            else if (cnt == 6)
                            {
                                AgentName = aa[0] + Environment.NewLine + aa[1] + " " + aa[2] + Environment.NewLine + aa[3] + " " + aa[4] + Environment.NewLine + aa[5];
                            }
                            else if (cnt == 5)
                            {
                                AgentName = aa[0] + Environment.NewLine + aa[1] + " " + aa[2] + Environment.NewLine + aa[3] + Environment.NewLine + aa[4];
                            }
                            else if (cnt == 4)
                            {
                                AgentName = aa[0] + Environment.NewLine + aa[1] + Environment.NewLine + aa[2] + Environment.NewLine + aa[3];
                            }
                            else if (cnt == 3)
                            {
                                AgentName = aa[0] + Environment.NewLine + aa[1] + Environment.NewLine + aa[2];
                            }
                            else if (cnt == 2)
                            {
                                AgentName = aa[0] + Environment.NewLine + aa[1];
                            }
                            else if (cnt == 1)
                            {
                                AgentName = aa[0];
                            }
                            else
                            {
                                AgentName ="";
                            }
                        }
                    }

                    string str_VOYAGE = "";
                    //if (Connection.COMPANYID() == "1065" || Connection.COMPANYID() == "10" && Btn_Type == "Manual")
                    if (Connection.COMPANYID() == "1065" && Btn_Type == "Manual")
                    {
                        all_det =  INVNO + Environment.NewLine + SBNO + Environment.NewLine + IECNO + Environment.NewLine + LCNO + Environment.NewLine + HSCODENO + Environment.NewLine + ORDER_NO + Environment.NewLine + Environment.NewLine + Environment.NewLine + Frieght_Col;
                        str_VOYAGE = "V:" + ds.Tables[0].Rows[0]["VOYAGE"].ToString();
                    }
                    else
                    {
                         all_det = INVNO + Environment.NewLine + SBNO + Environment.NewLine + IECNO + Environment.NewLine + LCNO + Environment.NewLine + HSCODENO + Environment.NewLine + ORDER_NO + Environment.NewLine + Environment.NewLine + If_Notify + Environment.NewLine + Environment.NewLine + Frieght_Col;
                         str_VOYAGE = ds.Tables[0].Rows[0]["VOYAGE"].ToString();
                    }

                    string Notift1 = ds.Tables[0].Rows[0]["LC_NO"].ToString();

                    


                    ReportParameter param_Frieght_Col = new ReportParameter("Frieght_Col", Frieght_Col);
                    ReportParameter param_JobDate = new ReportParameter("Jobdate1", JobDate1);
                    ReportParameter Origin_destination = new ReportParameter("orig_dest", orig_dest);
                    ReportParameter NotifyAddress = new ReportParameter("NotifyAddress4", NotifyAddress4);
                    ReportParameter TOTALVOLUME = new ReportParameter("Tot_Volume", Tot_Volume);
                    ReportParameter VOYAGE = new ReportParameter("VOYAGE", str_VOYAGE);
                    ReportParameter Agent_Name = new ReportParameter("AgentName", AgentName);
                    ReportParameter Pkgs_Words = new ReportParameter("Pkgs_Words", PKGS_WORDS);
                    ReportParameter FreightCharges = new ReportParameter("FreightCharges", ds.Tables[0].Rows[0]["FREIGHT_CHARGES"].ToString());



                    ReportDataSource datasource2 = new ReportDataSource("EXPORT_BL_ITEM_DETAILS", ds.Tables[1]);
                    ReportViewer1.LocalReport.DataSources.Add(datasource2);

                    //****************ITEM DETAILS*******************************

                    DataTable item_dt = ds.Tables[1];


                    ArrayList item_arr = new ArrayList();
                    ArrayList item_desc = new ArrayList();
                    ArrayList item_grosswt = new ArrayList();
                    ArrayList Marks_nos = new ArrayList();


                    for (int i = 0; i < item_dt.Rows.Count; i++)
                    {
                        item_arr.Add(ds.Tables[1].Rows[i]["NO_OF_PKG"].ToString());
                        item_desc.Add(ds.Tables[1].Rows[i]["GOODS_DESC"].ToString());
                        item_grosswt.Add(ds.Tables[1].Rows[i]["GROSS_WEIGHT"].ToString());
                        Marks_nos.Add(ds.Tables[1].Rows[i]["MARKS_NUMBERS"].ToString());

                    }

                    items = string.Empty;
                    items_description = string.Empty;
                    item_grsWt = string.Empty;

                    foreach (string item_val in item_arr)
                    {
                        items += item_val + Environment.NewLine;

                    }

                    foreach (string desc_val in item_desc)
                    {
                        items_description += desc_val + Environment.NewLine + Environment.NewLine;

                    }

                    foreach (string gross_val in item_grosswt)
                    {
                        item_grsWt += gross_val + Environment.NewLine + Environment.NewLine;

                    }

                    item_grsWt = item_grsWt +  Environment.NewLine + Tot_Volume;

                    foreach (string mrk_nos in Marks_nos)
                    {
                        items_Marks_nos += mrk_nos + Environment.NewLine + Environment.NewLine;

                    }

                    if (ds.Tables[1].Rows[0]["NO_OF_PKG"].ToString() != "")
                    {
                        Item_value = items + "" + Tot_pkg_Units;
                    }
                    else
                    {
                         Item_value = items;
                    }

                    
                    //****************CONTAINER DETAILS*******************************
                    DataTable container_dt = ds.Tables[2];

                    ArrayList Array = new ArrayList();

                    for (int i = 0; i < container_dt.Rows.Count; i++)
                    {
                        Array.Add(ds.Tables[2].Rows[i]["CONTAINER_NO"].ToString());
                    }

                    Container = string.Empty;

                    foreach (string cont_val in Array)
                    {
                        Container += cont_val + Environment.NewLine + Environment.NewLine;

                    }

                    string value = Container;
                    string marks = "";

                    if (ds.Tables[1].Rows[0]["MARKS_NUMBERS"].ToString() != "")
                    {
                       
                        marks = " MARKS & NOS :" + Environment.NewLine + Environment.NewLine + items_Marks_nos;
                    }
                    else
                    {
                        marks = "";
                    }

                    //if (Connection.COMPANYID() == "1065" || Connection.COMPANYID() == "10" && Btn_Type == "Manual")
                    if (Connection.COMPANYID() == "1065"  && Btn_Type == "Manual")
                    {
                        item_desc_all = ds.Tables[0].Rows[0]["PKGS_WORDS"].ToString().Replace("RUPEES", Tot_pkg_Units) + Environment.NewLine + Environment.NewLine + items_description + all_det;
                    }
                    else
                    {
                        item_desc_all = items_description + all_det;
                    }

                    ReportParameter Container_Details = new ReportParameter("Container1", Container + marks);
                    ReportParameter Items_no_of_pkgs = new ReportParameter("Item_value_pkgs", Item_value);
                    ReportParameter Item_description = new ReportParameter("items_description", item_desc_all);
                    ReportParameter Item_grossWeight = new ReportParameter("item_grsWt", item_grsWt);
                    ReportParameter BLNumber1 = new ReportParameter("BLNumber", BLNumber);
                    ReportParameter IfNotify = new ReportParameter("If_Notify", If_Notify);

                    //Load_BL_Container_Details();

                    ReportViewer1.LocalReport.DisplayName = "BLGeneration";

                    //if (Connection.COMPANYID() == "1065" || Connection.COMPANYID() == "10" && Btn_Type == "Manual")
                    if (Connection.COMPANYID() == "1065" && Btn_Type == "Manual")
                    {
                        
                        ReportParameter[] p = { param_Frieght_Col, param_JobDate, Origin_destination, NotifyAddress, TOTALVOLUME, Container_Details, Items_no_of_pkgs, Item_description, Item_grossWeight, BLNumber1, VOYAGE, IfNotify, Agent_Name, FreightCharges };
                        ReportViewer1.LocalReport.SetParameters(p);
                    }
                    else
                    {
                        ReportParameter[] p = { param_Frieght_Col, param_JobDate, Origin_destination, NotifyAddress, TOTALVOLUME, Container_Details, Items_no_of_pkgs, Item_description, Item_grossWeight, BLNumber1, VOYAGE };
                        ReportViewer1.LocalReport.SetParameters(p);
                    }

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