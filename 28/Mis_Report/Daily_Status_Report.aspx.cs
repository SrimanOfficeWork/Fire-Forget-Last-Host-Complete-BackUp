using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using GeneraReport;
using Microsoft.Reporting.WebForms;
using System.Windows.Forms;
//using System.Data.SqlClient.SqlGen;
using System.Net;
using System.Net.Mail;

public partial class DSR : ThemeClass
{
    
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string Company_ID;
    public string LoginDate;
    
    public string SELECT_TYPE, SELECT_BRANCH;

    AppSession aps = new AppSession();
    DailyStatusRpt DSR1 = new DailyStatusRpt();
    ErrorLogs err = new ErrorLogs();

    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Company_ID = Session["COMPANY_ID"].ToString();


        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
           // commented for areawise implementation on 05-mar-2020
        /*
        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
            }
            else
            {
                SELECT_BRANCH = "";
                if (!IsPostBack)
                {
                    Bind_ClientMasterName();
                    Bind_Branches();
                }
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }
          * */
        SELECT_BRANCH = Connection.Get_Company_Type();

        if (!IsPostBack)
        {
            Bind_ClientMasterName();
            Bind_Branches();
            //Data_Bind();
        }
    }

    public void Bind_Branches()
    {
        string id = Company_ID;

        DSR1.companyId = id;
        DSR1.Ename = "Bind_Branches";
        ds = DSR1.DS_Report();

        ddlSelect_Branch.DataSource = ds.Tables[0];
        ddlSelect_Branch.DataTextField = "BRANCH";
        ddlSelect_Branch.DataValueField = "BRANCH";
        ddlSelect_Branch.DataBind();

        if (SELECT_BRANCH == currentbranch)
        {
            ddlSelect_Branch.Text = currentbranch;
           
        }
        else
        {
            ddlSelect_Branch.Items.Remove("0");
            ddlSelect_Branch.Items.Insert(0, "All");
        }

    }

    public void Bind_ClientMasterName()
    {
        DSR1.Ename = "Bind_IMP_EXP_Name";
        ds = DSR1.DS_Report();

        ddlCutomerName.DataSource = ds.Tables[0];
        ddlCutomerName.DataTextField = "IMP_EXP_NAME";
        ddlCutomerName.DataValueField = "IMP_EXP_NAME";
        ddlCutomerName.DataBind();
        ddlCutomerName.Items.Remove("0");
        ddlCutomerName.Items.Insert(0, "All");  

    }

    public void Data_Bind()
    {
        string ClientNm=string.Empty;
        ClientNm = ddlCutomerName.SelectedItem.Text;
        Session["ClientNm"] = ClientNm;

        DSR1.ClientName = ddlCutomerName.SelectedItem.Text;
        DSR1.Job_type = "Import";
        HiddenField1_Jobtype.Value = "Import";
        DSR1.Tr_mode = ddlTransportMode.SelectedItem.Text;
        DSR1.Fromdate = txtFrom_Date.Text;
        DSR1.To_date = txtTo_Date.Text;
        DSR1.Branch = ddlSelect_Branch.SelectedItem.Text;
   
        DataView dv = new DataView(DSR1.DS_Report_Stmt());
        GV_Details.DataSource = dv;
        GV_Details.DataBind();

       
            #region without slno
           
            GV_Details.HeaderRow.Cells[0].Text = "JobNo";
            GV_Details.HeaderRow.Cells[1].Text = "JobDate";
            GV_Details.HeaderRow.Cells[2].Text = "Importer Name";

            GV_Details.HeaderRow.Cells[3].Text = "MABL No";
            GV_Details.HeaderRow.Cells[4].Text = "MABL Date";
            GV_Details.HeaderRow.Cells[5].Text = "HAWB NO";
            GV_Details.HeaderRow.Cells[6].Text = "HAWB Date";

            GV_Details.HeaderRow.Cells[7].Text = "BE No";
            GV_Details.HeaderRow.Cells[8].Text = "BE Date";

            GV_Details.HeaderRow.Cells[9].Text = "Invoice No";
            GV_Details.HeaderRow.Cells[10].Text = "Invoice Date";
            GV_Details.HeaderRow.Cells[11].Text = "Total Inv Value";
            GV_Details.HeaderRow.Cells[12].Text = "Inv Currency";
            GV_Details.HeaderRow.Cells[13].Text = "Ex-Rate";

            GV_Details.HeaderRow.Cells[14].Text = "Product Description";
            GV_Details.HeaderRow.Cells[15].Text = "Quantity";
            GV_Details.HeaderRow.Cells[16].Text = "Unit";
            GV_Details.HeaderRow.Cells[17].Text = "Unit Price";
            GV_Details.HeaderRow.Cells[18].Text = "CTH No";
            GV_Details.HeaderRow.Cells[19].Text = "CIF Amount";
            GV_Details.HeaderRow.Cells[20].Text = "Total Ass.Value";

            GV_Details.HeaderRow.Cells[21].Text = "Total CVD";
            GV_Details.HeaderRow.Cells[22].Text = "Total SAD Duty";
            GV_Details.HeaderRow.Cells[23].Text = "Total Duty";
            GV_Details.HeaderRow.Cells[24].Text = "PL";
            GV_Details.HeaderRow.Cells[25].Text = "BU";
            GV_Details.HeaderRow.Cells[26].Text = "Debit Value";
            GV_Details.HeaderRow.Cells[27].Text = "Qty";

            #endregion without slno
      

        if (dv.Count == 0)
        {
            Alert_msg("No Records");
        }
    }

    protected void GV_Details_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
            e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Left;
            e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Left;

            if (e.Row.RowIndex == 0)
                e.Row.Style.Add("height", "30px");

        }
        
    }

    protected void GV_Details_RowCreated(object sender, GridViewRowEventArgs e)
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

    protected void GV_Details_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Details.PageIndex = e.NewPageIndex;
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Daily Status Report', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtFrom_Date.Text != "" && txtTo_Date.Text == "" || txtFrom_Date.Text != null && txtTo_Date.Text == null)
        {
            date_check(txtFrom_Date.Text);
        }

        else if (txtTo_Date.Text != "" && txtFrom_Date.Text == "" || txtTo_Date.Text != null && txtFrom_Date.Text == null)
        {
            date_check(txtTo_Date.Text);
        }

        else if (txtFrom_Date.Text == "" && txtTo_Date.Text == "" || txtFrom_Date.Text == null && txtTo_Date.Text == null)
        {
            Data_Bind();
        }
        else if (txtFrom_Date.Text != "" && txtTo_Date.Text != "" || txtFrom_Date.Text != null && txtTo_Date.Text != null)
        {
            date_check(txtFrom_Date.Text);
        }
    }

    protected void ddlCutomerName_SelectedIndexChanged(object sender, EventArgs e)
    {
        Data_Bind();

    }
    public void date_check(string val)
    {
        var datee = val;
        var year = DateTime.Now.ToString();

        string[] y1 = year.Split('/');
        string a1 = y1[2];

        string[] y2 = a1.Split(' ');
        string a2 = y2[0];
        int y3 = Convert.ToInt32(a2);

        string[] d1 = datee.Split('/');

        string p1 = d1[0];
        string p2 = d1[1];
        string p3 = d1[2];

        int dd = Convert.ToInt32(p1);
        int mm = Convert.ToInt32(p2);
        int yyyy = Convert.ToInt32(p3);

        if (dd <= 31 && mm <= 12 && yyyy <= y3)
        {
            Data_Bind();
        }
        else
        {
            Alert_msg("Date Invalid");
        }
    }
}