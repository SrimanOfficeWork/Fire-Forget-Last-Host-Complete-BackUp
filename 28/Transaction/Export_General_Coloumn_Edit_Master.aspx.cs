using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class Export_General_Coloumn_Edit_Master : ThemeClass
{
    DataSet ds = new DataSet();
    StringBuilder sb = new StringBuilder();

    Internal_Mail mail = new Internal_Mail();
    AppSession aps = new AppSession();
    Company_Master Comp = new Company_Master();
    User_Creation User = new User_Creation();
    ErrorLogs er = new ErrorLogs();

    public int i;
    public string COMPANY_ID, USER_CREATION_ID, BRANCH, USER_ID;
    public string currentuser;

    // ══ ACTIVE PAGE PROPERTY ════════════════════════════════════════
    public int ActivePage
    {
        get
        {
            int pg;
            return int.TryParse(hdn_ActivePage.Value, out pg)
                   && pg >= 1 && pg <= 1 ? pg : 1;
        }
    }

    // ══ PAGE LABEL HELPER ═══════════════════════════════════════════
    public string PageLabel(int page)
    {
        switch (page)
        {
            case 1: return "General";
            //case 3: return "Invoice";
            default: return "";
        }
    }

    // ══ BRANCH DETAILS CLASS ════════════════════════════════════════
    public sealed class BranchDetails
    {
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public string Comp_License { get; set; }
        public string result { get; set; }
    }

    // ══ PAGE LOAD ═══════════════════════════════════════════════════
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (Session["COMPANY_ID"] != null)
        {
            COMPANY_ID = Session["COMPANY_ID"].ToString();
            currentuser = Connection.Current_User();

            if (Session["USER_CREATION_ID_EDIT"] != null)
                USER_CREATION_ID = Session["USER_CREATION_ID_EDIT"].ToString();
            else if (Session["USER_CREATION_ID"] != null)
                USER_CREATION_ID = Session["USER_CREATION_ID"].ToString();
            else
            {
                Response.Write("<script>window.open('Login.aspx','_parent');</script>");
                return;
            }
        }
        else
        {
            Response.Write("<script>window.open('Login.aspx','_parent');</script>");
            return;
        }

        // Register hidden delete button for full postback
        ScriptManager sm = ScriptManager.GetCurrent(this.Page);
        if (sm != null)
            sm.RegisterPostBackControl(btn);

        if (!IsPostBack)
        {
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            Bind_Group(Session["WorkingPeriod"].ToString());
            LoadActiveTabData(); // ✅ first load only — no DB hit on postback
            ddlBind();
        }
        // ✅ NO else block — never hit DB on every postback in Page_Load
    }

    // ══ CENTRAL TAB DATA LOADER — called only where truly needed ════
    private void LoadActiveTabData()
    {
        switch (ActivePage)
        {
            case 1: Load_General_Settings(); break;
            //case 3: Load_INVOICE_Settings(); break;
            //case 4: Load_Unit_Settings(); break;
        }
    }

    // ══ BIND GROUP DROPDOWN ══════════════════════════════════════════
    private void Bind_Group(string wk)
    {
        ddlGroupname.Items.Clear();
        DataSet ds = new DataSet();
        ds = (DataSet)HttpContext.Current.Session["COMPANY_DETAILS_DS"];

        DataView view1 = ds.Tables[2].DefaultView;
        view1.RowFilter = "WORKING_PERIOD = '" + wk + "'";

        Comp.COMPANY_ID = "";
        Comp.BRANCH = "";
        Comp.flag = "Select-Group";
        ds = Comp.RetrieveAll_Groups();
        HttpContext.Current.Session["ClientGrpMst"] = ds;

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlGroupname.DataSource = ds.Tables[0];
            ddlGroupname.DataTextField = "GROUP_NAME";
            ddlGroupname.DataValueField = "GROUP_ID";
            ddlGroupname.DataBind();
            Bind_Branch(ds.Tables[0].Rows[0]["GROUP_ID"].ToString(), ds.Tables[1]);
        }
    }

    // ══ BIND BRANCH DROPDOWN — DataBind moved OUTSIDE loop ══════════
    private void Bind_Branch(string grpid, DataTable dt)
    {
        ddlLoad_Branch.Items.Clear();

        if (Session["COMPANY_DETAILS_DS"] != null)
            ds = (DataSet)Session["COMPANY_DETAILS_DS"];

        DataView view1 = dt.DefaultView;
        view1.RowFilter = "GROUP_ID = '" + grpid + "'";
        dt = view1.ToTable();

        List<BranchDetails> details = new List<BranchDetails>();

        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dtrow in dt.Rows)
            {
                string branch = dtrow["BRANCHCODE"].ToString();
                string branch_code = dtrow["CUSTOMHOUSE"].ToString();

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
                        if (mode == "A") Category_mode = "Air";
                        if (mode == "S") Category_mode = "Sea";
                        if (mode == "L") Category_mode = "Land";
                        if (a == "Customs, Mundra") Category_mode = "Sea";

                        BranchDetails Branch = new BranchDetails();
                        Branch.CountryId = dtrow["BRANCHCODE"].ToString();
                        Branch.CountryName = custom_Branch + "(" + Category_mode + ")";
                        Branch.result = Convert.ToString(Comp.result);
                        details.Add(Branch);
                    }
                }
            } // ✅ loop ends here

            // ✅ DataBind ONCE outside loop
            ddlLoad_Branch.DataSource = details.ToArray();
            ddlLoad_Branch.DataValueField = "CountryId";
            ddlLoad_Branch.DataTextField = "CountryName";
            ddlLoad_Branch.DataBind();
        }
    }

    //// ══ DROPDOWN EVENTS ══════════════════════════════════════════════
    //protected void ddlGroupname_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    ds = (DataSet)HttpContext.Current.Session["ClientGrpMst"];
    //    Bind_Branch(ddlGroupname.SelectedValue, ds.Tables[1]);
    //    ddlGroupname.Focus();
    //    LoadActiveTabData(); // reload active tab data on branch change
    //}

    //protected void ddlLoad_Branch_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    LoadActiveTabData();
    //}
    //protected void btnTabSwitch_Click(object sender, EventArgs e)
    //{
    //    // ✅ Load correct tab data based on active page
    //    switch (ActivePage)
    //    {
    //        case 1:
    //            Load_General_Settings();
    //            break;
    //        //case 3:
    //        //    Load_INVOICE_Settings();
    //        //    break;


    //    }

    //    // ✅ Set correct buttons for active tab
    //    Set_Button_Visibility();
    //    UpdatePanel1.Update();
    //}




    protected void ddlGroupname_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["PendingNew"] = false; 
        ds = (DataSet)HttpContext.Current.Session["ClientGrpMst"];
        Bind_Branch(ddlGroupname.SelectedValue, ds.Tables[1]);
        ddlGroupname.Focus();
        LoadActiveTabData();
    }

    protected void ddlLoad_Branch_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["PendingNew"] = false;  
        LoadActiveTabData();
    }

    protected void btnTabSwitch_Click(object sender, EventArgs e)
    {
        ViewState["PendingNew"] = false;   
        switch (ActivePage)
        {
            case 1:
                Load_General_Settings();
                break;
        }

        Set_Button_Visibility();
        UpdatePanel1.Update();
    }

    private string TargetUserCreationId
    {
        get
        {
            if (ddlUserName != null && !string.IsNullOrEmpty(ddlUserName.SelectedValue))
                return ddlUserName.SelectedValue;

            return USER_CREATION_ID; 
        }
    }



    private void Sync_Branch_To_Selected_User()
    {
        try
        {
            if (string.IsNullOrEmpty(ddlUserName.SelectedValue))
                return;

            User.COMPANY_ID = COMPANY_ID;
            User.USER_CREATION_ID = ddlUserName.SelectedValue;
            User.flag = "Select_User_Branch";  

            DataSet ds = User.Imp_Col_Edit_Insert_update(
                             HttpContext.Current.Session["currentcomp_db"].ToString());

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return;

            DataRow row = ds.Tables[0].Rows[0];
            string branchCode = (row["BRANCH_CODE"] == DBNull.Value) ? "" : row["BRANCH_CODE"].ToString();
            string groupId = (row["GROUP_ID"] == DBNull.Value) ? "" : row["GROUP_ID"].ToString();

            if (string.IsNullOrEmpty(groupId))
                return;

            DataSet grpDs = (DataSet)HttpContext.Current.Session["ClientGrpMst"];
            if (grpDs == null || grpDs.Tables.Count < 2)
                return;

            if (ddlGroupname.Items.FindByValue(groupId) != null)
                ddlGroupname.SelectedValue = groupId;

            Bind_Branch(groupId, grpDs.Tables[1]);

            if (!string.IsNullOrEmpty(branchCode) && ddlLoad_Branch.Items.FindByValue(branchCode) != null)
                ddlLoad_Branch.SelectedValue = branchCode;
        }
        catch (Exception ex) { er.makeLog(ex.Message); }
    }

    protected void ddlUserName_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["PendingNew"] = false;   
        Sync_Branch_To_Selected_User();
        LoadActiveTabData();
        Set_Button_Visibility();
        UpdatePanel1.Update();
    }

    private void Set_Button_Visibility()
    {
        try
        {
            string flag = "";
            switch (ActivePage)
            {
                case 1: flag = "Select_Exp_Col_Setngs"; break;
                default: flag = "Select_Exp_Col_Setngs"; break;
            }

            User.COMPANY_ID = COMPANY_ID;
            User.USER_ID = currentuser;
            //User.USER_CREATION_ID = USER_CREATION_ID;
            User.USER_CREATION_ID = TargetUserCreationId;   // ← changed
            User.ACTION_BRANCH = ddlLoad_Branch.SelectedValue;
            User.flag = flag;
            // ✅ No empty defaults needed anymore

            DataSet ds = User.Exp_Col_Edit_Insert_update(
                             HttpContext.Current.Session["currentcomp_db"].ToString());

            bool hasData = ds != null
                           && ds.Tables.Count > 0
                           && ds.Tables[0].Rows.Count > 0;

            btnSave.Visible = !hasData;
            btnUpdate.Visible = hasData;
            btnDelete.Visible = hasData;
        }
        catch (Exception ex) { er.makeLog(ex.Message); }
    }


    // ════════════════════════════════════════════════════════════════
    //  LOAD METHODS — one per tab
    // ════════════════════════════════════════════════════════════════

    private void Load_General_Settings()
    {
        try
        {
            User.COMPANY_ID = COMPANY_ID;
            User.USER_ID = currentuser;
            //User.USER_CREATION_ID = USER_CREATION_ID;
            User.USER_CREATION_ID = TargetUserCreationId;   // ← changed
            User.ACTION_BRANCH = ddlLoad_Branch.SelectedValue;
            User.flag = "Select_Exp_Col_Setngs";

            DataSet Exp_ds = User.Exp_Col_Edit_Insert_update(
                                 HttpContext.Current.Session["currentcomp_db"].ToString());

            if (Exp_ds != null && Exp_ds.Tables.Count > 0
                               && Exp_ds.Tables[0].Rows.Count > 0)
            {
                rdl_General_ExporterName.SelectedValue = Exp_ds.Tables[0].Rows[0]["EXPORT_GENERAL_EXPORTER_NAME"].ToString();
                rdl_General_IECNo.SelectedValue = Exp_ds.Tables[0].Rows[0]["EXPORT_GENERAL_IEC_NO"].ToString();
                rdl_General_Branch_SL_No.SelectedValue = Exp_ds.Tables[0].Rows[0]["EXPORT_GENERAL_BRANCH_SL_NO"].ToString();
                rdl_General_Address.SelectedValue = Exp_ds.Tables[0].Rows[0]["EXPORT_GENERAL_ADDRESS"].ToString();
                rdl_General_Pin.SelectedValue = Exp_ds.Tables[0].Rows[0]["EXPORT_GENERAL_PIN"].ToString();
                rdl_General_GSTN_ID.SelectedValue = Exp_ds.Tables[0].Rows[0]["EXPORT_GENERAL_GSTN_ID"].ToString();
                rdl_General_GSTN_Type.SelectedValue = Exp_ds.Tables[0].Rows[0]["EXPORT_GENERAL_GSTN_TYPE"].ToString();
                rdl_General_Type_Of_Exporter.SelectedValue = Exp_ds.Tables[0].Rows[0]["EXPORT_GENERAL_TYPE_OF_EXPORTER"].ToString();
                rdl_General_Country_Discharge.SelectedValue = Exp_ds.Tables[0].Rows[0]["EXPORT_GENERAL_COUNTRY_DISCHARGE"].ToString();
                rdl_General_Port_Discharge.SelectedValue = Exp_ds.Tables[0].Rows[0]["EXPORT_GENERAL_PORT_DISCHARGE"].ToString();
                rdl_General_Country_Final_Destination.SelectedValue = Exp_ds.Tables[0].Rows[0]["EXPORT_GENERAL_COUNTRY_FINAL_DESTINATION"].ToString();
                rdl_General_Port_Final_Destination.SelectedValue = Exp_ds.Tables[0].Rows[0]["EXPORT_GENERAL_PORT_FINAL_DESTINATION"].ToString();
                rdl_General_State_Of_Export.SelectedValue = Exp_ds.Tables[0].Rows[0]["EXPORT_GENERAL_STATE_OF_EXPORT"].ToString();
                rdl_General_Consignee_Name.SelectedValue = Exp_ds.Tables[0].Rows[0]["EXPORT_GENERAL_CONSIGNEE_NAME"].ToString();
                rdl_General_AD_Code.SelectedValue = Exp_ds.Tables[0].Rows[0]["EXPORT_GENERAL_AD_CODE"].ToString();
                rdl_General_Consignee_Address.SelectedValue = Exp_ds.Tables[0].Rows[0]["EXPORT_GENERAL_CONSIGNEE_ADDRESS"].ToString();
                rdl_General_Country.SelectedValue = Exp_ds.Tables[0].Rows[0]["EXPORT_GENERAL_CONSIGNEE_COUNTRY"].ToString();
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
            }
            else
            {
                Reset_Export_General();
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
            }
        }
        catch (Exception ex) { er.makeLog(ex.Message); }
    }


    private void Reset_Export_General()
    {
        rdl_General_ExporterName.SelectedValue = "Y";
        rdl_General_IECNo.SelectedValue = "Y";
        rdl_General_Branch_SL_No.SelectedValue = "Y";
        rdl_General_Address.SelectedValue = "Y";
        rdl_General_Pin.SelectedValue = "Y";
        rdl_General_GSTN_ID.SelectedValue = "Y";
        rdl_General_GSTN_Type.SelectedValue = "Y";
        rdl_General_Type_Of_Exporter.SelectedValue = "Y";
        rdl_General_Country_Discharge.SelectedValue = "Y";
        rdl_General_Port_Discharge.SelectedValue = "Y";
        rdl_General_Country_Final_Destination.SelectedValue = "Y";
        rdl_General_Port_Final_Destination.SelectedValue = "Y";
        rdl_General_State_Of_Export.SelectedValue = "Y";
        rdl_General_Consignee_Name.SelectedValue = "Y";
        rdl_General_AD_Code.SelectedValue = "Y";
        rdl_General_Consignee_Address.SelectedValue = "Y";
        rdl_General_Country.SelectedValue = "Y";
    }

   


    private int Insert_Update_Export_General(string flag)
    {
        try
        {
            string expFlag = "";
            if (flag == "S") expFlag = "S_EXP";
            else if (flag == "U") expFlag = "U_EXP";
            else expFlag = flag;

            //User.USER_CREATION_ID = USER_CREATION_ID;
            User.USER_CREATION_ID = TargetUserCreationId;   // ← changed
            User.COMPANY_ID = COMPANY_ID;
            User.USER_ID = currentuser;
            User.ACTION_BRANCH = ddlLoad_Branch.SelectedValue;
            User.EXPORT_GENERAL_EXPORTER_NAME = rdl_General_ExporterName.SelectedValue;
            User.EXPORT_GENERAL_IEC_NO = rdl_General_IECNo.SelectedValue;
            User.EXPORT_GENERAL_BRANCH_SL_NO = rdl_General_Branch_SL_No.SelectedValue;
            User.EXPORT_GENERAL_ADDRESS = rdl_General_Address.SelectedValue;
            User.EXPORT_GENERAL_PIN = rdl_General_Pin.SelectedValue;
            User.EXPORT_GENERAL_GSTN_ID = rdl_General_GSTN_ID.SelectedValue;
            User.EXPORT_GENERAL_GSTN_TYPE = rdl_General_GSTN_Type.SelectedValue;
            User.EXPORT_GENERAL_TYPE_OF_EXPORTER = rdl_General_Type_Of_Exporter.SelectedValue;
            User.EXPORT_GENERAL_COUNTRY_DISCHARGE = rdl_General_Country_Discharge.SelectedValue;
            User.EXPORT_GENERAL_PORT_DISCHARGE = rdl_General_Port_Discharge.SelectedValue;
            User.EXPORT_GENERAL_COUNTRY_FINAL_DESTINATION = rdl_General_Country_Final_Destination.SelectedValue;
            User.EXPORT_GENERAL_PORT_FINAL_DESTINATION = rdl_General_Port_Final_Destination.SelectedValue;
            User.EXPORT_GENERAL_STATE_OF_EXPORT = rdl_General_State_Of_Export.SelectedValue;
            User.EXPORT_GENERAL_CONSIGNEE_NAME = rdl_General_Consignee_Name.SelectedValue;
            User.EXPORT_GENERAL_AD_CODE = rdl_General_AD_Code.SelectedValue;
            User.EXPORT_GENERAL_CONSIGNEE_ADDRESS = rdl_General_Consignee_Address.SelectedValue;
            User.EXPORT_GENERAL_CONSIGNEE_COUNTRY = rdl_General_Country.SelectedValue;
            User.flag = expFlag;

            User.Exp_Col_Edit_Insert_update(
                HttpContext.Current.Session["currentcomp_db"].ToString());

            i = User.result;
        }
        catch (Exception ex) { er.makeLog(ex.Message); }
        return i;
    }


    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            switch (ActivePage)
            {
                case 1:
                    Reset_Export_General();   // reset the form only — no DB call
                    break;
            }

            // Remember that the NEXT Save should clear out the old row first.
            // Nothing is deleted yet.
            ViewState["PendingNew"] = true;

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
        }
        catch (Exception ex) { er.makeLog(ex.Message); }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            bool pendingNew = ViewState["PendingNew"] != null && (bool)ViewState["PendingNew"];
            if (pendingNew)
            {
                switch (ActivePage)
                {
                    case 1: Delete_Existing_Record("D_EXP"); break;
                }
                ViewState["PendingNew"] = false;
            }

            switch (ActivePage)
            {
                case 1:
                    i = Insert_Update_Export_General("S");
                    if (i == 1) { btnSave.Visible = false; btnUpdate.Visible = true; btnDelete.Visible = true; Alert_msg("General settings saved successfully."); }
                    else if (i == 2) Alert_msg("Record already exists. Click Update to modify.");
                    else Alert_msg("Save failed. Please try again.");
                    break;
            }
        }
        catch (Exception ex) { er.makeLog(ex.Message); }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            switch (ActivePage)
            {
                case 1:
                    i = Insert_Update_Export_General("U");
                    Alert_msg(i == 1 ? "General settings updated successfully."
                                     : "Update failed. Please try again.");
                    break;

            }
        }
        catch (Exception ex) { er.makeLog(ex.Message); }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            // Set common fields
            User.COMPANY_ID = COMPANY_ID;
            User.USER_CREATION_ID = USER_CREATION_ID;
            User.USER_CREATION_ID = TargetUserCreationId;   // ← changed
            User.USER_ID = currentuser;
            User.ACTION_BRANCH = ddlLoad_Branch.SelectedValue;

            switch (ActivePage)
            {
                case 1:
                    User.flag = "D_EXP";
                    User.Exp_Col_Edit_Insert_update(
                        HttpContext.Current.Session["currentcomp_db"].ToString());
                    i = User.result;
                    if (i == 1) { Reset_Export_General(); Load_General_Settings(); Alert_msg("General settings deleted successfully."); }
                    else Alert_msg("Delete failed. Please try again.");
                    break;
            }
        }
        catch (Exception ex) { er.makeLog(ex.Message); }
    }

    // ════════════════════════════════════════════════════════════════
    //  ALERT HELPERS
    // ════════════════════════════════════════════════════════════════

    public void Alert_msg(string msg)
    {
        string prompt = "setTimeout(function(){ showAlert('" + msg + "'); }, 100);";
        ScriptManager.RegisterStartupScript(this, this.GetType(),
            "alert_" + Guid.NewGuid().ToString(), prompt, true);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "setTimeout(function(){ showAlert('" + msg +
            "', function(){ document.getElementById('" + focus + "').focus(); }); }, 100);";
        ScriptManager.RegisterStartupScript(this, this.GetType(),
            "alert_" + Guid.NewGuid().ToString(), prompt, true);
    }


    private void Delete_Existing_Record(string flag)
    {
        try
        {
            User.COMPANY_ID = COMPANY_ID;
            //User.USER_CREATION_ID = USER_CREATION_ID;
            User.USER_CREATION_ID = TargetUserCreationId;   // ← changed
            User.USER_ID = currentuser;
            User.ACTION_BRANCH = ddlLoad_Branch.SelectedValue;
            User.flag = flag;
            // ✅ No empty defaults needed anymore

            User.Exp_Col_Edit_Insert_update(
                HttpContext.Current.Session["currentcomp_db"].ToString());
        }
        catch (Exception ex) { er.makeLog(ex.Message); }
    }


    public void ddlBind()
    {
        mail.flag = "Bind_mandatory_User";
        mail.FROM_DATE = "";
        mail.TO_DATE = "";
        ddlUserName.Items.Clear();
        ddlUserName.DataSource = mail.GetMail();
        ddlUserName.DataTextField = "USER_NAME";
        ddlUserName.DataValueField = "USER_CREATION_ID";
        ddlUserName.DataBind();
        ddlUserName.Items.Insert(0, "");
    }


}



























