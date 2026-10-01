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
using System.Web.Script.Serialization;
using Microsoft.ApplicationBlocks.Data;

public partial class Transaction_IGMDetails_new : ThemeClass
{
    Date_Time rep = new Date_Time();
    Transaction Transact = new Transaction();
    DataSet dss = new DataSet();
    AppSession aps = new AppSession();
    DataTable dt = new DataTable();
    public string IGMSLNO = "", COMPANY_ID = "";
    ErrorLogs er = new ErrorLogs();
    public int i;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string DEFAULT_DATE;
    public string SELECT_TYPE, SELECT_BRANCH;

    public string IGM_Transportmode, IMPORT_JOBNO, IMPORT_JOBDATE, FILING_STAUS, Flight_Vesseldate = "", IGMDATE = "", GATEWAY_IGMDATE = "", MAWB_DATE, HAWB_DATE, IGM_GATEWAY_IGM_DATE;
    public string sno = "", flag = "", IGM_SLNO_UPDATE = "";
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, Audit_YN = "";
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE;
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
            DEFAULT_DATE = Session["DEFAULT_DATE"].ToString();

            if (Session["TRANSPORT_MODE"] != null)
            {
                IGM_Transportmode = Session["TRANSPORT_MODE"].ToString();
            }

            hdn_Transport_Mode.Value = IGM_Transportmode;
            if (!IsPostBack)
            {
                hd_CUSTOMHOUSE_CODE.Value = Session["IMP_Job_CUSTOMHOUSE_CODE"].ToString();
                hdn_CompanyID.Value = Session["COMPANY_LICENSE"].ToString().ToLower();
            }

            if (COMPANY_ID == "" || COMPANY_ID == "1640")
            {
                Btn_xl_upload.Visible = true;
            }

            if (Connection.Audit_Logs(COMPANY_ID) == "Y")
            {
                Audit_YN = "Y";
            }

            SELECT_BRANCH = Connection.Get_Company_Type();
            Screen_Id = 7;
            Page_Rights(Screen_Id);

            if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
            {
                if (Session["FILING_STATUS"] != null)
                {
                    FILING_STAUS = Session["FILING_STATUS"].ToString();
                    hdn_filling_status.Value = FILING_STAUS;
                }

                /*
                // start added by jayanthi on 19-Mar-22
                if (ViewState["IGM_ID"] == "" || ViewState["IGM_ID"] == null)
                {
                    if (Session["IsCHA_Mapped"] != null)
                    {
                        if (Session["FRT_IMP_JOBNO_CHA"] != null && Session["IsCHA_Mapped"].ToString() == "Y")
                        {
                            IGM_Load_From_FRT();
                        }
                    }
                }
                // end  added by jayanthi on 19-Mar-22
                */
            }
            else
            {
                hdn_filling_status.Value = Request.QueryString["jobno"].ToString();
                FILING_STAUS = hdn_filling_status.Value;
            }

            if (FILING_STAUS == "Advanced" || FILING_STAUS == "Prior")
            {
                chk_MBL.Visible = true;
            }
            else
            {
                chk_MBL.Visible = false;
            }


            if (IGM_Transportmode == "Air")
            {
                txtMAWBMBLNo.Attributes.Add("onblur", "javascript:MAWB_VALIDATION()");
            }

            if (!string.IsNullOrEmpty(Session["BE_TYPE"] as string))
            {
                hdn_BEType.Value = Session["BE_TYPE"].ToString();
            }

            Pageload();
            Load_Mandatory_Flags();
            //auto search

            //txtAirlineName.Attributes.Add("onkeyup", "javascript:Call_AirLine_Code('" + txtAirlineName.ClientID + "', '" + txtAirlineCode.ClientID + "')");
            txtAirlineName.Attributes.Add("onblur", "javascript:Call_AirLine_Code('" + txtAirlineName.ClientID + "', '" + txtAirlineCode.ClientID + "')");
            txtMAWBMBLNo.Attributes.Add("onchange", "javascript:Call_MAWBMBLNo_Exists('" + txtMAWBMBLNo.ClientID + "', '" + txtMAWBMBLDate.ClientID + "')");



            // txtGrossWeight.Attributes.Add("onblur", "javascript:extractNumber(this,3,false);Clear_Dot(this);");
            //auto search

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
                    btn_save_new.ToolTip = "This Job is Locked by Admin";
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

            if (COMPANY_ID == "10" || Connection.COMPANYID() == "1" || COMPANY_ID == "2145")
            {
                DateTime opentime = DateTime.Now;
                DateTime closingtime = opentime.AddMinutes(15);

                DataSet ds_User_st = new DataSet();
                ds_User_st = Common_CS.Get_Job_User_Lock_Status(IMPORT_JOBNO, currentuser, Convert.ToString(opentime), Convert.ToString(closingtime), "Insert_User_History", "Import");
            }

