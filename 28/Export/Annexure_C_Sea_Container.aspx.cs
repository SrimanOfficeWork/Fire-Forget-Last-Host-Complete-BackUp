using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;

public partial class Export_Annexure_C_Sea_Container : ThemeClass
{
    DataSet dtuser = new DataSet();
    AppSession aps = new AppSession();
    AdminMasterDetails admin = new AdminMasterDetails();
    Annexure_C_Sea_Container ANNEX_C_Sea_Con = new Annexure_C_Sea_Container();
    ErrorLogs er = new ErrorLogs();
    public int i, Cont_id_Max;
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet ds = new DataSet();
    DataSet dsXML = new DataSet();
    DataTable dt = new DataTable();

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
    public string JOB_LOCK, JOB_RELEASE;
    User_Creation user_Create = new User_Creation();
    public string errorFolder = "", logline = "", logFileName = "",Del_Status="";

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

            errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "EXPORT_ANNEXURE_SEA_CONTAINER");
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
            //ddl_Type();
            //ddl_Size();

            //errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "EXPORT_ANNEXURE_SEA_CONTAINER");

            if (Session["EXPORT_JOBNO"] != null)
            {
                EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();

                if (!IsPostBack)
                {
                    //----------------SETTING SCREEN PERMISSION---------------//
                    Screen_Id = 12;
                    Page_Rights(Screen_Id);
                    //----------------SETTING SCREEN PERMISSION---------------//
                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                    btnNew.Visible = true;
                    btn_Save_New.Visible = true;

                    ddl_Type();
                    ddl_Size();
                    txtContainerNo.Focus();
                    Gridbind_Annex_C_Sea_Container();
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
                    btn_Save_New.Enabled = false;

                    btnNew.ToolTip = "This Job is Locked by Admin";
                    btnSave.ToolTip = "This Job is Locked by Admin";
                    btn_Save_New.ToolTip = "This Job is Locked by Admin";
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
                            btn_Save_New.Enabled = false;
                            MP_U.Show();

                            lblUser_Msg.Text = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                            btnUpdate.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnDelete.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnNew.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnSave.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btn_Save_New.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

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
                btn_Save_New.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                btnNew.ToolTip = "You don't have permission to access";
                btnSave.ToolTip = "You don't have permission to access";
                btn_Save_New.ToolTip = "You don't have permission to access";
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
                    btn_Save_New.Enabled = true;
                    btnNew.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                    btn_Save_New.Enabled = false;
                    btnSave.ToolTip = "You don't have permission to access";
                    btn_Save_New.ToolTip = "You don't have permission to access";
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
                    //hdn_Grid_Disable.Value = "1";
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
                    //hdn_Grid_Disable.Value = "1";
                }
            }
            //if (hdn_Grid_Disable.Value == "1")
            //gv_details.ToolTip = "You don't have permission to access";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
    }

    public void Gridbind_Annex_C_Sea_Container()
    {
        try
        {
            ANNEX_C_Sea_Con.ANNEX_SEA_CON_ID = "";
            ANNEX_C_Sea_Con.ANNEX_SEA_CON_JOBNO = EXPORT_JOBNO;
            ANNEX_C_Sea_Con.WORKING_PERIOD = SELECT_BRANCH;
            ANNEX_C_Sea_Con.Ename = "select";
            gv_details.DataSource = ANNEX_C_Sea_Con.RetrieveAll_Annexure_C_Sea_Container_Details();
            gv_details.DataBind();

            //dss = Transact.RetrieveAll_IGM_Details();
            //Grid_Empty();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
    }

    public void ddl_Size()
    {
        try
        {
            ddlSize.Items.Add("20");
            ddlSize.Items.Add("40");
            ddlSize.Items.Add("45");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        
    }

    public void ddl_Type()
    {
        try
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
    }

    public int Export_Annexure_C_Sea_Con_Insert_Update(string Flag, string ANNEX_SEA_CON_ID)
    {
        try
        {
            ANNEX_C_Sea_Con.ANNEX_SEA_CON_ID = ANNEX_SEA_CON_ID;
            ANNEX_C_Sea_Con.ANNEX_SEA_CON_JOBNO = EXPORT_JOBNO;
            ANNEX_C_Sea_Con.ANNEX_SEA_CON_CONTAINERNO = txtContainerNo.Text;
            ANNEX_C_Sea_Con.ANNEX_SEA_CON_SIZE = ddlSize.SelectedValue;
            ANNEX_C_Sea_Con.ANNEX_SEA_CON_TYPE = ddlType.SelectedValue;
            ANNEX_C_Sea_Con.ANNEX_SEA_CON_EXCISE_SEALNO = txtExcise_Seal_No.Text;
            //ANNEX_C_Sea_Con.ANNEX_SEA_CON_SEAL_DATE = txtSealDate.Text;

            string dt;
            if (txtSealDate.Text != "")
            {
                dt = txtSealDate.Text;
            }
            else
            {
                dt = "01/01/1900";
            }
            ANNEX_C_Sea_Con.ANNEX_SEA_CON_SEAL_DATE = dt;

            ANNEX_C_Sea_Con.USER_ID = currentuser;
            ANNEX_C_Sea_Con.flag = Flag;
            ANNEX_C_Sea_Con.BRANCH_CODE = currentbranch;
            ANNEX_C_Sea_Con.WORKING_PERIOD = Working_Period;
            ANNEX_C_Sea_Con.BRANCH_COMMON = SELECT_BRANCH;
            ANNEX_C_Sea_Con.ANNEX_SEA_CON_SEALTYPE_INDICATOR = ddl_SealType_Indicator.SelectedItem.Text;
            ANNEX_C_Sea_Con.ANNEX_SEA_CON_SEAL_DEVICEID = txt_Seal_ID.Text;
            ANNEX_C_Sea_Con.ANNEX_SEA_CON_DOC_TYPE = txt_Movement_DocType.Text;
            ANNEX_C_Sea_Con.ANNEX_SEA_CON_DOC_NUMBER = txt_Movement_DocNo.Text;
            ANNEX_C_Sea_Con.JOBNO_PS = Session["JOBNO_PS"].ToString();


            //i = ANNEX_C_Sea_Con.Annexure_C_Sea_Con_details_insertupdate();
            gv_details.DataSource = ANNEX_C_Sea_Con.Annexure_C_Sea_Con_details_insertupdate();
            gv_details.DataBind();
            i = ANNEX_C_Sea_Con.result;
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
            //string ID = "";
            string F = "S", ANNEX_SEA_CON_ID="0";
            i = Export_Annexure_C_Sea_Con_Insert_Update(F, ANNEX_SEA_CON_ID);
            hdn_update.Value = Convert.ToString(ANNEX_C_Sea_Con.UPDATE_ID);

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
                    btn_Save_New.Visible = false;
                    btnSave.Focus();
                }
                //-----------------------FOR USER RIGHTS--------------------------------//

                ViewState["UPDATED_ID"] = null;
                Alert_msg("Saved Successfully", "btnSave");
                //Gridbind_Annex_C_Sea_Container();
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
            string F = "U", ANNEX_SEA_CON_ID;
            //ANNEX_SEA_CON_ID = ViewState["ANNEX_SEA_CON_ID"].ToString();
            ANNEX_SEA_CON_ID = hdn_update.Value;

            i = Export_Annexure_C_Sea_Con_Insert_Update(F, ANNEX_SEA_CON_ID);
            if (i == 1)
            {                           
                //Gridbind_Annex_C_Sea_Container();
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
            ANNEX_C_Sea_Con.ANNEX_SEA_CON_ID = ViewState["ANNEX_SEA_CON_ID"].ToString();
            ANNEX_C_Sea_Con.ANNEX_SEA_CON_JOBNO = EXPORT_JOBNO;
            ANNEX_C_Sea_Con.Ename = "delete";
            ANNEX_C_Sea_Con.WORKING_PERIOD = SELECT_BRANCH;
            //dtuser = ANNEX_C_Sea_Con.RetrieveAll_Annexure_C_Sea_Container_Details();
            gv_details.DataSource = ANNEX_C_Sea_Con.RetrieveAll_Annexure_C_Sea_Container_Details();

            gv_details.DataBind();
            i = ANNEX_C_Sea_Con.result;

            if (i == 1)
            {
                //Gridbind_Annex_C_Sea_Container();
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
        try
        {
            ViewState["ANNEX_SEA_CON_ID"] = Convert.ToString(this.gv_details.SelectedDataKey.Value);

            if (ViewState["ANNEX_SEA_CON_ID"] != "" && ViewState["ANNEX_SEA_CON_ID"] != null)
            {
                txtContainerNo.Text = gv_details.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");

                ddlSize.Items.Clear();
                string Size = gv_details.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");

                ddl_Size();
                ddlSize.Items.Remove(Size);
                ddlSize.Items.Insert(0, Size);

                ddlType.Items.Clear();
                string type = gv_details.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");

                ddl_Type();
                ddlType.Items.Remove(type);
                ddlType.Items.Insert(0, type);

                txtExcise_Seal_No.Text = gv_details.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
                txtSealDate.Text = gv_details.SelectedRow.Cells[6].Text.Replace("01/01/1900", "");

                ddl_SealType_Indicator.Text = gv_details.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
                txt_Seal_ID.Text = gv_details.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
                txt_Movement_DocType.Text = gv_details.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
                txt_Movement_DocNo.Text = gv_details.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");

                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = ViewState["ANNEX_SEA_CON_ID"].ToString();
                hdn_update.Value = ViewState["ANNEX_SEA_CON_ID"].ToString();

                //FOR UPDATED SUCCESSFULLY
                btnUpdate.CssClass = "updates";

                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btn_Save_New.Visible = false;
                btnNew.Visible = true;
            }
            else
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btn_Save_New.Visible = true;
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

                if (e.Row.Cells[6].Text == MINDATE)
                {
                    if (Convert.ToDateTime(e.Row.Cells[6].Text) <= Convert.ToDateTime(MINDATE))
                        e.Row.Cells[6].Text = string.Empty;
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
            Gridbind_Annex_C_Sea_Container();
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
            txtContainerNo.Focus();

            ddlSize.Items.Clear();
            ddl_Size();
            ddlType.Items.Clear();
            ddl_Type();

            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
            btn_Save_New.Visible = true;
            btnUpdate.CssClass = "updates";

            ViewState["UPDATED_ID"] = null;
            hdn_update.Value = "";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
      
    }
   
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'ANNEXURE_C_CONTAINER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'ANNEXURE_C_CONTAINER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Get_Annex_C_Container_MaxID()
    {
        try
        {
            ANNEX_C_Sea_Con.ANNEX_SEA_CON_ID = "";
            ANNEX_C_Sea_Con.ANNEX_SEA_CON_JOBNO = EXPORT_JOBNO;
            ANNEX_C_Sea_Con.WORKING_PERIOD = SELECT_BRANCH;
            ANNEX_C_Sea_Con.Ename = "Select_MAX_Container_ID";
            ds = ANNEX_C_Sea_Con.RetrieveAll_Annexure_C_Sea_Container_Details();

            if (ds.Tables[0].Rows.Count > 0)
            {
                Cont_id_Max = Convert.ToInt32(ds.Tables[0].Rows[0]["ANNEX_SEA_CON_ID"].ToString());
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        
    }

    public string Get_ExcelFile()
    {
        string connString = "";
        string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
        string path = errorFolder + "\\" + fileuploadExcel.FileName;

        string picExtension;
        string fileName2;
        try
        {
            if (fileuploadExcel.HasFile)
            {
                picExtension = fnGetPictureExtn(fileuploadExcel.FileName);
                fileName2 = fileuploadExcel.FileName;
                addtoGallery1(fileName2, errorFolder);
            }

            if (strFileType.Trim() == ".xls" || strFileType.Trim() == ".xlsx")
            {
                if (strFileType.Trim() == ".xls")
                {
                    connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                }
                else if (strFileType.Trim() == ".xlsx")
                {
                    connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                }
                //----------------------------
                string query = "SELECT * FROM [Sheet1$]";

                OleDbConnection conn = new OleDbConnection(connString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                da.Fill(ds);
                da.Dispose();
                conn.Close();
                conn.Dispose();
            }
            ViewState["ds_Excel_upload"] = ds;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

      
        return strFileType.Trim();
    }

    protected void btn_Delete_All_Invoice_And_Upload_Click(object sender, EventArgs e)
    {
        try
        {
            ANNEX_C_Sea_Con.ANNEX_SEA_CON_ID = "";
            ANNEX_C_Sea_Con.ANNEX_SEA_CON_JOBNO = EXPORT_JOBNO;
            ANNEX_C_Sea_Con.WORKING_PERIOD = SELECT_BRANCH;
            ANNEX_C_Sea_Con.Ename = "Delete_All_Containers";

            dtuser = ANNEX_C_Sea_Con.RetrieveAll_Annexure_C_Sea_Container_Details();
            Gridbind_Annex_C_Sea_Container();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        
    }

    protected void btn_BulkContainer_Upload_Click(object sender, EventArgs e)
    {
        try
        {
            Gridbind_Annex_C_Sea_Container();

            if (gv_details.Rows.Count > 0)
            {
                mp_yesorno.Show();
                Del_Status = "Yes";
            }
            else
            {
                string file_ext = "";             
                if (File.Exists(errorFolder + logFileName))
                {
                    DirectoryInfo dir = new DirectoryInfo(errorFolder);

                    foreach (FileInfo fi in dir.GetFiles())
                    {
                        fi.Delete();
                    }
                    file_ext = Get_ExcelFile();
                    ViewState["File_Exten"] = file_ext;
                }
                else
                {
                    Directory.CreateDirectory(errorFolder);
                    DirectoryInfo dir = new DirectoryInfo(errorFolder);
                    foreach (FileInfo fi in dir.GetFiles())
                    {
                        fi.Delete();
                    }
                    file_ext = Get_ExcelFile();
                    ViewState["File_Exten"] = file_ext;
                }
                Excel_Upload_load(file_ext);
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public void Excel_Upload_load(string file_ext)
    {
        try
        {
            Get_Annex_C_Container_MaxID();
            DataSet Inv_ds = new DataSet();
            Inv_ds = ds = (DataSet)ViewState["ds_Excel_upload"];
            int a = 0, b = 0, c = 1;
            ds.Tables[0].Rows.Add();
            if (ds.Tables[0].Rows.Count > a)
            {
                #region create dataset column
                dsXML.Tables.Add("Export_Annex_C_Container_Details");
                dsXML.Tables[0].Columns.Add("ANNEX_SEA_CON_ID");
                dsXML.Tables[0].Columns.Add("ANNEX_SEA_CON_JOBNO");
                dsXML.Tables[0].Columns.Add("ANNEX_SEA_CON_CONTAINERNO");
                dsXML.Tables[0].Columns.Add("ANNEX_SEA_CON_SIZE");
                dsXML.Tables[0].Columns.Add("ANNEX_SEA_CON_TYPE");
                dsXML.Tables[0].Columns.Add("ANNEX_SEA_CON_EXCISE_SEALNO");
                dsXML.Tables[0].Columns.Add("ANNEX_SEA_CON_SEAL_DATE");
                dsXML.Tables[0].Columns.Add("USER_ID");
                dsXML.Tables[0].Columns.Add("DATE_TIME");
                dsXML.Tables[0].Columns.Add("STATUS");
                dsXML.Tables[0].Columns.Add("BRANCH_CODE");
                dsXML.Tables[0].Columns.Add("YEAR");
                dsXML.Tables[0].Columns.Add("WORKING_PERIOD");
                dsXML.Tables[0].Columns.Add("MODIFIEDBY");
                dsXML.Tables[0].Columns.Add("MODIFIEDON");
                dsXML.Tables[0].Columns.Add("ANNEX_SEA_CON_SEALTYPE_INDICATOR");
                dsXML.Tables[0].Columns.Add("ANNEX_SEA_CON_SEAL_DEVICEID");
                dsXML.Tables[0].Columns.Add("ANNEX_SEA_CON_DOC_TYPE");
                dsXML.Tables[0].Columns.Add("ANNEX_SEA_CON_DOC_NUMBER");
                dsXML.Tables[0].Columns.Add("JOBNO_PS");

                #endregion
                //--------------------End License Details--------------------------//
                if (file_ext == ".xls" || file_ext == ".xlsx")
                {
                    #region read Excel_Format

                    string validateContainer = string.Empty;
                    while (ds.Tables[0].Rows[a][0] != System.DBNull.Value)
                    {

                        DataRow dr = dsXML.Tables[0].NewRow();

                        dr["ANNEX_SEA_CON_ID"] = Cont_id_Max;
                        dr["ANNEX_SEA_CON_JOBNO"] = EXPORT_JOBNO;
                        dr["ANNEX_SEA_CON_CONTAINERNO"] = ds.Tables[0].Rows[a][0].ToString();
                        if (ds.Tables[0].Rows[a][0].ToString().Trim().Length != 11)
                        {
                            validateContainer += ds.Tables[0].Rows[a][0].ToString() + " ";
                        }

                        dr["ANNEX_SEA_CON_SIZE"] = ds.Tables[0].Rows[a][1].ToString().TrimEnd();
                        dr["ANNEX_SEA_CON_TYPE"] = ds.Tables[0].Rows[a][2].ToString();
                        dr["ANNEX_SEA_CON_EXCISE_SEALNO"] = ds.Tables[0].Rows[a][3].ToString();

                        //dr["ANNEX_SEA_CON_SEAL_DATE"] = ds.Tables[0].Rows[a][4].ToString();
                        //string SEAL_DATE = Convert.ToDateTime(ds.Tables[0].Rows[a][4].ToString()).ToShortDateString();
                        //string SEAL_DATE1 = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(SEAL_DATE));

                        //dr["ANNEX_SEA_CON_SEAL_DATE"] = Convert.ToDateTime(SEAL_DATE1).ToString(@"MM/dd/yyyy");
                        dr["ANNEX_SEA_CON_SEAL_DATE"] = DateTime.Parse(ds.Tables[0].Rows[a][4].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                        dr["USER_ID"] = currentuser;
                        dr["DATE_TIME"] = LoginDate;
                        dr["STATUS"] = "N";
                        dr["BRANCH_CODE"] = currentbranch;
                        dr["YEAR"] = "";
                        dr["WORKING_PERIOD"] = Working_Period;
                        dr["MODIFIEDBY"] = LoginDate;
                        dr["MODIFIEDON"] = LoginDate;

                        dr["ANNEX_SEA_CON_SEALTYPE_INDICATOR"] = ds.Tables[0].Rows[a][5].ToString();
                        dr["ANNEX_SEA_CON_SEAL_DEVICEID"] = ds.Tables[0].Rows[a][6].ToString();
                        dr["ANNEX_SEA_CON_DOC_TYPE"] = ds.Tables[0].Rows[a][7].ToString();
                        dr["ANNEX_SEA_CON_DOC_NUMBER"] = ds.Tables[0].Rows[a][8].ToString();
                        dr["JOBNO_PS"] = EXPORT_JOBNO;

                        dsXML.Tables[0].Rows.Add(dr);
                        a++;
                        Cont_id_Max = Cont_id_Max + 1;
                    }
                    #endregion

                    if (!string.IsNullOrWhiteSpace(validateContainer))
                    {
                        Alert_msg(validateContainer + " Container Number should be 11 digits...");
                        validateContainer = "";
                        return;
                    }

                    dt = dsXML.Tables["Export_Annex_C_Container_Details"];

                    //dt=  RemoveDuplicateRows(dt, "LICENSE_NO","INV_SL_NO","ITEM_SL_NO");
                    if (dsXML.Tables[0].Rows.Count > 0)
                    {
                        admin.SqlBulk_Upload_Product("EXPORT_ANNEXURE_C_SEA_CONTAINER", dsXML.Tables[0], Session["currentcomp_db"].ToString());
                    }
                }
            }
            Gridbind_Annex_C_Sea_Container();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
    }

    public void addtoGallery1(string picName, string folderName)
    {
        string strFolderPath;
        string strImagePath;
        try
        {
            strFolderPath = Path.Combine(Request.PhysicalApplicationPath, folderName);
            strImagePath = Path.Combine(strFolderPath, picName);
            fileuploadExcel.SaveAs(strImagePath);
        }
        catch
        {
        }
        finally
        {
        }
    }

    public string fnGetPictureExtn(string pictureName)
    {
        try
        {
            if (pictureName.ToUpper().EndsWith(".JPG"))
                return ".JPG";
            else if (pictureName.ToUpper().EndsWith(".JPEG"))
                return ".JPEG";
            else if (pictureName.ToUpper().EndsWith(".GIF"))
                return ".GIF";
            else if (pictureName.ToUpper().EndsWith(".DOC"))
                return ".DOC";
            else if (pictureName.ToUpper().EndsWith(".XLS"))
                return ".XLS";
            else if (pictureName.ToUpper().EndsWith(".PDF"))
                return ".PDF";
            else if (pictureName.ToUpper().EndsWith(".PNG"))
                return ".PNG";
            else if (pictureName.ToUpper().EndsWith(".CDR"))
                return ".CDR";
            else if (pictureName.ToUpper().EndsWith(".PSD"))
                return ".PSD";
            else if (pictureName.ToUpper().EndsWith(".TXT"))
                return ".TXT";
            else if (pictureName.ToUpper().EndsWith(".XLSX"))
                return ".XLSX";
            else
            {
            }
        }
        catch
        {
        }
        finally
        {
        }
        return "";
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
}