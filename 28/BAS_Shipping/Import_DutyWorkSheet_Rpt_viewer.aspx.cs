using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Data.SqlClient;

using System.IO;
using Microsoft.ApplicationBlocks.Data;
using System.ComponentModel;
using System.Drawing.Printing;
//using System.Drawing.Printing;

using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Web.UI.WebControls.WebParts;
//using ReportViewerLib;
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
using AjaxControlToolkit;
using Microsoft.ReportingServices.Rendering;
using Microsoft.ReportingServices.Library;
using System.Linq;

public partial class Import_DutyWorkSheet_Rpt_viewer : System.Web.UI.Page
{
    

    #region Private_Attributes
    private string _BE_NO;
    private string _BE_NO_DATE;
    private string _JOB_NO;
    private string _Today_dt;
   
    private string _Importer_Name;

    private string _TRANSPORT_MODE;
   
    private string _CUSTOMS_HOUSE;
    
  
    //private string _INVOICE_SLNO;
    private string _INVOICE_NO;
   

    #endregion
    #region Public_Attributes
  
    public string BE_NO { get { return _BE_NO; } set { _BE_NO = value; } }
    public string BE_NO_DATE { get { return _BE_NO_DATE; } set { _BE_NO_DATE = value; } }
    public string JOB_NO { get { return _BE_NO; } set { _JOB_NO = value; } }
    public string Today_dt { get { return _BE_NO; } set { _Today_dt = value; } }
    public string Importer_Name { get { return _Importer_Name; } set { _Importer_Name = value; } }
    
    public string CUSTOMS_HOUSE { get { return _CUSTOMS_HOUSE; } set { _CUSTOMS_HOUSE = value; } }
         
    #endregion
    //---------------------ITEM ATTRIBUTES-----------------//
    #region ITEM ATTRIBUTES
    #region Private_Attributes
    private string _INVOICE_SLNO;
    private string _INVOICE_DATE;
    private string  _INVOICE_NO_ITEM, _Invoice_No, _Invoice_Details;

    private string _INVOICE_VALUE, _Invoice_value, _INVOICE_EXRATE;
   
    //item Details
    
    private string _ITEM_SLNO;
    private string _ITEM_DESCRIPTION;
    private string _ITEM_QTY;
    private string _ITEM_QTY_CODE;
    private string _ITEM_UNIT_PRICE;
    private string  _Total_Invoice, _SupplierCountry_Name_Pincode;
   
    #endregion
    #region Public_Attributes
    
    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
    public string INVOICE_NO_ITEM { get { return _INVOICE_NO_ITEM; } set { _INVOICE_NO_ITEM = value; } }
    public string Invoice_No { get { return _Invoice_No; } set { _Invoice_No = value; } }
    public string Invoice_Details { get { return _Invoice_Details; } set { _Invoice_Details = value; } }

    public string INVOICE_VALUE { get { return _INVOICE_VALUE; } set { _INVOICE_VALUE = value; } }
    public string Invoice_value { get { return _Invoice_value; } set { _Invoice_value = value; } }


    //ITEM DETAILS

    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string ITEM_DESCRIPTION { get { return _ITEM_DESCRIPTION; } set { _ITEM_DESCRIPTION = value; } }
    public string ITEM_QTY { get { return _ITEM_QTY; } set { _ITEM_QTY = value; } }
    public string ITEM_QTY_CODE { get { return _ITEM_QTY_CODE; } set { _ITEM_QTY_CODE = value; } }
    public string ITEM_UNIT_PRICE { get { return _ITEM_UNIT_PRICE; } set { _ITEM_UNIT_PRICE = value; } }
   
  
  
    #endregion
#endregion
    public string working_period;

    AppSession aps = new AppSession();
    Transaction Transact = new Transaction();
    adminmaster adm = new adminmaster();
    NForm Nform = new NForm();

    DataSet ds = new DataSet();
    DutyWorkSht WorkSht = new DutyWorkSht();
    DataSet ds1 = new DataSet();
    DataSet dss = new DataSet();
    AdminMasterDetails admin = new AdminMasterDetails();

    public string currentuser, ddlJobNo;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate,testaddress;
    public string SELECT_TYPE, SELECT_BRANCH;
    
