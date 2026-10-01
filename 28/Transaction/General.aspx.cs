using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using BussinessObject;
using System.Linq;

public partial class Transaction_General_New : ThemeClass
{
    Transaction Transact = new Transaction();
    Date_Time dt = new Date_Time();
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();
    DataSet dtuser = new DataSet();
    DataSet ds = new DataSet();
    ErrorLogs er = new ErrorLogs();
    PDFReaderLog pdflog = new PDFReaderLog();

    public int i, Screen_Id;
    public string currentuser, currentbranch, Working_Period, SELECT_BRANCH, COMPANY_ID, SELECT_TYPE;
    public string SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, Screen_IdNew;
    public string JOB_LOCK, JOB_RELEASE, JOB_USER, Audit_YN = "", ddl_MultipleIcegate_YN = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.Load += Page_Load;
            aps.checkSession();

            currentuser = Connection.Current_User();
            currentbranch = Connection.Current_Branch();
            Working_Period = Connection.WorkingPeriod();
            SELECT_BRANCH = Connection.Get_Company_Type();
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();
            COMPANY_ID = Session["COMPANY_ID"].ToString();
            hdn_CompanyID.Value = COMPANY_ID;
            hdn_currentPage.Value = "General";
            Session["BE_TYPE"] = ddlBEType.SelectedValue.ToString();
            Screen_Id = 7;
            Page_Rights(Screen_Id);

            txtJobDate.Focus();
            Session.Remove("EXBND_JOBID");

            //if (!string.IsNullOrEmpty(Session["JOBID"].ToString()))
            if (!string.IsNullOrEmpty(Session["JOBIDexcel"] as string))
            {
                string aa = Session["JOBIDexcel"].ToString();

                System.Reflection.PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection)
                                                 .GetProperty("IsReadOnly", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                isreadonly.SetValue(HttpContext.Current.Request.QueryString, false, null);
                //HttpContext.Current.Request.QueryString.Clear();
                Request.QueryString.Remove("JOBID");
                Request.QueryString["JOBID"] = Session["JOBIDexcel"].ToString();
                Session.Remove("JOBIDexcel");

                Request.QueryString.Remove("Page"); // Added by Mrs.Chithra on 16-07-2026
                Request.QueryString["Page"] = "Update";
                //btnJobDetails.Enabled = false; 
                btnJobDetails.Visible = false;
            }

            if (!string.IsNullOrEmpty(Session["Client_Master_Job_edit"] as string))
            {
                Get_ClientMaster_edit_details("select_conwithcode_STD", Session["Client_Master_Job_edit"].ToString());
            }

            if (COMPANY_ID == "1" || COMPANY_ID == "10" || COMPANY_ID == "2145" || COMPANY_ID == "3267")
            {
                F.Visible = true;
                S.Visible = false;
            }

            if (Connection.Audit_Logs(COMPANY_ID) == "Y")
            {
                Audit_YN = "Y";
            }

            if (Connection.Imp_Multiple_CHA_IcegateID_enable(COMPANY_ID) == "Y")
            {
                ddl_MultipleIcegate_YN = "Y";
            }

            Session["BE_No"] = "";


            if (!this.IsPostBack)
            {

                /* hided by Tamil(13-03-2026)
                if (COMPANY_ID == "1" || COMPANY_ID == "2" || COMPANY_ID == "350" || COMPANY_ID == "408" || COMPANY_ID == "485" || COMPANY_ID == "534" || COMPANY_ID == "576" 
                    || COMPANY_ID == "744" || COMPANY_ID == "919" || COMPANY_ID == "2349" || COMPANY_ID == "2563" || COMPANY_ID == "3209" || COMPANY_ID == "3305"
                    || COMPANY_ID == "3305" || COMPANY_ID == "480" || COMPANY_ID == "1011" || COMPANY_ID == "1019" || COMPANY_ID == "1176" || COMPANY_ID == "1277"
                    )
                {
                    Acc_Charge.Visible = true;
                    Acc_Financial.Visible = true;
                }
                else
                {
                    Acc_Charge.Visible = false;
                    Acc_Financial.Visible = false;
                }*/


                Load_Mandatory_Flags();

                bool showTabs = new[] {"1","10", "2","350","408","485","534","576",
        "919","2349","2563","3209","3305",
        "480","1011","1019","1176","1277","1280","1698","3267"}
                        .Contains(COMPANY_ID);
               bool showEntitytab=new[]{"1","10"}.Contains(COMPANY_ID);
                Acc_NewTab.Visible = showEntitytab;
                Acc_Charge.Visible = showTabs;
                Acc_Financial.Visible = showTabs;
                if (COMPANY_ID == "744")
                {
                    var accChargeSun = FindControl("Acc_Charge_Sun");

                    if (accChargeSun != null)
                    {
                        accChargeSun.Visible = true;
                    }

                    Acc_Financial.Visible = true;
                }
                if (COMPANY_ID == "293")
                {
                    if (currentuser.ToUpper() == "ACCOUNTS" || currentuser.ToUpper() == "RTS" || currentuser.ToUpper() == "RTSAC" || currentuser.ToUpper() == "ACCOUNTS1" || currentuser.ToUpper() == "ACCOUNTS2")
                    {
                        Acc_Charge.Visible = true;
                        Acc_Financial.Visible = true;
                    }
                    else
                    {
                        Acc_Charge.Visible = false;
                        Acc_Financial.Visible = false;
                    }
                }
                if (COMPANY_ID == "3004")
                {
                    if (currentuser.ToUpper() == "BILLING" || currentuser.ToUpper() == "ADMIN" || currentuser.ToUpper() == "RTS")
                    {
                        Acc_Charge.Visible = true;
                        Acc_Financial.Visible = true;
                    }
                    else
                    {
                        Acc_Charge.Visible = false;
                        Acc_Financial.Visible = false;
                    }
                }
                if (COMPANY_ID == "3196")
                {
                    if (currentuser.ToUpper() == "CHAVAN" || currentuser.ToUpper() == "PATADE" || currentuser.ToUpper() == "RTS")
                    {
                        Acc_Charge.Visible = true;
                        Acc_Financial.Visible = true;
                    }
                    else
                    {
                        Acc_Charge.Visible = false;
                        Acc_Financial.Visible = false;
                    }
                }

                if (COMPANY_ID == "1" || COMPANY_ID == "10" || COMPANY_ID == "293" || COMPANY_ID == "2099" || COMPANY_ID == "3267")
                {
                    btnDSR.Visible = true;
                }
                else
                {
                    btnDSR.Visible = false;
                }

                if (Connection.Ryal() != string.Empty)
                {
                    txt_FF_Jobno.Attributes.Add("readonly", "readonly");
                    txt_FF_Jobno.Visible = true;
                    ND.Visible = false;
                    WD.Visible = true;
                }
                else if (Connection.I_Code() != string.Empty)
                {
                    txt_FF_Jobno.Attributes.Add("readonly", "readonly");
                    txt_FF_Jobno.Visible = true;
                    I_Code_WD.Visible = true;
                }
                else
                {
                    txt_FF_Jobno.Attributes.Add("readonly", "readonly");
                    txt_FF_Jobno.Visible = false;
                    ND.Visible = true;
                    WD.Visible = false;
                    I_Code_WD.Visible = false;
                }

                if (Connection.e_WayBill("I") == "Y")
                {
                    E_Way_Bill.Visible = true;
                }


                if (Connection.Billing_YN("Import") == "Y")
                {
                    Imp_Billing_Others1.Visible = true;
                }
                else
                {
                    Imp_Billing_Others1.Visible = false;
                }

                //hide on 02-04-2026 for enabled for common
                //if (COMPANY_ID == "10" || COMPANY_ID == "293" || COMPANY_ID == "480" || COMPANY_ID == "1011" || COMPANY_ID == "1019" || COMPANY_ID == "1025" || COMPANY_ID == "1176" || COMPANY_ID == "2145" || COMPANY_ID == "2373" || COMPANY_ID == "3004" || COMPANY_ID == "3010" || COMPANY_ID == "3196" || COMPANY_ID == "3267")//Capricorn
                //{
                //    Imp_Job_Logs_History.Visible = true;
                //}

                if (COMPANY_ID == "4" || COMPANY_ID == "10" || COMPANY_ID == "537")
                {
                    Imp_SDF_Others.Visible = true;
                }
                else
                {
                    Imp_SDF_Others.Visible = false;
                }

                load_Tr_Mode();

                txtJobDate.Text = dt.Today_Date();

                if (ddl_MultipleIcegate_YN == "Y")
                {
                    lbl_CHA_No.Visible = true;
                    ddl_Multiple_CHA_No.Visible = true;
                }
                else
                {
                    lbl_CHA_No.Visible = false;
                    ddl_Multiple_CHA_No.Visible = false;
                }

                /*
                if (COMPANY_ID == "1" || COMPANY_ID == "10" || COMPANY_ID == "2145" || COMPANY_ID == "3177" || COMPANY_ID == "3196" || COMPANY_ID == "3198" || COMPANY_ID == "3200" || COMPANY_ID == "3219" || COMPANY_ID == "3277" || COMPANY_ID == "3280" || COMPANY_ID == "3282")
                {
                    btnSignedBE.Visible = true;
                }
                else
                {
                    btnSignedBE.Visible = false;
                }
                */
                Premium_Services();

                ///*****Start Freight and CHA Mapping Method hided due to heavy load need to recheck ************
                /*
                if (Session["IsCHA_Mapped"] != null)
                {
                    if (Session["IsCHA_Mapped"].ToString() == "Y")
                    {
                        load_FRT_JOBS();
                    }
                    else
                    {
                        ddlFreightJobs.Enabled = false;
                    }
                }
                else
                {
                    ddlFreightJobs.Enabled = false;
                }
                */
                ddlFreightJobs.Enabled = false;
                ///*****End Freight and CHA Mapping Method hided due to heavy load need to recheck ************

                if (!string.IsNullOrEmpty(Request["Page"]))
                {
                    string s = Request["Page"].ToString();
                    if (Request["Page"] == "New")
                    {
                        Session["JobBulk"] = "New";// Added by YG on 21-05-2026

                        F.Visible = true;
                        S.Visible = false;
                        btnnew1.Visible = true;
                        btn_Masedit.Visible = false;

                        if (Connection.e_lOGIX_CHENNAI() != string.Empty)
                        {
                            txt_Ref_Loc.Enabled = true;
                            ddl_Ref_Type.Enabled = true;
                        }


                        hdn_New_Update.Value = "New";
                        txtImporterName.Attributes.Add("onblur", "javascript:CallServerside_Importer_2('" + txtImporterName.ClientID + "', '" + hd_Brslno.ClientID + "', '" + hdn_New_Update.Value + "', '" + txtJobNo.Text + "')");
                        txtSellerName.Attributes.Add("onblur", "javascript:CallServerside_Seller_STD('" + txtSellerName.ClientID + "', '" + hd_hss_br_sl_no.ClientID + "', '" + hdn_New_Update.Value + "', '" + txtJobNo.Text + "')");
                        txtBranchNo.Attributes.Add("onblur", "javascript:CallServerside_Importer_Branch('" + txtBranchNo.ClientID + "', '" + txtIECNo.ClientID + "', '" + hdn_New_Update.Value + "', '" + txtJobNo.Text + "')");

                        hdn_Jobno.Value = "";
                        Session.Remove("TRANSPORT_MODE");
                        Session.Remove("IMPORT_JOBNO");
                        Session.Remove("IMPORT_JOBDATE");
                        Session.Remove("FILING_STATUS");
                        Session.Remove("COUNTRY_OF_ORIGIN");
                        Session.Remove("CONT_TYPE");
                        Session.Remove("SUP_Master_Job_New");
                        Session.Remove("SUP_Master_Job_edit");
                        Session.Remove("JOBNO_PS");


                        //-------------------------------FROM LOGIN PAGE BASED ON BRANCH SELECT-----------------//
                        string TRANS_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();

                        if (TRANS_MODE == "A")
                        {
                            ddlTransportMode.SelectedValue = "Air";
                        }
                        else if (TRANS_MODE == "S")
                        {
                            ddlTransportMode.SelectedValue = "Sea";
                        }
                        else if (TRANS_MODE == "L")
                        {
                            ddlTransportMode.SelectedValue = "Land";
                        }

                        txtCustomsHouse.Text = Session["CUSTOMHOUSE_CODE"].ToString();
                        hdn_Customhouse_chk.Value = Set_Customs_House_Validation(txtCustomsHouse.Text);
                        //string b = Set_Customs_House_Validation(txtCustomsHouse.Text);
                        //string[] s1 = b.Split(new string[] { "~" }, StringSplitOptions.None);
                        //hdn_Customhouse_chk.Value= s1[0].ToString();
                        //txtCustomsHouse.Text = s1[1].ToString();



                        //-------------------------------FROM LOGIN PAGE BASED ON BRANCH SELECT-----------------//

                        if (Connection.COMPANYID() == "555") // AHAN SHIPPING 
                        {
                            ddlContainer_Type.Items.Remove("FCL");
                            ddlContainer_Type.Items.Insert(0, "FCL");
                        }

                        if (COMPANY_ID == "1" || COMPANY_ID == "10" || COMPANY_ID == "268") // AHAN SHIPPING 
                        {
                            btnPDFUpload_New.Visible = true;
                        }

                        if (COMPANY_ID == "1" || COMPANY_ID == "10" || COMPANY_ID == "1532") // AHAN SHIPPING 
                        {
                            btnPDFUpload_Manual.Visible = true;
                        }

                    }
                }
                else
                {
                    hdn_Jobno.Value = txtJobNo.Text;
                    Session["JobBulk"] = "Update";// Added by YG on 21-05-2026

                }
                //--------------- dont delete-------------------------------------//

                txtIECNo.Attributes.Add("readonly", "readonly");
                txtAddress1.Attributes.Add("readonly", "readonly");
                txtAddress2.Attributes.Add("readonly", "readonly");
                txtAddress3.Attributes.Add("readonly", "readonly");
                txtAddress4.Attributes.Add("readonly", "readonly");
                txtAddress5.Attributes.Add("readonly", "readonly");
                txtHighSeaSaleIECNo.Attributes.Add("readonly", "readonly");

                txtHighSeaSaleAddress1.Attributes.Add("readonly", "readonly");
                txtHighSeaSaleAddress2.Attributes.Add("readonly", "readonly");
                txtHighSeaSaleAddress3.Attributes.Add("readonly", "readonly");
                txtHighSeaSaleAddress4.Attributes.Add("readonly", "readonly");
                txtHighSeaSaleAddress.Attributes.Add("readonly", "readonly");
                //txtHSS_AdCode.Attributes.Add("readonly", "readonly");


                //--------------- dont delete--------------------------------------//

                //#------ PageRights Settings-----------------
                if (user_Create.IMP_EXP_MASTER_yn == "False")
                {
                    ND.Visible = false;
                    WD.Visible = false;
                    dv_mas_adcode_popup.Visible = false;
                    dv_mas_brlso_popup.Visible = false;
                    dv_hss_popup.Visible = false;
                    dv_hss_brsl_popup.Visible = false;
                    dv_hss_adcode_popup.Visible = false;
                    btnnew1.Visible = false;
                    btn_Masedit.Visible = false;
                }

                Get_Client_Default_Settings();

                ///------------------------------------------------auto search-----------------------------------------------------------------
                //IMPORTER
                //txtImporterName.Attributes.Add("onblur", "javascript:CallServerside_Importer_2('" + txtImporterName.ClientID + "', '" + hd_Brslno.ClientID + "')");
                //txtBranchNo.Attributes.Add("onblur", "javascript:CallServerside_Importer_Branch('" + txtBranchNo.ClientID + "', '" + txtIECNo.ClientID + "', '" + hdn_New_Update.Value + "', '" + txtJobNo.Text + "')");// This line placed in below, by chithra- 14-Feb-2018
                //txtSellerName.Attributes.Add("onblur", "javascript:CallServerside_Seller('" + txtSellerName.ClientID + "', '" + hd_hss_br_sl_no.ClientID + "')");
                //txtSellerName.Attributes.Add("onblur", "javascript:CallServerside_Seller_STD('" + txtSellerName.ClientID + "', '" + hd_hss_br_sl_no.ClientID + "')");
                //txtBranchSLNo.Attributes.Add("onblur", "javascript:CallServerside_BranchSeller('" + txtBranchSLNo.ClientID + "', '" + txtHighSeaSaleIECNo.ClientID + "')");//20-07-2-23 by Chithra
                txtBranchSLNo.Attributes.Add("onblur", "javascript:CallServerside_BranchSeller('" + txtBranchSLNo.ClientID + "', '" + txtHighSeaSaleIECNo.ClientID + "', '" + hdn_New_Update.Value + "', '" + txtJobNo.Text + "')");

                txtCountryName.Attributes.Add("onblur", "javascript:CallServerside_Country_of_orgin('" + txtCountryName.ClientID + "', '" + ddlTransportMode.ClientID + "')");
                txtCountryShipment.Attributes.Add("onblur", "javascript:CallServerside_Country_of_Shipment('" + txtCountryShipment.ClientID + "', '" + ddlTransportMode.ClientID + "')");

                txtCountryName.Attributes.Add("onfocus", "javascript:CallServerside_Country_of_orgin('" + txtCountryName.ClientID + "', '" + ddlTransportMode.ClientID + "')");
                txtCountryShipment.Attributes.Add("onfocus", "javascript:CallServerside_Country_of_Shipment('" + txtCountryShipment.ClientID + "', '" + ddlTransportMode.ClientID + "')");

                txtPortOrigin.Attributes.Add("onblur", "javascript:CallServerside_Port_of_orgin('" + txtPortOrigin.ClientID + "', '" + ddlTransportMode.ClientID + "')");
                txtPortShipment.Attributes.Add("onblur", "javascript:CallServerside_Port_of_Shipment('" + txtPortShipment.ClientID + "', '" + ddlTransportMode.ClientID + "')");
                txtPortOrigin.Attributes.Add("onfocus", "javascript:CallServerside_Port_of_orgin('" + txtPortOrigin.ClientID + "', '" + ddlTransportMode.ClientID + "')");
                txtPortShipment.Attributes.Add("onfocus", "javascript:CallServerside_Port_of_Shipment('" + txtPortShipment.ClientID + "', '" + ddlTransportMode.ClientID + "')");


                txtCommercial_StateName.Attributes.Add("onblur", "javascript:CallServerside_State_Name_Validation('" + txtCommercial_StateName.ClientID + "')");
                txtCommercial_StateName.Attributes.Add("onkeyup", "javascript:CallServerside_State_Name_Validation('" + txtCommercial_StateName.ClientID + "')");

                txtCustomsHouse.Attributes.Add("onblur", "javascript:CallServerside_Custom_House_Name('" + txtCustomsHouse.ClientID + "', '" + hdn_CustomsHouse_Name.ClientID + "')");

                if (COMPANY_ID == "125" || COMPANY_ID == "151" || COMPANY_ID == "152")
                {
                    chkKachha.Enabled = false;
                }

                if (COMPANY_ID == "293" || COMPANY_ID == "381" || COMPANY_ID == "382" || COMPANY_ID == "385" || COMPANY_ID == "394" || COMPANY_ID == "461" || COMPANY_ID == "508" || COMPANY_ID == "511" || COMPANY_ID == "10" || COMPANY_ID == "4" || COMPANY_ID == "2099")
                {
                    divparty_ref.Visible = true;
                }
                else
                {
                    divparty_ref.Visible = false;
                }

                if (COMPANY_ID == "1" || COMPANY_ID == "4" || COMPANY_ID == "10" || COMPANY_ID == "499")
                {
                    btngenexcel.Visible = true;
                }

                Edit_GeneralDetails();
            }

            hdfTransport_mode.Value = ddlTransportMode.SelectedValue.ToString();

