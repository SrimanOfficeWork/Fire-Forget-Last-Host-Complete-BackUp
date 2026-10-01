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
    Export_General_New Export = new Export_General_New();
    EXP_SW_CONTROL SW = new EXP_SW_CONTROL();
    UserBO ObjUBO = new UserBO();
    ErrorLogs er = new ErrorLogs();


    DataSet dtuser = new DataSet();
    DataSet dss = new DataSet();

    public int i,Screen_Id;

    public string EXPORT_JOBNO, SW_ID, SELECT_BRANCH, currentuser;

    public string INVOICE_SLNO = "", ITEM_SLNO = "", INVOICE_NO = "";
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    
    public string JOB_LOCK, JOB_RELEASE;
    
    adminmaster Am = new adminmaster();

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
                hdn_Normal_Bulk.Value = "B";
                //INVOICE_SLNO = Session["Invoice_SLNO"].ToString();
                ITEM_SLNO = Session["Q_Item_slno"].ToString();
                INVOICE_NO = Session["Invoice_NO"].ToString();
                INVOICE_SLNO = Session["Q_Item_slno"].ToString();


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
                if (Session["Item_SLNo"] != null)
                {
                    hdn_Normal_Bulk.Value = "N";

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
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
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
            Connection.Error_Msg(ex.Message);
        }
       
    }
    public void Bind_ResultCode()
    {
        try
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

            if (ddlCont_type_code.SelectedItem.ToString().Contains("DUC"))
            {
                txt_Cont_ResultCode.Visible = true;
                ddl_ResultCode.Visible = false;
            }
            else
            {
                txt_Cont_ResultCode.Visible = false;
                ddl_ResultCode.Visible = true;
            }

            ddl_ResultCode.Items.Clear();
            ddl_ResultCode.DataSource = dtuser.Tables[0];
            ddl_ResultCode.DataTextField = "CTRL_CODE_DESC";
            ddl_ResultCode.DataValueField = "CTRL_CODE_DESC";
            ddl_ResultCode.DataBind();
            ddlCont_type_code.Items.Insert(0, "");
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }
  
    public void Bind_ControlCode_DropDownList(string Flag,string Code,string Type)
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
            Connection.Error_Msg(ex.Message);
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
            Connection.Error_Msg(ex.Message);
        }
     }

    public void Gridbind_SW_Control()
    {
        try
        {
            ObjUBO.JOBNO = EXPORT_JOBNO;
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
            Connection.Error_Msg(ex.Message);
        }
       
    }
    public void SW_CONTROL_insert_update(string SW_ID, string flag)
    {
        try
        {
            ObjUBO.SW_ID = SW_ID;
            ObjUBO.JOBNO = EXPORT_JOBNO;
            ObjUBO.ITEM_SLNO = ITEM_SLNO;
            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;

            ObjUBO.CONTROL_TYPE_CODE = ddlCont_type_code.SelectedValue.ToString().Substring(0, 6);
            ObjUBO.CONTROL_LOCATION = txt_Cont_Location.Text.ToUpper();
            ObjUBO.CONTROL_START_DATE = txt_Cont_Start_Date.Text;
            ObjUBO.CONTROL_END_DATE = txt_Cont_End_Date.Text;

            if (ddlCont_type_code.SelectedItem.ToString().Contains("DUC"))
            {
                ObjUBO.CONTROL_TYPE_CODE = ddlCont_type_code.SelectedValue.ToString().Substring(0, 3);
                ObjUBO.CONTROL_RESULT_CODE = txt_Cont_ResultCode.Text.ToUpper();
            }
            else
            {
                ObjUBO.CONTROL_RESULT_CODE = ddl_ResultCode.SelectedValue.ToString().Substring(0, 8);
            }


            ObjUBO.CONTROL_RESULT_TEXT = txt_Cont_Result_Text.Text;
            ObjUBO.JOBID = txt_Sr_No.Text;

            ObjUBO.flag = flag;
            ObjUBO.Ename = hdn_Normal_Bulk.Value.ToString();
            SW.SW_CONTROL_Details_Insert_Update(ObjUBO);

            i = SW.result;
            Export.Exp_Job_Logs_All_Details(EXPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, "SW Control", flag, "Insert");
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
                if (gv_ReImport.SelectedRow.Cells[1].Text == "DUC")
                {
                    txt_Cont_ResultCode.Text = gv_ReImport.SelectedRow.Cells[5].Text;
                }
                else
                {
                    Bind_ControlCode_DropDownList("Select_DESC_CTRL_CODE", gv_ReImport.SelectedRow.Cells[5].Text, "R");
                }
                txt_Cont_Result_Text.Text = gv_ReImport.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
                txt_Sr_No.Text = gv_ReImport.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
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
            Connection.Error_Msg(ex.Message);
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
            Connection.Error_Msg(ex.Message);
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
            Connection.Error_Msg(ex.Message);
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
            ObjUBO.JOBNO = EXPORT_JOBNO;
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
                Export.Exp_Job_Logs_All_Details(EXPORT_JOBNO, INVOICE_SLNO, ITEM_SLNO, "SW Control", "D", "Insert");
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
            Connection.Error_Msg(ex.Message);
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
            Connection.Error_Msg(ex.Message);
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
            Connection.Error_Msg(ex.Message);
        }
       
    }

}