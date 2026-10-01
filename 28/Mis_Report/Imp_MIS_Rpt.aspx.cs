using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using ImapX;
using System.IO;
using System.Collections;

public partial class Mis_Report_Imp_MIS_Rpt : ThemeClass
{
    MIS_rpt MIS_data = new MIS_rpt();

    AppSession aps = new AppSession();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;

    public string SELECT_TYPE, SELECT_BRANCH;

    Company_Master Comp = new Company_Master();

    string[] arr = new string[] { };

    bool isTotalReached = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        SELECT_BRANCH = Connection.Get_Company_Type();

        if (!IsPostBack)
        {
            groupload();
            Load_TrMode_Group();
            Load_Doc_UserNameList();
            LoadGroup();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gridBind();
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

    //protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    #region old
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        TableCell cell = new TableCell();
    //        cell = e.Row.Cells[0];

    //        if (ddlrptype.SelectedItem.Text == "Mode" || ddlrptype.SelectedItem.Text == "BE Type")
    //        {
    //            cell.Width = new Unit("80px");
    //        }
    //        else if (ddlrptype.SelectedItem.Text == "Importer")
    //        {
    //            cell.Width = new Unit("300px");
    //        }
    //        else if (ddlrptype.SelectedItem.Text == "Country")
    //        {
    //            cell.Width = new Unit("250px");
    //        }

    //        cell.Style["border-right"] = "1px solid #666666";
    //        cell.HorizontalAlign = HorizontalAlign.Left;

    //        for (int i = 1; i < e.Row.Cells.Count; i++)
    //        {
    //            cell = e.Row.Cells[i];
    //            if (i == 1)
    //                cell.HorizontalAlign = HorizontalAlign.Center;
    //            else if (i == 2)
    //                cell.HorizontalAlign = HorizontalAlign.Center;
    //            else
    //                cell.HorizontalAlign = HorizontalAlign.Right;

    //            cell.Style["border-right"] = "0.5px solid #666666";
    //        }
    //    }
    //    #endregion

    //    // Total row styling (mirrors Export)
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        string modeText = e.Row.Cells[2].Text.Trim();

    //        if (modeText.StartsWith("Total"))
    //        {
    //            isTotalReached = true;
    //        }

    //        if (isTotalReached)
    //        {
    //            e.Row.Font.Bold = true;
    //            e.Row.BackColor = System.Drawing.Color.Blue;

    //            e.Row.Cells[0].Text = "";
    //            e.Row.Cells[0].BorderStyle = BorderStyle.None;
    //            e.Row.Cells[0].BorderWidth = 0;

    //            e.Row.Cells[1].Text = "";
    //            e.Row.Cells[1].BorderStyle = BorderStyle.None;
    //            e.Row.Cells[1].BorderWidth = 0;
    //        }
    //    }
    //}
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // ── S. No column (Cells[0]) — always narrow ──
            e.Row.Cells[0].Width = new Unit("60px");
            e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[0].Style["border-right"] = "1px solid #666666";

            // ── Category column (Cells[1]) — wide, varies by report type ──
            if (e.Row.Cells.Count > 1)
            {
                if (ddlrptype.SelectedItem.Text == "Mode" || ddlrptype.SelectedItem.Text == "BE Type")
                    e.Row.Cells[1].Width = new Unit("120px");
                else if (ddlrptype.SelectedItem.Text == "Importer")
                    e.Row.Cells[1].Width = new Unit("300px");
                else if (ddlrptype.SelectedItem.Text == "Country")
                    e.Row.Cells[1].Width = new Unit("250px");

                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[1].Style["border-right"] = "1px solid #666666";
            }

            // ── Remaining columns alignment ──
            for (int i = 2; i < e.Row.Cells.Count; i++)
            {
                if (i == 2)
                    e.Row.Cells[i].HorizontalAlign = HorizontalAlign.Center;
                else
                    e.Row.Cells[i].HorizontalAlign = HorizontalAlign.Right;

                e.Row.Cells[i].Style["border-right"] = "0.5px solid #666666";
            }
        }

