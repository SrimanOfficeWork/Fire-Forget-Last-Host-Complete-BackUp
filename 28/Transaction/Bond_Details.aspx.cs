using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Data;

public partial class Transaction_Bond_Details : ThemeClass
{
    Transaction Transact = new Transaction();
    SqlConnection con;
    SqlCommand cmd;
    DataTable dt = new DataTable();

    DataSet dtuser = new DataSet();
    DataSet dss = new DataSet();
    AppSession aps = new AppSession();

    public string Trans_ID = "", IGMSLNO = "", Audit_YN = "";
    ErrorLogs er = new ErrorLogs();
    public int i, j, k, l;
    public string AUTO_ID;
    string SP_QUERY;


    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string IGM_Transportmode, IMPORT_JOBNO, IMPORT_JOBDATE, FILING_STAUS, Flight_Vesseldate = "", IGMDATE = "", GATEWAY_IGMDATE = "";
    public string sno = "", flag = "", IGM_SLNO_UPDATE = "", BOND_ID = "", CONTAINER_ID = "", CERTIFICATE_ID = "";
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE;
    public string SELECT_TYPE, SELECT_BRANCH, COMPANY_ID;

    User_Creation user_Create = new User_Creation();
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
            COMPANY_ID = Connection.COMPANYID();
            // commented for areawise implementation on 05-mar-2020

            SELECT_BRANCH = Connection.Get_Company_Type();

            if (Session["IMPORT_JOBNO"] != null || Session["IMPORT_JOBDATE"] != null || Session["TRANSPORT_MODE"] != null)
            {
                hdfTransport_mode.Value = Session["TRANSPORT_MODE"].ToString();
                hdn_Customhouse_chk.Value = "Yes";
                IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
                IMPORT_JOBDATE = Session["IMPORT_JOBDATE"].ToString();

                if (!IsPostBack)
                {
                    txtBondLocation.Text = Session["CUSTOMHOUSE_CODE"].ToString();
                }
            }
            else
            {
                //Response.Write("<script>window.open('IGM_Details.aspx','_parent');</script>");
                Response.Write("<script>window.parent.document.getElementById('IGM').click();</script>");
            }

            if (Connection.Audit_Logs(COMPANY_ID) == "Y")
            {
                Audit_YN = "Y";
            }

            if (!IsPostBack)
            {
                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 7;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//

                if (COMPANY_ID == "293" || COMPANY_ID == "1" || COMPANY_ID == "10")
                {
                    pop_text_area_transac_popup_inn_container_left_IGM_Bond.Visible = true;
                }
                else
                {
                    pop_text_area_transac_popup_inn_container_left_IGM_Bond.Visible = false;
                }

                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btn_save_new.Visible = true;
                btnNew.Visible = true;
                txtBondNo.Focus();
                Gridbind_BOND();
                ddlBond_Type();
            }

            if (Session["JOB_LOCK"] != null && Session["JOB_LOCK"] != "")
            {
                JOB_LOCK = Session["JOB_LOCK"].ToString();

                if (Convert.ToInt32(JOB_LOCK) == 1)
                {
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnNew.Enabled = false;
                    btnSave.Enabled = false;
                    btn_save_new.Enabled = false;

                    btnNew.ToolTip = "This Job is Locked by Admin";
                    btnSave.ToolTip = "This Job is Locked by Admin";
                    btnUpdate.ToolTip = "This Job is Locked by Admin";
                    btnDelete.ToolTip = "This Job is Locked by Admin";
                    btn_save_new.ToolTip = "This Job is Locked by Admin";
                }
            }

