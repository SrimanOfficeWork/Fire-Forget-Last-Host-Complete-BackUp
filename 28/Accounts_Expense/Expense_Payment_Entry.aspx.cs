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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Globalization;
using System.Text.RegularExpressions;

public partial class Expense_Payment_Entry : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();
    
    Expense_Entry_cs BI = new Expense_Entry_cs();
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
            btnJob_New.Visible = false;
            btnJob_Save.Visible = false;
            btnJob_Update.Visible = false;
            btnJob_Delete.Visible = false;
            btnDelete.Visible = false;
            Exp_Leg();
            if (Request.QueryString["Page"] == null || Request.QueryString["Page"]=="")
            {
                btnExpHead_Delete.Visible = false;
                btnExpHead_New.Visible = false;
                btnExpHead_Save.Visible = false;
                btnExpHead_Update.Visible = false;

                lbl_Job_Company_Lic.Text = Connection.Company_License().ToUpper();
                lbl_Job_Wrk_Period.Text = Connection.WorkingPeriod();

                LoadCustomer();
                Load_ExpVoucherNo();
                btnsup.Text = "Save";
                //--------------------------------------------------

                gv.DataSource = dt;
                gv.DataBind();

                gv_ExpHead.DataSource = dt;
                gv_ExpHead.DataBind();

                txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy"); 
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    btnsup.Text = "Update";
                    //--------------------------------------------------
                    Update_Item_Load();
                    Rd_Royal_Other.Enabled = false;
                    btnDelete.Visible = true;

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
        ObjUBO.A60 = "Exp_Leg_Select";
        ds = BI.Select_Expense(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_Expense_Charges.DataSource = ds.Tables[0];
            ddl_Expense_Charges.DataTextField = "CHARGE_NAME";
            ddl_Expense_Charges.DataValueField = "CHARGE_NAME";
            ddl_Expense_Charges.DataBind();
        }
        ddl_Expense_Charges.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
        ddl_Expense_Charges.SelectedIndex = 0;
    }
    private void Load_ExpVoucherNo()
    {
        DataSet ds = new DataSet();
        try
        {
            txtExpVoucherNo.Text = string.Empty;
            ObjUBO.A60 = "ExpVoucherNo_Select";
            ds = BI.Select_Expense(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtExpVoucherNo.Text = ds.Tables[0].Rows[0][0].ToString();
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
            ddlCustomer.Items.Clear();
            DataSet dss = new DataSet();
            ObjUBO.A60 = "Expense_Updated_Select";
            ObjUBO.A1 = Request.QueryString["Page"].ToString();
            dss = BI.Select_Expense(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = dss.Tables[0].Rows[0]["EXP_ID"].ToString();
                ddlCustomer.Items.Insert(0, new System.Web.UI.WebControls.ListItem(dss.Tables[0].Rows[0]["CUSTOMER_NAME"].ToString(), dss.Tables[0].Rows[0]["CUSTOMER_NAME"].ToString()));
                ddlCustomer.SelectedIndex = 0;

                txtExpVoucherNo.Text = dss.Tables[0].Rows[0]["VOUCHER_REFNO"].ToString();
                txtDate.Text = dss.Tables[0].Rows[0]["EXP_DATE"].ToString();
                txtRefVoucherNo.Text = dss.Tables[0].Rows[0]["REFNO"].ToString();
                txtTotalExpAmt.Text = dss.Tables[0].Rows[0]["TOTALAMOUNT"].ToString();

                ddlstaff_Name.Items.Insert(0, new System.Web.UI.WebControls.ListItem(dss.Tables[0].Rows[0]["STAFFNAME"].ToString(), dss.Tables[0].Rows[0]["STAFFNAME"].ToString()));
                ddlstaff_Name.SelectedIndex = 0;

                txtGivenBy.Text = dss.Tables[0].Rows[0]["GIVENBY"].ToString();
                txtRemarks.Text = dss.Tables[0].Rows[0]["NARRATION"].ToString();
                Rd_Royal_Other.SelectedValue = dss.Tables[0].Rows[0]["JOB_TYPE"].ToString();

                lbl_Job_Company_Lic.Text = dss.Tables[0].Rows[0]["JOB_LICENSE"].ToString();
                lbl_Job_Wrk_Period.Text = dss.Tables[0].Rows[0]["JOB_WORKINGPERIOD"].ToString();

                ddlCustomer.Style.Add("background-color", "#E7E6E6");
                ddlCustomer.Enabled = false;
                ddlstaff_Name.Style.Add("background-color", "#E7E6E6");
                ddlstaff_Name.Enabled = false;
            }
            if (dss.Tables[1].Rows.Count > 0)
            {
                gv_ExpHead.DataSource = dss.Tables[1];
            }
            else
            {
                gv_ExpHead.DataSource = dt;
            }
            gv_ExpHead.DataBind();

            if (dss.Tables[2].Rows.Count > 0)
            {
                txtRegn_Sl_No.Text = dss.Tables[2].Rows[0]["LINE_NO"].ToString();
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
    private void LoadCustomer()
    {
        DataSet ds = new DataSet();
        ObjUBO.A60 = "Party_Name_Select";
        ds = BI.Select_Expense(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlCustomer.DataSource = ds.Tables[0];
            ddlCustomer.DataTextField = "CustomerName";
            ddlCustomer.DataValueField = "CustomerName";
            ddlCustomer.DataBind();
        }
        ddlCustomer.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
        ddlCustomer.SelectedIndex = 0;

        if (ds.Tables[1].Rows.Count > 0)
        {
            ddlstaff_Name.DataSource = ds.Tables[1];
            ddlstaff_Name.DataTextField = "STAFF_NAME";
            ddlstaff_Name.DataValueField = "STAFF_NAME";
            ddlstaff_Name.DataBind();
        }
        ddlstaff_Name.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
        ddlstaff_Name.SelectedIndex = 0;

        ds.Dispose();
        GC.Collect();
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Expenses Entry', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Expenses Entry', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
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
        if (txtRegn_Sl_No.Text != string.Empty)
        {
            if (ddl_Expense_Charges.SelectedValue.ToString() != string.Empty)
            {
                if (txtTotSubExpAmt.Text != string.Empty)
                {
                        ds = Expense_Ch_Ins_Upd("SC", HDupdate_id.Value.ToString(), "");
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
                            txtTotalExpAmt.Text = ds.Tables[1].Rows[0][0].ToString();
                        }
                        else
                        {
                            txtTotalExpAmt.Text = "0";
                        }
                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            gv_ExpHead.DataSource = ds.Tables[2];
                        }
                        else
                        {
                            gv_ExpHead.DataSource = dt;
                        }
                        gv_ExpHead.DataBind();

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
        else
        {
            Alert_msg("Enter Ur Sl.No!", "txtRegn_Sl_No");
        }
           
    }
    protected void btnExpHead_Update_Click(object sender, EventArgs e)
    {
        if (txtRegn_Sl_No.Text != string.Empty)
        {
            if (ddl_Expense_Charges.SelectedValue.ToString() != string.Empty)
            {
                if (txtTotSubExpAmt.Text != string.Empty)
                {
                    ds = Expense_Ch_Ins_Upd("UC", HDupdate_id.Value.ToString(), HDupdate_Ch_id.Value.ToString());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        HDupdate_Ch_id.Value = Convert.ToString(HDupdate_Ch_id.Value.ToString());
                        btnExpHead_Save.Visible = false;
                        btnExpHead_Update.Visible = true;
                        Alert_msg("Updated Successfully!", "btnExpHead_Update");

                        gv_ExpHead.DataSource = ds.Tables[0];
                        gv_ExpHead.DataBind();
                    }
                    else
                    {
                        btnExpHead_Save.Visible = false;
                        btnExpHead_Update.Visible = true;
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        txtTotalExpAmt.Text = ds.Tables[1].Rows[0][0].ToString();
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
        else
        {
            Alert_msg("Enter Ur Sl.No!", "txtRegn_Sl_No");
        }
    }
    public DataSet Expense_Ch_Ins_Upd(string flg,string Exp_id , string Ch_id)
    {
        ObjUBO.A1 = Exp_id;
        ObjUBO.A2 = Ch_id;
        ObjUBO.A4 = Rd_Imp_Exp.SelectedValue.ToString();
        ObjUBO.A59 = txt_Exp_Date.Text;
        ObjUBO.A7 = ddlTr_Mode.SelectedValue.ToString(); 

        ObjUBO.A9 = txtExpVoucherNo.Text;
        ObjUBO.A16 = txtRegn_Sl_No.Text;
        ObjUBO.A17 = ddl_Expense_Charges.SelectedValue.ToString();
        ObjUBO.A18 = txtTotSubExpAmt.Text;
        ObjUBO.A60 = flg;
        return BI.Expense_Ch_Ins_Upd(ObjUBO);
    }
    protected void btnExpHead_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds1 = new DataSet();
            ObjUBO.A1 = HDupdate_id.Value.ToString();
            ObjUBO.A5 = txtExpVoucherNo.Text;
            ObjUBO.A2 = HDupdate_Ch_id.Value.ToString();
            ObjUBO.A6 = HDupdate_Imp_Exp.Value.ToString();
            ObjUBO.A60 = "Expense_Charge_Delete";
            ds1 = BI.Select_Expense(ObjUBO);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                Alert_msg("Job Not Deleted");
            }
            else
            {
                btnJob_New_Click(sender, e);
                Alert_msg("Job Deleted");
            }
            gv_ExpHead.DataSource = ds1.Tables[1];
            gv_ExpHead.DataBind();
            btnExpHead_Delete.Visible = false;
            btnExpHead_Update.Visible = false;
            btnExpHead_Save.Visible = true;

            ddl_Expense_Charges.SelectedIndex = -1;
            txtTotSubExpAmt.Text = "";
            lbl_Exp_Amt.Text = "";
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
        lbl_Exp_Amt.Text = "";
        lbljob_total_amt.Text = "";
        txt_Other_Jobno.Text = "";
        GetAuto_LineNo();

        btnJob_Delete_All.Visible = false;
        ddl_Jobno.Items.Clear();
        gv.DataSource = dt;
        gv.DataBind();
    }
    private void GetAuto_LineNo()
    {

        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A5 = txtExpVoucherNo.Text;
        ObjUBO.A60 = "Expense_AutoLineNo_Select";
        ds = BI.Select_Expense(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            txtRegn_Sl_No.Text = ds.Tables[0].Rows[0]["LINE_NO"].ToString();
        }
        else
        {
            txtRegn_Sl_No.Text = "";
        }
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

                if (DataBinder.Eval(e.Row.DataItem, "flg").ToString() == "F")
                {
                    e.Row.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    e.Row.ForeColor = System.Drawing.Color.Green;
                }
                e.Row.Font.Bold = true;
        }
    }
    protected void gv_ExpHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnJob_Delete.Visible = false;
        btnJob_Save.Visible = true;
        btnJob_New.Visible = true;
        btnJob_Update.Visible = false;
        lbl_Error_Msg.Text = string.Empty;
        ViewState["CH_ID"] = Convert.ToString(this.gv_ExpHead.SelectedDataKey.Value);

        if (ViewState["CH_ID"] != "" && ViewState["CH_ID"] != null)
        {
            HDupdate_Ch_id.Value = ViewState["CH_ID"].ToString();
            HDupdate_id.Value = gv_ExpHead.DataKeys[gv_ExpHead.SelectedRow.RowIndex].Values[1].ToString();

            btnExpHead_Update.CssClass = "updates";
            btnExpHead_Delete.Visible = true;
            btnExpHead_Update.Visible = true;
            btnExpHead_Save.Visible = false;

            txtRegn_Sl_No.Text = gv_ExpHead.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            Rd_Imp_Exp.SelectedValue = gv_ExpHead.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            ddlTr_Mode.SelectedValue = gv_ExpHead.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            txtTotSubExpAmt.Text = gv_ExpHead.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");

            ddl_Expense_Charges.SelectedValue = gv_ExpHead.SelectedRow.Cells[7].Text.Replace("&amp;", "&");
            txt_Exp_Date.Text = gv_ExpHead.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
            ddl_Job_Imp_Exp.SelectedValue = gv_ExpHead.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            HDupdate_Imp_Exp.Value = Rd_Imp_Exp.SelectedValue.ToString();
            HDupdate_Tr_Mode.Value = ddlTr_Mode.SelectedValue.ToString();
            
            HDupdate_Line_Id.Value = txtRegn_Sl_No.Text;
            //-----------------------------------------------------------------------------------------------------------
            //Panel1.Enabled = true;

            lblcharge.Text = ddl_Expense_Charges.SelectedValue.ToString();
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
    private void load_Jobs()
    {
        ddl_Jobno.Items.Clear();
        txt_Exp_Job_Amt.Text = "";
        //txt_Job_Remarks.Text = "";
        ddl_Jobno.Enabled = true;

            ObjUBO.A1 = HDupdate_id.Value.ToString();
            ObjUBO.A5 = txtExpVoucherNo.Text;
            ObjUBO.A2 = HDupdate_Ch_id.Value.ToString();
            ObjUBO.A6 = HDupdate_Imp_Exp.Value.ToString();
            ObjUBO.A7 = HDupdate_Tr_Mode.Value.ToString();
            ObjUBO.A3 = ddlCustomer.SelectedValue.ToString();
            ObjUBO.A60 = "Expense_Jobno_Select";
            ds = BI.Select_Expense(ObjUBO);

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
            btnExpHead_Delete.Visible =true;
        }
        if (ds.Tables[2].Rows.Count > 0)
        {
            lbljob_total_amt.Text=ds.Tables[2].Rows[0]["Job_Tot"].ToString();
        }
        
    }
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
    }
    
    protected void btnsup_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlCustomer.SelectedValue.ToString() != string.Empty)
            {
                if (txtExpVoucherNo.Text != string.Empty)
                {
                    if (txtDate.Text != string.Empty)
                    {
                        ds = Expense_Ins_Upd(btnsup.Text);
                        if (btnsup.Text=="Save")
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                HDupdate_id.Value = Convert.ToString(BI.UPDATE_ID);
                                btnsup.Text = "Update";
                                Alert_msg("Saved Successfully!", "btnsup");
                                GetAuto_LineNo();

                                btnExpHead_Delete.Visible = false;
                                btnExpHead_New.Visible = true;
                                btnExpHead_Save.Visible = true;
                                btnExpHead_Update.Visible = false;
                                Rd_Royal_Other.Enabled = false;
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
                            }
                            else
                            {
                                Alert_msg("Not Updated", "btnsup");
                            }
                        }
                    }
                    else
                    {
                        Alert_msg("Enter Ur Date!", "txtDate");
                    }
                }
                else
                {
                    Alert_msg("Enter Ur VoucherNo!", "txtExpVoucherNo");
                }
            }
            else
            {
                Alert_msg("Select Ur Customer Name!", "ddlCustomer");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public DataSet Expense_Ins_Upd(string flg)
    {
        ObjUBO.A22 = Rd_Royal_Other.SelectedValue.ToString();
        ObjUBO.A23 = lbl_Job_Company_Lic.Text;
        ObjUBO.A24 = lbl_Job_Wrk_Period.Text;

        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A8 = ddlCustomer.SelectedValue.ToString();
        ObjUBO.A9 = txtExpVoucherNo.Text;
        ObjUBO.A10 = txtDate.Text;
        ObjUBO.A11 = txtRefVoucherNo.Text;
        ObjUBO.A12 = ddlstaff_Name.SelectedValue.ToString();
        ObjUBO.A13 = txtGivenBy.Text;
        ObjUBO.A14 = txtRemarks.Text;
       // ObjUBO.A9 = "0";
        ObjUBO.A16 = txtRegn_Sl_No.Text;
        ObjUBO.A17 = ddl_Expense_Charges.SelectedValue.ToString();
        ObjUBO.A18 = txtTotSubExpAmt.Text;
        ObjUBO.A60 = flg;

        return BI.Expense_Ch_Ins_Upd(ObjUBO);
    }
    protected void ddl_Jobno_SelectedIndexChanged(object sender, EventArgs e)
    {
        txt_Exp_Job_Amt.Text = string.Empty;
        //txt_Job_Remarks.Text = string.Empty;

        if (ddl_Jobno.SelectedValue.ToString() != string.Empty)
        {
            btnJob_Save.Visible = true;
            btnJob_Update.Visible = false;
            btnJob_Delete.Visible = false;
            load_Job_Data();
        }
        else
        {
            
            btnJob_Save.Visible = false;
            btnJob_Update.Visible = true;
            btnJob_Delete.Visible = true;
        }
    }
    private void load_Job_Data()
    {
        txt_Other_Jobno.Text = string.Empty;
        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A5 = txtExpVoucherNo.Text;
        ObjUBO.A2 = HDupdate_Ch_id.Value.ToString();
        ObjUBO.A6 = HDupdate_Imp_Exp.Value.ToString();

        ObjUBO.A7 = HDupdate_Tr_Mode.Value.ToString();
        ObjUBO.A3 = ddlCustomer.SelectedValue.ToString();
        ObjUBO.A8 = ddl_Jobno.SelectedItem.ToString(); 
        ObjUBO.A10 = ddl_Jobno.SelectedValue.ToString();
        ObjUBO.A60 = "Expense_Job_data_Select";
        ds = BI.Select_Expense(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            txt_Other_Jobno.Text = ddl_Jobno.SelectedItem.ToString();
        }
        else
        {
            gv.DataSource = dt;
            gv.DataBind();
        }
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
    }
    protected void btnJob_Save_Click(object sender, EventArgs e)
    {
        lbl_Error_Msg.Text = string.Empty;
        if (txt_Exp_Job_Amt.Text != string.Empty)
        {
            if (Validtion_Exp_Amt() == "0")
            {
                ds = Expense_Ch_Job_Ins_Upd("SJ", HDupdate_id.Value.ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    HDupdate_Job_Id.Value = Convert.ToString(ds.Tables[0].Rows[0]["Job_Id"].ToString());
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
                if (ds.Tables[2].Rows.Count > 0)
                {
                    gv_ExpHead.DataSource = ds.Tables[2];
                    gv_ExpHead.DataBind();
                }
                else
                {
                    gv_ExpHead.DataSource = dt;
                    gv_ExpHead.DataBind();
                }
            }
            else
            {
                Alert_msg("All Job(s) Amount higher then Expense Amount !", "txt_Exp_Job_Amt");
            }
        }
        else
        {
            Alert_msg("Enter Ur Expense Amount !", "txt_Exp_Job_Amt");
        }
    }
    public DataSet Expense_Ch_Job_Ins_Upd(string flg, string Exp_id)
    {
        ObjUBO.A1 = HDupdate_id.Value.ToString(); 
        ObjUBO.A2 = HDupdate_Ch_id.Value.ToString();
        ObjUBO.A3 = HDupdate_Job_Id.Value.ToString();
        ObjUBO.A4 = HDupdate_Imp_Exp.Value.ToString();
        ObjUBO.A9 = txtExpVoucherNo.Text;
        ObjUBO.A16 = HDupdate_Line_Id.Value.ToString();
        ObjUBO.A19 = ddl_Jobno.SelectedItem.ToString();
        ObjUBO.A20 = ddl_Jobno.SelectedValue.ToString();
        ObjUBO.A25 = txt_Exp_Job_Amt.Text;
        ObjUBO.A60 = flg;
        return BI.Expense_Ch_Ins_Upd(ObjUBO);
    }
    protected void btnJob_Update_Click(object sender, EventArgs e)
    {
        lbl_Error_Msg.Text = string.Empty;
        if (txt_Exp_Job_Amt.Text != string.Empty)
        {
            if (Validtion_Exp_Amt() == "0")
            {
                ds = Expense_Ch_Job_Ins_Upd("UJ", HDupdate_id.Value.ToString());
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

                if (ds.Tables[2].Rows.Count > 0)
                {
                    gv_ExpHead.DataSource = ds.Tables[2];
                    gv_ExpHead.DataBind();
                }
                else
                {
                    gv_ExpHead.DataSource = dt;
                    gv_ExpHead.DataBind();
                }
            }
            else
            {
                lbl_Error_Msg.Text="Not Updated all Job(s) Amount higher then Expense Amount";
                Alert_msg("All Job(s) Amount higher then Expense Amount !", "txt_Exp_Job_Amt");
            }
        }
        else
        {
            Alert_msg("Enter Ur Expense Amount !", "txt_Exp_Job_Amt");
        }
    }
    protected void btnJob_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            ObjUBO.A1 = HDupdate_id.Value.ToString();
            ObjUBO.A5 = txtExpVoucherNo.Text;
            ObjUBO.A2 = HDupdate_Ch_id.Value.ToString();
            ObjUBO.A4 = HDupdate_Job_Id.Value.ToString();
            ObjUBO.A6 = HDupdate_Imp_Exp.Value.ToString();
            ObjUBO.A7 = HDupdate_Tr_Mode.Value.ToString();
            ObjUBO.A3 = ddlCustomer.SelectedValue.ToString();
            ObjUBO.A8 = ddl_Jobno.SelectedValue.ToString();
            ObjUBO.A60 = "Expense_Job_data_Delete";
            ds = BI.Select_Expense(ObjUBO);
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
            if (ds.Tables[0].Rows.Count > 0)
            {
                Alert_msg("Job Not Deleted");
            }
            else
            {
                HDupdate_Job_Id.Value = "";
                btnJob_New_Click(sender, e);
                Alert_msg("Job Deleted");
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
            ObjUBO.A5 = txtExpVoucherNo.Text;
            ObjUBO.A2 = HDupdate_Ch_id.Value.ToString();
            ObjUBO.A6 = HDupdate_Imp_Exp.Value.ToString();
            
            ObjUBO.A7 = HDupdate_Tr_Mode.Value.ToString();
            ObjUBO.A3 = ddlCustomer.SelectedValue.ToString();
            ObjUBO.A8 = ddl_Jobno.SelectedValue.ToString();
            ObjUBO.A60 = "Expense_Job_All_data_Delete";
            ds = BI.Select_Expense(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Alert_msg("Job Not Deleted");
            }
            else
            {
                btnJob_New_Click(sender, e);
                btnExpHead_New_Click(sender, e);
                load_gv_ExpHead_Grid();
                Alert_msg(" All Job(s) Deleted");
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

            ddl_Jobno.Items.Insert(0, new System.Web.UI.WebControls.ListItem(JOBNO, JOBNO_PS)); 
            ddl_Jobno.SelectedIndex = 0;
            txt_Other_Jobno.Text = JOBNO_PS;

            txt_Exp_Job_Amt.Text = gv.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");

            btnJob_New.Visible = true;
            btnJob_Save.Visible = false;
            btnJob_Update.Visible = true;
            btnJob_Delete.Visible = true;
            ddl_Jobno.Enabled = false;
        }
    }

    private string Validtion_Exp_Amt()
    { 
       string val="";
       ObjUBO.A1 = HDupdate_id.Value.ToString();
       ObjUBO.A5 = txtExpVoucherNo.Text;
       ObjUBO.A2 = HDupdate_Ch_id.Value.ToString();
       ObjUBO.A4 = HDupdate_Job_Id.Value.ToString();
       ObjUBO.A6 = HDupdate_Imp_Exp.Value.ToString();
       ObjUBO.A8 = ddl_Jobno.SelectedValue.ToString();
       ObjUBO.A9 = txt_Exp_Job_Amt.Text;
       ObjUBO.A60 = "Expense_Job_Amt_Validation";
       ds = BI.Select_Expense(ObjUBO);
       if (ds.Tables[0].Rows.Count > 0)
       {
           val = ds.Tables[0].Rows[0]["val"].ToString();
       }
       return val;
    }

    private void load_gv_ExpHead_Grid()
    {
        DataSet dss = new DataSet();
        ObjUBO.A60 = "Expense_Charge_Grid_Select";
        ObjUBO.A1 = HDupdate_id.Value.ToString();
        dss = BI.Select_Expense(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            gv_ExpHead.DataSource = dss.Tables[0];
        }
        else
        {
            gv_ExpHead.DataSource = dt;
        }
        gv_ExpHead.DataBind();
    }
    protected void Rd_Royal_Other_SelectedIndexChanged(object sender, EventArgs e)
    {
        E_Royal_Other_Jobs();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjUBO.A1 = HDupdate_id.Value.ToString();
            ObjUBO.A5 = txtExpVoucherNo.Text;
            ObjUBO.A2 = HDupdate_Ch_id.Value.ToString();
            ObjUBO.A6 = HDupdate_Imp_Exp.Value.ToString();
            ObjUBO.A60 = "Expense_Delete";
            ds = BI.Select_Expense(ObjUBO);
            if (ds.Tables[0].Rows.Count == 0)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('Expense Deleted', 'Expense', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
                
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

    [System.Web.Services.WebMethod]
    public static string Getload_Job_Data(string custid, string Imp_Exp, string ddl_job)
    {
        Global_variables ObjUBO = new Global_variables();
        DataSet ds = new DataSet();
        Expense_Entry_cs EX = new Expense_Entry_cs();
        if (custid != string.Empty)
        {
            ObjUBO.A6 = Imp_Exp;
            ObjUBO.A8 = ddl_job;
            ObjUBO.A60 = "Client_Name_Select";
            ds = EX.Select_Expense(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                custid = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                custid = string.Empty;
            }
        }
        return custid;
    }
}