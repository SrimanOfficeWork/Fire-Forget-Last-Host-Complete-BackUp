using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class User_Imp_Settings : ThemeClass
{
    DataSet dtuser = new DataSet();
    DataSet dtbranch = new DataSet();
    DataSet dt_Userbranch = new DataSet();
    DataSet dt_UserRights = new DataSet();
    DataSet ds = new DataSet();
    StringBuilder sb = new StringBuilder();

    AppSession aps = new AppSession();
    Transaction trans = new Transaction();
    Company_Master Comp = new Company_Master();
    DataTable dtt = new DataTable();
    User_Creation User = new User_Creation();
    public string Trans_ID = "";
    ErrorLogs er = new ErrorLogs();
    public int i;
    public string AUTO_I, COMPANY_ID, USER_CREATION_ID, BRANCH, BRANCH_ID, flag;
    public string USER_RIGHTS_ID, SCREEN_ID,PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE;
   

    string S_ID = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();
       
        if (Session["COMPANY_ID"] != null)
        {

            COMPANY_ID = Session["COMPANY_ID"].ToString();

            if (Session["USER_CREATION_ID_EDIT"] != null)
            {
                USER_CREATION_ID = Session["USER_CREATION_ID_EDIT"].ToString();
            }
            else
            {
                Response.Write("<script>window.open('User_Master.aspx','_parent');</script>");
            }
        }
        else
        {
            Response.Write("<script>window.open('User_Master.aspx','_parent');</script>");
        }
        if (!IsPostBack)
        {           
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;

            //Load_Permission_User_Details();
            //Load_User_Branch_Details();
            Bind_Group(Session["WorkingPeriod"].ToString());
            Load_User_Settings_Details();
        }
        
       
    }

    public class BranchDetails
    {
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public string Comp_License { get; set; }
        public string result { get; set; }
    }

    private void Bind_Group(string wk)
    {
        ddlGroupname.Items.Clear();
        DataSet ds = new DataSet();
        ds = (DataSet)HttpContext.Current.Session["COMPANY_DETAILS_DS"];

        DataView view1 = ds.Tables[2].DefaultView; //WORKING_PERIOD
        view1.RowFilter = "WORKING_PERIOD = '" + wk + "'";

       // HttpContext.Current.Session["currentcomp_db"] = view1.ToTable().Rows[0]["SERVER_NAME"].ToString();

        Comp.COMPANY_ID = "";
        Comp.BRANCH = "";
        Comp.flag = "Select-Group";
        ds = Comp.RetrieveAll_Groups();
        HttpContext.Current.Session["ClientGrpMst"] = ds;
        //RetrieveAll_Groups

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlGroupname.DataSource = ds.Tables[0];
            ddlGroupname.DataTextField = "GROUP_NAME";
            ddlGroupname.DataValueField = "GROUP_ID";
            ddlGroupname.DataBind();
            Bind_Branch(ds.Tables[0].Rows[0]["GROUP_ID"].ToString(), ds.Tables[1]);
        }
    }

    private void Bind_Branch(string grpid, DataTable dt)
    {
        ddlLoad_Branch.Items.Clear();
        ds = (DataSet)Session["COMPANY_DETAILS_DS"];
        if (Session["COMPANY_DETAILS_DS"] != null)
        {
            ds = (DataSet)Session["COMPANY_DETAILS_DS"];
        }

        DataView view1 = dt.DefaultView;
        view1.RowFilter = "GROUP_ID = '" + grpid + "'";
        dt = view1.ToTable();

        List<BranchDetails> details = new List<BranchDetails>();
        BranchDetails Branch1 = new BranchDetails();
        if (dt.Rows.Count > 0)
        {

            Branch1.Comp_License = ds.Tables[0].Rows[0]["COMPANY_LICENSE"].ToString();
            Branch1.result = Convert.ToString(Comp.result);
           // hdn_result.Value = "1";
            foreach (DataRow dtrow in dt.Rows)
            {
                BranchDetails Branch = new BranchDetails();
                Branch.CountryId = dtrow["BRANCHCODE"].ToString();
                string branch = dtrow["BRANCHCODE"].ToString();
                string branch_code = dtrow["CUSTOMHOUSE"].ToString();
                Branch.result = Convert.ToString(Comp.result);

                string[] s1 = branch.Split(new string[] { "," }, StringSplitOptions.None);
                string custom_Branch = s1[1].ToString();

                DataView view2 = ds.Tables[3].DefaultView;
                view2.RowFilter = "CUSTOMHOUSE_CODE = '" + branch_code + "'";

                DataSet dt_UserRights = new DataSet();
                dt_UserRights.Tables.Add(view2.ToTable());
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

                        if (a == "Customs, Mundra")
                            Category_mode = "Sea";

                        Branch.CountryName = custom_Branch + "(" + Category_mode + ")";
                        details.Add(Branch);

                    }
                }

                ddlLoad_Branch.DataSource = details.ToArray();
                ddlLoad_Branch.DataValueField = "CountryId";
                ddlLoad_Branch.DataTextField = "CountryName";
                ddlLoad_Branch.DataBind();
            }
        }      
    }

    protected void ddlGroupname_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds = (DataSet)HttpContext.Current.Session["ClientGrpMst"];
        Bind_Branch(ddlGroupname.SelectedValue, ds.Tables[1]);
        ddlGroupname.Focus();
        Load_User_Settings_Details();
    }

    private void Load_User_Settings_Details()
    {
        DataSet Exp_ds = new DataSet();
        User.COMPANY_ID = COMPANY_ID;
        User.USER_CREATION_ID = USER_CREATION_ID;
        User.ACTION_BRANCH = ddlLoad_Branch.SelectedValue;
        User.flag = "Select_Imp_Settings";

        Exp_ds = User.User_Imp_Settings_Insert_update(HttpContext.Current.Session["currentcomp_db"].ToString());

        if (Exp_ds.Tables[0].Rows.Count > 0)
        {
            
            rdl_Job_edit.SelectedValue = Exp_ds.Tables[0].Rows[0]["GENERAL_JOB_EDIT"].ToString();
            rdl_AddlDutyImports.SelectedValue = Exp_ds.Tables[0].Rows[0]["ITEM_ADDL_DUTY_IMPORTS"].ToString();
            rdl_GeneralDetails.SelectedValue = Exp_ds.Tables[0].Rows[0]["CHKLIST_GENERAL"].ToString();
            rdl_ManufacturerDetails.SelectedValue = Exp_ds.Tables[0].Rows[0]["CHKLIST_MANUF"].ToString();
            rdl_SellerDetails.SelectedValue = Exp_ds.Tables[0].Rows[0]["CHKLIST_SELLER"].ToString();
            rdl_FF_STMTTEXT.SelectedValue = Exp_ds.Tables[0].Rows[0]["FF_STMT_TEXT"].ToString();
            rdl_FF_FTA_Exbond.SelectedValue = Exp_ds.Tables[0].Rows[0]["FF_FTA_EXBOND"].ToString();
            rdl_Default_IGST_Excepn_Notn.SelectedValue = Exp_ds.Tables[0].Rows[0]["ITEM_DEFAULT_IGST_EXCMPN_NOTN"].ToString();
            rdl_General_Det.SelectedValue = Exp_ds.Tables[0].Rows[0]["GENERAL_DESC_SAME_AS_ITEM_DESC"].ToString();         
            rdl_License_Det.SelectedValue = Exp_ds.Tables[0].Rows[0]["IGST_EXEMPTION_NOTN_AS_LICENSE_NOTN"].ToString();
            rdl_FF_Allow_RE_Bond_Notn.SelectedValue = Exp_ds.Tables[0].Rows[0]["FF_ALLOW_WITHOUT_REBOND_NOTN"].ToString();
            rdl_General_Role_Wise_Milesstone.SelectedValue = Exp_ds.Tables[0].Rows[0]["GENERAL_USER_WISE_MILESTONE"].ToString();
            
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;

        }
        else
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
        }
    }


    public void Load_User_Branch_Details()
    {
        try
        {
            flag = "Select_Permission_Branch_Details";

            BRANCH_ID = "0";
            User.COMPANY_ID = COMPANY_ID;
            User.USER_CREATION_ID = USER_CREATION_ID;
            User.USER_BRANCHID = BRANCH_ID;
            User.BRANCH = BRANCH;
            User.flag = flag;

            ddlLoad_Branch.DataSource = User.RetrieveAll_Branch_Details(HttpContext.Current.Session["currentcomp_db"].ToString());
            ddlLoad_Branch.DataTextField = "BRANCH";
            ddlLoad_Branch.DataValueField = "BRANCH";

            ddlLoad_Branch.DataBind();
                     
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

  
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            trans.ResetFields(Page.Controls);
            Load_User_Settings_Details();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
  
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            Insert_Update("S");
            i = User.result;

            if (i == 1)
            {
                Alert_msg("Saved Succesfully..");
            }

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
      
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataSet dss = new DataSet(); 
        try
        {         
           
            BRANCH = ddlLoad_Branch.SelectedValue.ToString();
          i= Insert_Update("U");

          if (i == 1)
          {
              Alert_msg("Updated Succesfully..");
          }

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet Exp_ds = new DataSet();
            User.COMPANY_ID = COMPANY_ID;
            User.USER_CREATION_ID = USER_CREATION_ID;
            User.ACTION_BRANCH = ddlLoad_Branch.SelectedValue;
            User.flag = "delete";

            Exp_ds = User.RetrieveAll_User_Imp_Settings(HttpContext.Current.Session["currentcomp_db"].ToString());
            i = User.result;
           
            if (i == 1)
            {
                btnNew_Click(sender, e);
                Alert_msg("Deleted");
            }
            else
            {
                Alert_msg("Not Deleted");

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public int Insert_Update(string flag)
    {
        try
        {
            
            User.USER_CREATION_ID = USER_CREATION_ID;
            User.COMPANY_ID = COMPANY_ID;
            User.ACTION_BRANCH = ddlLoad_Branch.SelectedValue;
            User.GENERAL_JOB_EDIT = rdl_Job_edit.SelectedValue;
            User.ITEM_ADDL_DUTY_IMPORTS = rdl_AddlDutyImports.SelectedValue;
            User.CHKLIST_GENERAL = rdl_GeneralDetails.SelectedValue;
            User.CHKLIST_MANUF = rdl_ManufacturerDetails.SelectedValue;
            User.CHKLIST_SELLER = rdl_SellerDetails.SelectedValue;
            User.FF_STMT_TEXT = rdl_FF_STMTTEXT.SelectedValue;
            User.FF_FTA_EXBOND = rdl_FF_FTA_Exbond.SelectedValue;
            User.ITEM_DEFAULT_IGST_EXCMPN_NOTN = rdl_Default_IGST_Excepn_Notn.SelectedValue;
            User.GENERAL_DESC_SAME_AS_ITEM_DESC = rdl_General_Det.SelectedValue;
            User.IGST_EXEMPTION_NOTN_AS_LICENSE_NOTN = rdl_License_Det.SelectedValue;
            User.FF_ALLOW_WITHOUT_REBOND_NOTN = rdl_FF_Allow_RE_Bond_Notn.SelectedValue;
            User.GENERAL_USER_WISE_MILESTONE = rdl_General_Role_Wise_Milesstone.SelectedValue;


            User.flag = flag;
            User.User_Imp_Settings_Insert_update(HttpContext.Current.Session["currentcomp_db"].ToString());
            
            i = User.result;

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
         return i;
    }


    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'User Details', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'User Details', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


    protected void ddlLoad_Branch_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        //Load_Permission_User_Details();
        Load_User_Settings_Details();
    }
}