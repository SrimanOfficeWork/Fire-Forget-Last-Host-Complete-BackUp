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

public partial class Accounts_Payment_Payment_Entry_Other : ThemeClass
{
    AppSession aps = new AppSession();
    Payment_Entry_others PEO = new Payment_Entry_others();
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
                gvAll.DataSource = dt;
                gvAll.DataBind();
                if (Request.QueryString["R_ID"] == null)
                {
                    lbl_Job_Company_Lic.Text = Connection.Company_License().ToUpper();
                    lbl_Job_Wrk_Period.Text = Connection.WorkingPeriod();
                    load_Charge_name();
                    load_Bank_Name();
                    Load_CP_No();
                    btnsup.Text = "Save";
                    btn_JV_Delete.Visible = false;
                }
                else
                {
                    if (Request.QueryString["R_ID"] != null && Request.QueryString["R_ID"] != string.Empty)
                    {
                        btnsup.Text = "Update";
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

    private void load_Charge_name()
    {
        try
        {
            DataSet dss = new DataSet();
            ddlcharge.Items.Clear();
            ObjUBO.A40 = "Load_Charge";
            dss = PEO.Acc_Gst_BP_Other_Payment_Select(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                ddlcharge.DataSource = dss.Tables[0];
                ddlcharge.DataTextField = "CHARGE_NAME";
                ddlcharge.DataValueField = "CHARGE_VALUE";
                ddlcharge.DataBind();
            }
            if (dss.Tables[1].Rows.Count > 0)
            {
                ddl_Ven_Billno.DataSource = dss.Tables[1];
                ddl_Ven_Billno.DataTextField = "VENDOR_BILL_NO";
                ddl_Ven_Billno.DataValueField = "VENDOR_BILL_NO";
                ddl_Ven_Billno.DataBind();
            }
            ddlcharge.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlcharge.SelectedIndex = 0;
            ddl_Ven_Billno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Ven_Billno.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
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
            ds = PEO.Acc_Gst_BP_Other_Payment_Select(ObjUBO);
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

    protected void gvAll_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["CHARGE_ID"] = Convert.ToString(this.gvAll.SelectedRow.Cells[2].Text);
        if (ViewState["CHARGE_ID"] != "" && ViewState["CHARGE_ID"] != null)
        {
            Hidden_ch_amt.Value = "";
            ddlcharge.SelectedValue = gvAll.SelectedRow.Cells[3].Text.Replace("&nbsp;", "").Replace("&amp;","&");
            txtAmt.Text = gvAll.SelectedRow.Cells[4].Text.Replace("&amp;nbsp;", "");
            ddl_Amt_Type.SelectedValue = gvAll.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            ddl_Exp_Branch.SelectedItem.Text = gvAll.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            ddl_Tax.SelectedValue = gvAll.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            txtNarration.Text = gvAll.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
            ddl_Ven_Billno.SelectedValue= gvAll.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
            
            Hidden_ch_amt.Value = gvAll.SelectedRow.Cells[4].Text.Replace("amp;", "");
            ViewState["UPDATED_ID"] = null;
            ViewState["UPDATED_ID"] = ViewState["CHARGE_ID"].ToString();
            btnUpdate.CssClass = "updates";
            if ( HiddenField1_FLAG.Value =="1")
            {
                btnSave.Visible = false;
                btnsup.Visible = false;
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btn_JV_Delete.Visible = false;
                btnNew.Visible = false;
            }
            else
            {
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
            }
        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }
    }

    private void Update_Item_Load()
    {
        try
        {
            load_Bank_Name();
            load_Charge_name();
            DataSet dSS = new DataSet();
            ObjUBO.A1 = Request.QueryString["R_ID"].ToString();
            ObjUBO.A40 = "Updated_Payment_Other_Select";
            dSS = PEO.Acc_Gst_BP_Other_Payment_Select(ObjUBO);
            if (dSS.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = dSS.Tables[0].Rows[0]["BP_O_ID"].ToString();
                txt_BR_No_F.Text = dSS.Tables[0].Rows[0]["BP_O_P"].ToString();
                txt_BR_No_M.Text = dSS.Tables[0].Rows[0]["BP_O_NO"].ToString();
                txt_BR_No_L.Text = dSS.Tables[0].Rows[0]["BP_O_S"].ToString();
                txt_BR_Entry_Date.Text = dSS.Tables[0].Rows[0]["BP_O_DATE"].ToString().Replace("01/01/1900", "");
                txt_Posting_Date.Text = dSS.Tables[0].Rows[0]["POSTING_DATE"].ToString().Replace("01/01/1900", "");
                ddl_Issuer_Bank_Name.SelectedValue = dSS.Tables[0].Rows[0]["ISSUSER_BANK_NAME"].ToString();
                txt_Issuer_Bank_Accno.Text = dSS.Tables[0].Rows[0]["ISSUSER_BANK_NO"].ToString();
                ddl_Bank_From.SelectedItem.Text = dSS.Tables[0].Rows[0]["BANK_NAME"].ToString();
                ddl_Bank_From.SelectedValue = dSS.Tables[0].Rows[0]["AC_NO"].ToString();
                ddl_Issuer_Bank_info_Type.SelectedValue = dSS.Tables[0].Rows[0]["FUND_TYPE"].ToString();
                txt_Issuer_Bank_info_Date.Text = dSS.Tables[0].Rows[0]["FUND_DATE"].ToString().Replace("01/01/1900", "");
                ddl_Cur.SelectedValue = dSS.Tables[0].Rows[0]["FUND_CUR"].ToString();
                txt_Ex_Rate.Text = dSS.Tables[0].Rows[0]["FUND_EX_RATE"].ToString();
                txt_Cur_Amt.Text = dSS.Tables[0].Rows[0]["FUND_CUR_AMT"].ToString();
                txt_INR_Amt.Text = dSS.Tables[0].Rows[0]["FUND_INR_AMT"].ToString();
                Hidden_iNR.Value = dSS.Tables[0].Rows[0]["FUND_INR_AMT"].ToString();
                txt_Reference.Text = dSS.Tables[0].Rows[0]["REFERANCE_NUMBER"].ToString();
                txtReference_Date.Text = dSS.Tables[0].Rows[0]["REFERENCE_DATE"].ToString().Replace("01/01/1900", "");
                txt_Narration.Text = dSS.Tables[0].Rows[0]["NARRATION"].ToString();
                txt_Issuer_Bank_info_No.Text = dSS.Tables[0].Rows[0]["Issuer_Bank_info_No"].ToString();
                lbl_Job_Company_Lic.Text = dSS.Tables[0].Rows[0]["JOB_LICENSE"].ToString();
                lbl_Job_Wrk_Period.Text = dSS.Tables[0].Rows[0]["JOB_WORKINGPERIOD"].ToString();
                txt_INR_Amt.Enabled = false;
                HiddenField1_FLAG.Value = "";
                if (dSS.Tables[0].Rows[0]["FLAG"].ToString() == "C")
                {
                    btnSave.Visible = false;
                    btnsup.Visible = false;
                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                    btn_JV_Delete.Visible = false;
                    btnNew.Visible = false;
                    HiddenField1_FLAG.Value = "1";
                }
                else
                {
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btn_JV_Delete.Visible = true;
                   
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


    private void load_Bank_Name()
    {
        try
        {

            DataSet ds = new DataSet();
            ObjUBO.A40 = "load_Bank_Detais";
            ds = PEO.Acc_Gst_BP_Other_Payment_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_Bank_From.DataSource = ds.Tables[0];
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

    protected void gvAll_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
                e.Row.Enabled = true;
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gvAll, "Select$" + e.Row.RowIndex.ToString()));
           
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
            if (ddlcharge.SelectedValue != "")
            {
                if (ddl_Bank_From.SelectedValue.ToString() != string.Empty)
                {
                    string txtInrAmtText = txt_INR_Amt.Text;
                    string lblTotalAdjText = Hidden_lblTotal.Value;
                    string charge_AmtText = txtAmt.Text;
                    string charge_select_Amt_Text = Hidden_ch_amt.Value;
                    decimal txtInrAmt;
                    decimal lblTotalAdj;
                    decimal lblch_Amt;
                    decimal charge_In_Am_Text;
                    bool txtInrAmtValid = decimal.TryParse(txtInrAmtText, out txtInrAmt);
                    bool lblTotalAdjValid = decimal.TryParse(lblTotalAdjText, out lblTotalAdj);
                    bool lbltot_AmtValid = decimal.TryParse(charge_AmtText, out lblch_Amt);
                    bool intot_AmtValid = decimal.TryParse(charge_select_Amt_Text, out charge_In_Am_Text);
                    decimal VAL = ((lblTotalAdj - charge_In_Am_Text) + lblch_Amt);
                    if (txtInrAmt >= (lblTotalAdj + lblch_Amt))
                    {

                        ds = Payment_Insert_Update("SAVE", "");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["BP_O_ID"].ToString() != "0")
                            {
                                HD_Ch_update_id.Value = ds.Tables[0].Rows[0]["BP_O_ID"].ToString();

                                btnUpdate.Visible = true;
                                btnDelete.Visible = true;
                                btnSave.Visible = false;
                                btnSave.Focus();
                                ViewState["UPDATED_ID"] = null;
                                Alert_msg("Payment Entry Saved Successfully", "btnSave");
                                btnNew_Click(this, null);
                            }
                            else
                            {
                                Alert_msg("Save above Details", "btnSave");
                            }
                        }
                        else
                        {
                            Alert_msg("Payment Entry Not Saved", "btnSave");
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
                        Alert_msg("Total Amount Greater than Inr Amt", "txt_INR_Amt");
                    }

                }
                else
                {
                    Alert_msg("Select Ur Bank!", "ddl_Bank_From");
                }

            }
            else
            {
                Alert_msg("Select Ur Charge!", "ddlcharge");
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
            if (ddlcharge.SelectedValue != "")
            {
                string txtInrAmtText = txt_INR_Amt.Text;
                string lblTotalAdjText = Hidden_lblTotal.Value;
                string charge_AmtText = txtAmt.Text;
                string charge_select_Amt_Text = Hidden_ch_amt.Value;
                decimal txtInrAmt;
                decimal lblTotalAdj;
                decimal lblch_Amt;
                decimal charge_In_Am_Text;
                bool txtInrAmtValid = decimal.TryParse(txtInrAmtText, out txtInrAmt);
                bool lblTotalAdjValid = decimal.TryParse(lblTotalAdjText, out lblTotalAdj);
                bool lbltot_AmtValid = decimal.TryParse(charge_AmtText, out lblch_Amt);
                bool intot_AmtValid = decimal.TryParse(charge_select_Amt_Text, out charge_In_Am_Text);
                if (txtInrAmt >= ((lblTotalAdj - charge_In_Am_Text) + lblch_Amt))
                {
                    string a = ViewState["CHARGE_ID"].ToString();
                    ds = Payment_Insert_Update("UPDATE", a);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        HD_Ch_update_id.Value = ds.Tables[0].Rows[0]["BP_O_ID"].ToString();

                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                        btnSave.Visible = false;
                        btnSave.Focus();
                        ViewState["UPDATED_ID"] = null;
                        Alert_msg("Payment Entry Updated Successfully", "btnSave");
                    }
                    else
                    {
                        Alert_msg("Payment Entry Not Updated", "btnSave");
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
                    Alert_msg("Total Amount Greater than Inr Amt", "txt_INR_Amt");
                }
            }
            else
            {
                Alert_msg("Select Ur Charge!", "ddlcharge");
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
            string a = ViewState["CHARGE_ID"].ToString();
            ds = Payment_Insert_Update("CHARGE_Delete", a);

            if (ds.Tables[0].Rows.Count > 0)
            {
                HD_Ch_update_id.Value = ds.Tables[0].Rows[0]["BP_O_ID"].ToString();

                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnSave.Focus();
                ViewState["UPDATED_ID"] = null;
                Alert_msg("Payment Entry deleted Successfully", "btnDelete");
                btnNew_Click(this, null);
            }
            else
            {
                Alert_msg("Payment Entry Not deleted", "btnDelete");
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
                Alert_msg("Payment Not Deleted", "btnDelete");
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
            btnUpdate.CssClass = "updates";
            ViewState["UPDATED_ID"] = null;
            HD_Ch_update_id.Value = "";
            ddlcharge.SelectedValue = "";
            txtAmt.Text = "";
            ddl_Amt_Type.SelectedValue = "";
            ddl_Exp_Branch.SelectedValue = "";
            ddl_Tax.SelectedValue = "";
            txtNarration.Text = "";
            ddl_Ven_Billno.SelectedIndex = -1;
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

            if (txt_Cur_Amt.Text != string.Empty)
            {
                if (ddl_Bank_From.SelectedValue.ToString() != string.Empty)
                {
                    Payment_Save();
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
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void Payment_Save()
    {
        if (btnsup.Text == "Save")
        {
            ds = Payment_Insert_Update("S", "");
            if (ds.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = ds.Tables[0].Rows[0]["BP_O_ID"].ToString();
                btnsup.Text = "Update";
                btn_JV_Delete.Visible = true;
                Alert_msg("Saved Successfully!", "btn_Save_Update");
            }
        }
        else if (btnsup.Text == "Update")
        {
            ds = Payment_Insert_Update("U", "");
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnsup.Text = "Update";
                Alert_msg("Updated Successfully!", "btn_Save_Update");
            }
        }
    }

    public DataSet Payment_Insert_Update(string S1, string S2)
    {
        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A3 = txt_BR_No_F.Text;
        ObjUBO.A4 = txt_BR_No_M.Text;
        ObjUBO.A5 = txt_BR_No_L.Text;
        ObjUBO.A6 = txt_BR_Entry_Date.Text;
        ObjUBO.A7 = txt_Posting_Date.Text;
        ObjUBO.A28 = ddl_Bank_From.SelectedValue;
        ObjUBO.A8 = ddl_Bank_From.SelectedItem.Text;
        ObjUBO.A9 = ddl_Issuer_Bank_Name.SelectedValue;
        ObjUBO.A10 = txt_Issuer_Bank_Accno.Text;
        ObjUBO.A11 = S2;
        ObjUBO.A12 = ddlcharge.SelectedValue;
        ObjUBO.A13 = ddl_Issuer_Bank_info_Type.SelectedValue;
        ObjUBO.A15 = txt_Issuer_Bank_info_Date.Text;
        ObjUBO.A16 = ddl_Cur.SelectedValue;
        ObjUBO.A17 = txt_Ex_Rate.Text;
        ObjUBO.A18 = txt_Cur_Amt.Text;
        txt_INR_Amt.Text = Hidden_iNR.Value;
        ObjUBO.A19 = Hidden_iNR.Value;
        ObjUBO.A20 = txtAmt.Text;
        ObjUBO.A21 = ddl_Amt_Type.SelectedValue;
        ObjUBO.A22 = ddl_Tax.SelectedValue;
        ObjUBO.A29 = ddl_Exp_Branch.SelectedItem.Text;
        ObjUBO.A23 = txt_Narration.Text;
        ObjUBO.A24 = lbl_Job_Company_Lic.Text;
        ObjUBO.A25 = lbl_Job_Wrk_Period.Text;
        ObjUBO.A30 = txtNarration.Text;
        ObjUBO.A31 = txt_Reference.Text;
        ObjUBO.A32 = txtReference_Date.Text;
        ObjUBO.A27 = S1;
        ObjUBO.A33 = txt_Issuer_Bank_info_No.Text;
        ObjUBO.A34 = ddl_Ven_Billno.SelectedValue.ToString();
        ds = PEO.ACC_GST_BP_O_RECEIPT_ENTRY_INS_UPD(ObjUBO);
        return ds;
    }
    protected void ddlcharge_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlcharge.SelectedValue.ToString() != string.Empty)
        {
            string[] chargename = (ddlcharge.SelectedValue.ToString()).Split('~');
            int cnt = int.Parse(chargename.Length.ToString());
            if (cnt == 2)
            {
                ddl_Tax.SelectedValue = chargename[0];
            }
            else
            {
                ddl_Tax.SelectedIndex = -1;
            }
        }
        else
        {
            ddl_Tax.SelectedIndex = -1;
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


    protected void ddl_Ven_Billno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Ven_Billno.SelectedValue.ToString() != string.Empty)
        {
            DataSet ds = new DataSet();
            ObjUBO.A4 = ddl_Ven_Billno.SelectedValue.ToString();
            ObjUBO.A40 = "Vendor_Bill_No_Amt";
            ds = PEO.Acc_Gst_BP_Other_Payment_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtAmt.Text = ds.Tables[0].Rows[0]["AMT_IN_INR"].ToString();
            }
            else
            {
                txtAmt.Text=string.Empty;
            }
        }
        else
        { 
            txtAmt.Text=string.Empty;
        }
    }
}