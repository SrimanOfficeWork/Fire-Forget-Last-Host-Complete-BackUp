using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Export_Annexure_C_Sea_Package : ThemeClass
{
    Transaction Transact = new Transaction();
    AppSession aps = new AppSession();

    public string currentuser ,currentbranch ,Working_Period,SELECT_BRANCH;
    public int i;

    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Connection.Current_User();
        currentbranch = Connection.Current_Branch();
        Working_Period = Connection.WorkingPeriod(); 
        SELECT_BRANCH = Connection.Get_Company_Type();

        if (!IsPostBack)
        {
            Load_BE_No();
            if (Request.QueryString["EXBND_JOBID"] != "" && Request.QueryString["EXBND_JOBID"] != null)
           {
               if (Request.QueryString["EXBND_JOBID"] == "warehouse")
               {
                   DataTable dt = new DataTable();
                   Load_Company_Branch();

                   AUTO_JOBNO();
                   Warehouse_Id.Style.Add("display", "Block");
                   Exbond_Id.Style.Add("display", "none");
                   btn_warehose.Style.Add("display", "Block");
                   btn_exbond.Style.Add("display", "none");
                   btnCancel_warehouse.Style.Add("display", "Block");
                   btnCancel_exbond.Style.Add("display", "none");
                   Session.Remove("EXBND_JOBID");
                   dropdown_bind();

                   gvAll.DataSource = dt;//add empty row
                   gvAll.DataBind();
                   gvSelected.DataSource = dt;//add empty row
                   gvSelected.DataBind();

               }
               else
               {

                   Warehouse_Id.Style.Add("display", "none");
                   Exbond_Id.Style.Add("display", "Block");
                   btn_warehose.Style.Add("display", "none");
                   btn_exbond.Style.Add("display", "Block");
                   btnCancel_warehouse.Style.Add("display", "none");
                   btnCancel_exbond.Style.Add("display", "Block");
                   if (Request.QueryString["EXBND_JOBID"] != "" && Request.QueryString["EXBND_JOBID"] != null && Request.QueryString["EXBND_JOBID"] != "warehouse")
                   {
                       Session.Remove("EXBND_JOBID");
                       Session["EXBND_JOBID"] = Request.QueryString["EXBND_JOBID"].ToString();
                   }
                   else
                   {
                       Session.Remove("EXBND_JOBID");
                       Session["EXBND_JOBID"] = txtExbond_JobNo.Text;
                   }
                   ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>document.getElementById('page-1').style.display = 'none';document.getElementById('page-2').style.display = 'Block';document.getElementById('annexureCSea_EXbond_Iframe').src = '../Transaction/Ex-Bond_Details.aspx';</script>", false);

               }

            }
        }
    }
    public string USER_CREATION_ID, BRANCH, BRANCH_ID;
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
            USER_CREATION_ID = Session["USER_CREATION_ID"].ToString();
            BRANCH_ID = "0";
            User.COMPANY_ID = Connection.COMPANYID(); 
            User.USER_CREATION_ID = USER_CREATION_ID;
            User.USER_BRANCHID = BRANCH_ID;
            User.BRANCH = BRANCH;

            User.flag = "Select_Branch_Details";
            DataSet ds_userbranch = new DataSet();

            ds_userbranch = User.RetrieveAll_Branch_Details(HttpContext.Current.Session["currentcomp_db"].ToString());

            if (ds_branch.Tables[1].Rows.Count > 0)
            {
                BranchDetails Branch2 = new BranchDetails();
                Branch2.CountryId = currentbranch;
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
                    //DataTable table1 = view1.ToTable();
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
                            //DataTable table1 = view1.ToTable();
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
              
                ddltoBranch.DataSource = details.ToArray();
                ddltoBranch.DataValueField = "CountryId";
                ddltoBranch.DataTextField = "CountryName";
                ddltoBranch.DataBind();
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
    public void AUTO_JOBNO()
    {
        if (SELECT_BRANCH != string.Empty)
        {
            Transact.WORKING_PERIOD = Working_Period;
            Transact.BRANCH_CODE = SELECT_BRANCH == ddltoBranch.SelectedValue.ToString() ? SELECT_BRANCH : ddltoBranch.SelectedValue.ToString();
            Session.Remove("Warehouse_Exbond_JobNo");
            txtExbond_JobNo.Text = Convert.ToString(Transact.RetrieveID());
            lblport.Visible = SELECT_BRANCH == ddltoBranch.SelectedValue.ToString() ? false : true;

            string[] arr;
            string Mode = "";
            if (ddltoBranch.SelectedItem.Text != string.Empty)
            {
                arr = ddltoBranch.SelectedItem.Text.Split('(');
                Mode = arr[1].TrimEnd(')');
                hdfTransport_mode.Value = arr[1].TrimEnd(')');
            }
            
            Admin_job_Prefix_Suffix JPS = new Admin_job_Prefix_Suffix();
            DataSet dats = new DataSet();
            JPS.Branch = ddltoBranch.SelectedValue.ToString();
            JPS.Tr_mode = Mode;
            JPS.Ename = "Imp_gen_select";
            //JPS.Branch = SELECT_BRANCH;
           // dats = JPS.Job_prefix_Suffix_Select();
            dats = JPS.Job_prefix_Suffix_Select_Areawise();
            if (dats.Tables[0].Rows.Count > 0)
            {
                if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                {
                    txtjob_Prefix.Text = string.Empty;
                    txtjob_Suffix.Text = ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                }
                else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                {
                    txtjob_Prefix.Text = ((dats.Tables[0].Rows[0][0].ToString()).TrimStart()).TrimEnd();
                    txtjob_Suffix.Text = string.Empty;
                }
                else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                {
                    txtjob_Prefix.Text = ((dats.Tables[0].Rows[0][0].ToString()).TrimStart()).TrimEnd();
                    txtjob_Suffix.Text = ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                }
                else if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                {
                   Clear_Prefix_Suffix();
                }
            }
            else
            {
                Clear_Prefix_Suffix();
            }
        }
        else
        {
            Transact.WORKING_PERIOD = Working_Period;
            Transact.BRANCH_CODE = SELECT_BRANCH;
            Session.Remove("Warehouse_Exbond_JobNo");
            txtExbond_JobNo.Text = Convert.ToString(Transact.RetrieveID());
        }
    }
    private void Clear_Prefix_Suffix() { txtjob_Prefix.Text = string.Empty; txtjob_Suffix.Text = string.Empty; }
    
    public void dropdown_bind()
    {
        Transact.JOBNO = "";
        Transact.Ename = "select_Warehouse_JobNo";
        Transact.WORKING_PERIOD = SELECT_BRANCH;
        ddlWarehouse_JobNo.DataSource = Transact.RetrieveAll_Warehouse_Job_Details();
        ddlWarehouse_JobNo.DataValueField = "JOBNO";
        ddlWarehouse_JobNo.DataTextField = "JOBNO_PS";
        ddlWarehouse_JobNo.DataBind();
        ddlWarehouse_JobNo.Items.Remove("0");
        ddlWarehouse_JobNo.Items.Insert(0, "Select");
    }
    public void BindPrimaryGrid()
    {
        Transact.JOBNO = ddlWarehouse_JobNo.SelectedValue;
        Session["WAREHOUSE_JOBNO"] = ddlWarehouse_JobNo.SelectedValue;
        Transact.Ename = "select_Details";
        Transact.WORKING_PERIOD = SELECT_BRANCH;
        gvAll.DataSource = Transact.RetrieveAll_Warehouse_Job_Details();
        gvAll.DataBind();

        if (ddlWarehouse_JobNo.SelectedItem.Text != "Select")
        {
            DataSet ss = new DataSet();
            ss = Transact.RetrieveAll_Warehouse_Job_Details();
            if (ss.Tables[1].Rows.Count > 0)
            {
                ddlbe_No.SelectedValue = ss.Tables[1].Rows[0]["BE_JOBNO"].ToString();
            }
            else
            {
                ddlbe_No.SelectedIndex=-1;
            }
        }
        else
        {
            ddlbe_No.SelectedIndex=-1;
        }
    }
    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        GetData();
        gvAll.PageIndex = e.NewPageIndex;
        BindPrimaryGrid();
        SetData();
    }
    private void GetData()
    {
        DataTable dt;
        if (ViewState["SelectedRecords"] != null)
            dt = (DataTable)ViewState["SelectedRecords"];
        else
            dt = CreateDataTable();
        CheckBox chkAll = (CheckBox)gvAll.HeaderRow.Cells[0].FindControl("chkAll");
        for (int i = 0; i < gvAll.Rows.Count; i++)
        {
            if (chkAll.Checked)
            {
                dt = AddRow(gvAll.Rows[i], dt);
            }
            else
            {
                CheckBox chk = (CheckBox)gvAll.Rows[i].Cells[0].FindControl("chk");
                if (chk.Checked)
                {
                    
                    dt = AddRow(gvAll.Rows[i], dt);
                }
                else
                {
                  
                    dt = RemoveRow(gvAll.Rows[i], dt);
                }
            }
        }
       
        ViewState["SelectedRecords"] = dt;
    }
    private void SetData()
    {
        CheckBox chkAll = (CheckBox)gvAll.HeaderRow.Cells[0].FindControl("chkAll");
        chkAll.Checked = true;
        if (ViewState["SelectedRecords"] != null)
        {
            DataTable dt = (DataTable)ViewState["SelectedRecords"];
            for (int i = 0; i < gvAll.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvAll.Rows[i].Cells[0].FindControl("chk");
                if (chk != null)
                {
                    DataRow[] dr = dt.Select("ITEM_ID = '" + gvAll.Rows[i].Cells[1].Text + "' and INVOICE_SLNO = '" + gvAll.Rows[i].Cells[2].Text + "' and ITEM_SLNO = '" + gvAll.Rows[i].Cells[3].Text + "'");
                    chk.Checked = dr.Length > 0;
                    if (!chk.Checked)
                    {
                        chkAll.Checked = false;
                    }
                }
            }
        }
    }
    private DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("ITEM_ID");
        dt.Columns.Add("INVOICE_NO");
        dt.Columns.Add("INVOICE_SLNO");
        dt.Columns.Add("ITEM_SLNO");
        dt.Columns.Add("REMAINING_QTY");
        dt.Columns.Add("ITEM_QTY_CODE");
        dt.Columns.Add("ITEM_DESCRIPTION");
        dt.AcceptChanges();
        return dt;
    }
    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {

        DataRow[] dr = dt.Select("ITEM_ID = '" + gvRow.Cells[1].Text + "' and INVOICE_SLNO = '" + gvRow.Cells[2].Text + "' and ITEM_SLNO = '" + gvRow.Cells[3].Text + "'");
        if (dr.Length <= 0)
        {
            TextBox txtItem = (TextBox)(gvRow.FindControl("txtItem_Qty"));
            decimal Remain_Qty = Convert.ToDecimal(gvRow.Cells[5].Text);
            txtItem.Enabled = false;

            if (txtItem.Text == "")
            {
                txtItem.Text = "0";
            }
            if (Remain_Qty >= Convert.ToDecimal(txtItem.Text))
            {
                dt.Rows.Add();
                dt.Rows[dt.Rows.Count - 1]["ITEM_ID"] = gvRow.Cells[1].Text;
                dt.Rows[dt.Rows.Count - 1]["INVOICE_NO"] = gvRow.Cells[2].Text;
                dt.Rows[dt.Rows.Count - 1]["INVOICE_SLNO"] = gvRow.Cells[3].Text;
                dt.Rows[dt.Rows.Count - 1]["ITEM_SLNO"] = gvRow.Cells[4].Text;
                dt.Rows[dt.Rows.Count - 1]["REMAINING_QTY"] = txtItem.Text;

                if (txtItem.Text == "" || txtItem.Text=="0")
                {
                    dt.Rows[dt.Rows.Count - 1]["REMAINING_QTY"] = gvRow.Cells[5].Text;
                    txtItem.Text = "";
                }
                else
                {
                    dt.Rows[dt.Rows.Count - 1]["REMAINING_QTY"] = txtItem.Text;
                }
                dt.Rows[dt.Rows.Count - 1]["ITEM_QTY_CODE"] = gvRow.Cells[8].Text;
                dt.Rows[dt.Rows.Count - 1]["ITEM_DESCRIPTION"] = gvRow.Cells[9].Text;
                dt.AcceptChanges();
            }
            else
            {
                txtItem.Enabled = false;
                Alert_msg("Your Exbond Qty not greater than Remaining Qty");
                txtItem.Focus();
            }                          
        }
        return dt;
    }

    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("ITEM_ID = '" + gvRow.Cells[1].Text + "' and INVOICE_SLNO = '" + gvRow.Cells[2].Text + "' and ITEM_SLNO = '" + gvRow.Cells[3].Text + "'");
        if (dr.Length > 0)
        {
            dt.Rows.Remove(dr[0]);
            dt.AcceptChanges();
            TextBox txtItem = (TextBox)(gvRow.FindControl("txtItem_Qty"));
            txtItem.Enabled = true;
        }
        return dt;
    }
   
    protected void CheckBox_CheckChanged(object sender, EventArgs e)
    {
        GetData();
        SetData();
        BindSecondaryGrid();
    }
    private void BindSecondaryGrid()
    {
        DataTable dt = (DataTable)ViewState["SelectedRecords"];
        gvSelected.DataSource = dt;
        gvSelected.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        AUTO_JOBNO();
        string P_S = string.Empty;
        string JobnoPS = string.Empty;
        Session["IMPORT_JOBNO"] = txtExbond_JobNo.Text;

        if (currentbranch != ddltoBranch.SelectedValue.ToString())
        {
            if (txtPortOrigin.Text != string.Empty && txtPortShipment.Text != string.Empty)
            {
                P_S = "Y";
            }
        }
        else
        {
            P_S = "Y";
        }

        if (P_S == "Y")
        {
            string B_to_B = string.Empty;
            if (gvSelected.Rows.Count > 0)
            {
                if (currentbranch == ddltoBranch.SelectedValue.ToString())
                {
                    for (int j = 0; j < gvSelected.Rows.Count; j++)
                    {
                        Transact.OLD_JOBNO = ddlWarehouse_JobNo.SelectedValue.ToString();
                        Transact.JOBNO = txtExbond_JobNo.Text;
                        Transact.ITEM_ID = gvSelected.Rows[j].Cells[0].Text;
                        //Transact.INVOICE_NO = gvSelected.Rows[j].Cells[1].Text;
                        Transact.INVOICE_SLNO = gvSelected.Rows[j].Cells[2].Text;
                        Transact.ITEM_SLNO = gvSelected.Rows[j].Cells[3].Text;
                        Transact.ITEM_QTY = gvSelected.Rows[j].Cells[4].Text;
                        Transact.ITEM_QTY_CODE = gvSelected.Rows[j].Cells[5].Text;
                        Transact.ITEM_DESCRIPTION = gvSelected.Rows[j].Cells[6].Text;
                        Transact.BRANCH_CODE = currentbranch;
                        Transact.USER_ID = currentuser;
                        Transact.Ename = "Duplicate_Job";
                        Transact.WORKING_PERIOD = SELECT_BRANCH;

                        if (Connection.Company_License() != null) 
                        {
                            if (Connection.Company_License().ToLower() == "eri00247")
                            {
                                if (txtjob_Prefix.Text != string.Empty && txtjob_Suffix.Text != string.Empty)
                                {
                                    Transact.JOBNO_PS = txtjob_Prefix.Text + txtExbond_JobNo.Text + "/" + txtjob_Suffix.Text;
                                    Transact.JOB_PREFIX = txtjob_Prefix.Text;
                                    Transact.JOB_SUFFIX = txtjob_Suffix.Text;
                                }
                                else if (txtjob_Prefix.Text != string.Empty && txtjob_Suffix.Text == string.Empty)
                                {
                                    Transact.JOBNO_PS = txtjob_Prefix.Text + txtExbond_JobNo.Text;
                                    Transact.JOB_PREFIX = txtjob_Prefix.Text;
                                    Transact.JOB_SUFFIX = string.Empty;
                                }
                                else if (txtjob_Prefix.Text == string.Empty && txtjob_Suffix.Text != string.Empty)
                                {
                                    Transact.JOBNO_PS = txtExbond_JobNo.Text + "/" + txtjob_Suffix.Text;
                                    Transact.JOB_PREFIX = string.Empty;
                                    Transact.JOB_SUFFIX = txtjob_Suffix.Text;
                                }
                                else if (txtjob_Prefix.Text == string.Empty && txtjob_Suffix.Text == string.Empty)
                                {
                                    Transact.JOBNO_PS = txtExbond_JobNo.Text;
                                    Clear_JOB_PREFIX_SUFFIX();
                                }
                            }
                            else
                            {
                                if (txtjob_Prefix.Text != string.Empty && txtjob_Suffix.Text != string.Empty)
                                {
                                    Transact.JOBNO_PS = txtjob_Prefix.Text + "/" + txtExbond_JobNo.Text + "/" + txtjob_Suffix.Text;
                                    Transact.JOB_PREFIX = txtjob_Prefix.Text;
                                    Transact.JOB_SUFFIX = txtjob_Suffix.Text;
                                }
                                else if (txtjob_Prefix.Text != string.Empty && txtjob_Suffix.Text == string.Empty)
                                {
                                    Transact.JOBNO_PS = txtjob_Prefix.Text + "/" + txtExbond_JobNo.Text;
                                    Transact.JOB_PREFIX = txtjob_Prefix.Text;
                                    Transact.JOB_SUFFIX = string.Empty;
                                }
                                else if (txtjob_Prefix.Text == string.Empty && txtjob_Suffix.Text != string.Empty)
                                {
                                    Transact.JOBNO_PS = txtExbond_JobNo.Text + "/" + txtjob_Suffix.Text;
                                    Transact.JOB_PREFIX = string.Empty;
                                    Transact.JOB_SUFFIX = txtjob_Suffix.Text;
                                }
                                else if (txtjob_Prefix.Text == string.Empty && txtjob_Suffix.Text == string.Empty)
                                {
                                    Transact.JOBNO_PS = txtExbond_JobNo.Text;
                                    Clear_JOB_PREFIX_SUFFIX();
                                }
                            }
                            JobnoPS = Transact.JOBNO_PS;
                            i = Transact.Generate_Warehouse_Duplicate_Job();
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < gvSelected.Rows.Count; j++)
                    {
                        Transact.OLD_JOBNO = ddlWarehouse_JobNo.SelectedValue.ToString();
                        Transact.JOBNO = txtExbond_JobNo.Text;
                        Transact.ITEM_ID = gvSelected.Rows[j].Cells[0].Text;
                        //Transact.INVOICE_NO = gvSelected.Rows[j].Cells[1].Text;
                        Transact.INVOICE_SLNO = gvSelected.Rows[j].Cells[2].Text;
                        Transact.ITEM_SLNO = gvSelected.Rows[j].Cells[3].Text;
                        Transact.ITEM_QTY = gvSelected.Rows[j].Cells[4].Text;
                        Transact.ITEM_QTY_CODE = gvSelected.Rows[j].Cells[5].Text;
                        Transact.ITEM_DESCRIPTION = gvSelected.Rows[j].Cells[6].Text;
                        Transact.BRANCH_CODE = ddltoBranch.SelectedValue.ToString();
                        Transact.USER_ID = currentuser;
                        Transact.Port_Orgin = txtPortOrigin.Text;
                        Transact.Port_Shipment = txtPortShipment.Text;
                        Transact.Tr_Mode = hdfTransport_mode.Value.ToString();
                        Transact.Cus_House = hdCus_House.Value.ToString();

                        Transact.Ename = "Duplicate_Job_Branch_TO_Branch";
                        Transact.WORKING_PERIOD = SELECT_BRANCH;

                        if (txtjob_Prefix.Text != string.Empty && txtjob_Suffix.Text != string.Empty)
                        {
                            Transact.JOBNO_PS = txtjob_Prefix.Text + "/" + txtExbond_JobNo.Text + "/" + txtjob_Suffix.Text;
                            Transact.JOB_PREFIX = txtjob_Prefix.Text;
                            Transact.JOB_SUFFIX = txtjob_Suffix.Text;
                        }
                        else if (txtjob_Prefix.Text != string.Empty && txtjob_Suffix.Text == string.Empty)
                        {
                            Transact.JOBNO_PS = txtjob_Prefix.Text + "/" + txtExbond_JobNo.Text;
                            Transact.JOB_PREFIX = txtjob_Prefix.Text;
                            Transact.JOB_SUFFIX = string.Empty;
                        }
                        else if (txtjob_Prefix.Text == string.Empty && txtjob_Suffix.Text != string.Empty)
                        {
                            Transact.JOBNO_PS = txtExbond_JobNo.Text + "/" + txtjob_Suffix.Text;
                            Transact.JOB_PREFIX = string.Empty;
                            Transact.JOB_SUFFIX = txtjob_Suffix.Text;
                        }
                        else if (txtjob_Prefix.Text == string.Empty && txtjob_Suffix.Text == string.Empty)
                        {
                            Transact.JOBNO_PS = txtExbond_JobNo.Text;
                            Clear_JOB_PREFIX_SUFFIX();
                        }
                        JobnoPS = Transact.JOBNO_PS;
                        i = Transact.Generate_Warehouse_Duplicate_Job();
                    }
                    B_to_B = "Y";
                }

                BindPrimaryGrid();
                if (i == 1)
                {
                    if (B_to_B == "Y")
                    {
                        Session.Remove("EXBND_JOBID");
                        Session["EXBND_JOBID"] = txtExbond_JobNo.Text;
                        Exbond_Id.Style.Add("display", "none");
                        Session.Remove("Warehouse_Exbond_JobNo");

                        Session.Remove("Job_PS");
                        Session["Job_PS"] = string.Empty;
                    }
                    else
                    {
                        Session.Remove("EXBND_JOBID");
                        Session["EXBND_JOBID"] = txtExbond_JobNo.Text;
                        Exbond_Id.Style.Add("display", "Block");
                        Session.Remove("Warehouse_Exbond_JobNo");
                        Session.Remove("Job_PS");
                        Session["Job_PS"] = JobnoPS;
                    }
                }
                else
                {
                    Exbond_Id.Style.Add("display", "none");
                    Session.Remove("EXBND_JOBID");

                }
                Alert_msg("Saved Successfully");
            }
            else
            {
                Alert_msg("No Data Found");
            }
        }
        else
        {
            Alert_msg("Select Port of Orgin or Port of Shipment");
        }
    }
    private void Clear_JOB_PREFIX_SUFFIX()
    {
    Transact.JOB_PREFIX = string.Empty;
    Transact.JOB_SUFFIX = string.Empty;
    }
    protected void ddlWarehouse_JobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["SelectedRecords"] = null;
        ViewState.Clear();
        BindPrimaryGrid();

        gvSelected.DataSource = dt;
        gvSelected.DataBind();
        ddltoBranch_SelectedIndexChanged(sender, e);
    }
    protected void gvAll_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (hdn_Grid_Disable.Value == "1")
            {
                e.Row.Enabled = false;
            }
            else
            {
                e.Row.Enabled = true;
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                if (!IsPostBack)
                {
                    e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gvAll, "Select$" + e.Row.RowIndex.ToString()));
                }
            }
        }
    }
    protected void gvAll_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
   
    protected void gvSelected_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (hdn_Grid_Disable.Value == "1")
            {
                e.Row.Enabled = false;
            }
            else
            {
                e.Row.Enabled = true;
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gvSelected, "Select$" + e.Row.RowIndex.ToString()));
            }
        }
    }
    protected void gvAll_DataBound(object sender, EventArgs e)
    {
        Boolean hasData = false;

        for (int col = 0; col < gvAll.HeaderRow.Cells.Count; col++)
        {
            for (int row = 0; row < gvAll.Rows.Count; row++)
            {
                if (!String.IsNullOrEmpty(gvAll.Rows[row].Cells[col].Text) && !String.IsNullOrEmpty(HttpUtility.HtmlDecode(gvAll.Rows[row].Cells[col].Text).Trim()))
                {
                    hasData = true;
                    break;
                }
            }
            if (!hasData)
            {
               /* for (int hiddenrows = 0; hiddenrows < gvAll.Rows.Count; hiddenrows++)
                {
                    //gvAll.Rows[hiddenrows].Cells[col].Visible = false;
                }*/
            }
            hasData = false;
        }

    }
    protected void ddltoBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtPortOrigin.Text = string.Empty;
        txtPortShipment.Text = string.Empty;
        string[] arr = new string[] { };
        string Mode = string.Empty;

        if (ddlWarehouse_JobNo.SelectedItem.Text != "Select")
        {
            AUTO_JOBNO();

            if (ddltoBranch.SelectedItem.Text != string.Empty)
            {
                arr = ddltoBranch.SelectedItem.Text.Split('(');
                Mode = arr[1].TrimEnd(')');
                hdfTransport_mode.Value = arr[1].TrimEnd(')');

                if (Mode == "Air")
                {
                    Mode = "A";
                }
                else if (Mode == "Sea")
                {
                    Mode = "S";
                }
                else if (Mode == "Land")
                {
                    Mode = "L";
                }
            }

            DataSet dsss = new DataSet();
            Imp_Job_Duplicate IJD = new Imp_Job_Duplicate();
            IJD.COMPANY_ID = Mode;
            IJD.SELECT_BRANCH_CODE = ddltoBranch.SelectedValue.ToString();
            IJD.Ename = "Select_CUS_CODE";
            dsss = IJD.Load_Company_Branch();
            if (dsss.Tables[0].Rows.Count > 0)
            {
                hdCus_House.Value = dsss.Tables[0].Rows[0][0].ToString();
            }
        }
        else
        {
            if (ddltoBranch.SelectedItem.Text != string.Empty)
            {
                arr = ddltoBranch.SelectedItem.Text.Split('(');
                Mode = arr[1].TrimEnd(')');
                hdfTransport_mode.Value = arr[1].TrimEnd(')');
            }

        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'WAREHOUSE-EXBOND', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
   
    protected void ddlbe_No_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ( ddlbe_No.SelectedItem.Text != string.Empty)
        {
            ViewState["SelectedRecords"] = null;
            ViewState.Clear();

            Transact.JOBNO = ddlbe_No.SelectedItem.Text;

            Transact.Ename = "WH_select_Details";
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            gvAll.DataSource = Transact.RetrieveAll_Warehouse_Job_Details();
            gvAll.DataBind();

            DataSet dss = new DataSet();
            dss = Transact.RetrieveAll_Warehouse_Job_Details();

            if (dss.Tables[0].Rows.Count > 0)
            {
                if (dss.Tables[1].Rows.Count > 0)
                {
                    Session["WAREHOUSE_JOBNO"] = dss.Tables[1].Rows[0]["JOBNO"].ToString();
                    ddlWarehouse_JobNo.SelectedValue = dss.Tables[1].Rows[0]["JOBNO"].ToString();

                    gvSelected.DataSource = dt;
                    gvSelected.DataBind();
                    ddltoBranch_SelectedIndexChanged(sender, e);
                }
            }
            else
            {
                ddlWarehouse_JobNo.SelectedIndex = -1;
            }
        }
        else
        {
            

            gvSelected.DataSource = dt;
            gvSelected.DataBind();
            ddltoBranch_SelectedIndexChanged(sender, e);
        }
    }

    private void Load_BE_No()
    {
        Auto_Search As = new Auto_Search();
        DataSet dss = new DataSet();

        //As.Enamesearch = "";
        As.NSearch = SELECT_BRANCH;
        As.Ename = "Get_Warehouse_Beno";
        dss = As.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

        if (dss.Tables[0].Rows.Count > 0)
        {
            ddlbe_No.DataTextField = dss.Tables[0].Columns["BE_NO"].ToString();
            ddlbe_No.DataValueField = dss.Tables[0].Columns["BE_JOBNO"].ToString();
            ddlbe_No.DataSource = dss.Tables[0];
            ddlbe_No.DataBind();
            ddlbe_No.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlbe_No.SelectedIndex = 0;
        }
    }
}