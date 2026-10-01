using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BussinessObject;

public partial class Imp_SupDocs_Bulk : ThemeClass
{
    AppSession aps = new AppSession();
    public string SELECT_BRANCH, Jobno, COMPANY_ID = "", currentbranch;
    Imp_Invcopy IIC = new Imp_Invcopy();
    adminmaster Am = new adminmaster();
    SW_INFO_TYPE SW = new SW_INFO_TYPE();
    UserBO ObjUBO = new UserBO();

    private string BE_TYPE { get { return ViewState["BE_TYPE"] != null ? ViewState["BE_TYPE"].ToString() : ""; } }
    private string IMP_EXP_TYPE { get { return ViewState["IMP_EXP_TYPE"] != null ? ViewState["IMP_EXP_TYPE"].ToString() : ""; } }
    private string TRANSPORT_MODE { get { return ViewState["TRANSPORT_MODE"] != null ? ViewState["TRANSPORT_MODE"].ToString() : ""; } }

    // Current top-filter mode: "RITC" (default) or "DEPT"
    private string CurrentMode { get { return ddl_Mode != null ? ddl_Mode.SelectedValue : "RITC"; } }
    private static readonly string[] SEZ_BE_TYPES = { "SEZ FTA-Z", "SEZ DTA-T", "SEZ DTA-M", "Jobbing", "Repair & Return", "Exhibition", "Destruction", "Movement of Goods", "Stock Item" };

    private static readonly Dictionary<string, List<DeptRow>> DeptDefaultRows = new Dictionary<string, List<DeptRow>>(StringComparer.OrdinalIgnoreCase)
    {
        { "AQCS",  new List<DeptRow> {
            new DeptRow("PNM","PNM - Product Name","COM","COM - Common Name",    false,true, false,false)
        }},
        { "PQIS",  new List<DeptRow> {
            new DeptRow("CHR","CHR - Item Characteristics","PLV","PLV - Plant Variety",       false,true, false,false),
            new DeptRow("CTG","CTG - Item Category",       "PLC","PLC - plant Category",      true, false,true, true ),
            new DeptRow("CTG","CTG - Item Category",       "PLP","PLP - Plant Parts",         true, false,false,false),
            new DeptRow("PNM","PNM - Product Name",        "PCN","PCN - Plant Commodity Name",true,false, false,false),
            new DeptRow("PNM","PNM - Product Name",        "SCI","SCI - Scientific Name",     false,true, false,false)
        }},
        { "WCCB",  new List<DeptRow> {
            new DeptRow("PNM","PNM - Product Name","COM","COM - Common Name",    false,true,false,false),
            new DeptRow("PNM","PNM - Product Name","SCI","SCI - Scientific Name",false,true,false,false)
        }},
        { "FSSAI", new List<DeptRow> {
            new DeptRow("CHR","CHR - Item Characteristics","STC","STC - Storage Condition",                    true,false,false,false),
            new DeptRow("CTG","CTG - Item Category",       "FSP","FSP - Foods & Supplement Proprietry Status", true,false,false,false),
            new DeptRow("IDT","IDT - Item Identification", "RFA","RFA - Retail Pre-pack Food Article",         true,false,false,false)
        }},
        { "DCPC",  new List<DeptRow> {
            new DeptRow("CTG","CTG - Item Category","CPC","CPC - Chemical Products",    true,false,false,false)
        }},
        { "CDRUG", new List<DeptRow> {
            new DeptRow("CTG","CTG - Item Category","DRC","DRC - Drug Related Category",true,false,false,false)
        }},
        { "HZRDS", new List<DeptRow> {
            new DeptRow("CHR","CHR - Item Characteristics","HZRDS","HZRDS - Hazardous",true,false,false,false)
                { IsYesNo = true }
        }},
        { "SIMS",  new List<DeptRow> {
            new DeptRow("PNM","PNM - SIMS","SIU","SIU - SIMS",true,true,false,false),
            new DeptRow("CHR","CHR - Item Characteristics","SGD","SGD - SafeGuard Duty",true,true,false,false)
        }},
        { "8517",  new List<DeptRow> {
            new DeptRow("PNM","PNM - Product Name","PID","PID - Product Identification",true,false,false,false)
        }},  
        { "HAND", new List<DeptRow> {
            new DeptRow("HAC","HAC - Hand Carriage","","",false,true,false,false)
        }},
        { "CCDC", new List<DeptRow> {
            new DeptRow("CHR","CHR - Item Characteristics","","",false,true,false,false)
        }}
    };

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
            SELECT_BRANCH = Connection.Get_Company_Type();
            COMPANY_ID = Connection.COMPANYID();
            currentbranch = Session["currentbranch"].ToString();

            Jobno = (Request.QueryString["JOBID"] != null && Request.QueryString["JOBID"] != "")
                    ? Request.QueryString["JOBID"].ToString()
                    : Connection.IMP_Jobno();

            lbljobno.Text = Jobno;
            hfJobNo.Value = Jobno;
            hfBranchType.Value = SELECT_BRANCH;

