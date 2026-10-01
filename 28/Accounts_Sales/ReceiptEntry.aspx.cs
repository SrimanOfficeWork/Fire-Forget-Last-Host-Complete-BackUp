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

public partial class ReceiptEntry : ThemeClass
{
    AppSession aps = new AppSession();
    ReceiptEntry_cs RE = new ReceiptEntry_cs();
    Global_variables ObjUBO = new Global_variables();

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
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;

                if (Request.QueryString["R_ID"] == null)
                {
                    lbl_Job_Company_Lic.Text = Connection.Company_License().ToUpper();
                    lbl_Job_Wrk_Period.Text = Connection.WorkingPeriod();
                    Rd_Royal_Other.Enabled = true;

                    load_Party_Name();
                    txtReceipt_Date.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    btn_Save_Update.Text = "Save";
                }
                else
                {
                    if (Request.QueryString["R_ID"] != null && Request.QueryString["R_ID"] != string.Empty)
                    {
                        
                        Update_Item_Load();
                        Rd_Bill_Type.Enabled = false;
                        //load_Jobno();
                        Rd_IMP_EXP_SelectedIndexChanged(sender, e);
                        Job_Invno_ED();

                        btn_Save_Update.Text = "Update";
                        Rd_Royal_Other.Enabled = false;
                    }
                }
                Payment_Mode();
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                E_Royal_Other_Jobs();
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
            ObjUBO.A1 = Request.QueryString["R_ID"].ToString();
            ObjUBO.A15 = "Updated_Receipt_Select";
            ds = RE.Receipt_Entry_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = ds.Tables[0].Rows[0]["R_ID"].ToString();
                txtReceiptNo.Text = ds.Tables[0].Rows[0]["RECEIPT_NO"].ToString();
                txtReceipt_Date.Text = ds.Tables[0].Rows[0]["RECEIPT_DATE"].ToString();
                RdPayFor.SelectedValue = ds.Tables[0].Rows[0]["PAYMENT_TYPE"].ToString();

