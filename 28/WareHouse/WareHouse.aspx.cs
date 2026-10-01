using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BussinessObject;
using System.IO;
using System.Text;
using Microsoft.Reporting.WebForms;
using AjaxControlToolkit;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class WareHouse : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    WareHouse_Cs WHCS = new WareHouse_Cs();
    WareHouseReportDetails wh = new WareHouseReportDetails();

    public string COMPANY_ID, flag;
    private int i;
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        
        if (!IsPostBack)
        {
            lblWk.Text = Connection.WorkingPeriod();
            Load_Wkp(); // Added by pandiyan on 04/05/2026 
            Load_JobNo();
        }
    }
    public void Load_Wkp()
    {
        DataSet dss = new DataSet();
        if (Session["COMPANY_DETAILS_DS"] != null)
        {
            dss = (DataSet)Session["COMPANY_DETAILS_DS"];
        }
      
            if (dss.Tables[2].Rows.Count > 0)
            {  
                DataTable dtTop = dss.Tables[2].AsEnumerable()
                                    .Take(4)
                                    .CopyToDataTable();

                ddlWorkingPeriod.DataSource = dtTop;
                ddlWorkingPeriod.DataTextField = "WORKING_PERIOD";
                ddlWorkingPeriod.DataValueField = "WORKING_PERIOD";
                ddlWorkingPeriod.DataBind();
            }
        
    }

    public void Load_JobNo()
    {
        DataSet dss = new DataSet();
        ObjUBO.A3 = "WH_Jobno_Select";
        dss = Database_Con_string();
        ViewState["dss_tbl"] = dss.Tables[1];

        if (dss.Tables[0].Rows.Count > 0)
        {
            ddlJobNo.DataSource = dss.Tables[0];
            ddlJobNo.DataValueField = "JOBNO";
            ddlJobNo.DataTextField = "JOBNO_PS";
            ddlJobNo.DataBind();
            Add_Empty_Jobno();
        }
        else
        {
            Add_Empty_Jobno();
        }

        if (dss.Tables[1].Rows.Count > 0)
        {
            ddl_BE_NO.DataSource = dss.Tables[1];
            ddl_BE_NO.DataValueField = "BE_JOBNO";
            ddl_BE_NO.DataTextField = "BE_NO";
            ddl_BE_NO.DataBind();
            Add_Empty_BE_Jobno();
        }
        else
        {
            Add_Empty_BE_Jobno(); 
        }
    }

    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {

        Clear();
        if (ddlJobNo.SelectedValue.ToString() != string.Empty)
        {
            DataTable dss_tbl = new DataTable();
            dss_tbl = (DataTable)ViewState["dss_tbl"];

            if (dss_tbl.Rows.Count > 0)
            {
                var FullName1 = from DataRow drr in dss_tbl.AsEnumerable()
                                where drr.Field<string>("BE_JOBNO") == ddlJobNo.SelectedValue.ToString()
                                select drr;

                DataView dvv = FullName1.AsDataView();

                if (dvv.Count > 0)
                {
                    ddl_BE_NO.SelectedValue = ddlJobNo.SelectedValue.ToString();

                    DataSet dss = new DataSet();
                    DataSet ds_Id = new DataSet();

                    string str = Connection.GetConnection();
                    string[] arr = new string[] { };
                    string[] arr2 = new string[] { };
                    string b = string.Empty, c = string.Empty;

                    arr = str.Split(';');
                    b = arr[1].ToString();
                    arr2 = b.Split('=');
                    c = arr2[1].ToString();

                    ObjUBO.A1 = ddlJobNo.SelectedValue.ToString();
                    ObjUBO.A3 = "WH_JOBNO_DATA_SELECT";
                    ObjUBO.A4 = c;
                    ObjUBO.A5 = ddlWorkingPeriod.SelectedValue.ToString();
                    dss = Database_Con_string_Details();
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        txtImporterName.Text = dss.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                        txtPortOrigin.Text = dss.Tables[0].Rows[0]["PORT_ORIGIN"].ToString();
                        txtPortShipment.Text = dss.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString();
                        txt_Oportorgin.Text = dss.Tables[0].Rows[0]["PORT_ORIGIN"].ToString();
                        txt_OPortShipment.Text = dss.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString();

                        gvAll.DataSource = dss.Tables[0];
                        gvAll.DataBind();
                    }
                    else
                    {
                        gvAll.DataSource = null;
                        gvAll.DataBind();
                    }
                    ObjUBO.A3 = "IMP_Max_Job";
                    ds_Id = WHCS.WH_Select(ObjUBO);
                    if (ds_Id.Tables[0].Rows.Count > 0)
                    {
                        txtCurrent_Job.Text = ds_Id.Tables[0].Rows[0]["JOBNO"].ToString();
                    }
                    else
                    {
                        txtCurrent_Job.Text = "";
                    }

                    if (ds_Id.Tables[1].Rows.Count > 0)
                    {
                        txt_Prefix.Text = ds_Id.Tables[1].Rows[0]["JOB_PREFIX"].ToString();
                        txt_Suffix.Text = ds_Id.Tables[1].Rows[0]["JOB_SUFFIX"].ToString();
                    }
                    else
                    {
                        txt_Prefix.Text = string.Empty;
                        txt_Suffix.Text = string.Empty;
                    }
                }
                else
                {
                    Alert_msg("BE No - Not Avail for Warehouse Job", "");
                }
            }
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Clear();
        ddlJobNo.SelectedIndex = -1;
        ddl_BE_NO.SelectedIndex = -1;
    }
    private void Clear()
    {
        txtImporterName.Text = string.Empty;
        HD_Tr_mode.Value = string.Empty;

        txt_Oportorgin.Text = string.Empty;
        txt_OPortShipment.Text = string.Empty;

        txt_Prefix.Text = string.Empty;
        txt_Suffix.Text = string.Empty;
        txtCurrent_Job.Text = string.Empty;
        txtPortOrigin.Text = string.Empty;
        txtPortShipment.Text = string.Empty;
        gvAll.DataSource = null;
        gvAll.DataBind();
    }
    private void Add_Empty_Jobno()
    {
        ddlJobNo.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlJobNo.SelectedIndex = 0;
    }

    private void Add_Empty_BE_Jobno()
    {
        ddl_BE_NO.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_BE_NO.SelectedIndex = 0;
    }

    private DataSet Database_Con_string()
    {
        DataSet ds = new DataSet();
        DataSet dss = new DataSet();
        if (Session["COMPANY_DETAILS_DS"] != null)
        {
            ds = (DataSet)Session["COMPANY_DETAILS_DS"];

            DataTable ds3 = new DataTable();
            ds3 = ds.Tables[2];
            DataView view1 = ds3.DefaultView;
            string a = ddlWorkingPeriod.SelectedValue.ToString();
            view1.RowFilter = "WORKING_PERIOD = '" + a + "'";
            DataTable table1 = view1.ToTable();
            //-----------------------------------------------------------------//
            dss = WHCS.WH_Select(ObjUBO, table1.Rows[0]["SERVER_NAME"].ToString());
        }
        return dss;
    }
    private DataSet Database_Con_string_Details()
    {
        DataSet ds = new DataSet();
        DataSet dss = new DataSet();
        if (Session["COMPANY_DETAILS_DS"] != null)
        {
            ds = (DataSet)Session["COMPANY_DETAILS_DS"];

            DataTable ds3 = new DataTable();
            ds3 = ds.Tables[2];
            DataView view1 = ds3.DefaultView;
            string a = ddlWorkingPeriod.SelectedValue.ToString();
            view1.RowFilter = "WORKING_PERIOD = '" + a + "'";
            DataTable table1 = view1.ToTable();
            //-----------------------------------------------------------------//
            dss = WHCS.WH_Select_Details(ObjUBO, table1.Rows[0]["SERVER_NAME"].ToString());
        }
        return dss;
    }

   
    protected void gvAll_DataBound(object sender, EventArgs e)
    {

    }
    protected void gvAll_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if (DataBinder.Eval(e.Row.DataItem, "REMAINING_QTY").ToString() == "0.000000")
            {
                if (Connection.COMPANYID().ToString() != "3011") // Added by shanthini on 17-09-2026
                {
                    TextBox txt_Ex_Bond_Qty = (e.Row.FindControl("txt_Ex_Bond_Qty") as TextBox);
                    txt_Ex_Bond_Qty.Attributes.Add("style", "background-color:#F5F5F5;");
                    txt_Ex_Bond_Qty.Attributes.Add("readonly", "readonly");

                    CheckBox chk = (e.Row.FindControl("chk") as CheckBox);
                    chk.Attributes.Add("style", "display:none;");

                }
            }
        }
    }

    protected void gvAll_RowCreated(object sender, GridViewRowEventArgs e)
    {
    }

    private DataTable Item_details()
    {
        hd_error.Value=string.Empty;
        DataTable dtt = new DataTable();
        DataRow dr;

        dtt.Columns.Add(new System.Data.DataColumn("INVOICE_SLNO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("INVOICE_NO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ITEM_SLNO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("Item_Qty", typeof(String)));

        int R = 1;
        foreach (GridViewRow row in gvAll.Rows)
        {
            CheckBox INV_CHECK = (CheckBox)row.FindControl("chk");
            Literal txt_Inv_Slno = (Literal)row.FindControl("txt_Inv_Slno");
            Literal txt_Inv_no = (Literal)row.FindControl("txt_Inv_no");
            Literal txt_Item_Slno = (Literal)row.FindControl("txt_Item_Slno");
            TextBox txt_Ex_Bond_Qty = (TextBox)(row.FindControl("txt_Ex_Bond_Qty"));
            
            if (INV_CHECK.Checked == true)
            {
                
                    Literal txt_Rem_Qty = (Literal)row.FindControl("txt_Rem_Qty");
                    decimal Avl_Qty, Ex_Qty;
                    bool isCompanyId = (Connection.COMPANYID().ToString() == "3011"); // Added by shanthini on 17-09-2026

                    Avl_Qty = Convert.ToDecimal(txt_Rem_Qty.Text);
                    if (Avl_Qty > 0 || isCompanyId)
                    {
                        if (string.IsNullOrWhiteSpace(txt_Ex_Bond_Qty.Text))
                        {
                            Ex_Qty = Avl_Qty;
                        }
                        else
                        {
                            Ex_Qty = Convert.ToDecimal(txt_Ex_Bond_Qty.Text);
                        }

                        if (Ex_Qty > 0)
                        {
                            if (Ex_Qty <= Avl_Qty || isCompanyId)
                            {
                                dr = dtt.NewRow();
                                dr[0] = txt_Inv_Slno.Text;//
                                dr[1] = txt_Inv_no.Text;
                                dr[2] = txt_Item_Slno.Text;//txt_Inv_no
                                // dr[2] = txt_Ex_Bond_Qty.Text;
                                dr[3] = Ex_Qty;
                                dtt.Rows.Add(dr);    
                            }
                            else
                            {
                                hd_error.Value = "INV.Slno : " + txt_Inv_Slno.Text + " , Item. Slno : " + txt_Item_Slno.Text + "  Check Ur Ex-Bond Qty!";
                                dtt.Clear();
                                break;
                            }
                        }
                        else
                        {
                            hd_error.Value = "INV.Slno : " + txt_Inv_Slno.Text + " , Item. Slno : " + txt_Item_Slno.Text + "  Check Ur Ex-Bond Qty!";
                            dtt.Clear();
                            break;
                        }
                    }
            }
        }
        return dtt;
    }
   
    protected void btn_Exbond_Click(object sender, EventArgs e)
    {
        if (ddlJobNo.SelectedValue != string.Empty && txtCurrent_Job.Text != string.Empty)
        {
            DataTable dtt = new DataTable();
            DataSet d_s = new DataSet();
            Session["WAREHOUSE_JOBNO"] = ddlJobNo.SelectedValue.ToString(); // Added by pandiyan on 27-06-2025
            Session["Wkp"] = ddlWorkingPeriod.SelectedValue.ToString(); // Added by pandiyan on 27-06-2025
            ObjUBO.A1 = ddlJobNo.SelectedValue.ToString();
            ObjUBO.A2 = txtCurrent_Job.Text;
            ObjUBO.A3 = "Duplicate_Job";
            ObjUBO.A4 = Database_Name();

            dtt = Item_details();
            if (dtt.Rows.Count > 0)
            {
                String xmlData = ConvertDataTableToXML(dtt);
                d_s=WHCS.Generate_Exbond_Job(ObjUBO, xmlData);
                //i = WHCS.result;

                if (d_s.Tables[0].Rows[0][1].ToString() == "1")
                {
                    Session.Remove("EXBND_JOBID");
                    Session["EXBND_JOBID"] = d_s.Tables[0].Rows[0][0].ToString();
                    Session["Job_PS"] = d_s.Tables[0].Rows[0][0].ToString(); // Added by pandiyan on 27-06-2025
                    Alert_msg("Job Ex-Bonded Successfully", "btn_Exbond");
                    Clear();
                    ddlJobNo.SelectedIndex = -1;
                }
                else
                {
                    Session["EXBND_JOBID"] = "";
                    Alert_msg("Error", "btn_Exbond");
                }
            }
            else
            {
                if (hd_error.Value.ToString() != string.Empty)
                {
                    Alert_msg(hd_error.Value.ToString(), "ddlJobNo");
                }
            }
        }
        else
        {
            Alert_msg("Select Ur Jobno", "ddlJobNo");
        }
    }
    private static string ConvertDataTableToXML(DataTable dtData)
    {
        DataSet dsData = new DataSet();
        StringBuilder sbSQL;
        StringWriter swSQL;
        string XMLformat;
        try
        {
            sbSQL = new StringBuilder();
            swSQL = new StringWriter(sbSQL);
            dsData.Merge(dtData, true, MissingSchemaAction.AddWithKey);
            dsData.Tables[0].TableName = "SampleDataTable";
            foreach (DataColumn col in dsData.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            dsData.WriteXml(swSQL, XmlWriteMode.WriteSchema);
            XMLformat = sbSQL.ToString();
            return XMLformat;
        }
        catch (Exception sysException)
        {
            throw sysException;
        }
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'WareHouse To Ex-Bond', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    private string Database_Name()
    {
        DataSet ds = new DataSet();
        DataSet dss = new DataSet();
        string DB_Name = string.Empty;
        if (Session["COMPANY_DETAILS_DS"] != null)
        {
            ds = (DataSet)Session["COMPANY_DETAILS_DS"];

            DataTable ds3 = new DataTable();
            ds3 = ds.Tables[2];
            DataView view1 = ds3.DefaultView;
            string a = ddlWorkingPeriod.SelectedValue.ToString();
            view1.RowFilter = "WORKING_PERIOD = '" + a + "'";
            DataTable table1 = view1.ToTable();
            //-----------------------------------------------------------------//
            string str = table1.Rows[0]["SERVER_NAME"].ToString();
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };
            string b = string.Empty;

            arr = str.Split(';');
            b = arr[1].ToString();
            arr2 = b.Split('=');
            DB_Name = arr2[1].ToString();
        }
        return DB_Name;
    }
    protected void ddl_BE_NO_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlJobNo.SelectedValue = ddl_BE_NO.SelectedValue.ToString();
        ddlJobNo_SelectedIndexChanged(sender, e);
    }
    protected void ddlWorkingPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_JobNo();
    }
}