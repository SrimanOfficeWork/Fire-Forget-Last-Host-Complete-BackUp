using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Billing_Quotation_Master_Search_New : ThemeClass
{
    AppSession aps = new AppSession();
    Billing_Imp_Invoice BI = new Billing_Imp_Invoice();
    Quotation_Master QM = new Quotation_Master();
    Auto_Search AS = new Auto_Search();
    DataSet ds = new DataSet();

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
    public string SELECT_TYPE, SELECT_BRANCH;

    string[] arr = new string[] { };
    string[] arr_Month = new string[] { };

    string Start_date = string.Empty;
    string End_date = string.Empty;

    string From_month = string.Empty;
    string To_month = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
                HDBranch.Value = SELECT_BRANCH;
            }
            else
            {
                SELECT_BRANCH = "";
                HDBranch.Value = SELECT_BRANCH;
            }
        }
        else
        {
            SELECT_BRANCH = "";
            HDBranch.Value = SELECT_BRANCH;
        }
        hdrowindex.Value = String.Empty;
        hdBill_invno.Value = String.Empty;

        if (!IsPostBack)
        {
            Company_Branch_details();
            Tr_mode_load();
            //Load_Month();
            Load_Client_Name();

            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();

            btnSearch_Click(sender, e);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Load_Grid();
    }
     private void Load_Grid()
     {
         /*
         if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
         {
             QM.from_date = txtfromdate.Text;
             QM.todate = txttodate.Text;
         }
         else
         {
             if (ddlmonth.SelectedItem.Text != string.Empty)
             {
                 arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                 QM.from_date = arr_Month[0];
                 QM.todate = arr_Month[1];
             }
             else
             {
                 QM.from_date = txtfromdate.Text;
                 QM.todate = txttodate.Text;
             }
         }
         */
         QM.from_date = txtfromdate.Text;
         QM.todate = txttodate.Text;

         QM.Client_name = ddlClient_Name.SelectedItem.Text;
         QM.Module_name = ddlmode.SelectedItem.Text;
         QM.BRANCH_CODE = ddlbranch.SelectedItem.Text;
         ds = QM.BILL_Quotation_Master_Search();
         if (ds.Tables[0].Rows.Count > 0)
         {
           gvdetails.DataSource = ds;
           gvdetails.DataBind();
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

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string jobno = string.Empty;
        string rowID = String.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Module = this.gvdetails.DataKeys[e.Row.RowIndex]["MODULE"].ToString();
            string Client_Name = this.gvdetails.DataKeys[e.Row.RowIndex]["CLIENT_NAME"].ToString();
            string Sh_Type = this.gvdetails.DataKeys[e.Row.RowIndex]["SHIPMENT_TYPE"].ToString();
            string Branch_No = this.gvdetails.DataKeys[e.Row.RowIndex]["BRANCH_NO"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("ondblclick", "open_Quotation_Search_Update('" + Module + "','" + Server.UrlEncode(Client_Name) + "','" + Sh_Type + "','" + Branch_No + "')");
            
            rowID = e.Row.RowIndex.ToString();
            e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
            e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + Module + "','" + Client_Name + "')");
        }
    }
    private void Tr_mode_load()
    {
        if (SELECT_BRANCH != "")
        {
            string TRANS_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();
            if (TRANS_MODE == "A")
            {
                ddlmode.Items.Add(new ListItem("Air Import", "Air-Import"));
                ddlmode.Items.Add(new ListItem("Air Export", "Air-Export"));
            }
            else if (TRANS_MODE == "S")
            {
                ddlmode.Items.Add(new ListItem("Sea Import", "Sea-Import"));
                ddlmode.Items.Add(new ListItem("Sea Export", "Sea-Export"));
            }
            else if (TRANS_MODE == "L")
            {
                ddlmode.Items.Add(new ListItem("Land Import", "Land-Import"));
                ddlmode.Items.Add(new ListItem("Land Export", "Land-Export"));
            }
            //ddlmode.Items.Add(new ListItem("Other", "O"));
        }
        else
        {
            ddlmode.Items.Add(new ListItem("", ""));
            ddlmode.Items.Add(new ListItem("Air Import", "AI"));
            ddlmode.Items.Add(new ListItem("Air Export", "AE"));
            ddlmode.Items.Add(new ListItem("Sea Import", "SI"));
            ddlmode.Items.Add(new ListItem("Sea Export", "SE"));
            ddlmode.Items.Add(new ListItem("Land Import", "LI"));
            ddlmode.Items.Add(new ListItem("Land Export", "LE"));
          //ddlmode.Items.Add(new ListItem("Other", "O"));
        }
    }

    private void Company_Branch_details()
    {

        if (SELECT_BRANCH != "")
        {
            DataSet dss = new DataSet();
            DataTable table = new DataTable("MyTable");
            table.Columns.Add("Branch", typeof(string));

            string[] names = { SELECT_BRANCH };
            DataRow dr;
            for (int i = 0; i < names.Length; i++)
            {
                dr = table.NewRow();
                dr["Branch"] = names[i];
                table.Rows.Add(dr);
            }

            //up to here!

            //this is:
            dss.Tables.Add(table);
            ddlbranch.DataSource = dss.Tables["MyTable"];
            ddlbranch.DataTextField = dss.Tables[0].Columns["Branch"].ToString();
            ddlbranch.DataValueField = dss.Tables[0].Columns["Branch"].ToString();
            ddlbranch.DataBind();

        }
        else
        {

            DataSet dss = new DataSet();
            dss = (DataSet)Session["COMPANY_DETAILS_DS"];

            Company_Master Comp = new Company_Master();

            ddlbranch.SelectedIndex = -1;
            Comp.COMPANY_ID = "0";
            Comp.COMPANY_LICENSE = dss.Tables[0].Rows[0][3].ToString();
            Comp.CLIENT_NAME = "";
            Comp.CONTACT_PERSON = "";
            Comp.MOBILE_NO = "";
            Comp.Ename = "select_Company_Login_Details";
            Comp.startRowIndex = "0";
            Comp.maximumRows = "0";
            DataSet ds = new DataSet();
            ds = Comp.RetrieveAll_Company_Details();

            ddlbranch.DataTextField = ds.Tables[1].Columns["Branch"].ToString();
            ddlbranch.DataValueField = ds.Tables[1].Columns["Branch"].ToString();

            ddlbranch.DataSource = ds.Tables[1];
            ddlbranch.DataBind();
            ddlbranch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlbranch.SelectedIndex = 0;
        }
    }
    /*
    private void Load_Month()
    {
        DataSet ds = new DataSet();
        arr = Working_Period.Split('-');
        Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
        End_date = arr[3] + '-' + arr[4] + '-' + arr[5];

        BI.from_date = Start_date;
        BI.todate = End_date;
        BI.Flag = "Month";

        ds = BI.IMP_EXP_Month();

        ddlmonth.DataSource = ds.Tables[0];
        ddlmonth.DataTextField = "TheMonth";
        ddlmonth.DataValueField = "TheMonth_No";
        ddlmonth.DataBind();

        ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
        ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
    }
    */
    private void Load_Client_Name()
    {
        AS.Name_Search = ddlmode.SelectedItem.Text;
        AS.Branch = SELECT_BRANCH;
        AS.Flag = "Client_Name_Master_Select";
        ds = AS.Export_Billing_Mastersearch();

        ddlClient_Name.DataSource = ds.Tables[0];
        ddlClient_Name.DataTextField = "CLIENT_NAME";
        ddlClient_Name.DataValueField = "CLIENT_NAME";
        ddlClient_Name.DataBind();

        ddlClient_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlClient_Name.SelectedIndex = 0;
    }
    protected void ddlmode_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Client_Name();
        Load_Grid();
    }
}