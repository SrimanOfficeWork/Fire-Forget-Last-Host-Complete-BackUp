using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessObject
{
    public class Billing_UserBO
    {
        private string _ID, _JOBNO, _IMPORTER_NAME, _MODE, _BILL_INV_NO, _BILL_INV_DATE, _INV_NO, _INV_DATE, _BE_NO, _BE_DATE, _MBLNO,
        _HBLNO, _CONTAINER_NO, _NO_OF_PKG, _GROSS_WGT, _NET_WGT, _VOLUME, _VESSEL, _DESTINATION, _COMMODITY, _FREIGHT_STATUS, _AC_BEHALF, _SHIPPER_NAME, _SHIPPER_ADDRESS,
        _CONSIGNEE_NAME, _CONSIGNEE_ADDRESS, _NOTIFY_PARTY_1, _NOTIFY_PARTY_1_ADDRESS, _NOTIFY_PARTY_2, _NOTIFY_PARTY_2_ADDRESS, _REMARKS, _NON_TAXABLE_AMT, _TAXABLE_AMT,
        _TOTAL_TAX_AMT, _TOTAL_AMT_TAX, _Imp_Name, _Flag, _from_date, _todate, _JOBDATE, _Tax_Mode, _Bill_No, _Ass_Value, _COMPANY_LICENSE, _FILE_REF_NO,
        _CHARGE_WGT, _CHARGE_TYPE, _BILL_TYPE, _ADVANCE_AMT, _State_Name, _GSTN_ID, _Sp_Name, _Party_Ref, _Duty_Value, _CHARGE_NAME, _MAWB_DATE, _ETA_DATE,
        _STUFFING_DATE, _STUFFING_PLACE, _VENDOR_CODE, _EXPENSE_AMT, _JOB_STATUS, _UNAPPROVAL_APPROVED, _COUNTRY_SHIPMENT, _PORT_SHIPMENT, _TR_DETAILS,
        _TAX_NONTAX, _CFS_CHARGE, _ATTACHMENT_DET, _PO_NO, _LCL_FCL, _TWENTY_FEET_CNT, _FORTY_FEET_CNT, _INV_TYPE,
        _JOB_WORKINGPERIOD, _BASED_ON, _SEARCH_CONTENT, _BRANCHSLNO, _TERMS, _DEFAULT_CUR, _LCL, _FCL_20_FT, _FCL_40_FT, _BOND_EX_BOND_BULK,
        _PER_VALUE, _MIN_AMT, _MAX_AMT, _Order_by, _Q_Id, _Party_ID, _Imp_Exp, _Charge_Id, _QC_Id, _Local_Other, _SEZ_Area


        ,_LCL_AMT,_FCL_20_FT_AMT,_FCL_40_FT_AMT,_BOND_AMT,_AIR_AMT
        ,_LCL_BASED_ON, _FCL_20_FT_BASED_ON, _FCL_40_FT_BASED_ON,_BOND_BASED_ON,_AIR_BASED_ON
        ,_LCL_P, _FCL_20_P, _FCL_40_P,_BOND_P, _AIR_P
        ,_LCL_MIN_AMT, _FCL_20_MIN_AMT, _FCL_40_MIN_AMT,_BOND_MIN_AMT, _AIR_MIN_AMT
        ,_LCL_MAX_AMT, _FCL_20_MAX_AMT, _FCL_40_MAX_AMT,_BOND_MAX_AMT, _AIR_MAX_AMT
        , _Expense_Select_Flag, _Expense_Imp_Exp, _Expense_Tr_Mode, _Expense_Party_Name, _Expense_Ledger_Name, _Expense_Job_Number,
         _A201, _A202, _A203, _A204, _A205, _A206, _A207, _A208, _A209, _A210, _A211, _A212, _A213, _A214, _A9, _A1,_A2,_A6,_A7,_A8,_A10,_A11,_A12;

        public string Expense_Select_Flag { get { return _Expense_Select_Flag; } set { _Expense_Select_Flag = value; } }
        public string Expense_Imp_Exp { get { return _Expense_Imp_Exp; } set { _Expense_Imp_Exp = value; } }
        public string Expense_Tr_Mode { get { return _Expense_Tr_Mode; } set { _Expense_Tr_Mode = value; } }
        public string Expense_Party_Name { get { return _Expense_Party_Name; } set { _Expense_Party_Name = value; } }
        public string Expense_Ledger_Name { get { return _Expense_Ledger_Name; } set { _Expense_Ledger_Name = value; } }
        public string Expense_Job_Number { get { return _Expense_Job_Number; } set { _Expense_Job_Number = value; } }
        public string A201 { get { return _A201; } set { _A201 = value; } }
        public string A202 { get { return _A202; } set { _A202 = value; } }
        public string A203 { get { return _A203; } set { _A203 = value; } }
        public string A204 { get { return _A204; } set { _A204 = value; } }
        public string A205 { get { return _A205; } set { _A205 = value; } }
        public string A206 { get { return _A206; } set { _A206 = value; } }
        public string A207 { get { return _A207; } set { _A207 = value; } }
        public string A208 { get { return _A208; } set { _A208 = value; } }
        public string A209 { get { return _A209; } set { _A209 = value; } }
        public string A210 { get { return _A210; } set { _A210 = value; } }
        public string A211 { get { return _A211; } set { _A211 = value; } }
        public string A212 { get { return _A212; } set { _A212 = value; } }
        public string A213 { get { return _A213; } set { _A213 = value; } }
        public string A214 { get { return _A214; } set { _A214 = value; } }
        public string A1 { get { return _A1; } set { _A1 = value; } }
        public string A2 { get { return _A2; } set { _A2 = value; } }
        public string A6 { get { return _A6; } set { _A6 = value; } }
        public string A7 { get { return _A7; } set { _A7 = value; } }
        public string A8 { get { return _A8; } set { _A8 = value; } }
        public string A9 { get { return _A9; } set { _A9 = value; } }
        public string A10 { get { return _A10; } set { _A10 = value; } }
        public string A11 { get { return _A11; } set { _A11 = value; } }
        public string A12 { get { return _A12; } set { _A12 = value; } }
            
        public string LCL_AMT { get { return _LCL_AMT; } set { _LCL_AMT = value; } }
        public string FCL_20_FT_AMT { get { return _FCL_20_FT_AMT; } set { _FCL_20_FT_AMT = value; } }
        public string FCL_40_FT_AMT { get { return _FCL_40_FT_AMT; } set { _FCL_40_FT_AMT = value; } }
        public string AIR_AMT { get { return _AIR_AMT; } set { _AIR_AMT = value; } }
        public string BOND_AMT { get { return _BOND_AMT; } set { _BOND_AMT = value; } }

        public string LCL_BASED_ON { get { return _LCL_BASED_ON; } set { _LCL_BASED_ON = value; } }
        public string FCL_20_FT_BASED_ON { get { return _FCL_20_FT_BASED_ON; } set { _FCL_20_FT_BASED_ON = value; } }
        public string FCL_40_FT_BASED_ON { get { return _FCL_40_FT_BASED_ON; } set { _FCL_40_FT_BASED_ON = value; } }
        public string AIR_BASED_ON { get { return _AIR_BASED_ON; } set { _AIR_BASED_ON = value; } }
        public string BOND_BASED_ON { get { return _BOND_BASED_ON; } set { _BOND_BASED_ON = value; } }

        public string LCL_P { get { return _LCL_P; } set { _LCL_P = value; } }
        public string FCL_20_P { get { return _FCL_20_P; } set { _FCL_20_P = value; } }
        public string FCL_40_P { get { return _FCL_40_P; } set { _FCL_40_P = value; } }
        public string AIR_P { get { return _AIR_P; } set { _AIR_P = value; } }
        public string BOND_P { get { return _BOND_P; } set { _BOND_P = value; } }

        public string LCL_MIN_AMT { get { return _LCL_MIN_AMT; } set { _LCL_MIN_AMT = value; } }
        public string FCL_20_MIN_AMT { get { return _FCL_20_MIN_AMT; } set { _FCL_20_MIN_AMT = value; } }
        public string FCL_40_MIN_AMT { get { return _FCL_40_MIN_AMT; } set { _FCL_40_MIN_AMT = value; } }
        public string AIR_MIN_AMT { get { return _AIR_MIN_AMT; } set { _AIR_MIN_AMT = value; } }
        public string BOND_MIN_AMT { get { return _BOND_MIN_AMT; } set { _BOND_MIN_AMT = value; } }

        public string LCL_MAX_AMT { get { return _LCL_MAX_AMT; } set { _LCL_MAX_AMT = value; } }
        public string FCL_20_MAX_AMT { get { return _FCL_20_MAX_AMT; } set { _FCL_20_MAX_AMT = value; } }
        public string FCL_40_MAX_AMT { get { return _FCL_40_MAX_AMT; } set { _FCL_40_MAX_AMT = value; } }
        public string AIR_MAX_AMT { get { return _AIR_MAX_AMT; } set { _AIR_MAX_AMT = value; } }
        public string BOND_MAX_AMT { get { return _BOND_MAX_AMT; } set { _BOND_MAX_AMT = value; } }

        public string LCL { get { return _LCL; } set { _LCL = value; } }
        public string FCL_20_FT { get { return _FCL_20_FT; } set { _FCL_20_FT = value; } }
        public string FCL_40_FT { get { return _FCL_40_FT; } set { _FCL_40_FT = value; } }


        public string BOND_EX_BOND_BULK { get { return _BOND_EX_BOND_BULK; } set { _BOND_EX_BOND_BULK = value; } }
        public string PER_VALUE { get { return _PER_VALUE; } set { _PER_VALUE = value; } }
        public string MIN_AMT { get { return _MIN_AMT; } set { _MIN_AMT = value; } }
        public string MAX_AMT { get { return _MAX_AMT; } set { _MAX_AMT = value; } }
        public string Order_by { get { return _Order_by; } set { _Order_by = value; } }
        public string Q_Id { get { return _Q_Id; } set { _Q_Id = value; } }
        public string Party_ID { get { return _Party_ID; } set { _Party_ID = value; } }
        public string Imp_Exp { get { return _Imp_Exp; } set { _Imp_Exp = value; } }
        public string Charge_Id { get { return _Charge_Id; } set { _Charge_Id = value; } }
        public string QC_Id { get { return _QC_Id; } set { _QC_Id = value; } }

        private string _startRowIndex, _maximumRows, _totalRows;

        public string TERMS { get { return _TERMS; } set { _TERMS = value; } }
        public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
        public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
        public string totalRows { get { return _totalRows; } set { _totalRows = value; } }

        private String _Xml_D;
       
        public string Xml_D { get { return _Xml_D; } set { _Xml_D = value; } }
        public string BILL_TYPE { get { return _BILL_TYPE; } set { _BILL_TYPE = value; } }

        public string JOBDATE { get { return _JOBDATE; } set { _JOBDATE = value; } }
        public string Tax_Mode { get { return _Tax_Mode; } set { _Tax_Mode = value; } }
        public string Bill_No { get { return _Bill_No; } set { _Bill_No = value; } }
        public string from_date { get { return _from_date; } set { _from_date = value; } }
        public string todate { get { return _todate; } set { _todate = value; } }
        
        public string ID { get { return _ID; } set { _ID = value; } }
        public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
        public string IMPORTER_NAME { get { return _IMPORTER_NAME; } set { _IMPORTER_NAME = value; } }
        public string MODE { get { return _MODE; } set { _MODE = value; } }

        public string Local_Other { get { return _Local_Other; } set { _Local_Other = value; } }
        public string SEZ_Area { get { return _SEZ_Area; } set { _SEZ_Area = value; } }

        public string BILL_INV_NO { get { return _BILL_INV_NO; } set { _BILL_INV_NO = value; } }
        public string BILL_INV_DATE { get { return _BILL_INV_DATE; } set { _BILL_INV_DATE = value; } }
       
        public string INV_NO { get { return _INV_NO; } set { _INV_NO = value; } }
        public string INV_DATE { get { return _INV_DATE; } set { _INV_DATE = value; } }
        public string BE_NO { get { return _BE_NO; } set { _BE_NO = value; } }
        public string BE_DATE { get { return _BE_DATE; } set { _BE_DATE = value; } }

        public string MBLNO { get { return _MBLNO; } set { _MBLNO = value; } }
        public string HBLNO { get { return _HBLNO; } set { _HBLNO = value; } }
        public string CONTAINER_NO { get { return _CONTAINER_NO; } set { _CONTAINER_NO = value; } }
        public string NO_OF_PKG { get { return _NO_OF_PKG; } set { _NO_OF_PKG = value; } }
        public string GROSS_WGT { get { return _GROSS_WGT; } set { _GROSS_WGT = value; } }
        public string NET_WGT { get { return _NET_WGT; } set { _NET_WGT = value; } }
        public string VOLUME { get { return _VOLUME; } set { _VOLUME = value; } }
        public string VESSEL { get { return _VESSEL; } set { _VESSEL = value; } }

        public string DESTINATION { get { return _DESTINATION; } set { _DESTINATION = value; } }
        public string COMMODITY { get { return _COMMODITY; } set { _COMMODITY = value; } }
        public string FREIGHT_STATUS { get { return _FREIGHT_STATUS; } set { _FREIGHT_STATUS = value; } }
        public string AC_BEHALF { get { return _AC_BEHALF; } set { _AC_BEHALF = value; } }
        public string SHIPPER_NAME { get { return _SHIPPER_NAME; } set { _SHIPPER_NAME = value; } }

        public string SHIPPER_ADDRESS { get { return _SHIPPER_ADDRESS; } set { _SHIPPER_ADDRESS = value; } }
        public string CONSIGNEE_NAME { get { return _CONSIGNEE_NAME; } set { _CONSIGNEE_NAME = value; } }
        public string CONSIGNEE_ADDRESS { get { return _CONSIGNEE_ADDRESS; } set { _CONSIGNEE_ADDRESS = value; } }
        public string NOTIFY_PARTY_1 { get { return _NOTIFY_PARTY_1; } set { _NOTIFY_PARTY_1 = value; } }
        public string NOTIFY_PARTY_1_ADDRESS { get { return _NOTIFY_PARTY_1_ADDRESS; } set { _NOTIFY_PARTY_1_ADDRESS = value; } }
        public string NOTIFY_PARTY_2 { get { return _NOTIFY_PARTY_2; } set { _NOTIFY_PARTY_2 = value; } }
        public string NOTIFY_PARTY_2_ADDRESS { get { return _NOTIFY_PARTY_2_ADDRESS; } set { _NOTIFY_PARTY_2_ADDRESS = value; } }
        public string REMARKS { get { return _REMARKS; } set { _REMARKS = value; } }

        public string NON_TAXABLE_AMT { get { return _NON_TAXABLE_AMT; } set { _NON_TAXABLE_AMT = value; } }
        public string TAXABLE_AMT { get { return _TAXABLE_AMT; } set { _TAXABLE_AMT = value; } }
        public string TOTAL_TAX_AMT { get { return _TOTAL_TAX_AMT; } set { _TOTAL_TAX_AMT = value; } }
        public string TOTAL_AMT_TAX { get { return _TOTAL_AMT_TAX; } set { _TOTAL_AMT_TAX = value; } }
        public string Flag { get { return _Flag; } set { _Flag = value; } }
        public string Imp_Name { get { return _Imp_Name; } set { _Imp_Name = value; } }


        public string FILE_REF_NO { get { return _FILE_REF_NO; } set { _FILE_REF_NO = value; } }
        public string CHARGE_TYPE { get { return _CHARGE_TYPE; } set { _CHARGE_TYPE = value; } }
        public string CHARGE_WGT { get { return _CHARGE_WGT; } set { _CHARGE_WGT = value; } }

        public string Ass_Value { get { return _Ass_Value; } set { _Ass_Value = value; } }
        public string ADVANCE_AMT { get { return _ADVANCE_AMT; } set { _ADVANCE_AMT = value; } }

        public string JOB_WORKINGPERIOD { get { return _JOB_WORKINGPERIOD; } set { _JOB_WORKINGPERIOD = value; } }
        public string DEFAULT_CUR { get { return _DEFAULT_CUR; } set { _DEFAULT_CUR = value; } }

        private string _Exp_Name, _FOB_Value, _MAWB_NO, _HAWB_NO, _SB_DATE, _SB_NO;

        
        private string _Exp_SubID, _Exp_Details, _Ref_VoucherNo, _Exp_Amount, _PaymentMode, _Remarks, _GivenBy, _Assignee, _PAID_ON, _STAFF_NAME, _FILE_IMAGE_NAME
            , _FILE_PATH, _ATTACHMENT_FILE, _GSTR1_OFFLINE, _ONE_JOB_ONE_BILL
            , _VENDOR_BRANCH, _VENDOR_GSTIN, _CR_DR, _EX_RATE, _CURRENCY, _FOREIGN_AMOUNT, _CLASSIFY_TYPE, _TAXABLE_AMOUNT, _CGST_PERCENTAGE, _CGST_AMOUNT, _SGST_PERCENTAGE, _SGST_AMOUNT, _IGST_PERCENTAGE, _IGST_AMOUNT, _STAFF_NAME_MAIN, _EXPENSE_HEAD, _GENERAL, _JOB_INFO;

        public string Exp_Name { get { return _Exp_Name; } set { _Exp_Name = value; } }
        public string FOB_Value { get { return _FOB_Value; } set { _FOB_Value = value; } }
        public string MAWB_NO { get { return _MAWB_NO; } set { _MAWB_NO = value; } }
        public string HAWB_NO { get { return _HAWB_NO; } set { _HAWB_NO = value; } }
        public string SB_DATE { get { return _SB_DATE; } set { _SB_DATE = value; } }
        public string SB_NO { get { return _SB_NO; } set { _SB_NO = value; } }
        public string State_Name { get { return _State_Name; } set { _State_Name = value; } }
        public string GSTN_ID { get { return _GSTN_ID; } set { _GSTN_ID = value; } }
        public string Sp_Name { get { return _Sp_Name; } set { _Sp_Name = value; } }
        public string Party_Ref { get { return _Party_Ref; } set { _Party_Ref = value; } }
        public string Duty_Value { get { return _Duty_Value; } set { _Duty_Value = value; } }
        public string CHARGE_NAME { get { return _CHARGE_NAME; } set { _CHARGE_NAME = value; } }

        private string _CH_DESCRIPTION, _HSN_CODE, _SA_CODE, _ALLOW_QUOTATION;

        public string CH_DESCRIPTION { get { return _CH_DESCRIPTION; } set { _CH_DESCRIPTION = value; } }
        public string HSN_CODE { get { return _HSN_CODE; } set { _HSN_CODE = value; } }
        public string SA_CODE { get { return _SA_CODE; } set { _SA_CODE = value; } }
        public string ALLOW_QUOTATION { get { return _ALLOW_QUOTATION; } set { _ALLOW_QUOTATION = value; } }

        private string _HBL_NO_DATE, _MBL_NO_DATE, _FLIGHT_ARAIVAL_DATE, _CONTAINER_SIZE, _BOND_NO, _BOND_DATE, _TOT_REVERSE_TAX_AMT, _FROM_QUOTATION;

        public string HBL_NO_DATE { get { return _HBL_NO_DATE; } set { _HBL_NO_DATE = value; } }
        public string MBL_NO_DATE { get { return _MBL_NO_DATE; } set { _MBL_NO_DATE = value; } }
        public string FLIGHT_ARAIVAL_DATE { get { return _FLIGHT_ARAIVAL_DATE; } set { _FLIGHT_ARAIVAL_DATE = value; } }
        public string CONTAINER_SIZE { get { return _CONTAINER_SIZE; } set { _CONTAINER_SIZE = value; } }
        public string BOND_NO { get { return _BOND_NO; } set { _BOND_NO = value; } }
        public string BOND_DATE { get { return _BOND_DATE; } set { _BOND_DATE = value; } }
        public string TOT_REVERSE_TAX_AMT { get { return _TOT_REVERSE_TAX_AMT; } set { _TOT_REVERSE_TAX_AMT = value; } }
        public string FROM_QUOTATION { get { return _FROM_QUOTATION; } set { _FROM_QUOTATION = value; } }
        
        private string _TYPE_OF_INVOICE, _YOUR_REF, _NO_OF_PKG_TYPE, _GROSS_WGT_TYPE, _NET_WGT_TYPE, _ITEM_DESC;

        public string TYPE_OF_INVOICE { get { return _TYPE_OF_INVOICE; } set { _TYPE_OF_INVOICE = value; } }
        public string YOUR_REF { get { return _YOUR_REF; } set { _YOUR_REF = value; } }
        public string NO_OF_PKG_TYPE { get { return _NO_OF_PKG_TYPE; } set { _NO_OF_PKG_TYPE = value; } }
        public string GROSS_WGT_TYPE { get { return _GROSS_WGT_TYPE; } set { _GROSS_WGT_TYPE = value; } }
        public string NET_WGT_TYPE { get { return _NET_WGT_TYPE; } set { _NET_WGT_TYPE = value; } }
        public string ITEM_DESC { get { return _ITEM_DESC; } set { _ITEM_DESC = value; } }

        private string _BranchCode;
        public string BranchCode { get { return _BranchCode; } set { _BranchCode = value; } }

        public string MAWB_DATE { get { return _MAWB_DATE; } set { _MAWB_DATE = value; } }
        public string ETA_DATE { get { return _ETA_DATE; } set { _ETA_DATE = value; } }


        private string _Ref_ID, _CGST_RATE, _SGST_RATE, _IGST_RATE, _SHIPMENT_TYPE, _Branch_No, _Branch_No_Loc, _CIF_VALUE;
        public string Ref_ID { get { return _Ref_ID; } set { _Ref_ID = value; } }

        public string CGST_RATE { get { return _CGST_RATE; } set { _CGST_RATE = value; } }
        public string SGST_RATE { get { return _SGST_RATE; } set { _SGST_RATE = value; } }
        public string IGST_RATE { get { return _IGST_RATE; } set { _IGST_RATE = value; } }
        public string SHIPMENT_TYPE { get { return _SHIPMENT_TYPE; } set { _SHIPMENT_TYPE = value; } }
        public string Branch_No { get { return _Branch_No; } set { _Branch_No = value; } }
        public string Branch_No_Loc { get { return _Branch_No_Loc; } set { _Branch_No_Loc = value; } }

        public string CIF_VALUE { get { return _CIF_VALUE; } set { _CIF_VALUE = value; } }

        public string STUFFING_DATE { get { return _STUFFING_DATE; } set { _STUFFING_DATE = value; } }
        public string STUFFING_PLACE { get { return _STUFFING_PLACE; } set { _STUFFING_PLACE = value; } }
        public string VENDOR_CODE { get { return _VENDOR_CODE; } set { _VENDOR_CODE = value; } }
        public string EXPENSE_AMT { get { return _EXPENSE_AMT; } set { _EXPENSE_AMT = value; } }

        public string JOB_STATUS { get { return _JOB_STATUS; } set { _JOB_STATUS = value; } }
        public string UNAPPROVAL_APPROVED { get { return _UNAPPROVAL_APPROVED; } set { _UNAPPROVAL_APPROVED = value; } }

        public string COUNTRY_SHIPMENT { get { return _COUNTRY_SHIPMENT; } set { _COUNTRY_SHIPMENT = value; } }
        public string PORT_SHIPMENT { get { return _PORT_SHIPMENT; } set { _PORT_SHIPMENT = value; } }
        public string TR_DETAILS { get { return _TR_DETAILS; } set { _TR_DETAILS = value; } }
        public string TAX_NONTAX { get { return _TAX_NONTAX; } set { _TAX_NONTAX = value; } }

        public string CFS_CHARGE { get { return _CFS_CHARGE; } set { _CFS_CHARGE = value; } }
        public string ATTACHMENT_DET { get { return _ATTACHMENT_DET; } set { _ATTACHMENT_DET = value; } }
        public string PO_NO { get { return _PO_NO; } set { _PO_NO = value; } }

        public string LCL_FCL { get { return _LCL_FCL; } set { _LCL_FCL = value; } }
        public string TWENTY_FEET_CNT { get { return _TWENTY_FEET_CNT; } set { _TWENTY_FEET_CNT = value; } }
        public string FORTY_FEET_CNT { get { return _FORTY_FEET_CNT; } set { _FORTY_FEET_CNT = value; } }

        public string INV_TYPE { get { return _INV_TYPE; } set { _INV_TYPE = value; } }

        public string BASED_ON { get { return _BASED_ON; } set { _BASED_ON = value; } }
        public string SEARCH_CONTENT { get { return _SEARCH_CONTENT; } set { _SEARCH_CONTENT = value; } }
        public string BRANCHSLNO { get { return _BRANCHSLNO; } set { _BRANCHSLNO = value; } }

        public string STAFF_NAME_MAIN { get { return _STAFF_NAME_MAIN; } set { _STAFF_NAME_MAIN = value; } }
        public string EXPENSE_HEAD { get { return _EXPENSE_HEAD; } set { _EXPENSE_HEAD = value; } }
        public string GENERAL { get { return _GENERAL; } set { _GENERAL = value; } }
        public string JOB_INFO { get { return _JOB_INFO; } set { _JOB_INFO = value; } }


        public string Exp_SubID { get { return _Exp_SubID; } set { _Exp_SubID = value; } }
        public string Exp_Details { get { return _Exp_Details; } set { _Exp_Details = value; } }
        public string Ref_VoucherNo { get { return _Ref_VoucherNo; } set { _Ref_VoucherNo = value; } }
        public string Exp_Amount { get { return _Exp_Amount; } set { _Exp_Amount = value; } }
        public string PaymentMode { get { return _PaymentMode; } set { _PaymentMode = value; } }
        public string Remarks { get { return _Remarks; } set { _Remarks = value; } }
        public string GivenBy { get { return _GivenBy; } set { _GivenBy = value; } }
        public string Assignee { get { return _Assignee; } set { _Assignee = value; } }
        public string PAID_ON { get { return _PAID_ON; } set { _PAID_ON = value; } }
        public string STAFF_NAME { get { return _STAFF_NAME; } set { _STAFF_NAME = value; } }
        public string FILE_IMAGE_NAME { get { return _FILE_IMAGE_NAME; } set { _FILE_IMAGE_NAME = value; } }
        public string FILE_PATH { get { return _FILE_PATH; } set { _FILE_PATH = value; } }
        public string ATTACHMENT_FILE { get { return _ATTACHMENT_FILE; } set { _ATTACHMENT_FILE = value; } }

        public string VENDOR_BRANCH { get { return _VENDOR_BRANCH; } set { _VENDOR_BRANCH = value; } }
        public string VENDOR_GSTIN { get { return _VENDOR_GSTIN; } set { _VENDOR_GSTIN = value; } }
        public string CR_DR { get { return _CR_DR; } set { _CR_DR = value; } }
        public string EX_RATE { get { return _EX_RATE; } set { _EX_RATE = value; } }
        public string CURRENCY { get { return _CURRENCY; } set { _CURRENCY = value; } }
        public string FOREIGN_AMOUNT { get { return _FOREIGN_AMOUNT; } set { _FOREIGN_AMOUNT = value; } }
        public string CLASSIFY_TYPE { get { return _CLASSIFY_TYPE; } set { _CLASSIFY_TYPE = value; } }
        public string TAXABLE_AMOUNT { get { return _TAXABLE_AMOUNT; } set { _TAXABLE_AMOUNT = value; } }
        public string CGST_PERCENTAGE { get { return _CGST_PERCENTAGE; } set { _CGST_PERCENTAGE = value; } }
        public string CGST_AMOUNT { get { return _CGST_AMOUNT; } set { _CGST_AMOUNT = value; } }
        public string SGST_PERCENTAGE { get { return _SGST_PERCENTAGE; } set { _SGST_PERCENTAGE = value; } }
        public string SGST_AMOUNT { get { return _SGST_AMOUNT; } set { _SGST_AMOUNT = value; } }
        public string IGST_PERCENTAGE { get { return _IGST_PERCENTAGE; } set { _IGST_PERCENTAGE = value; } }
        public string IGST_AMOUNT { get { return _IGST_AMOUNT; } set { _IGST_AMOUNT = value; } }

        #region ACCOUNTS_SETTINGS

        public string GSTR1_OFFLINE { get { return _GSTR1_OFFLINE; } set { _GSTR1_OFFLINE = value; } }
        public string ONE_JOB_ONE_BILL { get { return _ONE_JOB_ONE_BILL; } set { _ONE_JOB_ONE_BILL = value; } }

        #endregion ACCOUNTS_SETTINGS


        #region COVERING_LETTER
        private string _COVERING_NO;
        private string _DISPATCH_DATE;
        private string _ADD1;
        private string _ADD2;
        private string _ADD3;
        private string _ADD4;
        private string _SUBJECT;
        private string _BILL_INVOICE_NO;
        private string _BILL_INVOICE_DATE;
        private string _BILL_REMARKS;
        private string _TOTAL, _TYPE;
        private string _SCFS_BILL_NO, _ATTACHMENT, _SCFS_AMOUNT, _CFS_BILLNO;
        private string _From_date, _Todate, _SW_ID, _BRANCH_CODE, _WORKING_PERIOD, _BRANCH_COMMON, _flag, _USER_ID;
        private string _COVERING_PS;
        private string _REFNO,_INVOICE, _PACKINGLIST, _BILL_OF_ENTRY, _SHIPPING_BILL, _BILL_OF_LADING, _STPI_IMPORT, _PROCUREMENT_CERT, _CERTIFICATE_OF_ORIGIN,
                       _DUTY_PAID, _DO_RECEIPT, _EDI_COUPON_RECEIPT, _CFS_RECEIPT, _IAAI_RECEIPTNO, _ESCORT_CONVEYANCE, _TRANSPORT_BILL_NO, _VEHICLE_PASS,
                       _INSURANCE_CERTNO, _CE_CERTIFICATE_NO, _ANYOTHER_DOC;

        public string REFNO { get { return _REFNO; } set { _REFNO = value; } }
        public string INVOICE { get { return _INVOICE; } set { _INVOICE = value; } }
        public string PACKINGLIST { get { return _PACKINGLIST; } set { _PACKINGLIST = value; } }
        public string BILL_OF_ENTRY { get { return _BILL_OF_ENTRY; } set { _BILL_OF_ENTRY = value; } }
        public string SHIPPING_BILL { get { return _SHIPPING_BILL; } set { _SHIPPING_BILL = value; } }
        public string BILL_OF_LADING { get { return _BILL_OF_LADING; } set { _BILL_OF_LADING = value; } }
        public string STPI_IMPORT { get { return _STPI_IMPORT; } set { _STPI_IMPORT = value; } }
        public string PROCUREMENT_CERT { get { return _PROCUREMENT_CERT; } set { _PROCUREMENT_CERT = value; } }
        public string CERTIFICATE_OF_ORIGIN { get { return _CERTIFICATE_OF_ORIGIN; } set { _CERTIFICATE_OF_ORIGIN = value; } }
        public string DUTY_PAID { get { return _DUTY_PAID; } set { _DUTY_PAID = value; } }
        public string DO_RECEIPT { get { return _DO_RECEIPT; } set { _DO_RECEIPT = value; } }
        public string EDI_COUPON_RECEIPT { get { return _EDI_COUPON_RECEIPT; } set { _EDI_COUPON_RECEIPT = value; } }
        public string CFS_RECEIPT { get { return _CFS_RECEIPT; } set { _CFS_RECEIPT = value; } }
        public string IAAI_RECEIPTNO { get { return _IAAI_RECEIPTNO; } set { _IAAI_RECEIPTNO = value; } }
        public string ESCORT_CONVEYANCE { get { return _ESCORT_CONVEYANCE; } set { _ESCORT_CONVEYANCE = value; } }
        public string TRANSPORT_BILL_NO { get { return _TRANSPORT_BILL_NO; } set { _TRANSPORT_BILL_NO = value; } }
        public string VEHICLE_PASS { get { return _VEHICLE_PASS; } set { _VEHICLE_PASS = value; } }
        public string INSURANCE_CERTNO { get { return _INSURANCE_CERTNO; } set { _INSURANCE_CERTNO = value; } }
        public string CE_CERTIFICATE_NO { get { return _CE_CERTIFICATE_NO; } set { _CE_CERTIFICATE_NO = value; } }
        public string ANYOTHER_DOC { get { return _ANYOTHER_DOC; } set { _ANYOTHER_DOC = value; } }
        

        public string SW_ID { get { return _SW_ID; } set { _SW_ID = value; } }


        public string From_date { get { return _From_date; } set { _From_date = value; } }
        public string Todate { get { return _Todate; } set { _Todate = value; } }
        public string COVERING_NO { get { return _COVERING_NO; } set { _COVERING_NO = value; } }
        public string DISPATCH_DATE { get { return _DISPATCH_DATE; } set { _DISPATCH_DATE = value; } }
        public string ADD1 { get { return _ADD1; } set { _ADD1 = value; } }
        public string ADD2 { get { return _ADD2; } set { _ADD2 = value; } }
        public string ADD3 { get { return _ADD3; } set { _ADD3 = value; } }
        public string ADD4 { get { return _ADD4; } set { _ADD4 = value; } }
        public string SUBJECT { get { return _SUBJECT; } set { _SUBJECT = value; } }
        public string BILL_INVOICE_NO { get { return _BILL_INVOICE_NO; } set { _BILL_INVOICE_NO = value; } }
        public string BILL_INVOICE_DATE { get { return _BILL_INVOICE_DATE; } set { _BILL_INVOICE_DATE = value; } }
        public string BILL_REMARKS { get { return _BILL_REMARKS; } set { _BILL_REMARKS = value; } }
        public string TOTAL { get { return _TOTAL; } set { _TOTAL = value; } }
        public string TYPE { get { return _TYPE; } set { _TYPE = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
        public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }
        public string flag { get { return _flag; } set { _flag = value; } }
        public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
        public string SCFS_BILL_NO { get { return _SCFS_BILL_NO; } set { _SCFS_BILL_NO = value; } }
        public string ATTACHMENT { get { return _ATTACHMENT; } set { _ATTACHMENT = value; } }
        public string SCFS_AMOUNT { get { return _SCFS_AMOUNT; } set { _SCFS_AMOUNT = value; } }

        public string CFS_BILLNO { get { return _CFS_BILLNO; } set { _CFS_BILLNO = value; } }
        public string COVERING_PS { get { return _COVERING_PS; } set { _COVERING_PS = value; } }

        #endregion COVERING_LETTER

        // exp - payment
        private string _ExpVoucherNo;
        //private DataTable _dtBulkData;
        public string ExpVoucherNo { get { return _ExpVoucherNo; } set { _ExpVoucherNo = value; } }
        //public DataTable dtBulkData { get { return _dtBulkData; } set { dtBulkData = value; } }

        // Receipt Entry
        private string _ModeOfPay, _Chqno, _ChqDt, _BankName, _BankBranch;
        public string ModeOfPay { get { return _ModeOfPay; } set { _ModeOfPay = value; } }
        public string Chqno { get { return _Chqno; } set { _Chqno = value; } }
        public string ChqDt { get { return _ChqDt; } set { _ChqDt = value; } }
        public string BankName { get { return _BankName; } set { _BankName = value; } }
        public string BankBranch { get { return _BankBranch; } set { _BankBranch = value; } }


        private string _BankReceiptNo, _PaymentFor, _PaymentFrom, _CustBranch, _DepositedBank;
        public string BankReceiptNo { get { return _BankReceiptNo; } set { _BankReceiptNo = value; } }
        public string PaymentFor { get { return _PaymentFor; } set { _PaymentFor = value; } }
        public string PaymentFrom { get { return _PaymentFrom; } set { _PaymentFrom = value; } }
        public string CustBranch { get { return _CustBranch; } set { _CustBranch = value; } }
        public string DepositedBank { get { return _DepositedBank; } set { _DepositedBank = value; } }
        //ELAIYAA START FOR EXPENSE CHARGE MASTER
        private string _GROUP_NAME, _TDS_SECTION, _TDS_RATE, _ACTIVE, _NARRATION;

        public string GROUP_NAME { get { return _GROUP_NAME; } set { _GROUP_NAME = value; } }
        public string TDS_SECTION { get { return _TDS_SECTION; } set { _TDS_SECTION = value; } }
        public string TDS_RATE { get { return _TDS_RATE; } set { _TDS_RATE = value; } }
        public string ACTIVE { get { return _ACTIVE; } set { _ACTIVE = value; } }
        public string NARRATION { get { return _NARRATION; } set { _NARRATION = value; } }
        //ELAIYAA END FOR EXPENSE CHARGE MASTER

        #region VENDOR_MASTER_PURPOSE

        private string _VENDOR_ID, _VENDOR_SUBID, _VENDOR_NAME, _UserID, _EntryDt, _Modified_UserID, _ModifiedDt, _TAX_TYPE, _TAX_TYPE_ITC, _PAN_NO,
                                           _TAN_NO, _CIN_NO, _TDS_YES_NO, _EXEMPTION_YES_NO, _CERTIFICATE_NO,
                                           _VALID_FROM, _VALID_TO, _CREDIT_DAYS, _CREDIT_LIMITS, _OPENING_BALANCE,
                                           _REGISTERED_VENDOR_YES_NO, _FOREIGN_VENDOR_YES_NO, _COUNTRY_NAME, _ACTIVE_YES_NO, _EXEMPTION_VALUE, _ENAME, _XML_DETAIL;


        public string VENDOR_ID { get { return _VENDOR_ID; } set { _VENDOR_ID = value; } }
        public string VENDOR_NAME { get { return _VENDOR_NAME; } set { _VENDOR_NAME = value; } }
        public string VENDOR_SUBID { get { return _VENDOR_SUBID; } set { _VENDOR_SUBID = value; } }
        public string UserID { get { return _UserID; } set { _UserID = value; } }
        public string EntryDt { get { return _EntryDt; } set { _EntryDt = value; } }
        public string Modified_UserID { get { return _Modified_UserID; } set { _Modified_UserID = value; } }
        public string ModifiedDt { get { return _ModifiedDt; } set { _ModifiedDt = value; } }
        //public string EXEMPTION_YES_NO { get { return _EXEMPTION_YES_NO; } set { _EXEMPTION_YES_NO = value; } }
        public string TAX_TYPE { get { return _TAX_TYPE; } set { _TAX_TYPE = value; } }
        public string TAX_TYPE_ITC { get { return _TAX_TYPE_ITC; } set { _TAX_TYPE_ITC = value; } }
        public string PAN_NO { get { return _PAN_NO; } set { _PAN_NO = value; } }

        public string TAN_NO { get { return _TAN_NO; } set { _TAN_NO = value; } }
        public string CIN_NO { get { return _CIN_NO; } set { _CIN_NO = value; } }
        public string TDS_YES_NO { get { return _TDS_YES_NO; } set { _TDS_YES_NO = value; } }
        public string EXEMPTION_YES_NO { get { return _EXEMPTION_YES_NO; } set { _EXEMPTION_YES_NO = value; } }
        public string CERTIFICATE_NO { get { return _CERTIFICATE_NO; } set { _CERTIFICATE_NO = value; } }

        public string VALID_FROM { get { return _VALID_FROM; } set { _VALID_FROM = value; } }
        public string VALID_TO { get { return _VALID_TO; } set { _VALID_TO = value; } }
        public string CREDIT_DAYS { get { return _CREDIT_DAYS; } set { _CREDIT_DAYS = value; } }
        public string CREDIT_LIMITS { get { return _CREDIT_LIMITS; } set { _CREDIT_LIMITS = value; } }
        public string OPENING_BALANCE { get { return _OPENING_BALANCE; } set { _OPENING_BALANCE = value; } }


        public string REGISTERED_VENDOR_YES_NO { get { return _REGISTERED_VENDOR_YES_NO; } set { _REGISTERED_VENDOR_YES_NO = value; } }
        public string FOREIGN_VENDOR_YES_NO { get { return _FOREIGN_VENDOR_YES_NO; } set { _FOREIGN_VENDOR_YES_NO = value; } }
        public string COUNTRY_NAME { get { return _COUNTRY_NAME; } set { _COUNTRY_NAME = value; } }
        public string ACTIVE_YES_NO { get { return _ACTIVE_YES_NO; } set { _ACTIVE_YES_NO = value; } }
        public string EXEMPTION_VALUE { get { return _EXEMPTION_VALUE; } set { _EXEMPTION_VALUE = value; } }
        public string ENAME { get { return _ENAME; } set { _ENAME = value; } }
        public string XML_DETAIL { get { return _XML_DETAIL; } set { _XML_DETAIL = value; } }

        private string _BR_SL_NO, _BR_CODE_LOCATION, _BR_ADDRESS1, _BR_ADDRESS2, _BR_COUNTRY_NAME,
                       _BR_TAX_TYPE, _BR_TAX_TYPE_ITC, _BR_GSTIN_NO, _BR_STATE, _BR_PIN_CODE,
                       _BR_CONTACT_PERSON_NAME, _BR_CONTACT_PERSON_DESIGNATION, _BR_MOBILE_NO, _BR_EMAIL_ID, _BR_ACTIVE_YES_NO,
                       _BR_NARRATION;

        public string BR_SL_NO { get { return _BR_SL_NO; } set { _BR_SL_NO = value; } }
        public string BR_CODE_LOCATION { get { return _BR_CODE_LOCATION; } set { _BR_CODE_LOCATION = value; } }
        public string BR_ADDRESS1 { get { return _BR_ADDRESS1; } set { _BR_ADDRESS1 = value; } }
        public string BR_ADDRESS2 { get { return _BR_ADDRESS2; } set { _BR_ADDRESS2 = value; } }
        public string BR_COUNTRY_NAME { get { return _BR_COUNTRY_NAME; } set { _BR_COUNTRY_NAME = value; } }


        public string BR_TAX_TYPE { get { return _BR_TAX_TYPE; } set { _BR_TAX_TYPE = value; } }
        public string BR_TAX_TYPE_ITC { get { return BR_TAX_TYPE_ITC; } set { BR_TAX_TYPE_ITC = value; } }
        public string BR_GSTIN_NO { get { return _BR_GSTIN_NO; } set { _BR_GSTIN_NO = value; } }
        public string BR_STATE { get { return _BR_STATE; } set { _BR_STATE = value; } }
        public string BR_PIN_CODE { get { return _BR_PIN_CODE; } set { _BR_PIN_CODE = value; } }

        public string BR_CONTACT_PERSON_NAME { get { return _BR_CONTACT_PERSON_NAME; } set { _BR_CONTACT_PERSON_NAME = value; } }
        public string BR_CONTACT_PERSON_DESIGNATION { get { return _BR_CONTACT_PERSON_DESIGNATION; } set { _BR_CONTACT_PERSON_DESIGNATION = value; } }
        public string BR_MOBILE_NO { get { return _BR_MOBILE_NO; } set { _BR_MOBILE_NO = value; } }
        public string BR_EMAIL_ID { get { return _BR_EMAIL_ID; } set { _BR_EMAIL_ID = value; } }
        public string BR_ACTIVE_YES_NO { get { return _BR_ACTIVE_YES_NO; } set { _BR_ACTIVE_YES_NO = value; } }

        public string BR_NARRATION { get { return _BR_NARRATION; } set { _BR_NARRATION = value; } }




        #endregion VENDOR_MASTER_PURPOSE

        private string _VOUCHER_NO, _VOUCHER_DATE,  _VENDOR_STATE, _GSTN, _GSTN_TYPE, _COUNTRY, _VENDOR_BILL, _BILL_DATE, _BILL_AMOUNT, _AMT_IN_INR;
        public string VOUCHER_NO { get { return _VOUCHER_NO; } set { _VOUCHER_NO = value; } }
        public string VOUCHER_DATE { get { return _VOUCHER_DATE; } set { _VOUCHER_DATE = value; } }
        public string VENDOR_STATE { get { return _VENDOR_STATE; } set { _VENDOR_STATE = value; } }
        public string GSTN { get { return _GSTN; } set { _GSTN = value; } }
        public string GSTN_TYPE { get { return _GSTN_TYPE; } set { _GSTN_TYPE = value; } }
        public string COUNTRY { get { return _COUNTRY; } set { _COUNTRY = value; } }
        public string VENDOR_BILL { get { return _VENDOR_BILL; } set { _VENDOR_BILL = value; } }
        public string BILL_DATE { get { return _BILL_DATE; } set { _BILL_DATE = value; } }
        public string BILL_AMOUNT { get { return _BILL_AMOUNT; } set { _BILL_AMOUNT = value; } }      
        public string AMT_IN_INR { get { return _AMT_IN_INR; } set { _AMT_IN_INR = value; } }           
        private string _charge_id, _charge_name;
        public string charge_id { get { return _charge_id; } set { _charge_id = value; } }
        public string charge_name { get { return _charge_name; } set { _charge_name = value; } }

        //-----------------------------------JOURNAL ENTRY START------------------------------------------------//
        private string _JOURNAL_ID, _VOUCHER_TYPE;
        public string JOURNAL_ID { get { return _JOURNAL_ID; } set { _JOURNAL_ID = value; } }
        public string VOUCHER_TYPE { get { return _VOUCHER_TYPE; } set { _VOUCHER_TYPE = value; } }

        //-----------------------------------JOURNAL ENTRY END------------------------------------------------//

        //-----------------------------------CONTRAVOUCHER ENTRY START------------------------------------------------//
        private string _CONTRAVOUCHER_ID, _PAYMENT_METHOD;

        public string CONTRAVOUCHER_ID { get { return _CONTRAVOUCHER_ID; } set { _CONTRAVOUCHER_ID = value; } }
        public string PAYMENT_METHOD { get { return _PAYMENT_METHOD; } set { _PAYMENT_METHOD = value; } }


        //-----------------------------------CONTRAVOUCHER ENTRY END------------------------------------------------//
        //-------------------------------CREDIT & DEBIT NOTE ENTRY START---------------------------------------------//
       
        private string _CREDIT_NOTE_NO, _PARTY_NAME, _DEBIT_NOTE_NO, _CREDIT_NOTE_DATE, _DEBIT_NOTE_DATE, _DEBITNOTE_MAIN_ID, _VOUCHER_ID, _DEBITNOTE_SUB_ID, _Narration;
        public string CREDIT_NOTE_NO { get { return _CREDIT_NOTE_NO; } set { _CREDIT_NOTE_NO = value; } }
        public string PARTY_NAME { get { return _PARTY_NAME; } set { _PARTY_NAME = value; } }
        public string DEBIT_NOTE_NO { get { return _DEBIT_NOTE_NO; } set { _DEBIT_NOTE_NO = value; } }
        public string CREDIT_NOTE_DATE { get { return _CREDIT_NOTE_DATE; } set { _CREDIT_NOTE_DATE = value; } }
        public string DEBIT_NOTE_DATE { get { return _DEBIT_NOTE_DATE; } set { _DEBIT_NOTE_DATE = value; } }
        public string DEBITNOTE_MAIN_ID { get { return _DEBITNOTE_MAIN_ID; } set { _DEBITNOTE_MAIN_ID = value; } }
        public string VOUCHER_ID { get { return _VOUCHER_ID; } set { _VOUCHER_ID = value; } }
        public string DEBITNOTE_SUB_ID { get { return _DEBITNOTE_SUB_ID; } set { _DEBITNOTE_SUB_ID = value; } }
        public string Narration { get { return _Narration; } set { _Narration = value; } }  
        //-------------------------------CREDIT & DEBIT NOTE ENTRY END---------------------------------------------//
        private string _MutipleBranches, _Exp_ID, _BulkXml, _CustomerName, _Line_no, _SubLine_no, _ExpForDetail, _TotSubExpAmt, _Department;
        public string MutipleBranches { get { return _MutipleBranches; } set { _MutipleBranches = value; } }
        public string EXP_ID { get { return _Exp_ID; } set { _Exp_ID = value; } }
        public string BulkXML { get { return _BulkXml; } set { _BulkXml = value; } }

        public string CustomerName { get { return _CustomerName; } set { _CustomerName = value; } }
        public string Line_no { get { return _Line_no; } set { _Line_no = value; } }
        public string SubLine_no { get { return _SubLine_no; } set { _SubLine_no = value; } }
        public string ExpForDetail { get { return _ExpForDetail; } set { _ExpForDetail = value; } }
        public string TotSubExpAmt { get { return _TotSubExpAmt; } set { _TotSubExpAmt = value; } }
        public string Department { get { return _Department; } set { _Department = value; } }


        //--------------------------------GROUP MASTER ENTRY START------------------------------------------------//
        private string _LEDGER, _SUB_GROUP, _REPORTING;
        public string LEDGER { get { return _LEDGER; } set { _LEDGER = value; } }
        public string SUB_GROUP { get { return _SUB_GROUP; } set { _SUB_GROUP = value; } }
        public string REPORTING { get { return _REPORTING; } set { _REPORTING = value; } }

        //--------------------------------GROUP MASTER ENTRY END--------------------------------------------------//

        //--------------------------------BANK MASTER ENTRY START------------------------------------------------//
        private string _NAME, _ACCOUNT_HOLDER_NAME, _ACCOUNT_NUMBER, _IFSCODE, _GST_NUMBER, _DISTRICT, _PINCODE, _SET_CHEQUE_BOOKS, _ENABLE_CHEQUE_PRINTING, _ENABLE_AUTO_RECONCILATION, _ENABLE_E_PAYMENTS;
        public string NAME { get { return _NAME; } set { _NAME = value; } }
        public string ACCOUNT_HOLDER_NAME { get { return _ACCOUNT_HOLDER_NAME; } set { _ACCOUNT_HOLDER_NAME = value; } }
        public string ACCOUNT_NUMBER { get { return _ACCOUNT_NUMBER; } set { _ACCOUNT_NUMBER = value; } }
        public string IFSCODE { get { return _IFSCODE; } set { _IFSCODE = value; } }
        public string GST_NUMBER { get { return _GST_NUMBER; } set { _GST_NUMBER = value; } }
        public string DISTRICT { get { return _DISTRICT; } set { _DISTRICT = value; } }
        public string PINCODE { get { return _PINCODE; } set { _PINCODE = value; } }
        public string SET_CHEQUE_BOOKS { get { return _SET_CHEQUE_BOOKS; } set { _SET_CHEQUE_BOOKS = value; } }
        public string ENABLE_CHEQUE_PRINTING { get { return _ENABLE_CHEQUE_PRINTING; } set { _ENABLE_CHEQUE_PRINTING = value; } }
        public string ENABLE_AUTO_RECONCILATION { get { return _ENABLE_AUTO_RECONCILATION; } set { _ENABLE_AUTO_RECONCILATION = value; } }
        public string ENABLE_E_PAYMENTS { get { return _ENABLE_E_PAYMENTS; } set { _ENABLE_E_PAYMENTS = value; } }
        //--------------------------------BANK MASTER ENTRY END--------------------------------------------------//
    }
}