            if (!Page.IsPostBack)
            {
                if (IGM_Transportmode == "Air")
                {
                    lbl_air_AwbStat.Visible = true;
                    lbl_Land_ICDStat.Visible = false;
                    lblTrk_IGM.Visible = true;
                }
                else if (IGM_Transportmode == "Sea")
                {
                    lbl_air_AwbStat.Visible = false;
                    lbl_Land_ICDStat.Visible = false;
                    lblTrk_IGM.Visible = true;
                }
                else if (IGM_Transportmode == "Land")
                {
                    lbl_air_AwbStat.Visible = false;
                    lbl_Land_ICDStat.Visible = true;
                    lblTrk_IGM.Visible = false;
                }
            }
            if (!IsPostBack)
            {
                //CalendarExtender3.EndDate = DateTime.Today;   // Hide by shanthini on 12-08-2026
                //CalendarExtender4.EndDate = DateTime.Today;
                if (COMPANY_ID == "247" || COMPANY_ID == "293" || COMPANY_ID == "4" || COMPANY_ID == "10")
                {
                    ddlhrs_FV_dat.Visible = true;
                    ddlMin_FV_dat.Visible = true;
                    txtChargable_Wgt.Visible = true;
                }
                else
                {
                    ddlhrs_FV_dat.Visible = false;
                    ddlMin_FV_dat.Visible = false;
                    txtChargable_Wgt.Visible = false;
                }

                if (COMPANY_ID == "4" || COMPANY_ID == "10" || COMPANY_ID == "537" || COMPANY_ID == "1029")
                {
                    lbl_RotationNo.Visible = true;
                    txt_RotationNo.Visible = true;
                    lbl_Rotation_Date.Visible = true;
                    txt_Rotation_Date.Visible = true;
                }
                else
                {
                    lbl_RotationNo.Visible = false;
                    txt_RotationNo.Visible = false;
                    lbl_Rotation_Date.Visible = false;
                    txt_Rotation_Date.Visible = false;
                }

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void IGM_Load_From_FRT()
    {
        DataSet ds = new DataSet();
        
        try
        {
            Transact.SEARCH_CAT = ""; Transact.SEARCH_ITEM = Session["FRT_IMP_JOBNO_CHA"].ToString();
            Transact.WORKING_PERIOD = currentbranch; Transact.TRANSPORT_MODE = IGM_Transportmode;

            if (IGM_Transportmode == "Air")
            {
                Transact.flag = "Import-Air-JobNo";
            }
            else if (IGM_Transportmode == "Sea")
            {
                Transact.flag = "Import-Sea-JobNo";
            }
            else if (IGM_Transportmode == "Land")
            {
                Transact.flag = "Import-Other-Jobno";
            }

            ds = Transact.FREIGHT_IMP_EXP_Job_Load();
            if (ds.Tables.Count > 1)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    txtAirlineName.Text = ds.Tables[1].Rows[0]["IGM_AIRLINENAME"].ToString();
                    txtFlightVesselNo.Text = ds.Tables[1].Rows[0]["IGM_FLIGHTNO_VESSELNO"].ToString();
                    txtFlightVesselDate.Text = ds.Tables[1].Rows[0]["IGM_FLIGHT_VESSELDATE"].ToString();
                    txtMAWBMBLNo.Text = ds.Tables[1].Rows[0]["IGM_MAWB_MBL"].ToString();
                    txtMAWBMBLDate.Text = ds.Tables[1].Rows[0]["IGM_MAWB_MBLDATE"].ToString();
                    txtHAWBHBLNo.Text = ds.Tables[1].Rows[0]["IGM_HAWB_HBLNO"].ToString();
                    txtHAWBHBLDate.Text = ds.Tables[1].Rows[0]["IGM_HAWB_HBLDATE"].ToString();
                    txtAirlineCode.Text = ds.Tables[1].Rows[0]["IGM_AIRLINECODE"].ToString();
                    txtPackages.Text = ds.Tables[1].Rows[0]["IGM_NOOFPACKAGE"].ToString();
                    txtPackageType.Text = ds.Tables[1].Rows[0]["IGM_PACKAGETYPE"].ToString();
                    txtGrossWeight.Text = ds.Tables[1].Rows[0]["IGM_GROSSWEIGHT"].ToString();
                    txtGrossWeightType.Text = ds.Tables[1].Rows[0]["IGM_TYPEOFWEIGHT"].ToString();
                    txtNetWeight.Text = ds.Tables[1].Rows[0]["IGM_NETWEIGHT"].ToString();
                    txtNetWeightType.Text = ds.Tables[1].Rows[0]["IGM_NETWEIGHTTYPE"].ToString();
                    txtMarksNos.Text = ds.Tables[1].Rows[0]["IGM_MARKSNOS"].ToString();
                    txtGateway_Igm_No.Text = ds.Tables[1].Rows[0]["IGM_GATEWAY_IGM_NO"].ToString();
                    txtGateway_Igm_Date.Text = ds.Tables[1].Rows[0]["IGM_GATEWAY_IGM_DATE"].ToString();
                    txtGateway_Port_Code.Text = ds.Tables[1].Rows[0]["IGM_GATEWAY_PORT_CODE"].ToString();
                    txt_LineNumber.Text = ds.Tables[1].Rows[0]["IGM_LINE_NUMBER"].ToString();
                    txt_ShippingLine.Text = ds.Tables[1].Rows[0]["IGM_SHIPPING_LINE_NUMBER"].ToString();
                    txt_Voyage.Text = ds.Tables[1].Rows[0]["IGM_VOYAGE"].ToString();
                    txtChargable_Wgt.Text = ds.Tables[1].Rows[0]["IGM_CHARGEABLE_WGT"].ToString();
                    txt_RotationNo.Text = ds.Tables[1].Rows[0]["ROTATION_NO"].ToString();
                    txt_Rotation_Date.Text = ds.Tables[1].Rows[0]["ROTATION_DATE"].ToString();

                    txtIGMNo.Text = ds.Tables[1].Rows[0]["IGM_NO"].ToString();
                    txtIGMDate.Text = ds.Tables[1].Rows[0]["IGM_DATE"].ToString();
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
                gv_IGM.ToolTip = "You don't have permission to access";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void Pageload()
    {
     try
     {
        if (!this.IsPostBack)
        {
            txtAirlineName.Focus();

            hdfTransport_mode.Value = "";
        }
        if (Session["IMPORT_JOBNO"] != null || Session["IMPORT_JOBDATE"] != null)
        {
            pageload_IGM();
        }
        else
        {
            //Response.Write("<script>window.open('General.aspx','_parent');</script>");
            Response.Write("<script>window.parent.document.getElementById('General').click();</script>");
        }
    }
     catch (Exception ex)
     {
         er.makeLog(ex.Message);
         
     }
    }
    public void pageload_IGM()
    {
        try
        {

            IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
            hdn_Jobno.Value = IMPORT_JOBNO;
            IMPORT_JOBDATE = Session["IMPORT_JOBDATE"].ToString();

            Session["IGMSLNO"] = null;
            Session["IGMNO"] = null;

            if (!IsPostBack)
            {
                Gridbind_IGM();
            }

            if (txtIGMNo.Text != "")
            {
                ViewState["IgmNo"] = txtIGMNo.Text;
            }
            if (txtIGMDate.Text != "")
            {
                ViewState["Igmdate"] = txtIGMNo.Text;
            }
            if (txtFlightVesselDate.Text != "")
            {
                ViewState["vesseldate"] = txtIGMNo.Text;
            }

            if (IGM_Transportmode == "Air")
            {

                //pop_text_area_transac_popup_inn_container_IGM_tag2.Visible = false; //-- hide on 12-12-2023 by Chithra sugg.by Bala sir

                pop_text_area_transac_popup_inn_container_IGM_tag2.Visible = true;
                txtGateway_Igm_No.Enabled = false;
                txtGateway_Igm_Date.Enabled = false;
                txtGateway_Port_Code.Enabled = true;

                txtAirlineName.Enabled = true;
                txtAirlineCode.Enabled = true;
                // tabPanel2.Enabled = false;

                //if (Session["FILING_STATUS"] != null)
                //{
                //    FILING_STAUS = Session["FILING_STATUS"].ToString();
                //    hdn_filling_status.Value = FILING_STAUS;
                if (FILING_STAUS == "Advanced")
                {
                    if (!this.IsPostBack)
                    {
                        txtAirlineName.Focus();
                    }
                    txtIGMNo.Enabled = true;
                    txtIGMDate.Enabled = true;
                    txtFlightVesselDate.Enabled = false;
                    if (Request.QueryString["jobno"] != "" || Request.QueryString["jobno"] != null)
                    {
                        txtFlightVesselDate.Text = "";
                    }
                    if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00247" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00004")
                    {
                        txtFlightVesselDate.Enabled = true;
                    }
                    if (!this.IsPostBack)
                    {
                        if (DEFAULT_DATE == "Yes")
                        {
                            txtIGMDate.Text = rep.Today_Date();
                            txtMAWBMBLDate.Text = rep.Today_Date();
                            txtHAWBHBLDate.Text = rep.Today_Date();
                        }
                    }
                }
                else if (FILING_STAUS == "Prior")
                {

                    txtIGMNo.Enabled = false;
                    txtIGMDate.Enabled = false;

                    txtFlightVesselDate.Enabled = false;
                    if (Request.QueryString["jobno"] != "" || Request.QueryString["jobno"] != null)
                    {
                        txtIGMNo.Text = "";
                        txtIGMDate.Text = "";
                        txtFlightVesselDate.Text = "";
                    }
                    if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00247" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00004")
                    {
                        txtFlightVesselDate.Enabled = true;
                    }

                    if (!this.IsPostBack)
                    {
                        if (DEFAULT_DATE == "Yes")
                        {
                            txtMAWBMBLDate.Text = rep.Today_Date();
                            txtHAWBHBLDate.Text = rep.Today_Date();
                        }
                    }
                }
                else if (FILING_STAUS == "Normal")
                {
                    if (!this.IsPostBack)
                    {
                        txtAirlineName.Focus();
                    }
                    txtIGMNo.Enabled = true;
                    txtIGMDate.Enabled = true;
                    txtFlightVesselDate.Enabled = true;
                    if (Request.QueryString["jobno"] != "" || Request.QueryString["jobno"] != null)
                    {
                        //txtIGMNo.Text = ViewState["IgmNo"].ToString();
                        //txtIGMDate.Text = ViewState["Igmdate"].ToString();
                        //txtFlightVesselDate.Text = ViewState["vesseldate"].ToString();
                    }
                    if (!this.IsPostBack)
                    {
                        if (DEFAULT_DATE == "Yes")
                        {
                            txtIGMDate.Text = rep.Today_Date();
                            txtFlightVesselDate.Text = rep.Today_Date();

                            txtMAWBMBLDate.Text = rep.Today_Date();
                            txtHAWBHBLDate.Text = rep.Today_Date();
                        }
                    }
                }
                //}
                CONTAINER.Style.Add("display", "none");
            }
            else
            {
                //CONTAINER.Style.Add("display", "block");
                //if (IGM_Transportmode == "Land" || IGM_Transportmode == "Sea")
                if (IGM_Transportmode == "Land")
                {
                    //pnl_Land_Gateway.Visible = true;
                    pop_text_area_transac_popup_inn_container_IGM_tag2.Visible = true;

                    txtGateway_Igm_No.Enabled = true;
                    txtGateway_Igm_Date.Enabled = true;
                    txtGateway_Port_Code.Enabled = true;
                    //pop_text_area_transac_popup_inn_container_IGM_Container2_grid_gateway.Style.Add("height", "125px");

                    if (hdn_BEType.Value == "SEZ FTA-Z" && FILING_STAUS == "Prior")
                    {
                        txtIGMNo.Enabled = true;
                        txtIGMDate.Enabled = true;
                        txtFlightVesselDate.Enabled = false;
                    }
                    else if (FILING_STAUS == "Prior" || FILING_STAUS == "Advanced")
                    {
                        txtIGMNo.Enabled = false;
                        txtIGMDate.Enabled = false;
                        txtFlightVesselDate.Enabled = false;
                        //txtGateway_Igm_No.Enabled = false;
                        //txtGateway_Igm_Date.Enabled = false;
                    }

                    if (FILING_STAUS == "Advanced")
                    {
                        txtGateway_Igm_No.Enabled = false;
                        txtGateway_Igm_Date.Enabled = false;
                    }

                }
                else if (IGM_Transportmode == "Sea")
                {
                    //pnl_Land_Gateway.Visible = true;
                    pop_text_area_transac_popup_inn_container_IGM_tag2.Visible = true;
                    txtGateway_Igm_No.Enabled = false;
                    txtGateway_Igm_Date.Enabled = false;
                    txtGateway_Port_Code.Enabled = true;

                    if (COMPANY_ID == "1593")//06-10-2022 -- Jay chemicals for checklist purpose
                    {
                        txtGateway_Igm_No.Enabled = true;
                        txtGateway_Igm_Date.Enabled = true;
                    }

                    //pop_text_area_transac_popup_inn_container_IGM_Container2_grid_gateway.Style.Add("height", "125px");
                }
                txtIGMNo.Focus();
                txtAirlineName.Enabled = false;
                txtAirlineCode.Enabled = false;
                //tabPanel2.Enabled = true;
                //if (Session["FILING_STATUS"] != null)
                //{
                //    FILING_STAUS = Session["FILING_STATUS"].ToString();
                //    hdn_filling_status.Value = FILING_STAUS;

                if (FILING_STAUS == "Advanced")
                {
                    txtFlightVesselNo.Focus();

                    txtIGMNo.Enabled = false;
                    txtIGMDate.Enabled = false;
                    txtFlightVesselDate.Enabled = false;
                    if (Request.QueryString["jobno"] != "" || Request.QueryString["jobno"] != null)
                    {
                        txtIGMNo.Text = "";
                        txtIGMDate.Text = "";
                        txtFlightVesselDate.Text = "";
                    }
                    if (!this.IsPostBack)
                    {
                        if (DEFAULT_DATE == "Yes")
                        {
                            txtMAWBMBLDate.Text = rep.Today_Date();
                            txtHAWBHBLDate.Text = rep.Today_Date();
                        }
                    }
                }
                else if (FILING_STAUS == "Prior")
                {
                    if (IGM_Transportmode != "Land")//--this condition newly added on 21/12/2020 by Chithra sugg.Bala sir
                    {
                        txtIGMNo.Enabled = true;
                        txtIGMDate.Enabled = true;
                    }

                    txtFlightVesselDate.Enabled = false;
                    txtFlightVesselNo.Focus();
                    if (Request.QueryString["jobno"] != "" || Request.QueryString["jobno"] != null)
                    {
                        txtFlightVesselDate.Text = "";
                    }
                    if (!this.IsPostBack)
                    {
                        if (DEFAULT_DATE == "Yes")
                        {
                            txtIGMDate.Text = rep.Today_Date();

                            txtMAWBMBLDate.Text = rep.Today_Date();
                            txtHAWBHBLDate.Text = rep.Today_Date();
                        }
                    }

                }
                else if (FILING_STAUS == "Normal")
                {
                    txtFlightVesselNo.Focus();


                    txtIGMNo.Enabled = true;
                    txtIGMDate.Enabled = true;
                    txtFlightVesselDate.Enabled = true;
                    if (Request.QueryString["jobno"] != "" || Request.QueryString["jobno"] != null)
                    {
                        //txtIGMNo.Text = ViewState["IgmNo"].ToString();
                        //txtIGMDate.Text = ViewState["Igmdate"].ToString();
                        //txtFlightVesselDate.Text = ViewState["vesseldate"].ToString();
                    }
                    if (!this.IsPostBack)
                    {
                        if (DEFAULT_DATE == "Yes")
                        {
                            txtIGMDate.Text = rep.Today_Date();
                            txtFlightVesselDate.Text = rep.Today_Date();

                            txtMAWBMBLDate.Text = rep.Today_Date();
                            txtHAWBHBLDate.Text = rep.Today_Date();
                        }
                    }
                }
            }
            //}


            //if (!IsPostBack)
            //{
            //    //tabPanel2.Enabled = false;
            //    Gridbind_IGM();
            //}
        }

        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void Gridbind_IGM()
    {
        DataSet ds_IGM = new DataSet();
        Transact.JOBNO = IMPORT_JOBNO;
        Transact.TRANSPORT_MODE = IGM_Transportmode;
        Transact.WORKING_PERIOD = @SELECT_BRANCH;
        Transact.IGM_SLNO_UPDATE = "0";
        Transact.Ename = "select_con";
        ds_IGM = Transact.RetrieveAll_IGM_Details();
        gv_IGM.DataSource = ds_IGM.Tables[0];
        gv_IGM.DataBind();

        if (gv_IGM.Rows.Count > 0)
        {
            ViewState["IGM_ID"] = gv_IGM.Rows[0].Cells[23].Text.Replace("&nbsp;", "");

            // ----Audit Modified Data -----------------------------------
            if (Audit_YN == "Y")
            {
                Tbl_Filed_Modified_History(ds_IGM.Tables[1]);
            }

            IGM_Edit_UpdateDetails();
        }
    }

    public void IGM_insert_update(string IMPORT_JOBNO, string IMPORT_JOBDATE, string Flight_Vesseldate, string IGM_GATEWAY_IGMDATE, string IGMDATE, string flag, string IGM_SLNO_UPDATE, string IGM_Transportmode, string year)
    {
        try
        {
            Transact.IGM_SLNO_UPDATE = IGM_SLNO_UPDATE;
            Transact.IGM_JOBNO = IMPORT_JOBNO;//call session value from general details
            Transact.IGM_JOBDATE = IMPORT_JOBDATE;//call session value from general details
            Transact.IGM_AIRLINECODE = txtAirlineCode.Text;
            Transact.IGM_AIRLINENAME = txtAirlineName.Text;
            Transact.IGM_FLIGHTNO_VESSELNO = txtFlightVesselNo.Text;

            if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00247")
            {
                if (Flight_Vesseldate != string.Empty)
                {
                    Transact.IGM_FLIGHT_VESSELDATE = Flight_Vesseldate + " " + ddlhrs_FV_dat.SelectedValue.ToString() + ":" + ddlMin_FV_dat.SelectedValue.ToString() + ":00";
                }
                else
                {
                    Transact.IGM_FLIGHT_VESSELDATE = Flight_Vesseldate;
                }
            }
            else
            {
                Transact.IGM_FLIGHT_VESSELDATE = Flight_Vesseldate;
            }


            if (Transact.IGM_FLIGHT_VESSELDATE == "")
            {
                Transact.IGM_FLIGHT_VESSELDATE = "01/01/1900";
            }

            Transact.IGM_NO = txtIGMNo.Text;
            Transact.IGM_DATE = IGMDATE;

            Session["IGMDATE"] = IGMDATE;

            Transact.IGM_MAWB_MBL = txtMAWBMBLNo.Text.ToUpper().Trim();
            Transact.IGM_MAWB_MBLDATE = MAWB_DATE;
            Transact.IGM_HAWB_HBLNO = txtHAWBHBLNo.Text.ToUpper().Trim();
            Transact.IGM_HAWB_HBLDATE = HAWB_DATE;
            Transact.IGM_NOOFPACKAGE = txtPackages.Text;
            Transact.IGM_PACKAGETYPE = txtPackageType.Text;
            Transact.IGM_GROSSWEIGHT = txtGrossWeight.Text;
            Transact.IGM_TYPEOFWEIGHT = txtGrossWeightType.Text;
            string s = "";
            s = txtNetWeight.Text;
            if (s.Length == 0)
                s = "0";
            else
            {
                s = s;
            }
            Transact.IGM_NETWEIGHT = s;

            Transact.IGM_NETWEIGHTTYPE = txtNetWeightType.Text;
            Transact.IGM_MARKSNOS = txtMarksNos.Text.ToUpper();
            Transact.IGM_TRANSPORTMODE = IGM_Transportmode;  //call session value from general details
            Transact.IGM_GATEWAY_IGM_NO = txtGateway_Igm_No.Text; ;  //call session value from general details
            //Transact.IGM_GATEWAY_IGM_DATE = IGM_GATEWAY_IGMDATE;  //call session value from general details
            //Transact.IGM_GATEWAY_IGM_DATE = txtGateway_Igm_Date.Text;  //call session value from general details
            Transact.IGM_GATEWAY_PORT_CODE = txtGateway_Port_Code.Text; ;  //call session value from general details

            if (txtGateway_Igm_Date.Text != "")
            {
                Transact.IGM_GATEWAY_IGM_DATE = txtGateway_Igm_Date.Text;
            }
            else
            {
                Transact.IGM_GATEWAY_IGM_DATE = "01/01/1900";
            }

            Transact.IGM_LINE_NUMBER = txt_LineNumber.Text;
            Transact.IGM_SHIPPING_LINE_NUMBER = txt_ShippingLine.Text;
            Transact.IGM_VOYAGE = txt_Voyage.Text;

            Transact.USER_ID = currentuser;
            Transact.flag = flag;
            Transact.BRANCH_CODE = currentbranch;
            Transact.YEAR = year;
            Transact.WORKING_PERIOD = Working_Period;
            Transact.BRANCH_COMMON = SELECT_BRANCH;
            Transact.IGM_CHARGEABLE_WGT = txtChargable_Wgt.Text;
            Transact.ROTATION_NO = txt_RotationNo.Text;
            Transact.ROTATION_DATE = txt_Rotation_Date.Text;

            Transact.AMENDMENT_TYPE = ddl_AmendmentType.SelectedValue;
            Transact.AMENDMENT_STATUS = "";
            Transact.JOBNO_PS = Session["JOBNO_PS"].ToString();

            gv_IGM.DataSource = Transact.IGM_Details_insertupdate();
            gv_IGM.DataBind();
            //dss = Transact.IGM_Details_insertupdate();
            //Grid_Empty();
            //i = Transact.result;
            //return i;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public int Update_Gen_Filing_Status()
    {
      try
        {
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.IGM_SLNO_UPDATE = "";
            Transact.TRANSPORT_MODE = FILING_STAUS;
            Transact.Ename = "Update_Gen_FilingStatus";
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            dss = Transact.RetrieveAll_IGM_Details();
            i = Transact.result;

           
        }

      catch (Exception ex)
      {
          er.makeLog(ex.Message);
          
      }
      return i;
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            string marksnos = txtMarksNos.Text;
            Transact.ResetFields(Page.Controls);
            txtMarksNos.Text = marksnos;


            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btn_save_new.Visible = true;
            btnNew.Visible = true;
            btnUpdate.CssClass = "updates";

            ViewState["UPDATED_ID"] = null;
            hdn_update_IGM.Value = "";
            //Gridbind_IGM();
            Is_container();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void Is_container()
    {
        try
        {
            if (IGM_Transportmode == "Air")
            {
                CONTAINER.Style.Add("display", "none");
            }
            else
                CONTAINER.Style.Add("display", "block");
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
            flag = "U";

            if (ViewState["IGMSLNO"] != null)
            {
                IGM_SLNO_UPDATE = ViewState["IGMSLNO"].ToString();
                IGM_Save_Update(flag, IGM_SLNO_UPDATE);

                //------------------Audit Modified column History-------------------
                if (Audit_YN == "Y")
                {
                    Audit_Modified_DataTableComparer();
                }
                //------------------------------------------------------------------
            }
            if (hdn_update_IGM.Value != "")
            {
                IGM_SLNO_UPDATE = hdn_update_IGM.Value;
                // IGM_Save_Update(flag, IGM_SLNO_UPDATE); --hide on 05-03-2024 by Chithra for 2 times Update triggering
            }
            Update_Gen_Filing_Status();
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
            if (!Check_Mandatory_Fields_IGM())
                return;

            flag = "S";
            IGM_SLNO_UPDATE = "0";
            IGM_Save_Update(flag, IGM_SLNO_UPDATE);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void MAWB_HAWB_Date()
    {
        try
        {
            if (txtMAWBMBLDate.Text != "")
            {
                MAWB_DATE = txtMAWBMBLDate.Text;
            }
            else
            {
                MAWB_DATE = "01/01/1900";
            }
            if (txtHAWBHBLDate.Text != "")
            {
                HAWB_DATE = txtHAWBHBLDate.Text;
            }
            else
            {
                HAWB_DATE = "01/01/1900";
            }

            if (txtGateway_Igm_Date.Text != "")
            {
                IGM_GATEWAY_IGM_DATE = txtGateway_Igm_Date.Text;
            }
            else
            {
                IGM_GATEWAY_IGM_DATE = "01/01/1900";
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }


    //public void IGM_Save_Update(string flag, string IGM_SLNO_UPDATE)
    //{
    //    try
    //    {

    //        if (Session["TRANSPORT_MODE"] != null)
    //        {
    //            IGM_Transportmode = Session["TRANSPORT_MODE"].ToString();

    //            if (hdn_BEType.Value == "SEZ DTA-M" || hdn_BEType.Value == "Jobbing" || hdn_BEType.Value == "Repair & Return" || hdn_BEType.Value == "Exhibition" || hdn_BEType.Value == "Destruction" || hdn_BEType.Value == "Movement of Goods")
    //            {
    //                SEZ_IGM();
    //            }
    //            else
    //            {
    //                if (IGM_Transportmode == "Air")
    //                {
    //                    if (FILING_STAUS == "Advanced")
    //                    {
    //                        if (txtIGMNo.Text != "" && txtIGMDate.Text != "")
    //                        {
    //                            if (txtFlightVesselDate.Text != "")
    //                            {
    //                                Flight_Vesseldate = txtFlightVesselDate.Text;
    //                            }
    //                            else
    //                            {
    //                                Flight_Vesseldate = "01/01/1900";
    //                            }

    //                            //if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00247" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00004")
    //                            //{

    //                            //    if (txtFlightVesselDate.Text != "")
    //                            //    {
    //                            //        Flight_Vesseldate = txtFlightVesselDate.Text;
    //                            //    }
    //                            //    else
    //                            //    {
    //                            //        Flight_Vesseldate = "01/01/1900";
    //                            //    }
    //                            //}

    //                            IGMDATE = txtIGMDate.Text;
    //                            GATEWAY_IGMDATE = "01/01/1900";
    //                            SAVE_IGM(flag, IGM_SLNO_UPDATE);
    //                        }
    //                        else
    //                            Alert_msg("IGM No and IGM Date cannot be empty");
    //                    }
    //                    else if (FILING_STAUS == "Prior")
    //                    {
    //                        if (txtFlightVesselDate.Text != "")
    //                        {
    //                            Flight_Vesseldate = txtFlightVesselDate.Text;
    //                        }
    //                        else
    //                        {
    //                            Flight_Vesseldate = "01/01/1900";
    //                        }

    //                        if (txtIGMDate.Text != "")
    //                        {
    //                            IGMDATE = txtIGMDate.Text;
    //                        }
    //                        else
    //                        {
    //                            IGMDATE = "01/01/1900";
    //                        }


    //                        if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00247" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00004")
    //                        {
    //                            if (txtFlightVesselDate.Text != "")
    //                            {
    //                                Flight_Vesseldate = txtFlightVesselDate.Text;
    //                            }
    //                            else
    //                            {
    //                                Flight_Vesseldate = "01/01/1900";
    //                            }
    //                        }

    //                        GATEWAY_IGMDATE = "01/01/1900";

    //                        SAVE_IGM(flag, IGM_SLNO_UPDATE);

    //                    }
    //                    else if (FILING_STAUS == "Normal")
    //                    {
    //                        if (txtIGMNo.Text != "" && txtIGMDate.Text != "" && txtFlightVesselDate.Text != "")
    //                        {

    //                            Flight_Vesseldate = txtFlightVesselDate.Text;

    //                            if (txtIGMDate.Text != "")
    //                            {
    //                                IGMDATE = txtIGMDate.Text;
    //                            }
    //                            else
    //                            {
    //                                IGMDATE = "01/01/1900";
    //                            }

    //                            GATEWAY_IGMDATE = "01/01/1900";
    //                            SAVE_IGM(flag, IGM_SLNO_UPDATE);
    //                        }
    //                        else
    //                            Alert_msg("IGM No ,IGM Date and Flight/Vessel Date cannot be empty");
    //                    }
    //                }
    //                else if (IGM_Transportmode == "Sea")
    //                {

    //                    pop_text_area_transac_popup_inn_container_IGM_tag2.Visible = true;
    //                    if (COMPANY_ID == "1593")//06-10-2022 -- Jay chemicals for checklist purpose
    //                    {
    //                        txtGateway_Igm_No.Enabled = true;
    //                        txtGateway_Igm_Date.Enabled = true;
    //                    }
    //                    else
    //                    {
    //                        txtGateway_Igm_No.Enabled = false;
    //                        txtGateway_Igm_Date.Enabled = false;
    //                    }
    //                    txtGateway_Port_Code.Enabled = true;
    //                    Sea();
    //                }

    //                else if (IGM_Transportmode == "Land")
    //                {
    //                    if (hd_CUSTOMHOUSE_CODE.Value.Substring(5, 1) == "6")
    //                    {
    //                        pop_text_area_transac_popup_inn_container_IGM_tag2.Visible = true;

    //                        //if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00747" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00542" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00829" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00004" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00010" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00005")
    //                        //{
    //                        if (txtGateway_Igm_Date.Text != "")
    //                        {
    //                            GATEWAY_IGMDATE = txtGateway_Igm_Date.Text;
    //                        }
    //                        else
    //                        {
    //                            GATEWAY_IGMDATE = "01/01/1900";
    //                        }
    //                        Land();
    //                        //}
    //                        //else
    //                        //{
    //                        //    if (txtGateway_Igm_No.Text != "" && txtGateway_Igm_Date.Text != "" && txtGateway_Port_Code.Text != "")
    //                        //    {
    //                        //        GATEWAY_IGMDATE = txtGateway_Igm_Date.Text;
    //                        //        Land();
    //                        //    }
    //                        //    else

    //                        //        Alert_msg("Gateway IGM No ,Gateway IGM Date and Gateway Portcode cannot be empty");
    //                        //}
    //                    }
    //                    else
    //                    {
    //                        GATEWAY_IGMDATE = "01/01/1900";
    //                        Land();
    //                    }
    //                }
    //            }//end of SEZ_IGM()
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        er.makeLog(ex.Message);
    //        
    //    }
    //}


    public void IGM_Save_Update(string flag, string IGM_SLNO_UPDATE)
    {
        if (Session["TRANSPORT_MODE"] != null)
        {
            IGM_Transportmode = Session["TRANSPORT_MODE"].ToString();

            if (hdn_BEType.Value == "SEZ DTA-M" ||
                hdn_BEType.Value == "Jobbing" ||
                hdn_BEType.Value == "Repair & Return" ||
                hdn_BEType.Value == "Exhibition" ||
                hdn_BEType.Value == "Destruction" ||
                hdn_BEType.Value == "Movement of Goods")
            {
                SEZ_IGM();
            }
            else
            {
                // ✅ Get mandatory flags once
                DataRow mand = Get_Mandatory_Settings();
                bool igmNoRequired = mand != null && mand["IGM_NO"].ToString() == "Y";
                bool igmDateRequired = mand != null && mand["IGM_DATE"].ToString() == "Y";
                bool flightVesselRequired = mand != null && mand["FLIGHT_VESSEL_DATE"].ToString() == "Y"; // ✅ Own flag

                if (IGM_Transportmode == "Air")
                {
                    if (FILING_STAUS == "Advanced")
                    {
                        bool igmNoValid = !igmNoRequired || txtIGMNo.Text.Trim() != "";
                        bool igmDateValid = !igmDateRequired || txtIGMDate.Text.Trim() != "";

                        if (igmNoValid && igmDateValid)
                        {
                            // ✅ Flight/Vessel — use if available, else default
                            Flight_Vesseldate = txtFlightVesselDate.Text.Trim() != ""
                                                ? txtFlightVesselDate.Text
                                                : "01/01/1900";

                            IGMDATE = txtIGMDate.Text.Trim() != ""
                                              ? txtIGMDate.Text
                                              : "01/01/1900";
                            GATEWAY_IGMDATE = "01/01/1900";
                            SAVE_IGM(flag, IGM_SLNO_UPDATE);
                        }
                        else
                        {
                            if (igmNoRequired && txtIGMNo.Text.Trim() == "")
                                Alert_msg("IGM No cannot be empty");
                            else if (igmDateRequired && txtIGMDate.Text.Trim() == "")
                                Alert_msg("IGM Date cannot be empty");
                        }
                    }
                    else if (FILING_STAUS == "Prior")
                    {
                        // ✅ Prior — no mandatory check, always save
                        Flight_Vesseldate = txtFlightVesselDate.Text.Trim() != ""
                                            ? txtFlightVesselDate.Text
                                            : "01/01/1900";

                        IGMDATE = txtIGMDate.Text.Trim() != ""
                                  ? txtIGMDate.Text
                                  : "01/01/1900";

                        if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00247" ||
                            Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00004")
                        {
                            Flight_Vesseldate = txtFlightVesselDate.Text.Trim() != ""
                                                ? txtFlightVesselDate.Text
                                                : "01/01/1900";
                        }

                        GATEWAY_IGMDATE = "01/01/1900";
                        SAVE_IGM(flag, IGM_SLNO_UPDATE);
                    }
                    else if (FILING_STAUS == "Normal")
                    {
                        bool igmNoValid = !igmNoRequired || txtIGMNo.Text.Trim() != "";
                        bool igmDateValid = !igmDateRequired || txtIGMDate.Text.Trim() != "";
                        bool flightDateValid = !flightVesselRequired || txtFlightVesselDate.Text.Trim() != ""; // ✅ Own flag

                        if (igmNoValid && igmDateValid && flightDateValid)
                        {
                            // ✅ Flight/Vessel — use if available, else default
                            Flight_Vesseldate = txtFlightVesselDate.Text.Trim() != ""
                                                ? txtFlightVesselDate.Text
                                                : "01/01/1900";

                            IGMDATE = txtIGMDate.Text.Trim() != ""
                                              ? txtIGMDate.Text
                                              : "01/01/1900";
                            GATEWAY_IGMDATE = "01/01/1900";
                            SAVE_IGM(flag, IGM_SLNO_UPDATE);
                        }
                        else
                        {
                            if (igmNoRequired && txtIGMNo.Text.Trim() == "")
                                Alert_msg("IGM No cannot be empty");
                            else if (igmDateRequired && txtIGMDate.Text.Trim() == "")
                                Alert_msg("IGM Date cannot be empty");
                            else if (flightVesselRequired && txtFlightVesselDate.Text.Trim() == "") // ✅ Own flag
                                Alert_msg("Flight/Vessel Date cannot be empty");
                        }
                    }
                }
                else if (IGM_Transportmode == "Sea")
                {
                    pop_text_area_transac_popup_inn_container_IGM_tag2.Visible = true;

                    if (COMPANY_ID == "1593")
                    {
                        txtGateway_Igm_No.Enabled = true;
                        txtGateway_Igm_Date.Enabled = true;
                    }
                    else
                    {
                        txtGateway_Igm_No.Enabled = false;
                        txtGateway_Igm_Date.Enabled = false;
                    }

                    txtGateway_Port_Code.Enabled = true;
                    Sea();
                }
                else if (IGM_Transportmode == "Land")
                {
                    if (hd_CUSTOMHOUSE_CODE.Value.Substring(5, 1) == "6")
                    {
                        pop_text_area_transac_popup_inn_container_IGM_tag2.Visible = true;

                        GATEWAY_IGMDATE = txtGateway_Igm_Date.Text.Trim() != ""
                                          ? txtGateway_Igm_Date.Text
                                          : "01/01/1900";
                        Land();
                    }
                    else
                    {
                        GATEWAY_IGMDATE = "01/01/1900";
                        Land();
                    }
                }
            }
        }
    }







    protected void btnyes_Click(object sender, EventArgs e)
    {
        //btnNew_Click(sender, e);
        if (IGM_Transportmode == "Air")
        {

        }
        else
        {
            //TabContainer1.ActiveTabIndex = 1;
        }
    }

    public void SAVE_IGM(string flag, string IGM_SLNO_UPDATE)
    {
        try
        {
            string year = "";
            MAWB_HAWB_Date();

            IGM_insert_update(IMPORT_JOBNO, IMPORT_JOBDATE, Flight_Vesseldate, GATEWAY_IGMDATE, IGMDATE, flag, IGM_SLNO_UPDATE, IGM_Transportmode, year);
            i = Transact.result;
            hdn_update_IGM.Value = Convert.ToString(Transact.UPDATE_ID);


            if (i == 1)
            {
                Transact.Imp_Job_Logs_All_Details(Connection.IMP_Jobno(), "", "", "IGM", flag, "Insert");
            }


            if (flag == "S")
            {
                if (i == 1)
                {
                    //-----------------------FOR USER RIGHTS--------------------------------//
                    user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);

                    PAGE_MODIFY = user_Create.PAGE_MODIFY;

                    //---------------SAVE ONLY------------------//

                    if (PAGE_MODIFY == "False")
                    {
                        Transact.ResetFields(Page.Controls);
                        btnDelete.Visible = false;
                        btnUpdate.Visible = false;
                        btnSave.Visible = true;
                        btn_save_new.Visible = true;
                        btnNew.Visible = true;
                        btnUpdate.CssClass = "updates";

                        ViewState["UPDATED_ID"] = null;
                        hdn_update_IGM.Value = "";
                    }
                    else
                    {
                        btnUpdate.CssClass = "save";
                        btnUpdate.Visible = true;
                        btnSave.Visible = false;
                        btn_save_new.Visible = false;
                        Transact.IGM_NO = txtIGMNo.Text;
                        Transact.IGM_DATE = txtIGMDate.Text;
                        txtAirlineName.Focus();
                        btnSave.Focus();

                        ViewState["IGMSLNO"] = Transact.UPDATE_ID.ToString();
                    }

                    ViewState["UPDATED_ID"] = null;
                    Elogix_Service();
                    Alert_msg("IGM Saved Successfully", "btnSave");
                }
                else
                {
                    Alert_msg("IGM Not Saved", "btnSave");
                }
            }
            else
            {
                if (i == 1)
                {
                    Transact.IGM_NO = txtIGMNo.Text;
                    Transact.IGM_DATE = txtIGMDate.Text;
                    txtAirlineName.Focus();
                    Elogix_Service();

                    if (ViewState["UPDATED_ID"] != null)
                    {
                        Alert_msg("IGM Updated Successfully", "btnUpdate");
                    }
                    else
                    {
                        Alert_msg("IGM Saved Successfully", "btnUpdate");
                    }
                }
                else
                {
                    Alert_msg("IGM Not Saved");
                }
            }
            if (i == 1)
            {
                Session.Remove("IGMSLNO");
                Session.Remove("IGMNO");
                Session["IGMSLNO"] = Transact.UPDATE_ID;
                Session["IGMNO"] = txtIGMNo.Text;
                Is_container();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void Sea()
    {
        try
        {
            //if (Session["FILING_STATUS"] != null)
            //{
            //    FILING_STAUS = Session["FILING_STATUS"].ToString();
            //    hdn_filling_status.Value = FILING_STAUS;

            if (FILING_STAUS == "Advanced")
            {
                if (txtIGMDate.Text != "" && txtFlightVesselDate.Text != "")
                {
                    Flight_Vesseldate = txtFlightVesselDate.Text;
                    IGMDATE = txtIGMDate.Text;
                }
                else
                {
                    IGMDATE = "01/01/1900";
                    Flight_Vesseldate = "01/01/1900";
                }
                MAWB_HAWB_Date();

                if (Connection.COMPANYID() != "1593")//06-10-2022 -- Jay chemicals for checklist purpose
                {
                    GATEWAY_IGMDATE = "01/01/1900";
                }
                else
                {
                    GATEWAY_IGMDATE = txtGateway_Igm_Date.Text;
                }

                SAVE_IGM(flag, IGM_SLNO_UPDATE);

            }
            else if (FILING_STAUS == "Prior")
            {
                if (txtIGMNo.Text != "" && txtIGMDate.Text != "")
                {
                    if (txtFlightVesselDate.Text != "")
                    {
                        Flight_Vesseldate = txtFlightVesselDate.Text;
                    }
                    else
                    {
                        Flight_Vesseldate = "01/01/1900";
                    }
                    IGMDATE = txtIGMDate.Text;

                    if (Connection.COMPANYID() != "1593")//06-10-2022 -- Jay chemicals for checklist purpose
                    {
                        GATEWAY_IGMDATE = "01/01/1900";
                    }
                    else
                    {
                        GATEWAY_IGMDATE = txtGateway_Igm_Date.Text;
                    }

                    MAWB_HAWB_Date();

                    SAVE_IGM(flag, IGM_SLNO_UPDATE);
                }
                else
                    Alert_msg("IGM No and IGM Date cannot be empty");

            }
            else if (FILING_STAUS == "Normal")
            {
                if (txtIGMNo.Text != "" && txtIGMDate.Text != "" && txtFlightVesselDate.Text != "")
                {
                    Flight_Vesseldate = txtFlightVesselDate.Text;
                    IGMDATE = txtIGMDate.Text;

                    if (Connection.COMPANYID() != "1593")//06-10-2022 -- Jay chemicals for checklist purpose
                    {
                        GATEWAY_IGMDATE = "01/01/1900";
                    }
                    else
                    {
                        GATEWAY_IGMDATE = txtGateway_Igm_Date.Text;
                    }
                    MAWB_HAWB_Date();

                    SAVE_IGM(flag, IGM_SLNO_UPDATE);
                }
                else
                    Alert_msg("IGM No ,IGM Date and Flight/Vessel Date cannot be empty");

            }
            //}
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    private void SEZ_IGM()
    {
        try
        {
            if (txtIGMDate.Text == "")
            {
                IGMDATE = "01/01/1900";
            }
            else
            {
                IGMDATE = txtIGMDate.Text;
            }
            if (txtFlightVesselDate.Text == "")
            {
                Flight_Vesseldate = "01/01/1900";
            }
            else
            {
                Flight_Vesseldate = txtFlightVesselDate.Text;
            }
            if (txtGateway_Igm_Date.Text == "")
            {
                GATEWAY_IGMDATE = "01/01/1900";
            }
            else
            {
                GATEWAY_IGMDATE = txtGateway_Igm_Date.Text;
            }

            MAWB_HAWB_Date();
            SAVE_IGM(flag, IGM_SLNO_UPDATE);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void Land()
    {
        try
        {

            //if (Session["FILING_STATUS"] != null)
            //{
            //    FILING_STAUS = Session["FILING_STATUS"].ToString();
            //    hdn_filling_status.Value = FILING_STAUS;

            if (FILING_STAUS == "Advanced")
            {
                if (txtIGMDate.Text != "" && txtFlightVesselDate.Text != "")
                {
                    Flight_Vesseldate = txtFlightVesselDate.Text;
                    IGMDATE = txtIGMDate.Text;

                }
                else
                {
                    IGMDATE = "01/01/1900";
                    Flight_Vesseldate = "01/01/1900";
                }
                MAWB_HAWB_Date();

                // GATEWAY_IGMDATE = "01/01/1900";

                SAVE_IGM(flag, IGM_SLNO_UPDATE);

            }
            else if (FILING_STAUS == "Prior")
            {
                //if (txtIGMNo.Text != "" && txtIGMDate.Text != "")
                //{
                if (txtFlightVesselDate.Text != "")
                {
                    Flight_Vesseldate = txtFlightVesselDate.Text;

                }
                else
                {
                    Flight_Vesseldate = "01/01/1900";
                }
                if (txtIGMDate.Text != "")
                {
                    IGMDATE = txtIGMDate.Text;
                }
                else
                {
                    IGMDATE = "01/01/1900";
                }
                MAWB_HAWB_Date();

                SAVE_IGM(flag, IGM_SLNO_UPDATE);

                //----------Disabled on 21Jan2016 for Indev Logistics(Bala)--------// 
                //else
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('IGM No and IGM Date cannot be empty')</script>", false);


                // Alert_msg("IGM No and IGM Date cannot be empty");
                //----------Disabled on 21Jan2016 for Indev Logistics(Bala)--------// 

            }
            else if (FILING_STAUS == "Normal")
            {
                if (txtIGMNo.Text != "" && txtIGMDate.Text != "" && txtFlightVesselDate.Text != "")
                {
                    Flight_Vesseldate = txtFlightVesselDate.Text;
                    IGMDATE = txtIGMDate.Text;
                    MAWB_HAWB_Date();

                    SAVE_IGM(flag, IGM_SLNO_UPDATE);
                }
                else
                    Alert_msg("IGM No ,IGM Date and Flight/Vessel Date cannot be empty");
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
            Transact.IGM_SLNO_UPDATE = ViewState["IGMSLNO"].ToString();
            Transact.TRANSPORT_MODE = IGM_Transportmode;
            Transact.Ename = "delete";
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            gv_IGM.DataSource = Transact.RetrieveAll_IGM_Details();
            gv_IGM.DataBind();

            int ii = 0;
            ii = Transact.result;

            if (ii > 0)
            {
                btnNew_Click(sender, e);
                CONTAINER.Style.Add("display", "none");
                Elogix_Service();
                Alert_msg("IGM Deleted");

                Transact.Imp_Job_Logs_All_Details(Connection.IMP_Jobno(), "", "", "IGM", "D", "Insert");

            }
            else
            {
                Alert_msg("IGM Not Deleted");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void gv_IGM_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["IGM_ID"] = Convert.ToString(this.gv_IGM.SelectedDataKey.Value);

            if (ViewState["IGM_ID"] != "" && ViewState["IGM_ID"] != null)
            {
                sno = gv_IGM.SelectedRow.Cells[2].Text;
                ViewState["IGMSLNO"] = sno;
                Session["IGMSLNO"] = sno;

                txtIGMNo.Text = gv_IGM.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");

                ViewState["IGMNO"] = txtIGMNo.Text;
                Session["IGMNO"] = txtIGMNo.Text;
                txtIGMDate.Text = gv_IGM.SelectedRow.Cells[4].Text.Replace("01/01/1900", "");
                Session["IGMDATE"] = txtIGMDate.Text;

                txtAirlineName.Text = rep.Replace(gv_IGM.SelectedRow.Cells[5].Text);
                txtFlightVesselNo.Text = gv_IGM.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
                txtFlightVesselDate.Text = gv_IGM.SelectedRow.Cells[7].Text.Replace("01/01/1900", "");


                txtMAWBMBLNo.Text = gv_IGM.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
                txtMAWBMBLDate.Text = gv_IGM.SelectedRow.Cells[9].Text.Replace("01/01/1900", "");

                txtHAWBHBLNo.Text = gv_IGM.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
                txtHAWBHBLDate.Text = gv_IGM.SelectedRow.Cells[11].Text.Replace("01/01/1900", "");

                txtAirlineCode.Text = rep.Replace(gv_IGM.SelectedRow.Cells[12].Text.Replace("&nbsp;", ""));

                txtPackages.Text = gv_IGM.SelectedRow.Cells[13].Text.Replace("&nbsp;", "");

                txtPackageType.Text = gv_IGM.SelectedRow.Cells[14].Text.Replace("&nbsp;", "");


                txtGrossWeight.Text = gv_IGM.SelectedRow.Cells[15].Text.Replace("&nbsp;", "");

                txtGrossWeightType.Text = gv_IGM.SelectedRow.Cells[16].Text.Replace("&nbsp;", "");

                txtNetWeight.Text = gv_IGM.SelectedRow.Cells[17].Text.Replace("&nbsp;", "");
                txtNetWeightType.Text = gv_IGM.SelectedRow.Cells[18].Text.Replace("&nbsp;", "");

                txtMarksNos.Text = rep.Replace(gv_IGM.SelectedRow.Cells[19].Text);

                txtGateway_Igm_No.Text = gv_IGM.SelectedRow.Cells[20].Text.Replace("&nbsp;", "");
                txtGateway_Igm_Date.Text = gv_IGM.SelectedRow.Cells[21].Text.Replace("01/01/1900", "");
                txtGateway_Port_Code.Text = gv_IGM.SelectedRow.Cells[22].Text.Replace("&nbsp;", "");

                txt_LineNumber.Text = gv_IGM.SelectedRow.Cells[24].Text.Replace("&nbsp;", "");
                txt_ShippingLine.Text = gv_IGM.SelectedRow.Cells[25].Text.Replace("&nbsp;", "");
                txt_Voyage.Text = gv_IGM.SelectedRow.Cells[26].Text.Replace("&nbsp;", "");

                if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00247" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00004" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00010")
                {
                    ddlhrs_FV_dat.SelectedValue = gv_IGM.SelectedRow.Cells[27].Text.Replace("&nbsp;", "");
                    ddlMin_FV_dat.SelectedValue = gv_IGM.SelectedRow.Cells[28].Text.Replace("&nbsp;", "");
                }

                txtChargable_Wgt.Text = gv_IGM.SelectedRow.Cells[29].Text.Replace("&nbsp;", "");
                txt_RotationNo.Text = gv_IGM.SelectedRow.Cells[30].Text.Replace("&nbsp;", "");
                txt_Rotation_Date.Text = gv_IGM.SelectedRow.Cells[31].Text.Replace("&nbsp;", "");

                if (!string.IsNullOrEmpty(Session["BE_No"].ToString()))
                {
                    div_AmendmentType.Visible = true;
                    ddl_AmendmentType.SelectedValue = gv_IGM.SelectedRow.Cells[32].Text.Replace("&nbsp;", "");
                }


                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = ViewState["IGMSLNO"].ToString();
                //FOR UPDATED SUCCESSFULLY
                btnUpdate.CssClass = "updates";

                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btn_save_new.Visible = false;
                btnNew.Visible = true;
                if (hdn_Transport_Mode.Value == "Land" || hdn_Transport_Mode.Value == "Sea")
                {
                    CONTAINER.Style.Add("display", "block");
                }
                else
                {
                    CONTAINER.Style.Add("display", "none");

                }

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
                btn_save_new.Visible = true;
                btnNew.Visible = true;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
   
    public void IGM_Edit_UpdateDetails()
    {
        try
        {
            if (ViewState["IGM_ID"] != "" && ViewState["IGM_ID"] != null)
            {
                sno = gv_IGM.Rows[0].Cells[2].Text;

                ViewState["IGMSLNO"] = sno;
                Session["IGMSLNO"] = sno;


                txtIGMNo.Text = gv_IGM.Rows[0].Cells[3].Text.Replace("&nbsp;", "");

                ViewState["IGMNO"] = txtIGMNo.Text;
                Session["IGMNO"] = txtIGMNo.Text;
                txtIGMDate.Text = gv_IGM.Rows[0].Cells[4].Text.Replace("01/01/1900", "");
                Session["IGMDATE"] = txtIGMDate.Text;

                txtAirlineName.Text = gv_IGM.Rows[0].Cells[5].Text.Replace("&nbsp;", "");
                txtFlightVesselNo.Text = gv_IGM.Rows[0].Cells[6].Text.Replace("&nbsp;", "");
                txtFlightVesselDate.Text = gv_IGM.Rows[0].Cells[7].Text.Replace("01/01/1900", "");


                txtMAWBMBLNo.Text = gv_IGM.Rows[0].Cells[8].Text.Replace("&nbsp;", "");
                txtMAWBMBLDate.Text = gv_IGM.Rows[0].Cells[9].Text.Replace("01/01/1900", "");

                txtHAWBHBLNo.Text = gv_IGM.Rows[0].Cells[10].Text.Replace("&nbsp;", "");
                txtHAWBHBLDate.Text = gv_IGM.Rows[0].Cells[11].Text.Replace("01/01/1900", "");

                txtAirlineCode.Text = gv_IGM.Rows[0].Cells[12].Text.Replace("&nbsp;", "");

                txtPackages.Text = gv_IGM.Rows[0].Cells[13].Text.Replace("&nbsp;", "");

                txtPackageType.Text = gv_IGM.Rows[0].Cells[14].Text.Replace("&nbsp;", "");


                txtGrossWeight.Text = gv_IGM.Rows[0].Cells[15].Text.Replace("&nbsp;", "");

                txtGrossWeightType.Text = gv_IGM.Rows[0].Cells[16].Text.Replace("&nbsp;", "");

                txtNetWeight.Text = gv_IGM.Rows[0].Cells[17].Text.Replace("&nbsp;", "");
                txtNetWeightType.Text = gv_IGM.Rows[0].Cells[18].Text.Replace("&nbsp;", "");

                txtMarksNos.Text = rep.Replace(gv_IGM.Rows[0].Cells[19].Text);

                txtGateway_Igm_No.Text = gv_IGM.Rows[0].Cells[20].Text.Replace("&nbsp;", "");
                txtGateway_Igm_Date.Text = gv_IGM.Rows[0].Cells[21].Text.Replace("01/01/1900", "");
                txtGateway_Port_Code.Text = gv_IGM.Rows[0].Cells[22].Text.Replace("&nbsp;", "");

                txt_LineNumber.Text = gv_IGM.Rows[0].Cells[24].Text.Replace("&nbsp;", "");
                txt_ShippingLine.Text = gv_IGM.Rows[0].Cells[25].Text.Replace("&nbsp;", "");
                txt_Voyage.Text = gv_IGM.Rows[0].Cells[26].Text.Replace("&nbsp;", "");


                if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00247" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00004" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00010")
                {
                    ddlhrs_FV_dat.SelectedValue = gv_IGM.Rows[0].Cells[27].Text.Replace("&nbsp;", "");
                    ddlMin_FV_dat.SelectedValue = gv_IGM.Rows[0].Cells[28].Text.Replace("&nbsp;", "");
                }

                txtChargable_Wgt.Text = gv_IGM.Rows[0].Cells[29].Text.Replace("&nbsp;", "");
                txt_RotationNo.Text = gv_IGM.Rows[0].Cells[30].Text.Replace("&nbsp;", "");
                txt_Rotation_Date.Text = gv_IGM.Rows[0].Cells[31].Text.Replace("&nbsp;", "");

                if (!string.IsNullOrEmpty(Session["BE_No"].ToString()))
                {
                    div_AmendmentType.Visible = true;
                    ddl_AmendmentType.SelectedValue = gv_IGM.Rows[0].Cells[32].Text.Replace("&nbsp;", "");
                }



                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = ViewState["IGMSLNO"].ToString();
                //FOR UPDATED SUCCESSFULLY
                btnUpdate.CssClass = "updates";

                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btn_save_new.Visible = false;
                btnNew.Visible = true;
                if (hdn_Transport_Mode.Value == "Land" || hdn_Transport_Mode.Value == "Sea")
                {
                    CONTAINER.Style.Add("display", "block");
                }
                else
                {
                    CONTAINER.Style.Add("display", "none");

                }
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
                btn_save_new.Visible = false;
                btnNew.Visible = true;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    protected void gv_IGM_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_IGM, "Select$" + e.Row.RowIndex.ToString()));
                }
                //  if Read Permiision given true for gridview enabled or Disabled----------//

                string MINDATE = "01/01/1900";

                int i = 0;
                string ii = e.Row.Cells[2].Text;
                if (ii != "" && ii != "&nbsp;")
                {
                    if (Convert.ToInt32(e.Row.Cells[2].Text) == i)
                    {
                        //if (Convert.ToInt32(e.Row.Cells[2].Text) <= i)
                        e.Row.Cells[2].Text = string.Empty;
                    }
                }
                else
                {
                    e.Row.Cells[2].Text = string.Empty;
                }
                ii = e.Row.Cells[3].Text;

                if (ii != "" && ii != "&nbsp;")
                {
                    if (Convert.ToInt32(e.Row.Cells[3].Text) == i)
                    {
                        //if (Convert.ToInt32(e.Row.Cells[2].Text) <= i)
                        e.Row.Cells[3].Text = string.Empty;
                    }
                }
                else
                {
                    e.Row.Cells[3].Text = string.Empty;
                }



                if (e.Row.Cells[4].Text == MINDATE)
                {
                    if (Convert.ToDateTime(e.Row.Cells[4].Text) <= Convert.ToDateTime(MINDATE))
                        e.Row.Cells[4].Text = string.Empty;
                }

                if (e.Row.Cells[7].Text == MINDATE)
                {
                    if (Convert.ToDateTime(e.Row.Cells[7].Text) <= Convert.ToDateTime(MINDATE))
                        e.Row.Cells[7].Text = string.Empty;
                }

                if (e.Row.Cells[9].Text == MINDATE)
                {
                    if (Convert.ToDateTime(e.Row.Cells[9].Text) <= Convert.ToDateTime(MINDATE))
                        e.Row.Cells[9].Text = string.Empty;
                }
                if (e.Row.Cells[11].Text == MINDATE)
                {
                    if (Convert.ToDateTime(e.Row.Cells[11].Text) <= Convert.ToDateTime(MINDATE))
                        e.Row.Cells[11].Text = string.Empty;
                }
                if (e.Row.Cells[21].Text == MINDATE)
                {
                    if (Convert.ToDateTime(e.Row.Cells[21].Text) <= Convert.ToDateTime(MINDATE))
                        e.Row.Cells[21].Text = string.Empty;
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    protected void gv_IGM_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gv_IGM.PageIndex = e.NewPageIndex;
            Gridbind_IGM();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void gv_IGM_RowCreated(object sender, GridViewRowEventArgs e)
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
                    gv_IGM.DataSource = dss;

                    gv_IGM.DataBind();
                }
                else
                {
                    gv_IGM.DataSource = dt;
                    gv_IGM.DataBind();
                }
            }
            else
            {
                gv_IGM.DataSource = dt;
                gv_IGM.DataBind();
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
            dt.Rows.Add(dt.NewRow());
            gv_IGM.DataSource = dt;
            gv_IGM.DataBind();
            int columncount = gv_IGM.Rows[0].Cells.Count;
            gv_IGM.Rows[0].Cells.Clear();
            gv_IGM.Rows[0].Cells.Add(new TableCell());
            gv_IGM.Rows[0].Cells[0].ColumnSpan = columncount;
            gv_IGM.Rows[0].Cells[0].Text = "No Record Found";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'IGM', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'IGM', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    ///auto search
    [System.Web.Services.WebMethod]
    public static string GetAirLine_Code(string custid)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            string name = "AIRLINE_MASTER_CODE";
            string rows = "AIRLINE_CODE";
            custid = Auto.Country_Master_FromClientSide_Calling(custid, name, rows);
            if (Auto.Ename != "1")
            {
                custid = "";
            }
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return custid;
    }

    /* this method hide by Chithra on 29-08-2020 - for Agility -to avoid the Page Refresh & Tab index issue
    ///auto search
    protected void txtMAWBMBLNo_TextChanged(object sender, EventArgs e)
    {
        if (txtMAWBMBLNo.Text != string.Empty)
        {
            Import_IGM_Details IGM_MAB = new Import_IGM_Details();
            DataSet ds = new DataSet();

            IGM_MAB.WORKING_PERIOD = SELECT_BRANCH;
            IGM_MAB.Ename = "IGM_MAWB_MBL_Dup";
            IGM_MAB.IGM_MAWB_MBL = txtMAWBMBLNo.Text;

            ds = IGM_MAB.MAWBMBLNo();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Alert_msg("MAWB/ MBL No( " + txtMAWBMBLNo.Text + ") already Exists ", "txtMAWBMBLNo");
                txtMAWBMBLNo.Focus();
            }
            txtMAWBMBLDate.Focus();
        }
    }
     * */

    [System.Web.Services.WebMethod]
    public static string Check_MAWB_No_Exists(string MAWBMBLNo)
    {
      try
        {
        if (MAWBMBLNo != "")
        {
            Import_IGM_Details IGM_MAB = new Import_IGM_Details();
            DataSet ds = new DataSet();

            IGM_MAB.WORKING_PERIOD = Connection.Get_Company_Type();
            IGM_MAB.Ename = "IGM_MAWB_MBL_Dup";
            IGM_MAB.IGM_MAWB_MBL = MAWBMBLNo;

            ds = IGM_MAB.MAWBMBLNo();
            if (ds.Tables[0].Rows.Count > 0)
            {
            }
            else
            {
                MAWBMBLNo = "";
            }
        }
     
        }
         catch (Exception ex)
         {
             Connection.Error_Msg(ex.Message);
         }
         return MAWBMBLNo;
    }



    [System.Web.Services.WebMethod]
    public static string Save_IGM_Tracking_Data(string mode, string mblNo, string hblNo, string trackingJson, bool allowMismatchUpdate)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(trackingJson))
                return "ERROR:Tracking data Not found.";

            if (HttpContext.Current.Session["IMPORT_JOBNO"] == null)
                return "ERROR:Session Expired. Job No not Found";

            string jobNo = HttpContext.Current.Session["IMPORT_JOBNO"].ToString();
            string jobDate = HttpContext.Current.Session["IMPORT_JOBDATE"] != null
                                ? HttpContext.Current.Session["IMPORT_JOBDATE"].ToString() : "";
            string branchCommon = Connection.Get_Company_Type();
            string workingPeriod = HttpContext.Current.Session["WorkingPeriod"] != null
                                ? HttpContext.Current.Session["WorkingPeriod"].ToString() : "";
            string branchCode = HttpContext.Current.Session["currentbranch"] != null
                                ? HttpContext.Current.Session["currentbranch"].ToString() : "";
            string userId = HttpContext.Current.Session["currentuser"] != null
                                ? HttpContext.Current.Session["currentuser"].ToString() : "";

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Dictionary<string, object> payload = serializer.Deserialize<Dictionary<string, object>>(trackingJson);

            Dictionary<string, object> record = payload.ContainsKey("record")
                                                    ? payload["record"] as Dictionary<string, object>
                                                    : null;
            if (record == null) record = new Dictionary<string, object>();

            Dictionary<string, object> viewInfo = null;
            if (payload.ContainsKey("viewDetail") && payload["viewDetail"] != null)
            {
                Dictionary<string, object> viewDetail = payload["viewDetail"] as Dictionary<string, object>;
                if (viewDetail != null && viewDetail.ContainsKey("inwInfo") && viewDetail["inwInfo"] != null)
                    viewInfo = viewDetail["inwInfo"] as Dictionary<string, object>;
            }



            Dictionary<string, object> viewDetails =
                payload.ContainsKey("viewDetail")
                    ? payload["viewDetail"] as Dictionary<string, object>
                    : null;

            Dictionary<string, object> inwInfo =
                viewDetails != null && viewDetails.ContainsKey("inwInfo")
                    ? viewDetails["inwInfo"] as Dictionary<string, object>
                    : null;

            IList containers = null;

            if (viewDetails != null &&
                viewDetails.ContainsKey("containers") &&
                viewDetails["containers"] != null)
            {
                containers = viewDetails["containers"] as IList;
            }

            Transaction Transact = new Transaction();
            Transact.JOBNO = jobNo;
            Transact.TRANSPORT_MODE = mode;
            Transact.WORKING_PERIOD = branchCommon;
            Transact.IGM_SLNO_UPDATE = "0";
            Transact.Ename = "select_con";

            DataSet ds_IGM = Transact.RetrieveAll_IGM_Details();

            if (ds_IGM == null || ds_IGM.Tables.Count == 0 || ds_IGM.Tables[0].Rows.Count == 0)
                return "MISMATCH:IGM_DETAILS.";

            DataTable dtIgm = ds_IGM.Tables[0];

            string mblUpper = (mblNo ?? "").Trim().ToUpper();
            string hblUpper = (hblNo ?? "").Trim().ToUpper();

            DataRow matchedRow = null;

            foreach (DataRow row in dtIgm.Rows)
            {
                string dbMbl = row["IGM_MAWB_MBL"] != DBNull.Value ? row["IGM_MAWB_MBL"].ToString().Trim().ToUpper() : "";

                if (mode == "Sea")
                {
                    string dbHbl = row["IGM_HAWB_HBLNO"] != DBNull.Value ? row["IGM_HAWB_HBLNO"].ToString().Trim().ToUpper() : "";
                    if (dbMbl == mblUpper && dbHbl == hblUpper)
                    {
                        matchedRow = row;
                        break;
                    }
                }
                else if (mode == "Air")
                {
                    if (dbMbl == mblUpper)
                    {
                        matchedRow = row;
                        break;
                    }
                }
            }

            if (matchedRow == null)
            {
                return mode == "Sea"
                    ? "MISMATCH:MBL No / HBL No, IGM_DETAILS"
                    : "MISMATCH:AWB No, IGM_DETAILS ";
            }

            // =========================================================
            // DOCUMENT vs IGM TABLE VALIDATION
            // Package / Gross Weight
            // =========================================================

            string tablePackage =
                matchedRow["IGM_NOOFPACKAGE"] != DBNull.Value
                    ? matchedRow["IGM_NOOFPACKAGE"].ToString().Trim()
                    : "";

            string tableGrossWeight =
                matchedRow["IGM_GROSSWEIGHT"] != DBNull.Value
                    ? matchedRow["IGM_GROSSWEIGHT"].ToString().Trim()
                    : "";

            string jsonPackage = "";
            string jsonGrossWeight = "";

            if (record.ContainsKey("TotalPackage") &&
                record["TotalPackage"] != null)
            {
                jsonPackage =
                    Convert.ToString(record["TotalPackage"]).Trim();
            }

            if (record.ContainsKey("GrossWeight") &&
                record["GrossWeight"] != null)
            {
                jsonGrossWeight =
                    Convert.ToString(record["GrossWeight"]).Trim();
            }

            string mismatchMessage = "";

            // =========================================================
            // PACKAGE DIFFERENCE
            // =========================================================
            if (!string.IsNullOrEmpty(tablePackage) &&
                !string.IsNullOrEmpty(jsonPackage))
            {
                decimal dbPackage;
                decimal jsonPackageValue;

                bool packageDifferent = false;

                if (decimal.TryParse(tablePackage, out dbPackage) &&
                    decimal.TryParse(jsonPackage, out jsonPackageValue))
                {
                    packageDifferent = dbPackage != jsonPackageValue;
                }
                else
                {
                    packageDifferent = !string.Equals(
                        tablePackage,
                        jsonPackage,
                        StringComparison.OrdinalIgnoreCase);
                }

                if (packageDifferent)
                {
                    mismatchMessage +=
                        "Package Difference - " +
                        "IGM  = " + tablePackage +
                        ", Document = " + jsonPackage;
                }
            }


            // =========================================================
            // GROSS WEIGHT DIFFERENCE
            // =========================================================
            if (!string.IsNullOrEmpty(tableGrossWeight) &&
                !string.IsNullOrEmpty(jsonGrossWeight))
            {
                decimal dbWeight;
                decimal jsonWeight;

                bool weightDifferent = false;

                if (decimal.TryParse(tableGrossWeight, out dbWeight) &&
                    decimal.TryParse(jsonGrossWeight, out jsonWeight))
                {
                    weightDifferent = dbWeight != jsonWeight;
                }
                else
                {
                    weightDifferent = !string.Equals(
                        tableGrossWeight,
                        jsonGrossWeight,
                        StringComparison.OrdinalIgnoreCase);
                }

                if (weightDifferent)
                {
                    if (!string.IsNullOrEmpty(mismatchMessage))
                        mismatchMessage += "\n";

                    mismatchMessage +=
                        "Gross Weight Difference - " +
                        "IGM  = " + tableGrossWeight +
                        ", Document = " + jsonGrossWeight;
                }
            }


            // =========================================================
            // SHOW CONFIRMATION ONLY ONCE
            // =========================================================
            if (!allowMismatchUpdate &&
                !string.IsNullOrEmpty(mismatchMessage))
            {
                return "CONFIRM_UPDATE:" + mismatchMessage;
            }

              //

            string existingSlno = matchedRow["IGM_SLNO"].ToString();

            Transact.IGM_SLNO_UPDATE = existingSlno;
            Transact.IGM_JOBNO = jobNo;
            Transact.IGM_JOBDATE = jobDate;
            Transact.IGM_AIRLINECODE = Convert.ToString(matchedRow["IGM_AIRLINECODE"]);
            Transact.IGM_AIRLINENAME = Convert.ToString(matchedRow["IGM_AIRLINENAME"]);
            Transact.IGM_FLIGHTNO_VESSELNO = Convert.ToString(matchedRow["IGM_FLIGHTNO_VESSELNO"]);
            Transact.IGM_FLIGHT_VESSELDATE = Convert.ToString(matchedRow["IGM_FLIGHT_VESSELDATE"]);
            Transact.IGM_NO = Convert.ToString(matchedRow["IGM_NO"]);
            Transact.IGM_DATE = Convert.ToString(matchedRow["IGM_DATE"]);
            Transact.IGM_MAWB_MBL = Convert.ToString(matchedRow["IGM_MAWB_MBL"]);
            Transact.IGM_MAWB_MBLDATE = Convert.ToString(matchedRow["IGM_MAWB_MBLDATE"]);
            Transact.IGM_HAWB_HBLNO = Convert.ToString(matchedRow["IGM_HAWB_HBLNO"]);
            Transact.IGM_HAWB_HBLDATE = Convert.ToString(matchedRow["IGM_HAWB_HBLDATE"]);
            Transact.IGM_NOOFPACKAGE = Convert.ToString(matchedRow["IGM_NOOFPACKAGE"]);
            Transact.IGM_PACKAGETYPE = Convert.ToString(matchedRow["IGM_PACKAGETYPE"]);
            Transact.IGM_GROSSWEIGHT = Convert.ToString(matchedRow["IGM_GROSSWEIGHT"]);
            Transact.IGM_TYPEOFWEIGHT = Convert.ToString(matchedRow["IGM_TYPEOFWEIGHT"]);
            Transact.IGM_NETWEIGHT = Convert.ToString(matchedRow["IGM_NETWEIGHT"]);
            Transact.IGM_NETWEIGHTTYPE = Convert.ToString(matchedRow["IGM_NETWEIGHTTYPE"]);
            Transact.IGM_MARKSNOS = Convert.ToString(matchedRow["IGM_MARKSNOS"]);
            Transact.IGM_TRANSPORTMODE = mode;
            Transact.IGM_GATEWAY_IGM_NO = Convert.ToString(matchedRow["IGM_GATEWAY_IGM_NO"]);
            Transact.IGM_GATEWAY_IGM_DATE = Convert.ToString(matchedRow["IGM_GATEWAY_IGM_DATE"]);
            Transact.IGM_GATEWAY_PORT_CODE = Convert.ToString(matchedRow["IGM_GATEWAY_PORT_CODE"]);
            Transact.IGM_LINE_NUMBER = Convert.ToString(matchedRow["IGM_LINE_NUMBER"]);
            Transact.IGM_SHIPPING_LINE_NUMBER = Convert.ToString(matchedRow["IGM_SHIPPING_LINE_NUMBER"]);
            Transact.IGM_VOYAGE = Convert.ToString(matchedRow["IGM_VOYAGE"]);
            Transact.IGM_CHARGEABLE_WGT = Convert.ToString(matchedRow["IGM_CHARGEABLE_WGT"]);
            Transact.ROTATION_NO = Convert.ToString(matchedRow["ROTATION_NO"]);
            Transact.ROTATION_DATE = Convert.ToString(matchedRow["ROTATION_DATE"]);
            Transact.AMENDMENT_TYPE = Convert.ToString(matchedRow["AMENDMENT_TYPE"]);
            Transact.AMENDMENT_STATUS = "";
            Transact.JOBNO_PS = HttpContext.Current.Session["JOBNO_PS"] != null
                                    ? HttpContext.Current.Session["JOBNO_PS"].ToString() : "";

            Transact.USER_ID = userId;
            Transact.BRANCH_CODE = branchCode;
            Transact.YEAR = "";
            Transact.WORKING_PERIOD = workingPeriod;
            Transact.BRANCH_COMMON = branchCommon;

            if (mode == "Sea")
            {
                if (record.ContainsKey("LineNo"))
                    Transact.IGM_LINE_NUMBER = Convert.ToString(record["LineNo"]);
                if (record.ContainsKey("SubLineNo"))
                    Transact.IGM_SHIPPING_LINE_NUMBER = Convert.ToString(record["SubLineNo"]);
                //if (record.ContainsKey("BlNo"))
                //    Transact.IGM_MAWB_MBL = Convert.ToString(record["BlNo"]);
                //if (record.ContainsKey("BlDate"))
                //    Transact.IGM_MAWB_MBLDATE = Convert.ToString(record["BlDate"]);
                //if (record.ContainsKey("HouseBlNo"))
                //    Transact.IGM_HAWB_HBLNO = Convert.ToString(record["HouseBlNo"]);
                //if (record.ContainsKey("HouseBlDate"))
                //    Transact.IGM_HAWB_HBLDATE = Convert.ToString(record["HouseBlDate"]);
                // MBL No
                if (record.ContainsKey("BlNo"))
                    Transact.IGM_MAWB_MBL = GetValueOrEmpty(record["BlNo"]);

                // MBL Date
                if (record.ContainsKey("BlDate"))
                    Transact.IGM_MAWB_MBLDATE = GetValueOrEmpty(record["BlDate"]);

                // HBL No
                if (record.ContainsKey("HouseBlNo"))
                    Transact.IGM_HAWB_HBLNO = GetValueOrEmpty(record["HouseBlNo"]);

                // HBL Date
                if (record.ContainsKey("HouseBlDate"))
                    Transact.IGM_HAWB_HBLDATE = GetValueOrEmpty(record["HouseBlDate"]);

                if (record.ContainsKey("GrossWeight"))
                    Transact.IGM_GROSSWEIGHT = Convert.ToString(record["GrossWeight"]);
                if (record.ContainsKey("UnitOfWeight"))
                    Transact.IGM_TYPEOFWEIGHT = Convert.ToString(record["UnitOfWeight"]);
                if (record.ContainsKey("TotalPackage"))
                    Transact.IGM_NOOFPACKAGE = Convert.ToString(record["TotalPackage"]);
                if (record.ContainsKey("PackageCode"))
                    Transact.IGM_PACKAGETYPE = Convert.ToString(record["PackageCode"]);

                if (viewInfo != null)
                {
                    if (viewInfo.ContainsKey("IgmNo"))
                        Transact.IGM_NO = Convert.ToString(viewInfo["IgmNo"]);
                    if (viewInfo.ContainsKey("IgmDate"))
                        Transact.IGM_DATE = Convert.ToString(viewInfo["IgmDate"]);
                    if (viewInfo.ContainsKey("InwDate"))
                        Transact.IGM_FLIGHT_VESSELDATE = Convert.ToString(viewInfo["InwDate"]);
                    if (viewInfo.ContainsKey("GatewayPort"))
                        Transact.IGM_GATEWAY_PORT_CODE = Convert.ToString(viewInfo["GatewayPort"]);
                    if (viewInfo.ContainsKey("VoyageNumber"))
                        Transact.IGM_VOYAGE = Convert.ToString(viewInfo["VoyageNumber"]);
                }
            }
            else if (mode == "Air")
            {
                if (record.ContainsKey("LineNo"))
                    Transact.IGM_LINE_NUMBER = Convert.ToString(record["LineNo"]);
                if (record.ContainsKey("GrossWeight"))
                    Transact.IGM_GROSSWEIGHT = Convert.ToString(record["GrossWeight"]);
                //if (record.ContainsKey("UnitOfWeight"))
                //    Transact.IGM_TYPEOFWEIGHT = Convert.ToString(record["UnitOfWeight"]);
                Transact.IGM_TYPEOFWEIGHT = "KGS";
                if (record.ContainsKey("TotalPackage"))
                    Transact.IGM_NOOFPACKAGE = Convert.ToString(record["TotalPackage"]);
                //if (record.ContainsKey("PackageCode"))
                //    Transact.IGM_PACKAGETYPE = Convert.ToString(record["PackageCode"]);
                Transact.IGM_PACKAGETYPE = "PKG";
                if (record.ContainsKey("AwbNo"))
                    Transact.IGM_MAWB_MBL = Convert.ToString(record["AwbNo"]);
                if (inwInfo.ContainsKey("IgmNo"))
                    Transact.IGM_NO = Convert.ToString(inwInfo["IgmNo"]);

                if (viewInfo != null)
                {
                    if (viewInfo.ContainsKey("FlightNo"))
                        Transact.IGM_FLIGHTNO_VESSELNO = Convert.ToString(viewInfo["FlightNo"]);
                    if (viewInfo.ContainsKey("InwardDate"))
                        Transact.IGM_FLIGHT_VESSELDATE = Convert.ToString(viewInfo["InwardDate"]);

                    if (containers != null && containers.Count > 0)
                    {
                        var container = containers[0] as Dictionary<string, object>;

                        if (container != null && container.ContainsKey("IgmDate"))
                        {
                            Transact.IGM_DATE = Convert.ToString(container["IgmDate"]);
                        }
                    }
                    //if (viewInfo.ContainsKey("IgmDate"))
                    //    Transact.IGM_DATE = Convert.ToString(viewInfo["IgmDate"]);
                }
            }
            else
            {
                return "ERROR:only allowed Air or Sea";
            }

            Transact.flag = "U";

            DataSet resultDs = Transact.IGM_Details_insertupdate();
            int resultFlag = Transact.result;

            //if (resultFlag == 1)
            //    return "SUCCESS";
            if (resultFlag == 2)
            {
                return "IGM already Exist";
            }

            if (resultFlag == 1)
            {
                // =====================================================
                // SEA - CONTAINER DETAILS INSERT
                // =====================================================

                if (mode == "Sea" &&
                    inwInfo != null &&
                    containers != null &&
                    containers.Count > 0)
                {
                    // ---------------------------------------------
                    // inwInfo values
                    // ---------------------------------------------
                    string inwSerialNo = "";
                    //string inwIgmNo = "";
                    //string inwIgmDate = "";

                    if (inwInfo.ContainsKey("SerialNo"))
                       inwSerialNo = Convert.ToString(inwInfo["SerialNo"]).Trim();

                    //if (inwInfo.ContainsKey("IgmNo"))
                    //    inwIgmNo = Convert.ToString(inwInfo["IgmNo"]).Trim();

                    //if (inwInfo.ContainsKey("IgmDate"))
                    //    inwIgmDate = Convert.ToString(inwInfo["IgmDate"]).Trim();

                    string inwLineNo = "";
                    string inwIgmNo = "";
                    string inwIgmDate = "";

                    // ---------------------------------------------
                    // Line No from main record
                    // ---------------------------------------------
                    if (record.ContainsKey("LineNo"))
                    {
                        inwLineNo =
                            Convert.ToString(record["LineNo"]).Trim();
                    }

                    // ---------------------------------------------
                    // IGM No from inwInfo
                    // ---------------------------------------------
                    if (inwInfo != null && inwInfo.ContainsKey("IgmNo"))
                    {
                        inwIgmNo =
                            Convert.ToString(inwInfo["IgmNo"]).Trim();
                    }

                    // ---------------------------------------------
                    // IGM Date from inwInfo
                    // ---------------------------------------------
                    if (inwInfo != null && inwInfo.ContainsKey("IgmDate"))
                    {
                        inwIgmDate =
                            Convert.ToString(inwInfo["IgmDate"]).Trim();
                    }


                    // ---------------------------------------------
                    // IGM Date default
                    // ---------------------------------------------
                    if (string.IsNullOrWhiteSpace(inwIgmDate))
                    {
                        inwIgmDate = "01/01/1900";
                    }


                    // ---------------------------------------------
                    // Containers loop
                    // ---------------------------------------------
                    foreach (object containerObj in containers)
                    {
                        Dictionary<string, object> container =
                              containerObj as Dictionary<string, object>;

                        if (container == null)
                            continue;


                        string containerSerialNo = "";
                        //string containerIgmNo = "";
                        //string containerNo = "";
                        //string containerStatus = "";

                        string containerLineNo = "";
                        string containerIgmNo = "";
                        string containerNo = "";
                        string containerStatus = "";


                        if (container.ContainsKey("SerialNo"))
                            containerSerialNo =
                                Convert.ToString(container["SerialNo"]).Trim();

                        if (container.ContainsKey("LineNo"))
                        {
                            containerLineNo =
                                Convert.ToString(container["LineNo"]).Trim();
                        }

                        if (container.ContainsKey("IgmNo"))
                            containerIgmNo =
                                Convert.ToString(container["IgmNo"]).Trim();

                        if (container.ContainsKey("ContainerDetails"))
                            containerNo =
                                Convert.ToString(container["ContainerDetails"]).Trim();

                        if (container.ContainsKey("ContainerStatus"))
                            containerStatus =
                                Convert.ToString(container["ContainerStatus"]).Trim();

                        // ---------------------------------------------
                        // Line No + IGM No BOTH must match
                        // ---------------------------------------------
                        if (containerLineNo != inwLineNo ||
                            containerIgmNo != inwIgmNo)
                        {
                            continue;
                        }


                        // ---------------------------------------------
                        // Container No mandatory
                        // ---------------------------------------------
                        if (string.IsNullOrWhiteSpace(containerNo))
                        {
                            continue;
                        }


                        // ---------------------------------------------
                        // Create Transaction
                        // ---------------------------------------------
                        Transaction containerTransact = new Transaction();

                        containerTransact.CONTAINERID = "";

                        containerTransact.CONTAINER_IGM_SLNO = inwSerialNo;
                        containerTransact.CONTAINER_IGM_NO = inwIgmNo;

                         inwIgmDate = Convert.ToString(inwInfo["IgmDate"]).Trim();

                        // 2. Convert
                         string formattedIgmDate = "";

                         DateTime parsedIgmDate;

                         if (DateTime.TryParseExact(
                                 (inwIgmDate ?? "").Trim(),
                                 "dd-MMM-yyyy HH:mm:ss",
                                 System.Globalization.CultureInfo.InvariantCulture,
                                 System.Globalization.DateTimeStyles.None,
                                 out parsedIgmDate))
                         {
                             DateTime dateOnly = parsedIgmDate.Date;

                             formattedIgmDate = dateOnly.ToString("yyyy-MM-dd HH:mm:ss.fff");
                         }
                         else
                         {
                             formattedIgmDate = "1900-01-01 00:00:00.000";
                         }

                        containerTransact.CONTAINER_IGM_DATE = formattedIgmDate;
                        containerTransact.JOBNO = jobNo;

                        containerTransact.CONTAINER_NO = containerNo;

                        containerTransact.SEAL_NO = "NA";

                        containerTransact.FCL_OR_LCL = containerStatus.ToUpper() == "FCL" ? "F" : containerStatus.ToUpper() == "LCL" ? "L" : "";

                        containerTransact.USER_ID = userId;

                        containerTransact.flag = "S";

                        containerTransact.BRANCH_CODE = branchCode;

                        containerTransact.YEAR = "";

                        containerTransact.WORKING_PERIOD = workingPeriod;

                        containerTransact.BRANCH_COMMON = branchCommon;

                        containerTransact.TYPE = "";

                        containerTransact.TRUCK_NO = "";

                        containerTransact.AMENDMENT_TYPE =
                            Convert.ToString(matchedRow["AMENDMENT_TYPE"]);

                        containerTransact.AMENDMENT_STATUS = "";

                        containerTransact.JOBNO_PS =
                            HttpContext.Current.Session["JOBNO_PS"] != null
                                ? HttpContext.Current.Session["JOBNO_PS"].ToString()
                                : "";


                        // ---------------------------------------------
                        // Insert Container
                        // ---------------------------------------------
                        DataSet dss =
                            containerTransact.CONTAINER_Details_insertupdate();

                        int containerResult =
                            containerTransact.result;


                        if (containerResult == 2)
                        {
                            return containerNo + "Container No Already Exist";
                                  
                        }
                    }
                }


                return "SUCCESS";
            }
            else
                return "ERROR: Not inserted";
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
            return "ERROR:" + ex.Message;
        }
    }

    private static string GetValueOrEmpty(object value)
    {
        if (value == null)
            return "";

        string val = Convert.ToString(value).Trim();

        if (string.IsNullOrEmpty(val))
            return "";

        string upperVal = val.ToUpper();

        if (upperVal == "N.A." ||
            upperVal == "N.A" ||
            upperVal == "NA" ||
            upperVal == "N/A")
        {
            return "";
        }

        return val;
    }


    private void Elogix_Service()
    {
        Connection.e_lOGIX("I", "U");
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


    private void Load_Mandatory_Flags()
    {
        DataRow mand = Get_Mandatory_Settings();

        string f_IGMNo = (mand != null) ? mand["IGM_NO"].ToString() : "Y";
        string f_IGMDate = (mand != null) ? mand["IGM_DATE"].ToString() : "Y";
        string f_FlightVesselDate = (mand != null) ? mand["FLIGHT_VESSEL_DATE"].ToString() : "Y"; // ✅ New
        string f_MAWBMBLNo = (mand != null) ? mand["MAWB_BL_NO"].ToString() : "Y";
        string f_MAWBMBLDate = (mand != null) ? mand["MAWB_MBL_DATE"].ToString() : "Y";
        string f_Packages = (mand != null) ? mand["PACKAGES"].ToString() : "Y";
        string f_PackageType = (mand != null) ? mand["IGM_PACKAGE_TYPE"].ToString() : "Y";
        string f_GrossWeight = (mand != null) ? mand["IGM_GROSS_WEIGHT"].ToString() : "Y";
        string f_GrossWeightType = (mand != null) ? mand["IGM_GROSS_WEIGHT_TYPE"].ToString() : "Y";
        string f_MarksNos = (mand != null) ? mand["MARKS_NOS"].ToString() : "Y";

        string script = string.Format(@"
        var mand_IGMNo            = '{0}';
        var mand_IGMDate          = '{1}';
        var mand_FlightVesselDate = '{2}';
        var mand_MAWBMBLNo        = '{3}';
        var mand_MAWBMBLDate      = '{4}';
        var mand_Packages         = '{5}';
        var mand_PackageType      = '{6}';
        var mand_GrossWeight      = '{7}';
        var mand_GrossWeightType  = '{8}';
        var mand_MarksNos         = '{9}';
    ",
            f_IGMNo,
            f_IGMDate,
            f_FlightVesselDate,
            f_MAWBMBLNo,
            f_MAWBMBLDate,
            f_Packages,
            f_PackageType,
            f_GrossWeight,
            f_GrossWeightType,
            f_MarksNos);

        ScriptManager.RegisterStartupScript(
            this, this.GetType(), "IGMMandatoryFlags", script, true);
    }


    private DataRow Get_Mandatory_Settings()
    {
        try
        {
            if (Session["COMPANY_ID"] == null)
                return null;

            // ── COMPANY_ID — must be numeric ──────────────────────
            string companyIdStr = COMPANY_ID;
            long companyId = 0;
            if (!long.TryParse(companyIdStr, out companyId) || companyId == 0)
            {
                Connection.Error_Msg("COMPANY_ID is invalid: " + companyIdStr);
                return null;
            }

            // ── USER_CREATION_ID — must be numeric ────────────────
            // ✅ Use SESSION directly — not currentuser (which is username string)
            string userCreationIdStr = "";
            if (Session["USER_CREATION_ID"] != null)
                userCreationIdStr = Session["USER_CREATION_ID"].ToString();
            else if (Session["USER_CREATION_ID_EDIT"] != null)
                userCreationIdStr = Session["USER_CREATION_ID_EDIT"].ToString();

            long userCreationId = 0;
            if (!long.TryParse(userCreationIdStr, out userCreationId) || userCreationId == 0)
            {
                Connection.Error_Msg("USER_CREATION_ID is invalid: " + userCreationIdStr);
                return null;
            }

            // ── Safe to call SP ───────────────────────────────────
            User_Creation user_Create = new User_Creation();
            user_Create.COMPANY_ID = companyIdStr;
            user_Create.USER_CREATION_ID = userCreationIdStr;  // ✅ numeric ID
            user_Create.ACTION_BRANCH = SELECT_BRANCH;
            user_Create.flag = "Select_Imp_IGm_Setngs";

            DataSet ds = user_Create.Imp_Col_Edit_Insert_update(
                             HttpContext.Current.Session["currentcomp_db"].ToString());

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0];

            return null;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
            return null;
        }
    }


    private bool Check_Mandatory_Fields_IGM()
    {
        DataRow mand = Get_Mandatory_Settings();

        // ✅ No settings saved → all fields default mandatory
        if (mand == null)
            return true;

        bool isValid = true;
        string errMsg = "";

        // ── IGM No ────────────────────────────────────────────────────
        if (isValid && mand["IGM_NO"].ToString() == "Y"
            && string.IsNullOrWhiteSpace(txtIGMNo.Text))
        {
            errMsg = "IGM No is mandatory.";
            isValid = false;
        }

        // ── IGM Date ──────────────────────────────────────────────────
        if (isValid && mand["IGM_DATE"].ToString() == "Y"
            && string.IsNullOrWhiteSpace(txtIGMDate.Text))
        {
            errMsg = "IGM Date is mandatory.";
            isValid = false;
        }

        // ── Flight/Vessel Date — OWN flag ✅ Fixed ────────────────────
        if (isValid && mand["FLIGHT_VESSEL_DATE"].ToString() == "Y"
            && string.IsNullOrWhiteSpace(txtFlightVesselDate.Text))
        {
            errMsg = "Flight/Vessel Date is mandatory.";
            isValid = false;
        }

        // ── MAWB/MBL No ───────────────────────────────────────────────
        if (isValid && mand["MAWB_BL_NO"].ToString() == "Y"
            && string.IsNullOrWhiteSpace(txtMAWBMBLNo.Text))
        {
            errMsg = "MAWB/MBL No is mandatory.";
            isValid = false;
        }

        // ── MAWB/MBL Date ─────────────────────────────────────────────
        if (isValid && mand["MAWB_MBL_DATE"].ToString() == "Y"
            && string.IsNullOrWhiteSpace(txtMAWBMBLDate.Text))
        {
            errMsg = "MAWB/MBL Date is mandatory.";
            isValid = false;
        }
        // ── Packages ──────────────────────────────────────────────────
        if (isValid && mand["PACKAGES"].ToString() == "Y"
            && string.IsNullOrWhiteSpace(txtPackages.Text))
        {
            errMsg = "Packages is mandatory.";
            isValid = false;
        }

        // ── Package Type ──────────────────────────────────────────────
        if (isValid && mand["IGM_PACKAGE_TYPE"].ToString() == "Y"
            && string.IsNullOrWhiteSpace(txtPackageType.Text))
        {
            errMsg = "Package Type is mandatory.";
            isValid = false;
        }

        // ── Gross Weight ──────────────────────────────────────────────
        if (isValid && mand["IGM_GROSS_WEIGHT"].ToString() == "Y"
            && string.IsNullOrWhiteSpace(txtGrossWeight.Text))
        {
            errMsg = "Gross Weight is mandatory.";
            isValid = false;
        }

        // ── Gross Weight Type ─────────────────────────────────────────
        if (isValid && mand["IGM_GROSS_WEIGHT_TYPE"].ToString() == "Y"
            && string.IsNullOrWhiteSpace(txtGrossWeightType.Text))
        {
            errMsg = "Gross Weight Type is mandatory.";
            isValid = false;
        }

        // ── Marks and Nos ─────────────────────────────────────────────
        if (isValid && mand["MARKS_NOS"].ToString() == "Y"
            && string.IsNullOrWhiteSpace(txtMarksNos.Text))
        {
            errMsg = "Marks and Nos is mandatory.";
            isValid = false;
        }

        // ── Show error ────────────────────────────────────────────────
        if (!isValid)
        {
            Alert_msg(errMsg);
        }

        return isValid;
    }

    private void Tbl_Filed_Modified_History(DataTable dt_Curr_tbl_struct)
    {
        try
        {
            ViewState["dt_Prev_Table"] = dt_Curr_tbl_struct;
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
            Dt_Change.GetMismatchedRowsFast(dt_Prev, dt_modified, "IGM_SLNO", "IGM", IMPORT_JOBNO, ViewState["IGMSLNO"].ToString(), "", currentuser, Connection.Current_Branch());
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

            dr["IGM_SLNO"] = ViewState["IGMSLNO"].ToString();  // Auto/system generated - no direct control
            dr["IGM_AIRLINECODE"] = txtAirlineCode.Text;
            dr["IGM_AIRLINENAME"] = txtAirlineName.Text;
            dr["IGM_FLIGHTNO_VESSELNO"] = txtFlightVesselNo.Text;
            dr["IGM_FLIGHT_VESSELDATE"] = txtFlightVesselDate.Text;
            dr["IGM_NO"] = txtIGMNo.Text;
            dr["IGM_DATE"] = txtIGMDate.Text;
            dr["IGM_MAWB_MBL"] = txtMAWBMBLNo.Text;
            dr["IGM_MAWB_MBLDATE"] = txtMAWBMBLDate.Text;
            dr["IGM_HAWB_HBLNO"] = txtHAWBHBLNo.Text;
            dr["IGM_HAWB_HBLDATE"] = txtHAWBHBLDate.Text;
            dr["IGM_NOOFPACKAGE"] = txtPackages.Text;
            dr["IGM_PACKAGETYPE"] = txtPackageType.Text;
            dr["IGM_GROSSWEIGHT"] = txtGrossWeight.Text;
            dr["IGM_TYPEOFWEIGHT"] = txtGrossWeightType.Text;
            dr["IGM_NETWEIGHT"] = txtNetWeight.Text;
            dr["IGM_NETWEIGHTTYPE"] = txtNetWeightType.Text;
            dr["IGM_TRANSPORTMODE"] = "";
            dr["IGM_MARKSNOS"] = txtMarksNos.Text;
            dr["IGM_GATEWAY_IGM_NO"] = txtGateway_Igm_No.Text;
            dr["IGM_GATEWAY_IGM_DATE"] = txtGateway_Igm_Date.Text;
            dr["IGM_GATEWAY_PORT_CODE"] = txtGateway_Port_Code.Text;
            dr["IGM_LINE_NUMBER"] = txt_LineNumber.Text;
            dr["IGM_SHIPPING_LINE_NUMBER"] = txt_ShippingLine.Text;
            dr["IGM_VOYAGE"] = txt_Voyage.Text;
            dr["IGM_CHARGEABLE_WGT"] = txtChargable_Wgt.Text;
            dr["ROTATION_NO"] = txt_RotationNo.Text;
            dr["ROTATION_DATE"] = txt_Rotation_Date.Text;
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

    protected void ETA_Update_Click(object sender, EventArgs e)
    {
        try
        {
            // ---------------------------------------------
            // Vessel Name
            // ---------------------------------------------
            string vesselName = txtFlightVesselNo.Text.Trim();

            if (string.IsNullOrWhiteSpace(vesselName))
            {
                Alert_msg("Please enter the vessel name.");
                return;
            }


            // ---------------------------------------------
            // First Port = Custom House
            // ---------------------------------------------
            string customHouse =
                hd_CUSTOMHOUSE_CODE.Value.Trim().ToUpperInvariant();

            if (string.IsNullOrWhiteSpace(customHouse))
            {
                Alert_msg("Custom House code is missing.");
                return;
            }


            // ---------------------------------------------
            // Second Port = Gateway Port
            // ---------------------------------------------
            string gatewayportcode =
                txtGateway_Port_Code.Text.Trim().ToUpperInvariant();

            if (gatewayportcode.Contains("-"))
            {
                gatewayportcode =
                    gatewayportcode.Substring(
                        gatewayportcode.LastIndexOf("-") + 1
                    ).Trim();
            }


            // ---------------------------------------------
            // Validate Custom House
            // ---------------------------------------------
            if (customHouse != "INMAA1" &&
                customHouse != "INENR1" &&
                customHouse != "INKAT1")
            {
                Alert_msg(
                    "Berthing schedule is available only for Chennai (INMAA1), Ennore (INENR1), and Kattupalli (INKAT1).");

                return;
            }


            // =====================================================
            // STEP 1
            // First check vessel in Custom House port
            // =====================================================
            string port = customHouse;

            DataTable dt =
                Execute_Berthing_Schedule_SP(
                    port,
                    vesselName);


            // =====================================================
            // STEP 2
            // If vessel NOT found in Custom House,
            // check Gateway Port
            // =====================================================
            if (dt == null || dt.Rows.Count == 0)
            {
                if (!string.IsNullOrWhiteSpace(gatewayportcode))
                {
                    // Check only supported ports
                    if (gatewayportcode == "INMAA1" ||
                        gatewayportcode == "INENR1" ||
                        gatewayportcode == "INKAT1")
                    {
                        port = gatewayportcode;

                        dt =
                            Execute_Berthing_Schedule_SP(
                                port,
                                vesselName);
                    }
                }
            }


            // =====================================================
            // STEP 3
            // No schedule found in both ports
            // =====================================================
            if (dt == null || dt.Rows.Count == 0)
            {
                Alert_msg_berthing(
                    "No berthing schedule found for vessel '" +
                    vesselName +
                    "' in Custom House (" +
                    customHouse +
                    ") or Gateway Port (" +
                    gatewayportcode +
                    ").");

                return;
            }


            // =====================================================
            // STEP 4
            // Show schedule based on the port where vessel found
            // =====================================================
            if (port == "INMAA1")
            {
                gvChennaiSchedule.DataSource = dt;
                gvChennaiSchedule.DataBind();

                lbl_ChennaiScheduleHeading.Text =
                    "Chennai Vessel Schedule - " + vesselName;

                MP_ChennaiSchedule.Show();
            }
            else if (port == "INENR1")
            {
                gvEnnoreSchedule.DataSource = dt;
                gvEnnoreSchedule.DataBind();

                lbl_EnnoreScheduleHeading.Text =
                    "Ennore Vessel Schedule - " + vesselName;

                MP_EnnoreSchedule.Show();
            }
            else if (port == "INKAT1")
            {
                gvKattupalliSchedule.DataSource = dt;
                gvKattupalliSchedule.DataBind();

                lbl_KattupalliScheduleHeading.Text =
                    "Kattupalli Vessel Schedule - " + vesselName;

                MP_KattupalliSchedule.Show();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

            Alert_msg(
                "Error loading vessel schedule: " +
                ex.Message);
        }
    }

    private string GetBerthingPortFromCustomHouse(
       string customHouse)
    {
        customHouse =
            (customHouse ?? "")
            .Trim()
            .ToUpperInvariant();

        if (customHouse == "INMAA1" ||
            customHouse.StartsWith("INMAA"))
        {
            return "INMAA1";
        }

        if (customHouse == "INENR1" ||
            customHouse.StartsWith("INENR"))
        {
            return "INENR1";
        }

        if (customHouse == "INKAT1" ||
            customHouse.StartsWith("INKAT"))
        {
            return "INKAT1";
        }

        return "";
    }

    private DataTable Execute_Berthing_Schedule_SP(
      string portCode,
      string vesselName)
    {
        DataTable dt = new DataTable();

        try
        {
            SqlParameter[] param =
            {
                new SqlParameter(
                    "@PortCode",
                    SqlDbType.VarChar,
                    20)
                {
                    Value = portCode
                },

                new SqlParameter(
                    "@VesselName",
                    SqlDbType.VarChar,
                    200)
                {
                    Value =
                        string.IsNullOrWhiteSpace(vesselName)
                            ? (object)DBNull.Value
                            : vesselName.Trim()
                }
            };

            DataSet ds =
                SqlHelper.ExecuteDataset(
                    ConfigurationManager.AppSettings["con"],
                    CommandType.StoredProcedure,
                    "BERTHING_SCHEDULE_SP",
                    param);

            if (ds != null &&
                ds.Tables.Count > 0)
            {
                dt = ds.Tables[0].Copy();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

            Alert_msg(
                "Error loading vessel schedule: " +
                ex.Message);
        }

        return dt;
    }

    protected void btn_ChennaiScheduleUpdate_Click(
       object sender,
       EventArgs e)
    {
        try
        {
            GridViewRow selectedRow = null;

            foreach (GridViewRow row in gvChennaiSchedule.Rows)
            {
                if (row.RowType != DataControlRowType.DataRow)
                    continue;

                CheckBox chk =
                    row.FindControl("chkSelectChennai")
                    as CheckBox;

                if (chk != null && chk.Checked)
                {
                    selectedRow = row;
                    break;
                }
            }

            if (selectedRow == null)
            {
                Alert_msg("Please select one vessel schedule.");
                MP_ChennaiSchedule.Show();
                return;
            }

            string vessel =
                GetCellText(selectedRow, 2);

            string eta =
                GetCellText(selectedRow, 3);

            string revisedEta =
                GetCellText(selectedRow, 4);

            if (!string.IsNullOrWhiteSpace(revisedEta) &&
    revisedEta.IndexOf("HRS", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                revisedEta = "";
            }

            string chosenEta =
                !string.IsNullOrWhiteSpace(revisedEta)
                    ? revisedEta
                    : eta;

            if (string.IsNullOrWhiteSpace(chosenEta))
            {
                Alert_msg(
                    "Selected vessel schedule does not have ETA.");
                MP_ChennaiSchedule.Show();
                return;
            }
            string dateOnly =
                ExtractScheduleDate(chosenEta);

            string jobNo = IMPORT_JOBNO;
            string customsHouse = hd_CUSTOMHOUSE_CODE.Value.Trim().ToUpperInvariant();
            string branchCode = Connection.Current_Branch();

            using (SqlConnection conn = new SqlConnection(HttpContext.Current.Session["currentcomp_db"].ToString()))
            {
                string sql = @"
        UPDATE GENERAL_DETAILS
        SET ETA = @ETA
        WHERE JOBNO = @JOBNO
          AND CUSTOMS_HOUSE = @CUSTOMS_HOUSE
          AND BRANCHCODE = @BRANCHCODE";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@ETA", SqlDbType.VarChar, 15).Value = dateOnly;
                    cmd.Parameters.Add("@JOBNO", SqlDbType.NVarChar, 50).Value = jobNo;
                    cmd.Parameters.Add("@CUSTOMS_HOUSE", SqlDbType.NVarChar, 50).Value = customsHouse;
                    cmd.Parameters.Add("@BRANCHCODE", SqlDbType.NVarChar, 50).Value = branchCode;

                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MP_KattupalliSchedule.Hide();
                        Alert_msg("ETA updated successfully.");
                    }
                    else
                    {
                        Alert_msg("No matching GENERAL_DETAILS record found.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Alert_msg(
                "Error updating ETA: " +
                ex.Message);
        }
    }

    protected void btn_ChennaiScheduleClose_Click(
       object sender,
       EventArgs e)
    {
        MP_ChennaiSchedule.Hide();
    }

    protected void btn_EnnoreScheduleUpdate_Click(
      object sender,
      EventArgs e)
    {
        try
        {
            GridViewRow selectedRow = null;

            foreach (GridViewRow row in gvEnnoreSchedule.Rows)
            {
                if (row.RowType != DataControlRowType.DataRow)
                    continue;

                CheckBox chk =
                    row.FindControl("chkSelectEnnore")
                    as CheckBox;

                if (chk != null && chk.Checked)
                {
                    selectedRow = row;
                    break;
                }
            }

            if (selectedRow == null)
            {
                Alert_msg("Please select one vessel schedule.");
                MP_EnnoreSchedule.Show();
                return;
            }

            string etaDate =
                GetCellText(selectedRow, 3);

            if (string.IsNullOrWhiteSpace(etaDate))
            {
                Alert_msg(
                    "Selected vessel schedule does not have ETA.");
                MP_EnnoreSchedule.Show();
                return;
            }

            string dateOnly = ExtractScheduleDate(etaDate);

            //  if (!string.IsNullOrWhiteSpace(dateOnly)) txtFlightVesselDate.Text = dateOnly;
            string jobNo = IMPORT_JOBNO;
            string customsHouse = hd_CUSTOMHOUSE_CODE.Value.Trim().ToUpperInvariant();
            string branchCode = Connection.Current_Branch();

            using (SqlConnection conn = new SqlConnection(HttpContext.Current.Session["currentcomp_db"].ToString()))
            {
                string sql = @"
        UPDATE GENERAL_DETAILS
        SET ETA = @ETA
        WHERE JOBNO = @JOBNO
          AND CUSTOMS_HOUSE = @CUSTOMS_HOUSE
          AND BRANCHCODE = @BRANCHCODE";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@ETA", SqlDbType.VarChar, 15).Value = dateOnly;
                    cmd.Parameters.Add("@JOBNO", SqlDbType.NVarChar, 50).Value = jobNo;
                    cmd.Parameters.Add("@CUSTOMS_HOUSE", SqlDbType.NVarChar, 50).Value = customsHouse;
                    cmd.Parameters.Add("@BRANCHCODE", SqlDbType.NVarChar, 50).Value = branchCode;

                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MP_KattupalliSchedule.Hide();
                        Alert_msg("ETA updated successfully.");
                    }
                    else
                    {
                        Alert_msg("No matching GENERAL_DETAILS record found.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Alert_msg(
                "Error updating ETA: " +
                ex.Message);
        }
    }

    protected void btn_EnnoreScheduleClose_Click(
       object sender,
       EventArgs e)
    {
        MP_EnnoreSchedule.Hide();
    }

    protected void btn_KattupalliScheduleUpdate_Click(
      object sender,
      EventArgs e)
    {
        try
        {
            GridViewRow selectedRow = null;

            foreach (GridViewRow row in gvKattupalliSchedule.Rows)
            {
                if (row.RowType != DataControlRowType.DataRow)
                    continue;

                CheckBox chk =
                    row.FindControl("chkSelectKattupalli")
                    as CheckBox;

                if (chk != null && chk.Checked)
                {
                    selectedRow = row;
                    break;
                }
            }

            if (selectedRow == null)
            {
                Alert_msg("Please select one vessel schedule.");
                MP_KattupalliSchedule.Show();
                return;
            }

            string ataEta =
                GetCellText(selectedRow, 3);

            string eta =
                GetCellText(selectedRow, 4);

            string chosenDate =
                !string.IsNullOrWhiteSpace(ataEta)
                    ? ataEta
                    : eta;

            if (string.IsNullOrWhiteSpace(chosenDate))
            {
                Alert_msg(
                    "Selected vessel schedule does not have ETA.");
                MP_KattupalliSchedule.Show();
                return;
            }

            string dateOnly =
                ExtractScheduleDate(chosenDate);

            string jobNo = IMPORT_JOBNO;
            string customsHouse = hd_CUSTOMHOUSE_CODE.Value.Trim().ToUpperInvariant();
            string branchCode = Connection.Current_Branch();

            using (SqlConnection conn = new SqlConnection(HttpContext.Current.Session["currentcomp_db"].ToString()))
            {
                string sql = @"
        UPDATE GENERAL_DETAILS
        SET ETA = @ETA
        WHERE JOBNO = @JOBNO
          AND CUSTOMS_HOUSE = @CUSTOMS_HOUSE
          AND BRANCHCODE = @BRANCHCODE";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@ETA", SqlDbType.VarChar, 15).Value = dateOnly;
                    cmd.Parameters.Add("@JOBNO", SqlDbType.NVarChar, 50).Value = jobNo;
                    cmd.Parameters.Add("@CUSTOMS_HOUSE", SqlDbType.NVarChar, 50).Value = customsHouse;
                    cmd.Parameters.Add("@BRANCHCODE", SqlDbType.NVarChar, 50).Value = branchCode;

                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MP_KattupalliSchedule.Hide();
                        Alert_msg("ETA updated successfully.");
                    }
                    else
                    {
                        Alert_msg("No matching GENERAL_DETAILS record found.");
                    }
                }
            }
          
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Alert_msg(
                "Error updating ETA: " +
                ex.Message);
        }
    }

    protected void btn_KattupalliScheduleClose_Click(
       object sender,
       EventArgs e)
    {
        MP_KattupalliSchedule.Hide();
    }

    private string GetCellText(
      GridViewRow row,
      int cellIndex)
    {
        if (row == null ||
            cellIndex < 0 ||
            cellIndex >= row.Cells.Count)
        {
            return "";
        }

        return
            row.Cells[cellIndex].Text
                .Replace("&nbsp;", "")
                .Trim();
    }

    private string ExtractScheduleDate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return "";

        string text =
            HttpUtility.HtmlDecode(value)
                .Replace("\r", " ")
                .Replace("\n", " ")
                .Replace("\u00A0", " ")
                .Trim();

        // Remove multiple spaces
        text = Regex.Replace(text, @"\s+", " ").Trim();

        DateTime parsedDate;

        // =========================================================
        // 1. DIRECT DATE FORMATS
        // =========================================================
        string[] formats =
        {
            // 4 digit year
            "dd/MM/yyyy",
            "d/M/yyyy",

            "dd-MM-yyyy",
            "d-M-yyyy",

            "dd.MM.yyyy",
            "d.M.yyyy",

            "dd MMM yyyy",
            "d MMM yyyy",

            "dd MMMM yyyy",
            "d MMMM yyyy",

            "ddd dd MMM yyyy",
            "ddd d MMM yyyy",

            "ddd dd MMMM yyyy",
            "ddd d MMMM yyyy",

            "ddd dd MMM - yyyy",
            "ddd d MMM - yyyy",

            // ⭐ Month name with hyphen
            "dd-MMM-yyyy",
            "d-MMM-yyyy",

            // 2 digit year
            "dd/MM/yy",
            "d/M/yy",

            "dd-MM-yy",
            "d-M-yy",

            "dd.MM.yy",
            "d.M.yy",

            "dd MMM yy",
            "d MMM yy",

            "dd MMMM yy",
            "d MMMM yy",

            "ddd dd MMM yy",
            "ddd d MMM yy",

            // ⭐ Month name + hyphen + 2 digit year
            "dd-MMM-yy",
            "d-MMM-yy"
        };

        // =========================================================
        // 2. DIRECT PARSE
        // =========================================================

        if (DateTime.TryParseExact(
            text,
            formats,
            System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.AllowWhiteSpaces,
            out parsedDate))
        {
            return parsedDate.ToString("dd/MM/yyyy");
        }

        text = Regex.Replace(
            text,
            @"(?<=\d)\s+(?=\d\s*:)",
            "");

        // Also handle:
        // 1 4 : 00 -> 14:00
        text = Regex.Replace(
            text,
            @"(?<=\d)\s+(?=\d\s*:)",
            "");

        text = Regex.Replace(
            text,
            @"(\d)\s+(\d)\s*:",
            "$1$2:");

        Match monthMatch =
            Regex.Match(
                text,
                @"\b(\d{1,2})\s+([A-Za-z]{3,9})\s*[-/.]?\s*(\d{2,4})\b",
                RegexOptions.IgnoreCase);

        if (monthMatch.Success)
        {
            string day =
                monthMatch.Groups[1].Value;

            string month =
                monthMatch.Groups[2].Value;

            string year =
                monthMatch.Groups[3].Value;

            string candidate =
                day + " " +
                month + " " +
                year;

            // =====================================================
            // 4 DIGIT YEAR
            // =====================================================

            if (year.Length == 4)
            {
                string[] monthFormats =
            {
                "d MMM yyyy",
                "dd MMM yyyy",
                "d MMMM yyyy",
                "dd MMMM yyyy"
            };

                if (DateTime.TryParseExact(
                    candidate,
                    monthFormats,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.AllowWhiteSpaces,
                    out parsedDate))
                {
                    return parsedDate.ToString("dd/MM/yyyy");
                }
            }

            // =====================================================
            // 2 DIGIT YEAR
            // =====================================================

            if (year.Length == 2)
            {
                string[] monthFormats =
            {
                "d MMM yy",
                "dd MMM yy",
                "d MMMM yy",
                "dd MMMM yy"
            };

                if (DateTime.TryParseExact(
                    candidate,
                    monthFormats,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.AllowWhiteSpaces,
                    out parsedDate))
                {
                    return parsedDate.ToString("dd/MM/yyyy");
                }
            }
        }

        Match numericMatch =
            Regex.Match(
                text,
                @"\b(\d{1,2})[\/\-.](\d{1,2})[\/\-.](\d{2,4})\b");

        if (numericMatch.Success)
        {
            string day =
                numericMatch.Groups[1].Value;

            string month =
                numericMatch.Groups[2].Value;

            string year =
                numericMatch.Groups[3].Value;

            string candidate =
                day + "/" +
                month + "/" +
                year;

            // 4 digit year
            if (year.Length == 4)
            {
                if (DateTime.TryParseExact(
                    candidate,
                    new[]
                {
                    "d/M/yyyy",
                    "dd/MM/yyyy"
                },
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out parsedDate))
                {
                    return parsedDate.ToString("dd/MM/yyyy");
                }
            }

            // 2 digit year
            if (year.Length == 2)
            {
                if (DateTime.TryParseExact(
                    candidate,
                    new[]
                {
                    "d/M/yy",
                    "dd/MM/yy"
                },
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out parsedDate))
                {
                    return parsedDate.ToString("dd/MM/yyyy");
                }
            }
        }

        // =========================================================
        // 6. FALLBACK
        // =========================================================

        return "";
    }

    public void Alert_msg_berthing(string msg)
    {
        string safeMsg =
            HttpUtility.JavaScriptStringEncode(msg ?? "");

        string prompt =
            "<script type='text/javascript'>" +
            "$(document).ready(function() {" +
            "jAlert('" + safeMsg + "', 'IGM', function(r) {});" +
            "});" +
            "</script>";

        ScriptManager.RegisterStartupScript(
            this,
            this.GetType(),
            "IGMAlert_" + Guid.NewGuid().ToString("N"),
            prompt,
            false);
    }

}