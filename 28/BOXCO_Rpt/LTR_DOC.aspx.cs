using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text;
using System.Configuration;
using System.Drawing.Printing;

public partial class Transaction_Import_KKForm : System.Web.UI.Page
{
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public string Working_Period;
    public string CHAAddr1, CHAAddr2, CHAAddr3;
    Date_Time dt = new Date_Time();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    KK_Form kk = new KK_Form();
    DataSet ds = new DataSet();
    public int i = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        CHAAddr1 = HttpContext.Current.Session["CHA_NAME"].ToString();
        CHAAddr2 = HttpContext.Current.Session["CHA_ADDRESS"].ToString();
        CHAAddr3 = HttpContext.Current.Session["CHA_ADDRESS1"].ToString();


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

            if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
            {
                LoadJobNo();               
            }
            else
            {
                LoadJobNo();
                ddlJobNo.SelectedValue = Request.QueryString["jobno"].ToString();
                DropDownList1_SelectedIndexChanged(sender, e);
            }
            //Save_Update_Btn();

            btnSave.Visible = false;
            btnupdate.Visible = false;
            btn_print.Visible = false;
            btnRpt.Visible = false;
            btnDelete.Visible = false;

            //TextBox5.BackColor = System.Drawing.Color.LightGray;

        }
      
        //txtDate.Text = dt.Today_Date();
    }

    public void LoadJobNo()
    {       
        CheckList chklist = new CheckList();
        chklist.JOBNo = "";
        chklist.Ename = "select_jobno";
        chklist.Workingperiod = SELECT_BRANCH;
        ddlJobNo.DataSource = chklist.RetrieveAll_General_Details();
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataTextField = "JOBNO";
        ddlJobNo.DataBind();
        ddlJobNo.Items.Remove("0");
        ddlJobNo.Items.Insert(0, "Select");

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (ddlJobNo.SelectedItem.Text != "Select")
        {
           
            Clear();
        
            kk.LTR_JOBNO = ddlJobNo.SelectedItem.Text;
            kk.LTR_BRANCHCOMMON = SELECT_BRANCH;
            kk.Ename = "Get_LTR_Form";
            ds = kk.RetrieveAll_LTR_DOCUMENT_Details();

            i = kk.result;

            if (i == 1)
            {            
                if (ds.Tables[0].Rows.Count > 0)
                {

                    txtImporterName.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                    txt_ADDRESS1.Text = ds.Tables[0].Rows[0]["ADDRESS1"].ToString();
                    txt_ADDRESS2.Text = ds.Tables[0].Rows[0]["ADDRESS2"].ToString();
                    txt_ADDRESS3.Text = ds.Tables[0].Rows[0]["ADDRESS3"].ToString();
                    txt_ADDRESS4.Text = ds.Tables[0].Rows[0]["ADDRESS4"].ToString() + "," + ds.Tables[0].Rows[0]["ADDRESS5"].ToString();
                    //txt_ADDRESS5.Text = ds.Tables[0].Rows[0]["ADDRESS5"].ToString();

                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    txt_NO_OF_PKGS.Text = ds.Tables[1].Rows[0]["IGM_NOOFPACKAGE"].ToString() + "  " + ds.Tables[1].Rows[0]["IGM_PACKAGETYPE"].ToString();
                    txt_VESSEL_FLIGHT_NO.Text = ds.Tables[1].Rows[0]["IGM_FLIGHTNO_VESSELNO"].ToString();
                    txt_MAWB_NO.Text = ds.Tables[1].Rows[0]["IGM_MAWB_MBL"].ToString();
                    txt_MAWB_DATE.Text = ds.Tables[1].Rows[0]["IGM_MAWB_MBLDATE"].ToString();

                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    txt_INVOICE_NO.Text = ds.Tables[2].Rows[0]["INVOICE_NO"].ToString();
                    txt_INVOICE_DATE.Text = ds.Tables[2].Rows[0]["INVOICE_DATE"].ToString();
                    txt_PACK_INVOICE_DATE.Text = ds.Tables[2].Rows[0]["INVOICE_DATE"].ToString();
                    txt_CERT_INVOICE_DATE.Text = ds.Tables[2].Rows[0]["INVOICE_DATE"].ToString();
                    txt_CERT_WEIGHT_INVOICE_DATE.Text = ds.Tables[2].Rows[0]["INVOICE_DATE"].ToString();
                   
                }

                if (ds.Tables[3].Rows.Count > 0)
                {
                    txt_PRODUCT_DESCRIPTION.Text = ds.Tables[3].Rows[0]["ITEM_DESCRIPTION"].ToString();
                    txt_PRODUCT_QUANTITY.Text = ds.Tables[3].Rows[0]["ITEM_QTY"].ToString();

                }

                if (ds.Tables[4].Rows.Count > 0)
                {
                    txt_BE_NO.Text = ds.Tables[4].Rows[0]["BE_NO"].ToString();
                    txt_BE_DATE.Text = ds.Tables[4].Rows[0]["BE_DATE"].ToString();
                    txt_Copy_BE_NO.Text = ds.Tables[4].Rows[0]["BE_NO"].ToString();
                    txt_Copy_BE_Date.Text = ds.Tables[4].Rows[0]["BE_DATE"].ToString();

                }
                DateTime now = DateTime.Today;
             
                txt_FOR.Text = CHAAddr1;
                //txt_CurrentDate.Text = DateTime.Now.ToString("dd/mm/yyyy");
                txt_CurrentDate.Text = Convert.ToString(DateTime.Now.ToShortDateString());

                btnSave.Visible = true;
                btnupdate.Visible = false;
                btnRpt.Visible = false;
                btn_print.Visible = false;
                btnDelete.Visible = false;
            }
            else
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtImporterName.Text = ds.Tables[0].Rows[0]["LTR_IMPORTER_NAME"].ToString();
                    txt_CurrentDate.Text = ds.Tables[0].Rows[0]["LTR_CURRENT_DATE"].ToString();
                    txt_ADDRESS1.Text = ds.Tables[0].Rows[0]["LTR_ADDRESS1"].ToString();
                    txt_ADDRESS2.Text = ds.Tables[0].Rows[0]["LTR_ADDRESS2"].ToString();
                    txt_ADDRESS3.Text = ds.Tables[0].Rows[0]["LTR_ADDRESS3"].ToString();
                    txt_ADDRESS4.Text = ds.Tables[0].Rows[0]["LTR_ADDRESS4"].ToString();
                    txt_ADDRESS5.Text = ds.Tables[0].Rows[0]["LTR_ADDRESS5"].ToString();
                    txt_NO_OF_PKGS.Text = ds.Tables[0].Rows[0]["LTR_NO_OF_PKGS"].ToString();
                    txt_PRODUCT_QUANTITY.Text = ds.Tables[0].Rows[0]["LTR_PRODUCT_QUANTITY"].ToString();

                    txt_PRODUCT_DESCRIPTION.Text = ds.Tables[0].Rows[0]["LTR_PRODUCT_DESCRIPTION"].ToString();
                    txt_VESSEL_FLIGHT_NO.Text = ds.Tables[0].Rows[0]["LTR_VESSEL_FLIGHT_NO"].ToString();
                    txt_VOYAGE.Text = ds.Tables[0].Rows[0]["LTR_VOYAGE"].ToString();
                    txt_BE_NO.Text = ds.Tables[0].Rows[0]["LTR_BE_NO"].ToString();
                    txt_BE_DATE.Text = ds.Tables[0].Rows[0]["LTR_BE_DATE"].ToString();
                    txt_Copy_BE_NO.Text = ds.Tables[0].Rows[0]["LTR_COPY_BE_NO"].ToString();
                    txt_Copy_BE_Date.Text = ds.Tables[0].Rows[0]["LTR_COPY_BE_DATE"].ToString();
                    txt_E_RECEIPT_NO.Text = ds.Tables[0].Rows[0]["LTR_E_RECEIPT_NO"].ToString();
                    txt_E_RECEIPT_DATE.Text = ds.Tables[0].Rows[0]["LTR_E_RECEIPT_DATE"].ToString();
                    txt_MAWB_NO.Text = ds.Tables[0].Rows[0]["LTR_MAWB_NO"].ToString();
                    txt_MAWB_DATE.Text = ds.Tables[0].Rows[0]["LTR_MAWB_DATE"].ToString();
                    txt_INVOICE_NO.Text = ds.Tables[0].Rows[0]["LTR_INVOICE_NO"].ToString();
                    txt_INVOICE_DATE.Text = ds.Tables[0].Rows[0]["LTR_INVOICE_DATE"].ToString();
                    txt_PACK_INVOICE_DATE.Text = ds.Tables[0].Rows[0]["LTR_PACK_INVOICE_DATE"].ToString();
                    txt_CERT_INVOICE_DATE.Text = ds.Tables[0].Rows[0]["LTR_CERT_INVOICE_DATE"].ToString();
                    txt_CERT_WEIGHT_INVOICE_DATE.Text = ds.Tables[0].Rows[0]["LTR_CERT_WEIGHT_INVOICE_DATE"].ToString();
                    txt_INSURANCE_NO.Text = ds.Tables[0].Rows[0]["LTR_INSURANCE_NO"].ToString();
                    txt_INSURANCE_DATE.Text = ds.Tables[0].Rows[0]["LTR_INSURANCE_DATE"].ToString();
                    txt_DO_NO.Text = ds.Tables[0].Rows[0]["LTR_DO_NO"].ToString();
                    txt_DO_DATE.Text = ds.Tables[0].Rows[0]["LTR_DO_DATE"].ToString();
                    txt_J_CERT_NO.Text = ds.Tables[0].Rows[0]["LTR_J_CERT_NO"].ToString();
                    txt_J_CERT_DATE.Text = ds.Tables[0].Rows[0]["LTR_J_CERT_DATE"].ToString();
                    txt_FOR.Text = ds.Tables[0].Rows[0]["LTR_FOR"].ToString();
                }
                btn_print.Visible = false;
                btnRpt.Visible = true;
                btnSave.Visible = false;
                btnupdate.Visible = true;
                btnDelete.Visible = true;
            }
          
        }
        else
        {
            btn_print.Visible = false;
            btnRpt.Visible = false;
            btnSave.Visible = false;
            btnupdate.Visible = false;
            btnDelete.Visible = false;
        }
    }

    public int insert_update()
    {

        kk.LTR_Id = ddlJobNo.SelectedItem.Text;
        kk.LTR_JOBNO = ddlJobNo.SelectedItem.Text;
        kk.LTR_CURRENT_DATE = txt_CurrentDate.Text;
        kk.LTR_IMPORTER_NAME = txtImporterName.Text;
        kk.LTR_ADDRESS1 = txt_ADDRESS1.Text;
        kk.LTR_ADDRESS2 = txt_ADDRESS2.Text;
        kk.LTR_ADDRESS3 = txt_ADDRESS3.Text;
        kk.LTR_ADDRESS4 = txt_ADDRESS4.Text;
        kk.LTR_ADDRESS5 = txt_ADDRESS5.Text;
        kk.LTR_NO_OF_PKGS = txt_NO_OF_PKGS.Text;
        kk.LTR_PRODUCT_QUANTITY = txt_PRODUCT_QUANTITY.Text;
        kk.LTR_PRODUCT_DESCRIPTION = txt_PRODUCT_DESCRIPTION.Text;
        kk.LTR_VESSEL_FLIGHT_NO = txt_VESSEL_FLIGHT_NO.Text;

        kk.LTR_VOYAGE	=	txt_VOYAGE.Text;
        kk.LTR_BE_NO	=	txt_BE_NO.Text;
        kk.LTR_BE_DATE	=	txt_BE_DATE.Text;
        kk.LTR_E_RECEIPT_NO	=	txt_E_RECEIPT_NO.Text;
        kk.LTR_E_RECEIPT_DATE	=	txt_E_RECEIPT_DATE.Text;
        kk.LTR_MAWB_NO	=	txt_MAWB_NO.Text;
        kk.LTR_MAWB_DATE	=	txt_MAWB_DATE.Text;
        kk.LTR_INVOICE_NO	=	txt_INVOICE_NO.Text;
        kk.LTR_INVOICE_DATE	=	txt_INVOICE_DATE.Text;
        kk.LTR_PACK_INVOICE_DATE	=	txt_PACK_INVOICE_DATE.Text;
        kk.LTR_CERT_INVOICE_DATE	=	txt_CERT_INVOICE_DATE.Text;
        kk.LTR_CERT_WEIGHT_INVOICE_DATE	=	txt_CERT_WEIGHT_INVOICE_DATE.Text;
        kk.LTR_INSURANCE_NO	=	txt_INSURANCE_NO.Text;
        kk.LTR_INSURANCE_DATE	=	txt_INSURANCE_DATE.Text;
        kk.LTR_DO_NO	=	txt_DO_NO.Text;
        kk.LTR_DO_DATE	=	txt_DO_DATE.Text;
        kk.LTR_J_CERT_NO	=	txt_J_CERT_NO.Text;
        kk.LTR_J_CERT_DATE	=	txt_J_CERT_DATE.Text;
        kk.LTR_FOR = txt_FOR.Text;
        kk.LTR_BRANCHCODE = currentbranch;
        kk.Ename = "S";
        kk.LTR_WORKINGPERIOD = Working_Period;
        kk.LTR_BRANCHCOMMON = SELECT_BRANCH;
        kk.LTR_USERID = currentuser;
        kk.LTR_LOGINDATE = LoginDate;

       i= kk.LTR_DOC_Insert_Update();
       return i;

          
    }

    protected void btnSave_Click1(object sender, EventArgs e)
    {
        try
        {
            insert_update();
            Alert_msg("Saved Successfully");
            btnRpt.Visible = true;
            btnSave.Visible = false;
            btnupdate.Visible = true;
            btnDelete.Visible = true;
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
            //kk.KK_JOBNO = ddlJobNo.SelectedItem.Text;
            //kk.KK_BRANCHCODE = SELECT_BRANCH;
            //kk.Ename = "KK_Form_Delete";
            //ds = kk.RetrieveAll_KK_Details();

            //i = kk.result;

            kk.LTR_JOBNO = ddlJobNo.SelectedItem.Text;
            kk.LTR_BRANCHCODE = SELECT_BRANCH;
            kk.Ename = "LTR_Delete";
            ds = kk.RetrieveAll_LTR_DOCUMENT_Details();

            i = kk.result;

            if (i > 0)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('KK-FORM Deleted', 'LTR DOCUMENT ', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
                Clear();
            }
            else
            {
                Alert_msg("KK-FORM Not Deleted");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            insert_update();
            Alert_msg("Updated Successfully");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void btn_print_Click(object sender, EventArgs e)
    {
        string ec = "<script>$(document).ready(function(){{return PrintGridData();}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", ec, false);
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'KK-FORM APP', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Clear()
    {
        txtImporterName.Text = "";
        txt_CurrentDate.Text = "";
        txt_ADDRESS1.Text = "";
        txt_ADDRESS2.Text = "";
        txt_ADDRESS3.Text = "";
        txt_ADDRESS4.Text = "";
        txt_ADDRESS5.Text = "";
        txt_NO_OF_PKGS.Text = "";
        txt_PRODUCT_QUANTITY.Text = "";
        txt_PRODUCT_DESCRIPTION.Text = "";
        txt_VESSEL_FLIGHT_NO.Text = "";
        txt_VOYAGE.Text = "";
        txt_BE_NO.Text = "";
        txt_BE_DATE.Text = "";
        txt_E_RECEIPT_NO.Text = "";
        txt_E_RECEIPT_DATE.Text = "";
        txt_MAWB_NO.Text = "";
        txt_MAWB_DATE.Text = "";
        txt_INVOICE_NO.Text = "";
        txt_INVOICE_DATE.Text = "";
        txt_PACK_INVOICE_DATE.Text = "";
        txt_CERT_INVOICE_DATE.Text = "";
        txt_CERT_WEIGHT_INVOICE_DATE.Text = "";
        txt_INSURANCE_NO.Text = "";
        txt_INSURANCE_DATE.Text = "";
        txt_DO_NO.Text = "";
        txt_DO_DATE.Text = "";
        txt_J_CERT_NO.Text = "";
        txt_J_CERT_DATE.Text = "";
        txt_Copy_BE_NO.Text = "";
        txt_Copy_BE_Date.Text = "";

    }

}