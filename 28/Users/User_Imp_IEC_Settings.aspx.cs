using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text; // This was added to make StringBuilder function

public partial class User_Imp_IEC_Settings : ThemeClass
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
    Date_Time dt = new Date_Time();
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

        hdfTransport_mode.Value = "";
        Hdn_STANDARD_TYPE.Value = "";
       
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
        //txtPassword.Attributes.Add("value", txtPassword.Text.Trim());
        ddlGroupname.Focus();
        Load_User_Settings_Details();
    }

    private void Load_User_Settings_Details()
    {
        DataSet Exp_ds = new DataSet();
        User.COMPANY_ID = COMPANY_ID;
        User.USER_CREATION_ID = USER_CREATION_ID;
        User.ACTION_BRANCH = ddlLoad_Branch.SelectedValue;
        User.TYPE = ddlType.SelectedValue;
        User.flag = "Select_Imp_IEC_ACCESS_Settings";

        if (ddlType.SelectedValue == "Import")
        {
            lblClient_Name.Text = "Importer Name";
        }
        else
        {
            lblClient_Name.Text = "Exporter Name";
        }

        Exp_ds = User.RetrieveAll_User_IEC_Access_Settings(HttpContext.Current.Session["currentcomp_db"].ToString());

        int ccnt = 0;

        if (Exp_ds.Tables[0].Rows.Count > 0)
        {
            ccnt = 1;
            gvAll.DataSource = Exp_ds.Tables[0];
            gvAll.DataBind();

            ViewState["CurrentTable"] = Exp_ds.Tables[0];
            //SetPreviousData();
        }
        else
        {
            gvAll.DataSource = dtt;
            gvAll.DataBind();
        }

        //if (ccnt == 1)
        //{
        //    btnSave.Visible = false;
        //    btnUpdate.Visible = true;
        //    btnDelete.Visible = true;
        //}
        //else
        //{
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
        //}
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
            hdnSelectedImporters.Value = "";
            Load_User_Settings_Details();

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
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
            // If the user multi-selected importers in txtImporterName, loop-insert them.
            if (Save_Multiple_Importers())
            {
                return;
            }

            Insert_Update("S", "0");
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

    /// <summary>
    /// Reads the hidden field filled by the multi-select autocomplete on txtImporterName
    /// (records separated by "||", each record = BRANCH_NO--IEC_NO--IEC_NAME) and inserts
    /// every selected importer one by one. Returns true when it handled the save.
    /// </summary>
    private bool Save_Multiple_Importers()
    {
        string raw = hdnSelectedImporters.Value;
        if (string.IsNullOrEmpty(raw) || raw.Trim().Length == 0)
        {
            return false;
        }

        string[] records = raw.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);

        int savedCount = 0;
        foreach (string rec in records)
        {
            string[] f = rec.Split(new string[] { "--" }, StringSplitOptions.None);
            if (f.Length < 3)
            {
                continue;
            }

            string branchNo = f[0].Trim();
            string iecNo = f[1].Trim();
            // importer name is everything after the 2nd "--" (name itself may contain "--")
            string iecName = string.Join("--", f, 2, f.Length - 2).Trim();

            if (iecName.Length == 0 && iecNo.Length == 0)
            {
                continue;
            }

            User.ID = "0";
            User.COMPANY_ID = COMPANY_ID;
            User.USER_CREATION_ID = USER_CREATION_ID;
            User.TYPE = ddlType.SelectedValue;
            User.ACTION_BRANCH = ddlLoad_Branch.SelectedValue;
            User.IEC_NO = iecNo;
            User.BRANCH_NO = branchNo;
            User.IEC_NAME = iecName;
            User.USER_ID = Session["USER_NAME"].ToString();
            User.flag = "S";

            ds = User.User_Imp_IEC_Access_Settings_Insert_update(HttpContext.Current.Session["currentcomp_db"].ToString());

            if (User.result == 1)
            {
                savedCount++;
            }
        }

        // reset the picker and refresh the grid exactly like the single-insert path does
        hdnSelectedImporters.Value = "";
        txtImporterName.Text = "";
        txtIECNo.Text = "";
        txtBranchNo.Text = "";

        Load_User_Settings_Details();

        btnSave.Visible = true;
        btnUpdate.Visible = false;
        btnDelete.Visible = false;

        if (savedCount > 0)
        {
            Alert_msg(savedCount + " Importer(s) Saved Succesfully..");
        }
        else
        {
            Alert_msg("Not Saved..");
        }

        return true;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataSet dss = new DataSet(); 
        try
        {         
           
            BRANCH = ddlLoad_Branch.SelectedValue.ToString();
          i= Insert_Update("U", ViewState["ID"].ToString());

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
            User.ID = ViewState["ID"].ToString();
            User.COMPANY_ID = COMPANY_ID;
            User.USER_CREATION_ID = USER_CREATION_ID;
            User.ACTION_BRANCH = ddlLoad_Branch.SelectedValue;
            User.flag = "delete_IEC";

            Exp_ds = User.RetrieveAll_User_IEC_Access_Settings(HttpContext.Current.Session["currentcomp_db"].ToString());
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

    public int Insert_Update(string flag, string ID)
    {
        try
        {
            User.ID = ID;
            User.COMPANY_ID = COMPANY_ID;
            User.USER_CREATION_ID = USER_CREATION_ID;
            User.TYPE = ddlType.SelectedValue;
            User.ACTION_BRANCH = ddlLoad_Branch.SelectedValue;
            User.IEC_NO = txtIECNo.Text;
            User.BRANCH_NO = txtBranchNo.Text;
            User.IEC_NAME = txtImporterName.Text;
            User.USER_ID = Session["USER_NAME"].ToString();
            User.flag = flag;

            ds = User.User_Imp_IEC_Access_Settings_Insert_update(HttpContext.Current.Session["currentcomp_db"].ToString());

            if (User.result == 1)
            {
                Alert_msg("Saved Successfully", "btnSave");
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;

                Load_User_Settings_Details();
            }

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
        Load_User_Settings_Details();
    }

    protected void gvAll_RowCreated(object sender, GridViewRowEventArgs e)
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

    protected void gvAll_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Enabled = true;

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gvAll, "Select$" + e.Row.RowIndex.ToString()));
        }
    }

    protected void gvAll_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["ID"] = Convert.ToString(this.gvAll.SelectedDataKey.Value);

        // editing a single existing row -> multi-select picker must be empty
        hdnSelectedImporters.Value = "";

        if (ViewState["ID"] != "" && ViewState["ID"] != null)
         {
             txtImporterName.Text = gvAll.SelectedRow.Cells[1].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
             txtIECNo.Text = gvAll.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
             txtBranchNo.Text = gvAll.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");

             btnUpdate.Visible = true;
             btnDelete.Visible = true;
             btnSave.Visible = false;

         }
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_User_Settings_Details();
    }
}