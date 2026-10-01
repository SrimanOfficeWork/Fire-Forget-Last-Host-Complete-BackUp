using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using BussinessObject;
using System.Linq;

public partial class Export_General : ThemeClass
{
    Export_General_New Export = new Export_General_New();
    Transaction Transact = new Transaction();
    User_Creation user_Create = new User_Creation();
    Date_Time dt = new Date_Time();
    AppSession aps = new AppSession();
    Transaction trans = new Transaction();

    DataSet dtuser = new DataSet();
    DataSet ds = new DataSet();
    ErrorLogs er = new ErrorLogs();
    PDFReaderLog pdflog = new PDFReaderLog();


    public int i;

    public string currentuser, currentbranch, Working_Period, SELECT_TYPE, SELECT_BRANCH, COMPANY_ID;
    public string SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Screen_IdNew;

    public string JOB_LOCK, JOB_RELEASE, JOB_USER;
    public int Screen_Id;
    public string Shahi_btn_view = "", ddl_MultipleIcegate_YN = "", Audit_YN = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            currentuser = Connection.Current_User();
            currentbranch = Connection.Current_Branch();
            Working_Period = Connection.WorkingPeriod();
            SELECT_BRANCH = Connection.Get_Company_Type();
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();
            COMPANY_ID = Session["COMPANY_ID"].ToString();
            hdn_CompanyID.Value = COMPANY_ID;
            hdn_currentPage.Value = "General";

            Session.Remove("EXPORT_SBTYPE");
            Session["EXPORT_SBTYPE"] = ddlSBType.SelectedValue.ToString();


            //----------------Remove the Session from ItemCopy ------------
            Session.Remove("EXP_ITEM_COPY_YN");
            Session["EXP_ITEM_COPY_YN"] = "No";
            //-------------------------------------------------------------


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
                //Session.Remove("JOBIDexcel"); // hide by chithra with Ram sir..on 04/03/2019 - this line put in  Export General Search page
                //Request["Page"] = "";
                Shahi_btn_view = "No";
                btn_Sahi_ExcelUpload.Visible = false;
                //btnPDFUpload.Visible = false;

