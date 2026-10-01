using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class SW_Control_Master : ThemeClass
{
    AppSession aps = new AppSession();
    Transaction Transact = new Transaction();
    User_Creation user_Create = new User_Creation();
    SW_CONTROL SW = new SW_CONTROL();
    UserBO ObjUBO = new UserBO();

    DataSet dtuser = new DataSet();
    DataSet dss = new DataSet();
    eroyalmaster erm = new eroyalmaster();

    public int i,Screen_Id;
    public string IMPORT_JOBNO, SW_ID,SELECT_BRANCH,currentuser;

    public string INVOICE_SLNO = "", ITEM_SLNO = "", INVOICE_NO = "", COMPANY_ID;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, RITC_NO, Description, PART_NO;
    
    public string JOB_LOCK, JOB_RELEASE;
    adminmaster Am = new adminmaster();

    

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Connection.Current_User();
        SELECT_BRANCH = Connection.Get_Company_Type();
        COMPANY_ID = Connection.COMPANYID();
        hdn_Jobno.Value = IMPORT_JOBNO;

        RITC_NO = (Session["CTH_No"] == null) ? string.Empty : Session["CTH_No"].ToString();
        Description = (Session["Description"] == null) ? string.Empty : Session["Description"].ToString();
        PART_NO = (Session["PARTNO"] == null) ? string.Empty : Session["PARTNO"].ToString();

        if (!IsPostBack)
        {
          
                lblinvid.Text = "";
                lblSEC65.Text = "";
                btnaddnew.Visible = false;
        }

        if (Session["CTH_No"] != null || Session["CTH_No"] == null)
        {
            hdn_Normal_Bulk.Value = "B";
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

    public void Bind_COntrolCode()
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
    public void Bind_ResultCode()
    {
        if (ddlCont_type_code.SelectedItem.ToString().Contains("SEC65"))
        {

            txt_Cont_Result_Text.Text = Session["CTH_No"].ToString() + "|" + Session["Description"].ToString();

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
  
    public void Bind_ControlCode_DropDownList(string Flag,string Code,string Type)
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

    public void Page_Rights(int i)
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

    public void Gridbind_SW_Control()
    {
        ObjUBO.Ename = "CONTROL_Select";
        ObjUBO.PRODUCT_RITC = RITC_NO;
        ObjUBO.PART_NO = PART_NO;
            dss = erm.SingleWindow_CONTROL_Select(ObjUBO);

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
    public void SW_CONTROL_insert_update(string SW_ID, string flag)
    {
        ObjUBO.SW_ID = SW_ID;
        ObjUBO.PRODUCT_DESCRIPTION = Session["Description"].ToString();
        ObjUBO.PRODUCT_RITC = Session["CTH_No"].ToString();
        ObjUBO.PART_NO = Session["PARTNO"].ToString();


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
        erm.SW_CONTROL_Details_Insert_Update(ObjUBO);

        i = erm.result;
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
                Alert_msg ("(004W01) Already Exist");

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
            //ddl_AmendmentType.SelectedValue = gv_ReImport.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");

        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;

        }
    }

    protected void gv_ReImport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_ReImport.PageIndex = e.NewPageIndex;
        Gridbind_SW_Control();
    }
    protected void gv_ReImport_RowDataBound(object sender, GridViewRowEventArgs e)
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
            ObjUBO.JOBNO = IMPORT_JOBNO;
            ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
            ObjUBO.ITEM_SLNO = ITEM_SLNO;
            ObjUBO.SW_ID = ViewState["SW_CONTROL_ID"].ToString();
            ObjUBO.Ename = hdn_Normal_Bulk.Value.ToString();
            ObjUBO.flag = "D";
            erm.SW_CONTROL_Details_Insert_Update(ObjUBO);

            int ii = 0;
            ii = erm.result;

            if (ii > 0)
            {
                btnNew_Click(sender, e);
                Alert_msg("SW Control Deleted");

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
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void btnNew_Click(object sender, EventArgs e)
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

}