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


public partial class ReImport_Excel_Upload : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    DataTable dt = new DataTable();
    AdminMasterDetails admin = new AdminMasterDetails();
    Transaction RE_IMP = new Transaction();
    Re_Import_XL_Upload RE_IMP_OBJ = new Re_Import_XL_Upload();
    DataTable VALID = new DataTable();
    DataTable selected;

    public int i;
    public string currentuser;
    public string currentbranch;
    public string Working_Period;
    public string LoginDate;
    //public string SELECT_BRANCH;
    public int Re_Imp_id_Max;
    public string IMPORT_JOBNO, INVOICE_SLNO, INVOICE_NO, ITEM_SLNO;

    DataSet ds = new DataSet();
    DataSet dsXML = new DataSet();
    DataTable dt_Avail = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet ds_scheme = new DataSet();

    string file_ext = "";
    public string errorFolder = "", logFileName = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        //SELECT_BRANCH = Connection.Get_Company_Type();
        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "RE_IMPORT_XL_UPLOAD");
        if (Session["IMPORT_JOBNO"] != null)
        {
            IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
            INVOICE_SLNO = Session["INVOICE_SLNO"].ToString();
            INVOICE_NO = Session["INVOICE_NO"].ToString();
            ITEM_SLNO = Session["ITEM_SLNO"].ToString();
        }

    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Re Import Excel Upload', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Re Import Excel Upload', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Get_Sup_Doc_MaxID()
    {
        RE_IMP.RE_IMPORT_ID = "";
        RE_IMP.SB_NO = "0";
        RE_IMP.flag = "autoid";
        RE_IMP.WORKING_PERIOD = Working_Period;

        ds = RE_IMP_OBJ.Re_Import_XL(RE_IMP);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Re_Imp_id_Max = Convert.ToInt32(ds.Tables[0].Rows[0]["RE_IMPORT_ID"].ToString());
        }
    }



    public string Get_ExcelFile()
    {
        string connString = "";
        string strFileType = Path.GetExtension(fileuploadExcel.FileName).ToLower();
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

        if (ds.Tables.Count > 0)
        {
            ViewState["ds_Excel_upload"] = ds;
        }
        else
        {
            Alert_msg("Upload valid file");
            strFileType = "Empty";
        }


        return strFileType.Trim();
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


    protected void btn_Re_Imp_Xl_Upload(object sender, EventArgs e)
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
            
            if (ViewState["File_Exten"].ToString() != "Empty")
            {
                DataSet d = new DataSet();
                RE_IMP.JOBNO = IMPORT_JOBNO;
                RE_IMP.flag = "Excel_Avail";
                //RE_IMP.BRANCH_CODE = SELECT_BRANCH;
                RE_IMP.BRANCH_CODE = Connection.Current_Branch();

                d = RE_IMP_OBJ.Re_Import_XL(RE_IMP);
               
                if (d.Tables[0].Rows.Count > 0)
                {
                    MP_U.Show();
                }
                else
                {
                    Excel_Upload_load(file_ext);
                }
            }
            else
            {
                Alert_msg("Error");
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }


    protected void btnyes_Click(object sender, EventArgs e)
    {
        DataSet d = new DataSet();
        RE_IMP.JOBNO = IMPORT_JOBNO;
        RE_IMP.flag = "Delete_Excel";
        //RE_IMP.BRANCH_CODE = SELECT_BRANCH;
        RE_IMP.BRANCH_CODE = Connection.Current_Branch();
        d = RE_IMP_OBJ.Re_Import_XL(RE_IMP);

        if (d.Tables[0].Rows.Count > 0)
        {
            Alert_msg("Not deleted ur Old Sup Doc");
        }
        else
        {
            //Alert_msg("deleted ur Old Sup Doc Successfully");
            MP_U.Hide();
            Excel_Upload_load(ViewState["File_Exten"].ToString());
        }
    }


    public void Excel_Upload_load(string file_ext)
    {
        try
        {
            Get_Sup_Doc_MaxID();
            DataSet dss = new DataSet();
            DataSet Inv_ds = new DataSet();

            ds.Tables.Add("Invoice_dt");
            Inv_ds = ds = (DataSet)ViewState["ds_Excel_upload"];

            int a = 0, b = 1, c = 1;
            ds.Tables[0].Rows.Add();
            if (ds.Tables[0].Rows.Count > a)
            {
                #region create dataset column
                dsXML.Tables.Add("RE_IMP_XL_UPLOAD");
                dsXML.Tables[0].Columns.Add("RE_IMPORT_ID");
                dsXML.Tables[0].Columns.Add("RE_IMPORT_SLNO");
                dsXML.Tables[0].Columns.Add("JOBNO");
                dsXML.Tables[0].Columns.Add("INVOICE_SLNO");
                dsXML.Tables[0].Columns.Add("INVOICE_NO");
                dsXML.Tables[0].Columns.Add("ITEM_SLNO");

                dsXML.Tables[0].Columns.Add("SB_NO");
                dsXML.Tables[0].Columns.Add("SB_DATE");
                dsXML.Tables[0].Columns.Add("PORT_EXPORT");
                dsXML.Tables[0].Columns.Add("SB_INVOICE_NO");
                dsXML.Tables[0].Columns.Add("SB_INVOICE__ITEM_NO");
                dsXML.Tables[0].Columns.Add("NOTN_NO");
                dsXML.Tables[0].Columns.Add("NOTN_SLNO");
                dsXML.Tables[0].Columns.Add("EXPORT_FREIGHT");
                dsXML.Tables[0].Columns.Add("EXPORT_INSURANCE");
                dsXML.Tables[0].Columns.Add("CUSTOMS_DUTY");
                dsXML.Tables[0].Columns.Add("EXCISE_DUTY");
                dsXML.Tables[0].Columns.Add("USER_ID");
                dsXML.Tables[0].Columns.Add("DATE_TIME");
                dsXML.Tables[0].Columns.Add("STATUS");
                dsXML.Tables[0].Columns.Add("BRANCH_CODE");
                dsXML.Tables[0].Columns.Add("YEAR");
                dsXML.Tables[0].Columns.Add("WORKING_PERIOD");
                dsXML.Tables[0].Columns.Add("MODIFIEDBY");
                dsXML.Tables[0].Columns.Add("MODIFIEDON");
                #endregion

                dt_Avail.Columns.Add("INVOICE_SLNO");
                dt_Avail.Columns.Add("ITEM_SLNO");
                dt_Avail.Columns.Add("SB_NO");
                //--------------------End Sup doc Details--------------------------//
                if (file_ext == ".xls" || file_ext == ".xlsx")
                {
                    #region read Excel_Format

                    while (ds.Tables[0].Rows[a][0] != System.DBNull.Value)
                    {

                        i = Check_Avail_Sup_Doc(ds.Tables[0].Rows[a][2].ToString().Trim());
                        dss = (DataSet)ViewState["dss"];

                        if (i == 1)
                        {
                            DataRow dr = dsXML.Tables[0].NewRow();

                            dr["RE_IMPORT_ID"] = Re_Imp_id_Max;
                            dr["RE_IMPORT_SLNO"] = b;
                            dr["JOBNO"] = IMPORT_JOBNO;
                            //string ts =Convert.ToString( Convert.ToInt32(ds.Tables[0].Rows[a][0].ToString().Trim()));
                            int ts = Convert.ToInt32(ds.Tables[0].Rows[a][0].ToString().Trim());

                            //int tsS = Convert.ToInt32(dss.Tables[1].Rows[a][1].ToString().Trim());

                            if (dss.Tables[1].Rows.Count > 0)
                            {
                                var query = from t in dss.Tables[1].AsEnumerable()
                                            where t.Field<Int64>("INVOICE_SLNO").Equals(Convert.ToInt64(ds.Tables[0].Rows[a][0].ToString().Trim()))
                                            select t;
                                if (query.Count() > 0)
                                {
                                    DataTable dddd = query.CopyToDataTable();
                                    dr["INVOICE_NO"] = dddd.Rows[0]["INVOICE_NO"].ToString();
                                }
                                else
                                {
                                    dr["INVOICE_NO"] = "";
                                }
                            }

                            dr["INVOICE_SLNO"] = ds.Tables[0].Rows[a][0].ToString().Trim();
                            dr["ITEM_SLNO"] = ds.Tables[0].Rows[a][1].ToString().Trim();
                            dr["SB_NO"] = ds.Tables[0].Rows[a][2].ToString().Trim();
                            if (ds.Tables[0].Rows[a][3] != System.DBNull.Value)
                            {
                                DateTime s1 = System.Convert.ToDateTime(ds.Tables[0].Rows[a][3].ToString().Trim());
                                DateTime date = (s1);
                                String frmdt = date.ToString("dd/MM/yyyy");
                                String.Format("{0:MM/dd/yyyy}", dt);

                                dr["SB_DATE"] = frmdt.ToString();
                            }
                            //dr["SB_DATE"] = ds.Tables[0].Rows[a][3].ToString().Trim();
                            dr["SB_INVOICE_NO"] = ds.Tables[0].Rows[a][4].ToString().Trim();
                            dr["SB_INVOICE__ITEM_NO"] = ds.Tables[0].Rows[a][5].ToString().Trim();
                            dr["PORT_EXPORT"] = ds.Tables[0].Rows[a][6].ToString().Trim();
                            dr["NOTN_NO"] = ds.Tables[0].Rows[a][7].ToString().Trim();
                            dr["NOTN_SLNO"] = ds.Tables[0].Rows[a][8].ToString().Trim();
                            dr["EXPORT_FREIGHT"] = ds.Tables[0].Rows[a][9].ToString().Trim();
                            dr["EXPORT_INSURANCE"] = ds.Tables[0].Rows[a][10].ToString().Trim();
                            dr["CUSTOMS_DUTY"] = ds.Tables[0].Rows[a][11].ToString().Trim();
                            dr["EXCISE_DUTY"] = ds.Tables[0].Rows[a][12].ToString().Trim();
                            //dr["BRANCH_CODE"] = SELECT_BRANCH;
                            dr["BRANCH_CODE"] = Connection.Current_Branch();
                            dr["WORKING_PERIOD"] = Working_Period;
                            dr["DATE_TIME"] = LoginDate;
                            dr["STATUS"] = "N";
                            dr["YEAR"] = "";
                            dr["USER_ID"] = currentuser;
                            dr["DATE_TIME"] = LoginDate;
                            dr["MODIFIEDBY"] = currentuser;
                            dr["MODIFIEDON"] = LoginDate;


                            dsXML.Tables[0].Rows.Add(dr);

                            System.Data.DataView view = new System.Data.DataView(dsXML.Tables[0]);
                            selected = view.ToTable("Selected", false, "INVOICE_SLNO", "ITEM_SLNO", "SB_NO", "SB_DATE", "SB_INVOICE_NO", "SB_INVOICE__ITEM_NO", "PORT_EXPORT", "NOTN_NO", "NOTN_SLNO", "EXPORT_FREIGHT", "EXPORT_INSURANCE", "CUSTOMS_DUTY", "EXCISE_DUTY");
                        }
                        else
                        {
                            dt_Avail.Rows.Add(ds.Tables[0].Rows[a][0].ToString().Trim(), ds.Tables[0].Rows[a][1].ToString(), ds.Tables[0].Rows[a][2].ToString().Trim());
                        }

                        a++;
                        b++;

                        //a = b;
                        Re_Imp_id_Max++;
                        //String xmlData = ConvertDataTableToXML(dsXML.Tables[0]);
                    }


                    #endregion

                    if (dt_Avail.Rows.Count == 0)
                    {
                        DataTable dtShow = new DataTable();
                        DATA_CHECK(selected);

                        if (VALID.Rows.Count == 0)
                        {
                            if (dsXML.Tables[0].Rows.Count > 0)
                            {
                                //MP_U1.Hide();

                                admin.SqlBulk_Upload_Product("RE_IMPORT_DETAILS", dsXML.Tables[0], Session["currentcomp_db"].ToString());
                                Alert_msg("Uploaded Successfully..");
                            }
                        }
                        else
                        {
                            MP_U1.Show();
                            //string msg = "    IRN No Already Available" + Environment.NewLine + " -------------------------------------------------------" + Environment.NewLine + "   Inv No  " + "         " + "IRN No" + Environment.NewLine + Environment.NewLine;
                            //for (int j = 0; j <= dt_Avail.Rows.Count - 1; j++)
                            //{
                            //    msg += dt_Avail.Rows[j][0].ToString() + "              " + dt_Avail.Rows[j][2].ToString() + "  " + Environment.NewLine;
                            //}

                            ////msg = " Inv no : " + dss.Tables[0].Rows[s][38].ToString() + "  -  Already Exists";
                            //hdinvno.Value = msg;
                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Avail_InvoiceNo_Alert_Msg()", true);
                        }
                    }
                }
                //}
            }
        }
        catch (Exception ex)
        {
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

    public int Check_Avail_Sup_Doc(string SB_NO)
    {
        DataSet dss = new DataSet();
        RE_IMP.JOBNO = IMPORT_JOBNO;
        RE_IMP.SB_NO = SB_NO;
        RE_IMP.flag = "Check_Avail";
        RE_IMP.WORKING_PERIOD = Working_Period;
        RE_IMP.BRANCH_CODE = Connection.Get_Company_Type();
        RE_IMP.BRANCH_COMMON = Connection.Get_Company_Type();

        DataTable TEMP1 = ds.Tables[0];
        dss = RE_IMP_OBJ.Re_Import_XL(RE_IMP);
        ViewState["dss"] = dss;
        i = RE_IMP_OBJ.result;

        return i;
    }

    public void DATA_CHECK(DataTable dsXML_Excel)
    {
        DataSet dck = new DataSet();
   
        RE_IMP.RE_IMPORT_ID = ConvertDataTableToXML(dsXML.Tables[0]);
        RE_IMP.flag = "Data_Check";
        RE_IMP.WORKING_PERIOD = Working_Period;
        dck = RE_IMP_OBJ.Re_Import_XL(RE_IMP);

        if (dck.Tables[1].Columns.Count > 3)
        {
            if (dck.Tables[1].Rows.Count > 0)
            {
                VALID.Columns.Add("Inv_SlNo");
                VALID.Columns.Add("Itm_SlNo");
                VALID.Columns.Add("SB_NO");
                VALID.Columns.Add("ERROR");
                for (int i = 0; i <= dck.Tables[1].Rows.Count - 1; i++)
                {

                    string Inv_SlNo = dck.Tables[1].Rows[i]["INVOICE_SLNO"].ToString();
                    string Itm_SlNo = dck.Tables[1].Rows[i]["ITEM_SLNO"].ToString();
                    string SB_NO = dck.Tables[1].Rows[i]["SB_NO"].ToString();
                    string ERROR = "";
                    if (dck.Tables[1].Rows[i]["ERROR"].ToString() != "T")
                    {
                        ERROR = dck.Tables[1].Rows[i]["ERROR"].ToString();

                        VALID.Rows.Add(Inv_SlNo, Itm_SlNo, SB_NO,ERROR);
                    }
                    else
                    {
                        //ERROR = dck.Tables[2].Rows[i]["ERROR"].ToString();
                        //INVALID.Rows.Add(Inv_SlNo, Itm_SlNo, Irn_No, DOC_TYPE_CODE, ERROR);
                    }
                }
            }

        }
        else
        {
            if (dck.Tables[1].Rows.Count > 0)
            {
                VALID.Columns.Add("Inv_SlNo");
                VALID.Columns.Add("Itm_SlNo");

                VALID.Columns.Add("ERROR");
                for (int i = 0; i <= dck.Tables[1].Rows.Count - 1; i++)
                {

                    string Inv_SlNo = dck.Tables[1].Rows[i]["INVOICE_SLNO"].ToString();
                    string Itm_SlNo = dck.Tables[1].Rows[i]["ITEM_SLNO"].ToString();

                    string ERROR = "";
                    if (dck.Tables[1].Rows[i]["ERROR"].ToString() != "T")
                    {
                        ERROR = dck.Tables[1].Rows[i]["ERROR"].ToString();

                        VALID.Rows.Add(Inv_SlNo, Itm_SlNo, ERROR);
                    }
                }
            }
        }
        gv_Preview.DataSource = VALID;
        gv_Preview.DataBind();
        gv_Preview.Attributes.Add("Width", "100%");
    }
}
