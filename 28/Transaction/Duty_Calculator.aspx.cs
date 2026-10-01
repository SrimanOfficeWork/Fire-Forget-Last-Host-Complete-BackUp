using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Windows.Forms;


public partial class Duty_Calculator : ThemeClass
{
    AppSession aps = new AppSession();
    DataSet dtuser = new DataSet();
 
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

    public string str_txtInvoiceValFC, str_txtExRate, str_InvoiceValueINR, str_txtFreightINR, str_txtFreight, str_txtInsuranceINR, str_txtInsurance, str_txtMISC;
    public string str_txtLandingCharges, str_txtAssesableValue, str_txtBasicDutyPercentage, str_txtBasicDuty, str_txtCVDDutyPercentage, str_txtCVDDuty;
    public string str_txtCessPercentage, str_txtCess, str_txtCustoms_CessPercentage, str_txtCustoms_Cess, str_txtAdditional_DutyPercentage, str_txtAdditional_Duty, str_txtTotal_Duty;

    public decimal dcl_InvoiceValueINR, dcl_txtInvoiceValFC, dcl_txtExRate, dcl_txtFreightINR, dcl_txtFreight, dcl_txtInsuranceINR, dcl_txtInsurance;
    public decimal dcl_txtMISC,dcl_txtAssesableValue, dcl_txtBasicDutyPercentage, dcl_txtCVDDutyPercentage, dcl_txtCessPercentage, dcl_txtCustoms_CessPercentage, dcl_txtAdditional_DutyPercentage, dcl_txtLandingCharges;

    public decimal dcl_txtBasicDuty, dcl_txtCVDDuty, dcl_txtCustoms_Cess, dcl_txtCess, dcl_txtAdditional_Duty;

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
            // commented for areawise implementation on 05-mar-2020
        /*
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
        
  * */
        SELECT_BRANCH = Connection.Get_Company_Type();
        if (!IsPostBack)
        {

        }

