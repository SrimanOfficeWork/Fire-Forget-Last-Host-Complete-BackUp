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


public partial class Import_Bulk_License_Master_Upoad : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    eroyalmaster erm = new eroyalmaster();
    adminmaster adm = new adminmaster();
    DataTable dt = new DataTable();
    Export_Licence Export_license = new Export_Licence();
    AdminMasterDetails admin = new AdminMasterDetails();
    public int i;
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, EXPORT_JOBNO;
    public int License_id_Max, License_id_IMP_EXP_Max;

    DataSet ds = new DataSet();
    DataSet dsXML = new DataSet();
    DataTable dt_Avail = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet ds_scheme = new DataSet();


    public string errorFolder = "", logFileName="";
    
    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Import_License_master_Excel");
        
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'License Master Excel Upload', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'License Master Excel Upload', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Get_LICENSE_IMP_EXP_MaxID()
    {
        erm.LICENSE_ID = "";
        erm.LICENSE_NO = "0";
        erm.Ename = "Auto_ID";
        erm.EWorking_Period = Working_Period;

        ds = erm.RetrieveAll_IMPORT_LICENSE_MASTER();
        if (ds.Tables[0].Rows.Count > 0)
        {
            License_id_Max = Convert.ToInt32(ds.Tables[0].Rows[0]["LICENSE_ID"].ToString());
        }
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

    protected void btn_Import_BulkUpload_Click(object sender, EventArgs e)
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

                Directory.CreateDirectory(errorFolder);
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

    public void Excel_Upload_load(string file_ext)
    {
        Get_LICENSE_IMP_EXP_MaxID();
        DataSet Inv_ds = new DataSet();
        //ds.Tables.Add("Invoice_dt");
        Inv_ds = ds = (DataSet)ViewState["ds_Excel_upload"];
        int a = 0, b = 0, c = 1;
        ds.Tables[0].Rows.Add();
        if (ds.Tables[0].Rows.Count > a)
        {
            #region create dataset column
            dsXML.Tables.Add("IMPORT_LICENSE_MASTER");
            dsXML.Tables[0].Columns.Add("LICENSE_ID");
            dsXML.Tables[0].Columns.Add("REGISTRATION_NO");
            dsXML.Tables[0].Columns.Add("REGISTRATION_DATE");

            dsXML.Tables[0].Columns.Add("LICENSE_NO");
            // dsXML.Tables[0].Columns.Add("INVOICE_DATE", typeof(DateTime));
            dsXML.Tables[0].Columns.Add("LICENSE_DATE");

            dsXML.Tables[0].Columns.Add("EXCEMPTION");
            dsXML.Tables[0].Columns.Add("LICENSE_TYPE");
            dsXML.Tables[0].Columns.Add("TOTAL_DEBIT_AMT");
            dsXML.Tables[0].Columns.Add("REMAINING_AMT");
            dsXML.Tables[0].Columns.Add("TOTAL_DEBIT_QTY");
            dsXML.Tables[0].Columns.Add("UNIT_QTY");
            dsXML.Tables[0].Columns.Add("LICENSE_ITEM_NO");
            dsXML.Tables[0].Columns.Add("PORT_OF_LICENSE");

            dsXML.Tables[0].Columns.Add("USER_ID");
            dsXML.Tables[0].Columns.Add("DATE_TIME");
            dsXML.Tables[0].Columns.Add("STATUS");
            dsXML.Tables[0].Columns.Add("BRANCH_CODE");
            dsXML.Tables[0].Columns.Add("YEAR");
            dsXML.Tables[0].Columns.Add("WORKING_PERIOD");
            dsXML.Tables[0].Columns.Add("MODIFIEDBY");
            dsXML.Tables[0].Columns.Add("MODIFIEDON");

            dsXML.Tables[0].Columns.Add("REMAINING_QTY");
            dsXML.Tables[0].Columns.Add("PARTY_NAME");
            dsXML.Tables[0].Columns.Add("LICENSE_DESC");
            dsXML.Tables[0].Columns.Add("SINGLE_DUTY_Y_N");
            dsXML.Tables[0].Columns.Add("TOTAL_FC_VALUE");
            dsXML.Tables[0].Columns.Add("REMAINING_FC");
            dsXML.Tables[0].Columns.Add("EX_RATE");
            dsXML.Tables[0].Columns.Add("TOTAL_CIF_VALUE");
            dsXML.Tables[0].Columns.Add("REMAINING_CIF");
            dsXML.Tables[0].Columns.Add("LICENSE_CURRENCY");


            dsXML.Tables[0].Columns.Add("LICENSE_BROKER_NAME");
            dsXML.Tables[0].Columns.Add("LICENSE_TRANSFERED_TO");
            dsXML.Tables[0].Columns.Add("LICENSE_RECEIVED_DATE");
     
            dsXML.Tables[0].Columns.Add("BOND_NO");
            dsXML.Tables[0].Columns.Add("BOND_DATE");
            dsXML.Tables[0].Columns.Add("BOND_TYPE");
            dsXML.Tables[0].Columns.Add("DATE_OF_SURRENDER");
            dsXML.Tables[0].Columns.Add("PART_NO");
            dsXML.Tables[0].Columns.Add("LICENSE_EXPIRY_DATE");
            dsXML.Tables[0].Columns.Add("BOND_LOCATION");

           
            //--------------------License Details--------------------------//

            //dt_Avail.Tables.Add("IMPORT_LICENSE_MASTER");
            dt_Avail.Columns.Add("REGISTRATION_NO");
            dt_Avail.Columns.Add("LICENSE_ITEM_NO");
            dt_Avail.Columns.Add("LICENSE_TYPE");
           
            
            #endregion
            //--------------------End License Details--------------------------//
            if (file_ext == ".xls" || file_ext == ".xlsx")
            {
                #region read Excel_Format
                
                while (ds.Tables[0].Rows[a][0] != System.DBNull.Value)
                {
                    i = Check_Avail_License(ds.Tables[0].Rows[a][0].ToString().TrimEnd(), ds.Tables[0].Rows[a][3].ToString());

                    if (i == 1)
                    {
                        DataRow dr = dsXML.Tables[0].NewRow();

                        dr["LICENSE_ID"] = License_id_Max;
                        dr["REGISTRATION_NO"] = ds.Tables[0].Rows[a][0].ToString().TrimEnd();
                        dr["REGISTRATION_DATE"] = ds.Tables[0].Rows[a][1].ToString().TrimEnd();
                        dr["LICENSE_NO"] = ds.Tables[0].Rows[a][14].ToString().TrimEnd();
                       // dr["LICENSE_DATE"] = ds.Tables[0].Rows[a][15].ToString().TrimEnd();

                        dr["LICENSE_DATE"] = string.IsNullOrWhiteSpace(ds.Tables[0].Rows[a][15].ToString().Trim())
                             ? "1900-01-01 00:00:00.000"
                             : ds.Tables[0].Rows[a][15].ToString().Trim();

                        dr["EXCEMPTION"] = "Y";
                        dr["LICENSE_TYPE"] = ds.Tables[0].Rows[a][2].ToString().TrimEnd();
                        dr["TOTAL_DEBIT_AMT"] = ds.Tables[0].Rows[a][7].ToString();
                        dr["REMAINING_AMT"] = "";
                        dr["TOTAL_DEBIT_QTY"] = ds.Tables[0].Rows[a][8].ToString();
                        dr["UNIT_QTY"] = ds.Tables[0].Rows[a][4].ToString();
                        dr["LICENSE_ITEM_NO"] = ds.Tables[0].Rows[a][3].ToString();
                        dr["PORT_OF_LICENSE"] = ds.Tables[0].Rows[a][5].ToString();

                        dr["USER_ID"] = currentuser;
                        dr["DATE_TIME"] = LoginDate;
                        dr["STATUS"] = "N";
                        dr["BRANCH_CODE"] = currentbranch;
                        dr["YEAR"] = "";
                        dr["WORKING_PERIOD"] = Working_Period;
                        dr["MODIFIEDBY"] = currentuser;
                        dr["MODIFIEDON"] = LoginDate;


                        dr["REMAINING_QTY"] = "";
                        dr["PARTY_NAME"] = ds.Tables[0].Rows[a][12].ToString();
                        dr["LICENSE_DESC"] = ds.Tables[0].Rows[a][13].ToString();
                        dr["SINGLE_DUTY_Y_N"] = "N";
                        dr["TOTAL_FC_VALUE"] = ds.Tables[0].Rows[a][9].ToString();
                        dr["REMAINING_FC"] = "";
                        dr["EX_RATE"] = ds.Tables[0].Rows[a][11].ToString();
                        dr["TOTAL_CIF_VALUE"] = ds.Tables[0].Rows[a][6].ToString();
                        dr["REMAINING_CIF"] = "";
                        dr["LICENSE_CURRENCY"] = ds.Tables[0].Rows[a][10].ToString();


                        dr["LICENSE_BROKER_NAME"] = ds.Tables[0].Rows[a][16].ToString();
                        dr["LICENSE_TRANSFERED_TO"] = ds.Tables[0].Rows[a][17].ToString();
                        dr["LICENSE_RECEIVED_DATE"] = ds.Tables[0].Rows[a][18].ToString();



                        dr["BOND_NO"] = ds.Tables[0].Rows[a][19].ToString();
                        dr["BOND_DATE"] = ds.Tables[0].Rows[a][20].ToString();
                        dr["BOND_TYPE"] = ds.Tables[0].Rows[a][21].ToString();
                        dr["DATE_OF_SURRENDER"] = ds.Tables[0].Rows[a][22].ToString();
                        dr["PART_NO"] = ds.Tables[0].Rows[a][23].ToString();
                        dr["LICENSE_EXPIRY_DATE"] = ds.Tables[0].Rows[a][24].ToString();
                        dr["BOND_LOCATION"] = ds.Tables[0].Rows[a][25].ToString();


                        dsXML.Tables[0].Rows.Add(dr);
                    }
                    else
                    {
                        dt_Avail.Rows.Add(ds.Tables[0].Rows[a][0].ToString().TrimEnd(), ds.Tables[0].Rows[a][3].ToString(), ds.Tables[0].Rows[a][2].ToString().TrimEnd());
                    }

                    a++;

                    //a = b;
                    License_id_Max++;
                }
                #endregion

                //dt = dsXML.Tables["Export_License_Details"];
                //DataTable  dtt = dsXML.Tables["Export_License_IMP_EXP_Details"];
                //dt=  RemoveDuplicateRows(dt, "LICENSE_NO","INV_SL_NO","ITEM_SL_NO");

                if (dt_Avail.Rows.Count == 0)
                {
                    if (dsXML.Tables[0].Rows.Count > 0)
                    {
                        admin.SqlBulk_Upload_Product("IMPORT_LICENSE_MASTER", dsXML.Tables[0], Session["currentcomp_db"].ToString());
                        Alert_msg("Uploaded Successfully..");
                    }
                }
                else
                {
                    string msg = "    License Details Already Available" + Environment.NewLine + " -------------------------------------------------------" + Environment.NewLine + "   License No  " + "         " + "Lic Item No" + Environment.NewLine + Environment.NewLine;
                    for (int j = 0; j <= dt_Avail.Rows.Count - 1; j++)
                    {
                        msg += dt_Avail.Rows[j][0].ToString() + "              " + dt_Avail.Rows[j][1].ToString() + "  "+ Environment.NewLine;
                    }

                    //msg = " Inv no : " + dss.Tables[0].Rows[s][38].ToString() + "  -  Already Exists";
                    hdinvno.Value = msg;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Avail_InvoiceNo_Alert_Msg()", true);     
                }
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

    public int Check_Avail_License(string License_No, string ItemNo)
    {
        DataSet dss = new DataSet();
        erm.LICENSE_ID = ItemNo;
        erm.LICENSE_NO = License_No;
        erm.Ename = "Check_Avail";
        erm.EWorking_Period = Working_Period;

        dss = erm.RetrieveAll_IMPORT_LICENSE_MASTER();
       i = erm.result;
       
        return i;
    }
    
}
