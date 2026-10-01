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


public partial class Export_Bulk_LicenseUpoad : ThemeClass
{
    EGM EGM = new EGM();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    eroyalmaster erm = new eroyalmaster();
    adminmaster adm = new adminmaster();
    DataTable dt = new DataTable();
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
    int EGM_JOBNO = 0, EGM_SBSLNO = 0;

    DataSet ds = new DataSet();
    DataSet dsXML = new DataSet();
    DataTable dt_Nil = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataSet ds_scheme = new DataSet();


    public string errorFolder = "", logFileName = "", Is_Additional_EGM = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "EGM");

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

        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "EGM");
        
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'EGM Excel Upload', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'EGM Excel Upload', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
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

    protected void btn_Export_BulkUpload_Click(object sender, EventArgs e)
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
        DataSet Inv_ds = new DataSet();
        DataSet ds_data = new DataSet();
        DataSet dt_imo = new DataSet();
        //ds.Tables.Add("Invoice_dt");
        Inv_ds = ds = (DataSet)ViewState["ds_Excel_upload"];
        int a = 0, b = 0, c = 1;
        ds.Tables[0].Rows.Add();
        if (ds.Tables[0].Rows.Count > a)
        {
            #region create dataset column
            dsXML.Tables.Add("EGM_CONSOLIDATE_DETAILS");
            dsXML.Tables[0].Columns.Add("EGM_ID");
            dsXML.Tables[0].Columns.Add("EGM_JOBNO");
            dsXML.Tables[0].Columns.Add("JOBNO");
            dsXML.Tables[0].Columns.Add("JOBDATE");
            dsXML.Tables[0].Columns.Add("ROTATION_NO");
            dsXML.Tables[0].Columns.Add("ROTATION_DATE");
            dsXML.Tables[0].Columns.Add("LINER_NAME");
            dsXML.Tables[0].Columns.Add("VESSEL_NAME");
            dsXML.Tables[0].Columns.Add("IMO_NO");
            dsXML.Tables[0].Columns.Add("VOYAGE_NO");
            dsXML.Tables[0].Columns.Add("SBNO");
            dsXML.Tables[0].Columns.Add("SB_DATE");
            dsXML.Tables[0].Columns.Add("PORT_ORIGIN");
            dsXML.Tables[0].Columns.Add("DESTINATION_PORT");
            dsXML.Tables[0].Columns.Add("GATEWAY_PORT");
            dsXML.Tables[0].Columns.Add("NATURE_OF_CARGO");
            dsXML.Tables[0].Columns.Add("QUATITY");
            dsXML.Tables[0].Columns.Add("UNIT_QTY");
            dsXML.Tables[0].Columns.Add("NO_OF_PKGS");
            dsXML.Tables[0].Columns.Add("EXPORTER_NAME");
            dsXML.Tables[0].Columns.Add("EXPORTER_ADD1");
            dsXML.Tables[0].Columns.Add("EXPORTER_ADD2");
            dsXML.Tables[0].Columns.Add("EXPORTER_ADD3");
            dsXML.Tables[0].Columns.Add("EXPORTER_ADD4");
            dsXML.Tables[0].Columns.Add("CONSIGNEE_NAME");
            dsXML.Tables[0].Columns.Add("CONSIGNEE_ADD1");
            dsXML.Tables[0].Columns.Add("CONSIGNEE_ADD2");
            dsXML.Tables[0].Columns.Add("CONSIGNEE_ADD3");
            dsXML.Tables[0].Columns.Add("CONSIGNEE_ADD4");
            dsXML.Tables[0].Columns.Add("USERID");
            dsXML.Tables[0].Columns.Add("LOGIN_DATE");
            dsXML.Tables[0].Columns.Add("STATUS");
            dsXML.Tables[0].Columns.Add("BRANCHCODE");
            dsXML.Tables[0].Columns.Add("WORKINGPERIOD");
            dsXML.Tables[0].Columns.Add("SB_SLNO");
            dsXML.Tables[0].Columns.Add("STUFFDATE");
            dsXML.Tables[0].Columns.Add("DESCRIPTION");


            //--------------------License Details--------------------------//

            dsXML.Tables.Add("EGM_CONSOLIDATE_CONTAINER_DETAILS");
            dsXML.Tables[1].Columns.Add("EGM_CONID");
            dsXML.Tables[1].Columns.Add("EGM_JOBNO");
            dsXML.Tables[1].Columns.Add("JOBNO");
            dsXML.Tables[1].Columns.Add("SBNO");
            dsXML.Tables[1].Columns.Add("SLNO");
            dsXML.Tables[1].Columns.Add("CONTAINER_NO");
            dsXML.Tables[1].Columns.Add("SIZE");
            dsXML.Tables[1].Columns.Add("TYPE");

            dsXML.Tables[1].Columns.Add("USERID");
            dsXML.Tables[1].Columns.Add("LOGIN_DATE");
            dsXML.Tables[1].Columns.Add("STATUS");
            dsXML.Tables[1].Columns.Add("BRANCHCODE");
            dsXML.Tables[1].Columns.Add("WORKINGPERIOD");
            dsXML.Tables[1].Columns.Add("ROTATION_NO");

            dt_Nil.Columns.Add("Jobno");
            dt_Nil.Columns.Add("SBNo");

            
            #endregion
            //--------------------End License Details--------------------------//
            if (file_ext == ".xls" || file_ext == ".xlsx")
            {

                EGM_JOBNO = Get_MAXID("Get_EGM_JOBNO_MAXID");
                int EGM_Max_ID = Get_MAXID("Get_EGM_MAXID");
                int EGM_Container_Max_ID = Get_MAXID("Get_EGM_Container_MAXID");
                int EGM_SBSLNO = Get_MAXID("Get_EGM_MAX_SLNO");

                //Session["EGMID_excel"] = EGM_JOBNO;

                #region read Excel_Format

                while (ds.Tables[0].Rows[a][0] != System.DBNull.Value)
                {

                    DataRow dr = dsXML.Tables[0].NewRow();

                    dr["EGM_ID"] = EGM_Max_ID;
                    dr["EGM_JOBNO"] = EGM_JOBNO;
                    dr["JOBNO"] = ds.Tables[0].Rows[a][2].ToString();
                    //dr["JOBDATE"] = ds.Tables[0].Rows[a][3].ToString().TrimEnd();
                    dr["ROTATION_NO"] = ds.Tables[0].Rows[a][0].ToString();
                    dr["ROTATION_DATE"] = ds.Tables[0].Rows[a][1].ToString();

                    
                    if (ds.Tables[0].Rows[a][2].ToString() != "")
                    {
                        EGM.EGM_ID = "";
                        EGM.JOBNO = ds.Tables[0].Rows[a][2].ToString();
                        //EGM.SB_SLNO = Convert.ToInt32(hdn_SB_SlNo.Value == string.Empty ? 0 : Convert.ToInt32(hdn_SB_SlNo.Value));
                        EGM.SBNO = ds.Tables[0].Rows[a][3].ToString();
                        EGM.Ename = "Select_EGM_CONSOLIDATE_DETAILS_job_Search";

                        EGM.WORKINGPERIOD = SELECT_BRANCH;
                        ds_data = EGM.EGM_CONSOLIDATE_Select_All();
                        int i = EGM.result;

                        if (ds_data.Tables[0].Rows.Count > 0)
                        {
                            if (i == 1)
                            {
                                dr["JOBDATE"] = ds_data.Tables[0].Rows[0]["JOBDATE"].ToString();
                                dr["SBNO"] = ds_data.Tables[0].Rows[0]["SB_NO"].ToString();
                                dr["SB_DATE"] = ds_data.Tables[0].Rows[0]["SB_DATE"].ToString() == "" ? "01/01/1900" : ds_data.Tables[0].Rows[0]["SB_DATE"].ToString();
                                dr["PORT_ORIGIN"] = ds_data.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                                dr["DESTINATION_PORT"] = ds_data.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();

                                if (Connection.COMPANYID() == "517")
                                {
                                    dr["GATEWAY_PORT"] = "INTUT1";
                                }
                                else
                                {
                                    dr["GATEWAY_PORT"] = ds_data.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                                }

                                dr["EXPORTER_NAME"] = ds_data.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                                dr["EXPORTER_ADD1"] = ds_data.Tables[0].Rows[0]["ADDRESS1"].ToString();
                                dr["EXPORTER_ADD2"] = ds_data.Tables[0].Rows[0]["ADDRESS2"].ToString();
                                dr["EXPORTER_ADD3"] = ds_data.Tables[0].Rows[0]["ADDRESS3"].ToString();
                                dr["EXPORTER_ADD4"] = ds_data.Tables[0].Rows[0]["ADDRESS4"].ToString();
                                dr["CONSIGNEE_NAME"] = ds_data.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                                dr["CONSIGNEE_ADD1"] = ds_data.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();
                                dr["CONSIGNEE_ADD2"] = ds_data.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString();
                                dr["CONSIGNEE_ADD3"] = ds_data.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString();
                                dr["CONSIGNEE_ADD4"] = ds_data.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString();

                                if (ds_data.Tables[2].Rows.Count > 0)
                                {
                                    dr["NATURE_OF_CARGO"] = ds_data.Tables[2].Rows[0]["ANNEX_AIR_NATURE_OF_CARGO"].ToString();
                                    dr["QUATITY"] = ds_data.Tables[2].Rows[0]["ANNEX_AIR_GROSS_WEIGHT"].ToString();
                                    dr["UNIT_QTY"] = ds_data.Tables[2].Rows[0]["ANNEX_AIR_GR_UNIT_CODE"].ToString();
                                    dr["NO_OF_PKGS"] = ds_data.Tables[2].Rows[0]["ANNEX_AIR_TOTAL_PACKAGES"].ToString();
                                }

                                if (ds_data.Tables[3].Rows.Count > 0)
                                {
                                    dr["NATURE_OF_CARGO"] = ds_data.Tables[3].Rows[0]["ANNEX_SEA_NATURE_OF_CARGO"].ToString();
                                    dr["QUATITY"] = ds_data.Tables[3].Rows[0]["ANNEX_SEA_GROSS_WEIGHT"].ToString();
                                    dr["UNIT_QTY"] = ds_data.Tables[3].Rows[0]["ANNEX_SEA_UNIT_MEASUREMENT"].ToString();
                                    dr["NO_OF_PKGS"] = ds_data.Tables[3].Rows[0]["ANNEX_SEA_TOTAL_PACKAGES"].ToString();
                                }

                                if (ds.Tables[0].Rows[a][12].ToString() == "")
                                {
                                    if (ds_data.Tables[4].Rows.Count > 0)
                                    {
                                        dr["DESCRIPTION"] = ds_data.Tables[4].Rows[0][0].ToString();
                                    }
                                }
                                else
                                {
                                    dr["DESCRIPTION"] = ds.Tables[0].Rows[a][12].ToString();
                                }

                                dr["LINER_NAME"] = ds.Tables[0].Rows[a][5].ToString();
                                dr["VESSEL_NAME"] = ds.Tables[0].Rows[a][6].ToString();

                                // get IMO Code from VesselMaster
                                if (ds.Tables[0].Rows[a][6].ToString() != "")
                                {
                                    EGM.EGM_ID = "";
                                    EGM.JOBNO = "";
                                    //EGM.SB_SLNO = Convert.ToInt32(hdn_SB_SlNo.Value == string.Empty ? 0 : Convert.ToInt32(hdn_SB_SlNo.Value));
                                    EGM.ROTATION_NO = ds.Tables[0].Rows[a][6].ToString();
                                    EGM.Ename = "Get_IMOCODE_VesselMaster";

                                    EGM.WORKINGPERIOD = SELECT_BRANCH;
                                    dt_imo = EGM.EGM_CONSOLIDATE_Select_All();

                                    if (dt_imo.Tables[0].Rows.Count > 0)
                                    {
                                        dr["IMO_NO"] = dt_imo.Tables[0].Rows[0][0].ToString();
                                    }
                                }

                                
                                dr["VOYAGE_NO"] = ds.Tables[0].Rows[a][7].ToString();


                                dr["USERID"] = currentuser;
                                dr["LOGIN_DATE"] = LoginDate;
                                dr["STATUS"] = "N";
                                dr["BRANCHCODE"] = currentbranch;
                                dr["WORKINGPERIOD"] = Working_Period;
                                dr["SB_SLNO"] = EGM_SBSLNO;
                                dr["STUFFDATE"] = ds.Tables[0].Rows[a][11].ToString() == string.Empty ? "01/01/1900" : ds.Tables[0].Rows[a][11].ToString();
                                //dr["DESCRIPTION"] = ds.Tables[0].Rows[a][12].ToString();
                            }
                        }
                        else
                        {
                            EGM.EGM_ID = "";
                            EGM.JOBNO = ds.Tables[0].Rows[a][2].ToString();
                            //EGM.SB_SLNO = Convert.ToInt32(hdn_SB_SlNo.Value == string.Empty ? 0 : Convert.ToInt32(hdn_SB_SlNo.Value));
                            EGM.SBNO = ds.Tables[0].Rows[a][3].ToString();
                            EGM.Ename = "Select_EGM_CONSOLIDATE_DETAILS_SB_Search";

                            EGM.WORKINGPERIOD = SELECT_BRANCH;
                            ds_data = EGM.EGM_CONSOLIDATE_Select_All();
                            int ii = EGM.result;

                            if (ds_data.Tables[0].Rows.Count > 0)
                            {

                                if (ii == 1)
                                {
                                    dr["JOBDATE"] = ds_data.Tables[0].Rows[0]["JOBDATE"].ToString();
                                    dr["SBNO"] = ds_data.Tables[0].Rows[0]["SB_NO"].ToString();
                                    dr["SB_DATE"] = ds_data.Tables[0].Rows[0]["SB_DATE"].ToString() == "" ? "01/01/1900" : ds_data.Tables[0].Rows[0]["SB_DATE"].ToString();
                                    dr["PORT_ORIGIN"] = ds_data.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                                    dr["DESTINATION_PORT"] = ds_data.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();

                                    if (Connection.COMPANYID() == "517")
                                    {
                                        dr["GATEWAY_PORT"] = "INTUT1";
                                    }
                                    else
                                    {
                                        dr["GATEWAY_PORT"] = ds_data.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                                    }

                                    dr["EXPORTER_NAME"] = ds_data.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                                    dr["EXPORTER_ADD1"] = ds_data.Tables[0].Rows[0]["ADDRESS1"].ToString();
                                    dr["EXPORTER_ADD2"] = ds_data.Tables[0].Rows[0]["ADDRESS2"].ToString();
                                    dr["EXPORTER_ADD3"] = ds_data.Tables[0].Rows[0]["ADDRESS3"].ToString();
                                    dr["EXPORTER_ADD4"] = ds_data.Tables[0].Rows[0]["ADDRESS4"].ToString();
                                    dr["CONSIGNEE_NAME"] = ds_data.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                                    dr["CONSIGNEE_ADD1"] = ds_data.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();
                                    dr["CONSIGNEE_ADD2"] = ds_data.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString();
                                    dr["CONSIGNEE_ADD3"] = ds_data.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString();
                                    dr["CONSIGNEE_ADD4"] = ds_data.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString();

                                    if (ds_data.Tables[2].Rows.Count > 0)
                                    {
                                        dr["NATURE_OF_CARGO"] = ds_data.Tables[2].Rows[0]["ANNEX_AIR_NATURE_OF_CARGO"].ToString();
                                        dr["QUATITY"] = ds_data.Tables[2].Rows[0]["ANNEX_AIR_GROSS_WEIGHT"].ToString();
                                        dr["UNIT_QTY"] = ds_data.Tables[2].Rows[0]["ANNEX_AIR_GR_UNIT_CODE"].ToString();
                                        dr["NO_OF_PKGS"] = ds_data.Tables[2].Rows[0]["ANNEX_AIR_TOTAL_PACKAGES"].ToString();
                                    }

                                    if (ds_data.Tables[3].Rows.Count > 0)
                                    {
                                        dr["NATURE_OF_CARGO"] = ds_data.Tables[3].Rows[0]["ANNEX_SEA_NATURE_OF_CARGO"].ToString();
                                        dr["QUATITY"] = ds_data.Tables[3].Rows[0]["ANNEX_SEA_GROSS_WEIGHT"].ToString();
                                        dr["UNIT_QTY"] = ds_data.Tables[3].Rows[0]["ANNEX_SEA_UNIT_MEASUREMENT"].ToString();
                                        dr["NO_OF_PKGS"] = ds_data.Tables[3].Rows[0]["ANNEX_SEA_TOTAL_PACKAGES"].ToString();
                                    }

                                    if (ds.Tables[0].Rows[a][12].ToString() == "")
                                    {
                                        if (ds_data.Tables[4].Rows.Count > 0)
                                        {
                                            dr["DESCRIPTION"] = ds_data.Tables[4].Rows[0][0].ToString();
                                        }
                                    }
                                    else
                                    {
                                        dr["DESCRIPTION"] = ds.Tables[0].Rows[a][12].ToString();
                                    }


                                    dr["LINER_NAME"] = ds.Tables[0].Rows[a][5].ToString();
                                    dr["VESSEL_NAME"] = ds.Tables[0].Rows[a][6].ToString();


                                    // get IMO Code from VesselMaster
                                    if (ds.Tables[0].Rows[a][6].ToString() != "")
                                    {
                                        EGM.EGM_ID = "";
                                        EGM.JOBNO = "";
                                        //EGM.SB_SLNO = Convert.ToInt32(hdn_SB_SlNo.Value == string.Empty ? 0 : Convert.ToInt32(hdn_SB_SlNo.Value));
                                        EGM.ROTATION_NO = ds.Tables[0].Rows[a][6].ToString();
                                        EGM.Ename = "Get_IMOCODE_VesselMaster";

                                        EGM.WORKINGPERIOD = SELECT_BRANCH;
                                        dt_imo = EGM.EGM_CONSOLIDATE_Select_All();

                                        if (dt_imo.Tables[0].Rows.Count > 0)
                                        {
                                            dr["IMO_NO"] = dt_imo.Tables[0].Rows[0][0].ToString();
                                        }
                                    }

                                    dr["VOYAGE_NO"] = ds.Tables[0].Rows[a][7].ToString();


                                    dr["USERID"] = currentuser;
                                    dr["LOGIN_DATE"] = LoginDate;
                                    dr["STATUS"] = "N";
                                    dr["BRANCHCODE"] = currentbranch;
                                    dr["WORKINGPERIOD"] = Working_Period;
                                    dr["SB_SLNO"] = EGM_SBSLNO;
                                    dr["STUFFDATE"] = ds.Tables[0].Rows[a][11].ToString() == string.Empty ? "01/01/1900" : ds.Tables[0].Rows[a][11].ToString();
                                    //dr["DESCRIPTION"] = ds.Tables[0].Rows[a][12].ToString();
                                }
                            }
                        }
                    }



                    if (ds_data.Tables[0].Rows.Count > 0)
                    {
                        dsXML.Tables[0].Rows.Add(dr);


                        hdn_Jobno.Value = ds.Tables[0].Rows[a][2].ToString();
                        hdn_RotationNo.Value = ds.Tables[0].Rows[a][4].ToString();

                        b = a;
                        while (ds.Tables[0].Rows[b][0] != System.DBNull.Value)
                        {
                            //while (ds.Tables[0].Rows.Count > b)
                            //{
                            DataRow dr1 = dsXML.Tables[1].NewRow();
                            string RotationNo, Cont_RotationNo, Jobno, Cont_Jobno, SBNo, Cont_SBNo;

                            RotationNo = ds.Tables[0].Rows[a][0].ToString();
                            Cont_RotationNo = ds.Tables[0].Rows[b][0].ToString();

                            Jobno = ds.Tables[0].Rows[a][2].ToString();
                            Cont_Jobno = ds.Tables[0].Rows[b][2].ToString();

                            //SBNo = ds.Tables[0].Rows[a][3].ToString().TrimEnd();
                            //Cont_SBNo = ds.Tables[0].Rows[b][3].ToString().TrimEnd();

                            SBNo = ds_data.Tables[0].Rows[0]["SB_NO"].ToString();
                            Cont_SBNo = ds.Tables[0].Rows[b][3].ToString();

                            //if (RotationNo == Cont_RotationNo && Jobno == Cont_Jobno && SBNo == Cont_SBNo)
                            if (RotationNo == Cont_RotationNo && Jobno == Cont_Jobno)
                            {
                                dr1["EGM_CONID"] = EGM_Container_Max_ID;
                                dr1["EGM_JOBNO"] = EGM_JOBNO;
                                dr1["JOBNO"] = Jobno;
                                dr1["SBNO"] = SBNo;
                                dr1["SLNO"] = EGM_SBSLNO;
                                dr1["CONTAINER_NO"] = ds.Tables[0].Rows[b][8].ToString();
                                dr1["SIZE"] = ds.Tables[0].Rows[b][9].ToString();
                                dr1["TYPE"] = ds.Tables[0].Rows[b][10].ToString();

                                dr1["USERID"] = currentuser;
                                dr1["LOGIN_DATE"] = LoginDate;
                                dr1["STATUS"] = "N";
                                dr1["BRANCHCODE"] = currentbranch;
                                dr1["WORKINGPERIOD"] = Working_Period;
                                dr1["ROTATION_NO"] = ds.Tables[0].Rows[b][0].ToString();

                                b++;
                                EGM_Container_Max_ID++;
                                dsXML.Tables[1].Rows.Add(dr1);
                            }
                            else
                            {
                                break;
                            }
                            //b++;
                        }

                        //a++;
                        a = b;
                        EGM_SBSLNO++;
                        EGM_Max_ID++;
                    }
                    else
                    {
                        //dt_Nil.Rows.Add(ds.Tables[0].Rows[a][2].ToString(), ds.Tables[0].Rows[a][3].ToString());
                        a++;
                    }
                }
                #endregion


                //if (dt_Nil.Rows.Count == 0)
                //{
                    dt = dsXML.Tables["EGM_CONSOLIDATE_DETAILS"];
                    DataTable dtt = dsXML.Tables["EGM_CONSOLIDATE_CONTAINER_DETAILS"];
                    //dt=  RemoveDuplicateRows(dt, "LICENSE_NO","INV_SL_NO","ITEM_SL_NO");

                    string status = "";
                    if (dsXML.Tables[0].Rows.Count > 0)
                    {
                        admin.SqlBulk_Upload_Product("EGM_CONSOLIDATE_DETAILS", dsXML.Tables[0], Session["currentcomp_db"].ToString());
                    }

                    if (dsXML.Tables[1].Rows.Count > 0)
                    {
                        admin.SqlBulk_Upload_Product("EGM_CONSOLIDATE_CONTAINER_DETAILS", dsXML.Tables[1], Session["currentcomp_db"].ToString());
                        Alert_msg("Uploaded Successfully...!");
                        Session["EGMID_excel"] = Convert.ToString(EGM_JOBNO);
                    }
                //}
                //else
                //{
                //    string msg = "    Job Details Not Available" + Environment.NewLine + " -------------------------------------------------------" + Environment.NewLine + "   Job No  " + "         " + "SB No" + Environment.NewLine + Environment.NewLine;
                //    for (int j = 0; j <= dt_Nil.Rows.Count - 1; j++)
                //    {
                //        msg += dt_Nil.Rows[j][0].ToString() + "              " + dt_Nil.Rows[j][1].ToString() + "  " + Environment.NewLine;
                //    }

                //    //msg = " Inv no : " + dss.Tables[0].Rows[s][38].ToString() + "  -  Already Exists";
                //    hdinvno.Value = msg;
                //    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Avail_InvoiceNo_Alert_Msg()", true);   
                //}
                
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

    public int Get_MAXID(string Flag)
    {
        int MAX_ID = 0;
        DataSet dt_max = new DataSet();
        EGM.EGM_JOBNO = Convert.ToString(EGM_JOBNO);
        EGM.JOBNO = hdn_Jobno.Value;
        EGM.ROTATION_NO = hdn_RotationNo.Value;
        EGM.WORKINGPERIOD = SELECT_BRANCH;
        EGM.Ename = Flag;

        dt_max = EGM.EGM_CONSOLIDATE_Select_All();

        if (dt_max.Tables[0].Rows.Count > 0)
        {
            //MAX_ID = Convert.ToInt32(dt_max.Tables[0].Rows[0]["MAXID"].ToString());
            MAX_ID = Convert.ToInt32(dt_max.Tables[0].Rows[0][0].ToString());
        }

        return MAX_ID;
    }

    /*
    protected void btnyes_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();

        //objUBO.IEC_NO = EXPORT_JOBNO;
        //objUBO.BRANCH_NO = "";
        //objUBO.Ename = "get_MAX_Invoice_SlNo";
        //objUBO.WORKING_PERIOD = SELECT_BRANCH;
        //ds = xl.Bind_Export_General_IEC_No(objUBO);

        //objUBO.JOBNO = EXPORT_JOBNO;
        //objUBO.Ename = "get_MAX_Invoice_SlNo";
        //objUBO.Xml_D = "";

        //EXU.JOBNO = EXPORT_JOBNO;
        //EXU.Xml_D = "";
        //EXU.Branch_Code = SELECT_BRANCH;
        //EXU.Ename = "get_MAX_Invoice_SlNo";
        //ds = EXU.Select_Exp_INV();

        Is_Additional_EGM = "YES";
        btn_Export_BulkUpload_Click(sender, e);

        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    MAX_INVOICE_SLNO = ds.Tables[0].Rows[0][0].ToString();
            //Excel_Upload_load(MAX_INVOICE_SLNO, Is_Additional_INV);
        //}
    }
*/


}
