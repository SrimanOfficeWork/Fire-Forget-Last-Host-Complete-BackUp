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

public partial class Accounts_Payment_Payment_Entry_Debitors : ThemeClass
{
    AppSession aps = new AppSession();
    Payment_Entry_Debitors PD = new Payment_Entry_Debitors();
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
                load_Party_Name();
                Load_Month();
                gvAll.DataSource = dt;
                gvAll.DataBind();

                txt_Ex_Rate.Attributes.Add("readonly", "readonly");
                txt_INR_Amt.Attributes.Add("readonly", "readonly");
                txtDebit_bank_Inr_I.Attributes.Add("readonly", "readonly");
                //txt_TDS_Deducted_Inr_II.Attributes.Add("readonly", "readonly");
                txtPaid_Org_II.Attributes.Add("readonly", "readonly");
                TxtbankCharge_Inr_I.Attributes.Add("readonl", "readonly");
                txtDebit_bank_Inr_II.Attributes.Add("readonly", "readonly");
                txtDebit_bank.Attributes.Add("readonly", "readonly");

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
                        btnsup.Text = "Update";
                        btn_JV_Delete.Visible = true;
                        Update_Item_Load();
                    }
                }
            }
            if (ddl_TDS_Deducted.SelectedValue == "Y")
            {

                txt_TDS_Rate.Enabled = true;
                ddlTDS_Section.Enabled = true;
                txt_TDS_Deducted_Inr_I.Enabled = true;
            }
            else
            {
                txt_TDS_Rate.Enabled = false;
                ddlTDS_Section.Enabled = false;
                txt_TDS_Deducted_Inr_I.Enabled = false;
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
        dtt.Columns.Add(new DataColumn("Vendor_Bill_No", typeof(string)));
        dtt.Columns.Add(new DataColumn("Bill_Date", typeof(string)));
        dtt.Columns.Add(new DataColumn("Bill_Amt", typeof(string)));
        dtt.Columns.Add(new DataColumn("Tds_Rate", typeof(string)));
        dtt.Columns.Add(new DataColumn("Paid_Amt", typeof(string)));
        dtt.Columns.Add(new DataColumn("Adjustment_Amt", typeof(string)));
        dtt.Columns.Add(new DataColumn("Balance_Amt", typeof(string)));
        dtt.Columns.Add(new DataColumn("Taxable_Amt", typeof(string)));
        dtt.Columns.Add(new DataColumn("TDS_PERCENT", typeof(string)));
        dtt.Columns.Add(new DataColumn("Tds_Amt", typeof(string)));
        dtt.Columns.Add(new DataColumn("Write_off_Amt", typeof(string)));
        dtt.Columns.Add(new DataColumn("Remarks", typeof(string)));
        dtt.Columns.Add(new DataColumn("CR_GRAND_TOTAL", typeof(string)));
        dtt.Columns.Add(new DataColumn("TDS_Y_N", typeof(bool)));

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
                    LinkButton txt_billno = (LinkButton)row.FindControl("txt_billno");
                    Literal txt_Vendor_billno = (Literal)row.FindControl("txt_Vendor_billno");
                    Literal txt_billDate = (Literal)row.FindControl("txt_billDate");

                    TextBox txt_billAmt = (TextBox)row.FindControl("txt_billAmt");
                    TextBox txt_tds_Rate = (TextBox)row.FindControl("txt_tds_Rate");
                    TextBox txt_PaidAmt = (TextBox)row.FindControl("txt_PaidAmt");
                    TextBox txt_Adjustment_Amt = (TextBox)row.FindControl("txt_Adjustment_Amt");
                    TextBox txt_Taxable_Amt = (TextBox)row.FindControl("txt_Taxable_Amt");
                    TextBox txt_TDS_Per = (TextBox)row.FindControl("txt_TDS_Per");
                    TextBox txt_TDS_Amt = (TextBox)row.FindControl("txt_TDS_Amt");
                    TextBox txt_Write_Amt = (TextBox)row.FindControl("txt_Write_Amt");
                    TextBox txt_Remarks = (TextBox)row.FindControl("txt_Remarks");
                    TextBox txt_Cr_Note_Bill_Amt = (TextBox)row.FindControl("txt_Cr_Note_Bill_Amt");

                    HiddenField hf_Bal = (HiddenField)row.FindControl("hf_Bal");
                    CheckBox isch_tds = (CheckBox)row.FindControl("isch_tds");

                    DataRow dr = dtt.NewRow();

                    dr["Chk"] = ischk.Checked;
                    dr["BILL_ID"] = txt_BILLID != null ? txt_BILLID.Text : "";
                    dr["Location"] = txt_location != null ? txt_location.Text : "";
                    dr["Branch"] = txt_Branch != null ? txt_Branch.Text : "";
                    dr["Bill_No"] = txt_billno != null ? txt_billno.Text : "";
                    dr["Vendor_Bill_No"] = txt_Vendor_billno != null ? txt_Vendor_billno.Text : "";
                    dr["Bill_Date"] = txt_billDate != null ? txt_billDate.Text : "";
                    dr["Bill_Amt"] = txt_billAmt != null ? txt_billAmt.Text : "";
                    dr["Tds_Rate"] = txt_tds_Rate != null ? txt_tds_Rate.Text : "";
                    dr["Paid_Amt"] = txt_PaidAmt != null ? txt_PaidAmt.Text : "";
                    dr["Adjustment_Amt"] = txt_Adjustment_Amt != null ? txt_Adjustment_Amt.Text : "";
                    dr["Balance_Amt"] = hf_Bal != null ? hf_Bal.Value : "";
                    dr["Taxable_Amt"] = txt_Taxable_Amt != null ? txt_Taxable_Amt.Text : "";
                    dr["TDS_PERCENT"] = txt_TDS_Per != null ? txt_TDS_Per.Text : "";
                    dr["Tds_Amt"] = txt_TDS_Amt != null ? txt_TDS_Amt.Text : "";
                    dr["Write_off_Amt"] = txt_Write_Amt != null ? txt_Write_Amt.Text : "";
                    dr["Remarks"] = txt_Remarks != null ? txt_Remarks.Text : "";
                    dr["CR_GRAND_TOTAL"] = txt_Cr_Note_Bill_Amt != null ? txt_Cr_Note_Bill_Amt.Text : "";
                    dr["TDS_Y_N"] = isch_tds != null ? isch_tds.Checked : false;

                    dtt.Rows.Add(dr);
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
            ds = PD.Acc_Gst_Payment_Bill_details_Search(ObjUBO);
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
            ObjUBO.A40 = "BP_No_Select";
            ds = PD.BP_Payment_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_BR_No_F.Text = ds.Tables[0].Rows[0]["BP_P"].ToString();
                txt_BR_No_M.Text = ds.Tables[0].Rows[0]["BP_NO"].ToString();
                txt_BR_No_L.Text = ds.Tables[0].Rows[0]["BP_S"].ToString();
                txt_BR_Entry_Date.Text = ds.Tables[0].Rows[0]["BP_Date"].ToString();
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
            ObjUBO.A40 = "Updated_Payment_Select";
            dSS = PD.BP_Payment_Select(ObjUBO);
            if (dSS.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = dSS.Tables[0].Rows[0]["BP_ID"].ToString();
                txt_BR_No_F.Text = dSS.Tables[0].Rows[0]["BP_P"].ToString();
                txt_BR_No_M.Text = dSS.Tables[0].Rows[0]["BP_NO"].ToString();
                txt_BR_No_L.Text = dSS.Tables[0].Rows[0]["BP_S"].ToString();
                txt_BR_Entry_Date.Text = dSS.Tables[0].Rows[0]["BP_DATE"].ToString().Replace("01/01/1900", "");
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
                txt_TDS_Deducted_Inr_I.Text = dSS.Tables[0].Rows[0]["TDS_AMT"].ToString();
                txt_Narration.Text = dSS.Tables[0].Rows[0]["NARRATION"].ToString();
                txt_Issuer_Bank_info_No.Text = dSS.Tables[0].Rows[0]["Issuer_Bank_info_No"].ToString();
                ddl_Bank_From.SelectedValue = dSS.Tables[0].Rows[0]["AC_NO"].ToString();
                txtDebit_bank.Text = dSS.Tables[0].Rows[0]["DEBIT_TO_BANK"].ToString();
                lbl_Job_Company_Lic.Text = dSS.Tables[0].Rows[0]["JOB_LICENSE"].ToString();
                lbl_Job_Wrk_Period.Text = dSS.Tables[0].Rows[0]["JOB_WORKINGPERIOD"].ToString();
                ddlTDS_Section.SelectedValue = dSS.Tables[0].Rows[0]["TDS_SECTION"].ToString();
                txt_TDS_Rate.Text = dSS.Tables[0].Rows[0]["TDS_RATE"].ToString();
                txt_INR_Amt.Enabled = false;
                txt_TDS_Deducted_Inr_II.Text = dSS.Tables[0].Rows[0]["TDS_AMT_II"].ToString();
                string Chk = dSS.Tables[0].Rows[0]["CHK_TO_ORG"].ToString();
                if (Chk == "T")
                {
                    Chk_To_Org.Checked = true;
                }
                else
                {
                    Chk_To_Org.Checked = false;
                }
                txtPaid_Org_I.Text = dSS.Tables[0].Rows[0]["PAID_TO_ORG_I"].ToString();
                txtPaid_Org_II.Text = dSS.Tables[0].Rows[0]["PAID_TO_ORG_II"].ToString();
                TxtbankCharge_Inr_II.Text = dSS.Tables[0].Rows[0]["BANK_CHARGES_I"].ToString();
                TxtbankCharge_Inr_I.Text = dSS.Tables[0].Rows[0]["BANK_CHARGES_II"].ToString();
                txtDebit_bank_Inr_II.Text = dSS.Tables[0].Rows[0]["CREDIT_TO_BANK_I"].ToString();
                txt_payee.Text = dSS.Tables[0].Rows[0]["PAYEE"].ToString();
                ddlPayee_type.SelectedValue = dSS.Tables[0].Rows[0]["PAY_TYPE"].ToString();
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
            ds = PD.BP_Payment_Select(ObjUBO);
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
    protected void ddlPartyname_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_PaymentBranch();
    }
    private void Load_PaymentBranch()
    {
        ddlPartyBranch.Items.Clear();

        ObjUBO.A8 = ddlPartyname.SelectedValue.ToString();
        ObjUBO.A40 = "Party_Branch_Select";
        ds = PD.BP_Payment_Select(ObjUBO);
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

            string tds = ds.Tables[1].Rows[0]["TDS_YES_NO"].ToString();
            if (tds == "YES")
            {
                ddl_TDS_Deducted.SelectedValue = "Y";
            }
            else
            {
                ddl_TDS_Deducted.SelectedValue = "N";
            }
            ddlTDS_Section.SelectedValue = ds.Tables[1].Rows[0]["TDS_SECTION"].ToString();
            txt_TDS_Rate.Text = ds.Tables[1].Rows[0]["TDS_PERCENT"].ToString();
            if (ddl_TDS_Deducted.SelectedValue == "Y")
            {

                txt_TDS_Rate.Enabled = true;
                ddlTDS_Section.Enabled = true;
                txt_TDS_Deducted_Inr_I.Enabled = true;
            }
            else
            {
                txt_TDS_Rate.Enabled = false;
                ddlTDS_Section.Enabled = false;
                txt_TDS_Deducted_Inr_I.Enabled = false;
            }
        }
        if (ds.Tables[2].Rows.Count > 0)
        {
            ddl_Bill_No.DataSource = ds.Tables[2];
            ddl_Bill_No.DataTextField = "VENDOR_BILL_NO";
            ddl_Bill_No.DataValueField = "VENDOR_BILL_NO";
            ddl_Bill_No.DataBind();

        }
        ddl_Bill_No.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Bill_No.SelectedIndex = 0;


    }

    protected void gvAll_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txt_tds_Rate = (TextBox)e.Row.FindControl("txt_tds_Rate");
            CheckBox isch_tds = (CheckBox)e.Row.FindControl("isch_tds");
            TextBox txt_tds_amt = (TextBox)e.Row.FindControl("txt_TDS_Amt");

            if (isch_tds != null)
            {
                bool hasTdsRate = txt_tds_Rate != null &&
                                  !string.IsNullOrWhiteSpace(txt_tds_Rate.Text) &&
                                  txt_tds_Rate.Text.Trim() != "0" &&
                                  txt_tds_Rate.Text.Trim() != "0.00";

                bool hasTdsAmt = txt_tds_amt != null &&
                                 !string.IsNullOrWhiteSpace(txt_tds_amt.Text) &&
                                 txt_tds_amt.Text.Trim() != "0" &&
                                 txt_tds_amt.Text.Trim() != "0.00";

                // Disable if either Rate or Amount exists
                isch_tds.Enabled = !(hasTdsRate || hasTdsAmt);
            }
        }
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
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Payment Entry', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Payment Entry', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
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
                        string txtInrAmtText = txtDebit_bank.Text;
                        string lblTotalAdjText = Hidden_lblTotalAdjustment.Value;
                        decimal txtInrAmt;
                        decimal lblTotalAdj;
                        bool txtInrAmtValid = decimal.TryParse(txtInrAmtText, out txtInrAmt);
                        bool lblTotalAdjValid = decimal.TryParse(lblTotalAdjText, out lblTotalAdj);
                        if (txtInrAmt >= lblTotalAdj)
                        {
                            ds = Payment_Insert_Update("SAVE", bill_details());
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                if (ds.Tables[0].Rows[0]["BP_ID"].ToString() != "0")
                                {
                                    HD_Ch_update_id.Value = ds.Tables[0].Rows[0]["BP_ID"].ToString();

                                    btnUpdate.Visible = true;
                                    btnDelete.Visible = true;
                                    btnSave.Visible = false;
                                    btnSave.Focus();
                                    ViewState["UPDATED_ID"] = null;
                                    Alert_msg("Payment Entry Saved Successfully", "btnSave");
                                }
                                else
                                {
                                    Alert_msg("Save above Details", "btnSave");
                                }
                            }
                            else
                            {
                                Alert_msg("Payment Not Saved", "btnSave");
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
                            Alert_msg("Total Adjustment Amt Greater than Debit Amt", "txt_INR_Amt");
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
            string txtInrAmtText = txtDebit_bank.Text;
            string lblTotalAdjText = Hidden_lblTotalAdjustment.Value;
            decimal txtInrAmt;
            decimal lblTotalAdj;
            bool txtInrAmtValid = decimal.TryParse(txtInrAmtText, out txtInrAmt);
            bool lblTotalAdjValid = decimal.TryParse(lblTotalAdjText, out lblTotalAdj);
            if (txtInrAmt >= lblTotalAdj)
            {
                ds = Payment_Insert_Update("UPDATE", bill_details());

                if (ds.Tables[0].Rows.Count >= 0)
                {
                    HD_Ch_update_id.Value = ds.Tables[0].Rows[0]["BP_ID"].ToString();

                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSave.Visible = false;
                    btnSave.Focus();
                    ViewState["UPDATED_ID"] = null;
                    Alert_msg("Payment Entry Updated Successfully", "btnSave");
                }
                else
                {
                    Alert_msg("Payment Not Updated", "btnSave");
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
                Alert_msg("Total Adjustment Amt Greater than Debit Amt", "txt_INR_Amt");
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
            int uncheckedCount = gvAll.Rows.Cast<GridViewRow>()
     .Count(row => ((CheckBox)row.FindControl("ischk")).Checked == false);
            if (uncheckedCount != 0)
            {
                ds = Payment_Insert_Update("UPDATE", bill_details());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    HD_Ch_update_id.Value = ds.Tables[0].Rows[0]["BP_ID"].ToString();

                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSave.Visible = false;
                    btnSave.Focus();
                    ViewState["UPDATED_ID"] = null;
                    Alert_msg("Payment Entry deleted Successfully", "btnDelete");
                }
                else
                {
                    Alert_msg("Payment Not deleted", "btnDelete");
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
            Payment_Insert_Update("Delete", "");
            if (ds.Tables[0].Rows.Count == 0)
            {
                ViewState["UPDATED_ID"] = null;
                btnNew_Click(sender, e);
                Alert_msg("Payment Entry Deleted");
            }
            else
            {
                Alert_msg("Payment Entry Not Deleted", "btnDelete");
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
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
            btn_JV_Delete.Visible = false;
            btnUpdate.CssClass = "updates";
            btnsup.Text = "Save";
            ViewState["UPDATED_ID"] = null;
            HD_Ch_update_id.Value = "";
            gvAll.DataSource = dt;
            gvAll.DataBind();
            PD.ResetFields(Page.Controls);
            Load_CP_No();

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
            txt_INR_Amt.Text = Hidden_iNR.Value;
            string txtInrAmtText = txtDebit_bank.Text;
            string lblTotalAdjText = Hidden_lblTotalAdjustment.Value;
            decimal txtInrAmt;
            decimal lblTotalAdj;
            bool txtInrAmtValid = decimal.TryParse(txtInrAmtText, out txtInrAmt);
            bool lblTotalAdjValid = decimal.TryParse(lblTotalAdjText, out lblTotalAdj);
            if (ddl_Bank_From.SelectedValue.ToString() != string.Empty)
            {
                if (ddlPartyname.SelectedValue.ToString() != string.Empty)
                {
                    if (txt_INR_Amt.Text != "" || Hidden_iNR.Value != "")
                    {
                        if (txtInrAmt >= lblTotalAdj)
                        {
                            Payment_Save();
                        }
                        else
                        {
                            Alert_msg("Total Adjustment Amt Greater than Debit Amt", "txt_INR_Amt");
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
            else
            {
                Alert_msg("Select Ur Bank!", "ddl_Bank_From");
            }


        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void Payment_Save()
    {
        if (btnsup.Text == "Save")
        {
            ds = Payment_Insert_Update("S", bill_details());
            if (ds.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = ds.Tables[0].Rows[0]["BP_ID"].ToString();
                btnsup.Text = "Update";

                btn_JV_Delete.Visible = true;
                Alert_msg("Saved Successfully!", "btn_Save_Update");
            }
        }
        else if (btnsup.Text == "Update")
        {
            ds = Payment_Insert_Update("U", bill_details());
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnsup.Text = "Update";
                Alert_msg("Updated Successfully!", "btn_Save_Update");
            }
        }
    }

    public DataSet Payment_Insert_Update(string S1, string xmlData_A)
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
        ObjUBO.A22 = txt_TDS_Deducted_Inr_I.Text;
        ObjUBO.A23 = txt_Narration.Text;
        ObjUBO.A24 = lbl_Job_Company_Lic.Text;
        ObjUBO.A25 = lbl_Job_Wrk_Period.Text;
        ObjUBO.A26 = ddlTDS_Section.SelectedValue;
        ObjUBO.A27 = txt_TDS_Rate.Text;
        ObjUBO.A28 = ddl_Bank_From.SelectedValue;
        ObjUBO.A29 = txt_Issuer_Bank_info_No.Text;
        ObjUBO.A30 = txtDebit_bank.Text;
        ObjUBO.A31 = Chk_To_Org.Checked ? "T" : "F";

        ObjUBO.A32 = txtPaid_Org_I.Text;
        ObjUBO.A33 = txtPaid_Org_II.Text;
        ObjUBO.A34 = TxtbankCharge_Inr_II.Text;
        ObjUBO.A35 = TxtbankCharge_Inr_I.Text;
        ObjUBO.A36 = txtDebit_bank_Inr_II.Text;
        ObjUBO.A37 = txt_payee.Text;
        ObjUBO.A38 = ddlPayee_type.SelectedValue;
        ObjUBO.A39 = txt_TDS_Deducted_Inr_II.Text;
        ObjUBO.A40 = txtDebit_bank_Inr_I.Text;
        ObjUBO.A41 = hfBankGLCode.Value;
        PD.xmlString = xmlData_A;
        ObjUBO.A53 = S1;

        ds = PD.ACC_GST_BP_PAYMENT_ENTRY_INS_UPD(ObjUBO);
        return ds;
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