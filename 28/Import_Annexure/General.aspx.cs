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

    public string working_period;


    private string _Workingperiod;
    DataSet ds = new DataSet();

    public string Workingperiod
    {
        get { return _Workingperiod; }
        set { _Workingperiod = value; }
    }

    public int currentrow = 0, Selected_Row = 0, Cell_Row = 0, ColumnIndex = 0;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    CheckList CHKLIST = new CheckList();
    //Customer c = new Customer();
    Date_Time dt = new Date_Time();
    AppSession aps = new AppSession();


    protected void Page_Load(object sender, EventArgs e)
    {
        Page_load();

    }

    public void Page_load()
    {
        try
        {
            aps.checkSession_Subfolder();
            currentuser = Session["currentuser"].ToString();
            currentbranch = Session["currentbranch"].ToString();
            //currentcomp_name = Session["currentcomp_name"].ToString();
            //comp_ConnectionStr = Session["currentcomp_db"].ToString();

            Working_Period = Session["WorkingPeriod"].ToString();
            LoginDate = Session["LoginDate"].ToString();
            //mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;
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
                ddlJobNo.Attributes.Add("onchange", "javascript:CallServerside_Importer('" + ddlJobNo.ClientID + "', '" + txtCustomHouse.ClientID + "')");
       
                CheckList chklist = new CheckList();
                chklist.JOBNo = "";
                chklist.Ename = "select_jobno";
                chklist.Workingperiod = SELECT_BRANCH;
                ddlJobNo.DataSource = chklist.RetrieveAll_General_Details();
                ddlJobNo.DataValueField = "JOBNO";
                ddlJobNo.DataTextField = "JOBNO";
                ddlJobNo.DataBind();
                ddlJobNo.Items.Remove("0");
                ddlJobNo.Items.Insert(0, "Select");

               
                txtCustomHouse.Attributes.Add("readonly", "readonly");
                txtImporterName.Attributes.Add("readonly", "readonly");
                txtBE_Type.Attributes.Add("readonly", "readonly");
                txtSupplier.Attributes.Add("readonly", "readonly");
                txtNoofItems.Attributes.Add("readonly", "readonly");
                txtNoofInvoices.Attributes.Add("readonly", "readonly");
            }
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
            CheckList chklist = new CheckList();
            chklist.JOBNo = ddlJobNo.SelectedValue.ToString();
            chklist.Ename = "select_jobno_CheckList";
            
            chklist.Workingperiod = SELECT_BRANCH;
            DataSet ds = new DataSet();
            ds = chklist.RetrieveAll_General_Details();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCustomHouse.Text = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                txtImporterName.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                txtBE_Type.Text = ds.Tables[0].Rows[0]["BE_TYPE"].ToString();
                if (ds.Tables[1].Rows.Count > 0)
                {
                    txtSupplier.Text = ds.Tables[1].Rows[0]["SUPPLIER_NAME"].ToString();
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
                    txtSupplier.Text = "";
                    txtNoofItems.Text = "";
                    txtNoofInvoices.Text = "";
                }

            }
            else
            {
                txtCustomHouse.Text = "";
                txtImporterName.Text = "";
                txtBE_Type.Text = "";
                txtSupplier.Text = "";
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
    public static string Get_Import_Details(string custid)
    {
        string Working_Period = "", txtCustomHouse = "",
               txtImporterName = "",
               txtBE_Type = "",
               txtSupplier = "",
               txtNoofItems = "",
               txtNoofInvoices = "",select_branch="" 
                  ;
           
         
        try
        {
              Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
              // commented for areawise implementation on 05-mar-2020
              /*
                    select_branch = HttpContext.Current.Session["currentbranch"].ToString();
                    select_type_ = HttpContext.Current.Session["SELECT_TYPE"].ToString();

                    if (select_type_ == "Branchwise Job")
                    {
                        select_branch = select_branch;
                    }
                    else
                    {
                        select_branch = "";
                    }
                    * */
              select_branch = Connection.Get_Company_Type();

            CheckList chklist = new CheckList();
            chklist.JOBNo = custid;
            chklist.Ename = "select_jobno_CheckList";

            chklist.Workingperiod = select_branch;
            DataSet ds = new DataSet();
            ds = chklist.RetrieveAll_General_Details();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCustomHouse = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                txtImporterName = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                txtBE_Type = ds.Tables[0].Rows[0]["BE_TYPE"].ToString();
                if (ds.Tables[1].Rows.Count > 0)
                {
                    txtSupplier = ds.Tables[1].Rows[0]["SUPPLIER_NAME"].ToString();
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        txtNoofInvoices = ds.Tables[2].Rows[0]["INVOICE_NO"].ToString() + " INVOICE";

                    }
                    else
                    {
                        txtNoofInvoices = "";
                    }

                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        txtNoofItems = ds.Tables[3].Rows[0]["ITEM_SLNO"].ToString() + " ITEMS";

                    }
                    else
                    {
                        txtNoofItems = "";
                    }
                }
                else
                {
                    txtSupplier = "";
                    txtNoofItems = "";
                    txtNoofInvoices = "";
                }
                General_Details Import_General = new General_Details();
                Import_General.Retrieve_GetImport_Annexure(custid);
    
            }
            else
            {
                txtCustomHouse = "";
                txtImporterName = "";
                txtBE_Type = "";
                txtSupplier = "";
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
        custid = txtCustomHouse + "~~" + txtImporterName + "~~" + txtBE_Type + "~~" + txtSupplier + "~~" + txtNoofItems + "~~" + txtNoofInvoices;
      
        return custid;
    }
}