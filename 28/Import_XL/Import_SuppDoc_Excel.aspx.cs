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
using BussinessObject;
using System.Xml.Schema;
//using Excel;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


public partial class Import_SuppDoc_Excel : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    eroyalmaster erm = new eroyalmaster();
    adminmaster adm = new adminmaster();
    DataTable dt = new DataTable();
    Export_Licence Export_license = new Export_Licence();
    AdminMasterDetails admin = new AdminMasterDetails();
    SW_Support_Docs Sup_Doc = new SW_Support_Docs();
    UserBO ObjUBO = new UserBO();
    DataSet temp = new DataSet();
    DataTable VALID = new DataTable();
    DataTable INVALID = new DataTable();
    DataTable dtest = new DataTable();
    DataTable selected;
    DateTime parsed;
    DataTable distinctDT = new DataTable();

    Transaction Transact = new Transaction();
    Import_XL_Upload Imp_XL = new Import_XL_Upload();


    public int i;
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, IMPORT_JOBNO, SLNO, INVOICE_SLNO, ITEM_SLNO;
    public int Exp_sup_id_Max;
    public string DOC_ISSUING_PARTY_NAME, DOC_ISSUING_PARTY_NAME_ADD1, DOC_ISSUING_PARTY_NAME_ADD2, DOC_ISSUING_PARTY_CITY, DOC_ISSUING_PARTY_PIN;
    string selected_SW;

    DataSet ds = new DataSet();
    DataSet dsssrno = new DataSet();
    DataSet dsXML = new DataSet();
    DataTable dt_Avail = new DataTable();
    DataTable dtt = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet ds_scheme = new DataSet();

    string file_ext = "";
    public string errorFolder = "", logFileName = "", error = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        //currentbranch = "";
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "EXP_SUP_DOC_XL_UPLOAD");


        if (Session["IMPORT_JOBNO"] != null)
        {
            int FileLog = 0;
            IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
            //INVOICE_SLNO = Session["Inv_SL_No"].ToString();
            //ITEM_SLNO = Session["Item_SLNo"].ToString();
            if (!IsPostBack)
            {
                //Dropdown_bind();
                //Bind_ItemSl_No();
                FileLog = 0;
            }
            else
            {
                FileLog = 1;
            }


        }


    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Import Sup Doc Excel Upload', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Import Sup Doc Excel Upload', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Get_Sup_Doc_MaxID()
    {
        ObjUBO.SW_STMT_ID = "";
        ObjUBO.Unique_Document_No = "0";
        ObjUBO.flag = "autoid";
        ObjUBO.WORKING_PERIOD = Working_Period;

        ds = Sup_Doc.Imp_Sup_Doc_Xl_Upload(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Exp_sup_id_Max = Convert.ToInt32(ds.Tables[0].Rows[0]["SW_ID"].ToString());
        }
    }
    protected void btn_upload_Click(object sender, EventArgs e)
    {
        try
        {
            if (fileuploadExcel.HasFile)
            {
                //fileuploadExcel = (FileUpload)Session["FileUpload1"]; 
                Excelfile();
                Session.Remove("fileUpload");
                Session["fileUpload"] = fileuploadExcel;
                fileuploadExcel = (FileUpload)Session["fileUpload"];

                Label1.Text = fileuploadExcel.FileName;
                //gv_Error.Visible = false;
                //gv_Preview.Visible = true;
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public void Excelfile()
    {
        if (File.Exists(errorFolder + logFileName))
        {
            DirectoryInfo dir = new DirectoryInfo(errorFolder);


            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }
            Get_ExcelFile();
        }
        else
        {
            Directory.CreateDirectory(errorFolder);
            DirectoryInfo dir = new DirectoryInfo(errorFolder);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            Get_ExcelFile();
        }
    }


    public string Get_ExcelFile()
    {
        string connString = "";

        string strFileType = "";
        string path = "";

        string picExtension;
        string fileName2;


        strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
        //string path = "C:\\Documents and Settings\\sathis\\Desktop\\" + fileuploadExcel.FileName;
        path = errorFolder + "\\" + fileuploadExcel.FileName;

        picExtension = fnGetPictureExtn(fileuploadExcel.FileName);
        fileName2 = fileuploadExcel.FileName;
        addtoGallery1(fileName2, errorFolder);


        //Connection String to Excel Workbook
        //if (strFileType.Trim() == ".xls")
        //{
        //    connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
        //}
        //else if (strFileType.Trim() == ".xlsx")
        //{
        //    connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
        //}

        //Connection String to Excel Workbook to Support xlsm format 
        if (strFileType.Trim() == ".xls")
        {
            connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path +
                         ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
        }
        else if (strFileType.Trim() == ".xlsx" || strFileType.Trim() == ".xlsm") // ✅ ADD .xlsm
        {
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path +
                         ";Extended Properties=\"Excel 12.0 Macro;HDR=Yes;IMEX=2\""; // ✅ Add Macro
        }



        //string query = "SELECT * FROM [Sheet1$]";
        OleDbConnection conn = new OleDbConnection(connString);
        DataTable dtt = new DataTable();
        if (conn.State == ConnectionState.Closed)
            conn.Open();
        DataTable dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });


        if (dtSchema.Rows.Count == 1)
        {
            String firstSheetName = dtSchema.Rows[0].Field<string>("TABLE_NAME");
            string query = string.Format("SELECT * FROM [{0}]", firstSheetName);
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dtt);

            da.Dispose();
            conn.Close();
            conn.Dispose();
        }
        else
        {
            string query = "SELECT * FROM [Sheet1$]";

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dtt);

            da.Dispose();
            conn.Close();
            conn.Dispose();
        }



        DataTable filteredRows = dtt.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull)).CopyToDataTable();
        DataSet dss1 = new DataSet();
        dss1.Tables.Add(filteredRows);
        if (dss1.Tables[0].Rows.Count > 0)
        {
            ViewState["ds_Excel_upload"] = dss1;
        }

        Get_Sup_Doc_MaxID();
        DataSet dss = new DataSet();
        ObjUBO.JOBNO = IMPORT_JOBNO;
        ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
        ObjUBO.ITEM_SLNO = ITEM_SLNO;
        ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
        ObjUBO.Ename = "SUP_DOC_Select";
        dss = Sup_Doc.SingleWindow_Select(ObjUBO);
        DataSet Inv_ds = new DataSet();

        //ds.Tables.Add("Invoice_dt");
        Inv_ds = ds = (DataSet)ViewState["ds_Excel_upload"];
        int ysExcel = 0;

        DataColumnCollection columns = ds.Tables[0].Columns;
        if (columns.Contains("INVOICE_SLNO") && columns.Contains("ITEM_SLNO") && columns.Contains("IRN_NO"))
        {
            ysExcel = 1;
        }
        if (ysExcel != 1)
        {
            //DataTable ddt = new DataTable();
            //gv_Preview.DataSource = ddt;
            //gv_Preview.DataBind();

            //gv_Preview.Attributes.Add("Width", "100%");
            Alert_msg("Invalid Excel File!.. Please Upload Support Documents Excel File");
        }
        else
        {

            //if (dss.Tables[1].Rows[0]["ADDRESS5"] == "" && ds.Tables[0].Rows[0]["ISS_PARTY_PIN"].ToString() == "")
            //{
            //    Alert_msg("Check Your Issuing Party Pin No");


            //}
            //else
            //{



                int a = 0, b = 1, c = 1;
                ds.Tables[0].Rows.Add();
                if (ds.Tables[0].Rows.Count > a)
                {
                    #region create dataset column
                    dsXML.Tables.Add("BE_ITEM_SW_SUP_DOC");
                    dsXML.Tables[0].Columns.Add("SW_ID");
                    dsXML.Tables[0].Columns.Add("JOBNO");
                    dsXML.Tables[0].Columns.Add("INVOICE_SLNO");
                    dsXML.Tables[0].Columns.Add("ITEM_SLNO");
                    dsXML.Tables[0].Columns.Add("DECLARATION_TYPE");
                    dsXML.Tables[0].Columns.Add(new System.Data.DataColumn("IMAGE_REF_NUMBER", typeof(string)));
                    dsXML.Tables[0].Columns.Add("DOC_TYPE_CODE");
                    dsXML.Tables[0].Columns.Add("DOC_ISSUING_PARTY_CODE");
                    dsXML.Tables[0].Columns.Add("DOC_ISSUING_PARTY_NAME");
                    dsXML.Tables[0].Columns.Add("DOC_ISSUING_PARTY_NAME_ADD1");
                    dsXML.Tables[0].Columns.Add("DOC_ISSUING_PARTY_NAME_ADD2");
                    dsXML.Tables[0].Columns.Add("DOC_ISSUING_PARTY_CITY");
                    dsXML.Tables[0].Columns.Add("DOC_ISSUING_PARTY_PIN");
                    dsXML.Tables[0].Columns.Add("DOC_REF_NUMBER");
                    dsXML.Tables[0].Columns.Add("PLACE_OF_ISSUE");
                    //dsXML.Tables[0].Columns.Add(new System.Data.DataColumn("DOC_ISSUE_DATE", typeof(DateTime)));
                    //dsXML.Tables[0].Columns.Add(new System.Data.DataColumn("DOC_EXPIRY_DATE", typeof(DateTime)));
                    dsXML.Tables[0].Columns.Add("DOC_ISSUE_DATE");
                    dsXML.Tables[0].Columns.Add("DOC_EXPIRY_DATE");
                    dsXML.Tables[0].Columns.Add("BENEFICIARY_PARTY_CODE");
                    dsXML.Tables[0].Columns.Add("BENEFICIARY_PARTY_NAME");
                    dsXML.Tables[0].Columns.Add("BENEFICIARY_PARTY_ADDRESS1");
                    dsXML.Tables[0].Columns.Add("BENEFICIARY_PARTY_ADDRESS2");
                    dsXML.Tables[0].Columns.Add("BENEFICIARY_PARTY_CITY");
                    dsXML.Tables[0].Columns.Add("BENEFICIARY_PARTY_PIN");
                    dsXML.Tables[0].Columns.Add("FILE_TYPE");
                    dsXML.Tables[0].Columns.Add("USER_ID");
                    dsXML.Tables[0].Columns.Add(new System.Data.DataColumn("DATE_TIME", typeof(DateTime)));

                    dsXML.Tables[0].Columns.Add("BRANCH_CODE");
                    dsXML.Tables[0].Columns.Add("WORKING_PERIOD");
                    dsXML.Tables[0].Columns.Add(new System.Data.DataColumn("CREATEDON", typeof(DateTime)));
                    //dsXML.Tables[0].Columns.Add("CREATEDON");
                    dsXML.Tables[0].Columns.Add("CREATEDBY");
                    dsXML.Tables[0].Columns.Add("MODIFIEDBY");
                    dsXML.Tables[0].Columns.Add(new System.Data.DataColumn("MODIFIEDON", typeof(DateTime)));
                    //dsXML.Tables[0].Columns.Add("MODIFIEDON");

                    //dsXML.Tables[0].Columns.Add("DATE_TIME");
                    dsXML.Tables[0].Columns.Add("SELECT_TYPE");
                    dsXML.Tables[0].Columns.Add("ICEGATE_ID");
                    dsXML.Tables[0].Columns.Add("AMENDMENT_TYPE");
                    dsXML.Tables[0].Columns.Add("AMENDMENT_STATUS");

                    dsXML.Tables[0].Columns.Add("ICEGATE_DOC_FILE_NAME");





                    #endregion

                    dt_Avail.Columns.Add("INVOICE_SLNO");
                    dt_Avail.Columns.Add("ITEM_SLNO");
                    dt_Avail.Columns.Add("IMAGE_REF_NUMBER");
                    //--------------------End Sup doc Details--------------------------//

                    //if (strFileType == ".xls" || strFileType == ".xlsx")
                    //{
                    //    #region read Excel_Format

                    //    while (ds.Tables[0].Rows[a][0] != System.DBNull.Value)
                    //    {
                    //        i = Check_Avail_Sup_Doc(ds.Tables[0].Rows[a][2].ToString().Trim());

                    //        if (i == 1)
                    //        {
                    //            DataRow dr = dsXML.Tables[0].NewRow();

                    //            dr["SW_ID"] = Exp_sup_id_Max;
                    //            dr["JOBNO"] = IMPORT_JOBNO;
                    //            dr["INVOICE_SLNO"] = ds.Tables[0].Rows[a][0].ToString().Trim();
                    //            dr["ITEM_SLNO"] = ds.Tables[0].Rows[a][1].ToString().Trim();

                    //            //dr["SLNO"] = b;
                    //            dr["DECLARATION_TYPE"] = "E";
                    //            dr["IMAGE_REF_NUMBER"] = ds.Tables[0].Rows[a][3].ToString().Trim();

                    //            if (ds.Tables[0].Rows[a][4].ToString().Contains("-"))
                    //            {
                    //                string[] sp = ds.Tables[0].Rows[a][4].ToString().Split('-');
                    //                dr["DOC_TYPE_CODE"] = sp[0].Trim();
                    //            }
                    //            else
                    //            {

                    //                dr["DOC_TYPE_CODE"] = ds.Tables[0].Rows[a][4].ToString().Trim();
                    //            }


                    //            //if (ds.Tables[0].Rows[a][9] != System.DBNull.Value)
                    //            //{
                    //                dr["DOC_ISSUING_PARTY_NAME"] = ds.Tables[0].Rows[a][9].ToString().Trim();
                    //                dr["DOC_ISSUING_PARTY_CODE"] = "";
                    //                dr["DOC_ISSUING_PARTY_NAME_ADD1"] = ds.Tables[0].Rows[a][10].ToString().Trim();
                    //                dr["DOC_ISSUING_PARTY_NAME_ADD2"] = ds.Tables[0].Rows[a][11].ToString().Trim();
                    //                dr["DOC_ISSUING_PARTY_CITY"] = ds.Tables[0].Rows[a][12].ToString().Trim();
                    //                dr["DOC_ISSUING_PARTY_PIN"] = ds.Tables[0].Rows[a][13].ToString().Trim();

                    //            //}
                    //            //else
                    //            //{

                    //            //    if (dss.Tables[1].Rows.Count > 0)
                    //            //    {


                    //            //        dr["DOC_ISSUING_PARTY_NAME"] = dss.Tables[1].Rows[0]["IMPORTER_NAME"].ToString().Replace("&amp;", "&").Replace("amp;", "&").Trim();
                    //            //        dr["DOC_ISSUING_PARTY_NAME_ADD1"] = dss.Tables[1].Rows[0]["ADDRESS1"].ToString().Replace("&amp;", "&");
                    //            //        dr["DOC_ISSUING_PARTY_NAME_ADD2"] = dss.Tables[1].Rows[0]["ADDRESS2"].ToString().Replace("&amp;", "&");

                    //            //        string DOC_ISSUING_PARTY_CITY = "";
                    //            //        DOC_ISSUING_PARTY_CITY = dss.Tables[1].Rows[0]["ADDRESS3"].ToString() + "," + dss.Tables[1].Rows[0]["ADDRESS4"].ToString();
                    //            //        if (DOC_ISSUING_PARTY_CITY.Length > 35)
                    //            //        {
                    //            //            DOC_ISSUING_PARTY_CITY = DOC_ISSUING_PARTY_CITY.Substring(0, 35);
                    //            //        }
                    //            //        dr["DOC_ISSUING_PARTY_CITY"] = DOC_ISSUING_PARTY_CITY;
                    //            //        dr["DOC_ISSUING_PARTY_PIN"] = dss.Tables[1].Rows[0]["ADDRESS5"].ToString();

                    //            //    }

                    //            //}
                    //            //if (ds.Tables[0].Rows[a][14] != System.DBNull.Value)
                    //            //{
                    //                dr["BENEFICIARY_PARTY_NAME"] = ds.Tables[0].Rows[a][14].ToString().Trim();
                    //                dr["BENEFICIARY_PARTY_CODE"] = "";
                    //                dr["BENEFICIARY_PARTY_ADDRESS1"] = ds.Tables[0].Rows[a][15].ToString().Trim();
                    //                dr["BENEFICIARY_PARTY_ADDRESS2"] = ds.Tables[0].Rows[a][16].ToString().Trim();
                    //                dr["BENEFICIARY_PARTY_CITY"] = ds.Tables[0].Rows[a][17].ToString().Trim();
                    //                dr["BENEFICIARY_PARTY_PIN"] = ds.Tables[0].Rows[a][18].ToString().Trim();
                    //            //}
                    //            //else
                    //            //{

                    //            //    if (dss.Tables[1].Rows.Count > 0)
                    //            //    {
                    //            //        dr["BENEFICIARY_PARTY_NAME"] = dss.Tables[1].Rows[0]["CONSIGNEE_NAME"].ToString().Replace("&amp;", "&").Replace("amp;", "&").Trim();
                    //            //        dr["BENEFICIARY_PARTY_ADDRESS1"] = dss.Tables[1].Rows[0]["CONSIGNEE_ADD1"].ToString().Replace("&amp;", "&");
                    //            //        dr["BENEFICIARY_PARTY_ADDRESS2"] = dss.Tables[1].Rows[0]["CONSIGNEE_ADD2"].ToString().Replace("&amp;", "&");
                    //            //        //string BENIFICIARY = dss.Tables[1].Rows[0]["CONSIGNEE_ADD3"].ToString() + "," + dss.Tables[1].Rows[0]["CONSIGNEE_ADD4"].ToString();
                    //            //        //string CUTSTRING = BENIFICIARY.Substring(0, 35);
                    //            //        string BENEFICIARY_PARTY_CITY = "";
                    //            //        BENEFICIARY_PARTY_CITY = dss.Tables[1].Rows[0]["CONSIGNEE_ADD3"].ToString() + "," + dss.Tables[1].Rows[0]["CONSIGNEE_ADD4"].ToString();
                    //            //        if (BENEFICIARY_PARTY_CITY.Length > 35)
                    //            //        {
                    //            //            BENEFICIARY_PARTY_CITY = BENEFICIARY_PARTY_CITY.Substring(0, 35);
                    //            //        }
                    //            //        dr["BENEFICIARY_PARTY_CITY"] = BENEFICIARY_PARTY_CITY;
                    //            //        if (dss.Tables[1].Rows[0]["ADDRESS5"] != System.DBNull.Value)
                    //            //        {
                    //            //            dr["BENEFICIARY_PARTY_PIN"] = "000000";

                    //            //        }
                    //            //        else
                    //            //        {
                    //            //            dr["BENEFICIARY_PARTY_PIN"] = dss.Tables[1].Rows[0]["CONSIGNEE_ADD5"].ToString();
                    //            //        }

                    //            //    }
                    //            //}

                    //            dr["DOC_REF_NUMBER"] = ds.Tables[0].Rows[a][5].ToString().Trim();
                    //            dr["PLACE_OF_ISSUE"] = ds.Tables[0].Rows[a][6].ToString().Trim();

                    //            //dr["DOC_ISSUE_DATE"] = ds.Tables[0].Rows[a][6].ToString().Trim();
                    //            if (ds.Tables[0].Rows[a][7] != System.DBNull.Value)
                    //            {
                    //                //DateTime s1 = System.Convert.ToDateTime(ds.Tables[0].Rows[a][7].ToString().Trim());
                    //                //DateTime date = (s1);
                    //                //String frmdt = date.ToString("dd/MM/yyyy");
                    //                //String.Format("{0:MM/dd/yyyy}", dt);

                    //                dr["DOC_ISSUE_DATE"] = ds.Tables[0].Rows[a][7].ToString().Trim().Replace(" 00:00:00", "");
                    //            }
                    //            else
                    //            {
                    //                dr["DOC_ISSUE_DATE"] = Convert.ToDateTime("01/01/1900");

                    //            }



                    //            if (ds.Tables[0].Rows[a][8] != System.DBNull.Value)
                    //            {
                    //                // DateTime s2 = System.Convert.ToDateTime(ds.Tables[0].Rows[a][8].ToString().Trim());
                    //                //DateTime date1 = (s2);
                    //                //String frmdt1 = date1.ToString("dd/MM/yyyy");
                    //                //String.Format("{0:MM/dd/yyyy}", dt);
                    //                dr["DOC_EXPIRY_DATE"] = ds.Tables[0].Rows[a][8].ToString().Trim().Replace(" 00:00:00", "");
                    //            }
                    //            else
                    //            {
                    //                dr["DOC_EXPIRY_DATE"] = Convert.ToDateTime("01/01/1900");

                    //            }

                    //            dr["FILE_TYPE"] = "PDF";
                    //            dr["SELECT_TYPE"] = ds.Tables[0].Rows[a][2].ToString().Trim();
                    //            dr["BRANCH_CODE"] = currentbranch;
                    //            dr["WORKING_PERIOD"] = Working_Period;
                    //            dr["CREATEDON"] = Convert.ToDateTime(LoginDate); ;
                    //            dr["CREATEDBY"] = currentuser;
                    //            dr["MODIFIEDBY"] = currentuser;
                    //            dr["MODIFIEDON"] = Convert.ToDateTime(LoginDate);
                    //            dr["USER_ID"] = currentuser;
                    //            dr["DATE_TIME"] = Convert.ToDateTime(LoginDate);
                    //            dr["AMENDMENT_TYPE"] = null;
                    //            dr["AMENDMENT_STATUS"] = null;
                    //            dr["ICEGATE_DOC_FILE_NAME"] = ds.Tables[0].Rows[a][20].ToString().Trim(); ;

                    //            if (ds.Tables[0].Rows[a][19] != System.DBNull.Value)
                    //            {
                    //                dr["ICEGATE_ID"] = ds.Tables[0].Rows[a][19].ToString().Trim();
                    //            }
                    //            else
                    //            {
                    //                dr["ICEGATE_ID"] = Connection.Get_EXP_Icegate_Id("");
                    //            }

                    //            //if (distinctDT.Rows.Count == 0)
                    //            //{
                    //            //    distinctDT = SelectDistinct(ds.Tables[0], "IRN_NO");
                    //            //    if (ds.Tables[0].Rows.Count != distinctDT.Rows.Count)
                    //            //    {
                    //            //        //DataRow invalid = distinctDT.NewRow();
                    //            //        //invalid["ERROR"] = distinctDT.Rows.ToString();
                    //            //        //INVALID.Columns.Add("ERROR") = distinctDT;


                    //            //    }
                    //            //}
                    //            dsXML.Tables[0].Rows.Add(dr);




                    //            if (dsXML.Tables[0].Rows.Count > 0)
                    //            {
                    //                ViewState["dss_Excel_upload"] = dsXML;
                    //            }


                    //        }

                    //        else
                    //        {
                    //            dt_Avail.Rows.Add(ds.Tables[0].Rows[a][0].ToString().Trim(), ds.Tables[0].Rows[a][1].ToString(), ds.Tables[0].Rows[a][2].ToString().Trim());
                    //        }


                    //        a++;
                    //        b++;

                    //        //a = b;
                    //        Exp_sup_id_Max++;
                    //        //String xmlData = ConvertDataTableToXML(dsXML.Tables[0]);



                    //    }


                    //    #endregion
                    //}

                    ////gv_Preview.DataSource = SelecctedSUPPDOC();
                    ////gv_Preview.DataBind();

                    //////gv_Preview.Visible = true;
                    ////gv_Preview.Columns[2].Visible = false;
                    ////gv_Preview.Columns[20].Visible = false;
                    ////DataSet ds = new DataSet();
                    ////ds = (DataSet)ViewState["ds_Excel_upload"];
                    ////DataTable distinctDT = SelectDistinct(dsXML.Tables[0], "IMAGE_REF_NUMBER");

                    //// One single DataTable — all columns together
                    //// No need to split at all


                    //Run_SW_Doc_Validation();




                 

                     if (strFileType == ".xls" || strFileType == ".xlsx" || strFileType == ".xlsm") // ✅ ADD .xlsm
                     {
                        #region read Excel_Format

                        // ✅ ADD THIS — mandatory check before while loop starts
                        DataTable dtMandatory = new DataTable();
                        dtMandatory.Columns.Add("ROW_NO");
                        dtMandatory.Columns.Add("DATA_FILED");
                        dtMandatory.Columns.Add("ERRORS_MESSAGE");

                        while (ds.Tables[0].Rows[a][3] != System.DBNull.Value)
                        {
                            // ✅ ADD THIS — mandatory check for each row inside loop
                            string missingFields = "";

                            if (ds.Tables[0].Rows[a][0] == System.DBNull.Value ||
                                ds.Tables[0].Rows[a][0].ToString().Trim() == "")
                                missingFields = missingFields + "INVOICE_SLNO, ";

                            if (ds.Tables[0].Rows[a][1] == System.DBNull.Value ||
                                ds.Tables[0].Rows[a][1].ToString().Trim() == "")
                                missingFields = missingFields + "ITEM_SLNO, ";

                            if (ds.Tables[0].Rows[a][2] == System.DBNull.Value ||
                                ds.Tables[0].Rows[a][2].ToString().Trim() == "")
                                missingFields = missingFields + "SELECT_TYPE, ";

                            if (ds.Tables[0].Rows[a][3] == System.DBNull.Value ||
                                ds.Tables[0].Rows[a][3].ToString().Trim() == "")
                                missingFields = missingFields + "IMAGE_REF_NUMBER, ";

                            if (ds.Tables[0].Rows[a][4] == System.DBNull.Value ||
                                ds.Tables[0].Rows[a][4].ToString().Trim() == "")
                                missingFields = missingFields + "DOC_TYPE_CODE, ";

                            if (ds.Tables[0].Rows[a][6] == System.DBNull.Value ||
                                ds.Tables[0].Rows[a][6].ToString().Trim() == "")
                                missingFields = missingFields + "PLACE_OF_ISSUE, ";

                            if (ds.Tables[0].Rows[a][7] == System.DBNull.Value ||
                                ds.Tables[0].Rows[a][7].ToString().Trim() == "")
                                missingFields = missingFields + "DOC_ISSUE_DATE, ";

                            if (ds.Tables[0].Rows[a][9] == System.DBNull.Value ||
                                ds.Tables[0].Rows[a][9].ToString().Trim() == "")
                                missingFields = missingFields + "ISS_PARTY_NAME, ";

                            if (ds.Tables[0].Rows[a][14] == System.DBNull.Value ||
                                ds.Tables[0].Rows[a][14].ToString().Trim() == "")
                                missingFields = missingFields + "BEN_PARTY_NAME, ";

                            if (ds.Tables[0].Rows[a][19] == System.DBNull.Value ||
                                ds.Tables[0].Rows[a][19].ToString().Trim() == "")
                                missingFields = missingFields + "ICEGATE_ID, ";

                            // ✅ If any mandatory field missing — add to error table and skip row
                            if (missingFields != "")
                            {
                                DataRow drErr = dtMandatory.NewRow();
                                drErr["ROW_NO"] = "Row " + (a + 1);
                                drErr["DATA_FILED"] = missingFields.TrimEnd(',', ' ');
                                drErr["ERRORS_MESSAGE"] = "Mandatory field Missing";
                                dtMandatory.Rows.Add(drErr);

                                a++;
                                b++;
                                Exp_sup_id_Max++;
                                continue; // ✅ Skip this row — don't add to dsXML
                            }

                            i = Check_Avail_Sup_Doc(ds.Tables[0].Rows[a][2].ToString().Trim());

                            if (i == 1)
                            {
                                DataRow dr = dsXML.Tables[0].NewRow();

                                dr["SW_ID"] = Exp_sup_id_Max;
                                dr["JOBNO"] = IMPORT_JOBNO;
                                dr["INVOICE_SLNO"] = ds.Tables[0].Rows[a][0].ToString().Trim();
                                dr["ITEM_SLNO"] = ds.Tables[0].Rows[a][1].ToString().Trim();

                                dr["DECLARATION_TYPE"] = "E";
                                dr["IMAGE_REF_NUMBER"] = ds.Tables[0].Rows[a][3].ToString().Trim();

                                if (ds.Tables[0].Rows[a][4].ToString().Contains("-"))
                                {
                                    string[] sp = ds.Tables[0].Rows[a][4].ToString().Split('-');
                                    dr["DOC_TYPE_CODE"] = sp[0].Trim();
                                }
                                else
                                {
                                    dr["DOC_TYPE_CODE"] = ds.Tables[0].Rows[a][4].ToString().Trim();
                                }

                                dr["DOC_ISSUING_PARTY_NAME"] = ds.Tables[0].Rows[a][9].ToString().Trim();
                                dr["DOC_ISSUING_PARTY_CODE"] = "";
                                dr["DOC_ISSUING_PARTY_NAME_ADD1"] = ds.Tables[0].Rows[a][10].ToString().Trim();
                                dr["DOC_ISSUING_PARTY_NAME_ADD2"] = ds.Tables[0].Rows[a][11].ToString().Trim();
                                dr["DOC_ISSUING_PARTY_CITY"] = ds.Tables[0].Rows[a][12].ToString().Trim();
                                dr["DOC_ISSUING_PARTY_PIN"] = ds.Tables[0].Rows[a][13].ToString().Trim();

                                dr["BENEFICIARY_PARTY_NAME"] = ds.Tables[0].Rows[a][14].ToString().Trim();
                                dr["BENEFICIARY_PARTY_CODE"] = "";
                                dr["BENEFICIARY_PARTY_ADDRESS1"] = ds.Tables[0].Rows[a][15].ToString().Trim();
                                dr["BENEFICIARY_PARTY_ADDRESS2"] = ds.Tables[0].Rows[a][16].ToString().Trim();
                                dr["BENEFICIARY_PARTY_CITY"] = ds.Tables[0].Rows[a][17].ToString().Trim();
                                dr["BENEFICIARY_PARTY_PIN"] = ds.Tables[0].Rows[a][18].ToString().Trim();

                                dr["DOC_REF_NUMBER"] = ds.Tables[0].Rows[a][5].ToString().Trim();
                                dr["PLACE_OF_ISSUE"] = ds.Tables[0].Rows[a][6].ToString().Trim();

                                if (ds.Tables[0].Rows[a][7] != System.DBNull.Value)
                                {
                                    dr["DOC_ISSUE_DATE"] = ds.Tables[0].Rows[a][7].ToString().Trim().Replace(" 00:00:00", "");
                                }
                                else
                                {
                                    dr["DOC_ISSUE_DATE"] = Convert.ToDateTime("01/01/1900");
                                }

                                if (ds.Tables[0].Rows[a][8] != System.DBNull.Value)
                                {
                                    dr["DOC_EXPIRY_DATE"] = ds.Tables[0].Rows[a][8].ToString().Trim().Replace(" 00:00:00", "");
                                }
                                else
                                {
                                    dr["DOC_EXPIRY_DATE"] = Convert.ToDateTime("01/01/1900");
                                }

                                dr["FILE_TYPE"] = "PDF";
                                dr["SELECT_TYPE"] = ds.Tables[0].Rows[a][2].ToString().Trim();
                                dr["BRANCH_CODE"] = currentbranch;
                                dr["WORKING_PERIOD"] = Working_Period;
                                dr["CREATEDON"] = Convert.ToDateTime(LoginDate);
                                dr["CREATEDBY"] = currentuser;
                                dr["MODIFIEDBY"] = currentuser;
                                dr["MODIFIEDON"] = Convert.ToDateTime(LoginDate);
                                dr["USER_ID"] = currentuser;
                                dr["DATE_TIME"] = Convert.ToDateTime(LoginDate);
                                dr["AMENDMENT_TYPE"] = null;
                                dr["AMENDMENT_STATUS"] = null;
                                dr["ICEGATE_DOC_FILE_NAME"] = ds.Tables[0].Rows[a][20].ToString().Trim();

                                if (ds.Tables[0].Rows[a][19] != System.DBNull.Value)
                                {
                                    dr["ICEGATE_ID"] = ds.Tables[0].Rows[a][19].ToString().Trim();
                                }
                                else
                                {
                                    dr["ICEGATE_ID"] = Connection.Get_EXP_Icegate_Id("");
                                }

                                dsXML.Tables[0].Rows.Add(dr);

                                if (dsXML.Tables[0].Rows.Count > 0)
                                {
                                    ViewState["dss_Excel_upload"] = dsXML;
                                }
                            }
                            else
                            {
                                dt_Avail.Rows.Add(
                                    ds.Tables[0].Rows[a][0].ToString().Trim(),
                                    ds.Tables[0].Rows[a][1].ToString(),
                                    ds.Tables[0].Rows[a][2].ToString().Trim());
                            }

                            a++;
                            b++;
                            Exp_sup_id_Max++;
                        }

                        // ✅ ADD THIS — after while loop, show mandatory errors if any
                        if (dtMandatory.Rows.Count > 0)
                        {
                            gv_Error.DataSource = dtMandatory;
                            gv_Error.DataBind();
                            gv_Error.Visible = true;
                            mainmastop2container_rght_tag2_txt1.InnerText = "Preview Data";
                            btn_Exp_Sup_Doc_Upload.Visible = false;

                            // ✅ Stop further validation — don't call Run_SW_Doc_Validation
                            ViewState["err_Validate"] = "Y";
                            return strFileType.Trim();
                        }

                        #endregion
                    }

                    // One single DataTable — all columns together
                    // No need to split at all
                    Run_SW_Doc_Validation();






                    if (ViewState["err_Validate"] != null &&   // ✅ change || to && and null check
    ViewState["err_Validate"].ToString() == "N")
                    {
                        Excel_Validation(SelecctedSUPPDOC());
                    }
                 



                    //Excel_Validation(SelecctedSUPPDOC());

                }
                else
                {
                    //DataTable ddt = new DataTable();
                    //gv_Preview.DataSource = ddt;
                    //gv_Preview.DataBind();


                }



            //}
        }

        return strFileType.Trim();
    }


    private void Run_SW_Doc_Validation()
    {
        try
        {
            // ── Step 1 : Select validation columns from dsXML ────────────────
            DataView view_SW = new DataView(dsXML.Tables[0]);
            DataSet ds_validate = new DataSet();

            System.Data.DataTable selected_SW = view_SW.ToTable("Selected", true,
                "INVOICE_SLNO",
                "ITEM_SLNO",
                "DECLARATION_TYPE",
                "IMAGE_REF_NUMBER",
                "DOC_TYPE_CODE",
                "DOC_ISSUING_PARTY_CODE",
                "DOC_ISSUING_PARTY_NAME",
                "DOC_ISSUING_PARTY_NAME_ADD1",
                "DOC_ISSUING_PARTY_NAME_ADD2",
                "DOC_ISSUING_PARTY_CITY",
                "DOC_ISSUING_PARTY_PIN",
                "DOC_REF_NUMBER",
                "PLACE_OF_ISSUE",
                "DOC_ISSUE_DATE",
                "DOC_EXPIRY_DATE",
                "BENEFICIARY_PARTY_CODE",
                "BENEFICIARY_PARTY_NAME",
                "BENEFICIARY_PARTY_ADDRESS1",
                "BENEFICIARY_PARTY_ADDRESS2",
                "BENEFICIARY_PARTY_CITY",
                "BENEFICIARY_PARTY_PIN",
                "SELECT_TYPE",
                "ICEGATE_ID",
                "ICEGATE_DOC_FILE_NAME"
            );

            // ── Step 2 : Delete old temp data ─────────────────────────────────
            Delete_SW_Temp_Table();

            foreach (DataRow row in selected_SW.Rows)
            {
                if (row["DOC_ISSUE_DATE"] != null && row["DOC_ISSUE_DATE"] != DBNull.Value)
                {
                    string issueDate = row["DOC_ISSUE_DATE"].ToString().Trim();
                    if (issueDate.Length > 10)
                        row["DOC_ISSUE_DATE"] = issueDate.Substring(0, 10);
                }

                if (row["DOC_EXPIRY_DATE"] != null && row["DOC_EXPIRY_DATE"] != DBNull.Value)
                {
                    string expiryDate = row["DOC_EXPIRY_DATE"].ToString().Trim();
                    if (expiryDate.Length > 10)
                        row["DOC_EXPIRY_DATE"] = expiryDate.Substring(0, 10);
                }
            }



            // ── Step 3 : Bulk insert into temp table ──────────────────────────
            admin.SqlBulk_Upload_Product(
                "TBL_BE_ITEM_SW_SUP_DOC_EXCEL_FORMAT",
                selected_SW,
                Connection.GetConnection());

            // ── Step 4 : Run validation stored procedure ──────────────────────
            ds_validate = Imp_XL.Bulk_Excel_Validation("BE_ITEM_SW_SUP_DOC_Val");

            // ── Step 5 : Show errors or allow upload ──────────────────────────
            if (ds_validate == null || ds_validate.Tables.Count == 0)
            {
                Alert_msg("Validation returned no result. Please try again.");
                return;
            }

            if (ds_validate.Tables[0].Rows.Count > 0)
            {
                // ── Errors found — show in grid, block upload ─────────────────
                ViewState["Admin_err"] = "N";
                ViewState["err_Validate"] = "Y";
                error = "errormsg";

                //gv_Error.DataSource = ds_validate.Tables[0];
                //gv_Error.DataBind();
                //btn_upload.Visible = false;

                gv_Error.DataSource = ds_validate.Tables[0];
                gv_Error.DataBind();
                gv_Error.Visible = true;   // ✅ ADD THIS LINE ONLY
                btn_upload.Visible = false;
                mainmastop2container_rght_tag2_txt1.InnerText = "Please fix errors before uploading."; // ✅ ADD THIS LINE ONLY


            }
            else
            {
                // ── No errors — allow upload ──────────────────────────────────
                ViewState["Admin_err"] = "N";
                ViewState["err_Validate"] = "N";
                btn_upload.Visible = true;

                // ── Tables[1] check — only access if it exists ────────────────
                if (ds_validate.Tables.Count > 1 &&
                    ds_validate.Tables[1].Rows.Count > 0)
                {
                    gv_Error.DataSource = ds_validate.Tables[1];
                    gv_Error.DataBind();
                }
                else
                {
                    // ── Show preview from dsXML if no Tables[1] ───────────────
                    //gv_Error.DataSource = dsXML.Tables[0];
                    //gv_Error.DataBind();


                    gv_Error.DataSource = dsXML.Tables[0];
                    gv_Error.DataBind();
                    gv_Error.Visible = true;  // ✅ ADD THIS LINE ONLY
                }
            }
        }
        catch (Exception ex)
        {
            Alert_msg("SW Doc Validation Error: " + ex.Message);
        }
    }


    private void Delete_SW_Temp_Table()
    {
        // Connection.GetConnection() returns string — wrap in new SqlConnection
        SqlConnection con = new SqlConnection(Connection.GetConnection());
        try
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlCommand cmd = new SqlCommand(
                "DELETE FROM TBL_BE_ITEM_SW_SUP_DOC_EXCEL_FORMAT", con);
            cmd.CommandTimeout = 120;
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Alert_msg("Delete Temp Error: " + ex.Message);
        }
        finally
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Dispose();
        }
    }

    #region DATASET HELPER
    private bool ColumnEqual(object A, object B)
    {
        // Compares two values to see if they are equal. Also compares DBNULL.Value.           
        if (A == DBNull.Value && B == DBNull.Value) //  both are DBNull.Value
            return true;
        if (A == DBNull.Value || B == DBNull.Value) //  only one is BNull.Value
            return false;
        return (A.Equals(B));  // value type standard comparison
    }

    public DataTable SelectDistinct(DataTable SourceTable, string FieldName)
    {
        // Create a Datatable – datatype same as FieldName
        DataTable dt = new DataTable(SourceTable.TableName);
        DataTable dtt = new DataTable(SourceTable.TableName);

        dtt.Columns.Add(FieldName, SourceTable.Columns[FieldName].DataType);
        dt.Columns.Add(FieldName, SourceTable.Columns[FieldName].DataType);
        // Loop each row & compare each value with one another
        // Add it to datatable if the values are mismatch
        object LastValue = null;
        foreach (DataRow dr in SourceTable.Select("", FieldName))
        {
            if (LastValue == null || !(ColumnEqual(LastValue, dr[FieldName])))
            {
                LastValue = dr[FieldName];
                dt.Rows.Add(new object[] { LastValue });
            }
            else
            {
                dtt.Rows.Add(LastValue);

            }
        }
        return dt;
    }
    #endregion


    protected void btn_Exp_Sup_Doc_Xl_Upload(object sender, EventArgs e)
    {
        try
        {

            //Please Upload File
            if (Label1.Text == "")
            {
                Alert_msg("Please Upload File");
            }
            else
            {

                ExcelUpload();


                //DataSet d = new DataSet();
                //ObjUBO.JOBNO = IMPORT_JOBNO;
                ////ObjUBO.INVOICE_SLNO = ddlInvoice_SlNo.SelectedItem.Text;
                ////ObjUBO.ITEM_SLNO = ddl_ItemSlno.SelectedItem.Text;
                //ObjUBO.flag = "Excel_Avail";
                //ObjUBO.BRANCH_CODE = currentbranch;


                //d = Sup_Doc.Imp_Sup_Doc_Xl_Upload(ObjUBO, SelecctedSUPPDOC());

                //if (d.Tables[0].Rows.Count > 0)
                //{
                //    MP_U1.Show();
                //}
                //else
                //{
                //Excel_Validation(selected);
                //}
            }

        }
        catch (Exception ex)
        {
            //Maildb.StoreMailContents(ds, email);
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }


    protected void btnyes_Click(object sender, EventArgs e)
    {


        DataSet d = new DataSet();
        ObjUBO.JOBNO = IMPORT_JOBNO;
        ObjUBO.flag = "Delete_Excel";
        ObjUBO.BRANCH_CODE = currentbranch;
        d = Sup_Doc.Imp_Sup_Doc_Xl_Upload(ObjUBO, SelecctedSUPPDOC());

        if (d.Tables[0].Rows.Count > 0)
        {
            Alert_msg("Not Deleted.");
        }
        else
        {
            //Alert_msg("deleted ur Old Sup Doc Successfully");

            if (Sup_Doc.result == 1)
            {
                Alert_msg("Deleted Successfully.");
                MP_U1.Hide();
                gv_Error.Visible = false;
                btn_Exp_Sup_Doc_Upload.Visible = false;
                mainmastop2container_rght_tag2_txt1.InnerText = "Preview Data";
                //fileuploadExcel.Dispose();
                //fileuploadExcel.Attributes.Clear();
                Label1.Text = "";
                //if (d.Tables[0].Rows.Count > 0)
                //{
                //    gv_Preview.DataSource = d.Tables[0];
                //    gv_Preview.DataBind();
                //}
                //else
                //{
                //    DataTable ddt = new DataTable();
                //    gv_Preview.DataSource = ddt;
                //    gv_Preview.DataBind();
                //}

            }
            else
                Alert_msg("Not Deleted.");
        }
    }


   








    public DataTable SelecctedSUPPDOC()
    {
        DataSet dtShow1 = new DataSet();
        dtShow1 = (DataSet)ViewState["dss_Excel_upload"];
        System.Data.DataView view = new System.Data.DataView(dtShow1.Tables[0]);
        return selected = view.ToTable("Selected", false, "INVOICE_SLNO", "ITEM_SLNO", "DECLARATION_TYPE", "IMAGE_REF_NUMBER", "DOC_REF_NUMBER", "DOC_TYPE_CODE", "PLACE_OF_ISSUE"
             , "DOC_ISSUE_DATE", "DOC_EXPIRY_DATE", "DOC_ISSUING_PARTY_CODE",
             "DOC_ISSUING_PARTY_NAME", "DOC_ISSUING_PARTY_NAME_ADD1"
             , "DOC_ISSUING_PARTY_NAME_ADD2", "DOC_ISSUING_PARTY_CITY", "DOC_ISSUING_PARTY_PIN", "BENEFICIARY_PARTY_NAME", "BENEFICIARY_PARTY_CODE", "BENEFICIARY_PARTY_ADDRESS1"
             , "BENEFICIARY_PARTY_ADDRESS2", "BENEFICIARY_PARTY_CITY", "BENEFICIARY_PARTY_PIN", "FILE_TYPE", "SELECT_TYPE", "ICEGATE_ID", "ICEGATE_DOC_FILE_NAME");




    }
    public bool Check_Field()
    {
        bool ischk = false;

        //System.Data.DataTable Mandatory_select = SelecctedSUPPDOC();
        DataView Mandatory_select = SelecctedSUPPDOC().DefaultView;
        //Mandatory_select.RowFilter = "IsNull(CONVERT(INVOICE_SLNO,'System.String'),'')='' or IsNull(CONVERT(ITEM_SLNO, 'System.String'),'')='' or IsNull(CONVERT(IMAGE_REF_NUMBER , 'System.String'),'')='' or IsNull(CONVERT(DOC_REF_NUMBER , 'System.String'),'')='' or IsNull(CONVERT(DOC_TYPE_CODE , 'System.String'),'')='' or IsNull(CONVERT(PLACE_OF_ISSUE , 'System.String'),'')='' or IsNull(CONVERT(DOC_ISSUE_DATE , 'System.String'),'')=''  or IsNull(CONVERT(BENEFICIARY_PARTY_NAME , 'System.String'),'')='' or IsNull(CONVERT(BENEFICIARY_PARTY_CODE , 'System.String'),'')='' or IsNull(CONVERT(BENEFICIARY_PARTY_CODE , 'System.String'),'')='' or IsNull(CONVERT(BENEFICIARY_PARTY_ADDRESS1 , 'System.String'),'')='' or IsNull(CONVERT(BENEFICIARY_PARTY_ADDRESS2 , 'System.String'),'')='' or IsNull(CONVERT(BENEFICIARY_PARTY_CITY , 'System.String'),'')='' or IsNull(CONVERT(ICEGATE_DOC_FILE_NAME , 'System.String'),'')='' or IsNull(CONVERT(BENEFICIARY_PARTY_PIN , 'System.String'),'')='' or IsNull(CONVERT(FILE_TYPE , 'System.String'),'')='' or IsNull(CONVERT(SELECT_TYPE , 'System.String'),'')='' or IsNull(CONVERT(ICEGATE_ID , 'System.String'),'')=''";
        Mandatory_select.RowFilter = "IsNull(CONVERT(INVOICE_SLNO,'System.String'),'')='' or IsNull(CONVERT(ITEM_SLNO, 'System.String'),'')='' or IsNull(CONVERT(IMAGE_REF_NUMBER , 'System.String'),'')='' or IsNull(CONVERT(DOC_TYPE_CODE , 'System.String'),'')='' or IsNull(CONVERT(PLACE_OF_ISSUE , 'System.String'),'')='' or IsNull(CONVERT(DOC_ISSUE_DATE , 'System.String'),'')=''  or IsNull(CONVERT(BENEFICIARY_PARTY_NAME , 'System.String'),'')='' or  IsNull(CONVERT(SELECT_TYPE , 'System.String'),'')='' or IsNull(CONVERT(ICEGATE_ID , 'System.String'),'')='' or IsNull(CONVERT(DOC_ISSUING_PARTY_NAME , 'System.String'),'')=''";


        //System.Data.DataTable Mandatory_tb = Mandatory_select.ToTable("Selected", false, "INVOICE_SLNO", "ITEM_SLNO", "DECLARATION_TYPE", "IMAGE_REF_NUMBER", "DOC_REF_NUMBER", "DOC_TYPE_CODE", "PLACE_OF_ISSUE", "DOC_ISSUE_DATE", "DOC_EXPIRY_DATE", "DOC_ISSUING_PARTY_CODE", "DOC_ISSUING_PARTY_NAME", "DOC_ISSUING_PARTY_NAME_ADD1"
        //   , "DOC_ISSUING_PARTY_NAME_ADD2", "DOC_ISSUING_PARTY_CITY", "DOC_ISSUING_PARTY_PIN", "BENEFICIARY_PARTY_NAME", "BENEFICIARY_PARTY_CODE", "BENEFICIARY_PARTY_ADDRESS1"
        //   , "BENEFICIARY_PARTY_ADDRESS2", "BENEFICIARY_PARTY_CITY", "BENEFICIARY_PARTY_PIN", "FILE_TYPE", "SELECT_TYPE", "ICEGATE_ID", "ICEGATE_DOC_FILE_NAME");
        System.Data.DataTable Mandatory_tb = Mandatory_select.ToTable("Selected", false, "INVOICE_SLNO", "ITEM_SLNO", "DECLARATION_TYPE", "IMAGE_REF_NUMBER", "DOC_TYPE_CODE", "PLACE_OF_ISSUE", "DOC_ISSUE_DATE", "DOC_ISSUING_PARTY_NAME"
          , "BENEFICIARY_PARTY_NAME", "ICEGATE_ID");



        DataView dv = Mandatory_tb.DefaultView;
        DataTable dat = new DataTable();
        dat = dv.ToTable("Selected", false, "INVOICE_SLNO", "ITEM_SLNO");
        dat.Columns.Add("DATA_FILED");
        dat.Columns.Add("ERRORS_MESSAGE");


        if (Mandatory_tb.Rows.Count > 0)
        {
            for (int i = 0; i < Mandatory_tb.Rows.Count; i++)
            {
                for (int j = 0; j < Mandatory_tb.Columns.Count; j++)
                {
                    //if (Mandatory_tb.Rows[i][j].ToString() == "" && Mandatory_tb.Columns[j].ColumnName.ToString() != "BENEFICIARY_PARTY_CODE" && Mandatory_tb.Columns[j].ColumnName.ToString() != "DOC_ISSUING_PARTY_CODE"
                    //    && Mandatory_tb.Columns[j].ColumnName.ToString() != "DOC_EXPIRY_DATE" && Mandatory_tb.Columns[j].ColumnName.ToString() != "DOC_ISSUING_PARTY_NAME" && Mandatory_tb.Columns[j].ColumnName.ToString() != "DOC_ISSUING_PARTY_NAME_ADD1" && Mandatory_tb.Columns[j].ColumnName.ToString() != "DOC_ISSUING_PARTY_NAME_ADD2" && Mandatory_tb.Columns[j].ColumnName.ToString() != "DOC_ISSUING_PARTY_CITY" && Mandatory_tb.Columns[j].ColumnName.ToString() != "DOC_ISSUING_PARTY_PIN" && Mandatory_tb.Columns[j].ColumnName.ToString() != "BENEFICIARY_PARTY_NAME" && Mandatory_tb.Columns[j].ColumnName.ToString() != "BENEFICIARY_PARTY_ADDRESS1" && Mandatory_tb.Columns[j].ColumnName.ToString() != "BENEFICIARY_PARTY_ADDRESS2" && Mandatory_tb.Columns[j].ColumnName.ToString() != "BENEFICIARY_PARTY_CITY" && Mandatory_tb.Columns[j].ColumnName.ToString() != "BENEFICIARY_PARTY_PIN" && Mandatory_tb.Columns[j].ColumnName.ToString() != "ICEGATE_DOC_FILE_NAME"
                    if (Mandatory_tb.Rows[i][j].ToString() == "")
                    {
                        dat.Rows[i]["DATA_FILED"] = dat.Rows[i]["DATA_FILED"] + " " + Mandatory_tb.Columns[j].ColumnName.ToString() + ",";
                        dat.Rows[i]["ERRORS_MESSAGE"] = dat.Rows[i]["ERRORS_MESSAGE"] + "mandatory field ,";


                    }
                }
            }
        }
        //else{
            if (dat.Rows.Count > 0 && dat.Rows[0][3].ToString() != "")
            {
                //ischk = true;  //Hide by Antony on 23/04/2021
                ischk = false;
                gv_Error.DataSource = dat;
                gv_Error.DataBind();
                gv_Error.Visible = true;
                
                mainmastop2container_rght_tag2_txt1.InnerText = "Preview Data";
                btn_Exp_Sup_Doc_Upload.Visible = false;
                //gv_Preview.Visible = true;
            }
            else
            {

                for (int i = 0; i < Mandatory_tb.Rows.Count; i++)
                {
                   

                    for (int j = 0; j < Mandatory_tb.Columns.Count; j++)
                    {
                        if (Mandatory_tb.Rows[i][j].ToString() != "")
                        {

                            DataView dvv = Mandatory_tb.DefaultView;
                            dvv.RowFilter = "IMAGE_REF_NUMBER =" + Mandatory_tb.Rows[i]["IMAGE_REF_NUMBER"].ToString() + " AND " +
                                "INVOICE_SLNO =" + Mandatory_tb.Rows[i]["INVOICE_SLNO"].ToString() + " AND " +
                                "ITEM_SLNO =" + Mandatory_tb.Rows[i]["ITEM_SLNO"].ToString() + " AND " +
                                "SELECT_TYPE Like'" + Mandatory_tb.Rows[i]["SELECT_TYPE"].ToString() + "%'";
                            if ("IMAGE_REF_NUMBER" == Mandatory_tb.Columns[j].ColumnName.ToString())
                            {
                                if (Mandatory_tb.Rows[i][j].ToString().Length > 1)
                                {
                                    if (Mandatory_tb.Rows[i][j].ToString().Length != 16)
                                    {
                                        dat.Rows[i]["DATA_FILED"] = dat.Rows[i]["DATA_FILED"] + " " + Mandatory_tb.Columns[j].ColumnName.ToString() + ",";

                                        dat.Rows[i]["ERRORS_MESSAGE"] = dat.Rows[i]["ERRORS_MESSAGE"] + "IRN Should be 16 Digit, ";
                                    }
                                    else
                                    {

                                        if (Mandatory_tb.Rows[i][j].ToString().Length == 16)
                                        {
                                           
                                            if (dvv.Count > 1)
                                            {
                                                
                                                    dat.Rows[i]["DATA_FILED"] = dat.Rows[i]["DATA_FILED"] + " " + Mandatory_tb.Columns[j].ColumnName.ToString() + ",";

                                                    dat.Rows[i]["ERRORS_MESSAGE"] = dat.Rows[i]["ERRORS_MESSAGE"] + "Duplicate IRN, ";

                                              

                                            }
                                        }
                                    }

                                }


                            }
                            if ("DOC_TYPE_CODE" == Mandatory_tb.Columns[j].ColumnName.ToString())
                            {
                                if (Mandatory_tb.Rows[i][j].ToString().Length > 1)
                                {
                                    if (Mandatory_tb.Rows[i][j].ToString().Length > 6)
                                    {
                                        dat.Rows[i]["DATA_FILED"] = dat.Rows[i]["DATA_FILED"] + " " + Mandatory_tb.Columns[j].ColumnName.ToString() + ",";

                                        dat.Rows[i]["ERRORS_MESSAGE"] = dat.Rows[i]["ERRORS_MESSAGE"] + "DOC_TYPE_CODE MAX 6 DIGITS, ";
                                    }
                                }


                            }
                            if ("DOC_ISSUE_DATE" == Mandatory_tb.Columns[j].ColumnName.ToString())
                            {
                                string ddt = Mandatory_tb.Rows[i][j].ToString().Replace("01/01/1900 00:00:00","");
                                if (ddt.Length > 1 && ddt != "")
                                {
                                    if (Regex.IsMatch(Mandatory_tb.Rows[i][j].ToString(), "(((0|1)[0-9]|2[0-9]|3[0-1])\\/(0[1-9]|1[0-2])\\/((19|20)\\d\\d))$"))
                                    {
                                        DateTime dt;
                                        if (DateTime.TryParseExact(Mandatory_tb.Rows[i][j].ToString(), "dd/MM/yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out dt))
                                        {



                                        }
                                        else
                                        {
                                            dat.Rows[i]["DATA_FILED"] = dat.Rows[i]["DATA_FILED"] + " " + Mandatory_tb.Columns[j].ColumnName.ToString() + ",";

                                            dat.Rows[i]["ERRORS_MESSAGE"] = dat.Rows[i]["ERRORS_MESSAGE"] + "Invalid DOC_ISSUE_DATE Format, ";
                                        }
                                    }
                                    else
                                    {
                                        dat.Rows[i]["DATA_FILED"] = dat.Rows[i]["DATA_FILED"] + " " + Mandatory_tb.Columns[j].ColumnName.ToString() + ",";

                                        dat.Rows[i]["ERRORS_MESSAGE"] = dat.Rows[i]["ERRORS_MESSAGE"] + "Invalid DOC_ISSUE_DATE Format, ";
                                    }

                                }



                            }

                            if ("DOC_EXPIRY_DATE" == Mandatory_tb.Columns[j].ColumnName.ToString())
                            {
                                string ddt = Mandatory_tb.Rows[i][j].ToString().Replace("01/01/1900 00:00:00", "");
                                if (ddt.Length > 1 && ddt != "")
                                {
                                    if (Regex.IsMatch(Mandatory_tb.Rows[i][j].ToString(), "(((0|1)[0-9]|2[0-9]|3[0-1])\\/(0[1-9]|1[0-2])\\/((19|20)\\d\\d))$"))
                                    {
                                        DateTime dt;
                                        if (DateTime.TryParseExact(Mandatory_tb.Rows[i][j].ToString(), "dd/MM/yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out dt))
                                        {



                                        }
                                        else
                                        {
                                            dat.Rows[i]["DATA_FILED"] = dat.Rows[i]["DATA_FILED"] + " " + Mandatory_tb.Columns[j].ColumnName.ToString() + ",";

                                            dat.Rows[i]["ERRORS_MESSAGE"] = dat.Rows[i]["ERRORS_MESSAGE"] + "Invalid DOC_EXPIRY_DATE Format, ";
                                        }
                                    }
                                    else
                                    {
                                        dat.Rows[i]["DATA_FILED"] = dat.Rows[i]["DATA_FILED"] + " " + Mandatory_tb.Columns[j].ColumnName.ToString() + ",";

                                        dat.Rows[i]["ERRORS_MESSAGE"] = dat.Rows[i]["ERRORS_MESSAGE"] + "Invalid DOC_EXPIRY_DATE Format, ";
                                    }

                                }



                            }
                            if ("DOC_ISSUING_PARTY_NAME" == Mandatory_tb.Columns[j].ColumnName.ToString())
                            {
                                if (Mandatory_tb.Rows[i][j].ToString().Length > 1)
                                {
                                    if (Mandatory_tb.Rows[i][j].ToString().Length > 70)
                                    {
                                        dat.Rows[i]["DATA_FILED"] = dat.Rows[i]["DATA_FILED"] + " " + Mandatory_tb.Columns[j].ColumnName.ToString() + ",";

                                        dat.Rows[i]["ERRORS_MESSAGE"] = dat.Rows[i]["ERRORS_MESSAGE"] + "DOC_ISSUING_PARTY_NAME MAX 70 Characters, ";
                                    }
                                }


                            }

                            if ("DOC_REF_NUMBER" == Mandatory_tb.Columns[j].ColumnName.ToString())
                            {
                                if (Mandatory_tb.Rows[i][j].ToString().Length > 1)
                                {
                                    if (Mandatory_tb.Rows[i][j].ToString().Length > 17)
                                    {
                                        dat.Rows[i]["DATA_FILED"] = dat.Rows[i]["DATA_FILED"] + " " + Mandatory_tb.Columns[j].ColumnName.ToString() + ",";

                                        dat.Rows[i]["ERRORS_MESSAGE"] = dat.Rows[i]["ERRORS_MESSAGE"] + "DOC_REF_NUMBER MAX 17 Characters, ";
                                    }
                                }


                            }
                            if ("DOC_ISSUING_PARTY_NAME_ADD1" == Mandatory_tb.Columns[j].ColumnName.ToString())
                            {
                                if (Mandatory_tb.Rows[i][j].ToString().Length > 1)
                                {
                                    if (Mandatory_tb.Rows[i][j].ToString().Length > 70)
                                    {
                                        dat.Rows[i]["DATA_FILED"] = dat.Rows[i]["DATA_FILED"] + " " + Mandatory_tb.Columns[j].ColumnName.ToString() + ",";

                                        dat.Rows[i]["ERRORS_MESSAGE"] = dat.Rows[i]["ERRORS_MESSAGE"] + "DOC_ISSUING_PARTY_NAME_ADD1 MAX 70 Characters, ";
                                    }
                                }


                            }

                            if ("DOC_ISSUING_PARTY_NAME_ADD2" == Mandatory_tb.Columns[j].ColumnName.ToString())
                            {
                                if (Mandatory_tb.Rows[i][j].ToString().Length > 1)
                                {
                                    if (Mandatory_tb.Rows[i][j].ToString().Length > 70)
                                    {
                                        dat.Rows[i]["DATA_FILED"] = dat.Rows[i]["DATA_FILED"] + " " + Mandatory_tb.Columns[j].ColumnName.ToString() + ",";

                                        dat.Rows[i]["ERRORS_MESSAGE"] = dat.Rows[i]["ERRORS_MESSAGE"] + "DOC_ISSUING_PARTY_NAME_ADD2 MAX 70 Characters, ";
                                    }
                                }


                            }
                            if ("DOC_ISSUING_PARTY_CITY" == Mandatory_tb.Columns[j].ColumnName.ToString())
                            {
                                if (Mandatory_tb.Rows[i][j].ToString().Length > 1)
                                {
                                    if (Mandatory_tb.Rows[i][j].ToString().Length > 35)
                                    {
                                        dat.Rows[i]["DATA_FILED"] = dat.Rows[i]["DATA_FILED"] + " " + Mandatory_tb.Columns[j].ColumnName.ToString() + ",";

                                        dat.Rows[i]["ERRORS_MESSAGE"] = dat.Rows[i]["ERRORS_MESSAGE"] + "DOC_ISSUING_PARTY_CITY MAX 35 Characters, ";
                                    }
                                }


                            }

                            if ("DOC_ISSUING_PARTY_PIN" == Mandatory_tb.Columns[j].ColumnName.ToString())
                            {
                                if (Mandatory_tb.Rows[i][j].ToString().Length > 1)
                                {
                                    if (Mandatory_tb.Rows[i][j].ToString().Length > 10)
                                    {
                                        dat.Rows[i]["DATA_FILED"] = dat.Rows[i]["DATA_FILED"] + " " + Mandatory_tb.Columns[j].ColumnName.ToString() + ",";

                                        dat.Rows[i]["ERRORS_MESSAGE"] = dat.Rows[i]["ERRORS_MESSAGE"] + "DOC_ISSUING_PARTY_PIN MAX 10 Characters, ";
                                    }
                                }


                            }
                            if ("PLACE_OF_ISSUE" == Mandatory_tb.Columns[j].ColumnName.ToString())
                            {
                                if (Mandatory_tb.Rows[i][j].ToString().Length > 1)
                                {
                                    if (Mandatory_tb.Rows[i][j].ToString().Length > 35)
                                    {
                                        dat.Rows[i]["DATA_FILED"] = dat.Rows[i]["DATA_FILED"] + " " + Mandatory_tb.Columns[j].ColumnName.ToString() + ",";

                                        dat.Rows[i]["ERRORS_MESSAGE"] = dat.Rows[i]["ERRORS_MESSAGE"] + "PLACE_OF_ISSUE MAX 35 Characters, ";
                                    }
                                }


                            }

                            if ("BENEFICIARY_PARTY_NAME" == Mandatory_tb.Columns[j].ColumnName.ToString())
                            {
                                if (Mandatory_tb.Rows[i][j].ToString().Length > 1)
                                {
                                    if (Mandatory_tb.Rows[i][j].ToString().Length > 70)
                                    {
                                        dat.Rows[i]["DATA_FILED"] = dat.Rows[i]["DATA_FILED"] + " " + Mandatory_tb.Columns[j].ColumnName.ToString() + ",";

                                        dat.Rows[i]["ERRORS_MESSAGE"] = dat.Rows[i]["ERRORS_MESSAGE"] + "BENEFICIARY_PARTY_NAME MAX 70 Characters, ";
                                    }
                                }


                            }
                            if ("BENEFICIARY_PARTY_ADD1" == Mandatory_tb.Columns[j].ColumnName.ToString())
                            {
                                if (Mandatory_tb.Rows[i][j].ToString().Length > 1)
                                {
                                    if (Mandatory_tb.Rows[i][j].ToString().Length > 70)
                                    {
                                        dat.Rows[i]["DATA_FILED"] = dat.Rows[i]["DATA_FILED"] + " " + Mandatory_tb.Columns[j].ColumnName.ToString() + ",";

                                        dat.Rows[i]["ERRORS_MESSAGE"] = dat.Rows[i]["ERRORS_MESSAGE"] + "BENEFICIARY_PARTY_ADD1 MAX 70 Characters, ";
                                    }
                                }


                            }
                            if ("BENEFICIARY_PARTY_ADD2" == Mandatory_tb.Columns[j].ColumnName.ToString())
                            {
                                if (Mandatory_tb.Rows[i][j].ToString().Length > 1)
                                {
                                    if (Mandatory_tb.Rows[i][j].ToString().Length > 70)
                                    {
                                        dat.Rows[i]["DATA_FILED"] = dat.Rows[i]["DATA_FILED"] + " " + Mandatory_tb.Columns[j].ColumnName.ToString() + ",";

                                        dat.Rows[i]["ERRORS_MESSAGE"] = dat.Rows[i]["ERRORS_MESSAGE"] + "BENEFICIARY_PARTY_ADD2 MAX 70 Characters, ";
                                    }
                                }


                            }
                            if ("BENEFICIARY_PARTY_CITY" == Mandatory_tb.Columns[j].ColumnName.ToString())
                            {
                                if (Mandatory_tb.Rows[i][j].ToString().Length > 1)
                                {
                                    if (Mandatory_tb.Rows[i][j].ToString().Length > 35)
                                    {
                                        dat.Rows[i]["DATA_FILED"] = dat.Rows[i]["DATA_FILED"] + " " + Mandatory_tb.Columns[j].ColumnName.ToString() + ",";

                                        dat.Rows[i]["ERRORS_MESSAGE"] = dat.Rows[i]["ERRORS_MESSAGE"] + "BENEFICIARY_PARTY_CITY MAX 35 Characters, ";
                                    }
                                }


                            }
                            if ("BENEFICIARY_PARTY_PIN" == Mandatory_tb.Columns[j].ColumnName.ToString())
                            {
                                if (Mandatory_tb.Rows[i][j].ToString().Length > 1)
                                {
                                    if (Mandatory_tb.Rows[i][j].ToString().Length > 10)
                                    {
                                        dat.Rows[i]["DATA_FILED"] = dat.Rows[i]["DATA_FILED"] + " " + Mandatory_tb.Columns[j].ColumnName.ToString() + ",";

                                        dat.Rows[i]["ERRORS_MESSAGE"] = dat.Rows[i]["ERRORS_MESSAGE"] + "BENEFICIARY_PARTY_PIN MAX 10 Characters, ";
                                    }
                                }


                            }
                            if ("ICEGATE_DOC_FILE_NAME" == Mandatory_tb.Columns[j].ColumnName.ToString())
                            {
                                if (Mandatory_tb.Rows[i][j].ToString().Length > 1)
                                {
                                    if (Mandatory_tb.Rows[i][j].ToString().Length > 35)
                                    {
                                        dat.Rows[i]["DATA_FILED"] = dat.Rows[i]["DATA_FILED"] + " " + Mandatory_tb.Columns[j].ColumnName.ToString() + ",";

                                        dat.Rows[i]["ERRORS_MESSAGE"] = dat.Rows[i]["ERRORS_MESSAGE"] + "ICEGATE_DOC_FILE_NAME MAX 35 Characters, ";
                                    }
                                }


                            }
                            if ("ICEGATE_ID" == Mandatory_tb.Columns[j].ColumnName.ToString())
                            {
                                if (Mandatory_tb.Rows[i][j].ToString().Length > 1)
                                {
                                    if (Mandatory_tb.Rows[i][j].ToString().Length > 17)
                                    {
                                        dat.Rows[i]["DATA_FILED"] = dat.Rows[i]["DATA_FILED"] + " " + Mandatory_tb.Columns[j].ColumnName.ToString() + ",";

                                        dat.Rows[i]["ERRORS_MESSAGE"] = dat.Rows[i]["ERRORS_MESSAGE"] + "ICEGATE_ID MAX 17 Characters, ";
                                    }
                                }


                            }
                        }
                    }
                }
                if (dat.Rows.Count > 0) // && dat.Rows[0][3].ToString() != "")
                {
                    DataView dtv = dat.DefaultView;
                    dtv.RowFilter = "CONVERT(DATA_FILED, System.String) IS NOT NULL";

                    ischk = false;
                    if (dtv.ToTable().Rows.Count > 0)
                    {
                        gv_Error.DataSource = dtv.ToTable();
                        gv_Error.DataBind();
                        gv_Error.Visible = true;
                        mainmastop2container_rght_tag2_txt1.InnerText = "Preview Data";
                        btn_Exp_Sup_Doc_Upload.Visible = false;
                    }
                    else
                    {
                        ischk = true;
                        gv_Error.Visible = false;
                        btn_Exp_Sup_Doc_Upload.Visible = true;
                        mainmastop2container_rght_tag2_txt1.InnerText = "No Error Message Found... You can Upload Your Data's Now.";
                    }
                    //gv_Preview.Visible = true;

                }
                else
                {

                   
                    gv_Error.Visible = false;
                    btn_Exp_Sup_Doc_Upload.Visible = true;
                    mainmastop2container_rght_tag2_txt1.InnerText = "No Error Message Found... You can Upload Your Data's Now.";
                    //gv_Preview.Visible = true;
                }
                //ischk = false;


            }
        
       // }
    
        return ischk;
    
    }

    public void Excel_Validation(DataTable selected)
    {
        if (dt_Avail.Rows.Count == 0)
        {
            DataTable dtShow = new DataTable();

            if (Check_Field() == true)
            {
                //ExcelUpload();
                DATA_CHECK(selected);
            }
        }
    }

    public void ExcelUpload()
    {
        
        if (VALID.Rows.Count == 0)
        {
            DataSet d = new DataSet();
            ObjUBO.JOBNO = IMPORT_JOBNO;
            //ObjUBO.INVOICE_SLNO = ddlInvoice_SlNo.SelectedItem.Text;
            //ObjUBO.ITEM_SLNO = ddl_ItemSlno.SelectedItem.Text;
            ObjUBO.flag = "Excel_Avail";
            ObjUBO.BRANCH_CODE = currentbranch;


            d = Sup_Doc.Imp_Sup_Doc_Xl_Upload(ObjUBO, SelecctedSUPPDOC());

            if (d.Tables[0].Rows.Count > 0)
            {
                MP_U1.Show();
            }
            else
            {
                DataSet dsXML = new DataSet();
                dsXML = (DataSet)ViewState["dss_Excel_upload"];
                if (dsXML.Tables[0].Rows.Count > 0)
                {

                    //MP_U1.Hide();
                    //if (gv_Error.Rows.Count == 0)
                    //{
                        ChangeColumnDataType(dsXML.Tables[0], "DOC_ISSUE_DATE", typeof(DateTime));
                        ChangeColumnDataType(dsXML.Tables[0], "DOC_EXPIRY_DATE", typeof(DateTime));
                        DataView dataView = dsXML.Tables[0].DefaultView;
                        DataTable dst = new DataTable();
                        dst = dataView.ToTable(true, "SW_ID", "JOBNO", "INVOICE_SLNO", "ITEM_SLNO", "DECLARATION_TYPE", "IMAGE_REF_NUMBER", "DOC_TYPE_CODE", "DOC_ISSUING_PARTY_CODE", "DOC_ISSUING_PARTY_NAME", "DOC_ISSUING_PARTY_NAME_ADD1", "DOC_ISSUING_PARTY_NAME_ADD2", "DOC_ISSUING_PARTY_CITY", "DOC_ISSUING_PARTY_PIN",
"DOC_REF_NUMBER", "PLACE_OF_ISSUE", "DOC_ISSUE_DATE", "DOC_EXPIRY_DATE", "BENEFICIARY_PARTY_CODE", "BENEFICIARY_PARTY_NAME", "BENEFICIARY_PARTY_ADDRESS1", "BENEFICIARY_PARTY_ADDRESS2", "BENEFICIARY_PARTY_CITY", "BENEFICIARY_PARTY_PIN", "FILE_TYPE", "USER_ID", "DATE_TIME", "BRANCH_CODE", "WORKING_PERIOD", "CREATEDON", "CREATEDBY", "MODIFIEDBY", "MODIFIEDON", "SELECT_TYPE", "ICEGATE_ID", "AMENDMENT_TYPE", "AMENDMENT_STATUS", "ICEGATE_DOC_FILE_NAME");

                        admin.SqlBulk_Upload_Product("BE_ITEM_SW_SUP_DOC", dst, Session["currentcomp_db"].ToString());
                        Alert_msg("Uploaded Successfully..");
                        gv_Error.Visible = false;
                        //fileuploadExcel.Dispose();
                        //fileuploadExcel.Attributes.Clear();
                        Label1.Text = "";
                        mainmastop2container_rght_tag2_txt1.InnerText = "Preview Data";
                        btn_Exp_Sup_Doc_Upload.Visible = false;
                    }
                //}
            }
        }
    }



    protected void gv_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }
    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;

            for (int i = 0; i < drv.DataView.Table.Columns.Count; i++)
            {
                if (e.Row.Cells[i].Text == "F")
                {
                    e.Row.Cells[i].BackColor = System.Drawing.Color.Red;
                    e.Row.Cells[i].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[i].Font.Bold = true;
                }

            }

        }
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

    public int Check_Avail_Sup_Doc(string UNIQUE_DOC_NUMBER)
    {
        DataSet dss = new DataSet();
        ObjUBO.JOBNO = IMPORT_JOBNO;
        ObjUBO.Unique_Document_No = UNIQUE_DOC_NUMBER;
        ObjUBO.flag = "Check_Avail";
        ObjUBO.WORKING_PERIOD = Working_Period;
        ObjUBO.BRANCH_CODE = currentbranch;

        DataTable TEMP1 = ds.Tables[0];
        dss = Sup_Doc.Imp_Sup_Doc_Xl_Upload(ObjUBO);
        i = Sup_Doc.result;

        return i;
    }

    public void DATA_CHECK(DataTable dsXML_Excel)
    {
        DataSet dck = new DataSet();



        ObjUBO.SW_STMT_ID = "";

        ObjUBO.flag = "Data_Check";
        ObjUBO.WORKING_PERIOD = Working_Period;

        dck = Sup_Doc.Imp_Sup_Doc_Xl_Upload(ObjUBO, dsXML_Excel);

        if (dck.Tables.Count == 2)
        {

            if (dck.Tables[1].Columns.Count > 4)
            {

                if (dck.Tables[1].Rows.Count > 0)
                {
                    VALID.Columns.Add("INVOICE_SLNO");
                    VALID.Columns.Add("ITEM_SLNO");
                    VALID.Columns.Add("DATAFILED");
                    //VALID.Columns.Add("DOC_TYPE_CODE");
                    VALID.Columns.Add("ERRORS_MESSAGE");

                    for (int i = 0; i <= dck.Tables[1].Rows.Count - 1; i++)
                    {

                        string Inv_SlNo = dck.Tables[1].Rows[i]["INVOICE_SLNO"].ToString();
                        string Itm_SlNo = dck.Tables[1].Rows[i]["ITEM_SLNO"].ToString();
                        string Irn_No = dck.Tables[1].Rows[i]["IMAGE_REF_NUMBER"].ToString();
                        //string DOC_TYPE_CODE = "";
                        string ERROR = "";
                        if (dck.Tables[1].Rows[i]["ERRORS_MESSAGE"].ToString() != "T")
                        {
                            ERROR = dck.Tables[1].Rows[i]["ERRORS_MESSAGE"].ToString();


                            VALID.Rows.Add(Inv_SlNo, Itm_SlNo, Irn_No, ERROR);
                        }

                    }
                    gv_Error.DataSource = VALID;
                    gv_Error.DataBind();
                    gv_Error.Visible = true;
                     mainmastop2container_rght_tag2_txt1.InnerText = "Preview Data";
                        btn_Exp_Sup_Doc_Upload.Visible = true;
                    
                    //gv_Error.Columns[2].Visible = false;
                    //gv_Error.Columns[3].Visible = false;
                }

                else
                {
                    gv_Error.Visible = false;
                    btn_Exp_Sup_Doc_Upload.Visible = true;
                    mainmastop2container_rght_tag2_txt1.InnerText = "No Error Message Found... You can Upload Your Data's Now.";
                }




            }
            else
            {
                if (dck.Tables[1].Rows.Count > 0)
                {
                    VALID.Columns.Add("INVOICE_SLNO");
                    VALID.Columns.Add("ITEM_SLNO");
                    //VALID.Columns.Add("Irn_No");
                    //VALID.Columns.Add("DOC_TYPE_CODE");
                    VALID.Columns.Add("ERRORS_MESSAGE");
                    for (int i = 0; i <= dck.Tables[1].Rows.Count - 1; i++)
                    {

                        string Inv_SlNo = dck.Tables[1].Rows[i]["INVOICE_SLNO"].ToString();
                        string Itm_SlNo = dck.Tables[1].Rows[i]["ITEM_SLNO"].ToString();
                        //string Irn_No = dck.Tables[1].Rows[i]["IRN_NO"].ToString();
                        //string DOC_TYPE_CODE = dck.Tables[1].Rows[i]["DOC_CODE"].ToString();
                        string ERROR = "";
                        if (dck.Tables[1].Rows[i]["ERRORS_MESSAGE"].ToString() != "T")
                        {
                            ERROR = dck.Tables[1].Rows[i]["ERRORS_MESSAGE"].ToString();

                            VALID.Rows.Add(Inv_SlNo, Itm_SlNo, ERROR);
                        }
                        else
                        {
                            //ERROR = dck.Tables[2].Rows[i]["ERROR"].ToString();
                            //INVALID.Rows.Add(Inv_SlNo, Itm_SlNo, Irn_No, DOC_TYPE_CODE, ERROR);

                        }



                    }

                    gv_Error.DataSource = VALID;
                    gv_Error.DataBind();
                    gv_Error.Visible = true;
                    mainmastop2container_rght_tag2_txt1.InnerText = "Preview Data";
                    btn_Exp_Sup_Doc_Upload.Visible = false;
                    
                }
                else
                {
                    gv_Error.Visible = false;
                    btn_Exp_Sup_Doc_Upload.Visible = true;
                    mainmastop2container_rght_tag2_txt1.InnerText = "No Error Message Found... You can Upload Your Data's Now.";
                }
            }

            //gv_Preview.Visible = true;
            //gv_Error.Visible = true;
        }
    }
    protected void gv_Error_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DataRowView drv = (DataRowView)e.Row.DataItem;

            for (int i = 0; i < drv.DataView.Table.Columns.Count; i++)
            {

                if (drv.DataView.Table.Columns[i].ColumnName.Equals("ERRORS_MESSAGE"))
                {

                    e.Row.Cells[i].ForeColor = System.Drawing.Color.Red;

                }

            }

        }

    }
    //protected void gv_Preview_RowCreated(object sender, GridViewRowEventArgs e)
    //{
    //    //Add CSS class on header row.
    //    if (e.Row.RowType == DataControlRowType.Header)
    //        e.Row.CssClass = "header";

    //    //Add CSS class on normal row.
    //    if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
    //        e.Row.CssClass = "normal";

    //    //Add CSS class on alternate row.
    //    if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
    //        e.Row.CssClass = "alternate";

    //}
    protected void gv_Error_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";

    }

    public static bool ChangeColumnDataType(DataTable table, string columnname, Type newtype)
    {
        if (table.Columns.Contains(columnname) == false)
            return false;

        DataColumn column = table.Columns[columnname];
        if (column.DataType == newtype)
            return true;

        try
        {
            DataColumn newcolumn = new DataColumn("temporary", newtype);
            table.Columns.Add(newcolumn);
            foreach (DataRow row in table.Rows)
            {
                try
                {
                    row["temporary"] = Convert.ChangeType(row[columnname], newtype);
                    row["temporary"] = row[columnname].ToString();
                }
                catch
                {
                }
            }
            table.Columns.Remove(columnname);
            newcolumn.ColumnName = columnname;
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }
    //protected void gv_Preview_RowDataBound(object sender, GridViewRowEventArgs e)
    //{

    //    //if ((e.Row.RowType == DataControlRowType.Header))
    //    //{

    //    //    // For first column set to 200 px

    //    //    // For others set to 50 px
    //    //    // You can set all the width individually
    //    //    TableCell cell;
    //    //    for (i = 1; (i <= (e.Row.Cells.Count - 1)); i++)
    //    //    {
    //    //        // Mind that i used i=1 not 0 because the width of cells(0) has already been set
    //    //        TableCell cell2 = e.Row.Cells[i];



    //    //            cell2.Width = new Unit("280px");


    //    //        //gv_Preview.RowStyle.BorderStyle = BorderStyle.Solid;
    //    //    }

    //    //}
    //} 
    //public void Dropdown_bind()
    //{
    //    Transact.JOBNO = IMPORT_JOBNO;
    //    Transact.WORKING_PERIOD = SELECT_BRANCH;
    //    Transact.flag = "INVOICE_NO";
    //    dsssrno = Transact.RetrieveAll_Invoice_Details();
    //    ddlInvoice_SlNo.DataSource = dsssrno.Tables[0];
    //    ddlInvoice_SlNo.DataTextField = "INVOICE_SLNO";
    //    ddlInvoice_SlNo.DataValueField = "INVOICE_SLNO";
    //    ddlInvoice_SlNo.Items.Add("");
    //    ddlInvoice_SlNo.DataBind();

    //}
    //public void Bind_ItemSl_No()
    //{
    //    if (ddlInvoice_SlNo.SelectedValue != "")
    //    {
    //        Transact.JOBNO = IMPORT_JOBNO;
    //        Transact.WORKING_PERIOD = SELECT_BRANCH;
    //        Transact.INVOICE_SLNO = ddlInvoice_SlNo.SelectedItem.Text;
    //        Transact.Ename = "Item_Sl_No_Select";
    //        dsssrno = Transact.RetrieveAll_Item_Details();
    //        ddl_ItemSlno.DataSource = dsssrno.Tables[0];
    //        ddl_ItemSlno.DataTextField = "ITEM_SLNO";
    //        ddl_ItemSlno.DataValueField = "ITEM_SLNO_ID";
    //        ddl_ItemSlno.Items.Add("");
    //        ddl_ItemSlno.DataBind();


    //    }
    //}
    //protected void ddlInvoice_SlNo_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Bind_ItemSl_No();

    //}
}
