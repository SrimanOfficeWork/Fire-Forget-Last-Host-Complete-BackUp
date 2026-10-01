using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Acc_Payments_Others_Entry : ThemeClass
{   
    AppSession aps = new AppSession();    
    Payment_Entry_Cash_Withdrawal PCW = new Payment_Entry_Cash_Withdrawal();
    User_Creation user_Create = new User_Creation();

    Global_variables ObjUBO = new Global_variables();

    public int i;
    public string BP_C_ID = string.Empty;
    public string refreshID = string.Empty;
    public string refreshIDFlag = string.Empty;

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
            if (!Page.IsPostBack)
            {
                BP_C_ID = !string.IsNullOrEmpty(Request.QueryString["BP_C_ID"])
                    ? Request.QueryString["BP_C_ID"]
                    : Request.QueryString["R_ID"];

                DataTable dtt = new DataTable();
                btnJrnNew.Visible = false;

                if (string.IsNullOrEmpty(BP_C_ID))
                {
                    load_Bank_Name();
                    Load_CP_No();
                    btnsup.Text = "Save";
                    txt_Posting_Date.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    btn_OR_Delete.Visible = false;
                    gv_details.DataSource = dtt;
                    gv_details.DataBind();
                }
                else
                {
                    btnsup.Text = "Update";
                    btn_OR_Delete.Visible = true;
                    btnJrnNew.Visible = true;
                    load_Bank_Name();
                    Update_Item_Load();
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    /*
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
    */

    private void load_Bank_Name()
    {
        try
        {
            DataSet ds = new DataSet();
            ddl_Bank_From.Items.Clear();
            ObjUBO.A40 = "load_Bank_DetaiLs_expOP";
            ds = PCW.Acc_CashWithdrawal_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["BankDetails"] = ds.Tables[0];
                ddl_Bank_From.DataSource = ds.Tables[0];
                ddl_Bank_From.DataTextField = "BANKNAME";
                ddl_Bank_From.DataValueField = "ACCOUNT_NUMBER";                
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

    private void Load_CP_No()
    {
        DataSet ds = new DataSet();
        try
        {
            txt_BP_No_F.Text = string.Empty;
            txt_BP_No_M.Text = string.Empty;
            txt_BP_No_L.Text = string.Empty;
            txt_BP_Entry_Date.Text = string.Empty;
            ObjUBO.A40 = "BP_No_Select";
            ds = PCW.Acc_CashWithdrawal_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_BP_No_F.Text = ds.Tables[0].Rows[0]["BP_C_P"].ToString();
                txt_BP_No_M.Text = ds.Tables[0].Rows[0]["BP_C_NO"].ToString();
                txt_BP_No_L.Text = ds.Tables[0].Rows[0]["BP_C_S"].ToString();
                txt_BP_Entry_Date.Text = ds.Tables[0].Rows[0]["BP_C_DATE"].ToString();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
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
            string values = this.gv_details.DataKeys[e.Row.RowIndex]["BPL_ID"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_OtherpaymentsDetails_Update('" + values + "')");
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "')");
            e.Row.Font.Bold = true;
        }
    }

    protected void btn3_Click(object sender, EventArgs e)
    {
        string id = HDupdate_id.Value;
    }

    protected void gv_details_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string[] keys = e.CommandArgument.ToString().Split('~');
        string expAndOthPaytm = keys[0];

        if (e.CommandName == "DeleteRow")
        {
            try
            {
                ObjUBO.A1 = expAndOthPaytm;
                ObjUBO.A40 = "del_CashWD_Line_record";
                ds = PCW.Acc_CashWithdrawal_Select(ObjUBO);
                if (ds.Tables.Count == 0)
                {
                    ObjUBO.A1 = HDupdate_id.Value;
                    ObjUBO.A40 = "get_othExp_details_for_Update";
                    DataSet dsr = PCW.Acc_CashWithdrawal_Select(ObjUBO);
                    if (dsr.Tables[1].Rows.Count > 0)
                    {
                        gv_details.DataSource = dsr.Tables[1];
                        gv_details.DataBind();
                    }
                    else
                    {
                        gv_details.DataSource = dt;
                        gv_details.DataBind();
                    }
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
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Payments Other', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Payments Other', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    //function to check for record Delete.
    protected void btn_OR_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_BP_No_M.Text != string.Empty)
            {
                if (txt_BP_Entry_Date.Text != string.Empty)
                {
                    ds = expensesandOtherPayments("Delete");
                    if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                    {
                        DataTable dtt = new DataTable();
                        Alert_msg("Deleted Successfully!", "btn_Cp_Delete");
                        btnsup.Text = "Save";
                        btn_OR_Delete.Visible = false;
                        refreshID = HDupdate_id.Value;
                        refreshIDFlag = "refresh";
                        ClearControls();
                        load_Bank_Name();
                        Load_CP_No();
                        txt_Posting_Date.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        gv_details.DataSource = dtt;
                        gv_details.DataBind();
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
            //load all drop downs , bank details, 
            DataSet dsovn = new DataSet();
            ObjUBO.A40 = "load_Bank_DetaiLs_expOP";
            dsovn = PCW.Acc_CashWithdrawal_Select(ObjUBO);
            if (dsovn != null && dsovn.Tables.Count > 0 && dsovn.Tables[0].Rows.Count > 0)
            {
                ViewState["OrgLoadBankDetais"] = dsovn.Tables[0];
            }

            DataSet dss = new DataSet();
            if (refreshIDFlag == "refresh" && !string.IsNullOrEmpty(refreshID))
            {
                ObjUBO.A1 = refreshID;
            }
            else if (!string.IsNullOrEmpty(Convert.ToString(BP_C_ID)))
            {
                ObjUBO.A1 = Convert.ToString(BP_C_ID);
            }
            ObjUBO.A40 = "get_othExp_details_for_Update";            
            ds = PCW.Acc_CashWithdrawal_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = ds.Tables[0].Rows[0]["BP_C_ID"].ToString();

                txt_BP_No_F.Text = ds.Tables[0].Rows[0]["BP_C_P"].ToString();
                txt_BP_No_M.Text = ds.Tables[0].Rows[0]["BP_C_NO"].ToString();
                txt_BP_No_L.Text = ds.Tables[0].Rows[0]["BP_C_S"].ToString();

                txt_BP_Entry_Date.Text = ds.Tables[0].Rows[0]["BP_C_DATE"].ToString();
                txt_Posting_Date.Text = ds.Tables[0].Rows[0]["POSTING_DATE"].ToString();

                ddl_Cur.SelectedValue = ds.Tables[0].Rows[0]["FUND_CUR"].ToString();
                txt_Ex_Rate.Text = ds.Tables[0].Rows[0]["FUND_EX_RATE"].ToString();
                txt_Cur_Amt.Text = ds.Tables[0].Rows[0]["FUND_CUR_AMT"].ToString();

                txt_Reference.Text = ds.Tables[0].Rows[0]["REFERENCE_NUMBER"].ToString();
                txtReference_Date.Text = ds.Tables[0].Rows[0]["REFERENCE_DATE"].ToString();

                ddl_Instrument_Type.SelectedValue = ds.Tables[0].Rows[0]["INSTRUMENT_TYPE"].ToString();
                txt_Instrument_No.Text = ds.Tables[0].Rows[0]["INSTRUMENT_NO"].ToString();
                txt_Instrument_Date.Text = ds.Tables[0].Rows[0]["INSTRUMENT_DATE"].ToString();

                ddl_Payee_Type.SelectedValue = ds.Tables[0].Rows[0]["PAYEE_TYPE"].ToString();
                txt_Payee_Name.Text = ds.Tables[0].Rows[0]["PAYEE_NAME"].ToString();
                ddl_ChequeType.SelectedValue = ds.Tables[0].Rows[0]["CHEQUE_TYPE"].ToString();

                ddl_Paymente_Mode.SelectedValue = ds.Tables[0].Rows[0]["PAYMENT_MODE"].ToString();
                txt_NotOver_Amt.Text = ds.Tables[0].Rows[0]["NOT_OVER_AMOUNT"].ToString();
                txt_Narration.Text = ds.Tables[0].Rows[0]["NARRATION"].ToString();

                string value = ds.Tables[0].Rows[0]["AC_NO"].ToString();
                string[] parts = value.Split(new char[] { '_' }, 2);

                string accountNo = parts[0];
                string glCode = parts.Length > 1 ? parts[1] : "";
                if (ViewState["OrgLoadBankDetais"] != null)
                {
                    DataTable dtBank = (DataTable)ViewState["OrgLoadBankDetais"];
                    string fullAcNoValue = null;
                    foreach (DataRow row in dtBank.Rows)
                    {
                        string rowAccountNumber = row["ACCOUNT_NUMBER"].ToString();
                        string[] rowParts = rowAccountNumber.Split(new char[] { '_' }, 2);
                        string rowAccountNo = rowParts[0];
                        if (rowAccountNo == accountNo)
                        {
                            fullAcNoValue = rowAccountNumber;  
                            break;
                        }
                    }
                    if (fullAcNoValue != null)
                    {
                        ListItem matchedItem = ddl_Bank_From.Items.FindByValue(fullAcNoValue);
                        if (matchedItem != null)
                        {
                            ddl_Bank_From.ClearSelection();
                            matchedItem.Selected = true;
                        }
                    }
                }
                //ddl_Bank_From.SelectedValue = accountNo.ToString();   
                //ddl_Bank_From.SelectedValue = ds.Tables[0].Rows[0]["AC_NO"].ToString();
                hfBankGLCode.Value = glCode; // ds.Tables[0].Rows[0]["GL_CODE"].ToString();
            }
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                gv_details.DataSource = ds.Tables[1];
                gv_details.DataBind();

                CalculateTotals(ds.Tables[1]);
            }
            else if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count == 0)
            {
                DataTable dtt = new DataTable();
                gv_details.DataSource = dtt;
                gv_details.DataBind();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    /* --------------------------------------- */
    //1.1 save function 
    protected void btnsup_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddl_Bank_From.SelectedIndex <= 0)
            {
                Alert_msg("Select BANK NAME!", "ddl_Bank_From");
                return;
            }

            decimal amount;
            if (string.IsNullOrWhiteSpace(txt_Cur_Amt.Text) || !decimal.TryParse(txt_Cur_Amt.Text.Trim(), out amount) || amount <= 0)
            {
                Alert_msg("Enter a valid AMOUNT greater than 0!", "txt_Cur_Amt");
                return;
            }

            ds = expensesandOtherPayments(btnsup.Text);
            if (btnsup.Text == "Save")
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    HDupdate_id.Value = ds.Tables[0].Rows[0][0].ToString();
                    btnsup.Text = "Update";
                    btn_OR_Delete.Visible = true;
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
                    btn_OR_Delete.Visible = true;
                    btnJrnNew.Visible = true;
                    Alert_msg("Updated Successfully!", "btnsup");
                    Update_Item_Load();
                }
                else
                {
                    Alert_msg("Not Updated", "btnsup");
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    //1.2
    public DataSet expensesandOtherPayments(string flg)
    {
        ObjUBO.A1 = HDupdate_id.Value.ToString();

        ObjUBO.A3 = txt_BP_No_F.Text.Trim();
        ObjUBO.A4 = txt_BP_No_M.Text.Trim();
        ObjUBO.A5 = txt_BP_No_L.Text.Trim();

        ObjUBO.A6 = txt_BP_Entry_Date.Text.Trim();
        ObjUBO.A7 = txt_Posting_Date.Text.Trim();

        ObjUBO.A8 = ddl_Bank_From.SelectedItem.Text.Trim();     // Bank Name
        ObjUBO.A9 = txt_Cur_Amt.Text.Trim();                    // Amount
        ObjUBO.A10 = ddl_Cur.SelectedValue;                     // Currency
        ObjUBO.A11 = txt_Ex_Rate.Text.Trim();                   // Exchange Rate

        ObjUBO.A12 = txt_Reference.Text.Trim();                 // Reference No.
        ObjUBO.A13 = txtReference_Date.Text.Trim();             // Reference Date

        ObjUBO.A14 = ddl_Instrument_Type.SelectedValue;         // Instrument Type
        ObjUBO.A15 = txt_Instrument_No.Text.Trim();             // Instrument No.
        ObjUBO.A16 = txt_Instrument_Date.Text.Trim();           // Instrument Date

        ObjUBO.A17 = ddl_Payee_Type.SelectedValue;              // Payee Type
        ObjUBO.A18 = txt_Payee_Name.Text.Trim();                // Payee Name

        ObjUBO.A19 = ddl_ChequeType.SelectedValue;              // Cheque Type
        ObjUBO.A20 = ddl_Paymente_Mode.SelectedValue;           // Payment Mode

        ObjUBO.A21 = txt_NotOver_Amt.Text.Trim();               // Not Over Amount
        ObjUBO.A22 = txt_Narration.Text.Trim();                 // Narration

        string value = ddl_Bank_From.SelectedValue.ToString();
        string[] parts = value.Split(new char[] { '_' }, 2);

        string accountNo = parts[0];
        string glCode = parts.Length > 1 ? parts[1] : "";

        ObjUBO.A23 = glCode;                                        // GL Code
        ObjUBO.A24 = accountNo;                                     // Account No.        
        ObjUBO.A28 = btnsup.Text;                                   // SAVE / UPDATE / DELETE Flag        
        ObjUBO.A29 = hfTransactionRecordType.Value.Trim();          //recordType Expenses and Other Payments

        ObjUBO.A40 = flg;
        return PCW.Acc_ExpensesandOtherPayments_Ins_Upd(ObjUBO);
    }


    private void CalculateTotals(DataTable dt)
    {
        decimal totalDebit = 0;
        decimal totalCredit = 0;

        foreach (DataRow dr in dt.Rows)
        {  
            totalCredit += Convert.ToDecimal(
                string.IsNullOrEmpty(dr["AMOUNT"].ToString()) ? "0" : dr["AMOUNT"]);
        }

        lbl_Total_Debit.Text = totalCredit.ToString("N2");                
        
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

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        // TODO: RDLC Print
    }

    protected void lnk_PD_Clear_Click(object sender, EventArgs e)
    {
        // TODO: Clear payment details
    }
    protected void btn_PD_RetrieveOnAccount_Click(object sender, EventArgs e)
    {
        // TODO: Retrieve On Account logic
    }

    private void ClearControls()
    {
        HDupdate_id.Value = "";
        txt_BP_No_F.Text = "";
        txt_BP_No_M.Text = "";
        txt_BP_No_L.Text = "";
        txt_BP_Entry_Date.Text = "";
        txt_Posting_Date.Text = DateTime.Today.ToString("dd/MM/yyyy");
        ddl_Bank_From.SelectedIndex = 0;
        hfBankGLCode.Value = "";
        hfBankName.Value = "";
        txt_Cur_Amt.Text = "";
        ddl_Cur.SelectedIndex = 0;
        txt_Ex_Rate.Text = "1.00";
        txt_Reference.Text = "";
        txtReference_Date.Text = "";
        ddl_Instrument_Type.SelectedIndex = 0;
        txt_Instrument_No.Text = "";
        txt_Instrument_Date.Text = "";
        ddl_Payee_Type.SelectedIndex = 0;
        txt_Payee_Name.Text = "";
        ddl_ChequeType.SelectedIndex = 0;
        ddl_Paymente_Mode.SelectedIndex = 0;
        txt_NotOver_Amt.Text = "";
        txt_Narration.Text = "";
        gv_details.DataSource = null;
        gv_details.DataBind();        
        ViewState["GridData"] = null;
    }
}