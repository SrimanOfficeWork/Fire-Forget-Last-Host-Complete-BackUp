using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Export_Annexure_C_Sea_Container : ThemeClass
{
    DataSet dtuser = new DataSet();

    AppSession aps = new AppSession();
    //Export_General_New Export = new Export_General_New();
    Goods_Reg_Sea_Container Goods_Reg_Sea_Con = new Goods_Reg_Sea_Container();
    public string Trans_ID = "";
    ErrorLogs er = new ErrorLogs();
    public int i;
    public string AUTO_ID;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
   // public string Nature_Cargo, ddlNature_Cargo;
    public string EXPORT_JOBNO;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    User_Creation user_Create = new User_Creation();
    protected void Page_Load(object sender, EventArgs e)
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
        if (Session["EXPORT_JOBNO"] != null)
        {
            EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();

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
                txtContainerNo.Focus();
                ddl_Type();
                ddl_Size();
                Gridbind_Goods_Reg_Sea_Container();
            }
        }
        else
        {
            //Response.Write("<script>window.open('General.aspx','_parent');</script>");
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
            gv_details.ToolTip = "You don't have permission to access";
    }
    public void Gridbind_Goods_Reg_Sea_Container()
    {
        Goods_Reg_Sea_Con.GOODS_SEA_CON_ID = "";
        Goods_Reg_Sea_Con.GOODS_SEA_CON_JOBNO = EXPORT_JOBNO;

        Goods_Reg_Sea_Con.WORKING_PERIOD = SELECT_BRANCH;

        Goods_Reg_Sea_Con.Ename = "select";
        gv_details.DataSource = Goods_Reg_Sea_Con.RetrieveAll_Annexure_C_Sea_Container_Details();
        gv_details.DataBind();

        //dss = Transact.RetrieveAll_IGM_Details();
        //Grid_Empty();

    }
    public void ddl_Size()
    {
        ddlSize.Items.Add("20");
        ddlSize.Items.Add("40");
        ddlSize.Items.Add("45");

    }
    public void ddl_Type()
    {
        ddlType.Items.Add("FR");
        ddlType.Items.Add("GP");
        ddlType.Items.Add("HG");
        ddlType.Items.Add("HR");
        ddlType.Items.Add("OT");
        ddlType.Items.Add("RF");
        ddlType.Items.Add("HC");
        ddlType.Items.Add("TK");
    }

    public int Export_Annexure_C_Sea_Con_Insert_Update(string Flag, string GOODS_SEA_CON_ID)
    {
        Goods_Reg_Sea_Con.GOODS_SEA_CON_ID = GOODS_SEA_CON_ID;
        Goods_Reg_Sea_Con.GOODS_SEA_CON_JOBNO = EXPORT_JOBNO;
        Goods_Reg_Sea_Con.GOODS_SEA_CON_CONTAINERNO = txtContainerNo.Text;
        Goods_Reg_Sea_Con.GOODS_SEA_CON_SIZE = ddlSize.SelectedValue;
        Goods_Reg_Sea_Con.GOODS_SEA_CON_TYPE = ddlType.SelectedValue;

        Goods_Reg_Sea_Con.GOODS_SEA_CON_EXCISE_SEALNO = txtExcise_Seal_No.Text;
        Goods_Reg_Sea_Con.GOODS_SEA_CON_SEAL_DATE = txtSealDate.Text;

        Goods_Reg_Sea_Con.GOODS_SEA_CON_SEALTYPE_INDICATOR = ddl_SealType_Indicator.SelectedItem.Text;
        Goods_Reg_Sea_Con.GOODS_SEA_CON_SEAL_DEVICEID = txt_Seal_ID.Text;
        Goods_Reg_Sea_Con.GOODS_SEA_CON_DOC_TYPE = txt_Movement_DocType.Text;
        Goods_Reg_Sea_Con.GOODS_SEA_CON_DOC_NUMBER = txt_Movement_DocNo.Text;

        Goods_Reg_Sea_Con.GOODS_SEA_CON_EQMT_TYPE = ddl_Eqmnt_Type.SelectedValue;
        Goods_Reg_Sea_Con.GOODS_SEA_CON_EQMT_QTY = txt_Eqmnt_Qty.Text;
        Goods_Reg_Sea_Con.GOODS_SEA_CON_EQMT_QTY_CODE = txt_Eqmnt_QtyCode.Text;

        Goods_Reg_Sea_Con.USER_ID = currentuser;
        Goods_Reg_Sea_Con.flag = Flag;
        Goods_Reg_Sea_Con.BRANCH_CODE = currentbranch;
        Goods_Reg_Sea_Con.WORKING_PERIOD = Working_Period;
        Goods_Reg_Sea_Con.BRANCH_COMMON = SELECT_BRANCH;
        //i = Goods_Reg_Sea_Con.Annexure_C_Sea_Con_details_insertupdate();
        gv_details.DataSource = Goods_Reg_Sea_Con.Goods_Reg_Sea_Container_details_insertupdate();
        gv_details.DataBind();
        i = Goods_Reg_Sea_Con.result;

        return i;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //string ID = "";
            string F = "S", GOODS_SEA_CON_ID="0";
            i = Export_Annexure_C_Sea_Con_Insert_Update(F, GOODS_SEA_CON_ID);
            hdn_update.Value = Convert.ToString(Goods_Reg_Sea_Con.UPDATE_ID);

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
                Alert_msg("Saved Successfully", "btnSave");
                //Gridbind_Goods_Reg_Sea_Container();

            }
            else if (i == 2)
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Not Save, Job No Already Exist')</script>", false);
                Alert_msg("Job No Already Exist!", "btnSave");

            }
            else if (i == 3)
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Not Save, Exceed Container Entry')</script>", false);
                Alert_msg("Exceed Container Entry", "btnSave");

            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
                Alert_msg("Not Saved", "btnSave");

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
            //string ID = "";
            string F = "U", GOODS_SEA_CON_ID;
            //GOODS_SEA_CON_ID = ViewState["GOODS_SEA_CON_ID"].ToString();
            GOODS_SEA_CON_ID = hdn_update.Value;

            i = Export_Annexure_C_Sea_Con_Insert_Update(F, GOODS_SEA_CON_ID);
            if (i == 1)
            {
                             
                //Gridbind_Goods_Reg_Sea_Container();
                if (ViewState["UPDATED_ID"] != null)
                {
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>event.preventDefault();alert('Updated Successfully')</script>", false);
                    Alert_msg("Updated Successfully", "btnUpdate");

                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>event.preventDefault();alert('Saved Successfully')</script>", false);
                    Alert_msg("Saved Successfully", "btnUpdate");

                }  
            }
            else if (i == 2)
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Not Save, Job No Already Exist')</script>", false);
                Alert_msg("Job No Already Exist", "btnUpdate");

            }
            
            else
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
                Alert_msg("Not Saved", "btnUpdate");

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
            //string ID = "";
            Goods_Reg_Sea_Con.GOODS_SEA_CON_ID = ViewState["GOODS_SEA_CON_ID"].ToString();
            Goods_Reg_Sea_Con.GOODS_SEA_CON_JOBNO = EXPORT_JOBNO;

            Goods_Reg_Sea_Con.Ename = "delete";
            Goods_Reg_Sea_Con.WORKING_PERIOD = SELECT_BRANCH;
            //dtuser = Goods_Reg_Sea_Con.RetrieveAll_Annexure_C_Sea_Container_Details();
            gv_details.DataSource = Goods_Reg_Sea_Con.RetrieveAll_Annexure_C_Sea_Container_Details();

            gv_details.DataBind();
            i = Goods_Reg_Sea_Con.result;

            if (i == 1)
            {
                //Gridbind_Goods_Reg_Sea_Container();
                btnNew_Click(sender, e);
                Alert_msg("Deleted");
            }
           else
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Deleted')</script>", false);
                Alert_msg("Not Deleted");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void gv_details_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["GOODS_SEA_CON_ID"] = Convert.ToString(this.gv_details.SelectedDataKey.Value);

        if (ViewState["GOODS_SEA_CON_ID"] != "" && ViewState["GOODS_SEA_CON_ID"] != null)
        {

            txtContainerNo.Text = gv_details.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");

            ddlSize.Items.Clear();
            string Size = gv_details.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");

            ddl_Size();
            ddlSize.Items.Remove(Size);
            ddlSize.Items.Insert(0, Size);
            ddlType.Items.Clear();

            string type = gv_details.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");

            ddl_Type();
            ddlType.Items.Remove(type);
            ddlType.Items.Insert(0, type);

            txtExcise_Seal_No.Text = gv_details.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            txtSealDate.Text = gv_details.SelectedRow.Cells[5].Text.Replace("01/01/1900", "");

            ddl_SealType_Indicator.SelectedValue= gv_details.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            txt_Seal_ID.Text = gv_details.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            txt_Movement_DocType.Text = gv_details.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
            txt_Movement_DocNo.Text = gv_details.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");

            ddl_Eqmnt_Type.SelectedValue = gv_details.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
            txt_Eqmnt_Qty.Text = gv_details.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
            txt_Eqmnt_QtyCode.Text = gv_details.SelectedRow.Cells[12].Text.Replace("&nbsp;", "");

            //FOR UPDATED SUCCESSFULLY
            ViewState["UPDATED_ID"] = null;
            ViewState["UPDATED_ID"] = ViewState["GOODS_SEA_CON_ID"].ToString();
            hdn_update.Value = ViewState["GOODS_SEA_CON_ID"].ToString();

            //FOR UPDATED SUCCESSFULLY
            btnUpdate.CssClass = "updates";

            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnNew.Visible = true;
       
        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
        }
    }
    protected void gv_details_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_details, "Select$" + e.Row.RowIndex.ToString()));
            }
            //  if Read Permiision given true for gridview enabled or Disabled----------//

            string MINDATE = "01/01/1900";

            if (e.Row.Cells[5].Text == MINDATE)
            {
                if (Convert.ToDateTime(e.Row.Cells[5].Text) <= Convert.ToDateTime(MINDATE))
                    e.Row.Cells[5].Text = string.Empty;
            }
        }
    }
    protected void gv_details_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_details.PageIndex = e.NewPageIndex;
        Gridbind_Goods_Reg_Sea_Container();
    }
    protected void gv_details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
        txtContainerNo.Focus();
        
        ddlSize.Items.Clear();
        ddl_Size();
        ddlType.Items.Clear();
        ddl_Type();

        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;
        btnUpdate.CssClass = "updates";

        ViewState["UPDATED_ID"] = null;
        hdn_update.Value = "";
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GOODS_REG_SEA_CONTAINER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GOODS_REG_SEA_CONTAINER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}