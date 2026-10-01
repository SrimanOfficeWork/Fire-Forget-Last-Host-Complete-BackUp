using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.IO;


public class Flatfile_Json_export
{
    private string _JOBNO;
    public string COUNTRY_ORIGIN = null, COUNTRY_SHIPMENT = null, PORT_ORIGIN = null, PORT_SHIPMENT = null, PORT_DISCHARGE = null,
        PORT_FINAL_DEST = null, COUNTRY_DISCHARGE = null, COUNTRY_FINAL_DEST = null, RODTEP = null;
    public string NON_STD_EFFECT_DT_EXP = null;
    public string ANNEX_SEA_SEAL_TYPE = null;
    public string NON_STD_BANKNAME = null;
    public string NO_CONTAINERS = null;
    public string NON_STD_CERTIFICATE_NO = null;
    public string COMMISSION_CURRENCY = null, FOB_CURRENCY = null, PACKMISC_CURRENCY = null, OTHER_DEDUCTION_CURRENCY = null,
        FREIGHT_CURRENCY = null, INSURANCE_CURRENCY = null;
    public string NON_STD_CERTIFICATE_DATE = null;
    public string STATE_OF_EXPORT;
    public string CONSIGNEE_ADD5;
    public string PORT_OF_LOADING;
    public string sealType;
    public string natureOfCargo;
    public string grossWeight;
    public string netWeight;
    public string unitOfMeasurement;
    public string totalNumberOfPackages;
    public string marksNumbers;
    public string numberOfLoosePackets;
    public string numberOfContainers;
    public string mawbnumber;
    public string hawbnumber;
    public DataSet ds = new DataSet();
    Date_Time dt = new Date_Time();
    public string ITEM_EXPORTER_NAME = null;
    public string INVOICE_CURRENCY;
    public string ITEM_EXPORTER_NAME_THIRD = null;
    public string EXPORTER_CLASS = null;
    private string _Ename;
    public string _Inv_Slno;
    public string PMV_VALUE;
    public string NOTIFICATION_NO;
    public string INVOICE_EXRATE;
    public string Standard_Currency;
    public string JOBNo
    {
        get { return _JOBNO; }
        set { _JOBNO = value; }
    }
    public string Ename
    {
        get { return _Ename; }
        set { _Ename = value; }
    }
    public string Inv_Slno
    {
        get { return _Inv_Slno; }
        set { _Inv_Slno = value; }
    }
    public string COMPANY_ID = Connection.COMPANYID();
    public string currentbranch = Connection.Current_Branch();
    public string CHA_NO = Connection.Get_IMP_CHA_NO();


    //public DataSet Get_EXP_ChkList_All_New(string ICEGATE_ID, string logFileName, string errorFolder)
    //{
    //    try
    //    {
    //        SqlParameter[] param = new SqlParameter[10];
    //        param[2] = new SqlParameter("@Jobno", JOBNo);
    //        param[4] = new SqlParameter("@Branch_Common", Connection.Current_Branch());
    //        param[5] = new SqlParameter("@Company_Lic", Connection.COMPANYID());
    //        param[6] = new SqlParameter("@flag", Ename);
    //        ds = Connection.Get_Dataset("EXP_JSON_NEW", param);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            JSON_FOR_EXP(ds, ICEGATE_ID, errorFolder + logFileName);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Connection.Error_Msg(ex.Message);
    //    }
    //    return ds;

    //}



    public DataSet Get_EXP_ChkList_All_New(string ICEGATE_ID, string logFileName, string errorFolder,
                                       string jobNumberOverride, string sequenceOverride)   // ← 2 புது parameter
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[2] = new SqlParameter("@Jobno", JOBNo);
            param[4] = new SqlParameter("@Branch_Common", Connection.Current_Branch());
            param[5] = new SqlParameter("@Company_Lic", Connection.COMPANYID());
            param[6] = new SqlParameter("@flag", Ename);
            ds = Connection.Get_Dataset("EXP_JSON_NEW", param);
            if (ds.Tables[0].Rows.Count > 0)
            {
                JSON_FOR_EXP(ds, ICEGATE_ID, errorFolder + logFileName,
                             jobNumberOverride, sequenceOverride);   // ← pass through
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }










    public static int GenerateSequenceNumber()//old
    {
        long ticks = DateTime.UtcNow.Ticks;
        int seq = (int)(ticks % 10000000);

        if (seq == 0)
            seq = 1;

        return seq;
    }
    public static string GenerateSequenceNumber(string Jobno)//new
    {
        string seq = Convert.ToInt32(Jobno).ToString("D5");
        return seq + DateTime.Now.ToString("yy");
    }
    public string Trim(string str)
    {
        if (str.Contains("."))
        {
            string[] s1 = str.Split(new string[] { "." }, StringSplitOptions.None);
            string num = "123456789";
            if (num.Contains(s1[1].ToString()))
            {

            }
            else
            {
                str.Trim().Replace(".00", "").Replace(".0000", "");

            }

        }

        return str.Trim().Replace("amp;", "").Replace("`", "").Replace("'", "").Replace("&nbsp;", "").Replace("&nbsp;", "");
    }
    public void Get_Admin_Master_Codes()
    {
        DataSet dss = new DataSet();
        Date_Time dt = new Date_Time();
        Export_FlatFile_Generation FlatFile = new Export_FlatFile_Generation();
        Date_Time split = new Date_Time();

        FlatFile.Ename = "IMPORT_SELECT";

        dss = FlatFile.Search_Admin_Master();

        DataView view1 = dss.Tables[0].DefaultView;

        // STATE OF EXPORT
        if (!string.IsNullOrWhiteSpace(STATE_OF_EXPORT))
        {
            view1.RowFilter = "STATE_NAME = '" + split.Split("-", STATE_OF_EXPORT) + "'";
        }

        DataSet dt_UserRights = new DataSet();
        dt_UserRights.Tables.Add(view1.ToTable());

        if (dt_UserRights.Tables[0].Rows.Count > 0)
        {
            STATE_OF_EXPORT = dt.Trim(dt_UserRights.Tables[0].Rows[0]["STATE_CODE"].ToString());
        }

        // CONSIGNEE COUNTRY CODE
        view1 = dss.Tables[1].DefaultView;

        if (!string.IsNullOrWhiteSpace(CONSIGNEE_ADD5))
        {
            view1.RowFilter = "COUNTRY_NAME = '" + split.Split("-", CONSIGNEE_ADD5) + "'";
        }

        DataSet dt_2 = new DataSet();
        dt_2.Tables.Add(view1.ToTable());

        if (dt_2.Tables[0].Rows.Count > 0)
        {
            CONSIGNEE_ADD5 = dt.Trim(dt_2.Tables[0].Rows[0]["COUNTRY_CODE"].ToString());
        }

        // COUNTRY DISCHARGE
        view1 = dss.Tables[1].DefaultView;

        if (!string.IsNullOrWhiteSpace(COUNTRY_DISCHARGE))
        {
            view1.RowFilter = "COUNTRY_NAME = '" + split.Split("-", COUNTRY_DISCHARGE) + "'";
        }

        DataSet dt_1 = new DataSet();
        dt_1.Tables.Add(view1.ToTable());

        if (dt_1.Tables[0].Rows.Count > 0)
        {
            COUNTRY_DISCHARGE = dt.Trim(dt_1.Tables[0].Rows[0]["COUNTRY_CODE"].ToString());
        }

        // COUNTRY FINAL DEST
        view1 = dss.Tables[1].DefaultView;

        if (!string.IsNullOrWhiteSpace(COUNTRY_FINAL_DEST))
        {
            view1.RowFilter = "COUNTRY_NAME = '" + split.Split("-", COUNTRY_FINAL_DEST) + "'";
        }

        DataSet ds1 = new DataSet();
        ds1.Tables.Add(view1.ToTable());

        if (ds1.Tables[0].Rows.Count > 0)
        {
            COUNTRY_FINAL_DEST = dt.Trim(ds1.Tables[0].Rows[0]["COUNTRY_CODE"].ToString());
        }

        // PORT DISCHARGE
        if (!string.IsNullOrWhiteSpace(PORT_DISCHARGE) && PORT_DISCHARGE.Contains("-"))
        {
            PORT_DISCHARGE = split.Split_main("-", PORT_DISCHARGE);
        }

        // PORT FINAL DEST
        if (!string.IsNullOrWhiteSpace(PORT_FINAL_DEST) && PORT_FINAL_DEST.Contains("-"))
        {
            PORT_FINAL_DEST = split.Split_main("-", PORT_FINAL_DEST);
        }

        // PORT OF LOADING
        if (!string.IsNullOrWhiteSpace(PORT_OF_LOADING) && PORT_OF_LOADING.Contains("-"))
        {
            PORT_OF_LOADING = split.Split_main("-", PORT_OF_LOADING);
        }
        if (INVOICE_CURRENCY != null)
        {
            DataView view2 = dss.Tables[3].DefaultView;
            view2.RowFilter = "EXCHANGE_CUR_CODE = '" + INVOICE_CURRENCY + "'";
            DataSet ds8 = new DataSet();
            ds8.Tables.Add(view2.ToTable());

            if (ds8.Tables[0].Rows.Count > 0)
            {
                INVOICE_EXRATE = ds8.Tables[0].Rows[0]["EXCHANGE_RATE_EXPORT"].ToString();
                Standard_Currency = "Y";

            }
        }
    }
    public string GetValue_INV(DataRow row, string columnName)
    {
        if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
        {
            string value = row[columnName].ToString().Trim();

            // If value is 0 or 0.00 or 0.000 etc → return empty
            if (value == "" || value == "0" || value == "0.00")
                return null;

            return value;
        }

        return null;
    }


    //private void JSON_FOR_EXP(DataSet ds, string ICEGATE_ID, string filePath)
    //{
    //    if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
    //        return;




    //    DataRow masterRow = ds.Tables[0].Rows[0];



    //    if (ds.Tables.Count > 1 && ds.Tables[0].Rows.Count > 0)
    //    {
    //        COUNTRY_DISCHARGE = masterRow["COUNTRY_DISCHARGE"].ToString();
    //        COUNTRY_FINAL_DEST = masterRow["COUNTRY_FINAL_DEST"].ToString();
    //        PORT_DISCHARGE = masterRow["PORT_DISCHARGE"].ToString();
    //        PORT_FINAL_DEST = masterRow["PORT_FINAL_DEST"].ToString();
    //        Get_Admin_Master_Codes();
    //    }


    //    RootModelexp root = new RootModelexp();
    //    root.master = new master_Exp();

    //    // ================= HEADER =================

    //    root.headerField = new HeaderField_Exp
    //    {
    //        senderID = ICEGATE_ID,
    //        receiverID = masterRow["CUSTOMS_HOUSE"].ToString(),
    //        indicator = "P",
    //        messageID = "CACHE01",
    //       // sequenceOrControlNumber = GenerateSequenceNumber().ToString(),//hide on 06-06-2026 by Chithra Sugg.by Bala sir
    //        sequenceOrControlNumber = GenerateSequenceNumber(masterRow["JOBNO"].ToString()).ToString(),
    //        jobNumber = GetValue(masterRow, "JOBNO"),
    //        jobDate = GetValue(masterRow, "JOBDATE"),
    //        messageType = "F"
    //    };



