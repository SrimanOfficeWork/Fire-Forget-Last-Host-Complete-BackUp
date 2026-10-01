using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class ReExport_Details : ThemeClass
{
    EXP_ReExport Re_Exp = new EXP_ReExport();
    User_Creation user_Create = new User_Creation();
    ErrorLogs er = new ErrorLogs();
    Export_General_New Export = new Export_General_New();
    public int i;

    AppSession aps = new AppSession();

    public string a1, a2, a3, a4, a5, a6, EXPORT_JOBNO, RE_EXPORT_ID, FLAG, YEAR, SB_Date, Previous_Be_Date;
    public string INVOICE_SLNO = "", ITEM_SLNO = "", INVOICE_NO = "";
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
            EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();

            if (Session["Item_SLNo"] != null)
            {
                if (Session["TRANSPORT_MODE"] != null)
                {
                    hdfTransport_mode.Value = Session["TRANSPORT_MODE"].ToString();
                }
                INVOICE_SLNO = Session["Inv_SL_No"].ToString();
                ITEM_SLNO = Session["Item_SLNo"].ToString();
                INVOICE_NO = Session["Inv_NO"].ToString();
                if (!IsPostBack)
                {
                    //----------------SETTING SCREEN PERMISSION---------------//
                    Screen_Id = 7;
                    Page_Rights(Screen_Id);
                    //----------------SETTING SCREEN PERMISSION---------------//

                    txtSB_No.Focus();
                    Gridbind_ReExport();

                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                    btnNew.Visible = true;
                }
            }
            else
            {
                Response.Write("<script>window.parent.document.getElementById('ItemMain').click();</script>");
            }

            if (Session["JOB_LOCK"] != null && Session["JOB_LOCK"] != "")
            {
                JOB_LOCK = Session["JOB_LOCK"].ToString();

                if (Convert.ToInt32(JOB_LOCK) == 1)
                {
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnNew.Enabled = false;
                    btnSave.Enabled = false;

                    btnNew.ToolTip = "This Job is Locked by Admin";
                    btnSave.ToolTip = "This Job is Locked by Admin";
                    btnUpdate.ToolTip = "This Job is Locked by Admin";
                    btnDelete.ToolTip = "This Job is Locked by Admin";
                }
            }

            if (Session["USER_JOB_LOCK"].ToString() == "Yes")
            {
                if (Connection.Current_User().ToUpper() != Session["JOB_USER"].ToString().ToUpper())
                {
                    if (Session["JOB_RELEASE"] != null && Session["JOB_RELEASE"] != "")
                    {
                        JOB_RELEASE = Session["JOB_RELEASE"].ToString();

                        if (JOB_RELEASE == "No")
                        {

                            btnUpdate.Enabled = false;
                            btnDelete.Enabled = false;
                            btnNew.Enabled = false;
                            btnSave.Enabled = false;

                            MP_U.Show();

                            lblUser_Msg.Text = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                            btnUpdate.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnDelete.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnNew.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnSave.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        
    }
    public void Page_Rights(int i)
    {
        try
        {
            user_Create.RetrieveAll_User_Screen_Rights_Details(i);
            PAGE_WRITE = user_Create.PAGE_WRITE;
            PAGE_READ = user_Create.PAGE_READ;
            PAGE_MODIFY = user_Create.PAGE_MODIFY;
            PAGE_DELETE = user_Create.PAGE_DELETE;
            hdn_Grid_Disable.Value = "";

            //---------------READ ONLY------------------//

            if (PAGE_READ == "False")
            {
                btnSave.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                btnNew.ToolTip = "You don't have permission to access";
                btnSave.ToolTip = "You don't have permission to access";
                btnUpdate.ToolTip = "You don't have permission to access";
                btnDelete.ToolTip = "You don't have permission to access";
                hdn_Grid_Disable.Value = "1";
            }
            else
            {
                //---------------SAVE BUTTON------------------//
                if (PAGE_WRITE == "True")
                {
                    btnSave.Enabled = true;
                    btnNew.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                    btnSave.ToolTip = "You don't have permission to access";
                    btnNew.Enabled = false;
                }
                //---------------UPDATE BUTTON------------------//
                if (PAGE_MODIFY == "True")
                {
                    btnUpdate.Enabled = true;
                    hdn_Grid_Disable.Value = "";
                }
                else
                {
                    btnUpdate.Enabled = false;
                    btnUpdate.ToolTip = "You don't have permission to access";
                    hdn_Grid_Disable.Value = "1";
                }
                //---------------DELETE BUTTON------------------//

                if (PAGE_DELETE == "True")
                {
                    btnDelete.Enabled = true;
                    hdn_Grid_Disable.Value = "";
                }
                else
                {
                    btnDelete.Enabled = false;
                    btnDelete.ToolTip = "You don't have permission to access";
                    hdn_Grid_Disable.Value = "1";
                }
            }
            if (hdn_Grid_Disable.Value == "1")
                gv_ReExport.ToolTip = "You don't have permission to access";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        
    }
    public void Gridbind_ReExport()
    {
        try
        {
            DataSet ds = new DataSet();
            Re_Exp.JOBNO = EXPORT_JOBNO;
            Re_Exp.INVOICE_SLNO = INVOICE_SLNO;
            Re_Exp.ITEM_SLNO = ITEM_SLNO;
            Re_Exp.flag = "select_con";
            ds = Re_Exp.Re_Export_Details_insertupdate();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gv_ReExport.DataSource = ds.Tables[0];
                gv_ReExport.DataBind();
            }
            else
            {
                Empty_grid();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        

    }
    public void ReExport_Details_insert_update(string Export_ID, string flag)
    {
        try
        {
            DataSet ds = new DataSet();
            Re_Exp.SB_NO = txtSB_No.Text;
            Re_Exp.SB_DATE = txtSB_Date.Text == string.Empty ? null : txtSB_Date.Text;
            Re_Exp.RE_EXPORT_ID = Export_ID;
            Re_Exp.JOBNO = EXPORT_JOBNO;
            Re_Exp.INVOICE_SLNO = INVOICE_SLNO;
            Re_Exp.ITEM_SLNO = ITEM_SLNO;
            Re_Exp.SLNO = txtSerial_No.Text;
            Re_Exp.BE_SITE = txtBE_Site.Text;

            Re_Exp.BE_NO = txtBE_No.Text;
            Re_Exp.BE_DATE = txtBE_Date.Text == string.Empty ? null : txtBE_Date.Text;
            Re_Exp.BE_INVOICE_NO = txt_BE_Inv_no.Text;
            Re_Exp.BE_INVOICE_ITEM_NO = txtBE_Item.Text;
            Re_Exp.MANUAL_BE_Y_N = Rd_Manual_BE.SelectedValue.ToString();
            Re_Exp.BE_QTY_UTILISED = txtBE_Qty_Utilised.Text;

            Re_Exp.BE_ITEM_DESC = txtBE_Item_Desc.Text;
            Re_Exp.BE_QTY = txtBE_Qty.Text;
            Re_Exp.BE_UQC = txtBE_UQC.Text;
            Re_Exp.BE_ASS_VALUE = txt_Ass_Value.Text;
            Re_Exp.BE_DUTY_PAID = txt_Duty_paid.Text;
            Re_Exp.BE_DUTY_PAYMENT_DATE = txt_BE_Duty_payment_Date.Text == string.Empty ? null : txt_BE_Duty_payment_Date.Text;

            Re_Exp.BE_OTH_IDENTIFIABLE_PARAMETER = txt_BE_Oth_Ident_Parameter.Text;
            Re_Exp.BE_ASS_VALUE_CLAIM = txt_BE_Ass_Value_Claim.Text;
            Re_Exp.BE_ITEM_USED_Y_N = Rd_BE_Item_Used.Text;
            Re_Exp.COMMISIONER_PERMISSION_Y_N = Rd_Commisioner_Perm_Y_N.SelectedValue.ToString();
            Re_Exp.INPUT_CREDIT_Y_N = Rd_Input_Credit_Y_N.SelectedValue.ToString();
            Re_Exp.PERSONAL_USED_Y_N = Rd_Personal_used_Y_N.SelectedValue.ToString();
            Re_Exp.MODVAT_AVAILED_Y_N = Rd_Modvat_availed_Y_N.SelectedValue.ToString();
            Re_Exp.MODVAT_REPAID_Y_N = Rd_Modvat_Repaid_Y_N.SelectedValue.ToString();
            Re_Exp.flag = flag;

            ds = Re_Exp.Re_Export_Details_insertupdate();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gv_ReExport.DataSource = ds.Tables[0];
                gv_ReExport.DataBind();
            }
            else
            {
                Empty_grid();
            }
            i = Re_Exp.result;
            Export.Exp_Job_Logs_All_Details(EXPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, "ReExport", flag, "Insert");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        
    }


    private void Empty_grid()
    {
        try
        {
            DataTable dt = new DataTable();
            gv_ReExport.DataSource = dt;
            gv_ReExport.DataBind();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ReExport_Details_insert_update("", "S");
            hdn_update_ReExport.Value = Convert.ToString(Re_Exp.UPDATE_ID);

            if (i == 1)
            {
                //-----------------------FOR USER RIGHTS--------------------------------//
                user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);
                PAGE_MODIFY = user_Create.PAGE_MODIFY;
                //---------------SAVE ONLY------------------//

                if (PAGE_MODIFY == "False")
                {
                    btnNew_Click(sender, e);
                }
                else
                {
                    btnUpdate.CssClass = "save";
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    btnSave.Focus();
                }
                //-----------------------FOR USER RIGHTS--------------------------------//
                ViewState["UPDATED_ID"] = null;
                Alert_msg("Re-Export Saved Successfully", "btnSave");
            }
            else
            {
                Alert_msg("Re-Export Not Saved", "btnSave");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void gv_ReExport_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["ReExport_ID"] = Convert.ToString(this.gv_ReExport.SelectedDataKey.Value);

            if (ViewState["ReExport_ID"] != "" && ViewState["ReExport_ID"] != null)
            {
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = ViewState["ReExport_ID"].ToString();
                hdn_update_ReExport.Value = ViewState["ReExport_ID"].ToString();

                btnUpdate.CssClass = "updates";
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = true;

                DataSet ds = new DataSet();
                Re_Exp.JOBNO = EXPORT_JOBNO;
                Re_Exp.INVOICE_SLNO = INVOICE_SLNO;
                Re_Exp.ITEM_SLNO = ITEM_SLNO;
                Re_Exp.RE_EXPORT_ID = ViewState["ReExport_ID"].ToString();
                Re_Exp.flag = "select_Row_Value";
                ds = Re_Exp.Re_Export_Details_insertupdate();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtSB_No.Text = ds.Tables[0].Rows[0]["SB_NO"].ToString();
                    txtSB_Date.Text = ds.Tables[0].Rows[0]["SB_DATE"].ToString();
                    txtSerial_No.Text = ds.Tables[0].Rows[0]["SLNO"].ToString();
                    txtBE_Site.Text = ds.Tables[0].Rows[0]["BE_SITE"].ToString();
                    txtBE_No.Text = ds.Tables[0].Rows[0]["BE_NO"].ToString();
                    txtBE_Date.Text = ds.Tables[0].Rows[0]["BE_DATE"].ToString();
                    txt_BE_Inv_no.Text = ds.Tables[0].Rows[0]["BE_INVOICE_NO"].ToString();
                    txtBE_Item.Text = ds.Tables[0].Rows[0]["BE_INVOICE_ITEM_NO"].ToString();
                    Rd_Manual_BE.SelectedValue = ds.Tables[0].Rows[0]["MANUAL_BE_Y_N"].ToString();
                    txtBE_Qty_Utilised.Text = ds.Tables[0].Rows[0]["BE_QTY_UTILISED"].ToString();
                    txtBE_Item_Desc.Text = ds.Tables[0].Rows[0]["BE_ITEM_DESC"].ToString();
                    txtBE_Qty.Text = ds.Tables[0].Rows[0]["BE_QTY"].ToString();
                    txtBE_UQC.Text = ds.Tables[0].Rows[0]["BE_UQC"].ToString();
                    txt_Ass_Value.Text = ds.Tables[0].Rows[0]["BE_ASS_VALUE"].ToString();
                    txt_Duty_paid.Text = ds.Tables[0].Rows[0]["BE_DUTY_PAID"].ToString();
                    txt_BE_Duty_payment_Date.Text = ds.Tables[0].Rows[0]["BE_DUTY_PAYMENT_DATE"].ToString();
                    txt_BE_Oth_Ident_Parameter.Text = ds.Tables[0].Rows[0]["BE_OTH_IDENTIFIABLE_PARAMETER"].ToString();
                    txt_BE_Ass_Value_Claim.Text = ds.Tables[0].Rows[0]["BE_ASS_VALUE_CLAIM"].ToString();
                    Rd_BE_Item_Used.Text = ds.Tables[0].Rows[0]["BE_ITEM_USED_Y_N"].ToString();
                    Rd_Commisioner_Perm_Y_N.SelectedValue = ds.Tables[0].Rows[0]["COMMISIONER_PERMISSION_Y_N"].ToString();
                    Rd_Input_Credit_Y_N.SelectedValue = ds.Tables[0].Rows[0]["INPUT_CREDIT_Y_N"].ToString();
                    Rd_Personal_used_Y_N.SelectedValue = ds.Tables[0].Rows[0]["PERSONAL_USED_Y_N"].ToString();
                    Rd_Modvat_availed_Y_N.SelectedValue = ds.Tables[0].Rows[0]["MODVAT_AVAILED_Y_N"].ToString();
                    Rd_Modvat_Repaid_Y_N.SelectedValue = ds.Tables[0].Rows[0]["MODVAT_REPAID_Y_N"].ToString();
                }
            }
            else
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btnNew.Visible = true;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        
    }
    protected void gv_ReImport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
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
                    e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                    e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_ReExport, "Select$" + e.Row.RowIndex.ToString()));
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            ReExport_Details_insert_update(hdn_update_ReExport.Value.ToString(), "U");

            if (i == 1)
            {
                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("Re-Export Updated Successfully", "btnUpdate");
                }
                else
                {
                    Alert_msg("Re-Export Saved Successfully", "btnUpdate");
                }
            }
            else
            {
                Alert_msg("Re-Export Not Saved", "btnUpdate");
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
            ReExport_Details_insert_update(hdn_update_ReExport.Value.ToString(), "D");

            if (Re_Exp.result > 0)
            {
                btnNew_Click(sender, e);
                Alert_msg("Re-Export Deleted");
            }
            else
            {
                Alert_msg("Re-Export Not Deleted");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void gv_ReImport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.CssClass = "header";

            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
                e.Row.CssClass = "normal";
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
                e.Row.CssClass = "alternate";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        
    }
    
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            Transaction Transact = new Transaction();
            txtSB_No.Focus();
            Transact.ResetFields(Page.Controls);

            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
            btnUpdate.CssClass = "updates";

            ViewState["UPDATED_ID"] = null;
            hdn_update_ReExport.Value = "";
            Gridbind_ReExport();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'RE-EXPORT', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'RE-EXPORT', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
   
}