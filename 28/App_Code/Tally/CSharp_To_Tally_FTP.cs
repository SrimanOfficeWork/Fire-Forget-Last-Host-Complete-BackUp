using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;

/// <summary>
/// Summary description for CSharp_To_Tally_FTP
/// </summary>
public class CSharp_To_Tally_FTP
{
	public CSharp_To_Tally_FTP()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public class Tally_NewVersion_FTP
    {
        public static string ConnectToTally(string Tally_CompanyName, string VoucherNo, string FileRefNo, string Date, string Narration, string[] credit, string[] debit, string[] CrAcc, string[] DrAcc, int incr, string[] UserDesc, string[] CGST_RATE, string[] SGST_RATE, string[] IGST_RATE)
        {
            string xmlstc = "", ReturnMessage = "";
            try
            {
                xmlstc = "<ENVELOPE>" + "\r\n";
                xmlstc = xmlstc + "<HEADER>" + "\r\n";
                xmlstc = xmlstc + "<TALLYREQUEST>Import Data</TALLYREQUEST>" + "\r\n";
                xmlstc = xmlstc + "</HEADER>" + "\r\n";
                xmlstc = xmlstc + "<BODY>" + "\r\n";
                xmlstc = xmlstc + "<IMPORTDATA>" + "\r\n";
                xmlstc = xmlstc + "<REQUESTDESC>" + "\r\n";
                xmlstc = xmlstc + "<REPORTNAME>Vouchers</REPORTNAME>" + "\r\n";
                xmlstc = xmlstc + "<STATICVARIABLES>" + "\r\n";
                //xmlstc = xmlstc + "<SVCURRENTCOMPANY>##SVCURRENTCOMPANY</SVCURRENTCOMPANY>" + "\r\n";
                //xmlstc = xmlstc + "<SVCURRENTCOMPANY>MITHRA LOGISTICS</SVCURRENTCOMPANY>" + "\r\n";
                xmlstc = xmlstc + "<SVCURRENTCOMPANY>" + Tally_CompanyName + "</SVCURRENTCOMPANY>" + "\r\n";

                xmlstc = xmlstc + "</STATICVARIABLES>" + "\r\n";
                xmlstc = xmlstc + "</REQUESTDESC>" + "\r\n";

                xmlstc = xmlstc + "<REQUESTDATA>" + "\r\n";
                xmlstc = xmlstc + "<TALLYMESSAGE xmlns:UDF=" + "\"" + "TallyUDF" + "\">" + "\r\n";
                //xmlstc = xmlstc + "<VOUCHER VCHTYPE=" + "\"" + "Sales" + "\" ACTION=" + "\"" + "Create" + "\">" + "\r\n";//vtype

                xmlstc = xmlstc + "<VOUCHER VCHTYPE=" + "\"" + "GSTSales" + "\" ACTION=" + "\"" + "Create" + "\" OBJVIEW=" + "\"" + "Invoice Voucher View" + "\">" + "\r\n";//vtype
                xmlstc = xmlstc + "<ENTEREDBY>" + "ccccc" + "</ENTEREDBY>" + "\r\n";
                xmlstc = xmlstc + "<OLDAUDITENTRYIDS.LIST TYPE=" + "\"" + "Number" + "\">" + "\r\n";//vtype
                xmlstc = xmlstc + "<OLDAUDITENTRYIDS>1</OLDAUDITENTRYIDS>" + "\r\n";
                xmlstc = xmlstc + "</OLDAUDITENTRYIDS.LIST>" + "\r\n";// end
                //xmlstc = xmlstc + "<DATE>" + Date + "</DATE>" + "\r\n";
                //xmlstc = xmlstc + "<DATE>" + "20170901" + "</DATE>" + "\r\n";
                xmlstc = xmlstc + "<DATE>" + "20170902" + "</DATE>" + "\r\n";


                xmlstc = xmlstc + "<GUID>4e69f2a7-d7dc-4fdb-a901-ebd95770e053-00000037</GUID>" + "\r\n";
                xmlstc = xmlstc + "<STATENAME>Tamil Nadu</STATENAME>" + "\r\n";
                xmlstc = xmlstc + "<GSTREGISTRATIONTYPE>Regular</GSTREGISTRATIONTYPE>" + "\r\n";//new 14-11-17
                xmlstc = xmlstc + "<VATDEALERTYPE>Regular</VATDEALERTYPE>" + "\r\n";//new 14-11-17
                xmlstc = xmlstc + "<NARRATION>" + Narration + "</NARRATION>" + "\r\n";

                xmlstc = xmlstc + "<COUNTRYOFRESIDENCE>India</COUNTRYOFRESIDENCE>" + "\r\n";
                xmlstc = xmlstc + "<PARTYNAME>" + DrAcc[0] + "</PARTYNAME>" + "\r\n";
                xmlstc = xmlstc + "<VOUCHERTYPENAME>GSTSales</VOUCHERTYPENAME>" + "\r\n";
                xmlstc = xmlstc + "<REFERENCE>" + FileRefNo + "</REFERENCE>" + "\r\n";

                //xmlstc = xmlstc + "<VOUCHERNUMBER>3</VOUCHERNUMBER>" + "\r\n";
                xmlstc = xmlstc + "<VOUCHERNUMBER>" + VoucherNo + "</VOUCHERNUMBER>" + "\r\n";
                xmlstc = xmlstc + "<PARTYLEDGERNAME>" + DrAcc[0] + "</PARTYLEDGERNAME>" + "\r\n";
                xmlstc = xmlstc + "<BASICBASEPARTYNAME>" + DrAcc[0] + "</BASICBASEPARTYNAME>" + "\r\n";
                xmlstc = xmlstc + "<CSTFORMISSUETYPE/>" + "\r\n";
                xmlstc = xmlstc + "<CSTFORMRECVTYPE/>" + "\r\n";

                xmlstc = xmlstc + "<FBTPAYMENTTYPE>Default</FBTPAYMENTTYPE>" + "\r\n";
                xmlstc = xmlstc + "<PERSISTEDVIEW>Invoice Voucher View</PERSISTEDVIEW>" + "\r\n";
                xmlstc = xmlstc + "<PLACEOFSUPPLY>Tamil Nadu</PLACEOFSUPPLY>" + "\r\n";
                xmlstc = xmlstc + "<BASICBUYERNAME>" + DrAcc[0] + "</BASICBUYERNAME>" + "\r\n";
                //xmlstc = xmlstc + "<BASICDATETIMEOFINVOICE>1-Sep-2017 at 13:05</BASICDATETIMEOFINVOICE>" + "\r\n";
                //xmlstc = xmlstc + "<BASICDATETIMEOFREMOVAL>1-Sep-2017 at 13:05</BASICDATETIMEOFREMOVAL>" + "\r\n";

                xmlstc = xmlstc + "<BASICDATETIMEOFINVOICE>1-Sep-2017</BASICDATETIMEOFINVOICE>" + "\r\n";
                xmlstc = xmlstc + "<BASICDATETIMEOFREMOVAL>1-Sep-2017</BASICDATETIMEOFREMOVAL>" + "\r\n";
                xmlstc = xmlstc + "<VCHGSTCLASS/>" + "\r\n";

                xmlstc = xmlstc + "<CONSIGNEESTATENAME>Tamil Nadu</CONSIGNEESTATENAME>" + "\r\n";
                xmlstc = xmlstc + "<DIFFACTUALQTY>No</DIFFACTUALQTY>" + "\r\n";
                xmlstc = xmlstc + "<ISMSTFROMSYNC>No</ISMSTFROMSYNC>" + "\r\n";
                xmlstc = xmlstc + "<ASORIGINAL>No</ASORIGINAL>" + "\r\n";
                xmlstc = xmlstc + "<AUDITED>No</AUDITED>" + "\r\n";
                xmlstc = xmlstc + "<FORJOBCOSTING>No</FORJOBCOSTING>" + "\r\n";
                xmlstc = xmlstc + "<ISOPTIONAL>No</ISOPTIONAL>" + "\r\n";
                //xmlstc = xmlstc + "<EFFECTIVEDATE>" + Date + "</EFFECTIVEDATE>" + "\r\n";//Date
                //xmlstc = xmlstc + "<EFFECTIVEDATE>20170901</EFFECTIVEDATE>" + "\r\n";//Date
                //xmlstc = xmlstc + "<EFFECTIVEDATE>20170812</EFFECTIVEDATE>" + "\r\n";//Date
                xmlstc = xmlstc + "<EFFECTIVEDATE>" + "20170902" + "</EFFECTIVEDATE>" + "\r\n";

                xmlstc = xmlstc + "<USEFOREXCISE>No</USEFOREXCISE>" + "\r\n";
                xmlstc = xmlstc + "<ISFORJOBWORKIN>No</ISFORJOBWORKIN>" + "\r\n";
                xmlstc = xmlstc + "<ALLOWCONSUMPTION>No</ALLOWCONSUMPTION>" + "\r\n";

                xmlstc = xmlstc + "<USEFORINTEREST>No</USEFORINTEREST>" + "\r\n";
                xmlstc = xmlstc + "<USEFORGAINLOSS>No</USEFORGAINLOSS>" + "\r\n";
                xmlstc = xmlstc + "<USEFORGODOWNTRANSFER>No</USEFORGODOWNTRANSFER>" + "\r\n";
                xmlstc = xmlstc + "<USEFORCOMPOUND>No</USEFORCOMPOUND>" + "\r\n";
                xmlstc = xmlstc + "<USEFORSERVICETAX>No</USEFORSERVICETAX>" + "\r\n";

                xmlstc = xmlstc + "<ISEXCISEVOUCHER>No</ISEXCISEVOUCHER>" + "\r\n";
                xmlstc = xmlstc + "<EXCISETAXOVERRIDE>No</EXCISETAXOVERRIDE>" + "\r\n";
                xmlstc = xmlstc + "<USEFORTAXUNITTRANSFER>No</USEFORTAXUNITTRANSFER>" + "\r\n";
                xmlstc = xmlstc + "<EXCISEOPENING>No</EXCISEOPENING>" + "\r\n";
                xmlstc = xmlstc + "<USEFORFINALPRODUCTION>No</USEFORFINALPRODUCTION>" + "\r\n";


                xmlstc = xmlstc + "<ISTDSOVERRIDDEN>No</ISTDSOVERRIDDEN>" + "\r\n";
                xmlstc = xmlstc + "<ISTCSOVERRIDDEN>No</ISTCSOVERRIDDEN>" + "\r\n";
                xmlstc = xmlstc + "<ISTDSTCSCASHVCH>No</ISTDSTCSCASHVCH>" + "\r\n";

                xmlstc = xmlstc + "<INCLUDEADVPYMTVCH>No</INCLUDEADVPYMTVCH>" + "\r\n";
                xmlstc = xmlstc + "<ISSUBWORKSCONTRACT>No</ISSUBWORKSCONTRACT>" + "\r\n";
                xmlstc = xmlstc + "<ISVATOVERRIDDEN>No</ISVATOVERRIDDEN>" + "\r\n";
                xmlstc = xmlstc + "<IGNOREORIGVCHDATE>No</IGNOREORIGVCHDATE>" + "\r\n";
                xmlstc = xmlstc + "<ISSERVICETAXOVERRIDDEN>No</ISSERVICETAXOVERRIDDEN>" + "\r\n";

                xmlstc = xmlstc + "<ISISDVOUCHER>No</ISISDVOUCHER>" + "\r\n";
                xmlstc = xmlstc + "<ISEXCISEOVERRIDDEN>No</ISEXCISEOVERRIDDEN>" + "\r\n";
                xmlstc = xmlstc + "<ISEXCISESUPPLYVCH>No</ISEXCISESUPPLYVCH>" + "\r\n";
                xmlstc = xmlstc + "<ISGSTOVERRIDDEN>No</ISGSTOVERRIDDEN>" + "\r\n";
                xmlstc = xmlstc + "<GSTNOTEXPORTED>No</GSTNOTEXPORTED>" + "\r\n";
                xmlstc = xmlstc + "<ISVATPRINCIPALACCOUNT>No</ISVATPRINCIPALACCOUNT>" + "\r\n";
                xmlstc = xmlstc + "<ISSHIPPINGWITHINSTATE>No</ISSHIPPINGWITHINSTATE>" + "\r\n";


                xmlstc = xmlstc + "<ISCANCELLED>No</ISCANCELLED>" + "\r\n";
                xmlstc = xmlstc + "<HASCASHFLOW>No</HASCASHFLOW>" + "\r\n";
                xmlstc = xmlstc + "<ISPOSTDATED>No</ISPOSTDATED>" + "\r\n";
                xmlstc = xmlstc + "<USETRACKINGNUMBER>No</USETRACKINGNUMBER>" + "\r\n";
                xmlstc = xmlstc + "<ISINVOICE>Yes</ISINVOICE>" + "\r\n";

                xmlstc = xmlstc + "<MFGJOURNAL>No</MFGJOURNAL>" + "\r\n";
                xmlstc = xmlstc + "<HASDISCOUNTS>No</HASDISCOUNTS>" + "\r\n";
                xmlstc = xmlstc + "<ASPAYSLIP>No</ASPAYSLIP>" + "\r\n";
                xmlstc = xmlstc + "<ISCOSTCENTRE>No</ISCOSTCENTRE>" + "\r\n";
                xmlstc = xmlstc + "<ISSTXNONREALIZEDVCH>No</ISSTXNONREALIZEDVCH>" + "\r\n";
                xmlstc = xmlstc + "<ISEXCISEMANUFACTURERON>No</ISEXCISEMANUFACTURERON>" + "\r\n";
                xmlstc = xmlstc + "<ISBLANKCHEQUE>No</ISBLANKCHEQUE>" + "\r\n";

                xmlstc = xmlstc + "<ISVOID>No</ISVOID>" + "\r\n";
                xmlstc = xmlstc + "<ISONHOLD>No</ISONHOLD>" + "\r\n";
                xmlstc = xmlstc + "<ORDERLINESTATUS>No</ORDERLINESTATUS>" + "\r\n";

                xmlstc = xmlstc + "<VATISAGNSTCANCSALES>No</VATISAGNSTCANCSALES>" + "\r\n";
                xmlstc = xmlstc + "<VATISPURCEXEMPTED>No</VATISPURCEXEMPTED>" + "\r\n";
                xmlstc = xmlstc + "<ISVATRESTAXINVOICE>No</ISVATRESTAXINVOICE>" + "\r\n";
                xmlstc = xmlstc + "<VATISASSESABLECALCVCH>No</VATISASSESABLECALCVCH>" + "\r\n";

                xmlstc = xmlstc + "<ISVATDUTYPAID>Yes</ISVATDUTYPAID>" + "\r\n";
                xmlstc = xmlstc + "<ISDELIVERYSAMEASCONSIGNEE>No</ISDELIVERYSAMEASCONSIGNEE>" + "\r\n";
                xmlstc = xmlstc + "<ISDISPATCHSAMEASCONSIGNOR>No</ISDISPATCHSAMEASCONSIGNOR>" + "\r\n";
                xmlstc = xmlstc + "<ISDELETED>No</ISDELETED>" + "\r\n";
                xmlstc = xmlstc + "<CHANGEVCHMODE>No</CHANGEVCHMODE>" + "\r\n";
                xmlstc = xmlstc + "<ALTERID>No</ALTERID>" + "\r\n";
                xmlstc = xmlstc + "<MASTERID>No</MASTERID>" + "\r\n";
                //xmlstc = xmlstc + "<VOUCHERKEY>184589104447504</VOUCHERKEY>" + "\r\n";

                //xmlstc = xmlstc + "<CURRPARTYLEDGERNAME>ARCUS AUTOMATION PRIVATE LIMITED</CURRPARTYLEDGERNAME>" + "\r\n";
                //xmlstc = xmlstc + "<CURRBASICBUYERNAME>ARCUS AUTOMATION PRIVATE LIMITED</CURRBASICBUYERNAME>" + "\r\n";
                //xmlstc = xmlstc + "<CURRPARTYNAME>ARCUS AUTOMATION PRIVATE LIMITED</CURRPARTYNAME>" + "\r\n";
                //xmlstc = xmlstc + "<CURRBASICPURCHASEORDERNO/>" + "\r\n";
                //xmlstc = xmlstc + "<CURRBASICSHIPDELIVERYNOTE/>" + "\r\n";

                xmlstc = xmlstc + "<EXCLUDEDTAXATIONS.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<OLDAUDITENTRIES.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<ACCOUNTAUDITENTRIES.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<AUDITENTRIES.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<DUTYHEADDETAILS.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<SUPPLEMENTARYDUTYHEADDETAILS.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<INVOICEDELNOTES.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<INVOICEORDERLIST.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<INVOICEINDENTLIST.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<ATTENDANCEENTRIES.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<ORIGINVOICEDETAILS.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<INVOICEEXPORTLIST.LIST/>" + "\r\n";// end




                //LEDGER-START
                xmlstc = xmlstc + "<LEDGERENTRIES.LIST>" + "\r\n";
                xmlstc = xmlstc + "<OLDAUDITENTRYIDS.LIST TYPE=" + "\"" + "Number" + "\">" + "\r\n";//vtype
                xmlstc = xmlstc + "<OLDAUDITENTRYIDS>1</OLDAUDITENTRYIDS>" + "\r\n";
                xmlstc = xmlstc + "</OLDAUDITENTRYIDS.LIST>" + "\r\n";// end

                //xmlstc = xmlstc + "<LEDGERNAME>ARCUS AUTOMATION PRIVATE LIMITED</LEDGERNAME>" + "\r\n";
                xmlstc = xmlstc + "<LEDGERNAME>" + DrAcc[0] + "</LEDGERNAME>" + "\r\n";
                xmlstc = xmlstc + "<GSTCLASS/>" + "\r\n";
                xmlstc = xmlstc + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + "\r\n";
                xmlstc = xmlstc + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + "\r\n";
                xmlstc = xmlstc + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + "\r\n";

                xmlstc = xmlstc + "<ISPARTYLEDGER>Yes</ISPARTYLEDGER>" + "\r\n";
                xmlstc = xmlstc + "<ISLASTDEEMEDPOSITIVE>Yes</ISLASTDEEMEDPOSITIVE>" + "\r\n";
                //xmlstc = xmlstc + "<AMOUNT>-14530.65</AMOUNT>" + "\r\n";

                xmlstc = xmlstc + "<AMOUNT>" + "-" + debit[0] + "</AMOUNT>" + "\r\n";
                xmlstc = xmlstc + "<SERVICETAXDETAILS.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<BANKALLOCATIONS.LIST/>" + "\r\n";

                //xmlstc = xmlstc + "<BILLALLOCATIONS.LIST>" + "\r\n";//stop
                //xmlstc = xmlstc + "<NAME>No</NAME>" + "\r\n";
                //xmlstc = xmlstc + "<BILLTYPE>New Ref</BILLTYPE>" + "\r\n";
                //xmlstc = xmlstc + "<TDSDEDUCTEEISSPECIALRATE>No</TDSDEDUCTEEISSPECIALRATE>" + "\r\n";
                //xmlstc = xmlstc + "<AMOUNT>26000.00</AMOUNT>" + "\r\n";
                //xmlstc = xmlstc + "<INTERESTCOLLECTION.LIST/>" + "\r\n";
                //xmlstc = xmlstc + "<STBILLCATEGORIES.LIST/>" + "\r\n";
                //xmlstc = xmlstc + "</BILLALLOCATIONS.LIST>" + "\r\n";

                xmlstc = xmlstc + "<BILLALLOCATIONS.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<INTERESTCOLLECTION.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<OLDAUDITENTRIES.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<ACCOUNTAUDITENTRIES.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<ACCOUNTAUDITENTRIES.LIST/>" + "\r\n";
                //xmlstc = xmlstc + "<AUDITENTRIES.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<INPUTCRALLOCS.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<DUTYHEADDETAILS.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<EXCISEDUTYHEADDETAILS.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<RATEDETAILS.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<SUMMARYALLOCS.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<STPYMTDETAILS.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<EXCISEPAYMENTALLOCATIONS.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<TAXBILLALLOCATIONS.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<TAXOBJECTALLOCATIONS.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<TDSEXPENSEALLOCATIONS.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<VATSTATUTORYDETAILS.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<COSTTRACKALLOCATIONS.LIST/>" + "\r\n";

                xmlstc = xmlstc + "<REFVOUCHERDETAILS.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<INVOICEWISEDETAILS.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<VATITCDETAILS.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<ADVANCETAXDETAILS.LIST/>" + "\r\n";
                xmlstc = xmlstc + "</LEDGERENTRIES.LIST>" + "\r\n";


                //LEDGER-START

                for (int i = 0; i <= incr - 1; i++)
                {
                    if (DrAcc[i] != "" || DrAcc[i] != null)
                    {

                        xmlstc = xmlstc + "<LEDGERENTRIES.LIST>" + "\r\n";
                        //xmlstc = xmlstc + "<LEDGERNAME>TRANSPORT CHARGES</LEDGERNAME>" + "\r\n";
                        //xmlstc = xmlstc + "<LEDGERNAME>" + CrAcc[i].Replace("&","and") + "</LEDGERNAME>" + "\r\n";

                        xmlstc = xmlstc + "<LEDGERNAME>" + CrAcc[i].Replace("&", "&amp;") + "</LEDGERNAME>" + "\r\n";
                        xmlstc = xmlstc + "<VOUCHERFBTCATEGORY/>" + "\r\n";
                        xmlstc = xmlstc + "<GSTCLASS/>" + "\r\n";
                        xmlstc = xmlstc + "<GSTOVRDNNATURE>Sales Taxable</GSTOVRDNNATURE>" + "\r\n";
                        //xmlstc = xmlstc + "<GSTOVRDNISREVCHARGEAPPL> Not Applicable</GSTOVRDNISREVCHARGEAPPL>" + "\r\n";
                        xmlstc = xmlstc + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + "\r\n";
                        xmlstc = xmlstc + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + "\r\n";
                        xmlstc = xmlstc + "<ISPARTYLEDGER>No</ISPARTYLEDGER>" + "\r\n";
                        xmlstc = xmlstc + "<ISLASTDEEMEDPOSITIVE>No</ISLASTDEEMEDPOSITIVE>" + "\r\n";
                        //xmlstc = xmlstc + "<AMOUNT>25000.00</AMOUNT>" + "\r\n";
                        //xmlstc = xmlstc + "<VATEXPAMOUNT>25000.00</VATEXPAMOUNT>" + "\r\n";

                        xmlstc = xmlstc + "<AMOUNT>" + credit[i] + "</AMOUNT>" + "\r\n";
                        xmlstc = xmlstc + "<VATEXPAMOUNT>" + credit[i] + "</VATEXPAMOUNT>" + "\r\n";

                        xmlstc = xmlstc + "<SERVICETAXDETAILS.LIST/>" + "\r\n";
                        xmlstc = xmlstc + "<BANKALLOCATIONS.LIST/>" + "\r\n";
                        xmlstc = xmlstc + "<BILLALLOCATIONS.LIST/>" + "\r\n";
                        xmlstc = xmlstc + "<INTERESTCOLLECTION.LIST/>" + "\r\n";
                        xmlstc = xmlstc + "<OLDAUDITENTRIES.LIST/>" + "\r\n";
                        xmlstc = xmlstc + "<ACCOUNTAUDITENTRIES.LIST/>" + "\r\n";
                        xmlstc = xmlstc + "<AUDITENTRIES.LIST/>" + "\r\n";
                        xmlstc = xmlstc + "<INPUTCRALLOCS.LIST/>" + "\r\n";
                        //xmlstc = xmlstc + "<INVENTORYALLOCATIONS.LIST/>" + "\r\n";
                        xmlstc = xmlstc + "<DUTYHEADDETAILS.LIST/>" + "\r\n";
                        xmlstc = xmlstc + "<EXCISEDUTYHEADDETAILS.LIST/>" + "\r\n";

                        xmlstc = xmlstc + "<RATEDETAILS.LIST>" + "\r\n";
                        xmlstc = xmlstc + "<GSTRATEDUTYHEAD>Integrated Tax</GSTRATEDUTYHEAD>" + "\r\n";
                        xmlstc = xmlstc + "<GSTRATEVALUATIONTYPE>Based on Value</GSTRATEVALUATIONTYPE>" + "\r\n";
                        xmlstc = xmlstc + "<GSTRATE>" + IGST_RATE[i] + "</GSTRATE>" + "\r\n";
                        xmlstc = xmlstc + "</RATEDETAILS.LIST>" + "\r\n";

                        xmlstc = xmlstc + "<RATEDETAILS.LIST>" + "\r\n";
                        xmlstc = xmlstc + "<GSTRATEDUTYHEAD>Central Tax</GSTRATEDUTYHEAD>" + "\r\n";
                        xmlstc = xmlstc + "<GSTRATEVALUATIONTYPE>Based on Value</GSTRATEVALUATIONTYPE>" + "\r\n";
                        xmlstc = xmlstc + "<GSTRATE>" + CGST_RATE[i] + "</GSTRATE>" + "\r\n";
                        xmlstc = xmlstc + "</RATEDETAILS.LIST>" + "\r\n";

                        xmlstc = xmlstc + "<RATEDETAILS.LIST>" + "\r\n";
                        xmlstc = xmlstc + "<GSTRATEDUTYHEAD>State  Tax</GSTRATEDUTYHEAD>" + "\r\n";
                        xmlstc = xmlstc + "<GSTRATEVALUATIONTYPE>Based on Value</GSTRATEVALUATIONTYPE>" + "\r\n";
                        xmlstc = xmlstc + "<GSTRATE>" + SGST_RATE[i] + "</GSTRATE>" + "\r\n";
                        xmlstc = xmlstc + "</RATEDETAILS.LIST>" + "\r\n";

                        xmlstc = xmlstc + "<RATEDETAILS.LIST>" + "\r\n";
                        xmlstc = xmlstc + "<GSTRATEDUTYHEAD>Cess</GSTRATEDUTYHEAD>" + "\r\n";
                        xmlstc = xmlstc + "<GSTRATEVALUATIONTYPE>Based on Value</GSTRATEVALUATIONTYPE>" + "\r\n";
                        xmlstc = xmlstc + "</RATEDETAILS.LIST>" + "\r\n";

                        xmlstc = xmlstc + "<SUMMARYALLOCS.LIST/>" + "\r\n";
                        xmlstc = xmlstc + "<STPYMTDETAILS.LIST/>" + "\r\n";
                        xmlstc = xmlstc + "<EXCISEPAYMENTALLOCATIONS.LIST/>" + "\r\n";
                        xmlstc = xmlstc + "<TAXBILLALLOCATIONS.LIST/>" + "\r\n";
                        xmlstc = xmlstc + "<TAXOBJECTALLOCATIONS.LIST/>" + "\r\n";
                        xmlstc = xmlstc + "<TDSEXPENSEALLOCATIONS.LIST/>" + "\r\n";
                        xmlstc = xmlstc + "<VATSTATUTORYDETAILS.LIST/>" + "\r\n";
                        xmlstc = xmlstc + "<COSTTRACKALLOCATIONS.LIST/>" + "\r\n";

                        xmlstc = xmlstc + "<REFVOUCHERDETAILS.LIST/>" + "\r\n";
                        xmlstc = xmlstc + "<INVOICEWISEDETAILS.LIST/>" + "\r\n";
                        xmlstc = xmlstc + "<VATITCDETAILS.LIST/>" + "\r\n";
                        xmlstc = xmlstc + "<ADVANCETAXDETAILS.LIST/>" + "\r\n";


                        xmlstc = xmlstc + "<UDF:USERDESCRIPTION.LIST DESC=" + "\"" + "`User Description`" + "\" ISLIST=" + "\"" + "YES" + "\" TYPE=" + "\"" + "String" + "\" INDEX=" + "\"" + "29" + "\">" + "\r\n";//vtype

                        if (UserDesc[i] != "")
                        {
                            if (UserDesc[i].Length > 25)
                            {
                                int cnt = UserDesc[i].Length - 1;
                                string a1 = UserDesc[i].Substring(0, 25);
                                string a2 = UserDesc[i].Remove(0, 25);

                                xmlstc = xmlstc + "<UDF:USERDESCRIPTION DESC=" + "\"" + "`User Description`" + "\">" + a1 + "</UDF:USERDESCRIPTION" + ">" + "\r\n";
                                xmlstc = xmlstc + "<UDF:USERDESCRIPTION DESC=" + "\"" + "`User Description`" + "\">" + a2 + "</UDF:USERDESCRIPTION" + ">" + "\r\n";
                            }
                            else
                            {
                                xmlstc = xmlstc + "<UDF:USERDESCRIPTION DESC=" + "\"" + "`User Description`" + "\">" + UserDesc[i] + "</UDF:USERDESCRIPTION" + ">" + "\r\n";
                            }
                        }

                        //xmlstc = xmlstc + "<UDF:USERDESCRIPTION DESC=" + "\"" + "`User Description`" + "\">" + "DESCH</UDF:USERDESCRIPTION" + ">" + "\r\n";//vtype
                        //xmlstc = xmlstc + "<UDF:USERDESCRIPTION DESC=" + "\"" + "`User Description`" + "\">" + "IURTY98769856759876854ghgkjdghfdhgfd89745jhjh87y5ihgjfhg874568ghbfjhg8745</UDF:USERDESCRIPTION" + ">" + "\r\n";//vtype

                        xmlstc = xmlstc + "</UDF:USERDESCRIPTION.LIST>" + "\r\n";
                      
                         
                        xmlstc = xmlstc + "</LEDGERENTRIES.LIST>" + "\r\n";
                    }
                }

                xmlstc = xmlstc + "<ALLINVENTORYENTRIES.LIST/>" + "\r\n";
                //xmlstc = xmlstc + "<VCHLEDTOTALTREE.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<PAYROLLMODEOFPAYMENT.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<ATTDRECORDS.LIST/>" + "\r\n";
                xmlstc = xmlstc + "<TEMPGSTRATEDETAILS.LIST/>" + "\r\n";
                xmlstc = xmlstc + "</VOUCHER>" + "\r\n";
                xmlstc = xmlstc + "</TALLYMESSAGE>" + "\r\n";

                xmlstc = xmlstc + "</REQUESTDATA>" + "\r\n";
                xmlstc = xmlstc + "</IMPORTDATA>" + "\r\n";
                xmlstc = xmlstc + "</BODY>" + "\r\n";
                xmlstc = xmlstc + "</ENVELOPE>" + "\r\n";

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:9000/");
                httpWebRequest.Method = "POST";

                //httpWebRequest.ContentLength = xmlstc.Length;
                //httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                //StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream());
                //streamWriter.Write(xmlstc);
                //DataSet dss = new DataSet();
                //dss.stre(xmlstc);

                string postData = xmlstc;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(postData);

                string localDestnDir = "";
                string ftpFolder1 = "";

                if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "10")
                {
                     ftpFolder1 = "/ROYAL/";
                }
                else if (HttpContext.Current.Session["COMPANY_ID"].ToString() == "2")
                {
                     ftpFolder1 = "/ORIENTAL/";
                }
                else
                {
                     ftpFolder1 = "/UNKNOWN/";
                }
              
                localDestnDir = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() +"/" + HttpContext.Current.Session["currentuser"].ToString()+ "/" + "TALLY" + "/");

                if (Directory.Exists(localDestnDir + "/" + ftpFolder1))
                {

                }
                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(localDestnDir + "/" + ftpFolder1);
                }

