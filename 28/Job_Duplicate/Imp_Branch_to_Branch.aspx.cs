using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BussinessObject;

public partial class Imp_Branch_to_Branch : ThemeClass
{
    public string Working_Period, SELECT_BRANCH, DB_CONN, COMP_WORKING_PERIOD, DB_NAME, SELECT_TYPE;

    AppSession aps = new AppSession();
    Imp_Job_Duplicate JD = new Imp_Job_Duplicate();
    DataSet ds = new DataSet();
    Company_Master Comp = new Company_Master();

    public string COMPANY_ID, flag;
    private int i;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Working_Period = Connection.WorkingPeriod();
        COMPANY_ID = Connection.COMPANYID();
        SELECT_BRANCH = Connection.Get_Company_Type();
        SELECT_TYPE = Session["SELECT_TYPE"].ToString();


        if (!IsPostBack)
        {
            if (Request.QueryString["Jobno"] == "I")
            {
                Load_Job_Process_Type();
                EXP.Visible = false;
                Close.Visible = true;
                txtCurrent_Job.Attributes.Add("readonly", "readonly");
                Load_Visible();
                LoadFinancialYear();
                
            }
        }
    }
   /* public void LoadFinancialYear()
    {

        DataSet ds = new DataSet();
        JD.Ename = "Company_Wrk_Select";
        JD.WORKING_PERIOD = Connection.WorkingPeriod();
        ds = JD.Load_Company_Branch();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlWorkingPeriod.DataSource = ds.Tables[0];
            ddlWorkingPeriod.DataValueField = "WORKING_PERIOD";
            ddlWorkingPeriod.DataTextField = "WORKING_PERIOD";
            ddlWorkingPeriod.DataBind();
        }
        ddlWorkingPeriod.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlWorkingPeriod.SelectedValue = Connection.WorkingPeriod();

        if (Session["SELECT_TYPE"].ToString() == "Areawise Job")
        {
            ddlWorkingPeriod.Enabled = false;
            hdn_Server.Value = ds.Tables[1].Rows[0][0].ToString();
            //LoadGroup();      
            Load_Jobno_groupbased(  hdn_Server.Value);
        }
        else
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                Load_Jobno(ds.Tables[1].Rows[0][0].ToString());
            }
        }
    } */

    public void LoadFinancialYear() // Added by shanthini on 05-06-2026
    {
        DataSet ds = new DataSet();
        JD.Ename = "Company_Wrk_Select";
        JD.WORKING_PERIOD = Connection.WorkingPeriod();
        ds = JD.Load_Company_Branch();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlWorkingPeriod.DataSource = ds.Tables[0];
            ddlWorkingPeriod.DataValueField = "WORKING_PERIOD";
            ddlWorkingPeriod.DataTextField = "WORKING_PERIOD";
            ddlWorkingPeriod.DataBind();
        }
        ddlWorkingPeriod.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlWorkingPeriod.SelectedValue = Connection.WorkingPeriod();

        if (Session["SELECT_TYPE"].ToString() == "Areawise Job")
        {
            ddlWorkingPeriod.Enabled = false;
            hdn_Server.Value = ds.Tables[1].Rows[0][0].ToString();
            Load_Jobno_groupbased(hdn_Server.Value);
        }
        else
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                Load_Jobno(ds.Tables[1].Rows[0][0].ToString());
            }
        }

        // -----------------------------------------------
        // AUTO-SELECT JOB PASSED FROM GRID
        // -----------------------------------------------
        string selectedJobPS = Request.QueryString["SelectedJob"];

        if (!string.IsNullOrEmpty(selectedJobPS))
        {
            selectedJobPS = selectedJobPS.Trim();
            bool found = false;

            // Search by Text (JOBNO_PS) - exact match
            foreach (ListItem item in ddlJobNo.Items)
            {
                if (item.Text.Trim().ToUpper() == selectedJobPS.ToUpper())
                {
                    ddlJobNo.ClearSelection();
                    item.Selected = true;
                    found = true;
                    break;
                }
            }

            // If not found by text, try by Value (plain JOBNO)
            if (!found)
            {
                foreach (ListItem item in ddlJobNo.Items)
                {
                    if (item.Value.Trim().ToUpper() == selectedJobPS.ToUpper())
                    {
                        ddlJobNo.ClearSelection();
                        item.Selected = true;
                        found = true;
                        break;
                    }
                }
            }

            // If found, load job data automatically
            if (found && ddlJobNo.SelectedValue != string.Empty)
            {
                ddlJobNo_SelectedIndexChanged(null, EventArgs.Empty);
            }
        }
        
    }
    
    protected void ddlWorkingPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear();
        if (ddlWorkingPeriod.SelectedValue.ToString() != string.Empty)
        {
            if (Session["SELECT_TYPE"].ToString() != "Areawise Job")
            {
                if (Rd_Convert.SelectedValue.ToString() == "C")
                {
                    Load_Branch_Copy_Location(load_Con_String());

                }
                else
                {
                    Load_Jobno(load_Con_String());
                }
            }
            else if (Session["SELECT_TYPE"].ToString() != "Areawise Job")
            {
                Load_Group_Branch(ddlFromGrp.SelectedValue.ToString(), ddlFrom_Branch);

            }
        }
    }


    public void LoadGroup()
    {
        Clear();
        DataSet dsGrp = new DataSet();
        Comp.COMPANY_ID = "";
        Comp.flag = "Select-Group";
        dsGrp = Comp.RetrieveAll_Groups();
        ddlFromGrp.Items.Clear();
        ddlToGrp.Items.Clear();

        if (dsGrp.Tables.Count > 0)
        {
            if (Rd_Convert.SelectedValue.ToString() == "C")
            {
                ddlFromGrp.Enabled = true;
                ddlFromGrp.DataSource = dsGrp.Tables[0];
                ddlFromGrp.DataTextField = "GROUP_NAME";
                ddlFromGrp.DataValueField = "GROUP_ID";
                ddlFromGrp.DataBind();

                if (Session["GroupID"].ToString() != "" && Session["GroupID"].ToString() != null)
                {
                    ddlFromGrp.Items.Remove(ddlFromGrp.Items.FindByValue(Session["GroupID"].ToString()));

                }
                ddlToGrp.Items.Insert(0, new ListItem(Session["GroupName"].ToString(), Session["GroupID"].ToString()));
                ddlToGrp.Enabled = false;
                Load_Group_Branch(ddlFromGrp.SelectedValue.ToString(), ddltoBranch); // here right side branch loading
                Load_Jobno_groupbased(hdn_Server.Value);
            }
            else if (Rd_Convert.SelectedValue.ToString() == "T")
            {
                ddlToGrp.Enabled = true;
                ddlToGrp.DataSource = dsGrp.Tables[0];
                ddlToGrp.DataTextField = "GROUP_NAME";
                ddlToGrp.DataValueField = "GROUP_ID";
                ddlToGrp.DataBind();

                if (Session["GroupID"].ToString() != "" && Session["GroupID"].ToString() != null)
                {
                    ddlToGrp.Items.Remove(ddlToGrp.Items.FindByValue(Session["GroupID"].ToString()));

                }

                ddlToGrp.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlToGrp.SelectedIndex = 0;

                ddlFromGrp.Items.Insert(0, new ListItem(Session["GroupName"].ToString(), Session["GroupID"].ToString()));
                ddlFromGrp.Enabled = false;
                Load_Group_Branch(ddlToGrp.SelectedValue.ToString(), ddltoBranch); // here right side branch loading
                Load_Jobno_groupbased(hdn_Server.Value);
            }
        }
    }

    private void Load_Jobno_groupbased(string Con_String)
    {
        ddlJobNo.Items.Clear();
        DataSet ds = new DataSet();
        DB_CONN = Con_String;
        if (ddlFromGrp.SelectedValue.ToString() != "")
        {
            JD.Convert_To = ddlFromGrp.SelectedValue.ToString();
        }
        else
        {
            JD.Convert_To = Session["GroupID"].ToString();
        }
        JD.Ename = "IMP_JOBNO_SELECT_WITHIN_GRP";
        ds = JD.Select_Job_No(DB_CONN, "Import");

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlJobNo.DataSource = ds.Tables[0];
            ddlJobNo.DataValueField = "JOBNO";
            ddlJobNo.DataTextField = "JOBNO_PS";
            ddlJobNo.DataBind();
        }
        Add_Empty_Jobno();
    }
    

    public void Load_Group_Branch(string groupid, DropDownList brnddl)
    {
        DataSet dsGrpRight = new DataSet();
        Comp.COMPANY_ID = ddlToGrp.SelectedValue.ToString();       

        Comp.flag = "Select-Group";
        dsGrpRight = Comp.RetrieveAll_Groups();
        if (dsGrpRight.Tables.Count > 1)
        {
            brnddl.DataSource = dsGrpRight.Tables[1];
            //brnddl.DataTextField = "BRANCHCODE";// CUSTOMHOUSE_BRANCHCODE;            
            //brnddl.DataValueField = "BRANCHCODE";

            brnddl.DataValueField = "CUSTOMHOUSE_CATEGORY";
            brnddl.DataTextField = "PORT_OF_FILING";

            brnddl.DataBind();
        }
        Add_Empty_To();
    }

    protected void ddlFromGrp_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Jobno_groupbased(hdn_Server.Value);
    }


   

    private void Load_Branch_Copy_Location(string Con_String)
    {
        ddlJobNo.Items.Clear();
        ddlFrom_Branch.Items.Clear();


        DataSet ds = new DataSet();

        JD.Ename = "Copy_Location";
        JD.WORKING_PERIOD = ddlWorkingPeriod.SelectedValue.ToString();
        ds = JD.Load_Company_Branch();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlFrom_Branch.DataSource = ds.Tables[0];
            ddlFrom_Branch.DataValueField = "BRANCH";
            ddlFrom_Branch.DataTextField = "BRANCH";
            ddlFrom_Branch.DataBind();
        }
        Add_Empty_From();
    }

    private void Load_Jobno(string Con_String)
    {
        DataSet ds = new DataSet();
        DB_CONN = Con_String;
        JD.Ename = "IMP_JOBNO_SELECT";
        ds = JD.Select_Job_No(DB_CONN, "Import");

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlJobNo.DataSource = ds.Tables[0];
            ddlJobNo.DataValueField = "JOBNO";
            ddlJobNo.DataTextField = "JOBNO_PS";
            ddlJobNo.DataBind();
        }
        Add_Empty_Jobno();
    }
    
    

    protected void ddlToGrp_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Group_Branch(ddlToGrp.SelectedValue.ToString(), ddltoBranch);
    }

    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear();
        DataSet ds = new DataSet();
        if (ddlJobNo.SelectedValue.ToString() != string.Empty)
        {
            DB_CONN = load_Con_String();
            if (Rd_Convert.SelectedValue.ToString() == "C")
            {
                 if (Session["SELECT_TYPE"].ToString() == "Areawise Job")
                {
                    JD.Convert_To = ddlFromGrp.SelectedValue.ToString();                   
                    JD.JOBNO = ddlJobNo.SelectedValue.ToString();
                    JD.Ename = "IMP_Branch_Jobno_Select_FromGroup";
                    ds = JD.Select_Job_No(DB_CONN, "Import");
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        ddlFrom_Branch.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["BRANCHCODE"].ToString(), ds.Tables[0].Rows[0]["BRANCHCODE"].ToString()));
                    }
                }
                else
                {
                    if (ddlFrom_Branch.SelectedValue.ToString() != string.Empty)
                    {
                        JD.BRANCH_CODE = ddlFrom_Branch.SelectedValue.ToString();
                        JD.JOBNO = ddlJobNo.SelectedValue.ToString();
                        JD.Ename = "IMP_Branch_Jobno_Select";
                        ds = JD.Select_Job_No(DB_CONN, "Import");
                    }
                    else
                    {
                        Clear();
                    }
                }

            }
            else
            {
                JD.JOBNO = ddlJobNo.SelectedValue.ToString();
                JD.Ename = "IMP_JOBNO_DATA_SELECT";
                ds = JD.Select_Job_No(DB_CONN, "Import");
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                Show_Data(ds);
                PortOrigin_Shipment_enable_disable();
                //-----------------------------------------------------------
                if (Rd_Convert.SelectedValue.ToString() != "T")
                {

                    /* For Ref - get Current Logined Branchcode with TRMode like Banglore(Land)
                    string CurrentBranch_Code = Session["currentbranch_code"].ToString();

                    if (CurrentBranch_Code.Contains("(Air)"))
                    {
                        lbl_To_Tr_mode.Text = "Air";
                    }
                    else if (CurrentBranch_Code.Contains("(Sea)"))
                    {
                        lbl_To_Tr_mode.Text = "Sea";
                    }
                    else
                    {
                        lbl_To_Tr_mode.Text = "Land";
                    }
                    */

                    Transaction Transact = new Transaction();
                    Transact.BRANCH_CODE = SELECT_BRANCH;
                    Transact.WORKING_PERIOD = Working_Period;

                    if (Rd_Convert.SelectedValue.ToString() == "LC")
                    {
                        txtCurrent_Job.Text = ddlJobNo.SelectedValue.ToString();
                    }
                    else
                    {
                        txtCurrent_Job.Text = Convert.ToString(Transact.RetrieveID());
                    }

                    //-----------------------------------------------------------
                    Admin_job_Prefix_Suffix JPS = new Admin_job_Prefix_Suffix();
                    DataSet dats = new DataSet();
                    //JPS.Branch = SELECT_BRANCH;  //Co Trmode--hide on 05-05-2022 by Chithra

                    if (SELECT_BRANCH == "")
                    {
                        JPS.Branch = txt_Tr_Mode.Text;
                    }
                    else
                    {
                        JPS.Branch = SELECT_BRANCH;  //Co Trmode
                    }
                    JPS.Ename = "Imp_gen_select";
                    JPS.Tr_mode = txt_Tr_Mode.Text;
                    JPS.BranchType = SELECT_TYPE;

                    //dats = JPS.Job_prefix_Suffix_Select();// hide on 16-07-2024

                    dats = JPS.Job_prefix_Suffix_Select_Areawise();

                    if (dats.Tables[0].Rows.Count > 0)
                    {
                        txt_Prefix.Text = dats.Tables[0].Rows[0][0].ToString();
                        txt_Suffix.Text = dats.Tables[0].Rows[0][1].ToString();
                    }
                    else
                    {
                        txt_Prefix.Text = string.Empty;
                        txt_Suffix.Text = string.Empty;
                    }
                }
                else
                {
                    ddltoBranch.SelectedIndex = -1;
                    txt_Prefix.Text = string.Empty;
                    txt_Suffix.Text = string.Empty;
                    txtCurrent_Job.Text = string.Empty;
                }
                //-----------------------------------------------------------
            }
        }
        if (Rd_Convert.SelectedValue.ToString() == "LC" || Rd_Convert.SelectedValue.ToString() == "T")
        {
            if (Session["SELECT_TYPE"].ToString() != "Areawise Job")
            {
                if (Rd_Convert.SelectedValue.ToString() == "LC" && ddlJobNo.SelectedValue.ToString() != string.Empty)
                {
                    ddltoBranch.Items.Clear();
                    DataSet dds = new DataSet();
                    JD.Ename = "Load_Cus_House_LC";
                    JD.SELECT_BRANCH_CODE = txtCustoms_House.Text;
                    dds = JD.Load_Company_Branch();
                    if (dds.Tables[0].Rows.Count > 0)
                    {
                        ddltoBranch.DataSource = dds.Tables[0];
                        ddltoBranch.DataValueField = "CUSTOMHOUSE_CATEGORY";
                        ddltoBranch.DataTextField = "PORT_OF_FILING";
                        ddltoBranch.DataBind();
                    }
                    Add_Empty_To();
                }

                ddltoBranch.SelectedIndex = -1;
                lbl_To_Tr_mode.Text = string.Empty;
            }
        }
    }

    private void Show_Data(DataSet ds)
    {
        txtImporterName.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
        txtCustoms_House.Text = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
        txtjobdate.Text = ds.Tables[0].Rows[0]["JOBDATE"].ToString();
        txtNoof_Inv.Text = ds.Tables[0].Rows[0]["No_of_Inv"].ToString();
        txtnoofItems.Text = ds.Tables[0].Rows[0]["No_Of_item"].ToString();
        txt_Tr_Mode.Text = ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();
        txtPortOrigin.Text = ds.Tables[0].Rows[0]["PORT_ORIGIN"].ToString();
        txtPortShipment.Text = ds.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString();
        txt_Oportorgin.Text = ds.Tables[0].Rows[0]["PORT_ORIGIN"].ToString();
        txt_OPortShipment.Text = ds.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString();
    }

    private void Clear()
    {
        txtImporterName.Text = string.Empty;
        txtCustoms_House.Text = string.Empty;
        txtjobdate.Text = string.Empty;
        txtNoof_Inv.Text = string.Empty;
        txtnoofItems.Text = string.Empty;
        txt_Tr_Mode.Text = string.Empty;

        txtPortOrigin.Text = string.Empty;
        txtPortShipment.Text = string.Empty;
        txt_Oportorgin.Text = string.Empty;
        txt_OPortShipment.Text = string.Empty;

        txtCurrent_Job.Text = string.Empty;
        txt_Prefix.Text = string.Empty;
        txt_Suffix.Text = string.Empty;
        lbl_To_Tr_mode.Text = string.Empty;
    }

    private string load_Con_String()
    {
        HD_DB_Name.Value = string.Empty;
        string server_path = string.Empty;

        JD.Ename = "Company_Wrk_Select";
        JD.WORKING_PERIOD = ddlWorkingPeriod.SelectedValue.ToString();
        ds = JD.Load_Company_Branch();
        if (ds.Tables[1].Rows.Count > 0)
        {
            server_path = ds.Tables[1].Rows[0][0].ToString();
            HD_DB_Name.Value = ds.Tables[1].Rows[0][1].ToString();
        }
        return server_path;
    }


    protected void btnconvert_Click(object sender, EventArgs e)
    {

        if (txtCurrent_Job.Text != string.Empty)
        {
            if (Rd_Convert.SelectedValue.ToString() == "D")
            {
                if (ddlWorkingPeriod.SelectedValue.ToString() != string.Empty && ddlJobNo.SelectedValue.ToString() != string.Empty && txtCurrent_Job.Text != string.Empty)
                {
                    if (Working_Period == ddlWorkingPeriod.SelectedValue.ToString())
                    {
                        Jobdup("GENERATE_IMPORT_DUPLICATE_JOB");
                    }
                    else
                    {
                        Jobdup("GENERATE_IMPORT_DUPLICATE_JOB_WORK_PERIOD");
                    }
                }
            }
            else if (Rd_Convert.SelectedValue.ToString() == "LC")
            {
                if (ddltoBranch.SelectedValue.ToString() != string.Empty && txtPortOrigin.Text != string.Empty && txtPortShipment.Text !=string.Empty )
                {
                    Common_LC();
                }
                else
                {
                    Alert_msg("Select Ur Loacation ! ");
                }
            }
            else if (Rd_Convert.SelectedValue.ToString() == "C")
            {
                if (Working_Period == ddlWorkingPeriod.SelectedValue.ToString())
                {
                    Job_Copy("IMP_JOB_COPY");
                }
                else
                {
                    Job_Copy_Wrk("IMP_JOB_COPY_WORK_PERIOD");
                }
            }
            else if (Rd_Convert.SelectedValue.ToString() == "T")
            {
                Job_Transfer("IMP_JOB_TRANSFER");
            }
        }
        else
        {
            Alert_msg("Invaild Jobno!");
        }
    }
    private void Jobdup(string a1)
    {
        JD.OLD_JOBNO = ddlJobNo.SelectedValue.ToString();
        JD.JOBNO = txtCurrent_Job.Text;
        JD.DBS_Name = HD_DB_Name.Value.ToString();
        JD.Sp_name = a1;
        JD.JOB_PREFIX = txt_Prefix.Text;
        JD.JOB_SUFFIX = txt_Suffix.Text;

        JD.Ename = "Duplicate_Job";
        i = JD.Gen_Duplicate_Job();
        Alert_msg("Duplicate Job Created");

        Clear();
        if (ddlWorkingPeriod.SelectedValue.ToString() != string.Empty)
        {
            Load_Jobno(load_Con_String());
        }
    }
    private void Job_Copy(string a1)
    {
        JD.OLD_JOBNO = ddlJobNo.SelectedValue.ToString();
        JD.JOBNO = txtCurrent_Job.Text;
        JD.JOB_PREFIX = txt_Prefix.Text;
        JD.JOB_SUFFIX = txt_Suffix.Text;
        if (Connection.COMPANYID() == "247")
        {
            if (txt_Prefix.Text == string.Empty && txt_Suffix.Text != string.Empty)
            {
                JD.JOBNO_PS = txtCurrent_Job.Text + "/" + ((txt_Suffix.Text).TrimStart()).TrimEnd();
            }
            else if (txt_Prefix.Text != string.Empty && txt_Suffix.Text == string.Empty)
            {
                JD.JOBNO_PS = ((txt_Prefix.Text + txtCurrent_Job.Text).TrimEnd()).TrimStart();
            }
            else if (txt_Prefix.Text != string.Empty && txt_Suffix.Text != string.Empty)
            {
                JD.JOBNO_PS = ((txt_Prefix.Text + txtCurrent_Job.Text + "/" + txt_Suffix).TrimEnd()).TrimStart();
            }
            else if (txt_Prefix.Text == string.Empty && txt_Suffix.Text == string.Empty)
            {
                JD.JOBNO_PS = txtCurrent_Job.Text;
            }
        }
        else
        {
            if (txt_Prefix.Text == string.Empty && txt_Suffix.Text != string.Empty)
            {
                JD.JOBNO_PS = txtCurrent_Job.Text + "/" + ((txt_Suffix.Text).TrimStart()).TrimEnd();
            }
            else if (txt_Prefix.Text != string.Empty && txt_Suffix.Text == string.Empty)
            {
                JD.JOBNO_PS = ((txt_Prefix.Text + "/" + txtCurrent_Job.Text).TrimEnd()).TrimStart();
            }
            else if (txt_Prefix.Text != string.Empty && txt_Suffix.Text != string.Empty)
            {
                JD.JOBNO_PS = ((txt_Prefix.Text + "/" + txtCurrent_Job.Text + "/" + txt_Suffix.Text).TrimEnd()).TrimStart();
            }
            else if (txt_Prefix.Text == string.Empty && txt_Suffix.Text == string.Empty)
            {
                JD.JOBNO_PS = txtCurrent_Job.Text;
            }
        }

        JD.PORT_ORIGIN = txtPortOrigin.Text;
        JD.PORT_SHIPMENT = txtPortShipment.Text;
        JD.BRANCH_CODE = ddlFrom_Branch.SelectedValue.ToString();
        load_Cus_Mode();
        JD.DBS_Name = HD_DB_Name.Value.ToString();
        JD.Sp_name = a1;
        JD.Ename = "JobCopy";
        i = JD.Job_Copy();

        if (i == 1)
        {
            Alert_msg("Job Copyied Successfully"); 
        }
        else
        {
            Alert_msg("Job Not Copy."); 
        }
       

        Clear();
        if (ddlWorkingPeriod.SelectedValue.ToString() != string.Empty)
        {
            Load_Jobno(load_Con_String());
        }
    }
    private void Job_Copy_Wrk(string a1)
    {
        JD.OLD_JOBNO = ddlJobNo.SelectedValue.ToString();
        JD.JOBNO = txtCurrent_Job.Text;
        JD.BRANCH_CODE = ddlFrom_Branch.SelectedValue.ToString();
        load_Cus_Mode();
        JD.PORT_ORIGIN = txtPortOrigin.Text;
        JD.PORT_SHIPMENT = txtPortShipment.Text;
        JD.DBS_Name = HD_DB_Name.Value.ToString();
        JD.Sp_name = a1;
        i = JD.Job_Copy_Wrk();

        if (i == 1)
        {
            Alert_msg("Job Copyied Successfully");
        }
        else
        {
            Alert_msg("Job Not Copy.");
        }
        Clear();
        if (ddlWorkingPeriod.SelectedValue.ToString() != string.Empty)
        {
            Load_Jobno(load_Con_String());
        }
    }
    private void Job_Transfer(string a1)
    {
        string[] arr = new string[] { };
        string[] arr2 = new string[] { };

        arr = ddltoBranch.SelectedItem.ToString().Split('-');
        arr2 = ddltoBranch.SelectedValue .ToString().Split('-');

        JD.OLD_JOBNO = ddlJobNo.SelectedValue.ToString();
        JD.JOBNO = txtCurrent_Job.Text;

        JD.BRANCH_CODE = arr[1].ToString().Trim();
        JD.CUSTOMS_HOUSE = arr[0].ToString().Trim();
        JD.To_Tr_Mode = arr2[0].ToString().Trim();


        JD.JOB_PREFIX = txt_Prefix.Text;
        JD.JOB_SUFFIX = txt_Suffix.Text;
        if (Connection.COMPANYID() == "247")
        {
            if (txt_Prefix.Text == string.Empty && txt_Suffix.Text != string.Empty)
            {
                JD.JOBNO_PS = txtCurrent_Job.Text + "/" + ((txt_Suffix.Text).TrimStart()).TrimEnd();
            }
            else if (txt_Prefix.Text != string.Empty && txt_Suffix.Text == string.Empty)
            {
                JD.JOBNO_PS = ((txt_Prefix.Text + txtCurrent_Job.Text).TrimEnd()).TrimStart();
            }
            else if (txt_Prefix.Text != string.Empty && txt_Suffix.Text != string.Empty)
            {
                JD.JOBNO_PS = ((txt_Prefix.Text + txtCurrent_Job.Text + "/" + txt_Suffix).TrimEnd()).TrimStart();
            }
            else if (txt_Prefix.Text == string.Empty && txt_Suffix.Text == string.Empty)
            {
                JD.JOBNO_PS = txtCurrent_Job.Text;
            }
        }
        else
        {
            if (txt_Prefix.Text == string.Empty && txt_Suffix.Text != string.Empty)
            {
                JD.JOBNO_PS = txtCurrent_Job.Text + "/" + ((txt_Suffix.Text).TrimStart()).TrimEnd();
            }
            else if (txt_Prefix.Text != string.Empty && txt_Suffix.Text == string.Empty)
            {
                JD.JOBNO_PS = ((txt_Prefix.Text + "/" + txtCurrent_Job.Text).TrimEnd()).TrimStart();
            }
            else if (txt_Prefix.Text != string.Empty && txt_Suffix.Text != string.Empty)
            {
                JD.JOBNO_PS = ((txt_Prefix.Text + "/" + txtCurrent_Job.Text + "/" + txt_Suffix.Text).TrimEnd()).TrimStart();
            }
            else if (txt_Prefix.Text == string.Empty && txt_Suffix.Text == string.Empty)
            {
                JD.JOBNO_PS = txtCurrent_Job.Text;
            }
        }

        JD.PORT_ORIGIN = txtPortOrigin.Text;
        JD.PORT_SHIPMENT = txtPortShipment.Text;

        JD.Ename = "Job_Transfer";
        JD.Sp_name = a1;
        i = JD.Job_Transfer();

        if (i == 1)
        {
            Alert_msg("Job Transfered Successfully");
        }
        else
        {
            Alert_msg("Job Not Transfer.");
        }


        Clear();
        if (ddlWorkingPeriod.SelectedValue.ToString() != string.Empty)
        {
            Load_Jobno(load_Con_String());
        }
    }


    private void load_Cus_Mode()
    {
        if (Session["SELECT_TYPE"].ToString() != "Areawise Job")
        {
            DataSet ds = new DataSet();
            JD.Ename = "Cus_Code";
            ds = JD.Load_Company_Branch();
            if (ds.Tables[0].Rows.Count > 0)
            {
                //string[] arr2 = new string[] { };
                //arr2 = ddltoBranch.SelectedItem.Text.Split('-');
                
                    JD.CUSTOMS_HOUSE = ds.Tables[0].Rows[0][0].ToString();
                    JD.To_Tr_Mode = ds.Tables[0].Rows[0][1].ToString();
                 
                
            }
        }
        else
        {
            string[] arr2 = new string[] { };
            arr2 = ddltoBranch.SelectedValue.ToString().Split('-');
            JD.CUSTOMS_HOUSE = arr2[1].ToString().Trim();
            JD.To_Tr_Mode = arr2[0].ToString().Trim();
        }
    }
    private void Common_LC()
    {
        string[] arr = new string[] { };
        string[] arr2 = new string[] { };


        arr = ddltoBranch.SelectedItem.ToString().Split('-');
        arr2 = ddltoBranch.SelectedValue.ToString().Split('-');

        JD.JOBNO = ddlJobNo.SelectedValue.ToString();
        JD.CUSTOMS_HOUSE = arr[0].ToString().Trim();
        JD.PORT_ORIGIN = txtPortOrigin.Text;
        JD.PORT_SHIPMENT = txtPortShipment.Text;
        JD.To_Tr_Mode = arr2[0].ToString().Trim();
        JD.Branch_Common = SELECT_BRANCH;
        JD.JOB_PREFIX = txt_Prefix.Text;
        JD.JOB_SUFFIX = txt_Suffix.Text;
        JD.Sp_name = "IMP_JOB_LOCATION_CHANGE_COMMON";
        JD.Ename = "Location_Change_Common";
        i = JD.Common_Location_Change();

        if (i == 1)
        {
            Alert_msg("Location Changed Successfully");
        }
        else
        {
            Alert_msg("Invalid Job");
        }

        Clear();
        if (ddlWorkingPeriod.SelectedValue.ToString() != string.Empty)
        {
            Load_Jobno(load_Con_String());
        }
    }
    private void Load_Cus_House()
    {
        ddltoBranch.Items.Clear();
        DataSet ds = new DataSet();

        JD.Ename = "Load_Cus_House";
        JD.WORKING_PERIOD = ddlWorkingPeriod.SelectedValue.ToString();
        ds = JD.Load_Company_Branch();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddltoBranch.DataSource = ds.Tables[0];
            ddltoBranch.DataValueField = "CUSTOMHOUSE_CATEGORY";
            ddltoBranch.DataTextField = "PORT_OF_FILING";
            ddltoBranch.DataBind();
        }
        Add_Empty_To();
    }
    private void Load_Job_Process_Type()
    {
        if (SELECT_BRANCH != "")
        {
            Rd_Convert.Items.Add(new ListItem("Duplicate", "D"));
            Rd_Convert.Items.Add(new ListItem("Copy", "C"));
            Rd_Convert.Items.Add(new ListItem("Transfer", "T"));
            if (Session["SELECT_TYPE"].ToString() == "Areawise Job")
            {
                Rd_Convert.Items.Add(new ListItem("Location Change", "LC"));
            }
        }
        else
        {
            Rd_Convert.Items.Add(new ListItem("Duplicate", "D"));
            Rd_Convert.Items.Add(new ListItem("Location Change", "LC"));
        }
        Rd_Convert.SelectedValue = "D";
    }
    protected void Rd_Convert_SelectedIndexChanged(object sender, EventArgs e)
    {
         ddlWorkingPeriod.SelectedValue = Working_Period;
         if (Session["SELECT_TYPE"].ToString() != "Areawise Job")
         {
             ddlWorkingPeriod_SelectedIndexChanged(sender, e);
         }
         else

         {
             LoadGroup();
         }
         Load_Visible();

    }
    private void Load_Visible()
    {
        if (Rd_Convert.SelectedValue.ToString() == "D")
        {
            btnconvert.Visible = true;
            btnconvert.Text = "Duplicate";

            From_Branch.Visible = false;
            From_Grp.Visible = false;

            Part_1.Visible = false;
            To_Grp.Visible = false;
            Part_2.Visible = true;
            Part_3.Visible = false;
            Part_4.Visible = false;
            Part_5.Visible = false;

            ddlWorkingPeriod.Enabled = true;
        }
        else if (Rd_Convert.SelectedValue.ToString() == "C")
        {
            From_Branch.Visible = true;
            From_Grp.Visible = true;
            btnconvert.Visible = true;

            btnconvert.Text = "Copy";
            
            Part_1.Visible = false;
            To_Grp.Visible = false;
            ddlWorkingPeriod.Enabled = true;
            if (Session["SELECT_TYPE"].ToString() == "Areawise Job")
            {
                To_Grp.Visible = true;
                Part_1.Visible = true;
                ddlWorkingPeriod.Enabled = false;
                From_Branch.Visible = false;
            }

            Part_2.Visible = true;
            Part_3.Visible = true;
            Part_4.Visible = true;
            Part_5.Visible = false;
            
        }
        else if (Rd_Convert.SelectedValue.ToString() == "T")
        {
            ddlWorkingPeriod.Enabled = false;
            btnconvert.Visible = true;
            btnconvert.Text = "Transfer";
            From_Branch.Visible = false;
           

            if (Session["SELECT_TYPE"].ToString() == "Areawise Job")
            {
                From_Grp.Visible = true;
                To_Grp.Visible = true;
                Part_1.Visible = true;
                ddlWorkingPeriod.Enabled = false;
                From_Branch.Visible = false;
            }


            Part_1.Visible = true;
            To_Grp.Visible = true;
            Part_2.Visible = true;
            Part_3.Visible = true;
            Part_4.Visible = true;
            Part_5.Visible = true;

            load_Current_Location();
        }
        else if (Rd_Convert.SelectedValue.ToString() == "LC")
        {
            btnconvert.Visible = true;
            btnconvert.Text = "Location Change";

            Part_1.Visible = true;
            To_Grp.Visible = false;  //on 3-april-2020
            //Part_2.Visible = false; // hide in 16-07-2024
            Part_2.Visible = true;
            Part_3.Visible = true;
            Part_4.Visible = true;
            Part_5.Visible = true;
            ddlWorkingPeriod.Enabled = false;
            if (Session["SELECT_TYPE"].ToString() == "Areawise Job")
            {
                ddlToGrp.Items.Insert(0, new ListItem(Session["GroupName"].ToString(), Session["GroupID"].ToString()));
                ddlToGrp.Enabled = false;
                Load_Group_Branch(ddlFromGrp.SelectedValue.ToString(), ddltoBranch); // here right side branch loading
            }
            else
            {
                Load_Cus_House();
            }
        }
        else
        {
            btnconvert.Visible = false;
            btnconvert.Text = "";

            Part_1.Visible = false;
            To_Grp.Visible = false;
            Part_2.Visible = false;
            Part_3.Visible = false;
            Part_4.Visible = false;
            Part_5.Visible = false;
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'JOB DUPLICATE', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    //----------------------------------------------------------------

    private void load_Current_Location()
    {
        ddltoBranch.Items.Clear();
        DataSet ds = new DataSet();
        if (Session["SELECT_TYPE"].ToString() != "Areawise Job")
        {
            JD.Ename = "Load_Current_Cus_House";
            JD.WORKING_PERIOD = ddlWorkingPeriod.SelectedValue.ToString();
            ds = JD.Load_Company_Branch();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddltoBranch.DataSource = ds.Tables[0];
                ddltoBranch.DataValueField = "CUSTOMHOUSE_CATEGORY";
                ddltoBranch.DataTextField = "PORT_OF_FILING";
                ddltoBranch.DataBind();
            }
            Add_Empty_To();
        }
    }

  
    private void Add_Empty_From()
    {
        ddlFrom_Branch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlFrom_Branch.SelectedIndex = 0;
    }
    private void Add_Empty_To()
    {
        ddltoBranch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddltoBranch.SelectedIndex = 0;
    }
    private void Add_Empty_Jobno()
    {
        ddlJobNo.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlJobNo.SelectedIndex = 0;
    }
    
    protected void ddlFrom_Branch_SelectedIndexChanged(object sender, EventArgs e)
    {
        string DB_Connection = string.Empty;
        ddlJobNo.Items.Clear();

        if (ddlFrom_Branch.SelectedValue.ToString() != string.Empty)
        {
            DB_Connection = load_Con_String();
            JD.BRANCH_CODE = ddlFrom_Branch.SelectedValue.ToString();
            JD.JOBNO = ddlJobNo.SelectedValue.ToString();
            JD.Ename = "IMP_JOBNO_COPY_SELECT";
            ds = JD.Select_Job_No(DB_Connection, "Import");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlJobNo.DataSource = ds.Tables[0];
                ddlJobNo.DataValueField = "JOBNO";
                ddlJobNo.DataTextField = "JOBNO_PS";
                ddlJobNo.DataBind();
            }
            Add_Empty_Jobno();
        }
        else
        {
            Clear();
        }
        if (Rd_Convert.SelectedValue.ToString() == "C")
        {
            hdfTransport_mode.Value = Connection.Get_Tr_Mode();
        }
        else
        {
            hdfTransport_mode.Value = "";
        }
    }

    private void PortOrigin_Shipment_enable_disable()
    {
        string[] arr2 = new string[] { };
        string[] arr3 = new string[] { };

        if (Rd_Convert.SelectedValue.ToString() == "LC" || Rd_Convert.SelectedValue.ToString() == "T" || Rd_Convert.SelectedValue.ToString() == "C")  // by jayanthi on 8-apr-2020
        {
            arr3 = ddltoBranch.SelectedValue.ToString().Split('-');
            hdfTransport_mode.Value = arr3[0].ToString().Trim();
            lbl_To_Tr_mode.Text = arr3[0].ToString().Trim();
        }

        if (Rd_Convert.SelectedValue.ToString() == "LC" || Rd_Convert.SelectedValue.ToString() == "T" || Rd_Convert.SelectedValue.ToString() == "C") // include copy by jayanthi on 8-apr-2020
        {
            if (txt_Tr_Mode.Text != lbl_To_Tr_mode.Text)
            {
                if (txt_Tr_Mode.Text == "Sea" && lbl_To_Tr_mode.Text == "Land")
                {
                    txtPortOrigin.Text = txt_Oportorgin.Text;
                    txtPortShipment.Text = txt_OPortShipment.Text;
                }
                else if (txt_Tr_Mode.Text == "Land" && lbl_To_Tr_mode.Text == "Sea")
                {
                    txtPortOrigin.Text = txt_Oportorgin.Text;
                    txtPortShipment.Text = txt_OPortShipment.Text;
                }
                else
                {
                    txtPortOrigin.Text = string.Empty;
                    txtPortShipment.Text = string.Empty;
                }
            }
            else
            {
                txtPortOrigin.Text = txt_Oportorgin.Text;
                txtPortShipment.Text = txt_OPortShipment.Text;
            }
        }
        else
        {
            txtPortOrigin.Text = string.Empty;
            txtPortShipment.Text = string.Empty;
        }

    }

    protected void ddltoBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        string[] arr2 = new string[] { };
        string[] arr3 = new string[] { };

        if (Rd_Convert.SelectedValue.ToString() == "LC" || Rd_Convert.SelectedValue.ToString() == "T" || Rd_Convert.SelectedValue.ToString() == "C")  // by jayanthi on 8-apr-2020
        {
            arr3 = ddltoBranch.SelectedValue.ToString().Split('-');
            hdfTransport_mode.Value = arr3[0].ToString().Trim();
            lbl_To_Tr_mode.Text = arr3[0].ToString().Trim();
        }

        PortOrigin_Shipment_enable_disable();
        
        
        //if (ddltoBranch.SelectedValue.ToString() != string.Empty && Rd_Convert.SelectedValue.ToString() == "T")//--hide on 15-07-2024 
        if (ddltoBranch.SelectedValue.ToString() != string.Empty && (Rd_Convert.SelectedValue.ToString() == "T" || Rd_Convert.SelectedValue.ToString() == "C" || Rd_Convert.SelectedValue.ToString() == "LC"))
        {
            arr2 = ddltoBranch.SelectedItem.Text.Split('-');
            Transaction Transact = new Transaction();
            Transact.BRANCH_CODE = arr2[1].ToString().Trim();
            Transact.WORKING_PERIOD = Working_Period;

            if (Rd_Convert.SelectedValue.ToString() == "LC")
            {
                txtCurrent_Job.Text = ddlJobNo.SelectedValue.ToString();
            }
            else
            {
                txtCurrent_Job.Text = Convert.ToString(Transact.RetrieveID());
            }

            //-----------------------------------------------------------
            Admin_job_Prefix_Suffix JPS = new Admin_job_Prefix_Suffix();
            DataSet dats = new DataSet();
            JPS.Branch = arr2[1].ToString().Trim();
            JPS.Ename = "Imp_gen_select";
            //JPS.Tr_mode = txt_Tr_Mode.Text;
            JPS.Tr_mode = lbl_To_Tr_mode.Text;
            JPS.BranchType = SELECT_TYPE;

            //dats = JPS.Job_prefix_Suffix_Select();//--hide on 16-07-2024 
            dats = JPS.Job_prefix_Suffix_Select_Areawise();

          
            if (dats.Tables[0].Rows.Count > 0)
            {
                txt_Prefix.Text = dats.Tables[0].Rows[0][0].ToString();
                txt_Suffix.Text = dats.Tables[0].Rows[0][1].ToString();
            }
            else
            {
                txt_Prefix.Text = string.Empty;
                txt_Suffix.Text = string.Empty;
            }
        }

    }
}