    private void JSON_FOR_EXP(DataSet ds, string ICEGATE_ID, string filePath,
                         string jobNumberOverride, string sequenceOverride)   // ← 2 புது parameter
    {
        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            return;
        DataRow masterRow = ds.Tables[0].Rows[0];
        if (ds.Tables.Count > 1 && ds.Tables[0].Rows.Count > 0)
        {
            COUNTRY_DISCHARGE = masterRow["COUNTRY_DISCHARGE"].ToString();
            COUNTRY_FINAL_DEST = masterRow["COUNTRY_FINAL_DEST"].ToString();
            PORT_DISCHARGE = masterRow["PORT_DISCHARGE"].ToString();
            PORT_FINAL_DEST = masterRow["PORT_FINAL_DEST"].ToString();
            Get_Admin_Master_Codes();
        }

        string realJobNo = masterRow["JOBNO"].ToString();

        string jobNumberForJson = !string.IsNullOrEmpty(jobNumberOverride)
            ? jobNumberOverride
            : realJobNo;

        string sequenceForJson = !string.IsNullOrEmpty(sequenceOverride)
            ? sequenceOverride
            : GenerateSequenceNumber(realJobNo).ToString();

        RootModelexp root = new RootModelexp();
        root.master = new master_Exp();
        // ================= HEADER =================
        root.headerField = new HeaderField_Exp
        {
            senderID = ICEGATE_ID,
            receiverID = masterRow["CUSTOMS_HOUSE"].ToString(),
            indicator = "P",
            messageID = "CACHE01",
            sequenceOrControlNumber = sequenceForJson,
            jobNumber = jobNumberForJson,
            jobDate = GetValue(masterRow, "JOBDATE"),
            messageType = "F"          // ← "F" தப்பு, JSON ஆனதால "J" ஆ மாத்தினேன் (Import-லயும் இதே fix பண்ணது)
        };





        // ================= AR4 MODEL =================

        root.master.ar4Model = new List<AR4Model>();

        if (ds.Tables.Count > 6 && ds.Tables[6].Rows.Count > 0)
        {
            foreach (DataRow ar4 in ds.Tables[6].Rows)
            {
                AR4Model model = new AR4Model
                {

                    invoiceSerialNumber = GetValue(ar4, "AR4_INVOICE_SLNO"),
                    itemSerialNumberInvoice = GetValue(ar4, "AR4_ITEM_NO"),
                    ar4Number = GetValue(ar4, "AR4_NO"),
                    ar4Date = GetValue(ar4, "AR4_DATE"),
                    commissionerate = GetValue(ar4, "AR4_COMMISSION_RATE"),
                    division = GetValue(ar4, "AR4_DIVISION"),
                    range = GetValue(ar4, "AR4_RANGE"),
                    remarks = GetValue(ar4, "AR4_REMARKS")
                };

                root.master.ar4Model.Add(model);
            }
        }
        // ================= CESS MODEL =================

        root.master.cessModel = new List<CessModel>();

        if (ds.Tables.Count > 12 && ds.Tables[12].Rows.Count > 0)
        {
            foreach (DataRow r in ds.Tables[12].Rows)
            {
                CessModel cess = new CessModel
                {

                    invoiceSerialNumber = GetValue(r, "INVOICE_SLNO"),
                    itemSerialNumberInvoice = GetValue(r, "ITEM_SLNO"),
                    srno = GetValue(r, "CESS_SLNO"),
                    quantity = GetValue(r, "CESS_ITEM_QTY"),
                    itemCessValue = GetValue(r, "CESS_VALUE"),
                    cessActCode = GetValue(r, "CESS_TARIFF_UNIT")
                };

                root.master.cessModel.Add(cess);
            }
        }
        // ================= CONSTITUENT FINAL =================

        root.master.constituentFinal = new List<ConstituentFinal>();

        if (ds.Tables.Count > 16 && ds.Tables[16].Rows.Count > 0)
        {
            foreach (DataRow r in ds.Tables[16].Rows)
            {
                ConstituentFinal model = new ConstituentFinal
                {

                    invoiceSerialNumber = GetValue(r, "INVOICE_SLNO"),
                    itemSerialNumber = GetValue(r, "ITEM_SLNO"),
                    constituentSerialNo = GetValue(r, "CONSTITUENT_SRNO"),
                    constituentElementName = GetValue(r, "CONSTITUENT_ELEMENT_NAME"),
                    constituentElementCode = GetValue(r, "CONSTITUENT_ELEMENT_CODE"),
                    constituentPercentage = GetValue(r, "CONSTITUENT_PERCENTAGE"),
                    constituentYieldPercentage = GetValue(r, "CONSTITUENT_YIELD_PERCENTAGE"),
                    activeIngredient = GetValue(r, "ACTIVE_INGREDIENT")
                };

                root.master.constituentFinal.Add(model);
            }
        }
        // ================= CONTAINER MODEL =================

        root.master.containerModel = new List<ContainerModel_Exp>();

        if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
        {
            foreach (DataRow r in ds.Tables[3].Rows)
            {
                ContainerModel_Exp container = new ContainerModel_Exp
                {
                    containerNumber = GetValue(r, "ANNEX_SEA_CON_CONTAINERNO"),
                    containerSize = GetValue(r, "ANNEX_SEA_CON_SIZE"),
                    exciseSealNo = GetValue(r, "ANNEX_SEA_CON_EXCISE_SEALNO"),
                    sealDate = GetValue(r, "ANNEX_SEA_CON_SEAL_DATE"),
                    sealTypeIndicator = GetValue(r, "ANNEX_SEA_CON_SEALTYPE_INDICATOR"),
                    sealDeviceID = GetValue(r, "ANNEX_SEA_CON_SEAL_DEVICEID"),
                    movementDocumentType = GetValue(r, "ANNEX_SEA_CON_DOC_TYPE"),
                    movementDocumentNumber = GetValue(r, "ANNEX_SEA_CON_DOC_NUMBER"),
                    //   eqmntType = GetValue(r, "ANNEX_SEA_CON_TYPE"),
                    //eqmntQty = null,
                    //eqmntQtyCode = null
                };

                root.master.containerModel.Add(container);
            }
        }
        // ================= CONTROL MODEL =================

        root.master.controlType = new List<ControlModel_Exp>();

        if (ds.Tables.Count > 18 && ds.Tables[18].Rows.Count > 0)
        {
            foreach (DataRow r in ds.Tables[18].Rows)
            {
                ControlModel_Exp control = new ControlModel_Exp();
                {
                    string INVOICE_SLNO = GetValue(r, "INVOICE_SLNO");
                    string ITEM_SLNO = GetValue(r, "ITEM_SLNO");
                    string CONTROL_TYPE_CODE = GetValue(r, "CONTROL_TYPE_CODE");
                    if (CONTROL_TYPE_CODE != "DUC")
                    {
                        INVOICE_SLNO = "0";
                        ITEM_SLNO = "0";
                    }

                    control.invoiceSerialNumber = INVOICE_SLNO;
                    control.itemSerialNumber = ITEM_SLNO;
                    control.controlSerialNo = GetValue(r, "SLNO");
                    control.controlTypeCode = GetValue(r, "CONTROL_TYPE_CODE");
                    control.controlLocation = GetValue(r, "CONTROL_LOCATION");
                    control.controlStartDate = GetValue(r, "CONTROL_START_DATE");
                    control.controlEndDate = GetValue(r, "CONTROL_END_DATE");
                    control.controlResultCode = GetValue(r, "CONTROL_RESULT_CODE");
                    control.controlResultRemarks = GetValue(r, "CONTROL_RESULT_TEXT");
                };

                root.master.controlType.Add(control);

            }
        }
        // ================= DBKModel  =================
        root.master.dbkModel = new List<DBKModel_Exp>();

        if (ds.Tables.Count > 8 && ds.Tables[8].Rows.Count > 0)
        {
            foreach (DataRow r in ds.Tables[8].Rows)
            {
                DBKModel_Exp DBK = new DBKModel_Exp
                {
                    invoiceSerialNumber = GetValue(r, "INVOICE_SLNO"),
                    itemSerialNumberInvoice = GetValue(r, "ITEM_SLNO"),
                    dbkScheduleNumber = GetValue(r, "DRAWBACK_SLNO"),
                    drawbackQuantity = GetValue(r, "DRAWBACK_QTY"),
                    drawbackAvailable = GetValue(r, "drawbackAvailable"),

                };

                root.master.dbkModel.Add(DBK);
            }
        }
        // ================= DFIA MODEL =================

        //root.master.DfiaModel = new List<DfiaModel>();

        //if (ds.Tables.Count > 14 && ds.Tables[14].Rows.Count > 0)
        //{
        //    foreach (DataRow r in ds.Tables[14].Rows)
        //    {
        //        DfiaModel dfia = new DfiaModel
        //        {
        //            jobNumber = GetValue(r, "JOB_NO"),
        //            invoiceSerialNumber = GetValue(r, "INVOICE_SLNO"),
        //            itemSerialNumberInvoice = GetValue(r, "ITEM_SLNO"),
        //            srno = GetValue(r, "LICENSE_E_SL_NO"),
        //            quantity = GetValue(r, "LICENSE_IMP_QTY"),
        //            unitOfMeasurement = GetValue(r, "LICENSE_IMP_UNIT"),
        //            itemDescription = GetValue(r, "LICENSE_IMP_DESC"),
        //            licenseNumber = GetValue(r, "LICENSE_NO")
        //        };

        //        root.master.DfiaModel.Add(dfia);
        //    }
        //}
        // ================= EOU MODEL =================

        root.master.eouModel = new List<EOUModel>();

        if (ds.Tables.Count > 9 && ds.Tables[9].Rows.Count > 0)
        {
            foreach (DataRow r in ds.Tables[9].Rows)
            {
                EOUModel eou = new EOUModel
                {
                    //jobNumber = GetValue(r, "ANNEX_JOBNO"), // Hide by shanthini on 22-06-2026
                    ieCodeOfTheEOU = GetValue(r, "ANNEX_IECCODE"),
                    branchSrNumberOfIE = GetValue(r, "ANNEX_BR_SLNO"),
                    examinationDate = GetValue(r, "ANNEX_EXAM_DATE"),
                    examiningOfficerName = GetValue(r, "ANNEX_EXAM_OFFICER"),
                    examiningOfficerDesignation = GetValue(r, "ANNEX_EXAM_DESIGN"),
                    supervisingOfficerName = GetValue(r, "ANNEX_SUPER_NAME"),
                    supervisingOfficerDesignation = GetValue(r, "ANNEX_SUPER_DESIGN"),
                    commissionerate = GetValue(r, "ANNEX_COMMISSION_RATE"),
                    division = GetValue(r, "ANNEX_DIVISION"),
                    range = GetValue(r, "ANNEX_RANGE"),
                    sealNo = GetValue(r, "ANNEX_SEAL_NO"),
                    itemValuesVerifiedByExaminingOfficer = GetValue(r, "ANNEX_VERIFIED_EXAM_OFFICER"),
                    sampleForwarded = GetValue(r, "ANNEX_SAMPLE_DRAWN")
                };

                root.master.eouModel.Add(eou);
            }
        }

        // ================= INVOICE MODEL =================

        root.master.invoiceModel = new List<InvoiceModel_Exp>();

        if (ds.Tables.Count > 5 && ds.Tables[5].Rows.Count > 0)
        {
            foreach (DataRow r in ds.Tables[5].Rows)
            {
                InvoiceModel_Exp inv = new InvoiceModel_Exp();

                inv.invoiceSerialNumber = GetValue(r, "INVOICE_SLNO");
                inv.actualInvoiceNo = GetValue(r, "INVOICE_NO");
                inv.invoiceDate = GetValue(r, "INVOICE_DATE");
                inv.invoiceCurrency = GetValue(r, "INVOICE_CURRENCY");
                inv.natureOfContract = GetValue(r, "TERMS");
                //inv.buyerName = GetValue(r, "BUYER_NAME");
                string BUYER_NAME = GetValue(r, "BUYER_NAME");
                string BUYER_ADDRESS = GetValue(r, "BUYER_ADDRESS");
                string COMMISSION_RATE = GetValue(r, "COMMISSION_RATE");
                string COMMISSION_CHARGES = GetValue(r, "COMMISSION_CHARGES");
                string FOB_RATE = GetValue(r, "FOB_RATE");
                string FOB_CHARGES = GetValue(r, "FOB_CHARGES");
                string OTHER_DEDUCTION_CHARGES = GetValue(r, "OTHER_DEDUCTION_CHARGES");
                string OTHER_DEDUCTION_RATE = GetValue(r, "OTHER_DEDUCTION_RATE");
                if (BUYER_NAME == "SAME AS CONSIGNEE" && BUYER_ADDRESS == "" || BUYER_ADDRESS == null)
                {
                    BUYER_ADDRESS = "`";
                }

                if (COMMISSION_RATE != "0.00" & COMMISSION_RATE != "0.0" && COMMISSION_RATE != "0" && COMMISSION_RATE != "")
                {
                    COMMISSION_CHARGES = null;
                }

                if (FOB_RATE != "0.00" & FOB_RATE != "0.0" && FOB_RATE != "0" && FOB_RATE != "")
                {
                    FOB_CHARGES = null;
                }

                if (OTHER_DEDUCTION_RATE != "0.00" & OTHER_DEDUCTION_RATE != "0.0" && OTHER_DEDUCTION_RATE != "0" && OTHER_DEDUCTION_RATE != "")
                {
                    OTHER_DEDUCTION_CHARGES = null;
                }

                string buyer;
                buyer = BUYER_NAME; inv.buyerName = buyer != null && buyer.Length > 35 ? buyer.Substring(0, 35) : buyer;

                string BUYER_ADD1 = BUYER_ADDRESS;
                string BUYER_ADD2 = GetValue(r, "BUYER_ADDRESS1");
                string BUYER_ADD3 = GetValue(r, "BUYER_ADDRESS2");
                string BUYER_ADD4 = GetValue(r, "BUYER_ADDRESS3");

                if (Connection.COMPANYID() != "148") // Condition added by Shanthini suggest by bala sir & praveen on 24-08-2026
                {
                    string Buyer_All = BUYER_ADD1 + BUYER_ADD2 + BUYER_ADD3 + BUYER_ADD4; 
                    string[] buyerParts = new string[4];
                    for (int i = 0; i < buyerParts.Length && Buyer_All.Length > 0; i++)
                    {
                        int length = Math.Min(35, Buyer_All.Length);
                        buyerParts[i] = Buyer_All.Substring(0, length);
                        Buyer_All = Buyer_All.Remove(0, length);
                    } 
                    BUYER_ADD1 = buyerParts[0];
                    BUYER_ADD2 = buyerParts[1];
                    BUYER_ADD3 = buyerParts[2];
                    BUYER_ADD4 = buyerParts[3];
                }

                inv.buyerAddress1 = BUYER_ADD1;
                inv.buyerAddress2 = BUYER_ADD2;
                inv.buyerAddress3 = BUYER_ADD3;
                inv.buyerAddress4 = BUYER_ADD4;

                inv.freightCurrency = GetValue(r, "FREIGHT_CURRENCY");
                inv.freightAmount = GetValue(r, "FREIGHT_CHARGES");

                inv.insuranceRate = GetValue_INV(r, "INSURANCE_RATE");
                inv.insuranceCurrency = GetValue(r, "INSURANCE_CURRENCY");
                inv.insuranceAmount = GetValue_INV(r, "INSURANCE_CHARGES");

                inv.commissionRate = GetValue_INV(r, "COMMISSION_RATE");
                inv.commissionCurrency = GetValue(r, "COMMISSION_CURRENCY");
                inv.commissionAmount = COMMISSION_CHARGES;

                inv.discountOnFOB = GetValue_INV(r, "FOB_RATE");
                inv.discountCurrency = GetValue(r, "FOB_CURRENCY");
                inv.discountAmount = FOB_CHARGES;

                inv.otherDeductions = GetValue_INV(r, "OTHER_DEDUCTION_RATE");
                inv.otherDeductionsCurrency = GetValue(r, "OTHER_DEDUCTION_CURRENCY");
                inv.otherDeductionsAmount = OTHER_DEDUCTION_CHARGES;

                inv.packingCharges = GetValue(r, "PACKMISC_CHARGES");
                inv.addFreight = GetValue(r, "WHEATHER_UNIT_PRICE");
                inv.exporterContractNumber = GetValue(r, "CONTRACT_NO");
                inv.natureOfPayment = GetValue(r, "PAYMENT_METHOD");
                inv.periodOfPayment = GetValue(r, "PERIOD_PAYMENT");

                inv.thirdPartyName = GetValue(r, "THIRDPARTY_NAME");
                inv.thirdPartyAddress1 = GetValue(r, "THIRDPARTY_ADD1");
                inv.thirdPartyAddress2 = GetValue(r, "THIRDPARTY_ADD2");
                inv.thirdPartyCity = GetValue(r, "THIRDPARTY_CITY");
                inv.thirdPartyCountrySubdivision = GetValue(r, "T_PARTY_COUNTRY_SUB_DIV");
                inv.thirdPartCountryCode = GetValue(r, "T_PARTY_COUNTRY_CODE");
                inv.thirdPartyPin = GetValue(r, "T_PARTY_PIN");

                inv.authorizedEconomicOperatorCode = GetValue(r, "AUTHORIZED_ECONOMIC_OPERATOR_CODE");
                inv.authorizedEconomicOperatorCountry = GetValue(r, "A_E_O_COUNTRY");
                inv.authorizedEconomicOperatorRole = GetValue(r, "AUTHORIZED_ECONOMIC_OPERATOR");

                inv.termsPlace = GetValue(r, "TERMS_PLACE");


                root.master.invoiceModel.Add(inv);
            }
        }
        // =================ITEM ACCESS MODEL =================
        root.master.itemAccessModel = new List<itemAccessModel_Exp>();

        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            for (int ac = 0; ac < ds.Tables[0].Rows.Count; ac++)
            {
                string ITEM_ACCESSORIES_DESC = GetValue(ds.Tables[0].Rows[ac], "ITEM_ACCESSORIES_DESC");

                if (string.IsNullOrEmpty(ITEM_ACCESSORIES_DESC))
                    continue;

                itemAccessModel_Exp item = new itemAccessModel_Exp();


                item.invoiceSerialNumber = GetValue(ds.Tables[0].Rows[ac], "INVOICE_SLNO");
                item.itemSerialNumber = GetValue(ds.Tables[0].Rows[ac], "ITEM_SLNO");

                item.itemAccessoriesDescription = ITEM_ACCESSORIES_DESC;

                root.master.itemAccessModel.Add(item);
            }
        }
        // ================= ITEM MODEL =================

