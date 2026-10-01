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
using System.IO;

public partial class Transaction_General_New : System.Web.UI.Page
{
    DataSet dtuser = new DataSet();
    Transaction Transact = new Transaction();
    SqlConnection con;
    SqlCommand cmd;
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    Transaction trans = new Transaction();
    public string Trans_ID = "";
    ErrorLogs er = new ErrorLogs();
    public int i;
    public string AUTO_ID;

    //public string chksec46, chkFirCheck, chkGrnChannel, chkKach, chkSec48, chkHghSeaSale;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    Date_Time dt = new Date_Time();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtCustomsHouse.Focus();

        aps.checkSession();
        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
        
        txtJobDate.Text = dt.Today_Date();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        
        txtJobDate.Focus();

        
       
            ///------------------------------------------------auto search-----------------------------------------------------------------
            //IMPORTER
        txtImporterName.Attributes.Add("onblur", "javascript:CallServerside_Importer('" + txtImporterName.ClientID + "', '" + txtIECNo.ClientID + "')");
            txtBranchNo.Attributes.Add("onblur", "javascript:CallServerside_Importer_Branch('" + txtBranchNo.ClientID + "', '" + txtIECNo.ClientID + "')");
            //IMPORTER

            //HSS DETAILS
            txtSellerName.Attributes.Add("onblur", "javascript:CallServerside_Seller('" + txtSellerName.ClientID + "', '" + txtHighSeaSaleIECNo.ClientID + "')");
            txtBranchSLNo.Attributes.Add("onblur", "javascript:CallServerside_BranchSeller('" + txtBranchSLNo.ClientID + "', '" + txtHighSeaSaleIECNo.ClientID + "')");
            //HSS DETAILS

            ///------------------------------------------------auto search-----------------------------------------------------------------
       
      
            
            if (!IsPostBack)
            {

                if (!string.IsNullOrEmpty(Request["Page"]))
                {
                    string s = Request["Page"].ToString();
                    if (Request["Page"] == "New")
                    {
                        //hdn_Jobno.Value = "";
                        Session.Remove("TRANSPORT_MODE");
                        Session.Remove("IMPORT_JOBNO");
                        Session.Remove("IMPORT_JOBDATE");
                        Session.Remove("FILING_STATUS");

                    }
                }
                else
                {
                    hdn_Jobno.Value = txtJobNo.Text;

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
                //--------------- dont delete--------------------------------------//
                Edit_GeneralDetails();
               
            }
           
        //if (ddlTransportMode.SelectedValue != "Select")
        //{

        //    txtCustomsHouse.Enabled = true;
        //    Panel1.Enabled = true;

        //}
        //else
        //{

        //    txtCustomsHouse.Enabled = false;
        //    Panel1.Enabled = false;

        //}
            hdfTransport_mode.Value = ddlTransportMode.SelectedValue.ToString();

    }

    public DataSet gridbind()
    {

        Transact.JOBID = HiddenField1.Value;
        Transact.JOBNO = "";
        Transact.IMPORTER_NAME = "";
        Transact.TRANSPORT_MODE = "";
        Transact.CUSTOMS_HOUSE = "";
        Transact.Ename = "select_Id";
        Transact.WORKING_PERIOD = Working_Period;

        dtuser = Transact.RetrieveAll_General_Details();


        return dtuser;

    }
   
