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

public partial class Acc_Imp_Exp_Charges : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    Cha_Accounts Chrg = new Cha_Accounts();

    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    public string JOBNO, JOBNO_PS;
    public int i;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        try
        {
            string mode = Request.QueryString["I_E"];

            if (mode == "I")
            {
                /*
                txt_jobno.Text = Request.QueryString["JOBNO"].ToString();
                JOBNO = txt_jobno.Text;
                */
                JOBNO = Connection.IMP_Jobno();
                JOBNO_PS = Session["JOBNO_PS"].ToString();

                ddl_Cost_Center.SelectedValue = "I";

                ddl_Cost_Center.Items.Insert(0, new ListItem("Import", "I"));
                ddl_Cost_Center.SelectedIndex = 0;
            }
            else if (mode == "E")
            {   /*
                txt_jobno.Text = Request.QueryString["JOBNO"].ToString();
                JOBNO = txt_jobno.Text;
                */
                JOBNO = Connection.EXP_Jobno();
                JOBNO_PS = Session["JOBNO_PS"].ToString();
                ddl_Cost_Center.SelectedValue = "E";

                ddl_Cost_Center.Items.Insert(0, new ListItem("Export", "E"));
                ddl_Cost_Center.SelectedIndex = 0;
            }

            ddlcharge.Focus();
            if (!IsPostBack)
            {
                txt_Cur_Rev.Attributes.Add("readonly", "readonly");
                txt_Cur_Rev.Style.Add("background-color", "#F0F0F0");

                txt_Cur_Cost.Attributes.Add("readonly", "readonly");
                txt_Cur_Cost.Style.Add("background-color", "#F0F0F0");

                txt_Amount_Rev.Attributes.Add("readonly", "readonly");
                txt_Amount_Rev.Style.Add("background-color", "#F0F0F0");

                txt_Amount_Cost.Attributes.Add("readonly", "readonly");
                txt_Amount_Cost.Style.Add("background-color", "#F0F0F0");

                txtCgstRate_Cost.Attributes.Add("readonly", "readonly");
                txtCgstRate_Cost.Style.Add("background-color", "#F0F0F0");

                txtSgstRate_Cost.Attributes.Add("readonly", "readonly");
                txtSgstRate_Cost.Style.Add("background-color", "#F0F0F0");

                txtGstRate_Cost.Attributes.Add("readonly", "readonly");
                txtGstRate_Cost.Style.Add("background-color", "#F0F0F0");

                txtCgstRate_Rev.Attributes.Add("readonly", "readonly");
                txtCgstRate_Rev.Style.Add("background-color", "#F0F0F0");

                txtSgstRate_Rev.Attributes.Add("readonly", "readonly");
                txtSgstRate_Rev.Style.Add("background-color", "#F0F0F0");

                txtGstRate_Rev.Attributes.Add("readonly", "readonly");
                txtGstRate_Rev.Style.Add("background-color", "#F0F0F0");

                txt_CGST_Amt_Rev.Attributes.Add("readonly", "readonly");
                txt_CGST_Amt_Rev.Style.Add("background-color", "#F0F0F0");

                txt_SGST_Amt_Rev.Attributes.Add("readonly", "readonly");
                txt_SGST_Amt_Rev.Style.Add("background-color", "#F0F0F0");

                txt_IGST_Amt_Rev.Attributes.Add("readonly", "readonly");
                txt_IGST_Amt_Rev.Style.Add("background-color", "#F0F0F0");

                txt_CGST_Amt_Cost.Attributes.Add("readonly", "readonly");
                txt_CGST_Amt_Cost.Style.Add("background-color", "#F0F0F0");

                txt_SGST_Amt_Cost.Attributes.Add("readonly", "readonly");
                txt_SGST_Amt_Cost.Style.Add("background-color", "#F0F0F0");

                txt_IGST_Amt_Cost.Attributes.Add("readonly", "readonly");
                txt_IGST_Amt_Cost.Style.Add("background-color", "#F0F0F0");

                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btnNew.Visible = true;
                ddl_Payable_Type_SelectedIndexChanged(this, null);
                Load_Charge();

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Load_Charge()
    {

        DataSet ds = new DataSet();
        ObjUBO.A2 = JOBNO;
        ObjUBO.A13 = JOBNO_PS;
        ObjUBO.A10 = ddl_Cost_Center.SelectedValue;
        ObjUBO.A12 = "R";
        if (Request.QueryString["CHARGE_ID"] != null && Request.QueryString["CHARGE_ID"] != "")
        {
            ObjUBO.A1 = Request.QueryString["CHARGE_ID"].ToString();
        }
        else
        {
            ObjUBO.A1 = "";
        }
        ObjUBO.A15 = "Load_Charge_Grid";
        ds = Chrg.charge_Data_Search(ObjUBO);
        if (ds.Tables[1].Rows.Count > 0)
        {
            ddlcharge.DataSource = ds.Tables[1];
            ddlcharge.DataTextField = "CHARGE_NAME";
            ddlcharge.DataValueField = "CHARGE_VALUE";
            ddlcharge.DataBind();
        }
        ddlcharge.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlcharge.SelectedIndex = 0;
        if (ds.Tables[2].Rows.Count > 0)
        {
            Hdn_id.Value = ds.Tables[2].Rows[0]["SINO"].ToString();
        }
        else
        {
            Hdn_id.Value = "1";
        }
        if (ds.Tables[3].Rows.Count > 0)
        {
            ddl_Employee_Cost.DataSource = ds.Tables[3];
            ddl_Employee_Cost.DataTextField = "STAFF_FULL_NAME";
            ddl_Employee_Cost.DataValueField = "STAFF_FULL_NAME";
            ddl_Employee_Cost.DataBind();
        }
        ddl_Employee_Cost.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Employee_Cost.SelectedIndex = 0;
        if (Request.QueryString["CHARGE_ID"] != null && Request.QueryString["CHARGE_ID"] != "")
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlcharge.SelectedValue = ds.Tables[0].Rows[0]["CHARGE_HEAD"].ToString();
                ddl_Cur_Rev.SelectedValue = ds.Tables[0].Rows[0]["CURRENCY"].ToString();
                txt_Cur_Rev.Text = ds.Tables[0].Rows[0]["CURRENCY_VALUE"].ToString();
                ddl_Cost_Center.SelectedValue = ds.Tables[0].Rows[0]["BASIS"].ToString();
                txtQty_Rev.Text = ds.Tables[0].Rows[0]["QTY"].ToString();
                txtUnitPrice_Rev.Text = ds.Tables[0].Rows[0]["UNIT_PRICE"].ToString();
                txt_Amount_Rev.Text = ds.Tables[0].Rows[0]["AMOUNT_INR"].ToString();
                txtGstRate_Rev.Text = ds.Tables[0].Rows[0]["IGST_RATE"].ToString();
                txt_IGST_Amt_Rev.Text = ds.Tables[0].Rows[0]["IGST_AMOUNT"].ToString();
                hdn_TaxValue.Value = ds.Tables[0].Rows[0]["TAX_TYPE"].ToString();
                txtCgstRate_Rev.Text = ds.Tables[0].Rows[0]["CGST_RATE"].ToString();
                txtSgstRate_Rev.Text = ds.Tables[0].Rows[0]["SGST_RATE"].ToString();
                txt_CGST_Amt_Rev.Text = ds.Tables[0].Rows[0]["CGST_AMT"].ToString();
                txt_SGST_Amt_Rev.Text = ds.Tables[0].Rows[0]["SGST_AMT"].ToString();
                txt_Charge_Desc_Rev.Text = ds.Tables[0].Rows[0]["DESCRIPTION"].ToString();

                ddlch_Cat.SelectedValue = ds.Tables[0].Rows[0]["CATEGORY"].ToString();
                txtNarration.Text = ds.Tables[0].Rows[0]["NARRATION"].ToString();
                ddl_Rev_Type_Rev.SelectedValue = ds.Tables[0].Rows[0]["REV_RECEIVABLE_TYPE"].ToString();
                ddl_Rev_From_Rev.SelectedValue = ds.Tables[0].Rows[0]["REV_RECEIVABLE_FROM"].ToString();

                txt_Charge_Desc_Cost.Text = ds.Tables[0].Rows[0]["COST_DESCRIPTION"].ToString();
                txtQty_Cost.Text = ds.Tables[0].Rows[0]["COST_QTY"].ToString();
                txtUnitPrice_Cost.Text = ds.Tables[0].Rows[0]["COST_UNIT_PRICE"].ToString();
                ddl_Cur_Cost.SelectedValue = ds.Tables[0].Rows[0]["COST_CURRENCY"].ToString();
                txt_Cur_Cost.Text = ds.Tables[0].Rows[0]["COST_CURRENCY_VALUE"].ToString();
                txt_Amount_Cost.Text = ds.Tables[0].Rows[0]["COST_AMOUNT_INR"].ToString();

                txtCgstRate_Cost.Text = ds.Tables[0].Rows[0]["COST_CGST_RATE"].ToString();
                txt_CGST_Amt_Cost.Text = ds.Tables[0].Rows[0]["COST_CGST_AMT"].ToString();
                txtSgstRate_Cost.Text = ds.Tables[0].Rows[0]["COST_SGST_RATE"].ToString();
                txt_SGST_Amt_Cost.Text = ds.Tables[0].Rows[0]["COST_SGST_AMT"].ToString();
                txtGstRate_Cost.Text = ds.Tables[0].Rows[0]["COST_IGST_RATE"].ToString();
                txt_IGST_Amt_Cost.Text = ds.Tables[0].Rows[0]["COST_IGST_AMOUNT"].ToString();
                ddl_Payable_Type_Cost.SelectedValue = ds.Tables[0].Rows[0]["COST_PAYABLE_TYPE"].ToString();
                ddl_Payable_To_Cost.SelectedValue = ds.Tables[0].Rows[0]["COST_PAYABLE_TO"].ToString();
                ddl_Employee_Cost.SelectedValue = ds.Tables[0].Rows[0]["COST_EMPLOYEE"].ToString();
                ViewState["CHARGE_ID"] = ds.Tables[0].Rows[0]["CHARGE_ID"].ToString();
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
            }
        }

       

    }
    protected void ddl_Payable_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet dss = new DataSet();
            ObjUBO.A8 = ddl_Payable_Type_Cost.SelectedValue;
            ObjUBO.A15 = "LOAD_PAYABLE_TYPE";
            dss = Chrg.charge_Data_Search(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                ddl_Payable_To_Cost.DataSource = dss.Tables[0];
                ddl_Payable_To_Cost.DataTextField = "Payable_Type";
                ddl_Payable_To_Cost.DataValueField = "Payable_Type";
                ddl_Payable_To_Cost.DataBind();
            }
            ddl_Payable_To_Cost.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Payable_To_Cost.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void ddlcharge_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ObjUBO.A2 = JOBNO;
            string value = ddlcharge.SelectedValue;
            string[] chargename = value.Split('~');
            ObjUBO.A6 = chargename[1];
            ObjUBO.A7 = chargename[0];
            ObjUBO.A11 = Session["GSTN"].ToString().Substring(0, 2);
            ObjUBO.A15 = "Load_Charge_DETAILS";
            ds = Chrg.charge_Data_Search(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtGstRate_Cost.Text = ds.Tables[0].Rows[0]["IGST_RATE"].ToString();
                txtCgstRate_Cost.Text = ds.Tables[0].Rows[0]["CGST_RATE"].ToString();
                txtSgstRate_Cost.Text = ds.Tables[0].Rows[0]["SGST_RATE"].ToString();
                txtGstRate_Rev.Text = ds.Tables[0].Rows[0]["IGST_RATE"].ToString();
                txtCgstRate_Rev.Text = ds.Tables[0].Rows[0]["CGST_RATE"].ToString();
                txtSgstRate_Rev.Text = ds.Tables[0].Rows[0]["SGST_RATE"].ToString();

            }
            hdn_TaxValue.Value = "";
            hdn_TaxValue.Value = chargename[0].ToString();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public void Acc_Chrg_Ins_Upd(string Flag, string id)
    {
        DataSet ds = new DataSet();
        ObjUBO.A1 = id;
        ObjUBO.A2 = JOBNO;
        string value = ddlcharge.SelectedValue;
        string[] chargename = value.Split('~');
        ObjUBO.A3 = ddlcharge.SelectedValue;
        ObjUBO.A4 = ddl_Cur_Rev.SelectedValue;
        ObjUBO.A5 = txt_Cur_Rev.Text;
        ObjUBO.A6 = ddl_Cost_Center.SelectedValue;
        ObjUBO.A7 = string.IsNullOrWhiteSpace(txtQty_Rev.Text) ? "0" : txtQty_Rev.Text;
        ObjUBO.A8 = string.IsNullOrWhiteSpace(txtUnitPrice_Rev.Text) ? "0" : txtUnitPrice_Rev.Text;
        //txt_Amount_Cost.Text = Hdn_amt_inr.Value;
        ObjUBO.A9 = string.IsNullOrWhiteSpace(txt_Amount_Rev.Text) ? "0" : txt_Amount_Rev.Text;
        ObjUBO.A10 = string.IsNullOrWhiteSpace(txtGstRate_Rev.Text) ? "0" : txtGstRate_Rev.Text;
        ObjUBO.A11 = string.IsNullOrWhiteSpace(txt_IGST_Amt_Rev.Text) ? "0" : txt_IGST_Amt_Rev.Text;
        ObjUBO.A12 = hdn_TaxValue.Value;
        ObjUBO.A13 = string.IsNullOrWhiteSpace(txtCgstRate_Rev.Text) ? "0" : txtCgstRate_Rev.Text;
        ObjUBO.A14 = string.IsNullOrWhiteSpace(txtSgstRate_Rev.Text) ? "0" : txtSgstRate_Rev.Text;
        ObjUBO.A15 = string.IsNullOrWhiteSpace(txt_CGST_Amt_Rev.Text) ? "0" : txt_CGST_Amt_Rev.Text;
        ObjUBO.A16 = string.IsNullOrWhiteSpace(txt_SGST_Amt_Rev.Text) ? "0" : txt_SGST_Amt_Rev.Text;
        ObjUBO.A17 = "T";
        //if (chk.Checked == true)
        //{
        //    ObjUBO.A17 = "T";
        //}
        //else
        //{
        //    ObjUBO.A17 = "F";
        //}
        ObjUBO.A18 = txt_Charge_Desc_Rev.Text;
        ObjUBO.A19 = Hdn_id.Value;
        // ObjUBO.A20 = txtInvoice_No.Text;
        ObjUBO.A21 = Session["JOBNO_PS"].ToString();
        ObjUBO.A22 = "R";
        ObjUBO.A23 = ddlch_Cat.SelectedValue;
        ObjUBO.A24 = txtNarration.Text;
        ObjUBO.A25 = ddl_Rev_Type_Rev.SelectedValue;
        ObjUBO.A26 = ddl_Rev_From_Rev.SelectedValue;
        ObjUBO.A27 = txt_Charge_Desc_Cost.Text;
        ObjUBO.A28 = string.IsNullOrWhiteSpace(txtQty_Cost.Text) ? "0" : txtQty_Cost.Text;
        ObjUBO.A29 = string.IsNullOrWhiteSpace(txtUnitPrice_Cost.Text) ? "0" : txtUnitPrice_Cost.Text;
        ObjUBO.A30 = ddl_Cur_Cost.SelectedValue;
        ObjUBO.A31 = txt_Cur_Cost.Text;
        ObjUBO.A32 = string.IsNullOrWhiteSpace(txt_Amount_Cost.Text) ? "0" : txt_Amount_Cost.Text;
        ObjUBO.A33 = string.IsNullOrWhiteSpace(txtCgstRate_Cost.Text) ? "0" : txtCgstRate_Cost.Text;
        ObjUBO.A34 = string.IsNullOrWhiteSpace(txt_CGST_Amt_Cost.Text) ? "0" : txt_CGST_Amt_Cost.Text;
        ObjUBO.A35 = string.IsNullOrWhiteSpace(txtSgstRate_Cost.Text) ? "0" : txtSgstRate_Cost.Text;
        ObjUBO.A36 = string.IsNullOrWhiteSpace(txt_SGST_Amt_Cost.Text) ? "0" : txt_SGST_Amt_Cost.Text;
        ObjUBO.A37 = string.IsNullOrWhiteSpace(txtGstRate_Cost.Text) ? "0" : txtGstRate_Cost.Text;
        ObjUBO.A38 = string.IsNullOrWhiteSpace(txt_IGST_Amt_Cost.Text) ? "0" : txt_IGST_Amt_Cost.Text;
        ObjUBO.A40 = ddl_Payable_Type_Cost.SelectedValue;
        ObjUBO.A41 = ddl_Payable_To_Cost.SelectedValue;
        ObjUBO.A42 = ddl_Employee_Cost.SelectedValue;
        ObjUBO.A70 = Flag;
        ds = Chrg.Charge_Ins_Upd(ObjUBO);
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
            ViewState["CHARGE_ID"] = null;
            Clear();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void Clear()
    {
        txt_Charge_Desc_Cost.Text = string.Empty;
        txtQty_Cost.Text = string.Empty;
        txtUnitPrice_Cost.Text = string.Empty;
        txtGstRate_Cost.Text = string.Empty;
        hdn_TaxValue.Value = "";
        txt_IGST_Amt_Cost.Text = string.Empty;
        txt_CGST_Amt_Cost.Text = string.Empty;
        txt_SGST_Amt_Cost.Text = string.Empty;
        txtCgstRate_Cost.Text = string.Empty;
        txtSgstRate_Cost.Text = string.Empty;
        ddlcharge.SelectedIndex = -1;
        ddl_Cur_Cost.SelectedValue = "INR";
        txt_Cur_Cost.Text = "1";
        txt_Amount_Cost.Text = "";
        Hdn_amt_inr.Value = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlcharge.SelectedValue != "")
            {
                if (txtQty_Cost.Text != string.Empty)
                {
                    Acc_Chrg_Ins_Upd("S", "");
                    i = Chrg.result;
                    ViewState["CHARGE_ID"] = Convert.ToString(Chrg.UPDATE_ID);
                    if (i == 1)
                    {
                        Alert_msg("Charge Details Saved Successfully", "btnSave");
                        btnUpdate.CssClass = "updates";
                        btnDelete.Visible = true;
                        btnUpdate.Visible = true;
                        btnSave.Visible = false;
                    }
                    else if (i == 2)
                    {
                        Alert_msg("Charge Details already Exist", "btnSave");
                    }
                    else
                    {
                        Alert_msg("Charge Details Not Saved", "btnSave");
                    }
                }
                else
                {
                    Alert_msg("Enter Ur Quanity!", "txtQty");
                }
            }
            else
            {
                Alert_msg("Select Ur Charge Head!", "ddlcharge");
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
            ObjUBO.A1 = ViewState["CHARGE_ID"].ToString();
            ObjUBO.A2 = JOBNO;
            ObjUBO.A15 = "DELETE";
            ObjUBO.A10 = ddl_Cost_Center.SelectedValue;
            ObjUBO.A12 = "R";
            ds = Chrg.charge_Data_Search(ObjUBO);
            if (ds.Tables[1].Rows.Count > 0)
            {
                //gv_details.DataSource = ds.Tables[1];
                //gv_details.DataBind();
            }
            else
            {
                //gv_details.DataSource = dt;
                //gv_details.DataBind();
            }

            if (ds.Tables[0].Rows.Count == 0)
            {
                Alert_msg("Job Deleted.");
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btnNew.Visible = true;
                btnUpdate.CssClass = "updates";
                ViewState["CHARGE_ID"] = null;
                Clear();
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlcharge.SelectedValue != "")
            {
                if (txtQty_Cost.Text != string.Empty)
                {
                    Acc_Chrg_Ins_Upd("U", ViewState["CHARGE_ID"].ToString());
                    i = Chrg.result;
                    if (i == 1)
                    {
                        Alert_msg("Charge Updated Successfully", "btnUpdate");
                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                        btnSave.Visible = false;
                    }
                    else if (i == 2)
                    {
                        Alert_msg("Charge Details already Exist", "btnSave");
                    }
                    else
                    {
                        Alert_msg("Charge  Not Saved", "btnUpdate");
                    }
                }
                else
                {
                    Alert_msg("Enter Ur Quanity!", "txtQty");
                }
            }
            else
            {
                Alert_msg("Select Ur Charge Head!", "ddlcharge");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
    //protected void gv_details_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    ViewState["JOBNO"] = Convert.ToString(this.gv_details.SelectedDataKey.Value);
    //    ViewState["CHARGE_ID"] = Convert.ToString(this.gv_details.SelectedRow.Cells[2].Text);
    //    if (ViewState["JOBNO"] != "" && ViewState["JOBNO"] != null)
    //    {
    //        TxtSi_no.Text = gv_details.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
    //        string a = gv_details.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
    //        if (a == "True")
    //        {
    //            chk.Checked = true;
    //        }
    //        else
    //        {
    //            chk.Checked = false;
    //        }
    //        txtInvoice_No.Text = gv_details.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
    //        ddlcharge.SelectedValue = System.Net.WebUtility.HtmlDecode(gv_details.SelectedRow.Cells[6].Text);
    //        ddl_Tax.Items.Clear();
    //        ddl_Tax.Items.Add(gv_details.SelectedRow.Cells[7].Text.Replace("&nbsp;", "").Trim());
    //        txtInvoiceCurrency.SelectedValue = gv_details.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
    //        txtCurrValue.Text = gv_details.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
    //        txtQty.Text = gv_details.SelectedRow.Cells[11].Text.Replace("01/01/1900", "").Replace("&nbsp;", "");
    //        txtUnitPrice.Text = gv_details.SelectedRow.Cells[12].Text.Replace("&nbsp;", "");
    //        txtAmtinr.Text = gv_details.SelectedRow.Cells[13].Text.Replace("&nbsp;", "");
    //        Hdn_amt_inr.Value = gv_details.SelectedRow.Cells[13].Text.Replace("&nbsp;", "");
    //        txtGstRate.Text = gv_details.SelectedRow.Cells[14].Text.Replace("&nbsp;", "");
    //        txtGstAmt.Text = gv_details.SelectedRow.Cells[15].Text.Replace("&nbsp;", "");
    //        txtCgstRate.Text = gv_details.SelectedRow.Cells[16].Text.Replace("&nbsp;", "");
    //        txtCgstAmt.Text = gv_details.SelectedRow.Cells[17].Text.Replace("&nbsp;", "");
    //        txtSgstRate.Text = gv_details.SelectedRow.Cells[18].Text.Replace("&nbsp;", "");
    //        txtSgstAmt.Text = gv_details.SelectedRow.Cells[19].Text.Replace("&nbsp;", "");
    //        TxtDescription.Text = gv_details.SelectedRow.Cells[20].Text.Replace("&nbsp;", "");

    //        btnUpdate.CssClass = "updates";
    //        btnDelete.Visible = true;
    //        btnUpdate.Visible = true;
    //        btnSave.Visible = false;

    //    }
    //    else
    //    {
    //        btnDelete.Visible = false;
    //        btnUpdate.Visible = false;
    //        btnSave.Visible = true;

    //    }
    //}
    //protected void gv_details_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        if (hdn_Grid_Disable.Value == "1")
    //        {
    //            e.Row.Enabled = false;
    //        }
    //        else
    //        {
    //            e.Row.Enabled = true;
    //            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_details, "Select$" + e.Row.RowIndex.ToString()));

    //        }
    //    }

    //}
    //protected void gv_details_RowCreated(object sender, GridViewRowEventArgs e)
    //{
    //    //Add CSS class on header row.
    //    if (e.Row.RowType == DataControlRowType.Header)
    //        e.Row.CssClass = "header";

    //    //Add CSS class on normal row.
    //    if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
    //        e.Row.CssClass = "normal";

    //    //Add CSS class on alternate row.
    //    if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
    //        e.Row.CssClass = "alternate";
    //}

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    //[System.Web.Services.WebMethod]
    //public static string GetExchange_Rate_Invoice_Cur(string custid)
    //{
    //    if (custid.Length == 3)
    //    {
    //        Auto_Search Auto = new Auto_Search();
    //        DataSet ds = new DataSet();
    //        Auto.Ename = "EXCHANGE_MASTER_RATE_IMPORTWISE";
    //        Auto.Enamesearch = custid;
    //        ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            custid = ds.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();
    //        }
    //        else
    //        {
    //            Auto.Ename = "NON_STD_CUR_RATE_IMPORTWISE";
    //            Auto.Enamesearch = custid;
    //            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
    //            if (ds.Tables[0].Rows.Count > 0)
    //            {
    //                custid = ds.Tables[0].Rows[0]["NON_STD_RATE_IMPORT"].ToString();
    //            }
    //            else
    //            {
    //                custid = "";
    //            }
    //        }
    //    }
    //    else
    //    {
    //        custid = "";
    //    }
    //    return custid;
    //}


}