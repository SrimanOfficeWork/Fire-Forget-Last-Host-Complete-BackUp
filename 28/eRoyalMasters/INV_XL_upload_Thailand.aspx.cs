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
//using System.Web.UI.i
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;

using System.Globalization;
//using Excel;


public partial class INV_XL_upload_Thailand : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    Indev_eroyalmaster erm = new Indev_eroyalmaster();
    adminmaster adm = new adminmaster();
    Transaction Transact = new Transaction();
    DataTable dt = new DataTable();
    Company_Master Comp = new Company_Master();
    AdminMasterDetails admin = new AdminMasterDetails();
    DataSet ds_prod = new DataSet();
    DataSet ds_comp = new DataSet();
    DataTable dt_prod = new DataTable();
    DataSet dt_MAX = new DataSet();


    public int i;
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, IMPORT_JOBNO;
    public string inv_no = "";
   
    double cal, cal1, invoicevalue;
   
    DataSet ds = new DataSet();
    DataSet dsXML = new DataSet();

    DataSet ds1 = new DataSet();
    DataSet ds2 = new DataSet();
    DataSet ds3 = new DataSet();
    DataSet ds4 = new DataSet();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet ds_invoice = new DataSet();
    DataSet ds_scheme = new DataSet();
   

    public string errorFolder = "", logline = "", logFileName = "";
    public int licen_slno = 0;

    public string Invno;
    public string Invdt;
    public string INS_TERMS, FOB_TERMS, CHINA_INV_CURRENCY, ITEM_QTYCODE, ITEM_UNITCODE, INVSLNO, COUNTRYORIGIN, IsInvoiceno = "";
    public string Ins_amt;
    public decimal item_amt;
    public string scheme;
    public int INVCOUNT,MAX_ID;
    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();

        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Import_Excel");

        //ddl_Client_Database_Bind();
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
        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Import_Excel");

        if (Session["IMPORT_JOBNO"] != null)
        {

            IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
            //load_invno();
        }
        if (!Page.IsPostBack)
        {
            if (Session["IMPORT_JOBNO"] != null)
            {
               
            }
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Nippon Excel Upload', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Nippon Excel Upload', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public string Get_ExcelFile()
    {
        string connString = "";
        string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
        //string path = "C:\\Documents and Settings\\sathis\\Desktop\\" + fileuploadExcel.FileName;
        string path = errorFolder + "\\" + fileuploadExcel.FileName;
     

        string picExtension;
        string fileName2;

        if (fileuploadExcel.HasFile)
        {
            picExtension = fnGetPictureExtn(fileuploadExcel.FileName);
            fileName2 = fileuploadExcel.FileName;
            addtoGallery1(fileName2, errorFolder);
        }

        if (strFileType.Trim() == ".xls" || strFileType.Trim() == ".xlsx")
        {
            if (strFileType.Trim() == ".xls")
            {
                connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            }
            else if (strFileType.Trim() == ".xlsx")
            {
                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }
            //----------------------------
            string query = "SELECT * FROM [Sheet1$]";

           
                OleDbConnection conn = new OleDbConnection(connString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                OleDbCommand cmd = new OleDbCommand(query, conn);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                da.Fill(ds);
                da.Dispose();
                conn.Close();
                conn.Dispose();
            
        }
        ViewState["ds_Excel_upload"] = ds;
        return strFileType.Trim();

    }

    protected void btnImportInvUpload_Thailand_Click(object sender, EventArgs e)
    {
        try
        {
            string file_ext = "";
            if (File.Exists(errorFolder + logFileName))
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                file_ext = Get_ExcelFile();

                ViewState["File_Exten"] = file_ext;
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                file_ext = Get_ExcelFile();
                ViewState["File_Exten"] = file_ext;
            }

        Excel_Upload_load(file_ext);
            
        }
        catch (Exception ex)
        {
            //Maildb.StoreMailContents(ds, email);
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public void Get_Imp_Product_Thailand_MAX_ID()
    {
        erm.PRODUCT_IMPORT_ID = "";
        erm.PRODUCT_DESCRIPTION = "";
        erm.PRODUCT_CTH = "";
        erm.PRODUCT_CETH = "";
        erm.PRODUCT_RITC = "";

        if (ddl_Type.SelectedValue == "GENERAL")
        {
            erm.Ename = "GET_PRODUCT_IMPORT_MASTER_CHINA_MAX";
        }
        else
        {
            erm.Ename = "GET_PRODUCT_IMPORT_MASTER_THAILAND_MAX";
        }
 
        erm.EWorking_Period = Working_Period;

        dt_MAX = erm.RetrieveAll_Product_import_MASTER();

       if(dt_MAX.Tables[0].Rows.Count>0)
       {
           MAX_ID = Convert.ToInt32(dt_MAX.Tables[0].Rows[0]["PRODUCT_ID"].ToString());
       }
    }

    public void Get_Imp_Product_Thailand()    
    {
        erm.PRODUCT_IMPORT_ID = "";
        erm.PRODUCT_DESCRIPTION = "";
        erm.PRODUCT_CTH = "";
        erm.PRODUCT_CETH = "";
        erm.PRODUCT_RITC = "";
        erm.Ename = "Get_Product_Thailand";// "Get_Product_Thailand"//Get_Product_GMMCO;
        erm.EWorking_Period = Working_Period;

        ds_prod = erm.RetrieveAll_Product_import_MASTER();

        dt_prod.Columns.Add("PARTNO");
        dt_prod.Columns.Add("PRODUCT_DESCRIPTION");
        dt_prod.Columns.Add("PRODUCT_RITC");
        dt_prod.Columns.Add("PRODUCT_BCD_NOTN");
        dt_prod.Columns.Add("PRODUCT_BCD_SLNO");

        for (int j = 0; j < ds_prod.Tables[0].Rows.Count; j++)
        {
            dt_prod.Rows.Add(ds_prod.Tables[0].Rows[j]["PARTNO"].ToString(), ds_prod.Tables[0].Rows[j]["PRODUCT_DESCRIPTION"].ToString(), ds_prod.Tables[0].Rows[j]["PRODUCT_RITC"].ToString(), ds_prod.Tables[0].Rows[j]["PRODUCT_BCD_NOTN"].ToString(), ds_prod.Tables[0].Rows[j]["PRODUCT_BCD_SLNO"].ToString());
        }
    }
  
    public void Excel_Upload_load(string file_ext)
    {
        Get_Imp_Product_Thailand_MAX_ID();

        DataSet Inv_ds = new DataSet();
        Inv_ds = ds = (DataSet)ViewState["ds_Excel_upload"];
        int a = 0, b=1;
          
        int ic = ds.Tables[0].Rows.Count;

        DataTable dt1=ds.Tables[0];

        //Get_Imp_Product_Thailand();

        //dt1.AsEnumerable().Select(y => y.ItemArray.ToList()).Select(x => x.ToString().Trim());

        dt1.Columns[0].ColumnName = "PARTNO";
        dt1.Columns[1].ColumnName = "PRODUCT_DESCRIPTION";
        dt1.Columns[2].ColumnName = "PRODUCT_RITC";
        dt1.Columns[3].ColumnName = "PRODUCT_BCD_NOTN";
        dt1.Columns[4].ColumnName = "PRODUCT_BCD_SLNO";

        DataView dv = new DataView(dt1);
        DataTable dtt = dt1.DefaultView.ToTable(true,"PARTNO", "PRODUCT_DESCRIPTION", "PRODUCT_RITC", "PRODUCT_BCD_NOTN", "PRODUCT_BCD_SLNO");
     
        int ic2 = dtt.Rows.Count;

        DataTable dt_final = new DataTable();
        dt_final.Columns.Add("PARTNO");
        dt_final.Columns.Add("PRODUCT_DESCRIPTION");
        dt_final.Columns.Add("PRODUCT_RITC");
        dt_final.Columns.Add("PRODUCT_BCD_NOTN");
        dt_final.Columns.Add("PRODUCT_BCD_SLNO");

        //DataTable dt_final = dt1.Clone();
       
            for (int i = 0; i <= dtt.Rows.Count - 1; i++)
            {

              string  PARTNO = Regex.Replace(dtt.Rows[i]["PARTNO"].ToString(), @"\s+", "");
              string PRODUCT_DESCRIPTION = dtt.Rows[i]["PRODUCT_DESCRIPTION"].ToString();
              string PRODUCT_RITC = Regex.Replace(dtt.Rows[i]["PRODUCT_RITC"].ToString(), @"\s+", "");
              string PRODUCT_BCD_NOTN = Regex.Replace(dtt.Rows[i]["PRODUCT_BCD_NOTN"].ToString(), @"\s+", "");
              string PRODUCT_BCD_SLNO = Regex.Replace(dtt.Rows[i]["PRODUCT_BCD_SLNO"].ToString(), @"\s+", "");

              erm.Eproduct_imp_id = PARTNO;
              erm.Eproduct_imp_description = PRODUCT_DESCRIPTION;
              erm.Eproduct_imp_cth = PRODUCT_BCD_SLNO;
              erm.Eproduct_imp_ceth = PRODUCT_BCD_NOTN;
              erm.Eproduct_imp_ritc = PRODUCT_RITC;

              if (ddl_Type.SelectedValue == "GENERAL")
              {
                  erm.Ename = "Get_Product_Master_Check_All";
              }
              else
              {
                  erm.Ename = "Get_Product_Thailand_Check_All";
              }
               
                erm.EWorking_Period = Working_Period;

                ds_prod = erm.RetrieveAll_Product_import_MASTER();
                int result = erm.result;

                if (result == 1)
                {
                    if (dtt.Rows[i]["PARTNO"].ToString() != "")
                    {
                        dt_final.Rows.Add(PARTNO, PRODUCT_DESCRIPTION, PRODUCT_RITC, PRODUCT_BCD_NOTN, PRODUCT_BCD_SLNO);
                    }
                }
                else
                {
                    
                }
            }

            dt_final = dt_final.DefaultView.ToTable(true, "PARTNO", "PRODUCT_DESCRIPTION", "PRODUCT_RITC", "PRODUCT_BCD_NOTN", "PRODUCT_BCD_SLNO");

            int ic21 = dt_final.Rows.Count;

            if (dt_final.Rows.Count > 0)
            {
                dt_final.Rows.Add();

                if (dt_final.Rows.Count > a)
                {

                    dsXML.Tables.Add("ItemDetails");
                    dsXML.Tables[0].Columns.Add("PRODUCT_IMPORT_ID");
                    dsXML.Tables[0].Columns.Add("PRODUCT_DESCRIPTION");
                    dsXML.Tables[0].Columns.Add("PRODUCT_CODE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_RITC");
                    dsXML.Tables[0].Columns.Add("PRODUCT_CTH");
                    dsXML.Tables[0].Columns.Add("PRODUCT_BCD_NOTN");
                    dsXML.Tables[0].Columns.Add("PRODUCT_BCD_SLNO");
                    dsXML.Tables[0].Columns.Add("PRODUCT_BCD_RATE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_BCD_SPL");
                    dsXML.Tables[0].Columns.Add("PRODUCT_BCD_UNIT");
                    dsXML.Tables[0].Columns.Add("PRODUCT_BCD_SPL_TYPE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_DUTY_NOTN");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_DUTY_NOTN_SL");
                    dsXML.Tables[0].Columns.Add("PRODUCT_EDU_CESS_NOTN");
                    dsXML.Tables[0].Columns.Add("PRODUCT_EDU_CESS_NOTN_SL");
                    dsXML.Tables[0].Columns.Add("PRODUCT_EDU_CESS_RATE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_SEC_EDU_CESS_NOTN");
                    dsXML.Tables[0].Columns.Add("PRODUCT_SEC_EDU_CESS_NOTN_SL");
                    dsXML.Tables[0].Columns.Add("PRODUCT_SEC_EDU_CESS_RATE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_NCD_NOTN");
                    dsXML.Tables[0].Columns.Add("PRODUCT_NCD_SLNO");
                    dsXML.Tables[0].Columns.Add("PRODUCT_NCD_RATE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_NCD_SPL");
                    dsXML.Tables[0].Columns.Add("PRODUCT_NCD_UNIT");
                    dsXML.Tables[0].Columns.Add("PRODUCT_NCD_SPL_TYPE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_AGGREGATE_DUTY_NOTN");
                    dsXML.Tables[0].Columns.Add("PRODUCT_AGGREGATE_DUTY_NOTN_SL");
                    dsXML.Tables[0].Columns.Add("PRODUCT_AGGREGATE_DUTY_NOTN_RATE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_SAFEGUARD_NOTN");
                    dsXML.Tables[0].Columns.Add("PRODUCT_SAFEGUARD_SLNO");
                    dsXML.Tables[0].Columns.Add("PRODUCT_SAFEGUARD_RATE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_SAFEGUARD_SPL");
                    dsXML.Tables[0].Columns.Add("PRODUCT_SAFEGUARD_UNIT");
                    dsXML.Tables[0].Columns.Add("PRODUCT_SAFEGUARD_SPL_TYPE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_CETH");
                    dsXML.Tables[0].Columns.Add("PRODUCT_MRP_YN");
                    dsXML.Tables[0].Columns.Add("PRODUCT_MRP_SL_NO");
                    dsXML.Tables[0].Columns.Add("PRODUCT_MRP_AMOUNT");
                    dsXML.Tables[0].Columns.Add("PRODUCT_MRP_ABT_RATE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_CVD_NOTN");
                    dsXML.Tables[0].Columns.Add("PRODUCT_CVD_SLNO");
                    dsXML.Tables[0].Columns.Add("PRODUCT_CVD_RATE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_CVD_SPL");
                    dsXML.Tables[0].Columns.Add("PRODUCT_CVD_UNIT");
                    dsXML.Tables[0].Columns.Add("PRODUCT_CVD_SPL_TYPE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_CVD_EDU_CESS_RATE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_CVD_SEC_EDU_CESS_RATE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL5_SIA_NOTN");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL5_SIA_NOTN_SL");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL5_SIA_RATE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_GSI_NOTN");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_GSI_SLNO");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_GSI_RATE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_GSI_SPL");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_GSI_UNIT");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_GSI_SPL_TYPE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_SHEII_NOTN");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_SHEII_SLNO");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_SHEII_RATE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_SHEII_SPL");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_SHEII_UNIT");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_SHEII_TYPE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_TTA_NOTN");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_TTA_SLNO");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_TTA_RATE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_TTA_SPL");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_TTA_UNIT");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_TTA_TYPE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_NOTN");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_SLNO");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_RATE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_SPL");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_UNIT");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_TYPE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_CESS_NOTN");
                    dsXML.Tables[0].Columns.Add("PRODUCT_CESS_SLNO");
                    dsXML.Tables[0].Columns.Add("PRODUCT_CESS_RATE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_CESS_SPL");
                    dsXML.Tables[0].Columns.Add("PRODUCT_CESS_UNIT");
                    dsXML.Tables[0].Columns.Add("PRODUCT_CESS_TYPE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_GENERAL_DESC");
                    dsXML.Tables[0].Columns.Add("PRODUCT_MANUFACTURER");
                    dsXML.Tables[0].Columns.Add("PRODUCT_BRAND");
                    dsXML.Tables[0].Columns.Add("PRODUCT_MODEL");
                    dsXML.Tables[0].Columns.Add("PRODUCT_END_USE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_COUNTRY_ORIGIN");
                    dsXML.Tables[0].Columns.Add("PRODUCT_ACCESSORIES");
                    dsXML.Tables[0].Columns.Add("PRODUCT_REMARKS");
                    dsXML.Tables[0].Columns.Add("PRODUCT_USER_ID");
                    dsXML.Tables[0].Columns.Add("PRODUCT_DATE_TIME");
                    dsXML.Tables[0].Columns.Add("PRODUCT_STATUS");
                    dsXML.Tables[0].Columns.Add("PRODUCT_BRANCH_CODE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_YEAR");
                    dsXML.Tables[0].Columns.Add("PRODUCT_WORKING_PERIOD");
                    dsXML.Tables[0].Columns.Add("PRODUCT_SAPTA_NOTN");
                    dsXML.Tables[0].Columns.Add("PRODUCT_SAPTA_SLNO");
                    dsXML.Tables[0].Columns.Add("PRODUCT_SAPTA_RATE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_TARIFF_NOTN");
                    dsXML.Tables[0].Columns.Add("PRODUCT_TARIFF_SLNO");
                    dsXML.Tables[0].Columns.Add("PRODUCT_TARIFF_QTY");
                    dsXML.Tables[0].Columns.Add("PRODUCT_TARIFF_AMOUNT");
                    dsXML.Tables[0].Columns.Add("PRODUCT_TARIFF_AMOUNT_UNIT");
                    dsXML.Tables[0].Columns.Add("PRODUCT_RSP_NOTN_NO");
                    dsXML.Tables[0].Columns.Add("PRODUCT_RSP_NOTN_SL_NO");
                    dsXML.Tables[0].Columns.Add("PRODUCT_CVD_EDU_CESS_NOTN");
                    dsXML.Tables[0].Columns.Add("PRODUCT_CVD_EDU_CESS_NOTN_SL");
                    dsXML.Tables[0].Columns.Add("PRODUCT_CETH_EDU_CESS_RATE");
                    dsXML.Tables[0].Columns.Add("PRODUCT_CVD_SEC_EDU_CESS_NOTN");
                    dsXML.Tables[0].Columns.Add("PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL");
                    dsXML.Tables[0].Columns.Add("PRODUCT_CETH_CVD_SEC_EDU_CESS_RATE");
                    dsXML.Tables[0].Columns.Add("PARTNO");

                    //---------------------End--------------------------------------------------//
                    b = MAX_ID;

                    if (file_ext == ".xls" || file_ext == ".xlsx")
                    {
                        while (dt_final.Rows[a][0] != System.DBNull.Value)
                        {
                            //while (ds.Tables[0].Rows.Count > b)
                            //{
                            DataRow dr1 = dsXML.Tables[0].NewRow();

                            string partno = dt_final.Rows[a][0].ToString();

                            if (partno != "")
                            {
                                dr1["PRODUCT_IMPORT_ID"] = b;

                                dr1["PRODUCT_DESCRIPTION"] = Regex.Replace(dt_final.Rows[a][1].ToString(), @"\s+", "");
                                dr1["PRODUCT_CODE"] = "";
                                dr1["PRODUCT_RITC"] = Regex.Replace(dt_final.Rows[a][2].ToString(), @"\s+", "");
                                dr1["PRODUCT_CTH"] = Regex.Replace(dt_final.Rows[a][2].ToString(), @"\s+", "");
                                dr1["PRODUCT_BCD_NOTN"] = Regex.Replace(dt_final.Rows[a][3].ToString(), @"\s+", "");
                                string slno = Regex.Replace(dt_final.Rows[a][4].ToString(), @"\s+", "");
                                dr1["PRODUCT_BCD_SLNO"] = slno;
                                dr1["PRODUCT_BCD_SPL"] = "";
                                dr1["PRODUCT_BCD_UNIT"] = "";
                                dr1["PRODUCT_BCD_SPL_TYPE"] = "";
                                dr1["PRODUCT_ADDL_DUTY_NOTN"] = "";
                                dr1["PRODUCT_ADDL_DUTY_NOTN_SL"] = "";
                                dr1["PRODUCT_EDU_CESS_NOTN"] = "";
                                dr1["PRODUCT_EDU_CESS_NOTN_SL"] = "";
                                dr1["PRODUCT_EDU_CESS_RATE"] = "";
                                dr1["PRODUCT_SEC_EDU_CESS_NOTN"] = "";
                                dr1["PRODUCT_SEC_EDU_CESS_NOTN_SL"] = "";
                                dr1["PRODUCT_SEC_EDU_CESS_RATE"] = "";
                                dr1["PRODUCT_NCD_NOTN"] = "";
                                dr1["PRODUCT_NCD_SLNO"] = "";
                                dr1["PRODUCT_NCD_RATE"] = "";
                                dr1["PRODUCT_NCD_SPL"] = "";
                                dr1["PRODUCT_NCD_UNIT"] = "";
                                dr1["PRODUCT_NCD_SPL_TYPE"] = "";
                                dr1["PRODUCT_AGGREGATE_DUTY_NOTN"] = "";
                                dr1["PRODUCT_AGGREGATE_DUTY_NOTN_SL"] = "";
                                dr1["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"] = "";
                                dr1["PRODUCT_SAFEGUARD_NOTN"] = "";
                                dr1["PRODUCT_SAFEGUARD_SLNO"] = "";
                                dr1["PRODUCT_SAFEGUARD_RATE"] = "";
                                dr1["PRODUCT_SAFEGUARD_SPL"] = "";
                                dr1["PRODUCT_SAFEGUARD_UNIT"] = "";
                                dr1["PRODUCT_SAFEGUARD_SPL_TYPE"] = "";
                                dr1["PRODUCT_CETH"] = Regex.Replace(dt_final.Rows[a][2].ToString(), @"\s+", "");
                                dr1["PRODUCT_MRP_YN"] = "N";
                                dr1["PRODUCT_MRP_SL_NO"] = "";
                                dr1["PRODUCT_MRP_AMOUNT"] = "";
                                dr1["PRODUCT_MRP_ABT_RATE"] = "";
                                dr1["PRODUCT_CVD_NOTN"] = "";
                                dr1["PRODUCT_CVD_SLNO"] = "";
                                dr1["PRODUCT_CVD_RATE"] = "";
                                dr1["PRODUCT_CVD_SPL"] = "";
                                dr1["PRODUCT_CVD_UNIT"] = "";
                                dr1["PRODUCT_CVD_SPL_TYPE"] = "";
                                dr1["PRODUCT_CVD_EDU_CESS_RATE"] = "";
                                dr1["PRODUCT_CVD_SEC_EDU_CESS_RATE"] = "";
                                dr1["PRODUCT_ADDL5_SIA_NOTN"] = "";
                                dr1["PRODUCT_ADDL5_SIA_NOTN_SL"] = "";
                                dr1["PRODUCT_ADDL5_SIA_RATE"] = "";
                                dr1["PRODUCT_ADDL_GSI_NOTN"] = "";
                                dr1["PRODUCT_ADDL_GSI_SLNO"] = "";
                                dr1["PRODUCT_ADDL_GSI_RATE"] = "";
                                dr1["PRODUCT_ADDL_GSI_SPL"] = "";
                                dr1["PRODUCT_ADDL_GSI_UNIT"] = "";
                                dr1["PRODUCT_ADDL_GSI_SPL_TYPE"] = "";
                                dr1["PRODUCT_ADDL_SHEII_NOTN"] = "";
                                dr1["PRODUCT_ADDL_SHEII_SLNO"] = "";
                                dr1["PRODUCT_ADDL_SHEII_RATE"] = "";
                                dr1["PRODUCT_ADDL_SHEII_SPL"] = "";
                                dr1["PRODUCT_ADDL_SHEII_UNIT"] = "";
                                dr1["PRODUCT_ADDL_SHEII_TYPE"] = "";
                                dr1["PRODUCT_ADDL_TTA_NOTN"] = "";
                                dr1["PRODUCT_ADDL_TTA_SLNO"] = "";
                                dr1["PRODUCT_ADDL_TTA_RATE"] = "";
                                dr1["PRODUCT_ADDL_TTA_SPL"] = "";
                                dr1["PRODUCT_ADDL_TTA_UNIT"] = "";
                                dr1["PRODUCT_ADDL_TTA_TYPE"] = "";
                                dr1["PRODUCT_ADDL_HEALTH_CESS_NOTN"] = "";
                                dr1["PRODUCT_ADDL_HEALTH_CESS_SLNO"] = "";
                                dr1["PRODUCT_ADDL_HEALTH_CESS_RATE"] = "";
                                dr1["PRODUCT_ADDL_HEALTH_CESS_SPL"] = "";
                                dr1["PRODUCT_ADDL_HEALTH_CESS_UNIT"] = "";
                                dr1["PRODUCT_ADDL_HEALTH_CESS_TYPE"] = "";
                                dr1["PRODUCT_CESS_NOTN"] = "";
                                dr1["PRODUCT_CESS_SLNO"] = "";
                                dr1["PRODUCT_CESS_RATE"] = "";
                                dr1["PRODUCT_CESS_SPL"] = "";
                                dr1["PRODUCT_CESS_UNIT"] = "";
                                dr1["PRODUCT_CESS_TYPE"] = "";
                                dr1["PRODUCT_GENERAL_DESC"] = "N.A";
                                dr1["PRODUCT_MANUFACTURER"] = "N.A";
                                dr1["PRODUCT_BRAND"] = "N.A";
                                dr1["PRODUCT_MODEL"] = "N.A";
                                dr1["PRODUCT_END_USE"] = "N.A";


                                if (ddl_Type.SelectedValue == "GENERAL")
                                {
                                    dr1["PRODUCT_COUNTRY_ORIGIN"] = "CHINA";
                                }
                                else
                                {
                                    dr1["PRODUCT_COUNTRY_ORIGIN"] = "THAILAND";
                                }

                                dr1["PRODUCT_ACCESSORIES"] = "";
                                dr1["PRODUCT_REMARKS"] = "";
                                dr1["PRODUCT_USER_ID"] = currentuser;
                                dr1["PRODUCT_DATE_TIME"] = "01/01/2016";
                                dr1["PRODUCT_STATUS"] = "N";
                                dr1["PRODUCT_BRANCH_CODE"] = currentbranch;
                                dr1["PRODUCT_YEAR"] = "";
                                dr1["PRODUCT_WORKING_PERIOD"] = Working_Period;
                                dr1["PRODUCT_SAPTA_NOTN"] = "";
                                dr1["PRODUCT_SAPTA_SLNO"] = "";
                                dr1["PRODUCT_SAPTA_RATE"] = "";
                                dr1["PRODUCT_TARIFF_NOTN"] = "";
                                dr1["PRODUCT_TARIFF_SLNO"] = "";
                                dr1["PRODUCT_TARIFF_QTY"] = "";
                                dr1["PRODUCT_TARIFF_AMOUNT"] = "";
                                dr1["PRODUCT_TARIFF_AMOUNT_UNIT"] = "";
                                dr1["PRODUCT_RSP_NOTN_NO"] = "";
                                dr1["PRODUCT_RSP_NOTN_SL_NO"] = "";
                                dr1["PRODUCT_CVD_EDU_CESS_NOTN"] = "";
                                dr1["PRODUCT_CVD_EDU_CESS_NOTN_SL"] = "";
                                dr1["PRODUCT_CETH_EDU_CESS_RATE"] = "";
                                dr1["PRODUCT_CVD_SEC_EDU_CESS_NOTN"] = "";
                                dr1["PRODUCT_CVD_SEC_EDU_CESS_NOTN_SL"] = "";
                                dr1["PRODUCT_CETH_CVD_SEC_EDU_CESS_RATE"] = "";
                                dr1["PARTNO"] = Regex.Replace(dt_final.Rows[a][0].ToString(), @"\s+", "");


                                //*******************************************************************************//

                                dsXML.Tables[0].Rows.Add(dr1);
                                //a++;
                            }
                            a++;
                            b++;
                        }

                    }

                    if (ddl_Type.SelectedValue == "GENERAL")
                    {
                        admin.SqlBulk_Upload_Product("PRODUCT_IMPORT_MASTER", dsXML.Tables[0], comp_ConnectionStr);
                    }
                    else
                    {
                        admin.SqlBulk_Upload_Product("PRODUCT_IMPORT_MASTER_THAILAND", dsXML.Tables[0], comp_ConnectionStr);
                    }
                    //admin.SqlBulk_Upload_Product("PRODUCT_IMPORT_MASTER", dsXML.Tables[0], comp_ConnectionStr);
                }

            }
    }

    public void addtoGallery1(string picName, string folderName)
    {
        string strFolderPath;
        string strImagePath;
        try
        {
            strFolderPath = Path.Combine(Request.PhysicalApplicationPath, folderName);
            strImagePath = Path.Combine(strFolderPath, picName);
            fileuploadExcel.SaveAs(strImagePath);

        }
        catch
        {
        }
        finally
        {
        }
    }

    public string fnGetPictureExtn(string pictureName)
    {
        try
        {
            if (pictureName.ToUpper().EndsWith(".JPG"))
                return ".JPG";
            else if (pictureName.ToUpper().EndsWith(".JPEG"))
                return ".JPEG";
            else if (pictureName.ToUpper().EndsWith(".GIF"))
                return ".GIF";
            else if (pictureName.ToUpper().EndsWith(".DOC"))
                return ".DOC";
            else if (pictureName.ToUpper().EndsWith(".XLS"))
                return ".XLS";
            else if (pictureName.ToUpper().EndsWith(".PDF"))
                return ".PDF";
            else if (pictureName.ToUpper().EndsWith(".PNG"))
                return ".PNG";
            else if (pictureName.ToUpper().EndsWith(".CDR"))
                return ".CDR";
            else if (pictureName.ToUpper().EndsWith(".PSD"))
                return ".PSD";
            else if (pictureName.ToUpper().EndsWith(".TXT"))
                return ".TXT";
            else if (pictureName.ToUpper().EndsWith(".XLSX"))
                return ".XLSX";
            else
            {
            }
        }
        catch
        {
        }
        finally
        {
        }
        return "";
    }

    public DataTable RemoveDuplicateRows(DataTable dTable, string colName,string col2)
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

        //ViewState["inv_table"] = null;
        //ViewState["inv_table"] = dTable;

        return dTable;
    }
}
