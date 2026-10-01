using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Export_Export_Jobbing : ThemeClass
{
    DataSet dtuser = new DataSet();

    AppSession aps = new AppSession();

    DataSet dss = new DataSet();
    DataTable dt = new DataTable();
    Export_Jobbing Job = new Export_Jobbing();
    Export_Item Item = new Export_Item();
    Transaction Transact = new Transaction();

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
    public string EXPORT_JOBNO, INV_SLN0, ITEM_SLNO, SCHEME_CODE, JOB_ID, BE_Date, FLAG, YEAR;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE;
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
            if (Session["TRANSPORT_MODE"] != null)
            {
                hdfTransport_mode.Value = Session["TRANSPORT_MODE"].ToString();
            }
            EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();

            if (Session["Inv_SL_No"] != null)
            {
                INV_SLN0 = Session["Inv_SL_No"].ToString();
                ITEM_SLNO = Session["Item_SLNo"].ToString();
                SCHEME_CODE = Session["Scheme_Code"].ToString();
            }
            else
            {
                Response.Write("<script>window.open('Item_Details.aspx','_parent');</script>");
            }


            if (!IsPostBack)
            {
                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 12;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//

    
                Gridbind_Jobbing();
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;

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

    }

    public void Gridbind_Jobbing()
    {
        Job.JOBBING_ID = "0";
        Job.JOBNO = EXPORT_JOBNO;
        Job.INVOICE_SLNO = INV_SLN0;
        Job.ITEM_SLNO = ITEM_SLNO;
        Job.SCHEME_CODE = SCHEME_CODE;
        Job.WORKING_PERIOD = SELECT_BRANCH;
        Job.Ename = "select_con";
        dss = Job.RetrieveAll_Jobbing_Details();
        Grid_Empty();
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
            gv_jobbing.ToolTip = "You don't have permission to access";
    }
    public void Jobbing_Details_insert_update(string Jobbing_ID, string BE_Date, string flag, string year)
    {
        //---------------------SCHEME CODE TO SAVE IN LICENSE DETAILS----------------------------------------//

        string SCHEME = "";
        if (Session["SCHEME_CODE"] != null)
        {
            SCHEME = Session["SCHEME_CODE"].ToString();
        }
        else
        {
            SCHEME = "";
        }
        //---------------------SCHEME CODE TO SAVE IN LICENSE DETAILS----------------------------------------//

        Job.JOBBING_ID = Jobbing_ID;
        Job.JOBNO = EXPORT_JOBNO;
        Job.INVOICE_SLNO = INV_SLN0;
        Job.ITEM_SLNO = ITEM_SLNO;
        Job.SCHEME_CODE = SCHEME_CODE;
        Job.NOTIFICATION_NO = txtNotification_No.Text;
        Job.BE_NO = txtBE_No.Text;
        Job.BE_DATE = BE_Date;
        Job.BE_INV_SLNO = txtBE_Invoice_SLNo.Text;
        Job.BE_INV_NO = txtBE_Invoice_No.Text;
        Job.BE_ITEM_NO = txtBE_Item_No.Text;
        Job.BE_PORT_CODE = txtBE_PortCode.Text;
        Job.QTY = txtQty.Text;
        Job.UNIT = txtUnit.Text;

        Job.USER_ID = currentuser;
        Job.BRANCH_CODE = currentbranch;
        Job.flag = flag;
        Job.YEAR = year;
        Job.WORKING_PERIOD = Working_Period;

        Job.BRANCH_COMMON = SELECT_BRANCH;
        //i = Transact.Invoice_Details_insertupdate();
        //dss = Job.Export_Jobbing_Insert_Update();
        //Grid_Empty();
        gv_jobbing.DataSource = Job.Export_Jobbing_Insert_Update();

        gv_jobbing.DataBind();
        i = Job.result;

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            JOB_ID = "";

            if (txtBE_Date.Text == "")
            {
                BE_Date = "01/01/1900";
            }
            else
            {
                BE_Date = txtBE_Date.Text;
            }
            FLAG = "S";
            YEAR = "";

            Jobbing_Details_insert_update(JOB_ID, BE_Date, FLAG, YEAR);
            hdn_update_Bond.Value = Convert.ToString(Job.UPDATE_ID);

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
                Alert_msg("Jobbing Saved Successfully", "btnSave");
            }
            //else if (i == 2)
            //{

            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Not Saved, Invoice No Already Exist')</script>", false);

            //}

            else
            {

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Not Saved')</script>", false);
                Alert_msg("Jobbing Not Saved", "btnSave");

            }
            //gv_Reimport.DataSource = dtuser;
            //DataBind();
        }

        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void Grid_Empty()
    {
        if (dss.Tables.Count > 0)
        {
            if (dss.Tables[0].Rows.Count > 0)
            {
                gv_jobbing.DataSource = dss;

                gv_jobbing.DataBind();
            }
            else
            {
                gv_jobbing.DataSource = dt;//add empty row

                gv_jobbing.DataBind();
            }

        }
        else
        {
            gv_jobbing.DataSource = dt;//add empty row

            gv_jobbing.DataBind();

        }
    }
    protected void gv_jobbing_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_jobbing.PageIndex = e.NewPageIndex;
        Gridbind_Jobbing();
    }
    protected void gv_jobbing_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_jobbing, "Select$" + e.Row.RowIndex.ToString()));


            }
            //  if Read Permiision given true for gridview enabled or Disabled----------//

            string MINDATE = "01/01/1900";
            
            if (e.Row.Cells[3].Text == MINDATE)
            {
                if (Convert.ToDateTime(e.Row.Cells[3].Text) <= Convert.ToDateTime(MINDATE))
                    e.Row.Cells[3].Text = string.Empty;
            }

        }
    }
    protected void gv_jobbing_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["JOBBING_ID"] = Convert.ToString(this.gv_jobbing.SelectedDataKey.Value);

        if (ViewState["JOBBING_ID"] != "" && ViewState["JOBBING_ID"] != null)
        {
            //FOR UPDATED SUCCESSFULLY
            ViewState["UPDATED_ID"] = null;
            ViewState["UPDATED_ID"] = ViewState["JOBBING_ID"].ToString();
            hdn_update_Bond.Value = ViewState["JOBBING_ID"].ToString();

            //FOR UPDATED SUCCESSFULLY
            btnUpdate.CssClass = "updates";

            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnNew.Visible = true;
            txtNotification_No.Text = gv_jobbing.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");

            txtBE_No.Text = gv_jobbing.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");

            txtBE_Date.Text = gv_jobbing.SelectedRow.Cells[3].Text.Replace("01/01/1900", "");

            txtBE_Invoice_SLNo.Text = gv_jobbing.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            txtBE_Invoice_No.Text = gv_jobbing.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            txtBE_Item_No.Text = gv_jobbing.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");

            txtBE_PortCode.Text = gv_jobbing.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            txtQty.Text = gv_jobbing.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
            txtUnit.Text = gv_jobbing.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;

        }
    }
    protected void gv_License_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        try
        {
            //JOB_ID = ViewState["JOBBING_ID"].ToString();
            JOB_ID = hdn_update_Bond.Value;

            if (txtBE_Date.Text == "")
            {
                BE_Date = "01/01/1900";
            }
            else
            {
                BE_Date = txtBE_Date.Text;
            }
            FLAG = "U";
            YEAR = "";

            Jobbing_Details_insert_update(JOB_ID, BE_Date, FLAG, YEAR);

            if (i == 1)
            {

                //mo.ResetFields(Page.Controls);

               // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Updated Successfully')</script>", false);
               // Gridbind_Jobbing();
                if (ViewState["UPDATED_ID"] != null)
                {
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>event.preventDefault();alert('Updated Successfully')</script>", false);
                    Alert_msg("Jobbing Updated Successfully", "btnUpdate");

                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>event.preventDefault();alert('Saved Successfully')</script>", false);
                    Alert_msg("Jobbing Saved Successfully", "btnUpdate");

                }  
            }
            //else if (i == 2)
            //{

            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Not Saved, Invoice No Already Exist')</script>", false);

            //}

            else
            {

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
                Alert_msg("Jobbing Not Saved", "btnSave");

            }
            //gv_Reimport.DataSource = dtuser;
            //DataBind();
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

            Job.JOBNO = EXPORT_JOBNO;

            Job.INVOICE_SLNO = INV_SLN0;
            Job.ITEM_SLNO = ITEM_SLNO;


            Job.JOBBING_ID = ViewState["JOBBING_ID"].ToString();

            Job.WORKING_PERIOD = SELECT_BRANCH;
            //Transact.flag = "";

            Job.Ename = "delete";
            //dss = Job.RetrieveAll_Jobbing_Details();
            //Grid_Empty();
            gv_jobbing.DataSource = Job.RetrieveAll_Jobbing_Details();

            gv_jobbing.DataBind();
            int ii = 0;
            ii = Job.result;

            if (ii > 0)
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Deleted')</script>", false);
                //Gridbind_Jobbing();
                //btnDelete.Visible = false;
                //btnUpdate.Visible = false;
                //btnSave.Visible = true;
                btnNew_Click(sender, e);
                Alert_msg("Jobbing Deleted");
            }


            else
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Deleted')</script>", false);
                Alert_msg("Jobbing Not Deleted");

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Transact.ResetFields(Page.Controls);

        txtNotification_No.Focus();
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnSave.Visible = true;
        btnUpdate.CssClass = "updates";

        ViewState["UPDATED_ID"] = null;
        hdn_update_Bond.Value = "";
        //Gridbind_Jobbing();

    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'JOBBING', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'JOBBING', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}