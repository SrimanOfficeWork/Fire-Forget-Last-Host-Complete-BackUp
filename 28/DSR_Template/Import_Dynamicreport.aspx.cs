using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class DSR_Template_Import_Dynamicreport : System.Web.UI.Page
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
            jobload();
            load_Report_Name();
            groupload();
        }

        //iframe1.Visible = false;
    }

    private void groupload()
    {
        DataSet ds = new DataSet();
        Comp.COMPANY_ID = "";
        Comp.BRANCH = "";
        Comp.flag = "Select-Group";
        ds = Comp.RetrieveAll_Groups();
        //HttpContext.Current.Session["ClientGrpMst"] = ds;
        //RetrieveAll_Groups

        if (ds.Tables[0].Rows.Count > 0)
        {

            ListBox1.DataSource = ds.Tables[0];
            ListBox1.DataTextField = "GROUP_NAME";
            ListBox1.DataValueField = "GROUP_ID";
            ListBox1.DataBind();
            //Bind_Branch(ds.Tables[0].Rows[0]["GROUP_ID"].ToString(), ds.Tables[1]);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlrptname.SelectedItem.Text != string.Empty)
        {
            //iframe1.Visible = true;
            //iframe1.Attributes["src"] = "Import_Dynamic_Report_New.aspx?JobNo=" + ddlJobNo.SelectedItem.Text + "&Report_Name=" + ddlrptname.SelectedItem.Text + "&Report_Id=" + ddlrptname.SelectedValue.ToString() + "&From_date=" + txtFrom_Date.Text + "&To_date=" + txtTo_Date.Text + "&Orderby=" + ddlorederby.SelectedItem.Text + "&Based=" + ddlbase.SelectedItem.Text + "&Imp_name=" + HttpUtility.UrlEncode(ddlimpname.SelectedItem.Text) + "&BE_Type=" + ddlBEType.SelectedValue.ToString() + "";
         
            Report_data();
        }
        else
        {
            Alert_msg("Select the Report Name", "ddlrptname");
        }
    }

    private DataTable Report_data()
    {
        DataTable dt = new DataTable();
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

            if (Branchlist != "")
            {
                bool isEmpty = true;
                string F_date, T_date;

                string[] arr = new string[] { };
                string[] arr2 = new string[] { };


                if (txtFrom_Date.Text != "")
                {
                    arr = txtFrom_Date.Text.Split('/');
                    F_date = arr[1] + '/' + arr[0] + '/' + arr[2];
                }
                else
                {
                    F_date = "";
                }

                if (txtTo_Date.Text != "")
                {
                    arr = txtTo_Date.Text.Split('/');
                    T_date = arr[1] + '/' + arr[0] + '/' + arr[2];
                }
                else
                {
                    T_date = "";
                }


                DRT.Jobno = ddlJobNo.SelectedItem.Text;
                DRT.Report_Name = ddlrptname.SelectedItem.Text;
                DRT.Report_Name_id = ddlrptname.SelectedValue.ToString();
                DRT.From_date = F_date;
                DRT.To_date = T_date;

                if (ddlorederby.SelectedItem.Text == "Ascending")
                {
                    DRT.Orderby = "Asc";
                }
                else if (ddlorederby.SelectedItem.Text == "Descending")
                {
                    DRT.Orderby = "Desc";
                }

                DRT.Rpt_Type = ddlbase.SelectedItem.Text;
                //DRT.Imp_Name = HttpUtility.UrlEncode(ddlimpname.SelectedItem.Text);
                DRT.Imp_Name = ddlimpname.SelectedItem.Text;
                DRT.BE_Type = ddlBEType.SelectedValue.ToString();
                DRT.BRANCH_CODE = Branchlist;

                DataSet dss = DRT.Report_data();
                
                if (dss.Tables[0].Rows.Count > 0)
                {
                    string dsName = string.Empty;

                    dsName = ddlrptname.SelectedItem.Text.ToString().Replace(" ", "_");
                    dt = dss.Tables[0];

                    /************************************ for EKATA Shipping Report - 05-09-2018 - By Chithra ************************/
                    if (Connection.COMPANYID() == "1029")
                    {
                        //if (dsName == "EKTA_REPORT_sea")
                        //{
                        DataColumnCollection columns = dt.Columns;
                        if (columns.Contains("TYPE"))
                        {
                            int Index = columns.IndexOf("TYPE");

                            DataColumn Col = dt.Columns.Add("SIZE", System.Type.GetType("System.String"));
                            Col.SetOrdinal(Index);

                            IEnumerable<DataRow> rowsc = dt.Rows.Cast<DataRow>().Where(r => r["TYPE"].ToString().Length >= 2);
                            rowsc.ToList().ForEach(r => r.SetField("SIZE", r["TYPE"].ToString().Substring(0, 2)));

                            IEnumerable<DataRow> rowsc2 = dt.Rows.Cast<DataRow>().Where(r => r["TYPE"].ToString().Length >= 2);
                            rowsc2.ToList().ForEach(r => r.SetField("TYPE", r["TYPE"].ToString().Replace("20", "").Replace("40", "")));

                        }
                        //}
                    }

                    if (dt.Rows.Count > 0)
                    {
                        //ViewState["Excel"] = dt;

                        /* Due to Bulk Load in Grid - TOP 50 records only show in Grid
                        GvReport.DataSource = dt;
                        GvReport.DataBind();
                         * */

                        GvReport.DataSource = dss.Tables[1];
                        GvReport.DataBind();

                    }

                    lbl_count.Text = "Row Count : " + Convert.ToString(dt.Rows.Count);
                    lbl_cols_count.Text = "Column Count : " + Convert.ToString(dt.Columns.Count);

                }
            }
            else
            {
                Alert_msg("Select Group", ListBox1.Text);
            }
        }
        catch (Exception ex)
        {
            ErrorLogs err = new ErrorLogs();
            err.makeLog(ex.Message);
        }

        return dt;
    }



    private void jobload()
    {
        CheckList chklist = new CheckList();
        chklist.JOBNo = "";
        chklist.Ename = "select_jobno";
        chklist.Workingperiod = SELECT_BRANCH;

        ddlJobNo.DataSource = chklist.RetrieveAll_General_Details();
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataTextField = "JOBNO";
        ddlJobNo.DataBind();

        ListItem li = new ListItem(string.Empty, string.Empty);
        ddlJobNo.Items.Insert(0, li);
    }

    private void load_Report_Name()
    {
        DataSet ds = new DataSet();
        DRT.TYPE = "Import";
        DRT.TR_MODE = "";
        DRT.ACTIVE = "";
        DRT.WORKING_PERIOD = SELECT_BRANCH;
        DRT.Select_Con = "Load_Report_Name";

        ds = DRT.All_Record();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlrptname.DataSource = DRT.All_Record();
            ddlrptname.DataValueField = "T_ID";
            ddlrptname.DataTextField = "TEMPLATE_NAME";
            ddlrptname.DataBind();
            ddlrptname.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlrptname.SelectedIndex = 0;
        }
        else
        {
            ddlrptname.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlrptname.SelectedIndex = 0;
        }

        string Userwise_IEC_Avail = "";
        if (ds.Tables[2].Rows.Count > 0)
        {
            Userwise_IEC_Avail = ds.Tables[2].Rows[0]["IEC_enabled"].ToString();
        }

        if (ds.Tables[1].Rows.Count > 0)
        {
            ddlimpname.DataSource = ds.Tables[1];
            ddlimpname.DataValueField = "Imp_name";
            ddlimpname.DataTextField = "Imp_name";
            ddlimpname.DataBind();

            if (Userwise_IEC_Avail == "")
            {
                ddlimpname.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                ddlimpname.SelectedIndex = 0;
            }
        }
        else
        {
            ddlimpname.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlimpname.SelectedIndex = 0;
        }

    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
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
            //dt = (DataTable)ViewState["Excel"];

            dt = Report_data();
            if (dt.Rows.Count > 0)
            {
                if (filetype == "Excel")
                {
                    ExportExcel(dt, "Import-Customized-Report");
                }
            }
            else
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'Import Dynamic', function (r) {});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
        }
        else
        {
            string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'Import Dynamic', function (r) {});}});</script>";
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
}