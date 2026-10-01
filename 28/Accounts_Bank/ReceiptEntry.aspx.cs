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
using System.Configuration;
using System.Globalization;
using System.Linq;

public partial class ReceiptEntry : ThemeClass
{
    AppSession aps = new AppSession();
    ReceiptEntry_cs RE = new ReceiptEntry_cs();
    Global_variables ObjUBO = new Global_variables();
    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    public int i;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();


            if (!Page.IsPostBack)
            {
                Load_Group_Name();
                Load_Month();
                load_Party_Name();
                gvAll.DataSource = dt;
                gvAll.DataBind();

                txt_Ex_Rate.Attributes.Add("readonly", "readonly");
                txt_INR_Amt.Attributes.Add("readonly", "readonly");
                //txt_TDS_Deducted_Inr_II.Attributes.Add("readonly", "readonly");
                txt_Orgin_Bank_Charge_TDS_II.Attributes.Add("readonly", "readonly");
                txt_Rec_From_Org_II.Attributes.Add("readonly", "readonly");
                txt_bank_Charge_I.Attributes.Add("readonly", "readonly");
                txtcredit_Bank.Attributes.Add("readonly", "readonly");
                txt_Debit_to_bank_II.Attributes.Add("readonly", "readonly");


                if (Request.QueryString["R_ID"] == null)
                {
                    lbl_Job_Company_Lic.Text = Connection.Company_License().ToUpper();
                    lbl_Job_Wrk_Period.Text = Connection.WorkingPeriod();
                    Load_CP_No();
                    btnsup.Text = "Save";
                    btn_JV_Delete.Visible = false;
                }
                else
                {
                    if (Request.QueryString["R_ID"] != null && Request.QueryString["R_ID"] != string.Empty)
                    {
                        btn_JV_Delete.Visible = true;
                        btnsup.Text = "Update";
                        Update_Item_Load();
                    }
                }
            }
            if (ddl_TDS_Deducted.SelectedValue == "Y")
            {

                txt_TDS_Rate.Enabled = true;
                ddlTDS_Section.Enabled = true;
                txt_TDS_Deducted_Inr.Enabled = true;
            }
            else
            {
                txt_TDS_Rate.Enabled = false;
                ddlTDS_Section.Enabled = false;
                txt_TDS_Deducted_Inr.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private string bill_details()
    {
        DataTable dtt = new DataTable();
        dtt.Columns.Add(new DataColumn("Chk", typeof(bool)));
        dtt.Columns.Add(new DataColumn("BILL_ID", typeof(string)));
        dtt.Columns.Add(new DataColumn("Location", typeof(string)));
        dtt.Columns.Add(new DataColumn("Branch", typeof(string)));
        dtt.Columns.Add(new DataColumn("Bill_No", typeof(string)));
        dtt.Columns.Add(new DataColumn("Bill_Date", typeof(string)));
        dtt.Columns.Add(new DataColumn("Bill_Amt", typeof(string)));
        dtt.Columns.Add(new DataColumn("Paid_Amt", typeof(string)));
        dtt.Columns.Add(new DataColumn("Adjustment_Amt", typeof(string)));
        dtt.Columns.Add(new DataColumn("Balance_Amt", typeof(string)));
        dtt.Columns.Add(new DataColumn("Taxable_Amt", typeof(string)));
        dtt.Columns.Add(new DataColumn("Tds_Rate", typeof(string)));
        dtt.Columns.Add(new DataColumn("Tds_Amt", typeof(string)));
        dtt.Columns.Add(new DataColumn("Write_off_Amt", typeof(string)));
        dtt.Columns.Add(new DataColumn("Remarks", typeof(string)));
        dtt.Columns.Add(new DataColumn("CR_GRAND_TOTAL", typeof(string)));
        dtt.Columns.Add(new DataColumn("TDS_Y_N", typeof(bool)));

        int billIdCounter = 1;
        foreach (GridViewRow row in gvAll.Rows)
        {

            if (row.RowType == DataControlRowType.DataRow)
            {

                CheckBox ischk = (CheckBox)row.FindControl("ischk");
                if (ischk != null && ischk.Checked)
                {
                    Label txt_BILLID = (Label)row.FindControl("txt_BILLID");
                    Literal txt_location = (Literal)row.FindControl("txt_location");
                    Literal txt_Branch = (Literal)row.FindControl("txt_Branch");
                    // Literal txt_billno = (Literal)row.FindControl("txt_billno");
                    LinkButton txt_billno = (LinkButton)row.FindControl("txt_billno");
                    Literal txt_billDate = (Literal)row.FindControl("txt_billDate");
                    TextBox txt_billAmt = (TextBox)row.FindControl("txt_billAmt");
                    TextBox txt_PaidAmt = (TextBox)row.FindControl("txt_PaidAmt");
                    TextBox txt_Adjustment_Amt = (TextBox)row.FindControl("txt_Adjustment_Amt");
                    TextBox txt_Taxable_Amt = (TextBox)row.FindControl("txt_Taxable_Amt");
                    TextBox txt_TDS_Per = (TextBox)row.FindControl("txt_TDS_Per");
                    TextBox txt_TDS_Amt = (TextBox)row.FindControl("txt_TDS_Amt");
                    TextBox txt_Write_Amt = (TextBox)row.FindControl("txt_Write_Amt");
                    TextBox txt_Remarks = (TextBox)row.FindControl("txt_Remarks");
                    TextBox txt_Cr_Note_Bill_Amt = (TextBox)row.FindControl("txt_Cr_Note_Bill_Amt");
                    CheckBox isch_tds = (CheckBox)row.FindControl("isch_tds");


                    HiddenField hf_Bal = (HiddenField)row.FindControl("hf_Bal");
                    DataRow dr = dtt.NewRow();
                    dr["Chk"] = ischk.Checked;
                    dr["BILL_ID"] = txt_BILLID != null ? txt_BILLID.Text : string.Empty;
                    dr["Location"] = txt_location != null ? txt_location.Text : string.Empty;
                    dr["Branch"] = txt_Branch != null ? txt_Branch.Text : string.Empty;
                    dr["Bill_No"] = txt_billno != null ? txt_billno.Text : string.Empty;
                    dr["Bill_Date"] = txt_billDate != null ? txt_billDate.Text : string.Empty;
                    dr["Bill_Amt"] = txt_billAmt != null ? txt_billAmt.Text : string.Empty;
                    dr["Paid_Amt"] = txt_PaidAmt != null ? txt_PaidAmt.Text : string.Empty;
                    dr["Adjustment_Amt"] = txt_Adjustment_Amt != null ? txt_Adjustment_Amt.Text : string.Empty;
                    dr["Balance_Amt"] = hf_Bal != null ? hf_Bal.Value : string.Empty;
                    dr["TAXABLE_AMT"] = txt_Taxable_Amt != null ? txt_Taxable_Amt.Text : string.Empty;
                    dr["TDS_RATE"] = txt_TDS_Per != null ? txt_TDS_Per.Text : string.Empty;
                    dr["TDS_AMT"] = txt_TDS_Amt != null ? txt_TDS_Amt.Text : string.Empty;
                    dr["WRITE_OFF_AMT"] = txt_Write_Amt != null ? txt_Write_Amt.Text : string.Empty;
                    dr["REMARKS"] = txt_Remarks != null ? txt_Remarks.Text : string.Empty;
                    dr["CR_GRAND_TOTAL"] = txt_Cr_Note_Bill_Amt != null ? txt_Cr_Note_Bill_Amt.Text : string.Empty;
                    dr["TDS_Y_N"] = ischk.Checked;

                    dr = dtt.NewRow();
                    dr[0] = ischk.Checked;
                    dr[1] = txt_BILLID.Text;
                    dr[2] = txt_location.Text;
                    dr[3] = txt_Branch.Text;
                    dr[4] = txt_billno.Text;
                    dr[5] = txt_billDate.Text;
                    dr[6] = txt_billAmt.Text;
                    dr[7] = txt_PaidAmt.Text;
                    dr[8] = txt_Adjustment_Amt.Text;
                    dr[9] = hf_Bal.Value;
                    dr[10] = txt_Taxable_Amt.Text;
                    dr[11] = txt_TDS_Per.Text;
                    dr[12] = txt_TDS_Amt.Text;
                    dr[13] = txt_Write_Amt.Text;
                    dr[14] = txt_Remarks.Text;
                    dr[15] = txt_Cr_Note_Bill_Amt.Text;
                    dr[16] = isch_tds.Checked;
                    dtt.Rows.Add(dr);
                    billIdCounter++;
                }
            }
        }
        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        string xmlData1 = ConvertDataTableToXML(dsData.Tables[0]);
        return xmlData1;
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

    protected void gvAll_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txt_TDS_Amt = (TextBox)e.Row.FindControl("txt_TDS_Amt");
            CheckBox isch_tds = (CheckBox)e.Row.FindControl("isch_tds");

            if (isch_tds != null)
             {
                 bool hasTdsRate = txt_TDS_Amt != null &&
                                  !string.IsNullOrWhiteSpace(txt_TDS_Amt.Text) &&
                                  txt_TDS_Amt.Text.Trim() != "0" &&
                                  txt_TDS_Amt.Text.Trim() != "0.00";

                isch_tds.Enabled = !(hasTdsRate);
            }
        }




    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjUBO.A3 = ddl_Exp_Branch.SelectedValue;
            ObjUBO.A4 = ddlPartyname.SelectedValue.ToString();

            if (txtFromdate.Text != string.Empty || txtTodate.Text != string.Empty)
            {
                ObjUBO.A1 = txtFromdate.Text;
                ObjUBO.A2 = txtTodate.Text;
            }
            else
            {
                if (ddlMonth.SelectedItem.Text != string.Empty)
                {
                    arr_Month = ddlMonth.SelectedValue.ToString().Split('-');
                    ObjUBO.A1 = arr_Month[0];
                    ObjUBO.A2 = arr_Month[1];
                }
                else
                {
                    ObjUBO.A1 = txtFromdate.Text;
                    ObjUBO.A2 = txtTodate.Text;
                }
            }
            ObjUBO.A5 = ddl_Bill_No.SelectedValue;
            ObjUBO.A40 = "Load_Grid_Data";
            ds = RE.Acc_Gst_Recipit_Bill_details_Search(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvAll.DataSource = ds.Tables[0];
                gvAll.DataBind();
            }
            else
            {
                gvAll.DataSource = dt;
                gvAll.DataBind();
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    private void Load_Month()
    {
        DataSet ds = new DataSet();
        ds = Common_CS.Load_Month();
        ddlMonth.DataSource = ds.Tables[0];
        ddlMonth.DataTextField = "TheMonth";
        ddlMonth.DataValueField = "TheMonth_No";
        ddlMonth.DataBind();
        ddlMonth.Items.Insert(ddlMonth.Items.Count, new ListItem(String.Empty, String.Empty));
        ddlMonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
    }


    private void Load_CP_No()
    {
        DataSet ds = new DataSet();
        try
        {
            txt_BR_No_F.Text = string.Empty;
            txt_BR_No_M.Text = string.Empty;
            txt_BR_No_L.Text = string.Empty;
            txt_BR_Entry_Date.Text = string.Empty;
            ObjUBO.A40 = "BR_No_Select";
            ds = RE.BR_Receipt_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_BR_No_F.Text = ds.Tables[0].Rows[0]["BR_P"].ToString();
                txt_BR_No_M.Text = ds.Tables[0].Rows[0]["BR_NO"].ToString();
                txt_BR_No_L.Text = ds.Tables[0].Rows[0]["BR_S"].ToString();
                txt_BR_Entry_Date.Text = ds.Tables[0].Rows[0]["BR_Date"].ToString();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Update_Item_Load()
    {
        try
        {
            DataSet dSS = new DataSet();
            ObjUBO.A1 = Request.QueryString["R_ID"].ToString();
            ObjUBO.A40 = "Updated_Receipt_Select";
            dSS = RE.BR_Receipt_Select(ObjUBO);
            if (dSS.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = dSS.Tables[0].Rows[0]["BR_ID"].ToString();
                txt_BR_No_F.Text = dSS.Tables[0].Rows[0]["BR_P"].ToString();
                txt_BR_No_M.Text = dSS.Tables[0].Rows[0]["BR_NO"].ToString();
                txt_BR_No_L.Text = dSS.Tables[0].Rows[0]["BR_S"].ToString();
                txt_BR_Entry_Date.Text = dSS.Tables[0].Rows[0]["BR_DATE"].ToString().Replace("01/01/1900", "");
                txt_Posting_Date.Text = dSS.Tables[0].Rows[0]["POSTING_DATE"].ToString().Replace("01/01/1900", "");
                ddl_Issuer_Bank_Name.SelectedValue = dSS.Tables[0].Rows[0]["ISSUSER_BANK_NAME"].ToString();
                txt_Issuer_Bank_Accno.Text = dSS.Tables[0].Rows[0]["ISSUSER_BANK_NO"].ToString();
                ddl_Bank_From.SelectedValue = dSS.Tables[0].Rows[0]["BANK_NAME"].ToString();
                ddlPartyname.SelectedValue = dSS.Tables[0].Rows[0]["ORGANAIZATION_NAME"].ToString();
                ddlPartyname_SelectedIndexChanged(this, null);
                ddlPartyBranch.SelectedValue = dSS.Tables[0].Rows[0]["ORGANAIZATION_BR"].ToString();
                ddl_Issuer_Bank_info_Type.SelectedValue = dSS.Tables[0].Rows[0]["FUND_TYPE"].ToString();
                txt_Issuer_Bank_info_Date.Text = dSS.Tables[0].Rows[0]["FUND_DATE"].ToString().Replace("01/01/1900", "");
                ddl_Cur.SelectedValue = dSS.Tables[0].Rows[0]["FUND_CUR"].ToString();
                txt_Ex_Rate.Text = dSS.Tables[0].Rows[0]["FUND_EX_RATE"].ToString();
                txt_Cur_Amt.Text = dSS.Tables[0].Rows[0]["FUND_CUR_AMT"].ToString();
                Hidden_iNR.Value = dSS.Tables[0].Rows[0]["FUND_INR_AMT"].ToString();
                txt_INR_Amt.Text = dSS.Tables[0].Rows[0]["FUND_INR_AMT"].ToString();
                ddl_Adjustment_for.SelectedValue = dSS.Tables[0].Rows[0]["FUND_ADJUSTMENT_FOR"].ToString();
                ddl_TDS_Deducted.SelectedValue = dSS.Tables[0].Rows[0]["TDS_DEDUCTED"].ToString();
                txt_TDS_Deducted_Inr.Text = dSS.Tables[0].Rows[0]["TDS_AMT"].ToString();
                txt_Narration.Text = dSS.Tables[0].Rows[0]["NARRATION"].ToString();
                txt_Issuer_Bank_info_No.Text = dSS.Tables[0].Rows[0]["Issuer_Bank_info_No"].ToString();
                ddl_Bank_From.SelectedValue = dSS.Tables[0].Rows[0]["AC_NO"].ToString();
                txtcredit_Bank.Text = dSS.Tables[0].Rows[0]["CREDIT_TO_BANK"].ToString();
                lbl_Job_Company_Lic.Text = dSS.Tables[0].Rows[0]["JOB_LICENSE"].ToString();
                lbl_Job_Wrk_Period.Text = dSS.Tables[0].Rows[0]["JOB_WORKINGPERIOD"].ToString();
                ddlTDS_Section.SelectedValue = dSS.Tables[0].Rows[0]["TDS_SECTION"].ToString();
                txt_TDS_Rate.Text = dSS.Tables[0].Rows[0]["TDS_RATE"].ToString();

                txt_TDS_Deducted_Inr_II.Text = dSS.Tables[0].Rows[0]["TDS_DEDUCTED_INR_II"].ToString();
                txt_Orgin_Bank_Charge_TDS_I.Text = dSS.Tables[0].Rows[0]["ORGIN_BANK_CHARGE_TDS_I"].ToString();
                txt_Orgin_Bank_Charge_TDS_II.Text = dSS.Tables[0].Rows[0]["ORGIN_BANK_CHARGE_TDS_II"].ToString();
                txt_Rec_From_Org_I.Text = dSS.Tables[0].Rows[0]["REC_FROM_ORG_I"].ToString();
                txt_Rec_From_Org_II.Text = dSS.Tables[0].Rows[0]["REC_FROM_ORG_II"].ToString();
                txt_bank_Charge_I.Text = dSS.Tables[0].Rows[0]["BANK_CHARGE_I"].ToString();
                txt_bank_Charge_II.Text = dSS.Tables[0].Rows[0]["BANK_CHARGE_II"].ToString();
                txt_Debit_to_bank_I.Text = dSS.Tables[0].Rows[0]["DEBIT_TO_BANK_I"].ToString();
                txt_Debit_to_bank_II.Text = dSS.Tables[0].Rows[0]["DEBIT_TO_BANK_II"].ToString();

                txt_INR_Amt.Enabled = false;
                if (dSS.Tables[0].Rows[0]["FLAG"].ToString() == "C")
                {
                    btnsup.Visible = false;
                    btn_JV_Delete.Visible = false;
                    btnSave.Visible = false;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnSearch.Visible = false;
                    btnNew.Visible = false;
                }
                else
                {
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                }
            }
            else
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btn_JV_Delete.Visible = false;
            }
            if (dSS.Tables[1].Rows.Count > 0)
            {
                gvAll.DataSource = dSS.Tables[1];
                gvAll.DataBind();
                btnSearch.Visible = false;
            }
            else
            {
                gvAll.DataSource = dt;
                gvAll.DataBind();
                if (dSS.Tables[0].Rows[0]["FLAG"].ToString() == "C")
                {
                    btnSearch.Visible = false;
                }
                else
                {
                    btnSearch.Visible = true;
                }
                btnDelete.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    private void load_Party_Name()
    {
        try
        {
            ddlPartyname.Items.Clear();
            ddlPartyBranch.Items.Clear();
            DataSet ds = new DataSet();
            ObjUBO.A40 = "Party_Name_PNO_Select";
            ds = RE.BR_Receipt_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlPartyname.DataSource = ds.Tables[0];
                ddlPartyname.DataTextField = "PARTY_NAME";
                ddlPartyname.DataValueField = "PARTY_NAME";
                ddlPartyname.DataBind();
            }
            ddlPartyname.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlPartyname.SelectedIndex = 0;

            if (ds.Tables[1].Rows.Count > 0)
            {
                ViewState["BankDetails"] = ds.Tables[1];
                ddl_Bank_From.DataSource = ds.Tables[1];
                ddl_Bank_From.DataValueField = "ACCOUNT_NUMBER";
                ddl_Bank_From.DataTextField = "BANKNAME";
                ddl_Bank_From.DataBind();
            }
            ddl_Bank_From.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Bank_From.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void ddl_Bank_From_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = ViewState["BankDetails"] as DataTable;
        if (dt != null)
        {
            DataRow[] dr = dt.Select("ACCOUNT_NUMBER='" + ddl_Bank_From.SelectedValue.Replace("'", "''") + "'");

            if (dr.Length > 0)
            {
                hfBankGLCode.Value = dr[0]["GL_CODE"].ToString();
            }
        }
    }


    protected void ddlPartyname_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_ReceiptBranch();
    }
    private void Load_ReceiptBranch()
    {
        ddlPartyBranch.Items.Clear();
        if (ddlPartyname.SelectedValue.ToString() != string.Empty)
        {
            ObjUBO.A8 = ddlPartyname.SelectedValue.ToString();
            ObjUBO.A40 = "Party_Branch_Select";
            ds = RE.BR_Receipt_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlPartyBranch.DataSource = ds.Tables[0];
                ddlPartyBranch.DataTextField = "PARTY_BRANCH_NO";
                ddlPartyBranch.DataValueField = "PARTY_BRANCH_NO";
                ddlPartyBranch.DataBind();
            }

            ddlPartyBranch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlPartyBranch.SelectedIndex = 0;
            if (ds.Tables[1].Rows.Count > 0)
            {

                string tds = ds.Tables[1].Rows[0]["TDS_YN"].ToString();
                if (tds == "Y")
                {
                    ddl_TDS_Deducted.SelectedValue = "Y";
                }
                else
                {
                    ddl_TDS_Deducted.SelectedValue = "N";
                }
                if (ddl_TDS_Deducted.SelectedValue == "Y")
                {

                    txt_TDS_Rate.Enabled = true;
                    ddlTDS_Section.Enabled = true;
                    txt_TDS_Deducted_Inr.Enabled = true;
                }
                else
                {
                    txt_TDS_Rate.Enabled = false;
                    ddlTDS_Section.Enabled = false;
                    txt_TDS_Deducted_Inr.Enabled = false;
                }
                ddlTDS_Section.SelectedValue = ds.Tables[1].Rows[0]["TDS_SECTION"].ToString();
                txt_TDS_Rate.Text = ds.Tables[1].Rows[0]["TDS_RATE"].ToString();

            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                ddl_Bill_No.DataSource = ds.Tables[2];
                ddl_Bill_No.DataTextField = "BILL_INV_NO";
                ddl_Bill_No.DataValueField = "BILL_INV_NO";
                ddl_Bill_No.DataBind();

            }
        }
        ddl_Bill_No.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Bill_No.SelectedIndex = 0;
    }
    protected void gvAll_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Receipt Entry', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Receipt Entry', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int checkedCount = gvAll.Rows.Cast<GridViewRow>().Count(row => ((CheckBox)row.FindControl("ischk")).Checked);
            if (checkedCount != 0)
            {
                if (ddlPartyname.SelectedValue.ToString() != string.Empty)
                {
                    if (ddl_Bank_From.SelectedValue.ToString() != string.Empty)
                    {
                        txt_INR_Amt.Text = Hidden_iNR.Value;
                        string txtInrAmtText = txtcredit_Bank.Text;
                        string lblTotalAdjText = Hidden_lblTotalAdjustment.Value;

                        decimal txtInrAmt;
                        decimal lblTotalAdj;

                        bool txtInrAmtValid = decimal.TryParse(txtInrAmtText, out txtInrAmt);
                        bool lblTotalAdjValid = decimal.TryParse(lblTotalAdjText, out lblTotalAdj);


                        if (txtInrAmt >= lblTotalAdj)
                        {
                            ds = Receipt_Insert_Update("SAVE", bill_details());
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                if (ds.Tables[0].Rows[0]["BR_ID"].ToString() != "0")
                                {
                                    HD_Ch_update_id.Value = ds.Tables[0].Rows[0]["BR_ID"].ToString();

                                    btnUpdate.Visible = true;
                                    btnDelete.Visible = true;
                                    btnSave.Visible = false;
                                    btnSave.Focus();
                                    ViewState["UPDATED_ID"] = null;
                                    Alert_msg("Receipt Entry Saved Successfully", "btnSave");
                                    btnSearch.Visible = false;
                                }
                                else
                                {
                                    Alert_msg("Save above Details", "btnSave");
                                }
                            }
                            else
                            {
                                Alert_msg("Receipt Not Saved", "btnSave");
                            }


                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                gvAll.DataSource = ds.Tables[1];
                                gvAll.DataBind();
                            }
                            else
                            {
                                gvAll.DataSource = dt;
                                gvAll.DataBind();
                            }

                        }
                        else
                        {
                            Alert_msg("Total Adjustment Amt Greater than Credit Amt", "txt_INR_Amt");
                        }

                    }
                    else
                    {
                        Alert_msg("Select Ur Bank!", "ddl_Bank_From");
                    }
                }
                else
                {
                    Alert_msg("Select Ur Organization Name!", "ddlPartyname");
                }
            }
            else
            {
                Alert_msg("Select Ur Bill!", "ischk");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {

            string txtInrAmtText = txtcredit_Bank.Text;
            string lblTotalAdjText = Hidden_lblTotalAdjustment.Value;
            decimal txtInrAmt;
            decimal lblTotalAdj;
            bool txtInrAmtValid = decimal.TryParse(txtInrAmtText, out txtInrAmt);
            bool lblTotalAdjValid = decimal.TryParse(lblTotalAdjText, out lblTotalAdj);
            if (txtInrAmt >= lblTotalAdj)
            {
                ds = Receipt_Insert_Update("UPDATE", bill_details());

                if (ds.Tables[0].Rows.Count >= 0)
                {
                    HD_Ch_update_id.Value = ds.Tables[0].Rows[0]["BR_ID"].ToString();

                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSave.Visible = false;
                    btnSave.Focus();
                    ViewState["UPDATED_ID"] = null;
                    Alert_msg("Receipt Entry Updated Successfully", "btnSave");
                }
                else
                {
                    Alert_msg("Receipt Not Updated", "btnSave");
                }


                if (ds.Tables[1].Rows.Count > 0)
                {
                    gvAll.DataSource = ds.Tables[1];
                    gvAll.DataBind();
                }
                else
                {
                    gvAll.DataSource = dt;
                    gvAll.DataBind();
                }
            }

            else
            {
                Alert_msg("Total Adjustment Amt Greater than Credit Amt", "txt_INR_Amt");
            }


        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            int uncheckedCount = gvAll.Rows.Cast<GridViewRow>().Count(row => ((CheckBox)row.FindControl("ischk")).Checked == false);
            if (uncheckedCount != 0)
            {
                ds = Receipt_Insert_Update("UPDATE", bill_details());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    HD_Ch_update_id.Value = ds.Tables[0].Rows[0]["BR_ID"].ToString();

                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSave.Visible = false;
                    btnSave.Focus();
                    ViewState["UPDATED_ID"] = null;
                    Alert_msg("Receipt Entry deleted Successfully", "btnDelete");
                }
                else
                {
                    Alert_msg("Receipt Not deleted", "btnDelete");
                }


                if (ds.Tables[1].Rows.Count > 0)
                {
                    gvAll.DataSource = ds.Tables[1];
                    gvAll.DataBind();
                }
                else
                {
                    gvAll.DataSource = dt;
                    gvAll.DataBind();
                }
            }
            else
            {
                Alert_msg(" Please Uncheck the row(s) before Deleting!", "ischk");

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void btn_JV_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dss = new DataSet();
            dss = Receipt_Insert_Update("Delete", "");
            if (dss.Tables[0].Rows.Count == 0)
            {
                ViewState["UPDATED_ID"] = null;
                btnNew_Click(sender, e);
                Alert_msg("Receipt Entry Deleted");
            }
            else
            {
                Alert_msg("Receipt Not Deleted", "btnDelete");
            }
            if (dss.Tables[1].Rows.Count > 0)
            {
                gvAll.DataSource = dss.Tables[1];
                gvAll.DataBind();
            }
            else
            {
                gvAll.DataSource = dt;
                gvAll.DataBind();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            btnsup.Text = "Save";
            btn_JV_Delete.Visible = false;

            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
            btnUpdate.CssClass = "updates";
            ViewState["UPDATED_ID"] = null;
            HD_Ch_update_id.Value = "";
            RE.ResetFields(Page.Controls);
            Load_CP_No();
            gvAll.DataSource = dt;
            gvAll.DataBind();

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void btn_Save_Update_Click(object sender, EventArgs e)
    {
        try
        {
            string txtInrAmtText = txtcredit_Bank.Text;
            string lblTotalAdjText = Hidden_lblTotalAdjustment.Value;
            decimal txtInrAmt;
            decimal lblTotalAdj;
            bool txtInrAmtValid = decimal.TryParse(txtInrAmtText, out txtInrAmt);
            bool lblTotalAdjValid = decimal.TryParse(lblTotalAdjText, out lblTotalAdj);
            if (ddlPartyname.SelectedValue.ToString() != string.Empty)
            {
                if (txt_INR_Amt.Text != "" || Hidden_iNR.Value != "")
                {
                    if (ddl_Bank_From.SelectedValue.ToString() != string.Empty)
                    {
                        if (txtInrAmt >= lblTotalAdj)
                        {
                            Receipt_Save();
                        }
                        else
                        {
                            Alert_msg("Total Adjustment Amt Greater than Credit Amt", "txt_INR_Amt");
                        }
                    }
                    else
                    {
                        Alert_msg("Select Ur Bank!", "ddl_Bank_From");
                    }
                }
                else
                {
                    Alert_msg("Enter your Cur amt", "txt_INR_Amt");
                }
            }
            else
            {
                Alert_msg("Select Ur Organization Name!", "ddlPartyname");
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void Receipt_Save()
    {
        if (btnsup.Text == "Save")
        {
            ds = Receipt_Insert_Update("S", bill_details());
            if (ds.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = ds.Tables[0].Rows[0]["BR_ID"].ToString();
                btnsup.Text = "Update";
                btn_JV_Delete.Visible = true;
                Alert_msg("Saved Successfully!", "btn_Save_Update");
            }
        }
        else if (btnsup.Text == "Update")
        {
            ds = Receipt_Insert_Update("U", bill_details());
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnsup.Text = "Update";
                Alert_msg("Updated Successfully!", "btn_Save_Update");
            }
        }
    }

    public DataSet Receipt_Insert_Update(string S1, string xmlData_A)
    {
        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A3 = txt_BR_No_F.Text;
        ObjUBO.A4 = txt_BR_No_M.Text;
        ObjUBO.A5 = txt_BR_No_L.Text;
        ObjUBO.A6 = txt_BR_Entry_Date.Text;
        ObjUBO.A7 = txt_Posting_Date.Text;
        ObjUBO.A8 = ddl_Bank_From.SelectedItem.Text;
        ObjUBO.A9 = ddl_Issuer_Bank_Name.SelectedValue;
        ObjUBO.A10 = txt_Issuer_Bank_Accno.Text;
        ObjUBO.A11 = ddlPartyname.SelectedValue;
        ObjUBO.A12 = ddlPartyBranch.SelectedValue;
        ObjUBO.A13 = ddl_Issuer_Bank_info_Type.SelectedValue;
        ObjUBO.A15 = txt_Issuer_Bank_info_Date.Text;
        ObjUBO.A16 = ddl_Cur.SelectedValue;
        ObjUBO.A17 = txt_Ex_Rate.Text;
        ObjUBO.A18 = txt_Cur_Amt.Text;
        txt_INR_Amt.Text = Hidden_iNR.Value;
        ObjUBO.A19 = Hidden_iNR.Value;
        ObjUBO.A20 = ddl_Adjustment_for.SelectedValue;
        ObjUBO.A21 = ddl_TDS_Deducted.SelectedValue;

        ObjUBO.A22 = txt_TDS_Deducted_Inr.Text;
        ObjUBO.A23 = txt_Narration.Text;
        ObjUBO.A24 = lbl_Job_Company_Lic.Text;
        ObjUBO.A25 = lbl_Job_Wrk_Period.Text;
        ObjUBO.A26 = ddlTDS_Section.SelectedValue;
        ObjUBO.A27 = txt_TDS_Rate.Text;
        ObjUBO.A28 = ddl_Bank_From.SelectedValue;
        ObjUBO.A29 = txt_Issuer_Bank_info_No.Text;
        ObjUBO.A30 = txtcredit_Bank.Text;
        RE.xmlString = xmlData_A;

        ObjUBO.A31 = txt_TDS_Deducted_Inr_II.Text;
        ObjUBO.A32 = txt_Orgin_Bank_Charge_TDS_I.Text;
        ObjUBO.A33 = txt_Orgin_Bank_Charge_TDS_II.Text;
        ObjUBO.A34 = txt_Rec_From_Org_I.Text;
        ObjUBO.A35 = txt_Rec_From_Org_II.Text;
        ObjUBO.A36 = txt_bank_Charge_I.Text;
        ObjUBO.A37 = txt_bank_Charge_II.Text;
        ObjUBO.A38 = txt_Debit_to_bank_I.Text;
        ObjUBO.A39 = txt_Debit_to_bank_II.Text;
        ObjUBO.A53 = S1;
        ObjUBO.A40 = hfBankGLCode.Value;
        ds = RE.ACC_GST_BR_RECEIPT_ENTRY_INS_UPD(ObjUBO);
        return ds;
    }

    private void Load_Group_Name()
    {
        ddl_Exp_Branch.Items.Clear();
        if (Session["ClientGrpMst"] != null)
        {
            DataSet ds = (DataSet)Session["ClientGrpMst"];
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_Exp_Branch.DataSource = ds.Tables[0];
                ddl_Exp_Branch.DataTextField = "GROUP_NAME";
                ddl_Exp_Branch.DataValueField = "GROUP_ID";
                ddl_Exp_Branch.DataBind();
            }
        }
        ddl_Exp_Branch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Exp_Branch.SelectedIndex = 0;
    }

}