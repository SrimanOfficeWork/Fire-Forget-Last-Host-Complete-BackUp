using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using GeneraReport;
using Microsoft.Reporting.WebForms;
using System.Windows.Forms;
using System.Data.SqlClient.SqlGen;
using System.Net;
using System.Net.Mail;

public partial class Report_DutyWorkSheet : System.Web.UI.Page
{
    AppSession aps = new AppSession();
    ErrorLogs err = new ErrorLogs();
    NForm nf = new NForm();
    KK_Form kk = new KK_Form();
    List<Report_DutyWorkSheet> Report_WorkSheet = new List<Report_DutyWorkSheet>();


     SqlConnection conadmin = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
    string conn_admin = System.Configuration.ConfigurationManager.AppSettings["con"];

    public SqlConnection conn;
    public SqlCommand cmd = new SqlCommand();
    public SqlDataAdapter da = new SqlDataAdapter();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string Company_ID;
    public string SELECT_TYPE, SELECT_BRANCH, ddlJobNo;
    public string weight, description, TIN;
    public string Imp_name, jobno, job_date, branch_Slno, IEC_No;
    public string Inv_Value, Inv_ExRate, Total_Amount, CESS_Rate, Cess_CETH_Rate, Assbl_Val, Basic_val, PRODUCT_CETH;
    public int ii = 0;
    DataSet ds = new DataSet();
    DataSet dss = new DataSet();
    DataSet dsss = new DataSet();
    DataSet ds_new = new DataSet();

    public string CETH_CESS_RTA1, total_Value1;

    #region Duty_Worksheet

    public string _InvNo, _Inv_Cur;

    public string _SlNo, _Item_Desc, _Item_Qty, _Item_Unit, _Item_UnitPrice, _total_Value, _total_Value_INR, _OtherChgs, _Freight_cal, _Insurance_Calc;
    public string _Tot_CIF, _LandingChargs, _Ass_Val, _CTH_CETH, _BCD_notn, _BCD_Amt, _CVD_Notn, _CVD_Amt, _CessAmt, _CVDCessAmt, _Edu_Notn, _ECessAmt, _SAD, _Total;
    public string _BCD_Rate, _CVD_Rate, _Cess_rate, _SAD_Rate,_ECessRate;

    public string Total_INR;

    public string InvNo { get { return _InvNo; } set { _InvNo = value; } }
    public string Inv_Cur { get { return _Inv_Cur; } set { _Inv_Cur = value; } }

    public string SlNo { get { return _SlNo; } set { _SlNo = value; } }
    public string Item_Desc { get { return _Item_Desc; } set { _Item_Desc = value; } }
    public string Item_Qty { get { return _Item_Qty; } set { _Item_Qty = value; } }
    public string Item_Unit { get { return _Item_Unit; } set { _Item_Unit = value; } }
    public string Item_UnitPrice { get { return _Item_UnitPrice; } set { _Item_UnitPrice = value; } }
    public string total_Value { get { return _total_Value; } set { _total_Value = value; } }
    public string total_Value_INR { get { return _total_Value_INR; } set { _total_Value_INR = value; } }
    public string OtherChgs { get { return _OtherChgs; } set { _OtherChgs = value; } }
    public string Freight_cal { get { return _Freight_cal; } set { _Freight_cal = value; } }
    public string Insurance_Calc { get { return _Insurance_Calc; } set { _Insurance_Calc = value; } }

    public string Tot_CIF { get { return _Tot_CIF; } set { _Tot_CIF = value; } }
    public string LandingChargs { get { return _LandingChargs; } set { _LandingChargs = value; } }
    public string Ass_Val { get { return _Ass_Val; } set { _Ass_Val = value; } }
    public string CTH_CETH { get { return _CTH_CETH; } set { _CTH_CETH = value; } }
    public string BCD_notn { get { return _BCD_notn; } set { _BCD_notn = value; } }
    public string BCD_Amt { get { return _BCD_Amt; } set { _BCD_Amt = value; } }
    public string CVD_Notn { get { return _CVD_Notn; } set { _CVD_Notn = value; } }
    public string CVD_Amt { get { return _CVD_Amt; } set { _CVD_Amt = value; } }
    public string CessAmt { get { return _CessAmt; } set { _CessAmt = value; } }
    public string CVDCessAmt { get { return _CVDCessAmt; } set { _CVDCessAmt = value; } }
    public string Edu_Notn { get { return _Edu_Notn; } set { _Edu_Notn = value; } }
    public string ECessAmt { get { return _ECessAmt; } set { _ECessAmt = value; } }
    public string SAD { get { return _SAD; } set { _SAD = value; } }
    public string Total { get { return _Total; } set { _Total = value; } }

