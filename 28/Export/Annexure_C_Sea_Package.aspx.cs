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
    Annexure_C_Sea_Package ANNEX_C_Sea_Pack = new Annexure_C_Sea_Package();
    public string Trans_ID = "";
    ErrorLogs er = new ErrorLogs();
    public int i;
    public string AUTO_ID;
    public string COMPANY_ID = "";
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public string Nature_Cargo, ddlNature_Cargo;
    public string EXPORT_JOBNO, ANNEX_SEA_PACK_ID;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE;
    User_Creation user_Create = new User_Creation();
    string ANNEX_PKG_Setting_Type = "";
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
            COMPANY_ID = Session["COMPANY_ID"].ToString();

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
                    Screen_Id = 12;
                    Page_Rights(Screen_Id);
                    //----------------SETTING SCREEN PERMISSION---------------//
                    load_Sea_Pkg_setting();


                    AUTO_GROUPNO();
                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                    btnNew.Visible = true;

                    txtGroup.Focus();

                    Gridbind_Annex_C_Sea_Package();
                }

            }
            else
            {
                Response.Write("<script>window.open('General.aspx','_parent');</script>");
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

            if (COMPANY_ID == "146" || COMPANY_ID == "158" || COMPANY_ID == "7" || COMPANY_ID == "137" || COMPANY_ID == "164" || COMPANY_ID == "165" || COMPANY_ID == "10")
            {
                txtFrom_Desc.MaxLength = 5;
                txtTo_Desc.MaxLength = 5;
            }
            else
            {
                txtFrom_Desc.MaxLength = 50;
                txtTo_Desc.MaxLength = 50;
            }
            if (Session["COMPANY_ID"].ToString() == "2501" || Session["COMPANY_ID"].ToString() == "2526" || Session["COMPANY_ID"].ToString() == "2537") // Added by pandiyan 26/04/2025
            {
                if (Session["Nature_Cargo"].ToString() == "P")
                {
                    txtPackageType.Text = "PKG";
                }
            }

            /* if (!IsPostBack)
            {
           
                if (Session["COMPANY_LICENSE"].ToString().ToUpper() == "ERI00158")
                {
                    Hdringo_cargo.Value = "Yes";
                    txtFrom.ReadOnly = false;
                    txtFrom_Desc.Focus();
                }
                else
                {
                    Hdringo_cargo.Value = "";
                    txtFrom.ReadOnly = true;
                }
            
            }*/
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        
    }

    private void load_Sea_Pkg_setting()
    {
        try
        {
            Default_Settings DS_pkg = new Default_Settings();
            DataSet dss = new DataSet();

            DS_pkg.USER_ID = currentuser;
            DS_pkg.BRANCH_CODE = currentbranch;
            DS_pkg.BRANCH_COMMON = SELECT_BRANCH;
            DS_pkg.flag = "Select_Pkg";
            dss = DS_pkg.Client_DefaultSettings_Insert_Update();

            if (dss.Tables[0].Rows.Count > 0)
            {
                ANNEX_PKG_Setting_Type = dss.Tables[0].Rows[0]["PKG_TYPE"].ToString();

                if (dss.Tables[0].Rows[0]["PKG_TYPE"].ToString() == "M")
                {
                    Hdringo_cargo.Value = "Yes";
                    txtFrom.ReadOnly = false;
                    txtFrom_Desc.Focus();
                    Session["Annx_Sea_Pkg"] = "Yes";
                }
                else
                {
                    Hdringo_cargo.Value = "";
                    txtFrom.ReadOnly = true;
                    Session["Annx_Sea_Pkg"] = "";
                }
            }
            else
            {
                Hdringo_cargo.Value = "";
                txtFrom.ReadOnly = true;
                Session["Annx_Sea_Pkg"] = "";
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
                gv_details.ToolTip = "You don't have permission to access";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
      
    }
    public void AUTO_GROUPNO()
    {
        try
        {
            if (Session["COMPANY_LICENSE"] != null)
            {
                ANNEX_C_Sea_Pack.ANNEX_SEA_PACK_JOBNO = EXPORT_JOBNO;
                ANNEX_C_Sea_Pack.WORKING_PERIOD = SELECT_BRANCH;
                dtuser = ANNEX_C_Sea_Pack.Retrieve_GroupNo();

                if (ANNEX_PKG_Setting_Type != "M")
                {
                    //if (Session["COMPANY_LICENSE"].ToString().ToUpper() == "ERI00158")
                    if (Hdringo_cargo.Value.ToString() == "Yes")
                    {
                        txtGroup.Attributes.Remove("readonly");
                        txtFrom.Attributes.Remove("readonly");
                        txtTo.Attributes.Remove("readonly");
                        txtPackageType.Attributes.Remove("readonly");
                        btnNew.Enabled = true;
                        btnSave.Enabled = true;
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;
                        hdnTotal_pkgs.Value = Convert.ToString(ANNEX_C_Sea_Pack.max_packages);
                        if (dtuser.Tables.Count > 0)
                        {
                            if (dtuser.Tables[0].Rows.Count > 0)
                            {
                                txtGroup.Text = dtuser.Tables[0].Rows[0]["ANNEX_SEA_PACK_GROUP"].ToString();
                            }
                            if (dtuser.Tables[1].Rows.Count > 0)
                            {
                                txtFrom.Enabled = true;
                            }

                        }
                    }
                    else
                    {
                        if (ANNEX_C_Sea_Pack.result == 1)
                        {
                            hdnTotal_pkgs.Value = Convert.ToString(ANNEX_C_Sea_Pack.max_packages);

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
                            hdnTotal_pkgs.Value = Convert.ToString(ANNEX_C_Sea_Pack.max_packages);
                            txtTo.Text = Convert.ToString(ANNEX_C_Sea_Pack.max_packages);
                            if (dtuser.Tables.Count > 0)
                            {
                                if (dtuser.Tables[0].Rows.Count > 0)
                                {
                                    txtGroup.Text = dtuser.Tables[0].Rows[0]["ANNEX_SEA_PACK_GROUP"].ToString();

                                }
                                if (dtuser.Tables[1].Rows.Count > 0)
                                {

                                    txtFrom.Text = dtuser.Tables[1].Rows[0]["ANNEX_SEA_PACK_TO"].ToString();


                                }

                            }
                        }

                    }
                }

            }
            else
            {
                //----------------Company license-----------------------------

            }
       
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
    }

    public void Gridbind_Annex_C_Sea_Package()
    {
        try
        {
            ANNEX_C_Sea_Pack.ANNEX_SEA_PACK_ID = "";
            ANNEX_C_Sea_Pack.ANNEX_SEA_PACK_JOBNO = EXPORT_JOBNO;

            ANNEX_C_Sea_Pack.WORKING_PERIOD = SELECT_BRANCH;

            ANNEX_C_Sea_Pack.Ename = "select";
            gv_details.DataSource = ANNEX_C_Sea_Pack.RetrieveAll_Annexure_C_Sea_Package_Details();
            gv_details.DataBind();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
      

    }

    public int Export_Annexure_C_Sea_Pack_Insert_Update(string Flag, string ANNEX_SEA_PACK_ID)
    {
        try
        {
            ANNEX_C_Sea_Pack.ANNEX_SEA_PACK_ID = ANNEX_SEA_PACK_ID;
            ANNEX_C_Sea_Pack.ANNEX_SEA_PACK_JOBNO = EXPORT_JOBNO;
            ANNEX_C_Sea_Pack.ANNEX_SEA_PACK_GROUP = txtGroup.Text;
            ANNEX_C_Sea_Pack.ANNEX_SEA_PACK_FROM = txtFrom.Text;
            ANNEX_C_Sea_Pack.ANNEX_SEA_PACK_TO = txtTo.Text;

            ANNEX_C_Sea_Pack.ANNEX_SEA_PACK_PACKAGETYPE = txtPackageType.Text;

            ANNEX_C_Sea_Pack.ANNEX_SEA_PACK_FROMDESC = txtFrom_Desc.Text;
            ANNEX_C_Sea_Pack.ANNEX_SEA_PACK_TODESC = txtTo_Desc.Text;

            ANNEX_C_Sea_Pack.USER_ID = currentuser;
            ANNEX_C_Sea_Pack.flag = Flag;
            ANNEX_C_Sea_Pack.BRANCH_CODE = currentbranch;
            ANNEX_C_Sea_Pack.WORKING_PERIOD = Working_Period;
            ANNEX_C_Sea_Pack.BRANCH_COMMON = SELECT_BRANCH;

            gv_details.DataSource = ANNEX_C_Sea_Pack.Annexure_C_Sea_Package_details_insertupdate();
            gv_details.DataBind();
            i = ANNEX_C_Sea_Pack.result;

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
        return i;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string F = "S";
               ANNEX_SEA_PACK_ID = "0";
            i = Export_Annexure_C_Sea_Pack_Insert_Update(F, ANNEX_SEA_PACK_ID);
            hdn_update.Value = Convert.ToString(ANNEX_C_Sea_Pack.UPDATE_ID);

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
                Alert_msg("Job No Already Exist!", "btnSave");
            }
            else if (i == 3)
            {
                Alert_msg("Exceed Packages Entry!", "btnSave");
            }
            else
            {
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
            string F = "U";
            ANNEX_SEA_PACK_ID = hdn_update.Value;
            i = Export_Annexure_C_Sea_Pack_Insert_Update(F, ANNEX_SEA_PACK_ID);
            if (i == 1)
            {
                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("Updated Successfully", "btnUpdate");
                }
                else
                {
                    Alert_msg("Saved Successfully", "btnUpdate");
                }  
            }
            else if (i == 2)
            {
                Alert_msg("Job No Already Exist!", "btnUpdate");
            }
            else if (i == 3)
            {
                Alert_msg("Exceed Packages Entry!", "btnUpdate");
            }
            else
            {
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
            ANNEX_C_Sea_Pack.ANNEX_SEA_PACK_ID = ViewState["ANNEX_SEA_PACK_ID"].ToString();
            ANNEX_C_Sea_Pack.ANNEX_SEA_PACK_JOBNO = EXPORT_JOBNO;
            ANNEX_C_Sea_Pack.Ename = "delete";
            ANNEX_C_Sea_Pack.WORKING_PERIOD = SELECT_BRANCH;
            gv_details.DataSource = ANNEX_C_Sea_Pack.RetrieveAll_Annexure_C_Sea_Package_Details();
            gv_details.DataBind();
            i = ANNEX_C_Sea_Pack.result;

            if (i == 1)
            {
                btnNew_Click(sender, e);
                Alert_msg("Deleted");
            }

            else
            {
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
        try
        {
            ViewState["ANNEX_SEA_PACK_ID"] = Convert.ToString(this.gv_details.SelectedDataKey.Value);
            if (ViewState["ANNEX_SEA_PACK_ID"] != "" && ViewState["ANNEX_SEA_PACK_ID"] != null)
            {
                txtGroup.Text = gv_details.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
                txtFrom.Text = gv_details.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
                txtTo.Text = gv_details.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
                txtPackageType.Text = gv_details.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
                txtFrom_Desc.Text = gv_details.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
                txtTo_Desc.Text = gv_details.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");

                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = ViewState["ANNEX_SEA_PACK_ID"].ToString();
                hdn_update.Value = ViewState["ANNEX_SEA_PACK_ID"].ToString();

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

                if (Session["JOB_LOCK"] != null && Session["JOB_LOCK"] != "")
                {
                    JOB_LOCK = Session["JOB_LOCK"].ToString();

                    if (Convert.ToInt32(JOB_LOCK) == 1)
                    {
                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;
                        btnNew.Enabled = false;
                        btnSave.Enabled = false;
                    }
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
    protected void gv_details_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_details, "Select$" + e.Row.RowIndex.ToString()));
                }

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
    }
    protected void gv_details_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gv_details.PageIndex = e.NewPageIndex;
            Gridbind_Annex_C_Sea_Package();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
      
    }
    protected void gv_details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            Transaction trans = new Transaction();
            trans.ResetFields(Page.Controls);
            //if (Session["COMPANY_LICENSE"].ToString().ToUpper() == "ERI00158")
            if (Hdringo_cargo.Value.ToString() == "Yes")
            {
                txtFrom_Desc.Focus();
            }
            else
            {
                txtTo.Focus();
            }
            AUTO_GROUPNO();
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
            btnUpdate.CssClass = "updates";

            ViewState["UPDATED_ID"] = null;
            hdn_update.Value = "";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
    }
    protected void txtTo_TextChanged(object sender, EventArgs e)
    {
        try
        {
            // if (Session["COMPANY_LICENSE"].ToString().ToUpper() == "ERI00158")
            if (Hdringo_cargo.Value.ToString() == "Yes")
            {
            }
            else
            {
                if (txtTo.Text != "")
                {
                    int to = Convert.ToInt32(txtTo.Text);
                    if (hdnTotal_pkgs.Value != "")
                    {
                        if (to > Convert.ToInt32(hdnTotal_pkgs.Value))
                        {
                            Alert_msg("Exceed Package Value!", "txtTo");
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
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'ANNEXURE_C_PACKAGE', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'ANNEXURE_C_PACKAGE', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}