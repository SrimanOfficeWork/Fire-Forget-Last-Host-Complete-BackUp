using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Linq;

public partial class Export_XML_Jobwise_VELJI_Reliance : ThemeClass
{
    AppSession aps = new AppSession();
    UserBO objUBO = new UserBO();
    Export_General_New Gen = new Export_General_New();
    Jobwise_xl_Upload xl = new Jobwise_xl_Upload();
    Annexure_C_Air ANNEX_C_Air = new Annexure_C_Air();
    Annexure_C_Sea ANNEX_C_Sea = new Annexure_C_Sea();

    DataTable dt_Inv = new DataTable();
    DataTable dt_Item = new DataTable();
    DataTable dt_Lic = new DataTable();
    DataTable dt_Imp_Exp_lic = new DataTable();
    DataTable dt_Dbk = new DataTable();
    DataTable dt_AR4 = new DataTable();
    DataTable dt_blk_Lic = new DataTable();
    DataTable dt_blk_Imp_Exp_lic = new DataTable();
    //DataTable dt_SW_INFO = new DataTable();
    //DataTable dt_SW_CTRL = new DataTable();
    //DataTable dt_SW_STMT = new DataTable();
    DataSet ds_IEC = new DataSet();
    AdminMasterDetails admin = new AdminMasterDetails();
    Auto_Search Auto = new Auto_Search();
    ErrorLogs er = new ErrorLogs();
    AdminManipulation adm=new AdminManipulation();

    DataSet ds_draw = new DataSet();
    DataSet ds_license = new DataSet();
    DataTable Inv_data1 = new DataTable();
    
    public string SELECT_BRANCH, IMP_Jobno, IMP_INV_Slno;
    public string errorFolder = "", logline = "", logFileName = "";
    string EXPORT_JOBNO = "", Current_JOBID="";
    DateTime dateTime = DateTime.UtcNow.Date;
    public int MAX_ID = 0;
    public decimal item_amt;
    public string scheme, Transport_Mode = "", CustomHouse_Name = "", Statename = "", PAYMENT_METHOD = "", TERMS = "", PERIOD_OF_PAYMENTS = "", CONTRACT_NO = "", SCHEME_CODE="";
    public string BUYER_NAME = "", BUYER_ADDRESS1 = "", BUYER_ADDRESS2 = "", BUYER_ADDRESS3 = "", REWARD_FLAG = "", ENDUSE_ITEM = "", SEAL_TYPE_INDICATOR="";
    string[] scheme_name = new string[2];

    public string  comp_ConnectionStr = "";
    public int LICENSE_ID, LICENSE_IMP_EXP_ID;
    public int License_id_Max = 0;
    public int License_id_IMP_EXP_Max = 0;

