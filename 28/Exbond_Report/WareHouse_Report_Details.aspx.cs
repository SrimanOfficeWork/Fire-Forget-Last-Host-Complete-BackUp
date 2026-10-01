using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using Microsoft.Reporting.WebForms;


public partial class Transaction_Default2 : ThemeClass
{
    Transaction Transact = new Transaction();
    WareHouseReportDetails wh = new WareHouseReportDetails();
    CheckList CHKLIST = new CheckList();
    AppSession aps = new AppSession();

    public string SELECT_BRANCH;

    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        Page_load();
    }
    public void Page_load()
    {
        try
        {
            aps.checkSession_Subfolder();
            SELECT_BRANCH = Connection.Get_Company_Type();

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

                    ddlJobNo.Items.Clear();
                    ddlJobNo.Items.Add(Request["jobno"].ToString());
                }
                else
                {
                    WareHouse_JobNo_Load();              
                }
                ddlJobNo.Attributes.Add("onchange", "javascript:CallServerside_Importer('" + ddlJobNo.ClientID + "', '" + txtCustomHouse.ClientID + "')");

                txtCustomHouse.Attributes.Add("readonly", "readonly");
                txtImporterName.Attributes.Add("readonly", "readonly");
                txtBE_Type.Attributes.Add("readonly", "readonly");
                txtDescription.Attributes.Add("readonly", "readonly");
                txtNoofItems.Attributes.Add("readonly", "readonly");
                txtNoofInvoices.Attributes.Add("readonly", "readonly");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public void WareHouse_JobNo_Load()
    {
        Transact.JOBNO = "";
        Transact.Ename = "select_Warehouse_JobNo";
        Transact.WORKING_PERIOD = SELECT_BRANCH;

        ddlJobNo.DataSource = Transact.RetrieveAll_Warehouse_Job_Details();
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataTextField = "JOBNO";
        ddlJobNo.DataBind();
        ddlJobNo.Items.Remove("0");
        ddlJobNo.Items.Insert(0, "Select");
    }

    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            WareHouseReportDetails wh = new WareHouseReportDetails();
            wh.JOBNO = ddlJobNo.SelectedValue.ToString();
            wh.Ename = "Exbond_JobWiseReport";
            wh.Workingperiod = Connection.WorkingPeriod();
            DataSet ds = new DataSet();
            ds = wh.RetrieveAll_WareHouse_Details();

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCustomHouse.Text = ds.Tables[0].Rows[0]["EXBOND_INBOND_BE_NO"].ToString();

                if (ds.Tables[1].Rows.Count > 0)
                {
                    txtImporterName.Text = ds.Tables[1].Rows[0]["IMPORTER_NAME"].ToString();

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        txtDescription.Text = ds.Tables[2].Rows[0]["ITEM_DESCRIPTION"].ToString();

                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            txtNoofInvoices.Text = ds.Tables[3].Rows[0]["INVOICE_NO"].ToString() + " INVOICE";

                            if (ds.Tables[4].Rows.Count > 0)
                            {
                                txtNoofItems.Text = ds.Tables[4].Rows[0]["ITEM_SLNO"].ToString() + " ITEMS";
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    [System.Web.Services.WebMethod]
    public static string Get_Import_Details(string custid)
    {
        string txtCustomHouse = "", txtImporterName = "", txtDescription = "", txtNoofInvoices = "", txtNoofItems = "", txtBE_Type = "";

        try
        {
            WareHouseReportDetails wh = new WareHouseReportDetails();
            wh.JOBNO = custid;
            wh.Ename = "Exbond_JobWiseReport";

            wh.Working_Period = Connection.Get_Company_Type();
            DataSet ds = new DataSet();
            ds = wh.RetrieveAll_WareHouse_Details();

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCustomHouse = ds.Tables[1].Rows[0]["CUSTOMS_HOUSE"].ToString();
                if (ds.Tables[1].Rows.Count > 0)
                {
                    txtImporterName = ds.Tables[1].Rows[0]["IMPORTER_NAME"].ToString();
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        txtDescription= ds.Tables[2].Rows[0]["ITEM_DESCRIPTION"].ToString();
                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            txtNoofInvoices = ds.Tables[3].Rows[0]["INVOICE_NO"].ToString() + " INVOICE";
                            if (ds.Tables[4].Rows.Count > 0)
                            {
                                txtNoofItems = ds.Tables[4].Rows[0]["ITEM_SLNO"].ToString() + " ITEMS";
                            }
                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                txtBE_Type = ds.Tables[1].Rows[0]["BE_TYPE"].ToString();
                            }
                        }
                    }
                }
            }
            General_Details Import_General = new General_Details();
            Import_General.Retrieve_GetWareHouse_General(custid);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        custid = txtCustomHouse + "~~" + txtImporterName + "~~" + txtDescription + "~~" + txtNoofInvoices + "~~" + txtNoofItems + "~~" + txtBE_Type;
        return custid;
    }
}

