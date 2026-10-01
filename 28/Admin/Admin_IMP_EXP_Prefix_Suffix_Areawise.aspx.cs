using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Services;

public partial class Admin_IMP_EXP_Prefix_Suffix : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    Company_Master Comp = new Company_Master();
    Admin_job_Prefix_Suffix JPS = new Admin_job_Prefix_Suffix();

    public int i, j;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    string Mode = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        SELECT_TYPE = Session["SELECT_TYPE"].ToString();
        hdn_Select_Type.Value = SELECT_TYPE;

        SELECT_BRANCH = Connection.Get_Company_Type();

        if (!IsPostBack)
        {
            if (SELECT_BRANCH != "")
            {
                Common_I.Visible = false;
                Common_E.Visible = false;

                LoadGroup();
                Load_To_Branch();
                load_Job_prefix_Suffix();
            }
            else
            {
                Branch_1.Visible = false;
                txtJobNo_IA.Enabled = false;
                txtJobNo_IS.Enabled = false;
                txtJobNo_IL.Enabled = false;

                txtJobNo_EA.Enabled = false;
                txtJobNo_ES.Enabled = false;
                txtJobNo_EL.Enabled = false;
                Load_Common_data();

                txtJobNo_IA.Visible = false;
                txtJobNo_IS.Visible = false;
                txtJobNo_IL.Visible = false;

                txtJobNo_EA.Visible = false;
                txtJobNo_ES.Visible = false;
                txtJobNo_EL.Visible = false;
            }
        }
    }
    
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Job Prefix Suffix', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Job Prefix Suffix', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    private void Load_To_Branch()
    {
        DataSet ds = new DataSet();
        Company_Master Comp = new Company_Master();
        if (Session["COMPANY_DETAILS_DS"] != null)
        {
            ds = (DataSet)Session["COMPANY_DETAILS_DS"];
        }
        List<BranchDetails> details = new List<BranchDetails>();
        BranchDetails Branch1 = new BranchDetails();

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow dtrow in ds.Tables[1].Rows)
                {
                    BranchDetails Branch = new BranchDetails();
                    Branch.CountryId = dtrow["BRANCH"].ToString();
                    string branch = dtrow["BRANCH"].ToString();
                    string branch_code = dtrow["PORT_OF_FILING"].ToString();
                    Branch.result = Convert.ToString(Comp.result);

                    string[] s1 = branch.Split(new string[] { "," }, StringSplitOptions.None);
                    string custom_Branch = s1[1].ToString();

                    DataView view1 = ds.Tables[3].DefaultView;
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

                            if (a == "Customs, Mundra")
                                Category_mode = "Sea";

                            Branch.CountryName = custom_Branch + "(" + Category_mode + ")";
                            details.Add(Branch);
                        }
                    }
                }

                ddlbranch.DataSource = details.ToArray();
                ddlbranch.DataValueField = "CountryId";
                ddlbranch.DataTextField = "CountryName";
                ddlbranch.DataBind();
                ddlbranch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlbranch.SelectedIndex = 0;
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

    public class change_branch
    {
        public string BranchName { get; set; }
    }

    private void load_Job_prefix_Suffix()
    {
        string[] arr = new string[] { };
        //string Mode = string.Empty;

        DataSet ds = new DataSet();

        if (ddlbranch.SelectedItem.Text != string.Empty)
        {
            if (SELECT_TYPE == "Areawise Job")
            {
                txt_Prefix_IA.Enabled = true;
                txtJobNo_IA.Enabled = true;
                txt_Suffix_IA.Enabled = true;

                txt_Prefix_IS.Enabled = true;
                txtJobNo_IS.Enabled = true;
                txt_Suffix_IS.Enabled = true;

                txt_Prefix_IL.Enabled = true;
                txtJobNo_IL.Enabled = true;
                txt_Suffix_IL.Enabled = true;

                txt_Prefix_EA.Enabled = true;
                txtJobNo_EA.Enabled = true;
                txt_Suffix_EA.Enabled = true;

                txt_Prefix_ES.Enabled = true;
                txtJobNo_ES.Enabled = true;
                txt_Suffix_ES.Enabled = true;

                txt_Prefix_EL.Enabled = true;
                txtJobNo_EL.Enabled = true;
                txt_Suffix_EL.Enabled = true;
            }
            else
            {
                arr = ddlbranch.SelectedItem.Text.Split('(');
                Mode = arr[1].TrimEnd(')');

                if (Mode == "Air")
                {
                    txt_Prefix_IA.Enabled = true;
                    txtJobNo_IA.Enabled = true;
                    txt_Suffix_IA.Enabled = true;

                    txt_Prefix_IS.Enabled = false;
                    txtJobNo_IS.Enabled = false;
                    txt_Suffix_IS.Enabled = false;

                    txt_Prefix_IL.Enabled = false;
                    txtJobNo_IL.Enabled = false;
                    txt_Suffix_IL.Enabled = false;

                    txt_Prefix_EA.Enabled = true;
                    txtJobNo_EA.Enabled = true;
                    txt_Suffix_EA.Enabled = true;

                    txt_Prefix_ES.Enabled = false;
                    txtJobNo_ES.Enabled = false;
                    txt_Suffix_ES.Enabled = false;

                    txt_Prefix_EL.Enabled = false;
                    txtJobNo_EL.Enabled = false;
                    txt_Suffix_EL.Enabled = false;

                }
                else if (Mode == "Sea")
                {
                    txt_Prefix_IA.Enabled = false;
                    txtJobNo_IA.Enabled = false;
                    txt_Suffix_IA.Enabled = false;

                    txt_Prefix_IS.Enabled = true;
                    txtJobNo_IS.Enabled = true;
                    txt_Suffix_IS.Enabled = true;

                    txt_Prefix_IL.Enabled = false;
                    txtJobNo_IL.Enabled = false;
                    txt_Suffix_IL.Enabled = false;

                    txt_Prefix_EA.Enabled = false;
                    txtJobNo_EA.Enabled = false;
                    txt_Suffix_EA.Enabled = false;

                    txt_Prefix_ES.Enabled = true;
                    txtJobNo_ES.Enabled = true;
                    txt_Suffix_ES.Enabled = true;

                    txt_Prefix_EL.Enabled = false;
                    txtJobNo_EL.Enabled = false;
                    txt_Suffix_EL.Enabled = false;


                }
                else if (Mode == "Land")
                {
                    txt_Prefix_IA.Enabled = false;
                    txtJobNo_IA.Enabled = false;
                    txt_Suffix_IA.Enabled = false;

                    txt_Prefix_IS.Enabled = false;
                    txtJobNo_IS.Enabled = false;
                    txt_Suffix_IS.Enabled = false;

                    txt_Prefix_IL.Enabled = true;
                    txtJobNo_IL.Enabled = true;
                    txt_Suffix_IL.Enabled = true;

                    txt_Prefix_EA.Enabled = false;
                    txtJobNo_EA.Enabled = false;
                    txt_Suffix_EA.Enabled = false;

                    txt_Prefix_ES.Enabled = false;
                    txtJobNo_ES.Enabled = false;
                    txt_Suffix_ES.Enabled = false;

                    txt_Prefix_EL.Enabled = true;
                    txtJobNo_EL.Enabled = true;
                    txt_Suffix_EL.Enabled = true;
                }
            }

            JPS.Branch = ddlbranch.SelectedValue.ToString();
            JPS.BranchType = SELECT_TYPE;
            JPS.Ename = "Admin_select";

            if (SELECT_TYPE == "Areawise Job")
            {
                JPS.Tr_mode = Mode;
                JPS.GroupName = ddlGrpname.SelectedItem.Text;
                ds = JPS.Job_prefix_Suffix_Select_Areawise();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["BRANCH_CODE"].ToString() != "")
                    {
                        //-------------------------------IMP--Air --------------------------------------

                        var FullName1 = from DataRow drr in ds.Tables[0].AsEnumerable()
                                        where drr.Field<string>("TR_MODE") == "Air"
                                        select drr;

                        DataView dvv = FullName1.AsDataView();

                        if (dvv.Count > 0)
                        {
                            DataTable dt_Air = FullName1.CopyToDataTable();

                            txt_Prefix_IA.Text = dt_Air.Rows[0][0].ToString();
                            txtJobNo_IA.Text = dt_Air.Rows[0][2].ToString() == "0" ? string.Empty : dt_Air.Rows[0][2].ToString();
                            txt_Suffix_IA.Text = dt_Air.Rows[0][1].ToString();
                        }

                        //------------------------------IMP---Sea --------------------------------------
                        FullName1 = from DataRow drr in ds.Tables[0].AsEnumerable()
                                    where drr.Field<string>("TR_MODE") == "Sea"
                                    select drr;

                        dvv = FullName1.AsDataView();

                        if (dvv.Count > 0)
                        {
                            DataTable dt_Sea = FullName1.CopyToDataTable();

                            txt_Prefix_IS.Text = dt_Sea.Rows[0][0].ToString();
                            txtJobNo_IS.Text = dt_Sea.Rows[0][2].ToString() == "0" ? string.Empty : dt_Sea.Rows[0][2].ToString();
                            txt_Suffix_IS.Text = dt_Sea.Rows[0][1].ToString();
                        }

                        //-----------------------------IMP---Land --------------------------------------

                        FullName1 = from DataRow drr in ds.Tables[0].AsEnumerable()
                                    where drr.Field<string>("TR_MODE") == "Land"
                                    select drr;

                        dvv = FullName1.AsDataView();

                        if (dvv.Count > 0)
                        {
                            DataTable dt_Land = FullName1.CopyToDataTable();

                            txt_Prefix_IL.Text = dt_Land.Rows[0][0].ToString();
                            txtJobNo_IL.Text = dt_Land.Rows[0][2].ToString() == "0" ? string.Empty : dt_Land.Rows[0][2].ToString();
                            txt_Suffix_IL.Text = dt_Land.Rows[0][1].ToString();
                        }
                    }
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    if (ds.Tables[1].Rows[0]["BRANCH_CODE"].ToString() != "")
                    {
                        //-------------------------------EXP--Air --------------------------------------

                        var FullName1 = from DataRow drr in ds.Tables[1].AsEnumerable()
                                        where drr.Field<string>("TR_MODE") == "Air"
                                        select drr;

                        DataView dvv = FullName1.AsDataView();

                        if (dvv.Count > 0)
                        {
                            DataTable dt_Air = FullName1.CopyToDataTable();

                            txt_Prefix_EA.Text = dt_Air.Rows[0][0].ToString();
                            txtJobNo_EA.Text = dt_Air.Rows[0][2].ToString() == "0" ? string.Empty : dt_Air.Rows[0][2].ToString();
                            txt_Suffix_EA.Text = dt_Air.Rows[0][1].ToString();
                        }

                        //------------------------------EXP---Sea --------------------------------------
                        FullName1 = from DataRow drr in ds.Tables[1].AsEnumerable()
                                    where drr.Field<string>("TR_MODE") == "Sea"
                                    select drr;

                        dvv = FullName1.AsDataView();

                        if (dvv.Count > 0)
                        {
                            DataTable dt_Sea = FullName1.CopyToDataTable();

                            txt_Prefix_ES.Text = dt_Sea.Rows[0][0].ToString();
                            txtJobNo_ES.Text = dt_Sea.Rows[0][2].ToString() == "0" ? string.Empty : dt_Sea.Rows[0][2].ToString();
                            txt_Suffix_ES.Text = dt_Sea.Rows[0][1].ToString();
                        }

                        //------------------------------EXP---Land --------------------------------------

                        FullName1 = from DataRow drr in ds.Tables[1].AsEnumerable()
                                    where drr.Field<string>("TR_MODE") == "Land"
                                    select drr;

                        dvv = FullName1.AsDataView();

                        if (dvv.Count > 0)
                        {
                            DataTable dt_Land = FullName1.CopyToDataTable();

                            txt_Prefix_EL.Text = dt_Land.Rows[0][0].ToString();
                            txtJobNo_EL.Text = dt_Land.Rows[0][2].ToString() == "0" ? string.Empty : dt_Land.Rows[0][2].ToString();
                            txt_Suffix_EL.Text = dt_Land.Rows[0][1].ToString();
                        }
                    }
                }
            }
            else
            {
                ds = JPS.Job_prefix_Suffix_Select();
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (Mode == "Air")
                {
                    txt_Prefix_IA.Text = ds.Tables[0].Rows[0][0].ToString();
                    txtJobNo_IA.Text = ds.Tables[0].Rows[0][2].ToString() == "0" ? string.Empty : ds.Tables[0].Rows[0][2].ToString();
                    txt_Suffix_IA.Text = ds.Tables[0].Rows[0][1].ToString();
                }
                else if (Mode == "Sea")
                {
                    txt_Prefix_IS.Text = ds.Tables[0].Rows[0][0].ToString();
                    txtJobNo_IS.Text = ds.Tables[0].Rows[0][2].ToString() == "0" ? string.Empty : ds.Tables[0].Rows[0][2].ToString();
                    txt_Suffix_IS.Text = ds.Tables[0].Rows[0][1].ToString();
                }
                else if (Mode == "Land")
                {
                    txt_Prefix_IL.Text = ds.Tables[0].Rows[0][0].ToString();
                    txtJobNo_IL.Text = ds.Tables[0].Rows[0][2].ToString() == "0" ? string.Empty : ds.Tables[0].Rows[0][2].ToString();
                    txt_Suffix_IL.Text = ds.Tables[0].Rows[0][1].ToString();
                }
            }
            else
            {
                txt_Prefix_IA.Text = string.Empty;
                txtJobNo_IA.Text = string.Empty;
                txt_Suffix_IA.Text = string.Empty;

                txt_Prefix_IS.Text =string.Empty; 
                txtJobNo_IS.Text =string.Empty;
                txt_Suffix_IS.Text =string.Empty;

                txt_Prefix_IL.Text = string.Empty;
                txtJobNo_IL.Text = string.Empty;
                txt_Suffix_IL.Text = string.Empty;

            }
            //-------------------------------------------------------------------------------------------------------------------------------
            if (ds.Tables[1].Rows.Count > 0)
            {
                if (Mode == "Air")
                {
                    txt_Prefix_EA.Text = ds.Tables[1].Rows[0][0].ToString();
                    txtJobNo_EA.Text =  ds.Tables[1].Rows[0][2].ToString() == "0" ? string.Empty : ds.Tables[1].Rows[0][2].ToString();
                    txt_Suffix_EA.Text = ds.Tables[1].Rows[0][1].ToString();
                }
                else if (Mode == "Sea")
                {
                    txt_Prefix_ES.Text = ds.Tables[1].Rows[0][0].ToString();
                    txtJobNo_ES.Text =  ds.Tables[1].Rows[0][2].ToString() == "0" ? string.Empty : ds.Tables[1].Rows[0][2].ToString();
                    txt_Suffix_ES.Text = ds.Tables[1].Rows[0][1].ToString();
                }
                else if (Mode == "Land")
                {
                    txt_Prefix_EL.Text = ds.Tables[1].Rows[0][0].ToString();
                    txtJobNo_EL.Text =  ds.Tables[1].Rows[0][2].ToString() == "0" ? string.Empty : ds.Tables[1].Rows[0][2].ToString();
                    txt_Suffix_EL.Text = ds.Tables[1].Rows[0][1].ToString();
                }
            }
            else
            {
                txt_Prefix_EA.Text = string.Empty;
                txtJobNo_EA.Text = string.Empty;
                txt_Suffix_EA.Text = string.Empty;

                txt_Prefix_ES.Text = string.Empty;
                txtJobNo_ES.Text = string.Empty;
                txt_Suffix_ES.Text = string.Empty;

                txt_Prefix_EL.Text = string.Empty;
                txtJobNo_EL.Text = string.Empty;
                txt_Suffix_EL.Text = string.Empty;
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                hdn_Imp_MaxJobno.Value = ds.Tables[2].Rows[0][0].ToString();
                lblimp.Text = " * Enter ur Job no greater than " + ds.Tables[2].Rows[0][0].ToString() + "";
            }
            else
            {
                hdn_Imp_MaxJobno.Value = "0";
                lblimp.Text = " * Enter ur Job no greater than 1";
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                hdn_Exp_MaxJobno.Value = ds.Tables[3].Rows[0][0].ToString();
                lblexp.Text = " * Enter ur Job no greater than " + ds.Tables[3].Rows[0][0].ToString() + "";
            }
            else
            {
                hdn_Exp_MaxJobno.Value = "0";
                lblimp.Text = " * Enter ur Job no greater than 1";
            }
        }
        else
        {
            All_false();
        }
    }
    protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear();
        if(ddlbranch.SelectedItem.Text !=string.Empty)
        {
            load_Job_prefix_Suffix();

            if (ViewState["dsGrp"] != null)
            {
                DataTable dt_cusHouse = new DataTable();
                dt_cusHouse = (DataTable)ViewState["dsGrp"];

                DataView v1 = dt_cusHouse.DefaultView;
                v1.RowFilter = "BRANCH_TRANSPORT_MODE = '" + ddlbranch.SelectedItem.Text.Trim() + "'";
                DataTable tab1 = v1.ToTable();

                if (tab1.Rows.Count > 0)
                {
                    txt_Cushouse.Text = tab1.Rows[0]["CUSTOMHOUSE"].ToString();
                }
            }
        }
    }
    protected void btnsave_update_Click(object sender, EventArgs e)
    {
        if (SELECT_TYPE == "Areawise Job")
        {
            Save_Areawise();
        }
        else if (SELECT_TYPE == "Branchwise Job")
        {
            Save_Branch();
        }
        else
        {
            Save_Common();
        }
    }

    private void Load_Common_data()
    {
        DataSet dss = new DataSet();

        JPS.Branch = SELECT_BRANCH;
        JPS.BranchType = SELECT_TYPE;
        JPS.Ename = "Admin_select";
        //dss = JPS.Job_prefix_Suffix_Select();
        dss = JPS.Job_prefix_Suffix_Select_Areawise();

        
        if (dss.Tables[0].Rows.Count > 0)
        {
            txt_Imp_common_jobno.Text = dss.Tables[0].Rows[0]["JOBNO"].ToString() == "0" ? string.Empty : dss.Tables[0].Rows[0]["JOBNO"].ToString();
            for (int y = 0; y < dss.Tables[0].Rows.Count; y++)
            { 
               if(dss.Tables[0].Rows[y]["BRANCH_CODE"].ToString()=="Air")
               {
                   txt_Prefix_IA.Text = dss.Tables[0].Rows[y]["JOB_PREFIX"].ToString();
                   txtJobNo_IA.Text = dss.Tables[0].Rows[y]["JOBNO"].ToString() == "0" ? string.Empty : dss.Tables[0].Rows[y]["JOBNO"].ToString();
                   txt_Suffix_IA.Text = dss.Tables[0].Rows[y]["JOB_SUFFIX"].ToString();
               }
               else if (dss.Tables[0].Rows[y]["BRANCH_CODE"].ToString() == "Sea")
               {
                   txt_Prefix_IS.Text = dss.Tables[0].Rows[y]["JOB_PREFIX"].ToString();
                   txtJobNo_IS.Text = dss.Tables[0].Rows[y]["JOBNO"].ToString() == "0" ? string.Empty : dss.Tables[0].Rows[y]["JOBNO"].ToString();
                   txt_Suffix_IS.Text = dss.Tables[0].Rows[y]["JOB_SUFFIX"].ToString();
               }
               else if (dss.Tables[0].Rows[y]["BRANCH_CODE"].ToString() == "Land")
               {
                   txt_Prefix_IL.Text = dss.Tables[0].Rows[y]["JOB_PREFIX"].ToString();
                   txtJobNo_IL.Text = dss.Tables[0].Rows[y]["JOBNO"].ToString() == "0" ? string.Empty : dss.Tables[0].Rows[y]["JOBNO"].ToString();
                   txt_Suffix_IL.Text = dss.Tables[0].Rows[y]["JOB_SUFFIX"].ToString();
               }
            }
        }

        if (dss.Tables[1].Rows.Count > 0)
        {
            txt_Exp_common_jobno.Text = dss.Tables[1].Rows[0]["JOBNO"].ToString() == "0" ? string.Empty : dss.Tables[1].Rows[0]["JOBNO"].ToString();
            for (int z = 0; z < dss.Tables[1].Rows.Count; z++)
            {
                if (dss.Tables[1].Rows[z]["BRANCH_CODE"].ToString() == "Air")
                {
                    txt_Prefix_EA.Text = dss.Tables[1].Rows[z]["JOB_PREFIX"].ToString();
                    txtJobNo_EA.Text = dss.Tables[1].Rows[z]["JOBNO"].ToString() == "0" ? string.Empty : dss.Tables[1].Rows[z]["JOBNO"].ToString();
                    txt_Suffix_EA.Text = dss.Tables[1].Rows[z]["JOB_SUFFIX"].ToString();
                }
                else if (dss.Tables[1].Rows[z]["BRANCH_CODE"].ToString() == "Sea")
                {
                    txt_Prefix_ES.Text = dss.Tables[1].Rows[z]["JOB_PREFIX"].ToString();
                    txtJobNo_ES.Text = dss.Tables[1].Rows[z]["JOBNO"].ToString() == "0" ? string.Empty : dss.Tables[1].Rows[z]["JOBNO"].ToString();
                    txt_Suffix_ES.Text = dss.Tables[1].Rows[z]["JOB_SUFFIX"].ToString();
                }
                else if (dss.Tables[1].Rows[z]["BRANCH_CODE"].ToString() == "Land")
                {
                    txt_Prefix_EL.Text = dss.Tables[1].Rows[z]["JOB_PREFIX"].ToString();
                    txtJobNo_EL.Text = dss.Tables[1].Rows[z]["JOBNO"].ToString() == "0" ? string.Empty : dss.Tables[1].Rows[z]["JOBNO"].ToString();
                    txt_Suffix_EL.Text = dss.Tables[1].Rows[z]["JOB_SUFFIX"].ToString();
                }
            }
        }

        if (dss.Tables[2].Rows.Count > 0)
        {
            lblimp.Text = " * Enter ur Job no greater than " + dss.Tables[2].Rows[0][0].ToString() + "";
            hdn_Imp_MaxJobno.Value = dss.Tables[2].Rows[0][0].ToString();
        }
        else
        {
            hdn_Imp_MaxJobno.Value = "0";
            lblimp.Text = " * Enter ur Job no greater than 1";
        }

        if (dss.Tables[3].Rows.Count > 0)
        {
            lblexp.Text = " * Enter ur Job no greater than " + dss.Tables[3].Rows[0][0].ToString() + "";
            hdn_Exp_MaxJobno.Value = dss.Tables[3].Rows[0][0].ToString();
        }
        else
        {
            hdn_Exp_MaxJobno.Value = "0";
            lblimp.Text = " * Enter ur Job no greater than 1";
        }
    }
    private void Save_Common()
    {
        //if (txt_Exp_common_jobno.Text != "" || txt_Exp_common_jobno.Text != "")
        //{
           DataSet ds = new DataSet();

            //JPS.I_Common_job = txt_Imp_common_jobno.Text;
            //JPS.E_Common_job = txt_Exp_common_jobno.Text; 

           JPS.I_Jobno = txt_Imp_common_jobno.Text;
           JPS.E_Jobno = txt_Exp_common_jobno.Text; 

            JPS.ICA_PREFIX =txt_Prefix_IA.Text;
            JPS.ICA_Suffix = txt_Suffix_IA.Text;

            JPS.ICS_PREFIX = txt_Prefix_IS.Text;
            JPS.ICS_Suffix = txt_Suffix_IS.Text;

            JPS.ICL_PREFIX = txt_Prefix_IL.Text;
            JPS.ICL_Suffix = txt_Suffix_IL.Text;

            JPS.ECA_PREFIX = txt_Prefix_EA.Text;
            JPS.ECA_Suffix = txt_Suffix_EA.Text;
            JPS.ECS_PREFIX = txt_Prefix_ES.Text;
            JPS.ECS_Suffix = txt_Suffix_ES.Text;
            JPS.ECL_PREFIX = txt_Prefix_EL.Text;
            JPS.ECL_Suffix = txt_Suffix_EL.Text;
            
            JPS.user_Id = currentuser;
            JPS.Working_period = Working_Period;
            JPS.Flag = "";
            JPS.BranchType = SELECT_TYPE;

            //JPS.IMP_EXP_Common_INS_UPD();//hide on 16-07-2024
            JPS.IMP_EXP_Areawise_INS_UPD();
            i = JPS.result;

            if (i == 0)
            {
                Alert_msg("Created successfully!", "btnsave_update");
            }
            else if (i == 1)
            {
                Alert_msg("Updated successfully!", "btnsave_update");
            }
            else if (i == 2)
            {
                Alert_msg(" Not update.Check Ur Import Jobno !", "btnsave_update");
            }
            else if (i == 3)
            {
                Alert_msg(" Not update.Check Ur Export Jobno !", "btnsave_update");
            }
            
        //}
        //else
        //{
        //    Alert_msg(" Check Ur Export Jobno !", "btnsave_update");
        //}
    }

    private void Save_Branch()
    {
        if (ddlbranch.SelectedItem.Text != string.Empty)
        {

            string[] arr = new string[] { };
            string Mode = string.Empty;

            DataSet ds = new DataSet();

            arr = ddlbranch.SelectedItem.Text.Split('(');
            Mode = arr[1].TrimEnd(')');

            if (Mode == "Air")
            {
                JPS.I_PREFIX = txt_Prefix_IA.Text;
                JPS.I_Jobno = txtJobNo_IA.Text;
                JPS.I_Suffix = txt_Suffix_IA.Text;

                JPS.E_PREFIX = txt_Prefix_EA.Text;
                JPS.E_Jobno = txtJobNo_EA.Text;
                JPS.E_Suffix = txt_Suffix_EA.Text;
                JPS.Tr_mode = "Air";
            }
            else if (Mode == "Sea")
            {
                JPS.I_PREFIX = txt_Prefix_IS.Text;
                JPS.I_Jobno = txtJobNo_IS.Text;
                JPS.I_Suffix = txt_Suffix_IS.Text;

                JPS.E_PREFIX = txt_Prefix_ES.Text;
                JPS.E_Jobno = txtJobNo_ES.Text;
                JPS.E_Suffix = txt_Suffix_ES.Text;
                JPS.Tr_mode = "Sea";

            }
            else if (Mode == "Land")
            {
                JPS.I_PREFIX = txt_Prefix_IL.Text;
                JPS.I_Jobno = txtJobNo_IL.Text;
                JPS.I_Suffix = txt_Suffix_IL.Text;

                JPS.E_PREFIX = txt_Prefix_EL.Text;
                JPS.E_Jobno = txtJobNo_EL.Text;
                JPS.E_Suffix = txt_Suffix_EL.Text;
                JPS.Tr_mode = "Land";

            }
           
            JPS.Branch = ddlbranch.SelectedValue.ToString();
           
            JPS.user_Id = currentuser;
            JPS.Working_period = Working_Period;
            //JPS.Branch_Commom = SELECT_BRANCH;
            JPS.Flag = "";
            
            JPS.IMP_EXP_Branch_INS_UPD();
            i = JPS.result;
          
             if (i == 0)
            {
                Alert_msg("Created successfully!", "btnsave_update");
            }
            else if (i == 1)
            {
                Alert_msg("Updated successfully!", "btnsave_update");
            }
            else if (i == 2)
            {
                Alert_msg(" Not update.Check Ur Import or Export Jobno !", "btnsave_update");
            }
        }
    }

   
    private void All_false()
    {
        txt_Prefix_IA.Enabled = false;
        txtJobNo_IA.Enabled = false;
        txt_Suffix_IA.Enabled = false;

        txt_Prefix_IS.Enabled = false;
        txtJobNo_IS.Enabled = false;
        txt_Suffix_IS.Enabled = false;

        txt_Prefix_IL.Enabled = false;
        txtJobNo_IL.Enabled = false;
        txt_Suffix_IL.Enabled = false;

        txt_Prefix_EA.Enabled = false;
        txtJobNo_EA.Enabled = false;
        txt_Suffix_EA.Enabled = false;

        txt_Prefix_ES.Enabled = false;
        txtJobNo_ES.Enabled = false;
        txt_Suffix_ES.Enabled = false;

        txt_Prefix_EL.Enabled = false;
        txtJobNo_EL.Enabled = false;
        txt_Suffix_EL.Enabled = false;
    }

    private void Clear()
    {
        txt_Prefix_IA.Text =string.Empty;
        txtJobNo_IA.Text =string.Empty;
        txt_Suffix_IA.Text =string.Empty;

        txt_Prefix_IS.Text =string.Empty;
        txtJobNo_IS.Text =string.Empty;
        txt_Suffix_IS.Text =string.Empty;

        txt_Prefix_IL.Text = string.Empty;
        txtJobNo_IL.Text = string.Empty;
        txt_Suffix_IL.Text = string.Empty;

        txt_Prefix_EA.Text = string.Empty;
        txtJobNo_EA.Text = string.Empty;
        txt_Suffix_EA.Text = string.Empty;

        txt_Prefix_ES.Text = string.Empty;
        txtJobNo_ES.Text = string.Empty;
        txt_Suffix_ES.Text = string.Empty;

        txt_Prefix_EL.Text = string.Empty;
        txtJobNo_EL.Text = string.Empty;
        txt_Suffix_EL.Text = string.Empty;

        lblimp.Text = string.Empty;
        lblexp.Text = string.Empty;

        All_false();
    }


    public void LoadGroup()
    {

        DataSet dsGrp = new DataSet();
        Comp.COMPANY_ID = "";
        Comp.flag = "Select-Group";
        dsGrp = Comp.RetrieveAll_Groups();
        ddlGrpname.Items.Clear();
        if (dsGrp.Tables.Count > 0)
        {
            ddlGrpname.DataSource = dsGrp.Tables[0];
            ddlGrpname.DataTextField = "GROUP_NAME";
            ddlGrpname.DataValueField = "GROUP_ID";
            ddlGrpname.DataBind();

            ddlGrpname.Items.Remove("");
            ddlGrpname.Items.Insert(0, "");

            if (Session["GroupID"].ToString() != "" && Session["GroupID"].ToString() != null)
            {
                ddlGrpname.SelectedValue = Session["GroupID"].ToString();
            }
            Load_Company_Branch(ddlGrpname.SelectedValue.ToString());
        }
    }


    protected void ddlGrpname_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Company_Branch(ddlGrpname.SelectedValue.ToString());
    }

    public void Load_Company_Branch(string groupid)
    {
        DataSet dsGrp = new DataSet();
        Comp.COMPANY_ID = groupid;
        Comp.BRANCH = "";

        DataSet ds1 = (DataSet)HttpContext.Current.Session["COMPANY_DETAILS_DS"];

        Comp.flag = "Select-Group";
        dsGrp = Comp.RetrieveAll_Groups();
        if (dsGrp.Tables.Count > 1)
        {
            ddlbranch.DataSource = dsGrp.Tables[1];
            ddlbranch.DataTextField = "BRANCH_TRANSPORT_MODE";
            ddlbranch.DataValueField = "BRANCHCODE";
            ddlbranch.DataBind();

            ddlbranch.Items.Remove("");
            ddlbranch.Items.Insert(0, "");

            ViewState["dsGrp"] = dsGrp.Tables[1];
        }

    }

    private void Save_Areawise()
    {
        if (ddlbranch.SelectedItem.Text != string.Empty)
        {

            string[] arr = new string[] { };
            //string Mode = string.Empty;

            DataSet ds = new DataSet();
          
            JPS.I_Jobno = txtJobNo_IA.Text;
            JPS.E_Jobno = txtJobNo_EA.Text;

            JPS.ICA_PREFIX = txt_Prefix_IA.Text;
            JPS.ICA_Suffix = txt_Suffix_IA.Text;
            JPS.ICS_PREFIX = txt_Prefix_IS.Text;
            JPS.ICS_Suffix = txt_Suffix_IS.Text;
            JPS.ICL_PREFIX = txt_Prefix_IL.Text;
            JPS.ICL_Suffix = txt_Suffix_IL.Text;

            JPS.ECA_PREFIX = txt_Prefix_EA.Text;
            JPS.ECA_Suffix = txt_Suffix_EA.Text;
            JPS.ECS_PREFIX = txt_Prefix_ES.Text;
            JPS.ECS_Suffix = txt_Suffix_ES.Text;
            JPS.ECL_PREFIX = txt_Prefix_EL.Text;
            JPS.ECL_Suffix = txt_Suffix_EL.Text;

            JPS.Branch = ddlbranch.SelectedValue.ToString();
            JPS.user_Id = currentuser;
            JPS.Working_period = Working_Period;
            JPS.Flag = "";
            JPS.Tr_mode = Mode;
            JPS.GroupName = ddlGrpname.SelectedItem.Text;
            JPS.CusHouse = txt_Cushouse.Text;
             
            JPS.IMP_EXP_Areawise_INS_UPD();
            i = JPS.result;
            if (i == 0)
            {
                Alert_msg("Created successfully!", "btnsave_update");
            }
            else if (i == 1)
            {
                Alert_msg("Updated successfully!", "btnsave_update");
            }
            else if (i == 2)
            {
                Alert_msg(" Not update.Check Ur Import or Export Jobno !", "btnsave_update");
            }
        }
    }


    protected void btn_view_Click(object sender, EventArgs e)
    {

    }
}