    public string BCD_Rate { get { return _BCD_Rate; } set { _BCD_Rate = value; } }
    public string CVD_Rate { get { return _CVD_Rate; } set { _CVD_Rate = value; } }
    public string Cess_rate { get { return _Cess_rate; } set { _Cess_rate = value; } }
    public string SAD_Rate { get { return _SAD_Rate; } set { _SAD_Rate = value; } }
    public string ECessRate { get { return _ECessRate; } set { _ECessRate = value; } }




    #endregion

    #region 
    public string TRANSPORT_MODE;
    public string MIS_FREIGHT_RATE;
    public string MIS_INSURANCE_RATE;
   
    public string INVOICE_VALUE;
    public string INVOICE_EXRATE;

    public string MIS_FREIGHT_CHARGES;

    public string MIS_FREIGHT_CURRENCY;
    public string MIS_FREIGHT_EXRATE;
    public string MIS_INSURANCE_CHARGES;

    public string MIS_INSURANCE_CURRENCY;
    public string MIS_INSURANCE_EXRATE;

    public string SVB_ASSESABLE_RATE;
    public string SVB_DUTY_RATE;

    public string MIS_CHARGES;
    public string MIS_RATE;
    public string MIS_EXRATE;
    public string MIS_HIGHSEASALE_RATE;
    public string MIS_HIGHSEASALE_CHARGES;
    public string MIS_DISCOUNT_RATE;
    public string MIS_DISCOUNT_CHARGES;

    public string MIS_CURRENCY;
    public string MIS_LOADING_CHARGES;
    public string MIS_LOADING_CURRENCY;
    public string MIS_LOADING_EXRATE;
    public string MIS_DISCOUNT_CURRENCY;
    public string MIS_DISCOUNT_EXRATE;

    public string MIS_HIGHSEASALE_CURRENCY;

    public string REIMPORT_FREIGHT;
    public string REIMPORT_INSURANCE;

    public string NOTN_NO;
    public string NOTN_SLNO;

    public string MIS_HIGHSEASALE_EXRATE;
    public double INVOICE_VALUE_INR;
    public double TOTAL_INVOICE_VALUE;

    public double REIMPORT_FREIGHT_AMOUNT;
    public double REIMPORT_INSURANCE_AMOUNT;
    public double MISC_AMOUNT;
    public double DISCOUNT_AMOUNT = 0;
    public double INVOICE_AMOUNT = 0;
    public double INSURANCE_AMOUNT = 0;
    public double FREIGHT_AMOUNT = 0;
    public double INDIVITUAL_INVOICE_VALUE = 0;
    public double INDIVITUAL_FREIGHT_AMOUNT = 0;
    public double INDIVITUAL_INSURANCE_AMOUNT = 0;
    public double INDIVITUAL_MISC_AMOUNT = 0;
    public double INDIVITUAL_TOTAL_AMOUNT = 0;
    public double INDIVITUAL_HSS_AMOUNT = 0;
    public double INDIVITUAL_SVB_AMOUNT = 0;
    public double INDIVITUAL_CIF_AMOUNT = 0;
    public double INDIVITUAL_LANDING_COST = 0;
    public double INDIVITUAL_ASSESSABLE_AMOUNT = 0;
    public double CHECK_FREIGHT_RATE = 0;
    public double CHECK_FREIGHT_EXRATE = 0;

    public string TERMS;
    public double INDIVITUAL_DISCOUNT_AMOUNT = 0;
    public string ITEM_QTY;
    public string ITEM_UNIT_PRICE;

