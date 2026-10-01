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
    Billing_Exp_Invoice BI = new Billing_Exp_Invoice();

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
                HDBranch.Value = string.Empty;
            }
        }
        else
        {
            SELECT_BRANCH = "";
            HDBranch.Value = string.Empty;
        }
        hdrowindex.Value = String.Empty;
        hdBill_invno.Value = String.Empty;

        if (!IsPostBack)
        {
            Load_Month();
            Company_Branch_details();
            Tr_mode_load();
            Load_Billstatue();
            load_Exp_name();
            chk();
            btnSearch_Click(sender, e);
            load_Pending_Job_Cnt();
        }
        
    }
    private void load_Pending_Job_Cnt()
    {
        Quotation_Master QM = new Quotation_Master();
        DataSet ds1 = new DataSet();
        QM.MODULE = "E";
        QM.flag = "Pending_Job_cnt";
        QM.Branch_Common = SELECT_BRANCH;
        ds1 = QM.PENDING_INVOICE();
        if (ds1.Tables[0].Rows.Count > 0)
        {
            lblcnt.Text = ds1.Tables[0].Rows[0][0].ToString();
        }
        else
        {
            lblcnt.Text = "0";
        }
    }
    private void chk()
    {
        if (chkqs.Checked == true)
        {
            ddltype.Enabled = true;
            txtsearch.Enabled = true;
        }
        else
        {
            ddltype.Enabled = false;
            txtsearch.Enabled = false;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (chkqs.Checked == true && ddltype.SelectedItem.Value !="0" && txtsearch.Text !=string.Empty )
        {
            DataSet dss = new DataSet();
            BI.Mode = ddlmode.SelectedItem.Text;
            BI.Branch = "";
            BI.JOBNO = ddltype.SelectedValue.ToString();
            BI.Branch_Type = SELECT_BRANCH;
            BI.Mflag = "Exp_Master_Quick_Search";
            BI.Exp_Name = txtsearch.Text;
            BI.BILL_STATUS = ddl_Bill_status.SelectedValue.ToString();
            dss = BI.Select_Exp_INV_QS();

            gvdetails.DataSource = dss.Tables[0];
            gvdetails.DataBind();

            if (dss.Tables[1].Rows.Count > 0)
            {
                Session["Bill_EXP_MASTER_XL"] = dss.Tables[1];
            }
            if (dss.Tables[2].Rows.Count > 0)
            {
                Session["Bill_EXP_MASTER_Tally"] = dss.Tables[2];
            }

            if (dss.Tables[3].Rows.Count > 0)
            {
                lbljobcnt.Text = dss.Tables[3].Rows[0][0].ToString();
                lblpending_cnt.Text = dss.Tables[3].Rows[0][1].ToString();
                lblCancelled_cnt.Text = dss.Tables[3].Rows[0][2].ToString();
                lblCompleted_cnt.Text = dss.Tables[3].Rows[0][3].ToString();
            }
        }
        else
        {
            Load_Grid();
            txtsearch.Text = string.Empty;
            chkqs.Checked = false;
            ddltype.SelectedIndex = -1;
            Session.Remove("Bill_EXP_MASTER_XL");
            Session.Remove("Bill_EXP_MASTER_Tally");
        }
        chk();
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
             string values = this.gvdetails.DataKeys[e.Row.RowIndex]["FILE_REF_NO"].ToString();
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

             ddlinvno.Items.Clear();
             ddlinvno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
             ddlinvno.SelectedIndex = 0;
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

             ddljobno.Items.Clear();
             ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
             ddljobno.SelectedIndex = 0;

             ddlinvno.Items.Clear();
             ddlinvno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
             ddlinvno.SelectedIndex = 0;
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
             ddljobno.DataTextField = "FILE_REF_NO";
             ddljobno.DataValueField = "FILE_REF_NO";
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
         DataSet ds1=new DataSet();
         if (txtfromdate.Text != string.Empty || txttodate.Text != string.Empty)
         {
             BI.from_date = txtfromdate.Text;
             BI.todate = txttodate.Text;
         }
         else
         {
             if (ddlmonth.SelectedItem.Text != string.Empty)
             {
                 arr_Month = ddlmonth.SelectedValue.ToString().Split('-');
                 BI.from_date = arr_Month[0];
                 BI.todate = arr_Month[1];
             }
             else
             {
                 BI.from_date = txtfromdate.Text;
                 BI.todate = txttodate.Text;
             }
         }

         string ss = ddljobno.SelectedItem.Text;
         BI.Ac_Branch = ddlbranch.SelectedItem.Text;
         BI.Exp_Name = ddlExp_name.SelectedItem.Text;
         BI.JOBNO = ddljobno.SelectedItem.Text; 
         //BI.from_date = txtfromdate.Text;
         //BI.todate = txttodate.Text;
         BI.Mode = ddlmode.SelectedItem.Text;
         BI.Branch = SELECT_BRANCH;
         BI.Bill_No = ddlinvno.SelectedItem.Text;
         BI.BILL_STATUS = ddl_Bill_status.SelectedValue.ToString();
         BI.Flag = "Grid_Search";
         ds1=BI.BILL_EXPORT_JOB_INV_SEARCH();
         gvdetails.DataSource = ds1.Tables[0];
         gvdetails.DataBind();

         if(ds1.Tables[1].Rows.Count>0)
         {
             lbljobcnt.Text = ds1.Tables[1].Rows[0][0].ToString();
             lblpending_cnt.Text = ds1.Tables[1].Rows[0][1].ToString();
             lblCancelled_cnt.Text = ds1.Tables[1].Rows[0][2].ToString();
             lblCompleted_cnt.Text = ds1.Tables[1].Rows[0][3].ToString();
         }
     }
     protected void ddljobno_SelectedIndexChanged(object sender, EventArgs e)
     {
        load_Bill_Inv_No();
        Load_Grid();
     }
     private void load_Bill_Inv_No()
     {
         if (ddljobno.SelectedItem.Text != "")
         {
             DataSet dss = new DataSet();
             BI.Mode = ddlmode.SelectedItem.Text;
             BI.Branch = ddlbranch.SelectedItem.Text;
             BI.Branch_Type = SELECT_BRANCH;
             BI.Mflag = "Inv_Exp_Bill_no_Select";
             BI.Exp_Name = ddlExp_name.SelectedItem.Text;
             BI.JOBNO = ddljobno.SelectedItem.Text;
             dss = BI.Select_Exp_INV();

             ddlinvno.DataSource = dss.Tables[0];
             ddlinvno.DataTextField = "BILL_INV_NO";
             ddlinvno.DataValueField = "BILL_INV_NO";
             ddlinvno.DataBind();
             ddlinvno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
             ddlinvno.SelectedIndex = 0;
         }
         else
         {
             ddlinvno.Items.Clear();
             ddlinvno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
             ddlinvno.SelectedIndex = 0;
         }
     }
     protected void ddlinvno_SelectedIndexChanged(object sender, EventArgs e)
     {
         Load_Grid();
     }
     private void Load_Month()
     {
         Billing_Imp_Invoice BE = new Billing_Imp_Invoice();
         DataSet ds = new DataSet();
         arr = Working_Period.Split('-');
         Start_date = arr[0] + '-' + arr[1] + '-' + arr[2];
         End_date = arr[3] + '-' + arr[4] + '-' + arr[5];

         BE.from_date = Start_date;
         BE.todate = End_date;
         BE.Flag = "Month";
         ds = BE.IMP_EXP_Month();

         ddlmonth.DataSource = ds.Tables[0];
         ddlmonth.DataTextField = "TheMonth";
         ddlmonth.DataValueField = "TheMonth_No";
         ddlmonth.DataBind();

         ddlmonth.Items.Insert(ddlmonth.Items.Count, new ListItem(String.Empty, String.Empty));
         ddlmonth.SelectedValue = ds.Tables[1].Rows[0][0].ToString();
     }
     private void Load_Billstatue()
     {
         ddl_Bill_status.Items.Add(new ListItem("", ""));
         ddl_Bill_status.Items.Add(new ListItem("Completed", "D"));
         ddl_Bill_status.Items.Add(new ListItem("Pending", "P"));
         ddl_Bill_status.Items.Add(new ListItem("Cancelled", "C"));
     }
}