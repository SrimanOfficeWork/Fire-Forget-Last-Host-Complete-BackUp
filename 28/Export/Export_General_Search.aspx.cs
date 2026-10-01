using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BussinessObject;

public partial class Export_General_Search : ThemeClass
{
    AppSession aps = new AppSession();
    Export_General_Grid_Search Exp = new Export_General_Grid_Search();
   
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Session["JOBIDexcel"] as string))
            {
                Session.Remove("JOBIDexcel");
            }
            HDBranch.Value = Connection.Get_Company_Type();

            if (Connection.COMPANYID() == "1572")
            {
                ddlterms_load();
            }
            else
            {
                Page_load_Grid();
                Update_SB_Status();
            }
            /*
            if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "115" || Connection.COMPANYID() == "243" || Connection.COMPANYID() == "265" || Connection.COMPANYID() == "286" || Connection.COMPANYID() == "293" || Connection.COMPANYID() == "470" || Connection.COMPANYID() == "517" || Connection.COMPANYID() == "579" || Connection.COMPANYID() == "816" || Connection.COMPANYID() == "829" || Connection.COMPANYID() == "1334" || Connection.COMPANYID() == "1509" || Connection.COMPANYID() == "1586" || Connection.COMPANYID() == "2099" || Connection.COMPANYID() == "2118" || Connection.COMPANYID() == "2145" || Connection.COMPANYID() == "2458" || Connection.COMPANYID() == "2537" || Connection.COMPANYID() == "2835" || Connection.COMPANYID() == "3073" || Connection.COMPANYID() == "3074" || Connection.COMPANYID() == "3087" || Connection.COMPANYID() == "3089" || Connection.COMPANYID() == "3140" || Connection.COMPANYID() == "3158" || Connection.COMPANYID() == "3172" || Connection.COMPANYID() == "3198")
            {
                btn_PDF_Reader_AI.Visible = true;
            }
            */
            /*
            if (Connection.Export_OCR() == "T")
            {
                btn_PDF_Reader_AI.Visible = true;
            }

            if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "816" || Connection.COMPANYID() == "1586" || Connection.COMPANYID() == "2099" || Connection.COMPANYID() == "3335" || Connection.COMPANYID() == "3344")
            {
                btn_Excel_Reader.Visible = true;
            }
            if (Connection.COMPANYID() == "607" || Connection.COMPANYID() == "10")
            {
                btn_XML_Json_Reader.Visible = true;
            }*/
            if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "510" || Connection.COMPANYID() == "816")
            {
                btn_Track_Status.Style["display"] = "block";
            }
            else
            {
                btn_Track_Status.Style["display"] = "none";
            }
            
        }
    }
    private void Page_load_Grid()
    {
        ViewState["AZ"] = "";
        ddlterms_load();
        Exp.SEARCH_CAT = "";
        Exp.SEARCH_ITEM = "";
        Exp.EXPORTER_NAME = "";
        Exp.TRANSPORT_MODE = "";
        Exp.CUSTOMS_HOUSE = "";
        Exp.Selected_Index = "1";
        ds=Exp.EXP_General_Search();
        Load_Grid(ds);

    }

    private void Load_Grid(DataSet dss)
    {
        try
        {
            DataTable dt = new DataTable();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvdetails.DataSource = ds.Tables[0];
                gvdetails.DataBind();
                Add_Pageno(Exp.result);
            }
            else
            {
                gvdetails.DataSource = dt;
                gvdetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ViewState["AZ"] = "";
        Load_Search("1");
    }
    protected void ddlSelectPageno_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["AZ"].ToString() != string.Empty)
            {
                Exp.SEARCH_CAT = "";
                Exp.SEARCH_ITEM = "";
                Exp.EXPORTER_NAME = ViewState["AZ"].ToString();
                Exp.TRANSPORT_MODE = "";
                Exp.CUSTOMS_HOUSE = "";
            }
            else
            {
                if (ddlTerms.SelectedValue != "0" && txtsearch.Text != string.Empty)
                {
                    Exp.SEARCH_CAT = ddlTerms.SelectedValue.ToString();
                    Exp.SEARCH_ITEM = txtsearch.Text;
                    Exp.EXPORTER_NAME = "";
                    Exp.TRANSPORT_MODE = "";
                    Exp.CUSTOMS_HOUSE = "";
                }
                else
                {
                    Exp.SEARCH_CAT = "";
                    Exp.SEARCH_ITEM = "";
                    Exp.EXPORTER_NAME = txtExporterName.Text;
                    Exp.TRANSPORT_MODE = ddlTransportMode.SelectedValue.ToString();
                    Exp.CUSTOMS_HOUSE = txtCustomsHouse.Text;
                }
            }

            Exp.Selected_Index = ddlSelectPageno.SelectedValue.ToString();
            ds = Exp.EXP_General_Search();
            DataTable dt = new DataTable();

            if (ds.Tables[0].Rows.Count > 0)
            {
                gvdetails.DataSource = ds.Tables[0];
                gvdetails.DataBind();
            }
            else
            {
                gvdetails.DataSource = dt;
                gvdetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Load_Search(string Selected_Value)
    {
        try
        {
            if (ddlTerms.SelectedValue != "0" && txtsearch.Text != string.Empty)
            {
                Exp.SEARCH_CAT = ddlTerms.SelectedValue.ToString();
                Exp.SEARCH_ITEM = txtsearch.Text;
                Exp.EXPORTER_NAME = "";
                Exp.TRANSPORT_MODE = "";
                Exp.CUSTOMS_HOUSE = "";
            }
            else
            {
                Exp.SEARCH_CAT = "";
                Exp.SEARCH_ITEM = "";
                Exp.EXPORTER_NAME = txtExporterName.Text;
                Exp.TRANSPORT_MODE = ddlTransportMode.SelectedValue.ToString();
                Exp.CUSTOMS_HOUSE = txtCustomsHouse.Text;
            }
            Exp.Selected_Index = Selected_Value;
            ds = Exp.EXP_General_Search();
            Load_Grid(ds);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        Page_load_Grid();
    }
    protected void btn_A_TO_Z_Search_Click(object sender, EventArgs e)
    {
        try
        {
            txtsearch.Text = string.Empty;
            ddlTerms.SelectedIndex = -1;
            if (hdn_A_to_Z_Search.Value.ToString() != string.Empty)
            {
                ViewState["AZ"] = hdn_A_to_Z_Search.Value.ToString();
                Exp.SEARCH_CAT = "";
                Exp.SEARCH_ITEM = "";
                Exp.EXPORTER_NAME = hdn_A_to_Z_Search.Value.ToString();
                Exp.TRANSPORT_MODE = "";
                Exp.CUSTOMS_HOUSE = "";
                Exp.Selected_Index = "1";
                ds = Exp.EXP_General_Search();
                Load_Grid(ds);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Session.Contents.Remove("Client_Master_Job_edit");
        string jobno = string.Empty;
        string rowID = String.Empty;
        string job_dt = string.Empty;
        string Exp_name = string.Empty;


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values = this.gvdetails.DataKeys[e.Row.RowIndex]["JOBID"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            // Call the PARENT window's Export_General_Update (E_royal_Impex_Main.aspx, via
            // js/iframepopupwin.js) instead of this page's own copy, so the popup (dhtmlmodal)
            // renders in the top-level document and covers the whole screen - header/topbar
            // included - instead of being confined to this page's own #mainiframecontainer box.
            // Mirrors the identical fix on Transaction/General_Search.aspx.cs's own ondblclick
            // (General_Details_Update) - this page only ever loads inside Main's
            // #mainiframecontainer too (see the "Export"/"Export Job" menu items, both
            // target="maineroyal"). Falls back to the local copy only if this page is ever
            // opened standalone (no parent).
            e.Row.Attributes.Add("ondblclick",
                "if(window.parent && window.parent !== window && window.parent.Export_General_Update){ window.parent.Export_General_Update('" + values + "'); } else { Export_General_Update('" + values + "'); }");
            jobno = this.gvdetails.DataKeys[e.Row.RowIndex]["JOBNO"].ToString();
            string mode = this.gvdetails.DataKeys[e.Row.RowIndex]["TRANSPORT_MODE"].ToString();
            job_dt = this.gvdetails.DataKeys[e.Row.RowIndex]["JOBDATE"].ToString();
            Exp_name = this.gvdetails.DataKeys[e.Row.RowIndex]["EXPORTER_NAME"].ToString();
            hdn_Jobnops.Value = this.gvdetails.DataKeys[e.Row.RowIndex]["JOBNO_PS"].ToString();
            hdn_Jobno.Value = jobno;
            hdn_ExpName.Value = Exp_name;

            // Get JOBNO_PS from grid data
            string jobno_ps = DataBinder.Eval(e.Row.DataItem, "JOBNO_PS").ToString();

            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + jobno + "','" + values + "','" + mode + "','" + job_dt + "','" + Exp_name.Replace("'", "") + "','" + jobno_ps.Replace("'", "") + "' )");


            if (DataBinder.Eval(e.Row.DataItem, "JOB_FILED_STATUS").ToString() == "Created")
            {
                e.Row.ForeColor = System.Drawing.Color.Black;
            }
            else if (DataBinder.Eval(e.Row.DataItem, "JOB_FILED_STATUS").ToString() == "SB_Sent")
            {
                e.Row.ForeColor = System.Drawing.Color.Blue;
                e.Row.Font.Bold = true;
            }
            else if (DataBinder.Eval(e.Row.DataItem, "JOB_FILED_STATUS").ToString() == "Cancelled")
            {
                e.Row.ForeColor = System.Drawing.Color.Red;
            }
            else if (DataBinder.Eval(e.Row.DataItem, "JOB_FILED_STATUS").ToString() == "SB_Recipt")
            {
                e.Row.ForeColor = System.Drawing.Color.Green;
                e.Row.Font.Bold = true;
            }
            else if (DataBinder.Eval(e.Row.DataItem, "JOB_FILED_STATUS").ToString() == "LEO_Recvd")
            {
                e.Row.ForeColor = System.Drawing.Color.Maroon;
                e.Row.Font.Bold = true;
            }
        }
    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
  
    protected void ChangePage(object sender, CommandEventArgs e)
    {
       
    }
    public void Add_Pageno(int p)
    {
        if (p != 0)
        {
            ddlSelectPageno.Items.Clear();
            for (int i = 1; i <= p; i++)
            {
                ddlSelectPageno.Items.Add(Convert.ToString(i));
            }
        }
    }
    private void ddlterms_load()
    {
        //ddlTerms.Items.Add(new ListItem(" ", "0"));
        ddlTerms.Items.Add(new ListItem("Job No", "JOB_NO"));
        ddlTerms.Items.Add(new ListItem("Invoice No", "INV_NO"));
        ddlTerms.Items.Add(new ListItem("Container No", "CON_NO"));
        ddlTerms.Items.Add(new ListItem("MAWB No", "MAWB_NO"));
        ddlTerms.Items.Add(new ListItem("HAWB No", "HAWB_NO"));
        ddlTerms.Items.Add(new ListItem("SB No", "SB_NO"));
        ddlTerms.Items.Add(new ListItem("File Ref.no", "FILE_REF_NO"));
        ddlTerms.Items.Add(new ListItem("Item Desc", "ITEM_DESC"));
        ddlTerms.Items.Add(new ListItem("STR Code", "STR_CODE"));

        ddlTerms.Items.Add(new ListItem("Consignee Name", "Consignee_Name"));
        ddlTerms.Items.Add(new ListItem("Country", "SEEK_COUNTRY"));
        ddlTerms.Items.Add(new ListItem("Port Discharge", "Port_Discharge"));
        ddlTerms.Items.Add(new ListItem("License No", "License_No"));
        ddlTerms.Items.Add(new ListItem("AR4 No", "SEEK_AR4"));
    }
    private void Update_SB_Status()
    {
        Global_variables ObjUBO = new Global_variables();
        Imp_Exp_Job_Status IEJ = new Imp_Exp_Job_Status();
        ObjUBO.A3 = "SB_Status_Update";
        IEJ.Job_Status(ObjUBO);
    }

}