using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Data.SqlClient;

using System.IO;
using Microsoft.ApplicationBlocks.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
//using Microsoft.Reporting.WinForms;
using System.Web.UI.WebControls.WebParts;
//using ReportViewerLib;
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;



public partial class Transaction_Default2 : System.Web.UI.Page
{
    public string TICK_MARK = ((char)0x221A).ToString();
    private string _IMPORTER_TYPE;
    private string _IMPORTER_TYPE_PRIVATE;
    private string _IMPORTER_TYPE_GOVT;
    private string _HOME_CONSUMPTION;
    private string _WAREHOUSE;
    private string _EXBOND;
    private string _NORMAL;
    private string _PRIOR;
    private string _ADVANCE;
   
    public string IMPORTER_TYPE { get { return _IMPORTER_TYPE; } set { _IMPORTER_TYPE = value; } }
    public string IMPORTER_TYPE_PRIVATE { get { return _IMPORTER_TYPE_PRIVATE; } set { _IMPORTER_TYPE_PRIVATE = value; } }
    public string IMPORTER_TYPE_GOVT { get { return _IMPORTER_TYPE_GOVT; } set { _IMPORTER_TYPE_GOVT = value; } }
   
    public string HOME_CONSUMPTION { get { return _HOME_CONSUMPTION; } set { _HOME_CONSUMPTION = value; } }
    public string WAREHOUSE { get { return _WAREHOUSE; } set { _WAREHOUSE = value; } }
    public string EXBOND { get { return _EXBOND; } set { _EXBOND = value; } }
    public string NORMAL { get { return _NORMAL; } set { _NORMAL = value; } }
    public string PRIOR { get { return _PRIOR; } set { _PRIOR = value; } }
    public string ADVANCE { get { return _ADVANCE; } set { _ADVANCE = value; } }

    //private string _TERMS_FOB;
    //private string _TERMS_CI;
    //private string _TERMS_CF;
    //private string _TERMS_CIF;
    //public string TERMS_FOB { get { return _TERMS_FOB; } set { _TERMS_FOB = value; } }
    //public string TERMS_CI { get { return _TERMS_CI; } set { _TERMS_CI = value; } }
    //public string TERMS_CF { get { return _TERMS_CF; } set { _TERMS_CF = value; } }
    //public string TERMS_CIF { get { return _TERMS_CIF; } set { _TERMS_CIF = value; } }


    private string _OTHER_NATURE_OF_TRANSACTION;
    public string OTHER_NATURE_OF_TRANSACTION { get { return _OTHER_NATURE_OF_TRANSACTION; } set { _OTHER_NATURE_OF_TRANSACTION = value; } }

    private string _TICK_SALE;
    public string TICK_SALE { get { return _TICK_SALE; } set { _TICK_SALE = value; } }

    #region Private_Attributes
    private string _BE_NO;
    private string _JOB_NO;
    private string _Today_dt;
    //private string _IGM_TRANSPORTMODE;
    //General Details
    private string _Importer_Name;

    private string _TRANSPORT_MODE;
   
    private string _CUSTOMS_HOUSE;
    
    private string _SECTION46;
    private string _FIRSTCHECK;
    private string _GREEN_CHANNEL;
    private string _KACHHA_BE;
    private string _SECTION48;
    private string _HIGH_SEA_SALE_NAME;
    private string _HIGH_SEA_IEC;
    private string _HIGH_SEA_BRANCH_SL_NO;
    private string _HSS_ADD1;
    private string _HSS_ADD2;
    private string _HSS_ADD3;
    private string _HSS_ADD4;
    private string _HSS_ADD5;
    private string _SUPPLIER_COUNTRY_NAME;
    private string _SUPPLIER_COUNTRY_PINCODE;
    private string _SVB_ASSESABLE_STATUS;
    private string _SVB_DUTY_STATUS;
    //IGM
   
    // Invoice Details
    //private string _INVOICE_SLNO;
    private string _INVOICE_NO;
   

    //ITEM DETAILS
    //private string _ITEM_SLNO;
    //private string _SCHEME_CODE;

    #endregion
    #region Public_Attributes
  
    //public string SCHEME_NOTN_ = "";
    public string BE_NO { get { return _BE_NO; } set { _BE_NO = value; } }
    public string JOB_NO { get { return _BE_NO; } set { _JOB_NO = value; } }
    public string Today_dt { get { return _BE_NO; } set { _Today_dt = value; } }
    public string Importer_Name { get { return _Importer_Name; } set { _Importer_Name = value; } }
    //public string IGM_TRANSPORTMODE { get { return _IGM_TRANSPORTMODE; } set { _IGM_TRANSPORTMODE = value; } }

    //General Details

    public string SECTION46 { get { return _SECTION46; } set { _SECTION46 = value; } }
    public string FIRSTCHECK { get { return _FIRSTCHECK; } set { _FIRSTCHECK = value; } }
    public string GREEN_CHANNEL { get { return _GREEN_CHANNEL; } set { _GREEN_CHANNEL = value; } }
    public string KACHHA_BE { get { return _KACHHA_BE; } set { _KACHHA_BE = value; } }
    public string SECTION48 { get { return _SECTION48; } set { _SECTION48 = value; } }
   
    //public string TRANSPORT_MODE { get { return _TRANSPORT_MODE; } set { _TRANSPORT_MODE = value; } }
    
    public string CUSTOMS_HOUSE { get { return _CUSTOMS_HOUSE; } set { _CUSTOMS_HOUSE = value; } }
   
    #endregion
    //---------------------ITEM ATTRIBUTES-----------------//
    #region ITEM ATTRIBUTES
    #region Private_Attributes

    private string _WHETHER_REIMPORT,_SVB_REF_DATE;
   
    private string _INVOICE_SLNO;
    private string _INVOICE_DATE;
     private string _SUPPLIER_NAME;
    private string _SUPPLIER_ADDRESS;
    private string _SUPPLIER_ADDRESS1;
    private string _SUPPLIER_ADDRESS2;
    private string _SVB_RELATION;
    private string _SVB_REF_NO,_TERMS;
    private string  _INVOICE_NO_ITEM, _Invoice_No, _Invoice_Details;

    private string _INVOICE_VALUE, _Invoice_value, _INVOICE_EXRATE;
    private string _MIS_FREIGHT_RATE;

    private string _MIS_INSURANCE_RATE;

    private string _IGM_TRANSPORTMODE;
    private string _PORT_ORIGIN;
    private string _Country_Origin;
    private string _Country_Shipment;
    //item Details
    private string _SVB_CUSTOM_HOUSE;
    private string _ITEM_SLNO;
    private string _ITEM_DESCRIPTION;
    private string _ITEM_QTY;
    private string _ITEM_QTY_CODE;
    private string _ITEM_UNIT_PRICE, _ITEM_UNIT_CODE, _CTH_NO, _CTH_QTY;
    private string  _Total_Invoice, _SupplierCountry_Name_Pincode;
    private string _SCHEME_CODE, _SCHEME;
    private string _SCHEME_NOTN;
    private string _SCHEME_NOTN_SLNO;

    private string _PRODUCT_RITC;
    private string _PRODUCT_CTH;

    private string _PRODUCT_CVD_RATE, _PRODUCT_CVD_NOTN, _PRODUCT_CVD_NOTN_SLNO;
    private string _PRODUCT_EDU_CESS_RATE, _UNIT_PRICE, _UNIT_CODE, _CUSTOMS_HOUSE1;
    private string _PRODUCT_SEC_EDU_CESS_RATE, _GENEARL_DESCRIPTION, _MANUFACTURER, _BRAND, _MODEL, _END_USE_OF_ITEM, _COUNTRY_OF_ORIGIN, _ACCESSORIES, _PREVIOUS_BE_NO, _PREVIOUS_BE_DATE;

    private string _PRODUCT_BCD_RATE, _PRODUCT_BCD_NOTN, _PRODUCT_ADDL_DUTY_NOTN, _ADDTIONAL_DUTY_RATE, _PRODUCT_ADDL_DUTY_RATE, _PRODUCT_SEC_EDU_CESS_NOTN, _PRODUCT_EDU_CESS_NOTN, _EXCEMPTION, _INVOICE_CURRENCY, _Invoice_Currency;
    //private string _PRODUCT_EDU_CESS_NOTN;
    private string _PRODUCT_EDU_CESS_NOTN_SL;
    //private string _PRODUCT_EDU_CESS_RATE;
    //private string _PRODUCT_SEC_EDU_CESS_NOTN;
    private string _PRODUCT_SEC_EDU_CESS_NOTN_SL;
    //private string _PRODUCT_SEC_EDU_CESS_RATE;
    private string _PRODUCT_NCD_NOTN;
    private string _PRODUCT_NCD_SLNO;
    private string _PRODUCT_NCD_RATE;
    private string _PRODUCT_NCD_SPL;
    private string _PRODUCT_NCD_UNIT;
    private string _PRODUCT_NCD_SPL_TYPE;
    private string _PRODUCT_AGGREGATE_DUTY_NOTN;
    private string _PRODUCT_AGGREGATE_DUTY_NOTN_SL;
    private string _PRODUCT_AGGREGATE_DUTY_NOTN_RATE;
    private string _PRODUCT_SAFEGUARD_NOTN;
    private string _PRODUCT_SAFEGUARD_SLNO;
    private string _PRODUCT_SAFEGUARD_RATE;
    private string _PRODUCT_SAFEGUARD_SPL;
    private string _PRODUCT_SAFEGUARD_UNIT;
    private string _PRODUCT_SAFEGUARD_SPL_TYPE;

    private string _PRODUCT_SAPTA_NOTN;
    private string _PRODUCT_SAPTA_SLNO;
    private string _PRODUCT_SAPTA_RATE;

    private string _PRODUCT_TARIFF_NOTN;
    private string _PRODUCT_TARIFF_SLNO;
    private string _PRODUCT_TARIFF_QTY;
    private string _PRODUCT_TARIFF_AMOUNT;
    private string _PRODUCT_TARIFF_AMOUNT_UNIT;

    //private string _PRODUCT_CETH;
    private string _PRODUCT_MRP_YN;
    private string _PRODUCT_MRP_SL_NO;
    private string _PRODUCT_MRP_AMOUNT;
    private string _PRODUCT_MRP_ABT_RATE;
    //private string _PRODUCT_CVD_NOTN;
    private string _PRODUCT_CVD_SLNO;
    //private string _PRODUCT_CVD_RATE;
    private string _PRODUCT_CVD_SPL;
    private string _PRODUCT_CVD_UNIT;
    private string _PRODUCT_CVD_SPL_TYPE;
    private string _PRODUCT_CVD_EDU_CESS_RATE;
    private string _PRODUCT_CVD_SEC_EDU_CESS_RATE;
    private string _PRODUCT_ADDL5_SIA_NOTN;
    private string _PRODUCT_ADDL5_SIA_NOTN_SL;
    private string _PRODUCT_ADDL5_SIA_RATE;
    private string _PRODUCT_ADDL_GSI_NOTN;
    private string _PRODUCT_ADDL_GSI_SLNO;
    private string _PRODUCT_ADDL_GSI_RATE;
    private string _PRODUCT_ADDL_GSI_SPL;
    private string _PRODUCT_ADDL_GSI_UNIT;
    private string _PRODUCT_ADDL_GSI_SPL_TYPE;
    private string _PRODUCT_ADDL_SHEII_NOTN;
    private string _PRODUCT_ADDL_SHEII_SLNO;
    private string _PRODUCT_ADDL_SHEII_RATE;
    private string _PRODUCT_ADDL_SHEII_SPL;
    private string _PRODUCT_ADDL_SHEII_UNIT;
    private string _PRODUCT_ADDL_SHEII_TYPE;
    private string _PRODUCT_ADDL_TTA_NOTN;
    private string _PRODUCT_ADDL_TTA_SLNO;
    private string _PRODUCT_ADDL_TTA_RATE;
    private string _PRODUCT_ADDL_TTA_SPL;
    private string _PRODUCT_ADDL_TTA_UNIT;
    private string _PRODUCT_ADDL_TTA_TYPE;
    private string _PRODUCT_ADDL_HEALTH_CESS_NOTN;
    private string _PRODUCT_ADDL_HEALTH_CESS_SLNO;
    private string _PRODUCT_ADDL_HEALTH_CESS_RATE;
    private string _PRODUCT_ADDL_HEALTH_CESS_SPL;
    private string _PRODUCT_ADDL_HEALTH_CESS_UNIT;
    private string _PRODUCT_ADDL_HEALTH_CESS_TYPE;
    private string _PRODUCT_CESS_NOTN;
    private string _PRODUCT_CESS_SLNO;
    private string _PRODUCT_CESS_RATE;
    private string _PRODUCT_CESS_SPL;
    private string _PRODUCT_CESS_UNIT;
    private string _PRODUCT_CESS_TYPE;
    private string _ANTI_DUMPING_NOTN;
    private string _ANTI_DUMPING_NOTN_SLNO, _CTH_SLNO, _CTH_SUPPLIER_SLNO;
    private string _PRODUCT_CETH, _ADDTIONAL_DUTY, _BASIC_DUTY_TOATAL, _CVD_TOTAL, _CEC_TOTAL, _CHEC_TOTAL, _ADDLTIONAL_DUTY_TOTAL, _TOTAL_ITEM_DUTY, _NUMBERTOWORDS;
    private string _PRODUCT_BCD_SLNO, _PRODUCT_ADDL_DUTY_NOTN_SLNO, _PRODUCT_SEC_EDU_CESS_NOTN_SLNO, _PRODUCT_EDU_CESS_NOTN_SLNO;
    private double _ASSESABLE_VALUE, _ASSESSABLE_TOTAL, _ITEM_TOTAL;
    public string PRODUCT_BCD_SLNO { get { return _PRODUCT_BCD_SLNO; } set { _PRODUCT_BCD_SLNO = value; } }
    public string PRODUCT_ADDL_DUTY_NOTN_SLNO { get { return _PRODUCT_ADDL_DUTY_NOTN_SLNO; } set { _PRODUCT_ADDL_DUTY_NOTN_SLNO = value; } }
    public string PRODUCT_SEC_EDU_CESS_NOTN_SLNO { get { return _PRODUCT_SEC_EDU_CESS_NOTN_SLNO; } set { _PRODUCT_SEC_EDU_CESS_NOTN_SLNO = value; } }
    public string PRODUCT_EDU_CESS_NOTN_SLNO { get { return _PRODUCT_EDU_CESS_NOTN_SLNO; } set { _PRODUCT_EDU_CESS_NOTN_SLNO = value; } }
    public string PRODUCT_CVD_SLNO { get { return _PRODUCT_CVD_SLNO; } set { _PRODUCT_CVD_SLNO = value; } }

    public string GENEARL_DESCRIPTION { get { return _GENEARL_DESCRIPTION; } set { _GENEARL_DESCRIPTION = value; } }
    public string MANUFACTURER { get { return _MANUFACTURER; } set { _MANUFACTURER = value; } }
    public string BRAND { get { return _BRAND; } set { _BRAND = value; } }
    public string MODEL { get { return _MODEL; } set { _MODEL = value; } }
    public string END_USE_OF_ITEM { get { return _END_USE_OF_ITEM; } set { _END_USE_OF_ITEM = value; } }
    public string COUNTRY_OF_ORIGIN { get { return _COUNTRY_OF_ORIGIN; } set { _COUNTRY_OF_ORIGIN = value; } }
    public string ACCESSORIES { get { return _ACCESSORIES; } set { _ACCESSORIES = value; } }
    public string PREVIOUS_BE_NO { get { return _PREVIOUS_BE_NO; } set { _PREVIOUS_BE_NO = value; } }
    public string UNIT_PRICE { get { return _UNIT_PRICE; } set { _UNIT_PRICE = value; } }
    public string UNIT_CODE { get { return _UNIT_CODE; } set { _UNIT_CODE = value; } }
    public string CUSTOMS_HOUSE1 { get { return _CUSTOMS_HOUSE1; } set { _CUSTOMS_HOUSE1 = value; } }
    //public string PREVIOUS_BE_DATE { get { return _PREVIOUS_BE_DATE; } set { _PREVIOUS_BE_DATE = value; } }

    //public string PRODUCT_EDU_CESS_NOTN { get { return _PRODUCT_EDU_CESS_NOTN; } set { _PRODUCT_EDU_CESS_NOTN = value; } }
    //public string PRODUCT_EDU_CESS_RATE { get { return _PRODUCT_EDU_CESS_RATE; } set { _PRODUCT_EDU_CESS_RATE = value; } }
    //public string PRODUCT_SEC_EDU_CESS_NOTN { get { return _PRODUCT_SEC_EDU_CESS_NOTN; } set { _PRODUCT_SEC_EDU_CESS_NOTN = value; } }
    
    //public string PRODUCT_SEC_EDU_CESS_RATE { get { return _PRODUCT_SEC_EDU_CESS_RATE; } set { _PRODUCT_SEC_EDU_CESS_RATE = value; } }
    public string PRODUCT_SEC_EDU_CESS_NOTN_SL { get { return _PRODUCT_SEC_EDU_CESS_NOTN_SL; } set { _PRODUCT_SEC_EDU_CESS_NOTN_SL = value; } }
    public string PRODUCT_EDU_CESS_NOTN_SL { get { return _PRODUCT_EDU_CESS_NOTN_SL; } set { _PRODUCT_EDU_CESS_NOTN_SL = value; } }
    public string PRODUCT_NCD_NOTN { get { return _PRODUCT_NCD_NOTN; } set { _PRODUCT_NCD_NOTN = value; } }
    public string PRODUCT_NCD_SLNO { get { return _PRODUCT_NCD_SLNO; } set { _PRODUCT_NCD_SLNO = value; } }
    public string PRODUCT_NCD_RATE { get { return _PRODUCT_NCD_RATE; } set { _PRODUCT_NCD_RATE = value; } }
    public string PRODUCT_NCD_SPL { get { return _PRODUCT_NCD_SPL; } set { _PRODUCT_NCD_SPL = value; } }
    public string PRODUCT_NCD_UNIT { get { return _PRODUCT_NCD_UNIT; } set { _PRODUCT_NCD_UNIT = value; } }
    public string PRODUCT_NCD_SPL_TYPE { get { return _PRODUCT_NCD_SPL_TYPE; } set { _PRODUCT_NCD_SPL_TYPE = value; } }
    public string PRODUCT_AGGREGATE_DUTY_NOTN { get { return _PRODUCT_AGGREGATE_DUTY_NOTN; } set { _PRODUCT_AGGREGATE_DUTY_NOTN = value; } }
    public string PRODUCT_AGGREGATE_DUTY_NOTN_SL { get { return _PRODUCT_AGGREGATE_DUTY_NOTN_SL; } set { _PRODUCT_AGGREGATE_DUTY_NOTN_SL = value; } }
    public string PRODUCT_AGGREGATE_DUTY_NOTN_RATE { get { return _PRODUCT_AGGREGATE_DUTY_NOTN_RATE; } set { _PRODUCT_AGGREGATE_DUTY_NOTN_RATE = value; } }
    public string PRODUCT_SAFEGUARD_NOTN { get { return _PRODUCT_SAFEGUARD_NOTN; } set { _PRODUCT_SAFEGUARD_NOTN = value; } }
    public string PRODUCT_SAFEGUARD_SLNO { get { return _PRODUCT_SAFEGUARD_SLNO; } set { _PRODUCT_SAFEGUARD_SLNO = value; } }
    public string PRODUCT_SAFEGUARD_RATE { get { return _PRODUCT_SAFEGUARD_RATE; } set { _PRODUCT_SAFEGUARD_RATE = value; } }
    public string PRODUCT_SAFEGUARD_SPL { get { return _PRODUCT_SAFEGUARD_SPL; } set { _PRODUCT_SAFEGUARD_SPL = value; } }
    public string PRODUCT_SAFEGUARD_UNIT { get { return _PRODUCT_SAFEGUARD_UNIT; } set { _PRODUCT_SAFEGUARD_UNIT = value; } }
    public string PRODUCT_SAFEGUARD_SPL_TYPE { get { return _PRODUCT_SAFEGUARD_SPL_TYPE; } set { _PRODUCT_SAFEGUARD_SPL_TYPE = value; } }

    public string PRODUCT_SAPTA_NOTN { get { return _PRODUCT_SAPTA_NOTN; } set { _PRODUCT_SAPTA_NOTN = value; } }
    public string PRODUCT_SAPTA_SLNO { get { return _PRODUCT_SAPTA_SLNO; } set { _PRODUCT_SAPTA_SLNO = value; } }
    public string PRODUCT_SAPTA_RATE { get { return _PRODUCT_SAPTA_RATE; } set { _PRODUCT_SAPTA_RATE = value; } }

    public string PRODUCT_TARIFF_NOTN { get { return _PRODUCT_TARIFF_NOTN; } set { _PRODUCT_TARIFF_NOTN = value; } }
    public string PRODUCT_TARIFF_SLNO { get { return _PRODUCT_TARIFF_SLNO; } set { _PRODUCT_TARIFF_SLNO = value; } }
    public string PRODUCT_TARIFF_QTY { get { return _PRODUCT_TARIFF_QTY; } set { _PRODUCT_TARIFF_QTY = value; } }
    public string PRODUCT_TARIFF_AMOUNT { get { return _PRODUCT_TARIFF_AMOUNT; } set { _PRODUCT_TARIFF_AMOUNT = value; } }
    public string PRODUCT_TARIFF_AMOUNT_UNIT { get { return _PRODUCT_TARIFF_AMOUNT_UNIT; } set { _PRODUCT_TARIFF_AMOUNT_UNIT = value; } }

   
    public string PRODUCT_MRP_YN { get { return _PRODUCT_MRP_YN; } set { _PRODUCT_MRP_YN = value; } }
    public string PRODUCT_MRP_SL_NO { get { return _PRODUCT_MRP_SL_NO; } set { _PRODUCT_MRP_SL_NO = value; } }
    public string PRODUCT_MRP_AMOUNT { get { return _PRODUCT_MRP_AMOUNT; } set { _PRODUCT_MRP_AMOUNT = value; } }
    public string PRODUCT_MRP_ABT_RATE { get { return _PRODUCT_MRP_ABT_RATE; } set { _PRODUCT_MRP_ABT_RATE = value; } }
   
