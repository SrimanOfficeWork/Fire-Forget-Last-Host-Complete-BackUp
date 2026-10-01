using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data.OleDb; 


public partial class Transaction_Container : ThemeClass
{
    Date_Time rep = new Date_Time();
    Transaction Transact = new Transaction();
    DataSet dtuser = new DataSet();
    DataSet dss = new DataSet();
    DataSet dsXML = new DataSet();                        
    DataSet ds = new DataSet();                           
    AppSession aps = new AppSession();
    AdminMasterDetails admin = new AdminMasterDetails();        
    Annexure_C_Sea_Container ANNEX_C_Sea_Con = new Annexure_C_Sea_Container();             

    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();
    public int Cont_id_Max, j;

    public string currentuser;
    public string currentbranch;

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);   

    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string IGM_Transportmode, IMPORT_JOBNO, IMPORT_JOBDATE, FILING_STAUS, Flight_Vesseldate = "", IGM_NO = "", IGMSLNO="" , IGMDATE = "", GATEWAY_IGMDATE = "", IGM_DATE = "", CONTAINER_ID = "";
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public string SELECT_TYPE, SELECT_BRANCH, COMPANY_ID;
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE;
    User_Creation user_Create = new User_Creation();
    public string click_SaveNew="";
    public string errorFolder = "", logline = "", logFileName = "", Del_Status = "", Audit_YN = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        COMPANY_ID = Session["COMPANY_ID"].ToString();

        errorFolder = Server.MapPath("~/Submission/" + COMPANY_ID + "/" + currentbranch + "/" + currentuser + "/" + "EXPORT_ANNEXURE_SEA_CONTAINER");

        SELECT_BRANCH = Connection.Get_Company_Type();

        Screen_Id = 7;
        Page_Rights(Screen_Id);
        txtContainerNo.Focus();


        if (Connection.Audit_Logs(COMPANY_ID) == "Y")
        {
            Audit_YN = "Y";
        }

        if (Session["IMPORT_JOBNO"] != null || Session["IMPORT_JOBDATE"] != null)
        {
            IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
            hdn_Jobno.Value = IMPORT_JOBNO;
            IMPORT_JOBDATE = Session["IMPORT_JOBDATE"].ToString();
           
            if (Session["IGMDATE"] != null)
            {
                IGM_DATE = Session["IGMDATE"].ToString();
                if (IGM_DATE == "")
                {
                    IGM_DATE = "01/01/1900";
                }
            }
            else
            {
                IGM_DATE = "01/01/1900";
            }

            if (!IsPostBack)
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btnNew.Visible = true;
                btnSaveNew.Visible = true;
                //Gridbind_Container();

                //ddlFCL_LCL.Items.Add(Hdn_containertype.Value);
                //ddlFCL_LCL.Items.Add(Session["CONT_TYPE"].ToString()); 
                //ddlFCL_LCL.Items.Add("F");
                
                //ddlFCL_LCL.SelectedValue = Hdn_containertype.Value;

                if (Session["CONT_TYPE"] != null && Session["CONT_TYPE"] != "")
                {
                    Hdn_containertype.Value = Session["CONT_TYPE"].ToString();
                    Hdn_containertype.Value = Hdn_containertype.Value.Substring(0, 1);
                    ddlFCL_LCL.Items.Remove(Hdn_containertype.Value);
                    ddlFCL_LCL.Items.Add(Hdn_containertype.Value);
                    ddlFCL_LCL.SelectedValue = Hdn_containertype.Value;
                }
                else
                {

                }





                if (Session["IGMNO"] != null)
                {
                    IGM_NO = Session["IGMNO"].ToString();
                }

                if (Session["IGMSLNO"] != null || Session["IGMNO"] != null)
                {
                    IGMSLNO = Session["IGMSLNO"].ToString();

                    Gridbind_Import_Container(Session["IGMSLNO"].ToString(),"pageload");
                    ddlIGM_SL_No.SelectedValue = Session["IGMSLNO"].ToString();
                }

            }
        }
        else
        {
            //Response.Write("<script>window.open('IGM_Details.aspx','_parent');</script>");
            Response.Write("<script>window.parent.document.getElementById('IGM').click();</script>");         
        }
        if (Session["TRANSPORT_MODE"] != null)
        {

            IGM_Transportmode = Session["TRANSPORT_MODE"].ToString();
            hdn_TransportMode.Value = IGM_Transportmode;

            if (IGM_Transportmode == "Air")
            {
                //Response.Write("<script>window.open('IGM_Details.aspx','_parent');</script>");
                Response.Write("<script>window.parent.document.getElementById('IGM').click();</script>");
            }
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

    public void Page_Rights(int i)
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
            //}
            //btnNew.Enabled = true;
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
            gv_Container.ToolTip = "You don't have permission to access";
    }

    public void Gridbind_Container()
    {
        DataSet ds_cont = new DataSet();
        if (Session["IGMSLNO"] != null || Session["IGMNO"] != null)
        {
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.CONTAINER_IGM_SLNO = Session["IGMSLNO"].ToString();
            Transact.CONTAINER_IGM_NO = Session["IGMNO"].ToString();
            Transact.CONTAINER_NO = "0";
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            Transact.Ename = "select_con";
            ds_cont = Transact.RetrieveAll_Container_Details();
            gv_Container.DataSource = ds_cont.Tables[0];
            gv_Container.DataBind();

            if (Audit_YN == "Y")
            {
                Tbl_Filed_Modified_History(ds_cont.Tables[1]);
            }
        }
        else
        {
            //Response.Write("<script>window.open('IGM_Details.aspx','_parent');</script>");
            Response.Write("<script>window.parent.document.getElementById('IGM').click();</script>");
        }
    }

    public void CONTAINER_insert_update(string IMPORT_JOBNO, string CONTAINER_ID, string flag, string year)
    {

        Transact.CONTAINERID = CONTAINER_ID;
        Transact.CONTAINER_IGM_SLNO = ddlIGM_SL_No.SelectedValue;
        Transact.CONTAINER_IGM_NO = ViewState["IGM_NO"].ToString();
        IGM_DATE = ViewState["IGM_DATE"].ToString();

        if (IGM_DATE == "")
        {
            IGM_DATE = "01/01/1900";
        }

        Transact.CONTAINER_IGM_DATE = IGM_DATE;

        Transact.JOBNO = IMPORT_JOBNO;//call session value from general details
        Transact.CONTAINER_NO = txtContainerNo.Text.ToUpper();
        Transact.SEAL_NO = txtSealNo.Text.ToUpper();
        Transact.FCL_OR_LCL = ddlFCL_LCL.SelectedValue.ToString();
        Transact.USER_ID = currentuser;
        Transact.flag = flag;
        Transact.BRANCH_CODE = currentbranch;
        Transact.YEAR = year;
        Transact.WORKING_PERIOD = Working_Period;
        Transact.BRANCH_COMMON = SELECT_BRANCH;
        Transact.TYPE = ddlType.SelectedValue.ToString();
        Transact.TRUCK_NO = txttruckrNo.Text.ToUpper();
        Transact.AMENDMENT_TYPE = ddl_AmendmentType.SelectedValue;
        Transact.AMENDMENT_STATUS = "";
        Transact.JOBNO_PS = Session["JOBNO_PS"].ToString();

        DataSet dss = new DataSet();
        dss = Transact.CONTAINER_Details_insertupdate();
        j = Transact.result;

        if (j == 1)
        {
            Transact.Imp_Job_Logs_All_Details(IMPORT_JOBNO, "", "", "Container", flag, "Insert");
        }

        if (j != 2)
        {
            if (dss.Tables[0].Rows.Count > 0)
            {
                gv_Container.DataSource = dss;
                gv_Container.DataBind();
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Session["IGMSLNO"] != null)
        {
            if (txtContainerNo.Text != "" && txtSealNo.Text != "")
             {
                string flag = "S", year = "";
                CONTAINER_ID = "";
                CONTAINER_insert_update(IMPORT_JOBNO, CONTAINER_ID, flag, year);
                hdn_update_Container.Value = Convert.ToString(Transact.UPDATE_ID);
                Hdn_containertype.Value = ddlFCL_LCL.SelectedValue.ToString();
                if (j == 1)
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
                        //btnUpdate.CssClass = "save";
                        //btnUpdate.Visible = true;
                        //btnSave.Visible = false;

                        btnUpdate.Visible = false;
                        btnSave.Visible = true;
                        btnSaveNew.Visible = true;
                        txtContainerNo.Focus();
                        btnSave.Focus();
                    }
                    //-----------------------FOR USER RIGHTS--------------------------------//
                   
                    ViewState["UPDATED_ID"] = null;

                    if (click_SaveNew != "SaveNew_Click")
                    {
                        Alert_msg("Container Saved Successfully", "btnSave");
                       
                    }
                    else
                    {
                        Transact.ResetFields(Page.Controls);
                    }
                }
                else if (j == 2)
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Container No Already Exist')</script>", false);
                    Alert_msg("Container No Already Exist!", "btnSave");
                }
                else
                {
                   // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
                    Alert_msg("Container Not Saved", "btnSave");
                }
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string flag = "U", year = "";
        //CONTAINER_ID = ViewState["CONTAINERID"].ToString();
        CONTAINER_ID = hdn_update_Container.Value;
        CONTAINER_insert_update(IMPORT_JOBNO, CONTAINER_ID, flag, year);
        if (j == 1)
        {
            //txtAirlineCode.Focus();
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);
            if (ViewState["UPDATED_ID"] != null)
            {
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>event.preventDefault();alert('Updated Successfully')</script>", false);
                Alert_msg("Container Updated Successfully", "btnUpdate");
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>event.preventDefault();alert('Saved Successfully')</script>", false);
                Alert_msg("Container Saved Successfully", "btnUpdate");
            }
            if (Audit_YN == "Y")
            {
                Audit_Modified_DataTableComparer();
            }
        }

        else if (j == 2)
        {
           // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Container No Already Exist')</script>", false);
            Alert_msg("Container No Already Exist!", "btnUpdate");
        }
        else
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
            Alert_msg("Container Not Saved");
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        ddlFCL_LCL.Items.Clear();
        ddlFCL_LCL.Items.Add("F");
        ddlFCL_LCL.Items.Add("L");

        if (Session["CONT_TYPE"] != null && Session["CONT_TYPE"] != "")
        {
            Hdn_containertype.Value = Session["CONT_TYPE"].ToString();
            Hdn_containertype.Value = Hdn_containertype.Value.Substring(0, 1);
            ddlFCL_LCL.Items.Remove(Hdn_containertype.Value);
            ddlFCL_LCL.Items.Add(Hdn_containertype.Value);
            ddlFCL_LCL.SelectedValue = Hdn_containertype.Value;
        }

       if (COMPANY_ID == "2266")
         {
            ddlFCL_LCL.SelectedValue= Hdn_containertype.Value;
         }

        ddlType.Items.Clear();
        ddlType.Items.Add("");
        ddlType.Items.Add("20");
        ddlType.Items.Add("40");
        ddlType.Items.Add("40HC");

        ddlType.Items.Add("20 Bulk");
        ddlType.Items.Add("20 Bulk-22B0");
        ddlType.Items.Add("20 Collapsible Flat Rack");
        ddlType.Items.Add("20 Collapsible Flat Rack-22P3");
        ddlType.Items.Add("20 Flat Rack");
        ddlType.Items.Add("20 Flat Rack-22P1");
        ddlType.Items.Add("20 Hard Top");
        ddlType.Items.Add("20 Hard Top-22UP");
        ddlType.Items.Add("20 Open Top");
        ddlType.Items.Add("20 Open Top-22U1");
        ddlType.Items.Add("20 Platform");
        ddlType.Items.Add("20 Platform-29P0");
        ddlType.Items.Add("20 Reefer");
        ddlType.Items.Add("20 Reefer-22R1");
        ddlType.Items.Add("20 Standard Dry");
        ddlType.Items.Add("20 Standard Dry-22G0");
        ddlType.Items.Add("20 Tank");
        ddlType.Items.Add("20 Tank-22T0");
        ddlType.Items.Add("40 Collapsible Flat Rack");
        ddlType.Items.Add("40 Collapsible Flat Rack-42P3");
        ddlType.Items.Add("40 Flat Rack");
        ddlType.Items.Add("40 Flat Rack-42P1");
        ddlType.Items.Add("40 Hard Top");
        ddlType.Items.Add("40 Hard Top-42UP");
        ddlType.Items.Add("40 High Cube");
        ddlType.Items.Add("40 High Cube-45G0");
        ddlType.Items.Add("40 Open Top");
        ddlType.Items.Add("40 Open Top-42U1");
        ddlType.Items.Add("40 Platform");
        ddlType.Items.Add("40 Platform-49P0");
        ddlType.Items.Add("40 Reefer");
        ddlType.Items.Add("40 Reefer-42R1");
        ddlType.Items.Add("40 Reefer High Cube");
        ddlType.Items.Add("40 Reefer High Cube-45R1");
        ddlType.Items.Add("40 Standard Dry");
        ddlType.Items.Add("40 Standard Dry-42G0");
        ddlType.Items.Add("40 Tank");
        ddlType.Items.Add("40 Tank-42T0");
        ddlType.Items.Add("40 Reefer");
        ddlType.Items.Add("45");

       // Transact.ResetFields(Page.Controls);

        txtContainerNo.Text = "";
        txtSealNo.Text = "";
        txttruckrNo.Text = "";

        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;
        btnUpdate.CssClass = "updates";
        btnSaveNew.Visible = true;

        ViewState["UPDATED_ID"] = null;
        hdn_update_Container.Value = "";
       // Gridbind_Container();
        Gridbind_Import_Container(ddlIGM_SL_No.SelectedValue, "ddl_change");

    }

    protected void gv_Container_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["CONTAINERID"] = Convert.ToString(this.gv_Container.SelectedDataKey.Value);

        if (ViewState["CONTAINERID"] != "" && ViewState["CONTAINERID"] != null)
        {
            gv_Container.SelectedRowStyle.Font.Bold = true;
            gv_Container.SelectedRowStyle.BackColor = System.Drawing.Color.LightGray;

            txtContainerNo.Text = gv_Container.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");

            ViewState["CONTAINERNO"] = txtContainerNo.Text;
            txtSealNo.Text = gv_Container.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");

            ddlFCL_LCL.Items.Clear();
            string F_L=gv_Container.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            ddlFCL_LCL.Items.Add("F");
            ddlFCL_LCL.Items.Add("L");
            ddlFCL_LCL.Items.Remove(F_L);
            ddlFCL_LCL.Items.Insert(0, F_L);

            ddlType.Items.Clear();
            string type = gv_Container.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            ddlType.Items.Add("");
            ddlType.Items.Add("20");
            ddlType.Items.Add("40");
            ddlType.Items.Add("40HC");

            ddlType.Items.Add("20 Bulk");
            ddlType.Items.Add("20 Bulk-22B0");
            ddlType.Items.Add("20 Collapsible Flat Rack");
            ddlType.Items.Add("20 Collapsible Flat Rack-22P3");
            ddlType.Items.Add("20 Flat Rack");
            ddlType.Items.Add("20 Flat Rack-22P1");
            ddlType.Items.Add("20 Hard Top");
            ddlType.Items.Add("20 Hard Top-22UP");
            ddlType.Items.Add("20 Open Top");
            ddlType.Items.Add("20 Open Top-22U1");
            ddlType.Items.Add("20 Platform");
            ddlType.Items.Add("20 Platform-29P0");
            ddlType.Items.Add("20 Reefer");
            ddlType.Items.Add("20 Reefer-22R1");
            ddlType.Items.Add("20 Standard Dry");
            ddlType.Items.Add("20 Standard Dry-22G0");
            ddlType.Items.Add("20 Tank");
            ddlType.Items.Add("20 Tank-22T0");
            ddlType.Items.Add("40 Collapsible Flat Rack");
            ddlType.Items.Add("40 Collapsible Flat Rack-42P3");
            ddlType.Items.Add("40 Flat Rack");
            ddlType.Items.Add("40 Flat Rack-42P1");
            ddlType.Items.Add("40 Hard Top");
            ddlType.Items.Add("40 Hard Top-42UP");
            ddlType.Items.Add("40 High Cube");
            ddlType.Items.Add("40 High Cube-45G0");
            ddlType.Items.Add("40 Open Top");
            ddlType.Items.Add("40 Open Top-42U1");
            ddlType.Items.Add("40 Platform");
            ddlType.Items.Add("40 Platform-49P0");
            ddlType.Items.Add("40 Reefer");
            ddlType.Items.Add("40 Reefer-42R1");
            ddlType.Items.Add("40 Reefer High Cube");
            ddlType.Items.Add("40 Reefer High Cube-45R1");
            ddlType.Items.Add("40 Standard Dry");
            ddlType.Items.Add("40 Standard Dry-42G0");
            ddlType.Items.Add("40 Tank");
            ddlType.Items.Add("40 Tank-42T0");
            ddlType.Items.Add("40 Reefer");
            ddlType.Items.Add("45");

            ddlType.Items.Remove(type);
            ddlType.Items.Insert(0, type);

            txttruckrNo.Text = gv_Container.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");

            if (!string.IsNullOrEmpty(Session["BE_No"].ToString()))
            {
                div_AmendmentType.Visible = true;
                ddl_AmendmentType.SelectedValue = gv_Container.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
            }

            //FOR UPDATED SUCCESSFULLY
            ViewState["UPDATED_ID"] = null;
            ViewState["UPDATED_ID"] = ViewState["CONTAINERID"].ToString();
            hdn_update_Container.Value = ViewState["CONTAINERID"].ToString();

            ddlIGM_SL_No.SelectedValue = gv_Container.SelectedRow.Cells[5].Text;
            ViewState["IGM_NO"] = gv_Container.SelectedRow.Cells[6].Text;
            ViewState["IGM_DATE"] = gv_Container.SelectedRow.Cells[10].Text;
            //FOR UPDATED SUCCESSFULLY
            btnUpdate.CssClass = "updates";

            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnNew.Visible = true;
            btnSaveNew.Visible = false;

            if (Audit_YN == "Y")
            {
                DataTable_Mapping_Controls((DataTable)ViewState["dt_Prev_Table"], "Y");
            }
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

    protected void gv_Container_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_Container, "Select$" + e.Row.RowIndex.ToString()));
            }
            //  if Read Permiision given true for gridview enabled or Disabled----------//
        }
    }

    /*
    protected void gv_Container_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Container.PageIndex = e.NewPageIndex;
        Gridbind_Container();
    }
     * */

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.CONTAINER_IGM_SLNO = "0";
            Transact.CONTAINER_IGM_NO = "0";
            Transact.CONTAINER_NO = ViewState["CONTAINERNO"].ToString();
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            Transact.Ename = "delete";
            gv_Container.DataSource = Transact.RetrieveAll_Container_Details();
            gv_Container.DataBind();
            int ii = 0;
            ii = Transact.result;
            if (ii == 1)
            {
                //lblMsg.Text = " Record Deleted";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record  Deleted')</script>", false);
                btnNew_Click(sender, e);
                Alert_msg("Container Deleted");
                Transact.Imp_Job_Logs_All_Details(IMPORT_JOBNO, "", "", "Container", "D", "Insert");
            }
            else
            {
                //lblMsg.Text = " Record Not Deleted";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Deleted')</script>", false);

                Alert_msg("Container Not Deleted");
            }       
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void gv_Container_RowCreated(object sender, GridViewRowEventArgs e)
    {
        ////Add CSS class on header row.
        //if (e.Row.RowType == DataControlRowType.Header)
        //    e.Row.CssClass = "header";

        ////Add CSS class on normal row.
        //if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
        //    e.Row.CssClass = "normal";

        ////Add CSS class on alternate row.
        //if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
        //    e.Row.CssClass = "alternate";

        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal_2";
    }

    public void Grid_Empty()
    {
        if (dss.Tables.Count > 0)
        {
            if (dss.Tables[0].Rows.Count > 0)
            {
                gv_Container.DataSource = dss;

                gv_Container.DataBind();
            }
            else
            {
                gv_Container.DataSource = dt;
                gv_Container.DataBind();
            }
        }
        else
        {
            gv_Container.DataSource = dt;
            gv_Container.DataBind();      
        }
    }

    public void Add_Newrow()
    {
        dss.Tables[0].Rows.Add(dss.Tables[0].NewRow());
        gv_Container.DataSource = dss;
        gv_Container.DataBind();
        int columncount = gv_Container.Rows[0].Cells.Count;
        gv_Container.Rows[0].Cells.Clear();
        gv_Container.Rows[0].Cells.Add(new TableCell());
        gv_Container.Rows[0].Cells[0].ColumnSpan = columncount;
        gv_Container.Rows[0].Cells[0].Text = "No Record Found";
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CONTAINER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'CONTAINER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btnSaveNew_Click(object sender, EventArgs e)
    {
        click_SaveNew = "SaveNew_Click";
        btnSave_Click(sender, e);
        //Transact.ResetFields(Page.Controls);
        txtContainerNo.Focus();
    }

    public void Gridbind_Import_Container(string IGM_SLNo, string load_status)
    {
        DataSet ds_igm1 = new DataSet();

        //Transact.CONTAINERID = "";
        Transact.CONTAINERID = IGM_SLNo;
        Transact.JOBNO = IMPORT_JOBNO;
        Transact.WORKING_PERIOD = SELECT_BRANCH;
        Transact.Ename = "select";
        ds_igm1 = Transact.ExcelUpload_Container_Details();
        gv_Container.DataSource = ds_igm1.Tables[0];
        gv_Container.DataBind();

        if (load_status != "ddl_change")
        {
            ddlIGM_SL_No.DataSource = ds_igm1.Tables[1];
            ddlIGM_SL_No.DataTextField = "IGM_SLNO";
            ddlIGM_SL_No.DataValueField = "IGM_SLNO";
            ddlIGM_SL_No.DataBind();
        }

        if (ds_igm1.Tables[2].Rows.Count > 0)
        {
            IGMSLNO = ddlIGM_SL_No.SelectedValue;
            IGM_NO = ds_igm1.Tables[2].Rows[0]["IGM_NO"].ToString();
            IGM_DATE = ds_igm1.Tables[2].Rows[0]["IGM_DATE"].ToString();

            ViewState["IGM_NO"] = IGM_NO;
            ViewState["IGM_DATE"] = IGM_DATE;

        }

        if (Audit_YN == "Y")
        {
            Tbl_Filed_Modified_History(ds_igm1.Tables[3]);
        }
    }
    

    public string Get_ExcelFile()
    {
        string connString = "";
        string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
        string path = errorFolder + "\\" + fileuploadExcel.FileName;

        string picExtension;
        string fileName2;

        if (fileuploadExcel.HasFile)
        {
            picExtension = fnGetPictureExtn(fileuploadExcel.FileName);
            fileName2 = fileuploadExcel.FileName;
            addtoGallery1(fileName2, errorFolder);
        }

        if (strFileType.Trim() == ".xls" || strFileType.Trim() == ".xlsx")
        {
            if (strFileType.Trim() == ".xls")
            {
                connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            }
            else if (strFileType.Trim() == ".xlsx")
            {
                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }
            //----------------------------
            string query = "SELECT * FROM [Sheet1$]";


            OleDbConnection conn = new OleDbConnection(connString);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            OleDbCommand cmd = new OleDbCommand(query, conn);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            da.Fill(ds);
            da.Dispose();
            conn.Close();
            conn.Dispose();

        }
        ViewState["ds_Excel_upload"] = ds;
        return strFileType.Trim();
    }

    public void addtoGallery1(string picName, string folderName)
    {
        string strFolderPath;
        string strImagePath;
        try
        {
            strFolderPath = Path.Combine(Request.PhysicalApplicationPath, folderName);
            strImagePath = Path.Combine(strFolderPath, picName);
            fileuploadExcel.SaveAs(strImagePath);

        }
        catch
        {
        }
        finally
        {
        }
    }

    public string fnGetPictureExtn(string pictureName)
    {
        try
        {
            if (pictureName.ToUpper().EndsWith(".JPG"))
                return ".JPG";
            else if (pictureName.ToUpper().EndsWith(".JPEG"))
                return ".JPEG";
            else if (pictureName.ToUpper().EndsWith(".GIF"))
                return ".GIF";
            else if (pictureName.ToUpper().EndsWith(".DOC"))
                return ".DOC";
            else if (pictureName.ToUpper().EndsWith(".XLS"))
                return ".XLS";
            else if (pictureName.ToUpper().EndsWith(".PDF"))
                return ".PDF";
            else if (pictureName.ToUpper().EndsWith(".PNG"))
                return ".PNG";
            else if (pictureName.ToUpper().EndsWith(".CDR"))
                return ".CDR";
            else if (pictureName.ToUpper().EndsWith(".PSD"))
                return ".PSD";
            else if (pictureName.ToUpper().EndsWith(".TXT"))
                return ".TXT";
            else if (pictureName.ToUpper().EndsWith(".XLSX"))
                return ".XLSX";
            else
            {
            }
        }
        catch
        {
        }
        finally
        {
        }
        return "";
    }

    protected void btn_Delete_All_Invoice_And_Upload_Click(object sender, EventArgs e)
    {
        Transact.CONTAINERID = ddlIGM_SL_No.SelectedValue;
        Transact.JOBNO = IMPORT_JOBNO;
        Transact.WORKING_PERIOD = SELECT_BRANCH;
        Transact.Ename = "Delete_All_Containers_IGM_Slno_Wise";
        dtuser = Transact.ExcelUpload_Container_Details();
        Gridbind_Import_Container(ddlIGM_SL_No.SelectedValue, "ddl_change");
    }

    protected void btn_BulkContainer_Upload_Click(object sender, EventArgs e)
    {
        try
        {
            if (gv_Container.Rows.Count > 0)
            {
                mp_yesorno.Show();
                Del_Status = "Yes";
            }
            else
            {
                string file_ext = "";

                if (File.Exists(errorFolder + logFileName))
                {
                    DirectoryInfo dir = new DirectoryInfo(errorFolder);

                    foreach (FileInfo fi in dir.GetFiles())
                    {
                        fi.Delete();
                    }

                    file_ext = Get_ExcelFile();
                    ViewState["File_Exten"] = file_ext;
                }
                else
                {

                    Directory.CreateDirectory(errorFolder);
                    DirectoryInfo dir = new DirectoryInfo(errorFolder);
                    foreach (FileInfo fi in dir.GetFiles())
                    {
                        fi.Delete();
                    }

                    file_ext = Get_ExcelFile();
                    ViewState["File_Exten"] = file_ext;
                }

                Excel_Upload_load(file_ext);
            }

        }
        catch (Exception ex)
        {
            //Maildb.StoreMailContents(ds, email);
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public void Get_Annex_C_Container_MaxID()
    {
        Transact.CONTAINERID = "";
        Transact.JOBNO = IMPORT_JOBNO;
        Transact.WORKING_PERIOD = SELECT_BRANCH;
        Transact.Ename = "Select_MAX_Container_ID";
        ds = Transact.ExcelUpload_Container_Details();

        if (ds.Tables[0].Rows.Count > 0)
        {
            Cont_id_Max = Convert.ToInt32(ds.Tables[0].Rows[0]["CONTAINERID"].ToString());
        }
    }

    public void Excel_Upload_load(string file_ext)
    {
        Get_Annex_C_Container_MaxID();
        DataSet Inv_ds = new DataSet();
        //ds.Tables.Add("Invoice_dt");
        Inv_ds = ds = (DataSet)ViewState["ds_Excel_upload"];
        int a = 0, b = 0, c = 1;
        ds.Tables[0].Rows.Add();
        if (ds.Tables[0].Rows.Count > a)
        {

            #region create dataset column
            dsXML.Tables.Add("Import_Annex_C_Container_Details");
            dsXML.Tables[0].Columns.Add("CONTAINERID");
            dsXML.Tables[0].Columns.Add("CONTAINER_IGM_SLNO");
            dsXML.Tables[0].Columns.Add("CONTAINER_IGM_NO");
            dsXML.Tables[0].Columns.Add("CONTAINER_IGM_DATE");
            dsXML.Tables[0].Columns.Add("JOBNO");
            dsXML.Tables[0].Columns.Add("CONTAINER_NO");
            dsXML.Tables[0].Columns.Add("SEAL_NO");
            dsXML.Tables[0].Columns.Add("FCL_OR_LCL");
            dsXML.Tables[0].Columns.Add("USER_ID");
            dsXML.Tables[0].Columns.Add("DATE_TIME");
            dsXML.Tables[0].Columns.Add("STATUS");
            dsXML.Tables[0].Columns.Add("BRANCH_CODE");
            dsXML.Tables[0].Columns.Add("YEAR");
            dsXML.Tables[0].Columns.Add("WORKING_PERIOD");
            dsXML.Tables[0].Columns.Add("TYPE");
            dsXML.Tables[0].Columns.Add("TRUCK_NO");
            dsXML.Tables[0].Columns.Add("MODIFIEDBY");
            dsXML.Tables[0].Columns.Add("MODIFIEDON");
            dsXML.Tables[0].Columns.Add("AMENDMENT_TYPE");
            dsXML.Tables[0].Columns.Add("AMENDMENT_STATUS");
            dsXML.Tables[0].Columns.Add("JOBNO_PS");


            #endregion
            //--------------------End License Details--------------------------//
            if (file_ext == ".xls" || file_ext == ".xlsx")
            {
                #region read Excel_Format
                string len="";
                string validateContainer = string.Empty;
                while (ds.Tables[0].Rows[a][0] != System.DBNull.Value)
                {

                    DataRow dr = dsXML.Tables[0].NewRow();

                    dr["CONTAINERID"] = Cont_id_Max;
                    //dr["CONTAINER_IGM_SLNO"] = Session["IGMSLNO"].ToString();
                    dr["CONTAINER_IGM_SLNO"] = ds.Tables[0].Rows[a][0].ToString().Trim();

                    if (ds.Tables[0].Rows[a][1].ToString().Trim() == "")
                    {

                        dr["CONTAINER_IGM_NO"] = "0";
                        dr["CONTAINER_IGM_DATE"] = "01/01/1900";
                    }
                    else
                    {
                        dr["CONTAINER_IGM_NO"] = ds.Tables[0].Rows[a][1].ToString().Trim();
                        dr["CONTAINER_IGM_DATE"] = ds.Tables[0].Rows[a][2].ToString().Trim();
                    }

                    /*
                    if (Session["IGMNO"].ToString() == "")
                    {
                        dr["CONTAINER_IGM_NO"] = "0";
                        dr["CONTAINER_IGM_DATE"] ="01/01/1900";
                    }
                    else
                    {
                        dr["CONTAINER_IGM_NO"] = Session["IGMNO"].ToString();
                        dr["CONTAINER_IGM_DATE"] = Session["IGMDATE"].ToString();
                    }
                     */
                    
                    dr["JOBNO"] = IMPORT_JOBNO;

                    if (ds.Tables[0].Rows[a][0].ToString().Trim().Length == 11)
                    {
                    }
                    else
                    {
                        string length = ds.Tables[0].Rows[a][0].ToString() + ",";
                        len += length;
                     }

                    dr["CONTAINER_NO"] = ds.Tables[0].Rows[a][3].ToString().Trim();

                    if (ds.Tables[0].Rows[a][3].ToString().Trim().Length != 11)
                    {
                        validateContainer += ds.Tables[0].Rows[a][3].ToString().Trim() +" ";                        
                    }
                    

                    dr["SEAL_NO"] = ds.Tables[0].Rows[a][4].ToString();
                    dr["FCL_OR_LCL"] = ds.Tables[0].Rows[a][5].ToString();
                    dr["TYPE"] = ds.Tables[0].Rows[a][6].ToString();
                    dr["TRUCK_NO"] = ds.Tables[0].Rows[a][7].ToString();

                    dr["USER_ID"] = currentuser;
                    dr["DATE_TIME"] = LoginDate;
                    dr["STATUS"] = "N";
                    dr["BRANCH_CODE"] = currentbranch;
                    dr["YEAR"] = "";
                    dr["WORKING_PERIOD"] = Working_Period;

                    dr["MODIFIEDBY"] = LoginDate;
                    dr["MODIFIEDON"] = LoginDate;
                    dr["AMENDMENT_TYPE"] = "";
                    dr["AMENDMENT_STATUS"] = "";

                    dr["JOBNO_PS"] = Session["JOBNO_PS"].ToString();

                    dsXML.Tables[0].Rows.Add(dr);
                    a++;
                    Cont_id_Max = Cont_id_Max + 1;
                }
                #endregion

                if (!string.IsNullOrWhiteSpace(validateContainer))
                {
                    Alert_msg(validateContainer + " Container Number should be 11 digits...");
                    validateContainer = "";
                    return;
                }

                dt = dsXML.Tables["Import_Annex_C_Container_Details"];

                //dt=  RemoveDuplicateRows(dt, "LICENSE_NO","INV_SL_NO","ITEM_SL_NO");

                if (dsXML.Tables[0].Rows.Count > 0)
                {
                    admin.SqlBulk_Upload_Product("CONTAINER_DETAILS", dsXML.Tables[0], Session["currentcomp_db"].ToString());
                    Alert_msg("Excel Uploaded Successfully..!!");
                }
            }
        }
        Gridbind_Import_Container(ddlIGM_SL_No.SelectedValue, "ddl_change");
    }

    protected void ddlIGM_SL_No_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIGM_SL_No.SelectedItem.Text != string.Empty)
        {
            //---------------------this line hide by Chithra on 21-11-2019 for Direct Exbond inv slno Bind-----------------------------
            //this.gv_Invoice.SelectedIndex = Convert.ToInt32(ddlInv_SL_No.SelectedValue.ToString()) - 1; // here index getting minus from invslno
            //-------------------------------------------------------------------------------------------------------------------------

            this.gv_Container.SelectedIndex = Convert.ToInt32(ddlIGM_SL_No.SelectedIndex);
           // Gridbind_Import_Container(this.gv_Container, new EventArgs());
            btnNew_Click(sender, e);

            //Gridbind_Import_Container(ddlIGM_SL_No.SelectedValue, "ddl_change");
        }
    }
    protected void btn_DeleteAll_Click(object sender, EventArgs e)
    {
        Transact.CONTAINERID = ddlIGM_SL_No.SelectedValue;
        Transact.JOBNO = IMPORT_JOBNO;
        Transact.WORKING_PERIOD = SELECT_BRANCH;
        Transact.Ename = "Delete_All_Containers";
        dtuser = Transact.ExcelUpload_Container_Details();
        Gridbind_Import_Container(ddlIGM_SL_No.SelectedValue, "ddl_change");
    }

    private void Tbl_Filed_Modified_History(DataTable dt_Curr_tbl)
    {
        try
        {
            DataTable dt_Prev_Table = DataTable_Mapping_Controls(dt_Curr_tbl, "Y");
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
            DataTable dt_modified = DataTable_Mapping_Controls(dt_m2, "N");
            DataTableComparer Dt_Change = new DataTableComparer();
            Dt_Change.GetMismatchedRowsFast(dt_Prev, dt_modified, "CONTAINER_IGM_NO", "Container", IMPORT_JOBNO, "", "", currentuser, currentbranch);

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

            dr["CONTAINERID"] = "";
            dr["CONTAINER_IGM_SLNO"] = ddlIGM_SL_No.SelectedValue;
            dr["CONTAINER_IGM_NO"] = Session["IGMNO"].ToString();
            dr["CONTAINER_NO"] = txtContainerNo.Text.Trim();
            dr["SEAL_NO"] = txtSealNo.Text.Trim();
            dr["FCL_OR_LCL"] = ddlFCL_LCL.SelectedValue;
            dr["TYPE"] = ddlType.SelectedValue;
            dr["TRUCK_NO"] = txttruckrNo.Text.Trim();
            dr["AMENDMENT_TYPE"] = ddl_AmendmentType.SelectedValue;

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