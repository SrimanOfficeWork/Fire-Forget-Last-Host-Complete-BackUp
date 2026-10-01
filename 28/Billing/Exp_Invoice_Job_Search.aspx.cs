using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Billing_Exp_Invoice_Job_Search : ThemeClass
{
    AppSession aps = new AppSession();
    //Export_BL_Multiple EBM = new Export_BL_Multiple();
    Billing_Exp_Invoice BI = new Billing_Exp_Invoice();

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
    public string SELECT_TYPE, SELECT_BRANCH;


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
            load_Exp_name();
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
         
         string jobno = string.Empty;
         string rowID = String.Empty;

         if (e.Row.RowType == DataControlRowType.DataRow)
         {
             string values = this.gvdetails.DataKeys[e.Row.RowIndex]["Jobno"].ToString();
             string Bill_invno = this.gvdetails.DataKeys[e.Row.RowIndex]["Invoice_No"].ToString();
             
             e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
             e.Row.Attributes.Add("ondblclick", "open_Inv_Job_Search_Update('" + values + "','" + Bill_invno + "')");

            // jobno = this.gvdetails.DataKeys[e.Row.RowIndex]["JOBNO"].ToString();

             rowID = e.Row.RowIndex.ToString();
             e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);
             e.Row.Attributes.Add("onclick", "ChangeRowColor('" + rowID + "','" + values + "','" + Bill_invno + "')");
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
             else if (TRANS_MODE == "L")
             {
                 ddlmode.Items.Add(new ListItem("Land", "Land"));
             }
         }
         else
         {
             ddlmode.Items.Add(new ListItem("", ""));
             ddlmode.Items.Add(new ListItem("Air", "Air"));
             ddlmode.Items.Add(new ListItem("Sea", "Sea"));
             ddlmode.Items.Add(new ListItem("Land", "Land"));
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

             ddljobno.Items.Clear();
             ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
             ddljobno.SelectedIndex = 0;
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
     private void load_Exp_name()
     {
         if (ddlbranch.SelectedItem.Text != "")
         {
             DataSet dss = new DataSet();
             BI.Mode = ddlmode.SelectedItem.Text;
             BI.Branch = ddlbranch.SelectedItem.Text;
             BI.Branch_Type = SELECT_BRANCH;
             BI.Mflag = "Inv_Exp_Name_Select";

             dss = BI.Select_Exp_INV();

             ddlExp_name.DataSource = dss.Tables[0];
             ddlExp_name.DataTextField = "Exp_Name";
             ddlExp_name.DataValueField = "Exp_Name";
             ddlExp_name.DataBind();
             ddlExp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
             ddlExp_name.SelectedIndex = 0;
         }
         else
         {
             ddlExp_name.Items.Clear();
             ddlExp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
             ddlExp_name.SelectedIndex = 0;

             ddljobno.Items.Clear();
             ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
             ddljobno.SelectedIndex = 0;
         }


         
     }
     protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
     {
         load_Exp_name();
     }
     private void load_Jobno()
     {
         if (ddlExp_name.SelectedItem.Text != "")
         {
             DataSet dss = new DataSet();
             BI.Mode = ddlmode.SelectedItem.Text;
             BI.Branch = ddlbranch.SelectedItem.Text;
             BI.Branch_Type = SELECT_BRANCH;
             BI.Mflag = "Inv_Exp_Jobno_Select";
             BI.Exp_Name = ddlExp_name.SelectedItem.Text;
             dss = BI.Select_Exp_INV();

             ddljobno.DataSource = dss.Tables[0];
             ddljobno.DataTextField = "JOBNO";
             ddljobno.DataValueField = "JOBNO";
             ddljobno.DataBind();
             ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
             ddljobno.SelectedIndex = 0;
         }
         else
         {
             ddljobno.Items.Clear();
             ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
             ddljobno.SelectedIndex = 0;
         }
        
     }
     protected void ddlExp_name_SelectedIndexChanged(object sender, EventArgs e)
     {
         load_Jobno();
         btnSearch_Click(sender, e);
     }

     private void Load_Grid()
     {
         string ss = ddljobno.SelectedItem.Text;
         BI.Ac_Branch = ddlbranch.SelectedItem.Text;
         BI.Exp_Name = ddlExp_name.SelectedItem.Text;
         BI.JOBNO = ddljobno.SelectedItem.Text; 
         BI.from_date = txtfromdate.Text;
         BI.todate = txttodate.Text;
         BI.Mode = ddlmode.SelectedItem.Text;
         BI.Branch = SELECT_BRANCH;
         BI.Flag = "Grid_Search";

         gvdetails.DataSource = BI.BILL_EXPORT_JOB_INV_SEARCH();
         gvdetails.DataBind();
     }
     protected void ddljobno_SelectedIndexChanged(object sender, EventArgs e)
     {
         Load_Grid();
     }
}