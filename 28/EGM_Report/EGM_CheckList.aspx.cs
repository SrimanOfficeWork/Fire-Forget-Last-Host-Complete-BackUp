using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
//using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using Microsoft.ApplicationBlocks.Data;

using Microsoft.Reporting.WebForms;
//using ReportViewerLib;


public partial class Transaction_Default2 : ThemeClass
{
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;

    AppSession aps = new AppSession();
    Export_FlatFile_Generation FlatFile = new Export_FlatFile_Generation();


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession_Subfolder();
            currentuser = Session["currentuser"].ToString();
            currentbranch = Session["currentbranch"].ToString();
            currentcomp_name = Session["currentcomp_name"].ToString();
            comp_ConnectionStr = Session["currentcomp_db"].ToString();
            //mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;

            Working_Period = Session["WorkingPeriod"].ToString();
            LoginDate = Session["LoginDate"].ToString();

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
            hdn_Branch.Value = SELECT_BRANCH;

            if (!IsPostBack)
            {
               
                if (!string.IsNullOrEmpty(Request["jobno"]))
                {

                    System.Web.UI.HtmlControls.HtmlGenericControl currdiv = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("sidebar");
                    currdiv.Style.Add("display", "none");

                    System.Web.UI.HtmlControls.HtmlGenericControl currdiv1 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("innerbox_Main_Top_User");
                    currdiv1.Style.Add("display", "none");

                    System.Web.UI.HtmlControls.HtmlGenericControl currdiv2 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("maincontent");
                    currdiv2.Style.Add("margin", "-16px 2px 0 0");
                    currdiv2.Style.Add("padding", "2px 0 0");

                    /*ddlJobNo.Items.Clear();
                    ddlJobNo.Items.Add(Request["jobno"].ToString());*/

                    //ddlJobNo.Items.Clear();
                    //ddlJobNo.Items.Insert(0, new ListItem(Request["jobnops"].ToString(), Request["jobno"].ToString()));
                    //ddlJobNo.SelectedIndex = 0;



                    if (Request["jobno"].ToString().Contains("-"))
                    {
                        string[] sp = Request["jobno"].ToString().Split('-');

                        ddlJobNo.Items.Clear();
                        ddlJobNo.Items.Insert(0, new ListItem(sp[0], Request["jobno"].ToString()));
                        ddlJobNo.SelectedIndex = 0;
                        ViewState["Report_type"] = "Consolidate";
                        hdn_Report_Type.Value = "Consolidate";
                        hdn_Jobno.Value = sp[0];
                    }
                    else
                    {
                        ddlJobNo.Items.Clear();
                        ddlJobNo.Items.Insert(0, new ListItem(Request["jobnops"].ToString(), Request["jobno"].ToString()));
                        ddlJobNo.SelectedIndex = 0;
                        ViewState["Report_type"] = "Normal";
                        hdn_Report_Type.Value = "Normal";
                        hdn_Jobno.Value = Request["jobnops"].ToString();

                    }
                }
                else
                {
                    Export_CheckList CHKLIST = new Export_CheckList();
                    CHKLIST.JOBNo = "";
                    CHKLIST.Ename = "select_jobno";
                    CHKLIST.Workingperiod = SELECT_BRANCH;
                    ddlJobNo.DataSource = CHKLIST.RetrieveAll_General_Details();
                    ddlJobNo.DataValueField = "JOBNO";
                    ddlJobNo.DataTextField = "JOBNO_PS";
                    ddlJobNo.DataBind();
                    ddlJobNo.Items.Remove("0");
                    ddlJobNo.Items.Insert(0, "Select");
                }

                txtCustomHouse.Attributes.Add("readonly", "readonly");
                txtExporterName.Attributes.Add("readonly", "readonly");
                txtScheme.Attributes.Add("readonly", "readonly");
                txtConsignee.Attributes.Add("readonly", "readonly");
                txtNoofItems.Attributes.Add("readonly", "readonly");
                txtNoofInvoices.Attributes.Add("readonly", "readonly");
            }
            ddlJobNo.Attributes.Add("onchange", "javascript:CallServerside_Importer('" + ddlJobNo.ClientID + "', '" + txtCustomHouse.ClientID + "')");
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
    }
    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Export_CheckList CHKLIST = new Export_CheckList();
            CHKLIST.JOBNo = ddlJobNo.SelectedValue.ToString();
            CHKLIST.Ename = "select_jobno_CheckList";

            CHKLIST.Workingperiod = SELECT_BRANCH;
            DataSet ds = new DataSet();
            ds = CHKLIST.RetrieveAll_General_Details();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCustomHouse.Text = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                hdn_TransportMode.Value = ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();
                txtExporterName.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                txtConsignee.Text = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();

                if (ds.Tables[1].Rows.Count > 0)
                {
                    txtScheme.Text = ds.Tables[1].Rows[0]["ITEM_SCHEME_CODE"].ToString();
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        txtNoofInvoices.Text = ds.Tables[2].Rows[0]["INVOICE_NO"].ToString() + " INVOICE";

                    }
                    else
                    {
                        txtNoofInvoices.Text = "";
                    }

                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        txtNoofItems.Text = ds.Tables[3].Rows[0]["ITEM_SLNO"].ToString() + " ITEMS";

                    }
                    else
                    {
                        txtNoofItems.Text = "";
                    }
                }
                else
                {
                    txtScheme.Text = "";
                    txtNoofItems.Text = "";
                    txtNoofInvoices.Text = "";
                }
               
            }
            else
            {
                txtCustomHouse.Text = "";
                txtExporterName.Text = "";
                txtScheme.Text = "";
                txtConsignee.Text = "";
                txtNoofItems.Text = "";
                txtNoofInvoices.Text = "";

            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
    }
    [System.Web.Services.WebMethod]
    public static string Get_Import_Details(string custid, string type)
    {
        Export_FlatFile_Generation FlatFile = new Export_FlatFile_Generation();
        DataSet ds = new DataSet();
        string Working_Period = "", txtCustomHouse = "",
               txtExporterName = "",
               txtScheme = "",
               txtConsignee = "",
               txtNoofItems = "",
               txtNoofInvoices = "",
               Transport_Mode="",
        select_branch = "",
         select_type_ = "";


        try
        {
            //Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
            //select_branch = HttpContext.Current.Session["currentbranch"].ToString();
            //select_type_ = HttpContext.Current.Session["SELECT_TYPE"].ToString();

            //if (select_type_ == "Branchwise Job")
            //{
            //    select_branch = select_branch;
            //}
            //else
            //{
            //    select_branch = "";
            //}

            //Export_CheckList CHKLIST = new Export_CheckList();
            //CHKLIST.JOBNo = custid;
            //CHKLIST.Ename = "select_jobno_CheckList";

            //CHKLIST.Workingperiod = select_branch;
            //DataSet ds = new DataSet();
            //ds = CHKLIST.RetrieveAll_General_Details();

            if (custid.Contains("-"))
            {
                string[] sp = custid.Split('-');
                custid = sp[0];
            }

            if (type == "Consolidate")
            {
                FlatFile.JOBNo = custid;
                FlatFile.TRANSPORT_MODE = "";
                FlatFile.Ename = "EGM_CONSOLIDATE_FlatFile_Format";
                FlatFile.Workingperiod = Connection.Get_Company_Type();
                ds = FlatFile.Retrieve_Export_All_Details();
            }
            else
            {
                FlatFile.JOBNo = custid;
                FlatFile.TRANSPORT_MODE = "";
                FlatFile.Ename = "EGM_FlatFile_Format";
                FlatFile.Workingperiod = Connection.Get_Company_Type();
                ds = FlatFile.Retrieve_Export_All_Details();
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCustomHouse = ds.Tables[0].Rows[0]["GATEWAY_PORT"].ToString();
                txtExporterName = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                txtConsignee = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
               
                Rpt_Goods_Reg_General Export_Goods_Reg_General = new Rpt_Goods_Reg_General();
                Export_Goods_Reg_General.Retrieve_Export_Goods_Reg_General(custid, txtCustomHouse, Transport_Mode,select_branch);
    
            }
            else
            {
                txtCustomHouse = "";
                txtExporterName = "";
                txtScheme = "";
                txtConsignee = "";
                txtNoofItems = "";
                txtNoofInvoices = "";

            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
        custid = txtCustomHouse + "~~" + txtExporterName + "~~" + txtScheme + "~~" + txtConsignee + "~~" + txtNoofItems + "~~" + txtNoofInvoices + "~~" + Transport_Mode;

        return custid;
    }
}