        root.master.itemModel = new List<ItemModel_Exp>();

        if (ds.Tables.Count > 7 && ds.Tables[7].Rows.Count > 0)
        {
            foreach (DataRow r in ds.Tables[7].Rows)
            {
                ItemModel_Exp item = new ItemModel_Exp();

                string RODTEP = GetValue(r, "RODTEP");
                item.invoiceSerialNumber = GetValue(r, "INVOICE_SLNO");
                item.itemSerialNumberInvoice = GetValue(r, "ITEM_SLNO");
                string SCHEME_CODE_FULL = GetValue(r, "ITEM_SCHEME_CODE");

                string schecode = null;

                string[] SCHEME_COD = SCHEME_CODE_FULL.Split('-');

                //if (SCHEME_COD[0].Trim() == "00")
                //{

                //    schecode = null;
                //}
                //else
                //{
                schecode = SCHEME_COD[0];
                //}
                item.schemeCode = schecode;
                item.ritcCode = GetValue(r, "RITCNO");
                item.descOfGoods1 = GetValue(r, "ITEM_DESCRIPTION1");
                item.descOfGoods2 = GetValue(r, "ITEM_DESCRIPTION2");
                item.descOfGoods3 = GetValue(r, "ITEM_DESCRIPTION3");
                item.unitOfMeasurement = GetValue(r, "ITEM_QTY_CODE");
                item.quantity = GetValue(r, "ITEM_QTY");
                item.unitPrice = GetValue(r, "ITEM_UNIT_PRICE");
                item.unitOfRate = GetValue(r, "ITEM_QTY_CODE");
                item.noOfUnit = GetValue(r, "ITEM_PER");
                string val = GetValue(r, "ITEM_PMVVALUE");
                string ITEM_QTY = GetValue(r, "ITEM_QTY");
                string ITEM_PER = GetValue(r, "ITEM_PER");
                string PMV_METHOD = GetValue(r, "PMV_METHOD");
                string PMV_PER_UNIT = GetValue(r, "PMV_PER_UNIT");
                string INVOICE_SLNO = GetValue(r, "INVOICE_SLNO");
                string ITEM_SLNO = GetValue(r, "ITEM_SLNO");

                if (COMPANY_ID == "116")
                {
                    if (currentbranch == "ACC, Kolkata" || currentbranch == "CusHouse, Kolkata" || currentbranch == "ICD,Petrapole")
                    {
                        val = GetValue(r, "ITEM_PMVVALUE");
                    }
                }
                //-------------Implemented on 16Mar2018 For elogix Clients and eroyal Clients----------------//
                else if (COMPANY_ID == "233" || COMPANY_ID == "442" || COMPANY_ID == "438" || COMPANY_ID == "436" || COMPANY_ID == "443" ||
                   COMPANY_ID == "435" || COMPANY_ID == "434" || COMPANY_ID == "402" || COMPANY_ID == "459" ||
                   COMPANY_ID == "444" || COMPANY_ID == "457" || COMPANY_ID == "470" || COMPANY_ID == "477" ||
                  COMPANY_ID == "478" || COMPANY_ID == "479" || COMPANY_ID == "488" || COMPANY_ID == "492" ||
                  COMPANY_ID == "525" || COMPANY_ID == "538" || COMPANY_ID == "539" || COMPANY_ID == "571")
                {
                    val = GetValue(r, "ITEM_PMVVALUE");
                }
                //-------------Implemented on 16Mar2018 For elogix Clients and eroyal Clients----------------//



                if (val == "")
                {
                    val = "0.00";
                }

                if (val.Trim() != "" && Convert.ToDouble(val) != 0.00 && Convert.ToDouble(val) != 0)
                {

                    PMV_VALUE = Convert.ToString(Math.Round(Convert.ToDouble(val) / Convert.ToDouble(ITEM_QTY), 2).ToString("0.00"));


                    //this line hide by Chithra on 20-01-2020 for ITEM_PER calc wrong - do not (* Multiply) -should be (/- divide) 
                    //PMV_VALUE = Convert.ToString(Math.Round(Convert.ToDouble(PMV_VALUE) * Convert.ToDouble(ITEM_PER), 2).ToString("0.00"));

                    //this line hide by Chithra on 19-06-2020 for DBK value not come in Final Copy sugg.by Bala sir..
                    // PMV_VALUE = Convert.ToString(Math.Round(Convert.ToDouble(PMV_VALUE) / Convert.ToDouble(ITEM_PER), 2).ToString("0.00"));

                    //Again this line enabled on 05-08-2020 for DBK Rate Not Update in Icegate issue-Sugg.by Subbu sir..
                    PMV_VALUE = Convert.ToString(Math.Round(Convert.ToDouble(PMV_VALUE) * Convert.ToDouble(ITEM_PER), 2).ToString("0.00"));

                    if (Convert.ToDouble(PMV_VALUE) == 0.00 || Convert.ToDouble(PMV_VALUE) == 0)
                        PMV_VALUE = "0.01";

                    //PMV_VALUE = Convert.ToString(Math.Round(Convert.ToDouble(val), 1)/ Convert.ToDouble(ITEM_QTY).ToString("0.00"));
                    //string fob = Convert.ToString(Math.Round(val), 1).ToString("0.00"));

                }
                else
                {
                    if (Convert.ToDouble(val) == 0.00 || Convert.ToDouble(val) == 0)
                        PMV_VALUE = "0.01";
                    else
                        PMV_VALUE = "0";
                }


                if (COMPANY_ID == "116")
                {
                    if (currentbranch == "ACC, Kolkata" || currentbranch == "CusHouse, Kolkata" || currentbranch == "ICD,Petrapole")
                    {
                        if (Convert.ToDouble(PMV_VALUE) == 0.01 || Convert.ToDouble(PMV_VALUE) == 0)
                            PMV_VALUE = "0.00";
                    }
                }
                //-------------Implemented on 16Mar2018 For elogix Clients  and eroyal Clients EXCEPTT FrightLog(ERI00525)----------------//
                else if (COMPANY_ID == "233" || COMPANY_ID == "442" || COMPANY_ID == "438" || COMPANY_ID == "436" || COMPANY_ID == "443"
                    || COMPANY_ID == "435" || COMPANY_ID == "434" || COMPANY_ID == "402" || COMPANY_ID == "459"
                    || COMPANY_ID == "444" || COMPANY_ID == "457" || COMPANY_ID == "477" || COMPANY_ID == "478" || COMPANY_ID == "479"
                    || COMPANY_ID == "488" || COMPANY_ID == "492" || COMPANY_ID == "538" || COMPANY_ID == "571")
                {
                    if (Convert.ToDouble(PMV_VALUE) == 0.01 || Convert.ToDouble(PMV_VALUE) == 0)
                        PMV_VALUE = "0.00";
                }
                //-------------Implemented on 16Mar2018 For elogix Clients and eroyal Clients----------------//


                //this condition implmtd for Agility on 24-07-2020 sugg by Bala sir..
                if (PMV_METHOD == "Unit" || PMV_METHOD == "PerUnit")
                {
                    PMV_VALUE = PMV_PER_UNIT;
                }

                //Check IS_JOBBING
                DataView view1 = ds.Tables[13].DefaultView;

                view1.RowFilter = "INVOICE_SLNO = " + INVOICE_SLNO + " and " + "ITEM_SLNO = " + ITEM_SLNO;

                //DataTable table1 = view1.ToTable();
                DataSet dt_UserRights = new DataSet();
                dt_UserRights.Tables.Add(view1.ToTable());

                NOTIFICATION_NO = "";
                if (dt_UserRights.Tables[0].Rows.Count > 0)
                {
                    NOTIFICATION_NO = dt.Trim(dt_UserRights.Tables[0].Rows[0]["NOTIFICATION_NO"].ToString());
                }


                //Check IS_JOBBING

                //Check IS_ThirdPaty or Rewardpoints

                //string IS_ThirdParty = "", Is_Reward = "";

                //if (ITEM_EXPORTER_NAME != "" && ITEM_EXPORTER_NAME != null)
                //{
                //    IS_ThirdParty = "Y";
                //    ITEM_EXPORTER_NAME_THIRD = ITEM_EXPORTER_NAME;
                //}
                //else
                //    IS_ThirdParty = "N";
                
                string ITEM_EXPORTER_NAME = GetValue(r, "ITEM_EXPORTER_NAME"); //  read from row
                string IS_ThirdParty = "N"; //  default N
                string Is_Reward = "";

                if (!string.IsNullOrEmpty(ITEM_EXPORTER_NAME))
                {
                    IS_ThirdParty = "Y";
                    ITEM_EXPORTER_NAME_THIRD = ITEM_EXPORTER_NAME;
                }
                else
                    IS_ThirdParty = "N";

                //Check IS_ThirdPaty or Rewardpoints
             
                //if (REWARD_POINTS != "")
                //{
                //    Is_Reward = "Y";
                //}
                //else
                //    Is_Reward = "N";
                //Check IS_ThirdPaty or Rewardpoints

                //sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_SCHEME_CODE + ch + RITCNO + ch + ITEM_DESCRIPTION1 + ch + ITEM_DESCRIPTION2 + ch + ITEM_DESCRIPTION3 + ch + ITEM_QTY_CODE + ch + ITEM_QTY + ch + ITEM_UNIT_PRICE + ch + ITEM_QTY_CODE + ch + ITEM_PER + ch + PMV_VALUE + ch + NOTIFICATION_NO + ch + IS_ThirdParty + ch + REWARD_POINTS + ch + ch + ch);

                /* hide on 02-02-2023 by Chithra for Export not numbering issue
                if (MANUFACTURER_PRODUCER != "" || M_P_GROWER_CODE != "" || M_P_GROWER_ADD1 != "")
                {
                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_SCHEME_CODE + ch + RITCNO + ch + ITEM_DESCRIPTION1 + ch + ITEM_DESCRIPTION2 + ch + ITEM_DESCRIPTION3 + ch + ITEM_QTY_CODE + ch + ITEM_QTY + ch + ITEM_UNIT_PRICE + ch + ITEM_QTY_CODE + ch + ITEM_PER + ch + PMV_VALUE + ch + NOTIFICATION_NO + ch + IS_ThirdParty + ch + REWARD_POINTS + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date + ch + MANUFACTURER_PRODUCER + ch + M_P_GROWER_CODE + ch + M_P_GROWER_ADD1 + ch + M_P_GROWER_COUNTRY_SUBDIV + ch + M_P_GROWER_PIN + ch + M_P_GROWER_COUNTRY + ch + SOURCE_STATE + ch + TRANSIT_COUNTRY + ch + ACCESSORY_STATUS + ch + ENDUSE_ITEM + ch + HAWB_NO + ch + TOTAL_PKGS + ch + IGST_PAYMENT + ch + TAXABLE_VALUE + ch + IGST_AMT);
                }
                else
                {
                    sw.WriteLine("F" + ch + CUSTOMS_HOUSE + ch + ddlJobNo.SelectedValue.ToString() + ch + JOBDATE + ch + SB_NO + ch + SB_DATE + ch + INVOICE_SLNO + ch + ITEM_SLNO + ch + ITEM_SCHEME_CODE + ch + RITCNO + ch + ITEM_DESCRIPTION1 + ch + ITEM_DESCRIPTION2 + ch + ITEM_DESCRIPTION3 + ch + ITEM_QTY_CODE + ch + ITEM_QTY + ch + ITEM_UNIT_PRICE + ch + ITEM_QTY_CODE + ch + ITEM_PER + ch + PMV_VALUE + ch + NOTIFICATION_NO + ch + IS_ThirdParty + ch + REWARD_POINTS + ch + Amendment_Type + ch + Amendment_No + ch + Amendment_Date + ch + MANUFACTURER_PRODUCER + ch + M_P_GROWER_CODE + ch + M_P_GROWER_ADD1 + ch + M_P_GROWER_ADD2 + ch + M_P_GROWER_CITY + ch + M_P_GROWER_COUNTRY_SUBDIV + ch + M_P_GROWER_PIN + ch + M_P_GROWER_COUNTRY + ch + SOURCE_STATE + ch + TRANSIT_COUNTRY + ch + ACCESSORY_STATUS + ch + ENDUSE_ITEM + ch + HAWB_NO + ch + TOTAL_PKGS + ch + IGST_PAYMENT + ch + TAXABLE_VALUE + ch + IGST_AMT);
                }
                */



                item.presentMarketValue = PMV_VALUE;
                item.thirdParty = IS_ThirdParty;
                item.rewardItem = GetValue(r, "REWARD_POINTS");

                item.itemManufacturerProducerGrowerCode = GetValue(r, "M_P_GROWER_CODE");
                item.itemManufacturerProducerGrowerAddress1 = GetValue(r, "M_P_GROWER_ADD1");
                item.itemManufacturerProducerGrowerAddress2 = GetValue(r, "M_P_GROWER_ADD2");
                item.itemManufacturerProducerGrowerCity = GetValue(r, "M_P_GROWER_CITY");
                item.itemManufacturerProducerGrowerCountrySubdivisiob = GetValue(r, "M_P_GROWER_COUNTRY_SUBDIV");
                item.itemManufacturerProducerGrowerPin = GetValue(r, "M_P_GROWER_PIN");
                item.itemManufacturerCountry = GetValue(r, "M_P_GROWER_COUNTRY");

                item.sourceState = GetValue(r, "SOURCE_STATE");
                item.transitCountry = GetValue(r, "TRANSIT_COUNTRY");
                item.accessoryStatus = GetValue(r, "ACCESSORY_STATUS");
                item.endUseOfItem = GetValue(r, "ENDUSE_ITEM");

                item.hawbNo = GetValue(r, "HAWB_NO");
                item.totalPackage = GetValue(r, "TOTAL_PKGS");

                item.igstPaymentStatus = GetValue(r, "IGST_PAYMENT");
                item.taxableValue = GetValue(r, "TAXABLE_VALUE");
                item.igstAmount = GetValue(r, "IGST_AMT");


                root.master.itemModel.Add(item);
            }
        }

