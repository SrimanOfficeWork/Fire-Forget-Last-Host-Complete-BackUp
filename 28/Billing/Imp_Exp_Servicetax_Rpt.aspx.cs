using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Billing_Imp_Invoice_Job_Search : ThemeClass
{
    AppSession aps = new AppSession();


    Bill_Imp_Exp_Servicetax_Rpt rpt = new Bill_Imp_Exp_Servicetax_Rpt();

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
            btnSearch_Click(sender, e);
           
        }
    }
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        Load_Grid();
       
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
      
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";

            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex);

        }

    }

    private void Tr_mode_load()
    {
        if (SELECT_BRANCH != "")
        {
            string TRANS_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();

            if (TRANS_MODE == "A")
            {
                ddlmode.Items.Add(new ListItem("Air", "Air"));
            }
            else if (TRANS_MODE == "S")
            {
                ddlmode.Items.Add(new ListItem("Sea", "Sea"));
            }
            //else if (TRANS_MODE == "L")
            //{
            //    ddlmode.Items.Add(new ListItem("Land", "Land"));
            //}
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
            

        }
        else
        {

            DataSet dss = new DataSet();
            dss = (DataSet)Session["COMPANY_DETAILS_DS"];

            Company_Master Comp = new Company_Master();


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

        }
    }

    private void Load_Grid()
    {
        DataSet ds1 = new DataSet();
        if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
        {
            rpt.from_date = txtfromdate.Text;
            rpt.todate = txttodate.Text;
            rpt.MODULE = ddl_Imp_Exp.SelectedItem.Text;

            rpt.Mode = ddlmode.SelectedItem.Text;
            rpt.Branch = SELECT_BRANCH;
            
            rpt.Flag = "Grid_Search";

            ds1 = rpt.Bill_Imp_Exp_Servicetax_Report_Details();
            gvdetails.DataSource = ds1.Tables[0];
            gvdetails.DataBind();

        }
     
    }

    protected void ddl_Imp_Exp_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Grid();
    }
    protected void ddlmode_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Grid();
    }
}