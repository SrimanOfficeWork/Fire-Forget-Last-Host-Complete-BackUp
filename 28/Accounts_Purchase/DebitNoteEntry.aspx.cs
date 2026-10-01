using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.Text;
using System.IO;

public partial class DebitNoteEntry : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();

    DebitNote_cs BI = new DebitNote_cs();
    Global_variables ObjUBO = new Global_variables();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    public int i;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        CalendarExtender1.EndDate = DateTime.Now;
        if (!IsPostBack)
        {
            txtTotalamtininr.Attributes.Add("readonly", "readonly");
            txt_D_C_bal_Amt.Attributes.Add("readonly", "readonly");
            txt_CGST_Amt.Attributes.Add("readonly", "readonly");
            txt_SGST_Amt.Attributes.Add("readonly", "readonly");
            txt_IGST_Amt.Attributes.Add("readonly", "readonly");
            txt_Tds_Amt.Attributes.Add("readonly", "readonly");

            txt_D_C_bal_Amt.Style.Add("background-color", "#F0F0F0");
            txtTotalamtininr.Style.Add("background-color", "#F0F0F0");
            txt_CGST_Amt.Style.Add("background-color", "#F0F0F0");
            txt_SGST_Amt.Style.Add("background-color", "#F0F0F0");
            txt_IGST_Amt.Style.Add("background-color", "#F0F0F0");
            txt_Tds_Amt.Style.Add("background-color", "#F0F0F0");
          
            Load_Cus_Exp_Head_Name_Select();
            load_Jobno();
          
            if (Request.QueryString["DebitNote_No"] == null || Request.QueryString["DebitNote_No"] == string.Empty)
            {
                lbl_Job_Company_Lic.Text = Connection.Company_License().ToUpper();
                lbl_Job_Wrk_Period.Text = Connection.WorkingPeriod();

                Rd_Royal_Other.Enabled = true;
                Rd_IMP_EXP.Enabled = true;
                Load_Purchase_No();

                txtDebitNote_no.Attributes.Add("readonly", "readonly");
                txtDebitNote_no.Style.Add("background-color", "#F0F0F0");
                txtDebitNote_Date.Text = DateTime.Now.ToString("dd/MM/yyyy");
                btn_Save_Update.Text = "Save";
                gv_Ch.DataSource = dt;
                gv_Ch.DataBind();
            }
            else
            {
                
                Updated_Item_Load();
                txtDebitNote_no.Attributes.Add("readonly", "readonly");
                txtDebitNote_no.Style.Add("background-color", "#F0F0F0");

                txtbillamount.Attributes.Add("readonly", "readonly");
                txtbillamount.Style.Add("background-color", "#F0F0F0");

                Rd_Bill_Type.Enabled = false;
                Rd_IMP_EXP.Enabled = false;
                btn_Save_Update.Text = "Update";

                //ddlVendorname.Enabled = false;
                //ddlVendorBranch.Enabled = false;
                Rd_Royal_Other.Enabled = false;
            }
            E_Royal_Other_Jobs();
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }
    }
    private void Load_Purchase_No()
    {
        DataSet dss = new DataSet();
        ObjUBO.A12 =Rd_Royal_Other.SelectedValue.ToString();
        ObjUBO.A13=lbl_Job_Company_Lic.Text;
        ObjUBO.A14 = lbl_Job_Wrk_Period.Text;
        ObjUBO.A19 = "Debitnote_No_Select";
        dss = BI.DebitNote_Entry_Select(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            txtDebitNote_no.Text = dss.Tables[0].Rows[0]["DEBITNOTE_NO"].ToString();
        }
        if (dss.Tables[1].Rows.Count > 0)
        {
            ddl_Purchase_No.DataSource = dss.Tables[1];
            ddl_Purchase_No.DataTextField = "VENDOR_BILL_NO";
            ddl_Purchase_No.DataValueField = "VENDOR_BILL_NO";
            ddl_Purchase_No.DataBind();
        }

        ddl_Purchase_No.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Purchase_No.SelectedIndex = 0;
    }
    private void Updated_Item_Load()
    {
        ObjUBO.A1 = Request.QueryString["DebitNote_No"].ToString();
        ObjUBO.A19 = "Debitnote_Updated_Data_Select";
        ds = BI.DebitNote_Entry_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            HDupdate_id.Value = ds.Tables[0].Rows[0]["D_ID"].ToString();
            ddl_Purchase_No.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["PURCHASE_NO"].ToString(), ds.Tables[0].Rows[0]["PURCHASE_NO"].ToString()));
            ddl_Purchase_No.SelectedIndex = 0;

            
            ddl_Purchase_No.Attributes.Add("readonly", "readonly");
            ddl_Purchase_No.Style.Add("background-color", "#F0F0F0");
            ddl_Purchase_No.Enabled = false;
            
            Rd_Bill_Type.SelectedValue= ds.Tables[0].Rows[0]["BILL_TYPE"].ToString();
            txtDebitNote_no.Text = ds.Tables[0].Rows[0]["DEBITNOTE_NO"].ToString();
            txtDebitNote_Date.Text = ds.Tables[0].Rows[0]["DEBITNOTE_DATE"].ToString();

            lbl_Ven_Name.Text= ds.Tables[0].Rows[0]["VENDOR_NAME"].ToString();
            lbl_Ven_Branch.Text = ds.Tables[0].Rows[0]["VENDOR_BRANCH"].ToString();

            txtVendorstate.Text = ds.Tables[0].Rows[0]["VENDOR_STATE"].ToString(); 
            txtGstn.Text = ds.Tables[0].Rows[0]["GSTN_NO"].ToString();
            txtGstntype.Text = ds.Tables[0].Rows[0]["GSTN_TYPE"].ToString();
            txtCountry.Text = ds.Tables[0].Rows[0]["COUNTRY_CODE"].ToString();
            lbl_Ven_billno.Text = ds.Tables[0].Rows[0]["VENDOR_BILL_NO"].ToString();
            lbl_Ven_bill_Date.Text = ds.Tables[0].Rows[0]["VENDOR_BILL_DATE"].ToString();

            txtbillamount.Text = ds.Tables[0].Rows[0]["BILL_AMOUNT"].ToString();
            txtBill_Cur.Text = ds.Tables[0].Rows[0]["BILL_CUR"].ToString();
            txtExrate.Text = ds.Tables[0].Rows[0]["EX_RATE"].ToString();
            txtTotalamtininr.Text = ds.Tables[0].Rows[0]["AMT_IN_INR"].ToString();
            Rd_Debit_Credit.SelectedValue=ds.Tables[0].Rows[0]["DEBIT_CREDIT"].ToString();
            txtNarration.Text = ds.Tables[0].Rows[0]["REMARKS"].ToString();

            Rd_Royal_Other.SelectedValue = ds.Tables[0].Rows[0]["JOB_TYPE"].ToString();
            lbl_Job_Company_Lic.Text = ds.Tables[0].Rows[0]["JOB_LICENSE"].ToString();
            lbl_Job_Wrk_Period.Text = ds.Tables[0].Rows[0]["JOB_WORKINGPERIOD"].ToString();
            lbl_under_name.Text = ds.Tables[0].Rows[0]["UNDER_NAME"].ToString();
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            gv_Ch.DataSource = ds.Tables[1];
            gv_Ch.DataBind();
            if (gv_Ch.Rows.Count > 0)
            {

                GridViewRow lastRow = gv_Ch.Rows[0];
                string slnoValue = lastRow.Cells[1].Text;
                int slnoInt;
                if (int.TryParse(slnoValue.ToString(), out slnoInt))
                {
                    slnoInt++;
                    ddlslno.SelectedValue = slnoInt.ToString();
                }
                else
                {
                    ddlslno.SelectedValue = "1";
                }
            }
        }
        else
        {
            gv_Ch.DataSource = dt;
            gv_Ch.DataBind();
        }

        if (ds.Tables[2].Rows.Count > 0)
        {
            txt_D_C_bal_Amt.Text=ds.Tables[2].Rows[0]["Bal_Amt"].ToString(); 
        }
    }
    
    private void Load_Cus_Exp_Head_Name_Select()
    {
        try
        {
            ddl_Charge_head.Items.Clear();
            DataSet ds = new DataSet();
            ObjUBO.A19 = "Cus_Exp_Head_Name_Select";
            ds = BI.DebitNote_Entry_Select(ObjUBO);
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_Charge_head.DataSource = ds.Tables[0];
                ddl_Charge_head.DataTextField = "CHARGE_NAME";
                ddl_Charge_head.DataValueField = "CHARGE_VALUE";
                ddl_Charge_head.DataBind();
            }
            ddl_Charge_head.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Charge_head.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    
    private void Clear()
    {
        txtVendorstate.Text=string.Empty;
        txtGstn.Text=string.Empty;
        txtGstntype.Text=string.Empty;
        txtCountry.Text = string.Empty;
    }
    protected void btn_Save_Update_Click(object sender, EventArgs e)
     {
         try{
             if (txtDebitNote_no.Text != string.Empty)
             {
                 if (ddl_Purchase_No.SelectedValue.ToString() != string.Empty)
                 {
                     if (txtTotalamtininr.Text != string.Empty)
                     {
                         if (btn_Save_Update.Text == "Save")
                         {
                             ds = DebitNote_Insert_Update("DS");
                             if (ds.Tables[0].Rows.Count > 0)
                             {
                                 HDupdate_id.Value = ds.Tables[0].Rows[0]["D_ID"].ToString();
                                 btn_Save_Update.Text = "Update";
                                 Alert_msg("Saved Successfully!", "btn_Save_Update");
                                 E_Royal_Other_Jobs();
                             }
                             if (ds.Tables[1].Rows.Count > 0)
                             {
                                 txt_D_C_bal_Amt.Text = ds.Tables[1].Rows[0][0].ToString();
                             }
                             if (ds.Tables[2].Rows.Count > 0)
                             {
                                 gv_Ch.DataSource = ds.Tables[2];
                                 gv_Ch.DataBind();
                             }
                             else
                             {
                                 gv_Ch.DataSource = dt;
                                 gv_Ch.DataBind();
                             }

                         }
                         else if (btn_Save_Update.Text == "Update")
                         {
                             ds = DebitNote_Insert_Update("DU");
                             if (ds.Tables[0].Rows.Count > 0)
                             {
                                 btn_Save_Update.Text = "Update";
                                 Alert_msg("Updated Successfully!", "btn_Save_Update");
                             }

                             if (ds.Tables[1].Rows.Count > 0)
                             {
                                 txt_D_C_bal_Amt.Text = ds.Tables[1].Rows[0][0].ToString();
                             }
                         }
                     }
                     else
                     {
                         Alert_msg("Enter Ur Bill Amount!", "txtbillamount");
                     }
                 }
                 else
                 {
                     Alert_msg("select Ur Purchase!", "ddl_Purchase_No");
                 }
             }
             else
             {
                 Alert_msg("Enter Ur DebitNoteNo!", "txtDebitNote_no");
             }
         }
          catch(Exception ex)
         {
          Connection.Error_Msg(ex.Message);
          }
     }
    public DataSet DebitNote_Insert_Update(string S1)
     {
         ObjUBO.A1 = HDupdate_id.Value.ToString();
         ObjUBO.A2 = Rd_Bill_Type.SelectedValue.ToString();
         ObjUBO.A3 = txtDebitNote_no.Text;
         ObjUBO.A4 = txtDebitNote_Date.Text;
         ObjUBO.A5 = lbl_Ven_Name.Text;
         ObjUBO.A6 = lbl_Ven_Branch.Text; 
         ObjUBO.A7 = txtVendorstate.Text;
         ObjUBO.A8 = txtGstn.Text;
         ObjUBO.A9 = txtGstntype.Text;
         ObjUBO.A10 = txtCountry.Text;
         ObjUBO.A11 = lbl_Ven_billno.Text;
         ObjUBO.A12 = lbl_Ven_bill_Date.Text;
         ObjUBO.A13 = txtbillamount.Text;
         ObjUBO.A14 = txtBill_Cur.Text;
         ObjUBO.A15 = txtExrate.Text;
         ObjUBO.A16 = txtTotalamtininr.Text;
         ObjUBO.A17 = txtNarration.Text;
         ObjUBO.A18 = Rd_Debit_Credit.SelectedValue.ToString();
         ObjUBO.A19 = ddlslno.SelectedValue.ToString();
         ObjUBO.A20 = HD_Ch_update_id.Value.ToString();
         ObjUBO.A21 = Rd_IMP_EXP.SelectedValue.ToString();
         ObjUBO.A22 = ddljobno.SelectedValue.ToString();
         ObjUBO.A23 = txt_JobDate.Text;
         ObjUBO.A24 = lbl_Cus_Name.Text;
         ObjUBO.A25 = ddl_Charge_head.SelectedValue.ToString();
         ObjUBO.A26 = ddl_Tax_Rate.SelectedValue.ToString();
         ObjUBO.A27 = txt_Debit_Credit_Amt.Text;
         ObjUBO.A28 = txt_Tds_Rate.Text;

         ObjUBO.A29 = txt_CGST_Amt.Text;
         ObjUBO.A30 = txt_SGST_Amt.Text;
         ObjUBO.A31 = txt_IGST_Amt.Text;
         ObjUBO.A32 = txt_Tds_Amt.Text;

         ObjUBO.A33 = Rd_Royal_Other.SelectedValue.ToString();
         ObjUBO.A34 = lbl_Job_Company_Lic.Text ;
         ObjUBO.A35 = lbl_Job_Wrk_Period.Text;
         ObjUBO.A36 = txt_Other_Jobno.Text;
         ObjUBO.A37 = ddl_Purchase_No.SelectedValue.ToString();
         ObjUBO.A38 = lbl_under_name.Text;

         ObjUBO.A49 = S1;
         ds = BI.DebitNote_Entry_Ins_Upd(ObjUBO);
         return ds;
     }

     protected void btnNew_Click(object sender, EventArgs e)
     {
         ddljobno.SelectedIndex = -1;
        
         txt_JobDate.Text = string.Empty;
         lbl_Cus_Name.Text = string.Empty;
         ddl_Charge_head.SelectedIndex = -1;
         ddl_Tax_Rate.SelectedIndex = -1;
         txt_Debit_Credit_Amt.Text = string.Empty;
         txt_Tds_Rate.Text = string.Empty;
         txt_CGST_Amt.Text = string.Empty;
         txt_SGST_Amt.Text = string.Empty;
         txt_IGST_Amt.Text = string.Empty;
         txt_Tds_Amt.Text = string.Empty;
         Rd_IMP_EXP.Enabled = false;
         btnDelete.Visible = false;
         btnUpdate.Visible = false;
         btnSave.Visible = true;
         btnNew.Visible = true;
         btnUpdate.CssClass = "updates";
         if (gv_Ch.Rows.Count > 0)
         {
            
             GridViewRow lastRow = gv_Ch.Rows[0];
             string slnoValue = lastRow.Cells[1].Text;
             int slnoInt;
             if (int.TryParse(slnoValue.ToString(), out slnoInt))
             {
                 slnoInt++;
                 ddlslno.SelectedValue = slnoInt.ToString();
             }
             else
             {
                 ddlslno.SelectedValue = "1"; 
             }
         }
         ObjUBO.A38 = lbl_under_name.Text;
         ViewState["UPDATED_ID"] = null;
         HD_Ch_update_id.Value = "";
     }
     protected void ddljobno_SelectedIndexChanged(object sender, EventArgs e)
     {
        
         txt_Other_Jobno.Text = ddljobno.SelectedItem.Text;
         DataSet ds = new DataSet();
         ObjUBO.A15 = txt_Other_Jobno.Text;
        ObjUBO.A5 = Rd_IMP_EXP.SelectedValue.ToString();
        ObjUBO.A19 = "Jobno_Select";
        ds = BI.DebitNote_Entry_Select(ObjUBO);
        if (ds.Tables[1].Rows.Count > 0)
        {
            txt_JobDate.Text = ds.Tables[1].Rows[0]["JOBDATE"].ToString();
            lbl_Cus_Name.Text = ds.Tables[1].Rows[0]["CUS_NAME"].ToString();
        }

     }
     protected void Rd_IMP_EXP_SelectedIndexChanged(object sender, EventArgs e)
     {
         load_Jobno();
     }

     protected void btnSave_Click(object sender, EventArgs e)
     {
         try
         {
             if (txt_Other_Jobno.Text != string.Empty)
             {
                     if (ddl_Charge_head.SelectedValue.ToString() != string.Empty)
                     {
                         if (txt_Debit_Credit_Amt.Text != string.Empty)
                         {
                             if (Bill_Amt_Val() == "T")
                             {
                                 ds = DebitNote_Insert_Update("DCS");
                                 if (ds.Tables[0].Rows.Count > 0)
                                 {
                                     HD_Ch_update_id.Value = ds.Tables[0].Rows[0]["DC_ID"].ToString();

                                     ViewState["UPDATED_ID"] = null;
                                     Alert_msg("Debit Note Entry Saved Successfully", "btnSave");
                                   

                                 }
                                 else
                                 {
                                     Alert_msg("Debit Note Not Saved", "btnSave");
                                 }


                                 if (ds.Tables[1].Rows.Count > 0)
                                 {
                                     gv_Ch.DataSource = ds.Tables[1];
                                     gv_Ch.DataBind();
                                     btnNew_Click(this, null);
                                 }
                                 else
                                 {
                                     gv_Ch.DataSource = dt;
                                     gv_Ch.DataBind();
                                 }

                                 if (ds.Tables[2].Rows.Count > 0)
                                 {
                                     txt_D_C_bal_Amt.Text = ds.Tables[2].Rows[0][0].ToString();
                                 }
                             }
                             else
                             {
                                 Alert_msg("Invalid Debit / Credit Amt !");
                             }
                         }
                         else
                         {
                             Alert_msg("Enter Ur Debit Credit Amt !", "txt_Debit_Credit_Amt");
                         }
                     }
                     else
                     {
                         Alert_msg("Select Ur Charge Head !", "ddl_Charge_head");
                     }
                 
             }
             else
             {
                 Alert_msg("Enter or Select Ur Jobno !", "txt_Other_Jobno");
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
             if (txt_Other_Jobno.Text != string.Empty)
             {
                     if (ddl_Charge_head.SelectedValue.ToString() != string.Empty)
                     {
                         if (txt_Debit_Credit_Amt.Text != string.Empty)
                         {
                             if (Bill_Amt_Val() == "T")
                             {
                                 ds = DebitNote_Insert_Update("DCU");
                                 if (ds.Tables[0].Rows.Count > 0)
                                 {
                                     HD_Ch_update_id.Value = ds.Tables[0].Rows[0]["DC_ID"].ToString();

                                     ViewState["UPDATED_ID"] = null;
                                     Alert_msg("Debit Note Entry Updated Successfully", "btnUpdate");
                                 }
                                 else
                                 {
                                     Alert_msg("Debit Note Not Updated", "btnUpdate");
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
                                 if (ds.Tables[2].Rows.Count > 0)
                                 {
                                     txt_D_C_bal_Amt.Text = ds.Tables[2].Rows[0][0].ToString();
                                 }
                             }
                             else
                             {
                                 Alert_msg("Invalid Debit / Credit Amt !");
                             }
                         }
                         else
                         {
                             Alert_msg("Enter Ur Debit Credit Amt !", "txt_Debit_Credit_Amt");
                         }
                     }
                     else
                     {
                         Alert_msg("Select Ur Charge Head !", "ddl_Charge_head");
                     }
             }
             else
             {
                 Alert_msg("Enter or Select Ur Jobno !", "txt_Other_Jobno");
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
             ds = DebitNote_Insert_Update("DCD");
             if (ds.Tables[0].Rows.Count == 0)
             {
                 ViewState["UPDATED_ID"] = null;
               
                 Alert_msg("Debit Note Entry Deleted");
             }
             else
             {
                 Alert_msg("Debit Note Not Deleted", "btnDelete");
             }

             if (ds.Tables[1].Rows.Count > 0)
             {
                 gv_Ch.DataSource = ds.Tables[1];
                 gv_Ch.DataBind();
                 btnNew_Click(sender, e);
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
         ViewState["DC_ID"] = Convert.ToString(this.gv_Ch.SelectedDataKey.Value);

         if (ViewState["DC_ID"] != "" && ViewState["DC_ID"] != null)
         {
             ViewState["UPDATED_ID"] = null;
             ViewState["UPDATED_ID"] = ViewState["DC_ID"].ToString();
             btnUpdate.CssClass = "updates";
             HDn_SIno.Value = "";
             //---------------------------------------------
             ddlslno.SelectedValue = gv_Ch.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
             Rd_IMP_EXP.SelectedValue = gv_Ch.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
             //ddljobno.SelectedValue = gv_Ch.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
             ddljobno.Items.Insert(0, new ListItem(gv_Ch.DataKeys[gv_Ch.SelectedRow.RowIndex].Values["JOBNO_PS"].ToString(), gv_Ch.DataKeys[gv_Ch.SelectedRow.RowIndex].Values["JOBNO"].ToString()));
             ddljobno.SelectedIndex = 0;

             txt_JobDate.Text = gv_Ch.SelectedRow.Cells[4].Text.Replace("01/01/1900", "").Replace("&nbsp;", "");
             //ddl_Cus_Name.SelectedValue = gv_Ch.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
             lbl_Cus_Name.Text = gv_Ch.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");

             ddl_Charge_head.SelectedValue = gv_Ch.SelectedRow.Cells[6].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
             ddl_Tax_Rate.SelectedValue = gv_Ch.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");

             txt_Debit_Credit_Amt.Text = gv_Ch.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
             txt_CGST_Amt.Text = gv_Ch.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
             txt_SGST_Amt.Text = gv_Ch.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
             txt_IGST_Amt.Text = gv_Ch.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
             txt_Tds_Rate.Text = gv_Ch.SelectedRow.Cells[12].Text.Replace("&nbsp;", "");
             txt_Tds_Amt.Text = gv_Ch.SelectedRow.Cells[13].Text.Replace("&nbsp;", "");

             txt_Other_Jobno.Text = gv_Ch.DataKeys[gv_Ch.SelectedRow.RowIndex].Values["JOBNO_PS"].ToString();
             HDn_SIno.Value = ddlslno.SelectedValue;
             HD_Ch_update_id.Value = ViewState["DC_ID"].ToString();
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
     public void Alert_msg(string msg)
     {
         string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Debit Note Entry', function (r) {});}});</script>";
         ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
     }
     public void Alert_msg(string msg, string focus)
     {
         string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Debit Note Entry', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
         ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
     }
     
     private void load_Jobno()
    {
        DataSet ds = new DataSet();
        
        ObjUBO.A5 = Rd_IMP_EXP.SelectedValue.ToString();
        ObjUBO.A19 = "Jobno_Select";
        ds = BI.DebitNote_Entry_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddljobno.DataSource = ds.Tables[0];
            ddljobno.DataTextField = "JOBNO_PS";
            ddljobno.DataValueField = "JOBNO";
            ddljobno.DataBind();
        }
        ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddljobno.SelectedIndex = 0;
    }
     private string  Bill_Amt_Val()
     {
        string Val = string.Empty;
        DataSet ds = new DataSet();
        ObjUBO.A6 = txt_Debit_Credit_Amt.Text;
        ObjUBO.A7 = txt_CGST_Amt.Text;
        ObjUBO.A8 = txt_SGST_Amt.Text;
        ObjUBO.A9 = txt_IGST_Amt.Text;
        ObjUBO.A10 = txt_Tds_Amt.Text;

        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A2 = txtDebitNote_no.Text;
        ObjUBO.A19 = "Bill_Amt_Chk";
        ObjUBO.A16 = HD_Ch_update_id.Value;
        ds = BI.DebitNote_Entry_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        { 
            Val=ds.Tables[0].Rows[0][0].ToString();
        }
        return Val;
    }

     protected void Rd_Royal_Other_SelectedIndexChanged(object sender, EventArgs e)
     {
         Load_Purchase_No();
         E_Royal_Other_Jobs();
     }
     private void E_Royal_Other_Jobs()
     {
         txt_Other_Jobno.Text = string.Empty;
         ddljobno.SelectedIndex = -1;

         if (Rd_Royal_Other.SelectedValue.ToString() == "R")
         {
             txt_Other_Jobno.Enabled = false;
             ddljobno.Visible = true;
         }
         else
         {
             ddljobno.Enabled = false;
             txt_Other_Jobno.Enabled = true;
         }
        
     }
     protected void ddl_Purchase_No_SelectedIndexChanged(object sender, EventArgs e)
     {
         if (ddl_Purchase_No.SelectedValue.ToString() != string.Empty)
         {
             ObjUBO.A11 = ddl_Purchase_No.SelectedValue.ToString();
             ObjUBO.A12 = Rd_Royal_Other.SelectedValue.ToString();
             ObjUBO.A13 = lbl_Job_Company_Lic.Text;
             ObjUBO.A14 = lbl_Job_Wrk_Period.Text;
             ObjUBO.A19 = "Purchase_No_Data_Select";
             ds = BI.DebitNote_Entry_Select(ObjUBO);
             if (ds.Tables[0].Rows.Count > 0)
             {
                 Rd_Bill_Type.SelectedValue = ds.Tables[0].Rows[0]["BILL_TYPE"].ToString();
                 lbl_Ven_Name.Text= ds.Tables[0].Rows[0]["VENDOR_NAME"].ToString();
                 lbl_Ven_Branch.Text= ds.Tables[0].Rows[0]["VENDOR_BRANCH"].ToString();
                 txtVendorstate.Text= ds.Tables[0].Rows[0]["VENDOR_STATE"].ToString();
                 txtGstn.Text= ds.Tables[0].Rows[0]["GSTN_NO"].ToString();
                 txtGstntype.Text= ds.Tables[0].Rows[0]["GSTN_TYPE"].ToString();
                 txtCountry.Text= ds.Tables[0].Rows[0]["COUNTRY_CODE"].ToString();

                 Rd_Debit_Credit.SelectedValue= ds.Tables[0].Rows[0]["DEBIT_CREDIT"].ToString();
                 txtNarration.Text= ds.Tables[0].Rows[0]["REMARKS"].ToString();
                 lbl_Ven_billno.Text= ds.Tables[0].Rows[0]["VENDOR_BILL_NO"].ToString();
                 lbl_Ven_bill_Date.Text= ds.Tables[0].Rows[0]["VENDOR_BILL_DATE"].ToString();
                 txtbillamount.Text= ds.Tables[0].Rows[0]["BILL_AMOUNT"].ToString();

                 txtBill_Cur.Text= ds.Tables[0].Rows[0]["BILL_CUR"].ToString();
                 txtExrate.Text= ds.Tables[0].Rows[0]["EX_RATE"].ToString();
                 txtTotalamtininr.Text = ds.Tables[0].Rows[0]["AMT_IN_INR"].ToString();
                 lbl_under_name.Text = ds.Tables[0].Rows[0]["UNDER"].ToString();
             }
         }
     }
     protected void gv_Ch_PageIndexChanging(object sender, GridViewPageEventArgs e)
     {
         gv_Ch.PageIndex = e.NewPageIndex;
         Load_Grid();
     }
     private void Load_Grid()
     {
         ObjUBO.A2 = txtDebitNote_no.Text;
         ObjUBO.A19 = "Debitnote_Charge_Select";
         ds = BI.DebitNote_Entry_Select(ObjUBO);
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
}