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

public partial class Import_Statement_Import_Job_Register : ThemeClass
{
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string Company_ID;
    public string SELECT_TYPE, SELECT_BRANCH;

    AppSession aps = new AppSession();
    SqlCommand cmd;
    SqlConnection con;
    SqlDataAdapter da;
    SqlDataReader dr;
    //Imp_Job_Duplicate JD = new Imp_Job_Duplicate();
    public string AUTO_I, COMPANY_ID, USER_CREATION_ID, BRANCH, BRANCH_ID, flag;

    private int i;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
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
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }
        
  * */
        SELECT_BRANCH = Connection.Get_Company_Type();
        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

        if (!IsPostBack)
        {
            Load_Company_Branch();
            Username_Load();
            iframe1.Visible = false;
        }
    }
    public void Load_Company_Branch()
    {
        DataSet ds_branch = new DataSet();
        Company_Master Comp = new Company_Master();

        if (Session["COMPANY_DETAILS_DS"] != null)
        {
            ds_branch = (DataSet)Session["COMPANY_DETAILS_DS"];
        }
        List<BranchDetails> details = new List<BranchDetails>();
        BranchDetails Branch1 = new BranchDetails();
        if (ds_branch.Tables[0].Rows.Count > 0)
        {
            Branch1.Comp_License = ds_branch.Tables[0].Rows[0]["COMPANY_LICENSE"].ToString();
            Branch1.result = Convert.ToString(Comp.result);
            User_Creation User = new User_Creation();

            flag = "Select_Branch_Details";
            COMPANY_ID = Session["COMPANY_ID"].ToString();
            USER_CREATION_ID = Session["USER_CREATION_ID"].ToString();
            BRANCH_ID = "0";
            User.COMPANY_ID = COMPANY_ID;
            User.USER_CREATION_ID = USER_CREATION_ID;
            User.USER_BRANCHID = BRANCH_ID;
            User.BRANCH = BRANCH;

            User.flag = flag;
            DataSet ds_userbranch = new DataSet();

            ds_userbranch = User.RetrieveAll_Branch_Details(HttpContext.Current.Session["currentcomp_db"].ToString());

            if (ds_branch.Tables[1].Rows.Count > 0)
            {
                BranchDetails Branch2 = new BranchDetails();
                Branch2.CountryId = Session["currentbranch"].ToString();
                Branch2.CountryName = Session["currentbranch_code"].ToString();
                details.Add(Branch2);

                foreach (DataRow dtrow in ds_branch.Tables[1].Rows)
                {
                    BranchDetails Branch = new BranchDetails();
                    Branch.CountryId = dtrow["BRANCH"].ToString();
                    string branch = dtrow["BRANCH"].ToString();
                    string branch_code = dtrow["PORT_OF_FILING"].ToString();
                    Branch.result = Convert.ToString(Comp.result);

                    string[] s1 = branch.Split(new string[] { "," }, StringSplitOptions.None);
                    string custom_Branch = s1[1].ToString();

                    DataView view1 = ds_branch.Tables[3].DefaultView;
                    view1.RowFilter = "CUSTOMHOUSE_CODE = '" + branch_code + "'";
                    DataSet dt_UserRights = new DataSet();
                    dt_UserRights.Tables.Add(view1.ToTable());
                    if (dt_UserRights.Tables[0].Rows.Count > 0)
                    {

                        string a = dt_UserRights.Tables[0].Rows[0]["CUSTOMHOUSE_NAME"].ToString();
                        string mode = dt_UserRights.Tables[0].Rows[0]["CUSTOMHOUSE_CATEGORY"].ToString();
                        string Category_mode = "";
                        if (a == branch)
                        {

                            if (mode == "A")
                                Category_mode = "Air";
                            if (mode == "S")
                                Category_mode = "Sea";
                            if (mode == "L")
                                Category_mode = "Land";

                            DataView view2 = ds_userbranch.Tables[0].DefaultView;
                            view2.RowFilter = "BRANCH = '" + branch + "'";
                            DataSet dt_UserRights1 = new DataSet();
                            dt_UserRights1.Tables.Add(view2.ToTable());
                            if (dt_UserRights1.Tables[0].Rows.Count > 0)
                            {
                                if (branch != Session["currentbranch"].ToString())
                                {
                                    Branch.CountryName = custom_Branch + "(" + Category_mode + ")";
                                    details.Add(Branch);
                                }
                            }
                        }
                    }
                }
                ddlbranch.DataSource = details.ToArray();
                ddlbranch.DataValueField = "CountryId";
                ddlbranch.DataTextField = "CountryName";
                ddlbranch.DataBind();

                if (SELECT_BRANCH == string.Empty)
                {
                    ddlbranch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    ddlbranch.SelectedIndex = 0;
                }

            }
        }
    }

    public class BranchDetails
    {
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public string Comp_License { get; set; }
        public string result { get; set; }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        iframe1.Visible = true;
        iframe1.Attributes["src"] = "User_wise_Report_IFrame.aspx?JobType=" + ddl_jobtype.SelectedValue.ToString() + "&User=" + ddl_Username.SelectedValue.ToString() + "&FromDate=" + txtFrom_Date.Text + "&ToDate=" + txtTo_Date.Text + "&Branch=" + ddlbranch.SelectedValue.ToString() + "&Jobsort=" +ddl_Jobno_sort.SelectedValue.ToString() + "";
    }
    protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        Username_Load();
        btnSearch_Click(sender, e);
    }
    private void Username_Load()
    {
       // if (ddlbranch.SelectedItem.Text != string.Empty)//--hide on 25-03-2021 for Paramount Common wise issue
        //{
            DataSet ds = new DataSet();
            User_Wise_Job_Report UR = new User_Wise_Job_Report();

            UR.IMP_EXP = ddl_jobtype.SelectedValue.ToString();
            UR.Branch = ddlbranch.SelectedValue.ToString();
            UR.Flag = "Username_Select";
            ds = UR.Select_User();
            ddl_Username.DataSource = ds;
            ddl_Username.DataTextField = "NAME";
            ddl_Username.DataValueField = "NAME";
            ddl_Username.DataBind();
            ddl_Username.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Username.SelectedIndex = 0;
        //}
        //else
        //{
        //    ddl_Username.Items.Clear();
        //    ddl_Username.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        //    ddl_Username.SelectedIndex = 0;
        //}

    }



    protected void ddl_Jobno_sort_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
    }
    protected void ddl_Username_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
    }
    protected void ddl_jobtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSearch_Click(sender, e);
    }
}
