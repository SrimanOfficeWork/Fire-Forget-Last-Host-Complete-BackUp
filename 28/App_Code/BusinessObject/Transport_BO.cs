using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
namespace BussinessObject
{
    public class Transport_BO
    {
        public Transport_BO()
        {
            // TODO: Add constructor logic here
        }

        private string _startRowIndex, _maximumRows, _totalRows, _Flag;
        public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
        public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
        public string totalRows { get { return _totalRows; } set { _totalRows = value; } }
        public string Flag { get { return _Flag; } set { _Flag = value; } }
        
        private String _Xml_D;        
        public string Xml_D { get { return _Xml_D; } set { _Xml_D = value; } }


        #region    TRANSPORT_BILLING_PURPOSE

        private string _ID, _BILL_INV_NO, _BILL_INV_DATE, _DESTINATION_FROM, _BILLFROM_NAME, _BILLFROM_ADDRESS,_BILLTO_NAME,_BILLTO_ADDRESS,_REMARKS, _BRANCH_CODE,
            _WORKINGPERIOD,_CREATEDON,_CREATEDBY,_MODIFIEDBY,_MODIFIEDON,_BRANCH_NO,_BRANCH_NO_LOC,_JOB_WORKINGPERIOD,_DESTINATION_TO,_BILLFROM_BRANCH_NO,
            _BILLFROM_BRANCH_NO_LOC,_BILLFROM_STATE_NAME,_BILLFROM_GSTN_ID,_BILLTO_BRANCH_NO,_BILLTO_BRANCH_NO_LOC,_BILLTO_STATE_NAME,_BILLTO_GSTN_ID,_HSN_SACODE,_ACCOUNTS_TYPE,_BILL_TYPE,
            _INV_TYPE, _MAIN_TAX_NONTAX, _RCM_YN, _TOTAL_AMT, _NON_TAXABLE_AMT, _TAXABLE_AMT, _MAIN_CGST_RATE, _MAIN_CGST_AMT, _MAIN_SGST_RATE, _MAIN_SGST_AMT,
            _MAIN_IGST_RATE, _MAIN_IGST_AMT, _RCM_AMT, _TOTAL_BILL_AMT, _TOTAL_BILL_WORD, _ADVANCE_AMT, _BALANCE_AMT,
            _MARKET_CGST_RATE, _MARKET_SGST_RATE, _MARKET_IGST_RATE, _BILLTO_CODE, _BILLTO_RNO, _BILL_RNO, _FINYEAR_CODE, _AC_NAME, _BRANCH, _MODEL_BULK_CONTAINER, _MINIMUM_QTY, _Round_off;

