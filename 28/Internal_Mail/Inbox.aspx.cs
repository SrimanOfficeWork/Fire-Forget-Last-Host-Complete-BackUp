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


public partial class Import_Ex_Bond : ThemeClass
{
   
    DataTable dt = new DataTable();
    DataSet dtuser = new DataSet();
    DataSet dss = new DataSet();
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 25;
    AppSession aps = new AppSession();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
    int _startIndex = 0;
    int _thisPage = 1;
    int _pageSize = 10;
    int _totalNumberOfRows = 0;
    int i, j, ii, k, page, pageno, start, first, last, m, n, fir, la, kk, mmm, z, a, b, c, res;
    const int pageSize = 10;
    const int pageDispCount = 10;
    string read, unread, move, delete,val,flag;
    Internal_Mail mail = new Internal_Mail();
    GridView gvSelected = new GridView();
    string tab = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        //mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;
        
        if (!IsPostBack)
        {
            Div_Pagination.Visible = false;
            div_pagination1.Visible = false;
            DataTable dt = new DataTable();
            gvdetails.EmptyDataText = "";
            gvdetails.DataSource = dt;
            gvdetails.DataBind();

            if (Request.QueryString["mail"] != "" && Request.QueryString["mail"] != null)
            {

                string val = Request.QueryString["mail"];
                hdn_mail.Value = val;
                Session.Remove("mail");
                Session["mail"] = val;

                if (val == "INBOX")
                {
                    ListBox1.Items.Add("Personal");
                    btnread.Style.Add("display", "block");
                    btnunread.Style.Add("display", "block");
                    gvdetails.Columns[2].Visible = true;
                    gvdetails.Columns[3].Visible = false;
                }
                else if (val == "SENT")
                {

                    ListBox1.Items.Add("Inbox");
                    ListBox1.Items.Add("Personal");
                    btnread.Style.Add("display", "none");
                    btnunread.Style.Add("display", "none");
                    gvdetails.Columns[2].Visible = false;
                    gvdetails.Columns[3].Visible = true;

                }
                else if (val == "TRASH")
                {

                    ListBox1.Items.Add("Inbox");
                    ListBox1.Items.Add("Personal");
                    btnread.Style.Add("display", "none");
                    btnunread.Style.Add("display", "none");
                    gvdetails.Columns[2].Visible = true;
                    gvdetails.Columns[3].Visible = false;
                }
                else if (val == "FOLDER")
                {
                    ListBox1.Items.Add("Inbox");
                    btnread.Style.Add("display", "none");
                    btnunread.Style.Add("display", "none");
                    gvdetails.Columns[2].Visible = true;
                    gvdetails.Columns[3].Visible = false;
                }

            }



            //set if textbox !=null after textbox clear
            if (txt_From_Address.Text != "" || txt_frmdt.Text != "" || txt_todt.Text != "")
            {

                ViewState["pageno"] = null;
                ViewState["pageno"] = "1";
            }
            //set if textbox !=null after textbox clear

            else
            {
                ViewState["pageno"] = null;

            }
            //hdn_A_to_Z_Search.Value = "";
            hdn_read.Value = "select_all";
            flag = hdn_read.Value;
            btnSearch_Click(sender, e);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        hdn_read.Value = "select_all";
        flag = hdn_read.Value;
        read = "";
        Search();
        
    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        txt_frmdt.Text = "";
        txt_todt.Text = "";
        txt_From_Address.Text = "";
        
        txt_todt.Text = "";
        //txtTransport_Mode.Text = "";
        Name_Search = "";
        hdn_read.Value = "select_all";
        flag = hdn_read.Value;
        btnSearch_Click(sender, e);
    }
    protected void btn_A_TO_Z_Search_Click(object sender, EventArgs e)
    {

       
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string val="",values="",values1="";
            values = this.gvdetails.DataKeys[e.Row.RowIndex]["INBOX_ID"].ToString();
            values1 = this.gvdetails.DataKeys[e.Row.RowIndex]["REFERENCE_ID"].ToString();

            LinkButton lnkbtn_edit_from = (LinkButton)((e.Row.FindControl("lnkbtn_edit_from")));
            LinkButton lnkbtn_edit_subject = (LinkButton)((e.Row.FindControl("lnkbtn_edit_subject")));
            LinkButton lnkbtn_edit_sent = (LinkButton)((e.Row.FindControl("lnkbtn_edit_sent")));

            lnkbtn_edit_from.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            lnkbtn_edit_subject.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            lnkbtn_edit_sent.Attributes["onmouseover"] = "this.style.cursor='pointer';";

            lnkbtn_edit_from.Attributes.Add("onclick", "open_inbox('" + values + "','" + values1 + "','" + val + "');");
            lnkbtn_edit_subject.Attributes.Add("onclick", "open_inbox('" + values + "','" + values1 + "','" + val + "');");
            lnkbtn_edit_sent.Attributes.Add("onclick", "open_inbox('" + values + "','" + values1 + "','" + val + "');");
            //e.Row.Attributes.Add("onclick", "opencomposemsg_update('" + values + "')");

            if (Request.QueryString["mail"] != "" && Request.QueryString["mail"] != null)
            {
                 val= Request.QueryString["mail"];
            }
          
            string ext = this.gvdetails.DataKeys[e.Row.RowIndex]["READ_STATUS"].ToString();
           
            if (ext == "True")
            {
                e.Row.ForeColor = System.Drawing.Color.Green;
            }

            string str = this.gvdetails.DataKeys[e.Row.RowIndex]["TO_ADDRESS"].ToString();
            //string str1 = this.gvdetails.DataKeys[e.Row.RowIndex]["USER_NAME"].ToString();
            string[] s1 = str.Split(new string[] { "~~" }, StringSplitOptions.None);
            //e.Row.Cells[3].Text = s1[0].ToString() + "," + s1[1].ToString()+"("+s1.Count()+")";
            LinkButton lb = new LinkButton();
            if(str.Contains("~~"))
            {
                if(txt_From_Address.Text!="")
                    lnkbtn_edit_sent.Text = txt_From_Address.Text + "," + s1[1].ToString() + "(" + s1.Count() + ")";
                else
                    lnkbtn_edit_sent.Text = s1[0].ToString() + "," + s1[1].ToString() + "(" + s1.Count() + ")";

            }
            else
            {
                lnkbtn_edit_sent.Text = s1[0].ToString();
            }
            
            lnkbtn_edit_sent.CommandName = "ApproveVacation";
            lnkbtn_edit_sent.Attributes.Add("onclick", "open_inbox('" + values + "','" + values1 + "','" + val + "');");
            //lb.Command += LinkButton_Command;
            //e.Row.Cells[3].Controls.Add(lnkbtn_edit_sent);

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

    public void gridbind(int currentPageNumber1)
    {
        //if (txt_From_Address.Text != "")
        //    mail.FROM_ADD = txt_From_Address.Text;
        //else
        //{
        //    mail.FROM_ADD = currentuser;

        //}
        //mail.USER_CREATION_ID = Session["USER_CREATION_ID"].ToString();
        mail.USER_CREATION_ID = "";
        if (txt_From_Address.Text != "")
        {
            mail.FROM_ADD = txt_From_Address.Text;
            mail.TO_ADD = currentuser;
            flag = "select_fromaddress";
        }

        else
        {
            mail.FROM_ADD = "";
            mail.TO_ADD = currentuser;

        }
        int ttl = 0;
        int c1 = currentPageNumber1;
        //mail.JOBID = "0";
        mail.FROM_DATE = txt_frmdt.Text;
        //mail.IMPORTER_NAME = Name_Search;
        mail.TO_DATE = txt_todt.Text;
        //mail.FROM_ADD = "";
        //mail.SENT = "";
        //mail.TRASH = "";
        //mail.FOLDER = "";
        //mail.INBOX = "Yes";
        mail.INBOX_ID = "";
        mail.READ_STATUS = read;
        mail.DELETE_STATUS = "";
        mail.REFERENCE_ID = "";
        
        mail.flag = flag;
        
        mail.WORKING_PERIOD = Working_Period;
        //if textbox !=null working

        if (Request.QueryString["mail"] != "" && Request.QueryString["mail"] != null)
        {
            string val = Request.QueryString["mail"];
            if (txt_From_Address.Text == "")
            {

                if (val == "INBOX")
                {
                    mail.USER_CREATION_ID = "";
                    mail.SENT = "";
                    mail.TRASH = "";
                    mail.FOLDER = "";
                    mail.INBOX = "Yes";

                }
                else if (val == "SENT")
                {
                    mail.SENT = "Yes";
                    mail.TRASH = "";
                    mail.FOLDER = "";
                    mail.INBOX = "";
                }
                else if (val == "TRASH")
                {
                    mail.SENT = "";
                    mail.TRASH = "Yes";
                    mail.FOLDER = "";
                    mail.INBOX = "";
                }
                else if (val == "FOLDER")
                {
                    mail.SENT = "";
                    mail.TRASH = "";
                    mail.FOLDER = "Yes";
                    mail.INBOX = "";
                }
            }
            else
            {
                if (val == "INBOX")
                {
                    mail.SENT = "";
                    mail.TRASH = "";
                    mail.FOLDER = "";
                    mail.INBOX = "Yes";
                }
                else if (val == "SENT")
                {
                    mail.SENT = "";
                    mail.TRASH = "";
                    mail.FOLDER = "";
                    mail.INBOX = "Yes";
                    if (txt_From_Address.Text != "")
                    {
                        mail.TO_ADD = txt_From_Address.Text;
                        mail.FROM_ADD = currentuser;
                        flag = "select_fromaddress";
                    }

                    else
                    {
                        mail.TO_ADD = "";
                        mail.FROM_ADD = currentuser;

                    }
                }
                else if (val == "TRASH")
                {
                    mail.SENT = "";
                    mail.TRASH = "Yes";
                    mail.FOLDER = "";
                    mail.INBOX = "";
                }
                else if (val == "FOLDER")
                {
                    mail.SENT = "";
                    mail.TRASH = "";
                    mail.FOLDER = "Yes";
                    mail.INBOX = "";
                }
            }
        }

        if (currentPageNumber1 == 100000000 || currentPageNumber1 == 100000001)
        {
            mail.startRowIndex = Convert.ToString(currentPageNumber1);

            mail.maximumRows = Convert.ToString(gvdetails.PageSize);
            lblCurrentPage.Text = "1";
        }
        //if textbox !=null working

        //if textbox =null working

        else
        {
            ttl = CalculateTotalPages(double.Parse(lblTotalPages.Text));

            if (Int32.Parse(lblCurrentPage.Text) == ttl)
            {
                mail.startRowIndex = "1";
                mail.maximumRows = Convert.ToString(currentPageNumber1);
            }

            else
            {
                mail.startRowIndex = Convert.ToString(currentPageNumber1 + 1);
                mail.maximumRows = Convert.ToString(gvdetails.PageSize);
            }

        }
        gvdetails.EmptyDataText = "No Record Found";


        DataView dataView = new DataView(mail.GetMail());
        if (dataView.Count > 0)
        {
            if (ViewState["pageno"] == null)
            {
                dataView.Sort = "RECEIVED_DATE DESC";
                ViewState["pageno"] = null;
            }

            else
            {
                dataView.Sort = "RECEIVED_DATE ASC";

            }
        }
        gvdetails.DataSource = dataView;
        gvdetails.DataBind();
        // }
        //gvdetails.DataSource = mail.RetrieveAll_General_Details();

        //gvdetails.DataBind();

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
        // get the total rows
        //totalRows = (double)mail.result;
        totalRows = (double)mail.totalrows;

        lblTotalPages.Text = Convert.ToString(totalRows);


        //if page no = 1 working
        if (CalculateTotalPages(double.Parse(lblTotalPages.Text)) == 1)
        {
            lblCurrentPage.Text = "1";
            btnNext.Visible = false;
            btnLast.Visible = false;
            btnPrev.Visible = false;
            btnFirst.Visible = false;
        }
        //if page no = 1 working

        else
        {
            btnFirst.Visible = true;

            if (Int32.Parse(lblCurrentPage.Text) == 1 || currentPageNumber1 == 100000000 || currentPageNumber1 == 100000001 || currentPageNumber1 == 15)
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


            else if (Int32.Parse(lblCurrentPage.Text) == CalculateTotalPages(double.Parse(lblTotalPages.Text)))
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
        //BindData(currentpagenumber2);
        //General_GridBind(currentpagenumber2);
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
    protected void ddlSelectPageno_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["last_click"] = null;
        lblCurrentPage.Text = ddlSelectPageno.SelectedValue.ToString();
        int i = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        if (ddlSelectPageno.SelectedValue != "")
        {
            string val = "";
            if (ddlSelectPageno.SelectedValue == "1")
            {

                val = "100000000";
                gridbind(Int32.Parse(val));


            }

            else if (Int32.Parse(ddlSelectPageno.SelectedValue) == i)
            {
                lblCurrentPage.Text = ddlSelectPageno.SelectedValue.ToString();
                gridbind(Math.Abs(Int32.Parse(lblTotalPages.Text) - ((Int32.Parse(ddlSelectPageno.SelectedValue) - 1) * gvdetails.PageSize)));

            }

            else
            {

                gridbind(Math.Abs((Int32.Parse(ddlSelectPageno.SelectedValue.ToString()) * gvdetails.PageSize) - Int32.Parse(lblTotalPages.Text)));

            }

        }
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
        totalRows = (double)mail.result;

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


    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
    protected void btnread_Click(object sender, EventArgs e)
    {
        hdn_read.Value = "select_con";
        flag = hdn_read.Value;
        read = "1";
        Search();
    }
    protected void btnunread_Click(object sender, EventArgs e)
    {
        hdn_read.Value = "select_con";
        flag = hdn_read.Value;
        read = "0";
        Search();
    }
    protected void btnmove_Click(object sender, EventArgs e)
    {
        read = "";
        mail.TO_ADD = "";
        mail.FROM_DATE = "";
        mail.TO_DATE = "";
        mail.FROM_ADD = "";
      
        mail.READ_STATUS = read;
        mail.DELETE_STATUS = "";

        mail.WORKING_PERIOD = Working_Period;
        string tab = "";

        if (Request.QueryString["mail"] != "" && Request.QueryString["mail"] != null)
        {
            string val = Request.QueryString["mail"];
            
            if (val == "INBOX")
            {
                mail.SENT = "";
                mail.TRASH = "";
                mail.FOLDER = "Yes";
                mail.INBOX = "No";
                mail.flag = "MOVE_TO_FOLDER";
                tab = "Inbox_tab";
            }
            else if (val == "SENT")
            {
                mail.SENT = "No";
                mail.TRASH = "";
                mail.FOLDER = "";
                mail.INBOX = "Yes";
                mail.flag = "MOVE_TO_INBOX";
                tab = "Sent_tab";


            }
            else if (val == "TRASH")
            {
                mail.SENT = "No";
                mail.TRASH = "No";
                mail.FOLDER = "";
                mail.INBOX = "Yes";
                mail.flag = "MOVE_TO_INBOX";
                tab = "Trash_tab";

            }
            else if (val == "FOLDER")
            {
                mail.SENT = "";
                mail.TRASH = "";
                mail.FOLDER = "Yes";
                mail.INBOX = "";
                tab = "Personal_tab";

            }

        }
        if (gvdetails.Rows.Count > 0)
        {
            CheckBox chkAll = (CheckBox)gvdetails.HeaderRow.Cells[0].FindControl("chkAll");

            for (int j = 0; j < gvdetails.Rows.Count; j++)
            {
                if (chkAll.Checked)
                {
                    mail.INBOX_ID = gvdetails.DataKeys[j].Values["INBOX_ID"].ToString();
                    mail.REFERENCE_ID = gvdetails.DataKeys[j].Values["REFERENCE_ID"].ToString();

                    mail.INBOX = gvdetails.Rows[j].Cells[0].Text;
                    mail.FOLDER = gvdetails.Rows[j].Cells[0].Text;
                    mail.GetMail();
                }
                else
                {
                    CheckBox chk = (CheckBox)gvdetails.Rows[i].Cells[0].FindControl("chk");
                    if (chk.Checked)
                    {
                        mail.INBOX_ID = gvdetails.DataKeys[j].Values["INBOX_ID"].ToString();
                        mail.REFERENCE_ID = gvdetails.DataKeys[j].Values["REFERENCE_ID"].ToString();

                        mail.INBOX = gvdetails.Rows[j].Cells[0].Text;
                        mail.FOLDER = gvdetails.Rows[j].Cells[0].Text;
                        mail.GetMail();
                    }
                    else
                    {

                    }
                }
                           

            }

           
            if (mail.result == 1)
            {
                //Alert_msg("Saved Successfully");
                string prompt = "<script>$(document).ready(function(){{window.parent.document.getElementById('" + tab + "').click();}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
            else
            {
              

            }
            

        }
        else
        {
            //Alert_msg("No Data Found");

        }
        
        
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        Delete();
    }
    public void Search()
    {
        //set page 1 button click  
        if (txt_From_Address.Text != "" || txt_frmdt.Text != "" || txt_todt.Text != "")
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
        //set page 1 button click  


        gridbind(pageno);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        Add_Pageno(ii);
    }
   
   
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'MAIL', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'MAIL', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Move();
    }
    public void Move()
    {
       
        read = "";
        mail.TO_ADD = "";
        mail.FROM_DATE = "";
        mail.TO_DATE = "";
        mail.FROM_ADD = "";

        mail.READ_STATUS = read;
        mail.DELETE_STATUS = "";

        mail.WORKING_PERIOD = Working_Period;


        if (Request.QueryString["mail"] != "" && Request.QueryString["mail"] != null)
        {
            string val = Request.QueryString["mail"];
            if (val == "INBOX")
            {
                mail.SENT = "";
                mail.TRASH = "";
                mail.FOLDER = "Yes";
                mail.INBOX = "No";
                mail.flag = "MOVE_TO_FOLDER";
                tab = "Inbox_tab";

            }
            else if (val == "SENT")
            {
                
                mail.FOLDER = "";

                if (ListBox1.SelectedValue.ToString() == "Inbox")
                {
                    mail.INBOX = "Yes";
                    mail.SENT = "No";
                    mail.flag = "MOVE_FROM_SENT_TO_INBOX";
                }
                if (ListBox1.SelectedValue.ToString() == "Personal")
                {
                    mail.FOLDER = "Yes";
                    mail.SENT = "No";
                    mail.flag = "MOVE_FROM_SENT_TO_FOLDER";
                }
                tab = "Sent_tab";

            }
            else if (val == "TRASH")
            {
                
                
                mail.FOLDER = "";
                
                if (ListBox1.SelectedValue.ToString() == "Inbox")
                {
                    mail.INBOX = "Yes";
                    mail.TRASH = "No";
                    mail.flag = "MOVE_FROM_TRASH_TO_INBOX";
                }
                if (ListBox1.SelectedValue.ToString() == "Personal")
                {
                    mail.FOLDER = "Yes";
                    mail.TRASH = "No";
                    mail.flag = "MOVE_FROM_TRASH_TO_FOLDER";
                }
                tab = "Trash_tab";

            }
            else if (val == "FOLDER")
            {
               
                if (ListBox1.SelectedValue.ToString() == "Inbox")
                {
                    mail.INBOX = "Yes";
                    mail.FOLDER = "No";
                    mail.flag = "MOVE_FROM_FOLDER_TO_INBOX";
                    tab = "Personal_tab";

                }
            }

        }
         CheckBox chkAll = (CheckBox)gvdetails.HeaderRow.Cells[0].FindControl("chkAll");
         for (int i = 0; i < gvdetails.Rows.Count; i++)
         {

             CheckBox chk = (CheckBox)gvdetails.Rows[i].Cells[0].FindControl("chk");
             if (chk.Checked)
             {

                 mail.INBOX_ID = gvdetails.DataKeys[j].Values["INBOX_ID"].ToString();
                 mail.REFERENCE_ID = gvdetails.DataKeys[j].Values["REFERENCE_ID"].ToString();

                 mail.GetMail();


                 if (mail.result == 1)
                 {
                     //Alert_msg("Saved Successfully");
                     //string prompt = "<script>$(document).ready(function(){{window.parent.document.getElementById('" + tab + "').click();}});</script>";
                     string prompt = "<script>$(document).ready(function(){{jAlert('Moved', 'MAIL', function (r) {window.parent.document.getElementById('" + tab + "').click();});}});</script>";
        
                     ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
                 }
             }
         }
    }

    public void Delete()
    {
        read = "";
        mail.TO_ADD = "";
        mail.FROM_DATE = "";
        mail.TO_DATE = "";
        mail.FROM_ADD = "";

        mail.READ_STATUS = read;
        mail.DELETE_STATUS = "";

        mail.WORKING_PERIOD = Working_Period;


        if (Request.QueryString["mail"] != "" && Request.QueryString["mail"] != null)
        {
            val = Request.QueryString["mail"];
            if (val == "INBOX")
            {
                
                mail.TRASH = "Yes";
                mail.INBOX = "No";
                mail.flag = "DELETE_FROM_INBOX";
                tab = "Inbox_tab";

            }
            else if (val == "SENT")
            {

              
                    mail.TRASH = "Yes";
                    mail.SENT = "No";
                    mail.flag = "DELETE_FROM_SENT";
                    tab = "Sent_tab";

               
            }
            else if (val == "TRASH")
            {

                mail.flag = "DELETE_FROM_TRASH";
                tab = "Trash_tab";
              
                
            }
            else if (val == "FOLDER")
            {

                
                    mail.TRASH = "Yes";
                    mail.FOLDER = "No";
                    mail.flag = "DELETE_FROM_FOLDER";
                    tab = "Personal_tab";
                
            }

        }
        CheckBox chkAll = (CheckBox)gvdetails.HeaderRow.Cells[0].FindControl("chkAll");
        for (int i = 0; i < gvdetails.Rows.Count; i++)
        {

            CheckBox chk = (CheckBox)gvdetails.Rows[i].Cells[0].FindControl("chk");
            if (chk.Checked)
            {

                mail.INBOX_ID = gvdetails.DataKeys[j].Values["INBOX_ID"].ToString();
                mail.REFERENCE_ID = gvdetails.DataKeys[j].Values["REFERENCE_ID"].ToString();
                
                mail.GetMail();


                if (mail.result == 1)
                {
                    if (val == "TRASH")
                    {

                        mail.flag = "DELETE_FROM_TRASH";
                        string str=gvdetails.DataKeys[j].Values["FILE_NAME"].ToString();
                        string[] s1 = str.Split(new string[] { "~/" }, StringSplitOptions.None);
                        foreach (string value in s1)
	                    {
                            if(value!="")
	                        {

                                string Attach_Folder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "UploadFiles/" + value);

                                if (File.Exists(Attach_Folder))
                                {
                                    File.Delete(Attach_Folder);
                           
                                }
                            }
                        }

                    }
                    //Alert_msg("Saved Successfully");
                    string prompt = "<script>$(document).ready(function(){{jAlert('Mail Deleted', 'MAIL', function (r) {window.parent.document.getElementById('" + tab + "').click();});}});</script>";

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
                }
            }
        }
    }

    protected void gvdetails_DataBound(object sender, EventArgs e)
    {
        Boolean hasData = false;


        for (int col = 0; col < gvdetails.HeaderRow.Cells.Count; col++)
        {


            for (int row = 0; row < gvdetails.Rows.Count; row++)
            {


                if (!String.IsNullOrEmpty(gvdetails.Rows[row].Cells[col].Text) && !String.IsNullOrEmpty(HttpUtility.HtmlDecode(gvdetails.Rows[row].Cells[col].Text).Trim()))
                {


                    hasData = true;


                    break;


                }


            }
            if (!hasData)
            {
                //gvdetails.HeaderRow.Cells[col].Visible = false;
                for (int hiddenrows = 0; hiddenrows < gvdetails.Rows.Count; hiddenrows++)
                {
                    //gvdetails.Rows[hiddenrows].Cells[col].Visible = false;
                }
            }
            hasData = false;
        }

    }

    private void GetData()
    {
        DataTable dt;
        if (ViewState["SelectedRecords"] != null)
            dt = (DataTable)ViewState["SelectedRecords"];
        else
            dt = CreateDataTable();
        CheckBox chkAll = (CheckBox)gvdetails.HeaderRow.Cells[0].FindControl("chkAll");
        for (int i = 0; i < gvdetails.Rows.Count; i++)
        {
            if (chkAll.Checked)
            {
                dt = AddRow(gvdetails.Rows[i], dt);
            }
            else
            {
                CheckBox chk = (CheckBox)gvdetails.Rows[i]
                                .Cells[0].FindControl("chk");
                if (chk.Checked)
                {
                    dt = AddRow(gvdetails.Rows[i], dt);
                }
                else
                {
                    dt = RemoveRow(gvdetails.Rows[i], dt);
                }
            }
        }

        ViewState["SelectedRecords"] = dt;
    }

    private void SetData()
    {
        CheckBox chkAll = (CheckBox)gvdetails.HeaderRow.Cells[0].FindControl("chkAll");
        chkAll.Checked = true;
        if (ViewState["SelectedRecords"] != null)
        {
            DataTable dt = (DataTable)ViewState["SelectedRecords"];
            for (int i = 0; i < gvdetails.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvdetails.Rows[i].Cells[0].FindControl("chk");
                if (chk != null)
                {
                    DataRow[] dr = dt.Select("INBOX_ID = '" + gvdetails.DataKeys[i].Values["INBOX_ID"].ToString() + "'");
                    chk.Checked = dr.Length > 0;
                    if (!chk.Checked)
                    {
                        chkAll.Checked = false;
                    }
                }
            }
        }
    }

    private DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("INBOX_ID");
        dt.Columns.Add("REFERENCE_ID");
        dt.AcceptChanges();
        return dt;
    }

    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {

        DataRow[] dr = dt.Select("INBOX_ID = '" + gvRow.Cells[1].Text + "'");
        if (dr.Length <= 0)
        {


                dt.Rows.Add();


                dt.Rows[dt.Rows.Count - 1]["INBOX_ID"] = gvdetails.DataKeys[i].Values["REFERENCE_ID"].ToString();
                dt.Rows[dt.Rows.Count - 1]["REFERENCE_ID"] = gvdetails.DataKeys[i].Values["REFERENCE_ID"].ToString();
               
                dt.AcceptChanges();
          

        }
        return dt;
    }

    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("INBOX_ID = '" + gvRow.Cells[1].Text + "'");
        if (dr.Length > 0)
        {
            dt.Rows.Remove(dr[0]);
            dt.AcceptChanges();
           
        }
        return dt;
    }
    protected void CheckBox1_DataBinding(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        checkbox.Checked = ViewState[checkbox.UniqueID] != null;
    }

    protected void CheckBox_CheckChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        if (checkbox.Checked)
        {
            ViewState[checkbox.UniqueID] = true;
            btnmove.Style.Add("display", "block");
            btndelete.Style.Add("display", "block");
        }
        else
        {
            btnmove.Style.Add("display", "none");
            btndelete.Style.Add("display", "none");
            ViewState.Remove(checkbox.UniqueID);
        }
        //GetData();
        //SetData();
        //BindSecondaryGrid();

    }
    protected void CheckBox1_CheckChanged(object sender, EventArgs e)
    {
        GetData();
        SetData();
        BindSecondaryGrid();
    }
   
    private void BindSecondaryGrid()
    {
        DataTable dt = (DataTable)ViewState["SelectedRecords"];
        gvSelected.DataSource = dt;
        gvSelected.DataBind();
    }

    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        GetData();
        //gvAll.PageIndex = e.NewPageIndex;
        //BindPrimaryGrid();
        SetData();
    }
}