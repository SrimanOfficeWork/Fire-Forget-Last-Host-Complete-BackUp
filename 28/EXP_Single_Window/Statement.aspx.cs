using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Statement : ThemeClass
{
    Transaction Transact = new Transaction();
    EXP_SW_STMT stmt = new EXP_SW_STMT();
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();
    UserBO ObjUBO = new UserBO();
    ErrorLogs er = new ErrorLogs();
    Export_General_New Export = new Export_General_New();
    public int i;

    public string EXPORT_JOBNO, SW_ID, currentuser, SELECT_BRANCH;
    public string INVOICE_SLNO = "", ITEM_SLNO = "", INVOICE_NO = "",S_BULK="";
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
   
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            currentuser = Connection.Current_User();
            EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();
            SELECT_BRANCH = Connection.Get_Company_Type();


            if (Session["Q_Item_slno"] != null)
            {
                //INVOICE_SLNO = Session["Invoice_SLNO"].ToString();
                ITEM_SLNO = Session["Q_Item_slno"].ToString();
                INVOICE_NO = Session["Inv_NO"].ToString();

                INVOICE_SLNO = Session["Q_Item_slno"].ToString();
                S_BULK = "Bulk";
                if (!IsPostBack)
                {

                    Gridbind_SW_STMT();

                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                    btnNew.Visible = true;
                }
            }
            else
            {
                if (Session["Item_SLNo"] != null)
                {
                    if (Session["TRANSPORT_MODE"] != null)
                    {
                        hdfTransport_mode.Value = Session["TRANSPORT_MODE"].ToString();
                    }
                    INVOICE_SLNO = Session["Inv_SL_No"].ToString();
                    ITEM_SLNO = Session["Item_SLNo"].ToString();
                    INVOICE_NO = Session["Inv_NO"].ToString();
                    S_BULK = "Single";
                    if (!IsPostBack)
                    {
                        Gridbind_SW_STMT();

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
            ObjUBO.JOBNO = EXPORT_JOBNO;
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

    public void SW_Statement_insert_update(string SW_ID , string flag)
    {
        try
        {
            ObjUBO.SW_STMT_ID = SW_ID;
            ObjUBO.JOBNO = EXPORT_JOBNO;
            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
            ObjUBO.ITEM_SLNO = ITEM_SLNO;

            ObjUBO.JOBID = txt_Sr_No.Text;
            // ObjUBO.STMT_DECLARATION_NUMBER = txt_stmt_Declaration_No.Text;
            //ObjUBO.STMT_DECLARATION_DATE = txt_stmt_Declaration_Date.Text;


            ObjUBO.STMT_TYPE = txt_Statement_Type.Text;
            ObjUBO.STMT_CODE = txt_Statement_Code.Text;
            ObjUBO.STMT_TEXT = RegExReplace(txt_Statement_Text.Text);

            ObjUBO.USER_ID = currentuser;
            ObjUBO.BRANCH_CODE = Connection.Current_Branch();
            ObjUBO.Ename = flag;
            ObjUBO.I_U_TYPE = "";
            ObjUBO.WORKING_PERIOD = Connection.WorkingPeriod();
            ObjUBO.BRANCH_COMMON = SELECT_BRANCH;

            ObjUBO.AMENDMENT_TYPE = ddl_AmendmentType.SelectedValue;
            ObjUBO.AMENDMENT_STATUS = "";


            stmt.SW_Statement(ObjUBO, S_BULK);

            i = stmt.result;
            Export.Exp_Job_Logs_All_Details(EXPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, "SW Statement", flag, "Insert");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
    }

    private string RegExReplace(string s)
    {
        String inputString = s;
        try
        {
            s = s.Replace(System.Environment.NewLine, string.Empty);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
      
        return s;
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
                    btnSave.Focus();
                }
                //-----------------------FOR USER RIGHTS--------------------------------//

                ViewState["UPDATED_ID"] = null;
                Alert_msg("SW Statement Saved Successfully", "btnSave");
                Gridbind_SW_STMT();
            }  
            else
            {
                Alert_msg("SW Production Not Saved", "btnSave");
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
                btnNew.Visible = true;


                txt_Statement_Type.Text = gv_ReImport.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
                txt_Statement_Code.Text = gv_ReImport.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
                txt_Statement_Text.Text = gv_ReImport.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
                txt_Sr_No.Text = gv_ReImport.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");

                if (!string.IsNullOrEmpty(Session["SB_NO"].ToString()))
                {
                    div_AmendmentType.Visible = true;
                    ddl_AmendmentType.SelectedValue = gv_ReImport.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
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
            ObjUBO.JOBNO = EXPORT_JOBNO;
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

            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
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
            ADM.name = "Select_Statement_Text";
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
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();
                adminmaster ADM = new adminmaster();

                ADM.SCHEME_NOTN = txt_Statement_Type.Text;
                ADM.SCHEME_IMPORT_CODE = txt_Statement_Code.Text;
                ADM.name = "Select_Statement_Text";
                ds = ADM.IMP_Single_Window();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txt_Statement_Text.Text = ds.Tables[0].Rows[0]["STATEMENT_DESC"].ToString();
                }
                else
                {
                    txt_Statement_Text.Text = string.Empty;
                }
            }
            else
            {
                txt_Statement_Text.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
}