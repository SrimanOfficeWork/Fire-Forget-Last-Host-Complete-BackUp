using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Net;
using iTextSharp.text.pdf.qrcode;


public partial class E_Inv_Cancellation_Entry : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();

    E_Inv_Cancellation_Entry_cs EC = new E_Inv_Cancellation_Entry_cs();
    Global_variables ObjUBO = new Global_variables();
    DataTable dt = new DataTable();

    public int i, Screen_Id;
    public string SCREEN_ID, PAGE_MODIFY, PAGE_DELETE, COMPANY_LICENSE;

    string Imp_name = string.Empty, J_no = string.Empty, Ch_type = string.Empty;
    public bool chk = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        COMPANY_LICENSE = Connection.Company_License().ToLower();
        CalendarExtender1.EndDate = DateTime.Today;

        if (COMPANY_LICENSE == "eri00293")
        {
            txtInvoiceNo.Attributes.Add("readonly", "readonly");
            txtInvoiceNo.Style.Add("background-color", "#F0F0F0");
        }

        if (!Page.IsPostBack)
        {
            DataTable dtt = new DataTable();
            GV.DataSource = dtt;
            GV.DataBind();
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 11;
            //----------------SETTING SCREEN PERMISSION---------------//
            txttax_amt.Attributes.Add("readonly", "readonly");
            txt_Expense_Amt.Attributes.Add("readonly", "readonly");
            txt_total_amt.Attributes.Add("readonly", "readonly");
            txt_nontax_Amt.Attributes.Add("readonly", "readonly");
            txt_grand_total.Attributes.Add("readonly", "readonly");
            txt_tax_Amt.Attributes.Add("readonly", "readonly");

            if (Request.QueryString["Page"] == null)
            {
                load_Invno();
                txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                HDupdate_id.Value = "";
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    Update_Item_Load();
                    ViewState["UPDATED_ID"] = Request.QueryString["Billinvno"].ToString();

                    txtInvoiceNo.Enabled = false;
                    HD_Showcon.Value = "SAVED";
                }
            }
        }
        txt_Cus_name.Attributes.Add("onblur", "javascript:CallServerside_Customer('" + txt_Cus_name.ClientID + "', '" + txtInvoiceNo.ClientID + "')");
    }
    private void Update_Item_Load()
    {
        DataSet dss = new DataSet();
        ObjUBO.A4 = Request.QueryString["Billinvno"].ToString();
        ObjUBO.A7 = Request.QueryString["IMP_EXP"].ToString();
        ObjUBO.A12 = Request.QueryString["Page"].ToString();
        ObjUBO.A40 = "Billing_Updated_Data";
        dss = EC.e_Inv_Cancel_Select(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            //-----------------------BA--S---------------------------------------
            HDupdate_id.Value = dss.Tables[0].Rows[0]["ID"].ToString();
            HDupdate_IMP_EXP_id.Value = dss.Tables[0].Rows[0]["IMP_EXP"].ToString();

            txtInvoiceNo.Text = dss.Tables[0].Rows[0]["BILL_INV_NO"].ToString();
            txtDate.Text = dss.Tables[0].Rows[0]["BILL_INV_DATE"].ToString();
            txt_Cus_name.Text = dss.Tables[0].Rows[0]["PARTY_NAME"].ToString();

            ddl_state_name.SelectedValue = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();
            txt_GSTN_Id.Text = dss.Tables[0].Rows[0]["GSTN_ID"].ToString();
            txt_Party_Add.Text = dss.Tables[0].Rows[0]["PARTY_ADDRESS"].ToString();
            ddlbank_name.SelectedValue = dss.Tables[0].Rows[0]["BANK_AC_NO"].ToString();

            txtAccHead.Text = dss.Tables[0].Rows[0]["ACC_HEAD"].ToString();
            txtPONumber.Text = dss.Tables[0].Rows[0]["PO_NO"].ToString();
            txt_Shipper_name.Text = dss.Tables[0].Rows[0]["SHIPPER_NAME"].ToString();
            txt_Expense_Amt.Text = dss.Tables[0].Rows[0]["EXPENSE_AMT"].ToString();

            if (dss.Tables[0].Rows[0]["JOB_STATUS"].ToString() == "C")
            {
                if (dss.Tables[0].Rows[0]["UNAPPROVAL_APPROVED"].ToString() == "A")
                {
                    btn_EInvoice.Visible = true;
                    if (dss.Tables[10].Rows.Count > 0)
                    {
                        lbl_E_inv_msg.Text = "E-Invoice generated.";
                        btn_EInvoice.Visible = false;
                    }
                    else
                    {
                        btn_EInvoice.Text = "Generate Einvoice";
                    }
                }
            }

            txt_Remarks.Text = dss.Tables[0].Rows[0]["REMARKS"].ToString();
            txt_Hss.Text = dss.Tables[0].Rows[0]["HSS_CODE"].ToString();
            txt_Parma_Code.Text = dss.Tables[0].Rows[0]["PARMA_CODE"].ToString();
            txt_Work_Id.Text = dss.Tables[0].Rows[0]["WORK_ID"].ToString();

            txt_nontax_Amt.Text = dss.Tables[0].Rows[0]["NON_TAXABLE_AMT"].ToString();
            txt_tax_Amt.Text = dss.Tables[0].Rows[0]["TAXABLE_AMT"].ToString();
        }
        if (dss.Tables[1].Rows.Count > 0)
        {
            gv_Jobno.DataSource = dss.Tables[1];
            gv_Jobno.DataBind();
        }
        else
        {
            gv_Jobno.DataSource = dt;
            gv_Jobno.DataBind();
        }

        if (dss.Tables[2].Rows.Count > 0)
        {
            gv_Gen.DataSource = dss.Tables[2];
            gv_Gen.DataBind();
        }
        else
        {
            gv_Gen.DataSource = dt;
            gv_Gen.DataBind();
        }
        if (dss.Tables[3].Rows.Count > 0)
        {
            gv_IGM.DataSource = dss.Tables[3];
            gv_IGM.DataBind();
        }
        else
        {
            gv_IGM.DataSource = dt;
            gv_IGM.DataBind();
        }
        if (dss.Tables[4].Rows.Count > 0)
        {
            gv_Inv.DataSource = dss.Tables[4];
            gv_Inv.DataBind();
        }
        else
        {
            gv_Inv.DataSource = dt;
            gv_Inv.DataBind();
        }
        if (dss.Tables[5].Rows.Count > 0)
        {
            gv_Item.DataSource = dss.Tables[5];
            gv_Item.DataBind();
        }
        else
        {
            gv_Item.DataSource = dt;
            gv_Item.DataBind();
        }
        if (dss.Tables[6].Rows.Count > 0)
        {
            gv_BE_SB.DataSource = dss.Tables[6];
            gv_BE_SB.DataBind();
        }
        else
        {
            gv_BE_SB.DataSource = dt;
            gv_BE_SB.DataBind();
        }
        if (dss.Tables[7].Rows.Count > 0)
        {
            gv_Chg_Details.DataSource = dss.Tables[7];
            gv_Chg_Details.DataBind();

            DataTable firstTable = dss.Tables[7];
            ViewState["CurrentTable"] = firstTable;
        }
        else
        {
            SetInitialRow();
        }

        if (dss.Tables[8].Rows.Count > 0)
        {
            gv_Gen_Annexure.DataSource = dss.Tables[8];
            gv_Gen_Annexure.DataBind();
            gv_Gen_Annexure.Rows[0].BackColor = System.Drawing.Color.Orange;
            gv_Gen_Annexure.Rows[0].ForeColor = System.Drawing.Color.Black;
        }
        else
        {
            gv_Gen_Annexure.DataSource = dt;
            gv_Gen_Annexure.DataBind();
        }
    }
    private void load_Invno()
    {
        try
        {
            ddl_Invno.Items.Clear();
            DataSet dss = new DataSet();
            ObjUBO.A40 = "E_Invno_Select";
            dss = EC.e_Inv_Cancel_Select(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                ddl_Invno.DataSource = dss.Tables[0];
                ddl_Invno.DataTextField = "BILL_INV_NO";
                ddl_Invno.DataValueField = "BILL_INV_NO";
                ddl_Invno.DataBind();
            }
            ddl_Invno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Invno.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void gvAll_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Height = 20;
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'e Invoice Cancellation', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'e Invoice Cancellation', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    private void Clear()
    {
        txtInvoiceNo.Text = string.Empty;
        ch_Behalf.Checked = false;
        txt_Cus_name.Text = string.Empty;
        txt_Party_Add.Text = string.Empty;
        txttax_amt.Text = string.Empty;
        ddl_state_name.Text = string.Empty;
        txt_GSTN_Id.Text = string.Empty;
        txt_Expense_Amt.Text = string.Empty;
        txt_Remarks.Text = string.Empty;
        txt_tax_Amt.Text = string.Empty;
        txt_nontax_Amt.Text = string.Empty;

        txt_Hss.Text = string.Empty;
        txt_Parma_Code.Text = string.Empty;
        txt_Work_Id.Text = string.Empty;
        lbl_Irn_no.Text = string.Empty;
        lbl_GSTNID.Text = string.Empty;
    }
    protected void gv_Chg_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string Ch_name_select = string.Empty;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            TextBox txtamt = (e.Row.FindControl("txtamt") as TextBox);
            TextBox txtCGST_RATE = (e.Row.FindControl("txtCGST_RATE") as TextBox);
            TextBox txtSGST_RATE = (e.Row.FindControl("txtSGST_RATE") as TextBox);
            TextBox txtIGST_RATE = (e.Row.FindControl("txtIGST_RATE") as TextBox);
            TextBox txtCGST_AMT = (e.Row.FindControl("txtCGST_AMT") as TextBox);
            TextBox txtSGST_AMT = (e.Row.FindControl("txtSGST_AMT") as TextBox);
            TextBox txtIGST_AMT = (e.Row.FindControl("txtIGST_AMT") as TextBox);

            Ch_name_select = this.gv_Chg_Details.DataKeys[e.Row.RowIndex]["CHARGE_VALUE"].ToString();
            DropDownList ddlchname = (e.Row.FindControl("txtch_name") as DropDownList);

            txtamt.Attributes.Add("readonly", "readonly");
            txtCGST_RATE.Attributes.Add("readonly", "readonly");
            txtSGST_RATE.Attributes.Add("readonly", "readonly");
            txtIGST_RATE.Attributes.Add("readonly", "readonly");
            txtIGST_AMT.Attributes.Add("readonly", "readonly");
            txtCGST_AMT.Attributes.Add("readonly", "readonly");
            txtSGST_AMT.Attributes.Add("readonly", "readonly");

            //---------------------

            DropDownList ddlch_name = (e.Row.FindControl("txtch_name") as DropDownList);
            if (ViewState["CurrentTable_Ch"] != null && ViewState["CurrentTable_Ch"] != string.Empty)
            {
                DataSet dtt = (DataSet)ViewState["CurrentTable_Ch"];
                ddlch_name.DataSource = dtt.Tables[0];
                ddlch_name.DataTextField = "CHARGE_NAME";
                ddlch_name.DataValueField = "CHARGE_VALUE";
                ddlch_name.DataBind();
            }
            else
            {
                DataSet ss = new DataSet();
                ss = load_Charge_Name();
                ViewState["CurrentTable_Ch"] = ss;
                ddlch_name.DataSource = ss;
                ddlch_name.DataTextField = "CHARGE_NAME";
                ddlch_name.DataValueField = "CHARGE_VALUE";
                ddlch_name.DataBind();
            }

            ddlch_name.Items.Insert(0, new ListItem(""));
            ddlch_name.Items.FindByValue(Ch_name_select).Selected = true;

            //--------------------------------------------------------------------------
        }
        //https://www.aspsnippets.com/Articles/Dynamically-add-DropDownList-in-ASPNet-GridView-using-C-and-VBNet.aspx
        //https://www.aspsnippets.com/Articles/Get-Selected-Value-from-DropDownList-in-GridView-in-ASPNet.aspx
    }
    private DataSet load_Charge_Name()
    {
        DataSet ds = new DataSet();
        ObjUBO.A40 = "Get_Charge_name_With_Tax";
        return EC.e_Inv_Cancel_Select(ObjUBO);
    }
    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

        dt.Columns.Add(new DataColumn("INV_CHECK", typeof(string)));
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("ORDERBY", typeof(string)));
        dt.Columns.Add(new DataColumn("CHARGE_VALUE", typeof(string)));
        //dt.Columns.Add(new DataColumn("TAX_NONTAX", typeof(string)));
        dt.Columns.Add(new DataColumn("Qty", typeof(string)));
        dt.Columns.Add(new DataColumn("CUR", typeof(string)));
        dt.Columns.Add(new DataColumn("EX_RATE", typeof(string)));
        dt.Columns.Add(new DataColumn("UNIT_RATE", typeof(string)));
        dt.Columns.Add(new DataColumn("AMOUNT", typeof(string)));
        dt.Columns.Add(new DataColumn("CGST_RATE", typeof(string)));
        dt.Columns.Add(new DataColumn("CGST_AMT", typeof(string)));
        dt.Columns.Add(new DataColumn("SGST_RATE", typeof(string)));
        dt.Columns.Add(new DataColumn("SGST_AMT", typeof(string)));
        dt.Columns.Add(new DataColumn("IGST_RATE", typeof(string)));
        dt.Columns.Add(new DataColumn("IGST_AMT", typeof(string)));
        dt.Columns.Add(new DataColumn("CHARGE_DESC", typeof(string)));

        dr = dt.NewRow();
        dr["INV_CHECK"] = "True";
        dr["RowNumber"] = 1;
        dr["ORDERBY"] = string.Empty;
        dr["CHARGE_VALUE"] = string.Empty;
        //dr["TAX_NONTAX"] = "N";
        dr["Qty"] = "1";

        dr["CUR"] = "INR";
        dr["EX_RATE"] = "1";

        dr["UNIT_RATE"] = "0";
        dr["AMOUNT"] = "0";
        dr["CGST_RATE"] = "0";
        dr["CGST_AMT"] = "0";
        dr["SGST_RATE"] = "0";
        dr["SGST_AMT"] = "0";
        dr["IGST_RATE"] = "0";
        dr["IGST_AMT"] = "0";
        dr["CHARGE_DESC"] = string.Empty;
        dt.Rows.Add(dr);

        ViewState["CurrentTable"] = dt;

        gv_Chg_Details.DataSource = dt;
        gv_Chg_Details.DataBind();

        txttax_amt.Text = "0.00";
    }
    protected void gv_Chg_Details_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }
    protected void GV_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }
    protected void GV_Gen_head_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void gv_Gen_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txt_Jobno_I = (e.Row.FindControl("txt_Jobno_I") as TextBox);
            txt_Jobno_I.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_I.Enabled = false;

            TextBox txt_Jobno_PS = (e.Row.FindControl("txt_Jobno_PS_I") as TextBox);
            txt_Jobno_PS.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_PS.Enabled = false;
        }
    }
    protected void gv_IGM_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txt_Jobno_I = (e.Row.FindControl("txt_Jobno_I") as TextBox);
            txt_Jobno_I.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_I.Enabled = false;

            TextBox txt_Jobno_PS = (e.Row.FindControl("txt_Jobno_PS_I") as TextBox);
            txt_Jobno_PS.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_PS.Enabled = false;
        }
    }
    protected void gv_Inv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txt_Jobno_II = (e.Row.FindControl("txt_Jobno_II") as TextBox);
            txt_Jobno_II.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_II.Enabled = false;

            TextBox txt_Jobno_PS_II = (e.Row.FindControl("txt_Jobno_PS_II") as TextBox);
            txt_Jobno_PS_II.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_PS_II.Enabled = false;
        }
    }
    protected void gv_Item_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txt_Jobno_II = (e.Row.FindControl("txt_Jobno_I") as TextBox);
            txt_Jobno_II.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_II.Enabled = false;

            TextBox txt_Jobno_PS_II = (e.Row.FindControl("txt_Jobno_PS_I") as TextBox);
            txt_Jobno_PS_II.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_PS_II.Enabled = false;
        }
    }
    protected void gv_BE_SB_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txt_Jobno_II = (e.Row.FindControl("txt_Jobno_I") as TextBox);
            txt_Jobno_II.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_II.Enabled = false;

            TextBox txt_Jobno_PS_II = (e.Row.FindControl("txt_Jobno_PS_I") as TextBox);
            txt_Jobno_PS_II.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_PS_II.Enabled = false;
        }
    }
    protected void gv_Gen_Annexure_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }
    //RR--------------------------------------------------------------------s

    protected void gv_Jobno_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

    protected void btn_Generate_EInvoice_Click(object sender, EventArgs e)
    {
        if (ddl_Invno.SelectedValue.ToString() != string.Empty)
        {
            if (ddl_Cancel_Reason.SelectedValue.ToString() != string.Empty)
            {
                if (lbl_Irn_no.Text != string.Empty)
                {
                    if (lbl_GSTNID.Text != string.Empty)
                    {
                        load_Inv_Data();
                    }
                    else
                    {
                        Alert_msg("Invalid GSTNID !");
                    }
                }
                else
                {
                    Alert_msg("Invalid IRN No !");
                }
            }
            else
            {
                Alert_msg("Select Ur Reason for Cancellaion !", "ddl_Cancel_Reason");
            }
        }
        else
        {
            Alert_msg("Select Ur Invoice No !", "ddl_Invno");
        }
    }
    private void load_Inv_Data()
    {
        DataSet ds = new DataSet();
        ObjUBO.A2 = txtInvoiceNo.Text;
        ObjUBO.A40 = "Select_E_Invoice_Details";
        ds = EC.e_Inv_Cancel_Select(ObjUBO);
        string alertMessage = "";

        if (ds.Tables[0].Rows.Count > 0)
        {
            string Bill_No = ds.Tables[0].Rows[0]["BILL_INV_NO"].ToString();
            string tax_amt = ds.Tables[0].Rows[0]["TAX_AMT"].ToString();
            string Non_Tax = ds.Tables[0].Rows[0]["NON_TAX_AMT"].ToString();
            string Total_Amt = ds.Tables[0].Rows[0]["TOTAL_AMT"].ToString();
            string cgst_Amt = ds.Tables[0].Rows[0]["CGST_AMT"].ToString();
            string sgst_amt = ds.Tables[0].Rows[0]["SGST_AMT"].ToString();
            string Igst_Amt = ds.Tables[0].Rows[0]["IGST_AMT"].ToString();
            string Total_Inv_val = ds.Tables[0].Rows[0]["TotInvVal"].ToString();
            string Bill_To = ds.Tables[0].Rows[0]["local"].ToString();

            string lineWidth = "20%";
            alertMessage = "<table style='width:100%;height:80%'>" +
       "<tr><td style='width:30%;'>Invoice No</td><td style='text-align:left;'>: <span style='color: red;'>" + Bill_No +
       "</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style='color: black;'>Bill To: </span><span style='color: #8E4585;'>" + Bill_To + "</span></td></tr>" +
       "<tr><td style='width:30%;'>Tax Amt</td><td style='text-align:left;'>: <span style='color: #191970;'>" + tax_amt + "</span></td></tr>" +
       "<tr><td style='width:30%;'>Non Tax Amt</td><td style='text-align:left;'>: <span style='color: #191970;'>" + Non_Tax + "</span></td></tr>" +
       "<tr><td colspan='2' style='text-align:left;'><hr style='width: " + lineWidth + "; margin: auto; margin-left: 150px;'/></td></tr>" +
       "<tr><td style='width:30%;'>Total Amt</td><td style='text-align:left;'>: <span style='color: #800020;'>" + Total_Amt + "</span></td></tr>" +
       "<tr><td colspan='2' style='text-align:center;'><hr style='width: " + lineWidth + "; margin: auto; margin-left:150px;'/></td></tr>" +
       "<tr><td style='width:30%;'>CGST</td><td style='text-align:left;'>: <span style='color: green;'>" + cgst_Amt + "</span></td></tr>" +
       "<tr><td style='width:30%;'>SGST</td><td style='text-align:left;'>: <span style='color: green;'>" + sgst_amt + "</span></td></tr>" +
       "<tr><td style='width:30%;'>IGST</td><td style='text-align:left;'>: <span style='color: #4B0082;'>" + Igst_Amt + "</span></td></tr>" +
       "<tr><td colspan='2' style='text-align:center;'><hr style='width: " + lineWidth + "; margin: auto; margin-left:150px;'/></td></tr>" +
       "<tr><td style='width:30%;'>Grand Total</td><td style='text-align:left;'>: <span style='color: blue;'>" + Total_Inv_val + "</span></td></tr>" +
       "<tr><td colspan='2' style='text-align:center;'><hr style='width: " + lineWidth + "; margin: auto; margin-left:150px;'/></td></tr>" +
       "</table>" +
       "<span>Do you want to proceed with generating the e-invoice?</span>";

        }
        Alert_Einvoice(alertMessage);
    }
    public void Alert_Einvoice(string msg)
    {
        int dialogWidth = 530, dialogHeight = 348;
        string buttonId = Btn_Generate_Inv.ClientID;
        string prompt = "<script>" + "$(document).ready(function() {" + "$('<div></div>').dialog({" + "modal: true," + "title: 'E-Invoice Cancellation Charges'," +
        "width: " + dialogWidth + "," + "height: " + dialogHeight + "," + "buttons: {" + "'OK': function() {" + "$(this).dialog('close');" + "setTimeout(function() {" +
        "document.getElementById('" + buttonId + "').click();" + "}, 0);" + "}," + "'Cancel': function() {" + "$(this).dialog('close');" + "}" + "}," + "open: function() {" +
        "$(this).html('" + msg.Replace("'", "\\'").Replace("\n", "\\n") + "');" + "$(this).dialog('option', 'position', { my: 'center', at: 'top', of: window });" +
        "$(this).css({'overflow': 'hidden'}); " + "}," + "create: function() {" + "$(this).parent().find('.ui-dialog-buttonpane button').css({" + "'width': '50px'," +
        "'height': '5px'," + "'padding': '1px 1px', " + "'margin': '2px' " + "});" + "}" + "});" + "});" + "</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btn_EInvoice_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string filepath = string.Empty;
        filepath = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" 
            + Session["currentuser"].ToString() + "/"+"E_INVOCICE_CANCEL");
        if (Directory.Exists(filepath) == false)
        {
            Directory.CreateDirectory(filepath);
        }

        DirectoryInfo dir = new DirectoryInfo(filepath);
        foreach (FileInfo fi in dir.GetFiles())
        {
            fi.Delete();
        }
        string jsonOut = string.Empty;
        jsonOut = "{" + @"""" + "einvoiceusername" + @"""" + ":" + @"""" + lbl_GSTNID.Text + @"""" + "," + @"""" + "Invoice" + @"""" + ":{" +
        @"""" + "Irn" + @"""" + ":" + @"""" + lbl_Irn_no.Text + @"""" + "," + @"""" + "CnlRsn" + @"""" + ":" + @"""" + ddl_Cancel_Reason.SelectedValue.ToString() + @"""" +
        "," + @"""" + "CnlRem" + @"""" + ":" + @"""" + txt_Inv_Cancel_Remarks.Text + @"""" + "}}";
        System.IO.File.WriteAllText(filepath + "Inv_" + txtInvoiceNo.Text.Replace('/', '_') + ".JSON", jsonOut);
        HttpContext.Current.ApplicationInstance.CompleteRequest();

       SubmitInvoice(jsonOut, txtInvoiceNo.Text);
    }
   
    private void SubmitInvoice(string _invoiceJSONString, string _Invno)
    {
        DataSet dss = new DataSet();
        string result = "",AccessToken = "", urla = "";
        string reqstr = _invoiceJSONString;
        if (COMPANY_LICENSE == "eri00480" || COMPANY_LICENSE == "eri01019" || COMPANY_LICENSE == "eri01176" || COMPANY_LICENSE == "eri01277")
         {
            AccessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImp0aSI6IjZmNjZiZGU1MGIxMjYyYmU4YTA4YjEyODkzNTI0ZDIwYTY5NmUxMmY4MmFlZGNkNTY3YzA0MDU0OGI1NGVhODMzMTY4NjVmMDU4YzgxMjJlIn0.eyJhdWQiOiIxIiwianRpIjoiNmY2NmJkZTUwYjEyNjJiZThhMDhiMTI4OTM1MjRkMjBhNjk2ZTEyZjgyYWVkY2Q1NjdjMDQwNTQ4YjU0ZWE4MzMxNjg2NWYwNThjODEyMmUiLCJpYXQiOjE3Njg3OTk1NTUsIm5iZiI6MTc2ODc5OTU1NSwiZXhwIjo0OTI0NDczMTU0LCJzdWIiOiI1Iiwic2NvcGVzIjpbXX0.nqLwPrt2J1flFdHaUzxfDfD8l4xk5RfCcDXgfvywuVBcGap5Gcc3KfkJvEKCZYq901m2VXbdQSn4vKmLHRqXDhkMR2q77pxhLWQTzyYvA9vmFapFxUd3os9uiD0LkKo4zXABkulzzKgPNBvtiG_ka4Ims-FQNmg-dcrdgMZJC5xTwk2v8aeJUtD3dn7RJff4m-EjCL0EpU3a5wZv6XckaGK7VSQKeINaQn2sCwaaG53IcfKpiKK5LEVjAvBtu2vt_cEj_BaAKu88tbGdl5VFT7DhoiNqnwshrxWXRIBQtHU_VhIPrLNBRS4qSGqTzITYiyegX10aqhhY-TgGUJaYOpr-u9Gl9_hLaSUzMBJZdqFRNWhVcqpdeuh2JD30wSowAhI44MFJ9ScNDSLrQMSBPGAaGR-0MxzfNr5wQ5AJ82G_DyqjlO4wUMJYOJzeYEV-2ERhTsLZswiAbp-mNUMdqcOzGujv8SyvyWi_Fqta4hKmt8PeHXrUhKP8rHp8RUCV3bYKtBfSyCyWY38OvJHIDcMnayhg46LVaNZVRxPlnNP0YS02ClUm8eqjinqMAG3-8Ef7Rt18xSm4J_j5klkY0SR_Ngi7wGTQK9UvpIJK-vbrME_OsZwxP3-gOcZUi_ku0zRKsiaA88VdWdPGOXyMdgq31cFiAID_ggAf36RLNqA";
            urla = "http://einvoice.mazeworkssolutions.com/maze_eserver/public/api/einvoicecancel";
         }
        else if (COMPANY_LICENSE == "eri01011" || COMPANY_LICENSE == "eri01280")
        {
            AccessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImp0aSI6ImI2ZTQ2ZTI4YmMzM2NmMWNjN2IxMmU4MDg4OWNjMDE0ODIyMjA2NWEzMmJjYTE4ZGY1M2JiZmM3MzFhYWM5YmQ3MjU1YzAwNTkwOGQ4NDJmIn0.eyJhdWQiOiIxIiwianRpIjoiYjZlNDZlMjhiYzMzY2YxY2M3YjEyZTgwODg5Y2MwMTQ4MjIyMDY1YTMyYmNhMThkZjUzYmJmYzczMWFhYzliZDcyNTVjMDA1OTA4ZDg0MmYiLCJpYXQiOjE3Njg3OTk1ODMsIm5iZiI6MTc2ODc5OTU4MywiZXhwIjo0OTI0NDczMTgzLCJzdWIiOiI0Iiwic2NvcGVzIjpbXX0.fZgd1o8XDVlnlzUHzuQqdJQEMWm1iSheNYKSIKW10flDX5X-A0gU7nNBOs8M5c7assG9i5Si7rOIkAtTAv7zXoX-HwSrRA6k5n-1X906enAnGttiD-tzqa8K6KT4wuCnGguOUDk4j6YojPK_QaGPLnft8IZTMJXIXyp748URexsDD8WPnfdp7hhgd-f_60EeOuA0v6ieITX1TSZxaKDKfK26g0xUhBf06dUCMkQotqZlvPHQf025g4ZbeFu3KtC-p-B3qXCQmOKJBQrBHaKcuQOfx-FjKqPqHHDTdUN627vDEUK8URueQlSgcyqIHDad1LbuSz5anv1CaCacfQtQY1plOob7Joh8lY70s_HvPlSiu_TYA1r1xxwswpgFqSjbWJuk3rVyxOFL8J9CfGtQOq4aD6slgc-M2X-SSk5y0LzVJV1TJjCA9Z27fNk1bhWFsRxCsFt-sDcSwSPYDCMLIVcm3_kt8cj06R-w2-NaZgHUts7JyZY6xo5aTXHbU_hSVNN8mF7IgE0C46qe6EGgslKudXKwAZvcq00k-uaVzD-qfigNfWI9QAatPurFqW_IoFcYlUvwv6mUIFA3gARDdHe0gcclAuPqsIAwRg7T7trTKRG2GR_9kVo3PJLEnq6F6P59Qq5Fi3SSxvESvCs7ZT8vWKPyeytZEIGilYS1uzU";
            urla = "http://einvoice.mazeworkssolutions.com/maze_eserver/public/api/einvoicecancel";

        }
        else if (COMPANY_LICENSE == "eri03267")
        {
            AccessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIzIiwianRpIjoiNmZkOWYwMmExN2ZkYjY3Y2M2NjgzMGEwMTA4MTdiYmIyYWE1NTMxOGY0NTIyM2Q1OTBjMDdmNTYwOWU2YjgyZDA2NzA1NmIyODQ2NmJkNGEiLCJpYXQiOjE3ODQ2MzI0OTQuMjcwMDExLCJuYmYiOjE3ODQ2MzI0OTQuMjcwMDEzLCJleHAiOjE4MTYxNjg0OTQuMjY3OTg0LCJzdWIiOiI0MSIsInNjb3BlcyI6W119.FG3whGizqFIk3pJiAqE3qpMLetNfr_0IDxzvkwASXQ_YN9Z_fty0yvElje1q43kIvRV91d83iRbp0Q6wEGbhi2gWfRCSIodCZETHt4rbzGMIb_8o1ZiRuMyzBFOzhc9PVrE8axgm6U3glXsmVW6eIJb_Wiggn7WMUgFvwzKlNHXp9ziEVtJVxXd9kMOGnL-RC8BY0y_Di-_l_1hw1njKZqDlblfaJP2ws_S4b_PyCxeutavGwvExO-GgAHC_tlAULtz4wUfkR0S6pvmcqWzXzeyFsnCYwgjibtdhSx3eTutUS7gawPYAnvpdRHpRfLdacxTIVBurHMVQZvJUhqh6F9fMYzHORg5eYwFdGJgIZmWO6ZqMGcdaTbMUvPCOy75WE-OBF6UUVexnYoc3D-y5JV5hta_PmeTQeZvT2oxRyr6KJD4uSbDU_MFU7Oz2qFHupgGX0ifCxigfGuUqTix_igtHQwfpmhZRJNqaAjzYtEbPJbtl0Wnl8DdKMuPrlsNJxlx5NCYj230iGXmrnr0x0Nad7bTbsYx8iE36VTE5d4P0-wX-SXDEzI6jynd1xVOwCC90GPaG0Eq3xko100m0321l8QfKQ6RYFyFxC4lcw_IARTdkDM4RiFcZTAIZ_z66Il7Moh3oBAVuNrG7CNv8UEA9yqmdO2tuq2N_HyLiDPk";
            urla = "http://einvoice.mazeworkssolutions.com/maze_eserver/public/api/einvoicecancel";
        }
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urla);
        request.Method = "POST";
        request.Headers.Add("Authorization", "Bearer " + AccessToken);
        request.ContentType = "application/json; charset=utf-8";

        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        {
            streamWriter.Write(reqstr);
            streamWriter.Flush();
            streamWriter.Close();
        }
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        if (response.StatusCode == HttpStatusCode.OK)
        {
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
        }
        if (result != "")
        {
            string jsonResult = result;

                jsonResult = jsonResult.Replace("{", "")
                                       .Replace("}", "")
                                       .Replace("\"", "")
                                       .Replace("\r", "")
                                       .Replace("\n", "")
                                       .Replace(" ", "");
                jsonResult = jsonResult.Replace("server_status:", "")
                                       .Replace("Irn:", "")
                                       .Replace("CnlRsn:", "")
                                       .Replace("CnlRem:", "")
                                       .Replace("expirydate:", "")
                                       .Replace("RemainingDays:", "")
                                       .Replace("ActivationDate:", "")
                                       .Replace("remainingcount:", "");
                string[] Resut_Res = jsonResult.Split(',');
              
                if (Resut_Res.Length >= 8 && Resut_Res[0] == "success")
                {

                    string status = Resut_Res[0];
                    string Irn = Resut_Res[1];
                    string CnlRsn = Resut_Res[2];
                    string CnlRem = Resut_Res[3];
                    string expirydate = Resut_Res[4];
                    string RemainingDays = Resut_Res[5];
                    string ActivationDate = Resut_Res[6];
                    string remainingcount = Resut_Res[7];
                    ObjUBO.A1 = "";
                    ObjUBO.A2 = Rd_Imp_Exp.SelectedValue.ToString();
                    ObjUBO.A3 = txtInvoiceNo.Text;
                    ObjUBO.A4 = Irn;
                    ObjUBO.A12 = "WebService";
                    ObjUBO.A14 = ddl_Cancel_Reason.SelectedValue;
                    ObjUBO.A15 = txt_Inv_Cancel_Remarks.Text;
                    ObjUBO.A16 = "S";

                    dss = EC.e_Inv_Cancellation(ObjUBO);
                    
                    if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                    {
                        btn_EInvoice.Visible = false;
                        Alert_msg("e Invoice Cancelled Successfully");
                    }
                    else
                    {
                        Alert_msg("Save Failed");
                    }
                

                }
                else
                {
                    Alert_msg("Not Success" + result);
                }
            }
            else
            {
                Alert_msg("Not Success" + result);
            }
        }
       


    protected void ddl_Invno_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddl_Invno.SelectedValue.ToString() != string.Empty)
            {
                Load_Data();
            }
            else
            {
                Clear();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
    private void Load_Data()
    {
        DataSet dss = new DataSet();
        ObjUBO.A2 = ddl_Invno.SelectedValue.ToString();
        ObjUBO.A40 = "e_Inv_Data";
        dss = EC.e_Inv_Cancel_Select(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            //-----------------------BA--S---------------------------------------
            HDupdate_id.Value = dss.Tables[0].Rows[0]["ID"].ToString();
            HDupdate_IMP_EXP_id.Value = dss.Tables[0].Rows[0]["IMP_EXP"].ToString();
            Rd_Imp_Exp.SelectedValue = dss.Tables[0].Rows[0]["IMP_EXP"].ToString();

            lbl_Bill_Type.Text = dss.Tables[0].Rows[0]["REG_SEZ"].ToString();
            lbl_Trans.Text = dss.Tables[0].Rows[0]["TR_YN"].ToString();

            txtInvoiceNo.Text = dss.Tables[0].Rows[0]["BILL_INV_NO"].ToString();
            txtDate.Text = dss.Tables[0].Rows[0]["BILL_INV_DATE"].ToString();

            lbl_Cus_Name.Text = dss.Tables[0].Rows[0]["CUS_NAME"].ToString();
            txt_Cus_name.Text = dss.Tables[0].Rows[0]["PARTY_NAME"].ToString();

            ddl_state_name.SelectedValue = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();
            txt_GSTN_Id.Text = dss.Tables[0].Rows[0]["GSTN_ID"].ToString();
            txt_Party_Add.Text = dss.Tables[0].Rows[0]["PARTY_ADDRESS"].ToString();
            ddlbank_name.SelectedValue = dss.Tables[0].Rows[0]["BANK_AC_NO"].ToString();

            txtAccHead.Text = dss.Tables[0].Rows[0]["ACC_HEAD"].ToString();
            txtPONumber.Text = dss.Tables[0].Rows[0]["PO_NO"].ToString();
            txt_Shipper_name.Text = dss.Tables[0].Rows[0]["SHIPPER_NAME"].ToString();
            txt_Expense_Amt.Text = dss.Tables[0].Rows[0]["EXPENSE_AMT"].ToString();
            txt_Remarks.Text = dss.Tables[0].Rows[0]["REMARKS"].ToString();
            txt_Hss.Text = dss.Tables[0].Rows[0]["HSS_CODE"].ToString();
            txt_Parma_Code.Text = dss.Tables[0].Rows[0]["PARMA_CODE"].ToString();
            txt_Work_Id.Text = dss.Tables[0].Rows[0]["WORK_ID"].ToString();

            txt_nontax_Amt.Text = dss.Tables[0].Rows[0]["NON_TAXABLE_AMT"].ToString();
            txt_tax_Amt.Text = dss.Tables[0].Rows[0]["TAXABLE_AMT"].ToString();

        }
        if (dss.Tables[1].Rows.Count > 0)
        {
            gv_Jobno.DataSource = dss.Tables[1];
            gv_Jobno.DataBind();
        }
        else
        {
            gv_Jobno.DataSource = dt;
            gv_Jobno.DataBind();
        }

        if (dss.Tables[2].Rows.Count > 0)
        {
            gv_Gen.DataSource = dss.Tables[2];
            gv_Gen.DataBind();
        }
        else
        {
            gv_Gen.DataSource = dt;
            gv_Gen.DataBind();
        }
        if (dss.Tables[3].Rows.Count > 0)
        {
            gv_IGM.DataSource = dss.Tables[3];
            gv_IGM.DataBind();
        }
        else
        {
            gv_IGM.DataSource = dt;
            gv_IGM.DataBind();
        }
        if (dss.Tables[4].Rows.Count > 0)
        {
            gv_Inv.DataSource = dss.Tables[4];
            gv_Inv.DataBind();
        }
        else
        {
            gv_Inv.DataSource = dt;
            gv_Inv.DataBind();
        }
        if (dss.Tables[5].Rows.Count > 0)
        {
            gv_Item.DataSource = dss.Tables[5];
            gv_Item.DataBind();
        }
        else
        {
            gv_Item.DataSource = dt;
            gv_Item.DataBind();
        }
        if (dss.Tables[6].Rows.Count > 0)
        {
            gv_BE_SB.DataSource = dss.Tables[6];
            gv_BE_SB.DataBind();
        }
        else
        {
            gv_BE_SB.DataSource = dt;
            gv_BE_SB.DataBind();
        }
        if (dss.Tables[7].Rows.Count > 0)
        {
            try
            {
                gv_Chg_Details.DataSource = dss.Tables[7];
                gv_Chg_Details.DataBind();

                DataTable firstTable = dss.Tables[7];
                ViewState["CurrentTable"] = firstTable;
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }

        }
        else
        {
            SetInitialRow();
        }

        //if (dss.Tables[8].Rows.Count > 0)
        //{
        //    gv_Gen_Annexure.DataSource = dss.Tables[8];
        //    gv_Gen_Annexure.DataBind();
        //    gv_Gen_Annexure.Rows[0].BackColor = System.Drawing.Color.Orange;
        //    gv_Gen_Annexure.Rows[0].ForeColor = System.Drawing.Color.Black;
        //}
        //else
        //{
        //    gv_Gen_Annexure.DataSource = dt;
        //    gv_Gen_Annexure.DataBind();
        //}
        lbl_Ackno.Text = "";
        lbl_Ackdate.Text = "";
        lbl_Irn_no.Text = "";
        lbl_GSTNID.Text = "";

        if (dss.Tables[8].Rows.Count > 0)
        {
            lbl_Ackno.Text = dss.Tables[8].Rows[0]["ACKNO"].ToString();
            lbl_Ackdate.Text = dss.Tables[8].Rows[0]["ACKDT"].ToString();
            lbl_Irn_no.Text = dss.Tables[8].Rows[0]["IRN_NO"].ToString();
            lbl_GSTNID.Text = dss.Tables[8].Rows[0]["GSTNID"].ToString();
        }
    }

}