using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class Export_Export_Drawback : ThemeClass
{
    Certificate_Of_Origin certificate = new Certificate_Of_Origin();
    EXP_BL_Generation BL_Gen = new EXP_BL_Generation();
    Transaction trans = new Transaction();
    DataSet dtuser = new DataSet();
    DataSet ds = new DataSet();
    AppSession aps = new AppSession();
  
    public string Trans_ID = "";
    ErrorLogs er = new ErrorLogs();
    public int i;
    public string AUTO_ID;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public string EXPORT_JOBNO, INV_SLN0, ITEM_SLNO, SCHEME_CODE, RITC_NO, ITEM_DESC;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public string FILE_REF_NO, BRANCH_NO, IEC_NO, TRANSPORT_MODE;
    public int Screen_Id;
    User_Creation user_Create = new User_Creation();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        TRANSPORT_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();

        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
            }
            else
            {
                SELECT_BRANCH = "";
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }
        if (!IsPostBack)
        {
            string Category_mode = "";
            if (TRANSPORT_MODE == "A")
                Category_mode = "Air";
            if (TRANSPORT_MODE == "S")
                Category_mode = "Sea";
            if (TRANSPORT_MODE == "L")
                Category_mode = "Land";

            hdfTransport_mode1.Value = Category_mode;

            Get_JobNo();

            if (Request.QueryString["Page"] == "New")
            {              
                hdn_Jobno.Value = ddlJobNo.SelectedItem.Text;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                //BtnAddAnnex.Visible = false;
                btnSave.Visible = true;
                btnl_Annex.Visible = false;
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    hdn_Jobno.Value = txt_JobNo.Text;
                    Bind_All_DropdownSelectedValue();
                    //Update_Item_Load();
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    //BtnAddAnnex.Visible = true;
                    btnSave.Visible = false;
                    //btnl_Annex.Visible = true;
                    //HdnUpdate_id.Value = Request.QueryString["Page"].ToString();
                }
            }            
        }
        Check_JobNo();
    }

    public void Get_JobNo()
    {
        certificate.JOBNO = "";
        certificate.BRANCH_CODE = SELECT_BRANCH;
        certificate.WORKING_PERIOD = SELECT_BRANCH;
        certificate.Ename = "Get_COO_Except_JobNo";

        ds = certificate.COO_NORMAL_SEARCH();
        ddlJobNo.DataSource = ds.Tables[0];
        ddlJobNo.DataTextField = "JOBNO";
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataBind();
        ddlJobNo.Items.Insert(0, "Select");

        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
        btnSearch.Visible = false;
        btnNew.Visible = true;
    }

    public void Check_JobNo()
    {
        certificate.JOBNO = hdn_Jobno.Value;
        certificate.WORKING_PERIOD = SELECT_BRANCH;
        certificate.Ename = "Check_JobNo";
        ds = certificate.COO_NORMAL_SEARCH();
        i = certificate.result;

        HdnFld_CheckJobNo.Value = Convert.ToString(i);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlJobNo.SelectedItem.Text != "Select")
            {
                string F = "S";
                hdn_Jobno.Value = ddlJobNo.SelectedItem.Text;
                i = Export_Certificate_Of_Origin_Insert_Update(F);

                if (txt_Marks_Nos.Text != "" || txt_Description.Text != "")
                {
                    Annexure_Insert_Update();
                }

                if (i == 1)
                {
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSearch.Visible = true;
                    btnSave.Visible = false;
                    btnNew.Visible = false;
                    btnSave.Enabled = false;
                    btnl_Annex.Visible = true;

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);
                    Alert_msg("Saved Successfully", "btnSave");
                }
                else if (i == 2)
                {
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Not Save, Job No Already Exist')</script>", false);
                    Alert_msg("Job No Already Exist!", "btnSave");
                }
                else
                {
                    btnUpdate.Visible = false;
                    btnSearch.Visible = false;
                    btnDelete.Visible = false;
                    //BtnAddAnnex.Visible = false;
                    btnSave.Visible = true;
                    btnNew.Visible = true;
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
                    Alert_msg("Not Saved", "btnSave");

                }
            }
            else
            {
                Alert_msg("Select Valid Job No");
            }
        }
        
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        Check_JobNo();

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            hdn_Jobno.Value = txt_JobNo.Text;
            string F = "U";
            i = Export_Certificate_Of_Origin_Insert_Update(F);

            if (txt_Marks_Nos.Text != "" || txt_Description.Text != "")
            {
                Annexure_Insert_Update();
            }

            if (i == 1)
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSearch.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
                btnl_Annex.Visible = true;
                btnSave.Enabled = false;

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Updated Successfully')</script>", false);
                Alert_msg("Updated Successfully", "btnUpdate");

            }
            else if (i == 2)
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Not Save, Job No Already Exist')</script>", false);
                Alert_msg("Job No Already Exist!", "btnUpdate");
            }
            else
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSearch.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
                Alert_msg("Not Saved", "btnUpdate");

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
            BL_Gen.JOBNO = txt_JobNo.Text;
            BL_Gen.BRANCHCODE = SELECT_BRANCH;
            BL_Gen.WORKINGPERIOD = Working_Period;
            BL_Gen.REPORT_TYPE = "Certificate of Origin";
            BL_Gen.Ename = "Certificate_Of_Origin_Delete_All";

            ds = BL_Gen.BL_Container_Select_All();
            i = BL_Gen.result;
            
            if (i == 1)
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSearch.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
                trans.ResetFields(Page.Controls);
                //txtIECNo.Focus();
                btnSave.Enabled = false;

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Updated Successfully')</script>", false);
                Alert_msg("Record Deleted", "btnUpdate");

            }
            
            else
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSearch.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
                Alert_msg("Record Not Deleted", "btnUpdate");

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
        btnSearch.Visible = false;
        btnNew.Visible = true;
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Certificate Of Origin', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Certificate Of Origin', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlJobNo.SelectedValue == "Select")
            {
                FILE_REF_NO = "";
                txtToOrder.Text = "";
                txtExporter.Text = "";
                BRANCH_NO = "";
                IEC_NO = "";
                txtAddress1.Text = "";
                txtAddress2.Text = "";
                txtAddress3.Text = "";
                txtAddress4.Text = "";
                txtAddress5.Text = "";

                txtConsignee.Text = "";
                txtConsignee_Add1.Text = "";
                txtConsignee_Add2.Text = "";
                txtConsignee_Add3.Text = "";
                txtConsignee_Add4.Text = "";
                txtConsignee_Add5.Text = "";

                txtNotify.Text = "";
                txtNotify_Add1.Text = "";
                txtNotify_Add2.Text = "";
                txtNotify_Add3.Text = "";
                txtNotify_Add4.Text = "";
                txtNotify_Add5.Text = "";

                txtPre_Carriageby.Text = "";
                txtPlace_Precarier.Text = "";
                txtVessel_Flight.Text = "";
                txtPort_Of_Loading.Text = "";
                txtPort_Of_Discharge.Text = "";
                txtFinal_Destination.Text = "";

                txtMarksNos_Container.Text = "";
                txtNo_Kind_Pkgs.Text = "";
                txtGoods_Desc.Text = "";
                txtOrigin_Criterion.Text = "";
                txtGross_weight.Text = "";
                //txtMeasurement.Text = "";
                txtInvNo_Date.Text = "";
                txtImporting_Country.Text = "";
                txtRemarks.Text = "";

                txtAuthorised_Signatory.Text = "";
                txtSignature_Date.Text = "";

                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                //BtnAddAnnex.Visible = false;
                btnSave.Visible = true;
                btnl_Annex.Visible = false;
                btnSearch.Visible = false;
            }
            else
            {
                Bind_All_DropdownSelectedValue();
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
    }

    public int Export_Certificate_Of_Origin_Insert_Update(string Flag)
    {

        certificate.CER_ORG_ID = "0";
        certificate.JOBNO = hdn_Jobno.Value;
        certificate.FILE_REF_NO = FILE_REF_NO;
        certificate.TO_ORDER = txtToOrder.Text;
        certificate.EXPORTER_NAME = txtExporter.Text;
        certificate.BRANCH_NO = BRANCH_NO;
        certificate.IEC_NO = IEC_NO;
        certificate.ADDRESS1 = txtAddress1.Text;
        certificate.ADDRESS2 = txtAddress2.Text;
        certificate.ADDRESS3 = txtAddress3.Text;
        certificate.ADDRESS4 = txtAddress4.Text;
        certificate.ADDRESS5 = txtAddress5.Text;

        certificate.CONSIGNEE_NAME = txtConsignee.Text;
        certificate.CONSIGNEE_ADD1 = txtConsignee_Add1.Text;
        certificate.CONSIGNEE_ADD2 = txtConsignee_Add2.Text;
        certificate.CONSIGNEE_ADD3 = txtConsignee_Add3.Text;
        certificate.CONSIGNEE_ADD4 = txtConsignee_Add4.Text;
        certificate.CONSIGNEE_ADD5 = txtConsignee_Add5.Text;

        certificate.NOTIFY_NAME = txtNotify.Text;
        certificate.NOTIFY_ADD1 = txtNotify_Add1.Text;
        certificate.NOTIFY_ADD2 = txtNotify_Add2.Text;
        certificate.NOTIFY_ADD3 = txtNotify_Add3.Text;
        certificate.NOTIFY_ADD4 = txtNotify_Add4.Text;
        certificate.NOTIFY_ADD5 = txtNotify_Add5.Text;

        if (txtPre_Carriageby.Text.Contains('-'))
        {
            string[] cc = txtPre_Carriageby.Text.Split('-');
            certificate.PRE_CARRIAGE_BY = cc[0];
        }
        else
        {
            certificate.PRE_CARRIAGE_BY = txtPre_Carriageby.Text;
        }

        if (txtPlace_Precarier.Text.Contains('-'))
        {
            string[] cc = txtPlace_Precarier.Text.Split('-');
            certificate.PLACE_OF_RECEIPT = cc[0];
        }
        else
        {
            certificate.PLACE_OF_RECEIPT = txtPlace_Precarier.Text;
        }
        

        certificate.VESSEL_FLIGHT_NO = txtVessel_Flight.Text;

        if (txtPort_Of_Loading.Text.Contains('-'))
        {
            string[] cc = txtPort_Of_Loading.Text.Split('-');
            certificate.PORT_OF_LOADING = cc[0];
        }
        else
        {
            certificate.PORT_OF_LOADING = txtPort_Of_Loading.Text;
        }

        if (txtPort_Of_Discharge.Text.Contains('-'))
        {
            string[] cc = txtPort_Of_Discharge.Text.Split('-');
            certificate.PORT_OF_DISCHARGE = cc[0];
        }
        else
        {
            certificate.PORT_OF_DISCHARGE = txtPort_Of_Discharge.Text;
        }

        if (txtFinal_Destination.Text.Contains('-'))
        {
            string[] cc = txtFinal_Destination.Text.Split('-');
            certificate.FINAL_DEST = cc[0];
        }
        else
        {
            certificate.FINAL_DEST = txtFinal_Destination.Text;
        }

       
        certificate.MARK_NOS_CONTAINER_NO = txtMarksNos_Container.Text;
        certificate.NO_KIND_OF_PACKAGES = txtNo_Kind_Pkgs.Text;

        certificate.DESCRIPTION_GOODS = txtGoods_Desc.Text;
        certificate.ORIGIN_CRITERIA = txtOrigin_Criterion.Text;
        certificate.GROSS_WEIGHT = txtGross_weight.Text;
        //certificate.MEASUREMENT = txtMeasurement.Text;
        certificate.MEASUREMENT = "";

        certificate.NO_DATE_OF_INVOICE = txtInvNo_Date.Text;
        certificate.IMPORTING_COUNTRY = txtImporting_Country.Text;

        certificate.REMARKS = txtRemarks.Text;
        certificate.AUTHORISED_SIGNATORY = txtAuthorised_Signatory.Text;
        certificate.SIGNATURE_DATE = txtSignature_Date.Text;

        certificate.USER_ID = currentuser;
        certificate.YEAR = "";
        certificate.flag = Flag;
        certificate.BRANCH_CODE = SELECT_BRANCH;
        certificate.WORKING_PERIOD = Working_Period;

        certificate.BRANCH_COMMON = SELECT_BRANCH;

        i = certificate.Certificate_Of_Origin_details_insertupdate();
        return i;
    }

    public void Annexure_Insert_Update()
    {

        BL_Gen.JOBNO = hdn_Jobno.Value;
        BL_Gen.REPORT_TYPE = "Certificate of Origin";
        BL_Gen.MARKS_NOS = txt_Marks_Nos.Text;
        BL_Gen.GOODS_DESCRIPTION = txt_Description.Text;
        BL_Gen.flag = "S";

        BL_Gen.USERID = currentuser;
        BL_Gen.STATUS = "S";
        BL_Gen.BRANCHCODE = SELECT_BRANCH;
        BL_Gen.WORKINGPERIOD = Working_Period;
        BL_Gen.LOGIN_DATE = LoginDate;

        BL_Gen.BL_Annexure_Insert_Update(); 
    }

    protected void ddl_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        //btnSearch.Visible = true;
    }

    public void Bind_All_DropdownSelectedValue()
    {
        if (Request.QueryString["Page"] == "New")
        {
            certificate.JOBNO = ddlJobNo.SelectedItem.Text;
            certificate.Ename = "select_certificate_of_origin";

            hdn_Jobno.Value = ddlJobNo.SelectedItem.Text;
        }
        else
        {
            certificate.JOBNO = Request.QueryString["Page"].ToString();
            certificate.Ename = "Bind_Cert_Details";
        }

        certificate.BRANCH_CODE = SELECT_BRANCH;
        certificate.WORKING_PERIOD = SELECT_BRANCH;
        ds = certificate.COO_NORMAL_SEARCH();

        i = certificate.result;
               
                if (i == 1)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        FILE_REF_NO = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
                        txtExporter.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                        BRANCH_NO = ds.Tables[0].Rows[0]["BRANCH_NO"].ToString();
                        IEC_NO = ds.Tables[0].Rows[0]["IEC_NO"].ToString();
                        txtAddress1.Text = ds.Tables[0].Rows[0]["ADDRESS1"].ToString();
                        txtAddress2.Text = ds.Tables[0].Rows[0]["ADDRESS2"].ToString();
                        txtAddress3.Text = ds.Tables[0].Rows[0]["ADDRESS3"].ToString();
                        txtAddress4.Text = ds.Tables[0].Rows[0]["ADDRESS4"].ToString();
                        txtAddress5.Text = ds.Tables[0].Rows[0]["ADDRESS5"].ToString();

                        txtConsignee.Text = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                        txtConsignee_Add1.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();
                        txtConsignee_Add2.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString();
                        txtConsignee_Add3.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString();
                        txtConsignee_Add4.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString();
                        txtConsignee_Add5.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString();

                        txtPort_Of_Discharge.Text = ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString();
                        txtFinal_Destination.Text = ds.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString();

                        TRANSPORT_MODE = ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();
                        txtPort_Of_Loading.Text = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();

                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            txtInvNo_Date.Text = "INVOICE NO : " + Environment.NewLine + ds.Tables[2].Rows[0]["INVOICE_NO"].ToString() + Environment.NewLine + ds.Tables[2].Rows[0]["INVOICE_DATE"].ToString().Replace("01/01/1900", "");

                        }

                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            //txtGoods_Desc.Text = ds.Tables[1].Rows[0]["ITEM_DESCRIPTION"].ToString();
                            txtGoods_Desc.Text = "";

                        }
                        if (TRANSPORT_MODE == "Air")
                        {
                            if (ds.Tables[3].Rows.Count > 0)
                            {
                                //txtMarksNos_Container.Text = ds.Tables[3].Rows[0]["ANNEX_AIR_MARKS_NOS"].ToString();
                                txtMarksNos_Container.Text = "";
                                txtGross_weight.Text = "GROSS WGT : "+ Environment.NewLine +ds.Tables[3].Rows[0]["GROSS_WEIGHT"].ToString();
                            }
                        }
                        else if (TRANSPORT_MODE == "Sea")
                        {
                            if (ds.Tables[4].Rows.Count > 0)
                            {
                                //txtMarksNos_Container.Text = ds.Tables[4].Rows[0]["ANNEX_SEA_MARKS_NOS"].ToString();
                                txtMarksNos_Container.Text = "";
                                txtGross_weight.Text = "GROSS WGT : " + Environment.NewLine + ds.Tables[4].Rows[0]["GROSS_WEIGHT"].ToString();
                            }
                        }
                        btnUpdate.Visible = false;
                        btnDelete.Visible = false;
                        btnSave.Visible = true;
                        btnSearch.Visible = false;
                        btnNew.Visible = true;                    
                    }                   
                }
                else if (i == 2)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txt_JobNo.Visible = true;
                        txt_JobNo.Text = ds.Tables[0].Rows[0]["JOBNO"].ToString();
                        hdn_Jobno.Value = txt_JobNo.Text;
                        FILE_REF_NO = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
                        txtToOrder.Text = ds.Tables[0].Rows[0]["TO_ORDER"].ToString();
                        txtExporter.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                        BRANCH_NO = ds.Tables[0].Rows[0]["BRANCH_NO"].ToString();
                        IEC_NO = ds.Tables[0].Rows[0]["IEC_NO"].ToString();
                        txtAddress1.Text = ds.Tables[0].Rows[0]["ADDRESS1"].ToString();
                        txtAddress2.Text = ds.Tables[0].Rows[0]["ADDRESS2"].ToString();
                        txtAddress3.Text = ds.Tables[0].Rows[0]["ADDRESS3"].ToString();
                        txtAddress4.Text = ds.Tables[0].Rows[0]["ADDRESS4"].ToString();
                        txtAddress5.Text = ds.Tables[0].Rows[0]["ADDRESS5"].ToString();

                        txtConsignee.Text = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                        txtConsignee_Add1.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();
                        txtConsignee_Add2.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString();
                        txtConsignee_Add3.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString();
                        txtConsignee_Add4.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString();
                        txtConsignee_Add5.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString();

                        txtNotify.Text = ds.Tables[0].Rows[0]["NOTIFY_NAME"].ToString();
                        txtNotify_Add1.Text = ds.Tables[0].Rows[0]["NOTIFY_ADD1"].ToString();
                        txtNotify_Add2.Text = ds.Tables[0].Rows[0]["NOTIFY_ADD2"].ToString();
                        txtNotify_Add3.Text = ds.Tables[0].Rows[0]["NOTIFY_ADD3"].ToString();
                        txtNotify_Add4.Text = ds.Tables[0].Rows[0]["NOTIFY_ADD4"].ToString();
                        txtNotify_Add5.Text = ds.Tables[0].Rows[0]["NOTIFY_ADD5"].ToString();

                        txtPre_Carriageby.Text = ds.Tables[0].Rows[0]["PRE_CARRIAGE_BY"].ToString();
                        txtPlace_Precarier.Text = ds.Tables[0].Rows[0]["PLACE_OF_RECEIPT"].ToString();
                        txtVessel_Flight.Text = ds.Tables[0].Rows[0]["VESSEL_FLIGHT_NO"].ToString();
                        txtPort_Of_Loading.Text = ds.Tables[0].Rows[0]["PORT_OF_LOADING"].ToString();
                        txtPort_Of_Discharge.Text = ds.Tables[0].Rows[0]["PORT_OF_DISCHARGE"].ToString();
                        txtFinal_Destination.Text = ds.Tables[0].Rows[0]["FINAL_DEST"].ToString();

                        txtMarksNos_Container.Text = ds.Tables[0].Rows[0]["MARK_NOS_CONTAINER_NO"].ToString();
                        txtNo_Kind_Pkgs.Text = ds.Tables[0].Rows[0]["NO_KIND_OF_PACKAGES"].ToString();
                        txtGoods_Desc.Text = ds.Tables[0].Rows[0]["DESCRIPTION_GOODS"].ToString();
                        txtOrigin_Criterion.Text = ds.Tables[0].Rows[0]["ORIGIN_CRITERIA"].ToString();
                        txtGross_weight.Text = ds.Tables[0].Rows[0]["GROSS_WEIGHT"].ToString();
                        //txtMeasurement.Text = ds.Tables[0].Rows[0]["MEASUREMENT"].ToString();
                        txtInvNo_Date.Text = ds.Tables[0].Rows[0]["NO_DATE_OF_INVOICE"].ToString();
                        txtImporting_Country.Text = ds.Tables[0].Rows[0]["IMPORTING_COUNTRY"].ToString();
                        txtRemarks.Text = ds.Tables[0].Rows[0]["REMARKS"].ToString();

                        txtAuthorised_Signatory.Text = ds.Tables[0].Rows[0]["AUTHORISED_SIGNATORY"].ToString();
                        txtSignature_Date.Text = ds.Tables[0].Rows[0]["SIGNATURE_DATE"].ToString();

                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                        btnSearch.Visible = true;
                        btnSave.Visible = false;

                        btnNew.Visible = false;
                        ddlJobNo.Visible = false;

                        //if (txt_Description.Text != "" || txt_Marks_Nos.Text != "")
                        //{
                        //    btnl_Annex.Visible = true;
                        //}
                        //else
                        //{
                        //    btnl_Annex.Visible = false;
                        //}

                    }                                  
             }
           Bind_Annexure_Details();
    }

    public void Bind_Annexure_Details()
    {
        BL_Gen.JOBNO = hdn_Jobno.Value;
        BL_Gen.REPORT_TYPE = "Certificate of Origin";
        BL_Gen.Ename = "Select_BL_Annexure";
        BL_Gen.BRANCHCODE = SELECT_BRANCH;
        ds = BL_Gen.BL_Container_Select_All();

        if (ds.Tables[0].Rows.Count > 0)
        {
            txt_Marks_Nos.Text = ds.Tables[0].Rows[0]["MARKS_NOS"].ToString();
            txt_Description.Text = ds.Tables[0].Rows[0]["GOODS_DESCRIPTION"].ToString();
            btnl_Annex.Visible = true;
        }
        else
        {
            btnl_Annex.Visible = false;
        }
    }

    protected void btnl_Annex_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "tab_page4();", true);
    }

}