        // ================= INFO TYPE =================

        root.master.infoType = new List<InfoTypeModel>();

        // Read table 0
        string SB_TYPE = GetValue(ds.Tables[0].Rows[0], "SB_TYPE");
        string NFEI = GetValue(ds.Tables[0].Rows[0], "NFEI");
        string NFEI_TYPE = GetValue(ds.Tables[0].Rows[0], "NFEI_TYPE");
        int srNoCounter = 1;

        //  Table 24 - RODTEP qty data
        DataTable dtRodtep = ds.Tables[24];

        if (NFEI_TYPE != null)
        {
            if (NFEI_TYPE.Contains("-"))
            {
                string[] type = NFEI_TYPE.Split('-');
                NFEI_TYPE = dt.Trim(type[0]).ToUpper();
            }
        }

        // Read table 23
        foreach (DataRow r in ds.Tables[23].Rows)
        {
            string INFO_QUALIFIER = GetValue(r, "INFO_QUALIFIER");

            // Skip if all 4 conditions match
            if (INFO_QUALIFIER == "EPT" && SB_TYPE == "SEZ" && NFEI == "Yes" && NFEI_TYPE == "09")
                continue;

            string INFO_CODE = GetValue(r, "INFO_CODE");
            string INFO_TEXT = GetValue(r, "INFO_TEXT");

            if (!string.IsNullOrEmpty(INFO_CODE))
            {
                if (INFO_CODE.Contains("-"))
                    INFO_CODE = dt.Trim(INFO_CODE.Split('-')[0]).ToUpper();

                // Apply RODTEP text AFTER normalizing the code
                if (INFO_CODE == "RODTEPY")
                    INFO_TEXT = "CLAIMED";
                else if (INFO_CODE == "RODTEPN")
                    INFO_TEXT = "NOT CLAIMED";
            }

            //  INFO_MSR & INFO_UQC - Table24 first, fallback Table23
            
            string INVOICE_SLNO = GetValue(r, "INVOICE_SLNO");
            string ITEM_SLNO = GetValue(r, "ITEM_SLNO");
            string INFO_MSR;
            string INFO_UQC;

            if (INFO_CODE == "RODTEPY" && INFO_QUALIFIER == "RDT")
            {
                DataRow[] rodtepRows = dtRodtep.Select(
                    "INVOICE_SLNO = '" + INVOICE_SLNO + "' AND ITEM_SLNO = '" + ITEM_SLNO + "'"
                );

                if (rodtepRows.Length > 0)
                {
                    // Table24 match — use ITEM_QTY & ITEM_QTY_CODE
                    INFO_MSR = dt.Trim(rodtepRows[0]["ITEM_QTY"].ToString());
                    INFO_UQC = dt.Trim(rodtepRows[0]["ITEM_QTY_CODE"].ToString()).ToUpper();
                }
                else
                {
                    // Table24 not found — fallback to Table23 directly
                    INFO_MSR = GetValue(r, "INFO_MSR");
                    INFO_UQC = GetValue(r, "INFO_UQC") != null? GetValue(r, "INFO_UQC").ToUpper() : null;
                }
            }
            else
            {
                // Not RODTEPY/RDT — use Table23 directly
                INFO_MSR = GetValue(r, "INFO_MSR");
                INFO_UQC = GetValue(r, "INFO_UQC") != null? GetValue(r, "INFO_UQC").ToUpper(): null;
            }

            InfoTypeModel info = new InfoTypeModel();
            info.invoiceSerialNumber = INVOICE_SLNO;  
            info.itemSerialNumber = ITEM_SLNO;      
            info.infoSrNo = srNoCounter.ToString();
            info.infoType = GetValue(r, "INFO_TYPE");
            info.infoQualifier = INFO_QUALIFIER;
            info.infoCode = INFO_CODE;
            info.infoText = INFO_TEXT;
            info.infoMeasure = INFO_MSR;      
            info.infouqc = INFO_UQC;      

            root.master.infoType.Add(info);
            srNoCounter++;
        }



        // ================= Jobwork MODEL =================
        root.master.jobWorkModel = new List<jobWorkModel_Exp>();

        if (ds.Tables.Count > 13 && ds.Tables[13].Rows.Count > 0)
        {
            foreach (DataRow row in ds.Tables[13].Rows)
            {
                string invoiceSlno = GetValue(row, "INVOICE_SLNO");

                // only create record if invoice exists
                if (!string.IsNullOrEmpty(invoiceSlno))
                {
                    jobWorkModel_Exp job = new jobWorkModel_Exp();

                    job.invoiceSerialNumber = invoiceSlno;
                    job.itemSerialNumberInvoice = GetValue(row, "ITEM_SLNO");
                    job.srno = null;

                    job.beNumber = GetValue(row, "BE_NO");
                    job.beDate = GetValue(row, "BE_DATE");

                    job.beInvoiceSerialNo = GetValue(row, "BE_INV_SLNO");
                    job.beInvoiceNumber = GetValue(row, "BE_INV_NO");

                    job.beItemNumber = GetValue(row, "BE_ITEM_NO");
                    job.bePortCode = GetValue(row, "BE_PORT_CODE");

                    job.beQtyUsed = GetValue(row, "QTY");
                    job.qtyUnits = GetValue(row, "UNIT");



                    root.master.jobWorkModel.Add(job);
                }
            }



        }

        // ================= LICENSE MODEL =================

        root.master.licenceModel = new List<LicenseModel_Exp>();

        if (ds.Tables.Count > 14 && ds.Tables[14].Rows.Count > 0)
        {
            foreach (DataRow r in ds.Tables[14].Rows)
            {
                LicenseModel_Exp lic = new LicenseModel_Exp
                {

                    invoiceSerialNumber = GetValue(r, "INVOICE_SLNO"),
                    itemSerialNumberInvoice = GetValue(r, "ITEM_SLNO"),
                    srno = GetValue(r, "LICENSE_REG_SLNO"),
                    registrationNo = GetValue(r, "LICENSE_NO"),
                    registrationDate = GetValue(r, "LICENSE_DATE"),
                    itemSerialNoInPartE = GetValue(r, "LICENSE_E_SL_NO"),
                    itemSerialNoInPartC = GetValue(r, "LICENSE_IMP_ITEM_SL_NO"),
                    quantity = GetValue(r, "LICENSE_IMP_QTY"),
                    exportQuantity = GetValue(r, "LICENSE_EXP_QTY"),
                    whetherIndigenousImported = GetValue(r, "LICENSE_IMP_TYPE")
                };

                root.master.licenceModel.Add(lic);
            }
        }
        // ================= PACKING LIST MODEL =================

        root.master.packingListModel = new List<PackingListModel_Exp>();

