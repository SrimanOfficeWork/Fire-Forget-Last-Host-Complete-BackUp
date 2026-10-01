using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class SW_Control_Details : ThemeClass
{
    AppSession aps = new AppSession();
    Transaction Transact = new Transaction();
    User_Creation user_Create = new User_Creation();
    SW_CONTROL SW = new SW_CONTROL();
    UserBO ObjUBO = new UserBO();

    DataSet dtuser = new DataSet();
    DataSet dss = new DataSet();
    ErrorLogs er = new ErrorLogs();

    public int i, Screen_Id;
    public string IMPORT_JOBNO, SW_ID, SELECT_BRANCH, currentuser;

    public string INVOICE_SLNO = "", ITEM_SLNO = "", INVOICE_NO = "", COMPANY_ID, Audit_YN = "";
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;

    public string JOB_LOCK, JOB_RELEASE;
    adminmaster Am = new adminmaster();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
            currentuser = Connection.Current_User();
            IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
            SELECT_BRANCH = Connection.Get_Company_Type();
            COMPANY_ID = Connection.COMPANYID();
            hdn_Jobno.Value = IMPORT_JOBNO;

            if (Connection.Audit_Logs(COMPANY_ID) == "Y")
            {
                Audit_YN = "Y";
            }

            if (!IsPostBack)
            {
                if (Session["BE_TYPE"].ToString() == "Ex-Bond")
                {
                    Sec65_Check();
                }
                else
                {
                    lblinvid.Text = "";
                    lblSEC65.Text = "";
                    btnaddnew.Visible = false;
                }

                if (!string.IsNullOrEmpty(Session["BE_No"].ToString()))
                {
                    div_AmendmentType.Visible = true;
                    //ddl_AmendmentType.SelectedValue = dt_Item.Tables[0].Rows[0]["AMENDMENT_TYPE"].ToString();
                }
            }

            if (Session["Q_Item_slno"] != null)
            {
                hdn_Normal_Bulk.Value = "B";
                //INVOICE_SLNO = Session["Invoice_SLNO"].ToString();
                ITEM_SLNO = Session["Q_Item_slno"].ToString();
                INVOICE_NO = Session["Invoice_NO"].ToString();
                INVOICE_SLNO = Session["Q_Item_slno"].ToString();
                hdn_Invslno.Value = INVOICE_SLNO;

                if (!IsPostBack)
                {
                    //----------------SETTING SCREEN PERMISSION---------------//
                    Screen_Id = 7;
                    Page_Rights(Screen_Id);
                    //----------------SETTING SCREEN PERMISSION---------------//

                    Gridbind_SW_Control();
                    Bind_COntrolCode();
                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                    btnNew.Visible = true;

                }
            }
            else
            {
                if (Session["ITEM_SLNO"] != null)
                {
                    hdn_Normal_Bulk.Value = "N";

                    if (Session["TRANSPORT_MODE"] != null)
                    {
                        hdfTransport_mode.Value = Session["TRANSPORT_MODE"].ToString();
                    }
                    INVOICE_SLNO = Session["Invoice_SLNO"].ToString();
                    ITEM_SLNO = Session["ITEM_SLNO"].ToString();
                    INVOICE_NO = Session["Invoice_NO"].ToString();
                    hdn_Invslno.Value = INVOICE_SLNO;
                    if (!IsPostBack)
                    {
                        //----------------SETTING SCREEN PERMISSION---------------//
                        Screen_Id = 7;
                        Page_Rights(Screen_Id);
                        //----------------SETTING SCREEN PERMISSION---------------//

                        Gridbind_SW_Control();
                        Bind_COntrolCode();
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


            txt_Cont_SLNO.Enabled = false;
            txt_Cont_MSR.Enabled = false;
            txt_Cont_UQC.Enabled = false;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void Bind_COntrolCode()
    {
        try
        {
            Am.SCHEME_IMPORT_CODE = "";
            Am.name = "Select_Control_Code";
            dss = Am.IMP_Single_Window();

            ddlCont_type_code.Items.Clear();
            ddlCont_type_code.DataSource = dss.Tables[0];
            ddlCont_type_code.DataTextField = "CTRL_CODE_DESC";
            ddlCont_type_code.DataValueField = "CTRL_CODE_DESC";
            ddlCont_type_code.DataBind();
            ddlCont_type_code.Items.Insert(0, "");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    public void Bind_ResultCode()
    {
        try
        {
            if (ddlCont_type_code.SelectedItem.ToString().Contains("SEC65"))
            {

                DataSet ds = new DataSet();
                ObjUBO.JOBNO = IMPORT_JOBNO;
                ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
                ObjUBO.ITEM_SLNO = ITEM_SLNO;
                ObjUBO.BRANCH_COMMON = SELECT_BRANCH;

                if (hdn_Normal_Bulk.Value == "B")
                {
                    ObjUBO.Ename = "SW_Info_CTH_NO_Bulk";
                }
                else
                {
                    ObjUBO.Ename = "SW_Info_CTH_NO";
                }

                ds = SW.SingleWindow_Select(ObjUBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txt_Cont_Result_Text.Text = ds.Tables[0].Rows[0]["CTH_NO"].ToString() + "|" + ds.Tables[0].Rows[0]["ITEM_DESCRIPTION"].ToString();
                }

                ddl_ResultCode.Visible = false;
                txt_Cont_ResultCode.Visible = true;

                txt_Cont_SLNO.Enabled = true;
                txt_Cont_MSR.Enabled = true;
                txt_Cont_UQC.Enabled = true;

                lbl_location.Text = "Warehouse Code";
                lbl_StartDate.Text = "Warehousing Date";
                lbl_EndDate.Text = "GST Invoice Date";
                lbl_Result_Text.Text = "CTH & Product Desc";
                lbl_ResultCode.Text = "GST Invoice No";

            }
            else if (ddlCont_type_code.SelectedItem.ToString().Contains("SEZ"))
            {
                ddl_ResultCode.Visible = false;
                txt_Cont_ResultCode.Visible = true;

                txt_Cont_SLNO.Enabled = true;
                txt_Cont_MSR.Enabled = true;
                txt_Cont_UQC.Enabled = true;
            }
            else
            {
                if (ddlCont_type_code.SelectedItem.ToString() != "")
                {
                    Am.SCHEME_IMPORT_CODE = ddlCont_type_code.SelectedItem.ToString().Substring(0, 6);
                }
                else
                {
                    Am.SCHEME_IMPORT_CODE = "";
                }
                Am.name = "Select_Result_Code";
                dtuser = Am.IMP_Single_Window();

                ddl_ResultCode.Items.Clear();
                ddl_ResultCode.DataSource = dtuser.Tables[0];
                ddl_ResultCode.DataTextField = "CTRL_CODE_DESC";
                ddl_ResultCode.DataValueField = "CTRL_CODE_DESC";
                ddl_ResultCode.DataBind();
                ddlCont_type_code.Items.Insert(0, "");

                ddl_ResultCode.Visible = true;
                txt_Cont_ResultCode.Visible = false;


                txt_Cont_SLNO.Enabled = false;
                txt_Cont_MSR.Enabled = false;
                txt_Cont_UQC.Enabled = false;

                lbl_location.Text = "Cont. Location";
                lbl_StartDate.Text = "Cont. Start Date";
                lbl_EndDate.Text = "Cont. End Date";
                lbl_Result_Text.Text = "Cont. Result Text";
                lbl_ResultCode.Text = "Cont. Result Code";
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void Bind_ControlCode_DropDownList(string Flag, string Code, string Type)
    {
        try
        {
            Am.SCHEME_IMPORT_CODE = Code;
            Am.name = Flag;
            dss = Am.IMP_Single_Window();

            if (dss.Tables[0].Rows.Count > 0)
            {
                if (Flag == "Select_DESC_CTRL_CODE")
                {
                    if (Type == "C")
                    {
                        ddlCont_type_code.Items.Remove(dss.Tables[0].Rows[0]["CTRL_CODE_DESC"].ToString());
                        ddlCont_type_code.Items.Insert(0, dss.Tables[0].Rows[0]["CTRL_CODE_DESC"].ToString());
                    }
                    else
                    {
                        ddl_ResultCode.Items.Remove(dss.Tables[0].Rows[0]["CTRL_CODE_DESC"].ToString());
                        ddl_ResultCode.Items.Insert(0, dss.Tables[0].Rows[0]["CTRL_CODE_DESC"].ToString());
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
                gv_ReImport.ToolTip = "You don't have permission to access";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void Gridbind_SW_Control()
    {
        try
        {
            ObjUBO.JOBNO = IMPORT_JOBNO;
            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
            ObjUBO.ITEM_SLNO = ITEM_SLNO;
            ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
            if (hdn_Normal_Bulk.Value == "B")
            {
                ObjUBO.Ename = "CONTROL_Bulk_Select";
            }
            else
            {
                ObjUBO.Ename = "CONTROL_Select";
            }
            dss = SW.SingleWindow_Select(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                gv_ReImport.DataSource = dss.Tables[0];
                gv_ReImport.DataBind();

                // ----Audit Modified Data -----------------------------------
                if (Audit_YN == "Y")
                {
                    Tbl_Filed_Modified_History(dss.Tables[1]);
                }
            }
            else
            {
                DataTable dt = new DataTable();
                gv_ReImport.DataSource = dt;
                gv_ReImport.DataBind();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    public void SW_CONTROL_insert_update(string SW_ID, string flag)
    {
        try
        {
            ObjUBO.SW_ID = SW_ID;
            ObjUBO.JOBNO = IMPORT_JOBNO;
            ObjUBO.ITEM_SLNO = ITEM_SLNO;
            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;

            //ObjUBO.CONTROL_TYPE_CODE = ddlCont_type_code.SelectedValue.ToString().Substring(0, 6);// hide on 28-06-2024 by Chithra

            string sp_str = "";
            if (ddlCont_type_code.SelectedItem.ToString().Contains("-"))
            {
                string[] sp = ddlCont_type_code.SelectedItem.ToString().Split('-');
                sp_str = sp[0].Trim();
            }
            ObjUBO.CONTROL_TYPE_CODE = sp_str;
            ObjUBO.CONTROL_LOCATION = txt_Cont_Location.Text;
            ObjUBO.CONTROL_START_DATE = txt_Cont_Start_Date.Text;
            ObjUBO.CONTROL_END_DATE = txt_Cont_End_Date.Text;

            if (sp_str == "SEC65" || sp_str == "SEZ")
            {
                //ddl_ResultCode.Visible = false;
                //txt_Cont_ResultCode.Visible = true;
                ObjUBO.CONTROL_RESULT_CODE = txt_Cont_ResultCode.Text;
            }
            else
            {
                ObjUBO.CONTROL_RESULT_CODE = ddl_ResultCode.SelectedValue.ToString().Substring(0, 8);
            }
            ObjUBO.CONTROL_RESULT_TEXT = txt_Cont_Result_Text.Text;

            ObjUBO.CONTROL_MSR = txt_Cont_MSR.Text;
            ObjUBO.CONTROL_UQC = txt_Cont_UQC.Text;
            ObjUBO.CONTROL_SLNO = txt_Cont_SLNO.Text;

            ObjUBO.flag = flag;
            ObjUBO.Ename = hdn_Normal_Bulk.Value.ToString();
            ObjUBO.AMENDMENT_TYPE = ddl_AmendmentType.SelectedValue;
            ObjUBO.AMENDMENT_STATUS = "";

            SW.SW_CONTROL_Details_Insert_Update(ObjUBO);

            i = SW.result;

            if (i == 1)
            {
                Transact.Imp_Job_Logs_All_Details(Connection.IMP_Jobno(), INVOICE_SLNO, ITEM_SLNO, "SW Control", flag, "Insert");
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
            SW_ID = "";
            SW_CONTROL_insert_update(SW_ID, "S");
            hdn_update_Reimport.Value = Convert.ToString(SW.UPDATE_ID);

            if (i == 1)
            {
                user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);
                PAGE_MODIFY = user_Create.PAGE_MODIFY;
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
                Alert_msg("SW Control Saved Successfully", "btnSave");
                Gridbind_SW_Control();
            }
            else if (i == 2)
            {
                Alert_msg("(004W01) Already Exist");

            }
            else
            {
                Alert_msg("SW Control Not Saved", "btnSave");
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
            ViewState["SW_CONTROL_ID"] = Convert.ToString(this.gv_ReImport.SelectedDataKey.Value);

            if (ViewState["SW_CONTROL_ID"] != "" && ViewState["SW_CONTROL_ID"] != null)
            {
                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = ViewState["SW_CONTROL_ID"].ToString();
                hdn_update_Reimport.Value = ViewState["SW_CONTROL_ID"].ToString();

                //FOR UPDATED SUCCESSFULLY
                btnUpdate.CssClass = "updates";
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = true;

                Bind_COntrolCode();
                Bind_ControlCode_DropDownList("Select_DESC_CTRL_CODE", gv_ReImport.SelectedRow.Cells[1].Text, "C");
                txt_Cont_Location.Text = gv_ReImport.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");

                if (gv_ReImport.SelectedRow.Cells[3].Text.Replace("&nbsp;", "") != "01/01/1900")
                {
                    txt_Cont_Start_Date.Text = gv_ReImport.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
                }
                else
                {
                    txt_Cont_Start_Date.Text = "";
                }

                if (gv_ReImport.SelectedRow.Cells[4].Text.Replace("&nbsp;", "") != "01/01/1900")
                {
                    txt_Cont_End_Date.Text = gv_ReImport.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
                }
                else
                {
                    txt_Cont_End_Date.Text = "";
                }

                Bind_ResultCode();
                Bind_ControlCode_DropDownList("Select_DESC_CTRL_CODE", gv_ReImport.SelectedRow.Cells[5].Text, "R");

                if (ddlCont_type_code.SelectedItem.ToString().Contains("SEC65") || ddlCont_type_code.SelectedItem.ToString().Contains("SEZ"))
                {
                    txt_Cont_ResultCode.Text = gv_ReImport.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
                }

                txt_Cont_Result_Text.Text = gv_ReImport.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
                txt_Cont_MSR.Text = gv_ReImport.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
                txt_Cont_UQC.Text = gv_ReImport.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
                txt_Cont_SLNO.Text = gv_ReImport.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
                ddl_AmendmentType.SelectedValue = gv_ReImport.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");

                // ----Audit Modified Data -----------------------------------
                if (Audit_YN == "Y")
                {
                    DataTable_Mapping_Controls((DataTable)ViewState["dt_Prev_Table"], "Y");
                }
                //------------------------------------------------------------
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

    protected void gv_ReImport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gv_ReImport.PageIndex = e.NewPageIndex;
            Gridbind_SW_Control();
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
                //  if Read Permiision given true for gridview enabled or Disabled----------//
                if (hdn_Grid_Disable.Value == "1")
                {
                    e.Row.Enabled = false;
                }
                else
                {
                    e.Row.Enabled = true;
                    e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                    //e.Row.Attributes["onmouseout"] = "this.style.background='white'";
                    e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_ReImport, "Select$" + e.Row.RowIndex.ToString()));
                }
                //  if Read Permiision given true for gridview enabled or Disabled----------//

                if (e.Row.Cells[3].Text == "01/01/1900")
                {
                    e.Row.Cells[3].Text = "";
                }
                if (e.Row.Cells[4].Text == "01/01/1900")
                {
                    e.Row.Cells[4].Text = "";
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
            SW_ID = hdn_update_Reimport.Value;
            SW_CONTROL_insert_update(SW_ID, "U");
            if (i == 1)
            {
                if (ViewState["UPDATED_ID"] != null)
                {
                    // ----Audit Modified Data -----------------------------------
                    if (Audit_YN == "Y")
                    {
                        Audit_Modified_DataTableComparer();
                    }
                    //------------------------------------------------------------
                    Alert_msg("SW Control Updated Successfully", "btnUpdate");
                }
                else
                {
                    Alert_msg("SW Control Saved Successfully", "btnUpdate");
                }
                Gridbind_SW_Control();
            }
            else
            {
                Alert_msg("SW Control Not Saved", "btnUpdate");
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
            ObjUBO.JOBNO = IMPORT_JOBNO;
            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
            ObjUBO.ITEM_SLNO = ITEM_SLNO;
            ObjUBO.SW_ID = ViewState["SW_CONTROL_ID"].ToString();
            ObjUBO.Ename = hdn_Normal_Bulk.Value.ToString();
            ObjUBO.flag = "D";
            SW.SW_CONTROL_Details_Insert_Update(ObjUBO);

            int ii = 0;
            ii = SW.result;

            if (ii > 0)
            {
                btnNew_Click(sender, e);
                Alert_msg("SW Control Deleted");

                Transact.Imp_Job_Logs_All_Details(Connection.IMP_Jobno(), INVOICE_SLNO, ITEM_SLNO, "SW Control", "D", "Insert");

            }
            else
            {
                Alert_msg("SW Control Not Deleted");
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
            Transact.ResetFields(Page.Controls);
            Bind_COntrolCode();
            Bind_ResultCode();
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
            btnUpdate.CssClass = "updates";

            ViewState["UPDATED_ID"] = null;
            hdn_update_Reimport.Value = "";

            Gridbind_SW_Control();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }

    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SW Control', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SW Control', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void ddlCont_type_code_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCont_type_code.SelectedItem.Text != string.Empty)
            {
                Bind_ResultCode();
            }
            else
            {
                ddl_ResultCode.Items.Clear();
                ddl_ResultCode.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddl_ResultCode.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void btn_bulk_Save_Click(object sender, EventArgs e)
    {
        try
        {
            int length = 0;
            lblBmsg.Text = "";
            MP_UE.Show();
            if (txt_Bulk_Warehouse_Code.Text != string.Empty)
            {
                if (txt_Bulk_Warehousing_Date.Text != string.Empty)
                {
                    if (txt_Bulk_GST_Inv_No.Text != string.Empty)
                    {
                        string invno = txt_Bulk_GST_Inv_No.Text;
                        if (invno.Length < 17)
                        {
                            if (txt_Bulk_Inv_Date.Text != string.Empty)
                            {

                                ObjUBO.JOBNO = IMPORT_JOBNO;
                                ObjUBO.INVOICE_SLNO = INVOICE_SLNO;

                                ObjUBO.CONTROL_LOCATION = txt_Bulk_Warehouse_Code.Text;
                                ObjUBO.CONTROL_START_DATE = txt_Bulk_Warehousing_Date.Text;
                                ObjUBO.CONTROL_RESULT_TEXT = txt_Bulk_GST_Inv_No.Text;
                                ObjUBO.CONTROL_END_DATE = txt_Bulk_Inv_Date.Text;

                                ObjUBO.flag = "BES";
                                ObjUBO.Ename = "";
                                SW.SW_CONTROL_Details_Insert_Update(ObjUBO);
                                i = SW.result;

                                if (i == 1)
                                {
                                    lblBmsg.Text = "(SEC65) Saved Successfully.";

                                    Transact.Imp_Job_Logs_All_Details(Connection.IMP_Jobno(), INVOICE_SLNO, "Bulk", "SW Control-Sec65", "S", "Insert");
                                }
                                else
                                {
                                    lblBmsg.Text = "(SEC65) Not Saved!";
                                }
                            }
                            else
                            {
                                lblBmsg.Text = "Enter Ur GST Inv. Date !";
                            }
                        }
                        else
                        {
                            lblBmsg.Text = "Enter Ur Correct  GST Inv. No !";
                        }
                    }
                    else
                    {
                        lblBmsg.Text = "Enter Ur GST Inv. No !";
                    }
                }
                else
                {
                    lblBmsg.Text = "Enter Ur Warehouse Date !";
                }
            }
            else
            {
                lblBmsg.Text = "Enter Ur Warehouse Code !";
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }


    private void Sec65_Check()
    {
        try
        {
            INVOICE_SLNO = Session["Invoice_SLNO"].ToString();

            lblinvid.Text = INVOICE_SLNO;
            DataSet ds = new DataSet();
            ObjUBO.JOBNO = IMPORT_JOBNO;
            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
            ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
            ObjUBO.Ename = "SW_Sec65_Check";
            ds = SW.SingleWindow_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    btnaddnew.Visible = true;
                }
                else
                {
                    btnaddnew.Visible = false;
                    lblSEC65.Text = "(SEC65) Saved all item(s) Successfully.";
                }
            }
            else
            {
                btnaddnew.Visible = false;
                lblSEC65.Text = "(SEC65) Saved all item(s) Successfully.";
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btn_Bulk_Delete_Click(object sender, EventArgs e)
    {
        lblBmsg.Text = "";
        MP_UE.Show();
        try
        {
            INVOICE_SLNO = Session["Invoice_SLNO"].ToString();
            DataSet ds = new DataSet();
            ObjUBO.JOBNO = IMPORT_JOBNO;
            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
            ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
            ObjUBO.Ename = "SW_Sec65_Delete_All";
            ds = SW.SingleWindow_Select(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblBmsg.Text = "(SEC65) deleted Successfully.";

                Transact.Imp_Job_Logs_All_Details(Connection.IMP_Jobno(), INVOICE_SLNO, "Bulk", "SW Control-Sec65", "D", "Insert");

            }
            else
            {
                lblBmsg.Text = "(SEC65) No Record Found.";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Tbl_Filed_Modified_History(DataTable dt_Curr_tbl_struct)
    {
        ViewState["dt_Prev_Table"] = dt_Curr_tbl_struct;
       // DataTable_Mapping_Controls((DataTable)ViewState["dt_Prev_Table"], "Y");
    }

    private void Audit_Modified_DataTableComparer()
    {
        try
        {
            DataTable dt_Prev = (DataTable)ViewState["dt_Prev_Table"];
            DataTable dt_m2 = dt_Prev.Clone();
            DataTable dt_modified = DataTable_Mapping_Controls(dt_m2, "N");
            DataTableComparer Dt_Change = new DataTableComparer();
            Dt_Change.GetMismatchedRowsFast(dt_Prev, dt_modified, "SW_CONTROL_ID", "SW Control", IMPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, currentuser, Connection.Current_Branch());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private DataTable DataTable_Mapping_Controls(DataTable dt_mapping, string SelectMode)
    {
        try
        {
            if (dt_mapping.Rows.Count > 0)
            {
                dt_mapping.Rows.Clear();
            }

            string sp_str = "";

            DataRow dr = dt_mapping.NewRow();
            dr["SW_CONTROL_ID"] = "";
            dr["INVOICE_SLNO"] = INVOICE_SLNO;
            dr["ITEM_SLNO"] = ITEM_SLNO;

            if (ddlCont_type_code.SelectedItem.ToString().Contains("-"))
            {
                string[] sp = ddlCont_type_code.SelectedItem.ToString().Split('-');
                sp_str = sp[0].Trim();
            }

            dr["CONTROL_TYPE_CODE"] = sp_str;
            dr["CONTROL_LOCATION"] = txt_Cont_Location.Text.Trim();
            dr["CONTROL_START_DATE"] = txt_Cont_Start_Date.Text;
            dr["CONTROL_END_DATE"] = txt_Cont_End_Date.Text;
            if (sp_str == "SEC65" || sp_str == "SEZ")
            {
                dr["CONTROL_RESULT_CODE"] = txt_Cont_ResultCode.Text;
            }
            else
            {
                dr["CONTROL_RESULT_CODE"] = ddl_ResultCode.SelectedValue.ToString().Substring(0, 8);
            }
            dr["CONTROL_RESULT_TEXT"] = txt_Cont_Result_Text.Text.Trim();
            dr["CONTROL_MSR"] = txt_Cont_MSR.Text;
            dr["CONTROL_UQC"] = txt_Cont_UQC.Text.Trim();
            dr["CONTROL_SLNO"] = txt_Cont_SLNO.Text.Trim();
            dr["AMENDMENT_TYPE"] = ddl_AmendmentType.SelectedValue;
            dt_mapping.Rows.Add(dr);


            if (SelectMode == "Y")
            {
                ViewState["dt_Prev_Table"] = dt_mapping;
            }

           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return dt_mapping;
    }
}