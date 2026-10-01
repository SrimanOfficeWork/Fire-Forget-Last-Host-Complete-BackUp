using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Export_Export_Quota_Details : ThemeClass
{
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;

    AppSession aps = new AppSession();
    EXP_Quota EQ = new EXP_Quota();
    ErrorLogs er = new ErrorLogs();
    User_Creation user_Create = new User_Creation();
    DataSet dtuser = new DataSet();
    Export_General_New Export = new Export_General_New();
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public string EXPORT_JOBNO, a1, a2, a3, Item_SLNo, item_slno, invoice_slno, item_id, flag;

    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE, INV_SLN0, ITEM_SLNO, Audit_YN = "";


    public int i;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            currentuser = Session["currentuser"].ToString();
            currentbranch = Session["currentbranch"].ToString();
            currentcomp_name = Session["currentcomp_name"].ToString();
            comp_ConnectionStr = Session["currentcomp_db"].ToString();
            Working_Period = Session["WorkingPeriod"].ToString();
            LoginDate = Session["LoginDate"].ToString();
            // commented for areawise implementation on 05-mar-2020
            /*
            if (Session["SELECT_TYPE"] != null)
            {
                SELECT_TYPE = Session["SELECT_TYPE"].ToString();

                if (SELECT_TYPE == "Branchwise Job")
                {
                    SELECT_BRANCH = currentbranch;
                }
                else
                {
                    SELECT_BRANCH = "";
                }
            }
            else
            {
                SELECT_BRANCH = "";
            }
              * */
            SELECT_BRANCH = Connection.Get_Company_Type();


            if (Connection.Audit_Logs(Connection.COMPANYID()) == "Y")
            {
                Audit_YN = "Y";
            }

            if (Session["EXPORT_JOBNO"] != null)
            {
                EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();

                if (Session["Inv_SL_No"] != null)
                {
                    INV_SLN0 = Session["Inv_SL_No"].ToString();
                    ITEM_SLNO = Session["Item_SLNo"].ToString();
                }
                else
                {
                    Response.Write("<script>window.open('Item_Details.aspx','_parent');</script>");
                }

                if (!IsPostBack)
                {

                    //----------------SETTING SCREEN PERMISSION---------------//
                    Screen_Id = 11;
                    Page_Rights(Screen_Id);
                    //----------------SETTING SCREEN PERMISSION---------------//
                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                    btnNew.Visible = true;

                    BindValue();
                    txtAgency_code.Focus();
                }

            }
            else
            {

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
            }
            else
            {


                //}
                //btnNew.Enabled = true;
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
                    btnUpdate.Enabled = true;
                else
                {
                    btnUpdate.Enabled = false;
                    btnUpdate.ToolTip = "You don't have permission to access";

                }
                //---------------DELETE BUTTON------------------//

                if (PAGE_DELETE == "True")
                    btnDelete.Enabled = true;
                else
                {
                    btnDelete.Enabled = false;
                    btnDelete.ToolTip = "You don't have permission to access";

                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public DataSet BindValue()
    {
        EQ.QUOTA_ID = "";
        EQ.JOBNO = EXPORT_JOBNO;
        EQ.INVOICE_SLNO = INV_SLN0;
        EQ.ITEM_SLNO = ITEM_SLNO;
        EQ.Ename = "Select";

        dtuser = EQ.Export_Quota_details_insertupdate();
        gv_guota.DataSource = dtuser;
        gv_guota.DataBind();

        // ----Audit Modified Data -----------------------------------
        if (Audit_YN == "Y")
        {
            DataTable dt_main = dtuser.Tables[0].Clone();
            Tbl_Filed_Modified_History(dt_main);
        }

        return dtuser;
        gv_guota.Attributes.Add("style", "table-layout:fixed");
    }

    protected void gv_guota_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    protected void gv_guota_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //ViewState["JOBBING_ID"] = Convert.ToString(this.gv_guota.SelectedDataKey.Value);
            ViewState["guota_id"] = Convert.ToString(this.gv_guota.SelectedDataKey.Value);

            if (ViewState["guota_id"] != "" && ViewState["guota_id"] != null)
            {
                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = ViewState["guota_id"].ToString();
                hdn_update_guota_id.Value = ViewState["guota_id"].ToString();

                btnUpdate.CssClass = "updates";

                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = true;

                txtAgency_code.Text = gv_guota.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
                txtAgency_Name.Text = gv_guota.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
                txtalloc_No.Text = gv_guota.SelectedRow.Cells[5].Text.Replace("01/01/1900", "");
                txtexp_date.Text = gv_guota.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");

                // ----Audit Modified Data -----------------------------------
                if (Audit_YN == "Y")
                {
                    DataTable_Mapping_Controls((DataTable)ViewState["dt_Prev_Table"]);
                }
            }
            else
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    protected void gv_guota_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_guota, "Select$" + e.Row.RowIndex.ToString()));
                }
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

            Quota_Details_insert_update("", "S");
            hdn_update_guota_id.Value = Convert.ToString(EQ.Update_id);

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
                Alert_msg("Quota Saved Successfully", "btnSave");
            }
            else
            {
                Alert_msg("Quota Not Saved", "btnSave");
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
            txtAgency_code.Text = string.Empty;
            txtAgency_Name.Text = string.Empty;
            txtalloc_No.Text = string.Empty;
            txtexp_date.Text = string.Empty;

            txtAgency_code.Focus();
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnUpdate.CssClass = "updates";

            ViewState["UPDATED_ID"] = null;
            hdn_update_guota_id.Value = "";
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

            Quota_Details_insert_update(hdn_update_guota_id.Value, "U");

            if (i == 1)
            {
                // ----Audit Modified Data -----------------------------------
                if (Audit_YN == "Y")
                {
                    Audit_Modified_DataTableComparer();
                }
                //------------------------------------------------------------


                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("Quota Updated Successfully", "btnUpdate");
                }
                else
                {
                    Alert_msg("Quota Saved Successfully", "btnUpdate");
                }
            }
            else
            {
                Alert_msg("Quota Not Saved", "btnSave");
            }
        }

        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void Quota_Details_insert_update(string QUOTA_ID, string flag)
    {
        try
        {
            if (txtAgency_code.Text != string.Empty)
            {
                //---------------------SCHEME CODE TO SAVE IN LICENSE DETAILS----------------------------------------//
                EQ.QUOTA_ID = QUOTA_ID;
                EQ.JOBNO = EXPORT_JOBNO;
                EQ.INVOICE_SLNO = INV_SLN0;
                EQ.ITEM_SLNO = ITEM_SLNO;
                EQ.AGENCY_CODE = txtAgency_code.Text;
                EQ.AGENCY_NAME = txtAgency_Name.Text;
                EQ.ALLOCATION_NO = txtalloc_No.Text;
                EQ.EXPIRY_DATE = txtexp_date.Text;
                EQ.flag = flag;
                EQ.Ename = "INS_UPD";

                EQ.USER_ID = currentuser;
                EQ.BRANCH_CODE = currentbranch;
                EQ.WORKING_PERIOD = Working_Period;
                EQ.BRANCH_COMMON = SELECT_BRANCH;

                DataSet dss;
                dss = EQ.Export_Quota_details_insertupdate();
                i = EQ.result;
                Export.Exp_Job_Logs_All_Details(EXPORT_JOBNO, INV_SLN0, ITEM_SLNO, "Quota", flag, "Insert");
                if (i != 2)
                {
                    gv_guota.DataSource = dss;
                    gv_guota.DataBind();
                }
            }
            else
            {
                Alert_msg("Enter the Agency Code.", "txtAgency_code");
            }

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            EQ.QUOTA_ID = hdn_update_guota_id.Value.ToString();
            EQ.JOBNO = EXPORT_JOBNO;
            EQ.INVOICE_SLNO = INV_SLN0;
            EQ.ITEM_SLNO = ITEM_SLNO;
            EQ.Ename = "Delete";

            gv_guota.DataSource = EQ.Export_Quota_details_insertupdate();
            gv_guota.DataBind();
            int ii = 0;
            ii = EQ.result;

            if (ii > 0)
            {
                btnNew_Click(sender, e);
                Alert_msg("Quota Deleted");
                Export.Exp_Job_Logs_All_Details(EXPORT_JOBNO, INV_SLN0, ITEM_SLNO, "Quota", "D", "Insert");
            }
            else
            {
                Alert_msg("Quota Not Deleted");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'JOBBING', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'JOBBING', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


    #region Export Audit Logs

    private void Tbl_Filed_Modified_History(DataTable dt_Curr_tbl_struct)
    {
        try
        {
            ViewState["dt_Prev_Table"] = dt_Curr_tbl_struct;
            DataTable_Mapping_Controls(dt_Curr_tbl_struct);
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
            Dt_Change.GetMismatchedRowsFast_EXP(dt_Prev, dt_modified, "QUOTA_ID", "Quota", EXPORT_JOBNO, INV_SLN0, ITEM_SLNO, currentuser, currentbranch);
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

            dr["QUOTA_ID"] = hdn_update_guota_id.Value;        // Hidden field if available
            dr["JOBNO"] = EXPORT_JOBNO;
            dr["INVOICE_SLNO"] = INV_SLN0;
            dr["ITEM_SL_NO"] = ITEM_SLNO;
            dr["AGENCY_CODE"] = txtAgency_code.Text;
            dr["AGENCY_NAME"] = txtAgency_Name.Text;
            dr["ALLOCATION_NO"] = txtalloc_No.Text;
            dr["EXPIRY_DATE"] = txtexp_date.Text;

            dt_mapping.Rows.Add(dr);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return dt_mapping;
    }

    #endregion
}