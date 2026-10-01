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
using BussinessObject;
using System.Globalization;

public partial class IGM_Excel_Upload : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    DataTable dt = new DataTable();
    AdminMasterDetails admin = new AdminMasterDetails();
    UserBO objUserBL = new UserBO();
    IMP_IGM_EXCEl IGM_EXCEl = new IMP_IGM_EXCEl();
    // Import_IGM_XL_Upload IMP_IGM_OBJ = new Import_IGM_XL_Upload();
    DataTable VALID = new DataTable();
    DataTable selected;

    public int i;
    public string currentuser;
    public string currentbranch;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_BRANCH;
    public int Imp_Igm_id_Max;
    public string IMPORT_JOBNO, INVOICE_SLNO, INVOICE_NO, ITEM_SLNO, IMPORT_JOBDATE;

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
        SELECT_BRANCH = Connection.Get_Company_Type();
        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "RE_IMPORT_XL_UPLOAD");
        if (Session["IMPORT_JOBNO"] != null || Session["IMPORT_JOBDATE"] != null)
        {
            IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
            IMPORT_JOBDATE = Session["IMPORT_JOBDATE"].ToString();
            //INVOICE_SLNO = Session["INVOICE_SLNO"].ToString();
            //INVOICE_NO = Session["INVOICE_NO"].ToString();
            //ITEM_SLNO = Session["ITEM_SLNO"].ToString();
        }

    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Import Igm Excel Upload', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Igm Excel Upload', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Get_Igm_MaxID()
    {
        IGM_EXCEl.IGM_ID = "";
        IGM_EXCEl.IGM_NO = "0";
        IGM_EXCEl.flag = "autoid";
        IGM_EXCEl.WORKING_PERIOD = Working_Period;

        ds = IGM_EXCEl.IMP_IGM_EXCEl_upload();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Imp_Igm_id_Max = Convert.ToInt32(ds.Tables[0].Rows[0]["IGM_ID"].ToString());
        }
    }

   /* public void Gridview()
    {
        IGM_EXCEl.JOBNO = IMPORT_JOBNO;
        IGM_EXCEl.flag = "Select_con";
        IGM_EXCEl.IGM_ID = Imp_Igm_id_Max.ToString();
        IGM_EXCEl.BRANCH_CODE = SELECT_BRANCH;

        ds = IGM_EXCEl.IMP_IGM_EXCEl_upload();
       
    }*/


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


    protected void btn_Imp_igm_Xl_Upload(object sender, EventArgs e)
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
                IGM_EXCEl.JOBNO = IMPORT_JOBNO;
                //IGM_EXCEl.flag = "Excel_Avail";
                IGM_EXCEl.flag = "Check_Avail";
                IGM_EXCEl.BRANCH_CODE = SELECT_BRANCH;

                d = IGM_EXCEl.IMP_IGM_EXCEl_upload();

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
        IGM_EXCEl.JOBNO = IMPORT_JOBNO;
       // IGM_EXCEl.IGM_ID = Imp_Igm_id_Max.ToString();
        IGM_EXCEl.flag = "Delete_Excel";
        IGM_EXCEl.BRANCH_CODE = SELECT_BRANCH;
        d = IGM_EXCEl.IMP_IGM_EXCEl_upload();

        if (d.Tables[0].Rows.Count > 0)
        {
            Alert_msg("Not deleted ur Old Excel");
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
            Get_Igm_MaxID();
            DataSet dss = new DataSet();
            DataSet Inv_ds = new DataSet();

            //ds.Tables.Add("Invoice_dt");
            Inv_ds = ds = (DataSet)ViewState["ds_Excel_upload"];

            int a = 0, b = 1, c = 1;
            ds.Tables[0].Rows.Add();
            if (ds.Tables[0].Rows.Count > a)
            {
                #region create dataset column
                dsXML.Tables.Add("IGM_XL_UPLOAD");
                dsXML.Tables[0].Columns.Add("IGM_ID");
                dsXML.Tables[0].Columns.Add("IGM_SLNO");
                dsXML.Tables[0].Columns.Add("JOBNO");
                dsXML.Tables[0].Columns.Add("IGM_JOBDATE");
                dsXML.Tables[0].Columns.Add("IGM_AIRLINECODE");
                dsXML.Tables[0].Columns.Add("IGM_AIRLINENAME");
                dsXML.Tables[0].Columns.Add("IGM_FLIGHTNO_VESSELNO");
                dsXML.Tables[0].Columns.Add("IGM_FLIGHT_VESSELDATE");
                dsXML.Tables[0].Columns.Add("IGM_NO");
                dsXML.Tables[0].Columns.Add("IGM_DATE");
                dsXML.Tables[0].Columns.Add("IGM_MAWB_MBL");
                dsXML.Tables[0].Columns.Add("IGM_MAWB_MBLDATE");
                dsXML.Tables[0].Columns.Add("IGM_HAWB_HBLNO");
                dsXML.Tables[0].Columns.Add("IGM_HAWB_HBLDATE");
                dsXML.Tables[0].Columns.Add("IGM_NOOFPACKAGE");
                dsXML.Tables[0].Columns.Add("IGM_PACKAGETYPE");
                dsXML.Tables[0].Columns.Add("IGM_GROSSWEIGHT");
                dsXML.Tables[0].Columns.Add("IGM_TYPEOFWEIGHT");
                dsXML.Tables[0].Columns.Add("IGM_NETWEIGHT");
                dsXML.Tables[0].Columns.Add("IGM_NETWEIGHTTYPE");
                dsXML.Tables[0].Columns.Add("IGM_TRANSPORTMODE");
                dsXML.Tables[0].Columns.Add("IGM_MARKSNOS");
                dsXML.Tables[0].Columns.Add("IGM_GATEWAY_IGM_NO");
                dsXML.Tables[0].Columns.Add("IGM_GATEWAY_IGM_DATE");
                dsXML.Tables[0].Columns.Add("IGM_GATEWAY_PORT_CODE");
                dsXML.Tables[0].Columns.Add("IGM_USER_ID");
                dsXML.Tables[0].Columns.Add("IGM_DATE_TIME");
                dsXML.Tables[0].Columns.Add("IGM_STATUS");
                dsXML.Tables[0].Columns.Add("IGM_BRANCH_CODE");
                dsXML.Tables[0].Columns.Add("YEAR");
                dsXML.Tables[0].Columns.Add("IGM_WORKING_PERIOD");
                dsXML.Tables[0].Columns.Add("MODIFIEDBY");
                dsXML.Tables[0].Columns.Add("MODIFIEDON");
                dsXML.Tables[0].Columns.Add("IGM_LINE_NUMBER");
                dsXML.Tables[0].Columns.Add("IGM_SHIPPING_LINE_NUMBER");
                dsXML.Tables[0].Columns.Add("IGM_VOYAGE");
                dsXML.Tables[0].Columns.Add("IGM_CHARGEABLE_WGT");
                dsXML.Tables[0].Columns.Add("ROTATION_NO");
                dsXML.Tables[0].Columns.Add("ROTATION_DATE");
                dsXML.Tables[0].Columns.Add("AMENDMENT_TYPE");
                dsXML.Tables[0].Columns.Add("AMENDMENT_STATUS");


                #endregion

                dt_Avail.Columns.Add("IGM_MAWB_MBL");
                dt_Avail.Columns.Add("IGM_HAWB_HBLNO");
                dt_Avail.Columns.Add("IGM_NO");
                //--------------------End Sup doc Details--------------------------//
                if (file_ext == ".xls" || file_ext == ".xlsx")
                {
                    #region read Excel_Format

                    while (ds.Tables[0].Rows[a][0] != System.DBNull.Value)
                    {

                        //i = Check_Avail_Sup_Doc(ds.Tables[0].Rows[a][2].ToString().Trim());
                        //dss = (DataSet)ViewState["dss"];

                        i = 1;

                        if (i == 1)
                        {
                            DataRow dr = dsXML.Tables[0].NewRow();

                            dr["IGM_ID"] = Imp_Igm_id_Max;
                            dr["IGM_SLNO"] = b;
                            dr["JOBNO"] = IMPORT_JOBNO;
                            dr["IGM_JOBDATE"] = IMPORT_JOBDATE;
                            dr["IGM_AIRLINECODE"] = "";
                            dr["IGM_AIRLINENAME"] = "";

                            //if (dss.Tables[0].Rows.Count > 0)
                            //{
                            //    var query = from t in dss.Tables[0].AsEnumerable()
                            //                where t.Field<Int64>("IGM_MAWB_MBL").Equals(Convert.ToInt64(ds.Tables[0].Rows[a][0].ToString().Trim()))
                            //                select t;
                            //    if (query.Count() > 0)
                            //    {
                            //        DataTable dddd = query.CopyToDataTable();
                            //        dr["IGM_NO"] = dddd.Rows[0]["IGM_NO"].ToString();
                            //    }
                            //    else
                            //    {
                            //        dr["IGM_NO"] = "";
                            //    }
                            //}

                            dr["IGM_FLIGHTNO_VESSELNO"] = ds.Tables[0].Rows[a][0].ToString().Trim();
                            dr["IGM_FLIGHT_VESSELDATE"] = ds.Tables[0].Rows[a][1].ToString() == string.Empty ? "01/01/1900" : ds.Tables[0].Rows[a][1].ToString();
                            //dr["IGM_FLIGHT_VESSELDATE"] = "12/12/2022";
                            //if (ds.Tables[0].Rows[a][1] != System.DBNull.Value)
                            //{
                            //    DateTime s1 = System.Convert.ToDateTime(ds.Tables[0].Rows[a][3].ToString().Trim());
                            //    DateTime date = (s1);
                            //    String frmdt = date.ToString("dd/MM/yyyy");
                            //    String.Format("{0:MM/dd/yyyy}", dt);

                            //    dr["IGM_FLIGHT_VESSELDATE"] = frmdt.ToString();
                            //}
                            //dr["SB_DATE"] = ds.Tables[0].Rows[a][3].ToString().Trim();
                            dr["IGM_NO"] = ds.Tables[0].Rows[a][2].ToString().Trim();
                            //if (ds.Tables[0].Rows[a][3] != System.DBNull.Value)
                            //{
                            //    DateTime s1 = System.Convert.ToDateTime(ds.Tables[0].Rows[a][3].ToString().Trim());
                            //    DateTime date = (s1);
                            //    String frmdt = date.ToString("dd/MM/yyyy");
                            //    String.Format("{0:MM/dd/yyyy}", dt);

                            //    dr["IGM_DATE"] = frmdt.ToString();
                            //}
                            //dr["SB_DATE"] = ds.Tables[0].Rows[a][3].ToString().Trim();
                            dr["IGM_DATE"] = ds.Tables[0].Rows[a][3].ToString() == string.Empty ? "01/01/1900" : ds.Tables[0].Rows[a][3].ToString(); 
                            //(dr["IGM_DATE"] == "" ? "01/01/1900" : ds.Tables[0].Rows[a][3].ToString());
                            dr["IGM_MAWB_MBL"] = ds.Tables[0].Rows[a][4].ToString().Trim();
                            //if (ds.Tables[0].Rows[a][5] != System.DBNull.Value)
                            //{
                            //    DateTime s1 = System.Convert.ToDateTime(ds.Tables[0].Rows[a][5].ToString().Trim());
                            //    DateTime date = (s1);
                            //    String frmdt = date.ToString("dd/MM/yyyy");
                            //    String.Format("{0:MM/dd/yyyy}", dt);

                            //    dr["IGM_MAWB_MBLDATE"] = frmdt.ToString();
                            //}
                            dr["IGM_MAWB_MBLDATE"] = ds.Tables[0].Rows[a][5].ToString() == string.Empty ? "01/01/1900" : ds.Tables[0].Rows[a][5].ToString();
                            dr["IGM_HAWB_HBLNO"] = ds.Tables[0].Rows[a][6].ToString().Trim();
                            //if (ds.Tables[0].Rows[a][7] != System.DBNull.Value)
                            //{
                            //    DateTime s1 = System.Convert.ToDateTime(ds.Tables[0].Rows[a][7].ToString().Trim());
                            //    DateTime date = (s1);
                            //    String frmdt = date.ToString("dd/MM/yyyy");
                            //    String.Format("{0:MM/dd/yyyy}", dt);

                            //    dr["IGM_HAWB_HBLDATE"] = frmdt.ToString();
                            //}
                            dr["IGM_HAWB_HBLDATE"] = ds.Tables[0].Rows[a][7].ToString() == string.Empty ? "01/01/1900" : ds.Tables[0].Rows[a][7].ToString();
                            dr["IGM_NOOFPACKAGE"] = ds.Tables[0].Rows[a][8].ToString().Trim();
                            dr["IGM_PACKAGETYPE"] = ds.Tables[0].Rows[a][9].ToString().Trim();
                            dr["IGM_GROSSWEIGHT"] = ds.Tables[0].Rows[a][10].ToString().Trim();
                            dr["IGM_TYPEOFWEIGHT"] = ds.Tables[0].Rows[a][11].ToString().Trim();
                            dr["IGM_NETWEIGHT"] = "0.00";
                            dr["IGM_NETWEIGHTTYPE"] = "";
                            dr["IGM_TRANSPORTMODE"] = Session["TRANSPORT_MODE"].ToString();
                            dr["IGM_MARKSNOS"] = ds.Tables[0].Rows[a][12].ToString().Trim();
                            dr["IGM_GATEWAY_IGM_NO"] = ds.Tables[0].Rows[a][13].ToString().Trim();
                            //if (ds.Tables[0].Rows[a][13] != System.DBNull.Value)
                            //{
                            //    DateTime s1 = System.Convert.ToDateTime(ds.Tables[0].Rows[a][14].ToString().Trim());
                            //    DateTime date = (s1);
                            //    String frmdt = date.ToString("dd/MM/yyyy");
                            //    String.Format("{0:MM/dd/yyyy}", dt);

                            //    dr["IGM_GATEWAY_IGM_DATE"] = frmdt.ToString();
                            //}
                            dr["IGM_GATEWAY_IGM_DATE"] = ds.Tables[0].Rows[a][14].ToString() == string.Empty ? "01/01/1900" : ds.Tables[0].Rows[a][14].ToString();
                            dr["IGM_GATEWAY_PORT_CODE"] = ds.Tables[0].Rows[a][15].ToString().Trim();
                            dr["IGM_USER_ID"] = currentuser;
                            dr["IGM_DATE_TIME"] = LoginDate;
                            dr["IGM_STATUS"] = "N";
                            dr["IGM_BRANCH_CODE"] = Connection.Current_Branch();
                            dr["YEAR"] = "";
                            dr["IGM_WORKING_PERIOD"] = Working_Period;
                            dr["MODIFIEDBY"] = currentuser;
                            dr["MODIFIEDON"] = LoginDate;
                            dr["IGM_LINE_NUMBER"] = ds.Tables[0].Rows[a][16].ToString().Trim();
                            dr["IGM_SHIPPING_LINE_NUMBER"] = ds.Tables[0].Rows[a][17].ToString().Trim();
                            dr["IGM_VOYAGE"] = ds.Tables[0].Rows[a][18].ToString().Trim();
                            dr["IGM_CHARGEABLE_WGT"] = "";
                            dr["ROTATION_NO"] = "";
                            dr["ROTATION_DATE"] = "01/01/1900";
                            dr["AMENDMENT_TYPE"] = "";
                            dr["AMENDMENT_STATUS"] = "";

                            //dr["IGM_DATE_TIME"] = LoginDate;





                            dsXML.Tables[0].Rows.Add(dr);
                           
                           
                        }
                        else
                        {
                            dt_Avail.Rows.Add(ds.Tables[0].Rows[a][0].ToString().Trim(), ds.Tables[0].Rows[a][1].ToString(), ds.Tables[0].Rows[a][2].ToString().Trim());
                        }

                       
                        //String xmlData = ConvertDataTableToXML(dsXML.Tables[0]);
                        a++;
                        b++;

                        //a = b;
                        Imp_Igm_id_Max++;

                    }
                    //System.Data.DataView view = new System.Data.DataView(dsXML.Tables[0]);
                    //System.Data.DataTable selected = view.ToTable("Selected", false, "IGM_FLIGHTNO_VESSELNO", "IGM_FLIGHT_VESSELDATE", "IGM_NO", "IGM_DATE", "IGM_MAWB_MBL", "IGM_MAWB_MBLDATE", "IGM_HAWB_HBLNO", "IGM_HAWB_HBLDATE", "IGM_NOOFPACKAGE", "IGM_PACKAGETYPE", "IGM_GROSSWEIGHT", "IGM_TYPEOFWEIGHT", "IGM_MARKSNOS", "IGM_GATEWAY_IGM_NO", "IGM_GATEWAY_IGM_DATE", "IGM_GATEWAY_PORT_CODE", "IGM_LINE_NUMBER", "IGM_SHIPPING_LINE_NUMBER", "IGM_VOYAGE");
                    //DATA_CHECK(dsXML.Tables[0]);
                    //objUserBL.Xml_D = ConvertDataTableToXML(selected);
                    //objUserBL.flag = "Duplicate_Chk";
                    //ds = IGM_EXCEl.IGM_BULK_XL_UPD(objUserBL);

                    //if (ds.Tables.Count > 0)
                    //{
                    //    if (dsXML.Tables[0].Rows.Count > 0)
                    //    {

                    //        Alert_msg("XL contains duplicate value");
                    //        return;


                    //    }
                    //}
                    //else
                    //{
                        if (dt_Avail.Rows.Count == 0)
                        {
                            if (dsXML.Tables[0].Rows.Count > 0)
                            {
                                //MP_U1.Hide();

                                admin.SqlBulk_Upload_Product("IGM_DETAILS", dsXML.Tables[0], Session["currentcomp_db"].ToString());
                                Alert_msg("Uploaded Successfully..");
                            }
                        }
                    //}
                    #endregion

                    //if (dt_Avail.Rows.Count == 0)
                    //{
                    //    DataTable dtShow = new DataTable();
                    //    DATA_CHECK(selected);

                    //    if (VALID.Rows.Count == 0)
                    //    {
                    //        if (dsXML.Tables[0].Rows.Count > 0)
                    //        {
                    //            //MP_U1.Hide();

                    //            admin.SqlBulk_Upload_Product("IGM_DETAILS", dsXML.Tables[0], Session["currentcomp_db"].ToString());
                    //            Alert_msg("Uploaded Successfully..");
                    //        }
                    //    }
                    //    else
                    //    {
                    //        MP_U1.Show();
                    //        //string msg = "    IRN No Already Available" + Environment.NewLine + " -------------------------------------------------------" + Environment.NewLine + "   Inv No  " + "         " + "IRN No" + Environment.NewLine + Environment.NewLine;
                    //        //for (int j = 0; j <= dt_Avail.Rows.Count - 1; j++)
                    //        //{
                    //        //    msg += dt_Avail.Rows[j][0].ToString() + "              " + dt_Avail.Rows[j][2].ToString() + "  " + Environment.NewLine;
                    //        //}

                    //        ////msg = " Inv no : " + dss.Tables[0].Rows[s][38].ToString() + "  -  Already Exists";
                    //        //hdinvno.Value = msg;
                    //        //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Avail_InvoiceNo_Alert_Msg()", true);
                    //    }
                    //}
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

    public int Check_Avail_Sup_Doc(string IGM_NO)
    {
        DataSet dss = new DataSet();
        IGM_EXCEl.JOBNO = IMPORT_JOBNO;
        IGM_EXCEl.IGM_NO = IGM_NO;
        IGM_EXCEl.flag = "Check_Avail";
        IGM_EXCEl.WORKING_PERIOD = Working_Period;
        IGM_EXCEl.BRANCH_CODE = Connection.Get_Company_Type();
        IGM_EXCEl.BRANCH_COMMON = Connection.Get_Company_Type();

        DataTable TEMP1 = ds.Tables[0];
        dss = IGM_EXCEl.IMP_IGM_EXCEl_upload();
        ViewState["dss"] = dss;
        i = IGM_EXCEl.result;

        return i;
    }

    public void DATA_CHECK(DataTable dsXML_Excel)
    {
        DataSet dck = new DataSet();

        IGM_EXCEl.IGM_ID = ConvertDataTableToXML(dsXML.Tables[0]);
        IGM_EXCEl.flag = "Data_Check";
        IGM_EXCEl.WORKING_PERIOD = Working_Period;
        dck = IGM_EXCEl.IMP_IGM_EXCEl_upload();

        if (dck.Tables[2].Columns.Count > 3)
        {
            if (dck.Tables[2].Rows.Count > 0)
            {
                VALID.Columns.Add("Igm_Mawb_Mbl");
                VALID.Columns.Add("Igm_Hawb_Hbl");
                VALID.Columns.Add("IGM_NO");
                VALID.Columns.Add("ERROR");
                for (int i = 0; i <= dck.Tables[0].Rows.Count - 1; i++)
                {

                    string IGM_NO = dck.Tables[2].Rows[i]["IGM_NO"].ToString();
                    string Igm_Mawb_Mbl = dck.Tables[2].Rows[i]["IGM_MAWB_MBL"].ToString();
                    string Igm_Hawb_Hbl = dck.Tables[2].Rows[i]["IGM_HAWB_HBLNO"].ToString();
                    string ERROR = "";
                    if (dck.Tables[2].Rows[i]["ERROR"].ToString() != "T")
                    {
                        ERROR = dck.Tables[2].Rows[i]["ERROR"].ToString();

                        VALID.Rows.Add(IGM_NO, Igm_Mawb_Mbl, Igm_Hawb_Hbl, ERROR);
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
            if (dck.Tables[2].Rows.Count > 0)
            {
                VALID.Columns.Add("Igm_Mawb_Mbl");
                VALID.Columns.Add("Igm_Hawb_HblNo");

                VALID.Columns.Add("ERROR");
                for (int i = 0; i <= dck.Tables[2].Rows.Count - 1; i++)
                {

                    string Igm_Mawb_Mbl = dck.Tables[2].Rows[i]["Igm_Mawb_Mbl"].ToString();
                    string Igm_Hawb_HblNo = dck.Tables[2].Rows[i]["Igm_Hawb_HblNo"].ToString();

                    string ERROR = "";
                    if (dck.Tables[2].Rows[i]["ERROR"].ToString() != "T")
                    {
                        ERROR = dck.Tables[2].Rows[i]["ERROR"].ToString();

                        VALID.Rows.Add(Igm_Mawb_Mbl, Igm_Hawb_HblNo, ERROR);
                    }
                }
            }
        }
        gv_Preview.DataSource = VALID;
        gv_Preview.DataBind();
        // gv_Preview.Attributes.Add("Width","500px");
    }
}
