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
using System.Collections.Generic;   //---Added by Antony
using System.Data.SqlClient;

public partial class Import_INV_Gen_Excel : ThemeClass
{
    AppSession aps = new AppSession();
    UserBO ObjUBO = new UserBO();
    Import_XL_Upload IXL = new Import_XL_Upload();

    public string currentuser, COMPANY_IDD, IMPORT_JOBNO, Working_Period, error = "", currentbranch, errorFolder = "", SELECT_BRANCH, logFileName = "";
    private SqlConnection con;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Connection.Current_User();
        currentbranch = Connection.Current_Branch();
        Working_Period = Connection.WorkingPeriod();
        COMPANY_IDD = Connection.COMPANYID();
        SELECT_BRANCH = Connection.Get_Company_Type();
        IMPORT_JOBNO = Connection.IMP_Jobno();
        if (IMPORT_JOBNO != null)
        {

        }
        else
        {
            Response.Write("<script>window.parent.document.getElementById('General').click();</script>");
        }
        errorFolder = Server.MapPath("~/Submission/" + COMPANY_IDD + "/" + currentbranch + "/" + currentuser + "/" + "Import_Excel");
        con = new SqlConnection(HttpContext.Current.Session["currentcomp_db"].ToString());
    }

    protected void gv_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    public void Alert_msg(string msg)
    {
        string safeMsg = msg.Replace("\n","<br>");
        string prompt = string.Format("<script>$(document).ready(function(){{jAlert('{0}', 'Import Invoice', function (r) {{}});}});</script>", safeMsg);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Import Invoice', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void gv_Item_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {

        //------------------------------------------EXCEL upload- by Antony --------------------------------------------------------------------------------------------------
        GridViewRow row = e.Row;
        // Intitialize TableCell list
        List<TableCell> columns = new List<TableCell>();

        foreach (DataControlField column in gv_Item_Details.Columns)
        {
            TableCell cell = row.Cells[0];
            row.Cells.Remove(cell);
            columns.Add(cell);
        }

        row.Cells.AddRange(columns.ToArray());
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //int col_count = e.Row.Cells.Count;

        //if (e.Row.Cells[5].Text == "")    
        //{
        //       string supplierValue = txt_SupplierName_Gen.Text;
        //      TextBox txt_SupplierName = e.Row.FindControl("txt_SupplierName_Gen1") as TextBox;
        //      txt_SupplierName.Text = supplierValue;
            
        //}

        //if (col_count > 6)
        //{
        //    if (e.Row.Cells[6].Text == "")
        //    {
        //        string supplierValue = txt_ThirdPartyName.Text;
        //        TextBox txt_SupplierName = e.Row.FindControl("txt_Third_Party_Name") as TextBox;
        //        txt_SupplierName.Text = supplierValue;
        //    }
        //} 
        int col_count = e.Row.Cells.Count;

        if (col_count > 5 && e.Row.Cells[5].Text == "")
        {
            string supplierValue = txt_SupplierName_Gen.Text;
            TextBox txt_SupplierName = e.Row.FindControl("txt_SupplierName_Gen1") as TextBox;
            if (txt_SupplierName != null)
                txt_SupplierName.Text = supplierValue;

        }

        if (col_count > 6)
        {
            if (e.Row.Cells[6].Text == "")
            {
                string supplierValue = txt_ThirdPartyName.Text;
                TextBox txt_SupplierName = e.Row.FindControl("txt_Third_Party_Name") as TextBox;
                if (txt_SupplierName != null)
                    txt_SupplierName.Text = supplierValue;
            }
        }

        if (ViewState["err_Validate"] == "Y")
        {
            if (e.Row.Cells.Count >= 1)
            {

                //row.Cells.AddRange(columns.ToArray());
                //if (e.Row.RowType == DataControlRowType.Header)
                //    e.Row.CssClass = "header";


                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;

                if (ViewState["Admin_err"] == "Y")
                {
                    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[3].Font.Size = 8;
                    e.Row.Cells[5].Visible = false;
                }
                else
                {
                    e.Row.Cells[0].ForeColor = System.Drawing.Color.Red;
                    if (error != "")
                    {
                        e.Row.Cells[3].Visible = false;
                    }
                }
            }

            //--------------------------------------------------------------------------------------------------------------------------------------------

            //if (e.Row.RowType == DataControlRowType.Header)
            //    e.Row.CssClass = "header";
        }
    }

    protected void btn_upload_Click(object sender, EventArgs e)
    {
        if (txt_SupplierName_Gen.Text != "")
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

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                Get_ExcelFile();
            }
        }
        else
        {
            string Msg = "";
            Msg = "Please Select Supplier Name \n";
            Alert_msg(Msg);
            txt_SupplierName_Gen.Focus();
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
        else if (strFileType.Trim() == ".xlsm")
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
            //------ this concept implmtd by Antony on 23/07/2020 for AlphaNumeric not Capturing in Datatable------------------------------
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
        else
        {
            string query = "SELECT * FROM [Sheet1$]";
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dtt);

            //------ this concept implmtd by Antony on 23/07/2020 for AlphaNumeric not Capturing in Datatable------------------------------
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
            dtt.Columns[0].ColumnName = "INVOICE_SLNO";
            dtt.Columns[1].ColumnName = "INVOICE_NO";
            dtt.Columns[2].ColumnName = "INVOICE_DATE";
            dtt.Columns[3].ColumnName = "TERMS";
            dtt.Columns[4].ColumnName = "INVOICE_CURRENCY";
            dtt.Columns[5].ColumnName = "ITEM_SLNO";
            dtt.Columns[6].ColumnName = "ITEM_QTY";
            dtt.Columns[7].ColumnName = "ITEM_QTY_CODE";
            dtt.Columns[8].ColumnName = "ITEM_UNIT_PRICE";
            dtt.Columns[9].ColumnName = "MIS_FREIGHT_RATE";
            dtt.Columns[10].ColumnName = "MIS_FREIGHT_CHARGES";
            dtt.Columns[11].ColumnName = "MIS_FREIGHT_CURRENCY";
            dtt.Columns[12].ColumnName = "MIS_INSURANCE_RATE";
            dtt.Columns[13].ColumnName = "MIS_INSURANCE_CHARGES";
            dtt.Columns[14].ColumnName = "MIS_INSURANCE_CURRENCY";
           // dtt.Columns[15].ColumnName = "MIS_RATE";  comment by ajith
            dtt.Columns[15].ColumnName = "MIS_CHARGES";
            dtt.Columns[16].ColumnName = "MIS_CURRENCY";
            dtt.Columns[17].ColumnName = "ITEM_DESCRIPTION";
            dtt.Columns[18].ColumnName = "GENEARL_DESCRIPTION";
            dtt.Columns[19].ColumnName = "CTH_NO";
            dtt.Columns[20].ColumnName = "RITC_NO";
            dtt.Columns[21].ColumnName = "CETH_NO";
            dtt.Columns[22].ColumnName = "CTH_QTY1";
            dtt.Columns[23].ColumnName = "CTH_QTY1_CODE";
            dtt.Columns[24].ColumnName = "INFO_MSR";
            dtt.Columns[25].ColumnName = "INFO_UQC";
            dtt.Columns[26].ColumnName = "BCD_NOTN";
            dtt.Columns[27].ColumnName = "BCD_NOTN_SLNO";
            dtt.Columns[28].ColumnName = "CVD_NOTN";
            dtt.Columns[29].ColumnName = "CVD_NOTN_SLNO";
            dtt.Columns[30].ColumnName = "MANUFACTURER";
            dtt.Columns[31].ColumnName = "BRAND";
            dtt.Columns[32].ColumnName = "MODEL";
            dtt.Columns[33].ColumnName = "END_USE_OF_ITEM";
            dtt.Columns[34].ColumnName = "COUNTRY_OF_ORIGIN";
            dtt.Columns[35].ColumnName = "SCHEME_CODE";
            dtt.Columns[36].ColumnName = "SCHEME_NOTN";
            dtt.Columns[37].ColumnName = "SCHEME_NOTN_SLNO";
            dtt.Columns[38].ColumnName = "LICENSE_NO";
            dtt.Columns[39].ColumnName = "LICENSE_DATE";
            dtt.Columns[40].ColumnName = "EXCEMPTION";
            dtt.Columns[41].ColumnName = "LICENSE_SLNO";
            dtt.Columns[42].ColumnName = "PORT_OF_LICENSE";
            dtt.Columns[43].ColumnName = "SAPTA_NOTN";
            dtt.Columns[44].ColumnName = "SAPTA_NOTN_SLNO";
            dtt.Columns[45].ColumnName = "AGGREGATE_NOTN";
            dtt.Columns[46].ColumnName = "AGGREGATE_NOTN_SLNO";
            dtt.Columns[47].ColumnName = "SAFEGUARD_NOTN";
            dtt.Columns[48].ColumnName = "SAFEGUARD_NOTN_SLNO";
            dtt.Columns[49].ColumnName = "PRODUCT_OTHER_DUTY_NOTN";
            dtt.Columns[50].ColumnName = "PRODUCT_OTHER_DUTY_SLNO";
            dtt.Columns[51].ColumnName = "PRODUCT_OTHER_DUTY_RATE";
            dtt.Columns[52].ColumnName = "SOCIAL_WELFARE_NOTN";
            dtt.Columns[53].ColumnName = "SOCIAL_WELFARE_NOTN_SLNO";
            dtt.Columns[54].ColumnName = "IGST_LEVY_NOTN";
            dtt.Columns[55].ColumnName = "IGST_LEVY_SLNO";
            dtt.Columns[56].ColumnName = "IGST_LEVY_EXCEMPTION_NOTN";
            dtt.Columns[57].ColumnName = "IGST_LEVY_EXCEMPTION_SLNO";
            dtt.Columns[58].ColumnName = "LEVY_EXCEMPTION_NOTN_TYPE";
            dtt.Columns[59].ColumnName = "IGST_LEVY_COMPENSATION_CESS_NOTN";
            dtt.Columns[60].ColumnName = "IGST_LEVY_COMPENSATION_CESS_SLNO";
            dtt.Columns[61].ColumnName = "IGST_LEVY_EXCEPTION_CC_NOTN";
            dtt.Columns[62].ColumnName = "IGST_LEVY_EXCEMPTION_CC_SLNO";
            dtt.Columns[63].ColumnName = "LEVY_EXCEPTION_CC_NOTN_TYPE";
            dtt.Columns[64].ColumnName = "ANTI_DUMPING_NOTN";
            dtt.Columns[65].ColumnName = "ANTI_DUMPING_NOTN_SLNO";
            dtt.Columns[66].ColumnName = "CTH_SLNO";
            dtt.Columns[67].ColumnName = "CTH_SUPPLIER_SLNO";
            dtt.Columns[68].ColumnName = "CTH_QTY";
            dtt.Columns[69].ColumnName = "CENTRAL_EXCISE_FLAG";
            dtt.Columns[70].ColumnName = "M_P_GROWER_ADD1";
            dtt.Columns[71].ColumnName = "M_P_GROWER_ADD2";
            dtt.Columns[72].ColumnName = "M_P_GROWER_CITY";
            dtt.Columns[73].ColumnName = "M_P_GROWER_COUNTRY_SUBDIV";
            dtt.Columns[74].ColumnName = "M_P_GROWER_PIN";
            dtt.Columns[75].ColumnName = "M_P_GROWER_COUNTRY";
            dtt.Columns[76].ColumnName = "SOURCE_COUNTRY";
            dtt.Columns[77].ColumnName = "TRANSIT_COUNTRY";
            dtt.Columns[78].ColumnName = "ACCESSORY_STATUS";
            dtt.Columns[79].ColumnName = "SIMS_TYPE";
            dtt.Columns[80].ColumnName = "SIMS_CODE";
            dtt.Columns[81].ColumnName = "SIMS_REG_DATE";
            dtt.Columns[82].ColumnName = "SIMS_REG_VALIDITY";
            dtt.Columns[83].ColumnName = "HEALTH_CESS_NOTN";    //added by Antony
            dtt.Columns[84].ColumnName = "HEALTH_CESS_SLNO";    //added by Antony

            dtt.Columns[85].ColumnName = "FTA_COUNTRY";    //added by Antony
            dtt.Columns[86].ColumnName = "COO_NUMBER";    //added by Antony
            dtt.Columns[87].ColumnName = "COO_DATE";    //added by Antony
            dtt.Columns[88].ColumnName = "COO_ITEM_SLNO"; 
            dtt.Columns[89].ColumnName = "INFO_QUALIFIER"; 
            dtt.Columns[90].ColumnName = "ORIGIN_CRITERIA_CODE";    //added by Antony
            dtt.Columns[91].ColumnName = "INFO_TEXT";    //added by Antony
            dtt.Columns[92].ColumnName = "INFO_UQC_FTA";  
            dtt.Columns[93].ColumnName = "ACCUMULATION_CUMULATION";    //added by Antony
            dtt.Columns[94].ColumnName = "RIS";
            dtt.Columns[95].ColumnName = "DC";  
            dtt.Columns[96].ColumnName = "AIDC_NOTN";    //added by Antony
            dtt.Columns[97].ColumnName = "AIDC_NOTN_SLNO";    //added by Antony
            dtt.Columns[98].ColumnName = "REM_DECLARATION";
            dtt.Columns[99].ColumnName = "REM_TEXT";
            //-----------------------------------------------------------------------
           // if (COMPANY_IDD == "151" || COMPANY_IDD == "152" || COMPANY_IDD == "533" || COMPANY_IDD == "293" || COMPANY_IDD == "10")
            if (COMPANY_IDD == "151" || COMPANY_IDD == "152" || COMPANY_IDD == "533" || ((COMPANY_IDD == "293"  && Session["ICENO"].ToString() == "0400023067")))
            {
                dtt.Columns[100].ColumnName = "String_Con";
            }
            else if (COMPANY_IDD == "125" && currentbranch == "CusHouse, Chennai")
            {
                dtt.Columns[100].ColumnName = "String_Con";
            }
            dtt.AcceptChanges();
            Session["ds_Excel_upload"] = dtt;
            //---------------------------------------------------------------------------------------------------------------------------------------------

            //------------------------------------------EXCEL VALIDATION - by Antony - 02.05.2020---------------------------------------------------------------------------------------------------

            DataTable dat = new DataTable();
            if (COMPANY_IDD != "151" && COMPANY_IDD != "152" && COMPANY_IDD != "533" && COMPANY_IDD != "125" && ((COMPANY_IDD == "293" && Session["ICENO"].ToString() != "0400023067")))
            {
                System.Data.DataView Mandatory_select = new System.Data.DataView(dtt);

                Mandatory_select.RowFilter = "IsNull(CONVERT(INVOICE_SLNO,'System.String'),'')='' or IsNull(CONVERT(INVOICE_NO, 'System.String'),'')='' or IsNull(CONVERT(INVOICE_DATE , 'System.String'),'')='' or IsNull(CONVERT(TERMS , 'System.String'),'')='' or IsNull(CONVERT(INVOICE_CURRENCY , 'System.String'),'')='' or IsNull(CONVERT(ITEM_SLNO , 'System.String'),'')='' or IsNull(CONVERT(ITEM_QTY , 'System.String'),'')='' or IsNull(CONVERT(ITEM_QTY_CODE , 'System.String'),'')=''  or IsNull(CONVERT(ITEM_UNIT_PRICE , 'System.String'),'')='' or IsNull(CONVERT(ITEM_DESCRIPTION , 'System.String'),'')='' or IsNull(CONVERT(GENEARL_DESCRIPTION , 'System.String'),'')='' or IsNull(CONVERT(CTH_NO, 'System.String'),'')='' or IsNull(CONVERT(RITC_NO , 'System.String'),'')='' or IsNull(CONVERT(CETH_NO , 'System.String'),'')='' or IsNull(CONVERT(INFO_MSR , 'System.String'),'')='' or IsNull(CONVERT(INFO_UQC , 'System.String'),'')='' or IsNull(CONVERT(MANUFACTURER , 'System.String'),'')='' or IsNull(CONVERT(BRAND , 'System.String'),'')='' or IsNull(CONVERT(MODEL , 'System.String'),'')='' or IsNull(CONVERT(END_USE_OF_ITEM , 'System.String'),'')='' or IsNull(CONVERT(COUNTRY_OF_ORIGIN , 'System.String'),'')=''";

                System.Data.DataTable Mandatory_tb = Mandatory_select.ToTable("Selected", false, "INVOICE_SLNO", "INVOICE_NO", "INVOICE_DATE", "TERMS", "INVOICE_CURRENCY", "ITEM_SLNO", "ITEM_QTY", "ITEM_QTY_CODE", "ITEM_UNIT_PRICE", "ITEM_DESCRIPTION", "GENEARL_DESCRIPTION", "CTH_NO", "RITC_NO", "CETH_NO", "INFO_MSR", "INFO_UQC", "MANUFACTURER", "BRAND", "MODEL", "END_USE_OF_ITEM", "COUNTRY_OF_ORIGIN");
                DataView dv = Mandatory_tb.DefaultView;
                dat = dv.ToTable("Selected", false, "INVOICE_SLNO", "ITEM_SLNO");
                dat.Columns.Add("DATA_FILED");
                dat.Columns.Add("ERROR_MESSAGE");
                if (Mandatory_tb.Rows.Count > 0)
                {
                    for (int i = 0; i < Mandatory_tb.Rows.Count; i++)
                    {
                        for (int j = 0; j < Mandatory_tb.Columns.Count; j++)
                        {
                            if (Mandatory_tb.Rows[i][j].ToString() == "")
                            {
                                dat.Rows[i]["DATA_FILED"] = dat.Rows[i]["DATA_FILED"] + " " + Mandatory_tb.Columns[j].ColumnName.ToString() + ",";
                                dat.Rows[i]["ERROR_MESSAGE"] = dat.Rows[i]["ERROR_MESSAGE"] + "mandatory field ,";
                            }
                        }
                    }
                }
            }
            //---------------------------------------------------------------------------------------------------------------------------------------------

            if (Session["ICENO"] != string.Empty && Session["ICENO"] != "" && Session["ICENO"] != null)
            {
                if ((COMPANY_IDD == "293" && Session["ICENO"].ToString() == "0400023067"))//Kavi & Ajith //       
                {
                    System.Data.DataView Mandatory_select = new System.Data.DataView(dtt);

                    //COMMAND ON 31/05/2025 - Informed By Client // Condition Suggess By Niyas
                    //Mandatory_select.RowFilter = "IsNull(CONVERT(INVOICE_SLNO,'System.String'),'')='' or IsNull(CONVERT(INVOICE_NO, 'System.String'),'')='' or IsNull(CONVERT(INVOICE_DATE , 'System.String'),'')='' or IsNull(CONVERT(TERMS , 'System.String'),'')='' or IsNull(CONVERT(INVOICE_CURRENCY , 'System.String'),'')='' or IsNull(CONVERT(ITEM_SLNO , 'System.String'),'')='' or IsNull(CONVERT(ITEM_QTY , 'System.String'),'')='' or IsNull(CONVERT(ITEM_QTY_CODE , 'System.String'),'')=''  or IsNull(CONVERT(ITEM_UNIT_PRICE , 'System.String'),'')='' or IsNull(CONVERT(ITEM_DESCRIPTION , 'System.String'),'')='' or IsNull(CONVERT(GENEARL_DESCRIPTION , 'System.String'),'')='' or IsNull(CONVERT(INFO_MSR , 'System.String'),'')='' or IsNull(CONVERT(INFO_UQC , 'System.String'),'')='' or IsNull(CONVERT(MANUFACTURER , 'System.String'),'')='' or IsNull(CONVERT(BRAND , 'System.String'),'')='' or IsNull(CONVERT(MODEL , 'System.String'),'')='' or IsNull(CONVERT(END_USE_OF_ITEM , 'System.String'),'')='' or IsNull(CONVERT(COUNTRY_OF_ORIGIN , 'System.String'),'')='' or IsNull(CONVERT(String_Con , 'System.String'),'')=''";

                    //System.Data.DataTable Mandatory_tb = Mandatory_select.ToTable("Selected", false, "INVOICE_SLNO", "INVOICE_NO", "INVOICE_DATE", "TERMS", "INVOICE_CURRENCY", "ITEM_SLNO", "ITEM_QTY", "ITEM_QTY_CODE", "ITEM_UNIT_PRICE", "ITEM_DESCRIPTION", "GENEARL_DESCRIPTION", "INFO_MSR", "INFO_UQC", "MANUFACTURER", "BRAND", "MODEL", "END_USE_OF_ITEM", "COUNTRY_OF_ORIGIN", "String_Con");
                    //if (Mandatory_tb.Columns.Contains("String_Con"))
                    //{
                    //    Mandatory_tb.Columns["String_Con"].ColumnName = "PART_NO";
                    //}


                    Mandatory_select.RowFilter = "IsNull(CONVERT(INVOICE_SLNO,'System.String'),'')='' or IsNull(CONVERT(INVOICE_NO, 'System.String'),'')='' or IsNull(CONVERT(INVOICE_DATE , 'System.String'),'')='' or IsNull(CONVERT(TERMS , 'System.String'),'')='' or IsNull(CONVERT(INVOICE_CURRENCY , 'System.String'),'')='' or IsNull(CONVERT(ITEM_SLNO , 'System.String'),'')='' or IsNull(CONVERT(ITEM_QTY , 'System.String'),'')='' or IsNull(CONVERT(ITEM_QTY_CODE , 'System.String'),'')=''  or IsNull(CONVERT(ITEM_UNIT_PRICE , 'System.String'),'')='' or IsNull(CONVERT(ITEM_DESCRIPTION , 'System.String'),'')='' or IsNull(CONVERT(GENEARL_DESCRIPTION , 'System.String'),'')='' or IsNull(CONVERT(INFO_MSR , 'System.String'),'')='' or IsNull(CONVERT(INFO_UQC , 'System.String'),'')='' or IsNull(CONVERT(MANUFACTURER , 'System.String'),'')='' or IsNull(CONVERT(BRAND , 'System.String'),'')='' or IsNull(CONVERT(MODEL , 'System.String'),'')='' or IsNull(CONVERT(END_USE_OF_ITEM , 'System.String'),'')='' or IsNull(CONVERT(COUNTRY_OF_ORIGIN , 'System.String'),'')=''";

                    System.Data.DataTable Mandatory_tb = Mandatory_select.ToTable("Selected", false, "INVOICE_SLNO", "INVOICE_NO", "INVOICE_DATE", "TERMS", "INVOICE_CURRENCY", "ITEM_SLNO", "ITEM_QTY", "ITEM_QTY_CODE", "ITEM_UNIT_PRICE", "ITEM_DESCRIPTION", "GENEARL_DESCRIPTION", "INFO_MSR", "INFO_UQC", "MANUFACTURER", "BRAND", "MODEL", "END_USE_OF_ITEM", "COUNTRY_OF_ORIGIN");

                    DataView dv = Mandatory_tb.DefaultView;
                    dat = dv.ToTable("Selected", false, "INVOICE_SLNO", "ITEM_SLNO");
                    dat.Columns.Add("DATA_FILED");
                    dat.Columns.Add("ERROR_MESSAGE");
                    if (Mandatory_tb.Rows.Count > 0)
                    {
                        for (int i = 0; i < Mandatory_tb.Rows.Count; i++)
                        {
                            for (int j = 0; j < Mandatory_tb.Columns.Count; j++)
                            {
                                if (Mandatory_tb.Rows[i][j].ToString() == "")
                                {
                                    dat.Rows[i]["DATA_FILED"] = dat.Rows[i]["DATA_FILED"] + " " + Mandatory_tb.Columns[j].ColumnName.ToString() + ",";
                                    dat.Rows[i]["ERROR_MESSAGE"] = dat.Rows[i]["ERROR_MESSAGE"] + "mandatory field ,";
                                }
                            }
                        }
                    }
                    else
                    {
                        if (dtt.Rows.Count > 0)
                        {
                            for (int k = 0; k <= dtt.Rows.Count - 1; k++)
                            {
                                string INVOICE_SLNO = dtt.Rows[k]["INVOICE_SLNO"].ToString();
                                string ITEM_SLNO = dtt.Rows[k]["ITEM_SLNO"].ToString();
                                string PART_NO = dtt.Rows[k]["String_Con"].ToString();
                                con.Open();
                                SqlCommand Scmd =
                                    new SqlCommand(
                                        "select PRODUCT_CTH,PRODUCT_RITC,PRODUCT_CETH,PRODUCT_BCD_NOTN,PRODUCT_BCD_SLNO,IGST_LEVY_NOTN,IGST_LEVY_SLNO,AIDC_NOTN,AIDC_NOTN_SLNO from IMPORT_CATERPILLAR_MASTER where PART_NO = '" + PART_NO.Trim() + "'", con);
                                SqlDataAdapter sda = new SqlDataAdapter(Scmd);
                                DataSet Sds = new DataSet();
                                sda.Fill(Sds);
                                con.Close();
                                if (Sds.Tables[0].Rows.Count > 0)
                                {
                                    string CTH_NO = Sds.Tables[0].Rows[0]["PRODUCT_CTH"].ToString();
                                    string RITC_NO = Sds.Tables[0].Rows[0]["PRODUCT_RITC"].ToString();
                                    string CETH_NO = Sds.Tables[0].Rows[0]["PRODUCT_CETH"].ToString();

                                    string BCD_NOTN = !string.IsNullOrWhiteSpace(dtt.Rows[k]["BCD_NOTN"].ToString()) ? dtt.Rows[k]["BCD_NOTN"].ToString() : Sds.Tables[0].Rows[0]["PRODUCT_BCD_NOTN"].ToString();
                                    string BCD_NOTN_SLNO = !string.IsNullOrWhiteSpace(dtt.Rows[k]["BCD_NOTN_SLNO"].ToString()) ? dtt.Rows[k]["BCD_NOTN_SLNO"].ToString() : Sds.Tables[0].Rows[0]["PRODUCT_BCD_SLNO"].ToString();
                                    string IGST_LEVY_NOTN = !string.IsNullOrWhiteSpace(dtt.Rows[k]["IGST_LEVY_NOTN"].ToString()) ? dtt.Rows[k]["IGST_LEVY_NOTN"].ToString() : Sds.Tables[0].Rows[0]["IGST_LEVY_NOTN"].ToString();
                                    string IGST_LEVY_SLNO = !string.IsNullOrWhiteSpace(dtt.Rows[k]["IGST_LEVY_SLNO"].ToString()) ? dtt.Rows[k]["IGST_LEVY_SLNO"].ToString() : Sds.Tables[0].Rows[0]["IGST_LEVY_SLNO"].ToString();
                                    string AIDC_NOTN = !string.IsNullOrWhiteSpace(dtt.Rows[k]["AIDC_NOTN"].ToString()) ? dtt.Rows[k]["AIDC_NOTN"].ToString() : Sds.Tables[0].Rows[0]["AIDC_NOTN"].ToString();
                                    string AIDC_NOTN_SLNO = !string.IsNullOrWhiteSpace(dtt.Rows[k]["AIDC_NOTN_SLNO"].ToString()) ? dtt.Rows[k]["AIDC_NOTN_SLNO"].ToString() : Sds.Tables[0].Rows[0]["AIDC_NOTN_SLNO"].ToString();


                                    dtt.Rows[k]["CTH_NO"] = CTH_NO;
                                    dtt.Rows[k]["RITC_NO"] = RITC_NO;
                                    dtt.Rows[k]["CETH_NO"] = CETH_NO;
                                    dtt.Rows[k]["BCD_NOTN"] = BCD_NOTN;
                                    dtt.Rows[k]["BCD_NOTN_SLNO"] = BCD_NOTN_SLNO;
                                    dtt.Rows[k]["IGST_LEVY_NOTN"] = IGST_LEVY_NOTN;
                                    dtt.Rows[k]["IGST_LEVY_SLNO"] = IGST_LEVY_SLNO;
                                    dtt.Rows[k]["AIDC_NOTN"] = AIDC_NOTN;
                                    dtt.Rows[k]["AIDC_NOTN_SLNO"] = AIDC_NOTN_SLNO;
                                }                                
                            }

                            dtt.AcceptChanges();
                            Session["ds_Excel_upload"] = dtt;
                        }
                    }
                }
            }

            //----------------------------------------------------
            DataSet ds_Mandatory_err = ValidateMandatoryFields(dtt);
            if (ds_Mandatory_err.Tables[0].Rows.Count > 0)
            {
                error = "errormsg";
                gv_Item_Details.DataSource = ds_Mandatory_err.Tables[0];
                gv_Item_Details.DataBind();
                btnUpload.Visible = false;
                btnUpload_Alert.Visible = false;
                return;
            }
            //----------------------CTH / INFO_UQC VALIDATION - via ADMIN_GET_IMPORT_CTH_UQC_VALIDATION --------------- Added by shanthini on 07-07-2026
            System.Data.DataView view_Cth = new System.Data.DataView(dtt);
            System.Data.DataTable selected_Cth = view_Cth.ToTable("Selected", true, "INVOICE_SLNO", "ITEM_SLNO", "CTH_NO", "INFO_UQC");
            ObjUBO.Xml_D = ConvertDataTableToXML(selected_Cth);
            ObjUBO.flag = "Import_CTH_UQC_Validate";
            DataSet ds_CthUqc_err = IXL.ValidateImportCthUqc(ObjUBO);

            if (ds_CthUqc_err.Tables[0].Rows.Count > 0)
            {
                error = "errormsg";
                gv_Item_Details.DataSource = ds_CthUqc_err.Tables[0];
                gv_Item_Details.DataBind();
                btnUpload.Visible = false;
                btnUpload_Alert.Visible = false;
                return;
            }

            //------------------------------------------EXCEL VALIDATION - by Antony - 02.05.2020---------------------------------------------------------------------------------------------------
            System.Data.DataView view = new System.Data.DataView(dtt);
            System.Data.DataTable selected = view.ToTable("Selected", true, "INVOICE_NO", "INVOICE_DATE", "BRAND", "MODEL", "M_P_GROWER_ADD1", "M_P_GROWER_ADD2", "M_P_GROWER_CITY", "M_P_GROWER_COUNTRY_SUBDIV", "M_P_GROWER_PIN", "INVOICE_SLNO", "ITEM_SLNO", "ITEM_DESCRIPTION", "GENEARL_DESCRIPTION", "MANUFACTURER", "BCD_NOTN", "BCD_NOTN_SLNO", "SAPTA_NOTN", "COUNTRY_OF_ORIGIN", "FTA_COUNTRY", "ORIGIN_CRITERIA_CODE", "INFO_TEXT", "COO_NUMBER", "COO_DATE", "COO_ITEM_SLNO");
            ObjUBO.Xml_D = ConvertDataTableToXML(selected);
            ObjUBO.flag = "Special_Charater_Chk";
            dds = IXL.Special_Character_Chk(ObjUBO);

            if (dat.Rows.Count > 0 || dds.Tables[0].Rows.Count > 0)
            {
                error = "errormsg";
                if (dat.Rows.Count > 0 && dds.Tables[0].Rows.Count > 0)
                {
                    dds.Tables[0].Merge(dat, true, MissingSchemaAction.Ignore);
                    gv_Item_Details.DataSource = dds.Tables[0];
                    gv_Item_Details.DataBind();
                }
                else if (dat.Rows.Count > 0)
                {
                    gv_Item_Details.DataSource = dat;
                    gv_Item_Details.DataBind();
                }
                else
                {
                    gv_Item_Details.DataSource = dds.Tables[0];
                    gv_Item_Details.DataBind();                 
                }
                btnUpload.Visible = false;
                btnUpload_Alert.Visible = false;
            }
            //---------------------------------------------------------------------------------------------------------------------------------------------

            else
            {
                //-----------SIMS---Sea-------------------
                if (COMPANY_IDD == "152" || COMPANY_IDD == "533")
                {
                    DataSet SS = new DataSet();
                    System.Data.DataView view_Sims_S = new System.Data.DataView(dtt);
                    System.Data.DataTable selected_Sims_S = view_Sims_S.ToTable("Selected", true, "INVOICE_SLNO", "ITEM_SLNO", "CTH_NO", "SIMS_TYPE", "SIMS_CODE", "SIMS_REG_DATE", "SIMS_REG_VALIDITY", "String_Con");
                    ObjUBO.Xml_D = ConvertDataTableToXML(selected_Sims_S);
                    ObjUBO.flag = "SIMS_CTH_NO";
                    SS = IXL.IMP_CP_XL_Select(ObjUBO);
                    if (SS.Tables[0].Rows.Count > 0)
                    {
                        ObjUBO.Xml_D = ConvertDataTableToXML(SS.Tables[0]);
                        ObjUBO.CUSTOMS_HOUSE = Session["IMP_Job_CUSTOMHOUSE_CODE"].ToString();
                        ObjUBO.flag = "SIMS_CTH_NO";
                        get_SIMS(IXL.Special_Character_Chk(ObjUBO));
                    }
                    else
                    {
                        DataTable dt = new DataTable();
                        Session["get_SIMS"] = dt;
                        Session["get_SIMS_Tr_mode"] = "";
                    }
                }
                else
                { 
                        System.Data.DataView view_Sims = new System.Data.DataView(dtt);
                        System.Data.DataTable selected_Sims = view_Sims.ToTable("Selected", true, "INVOICE_SLNO", "ITEM_SLNO", "CTH_NO", "SIMS_TYPE", "SIMS_CODE", "SIMS_REG_DATE", "SIMS_REG_VALIDITY");
                        ObjUBO.Xml_D = ConvertDataTableToXML(selected_Sims);
                        ObjUBO.CUSTOMS_HOUSE = Session["IMP_Job_CUSTOMHOUSE_CODE"].ToString();
                        ObjUBO.flag = "SIMS_CTH_NO";
                        get_SIMS(IXL.Special_Character_Chk(ObjUBO));
                }
                //----------------------------------
                DataSet dds_2 = new DataSet();
                System.Data.DataView view_2 = new System.Data.DataView(dtt);
                System.Data.DataTable selected_2 = view_2.ToTable("Selected", true, "INVOICE_SLNO", "ITEM_SLNO", "INVOICE_CURRENCY", "TERMS", "ITEM_QTY", "ITEM_UNIT_PRICE"
               , "SAPTA_NOTN", "SAPTA_NOTN_SLNO", "AGGREGATE_NOTN", "AGGREGATE_NOTN_SLNO", "SAFEGUARD_NOTN", "SAFEGUARD_NOTN_SLNO", "PRODUCT_OTHER_DUTY_NOTN", "PRODUCT_OTHER_DUTY_SLNO", "PRODUCT_OTHER_DUTY_RATE"
               , "MIS_CURRENCY", "MIS_FREIGHT_CURRENCY", "MIS_INSURANCE_CURRENCY", "SCHEME_CODE", "IGST_LEVY_NOTN", "IGST_LEVY_SLNO", "IGST_LEVY_EXCEMPTION_NOTN", "IGST_LEVY_EXCEMPTION_SLNO", "IGST_LEVY_COMPENSATION_CESS_NOTN"
               , "IGST_LEVY_COMPENSATION_CESS_SLNO", "IGST_LEVY_EXCEPTION_CC_NOTN", "IGST_LEVY_EXCEMPTION_CC_SLNO", "M_P_GROWER_COUNTRY", "SOURCE_COUNTRY", "TRANSIT_COUNTRY", "FTA_COUNTRY", "COO_NUMBER", "COO_DATE", "COO_ITEM_SLNO"
               , "INFO_QUALIFIER", "ORIGIN_CRITERIA_CODE", "INFO_TEXT", "INFO_UQC_FTA", "ACCUMULATION_CUMULATION", "RIS", "DC");

                ObjUBO.Xml_D = ConvertDataTableToXML(selected_2);
                ObjUBO.flag = "Invoice_Details";
                dds_2 = IXL.Special_Character_Chk_FTA(ObjUBO);

                if (dds_2.Tables[0].Rows.Count > 0)
                {
                    DataTable ddt = new DataTable();
                    gv_Item_Details.DataSource = dds_2.Tables[0];
                    gv_Item_Details.DataBind();

                    //TextBox txtSupp = gv_Item_Details.Rows[0].FindControl("txt_SupplierName_Gen1") as TextBox;
                    //TextBox txt_Third_Party = gv_Item_Details.Rows[0].FindControl("txt_Third_Party_Name") as TextBox;
                    //txtSupp.Text  = txt_SupplierName_Gen.Text;
                    //txt_Third_Party.Text = txt_ThirdPartyName.Text;
                    //if (dds_2.Tables[0].Rows.Count == 1)
                    //{
                    //    TextBox txtSupp = gv_Item_Details.Rows[0].FindControl("txt_SupplierName_Gen1") as TextBox;
                    //    txtSupp.Enabled = true;

                    //}
                    if (dds_2.Tables[1].Rows.Count > 0)
                    {
                        Session["get_SAPTA_RATE_ALL"] = dds_2.Tables[1];
                    }
                    else
                    {
                        DataTable dt_SAPTA = new DataTable();
                        dt_SAPTA.Columns.Add(new System.Data.DataColumn("NOTN_No", typeof(String)));
                        dt_SAPTA.Columns.Add(new System.Data.DataColumn("NOTN_SLNo", typeof(String)));
                        dt_SAPTA.Columns.Add(new System.Data.DataColumn("NOTN_Type", typeof(String)));
                        dt_SAPTA.Columns.Add(new System.Data.DataColumn("RATE", typeof(String)));
                        Session["get_SAPTA_RATE_ALL"] = dt_SAPTA;
                    }

                    if (dds_2.Tables[2].Rows.Count > 0)
                    {
                        Session["Get_Ex_Rate"] = dds_2.Tables[2];
                    }
                    else
                    {
                        DataTable dt_Ex_Rate = new DataTable();
                        dt_Ex_Rate.Columns.Add(new System.Data.DataColumn("EXCHANGE_CUR_CODE", typeof(String)));
                        dt_Ex_Rate.Columns.Add(new System.Data.DataColumn("EXCHANGE_RATE_IMPORT", typeof(String)));
                        Session["Get_Ex_Rate"] = dt_Ex_Rate;
                    }

                    if (dds_2.Tables[3].Rows.Count > 0)
                    {
                        Session["Get_SCHEME_CODE"] = dds_2.Tables[3];
                    }
                    else
                    {
                        DataTable dt_SCHEME_CODE = new DataTable();
                        dt_SCHEME_CODE.Columns.Add(new System.Data.DataColumn("SCHEME_CODE", typeof(String)));
                        Session["Get_SCHEME_CODE"] = dt_SCHEME_CODE;
                    }
                    if (dds_2.Tables[4].Rows.Count > 0)
                    {
                        Session["Get_LEVY"] = dds_2.Tables[4];
                    }
                    else
                    {
                        DataTable dt_LEVY = new DataTable();
                        dt_LEVY.Columns.Add(new System.Data.DataColumn("LEVY_NOTN", typeof(String)));
                        dt_LEVY.Columns.Add(new System.Data.DataColumn("LEVY_NOTN_SLNO", typeof(String)));
                        dt_LEVY.Columns.Add(new System.Data.DataColumn("LEVY_NOTN_RATE", typeof(String)));
                        dt_LEVY.Columns.Add(new System.Data.DataColumn("NOTN_TYPE", typeof(String)));
                        Session["Get_LEVY"] = dt_LEVY;
                    }
                    if (dds_2.Tables[5].Rows.Count > 0)
                    {
                        Session["Get_COUNTRY"] = dds_2.Tables[5];
                    }
                    else
                    {
                        DataTable dt_COUNTRY = new DataTable();
                        dt_COUNTRY.Columns.Add(new System.Data.DataColumn("COUNTRY_CODE", typeof(String)));
                        dt_COUNTRY.Columns.Add(new System.Data.DataColumn("COUNTRY_NAME", typeof(String)));

                        Session["Get_COUNTRY"] = dt_COUNTRY;
                    }
                    Session["Get_Fta"] = dds_2.Tables[6];
                    DataSet ss = new DataSet();
                    ObjUBO.flag = "Inv_No_Chk";
                    ss = IXL.IMP_Gen_XL_DML(ObjUBO);

                    if (ss.Tables[0].Rows.Count > 0)
                    {
                        btnUpload_Alert.Visible = true;
                        btnUpload.Visible = false;
                    }
                    else
                    {
                        btnUpload_Alert.Visible = false;
                        btnUpload.Visible = true;
                    }
                    //------------------- REM DECLARATION----------------------
                    System.Data.DataView dv_REM = new System.Data.DataView(dtt);
                    DataTable dt_REM1 = new DataTable();
                    dt_REM1 = dv_REM.ToTable("Selected", false, "INVOICE_SLNO", "ITEM_SLNO", "REM_DECLARATION", "REM_TEXT");
                    DataView OD_view = dt_REM1.DefaultView;
                    OD_view.RowFilter = "Isnull(REM_DECLARATION,'') <> ''";
                    DataTable dt_REM = OD_view.ToTable();
                    Session["Get_REM"] = dt_REM;
                }
                else
                {
                    DataTable dt = new DataTable();
                    gv_Item_Details.DataSource = dt;
                    gv_Item_Details.DataBind();
                    btnUpload.Visible = false;
                    btnUpload_Alert.Visible = false;
                }
            }
        }
        //----------------------SriramE------------------
    }


    //[System.Web.Services.WebMethod]//hideon 14-02-2026
    //public static string IMP_Excel_Upload(string txt_SupplierName_Gen, DataTable dt)
   
    public string IMP_Excel_Upload(string txt_SupplierName_Gen, DataTable dt)
    {
        try
        {
            //DataTable dt = (DataTable)HttpContext.Current.Session["gvd"];   //--------Added by Antony-----------

           //DataTable dt = views
            string C_ID = string.Empty;

            C_ID = Connection.COMPANYID();

            Import_XL_Upload IXL = new Import_XL_Upload();
            UserBO ObjUBO = new UserBO();

            DataSet ds = new DataSet();

            DataTable dt_All = new DataTable();
            DataTable dt_SAPTA_RATE = new DataTable();
            DataTable dt_Ex_Rate = new DataTable();
            DataTable dt_SCHEME_CODE = new DataTable();
            DataTable dt_LEVY = new DataTable();
            DataTable dt_COUNTRY = new DataTable();
            DataTable dt_SIMS = new DataTable();
            DataTable dt_Fta = new DataTable();
            DataTable dt_REM1 = new DataTable();


            dt_All = (DataTable)HttpContext.Current.Session["ds_Excel_upload"];
            dt_SAPTA_RATE = (DataTable)HttpContext.Current.Session["get_SAPTA_RATE_ALL"];
            dt_Ex_Rate = (DataTable)HttpContext.Current.Session["Get_Ex_Rate"];
            dt_SCHEME_CODE = (DataTable)HttpContext.Current.Session["Get_SCHEME_CODE"];
            dt_LEVY = (DataTable)HttpContext.Current.Session["Get_LEVY"];
            dt_COUNTRY = (DataTable)HttpContext.Current.Session["Get_COUNTRY"];

            dt_SIMS = (DataTable)HttpContext.Current.Session["get_SIMS"];
            dt_Fta = (DataTable)HttpContext.Current.Session["Get_Fta"];
            dt_REM1 = (DataTable)HttpContext.Current.Session["Get_REM"];


            if (dt_All != null)
            {
                System.Data.DataView view = new System.Data.DataView(dt_All);

                if (C_ID == "151" || C_ID == "152" || C_ID == "533")
                {
                    System.Data.DataTable dt_Change = view.ToTable("Selected", true,
                     "INVOICE_SLNO", "INVOICE_NO", "INVOICE_DATE", "TERMS", "INVOICE_CURRENCY", "ITEM_SLNO", "ITEM_QTY", "ITEM_QTY_CODE"
                    , "ITEM_UNIT_PRICE", "ITEM_DESCRIPTION", "MIS_FREIGHT_RATE", "MIS_FREIGHT_CHARGES", "MIS_FREIGHT_CURRENCY", "MIS_INSURANCE_RATE", "MIS_INSURANCE_CHARGES", "MIS_INSURANCE_CURRENCY" //"MIS_RATE" comment by ajith
                    , "MIS_CHARGES", "MIS_CURRENCY", "CTH_NO"
                    , "RITC_NO", "BCD_NOTN", "BCD_NOTN_SLNO", "CETH_NO", "CVD_NOTN", "CVD_NOTN_SLNO", "GENEARL_DESCRIPTION", "MANUFACTURER", "BRAND", "MODEL", "END_USE_OF_ITEM"
                    , "COUNTRY_OF_ORIGIN", "SCHEME_CODE", "SCHEME_NOTN", "SCHEME_NOTN_SLNO", "LICENSE_NO", "LICENSE_DATE", "EXCEMPTION", "LICENSE_SLNO", "PORT_OF_LICENSE"
                    , "SAPTA_NOTN", "SAPTA_NOTN_SLNO", "AGGREGATE_NOTN"

                    , "AGGREGATE_NOTN_SLNO", "SAFEGUARD_NOTN", "SAFEGUARD_NOTN_SLNO", "PRODUCT_OTHER_DUTY_NOTN", "PRODUCT_OTHER_DUTY_SLNO", "PRODUCT_OTHER_DUTY_RATE"
                    , "IGST_LEVY_NOTN", "IGST_LEVY_SLNO", "IGST_LEVY_EXCEMPTION_NOTN", "IGST_LEVY_EXCEMPTION_SLNO", "IGST_LEVY_COMPENSATION_CESS_NOTN"
                    , "IGST_LEVY_COMPENSATION_CESS_SLNO", "IGST_LEVY_EXCEPTION_CC_NOTN", "IGST_LEVY_EXCEMPTION_CC_SLNO", "LEVY_EXCEMPTION_NOTN_TYPE", "LEVY_EXCEPTION_CC_NOTN_TYPE"
                    , "SOCIAL_WELFARE_NOTN", "SOCIAL_WELFARE_NOTN_SLNO", "INFO_MSR", "INFO_UQC", "CTH_QTY1", "CTH_QTY1_CODE", "ANTI_DUMPING_NOTN", "ANTI_DUMPING_NOTN_SLNO", "CTH_SLNO", "CTH_SUPPLIER_SLNO", "CTH_QTY"
                    , "CENTRAL_EXCISE_FLAG", "M_P_GROWER_ADD1", "M_P_GROWER_ADD2", "M_P_GROWER_CITY", "M_P_GROWER_COUNTRY_SUBDIV", "M_P_GROWER_PIN", "M_P_GROWER_COUNTRY", "SOURCE_COUNTRY"
                    , "TRANSIT_COUNTRY", "ACCESSORY_STATUS", "HEALTH_CESS_NOTN", "HEALTH_CESS_SLNO", "AIDC_NOTN", "AIDC_NOTN_SLNO", "REM_DECLARATION", "REM_TEXT", "String_Con"); //-Added healthcess by Antony

                    ObjUBO.Xml_A = ConvertDataTableToXML(dt_Change);
                }
                else if (C_ID == "125" && Connection.Current_Branch() == "CusHouse, Chennai")
                {
                    System.Data.DataTable dt_Change = view.ToTable("Selected", true,
                     "INVOICE_SLNO", "INVOICE_NO", "INVOICE_DATE", "TERMS", "INVOICE_CURRENCY", "ITEM_SLNO", "ITEM_QTY", "ITEM_QTY_CODE"
                    , "ITEM_UNIT_PRICE", "ITEM_DESCRIPTION", "MIS_FREIGHT_RATE", "MIS_FREIGHT_CHARGES", "MIS_FREIGHT_CURRENCY", "MIS_INSURANCE_RATE", "MIS_INSURANCE_CHARGES", "MIS_INSURANCE_CURRENCY", //"MIS_RATE",  comment by ajith
                    "MIS_CHARGES", "MIS_CURRENCY", "CTH_NO"
                    , "RITC_NO", "BCD_NOTN", "BCD_NOTN_SLNO", "CETH_NO", "CVD_NOTN", "CVD_NOTN_SLNO", "GENEARL_DESCRIPTION", "MANUFACTURER", "BRAND", "MODEL", "END_USE_OF_ITEM"
                    , "COUNTRY_OF_ORIGIN", "SCHEME_CODE", "SCHEME_NOTN", "SCHEME_NOTN_SLNO", "LICENSE_NO", "LICENSE_DATE", "EXCEMPTION", "LICENSE_SLNO", "PORT_OF_LICENSE"
                    , "SAPTA_NOTN", "SAPTA_NOTN_SLNO", "AGGREGATE_NOTN"

                    , "AGGREGATE_NOTN_SLNO", "SAFEGUARD_NOTN", "SAFEGUARD_NOTN_SLNO", "PRODUCT_OTHER_DUTY_NOTN", "PRODUCT_OTHER_DUTY_SLNO", "PRODUCT_OTHER_DUTY_RATE"
                    , "IGST_LEVY_NOTN", "IGST_LEVY_SLNO", "IGST_LEVY_EXCEMPTION_NOTN", "IGST_LEVY_EXCEMPTION_SLNO", "IGST_LEVY_COMPENSATION_CESS_NOTN"
                    , "IGST_LEVY_COMPENSATION_CESS_SLNO", "IGST_LEVY_EXCEPTION_CC_NOTN", "IGST_LEVY_EXCEMPTION_CC_SLNO", "LEVY_EXCEMPTION_NOTN_TYPE", "LEVY_EXCEPTION_CC_NOTN_TYPE"
                    , "SOCIAL_WELFARE_NOTN", "SOCIAL_WELFARE_NOTN_SLNO", "INFO_MSR", "INFO_UQC", "CTH_QTY1", "CTH_QTY1_CODE", "ANTI_DUMPING_NOTN", "ANTI_DUMPING_NOTN_SLNO", "CTH_SLNO", "CTH_SUPPLIER_SLNO", "CTH_QTY"
                    , "CENTRAL_EXCISE_FLAG", "M_P_GROWER_ADD1", "M_P_GROWER_ADD2", "M_P_GROWER_CITY", "M_P_GROWER_COUNTRY_SUBDIV", "M_P_GROWER_PIN", "M_P_GROWER_COUNTRY", "SOURCE_COUNTRY"
                    , "TRANSIT_COUNTRY", "ACCESSORY_STATUS", "HEALTH_CESS_NOTN", "HEALTH_CESS_SLNO", "AIDC_NOTN", "AIDC_NOTN_SLNO", "REM_DECLARATION", "REM_TEXT", "String_Con"); //-Added healthcess by Antony

                    ObjUBO.Xml_A = ConvertDataTableToXML(dt_Change);
                }
                else
                {
                    System.Data.DataTable dt_Change = view.ToTable("Selected", true,
                         "INVOICE_SLNO", "INVOICE_NO", "INVOICE_DATE", "TERMS", "INVOICE_CURRENCY", "ITEM_SLNO", "ITEM_QTY", "ITEM_QTY_CODE"
                        , "ITEM_UNIT_PRICE", "ITEM_DESCRIPTION", "MIS_FREIGHT_RATE", "MIS_FREIGHT_CHARGES", "MIS_FREIGHT_CURRENCY", "MIS_INSURANCE_RATE", "MIS_INSURANCE_CHARGES", "MIS_INSURANCE_CURRENCY", //"MIS_RATE", comment by ajith
                        "MIS_CHARGES", "MIS_CURRENCY", "CTH_NO"
                        , "RITC_NO", "BCD_NOTN", "BCD_NOTN_SLNO", "CETH_NO", "CVD_NOTN", "CVD_NOTN_SLNO", "GENEARL_DESCRIPTION", "MANUFACTURER", "BRAND", "MODEL", "END_USE_OF_ITEM"
                        , "COUNTRY_OF_ORIGIN", "SCHEME_CODE", "SCHEME_NOTN", "SCHEME_NOTN_SLNO", "LICENSE_NO", "LICENSE_DATE", "EXCEMPTION", "LICENSE_SLNO", "PORT_OF_LICENSE"
                        , "SAPTA_NOTN", "SAPTA_NOTN_SLNO", "AGGREGATE_NOTN"

                        , "AGGREGATE_NOTN_SLNO", "SAFEGUARD_NOTN", "SAFEGUARD_NOTN_SLNO", "PRODUCT_OTHER_DUTY_NOTN", "PRODUCT_OTHER_DUTY_SLNO", "PRODUCT_OTHER_DUTY_RATE"
                        , "IGST_LEVY_NOTN", "IGST_LEVY_SLNO", "IGST_LEVY_EXCEMPTION_NOTN", "IGST_LEVY_EXCEMPTION_SLNO", "IGST_LEVY_COMPENSATION_CESS_NOTN"
                        , "IGST_LEVY_COMPENSATION_CESS_SLNO", "IGST_LEVY_EXCEPTION_CC_NOTN", "IGST_LEVY_EXCEMPTION_CC_SLNO", "LEVY_EXCEMPTION_NOTN_TYPE", "LEVY_EXCEPTION_CC_NOTN_TYPE"
                        , "SOCIAL_WELFARE_NOTN", "SOCIAL_WELFARE_NOTN_SLNO", "INFO_MSR", "INFO_UQC", "CTH_QTY1", "CTH_QTY1_CODE", "ANTI_DUMPING_NOTN", "ANTI_DUMPING_NOTN_SLNO", "CTH_SLNO", "CTH_SUPPLIER_SLNO", "CTH_QTY"
                        , "CENTRAL_EXCISE_FLAG", "M_P_GROWER_ADD1", "M_P_GROWER_ADD2", "M_P_GROWER_CITY", "M_P_GROWER_COUNTRY_SUBDIV", "M_P_GROWER_PIN", "M_P_GROWER_COUNTRY", "SOURCE_COUNTRY"
                        , "TRANSIT_COUNTRY", "ACCESSORY_STATUS", "HEALTH_CESS_NOTN", "HEALTH_CESS_SLNO", "AIDC_NOTN", "AIDC_NOTN_SLNO", "REM_DECLARATION", "REM_TEXT"); //-Added healthcess by Antony);

                    ObjUBO.Xml_A = ConvertDataTableToXML(dt_Change);
                }

              
                ObjUBO.Xml_B = ConvertDataTableToXML(dt_SAPTA_RATE);
                ObjUBO.Xml_C = ConvertDataTableToXML(dt_Ex_Rate);
                ObjUBO.Xml_D = ConvertDataTableToXML(dt_SCHEME_CODE);
                ObjUBO.Xml_E = ConvertDataTableToXML(dt_LEVY);
                ObjUBO.Xml_F = ConvertDataTableToXML(dt_COUNTRY);
                ObjUBO.Xml_G = ConvertDataTableToXML(dt_SIMS);
                //ObjUBO.SHIPPER_NAME = txt_SupplierName_Gen;
                ObjUBO.SHIPPER_NAME = ConvertDataTableToXML(dt);
                ObjUBO.Xml_FTA = ConvertDataTableToXML(dt_Fta);
                ObjUBO.Xml_REM = ConvertDataTableToXML(dt_REM1);

                ObjUBO.Tr_Mode = HttpContext.Current.Session["get_SIMS_Tr_mode"].ToString();
                ObjUBO.flag = "Gen_Excel_Upload";
                ds = IXL.IMP_Gen_XL_DML(ObjUBO);

                

                HttpContext.Current.Session.Remove("ds_Excel_upload");
                HttpContext.Current.Session.Remove("get_SAPTA_RATE_ALL");
                HttpContext.Current.Session.Remove("Get_Ex_Rate");
                HttpContext.Current.Session.Remove("Get_SCHEME_CODE");
                HttpContext.Current.Session.Remove("Get_LEVY");
                HttpContext.Current.Session.Remove("Get_COUNTRY");

                HttpContext.Current.Session.Remove("get_SIMS");
                HttpContext.Current.Session.Remove("get_SIMS_Tr_mode");
                HttpContext.Current.Session.Remove("get_REM");



                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (COMPANY_IDD == "10" || COMPANY_IDD == "293" || COMPANY_IDD == "480" || COMPANY_IDD == "1011" || COMPANY_IDD == "1019" || COMPANY_IDD == "1176" || COMPANY_IDD == "2145" || COMPANY_IDD == "2373" || COMPANY_IDD == "3004" || COMPANY_IDD == "3010" || COMPANY_IDD == "3196" || COMPANY_IDD == "3267")//Capricorn
                    {
                        Transaction Transact = new Transaction();
                        Transact.Imp_Job_Logs_All_Details(Connection.IMP_Jobno(), "", "", "Invoice_XL_Upload", "S", "Insert");
                    }

                    return "XL Upload Successfully";

                }
                else
                {
                    return "XL Not Upload ! ";
                }
            }
            else
            {
                return "Re Upload XL!";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
            return ex.Message;
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
    //----------------11-05-2020-Antony---------------------
    //protected void btnSaveProduct_Click(object sender, EventArgs e)
    //{
    //    DataTable dt = new DataTable();
    //    if (gv_Item_Details.Rows.Count != 0)
    //    {
    //        for (int i = 0; i < gv_Item_Details.HeaderRow.Cells.Count; i++)
    //        {
    //            if (i == 5) {
    //                gv_Item_Details.HeaderRow.Cells[i].Text = "Supplier_Name";
    //            }
    //            if (i == 6)
    //            {
    //                gv_Item_Details.HeaderRow.Cells[i].Text = "Third_Party_Name";
    //            }
    //            dt.Columns.Add(gv_Item_Details.HeaderRow.Cells[i].Text);
    //        }

    //        foreach (GridViewRow row in gv_Item_Details.Rows)
    //        {
    //            DataRow dr = dt.NewRow();
    //            for (int j = 0; j < row.Cells.Count; j++)
    //            {
    //                dr[gv_Item_Details.HeaderRow.Cells[j].Text] = row.Cells[j].Text;

    //                if (j == 5 || j == 6)
    //                {
    //                    if (j == 5)
    //                    {
    //                        TextBox txt_SupplierName = row.FindControl("txt_SupplierName_Gen1") as TextBox;
    //                        dr[gv_Item_Details.HeaderRow.Cells[j].Text] = txt_SupplierName.Text;

    //                    }
    //                    else {
    //                        TextBox txt_ThirdParty = row.FindControl("txt_Third_Party_Name") as TextBox;
    //                        dr[gv_Item_Details.HeaderRow.Cells[j].Text] = txt_ThirdParty.Text;
    //                    }
                          
    //                }
    //                else
    //                {
    //                    dr[gv_Item_Details.HeaderRow.Cells[j].Text] = row.Cells[j].Text;
                    
    //                }

    //            }
    //            dt.Rows.Add(dr);
    //        }
            
    //    }
    //    string returnmsg = IMP_Excel_Upload(txt_SupplierName_Gen.Text, dt);
    //    Alert_msg(returnmsg);

    //}



    protected void btnSaveProduct_Click(object sender, EventArgs e)
    {
        Check_Duplicate_Invoice_Before_Import();
    }

    private void Check_Duplicate_Invoice_Before_Import()
    {
        try
        {
            DataTable dtExcel = null;
            object sessObj = Session["ds_Excel_upload"];

            if (sessObj is DataTable)
            {
                dtExcel = (DataTable)sessObj;
            }
            else if (sessObj is DataSet)
            {
                DataSet dsTmp = (DataSet)sessObj;
                if (dsTmp.Tables.Count > 0)
                    dtExcel = dsTmp.Tables[0];
            }

            if (dtExcel == null || dtExcel.Rows.Count == 0)
            {
                Alert_msg("Upload Ur Excel file.");
                return;
            }

            if (!dtExcel.Columns.Contains("INVOICE_NO"))
            {
                Save_Import_Excel();
                return;
            }

            string currentJob = Connection.IMP_Jobno().ToString().Trim();

            DataView view = new DataView(dtExcel);
            DataTable dtInv = view.ToTable(true, "INVOICE_NO");

            StringBuilder duplicateMsg = new StringBuilder();

            foreach (DataRow r in dtInv.Rows)
            {
                string invNo = r["INVOICE_NO"].ToString().Trim();
                if (invNo == "") continue;

                string result = Get_Duplicate_InvoiceNo(invNo, currentJob);

                if (result != null && result.IndexOf("~~") != -1)
                {
                    string jobnos = result.Split(
                        new string[] { "~~" }, StringSplitOptions.None)[0];

                    string otherJobs = "";
                    foreach (string j in jobnos.Split(','))
                    {
                        if (j.Trim() != "" && j.Trim() != currentJob)
                            otherJobs += (otherJobs == "" ? "" : ",") + j.Trim();
                    }

                    if (otherJobs != "")
                    {
                        duplicateMsg.Append("Invoice No : " + invNo +
                            " - JobNumber : " + otherJobs + "\\n");
                    }
                }
            }

            if (duplicateMsg.Length > 0)
            {
                string msg = "Invoice No Already Exists!\\n" +
                             duplicateMsg.ToString() +
                             "\\nDo you want to Proceed further?";
                msg = msg.Replace("'", "\\'");

                string script = "if(confirm('" + msg + "'))" +
                    "{ document.getElementById('" +
                    btn_ConfirmImport.ClientID + "').click(); }";

                ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "DupInvConfirmImport", script, true);
            }
            else
            {
                Save_Import_Excel();
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog("DupCheck: " + ex.Message);
        }
    }

    private void Save_Import_Excel()
    {
        try
        {
            DataTable dt = new DataTable();
            if (gv_Item_Details.Rows.Count != 0)
            {
                for (int i = 0; i < gv_Item_Details.HeaderRow.Cells.Count; i++)
                {
                    if (i == 5)
                    {
                        gv_Item_Details.HeaderRow.Cells[i].Text = "Supplier_Name";
                    }
                    if (i == 6)
                    {
                        gv_Item_Details.HeaderRow.Cells[i].Text = "Third_Party_Name";
                    }
                    dt.Columns.Add(gv_Item_Details.HeaderRow.Cells[i].Text);
                }
                foreach (GridViewRow row in gv_Item_Details.Rows)
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < row.Cells.Count; j++)
                    {
                        dr[gv_Item_Details.HeaderRow.Cells[j].Text] = row.Cells[j].Text;
                        if (j == 5 || j == 6)
                        {
                            if (j == 5)
                            {
                                TextBox txt_SupplierName = row.FindControl("txt_SupplierName_Gen1") as TextBox;
                                dr[gv_Item_Details.HeaderRow.Cells[j].Text] = txt_SupplierName.Text;
                            }
                            else
                            {
                                TextBox txt_ThirdParty = row.FindControl("txt_Third_Party_Name") as TextBox;
                                dr[gv_Item_Details.HeaderRow.Cells[j].Text] = txt_ThirdParty.Text;
                            }
                        }
                        else
                        {
                            dr[gv_Item_Details.HeaderRow.Cells[j].Text] = row.Cells[j].Text;
                        }
                    }
                    dt.Rows.Add(dr);
                }
            }
            string returnmsg = IMP_Excel_Upload(txt_SupplierName_Gen.Text, dt);
            Alert_msg(returnmsg);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }


    protected void btn_ConfirmImport_Click(object sender, EventArgs e)
    {
        try
        {
            Save_Import_Excel();
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    [System.Web.Services.WebMethod]
    public static string Get_Duplicate_InvoiceNo(string custid, string Jobno)
    {
        string InvoiceNo = "";
        try
        {
            if (custid != "")
            {
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();

                // custid = Auto.Country_Master_FromClientSide_Calling(custid);
                Auto.Ename = "IMPORT_DUPLICATE_INVOICENO";
                Auto.Enamesearch = custid;
                ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["INVOICE_NO"].ToString() != "")
                    {
                        if (ds.Tables[0].Rows[0]["INVOICE_NO"].ToString() != Jobno)
                        {
                            InvoiceNo = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString() + "~~";
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return InvoiceNo;
    }





    private void get_SIMS(DataSet d)
    {
        if (d.Tables[0].Rows.Count > 0)
        {
            Session["get_SIMS"] = d.Tables[0];
            Session["get_SIMS_Tr_mode"] = d.Tables[1].Rows[0][0].ToString();
        }
        else
        {
            DataTable dt = new DataTable();
            Session["get_SIMS"] = dt;
            Session["get_SIMS_Tr_mode"] = "";
        }
    }

    //----------------------------------------Diana-------------------------------------------//

   
    protected void Imp_Supplier_QS_Search_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            for (int i = 0; i < drv.DataView.Table.Columns.Count; i++)
            {
                e.Row.Attributes["onclick"] = "QuickSearch_bind(this,'supplier');";
                e.Row.Style.Add("cursor", "pointer");
               
            }
            

        }
    }
    protected void Imp_Third_Party_QS_Search_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            for (int i = 0; i < drv.DataView.Table.Columns.Count; i++)
            {
                e.Row.Attributes["onclick"] = "QuickSearch_bind(this,'ThirdParty');";
                e.Row.Style.Add("cursor", "pointer");
            }

        }
    
    }

    private static readonly string[] MANDATORY_COLUMNS = new string[]
    {
        "INVOICE_SLNO", "INVOICE_NO", "INVOICE_DATE", "TERMS",  "INVOICE_CURRENCY", "ITEM_SLNO",  "ITEM_QTY", "ITEM_QTY_CODE", "ITEM_UNIT_PRICE", "ITEM_DESCRIPTION",
        "GENEARL_DESCRIPTION", "CTH_NO", "RITC_NO", "CETH_NO", "INFO_MSR", "INFO_UQC", "MANUFACTURER", "BRAND", "MODEL", "END_USE_OF_ITEM", "COUNTRY_OF_ORIGIN", "SCHEME_CODE"
    };

    private bool IsBlankCell(object cellValue)
    {
        if (cellValue == null || cellValue == DBNull.Value)
            return true;
        string strVal = cellValue.ToString().Trim();
        return string.IsNullOrWhiteSpace(strVal) || strVal.Equals("nan", StringComparison.OrdinalIgnoreCase) || strVal.Equals("-", StringComparison.OrdinalIgnoreCase);
    }

    private DataSet ValidateMandatoryFields(DataTable dtt)
    {
        DataSet dsMandatoryErr = new DataSet();
        DataTable dtErrors = new DataTable("MandatoryErrors");
        dtErrors.Columns.Add("INVOICE_SLNO", typeof(string));        
        dtErrors.Columns.Add("ERROR_DESCRIPTION", typeof(string));
        dtErrors.Columns.Add("COLUMN_NAME", typeof(string));
        dtErrors.Columns.Add("DATA", typeof(string));

        dsMandatoryErr.Tables.Add(dtErrors);
        foreach (DataColumn col in dtt.Columns)
        {
            col.ColumnName = col.ColumnName.Trim();
        }
        
        foreach (string colName in MANDATORY_COLUMNS)
        {
            if (!dtt.Columns.Contains(colName))
            {
                DataRow missingCol = dtErrors.NewRow();
                missingCol["INVOICE_SLNO"] = "N/A";                
                missingCol["ERROR_DESCRIPTION"] = "Required column missing";
                missingCol["COLUMN_NAME"] = colName;
                missingCol["DATA"] = "";
                dtErrors.Rows.Add(missingCol);
            }
        }

        if (dtErrors.Rows.Count > 0)
            return dsMandatoryErr;
        
        for (int i = 0; i < dtt.Rows.Count; i++)
        {
            DataRow row = dtt.Rows[i];
            int excelRow = i + 2;            
            bool entireRowBlank = true;
            foreach (string col in MANDATORY_COLUMNS)
            {
                if (!IsBlankCell(row[col]))
                {
                    entireRowBlank = false;
                    break;
                }
            }
            if (entireRowBlank) continue; 
            string invoiceSlNo = IsBlankCell(row["INVOICE_SLNO"]) ? "" : row["INVOICE_SLNO"].ToString().Trim();            
            foreach (string colName in MANDATORY_COLUMNS)
            {
                if (IsBlankCell(row[colName]))
                {
                    DataRow errRow = dtErrors.NewRow();
                    errRow["INVOICE_SLNO"] = string.IsNullOrEmpty(invoiceSlNo) ? "Row " + excelRow : invoiceSlNo;                    
                    errRow["ERROR_DESCRIPTION"] = " value is required";
                    errRow["COLUMN_NAME"] = colName;
                    errRow["DATA"] = "";

                    dtErrors.Rows.Add(errRow);
                }
            }

            decimal price = 0;
            decimal.TryParse(row["ITEM_UNIT_PRICE"].ToString().Trim(), out price);
            if (price == 0 )
            {
                DataRow errRow = dtErrors.NewRow();
                errRow["INVOICE_SLNO"] = string.IsNullOrEmpty(invoiceSlNo) ? "Row " + excelRow : invoiceSlNo; 
                errRow["ERROR_DESCRIPTION"] = "ITEM_UNIT_PRICE cannot be zero";
                errRow["COLUMN_NAME"] = "ITEM_UNIT_PRICE";
                errRow["DATA"] = row["ITEM_UNIT_PRICE"].ToString();
                dtErrors.Rows.Add(errRow);
            }
        }
        return dsMandatoryErr;
    }
}


