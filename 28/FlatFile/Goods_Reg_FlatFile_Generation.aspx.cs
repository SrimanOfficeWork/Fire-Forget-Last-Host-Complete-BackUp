using System;
using System.Data; // This was added to make CommandType function
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
using System.Net.Mail;
using Microsoft.ApplicationBlocks.Data;
using Microsoft.Reporting.WebForms;

public partial class Transaction_Default2 : ThemeClass
{
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    User_Creation user_Create = new User_Creation();
 
    DataSet ds = new DataSet();

    public int currentrow = 0, Selected_Row = 0, Cell_Row = 0, ColumnIndex = 0;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;

    public string ICEGATE_EMAIL_ID = "", ICEGATE_EMAIL_PWD = "", targetPath = "", IS_Imgbtn="";
    public string EMail_ID = "";

    CheckList CHKLIST = new CheckList();
    Export_FlatFile_Generation FlatFile = new Export_FlatFile_Generation();
    //Customer c = new Customer();
    Date_Time dt = new Date_Time();
    AppSession aps = new AppSession();
    eroyalmaster erm = new eroyalmaster();

    public string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    public string errorFolder = "", logline = "", logFileName = "";
    public string folderName = "/Submission";
    ErrorLogs er = new ErrorLogs();
    public string createfilename = "";
    public char ch = Convert.ToChar(29);
    StreamWriter sw;
    public string Amendment_Type = "";
    public string Amendment_No = "";
    public string Amendment_Date = "";
    public string SRNO = "";
    public int is_Annexure_Mode = 0;
    public string JOBDATE;
   // public string TRANSPORT_MODE;
    public string ITEM_SLNO;
    public string CHA_NO = "", ICEGATE_ID = "", JOBDT_DDMMYY;

    public string COMPANY_ID = "";

    #region General_Details

    # region Public Attributes

    public string GOODS_ID;
    public string GOODS_JOBNO;
    public string GOODS_SB_NO;
    public string GOODS_CUSTOM_HOUSE;
    public string GOODS_SB_DATE;
    public string GOODS_SEAL_TYPE;
    public string GOODS_NATURE_OF_CARGO;
    public string GOODS_GROSS_WEIGHT;
    public string GOODS_NET_WEIGHT;
    public string GOODS_UNIT_MESUR;
    public string GOODS_TOTAL_PACKAGES;
    public string GOODS_MARKS_NOS;
    public string GOODS_MAWB_NO;
    public string GOODS_MAWB_DATE;
    public string GOODS_HAWB_NO;
    public string GOODS_HAWB_DATE;
    public string GOODS_LOOSE_PACKETS;
    public string GOODS_ROTATION_NO;
    public string GOODS_ROTATION_DATE;
    public string GOODS_NO_OF_CONTAINERS;

    //-------new fields-------------

    public string GOODS_TRANSHIPPER_CODE;
    public string GOODS_GATEWAY_PORT;
    public string GOODS_WAREHOUSECODE;
   
    #endregion

    #endregion
   

    #region Packing List


    # region Public Attributes

    public string GOODS_PACK_ID;
    public string GOODS_PACK_JOBNO;
    public string GOODS_PACK_GROUP;
    public string GOODS_PACK_FROM;
    public string GOODS_PACK_TO;
    public string GOODS_PACK_PACKAGETYPE;
    public string GOODS_PACK_MODE;
    public string flag;
    public string USER_ID;
    public string BRANCH_CODE;
    public string YEAR;
    public string WORKING_PERIOD;
    public string Ename;

    public string GOODS_PACK_FROM_DESC;
    public string GOODS_PACK_TO_DESC;

    #endregion

    #endregion

    #region Container

   

    # region Public Attributes

    public string GOODS_SEA_CON_ID;
    public string GOODS_SEA_CON_JOBNO;
    public string GOODS_SEA_CON_CONTAINERNO;
    public string GOODS_SEA_CON_SIZE;
    public string GOODS_SEA_CON_TYPE;
    public string GOODS_SEA_CON_EXCISE_SEALNO;
    public string GOODS_SEA_CON_SEAL_DATE;

    //--------newly added
    public string GOODS_SEA_CON_SEALTYPE_INDICATOR;
    public string GOODS_SEA_CON_SEAL_DEVICEID;
    public string GOODS_SEA_CON_DOC_TYPE;
    public string GOODS_SEA_CON_DOC_NUMBER;
    public string GOODS_SEA_CON_EQMT_TYPE;
    public string GOODS_SEA_CON_EQMT_QTY;
    public string GOODS_SEA_CON_EQMT_QTY_CODE;

    #endregion

    #endregion

    #region Invoice_Details

  

    # region Public Attributes


    public string TERMS;
    public string WHEATHER_UNIT_PRICE;
    public string INVOICE_SLNO;
    public string INVOICE_NO;
    public string INVOICE_DATE;
    public string FREIGHT_CHARGES;
    public string FREIGHT_CURRENCY;
    public string INSURANCE_CHARGES;
    public string INSURANCE_CURRENCY;
    public string INSURANCE_RATE;


    #endregion

    #endregion

    #region AR4_Details
    

    # region Public Attributes

    public string GOODS_AR4_ID;
    public string GOODS_AR4_JOBNO;
    public string GOODS_AR4_NO;
    public string GOODS_AR4_DATE;
    public string GOODS_AR4_COMMISSION_RATE;

    public string GOODS_AR4_DIVISION;
    public string GOODS_AR4_RANGE;
    public string GOODS_AR4_REMARKS;


    #endregion
    #endregion
    #region EOU_Details

    

    # region Public Attributes