                ddlPartyname.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["PARTY_NAME"].ToString(), ds.Tables[0].Rows[0]["PARTY_NAME"].ToString()));
                ddlPartyname.SelectedIndex = 0;
                ddlPartyBranch.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["PARTY_BRANCH"].ToString(), ds.Tables[0].Rows[0]["PARTY_BRANCH"].ToString()));
                ddlPartyBranch.SelectedIndex = 0;
                ddl_Bank_From.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["BANK_FROM"].ToString(), ds.Tables[0].Rows[0]["BANK_FROM"].ToString()));
                ddl_Bank_From.SelectedIndex = 0;
                ddl_Acc_No.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["BANK_FROM_ACC_NO"].ToString(), ds.Tables[0].Rows[0]["BANK_FROM_ACC_NO"].ToString()));
                ddl_Acc_No.SelectedIndex = 0;
                ddl_ifsc_Code.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["BANK_FROM_ACC_IFSC_CODE"].ToString(), ds.Tables[0].Rows[0]["BANK_FROM_ACC_IFSC_CODE"].ToString()));
                ddl_ifsc_Code.SelectedIndex = 0;
                Rd_Bill_Type.SelectedValue = ds.Tables[0].Rows[0]["BILL_TYPE"].ToString();
                
                Rd_Mode_Of_Payment.SelectedValue = ds.Tables[0].Rows[0]["PAYMENT_MODE"].ToString();
                txt_Cash_Amount.Text = ds.Tables[0].Rows[0]["PAYMENT_AMOUNT"].ToString();
                txt_Chk_NB_Refno.Text = ds.Tables[0].Rows[0]["CHEQUE_REF_NO"].ToString();
                ddl_To_BankName.SelectedValue = ds.Tables[0].Rows[0]["BANK_TO"].ToString();
                txt_to_Acc_No.Text = ds.Tables[0].Rows[0]["BANK_TO_ACC_NO"].ToString();
                txt_to_Bank_ifsc_Code.Text = ds.Tables[0].Rows[0]["BANK_TO_ACC_IFSC_CODE"].ToString();
                txt_Remarks.Text = ds.Tables[0].Rows[0]["REMARKS"].ToString();

                Rd_Royal_Other.SelectedValue = ds.Tables[0].Rows[0]["JOB_TYPE"].ToString();
                lbl_Job_Company_Lic.Text = ds.Tables[0].Rows[0]["JOB_LICENSE"].ToString();
                lbl_Job_Wrk_Period.Text = ds.Tables[0].Rows[0]["JOB_WORKINGPERIOD"].ToString();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                gv_Ch.DataSource = ds.Tables[1];
                gv_Ch.DataBind();
            }
            else
            {
                gv_Ch.DataSource = dt;
                gv_Ch.DataBind();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void ddljobno_SelectedIndexChanged(object sender, EventArgs e)
    {
       Load_Charge_Head();
    }
    private void Load_Charge_Head()
    {
        try
        {
            txt_Other_Jobno.Text="";
            ddl_Charge_head.Items.Clear();
            if (ddljobno.SelectedValue.ToString() != string.Empty)
            {
                ObjUBO.A3 = ddlPartyname.SelectedValue.ToString();
                ObjUBO.A4 = ddlPartyBranch.SelectedValue.ToString();
                ObjUBO.A7 = Rd_IMP_EXP.SelectedValue.ToString();
                ObjUBO.A8 = ddljobno.SelectedValue.ToString();
                ObjUBO.A15 = "Receipt_Charge_Value_Select";
                ds = RE.Receipt_Entry_Select(ObjUBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddl_Charge_head.DataSource = ds.Tables[0];
                    ddl_Charge_head.DataTextField = "CHARGE_NAME";
                    ddl_Charge_head.DataValueField = "CHARGE_VALUE";
                    ddl_Charge_head.DataBind();
                }
                ddl_Charge_head.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddl_Charge_head.SelectedIndex = 0;

                txt_Other_Jobno.Text = ddljobno.SelectedItem.ToString();
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
            txtReceiptNo.Text = string.Empty;
            ddlPartyname.Items.Clear();
            ddlPartyBranch.Items.Clear();

            DataSet ds = new DataSet();
            ObjUBO.A15 = "Party_Name_PNO_Select";
            ds = RE.Receipt_Entry_Select(ObjUBO);
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
                ddl_Bank_From.DataSource = ds.Tables[1];
                ddl_Bank_From.DataTextField = "Bank_Name";
                ddl_Bank_From.DataValueField = "Bank_Name";
                ddl_Bank_From.DataBind();
            }
            ddl_Bank_From.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Bank_From.SelectedIndex = 0;

            if (ds.Tables[2].Rows.Count > 0)
            {
                txtReceiptNo.Text = ds.Tables[2].Rows[0]["RECEIPT_NO"].ToString();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
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
            ObjUBO.A3 = ddlPartyname.SelectedValue.ToString();
            ObjUBO.A15 = "Party_Branch_Select";
            ds = RE.Receipt_Entry_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlPartyBranch.DataSource = ds.Tables[0];
                ddlPartyBranch.DataTextField = "Br_Name";
                ddlPartyBranch.DataValueField = "CUS_BRANCH_NO";
                ddlPartyBranch.DataBind();
            }
        }
        ddlPartyBranch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlPartyBranch.SelectedIndex = 0;
    }
    protected void gvPaymentdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

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
            if (ddljobno.SelectedValue.ToString() != string.Empty || ddl_SalesBillno.SelectedValue.ToString() != string.Empty)
            {
                    if (txt_Payable_Amt.Text != string.Empty)
                        {
                            ds = Receipt_Insert_Update("RCS");
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    HD_Ch_update_id.Value = ds.Tables[0].Rows[0]["RC_ID"].ToString();
                                    btnUpdate.CssClass = "save";
                                    btnUpdate.Visible = true;
                                    btnSave.Visible = false;
                                    btnSave.Focus();
                                    ViewState["UPDATED_ID"] = null;
                                    Alert_msg("Payment Entry Saved Successfully", "btnSave");
                                }
                                else
                                {
                                    Alert_msg("Payment Not Saved", "btnSave");
                                }
                                  

                                if (ds.Tables[1].Rows.Count > 0)
                                {
                                    gv_Ch.DataSource = ds.Tables[1];
                                    gv_Ch.DataBind();
                                }
                                else
                                {
                                    gv_Ch.DataSource = dt;
                                    gv_Ch.DataBind();
                                }
                        }
                        else
                        {
                            Alert_msg("Enter Ur Payable Amt !", "txt_Payable_Amt");
                        }
            }
            else
            {
                Alert_msg("select Ur Jobno or Sales Invoice No!");
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
            if (ddljobno.SelectedValue.ToString() != string.Empty)
            {
                if (txt_Payable_Amt.Text != string.Empty)
                {
                    ds = Receipt_Insert_Update("RCU");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        HD_Ch_update_id.Value = ds.Tables[0].Rows[0]["PC_ID"].ToString();

                        ViewState["UPDATED_ID"] = null;
                        Alert_msg("Receipt Entry Updated Successfully", "btnUpdate");
                    }
                    else
                    {
                        Alert_msg("Receipt Not Updated", "btnUpdate");
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        gv_Ch.DataSource = ds.Tables[1];
                        gv_Ch.DataBind();
                    }
                    else
                    {
                        gv_Ch.DataSource = dt;
                        gv_Ch.DataBind();
                    }
                }
                else
                {
                    Alert_msg("Enter Ur Payable Amt !", "txt_Payable_Amt");
                }
            }
            else
            {
                Alert_msg("select Ur Jobno !", "ddljobno");
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
            ds = Receipt_Insert_Update("RCD");
            if (ds.Tables[0].Rows.Count == 0)
            {
                ViewState["UPDATED_ID"] = null;
                btnNew_Click(sender, e);
                Alert_msg("Receipt Entry Deleted");
            }
            else
            {
                Alert_msg("Receipt Not Deleted", "btnDelete");
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                gv_Ch.DataSource = ds.Tables[1];
                gv_Ch.DataBind();
            }
            else
            {
                gv_Ch.DataSource = dt;
                gv_Ch.DataBind();
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
            lbl_Receipt_Amt.Text = "0";
            lbl_Already_Paid_Amt.Text = "0";
            lbl_Balance_Amt.Text = "0";
            txt_Payable_Amt.Text = string.Empty;
            txt_Write_Off_Amt.Text = string.Empty;
            txt_Write_Off_Amt_Remarks.Text = string.Empty;
            ddl_Charge_head.SelectedIndex = -1;

            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
            btnUpdate.CssClass = "updates";

            ViewState["UPDATED_ID"] = null;
            HD_Ch_update_id.Value = "";
            //load_Jobno();
            if (Rd_Bill_Type.SelectedValue.ToString() == "I")
            {
                load_Vendor_Billno();
            }
            else if (Rd_Bill_Type.SelectedValue.ToString() == "J")
            {
                load_Jobno();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void GV_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    } 
    protected void btn_Save_Update_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtReceiptNo.Text != string.Empty)
            {
                if (ddlPartyname.SelectedValue.ToString() != string.Empty)
                {
                    if (ddlPartyBranch.SelectedValue.ToString() != string.Empty)
                    {
                         if (ddl_Bank_From.SelectedValue.ToString() != string.Empty)
                            {
                             if (ddl_Acc_No.SelectedValue.ToString() != string.Empty)
                                {
                                  if (ddl_ifsc_Code.SelectedValue.ToString() != string.Empty)
                                   {
                                      if (txt_Cash_Amount.Text != string.Empty)
                                      {
                                          if (Rd_Mode_Of_Payment.SelectedValue.ToString() == "CA")
                                          {
                                              Receipt_Save();
                                          }
                                          else 
                                          {
                                              if (txt_Chk_NB_Refno.Text != string.Empty)
                                              {
                                                  if (Rd_Mode_Of_Payment.SelectedValue.ToString() == "NB")
                                                  {
                                                      if (ddl_To_BankName.SelectedValue.ToString() != string.Empty)
                                                      {
                                                          if (txt_to_Acc_No.Text != string.Empty)
                                                          {
                                                              if (txt_to_Bank_ifsc_Code.Text != string.Empty)
                                                              {
                                                                  Receipt_Save();
                                                              }
                                                              else
                                                              {
                                                                  Alert_msg("Enter Ur To Acc. No ifsc Code!", "txt_to_Bank_ifsc_Code");
                                                              }
                                                          }
                                                          else
                                                          {
                                                              Alert_msg("Enter Ur To Acc. No!", "txt_to_Acc_No");
                                                          }
                                                      }
                                                      else
                                                      {
                                                          Alert_msg("Select Ur Bank To Name!", "ddl_To_BankName");
                                                      }
                                                  }
                                                  else
                                                  {
                                                      Receipt_Save();
                                                  }
                                              }
                                              else
                                              {
                                                  Alert_msg("Select Ur Cheque / Ref No!", "txt_Chk_NB_Refno");
                                              }
                                          }
                                      }
                                      else
                                      {
                                          Alert_msg("Enter Ur Amount!", "txt_Cash_Amount");
                                      }
                                    }
                                  else
                                  {
                                      Alert_msg("Select Ur From Bank ifsc Code.!", "ddl_ifsc_Code");
                                  }
                            }
                             else
                             {
                                 Alert_msg("Select Ur From Bank Acc. No.!", "ddl_Acc_No");
                             }
                         }
                         else
                         {
                             Alert_msg("Select Ur From Bank!", "ddl_Bank_From");
                         }
                    }
                    else
                    {
                        Alert_msg("Select Ur Party Branch!", "ddlPartyBranch");
                    }
                }
                else
                {
                    Alert_msg("Select Ur PartyName!", "ddlPartyname");
                }
                  
            }
            else
            {
                Alert_msg("Enter Ur ReceiptNo!", "txtReceiptNo");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void Receipt_Save()
    {
        if (btn_Save_Update.Text == "Save")
        {
            ds = Receipt_Insert_Update("RS");
            if (ds.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = ds.Tables[0].Rows[0]["R_ID"].ToString();
                btn_Save_Update.Text = "Update";
                Alert_msg("Saved Successfully!", "btn_Save_Update");
                //load_Jobno();
                Job_Invno_ED();
                if (Rd_Bill_Type.SelectedValue.ToString() == "I")
                {
                    load_Vendor_Billno();
                }
                else if (Rd_Bill_Type.SelectedValue.ToString() == "J")
                {
                    load_Jobno();
                }
            }
        }
        else if (btn_Save_Update.Text == "Update")
        {
            ds = Receipt_Insert_Update("RU");
            if (ds.Tables[0].Rows.Count > 0)
            {
                btn_Save_Update.Text = "Update";
                Alert_msg("Updated Successfully!", "btn_Save_Update");
            }
        }                                    
    }
    private void load_Jobno()
    {
        try
        {
            ddljobno.Items.Clear();
            txt_Other_Jobno.Text = "";
            DataSet ds = new DataSet();
            ObjUBO.A1 = HDupdate_id.Value.ToString();
            ObjUBO.A2 = txtReceiptNo.Text;
            ObjUBO.A3 = ddlPartyname.SelectedValue.ToString();
            ObjUBO.A4 = ddlPartyBranch.SelectedValue.ToString();
            ObjUBO.A7 = Rd_IMP_EXP.SelectedValue.ToString();
            //ObjUBO.A9 = Rd_S_M_JI.SelectedValue.ToString();
            ObjUBO.A15 = "Sales_Jobno_Select";
            ds = RE.Receipt_Entry_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddljobno.DataSource = ds.Tables[0];
                ddljobno.DataTextField = "JOBNO_PS";
                ddljobno.DataValueField = "JOBNO_PS";
                ddljobno.DataBind();
            }
            ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddljobno.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public DataSet Receipt_Insert_Update(string S1)
    {
        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A2 = txtReceiptNo.Text;
        ObjUBO.A3 = txtReceipt_Date.Text;
        ObjUBO.A4 = RdPayFor.SelectedValue.ToString();
        ObjUBO.A5 = ddlPartyname.SelectedValue.ToString();
        ObjUBO.A6 = ddlPartyBranch.SelectedValue.ToString();
        ObjUBO.A7 = ddl_Bank_From.SelectedValue.ToString();
        ObjUBO.A8 = ddl_Acc_No.SelectedValue.ToString();
        ObjUBO.A9 = ddl_ifsc_Code.SelectedValue.ToString();
        ObjUBO.A10 = Rd_Mode_Of_Payment.SelectedValue.ToString();
        ObjUBO.A11 = txt_Cash_Amount.Text;
        ObjUBO.A12 = txt_Chk_NB_Refno.Text;
        ObjUBO.A13 = ddl_To_BankName.SelectedValue.ToString();
        ObjUBO.A14 = txt_to_Acc_No.Text;
        ObjUBO.A15 = txt_to_Bank_ifsc_Code.Text;
        ObjUBO.A16 = txt_Remarks.Text;

        ObjUBO.A20 = HD_Ch_update_id.Value.ToString();
        ObjUBO.A21 = ddlslno.SelectedValue.ToString();
        ObjUBO.A22 = Rd_IMP_EXP.SelectedValue.ToString(); 
        ObjUBO.A23 = ddljobno.SelectedValue.ToString();
        /*
        ObjUBO.A24 = lbl_Jobdate.Text;
        ObjUBO.A25 = lbl_Cus_Name.Text;
        */
        ObjUBO.A26 = txt_Payable_Amt.Text;
        ObjUBO.A27 = txt_Write_Off_Amt.Text;
        ObjUBO.A28 = txt_Write_Off_Amt_Remarks.Text;
       // ObjUBO.A29 = Rd_S_M_JI.SelectedValue.ToString();


        ObjUBO.A30 = Rd_Royal_Other.SelectedValue.ToString();
        ObjUBO.A31 = lbl_Job_Company_Lic.Text;
        ObjUBO.A32 = lbl_Job_Wrk_Period.Text;
        ObjUBO.A33 = txt_Other_Jobno.Text;
        if (ddl_Charge_head.SelectedValue != string.Empty)
        {
            string[] arr2 = new string[] { };
            arr2 = ddl_Charge_head.SelectedValue.ToString().Split('~');

            ObjUBO.A34 = arr2[1];
            ObjUBO.A35 = arr2[0]; 
        }
        ObjUBO.A36 = Rd_Bill_Type.SelectedValue.ToString();
        ObjUBO.A37 = ddl_SalesBillno.SelectedValue.ToString();

        ObjUBO.A60 = S1;
        ds = RE.Receipt_Entry_Ins_Upd(ObjUBO);
        return ds;
    }
    protected void ddl_Bank_From_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddl_Acc_No.Items.Clear();
            if (ddl_Bank_From.SelectedValue.ToString() != string.Empty)
            {
                ObjUBO.A5 = ddl_Bank_From.SelectedValue.ToString();
                ObjUBO.A15 = "From_Bank_Acc_No_Select";
                ds = RE.Receipt_Entry_Select(ObjUBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddl_Acc_No.DataSource = ds.Tables[0];
                    ddl_Acc_No.DataTextField = "Acc_No_Loc";
                    ddl_Acc_No.DataValueField = "Acc_No";
                    ddl_Acc_No.DataBind();
                }
            }
            ddl_Acc_No.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Acc_No.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void ddl_Acc_No_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddl_ifsc_Code.Items.Clear();
            if (ddl_Bank_From.SelectedValue.ToString() != string.Empty)
            {
                ObjUBO.A5 = ddl_Bank_From.SelectedValue.ToString();
                ObjUBO.A6 = ddl_Acc_No.SelectedValue.ToString();
                ObjUBO.A15 = "From_Bank_Acc_No_ifsc_Select";
                ds = RE.Receipt_Entry_Select(ObjUBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddl_ifsc_Code.DataSource = ds.Tables[0];
                    ddl_ifsc_Code.DataTextField = "IFSC_Br";
                    ddl_ifsc_Code.DataValueField = "IFSCODE";
                    ddl_ifsc_Code.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Payment_Mode()
    {
        if (Rd_Mode_Of_Payment.SelectedValue.ToString() == "CA")
        { 
            lbl_Chk_Nb_refno.Visible=false;
            lbl_NB.Visible=false;
        }
        else if (Rd_Mode_Of_Payment.SelectedValue.ToString() == "CH")
        {
            lbl_Chk_Nb_refno.Visible=true;
            lbl_NB.Visible=false;
        }
        else if (Rd_Mode_Of_Payment.SelectedValue.ToString() == "NB")
        {
            lbl_Chk_Nb_refno.Visible = true;
            lbl_NB.Visible = true;
        }
    }
    protected void Rd_Mode_Of_Payment_SelectedIndexChanged(object sender, EventArgs e)
    {
        Payment_Mode();
    }
    protected void Rd_IMP_EXP_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnNew_Click(sender, e);
        load_Jobno();
        Load_Grid();
    }
    protected void gv_Ch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Enabled = true;
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_Ch, "Select$" + e.Row.RowIndex.ToString()));
        }
    }
    protected void gv_Ch_RowCreated(object sender, GridViewRowEventArgs e)
     {
         if (e.Row.RowType == DataControlRowType.Header)
             e.Row.CssClass = "header";
         if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
             e.Row.CssClass = "normal";
         if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
             e.Row.CssClass = "alternate";
     }
    protected void gv_Ch_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ViewState["RC_ID"] = gv_Ch.DataKeys[gv_Ch.SelectedRow.RowIndex].Values["JOBNO"].ToString();
        ViewState["RC_ID"] = gv_Ch.DataKeys[gv_Ch.SelectedRow.RowIndex].Values["RC_ID"].ToString();
        ddljobno.Items.Clear();
        if (ViewState["RC_ID"] != "" && ViewState["RC_ID"] != null)
        {
            ViewState["UPDATED_ID"] = null;
            ViewState["UPDATED_ID"] = ViewState["RC_ID"].ToString();
            btnUpdate.CssClass = "updates";
            //---------------------------------------------
            ddlslno.SelectedValue = gv_Ch.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            ddl_SalesBillno.SelectedValue = gv_Ch.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            Rd_IMP_EXP.SelectedValue = gv_Ch.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");

            ddljobno.Items.Insert(0, new ListItem(gv_Ch.SelectedRow.Cells[4].Text.Replace("&nbsp;", ""), gv_Ch.DataKeys[gv_Ch.SelectedRow.RowIndex].Values["JOBNO"].ToString()));
            ddljobno.SelectedIndex = 0;

            ddljobno_SelectedIndexChanged(sender, e);

            ddl_Charge_head.SelectedValue = gv_Ch.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            txt_Payable_Amt.Text = gv_Ch.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            txt_Write_Off_Amt.Text = gv_Ch.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            txt_Write_Off_Amt_Remarks.Text = gv_Ch.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
            //Rd_S_M_JI.SelectedValue= gv_Ch.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");

            HD_Ch_update_id.Value = ViewState["RC_ID"].ToString();
            txt_Other_Jobno.Text = ddljobno.SelectedItem.Text;
            //--------------------------------------------------
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnNew.Visible = true;
        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
        }
        Job_Amt_Cal();
    }
    private void Job_Amt_Cal()
    {
        try
        {
            if(ddl_Charge_head.SelectedValue.ToString() !=string.Empty)
            {
                string[] arr = new string[] { };

                lbl_Receipt_Amt.Text = "0";
                lbl_Already_Paid_Amt.Text = "0";
                lbl_Balance_Amt.Text = "0";
               
                DataSet ds = new DataSet();
                ObjUBO.A1 = HDupdate_id.Value.ToString();
                ObjUBO.A2 = txtReceiptNo.Text;
                ObjUBO.A3 = ddlPartyname.SelectedValue.ToString();
                ObjUBO.A4 = ddlPartyBranch.SelectedValue.ToString();
                ObjUBO.A7 = Rd_IMP_EXP.SelectedValue.ToString();
                ObjUBO.A8 = ddljobno.SelectedValue.ToString();

                arr = ddl_Charge_head.SelectedValue.ToString().Split('~');
                ObjUBO.A10 = arr[1];
                ObjUBO.A11 = arr[0];
                //ObjUBO.A9 = Rd_S_M_JI.SelectedValue.ToString();
                ObjUBO.A15 = "Receipt_Jobno_Amt_Select";
                ds = RE.Receipt_Entry_Select(ObjUBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lbl_Receipt_Amt.Text = ds.Tables[0].Rows[0]["Sales_AMT"].ToString();
                    lbl_Already_Paid_Amt.Text = ds.Tables[0].Rows[0]["Rec_Amt"].ToString();
                    lbl_Balance_Amt.Text = ds.Tables[0].Rows[0]["Bal_Amt"].ToString();
                }
            }
            else
            {
                Alert_msg("Select Ur Chargehead!", "ddl_Charge_head");
            }
        }
        catch(Exception ex)
        {
           Connection.Error_Msg(ex.Message);
        }
    }
   
    private void Load_Grid()
    {
        DataSet ds = new DataSet();
        ObjUBO.A2 = txtReceiptNo.Text;
        ObjUBO.A15 = "Receipt_Ch_Select";
        ds = RE.Receipt_Entry_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gv_Ch.DataSource = ds.Tables[0];
            gv_Ch.DataBind();
        }
        else
        {
            gv_Ch.DataSource = dt;
            gv_Ch.DataBind();
        }
    }


    protected void Rd_Royal_Other_SelectedIndexChanged(object sender, EventArgs e)
    {
        E_Royal_Other_Jobs();
    }
    private void E_Royal_Other_Jobs()
    {
        txt_Other_Jobno.Text = string.Empty;
        ddljobno.SelectedIndex = -1;

        if (Rd_Royal_Other.SelectedValue.ToString() == "R")
        {
            txt_Other_Jobno.Enabled = false;
            ddljobno.Enabled = true;
        }
        else
        {
            ddljobno.Enabled = false;
            txt_Other_Jobno.Enabled = true;
        }
    }
    protected void ddl_Charge_head_SelectedIndexChanged(object sender, EventArgs e)
    {
        Job_Amt_Cal();
        Load_Grid();
    }
    protected void ddl_SalesBillno_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbl_Receipt_Amt.Text = "0";
        lbl_Already_Paid_Amt.Text = "0";
        lbl_Balance_Amt.Text = "0";

        if (ddl_SalesBillno.SelectedValue.ToString() != string.Empty)
        {
            DataSet ds = new DataSet();
            ObjUBO.A1 = HDupdate_id.Value.ToString();
            ObjUBO.A2 = ddl_SalesBillno.SelectedValue.ToString();
            ObjUBO.A3 = ddlPartyname.SelectedValue.ToString();
            ObjUBO.A4 = ddlPartyBranch.SelectedValue.ToString();

            ObjUBO.A15 = "Payment_Sales_Billno_Amt_Select";
            ds = RE.Receipt_Entry_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_Receipt_Amt.Text = ds.Tables[0].Rows[0][0].ToString();
            }
        }

    
    }
    private void load_Vendor_Billno()
    {
        try
        {
            ddl_SalesBillno.Items.Clear();
            DataSet ds = new DataSet();
            ObjUBO.A1 = HDupdate_id.Value.ToString();
            ObjUBO.A2 = txtReceiptNo.Text;
            ObjUBO.A3 = ddlPartyname.SelectedValue.ToString();
            ObjUBO.A4 = ddlPartyBranch.SelectedValue.ToString();
            ObjUBO.A15 = "Sales_Billno_Select";
            ds = RE.Receipt_Entry_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_SalesBillno.DataSource = ds.Tables[0];
                ddl_SalesBillno.DataTextField = "BILL_INV_NO";
                ddl_SalesBillno.DataValueField = "BILL_INV_NO";
                ddl_SalesBillno.DataBind();
            }
            ddl_SalesBillno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_SalesBillno.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void Rd_Bill_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        Job_Invno_ED();
    }
    private void Job_Invno_ED()
    {
        if (Rd_Bill_Type.SelectedValue.ToString() == "J")
        {
            ddl_SalesBillno.Items.Clear();
            ddljobno.Items.Clear();
            ddl_Charge_head.SelectedIndex = -1;
            ddl_SalesBillno.Enabled = false;

        }
        else if (Rd_Bill_Type.SelectedValue.ToString() == "I")
        {
            ddl_Charge_head.Items.Clear();
            ddljobno.Items.Clear();
            txt_Other_Jobno.Text = string.Empty;

            ddl_SalesBillno.Enabled = true;
            ddljobno.Enabled = false;
            txt_Other_Jobno.Enabled = false;
            ddl_Charge_head.Enabled = false;
            Rd_IMP_EXP.Enabled = false;
        }
    }
}