    public string INVOICE_NO_ITEM;
    public string INVOICE_SLNO;
    public string ITEM_SLNO;
    public double ASSESABLE_VALUE;

#endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Company_ID = Session["COMPANY_ID"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();


        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
                //ddlSelect_Branch.Text = currentbranch;
                //Bind_Branches();
                //Bind_ClientMasterName();
            }
            else
            {
                SELECT_BRANCH = "";
                if (!IsPostBack)
                {
                    Load_JobNo();
                    Load_Product_Details();
                }
            }
        }
        else
        {
            SELECT_BRANCH = "";

        }

        if (!IsPostBack)
        {
            Load_JobNo();

            if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
            {

            }
            else
            {
                ddlJob_No.SelectedValue = Request.QueryString["jobno"].ToString();
                ds_new = (DataSet)HttpContext.Current.Session["IMPORT_CHECKLIST"];
            }

            Load_Product_Details();
            //Item_Details();
            //Page_loaItem_Details();
        }
       
    }

    public void Load_JobNo()
    {

        DataSet ds = new DataSet();
        CheckList chklist = new CheckList();
        chklist.JOBNo = "";
        chklist.Ename = "select_jobno";
        chklist.Workingperiod = Working_Period;
        chklist.Workingperiod = SELECT_BRANCH;

        ddlJob_No.DataSource = chklist.RetrieveAll_General_Details();
        ddlJob_No.DataValueField = "JOBNO";
        ddlJob_No.DataTextField = "JOBNO";
        ddlJob_No.DataBind();
        ddlJob_No.Items.Remove("0");
        ddlJob_No.Items.Insert(0, "Select");

    }

    public void Load_Product_Details()
    {
        kk.KK_JOBNO = ddlJob_No.SelectedItem.Text;
        kk.KK_BRANCHCODE = SELECT_BRANCH;
        kk.Ename = "Get_DutyWorkSht";
        ds = kk.RetrieveAll_DutyWorkSheet_Details();

        List<ReportParameter> paramList = new List<ReportParameter>();
        this.ReportViewer1.LocalReport.SetParameters(paramList);
        ReportViewer1.LocalReport.DataSources.Clear();

        

        if (ds.Tables[0].Rows.Count > 0)
        {
            jobno = ds.Tables[0].Rows[0]["JOBNO"].ToString();
            job_date = ds.Tables[0].Rows[0]["JOBDATE"].ToString();
            Imp_name = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
            branch_Slno = ds.Tables[0].Rows[0]["BRANCH_NO"].ToString();
            IEC_No = ds.Tables[0].Rows[0]["IEC_NO"].ToString();

                
                ReportParameter p1 = new ReportParameter("jobno", jobno);
                ReportParameter p2 = new ReportParameter("job_date", job_date);
                ReportParameter p3 = new ReportParameter("Imp_name", Imp_name);
                ReportParameter p4 = new ReportParameter("branch_Slno", branch_Slno);
                ReportParameter p5 = new ReportParameter("IEC_No", IEC_No);

                ReportParameter cess = new ReportParameter("Cess_CETH_Rate", Cess_CETH_Rate);

                ReportParameter[] p = { p1, p2, p3, p4, p5, cess };

                ReportViewer1.LocalReport.SetParameters(p);

                Load_Item_Calc_Details();


                //--------------------------------------To Print------------------------------------------------------------------------------------//
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                string fileName = "a";
                byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                Session.Remove("report");
                Session["report"] = bytes;
                //--------------------------------------To Print------------------------------------------------------------------------------------//
            //}
        }
    }


    protected void ddlJob_No_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Product_Details();     
    }

    public void Load_Item_Calc_Details()
    {
        Get_CESS_Item_Details(ds.Tables[2]);
        ReportDataSource dataSS = new ReportDataSource("Duty_Worksheet_DataSet", Report_WorkSheet);
        ReportViewer1.LocalReport.DataSources.Add(dataSS);
    }


    public void Get_CESS_Item_Details(DataTable dt)
    {
        int iii = 0; int i = 0;
        //string CETH_CESS_RTA1, total_Value1;

        while (ds.Tables[1].Rows.Count > i)
        {

            string Inv_ExRate_Val = ds.Tables[1].Rows[i]["INVOICE_EXRATE"].ToString();
            string Total_cllll = ds.Tables[1].Rows[i]["INVOICE_VALUE"].ToString();

            double dbl_Inv_ExRate_Val = Convert.ToDouble(Inv_ExRate_Val);

                   while (ds.Tables[2].Rows.Count > iii)
                    {

                        


                    SlNo = ds.Tables[2].Rows[iii]["ITEM_SLNO"].ToString();
                    Item_Desc = ds.Tables[2].Rows[iii]["ITEM_DESCRIPTION"].ToString();
                    Item_Qty = ds.Tables[2].Rows[iii]["ITEM_QTY"].ToString();
                    Item_Unit = ds.Tables[2].Rows[iii]["ITEM_QTY_CODE"].ToString();
                    Item_UnitPrice = ds.Tables[2].Rows[iii]["ITEM_UNIT_PRICE"].ToString();
                    total_Value1 = ds.Tables[2].Rows[iii]["ITEM_TOTAL_AMOUNT"].ToString();

                    INVOICE_NO_ITEM = ds.Tables[2].Rows[iii]["INVOICE_NO"].ToString();
                    INVOICE_SLNO = ds.Tables[2].Rows[iii]["INVOICE_SLNO"].ToString();
                    ITEM_SLNO = ds.Tables[2].Rows[iii]["ITEM_SLNO"].ToString();

                    ASSESABLE_VALUE = Get_Indivitual_Assesable_Value(ds_new.Tables[7], INVOICE_SLNO, INVOICE_NO_ITEM, ITEM_SLNO);
                      // -------------------------Total_Value_INR-------------------------------------------------------
                    double dbl_total_Value = Convert.ToDouble(total_Value1);
                    double dbl_Total_Value_INR = dbl_total_Value * dbl_Inv_ExRate_Val;
                    total_Value = Convert.ToString(dbl_Total_Value_INR);
                    // --------------------------------------------------------------------------------------------------

                    total_Value_INR = ds.Tables[2].Rows[iii]["ITEM_TOTAL_AMOUNT_INR"].ToString();
                    OtherChgs = ds.Tables[2].Rows[iii]["OtherChgs"].ToString();
                    Freight_cal = ds.Tables[2].Rows[iii]["Freight_cal"].ToString();
                    Insurance_Calc = ds.Tables[2].Rows[iii]["Insurance_Calc"].ToString();
                    Tot_CIF = ds.Tables[2].Rows[iii]["CIF_VALUE"].ToString();
                    LandingChargs = ds.Tables[2].Rows[iii]["Landing_Charges"].ToString();
                    Ass_Val = ds.Tables[2].Rows[iii]["ASSESSABLE_VALUE"].ToString();


                    CTH_CETH = ds.Tables[2].Rows[iii]["PRODUCT_CETH"].ToString();
                    BCD_notn = ds.Tables[2].Rows[iii]["PRODUCT_BCD_NOTN"].ToString();
                    BCD_Amt = ds.Tables[2].Rows[iii]["BASIC_VALUE"].ToString();
                    CVD_Notn = ds.Tables[2].Rows[iii]["PRODUCT_CVD_NOTN"].ToString();
                    CVD_Amt = ds.Tables[2].Rows[iii]["CVD_VALUE"].ToString();
                    CessAmt = CessAmt;
                    CVDCessAmt = ds.Tables[2].Rows[iii]["CVDCessAmt"].ToString();
                    Edu_Notn = ds.Tables[2].Rows[iii]["CVDCessAmt"].ToString();
                    ECessAmt = ds.Tables[2].Rows[iii]["ECessAmt"].ToString();
                    SAD = ds.Tables[2].Rows[iii]["ADD_DUTY_VALUE"].ToString();
                    Total = ds.Tables[2].Rows[iii]["DUTY_VALUE"].ToString();

                    BCD_Rate = ds.Tables[2].Rows[iii]["PRODUCT_BCD_RATE"].ToString();
                    CVD_Rate = ds.Tables[2].Rows[iii]["PRODUCT_CVD_RATE"].ToString();
                    SAD_Rate = ds.Tables[2].Rows[iii]["PRODUCT_ADDL_DUTY_RATE"].ToString();
                    ECessRate = ds.Tables[2].Rows[iii]["PRODUCT_EDU_CESS_RATE"].ToString();

                    InvNo = ds.Tables[2].Rows[iii]["INVOICE_NO"].ToString();
                    Inv_Cur = ds.Tables[2].Rows[iii]["INVOICE_SLNO"].ToString();


                        Item_Desc = ds.Tables[2].Rows[iii]["ITEM_DESCRIPTION"].ToString();
                        PRODUCT_CETH = ds.Tables[2].Rows[iii]["PRODUCT_CETH"].ToString();
                        Assbl_Val = ds.Tables[2].Rows[iii]["ASSESSABLE_VALUE"].ToString();
                        Basic_val = ds.Tables[2].Rows[iii]["BASIC_VALUE"].ToString();

                        double Assable = 0, Basic=0;
                        if (Assbl_Val != "")
                        {
                             Assable = Convert.ToDouble(Ass_Val);
                        }
                        if (Basic_val != "")
                        {
                             Basic = Convert.ToDouble(Basic_val);
                        }
                       
                        double Cess_CETH_Rate1 = Assable + Basic;

                         kk.PRODUCT_CETH = PRODUCT_CETH;
                         kk.Ename = "CESS_NOTN_RATE";
                         dsss = kk.RetrieveAll_CheckList_Cess_Import();

                         if (dsss.Tables[0].Rows.Count > 0)
                         {
                             string Cess_Rates = dsss.Tables[0].Rows[0]["CETH_CESS_RTA"].ToString();


                             if (Cess_Rates != "-1.000")
                             {
                                 double dbl_cess_Rates = Convert.ToDouble(Cess_Rates);
                                 double dbl_cess_amt = Cess_CETH_Rate1 * dbl_cess_Rates / 100;
                                 CessAmt = Convert.ToString(dbl_cess_amt);
                                 CETH_CESS_RTA1 = Cess_Rates + "%";
                             }
                             else
                             {
                                 CessAmt = "0";
                                 CETH_CESS_RTA1 = "0.00%";
                             }
                         }
                        

            if (dt.Rows.Count > i)
            {
                
                DataRow row = dt.Rows[i];

                Report_WorkSheet.Add(new Report_DutyWorkSheet()
                {
                    SlNo = SlNo,
                    Item_Desc = Item_Desc,
                    Item_Qty = Item_Qty,
                    Item_Unit = Item_Unit,
                    Item_UnitPrice = Item_UnitPrice,
                    total_Value = total_Value,
                    total_Value_INR = total_Value_INR,
                    OtherChgs = OtherChgs,
                    Freight_cal = Freight_cal,
                    Insurance_Calc = Insurance_Calc,
                    Tot_CIF = Tot_CIF,
                    LandingChargs = LandingChargs,
                    Ass_Val = Ass_Val,

                    CTH_CETH = CTH_CETH,
                    BCD_notn = BCD_notn,
                    BCD_Amt = BCD_Amt,
                    CVD_Notn = CVD_Notn,
                    CVD_Amt = CVD_Amt,
                    CessAmt = CessAmt,
                    CVDCessAmt = CVDCessAmt,
                    Edu_Notn = Edu_Notn,
                    ECessAmt = ECessAmt,
                    SAD = SAD,
                    Total = Total,

                    BCD_Rate = BCD_Rate,
                    CVD_Rate = CVD_Rate,
                    Cess_rate = CETH_CESS_RTA1,
                    SAD_Rate = SAD_Rate,
                    ECessRate=ECessRate,

                    InvNo = InvNo,
                    Inv_Cur = Inv_Cur

                });
                //i++;
            }

            iii++;
         }
                   i++;    
        }
    }


    public double Get_Indivitual_Assesable_Value(DataTable dt_ReImport, string INV_SLNO, string INV_NO, string ITEM_SLNO)
    {
        INVOICE_VALUE_INR = Convert.ToDouble(INVOICE_VALUE) * Convert.ToDouble(INVOICE_EXRATE);
        MISC_AMOUNT = Convert.ToDouble(MIS_CHARGES) * Convert.ToDouble(MIS_EXRATE);
        //-----DISCOUNT AMOUNT CAL--------------//
        if (MIS_DISCOUNT_RATE != "0" && MIS_DISCOUNT_RATE != "0.00")
        {
            DISCOUNT_AMOUNT = (INVOICE_VALUE_INR / 100) * Convert.ToDouble(MIS_DISCOUNT_RATE);
            TOTAL_INVOICE_VALUE = INVOICE_VALUE_INR - DISCOUNT_AMOUNT;
        }
        else if (MIS_DISCOUNT_CHARGES != "0" && MIS_DISCOUNT_CHARGES != "0.00")
        {
            TOTAL_INVOICE_VALUE = INVOICE_VALUE_INR - DISCOUNT_AMOUNT;
        }
        else
            TOTAL_INVOICE_VALUE = INVOICE_VALUE_INR;
        //-----DISCOUNT AMOUNT CAL--------------//

        //-----INSURANCE AMOUNT CAL--------------//
        if (MIS_INSURANCE_RATE != "0" && MIS_INSURANCE_RATE != "0.00")
        {
            INSURANCE_AMOUNT = (Convert.ToDouble(MIS_INSURANCE_RATE) * (MISC_AMOUNT + TOTAL_INVOICE_VALUE)) / 100;

        }
        else if (MIS_INSURANCE_CHARGES != "0" && MIS_INSURANCE_CHARGES != "0.00")
        {
            INSURANCE_AMOUNT = Convert.ToDouble(MIS_INSURANCE_CHARGES) * Convert.ToDouble(MIS_INSURANCE_EXRATE);

        }
        //-----INSURANCE AMOUNT CAL--------------//

        //-----FREIGHT AMOUNT CAL--------------//


        if (MIS_FREIGHT_RATE != "0" && MIS_FREIGHT_RATE != "0.00")
        {
            FREIGHT_AMOUNT = (Convert.ToDouble(MIS_FREIGHT_RATE) * (MISC_AMOUNT + TOTAL_INVOICE_VALUE)) / 100;

        }
        if (TRANSPORT_MODE == "Sea" && TRANSPORT_MODE == "Land")
        {
            if (MIS_FREIGHT_RATE != "0" && MIS_FREIGHT_RATE != "0.00")
            {
            }
            else
            {

                if (MIS_FREIGHT_CHARGES != "")
                {
                    FREIGHT_AMOUNT = Convert.ToDouble(MIS_FREIGHT_CHARGES) * Convert.ToDouble(MIS_FREIGHT_EXRATE);

                }
            }
        }
        else
        {
            if (MIS_FREIGHT_RATE != "0" && MIS_FREIGHT_RATE != "0.00")
            {
            }
            else
            {
                if (MIS_FREIGHT_CHARGES != "0" && MIS_FREIGHT_CHARGES != "0.00")
                {
                    FREIGHT_AMOUNT = Convert.ToDouble(MIS_FREIGHT_CHARGES) * Convert.ToDouble(MIS_FREIGHT_EXRATE);

                    //Calculation not understandable 27/08/2013 //

                    //CHECK_FREIGHT_RATE = (CHECK_FREIGHT_EXRATE * TOTAL_INVOICE_VALUE) / 100;
                    //if (CHECK_FREIGHT_EXRATE >= Convert.ToDouble(MIS_FREIGHT_CHARGES))
                    //{
                    //    FREIGHT_AMOUNT = CHECK_FREIGHT_RATE;
                    //}
                }
            }
        }

        //-----FREIGHT AMOUNT CAL--------------//

        //-----ITEM AMOUNT CAL--------------//
        INDIVITUAL_INVOICE_VALUE = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE) * Convert.ToDouble(INVOICE_EXRATE);
        INDIVITUAL_DISCOUNT_AMOUNT = INDIVITUAL_INVOICE_VALUE * DISCOUNT_AMOUNT / TOTAL_INVOICE_VALUE;


        //-----REIMPORTT CAL--------------//
        DataView view = dt_ReImport.DefaultView;
        if (view.Count > 0)
        {
            view.RowFilter = "INVOICE_NO = '" + INV_NO + "' and " + "INVOICE_SLNO = '" + INV_SLNO + "' and " + "ITEM_SLNO = '" + ITEM_SLNO + "'";
            //view.RowFilter = "JOBNO = " + ddlJobNo + " and " + "INVOICE_SLNO = " + INV_SLNO + " and " + "ITEM_SLNO = " + ITEM_SLNO;
            DataTable table = view.ToTable();
            DataSet dss = new DataSet();
            dss.Tables.Add(table);
            int b = 0;
            while (dss.Tables[0].Rows.Count > b)
            {
                REIMPORT_FREIGHT = Return_Zero_Value(dss.Tables[0].Rows[b]["EXPORT_FREIGHT"].ToString());
                REIMPORT_INSURANCE = Return_Zero_Value(dss.Tables[0].Rows[b]["EXPORT_INSURANCE"].ToString());

                REIMPORT_FREIGHT_AMOUNT = REIMPORT_FREIGHT_AMOUNT + Convert.ToDouble(REIMPORT_FREIGHT);
                REIMPORT_INSURANCE_AMOUNT = REIMPORT_INSURANCE_AMOUNT + Convert.ToDouble(REIMPORT_INSURANCE);
                b++;
            }
        }
        //-----REIMPORTT CAL--------------//
        //-----REIMPORTT FREIGHT CAL--------------//

        INDIVITUAL_FREIGHT_AMOUNT = INDIVITUAL_INVOICE_VALUE / TOTAL_INVOICE_VALUE * FREIGHT_AMOUNT;
        INDIVITUAL_FREIGHT_AMOUNT = INDIVITUAL_FREIGHT_AMOUNT + REIMPORT_FREIGHT_AMOUNT;

        //-----REIMPORTT FREIGHT CAL--------------//

        //-----REIMPORTT INSURANCE CAL--------------//

        INDIVITUAL_INSURANCE_AMOUNT = INDIVITUAL_INVOICE_VALUE / TOTAL_INVOICE_VALUE * INSURANCE_AMOUNT;
        INDIVITUAL_INSURANCE_AMOUNT = INDIVITUAL_INSURANCE_AMOUNT + REIMPORT_INSURANCE_AMOUNT;

        //-----REIMPORTT INSURANCE CAL--------------//

        //-----MISC CAL--------------//

        INDIVITUAL_MISC_AMOUNT = INDIVITUAL_INVOICE_VALUE / TOTAL_INVOICE_VALUE * MISC_AMOUNT;

        //INDIVITUAL_TOTAL_AMOUNT = INDIVITUAL_DISCOUNT_AMOUNT + INDIVITUAL_INSURANCE_AMOUNT + INDIVITUAL_FREIGHT_AMOUNT + INDIVITUAL_MISC_AMOUNT;
        INDIVITUAL_TOTAL_AMOUNT = INDIVITUAL_INVOICE_VALUE + INDIVITUAL_INSURANCE_AMOUNT + INDIVITUAL_FREIGHT_AMOUNT + INDIVITUAL_MISC_AMOUNT;
        //-----MISC CAL--------------//

        //-----HSS CAL--------------//
        if (MIS_HIGHSEASALE_RATE != "0" && MIS_HIGHSEASALE_RATE != "0.00")
        {
            INDIVITUAL_HSS_AMOUNT = (INDIVITUAL_TOTAL_AMOUNT * Convert.ToDouble(MIS_HIGHSEASALE_RATE)) / 100;
        }
        else if (MIS_HIGHSEASALE_CHARGES != "0" && MIS_HIGHSEASALE_CHARGES != "0.00")
        {
            //modified on 23aug2013 by subbu sir
            INDIVITUAL_HSS_AMOUNT = (INDIVITUAL_TOTAL_AMOUNT) / TOTAL_INVOICE_VALUE * Convert.ToDouble(MIS_HIGHSEASALE_CHARGES);
            //modified on 23aug2013 by subbu sir

            //modified on 28Dec2013 by subbu sir
            INDIVITUAL_HSS_AMOUNT = (INDIVITUAL_INVOICE_VALUE) / TOTAL_INVOICE_VALUE * Convert.ToDouble(MIS_HIGHSEASALE_CHARGES);
            //modified on 28Dec2013 by subbu sir


            //INDIVITUAL_HSS_AMOUNT = (INDIVITUAL_TOTAL_AMOUNT * Convert.ToDouble(MIS_HIGHSEASALE_CHARGES)) / 100;
        }



        //-----HSS CAL--------------//

        //-----SVB CAL--------------//



        //if (SVB_ASSESABLE_RATE != "0" && SVB_ASSESABLE_RATE != "0.00")
        //{
        //if (TERMS == "CIF")
        //{
        //    INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_TOTAL_AMOUNT * Convert.ToDouble(SVB_ASSESABLE_RATE)) / 100;
        //}
        //else if (TERMS == "FOB")
        //{
        //    if (MIS_FREIGHT_RATE == "0.00" || MIS_FREIGHT_RATE == "0" && MIS_INSURANCE_RATE == "0.00" || MIS_INSURANCE_RATE == "0" )
        //    {
        //        INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_TOTAL_AMOUNT - (INDIVITUAL_INSURANCE_AMOUNT + INDIVITUAL_FREIGHT_AMOUNT ))*Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
        //       // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
        //    }
        //    else if(MIS_FREIGHT_RATE != "0.00" || MIS_FREIGHT_RATE != "0" && MIS_INSURANCE_RATE != "0.00" || MIS_INSURANCE_RATE != "0" )
        //    {
        //        INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
        //    }
        //}
        //}



        //-----SVB CAL--------------//

        //-----CIF CAL--------------//
        INDIVITUAL_CIF_AMOUNT = INDIVITUAL_TOTAL_AMOUNT + INDIVITUAL_HSS_AMOUNT + INDIVITUAL_SVB_AMOUNT;

        //-----CIF CAL--------------//
        //-----LANDING COST CAL--------------//
        INDIVITUAL_LANDING_COST = (INDIVITUAL_CIF_AMOUNT * 1) / 100;

        //-----LANDING COST CAL--------------//
        //-----ASSESABLE CAL--------------//
        INDIVITUAL_ASSESSABLE_AMOUNT = INDIVITUAL_CIF_AMOUNT + INDIVITUAL_LANDING_COST;

        //-----ASSESABLE CAL--------------//

        //-----ITEM AMOUNT CAL--------------//


        if (SVB_ASSESABLE_RATE != "0" && SVB_ASSESABLE_RATE != "0.00")
        {
            if (TERMS == "CIF")
            {
                INDIVITUAL_SVB_AMOUNT = INDIVITUAL_ASSESSABLE_AMOUNT * (Convert.ToDouble(SVB_ASSESABLE_RATE)) / 100;
            }
            else if (TERMS == "FOB")
            {
                if (MIS_FREIGHT_RATE == "0" || MIS_FREIGHT_RATE == "0.00")
                {
                    MIS_FREIGHT_RATE = "0";
                }


                if (MIS_INSURANCE_RATE == "0" || MIS_INSURANCE_RATE == "0.00")
                {
                    MIS_INSURANCE_RATE = "0";
                }



                if (MIS_FREIGHT_RATE == "0" && MIS_INSURANCE_RATE != "0")
                {
                    double AA = INDIVITUAL_FREIGHT_AMOUNT + (INDIVITUAL_FREIGHT_AMOUNT * 0.01);

                    INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - AA) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                    // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                }

                else if (MIS_FREIGHT_RATE != "0" && MIS_INSURANCE_RATE == "0")
                {
                    double AA = INDIVITUAL_INSURANCE_AMOUNT + (INDIVITUAL_INSURANCE_AMOUNT * 0.01);

                    INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - AA) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                    // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                }

                else if (MIS_FREIGHT_RATE == "0" && MIS_INSURANCE_RATE == "0")
                {
                    double AA = INDIVITUAL_INSURANCE_AMOUNT + (INDIVITUAL_INSURANCE_AMOUNT * 0.01);
                    double BB = INDIVITUAL_FREIGHT_AMOUNT + (INDIVITUAL_FREIGHT_AMOUNT * 0.01);
                    double CC = AA + BB;

                    INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - CC) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                    // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                }

                else if (MIS_FREIGHT_RATE != "0" && MIS_INSURANCE_RATE != "0")
                {
                    double AA = INDIVITUAL_INSURANCE_AMOUNT - (INDIVITUAL_INSURANCE_AMOUNT * 0.01);
                    double BB = INDIVITUAL_FREIGHT_AMOUNT - (INDIVITUAL_FREIGHT_AMOUNT * 0.01);
                    double CC = AA + BB;

                    INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - CC) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                    // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                }

            }
            else if (TERMS == "CF")
            {

                if (MIS_INSURANCE_RATE == "0" || MIS_INSURANCE_RATE == "0.00")
                {
                    MIS_INSURANCE_RATE = "0";
                }

                if (MIS_INSURANCE_RATE != "0")
                {
                    double AA = INDIVITUAL_INSURANCE_AMOUNT - (INDIVITUAL_INSURANCE_AMOUNT * 0.01);

                    INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - AA) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                    // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                }
                else if (MIS_INSURANCE_RATE == "0")
                {
                    double AA = INDIVITUAL_INSURANCE_AMOUNT + (INDIVITUAL_INSURANCE_AMOUNT * 0.01);

                    INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - AA) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                    // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                }
            }
            else if (TERMS == "CI")
            {

                if (MIS_FREIGHT_RATE == "0" || MIS_FREIGHT_RATE == "0.00")
                {
                    MIS_FREIGHT_RATE = "0";
                }

                if (MIS_FREIGHT_RATE != "0")
                {
                    double AA = INDIVITUAL_FREIGHT_AMOUNT - (INDIVITUAL_FREIGHT_AMOUNT * 0.01);

                    INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - AA) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                    // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                }
                else if (MIS_FREIGHT_RATE == "0")
                {
                    double AA = INDIVITUAL_FREIGHT_AMOUNT + (INDIVITUAL_FREIGHT_AMOUNT * 0.01);

                    INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_ASSESSABLE_AMOUNT - AA) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                    // INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_INVOICE_VALUE) * Convert.ToDouble(SVB_ASSESABLE_RATE) / 100;
                }
            }
        }

        INDIVITUAL_ASSESSABLE_AMOUNT = INDIVITUAL_ASSESSABLE_AMOUNT + INDIVITUAL_SVB_AMOUNT;
        return INDIVITUAL_ASSESSABLE_AMOUNT;
    }

    public string Return_Zero_Value(string val)
    {
        if (val == "")
        {
            val = "0";
        }
        return val;
    }
    public string Return_Zero_Value1(string val)
    {
        if (val == "")
        {
            val = "0.00";
        }
        return val;
    }
}