            if (!Page.IsPostBack)
            {
                // default = RITC mode
                td_RITC.Visible = true;
                td_Dept.Visible = false;
                td_RitcMulti.Visible = false;
                Bind_RITC_Dropdown();
                Bind_PartNo_Dropdown();
            }
        }
        catch (Exception ex) { Connection.Error_Msg(ex.Message); }
    }
    /*
        private void Bind_RITC_Dropdown()
        {
            try
            {
                ObjUBO.JOBNO = Jobno;
                ObjUBO.Ename = "Imp_Jobno_select";
                IIC.Branch_Type = SELECT_BRANCH;
                DataSet dss = SW.Select_Imp_Ritc_No_Inv_Item(ObjUBO);

                ddl_RITC.Items.Clear();
                ddl_RITC.Items.Add(new ListItem("-- Select RITC --", ""));

                if (dss == null || dss.Tables.Count == 0 || dss.Tables[0].Rows.Count == 0)
                    return;

                ViewState["DS_InvItem"] = dss.Tables[0];
                if (dss.Tables.Count > 1 && dss.Tables[1].Rows.Count > 0)
                {
                    ViewState["BE_TYPE"] = dss.Tables[1].Rows[0]["BE_TYPE"].ToString();
                    ViewState["IMP_EXP_TYPE"] = dss.Tables[1].Rows[0]["IMP_EXP_TYPE"].ToString();
                    ViewState["TRANSPORT_MODE"] = dss.Tables[1].Rows[0]["TRANSPORT_MODE"].ToString();
                }
                else
                {
                    ViewState["BE_TYPE"] = "";
                    ViewState["IMP_EXP_TYPE"] = "";
                    ViewState["TRANSPORT_MODE"] = "";
                }

                DataTable dtDistinct = new DataView(dss.Tables[0]).ToTable(true, "CTH_NO");
                foreach (DataRow dr in dtDistinct.Rows)
                {
                    string ritc = dr["CTH_NO"].ToString().Trim();
                    if (!string.IsNullOrEmpty(ritc))
                        ddl_RITC.Items.Add(new ListItem(ritc, ritc));
                }

                if (ddl_RITC.Items.Count == 2)
                {
                    ddl_RITC.SelectedIndex = 1;
                    Bind_InvItem_ByRITC(ddl_RITC.SelectedValue);
                    Load_AllDepts_ForRITC(ddl_RITC.SelectedValue);
                }
            }
            catch (Exception ex) { Alert_msg("Error loading RITC: " + ex.Message); }
        }
        */
    private void Bind_RITC_Dropdown()
    {
        try
        {
            ObjUBO.JOBNO = Jobno;
            ObjUBO.Ename = "Imp_Jobno_select";
            IIC.Branch_Type = SELECT_BRANCH;
            DataSet dss = SW.Select_Imp_Ritc_No_Inv_Item(ObjUBO);

            ddl_RITC.Items.Clear();
            ddl_RITC.Items.Add(new ListItem("-- Select RITC --", ""));

            if (dss == null || dss.Tables.Count == 0 || dss.Tables[0].Rows.Count == 0)
                return;

            ViewState["DS_InvItem"] = dss.Tables[0];

            if (dss.Tables.Count > 1 && dss.Tables[1].Rows.Count > 0)
            {
                ViewState["BE_TYPE"] = dss.Tables[1].Rows[0]["BE_TYPE"].ToString();
                ViewState["IMP_EXP_TYPE"] = dss.Tables[1].Rows[0]["IMP_EXP_TYPE"].ToString();
                ViewState["TRANSPORT_MODE"] = dss.Tables[1].Rows[0]["TRANSPORT_MODE"].ToString();
            }
            else
            {
                ViewState["BE_TYPE"] = "";
                ViewState["IMP_EXP_TYPE"] = "";
                ViewState["TRANSPORT_MODE"] = "";
            }

            // ── Filter: only add RITCs that have dept configured in admin ──
            DataTable dtDistinct = new DataView(dss.Tables[0]).ToTable(true, "CTH_NO");
            foreach (DataRow dr in dtDistinct.Rows)
            {
                string ritc = dr["CTH_NO"].ToString().Trim();
                if (string.IsNullOrEmpty(ritc)) continue;

                if (Has_Dept_ForRITC(ritc))
                    ddl_RITC.Items.Add(new ListItem(ritc, ritc));
            }

            // Auto-select if only one valid RITC with dept
            if (ddl_RITC.Items.Count == 2)
            {
                ddl_RITC.SelectedIndex = 1;
                Bind_InvItem_ByRITC(ddl_RITC.SelectedValue);
                Load_AllDepts_ForRITC(ddl_RITC.SelectedValue);
            }
        }
        catch (Exception ex) { Alert_msg("Error loading RITC: " + ex.Message); }
    }
    private void Bind_PartNo_Dropdown() // Added by shanthini on 04-09-2026
    {
        try
        {
            ddl_PartNo.Items.Clear();
            ddl_PartNo.Items.Add(new ListItem("-- All Part No --", ""));

            DataSet dss = new DataSet();
            IIC.Jobno = Jobno;
            IIC.Inv_slno = "";
            IIC.Flag = "FTA_Job_PartNo";
            IIC.Branch_Type = SELECT_BRANCH;
            dss = IIC.Imp_Inv_Copy_Select();

            if (dss.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dss.Tables[0].Rows)
                {
                    string pn = dr["PART_NO"].ToString().Trim();
                    if (!string.IsNullOrEmpty(pn))
                        ddl_PartNo.Items.Add(new ListItem(pn, pn));
                }
            }
        }
        catch (Exception ex) { Alert_msg("Error loading Part No: " + ex.Message); }
    }

    protected void ddl_PartNo_SelectedIndexChanged(object sender, EventArgs e)// Added by shanthini on 04-09-2026
    {
        string selectedPart = ddl_PartNo.SelectedValue;

        if (string.IsNullOrEmpty(selectedPart))
        {
            if (CurrentMode == "DEPT")
            {
                List<string> selRitc = new List<string>();
                foreach (ListItem li in chk_RITC.Items)
                    if (li.Selected) selRitc.Add(li.Value);
                Bind_InvItem_ByRITCs(selRitc);
            }
            else if (!string.IsNullOrEmpty(ddl_RITC.SelectedValue))
            {
                Bind_InvItem_ByRITC(ddl_RITC.SelectedValue);
            }
            return;
        }

        // Fetch inv/item pairs that belong to this Part No
        HashSet<string> validKeys = new HashSet<string>();
        try
        {
            DataSet dss = new DataSet();
            IIC.Jobno = Jobno;
            IIC.Inv_slno = "";
            IIC.Tbl_Name = selectedPart;
            IIC.Flag = "SW_PartNo_InvItem";
            IIC.Branch_Type = SELECT_BRANCH;
            dss = IIC.Imp_Inv_Copy_Select();

            if (dss.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dss.Tables[0].Rows)
                {
                    string key = dr["INVOICE_SLNO"].ToString() + "|" + dr["ITEM_SLNO"].ToString();
                    validKeys.Add(key);
                }
            }
        }
        catch (Exception ex) { Alert_msg("Error filtering by Part No: " + ex.Message); }

        for (int i = chk_InvItem.Items.Count - 1; i >= 0; i--)
        {
            if (!validKeys.Contains(chk_InvItem.Items[i].Value))
                chk_InvItem.Items.RemoveAt(i);
        }
    }

    // =========================================================================
    // Returns the list of dept codes configured (admin) for a given RITC.
    // Mirrors the dept-resolution logic used in Load_AllDepts_ForRITC, but
    // returns just the codes — used by both RITC mode and DEPT mode.
    // =========================================================================
    private List<string> Get_DeptCodes_ForRITC(string ritcNo)
    {
        List<string> deptList = new List<string>();
        try
        {
            List<string> userWiseDepts = Get_UserWise_Depts_ForRITC(ritcNo);
            foreach (string d in userWiseDepts)
                if (!deptList.Contains(d)) deptList.Add(d);
            Am = new adminmaster();
            Am.SCHEME_IMPORT_CODE = ritcNo;
            Am.name = "Chk_Aval_RITC";
            DataSet ds_chk = Am.IMP_Single_Window();
            //if (ds_chk == null || ds_chk.Tables.Count == 0 || ds_chk.Tables[0].Rows.Count == 0)
            //    return deptList;
            bool ritcKnownToAdmin = ds_chk != null && ds_chk.Tables.Count > 0 && ds_chk.Tables[0].Rows.Count > 0; 

            if (ritcKnownToAdmin)
            {
                Am = new adminmaster();
                Am.SCHEME_IMPORT_CODE = ritcNo;
                Am.name = "Select_Info_Department";
                DataSet ds_dept = Am.IMP_Single_Window();

                if (ds_dept != null && ds_dept.Tables.Count > 2 && ds_dept.Tables[2].Rows.Count > 0)
                {
                    string raw = ds_dept.Tables[2].Rows[0]["Department_Code"].ToString();
                    foreach (string d in raw.Split(','))
                    {
                        string t = d.Trim().ToUpper();
                        if (string.IsNullOrEmpty(t)) continue;
                        if (!deptList.Contains(t)) deptList.Add(t);
                    }
                }
            }

            // HAND carriage rule (same as RITC mode)
            string[] excludedBE = { "SEZ FTA-Z", "SEZ DTA-T", "SEZ DTA-M", "Jobbing", "Repair & Return", "Exhibition", "Destruction", "Movement of Goods", "Stock Item" };
            string beType = BE_TYPE;
            if (!string.IsNullOrEmpty(beType) && !excludedBE.Contains(beType)
                && IMP_EXP_TYPE == "HAND CARRIAGE" && TRANSPORT_MODE == "Air")
            {
                if (!deptList.Contains("HAND")) deptList.Add("HAND");
            }

            // Keep only depts we actually have default-row templates for
            //deptList = deptList.Where(d => DeptDefaultRows.ContainsKey(d)).ToList();
            deptList = deptList.Where(d => DeptDefaultRows.ContainsKey(d) || userWiseDepts.Contains(d)).ToList();
        }
        catch { /* return whatever resolved */ }
        return deptList;
    }

    private List<string> Get_UserWise_Depts_ForRITC(string ritcNo) // Added by shanthini 
    {
        List<string> list = new List<string>();
        try
        {
            eroyalmaster Emas = new eroyalmaster();
            Emas.SW_FROM_CTH = ritcNo;
            Emas.Ename = "select_by_cth";
            DataSet ds = Emas.RetrieveAll_SingleWindow_UserWise_master();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0
                && ds.Tables[0].Columns.Contains("AGENCY_CODE"))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string agencyCode = dr["AGENCY_CODE"].ToString().Trim().ToUpper();
                    if (!string.IsNullOrEmpty(agencyCode) && !list.Contains(agencyCode))
                        list.Add(agencyCode);
                }
            }
        }
        catch { /* fall through with whatever resolved */ }
        return list;
    }
    // =========================================================================
    // Returns true only if this RITC has at least one dept configured in admin
    // Called for every RITC in the dropdown — dept-less RITCs are excluded
    // =========================================================================
    private bool Has_Dept_ForRITC(string ritcNo)
    {
        try
        {
            if (Get_UserWise_Depts_ForRITC(ritcNo).Count > 0) // Added by shanthini on 18-09-2026
                return true;
            // Step 1: RITC exists in admin?
            Am = new adminmaster();
            Am.SCHEME_IMPORT_CODE = ritcNo;
            Am.name = "Chk_Aval_RITC";
            DataSet ds_chk = Am.IMP_Single_Window();
            if (ds_chk == null || ds_chk.Tables.Count == 0 || ds_chk.Tables[0].Rows.Count == 0)
                return false;

            // Step 2: Has at least one dept string in Tables[2]?
            Am = new adminmaster();
            Am.SCHEME_IMPORT_CODE = ritcNo;
            Am.name = "Select_Info_Department";
            DataSet ds_dept = Am.IMP_Single_Window();
            if (ds_dept == null || ds_dept.Tables.Count <= 2 || ds_dept.Tables[2].Rows.Count == 0)
                return false;

            string raw = ds_dept.Tables[2].Rows[0]["Department_Code"].ToString().Trim();
            return !string.IsNullOrEmpty(raw);
        }
        catch
        {
            return false;  // exclude on error
        }
    }


    protected void ddl_RITC_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnl_AllDepts.Visible = false;
        chk_InvItem.Items.Clear();
        lblNoDept.Visible = false;

        if (string.IsNullOrEmpty(ddl_RITC.SelectedValue)) return;
        Bind_InvItem_ByRITC(ddl_RITC.SelectedValue);
        Load_AllDepts_ForRITC(ddl_RITC.SelectedValue);
    }

    // =========================================================================
    //  MODE SWITCH : RITC  <->  DEPT
    // =========================================================================
    protected void ddl_Mode_SelectedIndexChanged(object sender, EventArgs e)
    {
        bool deptMode = (CurrentMode == "DEPT");

        // toggle top-filter cells
        td_RITC.Visible = !deptMode;
        td_Dept.Visible = deptMode;
        td_RitcMulti.Visible = deptMode;

        // reset shared UI
        pnl_AllDepts.Visible = false;
        pnl_SavedGrid.Visible = false;
        lblNoDept.Visible = false;
        chk_InvItem.Items.Clear();
        txt_InvItem.Text = "";

        if (deptMode)
        {
            ddl_RITC.SelectedIndex = 0;
            Bind_Dept_Dropdown();          // all-RITC union dept list
            chk_RITC.Items.Clear();
            txt_Ritc.Text = "";
        }
        else
        {
            // back to RITC mode — clean dept-mode controls
            ddl_Dept.Items.Clear();
            chk_RITC.Items.Clear();
            txt_Ritc.Text = "";
        }
    }

    // =========================================================================
    //  DEPT mode : build dept dropdown = union of depts across ALL valid RITCs
    // =========================================================================
    private void Bind_Dept_Dropdown()
    {
        ddl_Dept.Items.Clear();
        ddl_Dept.Items.Add(new ListItem("-- Select Dept --", ""));

        DataTable dtInv = ViewState["DS_InvItem"] as DataTable;
        if (dtInv == null) return;

        // distinct RITCs in this job
        DataTable dtDistinct = new DataView(dtInv).ToTable(true, "CTH_NO");

        // dept -> list of RITCs that cover it  (cached for dept-select step)
        var deptToRitc = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        foreach (DataRow dr in dtDistinct.Rows)
        {
            string ritc = dr["CTH_NO"].ToString().Trim();
            if (string.IsNullOrEmpty(ritc)) continue;

            foreach (string dept in Get_DeptCodes_ForRITC(ritc))
            {
                if (!deptToRitc.ContainsKey(dept))
                    deptToRitc[dept] = new List<string>();
                if (!deptToRitc[dept].Contains(ritc))
                    deptToRitc[dept].Add(ritc);
            }
        }

        // persist the map so dept-select doesn't recompute
        DataTable dtMap = new DataTable();
        dtMap.Columns.Add("Dept");
        dtMap.Columns.Add("Ritc");
        foreach (var kv in deptToRitc)
            foreach (string r in kv.Value)
                dtMap.Rows.Add(kv.Key, r);
        ViewState["DeptRitcMap"] = dtMap;

        foreach (string dept in deptToRitc.Keys.OrderBy(x => x))
            ddl_Dept.Items.Add(new ListItem(dept, dept));

        if (ddl_Dept.Items.Count == 1)
        {
            lblNoDept.Text = "No departments found across RITCs for this job.";
            lblNoDept.Visible = true;
        }
    }

    // =========================================================================
    //  DEPT mode : dept selected -> show only RITCs that cover this dept
    // =========================================================================
    protected void ddl_Dept_SelectedIndexChanged(object sender, EventArgs e)
    {
        chk_RITC.Items.Clear();
        txt_Ritc.Text = "";
        chk_InvItem.Items.Clear();
        txt_InvItem.Text = "";
        pnl_AllDepts.Visible = false;
        pnl_SavedGrid.Visible = false;
        lblNoDept.Visible = false;

        string dept = ddl_Dept.SelectedValue;
        if (string.IsNullOrEmpty(dept)) return;

        DataTable dtMap = ViewState["DeptRitcMap"] as DataTable;
        if (dtMap == null) { Bind_Dept_Dropdown(); dtMap = ViewState["DeptRitcMap"] as DataTable; }
        if (dtMap == null) return;

        DataRow[] rows = dtMap.Select("Dept = '" + dept.Replace("'", "''") + "'");
        var added = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (DataRow dr in rows)
        {
            string ritc = dr["Ritc"].ToString().Trim();
            if (string.IsNullOrEmpty(ritc) || added.Contains(ritc)) continue;
            added.Add(ritc);
            chk_RITC.Items.Add(new ListItem(ritc, ritc));
        }

        if (chk_RITC.Items.Count == 0)
        {
            lblNoDept.Text = "No RITC covers the selected department.";
            lblNoDept.Visible = true;
        }
    }

    // =========================================================================
    //  DEPT mode : RITC(s) ticked -> build combined inv/item list + dept section
    // =========================================================================
    protected void chk_RITC_SelectedIndexChanged(object sender, EventArgs e)
    {
        // refresh the readonly textbox server-side
        var sb = new StringBuilder();
        List<string> selRitc = new List<string>();
        foreach (ListItem li in chk_RITC.Items)
        {
            if (li.Selected)
            {
                selRitc.Add(li.Value);
                if (sb.Length > 0) sb.Append(", ");
                sb.Append(li.Text);
            }
        }
        txt_Ritc.Text = sb.ToString();

        chk_InvItem.Items.Clear();
        txt_InvItem.Text = "";
        pnl_AllDepts.Visible = false;
        pnl_SavedGrid.Visible = false;
        lblNoDept.Visible = false;

        if (selRitc.Count == 0) return;

        // Combined inv/item list across all selected RITCs (one single list)
        Bind_InvItem_ByRITCs(selRitc);

        // Build dept section for the single selected dept only
        Load_SingleDept_Section(ddl_Dept.SelectedValue);
    }

    // =========================================================================
    //  DEPT mode : combined inv/item list across multiple RITCs (dedup)
    // =========================================================================
    private void Bind_InvItem_ByRITCs(List<string> ritcList)
    {
        chk_InvItem.Items.Clear();
        DataTable dtAll = ViewState["DS_InvItem"] as DataTable;
        if (dtAll == null) return;

        var seen = new HashSet<string>();
        foreach (string ritc in ritcList)
        {
            DataRow[] rows = dtAll.Select("CTH_NO = '" + ritc.Replace("'", "''") + "'");
            foreach (DataRow dr in rows)
            {
                string inv = dr["INVOICE_SLNO"].ToString();
                string item = dr["ITEM_SLNO"].ToString();
                string key = inv + "|" + item;
                if (seen.Contains(key)) continue;   // ஒரே inv/item duplicate ஆகாம
                seen.Add(key);
                chk_InvItem.Items.Add(new ListItem("Inv " + inv + " - Item " + item, key));
            }
        }
    }

    // =========================================================================
    //  DEPT mode : build the info-entry section for the single selected dept
    //  (same rendering as RITC mode, but only one dept's default rows)
    // =========================================================================
   /* private void Load_SingleDept_Section(string dept)
    {
        if (string.IsNullOrEmpty(dept) || !DeptDefaultRows.ContainsKey(dept))
        {
            pnl_AllDepts.Visible = false;
            return;
        }

        List<string> deptList = new List<string> { dept.ToUpper() };

        DataTable dtAll = Build_AllDepts_DataTable(deptList);
        ViewState["AllDeptsTable"] = dtAll;

        DataTable dtDepts = new DataTable();
        dtDepts.Columns.Add("DeptCode");
        foreach (string dep in deptList)
        {
            DataRow[] check = dtAll.Select("DeptCode = '" + dep + "'");
            if (check.Length > 0) dtDepts.Rows.Add(dep);
        }

        rpt_Depts.DataSource = dtDepts;
        rpt_Depts.ItemDataBound += Rpt_Depts_ItemDataBound;
        rpt_Depts.DataBind();
        pnl_AllDepts.Visible = true;
        Load_Saved_Grid();
    } */
    private void Load_SingleDept_Section(string dept)
    {
        if (string.IsNullOrEmpty(dept))
        {
            pnl_AllDepts.Visible = false;
            return;
        }

        List<string> deptList = new List<string> { dept.ToUpper() };

        DataTable dtAll = Build_AllDepts_DataTable(deptList);
        if (dtAll.Rows.Count == 0) // Added by shanthini
        {
            pnl_AllDepts.Visible = false;
            lblNoDept.Text = "No info entries configured for this department.";
            lblNoDept.Visible = true;
            return;
        }
        ViewState["AllDeptsTable"] = dtAll;

        DataTable dtDepts = new DataTable();
        dtDepts.Columns.Add("DeptCode");
        foreach (string dep in deptList)
        {
            DataRow[] check = dtAll.Select("DeptCode = '" + dep + "'");
            if (check.Length > 0) dtDepts.Rows.Add(dep);
        }

        rpt_Depts.DataSource = dtDepts;
        rpt_Depts.ItemDataBound += Rpt_Depts_ItemDataBound;
        rpt_Depts.DataBind();
        pnl_AllDepts.Visible = true;
        Load_Saved_Grid();
    }

    private void Load_AllDepts_ForRITC(string ritcNo)
    {
        try
        {
            List<string> userWiseDepts = Get_UserWise_Depts_ForRITC(ritcNo);
            Am = new adminmaster();
            Am.SCHEME_IMPORT_CODE = ritcNo;
            Am.name = "Chk_Aval_RITC";
            DataSet ds_chk = Am.IMP_Single_Window();

            //if (ds_chk == null || ds_chk.Tables.Count == 0 || ds_chk.Tables[0].Rows.Count == 0)
            bool ritcKnownToAdmin = ds_chk != null && ds_chk.Tables.Count > 0 && ds_chk.Tables[0].Rows.Count > 0;

            if (!ritcKnownToAdmin && userWiseDepts.Count == 0)
            {
                lblNoDept.Text = "No departments found for this RITC.";
                lblNoDept.Visible = true;
                pnl_AllDepts.Visible = false;
                return;
            }
            List<string> deptList = new List<string>();
            foreach (string d in userWiseDepts)
                if (!deptList.Contains(d)) deptList.Add(d);
            if (ritcKnownToAdmin)
            {
                Am = new adminmaster();
                Am.SCHEME_IMPORT_CODE = ritcNo;
                Am.name = "Select_Info_Department";
                DataSet ds_dept = Am.IMP_Single_Window();
                //List<string> deptList = new List<string>();
                if (ds_dept != null && ds_dept.Tables.Count > 2 && ds_dept.Tables[2].Rows.Count > 0)
                {
                    string raw = ds_dept.Tables[2].Rows[0]["Department_Code"].ToString();
                    foreach (string d in raw.Split(','))
                    {
                        string t = d.Trim().ToUpper();
                        if (string.IsNullOrEmpty(t)) continue;
                        if (!deptList.Contains(t)) deptList.Add(t);
                    }
                }

                if (!deptList.Contains("DCPC", StringComparer.OrdinalIgnoreCase))
                    deptList.Add("PEC");
            }
            string[] excludedBE = { "SEZ FTA-Z", "SEZ DTA-T", "SEZ DTA-M", "Jobbing", "Repair & Return", "Exhibition", "Destruction", "Movement of Goods", "Stock Item" };

            string beType = BE_TYPE;
            string impExpType = IMP_EXP_TYPE;
            string transMode = TRANSPORT_MODE;

            if (!string.IsNullOrEmpty(beType) && !excludedBE.Contains(beType) && impExpType == "HAND CARRIAGE" && transMode == "Air")
            {
                if (!deptList.Contains("HAND")) deptList.Add("HAND");
            }

            DataTable dtInvItem = ViewState["DS_InvItem"] as DataTable;

            DataTable dtCCDC = ViewState["DS_CCDC"] as DataTable;
            if (dtCCDC != null && dtCCDC.Rows.Count > 0)
            {
                if (!deptList.Contains("CCDC")) deptList.Add("CCDC");
            }

            deptList.Remove("PEC");

            if (deptList.Count == 0)
            {
                lblNoDept.Text = "No departments configured for this RITC.";
                lblNoDept.Visible = true;
                pnl_AllDepts.Visible = false;
                return;
            }

            lblNoDept.Visible = false;
            DataTable dtAll = Build_AllDepts_DataTable(deptList);
            ViewState["AllDeptsTable"] = dtAll;

            DataTable dtDepts = new DataTable();
            dtDepts.Columns.Add("DeptCode");
            foreach (string dep in deptList)
            {
                DataRow[] check = dtAll.Select("DeptCode = '" + dep + "'");
                if (check.Length > 0)
                    dtDepts.Rows.Add(dep);
            }

            rpt_Depts.DataSource = dtDepts;
            rpt_Depts.ItemDataBound += Rpt_Depts_ItemDataBound;
            rpt_Depts.DataBind();
            pnl_AllDepts.Visible = true;
            Load_Saved_Grid();
        }
        catch (Exception ex) { Alert_msg("Error loading departments: " + ex.Message); }
    }

    private DataTable Build_AllDepts_DataTable(List<string> deptList)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("DeptCode");
        dt.Columns.Add("RowIndex");
        dt.Columns.Add("InfoTypeCode");
        dt.Columns.Add("InfoTypeDesc");
        dt.Columns.Add("InfoQualCode");
        dt.Columns.Add("InfoQualDesc");
        dt.Columns.Add("NeedsInfoCode", typeof(bool));
        dt.Columns.Add("NeedsInfoText", typeof(bool));
        dt.Columns.Add("NeedsMSR", typeof(bool));
        dt.Columns.Add("NeedsUQC", typeof(bool));
        dt.Columns.Add("IsYesNo", typeof(bool));

        foreach (string dept in deptList)
        {
            List<DeptRow> rows;

            if (DeptDefaultRows.ContainsKey(dept))
            {
                rows = DeptDefaultRows[dept];
            }
            else
            {
                
                rows = Build_DynamicDeptRows(dept);
                if (rows.Count == 0) continue;
            }

            int idx = 0;
            foreach (DeptRow r in rows)
            {
                dt.Rows.Add(dept, idx, r.InfoTypeCode, r.InfoTypeDesc, r.InfoQualCode, r.InfoQualDesc, r.NeedsInfoCode, r.NeedsInfoText, r.NeedsMSR, r.NeedsUQC, r.IsYesNo);
                idx++;
            }
        }
        return dt;
    }
   
    private List<DeptRow> Build_DynamicDeptRows(string deptCode) // Added by shanthini on 18-09-2026
    {
        var rows = new List<DeptRow>();
        try
        {
            Am = new adminmaster();
            Am.SCHEME_NOTN = deptCode;
            Am.SCHEME_IMPORT_CODE = "";
            Am.name = "Select_Info_Type_By_Department_Userwise";
            DataSet ds_types = Am.IMP_Single_Window();

            if (ds_types == null || ds_types.Tables.Count == 0 || ds_types.Tables[0].Rows.Count == 0)
                return rows;

            foreach (DataRow drType in ds_types.Tables[0].Rows)
            {
                string infoType = drType["Info_type"].ToString().Trim();
                string infoTypeDesc = drType["Info_type_desc"].ToString().Trim();
                if (string.IsNullOrEmpty(infoType)) continue;

                Am = new adminmaster();
                Am.SCHEME_NOTN = deptCode;
                Am.SCHEME_IMPORT_CODE = infoType;
                Am.name = "Select_Info_Qualifier";
                DataSet ds_qual = Am.IMP_Single_Window();

                if (ds_qual != null && ds_qual.Tables.Count > 0 && ds_qual.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drQual in ds_qual.Tables[0].Rows)
                    {
                        string qualCode = drQual["IFO_QFR_CODE"].ToString().Trim();
                        string qualDesc = drQual["IFO_QFR_CODE_desc"].ToString().Trim();
                        if (string.IsNullOrEmpty(qualCode)) continue;

                        rows.Add(new DeptRow(infoType, infoTypeDesc, qualCode, qualDesc, true, true, false, false));
                    }
                }
                else
                {
                    
                    rows.Add(new DeptRow(infoType, infoTypeDesc, "", "", false, true, false, false));
                }
            }
        }
        catch { /* leave rows as-is */ }
        return rows;
    }

    protected void Rpt_Depts_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item &&
            e.Item.ItemType != ListItemType.AlternatingItem) return;

        DataRowView drv = e.Item.DataItem as DataRowView;
        if (drv == null) return;

        string deptCode = drv["DeptCode"].ToString().ToUpper();

        Label lblDept = e.Item.FindControl("lbl_DeptName") as Label;
        if (lblDept != null) lblDept.Text = deptCode;

        Repeater rptRows = e.Item.FindControl("rpt_DeptRows") as Repeater;
        if (rptRows == null) return;

        DataTable dtAll = ViewState["AllDeptsTable"] as DataTable;
        if (dtAll == null) return;

        DataRow[] deptRows = dtAll.Select("DeptCode = '" + deptCode + "'");
        if (deptRows.Length == 0) return;

        DataTable dtDept = dtAll.Clone();
        foreach (DataRow dr in deptRows) dtDept.ImportRow(dr);

        rptRows.DataSource = dtDept;
        rptRows.ItemDataBound += Rpt_DeptRows_ItemDataBound;
        rptRows.DataBind();
    }

    protected void Rpt_DeptRows_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item &&
            e.Item.ItemType != ListItemType.AlternatingItem) return;

        DataRowView drv = e.Item.DataItem as DataRowView;
        if (drv == null) return;

        bool needsCode = (bool)drv["NeedsInfoCode"];
        bool isYesNo = (bool)drv["IsYesNo"];
        bool needsUQC = (bool)drv["NeedsUQC"];
        string qualCode = drv["InfoQualCode"].ToString();

        DropDownList ddlCode = e.Item.FindControl("ddl_Code") as DropDownList;
        if (ddlCode != null)
        {
            ddlCode.Items.Clear();
            ddlCode.Items.Add(new ListItem("-- Select --", ""));

            if (isYesNo)
            {
                ddlCode.Items.Add(new ListItem("Yes", "Y"));
                ddlCode.Items.Add(new ListItem("No", "N"));
            }
            else if (needsCode && !string.IsNullOrEmpty(qualCode))
            {
                try
                {
                    Am = new adminmaster();
                    Am.SCHEME_NOTN = "";
                    Am.SCHEME_IMPORT_CODE = qualCode;
                    Am.name = "Select_Info_Code";
                    DataSet ds_c = Am.IMP_Single_Window();

                    if (ds_c != null && ds_c.Tables.Count > 0 && ds_c.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow r in ds_c.Tables[0].Rows)
                        {
                            ddlCode.Items.Add(new ListItem(
                                r["info_desc"].ToString(),
                                r["IFO_CODE"].ToString()));
                        }
                    }
                }
                catch { /* silent */ }
            }

            if (qualCode == "SIU" && ddlCode.Items.Count > 1)
            {
                string transMode = TRANSPORT_MODE;
                string autoSelect = (transMode == "Air") ? "SIUNAF" : "SIUNRR";

                ListItem autoItem = ddlCode.Items.FindByValue(autoSelect);
                if (autoItem != null)
                    ddlCode.SelectedValue = autoSelect;
                if (transMode == "Air")
                {
                    TextBox txtText = e.Item.FindControl("txt_Text") as TextBox;
                    if (txtText != null)
                        txtText.Text = "SIUN000";
                }
            }
        }
    }

    private void Bind_InvItem_ByRITC(string selectedRITC)
    {
        chk_InvItem.Items.Clear();

        DataTable dtAll = ViewState["DS_InvItem"] as DataTable;
        if (dtAll == null) return;

        DataRow[] rows = dtAll.Select("CTH_NO = '" + selectedRITC + "'");
        foreach (DataRow dr in rows)
        {
            string inv = dr["INVOICE_SLNO"].ToString();
            string item = dr["ITEM_SLNO"].ToString();
            chk_InvItem.Items.Add(new ListItem("Inv " + inv + " - Item " + item, inv + "|" + item));
        }
    }

    private List<string[]> GetSelectedInvItems()
    {
        var list = new List<string[]>();
        foreach (ListItem li in chk_InvItem.Items)
            if (li.Selected && li.Value.Contains("|"))
                list.Add(li.Value.Split('|'));
        return list;
    }

    private void DoInsertUpdate(string flag, string swId)
    {

        List<string[]> selectedInvItems = GetSelectedInvItems();

        // Mode-aware RITC validation
        bool deptMode = (CurrentMode == "DEPT");
        if (!deptMode)
        {
            if (string.IsNullOrEmpty(ddl_RITC.SelectedValue))
            { Alert_msg("Please select a RITC No."); return; }
        }
        else
        {
            if (string.IsNullOrEmpty(ddl_Dept.SelectedValue))
            { Alert_msg("Please select a Department."); return; }
            bool anyRitc = false;
            foreach (ListItem li in chk_RITC.Items) { if (li.Selected) { anyRitc = true; break; } }
            if (!anyRitc)
            { Alert_msg("Please select at least one RITC."); return; }
        }

        if (selectedInvItems.Count == 0)
        {
            bool anyTicked = false;
            foreach (ListItem li in chk_InvItem.Items)
            {
                if (li.Selected) { anyTicked = true; break; }
            }
            if (!anyTicked && chk_InvItem.Items.Count > 0)
            {
                foreach (ListItem li in chk_InvItem.Items)
                    li.Selected = true;
                selectedInvItems = GetSelectedInvItems();
            }
        }

        if (selectedInvItems.Count == 0)
        { Alert_msg("Please select at least one Invoice / Item."); return; }

        string jobNo = hfJobNo.Value;
        int count = 0;

        foreach (RepeaterItem deptItem in rpt_Depts.Items)
        {
            if (deptItem.ItemType != ListItemType.Item &&
                deptItem.ItemType != ListItemType.AlternatingItem) continue;

            Label lblDept = deptItem.FindControl("lbl_DeptName") as Label;
            string dept = lblDept != null ? lblDept.Text : "";

            Repeater rptRows = deptItem.FindControl("rpt_DeptRows") as Repeater;
            if (rptRows == null) continue;

            foreach (RepeaterItem rowItem in rptRows.Items)
            {
                if (rowItem.ItemType != ListItemType.Item &&
                    rowItem.ItemType != ListItemType.AlternatingItem) continue;

                HiddenField hfIT = rowItem.FindControl("hf_InfoType") as HiddenField;
                HiddenField hfIQ = rowItem.FindControl("hf_InfoQual") as HiddenField;
                DropDownList ddlCode = rowItem.FindControl("ddl_Code") as DropDownList;
                TextBox txtText = rowItem.FindControl("txt_Text") as TextBox;
                TextBox txtMSR = rowItem.FindControl("txt_MSR") as TextBox;
                DropDownList ddlUQC = rowItem.FindControl("ddl_UQC") as DropDownList;

                string infoType = hfIT != null ? hfIT.Value : "";
                string infoQual = hfIQ != null ? hfIQ.Value : "";
                string infoCode = ddlCode != null ? ddlCode.SelectedValue : "";
                string infoText = txtText != null ? txtText.Text.Trim() : "";
                string infoMSR = txtMSR != null ? txtMSR.Text.Trim() : "";
                string infoUQC = ddlUQC != null ? ddlUQC.SelectedValue : "";

                HiddenField hfRowSwId = rowItem.FindControl("hf_SwId") as HiddenField;
                string rowSwId = (flag == "U" && hfRowSwId != null && hfRowSwId.Value != "0") ? hfRowSwId.Value : (flag == "U" ? swId : "0");

                foreach (string[] ii in selectedInvItems)
                {
                    string invSlno = ii[0];
                    string itemSlno = ii[1];

                    ObjUBO.SW_ID = rowSwId;
                    ObjUBO.JOBNO = jobNo;
                    ObjUBO.INVOICE_SLNO = invSlno;
                    ObjUBO.ITEM_SLNO = itemSlno;
                    ObjUBO.INFO_TYPE = infoType;
                    ObjUBO.INFO_QUALIFIER = infoQual;
                    ObjUBO.INFO_CODE = infoCode;
                    ObjUBO.INFO_TEXT = infoText;
                    ObjUBO.INFO_MSR = infoMSR;
                    ObjUBO.INFO_UQC = infoUQC;
                    ObjUBO.DEPARTMENT = dept;
                    ObjUBO.I_U_TYPE = "B";
                    ObjUBO.REGN_DATE = "";
                    ObjUBO.REGN_VALIDITY = "";
                    ObjUBO.AMENDMENT_TYPE = "";
                    ObjUBO.AMENDMENT_STATUS = "";
                    ObjUBO.flag = flag;
                    ObjUBO.Ename = "";
                    SW.SW_INFOTYPE_Details_Insert_Update(ObjUBO);
                    count++;
                }
            }
        }

        if (flag == "S")
        {
            Alert_msg(count + " record(s) saved successfully.");
            // Bulk flow: show grid but stay in Save mode + clear the form so the
            // user can switch the dept dropdown and add the next dept right away.
            ResetInputFields();
            hfEditSwId.Value = "0";
            Load_Saved_Grid(true);   // display-only: no auto-fill, no edit-mode switch
        }
        else
        {
            Alert_msg("Records updated successfully.");
            Load_Saved_Grid();       // normal: keep the updated record in edit mode
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        DoInsertUpdate("S", "0");
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        string swId = hfEditSwId.Value;
        if (string.IsNullOrEmpty(swId) || swId == "0")
        { Alert_msg("Please select a record to update."); return; }
        DoInsertUpdate("U", swId);
    }

    protected void btndelete_Click(object sender, EventArgs e)
    {
        try
        {
            string jobNo = hfJobNo.Value;

            List<string[]> selectedInvItems = GetSelectedInvItems();
            if (selectedInvItems.Count == 0 && chk_InvItem.Items.Count > 0)
            {
                foreach (ListItem li in chk_InvItem.Items)
                    li.Selected = true;
                selectedInvItems = GetSelectedInvItems();
            }

            if (selectedInvItems.Count == 0)
            { Alert_msg("Please select at least one Invoice / Item to delete."); return; }

            int deletedCount = 0;

            foreach (RepeaterItem deptItem in rpt_Depts.Items)
            {
                if (deptItem.ItemType != ListItemType.Item &&
                    deptItem.ItemType != ListItemType.AlternatingItem) continue;

                Repeater rptRows = deptItem.FindControl("rpt_DeptRows") as Repeater;
                if (rptRows == null) continue;

                foreach (RepeaterItem rowItem in rptRows.Items)
                {
                    if (rowItem.ItemType != ListItemType.Item &&
                        rowItem.ItemType != ListItemType.AlternatingItem) continue;
                    HiddenField hfRowSwId = rowItem.FindControl("hf_SwId") as HiddenField;

                    if (hfRowSwId == null || string.IsNullOrEmpty(hfRowSwId.Value) || hfRowSwId.Value == "0")
                        continue;

                    string rowSwId = hfRowSwId.Value;

                    foreach (string[] ii in selectedInvItems)
                    {
                        string invSlno = ii[0];
                        string itemSlno = ii[1];
                        ObjUBO.JOBNO = jobNo;
                        ObjUBO.SW_ID = rowSwId;
                        ObjUBO.INVOICE_SLNO = invSlno;
                        ObjUBO.ITEM_SLNO = itemSlno;
                        ObjUBO.flag = "Item_All_Info_Delete";
                        SW.SW_INFOTYPE_Details_Insert_Update(ObjUBO);
                        if (SW.result > 0) deletedCount++;
                    }
                }
            }

            if (deletedCount > 0)
            {
                Alert_msg(deletedCount + " record(s) deleted successfully.");
                ResetInputFields();
                hfEditSwId.Value = "0";
                Load_Saved_Grid(true);   // display-only: stay in fresh Save mode
                Set_Button_State(true);
            }
            else
                Alert_msg("Delete failed. Please try again.");
        }
        catch (Exception ex) { Alert_msg("Delete Error: " + ex.Message); }
    }
    // gridDisplayOnly = true  -> only show the grid, DO NOT auto-fill the form
    //                            or switch to edit mode (stay in Save mode).
    //                            Used right after a Save/Update/Delete so the
    //                            user can continue adding the next dept in bulk.
    // gridDisplayOnly = false -> normal behaviour: if a saved record matches the
    //                            current RITC/Dept, auto-fill + show Update/Delete.
    private void Load_Saved_Grid(bool gridDisplayOnly = false)
    {
        try
        {
            ObjUBO.JOBNO = hfJobNo.Value;
            ObjUBO.BRANCH_CODE = hfBranchType.Value;
            // RITC mode: filter by selected RITC. DEPT mode: first selected RITC
            // (saved-grid is keyed by dept|infotype|qualifier, RITC is just a filter).
            if (CurrentMode == "DEPT")
            {
                string firstRitc = "";
                foreach (ListItem li in chk_RITC.Items)
                    if (li.Selected) { firstRitc = li.Value; break; }
                ObjUBO.RITCNO = firstRitc;
            }
            else
            {
                ObjUBO.RITCNO = ddl_RITC.SelectedValue;
            }
            DataSet ds = SW.Select_Imp_Job_Sw_Details(ObjUBO);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dtSaved = ds.Tables[0];

                gvSaved.DataSource = dtSaved;
                gvSaved.DataBind();
                pnl_SavedGrid.Visible = true;

                // ── In display-only mode (just after a save), skip auto-fill ──
                // Keep the form fresh + stay in Save mode so the next dept can
                // be entered without the page jumping into Update mode.
                if (gridDisplayOnly)
                {
                    Set_Button_State(true);
                    return;
                }

                var lookup = new Dictionary<string, DataRow>(StringComparer.OrdinalIgnoreCase);
                foreach (DataRow dr in dtSaved.Rows)
                {
                    string key = dr["DEPARTMENT"].ToString().Trim() + "|" + dr["INFO_TYPE"].ToString().Trim() + "|" + dr["INFO_QUALIFIER"].ToString().Trim();
                    if (!lookup.ContainsKey(key))
                        lookup[key] = dr;
                }

                bool matchedAny = false;   // did a CURRENTLY VISIBLE dept-row match a saved record?

                foreach (RepeaterItem deptItem in rpt_Depts.Items)
                {
                    if (deptItem.ItemType != ListItemType.Item && deptItem.ItemType != ListItemType.AlternatingItem) continue;

                    Label lblDept = deptItem.FindControl("lbl_DeptName") as Label;
                    string dept = lblDept != null ? lblDept.Text.Trim() : "";

                    Repeater rptRows = deptItem.FindControl("rpt_DeptRows") as Repeater;
                    if (rptRows == null) continue;

                    foreach (RepeaterItem rowItem in rptRows.Items)
                    {
                        if (rowItem.ItemType != ListItemType.Item && rowItem.ItemType != ListItemType.AlternatingItem) continue;

                        HiddenField hfIT = rowItem.FindControl("hf_InfoType") as HiddenField;
                        HiddenField hfIQ = rowItem.FindControl("hf_InfoQual") as HiddenField;
                        if (hfIT == null || hfIQ == null) continue;

                        string lookupKey = dept + "|" + hfIT.Value + "|" + hfIQ.Value;
                        if (!lookup.ContainsKey(lookupKey)) continue;

                        matchedAny = true;
                        DataRow saved = lookup[lookupKey];

                        HiddenField hfSwId = rowItem.FindControl("hf_SwId") as HiddenField;
                        if (hfSwId != null)
                            hfSwId.Value = saved["SW_INFO_TYPE_ID"].ToString();

                        hfEditSwId.Value = saved["SW_INFO_TYPE_ID"].ToString();

                        DropDownList ddlCode = rowItem.FindControl("ddl_Code") as DropDownList;
                        TextBox txtText = rowItem.FindControl("txt_Text") as TextBox;
                        TextBox txtMSR = rowItem.FindControl("txt_MSR") as TextBox;
                        DropDownList ddlUQC = rowItem.FindControl("ddl_UQC") as DropDownList;

                        if (ddlCode != null)
                        {
                            string savedCode = saved["INFO_CODE"].ToString();
                            ListItem li = ddlCode.Items.FindByValue(savedCode);
                            if (li != null) ddlCode.SelectedValue = savedCode;
                        }
                        if (txtText != null) txtText.Text = saved["INFO_TEXT"].ToString();
                        if (txtMSR != null) txtMSR.Text = saved["INFO_MSR"].ToString();
                        if (ddlUQC != null)
                        {
                            string savedUQC = saved["INFO_UQC"].ToString();
                            ListItem li = ddlUQC.Items.FindByValue(savedUQC);
                            if (li != null) ddlUQC.SelectedValue = savedUQC;
                        }
                    }
                }

                var savedInvItems = new HashSet<string>(
                    dtSaved.AsEnumerable()
                           .Select(r => r["INVOICE_SLNO"].ToString() + "|" + r["ITEM_SLNO"].ToString()),
                    StringComparer.OrdinalIgnoreCase
                );

                var sbDisplay = new System.Text.StringBuilder();
                foreach (ListItem li in chk_InvItem.Items)
                {
                    if (savedInvItems.Contains(li.Value))
                    {
                        li.Selected = true;
                        if (sbDisplay.Length > 0) sbDisplay.Append(", ");
                        sbDisplay.Append(li.Text);
                    }
                }
                if (sbDisplay.Length > 0)
                    txt_InvItem.Text = sbDisplay.ToString();

                // Switch to Update/Delete mode ONLY when the currently shown dept
                // actually has a saved record. If saved data exists only for OTHER
                // depts (e.g. FTA saved from another page), stay in Save mode so
                // this new dept can still be added.
                if (matchedAny)
                    Set_Button_State(false);
                else
                {
                    hfEditSwId.Value = "0";
                    Set_Button_State(true);
                }
            }
            else
            {
                gvSaved.DataSource = null;
                gvSaved.DataBind();
                pnl_SavedGrid.Visible = false;
                Set_Button_State(true);
            }
        }
        catch (Exception ex)
        {
            pnl_SavedGrid.Visible = false;
            Alert_msg("Grid load error: " + ex.Message);
        }
    }

    protected void gvSaved_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    private void Set_Button_State(bool isNewMode)
    {
        btnsave.Visible = isNewMode;
        btn_Update.Visible = !isNewMode;
        btndelete.Visible = !isNewMode;
    }

    private void ResetInputFields()
    {
        foreach (RepeaterItem deptItem in rpt_Depts.Items)
        {
            if (deptItem.ItemType != ListItemType.Item &&
                deptItem.ItemType != ListItemType.AlternatingItem) continue;

            Repeater rptRows = deptItem.FindControl("rpt_DeptRows") as Repeater;
            if (rptRows == null) continue;

            foreach (RepeaterItem rowItem in rptRows.Items)
            {
                if (rowItem.ItemType != ListItemType.Item && rowItem.ItemType != ListItemType.AlternatingItem) continue;

                DropDownList ddlCode = rowItem.FindControl("ddl_Code") as DropDownList;
                TextBox txtText = rowItem.FindControl("txt_Text") as TextBox;
                TextBox txtMSR = rowItem.FindControl("txt_MSR") as TextBox;
                DropDownList ddlUQC = rowItem.FindControl("ddl_UQC") as DropDownList;

                if (ddlCode != null && ddlCode.Items.Count > 0) ddlCode.SelectedIndex = 0;
                if (txtText != null) txtText.Text = "";
                if (txtMSR != null) txtMSR.Text = "";
                if (ddlUQC != null && ddlUQC.Items.Count > 0) ddlUQC.SelectedIndex = 0;
            }
        }
        foreach (ListItem li in chk_InvItem.Items) li.Selected = false;
        txt_InvItem.Text = "";
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        if (CurrentMode == "DEPT")
        {
            string curDept = ddl_Dept.SelectedValue;
            // RITC source data lives in ViewState["DS_InvItem"]; rebuild dept list
            Bind_Dept_Dropdown();
            if (!string.IsNullOrEmpty(curDept))
            {
                ListItem dli = ddl_Dept.Items.FindByValue(curDept);
                if (dli != null)
                {
                    ddl_Dept.SelectedValue = curDept;
                    ddl_Dept_SelectedIndexChanged(null, null);
                }
            }
            return;
        }

        string currentRITC = ddl_RITC.SelectedValue;
        Bind_RITC_Dropdown();
        if (!string.IsNullOrEmpty(currentRITC))
        {
            ListItem li = ddl_RITC.Items.FindByValue(currentRITC);
            if (li != null)
            {
                ddl_RITC.SelectedValue = currentRITC;
                Bind_InvItem_ByRITC(currentRITC);
                Load_AllDepts_ForRITC(currentRITC);
            }
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" +
                        msg.Replace("'", "\\'") +
                        "', 'SW Bulk Entry', function(r){});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}

public class DeptRow
{
    public string InfoTypeCode { get; set; }
    public string InfoTypeDesc { get; set; }
    public string InfoQualCode { get; set; }
    public string InfoQualDesc { get; set; }
    public bool NeedsInfoCode { get; set; }
    public bool NeedsInfoText { get; set; }
    public bool NeedsMSR { get; set; }
    public bool NeedsUQC { get; set; }
    public bool IsYesNo { get; set; }

    public DeptRow(string itCode, string itDesc, string iqCode, string iqDesc, bool needsCode, bool needsText, bool needsMSR, bool needsUQC)
    {
        InfoTypeCode = itCode; InfoTypeDesc = itDesc;
        InfoQualCode = iqCode; InfoQualDesc = iqDesc;
        NeedsInfoCode = needsCode; NeedsInfoText = needsText;
        NeedsMSR = needsMSR; NeedsUQC = needsUQC;
    }
}