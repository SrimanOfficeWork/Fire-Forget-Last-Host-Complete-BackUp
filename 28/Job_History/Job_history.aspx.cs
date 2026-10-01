using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using System.Text;

public partial class Job_histroy : ThemeClass
{
    DataTable dt = new DataTable();
    DataRow dr;
    DataSet dss = new DataSet();
    DataSet ds = new DataSet();
    ErrorLogs er = new ErrorLogs();
    IMP_Job_Clearance IJC = new IMP_Job_Clearance();
    
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    AppSession aps = new AppSession();
    Job_Histroy jh = new Job_Histroy();  
    
    public string currentbranch,currentuser,Working_Period,SELECT_BRANCH;
    public string errorFolder = "", fileName, attach_File,Upload_Flag;
    public string Attach_Folder;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            currentbranch = Connection.Current_Branch();
            Working_Period = Connection.WorkingPeriod();
            currentuser = Connection.Current_User();
            SELECT_BRANCH = Connection.Get_Company_Type();

            jh.JOBNO = Request["jobno"].ToString();
            jh.JOBDATE = Request["jobdate"].ToString();
            jh.JOB_TYPE = Request["type"].ToString();
            string financialYear = GetFinancialYear();



            // -- Need to Implement in future for common wise clients also...
            //if (Connection.Get_Company_Type() != "")
            //{
            //    errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + currentbranch + "/" + jh.JOB_TYPE + "_Job_history" + "/");
            //}
            //else
            //{
            //    errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + jh.JOB_TYPE + "_Job_history" + "/");
            //}



            //if (Connection.COMPANYID() != "293" && Connection.COMPANYID() != "1" && Connection.COMPANYID() != "747")
            //{
            //    errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + currentbranch + "/" + jh.JOB_TYPE + "_Job_history" + "/");
            //}
            //else
            //{
            //    errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + jh.JOB_TYPE + "_Job_history" + "/");
            //}

