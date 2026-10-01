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

using System.Globalization;
using System.Text.RegularExpressions;

public partial class Journal_Entry : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();

    Journal_Entry_cs JE = new Journal_Entry_cs();
    Global_variables ObjUBO = new Global_variables();

    public int i;
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
        aps.checkSession();
        if (!Page.IsPostBack)
        {
            Load_Group_Name();
            btnJob_New.Visible = false;
            btnJob_Save.Visible = false;
            btnJob_Update.Visible = false;
            btnJob_Delete.Visible = false;
            Exp_Leg();
           // Load_Payee_Name();
            if (Request.QueryString["JV_ID"] == null || Request.QueryString["JV_ID"] == "")
            {
                
                btnExpHead_Delete.Visible = false;
                btnExpHead_New.Visible = false;
                btnExpHead_Save.Visible = false;
                btnExpHead_Update.Visible = false;

                lbl_Job_Company_Lic.Text = Connection.Company_License().ToUpper();
                lbl_Job_Wrk_Period.Text = Connection.WorkingPeriod();

                Load_CP_No();
                btnsup.Text = "Save";
                //--------------------------------------------------

                gv.DataSource = dt;
                gv.DataBind();

                gv_ExpHead.DataSource = dt;
                gv_ExpHead.DataBind();

                
            }
            else
            {
                if (Request.QueryString["JV_ID"] != null && Request.QueryString["JV_ID"] != string.Empty)
                {
                    btnsup.Text = "Update";
                    btn_JV_Delete.Visible = true;
                    //--------------------------------------------------
                    Update_Item_Load();
                    Rd_Royal_Other.Enabled = false;

                    gv.DataSource = dt;
                    gv.DataBind();
                }
            }
            E_Royal_Other_Jobs();
        }
         }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
  
    private  void E_Royal_Other_Jobs()
    {
        txt_Other_Jobno.Text = string.Empty;

        if (Rd_Royal_Other.SelectedValue.ToString() == "R")
        {
            txt_Other_Jobno.Enabled = false;
        }
        else
        {
            ddl_Jobno.Enabled = true;
        }
    }

    private void Exp_Leg()
    {
        ddl_Expense_Charges.Items.Clear();
        ObjUBO.A40 = "Exp_Leg_Select";
        ds = JE.JV_Payment_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_Expense_Charges.DataSource = ds.Tables[0];
            ddl_Expense_Charges.DataTextField = "CHARGE_NAME";
            ddl_Expense_Charges.DataValueField = "CHARGE_VALUE";
            ddl_Expense_Charges.DataBind();
        }
        ddl_Expense_Charges.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
        ddl_Expense_Charges.SelectedIndex = 0;
    }
    private void Load_CP_No()
    {
        DataSet ds = new DataSet();
        try
        {
            txt_JV_No_F.Text = string.Empty;
            txt_JV_No_M.Text = string.Empty;
            txt_JV_No_L.Text = string.Empty;
            txt_JV_Entry_Date.Text = string.Empty;
            ObjUBO.A40 = "CP_No_Select";
            ds = JE.JV_Payment_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_JV_No_F.Text = ds.Tables[0].Rows[0]["JV_P"].ToString();
                txt_JV_No_M.Text = ds.Tables[0].Rows[0]["JV_NO"].ToString();
                txt_JV_No_L.Text = ds.Tables[0].Rows[0]["JV_S"].ToString();
                txt_JV_Entry_Date.Text = ds.Tables[0].Rows[0]["JV_Date"].ToString();
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
            DataSet dss = new DataSet();
            ObjUBO.A1 = Request.QueryString["JV_ID"].ToString();
            ObjUBO.A40 = "CP_Updated_Select";
            ds = JE.JV_Payment_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = ds.Tables[0].Rows[0]["JV_ID"].ToString();
                Rd_Royal_Other.SelectedValue = ds.Tables[0].Rows[0]["R_O"].ToString();
                lbl_Job_Company_Lic.Text = ds.Tables[0].Rows[0]["JOB_LICENSE"].ToString();
                lbl_Job_Wrk_Period.Text = ds.Tables[0].Rows[0]["JOB_WORKINGPERIOD"].ToString();

                txt_JV_No_F.Text = ds.Tables[0].Rows[0]["JV_P"].ToString();
                txt_JV_No_M.Text = ds.Tables[0].Rows[0]["JV_NO"].ToString();
                txt_JV_No_L.Text = ds.Tables[0].Rows[0]["JV_S"].ToString();
                txt_JV_Entry_Date.Text = ds.Tables[0].Rows[0]["JV_DATE"].ToString();
                txt_Posting_Date.Text = ds.Tables[0].Rows[0]["POSTING_DATE"].ToString();

                ddl_Party.SelectedValue = ds.Tables[0].Rows[0]["PAYEE_NAME"].ToString();

                txt_JV_Amount.Text = ds.Tables[0].Rows[0]["JV_AMT"].ToString();
                ddl_JV_Cur.SelectedValue = ds.Tables[0].Rows[0]["JV_CUR"].ToString();
                txt_JV_Cur_Val.Text = ds.Tables[0].Rows[0]["JV_CUR_VALUE"].ToString();
                txt_JV_Reference.Text = ds.Tables[0].Rows[0]["JV_REF_NO"].ToString();
                txt_JV_Ref_Date.Text = ds.Tables[0].Rows[0]["JV_REF_DATE"].ToString();
                txt_JV_Remarks.Text = ds.Tables[0].Rows[0]["JV_NARRATION"].ToString();
            }
            
            if (ds.Tables[1].Rows.Count > 0)
            {
                gv_ExpHead.DataSource = ds.Tables[1];
            }
            else
            {
                gv_ExpHead.DataSource = dt;
            }
            gv_ExpHead.DataBind();

            if (ddl_Party.SelectedValue.ToString() != string.Empty)
            {
                ddl_Party_Br.Items.Clear();
                if (ds.Tables[2].Rows.Count > 0)
                {
                    ddl_Party_Br.DataSource = ds.Tables[2];
                    ddl_Party_Br.DataTextField = "BR_SLNO";
                    ddl_Party_Br.DataValueField = "BR_SLNO";
                    ddl_Party_Br.DataBind();
                }
                ddl_Party_Br.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
                ddl_Party_Br.SelectedIndex = 0;

                ddl_Party_Br.SelectedValue = ds.Tables[0].Rows[0]["PAYEE_BR_NO"].ToString();
            }
            lbl_Leg_Bal_Amt.Text = "";
            if (ds.Tables[3].Rows.Count > 0)
            {
                lbl_Leg_Bal_Amt.Text = ds.Tables[3].Rows[0]["Bal_Amt"].ToString();
            }

            btnExpHead_New.Visible = true;
            btnExpHead_Save.Visible = true;
            btnExpHead_Update.Visible = false;
            btnExpHead_Delete.Visible = false;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    /*
    private void Load_Payee_Name()
    {
        DataSet ds = new DataSet();
        ObjUBO.A40 = "Party_Name_Select";
        ds = JE.JV_Payment_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_Party.DataSource = ds.Tables[0];
            ddl_Party.DataTextField = "Party_Name";
            ddl_Party.DataValueField = "Party_Name";
            ddl_Party.DataBind();
        }
        ddl_Party.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
        ddl_Party.SelectedIndex = 0;
        ds.Dispose();
        GC.Collect();
    }
    */
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Journal Entry', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Journal Entry', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void gv_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void btnExpHead_Save_Click(object sender, EventArgs e)
    {
            if (ddl_Expense_Charges.SelectedValue.ToString() != string.Empty)
            {
                if (txtTotSubExpAmt.Text != string.Empty)
                {
                    if (ddl_Exp_Branch.SelectedValue.ToString() != string.Empty)
                    {
                        /*
                        if (ExpHead_Validtion_Exp_Amt("S") == "0")
                        {
                        */
                            ds = Cash_Ch_Ins_Upd("S", HDupdate_id.Value.ToString(), "");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                HDupdate_Ch_id.Value = Convert.ToString(ds.Tables[0].Rows[0][0].ToString());
                                btnExpHead_Save.Visible = false;
                                btnExpHead_Update.Visible = true;
                                Alert_msg("Saved Successfully!", "btnExpHead_Save");
                            }
                            else
                            {
                                btnExpHead_Save.Visible = true;
                                btnExpHead_Update.Visible = false;
                            }
                            
                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                gv_ExpHead.DataSource = ds.Tables[1];
                            }
                            else
                            {
                                gv_ExpHead.DataSource = dt;
                            }
                            gv_ExpHead.DataBind();

                            if (ds.Tables[2].Rows.Count > 0)
                            {
                                lbl_Leg_Bal_Amt.Text = ds.Tables[2].Rows[0][0].ToString();
                            }
                        /*
                        }
                        else
                        {
                            Alert_msg("All Charge(s) Amount higher then Journal Amount . Not Saved !", "txtTotSubExpAmt");
                        }
                        */
                    }
                    else
                    {
                        Alert_msg("select Ur Branch!", "ddl_Exp_Branch");
                    }
                }
                else
                {
                    Alert_msg("Enter Ur Journal Amount!", "txtTotSubExpAmt");
                }
            }
            else
            {
                Alert_msg("Select Ur Expsenses!", "ddl_Expense_Charges");
            }
           
    }
    protected void btnExpHead_Update_Click(object sender, EventArgs e)
    {
            if (ddl_Expense_Charges.SelectedValue.ToString() != string.Empty)
            {
                if (txtTotSubExpAmt.Text != string.Empty)
                {
                    if (ddl_Exp_Branch.SelectedValue.ToString() != string.Empty)
                    {
                        /*
                        if (ExpHead_Validtion_Exp_Amt("U") == "0")
                        {
                         */
                            ds = Cash_Ch_Ins_Upd("U", HDupdate_id.Value.ToString(), HDupdate_Ch_id.Value.ToString());
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                HDupdate_Ch_id.Value = Convert.ToString(HDupdate_Ch_id.Value.ToString());
                                btnExpHead_Save.Visible = false;
                                btnExpHead_Update.Visible = true;
                                Alert_msg("Updated Successfully!", "btnExpHead_Update");
                            }
                            else
                            {
                                btnExpHead_Save.Visible = false;
                                btnExpHead_Update.Visible = true;
                            }
                            
                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                gv_ExpHead.DataSource = ds.Tables[1];
                            }
                            else
                            {
                                gv_ExpHead.DataSource = dt;
                            }
                            gv_ExpHead.DataBind();

                            if (ds.Tables[2].Rows.Count > 0)
                            {
                                lbl_Leg_Bal_Amt.Text = ds.Tables[2].Rows[0][0].ToString();
                            }
                           /*  
                        }
                        else
                        {
                            Alert_msg("All Charge(s) Amount higher then Journal Amount . Not Saved !", "txtTotSubExpAmt");
                        }
                        */
                    }
                    else
                    {
                        Alert_msg("select Ur Branch!", "ddl_Exp_Branch");
                    }
                }
                else
                {
                    Alert_msg("Enter Ur Expsenses Amount!", "txtTotSubExpAmt");
                }
            }
            else
            {
                Alert_msg("Select Ur Expsenses!", "ddl_Expense_Charges");
            }
        
    }

    private string ExpHead_Validtion_Exp_Amt(string flg)
    {
        string val = "";

        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A2 = HDupdate_Ch_id.Value.ToString();

        ObjUBO.A3 = txt_JV_No_F.Text;
        ObjUBO.A4 = txt_JV_No_M.Text;
        ObjUBO.A5 = txt_JV_No_L.Text;
        //ObjUBO.A6 = HDupdate_Job_Id.Value.ToString();
        ObjUBO.A7 = txtTotSubExpAmt.Text;
        ObjUBO.A8 = flg;

        ObjUBO.A40 = "JV_Head_Amt_Validation";
        ds = JE.JV_Payment_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            val = ds.Tables[0].Rows[0]["val"].ToString();
        }
        return val;
    }
    public DataSet Cash_Ch_Ins_Upd(string flg, string Exp_id, string Ch_id)
    {
        //ACC_GST_CASH_PAYMENT_CH_ENTRY
        ObjUBO.A51 = HDupdate_Ch_id.Value.ToString();
        ObjUBO.A52 = Rd_Royal_Other.SelectedValue.ToString();
        ObjUBO.A53 = HDupdate_id.Value.ToString();
        ObjUBO.A54 = txt_JV_No_F.Text;
        ObjUBO.A55 = txt_JV_No_M.Text;
        ObjUBO.A56 = txt_JV_No_L.Text;
        ObjUBO.A57 = ddlslno.SelectedValue.ToString();
        ObjUBO.A58 = ddl_Imp_Exp.SelectedValue.ToString();
        ObjUBO.A59 = ddl_Expense_Charges.SelectedValue.ToString();
        ObjUBO.A60 = ddl_Exp_Tax_Type.SelectedValue.ToString();
        ObjUBO.A61 = txtTotSubExpAmt.Text;
        ObjUBO.A62 = ddl_Exp_Dr_Cr.SelectedValue.ToString();
        ObjUBO.A63 = ddl_Exp_Branch.SelectedItem.ToString();
        ObjUBO.A64 = ddl_Exp_Branch.SelectedValue.ToString();
        //ObjUBO.A65 = Ch_A_Tax_Credit.Checked.ToString();
        
        ObjUBO.A74 = txt_Exp_Remarks.Text;

        ObjUBO.A98 = lbl_Job_Company_Lic.Text;
        ObjUBO.A99 = lbl_Job_Wrk_Period.Text;
        ObjUBO.A100 = flg;
        return JE.JV_Payment_Head_Ins_Upd(ObjUBO);
    }
    protected void btnExpHead_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            ObjUBO.A1 = HDupdate_id.Value.ToString();
            ObjUBO.A2 = HDupdate_Ch_id.Value.ToString();
            ObjUBO.A3 = txt_JV_No_F.Text;
            ObjUBO.A4 = txt_JV_No_M.Text;
            ObjUBO.A5 = txt_JV_No_L.Text;
            ObjUBO.A40 = "CP_Charge_Name_Delete";
            ds = JE.JV_Payment_Select(ObjUBO);

            if (ds.Tables[0].Rows.Count == 0)
            {
                btnJob_New_Click(sender, e);
                Alert_msg("Expenses Deleted");
            }
            else
            {
                Alert_msg("Expenses Not Deleted");
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                gv_ExpHead.DataSource = ds.Tables[1];
                gv_ExpHead.DataBind();
            }
            else
            {
                gv_ExpHead.DataSource = dt;
                gv_ExpHead.DataBind();
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                lbl_Leg_Bal_Amt.Text = ds.Tables[2].Rows[0][0].ToString();
            }
            btnExpHead_Delete.Visible = false;
            btnExpHead_Update.Visible = false;
            btnExpHead_Save.Visible = true;

            ddl_Expense_Charges.SelectedIndex = -1;
            txtTotSubExpAmt.Text = "";

            //lbl_Charge_Name.Text = "";
            //lbl_Exp_Amt.Text = "";

            lbljob_total_amt.Text = "";

            btnJob_Delete_All.Visible = false;
            ddl_Jobno.Items.Clear();
            gv.DataSource = dt;
            gv.DataBind();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnExpHead_New_Click(object sender, EventArgs e)
    {
        btnExpHead_Delete.Visible = false;
        btnExpHead_Update.Visible = false;
        btnExpHead_Save.Visible = true;
        btnExpHead_Update.CssClass = "updates";

        ddl_Expense_Charges.SelectedIndex = -1;
        txtTotSubExpAmt.Text = "";
        //lbl_Charge_Name.Text = "";
        //lbl_Exp_Amt.Text = "";
        lbljob_total_amt.Text = "";
        txt_Other_Jobno.Text = "";
        HDupdate_Group_id.Value = "";
        HDupdate_Imp_Exp.Value = "";
        lblcharge.Text = string.Empty;

        btnJob_Delete_All.Visible = false;
        ddl_Jobno.Items.Clear();
        gv.DataSource = dt;
        gv.DataBind();
    }
  
    protected void gv_ExpHead_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_ExpHead.PageIndex = e.NewPageIndex;
       // Grid_LoadLineDetails();
    }    
    protected void gv_ExpHead_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void gv_ExpHead_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
                e.Row.Enabled = true;
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_ExpHead, "Select$" + e.Row.RowIndex.ToString()));
                e.Row.Font.Bold = true;

                if (DataBinder.Eval(e.Row.DataItem, "CR_DR").ToString() == "CR")
                {
                    e.Row.ForeColor = System.Drawing.Color.Green;

                }
                else if (DataBinder.Eval(e.Row.DataItem, "CR_DR").ToString() == "DR")
                {
                    e.Row.ForeColor = System.Drawing.Color.Red;
                }
        }
    }
    protected void gv_ExpHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnJob_Delete.Visible = false;
        btnJob_Save.Visible = true;
        btnJob_New.Visible = true;
        btnJob_Update.Visible = false;
        lbl_Error_Msg.Text = string.Empty;
        HDupdate_Group_id.Value = "";
        HDupdate_Imp_Exp.Value = "";
        lblcharge.Text = string.Empty;

        ViewState["CH_ID"] = Convert.ToString(this.gv_ExpHead.SelectedDataKey.Value);
       
        if (ViewState["CH_ID"] != "" && ViewState["CH_ID"] != null)
        {
            DataSet ds = new DataSet();
            ObjUBO.A1 = HDupdate_id.Value.ToString();
            ObjUBO.A2 = ViewState["CH_ID"].ToString();

            ObjUBO.A3 = txt_JV_No_F.Text;
            ObjUBO.A4 = txt_JV_No_M.Text;
            ObjUBO.A5 = txt_JV_No_L.Text;
            ObjUBO.A40 = "CP_Charge_Name_Select";
            ds = JE.JV_Payment_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                HDupdate_Ch_id.Value =ds.Tables[0].Rows[0]["CH_ID"].ToString();

                ddlslno.SelectedValue = ds.Tables[0].Rows[0]["SLNO"].ToString();
                ddl_Imp_Exp.SelectedValue = ds.Tables[0].Rows[0]["IMP_EXP"].ToString();
                ddl_Expense_Charges.SelectedValue = ds.Tables[0].Rows[0]["CHARGE_NAME"].ToString();
                ddl_Exp_Tax_Type.SelectedValue = ds.Tables[0].Rows[0]["TAX_NONTAX"].ToString();
                txtTotSubExpAmt.Text = ds.Tables[0].Rows[0]["AMOUNT"].ToString();
                ddl_Exp_Dr_Cr.SelectedValue= ds.Tables[0].Rows[0]["CR_DR"].ToString();
                ddl_Exp_Branch.SelectedValue = ds.Tables[0].Rows[0]["GROUP_ID"].ToString();
                ddl_Job_Imp_Exp.SelectedValue = ds.Tables[0].Rows[0]["IMP_EXP"].ToString();
                

                HDupdate_Group_id.Value = ddl_Exp_Branch.SelectedValue.ToString();
                HDupdate_Imp_Exp.Value = ddl_Imp_Exp.SelectedValue.ToString();
                lblcharge.Text = ds.Tables[0].Rows[0]["CHARGE_NAME"].ToString();
            }

            btnExpHead_Update.CssClass = "updates";
            btnExpHead_Delete.Visible = true;
            btnExpHead_Update.Visible = true;
            btnExpHead_Save.Visible = false;

            //lbl_Charge_Name.Text = ddl_Expense_Charges.SelectedValue.ToString();
            //lbl_Exp_Amt.Text = txtTotSubExpAmt.Text;
            load_Jobs();
            
        }
        else
        {
            btnExpHead_Delete.Visible = false;
            btnExpHead_Update.Visible = false;
            btnExpHead_Save.Visible = true;
        }
    }
    protected void btnsup_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_JV_No_M.Text != string.Empty)
                {
                    if (txt_JV_Entry_Date.Text != string.Empty)
                    {
                        if (txt_Posting_Date.Text != string.Empty) 
                        {
                            ds = JV_Ins_Upd(btnsup.Text);
                            if (btnsup.Text == "Save")
                            {
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    HDupdate_id.Value = ds.Tables[0].Rows[0][0].ToString();
                                    btnsup.Text = "Update";
                                    Alert_msg("Saved Successfully!", "btnsup");

                                    btnExpHead_Delete.Visible = false;
                                    btnExpHead_New.Visible = true;
                                    btnExpHead_Save.Visible = true;
                                    btnExpHead_Update.Visible = false;
                                    Rd_Royal_Other.Enabled = false;

                                    btn_JV_Delete.Visible = true;
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
                                    Alert_msg("Updated Successfully!", "btnsup");
                                    btn_JV_Delete.Visible = true;
                                }
                                else
                                {
                                    Alert_msg("Not Updated", "btnsup");
                                }
                            }
                        }
                        else
                        {
                            Alert_msg("Enter Ur Journal Posting Date!", "txt_Posting_Date");
                        }
                    }
                    else
                    {
                        Alert_msg("Enter Ur Journal Payment Date!", "txt_JV_Entry_Date");
                    }
                }
                else
                {
                    Alert_msg("Check Ur Journal Trans. No!", "txt_Cp_No_M");
                }
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public DataSet JV_Ins_Upd(string flg)
    {
        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A2 = Rd_Royal_Other.SelectedValue.ToString();

        ObjUBO.A3 = txt_JV_No_F.Text;
        ObjUBO.A4 = txt_JV_No_M.Text;
        ObjUBO.A5 = txt_JV_No_L.Text;
        ObjUBO.A6 = txt_JV_Entry_Date.Text;
        ObjUBO.A7 = txt_Posting_Date.Text;
        ObjUBO.A9 = ddl_Party.SelectedValue.ToString();
        ObjUBO.A9 = ddl_Party.SelectedValue.ToString();
        ObjUBO.A10 = ddl_Party_Br.SelectedValue.ToString();

        ObjUBO.A11 = txt_JV_Amount.Text;
        ObjUBO.A12 = ddl_JV_Cur.SelectedValue.ToString();
        ObjUBO.A13 = txt_JV_Cur_Val.Text;
        ObjUBO.A14 = txt_JV_Reference.Text;
        ObjUBO.A15 = txt_JV_Ref_Date.Text;
        ObjUBO.A16 = txt_JV_Remarks.Text;

        ObjUBO.A17 = lbl_Job_Company_Lic.Text;
        ObjUBO.A18 = lbl_Job_Wrk_Period.Text;
        ObjUBO.A40 = flg;
        return JE.JV_Payment_Ins_Upd(ObjUBO);
    }

    [System.Web.Services.WebMethod]
    public static string Getload_Job_Data(string custid, string Imp_Exp, string ddl_job)
    {
        Global_variables ObjUBO = new Global_variables();
        DataSet ds = new DataSet();
        Journal_Entry_cs JE = new Journal_Entry_cs();
        if (custid != string.Empty)
        {
           
            ObjUBO.A8 = Imp_Exp;
            ObjUBO.A6 = ddl_job;
            ObjUBO.A40 = "Client_Name_Select";
            ds = JE.JV_Payment_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                custid = ds.Tables[0].Rows[0][0].ToString();
            }
        }
        return custid;
    }
    protected void btnJob_New_Click(object sender, EventArgs e)
    {
        ddl_Jobno.Enabled = true;
        HDupdate_Job_Id.Value = "";
        load_Jobs();
        btnJob_Save.Visible = true;
        btnJob_Update.Visible = false;
        btnJob_Delete.Visible = false;
        lbl_Error_Msg.Text = string.Empty;
        txt_Other_Jobno.Text = string.Empty;
        txt_Exp_Job_Amt.Text = string.Empty;
    }
    protected void btnJob_Save_Click(object sender, EventArgs e)
    {
        lbl_Error_Msg.Text = string.Empty;
        if (ddl_Jobno.SelectedValue != string.Empty)
        {
            if (txt_Exp_Job_Amt.Text != string.Empty)
            {
                if (Validtion_Exp_Amt() == "0")
                {
                    ds = JV_Payment_Job_Ins_Upd("S", HDupdate_id.Value.ToString());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        HDupdate_Job_Id.Value = Convert.ToString(ds.Tables[0].Rows[0]["J_Id"].ToString());
                        lbljob_total_amt.Text = ds.Tables[0].Rows[0]["Job_Total"].ToString();
                        btnJob_Save.Visible = false;
                        btnJob_Update.Visible = true;
                        btnJob_New.Visible = true;
                        Alert_msg("Saved Successfully!", "btnExpHead_Save");
                    }
                    else
                    {
                        btnJob_Save.Visible = true;
                        btnJob_Update.Visible = false;
                        Alert_msg("Not Saved!", "btnJob_Save");
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        gv.DataSource = ds.Tables[1];
                    }
                    else
                    {
                        gv.DataSource = dt;
                    }
                    gv.DataBind();
                }
                else
                {
                    Alert_msg("All Job(s) Amount higher then Job Amount !", "txt_Exp_Job_Amt");
                }
            }
            else
            {
                Alert_msg("Enter the Job Amount !", "txt_Exp_Job_Amt");
            }
        }
        else
        {
            Alert_msg("select Ur Job !", "ddl_Jobno");
        }
    }
    public DataSet JV_Payment_Job_Ins_Upd(string flg, string Exp_id)
    {
        //ACC_GST_CASH_PAYMENT_CH_JOB_ENTRY

        ObjUBO.A101 = HDupdate_Job_Id.Value.ToString();
        ObjUBO.A102 = HDupdate_id.Value.ToString();
        ObjUBO.A103 = HDupdate_Ch_id.Value.ToString();
        ObjUBO.A104 = Rd_Royal_Other.SelectedValue.ToString();
        ObjUBO.A105 = txt_JV_No_F.Text;
        ObjUBO.A106 = txt_JV_No_M.Text;
        ObjUBO.A107 = txt_JV_No_L.Text;
        ObjUBO.A108 = ddl_Job_Imp_Exp.SelectedValue.ToString();
        ObjUBO.A109 = ddl_Expense_Charges.SelectedValue.ToString();
        
        ObjUBO.A110 = ddl_Jobno.SelectedItem.ToString();
        ObjUBO.A111 = ddl_Jobno.SelectedValue.ToString();
        ObjUBO.A112 = txt_Exp_Job_Amt.Text;
        ObjUBO.A113 = ddl_Exp_Branch.SelectedValue.ToString();

        ObjUBO.A138 = lbl_Job_Company_Lic.Text;
        ObjUBO.A139 = lbl_Job_Wrk_Period.Text;
        ObjUBO.A140 = flg;
        return JE.JV_Payment_Job_Ins_Upd(ObjUBO);
    }
    protected void btnJob_Update_Click(object sender, EventArgs e)
    {
        lbl_Error_Msg.Text = string.Empty;
        if (txt_Exp_Job_Amt.Text != string.Empty)
        {
            if (Validtion_Exp_Amt() == "0")
            {
                ds = JV_Payment_Job_Ins_Upd("U", HDupdate_id.Value.ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    HDupdate_Job_Id.Value = Convert.ToString(ds.Tables[0].Rows[0]["J_ID"].ToString());
                    lbljob_total_amt.Text = ds.Tables[0].Rows[0]["Job_Total"].ToString();
                    btnJob_Save.Visible = false;
                    btnJob_Update.Visible = true;
                    Alert_msg("Updated Successfully!", "btnJob_Update");
                }
                else
                {
                    btnJob_Save.Visible = false;
                    btnJob_Update.Visible = true;
                    Alert_msg("Not Updated!", "btnJob_Update");
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    gv.DataSource = ds.Tables[1];
                    gv.DataBind();
                }
                else
                {
                    gv.DataSource = dt;
                    gv.DataBind();
                }
                
            }
            else
            {
                lbl_Error_Msg.Text = "Not Updated all Job(s) Amount higher then Job Amount";
                Alert_msg("All Job(s) Amount higher then Job Amount !", "txt_Exp_Job_Amt");
            }
        }
        else
        {
            Alert_msg("Enter Ur Job Amount !", "txt_Exp_Job_Amt");
        }
    }
    protected void btnJob_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            ObjUBO.A1 = HDupdate_id.Value.ToString();
            ObjUBO.A2 = HDupdate_Ch_id.Value.ToString();

            ObjUBO.A3 = txt_JV_No_F.Text;
            ObjUBO.A4 = txt_JV_No_M.Text;
            ObjUBO.A5 = txt_JV_No_L.Text;
            ObjUBO.A6 = HDupdate_Job_Id.Value.ToString();
            ObjUBO.A40 = "CP_Job_delete";
            ds = JE.JV_Payment_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count == 0)
            {
                HDupdate_Job_Id.Value = "";
                btnJob_New_Click(sender, e);
                Alert_msg("Job Deleted");
            }
            else
            {
                Alert_msg("Job Not Deleted");
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                lbljob_total_amt.Text = ds.Tables[1].Rows[0]["Job_Total"].ToString();
            }
            else
            {
                lbljob_total_amt.Text = "0";
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                gv.DataSource = ds.Tables[2];
                gv.DataBind();
            }
            else
            {
                gv.DataSource = dt;
                gv.DataBind();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnJob_Delete_All_Click(object sender, EventArgs e)
    {
        try
        {
            ObjUBO.A1 = HDupdate_id.Value.ToString();
            ObjUBO.A2 = HDupdate_Ch_id.Value.ToString();

            ObjUBO.A3 = txt_JV_No_F.Text;
            ObjUBO.A4 = txt_JV_No_M.Text;
            ObjUBO.A5 = txt_JV_No_L.Text;
            ObjUBO.A40 = "CP_Job_delete_All";
            ds = JE.JV_Payment_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count == 0)
            {
                HDupdate_Job_Id.Value = "";
                btnJob_New_Click(sender, e);
                lbljob_total_amt.Text = "0";
                gv.DataSource = dt;
                gv.DataBind();
                Alert_msg("Job Deleted");
            }
            else
            {
                Alert_msg("Job Not Deleted");
            }
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Enabled = true;
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv, "Select$" + e.Row.RowIndex.ToString()));
        }
    }
    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbl_Cus_Name.Text = string.Empty;
        string J_ID = gv.DataKeys[gv.SelectedRow.RowIndex].Values["J_ID"].ToString();
        string JOBNO_PS = gv.DataKeys[gv.SelectedRow.RowIndex].Values["JOBNO_PS"].ToString();
        string JOBNO = gv.DataKeys[gv.SelectedRow.RowIndex].Values["JOBNO"].ToString();
        if (J_ID != "" && J_ID != null)
        {
            ddl_Jobno.Items.Clear();
            HDupdate_Job_Id.Value = J_ID;
            /*
            ddl_Jobno.Items.Insert(0, new System.Web.UI.WebControls.ListItem(JOBNO_PS, JOBNO));
            ddl_Jobno.SelectedIndex = 0;
            txt_Other_Jobno.Text = JOBNO_PS;
            */
            ddl_Jobno.Items.Insert(0, new System.Web.UI.WebControls.ListItem(JOBNO, JOBNO_PS));
            ddl_Jobno.SelectedIndex = 0;
            txt_Other_Jobno.Text = JOBNO_PS;
            ddl_Job_Imp_Exp.SelectedValue = gv.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            txt_Exp_Job_Amt.Text = gv.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");

            btnJob_New.Visible = true;
            btnJob_Save.Visible=false;
            btnJob_Update.Visible=true;
            btnJob_Delete.Visible = true;
            ddl_Jobno.Enabled = false;
        }
    }
    private string Validtion_Exp_Amt()
    {
        string val = "";

        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A2 = HDupdate_Ch_id.Value.ToString();

        ObjUBO.A3 = txt_JV_No_F.Text;
        ObjUBO.A4 = txt_JV_No_M.Text;
        ObjUBO.A5 = txt_JV_No_L.Text;
        ObjUBO.A6 = HDupdate_Job_Id.Value.ToString();
        ObjUBO.A7 = txt_Exp_Job_Amt.Text;
           
        ObjUBO.A40 = "CP_Job_Amt_Validation";
        ds = JE.JV_Payment_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            val = ds.Tables[0].Rows[0]["val"].ToString();
        }
        return val;
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
    protected void btn_JV_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_JV_No_M.Text != string.Empty)
            {
                if (txt_JV_Entry_Date.Text != string.Empty)
                {
                    ds = JV_Ins_Upd("Delete");
                    if (ds.Tables[0].Rows.Count == 0)
                     {
                         btnsup.Text = "Save";
                         Alert_msg("Deleted Successfully!", "btn_Cp_Delete");

                         btnExpHead_Delete.Visible = false;
                         btnExpHead_New.Visible = false;
                         btnExpHead_Save.Visible = false;
                         btnExpHead_Update.Visible = false;
                         btn_JV_Delete.Visible = false;
                        //---------------------------------------------------------
                         Load_CP_No();
                         btnsup.Text = "Save";
                         //--------------------------------------------------

                         gv.DataSource = dt;
                         gv.DataBind();

                         gv_ExpHead.DataSource = dt;
                         gv_ExpHead.DataBind();

                        }
                        else
                        {
                            Alert_msg("Not Deleted", "btn_Cp_Delete");
                        }
                }
                else
                {
                    Alert_msg("Enter Ur Invalid Journal Date!", "txt_JV_Entry_Date");
                }
            }
            else
            {
                Alert_msg("Invalid Trans. No!", "txt_JV_No_M");
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void ddl_Expense_Charges_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Expense_Charges.SelectedValue.ToString() != string.Empty)
        {
            string[] arr = new string[] { };
            arr = ddl_Expense_Charges.SelectedValue.ToString().Split('~');
            ddl_Exp_Tax_Type.SelectedValue = arr[0].ToString();
        }
        else
        {
            ddl_Exp_Tax_Type.SelectedIndex = -1;
        }
    }
    private void load_Jobs()
    {
        try
        {
            ddl_Jobno.Items.Clear();
            ddl_Jobno.Enabled = true;

            DataSet ds = new DataSet();
            ObjUBO.A1 = HDupdate_id.Value.ToString();
            ObjUBO.A2 = HDupdate_Ch_id.Value.ToString();

            ObjUBO.A3 = txt_JV_No_F.Text;
            ObjUBO.A4 = txt_JV_No_M.Text;
            ObjUBO.A5 = txt_JV_No_L.Text;
           
            ObjUBO.A40 = "CP_Charge_Jobno_Select";
            ds = JE.JV_Payment_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_Jobno.DataSource = ds.Tables[0];
                ddl_Jobno.DataTextField = "JOBNO";
                ddl_Jobno.DataValueField = "JOBNO_PS";
                ddl_Jobno.DataBind();
            }
            ddl_Jobno.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
            ddl_Jobno.SelectedIndex = 0;

            
            if (ds.Tables[1].Rows.Count > 0)
            {
                btnJob_Delete_All.Visible = true;
                gv.DataSource = ds.Tables[1];
                gv.DataBind();

                btnExpHead_Delete.Visible = false;
            }
            else
            {
                btnJob_Delete_All.Visible = false;
                gv.DataSource = dt;
                gv.DataBind();
                btnExpHead_Delete.Visible = true;
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                lbljob_total_amt.Text = ds.Tables[2].Rows[0]["Job_Total"].ToString();
            }
            else
            {
                lbljob_total_amt.Text = "0";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void ddl_Party_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_Party_Br.Items.Clear();
        if (ddl_Party.SelectedValue.ToString() != string.Empty)
        {
            DataSet ds = new DataSet();
            ObjUBO.A8 = ddl_Party.SelectedValue.ToString();
            ObjUBO.A40 = "Party_Br_Select";
            ds = JE.JV_Payment_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_Party_Br.DataSource = ds.Tables[0];
                ddl_Party_Br.DataTextField = "BR_SLNO";
                ddl_Party_Br.DataValueField = "BR_SLNO";
                ddl_Party_Br.DataBind();
            }
        }
        ddl_Party_Br.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
        ddl_Party_Br.SelectedIndex = 0;
    }

    protected void ddl_Job_Imp_Exp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Job_Imp_Exp.SelectedValue.ToString() != string.Empty)
        {
           Load_Refno();
        }
    }
    private void Load_Refno()
    {
        DataSet ds = new DataSet();
        ddl_Jobno.Items.Clear();
        txt_Exp_Job_Amt.Text = string.Empty;
        ddl_Jobno.Enabled = true;
        ObjUBO.A4 = ddl_Job_Imp_Exp.SelectedValue.ToString();
        ObjUBO.A8 = ddl_Expense_Charges.SelectedItem.ToString();
        ObjUBO.A9 = ddl_Expense_Charges.SelectedValue;
        ObjUBO.A40 = "JV_Refno_Select";
        ds = JE.JV_Payment_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_Jobno.DataSource = ds.Tables[0];
            ddl_Jobno.DataTextField = "JOBNO";
            ddl_Jobno.DataValueField = "JOBNO_PS";
            ddl_Jobno.DataBind();
        }
        ddl_Jobno.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
        ddl_Jobno.SelectedIndex = 0;
    }
    protected void ddl_Jobno_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txt_Exp_Job_Amt.Text = string.Empty;
            if (ddl_Jobno.SelectedValue.ToString() != string.Empty)
            {
                DataSet ds = new DataSet();
                ObjUBO.A8 = ddl_Expense_Charges.SelectedItem.ToString();
                ObjUBO.A9 = ddl_Expense_Charges.SelectedValue;
                ObjUBO.A4 = ddl_Job_Imp_Exp.SelectedValue.ToString();
                ObjUBO.A10 = ddl_Jobno.SelectedValue.ToString();
                ObjUBO.A40 = "JV_Refno_Amt_Select";
                ds = JE.JV_Payment_Select(ObjUBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txt_Exp_Job_Amt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
}