    public string GOODS_EOU_ID;
    public string GOODS_EOU_JOBNO;
    public string GOODS_EOU_EXAM_DATE;
    public string GOODS_EOU_EXAM_OFFICER;
    public string GOODS_EOU_EXAM_DESIGN;
    public string GOODS_EOU_SUPER_NAME;
    public string GOODS_EOU_SUPER_DESIGN;
    public string GOODS_EOU_COMMISSION_RATE;
    public string GOODS_EOU_DIVISION;
    public string GOODS_EOU_DRAWN;
    public string GOODS_EOU_RANGE;
    public string GOODS_EOU_SEAL_NO;
    public string GOODS_EOU_DECLARED_VALUE_VERI;


    #endregion
    #endregion

    #region DOCUMENT

    public string GOODS_DOCS_SERIAL_NO;
    public string GOODS_DOCS_NAME;

    #endregion DOCUMENT

    #region DOCUMENT

    public string GOODS_SEA_CON_EQMT_SERIAL_NO;
    public string GOODS_SEA_CON_EQMT_ID;
    public string GOODS_SEA_CON_EQMT_LOC;
    public string GOODS_SEA_CON_PCKG_FROM;
    public string GOODS_SEA_CON_PCKG_TO;
    public string GOODS_SEA_CON_PCKG_COUNT;
    public string GOODS_SEA_CON_PCKG_UQC;

    #endregion DOCUMENT



    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession_Subfolder();
            currentuser = Session["currentuser"].ToString();
            currentbranch = Session["currentbranch"].ToString();
            //currentcomp_name = Session["currentcomp_name"].ToString();
            //comp_ConnectionStr = Session["currentcomp_db"].ToString();

            Working_Period = Session["WorkingPeriod"].ToString();
            LoginDate = Session["LoginDate"].ToString();
            hdn_CompanyID.Value = Session["COMPANY_ID"].ToString();
          
        SELECT_BRANCH = Connection.Get_Company_Type();

            //mainmastopusernametxt.InnerText = "Welcome Mr." + currentuser;
            CHA_NO = HttpContext.Current.Session["CHA_NO"].ToString();
            ICEGATE_ID = HttpContext.Current.Session["ICEGATE_ID"].ToString();
            //txt_icegate_Id.Text = ICEGATE_ID;
            ICEGATE_EMAIL_ID = HttpContext.Current.Session["ICEGATE_EMAIL_ID"].ToString();
            ICEGATE_EMAIL_PWD = HttpContext.Current.Session["ICEGATE_EMAIL_PWD"].ToString();


            errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/");

