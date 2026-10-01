using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using iTextSharp.text.pdf;
using BussinessObject;
using System.Net;
using Newtonsoft.Json;

public partial class IRN_Autiomation_General : ThemeClass
{
    AppSession aps = new AppSession();
    DataSet ds = new DataSet();
    IRN_Automation IA = new IRN_Automation();
    Global_variables ObjUBO = new Global_variables();
    adminmaster Admin_mas = new adminmaster();
    Manipulation mo = new Manipulation();
    public string currentuser, currentbranch,
        Working_Period, COMPANY_ID, Jobno, upload_doc, folderPath = "", COMPANY_license = "",
        Server_ip, Message, Jobtype, logFile, jobid;





    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Connection.Current_User();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Connection.WorkingPeriod();
        COMPANY_ID = Session["COMPANY_ID"].ToString();
        COMPANY_license = Connection.Company_License();
        hdn_saved.Value = "N";
        Server_ip = Session["currentcomp_db"].ToString();
        if (Request.QueryString["JOBID"] != "" && Request.QueryString["JOBID"] != null)
        {
            jobid = Request.QueryString["JOBID"];


        }

        if (Request.QueryString["guidid"] != "" && Request.QueryString["guidid"] != null)
        {
            txttransid.Text = Request.QueryString["guidid"];


        }
        else
        {
            if (txttransid.Text != "")
            {
                string guidid = txttransid.Text;
                txttransid.Text = guidid;
            }
            else
            {
                txttransid.Text = Guid.NewGuid().ToString();
            }
        }
        if (!Page.IsPostBack)
        {
            Load_Icegate_id();
            //Load_Mail_Type();
            Edit_GeneralDetails();

        }

    }
    public void Edit_GeneralDetails()
    {
        DataSet dss = new DataSet();

        upload_doc = "";
        ObjUBO.A2 = Request.QueryString["JOBID"].ToString();
        ObjUBO.A10 = Jobtype;
        ObjUBO.A11 = txttransid.Text;
        ObjUBO.A15 = "SELECT_CON";
        dss = IA.IRN_Automation_Insert_Update_BG(ObjUBO);

        gv_Details.DataSource = dss.Tables[0];
        gv_Details.DataBind();
        if (gv_Details.Rows.Count > 0)
        {

            string userName = dss.Tables[0].Rows[0]["ICEGATE_USER_NAME"].ToString().Trim();
            string userPass = dss.Tables[0].Rows[0]["ICEGATE_PWD"].ToString().Trim();

            hdn_icegate_user.Value = userName;
            hdn_icegate_pass.Value = userPass;

            // Find matching index first, then set SelectedIndex ONCE — avoids multiple selection error
            int foundIndex = 0; // default to blank (index 0)
            for (int idx = 0; idx < ddlIcegateId.Items.Count; idx++)
            {
                if (ddlIcegateId.Items[idx].Text.Trim().Equals(userName, StringComparison.OrdinalIgnoreCase))
                {
                    foundIndex = idx;
                    break;
                }
            }
            ddlIcegateId.SelectedIndex = foundIndex; // only ONE assignment, no conflict
            
            Load_Mail_Type();
            hdn_mailtype.Value = dss.Tables[0].Rows[0]["Mail_type"].ToString();
            ddlmailtype.SelectedValue = hdn_mailtype.Value; 
            Load_Mail_id();
            hdn_mailid.Value = dss.Tables[0].Rows[0]["Mail_Id"].ToString();
            ddlmailid.SelectedValue = hdn_mailid.Value;
            txtmailhost.Text = dss.Tables[0].Rows[0]["Mail_host"].ToString();
            txtmailpass.Text = dss.Tables[0].Rows[0]["Mail_pass"].ToString();
            txtmailport.Text = dss.Tables[0].Rows[0]["Mail_port"].ToString();
            txtmailssl.Text = dss.Tables[0].Rows[0]["Mail_ssl"].ToString();
            txtmobilno.Text = dss.Tables[0].Rows[0]["Mob_num"].ToString();
            txttenetid.Text = dss.Tables[0].Rows[0]["MailTenentid"].ToString();
            txtclientid.Text = dss.Tables[0].Rows[0]["MailClientid"].ToString();
            txtscreenid.Text = dss.Tables[0].Rows[0]["MailScreenid"].ToString();



            for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
            {
                TextBox txtJobno = (TextBox)gv_Details.Rows[i].FindControl("txtJobno");
                TextBox txtJobType = (TextBox)gv_Details.Rows[i].FindControl("txtJobType");
                TextBox txt_InvSlno = (TextBox)gv_Details.Rows[i].FindControl("txt_InvSlno");
                TextBox txtItemSlNo = (TextBox)gv_Details.Rows[i].FindControl("txtItemSlNo");
                TextBox txtDoc_Code = (TextBox)gv_Details.Rows[i].FindControl("txtDoc_Code");
                TextBox txtFileName = (TextBox)gv_Details.Rows[i].FindControl("txtFileName");
                TextBox txtlevel = (TextBox)gv_Details.Rows[i].FindControl("txtlevel");
                TextBox txt_Doc_No = (TextBox)gv_Details.Rows[i].FindControl("txt_Doc_No");
                TextBox txtIRNno = (TextBox)gv_Details.Rows[i].FindControl("txtIRNno");
                TextBox txtIss_PartyName = (TextBox)gv_Details.Rows[i].FindControl("txtIss_PartyName");
                TextBox txtPlace_Of_Issue = (TextBox)gv_Details.Rows[i].FindControl("txtPlace_Of_Issue");
                TextBox txtIssue_Date = (TextBox)gv_Details.Rows[i].FindControl("txtIssue_Date");
                TextBox txtBenPartyName = (TextBox)gv_Details.Rows[i].FindControl("txtBenPartyName");
                TextBox txtUser = (TextBox)gv_Details.Rows[i].FindControl("txtUser");
                TextBox txtstatus = (TextBox)gv_Details.Rows[i].FindControl("txtstatus");
                TextBox txtslid = (TextBox)gv_Details.Rows[i].FindControl("txtslid");

                txtFileName.Text = dss.Tables[0].Rows[i]["DOC_FILE_NAME"].ToString();
                txtJobType.Text = dss.Tables[0].Rows[i]["JobType"].ToString();
                txtIRNno.Text = dss.Tables[0].Rows[i]["IRN"].ToString();
                txtDoc_Code.Text = dss.Tables[0].Rows[i]["DOC_TYPE"].ToString();
                txtlevel.Text = dss.Tables[0].Rows[i]["DOC_LEVEL"].ToString();
                txtJobno.Text = dss.Tables[0].Rows[i]["JOBNO"].ToString();
                txtUser.Text = dss.Tables[0].Rows[i]["User"].ToString();
                txtstatus.Text = dss.Tables[0].Rows[i]["IRN_STATUS"].ToString();
                txtslid.Text = dss.Tables[0].Rows[i]["SL_NO"].ToString();
                if (txtstatus.Text == "Success.")
                {
                    string baseFolderPath = HttpContext.Current.Server.MapPath("~/Submission/IRN_Doc_Uploads/" + COMPANY_ID + "/" + currentbranch);
                    string targetFolderPath = Path.Combine(baseFolderPath, txttransid.Text);
                    string targetFilePath = Path.Combine(targetFolderPath, txtFileName.Text);

                    if (File.Exists(targetFilePath))
                    {
                        File.Delete(targetFilePath);
                    }
                    if (Directory.Exists(targetFolderPath))
                    {
                        bool isEmpty = !Directory.EnumerateFileSystemEntries(targetFolderPath).Any();

                        if (isEmpty)
                        {
                            try
                            {
                                Directory.Delete(targetFolderPath, true);
                                File.AppendAllText(logFile, "deleting folder: " + folderPath);

                            }
                            catch (Exception ex)
                            {


                            }
                        }

                    }
                }

            }


            string baseFolder = HttpContext.Current.Server.MapPath("~/Submission/IRN_Doc_Uploads/" + COMPANY_ID + "/" + currentbranch);
            string targetFolder = Path.Combine(baseFolder, txttransid.Text);


            if (Directory.Exists(targetFolder))
            {
                bool isEmpty = !Directory.EnumerateFileSystemEntries(targetFolder).Any();

                if (isEmpty)
                {
                    try
                    {
                        Directory.Delete(targetFolder, false);
                        File.AppendAllText(logFile, "Deleted empty folder: " + targetFolder);
                    }
                    catch (Exception ex)
                    {
                        File.AppendAllText(logFile, "Error deleting folder: " + targetFolder + " | " + ex.Message);

                    }
                }
            }

            Session["IRN_STATUS"] = "";


            hdn_saved.Value = "Y";
            hdn_Grid.Value = "Y";
        }
        else
        {
            btndeletefileclose_Click(null, null);
        }
        DataTable firstTable = dss.Tables[0];
        ViewState["CurrentTable"] = firstTable;
        ViewState["UPDATED_ID"] = null;
        btnNew.Visible = false;
        btnDelete.Visible = true;
        btnSave.Visible = true;
        btnGenIRN.Visible = true;

        if (dss.Tables[0].Rows.Count > 0)
        {

            string error = dss.Tables[0].Rows[0]["Icegateerror"].ToString();
            string safeError = HttpUtility.JavaScriptStringEncode(error);
            if (safeError != "")
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + safeError.Replace("\n", "\\n") + "');", true);
            }

        }
        btndelete_Storedfile_Click(null, null);
    }
    public string Load_Doc_type_level(string DocType)
    {
        string Doc_Level = "";
        adminmaster Admin_mas = new adminmaster();
        DataSet ds = new DataSet();
        try
        {
            Admin_mas.EUnit_code = DocType;
            Admin_mas.Ename = "select_SUP_DOCS_TYPE";
            ds = Admin_mas.RetrieveAll_SUPPROTING_DOCS_Master();
            if (ds.Tables[1].Rows.Count > 0)
            {
                Doc_Level = ds.Tables[1].Rows[0]["DOC_LEVEL"].ToString();
            }
            return Doc_Level;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return Doc_Level;
    }

    public string Get_imp_exp_all(string jobno, string JobType, string invsl, string itmsl)
    {
        string Imp_Exp = "";
        try
        {
            ObjUBO.A2 = jobno;
            ObjUBO.A11 = invsl;
            ObjUBO.A14 = itmsl;
            ObjUBO.A10 = JobType;
            ObjUBO.A15 = "Load_Imp_Exp_Data";
            ds = IA.IRN_Automation_Insert_Update_BG(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Imp_Exp = ds.Tables[0].Rows[0]["IMP_EXP"].ToString();
            }
            return Imp_Exp;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return Imp_Exp;
    }

    public void Load_Icegate_id()
    {
        try
        {
            ddlIcegateId.Items.Clear();
            ObjUBO.A14 = "Loading_Icegate_id";
            ds = IA.Retrieve_Icegate_Login_setting_Details(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlIcegateId.DataSource = ds.Tables[0];
                ddlIcegateId.DataTextField = "ICEGATE_USER_NAME";
                ddlIcegateId.DataValueField = "ICEGATE_PWD";
                ddlIcegateId.DataBind();
            }
            ddlIcegateId.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
            ddlIcegateId.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public void Load_Mail_Type()
    {
        try
        {
            string icegateid = ddlIcegateId.SelectedItem.Text;
            string icegatepass = ddlIcegateId.SelectedValue;
            ObjUBO.A15 = "Load_Mailtype_Data";
            ds = IA.IRN_Automation_Insert_Update_BG(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlmailtype.DataSource = ds.Tables[0];
                ddlmailtype.DataTextField = "SERVER_TYPE";
                ddlmailtype.DataValueField = "SERVER_TYPE";
                ddlmailtype.DataBind();
            }
            ddlmailtype.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
            ddlmailtype.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public void Load_Mail_id()
    {
        string Mailid = "";
        string icegateid = ddlIcegateId.SelectedItem.Text;
        string icegatepass = ddlIcegateId.SelectedValue;
        string mailidtype = ddlmailtype.SelectedValue;
        try
        {
            ObjUBO.A12 = ddlmailtype.SelectedValue.ToString();
            ObjUBO.A15 = "Load_Mailid";
            ds = IA.IRN_Automation_Insert_Update_BG(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlmailid.DataSource = ds.Tables[0];
                ddlmailid.DataTextField = "MAILID";
                ddlmailid.DataValueField = "MAILID";
                ddlmailid.DataBind();
            }
            ddlmailid.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
            ddlmailid.SelectedIndex = 0;
           

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }


    }
    public void Load_Mail_Details()
    {
        string Maildata = "";
        string icegateid = ddlIcegateId.SelectedItem.Text;
        string icegatepass = ddlIcegateId.SelectedValue;
        string mailidtype = ddlmailtype.SelectedValue;
        try
        {
            if (ddlmailid.SelectedValue.ToString() != "")
            {
                ObjUBO.A12 = ddlmailtype.SelectedValue.ToString();
                ObjUBO.A13 = ddlmailid.SelectedValue.ToString();
                ObjUBO.A15 = "Load_Mailid_Data";
                ds = IA.IRN_Automation_Insert_Update_BG(ObjUBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Maildata = ds.Tables[0].Rows[0]["maildata"].ToString();
                    string[] maildatasplt = Maildata.Split('~');

                    txtmailpass.Text = maildatasplt[0].ToString();
                    txtmailhost.Text = maildatasplt[1].ToString();
                    string ssl = maildatasplt[2];
                    if (ssl == "True")
                    {
                        txtmailssl.Text = maildatasplt[2].Replace("True", "true");
                    }
                    else
                    {
                        txtmailssl.Text = maildatasplt[2].Replace("False", "false");
                    }
                    txtmailport.Text = maildatasplt[3].ToString();
                    string mobno = maildatasplt[4].ToString();
                    txtmobilno.Text = mobno;
                    txttenetid.Text = maildatasplt[5].ToString();
                    txtclientid.Text = maildatasplt[6].ToString();
                    txtscreenid.Text = maildatasplt[7].ToString();

                }
            }
           


        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }


    }
   
    private DataTable GetDataTableFromGrid()
    {
        DataTable dt = new DataTable();

        dt = new DataTable();
        dt.Columns.Add("Jobno", typeof(string));
        dt.Columns.Add("JobType", typeof(string));
        dt.Columns.Add("INV_SL", typeof(string));
        dt.Columns.Add("ITEM_SL", typeof(string));
        dt.Columns.Add("DOC_FILE_NAME", typeof(string));
        dt.Columns.Add("DOC_TYPE", typeof(string));
        dt.Columns.Add("DOC_LEVEL", typeof(string));
        dt.Columns.Add("DRN", typeof(string));
        dt.Columns.Add("IRN", typeof(string));
        dt.Columns.Add("DOC_ISSUING_PARTY_NAME", typeof(string));
        dt.Columns.Add("EXPORTER_ADDRESS1", typeof(string));
        dt.Columns.Add("EXPORTER_ADDRESS2", typeof(string));
        dt.Columns.Add("EXPORTER_ADDRESS3", typeof(string));
        dt.Columns.Add("EXPORTER_ADDRESS5", typeof(string));
        dt.Columns.Add("PLACE_OF_ISSUE", typeof(string));
        dt.Columns.Add("DOC_ISSUE_DATE", typeof(string));
        dt.Columns.Add("BENEFICIARY_PARTY_NAME", typeof(string));
        dt.Columns.Add("CONSIGNEE_ADD1", typeof(string));
        dt.Columns.Add("CONSIGNEE_ADD2", typeof(string));
        dt.Columns.Add("CONSIGNEE_ADD3", typeof(string));
        dt.Columns.Add("CONSIGNEE_ADD5", typeof(string));
        dt.Columns.Add("IRN_STATUS", typeof(string));
        dt.Columns.Add("User", typeof(string));
        dt.Columns.Add("Guidid", typeof(string));
        dt.Columns.Add("SL_NO", typeof(string));

        foreach (GridViewRow row in gv_Details.Rows)
        {
            DataRow dr = dt.NewRow();
            TextBox txtstatus = row.FindControl("txtstatus") as TextBox;
            TextBox txtJobno = row.FindControl("txtJobno") as TextBox;
            TextBox txtJobType = row.FindControl("txtJobType") as TextBox;
            TextBox txt_InvSlno = row.FindControl("txt_InvSlno") as TextBox;
            TextBox txtItemSlNo = row.FindControl("txtItemSlNo") as TextBox;
            TextBox txtFileName = row.FindControl("txtFileName") as TextBox;
            TextBox txtDoc_Code = row.FindControl("txtDoc_Code") as TextBox;
            TextBox txtlevel = row.FindControl("txtlevel") as TextBox;
            TextBox txt_Doc_No = row.FindControl("txt_Doc_No") as TextBox;
            TextBox txtIRNno = row.FindControl("txtIRNno") as TextBox;
            TextBox txtIss_PartyName = row.FindControl("txtIss_PartyName") as TextBox;
            TextBox txtIss_PartyNameadd1 = row.FindControl("txtIss_PartyNameadd1") as TextBox;
            TextBox txtIss_PartyNameadd2 = row.FindControl("txtIss_PartyNameadd2") as TextBox;
            TextBox txtIss_PartyNameadd3 = row.FindControl("txtIss_PartyNameadd3") as TextBox;
            TextBox txtIss_PartyNameadd4 = row.FindControl("txtIss_PartyNameadd4") as TextBox;
            TextBox txtPlace_Of_Issue = row.FindControl("txtPlace_Of_Issue") as TextBox;
            TextBox txtIssue_Date = row.FindControl("txtIssue_Date") as TextBox;
            TextBox txtBenPartyName = row.FindControl("txtBenPartyName") as TextBox;
            TextBox txtBenPartyNameadd1 = row.FindControl("txtBenPartyNameadd1") as TextBox;
            TextBox txtBenPartyNameadd2 = row.FindControl("txtBenPartyNameadd2") as TextBox;
            TextBox txtBenPartyNameadd3 = row.FindControl("txtBenPartyNameadd3") as TextBox;
            TextBox txtBenPartyNameadd4 = row.FindControl("txtBenPartyNameadd4") as TextBox;
            TextBox txtUser = row.FindControl("txtUser") as TextBox;
            TextBox txtGuidid = row.FindControl("txtGuidid") as TextBox;
            TextBox txtslid = row.FindControl("txtslid") as TextBox;


            dr["IRN_STATUS"] = txtstatus.Text;
            dr["Jobno"] = txtJobno.Text;
            dr["JobType"] = txtJobType.Text;
            dr["INV_SL"] = txt_InvSlno.Text;
            dr["ITEM_SL"] = txtItemSlNo.Text;
            dr["DOC_FILE_NAME"] = txtFileName.Text;
            dr["DOC_TYPE"] = txtDoc_Code.Text;
            dr["DOC_LEVEL"] = txtlevel.Text;
            dr["DRN"] = txt_Doc_No.Text;
            dr["IRN"] = txtIRNno.Text;
            dr["DOC_ISSUING_PARTY_NAME"] = txtIss_PartyName.Text;
            dr["EXPORTER_ADDRESS1"] = txtIss_PartyNameadd1.Text;
            dr["EXPORTER_ADDRESS2"] = txtIss_PartyNameadd2.Text;
            dr["EXPORTER_ADDRESS3"] = txtIss_PartyNameadd3.Text;
            dr["EXPORTER_ADDRESS5"] = txtIss_PartyNameadd4.Text;
            dr["PLACE_OF_ISSUE"] = txtPlace_Of_Issue.Text;
            dr["DOC_ISSUE_DATE"] = txtIssue_Date.Text;
            dr["BENEFICIARY_PARTY_NAME"] = txtBenPartyName.Text;
            dr["CONSIGNEE_ADD1"] = txtBenPartyNameadd1.Text;
            dr["CONSIGNEE_ADD2"] = txtBenPartyNameadd2.Text;
            dr["CONSIGNEE_ADD3"] = txtBenPartyNameadd3.Text;
            dr["CONSIGNEE_ADD5"] = txtBenPartyNameadd4.Text;
            dr["User"] = txtUser.Text;
            dr["Guidid"] = txtGuidid.Text;
            dr["SL_NO"] = txtslid.Text;
            dt.Rows.Add(dr);
        }

        return dt;
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string icegate_id = hdn_icegate_user.Value;
        string icegate_pass = hdn_icegate_pass.Value;
        string Get_Mail_Type = hdn_mailtype.Value;
        string mail_id = hdn_mailid.Value;


        string mailport = txtmailport.Text;

        string mailssl = txtmailssl.Text;
        string mailpass = txtmailpass.Text;
        string mailhost = txtmailhost.Text;
        try
        {


            if (icegate_id != "")
            {
                hdn_saved.Value = "N";
                folderPath = HttpContext.Current.Server.MapPath("~/Submission/IRN_Doc_Uploads/"
                                + COMPANY_ID + "/" + currentbranch + "/" + txttransid.Text);

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
                DataTable dt = new DataTable();
                if (gv_Details.Rows.Count > 0)
                {
                    dt = GetDataTableFromGrid();
                }
                else
                {

                    dt = ViewState["CurrentTable"] as DataTable;
                }

                if (dt == null)
                {
                    dt = new DataTable();
                    dt.Columns.Add("Jobno", typeof(string));
                    dt.Columns.Add("JobType", typeof(string));
                    dt.Columns.Add("INV_SL", typeof(string));
                    dt.Columns.Add("ITEM_SL", typeof(string));
                    dt.Columns.Add("DOC_FILE_NAME", typeof(string));
                    dt.Columns.Add("DOC_TYPE", typeof(string));
                    dt.Columns.Add("DOC_LEVEL", typeof(string));
                    dt.Columns.Add("DRN", typeof(string));
                    dt.Columns.Add("IRN", typeof(string));
                    dt.Columns.Add("DOC_ISSUING_PARTY_NAME", typeof(string));
                    dt.Columns.Add("EXPORTER_ADDRESS1", typeof(string));
                    dt.Columns.Add("EXPORTER_ADDRESS2", typeof(string));
                    dt.Columns.Add("EXPORTER_ADDRESS3", typeof(string));
                    dt.Columns.Add("EXPORTER_ADDRESS5", typeof(string));
                    dt.Columns.Add("PLACE_OF_ISSUE", typeof(string));
                    dt.Columns.Add("DOC_ISSUE_DATE", typeof(string));
                    dt.Columns.Add("BENEFICIARY_PARTY_NAME", typeof(string));
                    dt.Columns.Add("CONSIGNEE_ADD1", typeof(string));
                    dt.Columns.Add("CONSIGNEE_ADD2", typeof(string));
                    dt.Columns.Add("CONSIGNEE_ADD3", typeof(string));
                    dt.Columns.Add("CONSIGNEE_ADD5", typeof(string));
                    dt.Columns.Add("IRN_STATUS", typeof(string));
                    dt.Columns.Add("User", typeof(string));
                    dt.Columns.Add("Guidid", typeof(string));
                    dt.Columns.Add("SL_NO", typeof(string));
                }

                bool allSigned = true;
                string unsignedFiles = "";
                string largeFiles = "";
                string invalidFiles = "";
                string duplicateFiles = "";
                int tot_count_doc = Request.Files.Count;

                for (int i = 0; i < Request.Files.Count; i++)
                {
                    if (i >= 40) break;

                    HttpPostedFile uploadedFile = Request.Files[i];
                    if (uploadedFile.ContentLength <= 0) continue;

                    string filenam = Path.GetFileName(uploadedFile.FileName);
                    string fileName = "";
                    string jobno = "", jobtype = "", invsl = "", itmsl = "", doccode = "";

                    if (filenam.Contains('~'))
                    {
                        string[] parts = filenam.Split('~');
                        fileName = parts[parts.Length - 1];

                        if (parts.Length == 6)
                        {
                            jobno = parts[0];
                            jobtype = parts[1];
                            invsl = parts[2];
                            itmsl = parts[3];
                            doccode = parts[4];
                        }
                        if (parts.Length == 5)
                        {
                            jobno = parts[0];
                            jobtype = parts[1];
                            invsl = parts[2];
                            itmsl = parts[3];

                        }
                        if (parts.Length == 4)
                        {
                            jobno = parts[0];
                            jobtype = parts[1];
                            invsl = parts[2];

                        }
                        if (parts.Length == 3)
                        {
                            jobno = parts[0];
                            jobtype = parts[1];

                        }

                    }
                    else
                    {
                        fileName = filenam;
                    }

                    string fileExtension = Path.GetExtension(fileName).ToLower();

                    if (fileExtension != ".pdf")
                    {
                        invalidFiles += fileName + ", ";
                        continue;
                    }

                    if (uploadedFile.ContentLength > 2097152)
                    {
                        largeFiles += fileName + ", ";
                        continue;
                    }

                    //// ===== MODIFIED DUPLICATE LOGIC START =====

                    bool samedocDuplicate = dt.AsEnumerable().Any(r =>
     string.Equals(Convert.ToString(r["DOC_FILE_NAME"]), fileName, StringComparison.OrdinalIgnoreCase));


                    //if (samedocDuplicate)
                    //{
                    //    duplicateFiles += fileName + ", ";
                    //    continue;
                    //}

                    string originalFileName = fileName;
                    string nameOnly = Path.GetFileNameWithoutExtension(originalFileName);
                    string extension = Path.GetExtension(originalFileName);
                    int counter = 1;

                    while (
                        dt.AsEnumerable().Any(r =>
                            string.Equals(r.Field<string>("DOC_FILE_NAME"), fileName, StringComparison.OrdinalIgnoreCase))
                        || File.Exists(Path.Combine(folderPath, fileName))
                    )
                    {
                        fileName = nameOnly + "_" + counter + extension;
                        counter++;
                    }

                    string filePath = Path.Combine(folderPath, fileName);

                    //// ===== MODIFIED DUPLICATE LOGIC END =====

                    uploadedFile.SaveAs(filePath);

                    if (HasDigitalSignature(filePath))
                    {
                        bool exists = dt.AsEnumerable().Any(r => r.Field<string>("DOC_FILE_NAME") == fileName);
                        if (!exists)
                        {
                            DataRow row = dt.NewRow();
                            row["JOBNO"] = string.IsNullOrEmpty(jobno) ? (object)DBNull.Value : jobno;
                            row["JobType"] = string.IsNullOrEmpty(jobtype) ? (object)DBNull.Value : jobtype;
                            row["INV_SL"] = string.IsNullOrEmpty(invsl) ? (object)DBNull.Value : invsl;
                            row["ITEM_SL"] = string.IsNullOrEmpty(itmsl) ? (object)DBNull.Value : itmsl;
                            row["DOC_FILE_NAME"] = fileName;
                            row["DOC_TYPE"] = string.IsNullOrEmpty(doccode) ? (object)DBNull.Value : doccode;
                            if (doccode != "" && doccode != null)
                            {
                                row["DOC_LEVEL"] = Load_Doc_type_level(doccode);
                            }
                            else
                            {
                                row["DOC_LEVEL"] = DBNull.Value;
                            }
                            row["DRN"] = DBNull.Value;
                            row["IRN"] = DBNull.Value;
                            if (jobno != "" && jobtype != "" && invsl != "" && itmsl != "")
                            {
                                string jobdetails = Get_imp_exp_all(jobno, jobtype, invsl, itmsl);
                                string[] jobdetailssplit = jobdetails.Split('~');
                                if (jobdetails != "")
                                {
                                    row["DOC_ISSUING_PARTY_NAME"] = string.IsNullOrEmpty(jobdetailssplit[0]) ? (object)DBNull.Value : jobdetailssplit[0];
                                    row["EXPORTER_ADDRESS1"] = string.IsNullOrEmpty(jobdetailssplit[1]) ? (object)DBNull.Value : jobdetailssplit[1];
                                    row["EXPORTER_ADDRESS2"] = string.IsNullOrEmpty(jobdetailssplit[2]) ? (object)DBNull.Value : jobdetailssplit[2];
                                    row["EXPORTER_ADDRESS3"] = string.IsNullOrEmpty(jobdetailssplit[3]) ? (object)DBNull.Value : jobdetailssplit[3];
                                    row["EXPORTER_ADDRESS5"] = string.IsNullOrEmpty(jobdetailssplit[4]) ? (object)DBNull.Value : jobdetailssplit[4];

                                    row["BENEFICIARY_PARTY_NAME"] = string.IsNullOrEmpty(jobdetailssplit[5]) ? (object)DBNull.Value : jobdetailssplit[5];
                                    row["CONSIGNEE_ADD1"] = string.IsNullOrEmpty(jobdetailssplit[6]) ? (object)DBNull.Value : jobdetailssplit[6];
                                    row["CONSIGNEE_ADD2"] = string.IsNullOrEmpty(jobdetailssplit[7]) ? (object)DBNull.Value : jobdetailssplit[7];
                                    row["CONSIGNEE_ADD3"] = string.IsNullOrEmpty(jobdetailssplit[8]) ? (object)DBNull.Value : jobdetailssplit[8];
                                    row["CONSIGNEE_ADD5"] = string.IsNullOrEmpty(jobdetailssplit[9]) ? (object)DBNull.Value : jobdetailssplit[9];
                                    row["PLACE_OF_ISSUE"] = string.IsNullOrEmpty(jobdetailssplit[10]) ? (object)DBNull.Value : jobdetailssplit[10];
                                    row["DOC_ISSUE_DATE"] = string.IsNullOrEmpty(jobdetailssplit[11]) ? (object)DBNull.Value : jobdetailssplit[11];
                                }
                                else
                                {
                                    row["DOC_ISSUING_PARTY_NAME"] = DBNull.Value;
                                    row["EXPORTER_ADDRESS1"] = DBNull.Value;
                                    row["EXPORTER_ADDRESS2"] = DBNull.Value;
                                    row["EXPORTER_ADDRESS3"] = DBNull.Value;
                                    row["EXPORTER_ADDRESS5"] = DBNull.Value;
                                    row["PLACE_OF_ISSUE"] = DBNull.Value;
                                    row["DOC_ISSUE_DATE"] = DBNull.Value;
                                    row["BENEFICIARY_PARTY_NAME"] = DBNull.Value;
                                    row["CONSIGNEE_ADD1"] = DBNull.Value;
                                    row["CONSIGNEE_ADD2"] = DBNull.Value;
                                    row["CONSIGNEE_ADD3"] = DBNull.Value;
                                    row["CONSIGNEE_ADD5"] = DBNull.Value;

                                }
                            }

                            else
                            {
                                row["DOC_ISSUING_PARTY_NAME"] = DBNull.Value;
                                row["EXPORTER_ADDRESS1"] = DBNull.Value;
                                row["EXPORTER_ADDRESS2"] = DBNull.Value;
                                row["EXPORTER_ADDRESS3"] = DBNull.Value;
                                row["EXPORTER_ADDRESS5"] = DBNull.Value;
                                row["PLACE_OF_ISSUE"] = DBNull.Value;
                                row["DOC_ISSUE_DATE"] = DBNull.Value;
                                row["BENEFICIARY_PARTY_NAME"] = DBNull.Value;
                                row["CONSIGNEE_ADD1"] = DBNull.Value;
                                row["CONSIGNEE_ADD2"] = DBNull.Value;
                                row["CONSIGNEE_ADD3"] = DBNull.Value;
                                row["CONSIGNEE_ADD5"] = DBNull.Value;
                            }
                            row["IRN_STATUS"] = DBNull.Value;
                            row["User"] = currentuser;
                            row["Guidid"] = txttransid.Text;
                            row["SL_NO"] = DBNull.Value;

                            dt.Rows.Add(row);
                        }

                    }
                    else
                    {
                        allSigned = false;
                        unsignedFiles += fileName + ", ";
                        if (File.Exists(filePath))
                            File.Delete(filePath);
                    }
                }




                gv_Details.DataSource = dt;
                gv_Details.DataBind();
                ViewState["CurrentTable"] = dt;
                if (dt.Rows.Count > 0)
                {
                    btnGenIRN.Visible = true;
                    hdn_Grid.Value = "Y";
                }

                if (!allSigned || !string.IsNullOrEmpty(largeFiles) ||
                    !string.IsNullOrEmpty(invalidFiles) || !string.IsNullOrEmpty(duplicateFiles))
                {
                    string alertMessage = "";

                    if (!allSigned)
                        alertMessage += "(*) " + unsignedFiles.TrimEnd(',', ' ') + " does not contain digital signature.\n";

                    if (!string.IsNullOrEmpty(largeFiles))
                        alertMessage += "(*) " + largeFiles.TrimEnd(',', ' ') + " are larger than 2 MB.\n";

                    if (!string.IsNullOrEmpty(invalidFiles))
                        alertMessage += "(*) " + invalidFiles.TrimEnd(',', ' ') + " are not PDF files.\n";

                    if (!string.IsNullOrEmpty(duplicateFiles))
                        alertMessage += "(*) " + duplicateFiles.TrimEnd(',', ' ') + " already exist and were skipped.\n";

                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                        "alert", "alert('" + alertMessage.Replace("\n", "\\n") + "');", true);
                }
            }
            else
            {
                Alert_msg("Select ICEGATE USER ID");
            }
        }
        catch
        {
            Alert_msg("File not uploaded");
        }
        finally
        {
          
            hdn_icegate_user.Value = icegate_id;
            hdn_icegate_pass.Value = icegate_pass;

            // Find matching index first, then set SelectedIndex ONCE — avoids multiple selection error
            int foundIndex = 0; // default to blank (index 0)
            for (int idx = 0; idx < ddlIcegateId.Items.Count; idx++)
            {
                if (ddlIcegateId.Items[idx].Text.Trim().Equals(icegate_id, StringComparison.OrdinalIgnoreCase))
                {
                    foundIndex = idx;
                    break;
                }
            }
            ddlIcegateId.SelectedIndex = foundIndex; // only ONE assignment, no conflict



            Load_Mail_Type();
            hdn_mailtype.Value =ddlmailtype.SelectedValue= Get_Mail_Type;
            Load_Mail_id();
            hdn_mailid.Value =ddlmailid.SelectedValue=mail_id;
            Load_Mail_Details();
        }


    }
    protected void btnbulksave_Click(object sender, EventArgs e)
    {
        try
        {
            int i = insert_update("Save_To_Jobs", IRN_details());




            if (ds.Tables[1].Rows.Count > 0)
            {
                MP_JOB.Show();
                gv_Inv_Item.DataSource = ds.Tables[1];
                gv_Inv_Item.DataBind();
                Alert_msg("Details Not Saved");
                File.AppendAllText(logFile, "Details Not Saved");
            }
            else
            {
                Alert_msg("Details Saved to Jobs");
            }


        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
            //File.AppendAllText(logFile, "Save Error:" + ex.Message);
        }
    }
    protected void btnok_Click(object sender, EventArgs e)
    {
        MP_JOB.Hide();
    }
    protected void btnGenIRN_Click(object sender, EventArgs e)
    {
        string logpath = HttpContext.Current.Server.MapPath("~/Submission/IRN_Log/" + COMPANY_ID + "/" + currentbranch + "/" + txttransid.Text + "/");
        if (!Directory.Exists(logpath))
        {
            Directory.CreateDirectory(logpath);
        }

        logFile = Path.Combine(logpath, "Errorlog_IRN_" + txttransid.Text + ".log");

        string errorMsg = "";

        if (string.IsNullOrWhiteSpace(hdn_icegate_user.Value))
            errorMsg += "Icegate ID Not found\n";
        if (string.IsNullOrWhiteSpace(hdn_mailtype.Value))
            errorMsg += "Mail Type Not found\n";
        if (string.IsNullOrWhiteSpace(hdn_mailid.Value))
            errorMsg += "Mail ID Not found\n";

        if (string.IsNullOrWhiteSpace(txtmailhost.Text))
            errorMsg += "Mail Host Not found\n";

        if (string.IsNullOrWhiteSpace(txtmailpass.Text))
            errorMsg += "Mail Password Not found\n";

        if (string.IsNullOrWhiteSpace(txtmailport.Text))
            errorMsg += "Mail Port Not found\n";

        if (string.IsNullOrWhiteSpace(txtmailssl.Text))
            errorMsg += "Mail SSL Not found\n";

        if (gv_Details.Rows.Count <= 0)
            errorMsg += "Grid Data Not found\n";


        if (!string.IsNullOrEmpty(errorMsg))
        {
            Alert_msg(errorMsg);
            File.AppendAllText(logFile, "Validation Errors:\n" + errorMsg);
            return;
        }


        try
        {
            string connectionString = Server_ip;
            var builder = new System.Data.SqlClient.SqlConnectionStringBuilder(connectionString);
            string serverName = builder.DataSource.Replace(@"\", @"\\");

            hdn_saved.Value = "Y";
            var filesList = new List<object>();

            string folderPath = HttpContext.Current.Server.MapPath("~/Submission/IRN_Doc_Uploads/" + COMPANY_ID + "/" + currentbranch + "/" + txttransid.Text);


            if (!Directory.Exists(folderPath))
            {
                file_delete();
                Edit_GeneralDetails();
                Alert_msg("File not found. Please Reupload the file.");

                File.AppendAllText(logFile, "Folder not found: " + folderPath);
            }
            else
            {

                string WorkingPeriod = Working_Period;
                string Userid = currentuser;

                foreach (GridViewRow row in gv_Details.Rows)
                {

                    TextBox txtJobno = (TextBox)row.FindControl("txtJobno");
                    TextBox txtJobType = (TextBox)row.FindControl("txtJobType");
                    TextBox txt_InvSlno = (TextBox)row.FindControl("txt_InvSlno");
                    TextBox txtItemSlNo = (TextBox)row.FindControl("txtItemSlNo");
                    TextBox txtFileName = (TextBox)row.FindControl("txtFileName");
                    TextBox txtDoc_Code = (TextBox)row.FindControl("txtDoc_Code");
                    TextBox txtlevel = (TextBox)row.FindControl("txtlevel");
                    TextBox txt_Doc_No = (TextBox)row.FindControl("txt_Doc_No");
                    TextBox txtIRNno = (TextBox)row.FindControl("txtIRNno");
                    TextBox txtIss_PartyName = (TextBox)row.FindControl("txtIss_PartyName");
                    TextBox txtIss_PartyNameadd1 = (TextBox)row.FindControl("txtIss_PartyNameadd1");
                    TextBox txtIss_PartyNameadd2 = (TextBox)row.FindControl("txtIss_PartyNameadd2");
                    TextBox txtIss_PartyNameadd3 = (TextBox)row.FindControl("txtIss_PartyNameadd3");
                    TextBox txtIss_PartyNameadd4 = (TextBox)row.FindControl("txtIss_PartyNameadd4");
                    TextBox txtPlace_Of_Issue = (TextBox)row.FindControl("txtPlace_Of_Issue");
                    TextBox txtIssue_Date = (TextBox)row.FindControl("txtIssue_Date");
                    TextBox txtBenPartyName = (TextBox)row.FindControl("txtBenPartyName");
                    TextBox txtBenPartyNameadd1 = (TextBox)row.FindControl("txtBenPartyNameadd1");
                    TextBox txtBenPartyNameadd2 = (TextBox)row.FindControl("txtBenPartyNameadd2");
                    TextBox txtBenPartyNameadd3 = (TextBox)row.FindControl("txtBenPartyNameadd3");
                    TextBox txtBenPartyNameadd4 = (TextBox)row.FindControl("txtBenPartyNameadd4");
                    TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
                    TextBox txtUser = (TextBox)row.FindControl("txtUser");
                    TextBox txtGuidid = (TextBox)row.FindControl("txtGuidid");
                    TextBox txtslid = (TextBox)row.FindControl("txtslid");

                    if (!string.IsNullOrEmpty(txtFileName.Text) && !string.IsNullOrEmpty(txtDoc_Code.Text) && txtIRNno.Text == "")
                    {
                        string fileName = txtFileName.Text.Trim();
                        string fullPath = Path.Combine(folderPath, fileName);

                        string base64File = string.Empty;

                        if (File.Exists(fullPath))
                        {
                            byte[] fileBytes = File.ReadAllBytes(fullPath);
                            base64File = Convert.ToBase64String(fileBytes);
                        }

                        filesList.Add(new
                        {
                            Jobno = txtJobno.Text,
                            Jobtype = txtJobType.Text,
                            Inv_sl = txt_InvSlno.Text,
                            itm_sl = txtItemSlNo.Text,
                            FileName = txtFileName.Text,
                            DocumentType = txtDoc_Code.Text,
                            Level = txtlevel.Text,
                            DRN = txt_Doc_No.Text,
                            IRN = txtIRNno.Text,
                            Iss_party = txtIss_PartyName.Text,
                            EXPORTER_ADDRESS1 = txtIss_PartyNameadd1.Text,
                            EXPORTER_ADDRESS2 = txtIss_PartyNameadd2.Text,
                            EXPORTER_ADDRESS3 = txtIss_PartyNameadd3.Text,
                            EXPORTER_ADDRESS5 = txtIss_PartyNameadd4.Text,
                            POI = txtPlace_Of_Issue.Text,
                            DOI = txtIssue_Date.Text,
                            Ben_party = txtBenPartyName.Text,
                            CONSIGNEE_ADD1 = txtBenPartyNameadd1.Text,
                            CONSIGNEE_ADD2 = txtBenPartyNameadd2.Text,
                            CONSIGNEE_ADD3 = txtBenPartyNameadd3.Text,
                            CONSIGNEE_ADD5 = txtBenPartyNameadd4.Text,
                            IRN_STATUS = txtstatus.Text,
                            user = txtUser.Text,
                            GuidId = txtGuidid.Text,
                            FileContent = base64File
                        });
                    }
                }
                string mail_port = txtmailport.Text;
                var payload = new
                {
                    CorrelationId = Guid.NewGuid(),
                    FolderPath = "",
                    Files = filesList,
                    IcegateUser = hdn_icegate_user.Value,
                    IcegatePassword = hdn_icegate_pass.Value,
                    CompanyId = COMPANY_license,
                    BranchCode = currentbranch,
                    Client = "",
                    Working_Period = WorkingPeriod,
                    TransId = txttransid.Text,
                    serverIP = serverName,
                    JobType = "",
                    MailType = hdn_mailtype.Value,
                    Mailid = hdn_mailid.Value,
                    Mailhost = txtmailhost.Text,
                    Mailssl = txtmailssl.Text,
                    Mailport = txtmailport.Text,
                    password = txtmailpass.Text,
                    Mobno = txtmobilno.Text,
                    Icegateerror = "",
                    JobNo = "",
                    MailTenentid = txttenetid.Text,
                    MailClientid = txtclientid.Text,
                    MailScreenid = txtscreenid.Text,

                };

                string jsonData = JsonConvert.SerializeObject(payload);
                File.AppendAllText(logFile, "Json Data:" + jsonData);
                int maxRetries = 3;
                int delaySeconds = 3;
                bool success = false;
                string result = string.Empty;
                HttpStatusCode statusCode = HttpStatusCode.BadRequest;

                for (int attempt = 1; attempt <= maxRetries && !success; attempt++)
                {
                    try
                    {

                        string url = "http://irnjobservices.royaltechsystems.co.in/api/v2/Jobs/Createjob";
                        //string url = "http://localhost:5006/api/v2/jobs/CreateJob";
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                        request.Method = "POST";
                        request.ContentType = "application/json";
                        File.AppendAllText(logFile, "Connecting API:" + url);
                        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                        {
                            streamWriter.Write(jsonData);
                            streamWriter.Flush();
                        }

                        using (var response = (HttpWebResponse)request.GetResponse())
                        {
                            statusCode = response.StatusCode;
                            using (var reader = new StreamReader(response.GetResponseStream()))
                            {
                                result = reader.ReadToEnd();
                                File.AppendAllText(logFile, "Connecting status:" + result);
                            }
                        }

                        success = true; // Request succeeded
                        File.AppendAllText(logFile, "Connecting success:" + success);

                    }
                    catch (WebException webEx)
                    {
                        if (attempt == maxRetries)
                        {
                            Alert_msg("Failed to connect to IRN service after multiple attempts. Error: " + webEx.Message);
                            File.AppendAllText(logFile, "Connecting status:" + "Failed to connect to IRN service after multiple attempts. Error: " + webEx.Message);
                            return;
                        }
                        else
                        {
                            System.Threading.Thread.Sleep(delaySeconds * 1000);
                        }
                    }
                    catch (Exception ex)
                    {
                        Alert_msg("Unexpected error: " + ex.Message);
                        File.AppendAllText(logFile, "Unexpected error: " + ex.Message);
                        return;
                    }
                }

                // Process API response if success
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(result);

                if (apiResponse.Message.Contains("Request blocked"))
                {
                    Message = "IRN service is temporarily unavailable. Please retry later.";
                    File.AppendAllText(logFile, "IRN service is temporarily unavailable. Please retry later.");
                }
                else
                {
                    Message = "IRN Generation in progress, Check after few minutes..";
                    File.AppendAllText(logFile, "IRN Generation in progress, Check after few minutes..");
                }
                Session["IRN_STATUS"] = "In Progress";
                //btnGenIRN.Visible = false;
                btnSave_Click(sender, e);
            }

        }
        catch (Exception ex)
        {
            Alert_msg("Unexpected error: " + ex.Message);
            File.AppendAllText(logFile, "Folder not found: " + folderPath);
        }





    }



    public void file_delete()
    {
        DataSet dss = new DataSet();
        if (Request.QueryString["JOBID"] != "" && Request.QueryString["JOBID"] != null)
        {


            ObjUBO.A2 = Request.QueryString["JOBID"].ToString();
            ObjUBO.A10 = Jobtype;
            ObjUBO.A15 = "delete_file";
            dss = IA.IRN_Automation_Insert_Update_BG(ObjUBO);

            gv_Details.DataSource = dss.Tables[0];
            gv_Details.DataBind();
            if (gv_Details.Rows.Count > 0)
            {
                for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
                {
                    TextBox txtJobno = (TextBox)gv_Details.Rows[i].FindControl("txtJobno");
                    TextBox txtJobType = (TextBox)gv_Details.Rows[i].FindControl("txtJobType");
                    TextBox txt_InvSlno = (TextBox)gv_Details.Rows[i].FindControl("txt_InvSlno");
                    TextBox txtItemSlNo = (TextBox)gv_Details.Rows[i].FindControl("txtItemSlNo");
                    TextBox txtFileName = (TextBox)gv_Details.Rows[i].FindControl("txtFileName");
                    TextBox txtDoc_Code = (TextBox)gv_Details.Rows[i].FindControl("txtDoc_Code");
                    TextBox txtlevel = (TextBox)gv_Details.Rows[i].FindControl("txtlevel");
                    TextBox txt_Doc_No = (TextBox)gv_Details.Rows[i].FindControl("txt_Doc_No");

                    TextBox txtIRNno = (TextBox)gv_Details.Rows[i].FindControl("txtIRNno");
                    TextBox txtIss_PartyName = (TextBox)gv_Details.Rows[i].FindControl("txtIss_PartyName");
                    TextBox txtIss_PartyNameadd1 = (TextBox)gv_Details.Rows[i].FindControl("txtIss_PartyNameadd1");
                    TextBox txtIss_PartyNameadd2 = (TextBox)gv_Details.Rows[i].FindControl("txtIss_PartyNameadd2");
                    TextBox txtIss_PartyNameadd3 = (TextBox)gv_Details.Rows[i].FindControl("txtIss_PartyNameadd3");
                    TextBox txtIss_PartyNameadd4 = (TextBox)gv_Details.Rows[i].FindControl("txtIss_PartyNameadd4");
                    TextBox txtPlace_Of_Issue = (TextBox)gv_Details.Rows[i].FindControl("txtPlace_Of_Issue");
                    TextBox txtIssue_Date = (TextBox)gv_Details.Rows[i].FindControl("txtIssue_Date");
                    TextBox txtBenPartyName = (TextBox)gv_Details.Rows[i].FindControl("txtBenPartyName");
                    TextBox txtBenPartyNameadd1 = (TextBox)gv_Details.Rows[i].FindControl("txtBenPartyNameadd1");
                    TextBox txtBenPartyNameadd2 = (TextBox)gv_Details.Rows[i].FindControl("txtBenPartyNameadd2");
                    TextBox txtBenPartyNameadd3 = (TextBox)gv_Details.Rows[i].FindControl("txtBenPartyNameadd3");
                    TextBox txtBenPartyNameadd4 = (TextBox)gv_Details.Rows[i].FindControl("txtBenPartyNameadd4");
                    TextBox txtstatus = (TextBox)gv_Details.Rows[i].FindControl("txtstatus");
                    TextBox txtUser = (TextBox)gv_Details.Rows[i].FindControl("txtUser");
                    TextBox txtslid = (TextBox)gv_Details.Rows[i].FindControl("txtslid");

                    txtJobno.Text = dss.Tables[0].Rows[i]["JOBNO"].ToString();
                    txtJobType.Text = dss.Tables[0].Rows[i]["txtJobType"].ToString();
                    txt_InvSlno.Text = dss.Tables[0].Rows[i]["INV_SL"].ToString();
                    txtItemSlNo.Text = dss.Tables[0].Rows[i]["ITEM_SL"].ToString();
                    txtFileName.Text = dss.Tables[0].Rows[i]["DOC_FILE_NAME"].ToString();
                    txtDoc_Code.Text = dss.Tables[0].Rows[i]["DOC_TYPE"].ToString();
                    txtlevel.Text = dss.Tables[0].Rows[i]["DOC_LEVEL"].ToString();
                    txt_Doc_No.Text = dss.Tables[0].Rows[i]["DRN"].ToString();
                    txtIRNno.Text = dss.Tables[0].Rows[i]["IRN"].ToString();
                    txtIss_PartyName.Text = dss.Tables[0].Rows[i]["DOC_ISSUING_PARTY_NAME"].ToString();
                    txtIss_PartyNameadd1.Text = dss.Tables[0].Rows[i]["EXPORTER_ADDRESS1"].ToString();
                    txtIss_PartyNameadd2.Text = dss.Tables[0].Rows[i]["EXPORTER_ADDRESS2"].ToString();
                    txtIss_PartyNameadd3.Text = dss.Tables[0].Rows[i]["EXPORTER_ADDRESS3"].ToString();
                    txtIss_PartyNameadd4.Text = dss.Tables[0].Rows[i]["EXPORTER_ADDRESS5"].ToString();
                    txtPlace_Of_Issue.Text = dss.Tables[0].Rows[i]["PLACE_OF_ISSUE"].ToString();
                    txtIssue_Date.Text = dss.Tables[0].Rows[i]["DOC_ISSUE_DATE"].ToString();
                    txtBenPartyName.Text = dss.Tables[0].Rows[i]["BENEFICIARY_PARTY_NAME"].ToString();
                    txtBenPartyNameadd1.Text = dss.Tables[0].Rows[i]["CONSIGNEE_ADD1"].ToString();
                    txtBenPartyNameadd2.Text = dss.Tables[0].Rows[i]["CONSIGNEE_ADD2"].ToString();
                    txtBenPartyNameadd3.Text = dss.Tables[0].Rows[i]["CONSIGNEE_ADD3"].ToString();
                    txtBenPartyNameadd4.Text = dss.Tables[0].Rows[i]["CONSIGNEE_ADD5"].ToString();
                    txtstatus.Text = dss.Tables[0].Rows[i]["IRN_STATUS"].ToString();
                    txtUser.Text = dss.Tables[0].Rows[i]["User"].ToString();
                    txtslid.Text = dss.Tables[0].Rows[i]["SL_NO"].ToString();


                }
                Session["childIRNgrid"] = dss.Tables[1];
                Session["IRN_STATUS"] = "";


                hdn_saved.Value = "Y";
                hdn_Grid.Value = "Y";
            }
            DataTable firstTable = dss.Tables[0];
            ViewState["CurrentTable"] = firstTable;
            ViewState["UPDATED_ID"] = null;
            btnNew.Visible = false;
            btnDelete.Visible = true;
            btnSave.Visible = true;
            btnGenIRN.Visible = true;


        }



    }
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
    }

    protected void Generatebuttonhide()
    {
        bool allIRNsFilled = true;

        foreach (GridViewRow row in gv_Details.Rows)
        {
            TextBox txtIRNno = row.FindControl("txtIRNno") as TextBox;
            if (txtIRNno != null && string.IsNullOrWhiteSpace(txtIRNno.Text))
            {
                allIRNsFilled = false;
                break;
            }
        }

        btnGenIRN.Visible = !allIRNsFilled;
    }
    private string IRN_details()
    {
        DataTable dtt = new DataTable();
        DataRow dr;
        dtt.Columns.Add(new System.Data.DataColumn("Jobno", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("JobType", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("INV_SL", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ITEM_SL", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("DOC_FILE_NAME", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("DOC_TYPE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("DOC_LEVEL", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("DRN", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IRN", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("DOC_ISSUING_PARTY_NAME", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("EXPORTER_ADDRESS1", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("EXPORTER_ADDRESS2", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("EXPORTER_ADDRESS3", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("EXPORTER_ADDRESS5", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("PLACE_OF_ISSUE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("DOC_ISSUE_DATE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("BENEFICIARY_PARTY_NAME", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CONSIGNEE_ADD1", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CONSIGNEE_ADD2", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CONSIGNEE_ADD3", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CONSIGNEE_ADD5", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IRN_STATUS", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("User", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("SL_NO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("Guidid", typeof(String)));

        int R = 1;
        foreach (GridViewRow row in gv_Details.Rows)
        {
            TextBox txtJobno = (TextBox)row.FindControl("txtJobno");
            TextBox txtJobType = (TextBox)row.FindControl("txtJobType");
            TextBox txt_InvSlno = (TextBox)row.FindControl("txt_InvSlno");
            TextBox txtItemSlNo = (TextBox)row.FindControl("txtItemSlNo");
            TextBox txtFileName = (TextBox)row.FindControl("txtFileName");
            TextBox txtDoc_Code = (TextBox)row.FindControl("txtDoc_Code");
            TextBox txtlevel = (TextBox)row.FindControl("txtlevel");
            TextBox txt_Doc_No = (TextBox)row.FindControl("txt_Doc_No");
            TextBox txtIRNno = (TextBox)row.FindControl("txtIRNno");
            TextBox txtIss_PartyName = (TextBox)row.FindControl("txtIss_PartyName");
            TextBox txtIss_PartyNameadd1 = (TextBox)row.FindControl("txtIss_PartyNameadd1");
            TextBox txtIss_PartyNameadd2 = (TextBox)row.FindControl("txtIss_PartyNameadd2");
            TextBox txtIss_PartyNameadd3 = (TextBox)row.FindControl("txtIss_PartyNameadd3");
            TextBox txtIss_PartyNameadd4 = (TextBox)row.FindControl("txtIss_PartyNameadd4");
            TextBox txtPlace_Of_Issue = (TextBox)row.FindControl("txtPlace_Of_Issue");
            TextBox txtIssue_Date = (TextBox)row.FindControl("txtIssue_Date");
            TextBox txtBenPartyName = (TextBox)row.FindControl("txtBenPartyName");
            TextBox txtBenPartyNameadd1 = (TextBox)row.FindControl("txtBenPartyNameadd1");
            TextBox txtBenPartyNameadd2 = (TextBox)row.FindControl("txtBenPartyNameadd2");
            TextBox txtBenPartyNameadd3 = (TextBox)row.FindControl("txtBenPartyNameadd3");
            TextBox txtBenPartyNameadd4 = (TextBox)row.FindControl("txtBenPartyNameadd4");
            TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
            TextBox txtUser = (TextBox)row.FindControl("txtUser");
            TextBox txtslid = (TextBox)row.FindControl("txtslid");
            TextBox txtGuidid = (TextBox)row.FindControl("txtGuidid");
            dr = dtt.NewRow();
            dr[0] = txtJobno.Text;
            dr[1] = txtJobType.Text;
            dr[2] = txt_InvSlno.Text;
            dr[3] = txtItemSlNo.Text;
            dr[4] = txtFileName.Text;
            dr[5] = txtDoc_Code.Text;
            dr[6] = txtlevel.Text;
            dr[7] = txt_Doc_No.Text;
            dr[8] = txtIRNno.Text;
            dr[9] = txtIss_PartyName.Text;
            dr[10] = txtIss_PartyNameadd1.Text;
            dr[11] = txtIss_PartyNameadd2.Text;
            dr[12] = txtIss_PartyNameadd3.Text;
            dr[13] = txtIss_PartyNameadd4.Text;
            dr[14] = txtPlace_Of_Issue.Text;
            dr[15] = txtIssue_Date.Text;
            dr[16] = txtBenPartyName.Text;
            dr[17] = txtBenPartyNameadd1.Text;
            dr[18] = txtBenPartyNameadd2.Text;
            dr[19] = txtBenPartyNameadd3.Text;
            dr[20] = txtBenPartyNameadd4.Text;

            string status = txtstatus.Text;
            if (status != "" && status != "Failed.")
            {
                dr[21] = status;
            }
            else
            {
                dr[21] = "In Progress...";
            }
            dr[22] = txtUser.Text;
            dr[23] = txtslid.Text;
            dr[24] = txtGuidid.Text;
            dtt.Rows.Add(dr);
            R = R + 1;
        }
        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
        return xmlData;
    }
    private static string ConvertDataTableToXML(DataTable dtData)
    {
        DataSet dsData = new DataSet();
        StringBuilder sbSQL;
        StringWriter swSQL;
        string XMLformat;
        try
        {
            sbSQL = new StringBuilder();
            swSQL = new StringWriter(sbSQL);
            dsData.Merge(dtData, true, MissingSchemaAction.AddWithKey);
            dsData.Tables[0].TableName = "SampleDataTable";
            foreach (DataColumn col in dsData.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            dsData.WriteXml(swSQL, XmlWriteMode.WriteSchema);
            XMLformat = sbSQL.ToString();
            return XMLformat;
        }
        catch (Exception sysException)
        {
            throw sysException;
        }
    }
    public static bool HasDigitalSignature(string pdfPath)
    {
        PdfReader reader = null;
        try
        {
            reader = new PdfReader(pdfPath);
            AcroFields af = reader.AcroFields;
            var names = af.GetSignatureNames();
            return names.Count > 0;
        }
        finally
        {
            if (reader != null)
                reader.Close();
        }
    }

    public int insert_update(string Flag, string xmlData_A)
    {

        ObjUBO.A11 = txttransid.Text;
        ObjUBO.A13 = hdn_mailid.Value;
        ObjUBO.A12 = hdn_mailtype.Value;
        ObjUBO.A18 = txtmailhost.Text;
        ObjUBO.A17 = txtmailpass.Text;
        ObjUBO.A19 = txtmailport.Text;
        ObjUBO.A20 = txtmailssl.Text;
        ObjUBO.A21 = txttenetid.Text;
        ObjUBO.A22 = txtclientid.Text;
        ObjUBO.A23 = txtscreenid.Text;
        ObjUBO.A14 = txtmobilno.Text;
        ObjUBO.A5 = xmlData_A;
        ObjUBO.A6 = hdn_icegate_user.Value;
        ObjUBO.A7 = hdn_icegate_pass.Value;
        ObjUBO.A15 = Flag;
        ds = IA.IRN_Automation_Insert_Update_BG(ObjUBO);
        int i = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        return i;
    }
    protected void btndeletefileclose_Click(object sender, EventArgs e)
    {
        string baseFolderPath = HttpContext.Current.Server.MapPath("~/Submission/IRN_Doc_Uploads/" + COMPANY_ID + "/" + currentbranch);
        string targetFolderPath = Path.Combine(baseFolderPath, txttransid.Text);

        if (Directory.Exists(targetFolderPath))
        {
            Directory.Delete(targetFolderPath, true);
        }

    }
    protected void btndelete_Storedfile_Click(object sender, EventArgs e)
    {
        try
        {

            string uploadPath = HttpContext.Current.Server.MapPath(
            "~/Submission/IRN_Doc_Uploads/" + COMPANY_ID + "/" + currentbranch);

            string logPath = HttpContext.Current.Server.MapPath(
                "~/Submission/IRN_LOG/" + COMPANY_ID + "/" + currentbranch);

            // Keep only last 7 days
            DateTime cutoffDate = DateTime.Now.AddDays(-7);

            DeleteOldFolders(uploadPath, cutoffDate);
            DeleteOldFolders(logPath, cutoffDate);
        }
        catch (Exception ex)
        {

        }
    }

    private void DeleteOldFolders(string parentPath, DateTime cutoffDate)
    {
        if (!Directory.Exists(parentPath))
            return;

        DirectoryInfo parentDir = new DirectoryInfo(parentPath);
        DirectoryInfo[] subFolders = parentDir.GetDirectories();

        foreach (DirectoryInfo folder in subFolders)
        {
            // Delete folders older than 7 days
            if (folder.CreationTime < cutoffDate)
            {
                try
                {
                    folder.Delete(true); // true = recursive delete
                }
                catch
                {
                    // Optional: log which folder failed
                }
            }
        }
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int i = insert_update("IRN_UI_SAVE", IRN_details());
            if (i > 0)
            {
                hdn_saved.Value = "T";

            }
            if (Message == "Delete Row")
            {
                Alert_msg("Row Deleted.");
                File.AppendAllText(logFile, "Row Deleted.");
            }
            else if (ds.Tables[0].Rows.Count > 0 && Message != "Delete Row")
            {
                string prompt =
                         "<script>" +
                         "$(document).ready(function () {" +
                             "jAlert('" + Message + "', 'GENERAL', function (r) {" +
                                 "if (r) {" +
                                     "if (typeof RefreshParent === 'function') { RefreshParent(); }" +
                                     "if (window.parent && window.parent.document.getElementById('btnSearch')) {" +
                                         "window.parent.document.getElementById('btnSearch').click();" +
                                     "}" +
                                 "}" +
                             "});" +
                         "});" +
                         "</script>";
                File.AppendAllText(logFile, prompt);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "jalert", prompt, false);



                //Alert_msg("Saved Successfully");
                string baseFolderPath = HttpContext.Current.Server.MapPath("~/Submission/IRN_Doc_Uploads/" + COMPANY_ID + "/" + currentbranch);
                string targetFolderPath = Path.Combine(baseFolderPath, txttransid.Text);

                //if (Directory.Exists(targetFolderPath))
                //{
                //    Directory.Delete(targetFolderPath, true);
                //}
                if (Directory.Exists(targetFolderPath))
                {
                    bool hasFiles = false;
                    string[] files = Directory.GetFiles(targetFolderPath);
                    hasFiles = files.Length > 0;
                    if (hasFiles)
                    {
                        hdn_path_check.Value = "true";
                    }

                }
                else
                {
                    hdn_path_check.Value = "";
                }
                hdn_saved.Value = "Y";
                hdn_Grid.Value = "Y";
            }
            else
            {

                Alert_msg("Details Not Saved");
                File.AppendAllText(logFile, "Details Not Saved");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
            //File.AppendAllText(logFile, "Save Error:" + ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        gv_Details.DataSource = dt;
        gv_Details.DataBind();
        mo.ResetFields(Page.Controls);
        btnDelete.Visible = false;
        btnNew.Visible = false;
        btnSave.Visible = true;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = ViewState["CurrentTable"] as DataTable;
            if (dt == null || dt.Rows.Count == 0) return;

            bool gridHasIRN = false;


            foreach (GridViewRow row in gv_Details.Rows)
            {
                TextBox txtIRN = row.FindControl("txtIRNno") as TextBox;
                if (txtIRN != null && !string.IsNullOrEmpty(txtIRN.Text.Trim()))
                {
                    gridHasIRN = true;
                    break;
                }
            }

            bool anySelected = false;
            List<string> slNoList = new List<string>();
            List<string> irnList = new List<string>();

            for (int i = gv_Details.Rows.Count - 1; i >= 0; i--)
            {
                GridViewRow row = gv_Details.Rows[i];
                CheckBox chk = row.FindControl("chkSelect") as CheckBox;

                if (chk != null && chk.Checked)
                {
                    anySelected = true;

                    TextBox txtFile = row.FindControl("txtFileName") as TextBox;
                    TextBox txtIRN = row.FindControl("txtIRNno") as TextBox;
                    TextBox txtslid = row.FindControl("txtslid") as TextBox;

                    string fileName = txtFile != null ? txtFile.Text : "";
                    string irnNo = txtIRN != null ? txtIRN.Text.Trim() : "";
                    string SL_NO = txtslid != null ? txtslid.Text.Trim() : "";

                    if (!string.IsNullOrEmpty(irnNo))
                        irnList.Add(irnNo);

                    if (!string.IsNullOrEmpty(SL_NO))
                        slNoList.Add(SL_NO);

                    string folderPath = Server.MapPath("~/Submission/IRN_Doc_Uploads/"
                        + COMPANY_ID + "/" + currentbranch + "/" + txttransid.Text + "/");

                    string filePath = Path.Combine(folderPath, fileName);
                    if (File.Exists(filePath))
                        File.Delete(filePath);

                    dt.Rows.RemoveAt(i);
                }
            }

            if (!anySelected)
            {
                Alert_msg("Please select record(s) to delete.");
                return;
            }

            if (gridHasIRN && slNoList.Count > 0)
            {
                ObjUBO.A15 = "Delete";
                ObjUBO.A2 = string.Join("~", slNoList);
                ObjUBO.A11 = txttransid.Text;
                IA.IRN_Automation_Insert_Update_BG(ObjUBO);
            }

            ViewState["CurrentTable"] = dt;
            gv_Details.DataSource = dt;
            gv_Details.DataBind();

            Alert_msg("Selected record(s) deleted successfully.");
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    protected void gv_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.Footer)
            e.Row.CssClass = "Footer";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //load_DOC_CODE(e);
        }
    }


    protected void gv_RITC_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    public void Alert_msg(string msg)
    {

        if (msg == "")
        {
            msg = "Completed";
        }
        string cleanMsg = msg.Replace("<br>", "\\n").Replace("'", "\\'").Replace("\"", "\\\"").Replace("\n", "\\n");
        string script = "<script type='text/javascript'>alert('" + cleanMsg + "');</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", script, false);


    }

    [System.Web.Services.WebMethod]
    public static string Get_Doc_type_level(string DocType)
    {
        string Doc_Level = "";
        adminmaster Admin_mas = new adminmaster();
        DataSet ds = new DataSet();
        try
        {
            Admin_mas.EUnit_code = DocType;
            Admin_mas.Ename = "select_SUP_DOCS_TYPE";
            ds = Admin_mas.RetrieveAll_SUPPROTING_DOCS_Master();
            if (ds.Tables[1].Rows.Count > 0)
            {
                Doc_Level = ds.Tables[1].Rows[0]["DOC_LEVEL"].ToString();
            }
            return Doc_Level;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return Doc_Level;
    }


    [System.Web.Services.WebMethod]
    public static string Get_imp_exp(string jobno, string invsl, string itmsl, string jobtype)
    {
        string Imp_Exp = "";
        IRN_Automation IA = new IRN_Automation();
        Global_variables ObjUBO = new Global_variables();
        DataSet ds = new DataSet();
        try
        {
            ObjUBO.A2 = jobno;
            ObjUBO.A11 = invsl;
            ObjUBO.A14 = itmsl;
            ObjUBO.A10 = jobtype;
            ObjUBO.A15 = "Load_Imp_Exp_Data";
            ds = IA.IRN_Automation_Insert_Update_BG(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Imp_Exp = ds.Tables[0].Rows[0]["IMP_EXP"].ToString();
            }
            return Imp_Exp;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return Imp_Exp;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Mail_Ids(string Mailtype)
    {
        IRN_Automation IA = new IRN_Automation();
        Global_variables ObjUBO = new Global_variables();
        DataSet ds = new DataSet();
        try
        {
            ObjUBO.A12 = Mailtype;
            ObjUBO.A15 = "Load_Mailid";
            ds = IA.IRN_Automation_Insert_Update_BG(ObjUBO);

            var list = new System.Collections.Generic.List<object>();
            foreach (DataRow row in ds.Tables[0].Rows)  // loop ALL rows
            {
                list.Add(new
                {
                    value = row["MAILID"].ToString(),
                    text = row["MAILID"].ToString()
                });
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(list);
        }
        catch (Exception ex)
        {
            return "[]";
        }
    }

    [System.Web.Services.WebMethod]
    public static string Get_mail_data(string Mailtype, string mailid)
    {
        string Maildata = "";
        IRN_Automation IA = new IRN_Automation();
        Global_variables ObjUBO = new Global_variables();
        DataSet ds = new DataSet();
        try
        {
            ObjUBO.A12 = Mailtype;
            ObjUBO.A13 = mailid;
            ObjUBO.A15 = "Load_Mailid_Data";
            ds = IA.IRN_Automation_Insert_Update_BG(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Maildata = ds.Tables[0].Rows[0]["maildata"].ToString();
            }
            return Maildata;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return Maildata;
    }
    [System.Web.Services.WebMethod]
    public static string Get_Mail_Type(string icegateUser, string icegatePass)
    {
        IRN_Automation IA = new IRN_Automation();
        Global_variables ObjUBO = new Global_variables();
        DataSet ds = new DataSet();
        try
        {
            // Pass icegate credentials if your SP needs them
            // otherwise just load all mail types same as Load_Mail_Type()
            ObjUBO.A15 = "Load_Mailtype_Data";
            ds = IA.IRN_Automation_Insert_Update_BG(ObjUBO);

            var list = new System.Collections.Generic.List<object>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new
                {
                    value = row["SERVER_TYPE"].ToString(),
                    text = row["SERVER_TYPE"].ToString()
                });
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(list);
        }
        catch (Exception ex)
        {
            return "[]";
        }
    }
}                                                                                                                  