using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessObject
{
    public class UserBO
    {
        private string _ITEM_ID, _JOBNO, _INVOICE_SLNO, _INVOICE_NO, _ITEM_SLNO, _ITEM_DESCRIPTION, _RITCNO, _ITEM_QTY, _ITEM_QTY_CODE, _ITEM_UNIT_PRICE, _ITEM_PER, _ITEM_AMOUNT
            , _ITEM_PMVVALUE, _ITEM_TOTAL_PMVVALUE, _ITEM_SCHEME_CODE, _ITEM_ACCESSORIES, _ITEM_ACCESSORIES_DESC, _ITEM_AR4, _ITEM_AR4_NO, _ITEM_AR4_DATE, _ITEM_COMMISSION_RATE
            , _ITEM_DIVISION, _ITEM_RANGE, _ITEM_REMARKS, _ITEM_CESS, _ITEM_THIRDPARTY, _ITEM_IECCODE, _ITEM_EXPORTER_NAME, _BR_SLNO, _ADDRESS1, _ADDRESS2, _ADDRESS3, _ADDRESS4
            , _ADDRESS5, _STR_DETAILS, _ITEM_STR_CODE, _REWARD_POINTS, _PMV_VALUE, _FOB_VALUE, _DRAWBACK_VALUE, _STR_RATE, _STR_AMOUNT, _STR_Y_N, _flag, _USER_ID, _BRANCH_CODE
            , _YEAR, _WORKING_PERIOD, _BRANCH_COMMON, _CESS_YN, _Ename, _startRowIndex, _maximumRows, _totalRows, _DRAWBACK_SL_NO, _From_Item_Slno, _To_Item_Slno
            , _From_date, _Todate, _Date, _Jobdate, _BE_No, _BE_Date, _Description, _Courier_Name, _Courier_No, _Courier_Date, _MAWB_NO, _HAWB_NO, _Pkg, _Pkg_Unit, _Gross_Wgt
            , _Gross_Wgt_Unit, _Port_of_Loading, _Inward_Date, _Container_No, _Other_Description, _RODTEP, _JOBNO_PS, _PART_NO,_DOC_REF_NUMBER;

        private string _action;
        private string _Exp_Name;
        public string _AMENDMENT_TYPE, _AMENDMENT_STATUS, _ICEGATE_DOC_FILE_NAME;
        public string action { get { return _action; } set { _action = value; } }
        public string AMENDMENT_TYPE { get { return _AMENDMENT_TYPE; } set { _AMENDMENT_TYPE = value; } }
        public string AMENDMENT_STATUS { get { return _AMENDMENT_STATUS; } set { _AMENDMENT_STATUS = value; } }
        public string ICEGATE_DOC_FILE_NAME { get { return _ICEGATE_DOC_FILE_NAME; } set { _ICEGATE_DOC_FILE_NAME = value; } }
        public string RODTEP { get { return _RODTEP; } set { _RODTEP = value; } }
        public string Exp_Name { get { return _Exp_Name; } set { _Exp_Name = value; } }
        public string DOC_REF_NUMBER { get { return _DOC_REF_NUMBER; } set { _DOC_REF_NUMBER = value; } }
        
        

        private string _Imp_Name, _File_Refno, _Xml_A, _Xml_B, _Xml_C, _Xml_D, _Xml_E, _Xml_F, _Xml_G, _Xml_H, _Xml_FTA, _Xml_REM;
        private decimal _ITEM_VALUE;
        public string Xml_A { get { return _Xml_A; } set { _Xml_A = value; } }
        public string Xml_B { get { return _Xml_B; } set { _Xml_B = value; } }
        public string Xml_C { get { return _Xml_C; } set { _Xml_C = value; } }
        public string Xml_D { get { return _Xml_D; } set { _Xml_D = value; } }
        public string Xml_E { get { return _Xml_E; } set { _Xml_E = value; } }
        public string Xml_F { get { return _Xml_F; } set { _Xml_F = value; } }
        public string Xml_G { get { return _Xml_G; } set { _Xml_G = value; } }
        public string Xml_H { get { return _Xml_H; } set { _Xml_H = value; } }
        public string Xml_FTA { get { return _Xml_FTA; } set { _Xml_FTA = value; } }
        public string Xml_REM { get { return _Xml_REM; } set { _Xml_REM = value; } }

        public string ITEM_ID { get { return _ITEM_ID; } set { _ITEM_ID = value; } }
        public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
        public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
        public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
        public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
        public string ITEM_DESCRIPTION { get { return _ITEM_DESCRIPTION; } set { _ITEM_DESCRIPTION = value; } }
        public string RITCNO { get { return _RITCNO; } set { _RITCNO = value; } }
        public string ITEM_QTY { get { return _ITEM_QTY; } set { _ITEM_QTY = value; } }
        public string ITEM_QTY_CODE { get { return _ITEM_QTY_CODE; } set { _ITEM_QTY_CODE = value; } }
        public string ITEM_UNIT_PRICE { get { return _ITEM_UNIT_PRICE; } set { _ITEM_UNIT_PRICE = value; } }
        public string ITEM_PER { get { return _ITEM_PER; } set { _ITEM_PER = value; } }
        public string ITEM_AMOUNT { get { return _ITEM_AMOUNT; } set { _ITEM_AMOUNT = value; } }

        public string ITEM_PMVVALUE { get { return _ITEM_PMVVALUE; } set { _ITEM_PMVVALUE = value; } }
        public string ITEM_TOTAL_PMVVALUE { get { return _ITEM_TOTAL_PMVVALUE; } set { _ITEM_TOTAL_PMVVALUE = value; } }
        public string ITEM_SCHEME_CODE { get { return _ITEM_SCHEME_CODE; } set { _ITEM_SCHEME_CODE = value; } }
        public string ITEM_ACCESSORIES { get { return _ITEM_ACCESSORIES; } set { _ITEM_ACCESSORIES = value; } }
        public string ITEM_ACCESSORIES_DESC { get { return _ITEM_ACCESSORIES_DESC; } set { _ITEM_ACCESSORIES_DESC = value; } }
        public string ITEM_AR4 { get { return _ITEM_AR4; } set { _ITEM_AR4 = value; } }
        public string ITEM_AR4_NO { get { return _ITEM_AR4_NO; } set { _ITEM_AR4_NO = value; } }
        public string ITEM_AR4_DATE { get { return _ITEM_AR4_DATE; } set { _ITEM_AR4_DATE = value; } }
        public string ITEM_COMMISSION_RATE { get { return _ITEM_COMMISSION_RATE; } set { _ITEM_COMMISSION_RATE = value; } }
        public string ITEM_DIVISION { get { return _ITEM_DIVISION; } set { _ITEM_DIVISION = value; } }
        public string ITEM_RANGE { get { return _ITEM_RANGE; } set { _ITEM_RANGE = value; } }
        public string ITEM_REMARKS { get { return _ITEM_REMARKS; } set { _ITEM_REMARKS = value; } }
        public string ITEM_CESS { get { return _ITEM_CESS; } set { _ITEM_CESS = value; } }
        public string ITEM_THIRDPARTY { get { return _ITEM_THIRDPARTY; } set { _ITEM_THIRDPARTY = value; } }
        public string ITEM_IECCODE { get { return _ITEM_IECCODE; } set { _ITEM_IECCODE = value; } }
        public string ITEM_EXPORTER_NAME { get { return _ITEM_EXPORTER_NAME; } set { _ITEM_EXPORTER_NAME = value; } }
        public string BR_SLNO { get { return _BR_SLNO; } set { _BR_SLNO = value; } }
        public string ADDRESS1 { get { return _ADDRESS1; } set { _ADDRESS1 = value; } }
        public string ADDRESS2 { get { return _ADDRESS2; } set { _ADDRESS2 = value; } }
        public string ADDRESS3 { get { return _ADDRESS3; } set { _ADDRESS3 = value; } }
        public string ADDRESS4 { get { return _ADDRESS4; } set { _ADDRESS4 = value; } }
        public string ADDRESS5 { get { return _ADDRESS5; } set { _ADDRESS5 = value; } }
        public string STR_DETAILS { get { return _STR_DETAILS; } set { _STR_DETAILS = value; } }
        public string ITEM_STR_CODE { get { return _ITEM_STR_CODE; } set { _ITEM_STR_CODE = value; } }
        public string REWARD_POINTS { get { return _REWARD_POINTS; } set { _REWARD_POINTS = value; } }
        public string PMV_VALUE { get { return _PMV_VALUE; } set { _PMV_VALUE = value; } }
        public string FOB_VALUE { get { return _FOB_VALUE; } set { _FOB_VALUE = value; } }
        public string DRAWBACK_VALUE { get { return _DRAWBACK_VALUE; } set { _DRAWBACK_VALUE = value; } }
        public string DRAWBACK_SL_NO { get { return _DRAWBACK_SL_NO; } set { _DRAWBACK_SL_NO = value; } }

        public string STR_RATE { get { return _STR_RATE; } set { _STR_RATE = value; } }
        public string STR_AMOUNT { get { return _STR_AMOUNT; } set { _STR_AMOUNT = value; } }
        public string STR_Y_N { get { return _STR_Y_N; } set { _STR_Y_N = value; } }
        public string CESS_YN { get { return _CESS_YN; } set { _CESS_YN = value; } }

        public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
        public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
        public string totalRows { get { return _totalRows; } set { _totalRows = value; } }
        public decimal ITEM_VALUE { get { return _ITEM_VALUE; } set { _ITEM_VALUE = value; } }
        public string From_Item_Slno { get { return _From_Item_Slno; } set { _From_Item_Slno = value; } }
        public string To_Item_Slno { get { return _To_Item_Slno; } set { _To_Item_Slno = value; } }

        /*****************/
        public string flag { get { return _flag; } set { _flag = value; } }
        public string Ename { get { return _Ename; } set { _Ename = value; } }
        public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
        public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
        public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }
        public string JOBNO_PS { get { return _JOBNO_PS; } set { _JOBNO_PS = value; } }
        public string PART_NO { get { return _PART_NO; } set { _PART_NO = value; } }
        /*****************/


        private string _AWB_INV_NO, _AWB_TYPE, _MASTER_AWB_NO_1, _MASTER_AWB_NO_2, _HOUSE_AWB_NO, _AWB_DATE, _DSR_DATE, _SHIPPER_ACNO, _CONSIGNEE_ACNO, _CONSIGNEE_LCNO, _AGENT_NAME
   , _AGENT_CITY, _AGENT_IATA_CODE, _AGENT_ACNO, _AGENT_AC_INFO, _AIRPORT_DEPATURE_REQ_ROUTING, _AIRPORT_DESTINATION, _FLIGHT_NO, _FLIGHT_DATE, _AMT_OF_INSURANCE
   , _DV_FOR_CARRIAGE, _DV_FOR_CUSTOMS, _HANDLING_INFO, _ISSUED_BY, _R_D_TO_1, _R_D_BY_1, _R_D_TO_2, _R_D_BY_2, _R_D_TO_3, _R_D_BY_3, _CURRENCY, _CHGS_CODE, _WT_VAL, _OTHER
   , _CH_NO_OF_PIECES_RCP, _CH_GROSS_WGT, _CH_TOTAL, _PP_WGT_CHARGE, _CC_WGT_CHARGE, _PP_VALUATION_CHARGE, _CC_VALUATION_CHARGE, _PP_TAX, _CC_TAX, _PP_TOTAL_OTH_CH_DUE_AGENT
   , _CC_TOTAL_OTH_CH_DUE_AGENT, _PP_TOTAL_OTH_CH_DUE_CARRIER, _CC_TOTAL_OTH_CH_DUE_CARRIER, _PP_TOTAL, _CC_TOTAL, _NOTIFY, _OTHER_CHARGES, _SIGN_OF_SHIPPER, _EXECUTED_ON
   , _PLACE_AT, _SIGN_OF_ISS_CARRIER, _TOTAL_COLLECT_CHARGES, _SHIPPER_NAME, _SHIPPER_ADD_1, _SHIPPER_ADD_2, _SHIPPER_ADD_3, _SHIPPER_ADD_4, _CONSIGNEE_NAME, _CONSIGNEE_ADD_1, _CONSIGNEE_ADD_2, _CONSIGNEE_ADD_3, _CONSIGNEE_ADD_4;


        public string AWB_INV_NO { get { return _AWB_INV_NO; } set { _AWB_INV_NO = value; } }
        public string AWB_TYPE { get { return _AWB_TYPE; } set { _AWB_TYPE = value; } }
        public string MASTER_AWB_NO_1 { get { return _MASTER_AWB_NO_1; } set { _MASTER_AWB_NO_1 = value; } }
        public string MASTER_AWB_NO_2 { get { return _MASTER_AWB_NO_2; } set { _MASTER_AWB_NO_2 = value; } }
        public string HOUSE_AWB_NO { get { return _HOUSE_AWB_NO; } set { _HOUSE_AWB_NO = value; } }
        public string AWB_DATE { get { return _AWB_DATE; } set { _AWB_DATE = value; } }
        public string DSR_DATE { get { return _DSR_DATE; } set { _DSR_DATE = value; } }
        public string SHIPPER_ACNO { get { return _SHIPPER_ACNO; } set { _SHIPPER_ACNO = value; } }
        public string CONSIGNEE_ACNO { get { return _CONSIGNEE_ACNO; } set { _CONSIGNEE_ACNO = value; } }
        public string CONSIGNEE_LCNO { get { return _CONSIGNEE_LCNO; } set { _CONSIGNEE_LCNO = value; } }
        public string AGENT_NAME { get { return _AGENT_NAME; } set { _AGENT_NAME = value; } }
        public string AGENT_CITY { get { return _AGENT_CITY; } set { _AGENT_CITY = value; } }
        public string AGENT_IATA_CODE { get { return _AGENT_IATA_CODE; } set { _AGENT_IATA_CODE = value; } }
        public string AGENT_ACNO { get { return _AGENT_ACNO; } set { _AGENT_ACNO = value; } }

        public string SHIPPER_NAME { get { return _SHIPPER_NAME; } set { _SHIPPER_NAME = value; } }
        public string SHIPPER_ADD_1 { get { return _SHIPPER_ADD_1; } set { _SHIPPER_ADD_1 = value; } }
        public string SHIPPER_ADD_2 { get { return _SHIPPER_ADD_2; } set { _SHIPPER_ADD_2 = value; } }
        public string SHIPPER_ADD_3 { get { return _SHIPPER_ADD_3; } set { _SHIPPER_ADD_3 = value; } }
        public string SHIPPER_ADD_4 { get { return _SHIPPER_ADD_4; } set { _SHIPPER_ADD_4 = value; } }
        public string CONSIGNEE_NAME { get { return _CONSIGNEE_NAME; } set { _CONSIGNEE_NAME = value; } }
        public string CONSIGNEE_ADD_1 { get { return _CONSIGNEE_ADD_1; } set { _CONSIGNEE_ADD_1 = value; } }
        public string CONSIGNEE_ADD_2 { get { return _CONSIGNEE_ADD_2; } set { _CONSIGNEE_ADD_2 = value; } }
        public string CONSIGNEE_ADD_3 { get { return _CONSIGNEE_ADD_3; } set { _CONSIGNEE_ADD_3 = value; } }
        public string CONSIGNEE_ADD_4 { get { return _CONSIGNEE_ADD_4; } set { _CONSIGNEE_ADD_4 = value; } }

        public string AGENT_AC_INFO { get { return _AGENT_AC_INFO; } set { _AGENT_AC_INFO = value; } }
        public string AIRPORT_DEPATURE_REQ_ROUTING { get { return _AIRPORT_DEPATURE_REQ_ROUTING; } set { _AIRPORT_DEPATURE_REQ_ROUTING = value; } }
        public string AIRPORT_DESTINATION { get { return _AIRPORT_DESTINATION; } set { _AIRPORT_DESTINATION = value; } }
        public string FLIGHT_NO { get { return _FLIGHT_NO; } set { _FLIGHT_NO = value; } }
        public string FLIGHT_DATE { get { return _FLIGHT_DATE; } set { _FLIGHT_DATE = value; } }
        public string AMT_OF_INSURANCE { get { return _AMT_OF_INSURANCE; } set { _AMT_OF_INSURANCE = value; } }

        public string DV_FOR_CARRIAGE { get { return _DV_FOR_CARRIAGE; } set { _DV_FOR_CARRIAGE = value; } }
        public string DV_FOR_CUSTOMS { get { return _DV_FOR_CUSTOMS; } set { _DV_FOR_CUSTOMS = value; } }
        public string HANDLING_INFO { get { return _HANDLING_INFO; } set { _HANDLING_INFO = value; } }
        public string ISSUED_BY { get { return _ISSUED_BY; } set { _ISSUED_BY = value; } }
        public string R_D_TO_1 { get { return _R_D_TO_1; } set { _R_D_TO_1 = value; } }
        public string R_D_BY_1 { get { return _R_D_BY_1; } set { _R_D_BY_1 = value; } }
        public string R_D_TO_2 { get { return _R_D_TO_2; } set { _R_D_TO_2 = value; } }
        public string R_D_BY_2 { get { return _R_D_BY_2; } set { _R_D_BY_2 = value; } }
        public string R_D_TO_3 { get { return _R_D_TO_3; } set { _R_D_TO_3 = value; } }
        public string R_D_BY_3 { get { return _R_D_BY_3; } set { _R_D_BY_3 = value; } }

        public string CURRENCY { get { return _CURRENCY; } set { _CURRENCY = value; } }
        public string CHGS_CODE { get { return _CHGS_CODE; } set { _CHGS_CODE = value; } }
        public string WT_VAL { get { return _WT_VAL; } set { _WT_VAL = value; } }
        public string OTHER { get { return _OTHER; } set { _OTHER = value; } }
        public string CH_NO_OF_PIECES_RCP { get { return _CH_NO_OF_PIECES_RCP; } set { _CH_NO_OF_PIECES_RCP = value; } }
        public string CH_GROSS_WGT { get { return _CH_GROSS_WGT; } set { _CH_GROSS_WGT = value; } }
        public string CH_TOTAL { get { return _CH_TOTAL; } set { _CH_TOTAL = value; } }
        public string PP_WGT_CHARGE { get { return _PP_WGT_CHARGE; } set { _PP_WGT_CHARGE = value; } }
        public string CC_WGT_CHARGE { get { return _CC_WGT_CHARGE; } set { _CC_WGT_CHARGE = value; } }
        public string PP_VALUATION_CHARGE { get { return _PP_VALUATION_CHARGE; } set { _PP_VALUATION_CHARGE = value; } }
        public string CC_VALUATION_CHARGE { get { return _CC_VALUATION_CHARGE; } set { _CC_VALUATION_CHARGE = value; } }

        public string PP_TAX { get { return _PP_TAX; } set { _PP_TAX = value; } }
        public string CC_TAX { get { return _CC_TAX; } set { _CC_TAX = value; } }
        public string PP_TOTAL_OTH_CH_DUE_AGENT { get { return _PP_TOTAL_OTH_CH_DUE_AGENT; } set { _PP_TOTAL_OTH_CH_DUE_AGENT = value; } }
        public string CC_TOTAL_OTH_CH_DUE_AGENT { get { return _CC_TOTAL_OTH_CH_DUE_AGENT; } set { _CC_TOTAL_OTH_CH_DUE_AGENT = value; } }
        public string PP_TOTAL_OTH_CH_DUE_CARRIER { get { return _PP_TOTAL_OTH_CH_DUE_CARRIER; } set { _PP_TOTAL_OTH_CH_DUE_CARRIER = value; } }
        public string CC_TOTAL_OTH_CH_DUE_CARRIER { get { return _CC_TOTAL_OTH_CH_DUE_CARRIER; } set { _CC_TOTAL_OTH_CH_DUE_CARRIER = value; } }
        public string PP_TOTAL { get { return _PP_TOTAL; } set { _PP_TOTAL = value; } }
        public string CC_TOTAL { get { return _CC_TOTAL; } set { _CC_TOTAL = value; } }
        public string NOTIFY { get { return _NOTIFY; } set { _NOTIFY = value; } }
        public string OTHER_CHARGES { get { return _OTHER_CHARGES; } set { _OTHER_CHARGES = value; } }
        public string SIGN_OF_SHIPPER { get { return _SIGN_OF_SHIPPER; } set { _SIGN_OF_SHIPPER = value; } }
        public string EXECUTED_ON { get { return _EXECUTED_ON; } set { _EXECUTED_ON = value; } }
        public string PLACE_AT { get { return _PLACE_AT; } set { _PLACE_AT = value; } }
        public string SIGN_OF_ISS_CARRIER { get { return _SIGN_OF_ISS_CARRIER; } set { _SIGN_OF_ISS_CARRIER = value; } }
        public string TOTAL_COLLECT_CHARGES { get { return _TOTAL_COLLECT_CHARGES; } set { _TOTAL_COLLECT_CHARGES = value; } }

        public string From_date { get { return _From_date; } set { _From_date = value; } }
        public string Todate { get { return _Todate; } set { _Todate = value; } }
        public string Imp_Name { get { return _Imp_Name; } set { _Imp_Name = value; } }
        public string File_Refno { get { return _File_Refno; } set { _File_Refno = value; } }

        public string Date { get { return _Date; } set { _Date = value; } }
        public string Jobdate { get { return _Jobdate; } set { _Jobdate = value; } }
        public string BE_No { get { return _BE_No; } set { _BE_No = value; } }
        public string BE_Date { get { return _BE_Date; } set { _BE_Date = value; } }
        public string Description { get { return _Description; } set { _Description = value; } }
        public string Courier_Name { get { return _Courier_Name; } set { _Courier_Name = value; } }

        public string Courier_No { get { return _Courier_No; } set { _Courier_No = value; } }
        public string Courier_Date { get { return _Courier_Date; } set { _Courier_Date = value; } }
        public string MAWB_NO { get { return _MAWB_NO; } set { _MAWB_NO = value; } }
        public string HAWB_NO { get { return _HAWB_NO; } set { _HAWB_NO = value; } }
        public string Pkg { get { return _Pkg; } set { _Pkg = value; } }
        public string Pkg_Unit { get { return _Pkg_Unit; } set { _Pkg_Unit = value; } }
        public string Gross_Wgt { get { return _Gross_Wgt; } set { _Gross_Wgt = value; } }
        public string Gross_Wgt_Unit { get { return _Gross_Wgt_Unit; } set { _Gross_Wgt_Unit = value; } }
        public string Port_of_Loading { get { return _Port_of_Loading; } set { _Port_of_Loading = value; } }
        public string Inward_Date { get { return _Inward_Date; } set { _Inward_Date = value; } }
        public string Container_No { get { return _Container_No; } set { _Container_No = value; } }
        public string Other_Description { get { return _Other_Description; } set { _Other_Description = value; } }


        //********************* EXCHANGE RATE ALL BACKUP BY CHITHRA - 21-DEC-2016 **********************************************
        public string _Effect_From,
                     _Currecy,
                     _Month,
                     _Year,
                     _Mstatus,
                     _ErrorMsg;

        public string Effect_From { get { return _Effect_From; } set { _Effect_From = value; } }
        public string Currecy { get { return _Currecy; } set { _Currecy = value; } }
        public string Month { get { return _Month; } set { _Month = value; } }
        public string Year { get { return _Year; } set { _Year = value; } }
        public string Mstatus { get { return _Mstatus; } set { _Mstatus = value; } }
        public string ErrorMsg { get { return _ErrorMsg; } set { _ErrorMsg = value; } }

        //***********************************************************************************************************************

        public string _PORT_CODE, _PORT_ID,
                  _PORT_NAME;
        public string PORT_CODE { get { return _PORT_CODE; } set { _PORT_CODE = value; } }
        public string PORT_NAME { get { return _PORT_NAME; } set { _PORT_NAME = value; } }
        public string PORT_ID { get { return _PORT_ID; } set { _PORT_ID = value; } }


        #region NForm_Details

        public string _NFORM_ID, _NF_NAME1, _NF_NAME2, _NF_NAME3, _NF_NAME4;
        public string _NF_TO, _NF_FIELD1, _NF_FIELD2, _NF_FIELD3, _NF_FIELD4, _NF_FIELD5, _NF_FIELD6, _NF_FIELD7, _NF_FIELD8;
        public string _NF_NO_DATEOFDOC, _NF_PKGNO, _NF_DESCNO, _NF_DESC_ARTICLES, _NF_IMPORTMARKS, _NF_WEIGHT_QTY, _NF_NFORM_NO, _NF_NFORM_PKGNO, _NF_OCTRAI_PAID;
        public string _NF_IMP_BILL, _NF_PKG_ESCORTED, _NF_NO_DATEOFEXPORT, _NF_VALUE_OCTRAI, _NF_REMARKS, _NF_PLACEOFEXPORT, _NF_NAME_APPLICANT, _NF_DATEE, _NF_AUTHORIZED, _NF_ESCORD_FEES, _NF_DELIVED_TO;
        public string _NF_OCTRAI_NO, _NF_OCTRAI_DATE, _NF_OCTRAI_PERCENT;
        //public DateTime _NF_OCTRAI_DATE;

        public string NFORM_ID { get { return _NFORM_ID; } set { _NFORM_ID = value; } }
        public string NF_NAME1 { get { return _NF_NAME1; } set { _NF_NAME1 = value; } }
        public string NF_NAME2 { get { return _NF_NAME2; } set { _NF_NAME2 = value; } }
        public string NF_NAME3 { get { return _NF_NAME3; } set { _NF_NAME3 = value; } }
        public string NF_NAME4 { get { return _NF_NAME4; } set { _NF_NAME4 = value; } }

        public string NF_TO { get { return _NF_TO; } set { _NF_TO = value; } }
        public string NF_FIELD1 { get { return _NF_FIELD1; } set { _NF_FIELD1 = value; } }
        public string NF_FIELD2 { get { return _NF_FIELD2; } set { _NF_FIELD2 = value; } }
        public string NF_FIELD3 { get { return _NF_FIELD3; } set { _NF_FIELD3 = value; } }
        public string NF_FIELD4 { get { return _NF_FIELD4; } set { _NF_FIELD4 = value; } }
        public string NF_FIELD5 { get { return _NF_FIELD5; } set { _NF_FIELD5 = value; } }
        public string NF_FIELD6 { get { return _NF_FIELD6; } set { _NF_FIELD6 = value; } }
        public string NF_FIELD7 { get { return _NF_FIELD7; } set { _NF_FIELD7 = value; } }
        public string NF_FIELD8 { get { return _NF_FIELD8; } set { _NF_FIELD8 = value; } }

        public string NF_NO_DATEOFDOC { get { return _NF_NO_DATEOFDOC; } set { _NF_NO_DATEOFDOC = value; } }
        public string NF_PKGNO { get { return _NF_PKGNO; } set { _NF_PKGNO = value; } }
        public string NF_DESCNO { get { return _NF_DESCNO; } set { _NF_DESCNO = value; } }
        public string NF_DESC_ARTICLES { get { return _NF_DESC_ARTICLES; } set { _NF_DESC_ARTICLES = value; } }
        public string NF_IMPORTMARKS { get { return _NF_IMPORTMARKS; } set { _NF_IMPORTMARKS = value; } }
        public string NF_WEIGHT_QTY { get { return _NF_WEIGHT_QTY; } set { _NF_WEIGHT_QTY = value; } }
        public string NF_NFORM_NO { get { return _NF_NFORM_NO; } set { _NF_NFORM_NO = value; } }
        public string NF_NFORM_PKGNO { get { return _NF_NFORM_PKGNO; } set { _NF_NFORM_PKGNO = value; } }
        public string NF_OCTRAI_PAID { get { return _NF_OCTRAI_PAID; } set { _NF_OCTRAI_PAID = value; } }

        public string NF_IMP_BILL { get { return _NF_IMP_BILL; } set { _NF_IMP_BILL = value; } }
        public string NF_PKG_ESCORTED { get { return _NF_PKG_ESCORTED; } set { _NF_PKG_ESCORTED = value; } }
        public string NF_NO_DATEOFEXPORT { get { return _NF_NO_DATEOFEXPORT; } set { _NF_NO_DATEOFEXPORT = value; } }
        public string NF_VALUE_OCTRAI { get { return _NF_VALUE_OCTRAI; } set { _NF_VALUE_OCTRAI = value; } }
        public string NF_REMARKS { get { return _NF_REMARKS; } set { _NF_REMARKS = value; } }
        public string NF_PLACEOFEXPORT { get { return _NF_PLACEOFEXPORT; } set { _NF_PLACEOFEXPORT = value; } }
        public string NF_NAME_APPLICANT { get { return _NF_NAME_APPLICANT; } set { _NF_NAME_APPLICANT = value; } }
        public string NF_DATEE { get { return _NF_DATEE; } set { _NF_DATEE = value; } }
        public string NF_AUTHORIZED { get { return _NF_AUTHORIZED; } set { _NF_AUTHORIZED = value; } }
        public string NF_ESCORD_FEES { get { return _NF_ESCORD_FEES; } set { _NF_ESCORD_FEES = value; } }
        public string NF_DELIVED_TO { get { return _NF_DELIVED_TO; } set { _NF_DELIVED_TO = value; } }

        public string NF_OCTRAI_NO { get { return _NF_OCTRAI_NO; } set { _NF_OCTRAI_NO = value; } }
        public string NF_OCTRAI_DATE { get { return _NF_OCTRAI_DATE; } set { _NF_OCTRAI_DATE = value; } }
        public string NF_OCTRAI_PERCENT { get { return _NF_OCTRAI_PERCENT; } set { _NF_OCTRAI_PERCENT = value; } }

        #endregion NForm_Details

        #region SINGLE WINDOW DETAILS
        public string _SW_ID, _INFO_TYPE, _INFO_QUALIFIER, _INFO_CODE, _INFO_TEXT, _INFO_MSR, _INFO_UQC, _DEPARTMENT, _I_U_TYPE, _DELETE_ID, _REGN_DATE, _REGN_VALIDITY;

        public string SW_ID { get { return _SW_ID; } set { _SW_ID = value; } }
        public string INFO_TYPE { get { return _INFO_TYPE; } set { _INFO_TYPE = value; } }
        public string INFO_QUALIFIER { get { return _INFO_QUALIFIER; } set { _INFO_QUALIFIER = value; } }
        public string INFO_CODE { get { return _INFO_CODE; } set { _INFO_CODE = value; } }
        public string INFO_TEXT { get { return _INFO_TEXT; } set { _INFO_TEXT = value; } }
        public string INFO_MSR { get { return _INFO_MSR; } set { _INFO_MSR = value; } }
        public string INFO_UQC { get { return _INFO_UQC; } set { _INFO_UQC = value; } }
        public string DEPARTMENT { get { return _DEPARTMENT; } set { _DEPARTMENT = value; } }
        public string I_U_TYPE { get { return _I_U_TYPE; } set { _I_U_TYPE = value; } }
        public string DELETE_ID { get { return _DELETE_ID; } set { _DELETE_ID = value; } }
        public string REGN_DATE { get { return _REGN_DATE; } set { _REGN_DATE = value; } }
        public string REGN_VALIDITY { get { return _REGN_VALIDITY; } set { _REGN_VALIDITY = value; } }



        public string _PRODUCT_DESCRIPTION, _PRODUCT_RITC; 
        public string  PRODUCT_DESCRIPTION { get { return _PRODUCT_DESCRIPTION; } set { _PRODUCT_DESCRIPTION = value; } }
        public string  PRODUCT_RITC { get { return _PRODUCT_RITC; } set { _PRODUCT_RITC = value; } }


        public string _CONSTITUENT_SRNO, _CONSTITUENT_ELEMENT_NAME, _CONSTITUENT_ELEMENT_CODE, _CONSTITUENT_PERCENTAGE, _CONSTITUENT_YIELD_PERCENTAGE, _ACTIVE_INGREDIENT;

        public string CONSTITUENT_SRNO { get { return _CONSTITUENT_SRNO; } set { _CONSTITUENT_SRNO = value; } }
        public string CONSTITUENT_ELEMENT_NAME { get { return _CONSTITUENT_ELEMENT_NAME; } set { _CONSTITUENT_ELEMENT_NAME = value; } }
        public string CONSTITUENT_ELEMENT_CODE { get { return _CONSTITUENT_ELEMENT_CODE; } set { _CONSTITUENT_ELEMENT_CODE = value; } }
        public string CONSTITUENT_PERCENTAGE { get { return _CONSTITUENT_PERCENTAGE; } set { _CONSTITUENT_PERCENTAGE = value; } }
        public string CONSTITUENT_YIELD_PERCENTAGE { get { return _CONSTITUENT_YIELD_PERCENTAGE; } set { _CONSTITUENT_YIELD_PERCENTAGE = value; } }
        public string ACTIVE_INGREDIENT { get { return _ACTIVE_INGREDIENT; } set { _ACTIVE_INGREDIENT = value; } }

        public string _CONTROL_TYPE_CODE, _CONTROL_LOCATION, _CONTROL_START_DATE, _CONTROL_END_DATE, _CONTROL_RESULT_CODE, _CONTROL_RESULT_TEXT, _CONTROL_MSR, _CONTROL_UQC, _CONTROL_SLNO;

        public string CONTROL_TYPE_CODE { get { return _CONTROL_TYPE_CODE; } set { _CONTROL_TYPE_CODE = value; } }
        public string CONTROL_LOCATION { get { return _CONTROL_LOCATION; } set { _CONTROL_LOCATION = value; } }
        public string CONTROL_START_DATE { get { return _CONTROL_START_DATE; } set { _CONTROL_START_DATE = value; } }
        public string CONTROL_END_DATE { get { return _CONTROL_END_DATE; } set { _CONTROL_END_DATE = value; } }
        public string CONTROL_RESULT_CODE { get { return _CONTROL_RESULT_CODE; } set { _CONTROL_RESULT_CODE = value; } }
        public string CONTROL_RESULT_TEXT { get { return _CONTROL_RESULT_TEXT; } set { _CONTROL_RESULT_TEXT = value; } }
        public string CONTROL_MSR { get { return _CONTROL_MSR; } set { _CONTROL_MSR = value; } }
        public string CONTROL_UQC { get { return _CONTROL_UQC; } set { _CONTROL_UQC = value; } }
        public string CONTROL_SLNO { get { return _CONTROL_SLNO; } set { _CONTROL_SLNO = value; } }



        public string _PRODUCTION_BATCH_IDENTIFIER, _PRODUCTION_BATCH_QUANTITY, _UNIT_QTY_CODE, _DATE_OF_MANUFACTURING, _DATE_OF_EXPIRY, _BEST_BEFORE, _RESIDUAL_SHELF_LIFE_DAYS
            , _TOTAL_SHELF_LIFE_DAYS, _RESIDUAL_SHELF_PERCENT;

        public string PRODUCTION_BATCH_IDENTIFIER { get { return _PRODUCTION_BATCH_IDENTIFIER; } set { _PRODUCTION_BATCH_IDENTIFIER = value; } }
        public string PRODUCTION_BATCH_QUANTITY { get { return _PRODUCTION_BATCH_QUANTITY; } set { _PRODUCTION_BATCH_QUANTITY = value; } }
        public string UNIT_QTY_CODE { get { return _UNIT_QTY_CODE; } set { _UNIT_QTY_CODE = value; } }
        public string DATE_OF_MANUFACTURING { get { return _DATE_OF_MANUFACTURING; } set { _DATE_OF_MANUFACTURING = value; } }
        public string DATE_OF_EXPIRY { get { return _DATE_OF_EXPIRY; } set { _DATE_OF_EXPIRY = value; } }
        public string BEST_BEFORE { get { return _BEST_BEFORE; } set { _BEST_BEFORE = value; } }
        public string RESIDUAL_SHELF_LIFE_DAYS { get { return _RESIDUAL_SHELF_LIFE_DAYS; } set { _RESIDUAL_SHELF_LIFE_DAYS = value; } }
        public string TOTAL_SHELF_LIFE_DAYS { get { return _TOTAL_SHELF_LIFE_DAYS; } set { _TOTAL_SHELF_LIFE_DAYS = value; } }
        public string RESIDUAL_SHELF_PERCENT { get { return _RESIDUAL_SHELF_PERCENT; } set { _RESIDUAL_SHELF_PERCENT = value; } }


        public string _SW_STMT_ID, _STMT_DECLARATION_TYPE, _STMT_DECLARATION_NUMBER, _STMT_DECLARATION_DATE, _STMT_TYPE, _STMT_CODE, _STMT_TEXT;

        public string SW_STMT_ID { get { return _SW_STMT_ID; } set { _SW_STMT_ID = value; } }
        public string STMT_DECLARATION_TYPE { get { return _STMT_DECLARATION_TYPE; } set { _STMT_DECLARATION_TYPE = value; } }
        public string STMT_DECLARATION_NUMBER { get { return _STMT_DECLARATION_NUMBER; } set { _STMT_DECLARATION_NUMBER = value; } }
        public string STMT_DECLARATION_DATE { get { return _STMT_DECLARATION_DATE; } set { _STMT_DECLARATION_DATE = value; } }
        public string STMT_TYPE { get { return _STMT_TYPE; } set { _STMT_TYPE = value; } }
        public string STMT_CODE { get { return _STMT_CODE; } set { _STMT_CODE = value; } }
        public string STMT_TEXT { get { return _STMT_TEXT; } set { _STMT_TEXT = value; } }

        public string  _STATE_OF_ORIGIN, _DISTRICT_OF_ORIGIN, _PTA_FTA, _GST_CESS_AMT;

        public string STATE_OF_ORIGIN { get { return _STATE_OF_ORIGIN; } set { _STATE_OF_ORIGIN = value; } }
        public string DISTRICT_OF_ORIGIN { get { return _DISTRICT_OF_ORIGIN; } set { _DISTRICT_OF_ORIGIN = value; } }
        public string PTA_FTA { get { return _PTA_FTA; } set { _PTA_FTA = value; } }
        public string GST_CESS_AMT { get { return _GST_CESS_AMT; } set { _GST_CESS_AMT = value; } }

        #endregion SINGLE WINDOW DETAILS

        public string _SLNO, _Unique_Document_No, _Doc_Type_Code, _Doc_Issuing_Party_Code, _Doc_Issuing_Party_Name_Add1
        , _Doc_Issuing_Party_Name_Add2, _Doc_Issuing_Party_Name_City, _Doc_Issuing_Party_Name_Pin, _Doc_Reference_No
        , _Place_of_Issue, _Doc_Issue_Date, _Doc_Expiry_Date, _Doc_Beneficiary_Party_Code, _Doc_Beneficiary_Party_Name_Add1
        , _Doc_Beneficiary_Party_Name_Add2, _Doc_Beneficiary_Party_Name_City, _Doc_Beneficiary_Party_Name_Pin, _File_Type, _SELECT_TYPE, _ICEGATE_ID
        , _Upd_ImageRef, _Upd_DoctypeCode, _Upd_Iss_Party, _Upd_PlaceOfIssue, _Upd_Issuedate, _Upd_BenParty, _Upd_IcegateID, _UNIQUE_DOC_NUMBER;
        

        public string SLNO { get { return _SLNO; } set { _SLNO = value; } }
        public string Unique_Document_No { get { return _Unique_Document_No; } set { _Unique_Document_No = value; } }
        public string Doc_Type_Code { get { return _Doc_Type_Code; } set { _Doc_Type_Code = value; } }
        public string Doc_Issuing_Party_Code { get { return _Doc_Issuing_Party_Code; } set { _Doc_Issuing_Party_Code = value; } }
        public string Doc_Issuing_Party_Name_Add1 { get { return _Doc_Issuing_Party_Name_Add1; } set { _Doc_Issuing_Party_Name_Add1 = value; } }
        public string Doc_Issuing_Party_Name_Add2 { get { return _Doc_Issuing_Party_Name_Add2; } set { _Doc_Issuing_Party_Name_Add2 = value; } }
        public string Doc_Issuing_Party_Name_City { get { return _Doc_Issuing_Party_Name_City; } set { _Doc_Issuing_Party_Name_City = value; } }
        public string Doc_Issuing_Party_Name_Pin { get { return _Doc_Issuing_Party_Name_Pin; } set { _Doc_Issuing_Party_Name_Pin = value; } }
        public string Doc_Reference_No { get { return _Doc_Reference_No; } set { _Doc_Reference_No = value; } }
        public string Place_of_Issue { get { return _Place_of_Issue; } set { _Place_of_Issue = value; } }
        public string Doc_Issue_Date { get { return _Doc_Issue_Date; } set { _Doc_Issue_Date = value; } }
        public string Doc_Expiry_Date { get { return _Doc_Expiry_Date; } set { _Doc_Expiry_Date = value; } }
        public string Doc_Beneficiary_Party_Code { get { return _Doc_Beneficiary_Party_Code; } set { _Doc_Beneficiary_Party_Code = value; } }
        public string Doc_Beneficiary_Party_Name_Add1 { get { return _Doc_Beneficiary_Party_Name_Add1; } set { _Doc_Beneficiary_Party_Name_Add1 = value; } }
        
        public string Doc_Beneficiary_Party_Name_Add2 { get { return _Doc_Beneficiary_Party_Name_Add2; } set { _Doc_Beneficiary_Party_Name_Add2 = value; } }
        public string Doc_Beneficiary_Party_Name_City { get { return _Doc_Beneficiary_Party_Name_City; } set { _Doc_Beneficiary_Party_Name_City = value; } }
        public string Doc_Beneficiary_Party_Name_Pin { get { return _Doc_Beneficiary_Party_Name_Pin; } set { _Doc_Beneficiary_Party_Name_Pin = value; } }
        public string File_Type { get { return _File_Type; } set { _File_Type = value; } }
        public string SELECT_TYPE { get { return _SELECT_TYPE; } set { _SELECT_TYPE = value; } }
        public string ICEGATE_ID { get { return _ICEGATE_ID; } set { _ICEGATE_ID = value; } }

        public string _DECLARATION_TYPE, _IMAGE_REF_NUMBER, _DOC_ISSUING_PARTY_NAME, _BENEFICIARY_PARTY_NAME;

        public string DECLARATION_TYPE { get { return _DECLARATION_TYPE; } set { _DECLARATION_TYPE = value; } }
        public string IMAGE_REF_NUMBER { get { return _IMAGE_REF_NUMBER; } set { _IMAGE_REF_NUMBER = value; } }
        public string DOC_ISSUING_PARTY_NAME { get { return _DOC_ISSUING_PARTY_NAME; } set { _DOC_ISSUING_PARTY_NAME = value; } }
        public string BENEFICIARY_PARTY_NAME { get { return _BENEFICIARY_PARTY_NAME; } set { _BENEFICIARY_PARTY_NAME = value; } }


        public string _Tr_Mode, _Report_cat, _Select_Item, _Qstart, _QEnd, _StartMonth, _EndMonth;
        public string Tr_Mode { get { return _Tr_Mode; } set { _Tr_Mode = value; } }
        public string Report_cat { get { return _Report_cat; } set { _Report_cat = value; } }
        public string Select_Item { get { return _Select_Item; } set { _Select_Item = value; } }

        public string Qstart { get { return _Qstart; } set { _Qstart = value; } }
        public string QEnd { get { return _QEnd; } set { _QEnd = value; } }
        public string StartMonth { get { return _StartMonth; } set { _StartMonth = value; } }
        public string EndMonth { get { return _EndMonth; } set { _EndMonth = value; } }

        public string Upd_ImageRef { get { return _Upd_ImageRef; } set { _Upd_ImageRef = value; } }
        public string Upd_DoctypeCode { get { return _Upd_DoctypeCode; } set { _Upd_DoctypeCode = value; } }
        public string Upd_Iss_Party { get { return _Upd_Iss_Party; } set { _Upd_Iss_Party = value; } }
        public string Upd_PlaceOfIssue { get { return _Upd_PlaceOfIssue; } set { _Upd_PlaceOfIssue = value; } }
        public string Upd_Issuedate { get { return _Upd_Issuedate; } set { _Upd_Issuedate = value; } }
        public string Upd_BenParty { get { return _Upd_BenParty; } set { _Upd_BenParty = value; } }
        public string Upd_IcegateID { get { return _Upd_IcegateID; } set { _Upd_IcegateID = value; } }
        public string UNIQUE_DOC_NUMBER { get { return _UNIQUE_DOC_NUMBER; } set { _UNIQUE_DOC_NUMBER = value; } }


        #region GeneralDetails_Private_Attributes
        private string _JOBID, _Name_Search;
        private string _JOBDATE;
        private string _TRANSPORT_MODE;
        private string _BE_TYPE;
        private string _CUSTOMS_HOUSE, _CUSTOMS_HOUSE_NAME, _FILE_REF_NO;
        private string _CONTAINER_TYPE;
        private string _IMPORTER_NAME, _VESSEL_NAME, _ETA;
        private string _IEC_NO;
        private string _BRANCH_NO;
        private string _COUNTRY_ORIGIN;
        private string _PORT_ORIGIN;

        private string _PORT_SHIPMENT;
        private string _COUNTRY_SHIPMENT;
        private string _FILING_STATUS;
        private string _SECTION46;
        private string _SECTION46_DESC;
        private string _FIRSTCHECK;
        private string _FIRSTCHECK_DESC;
        private string _GREEN_CHANNEL;
        private string _GREEN_CHANNEL_DESC;
        private string _KACHHA_BE;
        private string _KACHHA_BE_DESC;
        private string _SECTION48;
        private string _SECTION48_DESC;
        private string _HIGH_SEA_SALE;
        private string _HIGH_SEA_SALE_NAME;
        private string _HIGH_SEA_IEC;
        private string _HIGH_SEA_BRANCH_SL_NO;
        private string _HSS_ADD1;
        private string _HSS_ADD2;
        private string _HSS_ADD3;
        private string _HSS_ADD4;
        private string _HSS_ADD5;
        private string _WAREHOUSE_NAME;
        private string _WAREHOUSE_CODE;

        private string _COMMERCIAL_DETAILS_STATUS;
        private string _COMMERCIAL_TAX_STATENAME;
        private string _COMMERCIAL_TAX_STATECODE;
        private string _COMMERCIAL_TAX_TYPE;
        private string _COMMERCIAL_TAX_REGISTRATION_NO;
        private string _EXBOND_INBOND_BE_NO;
        private string _EXBOND_INBOND_BE_DATE;
        private string _EXBOND_BOND_NO;
        private string _EXBOND_BOND_DATE;
        private string _EXBOND_WAREHOUSE_CUSTOMS;
        private string _EXBOND_WAREHOUSE_CUSTOMS_CODE;
        private string _EXBOND_NOOFPACKAGE;
        private string _EXBOND_NOOFPACKAGE_UNITCODE;
        private string _EXBOND_GROSS_WEIGHT;
        private string _EXBOND_GROSS_WEIGHT_UNITCODE;
        private string _EXBOND_DIRECT_EXBONDING;

        private string _REMARKS;

        private string _UCR_NO;
        private string _UCR_TYPE;
        private string _PAYMENT_METHOD_CODE;
        private string _PRECEDING_LEVEL;
        private string _ADCODE;

        private string _EXBOND_ADDL_LOAD_HSS;
        private string _EXBOND_MISC_LOAD_RATE;

        #endregion

        #region GeneralDetails_Public_Attributes

        public string Name_Search { get { return _Name_Search; } set { _Name_Search = value; } }
        public string JOBID { get { return _JOBID; } set { _JOBID = value; } }

        public string JOBDATE { get { return _JOBDATE; } set { _JOBDATE = value; } }
        public string TRANSPORT_MODE { get { return _TRANSPORT_MODE; } set { _TRANSPORT_MODE = value; } }
        public string BE_TYPE { get { return _BE_TYPE; } set { _BE_TYPE = value; } }
        public string CUSTOMS_HOUSE { get { return _CUSTOMS_HOUSE; } set { _CUSTOMS_HOUSE = value; } }
        public string CUSTOMS_HOUSE_NAME { get { return _CUSTOMS_HOUSE_NAME; } set { _CUSTOMS_HOUSE_NAME = value; } }
        public string FILE_REF_NO { get { return _FILE_REF_NO; } set { _FILE_REF_NO = value; } }
        public string CONTAINER_TYPE { get { return _CONTAINER_TYPE; } set { _CONTAINER_TYPE = value; } }
        public string IMPORTER_NAME { get { return _IMPORTER_NAME; } set { _IMPORTER_NAME = value; } }
        public string VESSEL_NAME { get { return _VESSEL_NAME; } set { _VESSEL_NAME = value; } }
        public string ETA { get { return _ETA; } set { _ETA = value; } }


        public string IEC_NO { get { return _IEC_NO; } set { _IEC_NO = value; } }
        public string BRANCH_NO { get { return _BRANCH_NO; } set { _BRANCH_NO = value; } }
        public string COUNTRY_ORIGIN { get { return _COUNTRY_ORIGIN; } set { _COUNTRY_ORIGIN = value; } }
        public string PORT_ORIGIN { get { return _PORT_ORIGIN; } set { _PORT_ORIGIN = value; } }

        public string PORT_SHIPMENT { get { return _PORT_SHIPMENT; } set { _PORT_SHIPMENT = value; } }
        public string COUNTRY_SHIPMENT { get { return _COUNTRY_SHIPMENT; } set { _COUNTRY_SHIPMENT = value; } }
        public string FILING_STATUS { get { return _FILING_STATUS; } set { _FILING_STATUS = value; } }
        public string SECTION46 { get { return _SECTION46; } set { _SECTION46 = value; } }
        public string SECTION46_DESC { get { return _SECTION46_DESC; } set { _SECTION46_DESC = value; } }
        public string FIRSTCHECK { get { return _FIRSTCHECK; } set { _FIRSTCHECK = value; } }
        public string FIRSTCHECK_DESC { get { return _FIRSTCHECK_DESC; } set { _FIRSTCHECK_DESC = value; } }
        public string GREEN_CHANNEL { get { return _GREEN_CHANNEL; } set { _GREEN_CHANNEL = value; } }
        public string GREEN_CHANNEL_DESC { get { return _GREEN_CHANNEL_DESC; } set { _GREEN_CHANNEL_DESC = value; } }
        public string KACHHA_BE { get { return _KACHHA_BE; } set { _KACHHA_BE = value; } }
        public string KACHHA_BE_DESC { get { return _KACHHA_BE_DESC; } set { _KACHHA_BE_DESC = value; } }
        public string SECTION48 { get { return _SECTION48; } set { _SECTION48 = value; } }
        public string SECTION48_DESC { get { return _SECTION48_DESC; } set { _SECTION48_DESC = value; } }
        public string HIGH_SEA_SALE { get { return _HIGH_SEA_SALE; } set { _HIGH_SEA_SALE = value; } }
        public string HIGH_SEA_SALE_NAME { get { return _HIGH_SEA_SALE_NAME; } set { _HIGH_SEA_SALE_NAME = value; } }
        public string HIGH_SEA_IEC { get { return _HIGH_SEA_IEC; } set { _HIGH_SEA_IEC = value; } }
        public string HIGH_SEA_BRANCH_SL_NO { get { return _HIGH_SEA_BRANCH_SL_NO; } set { _HIGH_SEA_BRANCH_SL_NO = value; } }
        public string HSS_ADD1 { get { return _HSS_ADD1; } set { _HSS_ADD1 = value; } }
        public string HSS_ADD2 { get { return _HSS_ADD2; } set { _HSS_ADD2 = value; } }
        public string HSS_ADD3 { get { return _HSS_ADD3; } set { _HSS_ADD3 = value; } }
        public string HSS_ADD4 { get { return _HSS_ADD4; } set { _HSS_ADD4 = value; } }
        public string HSS_ADD5 { get { return _HSS_ADD5; } set { _HSS_ADD5 = value; } }
        public string REMARKS { get { return _REMARKS; } set { _REMARKS = value; } }
        public string WAREHOUSE_NAME { get { return _WAREHOUSE_NAME; } set { _WAREHOUSE_NAME = value; } }
        public string WAREHOUSE_CODE { get { return _WAREHOUSE_CODE; } set { _WAREHOUSE_CODE = value; } }

        public string COMMERCIAL_DETAILS_STATUS { get { return _COMMERCIAL_DETAILS_STATUS; } set { _COMMERCIAL_DETAILS_STATUS = value; } }
        public string COMMERCIAL_TAX_STATENAME { get { return _COMMERCIAL_TAX_STATENAME; } set { _COMMERCIAL_TAX_STATENAME = value; } }
        public string COMMERCIAL_TAX_STATECODE { get { return _COMMERCIAL_TAX_STATECODE; } set { _COMMERCIAL_TAX_STATECODE = value; } }
        public string COMMERCIAL_TAX_TYPE { get { return _COMMERCIAL_TAX_TYPE; } set { _COMMERCIAL_TAX_TYPE = value; } }
        public string COMMERCIAL_TAX_REGISTRATION_NO { get { return _COMMERCIAL_TAX_REGISTRATION_NO; } set { _COMMERCIAL_TAX_REGISTRATION_NO = value; } }
        public string EXBOND_INBOND_BE_NO { get { return _EXBOND_INBOND_BE_NO; } set { _EXBOND_INBOND_BE_NO = value; } }
        public string EXBOND_INBOND_BE_DATE { get { return _EXBOND_INBOND_BE_DATE; } set { _EXBOND_INBOND_BE_DATE = value; } }
        public string EXBOND_BOND_NO { get { return _EXBOND_BOND_NO; } set { _EXBOND_BOND_NO = value; } }
        public string EXBOND_BOND_DATE { get { return _EXBOND_BOND_DATE; } set { _EXBOND_BOND_DATE = value; } }
        public string EXBOND_WAREHOUSE_CUSTOMS { get { return _EXBOND_WAREHOUSE_CUSTOMS; } set { _EXBOND_WAREHOUSE_CUSTOMS = value; } }
        public string EXBOND_WAREHOUSE_CUSTOMS_CODE { get { return _EXBOND_WAREHOUSE_CUSTOMS_CODE; } set { _EXBOND_WAREHOUSE_CUSTOMS_CODE = value; } }
        public string EXBOND_NOOFPACKAGE { get { return _EXBOND_NOOFPACKAGE; } set { _EXBOND_NOOFPACKAGE = value; } }
        public string EXBOND_NOOFPACKAGE_UNITCODE { get { return _EXBOND_NOOFPACKAGE_UNITCODE; } set { _EXBOND_NOOFPACKAGE_UNITCODE = value; } }
        public string EXBOND_GROSS_WEIGHT { get { return _EXBOND_GROSS_WEIGHT; } set { _EXBOND_GROSS_WEIGHT = value; } }
        public string EXBOND_GROSS_WEIGHT_UNITCODE { get { return _EXBOND_GROSS_WEIGHT_UNITCODE; } set { _EXBOND_GROSS_WEIGHT_UNITCODE = value; } }
        public string EXBOND_DIRECT_EXBONDING { get { return _EXBOND_DIRECT_EXBONDING; } set { _EXBOND_DIRECT_EXBONDING = value; } }

        public string UCR_NO { get { return _UCR_NO; } set { _UCR_NO = value; } }
        public string UCR_TYPE { get { return _UCR_TYPE; } set { _UCR_TYPE = value; } }
        public string PAYMENT_METHOD_CODE { get { return _PAYMENT_METHOD_CODE; } set { _PAYMENT_METHOD_CODE = value; } }
        public string PRECEDING_LEVEL { get { return _PRECEDING_LEVEL; } set { _PRECEDING_LEVEL = value; } }
        public string ADCODE { get { return _ADCODE; } set { _ADCODE = value; } }

        public string EXBOND_ADDL_LOAD_HSS { get { return _EXBOND_ADDL_LOAD_HSS; } set { _EXBOND_ADDL_LOAD_HSS = value; } }
        public string EXBOND_MISC_LOAD_RATE { get { return _EXBOND_MISC_LOAD_RATE; } set { _EXBOND_MISC_LOAD_RATE = value; } }



        #endregion

        #region EXPORT_SW_MANUFACTURER

        private string _MANUFACTURER_PRODUCER_CODE;
        private string _M_P_GROWER_CODE;
        private string _M_P_GROWER_ADD1;
        private string _M_P_GROWER_ADD2;
        private string _M_P_GROWER_CITY;
        private string _M_P_GROWER_COUNTRY_SUBDIV;
        private string _M_P_GROWER_PIN;
        private string _M_P_GROWER_COUNTRY;
        private string _SOURCE_STATE;
        private string _TRANSIT_COUNTRY;
        private string _ACCESSORY_STATUS;
        private string _GSTN_TYPE;
        private string _GSTN_ID;

        private string _TOTAL_PKGS;
        private string _ENDUSE_ITEM;
        private string _IGST_PAYMENT;
        private string _TAXABLE_VALUE;
        private string _IGST_AMT;
        private string _IGST_RATE;
        private string _PMV_METHOD;
        private string _PMV_RATE;
        private string _PMV_PER_UNIT;
       
        
        public string MANUFACTURER_PRODUCER_CODE { get { return _MANUFACTURER_PRODUCER_CODE; } set { _MANUFACTURER_PRODUCER_CODE = value; } }
        public string M_P_GROWER_CODE { get { return _M_P_GROWER_CODE; } set { _M_P_GROWER_CODE = value; } }
        public string M_P_GROWER_ADD1 { get { return _M_P_GROWER_ADD1; } set { _M_P_GROWER_ADD1 = value; } }
        public string M_P_GROWER_ADD2 { get { return _M_P_GROWER_ADD2; } set { _M_P_GROWER_ADD2 = value; } }
        public string M_P_GROWER_CITY { get { return _M_P_GROWER_CITY; } set { _M_P_GROWER_CITY = value; } }
        public string M_P_GROWER_COUNTRY_SUBDIV { get { return _M_P_GROWER_COUNTRY_SUBDIV; } set { _M_P_GROWER_COUNTRY_SUBDIV = value; } }
        public string M_P_GROWER_PIN { get { return _M_P_GROWER_PIN; } set { _M_P_GROWER_PIN = value; } }
        public string M_P_GROWER_COUNTRY { get { return _M_P_GROWER_COUNTRY; } set { _M_P_GROWER_COUNTRY = value; } }
        public string SOURCE_STATE { get { return _SOURCE_STATE; } set { _SOURCE_STATE = value; } }
        public string TRANSIT_COUNTRY { get { return _TRANSIT_COUNTRY; } set { _TRANSIT_COUNTRY = value; } }
        public string ACCESSORY_STATUS { get { return _ACCESSORY_STATUS; } set { _ACCESSORY_STATUS = value; } }
        public string TOTAL_PKGS { get { return _TOTAL_PKGS; } set { _TOTAL_PKGS = value; } }
        public string ENDUSE_ITEM { get { return _ENDUSE_ITEM; } set { _ENDUSE_ITEM = value; } }
        public string IGST_PAYMENT { get { return _IGST_PAYMENT; } set { _IGST_PAYMENT = value; } }
        public string TAXABLE_VALUE { get { return _TAXABLE_VALUE; } set { _TAXABLE_VALUE = value; } }
        public string IGST_AMT { get { return _IGST_AMT; } set { _IGST_AMT = value; } }
        public string GSTN_TYPE { get { return _GSTN_TYPE; } set { _GSTN_TYPE = value; } }
        public string GSTN_ID { get { return _GSTN_ID; } set { _GSTN_ID = value; } }
        public string IGST_RATE { get { return _IGST_RATE; } set { _IGST_RATE = value; } }
        public string PMV_METHOD { get { return _PMV_METHOD; } set { _PMV_METHOD = value; } }
        public string PMV_RATE { get { return _PMV_RATE; } set { _PMV_RATE = value; } }
        public string PMV_PER_UNIT { get { return _PMV_PER_UNIT; } set { _PMV_PER_UNIT = value; } }

        #endregion EXPORT_SW_MANUFACTURER

        #region WAREHOUSE_DETAILS_USERWISE
        private string _WH_ID;
        private string _WAREHOUSE_ADDRESS;

        public string WH_ID { get { return _WH_ID; } set { _WH_ID = value; } }
        public string WAREHOUSE_ADDRESS { get { return _WAREHOUSE_ADDRESS; } set { _WAREHOUSE_ADDRESS = value; } }

        #endregion WAREHOUSE_DETAILS_USERWISE


        public string _TRANSSHIPMENT_NO, _MODE_OF_TRANSPORT, _CARRIER_NO, _GATEWAY_PORT;

        public string TRANSSHIPMENT_NO { get { return _TRANSSHIPMENT_NO; } set { _TRANSSHIPMENT_NO = value; } }
        public string MODE_OF_TRANSPORT { get { return _MODE_OF_TRANSPORT; } set { _MODE_OF_TRANSPORT = value; } }
        public string CARRIER_NO { get { return _CARRIER_NO; } set { _CARRIER_NO = value; } }
        public string GATEWAY_PORT { get { return _GATEWAY_PORT; } set { _GATEWAY_PORT = value; } }
    }

}
