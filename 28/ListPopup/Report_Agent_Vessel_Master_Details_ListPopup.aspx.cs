using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Report_Agent_Vessel_Master_Details_ListPopup : ThemeClass
{
    public int currentPageNumber;
    public double totalRows;
    public const int PAGESIZE = 10;
    eroyalmaster erm = new eroyalmaster();
    Rpt_Client_Master Rpt_Clt = new Rpt_Client_Master();
    DataSet ds = new DataSet();
    string str;
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    string SP_QUERY;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search, CLIENT_TYPE;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        //if (Session["STANDARD_TYPE"] != null)
        //{
        //    STANDARD_TYPE = Session["STANDARD_TYPE"].ToString();
        //}

        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (hdn_A_to_Z_Search.Value != "")
        {
            Name_Search = hdn_A_to_Z_Search.Value;
        }
        else
        {
            Name_Search = txtClinetName.Text;
        }
        if (Request.QueryString["seller_id"] != "" || Request.QueryString["seller_id"] != null)
        {
            CLIENT_TYPE = Request.QueryString["seller_id"].ToString();
        }

        //hdn_A_to_Z_Search.Value = "";
        //----------------------------A to Z SEARCH OPTION--------------------------//
        if (!string.IsNullOrEmpty(Request["seller_id"]))
        {
            
            hdn.Value = Request.QueryString["seller_id"].ToString();
            hdn.Value= hdn.Value.Trim();
            if (hdn.Value.Length == 10)
            {
                txtBranchNO.Text = hdn.Value;
            }                 
        }
        
        if (!IsPostBack)
        {
            int pageno = 1;

            gridbind(pageno);
            int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
            Add_Pageno(ii);        
        }
    }


    private void gridbind(int currentPageNumber1)
    {
        Rpt_Clt.RPT_ID = "0";
        Rpt_Clt.CLIENT_NAME = Name_Search;
        Rpt_Clt.CLIENT_BRSLNO = txtBranchNO.Text;
        Rpt_Clt.Ename = "select_con_Rpt_AgentVessel";
        Rpt_Clt.CLIENT_BRANCH_CODE = txtBranchNO.Text;
        Rpt_Clt.CLIENT_WORKING_PERIOD = Working_Period;
        Rpt_Clt.CLIENT_TYPE = CLIENT_TYPE.Replace("_","");

        Rpt_Clt.startRowIndex = Convert.ToString(currentPageNumber1);
        Rpt_Clt.maximumRows = Convert.ToString(gvdetails.PageSize);
        
        ds = Rpt_Clt.RetrieveAll_Rpt_Client_Details();

        gvdetails.DataSource = ds;
        gvdetails.DataBind();
        Grid_Total(currentPageNumber1, Rpt_Clt.result);

    }

    private int CalculateTotalPages(double totalRows)
    {
        int totalPages = (int)Math.Ceiling(totalRows / gvdetails.PageSize);
        return totalPages;
    }
    protected void btnSearchAll_Click(object sender, EventArgs e)
    {
        txtClinetName.Text = "";
        txtBranchNO.Text = "";

        Name_Search = "";
        btnSearch_Click(sender, e);
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
        //BindData(currentpagenumber2);
        //General_GridBind(currentpagenumber2);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int pageno = 1;

        string A_Z = Hdn_GetValue.Value;

        if (A_Z == "A_Z")
        {
            Hdn_GetValue.Value = "";
        }
        else
        {
            Name_Search = txtClinetName.Text;
            hdn_A_to_Z_Search.Value = "";
        }

        gridbind(pageno);
        int ii = CalculateTotalPages(double.Parse(lblTotalPages.Text));
        Add_Pageno(ii);
    }
    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        Date_Time rep = new Date_Time();

        //string str = rep.Replace(gvdetails.SelectedRow.Cells[1].Text);
        //string str1 = rep.Replace(gvdetails.SelectedRow.Cells[2].Text);
        //string str2 = rep.Replace(gvdetails.SelectedRow.Cells[3].Text);
        //string str3 = rep.Replace(gvdetails.SelectedRow.Cells[4].Text);
        //string str4 = rep.Replace(gvdetails.SelectedRow.Cells[5].Text);
        //string str5 = rep.Replace(gvdetails.SelectedRow.Cells[6].Text);
        //string str6 = rep.Replace(gvdetails.SelectedRow.Cells[7].Text);

        Rpt_Clt.RPT_ID = "0";
        Rpt_Clt.CLIENT_NAME = rep.Replace(gvdetails.SelectedRow.Cells[1].Text);
        Rpt_Clt.CLIENT_BRANCH_CODE = rep.Replace(gvdetails.SelectedRow.Cells[2].Text);
        Rpt_Clt.CLIENT_BRSLNO = "";
        Rpt_Clt.Ename = "Bind_Gridview_Details_AGENT";
        Rpt_Clt.CLIENT_WORKING_PERIOD = Working_Period;
        Rpt_Clt.CLIENT_TYPE = CLIENT_TYPE.Replace("_", "");


        ds = Rpt_Clt.RetrieveAll_Rpt_Client_Details();

        string str = ds.Tables[0].Rows[0]["AGENT_NAME"].ToString();
        string str1 = ds.Tables[0].Rows[0]["AGENT_ADD1"].ToString();
        string str2 = ds.Tables[0].Rows[0]["AGENT_ADD2"].ToString();
        string str3 = ds.Tables[0].Rows[0]["AGENT_ADD3"].ToString();
        string str4 = ds.Tables[0].Rows[0]["AGENT_ADD4"].ToString();
        string str5 = ds.Tables[0].Rows[0]["AGENT_COUNTRY_NAME"].ToString();
        string str6 = ds.Tables[0].Rows[0]["AGENT_PINCODE"].ToString();
        string str7 = ds.Tables[0].Rows[0]["AGENT_GSTN_NO"].ToString();


        if (hdn.Value == "Agent")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ExporterDetails('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7 + "')", true);
        }

        else if (hdn.Value == "Agent_")
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:GetRowValue_ExporterDetails_Multiple('" + str + "','" + str1 + "','" + str2 + "','" + str3 + "','" + str4 + "','" + str5 + "','" + str6 + "','" + str7 + "')", true);
        }
        else
        { }
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";

            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex);

            var des0 = e.Row.Cells[3].Text.Replace("&amp;", "&");
            var des1 = e.Row.Cells[4].Text.Replace("&amp;", "&");
            var des2 = e.Row.Cells[5].Text.Replace("&amp;", "&");
            var des3 = e.Row.Cells[6].Text.Replace("&amp;", "&");

            if (des0.Length > 25)
            {
                e.Row.Cells[3].Text = des0.Substring(0, 25) + "...";
                e.Row.Cells[3].ToolTip = des0;
                //hdn_add1.Value = des0;
            }
            if (des1.Length > 25)
            {
                e.Row.Cells[4].Text = des1.Substring(0, 25) + "...";
                e.Row.Cells[4].ToolTip = des1;
                //hdn_add1.Value = des0;
            }
            if (des2.Length > 25)
            {
                e.Row.Cells[5].Text = des2.Substring(0, 25) + "...";
                e.Row.Cells[5].ToolTip = des2;
                //hdn_add1.Value = des0;
            }
            if (des3.Length > 25)
            {
                e.Row.Cells[6].Text = des3.Substring(0, 25) + "...";
                e.Row.Cells[6].ToolTip = des3;
                //hdn_add1.Value = des0;
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
        // get the total rows
        //totalRows = (double)Admin_mas.Total_Rows;

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
        if (ViewState["selected_change"] == "1")
        {
        }
        else
            Add_Pageno(ii);
    }
    ///auto search
    [System.Web.Services.WebMethod]
    public static string GetClient_Name(string txtIec_Code)
    {
        string Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        string ADCODE_BANK_ACCOUNT_NO = "";
        if (txtIec_Code.Length == 10)
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            // custid = Auto.Country_Master_FromClientSide_Calling(custid);
            eroyalmaster erm = new eroyalmaster();
            erm.Eadcodeid = "0";
            erm.ADCODE_IEC_ADCODE = "";
            erm.ADCODE_IEC_CODE = txtIec_Code;
            erm.Ename = "Get_Adcode";
            erm.EWorking_Period = Working_Period;

            ds = erm.RetrieveAll_Adcode_MASTER();
            if (ds.Tables[0].Rows.Count > 0)
            {

                txtIec_Code = ds.Tables[0].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                ADCODE_BANK_ACCOUNT_NO = ds.Tables[0].Rows[0]["ADCODE_BANK_ACCOUNT_NO"].ToString();

            }
            else
            {
                txtIec_Code = "";
            }

        }
        else
        {
            txtIec_Code = "";
        }
        return txtIec_Code = txtIec_Code + "~~" + ADCODE_BANK_ACCOUNT_NO;
    }
    ///auto search
}