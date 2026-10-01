using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Goods_Registration_Sea_ContainerPackage : ThemeClass
{
    DataSet dtuser = new DataSet();

    AppSession aps = new AppSession();

    Goods_Reg_Sea_Container_Package Goods_Reg_Con_Pkg = new Goods_Reg_Sea_Container_Package();
    ErrorLogs er = new ErrorLogs();
    public int i;


    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
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
                txt_Eqmnt_SerialNo.Focus();
              
                Gridbind_Goods_Reg_Con_Pckg();
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
    public void Gridbind_Goods_Reg_Con_Pckg()
    {
        Goods_Reg_Con_Pkg.GOODS_SEA_CON_ID = "";
        Goods_Reg_Con_Pkg.GOODS_SEA_CON_JOBNO = EXPORT_JOBNO;

        Goods_Reg_Con_Pkg.WORKING_PERIOD = SELECT_BRANCH;

        Goods_Reg_Con_Pkg.Ename = "select";
        gv_details.DataSource = Goods_Reg_Con_Pkg.RetrieveAll_GoodsReg_Container_Package_Details();
        gv_details.DataBind();

    }
    
    public int Export_Annexure_C_Sea_Con_Insert_Update(string Flag, string GOODS_SEA_CON_ID)
    {
        Goods_Reg_Con_Pkg.GOODS_SEA_CON_ID = GOODS_SEA_CON_ID;
        Goods_Reg_Con_Pkg.GOODS_SEA_CON_JOBNO = EXPORT_JOBNO;

        Goods_Reg_Con_Pkg.GOODS_SEA_CON_EQMT_SERIAL_NO = txt_Eqmnt_SerialNo.Text;
        Goods_Reg_Con_Pkg.GOODS_SEA_CON_EQMT_TYPE = ddl_Eqmnt_Type.SelectedValue;
        Goods_Reg_Con_Pkg.GOODS_SEA_CON_EQMT_ID = txt_Eqmnt_ID.Text;
        Goods_Reg_Con_Pkg.GOODS_SEA_CON_EQMT_LOC = txt_Eqmnt_Loc.Text;

        Goods_Reg_Con_Pkg.GOODS_SEA_CON_PCKG_FROM = txt_PckgFrom.Text;
        Goods_Reg_Con_Pkg.GOODS_SEA_CON_PCKG_TO = txt_PckgTo.Text;
        Goods_Reg_Con_Pkg.GOODS_SEA_CON_PCKG_COUNT = txt_PckgCount.Text;
        Goods_Reg_Con_Pkg.GOODS_SEA_CON_PCKG_UQC = txt_PckgUQC.Text;
        

        Goods_Reg_Con_Pkg.USER_ID = currentuser;
        Goods_Reg_Con_Pkg.flag = Flag;
        Goods_Reg_Con_Pkg.BRANCH_CODE = currentbranch;
        Goods_Reg_Con_Pkg.WORKING_PERIOD = Working_Period;
        Goods_Reg_Con_Pkg.BRANCH_COMMON = SELECT_BRANCH;

        gv_details.DataSource = Goods_Reg_Con_Pkg.Goods_Reg_Sea_Container_details_insertupdate();
        gv_details.DataBind();
        i = Goods_Reg_Con_Pkg.result;

        return i;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //string ID = "";
            string F = "S", GOODS_SEA_CON_ID="0";
            i = Export_Annexure_C_Sea_Con_Insert_Update(F, GOODS_SEA_CON_ID);
            hdn_update.Value = Convert.ToString(Goods_Reg_Con_Pkg.UPDATE_ID);

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
                //Gridbind_Goods_Reg_Con_Pkgtainer();

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
                             
                //Gridbind_Goods_Reg_Con_Pkgtainer();
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
            Goods_Reg_Con_Pkg.GOODS_SEA_CON_ID = ViewState["GOODS_SEA_CON_ID"].ToString();
            Goods_Reg_Con_Pkg.GOODS_SEA_CON_JOBNO = EXPORT_JOBNO;

            Goods_Reg_Con_Pkg.Ename = "delete";
            Goods_Reg_Con_Pkg.WORKING_PERIOD = SELECT_BRANCH;
            //dtuser = Goods_Reg_Con_Pkg.RetrieveAll_Annexure_C_Sea_Container_Details();
            gv_details.DataSource = Goods_Reg_Con_Pkg.RetrieveAll_GoodsReg_Container_Package_Details();

            gv_details.DataBind();
            i = Goods_Reg_Con_Pkg.result;

            if (i == 1)
            {
                //Gridbind_Goods_Reg_Con_Pkgtainer();
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
            txt_Eqmnt_SerialNo.Text = gv_details.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            ddl_Eqmnt_Type.SelectedValue = gv_details.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");

            txt_Eqmnt_ID.Text = gv_details.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            txt_Eqmnt_Loc.Text = gv_details.SelectedRow.Cells[4].Text.Replace("01/01/1900", "");

            txt_PckgFrom.Text = gv_details.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            txt_PckgTo.Text = gv_details.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            txt_PckgCount.Text = gv_details.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            txt_PckgUQC.Text = gv_details.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");

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
        Gridbind_Goods_Reg_Con_Pckg();
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
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CONTAINER PACKAGE', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CONTAINER PACKAGE', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}