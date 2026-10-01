using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;

public partial class Expense_Entry_PathTest : ThemeClass
{
    
    User_Creation user_Create = new User_Creation();
    Transaction Transact = new Transaction();

    SqlConnection con;
    SqlCommand cmd;
    DataSet dtuser = new DataSet();
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    public string QUOTE_ID = "";
    ErrorLogs er = new ErrorLogs();
    DropDownList ddl = new DropDownList();
    string SP_QUERY;

    Expense_Entry Expense = new Expense_Entry();

    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public int i, Update_Id;
    public string AUTO_ID;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    public string Company_ID;
    public string EXPENSE_ID = "";

    public string Name_Search, errorFolder, fileName, path, img_path, pathFolder;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
       
        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        Company_ID = Session["COMPANY_ID"].ToString();

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

        if (!IsPostBack)
        {
            ddlSelect_Type.Items.Clear();
            //ddlSelect_Type.Items.Add("Select");
            ddlSelect_Type.Items.Add("Import");
            ddlSelect_Type.Items.Add("Export");


            ddlCash_Mode.Items.Clear();
            ddlCash_Mode.Items.Add("Cash");
            ddlCash_Mode.Items.Add("Cheque");
            ddlCash_Mode.Items.Add("Net Banking");
            
            //Get_JobNo();
            Bind_Branches();
        }

        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Expense_Entry/");
        img_path = "~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Expense_Entry/";
        //if (!IsPostBack)
        //{
        //    if (Directory.Exists(errorFolder) == false)
        //    {
        //        Directory.CreateDirectory(errorFolder);
        //    }

        //    //LoadJobNo();

