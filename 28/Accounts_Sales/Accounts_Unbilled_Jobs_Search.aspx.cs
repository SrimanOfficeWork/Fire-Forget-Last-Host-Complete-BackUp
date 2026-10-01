using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObject;
using System.Linq;
using System.Data;
public partial class Accounts_Unbilled_Jobs_Search : ThemeClass
{
    Acc_Unbilled_Jobs un = new Acc_Unbilled_Jobs();
    private DataSet GridData
    {
        get { return ViewState["GridData"] as DataSet; }
        set { ViewState["GridData"] = value; }
    }

    private string SortDirection
    {
        get { return Convert.ToString(ViewState["SortDirection"]) ?? "ASC"; }
        set { ViewState["SortDirection"] = value; }
    }
    private string SortExpression
    {
        get { return ViewState["SortExpression"] as string ?? string.Empty; }
        set { ViewState["SortExpression"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGrid();
            Load_Branch();
            txtAsOnDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }

    private void Load_Branch()
    {
        chkBranch.Items.Clear();
        if (Session["ClientGrpMst"] != null)
        {
            DataSet ds = (DataSet)Session["ClientGrpMst"];
            if (ds.Tables[0].Rows.Count > 0)
            {
                chkBranch.DataSource = ds.Tables[0];
                chkBranch.DataTextField = "GROUP_NAME";
                chkBranch.DataValueField = "GROUP_ID";
                chkBranch.DataBind();
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadGrid();
    }


    private void LoadGrid()
    {
        DataTable dt = GetData();
        Session["UnbilledJobsData"] = dt;
        gvUnbilledJobs.DataSource = dt;
        gvUnbilledJobs.DataBind();
       
        BindTotalExpense(dt);
    }


    private DataTable GetData()
    {
        Global_variables obj = new Global_variables();
        obj.A1 = hdnBranchValues.Value;
        obj.A2 = ddlLOB.SelectedValue;
        obj.A3 = ddl_Shipper.SelectedValue;
        obj.A4 = ddl_Customer.SelectedValue;
        obj.A5 = txtJobNo.Text;
        obj.A6=string.IsNullOrEmpty(txtAsOnDate.Text)?DateTime.Now.ToString("dd/MM/yyyy"):txtAsOnDate.Text;
        obj.A7 = "LOAD";

        GridData = un.Select_UnbilledJobs(obj);
        return GridData.Tables[0];
    }
    private void BindTotalExpense(DataTable dt)
    {
        decimal total = 0;
        if (dt != null && dt.Columns.Contains("Expense_Amt"))
        {
            total = dt.AsEnumerable().Sum(x => x["Expense_Amt"] == DBNull.Value ? 0 : Convert.ToDecimal(x["Expense_Amt"]));
        }
        if (gvUnbilledJobs.FooterRow != null)
        {
            Label lblTotalExpense = (Label)gvUnbilledJobs.FooterRow.FindControl("lblTotalExpense");

            if (lblTotalExpense != null)
            {
                lblTotalExpense.Text = total.ToString("N2");
            }
        }
    }
    protected void gvUnbilledJobs_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        { 
            e.Row.CssClass = "header";
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                LinkButton sortLink = null;
                foreach (Control control in e.Row.Cells[i].Controls)
                {
                    if (control is LinkButton)
                    {
                        sortLink = (LinkButton)control;
                    }
                }
                if (sortLink != null && !string.IsNullOrEmpty(sortLink.CommandArgument))
                {
                    string icon = "▲";//"↕"
                    if (SortExpression == sortLink.CommandArgument)
                    {
                        icon=(SortDirection == "ASC" )? "▲" : "▼";
                    }
                    sortLink.Text += "<span class='sort-icon'>" + icon + "</span>";
                }
            }
        }

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.CssClass = "gridFooterRow";
        }
    }
    protected void ddl_Shipper_SelectedIndexChanged(object sender, EventArgs e)
    {
        Global_variables obj = new Global_variables();
        obj.A3 = ddl_Shipper.SelectedValue;
        obj.A6 = "DROPDOWN";
        obj.A7 = txtJobNo.Text;
        DataSet ds = un.Select_UnbilledJobs(obj);
        ddl_Customer.DataSource = ds.Tables[0];
        ddl_Customer.DataTextField = "NAME";
        ddl_Customer.DataValueField = "NAME";
        ddl_Customer.DataBind();
        ddl_Customer.Items.Insert(0, new ListItem("Select", ""));

    }

    protected void gvUnbilledJobs_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

        }
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {

        LoadGrid();
    }


    protected void gvUnbilledJobs_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (GridData == null)
        { return; }

        // Toggle direction
        if (SortExpression == e.SortExpression)
        {
            SortDirection = (SortDirection == "ASC") ? "DESC" : "ASC";
        }
        else
        {
            SortDirection = "ASC";
        }

        SortExpression = e.SortExpression;

        GridData.Tables[0].DefaultView.Sort = e.SortExpression + " " + SortDirection;

        gvUnbilledJobs.DataSource = GridData.Tables[0].DefaultView;
        gvUnbilledJobs.DataBind();
        BindTotalExpense(GridData.Tables[0]);
    }
}