        aa();

    }


    public void aa()
    {
        //GetData("Click");

        str_txtInvoiceValFC = txtInvoiceValFC.Text;
        Session["str_txtInvoiceValFC"] = str_txtInvoiceValFC;
        string str_txtInvoiceValFC1 = HttpContext.Current.Session["str_txtInvoiceValFC"].ToString();
        txtInvoiceValFC.Focus();

        str_InvoiceValueINR = InvoiceValueINR.Text;
        Session["str_InvoiceValueINR"] = str_InvoiceValueINR;
        string str_InvoiceValueINR1 = HttpContext.Current.Session["str_InvoiceValueINR"].ToString();

        str_txtFreight = txtFreight.Text;
        Session["str_txtFreight"] = str_txtFreight;
        //string str_txtFreight1 = HttpContext.Current.Session["str_txtFreight"].ToString();

        str_txtInsurance = txtInsurance.Text;
        Session["str_txtInsurance"] = str_txtInsurance;
        //string str_txtInsurance1 = HttpContext.Current.Session["str_txtInsurance"].ToString();

        str_txtMISC = txtMISC.Text;
        Session["str_txtMISC"] = str_txtMISC;


        str_txtLandingCharges = txtLandingCharges.Text;
        Session["str_txtLandingCharges"] = str_txtLandingCharges;
        txtLandingCharges.Text = Session["str_txtLandingCharges"].ToString();
        txtLandingCharges.Attributes.Add("readonly", "readonly");

        str_txtAssesableValue = txtAssesableValue.Text;
        Session["str_txtAssesableValue"] = str_txtAssesableValue;
        txtAssesableValue.Text = Session["str_txtAssesableValue"].ToString();
        txtAssesableValue.Attributes.Add("readonly", "readonly");

        str_txtBasicDutyPercentage = txtBasicDutyPercentage.Text;
        Session["str_txtBasicDutyPercentage"] = str_txtBasicDutyPercentage;
        

        str_txtBasicDuty = txtBasicDuty.Text;
        Session["str_txtBasicDuty"] = str_txtBasicDuty;
        txtBasicDuty.Attributes.Add("readonly", "readonly");

        str_txtCVDDutyPercentage = txtCVDDutyPercentage.Text;
        Session["str_txtCVDDutyPercentage"] = str_txtCVDDutyPercentage;


        str_txtCVDDuty = txtCVDDuty.Text;
        Session["str_txtCVDDuty"] = str_txtCVDDuty;
        txtCVDDuty.Attributes.Add("readonly", "readonly");
        
        str_txtCess = txtCess.Text;
        Session["str_txtCess"] = str_txtCess;
        txtCess.Attributes.Add("readonly", "readonly");

        str_txtCessPercentage = txtCessPercentage.Text;
        Session["str_txtCessPercentage"] = str_txtCessPercentage;

        str_txtCustoms_Cess = txtCustoms_Cess.Text;
        Session["str_txtCustoms_Cess"] = str_txtCustoms_Cess;
        txtCustoms_Cess.Attributes.Add("readonly", "readonly");

        str_txtCustoms_CessPercentage = txtCustoms_CessPercentage.Text;
        Session["str_txtCustoms_CessPercentage"] = str_txtCustoms_CessPercentage;
        
        str_txtAdditional_Duty = txtAdditional_Duty.Text;
        Session["str_txtAdditional_Duty"] = str_txtAdditional_Duty;
        txtAdditional_Duty.Attributes.Add("readonly", "readonly");

        str_txtAdditional_DutyPercentage = txtAdditional_DutyPercentage.Text;
        Session["str_txtAdditional_DutyPercentage"] = str_txtAdditional_DutyPercentage;

        str_txtTotal_Duty = txtTotal_Duty.Text;
        Session["str_txtTotal_Duty"] = str_txtTotal_Duty;
        txtTotal_Duty.Attributes.Add("readonly", "readonly");

        GetData();
       
    }


    [System.Web.Services.WebMethod]
    public static void GetData()    
    {

        string str_txtInvoiceValFC1 = HttpContext.Current.Session["str_txtInvoiceValFC"].ToString();
        string str_InvoiceValueINR1 = HttpContext.Current.Session["str_InvoiceValueINR"].ToString();
        string str_txtFreight1 = HttpContext.Current.Session["str_txtFreight"].ToString();
        string str_txtInsurance1 = HttpContext.Current.Session["str_txtInsurance"].ToString();
        string str_txtMISC1 = HttpContext.Current.Session["str_txtMISC"].ToString();
        string str_txtLandingCharges1 = HttpContext.Current.Session["str_txtLandingCharges"].ToString();
        string str_txtAssesableValue1 = HttpContext.Current.Session["str_txtAssesableValue"].ToString();
        string str_txtBasicDuty1 = HttpContext.Current.Session["str_txtBasicDuty"].ToString();
        string str_txtBasicDutyPercentage1 = HttpContext.Current.Session["str_txtBasicDutyPercentage"].ToString();
        string str_txtCVDDuty1 = HttpContext.Current.Session["str_txtCVDDuty"].ToString();
        string str_txtCVDDutyPercentage1 = HttpContext.Current.Session["str_txtCVDDutyPercentage"].ToString();
        string str_txtCess1 = HttpContext.Current.Session["str_txtCess"].ToString();
        string str_txtCessPercentage1 = HttpContext.Current.Session["str_txtCessPercentage"].ToString();
        string str_txtCustoms_Cess1 = HttpContext.Current.Session["str_txtCustoms_Cess"].ToString();
        string str_txtCustoms_CessPercentage1 = HttpContext.Current.Session["str_txtCustoms_CessPercentage"].ToString();
        string str_txtAdditional_Duty1 = HttpContext.Current.Session["str_txtAdditional_Duty"].ToString();
        string str_txtAdditional_DutyPercentage1 = HttpContext.Current.Session["str_txtAdditional_DutyPercentage"].ToString();
        string str_txtTotal_Duty1 = HttpContext.Current.Session["str_txtTotal_Duty"].ToString();
        
    }
}