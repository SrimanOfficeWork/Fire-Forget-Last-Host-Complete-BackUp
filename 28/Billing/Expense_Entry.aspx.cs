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

    public string Name_Search, errorFolder, fileName, path, img_path, pathFolder,Get_path_folder,EXP_No,Remove_FileName;

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
            //Common_Details();
        }

        //txtExp_Name.Attributes.Add("onblur", "javascript:CallServerside_Cess('" + txtExp_Name.ClientID + "', '" + txtExp_No.ClientID + "')");

        txtExp_Name.Attributes.Add("onblur", "javascript:CallServerside_BL_Exp_Name('" + txtExp_Name.ClientID + "', '" + txtExp_No.ClientID + "')");

        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Expense_Entry/");
        img_path = "~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Expense_Entry/";
        
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

        GV_FILES.DataSource = dt;
        GV_FILES.DataBind();
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

    public void Common_Details()
    {
        ViewState["JOBNO"] = ddlJobNo.SelectedItem.Text;
        ViewState["BRANCH"] = ddlBranch.SelectedItem.Text;

        Get_path_folder = HttpContext.Current.Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + ViewState["BRANCH"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Expense_Entry/");
        //Get_path_folder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + ViewState["BRANCH"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Expense_Entry/");

    }
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_JobNo();
        //Gridbind_Expense_Entry();

        GV_FILES.DataSource = dt;
        GV_FILES.DataBind();
    }

    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlJobNo.SelectedItem.Text != "Select")
        {
            Gridbind_Expense_Entry();
            
            GV_FILES.DataSource = dt;
            GV_FILES.DataBind();
        }
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
            hdn_save_update.Value = "BindFiles";

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
        Load_File_Names();
        
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
        //Expense.FILES = Hdn_Path.Value;

        if (hdn_save_update.Value != "Update")
        {
            Expense.FILES = hdn_filename.Value;
        }
        else
        {
            Expense.TYPE = ddlSelect_Type.SelectedValue;
            Expense.BRANCH = ddlBranch.SelectedValue;
            Expense.JOBNo = ddlJobNo.SelectedValue;
            Expense.WORKING_PERIOD = SELECT_BRANCH;
            Expense.Ename = "Bind_file_Names";

            ds = Expense.RetrieveAll_Expense_Entry_Details();

            string FILES = ds.Tables[0].Rows[0]["FILES"].ToString();

            var count = FILES.Count(x => x == ',');

            if (count < 4)
            {

                if (FILES != "")
                {
                    Expense.FILES = FILES + "," + hdn_filename.Value;
                }
                else
                {
                    Expense.FILES = hdn_filename.Value;
                }
            }
            else
            {
                Alert_msg(" Up to 5 Files only Acceptable");
                Expense.FILES = FILES;
            }
        }
        
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
            ////int EXPENSE_ID = 0;
            string EXPENSE_ID = "";
            string a2 = "S";

            hdn_save_update.Value = "Save";

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

        Load_File_Names();
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
        //Transact.ResetFields(Page.Controls);
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;
        btnUpdate.CssClass = "updates";

        ViewState["UPDATED_ID"] = null;
        //hdn_update_Certificate.Value = "";
        //txtCertificateNo.Focus();

        Clear();
    }

    public void Clear()
    {
        txtExp_No.Text = "";
        txtExp_Date.Text = "";
        txtExp_Name.Text = "";
        txtCash_Amount.Text = "";
        txtReceivable_Person.Text = "";
        txtAmt_TransferTo.Text = "";
        txtRemarks.Text = "";
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string a2 = "U";
        EXPENSE_ID = ViewState["ExpenseID"].ToString();

        
        hdn_save_update.Value = "Update";

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
        Load_File_Names();
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

        if (txtExp_No.Text != "")
        {
            for (int i = 0; i < fileCollection.Count; i++)
            {
                HttpPostedFile uploadfile = fileCollection[i];

                string fileName = Path.GetFileName(uploadfile.FileName);
                
                if (fileName.Length < 30)
                {
                    hdn_filename.Value = fileName;

                    //var count = Remove_FileName.Count(x => x == ',');


                    string ext = Path.GetExtension(uploadfile.FileName).ToLower();
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif" || ext == ".doc" || ext == ".docx" || ext == ".xls" || ext == ".xlsx" || ext == ".pdf" || ext == ".txt")
                    {
                        if (uploadfile.ContentLength > 0)
                        {
                            if (uploadfile.ContentLength < 10485760)
                            {
                                string file = ddlJobNo.SelectedValue.ToString();
                                string Branch_Name = ddlBranch.SelectedItem.Text;

                                ViewState["file"] = file;

                                //string ppp = Path.GetTempPath();

                                Get_path_folder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Branch_Name + "/" + Session["currentuser"].ToString() + "/" + "Expense_Entry/");

                                pathFolder = Get_path_folder + ViewState["file"].ToString() + "\\" + txtExp_No.Text;

                                if (Directory.Exists(pathFolder) == false)
                                {
                                    Directory.CreateDirectory(pathFolder);
                                }

                                //*********************

                                path = pathFolder + "\\" + hdn_filename.Value;

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

                                //Image1.ImageUrl = img_path + hdn_filename.Value;
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
                else
                {
                    Alert_msg("File Name Should Not be More than 30 Characters..");
                }
            }

                Alert_msg("File Uploaded..");
            }
        
        else
        {
            Alert_msg("Enter the Exp No");
        }
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

    [System.Web.Services.WebMethod]
    public static string DropDown_BL_EXP_Name(string name)
    {
        DataSet ds = new DataSet();
        Auto_Search Auto = new Auto_Search();

        Auto.Enamesearch = name;
        Auto.NSearch = name;
        Auto.Ename = "BL_CHARGE_MASTER_SELECT";
        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

        if (ds.Tables[0].Rows.Count > 0)
        {
            string txtExp_Name = ds.Tables[0].Rows[0]["CHARGE_NAME"].ToString();

            name = txtExp_Name;
        }

        return name;
    }

    public void DownloadFile()
    {
        Common_Details();
        
        string EXP_NO = ViewState["EXP_NO"].ToString();

        string path1 = HttpContext.Current.Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Expense_Entry/"); 
        

        string name = ViewState["grid_file"].ToString();

        string lcd = Get_path_folder + ViewState["JOBNO"].ToString() + "\\" + EXP_NO + "\\" + name;
        Response.AppendHeader("content-disposition",
            "attachment; filename=" + name);
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(lcd);
        Response.End();
    }

    protected void GV_FILES_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Enabled = true;

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes["onmouseout"] = "this.style.background='white'";
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.GV_FILES, "Select$" + e.Row.RowIndex.ToString()));
           
        }
    }

    protected void GV_FILES_RowCreated(object sender, GridViewRowEventArgs e)
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

    public void Load_File_Names()
    {
        Common_Details();

        if (hdn_save_update.Value != "BindFiles")
        {
            Expense.EXP_NO = txtExp_No.Text;
            EXP_No = txtExp_No.Text;
        }
        else
        {
            Expense.EXP_NO = ViewState["EXP_NO"].ToString();
            EXP_No = ViewState["EXP_NO"].ToString();
        }
 
        Expense.TYPE = ddlSelect_Type.SelectedValue;
        Expense.BRANCH = ddlBranch.SelectedValue;
        Expense.JOBNo = ddlJobNo.SelectedValue;
        Expense.WORKING_PERIOD = SELECT_BRANCH;
        Expense.Ename = "Bind_file_Names";

        string JobNo = ddlJobNo.SelectedItem.Text;

        pathFolder = Get_path_folder + JobNo + "\\" + EXP_No;


        if (Directory.Exists(pathFolder) == false)
        {
            Directory.CreateDirectory(pathFolder);
        }

        ds = Expense.RetrieveAll_Expense_Entry_Details();

        string FILES1 = ds.Tables[0].Rows[0]["FILES"].ToString();

        if (FILES1.Contains(','))
        {
            string[] file1 = FILES1.Split(',');

            string[] file2 = file1;

           
            ArrayList list = new ArrayList();
            //list.Add(file2.ToList());
            list.AddRange(file2);

            //list.Add("ccc");
            //list.Add("ddd");
                      
           DataTable dtt = new DataTable();
           dtt.Columns.Add("FILES");

               foreach (string item in list)
               {
                   dtt.Rows.Add(item);
               }

            GV_FILES.DataSource = dtt;
            GV_FILES.DataBind();
        }
        else
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (FILES1 != "")
                {
                    GV_FILES.DataSource = ds.Tables[0];
                    GV_FILES.DataBind();
                }
                else
                {
                    GV_FILES.DataSource = dt;
                    GV_FILES.DataBind();
                }
            }
        }
    }
    protected void GV_FILES_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["grid_file"] = GV_FILES.SelectedRow.Cells[0].Text;
       
        ViewState["FILES"] = Convert.ToString(this.GV_FILES.SelectedDataKey.Value);

         string index = ViewState["FILES"].ToString();

         if (hdn_Function.Value == "Delete")
         {
             DeleteFile(index);
             Bind_FileName(index);

             hdn_Function.Value = "";

             Load_File_Names();
         }
         else
         {
             DownloadFile();
         }       
    }