                Session.Remove("JOBIDexcel");// this session remove for New button load freshly - by chithra on 04-03-2023
            }

            if (!string.IsNullOrEmpty(Session["Client_Master_Job_edit"] as string))
            {
                Get_ClientMaster_edit_details("select_conwithcode_STD", Session["Client_Master_Job_edit"].ToString());
            }

            if (Connection.Exp_Multiple_CHA_IcegateID_enable(COMPANY_ID) == "Y")
            {
                ddl_MultipleIcegate_YN = "Y";
            }

            if (Connection.Audit_Logs(COMPANY_ID) == "Y")
            {
                Audit_YN = "Y";
            }

            txtCustomsHouse.Attributes.Add("onblur", "javascript:CallServerside_Custom_House_Name('" + txtCustomsHouse.ClientID + "', '" + hdn_CustomsHouse_Name.ClientID + "')");
            txt_PortOfLoading.Attributes.Add("onblur", "javascript:CallServerside_PortOfLoading('" + txt_PortOfLoading.ClientID + "', '" + hdn_PortOfLoading.ClientID + "')");

            //txtExporterName.Attributes.Add("onblur", "javascript:CallServerside_Importer('" + txtExporterName.ClientID + "', '" + txtIECNo.ClientID + "')");
            //txtExporterName.Attributes.Add("onblur", "javascript:CallServerside_Importer_STD('" + txtExporterName.ClientID + "', '" + txtIECNo.ClientID + "')");
            //txtExporterName.Attributes.Add("onblur", "javascript:CallServerside_Importer_STD('" + txtExporterName.ClientID + "', '" + hd_Brslno.ClientID + "')");
            //txtExporterName.Attributes.Add("onblur", "javascript:CallServerside_Importer_STD('" + txtExporterName.ClientID + "', '" + hd_Brslno.ClientID + "', '" + txtAdcode.Text + "')");

            //txtBranchNo.Attributes.Add("onblur", "javascript:CallServerside_Importer_Branch('" + txtBranchNo.ClientID + "', '" + txtIECNo.ClientID + "', '" + hdn_New_Update.Value + "', '" + txtJobNo.Text + "')"); // This line placed in below, by chithra- 14-Feb-2018
            txtConsigneeName.Attributes.Add("onblur", "javascript:CallServerside_Consignee('" + txtConsigneeName.ClientID + "', '" + hdn_Consignee_brSlNo.ClientID + "')");
            txtConsignee_BranchSlNo.Attributes.Add("onblur", "javascript:CallServerside_Consignee('" + txtConsigneeName.ClientID + "', '" + txtConsignee_BranchSlNo.ClientID + "')");
            txtStateExport.Attributes.Add("onblur", "javascript:CallServerside_State_of_Export('" + txtStateExport.ClientID + "')");
            txtStateExport.Attributes.Add("onkeyup", "javascript:CallServerside_State_of_Export('" + txtStateExport.ClientID + "')");

            if (!IsPostBack)
            {

                Load_Mandatory_Flags();

                //if (Connection.Ryal() != string.Empty)
                //{
                //    txt_FF_Jobno.Attributes.Add("readonly", "readonly");
                //    txt_FF_Jobno.Visible = true;
                //    ND.Visible = false;
                //    WD.Visible = true;
                //}

                /*Hided by Tamil(13-03-2026)
                if (COMPANY_ID == "1" || COMPANY_ID == "2" || COMPANY_ID == "10" || COMPANY_ID == "350" || COMPANY_ID == "485" || COMPANY_ID == "534" 
                    || COMPANY_ID == "576" || COMPANY_ID == "744" || COMPANY_ID == "919" || COMPANY_ID == "2349" || COMPANY_ID == "2563" || COMPANY_ID == "3209"
                    || COMPANY_ID == "3305" || COMPANY_ID == "480" || COMPANY_ID == "1011" || COMPANY_ID == "1019" || COMPANY_ID == "1176" || COMPANY_ID == "1277")
                {
                    Acc_Charge.Visible = true;
                    Acc_fin.Visible = true;
                }
                else
                {
                    Acc_Charge.Visible = false;
                }*/
                bool showTabs = new[] { "1","2","10","350","485","534","576","919",
                        "2349","2563","3209","3305","480","1011","1019","1176","1277","1280","1698","3267"}
                      .Contains(COMPANY_ID);

                 bool showEntitytab=new []{"1","10"}.Contains(COMPANY_ID);
                Acc_Charge.Visible = showTabs;
                Acc_fin.Visible = showTabs;
                Acc_Exp_Entity.Visible = showEntitytab;
                if (COMPANY_ID == "744")
                {
                    Acc_Charge_Sun.Visible = true;
                    Acc_fin.Visible = true;
                }
                if (COMPANY_ID == "293")
                {
                    if (currentuser.ToUpper() == "ACCOUNTS" || currentuser.ToUpper() == "RTSAC")
                    {
                        Acc_Charge.Visible = true;
                        Acc_fin.Visible = true;
                    }
                    else
                    {
                        Acc_Charge.Visible = false;
                        Acc_fin.Visible = false;
                    }
                }
                if (COMPANY_ID == "3004")
                {
                    if (currentuser.ToUpper() == "BILLING" || currentuser.ToUpper() == "ADMIN" || currentuser.ToUpper() == "RTS")
                    {
                        Acc_Charge.Visible = true;
                        Acc_fin.Visible = true;
                    }
                    else
                    {
                        Acc_Charge.Visible = false;
                        Acc_fin.Visible = false;
                    }
                }
                if (COMPANY_ID == "3196")
                {
                    if (currentuser.ToUpper() == "CHAVAN" || currentuser.ToUpper() == "PATADE" || currentuser.ToUpper() == "RTS")
                    {
                        Acc_Charge.Visible = true;
                        Acc_fin.Visible = true;
                    }
                    else
                    {
                        Acc_Charge.Visible = false;
                        Acc_fin.Visible = false;
                    }
                }

                /*if (COMPANY_ID == "10" || COMPANY_ID == "1579" || COMPANY_ID == "2188" || COMPANY_ID == "3196" || COMPANY_ID == "3198" || COMPANY_ID == "3200" || COMPANY_ID == "3219" || COMPANY_ID == "3277" || COMPANY_ID == "3280" || COMPANY_ID == "3282")
                {
                    btnSignedBE.Visible = true;
                }
                else
                {
                    btnSignedBE.Visible = false;
                }*/
                Premium_Services();

                if (Connection.Ryal() != string.Empty)
                {
                    txt_FF_Jobno.Attributes.Add("readonly", "readonly");
                    txt_FF_Jobno.Visible = true;

                    WD.Visible = true;
                    if (COMPANY_ID == "243")
                    {
                        ND.Visible = true;
                    }
                    else
                    {
                        ND.Visible = false;
                    }

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


                if (Connection.e_WayBill("E") == "Y")
                {
                    E_Way_Bill.Visible = true;
                }


                txtJobDate.Text = dt.Today_Date();
                Screen_Id = 12;
                Page_Rights(Screen_Id);

                // FOR AGILITY-  Delete option enabled for All the Export Pages - here General page Delete button only enabled False except below users.. 
                /*if ((Connection.COMPANYID() == "747") && (Connection.Current_User().ToUpper() != "ADMIN" && Connection.Current_User().ToUpper() != "KARTHIK" && Connection.Current_User().ToUpper() != "SURESH" && Connection.Current_User().ToUpper() != "SOWMIYAN" && Connection.Current_User().ToUpper() != "MARIAPPAN" && Connection.Current_User().ToUpper() != "JEGAN" && Connection.Current_User().ToUpper() != "KANNAN" && Connection.Current_User().ToUpper() != "BALAKRISHNAN"))
                {
                    btnDelete.Enabled = false;
                    btnDelete.ToolTip = "You don't have permission to access";
                }*/
                ////-------------------------------end----------------------------------------------------

                if (COMPANY_ID == "381" || COMPANY_ID == "382" || COMPANY_ID == "385" || COMPANY_ID == "394" || COMPANY_ID == "461" || COMPANY_ID == "480" || COMPANY_ID == "508" || COMPANY_ID == "511" || COMPANY_ID == "4")
                {
                    divparty_ref.Visible = true;
                }
                else
                {
                    divparty_ref.Visible = false;
                }

                if (COMPANY_ID == "1029" || COMPANY_ID == "4" || COMPANY_ID == "10")
                {
                    lbl_CartingPoint.Visible = true;
                    txt_CartingPoint.Visible = true;
                }
                else
                {
                    lbl_CartingPoint.Visible = false;
                    txt_CartingPoint.Visible = false;
                }

                if (Connection.Billing_YN("Export") == "Y")
                {
                    Exp_Billing_Others1.Visible = true;
                }
                else
                {
                    Exp_Billing_Others1.Visible = false;
                }

                if (COMPANY_ID == "1135")
                {
                    check_marks_nos_FEMA.Visible = true;
                }


                if (Request.QueryString["Page"] == "New")
                {
                    F.Visible = true;
                    S.Visible = false;
                    btnnew1.Visible = true;
                    btn_Masedit.Visible = false;
                    btn_Consigneenew1.Visible = true;
                    btn_ConsigneeMasedit.Visible = false;

                    if (Connection.e_lOGIX_CHENNAI() != string.Empty)
                    {
                        txt_Ref_Loc.Enabled = true;
                        ddl_Ref_Type.Enabled = true;
                    }

                    hdn_New_Update.Value = "New";

                    txtExporterName.Attributes.Add("onblur", "javascript:CallServerside_Importer_STD('" + txtExporterName.ClientID + "', '" + hd_Brslno.ClientID + "', '" + hdn_New_Update.Value + "', '" + txtJobNo.Text + "')");
                    txtBranchNo.Attributes.Add("onblur", "javascript:CallServerside_Importer_Branch('" + txtBranchNo.ClientID + "', '" + txtIECNo.ClientID + "', '" + hdn_New_Update.Value + "', '" + txtJobNo.Text + "')");

                    hdn_Jobno.Value = "";

                    Session.Remove("EXPORT_JOBNO");
                    Session.Remove("TRANSPORT_MODE");
                    Session.Remove("EXPORT_JOBDATE");
                    Session.Remove("EXPORTER_NAME");

                    Session.Remove("CONSIGNEE_NAME");
                    Session.Remove("CONSIGNEE_ADDRESS1");
                    Session.Remove("CONSIGNEE_ADDRESS2");
                    Session.Remove("CONSIGNEE_ADDRESS3");
                    Session.Remove("CONSIGNEE_ADDRESS4");
                    Session.Remove("CONSIGNEE_ADDRESS5");
                    Session.Remove("SB_NO");
                    Session["SB_NO"] = "";
                    Session.Remove("Buyer_Master_Job_edit");
                    Session.Remove("CONSIGNEE_Master_Job_New");
                    Session.Remove("CONSIGNEE_Master_Job_edit");

                    ddlTransportMode.Items.Clear();

                    load_Tr_Mode();

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


                    //******** start adding to include freight jobs on 23-Mar-22 ***********//
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
                    //******** end- adding to include freight jobs on 23-Mar-22 ***********//


                    /*
                    string Category_mode = "";
                    if (TRANS_MODE == "A")
                        Category_mode = "Air";
                    if (TRANS_MODE == "S")a
                        Category_mode = "Sea";
                    if (TRANS_MODE == "L")
                        Category_mode = "Land";

                    if (Connection.COMPANYID() == "589")// Eswar Logistics
                    {
                        ddlTransportMode.Items.Add("Air");
                        ddlTransportMode.Items.Add("Sea");
                        ddlTransportMode.Items.Add("Land");
                        ddlTransportMode.Items.Remove(Category_mode);
                        ddlTransportMode.Items.Insert(0, Category_mode);
                    }
                    else
                    {
                        ddlTransportMode.Items.Add(Category_mode);
                    }
                    */
                    txtCustomsHouse.Text = Session["CUSTOMHOUSE_CODE"].ToString();

                    if (COMPANY_ID == "2501" || COMPANY_ID == "2526" || COMPANY_ID == "2537" || COMPANY_ID == "6002") // Added by shanthini COMPANY_ID == "6002" 03/06/2026
                    {
                        txt_PortOfLoading.Text = Session["CUSTOMHOUSE_CODE"].ToString();
                        hdn_PortOfLoading_chk.Value = Set_Customs_House_Validation(txt_PortOfLoading.Text);// Added by pandiyan for validating the portofloading values 26/04/2025
                    }

                    if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00183" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00747" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00004" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00005")
                    {
                        check_marks_nos.Checked = true;
                        txtMarksNos.Text = "WE INTEND TO CLAIM REWARDS UNDER MERCHANDISE EXPORTS FROM INDIA SCHEME (MEIS)";
                    }
                    hdn_Comp_License.Value = Session["COMPANY_LICENSE"].ToString().ToLower();

                    if (COMPANY_ID == "10" || COMPANY_ID == "517" || COMPANY_ID == "1")
                    {
                        //btnPDFUpload.Visible = true;
                        btnPDFUpload_New.Visible = true;
                        btnPDFUpload_AI.Visible = true;
                    }

                }
                else
                {
                    btn_Sahi_ExcelUpload.Visible = false;
                    hdn_Jobno.Value = txtJobNo.Text;
                    //btnPDFUpload.Visible = false;
                }


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

                txtJobDate.Focus();
                btnSave.Attributes.Add("onclick", "return validate1();");
                btnsavenext.Attributes.Add("onclick", "return validate1();");

                btnNew.Attributes.Add("onclick", "jQuery('#form1').validationEngine('detach');");
                btnUpdate.Attributes.Add("onclick", "return validate1();");

                ddlSBType.Items.Clear();

                if (COMPANY_ID == "753")// Ashraf Cargo
                {
                    ddlSBType.Items.Add("Drawback");
                    ddlSBType.Items.Add("Free Duty");
                    ddlSBType.Items.Add("License");
                    ddlSBType.Items.Add("EOU");
                    ddlSBType.Items.Add("98-Scheme");
                    ddlSBType.Items.Add("99-NFEI Scheme");
                    ddlSBType.Items.Add("SEZ");

                }
                else if (COMPANY_ID == "2501" || COMPANY_ID == "2526" || COMPANY_ID == "2537" || COMPANY_ID == "3073" || COMPANY_ID == "3087" || COMPANY_ID == "3089" || COMPANY_ID == "6002") //Added by shanthini COMPANY_ID == "6002" 03/06/2026
                {
                    ddlSBType.Items.Add("SEZ");
                }
                else
                {
                    ddlSBType.Items.Add("Free Duty");
                    ddlSBType.Items.Add("License");
                    ddlSBType.Items.Add("Drawback");
                    ddlSBType.Items.Add("EOU");
                    ddlSBType.Items.Add("98-Scheme");
                    ddlSBType.Items.Add("99-NFEI Scheme");
                    ddlSBType.Items.Add("SEZ");
                }


                ddl_Type();
                //--------------- dont delete-------------------------------------//

                txtIECNo.Attributes.Add("readonly", "readonly");
                txtAddress.Attributes.Add("readonly", "readonly");
                txtAddress2.Attributes.Add("readonly", "readonly");
                txtAddress3.Attributes.Add("readonly", "readonly");
                txtAddress4.Attributes.Add("readonly", "readonly");
                txtAddress5.Attributes.Add("readonly", "readonly");
                //txt_GSTN_ID.Attributes.Add("readonly", "readonly");

                if (Session["COMPANY_LICENSE"] != null)
                {
                    if (Connection.Get_User_Exp_Settings_Job_Edit("GENERAL_CONSIGNEE_ADD_EDIT") == "D")
                    {
                        txtConsigneeAddress.Attributes.Add("readonly", "readonly");
                        txtConsigneeAddress1.Attributes.Add("readonly", "readonly");
                        txtConsigneeAddress2.Attributes.Add("readonly", "readonly");
                        txtConsigneeAddress3.Attributes.Add("readonly", "readonly");
                        txtConsigneeAddress4.Attributes.Add("readonly", "readonly");
                    }
                }

                //txtConsigneeAddress4.Attributes.Add("readonly", "readonly");
                txtBankAccount.Attributes.Add("readonly", "readonly");
                hdn_Customhouse_chk.Value = Set_Customs_House_Validation(txtCustomsHouse.Text);

                //--------------- dont delete--------------------------------------//
                Get_Client_Default_Settings();
                Edit_GeneralDetails();

                if (ddlTransportMode.SelectedValue == "Air")
                {
                    this.btn_Annexure.Attributes.Add("onClick", "jQuery('#form1').validationEngine('detach');Open_Annexure_C();return false;");
                }
                else if (ddlTransportMode.SelectedValue == "Sea")
                {
                    this.btn_Annexure.Attributes.Add("onClick", "jQuery('#form1').validationEngine('detach');Open_Annexure_C();return false;");
                }
                else if (ddlTransportMode.SelectedValue == "Land")
                {
                    this.btn_Annexure.Attributes.Add("onClick", "jQuery('#form1').validationEngine('detach');Open_Annexure_C();return false;");
                }

                hdfTransport_mode.Value = ddlTransportMode.SelectedValue.ToString();
                Session["hdfTransport_mode"] = hdfTransport_mode.Value;
            }


            //#------ PageRights Settings-----------------
            if (user_Create.IMP_EXP_MASTER_yn == "False")
            {
                ND.Visible = false;
                WD.Visible = false;
                dv_mas_adcode_popup.Visible = false;
                dv_mas_brlso_popup.Visible = false;
                btnnew1.Visible = false;
                btn_Masedit.Visible = false;
            }

            if (user_Create.CONSIGNEE_MASTER_yn == "False")
            {
                dv_mas_consignee_popup.Visible = false;
                dv_mas_consign_brsl_popup.Visible = false;
                btn_Consigneenew1.Visible = false;
                btn_ConsigneeMasedit.Visible = false;
                btn_Adcode_new.Visible = false;

                txtConsigneeName.Enabled = false;
                txtConsignee_BranchSlNo.Enabled = false;
            }

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
                    COMPANY_ID = Session["COMPANY_ID"].ToString();
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

            if (txtSB_No.Text != string.Empty && txtSB_Date.Text != string.Empty && txtCustomsHouse.Text != string.Empty)
            {
                lblTrkSBNo.Visible = true;
            }
            else
            {
                lblTrkSBNo.Visible = false;
            }
            hdsaveandclose.Value = "No";

            if (COMPANY_ID == "1" || COMPANY_ID == "4" || COMPANY_ID == "10" || COMPANY_ID == "499" || COMPANY_ID == "517" || COMPANY_ID == "2501" || COMPANY_ID == "2526" || COMPANY_ID == "2537")//ORIENTAL CLEARING AGENCIES (MUMBAI)
            {
                btngenexcel.Visible = true;
            }
            if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00001" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00010" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00004" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00499" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00526") //ORIENTAL CLEARING AGENCIES (MUMBAI)
            {
                btn_XML_Upload.Visible = true;
                btn_Reliance_XML.Visible = true;

                if (Request.QueryString["Page"] == "New" && Shahi_btn_view == "")
                {
                    btn_Sahi_ExcelUpload.Visible = true;
                }
            }
            if (COMPANY_ID == "1125" || COMPANY_ID == "1103" || COMPANY_ID == "589" || COMPANY_ID == "1572" || COMPANY_ID == "2537")
            {
                if (Request.QueryString["Page"] == "New" && Shahi_btn_view == "")
                {
                    btn_Sahi_ExcelUpload.Visible = true;
                }
            }
            else if (COMPANY_ID == "196" && currentbranch == "ACC, Banglore" || currentbranch == "ICD,  Banglore") //ORIENTAL CLEARING AGENCIES (MUMBAI)
            {
                btn_Sahi_ExcelUpload.Visible = true;
            }

            if (ddlSBType.SelectedItem.Text == "SEZ")
            {
                Lbl_Imp_Exp_Type.Style.Add("display", "block");
                ddl_Impexp_Type.Style.Add("display", "block");
            }
            else
            {
                Lbl_Imp_Exp_Type.Style.Add("display", "none");
                ddl_Impexp_Type.Style.Add("display", "none");
            }

            txtCountryDischarge.Attributes.Add("onblur", "javascript:CallServerside_CountryDischarge('" + txtCountryDischarge.ClientID + "', '" + ddlTransportMode.ClientID + "')");
            txtPortDischarge.Attributes.Add("onblur", "javascript:CallServerside_PortDischarge('" + txtPortDischarge.ClientID + "', '" + ddlTransportMode.ClientID + "')");

            txtCountryFinalDestination.Attributes.Add("onblur", "javascript:CallServerside_CountryFinalDestination('" + txtCountryFinalDestination.ClientID + "', '" + ddlTransportMode.ClientID + "')");
            txtPortFinalDestination.Attributes.Add("onblur", "javascript:CallServerside_PortFinalDestination('" + txtPortFinalDestination.ClientID + "', '" + ddlTransportMode.ClientID + "')");

            txtStateExport.Attributes.Add("onblur", "javascript:CallServerside_State_of_Export('" + txtStateExport.ClientID + "')");
            Elogix_Chennai_Service();
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
            Transact.SEARCH_CAT = ""; Transact.SEARCH_ITEM = ""; Transact.TRANSPORT_MODE = ddlTransportMode.SelectedValue.ToString(); Transact.CUSTOMS_HOUSE = "";
            Transact.Ename = ""; Transact.WORKING_PERIOD = currentbranch;
            if (ddlTransportMode.SelectedValue.ToString() == "Air")
            {
                Transact.flag = "Export-Air";
            }
            else if (ddlTransportMode.SelectedValue.ToString() == "Sea")
            {
                Transact.flag = "Export-Sea";
            }
            else if (ddlTransportMode.SelectedValue.ToString() == "Land")
            {
                Transact.flag = "Export-Land";
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

            if (COMPANY_ID == "10" || COMPANY_ID == "11" || COMPANY_ID == "2373")// for "Areawise Job" Only
            {
                //JobNo_Prefix_Sufix("TrMode_Change");
                JobNo_Prefix_Sufix();
            }
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
            txtFile_Ref_no.Text = ddlFreightJobs.SelectedValue.ToString();
            DataSet ds = new DataSet();
            Transact.SEARCH_CAT = ""; Transact.SEARCH_ITEM = ddlFreightJobs.SelectedItem.ToString();
            Transact.WORKING_PERIOD = currentbranch; Transact.TRANSPORT_MODE = ddlTransportMode.SelectedValue.ToString();


            if (ddlTransportMode.SelectedValue.ToString() == "Air")
            {
                Transact.flag = "Export-Air-JobNo";
            }
            else if (ddlTransportMode.SelectedValue.ToString() == "Sea")
            {
                Transact.flag = "Export-Sea-JobNo";
            }
            else if (ddlTransportMode.SelectedValue.ToString() == "Land")
            {
                Transact.flag = "Export-Other-Jobno";
            }

            ds = Transact.FREIGHT_IMP_EXP_Job_Load();
            if (ds.Tables.Count > 0)
            {
                Session.Remove("FRT_EXP_JOBNO_CHA");
                Session["FRT_EXP_JOBNO_CHA"] = ddlFreightJobs.SelectedItem.ToString();



                if (ds.Tables[0].Rows.Count > 0)
                {

                    txtExporterName.Text = ds.Tables[0].Rows[0]["CLIENT_NAME"].ToString();
                    txtIECNo.Text = ds.Tables[0].Rows[0]["IECNO"].ToString();
                    txtAdcode.Text = ds.Tables[0].Rows[0]["ADCODE"].ToString();
                    txtBranchNo.Text = ds.Tables[0].Rows[0]["BRANCHNO"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["ADDRESS1"].ToString();
                    txtAddress2.Text = ds.Tables[0].Rows[0]["ADDRESS2"].ToString();
                    txtAddress3.Text = ds.Tables[0].Rows[0]["ADDRESS3"].ToString();
                    txtAddress4.Text = ds.Tables[0].Rows[0]["ADDRESS4"].ToString();
                    txtAddress5.Text = ds.Tables[0].Rows[0]["ADDRESS5"].ToString();


                    txtCountryDischarge.Text = ds.Tables[0].Rows[0]["COUNTRYORIGIN"].ToString();
                    txtCountryFinalDestination.Text = ds.Tables[0].Rows[0]["COUNTRYOFSHIPMENT"].ToString();
                    //txtPortOrigin.Text = ds.Tables[0].Rows[0]["PORTOFORIGIN"].ToString();

                    txtPortFinalDestination.Text = ds.Tables[0].Rows[0]["PORTOFSHIPMENT"].ToString();

                    hdn_FRT_GroupID.Value = ds.Tables[0].Rows[0]["GROUP_ID"].ToString();
                    hdn_FRT_Branch.Value = ds.Tables[0].Rows[0]["BRANCHCODE"].ToString();
                }
                if (txtAddress.Text == "" || txtAddress2.Text == "")
                {
                    eroyalmaster erm = new eroyalmaster();
                    DataSet dsAdd = new DataSet();
                    erm.Ename = "Get_ClientAddress";
                    erm.Eimp_exp_name = txtExporterName.Text;
                    dsAdd = erm.RetrieveAll_Imp_exp_master_STD_TYPE();
                    if (dsAdd.Tables[0].Rows.Count > 0)
                    {
                        txtAddress.Text = dsAdd.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
                        txtAddress2.Text = dsAdd.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
                        txtAddress3.Text = dsAdd.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
                        txtAddress4.Text = dsAdd.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
                        txtAddress5.Text = dsAdd.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();
                    }

                }

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }



    }

    private void Load_JobEdit()
    {
        try
        {
            if (Connection.Get_User_Exp_Settings_Job_Edit("GENERAL_JOB_EDIT") == "E")
            {
                btnedit.Visible = true;
            }
            txtid.Text = string.Empty;
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

            if (i == 13)
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
        bool Is_Page = false;
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
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        return Is_Page;
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
    public void ddl_Type()
    {
        try
        {
            ddlType.Items.Clear();
            ddlType.Items.Add("");
            ddlType.Items.Add("01-Free Trade Sample");
            ddlType.Items.Add("02-Diplomatic Goods");
            ddlType.Items.Add("03-Warranty Replacement");
            ddlType.Items.Add("04-Currency Chest");
            ddlType.Items.Add("05-Tourist Goods");
            ddlType.Items.Add("06-Defence Goods");
            ddlType.Items.Add("07-Gift Parcel");
            ddlType.Items.Add("08-Others");
            ddlType.Items.Add("09-DTA SB");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }


    }
    public void Edit_GeneralDetails()
    {
        try
        {
            //load_Tr_Mode();
            if (Request.QueryString["JOBID"] != "" && Request.QueryString["JOBID"] != null)
            {
                F.Visible = false;
                S.Visible = true;
                btnnew1.Visible = false;
                btn_Masedit.Visible = true;
                btn_Consigneenew1.Visible = false;
                btn_ConsigneeMasedit.Visible = true;

                hdn_Customhouse_chk.Value = "Yes";
                hdnCountryDischarge_chk.Value = "Yes";
                hdnPortDischarge_chk.Value = "Yes";
                hdnCountryFinalDestination_chk.Value = "Yes";
                hdnPortFinalDestination_chk.Value = "Yes";

                hdn_Jobno.Value = "1";
                hd_joblck.Value = "No";

                int i = 0;
                HiddenField1.Value = Request.QueryString["JOBID"].ToString();

                gridbind();
                if (dtuser.Tables[0].Rows.Count > 0)
                {


                    btn_Tr_Mode_Change.Visible = true;
                    txtjobPS.Text = dtuser.Tables[0].Rows[0]["JOBNO_PS"].ToString() == "" ? dtuser.Tables[0].Rows[0]["JOBNO"].ToString() : dtuser.Tables[0].Rows[0]["JOBNO_PS"].ToString();
                    Session["JOBNO_PS"] = txtjobPS.Text;

                    hdprefix.Value = dtuser.Tables[0].Rows[0]["JOB_PREFIX"].ToString() == null ? string.Empty : dtuser.Tables[0].Rows[0]["JOB_PREFIX"].ToString();
                    hdsuffix.Value = dtuser.Tables[0].Rows[0]["JOB_SUFFIX"].ToString() == null ? string.Empty : dtuser.Tables[0].Rows[0]["JOB_SUFFIX"].ToString();

                    hd_Brslno.Value = dtuser.Tables[0].Rows[0]["BRANCH_NO"].ToString();
                    txtJobNo.Text = dtuser.Tables[0].Rows[0]["JOBNO"].ToString();
                    Session["Jobno_Excel"] = txtJobNo.Text;

                    txt_E_jobno.Text = txtJobNo.Text;
                    txt_M_jobps.Text = dtuser.Tables[0].Rows[0]["JOB_PREFIX"].ToString() == null ? string.Empty : dtuser.Tables[0].Rows[0]["JOB_PREFIX"].ToString();
                    txt_M_jobsf.Text = dtuser.Tables[0].Rows[0]["JOB_SUFFIX"].ToString() == null ? string.Empty : dtuser.Tables[0].Rows[0]["JOB_SUFFIX"].ToString();

                    hdn_New_Update.Value = "Update";
                    txtExporterName.Attributes.Add("onblur", "javascript:CallServerside_Importer_STD('" + txtExporterName.ClientID + "', '" + hd_Brslno.ClientID + "', '" + hdn_New_Update.Value + "', '" + txtJobNo.Text + "')");
                    txtBranchNo.Attributes.Add("onblur", "javascript:CallServerside_Importer_Branch('" + txtBranchNo.ClientID + "', '" + txtIECNo.ClientID + "', '" + hdn_New_Update.Value + "', '" + txtJobNo.Text + "')");

                    txtJobDate.Text = dtuser.Tables[0].Rows[0]["JOBDATE"].ToString();
                    txtSB_No.Text = dtuser.Tables[0].Rows[0]["SB_NO"].ToString();
                    Session["SB_NO"] = txtSB_No.Text;

                    txtSB_Date.Text = dtuser.Tables[0].Rows[0]["SB_DATE"].ToString();

                    string mode = dtuser.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();
                    ddlTransportMode.Items.Clear();
                    /*
                    SELECT_BRANCH = Connection.Get_Company_Type();
                    if (SELECT_BRANCH != "")
                    {
                        ddlTransportMode.Items.Insert(0, mode);
                    }
                    else
                    {
                        ddlTransportMode.Items.Add("Air");
                        ddlTransportMode.Items.Add("Sea");
                        ddlTransportMode.Items.Add("Land");
                        ddlTransportMode.Items.Remove(mode);
                        ddlTransportMode.Items.Insert(0, mode);
                    }
                    */
                    load_Tr_Mode();
                    ddlTransportMode.SelectedValue = mode;
                    Load_JobEdit();
                    hdn_Edit_TransportMode.Value = mode;
                    Session["Transport_Mode_Port"] = mode;

                    string BE_type = dtuser.Tables[0].Rows[0]["SB_TYPE"].ToString();

                    if (COMPANY_ID == "753")
                    {
                        ddlSBType.Items.Clear();
                        ddlSBType.Items.Add("Free Duty");
                        ddlSBType.Items.Add("License");
                        ddlSBType.Items.Add("Drawback");
                        ddlSBType.Items.Add("EOU");
                        ddlSBType.Items.Add("98-Scheme");
                        ddlSBType.Items.Add("99-NFEI Scheme");
                        ddlSBType.Items.Add("SEZ");

                        ddlSBType.Items.Remove(BE_type);
                        ddlSBType.Items.Insert(0, BE_type);
                    }
                    else if (COMPANY_ID == "2501" || COMPANY_ID == "2526" || COMPANY_ID == "2537" || COMPANY_ID == "6002") //Added by shanthini COMPANY_ID == "6002" on 03-06-2026
                    {
                        ddlSBType.Items.Clear();
                        ddlSBType.Items.Add("SEZ");
                    }
                    else
                    {
                        ddlSBType.Items.Clear();
                        ddlSBType.Items.Add("Free Duty");
                        ddlSBType.Items.Add("License");
                        ddlSBType.Items.Add("Drawback");
                        ddlSBType.Items.Add("EOU");
                        ddlSBType.Items.Add("98-Scheme");
                        ddlSBType.Items.Add("99-NFEI Scheme");
                        ddlSBType.Items.Add("SEZ");

                        ddlSBType.Items.Remove(BE_type);
                        ddlSBType.Items.Insert(0, BE_type);
                    }


                    if (BE_type == "SEZ")
                    {
                        ETP.Visible = true;
                        DTA.Visible = true;
                    }
                    else
                    {
                        ETP.Visible = true;
                        DTA.Visible = false;
                    }

                    txtCustomsHouse.Text = dtuser.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                    hdn_CustomsHouse_Name.Value = dtuser.Tables[0].Rows[0]["CUSTOMS_HOUSE_NAME"].ToString();
                    hdn_Customhouse_chk.Value = Set_Customs_House_Validation(txtCustomsHouse.Text);

                    if (!string.IsNullOrEmpty(Session["Client_Master_Job_edit"] as string))
                    {
                        //Get_ClientMaster_edit_details("select_branch", "");
                    }
                    else
                    {
                        txtExporterName.Text = dtuser.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                        txtIECNo.Text = dtuser.Tables[0].Rows[0]["IEC_NO"].ToString();
                        txtBranchNo.Text = dtuser.Tables[0].Rows[0]["BRANCH_NO"].ToString();
                        txtAddress.Text = dtuser.Tables[0].Rows[0]["ADDRESS1"].ToString();
                        txtAddress2.Text = dtuser.Tables[0].Rows[0]["ADDRESS2"].ToString();
                        txtAddress3.Text = dtuser.Tables[0].Rows[0]["ADDRESS3"].ToString();
                        txtAddress4.Text = dtuser.Tables[0].Rows[0]["ADDRESS4"].ToString();
                        txtAddress5.Text = dtuser.Tables[0].Rows[0]["ADDRESS5"].ToString();
                        ddlType_Exp.SelectedValue = dtuser.Tables[0].Rows[0]["TYPE_OF_EXPORTER"].ToString() == "" ? "F" : dtuser.Tables[0].Rows[0]["TYPE_OF_EXPORTER"].ToString();
                        txtMarksNos.Text = dtuser.Tables[0].Rows[0]["MARKS_NO"].ToString();
                        ddl_GSTN_Type.SelectedValue = dtuser.Tables[0].Rows[0]["GSTN_TYPE"].ToString();
                        txt_GSTN_ID.Text = dtuser.Tables[0].Rows[0]["GSTN_ID"].ToString();
                        txtDrawbackAccount.Text = dtuser.Tables[0].Rows[0]["DRAWBACK_ACCOUNT"].ToString();
                    }
                    Session.Remove("Client_Master_Job_edit");

                    txtAdcode.Text = dtuser.Tables[0].Rows[0]["ADCODE"].ToString();

                    if (COMPANY_ID == "1572")
                    {
                        if (txtExporterName.Text == "Shahi Exports Pvt. Ltd." && txtIECNo.Text == "0588085481")
                        {
                            txtExporterName.Enabled = false;
                            txtAddress.Enabled = false;
                            txtAddress2.Enabled = false;
                            txtAddress3.Enabled = false;
                            txtAddress4.Enabled = false;
                            txtAddress5.Enabled = false;
                            txtIECNo.Enabled = false;
                            txtBranchNo.Enabled = false;
                            txtAdcode.Enabled = false;
                        }
                    }

                    txtBankAccount.Text = dtuser.Tables[0].Rows[0]["BANK_ACCOUNT"].ToString();

                    txtConsigneeName.Text = dtuser.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                    txtConsignee_BranchSlNo.Text = dtuser.Tables[0].Rows[0]["CONSIGNEE_BRANCHSLNO"].ToString();
                    txtConsigneeAddress.Text = dtuser.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();
                    txtConsigneeAddress1.Text = dtuser.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString();
                    txtConsigneeAddress2.Text = dtuser.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString();
                    txtConsigneeAddress3.Text = dtuser.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString();
                    txtConsigneeAddress4.Text = dtuser.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString();

                    txtCountryDischarge.Text = dtuser.Tables[0].Rows[0]["COUNTRY_DISCHARGE"].ToString();
                    hdnCountryDischarge_chk.Value = Ser_CountryDischarge(txtCountryDischarge.Text, ddlTransportMode.SelectedItem.Text);

                    txtPortDischarge.Text = dtuser.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString();
                    hdnPortDischarge_chk.Value = Ser_CountryFinalDestination(txtPortDischarge.Text, ddlTransportMode.SelectedItem.Text);

                    txtCountryFinalDestination.Text = dtuser.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString();
                    hdnCountryFinalDestination_chk.Value = Ser_CountryDischarge(txtCountryFinalDestination.Text, ddlTransportMode.SelectedItem.Text);

                    txtPortFinalDestination.Text = dtuser.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
                    txtStateExport.Text = dtuser.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString();
                    ddl_Impexp_Type.SelectedValue = dtuser.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();
                    hdn_ExporterType.Value = dtuser.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();
                    Session["IMP_EXP_TYPE"] = hdn_ExporterType.Value;//Added by pandiyan on 05-06-2025
                    hdn_State_of_export_chk.Value = Set_State_of_Export(txtStateExport.Text);
                    string NFEI = dtuser.Tables[0].Rows[0]["NFEI"].ToString();
                    ddlNFEI.Items.Clear();
                    ddlNFEI.Items.Add("No");
                    ddlNFEI.Items.Add("Yes");
                    ddlNFEI.Items.Remove(NFEI);
                    ddlNFEI.Items.Insert(0, NFEI);

                    if (ddlNFEI.SelectedValue == "Yes")
                    {
                        string type = dtuser.Tables[0].Rows[0]["NFEI_TYPE"].ToString();
                        ddlType.Items.Clear();
                        ddlType.Items.Add("");
                        ddlType.Items.Add("01-Free Trade Sample");
                        ddlType.Items.Add("02-Diplomatic Goods");
                        ddlType.Items.Add("03-Warranty Replacement");
                        ddlType.Items.Add("04-Currency Chest");
                        ddlType.Items.Add("05-Tourist Goods");
                        ddlType.Items.Add("06-Defence Goods");
                        ddlType.Items.Add("07-Gift Parcel");
                        ddlType.Items.Add("08-Others");
                        ddlType.Items.Add("09-DTA SB");
                        ddlType.Items.Remove(type);
                        ddlType.Items.Insert(0, type);

                        ddlType.Enabled = true;
                        txtRBIWaiverNo.Enabled = true;
                        txtRBIWaiverDate.Enabled = true;
                    }
                    else
                    {

                        ddlType.Enabled = false;
                        txtRBIWaiverNo.Enabled = false;
                        txtRBIWaiverDate.Enabled = false;
                    }

                    txtRBIWaiverNo.Text = dtuser.Tables[0].Rows[0]["RBI_WAIVER_NO"].ToString();
                    txtRBIWaiverDate.Text = dtuser.Tables[0].Rows[0]["RBI_WAIVER_DATE"].ToString().Replace("01/01/1900", "");

                    txtFile_Ref_no.Text = dtuser.Tables[0].Rows[0]["FILE_REF_NO"].ToString();

                    JOB_LOCK = dtuser.Tables[0].Rows[0]["JOB_STATUS"].ToString();
                    JOB_RELEASE = dtuser.Tables[0].Rows[0]["JOB_RELEASE"].ToString();
                    JOB_USER = dtuser.Tables[0].Rows[0]["USERID"].ToString();



                    txt_CartingPoint.Text = dtuser.Tables[0].Rows[0]["CARTING_POINT"].ToString();
                    txt_IFSCCode.Text = dtuser.Tables[0].Rows[0]["IFSC_CODE"].ToString();

                    txt_PortOfLoading.Text = dtuser.Tables[0].Rows[0]["PORT_OF_LOADING"].ToString();
                    //ddl_Impexp_Type.SelectedValue = dtuser.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();
                    hdn_PortOfLoading_chk.Value = Set_Customs_House_Validation(txt_PortOfLoading.Text);

                    if (dtuser.Tables[0].Rows[0]["SB_NO"].ToString() != "")
                    {
                        div_AmendmentType.Visible = true;
                        ddl_AmendmentType.SelectedValue = dt.Replace(dtuser.Tables[0].Rows[0]["AMENDMENT_TYPE"].ToString());
                    }

                    //--------------CAPRICORN - MULTIPLE CHA NO-Load - 19-01-2024 --------------------
                    ddl_Multiple_CHA_No.SelectedValue = dtuser.Tables[0].Rows[0]["ICE_ID"].ToString() + "-" + dtuser.Tables[0].Rows[0]["CHA_NO"].ToString();


                    Session["JOB_LOCK"] = JOB_LOCK;
                    Session["JOB_RELEASE"] = JOB_RELEASE;
                    Session["JOB_USER"] = JOB_USER;


                    /*
                     if (Connection.I_Fact() != string.Empty)
                     {
                         DataSet s = new DataSet();
                         txt_FF_Jobno.Visible = true;
                         I_FACT IF = new I_FACT();
                         s = IF.Get_I_Fact_Jobno(dtuser.Tables[0].Rows[0]["JOBNO"].ToString(), "E");
                         if (s.Tables[0].Rows.Count > 0)
                         {
                             txt_FF_Jobno.Text = s.Tables[0].Rows[0]["FF_JOBNO"].ToString();

                         }
                         else
                         {
                             txt_FF_Jobno.Text = string.Empty;
                         }
                     }
                     else
                     {
                         txt_FF_Jobno.Visible = false;
                         txt_FF_Jobno.Text = string.Empty;
                     }
                     */
                    if (Connection.Freight_Forward() != string.Empty)
                    {
                        DataSet s = new DataSet();
                        txt_FF_Jobno.Visible = true;
                        if (COMPANY_ID == "")
                        {
                            I_FACT IF = new I_FACT();
                            s = IF.Get_I_Fact_Jobno(dtuser.Tables[0].Rows[0]["JOBNO"].ToString(), "E");
                        }
                        else if (COMPANY_ID == "861")
                        {
                            ICode_CS IC = new ICode_CS();
                            s = IC.Get_ICode_Jobno_Select(dtuser.Tables[0].Rows[0]["JOBNO"].ToString(), "E", "FF_Jobno", "", "861");
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
                        else
                        {
                            txt_FF_Jobno.Text = string.Empty;
                        }

                        //added by jayanthi on 11-feb-2021
                        //if (COMPANY_ID == "752" && dtuser.Tables.Count > 1)

                        if ((COMPANY_ID == "752" || COMPANY_ID == "2814" || COMPANY_ID == "3082" || COMPANY_ID == "3153" || COMPANY_ID == "3253") && dtuser.Tables.Count > 1)
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
                    //*Start Freight Forwarding*****//
                    if (dtuser.Tables[0].Rows.Count > 0)
                    {

                        if (dtuser.Tables[0].Rows[0]["FRT_JOBNO"].ToString() != null && dtuser.Tables[0].Rows[0]["FRT_JOBNO"].ToString() != "0")
                        {
                            load_FRT_JOBS();
                            ddlFreightJobs.SelectedValue = dtuser.Tables[0].Rows[0]["FRT_JOBNO"].ToString();
                            Session["FRT_IMP_JOBNO_CHA"] = ddlFreightJobs.SelectedValue.ToString();
                            ddlFreightJobs.Enabled = false;
                        }
                        if (dtuser.Tables[0].Rows[0]["FRT_GROUPID"].ToString() != null)
                        {
                            hdn_FRT_GroupID.Value = dtuser.Tables[0].Rows[0]["FRT_GROUPID"].ToString();
                        }
                        if (dtuser.Tables[0].Rows[0]["FRT_BRANCHCODE"].ToString() != null)
                        {
                            hdn_FRT_Branch.Value = dtuser.Tables[0].Rows[0]["FRT_BRANCHCODE"].ToString();
                        }
                    }
                    //*End  Freight Forwarding*****//

                    Session.Remove("TRANSPORT_MODE");
                    Session.Remove("EXPORT_JOBNO");
                    Session.Remove("EXPORT_JOBDATE");
                    Session.Remove("EXPORT_SBTYPE");
                    Session.Remove("EXPORTER_NAME");

                    Session["TRANSPORT_MODE"] = ddlTransportMode.SelectedValue.ToString();
                    Session["EXPORT_JOBNO"] = txtJobNo.Text;
                    Session["EXPORT_JOBDATE"] = txtJobDate.Text;
                    Session["EXPORT_SBTYPE"] = ddlSBType.SelectedValue.ToString();
                    Session["EXPORTER_NAME"] = txtExporterName.Text;

                    Elogix_Chennai_Ref_Service("");
                }
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = Request.QueryString["JOBID"].ToString();
                Get_Session_Consignee_Address();
                txtCustomsHouse.Enabled = true;

                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btn_Annexure.Enabled = true;
                btnsavenext.Visible = false;

                //------------------Audit Modified column History-------------------
                if (Audit_YN == "Y")
                {
                    Tbl_Filed_Modified_History(dtuser.Tables[1]);
                }
                //-----------------------------------------------------------------
            }
            else
            {
                if (!IsPostBack)
                {
                    AUTO_JOBNO();
                }

                hdfTransport_mode.Value = ddlTransportMode.SelectedValue.ToString();
                Session["Transport_Mode_Port"] = ddlTransportMode.SelectedValue.ToString();

                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btnsavenext.Visible = true;

                btnNew.Visible = true;
                ddl_NFEI();
                btn_Annexure.Enabled = false;
            }
            /*if (!IsPostBack)
            {
                if (Connection.e_lOGIX_CHENNAI() != string.Empty)
                {
                    if (COMPANY_ID != "4")
                    {
                        txtFile_Ref_no.Attributes.Add("readonly", "readonly");
                        txtFile_Ref_no.Style.Add("background-color", "#F0F0F0");
                    }
                
                }
                else
                {
                    txtFile_Ref_no.Attributes.Remove("readonly");
                    txtFile_Ref_no.Style.Add("background-color", "white");
                }
            }*/
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
            Export.JOBID = HiddenField1.Value;
            Export.JOBNO = "";
            Export.EXPORTER_NAME = "";
            Export.TRANSPORT_MODE = "";
            Export.CUSTOMS_HOUSE = "";
            Export.Ename = "select_Id";
            Export.WORKING_PERIOD = SELECT_BRANCH;
            dtuser = Export.RetrieveAll_General_Details();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

        return dtuser;
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

    public void AUTO_JOBNO()
    {
        try
        {
            Export.BRANCH_CODE = SELECT_BRANCH;
            Export.WORKING_PERIOD = Working_Period;
            txtJobNo.Text = Convert.ToString(Export.Retrieve_JobNO());

            /*
            if (COMPANY_ID == "10" || COMPANY_ID == "11" || COMPANY_ID == "2373")// for "Areawise Job" Only
            {
                JobNo_Prefix_Sufix("TrMode_Change");
            }
            else
            {
                JobNo_Prefix_Sufix("New");
            }
            */
            JobNo_Prefix_Sufix();
            Session["Jobno_Excel"] = txtJobNo.Text;

            if (COMPANY_ID == "1011")
            {
                txtFile_Ref_no.Text = txtjobPS.Text;
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

            if (COMPANY_ID == "293" || COMPANY_ID == "1")
            {
                JPS.Branch = Connection.Current_Branch();
                JPS.Ename = "Imp_Exp_gen_293_select";
                JPS.BranchType = "E";
            }
            else if (COMPANY_ID == "2349")
            {
                JPS.Branch = Connection.Current_Branch();
                JPS.Ename = "Imp_Exp_gen_2349_select";
                JPS.BranchType = "E";
            }
            else
            {
                JPS.Branch = SELECT_BRANCH;
                JPS.Ename = "Exp_gen_select";
                JPS.Tr_mode = ddlTransportMode.SelectedItem.Text;
                JPS.BranchType = SELECT_TYPE;
            }
            dats = JPS.Job_prefix_Suffix_Select_Areawise();

            /*
            JPS.Branch = SELECT_BRANCH;
            JPS.Ename = "Exp_gen_select";
            JPS.Tr_mode = ddlTransportMode.SelectedItem.Text;
         
            if (Type == "TrMode_Change")
            {
                dats = JPS.Job_prefix_Suffix_Select_Areawise();
            }
            else
            {
                dats = JPS.Job_prefix_Suffix_Select();
            }
             dats = JPS.Job_prefix_Suffix_Select_Areawise();
            */



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
                            txtjobPS.Text = txtJobNo.Text + "/" + ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                            hdprefix.Value = string.Empty;
                            hdsuffix.Value = ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                        }
                        else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                        {
                            txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + txtJobNo.Text).TrimEnd()).TrimStart();
                            //txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + JobNo).TrimEnd()).TrimStart();
                            hdprefix.Value = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                            hdsuffix.Value = string.Empty;
                        }
                        else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                        {
                            txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + txtJobNo.Text + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                            //txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + JobNo + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                            hdprefix.Value = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                            hdsuffix.Value = ((dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                        }
                        else if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                        {
                            txtjobPS.Text = txtJobNo.Text;
                            hdprefix.Value = string.Empty;
                            hdsuffix.Value = string.Empty;
                        }
                    }
                    else
                    {
                        txtjobPS.Text = txtJobNo.Text;
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
                            txtjobPS.Text = txtJobNo.Text + "/" + ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                            hdprefix.Value = string.Empty;
                            hdsuffix.Value = ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                        }
                        else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                        {
                            //txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + "/" + txtJobNo.Text).TrimEnd()).TrimStart();
                            if (Connection.COMPANYID() == "1163" || Connection.COMPANYID() == "1164" || Connection.COMPANYID() == "1165" || Connection.COMPANYID() == "1166")
                            {
                                txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + "/" + JobNo).TrimEnd()).TrimStart();
                            }
                            else
                            {
                                txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + "/" + txtJobNo.Text).TrimEnd()).TrimStart();
                            }
                            hdprefix.Value = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                            hdsuffix.Value = string.Empty;
                        }
                        else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                        {
                            // txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + "/" + txtJobNo.Text + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                            if (Connection.COMPANYID() == "1163" || Connection.COMPANYID() == "1164" || Connection.COMPANYID() == "1165" || Connection.COMPANYID() == "1166")
                            {
                                txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + "/" + JobNo + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                            }
                            else
                            {
                                txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + "/" + txtJobNo.Text + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                            }

                            hdprefix.Value = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                            hdsuffix.Value = ((dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                        }
                        else if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                        {
                            txtjobPS.Text = txtJobNo.Text;
                            hdprefix.Value = string.Empty;
                            hdsuffix.Value = string.Empty;
                        }
                    }
                    else
                    {
                        txtjobPS.Text = txtJobNo.Text;
                        hdprefix.Value = string.Empty;
                        hdsuffix.Value = string.Empty;
                    }
                }
                Session["JOBNO_PS"] = txtjobPS.Text;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public int Export_General_Insert_Update(string Flag)
    {
        try
        {
            Export.JOBNO = txtJobNo.Text;
            Export.JOBDATE = txtJobDate.Text;
            Export.TRANSPORT_MODE = ddlTransportMode.SelectedValue.ToString();
            Export.SB_TYPE = ddlSBType.SelectedValue.ToString();
            Export.CUSTOMS_HOUSE = txtCustomsHouse.Text;
            Export.CUSTOMS_HOUSE_NAME = hdn_CustomsHouse_Name.Value;
            Export.EXPORTER_NAME = txtExporterName.Text.Trim();
            Export.BRANCH_NO = txtBranchNo.Text.Trim();
            Export.IEC_NO = txtIECNo.Text.Trim();
            Export.ADDRESS1 = txtAddress.Text;
            Export.ADDRESS2 = txtAddress2.Text;
            Export.ADDRESS3 = txtAddress3.Text;
            Export.ADDRESS4 = txtAddress4.Text;
            Export.ADDRESS5 = txtAddress5.Text;
            Export.ADCODE = txtAdcode.Text;
            Export.BANK_ACCOUNT = txtBankAccount.Text;
            Export.DRAWBACK_ACCOUNT = txtDrawbackAccount.Text;
            Export.CONSIGNEE_NAME = txtConsigneeName.Text;
            Export.CONSIGNEE_ADD1 = txtConsigneeAddress.Text;
            Export.CONSIGNEE_ADD2 = txtConsigneeAddress1.Text;
            Export.CONSIGNEE_ADD3 = txtConsigneeAddress2.Text;
            Export.CONSIGNEE_ADD4 = txtConsigneeAddress3.Text;
            Export.CONSIGNEE_ADD5 = txtConsigneeAddress4.Text;
            Export.COUNTRY_DISCHARGE = txtCountryDischarge.Text;
            Export.PORT_DISCHARGE = txtPortDischarge.Text;
            Export.COUNTRY_FINAL_DEST = txtCountryFinalDestination.Text;
            Export.PORT_FINAL_DEST = txtPortFinalDestination.Text;
            Export.STATE_OF_EXPORT = txtStateExport.Text;
            Export.NFEI = ddlNFEI.SelectedValue.ToString();
            if (ddlNFEI.SelectedValue.ToString() != "No")
            {
                Export.NFEI_TYPE = ddlType.SelectedValue.ToString();
                Session["NFEI_TYPE"] = ddlType.SelectedValue.ToString();
            }
            else
            {
                Export.NFEI_TYPE = "";
            }
            Export.RBI_WAIVER_NO = txtRBIWaiverNo.Text;
            string dt;
            if (txtRBIWaiverDate.Text != "")
            {
                dt = txtRBIWaiverDate.Text;

            }
            else
            {
                dt = "01/01/1900";
            }
            Export.RBI_WAIVER_DATE = dt;

            if (check_marks_nos.Checked == true)
            {
                if (Session["COMPANY_LICENSE"] != null)
                {
                    if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00004")
                    {
                        txtMarksNos.Text = "I/WE DECLARE THAT THE PARTICULARS GIVEN HEREIN ARE TRUE AND ARE CORRECT,I/WE UNDERTAKE TO ABIDE BY PROVISIONS OF FOREIGN EXCHANGE MANAGEMENT ACT 1999,AS AMENDED FROM TIME TO TIME INCLUDING REALISATION/RESPATRIATION OF FOREIGNEXCHANGE TO FROM INDIA.";
                    }
                }
            }


            Export.MARKS_NO = txtMarksNos.Text;
            Export.USER_ID = currentuser;
            Export.flag = Flag;
            Export.BRANCH_CODE = currentbranch;
            Export.WORKING_PERIOD = Working_Period;
            Export.FILE_REF_NO = txtFile_Ref_no.Text.ToUpper();

            Export.BRANCH_COMMON = SELECT_BRANCH;
            Export.TYPE_OF_EXPORTER = ddlType_Exp.SelectedValue.ToString();
            Export.JOBNO_PS = txtjobPS.Text;

            Export.JOB_PREFIX = hdprefix.Value.ToString();
            Export.JOB_SUFFIX = hdsuffix.Value.ToString();

            Export.CONSIGNEE_BRANCHSLNO = txtConsignee_BranchSlNo.Text;
            Export.GSTN_TYPE = ddl_GSTN_Type.SelectedValue.ToString();
            Export.GSTN_ID = txt_GSTN_ID.Text.Trim();

            Export.PARTY_REF_NO = txtParty_RefNo.Text;
            Export.CARTING_POINT = txt_CartingPoint.Text;
            Export.IFSC_CODE = txt_IFSCCode.Text;

            // *********** start aded to link Freight jobs **************//
            Export.FRT_JOBNO = "";
            if (ddlFreightJobs.SelectedIndex > 0)
            {
                Export.FRT_JOBNO = ddlFreightJobs.SelectedValue.ToString();
                Export.FRT_BRANCHCODE = hdn_FRT_Branch.Value;
                Export.FRT_GROUPID = hdn_FRT_GroupID.Value;
            }
            // *********** start aded to link Freight jobs **************//

            Export.AMENDMENT_TYPE = ddl_AmendmentType.SelectedValue;
            Export.AMENDMENT_STATUS = "";
            Export.PORT_OF_LOADING = txt_PortOfLoading.Text;
            if (ddlSBType.SelectedItem.Text == "SEZ")
            {
                Export.IMP_EXP_TYPE = ddl_Impexp_Type.SelectedValue.ToString();

            }
            else
            {
                Export.IMP_EXP_TYPE = hdn_ExporterType.Value;
                Session["IMP_EXP_TYPE"] = hdn_ExporterType.Value;//taken by pandiyan on 05/06/2025
            }
            hdn_Customhouse_chk.Value = Set_Customs_House_Validation(txtCustomsHouse.Text);

            if (ddl_MultipleIcegate_YN == "Y")
            {
                if (ddl_Multiple_CHA_No.SelectedItem.Text != "")
                {
                    string[] splt = ddl_Multiple_CHA_No.SelectedItem.Text.Split('-');

                    Export.ICE_ID = splt[0];
                    Export.CHA_NO = splt[1];
                    Session.Remove("Multiple_ICE_ID");
                    Session["Multiple_ICE_ID"] = splt[0];
                }
            }
            else
            {
                Export.ICE_ID = "";
                Export.CHA_NO = "";
            }

            i = Export.General_details_insertupdate();

            if (i == 1)
            {
                hdn_Edit_TransportMode.Value = ddlTransportMode.SelectedValue.ToString();
                Get_Session_Consignee_Address();
                Export.Exp_Job_Logs_All_Details(txtJobNo.Text, "", "", "General", Flag, "Insert");

            }
            ddl_NFEI();

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return i;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtJobNo.Text != "" && txtJobDate.Text != "")
        {
            try
            {
                if (!Check_Mandatory_Fields())
                    return;

                string F = "S";
                i = Export_General_Insert_Update(F);

                HiddenField1.Value = Convert.ToString(trans.UPDATE_ID);
                if (i == 1)
                {
                    hdn_Jobno.Value = "1";

                    btn_Annexure.Enabled = true;
                    Session.Remove("TRANSPORT_MODE");
                    Session.Remove("EXPORT_JOBNO");
                    Session.Remove("EXPORT_JOBDATE");
                    Session.Remove("EXPORT_SBTYPE");
                    Session.Remove("JOB_USER");
                    Session.Remove("EXPORTER_NAME");
                    Session.Remove("NFEI_TYPE");

                    Session["TRANSPORT_MODE"] = ddlTransportMode.SelectedValue.ToString();
                    Session["EXPORT_JOBNO"] = txtJobNo.Text;
                    Session["EXPORT_JOBDATE"] = txtJobDate.Text;
                    Session["EXPORT_SBTYPE"] = ddlSBType.SelectedValue.ToString();
                    Session["EXPORTER_NAME"] = txtExporterName.Text;
                    Session["NFEI_TYPE"] = ddlType.SelectedValue.ToString();

                    Session["JOB_USER"] = currentuser;
                    txtJobNo.Focus();

                    if (ddlSBType.SelectedValue.ToString() == "SEZ")
                    {
                        ETP.Visible = true;
                    }
                    else
                    {
                        ETP.Visible = false;
                    }

                    /*
                    if (Connection.Ryal() != string.Empty)
                    {
                        Ryal_Service("S");
                    }
                    */
                    if (Connection.Freight_Forward() != string.Empty)
                    {
                        if (COMPANY_ID == "752" || COMPANY_ID == "2814" || COMPANY_ID == "3082" || COMPANY_ID == "3153" || COMPANY_ID == "3253")
                        {
                            Ryal_Service("S");
                        }
                        else if (COMPANY_ID == "861" || COMPANY_ID == "880")
                        {
                            ICode_CS IC = new ICode_CS();
                            IC.Get_ICode_Jobno_Select(txtJobNo.Text, "E", "CHA_Jobno_Update", txt_FF_Jobno.Text, COMPANY_ID);
                        }

                    }
                    if (COMPANY_ID == "115" || COMPANY_ID == "3288") // Added by pandiyan for Copper Api Process 
                    {
                        API_Post_Data Gen = new API_Post_Data();
                        Gen.General_Details_API_Post(txtJobNo.Text, Connection.WorkingPeriod(), "E", "JSON", Connection.Current_Branch());
                    }

                    if (ddl_Ref_Type.SelectedValue.ToString() == "M")
                    {
                        Elogix_Chennai_Ref_Service("S");
                    }

                    ViewState["UPDATED_ID"] = null;
                    //-----------------------FOR USER RIGHTS--------------------------------//
                    user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);
                    PAGE_MODIFY = user_Create.PAGE_MODIFY;


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
                    Alert_msg_Save("Saved Successfully", "btnSave");//session create in autosearch webservice file
                    btn_Tr_Mode_Change.Visible = true;


                    txt_E_jobno.Text = txtJobNo.Text;
                    txt_M_jobps.Text = hdprefix.Value.ToString();
                    txt_M_jobsf.Text = hdsuffix.Value.ToString();
                    hd_joblck.Value = "No";
                    Load_JobEdit();

                    if (Session["USER_JOB_LOCK"].ToString() == "Yes")
                    {
                        job_release.Visible = true;
                    }
                    else
                    {
                        job_release.Visible = false;
                    }

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
                    Alert_msg("Job Not Saved", "btnSave");
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
            hdn_Jobno.Value = "";
            Alert_msg("Enter All Mandatory Field", "btnSave");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtJobNo.Text != "" && txtJobDate.Text != "")
        {
            try
            {
                string F = "U";
                i = Export_General_Insert_Update(F);
                if (i == 1)
                {
                    hdn_Jobno.Value = "1";
                    btn_Annexure.Enabled = true;
                    Session.Remove("TRANSPORT_MODE");
                    Session.Remove("EXPORT_JOBNO");
                    Session.Remove("EXPORT_JOBDATE");
                    Session.Remove("EXPORT_SBTYPE");
                    Session.Remove("JOB_USER");
                    Session.Remove("EXPORTER_NAME");
                    Session.Remove("NFEI_TYPE");

                    Session["TRANSPORT_MODE"] = ddlTransportMode.SelectedValue.ToString();
                    Session["EXPORT_JOBNO"] = txtJobNo.Text;
                    Session["EXPORT_JOBDATE"] = txtJobDate.Text;
                    Session["EXPORT_SBTYPE"] = ddlSBType.SelectedValue.ToString();
                    Session["JOB_USER"] = currentuser;
                    Session["EXPORTER_NAME"] = txtExporterName.Text;
                    Session["NFEI_TYPE"] = ddlType.SelectedValue.ToString();

                    /*
                    if (Connection.Ryal() != string.Empty)
                    {
                        string str = txt_FF_Jobno.Text;
                        Ryal_Service("U");
                    }
                    */
                    if (Connection.Freight_Forward() != string.Empty)
                    {
                        if (COMPANY_ID == "752" || COMPANY_ID == "2814" || COMPANY_ID == "3082" || COMPANY_ID == "3153" || COMPANY_ID == "3253")
                        {
                            string str = txt_FF_Jobno.Text;
                            Ryal_Service("U");
                        }
                        else if (COMPANY_ID == "861" || COMPANY_ID == "880")
                        {
                            ICode_CS IC = new ICode_CS();
                            IC.Get_ICode_Jobno_Select(txtJobNo.Text, "E", "CHA_Jobno_Update", txt_FF_Jobno.Text, COMPANY_ID);
                        }
                    }

                    txtJobNo.Focus();

                    // ----Audit Modified Data -----------------------------------
                    if (Audit_YN == "Y")
                    {
                        Audit_Modified_DataTableComparer();
                    }
                    //------------------------------------------------------------

                    if (ViewState["UPDATED_ID"] != null)
                    {
                        Alert_msg("Updated Successfully", "btnUpdate");
                    }
                    else
                    {
                        Alert_msg("Saved Successfully", "btnUpdate");
                    }
                    Elogix_Service("U");
                }
                else if (i == 2)
                {
                    hdn_Jobno.Value = "";
                    Alert_msg("Job No Already Exist!", "btnUpdate");
                }
                else if (i == 3)
                {
                    hdn_Jobno.Value = "";
                    Alert_msg("File Ref. No Already Exist! Not Update", "btnUpdate");
                }
                else
                {
                    hdn_Jobno.Value = "";
                    Alert_msg("Job Not Updated", "btnUpdate");
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
            hdn_Jobno.Value = "";
            Alert_msg("Enter All Mandatory Field");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Export.JOBNO = txtJobNo.Text;
            Export.EXPORTER_NAME = "0";
            Export.TRANSPORT_MODE = "0";
            Export.CUSTOMS_HOUSE = "0";
            Export.Ename = "delete";
            Export.WORKING_PERIOD = SELECT_BRANCH;
            ds = Export.RetrieveAll_ExpGeneral_Details_datatablefrmDelJobs();

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {

                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Visible = true;
                    btnsavenext.Visible = true;
                    // Elogix_Service("D");

                    if (Connection.Freight_Forward() != string.Empty)
                    {
                        if (COMPANY_ID == "861" || COMPANY_ID == "880")
                        {
                            ICode_CS IC = new ICode_CS();
                            IC.Get_ICode_Jobno_Select(txtJobNo.Text, "E", "CHA_Jobno_Delete", txt_FF_Jobno.Text, COMPANY_ID);
                        }
                    }

                    string prompt = "<script>$(document).ready(function(){{jAlert('Job Deleted', 'GENERAL', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent_1();} else {}});}});</script>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);

                    OCR_Delete_Jobs(txtJobNo.Text);
                    Export.Exp_Job_Logs_All_Details(Connection.EXP_Jobno(), "", "", "General", "D", "Insert");
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

    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            F.Visible = false;
            S.Visible = true;
            btnnew1.Visible = true;
            btn_Masedit.Visible = false;
            btn_Consigneenew1.Visible = true;
            btn_ConsigneeMasedit.Visible = false;

            hdn_Jobno.Value = "";
            btn_Annexure.Enabled = false;
            trans.ResetFields(Page.Controls);
            Page_enable();
            txtJobDate.Text = dt.Today_Date();
            txtJobDate.Focus();
            AUTO_JOBNO();
            btnSave.Visible = true;
            btnsavenext.Visible = true;

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            ViewState["UPDATED_ID"] = null;
            hdn_Update_General.Value = "";
            Session.Remove("EXPORT_JOBNO");
            Session.Remove("TRANSPORT_MODE");
            Session.Remove("EXPORT_JOBDATE");
            // CONSIGNEE
            Session.Remove("CONSIGNEE_NAME");
            Session.Remove("CONSIGNEE_ADDRESS1");
            Session.Remove("CONSIGNEE_ADDRESS2");
            Session.Remove("CONSIGNEE_ADDRESS3");
            Session.Remove("CONSIGNEE_ADDRESS4");
            Session.Remove("CONSIGNEE_ADDRESS5");
            Session.Remove("EXPORTER_NAME");
            Session.Remove("Buyer_Master_Job_edit");
            Session.Remove("CONSIGNEE_Master_Job_New");
            Session.Remove("CONSIGNEE_Master_Job_edit");

            ddlTransportMode.Items.Clear();
            //-------------------------------FROM LOGIN PAGE BASED ON BRANCH SELECT-----------------//
            string TRANS_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();
            string Category_mode = "";
            if (TRANS_MODE == "A")
                Category_mode = "Air";
            if (TRANS_MODE == "S")
                Category_mode = "Sea";
            if (TRANS_MODE == "L")
                Category_mode = "Land";

            ddlTransportMode.Items.Add("Air");
            ddlTransportMode.Items.Add("Sea");
            ddlTransportMode.Items.Add("Land");
            ddlTransportMode.Items.Remove(Category_mode);
            ddlTransportMode.Items.Insert(0, Category_mode);

            txtCustomsHouse.Text = Session["CUSTOMHOUSE_CODE"].ToString();
            //-------------------------------FROM LOGIN PAGE BASED ON BRANCH SELECT-----------------//
            btn_Tr_Mode_Change.Visible = false;

            txtid.Text = string.Empty;
            btnedit.Visible = false;
            if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00001" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00010" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00004" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00499" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00526" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01103" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri01125") //ORIENTAL CLEARING AGENCIES (MUMBAI)
            {
                btn_Sahi_ExcelUpload.Visible = true;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public void ddl_NFEI()
    {
        try
        {
            if (ddlNFEI.SelectedValue == "Yes")
            {
                ddlType.Enabled = true;
                txtRBIWaiverNo.Enabled = true;
                txtRBIWaiverDate.Enabled = true;
            }
            else
            {
                ddlType.SelectedValue = "";
                ddlType.Enabled = false;
                txtRBIWaiverNo.Enabled = false;
                txtRBIWaiverDate.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    public void Get_Session_Consignee_Address()
    {
        try
        {
            //CONSIGNEE NAME
            Session.Remove("CONSIGNEE_NAME");
            Session.Remove("CONSIGNEE_ADDRESS1");
            Session.Remove("CONSIGNEE_ADDRESS2");
            Session.Remove("CONSIGNEE_ADDRESS3");
            Session.Remove("CONSIGNEE_ADDRESS4");
            Session.Remove("CONSIGNEE_ADDRESS5");
            Session.Remove("Buyer_Master_Job_edit");
            Session.Remove("CONSIGNEE_Master_Job_New");
            Session.Remove("CONSIGNEE_Master_Job_edit");

            Session["CONSIGNEE_NAME"] = txtConsigneeName.Text;
            Session["CONSIGNEE_ADDRESS1"] = txtConsigneeAddress.Text;
            Session["CONSIGNEE_ADDRESS2"] = txtConsigneeAddress1.Text;
            Session["CONSIGNEE_ADDRESS3"] = txtConsigneeAddress2.Text;
            Session["CONSIGNEE_ADDRESS4"] = txtConsigneeAddress3.Text;
            Session["CONSIGNEE_ADDRESS5"] = txtConsigneeAddress4.Text;
            //EXPORTER NAME

            Session.Remove("EXPORTER_NAME");
            Session.Remove("EXPORTER_IECNO");
            Session.Remove("EXPORTER_BRANCHSLNO");
            Session.Remove("EXPORTER_ADDRESS1");
            Session.Remove("EXPORTER_ADDRESS2");
            Session.Remove("EXPORTER_ADDRESS3");
            Session.Remove("EXPORTER_ADDRESS4");
            Session.Remove("EXPORTER_ADDRESS5");

            Session["EXPORTER_NAME"] = txtExporterName.Text;
            Session["EXPORTER_IECNO"] = txtIECNo.Text;
            Session["EXPORTER_BRANCHSLNO"] = txtBranchNo.Text;
            Session["EXPORTER_ADDRESS1"] = txtAddress.Text;
            Session["EXPORTER_ADDRESS2"] = txtAddress2.Text;
            Session["EXPORTER_ADDRESS3"] = txtAddress3.Text;
            Session["EXPORTER_ADDRESS4"] = txtAddress4.Text;
            Session["EXPORTER_ADDRESS5"] = txtAddress5.Text;
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
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {Export_session();document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btnsavenext_Click(object sender, EventArgs e)
    {
        try
        {
            btnSave_Click(sender, e);
            if (i == 1)
            {
                hdsaveandclose.Value = "Yes";
                hdn_Gen_Invoice_enable.Value = "Yes";
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public static string GetCustom_House_Name(string custid)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        string name = "", rows = "", custom_name;
        try
        {
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
            Auto.Ename = "IMP_EXP_MASTER_IMPORTER_SEARCH_ADCODE";
            Auto.Enamesearch = custid;
            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                string Adcode = "", Adcode_Bank_Account = "";
                string Address1 = ds.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
                string Address2 = ds.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
                string Address3 = ds.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
                string Address4 = ds.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
                string Address5 = ds.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();
                string Address6 = ds.Tables[0].Rows[0]["IMP_EXP_DRAWBACK_AC_NO"].ToString();

                string IECNo = ds.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString();
                string BranchNo = ds.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();
                if (ds.Tables[1].Rows.Count > 0)
                {
                    Adcode = ds.Tables[1].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                    Adcode_Bank_Account = ds.Tables[1].Rows[0]["ADCODE_BANK_ACCOUNT_NO"].ToString();
                }
                custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address5 + "~~" + IECNo + "~~" + BranchNo + "~~" + Adcode + "~~" + Adcode_Bank_Account + "~~" + Address6;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string GetImporter_Branchwise(string custid, string custid1, string custid_3, string Jobno)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            DataSet dss = new DataSet();

            string STD_Type = "";

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


            Auto.Ename = "IMP_EXP_MASTER_IMPORTER_BRANCH_WISE_ADCODE";
            Auto.Enamesearch = custid;
            Auto.NSearch = custid1;
            Auto.STANDARD_TYPE = STD_Type;

            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH_STD_Type();

            if (ds.Tables[0].Rows.Count > 0)
            {

                string Adcode = "", Adcode_Bank_Account = "", IFSC_Code = "";
                string IMP_EXP_NAME = ds.Tables[0].Rows[0]["IMP_EXP_NAME"].ToString();
                string Address1 = ds.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
                string Address2 = ds.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
                string Address3 = ds.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
                string Address4 = ds.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
                string Address5 = ds.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();
                string Address6 = ds.Tables[0].Rows[0]["IMP_EXP_DRAWBACK_AC_NO"].ToString();
                string IECNo = ds.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString();
                string BranchNo = ds.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();

                string TYPE_OF_EXPORTER = ds.Tables[0].Rows[0]["TYPE_OF_EXPORTER"].ToString();
                string MARKS_NOS = ds.Tables[0].Rows[0]["MARKS_NO"].ToString();
                string GSTN_TYPE = ds.Tables[0].Rows[0]["GSTN_TYPE"].ToString();
                string GSTN_ID = ds.Tables[0].Rows[0]["GSTN_ID"].ToString();

                //if (ds.Tables[1].Rows.Count > 0)
                //{
                //    if (ds.Tables[1].Rows.Count == 1)
                //    {
                //        Adcode = ds.Tables[1].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                //        Adcode_Bank_Account = ds.Tables[1].Rows[0]["ADCODE_BANK_ACCOUNT_NO"].ToString();
                //    }
                //    else
                //    {
                //        Adcode = "";
                //        Adcode_Bank_Account = "";
                //    }
                //}

                if (custid_3 == "Update")
                {
                    Auto.JobID = "";
                    Auto.Jobno = Jobno;
                    Auto.STANDARD_TYPE = STD_Type;
                    Auto.Ename = "Select_Adcode_from_ExportJob";
                    Auto.Enamesearch = custid;
                    Auto.NSearch = custid1;
                    Auto.Working_Period = Connection.Get_Company_Type();
                    ds = Auto.ERoyalmaste_Retrieve_ADCode_Export();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (IMP_EXP_NAME == ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString())
                        {
                            Adcode = ds.Tables[0].Rows[0]["ADCODE"].ToString();
                            Adcode_Bank_Account = ds.Tables[0].Rows[0]["BANK_ACCOUNT"].ToString();
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
                                        Adcode = dss.Tables[0].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                                        Adcode_Bank_Account = dss.Tables[0].Rows[0]["ADCODE_BANK_ACCOUNT_NO"].ToString();
                                        IFSC_Code = dss.Tables[0].Rows[0]["ADCODE_IFSC_CODE"].ToString();
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
                                    Adcode = dss.Tables[0].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                                    Adcode_Bank_Account = dss.Tables[0].Rows[0]["ADCODE_BANK_ACCOUNT_NO"].ToString();
                                    IFSC_Code = dss.Tables[0].Rows[0]["ADCODE_IFSC_CODE"].ToString();
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
                                Adcode = dss.Tables[0].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                                Adcode_Bank_Account = dss.Tables[0].Rows[0]["ADCODE_BANK_ACCOUNT_NO"].ToString();
                                IFSC_Code = dss.Tables[0].Rows[0]["ADCODE_IFSC_CODE"].ToString();
                            }
                        }
                    }
                }

                /*
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
                            Adcode = dss.Tables[0].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                            Adcode_Bank_Account = dss.Tables[0].Rows[0]["ADCODE_BANK_ACCOUNT_NO"].ToString();
                        }
                        //}
                        else
                        {
                            if (custid_3 == "Update")
                            {
                                Auto.JobID = "";
                                Auto.Jobno = Jobno;
                                Auto.STANDARD_TYPE = STD_Type;
                                Auto.Ename = "Select_Adcode_from_ExportJob";
                                Auto.Enamesearch = custid;
                                Auto.NSearch = custid1;
                                Auto.Working_Period = Connection.Get_Company_Type();
                                ds = Auto.ERoyalmaste_Retrieve_ADCode_Export();

                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    Adcode = ds.Tables[0].Rows[0]["ADCODE"].ToString();
                                    Adcode_Bank_Account = ds.Tables[0].Rows[0]["BANK_ACCOUNT"].ToString();
                                }
                            }
                            else
                            {
                                Adcode = "";
                                Adcode_Bank_Account = "";
                            }
                        }
                    }
                }
                */
                //custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address5 + "~~" + IECNo + "~~" + BranchNo + "~~" + Adcode + "~~" + Adcode_Bank_Account + "~~" + Address6;
                custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address5 + "~~" + IECNo + "~~" + BranchNo + "~~" + Adcode + "~~" + Adcode_Bank_Account + "~~" + Address6 + "~~" + TYPE_OF_EXPORTER + "~~" + MARKS_NOS + "~~" + GSTN_TYPE + "~~" + GSTN_ID + "~~" + IFSC_Code;

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Adcode(string custid, string iecno)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            string Address1 = "", Address2 = "";
            Auto.Ename = "ADCODE_MASTER_SEARCH";
            Auto.Enamesearch = custid;
            Auto.NSearch = iecno;
            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows.Count == 0)
                {
                    Address1 = ds.Tables[0].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                    Address2 = ds.Tables[0].Rows[0]["ADCODE_BANK_ACCOUNT_NO"].ToString();
                }
                custid = Address1 + "~~" + Address2;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_ConsigneeName(string custid, string Branchslno)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();

            if (Branchslno != "")
            {
                Auto.Ename = "CONSIGNEE_MASTER_SEARCH_with_BRANCH_SLNO";
            }
            else
            {
                Auto.Ename = "CONSIGNEE_MASTER_SEARCH";
            }

            Auto.Enamesearch = custid;
            Auto.NSearch = Branchslno;
            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

            if (ds.Tables[0].Rows.Count > 0)
            {

                string Address1 = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                string Address2 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();
                string Address3 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString();
                string Address4 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString();
                string Address5 = ds.Tables[0].Rows[0]["CONSIGNEE_COUNTRY_NAME"].ToString();
                string CONSIGNEE_PIN_CODE = ds.Tables[0].Rows[0]["CONSIGNEE_PIN_CODE"].ToString();

                string Address6 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString();
                string Branchslno1 = ds.Tables[0].Rows[0]["CONSIGNEE_BRANCHSLNO"].ToString();


                custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address6 + "~~" + Address5 + "~~" + Branchslno1;
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
            JL.Jobtype = "Export";
            JL.CURRENT_USER = currentuser;
            JL.JOBNO = Session["EXPORT_JOBNO"].ToString();
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
            EXP_JobEdit Jobedit = new EXP_JobEdit();
            if (Request.QueryString["JOBID"] != "" && Request.QueryString["JOBID"] != null)
            {

                if (hd_joblck.Value == "No")
                {
                    if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00247" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00010")
                    {
                        if (txt_M_jobps.Text == string.Empty && txt_M_jobsf.Text != string.Empty)
                        {
                            Jobedit.PS = txt_E_jobno.Text + "/" + ((txt_M_jobsf.Text).TrimStart()).TrimEnd();
                        }
                        else if (txt_M_jobps.Text != string.Empty && txt_M_jobsf.Text == string.Empty)
                        {
                            Jobedit.PS = ((txt_M_jobps.Text + txt_E_jobno.Text).TrimEnd()).TrimStart();
                        }
                        else if (txt_M_jobps.Text != string.Empty && txt_M_jobsf.Text != string.Empty)
                        {
                            Jobedit.PS = ((txt_M_jobps.Text + txt_E_jobno.Text + "/" + txt_M_jobsf.Text).TrimEnd()).TrimStart();
                        }
                        else if (txt_M_jobps.Text == string.Empty && txt_M_jobsf.Text == string.Empty)
                        {
                            Jobedit.PS = txt_E_jobno.Text;
                        }
                    }
                    else
                    {

                        if (txt_M_jobps.Text == string.Empty && txt_M_jobsf.Text != string.Empty)
                        {
                            Jobedit.PS = txt_E_jobno.Text + "/" + ((txt_M_jobsf.Text).TrimStart()).TrimEnd();
                        }
                        else if (txt_M_jobps.Text != string.Empty && txt_M_jobsf.Text == string.Empty)
                        {
                            Jobedit.PS = ((txt_M_jobps.Text + "/" + txt_E_jobno.Text).TrimEnd()).TrimStart();
                        }
                        else if (txt_M_jobps.Text != string.Empty && txt_M_jobsf.Text != string.Empty)
                        {
                            Jobedit.PS = ((txt_M_jobps.Text + "/" + txt_E_jobno.Text + "/" + txt_M_jobsf.Text).TrimEnd()).TrimStart();
                        }
                        else if (txt_M_jobps.Text == string.Empty && txt_M_jobsf.Text == string.Empty)
                        {
                            Jobedit.PS = txt_E_jobno.Text;
                        }
                    }
                    Jobedit.JOB_PREFIX = txt_M_jobps.Text;
                    Jobedit.JOB_SUFFIX = txt_M_jobsf.Text;

                    Jobedit.Old_Jobno = txtJobNo.Text;
                    Jobedit.Current_Jobno = txt_E_jobno.Text;
                    Jobedit.BRANCH_CODE = SELECT_BRANCH;
                    Jobedit.UserId = currentuser;
                    Jobedit.JopUpdate();

                    if (Jobedit.result == 1)
                    {
                        txtJobNo.Text = txt_E_jobno.Text;
                        txtjobPS.Text = Jobedit.PS;

                        Session.Remove("EXPORT_JOBNO");
                        Session["EXPORT_JOBNO"] = txtJobNo.Text;
                    }
                    else if (Jobedit.result == 2)
                    {
                        txtid.Text = "Job already exists";
                        EXP_MP_JOB.Show();
                    }
                    else if (Jobedit.result == 3)
                    {
                        txtid.Text = "Job already Filed Can't modify";
                        EXP_MP_JOB.Show();
                    }

                    /* if (hdprefix.Value.ToString() == string.Empty && hdsuffix.Value.ToString() != string.Empty)
                     {
                         Jobedit.PS = txt_E_jobno.Text + hdsuffix.Value.ToString();
                     }
                     else if (hdprefix.Value.ToString() != string.Empty && hdsuffix.Value.ToString() == string.Empty)
                     {
                         Jobedit.PS = hdprefix.Value.ToString() + txt_E_jobno.Text;
                     }
                     else if (hdprefix.Value.ToString() != string.Empty && hdsuffix.Value.ToString() != string.Empty)
                     {
                         Jobedit.PS = hdprefix.Value.ToString() + txt_E_jobno.Text + hdsuffix.Value.ToString();
                     }
                     else if (hdprefix.Value.ToString() == string.Empty && hdsuffix.Value.ToString() == string.Empty)
                     {
                         Jobedit.PS = txt_E_jobno.Text;
                     }

                     Jobedit.Old_Jobno = txtJobNo.Text;
                     Jobedit.Current_Jobno = txt_E_jobno.Text;
                     Jobedit.BRANCH_CODE = SELECT_BRANCH;
                     Jobedit.UserId = currentuser;
                     Jobedit.JopUpdate();

                     if (Jobedit.result == 1)
                     {
                         txtJobNo.Text = txt_E_jobno.Text;
                         txtjobPS.Text = Jobedit.PS;

                         Session.Remove("EXPORT_JOBNO");
                         Session["EXPORT_JOBNO"] = txtJobNo.Text;
                     }
                     else if (Jobedit.result == 2)
                     {
                         txtid.Text = "Job already exists";
                         EXP_MP_JOB.Show();
                     }
                     else if (Jobedit.result == 3)
                     {
                         txtid.Text = "Job already Filed Can't modify";
                         EXP_MP_JOB.Show();
                     } */
                }
                else if (hd_joblck.Value == "Yes")
                {
                    txtid.Text = "This Job Locked";
                    EXP_MP_JOB.Show();
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
                            Jobedit.PS = txt_E_jobno.Text + "/" + ((txt_M_jobsf.Text).TrimStart()).TrimEnd();
                        }
                        else if (txt_M_jobps.Text != string.Empty && txt_M_jobsf.Text == string.Empty)
                        {
                            Jobedit.PS = ((txt_M_jobps.Text + txt_E_jobno.Text).TrimEnd()).TrimStart();
                        }
                        else if (txt_M_jobps.Text != string.Empty && txt_M_jobsf.Text != string.Empty)
                        {
                            Jobedit.PS = ((txt_M_jobps.Text + txt_E_jobno.Text + "/" + txt_M_jobsf.Text).TrimEnd()).TrimStart();
                        }
                        else if (txt_M_jobps.Text == string.Empty && txt_M_jobsf.Text == string.Empty)
                        {
                            Jobedit.PS = txt_E_jobno.Text;
                        }
                    }
                    else
                    {

                        if (txt_M_jobps.Text == string.Empty && txt_M_jobsf.Text != string.Empty)
                        {
                            Jobedit.PS = txt_E_jobno.Text + "/" + ((txt_M_jobsf.Text).TrimStart()).TrimEnd();
                        }
                        else if (txt_M_jobps.Text != string.Empty && txt_M_jobsf.Text == string.Empty)
                        {
                            Jobedit.PS = ((txt_M_jobps.Text + "/" + txt_E_jobno.Text).TrimEnd()).TrimStart();
                        }
                        else if (txt_M_jobps.Text != string.Empty && txt_M_jobsf.Text != string.Empty)
                        {
                            Jobedit.PS = ((txt_M_jobps.Text + "/" + txt_E_jobno.Text + "/" + txt_M_jobsf.Text).TrimEnd()).TrimStart();
                        }
                        else if (txt_M_jobps.Text == string.Empty && txt_M_jobsf.Text == string.Empty)
                        {
                            Jobedit.PS = txt_E_jobno.Text;
                        }
                    }

                    Jobedit.JOB_PREFIX = txt_M_jobps.Text;
                    Jobedit.JOB_SUFFIX = txt_M_jobsf.Text;

                    Jobedit.Old_Jobno = txtJobNo.Text;
                    Jobedit.Current_Jobno = txt_E_jobno.Text;
                    Jobedit.BRANCH_CODE = SELECT_BRANCH;
                    Jobedit.UserId = currentuser;
                    Jobedit.JopUpdate();


                    if (Jobedit.result == 1)
                    {
                        txtJobNo.Text = txt_E_jobno.Text;
                        txtjobPS.Text = Jobedit.PS;

                        Session.Remove("EXPORT_JOBNO");
                        Session["EXPORT_JOBNO"] = txtJobNo.Text;
                    }
                    else if (Jobedit.result == 2)
                    {
                        txtid.Text = "Job already exists";
                        EXP_MP_JOB.Show();
                    }
                    else if (Jobedit.result == 3)
                    {
                        txtid.Text = "Job already Filed Can't modify";
                        EXP_MP_JOB.Show();
                    }
                }
                else if (hd_joblck.Value == "Yes")
                {
                    txtid.Text = "This Job Locked";
                    EXP_MP_JOB.Show();
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    [System.Web.Services.WebMethod]
    public static string GetImporter_2(string custid, string custid_2, string custid_3, string Jobno)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            DataSet dss = new DataSet();
            string STD_Type = "";

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

            Auto.Ename = "IMP_EXP_MASTER_IMPORTER_SEARCH_ADCODE";
            Auto.Enamesearch = custid;
            Auto.NSearch = custid_2;
            Auto.STANDARD_TYPE = STD_Type;

            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH_STD_Type();
            if (ds.Tables[0].Rows.Count > 0)
            {
                string Adcode = "", Adcode_Bank_Account = "", IFSC_Code = "";
                string Address1 = ds.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
                string Address2 = ds.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
                string Address3 = ds.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
                string Address4 = ds.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
                string Address5 = ds.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();
                string Address6 = ds.Tables[0].Rows[0]["IMP_EXP_DRAWBACK_AC_NO"].ToString();

                string IECNo = ds.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString();
                string BranchNo = ds.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();
                string TYPE_OF_EXPORTER = ds.Tables[0].Rows[0]["TYPE_OF_EXPORTER"].ToString();
                string MARKS_NOS = ds.Tables[0].Rows[0]["MARKS_NO"].ToString();
                string GSTN_TYPE = ds.Tables[0].Rows[0]["GSTN_TYPE"].ToString();
                string GSTN_ID = ds.Tables[0].Rows[0]["GSTN_ID"].ToString();
                string IMP_EXP_TYPE = ds.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();

                if (custid_3 == "Update")
                {
                    Auto.JobID = "";
                    Auto.Jobno = Jobno;
                    Auto.STANDARD_TYPE = STD_Type;
                    Auto.Ename = "Select_Adcode_from_ExportJob";
                    Auto.Enamesearch = custid;
                    Auto.NSearch = custid_2;
                    Auto.Working_Period = Connection.Get_Company_Type();
                    ds = Auto.ERoyalmaste_Retrieve_ADCode_Export();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (custid == ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString())
                        {
                            Adcode = ds.Tables[0].Rows[0]["ADCODE"].ToString();
                            Adcode_Bank_Account = ds.Tables[0].Rows[0]["BANK_ACCOUNT"].ToString();
                            IFSC_Code = ds.Tables[0].Rows[0]["IFSC_CODE"].ToString();
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
                                        Adcode = dss.Tables[0].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                                        Adcode_Bank_Account = dss.Tables[0].Rows[0]["ADCODE_BANK_ACCOUNT_NO"].ToString();
                                        IFSC_Code = dss.Tables[0].Rows[0]["ADCODE_IFSC_CODE"].ToString();
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
                                    Adcode = dss.Tables[0].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                                    Adcode_Bank_Account = dss.Tables[0].Rows[0]["ADCODE_BANK_ACCOUNT_NO"].ToString();
                                    IFSC_Code = dss.Tables[0].Rows[0]["ADCODE_IFSC_CODE"].ToString();
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
                                Adcode = dss.Tables[0].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                                Adcode_Bank_Account = dss.Tables[0].Rows[0]["ADCODE_BANK_ACCOUNT_NO"].ToString();
                                IFSC_Code = dss.Tables[0].Rows[0]["ADCODE_IFSC_CODE"].ToString();
                            }
                        }
                    }
                }

                custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address5 + "~~" + IECNo + "~~" + BranchNo + "~~" + Adcode + "~~" + Adcode_Bank_Account + "~~" + Address6 + "~~" + TYPE_OF_EXPORTER + "~~" + MARKS_NOS + "~~" + GSTN_TYPE + "~~" + GSTN_ID + "~~" + IFSC_Code + "~~" + IMP_EXP_TYPE;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }


        return custid;
    }

    public void Get_Client_Default_Settings()
    {
        try
        {
            Default_Settings Default = new Default_Settings();

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

    [System.Web.Services.WebMethod]
    public static string Ser_CountryDischarge(string custid, string custid_2)
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
    public static string Ser_CountryFinalDestination(string custid, string custid_2)
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
    public static string SetFileName(string FileName)
    {
        try
        {
            FileName = "cccc";
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return FileName;
    }

    private void Elogix_Service(string Flg)
    {
        try
        {
            Connection.e_lOGIX("E", Flg);
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

    private void Ryal_Service(string flg)
    {
        try
        {
            Ryal_CS RI = new Ryal_CS();
            Global_variables ObjUBO = new Global_variables();

            ObjUBO.A1 = Connection.EXP_Jobno();
            ObjUBO.A2 = txt_FF_Jobno.Text;
            ObjUBO.A3 = "E";
            ObjUBO.A4 = flg;
            RI.Ryal_Royal_Job_Update(ObjUBO);

            if (flg == "S")
            {
                if (Connection.COMPANYID() == "2814" || Connection.COMPANYID() == "3082" || Connection.COMPANYID() == "3153" || Connection.COMPANYID() == "3253")
                {
                    Connection.Ebms_JobRefno_Return(1, txt_FF_Jobno.Text, ObjUBO.A1, ObjUBO.A3);
                }
                else
                {
                    Connection.Ryal_JobRefno_Return(1, txt_FF_Jobno.Text, ObjUBO.A1); //*********IS LIVE IMPLEMENTATION********
                    //Connection.Ryal_JobRefno_Return(0, txt_FF_Jobno.Text, ObjUBO.A1); //*********IS TEST IMPLEMENTATION********
                }
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
                /* UserBO ObjUBO = new UserBO();
                 InvoSys_CS EL = new InvoSys_CS();

                 DataSet dss = new DataSet();
                 ObjUBO.JOBNO = Connection.EXP_Jobno();
                 ObjUBO.File_Type = "E";
                 ObjUBO.INVOICE_NO = txt_Ref_Loc.Text;
                 ObjUBO.INVOICE_SLNO = ddl_Ref_Type.SelectedValue.ToString();
                 if (flg == "S")
                 {
                     ObjUBO.flag = "S";
                     EL.E_Logix_Chennai_Ref(ObjUBO);
                 }
                 else
                 {
                     ObjUBO.flag = "Select";
                     dss = EL.E_Logix_Chennai_Ref(ObjUBO);
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

                 txt_Ref_Loc.Enabled = false;
                 ddl_Ref_Type.Enabled = false;
                 * */
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    [System.Web.Services.WebMethod]
    public static string Set_State_of_Export(string custid)
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


    private void Get_ClientMaster_edit_details(string ename, string IMP_EXP_ID)
    {
        try
        {
            eroyalmaster erm = new eroyalmaster();
            DataSet dtt_clnt = new DataSet();

            erm.Eimp_exp_id = IMP_EXP_ID;
            erm.Eimp_exp_name = txtExporterName.Text;
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
                txtExporterName.Text = dt.Replace(dtt_clnt.Tables[0].Rows[0]["IMP_EXP_NAME"].ToString());
                txtIECNo.Text = dt.Replace(dtt_clnt.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString());
                txtBranchNo.Text = dt.Replace(dtt_clnt.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString());
                txtAddress.Text = dt.Replace(dtt_clnt.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString());
                txtAddress2.Text = dt.Replace(dtt_clnt.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString());
                txtAddress3.Text = dt.Replace(dtt_clnt.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString());
                txtAddress4.Text = dt.Replace(dtt_clnt.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString());
                txtAddress5.Text = dt.Replace(dtt_clnt.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString());
                txtMarksNos.Text = dt.Replace(dtt_clnt.Tables[0].Rows[0]["MARKS_NO"].ToString());
                ddlType_Exp.SelectedValue = dtt_clnt.Tables[0].Rows[0]["TYPE_OF_EXPORTER"].ToString() == "" ? "F" : dtt_clnt.Tables[0].Rows[0]["TYPE_OF_EXPORTER"].ToString();
                hdn_Type_Of_Exporter.Value = dtt_clnt.Tables[0].Rows[0]["TYPE_OF_EXPORTER"].ToString() == "" ? "F" : dtt_clnt.Tables[0].Rows[0]["TYPE_OF_EXPORTER"].ToString();
                //ddl_GSTN_Type.SelectedValue = dtt_clnt.Tables[0].Rows[0]["GSTN_TYPE"].ToString();
                hdn_ddl_GSTNType.Value = dtt_clnt.Tables[0].Rows[0]["GSTN_TYPE"].ToString();
                txt_GSTN_ID.Text = dtt_clnt.Tables[0].Rows[0]["GSTN_ID"].ToString();
                txtDrawbackAccount.Text = dtt_clnt.Tables[0].Rows[0]["IMP_EXP_DRAWBACK_AC_NO"].ToString();

                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Update_TypeOfExporter()", true);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    [System.Web.Services.WebMethod]
    public static string GetCountryNameByCode(string countryCode) // Added by shanthini on 30-07-2026
    {
        string countryName = "";
        try
        {
            Auto_Search Auto = new Auto_Search();
            Auto.Ename = "Get_CountryName";
            Auto.Enamesearch = countryCode;
            DataSet ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

            if (ds.Tables[0].Rows.Count > 0)
            {
                countryName = ds.Tables[0].Rows[0]["COUNTRY_NAME"].ToString();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return countryName;
    }


    private void Get_ConsigneeMaster_edit_details(string ename, string CON_ID)
    {
        try
        {
            eroyalmaster erm = new eroyalmaster();
            DataSet dtt_clnt = new DataSet();

            erm.Econsigneeid = CON_ID;
            erm.Econsignee_name = txtConsigneeName.Text;
            erm.CONSIGNEE_BRANCHSLNO = txtConsignee_BranchSlNo.Text;
            erm.Ename = ename;
            erm.EWorking_Period = Working_Period;

            dtt_clnt = erm.RetrieveAll_Consignee_MASTER();

            if (dtt_clnt.Tables[0].Rows.Count > 0)
            {
                txtConsigneeName.Text = dtt_clnt.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                txtConsignee_BranchSlNo.Text = dtt_clnt.Tables[0].Rows[0]["CONSIGNEE_BRANCHSLNO"].ToString();
                txtConsigneeAddress.Text = dtt_clnt.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();
                txtConsigneeAddress1.Text = dtt_clnt.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString();
                txtConsigneeAddress2.Text = dtt_clnt.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString();
                txtConsigneeAddress3.Text = dtt_clnt.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString();
                txtConsigneeAddress4.Text = dtt_clnt.Tables[0].Rows[0]["CONSIGNEE_COUNTRY_NAME"].ToString();
            }
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
            if (Connection.Export_FF_Reader() == "T")
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
            DataRow mand = Get_Export_Mandatory_Settings();

            string f_ExporterName = (mand != null) ? mand["EXPORT_GENERAL_EXPORTER_NAME"].ToString() : "Y";
            string f_IECNo = (mand != null) ? mand["EXPORT_GENERAL_IEC_NO"].ToString() : "Y";
            string f_BranchSLNo = (mand != null) ? mand["EXPORT_GENERAL_BRANCH_SL_NO"].ToString() : "Y";
            string f_Address = (mand != null) ? mand["EXPORT_GENERAL_ADDRESS"].ToString() : "Y";
            string f_Pin = (mand != null) ? mand["EXPORT_GENERAL_PIN"].ToString() : "Y";
            string f_GstnId = (mand != null) ? mand["EXPORT_GENERAL_GSTN_ID"].ToString() : "Y";
            string f_GstnType = (mand != null) ? mand["EXPORT_GENERAL_GSTN_TYPE"].ToString() : "Y";
            string f_TypeOfExporter = (mand != null) ? mand["EXPORT_GENERAL_TYPE_OF_EXPORTER"].ToString() : "Y";
            string f_CountryDischarge = (mand != null) ? mand["EXPORT_GENERAL_COUNTRY_DISCHARGE"].ToString() : "Y";
            string f_PortDischarge = (mand != null) ? mand["EXPORT_GENERAL_PORT_DISCHARGE"].ToString() : "Y";
            string f_CountryFinalDest = (mand != null) ? mand["EXPORT_GENERAL_COUNTRY_FINAL_DESTINATION"].ToString() : "Y";
            string f_PortFinalDest = (mand != null) ? mand["EXPORT_GENERAL_PORT_FINAL_DESTINATION"].ToString() : "Y";
            string f_StateOfExport = (mand != null) ? mand["EXPORT_GENERAL_STATE_OF_EXPORT"].ToString() : "Y";
            string f_ConsigneeName = (mand != null) ? mand["EXPORT_GENERAL_CONSIGNEE_NAME"].ToString() : "Y";
            string f_ADCode = (mand != null) ? mand["EXPORT_GENERAL_AD_CODE"].ToString() : "Y";
            string f_ConsigneeAddress = (mand != null) ? mand["EXPORT_GENERAL_CONSIGNEE_ADDRESS"].ToString() : "Y";
            string f_ConsigneeCountry = (mand != null) ? mand["EXPORT_GENERAL_CONSIGNEE_COUNTRY"].ToString() : "Y";

            string script = string.Format(@"
        var mand_ExporterName     = '{0}';
        var mand_IECNo            = '{1}';
        var mand_BranchSLNo       = '{2}';
        var mand_Address          = '{3}';
        var mand_Pin              = '{4}';
        var mand_GstnId           = '{5}';
        var mand_GstnType         = '{6}';
        var mand_TypeOfExporter   = '{7}';
        var mand_CountryDischarge = '{8}';
        var mand_PortDischarge    = '{9}';
        var mand_CountryFinalDest = '{10}';
        var mand_PortFinalDest    = '{11}';
        var mand_StateOfExport    = '{12}';
        var mand_ConsigneeName    = '{13}';
        var mand_ADCode           = '{14}';
        var mand_ConsigneeAddress = '{15}';
        var mand_ConsigneeCountry = '{16}';
    ",
                f_ExporterName,
                f_IECNo,
                f_BranchSLNo,
                f_Address,
                f_Pin,
                f_GstnId,
                f_GstnType,
                f_TypeOfExporter,
                f_CountryDischarge,
                f_PortDischarge,
                f_CountryFinalDest,
                f_PortFinalDest,
                f_StateOfExport,
                f_ConsigneeName,
                f_ADCode,
                f_ConsigneeAddress,
                f_ConsigneeCountry);

            ScriptManager.RegisterStartupScript(
                this, this.GetType(), "EXPMandatoryFlags", script, true);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    private DataRow Get_Export_Mandatory_Settings()
    {
        try
        {
            if (Session["COMPANY_ID"] == null)
                return null;

            string companyIdStr = COMPANY_ID;
            long companyId = 0;
            if (!long.TryParse(companyIdStr, out companyId) || companyId == 0)
                return null;

            string userCreationIdStr = "";
            if (Session["USER_CREATION_ID"] != null)
                userCreationIdStr = Session["USER_CREATION_ID"].ToString();
            else if (Session["USER_CREATION_ID_EDIT"] != null)
                userCreationIdStr = Session["USER_CREATION_ID_EDIT"].ToString();

            long userCreationId = 0;
            if (!long.TryParse(userCreationIdStr, out userCreationId) || userCreationId == 0)
                return null;

            User_Creation user_Create = new User_Creation();
            user_Create.COMPANY_ID = companyIdStr;
            user_Create.USER_CREATION_ID = userCreationIdStr;
            user_Create.ACTION_BRANCH = SELECT_BRANCH;
            user_Create.flag = "Select_Exp_Col_Setngs";

            DataSet ds = user_Create.Exp_Col_Edit_Insert_update(
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
        try
        {
            DataRow mand = Get_Export_Mandatory_Settings();

            // ✅ No settings saved → all fields default mandatory
            if (mand == null)
                return true;


            string errMsg = "";

            // ── Exporter Name ─────────────────────────────────────────────
            if (isValid && mand["EXPORT_GENERAL_EXPORTER_NAME"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txtExporterName.Text))
            {
                errMsg = "Exporter Name cannot be blank.";
                isValid = false;
            }

            // ── IEC No ────────────────────────────────────────────────────
            if (isValid && mand["EXPORT_GENERAL_IEC_NO"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txtIECNo.Text))
            {
                errMsg = "IEC No cannot be blank.";
                isValid = false;
            }

            // ── Branch SL No ──────────────────────────────────────────────
            if (isValid && mand["EXPORT_GENERAL_BRANCH_SL_NO"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txtBranchNo.Text))
            {
                errMsg = "Branch SL No cannot be blank.";
                isValid = false;
            }

            // ── Address ───────────────────────────────────────────────────
            if (isValid && mand["EXPORT_GENERAL_ADDRESS"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                errMsg = "Address cannot be blank.";
                isValid = false;
            }

            // ── Pin ───────────────────────────────────────────────────────
            if (isValid && mand["EXPORT_GENERAL_PIN"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txtAddress5.Text))
            {
                errMsg = "Pin cannot be blank.";
                isValid = false;
            }

            // ── GSTN ID ───────────────────────────────────────────────────
            if (isValid && mand["EXPORT_GENERAL_GSTN_ID"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txt_GSTN_ID.Text))
            {
                errMsg = "GSTN ID cannot be blank.";
                isValid = false;
            }

            // ── GSTN Type ─────────────────────────────────────────────────
            if (isValid && mand["EXPORT_GENERAL_GSTN_TYPE"].ToString() == "Y"
                && ddl_GSTN_Type.SelectedValue == "")
            {
                errMsg = "GSTN Type cannot be blank.";
                isValid = false;
            }

            // ── Type of Exporter ──────────────────────────────────────────
            if (isValid && mand["EXPORT_GENERAL_TYPE_OF_EXPORTER"].ToString() == "Y"
                && ddlType_Exp.SelectedValue == "")
            {
                errMsg = "Type of Exporter cannot be blank.";
                isValid = false;
            }

            // ── Country Discharge ─────────────────────────────────────────
            if (isValid && mand["EXPORT_GENERAL_COUNTRY_DISCHARGE"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txtCountryDischarge.Text))
            {
                errMsg = "Country Discharge cannot be blank.";
                isValid = false;
            }

            // ── Port Discharge ────────────────────────────────────────────
            if (isValid && mand["EXPORT_GENERAL_PORT_DISCHARGE"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txtPortDischarge.Text))
            {
                errMsg = "Port Discharge cannot be blank.";
                isValid = false;
            }

            // ── Country Final Destination ─────────────────────────────────
            if (isValid && mand["EXPORT_GENERAL_COUNTRY_FINAL_DESTINATION"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txtCountryFinalDestination.Text))
            {
                errMsg = "Country Final Destination cannot be blank.";
                isValid = false;
            }

            // ── Port Final Destination ────────────────────────────────────
            if (isValid && mand["EXPORT_GENERAL_PORT_FINAL_DESTINATION"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txtPortFinalDestination.Text))
            {
                errMsg = "Port Final Destination cannot be blank.";
                isValid = false;
            }

            // ── State of Export ───────────────────────────────────────────
            if (isValid && mand["EXPORT_GENERAL_STATE_OF_EXPORT"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txtStateExport.Text))
            {
                errMsg = "State of Export cannot be blank.";
                isValid = false;
            }

            // ── Consignee Name ────────────────────────────────────────────
            if (isValid && mand["EXPORT_GENERAL_CONSIGNEE_NAME"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txtConsigneeName.Text))
            {
                errMsg = "Consignee Name cannot be blank.";
                isValid = false;
            }

            // ── AD Code ───────────────────────────────────────────────────
            if (isValid && mand["EXPORT_GENERAL_AD_CODE"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txtAdcode.Text))
            {
                errMsg = "AD Code cannot be blank.";
                isValid = false;
            }

            // ── Consignee Address ─────────────────────────────────────────
            if (isValid && mand["EXPORT_GENERAL_CONSIGNEE_ADDRESS"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txtConsigneeAddress.Text))
            {
                errMsg = "Consignee Address cannot be blank.";
                isValid = false;
            }

            // ── Consignee Country ─────────────────────────────────────────
            if (isValid && mand["EXPORT_GENERAL_CONSIGNEE_COUNTRY"].ToString() == "Y"
                && string.IsNullOrWhiteSpace(txtConsigneeAddress4.Text))
            {
                errMsg = "Consignee Country cannot be blank.";
                isValid = false;
            }

            // ── Show error ────────────────────────────────────────────────
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

    public void OCR_Delete_Jobs(string job_no)
    {
        try
        {
            Page_Count_Details ds_Page = new Page_Count_Details();
            ds_Page.PDF_JOB_NO = job_no;
            ds_Page.PDF_STATUS = "JOB DELETE";

            ds_Page.OCR_PDF_COUNT_UPDATE_INSERT();

            pdflog.WriteOcrJobLog(job_no, "Job Deleted", "JobNo:" + job_no + " deleted via Export/General screen (PDF_JOB_DELETED flagged)", "EXP");
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    #region Export Audit Logs

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
            Dt_Change.GetMismatchedRowsFast_EXP(dt_Prev, dt_modified, "JOBNO", "General", txtJobNo.Text, "", "", currentuser, currentbranch);

            //-------------------Delete 30 days Last modified files from logs Folder------------------------------------------
            //string folderPath = HttpContext.Current.Server.MapPath("~/logs_DataModifiedHistory/EXP/" + COMPANY_ID + "/" + HttpContext.Current.Session["GroupID"].ToString() + "/");
            //Dt_Change.DeleteLast30Files(folderPath);
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
            dr["CUSTOMS_HOUSE"] = txtCustomsHouse.Text;
            dr["SB_TYPE"] = ddlSBType.SelectedValue;
            dr["EXPORTER_NAME"] = txtExporterName.Text;
            dr["BRANCH_NO"] = txtBranchNo.Text;
            dr["IEC_NO"] = txtIECNo.Text;

            dr["ADDRESS1"] = txtAddress.Text;
            dr["ADDRESS2"] = txtAddress2.Text;
            dr["ADDRESS3"] = txtAddress3.Text;
            dr["ADDRESS4"] = txtAddress4.Text;
            dr["ADDRESS5"] = txtAddress5.Text;

            dr["ADCODE"] = txtAdcode.Text;
            dr["BANK_ACCOUNT"] = txtBankAccount.Text;
            dr["DRAWBACK_ACCOUNT"] = txtDrawbackAccount.Text;

            dr["CONSIGNEE_NAME"] = txtConsigneeName.Text;
            dr["CONSIGNEE_ADD1"] = txtConsigneeAddress.Text;
            dr["CONSIGNEE_ADD2"] = txtConsigneeAddress1.Text;
            dr["CONSIGNEE_ADD3"] = txtConsigneeAddress2.Text;
            dr["CONSIGNEE_ADD4"] = txtConsigneeAddress3.Text;
            dr["CONSIGNEE_ADD5"] = txtConsigneeAddress4.Text;

            dr["COUNTRY_DISCHARGE"] = txtCountryDischarge.Text;
            dr["PORT_DISCHARGE"] = txtPortDischarge.Text;

            dr["COUNTRY_FINAL_DEST"] = txtCountryFinalDestination.Text;
            dr["PORT_FINAL_DEST"] = txtPortFinalDestination.Text;
            dr["STATE_OF_EXPORT"] = txtStateExport.Text;
            dr["NFEI"] = ddlNFEI.SelectedValue;
            dr["NFEI_TYPE"] = ddlType.SelectedValue;
            dr["RBI_WAIVER_NO"] = txtRBIWaiverNo.Text;
            dr["RBI_WAIVER_DATE"] = txtRBIWaiverDate.Text;
            dr["MARKS_NO"] = txtMarksNos.Text;
            dr["FILE_REF_NO"] = txtFile_Ref_no.Text;
            dr["TYPE_OF_EXPORTER"] = ddlType_Exp.SelectedValue;
            dr["CONSIGNEE_BRANCHSLNO"] = txtConsignee_BranchSlNo.Text;
            dr["GSTN_TYPE"] = ddl_GSTN_Type.SelectedValue;
            dr["GSTN_ID"] = txt_GSTN_ID.Text;
            dr["PARTY_REF_NO"] = txtParty_RefNo.Text;
            dr["CARTING_POINT"] = txt_CartingPoint.Text;
            dr["IFSC_CODE"] = txt_IFSCCode.Text;
            dr["AMENDMENT_TYPE"] = ddl_AmendmentType.SelectedValue;
            dr["PORT_OF_LOADING"] = txt_PortOfLoading.Text;

            if (ddl_MultipleIcegate_YN == "Y")
            {
                if (ddl_Multiple_CHA_No.SelectedItem.Text != "")
                {
                    string[] splt = ddl_Multiple_CHA_No.SelectedItem.Text.Split('-');

                    dr["ICE_ID"] = splt[0];
                    dr["CHA_NO"] = splt[1];
                    Session.Remove("Multiple_ICE_ID");
                    Session["Multiple_ICE_ID"] = splt[0];
                }
            }
            else
            {
                dr["ICE_ID"] = "";
                dr["CHA_NO"] = "";
            }

            // ================= ADD ROW =================
            dt_mapping.Rows.Add(dr);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return dt_mapping;

    }

    #endregion




}