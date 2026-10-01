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
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using System.Globalization;
using BussinessObject;



public partial class Import_SuppDoc_Excel : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    Supporting_Document Sup_Doc_Mas = new Supporting_Document();
    AdminMasterDetails admin = new AdminMasterDetails();
    UserBO objUserBL = new UserBO();
    DataSet dss = new DataSet();
    DataTable selected;
    DateTime parsed;
  
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
    public int Master_sup_id_Max;
    public string DOC_ISSUING_PARTY_NAME, DOC_ISSUING_PARTY_NAME_ADD1, DOC_ISSUING_PARTY_NAME_ADD2, DOC_ISSUING_PARTY_CITY, DOC_ISSUING_PARTY_PIN;

    DataSet ds = new DataSet();
    DataTable dtt = new DataTable();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    string file_ext = "";
    DataSet dsXML = new DataSet();
    DataTable dt_Avail = new DataTable();
    Import_XL_Upload IXL = new Import_XL_Upload();
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

        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Sup_Doc_master_Excel");
        
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

    public void Get_Sup_Doc_MAster_MaxID()
    {
        objUserBL.flag = "autoid";
        objUserBL.WORKING_PERIOD = Working_Period;

        ds = Sup_Doc_Mas.SUP_DOC_MASTER_XL_UPD(objUserBL);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Master_sup_id_Max = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());
        }
    }
    protected void btn_Sup_Doc_ExlUpload_Click(object sender, EventArgs e)
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
            string query = "SELECT * FROM [Sheet1$] ";


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
    public void Excel_Upload_load(string file_ext)
    {
        Get_Sup_Doc_MAster_MaxID();
        DataSet Sup_ds = new DataSet();

        Sup_ds = ds = (DataSet)ViewState["ds_Excel_upload"];
        int a = 0;
        ds.Tables[0].Rows.Add();
        #region create dataset column
        dsXML.Tables.Add("SUPPORTING_DOCUMENTS");
        dsXML.Tables[0].Columns.Add("ID");
        dsXML.Tables[0].Columns.Add("IMP_EXP");
        dsXML.Tables[0].Columns.Add("ICEGATE_ID");
        dsXML.Tables[0].Columns.Add("DOC_APPLICABLE_FOR");
        dsXML.Tables[0].Columns.Add("IMAGE_REF_NO");
        dsXML.Tables[0].Columns.Add("DOC_UPLOAD_DATE_TIME");
        dsXML.Tables[0].Columns.Add("DOC_TYPE");
        dsXML.Tables[0].Columns.Add("FILE_TYPE");
        dsXML.Tables[0].Columns.Add("ICEGATE_FILE_NAME");
        dsXML.Tables[0].Columns.Add("ISSUED_AT");
        dsXML.Tables[0].Columns.Add("DOC_NAME");
        dsXML.Tables[0].Columns.Add("ISSUED_ON");
        dsXML.Tables[0].Columns.Add("REFERENCE_NO");
        dsXML.Tables[0].Columns.Add("EXPIRY_DATE");        
        dsXML.Tables[0].Columns.Add("ISSUING_PARTY_NAME");
        dsXML.Tables[0].Columns.Add("ISSUING_PARTY_CODE");
        dsXML.Tables[0].Columns.Add("ISSUING_PARTY_ADD_1");
        dsXML.Tables[0].Columns.Add("ISSUING_PARTY_ADD_2");
        dsXML.Tables[0].Columns.Add("ISSUING_PARTY_CITY");
        dsXML.Tables[0].Columns.Add("ISSUING_PARTY_PIN_CODE");
        dsXML.Tables[0].Columns.Add("BENEFICIARY_PARTY_NAME");
        dsXML.Tables[0].Columns.Add("BENEFICIARY_PARTY_CODE");
        dsXML.Tables[0].Columns.Add("BENEFICIARY_PARTY_ADD_1");
        dsXML.Tables[0].Columns.Add("BENEFICIARY_PARTY_ADD_2");
        dsXML.Tables[0].Columns.Add("BENEFICIARY_PARTY_CITY");
        dsXML.Tables[0].Columns.Add("BENEFICIARY_PARTY_PIN_CODE");
        dsXML.Tables[0].Columns.Add("BRANCH_CODE");
        dsXML.Tables[0].Columns.Add("WORKINGPERIOD");
        dsXML.Tables[0].Columns.Add("CREATEDON");
        dsXML.Tables[0].Columns.Add("CREATEDBY");
        dsXML.Tables[0].Columns.Add("MODIFIEDBY");
        dsXML.Tables[0].Columns.Add("MODIFIEDON");
            #endregion
            //--------------------End Sup Master Details--------------------------//
            if (file_ext == ".xls" || file_ext == ".xlsx")
            {
                #region read Excel_Format

                while (ds.Tables[0].Rows[a][0] != System.DBNull.Value)
                {

                    DataRow dr = dsXML.Tables[0].NewRow();

                    dr["ID"] = Master_sup_id_Max;
                    dr["IMP_EXP"] = ds.Tables[0].Rows[a][0].ToString();
                    dr["ICEGATE_ID"] = ds.Tables[0].Rows[a][1].ToString().TrimEnd();
                    dr["DOC_APPLICABLE_FOR"] = "MJ";
                    dr["IMAGE_REF_NO"] = ds.Tables[0].Rows[a][2].ToString();
                    dr["DOC_UPLOAD_DATE_TIME"] = DateTime.Parse(LoginDate == "" ? "01/01/1900" : LoginDate, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                    dr["DOC_TYPE"] = ds.Tables[0].Rows[a][3].ToString().Split('-')[0];
                    dr["FILE_TYPE"] = "PDF";
                    dr["ICEGATE_FILE_NAME"] = ds.Tables[0].Rows[a][18].ToString();
                    dr["ISSUED_AT"] = ds.Tables[0].Rows[a][5].ToString();
                    dr["DOC_NAME"] = ds.Tables[0].Rows[a][19].ToString();
                    dr["ISSUED_ON"] = DateTime.Parse(ds.Tables[0].Rows[a][6].ToString() == "" ? "01/01/1900" : ds.Tables[0].Rows[a][6].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                    dr["REFERENCE_NO"] = ds.Tables[0].Rows[a][4].ToString();
                    dr["EXPIRY_DATE"] = DateTime.Parse(ds.Tables[0].Rows[a][7].ToString() == "" ? "01/01/1900" : ds.Tables[0].Rows[a][7].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                    if (dr["IMP_EXP"].ToString() == "I")
                    {
                        dr["ISSUING_PARTY_NAME"] = ds.Tables[0].Rows[a][8].ToString();
                        //dr["ISSUING_PARTY_CODE"] = ds.Tables[0].Rows[a][0].ToString();
                        dr["ISSUING_PARTY_ADD_1"] = ds.Tables[0].Rows[a][9].ToString();
                        dr["ISSUING_PARTY_ADD_2"] = ds.Tables[0].Rows[a][10].ToString();
                        dr["ISSUING_PARTY_CITY"] = ds.Tables[0].Rows[a][11].ToString();
                        dr["ISSUING_PARTY_PIN_CODE"] = ds.Tables[0].Rows[a][12].ToString();
                        dr["BENEFICIARY_PARTY_NAME"] = ds.Tables[0].Rows[a][13].ToString();
                        //dr["BENEFICIARY_PARTY_CODE"] = ds.Tables[0].Rows[a][0].ToString();
                        dr["BENEFICIARY_PARTY_ADD_1"] = ds.Tables[0].Rows[a][14].ToString();
                        dr["BENEFICIARY_PARTY_ADD_2"] = ds.Tables[0].Rows[a][15].ToString();
                        dr["BENEFICIARY_PARTY_CITY"] = ds.Tables[0].Rows[a][16].ToString();
                        dr["BENEFICIARY_PARTY_PIN_CODE"] = ds.Tables[0].Rows[a][17].ToString();
                    }
                    else 
                    {
                        dr["BENEFICIARY_PARTY_NAME"] = ds.Tables[0].Rows[a][8].ToString();
                        //dr["BENEFICIARY_PARTY_CODE"] = ds.Tables[0].Rows[a][0].ToString();
                        dr["BENEFICIARY_PARTY_ADD_1"] = ds.Tables[0].Rows[a][9].ToString();
                        dr["BENEFICIARY_PARTY_ADD_2"] = ds.Tables[0].Rows[a][10].ToString();
                        dr["BENEFICIARY_PARTY_CITY"] = ds.Tables[0].Rows[a][11].ToString();
                        dr["BENEFICIARY_PARTY_PIN_CODE"] = ds.Tables[0].Rows[a][12].ToString();
                        dr["ISSUING_PARTY_NAME"] = ds.Tables[0].Rows[a][13].ToString();
                        //dr["ISSUING_PARTY_CODE"] = ds.Tables[0].Rows[a][0].ToString();
                        dr["ISSUING_PARTY_ADD_1"] = ds.Tables[0].Rows[a][14].ToString();
                        dr["ISSUING_PARTY_ADD_2"] = ds.Tables[0].Rows[a][15].ToString();
                        dr["ISSUING_PARTY_CITY"] = ds.Tables[0].Rows[a][16].ToString();
                        dr["ISSUING_PARTY_PIN_CODE"] = ds.Tables[0].Rows[a][17].ToString();
                    }
                    dr["BRANCH_CODE"] = currentbranch;
                    dr["WORKINGPERIOD"] = Working_Period;
                    dr["CREATEDON"] = DateTime.Parse(LoginDate == "" ? "01/01/1900" : LoginDate, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                    dr["CREATEDBY"] = currentuser;
                    dr["MODIFIEDBY"] = currentuser;
                    dr["MODIFIEDON"] = DateTime.Parse(LoginDate == "" ? "01/01/1900" : LoginDate, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

                    dsXML.Tables[0].Rows.Add(dr);

                    a++;
                  
                    Master_sup_id_Max++;
                }
                #endregion
                
                System.Data.DataView view = new System.Data.DataView(dsXML.Tables[0]);
                System.Data.DataTable selected = view.ToTable("Selected", false, "ICEGATE_ID", "IMAGE_REF_NO", "REFERENCE_NO", "ISSUING_PARTY_NAME", "ISSUING_PARTY_ADD_1", "ISSUING_PARTY_ADD_2", "BENEFICIARY_PARTY_NAME", "BENEFICIARY_PARTY_ADD_1", "BENEFICIARY_PARTY_ADD_2");
                objUserBL.Xml_D = ConvertDataTableToXML(selected);
                objUserBL.flag = "Duplicate_Chk";
                dss = Sup_Doc_Mas.SUP_DOC_MASTER_XL_UPD(objUserBL);

                if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                {
                    if (dss.Tables[0].Rows[0][0].ToString() == "Check_Length")
                    {
                        Alert_msg("Check the Length of Column Value");
                    }
                    else if (dss.Tables[0].Rows[0][0].ToString() == "Duplicate_Irn_record")
                    {
                        Alert_msg("Check the Duplicate Irn");
                    }
                    
                }
                else
                {
                    admin.SqlBulk_Upload_Product("SUPPORTING_DOCUMENTS", dsXML.Tables[0], Session["currentcomp_db"].ToString());
                    Alert_msg("Excel Uploaded Successfully.");
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
}
