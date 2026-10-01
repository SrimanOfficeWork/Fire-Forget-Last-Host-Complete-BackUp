using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class DSR_Template_Export_Dynamicreport : System.Web.UI.Page
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

            DataTable dt1 = new DataTable();
            GvReport.EmptyDataText = "Records Not Found";
            GvReport.Attributes.Add("style", "background-color: #e3e1e1 !important;");
            GvReport.DataSource = dt1;
            GvReport.DataBind();
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
        //--------------------------------------------Diana Changed-----------------------------------------------------------//
        GvReport.Columns.Clear();
        if (ddlrptname.SelectedItem.Text != string.Empty)
        {
            try
            {
                DataTable dt = Report_data();

                if (dt.Rows.Count <= 0)
                {
                    DataTable dt1 = new DataTable();
                    GvReport.EmptyDataText = "Records Not Found";
                    GvReport.Attributes.Add("style", "background-color: #e3e1e1 !important;");
                    GvReport.DataSource = dt1;
                    GvReport.DataBind();
                }
                else
                {
                    GvReport.Columns.Clear();
                    GvReport.DataSource = dt;
                    // Add columns dynamically
                    foreach (DataColumn column in dt.Columns)
                    {
                        BoundField boundField = new BoundField
                        {
                            DataField = column.ColumnName,
                            HeaderText = column.ColumnName,
                            SortExpression = column.ColumnName,
                            HeaderStyle =
                            {
                                Font = { Bold = true },
                                BackColor = System.Drawing.Color.CadetBlue,
                                BorderColor = System.Drawing.Color.Gray,
                                BorderWidth = Unit.Pixel(1),
                                BorderStyle = BorderStyle.Solid
                            },
                            ItemStyle =
                            {
                                BorderColor = System.Drawing.Color.Black,
                                BorderWidth = Unit.Pixel(1),
                                BorderStyle = BorderStyle.Solid
                            }
                        };

                        GvReport.Columns.Add(boundField);
                    }

                    GvReport.DataBind();
                    GvReport.Attributes.Add("style", "background-color: #fff !important;");
                    // Hide loading icon after data binding
                    ViewState["Excel"] = dt;
                    // Update label counts
                    lbl_count.Text = "Row Count : " + Convert.ToString(dt.Rows.Count);
                    lbl_cols_count.Text = "Column Count : " + Convert.ToString(dt.Columns.Count);
                }
            }
            catch (Exception ex)
            {
                ErrorLogs err = new ErrorLogs();
                DataTable dt1 = new DataTable();
                err.makeLog(ex.Message);
                dt1.Columns.Clear();
                GvReport.Columns.Clear();
                dt1.Rows.Add(ex.Message);
                GvReport.DataSource = dt1;
                GvReport.DataBind();

            }
            //--------------------------------------------Diana Changed-----------------------------------------------------------//
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "HideLoadingIcon", "hideLoading();", true);
        }
    }
    private DataTable Report_data()
    {
        DataTable dt = new DataTable();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowLoadingIcon", "showLoading();", true);

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
            //DRT.Imp_Name = HttpUtility.UrlEncode(ddlExpname.SelectedItem.Text);
            DRT.Imp_Name = ddlExpname.SelectedItem.Text;
            DRT.SB_Type = ddlSBType.SelectedValue.ToString();
            DRT.BRANCH_CODE = Branchlist;

            DataSet dss_Rpt = new DataSet();
            dss_Rpt = DRT.Exp_Report_data();

            //-----------------------------------------------Diana Added-----------------------------------------------//
            if (dss_Rpt.Tables.Count == 0)
            {
                dt.Columns.Clear();

            }
            else
            {
                if (dss_Rpt.Tables[0].Rows.Count > 0)
                {
                    // ViewState["Excel"] = dss_Rpt.Tables[0];
                    dt = dss_Rpt.Tables[0];
                    //GvReport.DataSource = dt;
                    //GvReport.DataBind();
                }
            }
            //-----------------------------------------------Diana Added-----------------------------------------------//
        }
        else
        {
            Alert_msg("Select Group", ListBox1.Text);
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "HideLoadingIcon", "hideLoading();", true);
        return dt;
    }

    private void jobload()
    {
        Export_CheckList chklist = new Export_CheckList();
        Working_Period = Session["WorkingPeriod"].ToString();

        chklist.JOBNo = "";
        chklist.Ename = "select_jobno";
        chklist.Workingperiod = SELECT_BRANCH;

        ddlJobNo.DataSource = chklist.RetrieveAll_General_Details();
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataTextField = "JOBNO";
        ddlJobNo.DataBind();

        ListItem li = new ListItem(" ", "0");
        ddlJobNo.Items.Insert(0, li);
    }

    private void load_Report_Name()
    {
        DataSet ds = new DataSet();
        DRT.TYPE = "Export";
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
            ddlExpname.DataSource = ds.Tables[1];
            ddlExpname.DataValueField = "Exp_name";
            ddlExpname.DataTextField = "Exp_name";
            ddlExpname.DataBind();

            if (Userwise_IEC_Avail == "")
            {
                ddlExpname.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                ddlExpname.SelectedIndex = 0;
            }
        }
        else
        {
            ddlExpname.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddlExpname.SelectedIndex = 0;
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
                    ExportExcel(dt, "Export-Customized-Report");
                }
            }
            else
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('No Records Found', 'Export Dynamic', function (r) {});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }

            dt.Clear();
            dt.Dispose();
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