    public void Edit_GeneralDetails()
    {
        if (Request.QueryString["JOBID"] != "" && Request.QueryString["JOBID"] != null)
        {
            hdn_Jobno.Value = "1";

            HiddenField1.Value = Request.QueryString["JOBID"].ToString();

            //imgCustomHouse.Enabled = true;
            txtCustomsHouse.Enabled = true;
            //Panel1.Enabled = true;
            int i = 0;
            gridbind();
            if (dtuser.Tables[0].Rows.Count > 0)
            {
                //if (Request.QueryString["ses_id"] == "" || Request.QueryString["ses_id"] == null)
                //{

                //}
                //else
                //{

                //    Session["Transport_Mode_Port"] = null;
                //    Session["Transport_Mode_Port"] = Request.QueryString["ses_id"].ToString();
                //    //string s = Session["Transport_Mode_Port"].ToString();
                //}
                hdn_ImporterType.Value = dtuser.Tables[0].Rows[0]["IMP_EXP_TYPE"].ToString();
                txtJobNo.Text = dtuser.Tables[0].Rows[0]["JOBNO"].ToString();

                txtJobDate.Text = dtuser.Tables[0].Rows[0]["JOBDATE"].ToString();


                string mode = dtuser.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();
                ddlTransportMode.Items.Clear();
                //ddlTransportMode.Items.Add(mode);
                //ddlTransportMode.Enabled = false;
                ddlTransportMode.Items.Add("Air");
                ddlTransportMode.Items.Add("Sea");
                ddlTransportMode.Items.Add("Land");
                ddlTransportMode.Items.Remove(mode);
                ddlTransportMode.Items.Insert(0, mode);
                hdfTransport_mode.Value = mode;
                Session["Transport_Mode_Port"] = mode;
                string BE_type = dtuser.Tables[0].Rows[0]["BE_TYPE"].ToString();

                ddlBEType.Items.Clear();
                ddlBEType.Items.Add("Home");
                ddlBEType.Items.Add("Warehouse");
                ddlBEType.Items.Add("Ex-Bond");
                ddlBEType.Items.Remove(BE_type);

                ddlBEType.Items.Insert(0, BE_type);
                if (BE_type == "Home")
                {
                    tag.Style.Add("display", "none");

                }
                else if (BE_type == "Warehouse")
                {
                    tag.Style.Add("display", "Block");


                }
                else if (BE_type == "Ex-Bond")
                {
                    tag.Style.Add("display", "none");


                }
                txtCustomsHouse.Text = dtuser.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();


                txtImporterName.Text = dtuser.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                txtAddress1.Text = dtuser.Tables[0].Rows[0]["ADDRESS1"].ToString();
                txtAddress2.Text = dtuser.Tables[0].Rows[0]["ADDRESS2"].ToString();
                txtAddress3.Text = dtuser.Tables[0].Rows[0]["ADDRESS3"].ToString();
                txtAddress4.Text = dtuser.Tables[0].Rows[0]["ADDRESS4"].ToString();
                txtAddress5.Text = dtuser.Tables[0].Rows[0]["ADDRESS5"].ToString();
                txtIECNo.Text = dtuser.Tables[0].Rows[0]["IEC_NO"].ToString();
                txtBranchNo.Text = dtuser.Tables[0].Rows[0]["BRANCH_NO"].ToString();
                txtCountryName.Text = dtuser.Tables[0].Rows[0]["COUNTRY_ORIGIN"].ToString();
                txtPortOrigin.Text = dtuser.Tables[0].Rows[0]["PORT_ORIGIN"].ToString();
                txtPortShipment.Text = dtuser.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString();
                txtCountryShipment.Text = dtuser.Tables[0].Rows[0]["COUNTRY_SHIPMENT"].ToString();

                string fil_status = dtuser.Tables[0].Rows[0]["FILING_STATUS"].ToString();

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


                txtSection46Desc.Text = dtuser.Tables[0].Rows[0]["SECTION46_DESC"].ToString();

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


                txtFirstCheckDesc.Text = dtuser.Tables[0].Rows[0]["FIRSTCHECK_DESC"].ToString();


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


                txtGreenChannelDesc.Text = dtuser.Tables[0].Rows[0]["GREEN_CHANNEL_DESC"].ToString();

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

                txtKachhaDesc.Text = dtuser.Tables[0].Rows[0]["KACHHA_BE_DESC"].ToString();

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

                txtSection48Desc.Text = dtuser.Tables[0].Rows[0]["SECTION48_DESC"].ToString();

                string hss = dtuser.Tables[0].Rows[0]["HIGH_SEA_SALE"].ToString();

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
                    chkHghSeaSale.Value = hss;
                    
                }
                else
                {
                    chkHighSeaSale.Checked = false;
                    txtSellerName.Enabled = false;
                    txtHighSeaSaleIECNo.Enabled = false;
                    txtBranchSLNo.Enabled = false;
                    txtHighSeaSaleAddress.Enabled = false;
                    txtHighSeaSaleAddress1.Enabled = false;
                    txtHighSeaSaleAddress2.Enabled = false;
                    txtHighSeaSaleAddress3.Enabled = false;
                    txtHighSeaSaleAddress4.Enabled = false;
                    chkHghSeaSale.Value = "";

                }

                txtSellerName.Text = dtuser.Tables[0].Rows[0]["HIGH_SEA_SALE_NAME"].ToString();
                txtHighSeaSaleIECNo.Text = dtuser.Tables[0].Rows[0]["HIGH_SEA_IEC"].ToString().Replace("0", "").ToString();
                txtBranchSLNo.Text = dtuser.Tables[0].Rows[0]["HIGH_SEA_BRANCH_SL_NO"].ToString().Replace("0", "").ToString();
                txtHighSeaSaleAddress.Text = dtuser.Tables[0].Rows[0]["HSS_ADD1"].ToString();
                txtHighSeaSaleAddress1.Text = dtuser.Tables[0].Rows[0]["HSS_ADD2"].ToString();
                txtHighSeaSaleAddress2.Text = dtuser.Tables[0].Rows[0]["HSS_ADD3"].ToString();
                txtHighSeaSaleAddress3.Text = dtuser.Tables[0].Rows[0]["HSS_ADD4"].ToString();
                txtHighSeaSaleAddress4.Text = dtuser.Tables[0].Rows[0]["HSS_ADD5"].ToString();
                txtWarehouseName.Text = dtuser.Tables[0].Rows[0]["WAREHOUSE_NAME"].ToString();
                txtWarehouseCode.Text = dtuser.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
                txtRemarks.Text = dtuser.Tables[0].Rows[0]["REMARKS"].ToString();
                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = Request.QueryString["JOBID"].ToString();
                //FOR UPDATED SUCCESSFULLY
                //Session["NEW"] = null;
                Session.Remove("TRANSPORT_MODE");
                Session.Remove("IMPORT_JOBNO");
                Session.Remove("IMPORT_JOBDATE");
                Session.Remove("FILING_STATUS");
               
                Session["TRANSPORT_MODE"] = ddlTransportMode.SelectedValue.ToString();


                Session["IMPORT_JOBNO"] = txtJobNo.Text;

                Session["IMPORT_JOBDATE"] = txtJobDate.Text;
                Session["FILING_STATUS"] = ddlFilingStatus.SelectedValue.ToString();
                
            }

            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
        }
        else
        {
            
            if (!IsPostBack)
            {
               
                //-------------Dont delete----------------------------

                btnSave.Attributes.Add("onclick", "return validate();");
                btnNew.Attributes.Add("onclick", "jQuery('#form1').validationEngine('detach');");
                btnUpdate.Attributes.Add("onclick", "return validate();");

                //-----------------------------------------------------
                AUTO_JOBNO();

                ddlTransportMode.Items.Clear();
                //ddlTransportMode.Items.Add("Select");
                ddlTransportMode.Items.Add("Air");
                ddlTransportMode.Items.Add("Sea");
                ddlTransportMode.Items.Add("Land");
                hdfTransport_mode.Value = ddlTransportMode.SelectedValue.ToString();
                ddlBEType.Items.Clear();
                ddlBEType.Items.Add("Home");
                ddlBEType.Items.Add("Warehouse");
                ddlBEType.Items.Add("Ex-Bond");

                //ddlCustomsHouse.Items.Clear();
                //ddlCustomsHouse.Items.Add();

                ddlFilingStatus.Items.Clear();
                ddlFilingStatus.Items.Add("Normal");
                ddlFilingStatus.Items.Add("Prior");
                ddlFilingStatus.Items.Add("Advanced");

                //CountryName();
                //EditSupDetails();


                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
            }
            
        }
    }

    public int insert_update(string jobid, string flag)
    {
        
        Transact.JOBID = jobid;
        Transact.JOBNO = txtJobNo.Text;
        Transact.JOBDATE = txtJobDate.Text;
        Transact.TRANSPORT_MODE = ddlTransportMode.SelectedValue.ToString();
        Transact.BE_TYPE = ddlBEType.SelectedValue.ToString();
        //Transact.CUSTOMS_HOUSE = ddlCustomsHouse.SelectedValue.ToString();
        Transact.CUSTOMS_HOUSE = txtCustomsHouse.Text;
        Transact.IMPORTER_NAME = txtImporterName.Text;
        Transact.ADDRESS1 = txtAddress1.Text;
        Transact.ADDRESS2 = txtAddress2.Text;
        //Transact.ADDRESS2 = ddlBranchNo.SelectedValue.ToString();
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
        Transact.WAREHOUSE_NAME = txtWarehouseName.Text;
        Transact.WAREHOUSE_CODE = txtWarehouseCode.Text;

        Transact.REMARKS = txtRemarks.Text;
        Transact.IMP_EXP_TYPE = hdn_ImporterType.Value;
        Transact.USER_ID = currentuser;

        Transact.flag = flag;
        Transact.BRANCH_CODE = currentbranch;
        Transact.WORKING_PERIOD = Working_Period;
        i = Transact.General_details_insertupdate();
        return i;
    }

    public void AUTO_JOBNO()
    {
        trans.WORKING_PERIOD = Working_Period;
        txtJobNo.Text = Convert.ToString(trans.RetrieveID());
        //Session.Remove("TRANSPORT_MODE");
        //Session.Remove("IMPORT_JOBNO");
        //Session.Remove("IMPORT_JOBDATE");
        //Session.Remove("FILING_STATUS");
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Request["page"].Replace("New", null);

        hdn_Jobno.Value = "";
       
        Session.Remove("TRANSPORT_MODE");
        Session.Remove("IMPORT_JOBNO");
        Session.Remove("IMPORT_JOBDATE");
        Session.Remove("FILING_STATUS");
        trans.ResetFields(Page.Controls);
        Page_enable();
        txtJobDate.Text = dt.Today_Date();
        AUTO_JOBNO();
        btnSave.Visible = true;
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Enabled = true;
        ViewState["UPDATED_ID"] = null;
        hdn_Update_General.Value = "";
        
    }
    public void Check_Box_Enable_Disable()
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
        if (chkKach.Value  =="Y")
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
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
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

                    //trans.ResetFields(Page.Controls);
                    txtJobNo.Focus();
                    Check_Box_Enable_Disable();
                    Session.Remove("TRANSPORT_MODE");
                    Session.Remove("FILING_STATUS");
                    Session["TRANSPORT_MODE"] = ddlTransportMode.SelectedValue.ToString();
                    Session["FILING_STATUS"] = ddlFilingStatus.SelectedValue.ToString();
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);
                    if (ViewState["UPDATED_ID"] != null)
                    {
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>event.preventDefault();alert('Updated Successfully')</script>", false);
                        Alert_msg("Updated Successfully", "btnUpdate");

                    }
                    else
                    {
                        hdn_Jobno.Value = "";

                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>event.preventDefault();alert('Saved Successfully')</script>", false);
                        Alert_msg("Saved Successfully", "btnUpdate");

                    }   
                    
                }
                else
                {
                    hdn_Jobno.Value = "";

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
                    Alert_msg("Job Not Saved", "btnUpdate");


                }
                Page_enable();


            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
            }
        }
        else
        {
            //lblMsg.Text = "Enter All Mandatory Field";
            Alert_msg("Enter All Mandatory Field");

        }

       
    }

    //use if script fail
    protected void ddlBEType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBEType.SelectedValue.ToString() == "Home")
        {

            //tag_transac_lft_in1.Visible = false;
        }
        else if (ddlBEType.SelectedValue.ToString() == "Warehouse")
        {
            //tag_transac_lft_in1.Visible = true;
        }
        else if (ddlBEType.SelectedValue.ToString() == "Ex-Bond")
        {
            //tag_transac_lft_in1.Visible = false;
        }
    }
    //use if script fail

    //use if script fail

    protected void ddlTransportMode_SelectedIndexChanged(object sender, EventArgs e)
    {
       


        //Session["Transport_Mode_Port"] = "";
        //string trans = ddlTransportMode.SelectedValue.ToString();

        //if (trans == "")
        //{
        //    imgCustomHouse.Enabled = false;
        //    Panel1.Enabled = false;
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Select Transport Mode')</script>", false);

        //}

        //else
        //{
        //    imgCustomHouse.Enabled = true;
        //    Panel1.Enabled = true;
        //}


        //Session["Transport_Mode_Port"] = trans;

    }
    //use if script fail

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {


            Transact.JOBNO = txtJobNo.Text;
            Transact.IMPORTER_NAME = "0";
            Transact.TRANSPORT_MODE = "0";
            Transact.CUSTOMS_HOUSE = "0";
            Transact.Ename = "delete";
            Transact.WORKING_PERIOD = Working_Period;

            Transact.RetrieveAll_General_Details();

            int ii = 0;
            ii = Transact.result;

            if (ii > 0)
            {
                //lblMsg.Text = " Record Deleted";
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                string prompt = "<script>$(document).ready(function(){{jAlert('Job Deleted', 'GENERAL', function (r) {var i = r + 'ok';if (i == 'trueok'){window.parent.document.getElementById('btnSearch').click();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Deleted')</script>", false);

                //string script = "this.window.opener.location=this.window.opener.location;this.window.close();";
                //if (!ClientScript.IsClientScriptBlockRegistered("REFRESH_PARENT"))
                //    ScriptManager.RegisterStartupScript(this, typeof(string), "REFRESH_PARENT", script, true);


                // Response.Write("<script language='javascript'>self.close();</script>");
            }


            else
            {
                //lblMsg.Text = " Record Not Deleted";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Deleted')</script>", false);
                Alert_msg("Job Not Deleted");
            }
            Page_enable();

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {


        if (txtJobNo.Text != "" && txtJobDate.Text != "")
        {
            try
            {
                string id = "";
                string f = "S";
                i = insert_update(id, f);
                HiddenField1.Value = Convert.ToString(Transact.UPDATE_ID);
              
                if (i == 1)
                {

                    //Session["TRANSPORT_MODE"] = null;
                    //Session["IMPORT_JOBNO"] = null;
                    //Session["IMPORT_JOBDATE"] = null;
                    //Session["FILING_STATUS"] = null;

                    //Request.QueryString.Remove("page");
                    Request["page"].Replace("New","old");
                    
                    //this.Request.QueryString.Remove("Page");
                    hdn_Jobno.Value = "1";
                    Session.Remove("TRANSPORT_MODE");
                    Session.Remove("IMPORT_JOBNO");
                    Session.Remove("IMPORT_JOBDATE");
                    Session.Remove("FILING_STATUS");
               
                    Session["TRANSPORT_MODE"] = ddlTransportMode.SelectedValue.ToString();


                    Session["IMPORT_JOBNO"] = txtJobNo.Text;


                    Session["IMPORT_JOBDATE"] = txtJobDate.Text;
                    Session["FILING_STATUS"] = ddlFilingStatus.SelectedValue.ToString();
                    //trans.ResetFields(Page.Controls);
                    txtJobNo.Focus();
                    //btnSave.Enabled = false;

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);
                    btnUpdate.CssClass = "save";
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                   
                    btnSave.Focus();
                   
                    ViewState["UPDATED_ID"] = null;
                    Alert_msg("Saved Successfully", "btnSave");


                }
                else if (i == 2)
                {
                    hdn_Jobno.Value = "";

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Job No Already Exist')</script>", false);
                    Alert_msg("Job No Already Exist!", "btnSave");

                }
                else
                {
                    hdn_Jobno.Value = "";

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
                    Alert_msg("Record Not Saved", "btnSave");

                }

                Page_enable();
            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
            }
        }
        else
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Enter All Mandatory Field')</script>", false);

            Alert_msg("Enter All Mandatory Field");

        }
    }


    public void Page_enable()
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
    ///auto search
    [System.Web.Services.WebMethod]
    public static string GetImporter(string custid)
   {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
       // custid = Auto.Country_Master_FromClientSide_Calling(custid);
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

        //if (Auto.Ename != "1")
        //{
            //custid = "";
       // }
        return custid;
    }
    [System.Web.Services.WebMethod]
    public static string GetImporter_Branchwise(string custid,string custid1)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        // custid = Auto.Country_Master_FromClientSide_Calling(custid);
        Auto.Ename = "IMP_EXP_MASTER_IMPORTER_BRANCH_WISE";
        Auto.Enamesearch = custid;
        Auto.NSearch = custid1;
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

        //if (Auto.Ename != "1")
        //{
        //custid = "";
        // }
        return custid;
    }

    ///auto search

   
}