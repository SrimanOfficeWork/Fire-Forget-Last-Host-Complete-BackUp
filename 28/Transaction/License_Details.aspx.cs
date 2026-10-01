using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;

public partial class Transaction_License_Details_new : ThemeClass
{
    Transaction Transact = new Transaction();
    DataSet dss = new DataSet();
    public int i;
    
    DataTable dt = new DataTable();
    AppSession aps = new AppSession();
    DataSet ds_lic = new DataSet();
    ErrorLogs er = new ErrorLogs();
    
   
    public string currentuser;

    public string IMPORT_JOBNO, LICENSE_ID, FLAG, YEAR, Registration_Date, License_Date, SchemeCode, COMPANY_IDD;
    public string INVOICE_SLNO = "", ITEM_SLNO = "";
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    public string JOB_LOCK, JOB_RELEASE;
    User_Creation user_Create = new User_Creation();
    public bool is_epcg = false;
    public double Job_Remaing_Amt, Job_Remaing_Qty;
    Imp_Checklist_Item_License Item_License = new Imp_Checklist_Item_License();
    public string INDIVITUAL_CIF_AMOUNT = "", TOTAL_DEBIT_DUTY_FINAL = "", Audit_YN = "";
    public string btn_cif_click = "";
    int result = 0;
    string Is_All_check = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            currentuser = Connection.Current_User();
            IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
            SchemeCode = Session["SCHEME_CODE"].ToString();
            SELECT_BRANCH = Connection.Get_Company_Type();
            COMPANY_IDD = Connection.COMPANYID();
            hdnCompanyID.Value = Connection.COMPANYID();