        if (ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
        {
            foreach (DataRow r in ds.Tables[4].Rows)
            {
                PackingListModel_Exp pack = new PackingListModel_Exp
                {

                    packingNumberFrom = GetValue(r, "ANNEX_SEA_PACK_FROM"),
                    packingNumberTo = GetValue(r, "ANNEX_SEA_PACK_TO"),
                    packingCode = GetValue(r, "ANNEX_SEA_PACK_PACKAGETYPE")
                };

                root.master.packingListModel.Add(pack);
            }
        }
        // ================= PRODUCTION =================

        root.master.production = new List<ProductionModel_Exp>();

        if (ds.Tables.Count > 17 && ds.Tables[17].Rows.Count > 0)
        {
            foreach (DataRow r in ds.Tables[17].Rows)
            {
                ProductionModel_Exp prod = new ProductionModel_Exp
                {
                    //jobNumber = GetValue(r, "JOBNO"), // Hide by shanthini on 22-06-2026
                    invoiceSerialNumber = GetValue(r, "INVOICE_SLNO"),
                    itemSerialNumber = GetValue(r, "ITEM_SLNO"),
                    productionSerialNo = GetValue(r, "SLNO"),
                    productionBatchIdentifier = GetValue(r, "PRODUCTION_BATCH_IDENTIFIER"),
                    productionBatchQuantity = GetValue(r, "PRODUCTION_BATCH_QUANTITY"),
                    unitQuantityCode = GetValue(r, "UNIT_QTY_CODE"),
                    dateOfManufacturing = GetValue(r, "DATE_OF_MANUFACTURING"),
                    dateOfExpiry = GetValue(r, "DATE_OF_EXPIRY"),
                    bestBefore = GetValue(r, "BEST_BEFORE")
                };

                root.master.production.Add(prod);
            }
        }
        // ================= REEXPORT =================

        root.master.reexport = new List<ReexportModel_Exp>();

        if (ds.Tables.Count > 10 && ds.Tables[10].Rows.Count > 0)
        {
            foreach (DataRow r in ds.Tables[10].Rows)
            {
                ReexportModel_Exp re = new ReexportModel_Exp
                {
                    //jobNumber = GetValue(r, "JOBNO"),// Hide by shanthini on 22-06-2026
                    sbNumber = GetValue(r, "SB_NO"),
                    sbDate = GetValue(r, "SB_DATE"),

                    invoiceSerialNumber = GetValue(r, "INVOICE_SLNO"),
                    itemSerialNumber = GetValue(r, "ITEM_SLNO"),
                    serialNo = GetValue(r, "SLNO"),

                    beSite = GetValue(r, "BE_SITE"),
                    beNo = GetValue(r, "BE_NO"),
                    beDate = GetValue(r, "BE_DATE"),

                    beInvoiceNo = GetValue(r, "BE_INVOICE_NO"),
                    beItem = GetValue(r, "BE_INVOICE_ITEM_NO"),
                    manualBe = GetValue(r, "MANUAL_BE_Y_N"),

                    beQuantityUtilised = GetValue(r, "BE_QTY_UTILISED"),
                    beItemDescription = GetValue(r, "BE_ITEM_DESC"),

                    beQty = GetValue(r, "BE_QTY"),
                    beUqc = GetValue(r, "BE_UQC"),

                    beAssessedValue = GetValue(r, "BE_ASS_VALUE"),
                    beDutyPaid = GetValue(r, "BE_DUTY_PAID"),
                    beDutyPaymentDate = GetValue(r, "BE_DUTY_PAYMENT_DATE"),

                    beOtherIdentifiableParameter = GetValue(r, "BE_OTH_IDENTIFIABLE_PARAMETER"),
                    beAssessableValueClaimed = GetValue(r, "BE_ASS_VALUE_CLAIM"),

                    beItemUsed = GetValue(r, "BE_ITEM_USED_Y_N"),
                    commisionerPermission = GetValue(r, "COMMISIONER_PERMISSION_Y_N"),
                    inputCredit = GetValue(r, "INPUT_CREDIT_Y_N"),
                    personalUse = GetValue(r, "PERSONAL_USED_Y_N"),

                    modvaAvailed = GetValue(r, "MODVAT_AVAILED_Y_N"),
                    modvatRepaid = GetValue(r, "MODVAT_REPAID_Y_N")
                };

                root.master.reexport.Add(re);
            }
        }

        // ================= SBModel =================
        root.master.sbModel = new List<SBModel_Exp>();

        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DataRow gen = ds.Tables[0].Rows[0];

            STATE_OF_EXPORT = GetValue(gen, "STATE_OF_EXPORT");
            PORT_OF_LOADING = GetValue(gen, "PORT_OF_LOADING");
            PORT_FINAL_DEST = GetValue(gen, "PORT_FINAL_DEST");
            string categoryNEFISB = GetValue(gen, "NFEI_TYPE");
            CONSIGNEE_ADD5 = GetValue(gen, "CONSIGNEE_ADD5");
            string[] NEFISB = new string[0];

            if (!string.IsNullOrEmpty(categoryNEFISB))
            {
                NEFISB = categoryNEFISB.Split('-');
            }
            else
            {
                NEFISB = null;
            }

            COUNTRY_DISCHARGE = GetValue(gen, "COUNTRY_DISCHARGE");
            COUNTRY_FINAL_DEST = GetValue(gen, "COUNTRY_FINAL_DEST");
            PORT_DISCHARGE = GetValue(gen, "PORT_DISCHARGE");

            Get_Admin_Master_Codes();

            string portdes = PORT_FINAL_DEST;
            string stateOfOriginExporter = STATE_OF_EXPORT;
            string portOfLoad = PORT_OF_LOADING;
            string country_dis = COUNTRY_DISCHARGE;
            string country_des = COUNTRY_FINAL_DEST;
            string portdischarge = PORT_DISCHARGE;

            string marksNumbers;
            string value = GetValue(gen, "MARKS_NO");
            marksNumbers = string.IsNullOrEmpty(value) ? null : value.Replace("\r\n", " ");

            if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                DataRow annex = ds.Tables[2].Rows[0];
                string Transport_Mode = GetValue(gen, "TRANSPORT_MODE");

                if (Transport_Mode == "Air")
                {
                    //NO_CONTAINERS = GetValue(annex, "ANNEX_SEA_NO_CONTAINERS");
                    //if (ANNEX_SEA_SEAL_TYPE == "Agency")
                    //{
                    //    ANNEX_SEA_SEAL_TYPE = "A";
                    //}
                    //else if (ANNEX_SEA_SEAL_TYPE == "Self")
                    //{
                    //    ANNEX_SEA_SEAL_TYPE = "S";
                    //}
                    //else if (ANNEX_SEA_SEAL_TYPE == "Warehouse")
                    //{
                    //    ANNEX_SEA_SEAL_TYPE = "W";
                    //}

                    //if (NO_CONTAINERS == "")
                    //{
                    //    NO_CONTAINERS = "0";
                    //}
                    string cargo = GetValue(annex, "NATURE_OF_CARGO");
                    string result = cargo.Split(' ')[0];
                    natureOfCargo = result;
                    grossWeight = GetValue(annex, "ANNEX_AIR_GROSS_WEIGHT");
                    netWeight = GetValue(annex, "ANNEX_AIR_NET_WEIGHT");
                    unitOfMeasurement = GetValue(annex, "ANNEX_AIR_UNIT_CODE");
                    totalNumberOfPackages = GetValue(annex, "ANNEX_AIR_TOTAL_PACKAGES");
                    //marksNumbers = GetValue(annex, "ANNEX_AIR_MARKS_NOS");

                    if (marksNumbers != null)
                    {
                        marksNumbers = marksNumbers.Length == 1 ? marksNumbers : marksNumbers.TrimEnd('.');
                    }

                    numberOfLoosePackets = GetValue(annex, "LOOSE_PACKETS");
                    numberOfContainers = NO_CONTAINERS;
                    mawbnumber = GetValue(annex, "ANNEX_AIR_MAWB_NO");
                    hawbnumber = GetValue(annex, "ANNEX_AIR_HAWB_NO");
                }
                else
                {
                    ANNEX_SEA_SEAL_TYPE = GetValue(annex, "ANNEX_SEA_SEAL_TYPE");
                    NO_CONTAINERS = GetValue(annex, "ANNEX_SEA_NO_CONTAINERS");

                    if (ANNEX_SEA_SEAL_TYPE == "Agency")
                    {
                        ANNEX_SEA_SEAL_TYPE = "A";
                    }
                    else if (ANNEX_SEA_SEAL_TYPE == "Self")
                    {
                        ANNEX_SEA_SEAL_TYPE = "S";
                    }
                    else if (ANNEX_SEA_SEAL_TYPE == "Warehouse")
                    {
                        ANNEX_SEA_SEAL_TYPE = "W";
                    }

                    if (NO_CONTAINERS == "")
                    {
                        NO_CONTAINERS = "0";
                    }

                    sealType = ANNEX_SEA_SEAL_TYPE;
                    natureOfCargo = GetValue(annex, "NATURE_OF_CARGO");
                    grossWeight = GetValue(annex, "ANNEX_SEA_GROSS_WEIGHT");
                    netWeight = GetValue(annex, "ANNEX_SEA_NET_WEIGHT");
                    unitOfMeasurement = GetValue(annex, "ANNEX_SEA_UNIT_MEASUREMENT");
                    totalNumberOfPackages = GetValue(annex, "ANNEX_SEA_TOTAL_PACKAGES");
                    //marksNumbers = GetValue(annex, "ANNEX_SEA_MARKS_NOS");

                    if (marksNumbers != null)
                    {
                        marksNumbers = marksNumbers.Length == 1 ? marksNumbers : marksNumbers.TrimEnd('.');
                    }

                    numberOfLoosePackets = GetValue(annex, "LOOSE_PACKETS");
                    numberOfContainers = NO_CONTAINERS;
                    mawbnumber = GetValue(annex, "ANNEX_AIR_MAWB_NO");
                    hawbnumber = GetValue(annex, "ANNEX_AIR_HAWB_NO");
                }
            }

            SBModel_Exp sbmodel = new SBModel_Exp();

            //----------------------- Kiran Group --------------------------
            string CUSTOMS_HOUSE = GetValue(gen, "CUSTOMS_HOUSE");

            if (Connection.COMPANYID() == "1636")
            {
                if (ICEGATE_ID == "RKLPLCHA" || ICEGATE_ID == "RKLPLCHAJM" || ICEGATE_ID == "RKLPLCHAUM" || ICEGATE_ID == "RKLPLCHARK")
                {
                    CHA_NO = "AADCR4880PCH001";
                }
                else if (ICEGATE_ID == "RKRLCHA")
                {
                    if (CUSTOMS_HOUSE == "INMUN1")
                    {
                        CHA_NO = "AACFK1870ECH002";
                    }
                    else
                    {
                        CHA_NO = "AACFK1870ECH001";
                    }
                }
                else if (ICEGATE_ID == "KRSACHA")
                {
                    CHA_NO = "AAGFK4878CCH001";
                }
            }
            //ICEGATE_ID = ICEGATE_ID.ToUpper();

            //if (ds.Tables[21].Rows.Count > 0)
            //{
            //    if (ds.Tables[21].Rows[0]["SEZ_ICEGATE_ID"].ToString() != "")
            //    {
            //        ICEGATE_ID = ds.Tables[21].Rows[0]["SEZ_ICEGATE_ID"].ToString();
            //    }

            //    if (ds.Tables[21].Rows[0]["SEZ_PAN_NO"].ToString() != "")
            //    {
            //        CHA_NO = ds.Tables[21].Rows[0]["SEZ_PAN_NO"].ToString();
            //    }
            //}

            if (Connection.COMPANYID() == "2650" && (
                Connection.Current_User_Upper() == "CAPIMPORT" ||
                Connection.Current_User_Upper() == "CAPEXPORT" ||
                Connection.Current_User_Upper() == "SRIVALLIMPORT" ||
                Connection.Current_User_Upper() == "SRIVALLIEXPORT" ||
                Connection.Current_User_Upper() == "SUNIMPEX"))
            {
                CHA_NO = Connection.Get_EXP_CHA_NO();
            }
            else if (Connection.COMPANYID() == "2659" && Connection.Current_User_Upper() == "MILINDCIRCLE")
            {
                CHA_NO = Connection.Get_EXP_CHA_NO();
            }

            string IMP_EXP_TYPE = GetValue(gen, "IMP_EXP_TYPE");

            if (IMP_EXP_TYPE == "GOVERNMENT" || IMP_EXP_TYPE == "GOVERNMENT DEPARTMENTS")
            {
                EXPORTER_CLASS = "G";
            }
            else if (IMP_EXP_TYPE == "GOVERNMENT UNDERTAKINGS")
            {
                EXPORTER_CLASS = "U";
            }
            else if (IMP_EXP_TYPE == "OTHERS")
            {
                EXPORTER_CLASS = "O";
            }
            else if (IMP_EXP_TYPE == "PRIVATE")
            {
                EXPORTER_CLASS = "P";
            }
            else if (IMP_EXP_TYPE == "HAND CARRIAGE")
            {
                EXPORTER_CLASS = "H";
            }
            else
            {
                EXPORTER_CLASS = IMP_EXP_TYPE;
            }

            sbmodel.chaLicenseNumber = CHA_NO;
            sbmodel.importerExporterCode = GetValue(gen, "IEC_NO");
            sbmodel.branchSrNoOfExporter = GetValue(gen, "BRANCH_NO");
            sbmodel.impExpName = GetValue(gen, "EXPORTER_NAME");
            sbmodel.impExpAddress1 = GetValue(gen, "ADDRESS1");
            sbmodel.impExpAddress2 = GetValue(gen, "ADDRESS2");
            sbmodel.impExpCity = GetValue(gen, "ADDRESS3");
            sbmodel.impExpState = GetValue(gen, "ADDRESS4");
            sbmodel.impExpPin = GetValue(gen, "ADDRESS5");
            sbmodel.typeOfExporter = GetValue(gen, "TYPE_OF_EXPORTER");
            sbmodel.exporterClass = EXPORTER_CLASS;
            sbmodel.stateOfOriginExporter = stateOfOriginExporter;
            sbmodel.authorizedDealerCode = GetValue(gen, "ADCODE");
            sbmodel.epzCode = null;

            sbmodel.consigneeName = GetValue(gen, "CONSIGNEE_NAME");

            string CONSIGNEE_ADD1 = GetValue(gen, "CONSIGNEE_ADD1");
            string CONSIGNEE_ADD2 = GetValue(gen, "CONSIGNEE_ADD2");
            string CONSIGNEE_ADD3 = GetValue(gen, "CONSIGNEE_ADD3");
            string CONSIGNEE_ADD4 = GetValue(gen, "CONSIGNEE_ADD4");

            if (Connection.COMPANYID() != "148") // Condition added by Shanthini suggest by bala sir& praveen on 19-08-2026
            {
                string Consignee_All = CONSIGNEE_ADD1 + CONSIGNEE_ADD2 + CONSIGNEE_ADD3 + CONSIGNEE_ADD4; 
                string[] consigneeParts = new string[4];
                for (int i = 0; i < consigneeParts.Length && Consignee_All.Length > 0; i++)
                {
                    int length = Math.Min(35, Consignee_All.Length);
                    consigneeParts[i] = Consignee_All.Substring(0, length);
                    Consignee_All = Consignee_All.Remove(0, length);
                } 
                CONSIGNEE_ADD1 = consigneeParts[0];
                CONSIGNEE_ADD2 = consigneeParts[1];
                CONSIGNEE_ADD3 = consigneeParts[2];
                CONSIGNEE_ADD4 = consigneeParts[3];
            }

            sbmodel.consigneeAddress1 = CONSIGNEE_ADD1;
            sbmodel.consigneeAddress2 = CONSIGNEE_ADD2;
            sbmodel.consigneeAddress3 = CONSIGNEE_ADD3;
            sbmodel.consigneeAddress4 = CONSIGNEE_ADD4;

            sbmodel.consigneeCountry = CONSIGNEE_ADD5;
            sbmodel.categoryForNEFISB = (NEFISB != null && NEFISB.Length > 0 && NEFISB[0] != null) ? NEFISB[0].ToString() : null;
            sbmodel.rbiWaiverNo = GetValue(gen, "RBI_WAIVER_NO");
            sbmodel.rbiWaiverDate = GetValue(gen, "RBI_WAIVER_DATE");
            sbmodel.portOfLoading = CUSTOMS_HOUSE;
            sbmodel.portOfFinalDestination = portdes;
            sbmodel.countryOfFinalDestination = country_des;
            sbmodel.countryOfDischarge = country_dis;
            sbmodel.portOfDischarge = portdischarge;

            sbmodel.sealType = sealType;
            sbmodel.natureOfCargo = natureOfCargo;
            sbmodel.grossWeight = grossWeight;
            sbmodel.netWeight = netWeight;
            sbmodel.unitOfMeasurement = unitOfMeasurement;
            sbmodel.totalNumberOfPackages = totalNumberOfPackages;

            if (marksNumbers != null)
            {
                marksNumbers = marksNumbers.Length == 1 ? marksNumbers : marksNumbers.TrimEnd('.');
            }

