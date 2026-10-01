using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Globalization;
using System.Web.Services;

public partial class Job_History_Job_history_new : ThemeClass
{
    AppSession aps = new AppSession();

    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 25;
    
    DataSet dtuser = new DataSet();
    eroyalmaster erm = new eroyalmaster();
    SqlConnection con;

    Read_mail RM = new Read_mail();


    public string  New_Jobtype,SELECT_BRANCH;

    int[] f = new int[100];
    int[] l = new int[100];
    public string Attach_Folder;
    int pageno, ii;
    const int pageSize = 10;
    const int pageDispCount = 10;

    public char ch = Convert.ToChar(29);
    List<Maildb> lstMails = new List<Maildb>();
    Maildb mdb = new Maildb();
    DataSet ds = new DataSet();
    DataSet dss = new DataSet();
    EnvironmentVariableTarget query;
    string xx = "first";

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        txt_type.Focus();
        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

        SELECT_BRANCH = Connection.Get_Company_Type();
        string financialYear = GetFinancialYear();
        Attach_Folder = HttpContext.Current.Server.MapPath("~/Submission/" + financialYear + "/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + Session["GroupName"].ToString() + "/" + "Attachments/");
        Div_Pagination.Visible = false;
        div_pagination1.Visible = false;
        

        if (!string.IsNullOrEmpty(Session["JOBTYPE_new"].ToString()))
        {
            New_Jobtype = Session["JOBTYPE_new"].ToString();
        }

        if (!IsPostBack)
        {
            view_control(New_Jobtype);

            if (Directory.Exists(Attach_Folder) == false)
            {
                Directory.CreateDirectory(Attach_Folder);
            }

            Search_Insert_Update_Delete("Search");

            DataTable dt = new DataTable();
            gvdetails.EmptyDataText = "";
            gvdetails.DataSource = dt;
            gvdetails.DataBind();

            if (txt_type.Text != "" || txt_frmdt.Text != "" || txt_todt.Text != "" || txt_Customhouse.Text != "")
            {
                ViewState["pageno"] = null;
                ViewState["pageno"] = "1";
            }
            else
            {
                ViewState["pageno"] = null;
            }
            btnSearch_Click(sender, e);

        }
        if (ddl_JobType.SelectedValue.ToString() == "All")
            mdb.TRANSPORT_MODE = "";
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
    public void view_control(string Jobtype)
    {
        ddl_JobType.Items.Clear();
        if (Jobtype == "Both")
        {
            gvdetails.Columns[4].Visible = true;
            gvdetails.Columns[5].Visible = true;
            gvdetails.Columns[6].Visible = true;
            gvdetails.Columns[7].Visible = true;
            gvdetails.Columns[9].Visible = true;
            gvdetails.Columns[10].Visible = true;
            gvdetails.Columns[11].Visible = true;
            gvdetails.Columns[12].Visible = true;
        }
        if (Jobtype == "Import")
        {
            mainmastop2container_rght_tag2_txt1.InnerText = "Import - Tracking";

            gvdetails.Columns[4].Visible = true;
            gvdetails.Columns[5].Visible = true;
            gvdetails.Columns[6].Visible = true;
            gvdetails.Columns[7].Visible = false;
            gvdetails.Columns[8].Visible = false;
            gvdetails.Columns[9].Visible = true;
            gvdetails.Columns[10].Visible = true;
            gvdetails.Columns[11].Visible = true;
            gvdetails.Columns[12].Visible = true;
            gvdetails.Columns[13].Visible = true;
            gvdetails.Columns[14].Visible = true;


        }
        if (Jobtype == "Export")
        {
            mainmastop2container_rght_tag2_txt1.InnerText = "Export - Tracking";

            gvdetails.Columns[3].Visible = true;
            gvdetails.Columns[4].Visible = false;
            gvdetails.Columns[5].Visible = false;
            gvdetails.Columns[6].Visible = true;
            gvdetails.Columns[7].Visible = true;
            gvdetails.Columns[8].Visible = true;
            gvdetails.Columns[9].Visible = true;
            gvdetails.Columns[10].Visible = true;
            gvdetails.Columns[11].Visible = true;
            gvdetails.Columns[12].Visible = true;
            gvdetails.Columns[13].Visible = true;
            gvdetails.Columns[14].Visible = true;
            gvdetails.ControlStyle.Width = 1100;

        }
        Load_Transport_mode();
    }
    public void view_control_new(string Jobtype)
    {
        if (txt_type.Text == "")
        {
            ddl_type.Items.Clear();
            ddl_type.Items.Add("Job No");

            if (Connection.COMPANYID() == "11" || Connection.COMPANYID() == "747")
            {
                gvdetails.Columns[0].Visible = false;
            }

            if (Jobtype == "Both")
            {
                ddl_type.Items.Add("BE No");
                ddl_type.Items.Add("SB No");

                gvdetails.Columns[4].Visible = true;
                gvdetails.Columns[5].Visible = true;
                gvdetails.Columns[6].Visible = false;
                gvdetails.Columns[7].Visible = false;
                gvdetails.Columns[9].Visible = true;
                gvdetails.Columns[10].Visible = true;
                gvdetails.Columns[11].Visible = true;

            }
            if (Jobtype == "Import")
            {
                ddl_type.Items.Remove("SB No");
                ddl_type.Items.Add("BE No");

                gvdetails.Columns[4].Visible = true;
                gvdetails.Columns[5].Visible = true; // be no
                gvdetails.Columns[6].Visible = true; // be date
                gvdetails.Columns[7].Visible = false; 
                gvdetails.Columns[8].Visible = false;
                gvdetails.Columns[9].Visible = true;
                gvdetails.Columns[10].Visible = true;
                gvdetails.Columns[11].Visible = true;
                gvdetails.Columns[12].Visible = true;
                gvdetails.Columns[13].Visible = true;
                gvdetails.Columns[14].Visible = true;

                ddl_Filetype.Items.Remove(".sb");

            }
            if (Jobtype == "Export")
            {
                ddl_type.Items.Remove("BE No");
                ddl_type.Items.Add("SB No");
                gvdetails.Columns[3].Visible = true;
                gvdetails.Columns[4].Visible = false; 
                gvdetails.Columns[5].Visible = false;
                gvdetails.Columns[6].Visible = true;
                gvdetails.Columns[7].Visible = true;
                gvdetails.Columns[8].Visible = true;
                gvdetails.Columns[9].Visible = true;
                gvdetails.Columns[10].Visible = true;
                gvdetails.Columns[11].Visible = true;
                gvdetails.Columns[12].Visible = true;
                gvdetails.Columns[13].Visible = true;
                gvdetails.Columns[14].Visible = true;
                gvdetails.ControlStyle.Width = 1100;

                ddl_Filetype.Items.Remove(".be");
            }
            ddl_type.Items.Add("Attachment");
        }
      
    }

    public void Load_Transport_mode()
    {
        ddl_JobType.Items.Add("All");
        ddl_JobType.Items.Add("Air");
        ddl_JobType.Items.Add("Sea");
        ddl_JobType.Items.Add("Land");
    }

    public DataSet Search_Insert_Update_Delete(string flag)
    {
        mdb.COMPANY_ID = Session["COMPANY_ID"].ToString();
        mdb.COMPANY_LIC_ID = Connection.Company_License();
        mdb.USER_CREATION_ID = Session["USER_CREATION_ID"].ToString();
        mdb.CUSTOM_HOUSE = Session["CUSTOMHOUSE_CODE"].ToString();
        mdb.IMAP_SERVER = "";
        mdb.SERVERTYPE = "IMAP";

        mdb.USER_NAME = "";
        mdb.PWD = "";
        mdb.FOLDER = "";
        mdb.PORT = "";
        mdb.Ename = flag;
        ds = mdb.MailSettting_INSERT_UPDATE_SEARCH_New();
        if (flag == "Search")
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_Imapserver.Value = ds.Tables[0].Rows[0]["HOST_NAME"].ToString();
                txt_username.Value = ds.Tables[0].Rows[0]["USER_NAME"].ToString();
                txt_pwd.Value = ds.Tables[0].Rows[0]["PWD"].ToString();
                txt_Folder.Value = ds.Tables[0].Rows[0]["FOLDER"].ToString();
                txt_port.Value = ds.Tables[0].Rows[0]["PORT"].ToString();
                txt_Customhouse_Id.Value = ds.Tables[0].Rows[0]["CUSTOM_HOUSE"].ToString();
                txt_Company_Id.Value = ds.Tables[0].Rows[0]["COMPANY_ID"].ToString();
            }
        }
        return ds;
    }

    protected void btn_CheckMail_Click(object sender, EventArgs e)
    {
        try
        {
            //Read_mail.Check_Mail_Search(txtSearch_Date.Text, "Imp_Exp_Mail");      
            RM.Check_Mail_Search(txtSearch_Date.Text, "Imp_Exp_Mail");      
                 
            btnSearch_Click(sender, e);
            Alert_msg("Mails Tracked Successfully");
        }
        catch (Exception ex)
        {
            Alert_msg(ex.Message);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (mdb.TRANSPORT_MODE != "" || ddl_type.SelectedValue.ToString() != "" || txt_type.Text != "" || txt_frmdt.Text != "" || txt_todt.Text != "" || txt_Customhouse.Text != "")
        {
            pageno = 100000001;
            ViewState["pageno"] = null;
            ViewState["pageno"] = "1";
        }
        else
        {
            ViewState["pageno"] = null;
            pageno = 100000000;
        }
        Add_Pageno_New(ii);
        gridbind(pageno);
        view_control_new(New_Jobtype);
    }

    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        txt_type.Text = "";
        txt_Customhouse.Text = "";
        btnSearch_Click(sender, e);
    }
    protected void btn_A_TO_Z_Search_Click(object sender, EventArgs e)
    {

    }

    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
        string a = gvdetails.DataKeys[gvrow.RowIndex].Value.ToString();
        string filePath = Attach_Folder + a;

        if (a.Substring(0, 5) == "CHCAE")
        {
            Response.ContentType = "Text/Plain";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");

            Response.TransmitFile(filePath);
            Response.End();
        }
        else
        {
            if (Path.GetExtension(a).ToLower() != ".pdf")
            {
                string url = "../Read_Mail/Import_FinalPrintOut_Rpt_viewer.aspx?jobno=" + a;
                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open('" + url + "' , null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
            }
            else if (Path.GetExtension(a).ToLower() == ".pdf")
            {
                System.IO.FileInfo file = new System.IO.FileInfo(Attach_Folder + a);
                Response.Clear();
                Response.ClearContent();
                Response.ContentType = "Application/pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + lnkbtn.Text);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.TransmitFile(file.FullName);
                Response.End();
            }
        }

        pageno = Convert.ToInt32(ddlSelectPageno.SelectedItem.Text);
        gridbind(pageno);

    }
    protected void lnkfileDownload_Click(object sender, EventArgs e)
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
        //   end
    }

    public static string MimeType(string Extension)
    {
        string mime = "application/octetstream";
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
            else if (ext == ".sb" || ext == ".be" || ext == ".SB" || ext == ".BE")
            {
                mime = "text/plain";
            }
            else
                mime = rk.GetValue("Content Type").ToString();
        }
        return mime;
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            string ext = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MailSubject"));
         

            ext = ext.Split('.')[1].ToLower();

            if (ext == "ack_" || ext == "ack")
            {
                e.Row.ForeColor = System.Drawing.Color.Green;
            }
            else if (ext == "nak")
            {
                e.Row.ForeColor = System.Drawing.Color.Red;
            }
            else if (ext == "prn")
            {
                e.Row.ForeColor = System.Drawing.Color.Blue;
            }
            else if (ext == "qry")
            {
                e.Row.ForeColor = System.Drawing.Color.White;
            }
            else if (ext == "pdf")
            {
                e.Row.ForeColor = System.Drawing.Color.Magenta;
            }

            CheckBox headerchk = (CheckBox)gvdetails.HeaderRow.FindControl("chkAll");
            CheckBox childchk = (CheckBox)e.Row.FindControl("chk");
            childchk.Attributes.Add("onclick", "javascript:Selectchildcheckboxes('" + headerchk.ClientID + "','gvdetails','btnDelete')");


            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (e.Row.Cells[6].Text.Length > 20)
                {
                    e.Row.Cells[6].ToolTip = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IMPORTER_NAME"));
                    e.Row.Cells[6].Text = e.Row.Cells[6].Text.Substring(0, 20) + "..";
                }

                LinkButton lk = e.Row.Cells[10].FindControl("lnkDownload") as LinkButton;
                 if (lk.Text.Length > 30)
                {
                    lk.ToolTip= Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MailSubject"));
                    lk.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MailSubject")).Substring(0, 30) + "..";
                }
                e.Row.Cells[i].Attributes.Add("style", "white-space:nowrap;");

            }

        }
    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    public void gridbind(int currentPageNumber1)
    {
        DataSet ds_empty = new DataSet();
        DataView dataView = new DataView();
        int ttl = 0;
        int c1 = currentPageNumber1;
        Session["title"] = null;

        if (New_Jobtype == "Both")
            mdb.JOB_TYPE = "";

        if (New_Jobtype == "Import")
            mdb.JOB_TYPE = "CHCAI";

        if (New_Jobtype == "Export")
            mdb.JOB_TYPE = "CHCAE";
        //-----------------------------------------------------------------//

        if (ddl_type.SelectedValue.ToString() == "Attachment")
        {
            mdb.ATTACHMENT = txt_type.Text;
            mdb.JOB_NO = "";
            mdb.BE_NO = "";
            mdb.SB_NO = "";
        }
        if (ddl_type.SelectedValue.ToString() == "Job No")
        {
            mdb.JOB_NO = txt_type.Text;
            mdb.ATTACHMENT = "";
            mdb.BE_NO = "";
            mdb.SB_NO = "";
        }
        if (ddl_type.SelectedValue.ToString() == "BE No")
        {
            mdb.BE_NO = txt_type.Text;
            mdb.ATTACHMENT = "";
            mdb.JOB_NO = "";
            mdb.SB_NO = "";
        }
        if (ddl_type.SelectedValue.ToString() == "SB No")
        {
            mdb.SB_NO = txt_type.Text;
            mdb.ATTACHMENT = "";
            mdb.JOB_NO = "";
            mdb.BE_NO = "";
        }
        mdb.CUSTOM_HOUSE = txt_Customhouse.Text;
        mdb.CUSTOM_HOUSE_ID = "";
        if (ddl_JobType.SelectedValue.ToString() == "All")
            mdb.TRANSPORT_MODE = "";
        else
        {
            mdb.TRANSPORT_MODE = ddl_JobType.SelectedValue.ToString();
        }

        mdb.COMPANY_ID = txt_Company_Id.Value;

        mdb.FROM_DATE = txt_frmdt.Text;
        mdb.TO_DATE = txt_todt.Text;
        mdb.Mode = "select_con";
        mdb.Emailid = "";
        mdb.BRANCH_CODE = SELECT_BRANCH;
        mdb.CLIENT_NAME = txt_ClientName.Text;
        mdb.FILE_TYPE = ddl_Filetype.SelectedItem.Text;
        gvdetails.EmptyDataText = "No Record Found";
        ds_empty = mdb.StoreMailContents_Grid_Search("select_con", New_Jobtype, SELECT_BRANCH);

        if (ds_empty.Tables[0].Rows.Count > 0)
        {
            var orderedRows = from row in ds_empty.Tables[0].AsEnumerable()
                              orderby row.Field<DateTime>("MailDate1") descending
                              select row;
            DataTable tblOrdered = orderedRows.CopyToDataTable();

            dataView = tblOrdered.DefaultView;

            DataTable dt_gvdetails = dataView.ToTable();

            DataView view = new DataView();
            DataTable d = new DataTable();
            int COUNT = view.Count;

            if (mdb.TRANSPORT_MODE != "")
            {
                if (txt_type.Text != "")
                {
                    if (mdb.BE_NO != "")
                    {
                        EnumerableRowCollection<DataRow> query = from order in dt_gvdetails.AsEnumerable()
                                                                 where order.Field<string>("BE_NO") == mdb.BE_NO
                                                                 && order.Field<string>("TRANSPORT_MODE") == mdb.TRANSPORT_MODE
                                                                 select order;
                        view = query.AsDataView();
                        d = view.ToTable();
                    }
                    if (mdb.JOB_NO != "")
                    {
                        EnumerableRowCollection<DataRow> query = from order in dt_gvdetails.AsEnumerable()
                                                                 where order.Field<string>("JOB_NO") == mdb.JOB_NO
                                                                 && order.Field<string>("TRANSPORT_MODE") == mdb.TRANSPORT_MODE
                                                                 select order;
                        view = query.AsDataView();
                        d = view.ToTable();
                    }
                    if (mdb.SB_NO != "")
                    {
                        EnumerableRowCollection<DataRow> query = from order in dt_gvdetails.AsEnumerable()
                                                                 where order.Field<string>("SB_NO") == mdb.SB_NO
                                                                 && order.Field<string>("TRANSPORT_MODE") == mdb.TRANSPORT_MODE
                                                                 select order;
                        view = query.AsDataView();
                        d = view.ToTable();
                    }
                    if (mdb.ATTACHMENT != "")
                    {
                        EnumerableRowCollection<DataRow> query = from order in dt_gvdetails.AsEnumerable()
                                                                 where order.Field<string>("MailSubject").Contains(mdb.ATTACHMENT)
                                                                 && order.Field<string>("TRANSPORT_MODE") == mdb.TRANSPORT_MODE
                                                                 select order;
                        view = query.AsDataView();
                        d = view.ToTable();
                    }
                }
                if (txt_Customhouse.Text != "")
                {
                    int count_d = d.Rows.Count;

                    if (count_d > 0)
                    {
                        EnumerableRowCollection<DataRow> query = from order in d.AsEnumerable()
                                                                 where order.Field<string>("CUSTOM_HOUSE_ID") == mdb.CUSTOM_HOUSE.ToUpper()
                                                                 && order.Field<string>("TRANSPORT_MODE") == mdb.TRANSPORT_MODE
                                                                 select order;
                        view = query.AsDataView();
                        d = view.ToTable();
                    }
                    else
                    {
                        EnumerableRowCollection<DataRow> query = from order in dt_gvdetails.AsEnumerable()
                                                                 where order.Field<string>("CUSTOM_HOUSE_ID") == mdb.CUSTOM_HOUSE.ToUpper()
                                                                 && order.Field<string>("TRANSPORT_MODE") == mdb.TRANSPORT_MODE
                                                                 select order;
                        view = query.AsDataView();
                        d = view.ToTable();
                    }
                }
                else
                {
                    int count_d = d.Rows.Count;

                    if (count_d > 0)
                    {
                        EnumerableRowCollection<DataRow> query = from order in d.AsEnumerable()
                                                                 where order.Field<string>("TRANSPORT_MODE") == mdb.TRANSPORT_MODE
                                                                 select order;
                        view = query.AsDataView();
                        d = view.ToTable();
                    }
                    else
                    {
                        EnumerableRowCollection<DataRow> query = from order in dt_gvdetails.AsEnumerable()
                                                                 where order.Field<string>("TRANSPORT_MODE") == mdb.TRANSPORT_MODE
                                                                 select order;
                        view = query.AsDataView();
                        d = view.ToTable();
                    }
                }
            }
            else
            {
                if (txt_type.Text != "")
                {
                    if (mdb.BE_NO != "")
                    {
                        EnumerableRowCollection<DataRow> query = from order in dt_gvdetails.AsEnumerable()
                                                                 where order.Field<string>("BE_NO") == mdb.BE_NO
                                                                 select order;
                        view = query.AsDataView();
                        d = view.ToTable();
                    }
                    if (mdb.JOB_NO != "")
                    {
                        EnumerableRowCollection<DataRow> query = from order in dt_gvdetails.AsEnumerable()
                                                                 where order.Field<string>("JOB_NO") == mdb.JOB_NO
                                                                 select order;
                        view = query.AsDataView();
                        d = view.ToTable();
                    }
                    if (mdb.SB_NO != "")
                    {
                        EnumerableRowCollection<DataRow> query = from order in dt_gvdetails.AsEnumerable()
                                                                 where order.Field<string>("SB_NO") == mdb.SB_NO
                                                                 select order;
                        view = query.AsDataView();
                        d = view.ToTable();
                    }
                    if (mdb.ATTACHMENT != "")
                    {
                        EnumerableRowCollection<DataRow> query = from order in dt_gvdetails.AsEnumerable()
                                                                 where order.Field<string>("MailSubject").Contains(mdb.ATTACHMENT)
                                                                 select order;
                        view = query.AsDataView();
                        d = view.ToTable();
                    }
                }
                if (txt_Customhouse.Text != "")
                {
                    int count_d = d.Rows.Count;

                    if (count_d > 0)
                    {
                        EnumerableRowCollection<DataRow> query = from order in d.AsEnumerable()
                                                                 where order.Field<string>("CUSTOM_HOUSE_ID") == mdb.CUSTOM_HOUSE.ToUpper()
                                                                 select order;
                        view = query.AsDataView();
                        d = view.ToTable();
                    }
                    else
                    {
                        EnumerableRowCollection<DataRow> query = from order in dt_gvdetails.AsEnumerable()
                                                                 where order.Field<string>("CUSTOM_HOUSE_ID") == mdb.CUSTOM_HOUSE.ToUpper()
                                                                 select order;
                        view = query.AsDataView();
                        d = view.ToTable();
                    }
                }
                else
                {
                    int count_d = d.Rows.Count;

                    if (count_d > 0)
                    {
                        EnumerableRowCollection<DataRow> query = from order in d.AsEnumerable()
                                                                 where order.Field<string>("TRANSPORT_MODE") != mdb.TRANSPORT_MODE
                                                                 select order;
                        view = query.AsDataView();
                        d = view.ToTable();
                    }
                    else
                    {
                        if (txt_type.Text == "")//31-12-2021 
                        {
                            
                            EnumerableRowCollection<DataRow> query = from order in dt_gvdetails.AsEnumerable()
                                                                     where order.Field<string>("TRANSPORT_MODE") != mdb.TRANSPORT_MODE
                                                                     select order;
                            view = query.AsDataView();
                            d = view.ToTable();
                            
                        }
                    }
                }
            }

            if (txt_frmdt.Text != "")
            {
                DateTime frm = Convert.ToDateTime(txt_frmdt.Text);
                DateTime to = Convert.ToDateTime(txt_todt.Text);

                d = FilterTable(d, frm, to);
            }

            COUNT = d.Rows.Count;
            DataView dvv = new DataView();

            int pageno_new = 1;

            if (xx == "first")
            {
                if (COUNT >= 20)
                {
                    pageno_new = 1;
                    xx = "";
                    Add_Pageno_New(COUNT);
                    pageno_new = Convert.ToInt32(ViewState["ddl_page_no"].ToString());

                }
                else
                {
                    Add_Pageno_New(COUNT);
                    pageno_new = Convert.ToInt32(ViewState["ddl_page_no"].ToString());
                }
            }
            else
            {
                pageno_new = Convert.ToInt32(ViewState["ddl_page_no"].ToString());
            }

            if (COUNT > 20)
            {
                if (pageno_new == 1)
                {
                    int numberOfObjectsPerPage = 20;
                    var queryResultPage = d.AsEnumerable()
                      .Skip(0)
                      .Take(numberOfObjectsPerPage);

                    d = queryResultPage.CopyToDataTable();
                    dvv = d.DefaultView;
                }
                else
                {
                    pageno_new = pageno_new - 1;

                    int numberOfObjectsPerPage = 20;
                    var queryResultPage = d.AsEnumerable()
                      .Skip(numberOfObjectsPerPage * pageno_new)
                      .Take(numberOfObjectsPerPage);

                    d = queryResultPage.CopyToDataTable();
                    dvv = d.DefaultView;
                }

            }
            else
            {
                dvv = d.DefaultView;
            }

            gvdetails.DataSource = dvv;
            gvdetails.DataBind();

            if (gvdetails.Rows.Count > 0)
            {
                Div_Pagination.Visible = true;
                div_pagination1.Visible = true;
            }
            else
            {
                Div_Pagination.Visible = false;
                div_pagination1.Visible = false;
            }

            if (pageno_new == 1)
            {
                lblCurrentPage.Text = "1";
                btnNext.Visible = false;
                btnLast.Visible = false;
                btnPrev.Visible = false;
                btnFirst.Visible = false;
            }
            else
            {
            }
        }
        else
        {
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();

        }
    }

    private DataTable FilterTable(DataTable table, DateTime startDate, DateTime endDate)
    {
        var filteredRows =
            from row in table.Rows.OfType<DataRow>()
            where (DateTime)row[3] >= startDate
            where (DateTime)row[3] <= endDate
            select row;

        DataTable filteredTable = table.Clone();

        filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));

        return filteredTable;
    }
    public DataSet GridView_Sorting(DataSet dtuser, string sort_ColumnName)
    {
        DataView dataView = new DataView(dtuser.Tables[0]);
        dataView.Sort = sort_ColumnName + " DESC";
        return dtuser;
    }

    private int CalculateTotalPages(double totalRows)
    {
        int totalPages = (int)Math.Ceiling(totalRows / gvdetails.PageSize);
        return totalPages;
    }

    protected void ChangePage(object sender, CommandEventArgs e)
    {
        int currentpagenumber2 = 0, h = 0, ii = 0;

        switch (e.CommandName)
        {
            case "Previous":
                currentpagenumber2 = Int32.Parse(lblCurrentPage.Text) - 1;
                lblCurrentPage.Text = Convert.ToString(currentpagenumber2);

                currentpagenumber2 = Math.Abs((currentpagenumber2 * gvdetails.PageSize) - Int32.Parse(lblTotalPages.Text));

                break;

            case "Next":
                if (ViewState["pageno"] == null)
                {
                    ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
                    lblCurrentPage.Text = Convert.ToString(Int32.Parse(lblCurrentPage.Text) + 1);
                    if (Int32.Parse(lblCurrentPage.Text) == ii)
                    {
                        lblCurrentPage.Text = Convert.ToString(Int32.Parse(lblCurrentPage.Text));
                        ii = Int32.Parse(lblTotalPages.Text) - ((Int32.Parse(lblCurrentPage.Text) - 1) * gvdetails.PageSize);
                        currentpagenumber2 = Math.Abs(ii);
                    }
                    else
                    {
                        currentpagenumber2 = Math.Abs((Int32.Parse(lblTotalPages.Text) - (gvdetails.PageSize * Int32.Parse(lblCurrentPage.Text))));
                    }
                }

                else
                {
                    ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
                    if (Int32.Parse(lblCurrentPage.Text) == ii)
                        currentpagenumber2 = ii;
                    else
                    {
                        currentpagenumber2 = Int32.Parse(lblCurrentPage.Text) + 1;
                        lblCurrentPage.Text = Convert.ToString(currentpagenumber2);
                        currentpagenumber2 = Math.Abs((Int32.Parse(lblTotalPages.Text) - (gvdetails.PageSize * Int32.Parse(lblCurrentPage.Text))));
                    }
                }

                break;
            case "First":

                if (ViewState["pageno"] == null)

                    currentpagenumber2 = 100000000;
                else
                    currentpagenumber2 = 100000001;
                break;
            case "Last":
                int i = CalculateTotalPages(double.Parse(lblTotalPages.Text));
                lblCurrentPage.Text = Convert.ToString(i);
                currentpagenumber2 = Math.Abs(Int32.Parse(lblTotalPages.Text) - ((i - 1) * gvdetails.PageSize));

                break;

        }

        gridbind(currentpagenumber2);
    }

    public void Add_Pageno(int p)
    {
        if (p != 0)
        {
            ddlSelectPageno.Items.Clear();
            for (int i = 1; i <= p; i++)
            {
                ddlSelectPageno.Items.Add(Convert.ToString(i));
            }
        }
    }

    public void Add_Pageno_New(int count)
    {
        if (xx == "first")
        {
            int one = 1;
            ddlSelectPageno.Items.Clear();
            ddlSelectPageno.Items.Add(Convert.ToString(one));
        }
        else
        {
            if (count >= 20)
            {
                ddlSelectPageno.Items.Clear();
                int cnt;
                decimal pp = Convert.ToDecimal(count) / 20;

                string d = Convert.ToString(pp);

                if (d.Contains('.'))
                {

                    string[] dd = d.Split('.');

                    if (dd[1] == "00")
                    {
                        cnt = Convert.ToInt32(dd[0]);
                    }
                    else
                    {
                        cnt = Convert.ToInt32(dd[0]);
                        cnt = cnt + 1;
                    }
                }
                else
                {
                    cnt = Convert.ToInt32(d);
                }

                int p = cnt;

                for (int i = 1; i <= p; i++)
                {
                    ddlSelectPageno.Items.Add(Convert.ToString(i));
                }
            }
            else
            {
                int one = 1;
                ddlSelectPageno.Items.Clear();
                ddlSelectPageno.Items.Add(Convert.ToString(one));
            }
        }
        ViewState["ddl_page_no"] = ddlSelectPageno.SelectedValue.ToString();
    }

    protected void ddlSelectPageno_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["last_click"] = null;
        lblCurrentPage.Text = ddlSelectPageno.SelectedValue.ToString();
        ViewState["ddl_page_no"] = lblCurrentPage.Text;
        xx = "";

        gridbind(Int32.Parse(ViewState["ddl_page_no"].ToString()));
    }

    public void Grid_Total(int currentPageNumber1, double totalRows)
    {
        if (gvdetails.Rows.Count > 0)
        {
            Div_Pagination.Visible = true;
            div_pagination1.Visible = true;
        }
        else if (gvdetails.Rows.Count == 0)
        {
            Div_Pagination.Visible = false;
            div_pagination1.Visible = false;
        }
        totalRows = (double)mdb.result;

        lblTotalPages.Text = Convert.ToString(totalRows);

        lblCurrentPage.Text = Convert.ToString(currentPageNumber1);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        if (currentPageNumber1 == 1)
        {
            btnPrev.Visible = false;

            if (Int32.Parse(lblTotalPages.Text) > 0)
            {
                btnNext.Visible = true;
                btnLast.Visible = true;
            }
            else
            {
                btnNext.Visible = false;
            }
        }
        else if (Int32.Parse(lblCurrentPage.Text) == ii)
        {
            btnNext.Visible = false;
            btnPrev.Visible = true;
        }
        else
        {
            btnPrev.Visible = true;

            if (currentPageNumber == Int32.Parse(lblTotalPages.Text))
                btnNext.Visible = false;
            else btnNext.Visible = true;
        }
    }

    protected void btnDelete_Click(object source, EventArgs e)
    {
        DataSet ds_del = new DataSet();
        mdb.Mode = "Delete";

        CheckBox chkAll = (CheckBox)gvdetails.HeaderRow.Cells[0].FindControl("chkAll");
        for (int i = 0; i < gvdetails.Rows.Count; i++)
        {
            if (chkAll.Checked)
            {
                CheckBox chk = (CheckBox)gvdetails.Rows[i].Cells[0].FindControl("chk");
                if (chk.Checked)
                {
                    mdb.COMPANY_ID = gvdetails.DataKeys[i].Values["id"].ToString();
                    mdb.Emailid = gvdetails.Rows[i].Cells[3].Text;
                    mdb.StoreMailContents(ds, mdb.Emailid, mdb.Mode, New_Jobtype, SELECT_BRANCH,"");
                }
            }
            else
            {
                CheckBox chk = (CheckBox)gvdetails.Rows[i].Cells[0].FindControl("chk");
                if (chk.Checked)
                {
                    mdb.COMPANY_ID = gvdetails.DataKeys[i].Values["id"].ToString();
                    mdb.Emailid = gvdetails.Rows[i].Cells[3].Text;

                    ds_del = mdb.StoreMailContents(ds, mdb.Emailid, "Delete_Folder", New_Jobtype, SELECT_BRANCH, HttpContext.Current.Session["currentcomp_db"].ToString());
                    string select_fileName = Attach_Folder + ds_del.Tables[0].Rows[0]["MailSubject"].ToString();

                    if (File.Exists(select_fileName))
                    {
                        File.Delete(select_fileName);
                    }
                    mdb.StoreMailContents(ds, mdb.Emailid, mdb.Mode, New_Jobtype, SELECT_BRANCH, HttpContext.Current.Session["currentcomp_db"].ToString());
                    
                }
            }
        }
      
        Alert_msg("Deleted");
        btnSearch_Click(source, e);
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'READ MAIL', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    
    [WebMethod]
    public static string Check_Mail(string mail)
    {
        return mail;
    }

    protected void btn_BE_SB_Mail_Click(object sender, EventArgs e)
    {

    }
}