    public string[] lic_no;
    public int licno_Count;
    public int ITEM_ID = 0, CONTAINER_MAX_ID = 0, AR4_ID = 0, DRAWBACK_ID = 0, INVOICE_ID = 0, PACK_ID = 0, SUP_DOC = 0, ANNEX_ID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/" + "Export_Excel");
       
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'XML Move', function (r) {});}});</script>";
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
                Get_XML_File();
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                dir.Create();
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                Get_XML_File();
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

    public void Get_XML_File()
    {
        DataSet ds = new DataSet();

        string connString = "";
        string strFileType = Path.GetExtension(fileuploadXML.FileName).ToLower();
        string path = errorFolder + "\\" + fileuploadXML.FileName;
        string picExtension;
        string fileName2;
        int i = 0;

        if (fileuploadXML.HasFile)
        {
            //picExtension = fnGetPictureExtn(fileuploadXML.FileName);
            fileName2 = fileuploadXML.FileName;
            addtoGallery1(fileName2, errorFolder, "NORMAL");

            string xmlFile = path;

            DataSet dataSet = new DataSet();
            dataSet.ReadXml(xmlFile, XmlReadMode.InferSchema);

            DataTable dt_gen = new DataTable();

            EXPORT_JOBNO = AUTO_JOBNO();


            if (dataSet.Tables.Contains("GENERAL"))
            {
                i = Bind_General_Details(dataSet.Tables["GENERAL"], EXPORT_JOBNO);

                if (i == 1)
                {
                    if (dataSet.Tables.Contains("ZPTC_SHIPPING_BILL_INVOICE"))
                    {
                        Bind_Invoice_Details(dataSet.Tables["ZPTC_SHIPPING_BILL_INVOICE"], EXPORT_JOBNO);
                    }
                    if (dataSet.Tables.Contains("ZPTC_SHIPPING_BILL_INV_ITEM"))
                    {
                        Bind_Item_Details(dataSet.Tables["ZPTC_SHIPPING_BILL_INV_ITEM"], EXPORT_JOBNO);
                    }
                    if (dataSet.Tables.Contains("AR4Details"))
                    {
                        Bind_AR4_Details(dataSet.Tables["AR4Details"], EXPORT_JOBNO);
                    }
                    if (dataSet.Tables.Contains("ZPTC_SHIPPING_BILL_LIC"))
                    {
                        Bind_Bulk_LICENSE_DETAILS(dataSet.Tables["ZPTC_SHIPPING_BILL_LIC"], EXPORT_JOBNO);
                    }
                    if (dataSet.Tables.Contains("ZPTC_SHIPPING_BILL_DBK"))
                    {
                        Bind_Drawback_Details(dataSet.Tables["ZPTC_SHIPPING_BILL_DBK"], EXPORT_JOBNO);
                    }
                    //if (dataSet.Tables.Contains("Sea_Container"))
                    //{
                    //    Bind_Sea_Container_Details(dataSet.Tables["Sea_Container"], EXPORT_JOBNO);
                    //}
                    if (dataSet.Tables.Contains("PACKAGE"))
                    {
                        Bind_PACKAGE_Details(dataSet.Tables["PACKAGE"], EXPORT_JOBNO);
                    }
                    if (dataSet.Tables.Contains("SupportingDocs"))
                    {
                        Bind_SUPPORTING_DOCS_Details(dataSet.Tables["SupportingDocs"], EXPORT_JOBNO);
                    }
                    if (dataSet.Tables.Contains("EOUDetails"))
                    {
                        Bind_ANNEXURE_C1_Details(dataSet.Tables["EOUDetails"], EXPORT_JOBNO);
                    }
                    
                    
                    Session["JOBIDexcel"] = Get_JOBID(EXPORT_JOBNO);
                    Alert_msg("Records Uploaded Successfully");
                }
                else // if (i == 3)
                {
                    Alert_msg("File Ref. No Already Exist! Not Saved");
                }
            }
           
        }

    }

    public int Bind_General_Details(DataTable dataSet, string EXPORT_JOBNO)
    {
        
        Transport_Mode=AdminManipulation.Get_Transport_Mode(dataSet.Rows[0]["CUSTOM_HOUSE"].ToString());
        Statename=AdminManipulation.Get_Statename(dataSet.Rows[0]["STATE_OF_EXPORT"].ToString());
        int i = 0;
        Gen.JOBNO = EXPORT_JOBNO;
        Gen.JOBDATE = dateTime.ToString("dd/MM/yyyy");

        //Gen.TRANSPORT_MODE = dataSet.Rows[0]["ModeOfTransport"].ToString();
        Gen.TRANSPORT_MODE = Transport_Mode;
        hdn_TransportMode.Value = Transport_Mode;
        
        Gen.SB_TYPE = "Free Duty";
        Gen.CUSTOMS_HOUSE = dataSet.Rows[0]["CUSTOM_HOUSE"].ToString();
        Gen.CUSTOMS_HOUSE_NAME = CustomHouse_Name;
        Gen.EXPORTER_NAME = dataSet.Rows[0]["IEC_NAME"].ToString();
        Gen.BRANCH_NO = dataSet.Rows[0]["BRANCH_SL_NO"].ToString();
        Gen.IEC_NO = dataSet.Rows[0]["EXPORTER_IE_CODE"].ToString();
        Gen.ADDRESS1 = dataSet.Rows[0]["EXPORTER_ADDRESS1"].ToString();
        Gen.ADDRESS2 = dataSet.Rows[0]["EXPORTER_ADDRESS2"].ToString();
        Gen.ADDRESS3 = dataSet.Rows[0]["EXPORTER_ADDRESS3"].ToString();
        Gen.ADDRESS4 = Statename;
        Gen.ADDRESS5 = dataSet.Rows[0]["EXPORTER_PINCODE"].ToString();
        Gen.ADCODE = dataSet.Rows[0]["AD_CODE"].ToString();
        Gen.BANK_ACCOUNT = dataSet.Rows[0]["NEGOTIATING_BANK"].ToString();
        Gen.DRAWBACK_ACCOUNT = "";
        Gen.CONSIGNEE_NAME = dataSet.Rows[0]["CONSIGNEE_NAME"].ToString();
        Gen.CONSIGNEE_ADD1 = dataSet.Rows[0]["CONSIGNEE_NAME1"].ToString();
        Gen.CONSIGNEE_ADD2 = dataSet.Rows[0]["CONSIGNEE_NAME2"].ToString();
        Gen.CONSIGNEE_ADD3 = dataSet.Rows[0]["CONSIGNEE_NAME3"].ToString();
        Gen.CONSIGNEE_ADD4 = "";
        Gen.CONSIGNEE_ADD5 = AdminManipulation.Get_Countryname(dataSet.Rows[0]["CONSIGNEE_COUNTRY"].ToString());
        Gen.COUNTRY_DISCHARGE = AdminManipulation.Get_Countryname(dataSet.Rows[0]["COUNTRY_DISCHARGE"].ToString());
        Gen.PORT_DISCHARGE = AdminManipulation.Get_Portname(dataSet.Rows[0]["PORT_DISCHARGE"].ToString());
        Gen.COUNTRY_FINAL_DEST = AdminManipulation.Get_Countryname(dataSet.Rows[0]["COUNTRY_FINAL_DESTINATION"].ToString());
        Gen.PORT_FINAL_DEST = AdminManipulation.Get_Portname(dataSet.Rows[0]["PORT_FINAL_DESTINATION"].ToString());
        Gen.STATE_OF_EXPORT = Statename;

        if (dataSet.Rows[0]["NFEI_Y_N"].ToString() != "N")
        {
            Gen.NFEI = "Yes";

            if (dataSet.Rows[0]["TYPE"].ToString().Contains("1"))
            {
                Gen.NFEI_TYPE = "01-Free Trade Sample";
            }
            else if (dataSet.Rows[0]["TYPE"].ToString().Contains("2"))
            {
                Gen.NFEI_TYPE = "02-Diplomatic Goods";
            }
            else if (dataSet.Rows[0]["TYPE"].ToString().Contains("3"))
            {
                Gen.NFEI_TYPE = "03-Warranty Replacement";
            }
            else if (dataSet.Rows[0]["TYPE"].ToString().Contains("4"))
            {
                Gen.NFEI_TYPE = "04-Currency Chest";
            }
            else if (dataSet.Rows[0]["TYPE"].ToString().Contains("5"))
            {
                Gen.NFEI_TYPE = "05-Tourist Goods";
            }
            else if (dataSet.Rows[0]["TYPE"].ToString().Contains("6"))
            {
                Gen.NFEI_TYPE = "06-Defence Goods";
            }
            else if (dataSet.Rows[0]["TYPE"].ToString().Contains("7"))
            {
                Gen.NFEI_TYPE = "07-Gift Parcel";
            }
            else
            {
                Gen.NFEI_TYPE = "08-Others";
            }

            //Gen.NFEI_TYPE = dataSet.Rows[0]["NFEI_TYPE"].ToString();
            Gen.RBI_WAIVER_NO = dataSet.Rows[0]["RBI_WAIVER_NO"].ToString();

            if (dataSet.Rows[0]["RBI_WAIVER_DATE"].ToString() != "")
            {
                Gen.RBI_WAIVER_DATE = dataSet.Rows[0]["RBI_WAIVER_DATE"].ToString();
            }
            else
            {
                Gen.RBI_WAIVER_DATE = "01/01/1900";
            }
        }
        else
        {
            Gen.NFEI = "No";
            Gen.NFEI_TYPE = "";
            Gen.RBI_WAIVER_NO = "";
            Gen.RBI_WAIVER_DATE = "01/01/1900";
        }
        
        //if (dataSet.Rows[0]["MARK__--26_NOS"].ToString() != "")
        if (dataSet.Rows[0]["MARK_NOS"].ToString() != "")
        {
            Gen.MARKS_NO = dataSet.Rows[0]["MARK_NOS"].ToString();
        }
        else
        {
            Gen.MARKS_NO = "I/WE DECLARE THAT THE PARTICULARS GIVEN HEREIN ARE TRUE AND ARE CORRECT,I/WE UNDERTAKE TO ABIDE BY PROVISIONS OF FOREIGN EXCHANGE MANAGEMENT ACT 1999,AS AMENDED FROM TIME TO TIME INCLUDING REALISATION/RESPATRIATION OF FOREIGNEXCHANGE TO FROM INDIA.";
        }
        //Gen.MARKS_NO = txtMarksNos.Text;
        Gen.USER_ID = Connection.Current_User();
        Gen.flag = "S";
        Gen.BRANCH_CODE = Connection.Current_Branch();
        Gen.WORKING_PERIOD = Connection.WorkingPeriod();
        //Gen.FILE_REF_NO = dataSet.Rows[0]["FILE_REF_NO"].ToString();
        Gen.FILE_REF_NO = dataSet.Rows[0]["STO_NO"].ToString();
        Gen.BRANCH_COMMON = Connection.Get_Company_Type(); ;
        Gen.TYPE_OF_EXPORTER = dataSet.Rows[0]["TYPE_OF_EXPORTER"].ToString();
        Gen.JOBNO_PS = EXPORT_JOBNO;

        Gen.JOB_PREFIX = "";
        Gen.JOB_SUFFIX = "";

        Gen.CONSIGNEE_BRANCHSLNO = "";
        Gen.GSTN_TYPE = "GSN"; //dataSet.Rows[0]["GSTN_TYPE"].ToString();
        //Gen.GSTN_TYPE = "";
        Gen.GSTN_ID = dataSet.Rows[0]["GSTN_REGISTRATION_NO"].ToString();

        Gen.PARTY_REF_NO = "";
        Gen.CARTING_POINT = "";


        PAYMENT_METHOD = dataSet.Rows[0]["PAYMENT_METHOD"].ToString().Trim();
        TERMS = dataSet.Rows[0]["TERMS"].ToString().Trim().Replace("&","");
        PERIOD_OF_PAYMENTS = dataSet.Rows[0]["PERIOD_OF_PAYMENTS"].ToString().Trim();
        CONTRACT_NO = dataSet.Rows[0]["CONTRACT_NO"].ToString().Trim();
        SCHEME_CODE = dataSet.Rows[0]["SCHEME_CODE"].ToString().Trim();

        BUYER_NAME = dataSet.Rows[0]["BUYER_NAME"].ToString();
        BUYER_ADDRESS1 = dataSet.Rows[0]["BUYER_ADDRESS1"].ToString();
        BUYER_ADDRESS2 = dataSet.Rows[0]["BUYER_ADDRESS2"].ToString();
        BUYER_ADDRESS3 = dataSet.Rows[0]["BUYER_ADDRESS3"].ToString();
        REWARD_FLAG = dataSet.Rows[0]["REWARD_FLAG"].ToString();
        ENDUSE_ITEM = dataSet.Rows[0]["ENDUSE_ITEM"].ToString();
        SEAL_TYPE_INDICATOR = dataSet.Rows[0]["SEAL_TYPE_INDICATOR"].ToString();

        i = Gen.General_details_insertupdate();

        if (dataSet.Rows[0]["NATURE_OF_CARGO"].ToString() != "")
        {
            if (hdn_TransportMode.Value == "Air")
            {
                ANNEX_C_Air.ANNEX_AIR_JOBNO = EXPORT_JOBNO;
                ANNEX_C_Air.ANNEX_AIR_SEALNO = dataSet.Rows[0]["SEAL_NO"].ToString().Trim();
                ANNEX_C_Air.ANNEX_AIR_SEAL_AGENCY = dataSet.Rows[0]["SEAL_TYPE"].ToString().Trim();

                //if (ddlNatureOfCargo.SelectedValue == "P Packaged")
                //{
                //    Nature_Cargo = "P";
                //}

                ANNEX_C_Air.ANNEX_AIR_NATURE_OF_CARGO = dataSet.Rows[0]["NATURE_OF_CARGO"].ToString().Trim();
                //ANNEX_C_Air.ANNEX_AIR_MARKS_NOS = dataSet.Rows[0]["CP1_MARK__--26_NOS1"].ToString();
                ANNEX_C_Air.ANNEX_AIR_MARKS_NOS = dataSet.Rows[0]["CP1_MARK_NOS"].ToString().Trim();
                ANNEX_C_Air.ANNEX_AIR_TOTAL_PACKAGES = dataSet.Rows[0]["TOTAL_NO_PACKAGES"].ToString().Trim();
                ANNEX_C_Air.ANNEX_AIR_UNIT_CODE = dataSet.Rows[0]["PACKAGES_UQC"].ToString().Trim();
                ANNEX_C_Air.ANNEX_AIR_FREIGHT_AMT = "";
                ANNEX_C_Air.ANNEX_AIR_INSURANCE_AMT = "";
                ANNEX_C_Air.ANNEX_AIR_GROSS_WEIGHT = dataSet.Rows[0]["GROSS_WEIGHT"].ToString().Trim();
                ANNEX_C_Air.ANNEX_AIR_GR_UNIT_CODE = dataSet.Rows[0]["WEIGHTSUQC"].ToString().Trim();
                ANNEX_C_Air.ANNEX_AIR_NET_WEIGHT = dataSet.Rows[0]["NET_WEIGHT"].ToString().Trim();
                ANNEX_C_Air.ANNEX_AIR_MAWB_NO = "";
                ANNEX_C_Air.ANNEX_AIR_HAWB_NO = "";
                ANNEX_C_Air.ANNEX_AIR_TOTAL_PACKAGES_MAWB = "";
                ANNEX_C_Air.ANNEX_AIR_ROTATION_NO = "";
                ANNEX_C_Air.ANNEX_AIR_ROTATION_DATE = "01/01/1900";
               
                ANNEX_C_Air.ANNEX_AIR_FOB_VALUE = "";


                ANNEX_C_Air.USER_ID = Connection.Current_User();
                ANNEX_C_Air.flag = "S";
                ANNEX_C_Air.BRANCH_CODE = Connection.Current_Branch();
                ANNEX_C_Air.WORKING_PERIOD = Connection.WorkingPeriod();
                ANNEX_C_Air.BRANCH_COMMON = SELECT_BRANCH;

                i = ANNEX_C_Air.Annexure_C_Air_details_insertupdate();
            }
            else 
            {
                ANNEX_C_Sea.ANNEX_SEA_JOBNO = EXPORT_JOBNO;
                ANNEX_C_Sea.ANNEX_SEA_FAC_STUFFED = dataSet.Rows[0]["FACTORY_STUFFED"].ToString().Trim();
                ANNEX_C_Sea.ANNEX_SEA_SAMPLE_ACCOM = dataSet.Rows[0]["SAMPLE_ACCOMPANIED"].ToString().Trim();
                ANNEX_C_Sea.ANNEX_SEA_NATURE_OF_CARGO = dataSet.Rows[0]["NATURE_OF_CARGO"].ToString().Trim();
                ANNEX_C_Sea.ANNEX_SEA_MARKS_NOS = dataSet.Rows[0]["CP1_MARK_NOS"].ToString().Trim();
                ANNEX_C_Sea.ANNEX_SEA_TOTAL_PACKAGES = dataSet.Rows[0]["TOTAL_NO_PACKAGES"].ToString().Trim();
                ANNEX_C_Sea.ANNEX_SEA_LOOSE_PACKETS = dataSet.Rows[0]["NO_OF_LOOSE_PACKETS"].ToString().Trim();
                ANNEX_C_Sea.ANNEX_SEA_NO_CONTAINERS = dataSet.Rows[0]["NO_OF_CONTAINERS"].ToString().Trim();
                ANNEX_C_Sea.ANNEX_SEA_GROSS_WEIGHT = dataSet.Rows[0]["GROSS_WEIGHT"].ToString().Trim();
                ANNEX_C_Sea.ANNEX_SEA_NET_WEIGHT = dataSet.Rows[0]["NET_WEIGHT"].ToString().Trim();
                ANNEX_C_Sea.ANNEX_SEA_UNIT_MEASUREMENT = dataSet.Rows[0]["WEIGHTSUQC"].ToString().Trim();
                ANNEX_C_Sea.ANNEX_SEA_ROTATION_NO = "";
                ANNEX_C_Sea.ANNEX_SEA_ROTATION_DATE = "01/01/1900";
                
                ANNEX_C_Sea.ANNEX_SEA_FOB_VALUE = "";

                ANNEX_C_Sea.USER_ID = Connection.Current_User();
                ANNEX_C_Sea.flag = "S";
                ANNEX_C_Sea.BRANCH_CODE = Connection.Current_Branch();
                ANNEX_C_Sea.WORKING_PERIOD = Connection.WorkingPeriod();
                ANNEX_C_Sea.BRANCH_COMMON = SELECT_BRANCH;
                ANNEX_C_Sea.ANNEX_SEA_SEAL_TYPE = dataSet.Rows[0]["SEAL_TYPE"].ToString().Trim();
                i = ANNEX_C_Sea.Annexure_C_Sea_details_insertupdate();
                return i;
            }           
        }

       
        return i;
    }

    public void Bind_Invoice_Details(DataTable Inv_data, string EXPORT_JOBNO)
    {
        #region dt_Inv
        dt_Inv.Columns.Add("INVOICE_ID");
        dt_Inv.Columns.Add("JOBNO");
        dt_Inv.Columns.Add("JOBDATE");
        dt_Inv.Columns.Add("INVOICE_SLNO");
        dt_Inv.Columns.Add("INVOICE_NO");
        dt_Inv.Columns.Add("INVOICE_DATE");
        dt_Inv.Columns.Add("PAYMENT_METHOD");
        dt_Inv.Columns.Add("PERIOD_PAYMENT");
        dt_Inv.Columns.Add("INVOICE_VALUE");
        dt_Inv.Columns.Add("INVOICE_CURRENCY");
        dt_Inv.Columns.Add("EXCHANGE_RATE");
        dt_Inv.Columns.Add("CONTRACT_NO");
        dt_Inv.Columns.Add("TERMS");
        dt_Inv.Columns.Add("BUYER");
        dt_Inv.Columns.Add("BUYER_NAME");
        dt_Inv.Columns.Add("BUYER_ADDRESS");
        dt_Inv.Columns.Add("BUYER_ADDRESS1");
        dt_Inv.Columns.Add("BUYER_ADDRESS2");
        dt_Inv.Columns.Add("BUYER_ADDRESS3");
        dt_Inv.Columns.Add("BUYER_ADDRESS4");
        dt_Inv.Columns.Add("COMMISSION_RATE");
        dt_Inv.Columns.Add("COMMISSION_CHARGES");
        dt_Inv.Columns.Add("COMMISSION_CURRENCY");
        dt_Inv.Columns.Add("FOB_RATE");
        dt_Inv.Columns.Add("FOB_CHARGES");
        dt_Inv.Columns.Add("FOB_CURRENCY");
        dt_Inv.Columns.Add("PACKMISC_RATE");
        dt_Inv.Columns.Add("PACKMISC_CHARGES");
        dt_Inv.Columns.Add("PACKMISC_CURRENCY");
        dt_Inv.Columns.Add("OTHER_DEDUCTION_RATE");
        dt_Inv.Columns.Add("OTHER_DEDUCTION_CHARGES");
        dt_Inv.Columns.Add("OTHER_DEDUCTION_CURRENCY");
        dt_Inv.Columns.Add("FREIGHT_RATE");
        dt_Inv.Columns.Add("FREIGHT_CHARGES");
        dt_Inv.Columns.Add("FREIGHT_CURRENCY");
        dt_Inv.Columns.Add("FREIGHT_EXRATE");
        dt_Inv.Columns.Add("INSURANCE_RATE");
        dt_Inv.Columns.Add("INSURANCE_CHARGES");
        dt_Inv.Columns.Add("INSURANCE_CURRENCY");
        dt_Inv.Columns.Add("INSURANCE_EXRATE");
        dt_Inv.Columns.Add("WHEATHER_UNIT_PRICE");
        dt_Inv.Columns.Add("USER_ID");
        dt_Inv.Columns.Add("DATE_TIME");
        dt_Inv.Columns.Add("STATUS");
        dt_Inv.Columns.Add("BRANCH_CODE");
        dt_Inv.Columns.Add("YEAR");
        dt_Inv.Columns.Add("WORKING_PERIOD");
        dt_Inv.Columns.Add("NON_STD_EFFECT_DT_EXP");
        dt_Inv.Columns.Add("NON_STD_BANKNAME");
        dt_Inv.Columns.Add("NON_STD_CERTIFICATE_NO");
        dt_Inv.Columns.Add("NON_STD_CERTIFICATE_DATE");
        dt_Inv.Columns.Add("MODIFIEDBY");
        dt_Inv.Columns.Add("MODIFIEDON");
        dt_Inv.Columns.Add("TERMS_PLACE");
        dt_Inv.Columns.Add("THIRDPARTY_NAME");
        dt_Inv.Columns.Add("THIRDPARTY_ADD1");
        dt_Inv.Columns.Add("THIRDPARTY_ADD2");
        dt_Inv.Columns.Add("THIRDPARTY_CITY");
        dt_Inv.Columns.Add("T_PARTY_COUNTRY_SUB_DIV");
        dt_Inv.Columns.Add("T_PARTY_COUNTRY_CODE");
        dt_Inv.Columns.Add("T_PARTY_PIN");
        dt_Inv.Columns.Add("AUTHORIZED_ECONOMIC_OPERATOR_CODE");
        dt_Inv.Columns.Add("A_E_O_COUNTRY");
        dt_Inv.Columns.Add("AUTHORIZED_ECONOMIC_OPERATOR");
        #endregion dt_Inv

        #region dt_CONTAINER
        DataTable dt_CONTAINER = new DataTable();
        dt_CONTAINER.Columns.Add("ANNEX_SEA_CON_ID");
        dt_CONTAINER.Columns.Add("ANNEX_SEA_CON_JOBNO");
        dt_CONTAINER.Columns.Add("ANNEX_SEA_CON_CONTAINERNO");
        dt_CONTAINER.Columns.Add("ANNEX_SEA_CON_SIZE");
        dt_CONTAINER.Columns.Add("ANNEX_SEA_CON_TYPE");
        dt_CONTAINER.Columns.Add("ANNEX_SEA_CON_EXCISE_SEALNO");
        dt_CONTAINER.Columns.Add("ANNEX_SEA_CON_SEAL_DATE");
        dt_CONTAINER.Columns.Add("USER_ID");
        dt_CONTAINER.Columns.Add("DATE_TIME");
        dt_CONTAINER.Columns.Add("STATUS");
        dt_CONTAINER.Columns.Add("BRANCH_CODE");
        dt_CONTAINER.Columns.Add("YEAR");
        dt_CONTAINER.Columns.Add("WORKING_PERIOD");
        dt_CONTAINER.Columns.Add("MODIFIEDBY");
        dt_CONTAINER.Columns.Add("MODIFIEDON");
        dt_CONTAINER.Columns.Add("ANNEX_SEA_CON_SEALTYPE_INDICATOR");
        dt_CONTAINER.Columns.Add("ANNEX_SEA_CON_SEAL_DEVICEID");
        dt_CONTAINER.Columns.Add("ANNEX_SEA_CON_DOC_TYPE");
        dt_CONTAINER.Columns.Add("ANNEX_SEA_CON_DOC_NUMBER");
        #endregion dt_CONTAINER

        int zz;
        int j;

        INVOICE_ID = Get_general_MAXID("INVOICE_MAX_ID");

        //******************** Remove Empty Rows from Datatable  ********************************

        //Inv_data = Inv_data.Rows.Cast<DataRow>()
        //     .Where(row => !row.ItemArray.All(field => field is System.DBNull))
        //     .CopyToDataTable();

        //*********************************************************************************************************

        for (int i = 0; i <= Inv_data.Rows.Count - 1; i++)
        {

            DataRow dr1 = dt_Inv.NewRow();
            dr1["JOBDATE"]= dateTime.ToString("dd/MM/yyyy");
            dr1["INVOICE_SLNO"] = Inv_data.Rows[i]["INV_SL_NO"].ToString().Trim();
            dr1["INVOICE_NO"] = Inv_data.Rows[i]["INVOICE_NO"].ToString().Trim();
            dr1["INVOICE_DATE"] = Inv_data.Rows[i]["DATE"].ToString().Trim();
            dr1["INVOICE_VALUE"] = Inv_data.Rows[i]["INVOICE_VALUE"].ToString().Trim();
            dr1["INVOICE_CURRENCY"] = Inv_data.Rows[i]["INV_CURRENCY"].ToString().Trim();
            //dr1["EXCHANGE_RATE"] = Inv_data.Rows[i]["EXCG_RATE"].ToString();
            dr1["EXCHANGE_RATE"] = adm.Currency_Converter(Inv_data.Rows[i]["INV_CURRENCY"].ToString().Trim());

            if (PAYMENT_METHOD == "")
            {
                dr1["PAYMENT_METHOD"] = "NA";
            }
            else
            {
                dr1["PAYMENT_METHOD"] = PAYMENT_METHOD;
            }
            dr1["PERIOD_PAYMENT"] = PERIOD_OF_PAYMENTS;
            dr1["CONTRACT_NO"] = CONTRACT_NO;

            dr1["TERMS"] = TERMS;
            //dr1["BUYER"] = Inv_data.Rows[i][8].ToString();
            dr1["BUYER_NAME"] = BUYER_NAME;
            if (dr1["BUYER_NAME"] == "")
            {
                dr1["BUYER"] = "Y";
                dr1["BUYER_NAME"] = "SAME AS CONSIGNEE";
            }
            else
            {
                dr1["BUYER"] = "N";
                dr1["BUYER_NAME"] = BUYER_NAME;
                int count = 0;
                if (BUYER_ADDRESS1.Length > 35)
                {
                    count = BUYER_ADDRESS1.Count();
                    string add1 = BUYER_ADDRESS1.Substring(0, 35);
                    dr1["BUYER_ADDRESS"] = BUYER_ADDRESS1;
                }
                else
                {
                    dr1["BUYER_ADDRESS"] = BUYER_ADDRESS1;
                }


                if (BUYER_ADDRESS2.Length > 35)
                {
                    count = BUYER_ADDRESS2.Count();
                    string add1 = BUYER_ADDRESS2.Substring(0, 35);
                    dr1["BUYER_ADDRESS1"] = add1;
                    int count1 = count - 35;

                    int count2 = BUYER_ADDRESS3.Length + count1;
                    if (count2 > 35)
                    {
                        count2 = count1 + BUYER_ADDRESS3.Length;
                        string buyer3 = BUYER_ADDRESS2.Substring(35, count1) + " " + BUYER_ADDRESS3;
                        dr1["BUYER_ADDRESS2"] = buyer3.Substring(0, 35);
                        if (buyer3.Length > 35)
                        {
                        }
                        else
                        {
                            dr1["BUYER_ADDRESS3"] = buyer3.Substring(35, count2);
                        }
                    }
                    else
                    {
                        dr1["BUYER_ADDRESS2"] = BUYER_ADDRESS2.Substring(35, count1) + " " + BUYER_ADDRESS3;
                    }
                }
                else
                {
                    if (BUYER_ADDRESS1.Length == 0)
                    {
                        dr1["BUYER_ADDRESS"] = BUYER_ADDRESS2;
                    }
                    else
                    {
                        dr1["BUYER_ADDRESS1"] = BUYER_ADDRESS2;
                    }
                }

                //dr1["BUYER_ADDRESS1"] = BUYER_ADDRESS2;
                //dr1["BUYER_ADDRESS2"] = BUYER_ADDRESS3;
                dr1["BUYER_ADDRESS3"] = "";
                dr1["BUYER_ADDRESS4"] = "";
            }

            dr1["COMMISSION_RATE"] = "0.00";
            if (Inv_data.Rows[i]["COMMISSION"].ToString().Trim() == "0" || Inv_data.Rows[i]["COMMISSION"].ToString().Trim() == "0.0" || Inv_data.Rows[i]["COMMISSION"].ToString().Trim() == "0.00")
            {
                dr1["COMMISSION_CHARGES"] = "";
            }
            else
            {
                dr1["COMMISSION_CHARGES"] = Inv_data.Rows[i]["COMMISSION"].ToString().Trim();
            }
            dr1["COMMISSION_CURRENCY"] = Inv_data.Rows[i]["COMMISSION_CURRENCY"].ToString().Trim();

            //dr1["FOB_RATE"] = Inv_data.Rows[i]["FOB_DISC_RAT"].ToString();
            //dr1["FOB_CHARGES"] = Inv_data.Rows[i]["FOB_DISC_AMT"].ToString();
            //dr1["FOB_CURRENCY"] = Inv_data.Rows[i]["FOB_DISC_CUR"].ToString();

            //dr1["PACKMISC_RATE"] = Inv_data.Rows[i]["PACK_RATE"].ToString();
            //dr1["PACKMISC_CHARGES"] = Inv_data.Rows[i]["PACK_CHARG"].ToString();
            //dr1["PACKMISC_CURRENCY"] = Inv_data.Rows[i]["PACK_CUR"].ToString();

            //dr1["OTHER_DEDUCTION_RATE"] = Inv_data.Rows[i]["OTHDED_RAT"].ToString();
            //dr1["OTHER_DEDUCTION_CHARGES"] = Inv_data.Rows[i]["OTHDED_AMT"].ToString();
            //dr1["OTHER_DEDUCTION_CURRENCY"] = Inv_data.Rows[i]["OTHDED_CUR"].ToString();

            dr1["FOB_RATE"] = "0.00";
            dr1["FOB_CHARGES"] = "";
            dr1["FOB_CURRENCY"] = Inv_data.Rows[i]["INV_CURRENCY"].ToString().Trim();

            dr1["PACKMISC_RATE"] = "0.00";
            dr1["PACKMISC_CHARGES"] = "";
            dr1["PACKMISC_CURRENCY"] = Inv_data.Rows[i]["INV_CURRENCY"].ToString().Trim();

            dr1["OTHER_DEDUCTION_RATE"] = "0.00";
            dr1["OTHER_DEDUCTION_CHARGES"] = "";
            dr1["OTHER_DEDUCTION_CURRENCY"] = Inv_data.Rows[i]["INV_CURRENCY"].ToString().Trim();


            if (TERMS == "CIF")
            {
                if (Inv_data.Rows[i]["FREIGHT"].ToString().Trim() == "0" || Inv_data.Rows[i]["FREIGHT"].ToString().Trim() == "0.0" || Inv_data.Rows[i]["FREIGHT"].ToString().Trim() == "0.00")
                {
                    dr1["FREIGHT_CHARGES"] = "";
                }
                else
                {
                    dr1["FREIGHT_CHARGES"] = Inv_data.Rows[i]["FREIGHT"].ToString().Trim();
                }
                dr1["FREIGHT_CURRENCY"] = Inv_data.Rows[i]["FREIGHT_CURRENCY"].ToString().Trim();


                if (Inv_data.Rows[i]["INSURANCE"].ToString().Trim() == "0" || Inv_data.Rows[i]["INSURANCE"].ToString().Trim() == "0.0" || Inv_data.Rows[i]["INSURANCE"].ToString().Trim() == "0.00")
                {
                    dr1["INSURANCE_CHARGES"] = "";
                }
                else
                {
                    dr1["INSURANCE_CHARGES"] = Inv_data.Rows[i]["INSURANCE"].ToString().Trim();
                }
                dr1["INSURANCE_CURRENCY"] = Inv_data.Rows[i]["INSURANCE_CURRENCY"].ToString().Trim();
            }
            else if (TERMS == "CF")
            {
                if (Inv_data.Rows[i]["FREIGHT"].ToString().Trim() == "0" || Inv_data.Rows[i]["FREIGHT"].ToString().Trim() == "0.0" || Inv_data.Rows[i]["FREIGHT"].ToString().Trim() == "0.00")
                {
                    dr1["FREIGHT_CHARGES"] = "";
                }
                else
                {
                    dr1["FREIGHT_CHARGES"] = Inv_data.Rows[i]["FREIGHT"].ToString().Trim();
                }
                dr1["FREIGHT_CURRENCY"] = Inv_data.Rows[i]["FREIGHT_CURRENCY"].ToString().Trim();
            }
            else if (TERMS == "CI")
            {
                if (Inv_data.Rows[i]["INSURANCE"].ToString().Trim() == "0" || Inv_data.Rows[i]["INSURANCE"].ToString().Trim() == "0.0" || Inv_data.Rows[i]["INSURANCE"].ToString().Trim() == "0.00")
                {
                    dr1["INSURANCE_CHARGES"] = "";
                }
                else
                {
                    dr1["INSURANCE_CHARGES"] = Inv_data.Rows[i]["INSURANCE"].ToString().Trim();
                }
                dr1["INSURANCE_CURRENCY"] = Inv_data.Rows[i]["INSURANCE_CURRENCY"].ToString().Trim();
            }
            else
            {
                dr1["FREIGHT_CHARGES"] = "";
                dr1["FREIGHT_CURRENCY"] = "";
                dr1["INSURANCE_CHARGES"] = "";
                dr1["INSURANCE_CURRENCY"] = "";
            }


            //FREIGHT_RATE = Inv_data.Rows[i][0].ToString();
            dr1["INSURANCE_RATE"] = "0.00";

            dr1["FREIGHT_EXRATE"] = adm.Currency_Converter(Inv_data.Rows[i]["FREIGHT_CURRENCY"].ToString().Trim());
            dr1["INSURANCE_EXRATE"] = adm.Currency_Converter(Inv_data.Rows[i]["INSURANCE_CURRENCY"].ToString().Trim());

            if (TERMS == "FOB")
            {
                dr1["FREIGHT_CURRENCY"] = "";
                dr1["INSURANCE_CURRENCY"]= "";
                dr1["FREIGHT_CHARGES"] = "";
                dr1["INSURANCE_CHARGES"] = "";
            }
            else if (TERMS == "CIF")
            {
                if (dr1["FREIGHT_CURRENCY"] == "")
                {
                    dr1["FREIGHT_CURRENCY"] = dr1["INVOICE_CURRENCY"];
                }
                if (dr1["INSURANCE_CURRENCY"] == "")
                {
                    dr1["INSURANCE_CURRENCY"] = dr1["INVOICE_CURRENCY"];
                }
            }
            else if (TERMS == "CI")
            {
                dr1["FREIGHT_CURRENCY"] = "";
                if (dr1["INSURANCE_CURRENCY"] == "")
                {
                    dr1["INSURANCE_CURRENCY"] = dr1["INVOICE_CURRENCY"];
                }
            }
            else if (TERMS == "CF")
            {
                dr1["INSURANCE_CURRENCY"] = "";
                if (dr1["FREIGHT_CURRENCY"] == "")
                {
                    dr1["FREIGHT_CURRENCY"] = dr1["INVOICE_CURRENCY"];
                }
            }

            if (dr1["COMMISSION_CURRENCY"] == "")
            {
                dr1["COMMISSION_CURRENCY"] = dr1["INVOICE_CURRENCY"];
            }
            if (dr1["FOB_CURRENCY"] == "")
            {
                dr1["FOB_CURRENCY"] = dr1["INVOICE_CURRENCY"];
            }
            if (dr1["PACKMISC_CURRENCY"] == "")
            {
                dr1["PACKMISC_CURRENCY"] = dr1["INVOICE_CURRENCY"];
            }
            if (dr1["OTHER_DEDUCTION_CURRENCY"] == "")
            {
                dr1["OTHER_DEDUCTION_CURRENCY"] = dr1["INVOICE_CURRENCY"];
            }


            dr1["WHEATHER_UNIT_PRICE"] = "N";

            dr1["NON_STD_EFFECT_DT_EXP"] = "01/01/1900";
            //NON_STD_BANKNAME=Inv_data.Rows[i][0].ToString();
            //NON_STD_CERTIFICATE_NO=Inv_data.Rows[i][0].ToString();
            dr1["NON_STD_CERTIFICATE_DATE"] = "01/01/1900";
            //MODIFIEDBY=Inv_data.Rows[i][0].ToString();
            //MODIFIEDON = Inv_data.Rows[i][0].ToString();

            dr1["TERMS_PLACE"] = "";
            dr1["THIRDPARTY_NAME"] = "";
            dr1["THIRDPARTY_ADD1"] = "";
            dr1["THIRDPARTY_ADD2"] = "";
            dr1["THIRDPARTY_CITY"] = "";
            dr1["T_PARTY_COUNTRY_SUB_DIV"] = "";
            dr1["T_PARTY_COUNTRY_CODE"] = "";
            dr1["T_PARTY_PIN"] = "";
            dr1["AUTHORIZED_ECONOMIC_OPERATOR_CODE"] = "";
            dr1["A_E_O_COUNTRY"] = "";
            dr1["AUTHORIZED_ECONOMIC_OPERATOR"] = "";


            dt_Inv.Rows.Add(Convert.ToInt32(INVOICE_ID) + i, EXPORT_JOBNO, dr1["JOBDATE"], dr1["INVOICE_SLNO"], dr1["INVOICE_NO"], dr1["INVOICE_DATE"], dr1["PAYMENT_METHOD"], dr1["PERIOD_PAYMENT"], dr1["INVOICE_VALUE"], dr1["INVOICE_CURRENCY"], dr1["EXCHANGE_RATE"], dr1["CONTRACT_NO"],
                            dr1["TERMS"], dr1["BUYER"], dr1["BUYER_NAME"], dr1["BUYER_ADDRESS"], dr1["BUYER_ADDRESS1"], dr1["BUYER_ADDRESS2"], dr1["BUYER_ADDRESS3"], dr1["BUYER_ADDRESS4"], dr1["COMMISSION_RATE"], dr1["COMMISSION_CHARGES"], dr1["COMMISSION_CURRENCY"],
                            dr1["FOB_RATE"], dr1["FOB_CHARGES"], dr1["FOB_CURRENCY"], dr1["PACKMISC_RATE"], dr1["PACKMISC_CHARGES"], dr1["PACKMISC_CURRENCY"], dr1["OTHER_DEDUCTION_RATE"], dr1["OTHER_DEDUCTION_CHARGES"], dr1["OTHER_DEDUCTION_CURRENCY"],
                            dr1["FREIGHT_RATE"], dr1["FREIGHT_CHARGES"], dr1["FREIGHT_CURRENCY"], dr1["FREIGHT_EXRATE"], dr1["INSURANCE_RATE"], dr1["INSURANCE_CHARGES"], dr1["INSURANCE_CURRENCY"], dr1["INSURANCE_EXRATE"], dr1["WHEATHER_UNIT_PRICE"],
                            Connection.Current_User(), dateTime.ToString("dd/MM/yyyy"), "N", Connection.Current_Branch(), "", Connection.WorkingPeriod(), dr1["NON_STD_EFFECT_DT_EXP"], "", "", dr1["NON_STD_CERTIFICATE_DATE"], Connection.Current_User(), dateTime.ToString("dd/MM/yyyy"),
                            dr1["TERMS_PLACE"], dr1["THIRDPARTY_NAME"], dr1["THIRDPARTY_ADD1"], dr1["THIRDPARTY_ADD2"], dr1["THIRDPARTY_CITY"], dr1["T_PARTY_COUNTRY_SUB_DIV"], dr1["T_PARTY_COUNTRY_CODE"], dr1["T_PARTY_PIN"],
                            dr1["AUTHORIZED_ECONOMIC_OPERATOR_CODE"], dr1["A_E_O_COUNTRY"], dr1["AUTHORIZED_ECONOMIC_OPERATOR"]);


            if (hdn_TransportMode.Value == "Sea" || hdn_TransportMode.Value == "Land")
            {
                //--------------------EXPORT_CONTAINER Details--------------------------//
                #region EXPORT_CONTAINER

                if (Inv_data.Rows[i]["Container_No"].ToString() != "")
                {

                    DataRow dr2 = dt_CONTAINER.NewRow();


                    dr2["ANNEX_SEA_CON_CONTAINERNO"] = Inv_data.Rows[i]["CONTAINER_NO"].ToString().Trim();
                    dr2["ANNEX_SEA_CON_SIZE"] = Inv_data.Rows[i]["CONTAINER_SIZE"].ToString().Trim();
                    dr2["ANNEX_SEA_CON_TYPE"] = Inv_data.Rows[i]["CONTAINER_TYPE"].ToString().Trim();
                    dr2["ANNEX_SEA_CON_EXCISE_SEALNO"] = Inv_data.Rows[i]["SHIPPING_SEAL"].ToString().Trim();
                    dr2["ANNEX_SEA_CON_SEAL_DATE"] = "01/01/1900";
                    dr2["ANNEX_SEA_CON_SEALTYPE_INDICATOR"] = SEAL_TYPE_INDICATOR;
                    dr2["ANNEX_SEA_CON_SEAL_DEVICEID"] = "";
                    dr2["ANNEX_SEA_CON_DOC_TYPE"] = "";
                    dr2["ANNEX_SEA_CON_DOC_NUMBER"] = "";


                    CONTAINER_MAX_ID = Get_general_MAXID("CONTAINER_MAX_ID");
                    dt_CONTAINER.Rows.Add(CONTAINER_MAX_ID + i, EXPORT_JOBNO, dr2["ANNEX_SEA_CON_CONTAINERNO"], dr2["ANNEX_SEA_CON_SIZE"], dr2["ANNEX_SEA_CON_TYPE"], dr2["ANNEX_SEA_CON_EXCISE_SEALNO"], dr2["ANNEX_SEA_CON_SEAL_DATE"],
                                     Connection.Current_User(), dateTime.ToString("dd/MM/yyyy"), "N", Connection.Current_Branch(), "", Connection.WorkingPeriod(), Connection.Current_User(), dateTime.ToString("dd/MM/yyyy"),
                                     dr2["ANNEX_SEA_CON_SEALTYPE_INDICATOR"], dr2["ANNEX_SEA_CON_SEAL_DEVICEID"], dr2["ANNEX_SEA_CON_DOC_TYPE"], dr2["ANNEX_SEA_CON_DOC_NUMBER"]);
                }
                
            }

                #endregion EXPORT_CONTAINER
           

        }

        if (dt_CONTAINER.Rows.Count > 0)
        {
            admin.SqlBulk_Upload_Product("EXPORT_ANNEXURE_C_SEA_CONTAINER", dt_CONTAINER, comp_ConnectionStr);
        }

        //ViewState["ds_INVOICE"] = dt_Inv;
        if (dt_Inv.Rows.Count > 0)
        {
            admin.SqlBulk_Upload_Product("EXPORT_INVOICE_DETAILS", dt_Inv, comp_ConnectionStr);
            Inv_data1 = Inv_data;
        }
    }

    public void Bind_Item_Details(DataTable Item_Data, string EXPORT_JOBNO)
    {
        #region dt_Item
        dt_Item.Columns.Add("ITEM_ID");
        dt_Item.Columns.Add("JOBNO");
        dt_Item.Columns.Add("INVOICE_SLNO");
        dt_Item.Columns.Add("INVOICE_NO");
        dt_Item.Columns.Add("ITEM_SLNO");
        dt_Item.Columns.Add("ITEM_DESCRIPTION");
        dt_Item.Columns.Add("RITCNO");
        dt_Item.Columns.Add("ITEM_QTY");
        dt_Item.Columns.Add("ITEM_QTY_CODE");
        dt_Item.Columns.Add("ITEM_UNIT_PRICE");
        dt_Item.Columns.Add("ITEM_PER");
        dt_Item.Columns.Add("ITEM_AMOUNT");
        dt_Item.Columns.Add("ITEM_PMVVALUE");
        dt_Item.Columns.Add("ITEM_SCHEME_CODE");
        dt_Item.Columns.Add("ITEM_ACCESSORIES_DESC");
        dt_Item.Columns.Add("ITEM_AR4_NO");
        dt_Item.Columns.Add("ITEM_AR4_DATE");
        dt_Item.Columns.Add("ITEM_COMMISSION_RATE");
        dt_Item.Columns.Add("ITEM_DIVISION");
        dt_Item.Columns.Add("ITEM_RANGE");
        dt_Item.Columns.Add("ITEM_REMARKS");
        dt_Item.Columns.Add("ITEM_IECCODE");
        dt_Item.Columns.Add("ITEM_EXPORTER_NAME");
        dt_Item.Columns.Add("BR_SLNO");
        dt_Item.Columns.Add("ADDRESS1");
        dt_Item.Columns.Add("ADDRESS2");
        dt_Item.Columns.Add("ADDRESS3");
        dt_Item.Columns.Add("ADDRESS4");
        dt_Item.Columns.Add("ADDRESS5");
        dt_Item.Columns.Add("ITEM_STR_CODE");
        dt_Item.Columns.Add("REWARD_POINTS");
        dt_Item.Columns.Add("USER_ID");
        dt_Item.Columns.Add("DATE_TIME");
        dt_Item.Columns.Add("STATUS");
        dt_Item.Columns.Add("BRANCH_CODE");
        dt_Item.Columns.Add("YEAR");
        dt_Item.Columns.Add("WORKING_PERIOD");
        dt_Item.Columns.Add("PMV_VALUE");
        dt_Item.Columns.Add("FOB_VALUE");
        dt_Item.Columns.Add("DRAWBACK_VALUE");
        dt_Item.Columns.Add("CESS_YN");
        dt_Item.Columns.Add("MODIFIEDBY");
        dt_Item.Columns.Add("MODIFIEDON");
        dt_Item.Columns.Add("STR_RATE");
        dt_Item.Columns.Add("STR_AMOUNT");
        dt_Item.Columns.Add("MANUFACTURER_PRODUCER");
        dt_Item.Columns.Add("M_P_GROWER_CODE");
        dt_Item.Columns.Add("M_P_GROWER_ADD1");
        dt_Item.Columns.Add("M_P_GROWER_ADD2");
        dt_Item.Columns.Add("M_P_GROWER_CITY");
        dt_Item.Columns.Add("M_P_GROWER_COUNTRY_SUBDIV");
        dt_Item.Columns.Add("M_P_GROWER_PIN");
        dt_Item.Columns.Add("M_P_GROWER_COUNTRY");
        dt_Item.Columns.Add("SOURCE_STATE");
        dt_Item.Columns.Add("TRANSIT_COUNTRY");
        dt_Item.Columns.Add("ACCESSORY_STATUS");
        dt_Item.Columns.Add("HAWB_NO");
        dt_Item.Columns.Add("TOTAL_PKGS");
        dt_Item.Columns.Add("ENDUSE_ITEM");
        dt_Item.Columns.Add("IGST_PAYMENT");
        dt_Item.Columns.Add("TAXABLE_VALUE");
        dt_Item.Columns.Add("IGST_AMT");
        dt_Item.Columns.Add("GSTN_TYPE");
        dt_Item.Columns.Add("GSTN_ID");


        #endregion dt_Item


        //ITEM_ID = Convert.ToString(Get_general_MAXID("ITEM_MAX_ID"));
        ITEM_ID = Get_general_MAXID("ITEM_MAX_ID");

        //******************** Remove Empty Rows from Datatable  ********************************
        //Item_Data = Item_Data.Rows.Cast<DataRow>()
        //     .Where(row => !row.ItemArray.All(field => field is System.DBNull))
        //     .CopyToDataTable();
        //*****************************************************************************************

        //while (ds.Tables[0].Rows[b][0] != System.DBNull.Value)
        //{
        for (int b = 0; b <= Item_Data.Rows.Count - 1; b++)
        {
            DataRow dr2 = dt_Item.NewRow();

            var LoginDetails = from myRow in Inv_data1.AsEnumerable()
                               where myRow.Field<Int32>("ZPTC_SHIPPING_BILL_INVOICE_Id") == b
                               select myRow;

            DataTable dd = new DataTable();
            dd = LoginDetails.CopyToDataTable();

            dr2["INVOICE_SLNO"] = dd.Rows[0]["INV_SL_NO"].ToString().Trim();
            dr2["INVOICE_NO"] = dd.Rows[0]["INVOICE_NO"].ToString().Trim();
            dr2["ITEM_SLNO"] = Item_Data.Rows[b]["INVOICE_ITEMSERIALNO"].ToString().Trim();
            dr2["ITEM_DESCRIPTION"] = Item_Data.Rows[b]["GOODS_DESCRIPTION"].ToString() + "" + Item_Data.Rows[b]["GOODS_DESCRIPTION1"].ToString();
            dr2["RITCNO"] = Item_Data.Rows[b]["HSNCODE"].ToString().Trim().Replace(" ", "");
            dr2["ITEM_QTY"] = Item_Data.Rows[b]["QUANTITY"].ToString();
            dr2["ITEM_QTY_CODE"] = Item_Data.Rows[b]["UOM"].ToString();
            dr2["ITEM_UNIT_PRICE"] = dd.Rows[0]["UNIT_RATE"].ToString();
            dr2["ITEM_PER"] = "1";

            if (Item_Data.Rows[b][4] != System.DBNull.Value && Item_Data.Rows[b][6] != System.DBNull.Value)
            {
                item_amt = Convert.ToDecimal(Item_Data.Rows[b]["QUANTITY"]) * Convert.ToDecimal(dd.Rows[0]["UNIT_RATE"].ToString());
            }
            else
            {
                item_amt = 0;
            }

            //ITEM_AMOUNT = item_amt;
            dr2["ITEM_AMOUNT"] = Convert.ToString(item_amt);
            dr2["ITEM_PMVVALUE"] = "0.00";

            var q1 =
                       from r in dt_Inv.AsEnumerable()
                       where r.Field<string>("INVOICE_SLNO").Equals(dd.Rows[0]["INV_SL_NO"].ToString())
                       select r.Field<string>("EXCHANGE_RATE");
            var exrate = q1.FirstOrDefault();

            if (exrate != "")
            {
                //double pmv = (((Convert.ToDouble(lblInvoiceValue) * 110) / 100) * (Convert.ToDouble(hdn_Invoice_Exrate))) / Convert.ToDouble(txtItemQty);
                decimal pmv = ((((Convert.ToDecimal(dr2["ITEM_QTY"]) * Convert.ToDecimal(dr2["ITEM_UNIT_PRICE"]) * Convert.ToDecimal(exrate)) * 110) / 100));

                dr2["ITEM_PMVVALUE"] = Convert.ToString(Math.Round(pmv, 2));
            }

            scheme = SCHEME_CODE;

            if (scheme.Contains('-'))
            {
                string[] sp = scheme.Split('-');
                scheme = sp[0];
            }

            Open_Schemecode();

            dr2["ITEM_SCHEME_CODE"] = scheme;

            dr2["ITEM_STR_CODE"] = "";
            dr2["REWARD_POINTS"] = REWARD_FLAG.Trim() == "" ? "N" : REWARD_FLAG.Trim();

            //dr2["ENDUSE_ITEM"] = "GNX200";
            //dr2["IGST_PAYMENT"] = "NA";
            dr2["ENDUSE_ITEM"] = ENDUSE_ITEM;



            dr2["TAXABLE_VALUE"] = Item_Data.Rows[b]["ASSESSABLE_VALUE"].ToString().Trim();
            dr2["IGST_AMT"] = Item_Data.Rows[b]["GST"].ToString().Trim();

            if (Item_Data.Rows[b]["GST"].ToString().Trim() != "")
            {
                dr2["IGST_PAYMENT"] = "P";
            }
            else
            {
                dr2["IGST_PAYMENT"] = "NA";
            }

            //dr2["CESS_YN"] = Item_Data.Rows[b][14].ToString();
            dr2["CESS_YN"] = "N";
            /**************************************************** */
            //string CESS_SRNO = Item_Data.Rows[b][15].ToString();

            dr2["ITEM_AR4_NO"] = "";
            dr2["ITEM_AR4_DATE"] = "01/01/1900";
            dr2["ITEM_COMMISSION_RATE"] = "";
            dr2["ITEM_DIVISION"] = "";
            dr2["ITEM_RANGE"] = "";
            dr2["ITEM_REMARKS"] = "";


            dr2["ITEM_IECCODE"] = "";
            dr2["BR_SLNO"] = "";
            dr2["ITEM_EXPORTER_NAME"] = "";
            dr2["ADDRESS1"] = "";
            dr2["ADDRESS2"] = "";
            dr2["ADDRESS3"] = "";
            dr2["ADDRESS4"] = "";
            dr2["ADDRESS5"] = "";
            //if (Item_Data.Rows[b][33].ToString().Contains('-'))
            //{
            //    dr2["GSTN_TYPE"] = Item_Data.Rows[b][].ToString().Substring(0, 3);
            //}
            dr2["GSTN_TYPE"] = "";
            dr2["GSTN_ID"] = "";

            dr2["MANUFACTURER_PRODUCER"] = "";
            dr2["M_P_GROWER_CODE"] = "";
            dr2["M_P_GROWER_ADD1"] = "";
            dr2["M_P_GROWER_ADD2"] = "";
            dr2["M_P_GROWER_CITY"] = "";
            dr2["M_P_GROWER_COUNTRY_SUBDIV"] = "";
            dr2["M_P_GROWER_PIN"] = "";
            dr2["M_P_GROWER_COUNTRY"] = "";

            //if (Item_Data.Rows[b]["SOURCE_STATE"].ToString().Contains('-'))
            //{
            //    dr2["SOURCE_STATE"] = Item_Data.Rows[b]["SOURCE_STATE"].ToString().Substring(0, 2);
            //}
            //else
            //{
            dr2["SOURCE_STATE"] = "";
            //}
            dr2["TRANSIT_COUNTRY"] = "";
            dr2["ACCESSORY_STATUS"] = "";

            dr2["HAWB_NO"] = "";
            dr2["TOTAL_PKGS"] = "";




            dt_Item.Rows.Add(ITEM_ID + b, EXPORT_JOBNO, dr2["INVOICE_SLNO"], dr2["INVOICE_NO"], dr2["ITEM_SLNO"], dr2["ITEM_DESCRIPTION"], dr2["RITCNO"], dr2["ITEM_QTY"], dr2["ITEM_QTY_CODE"], dr2["ITEM_UNIT_PRICE"], dr2["ITEM_PER"], dr2["ITEM_AMOUNT"],
                            dr2["ITEM_PMVVALUE"], dr2["ITEM_SCHEME_CODE"], dr2["ITEM_ACCESSORIES_DESC"], dr2["ITEM_AR4_NO"], dr2["ITEM_AR4_DATE"], dr2["ITEM_COMMISSION_RATE"], dr2["ITEM_DIVISION"], dr2["ITEM_RANGE"], dr2["ITEM_REMARKS"],
                            dr2["ITEM_IECCODE"], dr2["ITEM_EXPORTER_NAME"], dr2["BR_SLNO"], dr2["ADDRESS1"], dr2["ADDRESS2"], dr2["ADDRESS3"], dr2["ADDRESS4"], dr2["ADDRESS5"], dr2["ITEM_STR_CODE"], dr2["REWARD_POINTS"], Connection.Current_User(), dateTime.ToString("dd/MM/yyyy"), "N",
                            Connection.Current_Branch(), "", Connection.WorkingPeriod(), dr2["PMV_VALUE"], dr2["FOB_VALUE"], dr2["DRAWBACK_VALUE"], dr2["CESS_YN"], Connection.Current_User(), dateTime.ToString("dd/MM/yyyy"), dr2["STR_RATE"], dr2["STR_AMOUNT"], dr2["MANUFACTURER_PRODUCER"],
                            dr2["M_P_GROWER_CODE"], dr2["M_P_GROWER_ADD1"], dr2["M_P_GROWER_ADD2"], dr2["M_P_GROWER_CITY"], dr2["M_P_GROWER_COUNTRY_SUBDIV"], dr2["M_P_GROWER_PIN"], dr2["M_P_GROWER_COUNTRY"], dr2["SOURCE_STATE"], dr2["TRANSIT_COUNTRY"],
                            dr2["ACCESSORY_STATUS"], dr2["HAWB_NO"], dr2["TOTAL_PKGS"], dr2["ENDUSE_ITEM"], dr2["IGST_PAYMENT"], dr2["TAXABLE_VALUE"], dr2["IGST_AMT"], dr2["GSTN_TYPE"], dr2["GSTN_ID"]);

        }

        if (dt_Item.Rows.Count > 0)
        {
            admin.SqlBulk_Upload_Product("EXPORT_ITEM_DETAILS", dt_Item, comp_ConnectionStr);

        }
    }

    public void Bind_AR4_Details(DataTable Item_AR4, string EXPORT_JOBNO)
    {

        #region dt_AR4
        dt_AR4.Columns.Add("AR4_ID");
        dt_AR4.Columns.Add("AR4_JOBNO");
        dt_AR4.Columns.Add("AR4_NO");
        dt_AR4.Columns.Add("AR4_DATE");
        dt_AR4.Columns.Add("AR4_COMMISSION_RATE");
        dt_AR4.Columns.Add("AR4_DIVISION");
        dt_AR4.Columns.Add("AR4_RANGE");
        dt_AR4.Columns.Add("AR4_REMARKS");
        dt_AR4.Columns.Add("USER_ID");
        dt_AR4.Columns.Add("DATE_TIME");
        dt_AR4.Columns.Add("STATUS");
        dt_AR4.Columns.Add("BRANCH_CODE");
        dt_AR4.Columns.Add("YEAR");
        dt_AR4.Columns.Add("WORKING_PERIOD");
        dt_AR4.Columns.Add("AR4_INVOICE_NO");
        dt_AR4.Columns.Add("AR4_INVOICE_SLNO");
        dt_AR4.Columns.Add("AR4_RUN_ID");
        dt_AR4.Columns.Add("AR4_ITEM_NO");
        dt_AR4.Columns.Add("MODIFIEDBY");
        dt_AR4.Columns.Add("MODIFIEDON");
        #endregion dt_AR4

        //--------------------AR4 Details--------------------------//
        #region EXPORT_AR4_TBL

        for (int b = 0; b <= Item_AR4.Rows.Count - 1; b++)
        {
            DataRow dr2 = dt_AR4.NewRow();

            var query =
                       from r in dt_Inv.AsEnumerable()
                       where r.Field<string>("INVOICE_SLNO").Equals(Item_AR4.Rows[b]["INV_SRNO"].ToString())
                       select r.Field<string>("INVOICE_NO");
            var name1 = query.FirstOrDefault();

            dr2["AR4_INVOICE_SLNO"] = Item_AR4.Rows[b]["INV_SRNO"].ToString();
            dr2["AR4_ITEM_NO"] = Item_AR4.Rows[b]["ITM_NO"].ToString();
            string AR4_INVOICE_NO = name1;
            dr2["AR4_NO"] = Item_AR4.Rows[b]["AR4NO"].ToString();
            dr2["AR4_DATE"] = Item_AR4.Rows[b]["AR4DT"].ToString();
            dr2["AR4_COMMISSION_RATE"] = Item_AR4.Rows[b]["COMMISSIONERATE"].ToString();
            dr2["AR4_DIVISION"] = Item_AR4.Rows[b]["DIVISION"].ToString();
            dr2["AR4_RANGE"] = Item_AR4.Rows[b]["RANGE"].ToString();
            dr2["AR4_REMARKS"] = Item_AR4.Rows[b]["REMARKS"].ToString();


            AR4_ID = Get_general_MAXID("AR4_MAX_ID");
                    dt_AR4.Rows.Add(AR4_ID + b, EXPORT_JOBNO, dr2["AR4_NO"], dr2["AR4_DATE"], dr2["AR4_COMMISSION_RATE"], dr2["AR4_DIVISION"], dr2["AR4_RANGE"], dr2["AR4_REMARKS"],
                                     Connection.Current_User(), dateTime.ToString("dd/MM/yyyy"), "N", Connection.Current_Branch(), "", Connection.WorkingPeriod(),
                                     AR4_INVOICE_NO, dr2["AR4_INVOICE_SLNO"], b + 1, dr2["AR4_ITEM_NO"], Connection.Current_User(), dateTime.ToString("dd/MM/yyyy"));
        }
        if (dt_AR4.Rows.Count > 0)
        {
            admin.SqlBulk_Upload_Product("EXPORT_AR4_TBL", dt_AR4, comp_ConnectionStr);
        }

        #endregion EXPORT_AR4_TBL
    }

    public void Bind_Bulk_LICENSE_DETAILS(DataTable blk_lic_Data, string EXPORT_JOBNO)
    {
        #region dt_blk_Lic
        dt_blk_Lic.Columns.Add("LICENSE_ID", typeof(int));
        dt_blk_Lic.Columns.Add("JOB_NO");
        dt_blk_Lic.Columns.Add("INV_SL_NO");
        dt_blk_Lic.Columns.Add("ITEM_SL_NO");
        dt_blk_Lic.Columns.Add("SCHEME_CODE");
        dt_blk_Lic.Columns.Add("SCHEME");
        dt_blk_Lic.Columns.Add("LICENSE_R_SL_NO");
        dt_blk_Lic.Columns.Add("LICENSE_NO");
        dt_blk_Lic.Columns.Add("LICENSE_DATE");
        dt_blk_Lic.Columns.Add("USER_ID");
        dt_blk_Lic.Columns.Add("DATE_TIME");
        dt_blk_Lic.Columns.Add("STATUS");
        dt_blk_Lic.Columns.Add("BRANCH_CODE");
        dt_blk_Lic.Columns.Add("YEAR");
        dt_blk_Lic.Columns.Add("WORKING_PERIOD");
        dt_blk_Lic.Columns.Add("MODIFIEDBY");
        dt_blk_Lic.Columns.Add("MODIFIEDON");
        #endregion dt_blk_Lic

        #region dt_blk_Imp_Exp_lic
        dt_blk_Imp_Exp_lic.Columns.Add("LICENSE_IMP_EXP_ID", typeof(int));
        dt_blk_Imp_Exp_lic.Columns.Add("LICENSE_ID", typeof(int));
        dt_blk_Imp_Exp_lic.Columns.Add("JOB_NO");
        dt_blk_Imp_Exp_lic.Columns.Add("LICENSE_REG_SLNO");
        dt_blk_Imp_Exp_lic.Columns.Add("LICENSE_NO");
        dt_blk_Imp_Exp_lic.Columns.Add("LICENSE_E_SL_NO");
        dt_blk_Imp_Exp_lic.Columns.Add("LICENSE_EXP_QTY");
        dt_blk_Imp_Exp_lic.Columns.Add("LICENSE_EXP_UNIT");
        dt_blk_Imp_Exp_lic.Columns.Add("LICENSE_IMP_ITEM_SL_NO");
        dt_blk_Imp_Exp_lic.Columns.Add("LICENSE_IMP_DESC");
        dt_blk_Imp_Exp_lic.Columns.Add("LICENSE_IMP_QTY");
        dt_blk_Imp_Exp_lic.Columns.Add("LICENSE_IMP_UNIT");
        dt_blk_Imp_Exp_lic.Columns.Add("LICENSE_IMP_TYPE");
        dt_blk_Imp_Exp_lic.Columns.Add("USER_ID");
        dt_blk_Imp_Exp_lic.Columns.Add("DATE_TIME");
        dt_blk_Imp_Exp_lic.Columns.Add("STATUS");
        dt_blk_Imp_Exp_lic.Columns.Add("BRANCH_CODE");
        dt_blk_Imp_Exp_lic.Columns.Add("YEAR");
        dt_blk_Imp_Exp_lic.Columns.Add("WORKING_PERIOD");
        dt_blk_Imp_Exp_lic.Columns.Add("INV_SL_NO");
        dt_blk_Imp_Exp_lic.Columns.Add("ITEM_SL_NO");
        dt_blk_Imp_Exp_lic.Columns.Add("SCHEME");
        dt_blk_Imp_Exp_lic.Columns.Add("MODIFIEDBY");
        dt_blk_Imp_Exp_lic.Columns.Add("MODIFIEDON");
        #endregion dt_blk_Imp_Exp_lic

        //******************** Remove Empty Rows from Datatable  ********************************
        blk_lic_Data = blk_lic_Data.Rows.Cast<DataRow>()
             .Where(row => !row.ItemArray.All(field => field is System.DBNull))
             .CopyToDataTable();
        //***************************************************************************************
        blk_lic_Data.Rows.Add();
        int a = 0, b = 0, c = 1;

        LICENSE_ID = Get_general_MAXID("LICENSE_MAX_ID");
        License_id_Max = LICENSE_ID;
        LICENSE_IMP_EXP_ID = Get_general_MAXID("LICENSE_IMP_EXP_MAX_ID");
        License_id_IMP_EXP_Max = LICENSE_IMP_EXP_ID;

        while (blk_lic_Data.Rows[a][0] != System.DBNull.Value)
        {
            DataRow dr1 = dt_blk_Lic.NewRow();

            //var query =
            //        from r in dt_Item.AsEnumerable()
            //        where r.Field<string>("INVOICE_SLNO").Equals(blk_lic_Data.Rows[b]["INV_SL_NO"].ToString()) && r.Field<string>("ITEM_SLNO").Equals(blk_lic_Data.Rows[b]["INVOICE_ITEM_NO"].ToString())
            //        select r;
                    //select r.Field<string>("ITEM_SCHEME_CODE");
            //var schemecode = query.FirstOrDefault();


            //var LoginDetails = from myRow in dt_Item.AsEnumerable()
            //                   where myRow.Field<string>("INVOICE_SLNO").Trim() == blk_lic_Data.Rows[a]["INV_SL_NO"].ToString()
            //                   select myRow;

           

            var LoginDetails = from myRow in dt_Item.AsEnumerable()
                               where myRow.Field<string>("INVOICE_SLNO").Trim() == blk_lic_Data.Rows[a]["INV_SL_NO"].ToString().Trim()
                               select myRow;

            DataTable dd = new DataTable();
            dd = LoginDetails.CopyToDataTable();
            
            dr1["LICENSE_ID"] = License_id_Max;
            //JOBNO = EXPORT_JOBNO;
            dr1["INV_SL_NO"] = blk_lic_Data.Rows[a]["INV_SL_NO"].ToString();
            dr1["ITEM_SL_NO"] = blk_lic_Data.Rows[a]["INVOICE_ITEM_NO"].ToString().TrimEnd();
            //dr1["SCHEME_CODE"] = blk_lic_Data.Rows[a][2].ToString();

            //SCHEME = blk_lic_Data.Rows[a][3].ToString();
            //string  schemecode = scheme;
            //if (schemecode.Contains('-'))
            //{
            //    string[] sp = schemecode.Split('-');
            //    scheme = sp[0];
            //}
            scheme = SCHEME_CODE;
            scheme_name[0] = SCHEME_CODE;
            Open_Schemecode();

            dr1["SCHEME"] = scheme_name[0];
            //dr1["SCHEME"] = SCHEME_CODE;

            if (dr1["SCHEME"] != null && dr1["SCHEME"] != "")
            {
                dr1["LICENSE_R_SL_NO"] = c;
                dr1["LICENSE_NO"] = blk_lic_Data.Rows[a]["LICENSE_NO"].ToString();
                dr1["LICENSE_DATE"] = blk_lic_Data.Rows[a]["LICENSE_DATE"].ToString();

                dt_blk_Lic.Rows.Add(dr1["LICENSE_ID"], EXPORT_JOBNO, dr1["INV_SL_NO"], dr1["ITEM_SL_NO"], scheme, dr1["SCHEME"], dr1["LICENSE_R_SL_NO"], dr1["LICENSE_NO"], dr1["LICENSE_DATE"]
                    , Connection.Current_User(), dateTime.ToString("dd/MM/yyyy"), "N", Connection.Current_Branch(), "", Connection.WorkingPeriod(), Connection.Current_User(), dateTime.ToString("dd/MM/yyyy"));

                while (dr1["INV_SL_NO"] != System.DBNull.Value)
                {
                    DataRow dr2 = dt_blk_Imp_Exp_lic.NewRow();

                    string LicenseNo, IMP_Exp_LicenseNo, InvslNo, Imp_exp_Invslno, ItemslNo, Imp_exp_Itemslno;
                    LicenseNo = blk_lic_Data.Rows[a]["LICENSE_DATE"].ToString();
                    IMP_Exp_LicenseNo = blk_lic_Data.Rows[b]["LICENSE_DATE"].ToString();

                    InvslNo = blk_lic_Data.Rows[a][0].ToString();
                    Imp_exp_Invslno = blk_lic_Data.Rows[b][0].ToString();

                    ItemslNo = blk_lic_Data.Rows[a][1].ToString().TrimEnd();
                    Imp_exp_Itemslno = blk_lic_Data.Rows[b][1].ToString().TrimEnd();

                    if (LicenseNo == IMP_Exp_LicenseNo && InvslNo == Imp_exp_Invslno && ItemslNo == Imp_exp_Itemslno)
                    {
                        LICENSE_IMP_EXP_ID = License_id_IMP_EXP_Max;
                        //LICENSE_ID = License_id_Max;
                        //JOBNO = EXPORT_JOBNO;
                        //LICENSE_REG_SLNO = Convert.ToString(c);
                        //LICENSE_NO = blk_lic_Data.Rows[b][3].ToString();
                        dr2["LICENSE_E_SL_NO"] = blk_lic_Data.Rows[b]["EXP_SERIAL_NO"].ToString();
                        dr2["LICENSE_EXP_QTY"] = dd.Rows[0]["ITEM_QTY"].ToString();
                        dr2["LICENSE_EXP_UNIT"] = dd.Rows[0]["ITEM_QTY_CODE"].ToString();
                        dr2["LICENSE_IMP_ITEM_SL_NO"] = blk_lic_Data.Rows[b]["IMP_SERIAL_NO"].ToString();
                        dr2["LICENSE_IMP_DESC"] = "";
                        dr2["LICENSE_IMP_QTY"] = blk_lic_Data.Rows[b]["QUANTITY"].ToString();
                        dr2["LICENSE_IMP_UNIT"] = blk_lic_Data.Rows[b]["UOM"].ToString();
                        //dr1["LICENSE_IMP_TYPE"] = ds.Tables[0].Rows[b][13].ToString();
                        //if (blk_lic_Data.Rows[b]["LIC_TYPE"].ToString() == "Imported")
                        //{
                        //    dr2["LICENSE_IMP_TYPE"] = "M";
                        //}
                        //else
                        //{
                        //    dr2["LICENSE_IMP_TYPE"] = "N";
                        //}
                        //dr2["LICENSE_IMP_TYPE"] = "M";
                        dr2["LICENSE_IMP_TYPE"] = "";
                        dt_blk_Imp_Exp_lic.Rows.Add(LICENSE_IMP_EXP_ID + 1, dr1["LICENSE_ID"], EXPORT_JOBNO, dr1["LICENSE_R_SL_NO"], dr1["LICENSE_NO"], dr2["LICENSE_E_SL_NO"], dr2["LICENSE_EXP_QTY"],
                                          dr2["LICENSE_EXP_UNIT"], dr2["LICENSE_IMP_ITEM_SL_NO"], dr2["LICENSE_IMP_DESC"], dr2["LICENSE_IMP_QTY"], dr2["LICENSE_IMP_UNIT"], dr2["LICENSE_IMP_TYPE"],
                                           Connection.Current_User(), dateTime.ToString("dd/MM/yyyy"), "N", Connection.Current_Branch(), "", Connection.WorkingPeriod(), dr1["INV_SL_NO"], dr1["ITEM_SL_NO"], dr1["SCHEME"], Connection.Current_User(), dateTime.ToString("dd/MM/yyyy"));


                        b++;
                        License_id_IMP_EXP_Max++;
                    }
                    else
                    {
                        break;
                    }
                }
                //}

                //a++;
                a = b;
                License_id_Max++;
            }
            else
            {
                b++;
                a = b;
            }
        }

        if (dt_blk_Lic.Rows.Count > 0)
        {
            admin.SqlBulk_Upload_Product("EXPORT_LICENSE_DETAILS", dt_blk_Lic, comp_ConnectionStr);
        }
        if (dt_blk_Imp_Exp_lic.Rows.Count > 0)
        {
            admin.SqlBulk_Upload_Product("EXPORT_LICENSE_IMP_EXP_DETAILS", dt_blk_Imp_Exp_lic, comp_ConnectionStr);
        }

    }

    public void Bind_Drawback_Details(DataTable Item_DBK, string EXPORT_JOBNO)
    {
        #region dt_Dbk
        dt_Dbk.Columns.Add("DRAWBACK_ID");
        dt_Dbk.Columns.Add("JOBNO");
        dt_Dbk.Columns.Add("INVOICE_SLNO");
        dt_Dbk.Columns.Add("ITEM_SLNO");
        dt_Dbk.Columns.Add("SCHEME_CODE");
        dt_Dbk.Columns.Add("DRAWBACK_SLNO");
        dt_Dbk.Columns.Add("DRAWBACK_QTY");
        dt_Dbk.Columns.Add("DRAWBACK_UNIT");
        dt_Dbk.Columns.Add("DRAWBACK_NOOFUNITS");
        dt_Dbk.Columns.Add("DRAWBACK_RATE");
        dt_Dbk.Columns.Add("DRAWBACK_CAPS");
        dt_Dbk.Columns.Add("DRAWBACK_DESC");
        dt_Dbk.Columns.Add("USER_ID");
        dt_Dbk.Columns.Add("DATE_TIME");
        dt_Dbk.Columns.Add("STATUS");
        dt_Dbk.Columns.Add("BRANCH_CODE");
        dt_Dbk.Columns.Add("YEAR");
        dt_Dbk.Columns.Add("WORKING_PERIOD");
        dt_Dbk.Columns.Add("MODIFIEDBY");
        dt_Dbk.Columns.Add("MODIFIEDON");
        dt_Dbk.Columns.Add("STATE_LEVEL_ADV_RATE");
        dt_Dbk.Columns.Add("STATE_LEVEL_ADV_AMT");
        #endregion dt_Dbk

        //--------------------Drawback Details--------------------------//
      
        string[] arr = { "19", "41", "43", "44", "47", "48", "49", "71", "73", "74", "79", "60", "61", "62", "63", "64", "65" };
        //string scheme_draw = Item_Data.Rows[b]["SCHEMECODE"].ToString().Trim();
        string scheme_draw = scheme;
        if (scheme_draw.Contains('-'))
        {
            string[] sp = scheme_draw.Split('-');
            scheme_draw = sp[0];
        }

        string Draw_value = Array.Find(arr, element => element.StartsWith(scheme_draw, StringComparison.Ordinal));

        if (Draw_value != null)
        {
            DataRow dr3 = dt_Dbk.NewRow();
            for (int b = 0; b <= Item_DBK.Rows.Count - 1; b++)
            {
                dr3["DRAWBACK_SLNO"] = Item_DBK.Rows[b]["DBK_SERIAL_NO"].ToString().Trim();
                dr3["INVOICE_SLNO"] = Item_DBK.Rows[b]["INV_SL_NO"].ToString().Trim();
                dr3["ITEM_SLNO"] = Item_DBK.Rows[b]["INVOICE_ITEM_NO"].ToString().Trim();

                dr3["SCHEME_CODE"] = scheme;

                if (dr3["DRAWBACK_SLNO"] != "")
                {
                    if (scheme != "")
                    {
                        if (scheme_draw == Draw_value)
                        {

                            if (Item_DBK.Rows[b]["DBK_QUANTITY"].ToString() != "")
                            {
                                dr3["DRAWBACK_QTY"] = Item_DBK.Rows[b]["DBK_QUANTITY"].ToString();
                            }
                            else
                            {
                                dr3["DRAWBACK_QTY"] = Item_DBK.Rows[b][4].ToString();
                            }

                            if (Item_DBK.Rows[b]["UOM"].ToString() != "")
                            {
                                dr3["DRAWBACK_UNIT"] = Item_DBK.Rows[b]["UOM"].ToString();
                            }
                            else
                            {
                                dr3["DRAWBACK_UNIT"] = Item_DBK.Rows[b][5].ToString();
                            }
                            //SCHEME_CODE = scheme;
                            //dr2["ITEM_SCHEME_CODE"] = scheme;

                            if (dr3["DRAWBACK_SLNO"] != "")
                            {
                                Auto.Ename = "DRAWBACK_MASTER_ALL";
                                Auto.Enamesearch = dr3["DRAWBACK_SLNO"].ToString();
                                Auto.Notn_No_Search = scheme_draw;
                                ds_draw = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

                                if (ds_draw.Tables[0].Rows.Count > 0)
                                {
                                    dr3["DRAWBACK_NOOFUNITS"] = ds_draw.Tables[0].Rows[0]["DRAWBACK_NOOFUNITS"].ToString();
                                    dr3["DRAWBACK_RATE"] = ds_draw.Tables[0].Rows[0]["DRAWBACK_RATE"].ToString();
                                    dr3["DRAWBACK_CAPS"] = ds_draw.Tables[0].Rows[0]["DRAWBACK_VALUE_CAP"].ToString();
                                    dr3["DRAWBACK_DESC"] = ds_draw.Tables[0].Rows[0]["DRAWBACK_DESCRIPTION"].ToString();
                                }
                                if (scheme_draw == "60" || scheme_draw == "61" || scheme_draw == "62" || scheme_draw == "63" || scheme_draw == "64" || scheme_draw == "65")
                                {
                                    if (ds_draw.Tables[1].Rows.Count > 0)
                                    {
                                        dr3["STATE_LEVEL_ADV_RATE"] = ds_draw.Tables[1].Rows[0]["ROSL_RATE"].ToString();
                                        dr3["STATE_LEVEL_ADV_AMT"] = ds_draw.Tables[1].Rows[0]["ROSL_AMT"].ToString();
                                    }
                                    else
                                    {
                                        dr3["STATE_LEVEL_ADV_RATE"] = "0";
                                        dr3["STATE_LEVEL_ADV_AMT"] = "0";

                                    }
                                }
                            }
                            else
                            {
                                dr3["DRAWBACK_SLNO"] = Item_DBK.Rows[b]["DBK_SERIAL_NO"].ToString().Trim();
                                dr3["DRAWBACK_NOOFUNITS"] = "";

                                dr3["DRAWBACK_RATE"] = "";
                                dr3["DRAWBACK_CAPS"] = "";
                                dr3["DRAWBACK_DESC"] = "";
                                dr3["STATE_LEVEL_ADV_RATE"] = "";
                                dr3["STATE_LEVEL_ADV_AMT"] = "";
                            }
                        }

                        DRAWBACK_ID = Get_general_MAXID("DRAWBACK_MAX_ID");
                        dt_Dbk.Rows.Add(DRAWBACK_ID + b, EXPORT_JOBNO, dr3["INVOICE_SLNO"], dr3["ITEM_SLNO"], dr3["SCHEME_CODE"], dr3["DRAWBACK_SLNO"], dr3["DRAWBACK_QTY"], dr3["DRAWBACK_UNIT"], dr3["DRAWBACK_NOOFUNITS"], dr3["DRAWBACK_RATE"], dr3["DRAWBACK_CAPS"], dr3["DRAWBACK_DESC"],
                                        Connection.Current_User(), dateTime.ToString("dd/MM/yyyy"), "N", Connection.Current_Branch(), "", Connection.WorkingPeriod(), Connection.Current_User(), dateTime.ToString("dd/MM/yyyy"), dr3["STATE_LEVEL_ADV_RATE"], dr3["STATE_LEVEL_ADV_AMT"]);

                    }
                }
            }
        }
        if (dt_Dbk.Rows.Count > 0)
        {
            admin.SqlBulk_Upload_Product("EXPORT_DRAWBACK_DETAILS", dt_Dbk, comp_ConnectionStr);
        }
      
    }

    public void Bind_Sea_Container_Details(DataTable Item_Container, string EXPORT_JOBNO)
    {
        if (hdn_TransportMode.Value == "Sea" || hdn_TransportMode.Value == "Land")
        {
            DataTable dt_CONTAINER = new DataTable();

            #region dt_CONTAINER
            dt_CONTAINER.Columns.Add("ANNEX_SEA_CON_ID");
            dt_CONTAINER.Columns.Add("ANNEX_SEA_CON_JOBNO");
            dt_CONTAINER.Columns.Add("ANNEX_SEA_CON_CONTAINERNO");
            dt_CONTAINER.Columns.Add("ANNEX_SEA_CON_SIZE");
            dt_CONTAINER.Columns.Add("ANNEX_SEA_CON_TYPE");
            dt_CONTAINER.Columns.Add("ANNEX_SEA_CON_EXCISE_SEALNO");
            dt_CONTAINER.Columns.Add("ANNEX_SEA_CON_SEAL_DATE");
            dt_CONTAINER.Columns.Add("USER_ID");
            dt_CONTAINER.Columns.Add("DATE_TIME");
            dt_CONTAINER.Columns.Add("STATUS");
            dt_CONTAINER.Columns.Add("BRANCH_CODE");
            dt_CONTAINER.Columns.Add("YEAR");
            dt_CONTAINER.Columns.Add("WORKING_PERIOD");
            dt_CONTAINER.Columns.Add("MODIFIEDBY");
            dt_CONTAINER.Columns.Add("MODIFIEDON");
            dt_CONTAINER.Columns.Add("ANNEX_SEA_CON_SEALTYPE_INDICATOR");
            dt_CONTAINER.Columns.Add("ANNEX_SEA_CON_SEAL_DEVICEID");
            dt_CONTAINER.Columns.Add("ANNEX_SEA_CON_DOC_TYPE");
            dt_CONTAINER.Columns.Add("ANNEX_SEA_CON_DOC_NUMBER");
            #endregion dt_CONTAINER

            //--------------------AR4 Details--------------------------//
            #region EXPORT_CONTAINER

            for (int b = 0; b <= Item_Container.Rows.Count - 1; b++)
            {
                DataRow dr2 = dt_CONTAINER.NewRow();


                dr2["ANNEX_SEA_CON_CONTAINERNO"] = Item_Container.Rows[b]["Container_No"].ToString();
                dr2["ANNEX_SEA_CON_SIZE"] = Item_Container.Rows[b]["Size"].ToString();
                dr2["ANNEX_SEA_CON_TYPE"] = Item_Container.Rows[b]["Type"].ToString();
                dr2["ANNEX_SEA_CON_EXCISE_SEALNO"] = Item_Container.Rows[b]["SealNo"].ToString();
                dr2["ANNEX_SEA_CON_SEAL_DATE"] = Item_Container.Rows[b]["SealDate"].ToString();
                dr2["ANNEX_SEA_CON_SEALTYPE_INDICATOR"] = Item_Container.Rows[b]["Seal_Type_Indicator"].ToString();
                dr2["ANNEX_SEA_CON_SEAL_DEVICEID"] = Item_Container.Rows[b]["Seal_Device_ID"].ToString();
                dr2["ANNEX_SEA_CON_DOC_TYPE"] = Item_Container.Rows[b]["Movement_DocType"].ToString();
                dr2["ANNEX_SEA_CON_DOC_NUMBER"] = Item_Container.Rows[b]["Movement_DocNo"].ToString();


                CONTAINER_MAX_ID = Get_general_MAXID("CONTAINER_MAX_ID");
                dt_CONTAINER.Rows.Add(CONTAINER_MAX_ID + b, EXPORT_JOBNO, dr2["ANNEX_SEA_CON_CONTAINERNO"], dr2["ANNEX_SEA_CON_SIZE"], dr2["ANNEX_SEA_CON_TYPE"], dr2["ANNEX_SEA_CON_EXCISE_SEALNO"], dr2["ANNEX_SEA_CON_SEAL_DATE"],
                                 Connection.Current_User(), dateTime.ToString("dd/MM/yyyy"), "N", Connection.Current_Branch(), "", Connection.WorkingPeriod(), Connection.Current_User(), dateTime.ToString("dd/MM/yyyy"),
                                 dr2["ANNEX_SEA_CON_SEALTYPE_INDICATOR"], dr2["ANNEX_SEA_CON_SEAL_DEVICEID"], dr2["ANNEX_SEA_CON_DOC_TYPE"], dr2["ANNEX_SEA_CON_DOC_NUMBER"]);
            }
            if (dt_CONTAINER.Rows.Count > 0)
            {
                admin.SqlBulk_Upload_Product("EXPORT_ANNEXURE_C_SEA_CONTAINER", dt_CONTAINER, comp_ConnectionStr);
            }

            #endregion EXPORT_CONTAINER
        }
    }

    public void Bind_PACKAGE_Details(DataTable Item_PACKAGE, string EXPORT_JOBNO)
    {
        DataTable dt_PACK = new DataTable();

        #region dt_PACK
        dt_PACK.Columns.Add("ANNEX_SEA_PACK_ID");
        dt_PACK.Columns.Add("ANNEX_SEA_PACK_JOBNO");
        dt_PACK.Columns.Add("ANNEX_SEA_PACK_GROUP");
        dt_PACK.Columns.Add("ANNEX_SEA_PACK_FROM");
        dt_PACK.Columns.Add("ANNEX_SEA_PACK_TO");
        dt_PACK.Columns.Add("ANNEX_SEA_PACK_PACKAGETYPE");
        dt_PACK.Columns.Add("USER_ID");
        dt_PACK.Columns.Add("DATE_TIME");
        dt_PACK.Columns.Add("STATUS");
        dt_PACK.Columns.Add("BRANCH_CODE");
        dt_PACK.Columns.Add("YEAR");
        dt_PACK.Columns.Add("WORKING_PERIOD");
        dt_PACK.Columns.Add("ANNEX_SEA_PACK_FROMDESC");
        dt_PACK.Columns.Add("ANNEX_SEA_PACK_TODESC");
        dt_PACK.Columns.Add("MODIFIEDBY");
        dt_PACK.Columns.Add("MODIFIEDON");
        #endregion dt_PACK

        //--------------------AR4 Details--------------------------//
        #region EXPORT_PACKAGE

        for (int b = 0; b <= Item_PACKAGE.Rows.Count - 1; b++)
        {
            DataRow dr2 = dt_PACK.NewRow();
            if (Item_PACKAGE.Rows[b]["GROUP"].ToString() != "")
            {
                dr2["ANNEX_SEA_PACK_GROUP"] = Item_PACKAGE.Rows[b]["GROUP"].ToString();
            }
            else
            {
                dr2["ANNEX_SEA_PACK_GROUP"] = "1";
            }
            dr2["ANNEX_SEA_PACK_FROM"] = Item_PACKAGE.Rows[b]["FROM"].ToString();
            dr2["ANNEX_SEA_PACK_TO"] = Item_PACKAGE.Rows[b]["TO"].ToString();
            dr2["ANNEX_SEA_PACK_PACKAGETYPE"] = Item_PACKAGE.Rows[b]["PACKAGE_TYPE"].ToString();
            dr2["ANNEX_SEA_PACK_FROMDESC"] = Item_PACKAGE.Rows[b]["FROM_DESC"].ToString();
            dr2["ANNEX_SEA_PACK_TODESC"] = Item_PACKAGE.Rows[b]["TO_DESC"].ToString();
            
            PACK_ID = Get_general_MAXID("ANNEX_PKGS_ID");
            dt_PACK.Rows.Add(PACK_ID + b, EXPORT_JOBNO, dr2["ANNEX_SEA_PACK_GROUP"], dr2["ANNEX_SEA_PACK_FROM"], dr2["ANNEX_SEA_PACK_TO"], dr2["ANNEX_SEA_PACK_PACKAGETYPE"],
                             Connection.Current_User(), dateTime.ToString("dd/MM/yyyy"), "N", Connection.Current_Branch(), "", Connection.WorkingPeriod(),
                             dr2["ANNEX_SEA_PACK_FROMDESC"],dr2["ANNEX_SEA_PACK_TODESC"], Connection.Current_User(), dateTime.ToString("dd/MM/yyyy"));
                            
        }
        if (dt_PACK.Rows.Count > 0)
        {
            admin.SqlBulk_Upload_Product("EXPORT_ANNEXURE_C_SEA_PACKAGE", dt_PACK, comp_ConnectionStr);
        }

        #endregion EXPORT_PACKAGE
    }

    public void Bind_SUPPORTING_DOCS_Details(DataTable Item_SUPDOC, string EXPORT_JOBNO)
    {
        DataTable dt_SUP_DOC = new DataTable();

        #region dt_SUP_DOC
        dt_SUP_DOC.Columns.Add("SW_ID");
        dt_SUP_DOC.Columns.Add("JOBNO");
        dt_SUP_DOC.Columns.Add("INVOICE_SLNO");
        dt_SUP_DOC.Columns.Add("ITEM_SLNO");
        dt_SUP_DOC.Columns.Add("SLNO");
        dt_SUP_DOC.Columns.Add("UNIQUE_DOC_NUMBER");
        dt_SUP_DOC.Columns.Add("DOC_TYPE_CODE");
        dt_SUP_DOC.Columns.Add("DOC_ISSUING_PARTY_CODE");
        dt_SUP_DOC.Columns.Add("DOC_ISSUING_PARTY_NAME_ADD1");
        dt_SUP_DOC.Columns.Add("DOC_ISSUING_PARTY_NAME_ADD2");
        dt_SUP_DOC.Columns.Add("DOC_ISSUING_PARTY_CITY");
        dt_SUP_DOC.Columns.Add("DOC_ISSUING_PARTY_PIN");
        dt_SUP_DOC.Columns.Add("DOC_REF_NUMBER");
        dt_SUP_DOC.Columns.Add("PLACE_OF_ISSUE");
        dt_SUP_DOC.Columns.Add("DOC_ISSUE_DATE");
        dt_SUP_DOC.Columns.Add("DOC_EXPIRY_DATE");
        dt_SUP_DOC.Columns.Add("BENEFICIARY_PARTY_CODE");
        dt_SUP_DOC.Columns.Add("BENEFICIARY_PARTY_ADDRESS1");
        dt_SUP_DOC.Columns.Add("BENEFICIARY_PARTY_ADDRESS2");
        dt_SUP_DOC.Columns.Add("BENEFICIARY_PARTY_CITY");
        dt_SUP_DOC.Columns.Add("BENEFICIARY_PARTY_PIN");
        dt_SUP_DOC.Columns.Add("FILE_TYPE");
        dt_SUP_DOC.Columns.Add("BRANCH_CODE");
        dt_SUP_DOC.Columns.Add("WORKING_PERIOD");
        dt_SUP_DOC.Columns.Add("CREATEDON");
        dt_SUP_DOC.Columns.Add("CREATEDBY");
        dt_SUP_DOC.Columns.Add("MODIFIEDBY");
        dt_SUP_DOC.Columns.Add("MODIFIEDON");
        dt_SUP_DOC.Columns.Add("DOC_ISSUING_PARTY_NAME");
        dt_SUP_DOC.Columns.Add("BENEFICIARY_PARTY_NAME");
        #endregion dt_SUP_DOC

        //--------------------AR4 Details--------------------------//
        #region EXPORT_dt_SUP_DOC

        for (int b = 0; b <= Item_SUPDOC.Rows.Count - 1; b++)
        {
            DataRow dr2 = dt_SUP_DOC.NewRow();

            dr2["INVOICE_SLNO"] = Item_SUPDOC.Rows[b]["INV_SRNO"].ToString();
            dr2["ITEM_SLNO"] = Item_SUPDOC.Rows[b]["ITM_SRNO"].ToString();
            dr2["UNIQUE_DOC_NUMBER"] = Item_SUPDOC.Rows[b]["IRN_No"].ToString();
            dr2["DOC_TYPE_CODE"] = Item_SUPDOC.Rows[b]["Doc_TypeCode"].ToString();
            dr2["DOC_ISSUING_PARTY_CODE"] = Item_SUPDOC.Rows[b]["Issuing_PartyCode"].ToString();
            dr2["DOC_ISSUING_PARTY_NAME_ADD1"] = Item_SUPDOC.Rows[b]["Issuing_PartyAdd1"].ToString();
            dr2["DOC_ISSUING_PARTY_NAME_ADD2"] = Item_SUPDOC.Rows[b]["Issuing_PartyAdd2"].ToString();
            dr2["DOC_ISSUING_PARTY_CITY"] = Item_SUPDOC.Rows[b]["Issuing_PartyCity"].ToString();
            dr2["DOC_ISSUING_PARTY_PIN"] = Item_SUPDOC.Rows[b]["Issuing_PartyPin"].ToString();
            dr2["DOC_REF_NUMBER"] = Item_SUPDOC.Rows[b]["DRN_No"].ToString();
            dr2["PLACE_OF_ISSUE"] = Item_SUPDOC.Rows[b]["Place_of_Issue"].ToString();
            dr2["DOC_ISSUE_DATE"] = Item_SUPDOC.Rows[b]["Issue_Date"].ToString();
            dr2["DOC_EXPIRY_DATE"] = Item_SUPDOC.Rows[b]["Expiry_Date"].ToString();
            dr2["BENEFICIARY_PARTY_CODE"] = Item_SUPDOC.Rows[b]["Beneficiary_PartyCode"].ToString();
            dr2["BENEFICIARY_PARTY_ADDRESS1"] = Item_SUPDOC.Rows[b]["Beneficiary_PartyAdd1"].ToString();
            dr2["BENEFICIARY_PARTY_ADDRESS2"] = Item_SUPDOC.Rows[b]["Beneficiary_PartyAdd2"].ToString();
            dr2["BENEFICIARY_PARTY_CITY"] = Item_SUPDOC.Rows[b]["Beneficiary_PartyCity"].ToString();
            dr2["BENEFICIARY_PARTY_PIN"] = Item_SUPDOC.Rows[b]["Beneficiary_PartyPin"].ToString();
            dr2["FILE_TYPE"] = Item_SUPDOC.Rows[b]["FileType"].ToString();
            dr2["DOC_ISSUING_PARTY_NAME"] = Item_SUPDOC.Rows[b]["Issuing_PartyName"].ToString();
            dr2["BENEFICIARY_PARTY_NAME"] = Item_SUPDOC.Rows[b]["Beneficiary_PartyName"].ToString();


            SUP_DOC = Get_general_MAXID("EXP_SUPPORTING_DOCS_ID");
            dt_SUP_DOC.Rows.Add(SUP_DOC + b, EXPORT_JOBNO, dr2["INVOICE_SLNO"], dr2["ITEM_SLNO"], b + 1, dr2["UNIQUE_DOC_NUMBER"], dr2["DOC_TYPE_CODE"],
                                dr2["DOC_ISSUING_PARTY_CODE"],dr2["DOC_ISSUING_PARTY_NAME_ADD1"],dr2["DOC_ISSUING_PARTY_NAME_ADD2"],dr2["DOC_ISSUING_PARTY_CITY"],
                                dr2["DOC_ISSUING_PARTY_PIN"],dr2["DOC_REF_NUMBER"],dr2["PLACE_OF_ISSUE"],dr2["DOC_ISSUE_DATE"],dr2["DOC_EXPIRY_DATE"],
                                dr2["BENEFICIARY_PARTY_CODE"],dr2["BENEFICIARY_PARTY_ADDRESS1"],dr2["BENEFICIARY_PARTY_ADDRESS2"],dr2["BENEFICIARY_PARTY_CITY"] , dr2["BENEFICIARY_PARTY_PIN"] , dr2["FILE_TYPE"],
                                Connection.Current_Branch(), Connection.WorkingPeriod(), dateTime.ToString("dd/MM/yyyy"), Connection.Current_User(), Connection.Current_User(), dateTime.ToString("dd/MM/yyyy"), 
                                dr2["DOC_ISSUING_PARTY_NAME"],dr2["BENEFICIARY_PARTY_NAME"]);

        }
        if (dt_SUP_DOC.Rows.Count > 0)
        {
            admin.SqlBulk_Upload_Product("EXP_SW_SUP_DOC", dt_SUP_DOC, comp_ConnectionStr);
        }

        #endregion EXPORT_dt_SUP_DOC
    }

    public void Bind_ANNEXURE_C1_Details(DataTable Item_ANNEX, string EXPORT_JOBNO)
    {
        DataTable dt_ANNEX = new DataTable();

        #region dt_ANNEX
        dt_ANNEX.Columns.Add("ANNEX_ID");
        dt_ANNEX.Columns.Add("ANNEX_JOBNO");
        dt_ANNEX.Columns.Add("ANNEX_EXPORTERNAME");
        dt_ANNEX.Columns.Add("ANNEX_IECCODE");
        dt_ANNEX.Columns.Add("ANNEX_BR_SLNO");
        dt_ANNEX.Columns.Add("ANNEX_EXAM_DATE");
        dt_ANNEX.Columns.Add("ANNEX_EXAM_OFFICER");
        dt_ANNEX.Columns.Add("ANNEX_EXAM_DESIGN");
        dt_ANNEX.Columns.Add("ANNEX_SUPER_NAME");
        dt_ANNEX.Columns.Add("ANNEX_SUPER_DESIGN");
        dt_ANNEX.Columns.Add("ANNEX_COMMISSION_RATE");
        dt_ANNEX.Columns.Add("ANNEX_DIVISION");
        dt_ANNEX.Columns.Add("ANNEX_RANGE");
        dt_ANNEX.Columns.Add("ANNEX_VERIFIED_EXAM_OFFICER");
        dt_ANNEX.Columns.Add("ANNEX_SAMPLE_DRAWN");
        dt_ANNEX.Columns.Add("ANNEX_SEAL_NO");
        dt_ANNEX.Columns.Add("ANNEX_ADDRESS1");
        dt_ANNEX.Columns.Add("ANNEX_ADDRESS2");
        dt_ANNEX.Columns.Add("ANNEX_ADDRESS3");
        dt_ANNEX.Columns.Add("ANNEX_ADDRESS4");
        dt_ANNEX.Columns.Add("USER_ID");
        dt_ANNEX.Columns.Add("DATE_TIME");
        dt_ANNEX.Columns.Add("STATUS");
        dt_ANNEX.Columns.Add("BRANCH_CODE");
        dt_ANNEX.Columns.Add("YEAR");
        dt_ANNEX.Columns.Add("WORKING_PERIOD");
        dt_ANNEX.Columns.Add("MODIFIEDBY");
        dt_ANNEX.Columns.Add("MODIFIEDON");
        #endregion dt_AR4

        //--------------------AR4 Details--------------------------//
        #region EXPORT_ANNEX

        for (int b = 0; b <= Item_ANNEX.Rows.Count - 1; b++)
        {
            DataRow dr2 = dt_ANNEX.NewRow();

            dr2["ANNEX_EXPORTERNAME"] = Item_ANNEX.Rows[b]["Exporter_Name"].ToString();
            dr2["ANNEX_IECCODE"] = Item_ANNEX.Rows[b]["IECCode"].ToString();
            dr2["ANNEX_BR_SLNO"] = Item_ANNEX.Rows[b]["BRANCH_SR_NO"].ToString();
            dr2["ANNEX_EXAM_DATE"] = Item_ANNEX.Rows[b]["Examination_Dt"].ToString();
            dr2["ANNEX_EXAM_OFFICER"] = Item_ANNEX.Rows[b]["ExaminationOfficer"].ToString();
            dr2["ANNEX_EXAM_DESIGN"] = Item_ANNEX.Rows[b]["Designation1"].ToString();
            dr2["ANNEX_SUPER_NAME"] = Item_ANNEX.Rows[b]["SupervisingOfficer"].ToString();
            dr2["ANNEX_SUPER_DESIGN"] = Item_ANNEX.Rows[b]["Designation2"].ToString();
            dr2["ANNEX_COMMISSION_RATE"] = Item_ANNEX.Rows[b]["Commissionerate"].ToString();
            dr2["ANNEX_DIVISION"] = Item_ANNEX.Rows[b]["Division"].ToString();
            dr2["ANNEX_RANGE"] = Item_ANNEX.Rows[b]["Range"].ToString();
            //dr2["ANNEX_VERIFIED_EXAM_OFFICER"] = Item_ANNEX.Rows[b]["Verifiedby"].ToString();
            if (Item_ANNEX.Rows[b]["Verifiedby"].ToString() == "Y")
            {
                dr2["ANNEX_VERIFIED_EXAM_OFFICER"] = "Y";
            }
            else
            {
                dr2["ANNEX_VERIFIED_EXAM_OFFICER"] = "N";
            }
            //dr2["ANNEX_SAMPLE_DRAWN"] = Item_ANNEX.Rows[b]["SampleDrawn"].ToString();

            if (Item_ANNEX.Rows[b]["SampleDrawn"].ToString() == "Y")
            {
                dr2["ANNEX_SAMPLE_DRAWN"] = "Y";
            }
            else
            {
                dr2["ANNEX_SAMPLE_DRAWN"] = "N";
            }

            dr2["ANNEX_SEAL_NO"] = Item_ANNEX.Rows[b]["SealNo"].ToString();
            dr2["ANNEX_ADDRESS1"] = Item_ANNEX.Rows[b]["Address1"].ToString();
            dr2["ANNEX_ADDRESS2"] = Item_ANNEX.Rows[b]["Address2"].ToString();
            dr2["ANNEX_ADDRESS3"] = Item_ANNEX.Rows[b]["Address3"].ToString();
            dr2["ANNEX_ADDRESS4"] = Item_ANNEX.Rows[b]["Address4"].ToString();


            ANNEX_ID = Get_general_MAXID("EXP_ANNEXURE_C1_ID");
            dt_ANNEX.Rows.Add(ANNEX_ID + b, EXPORT_JOBNO, dr2["ANNEX_EXPORTERNAME"], dr2["ANNEX_IECCODE"], dr2["ANNEX_BR_SLNO"], dr2["ANNEX_EXAM_DATE"], dr2["ANNEX_EXAM_OFFICER"], dr2["ANNEX_EXAM_DESIGN"],
                                   dr2["ANNEX_SUPER_NAME"], dr2["ANNEX_SUPER_DESIGN"], dr2["ANNEX_COMMISSION_RATE"], dr2["ANNEX_DIVISION"], dr2["ANNEX_RANGE"], dr2["ANNEX_VERIFIED_EXAM_OFFICER"],
                                   dr2["ANNEX_SAMPLE_DRAWN"], dr2["ANNEX_SEAL_NO"], dr2["ANNEX_ADDRESS1"], dr2["ANNEX_ADDRESS2"], dr2["ANNEX_ADDRESS3"], dr2["ANNEX_ADDRESS4"],
                             Connection.Current_User(), dateTime.ToString("dd/MM/yyyy"), "N", Connection.Current_Branch(), "", Connection.WorkingPeriod(), Connection.Current_User(), dateTime.ToString("dd/MM/yyyy"));
                              
        }
        if (dt_ANNEX.Rows.Count > 0)
        {
            admin.SqlBulk_Upload_Product("ANNEXURE_C1_DETAILS", dt_ANNEX, comp_ConnectionStr);
        }

        #endregion EXPORT_ANNEX
    }

    public void Open_Schemecode()
    {
        if (scheme == "00")
        {
            scheme = "00-FREE SHIPPING BILL";
        }
        else if (scheme == "")
        {
            scheme = "00-FREE SHIPPING BILL";

        }
        else if (scheme == "01")
        {
            scheme = "01-ADVANCE LICENSE ACT. USER COND";
            scheme_name[0] = "DEEC";
        }
        else if (scheme == "02")
        {
            scheme = "02-ADVANCE LICENSE INTERM SUPPLIES";
            scheme_name[0] = "DEEC";
        }
        else if (scheme == "03")
        {
            scheme = "03-ADVANCE LICENSE";
            scheme_name[0] = "DEEC";
        }
        else if (scheme == "04")
        {
            scheme = "04-ADVANCE RELEASE ORDER";
            scheme_name[0] = "DEEC";
        }
        else if (scheme == "05")
        {
            scheme = "05-ADVANCE RELEASE DEEMED EXPORT";
            scheme_name[0] = "DEEC";
        }
        else if (scheme == "08")
        {
            scheme = "08-REPLENISHMENT LICENSE";
            scheme_name[0] = "DEEC";
        }
        else if (scheme == "09")
        {
            scheme = "09-DIAMOND IMPREST LICENSE";
            scheme_name[0] = "DEEC";
        }
        else if (scheme == "11")
        {
            scheme = "11-CONCESSIONAL DUTY EPCG";
            scheme_name[0] = "DEEC";
        }
        else if (scheme == "12")
        {
            scheme = "12-ZERO DUTY EPCG SCHEME";
            scheme_name[0] = "DEEC";
        }
        else if (scheme == "17")
        {
            scheme = "17-ADVANCE LICENSE  ANNUAL REQ.";
            scheme_name[0] = "DEEC";
        }
        else if (scheme == "19")
        {
            scheme = "19-DRAWBACK (DBK)";
        }
        else if (scheme == "20")
        {
            scheme = "20-JOBBING (JBG)";
        }
        else if (scheme == "21")
        {
            scheme = "21-EOU/EPZ/SEZ/EHTP/STP";
        }

        else if (scheme == "24-VKUY")
        {
            scheme = "24-VKUY";
        }
        else if (scheme == "25-DFIA")
        {
            scheme = "25-DFIA";
        }
        else if (scheme == "26")
        {
            scheme = "26-DFIA";
        }
        else if (scheme == "27")
        {
            scheme = "27-FMS";
        }
        else if (scheme == "28")
        {
            scheme = "28-FPS";
        }
        else if (scheme == "41")
        {
            scheme = "41-DRAWBACK AND ADVANCE LICENSE";
            scheme_name[0] = "DEEC";
        }

        else if (scheme == "43")
        {
            scheme = "43-DRAWBACK AND ZERO DUTY EPCG";
            scheme_name[0] = "EPCG";
        }
        else if (scheme == "44")
        {
            scheme = "44-DRAWBACK AND CONCESS. EPCG";
            scheme_name[0] = "EPCG";
        }
        else if (scheme == "47")
        {
            scheme = "47-DRAWBACK AND JOBBING";
        }
        else if (scheme == "48")
        {
            scheme = "48-DRAWBACK AND DIAMOND IMP LICENSE";
            scheme_name[0] = "DEEC";
        }
        else if (scheme == "49")
        {
            scheme = "49-DRAWBACK AND EOU/EPZ/SEZ";
        }
        else if (scheme == "50")
        {
            scheme = "50-EPCG AND ADVANCE LICENSE";
            scheme_name[0] = "EPCG";
            scheme_name[1] = "DEEC";
        }
        else if (scheme == "52")
        {
            scheme = "52-EPCG AND JOBBING";
            scheme_name[0] = "EPCG";
        }
        else if (scheme == "53")
        {
            scheme = "53-EPCG AND DIAMOND IMPREST LICENSE";
            scheme_name[0] = "EPCG";
            scheme_name[1] = "DEEC";
        }
        else if (scheme == "54")
        {
            scheme = "54-EPCG AND REPLENISHMENT LICENSE";
            scheme_name[0] = "EPCG";
            scheme_name[1] = "DEEC";
        }
        else if (scheme == "55")
        {
            scheme = "55-EPCG AND POST EXPORT DEPB";
            scheme_name[0] = "EPCG";
        }
        else if (scheme == "59")
        {
            scheme = "59-EPCG, DFIA";
            scheme_name[0] = "EPCG";
        }

        else if (scheme == "60")
        {
            scheme = "60-DRAWBACK AND ROSL";
        }
        else if (scheme == "61")
        {
            scheme = "61-EPCG, DRAWBACK AND ROSL";
        }
        else if (scheme == "62")
        {
            scheme = "62-DRAWBACK AND SPL AA";
        }
        else if (scheme == "63")
        {
            scheme = "63-EPCG,DRAWBACK AND SPL AA";
        }
        else if (scheme == "64")
        {
            scheme = "64-DRAWBACK, SPL AA ( 4.04A) AND ROSL";
        }
        else if (scheme == "65")
        {
            scheme = "65-EPCG, DRAWBACK, SPL AA(4.04A) AND ROSL";
        }

        else if (scheme == "71")
        {
            scheme = "71-EPCG, DRAWBACK AND DEEC";
            scheme_name[0] = "EPCG";
            scheme_name[1] = "DEEC";
        }
        else if (scheme == "73")
        {
            scheme = "73-EPCG, DRAWBACK AND JOBBING";
            scheme_name[0] = "EPCG";
        }
        else if (scheme == "74")
        {
            scheme = "74-EPCG, DRAWBACK AND DIMOND IMPREST";
            scheme_name[0] = "EPCG";
            scheme_name[1] = "DEEC";
        }
        else if (scheme == "79")
        {
            scheme = "79-EPCG, DRAWBACK AND DFIA";
            scheme_name[0] = "EPCG";
            scheme_name[1] = "DFIA";
        }
        else if (scheme == "99")
        {
            scheme = "99-NFEI";
        }
    }
  
    public string Get_JOBID(string EXPORT_JOBNO)
    {
        DataSet d = new DataSet();
        objUBO.IEC_NO = EXPORT_JOBNO;
        objUBO.BRANCH_NO = "";
        objUBO.Ename = "Get_JOBID";
        objUBO.WORKING_PERIOD = Connection.Get_Company_Type();
        d = xl.Bind_Export_General_IEC_No(objUBO);
        if (d.Tables[0].Rows.Count > 0)
        {
            Current_JOBID = d.Tables[0].Rows[0]["JOBID"].ToString();
        }
        return Current_JOBID;
    }

    public int Get_general_MAXID(string Flag)
    {
        objUBO.IEC_NO = "";
        objUBO.BRANCH_NO = "";
        objUBO.Ename = Flag;
        objUBO.WORKING_PERIOD = SELECT_BRANCH;
        ds_IEC = xl.Bind_Export_General_IEC_No(objUBO);
        if (ds_IEC.Tables[0].Rows.Count > 0)
        {
            MAX_ID = Convert.ToInt32(ds_IEC.Tables[0].Rows[0]["MAXID"].ToString());
        }

        return MAX_ID;
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

}