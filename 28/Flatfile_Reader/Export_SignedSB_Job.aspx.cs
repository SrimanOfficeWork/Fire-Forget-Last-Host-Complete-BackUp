using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Linq;
using System.Text;

public partial class Export_SignedSB_Job : ThemeClass
{
    AppSession aps = new AppSession();
    UserBO objUBO = new UserBO();
    Export_flatfile_reader Gen = new Export_flatfile_reader();
    Jobwise_xl_Upload xl = new Jobwise_xl_Upload();
    Annexure_C_Air ANNEX_C_Air = new Annexure_C_Air();
    Annexure_C_Sea ANNEX_C_Sea = new Annexure_C_Sea();
    Transaction Transact = new Transaction(); 
    DataTable dt_Inv = new DataTable();
    DataTable dt_Exchange = new DataTable();
    DataTable dt_Item = new DataTable();
    DataTable dt_Item_access= new  DataTable();
    DataTable dt_item_thirdparty= new DataTable();
    DataTable dt_Cess = new DataTable();
    DataTable dt_Lic = new DataTable();
    DataTable dt_Exp_lic = new DataTable();
    DataTable dt_Imp_Exp_lic = new DataTable();
    DataTable dt_Dbk = new DataTable();
    DataTable dt_AR4 = new DataTable();
    DataTable dt_Job_Work = new DataTable();
    DataTable dt_blk_Lic = new DataTable();
    DataTable dt_blk_Imp_Exp_lic = new DataTable();
    DataTable dt_packing_list = new DataTable(); 
    DataTable dt_rotation = new DataTable();
    DataTable dt_EOU = new DataTable();
    DataTable dt_Container = new DataTable();
    DataTable dt_SW_INFO = new DataTable();
    DataTable dt_SW_CTRL = new DataTable();
    DataTable dt_SW_STMT = new DataTable();
    DataTable dt_SW_Sup = new DataTable();
    DataTable dt_Re_Exp = new DataTable();
    DataSet ds_IEC = new DataSet();
    AdminMasterDetails admin = new AdminMasterDetails();
    Auto_Search Auto = new Auto_Search();

    DataSet ds_draw = new DataSet();
    DataSet ds_license = new DataSet();

    DataTable dtdrawback = new DataTable();
    DataTable dtScheme = new DataTable();

    public string SELECT_BRANCH, IMP_Jobno, IMP_INV_Slno;
    public string errorFolder = "", logline = "", logFileName = "";
    string EXPORT_JOBNO = "", Current_JOBID="";
    DateTime dateTime = DateTime.UtcNow.Date;
    public int MAX_ID = 0;
    //public string INVOICE_ID = "", comp_ConnectionStr = "", ITEM_ID = "", AR4_ID = "", DRAWBACK_ID="";
    public decimal item_amt;
    public string scheme;
    string[] scheme_name = new string[2];

    public string  comp_ConnectionStr = "";
    public int LICENSE_ID, LICENSE_IMP_EXP_ID;
    public int License_id_Max = 0;
    public int License_id_IMP_EXP_Max = 0;

