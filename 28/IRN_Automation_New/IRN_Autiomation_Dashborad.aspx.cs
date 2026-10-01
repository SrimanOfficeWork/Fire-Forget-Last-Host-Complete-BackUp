using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.Collections.Generic;
public partial class IRN_Autiomation_Dashborad : ThemeClass
{
    AppSession aps = new AppSession();
    DataSet ds = new DataSet();
    IRN_Automation IA = new IRN_Automation();
    Global_variables ObjUBO = new Global_variables();

    public string Name_Search, Client;
    public int currentPageNumber;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Name_Search = ddlJobno.SelectedValue;
        if (!IsPostBack)
        {
            DateTime today = DateTime.Today;
            CalendarExtender1.EndDate = today;
            CalendarExtender2.EndDate = today;
            Load_Jobno();
            btnSearch_Click(sender, e);
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (Connection.Export_IRN_N() == "T" && Connection.Import_IRN_N() == "T")
            {
                Div_IRN_btn_New.Style.Add("display", "block");
            }

            int pageno = 1;
            gridbind(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii);
        }
        catch (Exception ex)
        {
        }
    }
    public void Load_Jobno()
    {
        ddlJobno.Items.Clear();
        DataSet ds = new DataSet();
        ObjUBO.A10 = "LOAD_JOBNO_GRID";
        ds = IA.IRN_Automation_Dashboard(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlJobno.DataTextField = "JOBNO";
            ddlJobno.DataValueField = "JOBNO";
            ddlJobno.DataSource = ds.Tables[0];
            ddlJobno.DataBind();
        }
        ddlJobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlJobno.SelectedIndex = 0;
    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        ddlJobno.SelectedValue = "";
        ddljobtype.SelectedValue = "";
        Name_Search = "";
        btnSearch_Click(sender, e);
    }

    public void gridbind(int currentPageNumber1)
    
{
        DataSet ds = new DataSet();
        string selected = GetSelectedJobNos();

        ObjUBO.A1 = Name_Search;
        ObjUBO.A2 = ddljobtype.SelectedValue;
        ObjUBO.A3 = ddlstatus.SelectedValue;
        ObjUBO.A4 = txtfromdate.Text;
        ObjUBO.A5 = txttodate.Text;
        ObjUBO.A6 = selected;
        ObjUBO.A10 = "Grid_Data";
        ObjUBO.A11 = Convert.ToString(currentPageNumber1);
        ObjUBO.A12 = Convert.ToString(gvdetails.PageSize);
        ds = IA.IRN_Automation_Dashboard(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            gvdetails.DataSource = ds.Tables[0];
            gvdetails.DataBind();

            Grid_Total(currentPageNumber1, IA.result);
        }
        else
        {
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
            lblTotalPages.Text = "0";
        }
    }

    private int CalculateTotalPages(double totalRows)
    {
        int totalPages = (int)Math.Ceiling(totalRows / gvdetails.PageSize);
        return totalPages;
    }

    protected void ChangePage(object sender, CommandEventArgs e)
    {
        int currentpagenumber2 = 0;
        switch (e.CommandName)
        {
            case "Previous":
                currentpagenumber2 = Int32.Parse(lblCurrentPage.Text) - 1;

                break;

            case "Next":

                int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
                if (Int32.Parse(lblCurrentPage.Text) == ii)
                    currentpagenumber2 = ii;
                else
                    currentpagenumber2 = Int32.Parse(lblCurrentPage.Text) + 1;

                break;
            case "First":
                currentpagenumber2 = 1;

                break;
            case "Last":
                int i = CalculateTotalPages(double.Parse(lblTotalPages.Text));

                currentpagenumber2 = i;
                break;
        }

        gridbind(currentpagenumber2);
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.classList.add('gridHover');");
            e.Row.Attributes.Add("onmouseout", "this.classList.remove('gridHover');");

            // Read CLIENT_NAME from DataKeys
            string Jobno = gvdetails.DataKeys[e.Row.RowIndex]["JOBNO"].ToString();
            string clientName = gvdetails.DataKeys[e.Row.RowIndex]["CLIENT_NAME"].ToString();
            string Jobtype = gvdetails.DataKeys[e.Row.RowIndex]["JobType"].ToString();
            string status = DataBinder.Eval(e.Row.DataItem, "IRN_STATUS") + "";
            if (!string.IsNullOrEmpty(Jobno))
            {
                // Set tooltip as full text
                e.Row.Cells[1].ToolTip = Jobno;

                // Truncate inside grid display
                if (Jobno.Length > 32)
                {
                    e.Row.Cells[1].Text = Jobno.Substring(0, 30) + "...";
                }
                else
                {
                    e.Row.Cells[1].Text = Jobno; // No cut
                }
            }
            if (!string.IsNullOrEmpty(clientName))
            {

                e.Row.Cells[3].ToolTip = clientName;
                if (clientName.Length > 32)
                {
                    e.Row.Cells[3].Text = clientName.Substring(0, 30) + "...";
                }
                else
                {
                    e.Row.Cells[3].Text = clientName; 
                }
            }
            if (!string.IsNullOrEmpty(Jobtype))
            {
                e.Row.Cells[4].ToolTip = Jobtype;
                if (Jobtype.Length > 32)
                {
                    e.Row.Cells[4].Text = Jobtype.Substring(0, 30) + "...";
                }
                else
                {
                    e.Row.Cells[4].Text = Jobtype; 
                }
            }
            if (!string.IsNullOrEmpty(status))
            {
                if (status.Equals("Failed.", StringComparison.OrdinalIgnoreCase))
                {
                    e.Row.ForeColor = System.Drawing.Color.Red;
                }
                else if (status.Equals("Success.", StringComparison.OrdinalIgnoreCase))
                {
                    e.Row.ForeColor = System.Drawing.Color.Green;
                }
                else if (status.Contains("Progress")) // "In Progress..."
                {
                    e.Row.ForeColor = System.Drawing.Color.Blue;
                }
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
        if (ddlSelectPageno.SelectedValue != "")
        {
            ViewState["selected_change"] = "1";
            gridbind(Int32.Parse(ddlSelectPageno.SelectedValue.ToString()));
        }
    }
    private string GetSelectedJobNos()
    {
        HashSet<string> jobList = new HashSet<string>();

        foreach (GridViewRow row in gvdetails.Rows)
        {
            CheckBox chk = row.FindControl("chkSelect") as CheckBox;

            if (chk != null && chk.Checked)
            {
                string jobno = gvdetails.DataKeys[row.RowIndex]["Guidid"].ToString();
                jobList.Add(jobno);
            }
        }

        return string.Join(",", jobList);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            btnSearch_Click(sender, e);
        }
        catch (Exception ex)
        {
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

        lblTotalPages.Text = Convert.ToString(totalRows);
        lblCurrentPage.Text = Convert.ToString(currentPageNumber1);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));

        if (currentPageNumber1 == 1)
        {
            btnPrev.Visible = false;
            if (Int32.Parse(lblTotalPages.Text) > 10)
            {
                btnNext.Visible = true;
                btnLast.Visible = true;
            }
            else
            {
                btnNext.Visible = false;
                btnLast.Visible = false;
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
        if (ViewState["selected_change"] == "1")
        {
        }
        else
            Add_Pageno(ii);
    }

}