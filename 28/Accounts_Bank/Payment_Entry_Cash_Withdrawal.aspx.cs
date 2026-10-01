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

public partial class Accounts_Payment_Payment_Entry_Cash_Withdrawal : ThemeClass
{
    AppSession aps = new AppSession();
    Payment_Entry_Cash_Withdrawal PCW = new Payment_Entry_Cash_Withdrawal();
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
                load_Acc_Name();
                if (Request.QueryString["R_ID"] == null)
                {
                    lbl_Job_Company_Lic.Text = Connection.Company_License().ToUpper();
                    lbl_Job_Wrk_Period.Text = Connection.WorkingPeriod();
                    Load_CP_No();
                }
                else
                {
                    if (Request.QueryString["R_ID"] != null && Request.QueryString["R_ID"] != string.Empty)
                    {
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
            ds = PCW.Acc_Gst_Payment_Cash_Withdrawal_Select(ObjUBO);
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
            ObjUBO.A40 = "Updated_Payment_cash_Select";
            dSS = PCW.Acc_Gst_Payment_Cash_Withdrawal_Select(ObjUBO);
            if (dSS.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = dSS.Tables[0].Rows[0]["BP_C_ID"].ToString();
                txt_BR_No_F.Text = dSS.Tables[0].Rows[0]["BP_C_P"].ToString();
                txt_BR_No_M.Text = dSS.Tables[0].Rows[0]["BP_C_NO"].ToString();
                txt_BR_No_L.Text = dSS.Tables[0].Rows[0]["BP_C_S"].ToString();
                txt_BR_Entry_Date.Text = dSS.Tables[0].Rows[0]["BP_C_DATE"].ToString().Replace("01/01/1900", "");
                txt_Posting_Date.Text = dSS.Tables[0].Rows[0]["POSTING_DATE"].ToString().Replace("01/01/1900", "");
                ddl_Bank_From.SelectedValue = dSS.Tables[0].Rows[0]["AC_NO"].ToString();
                ddl_Cur.SelectedValue = dSS.Tables[0].Rows[0]["FUND_CUR"].ToString();
                txt_Ex_Rate.Text = dSS.Tables[0].Rows[0]["FUND_EX_RATE"].ToString();
                txt_Cur_Amt.Text = dSS.Tables[0].Rows[0]["FUND_CUR_AMT"].ToString();
                txt_INR_Amt.Text = dSS.Tables[0].Rows[0]["FUND_INR_AMT"].ToString();
                Hidden_iNR.Value = dSS.Tables[0].Rows[0]["FUND_INR_AMT"].ToString();
                txt_Reference.Text = dSS.Tables[0].Rows[0]["REFERENCE_NUMBER"].ToString();
                txtReference_Date.Text = dSS.Tables[0].Rows[0]["REFERENCE_DATE"].ToString().Replace("01/01/1900", "");
                txt_Narration.Text = dSS.Tables[0].Rows[0]["NARRATION"].ToString();
                lbl_Job_Company_Lic.Text = dSS.Tables[0].Rows[0]["JOB_LICENSE"].ToString();
                lbl_Job_Wrk_Period.Text = dSS.Tables[0].Rows[0]["JOB_WORKINGPERIOD"].ToString();
                txt_INR_Amt.Enabled = false;
                if (dSS.Tables[0].Rows[0]["FLAG"].ToString() == "C")
                {
                    btnSave.Visible = false;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
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
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    private void load_Acc_Name()
    {
        try
        {
            ddl_Bank_From.Items.Clear();
            DataSet ds = new DataSet();
            ObjUBO.A40 = "load_Bank_Detais";
            ds = PCW.Acc_Gst_Payment_Cash_Withdrawal_Select(ObjUBO);
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
            if (ddl_Bank_From.SelectedValue.ToString() != string.Empty)
            {
                ds = Payment_Insert_Update("S", "");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["BP_C_ID"].ToString() != "0")
                    {
                        HDupdate_id.Value = ds.Tables[0].Rows[0]["BP_C_ID"].ToString();

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


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string a = HDupdate_id.Value;
            ds = Payment_Insert_Update("U", a);
            if (ds.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = ds.Tables[0].Rows[0]["BP_C_ID"].ToString();
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

            ds = Payment_Insert_Update("Delete", "");
            if (ds.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = ds.Tables[0].Rows[0]["BP_C_ID"].ToString();
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
            HDupdate_id.Value = "";
            ddl_Bank_From.Items.Clear();
            PCW.ResetFields(Page.Controls);
            txt_Ex_Rate.Text = "1.00";
            load_Acc_Name();
            Load_CP_No();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public DataSet Payment_Insert_Update(string S1, string S2)
    {
        ObjUBO.A1 = S2;
        ObjUBO.A3 = txt_BR_No_F.Text;
        ObjUBO.A4 = txt_BR_No_M.Text;
        ObjUBO.A5 = txt_BR_No_L.Text;
        ObjUBO.A6 = txt_BR_Entry_Date.Text;
        ObjUBO.A7 = txt_Posting_Date.Text;
        ObjUBO.A8 = ddl_Bank_From.SelectedItem.Text;
        ObjUBO.A9 = ddl_Bank_From.SelectedValue;
        ObjUBO.A11 = S2;
        ObjUBO.A10 = ddl_Cur.SelectedValue;
        ObjUBO.A11 = txt_Ex_Rate.Text;
        ObjUBO.A12 = txt_Cur_Amt.Text;
        txt_INR_Amt.Text = Hidden_iNR.Value;
        ObjUBO.A13 = Hidden_iNR.Value;
        ObjUBO.A14 = txt_Narration.Text;
        ObjUBO.A15 = txt_Reference.Text;
        ObjUBO.A16 = txtReference_Date.Text;
        ObjUBO.A17 = lbl_Job_Company_Lic.Text;
        ObjUBO.A18 = lbl_Job_Wrk_Period.Text;
        ObjUBO.A19 = S1;
        ds = PCW.Acc_Gst_Payment_Cash_Withdrawal_Ins_Upd(ObjUBO);
        return ds;
    }
}