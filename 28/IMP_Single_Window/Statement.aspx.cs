using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;

public partial class Statement : ThemeClass
{
    Transaction Transact = new Transaction();
    SW_STMT stmt = new SW_STMT();
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();
    UserBO ObjUBO = new UserBO();
    ErrorLogs er = new ErrorLogs();
    
    public int i;

    public string IMPORT_JOBNO, SW_ID,currentuser,SELECT_BRANCH;
    public string INVOICE_SLNO = "", ITEM_SLNO = "", INVOICE_NO = "", S_BULK = "", COMPANY_ID, Audit_YN = "";
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
   
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            currentuser = Connection.Current_User();
            IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
            SELECT_BRANCH = Connection.Get_Company_Type();
            COMPANY_ID = Connection.COMPANYID();
            hdn_jobno.Value = IMPORT_JOBNO;

            if (Connection.Audit_Logs(COMPANY_ID) == "Y")
            {
                Audit_YN = "Y";
            }

            if (Session["Q_Item_slno"] != null)
            {
                ITEM_SLNO = Session["Q_Item_slno"].ToString();
                INVOICE_NO = Session["Invoice_NO"].ToString();
                INVOICE_SLNO = Session["Q_Item_slno"].ToString();
                S_BULK = "Bulk";
                if (!IsPostBack)
                {
                    //----------------SETTING SCREEN PERMISSION---------------//
                    Screen_Id = 7;
                    Page_Rights(Screen_Id);
                    //----------------SETTING SCREEN PERMISSION---------------//
                    Gridbind_SW_STMT();

                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                    btn_save_new.Visible = true;
                    btnNew.Visible = true;

                    btn_item_delete.Visible = false;
                    btn_inv_delete.Visible = false;
                    btn_job_delete.Visible = false;
                    btn_Auto_feed.Visible = false;
                }
            }
            else
            {
                if (Session["ITEM_SLNO"] != null)
                {
                    if (Session["TRANSPORT_MODE"] != null)
                    {
                        hdfTransport_mode.Value = Session["TRANSPORT_MODE"].ToString();
                    }
                    INVOICE_SLNO = Session["Invoice_SLNO"].ToString();
                    ITEM_SLNO = Session["ITEM_SLNO"].ToString();
                    INVOICE_NO = Session["Invoice_NO"].ToString();
                    S_BULK = "Single";
                    if (!IsPostBack)
                    {
                        //----------------SETTING SCREEN PERMISSION---------------//
                        Screen_Id = 7;
                        Page_Rights(Screen_Id);
                        //----------------SETTING SCREEN PERMISSION---------------//
                        Gridbind_SW_STMT();

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

                    btn_item_delete.Enabled = false;
                    btn_inv_delete.Enabled = false;
                    btn_job_delete.Enabled = false;

                    string msg = "This Job is Locked by Admin";

                    btnNew.ToolTip = msg;
                    btnSave.ToolTip = msg;
                    btn_save_new.ToolTip = msg;
                    btnUpdate.ToolTip = msg;
                    btnDelete.ToolTip = msg;
                    btn_item_delete.ToolTip = msg;
                    btn_inv_delete.ToolTip = msg;
                    btn_job_delete.ToolTip = msg;
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
                            btn_item_delete.Enabled = false;
                            btn_inv_delete.Enabled = false;
                            btn_job_delete.Enabled = false;

                            string msg = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                            lblUser_Msg.Text = msg;
                            btnUpdate.ToolTip = msg;
                            btnDelete.ToolTip = msg;
                            btnNew.ToolTip = msg;
                            btnSave.ToolTip = msg;
                            btn_save_new.ToolTip = msg;

                            btn_item_delete.ToolTip = msg;
                            btn_inv_delete.ToolTip = msg;
                            btn_job_delete.ToolTip = msg;
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

                btn_item_delete.Enabled = false;
                btn_inv_delete.Enabled = false;
                btn_job_delete.Enabled = false;

                string msg = "You don't have permission to access";

                btnNew.ToolTip = msg;
                btnSave.ToolTip = msg;
                btn_save_new.ToolTip = msg;
                btnUpdate.ToolTip = msg;
                btnDelete.ToolTip = msg;
                hdn_Grid_Disable.Value = "1";
                btn_item_delete.ToolTip = msg;
                btn_inv_delete.ToolTip = msg;
                btn_job_delete.ToolTip = msg;
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
    public void Gridbind_SW_STMT()
    {
        try
        {
            DataSet dss = new DataSet();
            ObjUBO.JOBNO = IMPORT_JOBNO;
            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
            ObjUBO.ITEM_SLNO = ITEM_SLNO;
            ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
            if (S_BULK == "Bulk")
            {
                ObjUBO.Ename = "STATEMENT_Bulk_Select";
            }
            else
            {
                ObjUBO.Ename = "STATEMENT_Select";

            }
            dss = stmt.SingleWindow_Select(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                gv_ReImport.DataSource = dss;
                gv_ReImport.DataBind();

                // ----Audit Modified Data -----------------------------------
                if (Audit_YN == "Y")
                {
                    Tbl_Filed_Modified_History(dss.Tables[2]);
                    DataTable_Mapping_Controls((DataTable)ViewState["dt_Prev_Table"], "Y");
                }
                //------------------------------------------------------------
            }
            else
            {
                DataTable dt = new DataTable();
                gv_ReImport.DataSource = dt;//add empty row
                gv_ReImport.DataBind();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void SW_Statement_insert_update(string SW_ID, string flag)
    {
        try
        {
            ObjUBO.SW_STMT_ID = SW_ID;
            ObjUBO.JOBNO = IMPORT_JOBNO;
            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
            ObjUBO.ITEM_SLNO = ITEM_SLNO;

            ObjUBO.STMT_DECLARATION_TYPE = txt_stmt_Declaration_Type.Text;
            ObjUBO.STMT_DECLARATION_NUMBER = txt_stmt_Declaration_No.Text;
            ObjUBO.STMT_DECLARATION_DATE = txt_stmt_Declaration_Date.Text;
            ObjUBO.STMT_TYPE = txt_Statement_Type.Text;
            ObjUBO.STMT_CODE = txt_Statement_Code.Text.ToUpper();
            ObjUBO.STMT_TEXT = txt_Statement_Text.Text;

            ObjUBO.USER_ID = currentuser;
            ObjUBO.BRANCH_CODE = Connection.Current_Branch();
            ObjUBO.Ename = flag;
            ObjUBO.I_U_TYPE = "";
            ObjUBO.WORKING_PERIOD = Connection.WorkingPeriod();
            ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
            stmt.SW_Statement(ObjUBO, S_BULK);

            i = stmt.result;

            Transact.Imp_Job_Logs_All_Details(Connection.IMP_Jobno(), INVOICE_SLNO, ITEM_SLNO, "SW Statement", flag, "Insert");
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
            SW_Statement_insert_update("", "S");
            hdn_update_STMT.Value = Convert.ToString(stmt.UPDATE_ID);

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
                Alert_msg("SW Statement Saved Successfully", "btnSave");
                Gridbind_SW_STMT();
            }  
            else
            {
                Alert_msg("SW Statement Not Saved", "btnSave");
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
            ViewState["SW_STMT_ID"] = Convert.ToString(this.gv_ReImport.SelectedDataKey.Value);

            if (ViewState["SW_STMT_ID"] != "" && ViewState["SW_STMT_ID"] != null)
            {
                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = ViewState["SW_STMT_ID"].ToString();
                hdn_update_STMT.Value = ViewState["SW_STMT_ID"].ToString();

                //FOR UPDATED SUCCESSFULLY
                btnUpdate.CssClass = "updates";
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btn_save_new.Visible = false;
                btnNew.Visible = true;
                txt_Statement_Type.Text = gv_ReImport.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
                txt_Statement_Code.Text = gv_ReImport.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
                txt_Statement_Text.Text = gv_ReImport.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");

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
            SW_ID = hdn_update_STMT.Value;
            SW_Statement_insert_update(SW_ID, "U");

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
                    Alert_msg("SW Statement Updated Successfully", "btnUpdate");
                }
                else
                {
                    Alert_msg("SW Statement Saved Successfully", "btnUpdate");
                }
                Gridbind_SW_STMT();
                
            }
            else
            {
                Alert_msg("SW Statement Not Saved", "btnUpdate");

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
            /*
            ObjUBO.JOBNO = IMPORT_JOBNO;
            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
            ObjUBO.ITEM_SLNO = ITEM_SLNO;
            ObjUBO.DELETE_ID = ViewState["SW_STMT_ID"].ToString();
            ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
            SW_Statement_insert_update(ObjUBO.DELETE_ID, "D");
            
            int ii = 0;
            ii = stmt.result;

            if (ii > 0)
            {
                btnNew_Click(sender, e);
                Alert_msg("SW Statement Deleted");
            }
            else
            {
                Alert_msg("SW Statement Not Deleted");
            }

            Gridbind_SW_STMT();
            */
            Delete("D");
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
   

    /*
    protected void btn_item_delete_Click(object sender, EventArgs e)
    {
        Delete("Item_Delete");
    }
    protected void btn_inv_delete_Click(object sender, EventArgs e)
    {
        Delete("Inv_Delete");
    }
    protected void btn_job_delete_Click(object sender, EventArgs e)
    {
        Delete("Job_Delete");
    }
    */

    
    private void Delete(string Del_flag)
    {
        try
        {
            ObjUBO.JOBNO = IMPORT_JOBNO;
            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
            ObjUBO.ITEM_SLNO = ITEM_SLNO;
            if (Del_flag == "D")
            {
                ObjUBO.DELETE_ID = ViewState["SW_STMT_ID"].ToString();
            }
            ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
            SW_Statement_insert_update(ObjUBO.DELETE_ID, Del_flag);

            int ii = 0;
            ii = stmt.result;

            if (ii > 0)
            {
                Transact.ResetFields(Page.Controls);
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btn_save_new.Visible = true;
                btnNew.Visible = true;
                btnUpdate.CssClass = "updates";

                ViewState["UPDATED_ID"] = null;
                hdn_update_STMT.Value = "";

                Alert_msg("SW Statement Deleted");

            }
            else
            {
                Alert_msg("SW Statement Not Deleted");
            }
            Gridbind_SW_STMT();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    protected void QS_RowCreated(object sender, GridViewRowEventArgs e)
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
    protected void QS_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ForeColor = System.Drawing.Color.Black;
                e.Row.BackColor = System.Drawing.Color.Gray;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
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
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btn_save_new.Visible = true;
            btnNew.Visible = true;
            btnUpdate.CssClass = "updates";

            ViewState["UPDATED_ID"] = null;
            hdn_update_STMT.Value = "";
            Gridbind_SW_STMT();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SW Statement', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SW Statement', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    [System.Web.Services.WebMethod]
    public static string GetSingleWindow_statement_bind(string custid, string custid1)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            adminmaster ADM = new adminmaster();
            ADM.SCHEME_NOTN = custid1;
            ADM.SCHEME_IMPORT_CODE = custid;
            ADM.name = "Select_Statement_Code_QS";
            ds = ADM.IMP_Single_Window();
            if (ds.Tables[0].Rows.Count > 0)
            {
                string STATEMENT_DESC = ds.Tables[0].Rows[0]["STATEMENT_DESC"].ToString();
                custid = STATEMENT_DESC;
            }
            else
            {
                custid = string.Empty;
            }
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return custid;
    }

    protected void txt_Statement_Code_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txt_Statement_Type.Text != string.Empty && txt_Statement_Code.Text != string.Empty)
            {
                if (txt_Statement_Code.Text.Length >= 5)
                {
                    Auto_Search Auto = new Auto_Search();
                    DataSet ds = new DataSet();
                    adminmaster ADM = new adminmaster();

                    string[] add = txt_Statement_Code.Text.Split('-');

                    ADM.SCHEME_NOTN = txt_Statement_Type.Text;
                    ADM.SCHEME_IMPORT_CODE = add[0];
                    ADM.name = "Select_Statement_Text";
                    ds = ADM.IMP_Single_Window();


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txt_Statement_Code.Text = add[0];
                        txt_Statement_Text.Text = ds.Tables[0].Rows[0]["STATEMENT_DESC"].ToString();
                    }
                    else
                    {
                        txt_Statement_Text.Text = string.Empty;
                    }
                    txt_Statement_Text.Focus();
                }
                else
                {
                    txt_Statement_Code.Focus();
                }
            }
            else
            {
                txt_Statement_Text.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    
    protected void btn_item_delete_Click(object sender, EventArgs e)
    {
        try
        {
            Delete("Item_Delete");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    protected void btn_inv_delete_Click(object sender, EventArgs e)
    {
        try
        {
            Delete("Inv_Delete");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    protected void btn_job_delete_Click(object sender, EventArgs e)
    {
        try
        {
            Delete("Job_Delete");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    protected void btn_Auto_feed_Click(object sender, EventArgs e)
    {
        try
        {
            ObjUBO.JOBNO = IMPORT_JOBNO;
            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
            ObjUBO.ITEM_SLNO = ITEM_SLNO;

            ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
            SW_Statement_insert_update(ObjUBO.DELETE_ID, "Auto_feed_data");

            int ii = 0;
            ii = stmt.result;

            if (ii > 0)
            {
                Transact.ResetFields(Page.Controls);
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btn_save_new.Visible = true;
                btnNew.Visible = true;

                ViewState["UPDATED_ID"] = null;
                hdn_update_STMT.Value = "";

                Alert_msg("SW Statement Saved Successfully");
            }
            else
            {
                Alert_msg("SW Statement Not Saved");
            }
            Gridbind_SW_STMT();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }


    protected void btn_Bulk_STMT_Copy_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_Statement_Type.Text == "REM")
            {
                DataSet dss = new DataSet();
                ObjUBO.JOBNO = IMPORT_JOBNO;
                ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
                ObjUBO.ITEM_SLNO = ITEM_SLNO;
                ObjUBO.STMT_CODE = txt_Statement_Code.Text;
                ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
                ObjUBO.Ename = "Copy";
                dss = stmt.GET_IMP_SW_STMT_BULK_COPY(ObjUBO);

                if (stmt.result == 1)
                {
                    Alert_msg("Copied Successfully");
                    Gridbind_SW_STMT();
                }
            }
            else
            {
                Alert_msg("Statement Code - Should be 'REM' Mandatory");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void btn_Bulk_STMT_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_Statement_Type.Text != "")
            {
                DataSet dss = new DataSet();
                ObjUBO.JOBNO = IMPORT_JOBNO;
                ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
                ObjUBO.ITEM_SLNO = ITEM_SLNO;
                ObjUBO.STMT_CODE = txt_Statement_Code.Text;
                ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
                ObjUBO.Ename = "Delete";
                dss = stmt.GET_IMP_SW_STMT_BULK_COPY(ObjUBO);

                if (stmt.result == 1)
                {
                    Alert_msg("Deleted Successfully");
                    Gridbind_SW_STMT();
                    txt_Statement_Type.Text = "";
                    txt_Statement_Code.Text = "";
                    txt_Statement_Text.Text = "";

                }
            }
            else
            {
                Alert_msg("Statement Code - Should be Mandatory");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
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
            er.makeLog(ex.Message);
            
        }
    }

    private void Tbl_Filed_Modified_History(DataTable dt_Curr_tbl_struct)
    {
        ViewState["dt_Prev_Table"] = dt_Curr_tbl_struct;
    }

    private void Audit_Modified_DataTableComparer()
    {
        try
        {
            DataTable dt_Prev = (DataTable)ViewState["dt_Prev_Table"];
            DataTable dt_m2 = dt_Prev.Clone();
            DataTable dt_modified = DataTable_Mapping_Controls(dt_m2, "N");
            DataTableComparer Dt_Change = new DataTableComparer();
            Dt_Change.GetMismatchedRowsFast(dt_Prev, dt_modified, "SW_ID", "SW Statement", IMPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, currentuser, Connection.Current_Branch());
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

            DataRow dr = dt_mapping.NewRow();
            dr["SW_ID"] = hdn_update_STMT.Value;
            dr["INVOICE_SLNO"] = INVOICE_SLNO;
            dr["ITEM_SLNO"] = ITEM_SLNO;

            dr["STMT_TYPE"] = txt_Statement_Type.Text.Trim();
            dr["STMT_CODE"] = txt_Statement_Code.Text.Trim();
            dr["STMT_TEXT"] = txt_Statement_Text.Text.Trim();

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