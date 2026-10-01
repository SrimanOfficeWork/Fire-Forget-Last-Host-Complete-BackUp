using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Export_DTA_Items : ThemeClass
{
    DataSet dtuser = new DataSet();

    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    Global_variables ObjUBO = new Global_variables();
    Exp_DTA DTA = new Exp_DTA();
    DataSet ds = new DataSet();

    public int i;
    public string EXPORT_JOBNO, INV_SLNO, ITEM_SLNO, SCHEME_CODE,RITC_NO,ITEM_DESC,UNIT_CODE;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE;
    User_Creation user_Create = new User_Creation();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
      
        if (Session["EXPORT_JOBNO"] != null)
        {
            EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();

            if (Session["Inv_SL_No"] != null)
            {
                INV_SLNO = Session["Inv_SL_No"].ToString();
                ITEM_SLNO = Session["Item_SLNo"].ToString();

                if (!IsPostBack)
                {
                    load_Data(EXPORT_JOBNO);
                }
            }
            else
            {
                Response.Write("<script>window.open('Item_Details.aspx','_parent');</script>");
            }
        }
        else
        {
            Response.Write("<script>window.open('General.aspx','_parent');</script>");
        }

    }

    private void load_Data(string Jobno)
    {
        try
        {
            ObjUBO.A2 = Jobno;
            ObjUBO.A3 = INV_SLNO;
            ObjUBO.A4 = ITEM_SLNO;

            ObjUBO.A10 = "Select_DTA_Item_Details";
            ds = DTA.DTA_Data_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                chk_DTA_Applicable.Checked = true;

                HDupdate_id.Value = ds.Tables[0].Rows[0]["DTA_ITEM_ID"].ToString();
                ViewState["UPDATED_ID"] = ds.Tables[0].Rows[0]["DTA_ITEM_ID"].ToString();

                ddl_ItemType.SelectedValue = ds.Tables[0].Rows[0]["ITEM_TYPE"].ToString();
                txt_RebateClaimed_Amt.Text = ds.Tables[0].Rows[0]["REBATE_CLAIMED_AMOUNT"].ToString();
                txt_IGST_Notn.Text = ds.Tables[0].Rows[0]["IGST_NOTN_NO"].ToString();
                txt_IGST_NotnSl.Text = ds.Tables[0].Rows[0]["IGST_NOTN_SLNO"].ToString();
                txt_Compen_Cess_Notn.Text = ds.Tables[0].Rows[0]["COMPENSATION_CESS_NOTN"].ToString();
                txt_Compen_Cess_NotnSl.Text = ds.Tables[0].Rows[0]["COMPENSATION_CESS_NOTN_SLNO"].ToString();
                txt_CessRate.Text = ds.Tables[0].Rows[0]["CESS_RATE"].ToString();
                txt_CessAmount.Text = ds.Tables[0].Rows[0]["CESS_AMOUNT"].ToString();

                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btnDelete.Visible = true;
                lbl_Inv_Status.Text = "";
            }
            else
            {
                if (DTA.result == 2)
                {
                    lbl_Inv_Status.Text = "No Such Invoice not selected for this Item";
                    chk_DTA_Applicable.Enabled = false;
                    ddl_ItemType.Enabled = false;
                    txt_RebateClaimed_Amt.Enabled = false;
                    txt_IGST_Notn.Enabled = false;
                    txt_IGST_NotnSl.Enabled = false;
                    txt_Compen_Cess_Notn.Enabled = false;
                    txt_Compen_Cess_NotnSl.Enabled = false;
                    txt_CessRate.Enabled = false;
                    txt_CessAmount.Enabled = false;


                }
                else
                {
                    lbl_Inv_Status.Text = "";
                }
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
            }

            //-------- Shows Sum of Values----
            if (ds.Tables[1].Rows.Count > 0)
            {
                lbl_DTA_InvoiceValue.Text = ds.Tables[1].Rows[0]["INVOICE_VALUE"].ToString();
                lbl_DTA_InvoiceValue_INR.Text = ds.Tables[1].Rows[0]["INVOICE_VALUE_INR"].ToString();
                lbl_DTA_IGST_AMT_INR.Text = ds.Tables[1].Rows[0]["TOT_IGST_AMT"].ToString();
                lbl_DTA_CESS_AMT_INR.Text = ds.Tables[1].Rows[0]["TOT_CESS_AMOUNT"].ToString();
            }
            else
            {
                lbl_DTA_InvoiceValue.Text = "0.00";
                lbl_DTA_InvoiceValue_INR.Text = "0.00";
                lbl_DTA_IGST_AMT_INR.Text = "0.00";
                lbl_DTA_CESS_AMT_INR.Text = "0.00";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ds = Save_Update("S");
            if (DTA.result==1)
            {
                btnUpdate.CssClass = "save";
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btnSave.Focus();
                ViewState["UPDATED_ID"] = null;
                Alert_msg("Saved Successfully", "btnSave");
                //HDupdate_id.Value = Convert.ToString(ds.Tables[0].Rows[0]["M_ID"].ToString());
                load_Data(EXPORT_JOBNO);
            }
            else
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                btnNew.Visible = true;
                Alert_msg("Not Saved.", "btnSave");
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
            ds = Save_Update("U");
            if (DTA.result == 1)
            {
                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("Updated Successfully", "btnUpdate");
                }
                else
                {
                    Alert_msg("Saved Successfully", "btnUpdate");
                }

                load_Data(EXPORT_JOBNO);
            }
            else
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = true;
                Alert_msg("Not Saved", "btnUpdate");
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            ObjUBO.A2 = EXPORT_JOBNO;
            ObjUBO.A3 = INV_SLNO;
            ObjUBO.A4 = ITEM_SLNO;
            ObjUBO.A10 = "Delete_DTA_Items_Details";
            ds = DTA.DTA_Data_Select(ObjUBO);

            if (DTA.result == 1)
            {
                Alert_msg("Deleted");
            }
            else
            {
                Alert_msg("Not Deleted");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private DataSet Save_Update(string Flag)
    {
        DataSet ds = new DataSet();
        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A2 = EXPORT_JOBNO;
        ObjUBO.A3 = INV_SLNO;
        ObjUBO.A4 = ITEM_SLNO;
        ObjUBO.A5 = txt_RebateClaimed_Amt.Text;
        ObjUBO.A6 = ddl_ItemType.SelectedValue;
        ObjUBO.A7 = txt_IGST_Notn.Text;
        ObjUBO.A8 = txt_IGST_NotnSl.Text;
       // ObjUBO.A9 = "Y";
        ObjUBO.A10 = txt_Compen_Cess_Notn.Text;
        ObjUBO.A11 = txt_Compen_Cess_NotnSl.Text;
        ObjUBO.A12 = txt_CessRate.Text;
        ObjUBO.A13 = txt_CessAmount.Text;
        ObjUBO.A14 = Session["JOBNO_PS"].ToString();


        ObjUBO.A20 = Flag;
        ds = DTA.Export_DTA_ITEMS_Ins_Upd(ObjUBO);
        return ds;

    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        //Transact.ResetFields(Page.Controls);
        //txtDrawback_SLNo.Focus();
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'EXPORT DTA ITEM', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'EXPORT DTA ITEM', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

   
}
