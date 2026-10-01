using System;
using System.Data;
using System.Configuration;
using System.Collections;
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
using System.Data.OleDb;
using System.Globalization;
using BussinessObject;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;
using Microsoft.Reporting.WebForms;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class Import_SignedBE_Job : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    Import_flatfile_reader Imp = new Import_flatfile_reader();
    adminmaster adm = new adminmaster();
    Svb_Relation SVR = new Svb_Relation();
    AdminMasterDetails admin = new AdminMasterDetails();
    DataSet ds_scheme = new DataSet();
    DataSet dss = new DataSet();
    DataTable ds_IGM = new DataTable();
    DataSet ds_INVITEM = new DataSet();
    DataTable ds_CONTAINER = new DataTable();
    DataTable ds_LICENSE = new DataTable();
    DataTable ds_REIMPORT = new DataTable();
    DataTable ds_SW_INFO = new DataTable();
    DataTable ds_SW_CTRL = new DataTable();
    DataTable ds_SW_STMT = new DataTable();
    DataTable ds_INVOICE = new DataTable();
    DataTable ds_ITEM = new DataTable();
    DataTable ds_BOND = new DataTable();
    DataTable ds_CERT = new DataTable();
    DataTable ds_SUP_DOC = new DataTable();
    DataSet data = new DataSet();
    DataTable dt_Imp = new DataTable();
    DataTable dt_IGM = new DataTable();
    DataTable dt_CONT = new DataTable();
    DataTable dt_REIMP = new DataTable();
    DataTable dt_SW_INFO = new DataTable();
    DataTable dt_SW_CTRL = new DataTable();
    DataTable dt_CONST = new DataTable();
    DataTable dt_PRODUCT = new DataTable();
    DataTable dt_SW_STMT = new DataTable();
    DataTable dt_INV = new DataTable();
    DataTable dt_ITEM = new DataTable();
    DataTable dt_BOND = new DataTable();
    DataTable dt_CERT = new DataTable();
    DataTable dt_LICNESE = new DataTable();
    DataTable dt_SUP_DOC = new DataTable();
    DataTable dt_Hss = new DataTable();
    DataTable dt_Sec = new DataTable();
    DataTable dt_Rsp = new DataTable();
    DataTable dt_Exchange = new DataTable();
    DataTable dt_Otherchrg = new DataTable();
    DataTable dt_Gst = new DataTable();
    DataTable dt_Igst = new DataTable();
    DataTable dt_Schm = new DataTable();
    Imp_Checklist IC = new Imp_Checklist();
    DataSet dt_All_Rates = new DataSet();
    DataSet ds_Gen = new DataSet();
    public int i;
    public int MAX_ID = 0;
    public string currentuser;
    public string currentbranch;
    public string Working_Period;
    public string SELECT_TYPE;
    public string txtJobNo = "", txtjobPS = "", JobNo = "", btn_cif_click;
    public string COMPANY_ID = "", JOBNO_PS = "";
    DateTime dateTime = DateTime.UtcNow.Date;   
    string alert = "";
    string Sec48 = "" ,Frt_Chk="", ProvAss="";
    public string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    string exrate_fromfile = "";
    public string errorFolder ="", logline ="", logFileName ="";
    public string folderName = "/Submission";
    public string scheme;
    string[] scheme_name = new string[2];
    public string LoginDate, IMPORT_JOBNO;

    public string formattedDate1 ="", formattedDate2 ="", formattedDate3 ="", formattedDate4 ="", formattedDate5="";

    DataSet Co_Po_St = new DataSet();
    DataSet Gen_Ms = new DataSet();
    Auto_Search Auto = new Auto_Search();    
    Imp_Checklist_Item_License Item_License = new Imp_Checklist_Item_License();
    DataSet ds = new DataSet();
    DataSet dsXML = new DataSet();
    DataTable dt = new DataTable();
    public string COMPANY_IDD, comp_ConnectionStr;

    public string _IGST_LEVY_TOTAL, _IGST_LEVY_TOTAL_DEBIT, _IGST_LEVY_COMPENSATION_CESS_TOTAL, _DUTY_TYPE = "", _ADDL_FLAG = "", ddlJobNo, Igm_DATE, _MIS_CHARGES_
    , SELECT_BRANCH, Check_Stmt = "", LICENSE_ID;

    public string A_AMOUNT = "", B_AMOUNT = "", C_AMOUNT = "", D_AMOUNT = "", E_AMOUNT = "",
                F_AMOUNT = "", G_AMOUNT = "", H_AMOUNT = "", I_AMOUNT = "", J_AMOUNT = "",
                K_AMOUNT = "", L_AMOUNT = "", M_AMOUNT = "", N_AMOUNT = "";
         
        

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        COMPANY_IDD = Session["COMPANY_ID"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        LoginDate = Session["LoginDate"].ToString();
      
        SELECT_BRANCH = Connection.Get_Company_Type();
        COMPANY_ID = Connection.COMPANYID();
        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Import_Excel");
        if (!Page.IsPostBack)
        {

        }
        
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Import Invoice', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Import Invoice', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void gv_Item_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }

    protected void gv_Item_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }


    protected void gv_Imp_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }

    protected void gv_Imp_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }

    protected void btn_upload_Click(object sender, EventArgs e)
    {
        try
        {
        string logFileName = fileuploadXML.FileName;
        if (File.Exists(errorFolder + logFileName))
        {
            DirectoryInfo dir = new DirectoryInfo(errorFolder);
            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }
            Get_File_Bulk_Upload();
            //Get_File();
        }
        else
        {
            DirectoryInfo dir = new DirectoryInfo(errorFolder);
            dir.Create();
            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }
            Get_File_Bulk_Upload();
            Alert_msg("File Uploaded Sucessfully", "btn_upload_Click");
            // Get_File();
        }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            Alert_msg("File Not Uploaded", "btn_upload_Click");
        }
    }


     public string AUTO_JOBNO()
    {
        Imp.BRANCH_CODE = Connection.Get_Company_Type();
        Imp.WORKING_PERIOD = Connection.WorkingPeriod();
        IMPORT_JOBNO = Convert.ToString(Imp.Retrieve_JobNO());
        return IMPORT_JOBNO;
    }

    public void JobNo_Prefix_Sufix()
    {
        string txtJobNo = Session["Jobno_Excel"].ToString();
        string txtjobPS = "";
        Admin_job_Prefix_Suffix JPS = new Admin_job_Prefix_Suffix();
        DataSet dats = new DataSet();
        JPS.Branch = SELECT_BRANCH;
        JPS.Ename = "Imp_gen_select";
        JPS.Tr_mode = "Air";
        dats = JPS.Job_prefix_Suffix_Select();
        int Jno = 0;
        string JobNo = string.Empty;
        JobNo = txtJobNo;

        if (JobNo != string.Empty)
        {
            Jno = Convert.ToInt32(JobNo);
            if (Jno < 1000)
            {
                if (Jno > 100)
                {
                    JobNo = "00" + txtJobNo;
                }
                else if (Jno > 10)
                {
                    JobNo = "000" + txtJobNo;
                }
                else
                {
                    JobNo = "0000" + txtJobNo;
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
                        txtjobPS = txtJobNo + "/" + ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                        hdprefix.Value = string.Empty;
                        hdsuffix.Value = ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                    {
                        txtjobPS = ((dats.Tables[0].Rows[0][0].ToString() + txtJobNo).TrimEnd()).TrimStart();
                        //txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + JobNo).TrimEnd()).TrimStart();
                        hdprefix.Value = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                        hdsuffix.Value = string.Empty;
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                    {
                        txtjobPS = ((dats.Tables[0].Rows[0][0].ToString() + txtJobNo + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                        //txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + JobNo + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                        hdprefix.Value = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                        hdsuffix.Value = ((dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                    {
                        txtjobPS = txtJobNo;
                        hdprefix.Value = string.Empty;
                        hdsuffix.Value = string.Empty;
                    }
                }
                else
                {
                    txtjobPS = txtJobNo;
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
                        txtjobPS = txtJobNo + "/" + ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                        hdprefix.Value = string.Empty;
                        hdsuffix.Value = ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                    {
                        //txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + "/" + txtJobNo.Text).TrimEnd()).TrimStart();
                        if (Connection.COMPANYID() == "1163" || Connection.COMPANYID() == "1164" || Connection.COMPANYID() == "1165" || Connection.COMPANYID() == "1166")
                        {
                            txtjobPS = ((dats.Tables[0].Rows[0][0].ToString() + "/" + JobNo).TrimEnd()).TrimStart();
                        }
                        else
                        {
                            txtjobPS = ((dats.Tables[0].Rows[0][0].ToString() + "/" + txtJobNo).TrimEnd()).TrimStart();
                        }
                        hdprefix.Value = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                        hdsuffix.Value = string.Empty;
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                    {
                        // txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + "/" + txtJobNo.Text + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                        if (Connection.COMPANYID() == "1163" || Connection.COMPANYID() == "1164" || Connection.COMPANYID() == "1165" || Connection.COMPANYID() == "1166")
                        {
                            txtjobPS = ((dats.Tables[0].Rows[0][0].ToString() + "/" + JobNo + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                        }
                        else
                        {
                            txtjobPS = ((dats.Tables[0].Rows[0][0].ToString() + "/" + txtJobNo + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                        }

                        hdprefix.Value = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                        hdsuffix.Value = ((dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                    {
                        txtjobPS = txtJobNo;
                        hdprefix.Value = string.Empty;
                        hdsuffix.Value = string.Empty;
                    }
                }
                else
                {
                    txtjobPS = txtJobNo;
                    hdprefix.Value = string.Empty;
                    hdsuffix.Value = string.Empty;
                }
            }
        }
    }


    public void  Get_File_Bulk_Upload()
    {
        DataSet ds = new DataSet();
        string cur_date = DateTime.Now.ToString("dd/MM/yyyy");
        string strFileType = Path.GetExtension(fileuploadXML.FileName).ToLower();
        string path = errorFolder + "\\" + fileuploadXML.FileName;
         string Cus_House="";
        string fileName2;
        string Country_Orgin = ""; string Port_Orgin = ""; string State_Code ="", item_country ="", Schem_code="", Ritc="";
        string INVOICE_SLNO ="", ITEM_SLNO = "",LICENSE_ID="";
        int i = 0, result = 0;
        if (fileuploadXML.HasFile)
        {
            
            fileName2 = fileuploadXML.FileName;
            addtoGallery1(fileName2, errorFolder, "NORMAL");

            char ch = Convert.ToChar(29);

            string fileText = System.IO.File.ReadAllText(path);
            
            fileText = fileText.Replace(ch, '^');

            System.IO.File.WriteAllText(path, fileText);

            int IMP_INV_ID = 0, IMP_ITEM_ID = 0, IMP_IGM_ID = 0, IMP_BOND_ID = 0, CERTID = 0, CON_ID = 0, LIC_ID = 0, REIMP_ID=0,SW_IFNO_ID=0,
                SW_CONTL_ID=0,SW_CONT_ID=0,SW_PRODUCT_ID=0,SW_STATE_ID=0,SUP_DOC_ID=0;

            DataSet dataSet = new DataSet();
            // *******************start reading from singed be copy ***************************//

            ////************************* Start Imp Genaral Details ***********************************//  

            string[] lines = File.ReadAllLines(path);

            Imp.BRANCH_CODE = Connection.Get_Company_Type();
            Imp.WORKING_PERIOD = Connection.WorkingPeriod();
            DataSet DsAutoid = Imp.Retrieve_Import_Flatfile_JobNO();

            if (DsAutoid.Tables.Count > 0)
            {

                IMP_INV_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["IMP_INV_ID"].ToString());
                IMP_ITEM_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["IMP_ITEM_ID"].ToString());
                IMP_IGM_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["IMP_IGM_ID"].ToString());
                IMP_BOND_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["IMP_BOND_ID"].ToString());
                CERTID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["CERTID"].ToString());
                CON_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["CON_ID"].ToString());
                LIC_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["LIC_ID"].ToString());
                REIMP_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["REIMP_ID"].ToString());
                SW_IFNO_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["SW_IFNO_ID"].ToString());
                SW_CONTL_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["SW_CONTL_ID"].ToString());
                SW_CONT_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["SW_CONT_ID"].ToString());
                SW_PRODUCT_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["SW_PRODUCT_ID"].ToString());
                SW_STATE_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["SW_STATE_ID"].ToString());
                SUP_DOC_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["SUP_DOC_ID"].ToString());
            }


            int pos = 0;
           
            string[] lnItm_sec;
            int ln_sec;
            ///****************************** start sec48,1stcheck pro Details ************************/////
            //for (ln_sec = 0; ln_sec < lines.Length; ln_sec++)
            //{
            
            pos = Array.IndexOf(lines, "<TABLE>PERMISSION");

            if (pos == 5)
            {
                #region dt_sec
                ln_sec = 1;

                for (ln_sec = ln_sec; ln_sec < lines.Length - 1; ln_sec++)
                {
                if ((!(lines[ln_sec].ToString().Contains("<TABLE>"))) && (!(lines[ln_sec].ToString().Contains("<END-BE>"))))
                {
                    lnItm_sec = lines[ln_sec].ToString().Split('^');
                    if (lnItm_sec.Length >= 7)
                    {
                        if (lnItm_sec[6].ToString() == "S48")
                        {
                            Sec48 = lnItm_sec[7].ToString();
                        }
                        else if(lnItm_sec[6].ToString() == "FCK")
                        {
                            Frt_Chk = lnItm_sec[7].ToString();
                        }
                        else if(lnItm_sec[6].ToString() == "PRV")
                        {
                            ProvAss = lnItm_sec[7].ToString();
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                }

                #endregion dt_sec

                //pos = ln_sec + 1;
                //break;
            }

            // }

            ///// ******************* end of sec48,1stcheck pro details *******************///////////////////


            //  for (int ln = 0; ln < lines.Length; ln++)
            //{
            int lns = 0;
                string[] lnItms;
                pos = Array.IndexOf(lines, "<TABLE>CTX");

                if (pos > 0)
                {
                    #region dt_Gst
                    dt_Gst.Columns.Add("COMMERCIAL_TAX_STATECODE"); dt_Gst.Columns.Add("COMMERCIAL_TAX_TYPE"); dt_Gst.Columns.Add("COMMERCIAL_TAX_REGISTRATION_NO"); 

                    lns = pos + 1;
                        if ((!(lines[lns].ToString().Contains("<TABLE>"))) && (!(lines[lns].ToString().Contains("<END-BE>"))))
                        {
                            lnItms = lines[lns].ToString().Split('^');
                            if (lnItms.Length >= 7)
                            {
                                dt_Gst.Rows.Add(lnItms[6].ToString(), lnItms[7].ToString(), lnItms[8].ToString());
                            }
                        }                      
                    #endregion dt_Gst
                }

            //}
                //****************************** starts Hss Details ************************/////
                //for (int ln = 0; ln < lines.Length; ln++)
                //{
                    string[] lnItm_hs;
                    int ln_s = 0;
                    pos = Array.IndexOf(lines, "<TABLE>HSS");

                    if ( pos > 0)
                    {

                        #region dt_Hss
                        dt_Hss.Columns.Add("HIGH_SEA_SALE_NAME"); dt_Hss.Columns.Add("HIGH_SEA_IEC"); dt_Hss.Columns.Add("HIGH_SEA_BRANCH_SL_NO"); dt_Hss.Columns.Add("HSS_ADD1");
                        dt_Hss.Columns.Add("HSS_ADD2"); dt_Hss.Columns.Add("HSS_ADD3"); dt_Hss.Columns.Add("HSS_ADD4"); dt_Hss.Columns.Add("HSS_ADD5"); dt_Hss.Columns.Add("PRECEDING_LEVEL");

                        ln_s = pos + 1;

                        //for (ln_s = ln_s; ln_s < lines.Length - 1; ln_s++)
                        //{
                            if ((!(lines[ln_s].ToString().Contains("<TABLE>"))) && (!(lines[ln_s].ToString().Contains("<END-BE>"))))
                            {

                                lnItm_hs = lines[ln_s].ToString().Split('^');
                                if (lnItm_hs.Length >= 10)
                                {
                                    dt_Hss.Rows.Add(lnItm_hs[8].ToString(), lnItm_hs[6].ToString(), lnItm_hs[7].ToString(), lnItm_hs[9].ToString(), lnItm_hs[10].ToString(), lnItm_hs[11].ToString(),
                                   "", lnItm_hs[12].ToString(), lnItm_hs[13].ToString());
                                }
                            }
                            
                        //}

                        #endregion dt_Hss

                        //pos = ln_s + 1;
                        //break;
                    }

               // }

                ///// ******************* end of Hss details *******************///////////////////

         
            pos=0;
            for (int ln = 0; ln < lines.Length; ln++)
            {
                pos = Array.IndexOf(lines, "<TABLE>BE");
                if (pos > 0)
                {
                    ln = pos + 1;

                    string[] lnItm = lines[ln].ToString().Split('^');
                    if (lnItm.Length > 40)
                    {
                        #region ImpGeneral
                        txtJobNo = AUTO_JOBNO();
                        Imp.JOBID = "";
                        Imp.JOBNO = txtJobNo;
                        Imp.JOBDATE = lnItm[3].ToString().Substring(6, 2) + "/" + lnItm[3].ToString().Substring(4, 2) + "/" + lnItm[3].ToString().Substring(0, 4);//"";
                       if(lnItm[6].ToString()=="H")
                       {
                           Imp.BE_TYPE = "Home"; 
                       }
                       else if (lnItm[6].ToString() == "W")
                       {
                           Imp.BE_TYPE = "Warehouse"; 
                       }
                       else if (lnItm[6].ToString() == "X")
                       {
                           Imp.BE_TYPE = "Ex-Bond"; 
                       }
                       else if (lnItm[6].ToString() == "Z")
                       {
                           Imp.BE_TYPE = "SEZ FTA-Z";                           
                       }
                       else if (lnItm[6].ToString() == "T")
                       {
                           Imp.BE_TYPE = "SEZ DTA-T";                         
                       }
                       else if (lnItm[6].ToString() == "M")
                       {
                           Imp.BE_TYPE = "SEZ DTA-M";                           
                       }
                       else if (lnItm[6].ToString() == "J")
                       {
                           Imp.BE_TYPE = "Jobbing";                           
                       }
                       else if (lnItm[6].ToString() == "R")
                       {
                           Imp.BE_TYPE = "Repair & Return";                           
                       }
                       else if (lnItm[6].ToString() == "E")
                       {
                           Imp.BE_TYPE = "Exhibition"; 
                       }
                       else if (lnItm[6].ToString() == "D")
                       {
                           Imp.BE_TYPE = "Destruction";   
                       }
                       else if (lnItm[6].ToString() == "V")
                       {
                           Imp.BE_TYPE = "Movement of Goods"; 
                       }
                       else if (lnItm[6].ToString() == "S")
                       {
                           Imp.BE_TYPE = "Stock Item";
                       }
                        
                        Imp.CUSTOMS_HOUSE = lnItm[1].ToString();

                        DataSet CUSTOMS_HOUSE = new DataSet();
                        CUSTOMS_HOUSE = Imp.Retrieve_Custom_House_details();
                        Cus_House=CUSTOMS_HOUSE.Tables[0].Rows[0]["Transport_Mode"].ToString();
                        Session["TRANSPORT_MODE"] = Cus_House;
                        if (CUSTOMS_HOUSE.Tables[0].Rows.Count > 0)
                        {
                            Imp.TRANSPORT_MODE = Cus_House;
                        }
                        Imp.CUSTOMS_HOUSE_NAME = lnItm[1].ToString();
                        Imp.IMPORTER_NAME = lnItm[9].ToString();
                        Imp.ADDRESS1 = lnItm[10].ToString();
                        Imp.ADDRESS2 = lnItm[11].ToString();
                        Imp.ADDRESS3 = lnItm[12].ToString();
                        Imp.ADDRESS4 = lnItm[13].ToString();
                        Imp.ADDRESS5 = lnItm[14].ToString();
                        Imp.IEC_NO = lnItm[7].ToString();
                        Imp.BRANCH_NO = lnItm[8].ToString();
                        Imp.COUNTRY_ORIGIN = lnItm[22].ToString();
                        Country_Orgin = Country_Orgin + "~" + lnItm[22].ToString();
                        Imp.PORT_ORIGIN = lnItm[20].ToString();
                        Port_Orgin = Port_Orgin + "~" + lnItm[20].ToString();
                        Imp.PORT_SHIPMENT = lnItm[24].ToString();
                        Imp.COUNTRY_SHIPMENT = lnItm[23].ToString();

                        if (lnItm[27].ToString()=="N")
                        {
                            Imp.FILING_STATUS="Normal";
                        }
                        else if (lnItm[27].ToString()=="Y")
                        {
                            Imp.FILING_STATUS="Prior";
                        }
                        else if (lnItm[27].ToString()=="A")
                        {
                            Imp.FILING_STATUS="Advanced";
                        }                        
                        Imp.SECTION46 = "N";
                        Imp.SECTION46_DESC = "";
                        Imp.FIRSTCHECK = lnItm[29].ToString();
                        Imp.FIRSTCHECK_DESC = Frt_Chk;
                        Imp.GREEN_CHANNEL = lnItm[25].ToString();
                        Imp.GREEN_CHANNEL_DESC = "";
                        Imp.KACHHA_BE = lnItm[18].ToString();
                        Imp.KACHHA_BE_DESC = "";
                        Imp.SECTION48 = lnItm[26].ToString();
                        Imp.SECTION48_DESC = Sec48;
                        if (ProvAss.Length > 0)
                        {
                            Imp.PROVISIONAL = "Y";
                            Imp.PROVISIONAL_DESC = ProvAss;
                        }
                        else 
                        {
                            Imp.PROVISIONAL = "N";
                            Imp.PROVISIONAL_DESC = "";
                        }
                        Imp.HIGH_SEA_SALE = lnItm[19].ToString();
                        Imp.HIGH_SEA_SALE_NAME = "";
                        Imp.HIGH_SEA_IEC = "";
                        Imp.HIGH_SEA_BRANCH_SL_NO = "";
                        Imp.HSS_ADD1 = "";                        
                        Imp.HSS_ADD2 = "";
                        Imp.HSS_ADD3 = "";
                        Imp.HSS_ADD4 = "";
                        Imp.HSS_ADD5 = "";
                        Imp.PRECEDING_LEVEL = "";
                        if (dt_Hss.Rows.Count>0)
                        {
                            Imp.HIGH_SEA_SALE_NAME = dt_Hss.Rows[0]["HIGH_SEA_SALE_NAME"].ToString();
                            Imp.HIGH_SEA_IEC = dt_Hss.Rows[0]["HIGH_SEA_IEC"].ToString();
                            Imp.HIGH_SEA_BRANCH_SL_NO = dt_Hss.Rows[0]["HIGH_SEA_BRANCH_SL_NO"].ToString();
                            Imp.HSS_ADD1 = dt_Hss.Rows[0]["HSS_ADD1"].ToString();
                            Imp.HSS_ADD2 = dt_Hss.Rows[0]["HSS_ADD2"].ToString();
                            Imp.HSS_ADD3 = dt_Hss.Rows[0]["HSS_ADD3"].ToString();
                            Imp.HSS_ADD4 = dt_Hss.Rows[0]["HSS_ADD4"].ToString();
                            Imp.HSS_ADD5 = dt_Hss.Rows[0]["HSS_ADD5"].ToString();
                            Imp.PRECEDING_LEVEL = dt_Hss.Rows[0]["PRECEDING_LEVEL"].ToString();
                        }
                        Imp.WAREHOUSE_NAME = "No";
                        Imp.WAREHOUSE_CODE = lnItm[30].ToString();
                        Imp.IMP_EXP_TYPE = lnItm[17].ToString();
                        Imp.COMMERCIAL_DETAILS_STATUS = "N";
                        Imp.COMMERCIAL_TAX_STATENAME = "";
                        Imp.COMMERCIAL_TAX_STATECODE = "";
                        Imp.COMMERCIAL_TAX_TYPE = "";
                        Imp.COMMERCIAL_TAX_REGISTRATION_NO = "";
                        if (dt_Gst.Rows.Count>0)
                        {
                            Imp.COMMERCIAL_DETAILS_STATUS = "Y";
                            Imp.COMMERCIAL_TAX_STATECODE=dt_Gst.Rows[0]["COMMERCIAL_TAX_STATECODE"].ToString();
                            Imp.COMMERCIAL_TAX_TYPE=dt_Gst.Rows[0]["COMMERCIAL_TAX_TYPE"].ToString();
                            Imp.COMMERCIAL_TAX_REGISTRATION_NO=dt_Gst.Rows[0]["COMMERCIAL_TAX_REGISTRATION_NO"].ToString();
                            State_Code = State_Code + "~" + dt_Gst.Rows[0]["COMMERCIAL_TAX_STATECODE"].ToString();                           
                        }
                        Imp.EXBOND_INBOND_BE_NO = lnItm[32].ToString();
                        if (Imp.BE_TYPE == "Home" || Imp.BE_TYPE == "Warehouse" || Imp.BE_TYPE == "Jobbing" || Imp.BE_TYPE == "Repair & Return" || Imp.BE_TYPE == "Destruction" || Imp.BE_TYPE == "Stock Item" || Imp.BE_TYPE == "SEZ FTA-Z" || Imp.BE_TYPE == "Exhibition")
                        {
                            Imp.EXBOND_INBOND_BE_DATE = "01/01/1900";
                            Imp.EXBOND_GROSS_WEIGHT = null;
                        }
                        else
                        {
                            Imp.EXBOND_INBOND_BE_DATE = lnItm[33].ToString().Substring(6, 2) + "/" + lnItm[33].ToString().Substring(4, 2) + "/" + lnItm[33].ToString().Substring(0, 4);
                            Imp.EXBOND_GROSS_WEIGHT = lnItm[36].ToString();
                        }
                        Imp.EXBOND_BOND_NO = "";
                        Imp.EXBOND_BOND_DATE = "01/01/1900";
                        Imp.EXBOND_WAREHOUSE_CUSTOMS = lnItm[31].ToString();
                        Imp.EXBOND_WAREHOUSE_CUSTOMS_CODE = lnItm[30].ToString();
                        Imp.EXBOND_NOOFPACKAGE = lnItm[34].ToString();
                        Imp.EXBOND_NOOFPACKAGE_UNITCODE = lnItm[35].ToString();
                        Imp.EXBOND_GROSS_WEIGHT_UNITCODE = lnItm[37].ToString();
                        Imp.EXBOND_DIRECT_EXBONDING = "";
                        Imp.REMARKS = "";
                        Imp.USER_ID = Connection.Current_User();
                        Imp.BRANCH_CODE = Connection.Current_Branch();
                        Imp.WORKING_PERIOD = Connection.WorkingPeriod();
                        Imp.FILE_REF_NO = "";
                        Imp.CONTAINER_TYPE="";                       
                        Imp.JOB_PREFIX = hdprefix.Value.ToString();
                        Imp.JOB_SUFFIX = hdsuffix.Value.ToString();
                        Imp.JOBNO_PS = txtjobPS;
                        Imp.COMPLETED_DATE = "01/01/1900";
                        Imp.ADCODE = lnItm[28].ToString();
                        Imp.UCR_NO = lnItm[40].ToString();
                        Imp.UCR_TYPE = lnItm[41].ToString();
                        Imp.PAYMENT_METHOD_CODE = lnItm[42].ToString();
                        Imp.DOC_RECEIVED_DATE = "01/01/1900";
                        Imp.AImpT_NAME = "";
                        Imp.EXBOND_ADDL_LOAD_HSS = lnItm[38].ToString();
                        Imp.EXBOND_MISC_LOAD_RATE = lnItm[39].ToString();
                        Imp.GSTN_TYPE = "";
                        Imp.GSTN_ID = "";
                        Imp.PARTY_REF_NO = "";
                        Imp.ETA = "";
                        Imp.AMENDMENT_TYPE = "";
                        Imp.AMENDMENT_STATUS = "";
                        Imp.flag = "S";
                        Imp.JOBNO_PS = txtJobNo;
                        Imp.GROUP_ID = "";
                        Imp.FRT_JOBNO = "";
                        Imp.FRT_GROUPID = "";
                        Imp.FRT_BRANCHCODE = "";
                        Imp.HSS_ADCODE = "";
                        Imp.ICE_ID = "";
                        Imp.CHA_NO = "";
                        Imp.BRANCH_COMMON="";
                        result = Imp.General_details_insertupdate();
                        
                        break;                        
                    }
                }
            }
             #endregion ImpGeneral

            ///// *******************end to build general details *******************///////////////////

            ///// ********************Start Igm *******************///////////////////
            #region Igm_Details

            for (int ln = 0; ln < lines.Length; ln++)
            {
                string[] lnItm;
                pos = Array.IndexOf(lines, "<TABLE>IGMS");

                if (result == 1 && pos > 0)
                {
                   
                    dt_IGM.Columns.Add("IGM_ID");dt_IGM.Columns.Add("IGM_SLNO");dt_IGM.Columns.Add("JOBNO");dt_IGM.Columns.Add("IGM_JOBDATE");dt_IGM.Columns.Add("IGM_AIRLINECODE");
                    dt_IGM.Columns.Add("IGM_AIRLINENAME");dt_IGM.Columns.Add("IGM_FLIGHTNO_VESSELNO");dt_IGM.Columns.Add("IGM_FLIGHT_VESSELDATE");dt_IGM.Columns.Add("IGM_NO");
                    dt_IGM.Columns.Add("IGM_DATE");dt_IGM.Columns.Add("IGM_MAWB_MBL");dt_IGM.Columns.Add("IGM_MAWB_MBLDATE");dt_IGM.Columns.Add("IGM_HAWB_HBLNO");dt_IGM.Columns.Add("IGM_HAWB_HBLDATE");
                    dt_IGM.Columns.Add("IGM_NOOFPACKAGE");dt_IGM.Columns.Add("IGM_PACKAGETYPE");dt_IGM.Columns.Add("IGM_GROSSWEIGHT");dt_IGM.Columns.Add("IGM_TYPEOFWEIGHT");dt_IGM.Columns.Add("IGM_NETWEIGHT");
                    dt_IGM.Columns.Add("IGM_NETWEIGHTTYPE");dt_IGM.Columns.Add("IGM_TRANSPORTMODE");dt_IGM.Columns.Add("IGM_MARKSNOS");dt_IGM.Columns.Add("IGM_GATEWAY_IGM_NO");dt_IGM.Columns.Add("IGM_GATEWAY_IGM_DATE");
                    dt_IGM.Columns.Add("IGM_GATEWAY_PORT_CODE");dt_IGM.Columns.Add("IGM_USER_ID");dt_IGM.Columns.Add("IGM_DATE_TIME");dt_IGM.Columns.Add("IGM_STATUS");dt_IGM.Columns.Add("IGM_BRANCH_CODE");
                    dt_IGM.Columns.Add("IGM_YEAR");dt_IGM.Columns.Add("IGM_WORKING_PERIOD");dt_IGM.Columns.Add("MODIFIEDBY");dt_IGM.Columns.Add("MODIFIEDON");dt_IGM.Columns.Add("IGM_LINE_NUMBER");
                    dt_IGM.Columns.Add("IGM_SHIPPING_LINE_NUMBER");dt_IGM.Columns.Add("IGM_VOYAGE");dt_IGM.Columns.Add("IGM_CHARGEABLE_WGT");dt_IGM.Columns.Add("ROTATION_NO");
                    dt_IGM.Columns.Add("ROTATION_DATE");dt_IGM.Columns.Add("AMENDMENT_TYPE");dt_IGM.Columns.Add("AMENDMENT_STATUS");dt_IGM.Columns.Add("JOBNO_PS");

                    ln = pos + 1;
                    int igm_slno = 1;
                    try
                    {
                        for (ln = ln; ln < lines.Length - 1; ln++)
                        {
                            if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-BE>"))))
                            {

                                lnItm = lines[ln].ToString().Split('^');
                                if (lnItm.Length >= 21)
                                {
                                    string Igm_JobDate = (lnItm[3].ToString().Length >= 8) ? lnItm[3].ToString().Substring(6, 2) + "/" + lnItm[3].ToString().Substring(4, 2) + "/" + lnItm[3].ToString().Substring(0, 4) : "01/01/1900";
                                    string Igm_Inwrd = (lnItm[8].ToString().Length >= 8) ? lnItm[8].ToString().Substring(6, 2) + "/" + lnItm[8].ToString().Substring(4, 2) + "/" + lnItm[8].ToString().Substring(0, 4) : "01/01/1900";
                                    string Igm_Date = (lnItm[7].ToString().Length >= 8) ? lnItm[7].ToString().Substring(6, 2) + "/" + lnItm[7].ToString().Substring(4, 2) + "/" + lnItm[7].ToString().Substring(0, 4) : "01/01/1900";
                                    string Mbl_Date = (lnItm[13].ToString().Length >= 8) ? lnItm[13].ToString().Substring(6, 2) + "/" + lnItm[13].ToString().Substring(4, 2) + "/" + lnItm[13].ToString().Substring(0, 4) : "01/01/1900";
                                    string Hbl_Date = (lnItm[15].ToString().Length >= 8) ? lnItm[15].ToString().Substring(6, 2) + "/" + lnItm[15].ToString().Substring(4, 2) + "/" + lnItm[15].ToString().Substring(0, 4) : "01/01/1900";
                                    string GateWay_Date = (lnItm[10].ToString().Length >= 8) ? lnItm[10].ToString().Substring(6, 2) + "/" + lnItm[10].ToString().Substring(4, 2) + "/" + lnItm[10].ToString().Substring(0, 4) : "01/01/1900";

                                    dt_IGM.Rows.Add(IMP_IGM_ID, igm_slno, Convert.ToInt64(txtJobNo), Igm_JobDate, "", "", "", Igm_Inwrd, string.IsNullOrWhiteSpace(lnItm[6].ToString()) ? 0 : Convert.ToInt64(lnItm[6].ToString()), Igm_Date,
                                    lnItm[12].ToString(), Mbl_Date, lnItm[14].ToString(), Hbl_Date, lnItm[16].ToString(), lnItm[19].ToString(), lnItm[17].ToString(),
                                    lnItm[18].ToString(), "0.00", "", Cus_House, lnItm[20].ToString() + lnItm[21].ToString() + lnItm[22].ToString(), lnItm[9].ToString(),
                                    GateWay_Date, lnItm[11].ToString(), currentuser, cur_date, "N", currentbranch, "", Working_Period, "", "01/01/1900", "", "", "", "", "", "", "", "", "");

                                    IMP_IGM_ID = IMP_IGM_ID + 1;
                                    igm_slno = igm_slno + 1;
                                }

                            }
                            else
                            {
                                break;
                            }
                        }

                        if (dt_IGM.Rows.Count > 0)
                        {
                            admin.SqlBulk_Upload_Product("IGM_DETAILS", dt_IGM, comp_ConnectionStr);
                        }
                        pos = ln + 1;
                        break;
                    }
                    catch (Exception ex)
                    {
                        ErrorLogs er = new ErrorLogs();
                        er.makeLog(ex.Message);

                        Imp.JOBNO = txtJobNo;
                        Imp.BRANCH_CODE = Connection.Get_Company_Type();
                        Imp.flag = "Delete_All_Table";
                        Gen_Ms = Imp.Update_Gen_Ms_Inv_Item_Details();
                    }

                }
            }

            #endregion Igm_Details
            ///// ********************End Igm *******************///////////////////

            ///// ********************Start Container Details *******************///////////////////
            #region Con_Details

            for (int ln = 0; ln < lines.Length; ln++)
            {
                string[] lnItm;
                pos = Array.IndexOf(lines, "<TABLE>CONTAINER");

                if (result == 1 && pos > 0)
                {

                    dt_CONT.Columns.Add("CONTAINERID"); dt_CONT.Columns.Add("CONTAINER_IGM_SLNO"); dt_CONT.Columns.Add("CONTAINER_IGM_NO"); dt_CONT.Columns.Add("CONTAINER_IGM_DATE");
                    dt_CONT.Columns.Add("JOBNO"); dt_CONT.Columns.Add("CONTAINER_NO"); dt_CONT.Columns.Add("SEAL_NO"); dt_CONT.Columns.Add("FCL_OR_LCL"); dt_CONT.Columns.Add("USER_ID");
                    dt_CONT.Columns.Add("DATE_TIME"); dt_CONT.Columns.Add("STATUS"); dt_CONT.Columns.Add("BRANCH_CODE"); dt_CONT.Columns.Add("YEAR"); dt_CONT.Columns.Add("WORKING_PERIOD");
                    dt_CONT.Columns.Add("TYPE"); dt_CONT.Columns.Add("TRUCK_NO"); dt_CONT.Columns.Add("MODIFIEDBY"); dt_CONT.Columns.Add("MODIFIEDON"); dt_CONT.Columns.Add("AMENDMENT_TYPE");
                    dt_CONT.Columns.Add("AMENDMENT_STATUS"); dt_CONT.Columns.Add("JOBNO_PS");


                    ln = pos + 1;
                    int con_sl = 1;
                    try
                    {
                        for (ln = ln; ln < lines.Length - 1; ln++)
                        {
                            if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-BE>"))))
                            {

                                //lnItm = lines[ln].ToString().Split('^');
                                //if (lnItm.Length >= 8)
                                //{
                                //    string Con_Date = (lnItm[7].ToString().Length >= 8) ? lnItm[7].ToString().Substring(6, 2) + "/" + lnItm[7].ToString().Substring(4, 2) + "/" + lnItm[7].ToString().Substring(0, 4) : "01/01/1900";

                                //    dt_CONT.Rows.Add(CON_ID, con_sl, lnItm[6].ToString(), Con_Date, Convert.ToInt64(txtJobNo), lnItm[9].ToString(), lnItm[10].ToString(), lnItm[8].ToString(),
                                //    currentuser, cur_date, "N", currentbranch, "", Working_Period, "", "", "", "01/01/1900", "", "", "");
                                //    CON_ID = CON_ID + 1;
                                //    con_sl = con_sl + 1;
                                //}
                                lnItm = lines[ln].ToString().Split('^');

                                if (lnItm.Length >= 11)
                                {
                                    // ----------------------------------------------------
                                    // IGM NO - SQL BIGINT
                                    // ----------------------------------------------------
                                    string containerIgmNo = "0";

                                    if (!string.IsNullOrWhiteSpace(lnItm[6].ToString()))
                                    {
                                        long tempIgmNo;

                                        if (long.TryParse(lnItm[6].ToString().Trim(), out tempIgmNo))
                                        {
                                            containerIgmNo = tempIgmNo.ToString();
                                        }
                                    }


                                    // ----------------------------------------------------
                                    // IGM DATE
                                    // ----------------------------------------------------
                                    string Con_Date = "01/01/1900";

                                    if (!string.IsNullOrWhiteSpace(lnItm[7].ToString()) &&
                                        lnItm[7].ToString().Trim().Length >= 8)
                                    {
                                        string igmDate = lnItm[7].ToString().Trim();

                                        Con_Date =  igmDate.Substring(6, 2) + "/" +igmDate.Substring(4, 2) + "/" + igmDate.Substring(0, 4);
                                    }


                                    // ----------------------------------------------------
                                    // ADD CONTAINER DATA
                                    // ----------------------------------------------------
                                    dt_CONT.Rows.Add(
                                        CON_ID, con_sl, containerIgmNo, Con_Date, Convert.ToInt64(txtJobNo), lnItm[9].ToString().Trim(),lnItm[10].ToString().Trim(), lnItm[8].ToString().Trim(), currentuser, cur_date,"N",currentbranch, "", Working_Period, "","","", "01/01/1900","",  "", "" );

                                    CON_ID++;
                                    con_sl++;
                                }

                            }

                            else
                            {
                                break;
                            }
                        }

                        if (dt_CONT.Rows.Count > 0)
                        {
                            admin.SqlBulk_Upload_Product("CONTAINER_DETAILS", dt_CONT, comp_ConnectionStr);
                        }
                        pos = ln + 1;

                        break;

                    }
                    catch (Exception ex)
                    {
                        ErrorLogs er = new ErrorLogs();
                        er.makeLog(ex.Message);

                        Imp.JOBNO = txtJobNo;
                        Imp.BRANCH_CODE = Connection.Get_Company_Type();
                        Imp.flag = "Delete_All_Table";
                        Gen_Ms = Imp.Update_Gen_Ms_Inv_Item_Details();
                    }

                }
            }
            #endregion Con_Details
            ///// ********************End Container Details *******************///////////////////
            
            ///// ********************Start Bond Details *******************///////////////////
            #region Bond_Details

            for (int ln = 0; ln < lines.Length; ln++)
            {
                string[] lnItm;
                pos = Array.IndexOf(lines, "<TABLE>BOND");

                if (result == 1 && pos > 0)
                {
                    dt_BOND.Columns.Add("BONDID"); dt_BOND.Columns.Add("JOBNO"); dt_BOND.Columns.Add("BOND_NO"); dt_BOND.Columns.Add("BOND_TYPE"); dt_BOND.Columns.Add("BOND_LOCATION");
                    dt_BOND.Columns.Add("USER_ID"); dt_BOND.Columns.Add("DATE_TIME"); dt_BOND.Columns.Add("STATUS"); dt_BOND.Columns.Add("BRANCH_CODE"); dt_BOND.Columns.Add("YEAR");
                    dt_BOND.Columns.Add("WORKING_PERIOD"); dt_BOND.Columns.Add("MODIFIEDBY"); dt_BOND.Columns.Add("MODIFIEDON");

                    ln = pos + 1;
                    try
                    {
                        for (ln = ln; ln < lines.Length - 1; ln++)
                        {
                            if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-BE>"))))
                            {

                                lnItm = lines[ln].ToString().Split('^');
                                if (lnItm.Length >= 8)
                                {
                                    dt_BOND.Rows.Add(IMP_BOND_ID, Convert.ToInt64(txtJobNo), lnItm[6].ToString(), lnItm[7].ToString(), lnItm[8].ToString(),
                                    currentuser, cur_date, "N", currentbranch, "", Working_Period, "", "01/01/1900");

                                    IMP_BOND_ID = IMP_BOND_ID + 1;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (dt_BOND.Rows.Count > 0)
                        {
                            admin.SqlBulk_Upload_Product("BOND_DETAILS", dt_BOND, comp_ConnectionStr);
                        }
                        pos = ln + 1;
                        break;
                    }//
                    catch (Exception ex)
                    {
                        ErrorLogs er = new ErrorLogs();
                        er.makeLog(ex.Message);

                        Imp.JOBNO = txtJobNo;
                        Imp.BRANCH_CODE = Connection.Get_Company_Type();
                        Imp.flag = "Delete_All_Table";
                        Gen_Ms = Imp.Update_Gen_Ms_Inv_Item_Details();
                    }
                }
            }

            #endregion Bond_Details
            ///// ********************End Bond Details *******************///////////////////

            ///// ********************Start Certi Details *******************///////////////////
            #region Certi_Details

            for (int ln = 0; ln < lines.Length; ln++)
            {
                string[] lnItm;
                pos = Array.IndexOf(lines, "<TABLE>CERT");

                if (result == 1 && pos > 0)
                {
                    dt_CERT.Columns.Add("CERTIFICATEID"); dt_CERT.Columns.Add("JOBNO"); dt_CERT.Columns.Add("CERTIFICATE_NO"); dt_CERT.Columns.Add("CERTIFICATE_DATE");
                    dt_CERT.Columns.Add("CERTIFICATE_TYPE"); dt_CERT.Columns.Add("USER_ID"); dt_CERT.Columns.Add("DATE_TIME"); dt_CERT.Columns.Add("STATUS"); dt_CERT.Columns.Add("BRANCH_CODE");
                    dt_CERT.Columns.Add("YEAR"); dt_CERT.Columns.Add("WORKING_PERIOD"); dt_CERT.Columns.Add("MODIFIEDBY"); dt_CERT.Columns.Add("MODIFIEDON");

                    ln = pos + 1;
                    try
                    {
                        for (ln = ln; ln < lines.Length - 1; ln++)
                        {
                            if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-BE>"))))
                            {

                                lnItm = lines[ln].ToString().Split('^');
                                if (lnItm.Length >= 8)
                                {
                                    string Cert_Date = (lnItm[7].ToString().Length >= 8) ? lnItm[7].ToString().Substring(6, 2) + "/" + lnItm[7].ToString().Substring(4, 2) + "/" + lnItm[7].ToString().Substring(0, 4) : "01/01/1900";

                                    dt_CERT.Rows.Add(CERTID, Convert.ToInt64(txtJobNo), lnItm[6].ToString(), Cert_Date, lnItm[8].ToString(),
                                    currentuser, cur_date, "N", currentbranch, "", Working_Period, "", "01/01/1900");

                                    CERTID = CERTID + 1;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (dt_CERT.Rows.Count > 0)
                        {
                            admin.SqlBulk_Upload_Product("CERTIFICATE_DETAILS", dt_CERT, comp_ConnectionStr);
                        }
                        pos = ln + 1;
                        break;
                    }
                    catch (Exception ex)
                    {
                        ErrorLogs er = new ErrorLogs();
                        er.makeLog(ex.Message);

                        Imp.JOBNO = txtJobNo;
                        Imp.BRANCH_CODE = Connection.Get_Company_Type();
                        Imp.flag = "Delete_All_Table";
                        Gen_Ms = Imp.Update_Gen_Ms_Inv_Item_Details();
                    }
                }
            }

            #endregion Certi_Details
            ///// ********************End Certi Details *******************///////////////////


            ////// ****************** starts exchange currency ************************///////

           
            for (int ln = 0; ln < lines.Length; ln++)
            {
                string[] lnItm;
                pos = Array.IndexOf(lines, "<TABLE>EXCHANGE");

                if (result == 1 && pos > 0)
                {
                  
                    #region dt_Exchange
                    dt_Exchange.Columns.Add("INVOICE_CURRENCY"); dt_Exchange.Columns.Add("Standard_Currency"); dt_Exchange.Columns.Add("UNIT"); dt_Exchange.Columns.Add("EXCHANGE_RATE");

                    ln = pos + 1;
                    for (ln = ln; ln < lines.Length - 1; ln++)
                    {
                        if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-BE>"))))
                        {

                            lnItm = lines[ln].ToString().Split('^');
                            if (lnItm.Length >= 2)
                            {
                                dt_Exchange.Rows.Add(lnItm[6].ToString(), lnItm[7].ToString(),lnItm[8].ToString(), lnItm[9].ToString());
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    #endregion dt_Exchange
                    pos = ln + 1;
                    break;

                }
            }
            //****************************** end of exchange currency ************************/////


            ////// ****************** starts Other charges ************************///////


            #region Other charges - MISC_CH

            Dictionary<string, Dictionary<string, string>> miscChargesByInvoice =
                new Dictionary<string, Dictionary<string, string>>();

            for (int ln = 0; ln < lines.Length; ln++)
            {
                string[] lnItm;

                pos = Array.IndexOf(lines, "<TABLE>MISC_CH");

                if (result == 1 && pos > 0)
                {
                    #region dt_Otherchrg

                    ln = pos + 1;

                    for (ln = ln; ln < lines.Length - 1; ln++)
                    {
                        // Stop when next TABLE or END-BE is reached
                        if ((!lines[ln].ToString().Contains("<TABLE>")) &&
                            (!lines[ln].ToString().Contains("<END-BE>")))
                        {
                            lnItm = lines[ln].ToString().Split('^');

                            // We access up to index 9
                            if (lnItm.Length >= 10)
                            {
                                // ------------------------------------------------
                                // MISC_CH field mapping
                                // ------------------------------------------------
                                string invoiceSlNo = lnItm[6].ToString().Trim();
                                string chargeType = lnItm[7].ToString().Trim();
                                string amount = lnItm[9].ToString().Trim();

                                // Ignore invalid/empty invoice number
                                if (string.IsNullOrWhiteSpace(invoiceSlNo))
                                {
                                    continue;
                                }

                                // ------------------------------------------------
                                // Create invoice entry if it does not exist
                                // ------------------------------------------------
                                if (!miscChargesByInvoice.ContainsKey(invoiceSlNo))
                                {
                                    miscChargesByInvoice.Add(
                                        invoiceSlNo,
                                        new Dictionary<string, string>()
                                    );
                                }
                                miscChargesByInvoice[invoiceSlNo][chargeType] = amount;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    #endregion dt_Otherchrg

                    pos = ln + 1;

                    break;
                }
            }

            #endregion Other charges
            //****************************** end of Other charges ************************/////

            ///// ******************* Start invoice details *******************///////////////////

            
            for (int ln = 0; ln < lines.Length; ln++)
            {
                string[] lnItm;

                string Trans = "", Payment = "";
                pos = Array.IndexOf(lines, "<TABLE>INVOICE");

                if (result == 1 && pos > 0)
                {
                    #region dt_INV
                    dt_INV.Columns.Add("INVOICE_ID"); dt_INV.Columns.Add("JOBNO"); dt_INV.Columns.Add("INVOICE_SLNO"); dt_INV.Columns.Add("INVOICE_NO"); dt_INV.Columns.Add("INVOICE_DATE");
                    dt_INV.Columns.Add("TERMS"); dt_INV.Columns.Add("INVOICE_CURRENCY"); dt_INV.Columns.Add("INVOICE_EXRATE"); dt_INV.Columns.Add("INVOICE_VALUE");
                    dt_INV.Columns.Add("SUPPLIER_NAME"); dt_INV.Columns.Add("SUPPLIER_ADDRESS"); dt_INV.Columns.Add("SUPPLIER_ADDRESS1"); dt_INV.Columns.Add("SUPPLIER_ADDRESS2"); dt_INV.Columns.Add("SUPPLIER_COUNTRY_NAME");// 14 count 
                    dt_INV.Columns.Add("SUPPLIER_COUNTRY_CODE"); dt_INV.Columns.Add("SUPPLIER_COUNTRY_PINCODE"); dt_INV.Columns.Add("SELLER_NAME"); dt_INV.Columns.Add("SELLER_ADDRESS");
                    dt_INV.Columns.Add("SELLER_ADDRESS1"); dt_INV.Columns.Add("SELLER_ADDRESS2"); dt_INV.Columns.Add("SELLER_COUNTRY_NAME"); dt_INV.Columns.Add("SELLER_COUNTRY_CODE");
                    dt_INV.Columns.Add("SELLERCOUNTRY_PINCODE"); dt_INV.Columns.Add("BROKER_NAME"); dt_INV.Columns.Add("BROKER_ADDRESS"); dt_INV.Columns.Add("BROKER_ADDRESS1"); // 26 count
                    dt_INV.Columns.Add("BROKER_ADDRESS2"); dt_INV.Columns.Add("BROKER_COUNTRY_NAME"); dt_INV.Columns.Add("BROKER_COUNTRY_CODE"); dt_INV.Columns.Add("BROKER_COUNTRY_PINCODE");//30
                    dt_INV.Columns.Add("MIS_CHARGES"); dt_INV.Columns.Add("MIS_RATE"); dt_INV.Columns.Add("MIS_CURRENCY"); dt_INV.Columns.Add("MIS_EXRATE");
                    dt_INV.Columns.Add("MIS_AGENCY_CHARGES"); dt_INV.Columns.Add("MIS_AGENCY_RATE"); dt_INV.Columns.Add("MIS_AGENCY_CURRENCY"); dt_INV.Columns.Add("MIS_AGENCY_EXRATE");
                    dt_INV.Columns.Add("MIS_DISCOUNT_CHARGES"); dt_INV.Columns.Add("MIS_DISCOUNT_RATE"); dt_INV.Columns.Add("MIS_DISCOUNT_CURRENCY");  //41
                    dt_INV.Columns.Add("MIS_DISCOUNT_EXRATE"); dt_INV.Columns.Add("MIS_DISCOUNT_REASON"); dt_INV.Columns.Add("MIS_LOADING_CHARGES"); dt_INV.Columns.Add("MIS_LOADING_RATE");
                    dt_INV.Columns.Add("MIS_LOADING_CURRENCY"); dt_INV.Columns.Add("MIS_LOADING_EXRATE"); dt_INV.Columns.Add("MIS_FREIGHT_CHARGES"); dt_INV.Columns.Add("MIS_FREIGHT_RATE");//49 count   
                    dt_INV.Columns.Add("MIS_FREIGHT_CURRENCY"); dt_INV.Columns.Add("MIS_FREIGHT_EXRATE"); dt_INV.Columns.Add("MIS_INSURANCE_CHARGES"); dt_INV.Columns.Add("MIS_INSURANCE_RATE");//53 count
                    dt_INV.Columns.Add("MIS_INSURANCE_CURRENCY"); dt_INV.Columns.Add("MIS_INSURANCE_EXRATE"); dt_INV.Columns.Add("MIS_HIGHSEASALE_CHARGES"); dt_INV.Columns.Add("MIS_HIGHSEASALE_RATE");
                    dt_INV.Columns.Add("MIS_HIGHSEASALE_CURRENCY"); dt_INV.Columns.Add("MIS_HIGHSEASALE_EXRATE"); //59
                    dt_INV.Columns.Add("MIS_SINGLE_OR_MULITIPLE"); dt_INV.Columns.Add("SVB_RELATION");
                    dt_INV.Columns.Add("SVB_REF_NO"); dt_INV.Columns.Add("SVB_REF_DATE"); dt_INV.Columns.Add("SVB_CUSTOM_HOUSE");
                    dt_INV.Columns.Add("SVB_LOADING_ON"); dt_INV.Columns.Add("SVB_ASSESABLE_RATE"); dt_INV.Columns.Add("SVB_DUTY_RATE"); dt_INV.Columns.Add("SVB_ASSESABLE_STATUS"); dt_INV.Columns.Add("SVB_DUTY_STATUS");
                    dt_INV.Columns.Add("OTHER_PURCHASE_ORDER"); dt_INV.Columns.Add("OTHER_PURCHASE_ORDER_DATE"); dt_INV.Columns.Add("OTHER_CONTRACT_NO"); dt_INV.Columns.Add("OTHER_CONTRACT_DATE"); dt_INV.Columns.Add("OTHER_LOC_NO");
                    dt_INV.Columns.Add("OTHER_LOC_DATE"); dt_INV.Columns.Add("OTHER_NATURE_OF_TRANSACTION"); dt_INV.Columns.Add("OTHER_TERMS_OF_PAYMENT"); dt_INV.Columns.Add("OTHER_CONDITIONS"); dt_INV.Columns.Add("OTHER_VALUATION_METHOD");
                    dt_INV.Columns.Add("USER_ID"); dt_INV.Columns.Add("DATE_TIME"); dt_INV.Columns.Add("STATUS"); dt_INV.Columns.Add("BRANCH_CODE"); dt_INV.Columns.Add("YEAR");
                    dt_INV.Columns.Add("WORKING_PERIOD"); dt_INV.Columns.Add("NON_STD_EFFECT_DT_IMP"); dt_INV.Columns.Add("NON_STD_BANKNAME"); dt_INV.Columns.Add("NON_STD_CERTIFICATE_NO"); dt_INV.Columns.Add("NON_STD_CERTIFICATE_DATE");
                    dt_INV.Columns.Add("SAP_DELIEVERY_ID"); dt_INV.Columns.Add("SHIP_DATE"); dt_INV.Columns.Add("INVOICE_LEVEL"); dt_INV.Columns.Add("COUNTRY_OF_DEPARTURE"); dt_INV.Columns.Add("REVENUEDEPOSIT_RATE");
                    dt_INV.Columns.Add("REVENUEDEPOSIT_ON"); dt_INV.Columns.Add("MI_FREIGHT"); dt_INV.Columns.Add("MI_INSURANCE"); dt_INV.Columns.Add("MI_MISC"); dt_INV.Columns.Add("MI_HSS");
                    dt_INV.Columns.Add("MODIFIEDBY"); dt_INV.Columns.Add("MODIFIEDON"); dt_INV.Columns.Add("INDEV_INV_TYPE"); dt_INV.Columns.Add("TERMS_PLACE"); dt_INV.Columns.Add("THIRDPARTY_NAME");
                    dt_INV.Columns.Add("THIRDPARTY_ADD1"); dt_INV.Columns.Add("THIRDPARTY_ADD2"); dt_INV.Columns.Add("THIRDPARTY_CITY"); dt_INV.Columns.Add("T_PARTY_COUNTRY_SUB_DIV"); dt_INV.Columns.Add("T_PARTY_COUNTRY_CODE");
                    dt_INV.Columns.Add("T_PARTY_PIN"); dt_INV.Columns.Add("AUTHORIZED_ECONOMIC_OPERATOR_CODE"); dt_INV.Columns.Add("A_E_O_COUNTRY"); dt_INV.Columns.Add("AUTHORIZED_ECONOMIC_OPERATOR"); dt_INV.Columns.Add("WHETHER_BUYER_SELLER_RELATED");
                    dt_INV.Columns.Add("A_AMOUNT"); dt_INV.Columns.Add("B_AMOUNT"); dt_INV.Columns.Add("C_AMOUNT"); dt_INV.Columns.Add("D_AMOUNT"); dt_INV.Columns.Add("E_AMOUNT");
                    dt_INV.Columns.Add("F_AMOUNT"); dt_INV.Columns.Add("G_AMOUNT"); dt_INV.Columns.Add("H_AMOUNT"); dt_INV.Columns.Add("I_AMOUNT"); dt_INV.Columns.Add("J_AMOUNT");
                    dt_INV.Columns.Add("K_AMOUNT"); dt_INV.Columns.Add("L_AMOUNT"); dt_INV.Columns.Add("M_AMOUNT"); dt_INV.Columns.Add("N_AMOUNT"); dt_INV.Columns.Add("TOTAL_OTHER_AMOUNT");
                    dt_INV.Columns.Add("DOC_RECD_DATE"); dt_INV.Columns.Add("INV_MISC_T_F"); dt_INV.Columns.Add("INV_MISC_CURRENCY"); dt_INV.Columns.Add("INV_MISC_EXRATE"); dt_INV.Columns.Add("INV_MISC_CHARGES");
                    dt_INV.Columns.Add("INV_MISC_TOTAL_CHARGES"); dt_INV.Columns.Add("INV_MISC_ADD_FRT_INS_YN"); dt_INV.Columns.Add("SUPPLIER_BRANCH_SLNO"); dt_INV.Columns.Add("AMENDMENT_TYPE"); dt_INV.Columns.Add("AMENDMENT_STATUS"); dt_INV.Columns.Add("JOBNO_PS"); 

                    ln = pos + 1;
                    try
                    {
                    for (ln = ln; ln < lines.Length - 1; ln++)
                    {
                        if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-BE>"))))
                        {                        
                               
                            lnItm = lines[ln].ToString().Split('^');
                            if (lnItm.Length > 30)
                            {
                                
                                if (lnItm[65].ToString()=="S")
                                {
                                    Trans = "S Sale";
                                }
                                else if (lnItm[65].ToString() == "F")
                                {
                                    Trans = "F Free Of Cost";
                                }
                                else if (lnItm[65].ToString() == "C")
                                {
                                    Trans = "C Consignment";
                                }
                                else if (lnItm[65].ToString() == "G")
                                {
                                    Trans = "G Gift";
                                }
                                else if (lnItm[65].ToString() == "H")
                                {
                                    Trans = "H Hire";
                                }
                                else if (lnItm[65].ToString() == "M")
                                {
                                    Trans = "M Sample";
                                }
                                else if (lnItm[65].ToString() == "O")
                                {
                                    Trans = "O Others";
                                }
                                else if (lnItm[65].ToString() == "P")
                                {
                                    Trans = "P Replacement";
                                }
                                else if (lnItm[65].ToString() == "R")
                                {
                                    Trans = "R Rent";
                                }

                                if (lnItm[66].ToString() == "OTH")
                                {
                                    Payment = "OTH Others";
                                }
                                else if ((lnItm[66].ToString() == "DP"))
                                {
                                    Payment = "DP Document Presentation";
                                }
                                else if ((lnItm[66].ToString() == "FC"))
                                {
                                    Payment = "FC Free Of Charge";
                                }
                                else if ((lnItm[66].ToString() == "LC"))
                                {
                                    Payment = "LC Letter Of Credit";
                                }
                                else if ((lnItm[66].ToString() == "SD"))
                                {
                                    Payment = "SD Site Draft";
                                }

                                formattedDate1 = (lnItm[7].ToString().Length >= 8) ? lnItm[7].ToString().Substring(6, 2) + "/" + lnItm[7].ToString().Substring(4, 2) + "/" + lnItm[7].ToString().Substring(0, 4) : "01/01/1900";
                                formattedDate2 = (lnItm[9].ToString().Length >= 8) ? lnItm[9].ToString().Substring(6, 2) + "/" + lnItm[9].ToString().Substring(4, 2) + "/" + lnItm[9].ToString().Substring(0, 4) : "01/01/1900";
                                formattedDate3 = (lnItm[11].ToString().Length >= 8) ? lnItm[11].ToString().Substring(6, 2) + "/" + lnItm[11].ToString().Substring(4, 2) + "/" + lnItm[11].ToString().Substring(0, 4) : "01/01/1900";
                                formattedDate4 = (lnItm[13].ToString().Length >= 8) ? lnItm[13].ToString().Substring(6, 2) + "/" + lnItm[13].ToString().Substring(4, 2) + "/" + lnItm[13].ToString().Substring(0, 4) : "01/01/1900";
                                formattedDate5 = (lnItm[15].ToString().Length >= 8) ? lnItm[15].ToString().Substring(6, 2) + "/" + lnItm[15].ToString().Substring(4, 2) + "/" + lnItm[15].ToString().Substring(0, 4) : "01/01/1900";

                                string Ex_Rate = string.IsNullOrEmpty(lnItm[56].ToString()) ? lnItm[42].ToString(): lnItm[56].ToString();
                                string Ex_Rate1 = string.IsNullOrEmpty(lnItm[63].ToString()) ? lnItm[42].ToString() : lnItm[63].ToString();
                                string Ex_Rate2 = string.IsNullOrEmpty(lnItm[60].ToString()) ? lnItm[42].ToString() : lnItm[60].ToString();
                                string Ex_Rate3 = string.IsNullOrEmpty(lnItm[51].ToString()) ? lnItm[42].ToString() : lnItm[51].ToString();
                                string Ex_Rate4 = string.IsNullOrEmpty(lnItm[54].ToString()) ? lnItm[42].ToString() : lnItm[54].ToString();
                                string invoiceSlNo =lnItm[6].ToString().Trim();

                                Dictionary<string, string> invoiceMiscCharges = null;

                                if (miscChargesByInvoice.TryGetValue(invoiceSlNo, out invoiceMiscCharges))
                                {
                                    invoiceMiscCharges.TryGetValue("A", out A_AMOUNT);
                                    invoiceMiscCharges.TryGetValue("B", out B_AMOUNT);
                                    invoiceMiscCharges.TryGetValue("C", out C_AMOUNT);
                                    invoiceMiscCharges.TryGetValue("D", out D_AMOUNT);
                                    invoiceMiscCharges.TryGetValue("E", out E_AMOUNT);
                                    invoiceMiscCharges.TryGetValue("F", out F_AMOUNT);
                                    invoiceMiscCharges.TryGetValue("G", out G_AMOUNT);
                                    invoiceMiscCharges.TryGetValue("H", out H_AMOUNT);
                                    invoiceMiscCharges.TryGetValue("I", out I_AMOUNT);
                                    invoiceMiscCharges.TryGetValue("J", out J_AMOUNT);
                                    invoiceMiscCharges.TryGetValue("K", out K_AMOUNT);
                                    invoiceMiscCharges.TryGetValue("L", out L_AMOUNT);
                                    invoiceMiscCharges.TryGetValue("M", out M_AMOUNT);
                                    invoiceMiscCharges.TryGetValue("N", out N_AMOUNT);
                                }

                                dt_INV.Rows.Add(IMP_INV_ID, Convert.ToInt64(txtJobNo), Convert.ToInt64(lnItm[6].ToString()),lnItm[73].ToString(),formattedDate1,lnItm[41].ToString(),lnItm[42].ToString(),
                                Get_ExRate(lnItm[42].ToString()), lnItm[40].ToString(), lnItm[22].ToString(), lnItm[23].ToString(), lnItm[24].ToString(), lnItm[25].ToString(), lnItm[26].ToString(),"",  
                                lnItm[27].ToString(),lnItm[28].ToString(),lnItm[29].ToString(), lnItm[30].ToString(),lnItm[31].ToString(),lnItm[32].ToString(),"", lnItm[33].ToString(),lnItm[34].ToString(),
                                lnItm[35].ToString(), lnItm[36].ToString(), lnItm[37].ToString(), lnItm[38].ToString(), "", lnItm[39].ToString(), lnItm[55].ToString(), lnItm[57].ToString(),
                                Ex_Rate, Get_ExRate(Ex_Rate), lnItm[62].ToString(), lnItm[64].ToString(), Ex_Rate1, Get_ExRate(Ex_Rate1), lnItm[45].ToString(), lnItm[44].ToString(),
                                lnItm[42].ToString(), Get_ExRate(lnItm[42].ToString()), "", lnItm[59].ToString(), lnItm[61].ToString(), Ex_Rate2, Get_ExRate(Ex_Rate2), lnItm[48].ToString(), lnItm[49].ToString(),
                                Ex_Rate3, Get_ExRate(Ex_Rate3), lnItm[52].ToString(), lnItm[53].ToString(), Ex_Rate4, Get_ExRate(Ex_Rate4), lnItm[47].ToString(), lnItm[46].ToString(),
                                "INR", "1", "S", "N", lnItm[14].ToString(), formattedDate5, lnItm[21].ToString(), lnItm[18].ToString(), lnItm[16].ToString(), lnItm[17].ToString(), lnItm[19].ToString(), lnItm[20].ToString(),
                                lnItm[8].ToString(), formattedDate2, lnItm[10].ToString(), formattedDate3, lnItm[12].ToString(), formattedDate4, Trans, Payment,"", lnItm[72].ToString(), Session["currentuser"].ToString(),
                                cur_date, "N", Session["currentbranch"].ToString(), "", Session["WorkingPeriod"].ToString(), "01/01/1900","","","01/01/1900","","01/01/1900","","","","","","","","","","01/01/1900","",                                                               
                                lnItm[75].ToString(), lnItm[76].ToString(),lnItm[77].ToString(),lnItm[78].ToString(), lnItm[79].ToString(), lnItm[80].ToString(), lnItm[81].ToString(), lnItm[82].ToString(),lnItm[83].ToString(),
                                lnItm[84].ToString(), lnItm[85].ToString(), lnItm[86].ToString(), A_AMOUNT, B_AMOUNT, C_AMOUNT, D_AMOUNT, E_AMOUNT, F_AMOUNT, G_AMOUNT, H_AMOUNT, I_AMOUNT, J_AMOUNT, K_AMOUNT, L_AMOUNT, M_AMOUNT,
                                N_AMOUNT, "", "", "", "", "", "", "", "", "", "", "");
                                
                                IMP_INV_ID = IMP_INV_ID + 1;
                            }

                        }
                        else
                        {
                            break;

                        }
                    }

                    if (dt_INV.Rows.Count > 0)
                    {
                        admin.SqlBulk_Upload_Product("INVOICE_DETAILS", dt_INV, comp_ConnectionStr);
                    }
                    pos = ln + 1;
                    break;
                }
                catch (Exception ex)
                    {
                        ErrorLogs er = new ErrorLogs();
                        er.makeLog(ex.Message);

                        Imp.JOBNO = txtJobNo;
                        Imp.BRANCH_CODE = Connection.Get_Company_Type();
                        Imp.flag = "Delete_All_Table";
                        Gen_Ms = Imp.Update_Gen_Ms_Inv_Item_Details();
                    }


                    # endregion dt_INV
                }
            }

            ///// ******************* End of invoice details *******************///////////////////


            //****************************** starts item ************************/////

            //for (int ln = pos; ln < lines.Length; ln++)
            try
            {
            for (int ln = 0; ln < lines.Length; ln++)
            {

                string[] lnItm;
                
                pos = Array.IndexOf(lines, "<TABLE>ITEMS");
                if (result == 1 && pos > 0)
                {

                    #region dt_Item

                    dt_ITEM.Columns.Add("ITEM_ID"); dt_ITEM.Columns.Add("JOBNO"); dt_ITEM.Columns.Add("INVOICE_SLNO");
                    dt_ITEM.Columns.Add("INVOICE_NO"); dt_ITEM.Columns.Add("ITEM_SLNO");dt_ITEM.Columns.Add("ITEM_DESCRIPTION"); 
                    dt_ITEM.Columns.Add("ITEM_QTY"); dt_ITEM.Columns.Add("ITEM_QTY_CODE"); dt_ITEM.Columns.Add("ITEM_UNIT_PRICE");
                    dt_ITEM.Columns.Add("ITEM_UNIT_CODE"); dt_ITEM.Columns.Add("ITEM_TOTAL_AMOUNT"); dt_ITEM.Columns.Add("ITEM_AMOUNT_CODE"); dt_ITEM.Columns.Add("CTH_NO");
                    dt_ITEM.Columns.Add("SCHEME_CODE"); dt_ITEM.Columns.Add("SCHEME_NOTN"); dt_ITEM.Columns.Add("SCHEME_NOTN_SLNO"); dt_ITEM.Columns.Add("CTH_QTY1");
                    dt_ITEM.Columns.Add("CTH_QTY1_CODE"); dt_ITEM.Columns.Add("CTH_QTY2"); dt_ITEM.Columns.Add("CTH_QTY2_CODE"); dt_ITEM.Columns.Add("GENEARL_DESCRIPTION"); dt_ITEM.Columns.Add("MANUFACTURER");
                    dt_ITEM.Columns.Add("BRAND"); dt_ITEM.Columns.Add("MODEL"); dt_ITEM.Columns.Add("END_USE_OF_ITEM"); dt_ITEM.Columns.Add("COUNTRY_OF_ORIGIN"); dt_ITEM.Columns.Add("ACCESSORIES");
                    dt_ITEM.Columns.Add("PREVIOUS_BE_NO"); dt_ITEM.Columns.Add("PREVIOUS_BE_DATE"); dt_ITEM.Columns.Add("UNIT_PRICE"); dt_ITEM.Columns.Add("UNIT_CODE"); dt_ITEM.Columns.Add("CUSTOMS_HOUSE");
                    dt_ITEM.Columns.Add("PRODUCT_RITC");dt_ITEM.Columns.Add("PRODUCT_CTH"); dt_ITEM.Columns.Add("PRODUCT_BCD_NOTN"); dt_ITEM.Columns.Add("PRODUCT_BCD_SLNO"); dt_ITEM.Columns.Add("PRODUCT_BCD_RATE");
                    dt_ITEM.Columns.Add("PRODUCT_BCD_SPL");dt_ITEM.Columns.Add("PRODUCT_BCD_UNIT"); dt_ITEM.Columns.Add("PRODUCT_BCD_SPL_TYPE");dt_ITEM.Columns.Add("PRODUCT_ADDL_DUTY_NOTN");dt_ITEM.Columns.Add("PRODUCT_ADDL_DUTY_NOTN_SL");
                    dt_ITEM.Columns.Add("PRODUCT_ADDL_DUTY_RATE");dt_ITEM.Columns.Add("PRODUCT_EDU_CESS_NOTN"); dt_ITEM.Columns.Add("PRODUCT_EDU_CESS_NOTN_SL");dt_ITEM.Columns.Add("PRODUCT_EDU_CESS_RATE");dt_ITEM.Columns.Add("PRODUCT_SEC_EDU_CESS_NOTN");
                    dt_ITEM.Columns.Add("PRODUCT_SEC_EDU_CESS_NOTN_SL"); dt_ITEM.Columns.Add("PRODUCT_SEC_EDU_CESS_RATE");dt_ITEM.Columns.Add("PRODUCT_NCD_NOTN");dt_ITEM.Columns.Add("PRODUCT_NCD_SLNO");dt_ITEM.Columns.Add("PRODUCT_NCD_RATE");
                    dt_ITEM.Columns.Add("PRODUCT_NCD_SPL");dt_ITEM.Columns.Add("PRODUCT_NCD_UNIT");dt_ITEM.Columns.Add("PRODUCT_NCD_SPL_TYPE");dt_ITEM.Columns.Add("PRODUCT_AGGREGATE_DUTY_NOTN");
                    dt_ITEM.Columns.Add("PRODUCT_AGGREGATE_DUTY_NOTN_SL");dt_ITEM.Columns.Add("PRODUCT_AGGREGATE_DUTY_NOTN_RATE");dt_ITEM.Columns.Add("PRODUCT_SAFEGUARD_NOTN");dt_ITEM.Columns.Add("PRODUCT_SAFEGUARD_SLNO");dt_ITEM.Columns.Add("PRODUCT_SAFEGUARD_RATE");
                    dt_ITEM.Columns.Add("PRODUCT_SAFEGUARD_SPL");dt_ITEM.Columns.Add("PRODUCT_SAFEGUARD_UNIT");dt_ITEM.Columns.Add("PRODUCT_SAFEGUARD_SPL_TYPE");dt_ITEM.Columns.Add("PRODUCT_SAPTA_NOTN");
                    dt_ITEM.Columns.Add("PRODUCT_SAPTA_SLNO");dt_ITEM.Columns.Add("PRODUCT_SAPTA_RATE");dt_ITEM.Columns.Add("PRODUCT_TARIFF_NOTN");dt_ITEM.Columns.Add("PRODUCT_TARIFF_SLNO");
                    dt_ITEM.Columns.Add("PRODUCT_TARIFF_QTY");dt_ITEM.Columns.Add("PRODUCT_TARIFF_AMOUNT");dt_ITEM.Columns.Add("PRODUCT_TARIFF_AMOUNT_UNIT");dt_ITEM.Columns.Add("PRODUCT_CETH");dt_ITEM.Columns.Add("PRODUCT_MRP_YN");
                    dt_ITEM.Columns.Add("PRODUCT_MRP_SL_NO");dt_ITEM.Columns.Add("PRODUCT_MRP_AMOUNT");dt_ITEM.Columns.Add("PRODUCT_MRP_ABT_RATE");dt_ITEM.Columns.Add("PRODUCT_CVD_NOTN");dt_ITEM.Columns.Add("PRODUCT_CVD_SLNO");
                    dt_ITEM.Columns.Add("PRODUCT_CVD_RATE");dt_ITEM.Columns.Add("PRODUCT_CVD_SPL");dt_ITEM.Columns.Add("PRODUCT_CVD_UNIT");dt_ITEM.Columns.Add("PRODUCT_CVD_SPL_TYPE");dt_ITEM.Columns.Add("PRODUCT_CVD_EDU_CESS_RATE");
                    dt_ITEM.Columns.Add("PRODUCT_CVD_SEC_EDU_CESS_RATE");dt_ITEM.Columns.Add("PRODUCT_ADDL5_SIA_NOTN");dt_ITEM.Columns.Add("PRODUCT_ADDL5_SIA_NOTN_SL");dt_ITEM.Columns.Add("PRODUCT_ADDL5_SIA_RATE");
                    dt_ITEM.Columns.Add("PRODUCT_ADDL_GSI_NOTN");dt_ITEM.Columns.Add("PRODUCT_ADDL_GSI_SLNO");dt_ITEM.Columns.Add("PRODUCT_ADDL_GSI_RATE");dt_ITEM.Columns.Add("PRODUCT_ADDL_GSI_SPL");dt_ITEM.Columns.Add("PRODUCT_ADDL_GSI_UNIT");
                    dt_ITEM.Columns.Add("PRODUCT_ADDL_GSI_SPL_TYPE");dt_ITEM.Columns.Add("PRODUCT_ADDL_SHEII_NOTN");dt_ITEM.Columns.Add("PRODUCT_ADDL_SHEII_SLNO");dt_ITEM.Columns.Add("PRODUCT_ADDL_SHEII_RATE");dt_ITEM.Columns.Add("PRODUCT_ADDL_SHEII_SPL");
                    dt_ITEM.Columns.Add("PRODUCT_ADDL_SHEII_UNIT");dt_ITEM.Columns.Add("PRODUCT_ADDL_SHEII_TYPE");dt_ITEM.Columns.Add("PRODUCT_ADDL_TTA_NOTN");dt_ITEM.Columns.Add("PRODUCT_ADDL_TTA_SLNO");dt_ITEM.Columns.Add("PRODUCT_ADDL_TTA_RATE");
                    dt_ITEM.Columns.Add("PRODUCT_ADDL_TTA_SPL");dt_ITEM.Columns.Add("PRODUCT_ADDL_TTA_UNIT");dt_ITEM.Columns.Add("PRODUCT_ADDL_TTA_TYPE");dt_ITEM.Columns.Add("PRODUCT_ADDL_HEALTH_CESS_NOTN");dt_ITEM.Columns.Add("PRODUCT_ADDL_HEALTH_CESS_SLNO");
                    dt_ITEM.Columns.Add("PRODUCT_ADDL_HEALTH_CESS_RATE");dt_ITEM.Columns.Add("PRODUCT_ADDL_HEALTH_CESS_SPL");dt_ITEM.Columns.Add("PRODUCT_ADDL_HEALTH_CESS_UNIT");dt_ITEM.Columns.Add("PRODUCT_ADDL_HEALTH_CESS_TYPE");
                    dt_ITEM.Columns.Add("PRODUCT_CESS_NOTN");dt_ITEM.Columns.Add("PRODUCT_CESS_SLNO");dt_ITEM.Columns.Add("PRODUCT_CESS_RATE");dt_ITEM.Columns.Add("PRODUCT_CESS_SPL");dt_ITEM.Columns.Add("PRODUCT_CESS_UNIT");dt_ITEM.Columns.Add("PRODUCT_CESS_TYPE");
                    dt_ITEM.Columns.Add("ANTI_DUMPING_NOTN");dt_ITEM.Columns.Add("ANTI_DUMPING_NOTN_SLNO");dt_ITEM.Columns.Add("CTH_SLNO");dt_ITEM.Columns.Add("CTH_SUPPLIER_SLNO");dt_ITEM.Columns.Add("CTH_QTY");dt_ITEM.Columns.Add("RSP_DUTY_STATUS");
                    dt_ITEM.Columns.Add("RSP_SL_NO");dt_ITEM.Columns.Add("RSP_DESC");dt_ITEM.Columns.Add("RSP_QTY");dt_ITEM.Columns.Add("RSP_AMOUNT");dt_ITEM.Columns.Add("RSP_NOTN_NO");dt_ITEM.Columns.Add("RSP_NOTN_SL_NO");
                    dt_ITEM.Columns.Add("RSP_ABT_RATE");dt_ITEM.Columns.Add("WAREHOUSE_JOBNO");dt_ITEM.Columns.Add("WAREHOUSE_INVOICE_SLNO");dt_ITEM.Columns.Add("WAREHOUSE_ITEM_SLNO");dt_ITEM.Columns.Add("ASSESSABLE_VALUE");
                    dt_ITEM.Columns.Add("DUTY_VALUE");dt_ITEM.Columns.Add("CIF_VALUE");dt_ITEM.Columns.Add("CVD_VALUE");dt_ITEM.Columns.Add("USER_ID");dt_ITEM.Columns.Add("DATE_TIME");dt_ITEM.Columns.Add("STATUS");dt_ITEM.Columns.Add("BRANCH_CODE");
                    dt_ITEM.Columns.Add("YEAR");dt_ITEM.Columns.Add("WORKING_PERIOD");dt_ITEM.Columns.Add("BASIC_VALUE");dt_ITEM.Columns.Add("CEC_VALUE");dt_ITEM.Columns.Add("CHEC_VALUE");dt_ITEM.Columns.Add("ADD_DUTY_VALUE");dt_ITEM.Columns.Add("CETH_CVD_EDU_CESS_SL");
                    dt_ITEM.Columns.Add("CETH_CVD_EDU_CESS_RATE");dt_ITEM.Columns.Add("CETH_CVD_SEC_EDU_CESS_SL");dt_ITEM.Columns.Add("CETH_CVD_SEC_EDU_CESS_RATE");dt_ITEM.Columns.Add("PRODUCT_OTHER_DUTY_NOTN");dt_ITEM.Columns.Add("PRODUCT_OTHER_DUTY_SLNO");
                    dt_ITEM.Columns.Add("PRODUCT_OTHER_DUTY_RATE");dt_ITEM.Columns.Add("PRODUCT_OTHER_DUTY_SPL");dt_ITEM.Columns.Add("PRODUCT_OTHER_DUTY_UNIT");dt_ITEM.Columns.Add("PRODUCT_OTHER_DUTY_TYPE");dt_ITEM.Columns.Add("MODIFIEDBY");dt_ITEM.Columns.Add("MODIFIEDON");
                    dt_ITEM.Columns.Add("INDIVITUAL_FREIGHT_AMOUNT");dt_ITEM.Columns.Add("INDIVITUAL_INSURANCE_AMOUNT");dt_ITEM.Columns.Add("INDIVITUAL_MISC_AMOUNT");dt_ITEM.Columns.Add("SVB_RELATION");dt_ITEM.Columns.Add("SVB_REF_NO");dt_ITEM.Columns.Add("SVB_REF_DATE");
                    dt_ITEM.Columns.Add("SVB_CUSTOM_HOUSE");dt_ITEM.Columns.Add("SVB_LOADING_ON");dt_ITEM.Columns.Add("SVB_ASSESABLE_RATE");dt_ITEM.Columns.Add("SVB_DUTY_RATE");dt_ITEM.Columns.Add("SVB_ASSESABLE_STATUS");dt_ITEM.Columns.Add("SVB_DUTY_STATUS");
                    dt_ITEM.Columns.Add("INDIVITUAL_EDU_CESS_AMT");dt_ITEM.Columns.Add("INDIVITUAL_SEC_HIGHER_CESS_AMT");dt_ITEM.Columns.Add("INDIVITUAL_LANDING_CHARGE");dt_ITEM.Columns.Add("CHECKLIST_BCD_RATE");dt_ITEM.Columns.Add("CHECKLIST_CVD_RATE");
                    dt_ITEM.Columns.Add("CHECKLIST_ADDL_DUTY_RATE");dt_ITEM.Columns.Add("INDEV_RACK_TYPE");dt_ITEM.Columns.Add("MERIT_DUTY_VALUE");dt_ITEM.Columns.Add("RSP_APPLICABLE");dt_ITEM.Columns.Add("CENTRAL_EXCISE_FLAG");dt_ITEM.Columns.Add("MANUFACTURER_PRODUCER");
                    dt_ITEM.Columns.Add("M_P_GROWER_CODE");dt_ITEM.Columns.Add("M_P_GROWER_ADD1");dt_ITEM.Columns.Add("M_P_GROWER_ADD2");dt_ITEM.Columns.Add("M_P_GROWER_CITY");dt_ITEM.Columns.Add("M_P_GROWER_COUNTRY_SUBDIV");dt_ITEM.Columns.Add("M_P_GROWER_PIN");
                    dt_ITEM.Columns.Add("M_P_GROWER_COUNTRY");dt_ITEM.Columns.Add("SOURCE_COUNTRY");dt_ITEM.Columns.Add("TRANSIT_COUNTRY");dt_ITEM.Columns.Add("ACCESSORY_STATUS");dt_ITEM.Columns.Add("INFRA_CESS_NOTN");dt_ITEM.Columns.Add("INFRA_CESS_NOTN_SL");
                    dt_ITEM.Columns.Add("INFRA_CESS_NOTN_RATE");dt_ITEM.Columns.Add("MERIT_BASIC_VALUE");dt_ITEM.Columns.Add("MERIT_CVD_VALUE");dt_ITEM.Columns.Add("MERIT_CEC_VALUE");dt_ITEM.Columns.Add("MERIT_CHEC_VALUE");dt_ITEM.Columns.Add("MERIT_ADD_DUTY_VALUE");
                    dt_ITEM.Columns.Add("MERIT_NOTN_BASIC_VALUE");dt_ITEM.Columns.Add("MERIT_NOTN_CVD_VALUE");dt_ITEM.Columns.Add("MERIT_NOTN_CEC_VALUE");dt_ITEM.Columns.Add("MERIT_NOTN_CHEC_VALUE");dt_ITEM.Columns.Add("MERIT_NOTN_ADD_DUTY_VALUE");dt_ITEM.Columns.Add("MERIT_NOTN_CESS_VALUE");
                    dt_ITEM.Columns.Add("MERIT_NOTN_NCD_VALUE");dt_ITEM.Columns.Add("INDIVITUAL_HSS_AMOUNT");dt_ITEM.Columns.Add("IGST_LEVY_NOTN");dt_ITEM.Columns.Add("IGST_LEVY_SLNO"); dt_ITEM.Columns.Add("IGST_LEVY_RATE");dt_ITEM.Columns.Add("IGST_LEVY_SPL");
                    dt_ITEM.Columns.Add("IGST_LEVY_UNIT");dt_ITEM.Columns.Add("IGST_LEVY_SPL_TYPE");dt_ITEM.Columns.Add("IGST_LEVY_EXCEPTION_NOTN");dt_ITEM.Columns.Add("IGST_LEVY_EXCEPTION_SLNO");dt_ITEM.Columns.Add("IGST_LEVY_EXCEPTION_RATE");dt_ITEM.Columns.Add("IGST_LEVY_COMPENSATION_CESS_NOTN");
                    dt_ITEM.Columns.Add("IGST_LEVY_COMPENSATION_CESS_SLNO");dt_ITEM.Columns.Add("IGST_LEVY_COMPENSATION_CESS_RATE");dt_ITEM.Columns.Add("IGST_LEVY_COMPENSATION_CESS_SPL");dt_ITEM.Columns.Add("IGST_LEVY_COMPENSATION_CESS_UNIT");
                    dt_ITEM.Columns.Add("IGST_LEVY_COMPENSATION_CESS_SPL_TYPE");dt_ITEM.Columns.Add("IGST_LEVY_EXCEPTION_CC_NOTN");dt_ITEM.Columns.Add("IGST_LEVY_EXCEPTION_CC_SLNO");dt_ITEM.Columns.Add("IGST_LEVY_EXCEPTION_CC_RATE");dt_ITEM.Columns.Add("LEVY_EXCEMPTION_NOTN_TYPE");
                    dt_ITEM.Columns.Add("LEVY_EXCEPTION_CC_NOTN_TYPE");dt_ITEM.Columns.Add("CHECKLIST_IGST_LEVY_AMOUNT"); dt_ITEM.Columns.Add("CHECKLIST_COMPENSATION_CC_AMOUNT"); dt_ITEM.Columns.Add("SOCIAL_WELFARE_NOTN");dt_ITEM.Columns.Add("SOCIAL_WELFARE_NOTN_SLNO");
                    dt_ITEM.Columns.Add("SOCIAL_WELFARE_RATE"); dt_ITEM.Columns.Add("CHECKLIST_SOCIAL_WELFARE_AMT");dt_ITEM.Columns.Add("CHECKLIST_HEALTH_CESS_AMT");dt_ITEM.Columns.Add("CHECKLIST_ANTI_DUMPING_AMT");dt_ITEM.Columns.Add("AMENDMENT_TYPE");dt_ITEM.Columns.Add("AMENDMENT_STATUS");
                    dt_ITEM.Columns.Add("AIDC_NOTN");dt_ITEM.Columns.Add("AIDC_NOTN_SLNO");dt_ITEM.Columns.Add("AIDC_RATE");dt_ITEM.Columns.Add("AIDC_CHECKLIST_AMT");dt_ITEM.Columns.Add("ADD_EX_RATE");dt_ITEM.Columns.Add("EXC_AIDC_NOTN");
                    dt_ITEM.Columns.Add("EXC_AIDC_NOTN_SLNO");dt_ITEM.Columns.Add("EXC_AIDC_RATE");dt_ITEM.Columns.Add("EXC_AIDC_CHECKLIST_AMT");dt_ITEM.Columns.Add("CHK_IGST_ASSBL_VAL");dt_ITEM.Columns.Add("BCD_FOREGONE_AMT");dt_ITEM.Columns.Add("TOTAL_DUTY_FOREGONE_AMT");dt_ITEM.Columns.Add("JOBNO_PS");

                    ln = pos + 1;
                    string invoic_cur="";
                    for (ln = ln; ln < lines.Length - 1; ln++)
                    {
                        if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-BE>"))))
                        {                            
                            string invno_fromfile = "";
                            lnItm = lines[ln].ToString().Split('^');
                            if (lnItm.Length >= 90)
                            {
                                double itm_amt = Convert.ToDouble(lnItm[8]) * Convert.ToDouble(lnItm[58]);

                                if (dt_INV.Rows.Count > 0)
                                {                                    
                                    DataRow[] dr = dt_INV.Select("INVOICE_SLNO = '" + lnItm[6].ToString() + "' ");

                                    if (dr.Length > 0)
                                    {
                                        invno_fromfile = dr[0].ItemArray[3].ToString().Trim();
                                        invoic_cur = dr[0].ItemArray[6].ToString().Trim();
                                    }
                                }

                                if (lnItm[13].ToString() == "")
                                {
                                    lnItm[13] = "00 - DUTIABLE";
                                }
                                
                                string formattedDate5 = (lnItm[76].ToString().Length >= 8) ? lnItm[76].ToString().Substring(6, 2) + "/" + lnItm[76].ToString().Substring(4, 2) + "/" + lnItm[76].ToString().Substring(0, 4) : "01/01/1900";
                                string formattedDate4 = (lnItm[64].ToString().Length >= 8) ? lnItm[64].ToString().Substring(6, 2) + "/" + lnItm[64].ToString().Substring(4, 2) + "/" + lnItm[64].ToString().Substring(0, 4) : "01/01/1900";
                                item_country = item_country+ "~" +lnItm[20].ToString();
                                Schem_code = Schem_code + "~" + lnItm[13].ToString();
                                Ritc = Ritc + "~" + lnItm[10].ToString();

                                dt_ITEM.Rows.Add(IMP_ITEM_ID, Convert.ToInt64(txtJobNo), Convert.ToInt64(lnItm[6].ToString()), invno_fromfile, Convert.ToInt64(lnItm[7].ToString()), lnItm[11].ToString() + "" + lnItm[12].ToString(),
                                lnItm[8].ToString(), lnItm[9].ToString(), lnItm[58].ToString(), invoic_cur, itm_amt, invoic_cur, lnItm[10].ToString(), lnItm[13].ToString(),"","",
                                lnItm[61].ToString(), lnItm[9].ToString(), lnItm[62].ToString(), lnItm[9].ToString(), lnItm[14].ToString(), lnItm[16].ToString(), lnItm[17].ToString(), lnItm[18].ToString(), lnItm[19].ToString(),
                                lnItm[20].ToString(), lnItm[15].ToString(), lnItm[75].ToString(), formattedDate5, lnItm[77].ToString(), lnItm[78].ToString(), lnItm[79].ToString(), lnItm[21].ToString(), lnItm[21].ToString(), lnItm[24].ToString(),
                                lnItm[25].ToString(),"","","","", lnItm[52].ToString(), lnItm[53].ToString(),"", lnItm[34].ToString(), lnItm[35].ToString(),"","","","", lnItm[38].ToString(), lnItm[39].ToString(),"","","","",
                                lnItm[54].ToString(), lnItm[55].ToString(),"", lnItm[56].ToString(), lnItm[57].ToString(),"","","","", lnItm[48].ToString(), lnItm[49].ToString(),"", lnItm[45].ToString(), lnItm[46].ToString(),
                                lnItm[47].ToString(),"","", lnItm[21].ToString(),"","","","", lnItm[26].ToString(), lnItm[27].ToString(),"","","","", lnItm[36].ToString(),"","","","", lnItm[28].ToString(), lnItm[29].ToString(),"","","","",
                                lnItm[30].ToString(), lnItm[31].ToString(),"","","","", lnItm[32].ToString(), lnItm[33].ToString(),"","","","", lnItm[50].ToString(), lnItm[51].ToString(),"","","","","","","","","","",                               
                                lnItm[40].ToString(), lnItm[41].ToString(), lnItm[42].ToString(), lnItm[43].ToString(), lnItm[44].ToString(),"","","","","","","","","0","0","0","","","","",
                                currentuser, cur_date,"N", currentbranch,"", Working_Period,"","","","", lnItm[37].ToString(),"","","","","","","","","", currentuser, cur_date,"","","",
                               "", lnItm[63].ToString(), formattedDate4, lnItm[70].ToString(), lnItm[67].ToString(), lnItm[65].ToString(), lnItm[66].ToString(), lnItm[68].ToString(), lnItm[69].ToString(),"","","","","","","","", lnItm[73].ToString(), lnItm[80].ToString(), lnItm[81].ToString(), lnItm[82].ToString(), lnItm[83].ToString(), lnItm[84].ToString(),
                                lnItm[85].ToString(), lnItm[86].ToString(), lnItm[87].ToString(), lnItm[88].ToString(), lnItm[89].ToString(), lnItm[90].ToString(), lnItm[91].ToString(),"","","","","","","","",
                               "","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","");

                                IMP_ITEM_ID = IMP_ITEM_ID + 1;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    #endregion dt_Item

                    pos = ln + 1;
                    break;
                }
            }

            for (int ln = 0; ln < lines.Length; ln++)
            {
                string[] lnItm;
                pos = Array.IndexOf(lines, "<TABLE>DEPB");

                if (result == 1 && pos > 0)
                {
                    #region dt_Schm
                    dt_Schm.Columns.Add("INVOICE_SLNO"); dt_Schm.Columns.Add("ITEM_SLNO"); dt_Schm.Columns.Add("SCHEME_NOTN_NEW");
                    dt_Schm.Columns.Add("SCHEME_NOTN_SLNO_NEW"); 

                    ln = pos + 1;

                    for (ln = ln; ln < lines.Length - 1; ln++)
                    {
                        if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-BE>"))))
                        {

                            lnItm = lines[ln].ToString().Split('^');
                            if (lnItm.Length >= 9)
                            {
                                dt_Schm.Rows.Add(lnItm[6].ToString(), lnItm[7].ToString(), lnItm[9].ToString(), lnItm[10].ToString());
                            }
                        }

                        else
                        {
                            break;
                        }
                    }

                    #endregion dt_Schm
                    pos = ln + 1;
                    break;
                }
            }

            for (int ln = 0; ln < lines.Length; ln++)
            {
                string[] lnItm;
                pos = Array.IndexOf(lines, "<TABLE>SBEDUTY");

                if (result == 1 && pos > 0)
                {
                    #region dt_Igst
                    dt_Igst.Columns.Add("INVOICE_SLNO"); dt_Igst.Columns.Add("ITEM_SLNO"); dt_Igst.Columns.Add("IGST_LEVY_NOTN_NEW"); dt_Igst.Columns.Add("IGST_LEVY_SLNO_NEW");
                    dt_Igst.Columns.Add("IGST_LEVY_TYPE1"); dt_Igst.Columns.Add("IGST_LEVY_TYPE2");
                    dt_Igst.Columns.Add("IGST_LEVY_EXCEPTION_NOTN_NEW"); dt_Igst.Columns.Add("IGST_LEVY_EXCEPTION_SLNO_NEW"); dt_Igst.Columns.Add("IGST_LEVY_TYPE3");

                    dt_Igst.Columns.Add("IGST_LEVY_COMPENSATION_CESS_NOTN_NEW"); dt_Igst.Columns.Add("IGST_LEVY_COMPENSATION_CESS_SLNO_NEW");
                    dt_Igst.Columns.Add("IGST_LEVY_EXCEPTION_CC_NOTN_NEW"); dt_Igst.Columns.Add("IGST_LEVY_EXCEPTION_CC_SLNO_NEW"); dt_Igst.Columns.Add("PRODUCT_OTHER_DUTY_NOTN_NEW"); 
                    dt_Igst.Columns.Add("PRODUCT_OTHER_DUTY_SLNO_NEW");
                    dt_Igst.Columns.Add("PRODUCT_ADDL_HEALTH_CESS_NOTN_NEW"); dt_Igst.Columns.Add("PRODUCT_ADDL_HEALTH_CESS_SLNO_NEW"); dt_Igst.Columns.Add("AIDC_NOTN_NEW");
                    dt_Igst.Columns.Add("AIDC_NOTN_SLNO_NEW"); dt_Igst.Columns.Add("EXC_AIDC_NOTN_NEW"); dt_Igst.Columns.Add("EXC_AIDC_NOTN_SLNO_NEW");
                   
                    ln = pos + 1;

                    for (ln = ln; ln < lines.Length - 1; ln++)
                    {
                        if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-BE>"))))
                        {
                            lnItm = lines[ln].ToString().Split('^');
                            if (lnItm.Length >= 12)
                            {
                                dt_Igst.Rows.Add(lnItm[6].ToString(), lnItm[7].ToString(), lnItm[8].ToString(), lnItm[9].ToString(), lnItm[10].ToString(), lnItm[11].ToString(), lnItm[12].ToString(), lnItm[13].ToString(),lnItm[14].ToString(),
                                   "","","","","","","","","","","","");                              
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    #endregion dt_Igst
                    pos = ln + 1;
                    break;
                }
            }
            if (dt_ITEM.Rows.Count > 0)
            {
                if (dt_Schm.Rows.Count > 0)
                {
                    foreach (DataRow row in dt_ITEM.Rows)
                    {
                        DataRow[] query_Info1 = dt_Schm.Select("ITEM_SLNO='" + row.Field<string>("ITEM_SLNO") + "' and INVOICE_SLNO='" + row.Field<string>("INVOICE_SLNO") + "'");
                        if (query_Info1 != null && query_Info1.Length >= 1)
                        {
                            row.SetField("SCHEME_NOTN", query_Info1[0][2].ToString()); row.SetField("SCHEME_NOTN_SLNO", query_Info1[0][3].ToString());
                        }
                    }
                }
                #region Gst_Insert
               
                if (dt_Igst.Rows.Count > 0)
                {
                    foreach (DataRow itemRow in dt_ITEM.Rows)
                    {
                        foreach (DataRow igstRow in dt_Igst.Rows)
                        {
                            if (itemRow.Field<string>("ITEM_SLNO") == igstRow.Field<string>("ITEM_SLNO") && itemRow.Field<string>("INVOICE_SLNO") == igstRow.Field<string>("INVOICE_SLNO"))                                
                            {
                                string exceptionType = igstRow[4].ToString();
                                string exceptionCode = igstRow[5].ToString();

                                if (exceptionType == "G" && exceptionCode == "I")
                                {
                                    itemRow.SetField("IGST_LEVY_NOTN", igstRow[2].ToString()); itemRow.SetField("IGST_LEVY_SLNO", igstRow[3].ToString());
                                    itemRow.SetField("IGST_LEVY_EXCEPTION_NOTN", igstRow[6].ToString()); itemRow.SetField("IGST_LEVY_EXCEPTION_SLNO", igstRow[7].ToString());                                    
                                }
                                else if (exceptionType == "G" && exceptionCode == "P")
                                {
                                    itemRow.SetField("IGST_LEVY_COMPENSATION_CESS_NOTN", igstRow[2].ToString()); itemRow.SetField("IGST_LEVY_COMPENSATION_CESS_SLNO", igstRow[3].ToString());
                                    itemRow.SetField("IGST_LEVY_EXCEPTION_CC_NOTN", igstRow[6].ToString()); itemRow.SetField("IGST_LEVY_EXCEPTION_CC_SLNO", igstRow[7].ToString());                                    
                                }
                                else if (exceptionType == "E" && exceptionCode == "X")
                                {
                                    itemRow.SetField("PRODUCT_OTHER_DUTY_NOTN", igstRow[2].ToString()); itemRow.SetField("PRODUCT_OTHER_DUTY_SLNO", igstRow[3].ToString());                                   
                                }
                                else if (exceptionType == "C" && exceptionCode == "+")
                                {
                                    itemRow.SetField("PRODUCT_ADDL_HEALTH_CESS_NOTN", igstRow[2].ToString()); itemRow.SetField("PRODUCT_ADDL_HEALTH_CESS_SLNO", igstRow[3].ToString());                                    
                                }
                                else if (exceptionType == "C" && exceptionCode == "A")
                                {
                                    itemRow.SetField("AIDC_NOTN", igstRow[2].ToString()); itemRow.SetField("AIDC_NOTN_SLNO", igstRow[3].ToString());                                    
                                }
                                else if (exceptionType == "E" && exceptionCode == "A")
                                {
                                    itemRow.SetField("EXC_AIDC_NOTN", igstRow[2].ToString()); itemRow.SetField("EXC_AIDC_NOTN_SLNO", igstRow[3].ToString());                                    
                                }
                            }
                        }
                    }
                }

                #endregion Gst_Insert

                admin.SqlBulk_Upload_Product("ITEM_PRODUCT_DETAILS", dt_ITEM, comp_ConnectionStr);
            }

        }
            catch (Exception ex)
            {
                ErrorLogs er = new ErrorLogs();
                er.makeLog(ex.Message);

                Imp.JOBNO = txtJobNo;
                Imp.BRANCH_CODE = Connection.Get_Company_Type();
                Imp.flag = "Delete_All_Table";
                Gen_Ms = Imp.Update_Gen_Ms_Inv_Item_Details();
            }

            //****************************** end of item ************************/////

            //******************************Start License details************************/////
            #region license
            for (int ln = 0; ln < lines.Length; ln++)
            {
                string[] lnItm;
              
                pos = Array.IndexOf(lines, "<TABLE>LICENCE");

                if (result == 1 && pos > 0)
                {

                    dt_LICNESE.Columns.Add("LICENSE_ID"); dt_LICNESE.Columns.Add("JOBNO"); dt_LICNESE.Columns.Add("INVOICE_SLNO"); dt_LICNESE.Columns.Add("ITEM_SLNO"); dt_LICNESE.Columns.Add("SCHEME_CODE"); 
                    dt_LICNESE.Columns.Add("LICENSE_SLNO"); dt_LICNESE.Columns.Add("REGISTRATION_NO"); dt_LICNESE.Columns.Add("REGISTRATION_DATE"); dt_LICNESE.Columns.Add("EXCEMPTION"); 
                    dt_LICNESE.Columns.Add("DEBIT_AMT"); dt_LICNESE.Columns.Add("DEBIT_QTY"); dt_LICNESE.Columns.Add("UNIT_QTY"); dt_LICNESE.Columns.Add("LICENSE_ITEM_NO"); dt_LICNESE.Columns.Add("PORT_OF_LICENSE");
                    dt_LICNESE.Columns.Add("USER_ID"); dt_LICNESE.Columns.Add("DATE_TIME"); dt_LICNESE.Columns.Add("STATUS"); dt_LICNESE.Columns.Add("BRANCH_CODE"); dt_LICNESE.Columns.Add("YEAR");
                    dt_LICNESE.Columns.Add("WORKING_PERIOD"); dt_LICNESE.Columns.Add("DEBIT_DUTY"); dt_LICNESE.Columns.Add("LICENSE_NO"); dt_LICNESE.Columns.Add("LICENSE_DATE"); dt_LICNESE.Columns.Add("MODIFIEDBY");
                    dt_LICNESE.Columns.Add("MODIFIEDON"); dt_LICNESE.Columns.Add("TOTAL_CIF_VALUE"); dt_LICNESE.Columns.Add("TOTAL_DEBIT_DUTY"); dt_LICNESE.Columns.Add("ENTRY_DEBIT_DUTY");
                    dt_LICNESE.Columns.Add("LIC_DESC"); dt_LICNESE.Columns.Add("LICENSE_CURRENCY"); dt_LICNESE.Columns.Add("EX_RATE"); dt_LICNESE.Columns.Add("JOBNO_PS");
                   
                    ln = pos + 1;
                    try
                    {
                        for (ln = ln; ln < lines.Length - 1; ln++)
                        {
                            if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-BE>"))))
                            {
                                lnItm = lines[ln].ToString().Split('^');
                                if (lnItm.Length > 15)
                                {
                                    formattedDate1 = (lnItm[13].ToString().Length >= 8) ? lnItm[13].ToString().Substring(6, 2) + "/" + lnItm[13].ToString().Substring(4, 2) + "/" + lnItm[13].ToString().Substring(0, 4) : "01/01/1900";

                                    dt_LICNESE.Rows.Add(LIC_ID, Convert.ToInt64(txtJobNo), Convert.ToInt64(lnItm[6].ToString()), lnItm[7].ToString(), lnItm[14].ToString(), lnItm[8].ToString(), lnItm[12].ToString(),
                                    formattedDate1, "Y", lnItm[9].ToString(), lnItm[10].ToString(), lnItm[11].ToString(), lnItm[8].ToString(), lnItm[15].ToString(), currentuser, cur_date, "N",
                                    currentbranch, "", Working_Period, "", lnItm[12].ToString(), formattedDate1, "", "01/01/1900", "", "", "", "", "", "", "");

                                    LIC_ID = LIC_ID + 1;
                                }

                            }
                            else
                            {
                                break;
                            }
                        }

                        if (dt_LICNESE.Rows.Count > 0)
                        {
                            admin.SqlBulk_Upload_Product("LICENSE_DETAILS", dt_LICNESE, comp_ConnectionStr);
                        }
                        pos = ln + 1;
                        break;
                    }
                    catch (Exception ex)
                    {
                        ErrorLogs er = new ErrorLogs();
                        er.makeLog(ex.Message);

                        Imp.JOBNO = txtJobNo;
                        Imp.BRANCH_CODE = Connection.Get_Company_Type();
                        Imp.flag = "Delete_All_Table";
                        Gen_Ms = Imp.Update_Gen_Ms_Inv_Item_Details();
                    }
                }
            }
            #endregion license

            ////********************************** End of License Details *********************///

            //****************************** Start Reimport details ************************/////
            #region reimprt
            for (int ln = 0; ln < lines.Length; ln++)
            {
                string[] lnItm;

                pos = Array.IndexOf(lines, "<TABLE>REIMPORT");

                if (result == 1 && pos > 0)
                {
                    dt_REIMP.Columns.Add("RE_IMPORT_ID"); dt_REIMP.Columns.Add("RE_IMPORT_SLNO"); dt_REIMP.Columns.Add("JOBNO"); dt_REIMP.Columns.Add("INVOICE_SLNO"); 
                    dt_REIMP.Columns.Add("INVOICE_NO"); dt_REIMP.Columns.Add("ITEM_SLNO"); dt_REIMP.Columns.Add("SB_NO"); dt_REIMP.Columns.Add("SB_DATE"); 
                    dt_REIMP.Columns.Add("PORT_EXPORT"); dt_REIMP.Columns.Add("SB_INVOICE_NO"); dt_REIMP.Columns.Add("SB_INVOICE__ITEM_NO"); dt_REIMP.Columns.Add("NOTN_NO"); 
                    dt_REIMP.Columns.Add("NOTN_SLNO"); dt_REIMP.Columns.Add("EXPORT_FREIGHT"); dt_REIMP.Columns.Add("EXPORT_INSURANCE"); dt_REIMP.Columns.Add("CUSTOMS_DUTY"); 
                    dt_REIMP.Columns.Add("EXCISE_DUTY"); dt_REIMP.Columns.Add("USER_ID"); dt_REIMP.Columns.Add("DATE_TIME"); dt_REIMP.Columns.Add("STATUS"); dt_REIMP.Columns.Add("BRANCH_CODE"); 
                    dt_REIMP.Columns.Add("YEAR"); dt_REIMP.Columns.Add("WORKING_PERIOD"); dt_REIMP.Columns.Add("MODIFIEDBY"); dt_REIMP.Columns.Add("MODIFIEDON");

                    ln = pos + 1;
                    int Reimp_Sl=1;
                    string invno = "";
                    try
                    {
                        for (ln = ln; ln < lines.Length - 1; ln++)
                        {
                            if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-BE>"))))
                            {
                                lnItm = lines[ln].ToString().Split('^');
                                if (lnItm.Length >= 18)
                                {
                                    if (dt_INV.Rows.Count > 0)
                                    {
                                        DataRow[] dr = dt_INV.Select("INVOICE_SLNO = '" + lnItm[6].ToString() + "' ");

                                        if (dr.Length > 0)
                                        {
                                            invno = dr[0].ItemArray[3].ToString().Trim();

                                        }
                                    }
                                    string sb_date = (lnItm[9].ToString().Length >= 8) ? lnItm[9].ToString().Substring(6, 2) + "/" + lnItm[9].ToString().Substring(4, 2) + "/" + lnItm[9].ToString().Substring(0, 4) : "01/01/1900";

                                    dt_REIMP.Rows.Add(REIMP_ID, Reimp_Sl, Convert.ToInt64(txtJobNo), lnItm[6].ToString(), invno, lnItm[7].ToString(), lnItm[8].ToString(), sb_date, lnItm[10].ToString(), lnItm[11].ToString(),
                                    lnItm[12].ToString(), lnItm[13].ToString(), lnItm[14].ToString(), lnItm[15].ToString(), lnItm[16].ToString(), lnItm[17].ToString(), lnItm[18].ToString(),
                                    currentuser, cur_date, "N", currentbranch, "", Working_Period, "", "01/01/1900");


                                    REIMP_ID = REIMP_ID + 1;
                                    Reimp_Sl = Reimp_Sl + 1;
                                }

                            }
                            else
                            {
                                break;
                            }
                        }

                        if (dt_REIMP.Rows.Count > 0)
                        {
                            admin.SqlBulk_Upload_Product("RE_IMPORT_DETAILS", dt_REIMP, comp_ConnectionStr);
                        }
                        pos = ln + 1;
                        break;

                    }
                    catch (Exception ex)
                    {
                        ErrorLogs er = new ErrorLogs();
                        er.makeLog(ex.Message);

                        Imp.JOBNO = txtJobNo;
                        Imp.BRANCH_CODE = Connection.Get_Company_Type();
                        Imp.flag = "Delete_All_Table";
                        Gen_Ms = Imp.Update_Gen_Ms_Inv_Item_Details();
                    }
                }
            }
            #endregion reimprt
            //****************************** End Reimport details ************************/////

            //****************************** Start SW Info details ************************/////
            #region SW_Info
            for (int ln = 0; ln < lines.Length; ln++)
            {
                string[] lnItm;

                pos = Array.IndexOf(lines, "<TABLE>BE_ITEM_SW_INFO_TYPE"); // department need to update 

                if (result == 1 && pos > 0)
                {
                    dt_SW_INFO.Columns.Add("SW_INFO_TYPE_ID"); dt_SW_INFO.Columns.Add("JOBNO"); dt_SW_INFO.Columns.Add("INVOICE_SLNO"); dt_SW_INFO.Columns.Add("ITEM_SLNO");
                    dt_SW_INFO.Columns.Add("INFO_TYPE"); dt_SW_INFO.Columns.Add("INFO_QUALIFIER"); dt_SW_INFO.Columns.Add("INFO_CODE"); dt_SW_INFO.Columns.Add("INFO_TEXT");
                    dt_SW_INFO.Columns.Add("INFO_MSR"); dt_SW_INFO.Columns.Add("INFO_UQC"); dt_SW_INFO.Columns.Add("USER_ID"); dt_SW_INFO.Columns.Add("DATE_TIME"); dt_SW_INFO.Columns.Add("STATUS");
                    dt_SW_INFO.Columns.Add("BRANCH_CODE"); dt_SW_INFO.Columns.Add("YEAR"); dt_SW_INFO.Columns.Add("WORKING_PERIOD"); dt_SW_INFO.Columns.Add("MODIFIEDBY");
                    dt_SW_INFO.Columns.Add("MODIFIEDON"); dt_SW_INFO.Columns.Add("DEPARTMENT"); dt_SW_INFO.Columns.Add("I_U_TYPE"); dt_SW_INFO.Columns.Add("REGN_DATE");
                    dt_SW_INFO.Columns.Add("REGN_VALIDITY"); dt_SW_INFO.Columns.Add("AMENDMENT_TYPE"); dt_SW_INFO.Columns.Add("AMENDMENT_STATUS");

                    ln = pos + 1;
                    try
                    {
                        for (ln = ln; ln < lines.Length - 1; ln++)
                        {
                            if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-BE>"))))
                            {
                                lnItm = lines[ln].ToString().Split('^');
                                if (lnItm.Length >= 14)
                                {
                                    dt_SW_INFO.Rows.Add(SW_IFNO_ID, Convert.ToInt64(txtJobNo), lnItm[6].ToString(), lnItm[7].ToString(), lnItm[8].ToString(), lnItm[9].ToString(), lnItm[10].ToString(),
                                    lnItm[11].ToString(), lnItm[12].ToString(), lnItm[13].ToString(),
                                    currentuser, cur_date, "N", currentbranch, "", Working_Period, "", "01/01/1900", "", "", "01/01/1900", "", "", "");

                                    SW_IFNO_ID = SW_IFNO_ID + 1;
                                }

                            }
                            else
                            {
                                break;
                            }
                        }

                        if (dt_SW_INFO.Rows.Count > 0)
                        {
                            admin.SqlBulk_Upload_Product("BE_ITEM_SW_INFO_TYPE", dt_SW_INFO, comp_ConnectionStr);
                        }
                        pos = ln + 1;
                        break;
                    }
                    catch (Exception ex)
                    {
                        ErrorLogs er = new ErrorLogs();
                        er.makeLog(ex.Message);

                        Imp.JOBNO = txtJobNo;
                        Imp.BRANCH_CODE = Connection.Get_Company_Type();
                        Imp.flag = "Delete_All_Table";
                        Gen_Ms = Imp.Update_Gen_Ms_Inv_Item_Details();
                    }
                }
            }
            #endregion SW_Info
            //****************************** End SW Info details ************************/////

            //****************************** Start SW Control details ************************/////
            #region SW_Contl
            for (int ln = 0; ln < lines.Length; ln++)
            {
                string[] lnItm;

                pos = Array.IndexOf(lines, "<TABLE>BE_ITEM_SW_CTRL"); //  need to update ivn&itm slno as 1 1 

                if (result == 1 && pos > 0)
                {
                    dt_SW_CTRL.Columns.Add("SW_CONTROL_ID"); dt_SW_CTRL.Columns.Add("JOBNO"); dt_SW_CTRL.Columns.Add("INVOICE_SLNO"); dt_SW_CTRL.Columns.Add("ITEM_SLNO");
                    dt_SW_CTRL.Columns.Add("CONTROL_TYPE_CODE"); dt_SW_CTRL.Columns.Add("CONTROL_LOCATION"); dt_SW_CTRL.Columns.Add("CONTROL_START_DATE");
                    dt_SW_CTRL.Columns.Add("CONTROL_END_DATE"); dt_SW_CTRL.Columns.Add("CONTROL_RESULT_CODE"); dt_SW_CTRL.Columns.Add("CONTROL_RESULT_TEXT"); 
                    dt_SW_CTRL.Columns.Add("USER_ID"); dt_SW_CTRL.Columns.Add("DATE_TIME"); dt_SW_CTRL.Columns.Add("STATUS"); dt_SW_CTRL.Columns.Add("BRANCH_CODE"); 
                    dt_SW_CTRL.Columns.Add("YEAR"); dt_SW_CTRL.Columns.Add("WORKING_PERIOD"); dt_SW_CTRL.Columns.Add("MODIFIEDBY"); dt_SW_CTRL.Columns.Add("MODIFIEDON"); 
                    dt_SW_CTRL.Columns.Add("CONTROL_MSR"); dt_SW_CTRL.Columns.Add("CONTROL_UQC"); dt_SW_CTRL.Columns.Add("CONTROL_SLNO"); 
                    dt_SW_CTRL.Columns.Add("AMENDMENT_TYPE"); dt_SW_CTRL.Columns.Add("AMENDMENT_STATUS");

                    ln = pos + 1;
                    try
                    {
                        for (ln = ln; ln < lines.Length - 1; ln++)
                        {
                            if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-BE>"))))
                            {
                                lnItm = lines[ln].ToString().Split('^');
                                if (lnItm.Length >= 13)
                                {
                                    string cntstart_date = (lnItm[10].ToString().Length >= 8) ? lnItm[10].ToString().Substring(6, 2) + "/" + lnItm[10].ToString().Substring(4, 2) + "/" + lnItm[10].ToString().Substring(0, 4) : "01/01/1900";
                                    string cntend_date = (lnItm[11].ToString().Length >= 8) ? lnItm[11].ToString().Substring(6, 2) + "/" + lnItm[11].ToString().Substring(4, 2) + "/" + lnItm[11].ToString().Substring(0, 4) : "01/01/1900";

                                    dt_SW_CTRL.Rows.Add(SW_IFNO_ID, Convert.ToInt64(txtJobNo), lnItm[6].ToString(), lnItm[7].ToString(), lnItm[8].ToString(), lnItm[9].ToString(),
                                    cntstart_date, cntend_date, lnItm[12].ToString(), lnItm[13].ToString(), currentuser, cur_date, "N", currentbranch, "",
                                    Working_Period, "", "01/01/1900", lnItm[14].ToString(), lnItm[15].ToString(), lnItm[16].ToString(), "", "");

                                    SW_IFNO_ID = SW_IFNO_ID + 1;
                                }

                            }
                            else
                            {
                                break;
                            }
                        }

                        if (dt_SW_CTRL.Rows.Count > 0)
                        {
                            admin.SqlBulk_Upload_Product("BE_ITEM_SW_CONTROL", dt_SW_CTRL, comp_ConnectionStr);
                        }
                        pos = ln + 1;
                        break;
                    }
                    catch (Exception ex)
                    {
                        ErrorLogs er = new ErrorLogs();
                        er.makeLog(ex.Message);

                        Imp.JOBNO = txtJobNo;
                        Imp.BRANCH_CODE = Connection.Get_Company_Type();
                        Imp.flag = "Delete_All_Table";
                        Gen_Ms = Imp.Update_Gen_Ms_Inv_Item_Details();
                    }
                }
            }
            #endregion SW_Contl
            //****************************** End SW Control details ************************/////


            //****************************** Start SW Const details ************************/////
            #region SW_Const
            for (int ln = 0; ln < lines.Length; ln++)
            {
                string[] lnItm;

                pos = Array.IndexOf(lines, "<TABLE>BE_ITEM_SW_CONST"); 

                if (result == 1 && pos > 0)
                {
                    dt_CONST.Columns.Add("SW_CONST_ID"); dt_CONST.Columns.Add("JOBNO"); dt_CONST.Columns.Add("INVOICE_SLNO"); dt_CONST.Columns.Add("ITEM_SLNO"); dt_CONST.Columns.Add("CONSTITUENT_SRNO");
                    dt_CONST.Columns.Add("CONSTITUENT_ELEMENT_NAME"); dt_CONST.Columns.Add("CONSTITUENT_ELEMENT_CODE"); dt_CONST.Columns.Add("CONSTITUENT_PERCENTAGE"); dt_CONST.Columns.Add("CONSTITUENT_YIELD_PERCENTAGE");
                    dt_CONST.Columns.Add("ACTIVE_INGREDIENT"); dt_CONST.Columns.Add("USER_ID"); dt_CONST.Columns.Add("DATE_TIME"); dt_CONST.Columns.Add("STATUS"); dt_CONST.Columns.Add("BRANCH_CODE");
                    dt_CONST.Columns.Add("YEAR"); dt_CONST.Columns.Add("WORKING_PERIOD"); dt_CONST.Columns.Add("MODIFIEDBY"); dt_CONST.Columns.Add("MODIFIEDON"); dt_CONST.Columns.Add("AMENDMENT_TYPE"); dt_CONST.Columns.Add("AMENDMENT_STATUS");

                    
                    ln = pos + 1;
                    try
                    {
                        for (ln = ln; ln < lines.Length - 1; ln++)
                        {
                            if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-BE>"))))
                            {
                                lnItm = lines[ln].ToString().Split('^');
                                if (lnItm.Length >= 13)
                                {
                                    string cntstart_date = (lnItm[10].ToString().Length >= 8) ? lnItm[10].ToString().Substring(6, 2) + "/" + lnItm[10].ToString().Substring(4, 2) + "/" + lnItm[10].ToString().Substring(0, 4) : "01/01/1900";
                                    string cntend_date = (lnItm[11].ToString().Length >= 8) ? lnItm[11].ToString().Substring(6, 2) + "/" + lnItm[11].ToString().Substring(4, 2) + "/" + lnItm[11].ToString().Substring(0, 4) : "01/01/1900";

                                    dt_CONST.Rows.Add(SW_CONT_ID, Convert.ToInt64(txtJobNo), lnItm[6].ToString(), lnItm[7].ToString(), lnItm[8].ToString(), lnItm[9].ToString(),
                                    lnItm[10].ToString(), lnItm[11].ToString(), lnItm[12].ToString(), lnItm[13].ToString(), currentuser, cur_date, "N", currentbranch, "",
                                    Working_Period, "", "01/01/1900", "", "");

                                    SW_CONT_ID = SW_CONT_ID + 1;
                                }

                            }
                            else
                            {
                                break;
                            }
                        }

                        if (dt_CONST.Rows.Count > 0)
                        {
                            admin.SqlBulk_Upload_Product("BE_ITEM_SW_CONST", dt_CONST, comp_ConnectionStr);
                        }
                        pos = ln + 1;
                        break;
                    }
                    catch (Exception ex)
                    {
                        ErrorLogs er = new ErrorLogs();
                        er.makeLog(ex.Message);

                        Imp.JOBNO = txtJobNo;
                        Imp.BRANCH_CODE = Connection.Get_Company_Type();
                        Imp.flag = "Delete_All_Table";
                        Gen_Ms = Imp.Update_Gen_Ms_Inv_Item_Details();
                    }
                }
            }
            #endregion SW_Const
            //****************************** End SW Const details ************************/////

            //****************************** Start SW Product details ************************/////
            #region SW_product
            for (int ln = 0; ln < lines.Length; ln++)
            {
                string[] lnItm;

                pos = Array.IndexOf(lines, "<TABLE>BE_ITEM_SW_PROD");

                if (result == 1 && pos > 0)
                {
                    dt_PRODUCT.Columns.Add("SW_PROD_ID"); dt_PRODUCT.Columns.Add("JOBNO"); dt_PRODUCT.Columns.Add("INVOICE_SLNO"); dt_PRODUCT.Columns.Add("ITEM_SLNO"); dt_PRODUCT.Columns.Add("PRODUCTION_BATCH_IDENTIFIER");
                    dt_PRODUCT.Columns.Add("PRODUCTION_BATCH_QUANTITY"); dt_PRODUCT.Columns.Add("UNIT_QTY_CODE"); dt_PRODUCT.Columns.Add("DATE_OF_MANUFACTURING"); dt_PRODUCT.Columns.Add("DATE_OF_EXPIRY"); 
                    dt_PRODUCT.Columns.Add("BEST_BEFORE"); dt_PRODUCT.Columns.Add("RESIDUAL_SHELF_LIFE_DAYS"); dt_PRODUCT.Columns.Add("TOTAL_SHELF_LIFE_DAYS"); dt_PRODUCT.Columns.Add("RESIDUAL_SHELF_PERCENT"); 
                    dt_PRODUCT.Columns.Add("USER_ID"); dt_PRODUCT.Columns.Add("DATE_TIME"); dt_PRODUCT.Columns.Add("STATUS"); dt_PRODUCT.Columns.Add("BRANCH_CODE"); dt_PRODUCT.Columns.Add("YEAR");
                    dt_PRODUCT.Columns.Add("WORKING_PERIOD"); dt_PRODUCT.Columns.Add("MODIFIEDBY"); dt_PRODUCT.Columns.Add("MODIFIEDON"); dt_PRODUCT.Columns.Add("AMENDMENT_TYPE"); 
                    dt_PRODUCT.Columns.Add("AMENDMENT_STATUS");

                    ln = pos + 1;
                    try
                    {
                        for (ln = ln; ln < lines.Length - 1; ln++)
                        {
                            if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-BE>"))))
                            {
                                lnItm = lines[ln].ToString().Split('^');
                                if (lnItm.Length >= 13)
                                {
                                    string Menauf_date = (lnItm[12].ToString().Length >= 8) ? lnItm[12].ToString().Substring(6, 2) + "/" + lnItm[12].ToString().Substring(4, 2) + "/" + lnItm[12].ToString().Substring(0, 4) : "01/01/1900";
                                    string Exp_date = (lnItm[12].ToString().Length >= 8) ? lnItm[12].ToString().Substring(6, 2) + "/" + lnItm[12].ToString().Substring(4, 2) + "/" + lnItm[12].ToString().Substring(0, 4) : "01/01/1900";
                                    string Befr_date = (lnItm[13].ToString().Length >= 8) ? lnItm[13].ToString().Substring(6, 2) + "/" + lnItm[13].ToString().Substring(4, 2) + "/" + lnItm[13].ToString().Substring(0, 4) : "01/01/1900";

                                    dt_PRODUCT.Rows.Add(SW_PRODUCT_ID, Convert.ToInt64(txtJobNo), lnItm[6].ToString(), lnItm[7].ToString(), lnItm[8].ToString(), lnItm[9].ToString(),
                                    lnItm[10].ToString(), Menauf_date, Exp_date, Befr_date, "", "", "", currentuser, cur_date, "N", currentbranch, "",
                                    Working_Period, "", "01/01/1900", "", "");

                                    SW_PRODUCT_ID = SW_PRODUCT_ID + 1;
                                }

                            }
                            else
                            {
                                break;
                            }
                        }

                        if (dt_PRODUCT.Rows.Count > 0)
                        {
                            admin.SqlBulk_Upload_Product("BE_ITEM_SW_PROD", dt_PRODUCT, comp_ConnectionStr);
                        }
                        pos = ln + 1;
                        break;
                    }
                    catch (Exception ex)
                    {
                        ErrorLogs er = new ErrorLogs();
                        er.makeLog(ex.Message);

                        Imp.JOBNO = txtJobNo;
                        Imp.BRANCH_CODE = Connection.Get_Company_Type();
                        Imp.flag = "Delete_All_Table";
                        Gen_Ms = Imp.Update_Gen_Ms_Inv_Item_Details();
                    }
                }
            }
            #endregion SW_product
            //****************************** End SW Product details ************************/////

            //****************************** Start SW Statement details ************************/////
            #region SW_Statement
            for (int ln = 0; ln < lines.Length; ln++)
            {
                string[] lnItm;

                pos = Array.IndexOf(lines, "<TABLE>STATEMENT");

                if (result == 1 && pos > 0)
                {

                    dt_SW_STMT.Columns.Add("SW_ID"); dt_SW_STMT.Columns.Add("JOBNO"); dt_SW_STMT.Columns.Add("INVOICE_SLNO"); dt_SW_STMT.Columns.Add("ITEM_SLNO"); 
                    dt_SW_STMT.Columns.Add("STMT_DECLARATION_TYPE"); dt_SW_STMT.Columns.Add("STMT_DECLARATION_NUMBER"); dt_SW_STMT.Columns.Add("STMT_DECLARATION_DATE");
                    dt_SW_STMT.Columns.Add("STMT_TYPE"); dt_SW_STMT.Columns.Add("STMT_CODE"); dt_SW_STMT.Columns.Add("STMT_TEXT"); dt_SW_STMT.Columns.Add("BRANCH_CODE"); 
                    dt_SW_STMT.Columns.Add("WORKING_PERIOD"); dt_SW_STMT.Columns.Add("CREATEDON"); dt_SW_STMT.Columns.Add("CREATEDBY"); dt_SW_STMT.Columns.Add("MODIFIEDBY");
                    dt_SW_STMT.Columns.Add("MODIFIEDON");


                    ln = pos + 1;
                    try
                    {
                        for (ln = ln; ln < lines.Length - 1; ln++)
                        {
                            if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-BE>"))))
                            {
                                lnItm = lines[ln].ToString().Split('^');
                                if (lnItm.Length >= 10)
                                {
                                    string Dec_date = (lnItm[6].ToString().Length >= 8) ? lnItm[6].ToString().Substring(6, 2) + "/" + lnItm[6].ToString().Substring(4, 2) + "/" + lnItm[6].ToString().Substring(0, 4) : "01/01/1900";

                                    dt_SW_STMT.Rows.Add(SW_STATE_ID, Convert.ToInt64(txtJobNo), lnItm[7].ToString(), lnItm[8].ToString(), lnItm[4].ToString(), lnItm[5].ToString(), Dec_date,
                                    lnItm[9].ToString(), lnItm[10].ToString(), lnItm[11].ToString(), currentbranch, Working_Period, cur_date, currentuser, "", "01/01/1900");

                                    SW_STATE_ID = SW_STATE_ID + 1;
                                }

                            }
                            else
                            {
                                break;
                            }
                        }

                        if (dt_SW_STMT.Rows.Count > 0)
                        {
                            admin.SqlBulk_Upload_Product("IMP_SINGLE_WINDOW_STMT", dt_SW_STMT, comp_ConnectionStr);
                        }
                        pos = ln + 1;
                        break;
                    }

                    catch (Exception ex)
                    {
                        ErrorLogs er = new ErrorLogs();
                        er.makeLog(ex.Message);

                        Imp.JOBNO = txtJobNo;
                        Imp.BRANCH_CODE = Connection.Get_Company_Type();
                        Imp.flag = "Delete_All_Table";
                        Gen_Ms = Imp.Update_Gen_Ms_Inv_Item_Details();
                    }
                }
            }
            #endregion SW_Statement
            //****************************** End SW Statement details ************************/////


            //****************************** Start SupDoc details ************************/////
            #region Sup_Doc
            for (int ln = 0; ln < lines.Length; ln++)
            {
                string[] lnItm;

                pos = Array.IndexOf(lines, "<TABLE>SUPPORTINGDOCS");

                if (result == 1 && pos > 0)
                {

                    dt_SUP_DOC.Columns.Add("SW_ID");  dt_SUP_DOC.Columns.Add("JOBNO");  dt_SUP_DOC.Columns.Add("INVOICE_SLNO");  dt_SUP_DOC.Columns.Add("ITEM_SLNO"); 
                    dt_SUP_DOC.Columns.Add("DECLARATION_TYPE");  dt_SUP_DOC.Columns.Add("IMAGE_REF_NUMBER");  dt_SUP_DOC.Columns.Add("DOC_TYPE_CODE");  dt_SUP_DOC.Columns.Add("DOC_ISSUING_PARTY_CODE"); 
                    dt_SUP_DOC.Columns.Add("DOC_ISSUING_PARTY_NAME"); dt_SUP_DOC.Columns.Add("DOC_ISSUING_PARTY_NAME_ADD1");  dt_SUP_DOC.Columns.Add("DOC_ISSUING_PARTY_NAME_ADD2"); 
                    dt_SUP_DOC.Columns.Add("DOC_ISSUING_PARTY_CITY"); dt_SUP_DOC.Columns.Add("DOC_ISSUING_PARTY_PIN");  dt_SUP_DOC.Columns.Add("DOC_REF_NUMBER");  dt_SUP_DOC.Columns.Add("PLACE_OF_ISSUE"); 
                    dt_SUP_DOC.Columns.Add("DOC_ISSUE_DATE");  dt_SUP_DOC.Columns.Add("DOC_EXPIRY_DATE");  dt_SUP_DOC.Columns.Add("BENEFICIARY_PARTY_CODE");  dt_SUP_DOC.Columns.Add("BENEFICIARY_PARTY_NAME");  
                    dt_SUP_DOC.Columns.Add("BENEFICIARY_PARTY_ADDRESS1"); dt_SUP_DOC.Columns.Add("BENEFICIARY_PARTY_ADDRESS2");  dt_SUP_DOC.Columns.Add("BENEFICIARY_PARTY_CITY"); 
                    dt_SUP_DOC.Columns.Add("BENEFICIARY_PARTY_PIN"); dt_SUP_DOC.Columns.Add("FILE_TYPE");  dt_SUP_DOC.Columns.Add("USER_ID");  dt_SUP_DOC.Columns.Add("DATE_TIME");
                    dt_SUP_DOC.Columns.Add("BRANCH_CODE"); dt_SUP_DOC.Columns.Add("WORKING_PERIOD"); dt_SUP_DOC.Columns.Add("CREATEDON");
                    dt_SUP_DOC.Columns.Add("CREATEDBY"); dt_SUP_DOC.Columns.Add("MODIFIEDBY"); dt_SUP_DOC.Columns.Add("MODIFIEDON"); dt_SUP_DOC.Columns.Add("SELECT_TYPE");
                    dt_SUP_DOC.Columns.Add("ICEGATE_ID"); dt_SUP_DOC.Columns.Add("AMENDMENT_TYPE"); dt_SUP_DOC.Columns.Add("AMENDMENT_STATUS"); dt_SUP_DOC.Columns.Add("ICEGATE_DOC_FILE_NAME");
                     


                    ln = pos + 1;
                    try
                    {
                        for (ln = ln; ln < lines.Length - 1; ln++)
                        {
                            if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-BE>"))))
                            {
                                lnItm = lines[ln].ToString().Split('^');
                                if (lnItm.Length > 25)
                                {
                                    string Issu_date = (lnItm[22].ToString().Length >= 8) ? lnItm[22].ToString().Substring(6, 2) + "/" + lnItm[22].ToString().Substring(4, 2) + "/" + lnItm[22].ToString().Substring(0, 4) : "01/01/1900";
                                    string Expry_date = (lnItm[23].ToString().Length >= 8) ? lnItm[23].ToString().Substring(6, 2) + "/" + lnItm[23].ToString().Substring(4, 2) + "/" + lnItm[23].ToString().Substring(0, 4) : "01/01/1900";

                                    dt_SUP_DOC.Rows.Add(SUP_DOC_ID, Convert.ToInt64(txtJobNo), lnItm[7].ToString(), lnItm[8].ToString(), lnItm[6].ToString(), lnItm[12].ToString(), lnItm[13].ToString(),
                                    lnItm[14].ToString(), lnItm[15].ToString(), lnItm[16].ToString(), lnItm[17].ToString(), lnItm[18].ToString(), lnItm[19].ToString(), lnItm[20].ToString(),
                                    lnItm[21].ToString(), Issu_date, Expry_date, lnItm[24].ToString(), lnItm[25].ToString(), lnItm[26].ToString(),
                                    lnItm[27].ToString(), lnItm[28].ToString(), lnItm[29].ToString(), lnItm[30].ToString(), currentuser, cur_date, currentbranch, Working_Period, cur_date, currentuser, "", "01/01/1900",
                                   "", lnItm[11].ToString(), "", "", "");

                                    SUP_DOC_ID = SUP_DOC_ID + 1;
                                }

                            }
                            else
                            {
                                break;
                            }
                        }

                        if (dt_SUP_DOC.Rows.Count > 0)
                        {
                            admin.SqlBulk_Upload_Product("BE_ITEM_SW_SUP_DOC", dt_SUP_DOC, comp_ConnectionStr);
                        }
                        pos = ln + 1;
                        break;
                    }
                    catch (Exception ex)
                    {
                        ErrorLogs er = new ErrorLogs();
                        er.makeLog(ex.Message);
                        Imp.JOBNO = txtJobNo;
                        Imp.BRANCH_CODE = Connection.Get_Company_Type();
                        Imp.flag = "Delete_All_Table";
                        Gen_Ms = Imp.Update_Gen_Ms_Inv_Item_Details();
                    }
                }
            }
            #endregion Sup_Doc
            //****************************** End SupDoc details ************************/////

            if (dt_INV.Rows.Count > 0 && dt_ITEM.Rows.Count > 0)
            {
                Imp.JOBNO = txtJobNo;
                Imp.BRANCH_CODE = Connection.Get_Company_Type();                
                Imp.INVOICE_SLNO = INVOICE_SLNO;
                Imp.ITEM_SLNO = ITEM_SLNO;
                Imp.COUNTRY_CODE = Country_Orgin;
                Imp.PORT_CODE = Port_Orgin;
                Imp.STATE_CODE = State_Code;
                Imp.ITEM_COUNTRY = item_country;
                Imp.SCHEM_CODE = Schem_code;
                Imp.RITC = Ritc;
                Imp.flag = "Conty_Port_State";
                Co_Po_St = Imp.Retrieve_County_Port_State_details();
                Imp.XMLGEN = Co_Po_St.GetXml();
                Imp.flag = "Job_Master_Data_Update";
                Gen_Ms = Imp.Update_Gen_Ms_Inv_Item_Details();

                if (dt_LICNESE.Rows.Count > 0)
                {
                    Session["IMPORT_JOBNO"] = txtJobNo;
                    Session["btn_cif_click"] = "License";
                    foreach (DataRow row in dt_LICNESE.Rows)
                    {
                        INVOICE_SLNO = row["INVOICE_SLNO"].ToString();
                        ITEM_SLNO = row["ITEM_SLNO"].ToString();
                        LICENSE_ID = row["LICENSE_ID"].ToString();
                        btn_cif_click = "btn_Calc";
                        Session["btn_cif_click"] = "btn_Calc";
                        Session["INDIVIDUAL_CIF_VALUE"] = row["DEBIT_AMT"].ToString();

                        //Item_License.Page_Load_Item_Details(INVOICE_SLNO, ITEM_SLNO);//hide on 31-12-2025
                        Item_License.Page_Load_Item_Details(INVOICE_SLNO, ITEM_SLNO, "", "");
                        Imp.INVOICE_SLNO = INVOICE_SLNO;
                        Imp.ITEM_SLNO = ITEM_SLNO;
                        Imp.BRANCH_CODE = Connection.Get_Company_Type();
                        if (row["SCHEME_CODE"].ToString() != "14" && row["SCHEME_CODE"].ToString() != "PI")
                        {
                            Imp.Debit_Duty = Session["ENTRY_DEBIT_DUTY_FINAL"].ToString();
                            Imp.LICENSE_ID = LICENSE_ID;
                            Imp.flag = "Lic_Debitduty_Update";
                            Gen_Ms = Imp.Update_Gen_Ms_Inv_Item_Details();
                        }
                    }
                   
                    if (dt_LICNESE.AsEnumerable().Any(row => row["SCHEME_CODE"].ToString() != "14" && row["SCHEME_CODE"].ToString() != "PI"))
                    {
                        Imp.flag = "Lic_Total_Debitduty_Update";
                        Gen_Ms = Imp.Update_Gen_Ms_Inv_Item_Details();
                    }
                }
            }
        }
    }

    private string Get_ExRate(string curr)
    {
        
        var FullName1 = from DataRow drr in dt_Exchange.AsEnumerable()
                        where drr.Field<string>("INVOICE_CURRENCY") == curr
                        select drr;

        DataView dvv = FullName1.AsDataView();

        if (dvv.Count > 0)
        {
            DataTable Get_JobNo = FullName1.CopyToDataTable();
            exrate_fromfile = Get_JobNo.Rows[0]["EXCHANGE_RATE"].ToString();
        }
        return exrate_fromfile;
    }
      
    public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
    {
        Hashtable hTable = new Hashtable();
        ArrayList duplicateList = new ArrayList();
        foreach (DataRow dtRow in dTable.Rows)
        {
            if (hTable.Contains(dtRow[colName]))
                duplicateList.Add(dtRow);
            else
                hTable.Add(dtRow[colName], string.Empty);
        }
        foreach (DataRow dtRow in duplicateList)
            dTable.Rows.Remove(dtRow);
        return dTable;
    }

    private static string ConvertDataTableToXML(DataTable dtData)
    {
        DataSet dsData = new DataSet();
        StringBuilder sbSQL;
        StringWriter swSQL;
        string XMLformat;
        try
        {
            sbSQL = new StringBuilder();
            swSQL = new StringWriter(sbSQL);
            dsData.Merge(dtData, true, MissingSchemaAction.AddWithKey);
            dsData.Tables[0].TableName = "SampleDataTable";
            foreach (DataColumn col in dsData.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            dsData.WriteXml(swSQL, XmlWriteMode.WriteSchema);
            XMLformat = sbSQL.ToString();
            return XMLformat;
        }
        catch (Exception sysException)
        {
            throw sysException;
        }
    }

    public void addtoGallery1(string picName, string folderName, string Excel_Name)
    {
        string strFolderPath;
        string strImagePath;
        try
        {
            strFolderPath = Path.Combine(Request.PhysicalApplicationPath, folderName);
            strImagePath = Path.Combine(strFolderPath, picName);

            if (Excel_Name == "INDEV")
            {
                //fileuploadExcel1.SaveAs(strImagePath);
            }
            else
            {
                fileuploadXML.SaveAs(strImagePath);
            }

        }
        catch
        {
        }
        finally
        {
        }
    }
}
