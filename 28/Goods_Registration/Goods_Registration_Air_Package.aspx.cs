using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Export_Annexure_C_Sea_Package : ThemeClass
{

    DataSet dtuser = new DataSet();

    AppSession aps = new AppSession();
    //Export_General_New Export = new Export_General_New();
    Goods_Reg_Package Goods_Reg_Pack = new Goods_Reg_Package();
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
    public string Nature_Cargo, ddlNature_Cargo;
    public string EXPORT_JOBNO, GOODS_PACK_ID, Transport_Mode="";
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    User_Creation user_Create = new User_Creation();
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

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
    
        if (Session["EXPORT_JOBNO"] != null)
        {
            EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();
            Transport_Mode = Session["TRANSPORT_MODE"].ToString();

            if (!IsPostBack)
            {
                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 11;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//

            
                AUTO_GROUPNO();
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btnNew.Visible = true;
                txtGroup.Focus();
                Gridbind_Goods_Reg_Package();
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
    public void AUTO_GROUPNO()
    {
        Goods_Reg_Pack.GOODS_PACK_JOBNO = EXPORT_JOBNO;
        Goods_Reg_Pack.WORKING_PERIOD = SELECT_BRANCH;
      
        dtuser = Goods_Reg_Pack.Retrieve_Air_GroupNo();
       
        if (Goods_Reg_Pack.result == 1)
        {
            hdnTotal_pkgs.Value = Convert.ToString(Goods_Reg_Pack.max_packages);

            Alert_msg("Package Limit Over!", "btnSave");
            txtGroup.Attributes.Add("readonly", "readonly");
            txtFrom.Attributes.Add("readonly", "readonly");
            txtTo.Attributes.Add("readonly", "readonly");
            txtPackageType.Attributes.Add("readonly", "readonly");
            btnNew.Enabled = false;
            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
        else
        {
            txtGroup.Attributes.Remove("readonly");
            txtFrom.Attributes.Remove("readonly");
            txtTo.Attributes.Remove("readonly");
            txtPackageType.Attributes.Remove("readonly");
            btnNew.Enabled = true;
            btnSave.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            hdnTotal_pkgs.Value = Convert.ToString(Goods_Reg_Pack.max_packages);
            txtTo.Text = Convert.ToString(Goods_Reg_Pack.max_packages);
            if (dtuser.Tables.Count > 0)
            {
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    txtGroup.Text = dtuser.Tables[0].Rows[0]["GOODS_REG_PACK_GROUP"].ToString();



                }
                if (dtuser.Tables[1].Rows.Count > 0)
                {

                    txtFrom.Text = dtuser.Tables[1].Rows[0]["GOODS_REG_PACK_TO"].ToString();


                }

            }
        }
        //hdnTotal_pkgs.Value = "0";
        
    }

    public void Gridbind_Goods_Reg_Package()
    {
        Goods_Reg_Pack.GOODS_PACK_ID = "0";
        Goods_Reg_Pack.GOODS_PACK_JOBNO = EXPORT_JOBNO;
        Goods_Reg_Pack.GOODS_PACK_MODE = Transport_Mode;

        Goods_Reg_Pack.WORKING_PERIOD = SELECT_BRANCH;

        Goods_Reg_Pack.Ename = "select";
        gv_details.DataSource = Goods_Reg_Pack.RetrieveAll_Export_Goods_Reg_Air_Sea_Package_Details();
        gv_details.DataBind();

        //dss = Transact.RetrieveAll_IGM_Details();

        //Grid_Empty();

    }

    public int Export_Annexure_C_Sea_Pack_Insert_Update(string Flag, string GOODS_PACK_ID)
    {
        Goods_Reg_Pack.GOODS_PACK_ID = GOODS_PACK_ID;
        Goods_Reg_Pack.GOODS_PACK_JOBNO = EXPORT_JOBNO;
        Goods_Reg_Pack.GOODS_PACK_GROUP = txtGroup.Text;
        Goods_Reg_Pack.GOODS_PACK_FROM = txtFrom.Text;
        Goods_Reg_Pack.GOODS_PACK_TO = txtTo.Text;
        Goods_Reg_Pack.GOODS_PACK_PACKAGETYPE = txtPackageType.Text;

        Goods_Reg_Pack.GOODS_PACK_MODE = Transport_Mode;

        Goods_Reg_Pack.GOODS_PACK_FROM_DESC = txtFrom_Desc.Text;
        Goods_Reg_Pack.GOODS_PACK_TO_DESC = txtTo_Desc.Text;
        
        Goods_Reg_Pack.USER_ID = currentuser;
        Goods_Reg_Pack.flag = Flag;
        Goods_Reg_Pack.BRANCH_CODE = currentbranch;
        Goods_Reg_Pack.WORKING_PERIOD = Working_Period;
        Goods_Reg_Pack.BRANCH_COMMON = SELECT_BRANCH;

        //i = Goods_Reg_Pack.Annexure_C_Sea_Package_details_insertupdate();
        gv_details.DataSource = Goods_Reg_Pack.Goods_Package_details_insertupdate();
        gv_details.DataBind();
        i = Goods_Reg_Pack.result;

        return i;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //string ID = "";
            string F = "S";
               GOODS_PACK_ID = "0";
            i = Export_Annexure_C_Sea_Pack_Insert_Update(F, GOODS_PACK_ID);
            hdn_update.Value = Convert.ToString(Goods_Reg_Pack.UPDATE_ID);

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

            }
            else if (i == 2)
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Not Save, Job No Already Exist')</script>", false);
                Alert_msg("Job No Already Exist!", "btnSave");

            }
            else if (i == 3)
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Not Save, Exceed Packages Entry')</script>", false);
                Alert_msg("Exceed Packages Entry!", "btnSave");

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
            string F = "U";
            //GOODS_PACK_ID = ViewState["GOODS_PACK_ID"].ToString();
            GOODS_PACK_ID = hdn_update.Value;

            i = Export_Annexure_C_Sea_Pack_Insert_Update(F, GOODS_PACK_ID);
            if (i == 1)
            {

                //Gridbind_Goods_Reg_Package();
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
                Alert_msg("Job No Already Exist!", "btnUpdate");

            }
            else if (i == 3)
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Not Save, Exceed Packages Entry')</script>", false);
                Alert_msg("Exceed Packages Entry!", "btnUpdate");

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
            Goods_Reg_Pack.GOODS_PACK_ID = ViewState["GOODS_PACK_ID"].ToString();
            Goods_Reg_Pack.GOODS_PACK_JOBNO = EXPORT_JOBNO;

            Goods_Reg_Pack.Ename = "delete";
            Goods_Reg_Pack.WORKING_PERIOD = SELECT_BRANCH;
            Goods_Reg_Pack.GOODS_PACK_MODE = Transport_Mode;

           // dtuser = Goods_Reg_Pack.RetrieveAll_Annexure_C_Sea_Package_Details();
            gv_details.DataSource = Goods_Reg_Pack.RetrieveAll_Export_Goods_Reg_Air_Sea_Package_Details();

            gv_details.DataBind();
            i = Goods_Reg_Pack.result;

            if (i == 1)
            {

                //Gridbind_Goods_Reg_Package();
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
        ViewState["GOODS_PACK_ID"] = Convert.ToString(this.gv_details.SelectedDataKey.Value);

        if (ViewState["GOODS_PACK_ID"] != "" && ViewState["GOODS_PACK_ID"] != null)
        {


            txtGroup.Text = gv_details.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");

           

            txtFrom.Text = gv_details.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");

            txtTo.Text = gv_details.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            txtPackageType.Text = gv_details.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");

            txtFrom_Desc.Text = gv_details.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            txtTo_Desc.Text = gv_details.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");


            //FOR UPDATED SUCCESSFULLY
            ViewState["UPDATED_ID"] = null;
            ViewState["UPDATED_ID"] = ViewState["GOODS_PACK_ID"].ToString();
            hdn_update.Value = ViewState["GOODS_PACK_ID"].ToString();

            //FOR UPDATED SUCCESSFULLY
            btnUpdate.CssClass = "updates";

            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnNew.Visible = true;

            txtGroup.Attributes.Remove("readonly");
            txtFrom.Attributes.Remove("readonly");
            txtTo.Attributes.Remove("readonly");
            txtPackageType.Attributes.Remove("readonly");
            btnNew.Enabled = true;
            btnSave.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;



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

           // string MINDATE = "01/01/1900";

          
            //if (e.Row.Cells[5].Text == MINDATE)
            //{
            //    if (Convert.ToDateTime(e.Row.Cells[5].Text) <= Convert.ToDateTime(MINDATE))
            //        e.Row.Cells[5].Text = string.Empty;
            //}
        }
    }
    protected void gv_details_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_details.PageIndex = e.NewPageIndex;
        Gridbind_Goods_Reg_Package();
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
        txtTo.Focus();
        AUTO_GROUPNO();
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;
        btnUpdate.CssClass = "updates";

        ViewState["UPDATED_ID"] = null;
        hdn_update.Value = "";
    }
    protected void txtTo_TextChanged(object sender, EventArgs e)
    {
        if (txtTo.Text != "")
        {
            int to = Convert.ToInt32(txtTo.Text);

            //string  s1 =;
            //s1.Substring(0, 1);

            if (to > Convert.ToInt32(hdnTotal_pkgs.Value))
            {
                //if (s1 != "0")
                //{
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Exceed Package Value')</script>", false);
                Alert_msg("Exceed Package Value!", "txtTo");
                //}

            }
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GOODS_REG_AIR_PACKAGE', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GOODS_REG_AIR_PACKAGE', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}