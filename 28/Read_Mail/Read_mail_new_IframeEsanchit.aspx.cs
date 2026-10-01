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
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 25;
    SqlCommand com, cmd, cmd1;
    SqlDataReader dr, dr1;

    SqlDataAdapter da;
    DataTable dt;
    DataRow de;
    DataSet dtuser = new DataSet();
    eroyalmaster erm = new eroyalmaster();
    SqlConnection con;
    Manipulation mo;
    AppSession aps = new AppSession();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search, New_Jobtype;

    public string SELECT_TYPE, SELECT_BRANCH;

    int _startIndex = 0;
    int _thisPage = 1;
    int _pageSize = 10;
    int _totalNumberOfRows = 0;
    int[] f = new int[100];
    int[] l = new int[100];
    public string str, title, state, magimage, pagestr, startpage, comments, mm, lastpost, selqry, search_datewise, search_From_mailid, Attach_Folder;
    int i, j, ii, k, page, pageno, start, first, last, m, n, fir, la, kk, mmm, z, a, b, c, res;
    const int pageSize = 10;
    const int pageDispCount = 10;

    public char ch = Convert.ToChar(29);
    List<Maildb> lstMails = new List<Maildb>();
    Maildb mdb = new Maildb();
    string folderName2 = "";
    DataSet ds = new DataSet();
    DataSet dss = new DataSet();
    EnvironmentVariableTarget query;
    string xx = "first";
    Read_mail Rm = new Read_mail();

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


        SELECT_BRANCH = Connection.Get_Company_Type();
        SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();
        ////commented out this branch logic on 31/oct/23 - because Esanchit comes as common so for. 
        /*
        if (SELECT_TYPE == "Branchwise Job")
        {
            Attach_Folder = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() + "/" + "Attachments/");
        }
        else if (SELECT_TYPE == "Areawise Job")
        {
            Attach_Folder = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["GroupName"].ToString() + "/" + "Attachments/");
        }
        else
        {
            Attach_Folder = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + "Attachments/");
        }
        */
        //Attach_Folder = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + "Attachments/");
        string financialYear = GetFinancialYear();

         Attach_Folder = HttpContext.Current.Server.MapPath("~/Submission/" +financialYear + "/" + HttpContext.Current.Session["COMPANY_ID"].ToString() +"/Attachments/");

        //mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;
       // HDBranch.Value = Connection.Get_Company_Type();
       
        Div_Pagination.Visible = false;
        div_pagination1.Visible = false;

        if (!string.IsNullOrEmpty(Session["JOBTYPE_new"].ToString()))
        {
            New_Jobtype = Session["JOBTYPE_new"].ToString();
        }

        if (!IsPostBack)
        {
            //if (!string.IsNullOrEmpty(Session["JOBTYPE_new"].ToString()))
            //{
            //New_Jobtype = Session["JOBTYPE_new"].ToString();
            view_control(New_Jobtype);
            //}

            if (Directory.Exists(Attach_Folder) == false)
            {
                Directory.CreateDirectory(Attach_Folder);
            }

           // Search_Insert_Update_Delete("Search");

            DataTable dt = new DataTable();
            gvdetails.EmptyDataText = "";
            gvdetails.DataSource = dt;
            gvdetails.DataBind();

            if (txt_frmdt.Text != "" || txt_todt.Text != "" || txt_Irnno.Text != "")
            {
                ViewState["pageno"] = null;
                ViewState["pageno"] = "1";
            }
            //set if textbox !=null after textbox clear

            else
            {
                ViewState["pageno"] = null;
            }
            btnSearch_Click(sender, e);

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
    public void view_control(string Jobtype)
    { 
            mainmastop2container_rght_tag2_txt1.InnerText = Jobtype; 
    }
    public void view_control_new(string Jobtype)
    {
        if (Connection.COMPANYID() == "11" || Connection.COMPANYID() == "747")
        {
            //gvdetails.FindControl("chkAll").Visible = false;
            gvdetails.Columns[0].Visible = false;
        }
 
        if (Jobtype == "Import-Esanchit")
        {
            mainmastop2container_rght_tag2_txt1.InnerText = "Import-Esanchit Tracking";

        }
        if (Jobtype == "Export-Esanchit")
        {
            mainmastop2container_rght_tag2_txt1.InnerText = "Export-Esanchit Tracking";          
        }

    }
    protected void btn_CheckMail_Click(object sender, EventArgs e)
    {
        Rm.Check_Mail_Search(txtSearch_Date.Text, "Esanchit");

        btnSearch_Click(sender, e);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        
        if (mdb.TRANSPORT_MODE != "" || txt_frmdt.Text != "" || txt_todt.Text != "" || txt_Irnno.Text != "")
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
        if (txt_frmdt.Text != "" || txt_todt.Text != "" || txt_Irnno.Text != "" || txt_Drnno.Text != "" || txt_Docname.Text != "")
        {
            Load_Search();
        }
        else
        {
            gridbind(pageno);
        }
      
        view_control_new(New_Jobtype);
    }

    protected void btnSearchAll_Click(object sender, EventArgs e)
    {

        txt_Irnno.Text = "";
        Name_Search = "";
        btnSearch_Click(sender, e);
    }

    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;

        string fileName = gvdetails.DataKeys[gvrow.RowIndex].Value.ToString();
        string fullPath = Path.Combine(Attach_Folder, fileName);

        if (!File.Exists(fullPath))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "msg",
                "alert('File not found.\\n\\n" + fullPath.Replace("\\", "\\\\") + "');", true);
            return;
        }

        if (fileName.Substring(0, 5) == "CHCAE")
        {
            Response.Clear();
            Response.ContentType = "text/plain";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + Path.GetFileName(fullPath));
            Response.TransmitFile(fullPath);
            Response.End();
        }
        else
        {
            if (Path.GetExtension(fileName).ToLower() != ".pdf")
            {
                string url = "../Read_Mail/Import_FinalPrintOut_Rpt_viewer.aspx?frompage=Esanchit&jobno=" + fileName;

                ScriptManager.RegisterStartupScript(
                    this,
                    typeof(string),
                    "OPEN_WINDOW",
                    "var Mleft=(screen.width/2)-(760/2);var Mtop=(screen.height/2)-(700/2);window.open('" + url + "',null,'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top='+Mtop+',left='+Mleft);",
                    true);
            }
            else
            {
                FileInfo file = new FileInfo(fullPath);

                Response.Clear();
                Response.ClearContent();
                Response.ContentType = "application/pdf";
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

        string fileName = gvdetails.DataKeys[gvrow.RowIndex].Value.ToString();

        if (string.IsNullOrWhiteSpace(lnkbtn.Text) || lnkbtn.Text == "&nbsp;")
            return;

        string fullPath = Path.Combine(Attach_Folder, fileName);

        if (!File.Exists(fullPath))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "msg",
                "alert('File not found.\\n\\n" + fullPath.Replace("\\", "\\\\") + "');", true);
            return;
        }

        FileInfo file = new FileInfo(fullPath);

        string ext = Path.GetExtension(file.Name).ToLower();

        Response.Clear();
        Response.ClearContent();

        if (ext.Contains(".dms"))
            Response.ContentType = "text/plain";
        else
            Response.ContentType = MimeType(ext);

        Response.AddHeader("Content-Disposition", "attachment;filename=" + lnkbtn.Text);
        Response.AddHeader("Content-Length", file.Length.ToString());

        Response.TransmitFile(file.FullName);
        Response.End();
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
            if (ext == ".dms" || ext == ".dms_")
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

            if (ext == "dms_" || ext == "dms")
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
                LinkButton lk = e.Row.Cells[10].FindControl("lnkDownload") as LinkButton;
                if (lk.Text.Length > 30)
                {
                    lk.ToolTip = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MailSubject"));
                    lk.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MailSubject")).Substring(0, 30) + "..";
                }
                e.Row.Cells[i].Attributes.Add("style", "white-space:nowrap;");

            }

        }
    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
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

    private void Load_Search()
    {
        try
        {
          
            if (txt_frmdt.Text != string.Empty || txt_todt.Text != string.Empty)
            {
                mdb.FROM_DATE = txt_frmdt.Text;
                mdb.TO_DATE = txt_todt.Text;
            }
            else
            {
                mdb.FROM_DATE = txt_frmdt.Text;
                mdb.TO_DATE = txt_todt.Text;
            }
                mdb.IRN_no = txt_Irnno.Text;
                mdb.DRN_no = txt_Drnno.Text;
                mdb.Doc_Name = txt_Docname.Text;
               
            ds = mdb.Esanchit_Filter_Search();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvdetails.DataSource = ds.Tables[0];
                gvdetails.DataBind();

            }
            else
            {
                Grid_Empty();
            }
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void Grid_Empty()
    {
        DataTable dt = new DataTable();
        gvdetails.DataSource = dt;
        gvdetails.DataBind();
    }

    public void gridbind(int currentPageNumber1)
    {
        DataSet ds_empty = new DataSet();
        DataView dataView = new DataView();
        int ttl = 0;
        int c1 = currentPageNumber1;
        Session["title"] = null;

        //-----------------------------------------------------------------//

        mdb.JOB_TYPE = New_Jobtype;
        mdb.IRN_no = txt_Irnno.Text;
        mdb.CUSTOM_HOUSE_ID = "";
        mdb.COMPANY_ID = "";
        mdb.FROM_DATE = txt_frmdt.Text;
        mdb.TO_DATE = txt_todt.Text;
        mdb.Mode = "select_con";
        mdb.Emailid = "";
        mdb.BRANCH_CODE = SELECT_BRANCH;

        gvdetails.EmptyDataText = "No Record Found";

        ds_empty = mdb.Esanchit_StoreMailContents(ds_empty, "", "select_con", mdb.JOB_TYPE, SELECT_BRANCH, HttpContext.Current.Session["currentcomp_db"].ToString()); 
        
        int COUNT = ds_empty.Tables[0].Rows.Count;
           

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
                    //pageno_new = 1;
                    Add_Pageno_New(COUNT);
                    pageno_new = Convert.ToInt32(ViewState["ddl_page_no"].ToString());
                }

            }
            else
            {
                pageno_new = Convert.ToInt32(ViewState["ddl_page_no"].ToString());
            }


            //gvdetails.DataSource = ds_empty;
            //gvdetails.DataBind();

            //if (gvdetails.Rows.Count > 0)
            //{
            //    Div_Pagination.Visible = true;
            //    div_pagination1.Visible = true;
            //}
            //else
            //{
            //    Div_Pagination.Visible = false;
            //    div_pagination1.Visible = false;
            //}

            //if (pageno_new == 1)
            //{
            //    lblCurrentPage.Text = "1";
            //    btnNext.Visible = false;
            //    btnLast.Visible = false;
            //    btnPrev.Visible = false;
            //    btnFirst.Visible = false;
            //}
            //else
            //{

            //}

            DataTable d = new DataTable();
            DataView dvv = new DataView();
            d = ds_empty.Tables[0];
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

            //if (dvv.Count > 0)
            //{
            //    dvv.Sort = "MailDate DESC";
            //}
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
                //btnPrev.Visible = true;
                //btnLast.Visible = true;
                //if (currentPageNumber == Int32.Parse(lblTotalPages.Text))
                //    btnNext.Visible = false;
                //else btnNext.Visible = true;
            }

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
        // get the total rows
        totalRows = (double)mdb.result;

        //lblTotalPages.Text = CalculateTotalPages(totalRows).ToString();
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
                //btnLast.Visible = true;
            }
        }
        else if (Int32.Parse(lblCurrentPage.Text) == ii)
        {
            btnNext.Visible = false;
            //btnLast.Visible = false;
            btnPrev.Visible = true;
        }
        else
        {
            btnPrev.Visible = true;
            //btnLast.Visible = true;

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
                    mdb.COMPANY_ID = gvdetails.DataKeys[i].Values["ESID"].ToString();
                    mdb.Emailid = gvdetails.Rows[i].Cells[3].Text;
                    mdb.StoreMailContents(ds, mdb.Emailid, mdb.Mode, New_Jobtype, SELECT_BRANCH, HttpContext.Current.Session["currentcomp_db"].ToString());
                }
            }
            else
            {
                CheckBox chk = (CheckBox)gvdetails.Rows[i].Cells[0].FindControl("chk");
                if (chk.Checked)
                {
                    mdb.COMPANY_ID = gvdetails.DataKeys[i].Values["ESID"].ToString();
                    mdb.Emailid = gvdetails.Rows[i].Cells[3].Text;

                    // to Delete Files From Folder
                    ds_del = mdb.Esanchit_StoreMailContents(ds, mdb.Emailid, "Delete_Folder", New_Jobtype, SELECT_BRANCH, HttpContext.Current.Session["currentcomp_db"].ToString());
                    string select_fileName = Attach_Folder + ds_del.Tables[0].Rows[0]["MailSubject"].ToString();

                    if (File.Exists(select_fileName))
                    {
                        File.Delete(select_fileName);
                    }
                    mdb.Esanchit_StoreMailContents(ds, mdb.Emailid, mdb.Mode, New_Jobtype, SELECT_BRANCH, HttpContext.Current.Session["currentcomp_db"].ToString());
                }
            }
        }
        //if (mdb.result == 1)
        //{
            Alert_msg("Deleted");
            btnSearch_Click(source, e);
        //}
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'READ MAIL', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    //[System.Web.Services.WebMethod]
    [WebMethod]
    public static string Check_Mail(string mail)
    {

        return mail;
    }
    
}
 