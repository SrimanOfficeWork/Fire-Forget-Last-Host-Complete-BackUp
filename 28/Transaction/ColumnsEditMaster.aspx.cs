using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class ColumnsEditMaster : ThemeClass
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


    public int ActivePage
    {
        get
        {
            int pg;
            return int.TryParse(hdn_ActivePage.Value, out pg)
                   && pg >= 1 && pg <= 2 ? pg : 1;
        }
    }

    public string PageLabel(int page)
    {
        switch (page)
        {
            case 1: return "General";
            case 2: return "IGM";
            //case 3: return "Invoice";
            default: return "";
        }
    }

    public sealed class BranchDetails
    {
        public string CountryId    { get; set; }
        public string CountryName  { get; set; }
        public string Comp_License { get; set; }
        public string result       { get; set; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (Session["COMPANY_ID"] != null)
        {
            COMPANY_ID  = Session["COMPANY_ID"].ToString();
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

        ScriptManager sm = ScriptManager.GetCurrent(this.Page);
        if (sm != null)
            sm.RegisterPostBackControl(btn);

        if (!IsPostBack)
        {
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible   = true;
            Bind_Group(Session["WorkingPeriod"].ToString());
            LoadActiveTabData();
            ddlBind();
        }
    
    }

    public void ddlBind()
    {
        mail.flag = "Bind_mandatory_User";
        mail.FROM_DATE = "";
        mail.TO_DATE = "";
        ddlUserName.Items.Clear();
        ddlUserName.DataSource = mail.GetMail();
        ddlUserName.DataTextField = "USER_NAME";
        ddlUserName.DataValueField = "USER_CREATION_ID";   // ← changed from "USER_NAME"
        ddlUserName.DataBind();
        ddlUserName.Items.Insert(0, "");
    }

    private string TargetUserCreationId
    {
        get
        {
            if (ddlUserName != null && !string.IsNullOrEmpty(ddlUserName.SelectedValue))
            {
                // If Step 2 was applied, SelectedValue is already numeric — use it directly.
                return ddlUserName.SelectedValue;
            }

            return USER_CREATION_ID; // fallback: current session context, same as today
        }
    }


  

    protected void ddlUserName_SelectedIndexChanged(object sender, EventArgs e)
    {
        Sync_Branch_To_Selected_User();  
        LoadActiveTabData();           
        Set_Button_Visibility();   
        UpdatePanel1.Update();
    }



    private void LoadActiveTabData()
    {
        switch (ActivePage)
        {
            case 1: Load_General_Settings(); break;
            case 2: Load_IGM_Settings(); break;
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
        Comp.BRANCH     = "";
        Comp.flag       = "Select-Group";
        ds = Comp.RetrieveAll_Groups();
        HttpContext.Current.Session["ClientGrpMst"] = ds;

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlGroupname.DataSource     = ds.Tables[0];
            ddlGroupname.DataTextField  = "GROUP_NAME";
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
                string branch      = dtrow["BRANCHCODE"].ToString();
                string branch_code = dtrow["CUSTOMHOUSE"].ToString();

                string[] s1          = branch.Split(new string[] { "," }, StringSplitOptions.None);
                string custom_Branch = s1[1].ToString();

                DataView view2 = ds.Tables[3].DefaultView;
                view2.RowFilter = "CUSTOMHOUSE_CODE = '" + branch_code + "'";

                DataSet dt_UserRights = new DataSet();
                dt_UserRights.Tables.Add(view2.ToTable());

                if (dt_UserRights.Tables[0].Rows.Count > 0)
                {
                    string a    = dt_UserRights.Tables[0].Rows[0]["CUSTOMHOUSE_NAME"].ToString();
                    string mode = dt_UserRights.Tables[0].Rows[0]["CUSTOMHOUSE_CATEGORY"].ToString();
                    string Category_mode = "";

                    if (a == branch)
                    {
                        if (mode == "A") Category_mode = "Air";
                        if (mode == "S") Category_mode = "Sea";
                        if (mode == "L") Category_mode = "Land";
                        if (a == "Customs, Mundra") Category_mode = "Sea";

                        BranchDetails Branch = new BranchDetails();
                        Branch.CountryId   = dtrow["BRANCHCODE"].ToString();
                        Branch.CountryName = custom_Branch + "(" + Category_mode + ")";
                        Branch.result      = Convert.ToString(Comp.result);
                        details.Add(Branch);
                    }
                }
            } // ✅ loop ends here

            // ✅ DataBind ONCE outside loop
            ddlLoad_Branch.DataSource     = details.ToArray();
            ddlLoad_Branch.DataValueField = "CountryId";
            ddlLoad_Branch.DataTextField  = "CountryName";
            ddlLoad_Branch.DataBind();
        }
    }

    // ══ DROPDOWN EVENTS ══════════════════════════════════════════════
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

    protected void ddlGroupname_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["PendingNew"] = false;   // ← ADD THIS LINE
        ds = (DataSet)HttpContext.Current.Session["ClientGrpMst"];
        Bind_Branch(ddlGroupname.SelectedValue, ds.Tables[1]);
        ddlGroupname.Focus();
        LoadActiveTabData();
    }

    protected void ddlLoad_Branch_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["PendingNew"] = false;   // ← ADD THIS LINE
        LoadActiveTabData();
    }





    // ══ TAB SWITCH ═══════════════════════════════════════════════════
    //protected void btnTabSwitch_Click(object sender, EventArgs e)
    //{
    //    // hdn_ActivePage already updated by JS switchPage()
    //    // Just load that tab's DB data — no session needed
    //    LoadActiveTabData();
    //    UpdatePanel1.Update();
    //}

    //protected void btnTabSwitch_Click(object sender, EventArgs e)
    //{
    //    // ✅ Load correct tab data based on active page
    //    switch (ActivePage)
    //    {
    //        case 1:
    //            Load_General_Settings();
    //            break;
    //        case 2:
    //            Load_IGM_Settings();
    //            break;
    //        //case 3:
    //        //    Load_INVOICE_Settings();
    //        //    break;


    //    }

    //    // ✅ Set correct buttons for active tab
    //    Set_Button_Visibility();
    //    UpdatePanel1.Update();
    //}




    protected void btnTabSwitch_Click(object sender, EventArgs e)
    {
        ViewState["PendingNew"] = false;   // ← ADD THIS LINE
        switch (ActivePage)
        {
            case 1:
                Load_General_Settings();
                break;
            case 2:
                Load_IGM_Settings();
                break;
        }

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
                case 1: flag = "Select_Imp_Col_Setngs"; break;
                case 2: flag = "Select_Imp_IGm_Setngs"; break;
                //case 3: flag = "Select_Imp_INV_Setngs"; break;
                default: flag = "Select_Imp_Col_Setngs"; break;
            }

            User.COMPANY_ID = COMPANY_ID;
            User.USER_ID = currentuser;
            //User.USER_CREATION_ID = USER_CREATION_ID;
            User.USER_CREATION_ID = TargetUserCreationId;   // ← changed
            User.ACTION_BRANCH = ddlLoad_Branch.SelectedValue;
            User.flag = flag;
            // ✅ No empty defaults needed anymore

            DataSet ds = User.Imp_Col_Edit_Insert_update(
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



    private void Load_General_Settings()
    {
        try
        {
            User.COMPANY_ID       = COMPANY_ID;
            User.USER_ID          = currentuser;
            //User.USER_CREATION_ID = USER_CREATION_ID;
            User.USER_CREATION_ID = TargetUserCreationId;   // ← changed
            User.ACTION_BRANCH    = ddlLoad_Branch.SelectedValue;
            User.flag             = "Select_Imp_Col_Setngs";

            DataSet Exp_ds = User.Imp_Col_Edit_Insert_update(
                                 HttpContext.Current.Session["currentcomp_db"].ToString());

            if (Exp_ds != null && Exp_ds.Tables.Count > 0
                               && Exp_ds.Tables[0].Rows.Count > 0)
            {
                rdl_General_ImporterName.SelectedValue    = Exp_ds.Tables[0].Rows[0]["GENERAL_IMPORTER_NAME"].ToString();
                rdl_General_IECNo.SelectedValue           = Exp_ds.Tables[0].Rows[0]["GENERAL_IEC_NO"].ToString();
                rdl_General_ADCode.SelectedValue          = Exp_ds.Tables[0].Rows[0]["GENERAL_AD_CODE"].ToString();
                rdl_General_Address.SelectedValue         = Exp_ds.Tables[0].Rows[0]["GENERAL_ADDRESS"].ToString();
                rdl_General_CountryOrigin.SelectedValue   = Exp_ds.Tables[0].Rows[0]["GENERAL_COUNTRY_ORIGIN"].ToString();
                rdl_General_CountryShipment.SelectedValue = Exp_ds.Tables[0].Rows[0]["GENERAL_COUNTRY_SHIPMENT"].ToString();
                rdl_General_PortOfOrigin.SelectedValue    = Exp_ds.Tables[0].Rows[0]["GENERAL_PORT_ORIGIN"].ToString();
                rdl_General_PortofShipment.SelectedValue  = Exp_ds.Tables[0].Rows[0]["GENERAL_PORT_SHIPMENT"].ToString();
                rdl_General_StateCode.SelectedValue       = Exp_ds.Tables[0].Rows[0]["GENERAL_STATE_CODE"].ToString();
                rdl_General_RegistrationNo.SelectedValue  = Exp_ds.Tables[0].Rows[0]["GENERAL_REGISTRATION_NO"].ToString();
                rdl_Branch_SL_No.SelectedValue = Exp_ds.Tables[0].Rows[0]["GENERAL_BRANCH_SL_NO"].ToString();
                rdl_General_StateName.SelectedValue = Exp_ds.Tables[0].Rows[0]["GENERAL_STATE_NAME"].ToString();
                btnSave.Visible   = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
            }
            else
            {
                Reset_General();
                btnSave.Visible   = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
            }
        }
        catch (Exception ex) { er.makeLog(ex.Message); }
    }

    private void Load_IGM_Settings()
    {
        try
        {
            User.COMPANY_ID = COMPANY_ID;
            User.USER_ID = currentuser;
            //User.USER_CREATION_ID = USER_CREATION_ID;
            User.USER_CREATION_ID = TargetUserCreationId;   // ← changed
            User.ACTION_BRANCH = ddlLoad_Branch.SelectedValue;
            User.flag = "Select_Imp_IGm_Setngs";

            DataSet Exp_ds = User.Imp_Col_Edit_Insert_update(
                                 HttpContext.Current.Session["currentcomp_db"].ToString());

            if (Exp_ds != null && Exp_ds.Tables.Count > 0
                               && Exp_ds.Tables[0].Rows.Count > 0)
            {
                rdl_IGM_No.SelectedValue = Exp_ds.Tables[0].Rows[0]["IGM_NO"].ToString();
                rdl_IGM_Date.SelectedValue = Exp_ds.Tables[0].Rows[0]["IGM_DATE"].ToString();
                rdl_MAWB_BL_No.SelectedValue = Exp_ds.Tables[0].Rows[0]["MAWB_BL_NO"].ToString();
                rdl_MAWB_MBL_Date.SelectedValue = Exp_ds.Tables[0].Rows[0]["MAWB_MBL_DATE"].ToString();
                rdl_Packages.SelectedValue = Exp_ds.Tables[0].Rows[0]["PACKAGES"].ToString();
                rdl_Marks_Nos.SelectedValue = Exp_ds.Tables[0].Rows[0]["MARKS_NOS"].ToString();
                rdl_gross_weight.SelectedValue = Exp_ds.Tables[0].Rows[0]["IGM_GROSS_WEIGHT"].ToString();
                rdl_IGM_PackageType.SelectedValue = Exp_ds.Tables[0].Rows[0]["IGM_PACKAGE_TYPE"].ToString();
                rdl_IGM_GrossWeightType.SelectedValue = Exp_ds.Tables[0].Rows[0]["IGM_GROSS_WEIGHT_TYPE"].ToString();
                rdl_IGM_FlightVesselDate.SelectedValue = Exp_ds.Tables[0].Rows[0]["FLIGHT_VESSEL_DATE"].ToString();
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
            }
            else
            {
                Reset_IGM();
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
            }
        }
        catch (Exception ex) { er.makeLog(ex.Message); }
    }



    //private void Load_INVOICE_Settings()
    //{
    //    try
    //    {
    //        User.COMPANY_ID = COMPANY_ID;
    //        User.USER_ID = currentuser;
    //        User.USER_CREATION_ID = USER_CREATION_ID;
    //        User.ACTION_BRANCH = ddlLoad_Branch.SelectedValue;
    //        User.flag = "Select_Imp_Inv_Setngs";

    //        DataSet Exp_ds = User.Imp_Col_Edit_Insert_update(
    //                             HttpContext.Current.Session["currentcomp_db"].ToString());

    //        if (Exp_ds != null && Exp_ds.Tables.Count > 0
    //                           && Exp_ds.Tables[0].Rows.Count > 0)
    //        {


    //            rdl_Invoice_No.SelectedValue = Exp_ds.Tables[0].Rows[0]["INV_NO"].ToString();
    //            rdl_Date.SelectedValue = Exp_ds.Tables[0].Rows[0]["INV_DATE"].ToString();
    //            rdl_Currency.SelectedValue = Exp_ds.Tables[0].Rows[0]["INV_CURRENCY"].ToString();
    //            rdl_Invoice_Value.SelectedValue = Exp_ds.Tables[0].Rows[0]["INV_VALUE"].ToString();
    //            rdl_Supplier_Name.SelectedValue = Exp_ds.Tables[0].Rows[0]["INV_SUPPLIER_NAME"].ToString();


    //            btnSave.Visible = false;
    //            btnUpdate.Visible = true;
    //            btnDelete.Visible = true;
    //        }
    //        else
    //        {
    //            Reset_Invoice();
    //            btnSave.Visible = true;
    //            btnUpdate.Visible = false;
    //            btnDelete.Visible = false;
    //        }
    //    }
    //    catch (Exception ex) { er.makeLog(ex.Message); }
    //}


    private void Reset_General()
    {
        rdl_General_ImporterName.SelectedValue    = "Y";
        rdl_General_IECNo.SelectedValue = "Y";
        rdl_General_ADCode.SelectedValue = "Y";
        rdl_General_Address.SelectedValue = "Y";
        rdl_General_CountryOrigin.SelectedValue = "Y";
        rdl_General_CountryShipment.SelectedValue = "Y";
        rdl_General_PortOfOrigin.SelectedValue = "Y";
        rdl_General_PortofShipment.SelectedValue = "Y";
        rdl_General_StateCode.SelectedValue = "Y";
        rdl_General_RegistrationNo.SelectedValue = "Y";
        rdl_Branch_SL_No.SelectedValue = "Y";
        rdl_General_StateName.SelectedValue = "Y";

    }

    private void Reset_IGM()
    {
        rdl_IGM_No.SelectedValue       = "Y";
        rdl_IGM_Date.SelectedValue     = "Y";
        rdl_MAWB_BL_No.SelectedValue   = "Y";
        rdl_MAWB_MBL_Date.SelectedValue= "Y";
        rdl_Packages.SelectedValue     = "Y";
        rdl_Marks_Nos.SelectedValue    = "Y";
        rdl_gross_weight.SelectedValue = "Y";
        rdl_IGM_PackageType.SelectedValue = "Y";
        rdl_IGM_GrossWeightType.SelectedValue = "Y";
        rdl_IGM_FlightVesselDate.SelectedValue = "Y";

    }

    //private void Reset_Invoice()
    //{
    //    rdl_Invoice_No.SelectedValue = "Y";
    //    rdl_Date.SelectedValue = "Y";
    //    rdl_Currency.SelectedValue = "Y";
    //    rdl_Invoice_Value.SelectedValue = "Y";
    //    rdl_Supplier_Name.SelectedValue = "Y";
    //}

   

    private int Insert_Update_General(string flag)
    {
        try
        {
            User.USER_CREATION_ID         = USER_CREATION_ID;
            User.USER_CREATION_ID = TargetUserCreationId;   // ← changed
            User.COMPANY_ID               = COMPANY_ID;
            User.USER_ID                  = currentuser;
            User.ACTION_BRANCH            = ddlLoad_Branch.SelectedValue;
            User.GENERAL_IMPORTER_NAME    = rdl_General_ImporterName.SelectedValue;
            User.GENERAL_IEC_NO           = rdl_General_IECNo.SelectedValue;
            User.GENERAL_AD_CODE          = rdl_General_ADCode.SelectedValue;
            User.GENERAL_BRANCH_SL_NO     = rdl_Branch_SL_No.SelectedValue;
            User.GENERAL_ADDRESS          = rdl_General_Address.SelectedValue;
            User.GENERAL_COUNTRY_ORIGIN   = rdl_General_CountryOrigin.SelectedValue;
            User.GENERAL_COUNTRY_SHIPMENT = rdl_General_CountryShipment.SelectedValue;
            User.GENERAL_PORT_ORIGIN      = rdl_General_PortOfOrigin.SelectedValue;
            User.GENERAL_PORT_SHIPMENT    = rdl_General_PortofShipment.SelectedValue;
            User.GENERAL_STATE_CODE       = rdl_General_StateCode.SelectedValue;
            User.GENERAL_STATE_NAME       = rdl_General_StateName.SelectedValue;
            User.GENERAL_REGISTRATION_NO  = rdl_General_RegistrationNo.SelectedValue;
            User.flag                     = flag;

            User.Imp_Col_Edit_Insert_update(
                HttpContext.Current.Session["currentcomp_db"].ToString());

            i = User.result;
        }
        catch (Exception ex) { er.makeLog(ex.Message); }
        return i;
    }

    private int Insert_Update_IGM(string flag)
    {
        try
        {
            // Convert generic S/U to IGM specific flags
            string igmFlag = "";
            if (flag == "S") igmFlag = "S_IGM";
            else if (flag == "U") igmFlag = "U_IGM";
            else igmFlag = flag;

            //User.USER_CREATION_ID = USER_CREATION_ID;
            User.USER_CREATION_ID = TargetUserCreationId;   // ← changed
            User.COMPANY_ID = COMPANY_ID;
            User.USER_ID = currentuser;
            User.ACTION_BRANCH = ddlLoad_Branch.SelectedValue;
            User.IGM_NO = rdl_IGM_No.SelectedValue;
            User.IGM_DATE = rdl_IGM_Date.SelectedValue;
            User.MAWB_BL_NO = rdl_MAWB_BL_No.SelectedValue;
            User.MAWB_MBL_DATE = rdl_MAWB_MBL_Date.SelectedValue;
            User.PACKAGES = rdl_Packages.SelectedValue;
            User.IGM_PACKAGE_TYPE = rdl_IGM_PackageType.SelectedValue;
            User.IGM_GROSS_WEIGHT = rdl_gross_weight.SelectedValue;
            User.MARKS_NOS = rdl_Marks_Nos.SelectedValue;
            User.IGM_GROSS_WEIGHT_TYPE = rdl_IGM_GrossWeightType.SelectedValue;
            User.FLIGHT_VESSEL_DATE = rdl_IGM_FlightVesselDate.SelectedValue;
            User.flag = igmFlag;  // ✅ S_IGM or U_IGM

            User.Imp_Col_Edit_Insert_update(
                HttpContext.Current.Session["currentcomp_db"].ToString());

            i = User.result;
        }
        catch (Exception ex) { er.makeLog(ex.Message); }
        return i;
    }

    //private int Insert_Update_INV(string flag)
    //{
    //    try
    //    {
    //        // ✅ Convert generic S/U to INV specific flags
    //        string invFlag = "";
    //        if (flag == "S") invFlag = "S_INV";
    //        else if (flag == "U") invFlag = "U_INV";
    //        else invFlag = flag;

    //        User.USER_CREATION_ID = USER_CREATION_ID;
    //        User.COMPANY_ID = COMPANY_ID;
    //        User.USER_ID = currentuser;
    //        User.ACTION_BRANCH = ddlLoad_Branch.SelectedValue;
    //        User.INV_NO = rdl_Invoice_No.SelectedValue;
    //        User.INV_DATE = rdl_Date.SelectedValue;
    //        User.INV_CURRENCY = rdl_Currency.SelectedValue;
    //        User.INV_VALUE = rdl_Invoice_Value.SelectedValue;
    //        User.INV_SUPPLIER_NAME = rdl_Supplier_Name.SelectedValue;
    //        User.flag = invFlag; // ✅ S_INV or U_INV

    //        User.Imp_Col_Edit_Insert_update(
    //            HttpContext.Current.Session["currentcomp_db"].ToString());

    //        i = User.result;
    //    }
    //    catch (Exception ex) { er.makeLog(ex.Message); }
    //    return i;
    //}

    //protected void btnNew_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        switch (ActivePage)
    //        {
    //            case 1:
    //                Delete_Existing_Record("D");
    //                Reset_General();
    //                btnSave.Visible   = true;
    //                btnUpdate.Visible = false;
    //                btnDelete.Visible = false;
    //                break;
    //            case 2:
    //                Delete_Existing_Record("D_IGM");
    //                Reset_IGM();
    //                btnSave.Visible = true;
    //                btnUpdate.Visible = false;
    //                btnDelete.Visible = false;
    //                break;
    //            //case 3:
    //            //    Delete_Existing_Record("D_INV");
    //            //    Reset_Invoice();
    //            //    btnSave.Visible = true;
    //            //    btnUpdate.Visible = false;
    //            //    btnDelete.Visible = false;
    //            //    break;
    //        }
    //    }
    //    catch (Exception ex) { er.makeLog(ex.Message); }
    //}



    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            switch (ActivePage)
            {
                case 1:
                    Reset_General();          // reset the form only — no DB call
                    break;
                case 2:
                    Reset_IGM();               // reset the form only — no DB call
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







    //protected void btnSave_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        switch (ActivePage)
    //        {
    //            case 1:
    //                i = Insert_Update_General("S");
    //                if      (i == 1) { btnSave.Visible = false; btnUpdate.Visible = true; btnDelete.Visible = true; Alert_msg("General settings saved successfully."); }
    //                else if (i == 2) Alert_msg("Record already exists. Click Update to modify.");
    //                else             Alert_msg("Save failed. Please try again.");
    //                break;

    //            case 2:
    //                i = Insert_Update_IGM("S");
    //                if (i == 1) { btnSave.Visible = false; btnUpdate.Visible = true; btnDelete.Visible = true; Alert_msg("IGM settings saved successfully."); }
    //                else if (i == 2) Alert_msg("Record already exists. Click Update to modify.");
    //                else Alert_msg("Save failed. Please try again.");
    //                break;

    //            //case 3:
    //            //    i = Insert_Update_INV("S");
    //            //    if (i == 1) { btnSave.Visible = false; btnUpdate.Visible = true; btnDelete.Visible = true; Alert_msg("Invoice settings saved successfully."); }
    //            //    else if (i == 2) Alert_msg("Record already exists. Click Update to modify.");
    //            //    else Alert_msg("Save failed. Please try again.");
    //            //    break;
    //        }
    //    }
    //    catch (Exception ex) { er.makeLog(ex.Message); }
    //}



    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            // Only now — at the actual moment of Save — clear out any existing
            // row for this user/branch, immediately followed by inserting the
            // fresh values. Delete and replace happen together, so there's
            // never a moment where data is gone with nothing to replace it.
            bool pendingNew = ViewState["PendingNew"] != null && (bool)ViewState["PendingNew"];
            if (pendingNew)
            {
                switch (ActivePage)
                {
                    case 1: Delete_Existing_Record("D"); break;
                    case 2: Delete_Existing_Record("D_IGM"); break;
                }
                ViewState["PendingNew"] = false;
            }

            switch (ActivePage)
            {
                case 1:
                    i = Insert_Update_General("S");
                    if (i == 1) { btnSave.Visible = false; btnUpdate.Visible = true; btnDelete.Visible = true; Alert_msg("General settings saved successfully."); }
                    else if (i == 2) Alert_msg("Record already exists. Click Update to modify.");
                    else Alert_msg("Save failed. Please try again.");
                    break;

                case 2:
                    i = Insert_Update_IGM("S");
                    if (i == 1) { btnSave.Visible = false; btnUpdate.Visible = true; btnDelete.Visible = true; Alert_msg("IGM settings saved successfully."); }
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
                    i = Insert_Update_General("U");
                    Alert_msg(i == 1 ? "General settings updated successfully."
                                     : "Update failed. Please try again.");
                    break;
                case 2:
                    i = Insert_Update_IGM("U");
                    Alert_msg(i == 1 ? "IGM settings updated successfully."
                                     : "Update failed. Please try again.");
                    break;
                //case 3:
                //    i = Insert_Update_INV("U");
                //    Alert_msg(i == 1 ? "Invoice settings updated successfully."
                //                     : "Update failed. Please try again.");
                //    break;
             
            }
        }
        catch (Exception ex) { er.makeLog(ex.Message); }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            // Set common fields
            User.COMPANY_ID       = COMPANY_ID;
            User.USER_CREATION_ID = TargetUserCreationId;   // ← changed
            //User.USER_CREATION_ID = USER_CREATION_ID;
            User.USER_ID          = currentuser;
            User.ACTION_BRANCH    = ddlLoad_Branch.SelectedValue;

            switch (ActivePage)
            {
                case 1:
                    User.flag = "D";
                    User.Imp_Col_Edit_Insert_update(
                        HttpContext.Current.Session["currentcomp_db"].ToString());
                    i = User.result;
                    if (i == 1) { Reset_General(); Load_General_Settings(); Alert_msg("General settings deleted successfully."); }
                    else Alert_msg("Delete failed. Please try again.");
                    break;

                case 2:
                    User.flag = "D_IGM";
                    User.Imp_Col_Edit_Insert_update(
                        HttpContext.Current.Session["currentcomp_db"].ToString());
                    i = User.result;
                    if (i == 1) { Reset_IGM(); Load_IGM_Settings(); Alert_msg("IGM settings deleted successfully."); }
                    else Alert_msg("Delete failed. Please try again.");
                    break;

                //case 3:
                //    User.flag = "D_INV";
                //    User.Imp_Col_Edit_Insert_update(
                //        HttpContext.Current.Session["currentcomp_db"].ToString());
                //    i = User.result;
                //    if (i == 1) { Reset_Invoice(); Load_INVOICE_Settings(); Alert_msg("Invoice settings deleted successfully."); }
                //    else Alert_msg("Delete failed. Please try again.");
                //    break;
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

            // Move "Select Branch" (ddlGroupname) to this user's group
            if (ddlGroupname.Items.FindByValue(groupId) != null)
            {
                ddlGroupname.SelectedValue = groupId;
            }

            // Rebuild "Select Location" (ddlLoad_Branch) for that group
            Bind_Branch(groupId, grpDs.Tables[1]);

            // Move "Select Location" to this user's specific branch, if it's in the list
            if (!string.IsNullOrEmpty(branchCode) && ddlLoad_Branch.Items.FindByValue(branchCode) != null)
            {
                ddlLoad_Branch.SelectedValue = branchCode;
            }
        }
        catch (Exception ex) { er.makeLog(ex.Message); }
    }




    private void Delete_Existing_Record(string flag)
    {
        try
        {
            User.COMPANY_ID = COMPANY_ID;
            User.USER_CREATION_ID = USER_CREATION_ID;
            User.USER_ID = currentuser;
            User.ACTION_BRANCH = ddlLoad_Branch.SelectedValue;
            User.flag = flag;
            // ✅ No empty defaults needed anymore

            User.Imp_Col_Edit_Insert_update(
                HttpContext.Current.Session["currentcomp_db"].ToString());
        }
        catch (Exception ex) { er.makeLog(ex.Message); }
    }


}



