            if (Session["USER_JOB_LOCK"].ToString() == "Yes")
            {
                if (currentuser.ToUpper() != Session["JOB_USER"].ToString().ToUpper())
                {
                    if (Session["JOB_RELEASE"] != null && Session["JOB_RELEASE"] != "")
                    {
                        JOB_RELEASE = Session["JOB_RELEASE"].ToString();

                        if (JOB_RELEASE == "No")
                        {

                            btnUpdate.Enabled = false;
                            btnDelete.Enabled = false;
                            btnNew.Enabled = false;
                            btnSave.Enabled = false;
                            btn_save_new.Enabled = false;

                            MP_U.Show();

                            lblUser_Msg.Text = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                            btnUpdate.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnDelete.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnNew.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnSave.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btn_save_new.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";

                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
           
        }

    }

    public void Page_Rights(int i)
    {
        try
        {
            user_Create.RetrieveAll_User_Screen_Rights_Details(i);
            PAGE_WRITE = user_Create.PAGE_WRITE;
            PAGE_READ = user_Create.PAGE_READ;
            PAGE_MODIFY = user_Create.PAGE_MODIFY;
            PAGE_DELETE = user_Create.PAGE_DELETE;
            hdn_Grid_Disable.Value = "";

            //---------------READ ONLY------------------//

            if (PAGE_READ == "False")
            {
                btnSave.Enabled = false;
                btn_save_new.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                btnNew.ToolTip = "You don't have permission to access";
                btnSave.ToolTip = "You don't have permission to access";
                btn_save_new.ToolTip = "You don't have permission to access";
                btnUpdate.ToolTip = "You don't have permission to access";
                btnDelete.ToolTip = "You don't have permission to access";
                hdn_Grid_Disable.Value = "1";
            }
            else
            {


                //}
                //btnNew.Enabled = true;
                //---------------SAVE BUTTON------------------//
                if (PAGE_WRITE == "True")
                {
                    btnSave.Enabled = true;
                    btn_save_new.Enabled = true;
                    btnNew.Enabled = true;

                }
                else
                {
                    btnSave.Enabled = false;
                    btn_save_new.Enabled = false;
                    btnSave.ToolTip = "You don't have permission to access";
                    btn_save_new.ToolTip = "You don't have permission to access";
                    btnNew.Enabled = false;

                }
                //---------------UPDATE BUTTON------------------//

                if (PAGE_MODIFY == "True")
                {
                    btnUpdate.Enabled = true;
                    hdn_Grid_Disable.Value = "";


                }
                else
                {
                    btnUpdate.Enabled = false;
                    btnUpdate.ToolTip = "You don't have permission to access";
                    hdn_Grid_Disable.Value = "1";


                }
                //---------------DELETE BUTTON------------------//

                if (PAGE_DELETE == "True")
                {
                    btnDelete.Enabled = true;
                    hdn_Grid_Disable.Value = "";


                }
                else
                {
                    btnDelete.Enabled = false;
                    btnDelete.ToolTip = "You don't have permission to access";
                    hdn_Grid_Disable.Value = "1";


                }
            }
            if (hdn_Grid_Disable.Value == "1")
                gv_BOND.ToolTip = "You don't have permission to access";

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
           
        }
    }

    public void ddlBond_Type()
    {
        try
        {
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
            ddlBondType.Items.Add("NB, National Bond");
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
           
        }

    }

    public void Gridbind_BOND()
    {
        try
        {
            DataSet ds_bond = new DataSet();
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.BOND_NO = "0";
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            Transact.Ename = "select_con";
            ds_bond = Transact.RetrieveAll_BOND_Details();
            gv_BOND.DataSource = ds_bond.Tables[0];
            gv_BOND.DataBind();

            //------------------Audit Modified column History-------------------
            if (Audit_YN == "Y")
            {
                Tbl_Filed_Modified_History(ds_bond.Tables[1]);
            }
            //-----------------------------------------------------------------

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
           
        }


    }

    //
    public void BOND_insert_update(string IMPORT_JOBNO, string BOND_ID, string flag, string year)//
    {
        try
        {
            Transact.BONDID = BOND_ID;
            Transact.JOBNO = IMPORT_JOBNO;//call session value from general details
            Transact.BOND_NO = txtBondNo.Text;
            Transact.BOND_TYPE = ddlBondType.SelectedValue;
            Transact.BOND_LOCATION = txtBondLocation.Text.ToUpper();

            Transact.USER_ID = currentuser;
            Transact.flag = flag;
            Transact.BRANCH_CODE = currentbranch;
            Transact.YEAR = year;
            Transact.WORKING_PERIOD = Working_Period;
            Transact.BRANCH_COMMON = SELECT_BRANCH;
            Transact.BOND_AMT = txt_Amt.Text;

            //dss = Transact.BOND_Details_insertupdate();
            gv_BOND.DataSource = Transact.BOND_Details_insertupdate();

            gv_BOND.DataBind();

            i = Transact.result;
            //Grid_Empty();
            if (i == 1)
            {
                Transact.Imp_Job_Logs_All_Details(IMPORT_JOBNO, "", "", "Bond", flag, "Insert");
            }
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

            ddlBondType.Items.Clear();
            ddlBond_Type();
            Transact.ResetFields(Page.Controls);
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btn_save_new.Visible = true;
            btnNew.Visible = true;
            btnUpdate.CssClass = "updates";

            ViewState["UPDATED_ID"] = null;
            hdn_update_Bond.Value = "";
            Gridbind_BOND();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
           
        }
       
    }

    protected void gv_BOND_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["BONDID"] = Convert.ToString(this.gv_BOND.SelectedDataKey.Value);

            if (ViewState["BONDID"] != "" && ViewState["BONDID"] != null)
            {

                txtBondNo.Text = gv_BOND.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");

                ViewState["BONDNO"] = txtBondNo.Text;

                ddlBondType.Items.Clear();
                string bond_type = gv_BOND.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");

                //ddlBondType.Items.Add("F");
                //ddlBondType.Items.Add("L");
                ddlBond_Type();
                ddlBondType.Items.Remove(bond_type);
                ddlBondType.Items.Insert(0, bond_type);
                txtBondLocation.Text = gv_BOND.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");

                txt_Amt.Text = gv_BOND.SelectedRow.Cells[4].Text.Replace("&nbsp;", ""); // ajith added 

                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = ViewState["BONDID"].ToString();
                hdn_update_Bond.Value = ViewState["BONDID"].ToString();

                // ajith added
                string availableAmt = GET_BOND_AVAILE_AMT_UPDATE(
                                  txtBondNo.Text,
                                  txtBondLocation.Text,
                                  bond_type);


                txt_avail.Text = availableAmt;
                //

                //FOR UPDATED SUCCESSFULLY
                btnUpdate.CssClass = "updates";

                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btn_save_new.Visible = false;
                btnNew.Visible = true;

                // ----Audit Modified Data -----------------------------------
                if (Audit_YN == "Y")
                {
                    DataTable_Mapping_Controls((DataTable)ViewState["dt_Prev_Table"]);
                }
                //------------------------------------------------------------

            }
            else
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btn_save_new.Visible = true;
                btnNew.Visible = true;


            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
           
        }
    }
    protected void gv_BOND_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //  if Read Permiision given true for gridview enabled or Disabled----------//
                if (hdn_Grid_Disable.Value == "1")
                {

                    e.Row.Enabled = false;

                }
                else
                {
                    e.Row.Enabled = true;

                    e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                    //e.Row.Attributes["onmouseout"] = "this.style.background='white'";
                    e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_BOND, "Select$" + e.Row.RowIndex.ToString()));


                }
                //  if Read Permiision given true for gridview enabled or Disabled----------//

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
           
        }
    }
    protected void gv_BOND_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gv_BOND.PageIndex = e.NewPageIndex;
            Gridbind_BOND();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
           
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string flag = "U", year = "";
            //BOND_ID = ViewState["BONDID"].ToString();
            BOND_ID = hdn_update_Bond.Value;

            BOND_insert_update(IMPORT_JOBNO, BOND_ID, flag, year);

            if (i == 1)
            {
                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("Bond Updated Successfully", "btnUpdate");
                }
                else
                {
                    Alert_msg("Bond Saved Successfully", "btnUpdate");

                }
                //------------------Audit Modified column History-------------------
                if (Audit_YN == "Y")
                {
                    Audit_Modified_DataTableComparer();
                }
                //------------------------------------------------------------------

            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
                Alert_msg("Bond Not Saved", "btnUpdate");
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

            Transact.JOBNO = IMPORT_JOBNO;

            Transact.BOND_NO = ViewState["BONDNO"].ToString();

            Transact.WORKING_PERIOD = Working_Period;
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            //Transact.flag = "";

            Transact.Ename = "delete";
            gv_BOND.DataSource = Transact.RetrieveAll_BOND_Details();

            gv_BOND.DataBind();
            //dss = Transact.RetrieveAll_BOND_Details();
            //Grid_Empty();

            int ii = 0;
            ii = Transact.result;

            if (ii == 1)
            {
                Transact.Imp_Job_Logs_All_Details(IMPORT_JOBNO, "", "", "Bond", "D", "Insert");
                //lblMsg.Text = " Record Deleted";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record  Deleted')</script>", false);
                btnNew_Click(sender, e);
                Alert_msg("Bond Deleted");

                //Gridbind_BOND();
            }


            else
            {
                //lblMsg.Text = " Record Not Deleted";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Deleted')</script>", false);
                Alert_msg("Bond Not Deleted");

            }
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
            string flag = "S", year = "";
            BOND_ID = "0";
            BOND_insert_update(IMPORT_JOBNO, BOND_ID, flag, year);
            hdn_update_Bond.Value = Convert.ToString(Transact.UPDATE_ID);

            if (i == 1)
            {


                //-----------------------FOR USER RIGHTS--------------------------------//
                user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);

                PAGE_MODIFY = user_Create.PAGE_MODIFY;


                //---------------SAVE ONLY------------------//

                if (PAGE_MODIFY == "False")
                {
                    btnNew_Click(sender, e);

                }
                else
                {
                    btnUpdate.CssClass = "save";
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    btn_save_new.Visible = false;
                    btnSave.Focus();
                }
                //-----------------------FOR USER RIGHTS--------------------------------//




                ViewState["UPDATED_ID"] = null;
                Alert_msg("Bond Saved Successfully", "btnSave");

            }
            else if (i == 2)
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Bond No Already Exist')</script>", false);
                Alert_msg("Bond No Already Exist!", "btnSave");

            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
                Alert_msg("Bond Not Saved", "btnSave");

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
           
        }
    }
    protected void gv_BOND_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
           
        }
    }

    public void Grid_Empty()
    {
        try
        {
            if (dss.Tables.Count > 0)
            {
                if (dss.Tables[0].Rows.Count > 0)
                {
                    gv_BOND.DataSource = dss;

                    gv_BOND.DataBind();
                }
                else
                {
                    gv_BOND.DataSource = dt;//add empty row

                    gv_BOND.DataBind();
                }

            }
            else
            {
                gv_BOND.DataSource = dt;//add empty row

                gv_BOND.DataBind();

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
           
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BOND', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BOND', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btn_save_new_Click(object sender, EventArgs e)
    {
        try  
        {
            btnSave_Click(sender, e);
            if (i == 1)
            {
                btnNew_Click(sender, e);
            }
        }
         catch (Exception ex)
         {
           er.makeLog(ex.Message);
          
         }
    }

    private void Tbl_Filed_Modified_History(DataTable dt_Curr_tbl)
    {
        try
        {
            DataTable dt_Prev_Table = DataTable_Mapping_Controls(dt_Curr_tbl);
            ViewState["dt_Prev_Table"] = dt_Prev_Table;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Audit_Modified_DataTableComparer()
    {
        try
        {
            DataTable dt_Prev = (DataTable)ViewState["dt_Prev_Table"];
            DataTable dt_m2 = dt_Prev.Clone();
            DataTable dt_modified = DataTable_Mapping_Controls(dt_m2);
            DataTableComparer Dt_Change = new DataTableComparer();
            Dt_Change.GetMismatchedRowsFast(dt_Prev, dt_modified, "JOBNO", "Bond", IMPORT_JOBNO, "", "", currentuser, currentbranch);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private DataTable DataTable_Mapping_Controls(DataTable dt_mapping)
    {
        try
        {
            if (dt_mapping.Rows.Count > 0)
            {
                dt_mapping.Rows.Clear();
            }

            DataRow dr = dt_mapping.NewRow();

            dr["BONDID"] = "";
            dr["JOBNO"] = IMPORT_JOBNO;
            dr["BOND_NO"] = txtBondNo.Text.Trim();
            dr["BOND_TYPE"] = ddlBondType.SelectedValue;
            dr["BOND_LOCATION"] = txtBondLocation.Text.Trim();
            //dr["BOND_AMT"] = "";
            //dr["ICEGATE_AMT"] = "";

            // ================= ADD ROW =================
            dt_mapping.Rows.Add(dr);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return dt_mapping;
    }

    [WebMethod]
    public static string GET_BOND_AVAILE_AMT(string bond_no, string bond_location, string bond_type)
    {
        Transaction Transact = new Transaction();

        Transact.BOND_NO = bond_no;
        Transact.BOND_TYPE = bond_type;
        Transact.BOND_LOCATION = bond_location.ToUpper();
        Transact.Ename = "BOND_BALANCE";

        DataSet ds = Transact.BOND_AMOUNT_DETAIL_GET();

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            return ds.Tables[0].Rows[0]["AvailableBalance"].ToString();
        }

        return "0";
    }

    public string GET_BOND_AVAILE_AMT_UPDATE(string bond_no, string bond_location, string bond_type)
    {
        Transaction Transact = new Transaction();

        Transact.BOND_NO = bond_no;
        Transact.BOND_TYPE = bond_type;
        Transact.BOND_LOCATION = bond_location.ToUpper();
        Transact.Ename = "BOND_BALANCE";

        DataSet ds = Transact.BOND_AMOUNT_DETAIL_GET();

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            return ds.Tables[0].Rows[0]["AvailableBalance"].ToString();
        }

        return "0";
    }

    protected void BOND_AMT_SELECT(object sender, EventArgs e)
    {
        string bondNo = hfBondNo.Value;
        string bondLocation = hfBondLocation.Value;
        string bondType = hfBondType.Value;

        if (string.IsNullOrWhiteSpace(bondNo) ||
            string.IsNullOrWhiteSpace(bondLocation) ||
            string.IsNullOrWhiteSpace(bondType))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert",
                "alert('Bond values missing on server side.');", true);
            return;
        }

        Transact.BRANCH_CODE = currentbranch;
        Transact.JOBNO = Session["IMPORT_JOBNO"].ToString();
        Transact.Ename = "BOND_DETAILS_GET";
        Transact.BOND_NO = bondNo;
        Transact.BOND_TYPE = bondType;
        Transact.BOND_LOCATION = bondLocation;

        DataSet ds = Transact.RetrieveAll_IMPORT_BOND_AMOUNT_DETAILS_SummaryReport();

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            BOND_AMOUNT_UPDATE(ds.Tables[0]);
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "nodata",
                "alert('No bond records found.');", true);
        }
    }

    public void BOND_AMOUNT_UPDATE(DataTable dt_Bond)
    {
        eroyalmaster erm = new eroyalmaster();
        SELECT_BRANCH = currentbranch;
        string jobno = Session["IMPORT_JOBNO"].ToString();

        if (dt_Bond == null || dt_Bond.Rows.Count == 0)
        {
            return;
        }

        DataSet finalDS = new DataSet();

        foreach (DataRow row in dt_Bond.Rows)
        {
            string bondType = row["BOND_TYPE"].ToString();
            string bondNo = row["BOND_NO"].ToString();
            string bondLocation = row["BOND_LOCATION"].ToString();

            if (bondType == "PD, Provisional duty bond")
            {
                Transact.Ename = "SELECT_PD_BOND_REPORT";
            }
            else if (bondType.StartsWith("R", StringComparison.OrdinalIgnoreCase))
            {
                Transact.Ename = "SELECT_RE_BOND_REPORT";
            }
            else if (bondType == "DE, DEEC Bond" || bondType == "NB,  National Bond")
            {
                Transact.Ename = "SELECT_DEEC_BOND_REPORT";
            }
            else if (bondType == "EC, EPCG Bond")
            {
                Transact.Ename = "SELECT_EPCG_BOND_REPORT";
            }
            else if (bondType == "WH, Warehouse Bond")
            {
                Transact.Ename = "SELECT_WAREHOUSE_BOND_REPORT";
            }
            else if (bondType == "EI, IGCR")
            {
                Transact.Ename = "SELECT_EI_IGCR_BOND_REPORT";
            }
            else if (bondType == "EU, End use Bond")
            {
                Transact.Ename = "SELECT_EU_END_USE_BOND_REPORT";
            }
            else
            {
                continue;
            }

            Transact.BOND_NO = bondNo;
            Transact.BOND_TYPE = bondType;
            Transact.BOND_LOCATION = bondLocation;
            Transact.BRANCH_CODE = SELECT_BRANCH;
            Transact.JOBNO = jobno;

            DataSet ds = Transact.RetrieveAll_IMPORT_BOND_AMOUNT_DETAILS_SummaryReport();

            if (Transact.result == 1)
            {
                Alert_msg("BOND AMOUNT UPDATED SUCESSFULLY");
            }
            else
            {
                Alert_msg("Insufficient Bond Balance");
            }
        }
    }


}