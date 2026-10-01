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

public partial class Accounts_Sales_Gst_Rpt_Annexure_Entry : ThemeClass
{
    AppSession aps = new AppSession();
    GST_Sales_Entry_cs RPT_A = new GST_Sales_Entry_cs();
    Global_variables ObjUBO = new Global_variables();
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();


    public String Imp_Exp;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["Inv_no"] != null && Request.QueryString["Inv_no"] != string.Empty)
            {
                txtInvoiceNo.Text = Request.QueryString["Inv_no"].ToString();
            }
            if (Request.QueryString["IMP_EXP"] != null && Request.QueryString["IMP_EXP"] != string.Empty)
            {
                Imp_Exp = Request.QueryString["IMP_EXP"].ToString();
            }
            Update_Item_Load();
        }
    }


    private void Update_Item_Load()
    {
        try
        {
            DataSet dSS = new DataSet();
            ObjUBO.A1 = txtInvoiceNo.Text;
            ObjUBO.A2 = Imp_Exp;
            ObjUBO.A30 = "Updated_Annexure_Select";
            dSS = RPT_A.Ass_Gst_Bill_Job_Rpt_Ann_Invoice_Exp_Select(ObjUBO);
            if (dSS.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = dSS.Tables[0].Rows[0]["ID"].ToString();
                txtInvoiceNo.Text = dSS.Tables[0].Rows[0]["BILL_INV_NO"].ToString();
                TxtJobNo.Text = dSS.Tables[0].Rows[0]["JOBNO"].ToString();
                TxtJobtype.Text = dSS.Tables[0].Rows[0]["JOBTYPE"].ToString();

                txtSb_No.Text = dSS.Tables[0].Rows[0]["SB_NO"].ToString();
                txtSbDate.Text = dSS.Tables[0].Rows[0]["SB_DATE"].ToString().Replace("01/01/1900", "");
                txtCustomer.Text = dSS.Tables[0].Rows[0]["CUS_REF_NO"].ToString();
                txtsb_type.Text = dSS.Tables[0].Rows[0]["SB_TYPE"].ToString();
                txtInvoice_No.Text = dSS.Tables[0].Rows[0]["JOB_INV_NO"].ToString();
                txtInv_dt.Text = dSS.Tables[0].Rows[0]["JOB_INV_DATE"].ToString().Replace("01/01/1900", "");
                txtMbl_No.Text = dSS.Tables[0].Rows[0]["MBL_NO"].ToString();

                txtMbldate.Text = dSS.Tables[0].Rows[0]["MBL_DATE"].ToString().Replace("01/01/1900", "");
                txtTerms.Text = dSS.Tables[0].Rows[0]["TERM_OF_INV"].ToString();
                TxtHbl.Text = dSS.Tables[0].Rows[0]["HBL_NO"].ToString();
                txtHbl_Date.Text = dSS.Tables[0].Rows[0]["HBL_DATE"].ToString().Replace("01/01/1900", "");
                TxtInv_Value.Text = dSS.Tables[0].Rows[0]["INV_VALUE"].ToString();

                txtCif_Val.Text = dSS.Tables[0].Rows[0]["CIF_VALUE"].ToString();
                txtCustom.Text = dSS.Tables[0].Rows[0]["CUSTOM_HOUSE"].ToString();
                txtFob_Value.Text = dSS.Tables[0].Rows[0]["FOB_VALUE"].ToString();

                txtVessel.Text = dSS.Tables[0].Rows[0]["VESSEL"].ToString();
                txtVoyage_No.Text = dSS.Tables[0].Rows[0]["VOYAGE_NO"].ToString();
                txtConsignee_Name.Text = dSS.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                txtOrgin.Text = dSS.Tables[0].Rows[0]["ORGIN_PORT"].ToString();

                txtSb_Heading.Text = dSS.Tables[0].Rows[0]["SB_HEADING"].ToString();
                txtExport.Text = dSS.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                txtcontainers.Text = dSS.Tables[0].Rows[0]["CONTAINERS"].ToString();

                txtConsignee_Type.Text = dSS.Tables[0].Rows[0]["CONSIGNE_TYPE"].ToString();
                txtPkgs.Text = dSS.Tables[0].Rows[0]["PKG"].ToString();
                txtGross_wt.Text = dSS.Tables[0].Rows[0]["GROSS_WEIGHT"].ToString();
                txtNet_wt.Text = dSS.Tables[0].Rows[0]["NET_WGT"].ToString();
                txtChrgwt.Text = dSS.Tables[0].Rows[0]["CHARGE_WT"].ToString();
                txtNo_of_container.Text = dSS.Tables[0].Rows[0]["NO_OF_CONTAINERS"].ToString();

                
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
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
    public DataSet Annexure_Insert_Update(string S1)
    {
        if (Request.QueryString["IMP_EXP"] != null && Request.QueryString["IMP_EXP"] != string.Empty)
        {
            Imp_Exp = Request.QueryString["IMP_EXP"].ToString();
        }
        ObjUBO.A1 =txtInvoiceNo.Text ;
        ObjUBO.A2 = Imp_Exp;
        ObjUBO.A3 = HDupdate_id.Value;
        ObjUBO.A4 = TxtJobNo.Text;
        ObjUBO.A5 = TxtJobtype.Text;
        ObjUBO.A6 = txtSb_No.Text;
        ObjUBO.A7 = txtSbDate.Text;
        ObjUBO.A8 = txtCustomer.Text;
        ObjUBO.A9 = txtsb_type.Text;
        ObjUBO.A10 = txtInvoice_No.Text;
        ObjUBO.A11 = txtInv_dt.Text;
        ObjUBO.A12 = txtMbl_No.Text;
        ObjUBO.A13 = txtMbldate.Text;
        ObjUBO.A14 = txtTerms.Text;
        ObjUBO.A15 = TxtHbl.Text;
        ObjUBO.A16 = txtHbl_Date.Text;
        ObjUBO.A17 = TxtInv_Value.Text;
        ObjUBO.A18 = txtCif_Val.Text;
        ObjUBO.A19 = txtCustom.Text;
        ObjUBO.A20 = txtFob_Value.Text;
        ObjUBO.A21 = txtVessel.Text;
        ObjUBO.A22 = txtVoyage_No.Text;
        ObjUBO.A23 = txtConsignee_Name.Text;
        ObjUBO.A24 = txtOrgin.Text;
        ObjUBO.A25 = txtSb_Heading.Text;
        ObjUBO.A26 = txtExport.Text;
        ObjUBO.A27 = txtcontainers.Text;
        ObjUBO.A30= S1;
        ObjUBO.A31 = txtConsignee_Type.Text;
        ObjUBO.A32 = txtPkgs.Text;
        ObjUBO.A33 = txtGross_wt.Text;
        ObjUBO.A34 = txtNet_wt.Text;
        ObjUBO.A35 = txtChrgwt.Text;
        ObjUBO.A36 = txtNo_of_container.Text;
        ds = RPT_A.Ass_Gst_Bill_Job_Rpt_Ann_Invoice_Exp_Ins_Upd(ObjUBO);
        return ds;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ds = Annexure_Insert_Update("S");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    HDupdate_id.Value = ds.Tables[0].Rows[0]["id"].ToString();

                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                        btnSave.Visible = false;
                        btnSave.Focus();
                        ViewState["UPDATED_ID"] = null;
                        Alert_msg("Annexure Saved Successfully", "btnSave");
                }
                else
                {
                    Alert_msg("Annexure already exists Not Saved !", "btnSave");
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
            ds = Annexure_Insert_Update("U");
            if (ds.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = ds.Tables[0].Rows[0]["id"].ToString();

                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnSave.Focus();
                ViewState["UPDATED_ID"] = null;
                Alert_msg("Annexure Updated Successfully", "btnSave");
            }
            else
            {
                Alert_msg("Annexure Not Updated", "btnSave");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ObjUBO.A1 = txtInvoiceNo.Text;
        ObjUBO.A2 = Imp_Exp;
        ObjUBO.A30 = "DELETE";
        ds = RPT_A.Ass_Gst_Bill_Job_Rpt_Ann_Invoice_Exp_Select(ObjUBO);
        if (ds.Tables[0].Rows[0]["id"].ToString()=="1")
        {
            Alert_msg("Annexure deleted Successfully", "btnDelete");
            btnNew_Click(this, null);
        }
        else
        {
            Alert_msg("Annexure Not deleted", "btnDelete");
        }

    }

    public void ResetFields(ControlCollection pageControls)
    {
        foreach (Control contl in pageControls)
        {
            string strCntName = (contl.GetType()).Name;
            switch (strCntName)
            {
                case "TextBox":
                    TextBox tbSource = (TextBox)contl;
                    tbSource.Text = "";
                    break;
                case "DropDownList":
                    DropDownList ddlSource = (DropDownList)contl;
                    ddlSource.SelectedIndex = -1;

                    break;

                case "CheckBox":
                    CheckBox chkSource = (CheckBox)contl;
                    chkSource.Checked = false;
                    break;

            }

            ResetFields(contl.Controls);
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        ResetFields(Page.Controls);

        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
        btnSave.Focus();
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Annexure', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Annexure', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void gv_Chg_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
  
}