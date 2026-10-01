using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;
using System.Data.SqlClient;

public partial class Exp_Branch_to_Branch : ThemeClass
{
    public string Working_Period, Company_ID, SELECT_BRANCH, DB_CONN, COMP_WORKING_PERIOD, DB_NAME, SELECT_TYPE;    
    AppSession aps = new AppSession();
    Exp_Job_Duplicate JD = new Exp_Job_Duplicate();
    Global_variables ObjUBO = new Global_variables();
    Export_General_New Export = new Export_General_New();
    Company_Master Comp = new Company_Master();
    DataSet ds = new DataSet();

    public string COMPANY_ID, flag;
    private int i;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        Working_Period = Connection.WorkingPeriod();
        Company_ID = Connection.COMPANYID();
        SELECT_BRANCH = Connection.Get_Company_Type();
        SELECT_TYPE = Session["SELECT_TYPE"].ToString();
       
        if (!IsPostBack)
        {
            if (Request.QueryString["Jobno"] == "E")
            {
                Load_Job_Process_Type();
                Close.Visible = true;
                txtCurrent_Job.Attributes.Add("readonly", "readonly");               
                Load_Visible();
                LoadFinancialYear();
            }
        }
    }

    /*public void LoadFinancialYear()
    {
        DataSet ds = new DataSet();
        ObjUBO.A2 = Connection.WorkingPeriod();
        ObjUBO.A3 = "Company_Wrk_Select";
        ds = JD.Load_Company_Branch(ObjUBO);
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
            Load_Jobno_groupbased(hdn_Server.Value);
        }
        else
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                Load_Jobno(ds.Tables[1].Rows[0][0].ToString());
            }
        }
    }*/

    public void LoadFinancialYear()
    {
        DataSet ds = new DataSet();
        ObjUBO.A2 = Connection.WorkingPeriod();
        ObjUBO.A3 = "Company_Wrk_Select";
        ds = JD.Load_Company_Branch(ObjUBO);

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
        // AUTO-SELECT EXPORT JOB FROM GRID
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
        // -----------------------------------------------
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
    private void Load_Visible()
    {
        if (Rd_Convert.SelectedValue.ToString() == "D")
        {
            btnconvert.Visible = true;
            btnconvert.Text = "Duplicate";
            From_Branch.Visible = false;
            From_Grp.Visible = false;
            Part_1.Visible = false;
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
            ddlWorkingPeriod.Enabled = true;
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
            //Part_2.Visible = false;//hide on 16-07-2024
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
    private void load_Current_Location()
    {
        ddltoBranch.Items.Clear();
        DataSet ds = new DataSet();
        if (Session["SELECT_TYPE"].ToString() != "Areawise Job")
        {
            ObjUBO.A2 = ddlWorkingPeriod.SelectedValue.ToString();
            ObjUBO.A3 = "Load_Current_Cus_House";
            ds = JD.Load_Company_Branch(ObjUBO);
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
    private void Add_Empty_To()
    {
        ddltoBranch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddltoBranch.SelectedIndex = 0;
    }
    private void Load_Cus_House()
    {
        ddltoBranch.Items.Clear();
        DataSet ds = new DataSet();
        ObjUBO.A2 = ddlWorkingPeriod.SelectedValue.ToString();
        ObjUBO.A3 = "Load_Cus_House";
        ds = JD.Load_Company_Branch(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddltoBranch.DataSource = ds.Tables[0];
            ddltoBranch.DataValueField = "CUSTOMHOUSE_CATEGORY";
            ddltoBranch.DataTextField = "PORT_OF_FILING";
            ddltoBranch.DataBind();
        }
        Add_Empty_To();
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
            else if (Session["SELECT_TYPE"].ToString() == "Areawise Job")
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

    private void Load_Jobno(string Con_String)
    {
        DataSet ds = new DataSet();
        DB_CONN = Con_String;
        ObjUBO.A4 = "EXP_JOBNO_SELECT";
        ds = JD.Select_Job_No(DB_CONN, ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlJobNo.DataSource = ds.Tables[0];
            ddlJobNo.DataValueField = "JOBNO";
            ddlJobNo.DataTextField = "JOBNO_PS";
            ddlJobNo.DataBind();
        }
        Add_Empty_Jobno();
    }

    private void Load_Jobno_groupbased(string Con_String)
    {
        ddlJobNo.Items.Clear();
        DataSet ds = new DataSet();
        DB_CONN = Con_String;
        if (ddlFromGrp.SelectedValue.ToString() != "")
        {
            ObjUBO.A2 = ddlFromGrp.SelectedValue.ToString();
            
        }
        else
        {
            ObjUBO.A2 = Session["GroupID"].ToString();
        }
        ObjUBO.A4 = "EXP_JOBNO_SELECT_WITHIN_GRP";
        
        ds = JD.Select_Job_No(DB_CONN, ObjUBO);

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

    private void Add_Empty_Jobno()
    {
        ddlJobNo.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlJobNo.SelectedIndex = 0;
    }
    private string load_Con_String()
    {
        HD_DB_Name.Value = string.Empty;
        string server_path = string.Empty;

        ObjUBO.A2 = ddlWorkingPeriod.SelectedValue.ToString();
        ObjUBO.A3 = "Company_Wrk_Select";
        ds = JD.Load_Company_Branch(ObjUBO);
        if (ds.Tables[1].Rows.Count > 0)
        {
            server_path = ds.Tables[1].Rows[0][0].ToString();
            HD_DB_Name.Value = ds.Tables[1].Rows[0][1].ToString();
        }
        return server_path;
    }
    protected void ddlFrom_Branch_SelectedIndexChanged(object sender, EventArgs e)
    {
        string DB_Connection = string.Empty;
        ddlJobNo.Items.Clear();
        if (ddlFrom_Branch.SelectedValue.ToString() != string.Empty)
        {
            DB_Connection = load_Con_String();
            ObjUBO.A1 = ddlJobNo.SelectedValue.ToString();
            ObjUBO.A3 = ddlFrom_Branch.SelectedValue.ToString();
            ObjUBO.A4 = "EXP_JOBNO_COPY_SELECT";
            ds = JD.Select_Job_No(DB_Connection, ObjUBO);

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
    private void Load_Branch_Copy_Location(string Con_String)
    {
        ddlJobNo.Items.Clear();
        ddlFrom_Branch.Items.Clear();
        DataSet ds = new DataSet();
        ObjUBO.A2 = ddlWorkingPeriod.SelectedValue.ToString();
        ObjUBO.A3 = "Copy_Location";
        ds = JD.Load_Company_Branch(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlFrom_Branch.DataSource = ds.Tables[0];
            ddlFrom_Branch.DataValueField = "BRANCH";
            ddlFrom_Branch.DataTextField = "BRANCH";
            ddlFrom_Branch.DataBind();
        }
        Add_Empty_From();
    }
    private void Add_Empty_From()
    {
        ddlFrom_Branch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlFrom_Branch.SelectedIndex = 0;
    }
    private void Clear()
    {
        txtExporterName.Text = string.Empty;
        txtCustoms_House.Text = string.Empty;
        txtjobdate.Text = string.Empty;
        txtNoof_Inv.Text = string.Empty;
        txtnoofItems.Text = string.Empty;
        txt_Tr_Mode.Text = string.Empty;

        txt_OPortDischarge .Text = string.Empty;
        txt_OPortFinalDestination .Text = string.Empty;
        txtPortDischarge.Text = string.Empty;
        txtPortFinalDestination.Text = string.Empty;

        txtCurrent_Job.Text = string.Empty;
        txt_Prefix.Text = string.Empty;
        txt_Suffix.Text = string.Empty;
        lbl_To_Tr_mode.Text = string.Empty;
    }

    protected void ddlToGrp_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Group_Branch(ddlToGrp.SelectedValue.ToString(), ddltoBranch);
    }
    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear();
        ObjUBO.A2 = "";
        DataSet ds = new DataSet();
        if (ddlJobNo.SelectedValue.ToString() != string.Empty)
        {
            DB_CONN = load_Con_String();
            if (Rd_Convert.SelectedValue.ToString() == "C")
            {
                if (Session["SELECT_TYPE"].ToString() == "Areawise Job")
                {
                    ObjUBO.A2 = ddlFromGrp.SelectedValue.ToString();
                    ObjUBO.A3 = ddlFromGrp.SelectedValue.ToString();
                    ObjUBO.A1 = ddlJobNo.SelectedValue.ToString();
                    ObjUBO.A4 = "EXP_Branch_Jobno_Select_FromGroup";
                    ds = JD.Select_Job_No(DB_CONN, ObjUBO);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        ddlFrom_Branch.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["BRANCHCODE"].ToString(), ds.Tables[0].Rows[0]["BRANCHCODE"].ToString()));
                    }

                }
                else
                {
                    if (ddlFrom_Branch.SelectedValue.ToString() != string.Empty)
                    {
                        ObjUBO.A1 = ddlJobNo.SelectedValue.ToString();
                        ObjUBO.A3 = ddlFrom_Branch.SelectedValue.ToString();
                        ObjUBO.A4 = "EXP_Branch_Jobno_Select";
                        ds = JD.Select_Job_No(DB_CONN, ObjUBO);
                    }
                    else
                    {
                        Clear();
                    }
                }
            }
            else
            {
                ObjUBO.A1 = ddlJobNo.SelectedValue.ToString();
                ObjUBO.A4 = "EXP_JOBNO_DATA_SELECT";
                ds = JD.Select_Job_No(DB_CONN, ObjUBO);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                Show_Data(ds);
                //-----------------------------------------------------------
                if (Rd_Convert.SelectedValue.ToString() != "T")
                {
                   // Transaction Transact = new Transaction();
                    
                    Export.BRANCH_CODE = SELECT_BRANCH;
                    Export.WORKING_PERIOD = Working_Period;
                    txtCurrent_Job.Text =  Convert.ToString(Export.Retrieve_JobNO());
                    //Convert.ToString(Transact.RetrieveID());
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
                    JPS.Ename = "Exp_gen_select";
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
                    //JD.Ename = "Load_Cus_House_LC";
                    //JD.SELECT_BRANCH_CODE = txtCustoms_House.Text;
                    //dds = JD.Load_Company_Branch();
                    
                    ObjUBO.A1 = txtCustoms_House.Text;
                    ObjUBO.A3 = "Load_Cus_House_LC";
                    dds = JD.Load_Company_Branch(ObjUBO);

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
        txtExporterName.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
        txtCustoms_House.Text = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
        txtjobdate.Text = ds.Tables[0].Rows[0]["JOBDATE"].ToString();
        txtNoof_Inv.Text = ds.Tables[0].Rows[0]["No_of_Inv"].ToString();
        txtnoofItems.Text = ds.Tables[0].Rows[0]["No_Of_item"].ToString();
        txt_Tr_Mode.Text = ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();

        txt_OPortDischarge.Text = ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString();
        txt_OPortFinalDestination.Text = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
        txtPortDischarge.Text = ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString();
        txtPortFinalDestination.Text = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
    }
    protected void ddltoBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        string[] arr2 = new string[] { };
        string[] arr3 = new string[] { };

        //txtPortDischarge.Text = string.Empty;
        //txtPortFinalDestination.Text = string.Empty;

        if (Rd_Convert.SelectedValue.ToString() == "LC" || Rd_Convert.SelectedValue.ToString() == "T" || Rd_Convert.SelectedValue.ToString() == "C")  // by jayanthi on 8-apr-2020
        {
            arr3 = ddltoBranch.SelectedValue.ToString().Split('-');
            hdfTransport_mode.Value = arr3[0].ToString().Trim();
            lbl_To_Tr_mode.Text = arr3[0].ToString().Trim();
        }

        if (Rd_Convert.SelectedValue.ToString() == "LC" || Rd_Convert.SelectedValue.ToString() == "T" || Rd_Convert.SelectedValue.ToString() == "C")
        {
            if (txt_Tr_Mode.Text != lbl_To_Tr_mode.Text)
            {
                if (txt_Tr_Mode.Text == "Sea" && lbl_To_Tr_mode.Text == "Land")
                {
                    txtPortDischarge.Text = txt_OPortDischarge.Text;
                    txtPortFinalDestination.Text = txt_OPortFinalDestination.Text;
                }
                else if (txt_Tr_Mode.Text == "Land" && lbl_To_Tr_mode.Text == "Sea")
                {
                    txtPortDischarge.Text = txt_OPortDischarge.Text;
                    txtPortFinalDestination.Text = txt_OPortFinalDestination.Text;
                }
                else
                {
                    txtPortDischarge.Text = string.Empty;
                    txtPortFinalDestination.Text = string.Empty;
                }
            }
            else
            {
                txtPortDischarge.Text = txt_OPortDischarge.Text;
                txtPortFinalDestination.Text = txt_OPortFinalDestination.Text;
            }
        }
        else
        {
            txtPortDischarge.Text = string.Empty;
            txtPortFinalDestination.Text = string.Empty;
        }

       // if (ddltoBranch.SelectedValue.ToString() != string.Empty && Rd_Convert.SelectedValue.ToString() == "T")//--hide on 15-07-2024 
        if (ddltoBranch.SelectedValue.ToString() != string.Empty && (Rd_Convert.SelectedValue.ToString() == "T" || Rd_Convert.SelectedValue.ToString() == "C" || Rd_Convert.SelectedValue.ToString() == "LC"))
        {
            arr2 = ddltoBranch.SelectedItem.Text.Split('-');
            Export.BRANCH_CODE = arr2[1].ToString().Trim();
            Export.WORKING_PERIOD = Working_Period;

            if (Rd_Convert.SelectedValue.ToString() == "LC")
            {
                txtCurrent_Job.Text = ddlJobNo.SelectedValue.ToString();
            }
            else
            {
                txtCurrent_Job.Text = Convert.ToString(Export.Retrieve_JobNO());
            }

            //-----------------------------------------------------------
            Admin_job_Prefix_Suffix JPS = new Admin_job_Prefix_Suffix();
            DataSet dats = new DataSet();
            JPS.Branch = arr2[1].ToString().Trim(); //Co Trmode
            JPS.Ename = "Exp_gen_select";
            JPS.BranchType = SELECT_TYPE;
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

        if (Rd_Convert.SelectedValue.ToString() == "LC")
        {
            arr3 = ddltoBranch.SelectedValue.ToString().Split('-');
            hdfTransport_mode.Value = arr3[0].ToString().Trim();
            lbl_To_Tr_mode.Text = arr3[0].ToString().Trim();
        }
        else if (Rd_Convert.SelectedValue.ToString() == "T")
        {
            arr3 = ddltoBranch.SelectedValue.ToString().Split('-');
            hdfTransport_mode.Value = arr3[0].ToString().Trim();
            lbl_To_Tr_mode.Text = arr3[0].ToString().Trim();
        }

       
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
                        Jobdup("GENERATE_EXPORT_DUPLICATE_JOB");
                    }
                    else
                    {
                        Jobdup("GENERATE_EXPORT_DUPLICATE_JOB_WORK_PERIOD");
                    }
                }
            }
            else if (Rd_Convert.SelectedValue.ToString() == "LC")
            {
                if (ddltoBranch.SelectedValue.ToString() != string.Empty && txtPortDischarge.Text != string.Empty && txtPortFinalDestination.Text != string.Empty)
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
                    Job_Copy("EXP_JOB_COPY");
                }
                else
                {
                    Job_Copy_Wrk("EXP_JOB_COPY_WORK_PERIOD");
                }
            }
            else if (Rd_Convert.SelectedValue.ToString() == "T")
            {
                Job_Transfer("EXP_JOB_TRANSFER");
            }
        }
        else
        {
            Alert_msg("Invaild Jobno!");
        }
    }

    private void Jobdup(string a1)
    {
        ObjUBO.A1 = ddlJobNo.SelectedValue.ToString();
        ObjUBO.A2 = txtCurrent_Job.Text;
        ObjUBO.A4 = "Duplicate_Job";
        ObjUBO.A5 = HD_DB_Name.Value.ToString();
        ObjUBO.A6 = txt_Prefix.Text;
        ObjUBO.A7 = txt_Suffix.Text;

        ObjUBO.A10 = a1;

        i = JD.Generate_Duplicate_Job(ObjUBO);
        if (i == 1)
        {
            Alert_msg("Duplicate Job Created");
        }
        else
        {
            Alert_msg("Duplicate Job Not Create!");
        }
        Clear();
        if (ddlWorkingPeriod.SelectedValue.ToString() != string.Empty)
        {
            Load_Jobno(load_Con_String());
        }
    }

    private void Common_LC()
    {
        string[] arr = new string[] { };
        string[] arr2 = new string[] { };

        arr = ddltoBranch.SelectedItem.ToString().Split('-');
        arr2 = ddltoBranch.SelectedValue.ToString().Split('-');

        ObjUBO.A1 = ddlJobNo.SelectedValue.ToString();
        ObjUBO.A2 = arr[0].ToString().Trim();
        ObjUBO.A3 = txtPortDischarge.Text;
        ObjUBO.A4 = txtPortFinalDestination.Text;
        ObjUBO.A5 = arr2[0].ToString().Trim();
        ObjUBO.A6 = "Location_Change_Common";
        ObjUBO.A7 = arr[1].ToString().Trim();
        ObjUBO.A8 = txt_Prefix.Text;
        ObjUBO.A9 = txt_Suffix.Text;
        ObjUBO.A10 = "EXP_JOB_LOCATION_CHANGE_COMMON";

        i = JD.Common_Location_Change(ObjUBO);

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
    private void Job_Copy(string a1)
    {
        ObjUBO.A1 = ddlJobNo.SelectedValue.ToString();
        ObjUBO.A2 = txtCurrent_Job.Text;
        
        ObjUBO.A4 = txt_Suffix.Text;

        if (Connection.COMPANYID() == "247")
        {
            if (txt_Prefix.Text == string.Empty && txt_Suffix.Text != string.Empty)
            {
                ObjUBO.A5 = txtCurrent_Job.Text + "/" + ((txt_Suffix.Text).TrimStart()).TrimEnd();
            }
            else if (txt_Prefix.Text != string.Empty && txt_Suffix.Text == string.Empty)
            {
                ObjUBO.A5 = ((txt_Prefix.Text + txtCurrent_Job.Text).TrimEnd()).TrimStart();
            }
            else if (txt_Prefix.Text != string.Empty && txt_Suffix.Text != string.Empty)
            {
                ObjUBO.A5 = ((txt_Prefix.Text + txtCurrent_Job.Text + "/" + txt_Suffix).TrimEnd()).TrimStart();
            }
            else if (txt_Prefix.Text == string.Empty && txt_Suffix.Text == string.Empty)
            {
                ObjUBO.A5 = txtCurrent_Job.Text;
            }
        }
        else
        {
            if (txt_Prefix.Text == string.Empty && txt_Suffix.Text != string.Empty)
            {
                ObjUBO.A5 = txtCurrent_Job.Text + "/" + ((txt_Suffix.Text).TrimStart()).TrimEnd();
            }
            else if (txt_Prefix.Text != string.Empty && txt_Suffix.Text == string.Empty)
            {
                ObjUBO.A5 = ((txt_Prefix.Text + "/" + txtCurrent_Job.Text).TrimEnd()).TrimStart();
            }
            else if (txt_Prefix.Text != string.Empty && txt_Suffix.Text != string.Empty)
            {
                ObjUBO.A5 = ((txt_Prefix.Text + "/" + txtCurrent_Job.Text + "/" + txt_Suffix.Text).TrimEnd()).TrimStart();
            }
            else if (txt_Prefix.Text == string.Empty && txt_Suffix.Text == string.Empty)
            {
                ObjUBO.A5 = txtCurrent_Job.Text;
            }
        }

        ObjUBO.A8 = txtPortDischarge.Text;
        ObjUBO.A9 = txtPortFinalDestination.Text;

        ObjUBO.A10 = ddlFrom_Branch.SelectedValue.ToString();
        load_Cus_Mode();
        ObjUBO.A3 = txt_Prefix.Text;
        ObjUBO.A11 = "JobCopy";
        ObjUBO.A12 = HD_DB_Name.Value.ToString();
        ObjUBO.A13 = a1;
        i = JD.Job_Copy(ObjUBO);

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
    private void load_Cus_Mode()
    {
        DataSet ds = new DataSet();
        ObjUBO.A3 = "Cus_Code"; 
        ds = JD.Load_Company_Branch(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ObjUBO.A6= ds.Tables[0].Rows[0][0].ToString();
            ObjUBO.A7 = ds.Tables[0].Rows[0][1].ToString();
        }
    }

    private void Job_Copy_Wrk(string a1)
    {
        ObjUBO.A1 = ddlJobNo.SelectedValue.ToString();
        ObjUBO.A2 = txtCurrent_Job.Text;
        ObjUBO.A7 = ddlFrom_Branch.SelectedValue.ToString();
        load_Cus_Mode();
        ObjUBO.A5 = txtPortDischarge.Text;
        ObjUBO.A6 = txtPortFinalDestination.Text;
        ObjUBO.A8 = HD_DB_Name.Value.ToString();
        ObjUBO.A10 = a1;
        i = JD.Job_Copy_Wrk(ObjUBO);
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
        arr2 = ddltoBranch.SelectedValue.ToString().Split('-');

        ObjUBO.A1 = ddlJobNo.SelectedValue.ToString();
        ObjUBO.A2 = txtCurrent_Job.Text;
        ObjUBO.A3 = arr[1].ToString().Trim();
        ObjUBO.A4 = arr[0].ToString().Trim();
        ObjUBO.A5 = arr2[0].ToString().Trim();

        ObjUBO.A7 = txt_Prefix.Text;
        ObjUBO.A8 = txt_Suffix.Text;
        if (Connection.COMPANYID() == "247")
        {
            if (txt_Prefix.Text == string.Empty && txt_Suffix.Text != string.Empty)
            {
                ObjUBO.A6 = txtCurrent_Job.Text + "/" + ((txt_Suffix.Text).TrimStart()).TrimEnd();
            }
            else if (txt_Prefix.Text != string.Empty && txt_Suffix.Text == string.Empty)
            {
                ObjUBO.A6 = ((txt_Prefix.Text + txtCurrent_Job.Text).TrimEnd()).TrimStart();
            }
            else if (txt_Prefix.Text != string.Empty && txt_Suffix.Text != string.Empty)
            {
                ObjUBO.A6 = ((txt_Prefix.Text + txtCurrent_Job.Text + "/" + txt_Suffix).TrimEnd()).TrimStart();
            }
            else if (txt_Prefix.Text == string.Empty && txt_Suffix.Text == string.Empty)
            {
                ObjUBO.A6 = txtCurrent_Job.Text;
            }
        }
        else
        {
            if (txt_Prefix.Text == string.Empty && txt_Suffix.Text != string.Empty)
            {
                ObjUBO.A6 = txtCurrent_Job.Text + "/" + ((txt_Suffix.Text).TrimStart()).TrimEnd();
            }
            else if (txt_Prefix.Text != string.Empty && txt_Suffix.Text == string.Empty)
            {
                ObjUBO.A6 = ((txt_Prefix.Text + "/" + txtCurrent_Job.Text).TrimEnd()).TrimStart();
            }
            else if (txt_Prefix.Text != string.Empty && txt_Suffix.Text != string.Empty)
            {
                ObjUBO.A6 = ((txt_Prefix.Text + "/" + txtCurrent_Job.Text + "/" + txt_Suffix.Text).TrimEnd()).TrimStart();
            }
            else if (txt_Prefix.Text == string.Empty && txt_Suffix.Text == string.Empty)
            {
                ObjUBO.A6 = txtCurrent_Job.Text;
            }
        }
        ObjUBO.A9 = txtPortDischarge.Text;
        ObjUBO.A10 = txtPortFinalDestination.Text; 
        ObjUBO.A11 = "Job_Transfer";
        ObjUBO.A13 = a1;
        i = JD.Job_Transfer(ObjUBO);
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

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Export Job', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}