[System.Web.Services.WebMethod]
    public void Bind_FileName(string filename)
    {
        string EXP_NO = ViewState["EXP_NO"].ToString();


        Expense.TYPE = ddlSelect_Type.SelectedValue;
        Expense.BRANCH = ddlBranch.SelectedValue;
        Expense.JOBNo = ddlJobNo.SelectedValue;
        Expense.EXP_NO = EXP_NO;
        Expense.WORKING_PERIOD = SELECT_BRANCH;
        Expense.Ename = "Bind_file_Names";

        ds = Expense.RetrieveAll_Expense_Entry_Details();

        string FILES = ds.Tables[0].Rows[0]["FILES"].ToString();

        if (FILES.Contains(','))
        {
            string[] file1 = FILES.Split(',');

            string[] file2 = file1;


            ArrayList list = new ArrayList();
            list.AddRange(file2);
        

            DataTable dtt = new DataTable();
            dtt.Columns.Add("FILES");

            foreach (string item in list)
            {
                if (filename == item)
                {
                    Remove_FileName = FILES.Replace(filename, "").TrimEnd(',');

                }
            }
            

            Remove_FileName = Remove_FileName.Replace(",,", ",").TrimStart(',');
            Update_FileNames(Remove_FileName);

            GV_FILES.DataSource = dtt;
            GV_FILES.DataBind();
        }
        else
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                Update_FileNames("");
               
            }
        }
    }

    [System.Web.Services.WebMethod]
    public void Update_FileNames(string Update_Filename)
    {
        Common_Details();


        Expense.EXPENSE_ID = "";
        Expense.JOBNo = ddlJobNo.SelectedValue;
        Expense.TYPE = ddlSelect_Type.SelectedValue;
        Expense.BRANCH = ddlBranch.SelectedValue;
        Expense.WORKING_PERIOD = SELECT_BRANCH;
        Expense.EXP_NO = txtExp_No.Text;
        Expense.FILES = Update_Filename;
        Expense.Ename = "Delete_File_Only";

        ds = Expense.RetrieveAll_Expense_Entry_Details();

            if (ds.Tables[0].Rows.Count > 0)
            {
             GV_FILES.DataSource = ds.Tables[0];
             GV_FILES.DataBind();
            }
            else
            {
               GV_FILES.DataSource = dt;
               GV_FILES.DataBind();
            }
    

        Alert_msg("File Removed");

    }

    [System.Web.Services.WebMethod]
    public void DeleteFile(string filename)
    {
        Common_Details();

        string Filename = filename;
        string pathFolder = Get_path_folder + ViewState["JOBNO"].ToString() + "\\" + txtExp_No.Text;

        DirectoryInfo dir = new DirectoryInfo(pathFolder);

        foreach (FileInfo fi in dir.GetFiles())
        {
            if (Filename == fi.Name)
            {
                fi.Delete();
            }
        }

        Alert_msg("File Deleted");
    }
   
}