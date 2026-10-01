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
using System.Windows.Forms;


using System.Globalization;
using Excel;


public partial class INV_XL_upload : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    eroyalmaster erm = new eroyalmaster();
    adminmaster adm = new adminmaster();
    Transaction Transact = new Transaction();
    DataTable dt = new DataTable();
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
    public string errorFolder_China = "", file_ext_CHINAPARTS, PRODUCT_MRP_AMOUNT, PRODUCT_MRP_SL_NO, FORMAT_TYPE;
    public string PART_NO, INV_CURRENCY, PART_NO1;
    public string flag = "", inv_no = "", singlemultiple = "", TERMS = "", inv_slno = "", CURRENCY_CODE = "", FREIGHT_EXRATE = "", INSURANCE_EXRATE = "", MISC_EXRATE = "";
    double cal, cal1, invoicevalue;
    Imp_Invcopy IIC = new Imp_Invcopy();
    DataSet ds_China = new DataSet();
    DataSet ds_prod = new DataSet();
    DataSet ds = new DataSet();
    DataSet dsXML = new DataSet();
    DataTable final_dt = new DataTable();
    
    DataSet ds1 = new DataSet();
    DataSet ds2 = new DataSet();
    DataSet ds3 = new DataSet();
    DataSet ds4 = new DataSet();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet ds_invoice = new DataSet();
    DataSet ds_scheme = new DataSet();
   
    public string SUPPLIER_NAME;
    public string SUPPLIER_ADDRESS;
    public string SUPPLIER_ADDRESS1;
    public string SUPPLIER_ADDRESS2;
    public string SUPPLIER_COUNTRYNAME;

    public string Invno;
    public string Invdt;
    public string INS_TERMS, FOB_TERMS, CHINA_INV_CURRENCY, ITEM_QTYCODE, ITEM_UNITCODE, INVSLNO, COUNTRYORIGIN, IsInvoiceno = "";
    public string Ins_amt;
    public decimal item_amt;
    public string scheme;
    public int INVCOUNT;
    string frt_val, Ins_val,Thailand_Notn = "",Thailand_Notn_SlNo = "",Result;
  
    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();

        errorFolder_China = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "China");

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

        //chk_Notn_46.Checked = false;
        //chk_Notn_85.Checked = false;

        if (ddlInv_Upload.SelectedValue == "Thailand Parts" || ddlInv_Upload.SelectedValue == "Thailand Rack")
        {
            lbl_46.Visible = true;
            lbl_85.Visible = true;
            chk_Notn_46.Visible = true;
            chk_Notn_85.Visible = true;
          
        }
        else
        {
            lbl_46.Visible = false;
            lbl_85.Visible = false;
            chk_Notn_46.Visible = false;
            chk_Notn_85.Visible = false;
            chk_Notn_46.Checked = false;
            chk_Notn_85.Checked = false;
        }
       

        if (Session["IMPORT_JOBNO"] != null)
        {

            IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
            //load_invno();
        }
        if (!Page.IsPostBack)
        {
            //Load_Jobno();
            if (Session["IMPORT_JOBNO"] != null)
            {
               
            }

            if (Directory.Exists(errorFolder_China) == false)
            {
                Directory.CreateDirectory(errorFolder_China);
            }
            if (Directory.Exists(errorFolder_China) == true)
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder_China);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    if (fileuploadExcel.FileName == fi.Name)
                    {
                        fi.Delete();
                    }
                }
            }
        }
      
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Nissan Excel Upload', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Nissan Excel Upload', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
  

    protected void btnImportInvUpload_Click(object sender, EventArgs e)
    {
        string SelectType = "";

        if (fileuploadExcel.FileName != "")
        {
            string filename = "";
            string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
            if (strFileType.Trim() == ".xls" || strFileType.Trim() == ".xlsx")
            {
                if (strFileType.Trim() == ".xls")
                {
                    filename = fileuploadExcel.FileName.Replace(".xls", "");
                }
                else if (strFileType.Trim() == ".xlsx")
                {
                    filename = fileuploadExcel.FileName.Replace(".xlsx", "");
                }
            }
       
            if (ddlInv_Upload.SelectedValue == "China PARTS")
                SelectType = "CHINAPARTS";


            else if (ddlInv_Upload.SelectedValue == "China Rack")
                SelectType = "CHINARACK";

            else if (ddlInv_Upload.SelectedValue == "Thailand Parts")
                SelectType = "THAILANDPARTS";

            else if (ddlInv_Upload.SelectedValue == "Thailand Rack")
                SelectType = "THAILANDRACK";

            else if (ddlInv_Upload.SelectedValue == "France Parts")
                SelectType = "FRANCEPARTS";
            else
            {
                Alert_msg("Select " + SelectType+" Excel File");
            }
                          
            ViewState["SelectType"] = SelectType;

           

            Get_ExcelFile_Chinna(SelectType);
        }
        else
        {
            Alert_msg("Select Excel File");
        }

      
    }  

    public string Get_ExcelFile_Chinna(string FORMATTYPE)
    {
        string connString = "";
        string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
        //string path = "C:\\Documents and Settings\\sathis\\Desktop\\" + fileuploadExcel.FileName;
        string path = errorFolder_China + "\\" + fileuploadExcel.FileName;

        string picExtension;
        string fileName2;

        if (fileuploadExcel.HasFile)
        {
            //strGID = userid;
            //picExtension = fnGetPictureExtn(fileuploadExcel.FileName);
            // fileName2 = strGID + picExtension;
            fileName2 = fileuploadExcel.FileName;
            //addtoGallery1(fileName2, errorFolder);
            DataSet result = new DataSet();
            fileuploadExcel.SaveAs(path);
            if (FORMATTYPE == "THAILANDPARTS" || FORMATTYPE == "THAILANDRACK")
            {
                FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);

                string strFileType1 = Path.GetExtension(fileuploadExcel.FileName).ToLower();

                //// Create new XLSX file.
                //var xlsxFile = new ExcelFile();

                //// Load data from XLSX file.
                //xlsxFile.LoadXlsx(fileName + ".xls", XlsxOptions.PreserveMakeCopy);

                //// Save XLSX file to XLS file.
                //xlsxFile.SaveXls(fileName + ".xls");
                
                if (strFileType.Trim() == ".xls" || strFileType.Trim() == ".xlsx")
                {
                    if (strFileType.Trim() == ".xls")
                    {
                        //1. Reading from a binary Excel file ('97-2003 format; *.xls)
                        IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                        result = excelReader.AsDataSet();
                        excelReader.Dispose();
                        excelReader.Close();
                    }
                    else if (strFileType.Trim() == ".xlsx")
                    {
                        //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                        result = excelReader.AsDataSet();
                        excelReader.Dispose();
                        excelReader.Close();
                    }
                    
                }

                stream.Dispose();
                stream.Close();

                //excelReader.Dispose();
                //excelReader.Close();
            }
            //ExportDataSetToExcel(path);

            //Connection String to Excel Workbook

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

                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = conn;

                    //DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    //DataTable dtSheet = conn.GetSchema("Tables");

                    DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    if (FORMATTYPE == "CHINAPARTS" || FORMATTYPE == "CHINARACK")
                    {
                        if (dtSheet.Rows.Count > 0)
                        {
                            for (int i = 0; i <= dtSheet.Rows.Count - 1; i++)
                            {
                                string sheetName = dtSheet.Rows[i]["TABLE_NAME"].ToString().Substring(0, 5);

                                if (sheetName.Contains("_xlnm"))
                                {
                                    dtSheet.Rows[i].Delete();
                                }
                            }
                        }
                    }

                    dtSheet.AcceptChanges();

                    string Inv_Details = "", Inv_Items = "", Inv_Items1="";
                    string[] selectedColumns = { "" };

                    if (FORMATTYPE == "CHINAPARTS")
                    {
                        //Inv_Details = dtSheet.Rows[4]["TABLE_NAME"].ToString();
                        //Inv_Items = dtSheet.Rows[5]["TABLE_NAME"].ToString();

                        Inv_Details = dtSheet.Rows[0]["TABLE_NAME"].ToString();
                        Inv_Items = dtSheet.Rows[1]["TABLE_NAME"].ToString();

                        //Inv_Details = dtSheet.Rows[1]["TABLE_NAME"].ToString();
                        //Inv_Items = dtSheet.Rows[2]["TABLE_NAME"].ToString();
                        selectedColumns = new[] { "f44", "f54", "f69", "f59", "f76", "f87" };  //It represent name of column for which you want to select records
                    }
                    if (FORMATTYPE == "CHINARACK")
                    {
                        Inv_Details = dtSheet.Rows[1]["TABLE_NAME"].ToString();
                        Inv_Items = dtSheet.Rows[0]["TABLE_NAME"].ToString();
                        //Inv_Details = dtSheet.Rows[2]["TABLE_NAME"].ToString();
                        //Inv_Items = dtSheet.Rows[1]["TABLE_NAME"].ToString();
                               
                        selectedColumns = new[] { "f40", "f44", "f53", "f68" };  //It represent name of column for which you want to select records
                        
                    }
                    if (FORMATTYPE == "THAILANDPARTS")
                    {
                        //read_excel(path);

                        Inv_Details = result.Tables[0].TableName;
                        Inv_Items = result.Tables[1].TableName;

                        selectedColumns = new[] { "column3", "column4", "column7", "column8" };  //It represent name of column for which you want to select records
                

                    }
                    if (FORMATTYPE == "THAILANDRACK")
                    {
                        //read_excel(path);

                        Inv_Details = result.Tables[0].TableName;
                        //Inv_Items = result.Tables[1].TableName;

                        //selectedColumns = new[] { "column3", "column4", "column6", "column7" };  //It represent name of column for which you want to select records
                        selectedColumns = new[] { "column6", "column7", "column12", "column15" }; 
                    }
                   
                    if (FORMATTYPE == "FRANCEPARTS")
                    {
                        Inv_Details = dtSheet.Rows[0]["TABLE_NAME"].ToString();
                        //Inv_Items = dtSheet.Rows[5]["TABLE_NAME"].ToString();
                        selectedColumns = new[] { "f18", "f39", "f23", "f26", "f12" };  //It represent name of column for which you want to select records
                    }


                    OleDbDataAdapter da = new OleDbDataAdapter();
                    if (Inv_Details != string.Empty)
                    {
                        cmd.CommandText = "Select * from[" + Inv_Details + "]";
                        da = new OleDbDataAdapter(cmd);
                        
                      
                        //DataTable tableWithOnlySelectedColumns = new DataView(dts).ToTable(false, selectedColumns);
                        if (FORMATTYPE == "FRANCEPARTS")
                        {
                            DataTable dts = new DataTable();
                            da.Fill(dts);
                            dts.TableName = "Table";

                            var arrayNames = (from DataColumn x in dts.Columns
                                              select x.ColumnName).ToArray();

                            Invdt = arrayNames[0].ToString();

                            //foreach (var fi in arrayNames)
                            //{
                                //if (fi.Length == 10)
                                //{
                                    //Invdt = fi.ToString();
                                //}
                            //}

                            DataTable tableWithOnlySelectedColumns = new DataView(dts).ToTable(false, selectedColumns);
                            ds_China.Tables.Add(RemoveUnusedColumnsAndRows(tableWithOnlySelectedColumns));
  
                        }
                      
                        else if (FORMATTYPE == "THAILANDPARTS")
                        {
                            //DataTable tableWithOnlySelectedColumns = new DataView(result.Tables[1]).ToTable(false, selectedColumns);
                            //ds_China.Tables.Add(RemoveUnusedColumnsAndRows(tableWithOnlySelectedColumns));
                        }
                        else if (FORMATTYPE == "THAILANDRACK")
                        {
                            DataTable tableWithOnlySelectedColumns = new DataView(result.Tables[0]).ToTable(false, selectedColumns);
                            ds_China.Tables.Add(RemoveUnusedColumnsAndRows(tableWithOnlySelectedColumns));
                        }
                      
                        else
                        {
                            da.Fill(ds_China);
                        }
                        //ds_China.Tables.Add(RemoveUnusedColumnsAndRows(tableWithOnlySelectedColumns));

                    }
                    if (Inv_Items != string.Empty)
                    {
                        if (FORMATTYPE == "THAILANDPARTS")
                        {
                            DataTable tableWithOnlySelectedColumns = new DataView(result.Tables[1]).ToTable(false, selectedColumns);                     
                            ds_China.Tables.Add(RemoveUnusedColumnsAndRows(tableWithOnlySelectedColumns));
                        }
                        else if (FORMATTYPE == "THAILANDRACK")
                        {
                            //DataTable tableWithOnlySelectedColumns = new DataView(result.Tables[0]).ToTable(false, selectedColumns);
                            //ds_China.Tables.Add(RemoveUnusedColumnsAndRows(tableWithOnlySelectedColumns));
                        }
                        else
                        {
                            cmd.CommandText = "Select * from [" + Inv_Items + "]";
                            da = new OleDbDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dt.TableName = "Inv_Items";
                            DataTable tableWithOnlySelectedColumns = new DataView(dt).ToTable(false, selectedColumns);
                            ds_China.Tables.Add(RemoveUnusedColumnsAndRows(tableWithOnlySelectedColumns));

                        }
                    }

                    da.Dispose();
                    conn.Close();
                    conn.Dispose();
                    //cmd.CommandText = "Select * from[" + Inv_Items1 + "]";
                    //da = new OleDbDataAdapter(cmd);
                    //DataTable dst = new DataTable();
                    //da.Fill(dst);
                    //dst.TableName = "Inv_Items1";


                    if (FORMATTYPE == "CHINARACK")
                    {
                        COUNTRYORIGIN = "CHINA";
                        //string status = "DESCRIPTION";
                        DataColumn dc = new DataColumn("DESCRIPTION");
                        ds_China.Tables[1].Columns.Add(dc);
                        foreach (DataRow dr in ds_China.Tables[1].Rows)
                        {
                            dr["DESCRIPTION"] = ds_China.Tables[0].Rows[34]["F22"].ToString();
                        }
                        SUPPLIER_NAME = ds_China.Tables[0].Rows[0]["F41"].ToString();
                        SUPPLIER_ADDRESS = ds_China.Tables[0].Rows[1]["F41"].ToString();
                        SUPPLIER_ADDRESS1 = ds_China.Tables[0].Rows[2]["F41"].ToString();
                        SUPPLIER_ADDRESS2 = ds_China.Tables[0].Rows[3]["F41"].ToString();
                       

                        Invno = ds_China.Tables[0].Rows[7]["F42"].ToString();
                        Invdt = ds_China.Tables[0].Rows[7]["F73"].ToString();

                        //Terms
                        FOB_TERMS = ds_China.Tables[0].Rows[36]["F57"].ToString();
                        CHINA_INV_CURRENCY = ds_China.Tables[0].Rows[44]["F61"].ToString();
                        //ITEM_QTYCODE = "PLT";
                        ITEM_QTYCODE = "PCS";
                        ITEM_UNITCODE = "USD";
                        //INS_TERMS = ds_China.Tables[0].Rows[44]["F52"].ToString();

                        

                        //Ins_amt = ds_China.Tables[0].Rows[46]["F65"].ToString();

                        ds_China.Tables[1].Columns[0].ColumnName = "PART_NO";
                        //ds_China.Tables[1].Columns[1].ColumnName = "DESCRIPTION";
                        ds_China.Tables[1].Columns[1].ColumnName = "QTY";
                        ds_China.Tables[1].Columns[2].ColumnName = "UNITPRICE";
                        ds_China.Tables[1].Columns[3].ColumnName = "AMOUNT";

                        IsInvoice_No(Invno);
                        if (IsInvoiceno == Invno && FORMATTYPE == "CHINARACK")
                        {

                            Invno = Invno + "-1";
                            if (INVCOUNT > 0)
                            {
                                INVSLNO = Convert.ToString(INVCOUNT + 1);
                            }
                            else
                            {
                                INVSLNO = "1";
                            }
                            ds_China.Tables.Remove("Table");
                            ViewState["ds_China_upload"] = ds_China;
                            Get_ProductMaster();
                        }
                        else
                        {

                            if (INVCOUNT > 0)
                            {
                                INVSLNO = Convert.ToString(INVCOUNT + 1);
                            }
                            else
                            {
                                INVSLNO = "1";
                            }
                            ds_China.Tables.Remove("Table");
                            ViewState["ds_China_upload"] = ds_China;
                            Get_ProductMaster();
                        }
                        
                    }
                    if (FORMATTYPE == "CHINAPARTS" )
                    {
                        COUNTRYORIGIN = "CHINA";               
                        SUPPLIER_NAME = ds_China.Tables[0].Rows[0]["F41"].ToString();
                        SUPPLIER_ADDRESS = ds_China.Tables[0].Rows[1]["F41"].ToString();
                        SUPPLIER_ADDRESS1 = ds_China.Tables[0].Rows[2]["F41"].ToString();
                        SUPPLIER_ADDRESS2 = ds_China.Tables[0].Rows[3]["F41"].ToString();
                        //SUPPLIER_COUNTRYNAME = "CHINA";

                        //****************************** FOR SPLIT THE COUNTRY NAME ********************************

                        //string s = ds_China.Tables[0].Rows[2]["F41"].ToString();

                        //var getNumbers = (from t in s
                        //                  where char.IsDigit(t)
                        //                  select t).ToArray();

                        //string gn = new string(getNumbers);

                        //string Numbers=gn;

                        //if (gn.Length == 6)
                        //{
                        //    string myString = (gn.Length == 6) ? gn.Substring(gn.Length - 6, 6) : gn;
                        //}
                        //else
                        //{
                        //    string myString = (gn.Length == 6) ? gn.Substring(gn.Length - 6, 6) : gn;
                        //}
                        //string[] split = Regex.Split(s, gn);

                        //****************************** FOR SPLIT THE COUNTRY NAME ********************************


                        Invno = ds_China.Tables[0].Rows[7]["F42"].ToString();
                        Invdt = ds_China.Tables[0].Rows[7]["F73"].ToString();

                        Ins_val = ds_China.Tables[0].Rows[46]["F65"].ToString();

                        FOB_TERMS = ds_China.Tables[0].Rows[36]["F57"].ToString().Replace("&","");
                        CHINA_INV_CURRENCY = ds_China.Tables[0].Rows[48]["F61"].ToString();
                        ITEM_QTYCODE = "PCS";
                        ITEM_UNITCODE = "USD";

                        INS_TERMS = ds_China.Tables[0].Rows[46]["F52"].ToString();
                        Ins_amt = ds_China.Tables[0].Rows[46]["F65"].ToString();

                        ds_China.Tables[1].Columns[0].ColumnName = "PART_NO";
                        ds_China.Tables[1].Columns[1].ColumnName = "DESCRIPTION";
                        ds_China.Tables[1].Columns[2].ColumnName = "QTY";
                        ds_China.Tables[1].Columns[3].ColumnName = "UNITPRICE";
                        ds_China.Tables[1].Columns[4].ColumnName = "AMOUNT";

                        DataRow[] rows;
                        rows = ds_China.Tables[1].Select("DESCRIPTION = 'DESCRIPTION'");  //'DESCRIPTION' is ColumnName
                        foreach (DataRow row in rows)
                            ds_China.Tables[1].Rows.Remove(row);

                        IsInvoice_No(Invno);
                        if (IsInvoiceno == Invno && FORMATTYPE == "CHINAPARTS")
                        {
                            Alert_msg(Invno + " Invoice No Already Exist!");
                        }
                        else
                        {
                            if (INVCOUNT > 0)
                            {
                                INVSLNO = Convert.ToString(INVCOUNT + 1);
                            }
                            else
                            {
                                INVSLNO = "1";
                            }
                            ds_China.Tables.Remove("Table"); 
                            ViewState["ds_China_upload"] = ds_China;
                            Get_ProductMaster();
                        }
                    }
                    if (FORMATTYPE == "THAILANDPARTS")
                    {
                        COUNTRYORIGIN = "THAILAND";
                        SUPPLIER_NAME = result.Tables[0].Rows[0]["column12"].ToString();
                        SUPPLIER_ADDRESS = result.Tables[0].Rows[1]["column12"].ToString();
                        SUPPLIER_ADDRESS1 = result.Tables[0].Rows[2]["column12"].ToString();
                        SUPPLIER_ADDRESS2 = "";

                        Invno = result.Tables[0].Rows[5]["column10"].ToString();
                        Invdt = result.Tables[0].Rows[5]["column14"].ToString();
                        //double d = double.Parse(Convert.ToString(Invdt));
                        //DateTime conv = DateTime.FromOADate(d);
                        //Invdt = Convert.ToString(conv);

                        FOB_TERMS = result.Tables[0].Rows[34]["column18"].ToString();
                        CHINA_INV_CURRENCY = result.Tables[0].Rows[34]["column17"].ToString();
                        ITEM_QTYCODE = result.Tables[0].Rows[34]["column15"].ToString().Replace("(", "").Replace(")", "").Replace(".", "");

                        ITEM_UNITCODE = "USD";

                        frt_val = result.Tables[0].Rows[45]["column18"].ToString();
                        Ins_val = result.Tables[0].Rows[46]["column18"].ToString();

                        if (chk_Notn_46.Checked == true)
                        {
                            Thailand_Notn = "046/2011";
                        }
                        else if (chk_Notn_85.Checked == true)
                        {
                            Thailand_Notn = "085/2004";
                        }
                        else
                        {
                            Thailand_Notn = "";
                        }

                        //INS_TERMS = ds_China.Tables[0].Rows[46]["F52"].ToString();
                        //Ins_amt = ds_China.Tables[0].Rows[46]["F65"].ToString();

                        ds_China.Tables[0].Columns[0].ColumnName = "PART_NO";
                        ds_China.Tables[0].Columns[1].ColumnName = "DESCRIPTION";
                        ds_China.Tables[0].Columns[2].ColumnName = "QTY";
                        ds_China.Tables[0].Columns[3].ColumnName = "UNITPRICE";
                        //ds_China.Tables[0].Columns[4].ColumnName = "AMOUNT";
                        ds_China.Tables[0].Rows.RemoveAt(0);
                        ds_China.Tables[0].Rows.RemoveAt(1);
                        ds_China.Tables[0].Rows.RemoveAt(0);

                        DataRow[] rows;
                        rows = ds_China.Tables[0].Select("DESCRIPTION = 'DESCRIPTION'");  //'DESCRIPTION' is ColumnName
                        foreach (DataRow row in rows)
                            ds_China.Tables[0].Rows.Remove(row);

                        IsInvoice_No(Invno);
                        if (IsInvoiceno == Invno && FORMATTYPE == "THAILANDPARTS")
                        {

                            Alert_msg(Invno + " Invoice No Already Exist!");

                        }
                        else
                        {
                            if (INVCOUNT > 0)
                            {
                                INVSLNO = Convert.ToString(INVCOUNT + 1);
                            }
                            else
                            {
                                INVSLNO = "1";
                            }

                            for (int i = ds_China.Tables[0].Rows.Count - 1; i >= 0; i--)
                            {
                                if (ds_China.Tables[0].Rows[i]["PART_NO"] == DBNull.Value)
                                {
                                    ds_China.Tables[0].Rows[i].Delete();
                                }
                            }
                            ds_China.Tables[0].AcceptChanges();
                            

                            //result.Tables.Remove("Table");
                            ViewState["ds_China_upload"] = ds_China;
                            Get_ProductMaster();
                        }
                    }

                    if (FORMATTYPE == "THAILANDRACK")
                    {
                        COUNTRYORIGIN = "THAILAND";
                        SUPPLIER_NAME = result.Tables[0].Rows[0]["column10"].ToString();
                        SUPPLIER_ADDRESS = result.Tables[0].Rows[1]["column10"].ToString();
                        SUPPLIER_ADDRESS1 = result.Tables[0].Rows[2]["column10"].ToString();
                        SUPPLIER_ADDRESS2 = "";

                        Invno = result.Tables[0].Rows[5]["column10"].ToString();
                        Invdt = result.Tables[0].Rows[5]["column14"].ToString();
                        //double d = double.Parse(Convert.ToString(Invdt));
                        //DateTime conv = DateTime.FromOADate(d);
                        //Invdt = Convert.ToString(conv);

                        FOB_TERMS = "FOB";
                        CHINA_INV_CURRENCY = result.Tables[0].Rows[33]["column15"].ToString();
                        //ITEM_QTYCODE = result.Tables[0].Rows[33]["column12"].ToString().Replace("(", "").Replace(")", "").Replace(".", "");
                        ITEM_QTYCODE = "PCS";
                        ITEM_UNITCODE = "USD";

                        string pp = result.Tables[0].Rows[35]["column6"].ToString();
                        string pp2 = result.Tables[0].Rows[36]["column6"].ToString();


                        ds_China.Tables[0].Columns[0].ColumnName = "DESCRIPTION";
                        ds_China.Tables[0].Columns[1].ColumnName = "PART_NO";
                        ds_China.Tables[0].Columns[2].ColumnName = "QTY";
                        ds_China.Tables[0].Columns[3].ColumnName = "UNITPRICE";
                        //ds_China.Tables[0].Columns[4].ColumnName = "AMOUNT";
                        //ds_China.Tables[0].Rows.RemoveAt(0);
                        //ds_China.Tables[0].Rows.RemoveAt(0);
                        //ds_China.Tables[0].Rows.RemoveAt(0);

                        //DataRow[] rows;
                        //rows = ds_China.Tables[0].Select("DESCRIPTION = 'DESCRIPTION'");  //'DESCRIPTION' is ColumnName
                        //foreach (DataRow row in rows)
                        //    ds_China.Tables[0].Rows.Remove(row);

                        if (chk_Notn_46.Checked == true)
                        {
                            Thailand_Notn = "046/2011";
                        }
                        else if (chk_Notn_85.Checked == true)
                        {
                            Thailand_Notn = "085/2004";
                        }
                        else
                        {
                            Thailand_Notn = "";
                        }

                        IsInvoice_No(Invno);
                        if (IsInvoiceno == Invno && FORMATTYPE == "THAILANDRACK")
                          
                        {

                            Invno = Invno + "-1";
                            if (INVCOUNT > 0)
                            {
                                INVSLNO = Convert.ToString(INVCOUNT + 1);
                            }
                            else
                            {
                                INVSLNO = "1";
                            }

                            var rows = ds_China.Tables[0].Select("QTY ='0'");
                            foreach (var row in rows)
                                ds_China.Tables[0].Rows.Remove(row);
                            //row.Delete();

                            ViewState["ds_China_upload"] = ds_China;
                            Get_ProductMaster();
                        }
                        
                        else 
                        {
                            
                                if (INVCOUNT > 0)
                                {
                                    INVSLNO = Convert.ToString(INVCOUNT + 1);
                                }
                                else
                                {
                                    INVSLNO = "1";
                                }

                            for (int i = ds_China.Tables[0].Rows.Count - 1; i >= 0; i--)
                            {
                                if (ds_China.Tables[0].Rows[i]["DESCRIPTION"] == DBNull.Value)
                                {
                                    ds_China.Tables[0].Rows[i].Delete();
                                }
                            }
                            ds_China.Tables[0].AcceptChanges();

                    

                   //************************************Remove Qty is '0' from Dataset*******************

                            var rows = ds_China.Tables[0].Select("QTY ='0'");
                            foreach (var row in rows)
                                ds_China.Tables[0].Rows.Remove(row);
                                //row.Delete();

                         
                            ViewState["ds_China_upload"] = ds_China;
                            Get_ProductMaster();
                            //result.Tables.Remove("Table");
                           
                        }
                    }
                    if (FORMATTYPE == "FRANCEPARTS")
                    {
                        COUNTRYORIGIN = "FRANCE"; 
                        SUPPLIER_NAME = "";
                        SUPPLIER_ADDRESS = "";
                        SUPPLIER_ADDRESS1 = "";
                        SUPPLIER_ADDRESS2 = "";

                        //Invno = ds_China.Tables[0].Rows[7]["F42"].ToString();
                        //Invdt = ds_China.Tables[0].Rows[07]["F1"].ToString();
                       
                        //Invdt = "01/01/2015";

                        FOB_TERMS = "FOB";
                        CHINA_INV_CURRENCY = "USD";
                        ITEM_QTYCODE = "PCS";
                        ITEM_UNITCODE = "USD";

                        INS_TERMS = "";
                        Ins_amt = "";

                        ds_China.Tables[0].Columns[0].ColumnName = "PART_NO";
                        ds_China.Tables[0].Columns[1].ColumnName = "DESCRIPTION";
                        ds_China.Tables[0].Columns[2].ColumnName = "QTY";
                        ds_China.Tables[0].Columns[3].ColumnName = "UNITPRICE";
                        ds_China.Tables[0].Columns[4].ColumnName = "INVOICE_NO";
                        ds_China.Tables[0].Rows.RemoveAt(0);
                        ds_China.Tables[0].Rows.RemoveAt(1);
                        ds_China.Tables[0].Rows.RemoveAt(0);
                        ds_China.Tables[0].Rows.RemoveAt(0);
                        ds_China.Tables[0].Rows.RemoveAt(ds_China.Tables[0].Rows.Count-1);

                        //DataRow[] rows;
                        //rows = ds_China.Tables[1].Select("DESCRIPTION = 'DESCRIPTION'");  //'DESCRIPTION' is ColumnName
                        //foreach (DataRow row in rows)
                            //ds_China.Tables[1].Rows.Remove(row);

                            Get_ProductMaster();
                      
                    }

                    if (CHINA_INV_CURRENCY == string.Empty)
                    {
                        CHINA_INV_CURRENCY = "USD";

                    }
                    if (FOB_TERMS == string.Empty)
                    {
                        FOB_TERMS = "FOB";
                    }
                }

                DirectoryInfo dir = new DirectoryInfo(errorFolder_China);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    if (fileuploadExcel.FileName == fi.Name)
                    {
                        fi.Delete();
                    }
                }

                //ViewState["ds_China_upload"] = ds_China;
            }
            else
            {
                Alert_msg("Not a Valid File");
            }
        }
        else
        {
            Alert_msg("File Should Not be Empty.");
        }

      
        return strFileType.Trim();

       
    }


    public void IsInvoice_No(string Inv_no)
    {
        Transact.JOBNO = IMPORT_JOBNO;
        Transact.INVOICE_NO = "";
        Transact.WORKING_PERIOD = SELECT_BRANCH;
        Transact.flag = "INVOICE_NO";
        Transact.TERMS = "";
        Transact.INVOICE_SLNO = "";

        DataSet ds = new DataSet();
        ds = Transact.RetrieveAll_Invoice_Details();

        DataRow[] rows1;
        rows1 = ds.Tables[0].Select("INVOICE_NO = '" + Inv_no + "'");  //'DESCRIPTION' is ColumnName
        INVCOUNT = ds.Tables[0].Rows.Count;
        foreach (DataRow row in rows1)
        {
            IsInvoiceno = row["INVOICE_NO"].ToString();
        }
    }
    public void Get_ProductMaster()
    {
        FORMAT_TYPE = ViewState["SelectType"].ToString();
       

        if (FORMAT_TYPE == "FRANCEPARTS")
        {
            DataView view = new DataView(ds_China.Tables[0]);
            DataTable distinctValues = view.ToTable(true, "INVOICE_NO");
            DataSet dtsss = new DataSet();
            dtsss.Tables.Add(distinctValues);
            ViewState["DS_FRANCE"] = dtsss;
            ViewState["DSS_FRANCE"] = ds_China;
  
                Get_Imp_Product("Get_Product_GMMCO");

                //Excel_Upload_load_France();
            
        }
        else if (FORMAT_TYPE == "THAILANDPARTS" || FORMAT_TYPE == "THAILANDRACK")
        {
            Get_Imp_Product("Get_Product_Thailand");
            //Excel_Upload_load_All();
        }
        else
        {

            Get_Imp_Product("Get_Product_GMMCO");
            //Excel_Upload_load_All();
        }
    }
    public DataTable getLinq(DataTable dt1, DataTable dt2)
    {
        DataTable dtMerged =
             (from a in dt1.AsEnumerable()
              join b in dt2.AsEnumerable()
                                on
      a["PRODUCT_DESCRIPTION"].ToString() equals b["PRODUCT_DESCRIPTION"].ToString()
                              into g
              where g.Count() > 0
              select a).CopyToDataTable();
        return dtMerged;
    }


    public void Get_Imp_Product(string flag)
    {
        DataSet ds_comp = new DataSet();

        erm.PRODUCT_IMPORT_ID = "";
        erm.PRODUCT_DESCRIPTION = "";
        erm.PRODUCT_CTH = "";
        erm.PRODUCT_CETH = "";
        erm.PRODUCT_RITC = "";
        erm.Ename = flag;// "Get_Product_Thailand"//Get_Product_GMMCO;
        erm.EWorking_Period = Working_Period;

        ds_prod = erm.RetrieveAll_Product_import_MASTER();

        if (FORMAT_TYPE == "FRANCEPARTS")
        {
            ds_comp = ds_China = (DataSet)ViewState["DSS_FRANCE"];
        }
        else
        {
            ds_comp = ds_China = (DataSet)ViewState["ds_China_upload"];
        }

        
        DataTable dtt = new DataTable();
        DataTable dtt_prod = new DataTable();
        //DataTable dt_PartNo = new DataTable();
        //DataRow dr = new DataRow();

        //dtt.Columns.Add("PRODUCT_DESCRIPTION");
        //dtt_prod.Columns.Add("PRODUCT_DESCRIPTION");

        dtt.Columns.Add("PARTNO");
        dtt_prod.Columns.Add("PARTNO");

        for (int j = 0; j < ds_China.Tables[0].Rows.Count; j++)
        {
            //dtt.Rows.Add(ds_China.Tables[0].Rows[j]["PRODUCT_DESCRIPTION"].ToString().TrimEnd());
            dtt.Rows.Add(ds_China.Tables[0].Rows[j]["PART_NO"].ToString().TrimEnd());
        }

        for (int i = dtt.Rows.Count - 1; i >= 0; i += -1)
        {
            DataRow row = dtt.Rows[i];
            if (row[0] == null)
            {
                dtt.Rows.Remove(row);
            }
            else if (string.IsNullOrEmpty(row[0].ToString()))
            {
                dtt.Rows.Remove(row);
            }
        }
        if (FORMAT_TYPE == "CHINAPARTS" || FORMAT_TYPE == "CHINARACK" || FORMAT_TYPE == "THAILANDPARTS" || FORMAT_TYPE == "THAILANDRACK" || FORMAT_TYPE == "FRANCEPARTS")
        {
            for (int j = 0; j < ds_prod.Tables[0].Rows.Count; j++)
            {
                dtt_prod.Rows.Add(ds_prod.Tables[0].Rows[j]["PARTNO"].ToString().TrimEnd());
            }
        }
        else
        {
            for (int j = 0; j < ds_prod.Tables[0].Rows.Count; j++)
            {
                dtt_prod.Rows.Add(ds_prod.Tables[0].Rows[j]["PARTNO"].ToString());
            }
        }


        DataTable dt_prod = dtt_prod;

        var dt_GMMCO = dtt_prod.Clone();
        dt_GMMCO = dtt;

        var table3 = dtt_prod.Copy();
        table3.AcceptChanges();
        table3.Merge(dt_GMMCO);

        //var distintTable = distinctRows.CopyToDataTable();

        var diff = dt_GMMCO.AsEnumerable().Except(dt_prod.AsEnumerable(),
                                                    DataRowComparer.Default);
        int count = diff.Count();

        if (count > 0)
        {

            var distintTable = diff.CopyToDataTable();

            if (distintTable.Rows.Count > 0)
            {
                string NotExists = "";

                for(int i=0;i<=count-1;i++)
                {
                    NotExists =NotExists+ distintTable.Rows[i]["PARTNO"].ToString() + " , ";
                }

                //Result = NotExists;
                errorlist.Text = NotExists;
                //MessageBox.Show(NotExists, "Not Exists", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
                 
        }
        else
        {
            
            if (FORMAT_TYPE == "FRANCEPARTS")
            {
                Excel_Upload_load_France();
            }
            else
            {
                Excel_Upload_load_All();
            }
            //errorlist.Text = "Ready to Upload"; 
            Result = "Ready to Upload"; 
        }
    }
    public DataTable RemoveUnusedColumnsAndRows(DataTable dt)
    {
        for (int i = dt.Rows.Count - 1; i >= 0; i--)
        {
            if (dt.Rows[i][1] == DBNull.Value)
                dt.Rows[i].Delete();
        }
        dt.AcceptChanges();
        foreach (var column in dt.Columns.Cast<DataColumn>().ToArray())
        {
            if (dt.AsEnumerable().All(dr => dr.IsNull(column)))
                dt.Columns.Remove(column);
        }

        dt.AcceptChanges();
        return dt;
    }


    public void Excel_Upload_load_France()
    {
        DataSet france = (DataSet)ViewState["DS_FRANCE"];

        foreach (DataRow row in france.Tables[0].Rows)
        {
            Invno = row["INVOICE_NO"].ToString();
            IsInvoice_No(Invno);
            if (IsInvoiceno == Invno && FORMAT_TYPE == "FRANCEPARTS")
            {
                Invno += Invno;
                Alert_msg(Invno + " Invoice No Already Exist!");
            }
            else
            {
                if (INVCOUNT > 0)
                {
                    INVSLNO = Convert.ToString(INVCOUNT + 1);
                }
                else
                {
                    INVSLNO = "1";
                }
               
                DataSet dsXML_FR = new DataSet();
                DataTable table = new DataTable();

                table.Columns.Add("PART_NO", typeof(string));
                table.Columns.Add("DESCRIPTION", typeof(string));
                table.Columns.Add("QTY", typeof(string));
                table.Columns.Add("UNITPRICE", typeof(string));
                table.Columns.Add("INVOICE_NO", typeof(string));

                DataSet france_ds = new DataSet();
                france_ds = (DataSet)ViewState["DSS_FRANCE"];

                DataRow[] rowss;
                rowss = france_ds.Tables[0].Select("INVOICE_NO = '" + Invno + "'");  //'DESCRIPTION' is ColumnName
                DataRow rsaow;
                foreach (DataRow rowsssd in rowss)
                {
                    rsaow = table.NewRow();
                    rsaow["PART_NO"] = rowsssd["PART_NO"].ToString();
                    rsaow["DESCRIPTION"] = rowsssd["DESCRIPTION"].ToString();
                    rsaow["QTY"] = rowsssd["QTY"].ToString();
                    rsaow["UNITPRICE"] = rowsssd["UNITPRICE"].ToString();
                    rsaow["INVOICE_NO"] = rowsssd["INVOICE_NO"].ToString();
                    table.Rows.Add(rsaow);
                }

                //ds_China.Tables.Remove("Table");
                //ds_China.Tables.Remove("Table");

                //}
                DataSet dts = new DataSet();
                dts.Tables.Add(table);

                ViewState["ds_China_upload"] = null;
                ViewState["ds_China_upload"] = dts;

                //Get_Imp_Product("Get_Product_GMMCO");

                //-------------------------------------------------Excel Upload--------------------------------------------------------
                DataTable dtPart = new DataTable();
                DataTable dt_GMMCO_new = new DataTable();
                FORMAT_TYPE = ViewState["SelectType"].ToString();


                DataSet Inv_ds_China = new DataSet();

                DataSet dt_All = new DataSet();
                string file_ext = ".xlsx";
                object sumObject;

                DataSet ds_Supp = (DataSet)ViewState["dtsupp"];

                //ds.Tables.Add("Invoice_dt");
                //Inv_ds = ds = (DataSet)ViewState["ds_Excel_upload"];
                Inv_ds_China = ds = (DataSet)ViewState["ds_China_upload"];

                dt_GMMCO_new = Inv_ds_China.Tables[0];

                DataTable d = new DataTable();
                //d.Columns.Add("INVOICE_SLNO");
                d.Columns.Add("INVOICE_NO");
                d.Columns.Add("MIS_FREIGHT_CHARGES", typeof(double));
                d.Columns.Add("MIS_INSURANCE_CHARGES", typeof(double));
                d.Columns.Add("MIS_CHARGES", typeof(double));

                DataTable db = new DataTable();
                //d.Columns.Add("INVOICE_SLNO");
                db.Columns.Add("INVOICE_NO");
                db.Columns.Add("MIS_FREIGHT_CHARGES");
                db.Columns.Add("MIS_INSURANCE_CHARGES");
                db.Columns.Add("MIS_CHARGES");

                #region freight CALC


                var Freight = "0.00";
                var Insrance = "0.00";
                var MISc = "0.00";


                //PART_NO += ds_China.Tables[0].Rows[k][15].ToString() + ',';
                d.Rows.Add(Invno, Freight, Insrance, MISc);

                #endregion

                var count = ds.Tables[0].Rows.Count;
                int inv_sl_no = 1;
                int a = 0, b = 0, c = 0;

                #region create dataset column
                dsXML_FR.Tables.Add("InvoiceDetails");
                dsXML_FR.Tables[0].Columns.Add("INVOICE_ID");
                dsXML_FR.Tables[0].Columns.Add("JOBNO");
                dsXML_FR.Tables[0].Columns.Add("INVOICE_SLNO");

                dsXML_FR.Tables[0].Columns.Add("INVOICE_NO");
                // dsXML_FR.Tables[0].Columns.Add("INVOICE_DATE", typeof(DateTime));
                dsXML_FR.Tables[0].Columns.Add("INVOICE_DATE");

                dsXML_FR.Tables[0].Columns.Add("TERMS");
                dsXML_FR.Tables[0].Columns.Add("INVOICE_CURRENCY");
                dsXML_FR.Tables[0].Columns.Add("INVOICE_EXRATE");
                dsXML_FR.Tables[0].Columns.Add("INVOICE_VALUE");
                dsXML_FR.Tables[0].Columns.Add("SUPPLIER_NAME");
                dsXML_FR.Tables[0].Columns.Add("SUPPLIER_ADDRESS");
                dsXML_FR.Tables[0].Columns.Add("SUPPLIER_ADDRESS1");
                dsXML_FR.Tables[0].Columns.Add("SUPPLIER_ADDRESS2");
                dsXML_FR.Tables[0].Columns.Add("SUPPLIER_COUNTRY_NAME");
                dsXML_FR.Tables[0].Columns.Add("SUPPLIER_COUNTRY_CODE");
                dsXML_FR.Tables[0].Columns.Add("SUPPLIER_COUNTRY_PINCODE");
                dsXML_FR.Tables[0].Columns.Add("SELLER_NAME");
                dsXML_FR.Tables[0].Columns.Add("SELLER_ADDRESS");
                dsXML_FR.Tables[0].Columns.Add("SELLER_ADDRESS1");
                dsXML_FR.Tables[0].Columns.Add("SELLER_ADDRESS2");
                dsXML_FR.Tables[0].Columns.Add("SELLER_COUNTRY_NAME");
                dsXML_FR.Tables[0].Columns.Add("SELLER_COUNTRY_CODE");
                dsXML_FR.Tables[0].Columns.Add("SELLERCOUNTRY_PINCODE");
                dsXML_FR.Tables[0].Columns.Add("BROKER_NAME");
                dsXML_FR.Tables[0].Columns.Add("BROKER_ADDRESS");
                dsXML_FR.Tables[0].Columns.Add("BROKER_ADDRESS1");
                dsXML_FR.Tables[0].Columns.Add("BROKER_ADDRESS2");
                dsXML_FR.Tables[0].Columns.Add("BROKER_COUNTRY_NAME");
                dsXML_FR.Tables[0].Columns.Add("BROKER_COUNTRY_CODE");
                dsXML_FR.Tables[0].Columns.Add("BROKER_COUNTRY_PINCODE");
                dsXML_FR.Tables[0].Columns.Add("MIS_CHARGES");
                dsXML_FR.Tables[0].Columns.Add("MIS_RATE");
                dsXML_FR.Tables[0].Columns.Add("MIS_CURRENCY");
                dsXML_FR.Tables[0].Columns.Add("MIS_EXRATE");
                dsXML_FR.Tables[0].Columns.Add("MIS_AGENCY_CHARGES");
                dsXML_FR.Tables[0].Columns.Add("MIS_AGENCY_RATE");
                dsXML_FR.Tables[0].Columns.Add("MIS_AGENCY_CURRENCY");
                dsXML_FR.Tables[0].Columns.Add("MIS_AGENCY_EXRATE");
                dsXML_FR.Tables[0].Columns.Add("MIS_DISCOUNT_CHARGES");
                dsXML_FR.Tables[0].Columns.Add("MIS_DISCOUNT_RATE");
                dsXML_FR.Tables[0].Columns.Add("MIS_DISCOUNT_CURRENCY");
                dsXML_FR.Tables[0].Columns.Add("MIS_DISCOUNT_EXRATE");
                dsXML_FR.Tables[0].Columns.Add("MIS_DISCOUNT_REASON");
                dsXML_FR.Tables[0].Columns.Add("MIS_LOADING_CHARGES");
                dsXML_FR.Tables[0].Columns.Add("MIS_LOADING_RATE");
                dsXML_FR.Tables[0].Columns.Add("MIS_LOADING_CURRENCY");
                dsXML_FR.Tables[0].Columns.Add("MIS_LOADING_EXRATE");
                dsXML_FR.Tables[0].Columns.Add("MIS_FREIGHT_CHARGES");
                dsXML_FR.Tables[0].Columns.Add("MIS_FREIGHT_RATE");
                dsXML_FR.Tables[0].Columns.Add("MIS_FREIGHT_CURRENCY");
                dsXML_FR.Tables[0].Columns.Add("MIS_FREIGHT_EXRATE");
                dsXML_FR.Tables[0].Columns.Add("MIS_INSURANCE_CHARGES");
                dsXML_FR.Tables[0].Columns.Add("MIS_INSURANCE_RATE");
                dsXML_FR.Tables[0].Columns.Add("MIS_INSURANCE_CURRENCY");
                dsXML_FR.Tables[0].Columns.Add("MIS_INSURANCE_EXRATE");
                dsXML_FR.Tables[0].Columns.Add("MIS_HIGHSEASALE_CHARGES");
                dsXML_FR.Tables[0].Columns.Add("MIS_HIGHSEASALE_RATE");
                dsXML_FR.Tables[0].Columns.Add("MIS_HIGHSEASALE_CURRENCY");
                dsXML_FR.Tables[0].Columns.Add("MIS_HIGHSEASALE_EXRATE");
                dsXML_FR.Tables[0].Columns.Add("MIS_SINGLE_OR_MULITIPLE");
                dsXML_FR.Tables[0].Columns.Add("SVB_RELATION");
                dsXML_FR.Tables[0].Columns.Add("SVB_REF_NO");
                dsXML_FR.Tables[0].Columns.Add("SVB_REF_DATE");//, typeof(DateTime));
                dsXML_FR.Tables[0].Columns.Add("SVB_CUSTOM_HOUSE");
                dsXML_FR.Tables[0].Columns.Add("SVB_LOADING_ON");
                dsXML_FR.Tables[0].Columns.Add("SVB_ASSESABLE_RATE");
                dsXML_FR.Tables[0].Columns.Add("SVB_DUTY_RATE");
                dsXML_FR.Tables[0].Columns.Add("SVB_ASSESABLE_STATUS");
                dsXML_FR.Tables[0].Columns.Add("SVB_DUTY_STATUS");
                dsXML_FR.Tables[0].Columns.Add("OTHER_PURCHASE_ORDER");
                dsXML_FR.Tables[0].Columns.Add("OTHER_PURCHASE_ORDER_DATE");
                dsXML_FR.Tables[0].Columns.Add("OTHER_CONTRACT_NO");
                dsXML_FR.Tables[0].Columns.Add("OTHER_CONTRACT_DATE");//, typeof(DateTime));
                dsXML_FR.Tables[0].Columns.Add("OTHER_LOC_NO");
                dsXML_FR.Tables[0].Columns.Add("OTHER_LOC_DATE");//, typeof(DateTime));
                dsXML_FR.Tables[0].Columns.Add("OTHER_NATURE_OF_TRANSACTION");
                dsXML_FR.Tables[0].Columns.Add("OTHER_TERMS_OF_PAYMENT");
                dsXML_FR.Tables[0].Columns.Add("OTHER_CONDITIONS");
                dsXML_FR.Tables[0].Columns.Add("OTHER_VALUATION_METHOD");

                dsXML_FR.Tables[0].Columns.Add("NON_STD_EFFECT_DT_IMP");
                dsXML_FR.Tables[0].Columns.Add("NON_STD_BANKNAME");
                dsXML_FR.Tables[0].Columns.Add("NON_STD_CERTIFICATE_NO");
                dsXML_FR.Tables[0].Columns.Add("NON_STD_CERTIFICATE_DATE");

                //---------Sudharshan Cargo Fields-----------------//
                dsXML_FR.Tables[0].Columns.Add("SAP_DELIEVERY_ID");
                dsXML_FR.Tables[0].Columns.Add("SHIP_DATE");
                dsXML_FR.Tables[0].Columns.Add("INVOICE_LEVEL");
                dsXML_FR.Tables[0].Columns.Add("COUNTRY_OF_DEPARTURE");

                //--------End Sudharshan Cargo Fields--------------//

                dsXML_FR.Tables[0].Columns.Add("USER_ID");
                dsXML_FR.Tables[0].Columns.Add("DATE_TIME");
                dsXML_FR.Tables[0].Columns.Add("STATUS");
                dsXML_FR.Tables[0].Columns.Add("BRANCH_CODE");
                dsXML_FR.Tables[0].Columns.Add("YEAR");
                dsXML_FR.Tables[0].Columns.Add("WORKING_PERIOD");

                //************************* NEW FIELDS **************************

                dsXML_FR.Tables[0].Columns.Add("MI_FREIGHT");
                dsXML_FR.Tables[0].Columns.Add("MI_INSURANCE");

                //************************* NEW FIELDS **************************


                //--------------------Item Details--------------------------//
                dsXML_FR.Tables.Add("ItemDetails");
                dsXML_FR.Tables[1].Columns.Add("ITEM_ID");
                dsXML_FR.Tables[1].Columns.Add("JOBNO");
                dsXML_FR.Tables[1].Columns.Add("INVOICE_SLNO");
                dsXML_FR.Tables[1].Columns.Add("INVOICE_NO");
                dsXML_FR.Tables[1].Columns.Add("ITEM_SLNO");
                dsXML_FR.Tables[1].Columns.Add("ITEM_DESCRIPTION");
                dsXML_FR.Tables[1].Columns.Add("ITEM_QTY");
                dsXML_FR.Tables[1].Columns.Add("ITEM_QTY_CODE");
                dsXML_FR.Tables[1].Columns.Add("ITEM_UNIT_PRICE");
                dsXML_FR.Tables[1].Columns.Add("ITEM_UNIT_CODE");
                dsXML_FR.Tables[1].Columns.Add("ITEM_TOTAL_AMOUNT", typeof(double));
                dsXML_FR.Tables[1].Columns.Add("ITEM_AMOUNT_CODE");
                dsXML_FR.Tables[1].Columns.Add("CTH_NO");
                dsXML_FR.Tables[1].Columns.Add("SCHEME_CODE");
                dsXML_FR.Tables[1].Columns.Add("SCHEME_NOTN");
                dsXML_FR.Tables[1].Columns.Add("SCHEME_NOTN_SLNO");
                dsXML_FR.Tables[1].Columns.Add("CTH_QTY1");
                dsXML_FR.Tables[1].Columns.Add("CTH_QTY1_CODE");
                dsXML_FR.Tables[1].Columns.Add("CTH_QTY2");
                dsXML_FR.Tables[1].Columns.Add("CTH_QTY2_CODE");
                dsXML_FR.Tables[1].Columns.Add("GENEARL_DESCRIPTION");
                dsXML_FR.Tables[1].Columns.Add("MANUFACTURER");
                dsXML_FR.Tables[1].Columns.Add("BRAND");
                dsXML_FR.Tables[1].Columns.Add("MODEL");
                dsXML_FR.Tables[1].Columns.Add("END_USE_OF_ITEM");
                dsXML_FR.Tables[1].Columns.Add("COUNTRY_OF_ORIGIN");
                dsXML_FR.Tables[1].Columns.Add("ACCESSORIES");
                dsXML_FR.Tables[1].Columns.Add("PREVIOUS_BE_NO");
                dsXML_FR.Tables[1].Columns.Add("PREVIOUS_BE_DATE");//, typeof(DateTime));
                dsXML_FR.Tables[1].Columns.Add("UNIT_PRICE");
                dsXML_FR.Tables[1].Columns.Add("UNIT_CODE");
                dsXML_FR.Tables[1].Columns.Add("CUSTOMS_HOUSE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_RITC");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_CTH");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_BCD_NOTN");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_BCD_SLNO");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_BCD_RATE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_BCD_SPL");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_BCD_UNIT");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_BCD_SPL_TYPE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_DUTY_NOTN");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_DUTY_NOTN_SL");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_DUTY_RATE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_EDU_CESS_NOTN");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_EDU_CESS_NOTN_SL");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_EDU_CESS_RATE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_SEC_EDU_CESS_NOTN");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_SEC_EDU_CESS_NOTN_SL");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_SEC_EDU_CESS_RATE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_NCD_NOTN");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_NCD_SLNO");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_NCD_RATE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_NCD_SPL");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_NCD_UNIT");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_NCD_SPL_TYPE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_AGGREGATE_DUTY_NOTN");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_AGGREGATE_DUTY_NOTN_SL");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_AGGREGATE_DUTY_NOTN_RATE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_SAFEGUARD_NOTN");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_SAFEGUARD_SLNO");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_SAFEGUARD_RATE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_SAFEGUARD_SPL");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_SAFEGUARD_UNIT");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_SAFEGUARD_SPL_TYPE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_SAPTA_NOTN");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_SAPTA_SLNO");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_SAPTA_RATE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_TARIFF_NOTN");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_TARIFF_SLNO");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_TARIFF_QTY");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_TARIFF_AMOUNT");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_TARIFF_AMOUNT_UNIT");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_CETH");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_MRP_YN");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_MRP_SL_NO");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_MRP_AMOUNT");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_MRP_ABT_RATE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_CVD_NOTN");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_CVD_SLNO");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_CVD_RATE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_CVD_SPL");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_CVD_UNIT");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_CVD_SPL_TYPE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_CVD_EDU_CESS_RATE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_CVD_SEC_EDU_CESS_RATE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL5_SIA_NOTN");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL5_SIA_NOTN_SL");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL5_SIA_RATE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_GSI_NOTN");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_GSI_SLNO");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_GSI_RATE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_GSI_SPL");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_GSI_UNIT");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_GSI_SPL_TYPE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_SHEII_NOTN");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_SHEII_SLNO");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_SHEII_RATE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_SHEII_SPL");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_SHEII_UNIT");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_SHEII_TYPE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_TTA_NOTN");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_TTA_SLNO");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_TTA_RATE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_TTA_SPL");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_TTA_UNIT");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_TTA_TYPE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_NOTN");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_SLNO");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_RATE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_SPL");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_UNIT");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_TYPE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_CESS_NOTN");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_CESS_SLNO");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_CESS_RATE");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_CESS_SPL");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_CESS_UNIT");
                dsXML_FR.Tables[1].Columns.Add("PRODUCT_CESS_TYPE");
                dsXML_FR.Tables[1].Columns.Add("ANTI_DUMPING_NOTN");
                dsXML_FR.Tables[1].Columns.Add("ANTI_DUMPING_NOTN_SLNO");
                dsXML_FR.Tables[1].Columns.Add("CTH_SLNO");
                dsXML_FR.Tables[1].Columns.Add("CTH_SUPPLIER_SLNO");
                dsXML_FR.Tables[1].Columns.Add("CTH_QTY");
                dsXML_FR.Tables[1].Columns.Add("RSP_DUTY_STATUS");
                dsXML_FR.Tables[1].Columns.Add("RSP_SL_NO");
                dsXML_FR.Tables[1].Columns.Add("RSP_DESC");
                dsXML_FR.Tables[1].Columns.Add("RSP_QTY");
                dsXML_FR.Tables[1].Columns.Add("RSP_AMOUNT");
                dsXML_FR.Tables[1].Columns.Add("RSP_NOTN_NO");
                dsXML_FR.Tables[1].Columns.Add("RSP_NOTN_SL_NO");
                dsXML_FR.Tables[1].Columns.Add("RSP_ABT_RATE");
                dsXML_FR.Tables[1].Columns.Add("WAREHOUSE_JOBNO");
                dsXML_FR.Tables[1].Columns.Add("WAREHOUSE_INVOICE_SLNO");
                dsXML_FR.Tables[1].Columns.Add("WAREHOUSE_ITEM_SLNO");
                dsXML_FR.Tables[1].Columns.Add("ASSESSABLE_VALUE");
                dsXML_FR.Tables[1].Columns.Add("DUTY_VALUE");
                dsXML_FR.Tables[1].Columns.Add("CIF_VALUE");
                dsXML_FR.Tables[1].Columns.Add("CVD_VALUE");


                dsXML_FR.Tables[1].Columns.Add("USER_ID");
                dsXML_FR.Tables[1].Columns.Add("DATE_TIME");
                dsXML_FR.Tables[1].Columns.Add("STATUS");
                dsXML_FR.Tables[1].Columns.Add("BRANCH_CODE");
                dsXML_FR.Tables[1].Columns.Add("YEAR");
                dsXML_FR.Tables[1].Columns.Add("WORKING_PERIOD");

                //--------------------New Field added on 08Aug2014--------------------------//

                dsXML_FR.Tables[1].Columns.Add("CETH_CVD_EDU_CESS_SL");

                dsXML_FR.Tables[1].Columns.Add("BASIC_VALUE");
                dsXML_FR.Tables[1].Columns.Add("CEC_VALUE");
                dsXML_FR.Tables[1].Columns.Add("CHEC_VALUE");
                dsXML_FR.Tables[1].Columns.Add("ADD_DUTY_VALUE");

                //---------------------End--------------------------------------------------//


                #endregion

                DataRow dr = dsXML_FR.Tables[0].NewRow();

                if (ds.Tables[0].Rows.Count > a)
                {


                    if (file_ext == ".xls" || file_ext == ".xlsx")
                    {

                        int x = 1;
                        int ccc = 0;
                        double frt;
                        double bb = 0.00;

                        #region read Excel_Format

                        DataView view = new DataView(ds.Tables[0]);
                        DataTable distinctValues = view.ToTable(true, "PART_NO", "DESCRIPTION", "UNITPRICE");
                        while (distinctValues.Rows.Count > b)
                        {
                            PART_NO = distinctValues.Rows[b][0].ToString();
                            if (PART_NO != "" && PART_NO != "PART NO.")
                            {
                                PART_NO1 += distinctValues.Rows[b][0].ToString() + ',';
                            }
                            b++;
                        }

                        int sum = 0;
                        b = 0;

                        int item_sl_no = 1;

                        //while (distinctValues.Rows[b][0] != System.DBNull.Value)
                        while (distinctValues.Rows.Count > b)
                        {

                            PART_NO = distinctValues.Rows[b][0].ToString();

                            /******* FOR CHECKING PART NO AVAILABLE OR NOT IN RSPINPUTNEW TABLE *****************************/
                            if (PART_NO != "" && PART_NO != "PART NO.")
                            {
                                if (b == 0)
                                {
                                    if (FORMAT_TYPE == "CHINAPARTS")
                                    {
                                        //GET_RSP_PartNo();
                                        dtPart = (DataTable)ViewState["dt_PartNo"];
                                    }

                                    dr["INVOICE_ID"] = "";
                                    dr["JOBNO"] = IMPORT_JOBNO;
                                    dr["INVOICE_NO"] = Invno.TrimEnd();
                                    dr["INVOICE_SLNO"] = INVSLNO;
                                    DateTime INVdate = DateTime.ParseExact(Invdt, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                                    string inv_date = INVdate.ToShortDateString();

                                    string inv_date1 = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(inv_date));
                                    dr["INVOICE_DATE"] = Convert.ToDateTime(inv_date).ToString(@"MM/dd/yyyy");

                                    dr["TERMS"] = FOB_TERMS;

                                    dr["INVOICE_CURRENCY"] = CHINA_INV_CURRENCY;
                                    INV_CURRENCY = dr["INVOICE_CURRENCY"].ToString();

                                    if (dr["INVOICE_CURRENCY"] != "")
                                    {
                                        adm.Invoice_Currency = dr["INVOICE_CURRENCY"].ToString(); ;

                                        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                        adm.EWorking_Period = Working_Period;

                                        ds1 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                        if (ds1.Tables[0].Rows.Count > 0)
                                        {
                                            dr["INVOICE_EXRATE"] = ds1.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                        }
                                    }
                                    else
                                    {
                                        dr["INVOICE_EXRATE"] = "";
                                    }

                                    dr["INVOICE_VALUE"] = "";

                                    dr["SUPPLIER_NAME"] = SUPPLIER_NAME;
                                    dr["SUPPLIER_ADDRESS"] = SUPPLIER_ADDRESS;
                                    dr["SUPPLIER_ADDRESS1"] = SUPPLIER_ADDRESS1;
                                    dr["SUPPLIER_ADDRESS2"] = SUPPLIER_ADDRESS2;
                                    dr["SUPPLIER_COUNTRY_NAME"] = COUNTRYORIGIN;
                                    dr["SUPPLIER_COUNTRY_CODE"] = "";
                                    dr["SUPPLIER_COUNTRY_PINCODE"] = "";
                                    dr["SELLER_NAME"] = "";
                                    dr["SELLER_ADDRESS"] = "";
                                    dr["SELLER_ADDRESS1"] = "";
                                    dr["SELLER_ADDRESS2"] = "";
                                    dr["SELLER_COUNTRY_NAME"] = "";
                                    dr["SELLER_COUNTRY_CODE"] = "";
                                    dr["SELLERCOUNTRY_PINCODE"] = "";
                                    dr["BROKER_NAME"] = "";
                                    dr["BROKER_ADDRESS"] = "";
                                    dr["BROKER_ADDRESS1"] = "";
                                    dr["BROKER_ADDRESS2"] = "";
                                    dr["BROKER_COUNTRY_NAME"] = "";
                                    dr["BROKER_COUNTRY_CODE"] = "";
                                    dr["BROKER_COUNTRY_PINCODE"] = "";

                                    object MIS_CHARGES;
                                    MIS_CHARGES = d.Compute("Sum(MIS_CHARGES)", "INVOICE_NO = '" + Invno + "'");
                                    MIS_CHARGES = Convert.ToString(Math.Round(Convert.ToDouble(MIS_CHARGES), 2, MidpointRounding.AwayFromZero).ToString("0.00"));
                                    dr["MIS_CHARGES"] = MIS_CHARGES;


                                    dr["MIS_RATE"] = "";
                                    dr["MIS_CURRENCY"] = INV_CURRENCY;

                                    if (dr["INVOICE_CURRENCY"] == dr["MIS_CURRENCY"])
                                    {
                                        dr["MIS_EXRATE"] = dr["INVOICE_EXRATE"];
                                    }
                                    else
                                    {
                                        if (dr["MIS_CURRENCY"] != "")
                                        {
                                            adm.Invoice_Currency = dr["MIS_CURRENCY"].ToString(); 

                                            adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                            adm.EWorking_Period = Working_Period;

                                            ds2 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                            if (ds2.Tables[0].Rows.Count > 0)
                                            {
                                                dr["MIS_EXRATE"] = ds2.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                            }
                                        }
                                        else
                                        {
                                            dr["MIS_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                            dr["MIS_EXRATE"] = dr["INVOICE_EXRATE"];
                                        }
                                    }

                                    dr["MIS_AGENCY_CHARGES"] = "";
                                    dr["MIS_AGENCY_RATE"] = "0.00";
                                    dr["MIS_AGENCY_CURRENCY"] = INV_CURRENCY;
                                    dr["MIS_AGENCY_EXRATE"] = dr["INVOICE_EXRATE"];
                                    dr["MIS_DISCOUNT_CHARGES"] = "";
                                    dr["MIS_DISCOUNT_RATE"] = "0.00";
                                    dr["MIS_DISCOUNT_CURRENCY"] = INV_CURRENCY;
                                    dr["MIS_DISCOUNT_EXRATE"] = dr["INVOICE_EXRATE"];
                                    dr["MIS_DISCOUNT_REASON"] = "";
                                    dr["MIS_LOADING_CHARGES"] = "";
                                    dr["MIS_LOADING_RATE"] = "";
                                    dr["MIS_LOADING_CURRENCY"] = "";
                                    dr["MIS_LOADING_EXRATE"] = "";

                                    dr["MIS_HIGHSEASALE_CHARGES"] = "";
                                    dr["MIS_HIGHSEASALE_RATE"] = "0.00";
                                    dr["MIS_HIGHSEASALE_CURRENCY"] = "INR";
                                    dr["MIS_HIGHSEASALE_EXRATE"] = "1.00";
                                    dr["MIS_SINGLE_OR_MULITIPLE"] = "S";
                                    dr["SVB_RELATION"] = "N";
                                    dr["SVB_REF_NO"] = "";

                                    string SVB_REF_DATE = "01/01/1900";
                                    dr["SVB_REF_DATE"] = DateTime.Parse(SVB_REF_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    dr["SVB_CUSTOM_HOUSE"] = "";
                                    dr["SVB_LOADING_ON"] = "";
                                    dr["SVB_ASSESABLE_RATE"] = "";
                                    dr["SVB_DUTY_RATE"] = "";
                                    dr["SVB_ASSESABLE_STATUS"] = "";
                                    dr["SVB_DUTY_STATUS"] = "";
                                    dr["OTHER_PURCHASE_ORDER"] = "";

                                    string PURCHASE_ORDER_DATE = "01/01/1900";

                                    dr["OTHER_PURCHASE_ORDER_DATE"] = DateTime.Parse(PURCHASE_ORDER_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                                    dr["OTHER_CONTRACT_NO"] = "";

                                    string CONTRACT_DATE = "01/01/1900";

                                    dr["OTHER_CONTRACT_DATE"] = DateTime.Parse(CONTRACT_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                                    dr["OTHER_LOC_NO"] = "";
                                    dr["OTHER_NATURE_OF_TRANSACTION"] = "S  Sale";
                                    dr["OTHER_TERMS_OF_PAYMENT"] = "OTH  Others";
                                    dr["OTHER_CONDITIONS"] = "";
                                    dr["OTHER_VALUATION_METHOD"] = "Rule 4 - Transaction Value";

                                    string ship = "01/01/1900";
                                    dr["SAP_DELIEVERY_ID"] = "";
                                    dr["SHIP_DATE"] = DateTime.Parse(ship, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    dr["INVOICE_LEVEL"] = "";
                                    dr["COUNTRY_OF_DEPARTURE"] = "";

                                    string DATE = "01/01/1900";

                                    dr["NON_STD_EFFECT_DT_IMP"] = DateTime.Parse(DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                                    dr["NON_STD_BANKNAME"] = "";
                                    dr["NON_STD_CERTIFICATE_NO"] = "";
                                    dr["NON_STD_CERTIFICATE_DATE"] = DateTime.Parse(DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                                    dr["USER_ID"] = currentuser;
                                    dr["DATE_TIME"] = "";
                                    dr["STATUS"] = "S";
                                    dr["BRANCH_CODE"] = currentbranch;
                                    dr["YEAR"] = "";
                                    dr["WORKING_PERIOD"] = Working_Period;

                                    dt = dsXML_FR.Tables[0];

                                    /////////////////////////////////////////////////////////////

                                    //#region Invoice Terms Calculation
                                    sumObject = d.Compute("Sum(MIS_FREIGHT_CHARGES)", "INVOICE_NO = '" + Invno + "'");
                                    sumObject = Convert.ToString(Math.Round(Convert.ToDouble(sumObject), 2, MidpointRounding.AwayFromZero).ToString("0.00"));
                                    dr["MIS_FREIGHT_CHARGES"] = sumObject;

                                    object INSURANCE_CHARGES;
                                    INSURANCE_CHARGES = d.Compute("Sum(MIS_INSURANCE_CHARGES)", "INVOICE_NO = '" + Invno + "'");
                                    INSURANCE_CHARGES = Convert.ToString(Math.Round(Convert.ToDouble(INSURANCE_CHARGES), 2, MidpointRounding.AwayFromZero).ToString("0.00"));
                                    dr["MIS_INSURANCE_CHARGES"] = INSURANCE_CHARGES;

                                    dr["TERMS"] = "FOB";
                                    dr["MIS_FREIGHT_RATE"] = "20.0000";
                                    dr["MIS_FREIGHT_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                    dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];

                                    dr["MIS_INSURANCE_RATE"] = "1.1250";
                                    dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                    dr["MIS_INSURANCE_CURRENCY"] = dr["INVOICE_CURRENCY"];


                                    #region INVOICE_FREIGHT & INSURANCE CALCULATION
                                    /*

                                    if (dr["MIS_FREIGHT_CHARGES"] == "" || dr["MIS_INSURANCE_CHARGES"] == "")
                                    {
                                        if (Convert.ToString(dr["TERMS"]) == "FOB")
                                        {
                                            if (dr["MIS_FREIGHT_CHARGES"] == "")
                                            {

                                                dr["MIS_FREIGHT_RATE"] = "20.0000";

                                                double invoicevalue_Excel = Convert.ToDouble(dr["INVOICE_VALUE"]);
                                                cal = invoicevalue_Excel * 20 / 100;

                                                //dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(cal);

                                                dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(cal), 2).ToString("0.00"));

                                                dr["MIS_FREIGHT_CURRENCY"] = ds.Tables[0].Rows[a][11].ToString();

                                                if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                                                {
                                                    dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                                }
                                                else
                                                {
                                                    if (dr["MIS_FREIGHT_CURRENCY"] != "")
                                                    {
                                                        adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                                                        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                                        adm.EWorking_Period = Working_Period;

                                                        ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                                        if (ds3.Tables[0].Rows.Count > 0)
                                                        {
                                                            dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                                        }
                                                    }
                                                    else
                                                    {
                                                        dr["MIS_FREIGHT_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                                        dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                //dr["MIS_FREIGHT_CHARGES"] = ds.Tables[0].Rows[a][10].ToString();

                                                dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(ds.Tables[0].Rows[a][10]), 2).ToString("0.00"));

                                                dr["MIS_FREIGHT_RATE"] = "";
                                                dr["MIS_FREIGHT_CURRENCY"] = ds.Tables[0].Rows[a][11].ToString();

                                                if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                                                {
                                                    dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                                }
                                                else
                                                {
                                                    if (dr["MIS_FREIGHT_CURRENCY"] != "")
                                                    {
                                                        adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                                                        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                                        adm.EWorking_Period = Working_Period;

                                                        ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                                        if (ds3.Tables[0].Rows.Count > 0)
                                                        {
                                                            dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                                        }
                                                    }
                                                    else
                                                    {
                                                        dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                                    }
                                                }
                                            }

                                            if (dr["MIS_INSURANCE_CHARGES"] == "")
                                            {

                                                dr["MIS_INSURANCE_RATE"] = "1.1250";

                                                double invoicevalue_Excel1 = Convert.ToDouble(dr["INVOICE_VALUE"]);
                                                cal1 = invoicevalue_Excel1 * 1.125 / 100;

                                                //dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(cal1);

                                                dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(cal1), 2).ToString("0.00"));

                                                dr["MIS_INSURANCE_CURRENCY"] = ds.Tables[0].Rows[a][13].ToString();

                                                if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                                                {
                                                    dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                                }
                                                else
                                                {

                                                    if (dr["MIS_INSURANCE_CURRENCY"] != "")
                                                    {
                                                        adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                                                        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                                        adm.EWorking_Period = Working_Period;

                                                        ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                                        if (ds4.Tables[0].Rows.Count > 0)
                                                        {
                                                            dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                                        }

                                                    }
                                                    else
                                                    {
                                                        dr["MIS_INSURANCE_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                                        dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                                    }
                                                }
                                            }
                                            else
                                            {

                                                //dr["MIS_INSURANCE_CHARGES"] = ds.Tables[0].Rows[a][12].ToString();

                                                dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(ds.Tables[0].Rows[a][12]), 2).ToString("0.00"));

                                                dr["MIS_INSURANCE_RATE"] = "";
                                                dr["MIS_INSURANCE_CURRENCY"] = ds.Tables[0].Rows[a][13].ToString();

                                                if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                                                {
                                                    dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                                }
                                                else
                                                {

                                                    if (dr["MIS_INSURANCE_CURRENCY"] != "")
                                                    {
                                                        adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                                                        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                                        adm.EWorking_Period = Working_Period;

                                                        ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                                        if (ds4.Tables[0].Rows.Count > 0)
                                                        {
                                                            dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                                        }

                                                    }
                                                    else
                                                    {
                                                        dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                                    }
                                                }


                                            }
                                        }


                                        else if (Convert.ToString(dr["TERMS"]) == "CI")
                                        {
                                            if (dr["MIS_FREIGHT_CHARGES"] == "")
                                            {
                                                dr["MIS_FREIGHT_RATE"] = "20.0000";

                                                double invoicevalue_Excel = Convert.ToDouble(dr["INVOICE_VALUE"]);
                                                cal = invoicevalue_Excel * 20 / 100;

                                                //dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(cal);

                                                dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(cal), 2).ToString("0.00"));

                                                dr["MIS_FREIGHT_CURRENCY"] = ds.Tables[0].Rows[a][11].ToString();

                                                if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                                                {
                                                    dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                                }
                                                else
                                                {

                                                    if (dr["MIS_FREIGHT_CURRENCY"] != "")
                                                    {
                                                        adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                                                        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                                        adm.EWorking_Period = Working_Period;

                                                        ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                                        if (ds3.Tables[0].Rows.Count > 0)
                                                        {
                                                            dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                                        }

                                                    }
                                                    else
                                                    {
                                                        dr["MIS_FREIGHT_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                                        dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                                    }
                                                }
                                            }

                                            else
                                            {
                                                //dr["MIS_FREIGHT_CHARGES"] = ds.Tables[0].Rows[a][10].ToString();

                                                dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(ds.Tables[0].Rows[a][10]), 2).ToString("0.00"));

                                                dr["MIS_FREIGHT_RATE"] = "";
                                                dr["MIS_FREIGHT_CURRENCY"] = ds.Tables[0].Rows[a][11].ToString();

                                                if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                                                {
                                                    dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                                }
                                                else
                                                {
                                                    if (dr["MIS_FREIGHT_CURRENCY"] != "")
                                                    {
                                                        adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                                                        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                                        adm.EWorking_Period = Working_Period;

                                                        ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                                        if (ds3.Tables[0].Rows.Count > 0)
                                                        {
                                                            dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                                        }

                                                    }
                                                    else
                                                    {
                                                        dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                                    }
                                                }
                                            }

                                        }
                                        else if (Convert.ToString(dr["TERMS"]) == "CF")
                                        {
                                            if (dr["MIS_INSURANCE_CHARGES"] == "")
                                            {
                                                dr["MIS_INSURANCE_RATE"] = "1.1250";

                                                double invoicevalue_Excel1 = Convert.ToDouble(dr["INVOICE_VALUE"]);
                                                cal1 = invoicevalue_Excel1 * 1.125 / 100;

                                                //dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(cal1);

                                                dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(cal1), 2).ToString("0.00"));

                                                dr["MIS_INSURANCE_CURRENCY"] = ds.Tables[0].Rows[a][13].ToString();

                                                if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                                                {
                                                    dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                                }
                                                else
                                                {

                                                    if (dr["MIS_INSURANCE_CURRENCY"] != "")
                                                    {
                                                        adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                                                        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                                        adm.EWorking_Period = Working_Period;

                                                        ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                                        if (ds4.Tables[0].Rows.Count > 0)
                                                        {
                                                            dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                                        }

                                                    }
                                                    else
                                                    {
                                                        dr["MIS_INSURANCE_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                                        dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                                    }
                                                }
                                            }

                                            else
                                            {

                                                //dr["MIS_INSURANCE_CHARGES"] = ds.Tables[0].Rows[a][12].ToString();

                                                dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(ds.Tables[0].Rows[a][12]), 2).ToString("0.00"));


                                                dr["MIS_INSURANCE_RATE"] = "";
                                                dr["MIS_INSURANCE_CURRENCY"] = ds.Tables[0].Rows[a][13].ToString();

                                                if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                                                {
                                                    dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                                }
                                                else
                                                {
                                                    if (dr["MIS_INSURANCE_CURRENCY"] != "")
                                                    {
                                                        adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                                                        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                                        adm.EWorking_Period = Working_Period;

                                                        ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                                        if (ds4.Tables[0].Rows.Count > 0)
                                                        {
                                                            dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                                        }
                                                    }
                                                    else
                                                    {
                                                        dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                                    }
                                                }
                                            }
                                        }
                                        else if (Convert.ToString(dr["TERMS"]) == "CIF")
                                        {

                                        }
                                    }

                                    else
                                    {

                                        dr["MIS_FREIGHT_CHARGES"] = sumObject;
                                        dr["MIS_FREIGHT_RATE"] = "";
                                        dr["MIS_FREIGHT_CURRENCY"] = "";

                                        if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                                        {
                                            dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                        }
                                        else
                                        {

                                            if (dr["MIS_FREIGHT_CURRENCY"] != "")
                                            {
                                                adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                                                adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                                adm.EWorking_Period = Working_Period;

                                                ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                                if (ds3.Tables[0].Rows.Count > 0)
                                                {
                                                    dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                                }

                                            }
                                            else
                                            {
                                                dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                            }
                                        }


                                        //dr["MIS_INSURANCE_CHARGES"] = ds.Tables[0].Rows[a][11].ToString();
                                        dr["MIS_INSURANCE_CHARGES"] = INSURANCE_CHARGES;
                                        dr["MIS_INSURANCE_RATE"] = "";
                                        dr["MIS_INSURANCE_CURRENCY"] = "";

                                        if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                                        {
                                            dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                        }
                                        else
                                        {

                                            if (dr["MIS_INSURANCE_CURRENCY"] != "")
                                            {
                                                adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                                                adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                                adm.EWorking_Period = Working_Period;

                                                ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                                if (ds4.Tables[0].Rows.Count > 0)
                                                {
                                                    dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                                }

                                            }
                                            else
                                            {
                                                dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                            }
                                        }

                                    }

                                    */

                                    #endregion


                                }

                                //#region Item Details

                                var results = from myRow in ds.Tables[0].AsEnumerable()
                                              where myRow.Field<string>("PART_NO") == PART_NO
                                              select myRow;


                                DataView dvv1 = results.AsDataView();
                                DataTable dtt = dvv1.ToTable();
                                DataSet dst = new DataSet();
                                dst.Tables.Add(dtt);

                                var Values = from nrow in dst.Tables[0].AsEnumerable()
                                             //group row by row.Field<string>("INVOICE_NO") into g
                                             //group row by dd into g
                                             group nrow by new { id = nrow.Field<string>("PART_NO") } into g
                                             select new
                                             {
                                                 name_1 = g.Key.id,
                                                 name_2 = g.Sum(r => (Convert.ToDouble(r.Field<string>("QTY")) * Convert.ToDouble(r.Field<string>("UNITPRICE"))))

                                             };

                                DataRow dr1 = dsXML_FR.Tables[1].NewRow();

                               
                                dr1["ITEM_ID"] = "";
                                dr1["JOBNO"] = IMPORT_JOBNO;


                                dr1["INVOICE_SLNO"] = INVSLNO;
                                dr1["INVOICE_NO"] = Invno.TrimEnd();
                                dr1["ITEM_SLNO"] = item_sl_no;

                                string item_product_desc = "";

                                DataRow[] rows;
                                rows = dts.Tables[0].Select("PART_NO = '" + PART_NO + "'");  //'DESCRIPTION' is ColumnName
                                foreach (DataRow rowdr in rows)
                                {
                                    //item_product_desc = rowdr["DESCRIPTION"].ToString();
                                    item_product_desc = rowdr["PART_NO"].ToString();
                                }

                                dt_All = Get_Product_Details_All(item_product_desc);


                                if (FORMAT_TYPE == "CHINAPARTS" || FORMAT_TYPE == "CHINARACK" | FORMAT_TYPE == "FRANCEPARTS")
                                {
                                    if (dst.Tables[0].Rows.Count > 0)
                                    {
                                        dr1["ITEM_DESCRIPTION"] = PART_NO + " " + dst.Tables[0].Rows[0]["DESCRIPTION"].ToString() + " " + "(ACTUAL USER)";
                                    }
                                    else
                                    {
                                        dr1["ITEM_DESCRIPTION"] = PART_NO + " " + dt_All.Tables[0].Rows[0]["PRODUCT_DESCRIPTION"].ToString() + " " + "(ACTUAL USER)";
                                    }
                                }

                                else
                                {
                                    dr1["ITEM_DESCRIPTION"] = dt_All.Tables[0].Rows[0]["PRODUCT_DESCRIPTION"].ToString() + " " + ds.Tables[0].Rows[b][8].ToString() + " " + "(ACTUAL USER)";
                                }

                                var ITEM_QTY = from rowitem in dst.Tables[0].AsEnumerable()
                                               //group row by row.Field<string>("INVOICE_NO") into g
                                               //group row by dd into g
                                               group rowitem by new { id = rowitem.Field<string>("PART_NO") } into g
                                               select new
                                               {
                                                   name_1 = g.Key.id,
                                                   name_2 = g.Sum(r => (Convert.ToDouble(r.Field<string>("QTY"))))

                                               };

                                foreach (var drval in ITEM_QTY)
                                {

                                    dr1["ITEM_QTY"] = Convert.ToString(drval.name_2);

                                }

                                double ITEM_QTY1 = Convert.ToDouble(dr1["ITEM_QTY"]);

                                if (FORMAT_TYPE == "FRANCEPARTS")
                                {
                                    
                                    dr1["ITEM_UNIT_PRICE"] = Convert.ToDouble(dst.Tables[0].Rows[0]["UNITPRICE"].ToString()) / 100;
                                    double div_unitPrice = Convert.ToDouble(dst.Tables[0].Rows[0]["UNITPRICE"].ToString()) / 100;
                                    double Calc_UnitPrice = ITEM_QTY1 * div_unitPrice;
                                    dr1["ITEM_TOTAL_AMOUNT"] = Convert.ToString(Calc_UnitPrice);

                                }
                                else
                                {
                                    dr1["ITEM_UNIT_PRICE"] =  Convert.ToDouble(dst.Tables[0].Rows[0]["UNITPRICE"].ToString());
                                    double Calc_UnitPrice = ITEM_QTY1 * Convert.ToDouble(dst.Tables[0].Rows[0]["UNITPRICE"].ToString());
                                    dr1["ITEM_TOTAL_AMOUNT"] = Convert.ToString(Calc_UnitPrice);

                                }

                                //if (FORMAT_TYPE == "FRANCEPARTS")
                                //{
                                  
                                //    double div_unitPrice = Convert.ToDouble(dst.Tables[0].Rows[0]["UNITPRICE"].ToString()) / 100;
                                //    double Calc_UnitPrice = ITEM_QTY1 * div_unitPrice;

                                //    dr1["ITEM_UNIT_PRICE"] = Convert.ToString(Calc_UnitPrice);
                                //}
                                //else
                                //{
                                //    double Calc_UnitPrice = ITEM_QTY1 * Convert.ToDouble(dst.Tables[0].Rows[0]["UNITPRICE"].ToString());
                                //    dr1["ITEM_UNIT_PRICE"] = Convert.ToString(Calc_UnitPrice);
                                //}

                                //*************************** BALAJI CODING UNITPRICE CALC**********************************

                                //var ITEM_UNIT_PRICE = from rowunit in dst.Tables[0].AsEnumerable()
                                //                      //group row by row.Field<string>("INVOICE_NO") into g
                                //                      //group row by dd into g
                                //                      group rowunit by new { id = rowunit.Field<string>("PART_NO") } into g
                                //                      select new
                                //                      {
                                //                          name_1 = g.Key.id,
                                //                          name_2 = g.Sum(r => (Convert.ToDouble(r.Field<string>("UNITPRICE"))))

                                //                      };

                                //foreach (var drval in ITEM_UNIT_PRICE)
                                //{
                                //    double unit = 0;
                                //    if (FORMAT_TYPE == "FRANCEPARTS")
                                //    {
                                //        unit = (drval.name_2 / 2);
                                //        unit = unit / 100;
                                //        dr1["ITEM_UNIT_PRICE"] = Convert.ToString(unit);
                                //    }
                                //    else
                                //    {
                                //        dr1["ITEM_UNIT_PRICE"] = Convert.ToString(drval.name_2);
                                //    }
                                //}

                                //*************************** BALAJI CODING UNITPRICE CALC**********************************

                                dr1["ITEM_QTY_CODE"] = ITEM_QTYCODE;

                                dr1["ITEM_UNIT_CODE"] = ITEM_UNITCODE;

                                dr1["ITEM_AMOUNT_CODE"] = "USD";
                                dr1["CTH_NO"] = dt_All.Tables[0].Rows[0]["PRODUCT_CTH"].ToString();

                                scheme = "00";

                                if (scheme != "" && scheme != "00" && scheme != "0")
                                {
                                    if (Convert.ToInt32(scheme) <= 9)
                                    {
                                        scheme = "0" + scheme;
                                    }
                                    scheme = Get_Scheme_Code(scheme);
                                    dr1["SCHEME_CODE"] = scheme;
                                    //dr1["SCHEME_NOTN"] = ds.Tables[0].Rows[b][36].ToString();
                                    //dr1["SCHEME_NOTN_SLNO"] = ds.Tables[0].Rows[b][37].ToString();
                                }
                                else
                                {
                                    dr1["SCHEME_CODE"] = "00 - DUTIABLE";
                                    dr1["SCHEME_NOTN"] = "";
                                    dr1["SCHEME_NOTN_SLNO"] = "";
                                }
                                dr1["CTH_QTY1"] = "";
                                dr1["CTH_QTY1_CODE"] = "";
                                dr1["CTH_QTY2"] = "";
                                dr1["CTH_QTY2_CODE"] = "";
                                dr1["GENEARL_DESCRIPTION"] = dt_All.Tables[0].Rows[0]["PRODUCT_GENERAL_DESC"].ToString();
                                dr1["MANUFACTURER"] = dt_All.Tables[0].Rows[0]["PRODUCT_MANUFACTURER"].ToString();
                                dr1["BRAND"] = dt_All.Tables[0].Rows[0]["PRODUCT_BRAND"].ToString();
                                dr1["MODEL"] = dt_All.Tables[0].Rows[0]["PRODUCT_MODEL"].ToString();
                                dr1["END_USE_OF_ITEM"] = dt_All.Tables[0].Rows[0]["PRODUCT_END_USE"].ToString();
                                dr1["COUNTRY_OF_ORIGIN"] = COUNTRYORIGIN;
                                dr1["ACCESSORIES"] = dt_All.Tables[0].Rows[0]["PRODUCT_ACCESSORIES"].ToString();
                                dr1["PREVIOUS_BE_NO"] = "";

                                string BE_DATE = "01/01/1900";

                                dr1["PREVIOUS_BE_DATE"] = DateTime.Parse(BE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);


                                dr1["UNIT_PRICE"] = "";
                                dr1["UNIT_CODE"] = "";
                                dr1["CUSTOMS_HOUSE"] = "";
                                dr1["PRODUCT_RITC"] = dt_All.Tables[0].Rows[0]["PRODUCT_RITC"].ToString();

                                dr1["PRODUCT_CTH"] = dt_All.Tables[0].Rows[0]["PRODUCT_CTH"].ToString();
                                dr1["PRODUCT_BCD_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_BCD_NOTN"].ToString();
                                dr1["PRODUCT_BCD_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_BCD_SLNO"].ToString();
                                dr1["PRODUCT_BCD_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_BCD_RATE"].ToString();
                                dr1["PRODUCT_BCD_SPL"] = dt_All.Tables[0].Rows[0]["PRODUCT_BCD_SPL"].ToString();
                                dr1["PRODUCT_BCD_UNIT"] = dt_All.Tables[0].Rows[0]["PRODUCT_BCD_UNIT"].ToString();
                                dr1["PRODUCT_BCD_SPL_TYPE"] = dt_All.Tables[0].Rows[0]["PRODUCT_BCD_SPL_TYPE"].ToString();

                                //dr1["PRODUCT_ADDL_DUTY_NOTN"] = "";
                                //dr1["PRODUCT_ADDL_DUTY_NOTN_SL"] = "";
                                //dr1["PRODUCT_ADDL_DUTY_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_BCD_SPL_TYPE"].ToString();
                                dr1["PRODUCT_EDU_CESS_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_EDU_CESS_NOTN"].ToString();
                                dr1["PRODUCT_EDU_CESS_NOTN_SL"] = dt_All.Tables[0].Rows[0]["PRODUCT_EDU_CESS_NOTN_SL"].ToString();
                                dr1["PRODUCT_EDU_CESS_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_EDU_CESS_RATE"].ToString();
                                dr1["PRODUCT_SEC_EDU_CESS_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_SEC_EDU_CESS_NOTN"].ToString();
                                dr1["PRODUCT_SEC_EDU_CESS_NOTN_SL"] = dt_All.Tables[0].Rows[0]["PRODUCT_SEC_EDU_CESS_NOTN_SL"].ToString();
                                dr1["PRODUCT_SEC_EDU_CESS_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_SEC_EDU_CESS_RATE"].ToString();

                                dr1["PRODUCT_NCD_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_NCD_NOTN"].ToString();
                                dr1["PRODUCT_NCD_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_NCD_SLNO"].ToString();
                                dr1["PRODUCT_NCD_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_NCD_RATE"].ToString();
                                dr1["PRODUCT_NCD_SPL"] = dt_All.Tables[0].Rows[0]["PRODUCT_NCD_SPL"].ToString();
                                dr1["PRODUCT_NCD_UNIT"] = dt_All.Tables[0].Rows[0]["PRODUCT_NCD_UNIT"].ToString();
                                dr1["PRODUCT_NCD_SPL_TYPE"] = dt_All.Tables[0].Rows[0]["PRODUCT_NCD_SPL_TYPE"].ToString();

                                dr1["PRODUCT_AGGREGATE_DUTY_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_AGGREGATE_DUTY_NOTN"].ToString();
                                dr1["PRODUCT_AGGREGATE_DUTY_NOTN_SL"] = dt_All.Tables[0].Rows[0]["PRODUCT_AGGREGATE_DUTY_NOTN_SL"].ToString();
                                dr1["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"].ToString();

                                dr1["PRODUCT_SAFEGUARD_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_NOTN"].ToString();
                                dr1["PRODUCT_SAFEGUARD_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_SLNO"].ToString();
                                dr1["PRODUCT_SAFEGUARD_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_RATE"].ToString();
                                dr1["PRODUCT_SAFEGUARD_SPL"] = dt_All.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_SPL"].ToString();
                                dr1["PRODUCT_SAFEGUARD_UNIT"] = dt_All.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_UNIT"].ToString();
                                dr1["PRODUCT_SAFEGUARD_SPL_TYPE"] = dt_All.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_SPL_TYPE"].ToString();
                                //dr1["PRODUCT_SAPTA_NOTN"] = "";
                                //dr1["PRODUCT_SAPTA_SLNO"] = "";

                                dr1["PRODUCT_SAPTA_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_SAPTA_NOTN"].ToString();
                                dr1["PRODUCT_SAPTA_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_SAPTA_SLNO"].ToString();
                                dr1["PRODUCT_SAPTA_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_SAPTA_RATE"].ToString();

                                dr1["PRODUCT_TARIFF_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_TARIFF_NOTN"].ToString();
                                dr1["PRODUCT_TARIFF_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_TARIFF_SLNO"].ToString();
                                dr1["PRODUCT_TARIFF_QTY"] = dt_All.Tables[0].Rows[0]["PRODUCT_TARIFF_QTY"].ToString();
                                dr1["PRODUCT_TARIFF_AMOUNT"] = dt_All.Tables[0].Rows[0]["PRODUCT_TARIFF_AMOUNT"].ToString();
                                dr1["PRODUCT_TARIFF_AMOUNT_UNIT"] = dt_All.Tables[0].Rows[0]["PRODUCT_TARIFF_AMOUNT_UNIT"].ToString();
                                dr1["PRODUCT_CETH"] = dt_All.Tables[0].Rows[0]["PRODUCT_CETH"].ToString();
                                dr1["RSP_NOTN_NO"] = dt_All.Tables[0].Rows[0]["PRODUCT_RSP_NOTN_NO"].ToString();
                                dr1["RSP_NOTN_SL_NO"] = dt_All.Tables[0].Rows[0]["PRODUCT_RSP_NOTN_SL_NO"].ToString();

                                string PRODUCT_MRP_YN = dt_All.Tables[0].Rows[0]["PRODUCT_MRP_YN"].ToString();
                                string PRODUCT_MRP_ABT_RATE = dt_All.Tables[0].Rows[0]["PRODUCT_MRP_ABT_RATE"].ToString();
                                dr1["PRODUCT_MRP_YN"] = dt_All.Tables[0].Rows[0]["PRODUCT_MRP_YN"].ToString();
                                string str_get_ABT_RATE_RSP;

                                if (PART_NO != "")
                                {
                                    if (PRODUCT_MRP_YN == "N")
                                    {
                                        dr1["PRODUCT_MRP_YN"] = "N";
                                        dr1["PRODUCT_MRP_AMOUNT"] = "";
                                        dr1["PRODUCT_MRP_ABT_RATE"] = "";

                                        dr1["RSP_NOTN_NO"] = "";
                                        dr1["RSP_NOTN_SL_NO"] = "";
                                    }
                                    else
                                    {
                                        if (PRODUCT_MRP_ABT_RATE != "")
                                        {
                                            dr1["PRODUCT_MRP_ABT_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_MRP_ABT_RATE"].ToString();
                                        }
                                        else
                                        {
                                            get_ABT_RATE_RSP(dr1["PRODUCT_RITC"].ToString(), dr1["RSP_NOTN_NO"].ToString(), dr1["RSP_NOTN_SL_NO"].ToString());
                                            str_get_ABT_RATE_RSP = ViewState["get_ABT_RATE_RSP"].ToString();

                                            if (str_get_ABT_RATE_RSP != "")
                                            {
                                                dr1["PRODUCT_MRP_YN"] = "Y";
                                                dr1["PRODUCT_MRP_SL_NO"] = "1";
                                                dr1["PRODUCT_MRP_ABT_RATE"] = str_get_ABT_RATE_RSP;

                                            }
                                            else
                                            {
                                                dr1["PRODUCT_MRP_YN"] = "N";
                                                dr1["PRODUCT_MRP_SL_NO"] = "";
                                                dr1["PRODUCT_MRP_ABT_RATE"] = str_get_ABT_RATE_RSP;
                                            }
                                        }
                                    }
                                }

                                dr1["PRODUCT_CVD_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_CVD_NOTN"].ToString();
                                dr1["PRODUCT_CVD_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_CVD_SLNO"].ToString();
                                dr1["PRODUCT_CVD_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_CVD_RATE"].ToString();
                                dr1["PRODUCT_CVD_SPL"] = dt_All.Tables[0].Rows[0]["PRODUCT_CVD_SPL"].ToString();
                                dr1["PRODUCT_CVD_UNIT"] = dt_All.Tables[0].Rows[0]["PRODUCT_CVD_UNIT"].ToString();
                                dr1["PRODUCT_CVD_SPL_TYPE"] = dt_All.Tables[0].Rows[0]["PRODUCT_CVD_SPL_TYPE"].ToString();
                                dr1["PRODUCT_CVD_EDU_CESS_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_CVD_EDU_CESS_RATE"].ToString();
                                dr1["CETH_CVD_EDU_CESS_SL"] = dt_All.Tables[0].Rows[0]["PRODUCT_CVD_SEC_EDU_CESS_RATE"].ToString();

                                dr1["PRODUCT_ADDL_DUTY_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_DUTY_NOTN"].ToString();
                                dr1["PRODUCT_ADDL_DUTY_NOTN_SL"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_DUTY_NOTN_SL"].ToString();
                                dr1["PRODUCT_ADDL_GSI_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_NOTN"].ToString();
                                dr1["PRODUCT_ADDL_GSI_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_SLNO"].ToString();

                                dr1["PRODUCT_ADDL_TTA_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_NOTN"].ToString();
                                dr1["PRODUCT_ADDL5_SIA_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL5_SIA_NOTN"].ToString();
                                dr1["PRODUCT_ADDL5_SIA_NOTN_SL"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL5_SIA_NOTN_SL"].ToString();
                                dr1["PRODUCT_ADDL5_SIA_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL5_SIA_RATE"].ToString();

                                dr1["PRODUCT_ADDL_GSI_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_SLNO"].ToString();
                                dr1["PRODUCT_ADDL_GSI_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_RATE"].ToString();
                                dr1["PRODUCT_ADDL_GSI_SPL"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_SPL"].ToString();
                                dr1["PRODUCT_ADDL_GSI_UNIT"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_UNIT"].ToString();
                                dr1["PRODUCT_ADDL_GSI_SPL_TYPE"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_SPL_TYPE"].ToString();

                                dr1["PRODUCT_ADDL_SHEII_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_NOTN"].ToString();
                                dr1["PRODUCT_ADDL_SHEII_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_SLNO"].ToString();
                                dr1["PRODUCT_ADDL_SHEII_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_RATE"].ToString();
                                dr1["PRODUCT_ADDL_SHEII_SPL"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_SPL"].ToString();
                                dr1["PRODUCT_ADDL_SHEII_UNIT"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_UNIT"].ToString();
                                dr1["PRODUCT_ADDL_SHEII_TYPE"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_TYPE"].ToString();

                                dr1["PRODUCT_ADDL_TTA_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_SLNO"].ToString();
                                dr1["PRODUCT_ADDL_TTA_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_RATE"].ToString();
                                dr1["PRODUCT_ADDL_TTA_SPL"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_SPL"].ToString();
                                dr1["PRODUCT_ADDL_TTA_UNIT"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_UNIT"].ToString();
                                dr1["PRODUCT_ADDL_TTA_TYPE"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_TYPE"].ToString();

                                dr1["PRODUCT_ADDL_HEALTH_CESS_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_NOTN"].ToString();
                                dr1["PRODUCT_ADDL_HEALTH_CESS_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_SLNO"].ToString();
                                dr1["PRODUCT_ADDL_HEALTH_CESS_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_RATE"].ToString();
                                dr1["PRODUCT_ADDL_HEALTH_CESS_SPL"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_SPL"].ToString();
                                dr1["PRODUCT_ADDL_HEALTH_CESS_UNIT"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_UNIT"].ToString();
                                dr1["PRODUCT_ADDL_HEALTH_CESS_TYPE"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_TYPE"].ToString();

                                dr1["PRODUCT_CESS_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_CESS_NOTN"].ToString();
                                dr1["PRODUCT_CESS_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_CESS_SLNO"].ToString();
                                dr1["PRODUCT_CESS_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_CESS_RATE"].ToString();
                                dr1["PRODUCT_CESS_SPL"] = dt_All.Tables[0].Rows[0]["PRODUCT_CESS_SPL"].ToString();
                                dr1["PRODUCT_CESS_UNIT"] = dt_All.Tables[0].Rows[0]["PRODUCT_CESS_UNIT"].ToString();
                                dr1["PRODUCT_CESS_TYPE"] = dt_All.Tables[0].Rows[0]["PRODUCT_CESS_TYPE"].ToString();

                                dr1["ANTI_DUMPING_NOTN"] = "";
                                dr1["ANTI_DUMPING_NOTN_SLNO"] = "";
                                dr1["CTH_SLNO"] = "";
                                dr1["CTH_SUPPLIER_SLNO"] = "";
                                dr1["CTH_QTY"] = "";
                                dr1["RSP_DUTY_STATUS"] = "";
                                dr1["RSP_SL_NO"] = "";
                                dr1["RSP_DESC"] = "";
                                dr1["RSP_QTY"] = "";
                                dr1["RSP_AMOUNT"] = "";
                                //dr1["RSP_NOTN_NO"] = "";
                                //dr1["RSP_NOTN_SL_NO"] = "";
                                dr1["RSP_ABT_RATE"] = "";
                                dr1["WAREHOUSE_JOBNO"] = "0";
                                dr1["WAREHOUSE_INVOICE_SLNO"] = "0";
                                dr1["WAREHOUSE_ITEM_SLNO"] = "0";
                                dr1["ASSESSABLE_VALUE"] = "";

                                dr1["DUTY_VALUE"] = "";
                                dr1["CIF_VALUE"] = "";
                                dr1["CVD_VALUE"] = "";

                                dr1["USER_ID"] = currentuser;
                                dr1["DATE_TIME"] = "";
                                dr1["STATUS"] = "N";
                                dr1["BRANCH_CODE"] = currentbranch;

                                dr1["YEAR"] = "";
                                dr1["WORKING_PERIOD"] = Working_Period;

                                dr1["BASIC_VALUE"] = "";
                                dr1["CEC_VALUE"] = "";
                                dr1["CHEC_VALUE"] = "";
                                dr1["ADD_DUTY_VALUE"] = "";

                                dsXML_FR.Tables[1].Rows.Add(dr1);


                                //#endregion

                            }


                            item_sl_no++;
                            b++;
                        }


                   #endregion

                        #region Inserting
                        dt = dsXML_FR.Tables["ItemDetails"];

                        string dd = Invno;
                        double Invval = 0;
                        var ItemValues = from rowval in dsXML_FR.Tables["ItemDetails"].AsEnumerable()
                                         //group row by row.Field<string>("INVOICE_NO") into g
                                         //group row by dd into g
                                         group rowval by new { id = rowval.Field<string>("INVOICE_NO") } into g
                                         select new
                                         {
                                             name_1 = g.Key.id,

                                             name_2 = g.Sum(r => r.Field<double>("ITEM_TOTAL_AMOUNT"))

                                         };

                        foreach (var drval in ItemValues)
                        {
                            //if (drval.name_1 == dd)
                            //{
                            Invval = drval.name_2;
                            //}
                        }

                        var final_inv_val = Invval.ToString();
                        final_inv_val = Convert.ToString(Math.Round(Convert.ToDouble(final_inv_val), 2).ToString("0.00"));
                        dr["INVOICE_VALUE"] = final_inv_val;


                        //**************** TO CALCULATE FREIGHT VALUE **************************************
                        double invoicevalue_Excel = Convert.ToDouble(dr["INVOICE_VALUE"]);
                        cal = invoicevalue_Excel * 20 / 100;
                        dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(cal), 2).ToString("0.00"));

                        //**************** TO CALCULATE INSURANCE VALUE **************************************

                        double invoicevalue_Excel1 = Convert.ToDouble(dr["INVOICE_VALUE"]);
                        cal1 = invoicevalue_Excel1 * 1.125 / 100;
                        dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(cal1), 2).ToString("0.00"));

                        //*************************************************************************************

                        dsXML_FR.Tables[0].Rows.Add(dr);

                        //a++;
                        //inv_sl_no++;
                        #endregion

                    }
                }

                dt = dsXML_FR.Tables["InvoiceDetails"];

                string inv_type = string.Empty;

                if (ddlInv_Upload.SelectedValue == "China PARTS" || ddlInv_Upload.SelectedValue == "Thailand Parts" || ddlInv_Upload.SelectedValue == "France Parts")
                {
                    inv_type = "P";
                }
                else
                {
                    inv_type = "R";
                }

                Transact.Bulk_Item_Excel_Upload_GMMCO(RemoveDuplicateRows(dt, "INVOICE_NO"), dsXML_FR.Tables[1], "BULK_ITEM_UPLOAD", inv_type);
            }

        }
        
        if (Transact.result == 1)
        {
            // Response.Redirect(Request.RawUrl);

            Response.Redirect(Request.RawUrl,false);
            Alert_msg("Uploaded Successfully");
        }
        else
        {
            Alert_msg("Excel Upload occured some problem");
        }

    }
    public void Excel_Upload_load_All()
    {
        DataTable dtPart = new DataTable();
        DataTable dt_GMMCO_new = new DataTable();
        FORMAT_TYPE = ViewState["SelectType"].ToString();

        
        DataSet Inv_ds_China = new DataSet();

        DataSet dt_All = new DataSet();
        string file_ext = ".xlsx";
        object sumObject;

        DataSet ds_Supp = (DataSet)ViewState["dtsupp"];

        //ds.Tables.Add("Invoice_dt");
        //Inv_ds = ds = (DataSet)ViewState["ds_Excel_upload"];
        Inv_ds_China = ds = (DataSet)ViewState["ds_China_upload"];

        dt_GMMCO_new = Inv_ds_China.Tables[0];

        DataTable d = new DataTable();
        //d.Columns.Add("INVOICE_SLNO");
        d.Columns.Add("INVOICE_NO");
        d.Columns.Add("MIS_FREIGHT_CHARGES", typeof(double));
        d.Columns.Add("MIS_INSURANCE_CHARGES", typeof(double));
        d.Columns.Add("MIS_CHARGES", typeof(double));

        DataTable db = new DataTable();
        //d.Columns.Add("INVOICE_SLNO");
        db.Columns.Add("INVOICE_NO");
        db.Columns.Add("MIS_FREIGHT_CHARGES");
        db.Columns.Add("MIS_INSURANCE_CHARGES");
        db.Columns.Add("MIS_CHARGES");

        #region freight CALC


        var Freight = "0.00";
        var Insrance = "0.00";
        var MISc = "0.00";


        //PART_NO += ds_China.Tables[0].Rows[k][15].ToString() + ',';
        d.Rows.Add(Invno, Freight, Insrance, MISc);

        #endregion

        var count = ds.Tables[0].Rows.Count;
        int inv_sl_no = 1;
        int a = 0, b = 0, c = 0;

        #region create dataset column
        dsXML.Tables.Add("InvoiceDetails");
        dsXML.Tables[0].Columns.Add("INVOICE_ID");
        dsXML.Tables[0].Columns.Add("JOBNO");
        dsXML.Tables[0].Columns.Add("INVOICE_SLNO");

        dsXML.Tables[0].Columns.Add("INVOICE_NO");
        // dsXML.Tables[0].Columns.Add("INVOICE_DATE", typeof(DateTime));
        dsXML.Tables[0].Columns.Add("INVOICE_DATE");

        dsXML.Tables[0].Columns.Add("TERMS");
        dsXML.Tables[0].Columns.Add("INVOICE_CURRENCY");
        dsXML.Tables[0].Columns.Add("INVOICE_EXRATE");
        dsXML.Tables[0].Columns.Add("INVOICE_VALUE");
        dsXML.Tables[0].Columns.Add("SUPPLIER_NAME");
        dsXML.Tables[0].Columns.Add("SUPPLIER_ADDRESS");
        dsXML.Tables[0].Columns.Add("SUPPLIER_ADDRESS1");
        dsXML.Tables[0].Columns.Add("SUPPLIER_ADDRESS2");
        dsXML.Tables[0].Columns.Add("SUPPLIER_COUNTRY_NAME");
        dsXML.Tables[0].Columns.Add("SUPPLIER_COUNTRY_CODE");
        dsXML.Tables[0].Columns.Add("SUPPLIER_COUNTRY_PINCODE");
        dsXML.Tables[0].Columns.Add("SELLER_NAME");
        dsXML.Tables[0].Columns.Add("SELLER_ADDRESS");
        dsXML.Tables[0].Columns.Add("SELLER_ADDRESS1");
        dsXML.Tables[0].Columns.Add("SELLER_ADDRESS2");
        dsXML.Tables[0].Columns.Add("SELLER_COUNTRY_NAME");
        dsXML.Tables[0].Columns.Add("SELLER_COUNTRY_CODE");
        dsXML.Tables[0].Columns.Add("SELLERCOUNTRY_PINCODE");
        dsXML.Tables[0].Columns.Add("BROKER_NAME");
        dsXML.Tables[0].Columns.Add("BROKER_ADDRESS");
        dsXML.Tables[0].Columns.Add("BROKER_ADDRESS1");
        dsXML.Tables[0].Columns.Add("BROKER_ADDRESS2");
        dsXML.Tables[0].Columns.Add("BROKER_COUNTRY_NAME");
        dsXML.Tables[0].Columns.Add("BROKER_COUNTRY_CODE");
        dsXML.Tables[0].Columns.Add("BROKER_COUNTRY_PINCODE");
        dsXML.Tables[0].Columns.Add("MIS_CHARGES");
        dsXML.Tables[0].Columns.Add("MIS_RATE");
        dsXML.Tables[0].Columns.Add("MIS_CURRENCY");
        dsXML.Tables[0].Columns.Add("MIS_EXRATE");
        dsXML.Tables[0].Columns.Add("MIS_AGENCY_CHARGES");
        dsXML.Tables[0].Columns.Add("MIS_AGENCY_RATE");
        dsXML.Tables[0].Columns.Add("MIS_AGENCY_CURRENCY");
        dsXML.Tables[0].Columns.Add("MIS_AGENCY_EXRATE");
        dsXML.Tables[0].Columns.Add("MIS_DISCOUNT_CHARGES");
        dsXML.Tables[0].Columns.Add("MIS_DISCOUNT_RATE");
        dsXML.Tables[0].Columns.Add("MIS_DISCOUNT_CURRENCY");
        dsXML.Tables[0].Columns.Add("MIS_DISCOUNT_EXRATE");
        dsXML.Tables[0].Columns.Add("MIS_DISCOUNT_REASON");
        dsXML.Tables[0].Columns.Add("MIS_LOADING_CHARGES");
        dsXML.Tables[0].Columns.Add("MIS_LOADING_RATE");
        dsXML.Tables[0].Columns.Add("MIS_LOADING_CURRENCY");
        dsXML.Tables[0].Columns.Add("MIS_LOADING_EXRATE");
        dsXML.Tables[0].Columns.Add("MIS_FREIGHT_CHARGES");
        dsXML.Tables[0].Columns.Add("MIS_FREIGHT_RATE");
        dsXML.Tables[0].Columns.Add("MIS_FREIGHT_CURRENCY");
        dsXML.Tables[0].Columns.Add("MIS_FREIGHT_EXRATE");
        dsXML.Tables[0].Columns.Add("MIS_INSURANCE_CHARGES");
        dsXML.Tables[0].Columns.Add("MIS_INSURANCE_RATE");
        dsXML.Tables[0].Columns.Add("MIS_INSURANCE_CURRENCY");
        dsXML.Tables[0].Columns.Add("MIS_INSURANCE_EXRATE");
        dsXML.Tables[0].Columns.Add("MIS_HIGHSEASALE_CHARGES");
        dsXML.Tables[0].Columns.Add("MIS_HIGHSEASALE_RATE");
        dsXML.Tables[0].Columns.Add("MIS_HIGHSEASALE_CURRENCY");
        dsXML.Tables[0].Columns.Add("MIS_HIGHSEASALE_EXRATE");
        dsXML.Tables[0].Columns.Add("MIS_SINGLE_OR_MULITIPLE");
        dsXML.Tables[0].Columns.Add("SVB_RELATION");
        dsXML.Tables[0].Columns.Add("SVB_REF_NO");
        dsXML.Tables[0].Columns.Add("SVB_REF_DATE");//, typeof(DateTime));
        dsXML.Tables[0].Columns.Add("SVB_CUSTOM_HOUSE");
        dsXML.Tables[0].Columns.Add("SVB_LOADING_ON");
        dsXML.Tables[0].Columns.Add("SVB_ASSESABLE_RATE");
        dsXML.Tables[0].Columns.Add("SVB_DUTY_RATE");
        dsXML.Tables[0].Columns.Add("SVB_ASSESABLE_STATUS");
        dsXML.Tables[0].Columns.Add("SVB_DUTY_STATUS");
        dsXML.Tables[0].Columns.Add("OTHER_PURCHASE_ORDER");
        dsXML.Tables[0].Columns.Add("OTHER_PURCHASE_ORDER_DATE");
        dsXML.Tables[0].Columns.Add("OTHER_CONTRACT_NO");
        dsXML.Tables[0].Columns.Add("OTHER_CONTRACT_DATE");//, typeof(DateTime));
        dsXML.Tables[0].Columns.Add("OTHER_LOC_NO");
        dsXML.Tables[0].Columns.Add("OTHER_LOC_DATE");//, typeof(DateTime));
        dsXML.Tables[0].Columns.Add("OTHER_NATURE_OF_TRANSACTION");
        dsXML.Tables[0].Columns.Add("OTHER_TERMS_OF_PAYMENT");
        dsXML.Tables[0].Columns.Add("OTHER_CONDITIONS");
        dsXML.Tables[0].Columns.Add("OTHER_VALUATION_METHOD");

        dsXML.Tables[0].Columns.Add("NON_STD_EFFECT_DT_IMP");
        dsXML.Tables[0].Columns.Add("NON_STD_BANKNAME");
        dsXML.Tables[0].Columns.Add("NON_STD_CERTIFICATE_NO");
        dsXML.Tables[0].Columns.Add("NON_STD_CERTIFICATE_DATE");

        //---------Sudharshan Cargo Fields-----------------//
        dsXML.Tables[0].Columns.Add("SAP_DELIEVERY_ID");
        dsXML.Tables[0].Columns.Add("SHIP_DATE");
        dsXML.Tables[0].Columns.Add("INVOICE_LEVEL");
        dsXML.Tables[0].Columns.Add("COUNTRY_OF_DEPARTURE");

        //--------End Sudharshan Cargo Fields--------------//

        dsXML.Tables[0].Columns.Add("USER_ID");
        dsXML.Tables[0].Columns.Add("DATE_TIME");
        dsXML.Tables[0].Columns.Add("STATUS");
        dsXML.Tables[0].Columns.Add("BRANCH_CODE");
        dsXML.Tables[0].Columns.Add("YEAR");
        dsXML.Tables[0].Columns.Add("WORKING_PERIOD");

        //************************* NEW FIELDS **************************

        dsXML.Tables[0].Columns.Add("MI_FREIGHT");
        dsXML.Tables[0].Columns.Add("MI_INSURANCE");
        dsXML.Tables[0].Columns.Add("INDEV_INV_TYPE");

        //************************* NEW FIELDS **************************


        //--------------------Item Details--------------------------//
        dsXML.Tables.Add("ItemDetails");
        dsXML.Tables[1].Columns.Add("ITEM_ID");
        dsXML.Tables[1].Columns.Add("JOBNO");
        dsXML.Tables[1].Columns.Add("INVOICE_SLNO");
        dsXML.Tables[1].Columns.Add("INVOICE_NO");
        dsXML.Tables[1].Columns.Add("ITEM_SLNO");
        dsXML.Tables[1].Columns.Add("ITEM_DESCRIPTION");
        dsXML.Tables[1].Columns.Add("ITEM_QTY");
        dsXML.Tables[1].Columns.Add("ITEM_QTY_CODE");
        dsXML.Tables[1].Columns.Add("ITEM_UNIT_PRICE");
        dsXML.Tables[1].Columns.Add("ITEM_UNIT_CODE");
        dsXML.Tables[1].Columns.Add("ITEM_TOTAL_AMOUNT", typeof(double));
        dsXML.Tables[1].Columns.Add("ITEM_AMOUNT_CODE");
        dsXML.Tables[1].Columns.Add("CTH_NO");
        dsXML.Tables[1].Columns.Add("SCHEME_CODE");
        dsXML.Tables[1].Columns.Add("SCHEME_NOTN");
        dsXML.Tables[1].Columns.Add("SCHEME_NOTN_SLNO");
        dsXML.Tables[1].Columns.Add("CTH_QTY1");
        dsXML.Tables[1].Columns.Add("CTH_QTY1_CODE");
        dsXML.Tables[1].Columns.Add("CTH_QTY2");
        dsXML.Tables[1].Columns.Add("CTH_QTY2_CODE");
        dsXML.Tables[1].Columns.Add("GENEARL_DESCRIPTION");
        dsXML.Tables[1].Columns.Add("MANUFACTURER");
        dsXML.Tables[1].Columns.Add("BRAND");
        dsXML.Tables[1].Columns.Add("MODEL");
        dsXML.Tables[1].Columns.Add("END_USE_OF_ITEM");
        dsXML.Tables[1].Columns.Add("COUNTRY_OF_ORIGIN");
        dsXML.Tables[1].Columns.Add("ACCESSORIES");
        dsXML.Tables[1].Columns.Add("PREVIOUS_BE_NO");
        dsXML.Tables[1].Columns.Add("PREVIOUS_BE_DATE");//, typeof(DateTime));
        dsXML.Tables[1].Columns.Add("UNIT_PRICE");
        dsXML.Tables[1].Columns.Add("UNIT_CODE");
        dsXML.Tables[1].Columns.Add("CUSTOMS_HOUSE");
        dsXML.Tables[1].Columns.Add("PRODUCT_RITC");
        dsXML.Tables[1].Columns.Add("PRODUCT_CTH");
        dsXML.Tables[1].Columns.Add("PRODUCT_BCD_NOTN");
        dsXML.Tables[1].Columns.Add("PRODUCT_BCD_SLNO");
        dsXML.Tables[1].Columns.Add("PRODUCT_BCD_RATE");
        dsXML.Tables[1].Columns.Add("PRODUCT_BCD_SPL");
        dsXML.Tables[1].Columns.Add("PRODUCT_BCD_UNIT");
        dsXML.Tables[1].Columns.Add("PRODUCT_BCD_SPL_TYPE");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_DUTY_NOTN");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_DUTY_NOTN_SL");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_DUTY_RATE");
        dsXML.Tables[1].Columns.Add("PRODUCT_EDU_CESS_NOTN");
        dsXML.Tables[1].Columns.Add("PRODUCT_EDU_CESS_NOTN_SL");
        dsXML.Tables[1].Columns.Add("PRODUCT_EDU_CESS_RATE");
        dsXML.Tables[1].Columns.Add("PRODUCT_SEC_EDU_CESS_NOTN");
        dsXML.Tables[1].Columns.Add("PRODUCT_SEC_EDU_CESS_NOTN_SL");
        dsXML.Tables[1].Columns.Add("PRODUCT_SEC_EDU_CESS_RATE");
        dsXML.Tables[1].Columns.Add("PRODUCT_NCD_NOTN");
        dsXML.Tables[1].Columns.Add("PRODUCT_NCD_SLNO");
        dsXML.Tables[1].Columns.Add("PRODUCT_NCD_RATE");
        dsXML.Tables[1].Columns.Add("PRODUCT_NCD_SPL");
        dsXML.Tables[1].Columns.Add("PRODUCT_NCD_UNIT");
        dsXML.Tables[1].Columns.Add("PRODUCT_NCD_SPL_TYPE");
        dsXML.Tables[1].Columns.Add("PRODUCT_AGGREGATE_DUTY_NOTN");
        dsXML.Tables[1].Columns.Add("PRODUCT_AGGREGATE_DUTY_NOTN_SL");
        dsXML.Tables[1].Columns.Add("PRODUCT_AGGREGATE_DUTY_NOTN_RATE");
        dsXML.Tables[1].Columns.Add("PRODUCT_SAFEGUARD_NOTN");
        dsXML.Tables[1].Columns.Add("PRODUCT_SAFEGUARD_SLNO");
        dsXML.Tables[1].Columns.Add("PRODUCT_SAFEGUARD_RATE");
        dsXML.Tables[1].Columns.Add("PRODUCT_SAFEGUARD_SPL");
        dsXML.Tables[1].Columns.Add("PRODUCT_SAFEGUARD_UNIT");
        dsXML.Tables[1].Columns.Add("PRODUCT_SAFEGUARD_SPL_TYPE");
        dsXML.Tables[1].Columns.Add("PRODUCT_SAPTA_NOTN");
        dsXML.Tables[1].Columns.Add("PRODUCT_SAPTA_SLNO");
        dsXML.Tables[1].Columns.Add("PRODUCT_SAPTA_RATE");
        dsXML.Tables[1].Columns.Add("PRODUCT_TARIFF_NOTN");
        dsXML.Tables[1].Columns.Add("PRODUCT_TARIFF_SLNO");
        dsXML.Tables[1].Columns.Add("PRODUCT_TARIFF_QTY");
        dsXML.Tables[1].Columns.Add("PRODUCT_TARIFF_AMOUNT");
        dsXML.Tables[1].Columns.Add("PRODUCT_TARIFF_AMOUNT_UNIT");
        dsXML.Tables[1].Columns.Add("PRODUCT_CETH");
        dsXML.Tables[1].Columns.Add("PRODUCT_MRP_YN");
        dsXML.Tables[1].Columns.Add("PRODUCT_MRP_SL_NO");
        dsXML.Tables[1].Columns.Add("PRODUCT_MRP_AMOUNT");
        dsXML.Tables[1].Columns.Add("PRODUCT_MRP_ABT_RATE");
        dsXML.Tables[1].Columns.Add("PRODUCT_CVD_NOTN");
        dsXML.Tables[1].Columns.Add("PRODUCT_CVD_SLNO");
        dsXML.Tables[1].Columns.Add("PRODUCT_CVD_RATE");
        dsXML.Tables[1].Columns.Add("PRODUCT_CVD_SPL");
        dsXML.Tables[1].Columns.Add("PRODUCT_CVD_UNIT");
        dsXML.Tables[1].Columns.Add("PRODUCT_CVD_SPL_TYPE");
        dsXML.Tables[1].Columns.Add("PRODUCT_CVD_EDU_CESS_RATE");
        dsXML.Tables[1].Columns.Add("PRODUCT_CVD_SEC_EDU_CESS_RATE");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL5_SIA_NOTN");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL5_SIA_NOTN_SL");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL5_SIA_RATE");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_GSI_NOTN");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_GSI_SLNO");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_GSI_RATE");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_GSI_SPL");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_GSI_UNIT");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_GSI_SPL_TYPE");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_SHEII_NOTN");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_SHEII_SLNO");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_SHEII_RATE");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_SHEII_SPL");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_SHEII_UNIT");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_SHEII_TYPE");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_TTA_NOTN");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_TTA_SLNO");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_TTA_RATE");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_TTA_SPL");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_TTA_UNIT");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_TTA_TYPE");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_NOTN");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_SLNO");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_RATE");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_SPL");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_UNIT");
        dsXML.Tables[1].Columns.Add("PRODUCT_ADDL_HEALTH_CESS_TYPE");
        dsXML.Tables[1].Columns.Add("PRODUCT_CESS_NOTN");
        dsXML.Tables[1].Columns.Add("PRODUCT_CESS_SLNO");
        dsXML.Tables[1].Columns.Add("PRODUCT_CESS_RATE");
        dsXML.Tables[1].Columns.Add("PRODUCT_CESS_SPL");
        dsXML.Tables[1].Columns.Add("PRODUCT_CESS_UNIT");
        dsXML.Tables[1].Columns.Add("PRODUCT_CESS_TYPE");
        dsXML.Tables[1].Columns.Add("ANTI_DUMPING_NOTN");
        dsXML.Tables[1].Columns.Add("ANTI_DUMPING_NOTN_SLNO");
        dsXML.Tables[1].Columns.Add("CTH_SLNO");
        dsXML.Tables[1].Columns.Add("CTH_SUPPLIER_SLNO");
        dsXML.Tables[1].Columns.Add("CTH_QTY");
        dsXML.Tables[1].Columns.Add("RSP_DUTY_STATUS");
        dsXML.Tables[1].Columns.Add("RSP_SL_NO");
        dsXML.Tables[1].Columns.Add("RSP_DESC");
        dsXML.Tables[1].Columns.Add("RSP_QTY");
        dsXML.Tables[1].Columns.Add("RSP_AMOUNT");
        dsXML.Tables[1].Columns.Add("RSP_NOTN_NO");
        dsXML.Tables[1].Columns.Add("RSP_NOTN_SL_NO");
        dsXML.Tables[1].Columns.Add("RSP_ABT_RATE");
        dsXML.Tables[1].Columns.Add("WAREHOUSE_JOBNO");
        dsXML.Tables[1].Columns.Add("WAREHOUSE_INVOICE_SLNO");
        dsXML.Tables[1].Columns.Add("WAREHOUSE_ITEM_SLNO");
        dsXML.Tables[1].Columns.Add("ASSESSABLE_VALUE");
        dsXML.Tables[1].Columns.Add("DUTY_VALUE");
        dsXML.Tables[1].Columns.Add("CIF_VALUE");
        dsXML.Tables[1].Columns.Add("CVD_VALUE");


        dsXML.Tables[1].Columns.Add("USER_ID");
        dsXML.Tables[1].Columns.Add("DATE_TIME");
        dsXML.Tables[1].Columns.Add("STATUS");
        dsXML.Tables[1].Columns.Add("BRANCH_CODE");
        dsXML.Tables[1].Columns.Add("YEAR");
        dsXML.Tables[1].Columns.Add("WORKING_PERIOD");

        //--------------------New Field added on 08Aug2014--------------------------//

        dsXML.Tables[1].Columns.Add("CETH_CVD_EDU_CESS_SL");

        dsXML.Tables[1].Columns.Add("BASIC_VALUE");
        dsXML.Tables[1].Columns.Add("CEC_VALUE");
        dsXML.Tables[1].Columns.Add("CHEC_VALUE");
        dsXML.Tables[1].Columns.Add("ADD_DUTY_VALUE");

        //---------------------End--------------------------------------------------//
        dsXML.Tables[1].Columns.Add("INDEV_RACK_TYPE");

        #endregion

        DataRow dr = dsXML.Tables[0].NewRow();

        if (ds.Tables[0].Rows.Count > a)
        {
            if (file_ext == ".xls" || file_ext == ".xlsx")
            {

                int x = 1;
                int ccc = 0;
                double frt;
                double bb = 0.00;

                #region read Excel_Format

                DataView view = new DataView(ds.Tables[0]);
                DataTable distinctValues = view.ToTable(true, "PART_NO", "DESCRIPTION", "UNITPRICE");
                while (distinctValues.Rows.Count > b)
                {
                    PART_NO = distinctValues.Rows[b][0].ToString();
                    if (PART_NO != "" && PART_NO != "PART NO.")
                    {
                        PART_NO1 += distinctValues.Rows[b][0].ToString() + ',';
                    }
                    b++;
                }

                int sum = 0;
                b = 0;

                int item_sl_no = 1;


                //while (distinctValues.Rows[b][0] != System.DBNull.Value)
                while (distinctValues.Rows.Count > b)
                {

                    PART_NO = distinctValues.Rows[b][0].ToString();


                    /******* FOR CHECKING PART NO AVAILABLE OR NOT IN RSPINPUTNEW TABLE *****************************/
                    if (PART_NO != "" && PART_NO != "PART NO.")
                    {

                        if (b == 0)
                        {
                            if (FORMAT_TYPE == "CHINAPARTS")
                            {
                                //GET_RSP_PartNo();
                                dtPart = (DataTable)ViewState["dt_PartNo"];
                            }

                            dr["INVOICE_ID"] = "";
                            dr["JOBNO"] = IMPORT_JOBNO;
                            dr["INVOICE_NO"] = Invno.TrimEnd();
                            dr["INVOICE_SLNO"] = INVSLNO;
                            string inv_date = Convert.ToDateTime(Invdt).ToShortDateString();

                            string inv_date1 = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(inv_date));
                            dr["INVOICE_DATE"] = Convert.ToDateTime(inv_date).ToString(@"MM/dd/yyyy");

                            dr["TERMS"] = FOB_TERMS;

                            dr["INVOICE_CURRENCY"] = CHINA_INV_CURRENCY;
                            INV_CURRENCY = dr["INVOICE_CURRENCY"].ToString();

                            if (dr["INVOICE_CURRENCY"] != "")
                            {
                                adm.Invoice_Currency = dr["INVOICE_CURRENCY"].ToString(); 

                                adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                adm.EWorking_Period = Working_Period;

                                ds1 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                if (ds1.Tables[0].Rows.Count > 0)
                                {
                                    dr["INVOICE_EXRATE"] = ds1.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                }
                            }
                            else
                            {
                                dr["INVOICE_EXRATE"] = "";
                            }

                            dr["INVOICE_VALUE"] = "";

                            dr["SUPPLIER_NAME"] = SUPPLIER_NAME;
                            dr["SUPPLIER_ADDRESS"] = SUPPLIER_ADDRESS;
                            dr["SUPPLIER_ADDRESS1"] = SUPPLIER_ADDRESS1;
                            dr["SUPPLIER_ADDRESS2"] = SUPPLIER_ADDRESS2;
                            dr["SUPPLIER_COUNTRY_NAME"] = COUNTRYORIGIN;
                            dr["SUPPLIER_COUNTRY_CODE"] = "";
                            dr["SUPPLIER_COUNTRY_PINCODE"] = "";
                            dr["SELLER_NAME"] = "";
                            dr["SELLER_ADDRESS"] = "";
                            dr["SELLER_ADDRESS1"] = "";
                            dr["SELLER_ADDRESS2"] = "";
                            dr["SELLER_COUNTRY_NAME"] = "";
                            dr["SELLER_COUNTRY_CODE"] = "";
                            dr["SELLERCOUNTRY_PINCODE"] = "";
                            dr["BROKER_NAME"] = "";
                            dr["BROKER_ADDRESS"] = "";
                            dr["BROKER_ADDRESS1"] = "";
                            dr["BROKER_ADDRESS2"] = "";
                            dr["BROKER_COUNTRY_NAME"] = "";
                            dr["BROKER_COUNTRY_CODE"] = "";
                            dr["BROKER_COUNTRY_PINCODE"] = "";

                            object MIS_CHARGES;
                            MIS_CHARGES = d.Compute("Sum(MIS_CHARGES)", "INVOICE_NO = '" + Invno + "'");
                            MIS_CHARGES = Convert.ToString(Math.Round(Convert.ToDouble(MIS_CHARGES), 2, MidpointRounding.AwayFromZero).ToString("0.00"));
                            dr["MIS_CHARGES"] = MIS_CHARGES;


                            dr["MIS_RATE"] = "";
                            dr["MIS_CURRENCY"] = INV_CURRENCY;

                            if (dr["INVOICE_CURRENCY"] == dr["MIS_CURRENCY"])
                            {
                                dr["MIS_EXRATE"] = dr["INVOICE_EXRATE"];
                            }
                            else
                            {
                                if (dr["MIS_CURRENCY"] != "")
                                {
                                    adm.Invoice_Currency = dr["MIS_CURRENCY"].ToString(); ;

                                    adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                    adm.EWorking_Period = Working_Period;

                                    ds2 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                    if (ds2.Tables[0].Rows.Count > 0)
                                    {
                                        dr["MIS_EXRATE"] = ds2.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                    }
                                }
                                else
                                {
                                    dr["MIS_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                    dr["MIS_EXRATE"] = dr["INVOICE_EXRATE"];
                                }
                            }

                            dr["MIS_AGENCY_CHARGES"] = "";
                            dr["MIS_AGENCY_RATE"] = "0.00";
                            dr["MIS_AGENCY_CURRENCY"] = INV_CURRENCY;
                            dr["MIS_AGENCY_EXRATE"] = dr["INVOICE_EXRATE"];
                            dr["MIS_DISCOUNT_CHARGES"] = "";
                            dr["MIS_DISCOUNT_RATE"] = "0.00";
                            dr["MIS_DISCOUNT_CURRENCY"] = INV_CURRENCY;
                            dr["MIS_DISCOUNT_EXRATE"] = dr["INVOICE_EXRATE"];
                            dr["MIS_DISCOUNT_REASON"] = "";
                            dr["MIS_LOADING_CHARGES"] = "";
                            dr["MIS_LOADING_RATE"] = "";
                            dr["MIS_LOADING_CURRENCY"] = "";
                            dr["MIS_LOADING_EXRATE"] = "";

                            dr["MIS_HIGHSEASALE_CHARGES"] = "";
                            dr["MIS_HIGHSEASALE_RATE"] = "0.00";
                            dr["MIS_HIGHSEASALE_CURRENCY"] = "INR";
                            dr["MIS_HIGHSEASALE_EXRATE"] = "1.00";
                            dr["MIS_SINGLE_OR_MULITIPLE"] = "S";
                            dr["SVB_RELATION"] = "N";
                            dr["SVB_REF_NO"] = "";

                            string SVB_REF_DATE = "01/01/1900";
                            dr["SVB_REF_DATE"] = DateTime.Parse(SVB_REF_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                            dr["SVB_CUSTOM_HOUSE"] = "";
                            dr["SVB_LOADING_ON"] = "";
                            dr["SVB_ASSESABLE_RATE"] = "";
                            dr["SVB_DUTY_RATE"] = "";
                            dr["SVB_ASSESABLE_STATUS"] = "";
                            dr["SVB_DUTY_STATUS"] = "";
                            dr["OTHER_PURCHASE_ORDER"] = "";

                            string PURCHASE_ORDER_DATE = "01/01/1900";

                            dr["OTHER_PURCHASE_ORDER_DATE"] = DateTime.Parse(PURCHASE_ORDER_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                            dr["OTHER_CONTRACT_NO"] = "";

                            string CONTRACT_DATE = "01/01/1900";

                            dr["OTHER_CONTRACT_DATE"] = DateTime.Parse(CONTRACT_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                            dr["OTHER_LOC_NO"] = "";
                            dr["OTHER_NATURE_OF_TRANSACTION"] = "S  Sale";
                            dr["OTHER_TERMS_OF_PAYMENT"] = "OTH  Others";
                            dr["OTHER_CONDITIONS"] = "";
                            dr["OTHER_VALUATION_METHOD"] = "Rule 4 - Transaction Value";

                            string ship = "01/01/1900";
                            dr["SAP_DELIEVERY_ID"] = "";
                            dr["SHIP_DATE"] = DateTime.Parse(ship, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                            dr["INVOICE_LEVEL"] = "";
                            dr["COUNTRY_OF_DEPARTURE"] = "";

                            string DATE = "01/01/1900";

                            dr["NON_STD_EFFECT_DT_IMP"] = DateTime.Parse(DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                            dr["NON_STD_BANKNAME"] = "";
                            dr["NON_STD_CERTIFICATE_NO"] = "";
                            dr["NON_STD_CERTIFICATE_DATE"] = DateTime.Parse(DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                            dr["USER_ID"] = currentuser;
                            dr["DATE_TIME"] = "";
                            dr["STATUS"] = "S";
                            dr["BRANCH_CODE"] = currentbranch;
                            dr["YEAR"] = "";
                            dr["WORKING_PERIOD"] = Working_Period;

                            dt = dsXML.Tables[0];

                            /////////////////////////////////////////////////////////////

                            //#region Invoice Terms Calculation
                            //sumObject = d.Compute("Sum(MIS_FREIGHT_CHARGES)", "INVOICE_NO = '" + Invno + "'");
                            //sumObject = Convert.ToString(Math.Round(Convert.ToDouble(sumObject), 2, MidpointRounding.AwayFromZero).ToString("0.00"));
                            //dr["MIS_FREIGHT_CHARGES"] = sumObject;

                            //object INSURANCE_CHARGES;
                            //INSURANCE_CHARGES = d.Compute("Sum(MIS_INSURANCE_CHARGES)", "INVOICE_NO = '" + Invno + "'");
                            //INSURANCE_CHARGES = Convert.ToString(Math.Round(Convert.ToDouble(INSURANCE_CHARGES), 2, MidpointRounding.AwayFromZero).ToString("0.00"));
                            //dr["MIS_INSURANCE_CHARGES"] = INSURANCE_CHARGES;

                            //dr["TERMS"] = "FOB";
                            //dr["MIS_FREIGHT_RATE"] = "20.0000";
                            //dr["MIS_FREIGHT_CURRENCY"] = dr["INVOICE_CURRENCY"];
                            //dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];

                            //dr["MIS_INSURANCE_RATE"] = "1.1250";
                            //dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                            //dr["MIS_INSURANCE_CURRENCY"] = dr["INVOICE_CURRENCY"];


                            if (FORMAT_TYPE == "THAILANDPARTS")
                            {

                                dr["TERMS"] = "FOB";
                                dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(frt_val), 2, MidpointRounding.AwayFromZero).ToString("0.00"));
                                dr["MIS_FREIGHT_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                dr["MIS_FREIGHT_RATE"] = "0.00";

                                dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(Ins_val), 2, MidpointRounding.AwayFromZero).ToString("0.00"));
                                dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                dr["MIS_INSURANCE_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                dr["MIS_INSURANCE_RATE"] = "0.00";
                            }
                            else if (FORMAT_TYPE == "CHINAPARTS")
                            {
                                dr["TERMS"] = "FOB";
                                dr["MIS_FREIGHT_RATE"] = "20.0000";
                                dr["MIS_FREIGHT_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];

                                dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(Ins_val), 2, MidpointRounding.AwayFromZero).ToString("0.00"));
                                dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                dr["MIS_INSURANCE_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                dr["MIS_INSURANCE_RATE"] = "0.00";
                            }
                            else
                            {
                                dr["TERMS"] = "FOB";
                                dr["MIS_FREIGHT_RATE"] = "20.0000";
                                dr["MIS_FREIGHT_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];

                                dr["MIS_INSURANCE_RATE"] = "1.1250";
                                dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                dr["MIS_INSURANCE_CURRENCY"] = dr["INVOICE_CURRENCY"];

                            }

                            #region INVOICE_FREIGHT& INSURANCE CALC
                            /*
                            if (dr["MIS_FREIGHT_CHARGES"] == "" || dr["MIS_INSURANCE_CHARGES"] == "")
                            {
                                if (Convert.ToString(dr["TERMS"]) == "FOB")
                                {
                                    if (dr["MIS_FREIGHT_CHARGES"] == "")
                                    {

                                        dr["MIS_FREIGHT_RATE"] = "20.0000";

                                        double invoicevalue_Excel = Convert.ToDouble(dr["INVOICE_VALUE"]);
                                        cal = invoicevalue_Excel * 20 / 100;

                                        //dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(cal);

                                        dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(cal), 2).ToString("0.00"));

                                        dr["MIS_FREIGHT_CURRENCY"] = ds.Tables[0].Rows[a][11].ToString();

                                        if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                                        {
                                            dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                        }
                                        else
                                        {
                                            if (dr["MIS_FREIGHT_CURRENCY"] != "")
                                            {
                                                adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                                                adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                                adm.EWorking_Period = Working_Period;

                                                ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                                if (ds3.Tables[0].Rows.Count > 0)
                                                {
                                                    dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                                }
                                            }
                                            else
                                            {
                                                dr["MIS_FREIGHT_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                                dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //dr["MIS_FREIGHT_CHARGES"] = ds.Tables[0].Rows[a][10].ToString();

                                        dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(ds.Tables[0].Rows[a][10]), 2).ToString("0.00"));

                                        dr["MIS_FREIGHT_RATE"] = "";
                                        dr["MIS_FREIGHT_CURRENCY"] = ds.Tables[0].Rows[a][11].ToString();

                                        if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                                        {
                                            dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                        }
                                        else
                                        {
                                            if (dr["MIS_FREIGHT_CURRENCY"] != "")
                                            {
                                                adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                                                adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                                adm.EWorking_Period = Working_Period;

                                                ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                                if (ds3.Tables[0].Rows.Count > 0)
                                                {
                                                    dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                                }
                                            }
                                            else
                                            {
                                                dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                            }
                                        }
                                    }

                                    if (dr["MIS_INSURANCE_CHARGES"] == "")
                                    {

                                        dr["MIS_INSURANCE_RATE"] = "1.1250";

                                        double invoicevalue_Excel1 = Convert.ToDouble(dr["INVOICE_VALUE"]);
                                        cal1 = invoicevalue_Excel1 * 1.125 / 100;

                                        //dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(cal1);

                                        dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(cal1), 2).ToString("0.00"));

                                        dr["MIS_INSURANCE_CURRENCY"] = ds.Tables[0].Rows[a][13].ToString();

                                        if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                                        {
                                            dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                        }
                                        else
                                        {

                                            if (dr["MIS_INSURANCE_CURRENCY"] != "")
                                            {
                                                adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                                                adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                                adm.EWorking_Period = Working_Period;

                                                ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                                if (ds4.Tables[0].Rows.Count > 0)
                                                {
                                                    dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                                }

                                            }
                                            else
                                            {
                                                dr["MIS_INSURANCE_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                                dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                            }
                                        }
                                    }
                                    else
                                    {

                                        //dr["MIS_INSURANCE_CHARGES"] = ds.Tables[0].Rows[a][12].ToString();

                                        dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(ds.Tables[0].Rows[a][12]), 2).ToString("0.00"));

                                        dr["MIS_INSURANCE_RATE"] = "";
                                        dr["MIS_INSURANCE_CURRENCY"] = ds.Tables[0].Rows[a][13].ToString();

                                        if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                                        {
                                            dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                        }
                                        else
                                        {

                                            if (dr["MIS_INSURANCE_CURRENCY"] != "")
                                            {
                                                adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                                                adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                                adm.EWorking_Period = Working_Period;

                                                ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                                if (ds4.Tables[0].Rows.Count > 0)
                                                {
                                                    dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                                }

                                            }
                                            else
                                            {
                                                dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                            }
                                        }


                                    }
                                }


                                else if (Convert.ToString(dr["TERMS"]) == "CI")
                                {
                                    if (dr["MIS_FREIGHT_CHARGES"] == "")
                                    {
                                        dr["MIS_FREIGHT_RATE"] = "20.0000";

                                        double invoicevalue_Excel = Convert.ToDouble(dr["INVOICE_VALUE"]);
                                        cal = invoicevalue_Excel * 20 / 100;

                                        //dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(cal);

                                        dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(cal), 2).ToString("0.00"));

                                        dr["MIS_FREIGHT_CURRENCY"] = ds.Tables[0].Rows[a][11].ToString();

                                        if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                                        {
                                            dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                        }
                                        else
                                        {

                                            if (dr["MIS_FREIGHT_CURRENCY"] != "")
                                            {
                                                adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                                                adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                                adm.EWorking_Period = Working_Period;

                                                ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                                if (ds3.Tables[0].Rows.Count > 0)
                                                {
                                                    dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                                }

                                            }
                                            else
                                            {
                                                dr["MIS_FREIGHT_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                                dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                            }
                                        }
                                    }

                                    else
                                    {
                                        //dr["MIS_FREIGHT_CHARGES"] = ds.Tables[0].Rows[a][10].ToString();

                                        dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(ds.Tables[0].Rows[a][10]), 2).ToString("0.00"));

                                        dr["MIS_FREIGHT_RATE"] = "";
                                        dr["MIS_FREIGHT_CURRENCY"] = ds.Tables[0].Rows[a][11].ToString();

                                        if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                                        {
                                            dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                        }
                                        else
                                        {
                                            if (dr["MIS_FREIGHT_CURRENCY"] != "")
                                            {
                                                adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                                                adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                                adm.EWorking_Period = Working_Period;

                                                ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                                if (ds3.Tables[0].Rows.Count > 0)
                                                {
                                                    dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                                }

                                            }
                                            else
                                            {
                                                dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                            }
                                        }
                                    }

                                }
                                else if (Convert.ToString(dr["TERMS"]) == "CF")
                                {
                                    if (dr["MIS_INSURANCE_CHARGES"] == "")
                                    {
                                        dr["MIS_INSURANCE_RATE"] = "1.1250";

                                        double invoicevalue_Excel1 = Convert.ToDouble(dr["INVOICE_VALUE"]);
                                        cal1 = invoicevalue_Excel1 * 1.125 / 100;

                                        //dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(cal1);

                                        dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(cal1), 2).ToString("0.00"));

                                        dr["MIS_INSURANCE_CURRENCY"] = ds.Tables[0].Rows[a][13].ToString();

                                        if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                                        {
                                            dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                        }
                                        else
                                        {

                                            if (dr["MIS_INSURANCE_CURRENCY"] != "")
                                            {
                                                adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                                                adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                                adm.EWorking_Period = Working_Period;

                                                ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                                if (ds4.Tables[0].Rows.Count > 0)
                                                {
                                                    dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                                }

                                            }
                                            else
                                            {
                                                dr["MIS_INSURANCE_CURRENCY"] = dr["INVOICE_CURRENCY"];
                                                dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                            }
                                        }
                                    }

                                    else
                                    {

                                        //dr["MIS_INSURANCE_CHARGES"] = ds.Tables[0].Rows[a][12].ToString();

                                        dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(ds.Tables[0].Rows[a][12]), 2).ToString("0.00"));


                                        dr["MIS_INSURANCE_RATE"] = "";
                                        dr["MIS_INSURANCE_CURRENCY"] = ds.Tables[0].Rows[a][13].ToString();

                                        if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                                        {
                                            dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                        }
                                        else
                                        {
                                            if (dr["MIS_INSURANCE_CURRENCY"] != "")
                                            {
                                                adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                                                adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                                adm.EWorking_Period = Working_Period;

                                                ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                                if (ds4.Tables[0].Rows.Count > 0)
                                                {
                                                    dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                                }
                                            }
                                            else
                                            {
                                                dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                            }
                                        }
                                    }
                                }
                                else if (Convert.ToString(dr["TERMS"]) == "CIF")
                                {

                                }
                            }

                            else
                            {

                                dr["MIS_FREIGHT_CHARGES"] = sumObject;
                                dr["MIS_FREIGHT_RATE"] = "";
                                dr["MIS_FREIGHT_CURRENCY"] = "";

                                if (dr["INVOICE_CURRENCY"] == dr["MIS_FREIGHT_CURRENCY"])
                                {
                                    dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                }
                                else
                                {

                                    if (dr["MIS_FREIGHT_CURRENCY"] != "")
                                    {
                                        adm.Invoice_Currency = dr["MIS_FREIGHT_CURRENCY"].ToString(); ;

                                        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                        adm.EWorking_Period = Working_Period;

                                        ds3 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                        if (ds3.Tables[0].Rows.Count > 0)
                                        {
                                            dr["MIS_FREIGHT_EXRATE"] = ds3.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                        }

                                    }
                                    else
                                    {
                                        dr["MIS_FREIGHT_EXRATE"] = dr["INVOICE_EXRATE"];
                                    }
                                }


                                //dr["MIS_INSURANCE_CHARGES"] = ds.Tables[0].Rows[a][11].ToString();
                                dr["MIS_INSURANCE_CHARGES"] = INSURANCE_CHARGES;
                                dr["MIS_INSURANCE_RATE"] = "";
                                dr["MIS_INSURANCE_CURRENCY"] = "";

                                if (dr["INVOICE_CURRENCY"] == dr["MIS_INSURANCE_CURRENCY"])
                                {
                                    dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                }
                                else
                                {

                                    if (dr["MIS_INSURANCE_CURRENCY"] != "")
                                    {
                                        adm.Invoice_Currency = dr["MIS_INSURANCE_CURRENCY"].ToString(); ;

                                        adm.Ename = "IMPORT_INVOICE_EX_RATE";
                                        adm.EWorking_Period = Working_Period;

                                        ds4 = adm.RetrieveAll_Exchange_master_INV_Currency_ExcelUpload();

                                        if (ds4.Tables[0].Rows.Count > 0)
                                        {
                                            dr["MIS_INSURANCE_EXRATE"] = ds4.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();

                                        }

                                    }
                                    else
                                    {
                                        dr["MIS_INSURANCE_EXRATE"] = dr["INVOICE_EXRATE"];
                                    }
                                }


                            }

                            */

                            #endregion

                        }

                        #region Item Details

                        var results = from myRow in ds.Tables[0].AsEnumerable()
                                      where myRow.Field<string>("PART_NO") == PART_NO
                                      select myRow;


                        DataView dvv1 = results.AsDataView();
                        DataTable dtt = dvv1.ToTable();
                        DataSet dst = new DataSet();
                        dst.Tables.Add(dtt);

                        //************************** SUM BY BALAJI *********************************
                        //var Values = from row in dst.Tables[0].AsEnumerable()
                        //             //group row by row.Field<string>("INVOICE_NO") into g
                        //             //group row by dd into g
                        //             group row by new { id = row.Field<string>("PART_NO") } into g
                        //             select new
                        //             {
                        //                 name_1 = g.Key.id,
                        //                 name_2 = g.Sum(r => (Convert.ToDouble(r.Field<object>("QTY")) * Convert.ToDouble(r.Field<object>("UNITPRICE"))))

                        //             };

                        //************************************************************************

                        var Values = from row in dst.Tables[0].AsEnumerable()
                                     //group row by row.Field<string>("INVOICE_NO") into g
                                     //group row by dd into g
                                     group row by new { id = row.Field<string>("PART_NO") } into g
                                     select new
                                     {
                                         name_1 = g.Key.id,
                                         name_2 = g.Sum(r => (Convert.ToDouble(r.Field<object>("QTY"))))

                                     };

                        DataRow dr1 = dsXML.Tables[1].NewRow();
                    
                        dr1["ITEM_ID"] = "";
                        dr1["JOBNO"] = IMPORT_JOBNO;

                        dr1["INVOICE_SLNO"] = INVSLNO;
                        dr1["INVOICE_NO"] = Invno.TrimEnd();
                        dr1["ITEM_SLNO"] = item_sl_no;

                        string item_product_desc = "";

                        string PARTNO = "";

                        DataRow[] rows;
                        rows = ds_China.Tables[0].Select("PART_NO = '" + PART_NO + "'");  //'DESCRIPTION' is ColumnName
                        //foreach (DataRow row in rows)
                        //{
                        //    item_product_desc = row["DESCRIPTION"].ToString();

                        //}

                        foreach (DataRow row in rows)
                        {
                            PARTNO = row["PART_NO"].ToString();
                        }

                        dt_All = Get_Product_Details_All(PARTNO);
                      
                            
                            if (FORMAT_TYPE == "THAILANDPARTS" || FORMAT_TYPE == "THAILANDRACK")
                            {
                                Thailand_Notn_SlNo = "";
                                //Select Only Particular Notns .....
                                if (Thailand_Notn != "")
                                {

                                    var FullName1 = from DataRow drr in dt_All.Tables[0].AsEnumerable()
                                                    where drr.Field<string>("PRODUCT_BCD_NOTN").Trim() == Thailand_Notn
                                                    select drr;

                                    int empty_count = FullName1.Count();

                                    if (empty_count > 0)
                                    {
                                        final_dt = FullName1.CopyToDataTable();
                                    }

                                    if (Thailand_Notn != "" && empty_count > 0 && Thailand_Notn == final_dt.Rows[0]["PRODUCT_BCD_NOTN"].ToString())
                                    {
                                        //Delete Unmatchabel Rows from dataset
                                        var query = dt_All.Tables[0].AsEnumerable().Where(r => r.Field<string>("PRODUCT_BCD_NOTN") != Thailand_Notn);
                                        foreach (var row in query.ToList())
                                            dt_All.Tables[0].Rows.Remove(row);
                                        Thailand_Notn_SlNo = dt_All.Tables[0].Rows[0]["PRODUCT_BCD_SLNO"].ToString();
                                    }
                                }
                            }

                          if (FORMAT_TYPE == "FRANCEPARTS" || FORMAT_TYPE == "THAILANDPARTS" || FORMAT_TYPE == "CHINAPARTS")
                          {
                            if (dst.Tables[0].Rows.Count > 0)
                            {
                                dr1["ITEM_DESCRIPTION"] = PART_NO + " " + dst.Tables[0].Rows[0]["DESCRIPTION"].ToString() + " " + "(ACTUAL USER)";

                            }
                            else
                            {
                                dr1["ITEM_DESCRIPTION"] = PART_NO + " " + dt_All.Tables[0].Rows[0]["PRODUCT_DESCRIPTION"].ToString() + " " + "(ACTUAL USER)";
                            }

                            dr1["PRODUCT_RITC"] = dt_All.Tables[0].Rows[0]["PRODUCT_RITC"].ToString();
                            dr1["PRODUCT_CTH"] = dt_All.Tables[0].Rows[0]["PRODUCT_CTH"].ToString();
                            dr1["PRODUCT_CETH"] = dt_All.Tables[0].Rows[0]["PRODUCT_CETH"].ToString();
                            //dr1["CTH_NO"] = dt_All.Tables[0].Rows[0]["CTH_NO"].ToString();
                            dr1["CTH_NO"] = dt_All.Tables[0].Rows[0]["PRODUCT_CTH"].ToString();


                            dr1["PRODUCT_BCD_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_BCD_SLNO"].ToString();
                            dr1["PRODUCT_BCD_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_BCD_RATE"].ToString();
                            dr1["PRODUCT_BCD_SPL"] = dt_All.Tables[0].Rows[0]["PRODUCT_BCD_SPL"].ToString();
                            dr1["PRODUCT_BCD_UNIT"] = dt_All.Tables[0].Rows[0]["PRODUCT_BCD_UNIT"].ToString();
                            dr1["PRODUCT_BCD_SPL_TYPE"] = dt_All.Tables[0].Rows[0]["PRODUCT_BCD_SPL_TYPE"].ToString();

                            dr1["PRODUCT_ADDL_DUTY_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_DUTY_NOTN"].ToString();
                            dr1["PRODUCT_ADDL_DUTY_NOTN_SL"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_DUTY_NOTN_SL"].ToString();

                            dr1["PRODUCT_CVD_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_CVD_NOTN"].ToString();
                            dr1["PRODUCT_CVD_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_CVD_SLNO"].ToString();
                            dr1["PRODUCT_CVD_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_CVD_RATE"].ToString();
                            dr1["PRODUCT_CVD_SPL"] = dt_All.Tables[0].Rows[0]["PRODUCT_CVD_SPL"].ToString();
                            dr1["PRODUCT_CVD_UNIT"] = dt_All.Tables[0].Rows[0]["PRODUCT_CVD_UNIT"].ToString();
                        }

                        else if (FORMAT_TYPE == "CHINARACK" )
                        {
                            if (dst.Tables[0].Rows.Count > 0)
                            {
                                if (PART_NO == "RC1" || PART_NO == "RC2" || PART_NO == "RC3" || PART_NO == "RC4" || PART_NO == "RD1" || PART_NO == "RPX" || PART_NO == "RR6")
                                {
                                    dr1["ITEM_DESCRIPTION"] = "RETURNABLE PALLET"+ " "+ PART_NO;
                                    dr1["PRODUCT_RITC"] = "39231090";
                                    dr1["PRODUCT_CTH"] = "39231090";
                                    dr1["PRODUCT_CETH"] = "39231090";
                                    dr1["CTH_NO"] = "39231090";

                                }
                                else
                                {
                                    dr1["ITEM_DESCRIPTION"] = "RETURNABLE PALLET" + " " + PART_NO;
                                    dr1["PRODUCT_RITC"] = "73269099";
                                    dr1["PRODUCT_CTH"] = "73269099";
                                    dr1["PRODUCT_CETH"] = "73269099";
                                    dr1["CTH_NO"] = "73269099";

                                }
                            }
                            dr1["PRODUCT_BCD_NOTN"] = "104/94";
                            dr1["PRODUCT_BCD_SLNO"] = "";
                            dr1["PRODUCT_ADDL_DUTY_NOTN"] = "021/2012";
                            dr1["PRODUCT_ADDL_DUTY_NOTN_SL"] = "1";

                          
                            dr1["PRODUCT_BCD_SPL"]  = "";
                            dr1["PRODUCT_BCD_UNIT"] = "";
                            dr1["PRODUCT_BCD_SPL_TYPE"] = "";

                            dr1["PRODUCT_CVD_NOTN"] = "";
                            dr1["PRODUCT_CVD_SLNO"] = "";
                            dr1["PRODUCT_CVD_RATE"] = "";
                            dr1["PRODUCT_CVD_SPL"] = "";
                            dr1["PRODUCT_CVD_UNIT"] = "";

                            dr1["INDEV_RACK_TYPE"] = PART_NO;
                            
                        }

                        else if (FORMAT_TYPE == "THAILANDRACK")
                        {
                            if (dst.Tables[0].Rows.Count > 0)
                            {
                                if (PART_NO == "RC1" || PART_NO == "RC2" || PART_NO == "RC3" || PART_NO == "RC4" || PART_NO == "RD1" || PART_NO == "RPX" || PART_NO == "RR6")
                                {
                                    dr1["ITEM_DESCRIPTION"] = "RETURNABLE DUNNAGE NISSAN" + " " + PART_NO;
                                    dr1["PRODUCT_RITC"] = "39231090";
                                    dr1["PRODUCT_CTH"] = "39231090";
                                    dr1["PRODUCT_CETH"] = "39231090";
                                    dr1["CTH_NO"] = "39231090";

                                }
                                else
                                {
                                    dr1["ITEM_DESCRIPTION"] = "RETURNABLE STEEL PALLETS NISSAN" + " " + PART_NO;
                                    dr1["PRODUCT_RITC"] = "73269099";
                                    dr1["PRODUCT_CTH"] = "73269099";
                                    dr1["PRODUCT_CETH"] = "73269099";
                                    dr1["CTH_NO"] = "73269099";
                                }
                            }
                            else
                            {
                                dr1["ITEM_DESCRIPTION"] = dt_All.Tables[0].Rows[0]["PRODUCT_DESCRIPTION"].ToString() + PART_NO;
                            }

                            dr1["PRODUCT_BCD_NOTN"] = "104/94";
                            dr1["PRODUCT_BCD_SLNO"] = "";
                            dr1["PRODUCT_BCD_SPL"] = "";
                            dr1["PRODUCT_BCD_UNIT"] = "";
                            dr1["PRODUCT_BCD_SPL_TYPE"] = "";

                            dr1["PRODUCT_ADDL_DUTY_NOTN"] = "021/2012";
                            dr1["PRODUCT_ADDL_DUTY_NOTN_SL"] = "1";

                            dr1["PRODUCT_CVD_NOTN"] = "";
                            dr1["PRODUCT_CVD_SLNO"] = "";
                            dr1["PRODUCT_CVD_RATE"] = "";
                            dr1["PRODUCT_CVD_SPL"] = "";
                            dr1["PRODUCT_CVD_UNIT"] = "";
                            dr1["INDEV_RACK_TYPE"] = PART_NO;
                        }

                        else
                        {
                            if (dt_All.Tables[0].Rows.Count > 0)
                            {
                                dr1["ITEM_DESCRIPTION"] = dt_All.Tables[0].Rows[0]["PRODUCT_DESCRIPTION"].ToString() + " " + ds.Tables[0].Rows[b][8].ToString() + " " + "(ACTUAL USER)";
                            }
                        }

                        var ITEM_QTY = from row in dst.Tables[0].AsEnumerable()
                                       //group row by row.Field<string>("INVOICE_NO") into g
                                       //group row by dd into g
                                       group row by new { id = row.Field<string>("PART_NO") } into g
                                       select new
                                       {
                                           name_1 = g.Key.id,
                                           name_2 = g.Sum(r => (Convert.ToDouble(r.Field<object>("QTY"))))

                                       };

                        foreach (var drval in ITEM_QTY)
                        {

                            dr1["ITEM_QTY"] = Convert.ToString(drval.name_2);

                        }
                        double ITEM_QTY1 = Convert.ToDouble(dr1["ITEM_QTY"]);

                        if (FORMAT_TYPE == "FRANCEPARTS")
                        {
                            //unit = (drval.name_2 / 2);
                            dr1["ITEM_UNIT_PRICE"] = Convert.ToDouble(dst.Tables[0].Rows[0]["UNITPRICE"].ToString()) / 100;
                            double div_unitPrice=Convert.ToDouble(dst.Tables[0].Rows[0]["UNITPRICE"].ToString())/100;
                            double Calc_UnitPrice = ITEM_QTY1 * div_unitPrice;
                            dr1["ITEM_TOTAL_AMOUNT"] = Convert.ToString(Calc_UnitPrice);                         
                        }
                        else
                        {
                            dr1["ITEM_UNIT_PRICE"] = Convert.ToDouble(dst.Tables[0].Rows[0]["UNITPRICE"].ToString());
                            double Calc_UnitPrice = ITEM_QTY1 * Convert.ToDouble(dst.Tables[0].Rows[0]["UNITPRICE"].ToString());
                            dr1["ITEM_TOTAL_AMOUNT"] = Convert.ToString(Calc_UnitPrice);                          
                        }

                        dr1["ITEM_QTY_CODE"] = ITEM_QTYCODE;

                        dr1["ITEM_UNIT_CODE"] = ITEM_UNITCODE;
                        dr1["ITEM_AMOUNT_CODE"] = "USD";

                        scheme = "00";

                        if (scheme != "" && scheme != "00" && scheme != "0")
                        {
                            if (Convert.ToInt32(scheme) <= 9)
                            {
                                scheme = "0" + scheme;
                            }
                            scheme = Get_Scheme_Code(scheme);
                            dr1["SCHEME_CODE"] = scheme;
                            //dr1["SCHEME_NOTN"] = ds.Tables[0].Rows[b][36].ToString();
                            //dr1["SCHEME_NOTN_SLNO"] = ds.Tables[0].Rows[b][37].ToString();
                        }
                        else
                        {
                            dr1["SCHEME_CODE"] = "00 - DUTIABLE";
                            dr1["SCHEME_NOTN"] = "";
                            dr1["SCHEME_NOTN_SLNO"] = "";
                        }
                        dr1["CTH_QTY1"] = "";
                        dr1["CTH_QTY1_CODE"] = "";
                        dr1["CTH_QTY2"] = "";
                        dr1["CTH_QTY2_CODE"] = "";

                        if (dt_All.Tables[0].Rows[0]["PRODUCT_GENERAL_DESC"].ToString() != "")
                        {
                            dr1["GENEARL_DESCRIPTION"] = dt_All.Tables[0].Rows[0]["PRODUCT_GENERAL_DESC"].ToString();
                        }
                        else
                        {
                            dr1["GENEARL_DESCRIPTION"] = "N.A";
                        }

                        if (dt_All.Tables[0].Rows[0]["PRODUCT_MANUFACTURER"].ToString() != "")
                        {
                            dr1["MANUFACTURER"] = dt_All.Tables[0].Rows[0]["PRODUCT_MANUFACTURER"].ToString();
                        }
                        else
                        {
                            dr1["MANUFACTURER"] = "N.A";
                        }

                        if (dt_All.Tables[0].Rows[0]["PRODUCT_BRAND"].ToString() != "")
                        {
                            dr1["BRAND"] = dt_All.Tables[0].Rows[0]["PRODUCT_BRAND"].ToString();
                        }
                        else
                        {
                            dr1["BRAND"] = "N.A";
                        }

                        if (dt_All.Tables[0].Rows[0]["PRODUCT_MODEL"].ToString() != "")
                        {
                            dr1["MODEL"] = dt_All.Tables[0].Rows[0]["PRODUCT_MODEL"].ToString();
                        }
                        else
                        {
                            dr1["MODEL"] ="N.A";
                        }

                        if (dt_All.Tables[0].Rows[0]["PRODUCT_END_USE"].ToString() != "")
                        {
                            dr1["END_USE_OF_ITEM"] = dt_All.Tables[0].Rows[0]["PRODUCT_END_USE"].ToString();
                        }
                        else
                        {
                            dr1["END_USE_OF_ITEM"] = "N.A";
                        }

                        dr1["COUNTRY_OF_ORIGIN"] = COUNTRYORIGIN;
                        dr1["ACCESSORIES"] = dt_All.Tables[0].Rows[0]["PRODUCT_ACCESSORIES"].ToString();
                        dr1["PREVIOUS_BE_NO"] = "";

                        string BE_DATE = "01/01/1900";

                        dr1["PREVIOUS_BE_DATE"] = DateTime.Parse(BE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);


                        dr1["UNIT_PRICE"] = "";
                        dr1["UNIT_CODE"] = "";
                        dr1["CUSTOMS_HOUSE"] = "";

                        //dr1["PRODUCT_RITC"] = dt_All.Tables[0].Rows[0]["PRODUCT_RITC"].ToString();
                        //dr1["PRODUCT_CTH"] = dt_All.Tables[0].Rows[0]["PRODUCT_CTH"].ToString();

                        if (FORMAT_TYPE == "THAILANDPARTS")
                        {
                            if (Thailand_Notn != "" && Thailand_Notn_SlNo != "")
                            {
                                dr1["PRODUCT_BCD_NOTN"] = Thailand_Notn;
                                dr1["PRODUCT_BCD_SLNO"] = Thailand_Notn_SlNo;
                            }
                            else
                            {
                                dr1["PRODUCT_BCD_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_BCD_NOTN"].ToString();
                                dr1["PRODUCT_BCD_SLNO"] = "";
                            }

                            //if (Thailand_Notn_SlNo != "")
                            //{
                            //    dr1["PRODUCT_BCD_SLNO"] = Thailand_Notn_SlNo;
                            //}
                            //else
                            //{
                            //    dr1["PRODUCT_BCD_SLNO"] = "";
                            //}
                        }


                        //dr1["PRODUCT_BCD_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_BCD_SLNO"].ToString();
                        //dr1["PRODUCT_BCD_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_BCD_RATE"].ToString();
                        //dr1["PRODUCT_BCD_SPL"] = dt_All.Tables[0].Rows[0]["PRODUCT_BCD_SPL"].ToString();
                        //dr1["PRODUCT_BCD_UNIT"] = dt_All.Tables[0].Rows[0]["PRODUCT_BCD_UNIT"].ToString();
                        //dr1["PRODUCT_BCD_SPL_TYPE"] = dt_All.Tables[0].Rows[0]["PRODUCT_BCD_SPL_TYPE"].ToString();

                        //dr1["PRODUCT_ADDL_DUTY_NOTN"] = "";
                        //dr1["PRODUCT_ADDL_DUTY_NOTN_SL"] = "";
                        //dr1["PRODUCT_ADDL_DUTY_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_BCD_SPL_TYPE"].ToString();

                        dr1["PRODUCT_EDU_CESS_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_EDU_CESS_NOTN"].ToString();
                        dr1["PRODUCT_EDU_CESS_NOTN_SL"] = dt_All.Tables[0].Rows[0]["PRODUCT_EDU_CESS_NOTN_SL"].ToString();
                        dr1["PRODUCT_EDU_CESS_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_EDU_CESS_RATE"].ToString();
                        dr1["PRODUCT_SEC_EDU_CESS_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_SEC_EDU_CESS_NOTN"].ToString();
                        dr1["PRODUCT_SEC_EDU_CESS_NOTN_SL"] = dt_All.Tables[0].Rows[0]["PRODUCT_SEC_EDU_CESS_NOTN_SL"].ToString();
                        dr1["PRODUCT_SEC_EDU_CESS_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_SEC_EDU_CESS_RATE"].ToString();

                        dr1["PRODUCT_NCD_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_NCD_NOTN"].ToString();
                        dr1["PRODUCT_NCD_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_NCD_SLNO"].ToString();
                        dr1["PRODUCT_NCD_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_NCD_RATE"].ToString();
                        dr1["PRODUCT_NCD_SPL"] = dt_All.Tables[0].Rows[0]["PRODUCT_NCD_SPL"].ToString();
                        dr1["PRODUCT_NCD_UNIT"] = dt_All.Tables[0].Rows[0]["PRODUCT_NCD_UNIT"].ToString();
                        dr1["PRODUCT_NCD_SPL_TYPE"] = dt_All.Tables[0].Rows[0]["PRODUCT_NCD_SPL_TYPE"].ToString();

                        dr1["PRODUCT_AGGREGATE_DUTY_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_AGGREGATE_DUTY_NOTN"].ToString();
                        dr1["PRODUCT_AGGREGATE_DUTY_NOTN_SL"] = dt_All.Tables[0].Rows[0]["PRODUCT_AGGREGATE_DUTY_NOTN_SL"].ToString();
                        dr1["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"].ToString();

                        dr1["PRODUCT_SAFEGUARD_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_NOTN"].ToString();
                        dr1["PRODUCT_SAFEGUARD_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_SLNO"].ToString();
                        dr1["PRODUCT_SAFEGUARD_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_RATE"].ToString();
                        dr1["PRODUCT_SAFEGUARD_SPL"] = dt_All.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_SPL"].ToString();
                        dr1["PRODUCT_SAFEGUARD_UNIT"] = dt_All.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_UNIT"].ToString();
                        dr1["PRODUCT_SAFEGUARD_SPL_TYPE"] = dt_All.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_SPL_TYPE"].ToString();
                        //dr1["PRODUCT_SAPTA_NOTN"] = "";
                        //dr1["PRODUCT_SAPTA_SLNO"] = "";

                        dr1["PRODUCT_SAPTA_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_SAPTA_NOTN"].ToString();
                        dr1["PRODUCT_SAPTA_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_SAPTA_SLNO"].ToString();
                        dr1["PRODUCT_SAPTA_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_SAPTA_RATE"].ToString();

                        dr1["PRODUCT_TARIFF_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_TARIFF_NOTN"].ToString();
                        dr1["PRODUCT_TARIFF_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_TARIFF_SLNO"].ToString();
                        dr1["PRODUCT_TARIFF_QTY"] = dt_All.Tables[0].Rows[0]["PRODUCT_TARIFF_QTY"].ToString();
                        dr1["PRODUCT_TARIFF_AMOUNT"] = dt_All.Tables[0].Rows[0]["PRODUCT_TARIFF_AMOUNT"].ToString();
                        dr1["PRODUCT_TARIFF_AMOUNT_UNIT"] = dt_All.Tables[0].Rows[0]["PRODUCT_TARIFF_AMOUNT_UNIT"].ToString();
                        //dr1["PRODUCT_CETH"] = dt_All.Tables[0].Rows[0]["PRODUCT_CETH"].ToString();
                        dr1["RSP_NOTN_NO"] = dt_All.Tables[0].Rows[0]["PRODUCT_RSP_NOTN_NO"].ToString();
                        dr1["RSP_NOTN_SL_NO"] = dt_All.Tables[0].Rows[0]["PRODUCT_RSP_NOTN_SL_NO"].ToString();

                        string PRODUCT_MRP_YN = dt_All.Tables[0].Rows[0]["PRODUCT_MRP_YN"].ToString();
                        string PRODUCT_MRP_ABT_RATE = dt_All.Tables[0].Rows[0]["PRODUCT_MRP_ABT_RATE"].ToString();
                        dr1["PRODUCT_MRP_YN"] = dt_All.Tables[0].Rows[0]["PRODUCT_MRP_YN"].ToString();
                        string str_get_ABT_RATE_RSP;

                        if (PART_NO != "")
                        {
                            if (PRODUCT_MRP_YN == "N")
                            {
                                dr1["PRODUCT_MRP_YN"] = "N";
                                dr1["PRODUCT_MRP_AMOUNT"] = "";
                                dr1["PRODUCT_MRP_ABT_RATE"] = "";

                                dr1["RSP_NOTN_NO"] = "";
                                dr1["RSP_NOTN_SL_NO"] = "";
                            }
                            else
                            {
                                if (PRODUCT_MRP_ABT_RATE != "")
                                {
                                    dr1["PRODUCT_MRP_ABT_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_MRP_ABT_RATE"].ToString();
                                }
                                else
                                {
                                    get_ABT_RATE_RSP(dr1["PRODUCT_RITC"].ToString(), dr1["RSP_NOTN_NO"].ToString(), dr1["RSP_NOTN_SL_NO"].ToString());
                                    str_get_ABT_RATE_RSP = ViewState["get_ABT_RATE_RSP"].ToString();

                                    if (str_get_ABT_RATE_RSP != "")
                                    {
                                        dr1["PRODUCT_MRP_YN"] = "Y";
                                        dr1["PRODUCT_MRP_SL_NO"] = "1";
                                        dr1["PRODUCT_MRP_ABT_RATE"] = str_get_ABT_RATE_RSP;

                                    }
                                    else
                                    {
                                        dr1["PRODUCT_MRP_YN"] = "N";
                                        dr1["PRODUCT_MRP_SL_NO"] = "";
                                        dr1["PRODUCT_MRP_ABT_RATE"] = str_get_ABT_RATE_RSP;
                                    }
                                }
                            }
                        }

                        //dr1["PRODUCT_CVD_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_CVD_NOTN"].ToString();
                        //dr1["PRODUCT_CVD_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_CVD_SLNO"].ToString();
                        //dr1["PRODUCT_CVD_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_CVD_RATE"].ToString();
                        //dr1["PRODUCT_CVD_SPL"] = dt_All.Tables[0].Rows[0]["PRODUCT_CVD_SPL"].ToString();
                        //dr1["PRODUCT_CVD_UNIT"] = dt_All.Tables[0].Rows[0]["PRODUCT_CVD_UNIT"].ToString();
                        dr1["PRODUCT_CVD_SPL_TYPE"] = dt_All.Tables[0].Rows[0]["PRODUCT_CVD_SPL_TYPE"].ToString();
                        dr1["PRODUCT_CVD_EDU_CESS_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_CVD_EDU_CESS_RATE"].ToString();
                        dr1["CETH_CVD_EDU_CESS_SL"] = dt_All.Tables[0].Rows[0]["PRODUCT_CVD_SEC_EDU_CESS_RATE"].ToString();

                        //dr1["PRODUCT_ADDL_DUTY_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_DUTY_NOTN"].ToString();
                        //dr1["PRODUCT_ADDL_DUTY_NOTN_SL"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_DUTY_NOTN_SL"].ToString();
                        dr1["PRODUCT_ADDL_GSI_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_NOTN"].ToString();
                        dr1["PRODUCT_ADDL_GSI_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_SLNO"].ToString();

                        dr1["PRODUCT_ADDL_TTA_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_NOTN"].ToString();
                        dr1["PRODUCT_ADDL5_SIA_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL5_SIA_NOTN"].ToString();
                        dr1["PRODUCT_ADDL5_SIA_NOTN_SL"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL5_SIA_NOTN_SL"].ToString();
                        dr1["PRODUCT_ADDL5_SIA_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL5_SIA_RATE"].ToString();

                        dr1["PRODUCT_ADDL_GSI_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_SLNO"].ToString();
                        dr1["PRODUCT_ADDL_GSI_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_RATE"].ToString();
                        dr1["PRODUCT_ADDL_GSI_SPL"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_SPL"].ToString();
                        dr1["PRODUCT_ADDL_GSI_UNIT"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_UNIT"].ToString();
                        dr1["PRODUCT_ADDL_GSI_SPL_TYPE"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_SPL_TYPE"].ToString();

                        dr1["PRODUCT_ADDL_SHEII_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_NOTN"].ToString();
                        dr1["PRODUCT_ADDL_SHEII_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_SLNO"].ToString();
                        dr1["PRODUCT_ADDL_SHEII_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_RATE"].ToString();
                        dr1["PRODUCT_ADDL_SHEII_SPL"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_SPL"].ToString();
                        dr1["PRODUCT_ADDL_SHEII_UNIT"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_UNIT"].ToString();
                        dr1["PRODUCT_ADDL_SHEII_TYPE"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_TYPE"].ToString();

                        dr1["PRODUCT_ADDL_TTA_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_SLNO"].ToString();
                        dr1["PRODUCT_ADDL_TTA_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_RATE"].ToString();
                        dr1["PRODUCT_ADDL_TTA_SPL"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_SPL"].ToString();
                        dr1["PRODUCT_ADDL_TTA_UNIT"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_UNIT"].ToString();
                        dr1["PRODUCT_ADDL_TTA_TYPE"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_TYPE"].ToString();

                        dr1["PRODUCT_ADDL_HEALTH_CESS_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_NOTN"].ToString();
                        dr1["PRODUCT_ADDL_HEALTH_CESS_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_SLNO"].ToString();
                        dr1["PRODUCT_ADDL_HEALTH_CESS_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_RATE"].ToString();
                        dr1["PRODUCT_ADDL_HEALTH_CESS_SPL"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_SPL"].ToString();
                        dr1["PRODUCT_ADDL_HEALTH_CESS_UNIT"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_UNIT"].ToString();
                        dr1["PRODUCT_ADDL_HEALTH_CESS_TYPE"] = dt_All.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_TYPE"].ToString();

                        dr1["PRODUCT_CESS_NOTN"] = dt_All.Tables[0].Rows[0]["PRODUCT_CESS_NOTN"].ToString();
                        dr1["PRODUCT_CESS_SLNO"] = dt_All.Tables[0].Rows[0]["PRODUCT_CESS_SLNO"].ToString();
                        dr1["PRODUCT_CESS_RATE"] = dt_All.Tables[0].Rows[0]["PRODUCT_CESS_RATE"].ToString();
                        dr1["PRODUCT_CESS_SPL"] = dt_All.Tables[0].Rows[0]["PRODUCT_CESS_SPL"].ToString();
                        dr1["PRODUCT_CESS_UNIT"] = dt_All.Tables[0].Rows[0]["PRODUCT_CESS_UNIT"].ToString();
                        dr1["PRODUCT_CESS_TYPE"] = dt_All.Tables[0].Rows[0]["PRODUCT_CESS_TYPE"].ToString();

                        dr1["ANTI_DUMPING_NOTN"] = "";
                        dr1["ANTI_DUMPING_NOTN_SLNO"] = "";
                        dr1["CTH_SLNO"] = "";
                        dr1["CTH_SUPPLIER_SLNO"] = "";
                        dr1["CTH_QTY"] = "";
                        dr1["RSP_DUTY_STATUS"] = "";
                        dr1["RSP_SL_NO"] = "";
                        dr1["RSP_DESC"] = "";
                        dr1["RSP_QTY"] = "";
                        dr1["RSP_AMOUNT"] = "";
                        //dr1["RSP_NOTN_NO"] = "";
                        //dr1["RSP_NOTN_SL_NO"] = "";
                        dr1["RSP_ABT_RATE"] = "";
                        dr1["WAREHOUSE_JOBNO"] = "0";
                        dr1["WAREHOUSE_INVOICE_SLNO"] = "0";
                        dr1["WAREHOUSE_ITEM_SLNO"] = "0";
                        dr1["ASSESSABLE_VALUE"] = "";

                        dr1["DUTY_VALUE"] = "";
                        dr1["CIF_VALUE"] = "";
                        dr1["CVD_VALUE"] = "";

                        dr1["USER_ID"] = currentuser;
                        dr1["DATE_TIME"] = "";
                        dr1["STATUS"] = "N";
                        dr1["BRANCH_CODE"] = currentbranch;

                        dr1["YEAR"] = "";
                        dr1["WORKING_PERIOD"] = Working_Period;

                        dr1["BASIC_VALUE"] = "";
                        dr1["CEC_VALUE"] = "";
                        dr1["CHEC_VALUE"] = "";
                        dr1["ADD_DUTY_VALUE"] = "";

                        dsXML.Tables[1].Rows.Add(dr1);


                        #endregion

                    }


                    item_sl_no++;
                    b++;
                }


                #endregion


                #region Inserting
                dt = dsXML.Tables["ItemDetails"];

                string dd = Invno;
                double Invval = 0;
                var ItemValues = from row in dsXML.Tables["ItemDetails"].AsEnumerable()
                                 //group row by row.Field<string>("INVOICE_NO") into g
                                 //group row by dd into g
                                 group row by new { id = row.Field<string>("INVOICE_NO") } into g
                                 select new
                                 {
                                     name_1 = g.Key.id,

                                     name_2 = g.Sum(r => r.Field<double>("ITEM_TOTAL_AMOUNT"))

                                 };

                foreach (var drval in ItemValues)
                {
                    //if (drval.name_1 == dd)
                    //{
                    Invval = drval.name_2;
                    //}
                }

                var final_inv_val = Invval.ToString();
                final_inv_val = Convert.ToString(Math.Round(Convert.ToDouble(final_inv_val), 2).ToString("0.00"));
                dr["INVOICE_VALUE"] = final_inv_val;

                if (FORMAT_TYPE == "CHINAPARTS")
                {
                    //**************** TO CALCULATE FREIGHT VALUE **************************************

                    double invoicevalue_Excel = Convert.ToDouble(dr["INVOICE_VALUE"]);
                    cal = invoicevalue_Excel * 20 / 100;
                    dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(cal), 2).ToString("0.00"));

                }
                else if (FORMAT_TYPE == "THAILANDPARTS")
                {
                }
                else
                {
                    //**************** TO CALCULATE FREIGHT VALUE **************************************

                    double invoicevalue_Excel = Convert.ToDouble(dr["INVOICE_VALUE"]);
                    cal = invoicevalue_Excel * 20 / 100;
                    dr["MIS_FREIGHT_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(cal), 2).ToString("0.00"));

                    //**************** TO CALCULATE INSURANCE VALUE **************************************

                    double invoicevalue_Excel1 = Convert.ToDouble(dr["INVOICE_VALUE"]);
                    cal1 = invoicevalue_Excel1 * 1.125 / 100;
                    dr["MIS_INSURANCE_CHARGES"] = Convert.ToString(Math.Round(Convert.ToDouble(cal1), 2).ToString("0.00"));

                    //*************************************************************************************
                }

                dsXML.Tables[0].Rows.Add(dr);

                //a++;
                //inv_sl_no++;
                #endregion
                //#endregion
                ///////////////////////////////////////endingggg
            }
        }

    
        dt = dsXML.Tables["InvoiceDetails"];

        string inv_type = string.Empty;

    
        if (ddlInv_Upload.SelectedValue == "China PARTS" || ddlInv_Upload.SelectedValue == "Thailand Parts" || ddlInv_Upload.SelectedValue == "France Parts")
        {
            inv_type = "P";
        }
        else 
        {
            inv_type = "R";
        }
      

        Transact.Bulk_Item_Excel_Upload_GMMCO(RemoveDuplicateRows(dt, "INVOICE_NO"), dsXML.Tables[1], "BULK_ITEM_UPLOAD", inv_type);
    
        if (Transact.result == 1)
        {
            // Response.Redirect(Request.RawUrl);

            Response.Redirect(Request.RawUrl,false);
            Alert_msg("Uploaded Successfully");
        }
        else
        {
            Alert_msg("Excel Upload occured some problem");
        }

        errorlist.Text = "Uploaded Successfully";
    }

    public string get_ABT_RATE_RSP(string ITEM_RITCNO, string RSP_NOTN_NO, string RSP_NOTN_SL_NO)
    {
        adminmaster admin = new adminmaster();
        DataSet dss_Rsp = new DataSet();

        //DataTable dt = (DataTable)ViewState["get_ABT_RATE_RSP"];

        admin.ERSP_id = "";
        admin.ERSP_cthno = ITEM_RITCNO;

        if (RSP_NOTN_NO != "")
        {
            admin.ERSP_Notn = RSP_NOTN_NO;
        }
        else
        {
            admin.ERSP_Notn = "0";
        }

        if (RSP_NOTN_SL_NO != "")
        {
            admin.ERSP_Notn_SlNo = RSP_NOTN_SL_NO;
        }
        else
        {
            admin.ERSP_Notn_SlNo = "0";
        }
        
        admin.ERSP_description = "";
        admin.Ename = "Get_RSP_ABTT_RATE_PRODUCT";

        dss_Rsp = admin.RetrieveAll_RSP_master_PRODUCT_MASTER();

        if (dss_Rsp.Tables[0].Rows.Count > 0)
        {
            ViewState["get_ABT_RATE_RSP"] = dss_Rsp.Tables[0].Rows[0]["RSP_RATE"].ToString();
        }
        else
        {
            ViewState["get_ABT_RATE_RSP"] = "";
        }

        return ITEM_RITCNO;

    }
    public DataSet Get_Product_Details_All(string part_no)
    {
        DataSet ds_prodct = new DataSet();
        FORMAT_TYPE = ViewState["SelectType"].ToString();

        erm.PRODUCT_IMPORT_ID = "";
        erm.Eproduct_imp_description = part_no;
        erm.PRODUCT_CTH = "";
        erm.PRODUCT_CETH = "";
        erm.PRODUCT_RITC = "";

        if (FORMAT_TYPE == "CHINAPARTS" || FORMAT_TYPE == "CHINARACK" || FORMAT_TYPE == "FRANCEPARTS")
        {
            erm.Ename = "Get_Product_Details_All_INDEV";
           
        }
      
        else if (FORMAT_TYPE == "THAILANDPARTS" || FORMAT_TYPE == "THAILANDRACK")
        {
            //erm.Ename = "Get_Product_Details_All_Thailand";
            erm.Ename = "Get_Product_PARTNO_Thailand";
        }
        else
        {
            erm.Ename = "Get_Product_PARTNO_CP";
        }
        erm.EWorking_Period = Working_Period;

        ds_prodct = erm.RetrieveAll_Product_import_MASTER();

        return ds_prodct;

        //ds_comp = ds_China = (DataSet)ViewState["ds_China_upload"];
    }
    
    public string Get_Scheme_Code(string scheme)
    {
        //----------------------SCHEME IMPORT MASTER-------------------------------//

        adm.SCHEME_IMPORT_CODE = scheme;
        adm.SCHEME_NOTN = "0";
        adm.name = "SCHEME_IMPORT_CODE";

        //ddlSchemeCode.DataSource = 
        ds_scheme = adm.RetrieveAll_Scheme_Import();
        if (ds_scheme.Tables[2].Rows.Count > 0)
        {
            scheme = ds_scheme.Tables[2].Rows[0]["SCHEME_CODE"].ToString();
        }

        return scheme;
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

        //ViewState["inv_table"] = null;
        //ViewState["inv_table"] = dTable;

        return dTable;
    }

}
