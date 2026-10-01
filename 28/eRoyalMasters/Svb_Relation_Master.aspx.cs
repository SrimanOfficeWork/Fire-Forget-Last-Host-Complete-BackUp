using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class eRoyalMasters_Svb_Relation_Master : ThemeClass
{
    public int i;

    AppSession aps = new AppSession();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
    ErrorLogs er = new ErrorLogs();
    Svb_Relation SVR = new Svb_Relation();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
            currentuser = Session["currentuser"].ToString();
            currentbranch = Session["currentbranch"].ToString();
            currentcomp_name = Session["currentcomp_name"].ToString();
            comp_ConnectionStr = Session["currentcomp_db"].ToString();
            Working_Period = Session["WorkingPeriod"].ToString();
            LoginDate = Session["LoginDate"].ToString();

            if (!IsPostBack)
            {
                ddlterms_load();
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnNew.Visible = true;
                btnSave.Visible = true;

                Edit_ClientDetails();
            }
            hdfTransport_mode.Value = "";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
       
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (chkSVB_All_Suppliers.Checked == true)
            {
                string flg = "S_All_Suppliers";
                string Id = "";
                insert_update(flg, Id);
                if (i == 1)
                {
                    Alert_msg("Saved Successfully", "btnNew");
                }
                else if (i == 2)
                {
                    Alert_msg("Relation- Already Exists..!!", "btnNew");
                }
                else if (i == 4)
                {
                    Alert_msg("Importer Name - Not Available in Master", "btnNew");
                }
            }
            else
            {
                string flg = "S";
                string Id = "";
                insert_update(flg, Id);
                if (i == 1)
                {
                    Alert_msg("Saved Successfully", "btnNew");
                }
                else if (i == 2)
                {
                    Alert_msg("Relation- Already Exists..!!", "btnNew");
                }
                else if (i == 3)
                {
                    Alert_msg("Supplier Name - Not Available in Master", "btnNew");
                }
                else if (i == 4)
                {
                    Alert_msg("Importer Name - Not Available in Master", "btnNew");
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
       
    }

    public int insert_update(string flg ,string Id)
    {
        try
        {
            SVR.SVB_ID_N = Id;
            SVR.IMP_NAME = txtimpexpname.Text;
            SVR.SUPPLIER_NAME = txtsup_name.Text;
            SVR.RELATION = txtRelation.Text;
            SVR.BASE = txtBase.Text;
            SVR.CONDITION = txtCondition.Text;
            SVR.SVB_RELATION = chkSVB_Relation.Checked == true ? "Y" : "N";
            SVR.SVB_REF_NO = txtSVB_RefNo.Text;
            SVR.SVB_REF_DATE = txtSVBDate.Text;
            SVR.SVB_CUSTOM_HOUSE = txtCustomsHouse.Text;
            SVR.SVB_LOADING_ON = ddlLoadingOn.SelectedItem.Text;
            SVR.SVB_ASSESABLE_RATE = txtAssesable_Rate.Text;
            SVR.SVB_DUTY_RATE = txtDuty_Rate.Text;
            SVR.SVB_ASSESABLE_STATUS = ddlAssesable_Status.SelectedItem.Text;
            SVR.SVB_DUTY_STATUS = ddlDuty_Status.SelectedItem.Text;
            SVR.USER_ID = currentuser;

            SVR.BRANCH_CODE = currentbranch;
            SVR.WORKING_PERIOD = Working_Period;
            SVR.flag = flg;

            SVR.BOND_NO = txtBond_No.Text;
            SVR.BOND_LOCATION = txtBondLocation.Text;
            SVR.BOND_TYPE = ddlBondType.SelectedItem.Text;
            SVR.SVB_APPLICABLE_ALL_SUPP = chkSVB_All_Suppliers.Checked == true ? "Y" : "N";

            i = SVR.SVB_Relation_Insert_update();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
       return i;
    }
    public void Clear()
    {
        try
        {
            txtimpexpname.Text = "";
            txtsup_name.Text = "";
            txtRelation.Text = "";
            txtBase.Text = "";
            txtCondition.Text = "";
            txtSVB_RefNo.Text = "";
            txtSVBDate.Text = "";
            txtCustomsHouse.Text = "";
            ddlLoadingOn.SelectedIndex = -1;
            txtAssesable_Rate.Text = "";
            txtDuty_Rate.Text = "";
            ddlAssesable_Status.SelectedIndex = -1;
            ddlDuty_Status.SelectedIndex = -1;
            txtBond_No.Text = "";
            txtBondLocation.Text = "";
            ddlBondType.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
       
    }

    private void ddlterms_load()
    {
        try
        {
            ddlLoadingOn.Items.Add(new ListItem(" ", ""));
            ddlLoadingOn.Items.Add(new ListItem("Assessable", "Assessable"));
            ddlLoadingOn.Items.Add(new ListItem("Duty", "Duty"));
            ddlLoadingOn.Items.Add(new ListItem("Both", "Both"));

            ddlAssesable_Status.Items.Add(new ListItem(" ", ""));
            ddlAssesable_Status.Items.Add(new ListItem("Provisional", "Provisional"));
            ddlAssesable_Status.Items.Add(new ListItem("Final", "Final"));

            ddlDuty_Status.Items.Add(new ListItem(" ", ""));
            ddlDuty_Status.Items.Add(new ListItem("Provisional", "Provisional"));
            ddlDuty_Status.Items.Add(new ListItem("Final", "Final"));

            ddlBondType.Items.Add("CE, central excise cert");
            ddlBondType.Items.Add("DE, DEEC Bond");
            ddlBondType.Items.Add("EU, End use Bond");
            ddlBondType.Items.Add("EO, EOU Bond");
            ddlBondType.Items.Add("EC, EPCG Bond");
            ddlBondType.Items.Add("EZ, EPZ Bond");
            ddlBondType.Items.Add("IT, ITC Bond");
            ddlBondType.Items.Add("JB, Jobbing");
            ddlBondType.Items.Add("LG, Letter of guarantee");
            ddlBondType.Items.Add("MS, Misc. cert");
            ddlBondType.Items.Add("PJ, Project Bond");
            ddlBondType.Items.Add("PD, Provisional duty bond");
            ddlBondType.Items.Add("RE, Re-export Bond");
            ddlBondType.Items.Add("TB, Test Bond");
            ddlBondType.Items.Add("TP, Transhipment Bond");
            ddlBondType.Items.Add("UT, Undertaking");
            ddlBondType.Items.Add("WH, Warehouse Bond");
            ddlBondType.Items.Add("NB,  National Bond");
            ddlBondType.Items.Add("PI, Project Imports");
            ddlBondType.Items.Add("EI, IGCR");
            ddlBondType.Items.Add("GB, General Common Bond");
            ddlBondType.Items.Add("SZ, SEZ Bond");
            ddlBondType.Items.Add("PG, Provisional duty Bond Global for SEZ");


            ddlBondType.Items.Add("P1, 	Carotar-PSU/Government  (Central/State and their Undertakings)	");
            ddlBondType.Items.Add("P2, 	Carotar -  All other categories including AEO	");
            ddlBondType.Items.Add("P3, 	SVB  -  All  other  importers  in  case  of initial period till non-compliance as per cir 05/2016");
            ddlBondType.Items.Add("P4, 	SVB - AEO T1 in case of initial period till non compliance as per cir 05/2016");
            ddlBondType.Items.Add("P5, 	SVB - AEO T2 in case of initial period till non compliance as per cir 05/2016");
            ddlBondType.Items.Add("P6, 	SVB a. AEO T3 b. PSUs, Government");
            ddlBondType.Items.Add("P7, 	Chemical Test –a. AEO T3,b.  PSU/Government  (Central/State  and their Undertakings)");
            ddlBondType.Items.Add("P8, 	Chemical Test - AEO T2	");
            ddlBondType.Items.Add("P9, 	Chemical Test - AEO T1	");
            ddlBondType.Items.Add("PA, 	Chemical Test - Others	");
            ddlBondType.Items.Add("PB, 	Carotar - Cases selected on random basis for verification of origin	");
            ddlBondType.Items.Add("PZ, 	Officer Determined	");
            ddlBondType.Items.Add("E1, 	EPCG/AA/DFIA  -a.  Export  turnover  more  than  5  crores (goods or services) in preceeding year b. Public Sector Undertaking c.  Star  Export  House  (Status  Holder) registered   with   GST   authorities   and exporting  in  preyious  2  FY  having  min export of 1 crore d. registered with GST and paid GST of 1 cr or more in previous FY	");
            ddlBondType.Items.Add("E2, 	EPCG/AA/DFIA – a.    not    covered    under    Sl.    no.    2.1 (a,b,c,d,e) of Circular 17/2009-Cus dated 25.05.2009 b. Units in AEZ c.   Established   Service   Providers   who have free FOREX earning of 50 lakhs or more during previous FY	");
            ddlBondType.Items.Add("E3, 	EPCG/AA/DFIA – a. Service providers handling sector who are     appointed     as     Custodians     by concerned jurisdictions	");
            ddlBondType.Items.Add("E4, 	Others");
            ddlBondType.Items.Add("EZ, 	Officer Determined");
            ddlBondType.Items.Add("R1, 	Container");
            ddlBondType.Items.Add("R2, 	Jobbing");
            ddlBondType.Items.Add("RZ, 	Officer Determined");
            ddlBondType.Items.Add("D1, 	Section 143	");
            ddlBondType.Items.Add("DZ, 	Officer Determined");
            ddlBondType.Items.Add("W1, 	a.  Other  than  AEO  Clients  -  sensitive goods stored for a period beyond 2 years b.   non-sensitive   goods   stored   for   a period beyond 3 years");
            ddlBondType.Items.Add("W2, 	a.  Non  AEO  Clients  -  Non  sensitive goods stored 2-3 years b. AEO T1 Non Sensitive goods stored more than 3 years c.  Non  AEO  Clients  -  Sensitive  goods stored for 1-2 years d. AEO T1 clients sensitive goods stored beyond 2 years e. Gold, silver, other precious metals and articles thereof warehoused by AEO T1 Clients beyond 1 year");
            ddlBondType.Items.Add("W3, 	a.  non-sensitive  goods  stored  for  1-2 year by importers other than AEO b.  non  sensitive  goods  stored  for  2-3 year by AEO T1 c.  non sensitive  goods  stored  beyond  3 years by  AEO T2 d.  sensitive  goods  stored  for  1-2  years by AEO T1 clients e. sensitive goods stored for more than 2 years by AEO T2 Clients f. Gold, silver, other precious metals and e.  articles thereof warehoused by AEO T2 Clients beyond 1 year");
            ddlBondType.Items.Add("W4, 	a.  Non  sensitive  goods  -  AEO  T1  for period 1-2 years b.  Non  Sensitive goods  stored by AEO T2 stored for 2-3 years c.  Sensitive  Goods  -  AEO  T2  for  1-2 years");
            ddlBondType.Items.Add("W5, 	Non Sensitive goods stored for 1-2 years for AEO T2	");
            ddlBondType.Items.Add("W6, 	a. AEO T3 b.  non  sensitive  goods  stored  for  initial period of 1 year c.   goods   warehoused   for   supply   to diplomats d.  warehoused  and  sold  through  duty free  shops,  warehoused  for  supply  as ship stores/airlines e. Gold, silver, other precious metals and articles thereof warehoused by AEO T3 Clients");
            ddlBondType.Items.Add("W7, 	sensitive goods stored beyond 1 year in private warehouse	");
            ddlBondType.Items.Add("W8, 	a. Sensitive goods stored for 0-1 year, if sensitive   goods   are   proposed   to   be removed from public bonded warehouse to private bonded warehouse b. Gold, silver, other precious metals and articles  thereof  warehoused  at  the  time of deposit (Other than AEO)");
            ddlBondType.Items.Add("W9, 	Gold,  silver,  other  precious  metals  and articles  thereof  warehoused  at  the  time of deposit by AEO T1 Clients	");
            ddlBondType.Items.Add("WA, 	Gold,  silver,  other  precious  metals  and articles  thereof  warehoused  at  the  time of deposit by AEO T2 Clients	");
            ddlBondType.Items.Add("WZ, 	Officer Determined");
            ddlBondType.Items.Add("M1, 	MOOWR in Private Warehouse");
            ddlBondType.Items.Add("MZ, 	Officer Determined");
            ddlBondType.Items.Add("S1, 	MOOWR in Special Warehouse");
            ddlBondType.Items.Add("SZ, 	Officer Determined");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
      
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (chkSVB_All_Suppliers.Checked == true)
            {
                string flg = "U_All_Suppliers";
                string Id = Request.QueryString["SVB_ID"].ToString();
                insert_update(flg, Id);
                if (i == 1)
                {
                    Alert_msg("Updated Successfully", "btnNew");
                }
                else if (i == 4)
                {
                    Alert_msg("Importer Name - Not Available in Master", "btnNew");
                }
            }
            else
            {
                string flg = "U";
                string Id = Request.QueryString["SVB_ID"].ToString();
                i = insert_update(flg, Id);
                if (i == 1)
                {
                    Alert_msg("Updated Successfully", "btnNew");
                }
                else if (i == 3)
                {
                    Alert_msg("Supplier Name - Not Available in Master", "btnNew");
                }
                else if (i == 4)
                {
                    Alert_msg("Importer Name - Not Available in Master", "btnNew");
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }


    public void Edit_ClientDetails()
    {
        try
        {
            if (Request.QueryString["SVB_ID"] != "" && Request.QueryString["SVB_ID"] != null)
            {
                int i = 0;

                DataSet ds = new DataSet();
                SVR.SVB_ID_N = Request.QueryString["SVB_ID"].ToString();
                SVR.flag = "Select";

                ds = SVR.SVB_Select();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtimpexpname.Text = ds.Tables[0].Rows[0]["IMP_NAME"].ToString();
                    txtsup_name.Text = ds.Tables[0].Rows[0]["SUPPLIER_NAME"].ToString();
                    txtRelation.Text = ds.Tables[0].Rows[0]["RELATION"].ToString();
                    txtBase.Text = ds.Tables[0].Rows[0]["BASE"].ToString();
                    txtCondition.Text = ds.Tables[0].Rows[0]["CONDITION"].ToString();

                    if (ds.Tables[0].Rows[0]["SVB_RELATION"].ToString() == "Y")
                    {
                        chkSVB_Relation.Checked = true;
                        txtSVB_RefNo.Enabled = true;
                        txtSVBDate.Enabled = true;
                        txtCustomsHouse.Enabled = true;
                        ddlLoadingOn.Enabled = true;

                        txtSVB_RefNo.Text = ds.Tables[0].Rows[0]["SVB_REF_NO"].ToString();
                        txtSVBDate.Text = ds.Tables[0].Rows[0]["SVB_REF_DATE"].ToString();
                        txtCustomsHouse.Text = ds.Tables[0].Rows[0]["SVB_CUSTOM_HOUSE"].ToString();

                        if (ds.Tables[0].Rows[0]["SVB_LOADING_ON"].ToString() == "A")
                        {
                            txtAssesable_Rate.Enabled = true;
                            ddlAssesable_Status.Enabled = true;

                            txtDuty_Rate.Enabled = false;
                            ddlDuty_Status.Enabled = false;

                            ddlLoadingOn.SelectedValue = "Assessable";

                            txtAssesable_Rate.Text = ds.Tables[0].Rows[0]["SVB_ASSESABLE_RATE"].ToString();

                            if (ds.Tables[0].Rows[0]["SVB_ASSESABLE_STATUS"].ToString() == "P")
                            {
                                ddlAssesable_Status.SelectedValue = "Provisional";
                            }
                            else if (ds.Tables[0].Rows[0]["SVB_ASSESABLE_STATUS"].ToString() == "F")
                            {
                                ddlAssesable_Status.SelectedValue = "Final";
                            }
                            else if (ds.Tables[0].Rows[0]["SVB_ASSESABLE_STATUS"].ToString() == "")
                            {
                                ddlAssesable_Status.SelectedValue = "";
                            }

                            if (ddlAssesable_Status.SelectedValue == "Provisional")
                            {
                                txtBond_No.Enabled = true;
                                txtBondLocation.Enabled = true;
                                ddlBondType.Enabled = true;

                                txtBond_No.Text = ds.Tables[0].Rows[0]["BOND_NO"].ToString();
                                txtBondLocation.Text = ds.Tables[0].Rows[0]["BOND_LOCATION"].ToString();
                                ddlBondType.Text = ds.Tables[0].Rows[0]["BOND_TYPE"].ToString();
                            }
                            else
                            {
                                txtBond_No.Enabled = false;
                                txtBondLocation.Enabled = false;
                                ddlBondType.Enabled = false;

                                txtBond_No.Text = "";
                                txtBondLocation.Text = "";
                                ddlBondType.Text = "";
                            }

                        }
                        else if (ds.Tables[0].Rows[0]["SVB_LOADING_ON"].ToString() == "D")
                        {
                            txtDuty_Rate.Enabled = true;
                            ddlDuty_Status.Enabled = true;

                            txtAssesable_Rate.Enabled = false;
                            ddlAssesable_Status.Enabled = false;

                            ddlLoadingOn.SelectedValue = "Duty";
                            txtDuty_Rate.Text = ds.Tables[0].Rows[0]["SVB_DUTY_RATE"].ToString();

                            if (ds.Tables[0].Rows[0]["SVB_DUTY_STATUS"].ToString() == "P")
                            {
                                ddlDuty_Status.SelectedValue = "Provisional";
                            }
                            else if (ds.Tables[0].Rows[0]["SVB_DUTY_STATUS"].ToString() == "F")
                            {
                                ddlDuty_Status.SelectedValue = "Final";
                            }
                            else if (ds.Tables[0].Rows[0]["SVB_DUTY_STATUS"].ToString() == "")
                            {
                                ddlDuty_Status.SelectedValue = "";
                            }

                            if (ddlDuty_Status.SelectedValue == "Provisional")
                            {
                                txtBond_No.Enabled = true;
                                txtBondLocation.Enabled = true;
                                ddlBondType.Enabled = true;

                                txtBond_No.Text = ds.Tables[0].Rows[0]["BOND_NO"].ToString();
                                txtBondLocation.Text = ds.Tables[0].Rows[0]["BOND_LOCATION"].ToString();
                                ddlBondType.Text = ds.Tables[0].Rows[0]["BOND_TYPE"].ToString();
                            }
                            else
                            {
                                txtBond_No.Enabled = false;
                                txtBondLocation.Enabled = false;
                                ddlBondType.Enabled = false;

                                txtBond_No.Text = "";
                                txtBondLocation.Text = "";
                                ddlBondType.Text = "";
                            }
                        }
                        else if (ds.Tables[0].Rows[0]["SVB_LOADING_ON"].ToString() == "B")
                        {
                            txtAssesable_Rate.Enabled = true;
                            ddlAssesable_Status.Enabled = true;

                            txtDuty_Rate.Enabled = true;
                            ddlDuty_Status.Enabled = true;

                            ddlLoadingOn.SelectedValue = "Both";

                            txtAssesable_Rate.Text = ds.Tables[0].Rows[0]["SVB_ASSESABLE_RATE"].ToString();
                            ddlAssesable_Status.SelectedIndex = -1;

                            txtDuty_Rate.Text = ds.Tables[0].Rows[0]["SVB_DUTY_RATE"].ToString();


                            if (ds.Tables[0].Rows[0]["SVB_DUTY_STATUS"].ToString() == "P")
                            {
                                ddlDuty_Status.SelectedValue = "Provisional";
                            }
                            else if (ds.Tables[0].Rows[0]["SVB_DUTY_STATUS"].ToString() == "F")
                            {
                                ddlDuty_Status.SelectedValue = "Final";
                            }
                            else if (ds.Tables[0].Rows[0]["SVB_DUTY_STATUS"].ToString() == "")
                            {
                                ddlDuty_Status.SelectedValue = "";
                            }


                            if (ds.Tables[0].Rows[0]["SVB_ASSESABLE_STATUS"].ToString() == "P")
                            {
                                ddlAssesable_Status.SelectedValue = "Provisional";
                            }
                            else if (ds.Tables[0].Rows[0]["SVB_ASSESABLE_STATUS"].ToString() == "F")
                            {
                                ddlAssesable_Status.SelectedValue = "Final";
                            }
                            else if (ds.Tables[0].Rows[0]["SVB_ASSESABLE_STATUS"].ToString() == "")
                            {
                                ddlAssesable_Status.SelectedValue = "";
                            }

                            if (ddlAssesable_Status.SelectedValue == "Provisional" || ddlDuty_Status.SelectedValue == "Provisional")
                            {
                                txtBond_No.Enabled = true;
                                txtBondLocation.Enabled = true;
                                ddlBondType.Enabled = true;

                                txtBond_No.Text = ds.Tables[0].Rows[0]["BOND_NO"].ToString();
                                txtBondLocation.Text = ds.Tables[0].Rows[0]["BOND_LOCATION"].ToString();
                                ddlBondType.Text = ds.Tables[0].Rows[0]["BOND_TYPE"].ToString();
                            }
                            else
                            {
                                txtBond_No.Enabled = false;
                                txtBondLocation.Enabled = false;
                                ddlBondType.Enabled = false;

                                txtBond_No.Text = "";
                                txtBondLocation.Text = "";
                                ddlBondType.Text = "";
                            }
                        }
                        else
                        {
                            ddlLoadingOn.SelectedValue = "";
                        }

                        if (ds.Tables[0].Rows[0]["SVB_APPLICABLE_ALL_SUPP"].ToString() == "Y")
                        {
                            chkSVB_All_Suppliers.Checked = true;
                        }
                        else
                        {
                            chkSVB_All_Suppliers.Checked = false;
                        }
                    }
                    else
                    {

                    }
                    HiddenField1.Value = Request.QueryString["SVB_ID"].ToString();
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                }

            }
            else
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
      
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            eroyalmaster erm = new eroyalmaster();
        
            erm.SVB_ID = HiddenField1.Value;
            erm.IMP_NAME = "0";
            erm.Ename = "delete";
            erm.EWorking_Period = Working_Period;
            erm.RetrieveAll_SVB_MASTER();

            int ii = 0;
            ii = erm.result;

            if (ii > 0)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('SVB Importer Deleted', 'SVB RELATION MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
            else
            {
                Alert_msg("SVB Importer Not Deleted");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SVB RELATION MASTER', function (r) {}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SVB RELATION MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

}