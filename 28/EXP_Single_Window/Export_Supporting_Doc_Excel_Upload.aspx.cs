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


public partial class Export_Supporting_Doc_Excel_Upload : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    eroyalmaster erm = new eroyalmaster();
    adminmaster adm = new adminmaster();
    DataTable dt = new DataTable();
    Export_Licence Export_license = new Export_Licence();
    AdminMasterDetails admin = new AdminMasterDetails();
    EXP_Supportingdoc Sup_Doc = new EXP_Supportingdoc();
    UserBO ObjUBO = new UserBO();
    DataSet temp = new DataSet();
    DataTable VALID = new DataTable();
    DataTable INVALID = new DataTable();
    DataTable dtest = new DataTable();
    DataTable selected;
    DateTime parsed;
    DataTable distinctDT = new DataTable();





    public int i;
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, EXPORT_JOBNO, SLNO, INVOICE_SLNO, ITEM_SLNO;
    public int Exp_sup_id_Max;
    public string DOC_ISSUING_PARTY_NAME, DOC_ISSUING_PARTY_NAME_ADD1, DOC_ISSUING_PARTY_NAME_ADD2, DOC_ISSUING_PARTY_CITY, DOC_ISSUING_PARTY_PIN;


    DataSet ds = new DataSet();
    DataSet dsXML = new DataSet();
    DataTable dt_Avail = new DataTable();
    DataTable dtt = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet ds_scheme = new DataSet();

    string file_ext = "";
    public string errorFolder = "", logFileName = "";

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
        if (Session["EXPORT_JOBNO"] != null)
        {
            EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();
            INVOICE_SLNO = Session["Inv_SL_No"].ToString();
            ITEM_SLNO = Session["Item_SLNo"].ToString();
        }

    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Export Sup Doc Excel Upload', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Export Sup Doc Excel Upload', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Get_Sup_Doc_MaxID()
    {
        ObjUBO.SW_STMT_ID = "";
        ObjUBO.Unique_Document_No = "0";
        ObjUBO.flag = "autoid";
        ObjUBO.WORKING_PERIOD = Working_Period;

        ds = Sup_Doc.Exp_Sup_Doc_Xl_Upload(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Exp_sup_id_Max = Convert.ToInt32(ds.Tables[0].Rows[0]["SW_STMT_ID"].ToString());
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
            DataTable distinctDT = SelectDistinct(ds.Tables[0], "IRN_NO");

            //if (ds.Tables[0].Rows.Count != distinctDT.Rows.Count)
            //{
            //    string msg = "  Duplicate Records in IRN No" + Environment.NewLine + " -------------------------------------------------------" + Environment.NewLine + "   IRN No  " + Environment.NewLine;
            //    for (int j = 0; j <= dtt.Rows.Count - 1; j++)
            //    {
            //        msg += dtt.Rows[j][0].ToString() + Environment.NewLine;
            //    }

            //    //msg = " Inv no : " + dss.Tables[0].Rows[s][38].ToString() + "  -  Already Exists";
            //    hdinvno.Value = msg;
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Avail_InvoiceNo_Alert_Msg()", true);
            //}
            //if (ds.Tables[0].Rows.Count == distinctDT.Rows.Count)
            //{
            DataSet d = new DataSet();
            ObjUBO.JOBNO = EXPORT_JOBNO;
            ObjUBO.flag = "Excel_Avail";
            ObjUBO.BRANCH_CODE = currentbranch;


            d = Sup_Doc.Exp_Sup_Doc_Xl_Upload(ObjUBO);
            //DataTable distinctINVIT = SelectDistinct(d.Tables[1], "ITEM_SLNO");
            //DataTable distinctSUPIT = SelectDistinct(ds.Tables[0], "ITEM_SLNO");


            //if (distinctINVIT.Rows.Count != distinctSUPIT.Rows.Count)
            //{
            //}
            //else
            //{
            if (d.Tables[0].Rows.Count > 0)
            {
                MP_U.Show();
            }
            else
            {
                Excel_Upload_load(file_ext);
            }
            //}


            //}







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
        ObjUBO.JOBNO = EXPORT_JOBNO;
        ObjUBO.flag = "Delete_Excel";
        ObjUBO.BRANCH_CODE = currentbranch;
        d = Sup_Doc.Exp_Sup_Doc_Xl_Upload(ObjUBO);

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
        Get_Sup_Doc_MaxID();
        DataSet dss = new DataSet();
        ObjUBO.JOBNO = EXPORT_JOBNO;
        ObjUBO.INVOICE_SLNO = INVOICE_SLNO;
        ObjUBO.ITEM_SLNO = ITEM_SLNO;
        ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
        ObjUBO.Ename = "SUP_DOC_Select";
        dss = Sup_Doc.SingleWindow_Select(ObjUBO);
        DataSet Inv_ds = new DataSet();

        //ds.Tables.Add("Invoice_dt");
        Inv_ds = ds = (DataSet)ViewState["ds_Excel_upload"];
        if (dss.Tables[1].Rows[0]["ADDRESS5"] == "" && ds.Tables[0].Rows[0]["ISS_PARTY_PIN"].ToString() == "")
        {
            Alert_msg("Check Your Issuing Party Pin No");


        }
        else
        {



            int a = 0, b = 1, c = 1;
            ds.Tables[0].Rows.Add();
            if (ds.Tables[0].Rows.Count > a)
            {
                #region create dataset column
                dsXML.Tables.Add("EXP_SW_SUP_DOC");
                dsXML.Tables[0].Columns.Add("SW_STMT_ID");
                dsXML.Tables[0].Columns.Add("JOBNO");
                dsXML.Tables[0].Columns.Add("INVOICE_SLNO");
                dsXML.Tables[0].Columns.Add("ITEM_SLNO");
                dsXML.Tables[0].Columns.Add("SLNO");
                dsXML.Tables[0].Columns.Add("UNIQUE_DOC_NUMBER");
                dsXML.Tables[0].Columns.Add("DOC_TYPE_CODE");
                dsXML.Tables[0].Columns.Add("DOC_ISSUING_PARTY_CODE");
                dsXML.Tables[0].Columns.Add("DOC_ISSUING_PARTY_NAME_ADD1");
                dsXML.Tables[0].Columns.Add("DOC_ISSUING_PARTY_NAME_ADD2");
                dsXML.Tables[0].Columns.Add("DOC_ISSUING_PARTY_CITY");
                dsXML.Tables[0].Columns.Add("DOC_ISSUING_PARTY_PIN");
                dsXML.Tables[0].Columns.Add("DOC_REF_NUMBER");
                dsXML.Tables[0].Columns.Add("PLACE_OF_ISSUE");
                dsXML.Tables[0].Columns.Add("DOC_ISSUE_DATE");
                dsXML.Tables[0].Columns.Add("DOC_EXPIRY_DATE");
                dsXML.Tables[0].Columns.Add("BENEFICIARY_PARTY_CODE");
                dsXML.Tables[0].Columns.Add("BENEFICIARY_PARTY_ADDRESS1");
                dsXML.Tables[0].Columns.Add("BENEFICIARY_PARTY_ADDRESS2");
                dsXML.Tables[0].Columns.Add("BENEFICIARY_PARTY_CITY");
                dsXML.Tables[0].Columns.Add("BENEFICIARY_PARTY_PIN");
                dsXML.Tables[0].Columns.Add("FILE_TYPE");
                dsXML.Tables[0].Columns.Add("BRANCH_CODE");
                dsXML.Tables[0].Columns.Add("WORKING_PERIOD");
                dsXML.Tables[0].Columns.Add("CREATEDON");
                dsXML.Tables[0].Columns.Add("CREATEDBY");
                dsXML.Tables[0].Columns.Add("MODIFIEDBY");
                dsXML.Tables[0].Columns.Add("MODIFIEDON");
                dsXML.Tables[0].Columns.Add("DOC_ISSUING_PARTY_NAME");
                dsXML.Tables[0].Columns.Add("BENEFICIARY_PARTY_NAME");
                dsXML.Tables[0].Columns.Add("ICEGATE_ID");
                dsXML.Tables[0].Columns.Add("ICEGATE_DOC_FILE_NAME");
                dsXML.Tables[0].Columns.Add("AMENDMENT_TYPE");
                dsXML.Tables[0].Columns.Add("AMENDMENT_STATUS");

                dsXML.Tables[0].Columns.Add("SELECT_TYPE");





                #endregion

                dt_Avail.Columns.Add("INVOICE_SLNO");
                dt_Avail.Columns.Add("ITEM_SLNO");
                dt_Avail.Columns.Add("UNIQUE_DOC_NUMBER");
                //--------------------End Sup doc Details--------------------------//
                if (file_ext == ".xls" || file_ext == ".xlsx")
                {
                    #region read Excel_Format

                    while (ds.Tables[0].Rows[a][0] != System.DBNull.Value)
                    {
                        i = Check_Avail_Sup_Doc(ds.Tables[0].Rows[a][2].ToString().Trim());

                        if (i == 1)
                        {
                            DataRow dr = dsXML.Tables[0].NewRow();

                            dr["SW_STMT_ID"] = Exp_sup_id_Max;
                            dr["JOBNO"] = EXPORT_JOBNO;
                            dr["INVOICE_SLNO"] = ds.Tables[0].Rows[a][0].ToString().Trim();
                            dr["ITEM_SLNO"] = ds.Tables[0].Rows[a][1].ToString().Trim();
                            dr["SELECT_TYPE"] = ds.Tables[0].Rows[a][2].ToString().Trim();

                            dr["SLNO"] = b;
                            dr["UNIQUE_DOC_NUMBER"] = ds.Tables[0].Rows[a][3].ToString().Trim();

                            if (ds.Tables[0].Rows[a][5].ToString().Contains("-"))
                            {
                                string[] sp = ds.Tables[0].Rows[a][5].ToString().Split('-');
                                dr["DOC_TYPE_CODE"] = sp[0].Trim();
                            }
                            else
                            {

                                dr["DOC_TYPE_CODE"] = ds.Tables[0].Rows[a][5].ToString().Trim();
                            }


                            if (ds.Tables[0].Rows[a][9] != System.DBNull.Value)
                            {
                                dr["DOC_ISSUING_PARTY_NAME"] = ds.Tables[0].Rows[a][9].ToString().Trim();
                                dr["DOC_ISSUING_PARTY_CODE"] = "";
                                dr["DOC_ISSUING_PARTY_NAME_ADD1"] = ds.Tables[0].Rows[a][10].ToString().Trim();
                                dr["DOC_ISSUING_PARTY_NAME_ADD2"] = ds.Tables[0].Rows[a][11].ToString().Trim();
                                dr["DOC_ISSUING_PARTY_CITY"] = ds.Tables[0].Rows[a][12].ToString().Trim();
                                dr["DOC_ISSUING_PARTY_PIN"] = ds.Tables[0].Rows[a][13].ToString().Trim();

                            }
                            else
                            {

                                if (dss.Tables[1].Rows.Count > 0)
                                {


                                    dr["DOC_ISSUING_PARTY_NAME"] = dss.Tables[1].Rows[0]["EXPORTER_NAME"].ToString().Replace("&amp;", "&").Replace("amp;", "&").Trim();
                                    dr["DOC_ISSUING_PARTY_NAME_ADD1"] = dss.Tables[1].Rows[0]["ADDRESS1"].ToString().Replace("&amp;", "&");
                                    dr["DOC_ISSUING_PARTY_NAME_ADD2"] = dss.Tables[1].Rows[0]["ADDRESS2"].ToString().Replace("&amp;", "&");

                                    string DOC_ISSUING_PARTY_CITY = "";
                                    DOC_ISSUING_PARTY_CITY = dss.Tables[1].Rows[0]["ADDRESS3"].ToString() + "," + dss.Tables[1].Rows[0]["ADDRESS4"].ToString();
                                    if (DOC_ISSUING_PARTY_CITY.Length > 35)
                                    {
                                        DOC_ISSUING_PARTY_CITY = DOC_ISSUING_PARTY_CITY.Substring(0, 35);
                                    }
                                    dr["DOC_ISSUING_PARTY_CITY"] = DOC_ISSUING_PARTY_CITY;
                                    dr["DOC_ISSUING_PARTY_PIN"] = dss.Tables[1].Rows[0]["ADDRESS5"].ToString();

                                }

                            }
                            if (ds.Tables[0].Rows[a][14] != System.DBNull.Value)
                            {
                                dr["BENEFICIARY_PARTY_NAME"] = ds.Tables[0].Rows[a][14].ToString().Trim();
                                dr["BENEFICIARY_PARTY_CODE"] = "";
                                dr["BENEFICIARY_PARTY_ADDRESS1"] = ds.Tables[0].Rows[a][15].ToString().Trim();
                                dr["BENEFICIARY_PARTY_ADDRESS2"] = ds.Tables[0].Rows[a][16].ToString().Trim();
                                dr["BENEFICIARY_PARTY_CITY"] = ds.Tables[0].Rows[a][17].ToString().Trim();
                                dr["BENEFICIARY_PARTY_PIN"] = ds.Tables[0].Rows[a][18].ToString().Trim();
                            }
                            else
                            {

                                if (dss.Tables[1].Rows.Count > 0)
                                {
                                    dr["BENEFICIARY_PARTY_NAME"] = dss.Tables[1].Rows[0]["CONSIGNEE_NAME"].ToString().Replace("&amp;", "&").Replace("amp;", "&").Trim();
                                    dr["BENEFICIARY_PARTY_ADDRESS1"] = dss.Tables[1].Rows[0]["CONSIGNEE_ADD1"].ToString().Replace("&amp;", "&");
                                    dr["BENEFICIARY_PARTY_ADDRESS2"] = dss.Tables[1].Rows[0]["CONSIGNEE_ADD2"].ToString().Replace("&amp;", "&");
                                    //string BENIFICIARY = dss.Tables[1].Rows[0]["CONSIGNEE_ADD3"].ToString() + "," + dss.Tables[1].Rows[0]["CONSIGNEE_ADD4"].ToString();
                                    //string CUTSTRING = BENIFICIARY.Substring(0, 35);
                                    string BENEFICIARY_PARTY_CITY = "";
                                    BENEFICIARY_PARTY_CITY = dss.Tables[1].Rows[0]["CONSIGNEE_ADD3"].ToString() + "," + dss.Tables[1].Rows[0]["CONSIGNEE_ADD4"].ToString();
                                    if (BENEFICIARY_PARTY_CITY.Length > 35)
                                    {
                                        BENEFICIARY_PARTY_CITY = BENEFICIARY_PARTY_CITY.Substring(0, 35);
                                    }
                                    dr["BENEFICIARY_PARTY_CITY"] = BENEFICIARY_PARTY_CITY;
                                    if (dss.Tables[1].Rows[0]["ADDRESS5"] != System.DBNull.Value)
                                    {
                                        dr["BENEFICIARY_PARTY_PIN"] = "000000";
                                        
                                    }
                                    else
                                    {
                                        dr["BENEFICIARY_PARTY_PIN"] = dss.Tables[1].Rows[0]["CONSIGNEE_ADD5"].ToString();
                                    }

                                }
                            }

                            dr["DOC_REF_NUMBER"] = ds.Tables[0].Rows[a][4].ToString().Trim();
                            dr["PLACE_OF_ISSUE"] = ds.Tables[0].Rows[a][6].ToString().Trim();

                            //dr["DOC_ISSUE_DATE"] = ds.Tables[0].Rows[a][6].ToString().Trim();
                            if (ds.Tables[0].Rows[a][7] != System.DBNull.Value)
                            { 
                                DateTime s1 = System.Convert.ToDateTime(ds.Tables[0].Rows[a][7].ToString().Trim());
                                DateTime date = (s1);
                                String frmdt = date.ToString("dd/MM/yyyy");
                                String.Format("{0:MM/dd/yyyy}", dt);

                            dr["DOC_ISSUE_DATE"] = frmdt.ToString();
                            }
                            else
                            
                            {
                                dr["DOC_ISSUE_DATE"] = "01/01/1900";

                            }



                            if (ds.Tables[0].Rows[a][8] != System.DBNull.Value)
                            {
                                DateTime s2 = System.Convert.ToDateTime(ds.Tables[0].Rows[a][8].ToString().Trim());
                                DateTime date1 = (s2);
                                String frmdt1 = date1.ToString("dd/MM/yyyy");
                                String.Format("{0:MM/dd/yyyy}", dt);
                                dr["DOC_EXPIRY_DATE"] = frmdt1.ToString();
                            }
                            else
                            {
                                dr["DOC_EXPIRY_DATE"] = "01/01/1900";

                            }

                            dr["FILE_TYPE"] = "PDF";
                            dr["BRANCH_CODE"] = currentbranch;
                            dr["WORKING_PERIOD"] = Working_Period;
                            dr["CREATEDON"] = LoginDate;
                            dr["CREATEDBY"] = currentuser;
                            dr["MODIFIEDBY"] = currentuser;
                            dr["MODIFIEDON"] = LoginDate;
                            dr["AMENDMENT_TYPE"] = null;
                            dr["AMENDMENT_STATUS"] = null;
                            dr["ICEGATE_DOC_FILE_NAME"] = ds.Tables[0].Rows[a][20].ToString().Trim(); ;

                            if (ds.Tables[0].Rows[a][19] != System.DBNull.Value)
                            {
                                dr["ICEGATE_ID"] = ds.Tables[0].Rows[a][19].ToString().Trim();
                            }
                            else
                            {
                                dr["ICEGATE_ID"] = Connection.Get_EXP_Icegate_Id("");
                            }

                            //if (distinctDT.Rows.Count == 0)
                            //{
                            //    distinctDT = SelectDistinct(ds.Tables[0], "IRN_NO");
                            //    if (ds.Tables[0].Rows.Count != distinctDT.Rows.Count)
                            //    {
                            //        //DataRow invalid = distinctDT.NewRow();
                            //        //invalid["ERROR"] = distinctDT.Rows.ToString();
                            //        //INVALID.Columns.Add("ERROR") = distinctDT;


                            //    }
                            //}
                            dsXML.Tables[0].Rows.Add(dr);

                            System.Data.DataView view = new System.Data.DataView(dsXML.Tables[0]);
                            selected = view.ToTable("Selected", false, "INVOICE_SLNO", "ITEM_SLNO", "UNIQUE_DOC_NUMBER", "DOC_REF_NUMBER", "DOC_TYPE_CODE", "PLACE_OF_ISSUE", "DOC_ISSUE_DATE", "DOC_EXPIRY_DATE", "DOC_ISSUING_PARTY_NAME", "DOC_ISSUING_PARTY_NAME_ADD1", "DOC_ISSUING_PARTY_NAME_ADD2", "DOC_ISSUING_PARTY_CITY", "DOC_ISSUING_PARTY_PIN", "BENEFICIARY_PARTY_NAME", "BENEFICIARY_PARTY_ADDRESS1", "BENEFICIARY_PARTY_ADDRESS2", "BENEFICIARY_PARTY_CITY", "BENEFICIARY_PARTY_PIN", "ICEGATE_ID", "ICEGATE_DOC_FILE_NAME", "SELECT_TYPE");






                        }

                        else
                        {
                            dt_Avail.Rows.Add(ds.Tables[0].Rows[a][0].ToString().Trim(), ds.Tables[0].Rows[a][1].ToString(), ds.Tables[0].Rows[a][2].ToString().Trim());
                        }


                        a++;
                        b++;

                        //a = b;
                        Exp_sup_id_Max++;
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
                                admin.SqlBulk_Upload_Product("EXP_SW_SUP_DOC", dsXML.Tables[0], Session["currentcomp_db"].ToString());
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
        ObjUBO.JOBNO = EXPORT_JOBNO;
        ObjUBO.Unique_Document_No = UNIQUE_DOC_NUMBER;
        ObjUBO.flag = "Check_Avail";
        ObjUBO.WORKING_PERIOD = Working_Period;
        ObjUBO.BRANCH_CODE = currentbranch;

        DataTable TEMP1 = ds.Tables[0];
        dss = Sup_Doc.Exp_Sup_Doc_Xl_Upload(ObjUBO);
        i = Sup_Doc.result;

        return i;
    }

    public void DATA_CHECK(DataTable dsXML_Excel)
    {
        DataSet dck = new DataSet();




        ObjUBO.SW_STMT_ID = "";

        ObjUBO.flag = "Data_Check";
        ObjUBO.WORKING_PERIOD = Working_Period;

        dck = Sup_Doc.Exp_Sup_Doc_Xl_Upload(ObjUBO, dsXML_Excel);

        if (dck.Tables[1].Columns.Count > 3)
        {
            if (dck.Tables[1].Rows.Count > 0)
            {
                VALID.Columns.Add("Inv_SlNo");
                VALID.Columns.Add("Itm_SlNo");
                VALID.Columns.Add("Irn_No");
                VALID.Columns.Add("DOC_TYPE_CODE");
                VALID.Columns.Add("ERROR");
                for (int i = 0; i <= dck.Tables[1].Rows.Count - 1; i++)
                {

                    string Inv_SlNo = dck.Tables[1].Rows[i]["INVOICE_SLNO"].ToString();
                    string Itm_SlNo = dck.Tables[1].Rows[i]["ITEM_SLNO"].ToString();
                    string Irn_No = dck.Tables[1].Rows[i]["IRN_NO"].ToString();
                    string DOC_TYPE_CODE = dck.Tables[1].Rows[i]["DOC_CODE"].ToString();
                    string ERROR = "";
                    if (dck.Tables[1].Rows[i]["ERROR"].ToString() != "T")
                    {
                        ERROR = dck.Tables[1].Rows[i]["ERROR"].ToString();

                        VALID.Rows.Add(Inv_SlNo, Itm_SlNo, Irn_No, DOC_TYPE_CODE, ERROR);
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