                if (Directory.Exists(localDestnDir + "/" + ftpFolder1 + "/" + "Log"))
                {

                }
                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(localDestnDir + "/" + ftpFolder1 + "/" + "Log");
                }

                //XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.LoadXml(postData);
                //xmlDoc.Save(localDestnDir + "/" + "ROYAL" + "/" + FileRefNo + ".xml");
                xmlDoc.Save(localDestnDir + "/" + ftpFolder1 + "/" + VoucherNo.Replace("/", "-") + ".xml");


                ////*********************************************************
                //string ftp = "ftp://ftp.efreightsuite.com/";
                //string uname = "hanscha";
                //string pwd = "gOoRsT";
                //string ftpFolder1 = "/TEST/";

                string ftp = "ftp://115.112.232.213:21/";
                string uname = "ftpuser";
                string pwd = "rtstallypost@#1234#@";

                //string ftp = "ftp://mazedemo.3utilities.com:2121/";
                //string uname = "tally";
                //string pwd = "tally123";

                byte[] fileBytes = null;
                string fileName1 = Path.GetFileName(localDestnDir + "/" + ftpFolder1 + VoucherNo.Replace("/", "-") + ".xml");
               
                using (StreamReader fileStream = new StreamReader(localDestnDir + "/" + ftpFolder1 + VoucherNo.Replace("/", "-") + ".xml"))
                {
                    fileBytes = Encoding.UTF8.GetBytes(fileStream.ReadToEnd());
                    fileStream.Close();
                }
                try
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder1 + "/" + "TallyPost" + "/" + fileName1);
                    request.Credentials = new NetworkCredential(uname, pwd);
                    //request.Method = WebRequestMethods.Ftp.MakeDirectory;

                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.ContentLength = fileBytes.Length;
                    request.UsePassive = true;
                    request.UseBinary = true;

                    request.ServicePoint.ConnectionLimit = fileBytes.Length;
                    request.EnableSsl = false;

                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(fileBytes, 0, fileBytes.Length);
                        requestStream.Close();
                    }

                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    response.Close();
                }
                catch (WebException ex)
                {
                    throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
                }
            }
            catch (Exception ex)
            {
                ReturnMessage = "<b>Error Message:</b>" + ex.Message + "<br/><br/> <b>StackTrace:</b>" + ex.StackTrace;
            }

            return ReturnMessage;
        }
    }   
}