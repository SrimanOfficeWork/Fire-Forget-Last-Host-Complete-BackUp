using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;


public class Flatfile_Json
{
    private string _JOBNO;
    public DataSet ds = new DataSet();
    private string _Ename;
    public string _Inv_Slno;
    public string COUNTRY_ORIGIN = null, COUNTRY_SHIPMENT = null, PORT_ORIGIN = null, PORT_SHIPMENT = null, INVOICE_CURRENCY = null, ExemptingIgstFlag = null;
    public string INVOICE_EXRATE = null, ANTI_DUMPING_NOTN = null, ANTI_DUMPING_NOTN_SLNO = null, CTH_QTY = null;
    string[] SCHEME_CODE = null;
    public string Standard_Currency = null, WHETHER_REIMPORT = null, STMT_TEXT = null,BETYPE=null;
    string[] Str_Bond_Location;
    public string NON_STD_EFFECT_DT_IMP = null;
    public string bond_Location;
    public string NON_STD_BANKNAME = null;

    public string NON_STD_CERTIFICATE_NO = null;

    public string NON_STD_CERTIFICATE_DATE = null;
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


    //public DataSet Get_Imp_ChkList_All_New(string ICEGATE_ID, string logFileName, string errorFolder, string CHA_NO)
    //{
    //    try
    //    {
    //        SqlParameter[] param = new SqlParameter[10];
    //        param[2] = new SqlParameter("@Jobno", JOBNo);
    //        param[4] = new SqlParameter("@Branch_Common", Connection.Current_Branch());
    //        param[5] = new SqlParameter("@COMPANY_LICENSE", Connection.COMPANYID());
    //        param[6] = new SqlParameter("@flag", Ename);
    //        param[7] = new SqlParameter("@Inv_Slno", Inv_Slno);

    //        param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
    //        param[9].Direction = ParameterDirection.Output;
    //        ds = Connection.Get_Dataset("IMP_JSON_SELECT_ALL_NEW", param);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            JSON_FOR_IMP(ds, ICEGATE_ID, errorFolder + logFileName, CHA_NO);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Connection.Error_Msg(ex.Message);
    //    }
    //    return ds;

    //}


