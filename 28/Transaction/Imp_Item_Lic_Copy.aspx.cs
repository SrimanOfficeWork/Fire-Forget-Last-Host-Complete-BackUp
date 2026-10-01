using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Services;

public partial class Imp_Item_Lic_Copy : ThemeClass
{
    AppSession aps = new AppSession();

    public int i;

    Imp_Invcopy IIC = new Imp_Invcopy();
    adminmaster adm = new adminmaster();

    string ddl_load_Job_no = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!Page.IsPostBack)
        {
            if (Session["IMPORT_JOBNO"] != null && Session["Invoice_SLNO"] != null)
            {
                // load_Item_dec();

            }
            Empty_grid();
            LoadJobNo();
        }

    }

    protected void btnNew_Click1(object sender, EventArgs e)
    {
        ddlinvno.SelectedIndex = -1;
        ddlinvno_SelectedIndexChanged(sender, e);
        LoadJobNo();
    }
    protected void gv_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.CssClass = "header";
        }

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";


        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";


        if (gv_Details.Rows.Count > 0)                                  //-----------Diana-Changes--------------//
        {
            CheckBox chkbox = (CheckBox)GV.HeaderRow.FindControl("chkSelectAll");
            chkbox.Visible = true;
        }

    }
    protected void gv_RowCreated(object sender, GridViewRowEventArgs e)                 //----------------Add New Function Diana--------------------//
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.CssClass = "header";
            CheckBox chkSelectAll = new CheckBox();
            chkSelectAll.ID = "chkSelectAll";
            chkSelectAll.Checked = false;
            // chkSelectAll.CheckedChanged += new EventHandler(chkSelectAll_CheckedChanged);
            //chkSelectAll.AutoPostBack = true;
            TableCell headerCell = new TableCell();
            headerCell.Controls.Add(chkSelectAll);
            headerCell.Width = Unit.Pixel(30);
            e.Row.Cells.AddAt(0, headerCell);
        }

    }

    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)              //----------------Add New Function Diana--------------------//
    {
        CheckBox chkSelectAll = (CheckBox)sender;
        foreach (GridViewRow row in gv_Details.Rows)
        {
            CheckBox chkBox = (CheckBox)row.FindControl("chk_inv");
            if (chkBox != null)
            {
                chkBox.Checked = chkSelectAll.Checked;
            }
        }

    }


    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Invoice', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    //-------------------------------------Added New----------------------------------------------//
    public void LoadJobNo()       //New Changes -20-03-2025
    {
        DataSet ds = new DataSet();
        IIC.Flag = "Load_License_Jobs";
        ds = IIC.Imp_Lic_Copy_Select();
        DataRow dr = ds.Tables[0].NewRow();
        ddlJobNo.DataSource = ds.Tables[0];
        ddlJobNo.DataTextField = "JOBNO";
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataBind();
        if (ds.Tables[0].Rows[0][0] == "Select")
        {
            ddlJobNo.Items.Insert(0, new ListItem("", ""));
        }
    }

    private void load_Item_dec()
    {
        DataSet ds = new DataSet();
        try
        {
            if (ddl_load_Job_no != "" && ddl_load_Job_no != "Select")
            {
                ddlinvno.Items.Clear();
                IIC.Jobno = ddl_load_Job_no;
                IIC.Flag = "Imp_Jobno_select";
                IIC.Inv_slno = Session["Invoice_SLNO"].ToString();
                ds = IIC.Imp_Lic_Copy_Select();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].Rows.Add("Select", "0");
                    var sortedRows = ds.Tables[0].AsEnumerable().OrderBy(row => row["LICENSE_ID"]);
                    ddlinvno.DataSource = sortedRows.CopyToDataTable();
                    ddlinvno.DataTextField = "Lic_details";
                    ddlinvno.DataValueField = "LICENSE_ID";
                    ddlinvno.DataBind();
                }
            }
            else
            {
                DataTable dt = new DataTable();
                ddlinvno.DataSource = dt;
                ddlinvno.DataTextField = "Lic_details";
                ddlinvno.DataValueField = "LICENSE_ID";
                ddlinvno.DataBind();

            }
            ddl_Scheme.Text = "";
            ddl_Item_Scheme.SelectedValue = "All";
            Empty_grid();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>ShowAlert('" + ex.Message.ToString() + "')</script>", false);
        }
    }

    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ddl_load_Job_no = ddlJobNo.SelectedValue.ToString();
        load_Item_dec();
    }

    protected void ddlItemScheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlinvno_SelectedIndexChanged(sender, e);

    }

    protected void SelectedItem_CheckBox(object sender, EventArgs e)
    {
        List<DataRow> selectedRows = new List<DataRow>();
        foreach (GridViewRow row in gv_Details.Rows)
        {
            CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");

            if (chkSelect != null && chkSelect.Checked)
            {
                //SCHEME_CODE.
            }
        }

    }
    protected void ddlinvno_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_load_Job_no = ddlJobNo.SelectedValue.ToString();
        try
        {
            if (ddlinvno.SelectedItem.ToString() != "Select")
            {
                    DataSet ds = new DataSet();
                    IIC.Jobno = Session["IMPORT_JOBNO"].ToString();
                    string lic_reg_no = ddlinvno.SelectedItem.Text;
                    string[] Lic_reg_No;
                    Lic_reg_No = lic_reg_no.Split(':', ' ');
                    IIC.Lic_Reg_No = Lic_reg_No[2].ToString();
                    IIC.Flag = "Imp_Jobno_Data";
                    IIC.Inv_slno = Session["Invoice_SLNO"].ToString();
                    IIC.Copy_Job_No = ddlJobNo.SelectedValue;
                    ds = IIC.Imp_Lic_Copy_Select();
                    Imp_Checklist_Item_License Item_License = new Imp_Checklist_Item_License();
                    Session["btn_cif_click"] = "";
                    ds.Tables[0].Columns.Add("TOTAL_CIF_AMOUNT");
                    ds.Tables[0].Columns.Add("REM_DEBIT_AMOUNT");
                    ds.Tables[0].Columns.Add("TOTAL_DEBIT_DUTY_FINAL");
                    ds.Tables[0].Columns.Add("REM_DEBIT_DUTY_VALUE");
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        IIC.Inv_slno = dr.ItemArray[3].ToString();
                        IIC.Item_slno = dr.ItemArray[4].ToString();
                        //Item_License.Page_Load_Item_Details(IIC.Inv_slno, IIC.Item_slno);//hide on 31-12-2025
                        Item_License.Page_Load_Item_Details(IIC.Inv_slno, IIC.Item_slno, "", "");
                        string TOTAL_DEBIT_DUTY_FINAL = Session["TOTAL_DEBIT_DUTY_FINAL"].ToString();
                        string INDIVITUAL_CIF_AMOUNT = Session["INDIVITUAL_CIF_AMOUNT"].ToString();
                        INDIVITUAL_CIF_AMOUNT = INDIVITUAL_CIF_AMOUNT == "" ? "0.00" : INDIVITUAL_CIF_AMOUNT;
                        TOTAL_DEBIT_DUTY_FINAL = TOTAL_DEBIT_DUTY_FINAL == "" ? "0.00" : TOTAL_DEBIT_DUTY_FINAL;
                        dr["TOTAL_CIF_AMOUNT"] = INDIVITUAL_CIF_AMOUNT;
                        dr["TOTAL_DEBIT_DUTY_FINAL"] = TOTAL_DEBIT_DUTY_FINAL;
                        dr["REM_DEBIT_AMOUNT"] = Convert.ToDouble(INDIVITUAL_CIF_AMOUNT) - (Convert.ToDouble(dr.ItemArray[13].ToString()));
                        dr["REM_DEBIT_DUTY_VALUE"] = Convert.ToDouble(TOTAL_DEBIT_DUTY_FINAL) - (Convert.ToDouble(string.IsNullOrEmpty(dr.ItemArray[14].ToString()) ? "0.00" : dr.ItemArray[17].ToString()));
                     }
                   
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        CheckBox chkGV = (CheckBox)GV.HeaderRow.FindControl("chkSelectAll");   //---Diana_changes----------------//
                        chkGV.Width = System.Web.UI.WebControls.Unit.Pixel(46);

                        HttpContext.Current.Session["INVOICE_NO"] = ds.Tables[0].AsEnumerable().Where(row => row.Field<string>("INVOICE_NO") != null).Select(row => row.Field<string>("INVOICE_NO")).FirstOrDefault();
                        if (ddl_Item_Scheme.SelectedValue != "All" && ddl_Item_Scheme.SelectedValue.ToString() != "")
                        {
                            gv_Details.DataSource = ds.Tables[0].AsEnumerable().Where(row => row.Field<string>("SCHEME_CODE").Contains(ddl_Item_Scheme.SelectedValue)).CopyToDataTable();
                            gv_Details.DataBind();
                        }
                        else   //New Changes -20-03-2025
                        {
                            gv_Details.DataSource = ds.Tables[0];
                            gv_Details.DataBind();
                            ddl_Item_Scheme.DataSource = ds.Tables[1];                        
                            ddl_Item_Scheme.DataTextField = "SCHEME_CODE";
                            ddl_Item_Scheme.DataValueField = "SCHEME_CODE";
                            ddl_Item_Scheme.DataBind();
                        }  
                        //-----------------------------------DIANA License-Scheme -----------------------------------------------//
                        ddl_Scheme.Text = ds.Tables[0].Rows[0][11].ToString();
                        ddl_Scheme.ForeColor = System.Drawing.Color.Black;
                        //-----------------------------------END -----------------------------------------------//
                        //---------------------------------------DIANA JOBNO-Scheme--------------------------------------------//
                        //-----------------------------------END -----------------------------------------------//
                    }
                    else
                    {
                        Empty_grid();
                    }

                    scheme_NOTN();
            }
            else
            {
                Empty_grid();
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>ShowAlert('" + ex.Message.ToString() + "')</script>", false);
        }
    }

    private void Empty_grid()
    {
        DataTable dt = new DataTable();
        gv_Details.DataSource = dt;
        gv_Details.DataBind();

        GV.DataSource = dt;
        GV.DataBind();
        CheckBox chkGV = (CheckBox)GV.HeaderRow.FindControl("chkSelectAll");   //---Diana_changes----------------//
        chkGV.Visible = false;
        ddl_Item_Scheme.SelectedValue = "Select";
        ddl_Scheme.Text = "";
    }
    protected void btncopy_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            if (gv_Details.Rows.Count > 0)
            {
                DataTable dtt = new DataTable();
                DataRow dr;
                dtt.Columns.Add(new System.Data.DataColumn("INVOICE_SLNO", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("ITEM_SLNO", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("SCHEME", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("DEBIT_QTY", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("TOTAL_DEBIT_AMT", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("REM_DEBIT_AMT", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("TOTAL_DEBIT_DUTY", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("REM_DEBIT_DUTY", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("WORKING_PERIOD", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("UNIT_QTY", typeof(String)));
                int R = 0;
                foreach (GridViewRow row in gv_Details.Rows)
                {
                    CheckBox chk = (CheckBox)gv_Details.Rows[R].Cells[0].FindControl("chk_inv");
                    if (chk.Checked == true)
                    {
                        TextBox Dbt_QTY = (TextBox)row.FindControl("txt_Dbt_amt");
                        TextBox REM_Dbt_QTY = (TextBox)row.FindControl("txt_Dbt_amt");
                        TextBox TOT_DEB_AMT = (TextBox)row.FindControl("txt_tot_Dbt_amt");
                        TextBox REM_DEB_AMT = (TextBox)row.FindControl("txt_Rem_Dbt_amt");
                        TextBox TOT_DEB_DUTY = (TextBox)row.FindControl("txt_TOT_Dbt_DUTY");
                        TextBox REM_DEB_DUTY = (TextBox)row.FindControl("txt_Rem_Dbt_DUTY");
                        DropDownList ddldbt_Qty_code = (DropDownList)row.FindControl("ddldbt_Qty_code");
                        dr = dtt.NewRow();
                        dr[0] = gv_Details.Rows[R].Cells[2].Text;
                        dr[1] = gv_Details.Rows[R].Cells[3].Text;
                        dr[2] = ddl_Scheme.Text;
                        dr[3] = Dbt_QTY.Text;
                        dr[4] = TOT_DEB_AMT.Text;
                        dr[5] = REM_DEB_AMT.Text;
                        dr[6] = TOT_DEB_DUTY.Text;
                        dr[7] = REM_DEB_DUTY.Text;
                        dr[8] = Connection.WorkingPeriod();
                        dr[9] = ddldbt_Qty_code.SelectedValue.ToString();
                        dtt.Rows.Add(dr);
                    }
                    R = R + 1;
                }
                DataSet dsData = new DataSet();
                dsData.Tables.Add(dtt);
                string errorMSG = "";
                foreach (DataRow dr1 in dsData.Tables[0].Rows)  // Changed 
                {

                    if (dr1.ItemArray[3].ToString() == "0" || dr1.ItemArray[5].ToString() == "0")               
                    {  
                        if (dr1.ItemArray[3].ToString() == "0" && dr1.ItemArray[5].ToString() == "0")
                        {
                            errorMSG = "Invalid Debit Qty and Debit Amount";
                        }
                        else {

                            if (dr1.ItemArray[3].ToString() == "0")
                            {
                                errorMSG = "Invalid Debit Qty";
                            }
                            if (dr1.ItemArray[5].ToString() == "0")
                            {
                                errorMSG = "Invalid Debit Amount";
                            }
                        }
                    }                                                                                         //Changes Ended

                    if (Convert.ToDouble(dr1.ItemArray[5].ToString()) > Convert.ToDouble(dr1.ItemArray[4].ToString()))
                    {
                        errorMSG = "Debit CIF Amount Over From Total CIF Amount";
                    }
                    else if (dr1.ItemArray[6].ToString() != "0.00")
                    {
                        if (Convert.ToDouble(dr1.ItemArray[7].ToString()) > Convert.ToDouble(dr1.ItemArray[6].ToString()))
                        {
                            errorMSG = "Debit Duty Over From Total Duty";
                        }
                    }
                }
                if (errorMSG != "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>ShowAlert('" + errorMSG + "')</script>", false);
                    return;
                }
                else
                {
                    if (dsData.Tables[0].Rows.Count > 0)
                    {
                        String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
                        IIC.Jobno = Session["IMPORT_JOBNO"].ToString();
                        IIC.Inv_slno = Session["Invoice_SLNO"].ToString();
                        IIC.Lic_Id = ddlinvno.SelectedValue.ToString();
                        IIC.Flag = "Imp_lic_dup";
                        IIC.Xml_D = xmlData;
                        IIC.Priority_Type = ddlPriority.SelectedValue;
                        string[] lic_Reg_no = ddlinvno.SelectedItem.Text.Split(':', ' ');
                        IIC.Lic_Reg_No = lic_Reg_no[2];
                        IIC.Copy_Job_No = ddlJobNo.SelectedValue;
                        IIC.Inv_no = Session["INVOICE_NO"].ToString();
                        IIC.JobNo_Ps = Session["JOBNO_PS"].ToString();
                        IIC.Scheme_Notn = ddlScheme_NOTN.SelectedValue.ToString();
                        IIC.Scheme_Notn_Slno = ddlScheme_NOTN_SL.SelectedValue.ToString();

                        ds = IIC.Imp_Lic_Copy_Select();
                        Imp_Checklist_Item_License Item_License = new Imp_Checklist_Item_License();
                        //Item_License.Page_Load_Item_Details(IIC.Inv_slno, ITEM_SLNO);
                        //throw new Exception("Invalid Error example example example example example example");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>ShowAlert('" + ds.Tables[0].Rows[0][0].ToString() + "')</script>", false);
                            CheckBox chkGV = (CheckBox)GV.HeaderRow.FindControl("chkSelectAll");   //---Diana_changes----------------//
                            chkGV.Checked = false;
                        }
                    }

                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>ShowAlert('" + ex.Message.ToString() + "')</script>", false);
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

    protected void ddlScheme_NOTN_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            //ddlScheme_NOTN_SL.Enabled = true;
            scheme_notn_slno();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>CTH_tab();</script>", false);
        }
    }

    public void scheme_NOTN()
    {
        string str = ddl_Scheme.Text;
        string[] s1 = str.Split(new string[] { "-" }, StringSplitOptions.None);

        ddlScheme_NOTN.Items.Clear();
        ddlScheme_NOTN_SL.Items.Clear();

        if (s1[0].Trim().ToString() != "00")
        {
            adm.SCHEME_IMPORT_CODE = s1[0].ToString();
            adm.SCHEME_NOTN = "0";
            adm.name = "SCHEME_NOTN";
            ddlScheme_NOTN.DataSource = adm.RetrieveAll_Scheme_Import();
            ddlScheme_NOTN.DataTextField = "SCHEME_NOTN";
            ddlScheme_NOTN.DataValueField = "SCHEME_NOTN";
            ddlScheme_NOTN.Items.Add(" ");
            ddlScheme_NOTN.DataBind();
            //--7-2r
            scheme_notn_slno();

        }
        else
        {
            ddlScheme_NOTN.Items.Clear();
            ddlScheme_NOTN_SL.Items.Clear();
        }
    }


    public void scheme_notn_slno()
    {
       
        string str = ddl_Scheme.Text;
        string[] s1 = str.Split(new string[] { "-" }, StringSplitOptions.None);
        ddlScheme_NOTN_SL.Items.Clear();

        adm.SCHEME_IMPORT_CODE = s1[0].ToString();
        adm.SCHEME_NOTN = ddlScheme_NOTN.SelectedValue;
        adm.name = "SCHEME_NOTN_SLNO";
        ddlScheme_NOTN_SL.DataSource = adm.RetrieveAll_Scheme_Import();
        ddlScheme_NOTN_SL.DataTextField = "SCHEME_NOTN_SLNO";
        ddlScheme_NOTN_SL.DataValueField = "SCHEME_NOTN_SLNO";
        ddlScheme_NOTN_SL.Items.Add(" ");
        ddlScheme_NOTN_SL.DataBind();
    }

}