        // ── Total row styling (mirrors Export) ──
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string modeText = e.Row.Cells[2].Text.Trim();
            if (modeText.StartsWith("Total"))
            {
                isTotalReached = true;
            }
            if (isTotalReached)
            {
                e.Row.Font.Bold = true;
                e.Row.BackColor = System.Drawing.Color.Blue;

                e.Row.Cells[0].Text = "";
                e.Row.Cells[0].BorderStyle = BorderStyle.None;
                e.Row.Cells[0].BorderWidth = 0;

                e.Row.Cells[1].Text = "";
                e.Row.Cells[1].BorderStyle = BorderStyle.None;
                e.Row.Cells[1].BorderWidth = 0;
            }
        }
    }
    private void gridBind()
    {
        MIS_data.Jobdate = txtJobDate.Text;
        MIS_data.Imp_name = txtimpname.Text;
        MIS_data.Tr_mode = ddltr_mode.SelectedItem.Text;
        MIS_data.Branch = ddlbranch.SelectedItem.Text;
        MIS_data.BE_type = txtBEtype.SelectedItem.Text == "All" ? "" : txtBEtype.SelectedItem.Text;
        MIS_data.To_date = txttodate.Text;
        MIS_data.Country = txtcountry.Text;
        MIS_data.Report_cat = ddlrptype.SelectedItem.Text;
        MIS_data.Port = txtport.Text;
        MIS_data.Branch = SELECT_BRANCH;
        MIS_data.UserID = ddl_UserID.SelectedItem.Text;
        MIS_data.CusHouse = ddltr_cushouse.SelectedItem.Value;

        DataTable dt = new DataTable();
        dt = MIS_data.MIS_info();

        if (dt.Rows.Count > 0)
        {
            gvdetails.DataSource = dt;
            gvdetails.DataBind();

          
        }
        else
        {
            DataTable dtempty = new DataTable();
            gvdetails.DataSource = dtempty;
            gvdetails.DataBind();
        }
    }


    private void groupload()
    {
        DataSet ds = new DataSet();
        Company_Master Comp = new Company_Master();

        Comp.COMPANY_ID = "";
        Comp.BRANCH = "";
        Comp.flag = "Select-Group";
        ds = Comp.RetrieveAll_Groups();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlbranch.DataSource = ds.Tables[0];
            ddlbranch.DataTextField = "GROUP_NAME";
            ddlbranch.DataValueField = "GROUP_ID";
            ddlbranch.DataBind();
        }
    }

   /* private void Load_TrMode_Group()
    {
        DataSet ds = new DataSet();
        Company_Master Comp = new Company_Master();

        Comp.COMPANY_ID = "";
        Comp.BRANCH = "";
        Comp.USER_ID = ddlbranch.SelectedItem.Text;
        Comp.flag = "Get_TrMode_basedon_Groupname";
        ds = Comp.RetrieveAll_Groups();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddltr_mode.DataSource = ds.Tables[0];
            ddltr_mode.DataTextField = "MODE";
            ddltr_mode.DataValueField = "MODE";
            ddltr_mode.DataBind();
        }

        ddltr_mode.Items.Add(new ListItem("All", "All"));
    } */

    private void Load_TrMode_Group()
    {
        DataSet ds = new DataSet();
        Company_Master Comp = new Company_Master();
        Comp.COMPANY_ID = "";
        Comp.BRANCH = "";
        Comp.USER_ID = ddlbranch.SelectedItem.Text;
        Comp.flag = "Get_TrMode_basedon_Groupname";
        ds = Comp.RetrieveAll_Groups();

        ddltr_mode.Items.Clear();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddltr_mode.DataSource = ds.Tables[0];
            ddltr_mode.DataTextField = "MODE";
            ddltr_mode.DataValueField = "MODE";
            ddltr_mode.DataBind();
        }

       
        string[] required = { "Air", "Sea", "Land" };
        foreach (string m in required)
        {
            if (ddltr_mode.Items.FindByValue(m) == null)
                ddltr_mode.Items.Add(new ListItem(m, m));
        }

        ddltr_mode.Items.Insert(0, new ListItem("All", "All"));
    }

    private void Load_Doc_UserNameList()
    {
        Company_Master Comp = new Company_Master();
        DataSet ds = new DataSet();

        Comp.COMPANY_ID = "";
        Comp.BRANCH = "";
        Comp.flag = "Select-Group";
        ds = Comp.RetrieveAll_Groups();

        if (ds.Tables[2].Rows.Count > 0)
        {
            ddl_UserID.DataSource = ds.Tables[2];
            ddl_UserID.DataTextField = "USER_NAME";
            ddl_UserID.DataValueField = "USER_NAME";
            ddl_UserID.DataBind();
        }

        ddl_UserID.Items.Insert(0, "");
    }

    public void LoadGroup()
    {
        DataSet dsGrp = new DataSet();
        Comp.COMPANY_ID = "";
        Comp.flag = "Select-Group";
        dsGrp = Comp.RetrieveAll_Groups();

        if (dsGrp.Tables.Count > 0)
        {
            string groupID = "";
            if (Session["GroupID"] != null && Session["GroupID"].ToString() != "")
                groupID = Session["GroupID"].ToString();

            Load_Company_Branch(groupID);
        }
    }

    public void Load_Company_Branch(string groupid)
    {
        DataSet dsGrp = new DataSet();
        Comp.COMPANY_ID = groupid;
        Comp.BRANCH = "";
        Comp.flag = "Select-Group";
        dsGrp = Comp.RetrieveAll_Groups();

        if (dsGrp.Tables.Count > 1)
        {
            DataTable dt = dsGrp.Tables[1];
            dt.Columns.Add("CUSTOMHOUSE_AND_MODE", typeof(string),
                           "CUSTOMHOUSE + ' - ' + BRANCH_TRANSPORT_MODE");

            ddltr_cushouse.DataSource = dt;
            ddltr_cushouse.DataTextField = "CUSTOMHOUSE_AND_MODE";
            ddltr_cushouse.DataValueField = "CUSTOMHOUSE";
            //ddltr_cushouse.DataValueField = "BRANCHCODE";
            ddltr_cushouse.DataBind();

            ddltr_cushouse.Items.Insert(0, "");
        }
    }


    private void SetSingleColumnWidth(int colIndex, int widthInPixels, HorizontalAlign alignment)
    {
       
        if (gvdetails.Columns.Count > colIndex)
        {
            gvdetails.Columns[colIndex].HeaderStyle.Width = Unit.Pixel(widthInPixels);
            gvdetails.Columns[colIndex].ItemStyle.Width = Unit.Pixel(widthInPixels);
            gvdetails.Columns[colIndex].ItemStyle.HorizontalAlign = alignment;
        }

        else if (gvdetails.HeaderRow != null && colIndex < gvdetails.HeaderRow.Cells.Count)
        {
            gvdetails.HeaderRow.Cells[colIndex].Width = Unit.Pixel(widthInPixels);
            gvdetails.HeaderRow.Cells[colIndex].HorizontalAlign = alignment;

            foreach (GridViewRow row in gvdetails.Rows)
            {
                if (colIndex < row.Cells.Count)
                {
                    row.Cells[colIndex].Width = Unit.Pixel(widthInPixels);
                    row.Cells[colIndex].HorizontalAlign = alignment;
                }
            }
        }

    }

    // ── Event handlers ────────────────────────────────────────────────────────

    protected void ddlrptype_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
    }

    protected void ddltr_mode_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
    }

    protected void ddl_UserID_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
    }

    protected void ddltr_cushouse_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
    }
}