            try
            {
                if (Session["USER_DETAILS_DS"] != null)
                {
                    if (Session["JOB_TYPE"] != null)
                    {
                        ds = (DataSet)Session["USER_DETAILS_DS"];
                    }

                    DataView view1 = ds.Tables[1].DefaultView;
                    string USER_CREATION_ID, BRANCH;
                    //COMPANY_ID = Session["COMPANY_ID"].ToString();
                    USER_CREATION_ID = Session["USER_CREATION_ID"].ToString();
                    BRANCH = Session["currentbranch"].ToString();

                    view1.RowFilter = "BRANCH = '" + BRANCH + "' and " + "COMPANY_ID = " + COMPANY_ID + " and " + "USER_CREATION_ID = " + USER_CREATION_ID + "";
                    DataTable table1 = view1.ToTable();
                    DataSet dt_UserRights = new DataSet();
                    dt_UserRights.Tables.Add(table1);
                    if (dt_UserRights.Tables[0].Rows.Count > 0)
                    {
                        for (int a = 0; a < dt_UserRights.Tables[0].Rows.Count; a++)
                        {
                            PAGE_READ = dt_UserRights.Tables[0].Rows[a]["PAGE_READ"].ToString();
                            PAGE_WRITE = dt_UserRights.Tables[0].Rows[a]["PAGE_WRITE"].ToString();
                            PAGE_MODIFY = dt_UserRights.Tables[0].Rows[a]["PAGE_MODIFY"].ToString();
                            PAGE_DELETE = dt_UserRights.Tables[0].Rows[a]["PAGE_DELETE"].ToString();
                            Screen_IdNew = dt_UserRights.Tables[0].Rows[a]["SCREEN_ID"].ToString();

                            Page_Show_Hide(Convert.ToInt32(Screen_IdNew));
                        }
                    }
                    else
                    {
                        Screen_IdNew = "0";
                        Page_Show_Hide(Convert.ToInt32(Screen_IdNew));
                    }
                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }

            if (!IsPostBack)
            {
                txtid.Text = string.Empty;
                /*if (Connection.e_lOGIX_CHENNAI() != string.Empty)
                {
                    if (COMPANY_ID != "4")
                    {
                        txtFile_Ref_No.Attributes.Add("readonly", "readonly");
                        txtFile_Ref_No.Style.Add("background-color", "#F0F0F0");
                    }
                }
                else
                {
                    txtFile_Ref_No.Attributes.Remove("readonly");
                    txtFile_Ref_No.Style.Add("background-color", "white");
                }*/
            }

            //-----------------job edit S---------------------------

            if (txtBE_No.Text != string.Empty && txtBE_Date.Text != string.Empty && txtCustomsHouse.Text != string.Empty)
            {
                lblTrkBENo.Visible = true;
            }
            else
            {
                lblTrkBENo.Visible = false;
            }

            //if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "188" || Connection.COMPANYID() == "252" || Connection.COMPANYID() == "293" || Connection.COMPANYID() == "394" || Connection.COMPANYID() == "1029" || Connection.COMPANYID() == "1108" || Connection.COMPANYID() == "1612" || Connection.COMPANYID() == "2099" || Connection.COMPANYID() == "3267" || Connection.COMPANYID() == "3275")
            //{
                lbl_ETA.Visible = true;
                txt_ETA_Date.Visible = true;
                txtWarehouseCode.Enabled = true;
                lbl_ETA.Font.Bold = true;
                txt_ETA_Date.Font.Bold = true;
                lbl_ETA.ForeColor = System.Drawing.Color.Red;
            //}
            //else
            //{
            //    lbl_ETA.Visible = false;
            //    txt_ETA_Date.Visible = false;
            //}

            if (ddlBEType.SelectedItem.Text == "Warehouse" || ddlBEType.SelectedItem.Text == "SEZ FTA-Z" || ddlBEType.SelectedItem.Text == "SEZ DTA-M"
                                                 || ddlBEType.SelectedItem.Text == "Jobbing" || ddlBEType.SelectedItem.Text == "Repair & Return" || ddlBEType.SelectedItem.Text == "Exhibition" || ddlBEType.SelectedItem.Text == "Destruction" || ddlBEType.SelectedItem.Text == "Movement of Goods" || ddlBEType.SelectedItem.Text == "Stock Item")
            {
                txtWarehouseCode.Enabled = true;
            }

            if (ddlBEType.SelectedItem.Text == "SEZ DTA-T" || ddlBEType.SelectedItem.Text == "SEZ FTA-Z" || ddlBEType.SelectedItem.Text == "SEZ DTA-M" || ddlBEType.SelectedItem.Text == "Stock Item")
            {
                Lbl_Imp_Exp_Type.Style.Add("display", "block");
                ddlType.Style.Add("display", "block");
            }
            else
            {
                Lbl_Imp_Exp_Type.Style.Add("display", "none");
                ddlType.Style.Add("display", "none");
            }


            hdsaveandclose.Value = "No";
            Elogix_Chennai_Service();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
        btngenexcel.Visible = false;
    }