            if (Session["ITEM_SLNO"] != null)
            {
                if (Session["TRANSPORT_MODE"] != null)
                {
                    hdfTransport_mode.Value = Session["TRANSPORT_MODE"].ToString();
                }

                INVOICE_SLNO = Session["Invoice_SLNO"].ToString();
                hdinvslno.Value = INVOICE_SLNO;
                ITEM_SLNO = Session["ITEM_SLNO"].ToString();
                hditemslno.Value = ITEM_SLNO;
                hdn_Customhouse_chk.Value = "Yes";

                Session["btn_cif_click"] = "License";
                if (!IsPostBack)
                {

                    CalendarExtender1.EndDate = DateTime.Today;
                    CalendarExtender2.EndDate = DateTime.Today;


                    Item_License.Page_Load_Item_Details(INVOICE_SLNO, ITEM_SLNO, "", "");
                    INDIVITUAL_CIF_AMOUNT = Session["INDIVITUAL_CIF_AMOUNT"].ToString();
                    TOTAL_DEBIT_DUTY_FINAL = Session["TOTAL_DEBIT_DUTY_FINAL"].ToString();
                    hdn_tot_CIF_Amt.Value = INDIVITUAL_CIF_AMOUNT;
                    hdn_tot_Duty_Amt.Value = TOTAL_DEBIT_DUTY_FINAL;

                    if (INDIVITUAL_CIF_AMOUNT != "" || INDIVITUAL_CIF_AMOUNT != null)
                    {
                        txtCIF_Value.Text = INDIVITUAL_CIF_AMOUNT;
                    }
                    if (TOTAL_DEBIT_DUTY_FINAL != "" || TOTAL_DEBIT_DUTY_FINAL != null)
                    {
                        txtDebit_DutyValue.Text = TOTAL_DEBIT_DUTY_FINAL;
                    }
                    Get_Remaining_CIF_VALUE();
                    Get_License_Default_Settings();
                }

                // set for No need any checking Calc - Always No
                if (Connection.COMPANYID() == "4" || Connection.COMPANYID() == "480" || Connection.COMPANYID() == "1011")// Sanco
                {
                    RB_Y_N.SelectedValue = "No";
                    hdn_Y_N.Value = RB_Y_N.SelectedItem.Text;
                    Session["RB_Y_N"] = hdn_Y_N.Value;
                }

                if (Connection.Audit_Logs(COMPANY_IDD) == "Y")
                {
                    Audit_YN = "Y";
                }


                hdn_Y_N.Value = RB_Y_N.SelectedItem.Text;
                Session["RB_Y_N"] = hdn_Y_N.Value;

                if (Session["SCHEME_CODE"].ToString() != null)
                {
                    hdn_Schemecode.Value = Session["SCHEME_CODE"].ToString();
                }

                if (!IsPostBack)
                {
                    //----------------SETTING SCREEN PERMISSION---------------//
                    Screen_Id = 7;
                    Page_Rights(Screen_Id);
                    //----------------SETTING SCREEN PERMISSION---------------//

                    ddlExcemption.Focus();

                    Gridbind_License();
                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                    btn_save_new.Visible = true;
                    btnNew.Visible = true;
                    btn_delete_all.Visible = false;
                    //----------------excemption always Y when EPCG ---------------//

                    //EPCG_EXcemption_Y(Session["SCHEME_CODE"].ToString());
                    //----------------excemption always Y when EPCG ---------------//

                    if (Session["DEBITQTY"] != null || Session["UNITQTY"] != null)
                    {
                        //txtDebit_Qty.Text = Session["DEBITQTY"].ToString();
                        /* hide on 24-03-2021
                        txtDebit_Qty.Text = Convert.ToString(Math.Round(Convert.ToDouble(Session["DEBITQTY"]), 2).ToString("0.00"));
                        hdn_tot_ItemQty.Value = txtDebit_Qty.Text;
                         * */

                        hdn_tot_ItemQty.Value = Convert.ToString(Math.Round(Convert.ToDouble(Session["DEBITQTY"]), 2).ToString("0.00"));
                        if (hdn_Curr_Debit_Qty.Value != "")
                        {
                            // if (SchemeCode != "36-MEIS" && SchemeCode != "37-SEIS" && SchemeCode != "31-SHIS" && SchemeCode != "28-FPS" && SchemeCode != "27-FMS")
                            if (SchemeCode != "36-MEIS" && SchemeCode != "37-SEIS" && SchemeCode != "31-SHIS" && SchemeCode != "28-FPS" && SchemeCode != "27-FMS" && SchemeCode != "RD-RoDTEP Scheme" && SchemeCode != "39-ROSCTL" && SchemeCode != "91-MEIS eCom" && SchemeCode != "RS-ROSCTL Scheme") //16-06-2021 sugg.by Bala sir- For MEIS should not debit the Qty
                            {
                                txtDebit_Qty.Text = hdn_Curr_Debit_Qty.Value;
                            }
                            else
                            {
                                txtDebit_Qty.Text = hdn_tot_ItemQty.Value;
                            }
                        }
                        else
                        {
                            txtDebit_Qty.Text = hdn_tot_ItemQty.Value;
                        }

                        txtUnit_Qty.Text = Session["UNITQTY"].ToString();
                        hdn_UnitQty.Value = Session["UNITQTY"].ToString();
                    }
                }
            }
            else
            {
                Response.Write("<script>window.parent.document.getElementById('ItemMain').click();</script>");
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
                    btn_save_new.ToolTip = "This Job is Locked by Admin";
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
            txt_LicenseCurrency.Attributes.Add("onblur", "javascript:Call__Inv_Currency_Excahnge_Rate('" + txt_LicenseCurrency.ClientID + "', '" + txt_Exrate.ClientID + "')");
            txtRegistration_No.Focus();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
           // 
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
                gv_License.ToolTip = "You don't have permission to access";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    private void Get_License_Default_Settings()
    {
        try
        {
            Default_Settings Default = new Default_Settings();
            DataSet ds_lic = new DataSet();

            string[] sp = Session["SCHEME_CODE"].ToString().Split('-');

            Default.SCHEME = sp[1];
            Default.USER_ID = currentuser;
            Default.BRANCH_CODE = Connection.Current_Branch();
            Default.YEAR = "";
            Default.WORKING_PERIOD = Connection.WorkingPeriod();
            Default.BRANCH_COMMON = SELECT_BRANCH;
            Default.flag = "Get_Scheme_Details";

            ds_lic = Default.Import_License_Default_Settings_Insert_Update();

            if (ds_lic.Tables[0].Rows.Count > 0)
            {
                hdn_Duty_based.Value = ds_lic.Tables[0].Rows[0]["DUTY_BASED"].ToString();
                hdn_CIF_based.Value = ds_lic.Tables[0].Rows[0]["CIF_BASED"].ToString();
                hdn_Qty_based.Value = ds_lic.Tables[0].Rows[0]["QTY_BASED"].ToString();

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void Gridbind_License()
    {
        DataSet ds_imp_lic = new DataSet();
        try
        {
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.INVOICE_SLNO = INVOICE_SLNO;
            Transact.ITEM_SLNO = ITEM_SLNO;
            Transact.DEBIT_AMT = "";
            Transact.DEBIT_DUTY = "";
            Transact.LICENSE_ID = "0";
            Transact.WORKING_PERIOD = SELECT_BRANCH;

            Transact.Ename = "select_con";
            ds_imp_lic = Transact.RetrieveAll_License_Details();
            gv_License.DataSource = ds_imp_lic.Tables[0];
            gv_License.DataBind();

            if (Audit_YN == "Y")
            {
                Tbl_Filed_Modified_History(ds_imp_lic.Tables[1]);
                DataTable_Mapping_Controls(ds_imp_lic.Tables[1], "Y");
            }

            Gridbind_ExRate_UpdateAll();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void Gridbind_ExRate_UpdateAll()
    {
        try
        {
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.INVOICE_SLNO = INVOICE_SLNO;
            Transact.ITEM_SLNO = ITEM_SLNO;
            Transact.DEBIT_AMT = "";
            Transact.DEBIT_DUTY = "";
            Transact.LICENSE_ID = "0";
            Transact.WORKING_PERIOD = SELECT_BRANCH;

            Transact.Ename = "select_ExRate_Grid_UpdateAll";
            gv_exrate.DataSource = Transact.RetrieveAll_License_Details();
            gv_exrate.DataBind();
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
            if (Convert.ToDouble(txtDebit_Qty.Text) > 0)
            {
                LICENSE_ID = "";


                if (txtRegistration_Date.Text == "")
                {
                    Registration_Date = "01/01/1900";
                }
                else
                {
                    Registration_Date = txtRegistration_Date.Text;
                }

                if (txtLicense_Date.Text == "")
                {
                    License_Date = "01/01/1900";
                }
                else
                {
                    License_Date = txtLicense_Date.Text;
                }

                FLAG = "S";
                YEAR = "";


                if (RB_Y_N.SelectedItem.Text == "Yes")
                {
                    double lic_bal = 0.00;

                    lic_bal = Check_License_Balance(txtRegistration_No.Text, txtLicense_ItemNo.Text);

                    string aa = hdn_Remaining_Amt.Value;
                    string bb = hdn_Remaining_Qty.Value;

                    txt_Remaining_Amt.Text = hdn_Remaining_Amt.Value;
                    txt_Remaining_Qty.Text = hdn_Remaining_Qty.Value;



                    if (hdn_Duty_based.Value == "Y")
                    {
                        if (((Convert.ToDouble(txtDebit_DutyValue_per.Text)) <= (Convert.ToDouble(lic_bal))) && (Convert.ToDouble(txtDebit_DutyValue_per.Text)) > 0)// should not be (-) minus value
                        {
                            //License_Insert();//29-04-2021
                            Is_All_check = "True";
                        }
                        else
                        {
                            Is_All_check = "DutyVal_exceeds";
                        }
                    }

                    if (Is_All_check == "True" || hdn_Duty_based.Value == "N")
                    {
                        if (hdn_CIF_based.Value == "Y")
                        {
                            if (((Convert.ToDouble(txtDebit_Amount.Text)) <= (Convert.ToDouble(txt_Remaining_Amt.Text))) && (Convert.ToDouble(txtDebit_Amount.Text)) > 0)// should not be (-) minus value
                            {
                                //License_Insert();//29-04-2021
                                Is_All_check = "True";
                            }
                            else
                            {
                                Is_All_check = "CIF_exceeds";
                            }
                        }
                    }

                    if (Is_All_check == "True" || hdn_CIF_based.Value == "N")
                    {
                        if (hdn_Qty_based.Value == "Y")
                        {
                            if ((Convert.ToDouble(txtDebit_Qty.Text)) <= (Convert.ToDouble(txt_Remaining_Qty.Text)))
                            {
                                //License_Insert();//29-04-2021
                                Is_All_check = "True";
                            }
                            else
                            {
                                Is_All_check = "Qty_exceeds";
                            }
                        }
                    }


                    //Finally Insert
                    if (Is_All_check == "True")
                    {
                        License_Insert();
                    }
                    else if (Is_All_check == "DutyVal_exceeds")
                    {
                        Alert_msg("Debit DutyVal exceeds than Available Duty");
                        txtDebit_DutyValue_per.Focus();
                    }
                    else if (Is_All_check == "CIF_exceeds")
                    {
                        Alert_msg("Total Debit Amt is Greater than Remaining Amt");
                    }
                    else if (Is_All_check == "Qty_exceeds")
                    {
                        Alert_msg("Total Debit Qty is Greater than Remaining Qty");
                    }
                    else
                    {
                        License_Insert();// No settings in License Default Settings
                    }

                }
                else
                {
                    License_Insert();
                }
                Gridbind_License();
                Get_Remaining_CIF_VALUE();//13-03-2021
            }
            else
            {
                Alert_msg("Debit Qty should be greater than '0'");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToDouble(txtDebit_Qty.Text) > 0)
            {
                //LICENSE_ID = ViewState["License_ID"].ToString();
                LICENSE_ID = hdn_update_License.Value;

                if (txtRegistration_Date.Text == "")
                {
                    Registration_Date = "01/01/1900";
                }
                else
                {
                    Registration_Date = txtRegistration_Date.Text;
                }

                if (txtLicense_Date.Text == "")
                {
                    License_Date = "01/01/1900";
                }
                else
                {
                    License_Date = txtLicense_Date.Text;
                }

                FLAG = "U";
                YEAR = "";

                if (RB_Y_N.SelectedItem.Text == "Yes")
                {
                    double lic_bal = 0.00;

                    lic_bal = Check_License_Balance(txtRegistration_No.Text, txtLicense_ItemNo.Text);

                    string aa = hdn_Remaining_Amt.Value;
                    string bb = hdn_Remaining_Qty.Value;

                    txt_Remaining_Amt.Text = hdn_Remaining_Amt.Value;
                    txt_Remaining_Qty.Text = hdn_Remaining_Qty.Value;

                    txt_Remaining_Amt.Text = Convert.ToString(hdn_Avail_CIF_AMt_Master.Value);

                    if (hdn_Duty_based.Value == "Y")
                    {
                        //if ((Convert.ToDouble(txtDebit_DutyValue_per.Text)) <= (Convert.ToDouble(lic_bal)))

                        if ((Convert.ToDouble(txtDebit_DutyValue_per.Text)) <= (Convert.ToDouble(hdn_tot_Debit_Duty.Value)))
                        {
                            Is_All_check = "True";
                        }
                        else
                        {
                            Is_All_check = "DutyVal_exceeds";
                            txtDebit_DutyValue_per.Focus();
                        }
                    }

                    if (Is_All_check == "True" || hdn_Duty_based.Value == "N")
                    {
                        if (hdn_CIF_based.Value == "Y")
                        {
                            if (hdn_Y_N.Value == "Yes")
                            {
                                //if ((Convert.ToDouble(txtDebit_Amount.Text)) <= (Convert.ToDouble(txt_Remaining_Amt.Text)))
                                if ((Convert.ToDouble(txtDebit_Amount.Text)) <= (Convert.ToDouble(hdn_tot_CIF_Amt.Value)))
                                {
                                    Is_All_check = "True";
                                }
                                else
                                {
                                    Is_All_check = "CIF_exceeds";
                                }
                            }// if hdn_Y_N.Value - close
                            else
                            {
                                License_Details_insert_update(LICENSE_ID, Registration_Date, FLAG, YEAR);
                            }
                        }
                    }

                    if (Is_All_check == "True" || hdn_CIF_based.Value == "N")
                    {
                        if (hdn_Qty_based.Value == "Y")
                        {
                            if ((Convert.ToDouble(txtDebit_Qty.Text)) <= (Convert.ToDouble(hdn_tot_Debit_Qty.Value)))
                            {
                                Is_All_check = "True";
                            }
                            else
                            {
                                Is_All_check = "Qty_exceeds";
                            }
                        }
                    }

                    if (hdn_Duty_based.Value == "N" && hdn_CIF_based.Value == "N" && hdn_Qty_based.Value == "N") //// No settings in License Default Settings
                    {
                        Is_All_check = "True";
                    }

                }
                else // -- if (RB_Y_N.SelectedItem.Text == "No")
                {
                    Is_All_check = "True";
                }

                //Finally Update
                if (Is_All_check == "True")
                {
                    License_Update();
                }
                else if (Is_All_check == "DutyVal_exceeds")
                {
                    Alert_msg("Debit DutyVal exceeds than Available Duty");
                    txtDebit_DutyValue_per.Focus();
                }
                else if (Is_All_check == "CIF_exceeds")
                {
                    Alert_msg("Total Debit Amt is Greater than Remaining Amt");
                }
                else if (Is_All_check == "Qty_exceeds")
                {
                    Alert_msg("Total Debit Qty is Greater than Remaining Qty");
                }
                else
                {
                    License_Update();// No settings in License Default Settings
                }

                Gridbind_License();
            }
            else
            {
                Alert_msg("Debit Qty should be greater than '0'");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public void License_Update()
    {
        try
        {
            License_Details_insert_update(LICENSE_ID, Registration_Date, FLAG, YEAR);

            if (i == 1)
            {
                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("Licence Updated Successfully", "btnUpdate");
                }
                else
                {
                    Alert_msg("Licence Saved Successfully", "btnUpdate");
                }

                if (Audit_YN == "Y")
                {
                    Audit_Modified_DataTableComparer();
                }
            }
            else if (i == 2)
            {
                Alert_msg(" License RegistrationNo Already Exist");
            }
            else if (i == 3)
            {
                Alert_msg(" Check the Debit & Duty Values ");
            }
            else
            {
                Alert_msg("Licence Not Updated", "btnSave");
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
            Transact.INVOICE_SLNO = INVOICE_SLNO;
            Transact.ITEM_SLNO = ITEM_SLNO;
            Transact.DEBIT_AMT = "";
            Transact.DEBIT_DUTY = "";

            Transact.LICENSE_ID = ViewState["License_ID"].ToString();

            Transact.WORKING_PERIOD = SELECT_BRANCH;

            Transact.Ename = "delete";
            dss = Transact.RetrieveAll_License_Details();
            Grid_Empty();
            int ii = 0;
            ii = Transact.result;

            if (ii > 0)
            {
                btnNew_Click(sender, e);
                Alert_msg("Licence Deleted");

                if (i == 1)
                {

                    Transact.Imp_Job_Logs_All_Details(Connection.IMP_Jobno(), INVOICE_SLNO, ITEM_SLNO, "License", "D", "Insert");
                }
            }
            else
            {
                Alert_msg("Licence Not Deleted");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    public void License_Insert()
    {
        try
        {
            License_Details_insert_update(LICENSE_ID, Registration_Date, FLAG, YEAR);
            hdn_update_License.Value = Convert.ToString(Transact.UPDATE_ID);

            if (i == 1)
            {
                //-----------------------FOR USER RIGHTS--------------------------------//
                user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);
                PAGE_MODIFY = user_Create.PAGE_MODIFY;

                //---------------SAVE ONLY------------------//

                if (PAGE_MODIFY == "False")
                {
                    btn_New();
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
                Alert_msg("Licence Saved Successfully", "btnSave");

            }
            else if (i == 2)
            {
                Alert_msg(" License RegistrationNo Already Exist");
            }
            else if (i == 3)
            {
                Alert_msg(" Check the Debit & Duty Values ");
            }
            else
            {
                Alert_msg("Licence Not Saved", "btnSave");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }

    }

   
    public void License_Details_insert_update(string LICENSE_ID, string REGISTRATION_DATE, string flag, string year)
    {
        try
        {
            //---------------------SCHEME CODE TO SAVE IN LICENSE DETAILS----------------------------------------//

            string SCHEME = "";
            if (Session["SCHEME_CODE"] != null)
            {
                SCHEME = Session["SCHEME_CODE"].ToString();
            }
            else
            {
                SCHEME = "";
            }
            //---------------------SCHEME CODE TO SAVE IN LICENSE DETAILS----------------------------------------//

            Transact.LICENSE_ID = LICENSE_ID;
            Transact.JOBNO = IMPORT_JOBNO;

            Transact.ITEM_SLNO = ITEM_SLNO;
            Transact.SCHEME_CODE_LICENSE = SCHEME;

            Transact.INVOICE_SLNO = INVOICE_SLNO;
            Transact.REGISTRATION_NO = txtRegistration_No.Text;
            Transact.REGISTRATION_DATE = REGISTRATION_DATE;
            Transact.EXCEMPTION = ddlExcemption.SelectedValue.ToString();
            Transact.DEBIT_AMT = txtDebit_Amount.Text;
            Transact.DEBIT_QTY = Convert.ToString(Math.Round(Convert.ToDouble(txtDebit_Qty.Text), 2).ToString("0.00"));
            Transact.UNIT_QTY = txtUnit_Qty.Text.ToUpper();
            Transact.LICENSE_ITEM_NO = txtLicense_ItemNo.Text;
            Transact.PORT_OF_LICENSE = txtPort_Of_Licenses.Text.ToUpper();
            hdn_Customhouse_chk.Value = Set_Customs_House_Validation(txtPort_Of_Licenses.Text);

            Transact.USER_ID = currentuser;
            Transact.BRANCH_CODE = Connection.Current_Branch();
            Transact.flag = flag;
            Transact.YEAR = year;
            Transact.WORKING_PERIOD = Connection.WorkingPeriod();
            Transact.BRANCH_COMMON = SELECT_BRANCH;
            Transact.LICENSE_NO = txtLicense_No.Text;
            Transact.LICENSE_DATE = License_Date;
            Transact.TOTAL_CIF_VALUE = txtCIF_Value.Text;
            Transact.TOTAL_DEBIT_DUTY = txtDebit_DutyValue.Text;
            if (txtDebit_DutyValue_per.Text == "" || txtDebit_DutyValue_per.Text == "0")
            {
                Transact.ENTRY_DEBIT_DUTY = "0.00";
            }
            else
            {
                Transact.ENTRY_DEBIT_DUTY = txtDebit_DutyValue_per.Text;
            }
            Transact.DEBIT_DUTY = txtDebit_DutyValue_per.Text;

            Transact.ITEM_DESCRIPTION = txt_lic_desc.Text;
            Transact.LICENSE_CURRENCY = txt_LicenseCurrency.Text;
            Transact.EX_RATE = txt_Exrate.Text;
            Transact.JOBNO_PS = Session["JOBNO_PS"].ToString();
            Transact.PART_NO = Session["Part_No"] == null ? "" : Session["Part_No"].ToString().Trim();

            dss = Transact.License_Details_insertupdate();
            Grid_Empty();
            i = Transact.result;

            if (i == 1)
            {
                //if (COMPANY_IDD == "10" || COMPANY_IDD == "293" || COMPANY_IDD == "480" || COMPANY_IDD == "1011" || COMPANY_IDD == "1019" || COMPANY_IDD == "1025" || COMPANY_IDD == "1176" || COMPANY_IDD == "2145" || COMPANY_IDD == "2373" || COMPANY_IDD == "3004" || COMPANY_IDD == "3010" || COMPANY_IDD == "3196" || COMPANY_IDD == "3267")//Capricorn
                //{
                Transact.Imp_Job_Logs_All_Details(Connection.IMP_Jobno(), INVOICE_SLNO, ITEM_SLNO, "License", flag, "Insert");
                //}
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void gv_License_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["License_ID"] = Convert.ToString(this.gv_License.SelectedDataKey.Value);

            if (ViewState["License_ID"] != "" && ViewState["License_ID"] != null)
            {
                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = ViewState["License_ID"].ToString();
                hdn_update_License.Value = ViewState["License_ID"].ToString();
                hdn_current_event.Value = "gv_License_Selected";


                //FOR UPDATED SUCCESSFULLY
                btnUpdate.CssClass = "updates";
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = true;
                btn_save_new.Visible = false;
                btn_delete_all.Visible = true;

                txtRegistration_No.Text = gv_License.SelectedRow.Cells[1].Text;
                txtRegistration_Date.Text = gv_License.SelectedRow.Cells[2].Text.Replace("01/01/1900", "");

                ddlExcemption.Items.Clear();
                string excemption = gv_License.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");

                //----------------excemption always Y when EPCG ---------------//

                //if (false == EPCG_EXcemption_Y(Session["SCHEME_CODE"].ToString()))

                //----------------excemption always Y when EPCG ---------------//

                //{
                ddlExcemption.Items.Add("Y");
                ddlExcemption.Items.Add("N");
                ddlExcemption.Items.Add("E");
                ddlExcemption.Items.Remove(excemption);
                ddlExcemption.Items.Insert(0, excemption);
                //}
                txtDebit_Amount.Text = gv_License.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
                Hdn_count_DebitAmt.Value = txtDebit_Amount.Text;
                txtDebit_Qty.Text = gv_License.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
                Hdn_count_DebitQTY.Value = txtDebit_Qty.Text;
                txtUnit_Qty.Text = gv_License.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");

                txtLicense_ItemNo.Text = gv_License.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
                txtPort_Of_Licenses.Text = gv_License.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
                hdn_Customhouse_chk.Value = Set_Customs_House_Validation(txtPort_Of_Licenses.Text);
                txtLicense_No.Text = gv_License.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
                txtLicense_Date.Text = gv_License.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");

                txtCIF_Value.Text = gv_License.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
                txtDebit_DutyValue.Text = gv_License.SelectedRow.Cells[12].Text.Replace("&nbsp;", "");
                txtDebit_DutyValue_per.Text = gv_License.SelectedRow.Cells[13].Text.Replace("&nbsp;", "");

                txt_lic_desc.Text = gv_License.SelectedRow.Cells[14].Text.Replace("&nbsp;", "");
                txt_LicenseCurrency.Text = gv_License.SelectedRow.Cells[15].Text.Replace("&nbsp;", "");
                txt_Exrate.Text = gv_License.SelectedRow.Cells[16].Text.Replace("&nbsp;", "");
                //RB_Y_N.SelectedValue = "1";

                Check_Higher_than_Value_Sum_CIF();
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

    protected void gv_License_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gv_License.PageIndex = e.NewPageIndex;
            Gridbind_License();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void gv_License_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_License, "Select$" + e.Row.RowIndex.ToString()));
                }
                //  if Read Permiision given true for gridview enabled or Disabled----------//

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

    protected void gv_License_RowCreated(object sender, GridViewRowEventArgs e)
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

    protected void gv_exrate_RowCreated(object sender, GridViewRowEventArgs e)
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

    protected void gv_exrate_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
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

    public void Grid_Empty()
    {
        try
        {
            if (dss.Tables.Count > 0)
            {
                if (dss.Tables[0].Rows.Count > 0)
                {
                    gv_License.DataSource = dss;
                    gv_License.DataBind();
                }
                else
                {
                    gv_License.DataSource = dt;//add empty row
                    gv_License.DataBind();
                }
            }
            else
            {
                gv_License.DataSource = dt;//add empty row
                gv_License.DataBind();
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
            btn_New();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    public void btn_New()
    {
        try
        {
            ddlExcemption.Focus();
            FLAG = "";

            Transact.ResetFields(Page.Controls);

            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
            btn_save_new.Visible = true;
            btnUpdate.CssClass = "updates";
            hdn_current_event.Value = "";

            ViewState["UPDATED_ID"] = null;
            hdn_update_License.Value = "";

            Gridbind_License();
            if (Session["DEBITQTY"] != null || Session["UNITQTY"] != null)
            {
                txtDebit_Qty.Text = Session["DEBITQTY"].ToString();
                txtUnit_Qty.Text = Session["UNITQTY"].ToString();
            }
            EPCG_EXcemption_Y(Session["SCHEME_CODE"].ToString());
            Get_Remaining_CIF_VALUE();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

     [System.Web.Services.WebMethod]
    public void Get_Remaining_CIF_VALUE()
    {
        try
        {
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.INVOICE_SLNO = INVOICE_SLNO;
            Transact.ITEM_SLNO = ITEM_SLNO;
            Transact.LICENSE_ITEM_NO = "";
            Transact.Ename = "ITEM_WISE_LICENSE_REMAINING_CIF_VALUE";
            Transact.BRANCH_CODE = SELECT_BRANCH;
            Transact.WORKING_PERIOD = SELECT_BRANCH;

            ds_lic = Transact.RetrieveAll_License_Details_ITEM_WISE();

            if (Transact.result == 1)
            {
                if (ds_lic.Tables[0].Rows.Count > 0)
                {
                    txtDebit_Amount.Text = ds_lic.Tables[0].Rows[0]["REMAINING_VALUE"].ToString();
                    hdn_tot_CIF_Amt.Value = txtDebit_Amount.Text;
                }
                if (ds_lic.Tables[1].Rows.Count > 0)
                {
                    txtDebit_DutyValue_per.Text = ds_lic.Tables[1].Rows[0]["REMAINING_DEBIT_VALUE"].ToString();
                    hdn_tot_Duty_Amt.Value = txtDebit_DutyValue_per.Text;
                }
                if (ds_lic.Tables[2].Rows.Count > 0)
                {
                    txtCIF_Value.Text = ds_lic.Tables[2].Rows[0]["TOTAL_CIF_VALUE"].ToString();
                    txtDebit_DutyValue.Text = ds_lic.Tables[2].Rows[0]["TOTAL_DEBIT_DUTY"].ToString();
                }
                if (ds_lic.Tables[3].Rows.Count > 0)
                {
                    if (SchemeCode != "36-MEIS" && SchemeCode != "37-SEIS" && SchemeCode != "31-SHIS" && SchemeCode != "28-FPS" && SchemeCode != "27-FMS" && SchemeCode != "RD-RoDTEP Scheme" && SchemeCode != "39-ROSCTL" && SchemeCode != "91-MEIS eCom" && SchemeCode != "RS-ROSCTL Scheme") //16-06-2021 sugg.by Bala sir- For MEIS should not debit the Qty
                    {
                        txtDebit_Qty.Text = ds_lic.Tables[3].Rows[0]["REMAINING_ITEM_QTY"].ToString();
                        hdn_Curr_Debit_Qty.Value = txtDebit_Qty.Text;
                    }
                }

                if (txtDebit_Amount.Text != "0.00")
                {
                    if (FLAG == "S")
                    {
                        mp_save_Alert.Show();
                    }
                }
            }
            else
            {
                txtDebit_Amount.Text = INDIVITUAL_CIF_AMOUNT;
                txtDebit_DutyValue_per.Text = TOTAL_DEBIT_DUTY_FINAL;
                // txtDebit_Qty.Text = Convert.ToString(Math.Round(Convert.ToDouble(Session["DEBITQTY"]), 2).ToString("0.00"));//24-03-2021
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }

    public bool EPCG_EXcemption_Y(string str)
    {
        try
        {
            //----------------excemption always Y when EPCG ---------------//

            if (str.Contains("EPCG"))
            {
                ddlExcemption.Items.Clear();
                ddlExcemption.Items.Insert(0, "Y");
                is_epcg = true;
            }
            //----------------excemption always Y when EPCG ---------------//
          
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
        return is_epcg;
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'LICENCE', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'LICENCE', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

  
    public void Check_Higher_than_Value_Sum_CIF()
    {
        try
        {
            DataSet ds_CIF = new DataSet();
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.INVOICE_SLNO = INVOICE_SLNO;
            Transact.ITEM_SLNO = ITEM_SLNO;
            Transact.LICENSE_ITEM_NO = txtLicense_ItemNo.Text;
            Transact.DUTY_VALUE = txtRegistration_No.Text;
            Transact.Ename = "Check_Higher_than_Value_Sum_CIF";
            Transact.BRANCH_CODE = SELECT_BRANCH;
            Transact.WORKING_PERIOD = SELECT_BRANCH;

            ds_CIF = Transact.RetrieveAll_License_Details_ITEM_WISE();

            if (Transact.result == 1)
            {
                if (ds_CIF.Tables[0].Rows.Count > 0)
                {
                    // txtDebit_Amount.Text = ds_CIF.Tables[0].Rows[0]["ITEM_DEBIT_AMT"].ToString();
                    hdn_tot_CIF_Amt.Value = ds_CIF.Tables[0].Rows[0]["ITEM_DEBIT_AMT"].ToString();
                }

                if (ds_CIF.Tables[1].Rows.Count > 0)
                {
                    hdn_tot_Debit_Duty.Value = ds_CIF.Tables[1].Rows[0]["ITEM_DEBIT_DUTY"].ToString();
                }

                if (ds_CIF.Tables[2].Rows.Count > 0)
                {
                    hdn_tot_Debit_Qty.Value = ds_CIF.Tables[2].Rows[0]["ITEM_DEBIT_QTY"].ToString();
                }

                if (ds_CIF.Tables[3].Rows.Count > 0)
                {
                    RB_Y_N.SelectedValue = ds_CIF.Tables[3].Rows[0][0].ToString();
                    hdn_Y_N.Value = RB_Y_N.SelectedItem.Text;
                    //Session["RB_Y_N"] = hdn_Y_N.Value;
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }



    [System.Web.Services.WebMethod]
    public static string Get_Remaining_Amt_Qty(string Lic_Regn_No, string ItemNo, string INV_SLNO, string ITEM_SLNO, string Debit_DutyValue_per, string hdn_tot_CIF_Amt, string Type, string Currnt_CIF_Amt, string hdn_tot_Duty_Amt, string Company_ID, string hdn_Duty_based, string hdn_CIF_based, string hdn_Qty_based)
    {
        string AmtQty = "", btn_cif_click = "";
        try
        {
            eroyalmaster erm = new eroyalmaster();
            Transaction Transact = new Transaction();
            Imp_Checklist_Item_License Item_License = new Imp_Checklist_Item_License();
            DataSet ds = new DataSet();
            string Amount = "", Qty = "", DEBIT_AMT = "", tot_DEBIT_AMT = "", DEBIT_QTY = "", tot_DEBIT_QTY = "", Excemption, Reg_Date, Unit, Lic_ItemNo, Port, Lic_No,
                Lic_Date, Desc = "", Curr = "", Exrate = "", Entry_Debit_Duty = "", tot_CIF_VALUE = "", Debit_CIF_VALUE = "", Avail_CIF_VALUE = "", Avail_Master = "", Remaining_CIF = "", Avail_DUTY_VALUE = "";

            Excemption = "";
            Reg_Date = "";
            Unit = "";
            Lic_ItemNo = "";
            Port = "";
            Lic_No = "";
            Lic_Date = "";
            double CIF_Value_per = 0.00;

           

            if (Lic_Regn_No != "")
            {

                //erm.LICENSE_ID = "0";
                erm.LICENSE_ID = ItemNo;
                erm.LICENSE_NO = Lic_Regn_No;
                erm.LICENSE_ITEM_DESCRIPTION = "";
                erm.SCHEME_CODE = HttpContext.Current.Session["SCHEME_CODE"].ToString();
                erm.Ename = "Get_Remaining_Debit_Amt";
                erm.EWorking_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();

                ds = erm.RetrieveAll_IMPORT_LICENSE_MASTER();


                /* hide on 09-03-2021 for Lotus sugg.By Bala sir - its should come CIF Value only
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Amount = ds.Tables[0].Rows[0]["REMAINING_AMT"].ToString();
                }
                else
                {
                    Amount = "0";
                }
                 **/

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Amount = ds.Tables[0].Rows[0]["REMAINING_AMT"].ToString();
                }
                else
                {
                    Amount = "0";
                }



                if (ds.Tables[1].Rows.Count > 0)
                {
                    Qty = ds.Tables[1].Rows[0]["REMAINING_QTY"].ToString();
                }
                else
                {
                    Qty = "0";
                }

                if (ds.Tables[2].Rows.Count > 0)// from sum of License Details ENTRY_DEBIT_DUTY
                {
                    DEBIT_AMT = ds.Tables[2].Rows[0]["DEBIT_AMT"].ToString();
                }
                else
                {
                    DEBIT_AMT = "0";
                }

                if (ds.Tables[3].Rows.Count > 0)// from License MASTER  TOTAL_DEBIT_AMT
                {
                    tot_DEBIT_AMT = ds.Tables[3].Rows[0]["TOTAL_DEBIT_AMT"].ToString();
                }
                else
                {
                    tot_DEBIT_AMT = "0";
                }

                if (ds.Tables[4].Rows.Count > 0)// from sum of License Details DEBIT_QTY
                {
                    DEBIT_QTY = ds.Tables[4].Rows[0]["DEBIT_QTY"].ToString();
                }
                else
                {
                    DEBIT_QTY = "0";
                }

                if (ds.Tables[5].Rows.Count > 0)// from License MASTER  TOTAL_DEBIT_QTY
                {
                    tot_DEBIT_QTY = ds.Tables[5].Rows[0]["TOTAL_DEBIT_QTY"].ToString();
                }
                else
                {
                    tot_DEBIT_QTY = "0";
                }

                if (hdn_CIF_based == "Y")
                {
                    if (ds.Tables[7].Rows.Count > 0)// TOTAL_CIF_VALUE- DEBIT_AMT
                    {
                        Remaining_CIF = ds.Tables[7].Rows[0]["REMAINING_CIF"].ToString();
                    }
                    else
                    {
                        Remaining_CIF = "0";
                    }
                }
                else
                {
                    Remaining_CIF = Currnt_CIF_Amt;
                }

                if (ds.Tables[8].Rows.Count > 0)// from IMPORT_LICENSE_MASTER
                {
                    Avail_Master = "Yes";
                    Excemption = ds.Tables[8].Rows[0]["EXCEMPTION"].ToString();
                    Reg_Date = ds.Tables[8].Rows[0]["REGISTRATION_DATE"].ToString().Replace("01/01/1900", "");
                    Unit = ds.Tables[8].Rows[0]["UNIT_QTY"].ToString();
                    Lic_ItemNo = ds.Tables[8].Rows[0]["LICENSE_ITEM_NO"].ToString();
                    Port = ds.Tables[8].Rows[0]["PORT_OF_LICENSE"].ToString();

                    Lic_No = ds.Tables[8].Rows[0]["LICENSE_NO"].ToString();
                    Lic_Date = ds.Tables[8].Rows[0]["LICENSE_DATE"].ToString().Replace("01/01/1900", "");
                    Desc = ds.Tables[8].Rows[0]["LICENSE_DESC"].ToString();
                    Curr = ds.Tables[8].Rows[0]["LICENSE_CURRENCY"].ToString();

                    Exrate = GetExchange_Rate_License_Cur(Curr).Replace("~", "");
                }
                else
                {
                    //tot_DEBIT_QTY = "0";
                    Avail_Master = "";
                }

                if (ds.Tables[9].Rows.Count > 0)// from IMPORT_LICENSE_MASTER
                {
                    tot_CIF_VALUE = ds.Tables[9].Rows[0]["TOTAL_CIF_VALUE"].ToString();
                }
                else
                {
                    tot_CIF_VALUE = "0";
                }


                if (ds.Tables[10].Rows.Count > 0)// from sum of License Details DEBIT_AMT
                {
                    Debit_CIF_VALUE = ds.Tables[10].Rows[0]["DEBIT_AMT"].ToString();
                }
                else
                {
                    Debit_CIF_VALUE = "0";
                }

                //Avail_CIF_VALUE = Convert.ToString((Convert.ToDouble(tot_CIF_VALUE) - (Convert.ToDouble(Debit_CIF_VALUE) - Convert.ToDouble(hdn_tot_CIF_Amt))));
                //Avail_CIF_VALUE = Convert.ToString(Convert.ToDouble(Debit_CIF_VALUE) - Convert.ToDouble(hdn_tot_CIF_Amt));

                //Avail_CIF_VALUE = Convert.ToString(Convert.ToDouble(Debit_CIF_VALUE) - Convert.ToDouble(Currnt_CIF_Amt));
                //Avail_CIF_VALUE = Convert.ToString(Convert.ToDouble(Currnt_CIF_Amt) + Convert.ToDouble(Avail_CIF_VALUE));

                //Its only for MEIS with DEBIT DUTY VAL - Calc - Not for CIF calc

                //----------------------- To get Remaining CIF Value -----------------------------------
                Avail_CIF_VALUE = Convert.ToString(Convert.ToDouble(tot_CIF_VALUE) - Convert.ToDouble(hdn_tot_CIF_Amt));
                //Avail_CIF_VALUE = Convert.ToString(Convert.ToDouble(Currnt_CIF_Amt) + Convert.ToDouble(Avail_CIF_VALUE));


                //--Its for Should not check CIF Amt
                //if (Company_ID != "10" && Company_ID != "11" && Company_ID != "1" && Company_ID != "4" && Company_ID != "5" && Company_ID != "951" && Company_ID != "747")
                if (hdn_CIF_based == "Y")
                {
                    //New Implementation on 12-03-2021 for Lotus Integrated by Chithra

                    if (Convert.ToDouble(hdn_tot_CIF_Amt) > Convert.ToDouble(Remaining_CIF))
                    {
                        hdn_tot_CIF_Amt = Remaining_CIF;
                    }

                    //----------------------- To get Remaining Duty Value -----------------------------------

                    Avail_DUTY_VALUE = Convert.ToString(Convert.ToDouble(tot_DEBIT_AMT) - Convert.ToDouble(hdn_tot_Duty_Amt));

                    if (Convert.ToDouble(hdn_tot_Duty_Amt) > Convert.ToDouble(Amount))
                    {
                        hdn_tot_Duty_Amt = Amount;
                    }


                    btn_cif_click = "btn_Calc";
                    HttpContext.Current.Session["btn_cif_click"] = "btn_Calc";

                    if (Type == "Save")
                    {
                        HttpContext.Current.Session["INDIVIDUAL_CIF_VALUE"] = hdn_tot_CIF_Amt;
                    }
                    else
                    {
                        HttpContext.Current.Session["INDIVIDUAL_CIF_VALUE"] = Avail_CIF_VALUE;
                    }


                    //Item_License.Page_Load_Item_Details(INV_SLNO, ITEM_SLNO);
                    Item_License.Page_Load_Item_Details(INV_SLNO, ITEM_SLNO, "", "");
                    Entry_Debit_Duty = HttpContext.Current.Session["ENTRY_DEBIT_DUTY_FINAL"].ToString();
                }

                else if (hdn_Duty_based == "Y")
                {
                    Entry_Debit_Duty = hdn_tot_Duty_Amt;

                    Avail_DUTY_VALUE = Convert.ToString(Convert.ToDouble(tot_DEBIT_AMT) - Convert.ToDouble(hdn_tot_Duty_Amt));

                    if (Convert.ToDouble(Amount) < Convert.ToDouble(hdn_tot_Duty_Amt))
                    {
                        Entry_Debit_Duty = Amount;
                        //DEBIT_AMT = hdn_tot_CIF_Amt;
                    }

                    /*
                    double CIF_Value = Convert.ToDouble(txtCIF_Value.Text);
                    double Debit_Value = Convert.ToDouble(txtDebit_DutyValue.Text);
                    double CIF_per = Convert.ToDouble(txtDebit_DutyValue_per.Text);
                    double CIF_Value_per = 0.00;
                    CIF_Value_per = (CIF_Value / Debit_Value) * CIF_per;
                    txtDebit_Amount.Text = Convert.ToString(Math.Round(CIF_Value_per + 0.00, 2));
                    */

                    if (hdn_tot_CIF_Amt != "0.00" && hdn_tot_Duty_Amt != "0.00" && Entry_Debit_Duty != "0.00")
                    {
                        double CIF_Value = Convert.ToDouble(hdn_tot_CIF_Amt);
                        //double CIF_Value = Convert.ToDouble(Avail_CIF_VALUE);
                        double Debit_Value = Convert.ToDouble(hdn_tot_Duty_Amt);
                        double CIF_per = Convert.ToDouble(Entry_Debit_Duty);
                        //double CIF_Value_per = 0.00;
                        CIF_Value_per = (CIF_Value / Debit_Value) * CIF_per;
                        //txtDebit_Amount.Text = Convert.ToString(Math.Round(CIF_Value_per + 0.00, 2));
                        CIF_Value_per = Math.Round(CIF_Value_per + 0.00, 2);
                    }
                }
                else // No selection from License master Settings
                {
                    Entry_Debit_Duty = hdn_tot_Duty_Amt;
                }

                //if (Convert.ToDouble(Debit_CIF_Amt) < Convert.ToDouble(DEBIT_AMT))
                //if (Convert.ToDouble(Debit_CIF_Amt) < Convert.ToDouble(hdn_tot_CIF_Amt)) 
                //if (Convert.ToDouble(hdn_tot_CIF_Amt) < Convert.ToDouble(Amount))
                if (Convert.ToDouble(hdn_tot_CIF_Amt) < Convert.ToDouble(hdn_tot_CIF_Amt))
                {
                    Entry_Debit_Duty = Entry_Debit_Duty;
                    //DEBIT_AMT = hdn_tot_CIF_Amt;
                }
                DEBIT_AMT = hdn_tot_CIF_Amt;
            }
            else
            {
                Entry_Debit_Duty = Debit_DutyValue_per;
                DEBIT_AMT = hdn_tot_CIF_Amt;
            }

            AmtQty = Amount + "*" + Qty + "*" + DEBIT_AMT + "*" + tot_DEBIT_AMT + "*" + DEBIT_QTY + "*" + tot_DEBIT_QTY + "*" + Excemption + "*" + Reg_Date + "*" + Unit + "*" + Lic_ItemNo + "*" + Port + "*" + Lic_No + "*" + Lic_Date + "*" + Desc + "*" + Curr + "*" + Exrate + "*" + Entry_Debit_Duty + "*" + tot_CIF_VALUE + "*" + Avail_CIF_VALUE + "*" + Avail_Master + "*" + Remaining_CIF + "*" + CIF_Value_per;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return AmtQty;
    }


    [System.Web.Services.WebMethod]
    public static string Get_Entry_Debit_Duty_As_Per_CIF(string CIF_Amount, string INV_SLNO, string ITEM_SLNO, string Debit_Qty, string EntryMode)
    {
        string Entry_Debit_Duty = "", btn_cif_click = "";
        try
        {
            
            Imp_Checklist_Item_License Item_License = new Imp_Checklist_Item_License();

            btn_cif_click = "btn_Calc";
            HttpContext.Current.Session["btn_cif_click"] = "btn_Calc";
            HttpContext.Current.Session["INDIVIDUAL_CIF_VALUE"] = CIF_Amount;

            Item_License.Page_Load_Item_Details(INV_SLNO, ITEM_SLNO, Debit_Qty, EntryMode);

            Entry_Debit_Duty = HttpContext.Current.Session["ENTRY_DEBIT_DUTY_FINAL"].ToString();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return Entry_Debit_Duty + "*" + "";
    }

    protected void btn_Calc_CIF_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtDebit_Amount.Text != "")
            {
                btn_cif_click = "btn_Calc";
                Session["btn_cif_click"] = "btn_Calc";
                Session["INDIVIDUAL_CIF_VALUE"] = txtDebit_Amount.Text;

                //Item_License.Page_Load_Item_Details(INVOICE_SLNO, ITEM_SLNO);//hide on 31-12-2025
                Item_License.Page_Load_Item_Details(INVOICE_SLNO, ITEM_SLNO, txtDebit_Qty.Text, "License_edit_Qty");
                //txtDebit_DutyValue_per.Text = Convert.ToString(Math.Round(Convert.ToDouble(Session["ENTRY_DEBIT_DUTY_FINAL"].ToString()) + 0.00, 2));
                txtDebit_DutyValue_per.Text = Session["ENTRY_DEBIT_DUTY_FINAL"].ToString();//14/03/2017
                //CIF_VALUE_PER = Item_License.Get_Individual_CIF_Amount_Calc_LICENSE(Convert.ToDouble(txtCIF_Value_per.Text), btn_cif_click);

                hdn_current_event.Value = "btn_Calc_CIF_Click";
            }
            else
            {
                txtDebit_DutyValue_per.Text = "";
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void btn_CIF_Calc_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtCIF_Value.Text != "")
            {
                if (txtDebit_DutyValue.Text != "")
                {
                    if (txtDebit_DutyValue_per.Text != "")
                    {
                        double CIF_Value = Convert.ToDouble(txtCIF_Value.Text);
                        double Debit_Value = Convert.ToDouble(txtDebit_DutyValue.Text);
                        double CIF_per = Convert.ToDouble(txtDebit_DutyValue_per.Text);
                        double CIF_Value_per = 0.00;
                        CIF_Value_per = (CIF_Value / Debit_Value) * CIF_per;
                        txtDebit_Amount.Text = Convert.ToString(Math.Round(CIF_Value_per + 0.00, 2));
                        //txtCIF_Value_per.Text = Convert.ToString(CIF_Value_per);
                        //txtDebit_Amount.Text = Convert.ToString(CIF_Value_per);//14/03/2017

                        hdn_current_event.Value = "btn_CIF_Calc_Click";

                    }
                    else
                    {
                        Alert_msg("Enter the CIF Value");
                    }
                }
                else
                {
                    Alert_msg("Total Debit Duty Should not be Empty");
                }
            }
            else
            {
                Alert_msg("Total CIF Vlaue Should not be Empty");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    [System.Web.Services.WebMethod]
    public static string GetExchange_Rate_License_Cur(string custid)
    {
        try
        {
            if (custid.Length == 3)
            {
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();
                Auto.Ename = "EXCHANGE_MASTER_RATE_IMPORTWISE";
                Auto.Enamesearch = custid;
                ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {

                    custid = ds.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString() + "~~" + " " + "~~" + " " + "~~" + " " + "~~" + " " + "~~" + " ";

                }
                else
                {
                    Auto.Ename = "NON_STD_CUR_RATE_IMPORTWISE";
                    Auto.Enamesearch = custid;
                    ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string NON_STD_RATE_IMPORT = ds.Tables[0].Rows[0]["NON_STD_RATE_IMPORT"].ToString();
                        string NON_STD_EFFECT_DT_IMP = ds.Tables[0].Rows[0]["NON_STD_EFFECT_DT_IMP"].ToString();
                        string NON_STD_BANKNAME = ds.Tables[0].Rows[0]["NON_STD_BANKNAME"].ToString();
                        string NON_STD_CERTIFICATE_NO = ds.Tables[0].Rows[0]["NON_STD_CERTIFICATE_NO"].ToString();
                        string NON_STD_CERTIFICATE_DATE = ds.Tables[0].Rows[0]["NON_STD_CERTIFICATE_DATE"].ToString();

                        custid = NON_STD_RATE_IMPORT + "~~" + NON_STD_EFFECT_DT_IMP + "~~" + NON_STD_BANKNAME + "~~" + NON_STD_CERTIFICATE_NO + "~~" + NON_STD_CERTIFICATE_DATE;
                    }
                    else

                        custid = "";
                }
            }
            else
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

    protected void btn_ExRate_UpdateAll_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in gv_exrate.Rows)
            {
                TextBox txt_ExRate = (TextBox)row.FindControl("txt_ExRate");
                TextBox txt_licCurr = (TextBox)row.FindControl("txt_licCurr");


                DataSet ds1 = new DataSet();
                Transact.JOBNO = IMPORT_JOBNO;
                Transact.INVOICE_SLNO = row.Cells[1].Text;
                Transact.ITEM_SLNO = ITEM_SLNO;
                Transact.DEBIT_AMT = txt_licCurr.Text;
                Transact.DEBIT_DUTY = txt_ExRate.Text;
                Transact.LICENSE_ID = "0";
                Transact.WORKING_PERIOD = SELECT_BRANCH;

                Transact.Ename = "UpdateAll_ExRate_Job";
                ds1 = Transact.RetrieveAll_License_Details();
                result = Transact.result;


            }
            if (result == 1)
            {
                Gridbind_License();
                Alert_msg("Ex.Rate Updated..");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    protected void btn_Refresh_License_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds1 = new DataSet();
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.INVOICE_SLNO = "";
            Transact.ITEM_SLNO = ITEM_SLNO;
            Transact.DEBIT_AMT = "";
            Transact.DEBIT_DUTY = "";
            Transact.LICENSE_ID = "0";
            Transact.WORKING_PERIOD = Connection.Get_Company_Type();

            Transact.Ename = "Clear_All_CIF_Duty_for_new_Exrate_Update";
            ds1 = Transact.RetrieveAll_License_Details();
            result = Transact.result;


            if (result == 1)
            {
                Alert_msg("Done..Re- Generate the Checklist");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
    }

    [System.Web.Services.WebMethod]
    //public static string Check_License_Balance(string LicenseNo, string ItemNo)
    public static double Check_License_Balance(string LicenseNo, string ItemNo)
    {
        eroyalmaster erm = new eroyalmaster();
        DataSet ds = new DataSet();
        double Amount = 0.00;
        try
        {
            if (LicenseNo != "")
            {
                erm.LICENSE_ID = ItemNo;
                erm.LICENSE_NO = LicenseNo;
                erm.LICENSE_ITEM_DESCRIPTION = "";
                erm.SCHEME_CODE = HttpContext.Current.Session["SCHEME_CODE"].ToString();
                erm.Ename = "Get_License_Balance";
                erm.EWorking_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();

                ds = erm.RetrieveAll_IMPORT_LICENSE_MASTER();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Amount = Convert.ToDouble(ds.Tables[0].Rows[0]["REMAINING_AMT"].ToString());
                }
                else
                {
                    Amount = 0.00;
                }
            }

           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return Amount;

    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        try
        {
            //btnSave_Click(sender, e);
            btnNew_Click(sender, e);
            mp_save_Alert.Hide();
            txtRegistration_No.Focus();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            
        }
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

    protected void btnDelete_all_Click(object sender, EventArgs e)
    {
        try
        {
            Transact.JOBNO = IMPORT_JOBNO;
            Transact.INVOICE_SLNO = INVOICE_SLNO;
            Transact.ITEM_SLNO = ITEM_SLNO;
            Transact.DEBIT_AMT = "";
            Transact.DEBIT_DUTY = "";

            Transact.LICENSE_ID = ViewState["License_ID"].ToString();

            Transact.WORKING_PERIOD = SELECT_BRANCH;

            Transact.Ename = "delete_all";
            dss = Transact.RetrieveAll_License_Details();
            Grid_Empty();
            int ii = 0;
            ii = Transact.result;

            if (ii > 0)
            {
               // btnNew_Click(sender, e);
                Transact.ResetFields(Page.Controls);
                Alert_msg(" Bulk Licence Deleted");
            }
            else
            {
                Alert_msg("Licence Not Deleted");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
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
            Dt_Change.GetMismatchedRowsFast(dt_Prev, dt_modified, "LICENSE_ID", "License", IMPORT_JOBNO, hdinvslno.Value, hditemslno.Value, currentuser, Connection.Current_Branch());
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

            dr["LICENSE_ID"] = hdn_update_License.Value; // Auto / Identity (if any)
            dr["JOBNO"] = IMPORT_JOBNO;
            dr["INVOICE_SLNO"] = hdinvslno.Value;
            dr["ITEM_SLNO"] = hditemslno.Value;
            dr["SCHEME_CODE"] = hdn_Schemecode.Value;
            dr["REGISTRATION_NO"] = txtRegistration_No.Text;
            dr["REGISTRATION_DATE"] = txtRegistration_Date.Text;
            dr["EXCEMPTION"] = ddlExcemption.SelectedValue;
            dr["DEBIT_AMT"] = txtDebit_Amount.Text;
            dr["DEBIT_QTY"] = txtDebit_Qty.Text;
            dr["UNIT_QTY"] = txtUnit_Qty.Text;
            dr["LICENSE_ITEM_NO"] = txtLicense_ItemNo.Text;
            dr["PORT_OF_LICENSE"] = txtPort_Of_Licenses.Text;
            dr["DEBIT_DUTY"] = txtDebit_DutyValue_per.Text;
            dr["LICENSE_NO"] = txtLicense_No.Text;
            dr["LICENSE_DATE"] = txtLicense_Date.Text;
            dr["TOTAL_CIF_VALUE"] = txtCIF_Value.Text;
            dr["TOTAL_DEBIT_DUTY"] = txtDebit_DutyValue.Text;
            dr["ENTRY_DEBIT_DUTY"] = txtDebit_DutyValue_per.Text;
            dr["LIC_DESC"] = txt_lic_desc.Text;
            dr["LICENSE_CURRENCY"] = txt_LicenseCurrency.Text;
            dr["EX_RATE"] = txt_Exrate.Text;

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