            sbmodel.marksNumbers = marksNumbers;
            sbmodel.numberOfLoosePackets = numberOfLoosePackets;
            sbmodel.numberOfContainers = numberOfContainers;
            sbmodel.mawbnumber = mawbnumber;
            sbmodel.hawbnumber = hawbnumber;
            sbmodel.gstnType = GetValue(gen, "GSTN_TYPE");
            sbmodel.gstnId = GetValue(gen, "GSTN_ID");

           
            root.master.sbModel.Add(sbmodel);
        }

       

        // ================= RotationModel=================

        root.master.rotationModel = new List<RotationModel>();

        if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
        {
            foreach (DataRow rt in ds.Tables[2].Rows)
            {
                string ANNEX_AIR_ROTATION_NO = GetValue(rt, "ANNEX_AIR_ROTATION_NO");
                if (ANNEX_AIR_ROTATION_NO != "" && ANNEX_AIR_ROTATION_NO != null)
                {
                    RotationModel rm = new RotationModel
                    {
                        rotationNumber = GetValue(rt, "ANNEX_AIR_ROTATION_NO"),
                        rotationDate = GetValue(rt, "ANNEX_AIR_ROTATION_DATE"),

                    };

                    root.master.rotationModel.Add(rm);
                }
            }
        }






        // ================= STATEMENT =================

        root.master.statement = new List<StatementModel_Exp>();

        if (ds.Tables.Count > 19 && ds.Tables[19].Rows.Count > 0)
        {
            foreach (DataRow r in ds.Tables[19].Rows)
            {
                StatementModel_Exp stmt = new StatementModel_Exp
                {

                    invoiceSerialNumber = GetValue(r, "INVOICE_SLNO"),
                    itemSerialNumber = GetValue(r, "ITEM_SLNO"),
                    statementSerialNo = GetValue(r, "SLNO"),
                    statementType = GetValue(r, "STMT_TYPE"),
                    statementCode = GetValue(r, "STMT_CODE"),
                    statementText = GetValue(r, "STMT_TEXT")
                };

                root.master.statement.Add(stmt);
            }
        }
        // ================= SUPPORTING DOCS =================

        root.master.supportingDocs = new List<SupportingDocsModel_Exp>();

        if (ds.Tables.Count > 20 && ds.Tables[20].Rows.Count > 0)
        {
            foreach (DataRow row in ds.Tables[20].Rows)
            {
                SupportingDocsModel_Exp doc = new SupportingDocsModel_Exp();

                string SELECT_TYPE = dt.Trim(GetValue(row, "SELECT_TYPE").ToString());
                string INVOICE_SLNO = GetValue(row, "INVOICE_SLNO");
                string ITEM_SLNO = GetValue(row, "ITEM_SLNO");
                if (SELECT_TYPE == "JOB")
                {
                    INVOICE_SLNO = "0";
                    ITEM_SLNO = "0";
                }
                else if (SELECT_TYPE == "INVOICE")
                {
                    INVOICE_SLNO = INVOICE_SLNO;
                    ITEM_SLNO = "0";
                }
                else if (SELECT_TYPE == "ITEM")
                {
                    INVOICE_SLNO = INVOICE_SLNO;
                    ITEM_SLNO = ITEM_SLNO;
                }
                else
                {
                    INVOICE_SLNO = "0";
                    ITEM_SLNO = "0";
                }

                doc.invoiceSerialNumber = INVOICE_SLNO;
                doc.itemSerialNumber = ITEM_SLNO;
                doc.serialNo = GetValue(row, "SLNO");

                doc.imageReferenceNumber = GetValue(row, "UNIQUE_DOC_NUMBER");
                doc.documentTypeCode = GetValue(row, "DOC_TYPE_CODE");

                doc.documentIssuingPartyCode = GetValue(row, "DOC_ISSUING_PARTY_CODE");
                doc.documentIssuingPartyName = GetValue(row, "DOC_ISSUING_PARTY_NAME");
                doc.documentIssuingPartyNameAddress1 = GetValue(row, "DOC_ISSUING_PARTY_NAME_ADD1");
                doc.documentIssuingPartyNameAddress2 = GetValue(row, "DOC_ISSUING_PARTY_NAME_ADD2");
                doc.documentIssuingPartyNameCity = GetValue(row, "DOC_ISSUING_PARTY_CITY");
                doc.documentIssuingPartyNamePin = GetValue(row, "DOC_ISSUING_PARTY_PIN");

                doc.documentReferenceNo = GetValue(row, "DOC_REF_NUMBER");
                doc.placeOfIssue = GetValue(row, "PLACE_OF_ISSUE");
                doc.documentIssueDate = GetValue(row, "DOC_ISSUE_DATE");
                doc.documentExpiryDate = GetValue(row, "DOC_EXPIRY_DATE");

                doc.documentBeneficiaryPartyCode = GetValue(row, "BENEFICIARY_PARTY_CODE");
                doc.documentBeneficiaryPartyName = GetValue(row, "BENEFICIARY_PARTY_NAME");
                doc.documentBeneficiaryPartyNameAddress1 = GetValue(row, "BENEFICIARY_PARTY_ADDRESS1");
                doc.documentBeneficiaryPartyNameAddress2 = GetValue(row, "BENEFICIARY_PARTY_ADDRESS2");
                doc.documentBeneficiaryPartyNameCity = GetValue(row, "BENEFICIARY_PARTY_CITY");
                doc.documentBeneficiaryPartyNamePin = GetValue(row, "BENEFICIARY_PARTY_PIN");

                doc.fileType = GetValue(row, "FILE_TYPE");
                doc.icegateId = GetValue(row, "ICEGATE_ID");


                root.master.supportingDocs.Add(doc);
            }
        }
        // ================= THIRD PARTY MODEL =================

        //root.master.thirdPartyModel = new List<ThirdPartyModel_Exp>();

        //if (ds.Tables.Count > 5 && ds.Tables[5].Rows.Count > 0)
        //{
        //    foreach (DataRow row in ds.Tables[5].Rows)
        //    {
        //        ThirdPartyModel_Exp third = new ThirdPartyModel_Exp();

        //        string THIRDPARTY_NAME = GetValue(row, "THIRDPARTY_NAME");

        //        string IS_ThirdParty;
        //        if (THIRDPARTY_NAME != "" && THIRDPARTY_NAME != null)
        //        {
        //            IS_ThirdParty = "Y";

        //        }
        //        else
        //            IS_ThirdParty = null;

        //        if (IS_ThirdParty == "Y")
        //        {
        //            third.invoiceSerialNumber = GetValue(row, "INVOICE_SLNO");

        //            // Not available in table → set NULL (NOT empty string)
        //            third.itemSerialNumberInvoice = null;
        //            third.iec = null;
        //            third.branchSerialNo = null;

        //            third.exporterName = GetValue(row, "THIRDPARTY_NAME");
        //            third.exporterAddress1 = GetValue(row, "THIRDPARTY_ADD1");
        //            third.exporterAddress2 = GetValue(row, "THIRDPARTY_ADD2");
        //            third.city = GetValue(row, "THIRDPARTY_CITY");
        //            third.pin = GetValue(row, "T_PARTY_PIN");

        //            third.amendmentType = null;
        //            third.amendmentNumber = null;
        //            third.amendmentDate = null;

        //            third.gstnType = GetValue(row, "AUTHORIZED_ECONOMIC_OPERATOR");
        //            third.gstnId = GetValue(row, "AUTHORIZED_ECONOMIC_OPERATOR_CODE");
        //        }
        //        third.itemThirdPartyValue = IS_ThirdParty;


        //        root.master.thirdPartyModel.Add(third);
        //    }
        //}


        root.master.thirdPartyModel = null;

        if (ds.Tables.Count > 7 && ds.Tables[7].Rows.Count > 0)
        {
            List<ThirdPartyModel_Exp> thirdPartyList = new List<ThirdPartyModel_Exp>();

            foreach (DataRow row in ds.Tables[7].Rows)
            {
                string ITEM_EXPORTER_NAME = GetValue(row, "ITEM_EXPORTER_NAME");
                string ITEM_IECCODE = GetValue(row, "ITEM_IECCODE");
                string BR_SLNO = GetValue(row, "BR_SLNO");
                string ADDRESS1 = GetValue(row, "ADDRESS1");
                string ADDRESS2 = GetValue(row, "ADDRESS2");
                string ADDRESS3 = GetValue(row, "ADDRESS3");
                string ADDRESS4 = GetValue(row, "ADDRESS4");
                string ADDRESS5 = GetValue(row, "ADDRESS5");



                if (!string.IsNullOrEmpty(ITEM_EXPORTER_NAME))
                {
                    ThirdPartyModel_Exp third = new ThirdPartyModel_Exp();

                    third.invoiceSerialNumber = GetValue(row, "INVOICE_SLNO");
                    third.itemSerialNumberInvoice = GetValue(row, "ITEM_SLNO");
                    third.iec = GetValue(row, "ITEM_IECCODE");
                    third.branchSerialNo = GetValue(row, "BR_SLNO");
                    third.exporterName = GetValue(row, "ITEM_EXPORTER_NAME");
                    third.exporterAddress1 = GetValue(row, "ADDRESS1");
                    third.exporterAddress2 = GetValue(row, "ADDRESS2");
                    third.city = GetValue(row, "ADDRESS3"); //+ " " + GetValue(row, "ADDRESS4");
                    third.pin = GetValue(row, "ADDRESS5");
                    third.amendmentType = null;
                    third.amendmentNumber = null;
                    third.amendmentDate = null;
                    third.gstnType = GetValue(row, "GSTN_TYPE");
                    third.gstnId = GetValue(row, "GSTN_ID");

                    thirdPartyList.Add(third);
                    third.itemThirdPartyValue = "Y";
                }

            }

            // Only assign if list has data
            if (thirdPartyList.Count > 0)
                root.master.thirdPartyModel = thirdPartyList;

        }

        
        // ================= DBKModel =================

        root.master.dbkModel = new List<DBKModel_Exp>();

        if (ds.Tables.Count > 8 && ds.Tables[8].Rows.Count > 0)
        {
            foreach (DataRow r in ds.Tables[8].Rows)
            {
                DBKModel_Exp DBK = new DBKModel_Exp
                {
                    invoiceSerialNumber = GetValue(r, "INVOICE_SLNO"),
                    itemSerialNumberInvoice = GetValue(r, "ITEM_SLNO"),
                    dbkScheduleNumber = GetValue(r, "DRAWBACK_SLNO"),
                    drawbackQuantity = GetValue(r, "DRAWBACK_QTY"),
                    drawbackAvailable = GetValue(r, "drawbackAvailable"),
                };

                root.master.dbkModel.Add(DBK);
            }
        }
        // ================= ExchangeModel  =================

        //    HashSet<string> addedCurrencies = new HashSet<string>();

        //    root.master.exchangeModel = new List<ExchangeModel_Exp>();

        //    foreach (DataRow row in ds.Tables[5].Rows)
        //    {
        //        INVOICE_CURRENCY = GetValue(row, "INVOICE_CURRENCY");
        //        List<string> currencies = new List<string>()
        //{
        //    INVOICE_CURRENCY
        //};

        //        foreach (string currency in currencies)
        //        {
        //            if (string.IsNullOrEmpty(currency))
        //                continue;


        //            if (!addedCurrencies.Add(currency))
        //                continue;

        //            // -------- Existing Logic --------
        //            INVOICE_CURRENCY = currency;
        //             INVOICE_EXRATE = "";
        //             Standard_Currency = "Y";

        //            Get_Admin_Master_Codes();

        //            if (INVOICE_EXRATE == "")
        //            {
        //                DataView view2 = ds.Tables[22].DefaultView;
        //                view2.RowFilter = "NON_STD_CUR_CODE = '" + currency + "'";

        //                DataTable dt2 = view2.ToTable();

        //                if (dt2.Rows.Count > 0)
        //                {
        //                    NON_STD_EFFECT_DT_EXP = GetValue(dt2.Rows[0], "NON_STD_EFFECT_DT_IMP").Replace("19000101", "");
        //                    NON_STD_BANKNAME = GetValue(dt2.Rows[0], "NON_STD_BANKNAME");
        //                    NON_STD_CERTIFICATE_NO = GetValue(dt2.Rows[0], "NON_STD_CERTIFICATE_NO");
        //                    NON_STD_CERTIFICATE_DATE = GetValue(dt2.Rows[0], "NON_STD_CERTIFICATE_DATE").Replace("19000101", "");
        //                    INVOICE_EXRATE = GetValue(dt2.Rows[0], "NON_STD_RATE_IMPORT");

        //                    Standard_Currency = "N";
        //                }
        //            }

        //            // -------- Add To Model --------

        //            ExchangeModel_Exp ex = new ExchangeModel_Exp();
        //            Date_Time dt = new Date_Time();

        //            ex.invoiceCurrencyCode = currency;
        //            ex.whetherStandardCurrency = Standard_Currency;
        //            ex.unitInRs = dt.Get_Exchange_PerUnit(currency);
        //            ex.rate = INVOICE_EXRATE;
        //            ex.effectiveDate = NON_STD_EFFECT_DT_EXP;
        //            root.master.exchangeModel.Add(ex);

        //        }
        //    }


        HashSet<string> addedCurrencies = new HashSet<string>();
        root.master.exchangeModel = new List<ExchangeModel_Exp>();
        foreach (DataRow row in ds.Tables[5].Rows)
        {

            INVOICE_CURRENCY = GetValue(row, "INVOICE_CURRENCY");
            COMMISSION_CURRENCY = GetValue(row, "COMMISSION_CURRENCY");
            FOB_CURRENCY = GetValue(row, "FOB_CURRENCY");
            PACKMISC_CURRENCY = GetValue(row, "PACKMISC_CURRENCY");
            OTHER_DEDUCTION_CURRENCY = GetValue(row, "OTHER_DEDUCTION_CURRENCY");
            FREIGHT_CURRENCY = GetValue(row, "FREIGHT_CURRENCY");
            INSURANCE_CURRENCY = GetValue(row, "INSURANCE_CURRENCY");

            List<string> currencies = new List<string>()
 
    {
 
        INVOICE_CURRENCY,
        COMMISSION_CURRENCY,
        FOB_CURRENCY,
        PACKMISC_CURRENCY,
        OTHER_DEDUCTION_CURRENCY,
        FREIGHT_CURRENCY,
        INSURANCE_CURRENCY
 
    };
            foreach (string currency in currencies)
            {

                if (string.IsNullOrEmpty(currency))

                    continue;


                if (!addedCurrencies.Add(currency))

                    continue;
                // -------- Existing Logic --------

                INVOICE_CURRENCY = currency;

                INVOICE_EXRATE = "";

                Standard_Currency = "Y";
                NON_STD_EFFECT_DT_EXP = null;
                NON_STD_BANKNAME = null;
                NON_STD_CERTIFICATE_NO = null;
                NON_STD_CERTIFICATE_DATE = null;
                Get_Admin_Master_Codes();
                if (INVOICE_EXRATE == "")
                {

                    DataView view2 = ds.Tables[22].DefaultView;

                    view2.RowFilter = "NON_STD_CUR_CODE = '" + currency + "'";
                    DataTable dt2 = view2.ToTable();
                    if (dt2.Rows.Count > 0)
                    {
                        var val = GetValue(dt2.Rows[0], "NON_STD_EFFECT_DT_EXP");
                        NON_STD_EFFECT_DT_EXP = val == "19000101" ? "" : Convert.ToDateTime(val).ToString("yyyyMMdd");
                        NON_STD_BANKNAME = GetValue(dt2.Rows[0], "NON_STD_BANKNAME");
                        NON_STD_CERTIFICATE_NO = GetValue(dt2.Rows[0], "NON_STD_CERTIFICATE_NO");
                        var val1 = GetValue(dt2.Rows[0], "NON_STD_CERTIFICATE_DATE");
                        NON_STD_CERTIFICATE_DATE = val == "19000101" ? "" : Convert.ToDateTime(val1).ToString("yyyyMMdd");
                        INVOICE_EXRATE = GetValue(dt2.Rows[0], "NON_STD_RATE_EXPORT");
                        Standard_Currency = "N";

                    }

                }
                // -------- Add To Model --------
                ExchangeModel_Exp ex = new ExchangeModel_Exp();

                Date_Time dt = new Date_Time();
                ex.invoiceCurrencyCode = currency;

                ex.whetherStandardCurrency = Standard_Currency;

                ex.unitInRs = dt.Get_Exchange_PerUnit(currency);

                ex.rate = INVOICE_EXRATE;

                ex.effectiveDate = NON_STD_EFFECT_DT_EXP;

                root.master.exchangeModel.Add(ex);


            }

        }




        // // ================= SBModel =================

        //root.master.sbModel = new List<SBModel_Exp>();

        //if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //{
        //    foreach (DataRow gen in ds.Tables[0].Rows)
        //    {
        //         STATE_OF_EXPORT = GetValue(gen, "STATE_OF_EXPORT");
        //         PORT_OF_LOADING = GetValue(gen, "PORT_OF_LOADING");
        //         PORT_FINAL_DEST = GetValue(gen, "PORT_FINAL_DEST");
        //        string categoryNEFISB = GetValue(gen, "NFEI_TYPE");
        //         CONSIGNEE_ADD5 = GetValue(gen, "CONSIGNEE_ADD5");
        //        string[] NEFISB = new string[0];

        //        if (!string.IsNullOrEmpty(categoryNEFISB))
        //        {
        //            NEFISB = categoryNEFISB.Split('-');
        //        }
        //         COUNTRY_DISCHARGE = GetValue(gen, "COUNTRY_DISCHARGE");
        //         COUNTRY_FINAL_DEST = GetValue(gen, "COUNTRY_FINAL_DEST");
        //         PORT_DISCHARGE = GetValue(gen, "PORT_DISCHARGE");

        //        Get_Admin_Master_Codes();
        //        string portdes = PORT_FINAL_DEST;
        //        string stateOfOriginExporter = STATE_OF_EXPORT;
        //        string portOfLoad = PORT_OF_LOADING;
        //        string country_dis = COUNTRY_DISCHARGE;
        //        string country_des = COUNTRY_FINAL_DEST;
        //        string portdischarge = PORT_DISCHARGE;


        //        if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
        //        {
        //            sealType = GetValue(gen, "AR4_INVOICE_SLNO");
        //            natureOfCargo = GetValue(gen, "NATURE_OF_CARGO");
        //            grossWeight = GetValue(gen, "ANNEX_SEA_GROSS_WEIGHT");
        //            netWeight = GetValue(gen, "ANNEX_SEA_NET_WEIGHT");
        //            unitOfMeasurement = GetValue(gen, "ANNEX_SEA_UNIT_MEASUREMENT");
        //            totalNumberOfPackages = GetValue(gen, "ANNEX_SEA_TOTAL_PACKAGES");
        //            marksNumbers = GetValue(gen, "ANNEX_SEA_MARKS_NOS");
        //            numberOfLoosePackets = GetValue(gen, "ANNEX_SEA_LOOSE_PACKETS");

        //            numberOfContainers = GetValue(gen, "ANNEX_SEA_NO_CONTAINERS");
        //            mawbnumber = GetValue(gen, "ANNEX_AIR_MAWB_NO");
        //            hawbnumber = GetValue(gen, "ANNEX_AIR_HAWB_NO");

        //        }

        //        SBModel_Exp sbmodel = new SBModel_Exp
        //        {

        //            chaLicenseNumber = GetValue(gen, "AR4_JOBNO"),
        //            importerExporterCode = GetValue(gen, "IEC_NO"),
        //            branchSrNoOfExporter = GetValue(gen, "BRANCH_NO"),
        //            impExpName = GetValue(gen, "EXPORTER_NAME"),
        //            impExpAddress1 = GetValue(gen, "ADDRESS1"),
        //            impExpAddress2 = GetValue(gen, "ADDRESS2"),
        //            impExpCity = GetValue(gen, "ADDRESS3"),
        //            impExpState = GetValue(gen, "ADDRESS4"),
        //            impExpPin = GetValue(gen, "ADDRESS5"),
        //            typeOfExporter = GetValue(gen, "TYPE_OF_EXPORTER"),
        //            exporterClass = GetValue(gen, "IMP_EXP_TYPE"),

        //            stateOfOriginExporter = stateOfOriginExporter,

        //            authorizedDealerCode = GetValue(gen, "ADCODE"),
        //            epzCode = "",
        //            consigneeName = GetValue(gen, "CONSIGNEE_NAME"),
        //            consigneeAddress1 = GetValue(gen, "CONSIGNEE_ADD1"),
        //            consigneeAddress2 = GetValue(gen, "CONSIGNEE_ADD2"),
        //            consigneeAddress3 = GetValue(gen, "CONSIGNEE_ADD3"),
        //            consigneeAddress4 = GetValue(gen, "CONSIGNEE_ADD4"),
        //            consigneeCountry = GetValue(gen, "CONSIGNEE_ADD5"),
        //            categoryForNEFISB = (NEFISB != null && NEFISB.Length > 0 && NEFISB[0] != null)? NEFISB[0].ToString(): "",
        //            rbiWaiverNo = GetValue(gen, "RBI_WAIVER_NO"),
        //            rbiWaiverDate = GetValue(gen, "RBI_WAIVER_DATE"),
        //            portOfLoading = portOfLoad,
        //            portOfFinalDestination = portdes,
        //            countryOfFinalDestination = country_des,
        //            countryOfDischarge = country_dis,
        //            portOfDischarge = portdischarge,


        //            sealType = sealType,
        //            natureOfCargo = natureOfCargo,
        //            grossWeight = grossWeight,
        //            netWeight = netWeight,
        //            unitOfMeasurement = unitOfMeasurement,
        //            totalNumberOfPackages = totalNumberOfPackages,
        //            marksNumbers = marksNumbers,
        //            numberOfLoosePackets = numberOfLoosePackets,

        //            numberOfContainers = numberOfContainers,
        //            mawbnumber = mawbnumber,
        //            hawbnumber = hawbnumber,
        //            gstnType = GetValue(gen, "GSTN_TYPE"),
        //            gstnId = GetValue(gen, "GSTN_ID"),


        //        };

        //        root.master.sbModel.Add(sbmodel);
        //    }
        //}



        // ================= StuffModel=================

        root.master.stuffModel = new List<StuffModel>();

        if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
        {
            foreach (DataRow st in ds.Tables[2].Rows)
            {
                string ANNEX_SEA_FAC_STUFFED = GetValue(st, "ANNEX_SEA_FAC_STUFFED");
                if (ANNEX_SEA_FAC_STUFFED != null && ANNEX_SEA_FAC_STUFFED != "")
                {

                    StuffModel ex = new StuffModel
                    {
                        factoryStuffed = GetValue(st, "ANNEX_SEA_FAC_STUFFED"),
                        sampleAccompanied = GetValue(st, "ANNEX_SEA_SAMPLE_ACCOM"),

                    };

                    root.master.stuffModel.Add(ex);
                }
            }
        }


        // ================= SERIALIZE =================
        RemoveEmptyLists_Exp(root);
        var settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        };

        string json = JsonConvert.SerializeObject(
            root,
            Formatting.Indented,
            settings);

        File.WriteAllText(filePath, json);

    }
    private string GetValue(DataRow row, string columnName)
    {
        if (row.Table.Columns.Contains(columnName) &&
            row[columnName] != DBNull.Value)
        {
            string value = row[columnName].ToString().Trim();

            return string.IsNullOrEmpty(value) ? null : value;
        }

        return null;
    }
    private List<T> NullIfEmpty<T>(List<T> list)
    {
        return (list == null || list.Count == 0) ? null : list;
    }
    private void RemoveEmptyLists_Exp(RootModelexp root)
    {
        if (root.master.ar4Model != null && root.master.ar4Model.Count == 0)
            root.master.ar4Model = null;

        if (root.master.cessModel != null && root.master.cessModel.Count == 0)
            root.master.cessModel = null;

        if (root.master.constituentFinal != null && root.master.constituentFinal.Count == 0)
            root.master.constituentFinal = null;

        if (root.master.containerModel != null && root.master.containerModel.Count == 0)
            root.master.containerModel = null;

        if (root.master.controlType != null && root.master.controlType.Count == 0)
            root.master.controlType = null;

        if (root.master.dbkModel != null && root.master.dbkModel.Count == 0)
            root.master.dbkModel = null;

        if (root.master.eouModel != null && root.master.eouModel.Count == 0)
            root.master.eouModel = null;

        if (root.master.exchangeModel != null && root.master.exchangeModel.Count == 0)
            root.master.exchangeModel = null;

        if (root.master.infoType != null && root.master.infoType.Count == 0)
            root.master.infoType = null;

        if (root.master.invoiceModel != null && root.master.invoiceModel.Count == 0)
            root.master.invoiceModel = null;

        if (root.master.itemAccessModel != null && root.master.itemAccessModel.Count == 0)
            root.master.itemAccessModel = null;

        if (root.master.itemModel != null && root.master.itemModel.Count == 0)
            root.master.itemModel = null;

        if (root.master.jobWorkModel != null && root.master.jobWorkModel.Count == 0)
            root.master.jobWorkModel = null;

        if (root.master.licenceModel != null && root.master.licenceModel.Count == 0)
            root.master.licenceModel = null;

        if (root.master.packingListModel != null && root.master.packingListModel.Count == 0)
            root.master.packingListModel = null;

        if (root.master.production != null && root.master.production.Count == 0)
            root.master.production = null;

        if (root.master.reexport != null && root.master.reexport.Count == 0)
            root.master.reexport = null;

        if (root.master.rotationModel != null && root.master.rotationModel.Count == 0)
            root.master.rotationModel = null;

        if (root.master.sbModel != null && root.master.sbModel.Count == 0)
            root.master.sbModel = null;

        if (root.master.statement != null && root.master.statement.Count == 0)
            root.master.statement = null;

        if (root.master.stuffModel != null && root.master.stuffModel.Count == 0)
            root.master.stuffModel = null;

        if (root.master.supportingDocs != null && root.master.supportingDocs.Count == 0)
            root.master.supportingDocs = null;

        if (root.master.thirdPartyModel != null && root.master.thirdPartyModel.Count == 0)
            root.master.thirdPartyModel = null;
    }
}


