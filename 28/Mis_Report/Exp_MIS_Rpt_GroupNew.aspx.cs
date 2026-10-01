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
    Export_MIS_2 MIS_data = new Export_MIS_2();
    
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

    //int lastRowIndex = 0;
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
            //Tr_mode_load();
            //btnSearch_Click(sender, e);

            groupload();
            Load_TrMode_Group();
            Load_Doc_UserNameList();
            //Load_CustomHouse();
            LoadGroup();
        }
        
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gridBind();
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
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        #region old
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell cell = new TableCell();
            cell = e.Row.Cells[0];
            if (ddlrptype.SelectedItem.Text == "Mode" || ddlrptype.SelectedItem.Text == "SB Type")
            {
                cell.Width = new Unit("80px");
            }
            else if (ddlrptype.SelectedItem.Text == "Exporter")
            {
                // cell.Width = new Unit("150px");
                cell.Width = new Unit("250px");
            }
            else if (ddlrptype.SelectedItem.Text == "Country")
            {
                cell.Width = new Unit("200px");
            }

            cell.Style["border-right"] = "1px solid #666666";
            cell.HorizontalAlign = HorizontalAlign.Left;

            for (int i = 1; i < e.Row.Cells.Count; i++)
            {
                cell = e.Row.Cells[i];
                if (i == 1)
                {
                    cell.HorizontalAlign = HorizontalAlign.Center;

                }
                else if (i == 2)
                {
                    cell.HorizontalAlign = HorizontalAlign.Center;
                }
                else
                {
                    cell.HorizontalAlign = HorizontalAlign.Right;
                }
                /* cell.Width = new Unit("40px");*/
                cell.Style["border-right"] = "0.5px solid #666666";
            }
        }
        #endregion



        // 2. Make sure we are checking a data row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Get the text from the "Mode" column (Index 2)
            string modeText = e.Row.Cells[2].Text.Trim();

            // 3. Check if we have hit the "Total :" row
            if (modeText.StartsWith("Total"))
            {
                isTotalReached = true;
            }

            // 4. Apply styles to the Total row AND every row that comes after it
            if (isTotalReached)
            {
                // Make the entire row bold
                e.Row.Font.Bold = true;

                // Optional: Give it that grey summary background style
                //e.Row.BackColor = System.Drawing.Color.FromName("#EAEAEA");
                e.Row.BackColor = System.Drawing.Color.Blue;

                // Remove borders and text for S.No (Cell 0)
                e.Row.Cells[0].Text = "";
                e.Row.Cells[0].BorderStyle = BorderStyle.None;
                e.Row.Cells[0].BorderWidth = 0;

                // Remove borders and text for Exporter Name (Cell 1)
                e.Row.Cells[1].Text = "";
                e.Row.Cells[1].BorderStyle = BorderStyle.None;
                e.Row.Cells[1].BorderWidth = 0;
            }
        }

    }

   
    private void gridBind()
    {
        MIS_data.Jobdate = txtJobDate.Text;
        MIS_data.Exp_name = txtExpname.Text;
        MIS_data.Tr_mode = ddltr_mode.SelectedItem.Text;
        MIS_data.Branch = ddlbranch.SelectedItem.Text;
        MIS_data.SB_type = txtSBtype.SelectedItem.Text == "All" ? "" : txtSBtype.SelectedItem.Text;
        MIS_data.To_date = txttodate.Text;
        MIS_data.Country = txtcountry.Text;
        MIS_data.Report_cat = ddlrptype.SelectedItem.Text;
        MIS_data.Port = txtport.Text;
        MIS_data.Branch = SELECT_BRANCH;
        MIS_data.UserID = ddl_UserID.SelectedItem.Text;        
        MIS_data.CusHouse = ddltr_cushouse.SelectedItem.Value;//Added by George Bush on 06-06-2026 

        //DataView dv = new DataView(MIS_data.Exp_MIS_Rpt_Optimized());
        //gvdetails.DataSource = dv;

        DataTable dt = new DataTable();
        dt = MIS_data.Exp_MIS_Rpt_Optimized();


        if (dt.Rows.Count > 0 && dt.Rows.Count > 0)
        {
            gvdetails.DataSource = dt;
            gvdetails.DataBind();

            // 2. Adjust individual column sizes immediately after DataBind()
            SetGridColumnWidths();
        }
        else
        {
            DataTable dtempty = new DataTable();
            gvdetails.DataSource = dtempty;
            gvdetails.DataBind();
        }
    }



    private void Tr_mode_load()
    {
        if (Session["SELECT_TYPE"].ToString() == "Branchwise Job")
        {
            string TRANS_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();


            if (TRANS_MODE == "A")
            {
                ddltr_mode.Items.Add(new ListItem("Air", "Air"));
            }
            else if (TRANS_MODE == "S")
            {
                ddltr_mode.Items.Add(new ListItem("Sea", "Sea"));
            }
            else if (TRANS_MODE == "L")
            {
                ddltr_mode.Items.Add(new ListItem("Land", "Land"));
            }

        }
        else
        {
            ddltr_mode.Items.Add(new ListItem("All", "All"));
            ddltr_mode.Items.Add(new ListItem("Air", "Air"));
            ddltr_mode.Items.Add(new ListItem("Sea", "Sea"));
            ddltr_mode.Items.Add(new ListItem("Land", "Land"));

        }
    }

    protected void ddlrptype_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
    }
    protected void ddltr_mode_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
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

    private void Load_TrMode_Group()
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
    protected void ddl_UserID_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
    }


    protected void ddltr_cushouse_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
    }
    
    public void Load_CustomHouse()
    {
        ddltr_cushouse.Items.Clear();
        DataSet ds = new DataSet();
        ds = (DataSet)HttpContext.Current.Session["COMPANY_DETAILS_DS"];

        // if (ds.Tables.Count > 1)
        if (ds.Tables[3].Rows.Count > 0)
        {
            DataTable dt = ds.Tables[3];
            dt.Columns.Add("CUSTOMHOUSE_AND_MODE", typeof(string), "CUSTOMHOUSE_CODE + ' - ' + CUSTOMHOUSE_NAME +'('+TransMode+')'");
            //dt.Columns.Add("CUSTOMHOUSE_AND_MODE", typeof(string), "ISNULL(CUSTOMHOUSE_CODE, '') + ' - ' + ISNULL(CUSTOMHOUSE_NAME, '') + ' (' + ISNULL(TransMode, '') + ')'");


            ddltr_cushouse.DataSource = dt;
            ddltr_cushouse.DataTextField = "CUSTOMHOUSE_AND_MODE";
            //ddlSelect_Branch.DataTextField = "BRANCH_TRANSPORT_MODE";
            ddltr_cushouse.DataValueField = "BRANCHCODE";
            ddltr_cushouse.DataBind();
        }

    }
    
    public void LoadGroup()
    {

        DataSet dsGrp = new DataSet();
        Comp.COMPANY_ID = "";
        Comp.flag = "Select-Group";
        dsGrp = Comp.RetrieveAll_Groups();
       // ddlGrpname.Items.Clear();
        if (dsGrp.Tables.Count > 0)
        {
            //ddlGrpname.DataSource = dsGrp.Tables[0];
            //ddlGrpname.DataTextField = "GROUP_NAME";
            //ddlGrpname.DataValueField = "GROUP_ID";
            //ddlGrpname.DataBind();

            string groupID = "";

            if (Session["GroupID"].ToString() != "" && Session["GroupID"].ToString() != null)
            {
                groupID = Session["GroupID"].ToString();
            }
            Load_Company_Branch(groupID);
        }
    }

    public void Load_Company_Branch(string groupid)
    {
        
        DataSet dsGrp = new DataSet();
        Comp.COMPANY_ID = groupid;
        Comp.BRANCH = "";

        DataSet ds1 = (DataSet)HttpContext.Current.Session["COMPANY_DETAILS_DS"];

        Comp.flag = "Select-Group";
        dsGrp = Comp.RetrieveAll_Groups();
        if (dsGrp.Tables.Count > 1)
        {
            DataTable dt = dsGrp.Tables[1];
            dt.Columns.Add("CUSTOMHOUSE_AND_MODE", typeof(string), "CUSTOMHOUSE + ' - ' + BRANCH_TRANSPORT_MODE");

            ddltr_cushouse.DataSource = dt;
            ddltr_cushouse.DataTextField = "CUSTOMHOUSE_AND_MODE";
            ddltr_cushouse.DataValueField = "CUSTOMHOUSE";
            //ddlSelect_Branch.DataTextField = "BRANCH_TRANSPORT_MODE";
            //ddltr_cushouse.DataValueField = "BRANCHCODE";
            ddltr_cushouse.DataBind();

            ddltr_cushouse.Items.Insert(0, "");
        }
        

    }

    private void SetGridColumnWidths()
    {
        // Check if the GridView actually has columns before modifying them
        if (gvdetails.HeaderRow != null)
        {
            // Format: SetWidth(ColumnIndex, PixelWidth, HorizontalAlignment)
            SetSingleColumnWidth(0, 50, HorizontalAlign.Center);   // S. No
            SetSingleColumnWidth(1, 250, HorizontalAlign.Left);    // Exporter Name
            SetSingleColumnWidth(2, 60, HorizontalAlign.Center);   // Mode 
            SetSingleColumnWidth(3, 100, HorizontalAlign.Right);    // Jobs Handled 80
            SetSingleColumnWidth(4, 110, HorizontalAlign.Right);    // No Of Containers 90
            SetSingleColumnWidth(5, 75, HorizontalAlign.Right);    // 20 Feet 50
            SetSingleColumnWidth(6, 75, HorizontalAlign.Right);    // 40 Feet 50
            SetSingleColumnWidth(7, 75, HorizontalAlign.Right);    // 45 Feet 50
            SetSingleColumnWidth(8, 100, HorizontalAlign.Right);    // No Of Packages 90
            SetSingleColumnWidth(9, 85, HorizontalAlign.Right);    // Tonnage 80
            SetSingleColumnWidth(10, 100, HorizontalAlign.Right);  // PMV Value 110
            SetSingleColumnWidth(11, 110, HorizontalAlign.Right);  // FOB Value 130 110
        }
    }
    private void SetSingleColumnWidth(int colIndex, int widthInPixels, HorizontalAlign alignment)
    {
        if (gvdetails.Columns.Count > colIndex)
        {
            // For explicitly declared <asp:BoundField> columns
            gvdetails.Columns[colIndex].HeaderStyle.Width = Unit.Pixel(widthInPixels);
            gvdetails.Columns[colIndex].ItemStyle.Width = Unit.Pixel(widthInPixels);
            gvdetails.Columns[colIndex].ItemStyle.HorizontalAlign = alignment;
        }
        else
        {
            // For dynamically auto-generated columns (AutoGenerateColumns="True")
            gvdetails.HeaderRow.Cells[colIndex].Width = Unit.Pixel(widthInPixels);
            gvdetails.HeaderRow.Cells[colIndex].HorizontalAlign = alignment;

            foreach (GridViewRow row in gvdetails.Rows)
            {
                row.Cells[colIndex].Width = Unit.Pixel(widthInPixels);
                row.Cells[colIndex].HorizontalAlign = alignment;
            }
        }
    }

    
}