using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;

public partial class Import_Acc_Charge_Details : ThemeClass
{
    Cha_Accounts Chrg = new Cha_Accounts();
    Global_variables ObjUBO = new Global_variables();
    AppSession aps = new AppSession();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
   
    public int i;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        try
        {
           
            ddlcharge.Focus();
            if (!IsPostBack)
            {
                txtGstRate.Attributes.Add("readonly", "readonly");
                txtGstRate.Style.Add("background-color", "#FFCBA4");

                txtGstAmt.Attributes.Add("readonly", "readonly");
                txtGstAmt.Style.Add("background-color", "#F0F0F0");

                txtCgstRate.Attributes.Add("readonly", "readonly");
                txtCgstRate.Style.Add("background-color", "#81F7BE");

                txtCgstAmt.Attributes.Add("readonly", "readonly");
                txtCgstAmt.Style.Add("background-color", "#F0F0F0");

                txtSgstRate.Attributes.Add("readonly", "readonly");
                txtSgstRate.Style.Add("background-color", "#81F7BE");

                txtSgstAmt.Attributes.Add("readonly", "readonly");
                txtSgstAmt.Style.Add("background-color", "#F0F0F0");
                ddl_Tax.Attributes.Add("disabled", "disabled");

                txtInvoiceCurrency.SelectedValue = "INR";
                txtCurrValue.Text = "1";
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btnNew.Visible = true;
                if (Session["MOVE_ACCOUNTS_OJ"].ToString()!= "0")
                {
                    btnDelete.Enabled = false;
                    lbl_Acc_Msg.Text = "Once moved to invoice, it cannot be modified";
                    btnUpdate.Enabled = false;
                    btnSave.Enabled = false;
                    btnNew.Enabled = false;
                }
                else
                {
                  
                    btnDelete.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnSave.Enabled = true;
                    btnNew.Enabled = true;
                    lbl_Acc_Msg.Text = "";
                }
                load_AutoNo_Charge_Grid();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public void load_AutoNo_Charge_Grid()
    {
        DataSet dss = new DataSet();
        try
        {
            ObjUBO.A15 = "Load_Charge_Sino_Grid";
            ObjUBO.A2 = Session["JOBNO_OJ"].ToString();
            ObjUBO.A10 = Session["IMP_EXP_OJ"].ToString();
            ObjUBO.A12 = "O";
            dss = Chrg.charge_Data_Search(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                TxtSi_no.Text = dss.Tables[0].Rows[0]["SINO"].ToString();
            }
            if (dss.Tables[1].Rows.Count > 0)
            {
                ddlcharge.DataSource = dss.Tables[1];
                ddlcharge.DataTextField = "CHARGE_NAME";
                ddlcharge.DataValueField = "CHARGE_VALUE";
                ddlcharge.DataBind();
            }
            ddlcharge.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlcharge.SelectedIndex = 0;
            if (dss.Tables[2].Rows.Count > 0)
            {
                gv_details.DataSource = dss.Tables[2];
                gv_details.DataBind();
                From_Quotation.Checked = false;
            }
            else
            {
                DataSet Ds = new DataSet();
                ObjUBO.A102 = Session["JOBNO_OJ"].ToString();
                ObjUBO.A103 = Session["JOBNO_PS_OJ"].ToString();
                ObjUBO.A109 = Session["GSTN_OJ"].ToString().Substring(0, 2);
                ObjUBO.A106 = Session["IMP_EXP_OJ"].ToString();
                ObjUBO.A107 = "O";
                ObjUBO.A108 = Session["MODE_OJ"].ToString();
                ObjUBO.A110 = "QUOTATION_INSERT";
               // Ds = Chrg.BillToOtherQuotationCharge_Ins_Upd(ObjUBO);

                gv_details.DataSource = Ds.Tables[0];
                gv_details.DataBind();
                From_Quotation.Checked =true;
            }
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
            ObjUBO.A2 = Session["JOBNO_OJ"].ToString();
            string value = ddlcharge.SelectedValue;
            string[] chargename = value.Split('~');
            ObjUBO.A6 = chargename[1];
            ObjUBO.A7 = chargename[0];
            ObjUBO.A11 = Session["GSTN_OJ"].ToString().Substring(0, 2);
            ObjUBO.A15 = "Load_Charge_DETAILS";
            ObjUBO.A12 = "O";
            ds = Chrg.charge_Data_Search(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtGstRate.Text = ds.Tables[0].Rows[0]["IGST_RATE"].ToString();
                txtCgstRate.Text = ds.Tables[0].Rows[0]["CGST_RATE"].ToString();
                txtSgstRate.Text = ds.Tables[0].Rows[0]["SGST_RATE"].ToString();
            }
            ddl_Tax.Items.Clear();
            ddl_Tax.Items.Add(chargename[0].ToString());
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
        ObjUBO.A2 = Session["JOBNO_OJ"].ToString();
        string value = ddlcharge.SelectedValue;
        string[] chargename = value.Split('~');
        ObjUBO.A3 = ddlcharge.SelectedValue;
        ObjUBO.A4 = txtInvoiceCurrency.SelectedValue;
        ObjUBO.A5 = txtCurrValue.Text;
        ObjUBO.A6 = Session["IMP_EXP_OJ"].ToString();
        ObjUBO.A7 = string.IsNullOrWhiteSpace(txtQty.Text) ? "0" : txtQty.Text;
        ObjUBO.A8 = string.IsNullOrWhiteSpace(txtUnitPrice.Text) ? "0" : txtUnitPrice.Text;
        txtAmtinr.Text = Hdn_amt_inr.Value;
        ObjUBO.A9 = string.IsNullOrWhiteSpace(txtAmtinr.Text) ? "0" : txtAmtinr.Text;
        ObjUBO.A10 = string.IsNullOrWhiteSpace(txtGstRate.Text) ? "0" : txtGstRate.Text;
        ObjUBO.A11 = string.IsNullOrWhiteSpace(txtGstAmt.Text) ? "0" : txtGstAmt.Text;
        ObjUBO.A12 = ddl_Tax.SelectedValue;
        ObjUBO.A13 = string.IsNullOrWhiteSpace(txtCgstRate.Text) ? "0" : txtCgstRate.Text;
        ObjUBO.A14 = string.IsNullOrWhiteSpace(txtSgstRate.Text) ? "0" : txtSgstRate.Text;
        ObjUBO.A15 = string.IsNullOrWhiteSpace(txtCgstAmt.Text) ? "0" : txtCgstAmt.Text;
        ObjUBO.A16 = string.IsNullOrWhiteSpace(txtSgstAmt.Text) ? "0" : txtSgstAmt.Text;
        if (chk.Checked == true)
        {
            ObjUBO.A17 = "T";
        }
        else
        {
            ObjUBO.A17 = "F";
        }
        ObjUBO.A18 = TxtDescription.Text;
        ObjUBO.A19 = TxtSi_no.Text;
        ObjUBO.A20 = txtInvoice_No.Text;
        ObjUBO.A21 = Session["JOBNO_PS_OJ"].ToString();
        ObjUBO.A22 = "O";
        ObjUBO.A70 = Flag;
        ds = Chrg.Charge_Ins_Upd(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gv_details.DataSource = ds.Tables[0];
            gv_details.DataBind();
        }
        else
        {
            gv_details.DataSource = dt;
            gv_details.DataBind();
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
        TxtDescription.Text = string.Empty;
        txtQty.Text = string.Empty;
        txtUnitPrice.Text = string.Empty;
        txtGstRate.Text = string.Empty;
        ddl_Tax.Items.Clear();
        txtGstAmt.Text = string.Empty;
        txtCgstAmt.Text = string.Empty;
        txtSgstAmt.Text = string.Empty;
        txtCgstRate.Text = string.Empty;
        txtSgstRate.Text = string.Empty;
        ddlcharge.SelectedIndex = -1;
        txtInvoiceCurrency.SelectedValue = "INR";
        txtCurrValue.Text = "1";
        chk.Checked = true;
        txtInvoice_No.Text = "";
        txtAmtinr.Text = "";
        Hdn_amt_inr.Value = "";
        TxtSi_no.Text =  (gv_details.Rows.Count+1).ToString() ;

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlcharge.SelectedValue != "")
            {
                if (txtQty.Text != string.Empty)
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
            ObjUBO.A2 = Session["JOBNO_OJ"].ToString();
            ObjUBO.A15 = "DELETE";
            ObjUBO.A10 = Session["IMP_EXP_OJ"].ToString();
            ObjUBO.A12 = "O";
            ds=Chrg.charge_Data_Search(ObjUBO);
            if (ds.Tables[1].Rows.Count > 0)
            {
                gv_details.DataSource = ds.Tables[1];
                gv_details.DataBind();
            }
            else
            {
                gv_details.DataSource = dt;
                gv_details.DataBind();
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
                if (txtQty.Text != string.Empty)
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
    protected void gv_details_SelectedIndexChanged(object sender, EventArgs e)
    {

        ViewState["JOBNO"] = Convert.ToString(this.gv_details.SelectedDataKey.Value);
        ViewState["CHARGE_ID"] = Convert.ToString(this.gv_details.SelectedRow.Cells[2].Text);
        if (ViewState["JOBNO"] != "" && ViewState["JOBNO"] != null)
        {
            TxtSi_no.Text = gv_details.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string a = gv_details.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            if (a == "True")
            {
                chk.Checked = true;
            }
            else
            {
                chk.Checked = false;
            }
            txtInvoice_No.Text = gv_details.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            ddlcharge.SelectedValue = System.Net.WebUtility.HtmlDecode(gv_details.SelectedRow.Cells[6].Text);
            ddl_Tax.Items.Clear();
            ddl_Tax.Items.Add(gv_details.SelectedRow.Cells[7].Text.Replace("&nbsp;", "").Trim());
            txtInvoiceCurrency.SelectedValue = gv_details.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
            txtCurrValue.Text = gv_details.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
            txtQty.Text = gv_details.SelectedRow.Cells[11].Text.Replace("01/01/1900", "").Replace("&nbsp;", "");
            txtUnitPrice.Text = gv_details.SelectedRow.Cells[12].Text.Replace("&nbsp;", "");
            txtAmtinr.Text = gv_details.SelectedRow.Cells[13].Text.Replace("&nbsp;", "");
            Hdn_amt_inr.Value = gv_details.SelectedRow.Cells[13].Text.Replace("&nbsp;", "");
            txtGstRate.Text = gv_details.SelectedRow.Cells[14].Text.Replace("&nbsp;", "");
            txtGstAmt.Text = gv_details.SelectedRow.Cells[15].Text.Replace("&nbsp;", "");
            txtCgstRate.Text = gv_details.SelectedRow.Cells[16].Text.Replace("&nbsp;", "");
            txtCgstAmt.Text = gv_details.SelectedRow.Cells[17].Text.Replace("&nbsp;", "");
            txtSgstRate.Text = gv_details.SelectedRow.Cells[18].Text.Replace("&nbsp;", "");
            txtSgstAmt.Text = gv_details.SelectedRow.Cells[19].Text.Replace("&nbsp;", "");
            TxtDescription.Text = gv_details.SelectedRow.Cells[20].Text.Replace("&nbsp;", "");

         
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
          
        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;

        }
    }

    protected void gv_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (hdn_Grid_Disable.Value == "1")
            {
                e.Row.Enabled = false;
            }
            else
            {
                e.Row.Enabled = true;
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_details, "Select$" + e.Row.RowIndex.ToString()));

            }
        }

    }
    protected void gv_details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

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

    [System.Web.Services.WebMethod]
    public static string GetExchange_Rate_Invoice_Cur(string custid, string Imp_Exp)
    {
        if (custid.Length == 3)
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Enamesearch = custid;
            if (Imp_Exp == "I")
            {
                Auto.Ename = "EXCHANGE_MASTER_RATE_IMPORTWISE";

            }
            else
            {
                Auto.Ename = "EXCHANGE_MASTER_RATE_EXPORTWISE";

            }
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {

                custid = ds.Tables[0].Rows[0][0].ToString();

            }
            else
            {
                if (Imp_Exp == "I")
                {
                    Auto.Ename = "NON_STD_CUR_RATE_IMPORTWISE";
                }
                else
                {
                    Auto.Ename = "NON_STD_CUR_RATE_EXPORTWISE";
                }
                ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {

                    custid = ds.Tables[0].Rows[0][0].ToString();

                }
                else
                {
                    custid = "";
                }
            }
        }
        else
        {
            custid = "";
        }
        return custid;
    }

}