public class RootModelexp
{
    public HeaderField_Exp headerField { get; set; }
    public master_Exp master { get; set; }
}

public class HeaderField_Exp
{
    public string senderID { get; set; }
    public string receiverID { get; set; }
    public string indicator { get; set; }
    public string messageID { get; set; }
    public string sequenceOrControlNumber { get; set; }
    public string jobNumber { get; set; }
    public string jobDate { get; set; }
    public string messageType { get; set; }
}
public class itemAccessModel_Exp
{

    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumber { get; set; }
    public string descriptionOfAccessories { get; set; }
    public string itemAccessoriesDescription { get; set; }
}
public class master_Exp
{
    public List<AR4Model> ar4Model { get; set; }
    public List<CessModel> cessModel { get; set; }
    public List<ConstituentFinal> constituentFinal { get; set; }
    public List<ContainerModel_Exp> containerModel { get; set; }
    public List<ControlModel_Exp> controlType { get; set; }
    public List<DBKModel_Exp> dbkModel { get; set; }
    //public List<depbModel_Exp> DEPBModel { get; set; }
    //public List<depbParentModel_Exp> DEPBParentModel { get; set; }
    //  public List<DfiaModel> DfiaModel { get; set; }

    public List<EOUModel> eouModel { get; set; }
    public List<ExchangeModel_Exp> exchangeModel { get; set; }

    public List<InfoTypeModel> infoType { get; set; }
    public List<InvoiceModel_Exp> invoiceModel { get; set; }
    public List<itemAccessModel_Exp> itemAccessModel { get; set; }
    public List<ItemModel_Exp> itemModel { get; set; }
    //public List<itemRawMaterialModel_Exp> ItemRawMaterialModel { get; set; }
    public List<jobWorkModel_Exp> jobWorkModel { get; set; }

    public List<LicenseModel_Exp> licenceModel { get; set; }

    public List<PackingListModel_Exp> packingListModel { get; set; }
    public List<ProductionModel_Exp> production { get; set; }
    public List<ReexportModel_Exp> reexport { get; set; }
    public List<RotationModel> rotationModel { get; set; }
    public List<SBModel_Exp> sbModel { get; set; }
    //public List<servTaxRefund_Exp> ServTaxRefund { get; set; }

    public List<StatementModel_Exp> statement { get; set; }
    public List<StuffModel> stuffModel { get; set; }
    public List<SupportingDocsModel_Exp> supportingDocs { get; set; }
    public List<ThirdPartyModel_Exp> thirdPartyModel { get; set; }

