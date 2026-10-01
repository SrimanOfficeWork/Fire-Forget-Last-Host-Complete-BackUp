using System;
using System.Collections.Generic;
using System.Web;
using BussinessObject;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;


/// <summary>
/// Summary description for API_Post_Data_CargoAmazer
/// </summary>
public class API_Post_Data_CargoAmazer
{
    Global_variables ObjUBO = new Global_variables();
    static String jwtToken = string.Empty;

    public void CargoWayz_API_Post(string job_no, string WKPD, string Imp_exp, string Branch_code)
    {
        DataSet dss = new DataSet();
        DataSet dss1 = new DataSet();
        {
            try
            {
                //CHECK IF API CALLED ALREADY
                ObjUBO.A1 = job_no;
                ObjUBO.A3 = WKPD;
                ObjUBO.A5 = Imp_exp;
                ObjUBO.A6 = Branch_code;
                dss1 = Select_JOB_EXISTS_WITH_REFERENCE(ObjUBO);
                if (dss1.Tables[0].Rows.Count > 0)
                {
                    Logger.LogInfoFormat("APi already processed for this job no {0} ", ObjUBO.A1);
                    return;
                }

                Logger.LogInfo("...CargoWayz_API_Post Call received and Attempting JWT authentication..");
                GetJwtToken();

                if (!string.IsNullOrEmpty(jwtToken))
                {
                    ObjUBO.A1 = job_no;
                    ObjUBO.A3 = WKPD;
                    ObjUBO.A4 = "GetImport_ExportDataset";
                    ObjUBO.A5 = Imp_exp;
                    ObjUBO.A6 = Branch_code;
                    dss = Select_Imp_Exp_Job_Details(ObjUBO);

                    if (dss.Tables.Count > 0)
                    {
                        // Log table structure
                        Logger.LogDebug("Table breakdown:");
                        for (int i = 0; i < dss.Tables.Count; i++)
                        {
                            int rowCount = dss.Tables[i] != null ? dss.Tables[i].Rows.Count : 0;
                            Logger.LogDebugFormat("  Table[{0}]: {1} rows", i, rowCount);
                        }

                        if (Imp_exp.ToString() == "E")
                        {
                            try
                            {
                                ShippingBill shippingBill = MapDataSetToShippingBill(dss);
                                Logger.LogDebug("ShippingBill object mapped successfully");

                                if (shippingBill != null && shippingBill.header != null)
                                {
                                    string jsonPayload = JsonConvert.SerializeObject(shippingBill, Formatting.Indented);
                                    Logger.LogInfoFormat("JSON payload created for Shipping Bill/export - Size: {0} bytes", jsonPayload);

                                    string postUrl = ConfigurationManager.AppSettings["6Solve.Api.CreateFlatFile"];
                                    Logger.LogInfoFormat("Posting to URL: {0}", postUrl);

                                    HttpHelper.ApiResult apiResult = new HttpHelper.ApiResult();
                                    apiResult = HttpHelper.PostJson(postUrl, jsonPayload, jwtToken);
                                    if (apiResult != null)
                                    {
                                        Logger.LogInfoFormat("API Response - Status: {0}, Success: {1}, ResponseBody: {2} ", apiResult.HttpStatusCode, apiResult.IsSuccess, apiResult.ResponseBody);
                                        if (apiResult.IsSuccess)
                                        {
                                            try
                                            {
                                                JObject obj = JObject.Parse(apiResult.ResponseBody);

                                                int flatfileId = (int)obj["data"]["flatfile_id"];
                                                string referenceNo = (string)obj["data"]["reference_no"];

                                                DataSet ds = new DataSet();
                                                SqlParameter[] param = new SqlParameter[10];
                                                param[0] = new SqlParameter("@DocType", 'E');
                                                param[1] = new SqlParameter("@JoBNo", shippingBill.general_info.user_job_no);
                                                param[2] = new SqlParameter("@FlatFileId", flatfileId);
                                                param[3] = new SqlParameter("@ReferenceId", referenceNo);

                                                param[4] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
                                                param[5] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
                                                param[6] = new SqlParameter("@CREATED_BY", Connection.Current_User());

                                                ds = Connection.Get_Dataset("Add_API_Job_Response_Status", param);
                                            }
                                            catch (Exception ex)
                                            {
                                                Connection.Error_Msg(ex.Message);
                                            }
                                        }
                                        if (!apiResult.IsSuccess)
                                        {
                                            Logger.LogErrorFormat("API Error. Status: {0}, Message: {1}, Response: {2}", apiResult.HttpStatusCode, apiResult.ErrorMessage, apiResult.ResponseBody);
                                        }
                                    }
                                    else
                                    {
                                        Logger.LogWarning("API Result is NULL. Possible network failure or exception in PostJson.");
                                    }
                                }
                                else
                                {
                                    Logger.LogWarning("SB API call skipped – header not created due to blank payload...");
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.LogError("Export processing failed", ex);
                                throw;
                            }
                        }

                        if (Imp_exp.ToString() == "I")
                        {
                            try
                            {
                                BillOfEntry billOfEntry = MapDataSetToBillofEntry(dss);
                                Logger.LogDebug("BillOfEntry object mapped successfully");

                                if (billOfEntry != null && billOfEntry.header != null)
                                {
                                    string jsonPayload = JsonConvert.SerializeObject(billOfEntry, Formatting.Indented);
                                    Logger.LogInfoFormat("JSON payload created for BillOfEntry /import - Size: {0} bytes", jsonPayload);

                                    string postUrl = ConfigurationManager.AppSettings["6Solve.Api.CreateFlatFile"];
                                    Logger.LogInfoFormat("Posting to URL: {0}", postUrl);

                                    HttpHelper.ApiResult apiResult = new HttpHelper.ApiResult();
                                    apiResult = HttpHelper.PostJson(postUrl, jsonPayload, jwtToken);
                                    if (apiResult != null)
                                    {
                                        Logger.LogInfoFormat("API Response - Status: {0}, Success: {1}, ResponseBody: {2}", apiResult.HttpStatusCode, apiResult.IsSuccess, apiResult.ResponseBody);
                                        if (apiResult.IsSuccess)
                                        {
                                            try
                                            {
                                                JObject obj = JObject.Parse(apiResult.ResponseBody);

                                                int flatfileId = (int)obj["data"]["flatfile_id"];
                                                string referenceNo = (string)obj["data"]["reference_no"];

                                                DataSet ds = new DataSet();
                                                SqlParameter[] param = new SqlParameter[10];
                                                param[0] = new SqlParameter("@DocType", 'I');
                                                param[1] = new SqlParameter("@JoBNo", billOfEntry.general_info.user_job_no);
                                                param[2] = new SqlParameter("@FlatFileId", flatfileId);
                                                param[3] = new SqlParameter("@ReferenceId", referenceNo);

                                                param[4] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
                                                param[5] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
                                                param[6] = new SqlParameter("@CREATED_BY", Connection.Current_User());

                                                ds = Connection.Get_Dataset("Add_API_Job_Response_Status", param);
                                            }
                                            catch (Exception ex)
                                            {
                                                Connection.Error_Msg(ex.Message);
                                            }
                                        }
                                        if (!apiResult.IsSuccess)
                                        {
                                            Logger.LogErrorFormat("API Error. Status: {0}, Message: {1}, Response: {2}", apiResult.HttpStatusCode, apiResult.ErrorMessage, apiResult.ResponseBody);
                                        }
                                    }
                                    else
                                    {
                                        Logger.LogWarning("API Result is NULL. Possible network failure or exception in PostJson.");
                                    }
                                }
                                else
                                {
                                    Logger.LogWarning("BE API call skipped – header not created due to blank payload...");
                                }

                            }
                            catch (Exception ex)
                            {
                                Logger.LogError("Import processing failed", ex);
                                throw;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogErrorFormat("CargoWayz_API_Post FAILED for JobNo: {0}", job_no);
                Logger.LogError("Exception details:", ex);
                Connection.Error_Msg(ex.Message);
            }
            finally
            {
                Logger.CleanupOldLogs(30);
            }
        }
    }


    /// <summary>
    ///  Billof Entry / Import
    /// </summary>
    /// <param name="ds"></param>
    /// <returns></returns>
    public static BillOfEntry MapDataSetToBillofEntry(DataSet ds)
    {
        Logger.LogInfo("=== MapDataSetToBillofEntry / import STARTED ===");
        Logger.LogDebugFormat("DataSet has {0} tables", ds.Tables.Count);

        String TransportMode = string.Empty;
        BillOfEntry billOfEntry = new BillOfEntry();
        BeHeader beHeader = new BeHeader();
        BeGeneralInfo beGeneralInfo = new BeGeneralInfo();
        BeExchangeInfo beExchangeInfo = new BeExchangeInfo();
        List<BeInvoiceInfo> beInvoiceInfo = new List<BeInvoiceInfo>();
        List<BeIgmsInfo> beIgmInfo = new List<BeIgmsInfo>();
        List<BeItemsInfo> beItemInfo = new List<BeItemsInfo>();
        List<BeContainerInfo> containerInfo = new List<BeContainerInfo>();
        List<BeItemSWInfoTypeInfo> swinfotypeInfo = new List<BeItemSWInfoTypeInfo>();

        if (ds.Tables.Count == 0)
        {
            return billOfEntry;
        }

        try
        {
            if (ds.Tables.Count > 0 && ds.Tables[16].Rows.Count > 0)
            {
                Logger.LogDebugFormat("Table[0] (General): {0} rows", ds.Tables[0] != null ? ds.Tables[0].Rows.Count : 0);
                Logger.LogDebugFormat("Table[6] (Invoice): {0} rows", ds.Tables.Count > 6 && ds.Tables[6] != null ? ds.Tables[6].Rows.Count : 0);
                Logger.LogDebugFormat("Table[2] (Items):   {0} rows", ds.Tables.Count > 2 && ds.Tables[2] != null ? ds.Tables[2].Rows.Count : 0);

                DataTable generalDT = ds.Tables[0];
                DataRow rowGeneralImport = ds.Tables[0].Rows.Count > 0 ? ds.Tables[0].Rows[0] : null;

                DataTable rowInvoiceImport = ds.Tables[6]; // for Invoice Details Import
                DataTable rowIgmDetails = ds.Tables[2]; // for IGM Details Import

                DataTable rowContainerDetails = ds.Tables[3]; //for container details in IGM 
                DataTable rowSWInfoTypeDetails = ds.Tables[11]; //for SW info type  details in IGM 
                
                DataTable rowItemDetails = ds.Tables[7]; // for Item Details Import

                DataRow exportBEEntry = ds.Tables[16].Rows.Count > 0 ? ds.Tables[16].Rows[0] : null; //For BE Entry Table 16

                TransportMode = rowGeneralImport["TRANSPORT_MODE"].ToString().ToUpper();
                billOfEntry.doc_type = DocumentConstants.DocTypeBE;

                #region Header
                Logger.LogInfo("Mapping BoE Header section...");
                beHeader.company_id = Connection.Company_License();
                beHeader.file_type = DocumentConstants.DocTypeBE;
                beHeader.record_type = DocumentConstants.RecordTypeHREC;
                beHeader.sender_id_type = DocumentConstants.SenderIdTypeZZ;
                beHeader.sender_id = HttpContext.Current.Session["ICEGATE_ID"].ToString();
                beHeader.receiver_id_type = DocumentConstants.ReceiverIdTypeZZ;
                beHeader.receiver_id = SafeGetString(rowGeneralImport, "CUSTOMS_HOUSE");
                beHeader.version = DocumentConstants.VersionIces1_5;
                beHeader.message_id = DocumentConstants.MessageIdCache01;
                beHeader.sequence_no = DocumentConstants.Blank;
                beHeader.date = DateTimeFormats.GetCurrentDate();
                beHeader.time = DateTimeFormats.GetCurrentTime();
                billOfEntry.header = beHeader;
                #endregion Header

                #region general info
                Logger.LogInfo("Mapping BE_General Info section...");
                beGeneralInfo.custom_house_code = SafeGetString(rowGeneralImport, "CUSTOMS_HOUSE");
                beGeneralInfo.cha_license_no = HttpContext.Current.Session["CHA_NO"].ToString();

                beGeneralInfo.user_job_no = SafeGetString(rowGeneralImport, "JOBNO");
                beGeneralInfo.user_job_date = DateTime.Parse(SafeGetString(rowGeneralImport, "JOBDATE")).ToString("yyyy-MM-dd");            //JOBDATE

                beGeneralInfo.be_type = MapBETYPE(SafeGetString(rowGeneralImport, "BE_TYPE"));

                beGeneralInfo.icegate_user_id = HttpContext.Current.Session["ICEGATE_ID"].ToString();
                beGeneralInfo.importer_exporter_code = SafeGetString(rowGeneralImport, "IEC_NO");
                beGeneralInfo.branch_sr_no_of_exporter = SafeGetString(rowGeneralImport, "BRANCH_NO");

                beGeneralInfo.importer_name = SafeGetString(rowGeneralImport, "IMPORTER_NAME");
                beGeneralInfo.importer_address_1 = SafeGetString(rowGeneralImport, "ADDRESS1");
                beGeneralInfo.importer_address_2 = SafeGetString(rowGeneralImport, "ADDRESS2");
                beGeneralInfo.importer_city = SafeGetString(rowGeneralImport, "ADDRESS3");
                beGeneralInfo.importer_state = SafeGetString(rowGeneralImport, "ADDRESS4");
                beGeneralInfo.importer_pin = SafeGetString(rowGeneralImport, "ADDRESS5");

                beGeneralInfo.high_sea_sale_flag = SafeGetString(rowGeneralImport, "HIGH_SEA_SALE");
                beGeneralInfo.port_of_origin = SafeGetString(rowGeneralImport, "PORT_ORIGIN");
                beGeneralInfo.cha_code = DocumentConstants.Blank;
                beGeneralInfo.country_of_origin = SafeGetString(rowGeneralImport, "COUNTRY_ORIGIN");
                beGeneralInfo.port_of_shipment = SafeGetString(rowGeneralImport, "PORT_SHIPMENT");
                beGeneralInfo.green_channel_requested = SafeGetString(rowGeneralImport, "GREEN_CHANNEL");
                beGeneralInfo.section_48_requested = SafeGetString(rowGeneralImport, "SECTION48");
                beGeneralInfo.authorized_dealer_code = SafeGetString(rowGeneralImport, "ADCODE");
                beGeneralInfo.kachcha_be = SafeGetString(rowGeneralImport, "KACHHA_BE");
                beGeneralInfo.first_check_requested = SafeGetString(rowGeneralImport, "FIRSTCHECK");

                beGeneralInfo.warehouse_code = SafeGetString(rowGeneralImport, "WAREHOUSE_CODE");
                beGeneralInfo.warehouse_customs_site_id = SafeGetString(rowGeneralImport, "EXBOND_WAREHOUSE_CUSTOMS_CODE");
                beGeneralInfo.warehouse_be_no = SafeGetString(rowGeneralImport, "WAREHOUSE_BE_NO");

                //WAREHOUSE_BE_DATE
                string warehouseBeDate = SafeGetString(rowGeneralImport, "WAREHOUSE_BE_DATE");
                beGeneralInfo.warehouse_be_date = string.IsNullOrWhiteSpace(warehouseBeDate) ? "" : DateTime.Parse(warehouseBeDate).ToString("yyyy-MM-dd");

                beGeneralInfo.no_of_packages_released = SafeGetString(rowGeneralImport, "EXBOND_NOOFPACKAGE");
                beGeneralInfo.package_code = SafeGetString(rowGeneralImport, "EXBOND_NOOFPACKAGE_UNITCODE");
                beGeneralInfo.gross_weight = SafeGetString(rowGeneralImport, "EXBOND_GROSS_WEIGHT");
                beGeneralInfo.unit_of_measurement = SafeGetString(rowGeneralImport, "EXBOND_GROSS_WEIGHT_UNITCODE");
                beGeneralInfo.miscellaneous_load_rate = SafeGetString(rowGeneralImport, "EXBOND_MISC_LOAD_RATE");

                beGeneralInfo.country_of_consignment = SafeGetString(rowGeneralImport, "COUNTRY_SHIPMENT");
                beGeneralInfo.mode_of_transport = MapTransportMode(SafeGetString(rowGeneralImport, "TRANSPORT_MODE"));
                beGeneralInfo.whether_prior_be = MapFilingStatus(SafeGetString(rowGeneralImport, "FILING_STATUS"));

                String importer_type_BE = SafeGetString(rowGeneralImport, "IMP_EXP_TYPE");
                if (importer_type_BE == "GOVERNMENT" || importer_type_BE == "GOVERNMENT DEPARTMENTS")
                {
                    beGeneralInfo.importer_type = "G";
                }
                else if (importer_type_BE == "GOVERNMENT UNDERTAKINGS")
                {
                    beGeneralInfo.importer_type = "U";
                }
                else if (importer_type_BE == "OTHERS")
                {
                    beGeneralInfo.importer_type = "O";
                }
                else if (importer_type_BE == "PRIVATE")
                {
                    beGeneralInfo.importer_type = "P";
                }
                else if (importer_type_BE == "HAND CARRIAGE")
                {
                    beGeneralInfo.importer_type = "H";
                }
                else
                {
                    beGeneralInfo.importer_type = DocumentConstants.Blank;
                }

                beGeneralInfo.importer_class = DocumentConstants.BE_Importer_Class;
                beGeneralInfo.be_no = SafeGetString(exportBEEntry, "BE_NO");
                beGeneralInfo.be_date = DateTime.Parse(SafeGetString(exportBEEntry, "BE_DATE")).ToString("yyyy-MM-dd");                         //BE DATE       

                string loadValue = SafeGetString(rowGeneralImport, "EXBOND_ADDL_LOAD_HSS");
                beGeneralInfo.loading_for_x_bond_over_wh_be = string.IsNullOrWhiteSpace(loadValue) ? "0" : loadValue.Trim();

                billOfEntry.general_info = beGeneralInfo;
                Logger.LogDebug("BE_general Mapped successfully...");
                #endregion

                #region  Invoice Details - Bill of Entry
                if (rowInvoiceImport != null && rowInvoiceImport.Rows.Count > 0)
                {
                    Logger.LogInfoFormat("Processing {0} invoices", rowInvoiceImport.Rows.Count);
                    int invoiceCount = 0;

                    foreach (DataRow row in rowInvoiceImport.Rows)
                    {
                        try
                        {
                            invoiceCount++;
                            Logger.LogDebugFormat("Processing Invoice #{0}", invoiceCount);

                            BeInvoiceInfo beinvoice = new BeInvoiceInfo();
                            beinvoice.custom_house_code = getInvoiceString(rowGeneralImport, "CUSTOMS_HOUSE");
                            beinvoice.cha_license_no = HttpContext.Current.Session["CHA_NO"].ToString();

                            beinvoice.user_job_no = getInvoiceString(rowGeneralImport, "JOBNO");
                            beinvoice.user_job_date = DateTime.Parse(SafeGetString(rowGeneralImport, "JOBDATE")).ToString("yyyy-MM-dd");                    //getInvoiceString(rowGeneralImport, "JOBDATE"); 

                            beinvoice.invoice_sr_no = getInvoiceString(row, "INVOICE_SLNO");
                            beinvoice.actual_invoice_no = getInvoiceString(row, "INVOICE_NO");

                            beinvoice.invoice_date = DateTime.Parse(SafeGetString(row, "INVOICE_DATE")).ToString("yyyy-MM-dd");                              //getInvoiceString(row, "INVOICE_DATE");
                            beinvoice.purchase_order_no = getInvoiceString(row, "OTHER_PURCHASE_ORDER");
                            beinvoice.purchase_order_date = DateTime.Parse(SafeGetString(row, "OTHER_PURCHASE_ORDER_DATE")).ToString("yyyy-MM-dd");          //getInvoiceString(row, "OTHER_PURCHASE_ORDER_DATE");

                            beinvoice.contract_no = getInvoiceString(row, "OTHER_CONTRACT_NO");
                            beinvoice.contract_date = DateTime.Parse(SafeGetString(row, "OTHER_CONTRACT_DATE")).ToString("yyyy-MM-dd");                     //getInvoiceString(row, "OTHER_CONTRACT_DATE");

                            beinvoice.lc_no = getInvoiceString(row, "OTHER_LOC_NO");
                            beinvoice.lc_date = DateTime.Parse(SafeGetString(row, "OTHER_LOC_DATE")).ToString("yyyy-MM-dd");                           //getInvoiceString(row, "OTHER_LOC_DATE");

                            beinvoice.svb_reference_no = getInvoiceString(row, "SVB_REF_NO");
                            beinvoice.svb_reference_date = GetApiDate(getInvoiceString(row, "SVB_REF_DATE"));                                            //SVB REFERENCE DATE

                            beinvoice.svb_load_assessable_value = getInvoiceString(row, "SVB_ASSESABLE_RATE");
                            beinvoice.svb_load_on_duty = getInvoiceString(row, "SVB_DUTY_RATE");
                            beinvoice.svb_flag = getInvoiceString(row, "SVB_LOADING_ON");

                            beinvoice.load_final_provisional_on_av = getInvoiceString(row, "SVB_ASSESABLE_STATUS");
                            beinvoice.load_final_provisional_on_duty = getInvoiceString(row, "SVB_DUTY_STATUS");
                            beinvoice.custom_house_code_imposed_load = getInvoiceString(row, "SVB_CUSTOM_HOUSE");
                            beinvoice.nature_of_contract = DocumentConstants.natureOfContact_BillofEntry;

                            beinvoice.supplier_name = getInvoiceString(row, "SUPPLIER_NAME");
                            beinvoice.supplier_address_1 = getInvoiceString(row, "SUPPLIER_ADDRESS");
                            beinvoice.supplier_address_2 = getInvoiceString(row, "SUPPLIER_ADDRESS1");
                            beinvoice.supplier_address_3 = getInvoiceString(row, "SUPPLIER_ADDRESS2");
                            beinvoice.supplier_country_name = getInvoiceString(row, "SUPPLIER_COUNTRY_NAME");
                            beinvoice.supplier_post_code = getInvoiceString(row, "SUPPLIER_COUNTRY_PINCODE");

                            beinvoice.seller_name = getInvoiceString(row, "SELLER_NAME");
                            beinvoice.seller_address_1 = getInvoiceString(row, "SELLER_ADDRESS");
                            beinvoice.seller_address_2 = getInvoiceString(row, "SELLER_ADDRESS1");
                            beinvoice.seller_address_3 = getInvoiceString(row, "SELLER_ADDRESS2");
                            beinvoice.seller_country_name = getInvoiceString(row, "SELLER_COUNTRY_NAME");
                            beinvoice.seller_post_code = getInvoiceString(row, "SELLERCOUNTRY_PINCODE");

                            beinvoice.broker_name = getInvoiceString(row, "BROKER_ADDRESS");
                            beinvoice.broker_address_1 = getInvoiceString(row, "BROKER_ADDRESS");
                            beinvoice.broker_address_2 = getInvoiceString(row, "BROKER_ADDRESS1");
                            beinvoice.broker_address_3 = getInvoiceString(row, "BROKER_ADDRESS2");
                            beinvoice.broker_country_name = getInvoiceString(row, "BROKER_COUNTRY_NAME");
                            beinvoice.broker_post_code = getInvoiceString(row, "BROKER_COUNTRY_PINCODE");

                            beinvoice.invoice_value = getInvoiceString(row, "INVOICE_VALUE");
                            beinvoice.invoice_terms = getInvoiceString(row, "TERMS");
                            beinvoice.invoice_currency = getInvoiceString(row, "INVOICE_CURRENCY");

                            beinvoice.nature_of_discount = getInvoiceString(row, "MIS_DISCOUNT_REASON");
                            beinvoice.discount_rate = getInvoiceString(row, "MIS_DISCOUNT_RATE");

                            beinvoice.hss_load_rate = getInvoiceString(row, "MIS_HIGHSEASALE_RATE");
                            beinvoice.hss_load_amount = getInvoiceString(row, "MIS_HIGHSEASALE_CHARGES");

                            beinvoice.freight_currency = getInvoiceString(row, "MIS_FREIGHT_CURRENCY");
                            beinvoice.freight_rate = getInvoiceString(row, "MIS_FREIGHT_RATE");
                            beinvoice.freight_value = getInvoiceString(row, "MIS_FREIGHT_CHARGES");
                            beinvoice.whether_freight_is_actual = DocumentConstants.Blank;

                            beinvoice.insurance_currency = getInvoiceString(row, "MIS_INSURANCE_CURRENCY");
                            beinvoice.insurance_rate = getInvoiceString(row, "MIS_INSURANCE_RATE");
                            beinvoice.insurance_value = getInvoiceString(row, "MIS_INSURANCE_CHARGES");

                            beinvoice.misc_charges_currency = getInvoiceString(row, "MIS_CURRENCY");
                            beinvoice.misc_charges_rate = getInvoiceString(row, "MIS_RATE");
                            beinvoice.misc_charges_value = getInvoiceString(row, "MIS_CHARGES");

                            beinvoice.landing_rate = DocumentConstants.Blank;
                            beinvoice.loading_currency = getInvoiceString(row, "MIS_LOADING_CURRENCY");
                            beinvoice.loading_rate = getInvoiceString(row, "MIS_LOADING_RATE");
                            beinvoice.loading_charges = getInvoiceString(row, "MIS_LOADING_CHARGES");

                            beinvoice.agency_commission_rate = getInvoiceString(row, "MIS_AGENCY_RATE");
                            beinvoice.agency_commission_amount = getInvoiceString(row, "MIS_AGENCY_CHARGES");

                            beinvoice.nature_of_transaction = getInvoiceString(row, "OTHER_NATURE_OF_TRANSACTION");
                            beinvoice.payment_terms = getInvoiceString(row, "OTHER_TERMS_OF_PAYMENT");

                            beinvoice.conditions_with_sale_1 = getInvoiceString(row, "OTHER_CONDITIONS");
                            beinvoice.conditions_with_sale_2 = DocumentConstants.Blank;
                            beinvoice.conditions_with_sale_3 = DocumentConstants.Blank;
                            beinvoice.conditions_with_sale_4 = DocumentConstants.Blank;
                            beinvoice.conditions_with_sale_5 = DocumentConstants.Blank;

                            beinvoice.other_relevant_information = DocumentConstants.Blank;
                            beinvoice.valuation_method_applicable = getInvoiceString(row, "OTHER_VALUATION_METHOD");

                            billOfEntry.invoice_info.Add(beinvoice);
                            Logger.LogInfoFormat("Invoice #{0} added successfully", invoiceCount);
                        }
                        catch (Exception ex)
                        {
                            Logger.LogErrorFormat("Failed to process Invoice #{0}", invoiceCount);
                            Logger.LogError("Invoice processing exception:", ex);
                        }
                    }

                    int successCount = billOfEntry.invoice_info != null ? billOfEntry.invoice_info.Count : 0;
                    Logger.LogInfoFormat("Successfully added {0} invoices", successCount);
                }
                else
                {
                    Logger.LogWarning("No invoice data found (Table[6] is empty or null)");
                }
                #endregion

                #region containerDetails
                if (rowContainerDetails != null && rowContainerDetails.Rows.Count > 0)
                {
                    Logger.LogInfoFormat("Processing {0} Container Details ", rowContainerDetails.Rows.Count);
                    int itemCount = 0;

                    foreach (DataRow rw in rowContainerDetails.Rows)
                    {
                        try
                        {
                            itemCount++;
                            Logger.LogDebugFormat("Processing Container Details Item  #{0}", itemCount);

                            BeContainerInfo beContainerItem = new BeContainerInfo();
                            beContainerItem.container_number = SafeGetString(rw, "CONTAINER_NO");
                            beContainerItem.container_size = SafeGetString(rw, "TYPE");
                            beContainerItem.lcl_fcl = SafeGetString(rw, "FCL_OR_LCL");
                            beContainerItem.excise_seal_no = SafeGetString(rw, "SEAL_NO");

                            billOfEntry.container_info.Add(beContainerItem);
                            Logger.LogDebugFormat("BE Container Detials Item #{0} added successfully", itemCount);
                        }
                        catch (Exception ex)
                        {
                            Logger.LogErrorFormat("Failed to process Item #{0}", itemCount);
                            Logger.LogError("Container Details Item processing exception:", ex);
                        }
                    }
                    int successCount = billOfEntry.container_info != null ? billOfEntry.container_info.Count : 0;
                    Logger.LogInfoFormat("Successfully added {0} Container detials Item", successCount);
                }
                else
                {
                    Logger.LogWarning("No Container ITEM Details data found (Table[3] is empty or null)");
                }
                #endregion containerDetails

                #region swinfotypeDetails
                if (rowSWInfoTypeDetails != null && rowSWInfoTypeDetails.Rows.Count > 0)
                {
                    Logger.LogInfoFormat("Processing {0} sw info Details ", rowSWInfoTypeDetails.Rows.Count);
                    int itemCount = 0;

                    foreach (DataRow rw in rowSWInfoTypeDetails.Rows)
                    {
                        try
                        {
                            if (SafeGetString(rw, "INFO_TYPE") != "CHR" || SafeGetString(rw, "INFO_QUALIFIER") != "SQC")
                            {
                                continue;
                            }

                            itemCount++;
                            Logger.LogDebugFormat("Processing sw Details Item  #{0}", itemCount);

                            BeItemSWInfoTypeInfo beSWInfo  = new BeItemSWInfoTypeInfo();
                            beSWInfo.info_msr = SafeGetString(rw, "INFO_MSR");
                            beSWInfo.info_uqc = SafeGetString(rw, "INFO_UQC");
                            billOfEntry.swinfotype_info.Add(beSWInfo);
                            Logger.LogDebugFormat("BE SW Detials Item #{0} added successfully", itemCount);
                        }
                        catch (Exception ex)
                        {
                            Logger.LogErrorFormat("Failed to process Item #{0}", itemCount);
                            Logger.LogError("sw info type Details Item processing exception:", ex);
                        }
                    }
                    int successCount = billOfEntry.swinfotype_info != null ? billOfEntry.swinfotype_info.Count : 0;
                    Logger.LogInfoFormat("Successfully added {0} sw detials Item", successCount);
                }
                else
                {
                    Logger.LogWarning("No swinfotype_info ITEM Details data found (Table[3] is empty or null)");
                }
                #endregion swinfotypeDetails

                #region exchangeinfoDetails
                if (rowInvoiceImport != null && rowInvoiceImport.Rows.Count > 0)
                {
                    DataRow firstRow = rowInvoiceImport.Rows[0];
                    beExchangeInfo.rate = getInvoiceString(firstRow, "INVOICE_EXRATE");
                }
                billOfEntry.exchange_info = beExchangeInfo;
                Logger.LogInfoFormat("ExchangeInfo rate mapped successfully...");               
                #endregion exchangeinfoDetails
                
                #region ITEM Details_BillofEntry
                if (rowItemDetails != null && rowItemDetails.Rows.Count > 0)
                {
                    Logger.LogInfoFormat("Processing {0} ITEM", rowItemDetails.Rows.Count);
                    int itemCount = 0;

                    foreach (DataRow rw in rowItemDetails.Rows)
                    {
                        try
                        {
                            itemCount++;
                            Logger.LogDebugFormat("Processing Item  #{0}", itemCount);

                            BeItemsInfo beitem = new BeItemsInfo();
                            beitem.quantity = SafeGetString(rw, "ITEM_QTY");
                            beitem.unit_price = SafeGetString(rw, "ITEM_UNIT_PRICE");
                            beitem.ritc_code_itchs_code = SafeGetString(rw, "PRODUCT_RITC");

                            beitem.description_of_the_goods_1 = GetItemInfoPart(rw, "ITEM_DESCRIPTION", 0, 100);
                            beitem.description_of_the_goods_2 = GetItemInfoPart(rw, "ITEM_DESCRIPTION", 101, 200);

                            beitem.unit_quantity_code = SafeGetString(rw, "ITEM_QTY_CODE");
                            //beitem.unit_price_invoiced = SafeGetString(rw, "ITEM_UNIT_PRICE");

                            beitem.item_category = SafeGetString(rw, "SCHEME_CODE");
                            beitem.generic_description = GetItemInfoPart(rw, "GENEARL_DESCRIPTION", 0, 100);

                            beitem.svb_loading_on = SafeGetString(rw, "SVB_LOADING_ON");
                            beitem.svb_assesable_rate = SafeGetString(rw, "SVB_ASSESABLE_RATE");
                            beitem.svb_assesable_status = SafeGetString(rw, "SVB_ASSESABLE_STATUS");
                            beitem.svb_duty_rate = SafeGetString(rw, "SVB_DUTY_RATE");                            
                            beitem.svb_duty_status = SafeGetString(rw, "SVB_DUTY_STATUS");

                            billOfEntry.items_info.Add(beitem);
                            Logger.LogDebugFormat("BE Item #{0} added successfully", itemCount);
                        }
                        catch (Exception ex)
                        {
                            Logger.LogErrorFormat("Failed to process Item #{0}", itemCount);
                            Logger.LogError("Item processing exception:", ex);
                        }
                    }
                    int successCount = billOfEntry.items_info != null ? billOfEntry.items_info.Count : 0;
                    Logger.LogInfoFormat("Successfully added {0} Item", successCount);
                }
                else
                {
                    Logger.LogWarning("No ITEM Details data found (Table[7] is empty or null)");
                }
                #endregion for ITEM DETAILS

                #region  IGM Details_BillofEntry
                if (rowIgmDetails != null && rowIgmDetails.Rows.Count > 0)
                {
                    Logger.LogInfoFormat("Processing {0} IGM", rowIgmDetails.Rows.Count);
                    int itemCount = 0;

                    foreach (DataRow rw in rowIgmDetails.Rows)
                    {
                        try
                        {
                            itemCount++;
                            Logger.LogDebugFormat("Processing IGM #{0}", itemCount);

                            BeIgmsInfo beii = new BeIgmsInfo();
                            beii.custom_house_code = getInvoiceString(rowGeneralImport, "CUSTOMS_HOUSE");
                            beii.cha_license_no = HttpContext.Current.Session["CHA_NO"].ToString();

                            beii.user_job_no = getInvoiceString(rowGeneralImport, "JOBNO");
                            beii.user_job_date = GetApiDate(getInvoiceString(rowGeneralImport, "JOBDATE"));             //JOB DATE

                            beii.igm_no = getInvoiceString(rw, "IGM_NO");

                            beii.igm_date = GetApiDate(getInvoiceString(rw, "IGM_DATE"));                                //IGMDATE
                            beii.inward_date = getInvoiceString(rw, "IGM_FLIGHT_VESSELDATE");                            //INWARD DATE

                            beii.gateway_igm_no = getInvoiceString(rw, "IGM_GATEWAY_IGM_NO");
                            beii.gateway_igm_date = GetApiDate(getInvoiceString(rw, "IGM_GATEWAY_IGM_DATE"));            //GATEWAYIGMDATE

                            beii.port_of_reporting = getInvoiceString(rw, "IGM_GATEWAY_PORT_CODE");

                            beii.mawb_bl_no = getInvoiceString(rw, "IGM_MAWB_MBL");
                            beii.mawb_bl_date = GetApiDate(getInvoiceString(rw, "IGM_MAWB_MBLDATE"));                    //MAWBLDATE

                            beii.hawb_hbl_no = getInvoiceString(rw, "IGM_HAWB_HBLNO");
                            beii.hawb_hbl_date = GetApiDate(getInvoiceString(rw, "IGM_HAWB_HBLDATE"));                   //HAWBDATE

                            beii.total_no_of_packages = getInvoiceString(rw, "IGM_NOOFPACKAGE");
                            beii.gross_weight = getInvoiceString(rw, "IGM_GROSSWEIGHT");
                            beii.unit_quantity_code = getInvoiceString(rw, "IGM_TYPEOFWEIGHT");
                            beii.package_code = getInvoiceString(rw, "IGM_PACKAGETYPE");

                            beii.marks_and_numbers_1 = GetItemInfoPart(rw, "IGM_MARKSNOS", 0, 100);
                            beii.marks_and_numbers_2 = GetItemInfoPart(rw, "IGM_MARKSNOS", 101, 200);
                            beii.marks_and_numbers_3 = GetItemInfoPart(rw, "IGM_MARKSNOS", 201, 300);

                            billOfEntry.igms_info.Add(beii);
                            Logger.LogDebugFormat("BE IGM #{0} added successfully", itemCount);
                        }
                        catch (Exception ex)
                        {
                            Logger.LogErrorFormat("Failed to process IGM #{0}", itemCount);
                            Logger.LogError("IGM processing exception:", ex);
                        }
                    }
                    int successCount = billOfEntry.igms_info != null ? billOfEntry.igms_info.Count : 0;
                    Logger.LogInfoFormat("Successfully added {0} IGM", successCount);
                }
                else
                {
                    Logger.LogWarning("No IGM data found (Table[2] is empty or null)");
                }
                #endregion
            }
            else
            {
                Logger.LogDebug("The BE_ENTRY rows are null, and no entry was found for this job number. Hence, the dataset mapping could not be performed for Bill of Entry...");
            }
            Logger.LogInfo("=== MapDataSetToBillofEntry COMPLETED successfully ===");
            return billOfEntry;
        }
        catch (Exception ex)
        {
            Logger.LogError("MapDataSetToBillofEntry failed", ex);
            throw new InvalidOperationException("Failed to map DataSet to Bill of Entry", ex);
        }
    }


    /// <summary>
    /// Shipping Bill DETAILS 
    /// </summary>
    /// <param name="ds"></param>
    /// <returns></returns>
    public static ShippingBill MapDataSetToShippingBill(DataSet ds)
    {
        Logger.LogInfo("=== Map DataSet To ShippingBill /Export STARTED ===");

        String TransportMode = string.Empty;
        String ShippingModeFileType = string.Empty;
        ShippingBill shippingBill = new ShippingBill();
        Header header = new Header();
        GeneralInfo generalInfo = new GeneralInfo();
        List<InvoiceInfo> invoiceinfo = new List<InvoiceInfo>();
        List<ItemInfo> item_info = new List<ItemInfo>();
        DbkInfo dbk_info = new DbkInfo();
        ExchangeInfo exi = new ExchangeInfo();
        LicenseInfo license_info = new LicenseInfo();
        List<ContainerInfo> container_info = new List<ContainerInfo>();

        if (ds.Tables.Count == 0)
        {
            return shippingBill;
        }

        try
        {
            if (ds.Tables.Count > 0 && ds.Tables[20].Rows.Count > 0)
            {
                DataRow exportSBEntry = ds.Tables[20].Rows.Count > 0 ? ds.Tables[20].Rows[0] : null; //For Sb Entry Table 20

                DataRow rowGeneral = ds.Tables[0].Rows.Count > 0 ? ds.Tables[0].Rows[0] : null;  //EXPORT_GENERAL_DETAILS
                DataRow rowTableTransmodebased = ds.Tables[1].Rows.Count > 0 ? ds.Tables[1].Rows[0] : null;  // Based on TransportMode  // EXPORT_ANNEXURE_C_AIR OR EXPORT_ANNEXURE_C_SEA

                DataTable exportAnnexureSeaContainer = ds.Tables[2];   //EXPORT_ANNEXURE_C_SEA_CONTAINER  table 2                 
                DataTable rowInvoice = ds.Tables[4]; // for Invoice Details
                DataTable rowItemInfo = ds.Tables[6]; //for Item details
                DataTable dbkInfo = ds.Tables[7]; // for DrawBack Details Table 7
                DataTable licenseInfo = ds.Tables[13]; //for License details

                DataTable exportSWINFOTYPE = ds.Tables[14]; // Table 14 for state of origin in invoice 
                //DataRow exportSBEntry = ds.Tables[20].Rows.Count > 0 ? ds.Tables[20].Rows[0] : null; //For Sb Entry Table 20


                TransportMode = rowGeneral["TRANSPORT_MODE"].ToString().ToUpper();
                shippingBill.doc_type = DocumentConstants.DocTypeSB;

                String headerFileType = SafeGetString(rowGeneral, "EXPOTER_CLASS");
                if (headerFileType == "GOVERNMENT" || headerFileType == "GOVERNMENT DEPARTMENTS")
                {
                    ShippingModeFileType = "G";
                }
                else if (headerFileType == "GOVERNMENT UNDERTAKINGS")
                {
                    ShippingModeFileType = "U";
                }
                else if (headerFileType == "OTHERS")
                {
                    ShippingModeFileType = "O";
                }
                else if (headerFileType == "PRIVATE")
                {
                    ShippingModeFileType = "P";
                }
                else if (headerFileType == "HAND CARRIAGE")
                {
                    ShippingModeFileType = "H";
                }
                else
                {
                    ShippingModeFileType = DocumentConstants.Blank;
                }

                #region Header
                Logger.LogDebug("Mapping SHIPPING BILL /EXPORT Header section...");
                header.company_id = Connection.Company_License();
                header.record_type = DocumentConstants.RecordTypeHREC;
                header.sender_id_type = DocumentConstants.SenderIdTypeZZ;
                header.sender_id = HttpContext.Current.Session["ICEGATE_ID"].ToString();
                header.receiver_id_type = DocumentConstants.ReceiverIdTypeZZ;
                header.receiver_id = SafeGetString(rowGeneral, "CUSTOMS_HOUSE");
                header.version = DocumentConstants.VersionIces1_5;
                header.file_type = ShippingModeFileType;
                header.blank_1 = DocumentConstants.Blank1;
                header.message_id = DocumentConstants.MessageIdCache01;
                header.sequence_no = DocumentConstants.Blank1;
                header.date = DateTimeFormats.GetCurrentDate();
                header.time = DateTimeFormats.GetCurrentTime();

                shippingBill.header = header;
                Logger.LogDebug("Header SHIPPING BILL /EXPORT mapped successfully");
                #endregion Header


                #region GENERAL details
                if (rowGeneral != null)
                {
                    Logger.LogDebug("Mapping SHIPPING BILL /EXPORT General Info section...");
                    generalInfo.custom_house_code = SafeGetString(rowGeneral, "CUSTOMS_HOUSE");
                    generalInfo.cha_license_no = HttpContext.Current.Session["CHA_NO"].ToString();

                    generalInfo.user_job_no = SafeGetString(rowGeneral, "JOBNO");
                    generalInfo.user_job_date = GetApiDate(SafeGetString(rowGeneral, "JOBDATE"));               //jobdate

                    generalInfo.sb_no = SafeGetString(exportSBEntry, "sb_no");
                    generalInfo.sb_date = GetApiDate(SafeGetString(exportSBEntry, "sb_date"));                  //SB DATE

                    generalInfo.icegate_user_id = HttpContext.Current.Session["ICEGATE_ID"].ToString();
                    generalInfo.importer_exporter_code = SafeGetString(rowGeneral, "IEC_NO");
                    generalInfo.branch_sr_no_of_exporter = SafeGetString(rowGeneral, "BRANCH_NO");
                    generalInfo.imp_exp_name = SafeGetString(rowGeneral, "EXPORTER_NAME");

                    generalInfo.imp_exp_address = SafeGetString(rowGeneral, "ADDRESS1");
                    generalInfo.imp_exp_address_2 = SafeGetString(rowGeneral, "ADDRESS2");
                    generalInfo.imp_exp_city = SafeGetString(rowGeneral, "ADDRESS3");
                    generalInfo.imp_exp_state = SafeGetString(rowGeneral, "ADDRESS4");
                    generalInfo.imp_exp_pin = SafeGetString(rowGeneral, "ADDRESS5");

                    String type_of_exporter_and_exporter_class = SafeGetString(rowGeneral, "EXPOTER_CLASS");
                    if (type_of_exporter_and_exporter_class == "GOVERNMENT" || type_of_exporter_and_exporter_class == "GOVERNMENT DEPARTMENTS")
                    {
                        generalInfo.type_of_exporter = "G";
                        generalInfo.exporter_class = "G";
                    }
                    else if (type_of_exporter_and_exporter_class == "GOVERNMENT UNDERTAKINGS")
                    {
                        generalInfo.type_of_exporter = "U";
                        generalInfo.exporter_class = "U";
                    }
                    else if (type_of_exporter_and_exporter_class == "OTHERS")
                    {
                        generalInfo.type_of_exporter = "O";
                        generalInfo.exporter_class = "O";
                    }
                    else if (type_of_exporter_and_exporter_class == "PRIVATE")
                    {
                        generalInfo.type_of_exporter = "P";
                        generalInfo.exporter_class = "P";
                    }
                    else if (type_of_exporter_and_exporter_class == "HAND CARRIAGE")
                    {
                        generalInfo.type_of_exporter = "H";
                        generalInfo.exporter_class = "H";

                    }
                    else
                    {
                        generalInfo.type_of_exporter = DocumentConstants.Blank;
                        generalInfo.exporter_class = DocumentConstants.Blank;
                    }

                    generalInfo.state_of_origin_exporter = SafeGetString(rowGeneral, "STATE_CODE");
                    generalInfo.authorized_dealer_code = SafeGetString(rowGeneral, "ADCODE");

                    generalInfo.epz_code = DocumentConstants.Blank;

                    generalInfo.consignee_name = SafeGetString(rowGeneral, "CONSIGNEE_NAME");
                    generalInfo.consignee_address_1 = SafeGetString(rowGeneral, "CONSIGNEE_ADD1");
                    generalInfo.consignee_address_2 = SafeGetString(rowGeneral, "CONSIGNEE_ADD2");
                    generalInfo.consignee_address_3 = SafeGetString(rowGeneral, "CONSIGNEE_ADD3");
                    generalInfo.consignee_address_4 = SafeGetString(rowGeneral, "CONSIGNEE_ADD4");
                    generalInfo.consignee_country = SafeGetString(rowGeneral, "CONSIGNEE_ADD5");

                    generalInfo.category_of_nfei_sb = SafeGetString(rowGeneral, "NFEI");

                    generalInfo.rbi_waiver_no = SafeGetString(rowGeneral, "RBI_WAIVER_NO");
                    generalInfo.rbi_waiver_date = GetApiDate(SafeGetString(rowGeneral, "RBI_WAIVER_DATE"));         //waiver date

                    generalInfo.port_of_loading = SafeGetString(rowGeneral, "PORT_OF_LOADING");
                    generalInfo.port_of_discharge = SafeGetString(rowGeneral, "PORT_DISCHARGE");

                    generalInfo.country_of_discharge = SafeGetString(rowGeneral, "COUNTRY_DISCHARGE");
                    generalInfo.port_of_final_destination = SafeGetString(rowGeneral, "PORT_FINAL_DEST");
                    generalInfo.country_of_final_destination = SafeGetString(rowGeneral, "COUNTRY_FINAL_DEST");

                    generalInfo.seal_type = MapSealTypeCode(SafeGetString(rowTableTransmodebased, "ANNEX_SEA_SEAL_TYPE"));               //<----------- diff table 

                    if (TransportMode == DocumentConstants.TRANSPORT_MODE_AIR)
                    {
                        generalInfo.nature_of_cargo = MapNatureofCargo(SafeGetString(rowTableTransmodebased, "ANNEX_AIR_NATURE_OF_CARGO"));
                        generalInfo.gross_weight = SafeGetString(rowTableTransmodebased, "ANNEX_AIR_GROSS_WEIGHT");
                        generalInfo.net_weight = SafeGetString(rowTableTransmodebased, "ANNEX_AIR_NET_WEIGHT");
                        generalInfo.unit_of_measurement = SafeGetString(rowTableTransmodebased, "ANNEX_AIR_UNIT_CODE");
                        generalInfo.total_no_of_packages = SafeGetString(rowTableTransmodebased, "ANNEX_AIR_TOTAL_PACKAGES");
                        generalInfo.marks_and_numbers = SafeGetString(rowTableTransmodebased, "ANNEX_AIR_MARKS_NOS");
                    }
                    else if (TransportMode == DocumentConstants.TRANSPORT_MODE_SEA || TransportMode == DocumentConstants.TRANSPORT_MODE_LAND)
                    {
                        generalInfo.nature_of_cargo = MapNatureofCargo(SafeGetString(rowTableTransmodebased, "ANNEX_SEA_NATURE_OF_CARGO"));
                        generalInfo.gross_weight = SafeGetString(rowTableTransmodebased, "ANNEX_SEA_GROSS_WEIGHT");
                        generalInfo.net_weight = SafeGetString(rowTableTransmodebased, "ANNEX_SEA_NET_WEIGHT");
                        generalInfo.unit_of_measurement = SafeGetString(rowTableTransmodebased, "ANNEX_SEA_UNIT_MEASUREMENT");
                        generalInfo.total_no_of_packages = SafeGetString(rowTableTransmodebased, "ANNEX_SEA_TOTAL_PACKAGES");
                        generalInfo.marks_and_numbers = SafeGetString(rowTableTransmodebased, "ANNEX_SEA_MARKS_NOS");
                    }

                    generalInfo.no_of_loose_packets = SafeGetString(rowTableTransmodebased, "ANNEX_SEA_LOOSE_PACKETS");
                    generalInfo.no_of_containers = SafeGetString(rowTableTransmodebased, "ANNEX_SEA_NO_CONTAINERS");
                    generalInfo.mawb_no = SafeGetString(rowTableTransmodebased, "ANNEX_AIR_MAWB_NO");
                    generalInfo.hawb_no = SafeGetString(rowTableTransmodebased, "ANNEX_AIR_HAWB_NO");
                    generalInfo.gstn_type = SafeGetString(rowGeneral, "GSTN_TYPE");
                    generalInfo.gstn_id = SafeGetString(rowGeneral, "GSTN_ID");

                    shippingBill.general_info = generalInfo;
                    Logger.LogDebug("General Info mapped successfully");
                }
                #endregion


                #region invoice Details
                if (rowInvoice != null && rowInvoice.Rows.Count > 0)
                {
                    Logger.LogInfoFormat("Processing {0} invoices", rowInvoice.Rows.Count);
                    int invoiceCount = 0;

                    foreach (DataRow row in rowInvoice.Rows)
                    {
                        try
                        {
                            invoiceCount++;
                            Logger.LogDebugFormat("Processing Invoice #{0}", invoiceCount);

                            InvoiceInfo invoice = new InvoiceInfo();
                            invoice.custom_house_code = getInvoiceString(rowGeneral, "CUSTOMS_HOUSE");
                            invoice.cha_license_no = HttpContext.Current.Session["CHA_NO"].ToString();
                            invoice.user_job_no = getInvoiceString(rowGeneral, "JOBNO");
                            invoice.user_job_date = GetApiDate(getInvoiceString(rowGeneral, "JOBDATE"));            //jobdate

                            invoice.invoice_sr_no = getInvoiceString(row, "INVOICE_SLNO");
                            invoice.actual_invoice_no = getInvoiceString(row, "INVOICE_NO");
                            invoice.invoice_date = GetApiDate(getInvoiceString(row, "INVOICE_DATE"));             //invoice date
                            invoice.invoice_currency = getInvoiceString(row, "INVOICE_CURRENCY");
                            invoice.nature_of_contract = getInvoiceString(row, "TERMS");

                            invoice.buyer_name = getInvoiceString(row, "BUYER_NAME");
                            invoice.buyer_address_1 = getInvoiceString(row, "BUYER_ADDRESS1");
                            invoice.buyer_address_2 = getInvoiceString(row, "BUYER_ADDRESS2");
                            invoice.buyer_address_3 = getInvoiceString(row, "BUYER_ADDRESS3");
                            invoice.buyer_address_4 = getInvoiceString(row, "BUYER_ADDRESS4");

                            invoice.freight_currency = getInvoiceString(row, "FREIGHT_CURRENCY");
                            invoice.freight_amount = getInvoiceString(row, "FREIGHT_CHARGES");

                            invoice.insurance_rate = getInvoiceString(row, "INSURANCE_RATE");
                            invoice.insurance_currency = getInvoiceString(row, "INSURANCE_CURRENCY");
                            invoice.insurance_amount = getInvoiceString(row, "INSURANCE_CHARGES");

                            invoice.commission_rate = getInvoiceString(row, "COMMISSION_RATE");
                            invoice.commission_currency = getInvoiceString(row, "COMMISSION_CURRENCY");
                            invoice.commission_amount = getInvoiceString(row, "COMMISSION_CHARGES");

                            invoice.discount_on_fob = getInvoiceString(row, "FOB_RATE");
                            invoice.discount_currency = getInvoiceString(row, "FOB_CURRENCY");
                            invoice.discount_amount = getInvoiceString(row, "FOB_CHARGES");

                            invoice.other_deductions = getInvoiceString(row, "OTHER_DEDUCTION_RATE");
                            invoice.other_deductions_currency = getInvoiceString(row, "OTHER_DEDUCTION_CURRENCY");
                            invoice.other_deductions_amount = getInvoiceString(row, "OTHER_DEDUCTION_CHARGES");

                            invoice.add_freight = getInvoiceString(row, "WHEATHER_UNIT_PRICE");
                            invoice.packing_charges = getInvoiceString(row, "PACKMISC_CHARGES");
                            invoice.exporter_contract_no = getInvoiceString(row, "CONTRACT_NO");
                            invoice.nature_of_payment = getInvoiceString(row, "PAYMENT_METHOD");
                            invoice.period_of_payment_in_days = getInvoiceString(row, "PERIOD_PAYMENT");

                            invoice.invoice_value_fcy = getInvoiceString(row, "INVOICE_VALUE");
                            invoice.invoice_value_inr = getInvoiceString(row, "INVOICE_CURRENCY");

                            invoice.ritc = DocumentConstants.Blank;
                            invoice.fob_value = DocumentConstants.Blank;
                            invoice.dbk_code = DocumentConstants.Blank;
                            invoice.dbk_amount = DocumentConstants.Blank;

                            invoice.exchange_rate = getInvoiceString(row, "EXCHANGE_RATE");
                            invoice.state_of_origin = SafeGetString(rowGeneral, "STATE_CODE");

                            if (TransportMode == DocumentConstants.TRANSPORT_MODE_AIR)
                            {
                                invoice.gross_weight = getInvoiceString(rowTableTransmodebased, "ANNEX_AIR_GROSS_WEIGHT");
                                invoice.net_weight = getInvoiceString(rowTableTransmodebased, "ANNEX_AIR_NET_WEIGHT");
                            }
                            else if (TransportMode == DocumentConstants.TRANSPORT_MODE_SEA || TransportMode == DocumentConstants.TRANSPORT_MODE_LAND)
                            {
                                invoice.gross_weight = getInvoiceString(rowTableTransmodebased, "ANNEX_SEA_GROSS_WEIGHT");
                                invoice.net_weight = getInvoiceString(rowTableTransmodebased, "ANNEX_SEA_NET_WEIGHT");

                                //invoice.container_no = getInvoiceString(rowTableTransmodebased, "ANNEX_SEA_NO_CONTAINERS");         //table 1 - EXPORT_ANNEXURE_C_SEA
                                //invoice.container_size = getInvoiceString(exportAnnexureSeaContainer, "ANNEX_SEA_CON_SIZE");            //table 2 - EXPORT_ANNEXURE_C_SEA_CONTAINER                      
                                //invoice.excise_seal_no = getInvoiceString(exportAnnexureSeaContainer, "ANNEX_SEA_CON_EXCISE_SEALNO");   //table 2 - EXPORT_ANNEXURE_C_SEA_CONTAINER 
                                //invoice.lcl_fcl = DocumentConstants.Blank1;
                            }
                            shippingBill.invoice_info.Add(invoice);
                            Logger.LogDebugFormat("Invoice #{0} added successfully", invoiceCount);
                        }
                        catch (Exception ex)
                        {
                            Logger.LogErrorFormat("Failed to process Invoice #{0}", invoiceCount);
                            Logger.LogError("Invoice processing exception:", ex);
                        }
                    }
                    int successCount = shippingBill.invoice_info != null ? shippingBill.invoice_info.Count : 0;
                    Logger.LogInfoFormat("Successfully added Shipping Bill {0} invoices", successCount);
                }
                #endregion


                #region Container Info Details
                //table 2 - EXPORT_ANNEXURE_C_SEA_CONTAINER
                if (exportAnnexureSeaContainer != null && exportAnnexureSeaContainer.Rows.Count > 0)
                {
                    Logger.LogInfoFormat("Processing SB container details {0} items", exportAnnexureSeaContainer.Rows.Count);
                    int itemCount = 0;

                    foreach (DataRow item in exportAnnexureSeaContainer.Rows)
                    {
                        try
                        {
                            itemCount++;
                            Logger.LogDebugFormat("Processing Container Dtls Item #{0}", itemCount);

                            ContainerInfo containerItemIfo = new ContainerInfo();

                            containerItemIfo.container_number = getInvoiceString(item, "ANNEX_SEA_CON_CONTAINERNO");
                            containerItemIfo.container_size = getInvoiceString(item, "ANNEX_SEA_CON_SIZE");
                            containerItemIfo.excise_seal_no = getInvoiceString(item, "ANNEX_SEA_CON_EXCISE_SEALNO");
                            containerItemIfo.lcl_fcl = DocumentConstants.Blank1;

                            shippingBill.container_info.Add(containerItemIfo);
                            Logger.LogDebugFormat("Container Item #{0} added successfully", itemCount);
                        }
                        catch (Exception ex)
                        {
                            Logger.LogErrorFormat("Failed to process container Item #{0}", itemCount);
                            Logger.LogError("container Item processing exception:", ex);
                        }
                    }
                    int successCount = shippingBill.container_info != null ? shippingBill.container_info.Count : 0;
                    Logger.LogInfoFormat("Successfully added {0} container items", successCount);
                }
                else
                {
                    Logger.LogWarning("No container item data found (Table[2] is empty or null)");
                }
                #endregion Invoice Item Details


                #region Item Info Details
                if (rowItemInfo != null && rowItemInfo.Rows.Count > 0)
                {
                    Logger.LogInfoFormat("Processing {0} items", rowItemInfo.Rows.Count);
                    int itemCount = 0;

                    foreach (DataRow item in rowItemInfo.Rows)
                    {
                        try
                        {
                            itemCount++;
                            Logger.LogDebugFormat("Processing Item #{0}", itemCount);
                            #region a
                            ItemInfo itminfo = new ItemInfo();

                            itminfo.custom_house_code = SafeGetString(rowGeneral, "CUSTOMS_HOUSE");
                            itminfo.user_job_no = getItemInfoString(rowGeneral, "JOBNO");
                            itminfo.user_job_date = GetApiDate(getItemInfoString(rowGeneral, "JOBDATE"));           //job date

                            itminfo.invoice_sr_no = getItemInfoString(item, "INVOICE_SLNO");
                            itminfo.item_sr_no = getItemInfoString(item, "ITEM_SLNO");
                            itminfo.cha_license_no = HttpContext.Current.Session["CHA_NO"].ToString();

                            itminfo.sb_no = SafeGetString(exportSBEntry, "SB_NO");
                            itminfo.sb_date = GetApiDate(SafeGetString(exportSBEntry, "SB_DATE"));              //sb date

                            itminfo.scheme_code = getItemInfoString(item, "ITEM_SCHEME_CODE");
                            itminfo.ritc_code_itchs_code = getItemInfoString(item, "RITCNO");

                            itminfo.description_of_the_goods_1 = GetItemInfoPart(item, "ITEM_DESCRIPTION", 0, 40);
                            itminfo.description_of_the_goods_2 = GetItemInfoPart(item, "ITEM_DESCRIPTION", 41, 80);
                            itminfo.description_of_the_goods_3 = GetItemInfoPart(item, "ITEM_DESCRIPTION", 81, 120);

                            itminfo.unit_of_measurement = getItemInfoString(item, "ITEM_QTY_CODE");
                            itminfo.quantity = getItemInfoString(item, "ITEM_QTY");
                            itminfo.unit_price = getItemInfoString(item, "ITEM_UNIT_PRICE");
                            itminfo.unit_of_rate = getItemInfoString(item, "ITEM_UNIT_PRICE");
                            itminfo.no_of_units_per = getItemInfoString(item, "ITEM_PER");
                            itminfo.present_market_value_lcy = getItemInfoString(item, "ITEM_AMOUNT");
                            itminfo.job_work_notification_no = DocumentConstants.Blank;

                            string iecCode = getItemInfoString(item, "ITEM_IECCODE");
                            itminfo.third_party = string.IsNullOrWhiteSpace(iecCode) ? "N" : "Y";

                            itminfo.reward_item = getItemInfoString(item, "REWARD_POINTS");

                            shippingBill.item_info.Add(itminfo);
                            Logger.LogDebugFormat("Item #{0} added successfully", itemCount);
                            #endregion a
                        }
                        catch (Exception ex)
                        {
                            Logger.LogErrorFormat("Failed to process Item #{0}", itemCount);
                            Logger.LogError("Item processing exception:", ex);
                        }
                    }
                    int successCount = shippingBill.item_info != null ? shippingBill.item_info.Count : 0;
                    Logger.LogInfoFormat("Successfully added {0} items", successCount);
                }
                else
                {
                    Logger.LogWarning("No item data found (Table[6] is empty or null)");
                }
                #endregion Invoice Item Details

                #region Drawback Details
                if (dbkInfo != null && dbkInfo.Rows.Count > 0)
                {
                    Logger.LogDebug("Processing Drawback details");
                    DataRow row = dbkInfo.Rows[0];
                    dbk_info.custom_house_code = SafeGetString(rowGeneral, "CUSTOMS_HOUSE");
                    dbk_info.user_job_no = SafeGetString(rowGeneral, "JOBNO");
                    dbk_info.user_job_date = GetApiDate(SafeGetString(rowGeneral, "JOBDATE"));          //job date

                    dbk_info.item_sr_no = SafeGetString(row, "ITEM_SLNO");
                    dbk_info.dbk_schedule_no = SafeGetString(row, "DRAWBACK_SLNO");
                    dbk_info.cha_license_no = HttpContext.Current.Session["CHA_NO"].ToString();
                    dbk_info.invoice_sr_no = SafeGetString(row, "INVOICE_SLNO");

                    dbk_info.sb_no = SafeGetString(exportSBEntry, "sb_no");
                    dbk_info.sb_date = GetApiDate(SafeGetString(exportSBEntry, "sb_date"));         //sb date

                    dbk_info.drawback_quantity = SafeGetString(row, "DRAWBACK_QTY");

                    shippingBill.dbkInfo = dbk_info;
                    Logger.LogDebug("Drawback details added successfully");
                }
                else
                {
                    Logger.LogWarning("No drawback data found (Table[7] is empty or null)");
                }
                #endregion


                #region Exchange Info Details
                if (dbkInfo != null && dbkInfo.Rows.Count > 0)
                {
                    Logger.LogDebug("Processing Exchange Info Details");
                    DataRow row = dbkInfo.Rows[0];
                    exi.custom_house_code = SafeGetString(rowGeneral, "CUSTOMS_HOUSE");
                    exi.user_job_no = SafeGetString(rowGeneral, "JOBNO");
                    exi.user_job_date = GetApiDate(SafeGetString(rowGeneral, "JOBDATE"));       //job date
                    exi.item_sr_no = SafeGetString(row, "ITEM_SLNO");
                    exi.dbk_schedule_no = SafeGetString(row, "DRAWBACK_SLNO");
                    exi.cha_license_no = HttpContext.Current.Session["CHA_NO"].ToString();
                    exi.invoice_sr_no = SafeGetString(row, "INVOICE_SLNO");
                    exi.sb_no = SafeGetString(exportSBEntry, "sb_no");
                    exi.sb_date = GetApiDate(SafeGetString(exportSBEntry, "sb_date"));  //sb date
                    exi.drawback_quantity = SafeGetString(row, "DRAWBACK_QTY");
                    shippingBill.exchange_info = exi;
                    Logger.LogDebug("Exchange Info Details added successfully");
                }
                else
                {
                    Logger.LogWarning("No Exchange Info Details data found (Table[need to check] is empty or null)");
                }
                #endregion

                #region License Details
                if (licenseInfo != null && licenseInfo.Rows.Count > 0)
                {
                    Logger.LogDebug("Processing License details");
                    DataRow row = licenseInfo.Rows[0];
                    license_info.custom_house_code = SafeGetString(rowGeneral, "CUSTOMS_HOUSE");
                    license_info.cha_license_no = HttpContext.Current.Session["CHA_NO"].ToString();

                    license_info.user_job_no = SafeGetString(rowGeneral, "JOBNO");
                    license_info.user_job_date = GetApiDate(SafeGetString(rowGeneral, "JOBDATE"));      //job date

                    license_info.invoice_sr_no = dbk_info.invoice_sr_no;

                    license_info.item_sr_no = dbk_info.item_sr_no;
                    license_info.registration_no = SafeGetString(row, "LICENSE_NO");
                    license_info.srno = SafeGetString(row, "LICENSE_REG_SLNO");

                    license_info.sb_no = SafeGetString(exportSBEntry, "sb_no");
                    license_info.sb_date = GetApiDate(SafeGetString(exportSBEntry, "sb_date"));     //sb date

                    license_info.registration_date = SafeGetString(row, "LICENSE_DATE");
                    license_info.item_sr_no_in_part_e = SafeGetString(row, "LICENSE_E_SL_NO");
                    license_info.item_sr_no_in_part_c = SafeGetString(row, "LICENSE_IMP_ITEM_SL_NO");
                    license_info.quantity = SafeGetString(row, "LICENSE_IMP_QTY");
                    license_info.export_quantity = SafeGetString(row, "LICENSE_EXP_QTY");
                    license_info.whether_indigenous_or_imported = SafeGetString(row, "LICENSE_IMP_TYPE");

                    shippingBill.licenseInfo = license_info;
                    Logger.LogDebug("License details added successfully");
                }
                else
                {
                    Logger.LogDebug("License details are added Blank ");
                    license_info.custom_house_code = DocumentConstants.Blank;
                    license_info.cha_license_no = HttpContext.Current.Session["CHA_NO"].ToString();
                    license_info.user_job_no = DocumentConstants.Blank;
                    license_info.user_job_date = DocumentConstants.Blank;
                    license_info.invoice_sr_no = DocumentConstants.Blank;
                    license_info.item_sr_no = DocumentConstants.Blank;
                    license_info.registration_no = DocumentConstants.Blank;
                    license_info.srno = DocumentConstants.Blank;
                    license_info.sb_no = DocumentConstants.Blank;
                    license_info.sb_date = DocumentConstants.Blank;
                    license_info.registration_date = DocumentConstants.Blank;
                    license_info.item_sr_no_in_part_e = DocumentConstants.Blank;
                    license_info.item_sr_no_in_part_c = DocumentConstants.Blank;
                    license_info.quantity = DocumentConstants.Blank;
                    license_info.export_quantity = DocumentConstants.Blank;
                    license_info.whether_indigenous_or_imported = DocumentConstants.Blank;

                    shippingBill.licenseInfo = license_info;
                    Logger.LogWarning("No license data found (Table[13] is empty or null) so add blank");
                }
                #endregion

            }
            else
            {
                Logger.LogDebug("The EXPORT_SB_ENTRY rows are null, and no entry was found for this job number. Hence, the dataset mapping could not be performed for Shipping Bill...");
            }
            Logger.LogInfo("=== MapDataSetToShippingBill COMPLETED successfully ===");
            return shippingBill;
        }
        catch (Exception ex)
        {
            Logger.LogError("MapDataSetToShippingBill failed", ex);
            throw new InvalidOperationException("Failed to map DataSet to ShippingBill", ex);
        }
    }

    public DataSet Select_Imp_Exp_Job_Details(Global_variables objUserBL)
    {
        Logger.LogInfo("=== Database Call: Select_Imp_Exp_Job_Details ===");
        Logger.LogInfoFormat("Parameters - JobNo: {0}, Branch: {1}, Flag: {2}, WORKINGPERIOD{3}, Imp_or_Exp {4}", objUserBL.A1, objUserBL.A6, objUserBL.A4, objUserBL.A3, objUserBL.A5);

        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Jobno", objUserBL.A1);
            param[2] = new SqlParameter("@BRANCH_COMMON", objUserBL.A6);
            param[3] = new SqlParameter("@Company_Lic", Connection.COMPANYID());
            param[4] = new SqlParameter("@Flag", objUserBL.A4);
            param[5] = new SqlParameter("@WORKINGPERIOD", objUserBL.A3);
            param[6] = new SqlParameter("@Imp_Exp", objUserBL.A5);

            Logger.LogDebug("Executing stored procedure: IMP_EXP_CHECKLIST_DETAILS_POSTING");
            //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_EXP_CHECKLIST_DETAILS_POSTING", param);
            ds = Connection.Get_Dataset("IMP_EXP_CHECKLIST_DETAILS_POSTING", param);

            int tableCount = (ds != null && ds.Tables != null) ? ds.Tables.Count : 0;
            Logger.LogInfoFormat("Query executed successfully - Returned {0} tables", tableCount);
        }
        catch (SqlException sqlEx)
        {
            Logger.LogErrorFormat("SQL Error in Select_Imp_Exp_Job_Details - ErrorNumber: {0}", sqlEx.Number);
            Logger.LogError("SQL Exception details:", sqlEx);
            Connection.Error_Msg(sqlEx.Message);
        }
        catch (Exception ex)
        {
            Logger.LogError("Database call failed in Select_Imp_Exp_Job_Details", ex);
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public DataSet Select_JOB_EXISTS_WITH_REFERENCE(Global_variables objUserBL)
    {
        Logger.LogInfo("=== STEP 1:Database Call: Select_JOB_EXISTS_WITH_REFERENCE ===");
        Logger.LogInfoFormat("Parameters - JobNo: {0}, Branch: {1}, WORKINGPERIOD{2}, Imp_or_Exp {3}", objUserBL.A1, objUserBL.A6, objUserBL.A3, objUserBL.A5);

        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@Jobno", objUserBL.A1);
            param[1] = new SqlParameter("@BRANCH_COMMON", objUserBL.A6);
            param[2] = new SqlParameter("@WORKINGPERIOD", objUserBL.A3);
            param[3] = new SqlParameter("@Imp_Exp", objUserBL.A5);

            Logger.LogInfo("Executing stored procedure: Check_Job_Exists_With_Reference");
            ds = Connection.Get_Dataset("Check_Job_Exists_With_Reference", param);

            int tableCount = (ds != null && ds.Tables != null) ? ds.Tables.Count : 0;
            Logger.LogInfoFormat("Query executed successfully - Returned {0} tables", tableCount);
        }
        catch (SqlException sqlEx)
        {
            Logger.LogErrorFormat("SQL Error in Check_Job_Exists_With_Reference - ErrorNumber: {0}", sqlEx.Number);
            Logger.LogError("SQL Exception details:", sqlEx);
            Connection.Error_Msg(sqlEx.Message);
        }
        catch (Exception ex)
        {
            Logger.LogError("Database call failed in Select_JOB_EXISTS_WITH_REFERENCE", ex);
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    //Authentication
    public static string GetJwtToken()
    {
        try
        {
            Logger.LogInfo("=== GetJwtToken: Authentication Process Started ===");
            string loginUrl = ConfigurationManager.AppSettings["6Solve.Api.Login"];
            string email = ConfigurationManager.AppSettings["6Solve.Api.User"];
            string password = ConfigurationManager.AppSettings["6Solve.Api.Password"];

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new ConfigurationErrorsException("Login credentials are missing in web.config");
            }
            var loginPayload = new
            {
                email = email,
                password = password
            };

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string jsonRequest = serializer.Serialize(loginPayload);

            Logger.LogDebug("Sending authentication request...");
            var jsonResponse = HttpHelper.PostJson(loginUrl, jsonRequest);

            int statusCode = jsonResponse != null ? jsonResponse.HttpStatusCode : 0;
            Logger.LogDebugFormat("Response received - Status: {0}", statusCode);

            HttpHelper.LoginResponse loginResponse = serializer.Deserialize<HttpHelper.LoginResponse>(jsonResponse.ResponseBody);

            if (loginResponse != null && loginResponse.status == 1)
            {
                jwtToken = loginResponse.token;
                Logger.LogInfo("JWT token obtained successfully");
                return loginResponse.token;
            }
            else
            {
                int status = loginResponse != null ? loginResponse.status : -1;
                string responseBody = jsonResponse != null ? jsonResponse.ResponseBody : "null";
                Logger.LogErrorFormat("Login failed - Status: {0}, Response: {1}", status, responseBody);
                throw new Exception("Login failed: " + jsonResponse);
            }
        }
        catch (Exception ex)
        {
            Logger.LogError("GetJwtToken failed", ex);
            throw;
        }
    }


    // Helper method for safe conversion
    private static string SafeGetString(DataRow row, string columnName)
    {
        if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
        {
            return row[columnName].ToString();
        }
        return string.Empty;
    }

    private static string getInvoiceString(DataRow row, string columnName)
    {
        return row[columnName] != DBNull.Value ? row[columnName].ToString() : "";
    }

    private static string getItemInfoString(DataRow row, string columnName)
    {
        return row[columnName] != DBNull.Value ? row[columnName].ToString() : "";
    }

    private static string GetItemInfoPart(DataRow row, string columnName, int start, int length)
    {
        if (!row.Table.Columns.Contains(columnName)) return string.Empty;
        if (row[columnName] == DBNull.Value) return string.Empty;
        string text = row[columnName].ToString();

        if (string.IsNullOrEmpty(text)) return string.Empty;
        if (text.Length <= start) return string.Empty;

        return text.Length >= start + length ? text.Substring(start, length) : text.Substring(start);
    }

    // Mapping method
    private static string MapTransportMode(string dbValue)
    {
        if (dbValue == null) return null;

        string normalized = dbValue.Trim().ToUpper();

        if (normalized == "AIR") return "A";
        if (normalized == "SEA") return "S";
        if (normalized == "LAND") return "L";

        return dbValue;
    }

    //Required for Date format 
    private static string GetApiDate(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return "";

        DateTime dt = DateTime.Parse(input);
        return dt.ToString("yyyy-MM-dd");
    }

    private static string MapFilingStatus(string dbValue)
    {
        if (dbValue == null) return null;

        string normalized = dbValue.Trim().ToUpper();

        if (normalized == "NORMAL") return "N";
        if (normalized == "ADVANCED") return "A";
        if (normalized == "PRIOR") return "P";

        return dbValue;
    }

    private static string MapBETYPE(string dbValue)
    {
        if (dbValue == null) return null;

        string normalized = dbValue.Trim().ToUpper();

        if (normalized == "HOME") return "H";
        if (normalized == "WAREHOUSE") return "W";
        if (normalized == "EX-BOND") return "X";

        return dbValue;
    }

    private static string MapSealTypeCode(string dbValue)
    {
        if (dbValue == null) return null;

        string normalized = dbValue.Trim().ToUpper();

        if (normalized == "SELF") return "S";
        if (normalized == "WAREHOUSE") return "W";
        if (normalized == "AGENCY") return "A";
        return dbValue;
    }

    private static string MapNatureofCargo(string dbValue)
    {
        if (dbValue == null) return null;

        string normalized = dbValue.Trim().ToUpper();

        if (normalized == "P PACKAGED") return "P";
        if (normalized == "C CONTAINERIZED") return "C";
        if (normalized == "CP CONTAINERIZED") return "CP";
        if (normalized == "LB LIQUID AND BULK") return "LB";
        if (normalized == "DB DRY BULK") return "DB";
        return dbValue;
    }
}



public static class DocumentConstants
{
    public const string DocTypeSB = "SB";
    public const string DocTypeBE = "BE";
    public const string TRANSPORT_MODE_AIR = "AIR";
    public const string TRANSPORT_MODE_SEA = "SEA";
    public const string TRANSPORT_MODE_LAND = "LAND";
    public const string BE_Importer_Class = "N";
    public const string exportThirdParty = "N";
    public const string natureOfContact_BillofEntry = "N/A";
    public const string RecordTypeHREC = "HREC";
    public const string SenderIdTypeZZ = "ZZ";
    public const string ReceiverIdTypeZZ = "ZZ";
    public const string VersionIces1_5 = "ICES1_5";
    public const string MessageIdCache01 = "CACHE01";

    public const string Blank = "";
    public const string Blank1 = "";
}


public static class DateTimeFormats
{
    public const string Date = "yyyyMMdd";
    public const string Time = "HHmm";
    public const string Full = "yyyyMMddHHmm";

    public static string GetCurrentDate()
    {
        return System.DateTime.Now.ToString(Date);
    }

    public static string GetCurrentTime()
    {
        return System.DateTime.Now.ToString(Time);
    }
}

