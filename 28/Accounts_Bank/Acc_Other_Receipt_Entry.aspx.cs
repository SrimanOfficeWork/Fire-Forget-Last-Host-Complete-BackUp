using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Acc_Other_Receipt_Entry : ThemeClass
{
    AppSession aps = new AppSession();
    //Receipt_Entry_Others REO = new Receipt_Entry_Others();
    Acc_BOReceiptEntry_cs BOR = new Acc_BOReceiptEntry_cs();
    User_Creation user_Create = new User_Creation();

    Global_variables ObjUBO = new Global_variables();

    public int i;
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
                DataTable dtt = new DataTable();
                btnJrnNew.Visible = false;
                if (Request.QueryString["BR_O_ID"] == null || Request.QueryString["BR_O_ID"] == "")
                {
                    //dt.Columns.Add("PCL_ID");
                    //load_Charge_name();
                    load_Bank_Name();
                    Load_CP_No();
                    btnsup.Text = "Save";
                    btn_OR_Delete.Visible = false;
                    gv_details.DataSource = dtt;
                    gv_details.DataBind();
                }
                else
                {
                    if (Request.QueryString["BR_O_ID"] != null && Request.QueryString["BR_O_ID"] != string.Empty)
                    {
                        btnsup.Text = "Update";
                        btn_OR_Delete.Visible = true;
                        btnJrnNew.Visible = true;
                        load_Bank_Name();
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

    private void load_Bank_Name()
    {
        try
        {
            DataSet ds = new DataSet();
            ddl_Bank_From.Items.Clear();
            ObjUBO.A40 = "load_Bank_Detais";
            ds = BOR.Acc_Gst_Other_Receipt_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["BankDetails"] = ds.Tables[0];
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
            ds = BOR.Acc_Gst_Other_Receipt_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_BR_No_F.Text = ds.Tables[0].Rows[0]["BR_O_P"].ToString();
                txt_BR_No_M.Text = ds.Tables[0].Rows[0]["BR_O_NO"].ToString();
                txt_BR_No_L.Text = ds.Tables[0].Rows[0]["BR_O_S"].ToString();
                txt_BR_Entry_Date.Text = ds.Tables[0].Rows[0]["BR_O_DATE"].ToString();
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
            string values = this.gv_details.DataKeys[e.Row.RowIndex]["BORL_ID"].ToString();
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_OtherReceipts_Details_Update('" + values + "')");
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "')");
            e.Row.Font.Bold = true;
        }
    }

    protected void gv_details_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string[] keys = e.CommandArgument.ToString().Split('~');
        string othRptsLineid = keys[0];

        if (e.CommandName == "DeleteRow")
        {
            try
            {
                ObjUBO.A1 = othRptsLineid;
                ObjUBO.A40 = "del_OthReceipts_Line_record";
                ds = BOR.Acc_Gst_Other_Receipt_Select(ObjUBO);
                if (ds.Tables.Count == 0)
                {
                    ObjUBO.A1 = HDupdate_id.Value;
                    ObjUBO.A40 = "get_OR_details_for_Update";
                    DataSet dsr = BOR.Acc_Gst_Other_Receipt_Select(ObjUBO);
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
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Other Receipt Entry', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Other Receipt Entry', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    //function to check for record Delete.
    protected void btn_OR_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_BR_No_M.Text != string.Empty)
            {
                if (txt_BR_Entry_Date.Text != string.Empty)
                {
                    ds = otherReceipts_Ins_Upd("Delete");                    
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
            ObjUBO.A40 = "load_Bank_Detais";
            dsovn = BOR.Acc_Gst_Other_Receipt_Select(ObjUBO);
            if (dsovn != null && dsovn.Tables.Count > 0 && dsovn.Tables[0].Rows.Count > 0)
            {
                ViewState["OrgLoadBankDetais"] = dsovn.Tables[0];
            }

            DataSet dss = new DataSet();
            if (refreshIDFlag == "refresh" && !string.IsNullOrEmpty(refreshID))
            {
                ObjUBO.A1 = refreshID;
            }
            else if (!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["BR_O_ID"])))
            {
                ObjUBO.A1 = Convert.ToString(Request.QueryString["BR_O_ID"]);
            }
            ObjUBO.A40 = "get_OR_details_for_Update";
            ds = BOR.Acc_Gst_Other_Receipt_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {   
                HDupdate_id.Value = ds.Tables[0].Rows[0]["BR_O_ID"].ToString();

                txt_BR_No_F.Text = ds.Tables[0].Rows[0]["BR_O_P"].ToString();
                txt_BR_No_M.Text = ds.Tables[0].Rows[0]["BR_O_NO"].ToString();
                txt_BR_No_L.Text = ds.Tables[0].Rows[0]["BR_O_S"].ToString();

                txt_BR_Entry_Date.Text = ds.Tables[0].Rows[0]["BR_O_DATE"].ToString();
                txt_Posting_Date.Text = ds.Tables[0].Rows[0]["POSTING_DATE"].ToString();

                txt_Cur_Amt.Text = ds.Tables[0].Rows[0]["FUND_CUR_AMT"].ToString();
                ddl_Cur.SelectedValue = ds.Tables[0].Rows[0]["FUND_CUR"].ToString();
                txt_Ex_Rate.Text = ds.Tables[0].Rows[0]["FUND_EX_RATE"].ToString();
                txt_Reference.Text = ds.Tables[0].Rows[0]["REFERENCE_NUMBER"].ToString();
                txtReference_Date.Text = ds.Tables[0].Rows[0]["REFERENCE_DATE"].ToString();

                ddl_Issuer_Bank_info_Type.SelectedValue = ds.Tables[0].Rows[0]["FUND_TYPE"].ToString();
                txt_Issuer_Bank_info_No.Text = ds.Tables[0].Rows[0]["ISSUER_BANK_INFO_NO"].ToString();
                txt_Issuer_Bank_info_Date.Text = ds.Tables[0].Rows[0]["FUND_DATE"].ToString();

                ddl_Issuer_Bank_Name.SelectedValue = ds.Tables[0].Rows[0]["ISSUSER_BANK_NAME"].ToString();
                txt_Issuer_Bank_Branch.Text = ds.Tables[0].Rows[0]["ISSUSER_BANK_NO"].ToString();

                txt_Narration.Text = ds.Tables[0].Rows[0]["NARRATION"].ToString();

                string accountNo = ds.Tables[0].Rows[0]["AC_NO"].ToString();

                if (ddl_Bank_From.Items.FindByValue(accountNo) != null)
                {
                    ddl_Bank_From.SelectedValue = accountNo;
                }
                hfBankGLCode.Value = ds.Tables[0].Rows[0]["GL_CODE"].ToString();
            }
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                gv_details.DataSource = ds.Tables[1];
                gv_details.DataBind();
            }
            else
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

            if (txt_Posting_Date.Text == string.Empty)
            {
                Alert_msg("Enter Posting Date!", "txt_Posting_Date");
                return;
            }

            ds = otherReceipts_Ins_Upd(btnsup.Text);            
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
    public DataSet otherReceipts_Ins_Upd(string flg)
    {
        ObjUBO.A1 = HDupdate_id.Value.ToString();

        ObjUBO.A3 = txt_BR_No_F.Text;
        ObjUBO.A4 = txt_BR_No_M.Text;
        ObjUBO.A5 = txt_BR_No_L.Text;

        ObjUBO.A6 = txt_BR_Entry_Date.Text;
        ObjUBO.A7 = txt_Posting_Date.Text;
        ObjUBO.A8 = ddl_Bank_From.SelectedItem.Text;
        ObjUBO.A9 = txt_Cur_Amt.Text;
        ObjUBO.A10 = ddl_Cur.Text;
        ObjUBO.A11 = txt_Ex_Rate.Text;
        ObjUBO.A12 = txt_Reference.Text;
        ObjUBO.A13 = txtReference_Date.Text;
        ObjUBO.A14 = ddl_Issuer_Bank_info_Type.Text;
        ObjUBO.A15 = txt_Issuer_Bank_info_No.Text;
        ObjUBO.A16 = txt_Issuer_Bank_info_Date.Text;

        ObjUBO.A17 = ddl_Issuer_Bank_Name.Text;
        ObjUBO.A18 = txt_Issuer_Bank_Branch.Text;

        ObjUBO.A19 = txt_Narration.Text;
        ObjUBO.A20 = ddl_Bank_From.SelectedValue; //aCCNUMBER
        ObjUBO.A21 = hfBankGLCode.Value; // GLCODE FOR BANK 

        ObjUBO.A40 = flg;

        return BOR.BOR_Header_Ins_Upd(ObjUBO);
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
        txt_BR_No_F.Text = "";
        txt_BR_No_M.Text = "";
        txt_BR_No_L.Text = "";
             
        if (ddl_Bank_From.Items.Count > 0)
            ddl_Bank_From.SelectedIndex = 0;

        txt_Cur_Amt.Text = "";
        ddl_Cur.SelectedValue = "INR";
        txt_Ex_Rate.Text = "1.00";

        txt_Reference.Text = "";
        txtReference_Date.Text = "";

        txt_BR_Entry_Date.Text = "";
        txt_Posting_Date.Text = DateTime.Now.ToString("dd/MM/yyyy");

        if (ddl_Issuer_Bank_info_Type.Items.Count > 0)
            ddl_Issuer_Bank_info_Type.SelectedIndex = 0;

        txt_Issuer_Bank_info_No.Text = "";
        txt_Issuer_Bank_info_Date.Text = "";

        if (ddl_Issuer_Bank_Name.Items.Count > 0)
            ddl_Issuer_Bank_Name.SelectedIndex = 0;

        txt_Issuer_Bank_Branch.Text = "";
        txt_Narration.Text = "";

        hfBankGLCode.Value = "";
        hfBankName.Value = "";

        hdn_Sel_JL_ID.Value = "";
        hdn_Sel_JV_NO.Value = "";

        HDupdate_id.Value = "";
        HDupdate_Ch_id.Value = "";
        HDupdate_Group_id.Value = "";
        HDupdate_Imp_Exp.Value = "";
        hdn_Grid_Disable.Value = "";
        gv_details.DataSource = null;
        gv_details.DataBind();
        ViewState["GridData"] = null;
    }
}