    //public List<CargoBackModel_Exp> CargoBack { get; set; }
    //public List<ControlModel_Exp> ControlType { get; set; }



}
public class AR4Model
{
    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumberInvoice { get; set; }
    public string ar4Number { get; set; }
    public string ar4Date { get; set; }
    public string commissionerate { get; set; }
    public string division { get; set; }
    public string range { get; set; }
    public string remarks { get; set; }
}
public class CessModel
{
    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumberInvoice { get; set; }
    public string srno { get; set; }
    public string cessActCode { get; set; }
    public string quantity { get; set; }
    public string itemCessValue { get; set; }
}
public class ConstituentFinal
{
    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumber { get; set; }
    public string constituentSerialNo { get; set; }
    public string constituentElementName { get; set; }
    public string constituentElementCode { get; set; }
    public string constituentPercentage { get; set; }
    public string constituentYieldPercentage { get; set; }
    public string activeIngredient { get; set; }
}
public class ContainerModel_Exp
{
    public string containerNumber { get; set; }
    public string containerSize { get; set; }
    public string exciseSealNo { get; set; }
    public string sealDate { get; set; }
    public string sealTypeIndicator { get; set; }
    public string sealDeviceID { get; set; }
    public string movementDocumentType { get; set; }
    public string movementDocumentNumber { get; set; }
    public string eqmntType { get; set; }
    public string eqmntQty { get; set; }
    public string eqmntQtyCode { get; set; }
}
public class ControlModel_Exp
{
    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumber { get; set; }
    public string controlSerialNo { get; set; }
    public string controlTypeCode { get; set; }
    public string controlLocation { get; set; }
    public string controlStartDate { get; set; }
    public string controlEndDate { get; set; }
    public string controlResultCode { get; set; }
    public string controlResultRemarks { get; set; }
}
public class DfiaModel
{
    public string jobNumber { get; set; }
    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumberInvoice { get; set; }
    public string srno { get; set; }
    public string quantity { get; set; }
    public string unitOfMeasurement { get; set; }
    public string itemDescription { get; set; }
    public string licenseNumber { get; set; }
}
public class EOUModel
{
    public string jobNumber { get; set; }
    public string ieCodeOfTheEOU { get; set; }
    public string branchSrNumberOfIE { get; set; }
    public string examinationDate { get; set; }
    public string examiningOfficerName { get; set; }
    public string examiningOfficerDesignation { get; set; }
    public string supervisingOfficerName { get; set; }
    public string supervisingOfficerDesignation { get; set; }
    public string commissionerate { get; set; }
    public string division { get; set; }
    public string range { get; set; }
    public string sealNo { get; set; }
    public string itemValuesVerifiedByExaminingOfficer { get; set; }
    public string sampleForwarded { get; set; }
}
public class InfoTypeModel
{
    public string jobNumber { get; set; }
    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumber { get; set; }
    public string infoSrNo { get; set; }
    public string infoType { get; set; }
    public string infoQualifier { get; set; }
    public string infoCode { get; set; }
    public string infoText { get; set; }
    public string infoMeasure { get; set; }
    public string infouqc { get; set; }
}
public class InvoiceModel_Exp
{
    public string invoiceSerialNumber { get; set; }
    public string actualInvoiceNo { get; set; }
    public string invoiceDate { get; set; }
    public string invoiceCurrency { get; set; }
    public string natureOfContract { get; set; }

    public string buyerName { get; set; }
    public string buyerAddress1 { get; set; }
    public string buyerAddress2 { get; set; }
    public string buyerAddress3 { get; set; }
    public string buyerAddress4 { get; set; }

    public string freightCurrency { get; set; }
    public string freightAmount { get; set; }

    public string insuranceRate { get; set; }
    public string insuranceCurrency { get; set; }
    public string insuranceAmount { get; set; }

    public string commissionRate { get; set; }
    public string commissionCurrency { get; set; }
    public string commissionAmount { get; set; }

    public string discountOnFOB { get; set; }
    public string discountCurrency { get; set; }
    public string discountAmount { get; set; }

    public string otherDeductions { get; set; }
    public string otherDeductionsCurrency { get; set; }
    public string otherDeductionsAmount { get; set; }

    public string packingCharges { get; set; }
    public string addFreight { get; set; }
    public string exporterContractNumber { get; set; }
    public string natureOfPayment { get; set; }
    public string periodOfPayment { get; set; }

    public string thirdPartyName { get; set; }
    public string thirdPartyAddress1 { get; set; }
    public string thirdPartyAddress2 { get; set; }
    public string thirdPartyCity { get; set; }
    public string thirdPartyCountrySubdivision { get; set; }
    public string thirdPartCountryCode { get; set; }
    public string thirdPartyPin { get; set; }

    public string authorizedEconomicOperatorCode { get; set; }
    public string authorizedEconomicOperatorCountry { get; set; }
    public string authorizedEconomicOperatorRole { get; set; }

    public string termsPlace { get; set; }
}
public class LicenseModel_Exp
{
    public string jobNumber { get; set; }
    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumberInvoice { get; set; }
    public string srno { get; set; }

    public string registrationNo { get; set; }
    public string registrationDate { get; set; }

    public string itemSerialNoInPartE { get; set; }
    public string itemSerialNoInPartC { get; set; }
    public string quantity { get; set; }
    public string exportQuantity { get; set; }

    public string whetherIndigenousImported { get; set; }
}
public class ItemModel_Exp
{
    public string jobNumber { get; set; }
    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumberInvoice { get; set; }

    public string schemeCode { get; set; }
    public string ritcCode { get; set; }
    public string descOfGoods1 { get; set; }
    public string descOfGoods2 { get; set; }
    public string descOfGoods3 { get; set; }
    public string unitOfMeasurement { get; set; }
    public string quantity { get; set; }
    public string unitPrice { get; set; }
    public string unitOfRate { get; set; }
    public string noOfUnit { get; set; }

    public string presentMarketValue { get; set; }
    public string thirdParty { get; set; }
    public string rewardItem { get; set; }

    public string itemManufacturerProducerGrowerCode { get; set; }
    public string itemManufacturerProducerGrowerAddress1 { get; set; }
    public string itemManufacturerProducerGrowerAddress2 { get; set; }
    public string itemManufacturerProducerGrowerCity { get; set; }
    public string itemManufacturerProducerGrowerCountrySubdivisiob { get; set; }
    public string itemManufacturerProducerGrowerPin { get; set; }
    public string itemManufacturerCountry { get; set; }

    public string sourceState { get; set; }
    public string transitCountry { get; set; }
    public string accessoryStatus { get; set; }
    public string endUseOfItem { get; set; }

    public string hawbNo { get; set; }
    public string totalPackage { get; set; }

    public string igstPaymentStatus { get; set; }
    public string taxableValue { get; set; }
    public string igstAmount { get; set; }
    
}
public class PackingListModel_Exp
{
    public string jobNumber { get; set; }
    public string packingNumberFrom { get; set; }
    public string packingNumberTo { get; set; }
    public string packingCode { get; set; }
}
public class ProductionModel_Exp
{
    public string jobNumber { get; set; }
    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumber { get; set; }

    public string productionSerialNo { get; set; }
    public string productionBatchIdentifier { get; set; }
    public string productionBatchQuantity { get; set; }
    public string unitQuantityCode { get; set; }

    public string dateOfManufacturing { get; set; }
    public string dateOfExpiry { get; set; }
    public string bestBefore { get; set; }
}
public class ReexportModel_Exp
{
    public string jobNumber { get; set; }

    public string sbNumber { get; set; }
    public string sbDate { get; set; }

    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumber { get; set; }
    public string serialNo { get; set; }

    public string beSite { get; set; }
    public string beNo { get; set; }
    public string beDate { get; set; }

    public string beInvoiceNo { get; set; }
    public string beItem { get; set; }
    public string manualBe { get; set; }

    public string beQuantityUtilised { get; set; }
    public string beItemDescription { get; set; }

    public string beQty { get; set; }
    public string beUqc { get; set; }

    public string beAssessedValue { get; set; }
    public string beDutyPaid { get; set; }
    public string beDutyPaymentDate { get; set; }

    public string beOtherIdentifiableParameter { get; set; }
    public string beAssessableValueClaimed { get; set; }

    public string beItemUsed { get; set; }
    public string commisionerPermission { get; set; }
    public string inputCredit { get; set; }
    public string personalUse { get; set; }

    public string modvaAvailed { get; set; }
    public string modvatRepaid { get; set; }
}
public class StatementModel_Exp
{

    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumber { get; set; }

    public string statementSerialNo { get; set; }
    public string statementType { get; set; }
    public string statementCode { get; set; }
    public string statementText { get; set; }
}
public class SupportingDocsModel_Exp
{

    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumber { get; set; }
    public string serialNo { get; set; }

    public string imageReferenceNumber { get; set; }
    public string documentTypeCode { get; set; }

    public string documentIssuingPartyCode { get; set; }
    public string documentIssuingPartyName { get; set; }
    public string documentIssuingPartyNameAddress1 { get; set; }
    public string documentIssuingPartyNameAddress2 { get; set; }
    public string documentIssuingPartyNameCity { get; set; }
    public string documentIssuingPartyNamePin { get; set; }

    public string documentReferenceNo { get; set; }
    public string placeOfIssue { get; set; }
    public string documentIssueDate { get; set; }
    public string documentExpiryDate { get; set; }

    public string documentBeneficiaryPartyCode { get; set; }
    public string documentBeneficiaryPartyName { get; set; }
    public string documentBeneficiaryPartyNameAddress1 { get; set; }
    public string documentBeneficiaryPartyNameAddress2 { get; set; }
    public string documentBeneficiaryPartyNameCity { get; set; }
    public string documentBeneficiaryPartyNamePin { get; set; }

    public string fileType { get; set; }
    public string icegateId { get; set; }
}
public class ThirdPartyModel_Exp
{

    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumberInvoice { get; set; }

    public string iec { get; set; }
    public string branchSerialNo { get; set; }

    public string exporterName { get; set; }
    public string exporterAddress1 { get; set; }
    public string exporterAddress2 { get; set; }
    public string city { get; set; }
    public string pin { get; set; }
    public string amendmentType { get; set; }
    public string amendmentNumber { get; set; }
    public string amendmentDate { get; set; }

    public string gstnType { get; set; }
    public string gstnId { get; set; }

    public string itemThirdPartyValue { get; set; }
}
public class CargoBackModel_Exp
{
    public string messageType { get; set; }

    public string sbNumber { get; set; }
    public string sbDate { get; set; }

    public string natureOfCargo { get; set; }
    public string loosePacketsLeft { get; set; }

    public string totalPacketsLeft { get; set; }
    public string noOfContainersLeft { get; set; }

    public string grossWeightLeft { get; set; }
    public string netWeightLeft { get; set; }

    public string uniqueQuantityCode { get; set; }

    public string amendmentType { get; set; }
    public string amendmentNumber { get; set; }
    public string amendmentDate { get; set; }
}
public class DBKModel_Exp
{


    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumberInvoice { get; set; }

    public string dbkScheduleNumber { get; set; }
    public string drawbackQuantity { get; set; }

    public string drawbackAvailable { get; set; }
}
public class ExchangeModel_Exp
{

    public string invoiceCurrencyCode { get; set; }
    public string currencyName { get; set; }
    public string unitInRs { get; set; }
    public string rate { get; set; }
    public string effectiveDate { get; set; }
    public string whetherStandardCurrency { get; set; }

}
public class StuffModel
{
    public string factoryStuffed { get; set; }
    public string sampleAccompanied { get; set; }
}
public class RotationModel
{
    public string rotationDate { get; set; }
    public string rotationNumber { get; set; }
}
public class SBModel_Exp
{

    public string chaLicenseNumber { get; set; }
    public string importerExporterCode { get; set; }
    public string branchSrNoOfExporter { get; set; }
    public string impExpName { get; set; }
    public string impExpAddress1 { get; set; }
    public string impExpAddress2 { get; set; }
    public string impExpCity { get; set; }
    public string impExpState { get; set; }
    public string impExpPin { get; set; }
    public string typeOfExporter { get; set; }
    public string exporterClass { get; set; }
    public string stateOfOriginExporter { get; set; }

    public string authorizedDealerCode { get; set; }
    public string epzCode { get; set; }

    public string consigneeName { get; set; }



    public string consigneeAddress1 { get; set; }
    public string consigneeAddress2 { get; set; }

    public string consigneeAddress3 { get; set; }
    public string consigneeAddress4 { get; set; }

    public string consigneeCountry { get; set; }



    public string categoryForNEFISB { get; set; }


    public string rbiWaiverNo { get; set; }
    public string rbiWaiverDate { get; set; }

    public string portOfLoading { get; set; }



    public string portOfFinalDestination { get; set; }
    public string countryOfFinalDestination { get; set; }

    public string countryOfDischarge { get; set; }
    public string portOfDischarge { get; set; }

    public string sealType { get; set; }



    public string natureOfCargo { get; set; }
    public string grossWeight { get; set; }

    public string netWeight { get; set; }
    public string unitOfMeasurement { get; set; }

    public string totalNumberOfPackages { get; set; }


    public string marksNumbers { get; set; }
    public string numberOfLoosePackets { get; set; }

    public string numberOfContainers { get; set; }
    public string mawbnumber { get; set; }

    public string hawbnumber { get; set; }



    public string gstnType { get; set; }
    public string gstnId { get; set; }



}
public class jobWorkModel_Exp
{
    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumberInvoice { get; set; }
    public string srno { get; set; }
    public string beNumber { get; set; }
    public string beDate { get; set; }
    public string beInvoiceSerialNo { get; set; }
    public string beInvoiceNumber { get; set; }
    public string beItemNumber { get; set; }
    public string bePortCode { get; set; }
    public string beQtyUsed { get; set; }
    public string qtyUnits { get; set; }
}
