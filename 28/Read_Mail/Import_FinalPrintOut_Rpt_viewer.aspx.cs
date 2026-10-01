using System.Collections;
using System.Collections.Generic;
using System.Text;
//using System.Text.RegularExpressions;
//using System.Diagnostics;
//using System.Data.SqlClient;

using System.IO;
//using Microsoft.ApplicationBlocks.Data;
//using System.ComponentModel;
//using System.Drawing.Printing;
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
////using AjaxControlToolkit;
//using Microsoft.ReportingServices.Rendering;
//using Microsoft.ReportingServices.Library;


public partial class Import_FinalPrintOut_Rpt_viewer : System.Web.UI.Page
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
    Undertaking_Form UF = new Undertaking_Form();

    WareHouseReportDetails wh = new WareHouseReportDetails();
    public string ccc; string i, j, k, l, m, n, itemqty, kkk, jjj, Attach_Folder, full, full_TR6;
    int kk, jj,rows=1;

    private string _Workingperiod, _INVOICE_ID, _REMAINING_QTY;
    public string INVOICE_ID { get { return _INVOICE_ID; } set { _INVOICE_ID = value; } }
    public string REMAINING_QTY { get { return _REMAINING_QTY; } set { _REMAINING_QTY = value; } }
 
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
   
    public string Workingperiod
    {
        get { return _Workingperiod; }
        set { _Workingperiod = value; }
    }

    public string currentuser, ddlJobNo;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate,testaddress;
    public string SELECT_TYPE, SELECT_BRANCH;
    
    CheckList CHKLIST = new CheckList();
    //Customer c = new Customer();
    Date_Time dt = new Date_Time();
    
    DataTable dtt = new DataTable();

    List<WareHouseReportDetails> Load_WareHouse_Inv_ItemDetails = new List<WareHouseReportDetails>();

    //List<NForm> NForm = new List<NForm>();
    List<NForm> Load_NForm_Details = new List<NForm>();

   
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
        working_period = HttpContext.Current.Session["WorkingPeriod"].ToString();
        LoginDate = HttpContext.Current.Session["LoginDate"].ToString();
            // commented for areawise implementation on 05-mar-2020
        /*
        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
                Attach_Folder = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() + "/" + "Attachments/");
            }
            else
            {
                SELECT_BRANCH = "";
                Attach_Folder = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + "Attachments/");
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }
*/

        SELECT_BRANCH = Connection.Get_Company_Type();
        SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();

        //Attach_Folder = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + Session["GroupName"].ToString() + "/" + "Attachments/");
		if (Request.QueryString["frompage"] == "" || Request.QueryString["frompage"] == null)
        {
            Attach_Folder = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + Session["GroupName"].ToString() + "/" + "Attachments/");
        }
        else if (Request.QueryString["frompage"] == "Esanchit")
        {
            Attach_Folder = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/Attachments/");
        }

       
        /*
        if (SELECT_TYPE == "Branchwise Job")
        {
            Attach_Folder = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() + "/" + "Attachments/");
        }
        else if (SELECT_TYPE == "Areawise Job")
        {
            Attach_Folder = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["GroupName"].ToString() + "/" + "Attachments/");
        }
        else
        {
            Attach_Folder = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + "Attachments/");
        }
        */
        //if (!IsPostBack)
        //{
            Page_loaItem_Details();    
        //}
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

                List<ReportParameter> paramList = new List<ReportParameter>(); this.ReportViewer1.LocalReport.SetParameters(paramList);
                ReportViewer1.LocalReport.DataSources.Clear();

                //Attach_Folder = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() + "/" + "Attachments/");
                //string filePath = Attach_Folder + "4309132.prn";
                string filePath = Attach_Folder + Request.QueryString["jobno"].ToString();

                string line;
                string[] new1;

                List<string> list = new List<string>();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        list.Add(line); // Add to list.
                        //Console.WriteLine(line); // Write to console.
                        //full += line + Environment.NewLine;

                        if (ddl_PrintType.SelectedItem.Text == "All Pages")
                        {
                            //full += line + "\n";
                            rows = 1;
                            int ii = 1;
                            string ff = line;

                            while ((line = reader.ReadLine()) != null)
                            {
                                ff = ff + line;
                                if (ii == 1)
                                {
                                    list.Add(ff);
                                    full_TR6 += ff + "\n";
                                    ii = 2;
                                }
                                else
                                {

                                    if (line.Contains("Indian Customs EDI System"))
                                    {
                                        if (rows >= 80)
                                        {
                                            rows = rows - 80;
                                        }
                                        else
                                        {
                                            rows = 80 - rows;
                                        }

                                        for (int i = 0; i <= rows; i++)
                                        {
                                            full_TR6 = full_TR6 + Environment.NewLine;
                                        }

                                        rows = 1;
                                    }


                                    if (line.Contains("(Treasury rule 92)"))
                                    {
                                        if (rows >= 80)
                                        {
                                            rows = rows - 80;
                                        }
                                        else
                                        {
                                            rows = 80 - rows;
                                        }

                                        for (int i = 0; i <= rows; i++)
                                        {
                                            full_TR6 = full_TR6 + Environment.NewLine;
                                        }

                                        //list.Add(line);
                                        //full_TR6 += line + "\n";

                                        rows = 1;
                                    }

                                    list.Add(line);
                                    full_TR6 += line + "\n";

                                }


                                rows++;
                            }
                            full = full_TR6;
                        }
                        else if (ddl_PrintType.SelectedItem.Text == "TR6 Challan")
                        {
                            if (line.Contains("(Treasury rule 92)"))
                            {
                                rows = 1;
                                int ii = 1;
                                string ff = line;
                                while ((line = reader.ReadLine()) != null)
                                {
                                    if (line.Contains("Indian Customs EDI System"))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        if (ii == 1)
                                        {
                                            list.Add(ff);
                                            full_TR6 += ff + "\n";
                                            ii = 2;
                                        }
                                        else
                                        {
                                            if (line.Contains("(Treasury rule 92)"))
                                            {
                                                if (rows >= 80)
                                                {
                                                    rows = rows - 80;
                                                }
                                                else
                                                {
                                                    rows = 80 - rows;
                                                }

                                                for (int i = 0; i <= rows; i++)
                                                {
                                                    full_TR6 = full_TR6 + Environment.NewLine;
                                                }

                                                rows = 1;
                                            }


                                            list.Add(line);
                                            full_TR6 += line + "\n";
                                        }
                                    }
                                    rows++;
                                }
                            }

                            full = full_TR6;
                        }



                        else if (ddl_PrintType.SelectedItem.Text == "BE Details")
                        {
                            rows = 1;
                            int ii = 1;
                            string ff = line;
                            while ((line = reader.ReadLine()) != null)
                            {

                                ff = ff + line;
                                if (line.Contains("(Treasury rule 92)"))
                                {
                                    kk = 1;
                                    break;
                                }
                                else
                                {
                                    if (ii == 1)
                                    {
                                        list.Add(ff);
                                        full_TR6 += ff + "\n";
                                        ii = 2;
                                    }
                                    else
                                    {
                                        if (line.Contains("Indian Customs EDI System"))
                                        {
                                            if (rows >= 80)
                                            {
                                                rows = rows - 80;
                                            }
                                            else
                                            {
                                                rows = 80 - rows;
                                            }

                                            for (int i = 0; i <= rows; i++)
                                            {
                                                full_TR6 = full_TR6 + Environment.NewLine;
                                            }

                                            rows = 1;
                                        }

                                        list.Add(line);
                                        full_TR6 += line + "\n";

                                    }
                                }
                                rows++;
                            }

                            full = full_TR6;

                        }


                        else if (ddl_PrintType.SelectedItem.Text == "Examination Order")
                        {
                            if (line.Contains("Examination Order"))
                            {
                                int ii = 1;
                                string ff = line;
                                while ((line = reader.ReadLine()) != null)
                                {

                                    if (ii == 1)
                                    {
                                        list.Add(ff);
                                        full_TR6 += ff + "\n";
                                        ii = 2;
                                    }
                                    else
                                    {
                                        list.Add(line);
                                        full_TR6 += line + "\n";
                                    }
                                }

                            }

                            full = full_TR6;

                        }
                        else
                        {
                        }

                        if (kk == 1)
                        {
                            break;
                        }
                    }
                }
            }
                                           

                    ReportParameter param = new ReportParameter("Title", full);

                    string ppp = Session["currentcomp_name"].ToString();

                    ReportParameter[] p = { param };
                    //ReportParameter[] p = { param, param1, param2, param3, param4, param5 };

                    ReportViewer1.LocalReport.SetParameters(p);
                //}

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
                //--------------------------------------To Print------------------------------------------------------------------------------------/

            //}
       
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
    }

    public void Load_Undertaking_Form_Details()
    {

        ReportDataSource dataSS = new ReportDataSource("IM_Undertaking_DataSet", UF.Load_UndertakingForm(ds.Tables[0]));
        ReportViewer1.LocalReport.DataSources.Add(dataSS);
    }


    protected void ddl_PrintType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_PrintType.SelectedItem.Text == "All Pages")
        {

        }
    }
}




