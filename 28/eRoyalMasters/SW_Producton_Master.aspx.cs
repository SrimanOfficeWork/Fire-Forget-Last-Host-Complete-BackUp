using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class SW_Producton_Master : ThemeClass
{
    Transaction Transact = new Transaction();
    User_Creation user_Create = new User_Creation();
    SW_PROD SW = new SW_PROD();
    UserBO ObjUBO = new UserBO();

    
    DataSet dtuser = new DataSet();
    DataSet dss = new DataSet();
    public int i;

    AppSession aps = new AppSession();
    eroyalmaster erm = new eroyalmaster();

    public string currentuser;

    public string IMPORT_JOBNO, SW_ID;
    public string INVOICE_SLNO = "", ITEM_SLNO = "", INVOICE_NO = "", COMPANY_ID;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE;
    public string RITC_NO, Description, PART_NO;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Connection.Current_User();
        //IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
        SELECT_BRANCH = Connection.Get_Company_Type();
        COMPANY_ID = Connection.COMPANYID();
        hdn_Jobno.Value = IMPORT_JOBNO;

        RITC_NO = (Session["CTH_No"] == null) ? string.Empty : Session["CTH_No"].ToString();
        Description = (Session["Description"] == null) ? string.Empty : Session["Description"].ToString();
        PART_NO = (Session["PARTNO"] == null)? string.Empty : Session["PARTNO"].ToString();

        if (Session["CTH_No"] != null || Session["CTH_No"] == null)
        {
            hdn_Invslno.Value = INVOICE_SLNO;

            hdn_Normal_Bulk.Value = "B";

            if (!IsPostBack)
            {
                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 7;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//

                txt_Prod_Batch_Identifier.Focus();
                Gridbind_SW_PRODUCTION();

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

    public void Gridbind_SW_PRODUCTION()
    {   
        ObjUBO.Ename = "PRODCUTION_Select";
        ObjUBO.PRODUCT_RITC = RITC_NO;
        ObjUBO.PART_NO = PART_NO;
      
        dss = erm.SingleWindow_PRODUCTION_Select(ObjUBO);

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
    public void SW_PRODUCTION_insert_update(string SW_ID , string flag)
    {
        ObjUBO.SW_ID = SW_ID;
        ObjUBO.PRODUCT_DESCRIPTION = Session["Description"].ToString();
        ObjUBO.PRODUCT_RITC = Session["CTH_No"].ToString();
        ObjUBO.PART_NO = Session["PARTNO"].ToString();
        ObjUBO.PRODUCTION_BATCH_IDENTIFIER = txt_Prod_Batch_Identifier.Text;
        ObjUBO.PRODUCTION_BATCH_QUANTITY = txt_Prod_Batch_Qty.Text;
        ObjUBO.UNIT_QTY_CODE = txt_Unit_Qty_Code.Text;
        ObjUBO.DATE_OF_MANUFACTURING = txt_Date_of_Manufacturing.Text;
        ObjUBO.DATE_OF_EXPIRY = txt_Date_of_Expiry.Text;
        ObjUBO.BEST_BEFORE = txt_Best_Before.Text;
        ObjUBO.RESIDUAL_SHELF_LIFE_DAYS = "";
        ObjUBO.TOTAL_SHELF_LIFE_DAYS = "";
        ObjUBO.RESIDUAL_SHELF_PERCENT = "";

        ObjUBO.flag = flag;
        ObjUBO.Ename = hdn_Normal_Bulk.Value.ToString();
        ObjUBO.AMENDMENT_STATUS = "";

        erm.SW_PRODUCTION_Details_Insert_Update(ObjUBO);

        i = erm.result;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SW_ID = "";

            SW_PRODUCTION_insert_update(SW_ID, "S");
            hdn_update_Reimport.Value = Convert.ToString(SW.UPDATE_ID);

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
                Alert_msg("SW Production Saved Successfully", "btnSave");
                Gridbind_SW_PRODUCTION();
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
        ViewState["SW_PROD_ID"] = Convert.ToString(this.gv_ReImport.SelectedDataKey.Value);

        if (ViewState["SW_PROD_ID"] != "" && ViewState["SW_PROD_ID"] != null)
        {
            //FOR UPDATED SUCCESSFULLY
            ViewState["UPDATED_ID"] = null;
            ViewState["UPDATED_ID"] = ViewState["SW_PROD_ID"].ToString();
            hdn_update_Reimport.Value = ViewState["SW_PROD_ID"].ToString();

            //FOR UPDATED SUCCESSFULLY
            btnUpdate.CssClass = "updates";
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnNew.Visible = true;

            txt_Prod_Batch_Identifier.Text = gv_ReImport.SelectedRow.Cells[1].Text;
            txt_Prod_Batch_Qty.Text = gv_ReImport.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            txt_Unit_Qty_Code.Text = gv_ReImport.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            txt_Date_of_Manufacturing.Text = gv_ReImport.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            txt_Date_of_Expiry.Text = gv_ReImport.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            txt_Best_Before.Text = gv_ReImport.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            //ddl_AmendmentType.SelectedValue = gv_ReImport.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
     
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
        Gridbind_SW_PRODUCTION();
    }
    protected void gv_ReImport_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {     
            SW_ID = hdn_update_Reimport.Value;
            SW_PRODUCTION_insert_update(SW_ID, "U");

            if (i == 1)
            {
                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("SW Production Updated Successfully", "btnUpdate");
                }
                else
                {
                    Alert_msg("SW Production Saved Successfully", "btnUpdate");
                }

                Gridbind_SW_PRODUCTION();
            }
        
            else
            {
                Alert_msg("SW Production Not Saved", "btnUpdate");

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
            ObjUBO.SW_ID = ViewState["SW_PROD_ID"].ToString();
            ObjUBO.Ename = hdn_Normal_Bulk.Value.ToString();
            ObjUBO.flag = "D";
            erm.SW_PRODUCTION_Details_Insert_Update(ObjUBO);
           
            int ii = 0;
            ii = erm.result;

            if (ii > 0)
            {
                btnNew_Click(sender, e);
                Alert_msg("SW Production Deleted");

                
            }
            else
            {
                Alert_msg("SW Production Not Deleted");
            }
            Gridbind_SW_PRODUCTION();
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
        txt_Prod_Batch_Identifier.Focus();
        Transact.ResetFields(Page.Controls);
        
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;
        btnUpdate.CssClass = "updates";

        ViewState["UPDATED_ID"] = null;
        hdn_update_Reimport.Value = "";

        Gridbind_SW_PRODUCTION();

    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SW Production', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SW Production', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
   
}