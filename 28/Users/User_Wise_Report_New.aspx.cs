using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class User_Wise_Report_New : System.Web.UI.Page
{
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;

    public string SELECT_TYPE, SELECT_BRANCH;

    AppSession aps = new AppSession();
    Dynamic_Report_GroupNew DRT = new Dynamic_Report_GroupNew();
    Company_Master Comp = new Company_Master();
    User_Wise_Job_Report User = new User_Wise_Job_Report();
    DataSet ds = new DataSet();
  

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();

        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        
        SELECT_BRANCH = Connection.Get_Company_Type();

        if (!IsPostBack)
        {
            groupload();
        }

    }

    private void groupload()
    {
        DataSet ds = new DataSet();
        Comp.COMPANY_ID = "";
        Comp.BRANCH = "";
        Comp.flag = "Select-Group";
        ds = Comp.RetrieveAll_Groups();
        
        if (ds.Tables[0].Rows.Count > 0)
        {
            ListBox1.DataSource = ds.Tables[0];
            ListBox1.DataTextField = "GROUP_NAME";
            ListBox1.DataValueField = "GROUP_ID";
            ListBox1.DataBind();
            //Bind_Branch(ds.Tables[0].Rows[0]["GROUP_ID"].ToString(), ds.Tables[1]);
        }

        if (ds.Tables[2].Rows.Count > 0)
        {
            ListBox2.DataSource = ds.Tables[2];
            ListBox2.DataTextField = "USER_NAME";
            ListBox2.DataValueField = "USER_NAME";
            ListBox2.DataBind();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Report_data();
    }

    private void Report_data()
    {
        try
        {
            string Branchlist = "";
            foreach (ListItem item in ListBox1.Items)
            {
                if (item.Selected)
                {
                    //message += item.Text + "~" + item.Value + "\\n";
                    Branchlist += item.Value + "~";
                }
            }

            string Userlist = "";
            foreach (ListItem item in ListBox2.Items)
            {
                if (item.Selected)
                {
                    Userlist += item.Value + "~";
                }
            }

            if (Branchlist != "" && Userlist != "")
            {
                bool isEmpty = true;
                string F_date, T_date;

                string[] arr = new string[] { };
                string[] arr2 = new string[] { };


                User.IMP_EXP = ddlJob_Type.SelectedValue;
                User.Branch = Branchlist;
                User.Username = Userlist;
                User.Flag = "";
                User.From_date = txtFrom_Date.Text;
                User.To_date = txtTo_Date.Text;
                User.Job_Sort = ddl_Jobno_sort.SelectedItem.Text;

                ds = User.Select_Master_Search();
             
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["Excel"] = ds.Tables[0];
                    GvReport.DataSource = ds.Tables[0];
                    GvReport.DataBind();
                }

                lbl_count.Text = "Row Count : " + Convert.ToString(ds.Tables[0].Rows.Count);
                lbl_cols_count.Text = "Column Count : " + Convert.ToString(ds.Tables[0].Columns.Count);

            }

            else
            {
                Alert_msg("Select Branch & User Name", ListBox1.Text);
            }
        }
        catch (Exception ex)
        {
            ErrorLogs err = new ErrorLogs();
            err.makeLog(ex.Message);
        }
    }

   
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'User Wise Report', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


    protected void btnexcel_Click(object sender, EventArgs e)
    {
        exportfile("Excel");
    }

    private void exportfile(string filetype)
    {
        if (GvReport.Rows.Count > 0)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)ViewState["Excel"];
            if (dt.Rows.Count > 0)
            {
                if (filetype == "Excel")
                {
                    if (ddlJob_Type.SelectedValue == "Import")
                    {
                        ExportExcel(dt, "Import-UserWise-Report");
                    }
                    else
                    {
                        ExportExcel(dt, "Export-UserWise-Report");
                    }
                }
            }
            else
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'User Wise Report', function (r) {});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
        }
        else
        {
            string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'User Wise Report', function (r) {});}});</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
        }
    }

    protected void btnRdlc_Click(object sender, EventArgs e)
    {

        exportfile("PDF");
    }

    protected void GvReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {   
        if (e.Row.RowType == DataControlRowType.DataRow)
        {       
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {

                e.Row.Cells[i].Attributes.Add("style", "white-space:nowrap;");

                //e.Row.Cells[i + 1].Text = e.Row.Cells[i + 1].Text + "  ";
            }
        }
    }
    protected void GvReport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.Header)
        //    e.Row.CssClass = "header";
        //if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
        //    e.Row.CssClass = "normal";
        //if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
        //    e.Row.CssClass = "alternate";
    }

    public void ExportExcel(DataTable dtdata, string filename)
    {

        HttpResponse Response = HttpContext.Current.Response;


        GridView grd = new GridView();
        grd.DataSource = dtdata;
        grd.DataBind();

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename= " + filename + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {

            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //foreach (TableCell cell in grd.HeaderRow.Cells)
            //{
            //    //cell.BackColor = grd.HeaderStyle.BackColor;
            //    cell.BackColor=grd.HeaderRow.BackColor
            //}

            grd.HeaderStyle.BackColor = System.Drawing.Color.LightGray;
            grd.HeaderStyle.ForeColor = System.Drawing.Color.Blue;
            grd.HeaderStyle.Height = 26;
            grd.RowStyle.Height = 18;

            grd.RenderControl(hw);
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    protected void ddl_Jobno_sort_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
    }

    protected void ddlJob_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
    }
}