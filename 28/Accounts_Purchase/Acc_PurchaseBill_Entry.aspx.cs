using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Acc_PurchaseBill_Entry : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();
    Acc_PurchaseBill_Entry_cs PC = new Acc_PurchaseBill_Entry_cs();
    Global_variables ObjUBO = new Global_variables();

    public int i;
    public string refreshID = string.Empty;
    public string refreshIDFlag = string.Empty;
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
            if (!Page.IsPostBack)
            {

                txtNetPayable.Attributes.Add("readonly", "readonly");

                DataTable dt = new DataTable();
                DataTable dtt = new DataTable();

                dt.Columns.Add("Currency");
                dt.Columns.Add("ExRate");
                dt.Columns.Add("ConvCurrency");
                dt.Rows.Add("USD", "", "INR");
                gvExchangeRate.DataSource = dt;
                gvExchangeRate.DataBind();

                btnJrnNew.Visible = false;
                txt_Posting_Date.Text = DateTime.Now.ToString("dd/MM/yyyy");
                Load_Organisation_Name();

                if (Request.QueryString["PC_ID"] == null || Request.QueryString["PC_ID"] == "")
                {
                    Load_PurchaseBill_No();
                    btnsup.Text = "Save";
                    btn_PC_Delete.Visible = false;
                    dt.Columns.Add("PCL_ID");
                    gv_details.DataSource = dtt;
                    gv_details.DataBind();
                }
                else
                {
                    if (Request.QueryString["PC_ID"] != null && Request.QueryString["PC_ID"] != string.Empty)
                    {
                        btnsup.Text = "Update";
                        btn_PC_Delete.Visible = true;
                        btnJrnNew.Visible = true;
                        Update_Item_Load();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Load_Organisation_Name()
    {
        DataSet ds = new DataSet();
        ddl_org_name.Items.Clear();
        ObjUBO.A40 = "load_pc_Org_vendor_names";
        ds = PC.PC_Header_Select(ObjUBO);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ViewState["OrgVendNames"] = ds.Tables[0];
            ddl_org_name.DataSource = ds.Tables[0];
            ddl_org_name.DataTextField = "OrgName";
            ddl_org_name.DataValueField = "OrgName";
            ddl_org_name.DataBind();
        }
        ddl_org_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_org_name.SelectedIndex = 0;
    }

    protected void ddl_org_name_SelectedIndexChanged(object sender, EventArgs e)
    {

        DataSet ds = new DataSet();
        ddl_Br_no.Items.Clear();

        if (ddl_org_name.SelectedValue.ToString() != string.Empty)
        {
            ObjUBO.A8 = ddl_org_name.SelectedValue.ToString();
            ObjUBO.A40 = "load_pc_Org_vendor_Br_no";
            ds = PC.PC_Header_Select(ObjUBO);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                ddl_Br_no.DataSource = ds.Tables[0];
                ddl_Br_no.DataTextField = "Br_no";
                ddl_Br_no.DataValueField = "Br_no";
                ddl_Br_no.DataBind();

                ddl_Br_no.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddl_Br_no.SelectedIndex = 0;

                if (ds != null && ds.Tables[0].Rows.Count == 1)
                {
                    ddl_Br_no.SelectedValue = ds.Tables[0].Rows[0]["Br_no"].ToString();
                    hfOrgStateGstId.Value = ds.Tables[0].Rows[0]["GSTSTATE"].ToString();
                    hfchkol.Value = ds.Tables[0].Rows[0]["OTHERLOCAL"].ToString();
                }

            }
        }
        else
        {

        }
    }

    protected void gv_details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

    protected void gv_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string rowID = String.Empty;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values = this.gv_details.DataKeys[e.Row.RowIndex]["PCL_ID"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_Purchase_Entry_Details_Update('" + values + "')");
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "')");
            e.Row.Font.Bold = true;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblReferenceNo = (Label)e.Row.FindControl("lblreferenceNo");
            string JobRefNarattion = DataBinder.Eval(e.Row.DataItem, "REF_NO").ToString();
            lblReferenceNo.ToolTip = JobRefNarattion;
            if (JobRefNarattion.Length > 50)
            {
                lblReferenceNo.Text = JobRefNarattion.Substring(0, 30) + "...";
            }
            else
            {
                lblReferenceNo.Text = JobRefNarattion;
            }
        }
    }

    protected void gv_details_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string[] keys = e.CommandArgument.ToString().Split('~');
        string pclid = keys[0];

        if (e.CommandName == "DeleteRow")
        {
            try
            {
                ObjUBO.A1 = pclid;
                ObjUBO.A40 = "PC_del_detail_record";
                ds = PC.PC_Header_Select(ObjUBO);
                if (ds.Tables.Count == 0)
                {
                    ObjUBO.A1 = HDupdate_id.Value;
                    ObjUBO.A40 = "pc_select_for_Update";
                    DataSet dsr = PC.PC_Header_Select(ObjUBO);
                    if (dsr.Tables[0].Rows.Count > 0)
                    {
                        txtTax.Text = dsr.Tables[0].Rows[0]["TAX_AMOUNT"].ToString();
                        txtGrandTotal.Text = dsr.Tables[0].Rows[0]["GRAND_TOTAL"].ToString();
                        ddlTDS.SelectedValue = dsr.Tables[0].Rows[0]["TDS_SECTION"].ToString();
                        txtTDSPercent.Text = dsr.Tables[0].Rows[0]["TDS_PERCENT"].ToString();
                        txtTDSAmount.Text = dsr.Tables[0].Rows[0]["TDS_AMOUNT"].ToString();
                        chkRoundOff.Checked = dsr.Tables[0].Rows[0]["ROUND_OFF_FLAG"].ToString() == "1";
                        txtGrossPayable.Text = dsr.Tables[0].Rows[0]["GROSS_PAYABLE"].ToString();
                        txtAdvance.Text = dsr.Tables[0].Rows[0]["ADVANCE_AMOUNT"].ToString();
                        txtNetPayable.Text = dsr.Tables[0].Rows[0]["NET_PAYABLE"].ToString();
                    }
                    if (dsr.Tables[1].Rows.Count > 0)
                    {
                        gv_details.DataSource = dsr.Tables[1];
                        gv_details.DataBind();

                        CalculateTotals(dsr.Tables[1]);
                    }
                    else
                    {
                        gv_details.DataSource = dt;
                        gv_details.DataBind();
                        CalculateTotals(dsr.Tables[1]);
                    }
                    /*if (ds.Tables.Count > 1 && ds.Tables[2].Rows.Count > 0)
                    {
                        txtTax.Text = ds.Tables[2].Rows[0]["TOTAL_SUMMARYTAX"].ToString();
                        txtGrandTotal.Text = ds.Tables[2].Rows[0]["GRANDTOTAL"].ToString();
                        txtGrossPayable.Text = ds.Tables[2].Rows[0]["GRANDTOTAL"].ToString();
                        txtNetPayable.Text = ds.Tables[2].Rows[0]["GRANDTOTAL"].ToString();
                    }
                    else
                    {
                        gv_details.DataSource = dt;
                        gv_details.DataBind();
                    } */

                    Alert_msg("Row Deleted Successfully!");

                }
                else
                {
                    Alert_msg("Row Not Deleted!");
                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Purchase Entry', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Purchase Entry', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    //function to check for record Delete.
    protected void btn_PC_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_PC_No_M.Text != string.Empty)
            {
                if (txt_PC_Entry_Date.Text != string.Empty)
                {
                    ds = PC_Ins_Upd("Delete");
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        Alert_msg("Deleted Successfully!", "btn_Cp_Delete");
                        btnsup.Text = "Save";
                        btn_PC_Delete.Visible = false;
                        ClearControls();
                        refreshID = HDupdate_id.Value;
                        refreshIDFlag = "refresh";
                        Update_Item_Load();
                        Load_PurchaseBill_No();
                    }
                    else
                    {
                        Alert_msg("Not Deleted", "btn_Cp_Delete");
                    }
                }
                else
                {
                    Alert_msg("Enter Ur Invalid Journal Date!", "txt_PC_Entry_Date");
                }
            }
            else
            {
                Alert_msg("Invalid Trans. No!", "txt_PC_No_M");
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    /* clean code function */
    private void Update_Item_Load()
    {
        try
        {
            DataSet dsovn = new DataSet();
            ObjUBO.A40 = "load_pc_Org_vendor_names";
            dsovn = PC.PC_Header_Select(ObjUBO);
            if (dsovn != null && dsovn.Tables.Count > 0 && dsovn.Tables[0].Rows.Count > 0)
            {
                ViewState["OrgVendNames"] = dsovn.Tables[0];
            }

            DataSet dss = new DataSet();
            if (refreshIDFlag == "refresh" && !string.IsNullOrEmpty(refreshID))
            {
                ObjUBO.A1 = refreshID;
            }
            else if (!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["PC_ID"])))
            {
                ObjUBO.A1 = Convert.ToString(Request.QueryString["PC_ID"]);
            }
            ObjUBO.A40 = "pc_select_for_Update";
            ds = PC.PC_Header_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = ds.Tables[0].Rows[0]["PC_ID"].ToString();

                txt_PC_No_F.Text = ds.Tables[0].Rows[0]["PC_P"].ToString();
                txt_PC_No_M.Text = ds.Tables[0].Rows[0]["PC_NO"].ToString();
                txt_PC_No_L.Text = ds.Tables[0].Rows[0]["PC_S"].ToString();

                txt_PC_Entry_Date.Text = ds.Tables[0].Rows[0]["PC_DATE"].ToString();
                txt_Posting_Date.Text = ds.Tables[0].Rows[0]["POSTING_DATE"].ToString();
                txt_PC_Due_Date.Text = ds.Tables[0].Rows[0]["PC_DUE_DATE"].ToString();

                ddl_PC_Cur.SelectedValue = ds.Tables[0].Rows[0]["PC_CUR"].ToString();
                txt_PC_Narration.Text = ds.Tables[0].Rows[0]["PC_NARRATION"].ToString();

                ddl_org_name.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["PC_ORGANISATION"].ToString(), ds.Tables[0].Rows[0]["PC_ORGANISATION"].ToString()));
                ddl_org_name.SelectedIndex = 0;

                ddl_Br_no.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["PC_OR_BR_SLNO"].ToString(), ds.Tables[0].Rows[0]["PC_OR_BR_SLNO"].ToString()));
                ddl_Br_no.SelectedIndex = 0;

                ddl_org_name.Enabled = false;
                ddl_Br_no.Enabled = false;

                txt_Vendor_Invoice_No.Text = ds.Tables[0].Rows[0]["VENDOR_INVOICE_NO"].ToString();
                txt_Vendor_Invoice_Date.Text = ds.Tables[0].Rows[0]["VENDOR_INVOICE_DATE"].ToString();

                einvoice_RefNo.Text = ds.Tables[0].Rows[0]["EINVOICE_REFNO"].ToString();
                /*    
     DataTable dtOrg = ViewState["OrgVendNames"] as DataTable;
     string orgName = ddl_org_name.SelectedValue.Replace("'", "''");
     DataRow[] dr = dtOrg.Select("OrgName = '" + orgName + "'");
     */
                //hfBranchSerialNo.Value = ds.Tables[0].Rows[0]["PC_OR_BR_SLNO"].ToString();
                /*hfOrgStateGstId.Value = dr[0]["GSTSTATE"].ToString();
                hfchkol.Value = dr[0]["OTHERLOCAL"].ToString(); 
                 * */

                txtTax.Text = ds.Tables[0].Rows[0]["TAX_AMOUNT"].ToString();
                txtGrandTotal.Text = ds.Tables[0].Rows[0]["GRAND_TOTAL"].ToString();
                ddlTDS.SelectedValue = ds.Tables[0].Rows[0]["TDS_SECTION"].ToString();
                txtTDSPercent.Text = ds.Tables[0].Rows[0]["TDS_PERCENT"].ToString();
                txtTDSAmount.Text = ds.Tables[0].Rows[0]["TDS_AMOUNT"].ToString();
                txtGrossPayable.Text = ds.Tables[0].Rows[0]["GROSS_PAYABLE"].ToString();
                txtAdvance.Text = ds.Tables[0].Rows[0]["ADVANCE_AMOUNT"].ToString();
                txtNetPayable.Text = ds.Tables[0].Rows[0]["NET_PAYABLE"].ToString();
                chkRoundOff.Checked = ds.Tables[0].Rows[0]["ROUND_OFF_FLAG"].ToString() == "1";
                txt_RoundOffAmt.Text = ds.Tables[0].Rows[0]["ROUNDOFF_AMT"].ToString();
            }

            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                gv_details.DataSource = ds.Tables[1];
                gv_details.DataBind();

                CalculateTotals(ds.Tables[1]);
            }
            else
            {
                gv_details.DataSource = new DataTable();
                gv_details.DataBind();
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                hfOrgStateGstId.Value = ds.Tables[2].Rows[0]["GSTSTATE"].ToString();
                hfchkol.Value = ds.Tables[2].Rows[0]["OTHERLOCAL"].ToString();
            }
            else
            {
                hfOrgStateGstId.Value = "";
                hfchkol.Value = "";
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void CalculateTotals(DataTable dt)
    {
        decimal totalAmt = 0;
        foreach (DataRow dr in dt.Rows)
        {
            totalAmt += Convert.ToDecimal(
                string.IsNullOrEmpty(dr["AMOUNT"].ToString()) ? "0" : dr["AMOUNT"]);
        }
        lbl_Total_Debit.Text = totalAmt.ToString("N2");
    }
    /* --------------------------------------- */
    //Purchase Bill No Load
    private void Load_PurchaseBill_No()
    {
        DataSet ds = new DataSet();
        try
        {
            txt_PC_No_F.Text = string.Empty;
            txt_PC_No_M.Text = string.Empty;
            txt_PC_No_L.Text = string.Empty;
            txt_PC_Entry_Date.Text = string.Empty;
            ObjUBO.A40 = "PC_No_Select";
            ds = PC.PC_Header_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_PC_No_F.Text = ds.Tables[0].Rows[0]["PC_P"].ToString();
                txt_PC_No_M.Text = ds.Tables[0].Rows[0]["PC_NO"].ToString();
                txt_PC_No_L.Text = ds.Tables[0].Rows[0]["PC_S"].ToString();
                txt_PC_Entry_Date.Text = ds.Tables[0].Rows[0]["PC_Date"].ToString();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    //1.1 save function 
    protected void btnsup_Click(object sender, EventArgs e)
    {
        try
        {
            //if (ddl_org_name.SelectedIndex > 0)
            if (ddl_org_name.SelectedValue != string.Empty)
            {
                if (txt_Vendor_Invoice_No.Text.Trim() != string.Empty)
                {
                    if (txt_Vendor_Invoice_Date.Text.Trim() != string.Empty)
                    {
                        if (txt_PC_No_M.Text != string.Empty)
                        {
                            if (txt_PC_Entry_Date.Text != string.Empty)
                            {
                                if (txt_Posting_Date.Text != string.Empty)
                                {
                                    ds = PC_Ins_Upd(btnsup.Text);
                                    if (btnsup.Text == "Save")
                                    {
                                        if (ds.Tables[0].Rows.Count > 0)
                                        {
                                            HDupdate_id.Value = ds.Tables[0].Rows[0][0].ToString();
                                            BindPurchaseHeader(ds);
                                            btnsup.Text = "Update";
                                            btn_PC_Delete.Visible = true;

                                            btnJrnNew.Visible = true;
                                            Alert_msg("Saved Successfully!", "btnsup");
                                        }
                                        else
                                        {
                                            Alert_msg("Not Saved", "btnsup");
                                        }
                                    }
                                    else if (btnsup.Text == "Update")
                                    {
                                        if (ds.Tables[0].Rows.Count > 0)
                                        {
                                            HDupdate_id.Value = ds.Tables[0].Rows[0][0].ToString();
                                            btnsup.Text = "Update";
                                            btn_PC_Delete.Visible = true;
                                            btnJrnNew.Visible = true;
                                            Alert_msg("Updated Successfully!", "btnsup");
                                        }
                                        else
                                        {
                                            Alert_msg("Not Updated", "btnsup");
                                        }
                                    }
                                }
                                else
                                {
                                    Alert_msg("Enter Purchase Posting Date!", "txt_Posting_Date");
                                }
                            }
                            else
                            {
                                Alert_msg("Enter Payment Date!", "txt_PC_Entry_Date");
                            }
                        }
                        else
                        {
                            Alert_msg("Check Purchase Trans. No!", "txt_PC_No_M");
                        }
                    }
                    else
                    {
                        Alert_msg("Enter Vendor Invoice Date!", "txt_Vendor_Invoice_Date");
                    }
                }
                else
                {
                    Alert_msg("Enter Vendor Invoice No!", "txt_Vendor_Invoice_No");
                }
            }
            else
            {
                Alert_msg("Select Organisation!", "ddl_org_name");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    //1.2
    public DataSet PC_Ins_Upd(string flg)
    {
        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A3 = txt_PC_No_F.Text;
        ObjUBO.A4 = txt_PC_No_M.Text;
        ObjUBO.A5 = txt_PC_No_L.Text;

        ObjUBO.A6 = txt_PC_Entry_Date.Text;
        ObjUBO.A7 = txt_Posting_Date.Text;
        ObjUBO.A8 = ddl_org_name.Text;
        ObjUBO.A9 = txt_PC_Due_Date.Text;
        ObjUBO.A10 = ddl_PC_Cur.Text;
        ObjUBO.A11 = txt_Vendor_Invoice_No.Text;
        ObjUBO.A12 = txt_Vendor_Invoice_Date.Text;
        ObjUBO.A13 = txt_PC_Narration.Text;
        ObjUBO.A14 = ddl_Br_no.SelectedValue.ToString(); //brlslrno

        ObjUBO.A34 = einvoice_RefNo.Text;

        ObjUBO.A41 = txtTax.Text;
        ObjUBO.A42 = txtGrandTotal.Text;
        ObjUBO.A43 = ddlTDS.SelectedValue;
        ObjUBO.A44 = txtTDSPercent.Text;
        ObjUBO.A45 = txtTDSAmount.Text;
        ObjUBO.A47 = txtGrossPayable.Text;
        ObjUBO.A48 = txtAdvance.Text;
        ObjUBO.A49 = txtNetPayable.Text;
        ObjUBO.A46 = chkRoundOff.Checked == true ? "1" : "0";
        ObjUBO.A50 = txt_RoundOffAmt.Text;

        ObjUBO.A100 = flg;

        return PC.PC_Header_Ins_Upd(ObjUBO);
    }

    protected void btnLedgerDetails_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            refreshID = HDupdate_id.Value;
            refreshIDFlag = "refresh";
            Update_Item_Load();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void lnk_PD_Clear_Click(object sender, EventArgs e)
    {
        // needed in 2nd tabs functions  for later
    }
    protected void btn_PD_RetrieveOnAccount_Click(object sender, EventArgs e)
    {
        // needed in 2nd tabs functions  for later
    }

    private void ClearControls()
    {  
        txt_PC_No_F.Text = "";
        txt_PC_No_M.Text = "";
        txt_PC_No_L.Text = "";
        ddl_org_name.SelectedIndex = 0;
        ddl_Br_no.SelectedIndex = -1;

        txt_Vendor_Invoice_No.Text = "";
        txt_Vendor_Invoice_Date.Text = "";
        txt_PC_Entry_Date.Text = "";
        txt_Posting_Date.Text = "";
        txt_PC_Due_Date.Text = "";
        ddl_PC_Cur.SelectedIndex = 0;
        txt_PC_Narration.Text = "";
        hfOrgStateGstId.Value = "";
        hfchkol.Value = "";

        HDupdate_id.Value = "";
        HDupdate_Ch_id.Value = "";
        HDupdate_Group_id.Value = "";
        HDupdate_Imp_Exp.Value = "";
        HDupdate_Job_Id.Value = "";

        hdn_Grid_Disable.Value = "";
        hdnVoucherNo.Value = "";

        hdn_Sel_JL_ID.Value = "";
        hdn_Sel_JV_NO.Value = "";
        txt_PD_DateRange.Text = "";
        ddl_PD_RefType.SelectedIndex = 0;
        txt_PD_Search.Text = "";
        txt_PD_Rows.Text = "50";
                
        einvoice_RefNo.Text = "";
        txtTax.Text = "";
        txtGrandTotal.Text = "";
        txtTDSPercent.Text = "";
        txtTDSAmount.Text = "0.00";
        txtGrossPayable.Text = "";
        txtAdvance.Text = "0.00";
        txtNetPayable.Text = "";

        chkRoundOff.Checked = false;
        txt_RoundOffAmt.Text = "";
        if (ddlTDS.Items.Count > 0)
            ddlTDS.SelectedIndex = 0;
        gv_details.DataSource = new DataTable();
        gv_details.DataBind();
        ViewState["OrgVendNames"] = null;
        ddl_org_name.Focus();
    }


    private void BindPurchaseHeader(DataSet ds)
    {
        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            return;

        DataRow dr = ds.Tables[0].Rows[0];

        HDupdate_id.Value = dr["PC_ID"].ToString();

        txt_PC_No_F.Text = dr["PC_P"].ToString();
        txt_PC_No_M.Text = dr["PC_NO"].ToString();
        txt_PC_No_L.Text = dr["PC_S"].ToString();

        txt_PC_Entry_Date.Text = dr["PC_DATE"] == DBNull.Value ? "" :
            Convert.ToDateTime(dr["PC_DATE"]).ToString("dd/MM/yyyy");

        txt_Posting_Date.Text = dr["POSTING_DATE"] == DBNull.Value ? "" :
            Convert.ToDateTime(dr["POSTING_DATE"]).ToString("dd/MM/yyyy");

        txt_PC_Due_Date.Text = dr["PC_DUE_DATE"] == DBNull.Value ? "" :
            Convert.ToDateTime(dr["PC_DUE_DATE"]).ToString("dd/MM/yyyy");

        if (ddl_PC_Cur.Items.FindByValue(dr["PC_CUR"].ToString()) != null)
            ddl_PC_Cur.SelectedValue = dr["PC_CUR"].ToString();

        if (ddl_org_name.Items.FindByValue(dr["PC_ORGANISATION"].ToString()) != null)
            ddl_org_name.SelectedValue = dr["PC_ORGANISATION"].ToString();

        if (ddl_org_name.Items.FindByValue(dr["PC_ORGANISATION"].ToString()) != null)
            ddl_org_name.SelectedValue = dr["PC_ORGANISATION"].ToString();

        if (ddl_Br_no.Items.FindByValue(dr["PC_OR_BR_SLNO"].ToString()) != null)
            ddl_Br_no.SelectedValue = dr["PC_OR_BR_SLNO"].ToString();

        txt_Vendor_Invoice_No.Text = dr["VENDOR_INVOICE_NO"].ToString();

        txt_Vendor_Invoice_Date.Text = dr["VENDOR_INVOICE_DATE"] == DBNull.Value ? "" :
            Convert.ToDateTime(dr["VENDOR_INVOICE_DATE"]).ToString("dd/MM/yyyy");

        txt_PC_Narration.Text = dr["PC_NARRATION"].ToString();
        einvoice_RefNo.Text = dr["EINVOICE_REFNO"].ToString();

        txtTax.Text = dr["TAX_AMOUNT"].ToString();
        txtGrandTotal.Text = dr["GRAND_TOTAL"].ToString();

        if (ddlTDS.Items.FindByValue(dr["TDS_SECTION"].ToString()) != null)
            ddlTDS.SelectedValue = dr["TDS_SECTION"].ToString();

        txtTDSPercent.Text = dr["TDS_PERCENT"].ToString();
        txtTDSAmount.Text = dr["TDS_AMOUNT"].ToString();

        chkRoundOff.Checked =
            dr["ROUND_OFF_FLAG"].ToString() == "1" ||
            dr["ROUND_OFF_FLAG"].ToString().ToUpper() == "Y" ||
            dr["ROUND_OFF_FLAG"].ToString().ToUpper() == "TRUE";

        txtGrossPayable.Text = dr["GROSS_PAYABLE"].ToString();
        txtAdvance.Text = dr["ADVANCE_AMOUNT"].ToString();
        txtNetPayable.Text = dr["NET_PAYABLE"].ToString();
        hfBranchSerialNo.Value = dr["PC_OR_BR_SLNO"].ToString();
        ddl_Br_no_SelectedIndexChanged(ddl_Br_no, EventArgs.Empty);
        // Branch Serial
        //lblBranchSerialNo.Text = dr["PC_OR_BR_SLNO"].ToString();
    }

    protected void ddl_Br_no_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_org_name.SelectedValue.ToString() != string.Empty)
        {
            if (ddl_Br_no.SelectedValue.ToString() != string.Empty)
            {
                ObjUBO.A8 = ddl_org_name.SelectedValue.ToString();
                ObjUBO.A9 = ddl_Br_no.SelectedValue.ToString();
                ObjUBO.A40 = "Org_State_code";
                ds = PC.PC_Header_Select(ObjUBO);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    hfOrgStateGstId.Value = ds.Tables[0].Rows[0]["GSTSTATE"].ToString();
                    hfchkol.Value = ds.Tables[0].Rows[0]["OTHERLOCAL"].ToString();
                }
                else
                {
                    hfOrgStateGstId.Value = "";
                    hfchkol.Value = "";
                }
            }
            else
            {

            }
        }
        else
        {

        }
    }
}