    Date_Time dt = new Date_Time();
    DataTable dtt = new DataTable();
    string H_AddlDuty = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        working_period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        LoginDate = HttpContext.Current.Session["LoginDate"].ToString();

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
            Page_loaItem_Details();
           
        }
    }
   
    public void Page_loaItem_Details()
    {
        try
        {
            if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
            {

            }
            else
            {
                ddlJobNo = Request.QueryString["jobno"].ToString();
                Session["JobNo"] = ddlJobNo;
               
                List<ReportParameter> paramList = new List<ReportParameter>(); this.ReportViewer1.LocalReport.SetParameters(paramList);

                ReportViewer1.LocalReport.DataSources.Clear();

                Get_FILE_REF_NO();

                WorkSht.JOBNO = ddlJobNo;
                WorkSht.BRANCHCODE = SELECT_BRANCH;
                WorkSht.flag = "select_RITC";
                ds1 = WorkSht.RetrieveAll_IMPORT_WORKSHEET_REPORT();

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    List<string> toReturn = new List<string>();

                    DataTable dt_column = new DataTable();
                    DataRow rr = dt_column.NewRow();

                    dt_column.Columns.Add("WORK SHEET");
                    dt_column.Columns.Add("JobNo :" + ddlJobNo);
                    dt_column.Columns.Add("RefNo :" + ViewState["FILEREF_NO"].ToString());
                    string vals = "";
                    for (int i = 1; i <= ds1.Tables[0].Rows.Count - 1; i++)
                    {
                        string val = " ";
                        vals += val;
                        dt_column.Columns.Add(vals);
                    }

                    DataRow row1 = dt_column.NewRow();
                    row1.ItemArray = toReturn.ToArray();
                    dt_column.Rows.Add("Details");

                    int rr1 = 0;
                    for (int i = 1; i <= ds1.Tables[0].Rows.Count; i++)
                    {
                        dt_column.Rows[0][i] = "RITC" + i;
                        //dt_column.Columns.Add("RITC" + i);
                        rr1 = i;
                    }
                    dt_column.Rows[0][rr1 + 1] = "FinalTotal";
                    

                    toReturn.Add("RITC NO");
                    for (int i = 0; i <= ds1.Tables[0].Rows.Count - 1; i++)
                    {
                        toReturn.Add(ds1.Tables[0].Rows[i]["PRODUCT_RITC"].ToString());
                    }
                    DataRow row = dt_column.NewRow();
                    row.ItemArray = toReturn.ToArray();
                    dt_column.Rows.Add(row);
                    toReturn.Clear();

                    toReturn.Add("CTH NO");
                    for (int i = 0; i <= ds1.Tables[0].Rows.Count - 1; i++)
                    {
                        toReturn.Add(ds1.Tables[0].Rows[i]["PRODUCT_CTH"].ToString());
                    }
                    row = dt_column.NewRow();
                    row.ItemArray = toReturn.ToArray();
                    dt_column.Rows.Add(row);
                    toReturn.Clear();

                    row = dt_column.NewRow();
                    row.ItemArray = toReturn.ToArray();
                    dt_column.Rows.Add(row);
                    toReturn.Clear();

                    toReturn.Add("CETH NO");
                    for (int i = 0; i <= ds1.Tables[0].Rows.Count - 1; i++)
                    {
                        toReturn.Add(ds1.Tables[0].Rows[i]["PRODUCT_CETH"].ToString());
                    }

                    row = dt_column.NewRow();
                    row.ItemArray = toReturn.ToArray();
                    dt_column.Rows.Add(row);
                    toReturn.Clear();

                    row = dt_column.NewRow();
                    row.ItemArray = toReturn.ToArray();
                    dt_column.Rows.Add(row);
                    toReturn.Clear();


                    for (int cc = 0; cc <= 26; cc++)
                    {
                        dt_column.Rows.Add();
                    }


                    toReturn.Clear();
                    DataTable dt_tot_Amt = new DataTable();

                    int MAX_ROW = 25;
                    int col = 1;

                    #region Second_Part

                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        //for (int i = 0; i <= ds1.Tables[0].Rows.Count; i++)
                        //{
                        //    toReturn.Add("____________");
                        //}
                        //row = dt_column.NewRow();
                        //row.ItemArray = toReturn.ToArray();
                        //dt_column.Rows.Add(row);

                        for (int x = 0; x <= ds1.Tables[0].Rows.Count - 1; x++)
                        {
                            Retreive_All_RITC_Details(ds1, x, "Select_ITEM_Amount_frm_RITC");

                            int rw = 25;
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int j = 0; j <= ds.Tables[0].Rows.Count - 1; j++)
                                {
                                    dt_column.Rows.Add();
                                    dt_column.Rows[rw][col] = ds.Tables[0].Rows[j]["ITEM_TOTAL_AMOUNT"].ToString();
                                    if (ds.Tables[0].Rows.Count == 1)
                                    {
                                        rw = 25;
                                    }
                                    else
                                    {
                                        rw = rw + 1;
                                    }

                                    if (rw > MAX_ROW)
                                    {
                                        MAX_ROW = rw;
                                    }

                                }
                                col = col + 1;
                            }                          
                            //****************************************
                        }
                        if (MAX_ROW == 25)
                        {
                            MAX_ROW = MAX_ROW + 1;
                            for (int cc = 0; cc <= 23; cc++)
                            {
                                dt_column.Rows.Add();
                            }
                        }
                        else
                        {
                            for (int cc = 0; cc <= 23; cc++)
                            {
                                dt_column.Rows.Add();
                            }
                        }

                        //dt_column.Rows[21][0] = ("____________");

                        //for (int xX = 0; xX <= dt_column.Columns.Count - 1; xX++)
                        //{
                        //    dt_column.Rows[MAX_ROW][xX] = ("____________");
                        //}

                        for (int xX = 0; xX <= dt_column.Columns.Count - 1; xX++)
                        {
                            dt_column.Rows[MAX_ROW+1][xX] = ("");
                        }

                    #endregion Second_Part

                    #region Third_Part

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            double Item_Amount = 0.00;
                            double Tot_Item_Amount = 0.00;
                            double FOB = 0.00;
                            double Tot_FOB = 0.00;
                            double FOB_in_RS = 0.00;
                            double Tot_FOB_in_RS = 0.00;
                            double Actual_Frt = 0.00;
                            double Tot_Actual_Frt = 0.00;
                            double Actual_Ins = 0.00;
                            double Tot_Actual_Ins = 0.00;
                            double Actual_Misc = 0.00;
                            double Tot_Actual_Misc = 0.00;
                            double Actual_HSS = 0.00;
                            double Tot_Actual_HSS = 0.00;
                            double CIF = 0.00;
                            double Tot_CIF = 0.00;
                            double Handling = 0.00;
                            double Tot_Handling = 0.00;
                            double Ass_Val = 0.00;
                            double Tot_Ass_Val = 0.00;
                            double Rund_Ass_Val = 0.00;
                            double Rund_Tot_Ass_Val = 0.00;
                            double Qty = 0.00;
                            double Tot_Qty = 0.00;

                            double BCD = 0.00;
                            double Tot_BCD = 0.00;
                            double CVD = 0.00;
                            double Tot_CVD = 0.00;
                            double CEC = 0.00;
                            double Tot_CEC = 0.00;
                            double CHEC = 0.00;
                            double Tot_CHEC = 0.00;
                            double ADD_Duty = 0.00;
                            double Tot_ADD_Duty = 0.00;

                            double Final_Value = 0.00;

                            col = 1;
                            for (int x = 0; x <= ds1.Tables[0].Rows.Count - 1; x++)
                            {
                                
                                Retreive_All_RITC_Details(ds1, x, "Select_ITEM_TOTAL_AMOUNT_FOB_IN_USD");
                                H_AddlDuty = "";
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    
                                    Item_Amount=  Convert.ToDouble(ds.Tables[0].Rows[0]["ITEM_TOTAL_AMOUNT"].ToString());
                                    dt_column.Rows[MAX_ROW + 1][col] = Item_Amount;
                                    Tot_Item_Amount += Convert.ToDouble(ds.Tables[0].Rows[0]["ITEM_TOTAL_AMOUNT"].ToString());

                                    //    Actual_Misc = Convert.ToDouble(ds.Tables[0].Rows[0]["INDIVITUAL_MISC_AMOUNT"].ToString());
                                    //    dt_column.Rows[MAX_ROW + 2][col] = Actual_Misc;
                                    //    Tot_Actual_Misc += Actual_Misc;

                                    //    FOB = Item_Amount + Actual_Misc;
                                    //    dt_column.Rows[MAX_ROW + 3][col] = FOB;
                                    //    Tot_FOB += FOB;

                                    //    FOB_in_RS = FOB * Convert.ToDouble(ds.Tables[1].Rows[0]["INVOICE_EXRATE"].ToString());
                                    //    dt_column.Rows[MAX_ROW + 4][col] = FOB_in_RS;
                                    //    Tot_FOB_in_RS += FOB_in_RS;

                                    if (ds.Tables[1].Rows[0]["MIS_CURRENCY"].ToString() == "INR")
                                    {
                                        Actual_Misc = Convert.ToDouble(ds.Tables[0].Rows[0]["INDIVITUAL_MISC_AMOUNT"].ToString());
                                        dt_column.Rows[MAX_ROW + 2][col] = Actual_Misc;
                                        Tot_Actual_Misc += Actual_Misc;

                                        double convert_fc = Convert.ToDouble(ds.Tables[0].Rows[0]["INDIVITUAL_MISC_AMOUNT"].ToString()) / Convert.ToDouble(ds.Tables[1].Rows[0]["INVOICE_EXRATE"].ToString());

                                        FOB = Item_Amount + convert_fc;
                                        dt_column.Rows[MAX_ROW + 3][col] = FOB;
                                        Tot_FOB += FOB;

                                        FOB_in_RS = FOB * Convert.ToDouble(ds.Tables[1].Rows[0]["INVOICE_EXRATE"].ToString());
                                        dt_column.Rows[MAX_ROW + 4][col] = FOB_in_RS;
                                        Tot_FOB_in_RS += FOB_in_RS;
                                    }
                                    else
                                    {
                                        Actual_Misc = Convert.ToDouble(ds.Tables[0].Rows[0]["INDIVITUAL_MISC_AMOUNT"].ToString()) / Convert.ToDouble(ds.Tables[1].Rows[0]["MIS_EXRATE"].ToString());
                                        //Actual_Misc = Convert.ToDouble(ds.Tables[0].Rows[0]["INDIVITUAL_MISC_AMOUNT"].ToString());
                                        dt_column.Rows[MAX_ROW + 2][col] =  Math.Round(Actual_Misc, 2);
                                        Tot_Actual_Misc += Math.Round(Actual_Misc, 2);

                                        FOB = Item_Amount + Math.Round(Actual_Misc, 2);
                                        dt_column.Rows[MAX_ROW + 3][col] = FOB;
                                        Tot_FOB += FOB;

                                        FOB_in_RS = FOB * Convert.ToDouble(ds.Tables[1].Rows[0]["INVOICE_EXRATE"].ToString());
                                        dt_column.Rows[MAX_ROW + 4][col] = FOB_in_RS;
                                        Tot_FOB_in_RS += FOB_in_RS;
                                    }


                                    Actual_Frt = Convert.ToDouble(ds.Tables[0].Rows[0]["INDIVITUAL_FREIGHT_AMOUNT"].ToString());
                                    dt_column.Rows[MAX_ROW + 5][col] = Actual_Frt;
                                    Tot_Actual_Frt += Actual_Frt;

                                    Actual_Ins = Convert.ToDouble(ds.Tables[0].Rows[0]["INDIVITUAL_INSURANCE_AMOUNT"].ToString());
                                    dt_column.Rows[MAX_ROW + 6][col] = Actual_Ins;
                                    Tot_Actual_Ins += Actual_Ins;

                                    Actual_HSS = Convert.ToDouble(ds.Tables[0].Rows[0]["INDIVITUAL_HSS_AMOUNT"].ToString());
                                    dt_column.Rows[MAX_ROW + 7][col] = Actual_HSS;
                                    Tot_Actual_HSS += Actual_HSS;

                                    //dt_column.Rows[MAX_ROW + 8][col] = ("____________");

                                    CIF = FOB_in_RS + Actual_Frt + Actual_Ins  + Actual_HSS;
                                    dt_column.Rows[MAX_ROW + 9][col] = CIF;
                                    Tot_CIF += CIF;

                                    Handling = CIF * 1 / 100;
                                    dt_column.Rows[MAX_ROW + 10][col] = Handling;
                                    Tot_Handling += Handling;

                                    Ass_Val = Convert.ToDouble(ds.Tables[0].Rows[0]["ASSESSABLE_VALUE"].ToString());
                                    dt_column.Rows[MAX_ROW + 11][col] = Ass_Val;
                                    Tot_Ass_Val += Ass_Val;

                                    //dt_column.Rows[MAX_ROW + 12][col] = ("____________");

                                    //Rund_Ass_Val = Math.Round(Ass_Val, 2, MidpointRounding.ToEven);
                                    //string aa = Math.Round(Convert.ToString(Ass_Val), 2, MidpointRounding.AwayFromZero).ToString();
                                    Rund_Ass_Val = Math.Round(Ass_Val, 0);
                                    dt_column.Rows[MAX_ROW + 13][col] = Rund_Ass_Val;
                                    //dt_column.Rows[MAX_ROW + 9][x] = Convert.ToString(Math.Round(Convert.ToDouble(Ass_Val), 2).ToString("0.00"));
                                    Rund_Tot_Ass_Val += Rund_Ass_Val;

                                    Qty = Convert.ToDouble(ds.Tables[0].Rows[0]["ITEM_QTY"].ToString());
                                    dt_column.Rows[MAX_ROW + 14][col] = Qty;
                                    Tot_Qty += Qty;
                                    string BCD_RATE = "", CVD_RATE = "",ADDL_DUTY_RATE="";

                                    if (ds.Tables[2].Rows.Count > 0)
                                    {
                                        if (ds.Tables[2].Rows[0]["PRODUCT_BCD_RATE"].ToString() == "" || ds.Tables[2].Rows[0]["PRODUCT_BCD_RATE"].ToString() == null)
                                        {
                                            BCD_RATE = ds.Tables[2].Rows[0]["CHECKLIST_BCD_RATE"].ToString();
                                        }
                                        else
                                        {
                                            BCD_RATE = ds.Tables[2].Rows[0]["PRODUCT_BCD_RATE"].ToString();
                                        }

                                        if (ds.Tables[2].Rows[0]["PRODUCT_CVD_RATE"].ToString() == "" || ds.Tables[2].Rows[0]["PRODUCT_CVD_RATE"].ToString() == null)
                                        {
                                            CVD_RATE = ds.Tables[2].Rows[0]["CHECKLIST_CVD_RATE"].ToString();
                                        }
                                        else
                                        {
                                            CVD_RATE = ds.Tables[2].Rows[0]["PRODUCT_CVD_RATE"].ToString();
                                        }

                                        if (ds.Tables[2].Rows[0]["PRODUCT_ADDL_DUTY_RATE"].ToString() == "" || ds.Tables[2].Rows[0]["PRODUCT_ADDL_DUTY_RATE"].ToString() == null)
                                        {
                                            ADDL_DUTY_RATE = ds.Tables[2].Rows[0]["CHECKLIST_ADDL_DUTY_RATE"].ToString();
                                        }
                                        else
                                        {
                                            ADDL_DUTY_RATE = ds.Tables[2].Rows[0]["PRODUCT_ADDL_DUTY_RATE"].ToString();
                                        }

                                        if(BCD_RATE.Contains(".00"))
                                        {
                                            string[] bcd=BCD_RATE.Split('.');
                                            BCD_RATE = bcd[0];
                                        }
                                        if (CVD_RATE.Contains(".00"))
                                        {
                                            string[] bcd = CVD_RATE.Split('.');
                                            CVD_RATE = bcd[0];
                                        }
                                        if (ADDL_DUTY_RATE.Contains(".00"))
                                        {
                                            string[] bcd = ADDL_DUTY_RATE.Split('.');
                                            ADDL_DUTY_RATE = bcd[0];
                                        }
                                        dt_column.Rows[MAX_ROW + 15][col] = BCD_RATE + "+" + CVD_RATE + "+" + ADDL_DUTY_RATE;
                                    }

                                   
                                    dt_column.Rows[MAX_ROW + 0][0] = ("____________");
                                    dt_column.Rows[MAX_ROW + 1][0] = "Item Total Amount";
                                    dt_column.Rows[MAX_ROW + 3][0] = ds.Tables[1].Rows[0]["TERMS"].ToString() + " in " + ds.Tables[1].Rows[0]["INVOICE_CURRENCY"].ToString();
                                    dt_column.Rows[MAX_ROW + 4][0] = ds.Tables[1].Rows[0]["TERMS"].ToString() + " in RS ";

                                    BCD = 0.00;
                                    string BCDNotn_SlNo = "", CVDNotn_SlNo = "", ADLNotn_SlNo = "";

                                    if (ds.Tables[2].Rows.Count > 0)
                                    {
                                        if (ds.Tables[2].Rows[0]["PRODUCT_BCD_NOTN"].ToString() != "")
                                        {
                                            BCDNotn_SlNo = "(" + ds.Tables[2].Rows[0]["PRODUCT_BCD_NOTN"].ToString() + " - " + ds.Tables[2].Rows[0]["PRODUCT_BCD_SLNO"].ToString() + ")  ";
                                            dt_column.Rows[3][col] = BCDNotn_SlNo;
                                        }

                                        if (ds.Tables[2].Rows[0]["SCHEME_CODE"].ToString() == "00 - DUTIABLE")
                                        {
                                            BCD = Convert.ToDouble(ds.Tables[0].Rows[0]["BASIC_VALUE"].ToString());
                                        }
                                        else
                                        {
                                            //BCD = Convert.ToDouble(ds.Tables[0].Rows[0]["MERIT_DUTY_VALUE"].ToString());
                                            BCD = Convert.ToDouble(ds.Tables[0].Rows[0]["MERIT_NOTN_BASIC_VALUE"].ToString());
                                        }

                                        if (BCD == 0 || BCD == 0.0)
                                        {
                                            string aa = "0.00";
                                            dt_column.Rows[MAX_ROW + 16][col] = aa;
                                        }
                                        else
                                        {
                                            dt_column.Rows[MAX_ROW + 16][col] = BCD;
                                        }
                                        Tot_BCD += BCD;

                                        CVD = 0.00;
                                        if (ds.Tables[2].Rows[0]["PRODUCT_CVD_NOTN"].ToString() != "")
                                        {
                                            CVDNotn_SlNo = "(" + ds.Tables[2].Rows[0]["PRODUCT_CVD_NOTN"].ToString() + " - " + ds.Tables[2].Rows[0]["PRODUCT_CVD_SLNO"].ToString() + ")  ";
                                            dt_column.Rows[5][col] = CVDNotn_SlNo;
                                        }

                                        if (ds.Tables[2].Rows[0]["SCHEME_CODE"].ToString() == "00 - DUTIABLE")
                                        {
                                            CVD = Convert.ToDouble(ds.Tables[0].Rows[0]["CVD_VALUE"].ToString());
                                        }
                                        else
                                        {
                                            //CVD = Convert.ToDouble(ds.Tables[0].Rows[0]["MERIT_CVD_VALUE"].ToString());
                                            CVD = Convert.ToDouble(ds.Tables[0].Rows[0]["MERIT_NOTN_CVD_VALUE"].ToString());
                                        }
                                        if (CVD == 0 || CVD == 0.0)
                                        {
                                            string aa = "0.00";
                                            dt_column.Rows[MAX_ROW + 17][col] = aa;
                                        }
                                        else
                                        {
                                            dt_column.Rows[MAX_ROW + 17][col] = CVD;
                                        }
                                        
                                        Tot_CVD += CVD;

                                        //        //************************************
                                        CEC = 0.00;
                                        if (ds.Tables[0].Rows[0]["CEC_VALUE"].ToString() != "")
                                        {
                                            if (ds.Tables[2].Rows[0]["SCHEME_CODE"].ToString() == "00 - DUTIABLE")
                                            {
                                                CEC = Convert.ToDouble(ds.Tables[0].Rows[0]["CEC_VALUE"].ToString());
                                            }
                                            else
                                            {
                                                //CEC = Convert.ToDouble(ds.Tables[0].Rows[0]["MERIT_CEC_VALUE"].ToString());
                                                CEC = Convert.ToDouble(ds.Tables[0].Rows[0]["MERIT_NOTN_CEC_VALUE"].ToString());
                                            }
                                            if (CEC == 0 || CEC == 0.0)
                                            {
                                                string aa = "0.00";
                                                dt_column.Rows[MAX_ROW + 18][col] = aa;
                                            }
                                            else
                                            {
                                                dt_column.Rows[MAX_ROW + 18][col] = CEC;
                                            }
                                            
                                            Tot_CEC += CEC;
                                        }
                                        //        //************************************
                                        CHEC = 0.00;
                                        if (ds.Tables[0].Rows[0]["CHEC_VALUE"].ToString() != "")
                                        {
                                            if (ds.Tables[2].Rows[0]["SCHEME_CODE"].ToString() == "00 - DUTIABLE")
                                            {
                                                CHEC = Convert.ToDouble(ds.Tables[0].Rows[0]["CHEC_VALUE"].ToString());
                                            }
                                            else
                                            {
                                                //CHEC = Convert.ToDouble(ds.Tables[0].Rows[0]["MERIT_CHEC_VALUE"].ToString());
                                                CHEC = Convert.ToDouble(ds.Tables[0].Rows[0]["MERIT_NOTN_CHEC_VALUE"].ToString());

                                            }
                                            if (CHEC == 0 || CHEC == 0.0)
                                            {
                                                string aa = "0.00";
                                                dt_column.Rows[MAX_ROW + 19][col] = aa;
                                            }
                                            else
                                            {
                                                dt_column.Rows[MAX_ROW + 19][col] = CHEC;
                                            }
                                            
                                            Tot_CHEC += CHEC;
                                        }

                                        ADD_Duty = 0.00;

                                        if (ds.Tables[2].Rows[0]["SCHEME_CODE"].ToString() == "00 - DUTIABLE")     
                                        {                                
                                            ADD_Duty = Convert.ToDouble(ds.Tables[0].Rows[0]["ADD_DUTY_VALUE"].ToString());
                                        }
                                        else
                                        {                                           
                                            //ADD_Duty = Convert.ToDouble(ds.Tables[0].Rows[0]["MERIT_ADD_DUTY_VALUE"].ToString());
                                            ADD_Duty = Convert.ToDouble(ds.Tables[0].Rows[0]["MERIT_NOTN_ADD_DUTY_VALUE"].ToString());
                                        }
                                        if (ADD_Duty == 0 || ADD_Duty == 0.0)
                                        {
                                            string aa = "0.00";
                                            dt_column.Rows[MAX_ROW + 20][col] = aa;
                                        }
                                        else
                                        {
                                            dt_column.Rows[MAX_ROW + 20][col] = ADD_Duty;
                                        }
                                        Tot_ADD_Duty += ADD_Duty;

                                        if (ds.Tables[2].Rows[0]["PRODUCT_ADDL_DUTY_NOTN"].ToString() != "")
                                        {
                                            if (ds.Tables[2].Rows[0]["PRODUCT_ADDL_DUTY_NOTN"].ToString() != "019/2006")
                                            {
                                                ADLNotn_SlNo = "(" + ds.Tables[2].Rows[0]["PRODUCT_ADDL_DUTY_NOTN"].ToString() + " - " + ds.Tables[2].Rows[0]["PRODUCT_ADDL_DUTY_NOTN_SL"].ToString() + ")  ";
                                                dt_column.Rows[6][col] = ADLNotn_SlNo;
                                                H_AddlDuty = "1";
                                            }
                                        }
                                        string Edu_cess_Notn = "";
                                        if (ds.Tables[2].Rows[0]["PRODUCT_EDU_CESS_NOTN"].ToString() != "")
                                        {
                                            Edu_cess_Notn = "(" + ds.Tables[2].Rows[0]["PRODUCT_EDU_CESS_NOTN"].ToString() + " - " + ds.Tables[2].Rows[0]["PRODUCT_EDU_CESS_NOTN_SL"].ToString() + ")  ";
                                            dt_column.Rows[7][col] = Edu_cess_Notn;
                                        }

                                        string Higher_Edu_cess_Notn = "";
                                        if (ds.Tables[2].Rows[0]["PRODUCT_SEC_EDU_CESS_NOTN"].ToString() != "")
                                        {
                                            Higher_Edu_cess_Notn = "(" + ds.Tables[2].Rows[0]["PRODUCT_SEC_EDU_CESS_NOTN"].ToString() + " - " + ds.Tables[2].Rows[0]["PRODUCT_SEC_EDU_CESS_NOTN_SL"].ToString() + ")  ";
                                            dt_column.Rows[8][col] = Higher_Edu_cess_Notn;
                                        }

                                        string NCD_Notn = "";
                                        if (ds.Tables[2].Rows[0]["PRODUCT_NCD_NOTN"].ToString() != "")
                                        {
                                            NCD_Notn = "(" + ds.Tables[2].Rows[0]["PRODUCT_NCD_NOTN"].ToString() + " - " + ds.Tables[2].Rows[0]["PRODUCT_NCD_SLNO"].ToString() + ")  ";
                                            dt_column.Rows[9][col] = NCD_Notn;
                                        }

                                        string Aggregate_Notn = "";
                                        if (ds.Tables[2].Rows[0]["PRODUCT_AGGREGATE_DUTY_NOTN"].ToString() != "")
                                        {
                                            Aggregate_Notn = "(" + ds.Tables[2].Rows[0]["PRODUCT_AGGREGATE_DUTY_NOTN"].ToString() + " - " + ds.Tables[2].Rows[0]["PRODUCT_AGGREGATE_DUTY_NOTN_SL"].ToString() + ")  ";
                                            dt_column.Rows[10][col] = Aggregate_Notn;
                                        }

                                        string SAFEGUARD_Notn = "";
                                        if (ds.Tables[2].Rows[0]["PRODUCT_SAFEGUARD_NOTN"].ToString() != "")
                                        {
                                            SAFEGUARD_Notn = "(" + ds.Tables[2].Rows[0]["PRODUCT_SAFEGUARD_NOTN"].ToString() + " - " + ds.Tables[2].Rows[0]["PRODUCT_SAFEGUARD_SLNO"].ToString() + ")  ";
                                            dt_column.Rows[11][col] = SAFEGUARD_Notn;
                                        }

                                        string SAPTA_Notn = "";
                                        if (ds.Tables[2].Rows[0]["PRODUCT_SAPTA_NOTN"].ToString() != "")
                                        {
                                            SAPTA_Notn = "(" + ds.Tables[2].Rows[0]["PRODUCT_SAPTA_NOTN"].ToString() + " - " + ds.Tables[2].Rows[0]["PRODUCT_SAPTA_SLNO"].ToString() + ")  ";
                                            dt_column.Rows[12][col] = SAPTA_Notn;
                                        }

                                        string TARIFF_Notn = "";
                                        if (ds.Tables[2].Rows[0]["PRODUCT_TARIFF_NOTN"].ToString() != "")
                                        {
                                            TARIFF_Notn = "(" + ds.Tables[2].Rows[0]["PRODUCT_TARIFF_NOTN"].ToString() + " - " + ds.Tables[2].Rows[0]["PRODUCT_TARIFF_SLNO"].ToString() + ")  ";
                                            dt_column.Rows[13][col] = TARIFF_Notn;
                                        }

                                        //Excise Notifications Started...................................

                                        string ADDL5_SIA_Notn = "";
                                        if (ds.Tables[2].Rows[0]["PRODUCT_ADDL5_SIA_NOTN"].ToString() != "")
                                        {
                                            ADDL5_SIA_Notn = "(" + ds.Tables[2].Rows[0]["PRODUCT_ADDL5_SIA_NOTN"].ToString() + " - " + ds.Tables[2].Rows[0]["PRODUCT_ADDL5_SIA_NOTN_SL"].ToString() + ")  ";
                                            dt_column.Rows[14][col] = ADDL5_SIA_Notn;
                                        }

                                        string ADDL_GSI_Notn = "";
                                        if (ds.Tables[2].Rows[0]["PRODUCT_ADDL_GSI_NOTN"].ToString() != "")
                                        {
                                            ADDL_GSI_Notn = "(" + ds.Tables[2].Rows[0]["PRODUCT_ADDL_GSI_NOTN"].ToString() + " - " + ds.Tables[2].Rows[0]["PRODUCT_ADDL_GSI_SLNO"].ToString() + ")  ";
                                            dt_column.Rows[15][col] = ADDL_GSI_Notn;
                                        }

                                        string ADDL_SHEII_Notn = "";
                                        if (ds.Tables[2].Rows[0]["PRODUCT_ADDL_SHEII_NOTN"].ToString() != "")
                                        {
                                            ADDL_SHEII_Notn = "(" + ds.Tables[2].Rows[0]["PRODUCT_ADDL_SHEII_NOTN"].ToString() + " - " + ds.Tables[2].Rows[0]["PRODUCT_ADDL_SHEII_SLNO"].ToString() + ")  ";
                                            dt_column.Rows[16][col] = ADDL_SHEII_Notn;
                                        }

                                        string ADDL_TTA_Notn = "";
                                        if (ds.Tables[2].Rows[0]["PRODUCT_ADDL_TTA_NOTN"].ToString() != "")
                                        {
                                            ADDL_TTA_Notn = "(" + ds.Tables[2].Rows[0]["PRODUCT_ADDL_TTA_NOTN"].ToString() + " - " + ds.Tables[2].Rows[0]["PRODUCT_ADDL_TTA_SLNO"].ToString() + ")  ";
                                            dt_column.Rows[17][col] = ADDL_TTA_Notn;
                                        }

                                        string HEALTH_CESS_Notn = "";
                                        if (ds.Tables[2].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_NOTN"].ToString() != "")
                                        {
                                            HEALTH_CESS_Notn = "(" + ds.Tables[2].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_NOTN"].ToString() + " - " + ds.Tables[2].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_SLNO"].ToString() + ")  ";
                                            dt_column.Rows[18][col] = HEALTH_CESS_Notn;
                                        }

                                        string CESS_Notn = "";
                                        if (ds.Tables[2].Rows[0]["PRODUCT_CESS_NOTN"].ToString() != "")
                                        {
                                            CESS_Notn = "(" + ds.Tables[2].Rows[0]["PRODUCT_CESS_NOTN"].ToString() + " - " + ds.Tables[2].Rows[0]["PRODUCT_CESS_SLNO"].ToString() + ")  ";
                                            dt_column.Rows[19][col] = CESS_Notn;
                                        }

                                        string ANTI_DUMPING_Notn = "";
                                        if (ds.Tables[2].Rows[0]["ANTI_DUMPING_NOTN"].ToString() != "")
                                        {
                                            ANTI_DUMPING_Notn = "(" + ds.Tables[2].Rows[0]["ANTI_DUMPING_NOTN"].ToString() + " - " + ds.Tables[2].Rows[0]["ANTI_DUMPING_NOTN_SLNO"].ToString() + ")  ";
                                            dt_column.Rows[20][col] = ANTI_DUMPING_Notn;
                                        }
                                        dt_column.Rows[21][0]=("____________");
                                    }

                        #endregion Third_Part


                                    Final_Value = BCD + CVD + CEC + CHEC + ADD_Duty;
                                    dt_column.Rows[MAX_ROW + 21][col] = Final_Value;
                                   
                                    dt_column.Rows[MAX_ROW + 1][dt_column.Columns.Count - 1] = Tot_Item_Amount;
                                    dt_column.Rows[MAX_ROW + 2][dt_column.Columns.Count - 1] = Tot_Actual_Misc;

                                    dt_column.Rows[MAX_ROW + 3][dt_column.Columns.Count - 1] = Tot_FOB;
                                    dt_column.Rows[MAX_ROW + 4][dt_column.Columns.Count - 1] = Tot_FOB_in_RS;
                                   
                                    dt_column.Rows[MAX_ROW + 5][dt_column.Columns.Count - 1] = Tot_Actual_Frt;
                                    dt_column.Rows[MAX_ROW + 6][dt_column.Columns.Count - 1] = Tot_Actual_Ins;
                                    dt_column.Rows[MAX_ROW + 7][dt_column.Columns.Count - 1] = Tot_Actual_HSS;

                                    dt_column.Rows[MAX_ROW + 9][dt_column.Columns.Count - 1] = Tot_CIF;
                                    dt_column.Rows[MAX_ROW + 10][dt_column.Columns.Count - 1] = Tot_Handling;
                                    dt_column.Rows[MAX_ROW + 11][dt_column.Columns.Count - 1] = Tot_Ass_Val;
                                    dt_column.Rows[MAX_ROW + 13][dt_column.Columns.Count - 1] = Rund_Tot_Ass_Val;
                                    dt_column.Rows[MAX_ROW + 14][dt_column.Columns.Count - 1] = Tot_Qty;

                                    dt_column.Rows[MAX_ROW + 16][dt_column.Columns.Count - 1] = Tot_BCD;
                                    dt_column.Rows[MAX_ROW + 17][dt_column.Columns.Count - 1] = Tot_CVD;
                                    dt_column.Rows[MAX_ROW + 18][dt_column.Columns.Count - 1] = Tot_CEC;
                                    dt_column.Rows[MAX_ROW + 19][dt_column.Columns.Count - 1] = Tot_CHEC;
                                    dt_column.Rows[MAX_ROW + 20][dt_column.Columns.Count - 1] = Tot_ADD_Duty;

                                    Final_Value = Tot_BCD + Tot_CVD + Tot_CEC + Tot_CHEC + Tot_ADD_Duty;

                                    dt_column.Rows[MAX_ROW + 21][dt_column.Columns.Count - 1] = Final_Value;
                                   
                                    double Rounded_FinalValue=Math.Round(Final_Value, 0);
                                    ViewState["Rounded_FinalValue"] = Rounded_FinalValue;
                                    col = col + 1;
                                }
                            }
                        }
                    }

                    #region Header_Part
                    string RITC = "";
                    if (dt_column.Columns.Count > 0)
                    {
                        for (int x = 0; x <= dt_column.Columns.Count - 1; x++)
                        {
                            RITC = dt_column.Rows[1][x].ToString();

                            if (RITC == "RITC NO" || RITC == "CTH NO" || RITC == "CETH NO")
                            {

                                //dt_column.Rows[MAX_ROW + 1][0] = "FOB in USD";
                                //dt_column.Rows[MAX_ROW + 2][0] = "FOB in RS";     
                                dt_column.Rows[MAX_ROW + 2][0] = "Other Charges";
                                dt_column.Rows[MAX_ROW + 5][0] = "Freight @ Actual";
                                dt_column.Rows[MAX_ROW + 6][0] = "Insurance @ Actual";
                                dt_column.Rows[MAX_ROW + 7][0] = "HSS Value";
                                dt_column.Rows[MAX_ROW + 8][0] = ("____________");
                                dt_column.Rows[MAX_ROW + 9][0] = "CIF Value";
                                dt_column.Rows[MAX_ROW + 10][0] = "Handling";
                                dt_column.Rows[MAX_ROW + 11][0] = "Assesable Value";
                                //dt_column.Rows[MAX_ROW + 12][0] = ("_____________");
                                dt_column.Rows[MAX_ROW + 13][0] = "Assesable Rounded";
                                dt_column.Rows[MAX_ROW + 14][0] = "Quantity";
                                dt_column.Rows[MAX_ROW + 15][0] = "Rate of Duty";
                                //dt_column.Rows[MAX_ROW + 14][0] = ("_____________");
                                dt_column.Rows[MAX_ROW + 16][0] = "Basic Duty";
                                dt_column.Rows[MAX_ROW + 17][0] = "Excise Duty";
                                dt_column.Rows[MAX_ROW + 18][0] = "CESS Duty @2%";
                                dt_column.Rows[MAX_ROW + 19][0] = "Cus Sec.Cess @1%";
                                dt_column.Rows[MAX_ROW + 20][0] = "Special Duty";
                                //dt_column.Rows[MAX_ROW + 20][0] = ("_____________");
                                dt_column.Rows[MAX_ROW + 21][0] = "TOTAL DUTY";
                                //dt_column.Rows[MAX_ROW + 22][0] = ("_____________");

                            }
                        }
                    }

                    DataTable final = new DataTable();
                    final.Columns.Add("ID");
                    final.Columns.Add("JOBNO");
                    final.Columns.Add("HEADER");
                    final.Columns.Add("RITC1");
                    final.Columns.Add("RITC2");
                    final.Columns.Add("RITC3");
                    final.Columns.Add("RITC4");
                    final.Columns.Add("RITC5");
                    final.Columns.Add("RITC6");
                    final.Columns.Add("RITC7");
                    final.Columns.Add("FinalTotal");

                    DataTable final_dt = new DataTable();
                    final_dt.Columns.Add("ID");
                    final_dt.Columns.Add("JOBNO");
                    final_dt.Columns.Add("HEADER");
                    final_dt.Columns.Add("RITC1");
                    final_dt.Columns.Add("RITC2");
                    final_dt.Columns.Add("RITC3");
                    final_dt.Columns.Add("RITC4");
                    final_dt.Columns.Add("RITC5");
                    final_dt.Columns.Add("RITC6");
                    final_dt.Columns.Add("RITC7");
                    final_dt.Columns.Add("FinalTotal");

                    #endregion Header_Part

                    int col_count = dt_column.Columns.Count;
                    int row_count = dt_column.Rows.Count;
                    int ccc = 7;
                    int d = 0;
                    int k = 0;
                    int id = 0;
                    for (int i = 0; i <= row_count - 1; i++)
                    {
                        final_dt.Rows.Add();
                    }

                    if (col_count <= 7)
                    {
                        int x = 2;
                        for (int i = 0; i <= col_count - 1; i++)
                        {

                            for (int j = 0; j <= dt_column.Rows.Count - 1; j++)
                            {
                                final_dt.Rows[j][x] = dt_column.Rows[j][i];
                            }
                            x++;
                        }
                        final_dt = final_dt.Rows.Cast<DataRow>().Where(row2 => !row2.ItemArray.All(field => field is System.DBNull || string.Compare((field as string).Trim(), string.Empty) == 0)).CopyToDataTable();

                        for (int i = 0; i <= final_dt.Rows.Count - 1; i++)
                        {
                            final_dt.Rows[i][0] = i + 1;
                            final_dt.Rows[i][1] = ddlJobNo;
                        }
                        if (final_dt.Rows.Count > 0)
                        {
                            final.Merge(final_dt);
                            //admin.SqlBulk_Upload_Product("WorkSheet_Details", final_dt, HttpContext.Current.Session["currentcomp_db"].ToString());
                        }
                    }
                    else
                    {
                        int aa = 0;
                        int x = 2;
                        int kc = 0;

                        for (k = d; k <= ccc; k++)
                        {
                            if (kc == 1)
                            {
                                aa = col_count;
                                int ff = dt_column.Columns.Count - col_count;
                                for (int i = 0; i <= aa - 1; i++)
                                {

                                    for (int j = 0; j <= dt_column.Rows.Count - 1; j++)
                                    {
                                        final_dt.Rows[j][x] = dt_column.Rows[j][ff];

                                    }
                                    ff++;
                                    x++;
                                }
                            }
                            else if (kc == 2)
                            {
                                for (int i = d; i <= ccc-1; i++)
                                {
                                    for (int j = 0; j <= dt_column.Rows.Count - 1; j++)
                                    {
                                        final_dt.Rows[j][x] = dt_column.Rows[j][aa];
                                    }
                                    x++;
                                    aa++;
                                }
                            }
                            else
                            {
                                for (int i = d; i <= ccc; i++)
                                {
                                    for (int j = 0; j <= dt_column.Rows.Count - 1; j++)
                                    {
                                        final_dt.Rows[j][x] = dt_column.Rows[j][aa];
                                    }
                                    x++;
                                    aa++;
                                }
                            }

                            #region Notn_Header
                            int vv = 9;
                            for (int j = 1; j <= vv; j++)
                            {
                                string AddlDuty_Notn = final_dt.Rows[6][j].ToString();
                                string C_Edu_cess_Notn = final_dt.Rows[7][j].ToString();
                                string C_Sec_Edu_cess_Notn = final_dt.Rows[8][j].ToString();
                                string C_NCD_Notn = final_dt.Rows[9][j].ToString();
                                string C_AGGREGATE_Notn = final_dt.Rows[10][j].ToString();
                                string C_SAFEGUARD_Notn = final_dt.Rows[11][j].ToString();
                                string C_SAPTA_Notn = final_dt.Rows[12][j].ToString();
                                string C_TARIFF_Notn = final_dt.Rows[13][j].ToString();
                                string C_ADDL5_SIA_Notn = final_dt.Rows[14][j].ToString();
                                string C_ADDL_GSI_Notn = final_dt.Rows[15][j].ToString();
                                string C_ADDL_SHEII_Notn = final_dt.Rows[16][j].ToString();
                                string C_ADDL_TTA_Notn = final_dt.Rows[17][j].ToString();
                                string C_HEALTH_CESS_Notn = final_dt.Rows[18][j].ToString();
                                string C_CESS_Notn = final_dt.Rows[19][j].ToString();
                                string C_ANTI_DUMPING_Notn = final_dt.Rows[20][j].ToString();

 
                                if (AddlDuty_Notn != string.Empty)
                                {
                                    final_dt.Rows[6][2] = "AddlDuty Notn";
                                }
                                if (C_Edu_cess_Notn != string.Empty)
                                {
                                    final_dt.Rows[7][2] = "Edu.Cess Notn";
                                }
                                if (C_Sec_Edu_cess_Notn != string.Empty)
                                {
                                    final_dt.Rows[8][2] = "Sec.Edu.Cess Notn";
                                }
                                if (C_NCD_Notn != string.Empty)
                                {
                                    final_dt.Rows[9][2] = "NCD Notn";
                                }
                                if (C_AGGREGATE_Notn != string.Empty)
                                {
                                    final_dt.Rows[10][2] = "AGGREGATE Notn";
                                }
                                if (C_SAFEGUARD_Notn != string.Empty)
                                {
                                    final_dt.Rows[11][2] = "SAFEGUARD Notn";
                                }
                                if (C_SAPTA_Notn != string.Empty)
                                {
                                    final_dt.Rows[12][2] = "SAPTA Notn";
                                }
                                if (C_TARIFF_Notn != string.Empty)
                                {
                                    final_dt.Rows[13][2] = "TARIFF Notn";
                                }
                                if (C_ADDL5_SIA_Notn != string.Empty)
                                {
                                    final_dt.Rows[14][2] = "Addl.Duty(Sub-Sec)";
                                }
                                if (C_ADDL_GSI_Notn != string.Empty)
                                {
                                    final_dt.Rows[15][2] = "AddlDuty Excise(SIA)";
                                }
                                if (C_ADDL_SHEII_Notn != string.Empty)
                                {
                                    final_dt.Rows[16][2] = "Spl.Ex.Duty(Sched-11)";
                                }
                                if (C_ADDL_TTA_Notn != string.Empty)
                                {
                                    final_dt.Rows[17][2] = "AddlDuty Excise(TTA)";
                                }
                                if (C_HEALTH_CESS_Notn != string.Empty)
                                {
                                    final_dt.Rows[18][2] = "HealthCess Notn";
                                }
                                if (C_CESS_Notn != string.Empty)
                                {
                                    final_dt.Rows[19][2] = "Cess Notn";
                                }
                                if (C_ANTI_DUMPING_Notn != string.Empty)
                                {
                                    final_dt.Rows[20][2] = "AntiDumpting Notn";
                                }
                            }
                            #endregion Notn_Header

                            final_dt = final_dt.Rows.Cast<DataRow>().Where(row2 => !row2.ItemArray.All(field => field is System.DBNull || string.Compare((field as string).Trim(), string.Empty) == 0)).CopyToDataTable();

                            for (int i = 0; i <= final_dt.Rows.Count - 1; i++)
                            {
                                final_dt.Rows[i][0] = id + 1;
                                id = id + 1;
                            }
                            for (int i = 0; i <= final_dt.Rows.Count - 1; i++)
                            {

                                final_dt.Rows[i][1] = ddlJobNo;
                            }
                            if (final_dt.Rows.Count > 0)
                            {
                                final.Merge(final_dt);
                                //admin.SqlBulk_Upload_Product("WorkSheet_Details", final_dt, HttpContext.Current.Session["currentcomp_db"].ToString());
                            }
                            final_dt.Rows.Clear();
                            for (int i = 0; i <= row_count - 1; i++)
                            {
                                final_dt.Rows.Add();
                                final_dt.Rows[i][2] = dt_column.Rows[i][0];
                            }
                            d = aa;
                            ccc += 7;
                            x = 3;

                            col_count = col_count - 7;
                            if (col_count < 7)
                            {
                                if (kc == 1 || kc == 2)
                                {
                                    break;
                                }
                                else
                                {
                                    kc = 1;
                                }
                            }
                            else if (col_count == 7)
                            {
                                //col_count = col_count;
                                kc = 2;
                            }
                            else
                            {
                            }
                        }
                    }
                   
                    ReportDataSource dataSS = new ReportDataSource("DutyWorkSheet_DataSet", final);
                    ReportViewer1.LocalReport.DataSources.Add(dataSS);
                                       
                    ReportParameter FileRef = new ReportParameter("FILEREF_NO", ViewState["FILEREF_NO"].ToString());
                    ReportParameter JobNo = new ReportParameter("JOBNO", ViewState["JOBNO"].ToString());
                    ReportParameter ExRate = new ReportParameter("ExRate", "ExRate: " + ds.Tables[1].Rows[0]["INVOICE_EXRATE"].ToString() + " (" + ds.Tables[1].Rows[0]["INVOICE_CURRENCY"].ToString() + ")");
                    ReportParameter RoundedValue = new ReportParameter("RoundedValue", ViewState["Rounded_FinalValue"].ToString());

                    ReportParameter[] p = { FileRef, JobNo, ExRate, RoundedValue };

                    ReportViewer1.LocalReport.SetParameters(p);

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
                }
            } 
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }     
    }
   
    public void Get_FILE_REF_NO()
    {
        ViewState["FILEREF_NO"] = "";
        WorkSht.JOBNO = ddlJobNo;
        WorkSht.BRANCHCODE = SELECT_BRANCH;
        WorkSht.flag = "select_FILEREF_NO";
        dss = WorkSht.RetrieveAll_IMPORT_WORKSHEET_REPORT();
        if (dss.Tables[0].Rows.Count > 0)
        {
            ViewState["FILEREF_NO"] = dss.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
            ViewState["JOBNO"] = dss.Tables[0].Rows[0]["JOBNO_PS"].ToString();

        }
    }

     public void Retreive_All_RITC_Details(DataSet ds1, int x, string flag)
    {
        string RITC = "", PRODUCT_CTH = "", SCHEME_CODE = "", SCHEME_NOTN = "", SCHEME_NOTN_SLNO = "", PRODUCT_BCD_NOTN = "", PRODUCT_BCD_SLNO = "";
        string CTH_QTY1 = "", CTH_QTY1_CODE = "", PRODUCT_ADDL_DUTY_NOTN = "", PRODUCT_ADDL_DUTY_NOTN_SL = "", PRODUCT_EDU_CESS_NOTN = "", PRODUCT_EDU_CESS_NOTN_SL = "", PRODUCT_SEC_EDU_CESS_NOTN = "", PRODUCT_SEC_EDU_CESS_NOTN_SL = "", PRODUCT_NCD_NOTN = "", PRODUCT_NCD_SLNO = "";
        string PRODUCT_AGGREGATE_DUTY_NOTN = "", PRODUCT_AGGREGATE_DUTY_NOTN_SL = "", PRODUCT_SAFEGUARD_NOTN = "", PRODUCT_SAFEGUARD_SLNO = "", PRODUCT_SAPTA_NOTN = "", PRODUCT_SAPTA_SLNO = "", PRODUCT_TARIFF_NOTN = "", PRODUCT_TARIFF_SLNO = "", PRODUCT_CETH = "", PRODUCT_MRP_YN = "";
        string PRODUCT_CVD_NOTN = "", PRODUCT_CVD_SLNO = "", PRODUCT_ADDL5_SIA_NOTN = "", PRODUCT_ADDL5_SIA_NOTN_SL = "", PRODUCT_ADDL_GSI_NOTN = "", PRODUCT_ADDL_GSI_SLNO = "", PRODUCT_ADDL_SHEII_NOTN = "", PRODUCT_ADDL_SHEII_SLNO = "", PRODUCT_ADDL_TTA_NOTN = "", PRODUCT_ADDL_TTA_SLNO = "";
        string PRODUCT_ADDL_HEALTH_CESS_NOTN = "", PRODUCT_ADDL_HEALTH_CESS_SLNO = "", PRODUCT_CESS_NOTN = "", PRODUCT_CESS_SLNO = "", ANTI_DUMPING_NOTN = "", ANTI_DUMPING_NOTN_SLNO = "", CTH_SLNO = "", CTH_SUPPLIER_SLNO = "", RSP_DUTY_STATUS = "", RSP_NOTN_NO = "", RSP_NOTN_SL_NO = "";
        string PRODUCT_OTHER_DUTY_NOTN = "", PRODUCT_OTHER_DUTY_SLNO = "", INFRA_CESS_NOTN = "", INFRA_CESS_NOTN_SL = "";


        int rw = 4;
        RITC = ds1.Tables[0].Rows[x]["PRODUCT_RITC"].ToString();
        PRODUCT_CTH = ds1.Tables[0].Rows[x]["PRODUCT_CTH"].ToString();
        SCHEME_CODE = ds1.Tables[0].Rows[x]["SCHEME_CODE"].ToString();
        SCHEME_NOTN = ds1.Tables[0].Rows[x]["SCHEME_NOTN"].ToString();
        SCHEME_NOTN_SLNO = ds1.Tables[0].Rows[x]["SCHEME_NOTN_SLNO"].ToString();
        PRODUCT_BCD_NOTN = ds1.Tables[0].Rows[x]["PRODUCT_BCD_NOTN"].ToString();
        PRODUCT_BCD_SLNO = ds1.Tables[0].Rows[x]["PRODUCT_BCD_SLNO"].ToString();

        CTH_QTY1 = ds1.Tables[0].Rows[x]["CTH_QTY1"].ToString();
        CTH_QTY1_CODE = ds1.Tables[0].Rows[x]["CTH_QTY1_CODE"].ToString();
        PRODUCT_ADDL_DUTY_NOTN = ds1.Tables[0].Rows[x]["PRODUCT_ADDL_DUTY_NOTN"].ToString();
        PRODUCT_ADDL_DUTY_NOTN_SL = ds1.Tables[0].Rows[x]["PRODUCT_ADDL_DUTY_NOTN_SL"].ToString();
        PRODUCT_EDU_CESS_NOTN = ds1.Tables[0].Rows[x]["PRODUCT_EDU_CESS_NOTN"].ToString();
        PRODUCT_EDU_CESS_NOTN_SL = ds1.Tables[0].Rows[x]["PRODUCT_EDU_CESS_NOTN_SL"].ToString();
        PRODUCT_SEC_EDU_CESS_NOTN = ds1.Tables[0].Rows[x]["PRODUCT_SEC_EDU_CESS_NOTN"].ToString();
        PRODUCT_SEC_EDU_CESS_NOTN_SL = ds1.Tables[0].Rows[x]["PRODUCT_SEC_EDU_CESS_NOTN_SL"].ToString();
        PRODUCT_NCD_NOTN = ds1.Tables[0].Rows[x]["PRODUCT_NCD_NOTN"].ToString();
        PRODUCT_NCD_SLNO = ds1.Tables[0].Rows[x]["PRODUCT_NCD_SLNO"].ToString();

        PRODUCT_AGGREGATE_DUTY_NOTN = ds1.Tables[0].Rows[x]["PRODUCT_AGGREGATE_DUTY_NOTN"].ToString();
        PRODUCT_AGGREGATE_DUTY_NOTN_SL = ds1.Tables[0].Rows[x]["PRODUCT_AGGREGATE_DUTY_NOTN_SL"].ToString();
        PRODUCT_SAFEGUARD_NOTN = ds1.Tables[0].Rows[x]["PRODUCT_SAFEGUARD_NOTN"].ToString();
        PRODUCT_SAFEGUARD_SLNO = ds1.Tables[0].Rows[x]["PRODUCT_SAFEGUARD_SLNO"].ToString();
        PRODUCT_SAPTA_NOTN = ds1.Tables[0].Rows[x]["PRODUCT_SAPTA_NOTN"].ToString();
        PRODUCT_SAPTA_SLNO = ds1.Tables[0].Rows[x]["PRODUCT_SAPTA_SLNO"].ToString();
        PRODUCT_TARIFF_NOTN = ds1.Tables[0].Rows[x]["PRODUCT_TARIFF_NOTN"].ToString();
        PRODUCT_TARIFF_SLNO = ds1.Tables[0].Rows[x]["PRODUCT_TARIFF_SLNO"].ToString();
        PRODUCT_CETH = ds1.Tables[0].Rows[x]["PRODUCT_CETH"].ToString();
        PRODUCT_MRP_YN = ds1.Tables[0].Rows[x]["PRODUCT_MRP_YN"].ToString();

        PRODUCT_CVD_NOTN = ds1.Tables[0].Rows[x]["PRODUCT_CVD_NOTN"].ToString();
        PRODUCT_CVD_SLNO = ds1.Tables[0].Rows[x]["PRODUCT_CVD_SLNO"].ToString();
        PRODUCT_ADDL5_SIA_NOTN = ds1.Tables[0].Rows[x]["PRODUCT_ADDL5_SIA_NOTN"].ToString();
        PRODUCT_ADDL5_SIA_NOTN_SL = ds1.Tables[0].Rows[x]["PRODUCT_ADDL5_SIA_NOTN_SL"].ToString();
        PRODUCT_ADDL_GSI_NOTN = ds1.Tables[0].Rows[x]["PRODUCT_ADDL_GSI_NOTN"].ToString();
        PRODUCT_ADDL_GSI_SLNO = ds1.Tables[0].Rows[x]["PRODUCT_ADDL_GSI_SLNO"].ToString();
        PRODUCT_ADDL_SHEII_NOTN = ds1.Tables[0].Rows[x]["PRODUCT_ADDL_SHEII_NOTN"].ToString();
        PRODUCT_ADDL_SHEII_SLNO = ds1.Tables[0].Rows[x]["PRODUCT_ADDL_SHEII_SLNO"].ToString();
        PRODUCT_ADDL_TTA_NOTN = ds1.Tables[0].Rows[x]["PRODUCT_ADDL_TTA_NOTN"].ToString();
        PRODUCT_ADDL_TTA_SLNO = ds1.Tables[0].Rows[x]["PRODUCT_ADDL_TTA_SLNO"].ToString();

        PRODUCT_ADDL_HEALTH_CESS_NOTN = ds1.Tables[0].Rows[x]["PRODUCT_ADDL_HEALTH_CESS_NOTN"].ToString();
        PRODUCT_ADDL_HEALTH_CESS_SLNO = ds1.Tables[0].Rows[x]["PRODUCT_ADDL_HEALTH_CESS_SLNO"].ToString();
        PRODUCT_CESS_NOTN = ds1.Tables[0].Rows[x]["PRODUCT_CESS_NOTN"].ToString();
        PRODUCT_CESS_SLNO = ds1.Tables[0].Rows[x]["PRODUCT_CESS_SLNO"].ToString();
        ANTI_DUMPING_NOTN = ds1.Tables[0].Rows[x]["ANTI_DUMPING_NOTN"].ToString();
        ANTI_DUMPING_NOTN_SLNO = ds1.Tables[0].Rows[x]["ANTI_DUMPING_NOTN_SLNO"].ToString();
        CTH_SLNO = ds1.Tables[0].Rows[x]["CTH_SLNO"].ToString();
        CTH_SUPPLIER_SLNO = ds1.Tables[0].Rows[x]["CTH_SUPPLIER_SLNO"].ToString();
        RSP_DUTY_STATUS = ds1.Tables[0].Rows[x]["RSP_DUTY_STATUS"].ToString();
        RSP_NOTN_NO = ds1.Tables[0].Rows[x]["RSP_NOTN_NO"].ToString();
        RSP_NOTN_SL_NO = ds1.Tables[0].Rows[x]["RSP_NOTN_SL_NO"].ToString();

        PRODUCT_OTHER_DUTY_NOTN = ds1.Tables[0].Rows[x]["PRODUCT_OTHER_DUTY_NOTN"].ToString();
        PRODUCT_OTHER_DUTY_SLNO = ds1.Tables[0].Rows[x]["PRODUCT_OTHER_DUTY_SLNO"].ToString();
        INFRA_CESS_NOTN = ds1.Tables[0].Rows[x]["INFRA_CESS_NOTN"].ToString();
        INFRA_CESS_NOTN_SL = ds1.Tables[0].Rows[x]["INFRA_CESS_NOTN_SL"].ToString();

        WorkSht.JOBNO = ddlJobNo;
        WorkSht.PRODUCT_RITC = RITC;
        WorkSht.PRODUCT_CTH = PRODUCT_CTH;
        WorkSht.SCHEME_CODE = SCHEME_CODE;
        WorkSht.SCHEME_NOTN = SCHEME_NOTN;
        WorkSht.SCHEME_NOTN_SLNO = SCHEME_NOTN_SLNO;
        WorkSht.PRODUCT_BCD_NOTN = PRODUCT_BCD_NOTN;
        WorkSht.PRODUCT_BCD_SLNO = PRODUCT_BCD_SLNO;

        WorkSht.CTH_QTY1 = CTH_QTY1;
        WorkSht.CTH_QTY1_CODE = CTH_QTY1_CODE;
        WorkSht.PRODUCT_ADDL_DUTY_NOTN = PRODUCT_ADDL_DUTY_NOTN;
        WorkSht.PRODUCT_ADDL_DUTY_NOTN_SL = PRODUCT_ADDL_DUTY_NOTN_SL;
        WorkSht.PRODUCT_EDU_CESS_NOTN = PRODUCT_EDU_CESS_NOTN;
        WorkSht.PRODUCT_EDU_CESS_NOTN_SL = PRODUCT_EDU_CESS_NOTN_SL;
        WorkSht.PRODUCT_SEC_EDU_CESS_NOTN = PRODUCT_SEC_EDU_CESS_NOTN;
        WorkSht.PRODUCT_SEC_EDU_CESS_NOTN_SL = PRODUCT_SEC_EDU_CESS_NOTN_SL;
        WorkSht.PRODUCT_NCD_NOTN = PRODUCT_NCD_NOTN;
        WorkSht.PRODUCT_NCD_SLNO = PRODUCT_NCD_SLNO;

        WorkSht.PRODUCT_AGGREGATE_DUTY_NOTN = PRODUCT_AGGREGATE_DUTY_NOTN;
        WorkSht.PRODUCT_AGGREGATE_DUTY_NOTN_SL = PRODUCT_AGGREGATE_DUTY_NOTN_SL;
        WorkSht.PRODUCT_SAFEGUARD_NOTN = PRODUCT_SAFEGUARD_NOTN;
        WorkSht.PRODUCT_SAFEGUARD_SLNO = PRODUCT_SAFEGUARD_SLNO;
        WorkSht.PRODUCT_SAPTA_NOTN = PRODUCT_SAPTA_NOTN;
        WorkSht.PRODUCT_SAPTA_SLNO = PRODUCT_SAPTA_SLNO;
        WorkSht.PRODUCT_TARIFF_NOTN = PRODUCT_TARIFF_NOTN;
        WorkSht.PRODUCT_TARIFF_SLNO = PRODUCT_TARIFF_SLNO;
        WorkSht.PRODUCT_CETH = PRODUCT_CETH;
        WorkSht.PRODUCT_MRP_YN = PRODUCT_MRP_YN;

        WorkSht.PRODUCT_CVD_NOTN = PRODUCT_CVD_NOTN;
        WorkSht.PRODUCT_CVD_SLNO = PRODUCT_CVD_SLNO;
        WorkSht.PRODUCT_ADDL5_SIA_NOTN = PRODUCT_ADDL5_SIA_NOTN;
        WorkSht.PRODUCT_ADDL5_SIA_NOTN_SL = PRODUCT_ADDL5_SIA_NOTN_SL;
        WorkSht.PRODUCT_ADDL_GSI_NOTN = PRODUCT_ADDL_GSI_NOTN;
        WorkSht.PRODUCT_ADDL_GSI_SLNO = PRODUCT_ADDL_GSI_SLNO;
        WorkSht.PRODUCT_ADDL_SHEII_NOTN = PRODUCT_ADDL_SHEII_NOTN;
        WorkSht.PRODUCT_ADDL_SHEII_SLNO = PRODUCT_ADDL_SHEII_SLNO;
        WorkSht.PRODUCT_ADDL_TTA_NOTN = PRODUCT_ADDL_TTA_NOTN;
        WorkSht.PRODUCT_ADDL_TTA_SLNO = PRODUCT_ADDL_TTA_SLNO;


        WorkSht.PRODUCT_ADDL_HEALTH_CESS_NOTN = PRODUCT_ADDL_HEALTH_CESS_NOTN;
        WorkSht.PRODUCT_ADDL_HEALTH_CESS_SLNO = PRODUCT_ADDL_HEALTH_CESS_SLNO;
        WorkSht.PRODUCT_CESS_NOTN = PRODUCT_CESS_NOTN;
        WorkSht.PRODUCT_CESS_SLNO = PRODUCT_CESS_SLNO;
        WorkSht.ANTI_DUMPING_NOTN = ANTI_DUMPING_NOTN;
        WorkSht.ANTI_DUMPING_NOTN_SLNO = ANTI_DUMPING_NOTN_SLNO;
        WorkSht.CTH_SLNO = CTH_SLNO;
        WorkSht.CTH_SUPPLIER_SLNO = CTH_SUPPLIER_SLNO;
        WorkSht.RSP_DUTY_STATUS = RSP_DUTY_STATUS;
        WorkSht.RSP_NOTN_NO = RSP_NOTN_NO;
        WorkSht.RSP_NOTN_SL_NO = RSP_NOTN_SL_NO;

        WorkSht.PRODUCT_OTHER_DUTY_NOTN = PRODUCT_OTHER_DUTY_NOTN;
        WorkSht.PRODUCT_OTHER_DUTY_SLNO = PRODUCT_OTHER_DUTY_SLNO;
        WorkSht.PRODUCT_CTH_INFRA_CESS_NOTN = INFRA_CESS_NOTN;
        WorkSht.PRODUCT_CTH_INFRA_CESS_NOTN_SLNO = INFRA_CESS_NOTN_SL;

        WorkSht.BRANCHCODE = SELECT_BRANCH;
        WorkSht.flag = flag;

        ds = WorkSht.RetrieveAll_IMPORT_WORKSHEET_REPORT();
    }

}




