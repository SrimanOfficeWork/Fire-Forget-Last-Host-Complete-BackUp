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
using System.Web.Services;

public partial class PurchaseEntry : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();

    Purchase_cs BI = new Purchase_cs();
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
            Load_Group_Name();
            load_Jobno();
            if (Request.QueryString["voucherno"] == null || Request.QueryString["voucherno"] == string.Empty)
            {
                lbl_Job_Company_Lic.Text = Connection.Company_License().ToUpper();
                lbl_Job_Wrk_Period.Text = Connection.WorkingPeriod();

                Rd_Royal_Other.Enabled = true;

                Load_VendorName();
                txtVoucherno.Attributes.Add("readonly", "readonly");
                txtVoucherno.Style.Add("background-color", "#F0F0F0");
                txtVoucherdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                btn_Save_Update.Text = "Save";
                gv_Ch.DataSource = dt;
                gv_Ch.DataBind();
            }
            else
            {
                Updated_Item_Load();
                txtVoucherno.Attributes.Add("readonly", "readonly");
                txtVoucherno.Style.Add("background-color", "#F0F0F0");
                /*
                txtbillamount.Attributes.Add("readonly", "readonly");
                txtbillamount.Style.Add("background-color", "#F0F0F0");
                */

                Rd_Bill_Type.Enabled = false;

                btn_Save_Update.Text = "Update";

                ddlVendorname.Enabled = false;
                ddlVendorBranch.Enabled = false;
                Rd_Royal_Other.Enabled = false;
                btn_Pu_Delete.Visible = true;
            }
            E_Royal_Other_Jobs();
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }
    }
    private void Updated_Item_Load()
    {
        ObjUBO.A1 = Request.QueryString["voucherno"].ToString();
        ObjUBO.A19 = "Vendor_Updated_Data_Select";
        ds = BI.Purchase_Entry_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            HDupdate_id.Value = ds.Tables[0].Rows[0]["V_ID"].ToString();
            Rd_Bill_Type.SelectedValue = ds.Tables[0].Rows[0]["BILL_TYPE"].ToString();

            txt_PB_No_F.Text = ds.Tables[0].Rows[0]["PB_NO_F"].ToString();
            txtVoucherno.Text = ds.Tables[0].Rows[0]["VOUCHER_NO"].ToString();
            txt_PB_No_L.Text = ds.Tables[0].Rows[0]["PB_NO_L"].ToString();

            txtVoucherdate.Text = ds.Tables[0].Rows[0]["VOUCHER_DATE"].ToString();

            ddlVendorname.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["VENDOR_NAME"].ToString(), ds.Tables[0].Rows[0]["VENDOR_NAME"].ToString()));
            ddlVendorname.SelectedIndex = 0;

            ddlVendorBranch.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["VENDOR_BRANCH"].ToString(), ds.Tables[0].Rows[0]["VENDOR_BRANCH"].ToString()));
            ddlVendorBranch.SelectedIndex = 0;

            txtVendorstate.Text = ds.Tables[0].Rows[0]["VENDOR_STATE"].ToString();
            txtGstn.Text = ds.Tables[0].Rows[0]["GSTN_NO"].ToString();
            txtGstntype.Text = ds.Tables[0].Rows[0]["GSTN_TYPE"].ToString();
            txtCountry.Text = ds.Tables[0].Rows[0]["COUNTRY_CODE"].ToString();
            txtVendorbillno.Text = ds.Tables[0].Rows[0]["VENDOR_BILL_NO"].ToString();
            txtBilldate.Text = ds.Tables[0].Rows[0]["VENDOR_BILL_DATE"].ToString();
            txtbillamount.Text = ds.Tables[0].Rows[0]["BILL_AMOUNT"].ToString();
            txtBill_Cur.Text = ds.Tables[0].Rows[0]["BILL_CUR"].ToString();
            txtExrate.Text = ds.Tables[0].Rows[0]["EX_RATE"].ToString();
            txtTotalamtininr.Text = ds.Tables[0].Rows[0]["AMT_IN_INR"].ToString();
            Rd_Debit_Credit.SelectedValue = ds.Tables[0].Rows[0]["DEBIT_CREDIT"].ToString();
            txtNarration.Text = ds.Tables[0].Rows[0]["REMARKS"].ToString();

            Rd_Royal_Other.SelectedValue = ds.Tables[0].Rows[0]["JOB_TYPE"].ToString();
            lbl_Job_Company_Lic.Text = ds.Tables[0].Rows[0]["JOB_LICENSE"].ToString();
            lbl_Job_Wrk_Period.Text = ds.Tables[0].Rows[0]["JOB_WORKINGPERIOD"].ToString();

            ddl_Under_name.SelectedValue = ds.Tables[0].Rows[0]["UNDER"].ToString();
            Rd_Reg_Sez.SelectedValue = ds.Tables[0].Rows[0]["REG_SEZ"].ToString();
            txt_Posting_Date.Text = ds.Tables[0].Rows[0]["POSTING_DATE"].ToString();

            

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
            txt_D_C_bal_Amt.Text = ds.Tables[2].Rows[0]["Bal_Amt"].ToString();
        }
        int nextSlNo = gv_Ch.Rows.Count > 0 ? gv_Ch.Rows.Count + 1 : 1;
        ddlslno.SelectedValue = nextSlNo.ToString();
    }
    private void Load_VendorName()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjUBO.A19 = "Ven_Name_VNO_Select";
            ds = BI.Purchase_Entry_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlVendorname.DataSource = ds.Tables[0];
                ddlVendorname.DataTextField = "VEN_NAME";
                ddlVendorname.DataValueField = "VEN_NAME";
                ddlVendorname.DataBind();
            }
            ddlVendorname.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlVendorname.SelectedIndex = 0;

            if (ds.Tables[1].Rows.Count > 0)
            {
                txt_PB_No_F.Text = ds.Tables[1].Rows[0]["PB_P"].ToString();
                txtVoucherno.Text = ds.Tables[1].Rows[0]["VOUCHER_NO"].ToString();
                txt_PB_No_L.Text = ds.Tables[1].Rows[0]["PB_S"].ToString();
            }
            else
            {
                txtVoucherno.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void Load_Cus_Exp_Head_Name_Select()
    {
        try
        {
            ddl_Cus_Name.Items.Clear();
            ddl_Charge_head.Items.Clear();
            DataSet ds = new DataSet();
            ObjUBO.A19 = "Cus_Exp_Head_Name_Select";
            ds = BI.Purchase_Entry_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_Cus_Name.DataSource = ds.Tables[0];
                ddl_Cus_Name.DataTextField = "Cus_Name";
                ddl_Cus_Name.DataValueField = "Cus_Name";
                ddl_Cus_Name.DataBind();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                ddl_Charge_head.DataSource = ds.Tables[1];
                ddl_Charge_head.DataTextField = "CHARGE_NAME";
                ddl_Charge_head.DataValueField = "CHARGE_VALUE";
                ddl_Charge_head.DataBind();
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                ddl_Under_name.DataSource = ds.Tables[2];
                ddl_Under_name.DataTextField = "SUB_GROUP_NAME";
                ddl_Under_name.DataValueField = "SUB_GROUP_NAME";
                ddl_Under_name.DataBind();
            }

            ddl_Cus_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Cus_Name.SelectedIndex = 0;
            ddl_Charge_head.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Charge_head.SelectedIndex = 0;
            ddl_Under_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Under_name.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void ddlVendorname_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear();
        Load_VendorBranch();
    }
    private void Load_VendorBranch()
    {
        ddlVendorBranch.Items.Clear();
        if (ddlVendorname.SelectedValue.ToString() != string.Empty)
        {
            ObjUBO.A3 = ddlVendorname.SelectedValue.ToString();
            ObjUBO.A19 = "Vendor_Branch_Select";
            ds = BI.Purchase_Entry_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlVendorBranch.DataSource = ds.Tables[0];
                ddlVendorBranch.DataTextField = "Br_Name";
                ddlVendorBranch.DataValueField = "Br_Name";
                ddlVendorBranch.DataBind();
            }
        }
        ddlVendorBranch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlVendorBranch.SelectedIndex = 0;
    }
    protected void ddlVendorBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear();
        if (ddlVendorBranch.SelectedValue.ToString() != string.Empty)
        {
            DataSet ds = new DataSet();
            ObjUBO.A3 = ddlVendorname.SelectedValue.ToString();
            ObjUBO.A4 = ddlVendorBranch.SelectedValue.ToString();
            ObjUBO.A19 = "Vendor_Data_Select";
            ds = BI.Purchase_Entry_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtVendorstate.Text = ds.Tables[0].Rows[0]["BR_STATE"].ToString();
                txtGstn.Text = ds.Tables[0].Rows[0]["BR_GSTIN_NO"].ToString();
                txtGstntype.Text = ds.Tables[0].Rows[0]["BR_TAX_TYPE"].ToString();
                txtCountry.Text = ds.Tables[0].Rows[0]["BR_COUNTRY_NAME"].ToString();
                Rd_Bill_Type.SelectedValue = ds.Tables[0].Rows[0]["BILL_TYPE"].ToString();
            }
        }
    }
    private void Clear()
    {
        txtVendorstate.Text = string.Empty;
        txtGstn.Text = string.Empty;
        txtGstntype.Text = string.Empty;
        txtCountry.Text = string.Empty;
    }
    protected void btn_Save_Update_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtVoucherno.Text != string.Empty)
            {
                if (ddlVendorname.SelectedValue.ToString() != string.Empty)
                {
                    if (ddlVendorBranch.SelectedValue.ToString() != string.Empty)
                    {
                        if (txtTotalamtininr.Text != string.Empty)
                        {
                            if (Ven_Bill_No_Check() == "T")
                            {
                                if (btn_Save_Update.Text == "Save")
                                {
                                    ds = Purchase_Insert_Update("PS");
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        HDupdate_id.Value = ds.Tables[0].Rows[0]["V_ID"].ToString();
                                        btn_Save_Update.Text = "Update";
                                        Alert_msg("Saved Successfully!", "btn_Save_Update");
                                        E_Royal_Other_Jobs();
                                        Rd_Royal_Other.Enabled = false;
                                    }
                                    if (ds.Tables[1].Rows.Count > 0)
                                    {
                                        txt_D_C_bal_Amt.Text = ds.Tables[1].Rows[0][0].ToString();
                                    }
                                }
                                else if (btn_Save_Update.Text == "Update")
                                {
                                    ds = Purchase_Insert_Update("PU");
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
                                Alert_msg("Vendor Bill No Already Exists!", "txtVendorbillno");
                            }
                        }
                        else
                        {
                            Alert_msg("Enter Ur Bill Amount!", "txtbillamount");
                        }
                    }
                    else
                    {
                        Alert_msg("Select Ur Vendor Branch!", "ddlVendorBranch");
                    }
                }
                else
                {
                    Alert_msg("Select Ur VendorName!", "ddlVendorname");
                }
            }
            else
            {
                Alert_msg("Enter Ur VoucherNo!", "txtVoucherno");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public DataSet Purchase_Insert_Update(string S1)
    {
        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A2 = Rd_Bill_Type.SelectedValue.ToString();
        ObjUBO.A3 = txtVoucherno.Text;
        ObjUBO.A4 = txtVoucherdate.Text;
        ObjUBO.A5 = ddlVendorname.SelectedItem.ToString();
        ObjUBO.A6 = ddlVendorBranch.SelectedValue.ToString();
        ObjUBO.A7 = txtVendorstate.Text;
        ObjUBO.A8 = txtGstn.Text;
        ObjUBO.A9 = txtGstntype.Text;
        ObjUBO.A10 = txtCountry.Text;
        ObjUBO.A11 = txtVendorbillno.Text;
        ObjUBO.A12 = txtBilldate.Text;
        ObjUBO.A13 = txtbillamount.Text;
        ObjUBO.A14 = txtBill_Cur.Text;
        ObjUBO.A15 = txtExrate.Text;
        ObjUBO.A16 = txtTotalamtininr.Text;
        ObjUBO.A17 = txtNarration.Text;
        ObjUBO.A18 = Rd_Debit_Credit.SelectedValue.ToString();
        ObjUBO.A19 = ddlslno.SelectedValue.ToString();
        ObjUBO.A20 = HD_Ch_update_id.Value.ToString();
        ObjUBO.A21 = Rd_IMP_EXP.SelectedValue.ToString();
        //ObjUBO.A22 = ddljobno.SelectedValue.ToString();
        ObjUBO.A22 = ddljobno.SelectedItem.ToString();
        ObjUBO.A23 = txt_JobDate.Text;
        ObjUBO.A24 = ddl_Cus_Name.SelectedValue.ToString();
        ObjUBO.A25 = ddl_Charge_head.SelectedValue.ToString();
        ObjUBO.A26 = ddl_Tax_Rate.SelectedValue.ToString();
        ObjUBO.A27 = txt_Debit_Credit_Amt.Text;
        ObjUBO.A28 = txt_Tds_Rate.Text;

        ObjUBO.A29 = txt_CGST_Amt.Text;
        ObjUBO.A30 = txt_SGST_Amt.Text;
        ObjUBO.A31 = txt_IGST_Amt.Text;
        ObjUBO.A32 = txt_Tds_Amt.Text;

        ObjUBO.A33 = Rd_Royal_Other.SelectedValue.ToString();
        ObjUBO.A34 = lbl_Job_Company_Lic.Text;
        ObjUBO.A35 = lbl_Job_Wrk_Period.Text;

        ObjUBO.A36 = txt_Other_Jobno.Text;
        ObjUBO.A37 = ddl_Under_name.SelectedValue.ToString();
        ObjUBO.A38 = ddlgroup_Name.SelectedItem.ToString();
        ObjUBO.A39 = ddlgroup_Name.SelectedValue.ToString();
        ObjUBO.A40 = Rd_Reg_Sez.SelectedValue.ToString();
        ObjUBO.A41 = ddl_TDS.SelectedValue.ToString();

        ObjUBO.A42 = txt_Posting_Date.Text;

        ObjUBO.A43 = txt_PB_No_F.Text;
        ObjUBO.A44 = txt_PB_No_L.Text;

        ObjUBO.A49 = S1;
        ds = BI.Purchase_Entry_Ins_Upd(ObjUBO);
        return ds;
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        ddljobno.SelectedIndex = -1;
        int nextSlNo = gv_Ch.Rows.Count > 0 ? gv_Ch.Rows.Count + 1 : 1;
        ddlslno.SelectedValue = nextSlNo.ToString();
        txt_JobDate.Text = string.Empty;
        ddl_Cus_Name.SelectedIndex = -1;
        ddl_Charge_head.SelectedIndex = -1;
        ddl_Tax_Rate.SelectedIndex = -1;
        txt_Debit_Credit_Amt.Text = string.Empty;
        txt_Tds_Rate.Text = string.Empty;
        txt_CGST_Amt.Text = string.Empty;
        txt_SGST_Amt.Text = string.Empty;
        txt_IGST_Amt.Text = string.Empty;
        txt_Tds_Amt.Text = string.Empty;
        txt_Other_Jobno.Text = string.Empty;

        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;
        btnUpdate.CssClass = "updates";

        ViewState["UPDATED_ID"] = null;
        HD_Ch_update_id.Value = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_Other_Jobno.Text != string.Empty)
            {
                if (ddl_Cus_Name.SelectedValue.ToString() != string.Empty)
                {
                    if (ddl_Charge_head.SelectedValue.ToString() != string.Empty)
                    {
                        if (txt_Debit_Credit_Amt.Text != string.Empty)
                        {
                            if (Bill_Amt_Val("Bill_Amt_S_Chk") == "T")
                            {
                                ds = Purchase_Insert_Update("PCS");
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    HD_Ch_update_id.Value = ds.Tables[0].Rows[0]["PC_ID"].ToString();

                                    ViewState["UPDATED_ID"] = null;
                                    Alert_msg("Purchase Entry Saved Successfully", "btnSave");
                                    btnNew_Click(sender, e);
                                }
                                else
                                {
                                    Alert_msg("Purchase Not Saved", "btnSave");
                                }


                                if (ds.Tables[1].Rows.Count > 0)
                                {
                                    gv_Ch.DataSource = ds.Tables[1];
                                    gv_Ch.DataBind();
                                    int nextSlNo = gv_Ch.Rows.Count > 0 ? gv_Ch.Rows.Count + 1 : 1;
                                    ddlslno.SelectedValue = nextSlNo.ToString();
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
                    Alert_msg("Select Ur Customer Name !", "ddl_Cus_Name");
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_Other_Jobno.Text != string.Empty)
            {
                if (ddl_Cus_Name.SelectedValue.ToString() != string.Empty)
                {
                    if (ddl_Charge_head.SelectedValue.ToString() != string.Empty)
                    {
                        if (txt_Debit_Credit_Amt.Text != string.Empty)
                        {
                            if (Bill_Amt_Val("Bill_Amt_U_Chk") == "T")
                            {
                                ds = Purchase_Insert_Update("PCU");
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    HD_Ch_update_id.Value = ds.Tables[0].Rows[0]["PC_ID"].ToString();

                                    ViewState["UPDATED_ID"] = null;
                                    Alert_msg("Purchase Entry Updated Successfully", "btnUpdate");
                                }
                                else
                                {
                                    Alert_msg("Purchase Not Updated", "btnUpdate");
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
                    Alert_msg("Select Ur Customer Name !", "ddl_Cus_Name");
                }
            }
            else
            {
                Alert_msg("Invalid Jobno !", "ddljobno");
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
            ds = Purchase_Insert_Update("PCD");
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
            if (ds.Tables[0].Rows.Count == 0)
            {
                ViewState["UPDATED_ID"] = null;
                btnNew_Click(sender, e);
                Alert_msg("Purchase Entry Deleted");
            }
            else
            {
                Alert_msg("Purchase Not Deleted", "btnDelete");
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
        ViewState["PC_ID"] = Convert.ToString(this.gv_Ch.SelectedDataKey.Value);

        if (ViewState["PC_ID"] != "" && ViewState["PC_ID"] != null)
        {
            ViewState["UPDATED_ID"] = null;
            ViewState["UPDATED_ID"] = ViewState["PC_ID"].ToString();
            btnUpdate.CssClass = "updates";
            //---------------------------------------------
            ddlslno.SelectedValue = gv_Ch.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            Rd_IMP_EXP.SelectedValue = gv_Ch.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            ddlgroup_Name.SelectedValue = gv_Ch.DataKeys[gv_Ch.SelectedRow.RowIndex].Values["GROUP_ID"].ToString();

            load_Jobno();
            //ddljobno.SelectedValue = gv_Ch.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            if (Rd_Royal_Other.SelectedValue == "R")
            {
                ddljobno.SelectedValue = gv_Ch.DataKeys[gv_Ch.SelectedRow.RowIndex].Values["JOBNO_PS"].ToString();
            }
            else
            {
                txt_Other_Jobno.Text = gv_Ch.DataKeys[gv_Ch.SelectedRow.RowIndex].Values["JOBNO_PS"].ToString();
            }
            
            txt_JobDate.Text = gv_Ch.SelectedRow.Cells[4].Text.Replace("01/01/1900", "");
            ddl_Cus_Name.SelectedValue = System.Net.WebUtility.HtmlDecode(gv_Ch.SelectedRow.Cells[5].Text); 
            ddl_Charge_head.SelectedValue = gv_Ch.SelectedRow.Cells[6].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
            ddl_TDS.SelectedValue = gv_Ch.SelectedRow.Cells[7].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
            ddl_Tax_Rate.SelectedValue = gv_Ch.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");

            txt_Debit_Credit_Amt.Text = gv_Ch.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
            txt_CGST_Amt.Text = gv_Ch.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
            txt_SGST_Amt.Text = gv_Ch.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
            txt_IGST_Amt.Text = gv_Ch.SelectedRow.Cells[12].Text.Replace("&nbsp;", "");
            txt_Tds_Rate.Text = gv_Ch.SelectedRow.Cells[13].Text.Replace("&nbsp;", "");
            txt_Tds_Amt.Text = gv_Ch.SelectedRow.Cells[14].Text.Replace("&nbsp;", "");

            txt_Other_Jobno.Text = gv_Ch.DataKeys[gv_Ch.SelectedRow.RowIndex].Values["JOBNO_PS"].ToString();

            HD_Ch_update_id.Value = ViewState["PC_ID"].ToString();
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
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Purchase Entry', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Purchase Entry', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void ddljobno_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            ddl_Cus_Name.SelectedIndex = -1;
            txt_JobDate.Text = string.Empty;
            txt_Other_Jobno.Text = string.Empty;

            if (ddljobno.SelectedValue.ToString() != string.Empty)
            {
                ObjUBO.A5 = Rd_IMP_EXP.SelectedValue.ToString();
                //ObjUBO.A2 = ddljobno.SelectedValue.ToString();
                ObjUBO.A2 = ddljobno.SelectedItem.ToString();
                ObjUBO.A18 = ddlgroup_Name.SelectedValue.ToString();
                ObjUBO.A19 = "Jobno_Data_Select";
                ds = BI.Purchase_Entry_Select(ObjUBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txt_JobDate.Text = ds.Tables[0].Rows[0]["JOBDATE"].ToString();
                    ddl_Cus_Name.SelectedValue = ds.Tables[0].Rows[0]["Cus_Name"].ToString();
                }
                //txt_Other_Jobno.Text = ddljobno.SelectedItem.ToString();
                txt_Other_Jobno.Text = ddljobno.SelectedValue.ToString();
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void Rd_IMP_EXP_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Jobno();
        txt_JobDate.Text = string.Empty;
        ddl_Cus_Name.SelectedIndex = -1;
    }
    private void load_Jobno()
    {
        DataSet ds = new DataSet();
        ObjUBO.A5 = Rd_IMP_EXP.SelectedValue.ToString();
        ObjUBO.A18 = ddlgroup_Name.SelectedValue.ToString();
        ObjUBO.A19 = "Jobno_Select";
        ds = BI.Purchase_Entry_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddljobno.DataSource = ds.Tables[0];
            /*ddljobno.DataTextField = "JOBNO_PS";
             ddljobno.DataValueField = "JOBNO";*/
            ddljobno.DataTextField = "JOBNO";
            ddljobno.DataValueField = "JOBNO_PS";
            ddljobno.DataBind();
        }
        ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddljobno.SelectedIndex = 0;
    }
    private string Bill_Amt_Val(string flg)
    {
        string Val = string.Empty;
        DataSet ds = new DataSet();
        ObjUBO.A6 = txt_Debit_Credit_Amt.Text;
        ObjUBO.A7 = txt_CGST_Amt.Text;
        ObjUBO.A8 = txt_SGST_Amt.Text;
        ObjUBO.A9 = txt_IGST_Amt.Text;
        ObjUBO.A10 = txt_Tds_Amt.Text;

        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A2 = txtVoucherno.Text;

        ObjUBO.A12 = HD_Ch_update_id.Value.ToString();

        ObjUBO.A19 = flg;
        ds = BI.Purchase_Entry_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Val = ds.Tables[0].Rows[0][0].ToString();
        }
        return Val;
    }
    private string Ven_Bill_No_Check()
    {
        string Val = "T";
        DataSet ds = new DataSet();

        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A2 = txtVoucherno.Text;
        ObjUBO.A3 = ddlVendorname.SelectedValue;
        ObjUBO.A5 = btn_Save_Update.Text;
        ObjUBO.A4 = txtVendorbillno.Text;
        ObjUBO.A19 = "Ven_Bill_No_Aval";
        ds = BI.Purchase_Entry_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Val = "F";
        }
        return Val;
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


    protected void gv_Ch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Ch.PageIndex = e.NewPageIndex;
        Load_Grid();
    }
    private void Load_Grid()
    {
        ObjUBO.A2 = txtVoucherno.Text;
        ObjUBO.A19 = "Purchase_Charge_Select";
        ds = BI.Purchase_Entry_Select(ObjUBO);
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

    private void Load_Group_Name()
    {
        ddlgroup_Name.Items.Clear();
        if (Session["ClientGrpMst"] != null)
        {
            DataSet ds = (DataSet)Session["ClientGrpMst"];
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlgroup_Name.DataSource = ds.Tables[0];
                ddlgroup_Name.DataTextField = "GROUP_NAME";
                ddlgroup_Name.DataValueField = "GROUP_ID";
                ddlgroup_Name.DataBind();
            }
        }
        /*
        ddlgroup_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlgroup_Name.SelectedIndex = 0;
         */
    }

    protected void ddlgroup_Name_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Jobno();
        txt_JobDate.Text = string.Empty;
        ddl_Cus_Name.SelectedIndex = -1;
    }

    protected void btn_Pu_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtVoucherno.Text != string.Empty)
            {
                ds = Purchase_Insert_Update("Pur_Delete");
                if (ds.Tables[0].Rows.Count == 0)
                {
                    btn_Save_Update.Text = "Save";
                    Alert_msg("Deleted Successfully!", "btn_Pu_Delete_Click");
                    /*
                    btnExpHead_Delete.Visible = false;
                    btnExpHead_New.Visible = false;
                    btnExpHead_Save.Visible = false;
                    btnExpHead_Update.Visible = false;
                    */
                    btn_Pu_Delete.Visible = false;
                    txtbillamount.Text = string.Empty;
                    txtTotalamtininr.Text = string.Empty;
                    //---------------------------------------------------------
                    Load_VendorName();
                    btnSave.Text = "Save";
                    //--------------------------------------------------
                    gv_Ch.DataSource = dt;
                    gv_Ch.DataBind();
                }
                else
                {
                    Alert_msg("Not Deleted", "btn_Pu_Delete");
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

  

    [System.Web.Services.WebMethod]
    public static string Get_Tds_Rate(string Charge, string Tax)
    {
        Purchase_cs BI = new Purchase_cs();
        DataSet ds = new DataSet();
        Global_variables ObjUBO = new Global_variables();
        ObjUBO.A11 = Charge;
        ObjUBO.A12 = Tax;
        ObjUBO.A19 = "Tds_Rate_Select";
        ds = BI.Purchase_Entry_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {

            Tax = ds.Tables[0].Rows[0][0].ToString();

        }
        else
        {
            Tax = "";
        }
        return Tax;

    }
}