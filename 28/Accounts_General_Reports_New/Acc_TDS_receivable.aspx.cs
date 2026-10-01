using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Microsoft.ReportingServices.Rendering;
using Microsoft.ReportingServices.Library;
using System.Data.SqlClient;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;
using ClosedXML.Excel;
using System.Linq;

public partial class Acc_TDS_receivable : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    TDS_receivable_Payable Tds = new TDS_receivable_Payable();
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

    public int currentPageNumber;
    decimal TotalTDS = 0;
    string[] arr_Month = new string[] { };
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!IsPostBack)
        {
            Load_Month();
            Load_Group_Name();
            load_Cus_name();
            gridbind(1);
        }
       
    }
    private void Load_Group_Name()
    {
        ddlgroup_Name.Items.Clear();
        if (Session["ClientGrpMst"] != null)
        {
            DataSet ds = (DataSet)Session["ClientGrpMst"];
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlgroup_Name.DataSource = ds.Tables[0];
                ddlgroup_Name.DataTextField = "GROUP_NAME";
                ddlgroup_Name.DataValueField = "GROUP_ID";
                ddlgroup_Name.DataBind();
            }
        }
        ddlgroup_Name.Items.Insert(0, new ListItem("ALL", "ALL"));
        ddlgroup_Name.SelectedIndex = 0;

    }

    public void load_Cus_name()
    {
        try
        {
            DataSet dss = new DataSet();
            ObjUBO.A6 = "LoadOrgname";
            dss = Tds.LoadTDS_receivable(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                ddlpartyname.DataSource = dss.Tables[0];
                ddlpartyname.DataTextField = "PARTY_NAME";
                ddlpartyname.DataValueField = "PARTY_NAME";
                ddlpartyname.DataBind();
                ddlpartyname.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlpartyname.SelectedIndex = 0;
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            int pageno = 1;
            gridbind(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii,currentPageNumber);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void gridbind(int currentPageNumber1)
    {
        try
        {
            DataTable dt=new DataTable();
            if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
            {
                ObjUBO.A1 = txtfromdate.Text;
                ObjUBO.A2 = txttodate.Text;
            }
            else
            {
                if (ddlmonth.SelectedItem.Text != string.Empty)
                {
                    arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                    ObjUBO.A1 = arr_Month[0];
                    ObjUBO.A2 = arr_Month[1];
                }
                else
                {
                    ObjUBO.A1 = txtfromdate.Text;
                    ObjUBO.A2 = txttodate.Text;
                }
            }
            ObjUBO.A3 = ddlpartyname.SelectedValue;
            ObjUBO.A5 = ddlgroup_Name.SelectedValue == "ALL" ? "" : ddlgroup_Name.SelectedValue;
            ObjUBO.A6 = ddlType.SelectedValue;
            ObjUBO.A7 = Convert.ToString(currentPageNumber1);
            ObjUBO.A8 = Convert.ToString(gvdetails.PageSize);
            GridData = Tds.LoadTDS_receivable(ObjUBO);
            if (GridData != null && GridData.Tables.Count > 0 && GridData.Tables[0].Rows.Count > 0)
            {
                Session["ExcelData"] = GridData.Tables[0];
                gvdetails.DataSource = GridData.Tables[0];
                gvdetails.DataBind();
            }
            else
            {
                Session["ExcelData"] = null;
                gvdetails.DataSource = dt;
                gvdetails.DataBind();
            }
            Grid_Total(currentPageNumber1, Convert.ToInt32(ObjUBO.A9));
          
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
   

    protected void btnexcel_Click(object sender, EventArgs e)
    {
      
        if (Session["ExcelData"] != null)
        {
            DataTable dt = Session["ExcelData"] as DataTable;
            ExportUsingClosedXML(dt);
        }
        else
        {

        }
    }
    private void ExportUsingClosedXML(DataTable dt)
    {
        DataTable dt1 = dt.Copy();
        if(dt1.Columns.Contains("ID"))
        {
            dt1.Columns.Remove("ID");
        }
        if (dt1.Columns.Contains("IMP_EXP"))
        {
            dt1.Columns.Remove("IMP_EXP");
        }
        using (XLWorkbook wb = new XLWorkbook())
        {
            var ws = wb.Worksheets.Add(dt1, "TDS Receivable");
            ws.Row(1).Style.Font.Bold = true;
            ws.Columns().AdjustToContents();
            var lastRow = ws.LastRowUsed().RowNumber() + 1;
            ws.Cell(lastRow, 3).Value = "Total";
            ws.Cell(lastRow, 4).Value = dt1.AsEnumerable().Sum(r => r.Field<decimal>("TDS_AMT"));
            ws.Row(lastRow).Style.Font.Bold = true;
            using (MemoryStream stream = new MemoryStream())
            {
                wb.SaveAs(stream);
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=Tds_receivable.xlsx");
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.BinaryWrite(stream.ToArray());
                Response.Flush();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
        }
    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.CssClass = "header";
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                LinkButton SortLink = null;
                foreach (Control linkbtn in e.Row.Cells[i].Controls)
                {
                    if (linkbtn is LinkButton)
                    {
                        SortLink = (LinkButton)linkbtn;
                    }
                }
                if (SortLink != null && !string.IsNullOrEmpty(SortLink.CommandArgument))
                {
                    string icon = "▲";
                    if (SortExpression == SortLink.CommandArgument)
                    {
                        icon = (SortDirection == "ASC") ? "▲" : "▼";
                    }
                    SortLink.Text += "<span class='sort-icon'>"+icon+"</span>";
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string ID = this.gvdetails.DataKeys[e.Row.RowIndex]["ID"].ToString();
            string IMP_EXP = this.gvdetails.DataKeys[e.Row.RowIndex]["IMP_EXP"].ToString();
            string BillNo = this.gvdetails.DataKeys[e.Row.RowIndex]["BILL_NO"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", "Open_Sales_entry('" + ID + "','" + IMP_EXP + "','" + BillNo + "')");

            decimal tds;
            if (decimal.TryParse(DataBinder.Eval(e.Row.DataItem, "TDS_AMT").ToString(), out tds))
            {
                TotalTDS += tds;
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[3].Text = "Total";
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
            e.Row.Cells[3].Style["border-left"] = "1px solid #D3D3D3";
            e.Row.Cells[3].Font.Bold = true;

            e.Row.Cells[4].Text = TotalTDS.ToString("N2");
            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
            e.Row.Cells[4].Style["border-left"] = "1px solid #D3D3D3";
            e.Row.Cells[4].Font.Bold = true;
        }
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
    public void Add_Pageno(int p,int currentPage)
    {
        if (p != 0)
        {
            ddlSelectPageno.Items.Clear();
            for (int i = 1; i <= p; i++)
            {
                ddlSelectPageno.Items.Add(Convert.ToString(i));
            }
            if (currentPage >= 1 && currentPage <= p)
            {
                ddlSelectPageno.SelectedValue = currentPage.ToString();
            }
        }
    }
    protected void ddlSelectPageno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSelectPageno.SelectedValue != "")
        {
            int SelectedPageNo =Convert.ToInt32(ddlSelectPageno.SelectedValue);
            gridbind(SelectedPageNo);
        }
    }
    private int CalculateTotalPages(double totalRows)
    {
        int totalPages = (int)Math.Ceiling(totalRows / gvdetails.PageSize);
        return totalPages;
    }
    public void Grid_Total(int currentPageNumber1, double totalRows)
    {
        if (gvdetails.Rows.Count > 0)
        {
            Div_Pagination.Visible = true;
        }
        else if (gvdetails.Rows.Count == 0)
        {
            Div_Pagination.Visible = false;
        }

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
            btnNext.Visible = true;
            /*if (currentPageNumber == Int32.Parse(lblTotalPages.Text))
            { btnNext.Visible = false; }
            else
            { btnNext.Visible = true; }*/
        }

        Add_Pageno(ii,currentPageNumber1);
    }
    public void Load_Month()
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            ds = Common_CS.Load_Month();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlmonth.DataSource = ds.Tables[0];
                ddlmonth.DataTextField = "TheMonth";
                ddlmonth.DataValueField = "TheMonth_No";
                ddlmonth.DataBind();
                ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
                ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void gvdetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (GridData == null)
        {
            return;
        }

        if (e.SortExpression == SortExpression)
        {
            SortDirection = (SortDirection == "ASC") ? "DESC" : "ASC";
        }
        else
        {
            SortDirection = "ASC";
        }
        SortExpression = e.SortExpression;
        GridData.Tables[0].DefaultView.Sort = e.SortExpression + " " + SortDirection;
        gvdetails.DataSource = GridData.Tables[0].DefaultView;
        gvdetails.DataBind();
    }
}