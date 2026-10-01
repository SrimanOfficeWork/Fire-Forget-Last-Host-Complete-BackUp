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

public partial class Transaction_Certificate_Details : ThemeClass
{

    Transaction Transact = new Transaction();
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();
    DataTable dt = new DataTable();
    DataSet dss = new DataSet();
    ErrorLogs er = new ErrorLogs();

    public int i, Screen_Id;
    public string currentuser, currentbranch, Working_Period, IMPORT_JOBNO, IMPORT_JOBDATE, SELECT_TYPE, SELECT_BRANCH, click_SaveNew = "", CERTIFICATE_ID = "", Audit_YN = ""
           , PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, JOB_LOCK, JOB_RELEASE, COMPANY_ID;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
            currentuser = Session["currentuser"].ToString();
            currentbranch = Session["currentbranch"].ToString();
            Working_Period = Session["WorkingPeriod"].ToString();
            COMPANY_ID = Connection.COMPANYID();
            SELECT_BRANCH = Connection.Get_Company_Type();

            Screen_Id = 7;
            Page_Rights(Screen_Id);
            if (Session["IMPORT_JOBNO"] != null || Session["IMPORT_JOBDATE"] != null)
            {
                IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
                IMPORT_JOBDATE = Session["IMPORT_JOBDATE"].ToString();
                hdn_CompanyID.Value = Session["COMPANY_LICENSE"].ToString().ToLower();
            }
            else
            {
                Response.Write("<script>window.parent.document.getElementById('IGM').click();</script>");
            }

            if (Connection.Audit_Logs(COMPANY_ID) == "Y")
            {
                Audit_YN = "Y";
            }

            if (!IsPostBack)
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btnNew.Visible = true;
                txtCertificateNo.Focus();
                ddlCertificate_Type();
                Gridbind_Certificate("N");
                btnSaveNew.Visible = true;

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
                    btnSaveNew.Enabled = false;

