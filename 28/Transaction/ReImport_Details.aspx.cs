using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Transaction_ReImport_Details : ThemeClass
{
    Transaction Transact = new Transaction();
    User_Creation user_Create = new User_Creation();

    DataSet dss = new DataSet();
    public int i;
    
    DataTable dt = new DataTable();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();

    public string currentuser, currentbranch,Working_Period;

    public string a1, a2, a3, a4, a5, a6, IMPORT_JOBNO, REIMPORT_ID, FLAG, YEAR, SB_Date, Previous_Be_Date, COMPANY_IDD;
    public string INVOICE_SLNO = "", ITEM_SLNO = "", INVOICE_NO = "";
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public string SELECT_TYPE, SELECT_BRANCH, Audit_YN = "";
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            currentuser = Connection.Current_User();
            currentbranch = Connection.Current_Branch();

            Working_Period = Connection.WorkingPeriod();
            IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
            SELECT_BRANCH = Connection.Get_Company_Type();
            COMPANY_IDD = Connection.COMPANYID();


            if (Connection.Audit_Logs(COMPANY_IDD) == "Y")
            {
                Audit_YN = "Y";
            }

            if (Session["ITEM_SLNO"] != null)
            {
                if (Session["TRANSPORT_MODE"] != null)
                {
                    hdfTransport_mode.Value = Session["TRANSPORT_MODE"].ToString();
                }
                INVOICE_SLNO = Session["Invoice_SLNO"].ToString();
                ITEM_SLNO = Session["ITEM_SLNO"].ToString();
                INVOICE_NO = Session["Invoice_NO"].ToString();
                hdn_Customhouse_chk.Value = "Yes";

                if (!IsPostBack)
                {
                    CalendarExtender1.EndDate = DateTime.Today;
                    //----------------SETTING SCREEN PERMISSION---------------//
                    Screen_Id = 7;
                    Page_Rights(Screen_Id);
                    //----------------SETTING SCREEN PERMISSION---------------//

                    txtSB_No.Focus();
                    Gridbind_ReImport();

                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                    btn_save_new.Visible = true;
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
                    btn_save_new.Enabled = false;

                    btnNew.ToolTip = "This Job is Locked by Admin";
                    btnSave.ToolTip = "This Job is Locked by Admin";
                    btn_save_new.ToolTip = "This Job is Locked by Admin";
                    btnUpdate.ToolTip = "This Job is Locked by Admin";
                    btnDelete.ToolTip = "This Job is Locked by Admin";
                }
            }

            if (Session["USER_JOB_LOCK"].ToString() == "Yes")
            {
                if (currentuser.ToUpper() != Session["JOB_USER"].ToString().ToUpper())
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
                            btn_save_new.Enabled = false;

                            MP_U.Show();

                            lblUser_Msg.Text = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                            btnUpdate.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnDelete.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnNew.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnSave.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btn_save_new.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";


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
                btn_save_new.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                btnNew.ToolTip = "You don't have permission to access";
                btnSave.ToolTip = "You don't have permission to access";
                btn_save_new.ToolTip = "You don't have permission to access";
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
                    btn_save_new.Enabled = true;
                    btnNew.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                    btn_save_new.Enabled = false;
                    btnSave.ToolTip = "You don't have permission to access";
                    btn_save_new.ToolTip = "You don't have permission to access";
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
                gv_ReImport.ToolTip = "You don't have permission to access";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    public void Gridbind_ReImport()
    {
        try
        {
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.INVOICE_SLNO = INVOICE_SLNO;
            Transact.ITEM_SLNO = ITEM_SLNO;
            Transact.INVOICE_NO = INVOICE_NO.Replace("&amp;", "&");
            Transact.RE_IMPORT_ID = "0";
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            Transact.Ename = "select_con";
            dss = Transact.RetrieveAll_ReImport_Details();

            if (Audit_YN == "Y")
            {
                Tbl_Filed_Modified_History(dss.Tables[1]);
            }

            Grid_Empty();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }

    }
    public void Reimport_Details_insert_update(string RE_IMPORT_ID, string SB_DATE, string flag, string year)
    {
        try
        {
            Transact.RE_IMPORT_ID = RE_IMPORT_ID;
            Transact.JOBNO = IMPORT_JOBNO;

            Transact.ITEM_SLNO = ITEM_SLNO;
            Transact.INVOICE_NO = INVOICE_NO.Replace("&amp;", "&");

            Transact.INVOICE_SLNO = INVOICE_SLNO;
            Transact.SB_NO = txtSB_No.Text;
            Transact.SB_DATE = SB_DATE;
            Transact.PORT_EXPORT = txtPort_Export.Text.ToUpper();
            hdn_Customhouse_chk.Value = Set_Customs_House_Validation(txtPort_Export.Text);
            Transact.SB_INVOICE_NO = txtSB_InvoiceNo.Text;
            Transact.SB_INVOICE__ITEM_NO = txtSB_Invoice_ItemNo.Text;
            Transact.NOTN_NO = ddl_NOTN_No.SelectedValue;
            Transact.NOTN_SLNO = ddlreimp_ntnslno.SelectedValue;
            Transact.EXPORT_FREIGHT = txtExport_Freight.Text;
            Transact.EXPORT_INSURANCE = txtExport_Insurance.Text;
            Transact.CUSTOMS_DUTY = txtCustoms_Duty.Text;
            Transact.EXCISE_DUTY = txtExcise_Duty.Text;
            Transact.USER_ID = currentuser;
            Transact.BRANCH_CODE = currentbranch;
            Transact.flag = flag;
            Transact.YEAR = year;
            Transact.WORKING_PERIOD = Working_Period;
            Transact.BRANCH_COMMON = SELECT_BRANCH;

            gv_ReImport.DataSource = Transact.Re_Import_Details_insertupdate();
            gv_ReImport.DataBind();
            i = Transact.result;

            if (i == 1)
            {

                Transact.Imp_Job_Logs_All_Details(Connection.IMP_Jobno(), INVOICE_SLNO, ITEM_SLNO, "ReImport", flag, "Insert");
            }
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
            REIMPORT_ID = "";
            if (txtSB_Date.Text == "")
            {
                SB_Date = "01/01/1900";
            }
            else
            {
                SB_Date = txtSB_Date.Text;
            }
            FLAG = "S";
            YEAR = "";

            Reimport_Details_insert_update(REIMPORT_ID, SB_Date, FLAG, YEAR);
            hdn_update_Reimport.Value = Convert.ToString(Transact.UPDATE_ID);

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
                    btn_save_new.Visible = false;
                    btnSave.Focus();
                }
                //-----------------------FOR USER RIGHTS--------------------------------//
                ViewState["UPDATED_ID"] = null;
                Alert_msg("Re-Import Saved Successfully", "btnSave");
            }
            else
            {
                Alert_msg("Re-Import Not Saved", "btnSave");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void gv_ReImport_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["ReImport_ID"] = Convert.ToString(this.gv_ReImport.SelectedDataKey.Value);

            if (ViewState["ReImport_ID"] != "" && ViewState["ReImport_ID"] != null)
            {
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = ViewState["ReImport_ID"].ToString();
                hdn_update_Reimport.Value = ViewState["ReImport_ID"].ToString();

                btnUpdate.CssClass = "updates";
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btn_save_new.Visible = false;
                btnNew.Visible = true;

                txtSB_No.Text = gv_ReImport.SelectedRow.Cells[2].Text;
                txtSB_Date.Text = gv_ReImport.SelectedRow.Cells[3].Text.Replace("01/01/1900", "");
                txtPort_Export.Text = gv_ReImport.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
                hdn_Customhouse_chk.Value = Set_Customs_House_Validation(txtPort_Export.Text);

                txtSB_InvoiceNo.Text = gv_ReImport.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
                txtSB_Invoice_ItemNo.Text = gv_ReImport.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
                ddl_NOTN_No.SelectedValue = gv_ReImport.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
                ddlreimp_ntnslno.SelectedValue = gv_ReImport.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
                txtExport_Freight.Text = gv_ReImport.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
                txtExport_Insurance.Text = gv_ReImport.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
                txtCustoms_Duty.Text = gv_ReImport.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
                txtExcise_Duty.Text = gv_ReImport.SelectedRow.Cells[12].Text.Replace("&nbsp;", "");

                if (ddl_NOTN_No.SelectedValue == "045/2017" || ddl_NOTN_No.SelectedValue == "046/2017" || ddl_NOTN_No.SelectedValue == "047/2017")
                {
                    if (ddlreimp_ntnslno.SelectedValue == "1A" || ddlreimp_ntnslno.SelectedValue == "1B" || ddlreimp_ntnslno.SelectedValue == "1C" || ddlreimp_ntnslno.SelectedValue == "1D" || ddlreimp_ntnslno.SelectedValue == "1E")
                    {
                        txtExport_Freight.Enabled = false;
                        txtExport_Insurance.Enabled = false;
                        txtExport_Freight.Text = "";
                        txtExport_Insurance.Text = "";

                        txtCustoms_Duty.Enabled = true;
                        txtExcise_Duty.Enabled = true;


                    }
                    else if (ddlreimp_ntnslno.SelectedValue == "2" || ddlreimp_ntnslno.SelectedValue == "3")
                    {
                        txtExport_Freight.Enabled = true;
                        txtExport_Insurance.Enabled = true;


                        txtCustoms_Duty.Enabled = false;
                        txtExcise_Duty.Enabled = false;
                        txtCustoms_Duty.Text = "";
                        txtExcise_Duty.Text = "";

                    }
                    else if (ddlreimp_ntnslno.SelectedValue == "4" || ddlreimp_ntnslno.SelectedValue == "5")
                    {
                        txtExport_Freight.Enabled = false;
                        txtExport_Insurance.Enabled = false;
                        txtCustoms_Duty.Enabled = false;
                        txtExcise_Duty.Enabled = false;
                        //txtExport_Freight.Text = "";
                        //txtExport_Insurance.Text = "";
                        //txtCustoms_Duty.Text = "";
                        //txtExcise_Duty.Text = "";
                    }
                    else
                    {
                        txtExport_Freight.Enabled = true;
                        txtExport_Insurance.Enabled = true;
                        txtCustoms_Duty.Enabled = true;
                        txtExcise_Duty.Enabled = true;
                        //txtExport_Freight.Text = "";
                        //txtExport_Insurance.Text = "";
                        //txtCustoms_Duty.Text = "";
                        //txtExcise_Duty.Text = "";
                    }
                }
                else
                {
                    txtExport_Freight.Enabled = true;
                    txtExport_Insurance.Enabled = true;
                    txtCustoms_Duty.Enabled = true;
                    txtExcise_Duty.Enabled = true;
                    txtExport_Freight.Text = "";
                    txtExport_Insurance.Text = "";
                    txtCustoms_Duty.Text = "";
                    txtExcise_Duty.Text = "";
                }


                // ----Audit Modified Data -----------------------------------
                if (Audit_YN == "Y")
                {
                    DataTable_Mapping_Controls((DataTable)ViewState["dt_Prev_Table"]);
                }
                //------------------------------------------------------------
            }
            else
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btn_save_new.Visible = true;
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
                    e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_ReImport, "Select$" + e.Row.RowIndex.ToString()));
                }
                string MINDATE = "01/01/1900";
                if (e.Row.Cells[2].Text == MINDATE)
                {
                    if (Convert.ToDateTime(e.Row.Cells[2].Text) <= Convert.ToDateTime(MINDATE))
                        e.Row.Cells[2].Text = string.Empty;
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
            REIMPORT_ID = hdn_update_Reimport.Value;
            if (txtSB_Date.Text == "")
            {
                SB_Date = "01/01/1900";
            }
            else
            {
                SB_Date = txtSB_Date.Text;
            }
            FLAG = "U";
            YEAR = "";

            Reimport_Details_insert_update(REIMPORT_ID, SB_Date, FLAG, YEAR);

            if (i == 1)
            {
                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("Re-Import Updated Successfully", "btnUpdate");
                }
                else
                {
                    Alert_msg("Re-Import Saved Successfully", "btnUpdate");
                }


                // ----Audit Modified Data -----------------------------------
                if (Audit_YN == "Y")
                {
                    Audit_Modified_DataTableComparer();
                }
                //------------------------------------------------------------
            }
            else
            {
                Alert_msg("Re-Import Not Saved", "btnUpdate");
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
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.INVOICE_SLNO = INVOICE_SLNO;
            Transact.ITEM_SLNO = ITEM_SLNO;
            Transact.INVOICE_NO = INVOICE_NO.Replace("&amp;", "&");
            Transact.RE_IMPORT_ID = ViewState["ReImport_ID"].ToString();
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            Transact.Ename = "delete";
            dss=Transact.RetrieveAll_ReImport_Details();
            Grid_Empty();
            int ii = 0;
            ii = Transact.result;

            if (i == 1)
            {

                Transact.Imp_Job_Logs_All_Details(Connection.IMP_Jobno(), INVOICE_SLNO, ITEM_SLNO, "ReImport", "D", "Insert");
            }


            if (ii > 0)
            {
                btnNew_Click(sender, e);
                Alert_msg("Re-Import Deleted");
            }
            else
            {
                Alert_msg("Re-Import Not Deleted");
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
    public void Grid_Empty()
    {
        try
        {
            if (dss.Tables.Count > 0)
            {
                if (dss.Tables[0].Rows.Count > 0)
                {
                    gv_ReImport.DataSource = dss;
                    gv_ReImport.DataBind();
                }
                else
                {
                    gv_ReImport.DataSource = dt;//add empty row
                    gv_ReImport.DataBind();
                }
            }
            else
            {
                gv_ReImport.DataSource = dt;//add empty row
                gv_ReImport.DataBind();
            }
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
            txtSB_No.Focus();
            Transact.ResetFields(Page.Controls);

            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btn_save_new.Visible = true;
            btnNew.Visible = true;
            btnUpdate.CssClass = "updates";

            ViewState["UPDATED_ID"] = null;
            hdn_update_Reimport.Value = "";
            Gridbind_ReImport();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'RE-IMPORT', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'RE-IMPORT', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


    [System.Web.Services.WebMethod]
    public static string Set_Customs_House_Validation(string custid)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();

            Auto.Enamesearch = custid;
            Auto.Ename = "CUSTOM_HOUSE_MASTER";
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

            if (ds.Tables[0].Rows.Count > 0)
            {
                custid = "Yes";
            }
            else
            {
                custid = "No";
            }
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return custid;
    }

    protected void btn_save_new_Click(object sender, EventArgs e)
    {
        try
        {
            btnSave_Click(sender, e);
            if (i == 1)
            {
                btnNew_Click(sender, e);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    private void Tbl_Filed_Modified_History(DataTable dt_Curr_tbl_struct)
    {
        try
        {
            ViewState["dt_Prev_Table"] = dt_Curr_tbl_struct;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Audit_Modified_DataTableComparer()
    {
        try
        {
            DataTable dt_Prev = (DataTable)ViewState["dt_Prev_Table"];
            DataTable dt_m2 = dt_Prev.Clone();
            DataTable dt_modified = DataTable_Mapping_Controls(dt_m2);
            DataTableComparer Dt_Change = new DataTableComparer();
            Dt_Change.GetMismatchedRowsFast(dt_Prev, dt_modified, "RE_IMPORT_ID", "ReImport", IMPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, currentuser, Connection.Current_Branch());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private DataTable DataTable_Mapping_Controls(DataTable dt_mapping)
    {
        try
        {
            if (dt_mapping.Rows.Count > 0)
            {
                dt_mapping.Rows.Clear();
            }

            DataRow dr = dt_mapping.NewRow();
            dr["RE_IMPORT_ID"] = hdn_update_Reimport.Value;
            dr["INVOICE_SLNO"] = INVOICE_SLNO;
            dr["INVOICE_NO"] = INVOICE_NO;
            dr["ITEM_SLNO"] = ITEM_SLNO;
            dr["SB_NO"] = txtSB_No.Text;
            dr["SB_DATE"] = txtSB_Date.Text;
            dr["SB_INVOICE_NO"] = txtSB_InvoiceNo.Text;
            dr["SB_INVOICE__ITEM_NO"] = txtSB_Invoice_ItemNo.Text;
            dr["PORT_EXPORT"] = txtPort_Export.Text;
            dr["NOTN_NO"] = ddl_NOTN_No.SelectedValue;
            dr["NOTN_SLNO"] = ddlreimp_ntnslno.SelectedValue;
            dr["EXPORT_FREIGHT"] = txtExport_Freight.Text;
            dr["EXPORT_INSURANCE"] = txtExport_Insurance.Text;
            dr["CUSTOMS_DUTY"] = txtCustoms_Duty.Text;
            dr["EXCISE_DUTY"] = txtExcise_Duty.Text;

            dt_mapping.Rows.Add(dr);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return dt_mapping;
    }

}