        //}
    }

    public void Get_JobNo()
    {
        if (ddlSelect_Type.SelectedValue != "Select")
        {
            if (ddlBranch.SelectedValue != "")
            {

                Expense.JOBNo = "";
                Expense.Ename = "select_jobno";
                Expense.Workingperiod = ddlBranch.SelectedValue.ToString();
                Expense.TYPE = ddlSelect_Type.SelectedValue.ToString();

                ddlJobNo.DataSource = Expense.RetrieveAll_Details();
                ddlJobNo.DataValueField = "JOBNO";
                ddlJobNo.DataTextField = "JOBNO";
                ddlJobNo.DataBind();
                ddlJobNo.Items.Remove("0");
                ddlJobNo.Items.Insert(0, "Select");
            }
            else
            {
                ddlJobNo.Items.Clear();
            }
        }
        else
        {
            ddlJobNo.Items.Clear();
        }
    }
    protected void ddlSelect_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_JobNo();
    }

    public void Bind_Branches()
    {

        string id = Company_ID;
        Expense.COMPANY_ID = id;
        Expense.Ename = "Bind_Branches";
        ds = Expense.RetrieveAll_Details();
        ddlBranch.DataSource = ds.Tables[0];
        ddlBranch.DataTextField = "BRANCH";
        ddlBranch.DataValueField = "BRANCH";
        ddlBranch.DataBind();
        ddlBranch.Items.Remove("0");
        ddlBranch.Items.Insert(0, "");
    }
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_JobNo();
        //Gridbind_Expense_Entry();
    }

    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Gridbind_Expense_Entry();
    }

    protected void gv_Expense_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Expense.PageIndex = e.NewPageIndex;
        Gridbind_Expense_Entry();
    }
    protected void gv_Expense_RowCreated(object sender, GridViewRowEventArgs e)
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
    protected void gv_Expense_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
                e.Row.Enabled = true;

                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                //e.Row.Attributes["onmouseout"] = "this.style.background='white'";
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_Expense, "Select$" + e.Row.RowIndex.ToString()));
                        

            string MINDATE = "01/01/1900";

            if (e.Row.Cells[2].Text == MINDATE)
            {
                if (Convert.ToDateTime(e.Row.Cells[2].Text) <= Convert.ToDateTime(MINDATE))
                    e.Row.Cells[2].Text = string.Empty;
            }

        }
    }
    protected void gv_Expense_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["ExpenseID"] = Convert.ToString(this.gv_Expense.SelectedDataKey.Value);

        if (ViewState["ExpenseID"] != "" && ViewState["ExpenseID"] != null)
        {

            txtExp_No.Text = gv_Expense.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");

            ViewState["EXP_NO"] = txtExp_No.Text;

            txtExp_Name.Text = gv_Expense.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");

            txtExp_Date.Text = gv_Expense.SelectedRow.Cells[4].Text.Replace("01/01/1900", "");

            ddlCash_Mode.Items.Clear();
            string ddlCashMode = gv_Expense.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");

            ddlCash_Mode.Items.Clear();
            ddlCash_Mode.Items.Add("Cash");
            ddlCash_Mode.Items.Add("Cheque");
            ddlCash_Mode.Items.Add("Net Banking");

            ddlCash_Mode.Items.Remove(ddlCashMode);
            ddlCash_Mode.Items.Insert(0, ddlCashMode);

            txtCash_Amount.Text = gv_Expense.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            txtReceivable_Person.Text = gv_Expense.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            txtAmt_TransferTo.Text = gv_Expense.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");

            txtRemarks.Text = gv_Expense.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");


            //FileUpload1.HasFile = img_path + hdn_filename.Value;

            ////FOR UPDATED SUCCESSFULLY
            //ViewState["UPDATED_ID"] = null;
            //ViewState["UPDATED_ID"] = ViewState["ExpenseID"].ToString();
            //hdn_update_Certificate.Value = ViewState["CertificateID"].ToString();

            ////FOR UPDATED SUCCESSFULLY
            //btnUpdate.CssClass = "updates";

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

    public void  insert_update(string EXPENSE_ID, string flag)
    {
        Expense.EXPENSE_ID = EXPENSE_ID;
        Expense.JOBNo = ddlJobNo.SelectedValue;//call session value from general details
        Expense.TYPE = ddlSelect_Type.SelectedValue;
        Expense.BRANCH = ddlBranch.SelectedValue;
        Expense.EXP_NO = txtExp_No.Text;
        Expense.EXP_DATE = txtExp_Date.Text;
        Expense.EXP_NAME = txtExp_Name.Text;

        Expense.CASH_MODE = ddlCash_Mode.SelectedValue;
        Expense.CASH_AMT = txtCash_Amount.Text;
        Expense.RECEIVABLE_PERSON = txtReceivable_Person.Text;
        Expense.AMT_TRANSFER_TO = txtAmt_TransferTo.Text;
        Expense.FILES = Hdn_Path.Value;
        //Expense.FILES = hdn_filename.Value;
        Expense.REMARKS = txtRemarks.Text;

        Expense.CREATED_BY = currentuser;
        Expense.MODIFIED_BY = currentuser;

        Expense.BRANCH_CODE = currentbranch;
        Expense.flag = flag;
        Expense.YEAR = "";
        Expense.WORKING_PERIOD = Working_Period;
        
        //Expense.BRANCH_COMMON = SELECT_BRANCH;

        ds = Expense.Expense_Entry_insertupdate();
        i = Expense.result;
        //Grid_Empty();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string EXPENSE_ID = "";
            string a2 = "S";
            
           insert_update(EXPENSE_ID, a2);
            //HiddenField1.Value = Convert.ToString(quote.UPDATE_ID);

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
                Gridbind_Expense_Entry();
            }
            else if (i == 2)
            {                
                Alert_msg("Already exixts!", "btnSave");

                //btnSave.Focus();
            }
            else
            {              
                Alert_msg("Not Saved", "btnNew");

                //btnNew.Focus();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }       
    }

     public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'EXPENSE ENTRY', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'EXPENSE ENTRY', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        //ddlCertificateType.Items.Clear();
        //ddlCertificate_Type();
        Transact.ResetFields(Page.Controls);
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;
        btnUpdate.CssClass = "updates";

        ViewState["UPDATED_ID"] = null;
        //hdn_update_Certificate.Value = "";
        //txtCertificateNo.Focus();

        //Gridbind_Certificate();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string a2 = "U";       
        EXPENSE_ID = ViewState["ExpenseID"].ToString();

        insert_update(EXPENSE_ID, a2);
        if (i == 1)
        {
            
            if (ViewState["UPDATED_ID"] != null)
            {
                
                Alert_msg("Expense Updated Successfully", "btnUpdate");
                Gridbind_Expense_Entry();

            }
            else
            {
                
                Alert_msg("Expense Saved Successfully", "btnUpdate");

            }
        }
        else
        {
            
            Alert_msg("Expense Not Saved");

        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            Expense.JOBNo = ddlJobNo.SelectedValue;
            Expense.TYPE = ddlSelect_Type.SelectedValue;
            Expense.BRANCH = ddlBranch.SelectedValue;

            Expense.EXPENSE_ID = ViewState["ExpenseID"].ToString();

            Expense.WORKING_PERIOD = SELECT_BRANCH;

            Expense.Ename = "delete";
            ds = Expense.RetrieveAll_Expense_Entry_Details();
            Grid_Empty();
            int ii = 0;
            ii = Expense.result;

            if (ii == 1)
            {
                //lblMsg.Text = " Record Deleted";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record  Deleted')</script>", false);


                //Gridbind_Certificate();
                btnNew_Click(sender, e);
                Alert_msg("Expense Deleted");
                Gridbind_Expense_Entry();
            }


            else
            {
                //lblMsg.Text = " Record Not Deleted";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Deleted')</script>", false);
                Alert_msg("Expense Not Deleted");

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void btn_upload_Click(object sender, EventArgs e)
    {
        HttpFileCollection fileCollection = Request.Files;

        for (int i = 0; i < fileCollection.Count; i++)
        {
            HttpPostedFile uploadfile = fileCollection[i];
            hdn_filename.Value = fileName = Path.GetFileName(uploadfile.FileName);

            string ext = Path.GetExtension(uploadfile.FileName).ToLower();
            if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif" || ext == ".doc" || ext == ".docx" || ext == ".xls" || ext == ".xlsx" || ext == ".pdf")
            {
                if (uploadfile.ContentLength > 0)
                {
                    if (uploadfile.ContentLength < 10485760)
                    {
                        //string file = ddlJobNo.SelectedValue.ToString() + "~~" + fileName;
                        string file = ddlJobNo.SelectedValue.ToString();
                        //path = errorFolder + file + ext;

                        ViewState["file"] = file;

                        // create directory***************
                        pathFolder = errorFolder + ViewState["file"].ToString();
                       
                        //if (!IsPostBack)
                        //{
                            if (Directory.Exists(pathFolder) == false)
                            {
                                Directory.CreateDirectory(pathFolder);
                            }

                        //*********************

                        path = pathFolder +"//"+ hdn_filename.Value;

                        Hdn_Path.Value = pathFolder;

                        if (File.Exists(path))
                        {
                            Alert_msg("File Already Exists!");

                            DirectoryInfo dir = new DirectoryInfo(errorFolder);

                            foreach (FileInfo fi in dir.GetFiles())
                            {
                                if (hdn_filename.Value == fi.Name)
                                {
                                    fi.Delete();
                                }

                            }

                        }
                        else
                        {
                            
                        }

                        uploadfile.SaveAs(path);

                        Image1.ImageUrl = img_path + hdn_filename.Value;
                    }
                    else
                    {
                        Alert_msg("File size exceeds maximum limit 10 MB.");
                    }
                }
                else
                {
                    Alert_msg("File cannot be empty");
                }
            }
            else
                Alert_msg(ext + " File format not allowed.");
        }

        Alert_msg("File Uploaded..");

    }

    public void Gridbind_Expense_Entry()
    {
        Expense.EXPENSE_ID = "";
        Expense.TYPE = ddlSelect_Type.SelectedValue;
        Expense.BRANCH = ddlBranch.SelectedValue;
        Expense.JOBNo = ddlJobNo.SelectedValue;           

        //Transact.WORKING_PERIOD = Working_Period;
        Expense.WORKING_PERIOD = SELECT_BRANCH;
        //Transact.flag = "";

        Expense.Ename = "select_con";
        ds = Expense.RetrieveAll_Expense_Entry_Details();
        Grid_Empty();


    }

    public void Grid_Empty()
    {
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                gv_Expense.DataSource = ds;

                gv_Expense.DataBind();
            }
            else
            {
                gv_Expense.DataSource = dt;
                gv_Expense.DataBind();
            }

        }
        else
        {

            gv_Expense.DataSource = dt;
            gv_Expense.DataBind();
        }
    }

    protected void test_Click(object sender, EventArgs e)
    {
        string JobNo = ddlJobNo.SelectedItem.Text;
        string xx = errorFolder + JobNo;

        Process.Start(xx);
        //OpenMicrosoftWord(xx);
        //System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
        //{
        //    FileName = xx,
        //    UseShellExecute = true,
        //    Verb = "open"
        //});
    }

    static void OpenMicrosoftWord(string file)
    {
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = "IExplore.exe";
        startInfo.Arguments = file;
        Process.Start(startInfo);
    }
}