            // commented for areawise implementation on 05-mar-2020
            string SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();
            if (SELECT_TYPE == "Branchwise Job")
            {
                errorFolder = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() + "/" + jh.JOB_TYPE + "_Job_history" + "/");

            }
            else if (SELECT_TYPE == "Areawise Job")
            {
                errorFolder = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["GroupName"].ToString() + "/" + jh.JOB_TYPE + "_Job_history" + "/");
            }
            else
            {
                errorFolder = HttpContext.Current.Server.MapPath("~/Submission/" + "/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + jh.JOB_TYPE + "_Job_history" + "/");
            }

            Attach_Folder = HttpContext.Current.Server.MapPath("~/Submission/" + financialYear + "/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + Session["GroupName"].ToString() + "/" + "Attachments/");


            btnClrDelete.OnClientClick = "jConfirm('Delete this Job Clearance?', 'Job Clearance', function(r) { var i = r + 'ok'; if (i == 'trueok') { document.getElementById('" + btnClr.ClientID + "').click(); } }); return false;";

            if (!IsPostBack)
            {

                if (Directory.Exists(errorFolder) == false)
                {
                    Directory.CreateDirectory(errorFolder);
                }
                if (Directory.Exists(Attach_Folder) == false)
                {
                    Directory.CreateDirectory(Attach_Folder);
                }
                grid_Bind_Job_Details();
                grid_Bind();
                load_Clearance_Grid();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }       
    }


    private string GetFinancialYear()
    {
        DateTime today = DateTime.Now;

        if (today.Month >= 4) // April to December
        {
            return today.Year + "-" + (today.Year + 1).ToString().Substring(2);
        }
        else // January to March
        {
            return (today.Year - 1) + "-" + today.Year.ToString().Substring(2);
        }
    }

    public void grid_Bind_Job_Details()
    {
        try
        {
            jh.JOBNO = Request["jobno"].ToString();
            jh.FLAG = "select";
            jh.BRANCH_CODE = SELECT_BRANCH;
            jh.JOB_TYPE = Request["type"].ToString();

            ds = jh.Job_History_Details();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvdetails1.DataSource = ds.Tables[0];
                gvdetails1.DataBind();
            }
            else
            {
                // Create dummy table to show header even if empty
                DataTable dt = new DataTable();
                dt.Columns.Add("JOB_NO");
                dt.Columns.Add("entrydate");
                dt.Columns.Add("File_Remarks");
                dt.Columns.Add("MailSubject");

                dt.Rows.Add(dt.NewRow()); // add empty row

                gvdetails1.DataSource = dt;
                gvdetails1.DataBind();

                // Show "NO RECORD FOUND" text centered
                gvdetails1.Rows[0].Cells.Clear();
                gvdetails1.Rows[0].Cells.Add(new TableCell());
                gvdetails1.Rows[0].Cells[0].ColumnSpan = gvdetails1.Columns.Count;
                gvdetails1.Rows[0].Cells[0].Text = "NO RECORD FOUND";
                gvdetails1.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                gvdetails1.Rows[0].Cells[0].Font.Bold = true;
                gvdetails1.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public void grid_Bind()
    {
        try
        {
            jh.FLAG = "select";
            jh.JOB_ID = "";
            Insert_Update(jh.FLAG, jh.JOB_ID, jh.JOB_TYPE, jh.DESCRIPTION, attach_File);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
     
    }

    protected void btn_Add_Click(object source, EventArgs e)
    {
        try
        {
            dt = (DataTable)ViewState["dt"];
            dr = dt.NewRow();
            string a = String.Format("{0: dd/MM/yyyy HH:mm:ss}", Convert.ToString(DateTime.Parse(String.Format("{0: dd/MM/yyyy HH:mm:ss}", DateTime.Now), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault)));
            dr["UPLOAD_DATE"] = a;
            dt.Rows.Add(dr);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
      

    }

    protected void btn_Remove_Click(object source, EventArgs e)
    {
        try
        {
            dt = (DataTable)ViewState["dt"];
            if (GridView1.Rows.Count - 1 != 0)
            {
                dt.Rows.RemoveAt(GridView1.Rows.Count - 1);
            }
            else
            {
            }
            ViewState["dt"] = dt;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
      

    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            txtItem_TextChanged(sender, e);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
      
    }

    protected void btnDelete_Click(object source, EventArgs e)
    {
        try
        {
            CheckBox chkAll = (CheckBox)GridView1.HeaderRow.Cells[0].FindControl("chkAll");
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (chkAll.Checked)
                {
                    CheckBox chk = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("chk");
                    if (chk.Checked)
                    {
                        jh.FLAG = "Delete";
                        Label lbl = (Label)GridView1.Rows[i].FindControl("lbl_JobId");
                        jh.JOB_ID = GridView1.Rows[i].Cells[5].Text;
                        Delete(jh.FLAG, jh.JOB_ID, jh.JOB_TYPE, jh.DESCRIPTION, attach_File);
                    }

                }
                else
                {
                    CheckBox chk = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("chk");
                    if (chk.Checked)
                    {
                        jh.FLAG = "Delete";
                        Label lbl = (Label)GridView1.Rows[i].FindControl("lbl_JobId");
                        jh.JOB_ID = GridView1.Rows[i].Cells[5].Text;
                        Delete(jh.FLAG, jh.JOB_ID, jh.JOB_TYPE, jh.DESCRIPTION, attach_File);
                    }
                }

            }
            if (jh.result == 1)
            {
                if (dss.Tables.Count > 0)
                {
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        GridView1.DataSource = dss.Tables[0];
                        GridView1.DataBind();

                        ViewState["dt"] = dss.Tables[0];
                    }
                    else
                    {
                        pageload();
                    }
                }
                else
                {
                    pageload();
                }

                Alert_msg("Deleted");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
    }

    protected void txtItem_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (Upload_Flag == "UPLOAD")
            {
                jh.FLAG = "Upload_File";
                attach_File = Request["jobno"].ToString() + "~~" + fileName;
                Insert_Update(jh.FLAG, jh.JOB_ID, jh.JOB_TYPE, jh.DESCRIPTION, attach_File);
            }
            else if (hdn_Val.Value == "Y")
            {
                if (string.IsNullOrEmpty(Upload_Flag))
                {
                    GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
                    int index = gvRow.RowIndex;
                    TextBox txt = (TextBox)GridView1.Rows[index].FindControl("txtItem");
                    //Label txtdate = (Label)GridView1.Rows[index].FindControl("txtdate");
                    TextBox txtdate = (TextBox)GridView1.Rows[index].FindControl("txtdate");

                    jh.DESCRIPTION = txt.Text;
                    string values = GridView1.Rows[index].Cells[5].Text;
                    jh.FLAG = "S";
                    jh.UPLOAD_DATE = txtdate.Text;
                    if (values != "" && values != "&nbsp;")
                        jh.JOB_ID = values;
                    else
                    {
                        Label lbl = (Label)GridView1.Rows[index].FindControl("lbl_JobId");

                        jh.JOB_ID = lbl.Text;
                    }
                    Insert_Update(jh.FLAG, jh.JOB_ID, jh.JOB_TYPE, jh.DESCRIPTION, attach_File);
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
       
      
    }

    public void Insert_Update(string flag, string id, string type, string DESCRIPTION, string attach_File)
    {
        try
        {
            jh.JOB_ID = id;
            jh.JOB_TYPE = type;
            jh.COMPANY_ID = HttpContext.Current.Session["COMPANY_ID"].ToString();
            jh.DESCRIPTION = DESCRIPTION;
            jh.ATTACHMENT_FILE = attach_File;
            jh.FLAG = flag;
            jh.USER_ID = currentuser;
            jh.BRANCH_CODE = currentbranch;
            jh.YEAR = "";
            jh.WORKING_PERIOD = Working_Period;
            jh.BRANCH_COMMON = SELECT_BRANCH;
            dss = jh.IMP_EXP_JOB_HISTROY_INSERT_UPDATE();

            if (dss.Tables.Count > 0)
            {
                if (dss.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = dss.Tables[0];
                    GridView1.DataBind();

                    ViewState["dt"] = dss.Tables[0];
                }
                else
                {
                    pageload();
                }

             // DataTable da = new DataTable();
              DataTable dtFiles = dss.Tables[1].Copy();
                //if (dss.Tables[1].Rows.Count > 0)
                //{
                //    gvdetails.DataSource = dss.Tables[1];
                //    gvdetails.DataBind();
                //}
                    //
                if (dss.Tables[1].Rows.Count > 0)
                                {
                                   

                                    for (int i = dtFiles.Rows.Count - 1; i >= 0; i--)
                                    {
                                        string webPath = Convert.ToString(dtFiles.Rows[i]["WEB_PATHURL"]);

                                        if (!string.IsNullOrEmpty(webPath))
                                        {
                                            DataRow newRow = dtFiles.NewRow();

                                            newRow["ATTACHMENT_FILE"] = webPath;

                                            if (dtFiles.Columns.Contains("FILE_JOB_ID"))
                                                newRow["FILE_JOB_ID"] = dtFiles.Rows[i]["FILE_JOB_ID"];

                                            dtFiles.Rows.InsertAt(newRow, i + 1);
                                        }
                                    }

                                    gvdetails.DataSource = dtFiles;
                                    gvdetails.DataBind();
                                }
                                else
                                {
                                    gvdetails.DataSource = dtFiles;
                                    gvdetails.DataBind();
                                }
                    //
                //else
                //{
                //    gvdetails.DataSource = da;
                //    gvdetails.DataBind();
                //}
            }
            else
            {
                pageload();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
    }
   
    public void Delete(string flag, string id, string type, string DESCRIPTION, string attach_File)
    {
        try
        {
            jh.JOB_ID = id;
            jh.JOB_TYPE = type;
            jh.COMPANY_ID = HttpContext.Current.Session["COMPANY_ID"].ToString();
            jh.DESCRIPTION = DESCRIPTION;
            jh.ATTACHMENT_FILE = attach_File;
            jh.FLAG = flag;
            jh.USER_ID = currentuser;

            jh.BRANCH_CODE = currentbranch;
            jh.YEAR = "";
            jh.WORKING_PERIOD = Working_Period;
            jh.BRANCH_COMMON = SELECT_BRANCH;
            dss = jh.IMP_EXP_JOB_HISTROY_INSERT_UPDATE();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

       
    }

    public void pageload()
    {
        try
        {
            DataColumn da = new DataColumn("UPLOAD_DATE", typeof(DateTime));
            DataColumn da1 = new DataColumn("DESCRIPTION");
            DataColumn da2 = new DataColumn("JOB_ID");
            DataTable dtt = new DataTable();
            dtt.Columns.Add(da);
            dtt.Columns.Add(da1);
            dtt.Columns.Add(da2);
            dr = dtt.NewRow();

            string a = String.Format("{0: dd/MM/yyyy HH:mm:ss}", Convert.ToString(DateTime.Parse(String.Format("{0: dd/MM/yyyy HH:mm:ss}", DateTime.Now), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault)));

            dr["UPLOAD_DATE"] = a;
            dr["DESCRIPTION"] = "";
            dr["JOB_ID"] = "";

            dtt.Rows.Add(dr);
            GridView1.DataSource = dtt;
            GridView1.DataBind();
            ViewState["dt"] = dtt;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
      
    }

    protected void GridView1_OnDataBound(object source, EventArgs e)
    {
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                TextBox NextTextBox = (TextBox)e.Row.FindControl("txtItem");
                NextTextBox.Attributes.Add("onkeypress", "return EnterEvent(event);");

                //Label txt = (Label)e.Row.FindControl("txtdate");
                TextBox txt = (TextBox)e.Row.FindControl("txtdate");
                if (txt.Text != "" && txt.Text != "&nbsp;" && txt.Text != "01/01/1900")
                {

                }
                else
                {
                    string ii = String.Format("{0: dd/MM/yyyy HH:mm:ss}", DateTime.Now);


                    txt.Text = String.Format("{0: dd/MM/yyyy HH:mm:ss}", Convert.ToString(DateTime.Parse(ii, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault)));
                }

                CheckBox headerchk = (CheckBox)GridView1.HeaderRow.FindControl("chkAll");
                CheckBox childchk = (CheckBox)e.Row.FindControl("chk");
                childchk.Attributes.Add("onclick", "javascript:Selectchildcheckboxes('" + headerchk.ClientID + "','GridView1','btnDelete')");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

      
    }

    protected void btn_Upload_Click(object sender, EventArgs e)
    {
        try
        {
            HttpFileCollection fileCollection = Request.Files;

            for (int i = 0; i < fileCollection.Count; i++)
            {
                HttpPostedFile uploadfile = fileCollection[i];
                fileName = Path.GetFileName(uploadfile.FileName);
                string ext = Path.GetExtension(uploadfile.FileName).ToLower();
                if (ext == ".sb" || ext == ".be" || ext == ".rtf" || ext == ".txt" || ext == ".doc" || ext == ".docx" || ext == ".xml" || ext == ".html" || ext == ".htm" || ext == ".xls" || ext == ".xlsx" || ext == ".pdf" || ext == ".jpg" || ext == ".jpeg" || ext == ".zip" || ext == ".rar" || ext == ".png" || ext == ".gif" || ext == ".rpl" || ext == ".json")
                {
                    if (uploadfile.ContentLength > 0)
                    {
                        if (uploadfile.ContentLength < 10485760)
                        {

                            string file = Request["jobno"].ToString() + "~~" + fileName;
                            string path = errorFolder + file;
                            jh.FLAG = "File_Exists";
                            jh.DESCRIPTION = errorFolder;
                            jh.ATTACHMENT_FILE = file;
                            jh.JOB_ID = "";
                            Upload_Flag = "UPLOAD";
                            Insert_Update(jh.FLAG, jh.JOB_ID, jh.JOB_TYPE, jh.DESCRIPTION, jh.ATTACHMENT_FILE);

                            if (jh.result == 1)
                            {
                                Alert_msg("File already exists! Please Try another one file for upload");
                            }
                            else
                            {
                                uploadfile.SaveAs(errorFolder + file);
                                txtItem_TextChanged(sender, e);
                            }
                        }
                        else
                        {
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
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
    }

    protected void gvdetails1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.CssClass = "header";
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
                e.Row.CssClass = "normal";
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
                e.Row.CssClass = "alternate";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
    }
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.CssClass = "header";
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
                e.Row.CssClass = "normal";
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
                e.Row.CssClass = "alternate";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
     
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.CssClass = "header";
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
                e.Row.CssClass = "txt";
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
                e.Row.CssClass = "txt";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            grid_Bind();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        
           
    }

    protected void gvdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvdetails.PageIndex = e.NewPageIndex;
            grid_Bind();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
     
    }

    protected void btn_File_Delete_Click(object source, EventArgs e)
    {
        try
        {
            CheckBox chkAll = (CheckBox)gvdetails.HeaderRow.Cells[0].FindControl("chkAll");
            for (int i = 0; i < gvdetails.Rows.Count; i++)
            {
                if (chkAll.Checked)
                {
                    CheckBox chk = (CheckBox)gvdetails.Rows[i].Cells[0].FindControl("chk");
                    if (chk.Checked)
                    {
                        jh.FLAG = "Delete_Upload_File";

                        jh.JOB_ID = gvdetails.Rows[i].Cells[2].Text;
                        Insert_Update(jh.FLAG, jh.JOB_ID, jh.JOB_TYPE, jh.DESCRIPTION, attach_File);
                    }
                }
                else
                {
                    CheckBox chk = (CheckBox)gvdetails.Rows[i].Cells[0].FindControl("chk");
                    if (chk.Checked)
                    {
                        jh.FLAG = "Delete_Upload_File";
                        jh.JOB_ID = gvdetails.Rows[i].Cells[2].Text;
                        Insert_Update(jh.FLAG, jh.JOB_ID, jh.JOB_TYPE, jh.DESCRIPTION, attach_File);
                    }

                }
            }
            if (jh.result == 1)
                Alert_msg("File Deleted");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
      

    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'JOB HISTROY', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void gvdetails1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Example: Accessing columns by name
                string jobNo = DataBinder.Eval(e.Row.DataItem, "JOB_NO") != null
                    ? DataBinder.Eval(e.Row.DataItem, "JOB_NO").ToString()
                    : string.Empty;

                string remarks = DataBinder.Eval(e.Row.DataItem, "File_Remarks") != null
                    ? DataBinder.Eval(e.Row.DataItem, "File_Remarks").ToString()
                    : string.Empty;

                string mailSubject = DataBinder.Eval(e.Row.DataItem, "MailSubject") != null
                    ? DataBinder.Eval(e.Row.DataItem, "MailSubject").ToString()
                    : string.Empty;

                // Example: highlight if remarks is empty
                if (string.IsNullOrEmpty(remarks))
                {
                    e.Row.BackColor = System.Drawing.Color.LightYellow;
                }

                // Example: make MailSubject clickable (if using LinkButton inside)
                LinkButton lnk = (LinkButton)e.Row.FindControl("lnkDownload");
                if (lnk != null)
                {
                    lnk.CommandArgument = mailSubject;  // Pass subject for download or any action
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            Date_Time dt = new Date_Time();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton txt = (LinkButton)e.Row.FindControl("txtdate");
                if (txt.Text != "" && txt.Text != "&nbsp;")
                {
                    txt.Text = dt.Split_main("~~", txt.Text);
                }
                CheckBox headerchk = (CheckBox)gvdetails.HeaderRow.FindControl("chkAll");
                CheckBox childchk = (CheckBox)e.Row.FindControl("chk");
                childchk.Attributes.Add("onclick", "javascript:Selectchildcheckboxes('" + headerchk.ClientID + "','gvdetails','btn_File_Delete')");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
    }
    protected void lnkDownload_Click_New(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkbtn = sender as LinkButton;
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            string a = gvdetails1.DataKeys[gvrow.RowIndex].Value.ToString();
            string filePath = Attach_Folder + a;

            if (lnkbtn.Text != "" && lnkbtn.Text != "&nbsp;")
            {
                System.IO.FileInfo file = new System.IO.FileInfo(Attach_Folder + a);

                string ext = Path.GetExtension(file.Name).ToLower();

                Response.Clear();
                Response.ClearContent();

                if (ext == ".doc" || ext == ".docx")
                {
                    Response.ContentType = "Application/msword";
                }
                else if (ext == ".json")
                {
                    Response.ContentType = "application/json";
                }
                else if (ext == ".pdf")
                {
                    Response.ContentType = "Application/pdf";
                }
                else if (ext == ".xls" || ext == ".xlsx")
                {
                    Response.ContentType = "Application/x-msexcel";
                }
                else if (ext == ".jpg" || ext == ".jpeg")
                {
                    Response.ContentType = "image/jpeg";
                }
                else if (ext == ".gif")
                {
                    Response.ContentType = "image/GIF";
                }
                else if (ext == ".html" || ext == ".htm")
                {
                    Response.ContentType = "text/HTML";
                }
                else if (ext == ".txt" || ext == ".be" || ext == ".sb")
                {
                    Response.ContentType = "text/plain";
                }
                else
                {
                    Response.ContentType = MimeType(Path.GetExtension(file.Name));
                }

                Response.AddHeader("Content-Disposition", "attachment;filename=" + lnkbtn.Text);
                Response.AddHeader("Content-Length", file.Length.ToString());

                Response.TransmitFile(file.FullName);
                Response.End();


            }
        }
         catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
      
        //   end
    }
   
    public static string MimeType(string Extension)
    {
        string mime = "application/octetstream";
        try
        {
         
            if (string.IsNullOrEmpty(Extension))
                return mime;
            string ext = Extension.ToLower();
            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (rk != null && rk.GetValue("Content Type") != null)
            {
                if (ext == ".rtf" || ext == ".doc")
                {
                    mime = "application/rtf";
                }
                else if (ext == ".sb" || ext == ".be" || ext == ".SB" || ext == ".BE" || ext ==".json")
                {
                    mime = "text/plain";
                }
                else
                    mime = rk.GetValue("Content Type").ToString();
            }
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return mime;
       
    }

    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkbtn = sender as LinkButton;
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            if (lnkbtn.Text != "" && lnkbtn.Text != "&nbsp;")
            {
                System.IO.FileInfo file = new System.IO.FileInfo(errorFolder + jh.JOBNO + "~~" + lnkbtn.Text);
                string filePath = errorFolder + jh.JOBNO + "~~" + lnkbtn.Text;
                string ext = Path.GetExtension(file.Name).ToLower();

                Response.Clear();
                Response.ClearContent();

                if (ext == ".doc" || ext == ".docx")
                {
                    Response.ContentType = "Application/msword";
                }
                else if (ext == ".json")
                {
                    Response.ContentType = "application/json";
                }
                else if (ext == ".pdf")
                {
                    Response.ContentType = "Application/pdf";
                }
                else if (ext == ".xls" || ext == ".xlsx")
                {
                    Response.ContentType = "Application/x-msexcel";
                }
                else if (ext == ".jpg" || ext == ".jpeg")
                {
                    Response.ContentType = "image/jpeg";
                }
                else if (ext == ".gif")
                {
                    Response.ContentType = "image/GIF";
                }
                else if (ext == ".html" || ext == ".htm")
                {
                    Response.ContentType = "text/HTML";
                }
                else if (ext == ".txt" || ext == ".be" || ext == ".sb")
                {
                    Response.ContentType = "text/plain";
                }
                else
                {
                    Response.ContentType = MimeType(Path.GetExtension(file.Name));
                }

                Response.AddHeader("Content-Disposition", "attachment;filename=" + lnkbtn.Text);
                Response.AddHeader("Content-Length", file.Length.ToString());

                Response.TransmitFile(file.FullName);
                Response.End();


            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
    }
    protected void lnkfileDownload_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkbtn = sender as LinkButton;
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            string a = gvdetails.DataKeys[gvrow.RowIndex].Value.ToString();
            string filePath = Attach_Folder + a;

            if (lnkbtn.Text != "" && lnkbtn.Text != "&nbsp;")
            {
                System.IO.FileInfo file = new System.IO.FileInfo(Attach_Folder + a);

                string ext = Path.GetExtension(file.Name).ToLower();

                Response.Clear();
                Response.ClearContent();

                if (ext == ".doc" || ext == ".docx")
                {
                    Response.ContentType = "Application/msword";
                }
                else if (ext == ".json")
                {
                    Response.ContentType = "application/json";
                }
                else if (ext == ".pdf")
                {
                    Response.ContentType = "Application/pdf";
                }
                else if (ext == ".xls" || ext == ".xlsx")
                {
                    Response.ContentType = "Application/x-msexcel";
                }
                else if (ext == ".jpg" || ext == ".jpeg")
                {
                    Response.ContentType = "image/jpeg";
                }
                else if (ext == ".gif")
                {
                    Response.ContentType = "image/GIF";
                }
                else if (ext == ".html" || ext == ".htm")
                {
                    Response.ContentType = "text/HTML";
                }
                else if (ext == ".txt" || ext == ".be" || ext == ".sb")
                {
                    Response.ContentType = "text/plain";
                }
                else
                {
                    Response.ContentType = MimeType(Path.GetExtension(file.Name));
                }

                Response.AddHeader("Content-Disposition", "attachment;filename=" + lnkbtn.Text);
                Response.AddHeader("Content-Length", file.Length.ToString());

                Response.TransmitFile(file.FullName);
                Response.End();


            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        //   end
    }

    private void load_Clearance_Grid()
    {
        try
        {
            DataSet dssClr = new DataSet();
            IJC.Jobno = jh.JOBNO;
            IJC.Flag = "Updated_Grid_Data";
            dssClr = IJC.IMP_Job_Clearance_select();

            if (dssClr.Tables.Count > 0 && dssClr.Tables[0].Rows.Count > 0)
            {
                gv_Chg_Details.DataSource = dssClr;
                gv_Chg_Details.DataBind();
            }
            else
            {
                gv_Chg_Details.DataSource = null;
                gv_Chg_Details.DataBind();
            }

            if (dssClr.Tables.Count > 1 && dssClr.Tables[1].Rows.Count > 0)
            {
                if (dssClr.Tables[1].Rows[0]["IMPORTER_NAME"].ToString() != "")
                {
                    hdn_ImpName.Value = dssClr.Tables[1].Rows[0]["IMPORTER_NAME"].ToString();
                }
                else
                {
                    hdn_ImpName.Value = Session["IMPORTER_NAME"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void gv_Chg_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

    protected void btnsaveupdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (gv_Chg_Details.Rows.Count > 0)
            {
                DataTable dtt = new DataTable();
                dtt.Columns.Add(new DataColumn("STAGE_ID", typeof(String)));
                dtt.Columns.Add(new DataColumn("DATE_INFO", typeof(String)));
                dtt.Columns.Add(new DataColumn("HANDLED_BY", typeof(String)));
                dtt.Columns.Add(new DataColumn("REMARKS", typeof(String)));

                foreach (GridViewRow row in gv_Chg_Details.Rows)
                {
                    Label txt_CH_ID = (Label)row.FindControl("txt_CH_ID");
                    TextBox txt_Acc_date = (TextBox)row.FindControl("txt_Acc_date");
                    TextBox txt_handled_by = (TextBox)row.FindControl("txt_handled_by");
                    TextBox txt_remarks = (TextBox)row.FindControl("txt_remarks");

                    DataRow drClr = dtt.NewRow();
                    drClr[0] = txt_CH_ID.Text;
                    drClr[1] = txt_Acc_date.Text != string.Empty ? txt_Acc_date.Text : string.Empty;
                    drClr[2] = txt_handled_by.Text;
                    drClr[3] = txt_remarks.Text;
                    dtt.Rows.Add(drClr);
                }

                DataSet dsData = new DataSet();
                dsData.Tables.Add(dtt);
                String xmlData = ConvertDataTableToXML(dsData.Tables[0]);

                IJC.Jobno = jh.JOBNO;
                IJC.Imp_Name = Session["IMPORTER_NAME"].ToString();
                IJC.Xml_D = xmlData;
                IJC.Flag = "Insert_Update";
                IJC.IMP_Job_Clearance_select();
                Alert_msg("Save and Updated Successfully.");
                KeepClearanceTabActive();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    private void KeepClearanceTabActive()
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "keepTab3", "$(document).ready(function(){ tab3('0'); });", true);
    }

    private static string ConvertDataTableToXML(DataTable dtData)
    {
        DataSet dsData = new DataSet();
        StringBuilder sbSQL = new StringBuilder();
        StringWriter swSQL = new StringWriter(sbSQL);

        dsData.Merge(dtData, true, MissingSchemaAction.AddWithKey);
        dsData.Tables[0].TableName = "SampleDataTable";
        foreach (DataColumn col in dsData.Tables[0].Columns)
        {
            col.ColumnMapping = MappingType.Attribute;
        }
        dsData.WriteXml(swSQL, XmlWriteMode.WriteSchema);
        return sbSQL.ToString();
    }

    protected void btnClrDelete_Click(object sender, EventArgs e)
    {
        try
        {
            IJC.Jobno = jh.JOBNO;
            IJC.Imp_Name = hdn_ImpName.Value;
            IJC.Xml_D = "";
            IJC.Flag = "Job_Clearance_Delete";
            IJC.IMP_Job_Clearance_select();
            load_Clearance_Grid();
            Alert_msg("Job Clearance Deleted");
            KeepClearanceTabActive();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

}