    public string[] lic_no;
    public int licno_Count;
    //public decimal item_amt;
    public int ITEM_ID = 0, CONTAINER_MAX_ID = 0, AR4_ID = 0, DRAWBACK_ID = 0, INVOICE_ID = 0, PACK_ID = 0, SUP_DOC = 0, ANNEX_ID = 0;
    public string txtJobNo = "" , txtjobPS = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Export_Excel");
        if (!IsPostBack)
        {
             
        }
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'General', function (r) {Export_session();document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btn_upload_Click(object sender, EventArgs e)
    {
        try
        {
            string logFileName = fileuploadXML.FileName;
            if (File.Exists(errorFolder + logFileName))
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }
                Get_File_Bulk_Upload();
               
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                dir.Create();
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }
                Get_File_Bulk_Upload();
                Alert_msg("File Uploaded Sucessfully", "btn_upload_Click");
              
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public string AUTO_JOBNO()
    {
        Gen.BRANCH_CODE = Connection.Get_Company_Type();
        Gen.WORKING_PERIOD = Connection.WorkingPeriod();
        EXPORT_JOBNO = Convert.ToString(Gen.Retrieve_JobNO());
        return EXPORT_JOBNO;
    }


    public void JobNo_Prefix_Sufix()
    {
        string txtJobNo = Session["Jobno_Excel"].ToString();
        string txtjobPS = "";
        Admin_job_Prefix_Suffix JPS = new Admin_job_Prefix_Suffix();
        DataSet dats = new DataSet();
        JPS.Branch = SELECT_BRANCH;
        JPS.Ename = "Exp_gen_select";
        JPS.Tr_mode = "Air";
        dats = JPS.Job_prefix_Suffix_Select();
        int Jno = 0;
        string JobNo = string.Empty;
        JobNo = txtJobNo ;

        if (JobNo != string.Empty)
        {
            Jno = Convert.ToInt32(JobNo);
            if (Jno < 1000)
            {
                if (Jno > 100)
                {
                    JobNo = "00" + txtJobNo ;
                }
                else if (Jno > 10)
                {
                    JobNo = "000" + txtJobNo ;
                }
                else
                {
                    JobNo = "0000" + txtJobNo;
                }
            }
        }
        if (Session["COMPANY_LICENSE"] != null)
        {
            if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00247")
            {
                if (dats.Tables[0].Rows.Count > 0)
                {
                    if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                    {
                        txtjobPS = txtJobNo + "/" + ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                        hdprefix.Value = string.Empty;
                        hdsuffix.Value = ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                    {
                        txtjobPS = ((dats.Tables[0].Rows[0][0].ToString() + txtJobNo).TrimEnd()).TrimStart();
                        //txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + JobNo).TrimEnd()).TrimStart();
                        hdprefix.Value = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                        hdsuffix.Value = string.Empty;
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                    {
                        txtjobPS = ((dats.Tables[0].Rows[0][0].ToString() + txtJobNo + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                        //txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + JobNo + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                        hdprefix.Value = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                        hdsuffix.Value = ((dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                    {
                        txtjobPS = txtJobNo;
                        hdprefix.Value = string.Empty;
                        hdsuffix.Value = string.Empty;
                    }
                }
                else
                {
                    txtjobPS = txtJobNo;
                    hdprefix.Value = string.Empty;
                    hdsuffix.Value = string.Empty;
                }
            }
            else
            {
                if (dats.Tables[0].Rows.Count > 0)
                {
                    if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                    {
                        txtjobPS = txtJobNo + "/" + ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                        hdprefix.Value = string.Empty;
                        hdsuffix.Value = ((dats.Tables[0].Rows[0][1].ToString()).TrimStart()).TrimEnd();
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                    {
                        //txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + "/" + txtJobNo.Text).TrimEnd()).TrimStart();
                        if (Connection.COMPANYID() == "1163" || Connection.COMPANYID() == "1164" || Connection.COMPANYID() == "1165" || Connection.COMPANYID() == "1166")
                        {
                            txtjobPS = ((dats.Tables[0].Rows[0][0].ToString() + "/" + JobNo).TrimEnd()).TrimStart();
                        }
                        else
                        {
                            txtjobPS = ((dats.Tables[0].Rows[0][0].ToString() + "/" + txtJobNo).TrimEnd()).TrimStart();
                        }
                        hdprefix.Value = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                        hdsuffix.Value = string.Empty;
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() != string.Empty && dats.Tables[0].Rows[0][1].ToString() != string.Empty)
                    {
                        // txtjobPS.Text = ((dats.Tables[0].Rows[0][0].ToString() + "/" + txtJobNo.Text + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                        if (Connection.COMPANYID() == "1163" || Connection.COMPANYID() == "1164" || Connection.COMPANYID() == "1165" || Connection.COMPANYID() == "1166")
                        {
                            txtjobPS = ((dats.Tables[0].Rows[0][0].ToString() + "/" + JobNo + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                        }
                        else
                        {
                            txtjobPS = ((dats.Tables[0].Rows[0][0].ToString() + "/" + txtJobNo + "/" + dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                        }

                        hdprefix.Value = ((dats.Tables[0].Rows[0][0].ToString()).TrimEnd()).TrimStart();
                        hdsuffix.Value = ((dats.Tables[0].Rows[0][1].ToString()).TrimEnd()).TrimStart();
                    }
                    else if (dats.Tables[0].Rows[0][0].ToString() == string.Empty && dats.Tables[0].Rows[0][1].ToString() == string.Empty)
                    {
                        txtjobPS = txtJobNo;
                        hdprefix.Value = string.Empty;
                        hdsuffix.Value = string.Empty;
                    }
                }
                else
                {
                    txtjobPS = txtJobNo;
                    hdprefix.Value = string.Empty;
                    hdsuffix.Value = string.Empty;
                }
            }
        }
    }

   

    public void Get_File_Bulk_Upload()
    {

        DataSet ds = new DataSet();
        string cur_date = DateTime.Now.ToString("dd/MM/yyyy");
        string strFileType = Path.GetExtension(fileuploadXML.FileName).ToLower();
        string path = errorFolder + "\\" + fileuploadXML.FileName;

        string Country_Discharge = ""; string Country_Final_Dest = ""; string Port_Discharge = ""; string Port_Final_Dest = ""; string State_Of_Export = "";
        string Ex_Sw_Info_Code = "", Inv_Cur = "", distcode = "", Sw_statecode = "", PtaFta_code = "", cess_slno=""; 
        string drawbk_sno = ""; 
        string item_schem_code = "";
       
        string ANNEX_SEA_SEAL_TYPE = "", NATURE_OF_CARGO = "", GROSS_WEIGHT = "", NET_WEIGHT = "", UNIT_CODE = "", TOTAL_PACKAGES = "", MARKS_NO = "", LOOSE_PACKETS = "", NO_CONTAINERS = "", ANNEX_AIR_MAWB_NO = "", ANNEX_AIR_HAWB_NO = "";
        string INVOICE_SLNO = "", ITEM_SLNO = "";
        string fileName2;
        int i = 0, result = 0, inc=1, Grp_Id=1;
        if (fileuploadXML.HasFile)
        {
            //picExtension = fnGetPictureExtn(fileuploadXML.FileName);
            fileName2 = fileuploadXML.FileName;
            addtoGallery1(fileName2, errorFolder, "NORMAL");

            //using(StreamReader r=new StreamReader(
            char ch = Convert.ToChar(29);

            string fileText = System.IO.File.ReadAllText(path);
            //fileText = System.Text.RegularExpressions.Regex.Replace(fileText,
            fileText = fileText.Replace(ch, '^');

            //var result = string.Join("^", fileText.Split(new[] { '^' }, StringSplitOptions.RemoveEmptyEntries));
            //System.IO.File.WriteAllText(path, result);

            System.IO.File.WriteAllText(path, fileText);


            DataSet dataSet = new DataSet();
            // *******************start reading from singed be copy ***************************//

            string[] lines = File.ReadAllLines(path);


            int EX_INV_ID = 0, EX_ITEM_ID = 0, EX_CESS_ID=0,EX_DBK_ID = 0, EX_AR4_ID = 0, EX_JOBBING_ID = 0, EX_LIC_ID = 0, EX_LICENSE_ID = 0, EX_ANN_PACK_ID = 0, EX_ANN_C_ID = 0,
                EX_ANN_A_ID = 0, EX_ANN_C1_ID = 0, EX_ANN_SEA_CON_ID = 0, EX_SW_INFO_ID = 0, EX_SW_STMT_ID = 0, EX_SW_SUP_ID = 0, RE_EX_ID = 0;

            Gen.BRANCH_CODE = Connection.Get_Company_Type();
            Gen.WORKING_PERIOD = Connection.WorkingPeriod();
            DataSet DsAutoid = Gen.Retrieve_Flatfile_JobNO();

            if (DsAutoid.Tables.Count > 0)
            {
               
                EX_INV_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["EX_INV_ID"].ToString());
                EX_ITEM_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["EX_ITEM_ID"].ToString());
                EX_CESS_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["EX_CESS_ID"].ToString());
                EX_DBK_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["EX_DBK_ID"].ToString());
                EX_AR4_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["EX_AR4_ID"].ToString());
                EX_JOBBING_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["EX_JOBBING_ID"].ToString());
                EX_LIC_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["EX_LIC_ID"].ToString());
                EX_LICENSE_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["EX_LICENSE_ID"].ToString());
                EX_ANN_PACK_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["EX_ANN_PACK_ID"].ToString());
                EX_ANN_C_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["EX_ANN_C_ID"].ToString());
                EX_ANN_A_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["EX_ANN_A_ID"].ToString());
                EX_ANN_C1_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["EX_ANN_C1_ID"].ToString());
                EX_ANN_SEA_CON_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["EX_ANN_SEA_CON_ID"].ToString());
                EX_SW_INFO_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["EX_SW_INFO_ID"].ToString());
                EX_SW_STMT_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["EX_SW_STMT_ID"].ToString());
                EX_SW_SUP_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["EX_SW_SUP_ID"].ToString());
                RE_EX_ID = Convert.ToInt32(DsAutoid.Tables[0].Rows[0]["RE_EX_ID"].ToString());

            }


            int pos = 0;
            for (int ln = 0; ln < lines.Length; ln++)
            {
                pos = Array.IndexOf(lines, "<TABLE>SB");
                if (pos > 0)
                {
                    ln = pos + 1;


                    string[] lnItm = lines[ln].ToString().Split('^');
                    if (lnItm.Length > 30)
                    {
                        #region general
                        txtJobNo = AUTO_JOBNO();
                        Gen.JOBID = "";
                        Gen.JOBNO = txtJobNo;  // 20221128
                        Gen.JOBDATE = lnItm[3].ToString().Substring(6, 2) + "/" + lnItm[3].ToString().Substring(4, 2) + "/" + lnItm[3].ToString().Substring(0, 4); //lnItm[3].ToString(); 
                        Gen.CUSTOMS_HOUSE = lnItm[1].ToString();

                        DataSet CUSTOMS_HOUSE = new DataSet();
                         CUSTOMS_HOUSE=  Gen.Retrieve_Custom_House_details();
                         if (CUSTOMS_HOUSE.Tables[0].Rows.Count > 0)
                         {
                             Gen.TRANSPORT_MODE = CUSTOMS_HOUSE.Tables[0].Rows[0]["Transport_Mode"].ToString(); 
                         }
                         
                       // Gen.TRANSPORT_MODE = "Air";
                        Gen.CUSTOMS_HOUSE_NAME = lnItm[1].ToString();
                        Gen.SB_TYPE = "";
                        Gen.IEC_NO = lnItm[7].ToString();
                        Gen.BRANCH_NO = lnItm[8].ToString();
                        Gen.EXPORTER_NAME = lnItm[9].ToString();
                        Gen.ADDRESS1 = lnItm[10].ToString();
                        Gen.ADDRESS2 = lnItm[11].ToString();
                        Gen.ADDRESS3 = lnItm[12].ToString();
                        Gen.ADDRESS4 = lnItm[13].ToString();
                        Gen.ADDRESS5 = lnItm[14].ToString();
                        Gen.ADCODE = lnItm[18].ToString();
                        Gen.BANK_ACCOUNT = "";
                        Gen.DRAWBACK_ACCOUNT = "";
                        Gen.CONSIGNEE_NAME = lnItm[20].ToString();
                        Gen.CONSIGNEE_ADD1 = lnItm[21].ToString();
                        Gen.CONSIGNEE_ADD2 = lnItm[22].ToString();
                        Gen.CONSIGNEE_ADD3 = lnItm[23].ToString();
                        Gen.CONSIGNEE_ADD4 = lnItm[24].ToString();
                        Gen.CONSIGNEE_ADD5 = lnItm[25].ToString();
                        Gen.COUNTRY_DISCHARGE = lnItm[31].ToString();
                        Country_Discharge = Country_Discharge + "~" + lnItm[31].ToString();
                        Gen.PORT_DISCHARGE = lnItm[30].ToString();
                        Port_Discharge = Port_Discharge + "~" + lnItm[30].ToString();
                        Gen.COUNTRY_FINAL_DEST = lnItm[32].ToString();
                        Country_Final_Dest = Country_Final_Dest + "~" + lnItm[32].ToString();
                        Gen.PORT_FINAL_DEST = lnItm[33].ToString();
                        Port_Final_Dest = Port_Final_Dest + "~" + lnItm[33].ToString();
                        Gen.STATE_OF_EXPORT = lnItm[17].ToString();
                        State_Of_Export = State_Of_Export + "~" + lnItm[17].ToString();
                        Gen.NFEI = "No";
                        Gen.NFEI_TYPE = lnItm[26].ToString();
                        Gen.RBI_WAIVER_NO = lnItm[27].ToString();
                       //Gen.RBI_WAIVER_DATE =RBI_WAIVER_DATE();
                        if (lnItm[28].ToString() != "")
                        {
                            Gen.RBI_WAIVER_DATE = lnItm[28].ToString().Substring(6, 2) + "/" + lnItm[28].ToString().Substring(4, 2) + "/" + lnItm[28].ToString().Substring(0, 4);
                        }
                        else
                        {
                            Gen.RBI_WAIVER_DATE = "01/01/1900";
                        }                        
                        Gen.MARKS_NO = lnItm[40].ToString();
                        Gen.USER_ID = Connection.Current_User();
                        //Gen.LoginDate = "01/01/1900";
                        //Gen.LoginSTATUS = "";
                        Gen.flag = "S";
                        Gen.BRANCH_CODE = Connection.Current_Branch();
                        Gen.WORKING_PERIOD = Connection.WorkingPeriod();
                        Gen.FILE_REF_NO = "";
                        //Gen.JOB_STATUS="";
                        //Gen.JOB_RELEASE ="";
                        //Gen.JOB_FILED_STATUS ="";
                        //Gen.MODIFIEDBY ="";
                        //Gen.MODIFIEDON ="";
                        Gen.BRANCH_COMMON = SELECT_BRANCH;
                        Gen.TYPE_OF_EXPORTER = lnItm[15].ToString();
                        Gen.JOB_PREFIX = hdprefix.Value.ToString();
                        Gen.JOB_SUFFIX = hdsuffix.Value.ToString();
                        Gen.JOBNO_PS = txtjobPS;
                        Gen.CONSIGNEE_BRANCHSLNO = "";
                        Gen.GSTN_TYPE = lnItm[48].ToString();
                        Gen.GSTN_ID = lnItm[49].ToString();
                        Gen.PARTY_REF_NO = "";
                        Gen.CARTING_POINT = "";
                        Gen.IFSC_CODE = "";
                        Gen.PORT_OF_LOADING = lnItm[1].ToString();
                       // Gen.IMP_EXP_TYPE = lnItm[16].ToString();

                        if (lnItm[16].ToString() == "P")
                        {
                            Gen.IMP_EXP_TYPE = "PRIVATE";
                        }
                        else if (lnItm[16].ToString() == "O")
                        {
                            Gen.IMP_EXP_TYPE = "OTHERS";
                        }
                        else if (lnItm[16].ToString() == "G")
                        {
                            Gen.IMP_EXP_TYPE = "GOVERNMENT DEPARTMENTS";
                        }
                        else if (lnItm[16].ToString() == "U")
                        {
                            Gen.IMP_EXP_TYPE = "GOVERNMENT UNDERTAKINGS";
                        }

                        // *********** start aded to link Freight jobs **************//
                        Gen.FRT_JOBNO = "";
                        Gen.FRT_GROUPID = Session["GroupID"].ToString();
                        Gen.FRT_BRANCHCODE = "";

                        // *********** start aded to link Freight jobs **************//
                        Gen.AMENDMENT_TYPE = "";
                        Gen.AMENDMENT_STATUS = "";
                        Gen.ICE_ID = "";
                        Gen.CHA_NO = "";

                        result = Gen.General_details_insertupdate();
                        //IMP_EXP_TYPE = lnItm[16].ToString();
                        ANNEX_SEA_SEAL_TYPE = lnItm[34].ToString();
                        NATURE_OF_CARGO = lnItm[35].ToString();
                        GROSS_WEIGHT = lnItm[36].ToString();
                        NET_WEIGHT = lnItm[37].ToString();
                        UNIT_CODE = lnItm[38].ToString();
                        TOTAL_PACKAGES = lnItm[39].ToString();
                        MARKS_NO = lnItm[40].ToString();
                        LOOSE_PACKETS = lnItm[41].ToString();
                        NO_CONTAINERS = lnItm[42].ToString();
                        ANNEX_AIR_MAWB_NO = lnItm[43].ToString();
                        ANNEX_AIR_HAWB_NO = lnItm[44].ToString();
                       

                        pos = ln + 1;

                        break;

                       
                      
                        #endregion
                    }
                }
            }
            ///// *******************end to build general detaails *******************///////////////////


            //****************************** starts exchange currency ************************/////

            //for (int ln = pos; ln < lines.Length; ln++)
            for (int ln = 0; ln < lines.Length; ln++)
            {


                string[] lnItm;
                pos = Array.IndexOf(lines, "<TABLE>EXCHANGE");

                if (result == 1 && pos > 0)
                {

                   
                    #region dt_Exchange
                    dt_Exchange.Columns.Add("INVOICE_CURRENCY"); dt_Exchange.Columns.Add("UNIT"); dt_Exchange.Columns.Add("EXCHANGE_RATE");

                    ln = pos + 1;
                    int inv = 1;
                    for (ln = ln; ln < lines.Length - 1; ln++)
                    {
                        if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-SB>"))))
                        {

                            lnItm = lines[ln].ToString().Split('^');
                            if (lnItm.Length >= 2)
                            {

                                dt_Exchange.Rows.Add(lnItm[6].ToString(), lnItm[8].ToString(), lnItm[9].ToString());
                                
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    #endregion dt_Exchange
                    pos = ln + 1;
                    break;

                }
            }
            //****************************** end of exchange currency ************************/////


          
            ///// ******************* Start invoice details *******************///////////////////

            //for (int ln = pos; ln < lines.Length; ln++)
            for (int ln = 0; ln < lines.Length; ln++)
            {
                string[] lnItm;
                string exrate_fromfile = "";
              
                pos = Array.IndexOf(lines, "<TABLE>INVOICE");

                if (result == 1 && pos > 0)
                {
                    //pos = Array.IndexOf(lines, "<TABLE>INVOICE");

                    #region dt_Inv
                    dt_Inv.Columns.Add("INVOICE_ID"); dt_Inv.Columns.Add("JOBNO"); dt_Inv.Columns.Add("JOBDATE"); dt_Inv.Columns.Add("INVOICE_SLNO"); dt_Inv.Columns.Add("INVOICE_NO");
                    dt_Inv.Columns.Add("INVOICE_DATE"); dt_Inv.Columns.Add("PAYMENT_METHOD"); dt_Inv.Columns.Add("PERIOD_PAYMENT"); dt_Inv.Columns.Add("INVOICE_VALUE");
                    dt_Inv.Columns.Add("INVOICE_CURRENCY"); dt_Inv.Columns.Add("EXCHANGE_RATE"); dt_Inv.Columns.Add("CONTRACT_NO"); dt_Inv.Columns.Add("TERMS"); dt_Inv.Columns.Add("BUYER");// 14 count 
                    dt_Inv.Columns.Add("BUYER_NAME"); dt_Inv.Columns.Add("BUYER_ADDRESS"); dt_Inv.Columns.Add("BUYER_ADDRESS1"); dt_Inv.Columns.Add("BUYER_ADDRESS2");
                    dt_Inv.Columns.Add("BUYER_ADDRESS3"); dt_Inv.Columns.Add("BUYER_ADDRESS4"); dt_Inv.Columns.Add("COMMISSION_RATE"); dt_Inv.Columns.Add("COMMISSION_CHARGES");
                    dt_Inv.Columns.Add("COMMISSION_CURRENCY"); dt_Inv.Columns.Add("FOB_RATE"); dt_Inv.Columns.Add("FOB_CHARGES"); dt_Inv.Columns.Add("FOB_CURRENCY"); // 26 count
                    dt_Inv.Columns.Add("PACKMISC_RATE"); dt_Inv.Columns.Add("PACKMISC_CHARGES"); dt_Inv.Columns.Add("PACKMISC_CURRENCY"); dt_Inv.Columns.Add("OTHER_DEDUCTION_RATE");
                    dt_Inv.Columns.Add("OTHER_DEDUCTION_CHARGES"); dt_Inv.Columns.Add("OTHER_DEDUCTION_CURRENCY"); dt_Inv.Columns.Add("FREIGHT_RATE"); dt_Inv.Columns.Add("FREIGHT_CHARGES");
                    dt_Inv.Columns.Add("FREIGHT_CURRENCY"); dt_Inv.Columns.Add("FREIGHT_EXRATE"); dt_Inv.Columns.Add("INSURANCE_RATE"); dt_Inv.Columns.Add("INSURANCE_CHARGES");
                    dt_Inv.Columns.Add("INSURANCE_CURRENCY"); dt_Inv.Columns.Add("INSURANCE_EXRATE"); dt_Inv.Columns.Add("WHEATHER_UNIT_PRICE");  //41
                    dt_Inv.Columns.Add("USER_ID"); dt_Inv.Columns.Add("DATE_TIME"); dt_Inv.Columns.Add("STATUS"); dt_Inv.Columns.Add("BRANCH_CODE");
                    dt_Inv.Columns.Add("YEAR"); dt_Inv.Columns.Add("WORKING_PERIOD"); dt_Inv.Columns.Add("NON_STD_EFFECT_DT_EXP"); dt_Inv.Columns.Add("NON_STD_BANKNAME");//49 count   
                    dt_Inv.Columns.Add("NON_STD_CERTIFICATE_NO"); dt_Inv.Columns.Add("NON_STD_CERTIFICATE_DATE"); dt_Inv.Columns.Add("MODIFIEDBY"); dt_Inv.Columns.Add("MODIFIEDON");//53 count
                    dt_Inv.Columns.Add("TERMS_PLACE"); dt_Inv.Columns.Add("THIRDPARTY_NAME"); dt_Inv.Columns.Add("THIRDPARTY_ADD1"); dt_Inv.Columns.Add("THIRDPARTY_ADD2");
                    dt_Inv.Columns.Add("THIRDPARTY_CITY"); dt_Inv.Columns.Add("T_PARTY_COUNTRY_SUB_DIV"); dt_Inv.Columns.Add("T_PARTY_COUNTRY_CODE"); dt_Inv.Columns.Add("T_PARTY_PIN");
                    dt_Inv.Columns.Add("AUTHORIZED_ECONOMIC_OPERATOR_CODE"); dt_Inv.Columns.Add("A_E_O_COUNTRY"); dt_Inv.Columns.Add("AUTHORIZED_ECONOMIC_OPERATOR");
                    dt_Inv.Columns.Add("DOC_RECD_DATE"); dt_Inv.Columns.Add("AMENDMENT_TYPE"); dt_Inv.Columns.Add("AMENDMENT_STATUS");

                    #endregion dt_Inv

                    #region Invoice1
                    ln = pos + 1;
                     
                    for (ln = ln; ln < lines.Length-1; ln++)
                    {
                        if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-SB>"))))
                        {
                            
                           
                            exrate_fromfile = "";
                            lnItm = lines[ln].ToString().Split('^');
                            if (lnItm.Length > 30)
                            {


                                if (dt_Exchange.Rows.Count > 0)
                                {
                                    //invno_fromfile
                                    DataRow[] dr = dt_Exchange.Select("INVOICE_CURRENCY = '" + lnItm[9].ToString() + "' ");

                                    if (dr.Length > 0)
                                    {

                                         exrate_fromfile = dr[0].ItemArray[2].ToString().Trim();
                                    }
                                }


                                dt_Inv.Rows.Add(EX_INV_ID, Convert.ToInt64(txtJobNo), lnItm[3].ToString().Substring(6, 2) + "/" + lnItm[3].ToString().Substring(4, 2) + "/" + lnItm[3].ToString().Substring(0, 4),
                                Convert.ToInt64(lnItm[6].ToString()), 
                                lnItm[7].ToString(), lnItm[3].ToString().Substring(6, 2) + "/" + lnItm[3].ToString().Substring(4, 2) + "/" + lnItm[3].ToString().Substring(0, 4),
                                lnItm[33].ToString(), lnItm[34].ToString(), "", lnItm[9].ToString(), exrate_fromfile, lnItm[32].ToString(), lnItm[10].ToString(),
                                "Y", lnItm[11].ToString(), lnItm[12].ToString(), lnItm[13].ToString(), lnItm[14].ToString(), lnItm[15].ToString(), "",
                                lnItm[21].ToString(), lnItm[23].ToString(), lnItm[22].ToString(), lnItm[24].ToString(), lnItm[26].ToString(), lnItm[25].ToString(), "0.00", lnItm[31].ToString(),
                                lnItm[9].ToString(), lnItm[27].ToString(), lnItm[29].ToString(), lnItm[28].ToString(), "0.00", lnItm[17].ToString(), lnItm[16].ToString(), "0.00",
                                lnItm[18].ToString(), lnItm[20].ToString(), lnItm[19].ToString(), "0.00", lnItm[30].ToString(), Session["currentuser"].ToString(), cur_date,
                                "N", Session["currentbranch"].ToString(), "", Session["WorkingPeriod"].ToString(), "01/01/1900", "", "", "01/01/1900", "", "01/01/1900", lnItm[48].ToString(),
                                lnItm[38].ToString(), lnItm[39].ToString(), lnItm[40].ToString(), lnItm[41].ToString(), lnItm[42].ToString(),
                                lnItm[43].ToString(), lnItm[44].ToString(), lnItm[45].ToString(), lnItm[46].ToString(), lnItm[47].ToString(), "", "", "");
                                Inv_Cur = Inv_Cur + "~" + lnItm[9].ToString();
                                EX_INV_ID = EX_INV_ID + 1;
                            }

                        }
                        else
                        {

                            break;

                        }
                    }

                    if (dt_Inv.Rows.Count > 0)
                    {
                        admin.SqlBulk_Upload_Product("EXPORT_INVOICE_DETAILS", dt_Inv, comp_ConnectionStr);
                    }
                    pos = ln + 1;
                    break;

                    # endregion Invoice1
                }
            }

            ///// ******************* End of invoice details *******************///////////////////

            

            //****************************** starts item ************************/////

            //for (int ln = pos; ln < lines.Length; ln++)
            for (int ln = 0; ln < lines.Length; ln++)
            {

                string[] lnItm;
                string invno_fromfile = "";
                pos = Array.IndexOf(lines, "<TABLE>ITEM");
                if (result == 1 && pos > 0)
                {

                    #region dt_Item
                    
                    dt_Item.Columns.Add("ITEM_ID"); dt_Item.Columns.Add("JOBNO"); dt_Item.Columns.Add("INVOICE_SLNO");
                    dt_Item.Columns.Add("INVOICE_NO"); dt_Item.Columns.Add("ITEM_SLNO");
                    dt_Item.Columns.Add("ITEM_DESCRIPTION");  dt_Item.Columns.Add("RITCNO");
                    dt_Item.Columns.Add("ITEM_QTY"); dt_Item.Columns.Add("ITEM_QTY_CODE"); dt_Item.Columns.Add("ITEM_UNIT_PRICE");
                    dt_Item.Columns.Add("ITEM_PER"); dt_Item.Columns.Add("ITEM_AMOUNT"); dt_Item.Columns.Add("ITEM_PMVVALUE"); dt_Item.Columns.Add("ITEM_SCHEME_CODE");
                    dt_Item.Columns.Add("ITEM_ACCESSORIES_DESC"); dt_Item.Columns.Add("ITEM_AR4_NO"); dt_Item.Columns.Add("ITEM_AR4_DATE"); dt_Item.Columns.Add("ITEM_COMMISSION_RATE");
                    dt_Item.Columns.Add("ITEM_DIVISION"); dt_Item.Columns.Add("ITEM_RANGE"); dt_Item.Columns.Add("ITEM_REMARKS"); dt_Item.Columns.Add("ITEM_IECCODE"); dt_Item.Columns.Add("ITEM_EXPORTER_NAME");
                    dt_Item.Columns.Add("BR_SLNO"); dt_Item.Columns.Add("ADDRESS1"); dt_Item.Columns.Add("ADDRESS2"); dt_Item.Columns.Add("ADDRESS3"); dt_Item.Columns.Add("ADDRESS4");
                    dt_Item.Columns.Add("ADDRESS5"); dt_Item.Columns.Add("ITEM_STR_CODE"); dt_Item.Columns.Add("REWARD_POINTS"); dt_Item.Columns.Add("USER_ID"); dt_Item.Columns.Add("DATE_TIME");
                    dt_Item.Columns.Add("STATUS"); dt_Item.Columns.Add("BRANCH_CODE"); dt_Item.Columns.Add("YEAR"); dt_Item.Columns.Add("WORKING_PERIOD"); dt_Item.Columns.Add("PMV_VALUE");
                    dt_Item.Columns.Add("FOB_VALUE"); dt_Item.Columns.Add("DRAWBACK_VALUE"); dt_Item.Columns.Add("CESS_YN"); dt_Item.Columns.Add("MODIFIEDBY"); dt_Item.Columns.Add("MODIFIEDON");
                    dt_Item.Columns.Add("STR_RATE"); dt_Item.Columns.Add("STR_AMOUNT");
                    dt_Item.Columns.Add("MANUFACTURER_PRODUCER"); dt_Item.Columns.Add("M_P_GROWER_CODE"); dt_Item.Columns.Add("M_P_GROWER_ADD1"); dt_Item.Columns.Add("M_P_GROWER_ADD2");
                    dt_Item.Columns.Add("M_P_GROWER_CITY"); dt_Item.Columns.Add("M_P_GROWER_COUNTRY_SUBDIV"); dt_Item.Columns.Add("M_P_GROWER_PIN");
                    dt_Item.Columns.Add("M_P_GROWER_COUNTRY");
                    dt_Item.Columns.Add("SOURCE_STATE"); dt_Item.Columns.Add("TRANSIT_COUNTRY"); dt_Item.Columns.Add("ACCESSORY_STATUS");
                    dt_Item.Columns.Add("HAWB_NO"); dt_Item.Columns.Add("TOTAL_PKGS");  dt_Item.Columns.Add("ENDUSE_ITEM");
                    dt_Item.Columns.Add("IGST_PAYMENT"); dt_Item.Columns.Add("TAXABLE_VALUE"); dt_Item.Columns.Add("IGST_AMT");
                    dt_Item.Columns.Add("GSTN_TYPE"); dt_Item.Columns.Add("GSTN_ID"); dt_Item.Columns.Add("IGST_RATE"); dt_Item.Columns.Add("PMV_METHOD");
                    dt_Item.Columns.Add("PMV_RATE"); dt_Item.Columns.Add("PMV_PER_UNIT"); dt_Item.Columns.Add("RODTEP"); dt_Item.Columns.Add("AMENDMENT_TYPE");
                    dt_Item.Columns.Add("AMENDMENT_STATUS"); dt_Item.Columns.Add("RODTEP_VALUE"); 

                    ln = pos + 1;
                    
                    for (ln = ln; ln < lines.Length-1; ln++)
                    {
                        if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-SB>"))))
                        {
                           
                            invno_fromfile = "";
                            lnItm = lines[ln].ToString().Split('^');
                            if (lnItm.Length >= 40)
                            {

                                if (dt_Inv.Rows.Count > 0)
                                {
                                    //invno_fromfile
                                    DataRow[] dr = dt_Inv.Select("INVOICE_SLNO = '" + lnItm[6].ToString() + "' ");  

                                    if (dr.Length > 0)
                                    {

                                        invno_fromfile = dr[0].ItemArray[4].ToString().Trim();
                                    }
                                }

                                if (lnItm.Length == 40)  
                                {
                                    dt_Item.Rows.Add(EX_ITEM_ID, Convert.ToInt64(txtJobNo), Convert.ToInt64(lnItm[6].ToString()), invno_fromfile, Convert.ToInt64(lnItm[7].ToString()), lnItm[10].ToString(), lnItm[9].ToString(),
                                    lnItm[14].ToString(), lnItm[16].ToString(), lnItm[15].ToString(),
                                    lnItm[17].ToString(), "", lnItm[18].ToString(), lnItm[8].ToString(), "", "", "01/01/1900", "", "", "", "", "", "",
                                    "", "", "", "", "", "", "", lnItm[21].ToString(), Session["currentuser"].ToString(), cur_date,
                                    "N", Session["currentbranch"].ToString(), "", Session["WorkingPeriod"].ToString(), lnItm[18].ToString(), "", "", "N", "", "01/01/1900", "0.00", "",
                                    lnItm[25].ToString(), lnItm[26].ToString(), lnItm[27].ToString(), "", "", lnItm[28].ToString(), lnItm[29].ToString(), lnItm[30].ToString(), lnItm[31].ToString(), lnItm[32].ToString(),
                                    lnItm[33].ToString(), lnItm[35].ToString(), lnItm[36].ToString(), lnItm[34].ToString(),
                                    lnItm[37].ToString(), lnItm[38].ToString(), lnItm[39].ToString(), "", "", "", "", "0.00", "", "NA", "", "", "");
                                    item_schem_code = item_schem_code + "~" + lnItm[8].ToString();
                                }

                                else if (lnItm.Length == 42)  // empty manufacturer
                                {
                                     dt_Item.Rows.Add(EX_ITEM_ID, Convert.ToInt64(txtJobNo), Convert.ToInt64(lnItm[6].ToString()), invno_fromfile, Convert.ToInt64(lnItm[7].ToString()), lnItm[10].ToString(), lnItm[9].ToString(),
                                     lnItm[14].ToString(), lnItm[16].ToString(), lnItm[15].ToString(),
                                     lnItm[17].ToString(), "", lnItm[18].ToString(), lnItm[8].ToString(), "", "", "01/01/1900", "", "", "", "", "", "",
                                     "", "", "", "", "", "", "", lnItm[21].ToString(), Session["currentuser"].ToString(), cur_date,
                                     "N", Session["currentbranch"].ToString(), "", Session["WorkingPeriod"].ToString(), lnItm[18].ToString(), "", "", "N", "", "01/01/1900", "0.00", "",
                                     lnItm[25].ToString(), lnItm[26].ToString(), lnItm[27].ToString(), lnItm[28].ToString(), lnItm[29].ToString(), lnItm[30].ToString(), lnItm[31].ToString(), lnItm[32].ToString(),
                                     lnItm[33].ToString(), lnItm[34].ToString(), lnItm[35].ToString(),
                                     lnItm[37].ToString(), lnItm[38].ToString(), lnItm[36].ToString(), lnItm[39].ToString(), lnItm[40].ToString(), lnItm[41].ToString(), "", "", "", "", "0.00", "", "NA", "", "", "");
                                     item_schem_code = item_schem_code + "~" + lnItm[8].ToString();
                                }


                                EX_ITEM_ID = EX_ITEM_ID + 1;
                            }
                        }
                        else
                        {

                            break;

                        }
                    }

                    #endregion dt_Item

                    pos = ln + 1;
                    break;

                }
            }

          

            //****************************** end of item ************************/////

            //****************************** Start of Item Access details ************************/////

            for (int ln = 0; ln < lines.Length; ln++)
            {
                string[] lnItm;
                pos = Array.IndexOf(lines, "<TABLE>ITEMACCESS");

                if (result == 1 && pos > 0)
                {

                    #region dt_Item_access
                    dt_Item_access.Columns.Add("INVOICE_SLNO"); dt_Item_access.Columns.Add("ITEM_SLNO"); dt_Item_access.Columns.Add("ITEM_ACCESSORIES_DESC_NEW");

                    ln = pos + 1;

                    for (ln = ln; ln < lines.Length - 1; ln++)
                    {
                        if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-SB>"))))
                        {
                            
                            lnItm = lines[ln].ToString().Split('^');
                            if (lnItm.Length >= 9)
                            {

                                dt_Item_access.Rows.Add(lnItm[6].ToString(), lnItm[7].ToString(), lnItm[8].ToString());
                                
                            }
                        }

                        else
                        {

                            break;

                        }
                    }

                    #endregion dt_Item_access
                    pos = ln + 1;
                    break;
                }

            }


            for (int ln = 0; ln < lines.Length; ln++)
            {
                string[] lnItm;
                pos = Array.IndexOf(lines, "<TABLE>THIRDPARTY");

                if (result == 1 && pos > 0)
                {
                    #region dt_item_thirdparty
                    dt_item_thirdparty.Columns.Add("INVOICE_SLNO"); dt_item_thirdparty.Columns.Add("ITEM_SLNO"); dt_item_thirdparty.Columns.Add("ITEM_IECCODE_NEW");
                    dt_item_thirdparty.Columns.Add("ITEM_EXPORTER_NAME_NEW"); dt_item_thirdparty.Columns.Add("BR_SLNO_NEW"); dt_item_thirdparty.Columns.Add("ADDRESS1_NEW");
                    dt_item_thirdparty.Columns.Add("ADDRESS2_NEW"); dt_item_thirdparty.Columns.Add("ADDRESS3_NEW"); dt_item_thirdparty.Columns.Add("ADDRESS4_NEW"); dt_item_thirdparty.Columns.Add("ADDRESS5_NEW");
                    dt_item_thirdparty.Columns.Add("GSTN_TYPE_NEW"); dt_item_thirdparty.Columns.Add("GSTN_ID_NEW");

                    ln = pos + 1;

                    for (ln = ln; ln < lines.Length - 1; ln++)
                    {
                        if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-SB>"))))
                        {
                            
                            lnItm = lines[ln].ToString().Split('^');
                            if (lnItm.Length >= 14)
                            {
                                dt_item_thirdparty.Rows.Add(lnItm[6].ToString(), lnItm[7].ToString(), lnItm[8].ToString(), lnItm[10].ToString(), lnItm[9].ToString(), lnItm[11].ToString(),
                                lnItm[12].ToString(), lnItm[13].ToString(),"",lnItm[14].ToString(), lnItm[18].ToString(), lnItm[19].ToString());

                            }
                        }

                        else
                        {

                            break;

                        }
                    }

                    #endregion dt_item_thirdparty

                    pos = ln + 1;


                    break;
                }

            }

            if (dt_Item.Rows.Count > 0)
            {
                if (dt_Item_access.Rows.Count > 0)
                { 
                
                //merger 

                    foreach (DataRow row in dt_Item.Rows)
                    {
                                                DataRow[] query_Info1 = dt_Item_access.Select("ITEM_SLNO='" + row.Field<string>("ITEM_SLNO") + "' and INVOICE_SLNO='" + row.Field<string>("INVOICE_SLNO") + "'" );
                        if (query_Info1 != null && query_Info1.Length >= 1)
                        {
                            row.SetField("ITEM_ACCESSORIES_DESC", query_Info1[0][2].ToString());  

                        } 

                    }  
                
                }

                if (dt_item_thirdparty.Rows.Count > 0)
                {

                    foreach (DataRow row in dt_Item.Rows)
                    {
                        DataRow[] query_Info1 = dt_item_thirdparty.Select("ITEM_SLNO='" + row.Field<string>("ITEM_SLNO") + "' and INVOICE_SLNO='" + row.Field<string>("INVOICE_SLNO") + "'");
                        if (query_Info1 != null && query_Info1.Length >= 1)
                        {
                            row.SetField("ITEM_IECCODE", query_Info1[0][2].ToString()); row.SetField("ITEM_EXPORTER_NAME", query_Info1[0][3].ToString()); row.SetField("BR_SLNO", query_Info1[0][4].ToString());
                            row.SetField("ADDRESS1", query_Info1[0][5].ToString()); row.SetField("ADDRESS2", query_Info1[0][6].ToString()); row.SetField("ADDRESS3", query_Info1[0][7].ToString());
                            row.SetField("ADDRESS4", query_Info1[0][8].ToString()); row.SetField("ADDRESS5", query_Info1[0][9].ToString()); row.SetField("GSTN_TYPE", query_Info1[0][10].ToString());
                            row.SetField("GSTN_ID", query_Info1[0][11].ToString());
                        }

                    }

                }
                      
                admin.SqlBulk_Upload_Product("EXPORT_ITEM_DETAILS", dt_Item, comp_ConnectionStr);
            }

            //****************************** end of Item details ************************/////

            //****************************** starts Cess details ************************/////


            //for (int ln = pos; ln < lines.Length; ln++)
            for (int ln = 0; ln < lines.Length; ln++)
            {
                string[] lnItm;
                pos = Array.IndexOf(lines, "<TABLE>CESS");

                if (result == 1 && pos > 0)
                {

                    #region dt_Cess
                    dt_Cess.Columns.Add("CESS_ID"); dt_Cess.Columns.Add("JOBNO"); dt_Cess.Columns.Add("INVOICE_SLNO"); dt_Cess.Columns.Add("ITEM_SLNO"); dt_Cess.Columns.Add("CESS_SLNO");
                    dt_Cess.Columns.Add("CESS_VALUE"); dt_Cess.Columns.Add("CESS_UNIT"); dt_Cess.Columns.Add("CESS_FLAG"); dt_Cess.Columns.Add("CESS_RATE"); dt_Cess.Columns.Add("CESS_ITEM_QTY");
                    dt_Cess.Columns.Add("CESS_ITEM_QTY_CODE"); dt_Cess.Columns.Add("CESS_TARIFF_VALUE"); dt_Cess.Columns.Add("CESS_TARIFF_UNIT");
                    dt_Cess.Columns.Add("USER_ID"); dt_Cess.Columns.Add("DATE_TIME"); dt_Cess.Columns.Add("STATUS"); dt_Cess.Columns.Add("BRANCH_CODE");
                    dt_Cess.Columns.Add("YEAR"); dt_Cess.Columns.Add("WORKING_PERIOD"); dt_Cess.Columns.Add("MODIFIEDBY"); dt_Cess.Columns.Add("MODIFIEDON");

                    ln = pos + 1;

                    for (ln = ln; ln < lines.Length - 1; ln++)
                    {
                        if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-SB>"))))
                        {
                        
                            lnItm = lines[ln].ToString().Split('^');
                            if (lnItm.Length >= 10)
                            {
                               
                                dt_Cess.Rows.Add(EX_CESS_ID, Convert.ToInt64(txtJobNo.ToString()), lnItm[6].ToString(), lnItm[7].ToString(), lnItm[9].ToString(),"",
                               "","","",lnItm[10].ToString(),"","","", Session["currentuser"].ToString(), cur_date,
                               "N", Session["currentbranch"].ToString(), "", Session["WorkingPeriod"].ToString(),"", "01/01/1900");
                                cess_slno = cess_slno + "~" + lnItm[9].ToString();
                                EX_CESS_ID = EX_CESS_ID + 1;
                            }
                        }

                        else
                        {

                            break;

                        }
                    }

                    if (dt_Cess.Rows.Count > 0)
                    {
                        admin.SqlBulk_Upload_Product("EXPORT_CESS_DETAILS", dt_Cess, comp_ConnectionStr);
                    }

                    #endregion dt_Cess

                    pos = ln + 1;


                    break;
                }

            }

            //****************************** end of Cess Details ************************/////




            //****************************** starts AR4 ************************/////


            //for (int ln = pos; ln < lines.Length; ln++)
            for (int ln = 0; ln < lines.Length; ln++)
            {
                string invno_fromfile = "";
                string[] lnItm;
                pos = Array.IndexOf(lines, "<TABLE>AR4");

                if (result == 1 && pos > 0 )
                {

                        #region dt_AR4
                        dt_AR4.Columns.Add("AR4_ID"); dt_AR4.Columns.Add("AR4_JOBNO"); dt_AR4.Columns.Add("AR4_NO"); dt_AR4.Columns.Add("AR4_DATE"); dt_AR4.Columns.Add("AR4_COMMISSION_RATE");
                        dt_AR4.Columns.Add("AR4_DIVISION"); dt_AR4.Columns.Add("AR4_RANGE"); dt_AR4.Columns.Add("AR4_REMARKS"); dt_AR4.Columns.Add("USER_ID"); dt_AR4.Columns.Add("DATE_TIME");
                        dt_AR4.Columns.Add("STATUS"); dt_AR4.Columns.Add("BRANCH_CODE");
                        dt_AR4.Columns.Add("YEAR"); dt_AR4.Columns.Add("WORKING_PERIOD"); dt_AR4.Columns.Add("AR4_INVOICE_NO"); dt_AR4.Columns.Add("AR4_INVOICE_SLNO");
                        dt_AR4.Columns.Add("AR4_RUN_ID"); dt_AR4.Columns.Add("AR4_ITEM_NO"); dt_AR4.Columns.Add("MODIFIEDBY"); dt_AR4.Columns.Add("MODIFIEDON");

                        ln = pos + 1;
                    
                        for (ln = ln; ln < lines.Length-1; ln++)
                        {
                            if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-SB>"))))
                            {
                                
                                invno_fromfile = "";
                                lnItm = lines[ln].ToString().Split('^');
                                if (lnItm.Length >= 10)
                                {
                                    if (dt_Inv.Rows.Count > 0)
                                    {
                                        //invno_fromfile
                                        DataRow[] dr = dt_Inv.Select("INVOICE_SLNO = '" + lnItm[6].ToString() + "' ");

                                        if (dr.Length > 0)
                                        {

                                            invno_fromfile = dr[0].ItemArray[4].ToString().Trim();
                                        }
                                    }

                                    dt_AR4.Rows.Add(EX_AR4_ID, Convert.ToInt64(txtJobNo.ToString()), lnItm[8].ToString(), lnItm[3].ToString().Substring(6, 2) + "/" + lnItm[3].ToString().Substring(4, 2) + "/" + lnItm[3].ToString().Substring(0, 4),
                                   lnItm[10].ToString(), lnItm[11].ToString(), lnItm[12].ToString(), lnItm[13].ToString(), Session["currentuser"].ToString(), cur_date,
                                   "N", Session["currentbranch"].ToString(), "", Session["WorkingPeriod"].ToString(), invno_fromfile, Convert.ToInt64(lnItm[6].ToString()), 1,
                                   lnItm[7].ToString(), "", "01/01/1900");

                                    EX_AR4_ID = EX_AR4_ID + 1;
                                }
                            }

                            else
                            {

                                break;

                            }
                        }

                        if (dt_AR4.Rows.Count > 0)
                        {
                            admin.SqlBulk_Upload_Product("EXPORT_AR4_TBL", dt_AR4, comp_ConnectionStr);
                        }

                        #endregion dt_AR4

                        pos = ln + 1;
                    

                        break;
                }

            }

            //****************************** end of AR4 ************************/////

            //****************************** starts drawback ************************/////


           // for (int ln = pos; ln < lines.Length; ln++)
            for (int ln = 0; ln < lines.Length; ln++)
            {

                string[] lnItm;
                string schem_code_fromfile = "";
                pos = Array.IndexOf(lines, "<TABLE>DBK");

                if (result == 1)
                { 
                    if (result == 1 && pos > 0)
                    {

                        #region dt_Dbk
                        dt_Dbk.Columns.Add("DRAWBACK_ID"); dt_Dbk.Columns.Add("JOBNO"); dt_Dbk.Columns.Add("INVOICE_SLNO"); dt_Dbk.Columns.Add("ITEM_SLNO"); dt_Dbk.Columns.Add("SCHEME_CODE");
                        dt_Dbk.Columns.Add("DRAWBACK_SLNO"); dt_Dbk.Columns.Add("DRAWBACK_QTY"); dt_Dbk.Columns.Add("DRAWBACK_UNIT"); dt_Dbk.Columns.Add("DRAWBACK_NOOFUNITS");
                        dt_Dbk.Columns.Add("DRAWBACK_RATE"); dt_Dbk.Columns.Add("DRAWBACK_CAPS"); dt_Dbk.Columns.Add("DRAWBACK_DESC"); dt_Dbk.Columns.Add("USER_ID");
                        dt_Dbk.Columns.Add("DATE_TIME"); dt_Dbk.Columns.Add("STATUS"); dt_Dbk.Columns.Add("BRANCH_CODE"); dt_Dbk.Columns.Add("YEAR"); dt_Dbk.Columns.Add("WORKING_PERIOD");
                        dt_Dbk.Columns.Add("MODIFIEDBY"); dt_Dbk.Columns.Add("MODIFIEDON"); dt_Dbk.Columns.Add("STATE_LEVEL_ADV_RATE"); dt_Dbk.Columns.Add("STATE_LEVEL_ADV_AMT");
                        dt_Dbk.Columns.Add("CENTRAL_LEVEL_ADV_RATE"); dt_Dbk.Columns.Add("CENTRAL_LEVEL_ADV_AMT"); dt_Dbk.Columns.Add("AMENDMENT_TYPE"); dt_Dbk.Columns.Add("AMENDMENT_STATUS");


                        ln = pos + 1;
                      
                        for (ln = ln; ln < lines.Length-1; ln++)
                        {
                            if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-SB>"))))
                            {
                                
                                schem_code_fromfile = "";
                               
                                lnItm = lines[ln].ToString().Split('^');
                                if (lnItm.Length >= 13)
                                {
                                    if (dt_Item.Rows.Count > 0)
                                    {
                                        //invno_fromfile
                                        DataRow[] dr = dt_Item.Select("INVOICE_SLNO = '" + lnItm[6].ToString() + "' ");

                                        if (dr.Length > 0)
                                        {

                                            schem_code_fromfile = dr[0].ItemArray[13].ToString().Trim();
                                           
                                        }
                                    }
                                    dt_Dbk.Rows.Add(EX_DBK_ID, Convert.ToInt64(txtJobNo.ToString()), Convert.ToInt64(lnItm[6].ToString()), Convert.ToInt64(lnItm[7].ToString()), schem_code_fromfile,
                                    lnItm[8].ToString(), lnItm[9].ToString(), "", "", "", "", "", Session["currentuser"].ToString(), cur_date,
                                    "N", Session["currentbranch"].ToString(), "", Session["WorkingPeriod"].ToString(), "", "01/01/1900", "", "", "", "", "", "");
                                    drawbk_sno = drawbk_sno + "~" + lnItm[8].ToString();


                                    EX_DBK_ID = EX_DBK_ID + 1;
                                }
                            }
                            else
                            {

                                break;

                            }
                        }

                        if (dt_Dbk.Rows.Count > 0)
                        {
                            admin.SqlBulk_Upload_Product("EXPORT_DRAWBACK_DETAILS", dt_Dbk, comp_ConnectionStr);
                        }

                        pos = ln + 1;
                        #endregion dt_Dbk
                    }
                    break;

                }
            }



            //****************************** starts jobwork ************************/////


            // for (int ln = pos; ln < lines.Length; ln++)
            for (int ln = 0; ln < lines.Length; ln++)
            {

                string[] lnItm;
                string schem_code_fromfile = "";
                pos = Array.IndexOf(lines, "<TABLE>JOBWORK");

                if (result == 1)
                {
                    if (result == 1 && pos > 0)
                    {

                        #region dt_Job_Work
                        dt_Job_Work.Columns.Add("JOBBING_ID"); dt_Job_Work.Columns.Add("JOBNO"); dt_Job_Work.Columns.Add("INVOICE_SLNO"); dt_Job_Work.Columns.Add("ITEM_SLNO"); dt_Job_Work.Columns.Add("SCHEME_CODE");
                        dt_Job_Work.Columns.Add("NOTIFICATION_NO"); dt_Job_Work.Columns.Add("BE_NO"); dt_Job_Work.Columns.Add("BE_DATE"); dt_Job_Work.Columns.Add("BE_INV_SLNO");
                        dt_Job_Work.Columns.Add("BE_INV_NO"); dt_Job_Work.Columns.Add("BE_ITEM_NO"); dt_Job_Work.Columns.Add("BE_PORT_CODE"); dt_Job_Work.Columns.Add("QTY");
                        dt_Job_Work.Columns.Add("UNIT"); dt_Job_Work.Columns.Add("USER_ID"); dt_Job_Work.Columns.Add("DATE_TIME"); dt_Job_Work.Columns.Add("STATUS"); dt_Job_Work.Columns.Add("BRANCH_CODE");
                        dt_Job_Work.Columns.Add("YEAR"); dt_Job_Work.Columns.Add("WORKING_PERIOD"); dt_Job_Work.Columns.Add("MODIFIEDBY"); dt_Job_Work.Columns.Add("MODIFIEDON");

                        ln = pos + 1;

                        for (ln = ln; ln < lines.Length - 1; ln++)
                        {
                            if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-SB>"))))
                            {
                              
                                schem_code_fromfile = "";

                                lnItm = lines[ln].ToString().Split('^');
                                if (lnItm.Length >= 16)
                                {
                                    if (dt_Item.Rows.Count > 0)
                                    {
                                        
                                        DataRow[] dr = dt_Item.Select("INVOICE_SLNO = '" + lnItm[6].ToString() + "' ");

                                        if (dr.Length > 0)
                                        {

                                            schem_code_fromfile = dr[0].ItemArray[13].ToString().Trim();

                                        }
                                    }
                                    dt_Job_Work.Rows.Add(EX_JOBBING_ID, Convert.ToInt64(txtJobNo.ToString()), Convert.ToInt64(lnItm[6].ToString()), Convert.ToInt64(lnItm[7].ToString()), schem_code_fromfile,
                                    lnItm[8].ToString(), lnItm[9].ToString(), lnItm[10].ToString().Substring(6, 2) + "/" + lnItm[10].ToString().Substring(4, 2) + "/" + lnItm[10].ToString().Substring(0, 4),
                                    lnItm[11].ToString(), lnItm[12].ToString(), lnItm[13].ToString(), lnItm[14].ToString(), lnItm[15].ToString(), lnItm[16].ToString(), Session["currentuser"].ToString(), cur_date,
                                    "N", Session["currentbranch"].ToString(), "", Session["WorkingPeriod"].ToString(), "", "01/01/1900");
                                   // drawbk_sno = drawbk_sno + "~" + lnItm[8].ToString();


                                    EX_JOBBING_ID = EX_JOBBING_ID + 1;
                                }
                            }
                            else
                            {

                                break;

                            }
                        }

                        if (dt_Job_Work.Rows.Count > 0)
                        {
                            admin.SqlBulk_Upload_Product("EXPORT_JOBBING", dt_Job_Work, comp_ConnectionStr);
                        }

                        pos = ln + 1;
                        #endregion dt_Job_Work
                    }
                    break;

                }
            }

            //****************************** end of jobwork ************************/////

            //****************************** starts license ************************/////


            // for (int ln = pos; ln < lines.Length; ln++)
            for (int ln = 0; ln < lines.Length; ln++)
            {

                string[] lnItm;
                string schem_fromfile = "";
                pos = Array.IndexOf(lines, "<TABLE>LICENCE");
                {
 
                        #region dt_Exp_lic
                        dt_Exp_lic.Columns.Add("LICENSE_ID"); dt_Exp_lic.Columns.Add("JOB_NO"); dt_Exp_lic.Columns.Add("INV_SL_NO"); dt_Exp_lic.Columns.Add("ITEM_SL_NO");
                        dt_Exp_lic.Columns.Add("SCHEME_CODE"); dt_Exp_lic.Columns.Add("SCHEME"); dt_Exp_lic.Columns.Add("LICENSE_R_SL_NO"); dt_Exp_lic.Columns.Add("LICENSE_NO");
                        dt_Exp_lic.Columns.Add("LICENSE_DATE"); dt_Exp_lic.Columns.Add("USER_ID"); dt_Exp_lic.Columns.Add("DATE_TIME"); dt_Exp_lic.Columns.Add("STATUS");
                        dt_Exp_lic.Columns.Add("BRANCH_CODE"); dt_Exp_lic.Columns.Add("YEAR"); dt_Exp_lic.Columns.Add("WORKING_PERIOD");
                        dt_Exp_lic.Columns.Add("MODIFIEDBY"); dt_Exp_lic.Columns.Add("MODIFIEDON");

                        ln = pos + 1;
                        inc = 1;
                        string curlicense = "", prelicense = "";
                        for (ln = ln; ln < lines.Length-1; ln++)
                        {
                            if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-SB>"))))
                            {
                                
                                schem_fromfile = "";
                                lnItm = lines[ln].ToString().Split('^');
                                if (lnItm.Length >= 19)
                                {
                                    if (dt_Item.Rows.Count > 0)
                                    {
                                       
                                        DataRow[] dr = dt_Item.Select("INVOICE_SLNO = '" + lnItm[6].ToString() + "' ");

                                        if (dr.Length > 0)
                                        {

                                            schem_fromfile = dr[0].ItemArray[13].ToString().Trim();
                                        }
                                    }

                                     dt_Exp_lic.Rows.Add(EX_LIC_ID, Convert.ToInt64(txtJobNo.ToString()), Convert.ToInt64(lnItm[6].ToString()), Convert.ToInt64(lnItm[7].ToString()),
                                     schem_fromfile,"", "1", lnItm[9].ToString(), lnItm[10].ToString().Substring(6, 2) + "/" + lnItm[10].ToString().Substring(4, 2) + "/" + lnItm[10].ToString().Substring(0, 4),
                                    Session["currentuser"].ToString(), cur_date, "N", Session["currentbranch"].ToString(), "", Session["WorkingPeriod"].ToString(), "", "01/01/1900");
                                     prelicense = lnItm[7].ToString();
                                     
                                    EX_LIC_ID = EX_LIC_ID + 1;
                                }
                            }
                            else
                            {

                                break;

                            }
                        }
  
                        if (dt_Exp_lic.Rows.Count > 0)
                        {

                            admin.SqlBulk_Upload_Product("EXPORT_LICENSE_DETAILS", dt_Exp_lic, comp_ConnectionStr);
                        }

                        pos = ln + 1;

                        #endregion dt_Imp_Exp_lic
                    
                    break;


                }

            }
            //****************************** end of license ************************/////  


            //****************************** starts license ************************/////

          
            // for (int ln = pos; ln < lines.Length; ln++)
            for (int ln = 0; ln < lines.Length; ln++)
            {

                string[] lnItm;
                string Ex_Item_Qty="";
                pos = Array.IndexOf(lines, "<TABLE>LICENCE");

                if (result == 1 && pos > 0 && dt_Exp_lic.Rows.Count>0)
                {
                     
                     
                        #region dt_Imp_Exp_lic
                        dt_Imp_Exp_lic.Columns.Add("LICENSE_IMP_EXP_ID"); dt_Imp_Exp_lic.Columns.Add("LICENSE_ID"); dt_Imp_Exp_lic.Columns.Add("JOB_NO"); dt_Imp_Exp_lic.Columns.Add("LICENSE_REG_SLNO");
                        dt_Imp_Exp_lic.Columns.Add("LICENSE_NO"); dt_Imp_Exp_lic.Columns.Add("LICENSE_E_SL_NO"); dt_Imp_Exp_lic.Columns.Add("LICENSE_EXP_QTY"); dt_Imp_Exp_lic.Columns.Add("LICENSE_EXP_UNIT");
                        dt_Imp_Exp_lic.Columns.Add("LICENSE_IMP_ITEM_SL_NO"); dt_Imp_Exp_lic.Columns.Add("LICENSE_IMP_DESC"); dt_Imp_Exp_lic.Columns.Add("LICENSE_IMP_QTY"); dt_Imp_Exp_lic.Columns.Add("LICENSE_IMP_UNIT");
                        dt_Imp_Exp_lic.Columns.Add("LICENSE_IMP_TYPE"); dt_Imp_Exp_lic.Columns.Add("USER_ID"); dt_Imp_Exp_lic.Columns.Add("DATE_TIME");
                        dt_Imp_Exp_lic.Columns.Add("STATUS"); dt_Imp_Exp_lic.Columns.Add("BRANCH_CODE"); dt_Imp_Exp_lic.Columns.Add("YEAR"); dt_Imp_Exp_lic.Columns.Add("WORKING_PERIOD");dt_Imp_Exp_lic.Columns.Add("INV_SL_NO");
                        dt_Imp_Exp_lic.Columns.Add("ITEM_SL_NO"); dt_Imp_Exp_lic.Columns.Add("SCHEME"); dt_Imp_Exp_lic.Columns.Add("MODIFIEDBY"); dt_Imp_Exp_lic.Columns.Add("MODIFIEDON");
                        dt_Imp_Exp_lic.Columns.Add("AMENDMENT_TYPE"); 

                        ln = pos + 1;
                        inc = 1;
                        string curlicense="", prelicense="";
                        
                        for (ln = ln; ln < lines.Length-1; ln++)
                        {
                            if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-SB>"))))
                            {
                                
                                Ex_Item_Qty = "";
                                lnItm = lines[ln].ToString().Split('^');
                                if (lnItm.Length >= 19)
                                {
                                    if (dt_Item.Rows.Count > 0)
                                    {

                                        DataRow[] dr = dt_Item.Select("INVOICE_SLNO = '" + lnItm[6].ToString() + "' ");

                                        if (dr.Length > 0)
                                        {

                                            Ex_Item_Qty = dr[0].ItemArray[8].ToString().Trim();
                                        }
                                    }
                                    dt_Imp_Exp_lic.Rows.Add(EX_LICENSE_ID, dt_Exp_lic.Rows[0][0].ToString(), Convert.ToInt64(txtJobNo.ToString()),
                                 inc.ToString(), lnItm[9].ToString(), lnItm[11].ToString(), lnItm[14].ToString(), Ex_Item_Qty, lnItm[12].ToString(), "",
                                 lnItm[13].ToString(), Ex_Item_Qty, lnItm[15].ToString(), Session["currentuser"].ToString(), cur_date, "N", Session["currentbranch"].ToString(), "", Session["WorkingPeriod"].ToString(),
                                 Convert.ToInt64(lnItm[6].ToString()), Convert.ToInt64(lnItm[7].ToString()),"","", "01/01/1900","");

                                    EX_LICENSE_ID = EX_LICENSE_ID + 1;
                                    inc = inc + 1;
                                   

                                }
                            }
                            else
                            {

                                break;

                            }
                        }

                        if (dt_Imp_Exp_lic.Rows.Count > 0)
                        {
                            admin.SqlBulk_Upload_Product("EXPORT_LICENSE_IMP_EXP_DETAILS", dt_Imp_Exp_lic, comp_ConnectionStr);
                        }

                        pos = ln + 1;

                        #endregion dt_Imp_Exp_lic
                    
                    break;

                }

            }

            //****************************** end of license ************************/////  

            //****************************** starts packing list ************************/////


            //for (int ln = pos; ln < lines.Length; ln++)
                for (int ln = 0; ln < lines.Length; ln++)
            {

                string[] lnItm;
                pos = Array.IndexOf(lines, "<TABLE>PACKINGLIST");

                if (result == 1 && pos > 0)
                { 
                        #region dt_packing_list
                        dt_packing_list.Columns.Add("ANNEX_SEA_PACK_ID"); dt_packing_list.Columns.Add("ANNEX_SEA_PACK_JOBNO"); dt_packing_list.Columns.Add("ANNEX_SEA_PACK_GROUP");
                        dt_packing_list.Columns.Add("ANNEX_SEA_PACK_FROM"); dt_packing_list.Columns.Add("ANNEX_SEA_PACK_TO"); dt_packing_list.Columns.Add("ANNEX_SEA_PACK_PACKAGETYPE");
                        dt_packing_list.Columns.Add("USER_ID"); dt_packing_list.Columns.Add("DATE_TIME"); dt_packing_list.Columns.Add("STATUS"); dt_packing_list.Columns.Add("BRANCH_CODE");
                        dt_packing_list.Columns.Add("YEAR"); dt_packing_list.Columns.Add("WORKING_PERIOD"); dt_packing_list.Columns.Add("ANNEX_SEA_PACK_FROMDESC");
                        dt_packing_list.Columns.Add("ANNEX_SEA_PACK_TODESC"); dt_packing_list.Columns.Add("MODIFIEDBY"); dt_packing_list.Columns.Add("MODIFIEDON");

                        ln = pos + 1;
                        Grp_Id =1;
                        for (ln = ln; ln < lines.Length-1; ln++)
                        {
                            if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-SB>"))))
                            {
                                //  sw.WriteLine("F" 0+ ch + CUSTOMS_HOUSE 1+ ch + ddlJobNo.SelectedValue.ToString() 2+ ch + JOBDATE 3 + ch + ANNEX_SEA_PACK_FROM 4+ ch + ANNEX_SEA_PACK_TO 5+ ch + ANNEX_SEA_PACK_PACKAGETYPE 6);

                                //
                                lnItm = lines[ln].ToString().Split('^');
                                if (lnItm.Length >=6)
                                {
                                    dt_packing_list.Rows.Add(EX_ANN_PACK_ID, Convert.ToInt64(txtJobNo.ToString()), Grp_Id, lnItm[4].ToString(), lnItm[5].ToString(), lnItm[6].ToString(),
                                        Session["currentuser"].ToString(), cur_date, "N", Session["currentbranch"].ToString(), "", Session["WorkingPeriod"].ToString(), "", "", "", "01/01/1900");

                                    EX_ANN_PACK_ID = EX_ANN_PACK_ID + 1;
                                    Grp_Id = Grp_Id + 1;
                                }
                            }
                            else
                            {

                                break;

                            }
                        }

                        if (dt_packing_list.Rows.Count > 0)
                        {
                            admin.SqlBulk_Upload_Product("EXPORT_ANNEXURE_C_SEA_PACKAGE", dt_packing_list, comp_ConnectionStr);
                        }

                        pos = ln + 1;
                        #endregion packing_list
                     
                    break;
                   
                }

            }
            //****************************** end of license ************************/////  



           //****************************** starts Annexure Details ************************/////


                //for (int ln = pos; ln < lines.Length; ln++)
                for (int ln = 0; ln < lines.Length; ln++)
                {
                   
                    string[] lnItm;
                    pos = Array.IndexOf(lines, "<TABLE>ROTATION");
                    dt_rotation.Columns.Add("C1"); dt_rotation.Columns.Add("C2"); dt_rotation.Columns.Add("C3");
                    dt_rotation.Columns.Add("C4"); dt_rotation.Columns.Add("C5"); dt_rotation.Columns.Add("C6");
                    dt_rotation.Columns.Add("C7"); dt_rotation.Columns.Add("C8"); dt_rotation.Columns.Add("C9");
                    dt_rotation.Columns.Add("C10"); dt_rotation.Columns.Add("C11"); dt_rotation.Columns.Add("C12");
                    dt_rotation.Columns.Add("C13"); dt_rotation.Columns.Add("C14"); dt_rotation.Columns.Add("C15");
                    dt_rotation.Columns.Add("C16"); dt_rotation.Columns.Add("C17"); dt_rotation.Columns.Add("C18");
                    dt_rotation.Columns.Add("C19"); dt_rotation.Columns.Add("C20"); dt_rotation.Columns.Add("C21");
                    dt_rotation.Columns.Add("C22"); dt_rotation.Columns.Add("C23"); dt_rotation.Columns.Add("C24");
                    dt_rotation.Columns.Add("C25"); dt_rotation.Columns.Add("C26"); dt_rotation.Columns.Add("C27");
                    dt_rotation.Columns.Add("C28"); dt_rotation.Columns.Add("C29"); dt_rotation.Columns.Add("C30");

                    if (result == 1 && pos > 0)
                    {
                        #region dt_rotation




                        ln = pos + 1;
                        //int rotat = Convert.ToInt64(dsAutoID.tables[0].rows[0]["Re_expID"].tostring());
                        int rotat = 1;
                        for (ln = ln; ln < lines.Length - 1; ln++)
                        {
                            if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-SB>"))))
                            {
                                

                                lnItm = lines[ln].ToString().Split('^');
                                if (lnItm.Length >= 5)
                                {


                                    if (Gen.TRANSPORT_MODE == "Air")
                                    {
                                        dt_rotation.Rows.Add(EX_ANN_A_ID, Convert.ToInt64(txtJobNo.ToString()), "N", "N", NATURE_OF_CARGO, MARKS_NO, TOTAL_PACKAGES, UNIT_CODE, "", "", GROSS_WEIGHT, UNIT_CODE, NET_WEIGHT,
                                      ANNEX_AIR_MAWB_NO, ANNEX_AIR_HAWB_NO, "", lnItm[5].ToString(), lnItm[4].ToString().Substring(6, 2) + "/" + lnItm[4].ToString().Substring(4, 2) + "/" + lnItm[4].ToString().Substring(0, 4),
                                      "", Session["currentuser"].ToString(), cur_date, "N", Session["currentbranch"].ToString(), "", Session["WorkingPeriod"].ToString(), "Active", "", "01/01/1900", "01/01/1900", "01/01/1900");

                                    }
                                    else if (Gen.TRANSPORT_MODE == "Sea")
                                    {
                                        dt_rotation.Rows.Add(EX_ANN_C_ID, Convert.ToInt64(txtJobNo.ToString()), "N", "N", NATURE_OF_CARGO, MARKS_NO, TOTAL_PACKAGES, LOOSE_PACKETS, NO_CONTAINERS, GROSS_WEIGHT, NET_WEIGHT, UNIT_CODE,
                                        lnItm[5].ToString(), lnItm[4].ToString().Substring(6, 2) + "/" + lnItm[4].ToString().Substring(4, 2) + "/" + lnItm[4].ToString().Substring(0, 4),
                                        "", Session["currentuser"].ToString(), cur_date, "N", Session["currentbranch"].ToString(), "", Session["WorkingPeriod"].ToString(), "Active", ANNEX_SEA_SEAL_TYPE, "", "01/01/1900", "", "", "", "", UNIT_CODE);

                                    }
                                    if (Gen.TRANSPORT_MODE == "Air")
                                    {
                                        EX_ANN_A_ID = EX_ANN_A_ID + 1;
                                    }

                                    else if (Gen.TRANSPORT_MODE == "Sea")
                                    { EX_ANN_C_ID = EX_ANN_C_ID + 1; }

                                }
                            }
                            else
                            {

                                break;

                            }
                        }

                        if (dt_rotation.Rows.Count > 0)
                        {
                            if (Gen.TRANSPORT_MODE == "Air")
                            {
                                admin.SqlBulk_Upload_Product("EXPORT_ANNEXURE_C_AIR", dt_rotation, comp_ConnectionStr);
                            }
                            else if (Gen.TRANSPORT_MODE == "Sea" || Gen.TRANSPORT_MODE == "Land")
                            {
                                admin.SqlBulk_Upload_Product("EXPORT_ANNEXURE_C_SEA", dt_rotation, comp_ConnectionStr);
                            }
                        }

                        pos = ln + 1;
                        #endregion dt_rotation

                        break;

                    }
                    else
                    {
                        if (Gen.TRANSPORT_MODE == "Air")
                        {
                            dt_rotation.Rows.Add(EX_ANN_A_ID, Convert.ToInt64(txtJobNo.ToString()), "N", "N", NATURE_OF_CARGO, MARKS_NO, TOTAL_PACKAGES, UNIT_CODE, "", "", GROSS_WEIGHT, UNIT_CODE, NET_WEIGHT,
                          ANNEX_AIR_MAWB_NO, ANNEX_AIR_HAWB_NO, "", "", "01/01/1900",
                          "", Session["currentuser"].ToString(), cur_date, "N", Session["currentbranch"].ToString(), "", Session["WorkingPeriod"].ToString(), "Active", "", "01/01/1900", "01/01/1900", "01/01/1900");

                        }
                        else if (Gen.TRANSPORT_MODE == "Sea")
                        {
                            dt_rotation.Rows.Add(EX_ANN_C_ID, Convert.ToInt64(txtJobNo.ToString()), "N", "N", NATURE_OF_CARGO, MARKS_NO, TOTAL_PACKAGES, LOOSE_PACKETS, NO_CONTAINERS, GROSS_WEIGHT, NET_WEIGHT, UNIT_CODE,
                            "", "01/01/1900",
                            "", Session["currentuser"].ToString(), cur_date, "N", Session["currentbranch"].ToString(), "", Session["WorkingPeriod"].ToString(), "Active", ANNEX_SEA_SEAL_TYPE, "", "01/01/1900", "", "", "", "", UNIT_CODE);

                        }
                        if (Gen.TRANSPORT_MODE == "Air")
                        {
                            EX_ANN_A_ID = EX_ANN_A_ID + 1;
                        }

                        else if (Gen.TRANSPORT_MODE == "Sea")
                        { EX_ANN_C_ID = EX_ANN_C_ID + 1; }


                        if (dt_rotation.Rows.Count > 0)
                        {
                            if (Gen.TRANSPORT_MODE == "Air")
                            {
                                admin.SqlBulk_Upload_Product("EXPORT_ANNEXURE_C_AIR", dt_rotation, comp_ConnectionStr);
                            }
                            else if (Gen.TRANSPORT_MODE == "Sea" || Gen.TRANSPORT_MODE == "Land")
                            {
                                admin.SqlBulk_Upload_Product("EXPORT_ANNEXURE_C_SEA", dt_rotation, comp_ConnectionStr);
                            }
                        }
                    }
                    break;

                }
                //****************************** end of Annexure Details ************************/////  

    
            //****************************** starts Eou ************************/////
         
                for (int ln = 0; ln < lines.Length; ln++)

            {

                string[] lnItm;
                pos = Array.IndexOf(lines, "<TABLE>EOU");

                if (result == 1 && pos >0)
                {
                    
                        #region dt_EOU
                        dt_EOU.Columns.Add("ANNEX_ID"); dt_EOU.Columns.Add("ANNEX_JOBNO"); dt_EOU.Columns.Add("ANNEX_EXPORTERNAME"); dt_EOU.Columns.Add("ANNEX_IECCODE"); dt_EOU.Columns.Add("ANNEX_BR_SLNO");
                        dt_EOU.Columns.Add("ANNEX_EXAM_DATE"); dt_EOU.Columns.Add("ANNEX_EXAM_OFFICER"); dt_EOU.Columns.Add("ANNEX_EXAM_DESIGN"); dt_EOU.Columns.Add("ANNEX_SUPER_NAME");
                        dt_EOU.Columns.Add("ANNEX_SUPER_DESIGN"); dt_EOU.Columns.Add("ANNEX_COMMISSION_RATE"); dt_EOU.Columns.Add("ANNEX_DIVISION"); dt_EOU.Columns.Add("ANNEX_RANGE");
                        dt_EOU.Columns.Add("ANNEX_VERIFIED_EXAM_OFFICER"); dt_EOU.Columns.Add("ANNEX_SAMPLE_DRAWN"); dt_EOU.Columns.Add("ANNEX_SEAL_NO"); dt_EOU.Columns.Add("ANNEX_ADDRESS1");
                        dt_EOU.Columns.Add("ANNEX_ADDRESS2"); dt_EOU.Columns.Add("ANNEX_ADDRESS3"); dt_EOU.Columns.Add("ANNEX_ADDRESS4"); dt_EOU.Columns.Add("USER_ID");
                        dt_EOU.Columns.Add("DATE_TIME"); dt_EOU.Columns.Add("STATUS"); dt_EOU.Columns.Add("BRANCH_CODE"); dt_EOU.Columns.Add("YEAR"); dt_EOU.Columns.Add("WORKING_PERIOD");
                        dt_EOU.Columns.Add("MODIFIEDBY"); dt_EOU.Columns.Add("MODIFIEDON");

                        ln = pos + 1;
                     
                        string txtExaminationDate;
                        for (ln = ln; ln < lines.Length-1; ln++)
                        {
                            if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-SB>"))))
                            {
                                
                                lnItm = lines[ln].ToString().Split('^');
                                if (lnItm.Length >= 21)
                                {
                                     dt_EOU.Rows.Add(EX_ANN_C1_ID, Convert.ToInt64(txtJobNo.ToString()), "",
                                     lnItm[6].ToString(), lnItm[7].ToString(),
                                     lnItm[8].ToString().Substring(6, 2) + "/" + lnItm[8].ToString().Substring(4, 2) + "/" + lnItm[8].ToString().Substring(0, 4),
                                     lnItm[9].ToString(), lnItm[10].ToString(), lnItm[11].ToString(),
                                     lnItm[12].ToString(), lnItm[13].ToString(), lnItm[14].ToString(), lnItm[15].ToString(), lnItm[17].ToString(), lnItm[18].ToString(), lnItm[16].ToString(), "", "", "", "",
                                     Session["currentuser"].ToString(), cur_date, "N", Session["currentbranch"].ToString(), "", Session["WorkingPeriod"].ToString(), "", "01/01/1900");

                                    EX_ANN_C1_ID = EX_ANN_C1_ID + 1;
                                }
                            }

                            else
                            {
                                break;
                            }

                            if (dt_EOU.Rows.Count > 0)
                            {
                                admin.SqlBulk_Upload_Product("ANNEXURE_C1_DETAILS", dt_EOU, comp_ConnectionStr);
                            }
                            pos = ln + 1;
                       
                        

                    }
                    break;
                        #endregion packing_list
                }
            }

            //****************************** end of Eou ************************/////

            //****************************** starts Container Details ************************/////

                for (int ln = pos; ln < lines.Length; ln++)
                {

                    string[] lnItm;
                    pos = Array.IndexOf(lines, "<TABLE>CONTAINER");

                    if (result == 1 && pos > 0)
                    {

                            #region dt_Container
                            dt_Container.Columns.Add("ANNEX_SEA_CON_ID"); dt_Container.Columns.Add("ANNEX_SEA_CON_JOBNO"); dt_Container.Columns.Add("ANNEX_SEA_CON_CONTAINERNO"); dt_Container.Columns.Add("ANNEX_SEA_CON_SIZE");
                            dt_Container.Columns.Add("ANNEX_SEA_CON_TYPE"); dt_Container.Columns.Add("ANNEX_SEA_CON_EXCISE_SEALNO"); dt_Container.Columns.Add("ANNEX_SEA_CON_SEAL_DATE");
                            dt_Container.Columns.Add("USER_ID"); dt_Container.Columns.Add("DATE_TIME"); dt_Container.Columns.Add("STATUS"); dt_Container.Columns.Add("BRANCH_CODE");
                            dt_Container.Columns.Add("YEAR"); dt_Container.Columns.Add("WORKING_PERIOD"); dt_Container.Columns.Add("MODIFIEDBY"); dt_Container.Columns.Add("MODIFIEDON");
                            dt_Container.Columns.Add("ANNEX_SEA_CON_SEALTYPE_INDICATOR"); dt_Container.Columns.Add("ANNEX_SEA_CON_SEAL_DEVICEID");
                            dt_Container.Columns.Add("ANNEX_SEA_CON_DOC_TYPE"); dt_Container.Columns.Add("ANNEX_SEA_CON_DOC_NUMBER");

                            ln = pos + 1;
                            
                            for (ln = ln; ln < lines.Length-1; ln++)
                            {
                                if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-SB>"))))
                                {
                                   
                                    lnItm = lines[ln].ToString().Split('^');
                                    if (lnItm.Length >= 10)
                                    {
                                     dt_Container.Rows.Add(EX_ANN_SEA_CON_ID, Convert.ToInt64(txtJobNo.ToString()), lnItm[4].ToString(), lnItm[5].ToString(), "FR", lnItm[6].ToString(),
                                     lnItm[7].ToString().Substring(6, 2) + "/" + lnItm[7].ToString().Substring(4, 2) + "/" + lnItm[7].ToString().Substring(0, 4),
                                     Session["currentuser"].ToString(),cur_date, "N", Session["currentbranch"].ToString(), "", Session["WorkingPeriod"].ToString(), "", "01/01/1900",
                                     lnItm[8].ToString(), lnItm[9].ToString(), lnItm[10].ToString(), lnItm[11].ToString());

                                        EX_ANN_SEA_CON_ID = EX_ANN_SEA_CON_ID + 1;
                                    }
                                }
                                else
                                {

                                    break;
                                }
                            }

                            if (dt_Container.Rows.Count > 0)
                            {
                                admin.SqlBulk_Upload_Product("EXPORT_ANNEXURE_C_SEA_CONTAINER", dt_Container, comp_ConnectionStr);
                            }
                            pos = ln + 1;

                            #endregion dt_Container

                        
                        break;

                    }

                }

            //****************************** end of Container Details ************************/////

            //****************************** starts Single Window Details ************************/////

                for (int ln = 0; ln < lines.Length; ln++)
                {

                    string[] lnItm;
                    pos = Array.IndexOf(lines, "<TABLE>SW_INFO_TYPE");

                    if (result == 1 && pos > 0)
                    {

 
                            #region dt_SW_INFO
                            dt_SW_INFO.Columns.Add("SW_INFO_TYPE_ID"); dt_SW_INFO.Columns.Add("JOBNO"); dt_SW_INFO.Columns.Add("INVOICE_SLNO"); dt_SW_INFO.Columns.Add("ITEM_SLNO");
                            dt_SW_INFO.Columns.Add("SLNO"); dt_SW_INFO.Columns.Add("INFO_TYPE"); dt_SW_INFO.Columns.Add("INFO_QUALIFIER"); dt_SW_INFO.Columns.Add("INFO_CODE");
                            dt_SW_INFO.Columns.Add("INFO_TEXT"); dt_SW_INFO.Columns.Add("INFO_MSR"); dt_SW_INFO.Columns.Add("INFO_UQC"); dt_SW_INFO.Columns.Add("USER_ID");
                            dt_SW_INFO.Columns.Add("DATE_TIME"); dt_SW_INFO.Columns.Add("STATUS"); dt_SW_INFO.Columns.Add("BRANCH_CODE"); dt_SW_INFO.Columns.Add("YEAR"); dt_SW_INFO.Columns.Add("WORKING_PERIOD");
                            dt_SW_INFO.Columns.Add("MODIFIEDBY"); dt_SW_INFO.Columns.Add("MODIFIEDON"); dt_SW_INFO.Columns.Add("DEPARTMENT"); dt_SW_INFO.Columns.Add("I_U_TYPE");

                            ln = pos + 1;
                            
                            for (ln = ln; ln < lines.Length-1; ln++)
                            {
                                if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-SB>"))))
                                {
                                    //  sw.WriteLine("F" 0+ ch + CUSTOMS_HOUSE 1+ ch + ddlJobNo.SelectedValue.ToString() 2+ ch + JOBDATE 3+ ch + SB_NO 4+ ch + SB_DATE 5+ ch + INVOICE_SLNO 6+ ch + ITEM_SLNO 7+ ch + INFO_SERIAL_NO 8+ ch + 
                                    //INFO_TYPE 9+ ch + INFO_QUALIFIER 10+ ch + INFO_CODE 11+ ch + INFO_TEXT 12+ ch + INFO_MSR 13+ ch + INFO_UQC 14);
                                    // sws_SLNO++ 15;
                                    lnItm = lines[ln].ToString().Split('^');
                                    if (lnItm.Length >= 8)
                                    {

                                        dt_SW_INFO.Rows.Add(EX_SW_INFO_ID, Convert.ToInt64(txtJobNo.ToString()), Convert.ToInt64(lnItm[6].ToString()), Convert.ToInt64(lnItm[7].ToString()),
                                        lnItm[8].ToString(), lnItm[9].ToString(), lnItm[10].ToString(),
                                        lnItm[11].ToString(), lnItm[12].ToString(), lnItm[13].ToString(), lnItm[14].ToString(),
                                        Session["currentuser"].ToString(), "01/01/1900", "N", Session["currentbranch"].ToString(), "", Session["WorkingPeriod"].ToString(), "", "01/01/1900", "", "");


                                        if (lines[ln].ToString().Contains("STO"))
                                        {
                                            Sw_statecode = Sw_statecode + "~" + lnItm[11].ToString();
                                        }
                                        else if (lines[ln].ToString().Contains("DOO"))
                                        {
                                            distcode = distcode + "~" + lnItm[11].ToString();
                                        }
                                        else if (lines[ln].ToString().Contains("EPT"))
                                        {
                                            PtaFta_code = PtaFta_code + "~" + lnItm[11].ToString();
                                        }
                                        else
                                        { Ex_Sw_Info_Code = Ex_Sw_Info_Code + "~" + lnItm[11].ToString(); }
                         
                                        EX_SW_INFO_ID = EX_SW_INFO_ID + 1;
                                    }
                                }
                                else
                                {
                                    break;

                                }
                            }
                            if (dt_SW_INFO.Rows.Count > 0)
                            {
                                admin.SqlBulk_Upload_Product("EXP_SW_INFO_TYPE", dt_SW_INFO, comp_ConnectionStr);
                            }

                            pos = ln + 1;
                            #endregion dt_SW_INFO
                        
                        break;

                    }

                }

            //****************************** end of Single Window Details ************************/////

            //****************************** starts Single Window Statement  Details ************************/////

           // for (int ln = pos; ln < lines.Length; ln++)
                for (int ln = 0; ln < lines.Length; ln++)
            {

                string[] lnItm;
                pos = Array.IndexOf(lines, "<TABLE>STATEMENT");

                if (result == 1 && pos > 0)
                {
 
                        #region dt_SW_INFO
                        dt_SW_STMT.Columns.Add("SW_ID"); dt_SW_STMT.Columns.Add("JOBNO"); dt_SW_STMT.Columns.Add("INVOICE_SLNO"); dt_SW_STMT.Columns.Add("ITEM_SLNO");
                        dt_SW_STMT.Columns.Add("SLNO"); dt_SW_STMT.Columns.Add("STMT_TYPE"); dt_SW_STMT.Columns.Add("STMT_CODE"); dt_SW_STMT.Columns.Add("STMT_TEXT");
                        dt_SW_STMT.Columns.Add("BRANCH_CODE"); dt_SW_STMT.Columns.Add("WORKING_PERIOD"); dt_SW_STMT.Columns.Add("CREATEDON"); dt_SW_STMT.Columns.Add("CREATEDBY");
                        dt_SW_STMT.Columns.Add("MODIFIEDBY"); dt_SW_STMT.Columns.Add("MODIFIEDON"); dt_SW_STMT.Columns.Add("AMENDMENT_TYPE"); dt_SW_STMT.Columns.Add("AMENDMENT_STATUS");

                        ln = pos + 1;
                       
                        for (ln = ln; ln < lines.Length-1; ln++)
                        {
                            if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-SB>"))))
                            {
                                //  sw.WriteLine("F"0 + ch + CUSTOMS_HOUSE 1+ ch + ddlJobNo.SelectedValue.ToString() 2+ ch + JOBDATE 3+ ch + SB_NO 4+ ch + SB_DATE 5+ ch + INVOICE_SLNO 6+ ch +
                                //ITEM_SLNO 7+ ch + STMT_SERIAL_NO 8+ ch + STMT_TYPE 9+ ch + STMT_CODE 10+ ch + STMT_TEXT 11);

                                lnItm = lines[ln].ToString().Split('^');
                                if (lnItm.Length >= 2)
                                {
                                    dt_SW_STMT.Rows.Add(EX_SW_STMT_ID, Convert.ToInt64(txtJobNo.ToString()), Convert.ToInt64(lnItm[6].ToString()), Convert.ToInt64(lnItm[7].ToString()),
                                    lnItm[8].ToString(), lnItm[9].ToString(), lnItm[10].ToString(), lnItm[11].ToString(),
                                    Session["currentbranch"].ToString(), Session["WorkingPeriod"].ToString(), cur_date, "", "", "01/01/1900", "", "");

                                    EX_SW_STMT_ID = EX_SW_STMT_ID + 1;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (dt_SW_STMT.Rows.Count > 0)
                        {
                            admin.SqlBulk_Upload_Product("EXP_SW_STMT", dt_SW_STMT, comp_ConnectionStr);
                        }

                        pos = ln + 1;
                        #endregion dt_SW_INFO

                    
                    break;

                }

            }

            //****************************** end of Single Window Statement Details ************************/////

            //****************************** starts Supportingdocs ************************/////

           // for (int ln = pos; ln < lines.Length; ln++)
                for (int ln = 0; ln < lines.Length; ln++)
            {

                string[] lnItm;
                pos = Array.IndexOf(lines, "<TABLE>Supportingdocs");

                if (result == 1 && pos > 0 )
                {

                    #region dt_SW_Sup
                    dt_SW_Sup.Columns.Add("SW_ID"); dt_SW_Sup.Columns.Add("JOBNO"); dt_SW_Sup.Columns.Add("INVOICE_SLNO"); dt_SW_Sup.Columns.Add("ITEM_SLNO");
                    dt_SW_Sup.Columns.Add("SLNO"); dt_SW_Sup.Columns.Add("UNIQUE_DOC_NUMBER"); dt_SW_Sup.Columns.Add("DOC_TYPE_CODE"); dt_SW_Sup.Columns.Add("DOC_ISSUING_PARTY_CODE");
                    dt_SW_Sup.Columns.Add("DOC_ISSUING_PARTY_NAME_ADD1"); dt_SW_Sup.Columns.Add("DOC_ISSUING_PARTY_NAME_ADD2"); dt_SW_Sup.Columns.Add("DOC_ISSUING_PARTY_CITY"); dt_SW_Sup.Columns.Add("DOC_ISSUING_PARTY_PIN");
                    dt_SW_Sup.Columns.Add("DOC_REF_NUMBER"); dt_SW_Sup.Columns.Add("PLACE_OF_ISSUE"); dt_SW_Sup.Columns.Add("DOC_ISSUE_DATE"); dt_SW_Sup.Columns.Add("DOC_EXPIRY_DATE");
                    dt_SW_Sup.Columns.Add("BENEFICIARY_PARTY_CODE"); dt_SW_Sup.Columns.Add("BENEFICIARY_PARTY_ADDRESS1"); dt_SW_Sup.Columns.Add("BENEFICIARY_PARTY_ADDRESS2"); dt_SW_Sup.Columns.Add("BENEFICIARY_PARTY_CITY");
                    dt_SW_Sup.Columns.Add("BENEFICIARY_PARTY_PIN"); dt_SW_Sup.Columns.Add("FILE_TYPE"); dt_SW_Sup.Columns.Add("BRANCH_CODE"); dt_SW_Sup.Columns.Add("WORKING_PERIOD");
                    dt_SW_Sup.Columns.Add("CREATEDON"); dt_SW_Sup.Columns.Add("CREATEDBY"); dt_SW_Sup.Columns.Add("MODIFIEDBY"); dt_SW_Sup.Columns.Add("MODIFIEDON");
                    dt_SW_Sup.Columns.Add("DOC_ISSUING_PARTY_NAME"); dt_SW_Sup.Columns.Add("BENEFICIARY_PARTY_NAME"); dt_SW_Sup.Columns.Add("ICEGATE_ID"); dt_SW_Sup.Columns.Add("ICEGATE_DOC_FILE_NAME");
                    dt_SW_Sup.Columns.Add("AMENDMENT_TYPE"); dt_SW_Sup.Columns.Add("AMENDMENT_STATUS"); dt_SW_Sup.Columns.Add("SELECT_TYPE");

                    ln = pos + 1;
                   
                    for (ln = ln; ln < lines.Length-1; ln++)
                    {
                        if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-SB>"))))
                        {
                            

                            lnItm = lines[ln].ToString().Split('^');
                            if (lnItm.Length >= 10)
                            {
                                dt_SW_Sup.Rows.Add(EX_SW_SUP_ID, Convert.ToInt64(txtJobNo.ToString()), Convert.ToInt64(lnItm[6].ToString()), Convert.ToInt64(lnItm[7].ToString()),
                                lnItm[8].ToString(), lnItm[9].ToString(), lnItm[10].ToString(), lnItm[11].ToString(), lnItm[12].ToString(), lnItm[13].ToString(), lnItm[14].ToString(), lnItm[15].ToString(),
                                lnItm[16].ToString(), lnItm[17].ToString(), lnItm[18].ToString().Substring(6, 2) + "/" + lnItm[18].ToString().Substring(4, 2) + "/" + lnItm[18].ToString().Substring(0, 4),
                                "01/01/1900", lnItm[20].ToString(), lnItm[21].ToString(), lnItm[22].ToString(), lnItm[23].ToString(),
                                lnItm[24].ToString(), lnItm[25].ToString(), Session["currentbranch"].ToString(), Session["WorkingPeriod"].ToString(), cur_date, "", "", "01/01/1900",
                                lnItm[26].ToString(), lnItm[27].ToString(), lnItm[28].ToString(), "", "", "", "");
                                EX_SW_SUP_ID = EX_SW_SUP_ID + 1;

                               // INVOICE_SLNO = lnItm[6].ToString(); ITEM_SLNO = lnItm[7].ToString(); SLNO = lnItm[8].ToString();
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                        if (dt_SW_Sup.Rows.Count > 0)
                        {
                            admin.SqlBulk_Upload_Product("EXP_SW_SUP_DOC", dt_SW_Sup, comp_ConnectionStr);
                        }

                    pos = ln + 1;
                    #endregion dt_SW_Sup

                   
                    break;

                }

            }

            //****************************** end of Supportingdocs ************************/////

            //****************************** starts ReExport Details ************************/////

                // for (int ln = pos; ln < lines.Length; ln++)
                for (int ln = 0; ln < lines.Length; ln++)
            {

                string[] lnItm;
                pos = Array.IndexOf(lines, "<TABLE>REEXPORT");

                if (result == 1 && pos > 0)
                {
                  
                        #region dt_Re_Exp
                        dt_Re_Exp.Columns.Add("RE_EXPORT_ID"); dt_Re_Exp.Columns.Add("SB_NO"); dt_Re_Exp.Columns.Add("SB_DATE"); dt_Re_Exp.Columns.Add("JOBNO");
                        dt_Re_Exp.Columns.Add("INVOICE_SLNO"); dt_Re_Exp.Columns.Add("ITEM_SLNO"); dt_Re_Exp.Columns.Add("SLNO"); dt_Re_Exp.Columns.Add("BE_SITE");
                        dt_Re_Exp.Columns.Add("BE_NO"); dt_Re_Exp.Columns.Add("BE_DATE"); dt_Re_Exp.Columns.Add("BE_INVOICE_NO"); dt_Re_Exp.Columns.Add("BE_INVOICE_ITEM_NO");
                        dt_Re_Exp.Columns.Add("MANUAL_BE_Y_N"); dt_Re_Exp.Columns.Add("BE_QTY_UTILISED"); dt_Re_Exp.Columns.Add("BE_ITEM_DESC"); dt_Re_Exp.Columns.Add("BE_QTY");
                        dt_Re_Exp.Columns.Add("BE_UQC"); dt_Re_Exp.Columns.Add("BE_ASS_VALUE"); dt_Re_Exp.Columns.Add("BE_DUTY_PAID"); dt_Re_Exp.Columns.Add("BE_DUTY_PAYMENT_DATE");
                        dt_Re_Exp.Columns.Add("BE_OTH_IDENTIFIABLE_PARAMETER"); dt_Re_Exp.Columns.Add("BE_ASS_VALUE_CLAIM"); dt_Re_Exp.Columns.Add("BE_ITEM_USED_Y_N"); dt_Re_Exp.Columns.Add("COMMISIONER_PERMISSION_Y_N");
                        dt_Re_Exp.Columns.Add("INPUT_CREDIT_Y_N"); dt_Re_Exp.Columns.Add("PERSONAL_USED_Y_N"); dt_Re_Exp.Columns.Add("MODVAT_AVAILED_Y_N"); dt_Re_Exp.Columns.Add("MODVAT_REPAID_Y_N");
                        dt_Re_Exp.Columns.Add("BRANCH_CODE"); dt_Re_Exp.Columns.Add("WORKING_PERIOD"); dt_Re_Exp.Columns.Add("CREATEDON"); dt_Re_Exp.Columns.Add("CREATEDBY");
                        dt_Re_Exp.Columns.Add("MODIFIEDBY"); dt_Re_Exp.Columns.Add("MODIFIEDON");

                        ln = pos + 1;
                        
                        for (ln = ln; ln < lines.Length-1; ln++)
                        {
                            if ((!(lines[ln].ToString().Contains("<TABLE>"))) && (!(lines[ln].ToString().Contains("<END-SB>"))))
                            {
                                
                                lnItm = lines[ln].ToString().Split('^');
                                if (lnItm.Length >= 10)
                                {
                                    dt_Re_Exp.Rows.Add(RE_EX_ID, "", "01/01/1900", Convert.ToInt64(txtJobNo.ToString()), Convert.ToInt64(lnItm[6].ToString()), Convert.ToInt64(lnItm[7].ToString()),
                                    lnItm[8].ToString(), lnItm[9].ToString(), lnItm[10].ToString(), lnItm[11].ToString().Substring(6, 2) + "/" + lnItm[11].ToString().Substring(4, 2) + "/" + lnItm[11].ToString().Substring(0, 4),
                                    lnItm[12].ToString(), lnItm[13].ToString(), lnItm[14].ToString(), lnItm[15].ToString(),
                                    lnItm[16].ToString(), lnItm[17].ToString(), lnItm[18].ToString(), lnItm[19].ToString(), lnItm[20].ToString(),
                                    lnItm[21].ToString().Substring(6, 2) + "/" + lnItm[21].ToString().Substring(4, 2) + "/" + lnItm[21].ToString().Substring(0, 4), 
                                    lnItm[22].ToString(), lnItm[23].ToString(),
                                    lnItm[24].ToString(), lnItm[25].ToString(), lnItm[26].ToString(), lnItm[27].ToString(), lnItm[28].ToString(), lnItm[29].ToString(),
                                    Session["currentbranch"].ToString(), Session["WorkingPeriod"].ToString(), cur_date, "", "", "01/01/1900");

                                    RE_EX_ID = RE_EX_ID + 1;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (dt_Re_Exp.Rows.Count > 0)
                        {
                            admin.SqlBulk_Upload_Product("RE_EXPORT_DETAILS", dt_Re_Exp, comp_ConnectionStr);
                        }

                        pos = ln + 1;
                        #endregion dt_Re_Exp
                    
                    break;

                }

            }


                if (dt_Inv.Rows.Count > 0 && dt_Item.Rows.Count > 0)
                {
                    DataSet Dsinv_item = new DataSet();
                    DataSet schem_draw = new DataSet();
                    Gen.BRANCH_CODE = Connection.Get_Company_Type();
                    Gen.JOBNO = txtJobNo;
                    Gen.INVOICE_SLNO = INVOICE_SLNO;
                    Gen.ITEM_SLNO = ITEM_SLNO;
                    Gen.COUNTRY_CODE = Country_Discharge;
                    Gen.PORT_CODE = Port_Discharge;
                    Gen.STATE_CODE = State_Of_Export;
                    Gen.DRAWBACK_SLNO = drawbk_sno;
                    Gen.SCHEME_EXPORT_CODE = item_schem_code;
                    Gen.AGREEMENT_CODE = PtaFta_code;
                    Gen.SW_STATE_CODE = Sw_statecode;
                    Gen.DISTRICT_CODE = distcode;
                    Gen.EXCHANGE_CUR_CODE = Inv_Cur;
                    Gen.CESS_SLNO = cess_slno;
                    Gen.flag = "DRAWBACK";
                    schem_draw = Gen.Retrieve_Schem_Drawback_details();

                    Gen.XML_DRAW = schem_draw.GetXml();
                    Gen.XML_DRAW = Gen.XML_DRAW.Replace("&", "").Replace("#", "").Replace("’", "").Replace("‘", "").Replace("”", "").Replace("“", "").Replace(";", "").Replace("„", "").Replace("„", "").Replace("?", "");
                    Gen.flag = "SCHEME";
                    schem_draw = Gen.Retrieve_Schem_Drawback_details();                  
                    Gen.XMLSCHEM = schem_draw.GetXml();

                    Gen.flag = "CNT_PORT_ST";
                    schem_draw = Gen.Retrieve_Schem_Drawback_details();
                    Gen.XML_IMPEXMASTER = schem_draw.GetXml();

                    Gen.flag = "CESS";
                    schem_draw = Gen.Retrieve_Schem_Drawback_details();
                    Gen.XML_Cess = schem_draw.GetXml();
                    //Gen.flag = "PTA_FTA";
                    //schem_draw = Gen.Retrieve_Schem_Drawback_details();
                    //Gen.XML_IMPEXMASTER = schem_draw.GetXml();

                    
                    Dsinv_item = Gen.Retrieve_inv_item_value();

                    
                }
           
        }

    }
    //****************************** end of ReExport Details ************************/////

    // *******************end of  reading from singed Sb copy ***************************//


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
                //fileuploadExcel1.SaveAs(strImagePath);
            }
            else
            {
                fileuploadXML.SaveAs(strImagePath);
            }

        }
        catch
        {
        }
        finally
        {
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

}