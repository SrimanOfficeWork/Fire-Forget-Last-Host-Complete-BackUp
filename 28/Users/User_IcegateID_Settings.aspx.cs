using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text; // This was added to make StringBuilder function

public partial class User_IcegateID_Settings : ThemeClass
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
    public int i, value = 0;
    public string AUTO_I, COMPANY_ID, USER_CREATION_ID, BRANCH, BRANCH_ID, flag;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE;


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
        User.flag = "Select_Imp_Settings";

        Exp_ds = User.RetrieveAll_User_ICEGATE_ID_Settings(HttpContext.Current.Session["currentcomp_db"].ToString());

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
            SetInitialRow();
        }

        if (Exp_ds.Tables[1].Rows.Count > 0)
        {
            ccnt = 1;
            gvExport.DataSource = Exp_ds.Tables[1];
            gvExport.DataBind();

            ViewState["CurrentTable_Exp"] = Exp_ds.Tables[1];

        }
        else
        {
            SetInitialRow_Export();
        }

        if (ccnt == 1)
        {
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
            if (value == 1)
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
            Insert_Update("U");
            if (value == 1)
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
            User.flag = "delete_IMP_EXP_ICEGATE_ID";

            Exp_ds = User.RetrieveAll_User_ICEGATE_ID_Settings(HttpContext.Current.Session["currentcomp_db"].ToString());
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
            DataTable dtt = new DataTable();
            DataRow dr;
            dtt.Columns.Add(new System.Data.DataColumn("ID", typeof(int)));
            dtt.Columns.Add(new System.Data.DataColumn("USER_CREATION_ID", typeof(int)));
            dtt.Columns.Add(new System.Data.DataColumn("COMPANY_ID", typeof(int)));
            dtt.Columns.Add(new System.Data.DataColumn("ACTION_BRANCH", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("SLNO", typeof(int)));
            dtt.Columns.Add(new System.Data.DataColumn("ICEGATE_ID", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("DATE_TIME", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("USER_ID", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("STATUS", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("MODIFIED_BY", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("MODIFIED_ON", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("CHA_NO", typeof(string)));
            dtt.Columns.Add(new System.Data.DataColumn("CHA_NAME", typeof(string)));
            dtt.Columns.Add(new System.Data.DataColumn("CHA_ADDRESS", typeof(string)));
            dtt.Columns.Add(new System.Data.DataColumn("CHA_ADDRESS1", typeof(string)));
            dtt.Columns.Add(new System.Data.DataColumn("CHA_ADDRESS2", typeof(string)));
            dtt.Columns.Add(new System.Data.DataColumn("CHA_ADDRESS3", typeof(string)));
            dtt.Columns.Add(new System.Data.DataColumn("CHA_ADDRESS4", typeof(string)));
            dtt.Columns.Add(new System.Data.DataColumn("AEO_REGISTRATION_NUMBER", typeof(string)));
            dtt.Columns.Add(new System.Data.DataColumn("AEO_REGISTER_ROLE", typeof(string)));

            int x = 1;
            int MAX_ID = Get_MAXID("Select_IMP_MAX_ID");
            int SLNO = 1;
            HashSet<string> _uniqueKeys = new HashSet<string>();
            foreach (GridViewRow row in gvAll.Rows)
            {
                TextBox txt_Imp_icegateId = (TextBox)row.FindControl("txt_Imp_icegateId");
                TextBox txt_Imp_CHA_NO = (TextBox)row.FindControl("txt_Imp_CHA_NO");
                TextBox txt_Imp_CHA_NAME = (TextBox)row.FindControl("txt_Imp_CHA_NAME");
                TextBox txt_Imp_CHA_ADDRESS = (TextBox)row.FindControl("txt_Imp_CHA_ADDRESS");
                TextBox txt_Imp_CHA_ADDRESS1 = (TextBox)row.FindControl("txt_Imp_CHA_ADDRESS1");
                TextBox txt_Imp_CHA_ADDRESS2 = (TextBox)row.FindControl("txt_Imp_CHA_ADDRESS2");
                TextBox txt_Imp_CHA_ADDRESS3 = (TextBox)row.FindControl("txt_Imp_CHA_ADDRESS3");
                TextBox txt_Imp_CHA_ADDRESS4 = (TextBox)row.FindControl("txt_Imp_CHA_ADDRESS4");
                TextBox txt_Imp_AEO_REGISTRATION_NUMBER = (TextBox)row.FindControl("txt_Imp_AEO_REGISTRATION_NUMBER");
                TextBox txt_Imp_AEO_REGISTER_ROLE = (TextBox)row.FindControl("txt_Imp_AEO_REGISTER_ROLE");

                string ImportIceGateId = txt_Imp_icegateId.Text.ToUpper().Trim();
                string ImportChaNo = txt_Imp_CHA_NO.Text.Trim();
                string ImportChaName = txt_Imp_CHA_NAME.Text.Trim();
                string ActionBranch = ddlLoad_Branch.SelectedValue;

                bool isAnyFieldFilled = (!string.IsNullOrEmpty(ImportIceGateId) || !string.IsNullOrEmpty(ImportChaNo) || !string.IsNullOrEmpty(ImportChaName));
                if (!isAnyFieldFilled)
                {
                    continue;
                }
                if (string.IsNullOrEmpty(ImportIceGateId) || string.IsNullOrEmpty(ImportChaNo) || string.IsNullOrEmpty(ImportChaName))
                {
                    Alert_msg("Icegate ID, CHA No, and CHA Name are mandatory for each row in Import grid.");
                    return User.result = 0;
                }

                if (!string.IsNullOrEmpty(ImportIceGateId) || !string.IsNullOrEmpty(ImportChaNo) || !string.IsNullOrEmpty(ImportChaName))
                {
                    string keys = USER_CREATION_ID + "|" + ImportIceGateId + "|" + ImportChaNo + "|" + ImportChaName + "|" + ActionBranch;
                    if (_uniqueKeys.Contains(keys))
                    {
                        Alert_msg("Duplicate entry detected: Import Icegate ID- {0}, CHA No- {1}, and CHA Name- {2} already exist.");
                        return User.result = 0;
                    }
                    else
                    {
                        _uniqueKeys.Add(keys);
                    }
                }


                dr = dtt.NewRow();

                dr[0] = MAX_ID;
                dr[1] = USER_CREATION_ID;
                dr[2] = COMPANY_ID;
                dr[3] = ddlLoad_Branch.SelectedValue;
                dr[4] = SLNO;
                dr[5] = txt_Imp_icegateId.Text.ToUpper();
                dr[6] = Session["LoginDate"].ToString();
                dr[7] = Connection.Current_User();
                dr[8] = "S";
                dr[9] = Connection.Current_User();
                dr[10] = Session["LoginDate"].ToString();
                dr[11] = txt_Imp_CHA_NO.Text;
                dr[12] = txt_Imp_CHA_NAME.Text;
                dr[13] = txt_Imp_CHA_ADDRESS.Text;
                dr[14] = txt_Imp_CHA_ADDRESS1.Text;
                dr[15] = txt_Imp_CHA_ADDRESS2.Text;
                dr[16] = txt_Imp_CHA_ADDRESS3.Text;
                dr[17] = txt_Imp_CHA_ADDRESS4.Text;
                dr[18] = txt_Imp_AEO_REGISTRATION_NUMBER.Text;
                dr[19] = txt_Imp_AEO_REGISTER_ROLE.Text;

                dtt.Rows.Add(dr);
                x = x + 1;
                MAX_ID = MAX_ID + 1;
                SLNO = SLNO + 1;
            }

            //--------------EXPORT ICEGATE ID DETAILS SAVE--START------------------
            DataTable dtt_export = new DataTable();
            dtt_export.Columns.Add(new DataColumn("ID", typeof(int)));
            dtt_export.Columns.Add(new DataColumn("USER_CREATION_ID", typeof(int)));
            dtt_export.Columns.Add(new DataColumn("COMPANY_ID", typeof(int)));
            dtt_export.Columns.Add(new DataColumn("ACTION_BRANCH", typeof(String)));
            dtt_export.Columns.Add(new DataColumn("SLNO", typeof(int)));
            dtt_export.Columns.Add(new DataColumn("ICEGATE_ID", typeof(String)));
            dtt_export.Columns.Add(new DataColumn("DATE_TIME", typeof(String)));
            dtt_export.Columns.Add(new DataColumn("USER_ID", typeof(String)));
            dtt_export.Columns.Add(new DataColumn("STATUS", typeof(String)));
            dtt_export.Columns.Add(new DataColumn("MODIFIED_BY", typeof(String)));
            dtt_export.Columns.Add(new DataColumn("MODIFIED_ON", typeof(String)));
            dtt_export.Columns.Add(new DataColumn("CHA_NO", typeof(string)));
            dtt_export.Columns.Add(new DataColumn("CHA_NAME", typeof(string)));
            dtt_export.Columns.Add(new DataColumn("CHA_ADDRESS", typeof(string)));
            dtt_export.Columns.Add(new DataColumn("CHA_ADDRESS1", typeof(string)));
            dtt_export.Columns.Add(new DataColumn("CHA_ADDRESS2", typeof(string)));
            dtt_export.Columns.Add(new DataColumn("CHA_ADDRESS3", typeof(string)));
            dtt_export.Columns.Add(new DataColumn("CHA_ADDRESS4", typeof(string)));
            dtt_export.Columns.Add(new DataColumn("AEO_REGISTRATION_NUMBER", typeof(string)));
            dtt_export.Columns.Add(new DataColumn("AEO_REGISTER_ROLE", typeof(string)));

            x = 1;
            MAX_ID = Get_MAXID("Select_EXP_MAX_ID");
            SLNO = 1;
            HashSet<string> ExportUniquevalues = new HashSet<string>();
            foreach (GridViewRow row in gvExport.Rows)
            {
                TextBox txt_Exp_icegateId = (TextBox)row.FindControl("txt_Exp_icegateId");
                TextBox txt_Exp_CHA_NO = (TextBox)row.FindControl("txt_Exp_CHA_NO");
                TextBox txt_Exp_CHA_NAME = (TextBox)row.FindControl("txt_Exp_CHA_NAME");
                TextBox txt_Exp_CHA_ADDRESS = (TextBox)row.FindControl("txt_Exp_CHA_ADDRESS");
                TextBox txt_Exp_CHA_ADDRESS1 = (TextBox)row.FindControl("txt_Exp_CHA_ADDRESS1");
                TextBox txt_Exp_CHA_ADDRESS2 = (TextBox)row.FindControl("txt_Exp_CHA_ADDRESS2");
                TextBox txt_Exp_CHA_ADDRESS3 = (TextBox)row.FindControl("txt_Exp_CHA_ADDRESS3");
                TextBox txt_Exp_CHA_ADDRESS4 = (TextBox)row.FindControl("txt_Exp_CHA_ADDRESS4");
                TextBox txt_Exp_AEO_REGISTRATION_NUMBER = (TextBox)row.FindControl("txt_Exp_AEO_REGISTRATION_NUMBER");
                TextBox txt_Exp_AEO_REGISTER_ROLE = (TextBox)row.FindControl("txt_Exp_AEO_REGISTER_ROLE");

                string ExportIcegateId = txt_Exp_icegateId.Text.ToUpper().Trim();
                string ExpChaNo = txt_Exp_CHA_NO.Text.Trim();
                string ExpChaName = txt_Exp_CHA_NAME.Text.Trim();
                string ActionBranch = ddlLoad_Branch.SelectedValue;

                bool isAnyFieldInExportGrod = (!string.IsNullOrEmpty(ExportIcegateId) || !string.IsNullOrEmpty(ExpChaNo) || !string.IsNullOrEmpty(ExpChaName));
                if (!isAnyFieldInExportGrod)
                {
                    continue;
                }
                if (string.IsNullOrEmpty(ExportIcegateId) || string.IsNullOrEmpty(ExpChaNo) || string.IsNullOrEmpty(ExpChaName))
                {
                    Alert_msg("Icegate ID, CHA No, and CHA Name are mandatory for each row in Export grid.");
                    return User.result = 0;
                }

                if (!string.IsNullOrEmpty(ExportIcegateId) || !string.IsNullOrEmpty(ExpChaNo) || !string.IsNullOrEmpty(ExpChaName))
                {
                    string keys = USER_CREATION_ID + "|" + ExportIcegateId + "|" + ExpChaNo + "|" + ExpChaName + "|" + ActionBranch;
                    if (ExportUniquevalues.Contains(keys))
                    {
                        Alert_msg("Duplicate entry detected: Export Icegate ID {0}, CHA No {1}, and CHA Name {2} already exist.");
                        return User.result = 0;
                    }
                    else
                    {
                        ExportUniquevalues.Add(keys);
                    }
                }


                dr = dtt_export.NewRow();

                dr[0] = MAX_ID;
                dr[1] = USER_CREATION_ID;
                dr[2] = COMPANY_ID;
                dr[3] = ddlLoad_Branch.SelectedValue;
                dr[4] = SLNO;
                dr[5] = txt_Exp_icegateId.Text.ToUpper();
                dr[6] = Session["LoginDate"].ToString();
                dr[7] = Connection.Current_User();
                dr[8] = "S";
                dr[9] = Connection.Current_User();
                dr[10] = Session["LoginDate"].ToString();
                dr[11] = txt_Exp_CHA_NO.Text;
                dr[12] = txt_Exp_CHA_NAME.Text;
                dr[13] = txt_Exp_CHA_ADDRESS.Text;
                dr[14] = txt_Exp_CHA_ADDRESS1.Text;
                dr[15] = txt_Exp_CHA_ADDRESS2.Text;
                dr[16] = txt_Exp_CHA_ADDRESS3.Text;
                dr[17] = txt_Exp_CHA_ADDRESS4.Text;
                dr[18] = txt_Exp_AEO_REGISTRATION_NUMBER.Text;
                dr[19] = txt_Exp_AEO_REGISTER_ROLE.Text;

                dtt_export.Rows.Add(dr);
                x = x + 1;
                MAX_ID = MAX_ID + 1;
                SLNO = SLNO + 1;


            }
            if (dtt.Rows.Count == 0 && dtt_export.Rows.Count == 0)
            {
                Alert_msg("Please fill Icegate ID, CHA No, and CHA Name in at least one row, in either the Import or Export grid.");
                return User.result = 0;
            }
            if (dtt.Rows.Count == 0)
            {
                Delete_ICEGATE_ID_ALL("delete_IMP_ICEGATE_ID");
            }
            else
            {
                Delete_ICEGATE_ID_ALL("delete_IMP_ICEGATE_ID");
                AdminMasterDetails adm = new AdminMasterDetails();
                value = adm.SqlBulk_Upload_Product("USER_IMP_ICEGATE_ID_SETTINGS", dtt, Session["currentcomp_db"].ToString());
            }

            dtt.Rows.Clear();

            if (dtt_export.Rows.Count == 0)
            {
                Delete_ICEGATE_ID_ALL("delete_EXP_ICEGATE_ID");
            }
            else
            {
                Delete_ICEGATE_ID_ALL("delete_EXP_ICEGATE_ID");
                AdminMasterDetails adm = new AdminMasterDetails();
                value = adm.SqlBulk_Upload_Product("USER_EXP_ICEGATE_ID_SETTINGS", dtt_export, Session["currentcomp_db"].ToString());
            }

            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnSave.Visible = false;

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return value;
    }


    //public void Alert_msg(string msg)
    //{
    //    string prompt = "jAlert('" + msg.Replace("'", "\\'") + "','User Details');";
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, true);
    //}

    public void Alert_msg(string msg)
    {
        string safeMsg = msg.Replace("'", "\\'").Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " ");
        string prompt = "alert('" + safeMsg + "');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, true);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'User Details', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus, int rowIndex, string gridClientId)
    {
        string safeMsg = msg.Replace("'", "\\'");
        string script = @"
         (function() {
             function highlightRow() {
                 // Clear ALL previous highlights + inline styles
                 document.querySelectorAll('tr.duplicate-row').forEach(function(r) {
                     r.classList.remove('duplicate-row');
                     Array.from(r.cells).forEach(function(td) {
                         td.style.backgroundColor = '';
                     });
                 });
         
                 var grid = document.getElementById('" + gridClientId + @"');
                 if (grid && grid.rows[" + (rowIndex + 1) + @"]) {
                     var dupRow = grid.rows[" + (rowIndex + 1) + @"];
                     dupRow.classList.add('duplicate-row');
         
                     // Force red background on each TD (bypasses GridView inline styles)
                     Array.from(dupRow.cells).forEach(function(td) {
                         td.style.backgroundColor = '#ffcccc';
                     });
         
                 }
                 var txt = document.getElementById('" + focus + @"');
                 if (txt) { txt.focus(); txt.select(); }
             }
         
             highlightRow();
         
             jAlert('" + safeMsg + @"', 'Duplicate Entry', function() {
                 highlightRow();
             });
         })();
         ";
        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), script, true);
    }



    protected void ddlLoad_Branch_SelectedIndexChanged(object sender, EventArgs e)
    {

        //Load_Permission_User_Details();
        Load_User_Settings_Details();
    }

    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
        //http://www.codeproject.com/Articles/30722/How-to-save-data-from-a-DataSet-into-a-T-SQL-table

        // sp_name EXP_BL_GENERATION_INS_UPD
    }

    private void AddNewRowToGrid()
    {
        int rowIndex = 0;
        string Emptyrow = string.Empty;

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //extract the TextBox values
                    TextBox txt_Imp_icegateId = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_icegateId");
                    TextBox txt_Imp_CHA_NO = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_CHA_NO");
                    TextBox txt_Imp_CHA_NAME = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_CHA_NAME");
                    TextBox txt_Imp_CHA_ADDRESS = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_CHA_ADDRESS");
                    TextBox txt_Imp_CHA_ADDRESS1 = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_CHA_ADDRESS1");
                    TextBox txt_Imp_CHA_ADDRESS2 = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_CHA_ADDRESS2");
                    TextBox txt_Imp_CHA_ADDRESS3 = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_CHA_ADDRESS3");
                    TextBox txt_Imp_CHA_ADDRESS4 = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_CHA_ADDRESS4");
                    TextBox txt_Imp_AEO_REGISTRATION_NUMBER = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_AEO_REGISTRATION_NUMBER");
                    TextBox txt_Imp_AEO_REGISTER_ROLE = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_AEO_REGISTER_ROLE");

                    if (string.IsNullOrEmpty(txt_Imp_icegateId.Text) || string.IsNullOrEmpty(txt_Imp_CHA_NO.Text) || string.IsNullOrEmpty(txt_Imp_CHA_NAME.Text))
                    {
                        Emptyrow = "Y";
                        break;
                    }

                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["ICEGATE_ID"] = txt_Imp_icegateId.Text;
                    dtCurrentTable.Rows[i - 1]["CHA_NO"] = txt_Imp_CHA_NO.Text;
                    dtCurrentTable.Rows[i - 1]["CHA_NAME"] = txt_Imp_CHA_NAME.Text;
                    dtCurrentTable.Rows[i - 1]["CHA_ADDRESS"] = txt_Imp_CHA_ADDRESS.Text;
                    dtCurrentTable.Rows[i - 1]["CHA_ADDRESS1"] = txt_Imp_CHA_ADDRESS1.Text;
                    dtCurrentTable.Rows[i - 1]["CHA_ADDRESS2"] = txt_Imp_CHA_ADDRESS2.Text;
                    dtCurrentTable.Rows[i - 1]["CHA_ADDRESS3"] = txt_Imp_CHA_ADDRESS3.Text;
                    dtCurrentTable.Rows[i - 1]["CHA_ADDRESS4"] = txt_Imp_CHA_ADDRESS4.Text;
                    dtCurrentTable.Rows[i - 1]["AEO_REGISTRATION_NUMBER"] = txt_Imp_AEO_REGISTRATION_NUMBER.Text;
                    dtCurrentTable.Rows[i - 1]["AEO_REGISTER_ROLE"] = txt_Imp_AEO_REGISTER_ROLE.Text;
                    rowIndex++;
                }

                if (Emptyrow != "Y")
                {
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    gvAll.DataSource = dtCurrentTable;
                    gvAll.DataBind();
                    SetPreviousData();
                }
                else
                {
                    Alert_msg("IMPORT ICEGATEID,CHA NO & CHA NAME ARE MANDATORY!");
                }
            }
        }
        else
        {
            //Response.Write("ViewState is null");
        }

        //Set Previous Data on Postbacks
        // SetPreviousData();
    }

    private void SetInitialRow()
    {
        DataTable dt = new DataTable();

        DataRow dr = null;

        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("ICEGATE_ID", typeof(string)));
        dt.Columns.Add(new DataColumn("CHA_NO", typeof(string)));
        dt.Columns.Add(new DataColumn("CHA_NAME", typeof(string)));
        dt.Columns.Add(new DataColumn("CHA_ADDRESS", typeof(string)));
        dt.Columns.Add(new DataColumn("CHA_ADDRESS1", typeof(string)));
        dt.Columns.Add(new DataColumn("CHA_ADDRESS2", typeof(string)));
        dt.Columns.Add(new DataColumn("CHA_ADDRESS3", typeof(string)));
        dt.Columns.Add(new DataColumn("CHA_ADDRESS4", typeof(string)));
        dt.Columns.Add(new DataColumn("AEO_REGISTRATION_NUMBER", typeof(string)));
        dt.Columns.Add(new DataColumn("AEO_REGISTER_ROLE", typeof(string)));



        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        //dr["SLNO"] = "";
        dr["ICEGATE_ID"] = string.Empty;
        dr["CHA_NO"] = "";
        dr["CHA_NAME"] = "";
        dr["CHA_ADDRESS"] = "";
        dr["CHA_ADDRESS1"] = "";
        dr["CHA_ADDRESS2"] = "";
        dr["CHA_ADDRESS3"] = "";
        dr["CHA_ADDRESS4"] = "";
        dr["AEO_REGISTRATION_NUMBER"] = "";
        dr["AEO_REGISTER_ROLE"] = "";

        dt.Rows.Add(dr);

        //Store the DataTable in ViewState
        ViewState["CurrentTable"] = dt;

        gvAll.DataSource = dt;
        gvAll.DataBind();

    }

    private void SetPreviousData()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox txt_Imp_icegateId = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_icegateId");
                    TextBox txt_Imp_CHA_NO = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_CHA_NO");
                    TextBox txt_Imp_CHA_NAME = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_CHA_NAME");
                    TextBox txt_Imp_CHA_ADDRESS = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_CHA_ADDRESS");
                    TextBox txt_Imp_CHA_ADDRESS1 = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_CHA_ADDRESS1");
                    TextBox txt_Imp_CHA_ADDRESS2 = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_CHA_ADDRESS2");
                    TextBox txt_Imp_CHA_ADDRESS3 = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_CHA_ADDRESS3");
                    TextBox txt_Imp_CHA_ADDRESS4 = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_CHA_ADDRESS4");
                    TextBox txt_Imp_AEO_REGISTRATION_NUMBER = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_AEO_REGISTRATION_NUMBER");
                    TextBox txt_Imp_AEO_REGISTER_ROLE = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_AEO_REGISTER_ROLE");
                    gvAll.Rows[i].Cells[0].Text = Convert.ToString(i + 1);

                    if (dt.Rows[i][1].ToString() != "" || dt.Rows[i][2].ToString() != "" || dt.Rows[i][3].ToString() != "" || dt.Rows[i][4].ToString() != "" ||
                        dt.Rows[i][5].ToString() != "" || dt.Rows[i][6].ToString() != "" || dt.Rows[i][7].ToString() != "" || dt.Rows[i][8].ToString() != "" ||
                        dt.Rows[i][9].ToString() != "" || dt.Rows[i][10].ToString() != "")
                    {
                        txt_Imp_icegateId.Text = dt.Rows[i][1].ToString();
                        txt_Imp_CHA_NO.Text = dt.Rows[i]["CHA_NO"].ToString();
                        txt_Imp_CHA_NAME.Text = dt.Rows[i]["CHA_NAME"].ToString();
                        txt_Imp_CHA_ADDRESS.Text = dt.Rows[i]["CHA_ADDRESS"].ToString();
                        txt_Imp_CHA_ADDRESS1.Text = dt.Rows[i]["CHA_ADDRESS1"].ToString();
                        txt_Imp_CHA_ADDRESS2.Text = dt.Rows[i]["CHA_ADDRESS2"].ToString();
                        txt_Imp_CHA_ADDRESS3.Text = dt.Rows[i]["CHA_ADDRESS3"].ToString();
                        txt_Imp_CHA_ADDRESS4.Text = dt.Rows[i]["CHA_ADDRESS4"].ToString();
                        txt_Imp_AEO_REGISTRATION_NUMBER.Text = dt.Rows[i]["AEO_REGISTRATION_NUMBER"].ToString();
                        txt_Imp_AEO_REGISTER_ROLE.Text = dt.Rows[i]["AEO_REGISTER_ROLE"].ToString();
                        rowIndex++;
                    }
                    else
                    {
                        txt_Imp_icegateId.Text = "";
                        txt_Imp_CHA_NO.Text = string.Empty;
                        txt_Imp_CHA_NAME.Text = string.Empty;
                        txt_Imp_CHA_ADDRESS.Text = string.Empty;
                        txt_Imp_CHA_ADDRESS1.Text = string.Empty;
                        txt_Imp_CHA_ADDRESS2.Text = string.Empty;
                        txt_Imp_CHA_ADDRESS3.Text = string.Empty;
                        txt_Imp_CHA_ADDRESS4.Text = string.Empty;
                        txt_Imp_AEO_REGISTRATION_NUMBER.Text = string.Empty;
                        txt_Imp_AEO_REGISTER_ROLE.Text = string.Empty;
                    }
                }
            }
        }
    }

    private void SetRowData()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //extract the TextBox values
                    TextBox txt_Imp_icegateId = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_icegateId");
                    TextBox txt_Imp_CHA_NO = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_CHA_NO");
                    TextBox txt_Imp_CHA_NAME = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_CHA_NAME");
                    TextBox txt_Imp_CHA_ADDRESS = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_CHA_ADDRESS");
                    TextBox txt_Imp_CHA_ADDRESS1 = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_CHA_ADDRESS1");
                    TextBox txt_Imp_CHA_ADDRESS2 = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_CHA_ADDRESS2");
                    TextBox txt_Imp_CHA_ADDRESS3 = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_CHA_ADDRESS3");
                    TextBox txt_Imp_CHA_ADDRESS4 = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_CHA_ADDRESS4");
                    TextBox txt_Imp_AEO_REGISTRATION_NUMBER = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_AEO_REGISTRATION_NUMBER");
                    TextBox txt_Imp_AEO_REGISTER_ROLE = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Imp_AEO_REGISTER_ROLE");

                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["ICEGATE_ID"] = txt_Imp_icegateId.Text;
                    dtCurrentTable.Rows[i - 1]["CHA_NO"] = txt_Imp_CHA_NO.Text;
                    dtCurrentTable.Rows[i - 1]["CHA_NAME"] = txt_Imp_CHA_NAME.Text;
                    dtCurrentTable.Rows[i - 1]["CHA_ADDRESS"] = txt_Imp_CHA_ADDRESS.Text;
                    dtCurrentTable.Rows[i - 1]["CHA_ADDRESS1"] = txt_Imp_CHA_ADDRESS1.Text;
                    dtCurrentTable.Rows[i - 1]["CHA_ADDRESS2"] = txt_Imp_CHA_ADDRESS2.Text;
                    dtCurrentTable.Rows[i - 1]["CHA_ADDRESS3"] = txt_Imp_CHA_ADDRESS3.Text;
                    dtCurrentTable.Rows[i - 1]["CHA_ADDRESS4"] = txt_Imp_CHA_ADDRESS4.Text;
                    dtCurrentTable.Rows[i - 1]["AEO_REGISTRATION_NUMBER"] = txt_Imp_AEO_REGISTRATION_NUMBER.Text;
                    dtCurrentTable.Rows[i - 1]["AEO_REGISTER_ROLE"] = txt_Imp_AEO_REGISTER_ROLE.Text;
                    rowIndex++;
                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;
            }
        }
        else
        {
            //Response.Write("ViewState is null");
        }
    }

    private void SetInitialRow_Export()
    {
        DataTable dt_Exp = new DataTable();

        DataRow dr = null;

        dt_Exp.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt_Exp.Columns.Add(new DataColumn("ICEGATE_ID", typeof(string)));
        dt_Exp.Columns.Add(new DataColumn("CHA_NO", typeof(string)));
        dt_Exp.Columns.Add(new DataColumn("CHA_NAME", typeof(string)));
        dt_Exp.Columns.Add(new DataColumn("CHA_ADDRESS", typeof(string)));
        dt_Exp.Columns.Add(new DataColumn("CHA_ADDRESS1", typeof(string)));
        dt_Exp.Columns.Add(new DataColumn("CHA_ADDRESS2", typeof(string)));
        dt_Exp.Columns.Add(new DataColumn("CHA_ADDRESS3", typeof(string)));
        dt_Exp.Columns.Add(new DataColumn("CHA_ADDRESS4", typeof(string)));
        dt_Exp.Columns.Add(new DataColumn("AEO_REGISTRATION_NUMBER", typeof(string)));
        dt_Exp.Columns.Add(new DataColumn("AEO_REGISTER_ROLE", typeof(string)));


        dr = dt_Exp.NewRow();
        dr["RowNumber"] = 1;
        dr["ICEGATE_ID"] = string.Empty;
        dr["CHA_NO"] = "";
        dr["CHA_NAME"] = "";
        dr["CHA_ADDRESS"] = "";
        dr["CHA_ADDRESS1"] = "";
        dr["CHA_ADDRESS2"] = "";
        dr["CHA_ADDRESS3"] = "";
        dr["CHA_ADDRESS4"] = "";
        dr["AEO_REGISTRATION_NUMBER"] = "";
        dr["AEO_REGISTER_ROLE"] = "";
        dt_Exp.Rows.Add(dr);

        ViewState["CurrentTable_Exp"] = dt_Exp;

        gvExport.DataSource = dt_Exp;
        gvExport.DataBind();

    }

    protected void gvAll_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SetRowData();
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            int rowIndex = Convert.ToInt32(e.RowIndex);
            if (dt.Rows.Count > 1)
            {
                dt.Rows.Remove(dt.Rows[rowIndex]);
                // drCurrentRow = dt.NewRow();
                ViewState["CurrentTable"] = dt;


                /*gvAll.DataSource = dt;
                gvAll.DataBind();*/

                SetPreviousData();

                // for (int i = 0; i < gvAll.Rows.Count - 1; i++)
                // {
                //     gvAll.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                // }
                //SetPreviousData();
            }
            else
            {
                Alert_msg("Cannot delete. At least one row must remain.");
            }
        }

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
        }
    }

    protected void gvAll_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAll.EditIndex = e.NewEditIndex;
    }


    protected void ButtonAdd_Exp_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid_Exp();

        //http://www.codeproject.com/Articles/30722/How-to-save-data-from-a-DataSet-into-a-T-SQL-table
        // sp_name EXP_BL_GENERATION_INS_UPD
    }

    private void SetPreviousData_Exp()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable_Exp"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable_Exp"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox txt_Exp_icegateId = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_icegateId");
                    TextBox txt_Exp_CHA_NO = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_CHA_NO");
                    TextBox txt_Exp_CHA_NAME = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_CHA_NAME");
                    TextBox txt_Exp_CHA_ADDRESS = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_CHA_ADDRESS");
                    TextBox txt_Exp_CHA_ADDRESS1 = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_CHA_ADDRESS1");
                    TextBox txt_Exp_CHA_ADDRESS2 = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_CHA_ADDRESS2");
                    TextBox txt_Exp_CHA_ADDRESS3 = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_CHA_ADDRESS3");
                    TextBox txt_Exp_CHA_ADDRESS4 = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_CHA_ADDRESS4");
                    TextBox txt_Exp_AEO_REGISTRATION_NUMBER = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_AEO_REGISTRATION_NUMBER");
                    TextBox txt_Exp_AEO_REGISTER_ROLE = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_AEO_REGISTER_ROLE");

                    gvExport.Rows[i].Cells[0].Text = Convert.ToString(i + 1);

                    if (dt.Rows[i][1].ToString() != "" || dt.Rows[i][2].ToString() != "" || dt.Rows[i][2].ToString() != "" ||
                        dt.Rows[i][3].ToString() != "" || dt.Rows[i][4].ToString() != "" || dt.Rows[i][5].ToString() != "" ||
                        dt.Rows[i][6].ToString() != "" || dt.Rows[i][7].ToString() != "" || dt.Rows[i][8].ToString() != "" ||
                        dt.Rows[i][9].ToString() != "" || dt.Rows[i][10].ToString() != "")
                    {
                        txt_Exp_icegateId.Text = dt.Rows[i][1].ToString();
                        txt_Exp_CHA_NO.Text = dt.Rows[i]["CHA_NO"].ToString();
                        txt_Exp_CHA_NAME.Text = dt.Rows[i]["CHA_NAME"].ToString();
                        txt_Exp_CHA_ADDRESS.Text = dt.Rows[i]["CHA_ADDRESS"].ToString();
                        txt_Exp_CHA_ADDRESS1.Text = dt.Rows[i]["CHA_ADDRESS1"].ToString();
                        txt_Exp_CHA_ADDRESS2.Text = dt.Rows[i]["CHA_ADDRESS2"].ToString();
                        txt_Exp_CHA_ADDRESS3.Text = dt.Rows[i]["CHA_ADDRESS3"].ToString();
                        txt_Exp_CHA_ADDRESS4.Text = dt.Rows[i]["CHA_ADDRESS4"].ToString();
                        txt_Exp_AEO_REGISTRATION_NUMBER.Text = dt.Rows[i]["AEO_REGISTRATION_NUMBER"].ToString();
                        txt_Exp_AEO_REGISTER_ROLE.Text = dt.Rows[i]["AEO_REGISTER_ROLE"].ToString();
                        rowIndex++;
                    }
                    else
                    {
                        txt_Exp_icegateId.Text = "";
                        txt_Exp_CHA_NO.Text = string.Empty;
                        txt_Exp_CHA_NAME.Text = string.Empty;
                        txt_Exp_CHA_ADDRESS.Text = string.Empty;
                        txt_Exp_CHA_ADDRESS1.Text = string.Empty;
                        txt_Exp_CHA_ADDRESS2.Text = string.Empty;
                        txt_Exp_CHA_ADDRESS3.Text = string.Empty;
                        txt_Exp_CHA_ADDRESS4.Text = string.Empty;
                        txt_Exp_AEO_REGISTRATION_NUMBER.Text = string.Empty;
                        txt_Exp_AEO_REGISTER_ROLE.Text = string.Empty;
                    }
                }
            }
        }
    }

    private void SetRowData_Exp()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable_Exp"] != null)
        {
            DataTable CurrentTable_Exp = (DataTable)ViewState["CurrentTable_Exp"];
            DataRow drCurrentRow = null;
            if (CurrentTable_Exp.Rows.Count > 0)
            {
                for (int i = 1; i <= CurrentTable_Exp.Rows.Count; i++)
                {
                    //extract the TextBox values
                    TextBox txt_Exp_icegateId = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_icegateId");
                    TextBox txt_Exp_CHA_NO = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_CHA_NO");
                    TextBox txt_Exp_CHA_NAME = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_CHA_NAME");
                    TextBox txt_Exp_CHA_ADDRESS = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_CHA_ADDRESS");
                    TextBox txt_Exp_CHA_ADDRESS1 = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_CHA_ADDRESS1");
                    TextBox txt_Exp_CHA_ADDRESS2 = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_CHA_ADDRESS2");
                    TextBox txt_Exp_CHA_ADDRESS3 = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_CHA_ADDRESS3");
                    TextBox txt_Exp_CHA_ADDRESS4 = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_CHA_ADDRESS4");
                    TextBox txt_Exp_AEO_REGISTRATION_NUMBER = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_AEO_REGISTRATION_NUMBER");
                    TextBox txt_Exp_AEO_REGISTER_ROLE = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_AEO_REGISTER_ROLE");

                    drCurrentRow = CurrentTable_Exp.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;
                    CurrentTable_Exp.Rows[i - 1]["ICEGATE_ID"] = txt_Exp_icegateId.Text;
                    CurrentTable_Exp.Rows[i - 1]["CHA_NO"] = txt_Exp_CHA_NO.Text;
                    CurrentTable_Exp.Rows[i - 1]["CHA_NAME"] = txt_Exp_CHA_NAME.Text;
                    CurrentTable_Exp.Rows[i - 1]["CHA_ADDRESS"] = txt_Exp_CHA_ADDRESS.Text;
                    CurrentTable_Exp.Rows[i - 1]["CHA_ADDRESS1"] = txt_Exp_CHA_ADDRESS1.Text;
                    CurrentTable_Exp.Rows[i - 1]["CHA_ADDRESS2"] = txt_Exp_CHA_ADDRESS2.Text;
                    CurrentTable_Exp.Rows[i - 1]["CHA_ADDRESS3"] = txt_Exp_CHA_ADDRESS3.Text;
                    CurrentTable_Exp.Rows[i - 1]["CHA_ADDRESS4"] = txt_Exp_CHA_ADDRESS4.Text;
                    CurrentTable_Exp.Rows[i - 1]["AEO_REGISTRATION_NUMBER"] = txt_Exp_AEO_REGISTRATION_NUMBER.Text;
                    CurrentTable_Exp.Rows[i - 1]["AEO_REGISTER_ROLE"] = txt_Exp_AEO_REGISTER_ROLE.Text;
                    rowIndex++;
                }
                CurrentTable_Exp.Rows.Add(drCurrentRow);
                ViewState["CurrentTable_Exp"] = CurrentTable_Exp;
            }
        }
        else
        {

        }
    }


    private void AddNewRowToGrid_Exp()
    {
        int rowIndex = 0;
        string Emptyrow = string.Empty;

        if (ViewState["CurrentTable_Exp"] != null)
        {
            DataTable dtCurrentTable_Exp = (DataTable)ViewState["CurrentTable_Exp"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable_Exp.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable_Exp.Rows.Count; i++)
                {
                    //extract the TextBox values
                    TextBox txt_Exp_icegateId = (TextBox)gvExport.Rows[rowIndex].Cells[0].FindControl("txt_Exp_icegateId");
                    TextBox txt_Exp_CHA_NO = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_CHA_NO");
                    TextBox txt_Exp_CHA_NAME = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_CHA_NAME");
                    TextBox txt_Exp_CHA_ADDRESS = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_CHA_ADDRESS");
                    TextBox txt_Exp_CHA_ADDRESS1 = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_CHA_ADDRESS1");
                    TextBox txt_Exp_CHA_ADDRESS2 = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_CHA_ADDRESS2");
                    TextBox txt_Exp_CHA_ADDRESS3 = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_CHA_ADDRESS3");
                    TextBox txt_Exp_CHA_ADDRESS4 = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_CHA_ADDRESS4");
                    TextBox txt_Exp_AEO_REGISTRATION_NUMBER = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_AEO_REGISTRATION_NUMBER");
                    TextBox txt_Exp_AEO_REGISTER_ROLE = (TextBox)gvExport.Rows[rowIndex].Cells[1].FindControl("txt_Exp_AEO_REGISTER_ROLE");


                    if (string.IsNullOrEmpty(txt_Exp_icegateId.Text) || string.IsNullOrEmpty(txt_Exp_CHA_NO.Text) || string.IsNullOrEmpty(txt_Exp_CHA_NAME.Text))
                    {
                        Emptyrow = "Y";
                        break;
                    }

                    drCurrentRow = dtCurrentTable_Exp.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;
                    dtCurrentTable_Exp.Rows[i - 1]["ICEGATE_ID"] = txt_Exp_icegateId.Text;
                    dtCurrentTable_Exp.Rows[i - 1]["CHA_NO"] = txt_Exp_CHA_NO.Text;
                    dtCurrentTable_Exp.Rows[i - 1]["CHA_NAME"] = txt_Exp_CHA_NAME.Text;
                    dtCurrentTable_Exp.Rows[i - 1]["CHA_ADDRESS"] = txt_Exp_CHA_ADDRESS.Text;
                    dtCurrentTable_Exp.Rows[i - 1]["CHA_ADDRESS1"] = txt_Exp_CHA_ADDRESS1.Text;
                    dtCurrentTable_Exp.Rows[i - 1]["CHA_ADDRESS2"] = txt_Exp_CHA_ADDRESS2.Text;
                    dtCurrentTable_Exp.Rows[i - 1]["CHA_ADDRESS3"] = txt_Exp_CHA_ADDRESS3.Text;
                    dtCurrentTable_Exp.Rows[i - 1]["CHA_ADDRESS4"] = txt_Exp_CHA_ADDRESS4.Text;
                    dtCurrentTable_Exp.Rows[i - 1]["AEO_REGISTRATION_NUMBER"] = txt_Exp_AEO_REGISTRATION_NUMBER.Text;
                    dtCurrentTable_Exp.Rows[i - 1]["AEO_REGISTER_ROLE"] = txt_Exp_AEO_REGISTER_ROLE.Text;

                    rowIndex++;
                }

                if (Emptyrow != "Y")
                {
                    dtCurrentTable_Exp.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable_Exp"] = dtCurrentTable_Exp;

                    gvExport.DataSource = dtCurrentTable_Exp;
                    gvExport.DataBind();
                    SetPreviousData_Exp();
                }
                else
                {
                    Alert_msg("EXPORT ICEGATEID,CHANAME & CHA NO ARE MANDATORY!");
                }
            }
        }
        else
        {

        }
    }

    protected void gvExport_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SetRowData_Exp();
        if (ViewState["CurrentTable_Exp"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable_Exp"];
            DataRow drCurrentRow = null;
            int rowIndex = Convert.ToInt32(e.RowIndex);
            if (dt.Rows.Count > 1)
            {
                dt.Rows.Remove(dt.Rows[rowIndex]);
                // drCurrentRow = dt.NewRow();
                ViewState["CurrentTable_Exp"] = dt;


                /*gvAll.DataSource = dt;
                gvAll.DataBind();*/

                SetPreviousData_Exp();

                // for (int i = 0; i < gvAll.Rows.Count - 1; i++)
                // {
                //     gvAll.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                // }
                //SetPreviousData();
            }
            else
            {
                Alert_msg("Cannot delete. At least one row must remain");
            }
        }

    }

    protected void gvExport_RowCreated(object sender, GridViewRowEventArgs e)
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

    protected void gvExport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }

    protected void gvExport_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvExport.EditIndex = e.NewEditIndex;
    }

    public int Get_MAXID(string Flag)
    {
        int MAX_ID = 0;
        DataSet dt_max = new DataSet();

        User.flag = Flag;
        dt_max = User.RetrieveAll_User_ICEGATE_ID_Settings(HttpContext.Current.Session["currentcomp_db"].ToString());

        if (dt_max.Tables[0].Rows.Count > 0)
        {
            MAX_ID = Convert.ToInt32(dt_max.Tables[0].Rows[0]["MAXID"].ToString());
        }

        return MAX_ID;
    }

    public void Delete_ICEGATE_ID_ALL(string flag)
    {

        DataSet Exp_ds1 = new DataSet();
        User.COMPANY_ID = COMPANY_ID;
        User.USER_CREATION_ID = USER_CREATION_ID;
        User.ACTION_BRANCH = ddlLoad_Branch.SelectedValue;
        User.flag = flag;
        Exp_ds1 = User.RetrieveAll_User_ICEGATE_ID_Settings(HttpContext.Current.Session["currentcomp_db"].ToString());
    }


    protected void ddlLoad_Branch_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Load_User_Settings_Details();
    }
}