    public DataSet Get_Imp_ChkList_All_New(string ICEGATE_ID, string logFileName, string errorFolder, string CHA_NO,
                                        string jobNumberOverride, string sequenceOverride)   // ← 2 புது parameter
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[2] = new SqlParameter("@Jobno", JOBNo);
            param[4] = new SqlParameter("@Branch_Common", Connection.Current_Branch());
            param[5] = new SqlParameter("@COMPANY_LICENSE", Connection.COMPANYID());
            param[6] = new SqlParameter("@flag", Ename);
            param[7] = new SqlParameter("@Inv_Slno", Inv_Slno);
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("IMP_JSON_SELECT_ALL_NEW", param);
            if (ds.Tables[0].Rows.Count > 0)
            {
                JSON_FOR_IMP(ds, ICEGATE_ID, errorFolder + logFileName, CHA_NO,
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
    private string TrimDot(string value)
    {
        if (string.IsNullOrEmpty(value))
            return value;

        return value.Length == 1 ? value : value.TrimEnd('.');
    }
    public string GetValue_INV(DataRow row, string columnName)
    {
        if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
        {
            string value = row[columnName].ToString().Trim();

            // If value is 0 or 0.00 or 0.000 etc → return empty
            if (value == "" || value == "0" || value == "0.00" || value == "0.000" || value == "0.0000")
                return null;

            return value;
        }

        return null;
    }
    public string Get_Exchange_PerUnit(string Currency)
    {
        if (Currency == "JPY" || Currency == "KRW")
            Currency = "100";
        else
            Currency = "1";
        return Currency;
    }
    public void Get_Admin_Master_Codes()
    {
        DataSet dss = new DataSet();
        Date_Time split = new Date_Time();
        string IMPORTER_CLASS = "N";
        Export_FlatFile_Generation Imp_FlatFile = new Export_FlatFile_Generation();
        Imp_FlatFile.Ename = "IMPORT_SELECT";

        dss = Imp_FlatFile.Search_Admin_Master();
        DataView view1 = dss.Tables[0].DefaultView;

        view1 = dss.Tables[1].DefaultView;
        view1.RowFilter = "COUNTRY_NAME = '" + split.Split("-", COUNTRY_ORIGIN) + "'";
        DataSet dt_1 = new DataSet();
        dt_1.Tables.Add(view1.ToTable());
        if (dt_1.Tables[0].Rows.Count > 0)
        {
            COUNTRY_ORIGIN = dt_1.Tables[0].Rows[0]["COUNTRY_CODE"].ToString();
        }
        view1 = dss.Tables[1].DefaultView;

        view1.RowFilter = "COUNTRY_NAME = '" + split.Split("-", COUNTRY_SHIPMENT) + "'";

        DataSet ds1 = new DataSet();
        ds1.Tables.Add(view1.ToTable());
        if (ds1.Tables[0].Rows.Count > 0)
        {
            COUNTRY_SHIPMENT = ds1.Tables[0].Rows[0]["COUNTRY_CODE"].ToString();
        }
        if (PORT_ORIGIN.Contains("-"))
        {
            PORT_ORIGIN = split.Split_main("-", PORT_ORIGIN);
        }

        if (PORT_SHIPMENT.Contains("-"))
        {

            PORT_SHIPMENT = split.Split_main("-", PORT_SHIPMENT);
        }

        if (INVOICE_CURRENCY != null)
        {
            DataView view2 = dss.Tables[3].DefaultView;
            view2.RowFilter = "EXCHANGE_CUR_CODE = '" + INVOICE_CURRENCY + "'";
            DataSet dt_2 = new DataSet();
            dt_2.Tables.Add(view2.ToTable());

            if (dt_2.Tables[0].Rows.Count > 0)
            {
                INVOICE_EXRATE = dt_2.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString();
                Standard_Currency = "Y";

            }
        }
    }







    //private void JSON_FOR_IMP(DataSet ds, string ICEGATE_ID, string filePath, string CHA_NO)
    //{
    //    if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
    //        return;

    //    string beNumber = null, beDate = null;

    //    if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
    //    {
    //        DataRow beRow = ds.Tables[1].Rows[0];
    //        if (beRow.Table.Columns.Contains("BE_NO")) beNumber = beRow["BE_NO"].ToString();
    //        if (beRow.Table.Columns.Contains("BE_DATE")) beDate = beRow["BE_DATE"].ToString();
    //    }


    //    DataRow masterRow = ds.Tables[0].Rows[0];

    //    if (ds.Tables.Count > 1 && ds.Tables[0].Rows.Count > 0)
    //    {

    //        COUNTRY_ORIGIN = masterRow["COUNTRY_ORIGIN"].ToString();
    //        COUNTRY_SHIPMENT = masterRow["COUNTRY_SHIPMENT"].ToString();
    //        PORT_ORIGIN = masterRow["PORT_ORIGIN"].ToString();
    //        PORT_SHIPMENT = masterRow["PORT_SHIPMENT"].ToString();

    //        Get_Admin_Master_Codes();
    //    }

    //    RootModel root = new RootModel();
    //    root.headerField = new HeaderField();
    //    root.master = new Master();

    //    // ================= HEADER =================

    //    root.headerField.senderID = ICEGATE_ID;
    //    root.headerField.receiverID = GetValue(masterRow, "CUSTOMS_HOUSE");
    //    root.headerField.indicator = "P";
    //    root.headerField.messageID = "CACHI01";
    //    //root.headerField.sequenceOrControlNumber = GenerateSequenceNumber().ToString();//hide on 05-06-2026 by Chithra Sugg.by Bala
    //    root.headerField.sequenceOrControlNumber = GenerateSequenceNumber(masterRow["JOBNO"].ToString()).ToString();
    //    root.headerField.jobNumber = masterRow["JOBNO"].ToString();
    //    root.headerField.jobDate = masterRow["JOBDATE"].ToString();
    //    root.headerField.messageType = "F";

        // ================= BE MODEL =================


    private void JSON_FOR_IMP(DataSet ds, string ICEGATE_ID, string filePath, string CHA_NO,
                         string jobNumberOverride, string sequenceOverride)
    {
        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            return;
        string beNumber = null, beDate = null;
        if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        {
            DataRow beRow = ds.Tables[1].Rows[0];
            if (beRow.Table.Columns.Contains("BE_NO")) beNumber = beRow["BE_NO"].ToString();
            if (beRow.Table.Columns.Contains("BE_DATE")) beDate = beRow["BE_DATE"].ToString();
        }
        DataRow masterRow = ds.Tables[0].Rows[0];
        if (ds.Tables.Count > 1 && ds.Tables[0].Rows.Count > 0)
        {
            COUNTRY_ORIGIN = masterRow["COUNTRY_ORIGIN"].ToString();
            COUNTRY_SHIPMENT = masterRow["COUNTRY_SHIPMENT"].ToString();
            PORT_ORIGIN = masterRow["PORT_ORIGIN"].ToString();
            PORT_SHIPMENT = masterRow["PORT_SHIPMENT"].ToString();
            Get_Admin_Master_Codes();
        }

        string realJobNo = masterRow["JOBNO"].ToString();

        // caller dummy value pass பண்ணி இருந்தா அதை use பண்ணு, இல்லனா existing logic (மாற்றம் இல்ல)
        string jobNumberForJson = !string.IsNullOrEmpty(jobNumberOverride)
            ? jobNumberOverride
            : realJobNo;

        string sequenceForJson = !string.IsNullOrEmpty(sequenceOverride)
            ? sequenceOverride
            : GenerateSequenceNumber(realJobNo).ToString();

        RootModel root = new RootModel();
        root.headerField = new HeaderField();
        root.master = new Master();

        // ================= HEADER =================
        root.headerField.senderID = ICEGATE_ID;
        root.headerField.receiverID = GetValue(masterRow, "CUSTOMS_HOUSE");
        root.headerField.indicator = "P";
        root.headerField.messageID = "CACHI01";
        root.headerField.sequenceOrControlNumber = sequenceForJson;
        root.headerField.jobNumber = jobNumberForJson;
        root.headerField.jobDate = masterRow["JOBDATE"].ToString();
        root.headerField.messageType = "F";
        // ================= BE MODEL =================


        root.master.beModel = new List<BeModel>();

        BeModel be = new BeModel();

        BETYPE = GetValue(masterRow, "BE_TYPE");
        be.beType = GetValue(masterRow, "BE_TYPE");
        //be.beClass = GetValue(masterRow, "FILING_STATUS");
        string filingStatus = GetValue(masterRow, "FILING_STATUS");
        be.beClass = "N";

        be.modeOfTransport = GetValue(masterRow, "TRANSPORT_MODE");
        //be.importerType = GetValue(masterRow, "IMP_EXP_TYPE");

        string importerType = GetValue(masterRow, "IMP_EXP_TYPE");

        if (!string.IsNullOrEmpty(importerType))
        {
            switch ((importerType).Trim().ToUpper())
            {
                case "GOVERNMENT DEPARTMENTS":
                    be.importerType = "G";
                    break;

                case "PRIVATE":
                    be.importerType = "P";
                    break;

                case "OTHERS":
                    be.importerType = "O";
                    break;

                case "GOVERNMANT":
                    be.importerType = "G";
                    break;

                case "JOBBING":
                    be.importerType = "J";
                    break;

                case "GOVERNMENT UNDERTAKINGS":
                    be.importerType = "U";
                    break;

                case "REPAIR & RETURN":
                    be.importerType = "R";
                    break;

                case "EXHIBITION":
                    be.importerType = "E";
                    break;

                case "DESTRUCTION":
                    be.importerType = "D";
                    break;

                case "MOVEMENT OF GOODS":
                    be.importerType = "V";
                    break;

                case "VESSELS":
                    be.importerType = "V";
                    break;

                case "SAMPLE TESTING":
                    be.importerType = "T";
                    break;

                case "SHIP STORES":
                    be.importerType = "S";
                    break;

                case "NEW AIRCRAFT":
                    be.importerType = "A";
                    break;

                case "HAND CARRIAGE":
                    be.importerType = "H";
                    break;

                case "TRADING":
                    be.importerType = "T";
                    break;

                case "MANUFATURED GOODS":
                    be.importerType = "M";
                    break;

                case "CBW":
                    be.importerType = "W";
                    break;

                case "UNCLAIMED CARGO":
                    be.importerType = "I";
                    break;

                case "SEZ-T TO SEZ":
                    be.importerType = "B";
                    break;

                case "SEZ-M TO SEZ":
                    be.importerType = "F";
                    break;

                default:
                    be.importerType = "P";
                    break;
            }
        }
         
        if (!string.IsNullOrEmpty(filingStatus))
        {
            switch (filingStatus.Trim().ToUpper())
            {
                case "NORMAL":
                    be.whetherPriorBE = "N";
                    break;

                case "PRIOR":
                    be.whetherPriorBE = "Y";
                    break;

                case "ADVANCED":
                    be.whetherPriorBE = "A";
                    break;

                default:
                    be.whetherPriorBE = "";
                    break;
            }
        }

        be.kachchaBE = GetValue(masterRow, "KACHHA_BE");
        be.highSeaSaleFlag = GetValue(masterRow, "HIGH_SEA_SALE");

        be.iecCode = GetValue(masterRow, "IEC_NO");
        be.branchSrNo = GetValue(masterRow, "BRANCH_NO");
        be.nameOfImporter = GetValue(masterRow, "IMPORTER_NAME");

        be.address1 = GetValue(masterRow, "ADDRESS1");
        be.address2 = GetValue(masterRow, "ADDRESS2");
        be.city = GetValue(masterRow, "ADDRESS3");
        be.state = GetValue(masterRow, "ADDRESS4");
        be.pin = GetValue(masterRow, "ADDRESS5");

        be.countryOfOrigin = COUNTRY_ORIGIN;
        be.countryOfConsignment = COUNTRY_SHIPMENT;
        be.portOfOrigin = PORT_ORIGIN;
        be.portOfShipment = PORT_SHIPMENT;

        be.chaCode = CHA_NO;
        be.authorizedEconomicDealerCode = GetValue(masterRow, "ADCODE");
  
        if (be.highSeaSaleFlag == "Y")
        {
            string hssAdCode = GetValue(masterRow, "HSS_ADCODE");
            if (!string.IsNullOrEmpty(hssAdCode))
            {
                be.authorizedEconomicDealerCode = hssAdCode;
            }
            // else: HSS_ADCODE is empty  keep normal ADCODE 
        }

        
        if (!string.IsNullOrEmpty(be.authorizedEconomicDealerCode))
        {
            if (BETYPE == "Z" || BETYPE == "T" || BETYPE == "M" || BETYPE == "J" ||
                BETYPE == "R" || BETYPE == "E" || BETYPE == "D" || BETYPE == "V" || BETYPE == "S")
            {
          
            }
            else
            {
                if (be.authorizedEconomicDealerCode.Length >= 7)
                    be.authorizedEconomicDealerCode = be.authorizedEconomicDealerCode.Substring(0, 7);
            }
        }

        be.greenChannelRequested = GetValue(masterRow, "GREEN_CHANNEL");
        be.firstCheckRequested = GetValue(masterRow, "FIRSTCHECK");
        be.section48Requested = GetValue(masterRow, "SECTION48");
        if (BETYPE == "X" || BETYPE == "T")
        {
            be.warehouseCode = GetValue(masterRow, "EXBOND_WAREHOUSE_CUSTOMS_CODE");

        }
        else
        {
            be.warehouseCode = GetValue(masterRow, "WAREHOUSE_CODE");
        }

        be.warehouseCustomSiteId = GetValue(masterRow, "EXBOND_WAREHOUSE_CUSTOMS");
        be.warehouseBENo = GetValue(masterRow, "EXBOND_INBOND_BE_NO");
        be.warehouseBEDate = GetValue(masterRow, "EXBOND_INBOND_BE_DATE");
        be.noOfPackagesReleased = GetValue(masterRow, "EXBOND_NOOFPACKAGE");
        be.packageCode = GetValue(masterRow, "EXBOND_NOOFPACKAGE_UNITCODE");
        be.grossWeight = GetValue(masterRow, "EXBOND_GROSS_WEIGHT");
        be.unitOfMeasurement = GetValue(masterRow, "EXBOND_GROSS_WEIGHT_UNITCODE");

        be.additionalChargesifanyPurchaseonHighseas = GetValue(masterRow, "EXBOND_ADDL_LOAD_HSS");
        be.miscellaneousLoad = GetValue(masterRow, "EXBOND_MISC_LOAD_RATE");

        be.uniqueConsignmentReferenceNo = GetValue(masterRow, "UCR_NO");
        be.ucrType = GetValue(masterRow, "UCR_TYPE");
        be.paymentMethodCode = GetValue(masterRow, "PAYMENT_METHOD_CODE");

        root.master.beModel.Add(be);
        string SECTION48 = GetValue(masterRow, "SECTION48");
        string FIRSTCHECK = GetValue(masterRow, "FIRSTCHECK");
        string PROVISIONAL = GetValue(masterRow, "PROVISIONAL");

        string SECTION48_DESC = GetValue(masterRow, "SECTION48_DESC");
        string FIRSTCHECK_DESC = GetValue(masterRow, "FIRSTCHECK_DESC");
        string PROVISIONAL_DESC = GetValue(masterRow, "PROVISIONAL_DESC");
        if (SECTION48 == "Y" || FIRSTCHECK == "Y" || PROVISIONAL == "Y")
        {
            root.master.permissionModel = new List<PermissionModel>();

            if (ds.Tables[0].Rows.Count > 0)
            {



                if (SECTION48 == "Y" || FIRSTCHECK == "Y" || PROVISIONAL == "Y")
                {
                    if (!string.IsNullOrEmpty(SECTION48_DESC))
                        SECTION48_DESC = SECTION48_DESC.TrimEnd('.');

                    if (!string.IsNullOrEmpty(PROVISIONAL_DESC))
                        PROVISIONAL_DESC = PROVISIONAL_DESC.TrimEnd('.');

                     // SECTION 48
                            if (SECTION48 == "Y")
                            {
                                PermissionModel perm = new PermissionModel();

                                
                                perm.permissionCode = "S48";
                                perm.reasonsForRequest = SECTION48_DESC;

                                root.master.permissionModel.Add(perm);
                            }

                            // FIRST CHECK
                            if (FIRSTCHECK == "Y")
                            {
                                PermissionModel perm = new PermissionModel();

                               
                                perm.permissionCode = "FCK";
                                perm.reasonsForRequest = FIRSTCHECK_DESC;

                                root.master.permissionModel.Add(perm);
                            }

                            // PROVISIONAL
                            if (PROVISIONAL == "Y")
                            {
                                PermissionModel perm = new PermissionModel();

                               
                                perm.permissionCode = "PRV";
                                perm.reasonsForRequest = PROVISIONAL_DESC;

                                root.master.permissionModel.Add(perm);
                            }
                }
            }
        }

        HashSet<string> addedCurrencies = new HashSet<string>();

        root.master.exchangeModel = new List<ExchangeModel>();

        foreach (DataRow row in ds.Tables[4].Rows)
        {
            INVOICE_CURRENCY = GetValue(row, "INVOICE_CURRENCY");
            string FREIGHT_CURRENCY = GetValue(row, "MIS_FREIGHT_CURRENCY");
            string INSURANCE_CURRENCY = GetValue(row, "MIS_INSURANCE_CURRENCY");
            string MIS_CURRENCY_exe = GetValue(row, "MIS_CURRENCY");

            List<string> currencies = new List<string>()
    {
        INVOICE_CURRENCY,
        FREIGHT_CURRENCY,
        INSURANCE_CURRENCY,
        MIS_CURRENCY_exe
    };

            foreach (string currency in currencies)
            {
                if (string.IsNullOrEmpty(currency))
                    continue;

                // Skip if already added
                if (!addedCurrencies.Add(currency))
                    continue;

                // -------- Existing Logic --------
                INVOICE_CURRENCY = currency;
                INVOICE_EXRATE = "";
                Standard_Currency = "Y";
                NON_STD_EFFECT_DT_IMP = null;
                NON_STD_CERTIFICATE_NO = null;
                NON_STD_CERTIFICATE_DATE = null;
                NON_STD_BANKNAME = null;
                Get_Admin_Master_Codes();

                if (INVOICE_EXRATE == "")
                {
                    DataView view2 = ds.Tables[26].DefaultView;
                    view2.RowFilter = "NON_STD_CUR_CODE = '" + currency + "'";

                    DataTable dt2 = view2.ToTable();

                    if (dt2.Rows.Count > 0)
                    {
                        var val = GetValue(dt2.Rows[0], "NON_STD_EFFECT_DT_IMP");
                        NON_STD_EFFECT_DT_IMP = val == "19000101" ? "" : Convert.ToDateTime(val).ToString("yyyyMMdd");
                        //NON_STD_EFFECT_DT_IMP = GetValue(dt2.Rows[0], "NON_STD_EFFECT_DT_IMP").Replace("19000101", "");
                        NON_STD_BANKNAME = GetValue(dt2.Rows[0], "NON_STD_BANKNAME");
                        NON_STD_CERTIFICATE_NO = GetValue(dt2.Rows[0], "NON_STD_CERTIFICATE_NO");
                        //NON_STD_CERTIFICATE_DATE = GetValue(dt2.Rows[0], "NON_STD_CERTIFICATE_DATE").Replace("19000101", "");
                        var val1 = GetValue(dt2.Rows[0], "NON_STD_CERTIFICATE_DATE");
                        NON_STD_CERTIFICATE_DATE = val == "19000101" ? "" : Convert.ToDateTime(val1).ToString("yyyyMMdd");
                        INVOICE_EXRATE = GetValue(dt2.Rows[0], "NON_STD_RATE_IMPORT");

                        Standard_Currency = "N";
                    }
                }

                // -------- Add To Model --------

                ExchangeModel ex = new ExchangeModel();
                Date_Time dt = new Date_Time();

                ex.currencyCode = currency;
                ex.standardCurrency = Standard_Currency;
                ex.unitInRs = dt.Get_Exchange_PerUnit(currency);
                ex.rate = INVOICE_EXRATE;
                ex.effectiveDate = NON_STD_EFFECT_DT_IMP;
                ex.banknamefornonstandardcurrency = NON_STD_BANKNAME;
                ex.certificateNumber = NON_STD_CERTIFICATE_NO;
                ex.certificateDate = NON_STD_CERTIFICATE_DATE;

                root.master.exchangeModel.Add(ex);
            }
        }

        // ================= INVOICE MODEL =================

        root.master.invoiceModel = new List<InvoiceModel>();

        if (ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
        {
            foreach (DataRow row in ds.Tables[4].Rows)
            {
                InvoiceModel inv = new InvoiceModel();
                inv.invoiceSerialNumber = GetValue(row, "INVOICE_SLNO");
                inv.invoiceDate = GetValue(row, "INVOICE_DATE");
                inv.purchaseOrderNumber = GetValue(row, "OTHER_PURCHASE_ORDER");
                inv.purchaseOrderDate = GetValue(row, "OTHER_PURCHASE_ORDER_DATE");
                inv.contractNumber = GetValue(row, "OTHER_PURCHASE_ORDER_DATE");
                inv.contractDate = GetValue(row, "OTHER_PURCHASE_ORDER_DATE");
                inv.lcNumber = GetValue(row, "OTHER_LOC_NO");
                inv.lcDate = GetValue(row, "OTHER_LOC_DATE");
                string MIS_CURRENCY = GetValue_INV(row, "MIS_CURRENCY");

                string SVB_RELATION = GetValue(row, "SVB_RELATION");

                if (SVB_RELATION == "Y")
                {


                    inv.svbReferenceNumber = GetValue(row, "SVB_REF_NO");
                    inv.svbReferenceDate = GetValue(row, "SVB_REF_DATE");
                    inv.svbLoadAssessableValue = GetValue(row, "SVB_ASSESABLE_RATE");
                    inv.svbLoadOnDuty = GetValue(row, "SVB_DUTY_RATE");
                }
                else
                {
                    inv.svbReferenceNumber = null;
                    inv.svbReferenceDate = null;
                    inv.svbLoadAssessableValue = null;
                    inv.svbLoadOnDuty = null;
                }


                inv.svbFlag = GetValue(row, "SVB_LOADING_ON");
                if (inv.svbFlag == "A")
                {
                    inv.whetherloadProvisionalOnAssValue = GetValue(row, "SVB_ASSESABLE_STATUS");
                }
                else if (inv.svbFlag == "D")
                {
                    inv.whetherProvisionalOnDuty = GetValue(row, "SVB_DUTY_STATUS");
                }
                else if (inv.svbFlag == "B")
                {
                    inv.whetherloadProvisionalOnAssValue = GetValue(row, "SVB_ASSESABLE_STATUS");
                    inv.whetherProvisionalOnDuty = GetValue(row, "SVB_DUTY_STATUS");
                }

                inv.customHouseCodeWhichHasImposedLoad = GetValue(row, "SVB_CUSTOM_HOUSE");
                inv.supplierName = GetValue(row, "SUPPLIER_NAME");
                inv.supplierAddress1 = GetValue(row, "SUPPLIER_ADDRESS");
                inv.supplierAddress2 = GetValue(row, "SUPPLIER_ADDRESS1");
                inv.supplierAddress3 = GetValue(row, "SUPPLIER_ADDRESS2");
                inv.supplierCountryName = GetValue(row, "SUPPLIER_COUNTRY_NAME");
                inv.supplierPin = GetValue(row, "SUPPLIER_COUNTRY_PINCODE");

                inv.sellerName = GetValue(row, "SELLER_NAME");
                inv.sellerAddress1 = GetValue(row, "SELLER_ADDRESS");
                inv.sellerAddress2 = GetValue(row, "SELLER_ADDRESS1");
                inv.sellerAddress3 = GetValue(row, "SELLER_ADDRESS2");
                inv.sellerCountryName = GetValue(row, "SELLER_COUNTRY_NAME");
                inv.sellerPin = GetValue(row, "SELLERCOUNTRY_PINCODE");
                inv.brokerName = GetValue(row, "BROKER_NAME");
                inv.brokerAddress1 = GetValue(row, "BROKER_ADDRESS");
                inv.brokerAddress2 = GetValue(row, "BROKER_ADDRESS1");
                inv.brokerAddress3 = GetValue(row, "BROKER_ADDRESS2");
                inv.brokerCountry = GetValue(row, "BROKER_COUNTRY_NAME");
                inv.brokerPin = GetValue(row, "BROKER_COUNTRY_PINCODE");
                inv.invoiceValue = GetValue(row, "INVOICE_VALUE");
                string D_AMOUNT = GetValue(row, "D_AMOUNT");
                string M_AMOUNT = GetValue(row, "M_AMOUNT");
                string N_AMOUNT = GetValue(row, "N_AMOUNT");
                string A_AMOUNT = GetValue(row, "A_AMOUNT");
                string B_AMOUNT = GetValue(row, "B_AMOUNT");
                string C_AMOUNT = GetValue(row, "C_AMOUNT");
                string E_AMOUNT = GetValue(row, "E_AMOUNT");
                string F_AMOUNT = GetValue(row, "F_AMOUNT");
                string G_AMOUNT = GetValue(row, "G_AMOUNT");
                string H_AMOUNT = GetValue(row, "H_AMOUNT");
                string I_AMOUNT = GetValue(row, "I_AMOUNT");
                string J_AMOUNT = GetValue(row, "J_AMOUNT");
                string K_AMOUNT = GetValue(row, "K_AMOUNT");
                string L_AMOUNT = GetValue(row, "L_AMOUNT");
                inv.termsOfInvoice = GetValue(row, "TERMS");
                string TERMS = GetValue(row, "TERMS");
                inv.invoiceCurrency = GetValue(row, "INVOICE_CURRENCY");
                INVOICE_CURRENCY = inv.invoiceCurrency;
                INVOICE_EXRATE = GetValue(row, "INVOICE_EXRATE");
                string INV_MISC_EXRATE = GetValue(row, "INV_MISC_EXRATE");
                string MIS_SINGLE_OR_MULTIPLE = GetValue(row, "MIS_SINGLE_OR_MULITIPLE");
                string MIS_AGENCY_RATE = GetValue_INV(row, "MIS_AGENCY_RATE");
                string MIS_AGENCY_CURRENCY = GetValue_INV(row, "MIS_AGENCY_CURRENCY");
                string MIS_AGENCY_CHARGES = GetValue_INV(row, "MIS_AGENCY_CHARGES");
                string MIS_DISCOUNT_RATE = GetValue_INV(row, "MIS_DISCOUNT_RATE");
                string MIS_DISCOUNT_CURRENCY = GetValue_INV(row, "MIS_DISCOUNT_CURRENCY");
                string MIS_LOADING_CHARGES = GetValue_INV(row, "MIS_LOADING_CHARGES");
                string MIS_DISCOUNT_CHARGES = GetValue_INV(row, "MIS_DISCOUNT_CHARGES");
                string MIS_LOADING_RATE = GetValue_INV(row, "MIS_LOADING_RATE");
                string MIS_LOADING_CURRENCY = GetValue_INV(row, "MIS_LOADING_CURRENCY");
                string MIS_FREIGHT_RATE = GetValue_INV(row, "MIS_FREIGHT_RATE");
                string MIS_FREIGHT_CURRENCY = GetValue_INV(row, "MIS_FREIGHT_CURRENCY");
                string MIS_INSURANCE_RATE = GetValue_INV(row, "MIS_INSURANCE_RATE");
                string MIS_INSURANCE_CHARGES = GetValue_INV(row, "MIS_INSURANCE_CHARGES");
                string MIS_FREIGHT_CHARGES = GetValue_INV(row, "MIS_FREIGHT_CHARGES");
                string MIS_INSURANCE_CURRENCY = GetValue(row, "MIS_INSURANCE_CURRENCY");
                string MIS_RATE = GetValue_INV(row, "MIS_RATE");
                string MIS_CHARGES = GetValue_INV(row, "MIS_CHARGES");
                string MIS_HIGHSEASALE_RATE = GetValue_INV(row, "MIS_HIGHSEASALE_RATE");
                string MIS_HIGHSEASALE_CHARGES = GetValue_INV(row, "MIS_HIGHSEASALE_CHARGES");
                string MIS_HIGHSEASALE_CURRENCY = GetValue_INV(row, "MIS_HIGHSEASALE_CURRENCY");
                string MI_FREIGHT = GetValue_INV(row, "MI_FREIGHT");
                string MI_INSURANCE = GetValue_INV(row, "MI_INSURANCE");
                string INV_MISC_T_F = GetValue_INV(row, "INV_MISC_T_F");
                string INV_MISC_CHARGES = GetValue_INV(row, "INV_MISC_CHARGES");
                string INV_MISC_TOTAL_CHARGES = GetValue_INV(row, "INV_MISC_TOTAL_CHARGES");
                string MIS_EXRATE = GetValue_INV(row, "MIS_EXRATE");

                string INV_MISC_CURRENCY = GetValue_INV(row, "INV_MISC_CURRENCY");
                if (inv.invoiceCurrency.ToUpper() == "JPY" || inv.invoiceCurrency.ToUpper() == "KRW")
                {
                    if (INV_MISC_EXRATE != null)
                    {
                        double invmisc_exrate1 = 0.00;
                        invmisc_exrate1 = Convert.ToDouble(INV_MISC_EXRATE) / 100;
                        INV_MISC_EXRATE = Convert.ToString(invmisc_exrate1);
                    }
                }

                if (MIS_SINGLE_OR_MULTIPLE == "M")
                {
                    if (TERMS == "CI")
                    {
                        if (MIS_CHARGES != null)
                        {
                            //MIS_CURRENCY = "";
                            //MIS_CHARGES = "";
                            MIS_RATE = null;
                        }
                        if (MIS_CHARGES == null || MIS_CHARGES == "0" || MIS_CHARGES == "0.00")
                        {
                            if (D_AMOUNT != null || M_AMOUNT != null || N_AMOUNT != null)
                            {
                                MIS_CURRENCY = INVOICE_CURRENCY;
                                MIS_CHARGES = Convert.ToString(Convert.ToDouble(D_AMOUNT == string.Empty ? "0" : D_AMOUNT) + Convert.ToDouble(M_AMOUNT == string.Empty ? "0" : M_AMOUNT) + Convert.ToDouble(N_AMOUNT == string.Empty ? "0" : N_AMOUNT));
                            }
                            else
                            {
                                MIS_CURRENCY = null;
                                MIS_CHARGES = null;
                            }
                        }
                        else
                        {
                            if (D_AMOUNT != null || M_AMOUNT != null || N_AMOUNT != null)
                            {
                                if (MIS_CURRENCY == INVOICE_CURRENCY)
                                {
                                    MIS_CURRENCY = INVOICE_CURRENCY;
                                    MIS_CHARGES = Convert.ToString(Convert.ToDouble(MIS_CHARGES == string.Empty ? "0" : MIS_CHARGES) + Convert.ToDouble(D_AMOUNT == string.Empty ? "0" : D_AMOUNT) + Convert.ToDouble(M_AMOUNT == string.Empty ? "0" : M_AMOUNT) + Convert.ToDouble(N_AMOUNT == string.Empty ? "0" : N_AMOUNT));
                                }
                                else
                                {
                                    double MISC_CHARGES_CONVERT_INV = Convert.ToDouble(MIS_CHARGES) / Convert.ToDouble(INVOICE_EXRATE);
                                    MIS_CHARGES = Convert.ToString(Math.Round(Convert.ToDouble(MISC_CHARGES_CONVERT_INV), 2));
                                    MIS_CURRENCY = INVOICE_CURRENCY;
                                    MIS_CHARGES = Convert.ToString(Convert.ToDouble(MIS_CHARGES == string.Empty ? "0" : MIS_CHARGES) + Convert.ToDouble(D_AMOUNT == string.Empty ? "0" : D_AMOUNT) + Convert.ToDouble(M_AMOUNT == string.Empty ? "0" : M_AMOUNT) + Convert.ToDouble(N_AMOUNT == string.Empty ? "0" : N_AMOUNT));
                                }
                            }
                            else
                            {
                                MIS_CURRENCY = MIS_CURRENCY;
                                MIS_CHARGES = MIS_CHARGES;
                            }
                        }
                    }
                    else
                    {
                        if (MIS_CHARGES != null)
                        {
                            //MIS_CURRENCY = "";
                            //MIS_CHARGES = "";
                            MIS_RATE = null;
                        }
                        else if (MIS_CHARGES == null || MIS_CHARGES == "0" || MIS_CHARGES == "0.00")
                        {
                            MIS_CURRENCY = null;
                            MIS_CHARGES = null;

                        }
                    }

                    if (MIS_AGENCY_CHARGES != null)
                    {
                        //MIS_AGENCY_CURRENCY = "";
                        //MIS_AGENCY_CHARGES = "";
                        MIS_AGENCY_RATE = "";
                    }
                    else if (MIS_AGENCY_CHARGES == null || MIS_AGENCY_CHARGES == "0" || MIS_AGENCY_CHARGES == "0.00")
                    {
                        MIS_AGENCY_CURRENCY = null;
                        MIS_AGENCY_CHARGES = null;
                    }

                    if (MIS_DISCOUNT_CHARGES != null)
                    {
                        //MIS_DISCOUNT_CURRENCY = "";
                        //MIS_DISCOUNT_CHARGES = "";
                        MIS_DISCOUNT_RATE = null;
                    }

                    if (MIS_LOADING_CHARGES != null)
                    {
                        //MIS_LOADING_CURRENCY = "";
                        //MIS_LOADING_CHARGES = "";
                        MIS_LOADING_RATE = null;
                    }

                    if (MI_FREIGHT == "Amt" || MI_FREIGHT == null)
                    {

                        if (MIS_FREIGHT_CHARGES != null)
                        {
                            //MIS_FREIGHT_CURRENCY = "";
                            //MIS_FREIGHT_CHARGES = "";
                            MIS_FREIGHT_RATE = "";
                        }
                    }
                    else if (MI_FREIGHT == "Rate")
                    {
                        if (MIS_FREIGHT_RATE != null)
                        {
                            MIS_FREIGHT_CURRENCY = null;
                            MIS_FREIGHT_CHARGES = null;
                        }
                    }

                    if (MI_INSURANCE == "Amt" || MI_INSURANCE == "")
                    {
                        if (MIS_INSURANCE_CHARGES != "")
                        {
                            //MIS_INSURANCE_CURRENCY = "";
                            //MIS_INSURANCE_CHARGES = "";
                            MIS_INSURANCE_RATE = null;
                        }
                    }
                    else if (MI_INSURANCE == "Rate")
                    {
                        if (MIS_INSURANCE_RATE != null)
                        {
                            MIS_INSURANCE_CURRENCY = null;
                            MIS_INSURANCE_CHARGES = null;
                        }
                    }

                    if (MIS_HIGHSEASALE_CHARGES != null)
                    {
                        //MIS_HIGHSEASALE_CURRENCY = "";
                        //MIS_HIGHSEASALE_CHARGES = "";
                        MIS_HIGHSEASALE_RATE = null;
                    }
                }

                else
                {
                    if (TERMS == "CI")
                    {
                        if (MIS_RATE != null)
                        {
                            MIS_CURRENCY = null;
                            MIS_CHARGES = null;
                        }
                        else
                        {
                            if (MIS_CHARGES == null || MIS_CHARGES == "0" || MIS_CHARGES == "0.00")
                            {
                                if (D_AMOUNT != null || M_AMOUNT != null || N_AMOUNT != null)
                                {
                                    MIS_CURRENCY = INVOICE_CURRENCY;
                                    MIS_CHARGES = Convert.ToString(Convert.ToDouble(D_AMOUNT == string.Empty ? "0" : D_AMOUNT) + Convert.ToDouble(M_AMOUNT == string.Empty ? "0" : M_AMOUNT) + Convert.ToDouble(N_AMOUNT == string.Empty ? "0" : N_AMOUNT) + Convert.ToDouble(INV_MISC_CHARGES == string.Empty ? "0" : INV_MISC_CHARGES));
                                }
                                else
                                {
                                    MIS_CURRENCY = null;
                                    MIS_CHARGES = null;
                                }
                            }
                            else
                            {
                                if (D_AMOUNT != null || M_AMOUNT != null || N_AMOUNT != null)
                                {
                                    if (MIS_CURRENCY == INVOICE_CURRENCY)
                                    {
                                        MIS_CURRENCY = INVOICE_CURRENCY;
                                        MIS_CHARGES = Convert.ToString(Convert.ToDouble(MIS_CHARGES == string.Empty ? "0" : MIS_CHARGES) + Convert.ToDouble(D_AMOUNT == string.Empty ? "0" : D_AMOUNT) + Convert.ToDouble(M_AMOUNT == string.Empty ? "0" : M_AMOUNT) + Convert.ToDouble(N_AMOUNT == string.Empty ? "0" : N_AMOUNT) + Convert.ToDouble(INV_MISC_CHARGES == string.Empty ? "0" : INV_MISC_CHARGES));
                                    }
                                    else
                                    {
                                        double MISC_CHARGES_CONVERT_INV = Convert.ToDouble(MIS_CHARGES) / Convert.ToDouble(INVOICE_EXRATE);
                                        MIS_CHARGES = Convert.ToString(Math.Round(Convert.ToDouble(MISC_CHARGES_CONVERT_INV), 2));
                                        MIS_CURRENCY = INVOICE_CURRENCY;
                                        MIS_CHARGES = Convert.ToString(Convert.ToDouble(MIS_CHARGES == string.Empty ? "0" : MIS_CHARGES) + Convert.ToDouble(D_AMOUNT == string.Empty ? "0" : D_AMOUNT) + Convert.ToDouble(M_AMOUNT == string.Empty ? "0" : M_AMOUNT) + Convert.ToDouble(N_AMOUNT == string.Empty ? "0" : N_AMOUNT) + Convert.ToDouble(INV_MISC_CHARGES == string.Empty ? "0" : INV_MISC_CHARGES));
                                    }
                                }
                                else
                                {
                                    MIS_CURRENCY = MIS_CURRENCY;
                                    MIS_CHARGES = MIS_CHARGES;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (INV_MISC_T_F == "T")
                        {
                            double INV_MISC_TOTAL_CHARGES1 = Convert.ToDouble(INV_MISC_TOTAL_CHARGES == string.Empty ? "0.00" : INV_MISC_TOTAL_CHARGES);
                            if (INV_MISC_TOTAL_CHARGES1 > 0)
                            {
                                /* hide on 12-04-2022 by Chithra  for MISC+INV_MISC charges diff from checklist and FF.. Issue faced by Fairmacs
                                MIS_CHARGES = INV_MISC_TOTAL_CHARGES;
                                 * */

                                //------------ Same checklist calc impelmnted here for avoid entry page script loading issue ------------

                                double INV_MISC_CHARGES_CONVERT_INV = 0.00;
                                double INV_MISC_CHARGES_CONVERT_fc = 0.00;
                                double final_INV_MISC_CHARGES = 0.00;

                                if (MIS_CURRENCY != INV_MISC_CURRENCY)
                                {
                                    INV_MISC_CHARGES_CONVERT_INV = Convert.ToDouble(INV_MISC_CHARGES) * Convert.ToDouble(INV_MISC_EXRATE);
                                    INV_MISC_CHARGES_CONVERT_fc = INV_MISC_CHARGES_CONVERT_INV / Convert.ToDouble(MIS_EXRATE);
                                }
                                else
                                {
                                    INV_MISC_CHARGES_CONVERT_fc = Convert.ToDouble(INV_MISC_CHARGES);
                                }

                                final_INV_MISC_CHARGES = Convert.ToDouble(INV_MISC_CHARGES_CONVERT_fc) + Convert.ToDouble(MIS_CHARGES == "" ? "0.00" : MIS_CHARGES);
                                MIS_CHARGES = Convert.ToString(Math.Round(Convert.ToDouble(final_INV_MISC_CHARGES), 2));

                                //-------------------------------------- end ---------------------------------------------------------------
                            }
                        }
                        else
                        {
                            if (MIS_RATE != null)
                            {
                                MIS_CURRENCY = null;
                                MIS_CHARGES = null;
                            }
                            else
                            {
                                if (MIS_CHARGES == null || MIS_CHARGES == "0" || MIS_CHARGES == "0.00")
                                {
                                    MIS_CURRENCY = null;
                                    MIS_CHARGES = null;
                                }
                            }
                        }
                    }

                    if (MIS_AGENCY_RATE != null)
                    {
                        MIS_AGENCY_CURRENCY = null;
                        MIS_AGENCY_CHARGES = null;

                    }
                    else
                    {
                        if (MIS_AGENCY_CHARGES == null || MIS_AGENCY_CHARGES == "0" || MIS_AGENCY_CHARGES == "0.00")
                        {
                            MIS_AGENCY_CURRENCY = null;
                            MIS_AGENCY_CHARGES = null;

                        }
                    }

                    if (MIS_DISCOUNT_RATE != null)
                    {
                        MIS_DISCOUNT_CURRENCY = null;
                        MIS_DISCOUNT_CHARGES = null;

                    }
                    else
                    {
                        if (MIS_DISCOUNT_CHARGES == null || MIS_DISCOUNT_CHARGES == "0" || MIS_DISCOUNT_CHARGES == "0.00")
                        {
                            MIS_DISCOUNT_CURRENCY = null;
                            MIS_DISCOUNT_CHARGES = null;

                        }
                    }

                    if (MIS_LOADING_RATE != null)
                    {
                        MIS_LOADING_CURRENCY = null;
                        MIS_LOADING_CHARGES = null;
                    }
                    else
                    {
                        if (MIS_LOADING_CHARGES == null || MIS_LOADING_CHARGES == "0" || MIS_LOADING_CHARGES == "0.00")
                        {
                            MIS_LOADING_CURRENCY = null;
                            MIS_LOADING_CHARGES = null;
                        }
                    }

                    if (MIS_FREIGHT_RATE != null)
                    {
                        MIS_FREIGHT_CURRENCY = null;
                        MIS_FREIGHT_CHARGES = null;
                    }
                    else
                    {
                        if (MIS_FREIGHT_CHARGES == null || MIS_FREIGHT_CHARGES == "0" || MIS_FREIGHT_CHARGES == "0.00")
                        {
                            MIS_FREIGHT_CURRENCY = null;
                            MIS_FREIGHT_CHARGES = null;
                        }
                    }

                    if (MIS_INSURANCE_RATE != null)
                    {
                        MIS_INSURANCE_CURRENCY = null;
                        MIS_INSURANCE_CHARGES = null;
                    }
                    else
                    {
                        if (MIS_INSURANCE_CHARGES == null || MIS_INSURANCE_CHARGES == "0" || MIS_INSURANCE_CHARGES == "0.00")
                        {
                            MIS_INSURANCE_CURRENCY = null;
                            MIS_INSURANCE_CHARGES = null;
                        }
                    }
                    if (MIS_HIGHSEASALE_RATE != null)
                    {
                        MIS_HIGHSEASALE_CURRENCY = null;
                        MIS_HIGHSEASALE_CHARGES = null;
                    }
                    else
                    {
                        if (MIS_HIGHSEASALE_CHARGES == null || MIS_HIGHSEASALE_CHARGES == "0" || MIS_HIGHSEASALE_CHARGES == "0.00")
                        {
                            MIS_HIGHSEASALE_CURRENCY = null;
                            MIS_HIGHSEASALE_CHARGES = null;
                        }
                    }

                }
                if (TERMS == "CIF")
                {
                    MIS_FREIGHT_CURRENCY = null;
                    MIS_FREIGHT_CHARGES = null;
                    MIS_FREIGHT_RATE = null;

                    MIS_INSURANCE_CURRENCY = null;
                    MIS_INSURANCE_CHARGES = null;
                    MIS_INSURANCE_RATE = null;

                }


                inv.natureOfDiscount = null;
                inv.discountRate = MIS_DISCOUNT_RATE;
                inv.discountAmount = MIS_DISCOUNT_CHARGES;
                inv.hssLoadRate = MIS_HIGHSEASALE_RATE;
                inv.hssLoadAmount = MIS_HIGHSEASALE_CHARGES;
                inv.freightValue = MIS_FREIGHT_CHARGES;
                inv.freightRate = MIS_FREIGHT_RATE;
                inv.whetherFreightActual = null;
                inv.freightCurrency = MIS_FREIGHT_CURRENCY;
                inv.insuranceRate = MIS_INSURANCE_RATE;
                inv.insuranceValue = MIS_INSURANCE_CHARGES;
                inv.insuranceCurrency = MIS_INSURANCE_CURRENCY;
                inv.miscCharges = MIS_CHARGES;
                inv.miscChargesRate = MIS_RATE;
                if (inv.miscCharges == null && inv.miscChargesRate == null)
                {
                    inv.miscCurrency = null;
                }
                else
                {
                    inv.miscCurrency = MIS_CURRENCY;
                }

                inv.landingRate = null;
                inv.loadingCharges = MIS_LOADING_CHARGES;
                inv.loadRate = MIS_LOADING_RATE;
                if (inv.loadingCharges == null && inv.loadRate == null)
                {
                    inv.loadingCurrency = null;
                }
                else
                {
                    inv.loadingCurrency = MIS_DISCOUNT_CHARGES;
                }

                inv.agencyCommission = MIS_AGENCY_CHARGES;

                inv.agencyCommissionRate = MIS_AGENCY_RATE;
                if (inv.agencyCommission == null && inv.agencyCommissionRate == null)
                {
                    inv.agencyCommissionCurrency = null;
                }
                else
                {
                    inv.agencyCommissionCurrency = MIS_AGENCY_CURRENCY;
                }
                inv.natureOfTransaction = GetValue(row, "OTHER_NATURE_OF_TRANSACTION");
                inv.paymentTerms = GetValue(row, "OTHER_TERMS_OF_PAYMENT");


                inv.conditionsAttachedWithSale1 = null;
                inv.conditionsAttachedWithSale2 = null;
                inv.conditionsAttachedWithSale3 = null;
                inv.conditionsAttachedWithSale4 = null;
                inv.conditionsAttachedWithSale5 = null;
                inv.valuationMethodApplicable = GetValue(row, "OTHER_VALUATION_METHOD");
                inv.actualInvoiceNumber = GetValue(row, "INVOICE_NO");
                inv.otherRelevantInform = null;
                inv.termsPlace = GetValue(row, "TERMS_PLACE");

                inv.thirdPartyName = GetValue(row, "THIRDPARTY_NAME");
                inv.thirdPartyAddress1 = GetValue(row, "THIRDPARTY_ADD1");
                inv.thirdPartyAddress2 = GetValue(row, "THIRDPARTY_ADD2");
                inv.thirdPartyCity = GetValue(row, "THIRDPARTY_CITY");
                inv.thirdPartyCntrySubDvsn = GetValue(row, "T_PARTY_COUNTRY_SUB_DIV");
                inv.thirdPartyCountryCode = GetValue(row, "T_PARTY_COUNTRY_CODE");
                inv.thirdPartyPin = GetValue(row, "T_PARTY_PIN");

                inv.authorizedEconomicOperatorCode = GetValue(row, "AUTHORIZED_ECONOMIC_OPERATOR_CODE");
                inv.authorizedEconomicOperatorCountry = GetValue(row, "A_E_O_COUNTRY");
                inv.authorizedEconomicOperatorRole = GetValue(row, "AUTHORIZED_ECONOMIC_OPERATOR");

                inv.whetherBuyerAndSellerAreRelated = GetValue(row, "WHETHER_BUYER_SELLER_RELATED");

                root.master.invoiceModel.Add(inv);
            }
        }

        // ================= 5. miscChModel ================= // modified by shanthini on 09-06-2026

        root.master.misc_chModel = new List<MiscChModel>();

        if (ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
        {
            foreach (DataRow row in ds.Tables[4].Rows)
            {
                string invoiceSlno = GetValue(row, "INVOICE_SLNO");

                // A_AMOUNT
                string a_amount = GetValue(row, "A_AMOUNT");
                if (!string.IsNullOrEmpty(a_amount))
                {
                    MiscChModel misc = new MiscChModel();
                    misc.invoiceSerialNumber = invoiceSlno;
                    misc.miscChargesCode = "A";
                    misc.miscChargesDscrptn = "Brokerage and commissions";
                    misc.miscCharges = a_amount;
                    misc.miscRate = "0";
                    root.master.misc_chModel.Add(misc);
                }

                // B_AMOUNT
                string b_amount = GetValue(row, "B_AMOUNT");
                if (!string.IsNullOrEmpty(b_amount))
                {
                    MiscChModel misc = new MiscChModel();
                    misc.invoiceSerialNumber = invoiceSlno;
                    misc.miscChargesCode = "B";
                    misc.miscChargesDscrptn = "Cost of Containers";
                    misc.miscCharges = b_amount;
                    misc.miscRate = "0";
                    root.master.misc_chModel.Add(misc);
                }

                // C_AMOUNT
                string c_amount = GetValue(row, "C_AMOUNT");
                if (!string.IsNullOrEmpty(c_amount))
                {
                    MiscChModel misc = new MiscChModel();
                    misc.invoiceSerialNumber = invoiceSlno;
                    misc.miscChargesCode = "C";
                    misc.miscChargesDscrptn = "Cost of Packing";
                    misc.miscCharges = c_amount;
                    misc.miscRate = "0";
                    root.master.misc_chModel.Add(misc);
                }

                // D_AMOUNT
                string d_amount = GetValue(row, "D_AMOUNT");
                if (!string.IsNullOrEmpty(d_amount))
                {
                    MiscChModel misc = new MiscChModel();
                    misc.invoiceSerialNumber = invoiceSlno;
                    misc.miscChargesCode = "D";
                    misc.miscChargesDscrptn = "Handling Charges";
                    misc.miscCharges = d_amount;
                    misc.miscRate = "0";
                    root.master.misc_chModel.Add(misc);
                }

                // E_AMOUNT
                string e_amount = GetValue(row, "E_AMOUNT");
                if (!string.IsNullOrEmpty(c_amount))
                {
                    MiscChModel misc = new MiscChModel();
                    misc.invoiceSerialNumber = invoiceSlno;
                    misc.miscChargesCode = "E";
                    misc.miscChargesDscrptn = "Cost of Goods and Services";
                    misc.miscCharges = e_amount;
                    misc.miscRate = "0";
                    root.master.misc_chModel.Add(misc);
                }

                // F_AMOUNT
                string f_amount = GetValue(row, "F_AMOUNT");
                if (!string.IsNullOrEmpty(c_amount))
                {
                    MiscChModel misc = new MiscChModel();
                    misc.invoiceSerialNumber = invoiceSlno;
                    misc.miscChargesCode = "F";
                    misc.miscChargesDscrptn = "Documentation";
                    misc.miscCharges = f_amount;
                    misc.miscRate = "0";
                    root.master.misc_chModel.Add(misc);
                }

                // G_AMOUNT
                string g_amount = GetValue(row, "G_AMOUNT");
                if (!string.IsNullOrEmpty(g_amount))
                {
                    MiscChModel misc = new MiscChModel();
                    misc.invoiceSerialNumber = invoiceSlno;
                    misc.miscChargesCode = "G";
                    misc.miscChargesDscrptn = "Country of Origin Certificate";
                    misc.miscCharges = g_amount;
                    misc.miscRate = "0";
                    root.master.misc_chModel.Add(misc);
                }

                // H_AMOUNT
                string h_amount = GetValue(row, "H_AMOUNT");
                if (!string.IsNullOrEmpty(h_amount))
                {
                    MiscChModel misc = new MiscChModel();
                    misc.invoiceSerialNumber = invoiceSlno;
                    misc.miscChargesCode = "H";
                    misc.miscChargesDscrptn = "Royalties and licence fees";
                    misc.miscCharges = h_amount;
                    misc.miscRate = "0";
                    root.master.misc_chModel.Add(misc);
                }

                // I_AMOUNT
                string i_amount = GetValue(row, "I_AMOUNT");
                if (!string.IsNullOrEmpty(i_amount))
                {
                    MiscChModel misc = new MiscChModel();
                    misc.invoiceSerialNumber = invoiceSlno;
                    misc.miscChargesCode = "I";
                    misc.miscChargesDscrptn = "Value of proceeds which accrue";
                    misc.miscCharges = i_amount;
                    misc.miscRate = "0";
                    root.master.misc_chModel.Add(misc);
                }

                // J_AMOUNT
                string j_amount = GetValue(row, "J_AMOUNT");
                if (!string.IsNullOrEmpty(j_amount))
                {
                    MiscChModel misc = new MiscChModel();
                    misc.invoiceSerialNumber = invoiceSlno;
                    misc.miscChargesCode = "J";
                    misc.miscChargesDscrptn = "Cost of Warrenty Services";
                    misc.miscCharges = j_amount;
                    misc.miscRate = "0";
                    root.master.misc_chModel.Add(misc);
                }

                // K_AMOUNT
                string k_amount = GetValue(row, "K_AMOUNT");
                if (!string.IsNullOrEmpty(k_amount))
                {
                    MiscChModel misc = new MiscChModel();
                    misc.invoiceSerialNumber = invoiceSlno;
                    misc.miscChargesCode = "K";
                    misc.miscChargesDscrptn = "Cost of Warrenty Services";
                    misc.miscCharges = k_amount;
                    misc.miscRate = "0";
                    root.master.misc_chModel.Add(misc);
                }

                // L_AMOUNT
                string l_amount = GetValue(row, "L_AMOUNT");
                if (!string.IsNullOrEmpty(l_amount))
                {
                    MiscChModel misc = new MiscChModel();
                    misc.invoiceSerialNumber = invoiceSlno;
                    misc.miscChargesCode = "L";
                    misc.miscChargesDscrptn = "Cost of Warrenty Services";
                    misc.miscCharges = l_amount;
                    misc.miscRate = "0";
                    root.master.misc_chModel.Add(misc);
                }

                // M_AMOUNT
                string m_amount = GetValue(row, "M_AMOUNT");
                if (!string.IsNullOrEmpty(m_amount))
                {
                    MiscChModel misc = new MiscChModel();
                    misc.invoiceSerialNumber = invoiceSlno;
                    misc.miscChargesCode = "M";
                    misc.miscChargesDscrptn = "Loading Charges";
                    misc.miscCharges = m_amount;
                    misc.miscRate = "0";
                    root.master.misc_chModel.Add(misc);
                }

                // N_AMOUNT
                string n_amount = GetValue(row, "N_AMOUNT");
                if (!string.IsNullOrEmpty(n_amount))
                {
                    MiscChModel misc = new MiscChModel();
                    misc.invoiceSerialNumber = invoiceSlno;
                    misc.miscChargesCode = "N";
                    misc.miscChargesDscrptn = "Unloading Charges";
                    misc.miscCharges = n_amount;
                    misc.miscRate = "0";
                    root.master.misc_chModel.Add(misc);
                }
            }
        }


        
        // ================= 6. licenseModel =================


        root.master.licenseModel = new List<LicenseModel>();

        if (ds.Tables.Count > 5 && ds.Tables[5].Rows.Count > 0)
        {
            foreach (DataRow row in ds.Tables[5].Rows)
            {
                LicenseModel lic = new LicenseModel();
                string Scheme_Code = GetValue(row, "SCHEME_CODE");
                if (Scheme_Code != null && Scheme_Code != "")
                {


                    lic.invoiceSerialNumber = GetValue(row, "INVOICE_SLNO");
                    lic.itemSerialNumberInvoice = GetValue(row, "ITEM_SLNO");
                    lic.itemSrNoLicense = GetValue(row, "LICENSE_ITEM_NO");

                    lic.debitValue = GetValue(row, "DEBIT_AMT");
                    lic.debitQuantity = GetValue(row, "DEBIT_QTY");
                    lic.debitUnitOfMeasurement = GetValue(row, "UNIT_QTY");

                    lic.licenseRegistrationNumber = GetValue(row, "REGISTRATION_NO");
                    lic.licenseRegistrationDate = GetValue(row, "REGISTRATION_DATE");
                    lic.licenseCode = GetValue(row, "SCHEME_CODE");
                    lic.licenseRegnPort = GetValue(row, "PORT_OF_LICENSE");

                    root.master.licenseModel.Add(lic);
                }
            }
        }

        root.master.rspModel = new List<RspModel>();

        bool hasRSPData = false;

        if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
        {
            foreach (DataRow productRow in ds.Tables[3].Rows)
            {
                string rspApplicable = GetValue(productRow, "RSP_APPLICABLE");
                string rspSlNo = GetValue(productRow, "RSP_SL_NO");
                string RSPNOTN_SL_NO = GetValue(productRow, "RSP_NOTN_SL_NO");
                if (RSPNOTN_SL_NO != "")
                {
                    if (rspApplicable == "Y" && !string.IsNullOrEmpty(rspSlNo))
                    {
                        hasRSPData = true;

                        RspModel rsp = new RspModel();

                        rsp.messageType = "F";
                        rsp.customHouseCode = GetValue(masterRow, "CUSTOMS_HOUSE");
                        rsp.jobNumber = GetValue(masterRow, "JOBNO");
                        rsp.jobDate = GetValue(masterRow, "JOBDATE");
                        rsp.beNumber = beNumber;
                        rsp.beDate = beDate;

                        rsp.invoiceSerialNumber = GetValue(productRow, "INVOICE_SLNO");
                        rsp.itemSerialNumberInvoice = GetValue(productRow, "ITEM_SLNO");
                        rsp.itemSrNoRsp = rspSlNo;
                        rsp.rsp = GetValue(productRow, "RSP_AMOUNT");
                        rsp.quantity = GetValue(productRow, "RSP_QTY");
                        rsp.descItem = GetValue(productRow, "RSP_DESC");
                        rsp.rspNotification = GetValue(productRow, "RSP_NOTN_NO");
                        rsp.rspNotificationSrNo = GetValue(productRow, "RSP_NOTN_SL_NO");

                        root.master.rspModel.Add(rsp);
                    }
                }
            }
        }

        // ================= depbModel =================
        root.master.depbModel = new List<DepbModel>();

        bool hasDEPBData = false;

        if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
        {
            DataTable productTable = ds.Tables[3];

            foreach (DataRow productRow in productTable.Rows)
            {
                string schemeCode = productRow["SCHEME_CODE"] == DBNull.Value
                    ? ""
                    : productRow["SCHEME_CODE"].ToString().Trim();

                if (productRow.Table.Columns.Contains("SCHEME_CODE") &&
                    !string.IsNullOrEmpty(schemeCode) &&
                    schemeCode != "00 - DUTIABLE")
                {
                    hasDEPBData = true;

                    DepbModel depb = new DepbModel();
                    depb.invoiceSerialNumber = GetValue(productRow, "INVOICE_SLNO");
                    depb.itemSerialNumberInvoice = GetValue(productRow, "ITEM_SLNO");
                    depb.whetherExemption = "Y";
                    depb.bcdNotification = GetValue(productRow, "SCHEME_NOTN");
                    depb.bcdNotificationSrNo = GetValue(productRow, "SCHEME_NOTN_SLNO");
                    root.master.depbModel.Add(depb);
                }
            }
        }

        // ================= ITEMS MODEL =================

        root.master.itemsModel = new List<ItemsModel>();

        if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
        {
            foreach (DataRow row in ds.Tables[3].Rows)
            {
                ItemsModel item = new ItemsModel();


                item.invoiceSerialNumber = GetValue(row, "INVOICE_SLNO");
                item.itemSerialNumber = GetValue(row, "ITEM_SLNO");
                item.quantity = GetValue(row, "ITEM_QTY");
                item.unitQuantityCode = GetValue(row, "ITEM_QTY_CODE");
                item.ritcCode = GetValue(row, "PRODUCT_RITC");

                item.itemDescription1 = GetValue(row, "ITEM_DESCRIPTION1");
                item.itemDescription2 = GetValue(row, "ITEM_DESCRIPTION2");
                string SCHEME_CODE_FULL = GetValue(row, "SCHEME_CODE");

                string schecode = null;

                string[] SCHEME_COD = SCHEME_CODE_FULL.Split('-');

                if (SCHEME_COD[0].Trim() == "00")
                {

                    schecode = null;
                }
                else
                {
                    schecode = SCHEME_COD[0];
                }
                item.itemCategory = schecode;
                item.genericDescriptionOfTheItem = GetValue(row, "GENEARL_DESCRIPTION");
                item.accessoriesForTheItem = GetValue(row, "ACCESSORIES");
                string MANUFACTURER = GetValue(row, "MANUFACTURER");
                item.manufacturerName = string.IsNullOrWhiteSpace(MANUFACTURER)? "": MANUFACTURER.Trim().TrimEnd('.');
                item.brandName = GetValue(row, "BRAND");
                item.model = GetValue(row, "MODEL");
                item.endUseOfItem = GetValue(row, "END_USE_OF_ITEM");
                COUNTRY_ORIGIN = GetValue(row, "COUNTRY_OF_ORIGIN");
                Get_Admin_Master_Codes();
                item.countryOfOrigin = COUNTRY_ORIGIN;
                string PRODUCT_CETH = GetValue(row, "PRODUCT_CETH");
                if (PRODUCT_CETH != "24022090" && PRODUCT_CETH != "24012010" && PRODUCT_CETH != "27090000" && PRODUCT_CETH != "27090010" && PRODUCT_CETH != "27090090" && PRODUCT_CETH != "27111100" && PRODUCT_CETH != "27101949" && PRODUCT_CETH != "27101241" && PRODUCT_CETH != "27101290" && PRODUCT_CETH != "24013000" && PRODUCT_CETH != "24012090" && PRODUCT_CETH != "24039100" && PRODUCT_CETH != "24012010" && PRODUCT_CETH != "24012040" && PRODUCT_CETH != "24011090")
                {
                    PRODUCT_CETH = "NOEXCISE";

                }
                item.cth = GetValue(row, "PRODUCT_CTH");
                item.preferentialStandard = "S";
                item.ceth = PRODUCT_CETH;
                item.bcdNotification = GetValue(row, "PRODUCT_BCD_NOTN");
                item.bcdNotificationSrNo = GetValue(row, "PRODUCT_BCD_SLNO");
                item.cvdNotification = GetValue(row, "PRODUCT_CVD_NOTN");
                item.cvdNotificationSrNo = GetValue(row, "PRODUCT_CVD_SLNO");
                string PRODUCT_ADDL_DUTY_NOTN = GetValue(row, "PRODUCT_ADDL_DUTY_NOTN");
                string PRODUCT_ADDL_DUTY_NOTN_SL = GetValue(row, "PRODUCT_ADDL_DUTY_NOTN_SL");
                if (PRODUCT_ADDL_DUTY_NOTN == "019/2006")
                {
                    PRODUCT_ADDL_DUTY_NOTN = null;
                    PRODUCT_ADDL_DUTY_NOTN_SL = null;
                }
                item.additionalNotification1 = PRODUCT_ADDL_DUTY_NOTN;
                item.additionalNotification1SrNo = PRODUCT_ADDL_DUTY_NOTN_SL;
                item.additionalNotification2 = GetValue(row, "PRODUCT_AGGREGATE_DUTY_NOTN");
                item.additionalNotification2SrNo = GetValue(row, "PRODUCT_AGGREGATE_DUTY_NOTN_SL");
                //item.otherNotification = GetValue(row, "PRODUCT_OTHER_DUTY_NOTN");
                //item.otherNotificationSrNo = GetValue(row, "PRODUCT_OTHER_DUTY_SLNO");
                item.cusEducessNotfnNumber = GetValue(row, "PRODUCT_EDU_CESS_NOTN");
                item.cusEducessNotfnSrNo = GetValue(row, "PRODUCT_EDU_CESS_NOTN_SL");

                item.socialWelfareNotn = GetValue(row, "SOCIAL_WELFARE_NOTN");
                item.socialWelfareNotnSlno = GetValue(row, "SOCIAL_WELFARE_NOTN_SLNO");

                item.ncdNotn = GetValue(row, "PRODUCT_NCD_NOTN");
                item.ncdNotnSrNo = GetValue(row, "PRODUCT_NCD_SLNO");
                ANTI_DUMPING_NOTN = GetValue(row, "ANTI_DUMPING_NOTN");
                ANTI_DUMPING_NOTN_SLNO = GetValue(row, "ANTI_DUMPING_NOTN_SLNO");
                CTH_QTY = GetValue(row, "CTH_QTY");
                if (ANTI_DUMPING_NOTN == null)
                {
                    ANTI_DUMPING_NOTN_SLNO = null;
                    CTH_QTY = null;
                }
                item.antiDumpingDutyNotification = ANTI_DUMPING_NOTN;
                item.antiDumpingDutySerialNumber = ANTI_DUMPING_NOTN_SLNO;

                item.cthSerialNumber = GetValue(row, "CTH_SLNO");
                item.supplierSerialNumber = GetValue(row, "CTH_SUPPLIER_SLNO");


                item.quantityAsPerAntiDumpingNotn = CTH_QTY;
                item.tariffValueNotn = GetValue(row, "PRODUCT_TARIFF_NOTN");
                item.tariffValueItemSerialNumber = GetValue(row, "PRODUCT_TARIFF_SLNO");
                item.quantityAsPerTariffValueNotn = GetValue(row, "PRODUCT_TARIFF_AMOUNT");

                item.saptaNotn = GetValue(row, "PRODUCT_SAPTA_NOTN");
                item.saptaSerialNumber = GetValue(row, "PRODUCT_SAPTA_SLNO");

                //item.healthNotn = GetValue(row, "PRODUCT_ADDL_HEALTH_CESS_NOTN");
                //item.healthSrNo = GetValue(row, "PRODUCT_ADDL_HEALTH_CESS_SLNO");
                item.additionalCvdNotn = null;
                item.additionalCvdSrNo = null;
                item.aggregateDutyNotn = GetValue(row, "PRODUCT_AGGREGATE_DUTY_NOTN");
                item.aggregateDutyNotnSrNo = GetValue(row, "PRODUCT_AGGREGATE_DUTY_NOTN_SL");

                item.safeguardDutyNotn = GetValue(row, "PRODUCT_SAFEGUARD_NOTN");
                item.safeguardDutyNotnSrNo = GetValue(row, "PRODUCT_SAFEGUARD_SLNO");

                item.unitPriceInvoiced = GetValue(row, "ITEM_UNIT_PRICE");
                item.discountRate = GetValue(row, "DISCOUNT_RATE");
                item.discountAmount = GetValue(row, "DISCOUNT_AMOUNT");
                item.quantityAsPerCth = GetValue(row, "CTH_QTY1");
                item.cthQty = GetValue(row, "CTH_QTY2");

                item.svbReferenceNumber = GetValue(row, "SVB_REF_NO");
                item.svbReferenceDate = GetValue(row, "SVB_REF_DATE");
                item.svbLoadAssessableValue = GetValue(row, "SVB_ASSESABLE_RATE");
                item.svbLoadOnDuty = GetValue(row, "SVB_DUTY_RATE");

                //item.svbFlag = GetValue(row, "SVB_LOADING_ON");
                //item.svbFlag = (GetValue(row, "SVB_LOADING_ON") ?? "").ToString().PadRight(1).Substring(0, 1); // Hide by shanthini on 24-06-2026
                string svbFlagRaw = (GetValue(row, "SVB_LOADING_ON") ?? "").ToString().Trim();
                item.svbFlag = string.IsNullOrWhiteSpace(svbFlagRaw) ? null : svbFlagRaw.Substring(0, 1);
                if (item.svbFlag == "A")
                {
                    item.whetherloadProvisionalOnAssValue = GetValue(row, "SVB_ASSESABLE_STATUS");
                }
                else if (item.svbFlag == "D")
                {
                    item.whetherLoadProvisionalOnDuty = GetValue(row, "SVB_DUTY_STATUS");
                }
                else if (item.svbFlag == "B")
                {
                    item.whetherloadProvisionalOnAssValue = GetValue(row, "SVB_ASSESABLE_STATUS");
                    item.whetherLoadProvisionalOnDuty = GetValue(row, "SVB_DUTY_STATUS");
                }
                item.customHouseCodeWhichHasImposedLoad = GetValue(row, "SVB_CUSTOM_HOUSE");
                item.policyParaNo = GetValue(row, "POLICY_PARA_NO");
                item.policyYear = GetValue(row, "POLICY_YEAR");
                item.rspApplicability = GetValue(row, "RSP_APPLICABLE");

                string currentInvoiceSlNo = GetValue(row, "INVOICE_SLNO");
                string currentItemSlNo = GetValue(row, "ITEM_SLNO");
                var reimportRows = ds.Tables[6].Select( "INVOICE_SLNO = '" + currentInvoiceSlNo + "' AND ITEM_SLNO = '" + currentItemSlNo + "'");

                if (reimportRows.Length > 0)
                {
                    WHETHER_REIMPORT = "Y";
                }
                else
                {
                    WHETHER_REIMPORT = "N";
                }

                item.whetherReimport = WHETHER_REIMPORT;

                item.previousBeNo = GetValue(row, "PREVIOUS_BE_NO");
                item.previousBeDate = GetValue(row, "PREVIOUS_BE_DATE");

                item.prevUnitPriceInvoiced = GetValue(row, "UNIT_PRICE");
                item.prevCurrencyCode = GetValue(row, "UNIT_CODE");
                item.prevCustomSite = GetValue(row, "PREVIOUS_CUSTOMS_HOUSE");
                item.customsFlag = GetValue(row, "CENTRAL_EXCISE_FLAG");

                item.itemManufacturerType = GetValue(row, "MANUFACTURER_PRODUCER");
                item.itemManufacturerCode = GetValue(row, "M_P_GROWER_CODE");
                item.itemManufacturerAddress1 = GetValue(row, "M_P_GROWER_ADD1");
                item.itemManufacturerAddress2 = GetValue(row, "M_P_GROWER_ADD2");
                item.itemManufacturerCity = GetValue(row, "M_P_GROWER_CITY");
                item.itemManufacturerSubdivision = GetValue(row, "M_P_GROWER_COUNTRY_SUBDIV");
                item.itemManufacturerPin = GetValue(row, "M_P_GROWER_PIN");
                item.itemManufacturerCntry = GetValue(row, "M_P_GROWER_COUNTRY");

                item.sourceCountry = GetValue(row, "SOURCE_COUNTRY");
                item.transitCountry = GetValue(row, "TRANSIT_COUNTRY");
                item.accessoryStatus = GetValue(row, "ACCESSORY_STATUS");

                root.master.itemsModel.Add(item);
            }
        }

        // ================= igmsModel =================

        root.master.igmsModel = new List<IgmsModel>();

        //if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
        if (BETYPE != "X" && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
        {
            foreach (DataRow row in ds.Tables[2].Rows)
            {
                IgmsModel igm = new IgmsModel();
                igm.igmNumber = GetValue_INV(row, "IGM_NO");
                igm.igmDate = GetValue(row, "IGM_DATE");
                igm.inwardDate = GetValue(row, "IGM_FLIGHT_VESSELDATE");

                igm.gatewayIgmNo = GetValue(row, "IGM_GATEWAY_IGM_NO");
                igm.gatewayIgmDate = GetValue(row, "IGM_GATEWAY_IGM_DATE");
                igm.gatewayPortCode = GetValue(row, "IGM_GATEWAY_PORT_CODE");

                igm.mawbNo = GetValue(row, "IGM_MAWB_MBL");
                igm.mawbDate = GetValue(row, "IGM_MAWB_MBLDATE");

                igm.hawbNo = GetValue(row, "IGM_HAWB_HBLNO");
                igm.hawbDate = GetValue(row, "IGM_HAWB_HBLDATE");

                igm.totalNoOfPackages = GetValue(row, "IGM_NOOFPACKAGE");
                igm.packageCode = GetValue(row, "IGM_PACKAGETYPE");

                igm.grossWeight = GetValue(row, "IGM_GROSSWEIGHT");
                igm.unitQuantityCode = GetValue(row, "IGM_TYPEOFWEIGHT");

                igm.marksAndNumbers1 = GetValue(row, "IGM_MARKSNOS1");
                igm.marksAndNumbers2 = GetValue(row, "IGM_MARKSNOS2");
                igm.marksAndNumbers3 = GetValue(row, "IGM_MARKSNOS3");
                root.master.igmsModel.Add(igm);
            }
        }

        // ================= containerModel =================
        root.master.containerModel = new List<ContainerModel>();

        if (ds.Tables.Count > 15 && ds.Tables[15].Rows.Count > 0)
        {
            foreach (DataRow row in ds.Tables[15].Rows)
            {
                ContainerModel container = new ContainerModel();


                container.igmNumber = GetValue_INV(row, "CONTAINER_IGM_NO");
                container.igmDate = GetValue(row, "CONTAINER_IGM_DATE");
                container.lclfcl = GetValue(row, "FCL_OR_LCL");
                container.contNumber = GetValue(row, "CONTAINER_NO");
                container.sealNumber = GetValue(row, "SEAL_NO");
                container.truckNumber = GetValue(row, "TRUCK_NO");

                root.master.containerModel.Add(container);
            }
        }

        // ================= ctxModel =================
        root.master.ctxModel = new List<CtxModel>();

        bool hasCTXData =
            !string.IsNullOrEmpty(GetValue(masterRow, "COMMERCIAL_TAX_STATECODE"));

        CtxModel ctx = new CtxModel();

        if (hasCTXData)
        {
            ctx.stateCode = GetValue(masterRow, "COMMERCIAL_TAX_STATECODE");
            ctx.commercialTaxType = GetValue(masterRow, "COMMERCIAL_TAX_TYPE");
            ctx.commercialTaxRegistrationNo = GetValue(masterRow, "COMMERCIAL_TAX_REGISTRATION_NO");
        }
        else
        {
            ctx.stateCode = null;
            ctx.commercialTaxType = null;
            ctx.commercialTaxRegistrationNo = null;
        }

        root.master.ctxModel.Add(ctx);

        // ================= bondDetails =================
        root.master.bondModel = new List<BondDetailsModel>();

        if (ds.Tables.Count > 13 && ds.Tables[13].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[13].Rows)
            {
                BondDetailsModel bond = new BondDetailsModel();



                string bond_Location = Convert.ToString(GetValue(dr, "BOND_LOCATION"));

                if (!string.IsNullOrEmpty(bond_Location) && bond_Location.Contains("-"))
                {
                    string[] strBondLocation = bond_Location.Split('-');
                    bond_Location = strBondLocation[1].Trim();
                }



                bond.bondNumber = GetValue(dr, "BOND_NO");
                bond.bondCode = GetValue(dr, "BOND_TYPE");

                bond.bondPort = bond_Location;
                root.master.bondModel.Add(bond);
            }
        }
        // ================= certModel =================
        root.master.certModel = new List<CertModel>();

        bool hasCertData = ds.Tables.Count > 14 && ds.Tables[14].Rows.Count > 0;

        if (hasCertData)
        {
            foreach (DataRow certRow in ds.Tables[14].Rows)
            {
                CertModel cert = new CertModel();



                cert.certificateNumber = GetValue(certRow, "CERTIFICATE_NO");
                cert.certificationDate = GetValue(certRow, "CERTIFICATE_DATE");
                cert.certificationType = GetValue(certRow, "CERTIFICATE_TYPE");

                root.master.certModel.Add(cert);
            }
        }

        // ================= hssModel =================

        bool hasHSSData =BETYPE != "X" && masterRow.Table.Columns.Contains("HIGH_SEA_SALE") && GetValue(masterRow, "HIGH_SEA_SALE") == "Y";
        if (hasHSSData)
        {
            HssModel hss = new HssModel();

            root.master.hssModel = new List<HssModel>();

            hss.iec = GetValue(masterRow, "HIGH_SEA_IEC");
            hss.branchSrNo = GetValue(masterRow, "HIGH_SEA_BRANCH_SL_NO");
            hss.importerName = GetValue(masterRow, "HIGH_SEA_SALE_NAME");
            hss.importerAddress1 = GetValue(masterRow, "HSS_ADD1");
            hss.importerAddress2 = GetValue(masterRow, "HSS_ADD2");
            hss.importerCity = GetValue(masterRow, "HSS_ADD3");
            hss.importerPin = GetValue(masterRow, "HSS_ADD5");
            hss.precedingLevel = GetValue(masterRow, "PRECEDING_LEVEL");


            root.master.hssModel.Add(hss);
        }
        // ================= reimportModel =================

        root.master.reimportModel = new List<ReImportDetailsModel>();

        if (ds.Tables.Count > 6 && ds.Tables[6].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[6].Rows)
            {
                ReImportDetailsModel reImport = new ReImportDetailsModel();

                reImport.beNumber = beNumber;
                reImport.beDate = beDate;

                reImport.invoiceSerialNumber = GetValue(dr, "INVOICE_SLNO");
                reImport.itemSerialNumber = GetValue(dr, "ITEM_SLNO");

                reImport.shippingBillNo = GetValue(dr, "SB_NO");
                reImport.shippingBillDate = GetValue(dr, "SB_DATE");
                reImport.portOfExport = GetValue(dr, "PORT_EXPORT");

                reImport.invoiceNoSb = GetValue(dr, "SB_INVOICE_NO");
                reImport.itemNoSb = GetValue(dr, "SB_INVOICE__ITEM_NO");

                reImport.notificationNo = GetValue(dr, "NOTN_NO");
                reImport.notificationSrNo = GetValue(dr, "NOTN_SLNO");

                reImport.exportFreight = GetValue(dr, "EXPORT_FREIGHT");
                reImport.exportInsurance = GetValue(dr, "EXPORT_INSURANCE");

                reImport.customsDuty = GetValue(dr, "CUSTOMS_DUTY");
                reImport.exciseDuty = GetValue(dr, "EXCISE_DUTY");

                root.master.reimportModel.Add(reImport);

                if ((reImport.notificationNo == "046/2017") && (reImport.notificationSrNo == "5" || reImport.notificationSrNo == "1E"))
                {
                    if (string.IsNullOrEmpty(reImport.customsDuty))
                    {
                        reImport.customsDuty = "0";
                    }

                    if (string.IsNullOrEmpty(reImport.exciseDuty))
                    {
                        reImport.exciseDuty = "0";
                    }
                }

                else if ((reImport.notificationNo == "045/2017") && (reImport.notificationSrNo != "1A" && reImport.notificationSrNo != "2" && reImport.notificationSrNo != "3"))
                {
                    if (string.IsNullOrEmpty(reImport.customsDuty))
                    {
                        reImport.customsDuty = "0";
                    }

                    if (string.IsNullOrEmpty(reImport.exciseDuty))
                    {
                        reImport.exciseDuty = "0";
                    }
                }

                else if ((reImport.notificationSrNo == "094/96") && (reImport.notificationSrNo != "2"))
                {
                    if (string.IsNullOrEmpty(reImport.customsDuty))
                    {
                        reImport.customsDuty = "0";
                    }
                    if (string.IsNullOrEmpty(reImport.exciseDuty))
                    {
                        reImport.exciseDuty = "0";
                    }
                }

            }
        }

        // ================= sbDutyModel =================
        root.master.sbedutyModel = new List<SbDutyModel>();
        bool hasSBDutyData = false;

        if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
        {
            foreach (DataRow productRow in ds.Tables[3].Rows)
            {
                string invoice = GetValue(productRow, "INVOICE_SLNO");
                string item = GetValue(productRow, "ITEM_SLNO");

                // ---------------- IGST ----------------
                string igstNotn = GetValue(productRow, "IGST_LEVY_NOTN");
                string igstLevy = GetValue(productRow, "IGST_LEVY_EXCEPTION_NOTN");
                if (igstNotn != "" && igstLevy != "" && igstLevy != null && igstNotn != null )
                {
                    ExemptingIgstFlag = GetValue(productRow, "LEVY_EXCEMPTION_NOTN_TYPE");
                }
                string PRODUCT_CETH = GetValue(productRow, "PRODUCT_CETH");
                string cessNotn = GetValue(productRow, "IGST_LEVY_COMPENSATION_CESS_NOTN");
                if (PRODUCT_CETH == "27090000" || PRODUCT_CETH == "27090010" || PRODUCT_CETH == "27090090" || PRODUCT_CETH == "27111100" || PRODUCT_CETH == "27101949" || PRODUCT_CETH == "27101241" || PRODUCT_CETH == "27101290")
                {
                    igstNotn = null;
                    cessNotn = null;
                }
                if (!string.IsNullOrEmpty(igstNotn))
                {
                    hasSBDutyData = true;

                    SbDutyModel sb = new SbDutyModel
                    {
                        invoiceSerialNumber = invoice,
                        itemSerialNumber = item,
                        notificationNo = igstNotn,
                        notificationSrNo = GetValue(productRow, "IGST_LEVY_SLNO"),
                        dutyType = "G",
                        addlDutyFlag = "I",
                        exmpNotificationNo = GetValue(productRow, "IGST_LEVY_EXCEPTION_NOTN"),
                        exmpNotificationSrNo = GetValue(productRow, "IGST_LEVY_EXCEPTION_SLNO"),
                        customsNotnExemptingIgstFlag = ExemptingIgstFlag,

                        itemSlNo = null,
                        supplierSlNo = null,
                        nou = null
                    };

                    root.master.sbedutyModel.Add(sb);
                }

                // ---------------- COMPENSATION CESS ----------------
              

                if (!string.IsNullOrEmpty(cessNotn))
                {
                    hasSBDutyData = true;
                      string   exmpNotificationNo = GetValue(productRow, "IGST_LEVY_EXCEPTION_CC_NOTN");
                      string customsNotnExemptingIgstFlag=null;

                       if(exmpNotificationNo =="" || exmpNotificationNo==null)
                        {
                            customsNotnExemptingIgstFlag = null;
                        }
                        else
                        {
                            customsNotnExemptingIgstFlag = GetValue(productRow, "LEVY_EXCEPTION_CC_NOTN_TYPE");
                        }

                    SbDutyModel sb = new SbDutyModel
                    {
                        invoiceSerialNumber = invoice,
                        itemSerialNumber = item,
                        notificationNo = cessNotn,
                        notificationSrNo = GetValue(productRow, "IGST_LEVY_COMPENSATION_CESS_SLNO"),
                        dutyType = "G",
                        addlDutyFlag = "P",
                        exmpNotificationNo = GetValue(productRow, "IGST_LEVY_EXCEPTION_CC_NOTN"),
                        exmpNotificationSrNo = GetValue(productRow, "IGST_LEVY_EXCEPTION_CC_SLNO"),
                        customsNotnExemptingIgstFlag = customsNotnExemptingIgstFlag,
                        itemSlNo = null,
                        supplierSlNo = null,
                        nou = null
                    };

                    root.master.sbedutyModel.Add(sb);
                }

                // ---------------- HEALTH CESS ----------------
                string healthNotn = GetValue(productRow, "PRODUCT_ADDL_HEALTH_CESS_NOTN");

                if (!string.IsNullOrEmpty(healthNotn))
                {
                    hasSBDutyData = true;

                    SbDutyModel sb = new SbDutyModel
                    {
                        invoiceSerialNumber = invoice,
                        itemSerialNumber = item,
                        notificationNo = healthNotn,
                        notificationSrNo = GetValue(productRow, "PRODUCT_ADDL_HEALTH_CESS_SLNO"),
                        dutyType = "C",
                        addlDutyFlag = "+",
                        exmpNotificationNo = null,
                        exmpNotificationSrNo = null,
                        customsNotnExemptingIgstFlag = null,
                        itemSlNo = null,
                        supplierSlNo = null,
                        nou = null
                    };

                    root.master.sbedutyModel.Add(sb);
                }
                // ---------------- OTHER DUTY (CVD) ---------------- Added by shanthini on 19-06-2026
                string otherDutyNotn = GetValue(productRow, "PRODUCT_OTHER_DUTY_NOTN");

                if (!string.IsNullOrEmpty(otherDutyNotn))
                {
                    hasSBDutyData = true;

                    SbDutyModel sb = new SbDutyModel
                    {
                        invoiceSerialNumber = invoice,
                        itemSerialNumber = item,
                        notificationNo = otherDutyNotn,
                        notificationSrNo = GetValue(productRow, "PRODUCT_OTHER_DUTY_SLNO"),
                        dutyType = "E",
                        addlDutyFlag = "X",
                        exmpNotificationNo = null,
                        exmpNotificationSrNo = null,
                        customsNotnExemptingIgstFlag = null,
                        itemSlNo = null,
                        supplierSlNo = null,
                        nou = null
                    };

                    root.master.sbedutyModel.Add(sb);
                }

                // ---------------- AIDC ----------------
                string aidcNotn = GetValue(productRow, "AIDC_NOTN");

                if (!string.IsNullOrEmpty(aidcNotn))
                {
                    hasSBDutyData = true;

                    SbDutyModel sb = new SbDutyModel
                    {
                        invoiceSerialNumber = invoice,
                        itemSerialNumber = item,
                        notificationNo = aidcNotn,
                        notificationSrNo = GetValue(productRow, "AIDC_NOTN_SLNO"),
                        dutyType = "C",
                        addlDutyFlag = "A",
                        exmpNotificationNo = null,
                        exmpNotificationSrNo = null,
                        customsNotnExemptingIgstFlag = null,
                        itemSlNo = null,
                        supplierSlNo = null,
                        nou = null


                    };

                    root.master.sbedutyModel.Add(sb);
                }

                // ---------------- EXC AIDC ----------------
                string excAidc = GetValue(productRow, "EXC_AIDC_NOTN");

                if (!string.IsNullOrEmpty(excAidc))
                {
                    hasSBDutyData = true;

                    SbDutyModel sb = new SbDutyModel
                    {
                        invoiceSerialNumber = invoice,
                        itemSerialNumber = excAidc,
                        notificationNo = aidcNotn,
                        notificationSrNo = GetValue(productRow, "EXC_AIDC_NOTN_SLNO"),
                        dutyType = "E",
                        addlDutyFlag = "A",
                        exmpNotificationNo = null,
                        exmpNotificationSrNo = null,
                        customsNotnExemptingIgstFlag = null,
                        itemSlNo = null,
                        supplierSlNo = null,
                        nou = null
                    };

                    root.master.sbedutyModel.Add(sb);
                }
            }
        }


        // ================= infoModel =================

        root.master.infoTypeModel = new List<InfoModel>();
        if (ds.Tables.Count > 7 && ds.Tables[7].Rows.Count > 0)
        {

            foreach (DataRow row in ds.Tables[7].Rows)
            {

                InfoModel info = new InfoModel();

                bool shouldAdd = false;  // <-- Track whether to add

                if (BETYPE == "X")
                {

                    string department = GetValue(row, "DEPARTMENT");

                    string infoType = GetValue(row, "INFO_TYPE");

                    string infoQualifier = GetValue(row, "INFO_QUALIFIER");

                    if (department == "FTA" || (infoType == "CHR" && infoQualifier == "SQC") || department == "SIMS")
                    {

                        info.invoiceSerialNumber = GetValue(row, "INVOICE_SLNO");

                        info.itemSerialNumber = GetValue(row, "ITEM_SLNO");

                        info.infoType = infoType;

                        info.infoQualifier = infoQualifier;

                        info.infoCode = GetValue(row, "INFO_CODE");

                        info.infoText = GetValue(row, "INFO_TEXT");

                        info.infoMsr = GetValue(row, "INFO_MSR");

                        info.infoUqc = GetValue(row, "INFO_UQC");

                        shouldAdd = true;  // <-- Mark valid

                    }
                }
                else if (BETYPE == "W" || BETYPE == "Z" || BETYPE == "T" || BETYPE == "M" || BETYPE == "J" || BETYPE == "R" || BETYPE == "E" || BETYPE == "D" || BETYPE == "V") 
                {
                    string department = GetValue(row, "DEPARTMENT");

                    string infoType = GetValue(row, "INFO_TYPE");

                    string infoQualifier = GetValue(row, "INFO_QUALIFIER");

                    if (department == "FSSAI" || department == "PQIS" || department == "SIMS" || department == "CDRUG" || department == "AQCS" || department == "HZRDS" || department == "8517" || department == "DCPC" || (infoType == "CHR" && infoQualifier == "SQC"))
                    {
                        info.invoiceSerialNumber = GetValue(row, "INVOICE_SLNO");

                        info.itemSerialNumber = GetValue(row, "ITEM_SLNO");

                        info.infoType = GetValue(row, "INFO_TYPE");

                        info.infoQualifier = GetValue(row, "INFO_QUALIFIER");

                        info.infoCode = GetValue(row, "INFO_CODE");

                        info.infoText = GetValue(row, "INFO_TEXT");

                        info.infoMsr = GetValue(row, "INFO_MSR");

                        info.infoUqc = GetValue(row, "INFO_UQC");

                        shouldAdd = true;
                    }

                    else
                    {
                        info.invoiceSerialNumber = GetValue(row, "INVOICE_SLNO");

                        info.itemSerialNumber = GetValue(row, "ITEM_SLNO");

                        info.infoType = GetValue(row, "INFO_TYPE");

                        info.infoQualifier = GetValue(row, "INFO_QUALIFIER");

                        info.infoCode = GetValue(row, "INFO_CODE");

                        info.infoText = GetValue(row, "INFO_TEXT");

                        info.infoMsr = GetValue(row, "INFO_MSR");

                        info.infoUqc = GetValue(row, "INFO_UQC");

                        shouldAdd = true;  // <-- Mark valid
                    }

                    if (importerType == "TRADING" || importerType == "MANUFATURED GOODS" || importerType == "CBW")
                    {

                        if (infoType == "SEZ" && infoQualifier == "CBW")
                        {
                            info.invoiceSerialNumber = "0";

                            info.itemSerialNumber = "0";

                            info.infoType = GetValue(row, "INFO_TYPE");

                            info.infoQualifier = GetValue(row, "INFO_QUALIFIER");

                            info.infoCode = GetValue(row, "INFO_CODE");

                            info.infoText = GetValue(row, "INFO_TEXT");

                            info.infoMsr = GetValue(row, "INFO_MSR");

                            info.infoUqc = GetValue(row, "INFO_UQC");

                            shouldAdd = true;


                        }
                    }
                }

                else
                {
                    info.invoiceSerialNumber = GetValue(row, "INVOICE_SLNO");

                    info.itemSerialNumber = GetValue(row, "ITEM_SLNO");

                    info.infoType = GetValue(row, "INFO_TYPE");

                    info.infoQualifier = GetValue(row, "INFO_QUALIFIER");

                    info.infoCode = GetValue(row, "INFO_CODE");

                    info.infoText = GetValue(row, "INFO_TEXT");

                    info.infoMsr = GetValue(row, "INFO_MSR");

                    info.infoUqc = GetValue(row, "INFO_UQC");

                    shouldAdd = true;  // <-- Mark valid

                }

                    if (shouldAdd)  // <-- Only add if populated

                        root.master.infoTypeModel.Add(info);

                }
            }
        


        // ================= constituentModel =================
        root.master.sw_ConstModel = new List<ConstituentModel>();

        if (ds.Tables.Count > 8 && ds.Tables[8].Rows.Count > 0)
        {
            foreach (DataRow row in ds.Tables[8].Rows)
            {
                ConstituentModel cons = new ConstituentModel();

                cons.invoiceSerialNumber = GetValue(row, "INVOICE_SLNO");
                cons.itemSerialNumber = GetValue(row, "ITEM_SLNO");

                cons.constituentSrNo = GetValue(row, "CONSTITUENT_SRNO");
                cons.constituentElementName = GetValue(row, "CONSTITUENT_ELEMENT_NAME");
                cons.constituentElementCode = GetValue(row, "CONSTITUENT_ELEMENT_CODE");
                cons.constituentPercentage = GetValue(row, "CONSTITUENT_PERCENTAGE");
                cons.constituentYieldPercentage = GetValue(row, "CONSTITUENT_YIELD_PERCENTAGE");
                cons.activeIngredientFlag = GetValue(row, "ACTIVE_INGREDIENT");

                root.master.sw_ConstModel.Add(cons);
            }
        }
        // ================= SW_ProdModel =================
        root.master.sw_ProdModel = new List<SWProdModel>();

        if (ds.Tables.Count > 9 && ds.Tables[9].Rows.Count > 0)
        {
            foreach (DataRow row in ds.Tables[9].Rows)
            {
                SWProdModel swProd = new SWProdModel();



                swProd.invoiceSerialNumber = GetValue(row, "INVOICE_SLNO");
                swProd.itemSerialNumber = GetValue(row, "ITEM_SLNO");

                swProd.productionBatchIdentifier = GetValue(row, "PRODUCTION_BATCH_IDENTIFIER");
                swProd.productionBatchQuantity = GetValue(row, "PRODUCTION_BATCH_QUANTITY");
                swProd.unitQuantityCode = GetValue(row, "UNIT_QTY_CODE");
                swProd.dateOfManufacturing = GetValue(row, "DATE_OF_MANUFACTURING");
                swProd.dateOfExpiry = GetValue(row, "DATE_OF_EXPIRY");
                swProd.bestBefore = GetValue(row, "BEST_BEFORE");

                root.master.sw_ProdModel.Add(swProd);
            }
        }

        // ================= ctrlModel =================
        root.master.ctrlModel = new List<CtrlModel>();

        if (ds.Tables.Count > 10 && ds.Tables[10].Rows.Count > 0)
        {
            foreach (DataRow row in ds.Tables[10].Rows)
            {
                CtrlModel ctrl = new CtrlModel();

                string INVOICE_SLNO = GetValue(row, "INVOICE_SLNO");
                string ITEM_SLNO = GetValue(row, "ITEM_SLNO");
                string CONTROL_TYPE_CODE = GetValue(row, "CONTROL_TYPE_CODE");
                if (CONTROL_TYPE_CODE != "SEC65" && CONTROL_TYPE_CODE != "SEZ")
                {
                    INVOICE_SLNO = "0";
                    ITEM_SLNO = "0";
                }

                ctrl.invoiceSerialNumber = INVOICE_SLNO;
                ctrl.itemSerialNumber = ITEM_SLNO;
                ctrl.controlTypeCode = GetValue(row, "CONTROL_TYPE_CODE");
                ctrl.controlLocation = GetValue(row, "CONTROL_LOCATION");
                ctrl.controlStartDate = GetValue(row, "CONTROL_START_DATE");
                ctrl.controlEndDate = GetValue(row, "CONTROL_END_DATE");
                ctrl.controlResultCode = GetValue(row, "CONTROL_RESULT_CODE");
                ctrl.controlResultText = GetValue(row, "CONTROL_RESULT_TEXT");
                ctrl.controlMsr = GetValue(row, "CONTROL_MSR");
                ctrl.controlUqc = GetValue(row, "CONTROL_UQC");
                ctrl.controlSlNo = GetValue(row, "CONTROL_SLNO");




                root.master.ctrlModel.Add(ctrl);
            }
        }
        // ================= statementModel =================



        // ================= statementModel =================

        root.master.statementModel = new List<StatementModel>();

        if (ds.Tables.Count > 11 && ds.Tables[11].Rows.Count > 0)
        {
            foreach (DataRow row in ds.Tables[11].Rows)
            {
                StatementModel stmt = new StatementModel();



                string STMT_CODE = GetValue(row, "STMT_CODE");
                string INVOICE_SLNO = GetValue(row, "INVOICE_SLNO");
                string ITEM_SLNO = GetValue(row, "ITEM_SLNO");
                if (STMT_CODE == "CUG00" || STMT_CODE == "CUG01")
                {
                    INVOICE_SLNO = "0";
                    ITEM_SLNO = "0";
                }
                if (STMT_CODE == "CUV01" || STMT_CODE == "CUV02" || STMT_CODE == "CUV03")
                {
                    ITEM_SLNO = "0";
                }
                stmt.declarationtype = "B";
                stmt.itemSerialNumber = ITEM_SLNO;
                stmt.invoiceSerialNumber = INVOICE_SLNO;


                stmt.statementType = GetValue(row, "STMT_TYPE");


                stmt.statementCode = GetValue(row, "STMT_CODE");


                string STMT_TYPE = GetValue(row, "STMT_TYPE");
                if (STMT_TYPE != "REM")
                {
                    STMT_TEXT = null;
                }

                else if (Connection.Get_User_Imp_Settings_Job_Edit("FF_STMT_TEXT") == "E")
                {
                    STMT_TEXT = GetValue(row, "STMT_TEXT").Replace("\r\n", " ").Replace("–", "").Replace("•", "");
                }
                else
                {
                    STMT_TEXT = GetValue(row, "STMT_TEXT");
                }

                stmt.statementText = STMT_TEXT;

                root.master.statementModel.Add(stmt);
            }
        }


        // ================= documentModel =================

        root.master.supportingDocsModel = new List<DocumentModel>();

        if (ds.Tables.Count > 12 && ds.Tables[12].Rows.Count > 0)
        {
            foreach (DataRow row in ds.Tables[12].Rows)
            {
                DocumentModel doc = new DocumentModel();


                doc.declarationType = "E";
                string Type = GetValue(row, "SELECT_TYPE");
                string INVOICE_SLNO = null, ITEM_SLNO = null;
                if (Type == "Job Level")
                {
                    INVOICE_SLNO = "0";
                    ITEM_SLNO = "0";
                }
                else if (Type == "Invoice Level")
                {
                    INVOICE_SLNO = GetValue(row, "INVOICE_SLNO");
                    ITEM_SLNO = "0";
                }
                else if (Type == "Item Level")
                {
                    INVOICE_SLNO = GetValue(row, "INVOICE_SLNO");
                    ITEM_SLNO = GetValue(row, "ITEM_SLNO");
                }
                else
                {
                    INVOICE_SLNO = "0";
                    ITEM_SLNO = "0";
                }

                doc.invoiceSerialNumber = INVOICE_SLNO;
                doc.itemSerialNumber = ITEM_SLNO;
                doc.chaLicenseNumber = CHA_NO;
                doc.iec = GetValue(masterRow, "IEC_NO");
                doc.icegateUserId = GetValue(row, "ICEGATE_ID");

                doc.imageReferenceNo = GetValue(row, "IMAGE_REF_NUMBER");
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
                doc.documentBeneficiaryPartyPin = GetValue(row, "BENEFICIARY_PARTY_PIN");

                doc.fileType = GetValue(row, "FILE_TYPE");


                root.master.supportingDocsModel.Add(doc);
            }
        }

        // ================= SERIALIZE =================
        RemoveEmptyLists(root);
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
    private void RemoveEmptyLists(RootModel root)
    {
        if (root.master.beModel != null && root.master.beModel.Count == 0)
            root.master.beModel = null;
        if (root.master.permissionModel != null && root.master.permissionModel.Count == 0)
            root.master.permissionModel = null;
        if (root.master.exchangeModel != null && root.master.exchangeModel.Count == 0)
            root.master.exchangeModel = null;
        if (root.master.sbedutyModel != null && root.master.sbedutyModel.Count == 0)
            root.master.sbedutyModel = null;
        if (root.master.invoiceModel != null && root.master.invoiceModel.Count == 0)
            root.master.invoiceModel = null;
        if (root.master.misc_chModel != null && root.master.misc_chModel.Count == 0)
            root.master.misc_chModel = null;
        if (root.master.licenseModel != null && root.master.licenseModel.Count == 0)
            root.master.licenseModel = null;
        if (root.master.rspModel != null && root.master.rspModel.Count == 0)
            root.master.rspModel = null;
        if (root.master.depbModel != null && root.master.depbModel.Count == 0)
            root.master.depbModel = null;
        if (root.master.itemsModel != null && root.master.itemsModel.Count == 0)
            root.master.itemsModel = null;
        if (root.master.igmsModel != null && root.master.igmsModel.Count == 0)
            root.master.igmsModel = null;
        if (root.master.containerModel != null && root.master.containerModel.Count == 0)
            root.master.containerModel = null;
        if (root.master.ctxModel != null && root.master.ctxModel.Count == 0)
            root.master.ctxModel = null;
        if (root.master.bondModel != null && root.master.bondModel.Count == 0)
            root.master.bondModel = null;
        if (root.master.certModel != null && root.master.certModel.Count == 0)
            root.master.certModel = null;
        if (root.master.hssModel != null && root.master.hssModel.Count == 0)
            root.master.hssModel = null;
        if (root.master.reimportModel != null && root.master.reimportModel.Count == 0)
            root.master.reimportModel = null;
        if (root.master.sbedutyModel != null && root.master.sbedutyModel.Count == 0)
            root.master.sbedutyModel = null;
        if (root.master.infoTypeModel != null && root.master.infoTypeModel.Count == 0)
            root.master.infoTypeModel = null;
        if (root.master.sw_ConstModel != null && root.master.sw_ConstModel.Count == 0)
            root.master.sw_ConstModel = null;
        if (root.master.sw_ProdModel != null && root.master.sw_ProdModel.Count == 0)
            root.master.sw_ProdModel = null;
        if (root.master.ctrlModel != null && root.master.ctrlModel.Count == 0)
            root.master.ctrlModel = null;
        if (root.master.statementModel != null && root.master.statementModel.Count == 0)
            root.master.statementModel = null;
        if (root.master.supportingDocsModel != null && root.master.supportingDocsModel.Count == 0)
            root.master.supportingDocsModel = null;
    }
}


public class RootModel
{
    public HeaderField headerField { get; set; }
    public Master master { get; set; }
}
public class HeaderField
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
public class Master
{
    public List<BeModel> beModel { get; set; }
    public List<ExchangeModel> exchangeModel { get; set; }
    public List<PermissionModel> permissionModel { get; set; }
    public List<InvoiceModel> invoiceModel { get; set; }
    public List<MiscChModel> misc_chModel { get; set; }
    public List<ItemsModel> itemsModel { get; set; }
    public List<LicenseModel> licenseModel { get; set; }
    public List<RspModel> rspModel { get; set; }
    public List<DepbModel> depbModel { get; set; }
    public List<BondDetailsModel> bondModel { get; set; }
    public List<CertModel> certModel { get; set; }
    public List<HssModel> hssModel { get; set; }
    public List<ReImportDetailsModel> reimportModel { get; set; }
    public List<SbDutyModel> sbedutyModel { get; set; }
    public List<IgmsModel> igmsModel { get; set; }
    public List<ContainerModel> containerModel { get; set; }
    public List<CtxModel> ctxModel { get; set; }
    public List<InfoModel> infoTypeModel { get; set; }
    public List<ConstituentModel> sw_ConstModel { get; set; }
    public List<SWProdModel> sw_ProdModel { get; set; }
    public List<CtrlModel> ctrlModel { get; set; }
    public List<StatementModel> statementModel { get; set; }
    public List<DocumentModel> supportingDocsModel { get; set; }


}
public class BeModel
{
    public string messageType { get; set; }
    public string customHouseCode { get; set; }
    public string jobNumber { get; set; }
    public string jobDate { get; set; }
    public string beNumber { get; set; }
    public string beDate { get; set; }


    public string beType { get; set; }
    public string iecCode { get; set; }
    public string branchSrNo { get; set; }
    public string nameOfImporter { get; set; }
    public string address1 { get; set; }
    public string address2 { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string pin { get; set; }
    public string beClass { get; set; }
    public string modeOfTransport { get; set; }
    public string importerType { get; set; }
    public string kachchaBE { get; set; }
    public string highSeaSaleFlag { get; set; }
    public string portOfOrigin { get; set; }
    public string chaCode { get; set; }
    public string countryOfOrigin { get; set; }
    public string countryOfConsignment { get; set; }
    public string portOfShipment { get; set; }
    public string greenChannelRequested { get; set; }
    public string section48Requested { get; set; }
    public string whetherPriorBE { get; set; }
    public string authorizedEconomicDealerCode { get; set; }
    public string firstCheckRequested { get; set; }
    public string warehouseCode { get; set; }
    public string warehouseCustomSiteId { get; set; }
    public string warehouseBENo { get; set; }
    public string warehouseBEDate { get; set; }
    public string noOfPackagesReleased { get; set; }
    public string packageCode { get; set; }
    public string grossWeight { get; set; }
    public string unitOfMeasurement { get; set; }
    public string additionalChargesifanyPurchaseonHighseas { get; set; }
    public string miscellaneousLoad { get; set; }
    public string uniqueConsignmentReferenceNo { get; set; }
    public string ucrType { get; set; }
    public string paymentMethodCode { get; set; }
}
public class PermissionModel
{
    public string messageType { get; set; }
    public string customHouseCode { get; set; }
    public string jobNumber { get; set; }
    public string jobDate { get; set; }
    public string beNumber { get; set; }
    public string beDate { get; set; }
    public string permissionCode { get; set; }
    public string reasonsForRequest { get; set; }
}
public class ExchangeModel
{
    public string messageType { get; set; }
    public string customHouseCode { get; set; }
    public string jobNumber { get; set; }
    public string jobDate { get; set; }
    public string beNumber { get; set; }
    public string beDate { get; set; }

    public string currencyCode { get; set; }
    public string standardCurrency { get; set; }
    public string unitInRs { get; set; }
    public string rate { get; set; }
    public string effectiveDate { get; set; }
    public string banknamefornonstandardcurrency { get; set; }
    public string certificateNumber { get; set; }
    public string certificateDate { get; set; }
}
public class InvoiceModel
{
    public string invoiceSerialNumber { get; set; }
    public string invoiceDate { get; set; }
    public string purchaseOrderNumber { get; set; }
    public string purchaseOrderDate { get; set; }
    public string contractNumber { get; set; }
    public string contractDate { get; set; }
    public string lcNumber { get; set; }
    public string lcDate { get; set; }
    public string svbReferenceNumber { get; set; }
    public string svbReferenceDate { get; set; }
    public string svbLoadAssessableValue { get; set; }
    public string svbLoadOnDuty { get; set; }
    public string svbFlag { get; set; }
    public string whetherloadProvisionalOnAssValue { get; set; }
    public string whetherProvisionalOnDuty { get; set; }
    public string customHouseCodeWhichHasImposedLoad { get; set; }


    public string supplierName { get; set; }
    public string supplierAddress1 { get; set; }
    public string supplierAddress2 { get; set; }
    public string supplierAddress3 { get; set; }
    public string supplierCountryName { get; set; }
    public string supplierPin { get; set; }

    public string sellerName { get; set; }
    public string sellerAddress1 { get; set; }
    public string sellerAddress2 { get; set; }
    public string sellerAddress3 { get; set; }
    public string sellerCountryName { get; set; }
    public string sellerPin { get; set; }
    public string brokerName { get; set; }
    public string brokerAddress1 { get; set; }
    public string brokerAddress2 { get; set; }
    public string brokerAddress3 { get; set; }
    public string brokerCountry { get; set; }
    public string brokerPin { get; set; }
    public string invoiceValue { get; set; }
    public string termsOfInvoice { get; set; }
    public string invoiceCurrency { get; set; }
    public string natureOfDiscount { get; set; }
    public string discountRate { get; set; }
    public string discountAmount { get; set; }
    public string hssLoadRate { get; set; }
    public string hssLoadAmount { get; set; }
    public string freightValue { get; set; }
    public string freightRate { get; set; }
    public string whetherFreightActual { get; set; }
    public string freightCurrency { get; set; }
    public string insuranceRate { get; set; }
    public string insuranceValue { get; set; }
    public string insuranceCurrency { get; set; }
    public string miscCharges { get; set; }
    public string miscCurrency { get; set; }
    public string miscChargesRate { get; set; }
    public string landingRate { get; set; }
    public string loadingCharges { get; set; }
    public string loadingCurrency { get; set; }
    public string loadRate { get; set; }
    public string agencyCommission { get; set; }
    public string agencyCommissionCurrency { get; set; }
    public string agencyCommissionRate { get; set; }

    public string natureOfTransaction { get; set; }
    public string paymentTerms { get; set; }

    public string conditionsAttachedWithSale1 { get; set; }
    public string conditionsAttachedWithSale2 { get; set; }
    public string conditionsAttachedWithSale3 { get; set; }
    public string conditionsAttachedWithSale4 { get; set; }
    public string conditionsAttachedWithSale5 { get; set; }
    public string valuationMethodApplicable { get; set; }
    public string actualInvoiceNumber { get; set; }
    public string otherRelevantInform { get; set; }
    public string termsPlace { get; set; }
    public string thirdPartyName { get; set; }
    public string thirdPartyAddress1 { get; set; }
    public string thirdPartyAddress2 { get; set; }
    public string thirdPartyCity { get; set; }
    public string thirdPartyCntrySubDvsn { get; set; }
    public string thirdPartyCountryCode { get; set; }
    public string thirdPartyPin { get; set; }
    public string authorizedEconomicOperatorCode { get; set; }
    public string authorizedEconomicOperatorCountry { get; set; }
    public string authorizedEconomicOperatorRole { get; set; }
    public string whetherBuyerAndSellerAreRelated { get; set; }

}
public class MiscChModel
{
    public string messageType { get; set; }
    public string customHouseCode { get; set; }
    public string jobNumber { get; set; }
    public string jobDate { get; set; }
    public string beNumber { get; set; }
    public string beDate { get; set; }

    public string invoiceSerialNumber { get; set; }
    public string miscChargesCode { get; set; }
    public string miscChargesDscrptn { get; set; }
    public string miscCharges { get; set; }
    public string miscRate { get; set; }
}
public class LicenseModel
{


    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumberInvoice { get; set; }
    public string itemSrNoLicense { get; set; }

    public string debitValue { get; set; }
    public string debitQuantity { get; set; }
    public string debitUnitOfMeasurement { get; set; }

    public string licenseRegistrationNumber { get; set; }
    public string licenseRegistrationDate { get; set; }
    public string licenseCode { get; set; }
    public string licenseRegnPort { get; set; }
}
public class RspModel
{
    public string messageType { get; set; }
    public string customHouseCode { get; set; }
    public string jobNumber { get; set; }
    public string jobDate { get; set; }
    public string beNumber { get; set; }
    public string beDate { get; set; }

    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumberInvoice { get; set; }
    public string itemSrNoRsp { get; set; }
    public string rsp { get; set; }
    public string quantity { get; set; }
    public string descItem { get; set; }
    public string rspNotification { get; set; }
    public string rspNotificationSrNo { get; set; }
}
public class DepbModel
{
    public string messageType { get; set; }
    public string customHouseCode { get; set; }
    public string jobNumber { get; set; }
    public string jobDate { get; set; }
    public string beNumber { get; set; }
    public string beDate { get; set; }
    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumberInvoice { get; set; }
    public string whetherExemption { get; set; }
    public string bcdNotification { get; set; }
    public string bcdNotificationSrNo { get; set; }
}
public class ItemsModel
{
    public string messageType { get; set; }
    public string customHouseCode { get; set; }
    public string jobNumber { get; set; }
    public string jobDate { get; set; }
    public string beNumber { get; set; }
    public string beDate { get; set; }

    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumber { get; set; }
    public string quantity { get; set; }
    public string unitQuantityCode { get; set; }
    public string ritcCode { get; set; }

    public string itemDescription1 { get; set; }
    public string itemDescription2 { get; set; }
    public string itemCategory { get; set; }
    public string genericDescriptionOfTheItem { get; set; }
    public string accessoriesForTheItem { get; set; }

    public string manufacturerName { get; set; }
    public string brandName { get; set; }
    public string model { get; set; }
    public string endUseOfItem { get; set; }
    public string countryOfOrigin { get; set; }
    public string cth { get; set; }
    public string preferentialStandard { get; set; }

    public string ceth { get; set; }
    public string bcdNotification { get; set; }
    public string bcdNotificationSrNo { get; set; }
    public string cvdNotification { get; set; }
    public string cvdNotificationSrNo { get; set; }

    public string additionalNotification1 { get; set; }
    public string additionalNotification1SrNo { get; set; }
    public string additionalNotification2 { get; set; }
    public string additionalNotification2SrNo { get; set; }
    public string otherNotification { get; set; }
    public string otherNotificationSrNo { get; set; }
    public string cusEducessNotfnNumber { get; set; }
    public string cusEducessNotfnSrNo { get; set; }

    public string socialWelfareNotn { get; set; }
    public string socialWelfareNotnSlno { get; set; }

    public string ncdNotn { get; set; }
    public string ncdNotnSrNo { get; set; }

    public string antiDumpingDutyNotification { get; set; }
    public string antiDumpingDutySerialNumber { get; set; }

    public string cthSerialNumber { get; set; }
    public string supplierSerialNumber { get; set; }

    public string quantityAsPerAntiDumpingNotn { get; set; }
    public string tariffValueNotn { get; set; }
    public string tariffValueItemSerialNumber { get; set; }
    public string quantityAsPerTariffValueNotn { get; set; }

    public string saptaNotn { get; set; }
    public string saptaSerialNumber { get; set; }

    public string healthNotn { get; set; }
    public string healthSrNo { get; set; }
    public string additionalCvdNotn { get; set; }
    public string additionalCvdSrNo { get; set; }
    public string aggregateDutyNotn { get; set; }
    public string aggregateDutyNotnSrNo { get; set; }

    public string safeguardDutyNotn { get; set; }
    public string safeguardDutyNotnSrNo { get; set; }

    public string unitPriceInvoiced { get; set; }
    public string discountRate { get; set; }
    public string discountAmount { get; set; }
    public string quantityAsPerCth { get; set; }
    public string cthQty { get; set; }

    public string svbReferenceNumber { get; set; }
    public string svbReferenceDate { get; set; }
    public string svbLoadAssessableValue { get; set; }
    public string svbLoadOnDuty { get; set; }
    public string svbFlag { get; set; }
    public string whetherloadProvisionalOnAssValue { get; set; }
    public string whetherLoadProvisionalOnDuty { get; set; }
    public string customHouseCodeWhichHasImposedLoad { get; set; }
    public string policyParaNo { get; set; }
    public string policyYear { get; set; }
    public string rspApplicability { get; set; }
    public string whetherReimport { get; set; }
    public string previousBeNo { get; set; }
    public string previousBeDate { get; set; }
    public string prevUnitPriceInvoiced { get; set; }
    public string prevCurrencyCode { get; set; }
    public string prevCustomSite { get; set; }
    public string customsFlag { get; set; }
    public string itemManufacturerType { get; set; }
    public string itemManufacturerCode { get; set; }
    public string itemManufacturerAddress1 { get; set; }
    public string itemManufacturerAddress2 { get; set; }
    public string itemManufacturerCity { get; set; }
    public string itemManufacturerSubdivision { get; set; }
    public string itemManufacturerPin { get; set; }
    public string itemManufacturerCntry { get; set; }
    public string sourceCountry { get; set; }
    public string transitCountry { get; set; }
    public string accessoryStatus { get; set; }



}
public class IgmsModel
{


    public string igmNumber { get; set; }
    public string igmDate { get; set; }
    public string inwardDate { get; set; }

    public string gatewayIgmNo { get; set; }
    public string gatewayIgmDate { get; set; }
    public string gatewayPortCode { get; set; }

    public string mawbNo { get; set; }
    public string mawbDate { get; set; }

    public string hawbNo { get; set; }
    public string hawbDate { get; set; }

    public string totalNoOfPackages { get; set; }
    public string grossWeight { get; set; }
    public string unitQuantityCode { get; set; }
    public string packageCode { get; set; }
    public string marksAndNumbers1 { get; set; }
    public string marksAndNumbers2 { get; set; }
    public string marksAndNumbers3 { get; set; }

}
public class ContainerModel
{
    public string messageType { get; set; }
    public string customHouseCode { get; set; }
    public string jobNumber { get; set; }
    public string jobDate { get; set; }
    public string igmNumber { get; set; }
    public string igmDate { get; set; }

    public string lclfcl { get; set; }
    public string contNumber { get; set; }
    public string sealNumber { get; set; }
    public string truckNumber { get; set; }
}
public class CtxModel
{
    public string messageType { get; set; }
    public string customHouseCode { get; set; }
    public string jobNumber { get; set; }
    public string jobDate { get; set; }
    public string beNumber { get; set; }
    public string beDate { get; set; }

    public string stateCode { get; set; }
    public string commercialTaxType { get; set; }
    public string commercialTaxRegistrationNo { get; set; }
}
public class BondDetailsModel
{
    public string messageType { get; set; }
    public string customHouseCode { get; set; }
    public string jobNumber { get; set; }
    public string jobDate { get; set; }
    public string beNumber { get; set; }
    public string beDate { get; set; }
    public string bondNumber { get; set; }
    public string bondCode { get; set; }
    public string bondPort { get; set; }
}
public class CertModel
{


    public string certificateNumber { get; set; }
    public string certificationDate { get; set; }
    public string certificationType { get; set; }
}
public class HssModel
{


    public string iec { get; set; }
    public string branchSrNo { get; set; }
    public string importerName { get; set; }
    public string importerAddress1 { get; set; }
    public string importerAddress2 { get; set; }
    public string importerCity { get; set; }
    public string importerPin { get; set; }
    public string precedingLevel { get; set; }
}
public class ReImportDetailsModel
{
    public string messageType { get; set; }
    public string customHouseCode { get; set; }
    public string jobNumber { get; set; }
    public string jobDate { get; set; }
    public string beNumber { get; set; }
    public string beDate { get; set; }

    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumber { get; set; }

    public string shippingBillNo { get; set; }
    public string shippingBillDate { get; set; }
    public string portOfExport { get; set; }

    public string invoiceNoSb { get; set; }
    public string itemNoSb { get; set; }

    public string notificationNo { get; set; }
    public string notificationSrNo { get; set; }

    public string exportFreight { get; set; }
    public string exportInsurance { get; set; }

    public string customsDuty { get; set; }
    public string exciseDuty { get; set; }
}
public class SbDutyModel
{
    public string messageType { get; set; }
    public string customHouseCode { get; set; }
    public string jobNumber { get; set; }
    public string jobDate { get; set; }
    public string beNumber { get; set; }
    public string beDate { get; set; }

    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumber { get; set; }

    public string notificationNo { get; set; }
    public string notificationSrNo { get; set; }

    public string dutyType { get; set; }
    public string addlDutyFlag { get; set; }

    public string exmpNotificationNo { get; set; }
    public string exmpNotificationSrNo { get; set; }

    public string exemptionFlag { get; set; }



    public string customsNotnExemptingIgstFlag { get; set; }

    public string itemSlNo { get; set; }
    public string supplierSlNo { get; set; }
    public string nou { get; set; }
    public string igstLevyNotn { get; set; }
    public string igstLevySlno { get; set; }
    public string igstExceptionNotn { get; set; }
    public string igstExceptionSlno { get; set; }

    public string igstCompCessNotn { get; set; }
    public string igstCompCessSlno { get; set; }

    public string healthCessNotn { get; set; }
    public string healthCessSlno { get; set; }

    public string aidcNotn { get; set; }
    public string aidcSlno { get; set; }

    public string excAidcNotn { get; set; }
    public string excAidcSlno { get; set; }
}
//public class SbDutyModel
//{
//    public string messageType { get; set; }
//    public string customHouseCode { get; set; }
//    public string jobNumber { get; set; }
//    public string jobDate { get; set; }
//    public string beNumber { get; set; }
//    public string beDate { get; set; }

//    public string invoiceSerialNumber { get; set; }
//    public string itemSerialNumber { get; set; }

//    public string notificationNo { get; set; }
//    public string notificationSrNo { get; set; }
//    public string dutyType { get; set; }

//    public string addlDutyFlag { get; set; }

//    public string exmpNotificationNo { get; set; }
//    public string exmpNotificationSrNo { get; set; }

//    public string customsNotnExemptingIgstFlag { get; set; }

//    public string itemSlNo { get; set; }
//    public string supplierSlNo { get; set; }
//    public string nou { get; set; }
//}
public class InfoModel
{
    public string messageType { get; set; }
    public string customHouseCode { get; set; }
    public string jobNumber { get; set; }
    public string jobDate { get; set; }
    public string beNumber { get; set; }
    public string beDate { get; set; }

    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumber { get; set; }

    public string infoType { get; set; }
    public string infoQualifier { get; set; }
    public string infoCode { get; set; }
    public string infoText { get; set; }
    public string infoMsr { get; set; }
    public string infoUqc { get; set; }
}
public class ConstituentModel
{
    public string messageType { get; set; }
    public string customHouseCode { get; set; }
    public string jobNumber { get; set; }
    public string jobDate { get; set; }
    public string beNumber { get; set; }
    public string beDate { get; set; }

    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumber { get; set; }

    public string constituentSrNo { get; set; }
    public string constituentElementName { get; set; }
    public string constituentElementCode { get; set; }
    public string constituentPercentage { get; set; }
    public string constituentYieldPercentage { get; set; }
    public string activeIngredientFlag { get; set; }
}
public class SWProdModel
{
    public string messageType { get; set; }
    public string customHouseCode { get; set; }
    public string jobNumber { get; set; }
    public string jobDate { get; set; }
    public string beNumber { get; set; }
    public string beDate { get; set; }

    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumber { get; set; }

    public string productionBatchIdentifier { get; set; }
    public string productionBatchQuantity { get; set; }
    public string unitQuantityCode { get; set; }
    public string dateOfManufacturing { get; set; }
    public string dateOfExpiry { get; set; }
    public string bestBefore { get; set; }
}
public class CtrlModel
{
    public string messageType { get; set; }
    public string customHouseCode { get; set; }
    public string jobNumber { get; set; }
    public string jobDate { get; set; }
    public string beNumber { get; set; }
    public string beDate { get; set; }

    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumber { get; set; }

    public string controlTypeCode { get; set; }
    public string controlLocation { get; set; }
    public string controlStartDate { get; set; }
    public string controlEndDate { get; set; }
    public string controlResultCode { get; set; }
    public string controlResultText { get; set; }
    public string controlMsr { get; set; }
    public string controlUqc { get; set; }
    public string controlSlNo { get; set; }
}
public class StatementModel
{

    public string declarationtype { get; set; }
    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumber { get; set; }
    public string statementType { get; set; }
    public string statementCode { get; set; }
    public string statementText { get; set; }

    // If needed later:

}
public class DocumentModel
{
    public string declarationType { get; set; }
    public string invoiceSerialNumber { get; set; }
    public string itemSerialNumber { get; set; }
    public string chaLicenseNumber { get; set; }
    public string iec { get; set; }
    public string icegateUserId { get; set; }
    public string imageReferenceNo { get; set; }
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
    public string documentBeneficiaryPartyPin { get; set; }
    public string fileType { get; set; }

}