    public string PRODUCT_CVD_SPL { get { return _PRODUCT_CVD_SPL; } set { _PRODUCT_CVD_SPL = value; } }
    public string PRODUCT_CVD_UNIT { get { return _PRODUCT_CVD_UNIT; } set { _PRODUCT_CVD_UNIT = value; } }
    public string PRODUCT_CVD_SPL_TYPE { get { return _PRODUCT_CVD_SPL_TYPE; } set { _PRODUCT_CVD_SPL_TYPE = value; } }
    public string PRODUCT_CVD_EDU_CESS_RATE { get { return _PRODUCT_CVD_EDU_CESS_RATE; } set { _PRODUCT_CVD_EDU_CESS_RATE = value; } }
    public string PRODUCT_CVD_SEC_EDU_CESS_RATE { get { return _PRODUCT_CVD_SEC_EDU_CESS_RATE; } set { _PRODUCT_CVD_SEC_EDU_CESS_RATE = value; } }
    public string PRODUCT_ADDL5_SIA_NOTN { get { return _PRODUCT_ADDL5_SIA_NOTN; } set { _PRODUCT_ADDL5_SIA_NOTN = value; } }
    public string PRODUCT_ADDL5_SIA_NOTN_SL { get { return _PRODUCT_ADDL5_SIA_NOTN_SL; } set { _PRODUCT_ADDL5_SIA_NOTN_SL = value; } }
    public string PRODUCT_ADDL5_SIA_RATE { get { return _PRODUCT_ADDL5_SIA_RATE; } set { _PRODUCT_ADDL5_SIA_RATE = value; } }
    public string PRODUCT_ADDL_GSI_NOTN { get { return _PRODUCT_ADDL_GSI_NOTN; } set { _PRODUCT_ADDL_GSI_NOTN = value; } }
    public string PRODUCT_ADDL_GSI_SLNO { get { return _PRODUCT_ADDL_GSI_SLNO; } set { _PRODUCT_ADDL_GSI_SLNO = value; } }
    public string PRODUCT_ADDL_GSI_RATE { get { return _PRODUCT_ADDL_GSI_RATE; } set { _PRODUCT_ADDL_GSI_RATE = value; } }
    public string PRODUCT_ADDL_GSI_SPL { get { return _PRODUCT_ADDL_GSI_SPL; } set { _PRODUCT_ADDL_GSI_SPL = value; } }
    public string PRODUCT_ADDL_GSI_UNIT { get { return _PRODUCT_ADDL_GSI_UNIT; } set { _PRODUCT_ADDL_GSI_UNIT = value; } }
    public string PRODUCT_ADDL_GSI_SPL_TYPE { get { return _PRODUCT_ADDL_GSI_SPL_TYPE; } set { _PRODUCT_ADDL_GSI_SPL_TYPE = value; } }
    public string PRODUCT_ADDL_SHEII_NOTN { get { return _PRODUCT_ADDL_SHEII_NOTN; } set { _PRODUCT_ADDL_SHEII_NOTN = value; } }
    public string PRODUCT_ADDL_SHEII_SLNO { get { return _PRODUCT_ADDL_SHEII_SLNO; } set { _PRODUCT_ADDL_SHEII_SLNO = value; } }
    public string PRODUCT_ADDL_SHEII_RATE { get { return _PRODUCT_ADDL_SHEII_RATE; } set { _PRODUCT_ADDL_SHEII_RATE = value; } }
    public string PRODUCT_ADDL_SHEII_SPL { get { return _PRODUCT_ADDL_SHEII_SPL; } set { _PRODUCT_ADDL_SHEII_SPL = value; } }
    public string PRODUCT_ADDL_SHEII_UNIT { get { return _PRODUCT_ADDL_SHEII_UNIT; } set { _PRODUCT_ADDL_SHEII_UNIT = value; } }
    public string PRODUCT_ADDL_SHEII_TYPE { get { return _PRODUCT_ADDL_SHEII_TYPE; } set { _PRODUCT_ADDL_SHEII_TYPE = value; } }
    public string PRODUCT_ADDL_TTA_NOTN { get { return _PRODUCT_ADDL_TTA_NOTN; } set { _PRODUCT_ADDL_TTA_NOTN = value; } }
    public string PRODUCT_ADDL_TTA_SLNO { get { return _PRODUCT_ADDL_TTA_SLNO; } set { _PRODUCT_ADDL_TTA_SLNO = value; } }
    public string PRODUCT_ADDL_TTA_RATE { get { return _PRODUCT_ADDL_TTA_RATE; } set { _PRODUCT_ADDL_TTA_RATE = value; } }
    public string PRODUCT_ADDL_TTA_SPL { get { return _PRODUCT_ADDL_TTA_SPL; } set { _PRODUCT_ADDL_TTA_SPL = value; } }
    public string PRODUCT_ADDL_TTA_UNIT { get { return _PRODUCT_ADDL_TTA_UNIT; } set { _PRODUCT_ADDL_TTA_UNIT = value; } }
    public string PRODUCT_ADDL_TTA_TYPE { get { return _PRODUCT_ADDL_TTA_TYPE; } set { _PRODUCT_ADDL_TTA_TYPE = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_NOTN { get { return _PRODUCT_ADDL_HEALTH_CESS_NOTN; } set { _PRODUCT_ADDL_HEALTH_CESS_NOTN = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_SLNO { get { return _PRODUCT_ADDL_HEALTH_CESS_SLNO; } set { _PRODUCT_ADDL_HEALTH_CESS_SLNO = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_RATE { get { return _PRODUCT_ADDL_HEALTH_CESS_RATE; } set { _PRODUCT_ADDL_HEALTH_CESS_RATE = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_SPL { get { return _PRODUCT_ADDL_HEALTH_CESS_SPL; } set { _PRODUCT_ADDL_HEALTH_CESS_SPL = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_UNIT { get { return _PRODUCT_ADDL_HEALTH_CESS_UNIT; } set { _PRODUCT_ADDL_HEALTH_CESS_UNIT = value; } }
    public string PRODUCT_ADDL_HEALTH_CESS_TYPE { get { return _PRODUCT_ADDL_HEALTH_CESS_TYPE; } set { _PRODUCT_ADDL_HEALTH_CESS_TYPE = value; } }
    public string PRODUCT_CESS_NOTN { get { return _PRODUCT_CESS_NOTN; } set { _PRODUCT_CESS_NOTN = value; } }
    public string PRODUCT_CESS_SLNO { get { return _PRODUCT_CESS_SLNO; } set { _PRODUCT_CESS_SLNO = value; } }
    public string PRODUCT_CESS_RATE { get { return _PRODUCT_CESS_RATE; } set { _PRODUCT_CESS_RATE = value; } }
    public string PRODUCT_CESS_SPL { get { return _PRODUCT_CESS_SPL; } set { _PRODUCT_CESS_SPL = value; } }
    public string PRODUCT_CESS_UNIT { get { return _PRODUCT_CESS_UNIT; } set { _PRODUCT_CESS_UNIT = value; } }
    public string PREVIOUS_BE_DATE { get { return _PREVIOUS_BE_DATE; } set { _PREVIOUS_BE_DATE = value; } }
    public string ANTI_DUMPING_NOTN { get { return _ANTI_DUMPING_NOTN; } set { _ANTI_DUMPING_NOTN = value; } }
    public string ANTI_DUMPING_NOTN_SLNO { get { return _ANTI_DUMPING_NOTN_SLNO; } set { _ANTI_DUMPING_NOTN_SLNO = value; } }
    public string CTH_SLNO { get { return _CTH_SLNO; } set { _CTH_SLNO = value; } }
    public string CTH_SUPPLIER_SLNO { get { return _CTH_SUPPLIER_SLNO; } set { _CTH_SUPPLIER_SLNO = value; } }

    #endregion


    //SINGLE WINDOW ITEM DETAILS
    #region SINGLE WINDOW ITEM DETAILS
    private string _CENTRAL_EXCISE_FLAG
        , _MANUFACTURER_PRODUCER
        , _M_P_GROWER_CODE
        , _M_P_GROWER_ADD1
        , _M_P_GROWER_ADD2
        , _M_P_GROWER_CITY
        , _M_P_GROWER_COUNTRY_SUBDIV
        , _M_P_GROWER_PIN
        , _M_P_GROWER_COUNTRY
        , _SOURCE_COUNTRY
        , _TRANSIT_COUNTRY
        , _ACCESSORY_STATUS;

    public string CENTRAL_EXCISE_FLAG { get { return _CENTRAL_EXCISE_FLAG; } set { _CENTRAL_EXCISE_FLAG = value; } }
    public string MANUFACTURER_PRODUCER { get { return _MANUFACTURER_PRODUCER; } set { _MANUFACTURER_PRODUCER = value; } }
    public string M_P_GROWER_CODE { get { return _M_P_GROWER_CODE; } set { _M_P_GROWER_CODE = value; } }
    public string M_P_GROWER_ADD1 { get { return _M_P_GROWER_ADD1; } set { _M_P_GROWER_ADD1 = value; } }
    public string M_P_GROWER_ADD2 { get { return _M_P_GROWER_ADD2; } set { _M_P_GROWER_ADD2 = value; } }
    public string M_P_GROWER_CITY { get { return _M_P_GROWER_CITY; } set { _M_P_GROWER_CITY = value; } }
    public string M_P_GROWER_COUNTRY_SUBDIV { get { return _M_P_GROWER_COUNTRY_SUBDIV; } set { _M_P_GROWER_COUNTRY_SUBDIV = value; } }
    public string M_P_GROWER_PIN { get { return _M_P_GROWER_PIN; } set { _M_P_GROWER_PIN = value; } }
    public string M_P_GROWER_COUNTRY { get { return _M_P_GROWER_COUNTRY; } set { _M_P_GROWER_COUNTRY = value; } }
    public string SOURCE_COUNTRY { get { return _SOURCE_COUNTRY; } set { _SOURCE_COUNTRY = value; } }
    public string TRANSIT_COUNTRY { get { return _TRANSIT_COUNTRY; } set { _TRANSIT_COUNTRY = value; } }
    public string ACCESSORY_STATUS { get { return _ACCESSORY_STATUS; } set { _ACCESSORY_STATUS = value; } }

    private string _CONSTITUENT_SRNO;
    private string _CONSTITUENT_ELEMENT_NAME;
    private string _CONSTITUENT_ELEMENT_CODE;
    private string _CONSTITUENT_PERCENTAGE;
    private string _CONSTITUENT_YIELD_PERCENTAGE;
    private string _ACTIVE_INGREDIENT;

    public string CONSTITUENT_SRNO { get { return _CONSTITUENT_SRNO; } set { _CONSTITUENT_SRNO = value; } }
    public string CONSTITUENT_ELEMENT_NAME { get { return _CONSTITUENT_ELEMENT_NAME; } set { _CONSTITUENT_ELEMENT_NAME = value; } }

    public string CONSTITUENT_ELEMENT_CODE { get { return _CONSTITUENT_ELEMENT_CODE; } set { _CONSTITUENT_ELEMENT_CODE = value; } }
    public string CONSTITUENT_PERCENTAGE { get { return _CONSTITUENT_PERCENTAGE; } set { _CONSTITUENT_PERCENTAGE = value; } }
    public string CONSTITUENT_YIELD_PERCENTAGE { get { return _CONSTITUENT_YIELD_PERCENTAGE; } set { _CONSTITUENT_YIELD_PERCENTAGE = value; } }

    #endregion

    #region Public_Attributes

    public string SVB_REF_DATE { get { return _SVB_REF_DATE; } set { _SVB_REF_DATE = value; } }
    public string WHETHER_REIMPORT { get { return _WHETHER_REIMPORT; } set { _WHETHER_REIMPORT = value; } }

    public string TRANSPORT_MODE;

    public string MIS_FREIGHT_CHARGES;

    public string MIS_FREIGHT_CURRENCY;
    public string MIS_FREIGHT_EXRATE;
    public string MIS_INSURANCE_CHARGES;

    public string MIS_INSURANCE_CURRENCY;
    public string MIS_INSURANCE_EXRATE;

    public string SVB_ASSESABLE_RATE;
    public string SVB_DUTY_RATE;

    public string MIS_CHARGES;
    public string MIS_RATE;
    public string MIS_EXRATE;
    public string MIS_HIGHSEASALE_RATE;
    public string MIS_HIGHSEASALE_CHARGES;
    public string MIS_DISCOUNT_RATE;
    public string MIS_DISCOUNT_CHARGES;

    public string MIS_CURRENCY;
    public string MIS_LOADING_CHARGES;
    public string MIS_LOADING_CURRENCY;
    public string MIS_LOADING_EXRATE;
    public string MIS_DISCOUNT_CURRENCY;
    public string MIS_DISCOUNT_EXRATE;

    public string MIS_HIGHSEASALE_CURRENCY;

    public string REIMPORT_FREIGHT;
    public string REIMPORT_INSURANCE;

    public string MIS_HIGHSEASALE_EXRATE;
    public double INVOICE_VALUE_INR;
    public double TOTAL_INVOICE_VALUE;

    public double REIMPORT_FREIGHT_AMOUNT;
    public double REIMPORT_INSURANCE_AMOUNT;
    public double MISC_AMOUNT;
    public double DISCOUNT_AMOUNT = 0;
    public double INVOICE_AMOUNT = 0;
    public double INSURANCE_AMOUNT = 0;
    public double FREIGHT_AMOUNT = 0;
    public double INDIVITUAL_INVOICE_VALUE = 0;
    public double INDIVITUAL_FREIGHT_AMOUNT = 0;
    public double INDIVITUAL_INSURANCE_AMOUNT = 0;
    public double INDIVITUAL_MISC_AMOUNT = 0;
    public double INDIVITUAL_TOTAL_AMOUNT = 0;
    public double INDIVITUAL_HSS_AMOUNT = 0;
    public double INDIVITUAL_SVB_AMOUNT = 0;
    public double INDIVITUAL_CIF_AMOUNT = 0;
    public double INDIVITUAL_LANDING_COST = 0;
    public double INDIVITUAL_ASSESSABLE_AMOUNT = 0;
    public double CHECK_FREIGHT_RATE = 0;
    public double CHECK_FREIGHT_EXRATE = 0;

    public double LICENSE_DEBIT_AMT = 0;


    public double INDIVITUAL_DISCOUNT_AMOUNT = 0;

    public double BASIC_DUTY, CVD, Customs_Edu_Cess, Customs_Higher_Edu_Cess, AddL_DUTY, TOTAL_DUTY = 0.0;
    public string SCHEME_NOTN_ = "";
    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
    public string INVOICE_NO_ITEM { get { return _INVOICE_NO_ITEM; } set { _INVOICE_NO_ITEM = value; } }
    public string Invoice_No { get { return _Invoice_No; } set { _Invoice_No = value; } }
    public string Invoice_Details { get { return _Invoice_Details; } set { _Invoice_Details = value; } }

    public string EXCEMPTION { get { return _EXCEMPTION; } set { _EXCEMPTION = value; } }


    public string INVOICE_VALUE { get { return _INVOICE_VALUE; } set { _INVOICE_VALUE = value; } }
    public string Invoice_value { get { return _Invoice_value; } set { _Invoice_value = value; } }

    public string INVOICE_CURRENCY { get { return _INVOICE_CURRENCY; } set { _INVOICE_CURRENCY = value; } }
    public string INVOICE_EXRATE { get { return _INVOICE_EXRATE; } set { _INVOICE_EXRATE = value; } }
    public string Invoice_Currency { get { return _Invoice_Currency; } set { _Invoice_Currency = value; } }

    public string MIS_FREIGHT_RATE { get { return _MIS_FREIGHT_RATE; } set { _MIS_FREIGHT_RATE = value; } }
    public string MIS_INSURANCE_RATE { get { return _MIS_INSURANCE_RATE; } set { _MIS_INSURANCE_RATE = value; } }
   // public string IGM_TRANSPORTMODE { get { return _IGM_TRANSPORTMODE; } set { _IGM_TRANSPORTMODE = value; } }
    public string PORT_ORIGIN { get { return _PORT_ORIGIN; } set { _PORT_ORIGIN = value; } }
    public string Country_Origin { get { return _Country_Origin; } set { _Country_Origin = value; } }
    public string Country_Shipment { get { return _Country_Shipment; } set { _Country_Shipment = value; } }
    //ITEM DETAILS

    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string ITEM_DESCRIPTION { get { return _ITEM_DESCRIPTION; } set { _ITEM_DESCRIPTION = value; } }
    public string ITEM_QTY { get { return _ITEM_QTY; } set { _ITEM_QTY = value; } }
    public string ITEM_QTY_CODE { get { return _ITEM_QTY_CODE; } set { _ITEM_QTY_CODE = value; } }
    public string ITEM_UNIT_PRICE { get { return _ITEM_UNIT_PRICE; } set { _ITEM_UNIT_PRICE = value; } }
    public string ITEM_UNIT_CODE { get { return _ITEM_UNIT_CODE; } set { _ITEM_UNIT_CODE = value; } }
    public string CTH_NO { get { return _CTH_NO; } set { _CTH_NO = value; } }
    public string CTH_QTY { get { return _CTH_QTY; } set { _CTH_QTY = value; } }
    public string SCHEME { get { return _SCHEME; } set { _SCHEME = value; } }

    public string SCHEME_CODE { get { return _SCHEME_CODE; } set { _SCHEME_CODE = value; } }
    public string SCHEME_NOTN { get { return _SCHEME_NOTN; } set { _SCHEME_NOTN = value; } }
    public string SCHEME_NOTN_SLNO { get { return _SCHEME_NOTN_SLNO; } set { _SCHEME_NOTN_SLNO = value; } }

    public string PRODUCT_RITC { get { return _PRODUCT_RITC; } set { _PRODUCT_RITC = value; } }
    public string PRODUCT_CTH { get { return _PRODUCT_CTH; } set { _PRODUCT_CTH = value; } }

    public string PRODUCT_CVD_RATE { get { return _PRODUCT_CVD_RATE; } set { _PRODUCT_CVD_RATE = value; } }
    public string PRODUCT_EDU_CESS_RATE { get { return _PRODUCT_EDU_CESS_RATE; } set { _PRODUCT_EDU_CESS_RATE = value; } }
    public string PRODUCT_EDU_CESS_NOTN { get { return _PRODUCT_EDU_CESS_NOTN; } set { _PRODUCT_EDU_CESS_NOTN = value; } }
    public string PRODUCT_SEC_EDU_CESS_NOTN { get { return _PRODUCT_SEC_EDU_CESS_NOTN; } set { _PRODUCT_SEC_EDU_CESS_NOTN = value; } }

    public string PRODUCT_SEC_EDU_CESS_RATE { get { return _PRODUCT_SEC_EDU_CESS_RATE; } set { _PRODUCT_SEC_EDU_CESS_RATE = value; } }

    public string PRODUCT_BCD_NOTN { get { return _PRODUCT_BCD_NOTN; } set { _PRODUCT_BCD_NOTN = value; } }
    public string PRODUCT_BCD_RATE { get { return _PRODUCT_BCD_RATE; } set { _PRODUCT_BCD_RATE = value; } }
    public string PRODUCT_CVD_NOTN { get { return _PRODUCT_CVD_NOTN; } set { _PRODUCT_CVD_NOTN = value; } }
    public string PRODUCT_ADDL_DUTY_NOTN { get { return _PRODUCT_ADDL_DUTY_NOTN; } set { _PRODUCT_ADDL_DUTY_NOTN = value; } }
    public string PRODUCT_ADDL_DUTY_RATE { get { return _PRODUCT_ADDL_DUTY_RATE; } set { _PRODUCT_ADDL_DUTY_RATE = value; } }

    public string PRODUCT_CETH { get { return _PRODUCT_CETH; } set { _PRODUCT_CETH = value; } }

    public double ASSESABLE_VALUE { get { return _ASSESABLE_VALUE; } set { _ASSESABLE_VALUE = value; } }
    public string ADDTIONAL_DUTY { get { return _ADDTIONAL_DUTY; } set { _ADDTIONAL_DUTY = value; } }
    public string ADDTIONAL_DUTY_RATE { get { return _ADDTIONAL_DUTY_RATE; } set { _ADDTIONAL_DUTY_RATE = value; } }

    public string BASIC_DUTY_TOTAL { get { return _BASIC_DUTY_TOATAL; } set { _BASIC_DUTY_TOATAL = value; } }
    public string CVD_TOTAL { get { return _CVD_TOTAL; } set { _CVD_TOTAL = value; } }
    public string CEC_TOTAL { get { return _CEC_TOTAL; } set { _CEC_TOTAL = value; } }
    public string CHEC_TOTAL { get { return _CHEC_TOTAL; } set { _CHEC_TOTAL = value; } }
    public string ADDLTIONAL_DUTY_TOTAL { get { return _ADDLTIONAL_DUTY_TOTAL; } set { _ADDLTIONAL_DUTY_TOTAL = value; } }
    public string TOTAL_ITEM_DUTY { get { return _TOTAL_ITEM_DUTY; } set { _TOTAL_ITEM_DUTY = value; } }
    public string NUMBERTOWORDS { get { return _NUMBERTOWORDS; } set { _NUMBERTOWORDS = value; } }
    public double ASSESSABLE_TOTAL { get { return _ASSESSABLE_TOTAL; } set { _ASSESSABLE_TOTAL = value; } }
    public double ITEM_TOTAL { get { return _ITEM_TOTAL; } set { _ITEM_TOTAL = value; } }
    public string INVOICE_DATE { get { return _INVOICE_DATE; } set { _INVOICE_DATE = value; } }
    public string SUPPLIER_COUNTRY_NAME { get { return _SUPPLIER_COUNTRY_NAME; } set { _SUPPLIER_COUNTRY_NAME = value; } }
    public string SUPPLIER_COUNTRY_PINCODE { get { return _SUPPLIER_COUNTRY_PINCODE; } set { _SUPPLIER_COUNTRY_PINCODE = value; } }
    public string SVB_ASSESABLE_STATUS { get { return _SVB_ASSESABLE_STATUS; } set { _SVB_ASSESABLE_STATUS = value; } }
    public string SVB_DUTY_STATUS { get { return _SVB_DUTY_STATUS; } set { _SVB_DUTY_STATUS = value; } }
    
    public string Total_Invoice { get { return _Total_Invoice; } set { _Total_Invoice = value; } }
    public string SupplierCountry_Name_Pincode { get { return _SupplierCountry_Name_Pincode; } set { _SupplierCountry_Name_Pincode = value; } }
    public string SVB_CUSTOM_HOUSE { get { return _SVB_CUSTOM_HOUSE; } set { _SVB_CUSTOM_HOUSE = value; } }
     public string SUPPLIER_NAME { get { return _SUPPLIER_NAME; } set { _SUPPLIER_NAME = value; } }
    public string SUPPLIER_ADDRESS { get { return _SUPPLIER_ADDRESS; } set { _SUPPLIER_ADDRESS = value; } }
    public string SUPPLIER_ADDRESS1 { get { return _SUPPLIER_ADDRESS1; } set { _SUPPLIER_ADDRESS1 = value; } }
    public string SUPPLIER_ADDRESS2 { get { return _SUPPLIER_ADDRESS2; } set { _SUPPLIER_ADDRESS2 = value; } }
    public string TERMS { get { return _TERMS; } set { _TERMS = value; } }
    public string SVB_RELATION { get { return _SVB_RELATION; } set { _SVB_RELATION = value; } }
    public string SVB_REF_NO { get { return _SVB_REF_NO; } set { _SVB_REF_NO = value; } }
    #endregion

    private string _INFO_TYPE;
    private string _INFO_QUALIFIER;
    private string _INFO_CODE;
    private string _INFO_TEXT;
    private string _INFO_MSR;
    private string _INFO_UQC;

   
    public string INFO_TYPE { get { return _INFO_TYPE; } set { _INFO_TYPE = value; } }
    public string INFO_QUALIFIER { get { return _INFO_QUALIFIER; } set { _INFO_QUALIFIER = value; } }
    public string INFO_CODE { get { return _INFO_CODE; } set { _INFO_CODE = value; } }
    public string INFO_TEXT { get { return _INFO_TEXT; } set { _INFO_TEXT = value; } }
    public string INFO_MSR { get { return _INFO_MSR; } set { _INFO_MSR = value; } }
    public string INFO_UQC { get { return _INFO_UQC; } set { _INFO_UQC = value; } }

#endregion

#region LICENSE
     //LICENCE_DETAILS
    private int _LICENSE_SLNO;
    private string _REGISTRATION_NO, _REGISTRATION_DATE,  _DEBIT_AMT, _DEBIT_QTY, _UNIT_QTY, _LICENSE_ITEM_NO, _PORT_OF_LICENSE;
    private string _TOTAL_DEBIT_DUTY;
    private string _DEBIT_DUTY;
    private string _LICENSE_NO;
    private string _LICENSE_DATE;
    private string _TOTAL_DEBIT_DUTY_FINAL;
    public int licen_slno;

     //LICENCE_DETAILS
    public int LICENSE_SLNO { get { return _LICENSE_SLNO; } set { _LICENSE_SLNO = value; } }
    public string REGISTRATION_NO { get { return _REGISTRATION_NO; } set { _REGISTRATION_NO = value; } }
    public string REGISTRATION_DATE { get { return _REGISTRATION_DATE; } set { _REGISTRATION_DATE = value; } }
    //public string EXCEMPTION { get { return _EXCEMPTION; } set { _EXCEMPTION = value; } }
    public string DEBIT_AMT { get { return _DEBIT_AMT; } set { _DEBIT_AMT = value; } }
    public string DEBIT_QTY { get { return _DEBIT_QTY; } set { _DEBIT_QTY = value; } }
    public string UNIT_QTY { get { return _UNIT_QTY; } set { _UNIT_QTY = value; } }
    public string LICENSE_ITEM_NO { get { return _LICENSE_ITEM_NO; } set { _LICENSE_ITEM_NO = value; } }
    public string PORT_OF_LICENSE { get { return _PORT_OF_LICENSE; } set { _PORT_OF_LICENSE = value; } }

    public string TOTAL_DEBIT_DUTY { get { return _TOTAL_DEBIT_DUTY; } set { _TOTAL_DEBIT_DUTY = value; } }

    public string DEBIT_DUTY { get { return _DEBIT_DUTY; } set { _DEBIT_DUTY = value; } }

    public string LICENSE_NO { get { return _LICENSE_NO; } set { _LICENSE_NO = value; } }
    public string LICENSE_DATE { get { return _LICENSE_DATE; } set { _LICENSE_DATE = value; } }

    public string TOTAL_DEBIT_DUTY_FINAL { get { return _TOTAL_DEBIT_DUTY_FINAL; } set { _TOTAL_DEBIT_DUTY_FINAL = value; } }


#endregion

    public string working_period;

    AppSession aps = new AppSession();
    Transaction Transact = new Transaction();
    Single_Window_details SW_Details = new Single_Window_details();

    private string _Workingperiod, _INVOICE_ID;
    public string INVOICE_ID { get { return _INVOICE_ID; } set { _INVOICE_ID = value; } }
    public string MIS_CHARGES_Add;
    public string INVOICE_EXCHANGERATE;
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    CheckBoxList chklist_Invoice_No = new CheckBoxList();
    CheckBoxList chklist_Invoice_SlNo = new CheckBoxList();

    public string Workingperiod
    {
        get { return _Workingperiod; }
        set { _Workingperiod = value; }
    }


    public string currentuser, ddlJobNo;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    CheckList CHKLIST = new CheckList();
    //Customer c = new Customer();
    Date_Time dt = new Date_Time();
    private string _MIS_CHARGES_;
    public string MIS_CHARGES_ { get { return _MIS_CHARGES_; } set { _MIS_CHARGES_ = value; } }
    DataSet ds_License = new DataSet();
    DataTable dtt = new DataTable();
    public double Ass_Value_ttl;
    GridView gv = new GridView();
    //List<Transaction_Default2> Load_Invoice_Details = new List<Transaction_Default2>();

    string itemslno, ritcNo, qty_sqm, Qty_Kgs, Qty_code, qty_;

    List<INVOICE_DETAILS> Load_Invoice_Details = new List<INVOICE_DETAILS>();
    List<Transaction_Default2> Load_Item_Details = new List<Transaction_Default2>();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();
        currentbranch = Session["currentbranch"].ToString();
        Session["Check_Stmt"] = "True";

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

        if (!IsPostBack)
        {
            if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
            {

            }
            else
            {
                if (Request.QueryString["Anx"] == "y")
                {

                }
                else
                {
                    Direct_Anx();
                    Page_loaItem_Details();
                }
            }
           
        }
    }
    private void Direct_Anx()
    {
        string Working_Period = "",

               select_branch = "",
                select_type_ = "";
        try
        {
            Working_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();
            select_branch = HttpContext.Current.Session["currentbranch"].ToString();
            select_type_ = HttpContext.Current.Session["SELECT_TYPE"].ToString();

            //if (select_type_ == "Branchwise Job")
            //{
            //    select_branch = select_branch;
            //}
            //else
            //{
            //    select_branch = "";
            //}

            select_branch = Connection.Current_Branch();
            CheckList chklist = new CheckList();
            chklist.JOBNo = Request.QueryString["jobno"].ToString();
            chklist.Ename = "select_jobno_CheckList";

            chklist.Workingperiod = select_branch;
            DataSet ds = new DataSet();
            ds = chklist.RetrieveAll_General_Details();
            if (ds.Tables[0].Rows.Count > 0)
            {
                General_Details Import_General = new General_Details();
                Import_General.Retrieve_GetImport_Annexure(Request.QueryString["jobno"].ToString());
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
    }
   
    public void Page_loaItem_Details()
    {
        try
        {
            if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
            {
            }
            else
            {
                Session["JobNo"] = Request.QueryString["jobno"].ToString();

                ddlJobNo = Request.QueryString["jobno"].ToString();
                currentuser = Session["currentuser"].ToString();
                //currentbranch = Session["currentbranch"].ToString();
                currentcomp_name = Session["currentcomp_name"].ToString();
                comp_ConnectionStr = HttpContext.Current.Session["currentcomp_db"].ToString();
                working_period = HttpContext.Current.Session["WorkingPeriod"].ToString();
                LoginDate = HttpContext.Current.Session["LoginDate"].ToString();
               
                List<ReportParameter> paramList = new List<ReportParameter>(); 
                this.ReportViewer1.LocalReport.SetParameters(paramList);

                ReportViewer1.LocalReport.DataSources.Clear();
                //ReportViewer1.LocalReport.Refresh();

                List<ReportParameter> paramList1 = new List<ReportParameter>(); this.ReportViewer1.LocalReport.SetParameters(paramList);

                ds = (DataSet)HttpContext.Current.Session["IMPORT_CHECKLIST"];
                GetGeneral();          
                Invoice_Detail();
                Item_Details();
                //Item_Details_TEST();
                Item_Details_SubReport();
               
                //TotalItem__DETAILS();
                //RSP_Details();
                //HSS_Details();
                //RE_IMPORT_DETAILS();
                REIMPORT_DETAILS_SubReport();
             
                //LICENSE_DETAILS();
                LICENSE_DETAILS_SubReport();
                //Commercial_Tax_Details();
                //Exbond_Details();

                SW_INFO_TYPE_DETAILS();
                SW_CONSTITUTE_DETAILS();
                SW_PRODUCTION_DETAILS();
                SW_CONTROL_DETAILS();
                SW_STATEMENT_DETAILS();
                Commercial_Tax_Details();
                //SW_SUP_DOC_DETAILS();
               
               
                string SchemeCode = ds.Tables[6].Rows[0]["SCHEME_CODE"].ToString();

                if (SchemeCode != "00 - DUTIABLE")
                {
                    
                }
                /* ***************** */

               
                qty_ = ds.Tables[6].Rows[0]["CTH_QTY1"].ToString();

                if (qty_ != "")
                {
                    itemslno = ds.Tables[6].Rows[0]["ITEM_SLNO"].ToString();
                    ritcNo = ds.Tables[6].Rows[0]["CTH_NO"].ToString();
                    Qty_code = ds.Tables[6].Rows[0]["CTH_QTY1_CODE"].ToString();

                    if (Qty_code == "SQM")
                    {
                        qty_sqm =qty_+" "+ Qty_code;
                    }
                    else
                    {
                        Qty_Kgs =qty_+" "+ Qty_code;
                       
                    }
                }
                else
                {
                    itemslno = "";
                    ritcNo = "";
                    Qty_code = "";
                    qty_sqm = "";
                    Qty_Kgs = "";
                }

                /* ***************** */                       

                ReportParameter param = new ReportParameter("Title", Session["currentcomp_name"].ToString());
                //ReportParameter param1 = new ReportParameter("SubTitle", "CHECK LIST - BILL OF ENTRY FOR HOME CONSUMPTION    " + KACHHA_BE);
                string BETYPE="";
                if (Session["CHECKLIST_BE_TYPE"].ToString().ToUpper() == "HOME")
                    BETYPE = Session["CHECKLIST_BE_TYPE"].ToString().ToUpper() + " CONSUMPTION";
                else
                    BETYPE = Session["CHECKLIST_BE_TYPE"].ToString().ToUpper();

                ReportParameter param1 = new ReportParameter("SubTitle", "CHECK LIST - BILL OF ENTRY FOR "+BETYPE + KACHHA_BE);
                //ReportParameter param2= new ReportParameter("CustomHouse", currentbranch + "," + CUSTOMS_HOUSE + "]");
                ReportParameter param3 = new ReportParameter("PrintDate", dt.Today_Date());
                ReportParameter param4 = new ReportParameter("TodayDate", dt.Today_Date());
                ReportParameter param5 = new ReportParameter("Jobno", ddlJobNo);
                ReportParameter param6 = new ReportParameter("CHA_NO", HttpContext.Current.Session["CHA_NO"].ToString());
                ReportParameter param7 = new ReportParameter("CHA_NAME", HttpContext.Current.Session["CHA_NAME"].ToString());
                ReportParameter param8 = new ReportParameter("CHA_ADDRESS", HttpContext.Current.Session["CHA_ADDRESS"].ToString());
                ReportParameter param9 = new ReportParameter("CHA_ADDRESS1", HttpContext.Current.Session["CHA_ADDRESS1"].ToString());
                ReportParameter param10 = new ReportParameter("CHA_ADDRESS2", HttpContext.Current.Session["CHA_ADDRESS2"].ToString());
                ReportParameter param11 = new ReportParameter("CHA_ADDRESS3", HttpContext.Current.Session["CHA_ADDRESS3"].ToString());

                ReportParameter itemslno1 = new ReportParameter("itemslno", itemslno);
                ReportParameter ritcNo1 = new ReportParameter("ritcNo", ritcNo);
                ReportParameter qty_1 = new ReportParameter("qty", qty_);
                ReportParameter qty_sqm1 = new ReportParameter("qty_sqm", qty_sqm);
                ReportParameter Qty_Kgs1 = new ReportParameter("Qty_Kgs", Qty_Kgs);

                ReportParameter[] p = { param, param1, param3, param4, param5, param6, param7, param8, param9, param10, param11, itemslno1, ritcNo1, qty_1, qty_sqm1, Qty_Kgs1 };        
                ReportViewer1.LocalReport.SetParameters(p);
                            
                //--------------------------------------To Print------------------------------------------------------------------------------------//
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                string fileName = "a";
                byte[] bytes = ReportViewer1.LocalReport.Render("pdf", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                Session.Remove("report");
                Session["report"] = bytes;
                //--------------------------------------To Print------------------------------------------------------------------------------------//

                //Response.AddHeader("content-disposition", "attachment; filename=Test." + "pdf");

                //Response.BinaryWrite((byte[])Session["report"]);
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
    }

    public void GetGeneral()
    {

        General_Details Import_General = new General_Details();
        ReportDataSource dataSource1 = new ReportDataSource("GENERAL_DETAILS", Import_General.Import_Annexure_GetGeneral(ds, ddlJobNo));
        ReportViewer1.LocalReport.DataSources.Add(dataSource1);
       
        if (ds.Tables[0].Rows.Count > 0)
        {
            KACHHA_BE = ds.Tables[0].Rows[0]["KACHHA_BE"].ToString();

            if (!String.IsNullOrEmpty(KACHHA_BE) && KACHHA_BE == "Y")
            {
                KACHHA_BE = "(KACHHA BE)";
            }
            else
                KACHHA_BE = "";          
        }
    }

   
    public void Invoice_Detail()
    {
        Load_Invoice_Details.Clear();
        //INVOICE_DETAILS INV = new INVOICE_DETAILS();
        //ReportDataSource dataSource = new ReportDataSource("INVOICE_DETAILS", INV.Get_Invoice_Details(ddlJobNo, ds.Tables[0], ds.Tables[5]));
        Get_ITEM_Details_new(ddlJobNo, ds.Tables[5], ds.Tables[6], ds.Tables[8], ds.Tables[7], ds, ds.Tables[9]);
        //Get_ITEM_Details_new(ddlJobNo, ds.Tables[5], ds.Tables[6], ds.Tables[8], ds.Tables[7], ds);

        ReportDataSource dataSource = new ReportDataSource("INVOICE_DETAILS", Load_Invoice_Details);
        ReportViewer1.LocalReport.DataSources.Add(dataSource);
      
    }

    public void Item_Details()
    {
        ReportDataSource dataSource = new ReportDataSource("ITEM", Load_Item_Details);
        ReportViewer1.LocalReport.DataSources.Add(dataSource);
        //ReportViewer1.LocalReport.SubreportProcessing += new Microsoft.Reporting.WebForms.SubreportProcessingEventHandler(ReportViewer1_SubreportProcessing);

    }
    public void SW_INFO_TYPE_DETAILS()
    {
        
        ReportDataSource dataSource1 = new ReportDataSource("SW_INFO_TYPE", SW_Details.Get_Single_Window_details_INFOTYPE(ds.Tables[10]));
        ReportViewer1.LocalReport.DataSources.Add(dataSource1);

        //Single_Window_details SW=new Single_Window_details();
        //ReportDataSource ds_SW_INFO = new ReportDataSource("SW_INFO_TYPE_DS", ds.Tables[10]);
        //ReportViewer1.LocalReport.DataSources.Add(ds_SW_INFO);
        //ReportViewer1.LocalReport.SubreportProcessing += new Microsoft.Reporting.WebForms.SubreportProcessingEventHandler(ReportViewer1_SubreportProcessing);
    }
    public void SW_CONSTITUTE_DETAILS()
    {           
        Single_Window_details SW_Details = new Single_Window_details();
        ReportDataSource dataSource1 = new ReportDataSource("SW_CONSTITUENT", SW_Details.Get_Single_Window_details_Constituent(ds.Tables[11]));
        ReportViewer1.LocalReport.DataSources.Add(dataSource1);
    }

    public void SW_PRODUCTION_DETAILS()
    {
        Single_Window_details SW = new Single_Window_details();
        ReportDataSource dataSource = new ReportDataSource("SW_PRODUCTION", SW.Get_Single_Window_details_PRODUCTION(ds.Tables[12]));
        ReportViewer1.LocalReport.DataSources.Add(dataSource);
        //ReportViewer1.LocalReport.SubreportProcessing += new Microsoft.Reporting.WebForms.SubreportProcessingEventHandler(ReportViewer1_SubreportProcessing);
    }

    public void SW_CONTROL_DETAILS()
    {
        Single_Window_details SW = new Single_Window_details();
        ReportDataSource dataSource = new ReportDataSource("SW_CONTROL", SW.Get_Single_Window_details_CONTROL(ds.Tables[13]));
        ReportViewer1.LocalReport.DataSources.Add(dataSource);
        //ReportViewer1.LocalReport.SubreportProcessing += new Microsoft.Reporting.WebForms.SubreportProcessingEventHandler(ReportViewer1_SubreportProcessing);
    }

    public void SW_STATEMENT_DETAILS()
    {
        Single_Window_details SW = new Single_Window_details();
        ReportDataSource dataSource = new ReportDataSource("SW_STATEMENT", SW.Get_Single_Window_details_STATEMENT(ds.Tables[14]));
        ReportViewer1.LocalReport.DataSources.Add(dataSource);
        //ReportViewer1.LocalReport.SubreportProcessing += new Microsoft.Reporting.WebForms.SubreportProcessingEventHandler(ReportViewer1_SubreportProcessing);
    }

    public void Commercial_Tax_Details()
    {
        Commercial_Tax_Details Commercial_Tax = new Commercial_Tax_Details();
        ReportDataSource dataSource1 = new ReportDataSource("COMMERCIAL_TAX_DETAILS", Commercial_Tax.Get_Commercial_Tax_Details1(ds.Tables[0]));
        ReportViewer1.LocalReport.DataSources.Add(dataSource1);
    }

    //public void SW_SUP_DOC_DETAILS()
    //{
    //    Single_Window_details SW = new Single_Window_details();
    //    ReportDataSource dataSource = new ReportDataSource("SW_SUP_DOC", SW.Get_Single_Window_details_SUP_DOC(ds.Tables[15]));
    //    ReportViewer1.LocalReport.DataSources.Add(dataSource);
    //}

  
    public void Item_Details_SubReport()
    {
        ReportViewer1.LocalReport.SubreportProcessing += new Microsoft.Reporting.WebForms.SubreportProcessingEventHandler(ReportViewer1_SubreportProcessing);  
    }

    protected void ReportViewer1_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
    {
        ReportDataSource dataSource = new ReportDataSource("ITEM", Load_Item_Details);
        e.DataSources.Add(dataSource);   
    }

    public void TotalItem__DETAILS()
    {
        ReportDataSource dataSource = new ReportDataSource("ITEM", Load_Item_Details);
        ReportViewer1.LocalReport.DataSources.Add(dataSource);
    }
   
    public void RE_IMPORT_DETAILS()
    {
        Re_Import_Details RE_IMPORT = new Re_Import_Details();
        ReportDataSource dataSource1 = new ReportDataSource("REIMPORT", RE_IMPORT.Get_RE_IMPORT_DETAILS(ds.Tables[7]));
        ReportViewer1.LocalReport.DataSources.Add(dataSource1);
    }

    public void LICENSE_DETAILS()
    {
      
        License_Details LICENSE = new License_Details();
        //ReportDataSource dataSource1 = new ReportDataSource("LICENSE1", LICENSE.Get_LICENCE_DETAILS_EXPORT_ANNEXURE(ds.Tables[9]));
        ReportDataSource dataSource1 = new ReportDataSource("INVOICE_DETAILS", LICENSE.Get_LICENCE_DETAILS(ds.Tables[8], ""));
        
        //ReportDataSource dataSource1 = new ReportDataSource("LICENSE_DETAILS", LICENSE.Get_LICENCE_DETAILS(ds.Tables[8], ""));
        ReportViewer1.LocalReport.DataSources.Add(dataSource1);
    }

    public void LICENSE_DETAILS_SubReport()
    {
        ReportViewer1.LocalReport.SubreportProcessing += new Microsoft.Reporting.WebForms.SubreportProcessingEventHandler(ReportViewer1_SubreportProcessingnew);
    }

    protected void ReportViewer1_SubreportProcessingnew(object sender, SubreportProcessingEventArgs e)
    {
        License_Details LICENSE = new License_Details();
        //ReportDataSource dataSource = new ReportDataSource("License", LICENSE.Get_LICENCE_DETAILS(ds.Tables[8], ""));
        ReportDataSource dataSource = new ReportDataSource("License", LICENSE.Get_LICENCE_DETAILS_EXPORT_ANNEXURE(ds.Tables[8]));
        e.DataSources.Add(dataSource);
    }

    public void REIMPORT_DETAILS_SubReport()
    {
        ReportViewer1.LocalReport.SubreportProcessing += new Microsoft.Reporting.WebForms.SubreportProcessingEventHandler(ReportViewer1_SubreportProcessingREIMPORT);
    }

    protected void ReportViewer1_SubreportProcessingREIMPORT(object sender, SubreportProcessingEventArgs e)
    {
        Re_Import_Details RE_IMPORT = new Re_Import_Details();
        ReportDataSource dataSource2 = new ReportDataSource("REIMPORT", RE_IMPORT.Get_RE_IMPORT_DETAILS(ds.Tables[7]));
        e.DataSources.Add(dataSource2);
    }


    public void HSS_Details()
    {
        HSS_Details HSS = new HSS_Details();
        ReportDataSource dataSource1 = new ReportDataSource("HSS_DETAILS", HSS.Get_HSS_Details(ds.Tables[0]));
        ReportViewer1.LocalReport.DataSources.Add(dataSource1);

    }
    public void RSP_Details()
    {
        RSP_Details RSP = new RSP_Details();
        ReportDataSource dataSource1 = new ReportDataSource("ITEM_DETAILS", RSP.Get_RSP_DETAILS(ds.Tables[6]));
        ReportViewer1.LocalReport.DataSources.Add(dataSource1);

    }
    //public void Commercial_Tax_Details()
    //{
    //    Commercial_Tax_Details Commercial_Tax = new Commercial_Tax_Details();
    //    ReportDataSource dataSource1 = new ReportDataSource("COMMERCIAL_TAX_DETAILS", Commercial_Tax.Get_Commercial_Tax_Details(ds.Tables[0]));
    //    ReportViewer1.LocalReport.DataSources.Add(dataSource1);

    //}
    public void Exbond_Details()
    {
        Exbond_Details Exbond = new Exbond_Details();
        ReportDataSource dataSource1 = new ReportDataSource("EXBOND_DETAILS", Exbond.Get_Exbond_Details(ds.Tables[0]));
        ReportViewer1.LocalReport.DataSources.Add(dataSource1);

    }
    public string Return_ExRate_Value(string currency, string ExRate)
    {
        if (ExRate == "")
        {
            ExRate = "0.00";
        }
        else if (currency == "INR")
        {
            ExRate = "1";
        }
        else if (currency == "JPY")
        {
            ExRate = Convert.ToString(Convert.ToDouble(ExRate) / 100);
        }


        return ExRate;
    }
    public void Get_Invoice_Details(string ddlJobNo, DataRow row,int count)
    {

        //Load_Invoice_Details.Clear();
       
        //if (ds.Rows.Count > 0)
        //{
        //    SECTION46 = ds.Rows[0]["SECTION46"].ToString();
        //    FIRSTCHECK = ds.Rows[0]["FIRSTCHECK"].ToString();
        //    GREEN_CHANNEL = ds.Rows[0]["GREEN_CHANNEL"].ToString();
        //    KACHHA_BE = ds.Rows[0]["KACHHA_BE"].ToString();
        //    SECTION48 = ds.Rows[0]["SECTION48"].ToString();

        //}
       

            INVOICE_SLNO = row["INVOICE_SLNO"].ToString();
            INVOICE_NO = row["INVOICE_NO"].ToString();

            INVOICE_DATE = row["INVOICE_DATE"].ToString().Replace("01/01/1900", ""); 
            INVOICE_VALUE = Return_Zero_Value1(row["INVOICE_VALUE"].ToString());
            INVOICE_CURRENCY = row["INVOICE_CURRENCY"].ToString();
            TERMS = row["TERMS"].ToString();

            MIS_FREIGHT_CHARGES = row["MIS_FREIGHT_CHARGES"].ToString();
            MIS_FREIGHT_RATE = row["MIS_FREIGHT_RATE"].ToString();
            MIS_FREIGHT_CURRENCY = row["MIS_FREIGHT_CURRENCY"].ToString();
            MIS_FREIGHT_EXRATE = row["MIS_FREIGHT_EXRATE"].ToString();
            MIS_INSURANCE_CHARGES = row["MIS_INSURANCE_CHARGES"].ToString();
            MIS_INSURANCE_RATE = row["MIS_INSURANCE_RATE"].ToString();

            MIS_INSURANCE_CURRENCY = row["MIS_INSURANCE_CURRENCY"].ToString();
            MIS_INSURANCE_EXRATE = row["MIS_INSURANCE_EXRATE"].ToString();
            SUPPLIER_COUNTRY_NAME = row["SUPPLIER_COUNTRY_NAME"].ToString();
            SUPPLIER_COUNTRY_PINCODE = row["SUPPLIER_COUNTRY_PINCODE"].ToString();
            //nat = row["SUPPLIER_COUNTRY_PINCODE"].ToString();
            if (INVOICE_DATE == "01/01/1900" || INVOICE_DATE == "01-01-1900")
                INVOICE_DATE = "";

            Invoice_value = INVOICE_VALUE + " " + INVOICE_CURRENCY;
            //----------------------------------------------------------------------------------------------------------------//

            if (MIS_FREIGHT_RATE != "0" && MIS_FREIGHT_RATE != "0.00" && MIS_FREIGHT_RATE != "0.0000" && MIS_FREIGHT_RATE != "")
            {
                //----------FOR CHECKLIST PURPOSE-------------//
                if (MIS_FREIGHT_RATE == "20.0000" || MIS_FREIGHT_RATE == "20.0")
                    MIS_FREIGHT_RATE = "20";
                //----------FOR CHECKLIST PURPOSE-------------//

                MIS_FREIGHT_CHARGES = MIS_FREIGHT_RATE + "%"+"("+ Math.Round(Convert.ToDouble(MIS_FREIGHT_CHARGES),2) + " " + MIS_FREIGHT_CURRENCY+")";
            }
            else
            {
                if (MIS_FREIGHT_CHARGES != "")
                {
                    MIS_FREIGHT_CHARGES = MIS_FREIGHT_CHARGES + " " + MIS_FREIGHT_CURRENCY + " " + MIS_FREIGHT_EXRATE;
                }
                else
                {

                    // MIS_FREIGHT_CHARGES = "20%";
                }
                MIS_FREIGHT_RATE = "20";
            }
            //----------------------------------------------------------------------------------------------------------------//
            if (MIS_INSURANCE_RATE != "0" && MIS_INSURANCE_RATE != "0.00" && MIS_INSURANCE_RATE != "0.0000" && MIS_INSURANCE_RATE != "")
            {
                MIS_INSURANCE_CHARGES = MIS_INSURANCE_RATE + "%" + "(" + Math.Round(Convert.ToDouble(MIS_INSURANCE_CHARGES),2) + " " + MIS_INSURANCE_CURRENCY  + ")";
            }


            else
            {
                if (MIS_INSURANCE_CHARGES != "")
                {
                    MIS_INSURANCE_CHARGES = MIS_INSURANCE_CHARGES + " " + MIS_INSURANCE_CURRENCY + " " + MIS_INSURANCE_EXRATE;
                    // MIS_FREIGHT_CHARGES = MIS_FREIGHT_CHARGES + " " + MIS_FREIGHT_CURRENCY + " " + MIS_FREIGHT_EXRATE;
                }
                else
                {

                    //MIS_INSURANCE_CHARGES = "1.125%";
                }
                MIS_INSURANCE_RATE = "1.125";

            }
            //----------------------------------------------------------------------------------------------------------------//

            SVB_ASSESABLE_RATE = row["SVB_ASSESABLE_RATE"].ToString();
            SVB_ASSESABLE_STATUS = row["SVB_ASSESABLE_STATUS"].ToString();
            SVB_DUTY_STATUS = row["SVB_DUTY_STATUS"].ToString();
            SVB_DUTY_RATE = row["SVB_DUTY_RATE"].ToString();
            SVB_CUSTOM_HOUSE = row["SVB_CUSTOM_HOUSE"].ToString();
            string SVB_lOADINGON = row["SVB_lOADING_ON"].ToString();
            

            if (SVB_ASSESABLE_RATE != "")
            {
                SVB_ASSESABLE_RATE = SVB_ASSESABLE_RATE + "%" + "(" + SVB_ASSESABLE_STATUS + ")";
            }
            else
            {
                SVB_ASSESABLE_RATE = "";
            }
            if (SVB_DUTY_RATE != "")
            {
                SVB_DUTY_RATE = SVB_DUTY_RATE + "%" + "(" + SVB_DUTY_STATUS + ")";
            }
            else
            {
                SVB_DUTY_RATE = "";
            }
            MIS_CHARGES = Return_Zero_Value(row["MIS_CHARGES"].ToString());

            MIS_RATE = Return_Zero_Value(row["MIS_RATE"].ToString());
            MIS_EXRATE = Return_Zero_Value(row["MIS_EXRATE"].ToString());
           
            //double mis_charge = Convert.ToDouble(MIS_CHARGES);
            // double mis_rate = Convert.ToDouble(MIS_EXRATE);
            //double ttl = Convert.ToDouble(mis_charge) * Convert.ToDouble(mis_rate);
            //Total_Invoice = Convert.ToString(ttl);
            string MIS_CHARGES_Add = "";
            SupplierCountry_Name_Pincode = SUPPLIER_COUNTRY_NAME + " " + SUPPLIER_COUNTRY_PINCODE;
            if (MIS_CHARGES != "0")
            {
                MIS_CHARGES_Add = MIS_CHARGES + " " + MIS_CURRENCY + " " + MIS_EXRATE;
            }
            else
            {
                MIS_CHARGES_Add = "";
            }
            MIS_HIGHSEASALE_RATE = row["MIS_HIGHSEASALE_RATE"].ToString();
            string MIS_Hss_RATE = MIS_HIGHSEASALE_RATE.Substring(0, 1);


            if (MIS_HIGHSEASALE_RATE != "" && MIS_Hss_RATE != "0")
            {
                MIS_HIGHSEASALE_RATE = MIS_HIGHSEASALE_RATE + "%";

            }
            else
            {
                MIS_HIGHSEASALE_RATE = "";
            }

            MIS_HIGHSEASALE_CHARGES = row["MIS_HIGHSEASALE_CHARGES"].ToString();
            MIS_HIGHSEASALE_CURRENCY = row["MIS_HIGHSEASALE_CURRENCY"].ToString();
            MIS_HIGHSEASALE_EXRATE = row["MIS_HIGHSEASALE_EXRATE"].ToString();
            if (MIS_HIGHSEASALE_CHARGES != "")
            {
                MIS_HIGHSEASALE_CHARGES = MIS_HIGHSEASALE_CHARGES + " " + MIS_HIGHSEASALE_CURRENCY + " " + MIS_HIGHSEASALE_EXRATE;
            }
            else
            {
                MIS_HIGHSEASALE_CHARGES = "";
            }

            MIS_LOADING_CHARGES = row["MIS_LOADING_CHARGES"].ToString();
            MIS_LOADING_CURRENCY = row["MIS_LOADING_CURRENCY"].ToString();
            MIS_LOADING_EXRATE = row["MIS_LOADING_EXRATE"].ToString();
            if (MIS_LOADING_CHARGES != "")
            {
                MIS_LOADING_CHARGES = MIS_LOADING_CHARGES + " " + MIS_LOADING_CURRENCY + " " + MIS_LOADING_EXRATE;
            }
            else
            {
                MIS_LOADING_CHARGES = "";
            }


            MIS_DISCOUNT_RATE = row["MIS_DISCOUNT_RATE"].ToString();
            MIS_DISCOUNT_CHARGES = row["MIS_DISCOUNT_CHARGES"].ToString();
            MIS_DISCOUNT_CURRENCY = row["MIS_DISCOUNT_CURRENCY"].ToString();
            MIS_DISCOUNT_EXRATE = row["MIS_DISCOUNT_EXRATE"].ToString();


            //string MIS_Dscount_RATE = MIS_DISCOUNT_RATE.Substring(0, 1); // this line hide by Chithra on 20-03-2020 for Discount rate hide in Invoice details
            string MIS_Dscount_RATE = "";
            MIS_Dscount_RATE = MIS_DISCOUNT_RATE;


            if (MIS_DISCOUNT_RATE != "" && MIS_Dscount_RATE != "0")
            {
                MIS_Dscount_RATE = MIS_DISCOUNT_RATE.Substring(0, 1);
                MIS_DISCOUNT_RATE = MIS_DISCOUNT_RATE + "%";
            }
            else
            {
                MIS_DISCOUNT_RATE = "";
            }

            if (MIS_DISCOUNT_CHARGES != "" && MIS_DISCOUNT_CHARGES != "0")
            {
                MIS_DISCOUNT_CHARGES = MIS_DISCOUNT_CHARGES + " " + MIS_DISCOUNT_CURRENCY + " " + MIS_DISCOUNT_EXRATE;
            }
            else
            {
                MIS_DISCOUNT_CHARGES = "";
            }
            // ITem(ddlJobNo, i);
            INVOICE_EXRATE = Return_Zero_Value1(row["INVOICE_EXRATE"].ToString());
            // if (INVOICE_EXRATE != "")
            INVOICE_EXCHANGERATE = "1.00" + " " + INVOICE_CURRENCY + "=" + INVOICE_EXRATE + " " + "INR";
            ///else
            // INVOICE_EXRATE = "1.00" + " " + INVOICE_CURRENCY + "=" + "0" + " " + "INR";
           
            //Invoice Details
            INVOICE_ID = row["INVOICE_ID"].ToString();
        //----------------------------------------------------NATURE TRANSACTION-------------------------------------------------------------//

           string OTHER_NATURE_OF_TRANSACTION = row["OTHER_NATURE_OF_TRANSACTION"].ToString();
           string  OTHER_TERMS_OF_PAYMENT =row["OTHER_TERMS_OF_PAYMENT"].ToString();
            INVOICE_DETAILS inv = new INVOICE_DETAILS();

         if (OTHER_NATURE_OF_TRANSACTION == "S  Sale")
        {
            inv.TICK_SALE=TICK_MARK;
            inv.TICK_COSIGNMENT="";
            inv.TICK_HIRE="";
            inv.TICK_RENT="";
            inv.TICK_REPLACEMENT="";
            inv.TICK_GIFT="";
            inv.TICK_SAMPLE="";
            inv.TICK_OTHER_FREECOST="";
        }
        else if(OTHER_NATURE_OF_TRANSACTION=="F  Free Of Cost" || OTHER_NATURE_OF_TRANSACTION=="O  Others")
        {
            inv.TICK_SALE="";
            inv.TICK_COSIGNMENT="";
            inv.TICK_HIRE="";
            inv.TICK_RENT="";
            inv.TICK_REPLACEMENT="";
            inv.TICK_GIFT="";
            inv.TICK_SAMPLE="";
            inv.TICK_OTHER_FREECOST = TICK_MARK;
        }
        else if(OTHER_NATURE_OF_TRANSACTION=="C  Consignment")
        {
            inv.TICK_SALE="";
            inv.TICK_COSIGNMENT = TICK_MARK;
            inv.TICK_HIRE="";
            inv.TICK_RENT="";
            inv.TICK_REPLACEMENT="";
            inv.TICK_GIFT="";
            inv.TICK_SAMPLE="";
            inv.TICK_OTHER_FREECOST="";
        }
         else if (OTHER_NATURE_OF_TRANSACTION == "G  Gift")
        {
             inv.TICK_SALE="";
            inv.TICK_COSIGNMENT="";
            inv.TICK_HIRE="";
            inv.TICK_RENT="";
            inv.TICK_REPLACEMENT="";
            inv.TICK_GIFT = TICK_MARK;
            inv.TICK_SAMPLE="";
            inv.TICK_OTHER_FREECOST="";
        }
         else if(OTHER_NATURE_OF_TRANSACTION=="H  Hire")
        {
             inv.TICK_SALE="";
            inv.TICK_COSIGNMENT="";
            inv.TICK_HIRE = TICK_MARK;
            inv.TICK_RENT="";
            inv.TICK_REPLACEMENT="";
            inv.TICK_GIFT="";
            inv.TICK_SAMPLE="";
            inv.TICK_OTHER_FREECOST="";
        }
         else if(OTHER_NATURE_OF_TRANSACTION=="M  Sample")
        {
             inv.TICK_SALE="";
            inv.TICK_COSIGNMENT="";
            inv.TICK_HIRE="";
            inv.TICK_RENT="";
            inv.TICK_REPLACEMENT="";
            inv.TICK_GIFT="";
            inv.TICK_SAMPLE=TICK_MARK;
            inv.TICK_OTHER_FREECOST="";
        }
        else if(OTHER_NATURE_OF_TRANSACTION=="R  Rent")
        {
            inv.TICK_SALE="";
            inv.TICK_COSIGNMENT="";
            inv.TICK_HIRE="";
            inv.TICK_RENT=TICK_MARK;
            inv.TICK_REPLACEMENT="";
            inv.TICK_GIFT="";
            inv.TICK_SAMPLE="";
            inv.TICK_OTHER_FREECOST="";
        }
         else if(OTHER_NATURE_OF_TRANSACTION=="P  Replacement")
        {
             inv.TICK_SALE="";
            inv.TICK_COSIGNMENT="";
            inv.TICK_HIRE="";
            inv.TICK_RENT="";
            inv.TICK_REPLACEMENT=TICK_MARK;
            inv.TICK_GIFT="";
            inv.TICK_SAMPLE="";
            inv.TICK_OTHER_FREECOST="";
        }
        //----------------------------------------------------PAYMENT-------------------------------------------------------------//
        if(OTHER_TERMS_OF_PAYMENT=="OTH  Others")
        {
            inv.TICK_LC="";
            inv.TICK_FOC="";
            inv.TICK_SD="";
            inv.TICK_DP="";
            inv.TICK_OTHER = TICK_MARK;
        }
        else if(OTHER_TERMS_OF_PAYMENT=="DP  Document Presentation")
        {
            inv.TICK_LC="";
            inv.TICK_FOC="";
            inv.TICK_SD="";
            inv.TICK_DP = TICK_MARK;
            inv.TICK_OTHER="";
        }
        else if(OTHER_TERMS_OF_PAYMENT=="FC  Free Of Charge")
        {
            inv.TICK_LC="";
            inv.TICK_FOC = TICK_MARK;
            inv.TICK_SD="";
            inv.TICK_DP="";
            inv.TICK_OTHER="";
        }
        if(OTHER_TERMS_OF_PAYMENT=="LC  Letter Of Credit")
        {
            inv.TICK_LC = TICK_MARK;
            inv.TICK_FOC="";
            inv.TICK_SD="";
            inv.TICK_DP="";
            inv.TICK_OTHER="";
        }
        if(OTHER_TERMS_OF_PAYMENT=="SD  Site Draft")
        {
            inv.TICK_LC="";
            inv.TICK_FOC="";
            inv.TICK_SD = TICK_MARK;
            inv.TICK_DP="";
            inv.TICK_OTHER="";
        }
        //----------------------------------------------------SVB RELATION-------------------------------------------------------------//

         SVB_RELATION= row["SVB_RELATION"].ToString();
            if(SVB_RELATION=="N")
            SVB_RELATION="No";
            else if(SVB_RELATION=="Y")
            SVB_RELATION="Yes";                     
        //----------------------------------------------------SVB RELATION-------------------------------------------------------------//
            //----------------------------------------------------TERMS-------------------------------------------------------------//
            if (TERMS == "FOB")
            {
                inv.TICK_FOB = TICK_MARK;
                inv.TICK_CI = "";
                inv.TICK_CF = "";
                inv.TICK_CIF = "";
            }
            else if (TERMS == "CI")
            {
                inv.TICK_FOB = "";
                inv.TICK_CI = TICK_MARK;
                inv.TICK_CF = "";
                inv.TICK_CIF = "";
            }
            else if (TERMS == "CF")
            {
                inv.TICK_FOB = "";
                inv.TICK_CI = "";
                inv.TICK_CF = TICK_MARK;
                inv.TICK_CIF = "";
            }
            else if (TERMS == "CIF")
            {
                inv.TICK_FOB = "";
                inv.TICK_CI = "";
                inv.TICK_CF = "";
                inv.TICK_CIF = TICK_MARK;
            }
            //----------------------------------------------------TERMS-------------------------------------------------------------//
            //----------------------------------------------------SVB ASS DUTY-------------------------------------------------------------//
            if (SVB_lOADINGON == "Assessable")
            {
                inv.TICK_SVBLOAD_ASSESSABLE = "";
                inv.TICK_SVBLOAD_DUTY = "";
                inv.TICK_SVBLOAD_BOTH = "";
            }
            else if (SVB_lOADINGON == "Duty")
            {
                inv.TICK_SVBLOAD_ASSESSABLE = "";
                inv.TICK_SVBLOAD_DUTY = "";
                inv.TICK_SVBLOAD_BOTH = "";
            }
            else if (SVB_lOADINGON == "Both")
            {
                inv.TICK_SVBLOAD_ASSESSABLE = "";
                inv.TICK_SVBLOAD_DUTY = "";
                inv.TICK_SVBLOAD_BOTH = "";
            }
            //----------------------------------------------------SVB ASS DUTY-------------------------------------------------------------//
            
        
            Load_Invoice_Details.Add(new INVOICE_DETAILS()
            {
                INVOICE_ID = INVOICE_ID,

                INVOICE_EXRATE = INVOICE_EXCHANGERATE,

                Invoice_Details = Convert.ToString(count),
                FIRSTCHECK = FIRSTCHECK,
                GREEN_CHANNEL = GREEN_CHANNEL,
                KACHHA_BE = KACHHA_BE,
                SECTION48 = SECTION48,

                INVOICE_NO = row["INVOICE_NO"].ToString(),
                INVOICE_SLNO = Convert.ToInt32(INVOICE_SLNO),
                INVOICE_DATE = INVOICE_DATE,
                INVOICE_VALUE = Invoice_value,
                TERMS = row["TERMS"].ToString(),
                INVOICE_CURRENCY = row["INVOICE_CURRENCY"].ToString(),
                SUPPLIER_NAME = row["SUPPLIER_NAME"].ToString(),
                SUPPLIER_ADDRESS = row["SUPPLIER_ADDRESS"].ToString(),
                SUPPLIER_ADDRESS1 = row["SUPPLIER_ADDRESS1"].ToString(),
                SUPPLIER_ADDRESS2 = row["SUPPLIER_ADDRESS2"].ToString(),
                SUPPLIER_COUNTRY_NAME = SupplierCountry_Name_Pincode,

                MIS_FREIGHT_CHARGES = MIS_FREIGHT_CHARGES,

                MIS_INSURANCE_CHARGES = MIS_INSURANCE_CHARGES,

                SVB_RELATION =SVB_RELATION,

                SVB_REF_NO = row["SVB_REF_NO"].ToString(),
                SVB_REF_DATE = row["SVB_REF_DATE"].ToString().Replace("19000101", "").Replace("01/01/1900", ""),
                SVB_ASSESABLE_RATE = SVB_ASSESABLE_RATE,
                SVB_DUTY_RATE = SVB_DUTY_RATE,

                SVB_CUSTOM_HOUSE = row["SVB_CUSTOM_HOUSE"].ToString(),

      
                OTHER_PURCHASE_ORDER = row["OTHER_PURCHASE_ORDER"].ToString(),
            OTHER_PURCHASE_ORDER_DATE =row["OTHER_PURCHASE_ORDER_DATE"].ToString().Replace("19000101", "").Replace("01/01/1900", ""),
            OTHER_CONTRACT_NO = row["OTHER_CONTRACT_NO"].ToString(),
            OTHER_CONTRACT_DATE = row["OTHER_CONTRACT_DATE"].ToString().Replace("19000101", "").Replace("01/01/1900", ""),
            OTHER_LOC_NO = row["OTHER_LOC_NO"].ToString(),
            OTHER_LOC_DATE = row["OTHER_LOC_DATE"].ToString().Replace("19000101", "").Replace("01/01/1900", ""),
          
             OTHER_NATURE_OF_TRANSACTION =row["OTHER_NATURE_OF_TRANSACTION"].ToString(),
            OTHER_TERMS_OF_PAYMENT =row["OTHER_TERMS_OF_PAYMENT"].ToString(),
            OTHER_CONDITIONS = row["OTHER_CONDITIONS"].ToString(),
            OTHER_VALUATION_METHOD = row["OTHER_VALUATION_METHOD"].ToString(),
         
                 MIS_CHARGES_ = Return_Zero_Value(MIS_CHARGES),

                MIS_CHARGES = Return_Zero_Value(MIS_CHARGES_Add),
                MIS_RATE = Return_Zero_Value(row["MIS_RATE"].ToString()),
                MIS_EXRATE = MIS_EXRATE,
                MIS_HIGHSEASALE_RATE = MIS_HIGHSEASALE_RATE,
                MIS_HIGHSEASALE_CHARGES = MIS_HIGHSEASALE_CHARGES,

                MIS_LOADING_CHARGES = MIS_LOADING_CHARGES,
                MIS_DISCOUNT_RATE = MIS_DISCOUNT_RATE,
                MIS_DISCOUNT_CHARGES = MIS_DISCOUNT_CHARGES,
                SVB_ASSESABLE_STATUS=SVB_ASSESABLE_STATUS,
                SVB_DUTY_STATUS=SVB_DUTY_STATUS,
               
                TICK_SALE=inv.TICK_SALE,
                TICK_COSIGNMENT=inv.TICK_COSIGNMENT,
                TICK_HIRE=inv.TICK_HIRE,
                TICK_RENT=inv.TICK_RENT,
                TICK_REPLACEMENT=inv.TICK_REPLACEMENT,
                TICK_GIFT=inv.TICK_GIFT,
                TICK_SAMPLE=inv.TICK_SAMPLE,
                TICK_OTHER_FREECOST = inv.TICK_OTHER_FREECOST,
                TICK_LC=inv.TICK_LC,
                TICK_FOC = inv.TICK_FOC,
                TICK_SD = inv.TICK_SD,
                TICK_DP = inv.TICK_DP,
                TICK_OTHER = inv.TICK_OTHER,
                TICK_FOB = inv.TICK_FOB,
                TICK_CI = inv.TICK_CI,
                TICK_CF = inv.TICK_CF,
                TICK_CIF = inv.TICK_CIF,
                TICK_SVBLOAD_ASSESSABLE = inv.TICK_SVBLOAD_ASSESSABLE,
                TICK_SVBLOAD_DUTY = inv.TICK_SVBLOAD_DUTY,
                TICK_SVBLOAD_BOTH = inv.TICK_SVBLOAD_BOTH,
                TICK_SVBLOAD_ASS_STATUS = inv.TICK_SVBLOAD_ASS_STATUS,
                TICK_SVBLOAD_DUTY_STATUS = inv.TICK_SVBLOAD_DUTY_STATUS
            });

    }

    public void Get_ITEM_Details_new(string ddlJobNo, DataTable ds, DataTable ds2, DataTable ds3, DataTable dt_ReImport, DataSet ds_general, DataTable LICENCE_dt)
    //public void Get_ITEM_Details_new(string ddlJobNo, DataTable ds, DataTable ds2, DataTable ds3, DataTable dt_ReImport, DataSet ds_general)
    {

        //List<ITEM_DETAILS> list1 = new List<ITEM_DETAILS>();
        Load_Item_Details.Clear();
        //-------------------GENERAL---------------------//
        if (ds_general.Tables[0].Rows.Count > 0)
        {
            TRANSPORT_MODE = ds_general.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();
        }
        //-------------------GENERAL---------------------//
        CHECK_FREIGHT_EXRATE = 20;
        int b = 0, C = 0;

        double salary = 0.0;
        double salary1 = 0.0;
        double TOTAL_ITEM = 0.0;

        string preINVOICE_SLNO = "0", curINVOICE_SLNO = "0";
        while (ds.Rows.Count > C)
        {
            NUMBERTOWORDS = "";
            curINVOICE_SLNO = ds.Rows[C]["INVOICE_SLNO"].ToString();
            INVOICE_SLNO = ds.Rows[C]["INVOICE_SLNO"].ToString();
            INVOICE_VALUE = Return_Zero_Value1(ds.Rows[C]["INVOICE_VALUE"].ToString());
            INVOICE_EXRATE = Return_ExRate_Value(ds.Rows[C]["INVOICE_CURRENCY"].ToString(), ds.Rows[C]["INVOICE_EXRATE"].ToString());
            MIS_FREIGHT_RATE = Return_Zero_Value1(ds.Rows[C]["MIS_FREIGHT_RATE"].ToString());
            MIS_FREIGHT_CHARGES = Return_Zero_Value1(ds.Rows[C]["MIS_FREIGHT_CHARGES"].ToString());
            MIS_FREIGHT_EXRATE = Return_ExRate_Value(ds.Rows[C]["MIS_FREIGHT_CURRENCY"].ToString(), ds.Rows[C]["MIS_FREIGHT_EXRATE"].ToString());
            MIS_INSURANCE_CHARGES = Return_Zero_Value1(ds.Rows[C]["MIS_INSURANCE_CHARGES"].ToString());
            MIS_INSURANCE_EXRATE = Return_ExRate_Value(ds.Rows[C]["MIS_INSURANCE_CURRENCY"].ToString(), ds.Rows[C]["MIS_INSURANCE_EXRATE"].ToString());


            MIS_INSURANCE_RATE = Return_Zero_Value1(ds.Rows[C]["MIS_INSURANCE_RATE"].ToString());

            ASSESSABLE_TOTAL = 0;
            TOTAL_ITEM = 0.0;
            TOTAL_DUTY = 0.0;
            b = 0;
            SVB_ASSESABLE_RATE = Return_Zero_Value(ds.Rows[C]["SVB_ASSESABLE_RATE"].ToString());
            SVB_RELATION = Return_Zero_Value(ds.Rows[C]["SVB_RELATION"].ToString());
            
            SVB_REF_NO = ds.Rows[C]["SVB_REF_NO"].ToString();
            SVB_CUSTOM_HOUSE = ds.Rows[C]["SVB_CUSTOM_HOUSE"].ToString();
            SVB_REF_DATE = ds.Rows[C]["SVB_REF_DATE"].ToString().Replace("19000101", "").Replace("01/01/1900", "");
            

            MIS_EXRATE = Return_ExRate_Value(ds.Rows[C]["MIS_CURRENCY"].ToString(), ds.Rows[C]["MIS_EXRATE"].ToString());
            MIS_RATE = Return_Zero_Value(ds.Rows[C]["MIS_RATE"].ToString());
            MIS_CHARGES = Return_Zero_Value(ds.Rows[C]["MIS_CHARGES"].ToString());
            MIS_HIGHSEASALE_RATE = Return_Zero_Value(ds.Rows[C]["MIS_HIGHSEASALE_RATE"].ToString());
            MIS_HIGHSEASALE_CHARGES = Return_Zero_Value(ds.Rows[C]["MIS_HIGHSEASALE_CHARGES"].ToString());
            MIS_HIGHSEASALE_CURRENCY = ds.Rows[C]["MIS_HIGHSEASALE_CURRENCY"].ToString();
            MIS_HIGHSEASALE_EXRATE = Return_ExRate_Value(MIS_HIGHSEASALE_CURRENCY, ds.Rows[C]["MIS_HIGHSEASALE_EXRATE"].ToString());
            MIS_LOADING_CHARGES = Return_Zero_Value(ds.Rows[C]["MIS_LOADING_CHARGES"].ToString());
            MIS_LOADING_CURRENCY = ds.Rows[C]["MIS_LOADING_CURRENCY"].ToString();
            MIS_LOADING_EXRATE = Return_ExRate_Value(MIS_LOADING_CURRENCY, ds.Rows[C]["MIS_LOADING_EXRATE"].ToString());
            MIS_DISCOUNT_RATE = Return_Zero_Value(ds.Rows[C]["MIS_DISCOUNT_RATE"].ToString());
            MIS_DISCOUNT_CHARGES = Return_Zero_Value(ds.Rows[C]["MIS_DISCOUNT_CHARGES"].ToString());
            MIS_DISCOUNT_CURRENCY = ds.Rows[C]["MIS_DISCOUNT_CURRENCY"].ToString();
            MIS_DISCOUNT_EXRATE = Return_ExRate_Value(MIS_DISCOUNT_CURRENCY, ds.Rows[C]["MIS_DISCOUNT_EXRATE"].ToString());

            string MIS_Dscount_RATE = MIS_DISCOUNT_RATE.Substring(0, 1);
          
           
            DataView view = ds2.DefaultView;
            view.RowFilter = "INVOICE_SLNO = " + curINVOICE_SLNO;
            DataTable table = view.ToTable();
            DataSet dss = new DataSet();
            dss.Tables.Add(table);
            while (dss.Tables[0].Rows.Count > b)
            {

                INVOICE_NO_ITEM = dss.Tables[0].Rows[b]["INVOICE_NO"].ToString();
                INVOICE_SLNO = dss.Tables[0].Rows[b]["INVOICE_SLNO"].ToString();
                ITEM_SLNO = dss.Tables[0].Rows[b]["ITEM_SLNO"].ToString();
                ITEM_DESCRIPTION = dss.Tables[0].Rows[b]["ITEM_DESCRIPTION"].ToString();
                ITEM_QTY = dss.Tables[0].Rows[b]["ITEM_QTY"].ToString();
                ITEM_QTY_CODE = dss.Tables[0].Rows[b]["ITEM_QTY_CODE"].ToString();
                ITEM_UNIT_PRICE = dss.Tables[0].Rows[b]["ITEM_UNIT_PRICE"].ToString();
                ITEM_UNIT_CODE = dss.Tables[0].Rows[b]["ITEM_UNIT_CODE"].ToString();
                CTH_NO = dss.Tables[0].Rows[b]["CTH_NO"].ToString();
                GENEARL_DESCRIPTION = dss.Tables[0].Rows[b]["GENEARL_DESCRIPTION"].ToString();
                MANUFACTURER = dss.Tables[0].Rows[b]["MANUFACTURER"].ToString();
                BRAND = dss.Tables[0].Rows[b]["BRAND"].ToString();
                MODEL = dss.Tables[0].Rows[b]["MODEL"].ToString();
                END_USE_OF_ITEM = dss.Tables[0].Rows[b]["END_USE_OF_ITEM"].ToString();
                COUNTRY_OF_ORIGIN = dss.Tables[0].Rows[b]["COUNTRY_OF_ORIGIN"].ToString();
                ACCESSORIES = dss.Tables[0].Rows[b]["ACCESSORIES"].ToString();
                PREVIOUS_BE_NO = dss.Tables[0].Rows[b]["PREVIOUS_BE_NO"].ToString();
                PREVIOUS_BE_DATE = dss.Tables[0].Rows[b]["PREVIOUS_BE_DATE"].ToString().Replace("01/01/1900", "");
                UNIT_PRICE = dss.Tables[0].Rows[b]["UNIT_PRICE"].ToString();
                UNIT_CODE = dss.Tables[0].Rows[b]["UNIT_CODE"].ToString();
                CUSTOMS_HOUSE1 = dss.Tables[0].Rows[b]["CUSTOMS_HOUSE"].ToString();

                if (PREVIOUS_BE_DATE == "01/01/1900")
                {
                    PREVIOUS_BE_DATE = "";
                }

                PRODUCT_SEC_EDU_CESS_NOTN_SL = dss.Tables[0].Rows[b]["PRODUCT_SEC_EDU_CESS_NOTN_SL"].ToString();
                PRODUCT_EDU_CESS_NOTN_SL = dss.Tables[0].Rows[b]["PRODUCT_EDU_CESS_NOTN_SL"].ToString();
                PRODUCT_NCD_NOTN = dss.Tables[0].Rows[b]["PRODUCT_NCD_NOTN"].ToString();
                PRODUCT_NCD_SLNO = dss.Tables[0].Rows[b]["PRODUCT_NCD_SLNO"].ToString();
                PRODUCT_NCD_RATE = dss.Tables[0].Rows[b]["PRODUCT_NCD_RATE"].ToString();
                PRODUCT_NCD_SPL = dss.Tables[0].Rows[b]["PRODUCT_NCD_SPL"].ToString();
                PRODUCT_NCD_UNIT = dss.Tables[0].Rows[b]["PRODUCT_NCD_UNIT"].ToString();
                PRODUCT_NCD_SPL_TYPE = dss.Tables[0].Rows[b]["PRODUCT_NCD_SPL_TYPE"].ToString();
                if (PRODUCT_NCD_SLNO != "")
                    PRODUCT_NCD_SLNO = "/" + PRODUCT_NCD_SLNO;
                else if (PRODUCT_NCD_NOTN == "")
                    PRODUCT_NCD_SLNO = PRODUCT_NCD_SLNO;

                PRODUCT_AGGREGATE_DUTY_NOTN = dss.Tables[0].Rows[b]["PRODUCT_AGGREGATE_DUTY_NOTN"].ToString();
                PRODUCT_AGGREGATE_DUTY_NOTN_SL = dss.Tables[0].Rows[b]["PRODUCT_AGGREGATE_DUTY_NOTN_SL"].ToString();
                PRODUCT_AGGREGATE_DUTY_NOTN_RATE = dss.Tables[0].Rows[b]["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"].ToString();
                PRODUCT_SAFEGUARD_NOTN = dss.Tables[0].Rows[b]["PRODUCT_SAFEGUARD_NOTN"].ToString();
                PRODUCT_SAFEGUARD_SLNO = dss.Tables[0].Rows[b]["PRODUCT_SAFEGUARD_SLNO"].ToString();
                PRODUCT_SAFEGUARD_RATE = dss.Tables[0].Rows[b]["PRODUCT_SAFEGUARD_RATE"].ToString();
                PRODUCT_SAFEGUARD_SPL = dss.Tables[0].Rows[b]["PRODUCT_SAFEGUARD_SPL"].ToString();
                PRODUCT_SAFEGUARD_UNIT = dss.Tables[0].Rows[b]["PRODUCT_SAFEGUARD_UNIT"].ToString();
                PRODUCT_SAFEGUARD_SPL_TYPE = dss.Tables[0].Rows[b]["PRODUCT_SAFEGUARD_SPL_TYPE"].ToString();
                if (PRODUCT_SAFEGUARD_SLNO != "")
                    PRODUCT_SAFEGUARD_SLNO = "/" + PRODUCT_SAFEGUARD_SLNO;
                else if (PRODUCT_SAFEGUARD_NOTN == "")
                    PRODUCT_SAFEGUARD_SLNO = PRODUCT_SAFEGUARD_SLNO;

                PRODUCT_SAPTA_NOTN = dss.Tables[0].Rows[b]["PRODUCT_SAPTA_NOTN"].ToString();
                PRODUCT_SAPTA_SLNO = dss.Tables[0].Rows[b]["PRODUCT_SAPTA_SLNO"].ToString();
                PRODUCT_SAPTA_RATE = dss.Tables[0].Rows[b]["PRODUCT_SAPTA_RATE"].ToString();
                if (PRODUCT_SAPTA_SLNO != "")
                    PRODUCT_SAPTA_SLNO = "/" + PRODUCT_SAPTA_SLNO;
                else if (PRODUCT_SAPTA_NOTN == "")
                    PRODUCT_SAPTA_SLNO = PRODUCT_SAPTA_SLNO;

               

                PRODUCT_TARIFF_NOTN = dss.Tables[0].Rows[b]["PRODUCT_TARIFF_NOTN"].ToString();
                PRODUCT_TARIFF_SLNO = dss.Tables[0].Rows[b]["PRODUCT_TARIFF_SLNO"].ToString();
                PRODUCT_TARIFF_QTY = dss.Tables[0].Rows[b]["PRODUCT_TARIFF_QTY"].ToString();
                PRODUCT_TARIFF_AMOUNT = dss.Tables[0].Rows[b]["PRODUCT_TARIFF_AMOUNT"].ToString();
                PRODUCT_TARIFF_AMOUNT_UNIT = dss.Tables[0].Rows[b]["PRODUCT_TARIFF_AMOUNT_UNIT"].ToString();
                //if (PRODUCT_TARIFF_SLNO != "")
                //    PRODUCT_TARIFF_SLNO = "," + PRODUCT_TARIFF_SLNO;
                //else if (PRODUCT_TARIFF_NOTN == "")
                //    PRODUCT_TARIFF_SLNO = PRODUCT_TARIFF_SLNO;

                PRODUCT_MRP_YN = dss.Tables[0].Rows[b]["PRODUCT_MRP_YN"].ToString();
                PRODUCT_MRP_SL_NO = dss.Tables[0].Rows[b]["PRODUCT_MRP_SL_NO"].ToString();
                PRODUCT_MRP_AMOUNT = dss.Tables[0].Rows[b]["PRODUCT_MRP_AMOUNT"].ToString();
                PRODUCT_MRP_ABT_RATE = dss.Tables[0].Rows[b]["PRODUCT_MRP_ABT_RATE"].ToString();

                PRODUCT_CVD_SPL = dss.Tables[0].Rows[b]["PRODUCT_CVD_SPL"].ToString();
                PRODUCT_CVD_UNIT = dss.Tables[0].Rows[b]["PRODUCT_CVD_UNIT"].ToString();
                PRODUCT_CVD_SPL_TYPE = dss.Tables[0].Rows[b]["PRODUCT_CVD_SPL_TYPE"].ToString();
                PRODUCT_CVD_EDU_CESS_RATE = dss.Tables[0].Rows[b]["PRODUCT_CVD_EDU_CESS_RATE"].ToString();
                PRODUCT_CVD_SEC_EDU_CESS_RATE = dss.Tables[0].Rows[b]["PRODUCT_CVD_SEC_EDU_CESS_RATE"].ToString();
                PRODUCT_ADDL5_SIA_NOTN = dss.Tables[0].Rows[b]["PRODUCT_ADDL5_SIA_NOTN"].ToString();
                PRODUCT_ADDL5_SIA_NOTN_SL = dss.Tables[0].Rows[b]["PRODUCT_ADDL5_SIA_NOTN_SL"].ToString();
                PRODUCT_ADDL5_SIA_RATE = dss.Tables[0].Rows[b]["PRODUCT_ADDL5_SIA_RATE"].ToString();
                if (PRODUCT_ADDL5_SIA_NOTN_SL != "")
                    PRODUCT_ADDL5_SIA_NOTN_SL = "/" + PRODUCT_ADDL5_SIA_NOTN_SL;
                else if (PRODUCT_ADDL5_SIA_NOTN == "")
                {
                    PRODUCT_ADDL5_SIA_NOTN_SL = PRODUCT_ADDL5_SIA_NOTN_SL;
                }
               

                PRODUCT_ADDL_GSI_NOTN = dss.Tables[0].Rows[b]["PRODUCT_ADDL_GSI_NOTN"].ToString();
                PRODUCT_ADDL_GSI_SLNO = dss.Tables[0].Rows[b]["PRODUCT_ADDL_GSI_SLNO"].ToString();
                PRODUCT_ADDL_GSI_RATE = dss.Tables[0].Rows[b]["PRODUCT_ADDL_GSI_RATE"].ToString();
                PRODUCT_ADDL_GSI_SPL = dss.Tables[0].Rows[b]["PRODUCT_ADDL_GSI_SPL"].ToString();
                PRODUCT_ADDL_GSI_UNIT = dss.Tables[0].Rows[b]["PRODUCT_ADDL_GSI_UNIT"].ToString();
                PRODUCT_ADDL_GSI_SPL_TYPE = dss.Tables[0].Rows[b]["PRODUCT_ADDL_GSI_SPL_TYPE"].ToString();
                PRODUCT_ADDL_SHEII_NOTN = dss.Tables[0].Rows[b]["PRODUCT_ADDL_SHEII_NOTN"].ToString();
                PRODUCT_ADDL_SHEII_SLNO = dss.Tables[0].Rows[b]["PRODUCT_ADDL_SHEII_SLNO"].ToString();
                PRODUCT_ADDL_SHEII_RATE = dss.Tables[0].Rows[b]["PRODUCT_ADDL_SHEII_RATE"].ToString();
                PRODUCT_ADDL_SHEII_SPL = dss.Tables[0].Rows[b]["PRODUCT_ADDL_SHEII_SPL"].ToString();
                PRODUCT_ADDL_SHEII_UNIT = dss.Tables[0].Rows[b]["PRODUCT_ADDL_SHEII_UNIT"].ToString();
                PRODUCT_ADDL_SHEII_TYPE = dss.Tables[0].Rows[b]["PRODUCT_ADDL_SHEII_TYPE"].ToString();
                PRODUCT_ADDL_TTA_NOTN = dss.Tables[0].Rows[b]["PRODUCT_ADDL_TTA_NOTN"].ToString();
                PRODUCT_ADDL_TTA_SLNO = dss.Tables[0].Rows[b]["PRODUCT_ADDL_TTA_SLNO"].ToString();
                if (PRODUCT_ADDL_TTA_SLNO != "")
                    PRODUCT_ADDL_TTA_SLNO = "/" + PRODUCT_ADDL_TTA_SLNO;
                else if (PRODUCT_ADDL_TTA_NOTN == "")
                    PRODUCT_ADDL_TTA_SLNO = PRODUCT_ADDL_TTA_SLNO;

                PRODUCT_ADDL_TTA_RATE = dss.Tables[0].Rows[b]["PRODUCT_ADDL_TTA_RATE"].ToString();
                PRODUCT_ADDL_TTA_SPL = dss.Tables[0].Rows[b]["PRODUCT_ADDL_TTA_SPL"].ToString();
                PRODUCT_ADDL_TTA_UNIT = dss.Tables[0].Rows[b]["PRODUCT_ADDL_TTA_UNIT"].ToString();
                PRODUCT_ADDL_TTA_TYPE = dss.Tables[0].Rows[b]["PRODUCT_ADDL_TTA_TYPE"].ToString();
              

                PRODUCT_ADDL_HEALTH_CESS_NOTN = dss.Tables[0].Rows[b]["PRODUCT_ADDL_HEALTH_CESS_NOTN"].ToString();
                PRODUCT_ADDL_HEALTH_CESS_SLNO = dss.Tables[0].Rows[b]["PRODUCT_ADDL_HEALTH_CESS_SLNO"].ToString();
                PRODUCT_ADDL_HEALTH_CESS_RATE = dss.Tables[0].Rows[b]["PRODUCT_ADDL_HEALTH_CESS_RATE"].ToString();
                PRODUCT_ADDL_HEALTH_CESS_SPL = dss.Tables[0].Rows[b]["PRODUCT_ADDL_HEALTH_CESS_SPL"].ToString();
                PRODUCT_ADDL_HEALTH_CESS_UNIT = dss.Tables[0].Rows[b]["PRODUCT_ADDL_HEALTH_CESS_UNIT"].ToString();
                PRODUCT_ADDL_HEALTH_CESS_TYPE = dss.Tables[0].Rows[b]["PRODUCT_ADDL_HEALTH_CESS_TYPE"].ToString();
                if (PRODUCT_ADDL_HEALTH_CESS_SLNO != "")
                    PRODUCT_ADDL_HEALTH_CESS_SLNO = "/" + PRODUCT_ADDL_HEALTH_CESS_SLNO;
                else if (PRODUCT_ADDL_HEALTH_CESS_NOTN == "")
                    PRODUCT_ADDL_HEALTH_CESS_SLNO = PRODUCT_ADDL_HEALTH_CESS_SLNO;

                PRODUCT_CESS_NOTN = dss.Tables[0].Rows[b]["PRODUCT_CESS_NOTN"].ToString();
                PRODUCT_CESS_SLNO = dss.Tables[0].Rows[b]["PRODUCT_CESS_SLNO"].ToString();
                PRODUCT_CESS_RATE = dss.Tables[0].Rows[b]["PRODUCT_CESS_RATE"].ToString();
                PRODUCT_CESS_SPL = dss.Tables[0].Rows[b]["PRODUCT_CESS_SPL"].ToString();
                PRODUCT_CESS_UNIT = dss.Tables[0].Rows[b]["PRODUCT_CESS_UNIT"].ToString();
                //PREVIOUS_BE_DATE = dss.Tables[0].Rows[b]["PREVIOUS_BE_DATE"].ToString();
                ANTI_DUMPING_NOTN = dss.Tables[0].Rows[b]["ANTI_DUMPING_NOTN"].ToString();
                ANTI_DUMPING_NOTN_SLNO = dss.Tables[0].Rows[b]["ANTI_DUMPING_NOTN_SLNO"].ToString();
                if (ANTI_DUMPING_NOTN_SLNO != "")
                    ANTI_DUMPING_NOTN_SLNO = "/" + ANTI_DUMPING_NOTN_SLNO;
                else if (ANTI_DUMPING_NOTN == "")
                {
                    ANTI_DUMPING_NOTN_SLNO = ANTI_DUMPING_NOTN_SLNO;
                }
                CTH_SLNO = dss.Tables[0].Rows[b]["CTH_SLNO"].ToString();
                CTH_SUPPLIER_SLNO = dss.Tables[0].Rows[b]["CTH_SUPPLIER_SLNO"].ToString();
                CTH_QTY = dss.Tables[0].Rows[b]["CTH_QTY"].ToString();
                PRODUCT_RITC = dss.Tables[0].Rows[b]["PRODUCT_RITC"].ToString();
                PRODUCT_CTH = dss.Tables[0].Rows[b]["PRODUCT_CTH"].ToString();
                PRODUCT_CVD_RATE = dss.Tables[0].Rows[b]["PRODUCT_CVD_RATE"].ToString();
                PRODUCT_EDU_CESS_RATE = dss.Tables[0].Rows[b]["PRODUCT_EDU_CESS_RATE"].ToString();

                PRODUCT_SEC_EDU_CESS_RATE = dss.Tables[0].Rows[b]["PRODUCT_SEC_EDU_CESS_RATE"].ToString();
                PRODUCT_SEC_EDU_CESS_NOTN = dss.Tables[0].Rows[b]["PRODUCT_SEC_EDU_CESS_NOTN"].ToString();

                PRODUCT_SEC_EDU_CESS_NOTN_SLNO = dss.Tables[0].Rows[b]["PRODUCT_SEC_EDU_CESS_NOTN_SL"].ToString();

                PRODUCT_BCD_RATE = dss.Tables[0].Rows[b]["PRODUCT_BCD_RATE"].ToString();
                PRODUCT_CETH = dss.Tables[0].Rows[b]["PRODUCT_CETH"].ToString();
                PRODUCT_BCD_NOTN = dss.Tables[0].Rows[b]["PRODUCT_BCD_NOTN"].ToString();
                PRODUCT_BCD_SLNO = dss.Tables[0].Rows[b]["PRODUCT_BCD_SLNO"].ToString();
                if (PRODUCT_BCD_SLNO != "")
                    PRODUCT_BCD_SLNO = "/" + PRODUCT_BCD_SLNO;
                else if (PRODUCT_BCD_NOTN == "")
                {
                    PRODUCT_BCD_SLNO = PRODUCT_BCD_SLNO;
                }
                PRODUCT_CVD_NOTN = dss.Tables[0].Rows[b]["PRODUCT_CVD_NOTN"].ToString();
                PRODUCT_CVD_SLNO = dss.Tables[0].Rows[b]["PRODUCT_CVD_SLNO"].ToString();
                if (PRODUCT_CVD_SLNO != "")
                    PRODUCT_CVD_SLNO = "/" + PRODUCT_CVD_SLNO;
                else if (PRODUCT_CVD_NOTN == "")
                    PRODUCT_CVD_SLNO = PRODUCT_CVD_SLNO;
                
                PRODUCT_EDU_CESS_NOTN = dss.Tables[0].Rows[b]["PRODUCT_EDU_CESS_NOTN"].ToString();
                PRODUCT_EDU_CESS_NOTN_SLNO = dss.Tables[0].Rows[b]["PRODUCT_EDU_CESS_NOTN_SL"].ToString();
                if (PRODUCT_EDU_CESS_NOTN_SLNO != "")
                    PRODUCT_EDU_CESS_NOTN_SLNO = "/" + PRODUCT_EDU_CESS_NOTN_SLNO;
                else if (PRODUCT_EDU_CESS_NOTN == "")
                    PRODUCT_EDU_CESS_NOTN_SLNO = PRODUCT_EDU_CESS_NOTN_SLNO;

                PRODUCT_ADDL_DUTY_NOTN = dss.Tables[0].Rows[b]["PRODUCT_ADDL_DUTY_NOTN"].ToString();
                PRODUCT_ADDL_DUTY_NOTN = PRODUCT_ADDL_DUTY_NOTN.Trim();
                PRODUCT_ADDL_DUTY_NOTN_SLNO = dss.Tables[0].Rows[b]["PRODUCT_ADDL_DUTY_NOTN_SL"].ToString();
                PRODUCT_ADDL_DUTY_RATE = dss.Tables[0].Rows[b]["PRODUCT_ADDL_DUTY_RATE"].ToString();

                SCHEME_CODE = dss.Tables[0].Rows[b]["SCHEME_CODE"].ToString();
                SCHEME_NOTN = dss.Tables[0].Rows[b]["SCHEME_NOTN"].ToString();
                SCHEME_NOTN_SLNO = dss.Tables[0].Rows[b]["SCHEME_NOTN_SLNO"].ToString();
               // if (PRODUCT_BCD_NOTN != "")
                   // PRODUCT_BCD_NOTN = PRODUCT_BCD_NOTN + "/" + PRODUCT_BCD_SLNO;
                //if (PRODUCT_CVD_NOTN != "")
                    //PRODUCT_CVD_NOTN = PRODUCT_CVD_NOTN + " " + PRODUCT_CVD_NOTN_SLNO;
                if (PRODUCT_EDU_CESS_NOTN != "")
                    PRODUCT_EDU_CESS_NOTN = PRODUCT_EDU_CESS_NOTN + " " + PRODUCT_EDU_CESS_NOTN_SLNO;
                if (PRODUCT_SEC_EDU_CESS_NOTN != "")
                    PRODUCT_SEC_EDU_CESS_NOTN = PRODUCT_SEC_EDU_CESS_NOTN + " " + PRODUCT_SEC_EDU_CESS_NOTN_SLNO;

                if (SCHEME_CODE != "")
                {
                    string[] s1 = SCHEME_CODE.Split(new string[] { "-" }, StringSplitOptions.None);
                    SCHEME_CODE = s1[0].ToString();
                    SCHEME_NOTN_ = s1[1].ToString();
                }
                else
                {
                    SCHEME_NOTN_ = "0";
                }
                // --------------------------------------- ITEM CALCULATION---------------------------------------------------------------

                //double INV_EXRATE = Convert.ToDouble(INVOICE_VALUE) * Convert.ToDouble(INVOICE_EXRATE);
                //double FRIEGHT_EXRATE = INV_EXRATE * Convert.ToDouble(MIS_FREIGHT_RATE) / 100;
                //double INSURANCE_EXRATE = INV_EXRATE * Convert.ToDouble(MIS_INSURANCE_RATE) / 100;

                //double TOTAL = INV_EXRATE + FRIEGHT_EXRATE + INSURANCE_EXRATE;
                //double LANDING_CHARGE = TOTAL * 1 / 100;
                //double ASSESABLE_VALUE = TOTAL + LANDING_CHARGE;
                //string ass = Convert.ToString(Math.Round(Get_Indivitual_Assesable_Value(dt_ReImport, INVOICE_SLNO, INVOICE_NO_ITEM, ITEM_SLNO), 1).ToString("0.00"));
                //ASSESABLE_VALUE = Convert.ToDouble(ass);
               // ASSESABLE_VALUE = Get_Indivitual_Assesable_Value(dt_ReImport, INVOICE_SLNO, INVOICE_NO_ITEM, ITEM_SLNO);
                //ASSESSABLE_TOTAL = ASSESSABLE_TOTAL + ASSESABLE_VALUE;
                //------------------------------------------SCHEME_NOTNCALCULATION---------------------------------------------------------------//


                PRODUCT_BCD_RATE = Return_Zero_Value1(PRODUCT_BCD_RATE);


                PRODUCT_CVD_RATE = Return_Zero_Value1(PRODUCT_CVD_RATE);

                if (PRODUCT_EDU_CESS_RATE == "")
                {
                    PRODUCT_EDU_CESS_RATE = "2.00";
                }
                if (PRODUCT_SEC_EDU_CESS_RATE == "")
                {
                    PRODUCT_SEC_EDU_CESS_RATE = "1.00";
                }

                if (PRODUCT_ADDL_DUTY_NOTN == "" || PRODUCT_ADDL_DUTY_NOTN == "019/2006")
                {

                    PRODUCT_ADDL_DUTY_NOTN = "019/2006";
                    //PRODUCT_ADDL_DUTY_NOTN_SLNO = "4";
                    ADDTIONAL_DUTY_RATE = ADDTIONAL_DUTY = PRODUCT_ADDL_DUTY_RATE = "4.00";
                }
                else if (PRODUCT_ADDL_DUTY_NOTN != "019/2006")
                {
                    if (PRODUCT_ADDL_DUTY_RATE == "")
                    {
                        ADDTIONAL_DUTY_RATE = ADDTIONAL_DUTY = "0.00";
                    }
                    else
                    {
                        ADDTIONAL_DUTY_RATE = ADDTIONAL_DUTY = PRODUCT_ADDL_DUTY_RATE;

                    }
                }


                #region license_hide
                //string f = "";
                //string[] arr = { "DEEC", "REP", "DIL", "JBG", "EOU", "DUTIABLE" };
                //string[] arr1 = { "DEPB", "DFRC", "DFCC", "TRG+", "(KRSH)", "DFCS", "DFIA", "FMS", "FPS", "SHIS" };
                //string[] arr2 = { "EPCG" };


                //if (SCHEME_NOTN_ != "")
                //{
                //    if (SCHEME_NOTN_ != "0")
                //    {

                //        string value1 = Array.Find(arr, element => element.StartsWith(SCHEME_NOTN_, StringComparison.Ordinal));

                //        if (SCHEME_NOTN_.Trim() == "DUTIABLE")
                //        {
                //            value1 = "";
                //            SCHEME_NOTN_ = "";
                //        }

                //        if (SCHEME_NOTN_ == value1)
                //        {

                //            if ("DEEC" == value1 || "" == value1)//this code for to check scheme 00-Dutiable)
                //            {
                //                DataView view1 = ds3.DefaultView;
                //                view1.RowFilter = "INVOICE_SLNO = " + INVOICE_SLNO + " and " + "ITEM_SLNO = " + ITEM_SLNO;
                //                DataTable table1 = view1.ToTable();
                //                DataSet dss1 = new DataSet();
                //                dss1.Tables.Add(table1);
                //                //------------------------------------------DATA FETCH FROM LICENSE DETAILS------------------------------------------//

                //                if (dss1.Tables[0].Rows.Count > 0)
                //                {
                //                    EXCEMPTION = dss1.Tables[0].Rows[0]["EXCEMPTION"].ToString();
                //                    if (EXCEMPTION == "Y")
                //                    {
                //                        BASIC_DUTY = 0.00;
                //                        CVD = 0.00;
                //                        Customs_Edu_Cess = 0.00;
                //                        Customs_Higher_Edu_Cess = 0.00;
                //                        AddL_DUTY = 0.00;
                //                        BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
                //                        CVD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(CVD), 1).ToString("0.00"));
                //                        CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
                //                        CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                //                        ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AddL_DUTY), 1).ToString("0.00"));
                        
                //                    }
                //                }
                //                //------------------------------------------DATA FETCH FROM LICENSE DETAILS------------------------------------------//


                //                else
                //                {

                //                    DataSet ds1 = new DataSet();
                //                    adminmaster adm_Mas = new adminmaster();
                //                    adm_Mas.SCHEME_IMPORT_CODE = PRODUCT_CTH;
                //                    adm_Mas.SCHEME_IMPORT_NAME = "";
                //                    adm_Mas.SCHEME_NOTN = "";
                //                    adm_Mas.SCHEME_NOTN_SLNO = "";
                //                    adm_Mas.Name = "CTH_NOTN_RATE";

                //                    ds1 = adm_Mas.RetrieveAll_CheckList_Scheme_Import();
                                 
                //                    if (PRODUCT_BCD_RATE == "" || PRODUCT_BCD_RATE == "0" || PRODUCT_BCD_RATE == "0.00")
                //                    {
                //                              //------------------------------------------DATA FETCH FROM CTH MASTER------------------------------------------//
                //                        if (ds1.Tables[0].Rows.Count > 0)
                //                        {
                //                            string CTH_Rate = ds1.Tables[0].Rows[0]["CTH_RATE"].ToString();
                //                            double CTH_Rate1 = Convert.ToDouble(CTH_Rate);
                //                            PRODUCT_BCD_RATE = Convert.ToString(Convert.ToDouble(CTH_Rate1).ToString("F"));
                //                        }
                //                        //------------------------------------------DATA FETCH FROM CTH MASTER------------------------------------------//
                //                    }



                //                    if (PRODUCT_CVD_RATE == "" || PRODUCT_CVD_RATE == "0.00" || PRODUCT_CVD_RATE == "0")
                //                    {
                //                        //------------------------------------------DATA FETCH FROM CETH MASTER------------------------------------------//
                //                        if (ds1.Tables[1].Rows.Count > 0)
                //                        {
                //                            string CETH_Rate = ds1.Tables[1].Rows[0]["CETH_ADDITIONAL_CVD_S_RATE"].ToString();
                //                            double CETH_Rate1 = Convert.ToDouble(CETH_Rate);
                //                            PRODUCT_CVD_RATE = Convert.ToString(Convert.ToDouble(CETH_Rate1).ToString("F"));
                //                        }
                //                        //------------------------------------------DATA FETCH FROM CETH MASTER------------------------------------------//
                //                    }
                //                    if (PRODUCT_ADDL_DUTY_RATE == "" || PRODUCT_ADDL_DUTY_RATE == "0.00" || PRODUCT_ADDL_DUTY_RATE == "0")
                //                    {
                //                        adminmaster adm = new adminmaster();
                //                        adm.SCHEME_IMPORT_CODE = PRODUCT_ADDL_DUTY_NOTN;
                //                        adm.SCHEME_IMPORT_NAME = "";
                //                        adm.SCHEME_NOTN = "";
                //                        adm.SCHEME_NOTN_SLNO = "";
                //                        adm.Name = "ADDL_DUTY_RATE";

                //                        ds1 = adm.RetrieveAll_CheckList_Scheme_Import();
                //                        //------------------------------------------DATA FETCH FROM NOTIFICATION_CUSTOMS MASTER------------------------------------------//
                //                        if (ds1.Tables[0].Rows.Count > 0)
                //                        {
                //                            string ADDL_DUTY_RATE = ds1.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
                //                            double ADDL_DUTY_RATE1 = Convert.ToDouble(ADDL_DUTY_RATE);
                //                            ADDTIONAL_DUTY_RATE = ADDTIONAL_DUTY_RATE = Convert.ToString(Convert.ToDouble(ADDL_DUTY_RATE1).ToString("F"));
                //                        }
                //                        //------------------------------------------DATA FETCH FROM NOTIFICATION_CUSTOMS MASTER------------------------------------------//

                //                    }


                //                    BASIC_DUTY = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;



                //                    CVD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;


                //                    Customs_Edu_Cess = (BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;


                //                    Customs_Higher_Edu_Cess = (BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;
                //                    AddL_DUTY = (ASSESABLE_VALUE + BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess) * Convert.ToDouble(ADDTIONAL_DUTY_RATE) / 100;

                //                    //TOTAL_DUTY = (BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY);
                                                                        
                //                    BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
                //                    CVD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(CVD), 1).ToString("0.00"));
                //                    CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
                //                    CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                //                    ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AddL_DUTY), 1).ToString("0.00"));
                //                    TOTAL_DUTY = (Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(CEC_TOTAL) + Convert.ToDouble(CHEC_TOTAL) + Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL));

                //                }
                //            }
                //            else
                //            {
                //                BASIC_DUTY = 0.00;
                //                CVD = 0.00;
                //                Customs_Edu_Cess = 0.00;
                //                Customs_Higher_Edu_Cess = 0.00;
                //                AddL_DUTY = 0.00;
                //                BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
                //                CVD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(CVD), 1).ToString("0.00"));
                //                CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
                //                CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                //                ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AddL_DUTY), 1).ToString("0.00"));
                        
                //            }
                //        }

                //        else if (SCHEME_NOTN_ == "EPCG")
                //        {
                //            adminmaster adm = new adminmaster();
                //            adm.SCHEME_IMPORT_CODE = SCHEME_CODE;
                //            adm.SCHEME_IMPORT_NAME = SCHEME_NOTN_;
                //            adm.SCHEME_NOTN = SCHEME_NOTN;
                //            adm.SCHEME_NOTN_SLNO = SCHEME_NOTN_SLNO;
                //            adm.Name = "SCHEME_NOTN_RATE";
                //            DataSet ds1 = new DataSet();
                //            ds1 = adm.RetrieveAll_CheckList_Scheme_Import();
                //            //------------------------------------------DATA FETCH FROM SCHEME IMPORT MASTER------------------------------------------//

                //            if (ds1.Tables[0].Rows.Count > 0)
                //            {
                //                string SCHEME_Rate = ds1.Tables[0].Rows[0]["SCHEME_RATE"].ToString();
                //                double SCHEME_Rate1 = Convert.ToDouble(SCHEME_Rate);
                //                PRODUCT_BCD_RATE = Convert.ToString(Convert.ToDouble(SCHEME_Rate1).ToString("F"));
                //                BASIC_DUTY = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;



                //                CVD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;


                //                Customs_Edu_Cess = (BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;


                //                Customs_Higher_Edu_Cess = (BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;
                //                AddL_DUTY = (ASSESABLE_VALUE + BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess) * Convert.ToDouble(ADDTIONAL_DUTY_RATE) / 100;

                //                //TOTAL_DUTY = (BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY);




                //                BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
                //                CVD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(CVD), 1).ToString("0.00"));
                //                CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
                //                CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                //                ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AddL_DUTY), 1).ToString("0.00"));
                //                TOTAL_DUTY = (Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(CEC_TOTAL) + Convert.ToDouble(CHEC_TOTAL) + Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL));
                //            }
                //            //------------------------------------------DATA FETCH FROM SCHEME IMPORT MASTER------------------------------------------//



                //            else
                //            {
                //                BASIC_DUTY = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
                //                CVD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;
                //                Customs_Edu_Cess = (BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;
                //                Customs_Higher_Edu_Cess = (BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;
                //                AddL_DUTY = (ASSESABLE_VALUE + BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess) * Convert.ToDouble(ADDTIONAL_DUTY_RATE) / 100;
                //                //TOTAL_DUTY = (BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY);
                //                BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
                //                CVD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(CVD), 1).ToString("0.00"));
                //                CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
                //                CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                //                ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AddL_DUTY), 1).ToString("0.00"));
                //                TOTAL_DUTY = (Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(CEC_TOTAL) + Convert.ToDouble(CHEC_TOTAL) + Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL));
                //            }
                //        }

                //        else
                //        {

                //            string value2 = Array.Find(arr1, element => element.StartsWith(SCHEME_NOTN_, StringComparison.Ordinal));
                //            if (SCHEME_NOTN_ == value2)
                //            {
                //                DataView view1 = ds3.DefaultView;
                //                view1.RowFilter = "INVOICE_SLNO = " + INVOICE_SLNO + " and " + "ITEM_SLNO = " + ITEM_SLNO;
                //                DataTable table1 = view1.ToTable();
                //                DataSet dss1 = new DataSet();
                //                dss1.Tables.Add(table1);

                //                //------------------------------------------DATA FETCH FROM LICENSE DETAILS------------------------------------------//

                //                if (dss1.Tables[0].Rows.Count > 0)
                //                {
                //                    EXCEMPTION = dss1.Tables[0].Rows[0]["EXCEMPTION"].ToString();
                //                    if (EXCEMPTION == "Y")
                //                    {
                //                        BASIC_DUTY = 0.00;
                //                        CVD = 0.00;
                //                        Customs_Edu_Cess = 0.00;
                //                        Customs_Higher_Edu_Cess = 0.00;
                //                        AddL_DUTY = 0.00;
                //                        BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
                //                        CVD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(CVD), 1).ToString("0.00"));
                //                        CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
                //                        CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                //                        ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AddL_DUTY), 1).ToString("0.00"));
                //                    }
                //                    //------------------------------------------DATA FETCH FROM LICENSE DETAILS------------------------------------------//

                //                    else
                //                    {
                //                        BASIC_DUTY = 0.00;

                                       

                //                        CVD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;


                //                        Customs_Edu_Cess = (BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;


                //                        Customs_Higher_Edu_Cess = (BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;
                //                        AddL_DUTY = (ASSESABLE_VALUE + BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess) * Convert.ToDouble(ADDTIONAL_DUTY_RATE) / 100;

                //                        //TOTAL_DUTY = (BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY);




                //                        BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
                //                        CVD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(CVD), 1).ToString("0.00"));
                //                        CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
                //                        CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                //                        ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AddL_DUTY), 1).ToString("0.00"));
                //                        TOTAL_DUTY = (Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(CEC_TOTAL) + Convert.ToDouble(CHEC_TOTAL) + Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL));
                //                    }

                //                }
                //                else
                //                {
                //                    BASIC_DUTY = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;



                //                    CVD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;


                //                    Customs_Edu_Cess = (BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;


                //                    Customs_Higher_Edu_Cess =(BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;
                //                    AddL_DUTY =(ASSESABLE_VALUE + BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess) * Convert.ToDouble(ADDTIONAL_DUTY_RATE) / 100;

                //                    //TOTAL_DUTY = (BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY);




                //                    BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
                //                    CVD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(CVD), 1).ToString("0.00"));
                //                    CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
                //                    CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                //                    ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AddL_DUTY), 1).ToString("0.00"));
                //                    TOTAL_DUTY = (Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(CEC_TOTAL) + Convert.ToDouble(CHEC_TOTAL) + Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL));
                //                }
                //            }

                //        }
                //    }
                //    else
                //    {
                //        BASIC_DUTY = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;



                //        CVD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;


                //        Customs_Edu_Cess = (BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;


                //        Customs_Higher_Edu_Cess = (BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;
                //        AddL_DUTY = (ASSESABLE_VALUE + BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess) * Convert.ToDouble(ADDTIONAL_DUTY_RATE) / 100;

                //        //TOTAL_DUTY = (BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY);




                //        BASIC_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(BASIC_DUTY), 1).ToString("0.00"));
                //        CVD_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(CVD), 1).ToString("0.00"));
                //        CEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Edu_Cess), 1).ToString("0.00"));
                //        CHEC_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(Customs_Higher_Edu_Cess), 1).ToString("0.00"));
                //        ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Math.Round(Convert.ToDouble(AddL_DUTY), 1).ToString("0.00"));
                //        TOTAL_DUTY = (Convert.ToDouble(BASIC_DUTY_TOTAL) + Convert.ToDouble(CVD_TOTAL) + Convert.ToDouble(CEC_TOTAL) + Convert.ToDouble(CHEC_TOTAL) + Convert.ToDouble(ADDLTIONAL_DUTY_TOTAL));
                //    }
                //}


                //PRODUCT_BCD_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_BCD_RATE).ToString("F")) + "%";
                //PRODUCT_CVD_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_CVD_RATE).ToString("F")) + "%";
                //PRODUCT_EDU_CESS_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_EDU_CESS_RATE).ToString("F")) + "%";
                //PRODUCT_SEC_EDU_CESS_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE).ToString("F")) + "%";
                //ADDTIONAL_DUTY = Convert.ToString(Convert.ToDouble(ADDTIONAL_DUTY).ToString("F")) + "%";
                //string ITEM_TTL = Convert.ToString(TOTAL_DUTY);
                //ITEM_TTL = Convert.ToString(Convert.ToDouble(Convert.ToString(Math.Round(TOTAL_DUTY, 2).ToString("F"))));
                //ITEM_TOTAL = Convert.ToDouble(ITEM_TTL);
                //string ASS_TTL = Convert.ToString(ASSESSABLE_TOTAL);
                //ASS_TTL = Convert.ToString(Convert.ToDouble(Convert.ToString(Math.Round(ASSESSABLE_TOTAL, 2).ToString("F"))));
                //ASSESSABLE_TOTAL = Convert.ToDouble(ASS_TTL);
                //string ASS_Value = Convert.ToString(ASSESSABLE_TOTAL);
                //ASS_Value = Convert.ToString(Convert.ToDouble(Convert.ToString(Math.Round(ASSESABLE_VALUE, 2).ToString("F"))));
                //ASSESABLE_VALUE = Convert.ToDouble(ASS_Value);

                ////------------License_Details  Debit Amount Calculation ------------------------//
                //double debit_amt = 0;

                //debit_amt = Math.Round((ASSESABLE_VALUE * 1) / 100);

                //LICENSE_DEBIT_AMT = ASSESABLE_VALUE - debit_amt;
                //LICENSE_DEBIT_AMT = Math.Round(LICENSE_DEBIT_AMT+0.50, 2);

                #endregion

                ////-------------Update Debit Amount in License Details Table--------------------//
                //Transact.JOBNO = ddlJobNo;

                //Transact.INVOICE_SLNO = INVOICE_SLNO;
                //Transact.ITEM_SLNO = ITEM_SLNO;
                //Transact.DEBIT_AMT = Convert.ToString(LICENSE_DEBIT_AMT);

                //Transact.LICENSE_ID = "";

                //Transact.WORKING_PERIOD = working_period;


                //Transact.Ename = "select_con";
                //DataSet ds_lic=Transact.RetrieveAll_License_Details();


                ////------------End License_Details-----------------------------------------------//


                // LICENSE




                WHETHER_REIMPORT = "N";
                DataView view5 = dt_ReImport.DefaultView;
                if (view5.Count > 0)
                {
                    view5.RowFilter =  "INVOICE_NO = '" + INVOICE_NO + "' and " + "INVOICE_SLNO = '" + INVOICE_SLNO + "' and " + "ITEM_SLNO = '" + ITEM_SLNO + "'";
                    //view.RowFilter = "JOBNO = " + ddlJobNo + " and " + "INVOICE_SLNO = " + INV_SLNO + " and " + "ITEM_SLNO = " + ITEM_SLNO;
                    DataTable table1 = view5.ToTable();
                    DataSet dss1 = new DataSet();
                    dss1.Tables.Add(table1);
                    
                    if(dss1.Tables[0].Rows.Count > b)
                    {
                        WHETHER_REIMPORT = "Y";
                                      
                    }
                    else
                        WHETHER_REIMPORT = "N";                    
                }
              
                //**********************************

                if (SCHEME_CODE.Trim() == "00")
                {
                    SCHEME_CODE = "";
                }
                if (SCHEME_NOTN_ == "0" || SCHEME_NOTN_ == "")
                {
                    SCHEME_NOTN = "";

                    Load_Item_Details.Add(new Transaction_Default2()
                    {
                        INVOICE_SLNO=INVOICE_SLNO,
                        //SVB_REF_NO = SVB_REF_NO,
                        //SVB_REF_DATE = SVB_REF_DATE,
                        //SVB_ASSESABLE_RATE = SVB_ASSESABLE_RATE,
                        //SVB_DUTY_RATE = SVB_DUTY_RATE,

                        //SVB_CUSTOM_HOUSE = SVB_CUSTOM_HOUSE,
                        INVOICE_NO = INVOICE_NO_ITEM,
                        ITEM_DESCRIPTION = ITEM_DESCRIPTION,
                        ITEM_QTY = ITEM_QTY,
                        ITEM_QTY_CODE = ITEM_QTY_CODE,
                        ITEM_UNIT_PRICE = ITEM_UNIT_PRICE,
                        ITEM_UNIT_CODE = ITEM_UNIT_CODE,
                        CTH_NO = CTH_NO,
                       
                        SCHEME_CODE = SCHEME_CODE,
                        PRODUCT_SEC_EDU_CESS_NOTN_SL = PRODUCT_SEC_EDU_CESS_NOTN_SL,
                        PRODUCT_EDU_CESS_NOTN_SL = PRODUCT_EDU_CESS_NOTN_SL,
                        PRODUCT_NCD_NOTN = PRODUCT_NCD_NOTN,
                        PRODUCT_NCD_SLNO = PRODUCT_NCD_SLNO,
                        PRODUCT_NCD_RATE = PRODUCT_NCD_RATE,
                        PRODUCT_NCD_SPL = PRODUCT_NCD_SPL,
                        PRODUCT_NCD_UNIT = PRODUCT_NCD_UNIT,
                        PRODUCT_NCD_SPL_TYPE = PRODUCT_NCD_SPL_TYPE,
                        PRODUCT_AGGREGATE_DUTY_NOTN = PRODUCT_AGGREGATE_DUTY_NOTN,
                        PRODUCT_AGGREGATE_DUTY_NOTN_SL = PRODUCT_AGGREGATE_DUTY_NOTN_SL,
                        PRODUCT_AGGREGATE_DUTY_NOTN_RATE = PRODUCT_AGGREGATE_DUTY_NOTN_RATE,
                        PRODUCT_SAFEGUARD_NOTN = PRODUCT_SAFEGUARD_NOTN,
                        PRODUCT_SAFEGUARD_SLNO = PRODUCT_SAFEGUARD_SLNO,
                        PRODUCT_SAFEGUARD_RATE = PRODUCT_SAFEGUARD_RATE,
                        PRODUCT_SAFEGUARD_SPL = PRODUCT_SAFEGUARD_SPL,
                        PRODUCT_SAFEGUARD_UNIT = PRODUCT_SAFEGUARD_UNIT,
                        PRODUCT_SAFEGUARD_SPL_TYPE = PRODUCT_SAFEGUARD_SPL_TYPE,

                        PRODUCT_SAPTA_NOTN = PRODUCT_SAPTA_NOTN,
                        PRODUCT_SAPTA_SLNO = PRODUCT_SAPTA_SLNO,
                        PRODUCT_SAPTA_RATE = PRODUCT_SAPTA_RATE,

                        PRODUCT_TARIFF_NOTN = PRODUCT_TARIFF_NOTN,
                        PRODUCT_TARIFF_SLNO = PRODUCT_TARIFF_SLNO,
                        PRODUCT_TARIFF_QTY = PRODUCT_TARIFF_QTY,
                        PRODUCT_TARIFF_AMOUNT = PRODUCT_TARIFF_AMOUNT,
                        PRODUCT_TARIFF_AMOUNT_UNIT = PRODUCT_TARIFF_AMOUNT_UNIT,

                        PRODUCT_MRP_YN = PRODUCT_MRP_YN,
                        PRODUCT_MRP_SL_NO = PRODUCT_MRP_SL_NO,
                        PRODUCT_MRP_AMOUNT = PRODUCT_MRP_AMOUNT,
                        PRODUCT_MRP_ABT_RATE = PRODUCT_MRP_ABT_RATE,

                        PRODUCT_CVD_NOTN = PRODUCT_CVD_NOTN,
                        PRODUCT_CVD_SLNO = PRODUCT_CVD_SLNO,
                        PRODUCT_CVD_SPL = PRODUCT_CVD_SPL,
                        PRODUCT_CVD_UNIT = PRODUCT_CVD_UNIT,
                        PRODUCT_CVD_SPL_TYPE = PRODUCT_CVD_SPL_TYPE,
                        PRODUCT_CVD_EDU_CESS_RATE = PRODUCT_CVD_EDU_CESS_RATE,
                        PRODUCT_CVD_SEC_EDU_CESS_RATE = PRODUCT_CVD_SEC_EDU_CESS_RATE,
                        PRODUCT_ADDL5_SIA_NOTN = PRODUCT_ADDL5_SIA_NOTN,
                        PRODUCT_ADDL5_SIA_NOTN_SL = PRODUCT_ADDL5_SIA_NOTN_SL,
                        PRODUCT_ADDL5_SIA_RATE = PRODUCT_ADDL5_SIA_RATE,
                        PRODUCT_ADDL_GSI_NOTN = PRODUCT_ADDL_GSI_NOTN,
                        PRODUCT_ADDL_GSI_SLNO = PRODUCT_ADDL_GSI_SLNO,
                        PRODUCT_ADDL_GSI_RATE = PRODUCT_ADDL_GSI_RATE,
                        PRODUCT_ADDL_GSI_SPL = PRODUCT_ADDL_GSI_SPL,
                        PRODUCT_ADDL_GSI_UNIT = PRODUCT_ADDL_GSI_UNIT,
                        PRODUCT_ADDL_GSI_SPL_TYPE = PRODUCT_ADDL_GSI_SPL_TYPE,
                        PRODUCT_ADDL_SHEII_NOTN = PRODUCT_ADDL_SHEII_NOTN,
                        PRODUCT_ADDL_SHEII_SLNO = PRODUCT_ADDL_SHEII_SLNO,
                        PRODUCT_ADDL_SHEII_RATE = PRODUCT_ADDL_SHEII_RATE,
                        PRODUCT_ADDL_SHEII_SPL = PRODUCT_ADDL_SHEII_SPL,
                        PRODUCT_ADDL_SHEII_UNIT = PRODUCT_ADDL_SHEII_UNIT,
                        PRODUCT_ADDL_SHEII_TYPE = PRODUCT_ADDL_SHEII_TYPE,
                        PRODUCT_ADDL_TTA_NOTN = PRODUCT_ADDL_TTA_NOTN,
                        PRODUCT_ADDL_TTA_SLNO = PRODUCT_ADDL_TTA_SLNO,
                        PRODUCT_ADDL_TTA_RATE = PRODUCT_ADDL_TTA_RATE,
                        PRODUCT_ADDL_TTA_SPL = PRODUCT_ADDL_TTA_SPL,
                        PRODUCT_ADDL_TTA_UNIT = PRODUCT_ADDL_TTA_UNIT,
                        PRODUCT_ADDL_TTA_TYPE = PRODUCT_ADDL_TTA_TYPE,
                        PRODUCT_ADDL_HEALTH_CESS_NOTN = PRODUCT_ADDL_HEALTH_CESS_NOTN,
                        PRODUCT_ADDL_HEALTH_CESS_SLNO = PRODUCT_ADDL_HEALTH_CESS_SLNO,
                        PRODUCT_ADDL_HEALTH_CESS_RATE = PRODUCT_ADDL_HEALTH_CESS_RATE,
                        PRODUCT_ADDL_HEALTH_CESS_SPL = PRODUCT_ADDL_HEALTH_CESS_SPL,
                        PRODUCT_ADDL_HEALTH_CESS_UNIT = PRODUCT_ADDL_HEALTH_CESS_UNIT,
                        PRODUCT_ADDL_HEALTH_CESS_TYPE = PRODUCT_ADDL_HEALTH_CESS_TYPE,
                        PRODUCT_CESS_NOTN = PRODUCT_CESS_NOTN,
                        PRODUCT_CESS_SLNO = PRODUCT_CESS_SLNO,
                        PRODUCT_CESS_RATE = PRODUCT_CESS_RATE,
                        PRODUCT_CESS_SPL = PRODUCT_CESS_SPL,
                        PRODUCT_CESS_UNIT = PRODUCT_CESS_UNIT,
                        PREVIOUS_BE_DATE = PREVIOUS_BE_DATE,
                        ANTI_DUMPING_NOTN = ANTI_DUMPING_NOTN,
                        ANTI_DUMPING_NOTN_SLNO = ANTI_DUMPING_NOTN_SLNO,
                        CTH_SLNO = CTH_SLNO,
                        CTH_SUPPLIER_SLNO = CTH_SUPPLIER_SLNO,
                        CTH_QTY=CTH_QTY,
                        GENEARL_DESCRIPTION = GENEARL_DESCRIPTION,
                        MANUFACTURER = MANUFACTURER,
                        BRAND = BRAND,
                        MODEL = MODEL,
                        END_USE_OF_ITEM = END_USE_OF_ITEM,
                        COUNTRY_OF_ORIGIN = COUNTRY_OF_ORIGIN,
                        ACCESSORIES =ACCESSORIES,
                        PREVIOUS_BE_NO = PREVIOUS_BE_NO,
                        UNIT_PRICE = UNIT_PRICE,
                        UNIT_CODE = UNIT_CODE,
                        CUSTOMS_HOUSE1 =CUSTOMS_HOUSE1,
                                            
                        PRODUCT_RITC = PRODUCT_RITC,
                        PRODUCT_CTH = PRODUCT_CTH,
                        PRODUCT_CVD_RATE = PRODUCT_CVD_RATE,
                        PRODUCT_EDU_CESS_RATE = PRODUCT_EDU_CESS_RATE,
                        PRODUCT_EDU_CESS_NOTN = PRODUCT_EDU_CESS_NOTN,
                        PRODUCT_SEC_EDU_CESS_NOTN = PRODUCT_SEC_EDU_CESS_NOTN,

                        PRODUCT_SEC_EDU_CESS_RATE = PRODUCT_SEC_EDU_CESS_RATE,
                        PRODUCT_BCD_RATE = PRODUCT_BCD_RATE,
                        PRODUCT_BCD_NOTN = PRODUCT_BCD_NOTN,
                        PRODUCT_BCD_SLNO = PRODUCT_BCD_SLNO,
                        
                        PRODUCT_ADDL_DUTY_NOTN = PRODUCT_ADDL_DUTY_NOTN + " " + PRODUCT_ADDL_DUTY_NOTN_SLNO,
                        PRODUCT_CETH = PRODUCT_CETH,
                        ITEM_SLNO = ITEM_SLNO,
                        BASIC_DUTY_TOTAL = BASIC_DUTY_TOTAL,
                        ASSESABLE_VALUE = ASSESABLE_VALUE,
                        ADDTIONAL_DUTY = ADDTIONAL_DUTY,

                        CVD_TOTAL = CVD_TOTAL,
                        CEC_TOTAL = CEC_TOTAL,
                        CHEC_TOTAL = CHEC_TOTAL,
                        ADDLTIONAL_DUTY_TOTAL = ADDLTIONAL_DUTY_TOTAL,
                        TOTAL_ITEM_DUTY = TOTAL_ITEM_DUTY,
                        NUMBERTOWORDS = "RUPEES " + NUMBERTOWORDS,
                        ASSESSABLE_TOTAL = ASSESSABLE_TOTAL,
                        ITEM_TOTAL = ITEM_TOTAL,
                        WHETHER_REIMPORT = WHETHER_REIMPORT,

                        M_P_GROWER_ADD1 = dss.Tables[0].Rows[b]["M_P_GROWER_ADD1"].ToString(),
                        M_P_GROWER_ADD2 = dss.Tables[0].Rows[b]["M_P_GROWER_ADD2"].ToString(),
                        M_P_GROWER_CITY = dss.Tables[0].Rows[b]["M_P_GROWER_CITY"].ToString(),
                        M_P_GROWER_COUNTRY_SUBDIV = dss.Tables[0].Rows[b]["M_P_GROWER_COUNTRY_SUBDIV"].ToString(),
                        M_P_GROWER_COUNTRY = dss.Tables[0].Rows[b]["M_P_GROWER_COUNTRY"].ToString(),
                        M_P_GROWER_PIN = dss.Tables[0].Rows[b]["M_P_GROWER_PIN"].ToString(),
                        TRANSIT_COUNTRY = dss.Tables[0].Rows[b]["TRANSIT_COUNTRY"].ToString(),
                        SOURCE_COUNTRY = dss.Tables[0].Rows[b]["SOURCE_COUNTRY"].ToString(),
                        ACCESSORY_STATUS = dss.Tables[0].Rows[b]["ACCESSORY_STATUS"].ToString()
                        

                    });

                    b++;
                }
                else
                {
                    SCHEME_NOTN = "SCHEME NOTN: "+SCHEME_NOTN_ + ":" + SCHEME_NOTN + " " + SCHEME_NOTN_SLNO;

                    Load_Item_Details.Add(new Transaction_Default2()
                    {
                        INVOICE_SLNO = INVOICE_SLNO,
                        SVB_REF_NO = SVB_REF_NO,
                        SVB_REF_DATE = SVB_REF_DATE,
                        SVB_ASSESABLE_RATE = SVB_ASSESABLE_RATE,
                        SVB_DUTY_RATE = SVB_DUTY_RATE,

                        SVB_CUSTOM_HOUSE = SVB_CUSTOM_HOUSE,
                        INVOICE_NO = INVOICE_NO_ITEM,
                        ITEM_DESCRIPTION = ITEM_DESCRIPTION,
                        ITEM_QTY = ITEM_QTY,
                        ITEM_QTY_CODE = ITEM_QTY_CODE,
                        ITEM_UNIT_PRICE = ITEM_UNIT_PRICE,
                        ITEM_UNIT_CODE = ITEM_UNIT_CODE,
                        CTH_NO = CTH_NO,
                        SCHEME_CODE = SCHEME_CODE,
                        SCHEME_NOTN = SCHEME_NOTN,
                        PRODUCT_SEC_EDU_CESS_NOTN_SL = PRODUCT_SEC_EDU_CESS_NOTN_SL,
                        PRODUCT_EDU_CESS_NOTN_SL = PRODUCT_EDU_CESS_NOTN_SL,
                        PRODUCT_NCD_NOTN = PRODUCT_NCD_NOTN,
                        PRODUCT_NCD_SLNO = PRODUCT_NCD_SLNO,
                        PRODUCT_NCD_RATE = PRODUCT_NCD_RATE,
                        PRODUCT_NCD_SPL = PRODUCT_NCD_SPL,
                        PRODUCT_NCD_UNIT = PRODUCT_NCD_UNIT,
                        PRODUCT_NCD_SPL_TYPE = PRODUCT_NCD_SPL_TYPE,
                        PRODUCT_AGGREGATE_DUTY_NOTN = PRODUCT_AGGREGATE_DUTY_NOTN,
                        PRODUCT_AGGREGATE_DUTY_NOTN_SL = PRODUCT_AGGREGATE_DUTY_NOTN_SL,
                        PRODUCT_AGGREGATE_DUTY_NOTN_RATE = PRODUCT_AGGREGATE_DUTY_NOTN_RATE,
                        PRODUCT_SAFEGUARD_NOTN = PRODUCT_SAFEGUARD_NOTN,
                        PRODUCT_SAFEGUARD_SLNO = PRODUCT_SAFEGUARD_SLNO,
                        PRODUCT_SAFEGUARD_RATE = PRODUCT_SAFEGUARD_RATE,
                        PRODUCT_SAFEGUARD_SPL = PRODUCT_SAFEGUARD_SPL,
                        PRODUCT_SAFEGUARD_UNIT = PRODUCT_SAFEGUARD_UNIT,
                        PRODUCT_SAFEGUARD_SPL_TYPE = PRODUCT_SAFEGUARD_SPL_TYPE,

                        PRODUCT_SAPTA_NOTN = PRODUCT_SAPTA_NOTN,
                        PRODUCT_SAPTA_SLNO = PRODUCT_SAPTA_SLNO,
                        PRODUCT_SAPTA_RATE = PRODUCT_SAPTA_RATE,

                        PRODUCT_TARIFF_NOTN = PRODUCT_TARIFF_NOTN,
                        PRODUCT_TARIFF_SLNO = PRODUCT_TARIFF_SLNO,
                        PRODUCT_TARIFF_QTY = PRODUCT_TARIFF_QTY,
                        PRODUCT_TARIFF_AMOUNT = PRODUCT_TARIFF_AMOUNT,
                        PRODUCT_TARIFF_AMOUNT_UNIT = PRODUCT_TARIFF_AMOUNT_UNIT,

                        PRODUCT_MRP_YN = PRODUCT_MRP_YN,
                        PRODUCT_MRP_SL_NO = PRODUCT_MRP_SL_NO,
                        PRODUCT_MRP_AMOUNT = PRODUCT_MRP_AMOUNT,
                        PRODUCT_MRP_ABT_RATE = PRODUCT_MRP_ABT_RATE,
                        PRODUCT_CVD_NOTN = PRODUCT_CVD_NOTN,
                        PRODUCT_CVD_SLNO = PRODUCT_CVD_SLNO,
                        PRODUCT_CVD_SPL = PRODUCT_CVD_SPL,
                        PRODUCT_CVD_UNIT = PRODUCT_CVD_UNIT,
                        PRODUCT_CVD_SPL_TYPE = PRODUCT_CVD_SPL_TYPE,
                        PRODUCT_CVD_EDU_CESS_RATE = PRODUCT_CVD_EDU_CESS_RATE,
                        PRODUCT_CVD_SEC_EDU_CESS_RATE = PRODUCT_CVD_SEC_EDU_CESS_RATE,
                        PRODUCT_ADDL5_SIA_NOTN = PRODUCT_ADDL5_SIA_NOTN,
                        PRODUCT_ADDL5_SIA_NOTN_SL = PRODUCT_ADDL5_SIA_NOTN_SL,
                        PRODUCT_ADDL5_SIA_RATE = PRODUCT_ADDL5_SIA_RATE,
                        PRODUCT_ADDL_GSI_NOTN = PRODUCT_ADDL_GSI_NOTN,
                        PRODUCT_ADDL_GSI_SLNO = PRODUCT_ADDL_GSI_SLNO,
                        PRODUCT_ADDL_GSI_RATE = PRODUCT_ADDL_GSI_RATE,
                        PRODUCT_ADDL_GSI_SPL = PRODUCT_ADDL_GSI_SPL,
                        PRODUCT_ADDL_GSI_UNIT = PRODUCT_ADDL_GSI_UNIT,
                        PRODUCT_ADDL_GSI_SPL_TYPE = PRODUCT_ADDL_GSI_SPL_TYPE,
                        PRODUCT_ADDL_SHEII_NOTN = PRODUCT_ADDL_SHEII_NOTN,
                        PRODUCT_ADDL_SHEII_SLNO = PRODUCT_ADDL_SHEII_SLNO,
                        PRODUCT_ADDL_SHEII_RATE = PRODUCT_ADDL_SHEII_RATE,
                        PRODUCT_ADDL_SHEII_SPL = PRODUCT_ADDL_SHEII_SPL,
                        PRODUCT_ADDL_SHEII_UNIT = PRODUCT_ADDL_SHEII_UNIT,
                        PRODUCT_ADDL_SHEII_TYPE = PRODUCT_ADDL_SHEII_TYPE,
                        PRODUCT_ADDL_TTA_NOTN = PRODUCT_ADDL_TTA_NOTN,
                        PRODUCT_ADDL_TTA_SLNO = PRODUCT_ADDL_TTA_SLNO,
                        PRODUCT_ADDL_TTA_RATE = PRODUCT_ADDL_TTA_RATE,
                        PRODUCT_ADDL_TTA_SPL = PRODUCT_ADDL_TTA_SPL,
                        PRODUCT_ADDL_TTA_UNIT = PRODUCT_ADDL_TTA_UNIT,
                        PRODUCT_ADDL_TTA_TYPE = PRODUCT_ADDL_TTA_TYPE,
                        PRODUCT_ADDL_HEALTH_CESS_NOTN = PRODUCT_ADDL_HEALTH_CESS_NOTN,
                        PRODUCT_ADDL_HEALTH_CESS_SLNO = PRODUCT_ADDL_HEALTH_CESS_SLNO,
                        PRODUCT_ADDL_HEALTH_CESS_RATE = PRODUCT_ADDL_HEALTH_CESS_RATE,
                        PRODUCT_ADDL_HEALTH_CESS_SPL = PRODUCT_ADDL_HEALTH_CESS_SPL,
                        PRODUCT_ADDL_HEALTH_CESS_UNIT = PRODUCT_ADDL_HEALTH_CESS_UNIT,
                        PRODUCT_ADDL_HEALTH_CESS_TYPE = PRODUCT_ADDL_HEALTH_CESS_TYPE,
                        PRODUCT_CESS_NOTN = PRODUCT_CESS_NOTN,
                        PRODUCT_CESS_SLNO = PRODUCT_CESS_SLNO,
                        PRODUCT_CESS_RATE = PRODUCT_CESS_RATE,
                        PRODUCT_CESS_SPL = PRODUCT_CESS_SPL,
                        PRODUCT_CESS_UNIT = PRODUCT_CESS_UNIT,
                        PREVIOUS_BE_DATE = PREVIOUS_BE_DATE,
                        ANTI_DUMPING_NOTN = ANTI_DUMPING_NOTN,
                        ANTI_DUMPING_NOTN_SLNO = ANTI_DUMPING_NOTN_SLNO,
                        CTH_SLNO = CTH_SLNO,
                        CTH_SUPPLIER_SLNO = CTH_SUPPLIER_SLNO,
                        CTH_QTY = CTH_QTY,
                        GENEARL_DESCRIPTION = GENEARL_DESCRIPTION,
                        MANUFACTURER = MANUFACTURER,
                        BRAND = BRAND,
                        MODEL = MODEL,
                        END_USE_OF_ITEM = END_USE_OF_ITEM,
                        COUNTRY_OF_ORIGIN = COUNTRY_OF_ORIGIN,
                        ACCESSORIES = ACCESSORIES,
                        PREVIOUS_BE_NO = PREVIOUS_BE_NO,
                        UNIT_PRICE = UNIT_PRICE,
                        UNIT_CODE = UNIT_CODE,
                        CUSTOMS_HOUSE1 = CUSTOMS_HOUSE1,
                        
                        PRODUCT_RITC = PRODUCT_RITC,
                        PRODUCT_CTH = PRODUCT_CTH,
                        PRODUCT_CVD_RATE = PRODUCT_CVD_RATE,
                        PRODUCT_EDU_CESS_RATE = PRODUCT_EDU_CESS_RATE,
                        PRODUCT_EDU_CESS_NOTN = PRODUCT_EDU_CESS_NOTN,
                        PRODUCT_SEC_EDU_CESS_NOTN = PRODUCT_SEC_EDU_CESS_NOTN,

                        PRODUCT_SEC_EDU_CESS_RATE = PRODUCT_SEC_EDU_CESS_RATE,
                        PRODUCT_BCD_RATE = PRODUCT_BCD_RATE,
                        PRODUCT_BCD_NOTN = PRODUCT_BCD_NOTN,
                        PRODUCT_BCD_SLNO = PRODUCT_BCD_SLNO,
                       
                        PRODUCT_ADDL_DUTY_NOTN = PRODUCT_ADDL_DUTY_NOTN + " " + PRODUCT_ADDL_DUTY_NOTN_SLNO,

                        PRODUCT_CETH = PRODUCT_CETH,
                        ITEM_SLNO = ITEM_SLNO,
                        BASIC_DUTY_TOTAL = BASIC_DUTY_TOTAL,
                        ASSESABLE_VALUE = ASSESABLE_VALUE,
                        ADDTIONAL_DUTY = ADDTIONAL_DUTY,

                        CVD_TOTAL = CVD_TOTAL,
                        CEC_TOTAL = CEC_TOTAL,
                        CHEC_TOTAL = CHEC_TOTAL,
                        ADDLTIONAL_DUTY_TOTAL = ADDLTIONAL_DUTY_TOTAL,
                        TOTAL_ITEM_DUTY = TOTAL_ITEM_DUTY,
                        NUMBERTOWORDS = "RUPEES " + NUMBERTOWORDS,
                        ASSESSABLE_TOTAL = ASSESSABLE_TOTAL,
                        ITEM_TOTAL = ITEM_TOTAL,
                        WHETHER_REIMPORT = WHETHER_REIMPORT,

                        M_P_GROWER_ADD1 = dss.Tables[0].Rows[b]["M_P_GROWER_ADD1"].ToString(),
                        M_P_GROWER_ADD2 = dss.Tables[0].Rows[b]["M_P_GROWER_ADD2"].ToString(),
                        M_P_GROWER_CITY = dss.Tables[0].Rows[b]["M_P_GROWER_CITY"].ToString(),
                        M_P_GROWER_COUNTRY_SUBDIV = dss.Tables[0].Rows[b]["M_P_GROWER_COUNTRY_SUBDIV"].ToString(),
                        M_P_GROWER_COUNTRY = dss.Tables[0].Rows[b]["M_P_GROWER_COUNTRY"].ToString(),
                        M_P_GROWER_PIN = dss.Tables[0].Rows[b]["M_P_GROWER_PIN"].ToString(),
                        TRANSIT_COUNTRY = dss.Tables[0].Rows[b]["TRANSIT_COUNTRY"].ToString(),
                        SOURCE_COUNTRY = dss.Tables[0].Rows[b]["SOURCE_COUNTRY"].ToString(),
                        ACCESSORY_STATUS = dss.Tables[0].Rows[b]["ACCESSORY_STATUS"].ToString()

                    });

                    b++;
                }      
            }
            Get_Invoice_Details(ddlJobNo, ds.Rows[C], ds_general.Tables[5].Rows.Count);
            C++;
        }
    }

    public double Get_Indivitual_Assesable_Value(DataTable dt_ReImport, string INV_SLNO, string INV_NO, string ITEM_SLNO)
    {
        INVOICE_VALUE_INR = Convert.ToDouble(INVOICE_VALUE) * Convert.ToDouble(INVOICE_EXRATE);
        MISC_AMOUNT = Convert.ToDouble(MIS_CHARGES) * Convert.ToDouble(MIS_EXRATE);
        //-----DISCOUNT AMOUNT CAL--------------//
        if (MIS_DISCOUNT_RATE != "0" && MIS_DISCOUNT_RATE != "0.00")
        {
            DISCOUNT_AMOUNT = (INVOICE_VALUE_INR / 100) * Convert.ToDouble(MIS_DISCOUNT_RATE);
            TOTAL_INVOICE_VALUE = INVOICE_VALUE_INR - DISCOUNT_AMOUNT;
        }
        else if (MIS_DISCOUNT_CHARGES != "0" && MIS_DISCOUNT_CHARGES != "0.00")
        {
            TOTAL_INVOICE_VALUE = INVOICE_VALUE_INR - DISCOUNT_AMOUNT;
        }
        else
            TOTAL_INVOICE_VALUE = INVOICE_VALUE_INR;
        //-----DISCOUNT AMOUNT CAL--------------//

        //-----INSURANCE AMOUNT CAL--------------//
        if (MIS_INSURANCE_RATE != "0" && MIS_INSURANCE_RATE != "0.00")
        {
            INSURANCE_AMOUNT = (Convert.ToDouble(MIS_INSURANCE_RATE) * (MISC_AMOUNT + TOTAL_INVOICE_VALUE)) / 100;

        }
        else if (MIS_INSURANCE_CHARGES != "0" && MIS_INSURANCE_CHARGES != "0.00")
        {
            INSURANCE_AMOUNT = Convert.ToDouble(MIS_INSURANCE_CHARGES) * Convert.ToDouble(MIS_INSURANCE_EXRATE);

        }
        //-----INSURANCE AMOUNT CAL--------------//

        //-----FREIGHT AMOUNT CAL--------------//


        if (MIS_FREIGHT_RATE != "0" && MIS_FREIGHT_RATE != "0.00")
        {
            FREIGHT_AMOUNT = (Convert.ToDouble(MIS_FREIGHT_RATE) * (MISC_AMOUNT + TOTAL_INVOICE_VALUE)) / 100;

        }
        if (TRANSPORT_MODE == "Sea" && TRANSPORT_MODE == "Land")
        {
            if (MIS_FREIGHT_RATE != "0" && MIS_FREIGHT_RATE != "0.00")
            {
            }
            else
            {

                if (MIS_FREIGHT_CHARGES != "")
                {
                    FREIGHT_AMOUNT = Convert.ToDouble(MIS_FREIGHT_CHARGES) * Convert.ToDouble(MIS_FREIGHT_EXRATE);

                }
            }
        }
        else
        {
            if (MIS_FREIGHT_RATE != "0" && MIS_FREIGHT_RATE != "0.00")
            {
            }
            else
            {
                if (MIS_FREIGHT_CHARGES != "0" && MIS_FREIGHT_CHARGES != "0.00")
                {
                    FREIGHT_AMOUNT = Convert.ToDouble(MIS_FREIGHT_CHARGES) * Convert.ToDouble(MIS_FREIGHT_EXRATE);
                    CHECK_FREIGHT_RATE = (CHECK_FREIGHT_EXRATE * TOTAL_INVOICE_VALUE) / 100;
                    if (CHECK_FREIGHT_EXRATE >= Convert.ToDouble(MIS_FREIGHT_CHARGES))
                    {
                        FREIGHT_AMOUNT = CHECK_FREIGHT_RATE;
                    }
                }
            }
        }

        //-----FREIGHT AMOUNT CAL--------------//

        //-----ITEM AMOUNT CAL--------------//
        INDIVITUAL_INVOICE_VALUE = Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE) * Convert.ToDouble(INVOICE_EXRATE);
        INDIVITUAL_DISCOUNT_AMOUNT = INDIVITUAL_INVOICE_VALUE * DISCOUNT_AMOUNT / TOTAL_INVOICE_VALUE;


        //-----REIMPORTT CAL--------------//
        DataView view = dt_ReImport.DefaultView;
        if (view.Count > 0)
        {
            view.RowFilter = "INVOICE_NO = '" + INV_NO + "' and " + "INVOICE_SLNO = '" + INV_SLNO + "' and " + "ITEM_SLNO = '" + ITEM_SLNO+"'";
            //view.RowFilter = "JOBNO = " + ddlJobNo + " and " + "INVOICE_SLNO = " + INV_SLNO + " and " + "ITEM_SLNO = " + ITEM_SLNO;
            DataTable table = view.ToTable();
            DataSet dss = new DataSet();
            dss.Tables.Add(table);
            int b = 0;
            while (dss.Tables[0].Rows.Count > b)
            {
                REIMPORT_FREIGHT = Return_Zero_Value(dss.Tables[0].Rows[b]["EXPORT_FREIGHT"].ToString());
                REIMPORT_INSURANCE = Return_Zero_Value(dss.Tables[0].Rows[b]["EXPORT_INSURANCE"].ToString());

                REIMPORT_FREIGHT_AMOUNT = REIMPORT_FREIGHT_AMOUNT + Convert.ToDouble(REIMPORT_FREIGHT);
                REIMPORT_INSURANCE_AMOUNT = REIMPORT_INSURANCE_AMOUNT + Convert.ToDouble(REIMPORT_INSURANCE);
                b++;
            }
        }
        //-----REIMPORTT CAL--------------//
        //-----REIMPORTT FREIGHT CAL--------------//

        INDIVITUAL_FREIGHT_AMOUNT = INDIVITUAL_INVOICE_VALUE / TOTAL_INVOICE_VALUE * FREIGHT_AMOUNT;
        INDIVITUAL_FREIGHT_AMOUNT = INDIVITUAL_FREIGHT_AMOUNT + REIMPORT_FREIGHT_AMOUNT;

        //-----REIMPORTT FREIGHT CAL--------------//

        //-----REIMPORTT INSURANCE CAL--------------//

        INDIVITUAL_INSURANCE_AMOUNT = INDIVITUAL_INVOICE_VALUE / TOTAL_INVOICE_VALUE * INSURANCE_AMOUNT;
        INDIVITUAL_INSURANCE_AMOUNT = INDIVITUAL_INSURANCE_AMOUNT + REIMPORT_INSURANCE_AMOUNT;

        //-----REIMPORTT INSURANCE CAL--------------//

        //-----MISC CAL--------------//

        INDIVITUAL_MISC_AMOUNT = INDIVITUAL_INVOICE_VALUE / TOTAL_INVOICE_VALUE * MISC_AMOUNT;

        //INDIVITUAL_TOTAL_AMOUNT = INDIVITUAL_DISCOUNT_AMOUNT + INDIVITUAL_INSURANCE_AMOUNT + INDIVITUAL_FREIGHT_AMOUNT + INDIVITUAL_MISC_AMOUNT;
        INDIVITUAL_TOTAL_AMOUNT = INDIVITUAL_INVOICE_VALUE + INDIVITUAL_INSURANCE_AMOUNT + INDIVITUAL_FREIGHT_AMOUNT + INDIVITUAL_MISC_AMOUNT;
        //-----MISC CAL--------------//

        //-----HSS CAL--------------//
        if (MIS_HIGHSEASALE_RATE != "0" && MIS_HIGHSEASALE_RATE != "0.00")
        {
            INDIVITUAL_HSS_AMOUNT = (INDIVITUAL_TOTAL_AMOUNT * Convert.ToDouble(MIS_HIGHSEASALE_RATE)) / 100;
        }
        else if (MIS_HIGHSEASALE_CHARGES != "0" && MIS_HIGHSEASALE_CHARGES != "0.00")
        {
            INDIVITUAL_HSS_AMOUNT = (INDIVITUAL_TOTAL_AMOUNT * Convert.ToDouble(MIS_HIGHSEASALE_CHARGES)) / 100;
        }

        //-----HSS CAL--------------//

        //-----SVB CAL--------------//
        if (SVB_ASSESABLE_RATE != "0" && SVB_ASSESABLE_RATE != "0.00")
        {
            INDIVITUAL_SVB_AMOUNT = (INDIVITUAL_TOTAL_AMOUNT * Convert.ToDouble(SVB_ASSESABLE_RATE)) / 100;
        }

        //-----SVB CAL--------------//

        //-----CIF CAL--------------//
        INDIVITUAL_CIF_AMOUNT = INDIVITUAL_TOTAL_AMOUNT + INDIVITUAL_HSS_AMOUNT + INDIVITUAL_SVB_AMOUNT;

        //-----CIF CAL--------------//
        //-----LANDING COST CAL--------------//
        INDIVITUAL_LANDING_COST = (INDIVITUAL_CIF_AMOUNT * 1) / 100;

        //-----LANDING COST CAL--------------//
        //-----ASSESABLE CAL--------------//
        INDIVITUAL_ASSESSABLE_AMOUNT =  INDIVITUAL_CIF_AMOUNT + INDIVITUAL_LANDING_COST;

        //-----ASSESABLE CAL--------------//

        //-----ITEM AMOUNT CAL--------------//
        return INDIVITUAL_ASSESSABLE_AMOUNT;
    }
    public string Return_Zero_Value(string val)
    {
        if (val == "")
        {
            val = "0";
        }
        return val;
    }
    public string Return_Zero_Value1(string val)
    {
        if (val == "")
        {
            val = "0.00";
        }
        return val;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        // Variables
        Warning[] warnings;
        string[] streamIds;
        string mimeType = string.Empty;
        string encoding = string.Empty;
        string extension = string.Empty;
        string fileName = "a";
       
        byte[] bytes = ReportViewer1.LocalReport.Render("word", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
        Session["report"] = bytes;
      

         //Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
        Response.Buffer = true;
        Response.Clear();
        Response.ContentType = "application/rtf";
       
        //Response.BinaryWrite(bytes); // create the file
        //Response.Flush(); // send it to the client to download
        Response.OutputStream.Write(bytes, 0, bytes.Length);
        Response.AddHeader("content-disposition", "attachment; filename=" + fileName + "." + "RTF");
        //String encodedImgData = Convert.ToBase64String(bytes);

        //Response.Write(String.Format(encodedImgData)); // create the file
        //Response.Flush(); // send it to the client to download
        Response.OutputStream.Flush();

        Response.OutputStream.Close();

        Response.Flush();

        Response.Close();

        
    }   
}