                    btnNew.ToolTip = "This Job is Locked by Admin";
                    btnSave.ToolTip = "This Job is Locked by Admin";
                    btnUpdate.ToolTip = "This Job is Locked by Admin";
                    btnDelete.ToolTip = "This Job is Locked by Admin";
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
                            btnSaveNew.Enabled = false;
                            MP_U.Show();
                            lblUser_Msg.Text = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnUpdate.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnDelete.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnNew.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                            btnSave.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
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
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                btnSaveNew.Enabled = false;
                btnNew.ToolTip = "You don't have permission to access";
                btnSave.ToolTip = "You don't have permission to access";
                btnUpdate.ToolTip = "You don't have permission to access";
                btnDelete.ToolTip = "You don't have permission to access";
                hdn_Grid_Disable.Value = "1";
            }
            else
            {
                //---------------SAVE BUTTON------------------//
                if (PAGE_WRITE == "True")
                {
                    btnSave.Enabled = true;
                    btnNew.Enabled = true;
                    btnSaveNew.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                    btnSave.ToolTip = "You don't have permission to access";
                    btnNew.Enabled = false;
                    btnSaveNew.Enabled = false;
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
                gv_Certificate.ToolTip = "You don't have permission to access";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void ddlCertificate_Type()
    {
        try
        {
            ddlCertificateType.Items.Add("CE, Central excise cert");
            ddlCertificateType.Items.Add("DE, DEEC Bond");
            ddlCertificateType.Items.Add("EU, End use Bond");
            ddlCertificateType.Items.Add("EO, EOU Bond");
            ddlCertificateType.Items.Add("EC, EPCG Bond");
            ddlCertificateType.Items.Add("EZ, EPZ Bond");
            ddlCertificateType.Items.Add("IT, ITC Bond");
            ddlCertificateType.Items.Add("JB, Jobbing");
            ddlCertificateType.Items.Add("LG, Letter of guarantee");
            ddlCertificateType.Items.Add("MS, Misc. cert");
            ddlCertificateType.Items.Add("PJ, Project Bond");
            ddlCertificateType.Items.Add("PD, Provisional duty bond");
            ddlCertificateType.Items.Add("RE, Re-export Bond");
            ddlCertificateType.Items.Add("TB, Test Bond");
            ddlCertificateType.Items.Add("TP, Transhipment Bond");
            ddlCertificateType.Items.Add("UT, Undertaking");
            ddlCertificateType.Items.Add("WH, Warehouse Bond");
            ddlCertificateType.Items.Add("PI, Project Imports");
            ddlCertificateType.Items.Add("EI, IGCR");
            ddlCertificateType.Items.Add("GB, General Common Bond");
            ddlCertificateType.Items.Add("SZ, SEZ Bond");


            ddlCertificateType.Items.Add("P1, 	Carotar-PSU/Government  (Central/State and their Undertakings)	");
            ddlCertificateType.Items.Add("P2, 	Carotar -  All other categories including AEO	");
            ddlCertificateType.Items.Add("P3, 	SVB  -  All  other  importers  in  case  of initial period till non-compliance as per cir 05/2016");
            ddlCertificateType.Items.Add("P4, 	SVB - AEO T1 in case of initial period till non compliance as per cir 05/2016");
            ddlCertificateType.Items.Add("P5, 	SVB - AEO T2 in case of initial period till non compliance as per cir 05/2016");
            ddlCertificateType.Items.Add("P6, 	SVB a. AEO T3 b. PSUs, Government");
            ddlCertificateType.Items.Add("P7, 	Chemical Test –a. AEO T3,b.  PSU/Government  (Central/State  and their Undertakings)");
            ddlCertificateType.Items.Add("P8, 	Chemical Test - AEO T2	");
            ddlCertificateType.Items.Add("P9, 	Chemical Test - AEO T1	");
            ddlCertificateType.Items.Add("PA, 	Chemical Test - Others	");
            ddlCertificateType.Items.Add("PB, 	Carotar - Cases selected on random basis for verification of origin	");
            ddlCertificateType.Items.Add("PZ, 	Officer Determined	");
            ddlCertificateType.Items.Add("E1, 	EPCG/AA/DFIA  -a.  Export  turnover  more  than  5  crores (goods or services) in preceeding year b. Public Sector Undertaking c.  Star  Export  House  (Status  Holder) registered   with   GST   authorities   and exporting  in  preyious  2  FY  having  min export of 1 crore d. registered with GST and paid GST of 1 cr or more in previous FY	");
            ddlCertificateType.Items.Add("E2, 	EPCG/AA/DFIA – a.    not    covered    under    Sl.    no.    2.1 (a,b,c,d,e) of Circular 17/2009-Cus dated 25.05.2009 b. Units in AEZ c.   Established   Service   Providers   who have free FOREX earning of 50 lakhs or more during previous FY	");
            ddlCertificateType.Items.Add("E3, 	EPCG/AA/DFIA – a. Service providers handling sector who are     appointed     as     Custodians     by concerned jurisdictions	");
            ddlCertificateType.Items.Add("E4, 	Others");
            ddlCertificateType.Items.Add("EZ, 	Officer Determined");
            ddlCertificateType.Items.Add("R1, 	Container");
            ddlCertificateType.Items.Add("R2, 	Jobbing");
            ddlCertificateType.Items.Add("RZ, 	Officer Determined");
            ddlCertificateType.Items.Add("D1, 	Section 143	");
            ddlCertificateType.Items.Add("DZ, 	Officer Determined");
            ddlCertificateType.Items.Add("W1, 	a.  Other  than  AEO  Clients  -  sensitive goods stored for a period beyond 2 years b.   non-sensitive   goods   stored   for   a period beyond 3 years");
            ddlCertificateType.Items.Add("W2, 	a.  Non  AEO  Clients  -  Non  sensitive goods stored 2-3 years b. AEO T1 Non Sensitive goods stored more than 3 years c.  Non  AEO  Clients  -  Sensitive  goods stored for 1-2 years d. AEO T1 clients sensitive goods stored beyond 2 years e. Gold, silver, other precious metals and articles thereof warehoused by AEO T1 Clients beyond 1 year");
            ddlCertificateType.Items.Add("W3, 	a.  non-sensitive  goods  stored  for  1-2 year by importers other than AEO b.  non  sensitive  goods  stored  for  2-3 year by AEO T1 c.  non sensitive  goods  stored  beyond  3 years by  AEO T2 d.  sensitive  goods  stored  for  1-2  years by AEO T1 clients e. sensitive goods stored for more than 2 years by AEO T2 Clients f. Gold, silver, other precious metals and e.  articles thereof warehoused by AEO T2 Clients beyond 1 year");
            ddlCertificateType.Items.Add("W4, 	a.  Non  sensitive  goods  -  AEO  T1  for period 1-2 years b.  Non  Sensitive goods  stored by AEO T2 stored for 2-3 years c.  Sensitive  Goods  -  AEO  T2  for  1-2 years");
            ddlCertificateType.Items.Add("W5, 	Non Sensitive goods stored for 1-2 years for AEO T2	");
            ddlCertificateType.Items.Add("W6, 	a. AEO T3 b.  non  sensitive  goods  stored  for  initial period of 1 year c.   goods   warehoused   for   supply   to diplomats d.  warehoused  and  sold  through  duty free  shops,  warehoused  for  supply  as ship stores/airlines e. Gold, silver, other precious metals and articles thereof warehoused by AEO T3 Clients");
            ddlCertificateType.Items.Add("W7, 	sensitive goods stored beyond 1 year in private warehouse	");
            ddlCertificateType.Items.Add("W8, 	a. Sensitive goods stored for 0-1 year, if sensitive   goods   are   proposed   to   be removed from public bonded warehouse to private bonded warehouse b. Gold, silver, other precious metals and articles  thereof  warehoused  at  the  time of deposit (Other than AEO)");
            ddlCertificateType.Items.Add("W9, 	Gold,  silver,  other  precious  metals  and articles  thereof  warehoused  at  the  time of deposit by AEO T1 Clients	");
            ddlCertificateType.Items.Add("WA, 	Gold,  silver,  other  precious  metals  and articles  thereof  warehoused  at  the  time of deposit by AEO T2 Clients	");
            ddlCertificateType.Items.Add("WZ, 	Officer Determined");
            ddlCertificateType.Items.Add("M1, 	MOOWR in Private Warehouse");
            ddlCertificateType.Items.Add("MZ, 	Officer Determined");
            ddlCertificateType.Items.Add("S1, 	MOOWR in Special Warehouse");
            ddlCertificateType.Items.Add("SZ, 	Officer Determined");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void Gridbind_Certificate(string Action_mode)
    {
        try
        {
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.CERTIFICATE_NO = "0";
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            Transact.Ename = "select_con";
            dss = Transact.RetrieveAll_Certificate_Details();

            //------------------Audit Modified column History-------------------
            if (Audit_YN == "Y" && Action_mode == "N")
            {
                Tbl_Filed_Modified_History(dss.Tables[1]);
            }
            //-----------------------------------------------------------------
            Grid_Empty();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void CERTIFICATE_insert_update(string IMPORT_JOBNO, string CERTIFICATE_ID, string flag, string year)
    {
        try
        {
            Transact.CERTIFICATEID = CERTIFICATE_ID;
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.CERTIFICATE_NO = txtCertificateNo.Text.ToUpper();
            Transact.CERTIFICATE_DATE = txtCertificateDate.Text == "" ? "01/01/1900" : txtCertificateDate.Text;
            Transact.CERTIFICATE_TYPE = ddlCertificateType.SelectedValue;
            Transact.USER_ID = currentuser;
            Transact.flag = flag;
            Transact.BRANCH_CODE = currentbranch;
            Transact.YEAR = year;
            Transact.WORKING_PERIOD = Working_Period;
            Transact.BRANCH_COMMON = SELECT_BRANCH;

            dss = Transact.CERTIFICATE_Details_insertupdate();
            i = Transact.result;
            if (i == 1)
            {
                Transact.Imp_Job_Logs_All_Details(IMPORT_JOBNO, "", "", "Certificate", flag, "Insert");
            }
            Gridbind_Certificate("U");
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
            CERTIFICATE_ID = "0";
            CERTIFICATE_insert_update(IMPORT_JOBNO, CERTIFICATE_ID, flag, year);
            hdn_update_Certificate.Value = Convert.ToString(Transact.UPDATE_ID);

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
                    /*
                    btnUpdate.CssClass = "save";
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    btnSave.Focus();
                    */

                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                    btnSaveNew.Visible = true;
                    txtCertificateNo.Focus();
                    btnSave.Focus();
                }
                //-----------------------FOR USER RIGHTS--------------------------------//
                ViewState["UPDATED_ID"] = null;

                if (click_SaveNew != "SaveNew_Click")
                {
                    Alert_msg("Certificate Saved Successfully", "btnSave");
                }
                else
                {
                    Transact.ResetFields(Page.Controls);
                }
            }
            else if (i == 2)
            {
                Alert_msg("Certificate No Already Exist!", "btnSave");
            }
            else
            {
                Alert_msg("Certificate Not Saved", "btnSave");
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
            ddlCertificateType.Items.Clear();
            ddlCertificate_Type();
            Transact.ResetFields(Page.Controls);
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
            btnUpdate.CssClass = "updates";
            btnSaveNew.Visible = true;

            ViewState["UPDATED_ID"] = null;
            hdn_update_Certificate.Value = "";
            txtCertificateNo.Focus();
            Gridbind_Certificate("N");
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
            CERTIFICATE_ID = hdn_update_Certificate.Value;
            CERTIFICATE_insert_update(IMPORT_JOBNO, CERTIFICATE_ID, flag, year);
            if (i == 1)
            {
                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("Certificate Updated Successfully", "btnUpdate");
                }
                else
                {
                    Alert_msg("Certificate Saved Successfully", "btnUpdate");
                }


                // ----Audit Modified Data -----------------------------------
                if (Audit_YN == "Y")
                {
                    Audit_Modified_DataTableComparer();
                }
                //------------------------------------------------------------
            }
            else
            {
                Alert_msg("Certificate Not Saved");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void gv_Certificate_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["CertificateID"] = Convert.ToString(this.gv_Certificate.SelectedDataKey.Value);
            if (ViewState["CertificateID"] != "" && ViewState["CertificateID"] != null)
            {
                txtCertificateNo.Text = gv_Certificate.SelectedRow.Cells[1].Text.Replace("&nbsp;", "").Replace("&amp;", "&");
                ViewState["CertificateNo"] = txtCertificateNo.Text;
                txtCertificateDate.Text = gv_Certificate.SelectedRow.Cells[2].Text.Replace("01/01/1900", "");
                ddlCertificateType.Items.Clear();
                string ddlCertificate = gv_Certificate.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
                ddlCertificate_Type();
                ddlCertificateType.Items.Remove(ddlCertificate);
                ddlCertificateType.Items.Insert(0, ddlCertificate);
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = ViewState["CertificateID"].ToString();
                hdn_update_Certificate.Value = ViewState["CertificateID"].ToString();
                btnUpdate.CssClass = "updates";
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = true;
                btnSaveNew.Visible = false;

                // ----Audit Modified Data -----------------------------------
                if (Audit_YN == "Y")
                {
                    DataTable_Mapping_Controls((DataTable)ViewState["dt_Prev_Table"], "Y");
                }
                //------------------------------------------------------------
            }
            else
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btnNew.Visible = true;
                btnSaveNew.Visible = true;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    protected void gv_Certificate_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
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
                    e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_Certificate, "Select$" + e.Row.RowIndex.ToString()));
                }
                string MINDATE = "01/01/1900";
                if (e.Row.Cells[2].Text == MINDATE)
                {
                    if (Convert.ToDateTime(e.Row.Cells[2].Text) <= Convert.ToDateTime(MINDATE))
                        e.Row.Cells[2].Text = string.Empty;
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    protected void gv_Certificate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gv_Certificate.PageIndex = e.NewPageIndex;
            Gridbind_Certificate("N");
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
           // Transact.CERTIFICATE_NO = ViewState["CertificateNo"].ToString(); 
            Transact.CERTIFICATE_NO = ViewState["CertificateID"].ToString(); 
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            Transact.Ename = "delete";
            dss=Transact.RetrieveAll_Certificate_Details();
            Grid_Empty();
            int ii = 0;
            ii = Transact.result;
            if (ii == 1)
            {

                Transact.Imp_Job_Logs_All_Details(IMPORT_JOBNO, "", "", "Certificate", "D", "Insert");

                btnNew_Click(sender, e);
                Alert_msg("Certificate Deleted");
            }
            else
            {
                Alert_msg("Certificate Not Deleted");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    protected void gv_Certificate_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.CssClass = "header";
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
                e.Row.CssClass = "normal";
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
                    gv_Certificate.DataSource = dss;
                    gv_Certificate.DataBind();
                }
                else
                {
                    gv_Certificate.DataSource = dt;
                    gv_Certificate.DataBind();
                }
            }
            else
            {
                gv_Certificate.DataSource = dt;
                gv_Certificate.DataBind();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    public void Add_Newrow()
    {
        try
        {
            Transact.ResetFields(Page.Controls);
            dss.Tables[0].Rows.Add(dss.Tables[0].NewRow());
            gv_Certificate.DataSource = dss;
            gv_Certificate.DataBind();
            int columncount = gv_Certificate.Rows[0].Cells.Count;
            gv_Certificate.Rows[0].Cells.Clear();
            gv_Certificate.Rows[0].Cells.Add(new TableCell());
            gv_Certificate.Rows[0].Cells[0].ColumnSpan = columncount;
            gv_Certificate.Rows[0].Cells[0].Text = "No Record Found";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    protected void btnSaveNew_Click(object sender, EventArgs e)
    {
        try
        {
            click_SaveNew = "SaveNew_Click";
            btnSave_Click(sender, e);
            txtCertificateNo.Focus();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CERTIFICATE', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CERTIFICATE', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    private void Tbl_Filed_Modified_History(DataTable dt_Curr_tbl)
    {
        try
        {
           // DataTable dt_Prev_Table = DataTable_Mapping_Controls(dt_Curr_tbl, "Y");
            ViewState["dt_Prev_Table"] = dt_Curr_tbl;
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
            DataTable dt_modified = DataTable_Mapping_Controls(dt_m2, "N");
            DataTableComparer Dt_Change = new DataTableComparer();
            Dt_Change.GetMismatchedRowsFast(dt_Prev, dt_modified, "JOBNO", "Certificate", IMPORT_JOBNO, "", "", currentuser, currentbranch);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private DataTable DataTable_Mapping_Controls(DataTable dt_mapping, string SelectMode)
    {
        try
        {
            if (dt_mapping.Rows.Count > 0)
            {
                dt_mapping.Rows.Clear();
            }

            DataRow dr = dt_mapping.NewRow();

            dr["CERTIFICATEID"] = "";
            dr["JOBNO"] = IMPORT_JOBNO;
            dr["CERTIFICATE_NO"] = txtCertificateNo.Text.Trim();
            dr["CERTIFICATE_DATE"] = txtCertificateDate.Text.Trim();
            dr["CERTIFICATE_TYPE"] = ddlCertificateType.Text.Trim();
            dt_mapping.Rows.Add(dr);

            if (SelectMode == "Y")
            {
                ViewState["dt_Prev_Table"] = dt_mapping;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return dt_mapping;
    }
}