    private void Load_jobedit_Visible()
    {
        try
        {
            if (Connection.Get_User_Imp_Settings_Job_Edit("GENERAL_JOB_EDIT") == "E")
            {
                btnedit.Visible = true;
            }

            /*
            if (Session["COMPANY_LICENSE"] != null)
            {
                if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00001" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00004" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00155" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00163" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00156" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00181" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00190" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00196" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00203" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00205" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00244" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00247" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00145" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00293" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00341" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00010" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00301" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00286" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00130" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00002" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00337" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00287" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00350" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00352" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00381" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00382" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00384" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00400" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00408" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00435" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00438" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00458" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00469" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00470" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00479" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00480" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00485" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00492" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00499" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00504" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00508" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00510" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00511" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00525" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00526" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00534" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00536" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00538" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00594" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00603" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00606" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00607" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00639" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00660" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00665" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00682" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00693" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00706" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00744" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00849" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00892" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00919" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01007" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01013" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01018" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01029" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01035" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01048" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01051" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01058" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01065" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01069" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01101" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01120" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01135" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01084" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01157" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01163" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01164" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01165" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01166" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01167" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01175" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01182" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01183" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01206" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri05001" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri05002" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri05003" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri05004" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri05005" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri05006" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri05007" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri05008" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01648" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01658")
                {
                    btnedit.Visible = true;
                }
                else
                {
                    btnedit.Visible = false;
                }
            }
             * */

            btn_Tr_Mode_Change.Visible = true;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
    }

    private void load_Tr_Mode()
    {
        try
        {
            ddlTransportMode.Items.Clear();
            ddlTransportMode.Items.Add(new ListItem("Air", "Air"));
            ddlTransportMode.Items.Add(new ListItem("Sea", "Sea"));
            ddlTransportMode.Items.Add(new ListItem("Land", "Land"));
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
    }

    public void Page_Show_Hide(int i)
    {
        try
        {
            bool is_page;
            if (i == 8)
            {
                is_page = Page_Rights();
                if (is_page == true)
                {
                    Submission.Style.Add("display", "block");
                }
                else
                {
                    Submission.Style.Add("display", "none");
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
    }
    public bool Page_Rights()
    {
        bool Is_Page;
        try
        {

            if (PAGE_READ == "False" && PAGE_WRITE == "False" && PAGE_MODIFY == "False" && PAGE_DELETE == "False")
            {
                Is_Page = false;
            }
            else
            {
                Is_Page = true;
            }
            return Is_Page;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

            return false;
        }

    }
    public void Page_Rights(int i)
    {
        try
        {
            //user_Create.RetrieveAll_User_Screen_Rights_Details(i);//hide on 27-08-2026
            user_Create.RetrieveAll_User_Screen_Rights_Details_USERWISE_IEC_settings(i);
            PAGE_WRITE = user_Create.PAGE_WRITE;
            PAGE_READ = user_Create.PAGE_READ;
            PAGE_MODIFY = user_Create.PAGE_MODIFY;
            PAGE_DELETE = user_Create.PAGE_DELETE;

            //---------------READ ONLY------------------//

            if (PAGE_READ == "False")
            {
                btnSave.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                btnsavenext.Enabled = false;

                btnNew.ToolTip = "You don't have permission to access";
                btnSave.ToolTip = "You don't have permission to access";
                btnUpdate.ToolTip = "You don't have permission to access";
                btnDelete.ToolTip = "You don't have permission to access";
            }
            else
            {
                if (PAGE_WRITE == "True")
                {
                    btnSave.Enabled = true;
                    btnNew.Enabled = true;
                    btnsavenext.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                    btnSave.ToolTip = "You don't have permission to access";
                    btnNew.Enabled = false;
                    btnsavenext.Enabled = false;
                }

                if (PAGE_MODIFY == "True")
                    btnUpdate.Enabled = true;
                else
                {
                    btnUpdate.Enabled = false;
                    btnUpdate.ToolTip = "You don't have permission to access";

                }
                if (PAGE_DELETE == "True")
                    btnDelete.Enabled = true;
                else
                {
                    btnDelete.Enabled = false;
                    btnDelete.ToolTip = "You don't have permission to access";

                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
    }

    public DataSet gridbind()
    {
        try
        {
            Transact.JOBID = HiddenField1.Value;
            Transact.JOBNO = "";
            Transact.IMPORTER_NAME = "";
            Transact.TRANSPORT_MODE = "";
            Transact.CUSTOMS_HOUSE = "";
            Transact.Ename = "select_Id";
            Transact.WORKING_PERIOD = SELECT_BRANCH;

            dtuser = Transact.RetrieveAll_General_Details();

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
        return dtuser;
    }

    public void Edit_GeneralDetails()
    {
        try
        {
            if (Request.QueryString["JOBID"] != "" && Request.QueryString["JOBID"] != null)
            {
                btnnew1.Visible = false;
                if (user_Create.IMP_EXP_MASTER_yn == "False")
                {
                    btn_Masedit.Visible = false;
                }
                else
                {
                    btn_Masedit.Visible = true;
                }


                ddlFreightJobs.Enabled = false;
                if (COMPANY_ID != "1" && COMPANY_ID != "10" && COMPANY_ID != "2145" && COMPANY_ID != "3267")
                {
                    F.Visible = false;
                    S.Visible = true;
                }

                if (COMPANY_ID == "1" || COMPANY_ID == "10" || COMPANY_ID == "480" || COMPANY_ID == "499" || COMPANY_ID == "504" || COMPANY_ID == "511" || COMPANY_ID == "526" || COMPANY_ID == "534" || COMPANY_ID == "660")
                {
                    txtCustomsHouse.Enabled = true;
                    ddlTransportMode.Enabled = true;
                }
                else
                {
                    txtCustomsHouse.Enabled = false;
                    ddlTransportMode.Enabled = false;
                }
                Load_jobedit_Visible();
                Hdcountryoforgin_chk.Value = "Yes";
                Hdcountryofshipment_chk.Value = "Yes";

                Hdportoforgin_Chk.Value = "Yes";
                Hdportofshipment_chk.Value = "Yes";

                hdn_CountryCD_PortOrigin_chk.Value = "Yes";
                hdn_CountryCD_PortofShipment_chk.Value = "Yes";

                hd_joblck.Value = "No";
                hdn_Jobno.Value = "1";
                HiddenField1.Value = Request.QueryString["JOBID"].ToString();

                int i = 0;
                gridbind();
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    txtjobps.Text = dtuser.Tables[0].Rows[0]["JOBNO_PS"].ToString() == "" ? dtuser.Tables[0].Rows[0]["JOBNO"].ToString() : dtuser.Tables[0].Rows[0]["JOBNO_PS"].ToString();
                    hd_Brslno.Value = dtuser.Tables[0].Rows[0]["BRANCH_NO"].ToString();
                    Session["JOBNO_PS"] = txtjobps.Text;

                    hdprefix.Value = dtuser.Tables[0].Rows[0]["JOB_PREFIX"].ToString() == null ? string.Empty : dtuser.Tables[0].Rows[0]["JOB_PREFIX"].ToString();
                    hdsuffix.Value = dtuser.Tables[0].Rows[0]["JOB_SUFFIX"].ToString() == null ? string.Empty : dtuser.Tables[0].Rows[0]["JOB_SUFFIX"].ToString();

                    //hdn_ImporterType.Value = dtuser.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();
                    txtJobNo.Text = dtuser.Tables[0].Rows[0]["JOBNO"].ToString();
                    Session["Jobno_Excel"] = txtJobNo.Text;
                    Session["Jobno_OpenStatus"] = txtJobNo.Text;

                    if (COMPANY_ID == "10" || Connection.COMPANYID() == "1" || COMPANY_ID == "2145" || COMPANY_ID == "3267" || COMPANY_ID == "4004")
                    {
                        DateTime opentime = DateTime.Now;
                        DateTime closingtime = opentime.AddMinutes(15);

                        DataSet ds_User_st = new DataSet();
                        ds_User_st = Common_CS.Get_Job_User_Lock_Status(txtJobNo.Text, currentuser, Convert.ToString(opentime), Convert.ToString(closingtime), "Insert_User_History", "Import");
                    }

                    txt_jobno.Text = txtJobNo.Text;
                    txt_M_jobps.Text = dtuser.Tables[0].Rows[0]["JOB_PREFIX"].ToString() == null ? string.Empty : dtuser.Tables[0].Rows[0]["JOB_PREFIX"].ToString();
                    txt_M_jobsf.Text = dtuser.Tables[0].Rows[0]["JOB_SUFFIX"].ToString() == null ? string.Empty : dtuser.Tables[0].Rows[0]["JOB_SUFFIX"].ToString();

                    hdn_New_Update.Value = "Update";
                    txtImporterName.Attributes.Add("onblur", "javascript:CallServerside_Importer_2('" + txtImporterName.ClientID + "', '" + hd_Brslno.ClientID + "', '" + hdn_New_Update.Value + "', '" + txtJobNo.Text + "')");
                    txtSellerName.Attributes.Add("onblur", "javascript:CallServerside_Seller_STD('" + txtSellerName.ClientID + "', '" + hd_hss_br_sl_no.ClientID + "', '" + hdn_New_Update.Value + "', '" + txtJobNo.Text + "')");
                    txtBranchNo.Attributes.Add("onblur", "javascript:CallServerside_Importer_Branch('" + txtBranchNo.ClientID + "', '" + txtIECNo.ClientID + "', '" + hdn_New_Update.Value + "', '" + txtJobNo.Text + "')");
                    txtBranchSLNo.Attributes.Add("onblur", "javascript:CallServerside_BranchSeller('" + txtBranchSLNo.ClientID + "', '" + txtHighSeaSaleIECNo.ClientID + "', '" + hdn_New_Update.Value + "', '" + txtJobNo.Text + "')");

                    txtJobDate.Text = dtuser.Tables[0].Rows[0]["JOBDATE"].ToString();
                    txtBE_No.Text = dtuser.Tables[0].Rows[0]["BE_NO"].ToString();
                    txtBE_Date.Text = dtuser.Tables[0].Rows[0]["BE_DATE"].ToString();
                    Session["BE_No"] = txtBE_No.Text;

                    string mode = dtuser.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();

                    hdfTransport_mode.Value = mode;
                    Session["Transport_Mode_Port"] = mode;

                    ddlTransportMode.SelectedValue = mode;
                    hdn_Trmode_excel.Value = mode; // YG
                    string BE_type = dtuser.Tables[0].Rows[0]["BE_TYPE"].ToString();
                    hdn_BeType_excel.Value = BE_type; // YG


                    if (Connection.COMPANYID() == "10" || Connection.COMPANYID() == "480" || Connection.COMPANYID() == "747")
                    {

                        hdn_CountryCD_PortOrigin_chk.Value = "Yes";
                        hdn_CountryCD_PortofShipment_chk.Value = "Yes";

                        if (ddlTransportMode.SelectedItem.Text == "Sea" || ddlTransportMode.SelectedItem.Text == "Land")
                        {
                            txtPortOrigin.Attributes.Add("onblur", "javascript:CallServerside_Port_Country_Origin('" + txtCountryShipment.ClientID + "', '" + txtPortOrigin.ClientID + "')");
                            txtPortOrigin.Attributes.Add("onkeyup", "javascript:CallServerside_Port_Country_Origin('" + txtCountryShipment.ClientID + "', '" + txtPortOrigin.ClientID + "')");
                            txtPortOrigin.Attributes.Add("onfocus", "javascript:CallServerside_Port_Country_Origin('" + txtCountryShipment.ClientID + "', '" + txtPortOrigin.ClientID + "')");

                            txtPortShipment.Attributes.Add("onblur", "javascript:CallServerside_Port_Country_Shipment('" + txtCountryShipment.ClientID + "', '" + txtPortShipment.ClientID + "')");
                            txtPortShipment.Attributes.Add("onkeyup", "javascript:CallServerside_Port_Country_Shipment('" + txtCountryShipment.ClientID + "', '" + txtPortShipment.ClientID + "')");
                            txtPortShipment.Attributes.Add("onfocus", "javascript:CallServerside_Port_Country_Shipment('" + txtCountryShipment.ClientID + "', '" + txtPortShipment.ClientID + "')");
                        }
                    }


                    ddlBEType.Items.Clear();
                    ddlBEType.Items.Add("Home");
                    ddlBEType.Items.Add("Warehouse");
                    ddlBEType.Items.Add("Ex-Bond");

                    Load_BE_Type();

                    ddlBEType.Items.Remove(BE_type);
                    Session["BE_TYPE"] = BE_type;

                    ddlBEType.Items.Insert(0, BE_type);
                    Show_BEtype(BE_type);

                    //string CusHouseCode_Validate = "";
                    //if (dtuser.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString() != "" && dtuser.Tables[0].Rows[0]["CUSTOMS_HOUSE_NAME"].ToString() != "")
                    //{
                    //    txtCustomsHouse.Text = dtuser.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString() + "-" + dtuser.Tables[0].Rows[0]["CUSTOMS_HOUSE_NAME"].ToString();
                    //    string[] spp = txtCustomsHouse.Text.Split('-');
                    //    CusHouseCode_Validate = spp[0];

                    //}
                    //else if (dtuser.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString() != "" && dtuser.Tables[0].Rows[0]["CUSTOMS_HOUSE_NAME"].ToString() == "")
                    //{
                    //    txtCustomsHouse.Text = dtuser.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                    //    CusHouseCode_Validate = txtCustomsHouse.Text;

                    //    string b = Set_Customs_House_Validation(txtCustomsHouse.Text);
                    //    string[] s1 = b.Split(new string[] { "~" }, StringSplitOptions.None);

                    //    hdn_Customhouse_chk.Value = s1[0].ToString();
                    //    txtCustomsHouse.Text = s1[1].ToString();
                    //}
                    txtCustomsHouse.Text = dtuser.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();


                    hdn_CustomsHouse_Name.Value = dtuser.Tables[0].Rows[0]["CUSTOMS_HOUSE_NAME"].ToString();
                    hdn_Customhouse_chk.Value = Set_Customs_House_Validation(txtCustomsHouse.Text);

                    txtImporterName.Text = dt.Replace(dtuser.Tables[0].Rows[0]["IMPORTER_NAME"].ToString());
                    txtIECNo.Text = dtuser.Tables[0].Rows[0]["IEC_NO"].ToString();
                    txtBranchNo.Text = dtuser.Tables[0].Rows[0]["BRANCH_NO"].ToString();

                    if (!string.IsNullOrEmpty(Session["Client_Master_Job_edit"] as string))
                    {
                        //Get_ClientMaster_edit_details("select_branch", "");
                    }
                    else
                    {
                        txtAddress1.Text = dt.Replace(dtuser.Tables[0].Rows[0]["ADDRESS1"].ToString());
                        txtAddress2.Text = dt.Replace(dtuser.Tables[0].Rows[0]["ADDRESS2"].ToString());
                        txtAddress3.Text = dt.Replace(dtuser.Tables[0].Rows[0]["ADDRESS3"].ToString());
                        txtAddress4.Text = dt.Replace(dtuser.Tables[0].Rows[0]["ADDRESS4"].ToString());
                        txtAddress5.Text = dt.Replace(dtuser.Tables[0].Rows[0]["ADDRESS5"].ToString());
                        txt_Payment_Method.Text = dt.Replace(dtuser.Tables[0].Rows[0]["PAYMENT_METHOD_CODE"].ToString());

                        string commercialYN = dtuser.Tables[0].Rows[0]["COMMERCIAL_DETAILS_STATUS"].ToString();
                        Session["commercialYN"] = commercialYN;
                        if (commercialYN == "Y")
                        {
                            //div_CommercialTax.Style.Add("Display", "Block");

                            ddlCommercial_Tax_yn.Items.Clear();
                            //ddlCommercial_Tax_yn.Items.Add("N");
                            ddlCommercial_Tax_yn.Items.Add("Y");
                            ddlCommercial_Tax_yn.Items.Remove(commercialYN);
                            ddlCommercial_Tax_yn.Items.Insert(0, commercialYN);


                            txtCommercial_StateName.Text = dtuser.Tables[0].Rows[0]["COMMERCIAL_TAX_STATENAME"].ToString();
                            txtCommercial_StateCode.Text = dtuser.Tables[0].Rows[0]["COMMERCIAL_TAX_STATECODE"].ToString();
                            ddl_Commercial_Type.SelectedValue = dtuser.Tables[0].Rows[0]["COMMERCIAL_TAX_TYPE"].ToString();
                            txtCommercial_RegistrationNo.Text = dtuser.Tables[0].Rows[0]["COMMERCIAL_TAX_REGISTRATION_NO"].ToString();
                            ddlType.SelectedValue = dtuser.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();
                            hdn_ImporterType.Value = dtuser.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();//Added by pandiyan on 04/06/2025
                            Session["IMP_EXP_TYPE"] = hdn_ImporterType.Value;//Added by pandiyan on 04/06/2025
                            hdn_StateName.Value = dtuser.Tables[0].Rows[0]["COMMERCIAL_TAX_STATENAME"].ToString();
                            hdn_StateName_chk.Value = Set_State_Name_Validation(hdn_StateName.Value);

                            hdn_TIN_NO.Value = dtuser.Tables[0].Rows[0]["COMMERCIAL_TAX_REGISTRATION_NO"].ToString();
                            hdn_StateCode.Value = dtuser.Tables[0].Rows[0]["COMMERCIAL_TAX_STATECODE"].ToString();
                            hdn_commercialType.Value = dtuser.Tables[0].Rows[0]["COMMERCIAL_TAX_TYPE"].ToString();
                            //ddl_GSTN_Type.SelectedValue = dtuser.Tables[0].Rows[0]["GSTN_TYPE"].ToString();
                            //txt_GSTN_ID.Text = dtuser.Tables[0].Rows[0]["GSTN_ID"].ToString();

                        }
                        else
                        {
                            //div_CommercialTax.Style.Add("Display", "none");
                            ddlCommercial_Tax_yn.Items.Clear();
                            //ddlCommercial_Tax_yn.Items.Add("N");
                            ddlCommercial_Tax_yn.Items.Add("Y");
                        }
                    }

                    Session.Remove("Client_Master_Job_edit");

                    txtCountryName.Text = dt.Replace(dtuser.Tables[0].Rows[0]["COUNTRY_ORIGIN"].ToString());
                    Hdcountryoforgin_chk.Value = Ser_Country_of_orgin(txtCountryName.Text, hdfTransport_mode.Value);

                    txtPortOrigin.Text = dt.Replace(dtuser.Tables[0].Rows[0]["PORT_ORIGIN"].ToString());
                    Hdportoforgin_Chk.Value = Ser_Port_of_orgin(txtPortOrigin.Text, ddlTransportMode.SelectedValue);

                    txtPortShipment.Text = dt.Replace(dtuser.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString());
                    Hdportofshipment_chk.Value = Ser_Port_of_orgin(txtPortShipment.Text, ddlTransportMode.SelectedValue);

                    txtCountryShipment.Text = dt.Replace(dtuser.Tables[0].Rows[0]["COUNTRY_SHIPMENT"].ToString());
                    Hdcountryofshipment_chk.Value = Ser_Country_of_orgin(txtCountryShipment.Text, hdfTransport_mode.Value);

                    string fil_status = dtuser.Tables[0].Rows[0]["FILING_STATUS"].ToString();
                    hdn_FilingStatus_excel.Value = fil_status;// YG

                    ddlFilingStatus.Items.Clear();
                    ddlFilingStatus.Items.Add("Normal");
                    ddlFilingStatus.Items.Add("Prior");
                    ddlFilingStatus.Items.Add("Advanced");
                    ddlFilingStatus.Items.Remove(fil_status);

                    ddlFilingStatus.Items.Insert(0, fil_status);

                    string sec46 = dtuser.Tables[0].Rows[0]["SECTION46"].ToString();

                    if (sec46 == "Y")
                    {
                        chkSection46.Checked = true;
                        txtSection46Desc.Enabled = true;
                        chksec46.Value = sec46;
                    }
                    else
                    {
                        chkSection46.Checked = false;
                        txtSection46Desc.Enabled = false;
                        chksec46.Value = "";
                    }


                    txtSection46Desc.Text = dt.Replace(dtuser.Tables[0].Rows[0]["SECTION46_DESC"].ToString());
                    string fircheck = dtuser.Tables[0].Rows[0]["FIRSTCHECK"].ToString();

                    if (fircheck == "Y")
                    {
                        chkFirstCheck.Checked = true;
                        txtFirstCheckDesc.Enabled = true;
                        chkFirCheck.Value = fircheck;
                    }
                    else
                    {
                        chkFirstCheck.Checked = false;
                        txtFirstCheckDesc.Enabled = false;
                        chkFirCheck.Value = "";
                    }

                    txtFirstCheckDesc.Text = dt.Replace(dtuser.Tables[0].Rows[0]["FIRSTCHECK_DESC"].ToString());
                    string grnchannel = dtuser.Tables[0].Rows[0]["GREEN_CHANNEL"].ToString();

                    if (grnchannel == "Y")
                    {
                        chkGreenChannel.Checked = true;
                        txtGreenChannelDesc.Enabled = true;
                        chkGrnChannel.Value = grnchannel;
                    }
                    else
                    {
                        chkGreenChannel.Checked = false;
                        txtGreenChannelDesc.Enabled = false;
                        chkGrnChannel.Value = "";
                    }
                    txtGreenChannelDesc.Text = dt.Replace(dtuser.Tables[0].Rows[0]["GREEN_CHANNEL_DESC"].ToString());
                    string kachha = dtuser.Tables[0].Rows[0]["KACHHA_BE"].ToString();

                    if (kachha == "Y")
                    {
                        chkKachha.Checked = true;
                        txtKachhaDesc.Enabled = true;
                        chkKach.Value = kachha;

                    }
                    else
                    {
                        chkKachha.Checked = false;
                        txtKachhaDesc.Enabled = false;
                        chkKach.Value = "";
                    }
                    txtKachhaDesc.Text = dt.Replace(dtuser.Tables[0].Rows[0]["KACHHA_BE_DESC"].ToString());

                    string sec48 = dtuser.Tables[0].Rows[0]["SECTION48"].ToString();
                    if (sec48 == "Y")
                    {
                        chkSection48.Checked = true;
                        txtSection48Desc.Enabled = true;
                        chkSec48.Value = sec48;
                    }
                    else
                    {
                        chkSection48.Checked = false;
                        txtSection48Desc.Enabled = false;
                        chkSec48.Value = "";
                    }

                    txtSection48Desc.Text = dt.Replace(dtuser.Tables[0].Rows[0]["SECTION48_DESC"].ToString());


                    string Provisional = dtuser.Tables[0].Rows[0]["PROVISIONAL"].ToString();
                    if (Provisional == "Y")
                    {
                        chkProvisional.Checked = true;
                        txtProvisionalDesc.Enabled = true;
                        chkProv.Value = Provisional;
                    }
                    else
                    {
                        chkProvisional.Checked = false;
                        txtProvisionalDesc.Enabled = false;
                        chkProv.Value = "";
                    }

                    txtProvisionalDesc.Text = dt.Replace(dtuser.Tables[0].Rows[0]["PROVISIONAL_DESC"].ToString());

                    string hss = dtuser.Tables[0].Rows[0]["HIGH_SEA_SALE"].ToString();
                    txtBranchSLNo.Text = dtuser.Tables[0].Rows[0]["HIGH_SEA_BRANCH_SL_NO"].ToString();

                    hd_hss_br_sl_no.Value = dtuser.Tables[0].Rows[0]["HIGH_SEA_BRANCH_SL_NO"].ToString();

                    if (hss == "Y")
                    {
                        chkHighSeaSale.Checked = true;
                        txtSellerName.Enabled = true;
                        txtHighSeaSaleIECNo.Enabled = true;
                        txtBranchSLNo.Enabled = true;
                        txtHighSeaSaleAddress.Enabled = true;
                        txtHighSeaSaleAddress1.Enabled = true;
                        txtHighSeaSaleAddress2.Enabled = true;
                        txtHighSeaSaleAddress3.Enabled = true;
                        txtHighSeaSaleAddress4.Enabled = true;
                        txtHSS_AdCode.Enabled = true;
                        txt_PrecedingLevel.Enabled = true;
                        chkHghSeaSale.Value = hss;

                    }
                    else
                    {
                        chkHighSeaSale.Checked = false;
                        txtSellerName.Enabled = false;
                        txtHighSeaSaleIECNo.Enabled = false;
                        txtBranchSLNo.Enabled = false;
                        txtBranchSLNo.Text = "";

                        txtHighSeaSaleAddress.Enabled = false;
                        txtHighSeaSaleAddress1.Enabled = false;
                        txtHighSeaSaleAddress2.Enabled = false;
                        txtHighSeaSaleAddress3.Enabled = false;
                        txtHighSeaSaleAddress4.Enabled = false;
                        txt_PrecedingLevel.Enabled = false;
                        txtHSS_AdCode.Enabled = false;

                        chkHghSeaSale.Value = "";

                    }

                    txtSellerName.Text = dt.Replace(dtuser.Tables[0].Rows[0]["HIGH_SEA_SALE_NAME"].ToString());
                    txtHighSeaSaleIECNo.Text = dtuser.Tables[0].Rows[0]["HIGH_SEA_IEC"].ToString();
                    txtHighSeaSaleAddress.Text = dt.Replace(dtuser.Tables[0].Rows[0]["HSS_ADD1"].ToString());
                    txtHighSeaSaleAddress1.Text = dt.Replace(dtuser.Tables[0].Rows[0]["HSS_ADD2"].ToString());
                    txtHighSeaSaleAddress2.Text = dt.Replace(dtuser.Tables[0].Rows[0]["HSS_ADD3"].ToString());
                    txtHighSeaSaleAddress3.Text = dt.Replace(dtuser.Tables[0].Rows[0]["HSS_ADD4"].ToString());
                    txtHighSeaSaleAddress4.Text = dt.Replace(dtuser.Tables[0].Rows[0]["HSS_ADD5"].ToString());
                    txtHSS_AdCode.Text = dt.Replace(dtuser.Tables[0].Rows[0]["HSS_ADCODE"].ToString());
                    txtWarehouseName.Text = dt.Replace(dtuser.Tables[0].Rows[0]["WAREHOUSE_NAME"].ToString());
                    txtWarehouseCode.Text = dt.Replace(dtuser.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString());
                    txt_ADCode.Text = dt.Replace(dtuser.Tables[0].Rows[0]["ADCODE"].ToString());
                    txt_UCR_Ref_No.Text = dt.Replace(dtuser.Tables[0].Rows[0]["UCR_NO"].ToString());
                    txt_PrecedingLevel.Text = dt.Replace(dtuser.Tables[0].Rows[0]["PRECEDING_LEVEL"].ToString());
                    txt_UCR_Type.Text = dt.Replace(dtuser.Tables[0].Rows[0]["UCR_TYPE"].ToString());
                    txt_UCR_Type.Text = dt.Replace(dtuser.Tables[0].Rows[0]["UCR_TYPE"].ToString());

                    if (!string.IsNullOrEmpty(Session["BE_No"].ToString()))
                    {
                        div_AmendmentType.Visible = true;
                        ddl_AmendmentType.SelectedValue = dt.Replace(dtuser.Tables[0].Rows[0]["AMENDMENT_TYPE"].ToString());
                    }

                    //************************* DON'T DELETE - ITS FOR EXBOND DETAILS  ********************** 

                    //hdn_Exbond_BENo.Value = dtuser.Tables[0].Rows[0]["EXBOND_INBOND_BE_NO"].ToString();
                    //hdn_Exbond_BEDate.Value = dtuser.Tables[0].Rows[0]["EXBOND_INBOND_BE_DATE"].ToString();
                    //hdn_Exbond_BondNo.Value = dtuser.Tables[0].Rows[0]["EXBOND_BOND_NO"].ToString();
                    //hdn_Exbond_BondDate.Value = dtuser.Tables[0].Rows[0]["EXBOND_BOND_DATE"].ToString();
                    //hdn_Exbond_Warehouse_Customs.Value = dtuser.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS"].ToString();
                    //hdn_Exbond_Warehouse_Code.Value = dtuser.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS_CODE"].ToString();
                    //hdn_Exbond_NoofPackages.Value = dtuser.Tables[0].Rows[0]["EXBOND_NOOFPACKAGE"].ToString();
                    //hdn_Exbond_NoofPackages_Code.Value = dtuser.Tables[0].Rows[0]["EXBOND_NOOFPACKAGE_UNITCODE"].ToString();
                    //hdn_Exbond_Gross_Weight.Value = dtuser.Tables[0].Rows[0]["EXBOND_GROSS_WEIGHT"].ToString();
                    //hdn_Exbond_Gross_Weight_Code.Value = dtuser.Tables[0].Rows[0]["EXBOND_GROSS_WEIGHT_UNITCODE"].ToString();
                    //hdn_Direct_Exbonding.Value = dtuser.Tables[0].Rows[0]["EXBOND_DIRECT_EXBONDING"].ToString();

                    //***************************************************************************************************

                    txtRemarks.Text = dtuser.Tables[0].Rows[0]["REMARKS"].ToString();
                    txtFile_Ref_No.Text = dtuser.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
                    JOB_LOCK = dtuser.Tables[0].Rows[0]["JOB_STATUS"].ToString();
                    JOB_RELEASE = dtuser.Tables[0].Rows[0]["JOB_RELEASE"].ToString();
                    JOB_USER = dtuser.Tables[0].Rows[0]["USERID"].ToString();

                    Session["JOB_LOCK"] = JOB_LOCK;
                    Session["JOB_RELEASE"] = JOB_RELEASE;
                    Session["JOB_USER"] = JOB_USER;

                    if (Connection.Freight_Forward() != string.Empty)
                    {
                        DataSet s = new DataSet();
                        txt_FF_Jobno.Visible = true;
                        if (COMPANY_ID == "")
                        {
                            I_FACT IF = new I_FACT();
                            s = IF.Get_I_Fact_Jobno(dtuser.Tables[0].Rows[0]["JOBNO"].ToString(), "I");
                        }
                        else if (COMPANY_ID == "861")
                        {
                            ICode_CS IC = new ICode_CS();
                            s = IC.Get_ICode_Jobno_Select(dtuser.Tables[0].Rows[0]["JOBNO"].ToString(), "I", "FF_Jobno", "", "861");
                        }
                        else
                        {
                            DataTable dtt = new DataTable();
                            s.Tables.Add(dtt);
                        }
                        if (s.Tables[0].Rows.Count > 0)
                        {
                            txt_FF_Jobno.Text = s.Tables[0].Rows[0]["FF_REF_NO"].ToString();
                        }

                        //added by jayanthi on 11-feb-2021
                        if ((COMPANY_ID == "752" || COMPANY_ID == "2814" || COMPANY_ID == "3082" || COMPANY_ID == "3253") && dtuser.Tables.Count > 1)
                        {
                            if (dtuser.Tables[1].Rows.Count > 0)
                            {
                                txt_FF_Jobno.Text = dtuser.Tables[1].Rows[0]["RYAL_REF_NO"].ToString();
                            }
                        }

                        //added by jayanthi on 11-feb-2021
                    }
                    else
                    {
                        txt_FF_Jobno.Visible = false;
                        txt_FF_Jobno.Text = string.Empty;
                    }

                    if (Session["JOB_LOCK"] != null && Session["JOB_LOCK"] != "")
                    {
                        if (Convert.ToInt32(JOB_LOCK) == 1)
                        {
                            btnUpdate.Enabled = false;
                            btnDelete.Enabled = false;

                            hd_joblck.Value = "Yes";

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
                                if (JOB_RELEASE == "No")
                                {
                                    job_release.Visible = false;
                                    btnUpdate.Enabled = false;
                                    btnDelete.Enabled = false;
                                    hd_joblck.Value = "Yes";
                                    MP_U.Show();
                                    lblUser_Msg.Text = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                                    btnUpdate.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                                    btnDelete.ToolTip = "Job used by " + Session["JOB_USER"].ToString().ToUpper() + " cannot modify";
                                }
                                else
                                {
                                    job_release.Visible = false;
                                }
                            }
                            else
                            {
                                job_release.Visible = false;
                            }
                        }
                        else
                        {
                            if (JOB_RELEASE == "Yes")
                            {
                                job_release.Visible = false;
                            }
                            else
                            {
                                job_release.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        job_release.Visible = false;
                    }

                    ddlContainer_Type.SelectedValue = dtuser.Tables[0].Rows[0]["CONTAINER_TYPE"].ToString();
                    hdn_ConType_excel.Value = dtuser.Tables[0].Rows[0]["CONTAINER_TYPE"].ToString(); // YG


                    txtParty_RefNo.Text = dtuser.Tables[0].Rows[0]["PARTY_REF_NO"].ToString();
                    txt_ETA_Date.Text = dtuser.Tables[0].Rows[0]["ETA"].ToString();

                    // start added by jayanthi on 19-Mar-22
                    if (dtuser.Tables[0].Rows[0]["FRT_JOBNO"].ToString() != null)
                    {
                        ddlFreightJobs.SelectedValue = dtuser.Tables[0].Rows[0]["FRT_JOBNO"].ToString();
                        Session["FRT_IMP_JOBNO_CHA"] = ddlFreightJobs.SelectedValue.ToString();
                    }
                    if (dtuser.Tables[0].Rows[0]["FRT_GROUPID"].ToString() != null)
                    {
                        hdn_FRT_GroupID.Value = dtuser.Tables[0].Rows[0]["FRT_GROUPID"].ToString();
                    }
                    if (dtuser.Tables[0].Rows[0]["FRT_BRANCHCODE"].ToString() != null)
                    {
                        hdn_FRT_Branch.Value = dtuser.Tables[0].Rows[0]["FRT_BRANCHCODE"].ToString();
                    }
                    // end  added by jayanthi on 19-Mar-22


                    //--------------CAPRICORN - MULTIPLE CHA NO-Load - 19-01-2024 --------------------
                    ddl_Multiple_CHA_No.SelectedValue = dtuser.Tables[0].Rows[0]["ICE_ID"].ToString() + "-" + dtuser.Tables[0].Rows[0]["CHA_NO"].ToString();

                    //--------------------------------------------------------------------------------

                    ViewState["UPDATED_ID"] = null;
                    ViewState["UPDATED_ID"] = Request.QueryString["JOBID"].ToString();
                    Session.Remove("TRANSPORT_MODE");
                    Session.Remove("IMPORT_JOBNO");
                    Session.Remove("IMPORT_JOBDATE");
                    Session.Remove("FILING_STATUS");
                    Session.Remove("COUNTRY_OF_ORIGIN");
                    Session.Remove("IMPORTER_NAME");
                    Session.Remove("ICENO");
                    Session.Remove("Multiple_ICE_ID");
                    Session.Remove("BRANCH_NO");
                    Session.Remove("BE_TYPE");
                    Session.Remove("Jobno_OpenStatus");
                    Session.Remove("CONT_TYPE");
                    Session.Remove("SUP_Master_Job_New");
                    Session.Remove("SUP_Master_Job_edit");
                    Session.Remove("JOBNO_PS");

                    Session["TRANSPORT_MODE"] = ddlTransportMode.SelectedValue.ToString();
                    Session["IMPORT_JOBNO"] = txtJobNo.Text;
                    Session["IMPORTER_NAME"] = txtImporterName.Text;
                    Session["ICENO"] = txtIECNo.Text;
                    Session["BRANCH_NO"] = txtBranchNo.Text;
                    Session["JOBNO_PS"] = txtjobps.Text;

                    Session["IMPORT_JOBDATE"] = txtJobDate.Text;
                    Session["FILING_STATUS"] = ddlFilingStatus.SelectedValue.ToString();
                    Session["COUNTRY_OF_ORIGIN"] = txtCountryName.Text;
                    Session.Remove("Warehouse_Exbond_JobNo");
                    Session["Multiple_ICE_ID"] = dtuser.Tables[0].Rows[0]["ICE_ID"].ToString();
                    Session["BE_TYPE"] = ddlBEType.SelectedValue.ToString();
                    Session["Jobno_OpenStatus"] = txtJobNo.Text;
                    Session["CONT_TYPE"] = ddlContainer_Type.SelectedValue.ToString();

                    Session.Remove("TRANSPORT_MODE_NEW");
                    Session.Remove("IMP_Job_CUSTOMHOUSE_CODE");
                    Session.Remove("PORT_ORIGIN");
                    Session.Remove("PORT_SHIPMENT");

                    //Session["TRANSPORT_MODE_NEW"] = dtuser.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();//For Transport mode Manual changing purpose Pandiyan 20Mar2025
                    //Session["IMP_Job_CUSTOMHOUSE_CODE"] = dtuser.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                    //Session["PORT_ORIGIN"] = dt.Replace(dtuser.Tables[0].Rows[0]["PORT_ORIGIN"].ToString());
                    //Session["PORT_SHIPMENT"] = dt.Replace(dtuser.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString());

                    HttpContext.Current.Session["TRANSPORT_MODE_NEW"] = dtuser.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();//For Transport mode Manual changing purpose Pandiyan 20Mar2025
                    HttpContext.Current.Session["IMP_Job_CUSTOMHOUSE_CODE"] = dtuser.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                    HttpContext.Current.Session["PORT_ORIGIN"] = dt.Replace(dtuser.Tables[0].Rows[0]["PORT_ORIGIN"].ToString());
                    HttpContext.Current.Session["PORT_SHIPMENT"] = dt.Replace(dtuser.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString());


                    Elogix_Chennai_Ref_Service("");

                    //-------- FAIRMACS - Customs Duty Report - Status show - by Chithra on 18-06-2022-----------
                    if (Connection.COMPANYID() == "10" || Connection.COMPANYID() == "151")
                    {
                        int rpt = Chk_CustomsDuty_rpt_Status_FAIRMACS(txt_jobno.Text);

                        if (rpt == 1)
                        {
                            lbl_status_FAIRMACS.Visible = true;
                        }
                    }
                    //-------------------------------------------------------------------------------------------
                }

                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;

                btnsavenext.Visible = false;

                //------------------Audit Modified column History-------------------
                if (Audit_YN == "Y")
                {
                    Tbl_Filed_Modified_History(dtuser.Tables[1]);
                }
                //-----------------------------------------------------------------

                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Update_excelValues()", true);

            }
            else
            {
                if (!IsPostBack)
                {
                    //-------------Dont delete----------------------------
                    //btnSave.Attributes.Add("onclick", "return validate();");
                    //btnNew.Attributes.Add("onclick", "jQuery('#form1').validationEngine('detach');");
                    //btnUpdate.Attributes.Add("onclick", "return validate();");
                    //-----------------------------------------------------
                    AUTO_JOBNO();
                    Create_Session_WareHouse_Exbond();
                    hdfTransport_mode.Value = ddlTransportMode.SelectedValue.ToString();
                    Session["Transport_Mode_Port"] = ddlTransportMode.SelectedValue.ToString();


                    if (Connection.COMPANYID() == "10" || Connection.COMPANYID() == "480" || Connection.COMPANYID() == "747")
                    {
                        hdn_CountryCD_PortOrigin_chk.Value = "Yes";
                        hdn_CountryCD_PortofShipment_chk.Value = "Yes";

                        if (ddlTransportMode.SelectedItem.Text == "Sea" || ddlTransportMode.SelectedItem.Text == "Land")
                        {
                            txtPortOrigin.Attributes.Add("onblur", "javascript:CallServerside_Port_Country_Origin('" + txtCountryShipment.ClientID + "', '" + txtPortOrigin.ClientID + "')");
                            txtPortOrigin.Attributes.Add("onkeyup", "javascript:CallServerside_Port_Country_Origin('" + txtCountryShipment.ClientID + "', '" + txtPortOrigin.ClientID + "')");
                            txtPortOrigin.Attributes.Add("onfocus", "javascript:CallServerside_Port_Country_Origin('" + txtCountryShipment.ClientID + "', '" + txtPortOrigin.ClientID + "')");

                            txtPortShipment.Attributes.Add("onblur", "javascript:CallServerside_Port_Country_Shipment('" + txtCountryShipment.ClientID + "', '" + txtPortShipment.ClientID + "')");
                            txtPortShipment.Attributes.Add("onkeyup", "javascript:CallServerside_Port_Country_Shipment('" + txtCountryShipment.ClientID + "', '" + txtPortShipment.ClientID + "')");
                            txtPortShipment.Attributes.Add("onfocus", "javascript:CallServerside_Port_Country_Shipment('" + txtCountryShipment.ClientID + "', '" + txtPortShipment.ClientID + "')");

                        }
                    }

                    ddlBEType.Items.Clear();
                    ddlBEType.Items.Add("Home");
                    ddlBEType.Items.Add("Warehouse");
                    ddlBEType.Items.Add("Ex-Bond");

                    Load_BE_Type();

                    ddlFilingStatus.Items.Clear();
                    ddlFilingStatus.Items.Add("Normal");
                    ddlFilingStatus.Items.Add("Prior");
                    ddlFilingStatus.Items.Add("Advanced");
                    ddlCommercial_Tax_yn.Items.Clear();
                    //ddlCommercial_Tax_yn.Items.Add("N");
                    ddlCommercial_Tax_yn.Items.Add("Y");

                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                    btnsavenext.Visible = true;

                    hdn_Jobno.Value = "";

                    Session.Remove("TRANSPORT_MODE");
                    Session.Remove("IMPORT_JOBNO");
                    Session.Remove("IMPORT_JOBDATE");
                    Session.Remove("FILING_STATUS");
                    Session.Remove("COUNTRY_OF_ORIGIN");
                    Session.Remove("Jobno_OpenStatus");
                    Session.Remove("CONT_TYPE");
                    Session.Remove("SUP_Master_Job_New");
                    Session.Remove("SUP_Master_Job_edit");
                    Session.Remove("JOBNO_PS");

                    //Session.Remove("IMPORTER_NAME");
                    Session["commercialYN"] = "N";
                    Session["BE_TYPE"] = ddlBEType.SelectedValue.ToString();
                    Session["Jobno_OpenStatus"] = txtJobNo.Text;
                    Session["JOBNO_PS"] = txtjobps.Text;
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void Show_BEtype(string BE_type)
    {
        try
        {
            if (BE_type == "Home")
            {
                tag.Style.Add("display", "none");
                lnkbtn_Exbond.Style.Add("display", "none");
            }
            else if (BE_type == "Warehouse")
            {
                tag.Style.Add("display", "none");
                lnkbtn_Exbond.Style.Add("display", "none");
            }
            else if (BE_type == "Ex-Bond" || BE_type == "SEZ DTA-T" || BE_type == "SEZ DTA-M" || BE_type == "Stock Item" || BE_type == "Movement of Goods")
            {
                tag.Style.Add("display", "none");
                lnkbtn_Exbond.Style.Add("display", "block");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
    }

    public int insert_update(string jobid, string flag)
    {
        try
        {
            CheckBox_YN();
            Transact.JOBID = jobid;
            Transact.JOBNO = txtJobNo.Text;
            Transact.JOBDATE = txtJobDate.Text;
            Transact.TRANSPORT_MODE = ddlTransportMode.SelectedValue.ToString();
            Transact.BE_TYPE = ddlBEType.SelectedValue.ToString();
            Session["BE_TYPE"] = ddlBEType.SelectedValue.ToString();
            if (txtCustomsHouse.Text != "")
            {
                if (txtCustomsHouse.Text.Contains("-"))
                {
                    string[] s1 = txtCustomsHouse.Text.Split(new string[] { "-" }, StringSplitOptions.None);

                    //Transact.CUSTOMS_HOUSE = s1[0].ToString();
                    Transact.CUSTOMS_HOUSE = s1[1].ToString();
                    //Transact.CUSTOMS_HOUSE = txtCustomsHouse.Text.ToUpper();
                    Transact.CUSTOMS_HOUSE_NAME = hdn_CustomsHouse_Name.Value;
                    hdn_Customhouse_chk.Value = Set_Customs_House_Validation(s1[1].ToString());
                }
                else
                {
                    Transact.CUSTOMS_HOUSE = txtCustomsHouse.Text.ToUpper();
                    Transact.CUSTOMS_HOUSE_NAME = hdn_CustomsHouse_Name.Value;
                    hdn_Customhouse_chk.Value = Set_Customs_House_Validation(txtCustomsHouse.Text);
                }
            }

            Transact.IMPORTER_NAME = txtImporterName.Text;
            Transact.ADDRESS1 = txtAddress1.Text;
            Transact.ADDRESS2 = txtAddress2.Text;
            Transact.ADDRESS3 = txtAddress3.Text;
            Transact.ADDRESS4 = txtAddress4.Text;
            Transact.ADDRESS5 = txtAddress5.Text;
            Transact.IEC_NO = txtIECNo.Text;
            Transact.BRANCH_NO = txtBranchNo.Text;
            Transact.COUNTRY_ORIGIN = txtCountryName.Text;
            Transact.PORT_ORIGIN = txtPortOrigin.Text;

            Transact.PORT_SHIPMENT = txtPortShipment.Text;
            Transact.COUNTRY_SHIPMENT = txtCountryShipment.Text;
            Transact.FILING_STATUS = ddlFilingStatus.SelectedValue.ToString();
            Transact.SECTION46 = chksec46.Value;

            Transact.SECTION46_DESC = txtSection46Desc.Text;
            Transact.FIRSTCHECK = chkFirCheck.Value;
            Transact.FIRSTCHECK_DESC = txtFirstCheckDesc.Text;
            Transact.GREEN_CHANNEL = chkGrnChannel.Value;
            Transact.GREEN_CHANNEL_DESC = txtGreenChannelDesc.Text;
            Transact.KACHHA_BE = chkKach.Value;
            Transact.KACHHA_BE_DESC = txtKachhaDesc.Text;
            Transact.SECTION48 = chkSec48.Value;
            Transact.SECTION48_DESC = txtSection48Desc.Text;
            Transact.HIGH_SEA_SALE = chkHghSeaSale.Value;
            Transact.HIGH_SEA_SALE_NAME = txtSellerName.Text;
            Transact.HIGH_SEA_IEC = txtHighSeaSaleIECNo.Text;
            Transact.HIGH_SEA_BRANCH_SL_NO = txtBranchSLNo.Text;
            Transact.HSS_ADD1 = txtHighSeaSaleAddress.Text;
            Transact.HSS_ADD2 = txtHighSeaSaleAddress1.Text;
            Transact.HSS_ADD3 = txtHighSeaSaleAddress2.Text;
            Transact.HSS_ADD4 = txtHighSeaSaleAddress3.Text;
            Transact.HSS_ADD5 = txtHighSeaSaleAddress4.Text;
            Transact.HSS_ADCODE = txtHSS_AdCode.Text;
            Transact.WAREHOUSE_NAME = "No";
            Transact.WAREHOUSE_CODE = txtWarehouseCode.Text.ToUpper();
            Transact.COMMERCIAL_DETAILS_STATUS = "Y";
            Transact.COMMERCIAL_TAX_STATENAME = txtCommercial_StateName.Text;
            Transact.COMMERCIAL_TAX_STATECODE = txtCommercial_StateCode.Text;
            Transact.COMMERCIAL_TAX_TYPE = ddl_Commercial_Type.SelectedItem.Text;
            Transact.COMMERCIAL_TAX_REGISTRATION_NO = txtCommercial_RegistrationNo.Text;


            Transact.EXBOND_INBOND_BE_DATE = "01/01/1900";
            Transact.EXBOND_BOND_DATE = "01/01/1900";

            //************************* DON'T DELETE - ITS FOR EXBOND DETAILS UPDATE ********************** 
            //string Exbond_BEDate = "", Exbond_BondDate = "";
            //if (hdn_Exbond_BEDate.Value != "")
            //{
            //    Exbond_BEDate = hdn_Exbond_BEDate.Value;

            //}
            //else
            //{
            //    Exbond_BEDate = "01/01/1900";
            //}
            //if (hdn_Exbond_BondDate.Value != "")
            //{
            //    Exbond_BondDate = hdn_Exbond_BondDate.Value;

            //}
            //else
            //{
            //    Exbond_BondDate = "01/01/1900";
            //}
            //Transact.EXBOND_INBOND_BE_NO = hdn_Exbond_BENo.Value;
            //Transact.EXBOND_BOND_NO = hdn_Exbond_BondNo.Value;
            //Transact.EXBOND_WAREHOUSE_CUSTOMS = hdn_Exbond_Warehouse_Customs.Value;
            //Transact.EXBOND_WAREHOUSE_CUSTOMS_CODE = hdn_Exbond_Warehouse_Code.Value;
            //Transact.EXBOND_NOOFPACKAGE = hdn_Exbond_NoofPackages.Value;
            //Transact.EXBOND_NOOFPACKAGE_UNITCODE = hdn_Exbond_NoofPackages_Code.Value;
            //Transact.EXBOND_GROSS_WEIGHT = hdn_Exbond_Gross_Weight.Value;
            //Transact.EXBOND_GROSS_WEIGHT_UNITCODE = hdn_Exbond_Gross_Weight_Code.Value;
            //Transact.EXBOND_DIRECT_EXBONDING = hdn_Direct_Exbonding.Value;
            //***********************************************************************************************

            Transact.REMARKS = txtRemarks.Text;
            //Transact.IMP_EXP_TYPE = hdn_ImporterType.Value;
            if (ddlBEType.SelectedItem.Text == "SEZ DTA-T" || ddlBEType.SelectedItem.Text == "SEZ FTA-Z" || ddlBEType.SelectedItem.Text == "SEZ DTA-M" || ddlBEType.SelectedItem.Text == "Stock Item")
            {
                Transact.IMP_EXP_TYPE = ddlType.SelectedItem.Text;
                Session["IMP_EXP_TYPE"] = ddlType.SelectedItem.Text;
            }
            else
            {
                Transact.IMP_EXP_TYPE = hdn_ImporterType.Value;
                Session["IMP_EXP_TYPE"] = hdn_ImporterType.Value;//taken by pandiyan on 04/06/2025
            }

            Transact.USER_ID = currentuser;
            Transact.flag = flag;
            Transact.BRANCH_CODE = currentbranch;
            Transact.WORKING_PERIOD = Working_Period;
            Transact.FILE_REF_NO = txtFile_Ref_No.Text.ToUpper();
            Transact.CONTAINER_TYPE = ddlContainer_Type.SelectedValue.ToString();
            Transact.BRANCH_COMMON = SELECT_BRANCH;
            Transact.JOBNO_PS = txtjobps.Text;

            Transact.JOB_PREFIX = hdprefix.Value.ToString();
            Transact.JOB_SUFFIX = hdsuffix.Value.ToString();

            Transact.ADCODE = txt_ADCode.Text;
            Transact.UCR_TYPE = txt_UCR_Type.Text;
            Transact.UCR_NO = txt_UCR_Ref_No.Text;
            Transact.PAYMENT_METHOD_CODE = txt_Payment_Method.Text.ToUpper();
            Transact.PRECEDING_LEVEL = txt_PrecedingLevel.Text;
            Transact.GSTN_TYPE = ddl_GSTN_Type.SelectedValue.ToString();
            Transact.GSTN_ID = txt_GSTN_ID.Text;
            Transact.PARTY_REF_NO = txtParty_RefNo.Text.ToUpper();
            Transact.ETA = txt_ETA_Date.Text;

            Transact.AMENDMENT_TYPE = ddl_AmendmentType.SelectedValue;
            Transact.AMENDMENT_STATUS = "";
            //hdn_Customhouse_chk.Value = Set_Customs_House_Validation(txtCustomsHouse.Text);

            // *********** start aded to link Freight jobs **************//
            Transact.FRT_JOBNO = "";
            if (ddlFreightJobs.SelectedIndex > 0)
            {
                Transact.FRT_JOBNO = ddlFreightJobs.SelectedValue.ToString();
                Transact.FRT_BRANCHCODE = hdn_FRT_Branch.Value;
                Transact.FRT_GROUPID = hdn_FRT_GroupID.Value;
            }
            // *********** start aded to link Freight jobs **************//

            if (ddl_MultipleIcegate_YN == "Y")
            {
                if (ddl_Multiple_CHA_No.SelectedItem.Text != "")
                {
                    string[] splt = ddl_Multiple_CHA_No.SelectedItem.Text.Split('-');

                    Transact.ICE_ID = splt[0];
                    Transact.CHA_NO = splt[1];
                    Session.Remove("Multiple_ICE_ID");
                    Session["Multiple_ICE_ID"] = splt[0];
                }
            }
            else
            {
                Transact.ICE_ID = "";
                Transact.CHA_NO = "";
            }


            Transact.PROVISIONAL = chkProv.Value;
            Transact.PROVISIONAL_DESC = txtProvisionalDesc.Text;

            i = Transact.General_details_insertupdate();
            if (i == 1)
            {

                Transact.Imp_Job_Logs_All_Details(txtJobNo.Text, "", "", "General", flag, "Insert");

                Show_BEtype(ddlBEType.SelectedValue.ToString());

                if (COMPANY_ID == "10" || COMPANY_ID == "2145" || COMPANY_ID == "3267" || COMPANY_ID == "4004")
                {
                    DateTime opentime = DateTime.Now;
                    DateTime closingtime = opentime.AddMinutes(15);

                    DataSet ds_User_st = new DataSet();
                    ds_User_st = Common_CS.Get_Job_User_Lock_Status(txtJobNo.Text, currentuser, Convert.ToString(opentime), Convert.ToString(closingtime), "Insert_User_History", "Import");
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }

        return i;
    }

    public void Create_Session_WareHouse_Exbond()
    {
        try
        {
            Session.Remove("Warehouse_Exbond_JobNo");
            Session["Warehouse_Exbond_JobNo"] = txtJobNo.Text;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
    }
    public void AUTO_JOBNO()
    {
        try
        {
            Transact.BRANCH_CODE = SELECT_BRANCH;
            Transact.WORKING_PERIOD = Working_Period;
            txtJobNo.Text = Convert.ToString(Transact.RetrieveID());

            //if (COMPANY_ID == "10" || COMPANY_ID == "11" || COMPANY_ID == "2373")// for "Areawise Job" Only
            //{
            //    JobNo_Prefix_Sufix("TrMode_Change");
            //}
            //else
            //{
            //    JobNo_Prefix_Sufix("New");
            //}

            JobNo_Prefix_Sufix();
            Session["Jobno_Excel"] = txtJobNo.Text;

            if (COMPANY_ID == "1011")
            {
                txtFile_Ref_No.Text = txtjobps.Text;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
    }

    public void JobNo_Prefix_Sufix()
    {
        try
        {
            Admin_job_Prefix_Suffix JPS = new Admin_job_Prefix_Suffix();
            DataSet dats = new DataSet();

            if (COMPANY_ID == "293")
            {
                JPS.Branch = Connection.Current_Branch();
                JPS.Ename = "Imp_Exp_gen_293_select";
                JPS.BranchType = "I";
            }
            else if (COMPANY_ID == "2349")
            {
                JPS.Branch = Connection.Current_Branch();
                JPS.Ename = "Imp_Exp_gen_2349_select";
                JPS.BranchType = "I";
            }
            else
            {
                JPS.Branch = SELECT_BRANCH;
                JPS.Ename = "Imp_gen_select";
                JPS.BranchType = SELECT_TYPE;
            }
            JPS.Tr_mode = ddlTransportMode.SelectedItem.Text;
            dats = JPS.Job_prefix_Suffix_Select_Areawise();

            int Jno = 0;
            string JobNo = string.Empty;
            JobNo = txtJobNo.Text;

            if (JobNo != string.Empty)
            {
                Jno = Convert.ToInt32(JobNo);
                if (Jno < 1000)
                {
                    if (Jno > 100)
                    {
                        JobNo = "00" + txtJobNo.Text;
                    }
                    else if (Jno > 10)
                    {
                        JobNo = "000" + txtJobNo.Text;
                    }
                    else
                    {
                        JobNo = "0000" + txtJobNo.Text;
                    }
                }
            }

            if (Session["COMPANY_LICENSE"] != null)
            {
                if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00247")
                {
                    if (dats.Tables[0].Rows.Count > 0)
                    {
                        if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                        {
                            txtjobps.Text = txtJobNo.Text + "/" + ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                            hdprefix.Value = string.Empty;
                            hdsuffix.Value = ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                        }
                        else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                        {
                            txtjobps.Text = ((dats.Tables[0].Rows[0][0].ToString() + txtJobNo.Text).TrimEnd()).TrimStart();
                            hdprefix.Value = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                            hdsuffix.Value = string.Empty;
                        }
                        else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                        {
                            txtjobps.Text = ((dats.Tables[0].Rows[0][0].ToString() + txtJobNo.Text + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                            hdprefix.Value = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                            hdsuffix.Value = ((dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                        }
                        else if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                        {
                            txtjobps.Text = txtJobNo.Text;
                            hdprefix.Value = string.Empty;
                            hdsuffix.Value = string.Empty;
                        }
                    }
                    else
                    {
                        txtjobps.Text = txtJobNo.Text;
                        hdprefix.Value = string.Empty;
                        hdsuffix.Value = string.Empty;
                    }
                }
                else
                {
                    if (dats.Tables[0].Rows.Count > 0)
                    {
                        if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                        {
                            txtjobps.Text = txtJobNo.Text + "/" + ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                            hdprefix.Value = string.Empty;
                            hdsuffix.Value = ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                        }
                        else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                        {
                            // txtjobps.Text = ((dats.Tables[0].Rows[0][0].ToString() + "/" + txtJobNo.Text).TrimEnd()).TrimStart();
                            if (Connection.COMPANYID() == "1163" || Connection.COMPANYID() == "1164" || Connection.COMPANYID() == "1165" || Connection.COMPANYID() == "1166")
                            {
                                txtjobps.Text = ((dats.Tables[0].Rows[0][0].ToString() + "/" + JobNo).TrimEnd()).TrimStart();
                            }
                            else
                            {
                                txtjobps.Text = ((dats.Tables[0].Rows[0][0].ToString() + "/" + txtJobNo.Text).TrimEnd()).TrimStart();
                            }

                            hdprefix.Value = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                            hdsuffix.Value = string.Empty;
                        }
                        else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                        {
                            //txtjobps.Text = ((dats.Tables[0].Rows[0][0].ToString() + "/" + txtJobNo.Text + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();

                            if (Connection.COMPANYID() == "1163" || Connection.COMPANYID() == "1164" || Connection.COMPANYID() == "1165" || Connection.COMPANYID() == "1166")
                            {
                                txtjobps.Text = ((dats.Tables[0].Rows[0][0].ToString() + "/" + JobNo + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                            }
                            else
                            {
                                txtjobps.Text = ((dats.Tables[0].Rows[0][0].ToString() + "/" + txtJobNo.Text + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                            }
                            hdprefix.Value = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                            hdsuffix.Value = ((dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                        }
                        else if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                        {
                            txtjobps.Text = txtJobNo.Text;
                            hdprefix.Value = string.Empty;
                            hdsuffix.Value = string.Empty;
                        }
                    }
                    else
                    {
                        txtjobps.Text = txtJobNo.Text;
                        hdprefix.Value = string.Empty;
                        hdsuffix.Value = string.Empty;
                    }
                }
                Session["JOBNO_PS"] = txtjobps.Text;
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
            F.Visible = true;
            S.Visible = false;
            btnnew1.Visible = true;
            btn_Masedit.Visible = false;

            btnedit.Visible = false;
            btn_Tr_Mode_Change.Visible = false;

            hdn_Jobno.Value = "";
            txtid.Text = string.Empty;
            Session.Remove("TRANSPORT_MODE");
            Session.Remove("IMPORT_JOBNO");
            Session.Remove("IMPORT_JOBDATE");
            Session.Remove("FILING_STATUS");
            Session.Remove("COUNTRY_OF_ORIGIN");
            Session.Remove("IMPORTER_NAME");
            Session.Remove("Multiple_ICE_ID");
            Session.Remove("CONT_TYPE");
            Session.Remove("SUP_Master_Job_New");
            Session.Remove("SUP_Master_Job_edit");
            Session.Remove("JOBNO_PS");

            Transact.ResetFields(Page.Controls);
            Page_enable();
            txtJobDate.Text = dt.Today_Date();
            AUTO_JOBNO();
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Enabled = true;

            btnsavenext.Visible = true;
            btnsavenext.Enabled = true;

            ViewState["UPDATED_ID"] = null;
            hdn_Update_General.Value = "";


            txt_Payment_Method.Text = "T";
            //-------------------------------FROM LOGIN PAGE BASED ON BRANCH SELECT-----------------//

            string TRANS_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();
            string Category_mode = "";
            if (TRANS_MODE == "A")
                Category_mode = "Air";
            if (TRANS_MODE == "S")
                Category_mode = "Sea";
            if (TRANS_MODE == "L")
                Category_mode = "Land";

            ddlTransportMode.SelectedValue = Category_mode;

            txtCustomsHouse.Text = Session["CUSTOMHOUSE_CODE"].ToString();
            Create_Session_WareHouse_Exbond();

            hd_joblck.Value = "No";

            //ddlTransportMode.Attributes.Remove("readonly");
            ddlTransportMode.Enabled = true;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }

    }
    public void Check_Box_Enable_Disable()
    {
        try
        {
            //Check Sec
            if (chksec46.Value == "Y")
            {
                txtSection46Desc.Enabled = true;
            }
            else
            {
                txtSection46Desc.Enabled = false;
            }
            //First Check
            if (chkFirCheck.Value == "Y")
            {
                txtFirstCheckDesc.Enabled = true;
            }
            else
            {
                txtFirstCheckDesc.Enabled = false;
            }
            //Green Channel
            if (chkGrnChannel.Value == "Y")
            {
                txtGreenChannelDesc.Enabled = true;
            }
            else
            {
                txtGreenChannelDesc.Enabled = false;
            }
            //Kachha
            if (chkKach.Value == "Y")
            {
                txtKachhaDesc.Enabled = true;
            }
            else
            {
                txtKachhaDesc.Enabled = false;
            }
            //Sec48
            if (chkSec48.Value == "Y")
            {
                txtSection48Desc.Enabled = true;
            }
            else
            {
                txtSection48Desc.Enabled = false;
            }
            //Provisional
            if (chkProv.Value == "Y")
            {
                txtProvisionalDesc.Enabled = true;
            }
            else
            {
                txtProvisionalDesc.Enabled = false;
            }

            //HSS Details
            if (chkHghSeaSale.Value == "Y")
            {
                txtSellerName.Enabled = true;
                txtHighSeaSaleIECNo.Enabled = true;
                txtBranchSLNo.Enabled = true;
                txtHighSeaSaleAddress.Enabled = true;
                txtHighSeaSaleAddress1.Enabled = true;
                txtHighSeaSaleAddress2.Enabled = true;
                txtHighSeaSaleAddress3.Enabled = true;
                txtHighSeaSaleAddress4.Enabled = true;
                txtHSS_AdCode.Enabled = true;
                txt_PrecedingLevel.Enabled = true;
            }
            else
            {
                txtSellerName.Enabled = false;
                txtHighSeaSaleIECNo.Enabled = false;
                txtBranchSLNo.Enabled = false;
                txtHighSeaSaleAddress.Enabled = false;
                txtHighSeaSaleAddress1.Enabled = false;
                txtHighSeaSaleAddress2.Enabled = false;
                txtHighSeaSaleAddress3.Enabled = false;
                txtHighSeaSaleAddress4.Enabled = false;
                txtHSS_AdCode.Enabled = false;
                txt_PrecedingLevel.Enabled = false;
            }
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
            if (txtJobNo.Text != "" && txtJobDate.Text != "")
            {
                try
                {
                    string f = "U";
                    i = insert_update(HiddenField1.Value, f);

                    if (i == 1)
                    {
                        hdn_Jobno.Value = "1";
                        txtJobNo.Focus();
                        Check_Box_Enable_Disable();
                        Session.Remove("TRANSPORT_MODE");
                        Session.Remove("IMPORT_JOBNO");
                        Session.Remove("IMPORT_JOBDATE");
                        Session.Remove("FILING_STATUS");
                        Session.Remove("COUNTRY_OF_ORIGIN");
                        Session.Remove("IMPORTER_NAME");
                        Session.Remove("ICENO");
                        Session.Remove("JOB_USER");
                        Session.Remove("BE_No");
                        Session.Remove("BRANCH_NO");
                        Session.Remove("CONT_TYPE");
                        Session.Remove("SUP_Master_Job_New");
                        Session.Remove("SUP_Master_Job_edit");
                        Session.Remove("JOBNO_PS");


                        Session["TRANSPORT_MODE"] = ddlTransportMode.SelectedValue.ToString();
                        Session["IMPORT_JOBNO"] = txtJobNo.Text;
                        Session["IMPORTER_NAME"] = txtImporterName.Text;
                        Session["ICENO"] = txtIECNo.Text;
                        Session["IMPORT_JOBDATE"] = txtJobDate.Text;
                        Session["FILING_STATUS"] = ddlFilingStatus.SelectedValue.ToString();
                        Session["COUNTRY_OF_ORIGIN"] = txtCountryName.Text;
                        Session["JOB_USER"] = currentuser;
                        Session["BE_No"] = txtBE_No.Text;
                        Session["BRANCH_NO"] = txtBranchNo.Text;
                        Session["CONT_TYPE"] = ddlContainer_Type.SelectedValue.ToString();
                        Session["JOBNO_PS"] = txtjobps.Text;

                        /*
                         if (Connection.Ryal() != string.Empty)
                         {
                             string str = txt_FF_Jobno.Text;
                             Ryal_Service("U");
                         }
                         */
                        if (Connection.Freight_Forward() != string.Empty)
                        {
                            if (COMPANY_ID == "752" || COMPANY_ID == "2814" || COMPANY_ID == "3082" || COMPANY_ID == "3253")
                            {
                                string str = txt_FF_Jobno.Text;
                                Ryal_Service("U");
                            }
                            else if (COMPANY_ID == "861" || COMPANY_ID == "880")
                            {
                                ICode_CS IC = new ICode_CS();
                                IC.Get_ICode_Jobno_Select(txtJobNo.Text, "I", "CHA_Jobno_Update", txt_FF_Jobno.Text, COMPANY_ID);
                            }
                        }

                        Elogix_Service("U");


                        if (ViewState["UPDATED_ID"] != null)
                        {
                            if (Connection.COMPANYID() == "247")
                            {
                                if (chkKachha.Checked == true)
                                {
                                    Response.Write("<script>alert('Note : Kachcha BE Selected');</script>");
                                }
                            }

                            Alert_msg("Updated Successfully", "btnUpdate");
                        }
                        else
                        {
                            if (Connection.COMPANYID() == "247")
                            {
                                if (chkKachha.Checked == true)
                                {
                                    Response.Write("<script>alert('Note : Kachcha BE Selected');</script>");
                                }
                            }

                            Alert_msg("Saved Successfully", "btnUpdate");
                        }


                        // ----Audit Modified Data -----------------------------------
                        if (Audit_YN == "Y")
                        {
                            Audit_Modified_DataTableComparer();
                        }
                        //------------------------------------------------------------
                    }
                    else if (i == 3)
                    {
                        Alert_msg("File Ref. No Already Exist! Not Update", "btnUpdate");
                    }
                    else
                    {
                        hdn_Jobno.Value = "";
                        Alert_msg("Job Not Saved", "btnUpdate");
                    }
                    Page_enable();
                }
                catch (Exception ex)
                {
                    Connection.Error_Msg(ex.Message);
                }
            }
            else
            {
                Alert_msg("Enter All Mandatory Field");
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
            Transact.JOBNO = txtJobNo.Text;
            Transact.IMPORTER_NAME = "0";
            Transact.TRANSPORT_MODE = "0";
            Transact.CUSTOMS_HOUSE = "0";
            Transact.Ename = "delete";
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            //Transact.RetrieveAll_General_Details();

            ds = Transact.RetrieveAll_General_Details_datatablefrmDelJobs();

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() == "2")
                {
                    Elogix_Service("D");
                    /*
                    if (Connection.Ryal() != string.Empty)
                    {
                      Ryal_Service("D");
                    }
                    */
                    if (Connection.Freight_Forward() != string.Empty)
                    {
                        if (COMPANY_ID == "752" || COMPANY_ID == "2814" || COMPANY_ID == "3082" || COMPANY_ID == "3253")
                        {
                            Ryal_Service("D");
                        }
                        else if (COMPANY_ID == "861" || COMPANY_ID == "880")
                        {
                            ICode_CS IC = new ICode_CS();
                            IC.Get_ICode_Jobno_Select(txtJobNo.Text, "I", "CHA_Jobno_Delete", txt_FF_Jobno.Text, "861");
                        }
                    }
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Visible = true;
                    btnsavenext.Visible = true;
                    string prompt = "<script>$(document).ready(function(){{jAlert('Job Deleted', 'GENERAL', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);

                    OCR_Delete_Jobs(txtJobNo.Text);
                    Transact.Imp_Job_Logs_All_Details(Connection.IMP_Jobno(), "", "", "General", "D", "Insert");

                }
                else
                {
                    Alert_msg("Job Not Deleted");
                }
            }
            else
            {
                Alert_msg("Job Not Deleted");
            }
            Page_enable();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnAuto_Jobno_Click(object sender, EventArgs e)
    {
        try
        {
            AUTO_JOBNO();
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

            hd_Brslno.Value = "";
            hd_Brslno.Value = txtBranchNo.Text;
            if (txtJobNo.Text != "" && txtJobDate.Text != "")
            {
                try
                {
                    if (!Check_Mandatory_Fields())
                        return;


                    string id = "";
                    string f = "S";
                    i = insert_update(id, f);
                    HiddenField1.Value = Convert.ToString(Transact.UPDATE_ID);

                    if (i == 1)
                    {
                        hdn_Jobno.Value = "1";
                        Session.Remove("TRANSPORT_MODE");
                        Session.Remove("IMPORT_JOBNO");
                        Session.Remove("IMPORT_JOBDATE");
                        Session.Remove("FILING_STATUS");
                        Session.Remove("COUNTRY_OF_ORIGIN");
                        Session.Remove("IMPORTER_NAME");
                        Session.Remove("ICENO");
                        Session.Remove("JOB_USER");
                        Session.Remove("BRANCH_NO");
                        Session.Remove("CONT_TYPE");
                        Session.Remove("SUP_Master_Job_New");
                        Session.Remove("SUP_Master_Job_edit");
                        Session.Remove("JOBNO_PS");

                        Session["TRANSPORT_MODE"] = ddlTransportMode.SelectedValue.ToString();
                        Session["IMPORT_JOBNO"] = txtJobNo.Text;
                        Session["IMPORTER_NAME"] = txtImporterName.Text;
                        Session["ICENO"] = txtIECNo.Text;
                        Session["IMPORT_JOBDATE"] = txtJobDate.Text;
                        Session["FILING_STATUS"] = ddlFilingStatus.SelectedValue.ToString();
                        Session["COUNTRY_OF_ORIGIN"] = txtCountryName.Text;
                        Session["JOB_USER"] = currentuser;
                        Session["BRANCH_NO"] = txtBranchNo.Text;
                        Session["CONT_TYPE"] = ddlContainer_Type.SelectedValue.ToString();
                        Session["JOBNO_PS"] = txtjobps.Text;

                        txtJobNo.Focus();
                        //-----------------------Webservie Data--------------------------------//
                        /*if (Connection.Ryal() != string.Empty)
                        {
                            Ryal_Service("S");
                        }*/

                        //-----------------------Webservie Data--------------------------------//
                        if (Connection.Freight_Forward() != string.Empty)
                        {
                            if (COMPANY_ID == "752" || COMPANY_ID == "2814" || COMPANY_ID == "3082" || COMPANY_ID == "3253")
                            {
                                Ryal_Service("S");
                            }
                            else if (COMPANY_ID == "861" || COMPANY_ID == "880")
                            {
                                ICode_CS IC = new ICode_CS();
                                IC.Get_ICode_Jobno_Select(txtJobNo.Text, "I", "CHA_Jobno_Update", txt_FF_Jobno.Text, COMPANY_ID);
                            }

                        }
                        if (COMPANY_ID == "115" || COMPANY_ID == "3288")  // Added by pandiyan for Copper Api Process 
                        {
                            API_Post_Data Gen = new API_Post_Data();
                            Gen.General_Details_API_Post(txtJobNo.Text, Connection.WorkingPeriod(), "I", "JSON", Connection.Current_Branch());
                        }
                        if (ddl_Ref_Type.SelectedValue.ToString() == "M")
                        {
                            Elogix_Chennai_Ref_Service("S");
                        }
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
                            btnsavenext.Visible = false;
                        }
                        //-----------------------FOR USER RIGHTS--------------------------------//
                        btnSave.Focus();

                        ViewState["UPDATED_ID"] = null;
                        Session["IMP_Job_CUSTOMHOUSE_CODE"] = txtCustomsHouse.Text;

                        if (Connection.COMPANYID() == "247")
                        {
                            if (chkKachha.Checked == true)
                            {
                                Response.Write("<script>alert('Note : Kachcha BE Selected');</script>");
                            }
                        }

                        Alert_msg_Save("Saved Successfully", "btnSave");
                        if (Session["USER_JOB_LOCK"].ToString() == "Yes")
                        {
                            job_release.Visible = true;
                        }
                        else
                        {
                            job_release.Visible = false;
                        }

                        txt_jobno.Text = txtJobNo.Text;
                        txt_M_jobps.Text = hdprefix.Value.ToString();
                        txt_M_jobsf.Text = hdsuffix.Value.ToString();
                        hd_joblck.Value = "No";
                        Load_jobedit_Visible();

                        ddlTransportMode.Enabled = false;
                        txtCustomsHouse.Enabled = false;
                    }
                    else if (i == 2)
                    {
                        hdn_Jobno.Value = "";
                        string prompt = "<script>$(document).ready(function(){{jAlert('Job No Already Exist!', 'GENERAL', function (r) {var i = r + 'ok';if (i == 'trueok'){document.getElementById('btnAuto_Jobno').click();} else {}});}});</script>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
                    }
                    else if (i == 3)
                    {
                        hdn_Jobno.Value = "";
                        Alert_msg("File Ref. No Already Exist! Not Saved", "btnSave");
                    }
                    else
                    {
                        hdn_Jobno.Value = "";
                        Alert_msg("Not Saved", "btnSave");
                    }

                    Page_enable();
                }
                catch (Exception ex)
                {
                    Connection.Error_Msg(ex.Message);
                }
            }
            else
            {
                Alert_msg("Enter All Mandatory Field");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
    }

    protected void btnsavenext_Click(object sender, EventArgs e)
    {
        try
        {
            btnSave_Click(sender, e);
            if (i == 1)
            {
                hdsaveandclose.Value = "Yes";
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
    }

    [System.Web.Services.WebMethod]
    public void Get_Commercial_Tax_Details()
    {
        try
        {
            adminmaster Admin_mas = new adminmaster();
            if (txtImporterName.Text != "" && txtBranchSLNo.Text != "" && txtAddress4.Text != "")
            {
                if (ddlCommercial_Tax_yn.SelectedItem.Text == "Y")
                {
                    Admin_mas.EState_id = "0";
                    Admin_mas.EState_code = "";
                    Admin_mas.EState_name = txtAddress4.Text;
                    Admin_mas.Ename = "select_con";

                    ds = Admin_mas.RetrieveAll_State_master();

                    hdn_Regn_no.Value = ds.Tables[0].Rows[0][""].ToString();
                }
                else
                {

                }

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public void CheckBox_YN()
    {
        try
        {
            if (chkSection46.Checked == true)
                chksec46.Value = "Y";
            else
                chksec46.Value = "N";

            if (chkFirstCheck.Checked == true)
                chkFirCheck.Value = "Y";
            else
                chkFirCheck.Value = "N";

            if (chkGreenChannel.Checked == true)
                chkGrnChannel.Value = "Y";
            else
                chkGrnChannel.Value = "N";

            if (chkKachha.Checked == true)
                chkKach.Value = "Y";
            else
                chkKach.Value = "N";

            if (chkSection48.Checked == true)
                chkSec48.Value = "Y";
            else
                chkSec48.Value = "N";

            if (chkProvisional.Checked == true)
                chkProv.Value = "Y";
            else
                chkProv.Value = "N";



            if (chkHighSeaSale.Checked == true)
                chkHghSeaSale.Value = "Y";
            else
                chkHghSeaSale.Value = "N";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }

    }
    public void Page_enable()
    {
        try
        {
            if (ddlTransportMode.SelectedValue != "")
            {
                Panel1.Enabled = true;
                txtCustomsHouse.Enabled = true;
            }
            else
            {
                Panel1.Enabled = false;
                txtCustomsHouse.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg_Save(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {Import_session('" + ddlTransportMode.SelectedValue.ToString() + "','" + txtJobNo.Text + "','" + txtJobDate.Text + "','" + ddlFilingStatus.SelectedValue.ToString() + "');document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    ///auto search
    ///
    [System.Web.Services.WebMethod]
    public static string GetCustom_House_Name(string custid)
    {
        string name = "";
        try
        {
            if (custid.Contains("-"))
            {
                string[] s1 = custid.Split(new string[] { "-" }, StringSplitOptions.None);
                custid = s1[1].ToString();
            }
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            string rows = "", custom_name;
            custid = Auto.Country_Master_FromClientSide_Calling(custid, name = "CUSTOM_HOUSE_MASTER_CUSTOM_NAME", rows = "CUSTOMHOUSE_NAME");
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return custid + "~~" + name;
    }

    [System.Web.Services.WebMethod]
    public static string GetImporter(string custid)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "IMP_EXP_MASTER_IMPORTER_SEARCH";
            Auto.Enamesearch = custid;

            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                string Address1 = ds.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
                string Address2 = ds.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
                string Address3 = ds.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
                string Address4 = ds.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
                string Address5 = ds.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();
                string IECNo = ds.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString();
                string BranchNo = ds.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();
                string IMP_EXP_TYPE = ds.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();
                custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address5 + "~~" + IECNo + "~~" + BranchNo + "~~" + IMP_EXP_TYPE;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return custid;
    }
    [System.Web.Services.WebMethod]
    public static string GetImporter_2(string custid, string custid_2, string Adcode, string Jobno, string SearchType)
    {
        try
        {
            Auto_Search Auto = new Auto_Search(); DataSet ds = new DataSet();
            DataSet dss = new DataSet();

            string STD_Type = "";
            string commercialYN = "";

            if (!string.IsNullOrEmpty(HttpContext.Current.Session["commercialYN"].ToString()))
            {
                commercialYN = HttpContext.Current.Session["commercialYN"].ToString();
            }

            if (HttpContext.Current.Session["STANDARD_TYPE"] != null)
            {
                STD_Type = HttpContext.Current.Session["STANDARD_TYPE"].ToString();

                if (STD_Type == "Non_STD")
                {
                    STD_Type = STD_Type;
                }
                else
                {
                    STD_Type = "";
                }
            }

            Auto.Ename = "IMP_EXP_MASTER_IMPORTER_SEARCH_Slno";
            Auto.Enamesearch = custid;
            Auto.NSearch = custid_2;
            Auto.STANDARD_TYPE = STD_Type;

            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH_STD_Type();
            if (ds.Tables[0].Rows.Count > 0)
            {

                string Address1 = ds.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
                string Address2 = ds.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
                string Address3 = ds.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
                string Address4 = ds.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
                string Address5 = ds.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();
                string IECNo = ds.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString();
                string BranchNo = ds.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();
                string IMP_EXP_TYPE = ds.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();
                string TIN_NO = ds.Tables[0].Rows[0]["TIN_NO"].ToString();
                string STATECODE = ds.Tables[0].Rows[0]["STATE_CODE"].ToString();
                string ADCODE_IEC_ADCODE = "";

                string M_COMMERCIAL_DETAILS_STATUS = ds.Tables[0].Rows[0]["M_COMMERCIAL_DETAILS_STATUS"].ToString();
                string M_COMMERCIAL_TAX_STATENAME = ds.Tables[0].Rows[0]["M_COMMERCIAL_TAX_STATENAME"].ToString();
                string M_COMMERCIAL_TAX_STATECODE = ds.Tables[0].Rows[0]["M_COMMERCIAL_TAX_STATECODE"].ToString();
                string M_COMMERCIAL_TAX_TYPE = ds.Tables[0].Rows[0]["M_COMMERCIAL_TAX_TYPE"].ToString();
                string M_COMMERCIAL_TAX_REGISTRATION_NO = ds.Tables[0].Rows[0]["M_COMMERCIAL_TAX_REGISTRATION_NO"].ToString();
                string GSTN_TYPE = ds.Tables[0].Rows[0]["GSTN_TYPE"].ToString();
                string GSTN_ID = ds.Tables[0].Rows[0]["GSTN_ID"].ToString();
                string WAREHOUSE_CODE = ds.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
                string PAYMENT_METHOD_CODE = ds.Tables[0].Rows[0]["PAYMENT_METHOD_CODE"].ToString();

                if (Adcode == "Update")
                {
                    Auto.JobID = "";
                    Auto.Jobno = Jobno;
                    Auto.STANDARD_TYPE = STD_Type;
                    Auto.Ename = "Select_Adcode_from_ImportJob";
                    Auto.Enamesearch = custid;
                    Auto.NSearch = custid_2;
                    Auto.Working_Period = Connection.Get_Company_Type();
                    ds = Auto.ERoyalmaste_Retrieve_ADCode_Export();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (custid == ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString() && SearchType == "Importer")
                        {
                            ADCODE_IEC_ADCODE = ds.Tables[0].Rows[0]["ADCODE"].ToString();
                        }
                        else if (custid == ds.Tables[0].Rows[0]["HIGH_SEA_SALE_NAME"].ToString() && SearchType == "Highseasale")
                        {
                            ADCODE_IEC_ADCODE = ds.Tables[0].Rows[0]["HSS_ADCODE"].ToString();
                        }
                        else
                        {
                            if (IECNo != "")
                            {
                                Auto.Ename = "ADCODE_MASTER_SEARCH_branch_slno_wise";
                                Auto.Enamesearch = BranchNo;
                                Auto.NSearch = IECNo;
                                dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

                                if (dss.Tables[0].Rows.Count == 0)
                                {
                                    Auto.Ename = "ADCODE_MASTER_SEARCH_branch_slno_wise";
                                    Auto.Enamesearch = "";
                                    Auto.NSearch = IECNo;
                                    dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                                }


                                if (dss.Tables[0].Rows.Count > 0)
                                {
                                    if (dss.Tables[0].Rows.Count == 1)
                                    {
                                        if (dss.Tables[0].Rows[0]["IMPORT_ADCODE"].ToString() != "")
                                        {
                                            ADCODE_IEC_ADCODE = dss.Tables[0].Rows[0]["IMPORT_ADCODE"].ToString();
                                        }
                                        else
                                        {
                                            ADCODE_IEC_ADCODE = dss.Tables[0].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (IECNo != "")
                        {
                            Auto.Ename = "ADCODE_MASTER_SEARCH_branch_slno_wise";
                            Auto.Enamesearch = BranchNo;
                            Auto.NSearch = IECNo;
                            dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

                            if (dss.Tables[0].Rows.Count == 0)
                            {
                                Auto.Ename = "ADCODE_MASTER_SEARCH_branch_slno_wise";
                                Auto.Enamesearch = "";
                                Auto.NSearch = IECNo;
                                dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                            }


                            if (dss.Tables[0].Rows.Count > 0)
                            {
                                if (dss.Tables[0].Rows.Count == 1)
                                {
                                    if (dss.Tables[0].Rows[0]["IMPORT_ADCODE"].ToString() != "")
                                    {
                                        ADCODE_IEC_ADCODE = dss.Tables[0].Rows[0]["IMPORT_ADCODE"].ToString();
                                    }
                                    else
                                    {
                                        ADCODE_IEC_ADCODE = dss.Tables[0].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (IECNo != "")
                    {
                        Auto.Ename = "ADCODE_MASTER_SEARCH_branch_slno_wise";
                        Auto.Enamesearch = BranchNo;
                        Auto.NSearch = IECNo;
                        dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

                        if (dss.Tables[0].Rows.Count == 0)
                        {
                            Auto.Ename = "ADCODE_MASTER_SEARCH_branch_slno_wise";
                            Auto.Enamesearch = "";
                            Auto.NSearch = IECNo;
                            dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                        }


                        if (dss.Tables[0].Rows.Count > 0)
                        {
                            if (dss.Tables[0].Rows.Count == 1)
                            {
                                if (dss.Tables[0].Rows[0]["IMPORT_ADCODE"].ToString() != "")
                                {
                                    ADCODE_IEC_ADCODE = dss.Tables[0].Rows[0]["IMPORT_ADCODE"].ToString();
                                }
                                else
                                {
                                    ADCODE_IEC_ADCODE = dss.Tables[0].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                                }
                            }
                        }
                    }
                }

                custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address5 + "~~" + IECNo + "~~" + BranchNo + "~~" + IMP_EXP_TYPE + "~~" + TIN_NO + "~~" + STATECODE + "~~" + commercialYN + "~~" + ADCODE_IEC_ADCODE
                     + "~~" + M_COMMERCIAL_DETAILS_STATUS + "~~" + M_COMMERCIAL_TAX_STATENAME + "~~" + M_COMMERCIAL_TAX_STATECODE + "~~" + M_COMMERCIAL_TAX_REGISTRATION_NO + "~~" + M_COMMERCIAL_TAX_TYPE + "~~" + GSTN_TYPE + "~~" + GSTN_ID + "~~" + WAREHOUSE_CODE + "~~" + PAYMENT_METHOD_CODE;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Ser_Country_of_orgin(string custid, string custid_2)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();

            Auto.Enamesearch = custid;
            Auto.Ename = "IMP_EXP_Country_of_orgin_Chk";
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

            if (ds.Tables[0].Rows.Count > 0)
            {
                custid = "Yes";
            }
            else
            {
                custid = "No";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Ser_Port_of_orgin(string custid, string custid_2)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();

            Auto.Enamesearch = custid;
            if (custid_2 == "Air")
            {
                Auto.Notn_No_Search = "3";
            }
            else if (custid_2 == "Sea" || custid_2 == "Land")
            {
                Auto.Notn_No_Search = "5";
            }

            Auto.Ename = "IMP_EXP_Port_of_orgin_Chk";
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

            if (ds.Tables[0].Rows.Count > 0)
            {
                custid = "Yes";
            }
            else
            {
                string flag = "";
                if (custid_2 == "Air")
                {
                    flag = "PORT_MASTER_USER_WISE_LIST_AIR_general";
                }
                else
                {
                    flag = "PORT_MASTER_USER_WISE_LIST_SEA_LAND_general";
                }
                Auto.Ename = flag;
                Auto.Enamesearch = custid;
                Auto.NSearch = "";

                ds.Clear();
                ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    custid = "Yes";
                }
                else
                {
                    custid = "No";

                    if (custid_2 == "Land")//for SEZ
                    {
                        Auto.Notn_No_Search = "6";
                        Auto.Ename = "IMP_EXP_Port_of_orgin_Chk";
                        ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            custid = "Yes";
                        }
                        else
                        {
                            custid = "No";
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string GetImporter_HIGHSEA_SALE_Branchwise(string custid, string custid1, string Adcode, string Jobno)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            DataSet dss = new DataSet();
            string STD_Type = "";
            string ADCODE_IEC_ADCODE = "";

            if (HttpContext.Current.Session["STANDARD_TYPE"] != null)
            {
                STD_Type = HttpContext.Current.Session["STANDARD_TYPE"].ToString();

                if (STD_Type == "Non_STD")
                {
                    STD_Type = STD_Type;
                }
                else
                {
                    STD_Type = "";
                }
            }

            Auto.Ename = "IMP_EXP_MASTER_IMPORTER_BRANCH_WISE";
            Auto.Enamesearch = custid;
            Auto.NSearch = custid1;
            Auto.STANDARD_TYPE = STD_Type;
            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH_STD_Type();

            if (ds.Tables[0].Rows.Count > 0)
            {
                string Address1 = ds.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
                string Address2 = ds.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
                string Address3 = ds.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
                string Address4 = ds.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
                string Address5 = ds.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();
                string IECNo = ds.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString();
                string BranchNo = ds.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();
                string IMP_EXP_TYPE = ds.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();

                if (Adcode == "Update")
                {
                    Auto.JobID = "";
                    Auto.Jobno = Jobno;
                    Auto.STANDARD_TYPE = STD_Type;
                    Auto.Ename = "Select_Adcode_from_ImportJob";
                    Auto.Enamesearch = custid;
                    Auto.NSearch = custid1;
                    Auto.Working_Period = Connection.Get_Company_Type();
                    ds = Auto.ERoyalmaste_Retrieve_ADCode_Export();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (custid == BranchNo && custid1 == IECNo)
                        {
                            ADCODE_IEC_ADCODE = ds.Tables[0].Rows[0]["HSS_ADCODE"].ToString();
                        }
                        else
                        {
                            if (IECNo != "")
                            {
                                Auto.Ename = "ADCODE_MASTER_SEARCH_branch_slno_wise";
                                Auto.Enamesearch = BranchNo;
                                Auto.NSearch = IECNo;
                                dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

                                if (dss.Tables[0].Rows.Count == 0)
                                {
                                    Auto.Ename = "ADCODE_MASTER_SEARCH_branch_slno_wise";
                                    Auto.Enamesearch = "";
                                    Auto.NSearch = IECNo;
                                    dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                                }


                                if (dss.Tables[0].Rows.Count > 0)
                                {
                                    if (dss.Tables[0].Rows.Count == 1)
                                    {
                                        if (dss.Tables[0].Rows[0]["IMPORT_ADCODE"].ToString() != "")
                                        {
                                            ADCODE_IEC_ADCODE = dss.Tables[0].Rows[0]["IMPORT_ADCODE"].ToString();
                                        }
                                        else
                                        {
                                            ADCODE_IEC_ADCODE = dss.Tables[0].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (IECNo != "")
                        {
                            Auto.Ename = "ADCODE_MASTER_SEARCH_branch_slno_wise";
                            Auto.Enamesearch = BranchNo;
                            Auto.NSearch = IECNo;
                            dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

                            if (dss.Tables[0].Rows.Count == 0)
                            {
                                Auto.Ename = "ADCODE_MASTER_SEARCH_branch_slno_wise";
                                Auto.Enamesearch = "";
                                Auto.NSearch = IECNo;
                                dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                            }


                            if (dss.Tables[0].Rows.Count > 0)
                            {
                                if (dss.Tables[0].Rows.Count == 1)
                                {
                                    if (dss.Tables[0].Rows[0]["IMPORT_ADCODE"].ToString() != "")
                                    {
                                        ADCODE_IEC_ADCODE = dss.Tables[0].Rows[0]["IMPORT_ADCODE"].ToString();
                                    }
                                    else
                                    {
                                        ADCODE_IEC_ADCODE = dss.Tables[0].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (IECNo != "")
                    {
                        Auto.Ename = "ADCODE_MASTER_SEARCH_branch_slno_wise";
                        Auto.Enamesearch = BranchNo;
                        Auto.NSearch = IECNo;
                        dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

                        if (dss.Tables[0].Rows.Count == 0)
                        {
                            Auto.Ename = "ADCODE_MASTER_SEARCH_branch_slno_wise";
                            Auto.Enamesearch = "";
                            Auto.NSearch = IECNo;
                            dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                        }


                        if (dss.Tables[0].Rows.Count > 0)
                        {
                            if (dss.Tables[0].Rows.Count == 1)
                            {
                                if (dss.Tables[0].Rows[0]["IMPORT_ADCODE"].ToString() != "")
                                {
                                    ADCODE_IEC_ADCODE = dss.Tables[0].Rows[0]["IMPORT_ADCODE"].ToString();
                                }
                                else
                                {
                                    ADCODE_IEC_ADCODE = dss.Tables[0].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                                }
                            }
                        }
                    }
                }

                custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address5 + "~~" + IECNo + "~~" + BranchNo + "~~" + IMP_EXP_TYPE + "~~" + ADCODE_IEC_ADCODE;


                // custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address5 + "~~" + IECNo + "~~" + BranchNo + "~~" + IMP_EXP_TYPE;

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string GetImporter_Branchwise(string custid, string custid1, string Adcode, string Jobno)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            DataSet dss = new DataSet();
            string STD_Type = "";
            string ADCODE_IEC_ADCODE = "";

            if (HttpContext.Current.Session["STANDARD_TYPE"] != null)
            {
                STD_Type = HttpContext.Current.Session["STANDARD_TYPE"].ToString();

                if (STD_Type == "Non_STD")
                {
                    STD_Type = STD_Type;
                }
                else
                {
                    STD_Type = "";
                }
            }

            Auto.Ename = "IMP_EXP_MASTER_IMPORTER_BRANCH_WISE";
            Auto.Enamesearch = custid;
            Auto.NSearch = custid1;
            Auto.STANDARD_TYPE = STD_Type;
            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH_STD_Type();

            if (ds.Tables[0].Rows.Count > 0)
            {
                string IMPORTERNAME = ds.Tables[0].Rows[0]["IMP_EXP_NAME"].ToString();
                string Address1 = ds.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
                string Address2 = ds.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
                string Address3 = ds.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
                string Address4 = ds.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
                string Address5 = ds.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();
                string IECNo = ds.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString();
                string BranchNo = ds.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();
                string IMP_EXP_TYPE = ds.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();

                string M_COMMERCIAL_TAX_STATENAME = ds.Tables[0].Rows[0]["M_COMMERCIAL_TAX_STATENAME"].ToString();
                string M_COMMERCIAL_TAX_STATECODE = ds.Tables[0].Rows[0]["M_COMMERCIAL_TAX_STATECODE"].ToString();
                string M_COMMERCIAL_TAX_REGISTRATION_NO = ds.Tables[0].Rows[0]["M_COMMERCIAL_TAX_REGISTRATION_NO"].ToString();
                string M_COMMERCIAL_TAX_TYPE = ds.Tables[0].Rows[0]["M_COMMERCIAL_TAX_TYPE"].ToString();


                if (Adcode == "Update")
                {
                    Auto.JobID = "";
                    Auto.Jobno = Jobno;
                    Auto.STANDARD_TYPE = STD_Type;
                    Auto.Ename = "Select_Adcode_from_ImportJob";
                    Auto.Enamesearch = custid;
                    Auto.NSearch = custid1;
                    Auto.Working_Period = Connection.Get_Company_Type();
                    ds = Auto.ERoyalmaste_Retrieve_ADCode_Export();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (IMPORTERNAME == ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString())
                        {
                            ADCODE_IEC_ADCODE = ds.Tables[0].Rows[0]["ADCODE"].ToString();
                        }
                        else
                        {
                            if (IECNo != "")
                            {
                                Auto.Ename = "ADCODE_MASTER_SEARCH_branch_slno_wise";
                                Auto.Enamesearch = BranchNo;
                                Auto.NSearch = IECNo;
                                dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

                                if (dss.Tables[0].Rows.Count == 0)
                                {
                                    Auto.Ename = "ADCODE_MASTER_SEARCH_branch_slno_wise";
                                    Auto.Enamesearch = "";
                                    Auto.NSearch = IECNo;
                                    dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                                }


                                if (dss.Tables[0].Rows.Count > 0)
                                {
                                    if (dss.Tables[0].Rows.Count == 1)
                                    {
                                        if (dss.Tables[0].Rows[0]["IMPORT_ADCODE"].ToString() != "")
                                        {
                                            ADCODE_IEC_ADCODE = dss.Tables[0].Rows[0]["IMPORT_ADCODE"].ToString();
                                        }
                                        else
                                        {
                                            ADCODE_IEC_ADCODE = dss.Tables[0].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (IECNo != "")
                        {
                            Auto.Ename = "ADCODE_MASTER_SEARCH_branch_slno_wise";
                            Auto.Enamesearch = BranchNo;
                            Auto.NSearch = IECNo;
                            dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

                            if (dss.Tables[0].Rows.Count == 0)
                            {
                                Auto.Ename = "ADCODE_MASTER_SEARCH_branch_slno_wise";
                                Auto.Enamesearch = "";
                                Auto.NSearch = IECNo;
                                dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                            }


                            if (dss.Tables[0].Rows.Count > 0)
                            {
                                if (dss.Tables[0].Rows.Count == 1)
                                {
                                    if (dss.Tables[0].Rows[0]["IMPORT_ADCODE"].ToString() != "")
                                    {
                                        ADCODE_IEC_ADCODE = dss.Tables[0].Rows[0]["IMPORT_ADCODE"].ToString();
                                    }
                                    else
                                    {
                                        ADCODE_IEC_ADCODE = dss.Tables[0].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (IECNo != "")
                    {
                        Auto.Ename = "ADCODE_MASTER_SEARCH_branch_slno_wise";
                        Auto.Enamesearch = BranchNo;
                        Auto.NSearch = IECNo;
                        dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

                        if (dss.Tables[0].Rows.Count == 0)
                        {
                            Auto.Ename = "ADCODE_MASTER_SEARCH_branch_slno_wise";
                            Auto.Enamesearch = "";
                            Auto.NSearch = IECNo;
                            dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                        }


                        if (dss.Tables[0].Rows.Count > 0)
                        {
                            if (dss.Tables[0].Rows.Count == 1)
                            {
                                if (dss.Tables[0].Rows[0]["IMPORT_ADCODE"].ToString() != "")
                                {
                                    ADCODE_IEC_ADCODE = dss.Tables[0].Rows[0]["IMPORT_ADCODE"].ToString();
                                }
                                else
                                {
                                    ADCODE_IEC_ADCODE = dss.Tables[0].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                                }
                            }
                        }
                    }
                }

                custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address5 + "~~" + IECNo + "~~" + BranchNo + "~~" + IMP_EXP_TYPE
                   + "~~" + M_COMMERCIAL_TAX_STATENAME
                   + "~~" + M_COMMERCIAL_TAX_STATECODE
                   + "~~" + M_COMMERCIAL_TAX_REGISTRATION_NO
                   + "~~" + M_COMMERCIAL_TAX_TYPE
                   + "~~" + ADCODE_IEC_ADCODE
                    ;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return custid;
    }

    protected void JobRelease_Click(object sender, EventArgs e)
    {
        try
        {
            Joblock JL = new Joblock();
            JL.Jobtype = "Import";
            JL.CURRENT_USER = currentuser;
            JL.JOBNO = Session["IMPORT_JOBNO"].ToString();
            JL.Commorn_or_Branchwise = SELECT_BRANCH;
            JL.Select_or_Update = "Update";
            JL.Job_Release_data();
            if (JL.result == 1)
            {
                job_release.Visible = false;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
    }
    protected void btnok_Click(object sender, EventArgs e)
    {
        try
        {
            IMP_JobEdit Jobedit = new IMP_JobEdit();
            if (Request.QueryString["JOBID"] != "" && Request.QueryString["JOBID"] != null)
            {
                if (hd_joblck.Value == "No")
                {
                    //-------------------------------------------------

                    if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00247" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00010")
                    {
                        if (txt_M_jobps.Text == string.Empty && txt_M_jobsf.Text != string.Empty)
                        {
                            Jobedit.PS = txt_jobno.Text + "/" + ((txt_M_jobsf.Text).TrimStart()).TrimEnd();
                        }
                        else if (txt_M_jobps.Text != string.Empty && txt_M_jobsf.Text == string.Empty)
                        {
                            Jobedit.PS = ((txt_M_jobps.Text + txt_jobno.Text).TrimEnd()).TrimStart();
                        }
                        else if (txt_M_jobps.Text != string.Empty && txt_M_jobsf.Text != string.Empty)
                        {
                            Jobedit.PS = ((txt_M_jobps.Text + txt_jobno.Text + "/" + txt_M_jobsf.Text).TrimEnd()).TrimStart();
                        }
                        else if (txt_M_jobps.Text == string.Empty && txt_M_jobsf.Text == string.Empty)
                        {
                            Jobedit.PS = txt_jobno.Text;
                        }
                    }
                    else
                    {

                        if (txt_M_jobps.Text == string.Empty && txt_M_jobsf.Text != string.Empty)
                        {
                            Jobedit.PS = txt_jobno.Text + "/" + ((txt_M_jobsf.Text).TrimStart()).TrimEnd();
                        }
                        else if (txt_M_jobps.Text != string.Empty && txt_M_jobsf.Text == string.Empty)
                        {
                            Jobedit.PS = ((txt_M_jobps.Text + "/" + txt_jobno.Text).TrimEnd()).TrimStart();
                        }
                        else if (txt_M_jobps.Text != string.Empty && txt_M_jobsf.Text != string.Empty)
                        {
                            Jobedit.PS = ((txt_M_jobps.Text + "/" + txt_jobno.Text + "/" + txt_M_jobsf.Text).TrimEnd()).TrimStart();
                        }
                        else if (txt_M_jobps.Text == string.Empty && txt_M_jobsf.Text == string.Empty)
                        {
                            Jobedit.PS = txt_jobno.Text;
                        }
                    }

                    //---------------------------------------------------

                    /*  if (txt_M_jobps.Text == string.Empty && txt_M_jobsf.Text != string.Empty) 
                      {
                          Jobedit.PS = txt_jobno.Text + "/" + txt_M_jobsf.Text;
                      }
                      else if (txt_M_jobps.Text != string.Empty && txt_M_jobsf.Text == string.Empty)
                      {
                          Jobedit.PS = txt_M_jobps.Text + "/" + txt_jobno.Text;
                      }
                      else if (txt_M_jobps.Text != string.Empty && txt_M_jobsf.Text != string.Empty)
                      {
                          Jobedit.PS = txt_M_jobps.Text + "/" + txt_jobno.Text + "/" + txt_M_jobsf.Text;
                      }
                      else if (txt_M_jobps.Text == string.Empty && txt_M_jobsf.Text == string.Empty)
                      {
                          Jobedit.PS = txt_jobno.Text;
                      }*/

                    Jobedit.JOB_PREFIX = txt_M_jobps.Text;
                    Jobedit.JOB_SUFFIX = txt_M_jobsf.Text;

                    Jobedit.Old_Jobno = txtJobNo.Text;
                    Jobedit.Current_Jobno = txt_jobno.Text;
                    Jobedit.BRANCH_CODE = SELECT_BRANCH;
                    Jobedit.UserId = currentuser;
                    Jobedit.JopUpdate();
                    if (Jobedit.result == 1)
                    {
                        txtJobNo.Text = txt_jobno.Text;
                        txtjobps.Text = Jobedit.PS;
                        Session.Remove("IMPORT_JOBNO");
                        Session.Remove("CONT_TYPE");
                        Session.Remove("JOBNO_PS");

                        Session["IMPORT_JOBNO"] = txtJobNo.Text;
                        Session["CONT_TYPE"] = ddlContainer_Type.SelectedValue.ToString();
                        Session["JOBNO_PS"] = txtjobps.Text;
                    }
                    else if (Jobedit.result == 2)
                    {
                        txtid.Text = "Job already exists";
                        MP_JOB.Show();
                    }
                    else if (Jobedit.result == 3)
                    {
                        txtid.Text = "Job already Filed Can't modify";
                        MP_JOB.Show();
                    }
                }
                else if (hd_joblck.Value == "Yes")
                {
                    txtid.Text = "This Job Locked";
                    MP_JOB.Show();
                }
            }
            else
            {
                if (hd_joblck.Value == "No")
                {
                    if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00247" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00010")
                    {
                        if (txt_M_jobps.Text == string.Empty && txt_M_jobsf.Text != string.Empty)
                        {
                            Jobedit.PS = txt_jobno.Text + "/" + ((txt_M_jobsf.Text).TrimStart()).TrimEnd();
                        }
                        else if (txt_M_jobps.Text != string.Empty && txt_M_jobsf.Text == string.Empty)
                        {
                            Jobedit.PS = ((txt_M_jobps.Text + txt_jobno.Text).TrimEnd()).TrimStart();
                        }
                        else if (txt_M_jobps.Text != string.Empty && txt_M_jobsf.Text != string.Empty)
                        {
                            Jobedit.PS = ((txt_M_jobps.Text + txt_jobno.Text + "/" + txt_M_jobsf.Text).TrimEnd()).TrimStart();
                        }
                        else if (txt_M_jobps.Text == string.Empty && txt_M_jobsf.Text == string.Empty)
                        {
                            Jobedit.PS = txt_jobno.Text;
                        }
                    }
                    else
                    {

                        if (txt_M_jobps.Text == string.Empty && txt_M_jobsf.Text != string.Empty)
                        {
                            Jobedit.PS = txt_jobno.Text + "/" + ((txt_M_jobsf.Text).TrimStart()).TrimEnd();
                        }
                        else if (txt_M_jobps.Text != string.Empty && txt_M_jobsf.Text == string.Empty)
                        {
                            Jobedit.PS = ((txt_M_jobps.Text + "/" + txt_jobno.Text).TrimEnd()).TrimStart();
                        }
                        else if (txt_M_jobps.Text != string.Empty && txt_M_jobsf.Text != string.Empty)
                        {
                            Jobedit.PS = ((txt_M_jobps.Text + "/" + txt_jobno.Text + "/" + txt_M_jobsf.Text).TrimEnd()).TrimStart();
                        }
                        else if (txt_M_jobps.Text == string.Empty && txt_M_jobsf.Text == string.Empty)
                        {
                            Jobedit.PS = txt_jobno.Text;
                        }
                    }

                    Jobedit.JOB_PREFIX = txt_M_jobps.Text;
                    Jobedit.JOB_SUFFIX = txt_M_jobsf.Text;

                    Jobedit.Old_Jobno = txtJobNo.Text;
                    Jobedit.Current_Jobno = txt_jobno.Text;
                    Jobedit.BRANCH_CODE = SELECT_BRANCH;
                    Jobedit.UserId = currentuser;
                    Jobedit.JopUpdate();
                    if (Jobedit.result == 1)
                    {
                        txtJobNo.Text = txt_jobno.Text;
                        txtjobps.Text = Jobedit.PS;
                        Session.Remove("IMPORT_JOBNO");
                        Session.Remove("CONT_TYPE");
                        Session.Remove("JOBNO_PS");

                        Session["IMPORT_JOBNO"] = txtJobNo.Text;
                        Session["CONT_TYPE"] = ddlContainer_Type.SelectedValue.ToString();
                        Session["JOBNO_PS"] = txtjobps.Text;
                    }
                    else if (Jobedit.result == 2)
                    {
                        txtid.Text = "Job already exists";
                        MP_JOB.Show();
                    }
                    else if (Jobedit.result == 3)
                    {
                        txtid.Text = "Job already Filed Can't modify";
                        MP_JOB.Show();
                    }
                }
                else if (hd_joblck.Value == "Yes")
                {
                    txtid.Text = "This Job Locked";
                    MP_JOB.Show();
                }

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
    }

    public void Get_Client_Default_Settings()
    {
        try
        {
            Default_Settings Default = new Default_Settings();
            Default.DEFAULT_ID = Session["USER_CREATION_ID"].ToString();
            Default.STANDARD_TYPE = "";
            Default.USER_ID = currentuser;
            Default.BRANCH_CODE = currentbranch;
            Default.YEAR = "";
            Default.WORKING_PERIOD = Working_Period;
            Default.BRANCH_COMMON = SELECT_BRANCH;
            Default.flag = "Get_Details";
            ds = Default.Client_DefaultSettings_Insert_Update();

            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["STANDARD_TYPE"] = ds.Tables[0].Rows[0]["STANDARD_TYPE"].ToString();
                Hdn_STANDARD_TYPE.Value = ViewState["STANDARD_TYPE"].ToString();
                Session["STANDARD_TYPE"] = Hdn_STANDARD_TYPE.Value;
            }
            else
            {
                Hdn_STANDARD_TYPE.Value = "STD";
                Session["STANDARD_TYPE"] = Hdn_STANDARD_TYPE.Value;
            }

            if (ddl_MultipleIcegate_YN == "Y")
            {
                if (ds.Tables[2].Rows.Count > 0)
                {
                    ddl_Multiple_CHA_No.DataSource = ds.Tables[2];
                    ddl_Multiple_CHA_No.DataTextField = "CHA_NO";
                    ddl_Multiple_CHA_No.DataValueField = "CHA_NO";
                    ddl_Multiple_CHA_No.DataBind();

                    ddl_Multiple_CHA_No.Items.Insert(0, "");
                }
                else
                {
                    ddl_Multiple_CHA_No.Items.Insert(0, "");
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
    }


    private void load_FRT_JOBS()
    {
        try
        {
            ddlFreightJobs.Items.Clear();
            DataSet dss = new DataSet();
            //eFreightQuotation_Transactions Trans = new eFreightQuotation_Transactions();
            Transact.SEARCH_CAT = ""; Transact.SEARCH_ITEM = ""; Transact.TRANSPORT_MODE = ddlTransportMode.SelectedValue.ToString(); Transact.CUSTOMS_HOUSE = "";
            Transact.Ename = "";
            Transact.WORKING_PERIOD = currentbranch;
            if (ddlTransportMode.SelectedValue.ToString() == "Air")
            {
                Transact.flag = "Import-Air";
            }
            else if (ddlTransportMode.SelectedValue.ToString() == "Sea")
            {
                Transact.flag = "Import-Sea";
            }
            else if (ddlTransportMode.SelectedValue.ToString() == "Land")
            {
                Transact.flag = "Import-Land";
            }
            dss = Transact.FREIGHT_IMP_EXP_Job_Load();
            if (dss.Tables.Count > 0)
            {
                if (dss.Tables[0].Rows.Count > 0)
                {
                    ddlFreightJobs.DataSource = dss.Tables[0];
                    ddlFreightJobs.DataValueField = "JOBNO";
                    ddlFreightJobs.DataTextField = "JobReference";
                    ddlFreightJobs.DataBind();
                    ddlFreightJobs.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    ddlFreightJobs.SelectedIndex = 0;
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
    }
    protected void ddlTransportMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string Trns_Mode = "", Cus_Loc = "";

            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            if (ddlTransportMode.SelectedValue == "Air")
            {
                Trns_Mode = "A";
            }
            else if (ddlTransportMode.SelectedValue == "Sea")
            {
                Trns_Mode = "S";
            }
            else
            {
                Trns_Mode = "L";
            }
            if (txtCustomsHouse.Text.Contains("-"))
            {
                string[] s1 = txtCustomsHouse.Text.Split(new string[] { "-" }, StringSplitOptions.None);
                Cus_Loc = s1[1].ToString();
            }
            else
            {
                Cus_Loc = txtCustomsHouse.Text;
            }
            Auto.Enamesearch = Trns_Mode;
            Auto.Notn_No_Search = Cus_Loc;
            Auto.Ename = "Check_Mode_Cus_Loc";
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH_PART_II();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCustomsHouse.Text = ds.Tables[0].Rows[0]["CUSTOMHOUSE_CODE"].ToString();
            }
            else
            {
                txtCustomsHouse.Text = "";

            }

            if (ddlTransportMode.SelectedValue == "Air")
            {
                DataSet ds_Con = new DataSet();
                Transact.JOBNO = txtJobNo.Text;
                Transact.flag = "Check_Container_Details";
                ds_Con = Transact.Check_Container_Details_Avail();
                if (Transact.result == 1)
                {
                    string customsHouseCode = Session["IMP_Job_CUSTOMHOUSE_CODE"] != null ? Session["IMP_Job_CUSTOMHOUSE_CODE"].ToString() : "";
                    string transportMode = Session["TRANSPORT_MODE_NEW"] != null ? Session["TRANSPORT_MODE_NEW"].ToString() : "";
                    string port_shipment = Session["PORT_SHIPMENT"] != null ? Session["PORT_SHIPMENT"].ToString() : "";
                    string port_orgin = Session["PORT_ORIGIN"] != null ? Session["PORT_ORIGIN"].ToString() : "";

                    string script = "if(confirm('Container Details available. Do you want to delete?')) { " +
                                    "__doPostBack('btnConfirmDelete', ''); } " +
                                    "else { " +
                                    "document.getElementById('txtCustomsHouse').value = '" + customsHouseCode + "';" +
                                    "document.getElementById('ddlTransportMode').value = '" + transportMode + "';" +
                                    "document.getElementById('txtPortShipment').value = '" + port_shipment + "';" +
                                    "document.getElementById('txtPortOrigin').value = '" + port_orgin + "';" +
                                    "}";

                    ClientScript.RegisterStartupScript(this.GetType(), "ConfirmDelete", script, true);

                }

            }
            //// up to this worked by pandiyan

            if (Session["IsCHA_Mapped"] != null)
            {
                if (Session["IsCHA_Mapped"].ToString() == "Y")
                {
                    //***** Freight and CHA Mapping Method hided due to heavy load need to recheck ************//
                    load_FRT_JOBS();
                }
                else
                {
                    ddlFreightJobs.Enabled = false;
                }
            }
            else
            {
                ddlFreightJobs.Enabled = false;
            }

            JobNo_Prefix_Sufix();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
    }


    protected void ddlFreightJobs_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtFile_Ref_No.Text = ddlFreightJobs.SelectedValue.ToString();
            DataSet ds = new DataSet();
            Transact.SEARCH_CAT = ""; Transact.SEARCH_ITEM = ddlFreightJobs.SelectedItem.ToString();
            Transact.WORKING_PERIOD = currentbranch; Transact.TRANSPORT_MODE = ddlTransportMode.SelectedValue.ToString();


            if (ddlTransportMode.SelectedValue.ToString() == "Air")
            {
                Transact.flag = "Import-Air-JobNo";
            }
            else if (ddlTransportMode.SelectedValue.ToString() == "Sea")
            {
                Transact.flag = "Import-Sea-JobNo";
            }
            else if (ddlTransportMode.SelectedValue.ToString() == "Land")
            {
                Transact.flag = "Import-Other-Jobno";
            }

            ds = Transact.FREIGHT_IMP_EXP_Job_Load();
            if (ds.Tables.Count > 0)
            {
                Session.Remove("FRT_IMP_JOBNO_CHA");
                Session["FRT_IMP_JOBNO_CHA"] = ddlFreightJobs.SelectedItem.ToString();



                if (ds.Tables[0].Rows.Count > 0)
                {

                    txtImporterName.Text = ds.Tables[0].Rows[0]["CLIENT_NAME"].ToString();
                    txtIECNo.Text = ds.Tables[0].Rows[0]["IEC_NO"].ToString();
                    txt_ADCode.Text = ds.Tables[0].Rows[0]["ADCODE"].ToString();
                    txtBranchNo.Text = ds.Tables[0].Rows[0]["BRANCH_NO"].ToString();
                    txtAddress1.Text = ds.Tables[0].Rows[0]["ADDRESS1"].ToString();
                    txtAddress2.Text = ds.Tables[0].Rows[0]["ADDRESS2"].ToString();
                    txtAddress3.Text = ds.Tables[0].Rows[0]["ADDRESS3"].ToString();
                    //txtAddress4.Text = ds.Tables[0].Rows[0]["ADDRESS4"].ToString();
                    txtAddress5.Text = ds.Tables[0].Rows[0]["ADDRESS5"].ToString();


                    txtCountryName.Text = ds.Tables[0].Rows[0]["COUNTRY_ORIGIN"].ToString();
                    txtCountryShipment.Text = ds.Tables[0].Rows[0]["COUNTRY_SHIPMENT"].ToString();
                    txtPortOrigin.Text = ds.Tables[0].Rows[0]["PORT_ORIGIN"].ToString();

                    txtPortShipment.Text = ds.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString();

                    hdn_FRT_GroupID.Value = ds.Tables[0].Rows[0]["GROUP_ID"].ToString();
                    hdn_FRT_Branch.Value = ds.Tables[0].Rows[0]["BRANCHCODE"].ToString();

                    //----------------------------------------------------------//
                    txtCommercial_StateName.Text = ds.Tables[0].Rows[0]["ADDRESS4"].ToString();
                    txtCommercial_StateCode.Text = ds.Tables[0].Rows[0]["STATE_CODE"].ToString();
                    txtCommercial_RegistrationNo.Text = ds.Tables[0].Rows[0]["GSTNID"].ToString();
                    ddl_Commercial_Type.SelectedValue = ds.Tables[0].Rows[0]["GSTNTYPE"].ToString();
                    //----------------------------------------------------------//
                }
                if (txtAddress1.Text == "" || txtAddress2.Text == "")
                {
                    eroyalmaster erm = new eroyalmaster();
                    DataSet dsAdd = new DataSet();
                    erm.Ename = "Get_ClientAddress";
                    erm.Eimp_exp_name = txtImporterName.Text;
                    dsAdd = erm.RetrieveAll_Imp_exp_master_STD_TYPE();
                    if (dsAdd.Tables[0].Rows.Count > 0)
                    {
                        txtAddress1.Text = dsAdd.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
                        txtAddress2.Text = dsAdd.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
                        txtAddress3.Text = dsAdd.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
                        txtAddress4.Text = dsAdd.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
                        txtAddress5.Text = dsAdd.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();
                    }

                }
                //RetrieveAll_Imp_exp_master_STD_TYPE
                //if (ds.Tables[1].Rows.Count > 0)
                //{
                //    txtInvoiceNo.Text = ds.Tables[1].Rows[0]["Invoice_no"].ToString();
                //    txtInvoiceDate.Text = ds.Tables[1].Rows[0]["Invoice_date"].ToString();
                //    txtInvoiceValue.Text = ds.Tables[1].Rows[0]["Invoice_Value"].ToString();
                //    txtInvoiceCurrency.Text = ds.Tables[1].Rows[0]["Invoice_Currency"].ToString();
                //}
                //if (ds.Tables[2].Rows.Count > 0)
                //{
                //    txt_HSCode.Text = ds.Tables[2].Rows[0]["PRODUCT_CTH"].ToString();
                //    txtCommodity.Text = ds.Tables[2].Rows[0]["ITEM_DESCRIPTION"].ToString();
                //}

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }

    }


    private void Elogix_Service(string Flg)
    {
        try
        {
            Connection.e_lOGIX("I", Flg);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
    }

    private void Elogix_Chennai_Service()
    {
        try
        {
            if (Connection.e_lOGIX_CHENNAI() != string.Empty)
            {
                ELogix_Chennai.Visible = true;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
    }
    private void Elogix_Chennai_Ref_Service(string flg)
    {
        try
        {
            if (Connection.e_lOGIX_CHENNAI() != string.Empty)
            {
                /*
                UserBO ObjUBO = new UserBO();
                InvoSys_CS EL = new InvoSys_CS();

                DataSet dss = new DataSet();
                ObjUBO.JOBNO = Connection.IMP_Jobno();
                ObjUBO.File_Type = "I";
                ObjUBO.INVOICE_NO =txt_Ref_Loc.Text;
                ObjUBO.INVOICE_SLNO = ddl_Ref_Type.SelectedValue.ToString();
                if (flg == "S")
                {
                    ObjUBO.flag = "S";
                    EL.E_Logix_Chennai_Ref(ObjUBO);
                }
                else
                {
                   ObjUBO.flag = "Select";
                   dss= EL.E_Logix_Chennai_Ref(ObjUBO);
                   if (dss.Tables[0].Rows.Count > 0)
                   {
                       txt_Ref_Loc.Text = dss.Tables[0].Rows[0][0].ToString();
                       ddl_Ref_Type.SelectedValue = dss.Tables[0].Rows[0][1].ToString();
                   }
                   else
                   {
                       txt_Ref_Loc.Text = string.Empty;
                       ddl_Ref_Type.SelectedIndex = -1;
                   }
                }
           
           
                txt_Ref_Loc.Enabled=false;
                ddl_Ref_Type.Enabled = false;
                * */
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
    }
    private void Ryal_Service(string flg)
    {
        try
        {
            Ryal_CS RI = new Ryal_CS();
            Global_variables ObjUBO = new Global_variables();

            ObjUBO.A1 = Connection.IMP_Jobno();
            ObjUBO.A2 = txt_FF_Jobno.Text;
            ObjUBO.A3 = "I";
            ObjUBO.A4 = flg;
            RI.Ryal_Royal_Job_Update(ObjUBO);

            if (flg == "S")

                if (Connection.COMPANYID() == "2814" || Connection.COMPANYID() == "3082" || Connection.COMPANYID() == "3253")
                {
                    Connection.Ebms_JobRefno_Return(1, txt_FF_Jobno.Text, ObjUBO.A1, ObjUBO.A3);
                }
                else
                {
                    Connection.Ryal_JobRefno_Return(1, txt_FF_Jobno.Text, ObjUBO.A1); //*********IS LIVE IMPLEMENTATION********
                    //Connection.Ryal_JobRefno_Return(0, txt_FF_Jobno.Text, ObjUBO.A1); //*********IS TEST IMPLEMENTATION********
                }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
    }

    [System.Web.Services.WebMethod]
    public static string Set_State_Name_Validation(string custid)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();

            Auto.Enamesearch = custid;
            Auto.Ename = "State_Name_Validate";
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

            if (ds.Tables[0].Rows.Count > 0)
            {
                custid = "Yes";
            }
            else
            {
                custid = "No";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Set_Customs_House_Validation(string custid)
    {
        try
        {

            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Enamesearch = custid;
            Auto.Ename = "CUSTOM_HOUSE_MASTER";
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                custid = "Yes";

            }
            else
            {
                custid = "No";


            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return custid;
    }


    [System.Web.Services.WebMethod]
    public static string Chk_CountryCode_PortCode(string custid, string custid_2)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();

            Auto.Enamesearch = custid;
            Auto.Notn_No_Search = custid_2;
            Auto.Ename = "CHK_COUNTRYCODE_PORTCODE_MISMATCH";
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

            if (ds.Tables[0].Rows.Count > 0)
            {
                custid = "Yes";
            }
            else
            {
                custid = "No";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return custid;
    }

    private int Chk_CustomsDuty_rpt_Status_FAIRMACS(string jobno)
    {
        CustomDuty_Rpt CDR = new CustomDuty_Rpt();

        int Result = 0;
        DataSet ds1 = new DataSet();
        try
        {

            CDR.Jobno = jobno;
            CDR.From_date = "C";
            CDR.To_date = "";
            CDR.Imp_Name = Connection.Current_User();
            CDR.BRANCH_CODE = Connection.Current_Branch();
            CDR.flag = "Get_Rpt_Status";
            ds1 = CDR.Report_data();

            Result = CDR.result;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
        return Result;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Betype(string betype)
    {

        DataSet ds = new DataSet();
        try
        {
            HttpContext.Current.Session["BE_TYPE"] = betype;

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return betype;
    }

    [System.Web.Services.WebMethod]
    public static string Transport_Mode(string CusHouse, string Jobno)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        string CUSTOMS_HOUSE = "";
        string Container = "";
        try
        {

            if (CusHouse.Contains("-"))
            {
                string[] s1 = CusHouse.Split(new string[] { "-" }, StringSplitOptions.None);
                CUSTOMS_HOUSE = s1[1].ToString();
            }
            else
            {
                CUSTOMS_HOUSE = CusHouse;
            }
            Auto.Enamesearch = CUSTOMS_HOUSE;
            Auto.Ename = "Transport_Mode_Cat";
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CUSTOMHOUSE_CATEGORY"].ToString() == "A")
                {
                    CusHouse = "Air";
                }
                else if (ds.Tables[0].Rows[0]["CUSTOMHOUSE_CATEGORY"].ToString() == "S")
                {
                    CusHouse = "Sea";
                }
                else if (ds.Tables[0].Rows[0]["CUSTOMHOUSE_CATEGORY"].ToString() == "L")
                {
                    CusHouse = "Land";
                }

            }

            if (CUSTOMS_HOUSE != "" && CusHouse == "Air")
            {
                Transaction Transact = new Transaction();
                DataSet ds_Con = new DataSet();
                Transact.JOBNO = Jobno;
                Transact.flag = "Check_Container_Details";
                ds_Con = Transact.Check_Container_Details_Avail();

                if (Transact.result == 1)
                {
                    Container = "Yes";
                }
                else
                {
                    Container = "No";
                }

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return CusHouse + "~" + Container;
    }
    [System.Web.Services.WebMethod]
    public static string Transport_Mode_Customhouse()
    {
        string customHouseCode = "";
        string transportModePort = "";
        string port_shipment = "";
        string port_orgin = "";
        try
        {
            customHouseCode = HttpContext.Current.Session["IMP_Job_CUSTOMHOUSE_CODE"] as string ?? "";
            transportModePort = HttpContext.Current.Session["TRANSPORT_MODE_NEW"] as string ?? "";
            port_shipment = HttpContext.Current.Session["PORT_SHIPMENT"] as string ?? "";
            port_orgin = HttpContext.Current.Session["PORT_ORIGIN"] as string ?? "";
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return customHouseCode + "~" + transportModePort + "~" + port_shipment + "~" + port_orgin;
    }

    private void Load_BE_Type()
    {
        try
        {
            ddlBEType.Items.Clear();
            ddlBEType.Items.Add("Home");
            ddlBEType.Items.Add("Warehouse");
            ddlBEType.Items.Add("Ex-Bond");

            if (Session["I_SEZ"].ToString() == "T")
            {
                ddlBEType.Items.Add("SEZ FTA-Z");
                ddlBEType.Items.Add("SEZ DTA-T");
                ddlBEType.Items.Add("SEZ DTA-M");
                ddlBEType.Items.Add("Jobbing");
                ddlBEType.Items.Add("Repair & Return");
                ddlBEType.Items.Add("Exhibition");
                ddlBEType.Items.Add("Destruction");
                ddlBEType.Items.Add("Movement of Goods");
                ddlBEType.Items.Add("Stock Item");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
    }

    private void Get_ClientMaster_edit_details(string ename, string IMP_EXP_ID)
    {
        try
        {
            eroyalmaster erm = new eroyalmaster();
            DataSet dtt_clnt = new DataSet();

            erm.Eimp_exp_id = IMP_EXP_ID;
            erm.Eimp_exp_name = txtImporterName.Text;
            erm.Eimp_exp_iecno = txtIECNo.Text;
            erm.Eimp_exp_brslno = txtBranchNo.Text;
            erm.Ename = ename;
            erm.EWorking_Period = Working_Period;

            if (!String.IsNullOrEmpty(Session["STANDARD_TYPE"] as string))
            {
                erm.STANDARD_TYPE = Session["STANDARD_TYPE"].ToString();
            }
            else
            {
                erm.STANDARD_TYPE = null;
            }

            dtt_clnt = erm.RetrieveAll_Imp_exp_master_STD_TYPE();

            if (dtt_clnt.Tables[0].Rows.Count > 0)
            {
                txtImporterName.Text = dt.Replace(dtt_clnt.Tables[0].Rows[0]["IMP_EXP_NAME"].ToString());
                txtIECNo.Text = dt.Replace(dtt_clnt.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString());
                txtBranchNo.Text = dt.Replace(dtt_clnt.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString());
                txtAddress1.Text = dt.Replace(dtt_clnt.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString());
                txtAddress2.Text = dt.Replace(dtt_clnt.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString());
                txtAddress3.Text = dt.Replace(dtt_clnt.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString());
                txtAddress4.Text = dt.Replace(dtt_clnt.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString());
                txtAddress5.Text = dt.Replace(dtt_clnt.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString());
                txt_Payment_Method.Text = dt.Replace(dtt_clnt.Tables[0].Rows[0]["PAYMENT_METHOD_CODE"].ToString());

                string commercialYN = dtt_clnt.Tables[0].Rows[0]["M_COMMERCIAL_DETAILS_STATUS"].ToString();
                Session["commercialYN"] = commercialYN;
                if (commercialYN == "Y")
                {
                    ddlCommercial_Tax_yn.Items.Clear();
                    ddlCommercial_Tax_yn.Items.Add("Y");
                    ddlCommercial_Tax_yn.Items.Remove(commercialYN);
                    ddlCommercial_Tax_yn.Items.Insert(0, commercialYN);

                    txtCommercial_StateName.Text = dtt_clnt.Tables[0].Rows[0]["M_COMMERCIAL_TAX_STATENAME"].ToString();
                    txtCommercial_StateCode.Text = dtt_clnt.Tables[0].Rows[0]["M_COMMERCIAL_TAX_STATECODE"].ToString();
                    ddl_Commercial_Type.SelectedValue = dtt_clnt.Tables[0].Rows[0]["M_COMMERCIAL_TAX_TYPE"].ToString();
                    //ViewState["M_COMMERCIAL_TAX_TYPE"] = ddl_Commercial_Type.SelectedValue;
                    txtCommercial_RegistrationNo.Text = dtt_clnt.Tables[0].Rows[0]["M_COMMERCIAL_TAX_REGISTRATION_NO"].ToString();
                    ddlType.SelectedValue = dtt_clnt.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();
                    hdn_ImporterType.Value = dtt_clnt.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();//Added by pandiyan on 04/06/2025
                    Session["IMP_EXP_TYPE"] = hdn_ImporterType.Value;//Added by pandiyan on 04/06/2025
                    hdn_StateName.Value = dtt_clnt.Tables[0].Rows[0]["M_COMMERCIAL_TAX_STATENAME"].ToString();
                    hdn_StateName_chk.Value = Set_State_Name_Validation(hdn_StateName.Value);

                    hdn_TIN_NO.Value = dtt_clnt.Tables[0].Rows[0]["M_COMMERCIAL_TAX_REGISTRATION_NO"].ToString();
                    hdn_StateCode.Value = dtt_clnt.Tables[0].Rows[0]["M_COMMERCIAL_TAX_STATECODE"].ToString();
                    hdn_commercialType.Value = dtt_clnt.Tables[0].Rows[0]["M_COMMERCIAL_TAX_TYPE"].ToString();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Update_ddlCommercial_Type()", true);
                }
                else
                {
                    //div_CommercialTax.Style.Add("Display", "none");
                    ddlCommercial_Tax_yn.Items.Clear();
                    //ddlCommercial_Tax_yn.Items.Add("N");
                    ddlCommercial_Tax_yn.Items.Add("Y");
                }
            }

            //Session.Remove("Client_Master_Job_New");
            //Session.Remove("Client_Master_Job_edit");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
    }

    private void Premium_Services()
    {
        try
        {
            if (Connection.Import_FF_Reader() == "T")
            {
                btnSignedBE.Visible = true;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
    }


    private void Load_Mandatory_Flags()
    {
        try
        {
            DataRow mand = Get_Mandatory_Settings();

            // ✅ When mand is null (deleted or no record) → default ALL to N
            // No mandatory checks when no active settings exist
            string f_ImporterName = (mand != null) ? mand["GENERAL_IMPORTER_NAME"].ToString() : "Y";
            string f_IECNo = (mand != null) ? mand["GENERAL_IEC_NO"].ToString() : "Y";
            string f_ADCode = (mand != null) ? mand["GENERAL_AD_CODE"].ToString() : "Y";
            string f_Address = (mand != null) ? mand["GENERAL_ADDRESS"].ToString() : "Y";
            string f_CountryOrigin = (mand != null) ? mand["GENERAL_COUNTRY_ORIGIN"].ToString() : "Y";
            string f_CountryShip = (mand != null) ? mand["GENERAL_COUNTRY_SHIPMENT"].ToString() : "Y";
            string f_PortOrigin = (mand != null) ? mand["GENERAL_PORT_ORIGIN"].ToString() : "Y";
            string f_PortShipment = (mand != null) ? mand["GENERAL_PORT_SHIPMENT"].ToString() : "Y";
            string f_StateCode = (mand != null) ? mand["GENERAL_STATE_CODE"].ToString() : "Y";
            string f_RegNo = (mand != null) ? mand["GENERAL_REGISTRATION_NO"].ToString() : "Y";
            string f_BranchNo = (mand != null) ? mand["GENERAL_BRANCH_SL_NO"].ToString() : "Y";
            string f_StateName = (mand != null) ? mand["GENERAL_STATE_NAME"].ToString() : "Y";

            string script = string.Format(@"
        var mand_ImporterName  = '{0}';
        var mand_IECNo         = '{1}';
        var mand_ADCode        = '{2}';
        var mand_Address       = '{3}';
        var mand_CountryOrigin = '{4}';
        var mand_CountryShip   = '{5}';
        var mand_PortOrigin    = '{6}';
        var mand_PortShipment  = '{7}';
        var mand_StateCode     = '{8}';
        var mand_RegNo         = '{9}';
        var mand_BranchNo      = '{10}';
        var mand_StateName     = '{11}';
    ",
                f_ImporterName, f_IECNo, f_ADCode, f_Address,
                f_CountryOrigin, f_CountryShip, f_PortOrigin,
                f_PortShipment, f_StateCode, f_RegNo,
                f_BranchNo, f_StateName);

            ScriptManager.RegisterStartupScript(
                this, this.GetType(), "MandatoryFlags", script, true);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }
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
            user_Create.flag = "Select_Imp_Col_Setngs";

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



    private bool Check_Mandatory_Fields()
    {
        bool isValid = true;
        string errMsg = "";
        try
        {
            DataRow mand = Get_Mandatory_Settings();

            // No settings saved → all fields default mandatory
            if (mand == null)
                return true;



            // ── Importer Name ─────────────────────────────────────────
            if (mand["GENERAL_IMPORTER_NAME"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txtImporterName.Text))
            {
                errMsg = "Importer Name is mandatory.";
                isValid = false;
            }

            // ── IEC No ────────────────────────────────────────────────
            if (isValid && mand["GENERAL_IEC_NO"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txtIECNo.Text))
            {
                errMsg = "IEC No is mandatory.";
                isValid = false;
            }

            // ── AD Code ───────────────────────────────────────────────
            if (isValid && mand["GENERAL_AD_CODE"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txt_ADCode.Text))
            {
                errMsg = "AD Code is mandatory.";
                isValid = false;
            }

            // ── Address ───────────────────────────────────────────────
            if (isValid && mand["GENERAL_ADDRESS"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txtAddress1.Text))
            {
                errMsg = "Address is mandatory.";
                isValid = false;
            }

            // ── Country Origin ────────────────────────────────────────
            if (isValid && mand["GENERAL_COUNTRY_ORIGIN"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txtCountryName.Text))
            {
                errMsg = "Country Origin is mandatory.";
                isValid = false;
            }

            // ── Country Shipment ──────────────────────────────────────
            if (isValid && mand["GENERAL_COUNTRY_SHIPMENT"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txtCountryShipment.Text))
            {
                errMsg = "Country Shipment is mandatory.";
                isValid = false;
            }

            // ── Port Origin ───────────────────────────────────────────
            if (isValid && mand["GENERAL_PORT_ORIGIN"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txtPortOrigin.Text))
            {
                errMsg = "Port Origin is mandatory.";
                isValid = false;
            }

            // ── Port Shipment ─────────────────────────────────────────
            if (isValid && mand["GENERAL_PORT_SHIPMENT"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txtPortShipment.Text))
            {
                errMsg = "Port Shipment is mandatory.";
                isValid = false;
            }

            // ── State Code ────────────────────────────────────────────
            if (isValid && mand["GENERAL_STATE_CODE"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txtCommercial_StateCode.Text))
            {
                errMsg = "State Code is mandatory.";
                isValid = false;
            }

            // ── Registration No ───────────────────────────────────────
            if (isValid && mand["GENERAL_REGISTRATION_NO"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txtCommercial_RegistrationNo.Text))
            {
                errMsg = "Registration No is mandatory.";
                isValid = false;
            }

            // ── Branch Sl No — NEW ────────────────────────────────────
            if (isValid && mand["GENERAL_BRANCH_SL_NO"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txtBranchNo.Text))
            {
                errMsg = "Branch Sl No is mandatory.";
                isValid = false;
            }

            // ── State Name — NEW ──────────────────────────────────────
            if (isValid && mand["GENERAL_STATE_NAME"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txtCommercial_StateName.Text))
            {
                errMsg = "State Name is mandatory.";
                isValid = false;
            }

            // ── Show error ────────────────────────────────────────────
            if (!isValid)
            {
                Alert_msg(errMsg);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);

        }

        return isValid;
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
            Dt_Change.GetMismatchedRowsFast(dt_Prev, dt_modified, "JOBNO", "General", txt_jobno.Text, "", "", currentuser, currentbranch);
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
            DataRow dr = dt_mapping.NewRow();
            dr["JOBNO"] = txtJobNo.Text;
            dr["JOBDATE"] = txtJobDate.Text;
            dr["TRANSPORT_MODE"] = ddlTransportMode.SelectedValue;
            dr["BE_TYPE"] = ddlBEType.SelectedValue;
            dr["CUSTOMS_HOUSE"] = txtCustomsHouse.Text;
            dr["CUSTOMS_HOUSE_NAME"] = hdn_CustomsHouse_Name.Value;
            dr["IMPORTER_NAME"] = txtImporterName.Text;
            dr["ADDRESS1"] = txtAddress1.Text;
            dr["ADDRESS2"] = txtAddress2.Text;
            dr["ADDRESS3"] = txtAddress3.Text;
            dr["ADDRESS4"] = txtAddress4.Text;
            dr["ADDRESS5"] = txtAddress5.Text;
            dr["IEC_NO"] = txtIECNo.Text;
            dr["BRANCH_NO"] = txtBranchNo.Text;
            dr["COUNTRY_ORIGIN"] = txtCountryName.Text;
            dr["PORT_ORIGIN"] = txtPortOrigin.Text;
            dr["PORT_SHIPMENT"] = txtPortShipment.Text;
            dr["COUNTRY_SHIPMENT"] = txtCountryShipment.Text;
            dr["FILING_STATUS"] = ddlFilingStatus.SelectedValue;

            dr["SECTION46"] = chkSection46.Checked ? "Y" : "N";
            dr["SECTION46_DESC"] = txtSection46Desc.Text;

            dr["FIRSTCHECK"] = chkFirstCheck.Checked ? "Y" : "N";
            dr["FIRSTCHECK_DESC"] = txtFirstCheckDesc.Text;

            dr["GREEN_CHANNEL"] = chkGreenChannel.Checked ? "Y" : "N";
            dr["GREEN_CHANNEL_DESC"] = txtGreenChannelDesc.Text;

            dr["KACHHA_BE"] = chkKachha.Checked ? "Y" : "N";
            dr["KACHHA_BE_DESC"] = txtKachhaDesc.Text;

            dr["SECTION48"] = chkSection48.Checked ? "Y" : "N";
            dr["SECTION48_DESC"] = txtSection48Desc.Text;

            dr["HIGH_SEA_SALE"] = chkHighSeaSale.Checked ? "Y" : "N";
            dr["HIGH_SEA_SALE_NAME"] = txtSellerName.Text;
            dr["HIGH_SEA_IEC"] = txtHighSeaSaleIECNo.Text;
            dr["HIGH_SEA_BRANCH_SL_NO"] = txtBranchSLNo.Text;
            dr["HSS_ADD1"] = txtHighSeaSaleAddress.Text;
            dr["HSS_ADD2"] = txtHighSeaSaleAddress1.Text;
            dr["HSS_ADD3"] = txtHighSeaSaleAddress2.Text;
            dr["HSS_ADD4"] = txtHighSeaSaleAddress3.Text;
            dr["HSS_ADD5"] = txtHighSeaSaleAddress4.Text;

            dr["WAREHOUSE_NAME"] = txtWarehouseName.Text;
            dr["WAREHOUSE_CODE"] = txtWarehouseCode.Text;

            dr["IMP_EXP_TYPE"] = ddlType.SelectedValue;
            dr["COMMERCIAL_DETAILS_STATUS"] = ddlCommercial_Tax_yn.SelectedValue;
            dr["COMMERCIAL_TAX_STATENAME"] = txtCommercial_StateName.Text;
            dr["COMMERCIAL_TAX_STATECODE"] = txtCommercial_StateCode.Text;
            dr["COMMERCIAL_TAX_TYPE"] = ddl_Commercial_Type.SelectedValue;
            dr["COMMERCIAL_TAX_REGISTRATION_NO"] = txtCommercial_RegistrationNo.Text;
            dr["FILE_REF_NO"] = txtFile_Ref_No.Text;
            dr["CONTAINER_TYPE"] = ddlContainer_Type.SelectedValue;
            dr["ADCODE"] = txt_ADCode.Text;
            dr["PAYMENT_METHOD_CODE"] = txt_Payment_Method.Text;
            dr["PRECEDING_LEVEL"] = txt_PrecedingLevel.Text;
            dr["GSTN_TYPE"] = ddl_GSTN_Type.SelectedValue;
            dr["GSTN_ID"] = txt_GSTN_ID.Text;
            dr["PARTY_REF_NO"] = txtParty_RefNo.Text;
            dr["ETA"] = txt_ETA_Date.Text;
            dr["AMENDMENT_TYPE"] = ddl_AmendmentType.SelectedValue;
            dr["HSS_ADCODE"] = txtHSS_AdCode.Text;
            dr["ICE_ID"] = "";
            dr["CHA_NO"] = "";
            dr["PROVISIONAL"] = chkProvisional.Checked ? "Y" : "N";
            dr["PROVISIONAL_DESC"] = txtProvisionalDesc.Text;

            // ================= ADD ROW =================
            dt_mapping.Rows.Add(dr);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return dt_mapping;
    }

    public void OCR_Delete_Jobs(string job_no) // added by sriman on 17-06-2026
    {
        try
        {
            Page_Count_Details ds_Page = new Page_Count_Details();
            ds_Page.PDF_JOB_NO = job_no;
            ds_Page.PDF_STATUS = "JOB DELETE";

            ds_Page.OCR_PDF_COUNT_UPDATE_INSERT();

            pdflog.WriteOcrJobLog(job_no, "Job Deleted", "JobNo:" + job_no + " deleted via Transaction/General screen (PDF_JOB_DELETED flagged)");
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    
}