        public string ID { get { return _ID; } set { _ID = value; } }
        public string BILL_INV_NO { get { return _BILL_INV_NO; } set { _BILL_INV_NO = value; } }
        public string BILL_INV_DATE { get { return _BILL_INV_DATE; } set { _BILL_INV_DATE = value; } }
        public string DESTINATION_FROM { get { return _DESTINATION_FROM; } set { _DESTINATION_FROM = value; } }
        public string BILLFROM_NAME { get { return _BILLFROM_NAME; } set { _BILLFROM_NAME = value; } }
        public string BILLFROM_ADDRESS { get { return _BILLFROM_ADDRESS; } set { _BILLFROM_ADDRESS = value; } }
        public string BILLTO_NAME { get { return _BILLTO_NAME; } set { _BILLTO_NAME = value; } }
        public string BILLTO_ADDRESS { get { return _BILLTO_ADDRESS; } set { _BILLTO_ADDRESS = value; } }
        public string REMARKS { get { return _REMARKS; } set { _REMARKS = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }

        public string WORKINGPERIOD { get { return _WORKINGPERIOD; } set { _WORKINGPERIOD = value; } }
        public string CREATEDON { get { return _CREATEDON; } set { _CREATEDON = value; } }
        public string CREATEDBY { get { return _CREATEDBY; } set { _CREATEDBY = value; } }
        public string MODIFIEDBY { get { return _MODIFIEDBY; } set { _MODIFIEDBY = value; } }
        public string MODIFIEDON { get { return _MODIFIEDON; } set { _MODIFIEDON = value; } }
        public string BRANCH_NO { get { return _BRANCH_NO; } set { _BRANCH_NO = value; } }
        public string BRANCH_NO_LOC { get { return _BRANCH_NO_LOC; } set { _BRANCH_NO_LOC = value; } }
        public string JOB_WORKINGPERIOD { get { return _JOB_WORKINGPERIOD; } set { _JOB_WORKINGPERIOD = value; } }
        public string DESTINATION_TO { get { return _DESTINATION_TO; } set { _DESTINATION_TO = value; } }
        public string BILLFROM_BRANCH_NO { get { return _BILLFROM_BRANCH_NO; } set { _BILLFROM_BRANCH_NO = value; } }


        public string BILLFROM_BRANCH_NO_LOC { get { return _BILLFROM_BRANCH_NO_LOC; } set { _BILLFROM_BRANCH_NO_LOC = value; } }
        public string BILLFROM_STATE_NAME { get { return _BILLFROM_STATE_NAME; } set { _BILLFROM_STATE_NAME = value; } }
        public string BILLFROM_GSTN_ID { get { return _BILLFROM_GSTN_ID; } set { _BILLFROM_GSTN_ID = value; } }
        public string BILLTO_BRANCH_NO { get { return _BILLTO_BRANCH_NO; } set { _BILLTO_BRANCH_NO = value; } }
        public string BILLTO_BRANCH_NO_LOC { get { return _BILLTO_BRANCH_NO_LOC; } set { _BILLTO_BRANCH_NO_LOC = value; } }
        public string BILLTO_STATE_NAME { get { return _BILLTO_STATE_NAME; } set { _BILLTO_STATE_NAME = value; } }
        public string BILLTO_GSTN_ID { get { return _BILLTO_GSTN_ID; } set { _BILLTO_GSTN_ID = value; } }
        public string HSN_SACODE { get { return _HSN_SACODE; } set { _HSN_SACODE = value; } }
        public string ACCOUNTS_TYPE { get { return _ACCOUNTS_TYPE; } set { _ACCOUNTS_TYPE = value; } }
        public string BILL_TYPE { get { return _BILL_TYPE; } set { _BILL_TYPE = value; } }


        
        public string INV_TYPE { get { return _INV_TYPE; } set { _INV_TYPE = value; } }
        public string MAIN_TAX_NONTAX { get { return _MAIN_TAX_NONTAX; } set { _MAIN_TAX_NONTAX = value; } }
        public string RCM_YN { get { return _RCM_YN; } set { _RCM_YN = value; } }
        public string TOTAL_AMT { get { return _TOTAL_AMT; } set { _TOTAL_AMT = value; } }
        public string NON_TAXABLE_AMT { get { return _NON_TAXABLE_AMT; } set { _NON_TAXABLE_AMT = value; } }
        public string TAXABLE_AMT { get { return _TAXABLE_AMT; } set { _TAXABLE_AMT = value; } }
        public string MAIN_CGST_RATE { get { return _MAIN_CGST_RATE; } set { _MAIN_CGST_RATE = value; } }
        public string MAIN_CGST_AMT { get { return _MAIN_CGST_AMT; } set { _MAIN_CGST_AMT = value; } }
        public string MAIN_SGST_RATE { get { return _MAIN_SGST_RATE; } set { _MAIN_SGST_RATE = value; } }
        public string MAIN_SGST_AMT { get { return _MAIN_SGST_AMT; } set { _MAIN_SGST_AMT = value; } }
        
        public string MAIN_IGST_RATE { get { return _MAIN_IGST_RATE; } set { _MAIN_IGST_RATE = value; } }
        public string MAIN_IGST_AMT { get { return _MAIN_IGST_AMT; } set { _MAIN_IGST_AMT = value; } }
        public string RCM_AMT { get { return _RCM_AMT; } set { _RCM_AMT = value; } }
        public string TOTAL_BILL_AMT { get { return _TOTAL_BILL_AMT; } set { _TOTAL_BILL_AMT = value; } }
        public string TOTAL_BILL_WORD { get { return _TOTAL_BILL_WORD; } set { _TOTAL_BILL_WORD = value; } }
        public string ADVANCE_AMT { get { return _ADVANCE_AMT; } set { _ADVANCE_AMT = value; } }
        public string BALANCE_AMT { get { return _BALANCE_AMT; } set { _BALANCE_AMT = value; } }

        public string MARKET_CGST_RATE { get { return _MARKET_CGST_RATE; } set { _MARKET_CGST_RATE = value; } }
        public string MARKET_SGST_RATE { get { return _MARKET_SGST_RATE; } set { _MARKET_SGST_RATE = value; } }
        public string MARKET_IGST_RATE { get { return _MARKET_IGST_RATE; } set { _MARKET_IGST_RATE = value; } }

        public string BILLTO_CODE  { get { return _BILLTO_CODE;  } set { _BILLTO_CODE = value; } }
        public string BILLTO_RNO   { get { return _BILLTO_RNO;   } set { _BILLTO_RNO = value; } }
        public string BILL_RNO     { get { return _BILL_RNO;     } set { _BILL_RNO = value; } }
        public string FINYEAR_CODE { get { return _FINYEAR_CODE; } set { _FINYEAR_CODE = value; } }
        public string AC_NAME { get { return _AC_NAME; } set { _AC_NAME = value; } }
        public string BRANCH { get { return _BRANCH; } set { _BRANCH = value; } }
        public string MODEL_BULK_CONTAINER { get { return _MODEL_BULK_CONTAINER; } set { _MODEL_BULK_CONTAINER = value; } }
        public string MINIMUM_QTY { get { return _MINIMUM_QTY; } set { _MINIMUM_QTY = value; } }
        public string Round_off { get { return _Round_off; } set { _Round_off = value; } }


        private string _INV_CHECK, _CHARGE_NAME, _TAX_NONTAX, _QTY, _CUR, _EX_RATE, _UNIT_RATE, _AMOUNT, _CGST_RATE, _CGST_AMT,
            _SGST_RATE,_SGST_AMT, _IGST_RATE, _IGST_AMT, _SA_CODE, _ORDERBY, _CHARGE_DESC, _DISCOUNT_RATE, _BILL_NO, _JOB_NO,
            _PO_NO, _CARGO, _SB_NO, _TYPE_CONT_GOODS, _LORRY_GATEPASS_NO, _VEHICLE_NO, _CONT_NO_BAGS, _LOAD_DATE, _UNLOAD_DATE;

        public string INV_CHECK { get { return _INV_CHECK; } set { _INV_CHECK = value; } }
        public string CHARGE_NAME { get { return _CHARGE_NAME; } set { _CHARGE_NAME = value; } }
        public string TAX_NONTAX { get { return _TAX_NONTAX; } set { _TAX_NONTAX = value; } }
        public string QTY { get { return _QTY; } set { _QTY = value; } }
        public string CUR { get { return _CUR; } set { _CUR = value; } }
        public string EX_RATE { get { return _EX_RATE; } set { _EX_RATE = value; } }
        public string UNIT_RATE { get { return _UNIT_RATE; } set { _UNIT_RATE = value; } }
        public string AMOUNT { get { return _AMOUNT; } set { _AMOUNT = value; } }
        public string CGST_RATE { get { return _CGST_RATE; } set { _CGST_RATE = value; } }
        public string CGST_AMT { get { return _CGST_AMT; } set { _CGST_AMT = value; } }
        
        public string SGST_RATE { get { return _SGST_RATE; } set { _SGST_RATE = value; } }
        public string SGST_AMT { get { return _SGST_AMT; } set { _SGST_AMT = value; } }
        public string IGST_RATE { get { return _IGST_RATE; } set { _IGST_RATE = value; } }
        public string IGST_AMT { get { return _IGST_AMT; } set { _IGST_AMT = value; } }
        public string SA_CODE { get { return _SA_CODE; } set { _SA_CODE = value; } }
        public string ORDERBY { get { return _ORDERBY; } set { _ORDERBY = value; } }
        public string CHARGE_DESC { get { return _CHARGE_DESC; } set { _CHARGE_DESC = value; } }
        public string DISCOUNT_RATE { get { return _DISCOUNT_RATE; } set { _DISCOUNT_RATE = value; } }
        public string BILL_NO { get { return _BILL_NO; } set { _BILL_NO = value; } }
        public string JOB_NO { get { return _JOB_NO; } set { _JOB_NO = value; } }        

        public string PO_NO { get { return _PO_NO; } set { _PO_NO = value; } }
        public string CARGO { get { return _CARGO; } set { _CARGO = value; } }
        public string SB_NO { get { return _SB_NO; } set { _SB_NO  = value; } }
        public string TYPE_CONT_GOODS { get { return _TYPE_CONT_GOODS ; } set { _TYPE_CONT_GOODS = value; } }
        public string LORRY_GATEPASS_NO { get { return _LORRY_GATEPASS_NO; } set { _LORRY_GATEPASS_NO = value; } }
        public string VEHICLE_NO { get { return _VEHICLE_NO; } set { _VEHICLE_NO = value; } }
        public string CONT_NO_BAGS { get { return _CONT_NO_BAGS; } set { _CONT_NO_BAGS = value; } }
        public string LOAD_DATE { get { return _LOAD_DATE; } set { _LOAD_DATE = value; } }
        public string UNLOAD_DATE { get { return _UNLOAD_DATE; } set { _UNLOAD_DATE = value; } }

        #endregion TRANSPORT_BILLING_PURPOSE
    }
}