            COMPANY_ID = Session["COMPANY_ID"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                targetPath = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + "GoodsRegistration/");
            }
            else if (SELECT_TYPE == "Areawise Job")
            {
                targetPath = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["GroupName"].ToString() + "/" + "GoodsRegistration/");
            }

            else
            {
                targetPath = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + "GoodsRegistration/");
            }


            if (!IsPostBack)
            {
                txt_icegate_Id.Text = ICEGATE_ID;
                if (Directory.Exists(errorFolder) == false)
                {
                    Directory.CreateDirectory(errorFolder);
                }  
              
                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 12;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//
          
                ddlJobNo.Attributes.Add("onchange", "javascript:CallServerside_Importer('" + ddlJobNo.ClientID + "', '" + txtCustomHouse.ClientID + "')");
                if (!string.IsNullOrEmpty(Request["jobno"]))
                {

                    System.Web.UI.HtmlControls.HtmlGenericControl currdiv = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("sidebar");
                    currdiv.Style.Add("display", "none");

                    System.Web.UI.HtmlControls.HtmlGenericControl currdiv1 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("innerbox_Main_Top_User");
                    currdiv1.Style.Add("display", "none");

                    System.Web.UI.HtmlControls.HtmlGenericControl currdiv2 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("maincontent");
                    currdiv2.Style.Add("margin", "-16px 2px 0 0");
                    currdiv2.Style.Add("padding", "2px 0 0");

                    /*ddlJobNo.Items.Clear();
                    ddlJobNo.Items.Add(Request["jobno"].ToString());
                    //ddlJobNo.Items.Remove("0");
                    //ddlJobNo.Items.Insert(0, "Select");
                    */
                    ddlJobNo.Items.Clear();
                    ddlJobNo.Items.Insert(0, new ListItem(Request["jobnops"].ToString(), Request["jobno"].ToString()));
                    ddlJobNo.SelectedIndex = 0;

                }
                else
                {
                    FlatFile.JOBNo = "";
                    FlatFile.Ename = "select_jobno";
                    FlatFile.Workingperiod = SELECT_BRANCH;
                    ddlJobNo.DataSource = FlatFile.Retrieve_Export_All_Details();
                    ddlJobNo.DataValueField = "JOBNO";
                    ddlJobNo.DataTextField = "JOBNO_PS";
                    ddlJobNo.DataBind();
                    ddlJobNo.Items.Remove("0");
                    ddlJobNo.Items.Insert(0, "Select");
                }
                txtCustomHouse.Attributes.Add("readonly", "readonly");
                txtExporterName.Attributes.Add("readonly", "readonly");
                txtScheme.Attributes.Add("readonly", "readonly");
                txtConsignee.Attributes.Add("readonly", "readonly");
                txtNoofItems.Attributes.Add("readonly", "readonly");
                txtNoofInvoices.Attributes.Add("readonly", "readonly");
                txtJobdate.Attributes.Add("readonly", "readonly");
                

            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
    }

    public void Page_Rights(int i)
    {
        user_Create.RetrieveAll_User_Screen_Rights_Details(i);
        PAGE_WRITE = user_Create.PAGE_WRITE;
        PAGE_READ = user_Create.PAGE_READ;
        PAGE_MODIFY = user_Create.PAGE_MODIFY;
        PAGE_DELETE = user_Create.PAGE_DELETE;

        //---------------READ ONLY------------------//

        if (PAGE_READ == "False")
        {
            btnSearch.Enabled = false;
            btnsend_Queue.Enabled = false;
            imgbtnFlatFile.Enabled = false;

            btnSearch.ToolTip = "You don't have permission to access";
            btnsend_Queue.ToolTip = "You don't have permission to access";
            imgbtnFlatFile.ToolTip = "You don't have permission to access";
        }
        else
        {
            btnSearch.Enabled = true;
            btnsend_Queue.Enabled = true;
            imgbtnFlatFile.Enabled = true;

        }
    }
   
    

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //FlatFile.Get_AllDetails(ddlJobNo.SelectedValue.ToString());

        try
        {
            
            imgbtnFlatFile.Visible = false;
            btnsend_Queue.Visible = false;
            DirectoryInfo dir;
            if (File.Exists(errorFolder + logFileName))
            {
                  dir = new DirectoryInfo(errorFolder);
            }

            else
            {                
                  dir = new DirectoryInfo(errorFolder);
            }
            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            Flat_File("GenerateButton");

            imgbtnFlatFile.Visible = true;
            btnsend_Queue.Visible = true;
            
        }
            
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void imgbtnFlatFile_Click(object sender, ImageClickEventArgs e)
    {


        try
        {
            IS_Imgbtn = "1";
          
            imgbtnFlatFile.Visible = false;
            
            btnsend_Queue.Visible = false;

            if (File.Exists(errorFolder + logFileName))
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                Flat_File("ImageButton");
                imgbtnFlatFile.Visible = true;                
                btnsend_Queue.Visible = true;
            }

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }



    public void Flat_File(string process)
    {
        FlatFile.JOBNo = ddlJobNo.SelectedValue.ToString();
        FlatFile.TRANSPORT_MODE = hdn_TransportMode.Value;
        FlatFile.Ename = "Export_Goods_Registration_FlatFile";
        FlatFile.Workingperiod = SELECT_BRANCH;
        ds = FlatFile.Retrieve_Export_All_Details();

        logFileName = ddlJobNo.SelectedValue.ToString() + ".gr";
        createfilename = logFileName;
        Session["createflename"] = logFileName;
        
        //delete the exisitng file 
        if (File.Exists(errorFolder + logFileName))
        {
            File.Delete((errorFolder + logFileName));
        }

        //

        sw = new StreamWriter(errorFolder + logFileName, true);
        DateTime date = System.DateTime.Now;
        string datestringg = string.Format("{0:yyyyMMdd}", date);

        DateTime tt = System.DateTime.Now;

        string time = string.Format("{0:hhmm}", tt);
        if (ds.Tables[7].Rows.Count > 0)
        {
            JOBDATE = ds.Tables[7].Rows[0]["JOBDATE"].ToString().Replace("19000101", "");
            JOBDT_DDMMYY = ds.Tables[7].Rows[0]["JOBDT_DDMMYY"].ToString().Replace("010100", "");

        }
        sw.WriteLine("HREC" + ch + "ZZ" + ch + txt_icegate_Id.Text + ch + "ZZ" + ch + txtCustomHouse.Text + ch + "ICES1_5" + ch + "P" + ch + ch + "CACHE05" + ch + ddlJobNo.SelectedValue.ToString() + JOBDT_DDMMYY + ch + JOBDATE + ch + time);
        
        sw.WriteLine("<SB_GOODS_REG>");                   
      
        if (ds.Tables[0].Rows.Count > 0)
        {

                GOODS_SB_NO = ds.Tables[0].Rows[0]["GOODS_SB_NO"].ToString();
                GOODS_SB_DATE = ds.Tables[0].Rows[0]["GOODS_SB_DATE"].ToString().Replace("19000101", "");
                GOODS_SEAL_TYPE = ds.Tables[0].Rows[0]["GOODS_SEAL_TYPE"].ToString();
                GOODS_NATURE_OF_CARGO = ds.Tables[0].Rows[0]["GOODS_NATURE_OF_CARGO"].ToString().Trim();
                GOODS_GROSS_WEIGHT = ds.Tables[0].Rows[0]["GOODS_GROSS_WEIGHT"].ToString();
                GOODS_NET_WEIGHT = ds.Tables[0].Rows[0]["GOODS_NET_WEIGHT"].ToString();
                GOODS_UNIT_MESUR = ds.Tables[0].Rows[0]["GOODS_UNIT_MESUR"].ToString();
                GOODS_TOTAL_PACKAGES = ds.Tables[0].Rows[0]["GOODS_TOTAL_PACKAGES"].ToString();
                GOODS_MARKS_NOS = ds.Tables[0].Rows[0]["GOODS_MARKS_NOS"].ToString();

                if (hdn_TransportMode.Value == "Sea")
                {
                    GOODS_LOOSE_PACKETS = ds.Tables[0].Rows[0]["GOODS_LOOSE_PACKETS"].ToString();
                    GOODS_NO_OF_CONTAINERS = ds.Tables[0].Rows[0]["GOODS_NO_OF_CONTAINERS"].ToString();

                    GOODS_ROTATION_NO = ds.Tables[0].Rows[0]["GOODS_ROTATION_NO"].ToString();
                    GOODS_ROTATION_DATE = ds.Tables[0].Rows[0]["GOODS_ROTATION_DATE"].ToString().Replace("19000101", "");

                    if (GOODS_NO_OF_CONTAINERS == "")
                    {
                        GOODS_NO_OF_CONTAINERS = "0";
                    }
                }
                else
                {
                    GOODS_LOOSE_PACKETS = "";
                    GOODS_NO_OF_CONTAINERS = "";
                    GOODS_ROTATION_NO = "";
                    GOODS_ROTATION_DATE = "";
                }

                //if (hdn_TransportMode.Value == "Air")
                //{
                    GOODS_MAWB_NO = ds.Tables[0].Rows[0]["GOODS_MAWB_NO"].ToString();
                    GOODS_MAWB_DATE = ds.Tables[0].Rows[0]["GOODS_MAWB_DATE"].ToString().Replace("19000101", "");
                    GOODS_HAWB_NO = ds.Tables[0].Rows[0]["GOODS_HAWB_NO"].ToString();
                    GOODS_HAWB_DATE = ds.Tables[0].Rows[0]["GOODS_HAWB_DATE"].ToString().Replace("19000101", "");
                //}
                //else
                //{
                //    GOODS_MAWB_NO = "";
                //    GOODS_MAWB_DATE = "";
                //    GOODS_HAWB_NO = "";
                //    GOODS_HAWB_DATE = "";
                //}

                //--------------NEW FIELDS----
                GOODS_TRANSHIPPER_CODE = ds.Tables[0].Rows[0]["GOODS_TRANSHIPPER_CODE"].ToString();
                GOODS_GATEWAY_PORT = ds.Tables[0].Rows[0]["GOODS_GATEWAY_PORT"].ToString();
                GOODS_WAREHOUSECODE = ds.Tables[0].Rows[0]["GOODS_WAREHOUSECODE"].ToString();

                sw.WriteLine("<MASTER>");

                //------------- hide by Chithra on 13/07/2020 - New Implementation
                //sw.WriteLine("F" + ch + txtCustomHouse.Text + ch + GOODS_SB_NO + ch + GOODS_SB_DATE + ch + GOODS_SEAL_TYPE + ch + GOODS_NATURE_OF_CARGO + ch + GOODS_GROSS_WEIGHT + ch + GOODS_NET_WEIGHT + ch + GOODS_UNIT_MESUR + ch + GOODS_TOTAL_PACKAGES + ch + GOODS_MARKS_NOS + ch + GOODS_LOOSE_PACKETS + ch + GOODS_NO_OF_CONTAINERS + ch + GOODS_MAWB_NO + ch + GOODS_MAWB_DATE + ch + GOODS_HAWB_NO + ch + GOODS_HAWB_DATE );
                sw.WriteLine("F" + ch + txtCustomHouse.Text + ch + GOODS_SB_NO + ch + GOODS_SB_DATE + ch + GOODS_SEAL_TYPE + ch + GOODS_NATURE_OF_CARGO + ch + GOODS_GROSS_WEIGHT + ch + GOODS_NET_WEIGHT + ch + GOODS_UNIT_MESUR + ch + GOODS_TOTAL_PACKAGES + ch + GOODS_MARKS_NOS + ch + GOODS_LOOSE_PACKETS + ch + GOODS_NO_OF_CONTAINERS + ch + GOODS_MAWB_NO + ch + GOODS_MAWB_DATE + ch + GOODS_HAWB_NO + ch + GOODS_HAWB_DATE + ch + GOODS_TRANSHIPPER_CODE + ch + GOODS_GATEWAY_PORT + ch + GOODS_WAREHOUSECODE);
                sw.WriteLine("<END-MASTER>");                
           
        }

        int i = 0;
        if (ds.Tables[1].Rows.Count > 0)
        {
            sw.WriteLine("<INVOICE>");
            while (ds.Tables[1].Rows.Count > i)
            {
                INVOICE_SLNO = ds.Tables[1].Rows[i]["INVOICE_SLNO"].ToString();
                INVOICE_NO = ds.Tables[1].Rows[i]["INVOICE_NO"].ToString();
                INVOICE_DATE = ds.Tables[1].Rows[i]["INVOICE_DATE"].ToString().Replace("19000101", "");               
                TERMS = ds.Tables[1].Rows[i]["TERMS"].ToString();                           
                FREIGHT_CHARGES = ds.Tables[1].Rows[i]["FREIGHT_CHARGES"].ToString();
                FREIGHT_CURRENCY = ds.Tables[1].Rows[i]["FREIGHT_CURRENCY"].ToString();
                INSURANCE_RATE = ds.Tables[1].Rows[i]["INSURANCE_RATE"].ToString();
                INSURANCE_CHARGES = ds.Tables[1].Rows[i]["INSURANCE_CHARGES"].ToString();
                INSURANCE_CURRENCY = ds.Tables[1].Rows[i]["INSURANCE_CURRENCY"].ToString();
                WHEATHER_UNIT_PRICE = ds.Tables[1].Rows[i]["WHEATHER_UNIT_PRICE"].ToString();

                sw.WriteLine("F" + ch + txtCustomHouse.Text + ch + GOODS_SB_NO + ch + GOODS_SB_DATE + ch + INVOICE_SLNO + ch + TERMS + ch + FREIGHT_CURRENCY + ch + FREIGHT_CHARGES + ch + INSURANCE_RATE + ch + INSURANCE_CURRENCY + ch + INSURANCE_CHARGES + ch + WHEATHER_UNIT_PRICE );
                i++;
            }
            sw.WriteLine("<END-INVOICE>");
            
        }

        int j = 0;
        if (ds.Tables[2].Rows.Count > 0)
        {
            sw.WriteLine("<PACKINGLIST>");
            while (ds.Tables[2].Rows.Count > j)
            {
                GOODS_PACK_FROM = ds.Tables[2].Rows[j]["GOODS_PACK_FROM"].ToString();
                GOODS_PACK_TO = ds.Tables[2].Rows[j]["GOODS_PACK_TO"].ToString();
                GOODS_PACK_PACKAGETYPE = ds.Tables[2].Rows[j]["GOODS_PACK_PACKAGETYPE"].ToString();

                GOODS_PACK_FROM_DESC = ds.Tables[2].Rows[j]["GOODS_PACK_FROM_DESC"].ToString();
                GOODS_PACK_TO_DESC = ds.Tables[2].Rows[j]["GOODS_PACK_TO_DESC"].ToString();

                if (COMPANY_ID == "146" || COMPANY_ID=="5")
                {
                    GOODS_PACK_FROM = GOODS_PACK_FROM_DESC;
                    GOODS_PACK_TO = GOODS_PACK_TO_DESC;
                }  

                sw.WriteLine("F" + ch + txtCustomHouse.Text + ch + GOODS_SB_NO + ch + GOODS_SB_DATE + ch + GOODS_PACK_FROM + ch + GOODS_PACK_TO + ch + GOODS_PACK_PACKAGETYPE );

                j++;
            }
            sw.WriteLine("<END-PACKINGLIST>");
        }

        int k = 0;
        if (ds.Tables[3].Rows.Count > 0)
        {
            sw.WriteLine("<CONTAINER>");
            while (ds.Tables[3].Rows.Count > k)
            {
                GOODS_SEA_CON_CONTAINERNO = ds.Tables[3].Rows[k]["GOODS_SEA_CON_CONTAINERNO"].ToString();
                GOODS_SEA_CON_SIZE = ds.Tables[3].Rows[k]["GOODS_SEA_CON_SIZE"].ToString();

                GOODS_SEA_CON_EXCISE_SEALNO = ds.Tables[3].Rows[k]["GOODS_SEA_CON_EXCISE_SEALNO"].ToString();
                GOODS_SEA_CON_SEAL_DATE = ds.Tables[3].Rows[k]["GOODS_SEA_CON_SEAL_DATE"].ToString().Replace("19000101", "");

                GOODS_SEA_CON_SEALTYPE_INDICATOR = ds.Tables[3].Rows[k]["GOODS_SEA_CON_SEALTYPE_INDICATOR"].ToString();
                GOODS_SEA_CON_SEAL_DEVICEID = ds.Tables[3].Rows[k]["GOODS_SEA_CON_SEAL_DEVICEID"].ToString();
                GOODS_SEA_CON_DOC_TYPE = ds.Tables[3].Rows[k]["GOODS_SEA_CON_DOC_TYPE"].ToString();
                GOODS_SEA_CON_DOC_NUMBER = ds.Tables[3].Rows[k]["GOODS_SEA_CON_DOC_NUMBER"].ToString();
                GOODS_SEA_CON_EQMT_TYPE = ds.Tables[3].Rows[k]["GOODS_SEA_CON_EQMT_TYPE"].ToString();
                GOODS_SEA_CON_EQMT_QTY = ds.Tables[3].Rows[k]["GOODS_SEA_CON_EQMT_QTY"].ToString();
                GOODS_SEA_CON_EQMT_QTY_CODE = ds.Tables[3].Rows[k]["GOODS_SEA_CON_EQMT_QTY_CODE"].ToString();

                //------------- hide by Chithra on 13/07/2020 - New Implementation
               // sw.WriteLine("F" + ch + txtCustomHouse.Text + ch + GOODS_SB_NO + ch + GOODS_SB_DATE + ch + GOODS_SEA_CON_CONTAINERNO + ch + GOODS_SEA_CON_SIZE + ch + GOODS_SEA_CON_EXCISE_SEALNO + ch + GOODS_SEA_CON_SEAL_DATE);
                sw.WriteLine("F" + ch + txtCustomHouse.Text + ch + GOODS_SB_NO + ch + GOODS_SB_DATE + ch + GOODS_SEA_CON_CONTAINERNO + ch + GOODS_SEA_CON_SIZE + ch + GOODS_SEA_CON_EXCISE_SEALNO + ch + GOODS_SEA_CON_SEAL_DATE + ch + GOODS_SEA_CON_SEALTYPE_INDICATOR + ch + GOODS_SEA_CON_SEAL_DEVICEID + ch + GOODS_SEA_CON_DOC_TYPE + ch + GOODS_SEA_CON_DOC_NUMBER + ch + GOODS_SEA_CON_EQMT_TYPE + ch + GOODS_SEA_CON_EQMT_QTY + ch + GOODS_SEA_CON_EQMT_QTY_CODE);

                k++;
            }
            sw.WriteLine("<END-CONTAINER>");
        }


        if (ds.Tables[4].Rows.Count > 0)
        {
                GOODS_EOU_EXAM_DATE = ds.Tables[4].Rows[0]["GOODS_EOU_EXAM_DATE"].ToString().Replace("19000101", "");
                GOODS_EOU_EXAM_OFFICER = ds.Tables[4].Rows[0]["GOODS_EOU_EXAM_OFFICER"].ToString();
                GOODS_EOU_EXAM_DESIGN = ds.Tables[4].Rows[0]["GOODS_EOU_EXAM_DESIGN"].ToString();
                GOODS_EOU_SUPER_NAME = ds.Tables[4].Rows[0]["GOODS_EOU_SUPER_NAME"].ToString();
                GOODS_EOU_SUPER_DESIGN = ds.Tables[4].Rows[0]["GOODS_EOU_SUPER_DESIGN"].ToString();
                GOODS_EOU_COMMISSION_RATE = ds.Tables[4].Rows[0]["GOODS_EOU_COMMISSION_RATE"].ToString();
                GOODS_EOU_DIVISION = ds.Tables[4].Rows[0]["GOODS_EOU_DIVISION"].ToString();
                GOODS_EOU_DRAWN = ds.Tables[4].Rows[0]["GOODS_EOU_DRAWN"].ToString();
                GOODS_EOU_RANGE = ds.Tables[4].Rows[0]["GOODS_EOU_RANGE"].ToString();         
                GOODS_EOU_SEAL_NO = ds.Tables[4].Rows[0]["GOODS_EOU_SEAL_NO"].ToString();
                GOODS_EOU_DECLARED_VALUE_VERI = ds.Tables[4].Rows[0]["GOODS_EOU_DECLARED_VALUE_VERI"].ToString();                             

                sw.WriteLine("<SEAL>");

                sw.WriteLine("F" + ch + txtCustomHouse.Text + ch + GOODS_SB_NO + ch + GOODS_SB_DATE + ch + GOODS_EOU_EXAM_DATE + ch + GOODS_EOU_EXAM_OFFICER + ch + GOODS_EOU_EXAM_DESIGN + ch + GOODS_EOU_SUPER_NAME + ch + GOODS_EOU_SUPER_DESIGN + ch + GOODS_EOU_COMMISSION_RATE + ch + GOODS_EOU_DIVISION + ch + GOODS_EOU_RANGE + ch + GOODS_EOU_SEAL_NO + ch + GOODS_EOU_DECLARED_VALUE_VERI + ch + GOODS_EOU_DRAWN);

                sw.WriteLine("<END-SEAL>");
        }
        //if (ds.Tables[5].Rows.Count > 0)
        //{
        //    GOODS_AR4_NO = ds.Tables[5].Rows[0]["GOODS_AR4_NO"].ToString();
        //    GOODS_AR4_DATE = ds.Tables[5].Rows[0]["GOODS_AR4_DATE"].ToString().Replace("19000101", "");
        //    GOODS_AR4_COMMISSION_RATE = ds.Tables[5].Rows[0]["GOODS_AR4_COMMISSION_RATE"].ToString();
        //    GOODS_AR4_DIVISION = ds.Tables[5].Rows[0]["GOODS_AR4_DIVISION"].ToString();
        //    GOODS_AR4_RANGE = ds.Tables[5].Rows[0]["GOODS_AR4_RANGE"].ToString();
        //    GOODS_AR4_REMARKS = ds.Tables[5].Rows[0]["GOODS_AR4_REMARKS"].ToString();

        //    if (ds.Tables[6].Rows.Count > 0)
        //    {
        //        INVOICE_SLNO = ds.Tables[6].Rows[0]["INVOICE_SLNO"].ToString();
        //        ITEM_SLNO = ds.Tables[6].Rows[0]["ITEM_SLNO"].ToString();
        //    }

        //    sw.WriteLine("<AR4>");

        //    sw.WriteLine("F" + ch + txtCustomHouse.Text + ch + GOODS_SB_NO + ch + GOODS_SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + GOODS_AR4_NO + ch + GOODS_AR4_DATE + ch + GOODS_AR4_COMMISSION_RATE + ch + GOODS_AR4_DIVISION + ch + GOODS_AR4_RANGE + ch + GOODS_AR4_REMARKS);

        //    sw.WriteLine("<END-AR4>");
        //}
        //--------------------------------------------------job based AR4 details---------------------------------------//
        int a = 0;
        if (ds.Tables[5].Rows.Count > 0)
        {
            sw.WriteLine("<AR4>"); 
            while (ds.Tables[5].Rows.Count > a)
            {
                INVOICE_SLNO = "1";//set default as Invoice No 1

                ITEM_SLNO = dt.Trim(ds.Tables[5].Rows[a]["AR4_ITEM_NO"].ToString());
                //ITEM_SLNO = "1";
                //ITEM_SLNO = dt.Trim(ds.Tables[5].Rows[a]["AR4_ID"].ToString());

                GOODS_AR4_NO = ds.Tables[5].Rows[a]["AR4_NO"].ToString();
                GOODS_AR4_DATE = ds.Tables[5].Rows[a]["AR4_DATE"].ToString().Replace("19000101", "");
                GOODS_AR4_COMMISSION_RATE = ds.Tables[5].Rows[a]["AR4_COMMISSION_RATE"].ToString();
                GOODS_AR4_DIVISION = ds.Tables[5].Rows[a]["AR4_DIVISION"].ToString();
                GOODS_AR4_RANGE = ds.Tables[5].Rows[a]["AR4_RANGE"].ToString();
                GOODS_AR4_REMARKS = ds.Tables[5].Rows[a]["AR4_REMARKS"].ToString();

                if (GOODS_AR4_REMARKS == "")
                {
                    GOODS_AR4_REMARKS = "NIL";
                }

                sw.WriteLine("F" + ch + txtCustomHouse.Text + ch + GOODS_SB_NO + ch + GOODS_SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + GOODS_AR4_NO + ch + GOODS_AR4_DATE + ch + GOODS_AR4_COMMISSION_RATE + ch + GOODS_AR4_DIVISION + ch + GOODS_AR4_RANGE + ch + GOODS_AR4_REMARKS);

                
                a++;
            }
            sw.WriteLine("<END-AR4>");
        }
        //--------------------------------------------------job based AR4 details---------------------------------------//


        //--------------------------------------------------ROTATION details---------------------------------------//
        if (GOODS_ROTATION_NO != "")
        {
            sw.WriteLine("<ROTATION>");

            sw.WriteLine("F" + ch + txtCustomHouse.Text + ch + GOODS_SB_NO + ch + GOODS_SB_DATE + ch + GOODS_ROTATION_NO + ch + GOODS_ROTATION_DATE);

            sw.WriteLine("<END-ROTATION>");
        }

       
        //--------------------------------------------------DOCUMENT details---------------------------------------//
        int d = 0;
        if (ds.Tables[8].Rows.Count > 0)
        {
            sw.WriteLine("<DOCUMENT>");
            while (ds.Tables[8].Rows.Count > d)
            {
                GOODS_DOCS_SERIAL_NO= ds.Tables[8].Rows[d]["GOODS_DOCS_SERIAL_NO"].ToString();
                GOODS_DOCS_NAME = ds.Tables[8].Rows[d]["GOODS_DOCS_NAME"].ToString();

                sw.WriteLine("F" + ch + txtCustomHouse.Text + ch + GOODS_SB_NO + ch + GOODS_SB_DATE + ch + GOODS_DOCS_SERIAL_NO + ch + GOODS_DOCS_NAME);
                d++;            
            }
             sw.WriteLine("<END-DOCUMENT>");
        }


        //--------------------------------------------------DOCUMENT details---------------------------------------//
        if (hdn_TransportMode.Value == "Sea")
        {
            d = 0;
            if (ds.Tables[9].Rows.Count > 0)
            {
                sw.WriteLine("<CONTAINER_PACKAGE>");
                while (ds.Tables[9].Rows.Count > d)
                {
                    GOODS_SEA_CON_EQMT_SERIAL_NO = ds.Tables[9].Rows[d]["GOODS_SEA_CON_EQMT_SERIAL_NO"].ToString();
                    GOODS_SEA_CON_EQMT_TYPE = ds.Tables[9].Rows[d]["GOODS_SEA_CON_EQMT_TYPE"].ToString();
                    GOODS_SEA_CON_EQMT_ID = ds.Tables[9].Rows[d]["GOODS_SEA_CON_EQMT_ID"].ToString();
                    GOODS_SEA_CON_EQMT_LOC = ds.Tables[9].Rows[d]["GOODS_SEA_CON_EQMT_LOC"].ToString();
                    GOODS_SEA_CON_PCKG_FROM = ds.Tables[9].Rows[d]["GOODS_SEA_CON_PCKG_FROM"].ToString();
                    GOODS_SEA_CON_PCKG_TO = ds.Tables[9].Rows[d]["GOODS_SEA_CON_PCKG_TO"].ToString();
                    GOODS_SEA_CON_PCKG_COUNT = ds.Tables[9].Rows[d]["GOODS_SEA_CON_PCKG_COUNT"].ToString();
                    GOODS_SEA_CON_PCKG_UQC = ds.Tables[9].Rows[d]["GOODS_SEA_CON_PCKG_UQC"].ToString();


                    sw.WriteLine("F" + ch + txtCustomHouse.Text + ch + GOODS_SB_NO + ch + GOODS_SB_DATE + ch + GOODS_SEA_CON_EQMT_SERIAL_NO + ch + GOODS_SEA_CON_EQMT_TYPE + ch + GOODS_SEA_CON_EQMT_ID + ch + GOODS_SEA_CON_EQMT_LOC + ch + GOODS_SEA_CON_PCKG_FROM + ch + GOODS_SEA_CON_PCKG_TO + ch + GOODS_SEA_CON_PCKG_COUNT + ch + GOODS_SEA_CON_PCKG_UQC);
                    d++;
                }
                sw.WriteLine("<END-CONTAINER_PACKAGE>");
            }
        }
        //--------------------------------------------------DOCUMENT details--END-------------------------------------//


        sw.WriteLine("<END-SB_GOODS_REG>");

        //sw.WriteLine("TREC" + ch + ddlJobNo.SelectedValue.ToString() + JOBDATE);
        sw.WriteLine("TREC" + ch + ddlJobNo.SelectedValue.ToString() + JOBDT_DDMMYY);// Modified on 06Sep2014 with subbu sir
        sw.Flush();
        sw.Close();
        sw.Dispose();
        string JOBNO = ddlJobNo.SelectedValue.ToString();
        DataSet dss = new DataSet();
        Job_Histroy jh = new Job_Histroy();
        if (process != "SendQueue")
        {
             
            if (Connection.COMPANYID() == "11" || Connection.COMPANYID() == "5" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "747")
            {
                if (File.Exists(errorFolder + logFileName))
                {
                    DirectoryInfo dir = new DirectoryInfo(errorFolder);

                    if (Directory.Exists(targetPath) == false)
                    {
                        Directory.CreateDirectory(targetPath);
                    }

                    string sourceFile = System.IO.Path.Combine(errorFolder, logFileName);
                    string destFile = System.IO.Path.Combine(targetPath, JOBNO + " ~~" + logFileName);

                    System.IO.File.Copy(sourceFile, destFile, true);

                    jh.JOB_ID = "";
                    jh.JOB_TYPE = "GR";
                    jh.JOBNO = JOBNO;
                    jh.COMPANY_ID = HttpContext.Current.Session["COMPANY_ID"].ToString();
                    jh.DESCRIPTION = targetPath;
                    jh.ATTACHMENT_FILE = JOBNO + " ~~" + logFileName;
                    jh.FLAG = "Upload_File";
                    jh.USER_ID = currentuser;
                    jh.JOBDATE = "01/01/1900";

                    jh.BRANCH_CODE = currentbranch;
                    jh.YEAR = "QueryReply";
                    jh.WORKING_PERIOD = Working_Period;
                    jh.BRANCH_COMMON = SELECT_BRANCH;
                    dss = jh.IMP_EXP_JOB_HISTROY_INSERT_UPDATE();

                }
                else
                {
                    Console.WriteLine("Source path does not exist!");
                }
            }
        }
        else if (process == "SendQueue")
        {
            //DSC_FLATFILE_INSERT_UPDATE

            string SQ_Path = string.Empty;
            string SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();
            if (SELECT_TYPE == "Branchwise Job")
            {
                SQ_Path = Server.MapPath("~/FlatFile_DSC/" + Session["COMPANY_ID"].ToString() + "/" + "GoodsRegistration" + "/"
                    +
                    Session["currentbranch"].ToString().Replace(", ", "_").Replace(",", "_").Replace("(", "_").Replace(")", "_").Replace(" ", "_").Replace("/", "_")
                    + "/");
            }
            else if (SELECT_TYPE == "Areawise Job")
            {
                SQ_Path = Server.MapPath("~/FlatFile_DSC/" + Session["COMPANY_ID"].ToString() + "/" + "GoodsRegistration" + "/"
                    +
                    Session["GroupName"].ToString().Replace(", ", "_").Replace(",", "_").Replace("(", "_").Replace(")", "_").Replace(" ", "_").Replace("/", "_")
                    + "/");
            }

            else
            {
                SQ_Path = Server.MapPath("~/FlatFile_DSC/" + Session["COMPANY_ID"].ToString() + "/" + "GoodsRegistration" + "/");
            }


            if (Directory.Exists(SQ_Path) == false)
            {
                Directory.CreateDirectory(SQ_Path);
            }

            string sourceFile2 = System.IO.Path.Combine(errorFolder, logFileName);

            System.IO.File.Copy(sourceFile2, SQ_Path + logFileName, true);


            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            url = url.Substring(0, url.IndexOf("FlatFile")) + SQ_Path.Substring(SQ_Path.IndexOf("FlatFile_DSC"), SQ_Path.Length - (SQ_Path.IndexOf("FlatFile_DSC"))) + logFileName;
            jh.JOB_ID = url.Replace(@"\", @"/");


            jh.JOB_TYPE = "GR";
            jh.JOBNO = JOBNO;

            jh.COMPANY_ID = HttpContext.Current.Session["COMPANY_ID"].ToString();
            jh.DESCRIPTION = SQ_Path + logFileName;
            jh.ATTACHMENT_FILE = JOBNO + " ~~" + logFileName;
            jh.FLAG = "GR_Insert";
            jh.USER_ID = currentuser;
            jh.JOBDATE = txtJobdate.Text;
            jh.BRANCH_CODE = currentbranch;
            jh.YEAR = "";
            jh.WORKING_PERIOD = Working_Period;
            jh.BRANCH_COMMON = SELECT_BRANCH;
            dss = jh.IMP_EXP_JOB_HISTROY_INSERT_UPDATE();
            if (dss.Tables.Count > 0)
            {
                if (dss.Tables[0].Rows[0][0].ToString() == "1")
                {
                    lblsent_date.Text = dss.Tables[0].Rows[0][1].ToString();
                    Alert_msg("Sent Successfully");
                }
                else
                {
                    lblsent_date.Text = "Failed to Sent";
                    Alert_msg("Failed to Sent");
                }

            }

        }

        if (IS_Imgbtn == "1")
        {
            Response.Write(sw.ToString());
            Response.Flush();
            // Response.End();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
 

    protected void btnsend_Queue_Click(object sender, EventArgs e)
    {
        try
        {

            Flat_File("SendQueue");      

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SUBMISSION', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SUBMISSION', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    [System.Web.Services.WebMethod]
    public static string Get_Import_Details(string custid)
    {
        string Working_Period = "", txtCustomHouse = "",
               txtExporterName = "",
               txtScheme = "",
               txtConsignee = "",
               txtNoofItems = "",
               txtNoofInvoices = "", hdn_TransportMode = "",
               select_branch = "", txtJobdate = "";


        try
        {
            Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
            
    // commented for areawise implementation on 05-mar-2020
        /*
            select_branch = HttpContext.Current.Session["currentbranch"].ToString();
            select_type_ = HttpContext.Current.Session["SELECT_TYPE"].ToString();
            if (select_type_ == "Branchwise Job")
            {
                select_branch = select_branch;
            }
            else
            {
                select_branch = "";
            }
              * */
            select_branch = Connection.Get_Company_Type();

            Export_CheckList CHKLIST = new Export_CheckList();
            CHKLIST.JOBNo = custid;
            CHKLIST.Ename = "select_jobno_CheckList";

            CHKLIST.Workingperiod = select_branch;
            DataSet ds = new DataSet();
            ds = CHKLIST.RetrieveAll_General_Details();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCustomHouse = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                txtExporterName = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                txtConsignee = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                hdn_TransportMode = ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();
                txtJobdate = ds.Tables[0].Rows[0]["JOBDATE1"].ToString();

                if (ds.Tables[1].Rows.Count > 0)
                {
                    txtScheme = ds.Tables[1].Rows[0]["ITEM_SCHEME_CODE"].ToString();
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        txtNoofInvoices = ds.Tables[2].Rows[0]["INVOICE_NO"].ToString() + " INVOICE";

                    }
                    else
                    {
                        txtNoofInvoices = "";
                    }

                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        txtNoofItems = ds.Tables[3].Rows[0]["ITEM_SLNO"].ToString() + " ITEMS";

                    }
                    else
                    {
                        txtNoofItems = "";
                    }
                }
                else
                {
                    txtScheme = "";
                    txtNoofItems = "";
                    txtNoofInvoices = "";
                }

            }
            else
            {
                txtCustomHouse = "";
                txtExporterName = "";
                txtScheme = "";
                txtConsignee = "";
                txtNoofItems = "";
                txtNoofInvoices = "";  txtJobdate = "";

            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
        custid = txtCustomHouse + "~~" + txtExporterName + "~~" + txtScheme + "~~" + txtConsignee + "~~" + txtNoofItems + "~~" + txtNoofInvoices + "~~" + hdn_TransportMode + "~~" + txtJobdate; 

        return custid;
    }
}