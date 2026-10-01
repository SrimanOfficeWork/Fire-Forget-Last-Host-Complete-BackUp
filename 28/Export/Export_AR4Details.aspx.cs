using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.HtmlControls;

public partial class Export_AR4Details : ThemeClass
{
    DataSet dtuser = new DataSet();

    AppSession aps = new AppSession();
    public string Trans_ID = "";
    ErrorLogs er = new ErrorLogs();
    public int i;
    public string AUTO_ID;
    Export_AR4 AR4 = new Export_AR4();
    Export_General_New Export = new Export_General_New();
    public string EXPORT_JOBNO;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE;
    User_Creation user_Create = new User_Creation();

    public string errorFolder = "", logFileName = "", Audit_YN = "";
    int AR4_id_Max = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "EXPORT_AR4");

            txtAR4No.Focus();

            if (Connection.Audit_Logs(Connection.COMPANYID()) == "Y")
            {
                Audit_YN = "Y";
            }
            if (Session["EXPORT_JOBNO"] != null)
            {
                EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();

                if (!IsPostBack)
                {
                    // if (Session["EXPORT_INV_NO"] != null && Session["INV_SLNO"] != null)
                    //{
                    if (!string.IsNullOrEmpty(Request["INV_NO"]) && !string.IsNullOrEmpty(Request["INV_SLNO"]))
                    {
                        hdn_INV_NO.Value = Request["INV_NO"].ToString();
                        hdn_inv_slno.Value = Session["INV_SLNO"].ToString();
                    }

                    //----------------SETTING SCREEN PERMISSION---------------//
                    Screen_Id = 11;
                    Page_Rights(Screen_Id);
                    //----------------SETTING SCREEN PERMISSION---------------//
                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                    btnNew.Visible = true;

                    BindValue();
                }
            }
            else
            {
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
                if (Connection.Current_User().ToUpper() != Session["JOB_USER"].ToString().ToUpper())
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
    public void Page_Rights(int i)
    {
        try
        {
            user_Create.RetrieveAll_User_Screen_Rights_Details(i);
            PAGE_WRITE = user_Create.PAGE_WRITE;
            PAGE_READ = user_Create.PAGE_READ;
            PAGE_MODIFY = user_Create.PAGE_MODIFY;
            PAGE_DELETE = user_Create.PAGE_DELETE;

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
                    btnUpdate.Enabled = true;
                else
                {
                    btnUpdate.Enabled = false;
                    btnUpdate.ToolTip = "You don't have permission to access";

                }
                //---------------DELETE BUTTON------------------//

                if (PAGE_DELETE == "True")
                    btnDelete.Enabled = true;
                else
                {
                    btnDelete.Enabled = false;
                    btnDelete.ToolTip = "You don't have permission to access";

                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    public DataSet BindValue()
    {

        AR4.AR4_ID = "";
        AR4.AR4_JOBNO = EXPORT_JOBNO;
        AR4.AR4_INVOICE_NO = hdn_INV_NO.Value;
        AR4.Ename = "select";
        AR4.WORKING_PERIOD = Connection.Get_Company_Type();
        dtuser = AR4.RetrieveAll_Details();
        gv_Item.DataSource = dtuser;
        gv_Item.DataBind();

        // ----Audit Modified Data -----------------------------------
        if (Audit_YN == "Y")
        {
            DataTable dt_ar4 = new DataTable();
            dt_ar4 = dtuser.Tables[0].Clone();
            Tbl_Filed_Modified_History(dt_ar4);
        }

        if (dtuser.Tables[0].Rows.Count == 0)
        {
            lnk_Delte2.Visible = false;
        }
        return dtuser;
        gv_Item.Attributes.Add("style", "table-layout:fixed");

        AR4 = null;

    }

    public void Edit_Annexure_Details()
    {
        try
        {
            if (Session["EXPORT_JOBNO"] != null)
            {
                BindValue();
            }
            else
                Button_Visible();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    public void Button_Visible()
    {
        try
        {
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public int Export_Annexure_Insert_Update(string Flag)
    {
        try
        {
            Export_AR4 AR4 = new Export_AR4();
            string dt;
            if (txtAR4Date.Text != "")
            {
                dt = txtAR4Date.Text;

            }
            else
            {
                dt = "01/01/1900";
            }
            AR4.AR4_ID = HiddenField1.Value;
            AR4.AR4_JOBNO = EXPORT_JOBNO;
            AR4.AR4_DATE = dt;
            AR4.AR4_NO = txtAR4No.Text;
            AR4.AR4_COMMISSION_RATE = txtCommissionRate.Text;
            AR4.AR4_DIVISION = txtDivision.Text;
            AR4.AR4_RANGE = txtRange.Text;
            AR4.AR4_REMARKS = txtMarks_Numbers.Text;

            AR4.USER_ID = Connection.Current_User();

            AR4.flag = Flag;
            AR4.BRANCH_CODE = Connection.Current_Branch();
            AR4.WORKING_PERIOD = Connection.WorkingPeriod();
            AR4.AR4_INVOICE_NO = hdn_INV_NO.Value;
            AR4.AR4_INVOICE_SLNO = hdn_inv_slno.Value;
            AR4.BRANCH_COMMON = Connection.Get_Company_Type();

            AR4.AR4_ITEM_NO = txtitem_No.Text;

            gv_Item.DataSource = AR4.Export_AR4_details_insertupdate();
            gv_Item.DataBind();
            i = AR4.result;
            Export.Exp_Job_Logs_All_Details(EXPORT_JOBNO, hdn_inv_slno.Value, "", "AR4 Details", Flag, "Insert");
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
            if (txtAR4No.Text != "")
            {
                if (txtAR4Date.Text != "")
                {
                    if (txtitem_No.Text != "")
                    {

                        i = Export_Annexure_Insert_Update("S");
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
                        else
                        {
                            btnUpdate.Visible = false;
                            btnDelete.Visible = false;
                            btnSave.Visible = true;
                            btnNew.Visible = true;
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
                            Alert_msg("Not Saved", "btnSave");

                        }
                    }
                    else
                    {
                        Alert_msg("AR4 ItemNo - Mandatory");
                    }
                }
                else
                {
                    Alert_msg("AR4 Date - Mandatory");
                }
            }
            else
            {
                Alert_msg("AR4 No - Mandatory");
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

            i = Export_Annexure_Insert_Update("U");
            if (i == 1)
            {
                // ----Audit Modified Data -----------------------------------
                if (Audit_YN == "Y")
                {
                    Audit_Modified_DataTableComparer();
                }
                //------------------------------------------------------------

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
                Alert_msg("Job No Already Exist!", "btnUpdate");
            }
            else
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = true;
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
            Export_AR4 AR4 = new Export_AR4();

            AR4.AR4_ID = HiddenField1.Value;
            AR4.AR4_JOBNO = EXPORT_JOBNO;

            AR4.Ename = "delete";
            AR4.WORKING_PERIOD = Connection.Get_Company_Type();
            AR4.AR4_INVOICE_NO = hdn_INV_NO.Value;

            dtuser = AR4.RetrieveAll_Details();
            gv_Item.DataSource = dtuser;
            gv_Item.DataBind();
            i = AR4.result;

            if (i == 1)
            {
                btnNew_Click(sender, e);
                Alert_msg("Deleted");
                Export.Exp_Job_Logs_All_Details(EXPORT_JOBNO, hdn_inv_slno.Value, "", "AR4 Details", "D", "Insert");
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
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            Transaction trans = new Transaction();
            trans.ResetFields(Page.Controls);
            Button_Visible();
            btnUpdate.CssClass = "updates";
            ViewState["UPDATED_ID"] = null;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    //protected void gv_Item_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    gv_Item.PageIndex = e.NewPageIndex;

    //    BindValue();
    //    /*flag = "select_con";
    //    Gridbind_ItemDetails(flag);*/

    //}

    protected void gv_Item_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    protected void gv_Item_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if Read Permiision given true for gridview enabled or Disabled----------//
                if (hdn_Grid_Disable.Value == "1")
                {

                    e.Row.Enabled = false;
                }
                else
                {
                    e.Row.Enabled = true;

                    e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                    //e.Row.Attributes["onmouseout"] = "this.style.background='white'";
                    e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_Item, "Select$" + e.Row.RowIndex.ToString()));
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    protected void gv_Item_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["AR4_ID"] = Convert.ToString(this.gv_Item.SelectedDataKey.Value);

            if (ViewState["AR4_ID"] != "" && ViewState["AR4_ID"] != null)
            {
                Date_Time rep = new Date_Time();
                HiddenField1.Value = ViewState["AR4_ID"].ToString();

                txtAR4No.Text = gv_Item.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
                txtAR4Date.Text = gv_Item.SelectedRow.Cells[3].Text.Replace("01/01/1900", "");
                txtCommissionRate.Text = gv_Item.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
                txtDivision.Text = gv_Item.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
                txtRange.Text = gv_Item.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
                txtMarks_Numbers.Text = rep.Replace(gv_Item.SelectedRow.Cells[7].Text);
                txtitem_No.Text = rep.Replace(gv_Item.SelectedRow.Cells[8].Text);

                btnUpdate.CssClass = "updates";

                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = ViewState["AR4_ID"].ToString();
                //FOR UPDATED SUCCESSFULLY

                // ----Audit Modified Data -----------------------------------
                if (Audit_YN == "Y")
                {
                    DataTable_Mapping_Controls((DataTable)ViewState["dt_Prev_Table"]);
                }
                //------------------------------------------------------------

            }
            else
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'EXPORT_AR4', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'EXPORT_AR4', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
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

    public string Get_ExcelFile()
    {
        DataSet ds = new DataSet();
        string connString = "";
        string strFileType = "";
        try
        {
            strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
            string path = errorFolder + "\\" + fileuploadExcel.FileName;

            string picExtension;
            string fileName2;

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

    protected void btn_BulkAR4_Upload_Click(object sender, EventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public void Get_AR4_MaxID()
    {
        DataSet dtuser = new DataSet();
        Export_AR4 AR4 = new Export_AR4();
        try
        {
            AR4.AR4_ID = "";
            AR4.AR4_JOBNO = EXPORT_JOBNO;
            AR4.AR4_INVOICE_NO = hdn_INV_NO.Value;
            AR4.Ename = "Select_MAX_AR4_ID";
            AR4.WORKING_PERIOD = Connection.Get_Company_Type();
            dtuser = AR4.RetrieveAll_Details();

            if (dtuser.Tables[0].Rows.Count > 0)
            {
                AR4_id_Max = Convert.ToInt32(dtuser.Tables[0].Rows[0]["AR4_ID"].ToString());
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }


    }


    public void Excel_Upload_load(string file_ext)
    {
        try
        {
            DataSet ds = new DataSet();
            DataSet dsXML = new DataSet();
            AdminMasterDetails admin = new AdminMasterDetails();

            Get_AR4_MaxID();
            DataSet Inv_ds = new DataSet();
            Inv_ds = ds = (DataSet)ViewState["ds_Excel_upload"];
            int a = 0;
            ds.Tables[0].Rows.Add();
            if (ds.Tables[0].Rows.Count > a)
            {

                #region create dataset column

                dsXML.Tables.Add();

                dsXML.Tables[0].Columns.Add("AR4_ID");
                dsXML.Tables[0].Columns.Add("AR4_JOBNO");
                dsXML.Tables[0].Columns.Add("AR4_NO");
                dsXML.Tables[0].Columns.Add("AR4_DATE");
                dsXML.Tables[0].Columns.Add("AR4_COMMISSION_RATE");
                dsXML.Tables[0].Columns.Add("AR4_DIVISION");
                dsXML.Tables[0].Columns.Add("AR4_RANGE");
                dsXML.Tables[0].Columns.Add("AR4_REMARKS");
                dsXML.Tables[0].Columns.Add("USER_ID");
                dsXML.Tables[0].Columns.Add("DATE_TIME");
                dsXML.Tables[0].Columns.Add("STATUS");
                dsXML.Tables[0].Columns.Add("BRANCH_CODE");
                dsXML.Tables[0].Columns.Add("YEAR");
                dsXML.Tables[0].Columns.Add("WORKING_PERIOD");
                dsXML.Tables[0].Columns.Add("AR4_INVOICE_NO");
                dsXML.Tables[0].Columns.Add("AR4_INVOICE_SLNO");
                dsXML.Tables[0].Columns.Add("AR4_RUN_ID");
                dsXML.Tables[0].Columns.Add("AR4_ITEM_NO");
                dsXML.Tables[0].Columns.Add("MODIFIEDBY");
                dsXML.Tables[0].Columns.Add("MODIFIEDON");


                #endregion

                if (file_ext == ".xls" || file_ext == ".xlsx")
                {
                    #region read Excel_Format

                    while (ds.Tables[0].Rows[a][0] != System.DBNull.Value)
                    {

                        DataRow dr = dsXML.Tables[0].NewRow();

                        dr["AR4_ID"] = AR4_id_Max;
                        dr["AR4_JOBNO"] = EXPORT_JOBNO;
                        dr["AR4_NO"] = ds.Tables[0].Rows[a][1].ToString().Trim();
                        dr["AR4_DATE"] = ds.Tables[0].Rows[a][2].ToString();
                        dr["AR4_COMMISSION_RATE"] = ds.Tables[0].Rows[a][3].ToString();
                        dr["AR4_DIVISION"] = ds.Tables[0].Rows[a][4].ToString();
                        dr["AR4_RANGE"] = ds.Tables[0].Rows[a][5].ToString();
                        dr["AR4_ITEM_NO"] = ds.Tables[0].Rows[a][6].ToString();
                        dr["AR4_REMARKS"] = ds.Tables[0].Rows[a][7].ToString();


                        dr["USER_ID"] = Connection.Current_User();
                        dr["DATE_TIME"] = Session["LoginDate"].ToString();
                        dr["STATUS"] = "N";
                        dr["BRANCH_CODE"] = Connection.Current_Branch();
                        dr["YEAR"] = "";
                        dr["WORKING_PERIOD"] = Connection.WorkingPeriod();

                        dr["AR4_INVOICE_NO"] = hdn_INV_NO.Value;
                        dr["AR4_INVOICE_SLNO"] = ds.Tables[0].Rows[a][0].ToString().Trim();
                        dr["AR4_RUN_ID"] = a + 1;

                        dr["MODIFIEDBY"] = Connection.Current_User();
                        dr["MODIFIEDON"] = Session["LoginDate"].ToString();

                        dsXML.Tables[0].Rows.Add(dr);
                        a++;
                        AR4_id_Max = AR4_id_Max + 1;
                    }
                    #endregion


                    if (dsXML.Tables[0].Rows.Count > 0)
                    {
                        admin.SqlBulk_Upload_Product("EXPORT_AR4_TBL", dsXML.Tables[0], Session["currentcomp_db"].ToString());
                    }
                }
            }
            BindValue();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    protected void btn_Bulk_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dtuser = new DataSet();

            AR4.AR4_ID = "";
            AR4.AR4_JOBNO = EXPORT_JOBNO;
            AR4.AR4_INVOICE_NO = hdn_INV_NO.Value;
            AR4.Ename = "Bulk_delete";
            AR4.WORKING_PERIOD = Connection.Get_Company_Type();
            dtuser = AR4.RetrieveAll_Details();

            gv_Item.DataSource = dtuser;
            gv_Item.DataBind();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    #region  Export Audit Logs

    private void Tbl_Filed_Modified_History(DataTable dt_Curr_tbl_struct)
    {
        try
        {
            ViewState["dt_Prev_Table"] = dt_Curr_tbl_struct;
            DataTable_Mapping_Controls(dt_Curr_tbl_struct);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);

        }
    }

    private void Audit_Modified_DataTableComparer()
    {
        try
        {
            DataTable dt_Prev = (DataTable)ViewState["dt_Prev_Table"];
            DataTable dt_m2 = dt_Prev.Clone();
            DataTable dt_modified = DataTable_Mapping_Controls(dt_m2);
            DataTableComparer Dt_Change = new DataTableComparer();
            Dt_Change.GetMismatchedRowsFast_EXP(dt_Prev, dt_modified, "AR4_INVOICE_SLNO", "AR4 Details", EXPORT_JOBNO, hdn_inv_slno.Value, "", Connection.Current_User(), Connection.Current_Branch());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private DataTable DataTable_Mapping_Controls(DataTable dt_mapping)
    {
        try
        {
            if (dt_mapping.Rows.Count > 0)
            {
                dt_mapping.Rows.Clear();
            }
            DataRow dr = dt_mapping.NewRow();

            dr["AR4_NO"] = txtAR4No.Text.Trim();
            dr["AR4_DATE"] = txtAR4Date.Text.Trim();
            dr["AR4_COMMISSION_RATE"] = txtCommissionRate.Text.Trim();
            dr["AR4_DIVISION"] = txtDivision.Text.Trim();
            dr["AR4_RANGE"] = txtRange.Text.Trim();
            dr["AR4_REMARKS"] = txtMarks_Numbers.Text.Trim();
            dr["AR4_INVOICE_SLNO"] = hdn_inv_slno.Value;
            dr["AR4_ITEM_NO"] = txtitem_No.Text.Trim();

            // ===== ADD ROW =====
            dt_mapping.Rows.Add(dr);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return dt_mapping;
    }

    #endregion
}