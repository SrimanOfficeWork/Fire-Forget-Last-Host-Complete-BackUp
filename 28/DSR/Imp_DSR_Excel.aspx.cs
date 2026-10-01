using System;
using System.IO;
using System.Data;
using System.Text;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using BussinessObject;
using System.Collections.Generic; 

public partial class Imp_DSR_Excel : ThemeClass
{
    AppSession aps = new AppSession();

    DSR_CS DSR = new DSR_CS();
    Global_variables ObjUBO = new Global_variables();

    public string currentuser, COMPANY_IDD, error = "", currentbranch, errorFolder = "", logFileName = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Connection.Current_User();
        currentbranch = Connection.Current_Branch();
        COMPANY_IDD = Connection.COMPANYID();

       errorFolder = Server.MapPath("~/Submission/" + COMPANY_IDD + "/" + currentbranch + "/" + currentuser + "/" + "Import_DSR_Excel");
    }
    protected void btn_upload_Click(object sender, EventArgs e)
    {
        try
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
                    DirectoryInfo dir = new DirectoryInfo(errorFolder);
                    dir.Create();
                    foreach (FileInfo fi in dir.GetFiles())
                    {
                        fi.Delete();
                    }
                    Get_ExcelFile();
                }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public void Get_ExcelFile()
    {
        DataSet ds = new DataSet();
        string connString = "",picExtension, fileName2;
        string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
        string path = errorFolder + "\\" + fileuploadExcel.FileName;

        if (fileuploadExcel.HasFile)
        {
            picExtension = fnGetPictureExtn(fileuploadExcel.FileName);
            fileName2 = fileuploadExcel.FileName;
            addtoGallery1(fileName2, errorFolder, "NORMAL");
        }

        if (strFileType.Trim() == ".xls")
        {
            connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
        }
        else if (strFileType.Trim() == ".xlsx")
        {
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text\"";
        }
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

            DataRow firstRow = dtt.Rows[0];
            for (int i = 0; i < dtt.Columns.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(firstRow[i].ToString())) // handle empty cell
                    dtt.Columns[i].ColumnName = firstRow[i].ToString().Trim();
            }
            dtt.Rows.RemoveAt(0);
            //-----------------------------------------------------------------------------------------------------------------------------

            da.Dispose();
            conn.Close();
            conn.Dispose();
        }
        dtt.Rows.Add();
        dtt = dtt.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull)).CopyToDataTable();
        //----------------------SriramS------------------
        DataSet dds = new DataSet();
        if (dtt.Rows.Count > 0)
        {
            DataSet dss = new DataSet();
            dss.Tables.Add(dtt);
            //----------------------------------------------
            dtt.Columns[0].ColumnName = "SLNO";
            dtt.Columns[1].ColumnName = "WEEK_WISE_ARRIVAL";
            dtt.Columns[2].ColumnName = "JOBNO";
            dtt.Columns[3].ColumnName = "COPY_DOCS_RECD_ON";
            dtt.Columns[4].ColumnName = "ORG_DOCS_RECD_ON";
            dtt.Columns[5].ColumnName = "FREIGHT_INV_RECD_ON";
            dtt.Columns[6].ColumnName = "FORWARDER";
            dtt.Columns[7].ColumnName = "AGENT";
            dtt.Columns[8].ColumnName = "NO_OF_CNTRS";
            dtt.Columns[9].ColumnName = "TWENTY_FEET";

            dtt.Columns[10].ColumnName = "FORTY_FEET";
            dtt.Columns[11].ColumnName = "LCL";
            dtt.Columns[12].ColumnName = "AIR";
            dtt.Columns[13].ColumnName = "B_B";
            dtt.Columns[14].ColumnName = "BL_NO";
            dtt.Columns[15].ColumnName = "LICENCE_MERIT";
            dtt.Columns[16].ColumnName = "PART_INVOICE_A_V";
            dtt.Columns[17].ColumnName = "PLACE_OF_DELIVERY";
            dtt.Columns[18].ColumnName = "ARRIVAL";
            dtt.Columns[19].ColumnName = "CHECK_LIST_SENT_DATE";

            dtt.Columns[20].ColumnName = "REMARKS";
            dtt.Columns[21].ColumnName = "CFS_NAME";
            dtt.Columns[22].ColumnName = "CFS_PORT";
            dtt.Columns[23].ColumnName = "DCR_INVOICE_A_V";
            dtt.Columns[24].ColumnName = "FTA_COPY_RECD";
            dtt.Columns[25].ColumnName = "FTA_ORG_RECD";
            dtt.Columns[26].ColumnName = "REVISION_IN_ETA";
            dtt.Columns[27].ColumnName = "IGM_PLAN";
            dtt.Columns[28].ColumnName = "IGM_ACTUAL";
            dtt.Columns[29].ColumnName = "DESTUFF";

            dtt.Columns[30].ColumnName = "BE_FILED_ON";
            dtt.Columns[31].ColumnName = "BE_ASS_ON";
            dtt.Columns[32].ColumnName = "RMS_OPEN";
            dtt.Columns[33].ColumnName = "DUTY_ADVICED_ON";
            dtt.Columns[34].ColumnName = "DUTY_RECEIVED";
            dtt.Columns[35].ColumnName = "DUTY_AMOUNT";
            dtt.Columns[36].ColumnName = "DUTY_PAID_ON";
            dtt.Columns[37].ColumnName = "DUTY_INTEREST";
            dtt.Columns[38].ColumnName = "PENTALY_AMOUNT";
            dtt.Columns[39].ColumnName = "EXAMINATION";

            dtt.Columns[40].ColumnName = "CNTR_MOVED_ON";
            dtt.Columns[41].ColumnName = "DO_RECD_ON";
            dtt.Columns[42].ColumnName = "CLEARED_ON";
            dtt.Columns[43].ColumnName = "DELIVERY_DATE";
            dtt.Columns[44].ColumnName = "CLEARANCE_MODE";
            dtt.Columns[45].ColumnName = "END_OF_FREE_DAYS";
            dtt.Columns[46].ColumnName = "TRANS_DOCS_HANDOVER";
            dtt.Columns[47].ColumnName = "REMARKS_CURRENT_ST";
            dtt.Columns[48].ColumnName = "REASON_FOR_DELAY";
            dtt.Columns[49].ColumnName = "BOND_NO";

            dtt.Columns[50].ColumnName = "BOND_LOCATION";
            dtt.Columns[51].ColumnName = "BOND_TYPE";
            dtt.Columns[52].ColumnName = "EDD_PAID_ON";
            dtt.Columns[53].ColumnName = "BOE_SENT_BY";
            dtt.Columns[54].ColumnName = "BOE_SENT_ON";
            dtt.Columns[55].ColumnName = "SERVICE_BILL_NUMBER";
            dtt.Columns[56].ColumnName = "SERVICE_BILL_DATE";
            dtt.Columns[57].ColumnName = "SERVICE_BILL_SENT_ON";
            dtt.Columns[58].ColumnName = "CHECKLIST_CONF_RECD";
            dtt.Columns[59].ColumnName = "CBM";
            
            dtt.Columns[60].ColumnName = "BOE_MONTH";
            dtt.Columns[61].ColumnName = "BOE_YEAR";
            dtt.Columns[62].ColumnName = "TYPE_OF_CLEARANCE";
            dtt.Columns[63].ColumnName = "MNRE_RECD_DATE";
            dtt.Columns[64].ColumnName = "CFS_CHARGES";
            dtt.Columns[65].ColumnName = "SERVICE_CHARGES";
            dtt.Columns[66].ColumnName = "OTHER_CHARGES";
            dtt.Columns[67].ColumnName = "REIMBURSEMENT_B_NO";
            dtt.Columns[68].ColumnName = "STREAMER_AGENT_CHARGE";
            dtt.Columns[69].ColumnName = "REIMBURSEMENT_CHARGE";

            dtt.Columns[70].ColumnName = "TOTAL_BILL_AMOUNT";
            dtt.Columns[71].ColumnName = "TRANS_SHIPMENT_PORT";
            dtt.Columns[72].ColumnName = "FREE_DAYS_VALIDITY";
            dtt.Columns[73].ColumnName = "FEEDER_VESSEL";
            dtt.Columns[74].ColumnName = "TRANSPORTATION_CHARGE";
            dtt.Columns[75].ColumnName = "RE_IMBURSE";
            dtt.Columns[76].ColumnName = "TRANSPORT_BILL_NO";
            dtt.Columns[77].ColumnName = "DUTY_BILL_NO";
            dtt.Columns[78].ColumnName = "DUTY_BILL_DATE";
            dtt.Columns[79].ColumnName = "DUTY_BILL_AMOUNT";

            dtt.Columns[80].ColumnName = "ETA_TO_CLR";
            dtt.Columns[81].ColumnName = "TR6_CHALLAN_NO";
            dtt.Columns[82].ColumnName = "TR6_CHALLAN_DATE";
            dtt.Columns[83].ColumnName = "TR6_CHALLAN_AMOUNT";
            dtt.Columns[84].ColumnName = "RE_BOND_DEBIT_AMOUNT";

            dtt.AcceptChanges();
            Session["DSR_Excel_upload"] = dtt;

            if (dtt.Rows.Count > 0)
            {
                btnUpload.Visible = true;
            }
            //---------------------------------------------------------------------------------------------------------------------------------------------
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
            }
            else
            {
                fileuploadExcel.SaveAs(strImagePath);
            }
        }
        catch
        {
        }
        finally
        {
        }
    }
    protected void btnSaveProduct_Click(object sender, EventArgs e)
    {
        try
        {

            DataTable dt_DSR = new DataTable();
            DataSet ds = new DataSet();

            dt_DSR = (DataTable)HttpContext.Current.Session["DSR_Excel_upload"];

            if (dt_DSR != null)
            {
                ObjUBO.A1 = ConvertDataTableToXML(dt_DSR);
                ObjUBO.A2 = "Gen_Excel_Upload";
                ds = DSR.XLUpload(ObjUBO);
                HttpContext.Current.Session.Remove("DSR_Excel_upload");

                Alert_msg("XL Upload Successfully.");
                /*
                if (ds.Tables[0].Rows.Count > 0)
                {
                   Alert_msg("XL Upload Successfully.");
                }
                else
                {
                   Alert_msg("XL Not Upload !");
                }
                */
            }
            else
            {
                Alert_msg("Re Upload XL !");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Import DSR', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}