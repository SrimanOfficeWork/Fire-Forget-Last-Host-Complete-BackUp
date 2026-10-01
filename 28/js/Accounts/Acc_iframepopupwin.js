var win = null;

//------------------------MASTER START-------------------------------------------
function open_GST_Add_New_Party_N(val) {
    w = '470';
    h = '240';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('NewParty', 'iframe', '../Accounts_Master/NewParty.aspx', '', settings)
}
function open_Party_Master_N(val) {
    w = '1203';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Party Master', 'iframe', '../Accounts_Master/Party_Master.aspx', '', settings)
}
/*
function open_Party_Master_Upd(val, val2) {
    w = '1203';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Party Master', 'iframe', '../Accounts_Master/Party_Master.aspx?Page=' + escape(val) + '&Brno=' + val2 + '', '', settings)
}
*/
function open_Party_Master_Upd(val, val2, val3) {
    w = '1203';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Party Master', 'iframe', '../Accounts_Master/Party_Master.aspx?Page=' + escape(val) + '&Brno=' + val2 + '&Part_Id=' + val3 + '', '', settings)
}

function open_chargemaster_N() {
    adcodewindow = dhtmlmodal.open('Charge Master', 'iframe', '../Accounts_Master/Charge_Master.aspx', '', NewWindow('700', '500'))
}
function open_chargemaster_Upd(val) {

    adcodewindow = dhtmlmodal.open('Charge Master', 'iframe', '../Accounts_Master/Charge_Master.aspx?CHARGE_ID=' + val + '', '', NewWindow('700', '500'))
}
function open_Party_Master_Cr_Limit_N(val) {
    w = '1203';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Accounts_Master/Party_Credit_Limit.aspx', '', settings)
}
function open_Party_Master_Cr_Limit_Upd(val) {
    w = '1203';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Accounts_Master/Party_Credit_Limit.aspx?Page=' + escape(val) + '', '', settings)
}
function opennew_Expense_chargemaster_N() {
    adcodewindow = dhtmlmodal.open('Expense Charge Master', 'iframe', '../Accounts_Master/Expense_Charge_Master.aspx', '', NewWindow('457', '480'))
}
function opennew_Expense_chargemaster_Upd(val) {
    adcodewindow = dhtmlmodal.open('Expense Charge Master', 'iframe', '../Accounts_Master/Expense_Charge_Master.aspx?CHARGE_ID=' + val + '', '', NewWindow('457', '480'))
}
function opennew_Vendormaster_N(val) {
    w = '1200'; //'1305';
    h = '585';  //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Accounts_Master/Vendor_Master.aspx', '', settings)
}
function open_VendorMaster_Search_Upd(val, val2) {

    w = '1200';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Vendor', 'iframe', '../Accounts_Master/Vendor_Master.aspx?Page=' + escape(val) + '&PageVendorcode=' + val2 + '', '', settings)
}

function opennew_Staff_Master_N() {
    adcodewindow = dhtmlmodal.open('Staff Master', 'iframe', '../Accounts_Master/Staff_Master.aspx', '', NewWindow('765', '440'))
}
function opennew_Staff_Master_Upd(val) {
    adcodewindow = dhtmlmodal.open('Staff Master', 'iframe', '../Accounts_Master/Staff_Master.aspx?STAFF_ID=' + val + '', '', NewWindow('765', '440'))
}
function open_Staff_Master_Debit_Cr_N() {
    adcodewindow = dhtmlmodal.open('Staff Master', 'iframe', '../Accounts_Master/Staff_Master_prvscr_debit_entry.aspx', '', NewWindow('550', '350'))
}
function open_Staff_Master_Debit_Cr_Upd(val) {
    adcodewindow = dhtmlmodal.open('Staff Master', 'iframe', '../Accounts_Master/Staff_Master_prvscr_debit_entry.aspx?STAFF_PR_CR_ID=' + val + '', '', NewWindow('550', '350'))
}
//------------------------MASTER END-------------------------------------------
//------------------------Expense Start-------------------------------------------
function open_Expense_PaymentEntry_N() {
    w = '1150';
    h = '615';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Expense Entry', 'iframe', '../Accounts_Expense/Expense_Payment_Entry.aspx', '', settings)
}
function open_Expense_PaymentEntry_Upd(val, val2) {
    w = '1150';
    h = '630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Expense Entry', 'iframe', '../Accounts_Expense/Expense_Payment_Entry.aspx?Page=' + escape(val) + '&Billinvno=' + val2 + '', '', settings)
}
//------------------------Expense End-------------------------------------------
//------------------------Purchase Start-------------------------------------------
function open_PurchaseEntry_N(val) {
    w = '1200';
    h = '580';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Purchase Entry', 'iframe', '../Accounts_Purchase/PurchaseEntry.aspx', '', settings)
}
function open_PurchaseEntry_Upd(val2) {
    w = '1200'; //1305
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Purchase Entry', 'iframe', '../Accounts_Purchase/PurchaseEntry.aspx?voucherno=' + val2 + '', '', settings)
}
function open_Payment_N(val) {

    w = '1240'//'1100';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Payment Entry', 'iframe', '../Accounts_Purchase/PaymentEntry.aspx', '', settings)
}
function open_Payment_Upd(val, val2) {
    w = '1240'; //'1100';
    h = '570'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Payment Entry', 'iframe', '../Accounts_Purchase/PaymentEntry.aspx?Page=' + escape(val) + '&Billinvno=' + val2 + '', '', settings)
}
function open_DebitNote_N(val) {
    w = '1200';
    h = '550';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('DebitNote Entry', 'iframe', '../Accounts_Purchase/DebitNoteEntry.aspx', '', settings)
}
function open_DebitNote_Upd(val2) {
    w = '1200';
    h = '550';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('DebitNote Entry', 'iframe', '../Accounts_Purchase/DebitNoteEntry.aspx?DebitNote_No=' + val2 + '', '', settings)
}
//------------------------Purchase End-------------------------------------------
//------------------------Sales Start-------------------------------------------
function open_GST_Sales_Entry_N(val) {
    w = '1200';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Sales Entry', 'iframe', '../Accounts_Sales/GST_Sales_Entry.aspx', '', settings)
}
function open_GST_Sales_Entry_Upd(val, val2, val3) {
    w = '1200';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Sales Entry', 'iframe', '../Accounts_Sales/GST_Sales_Entry.aspx?Page=' + val + '&IMP_EXP=' + val2 + '&Billinvno=' + escape(val3) + '', '', settings)
}
function open_GST_Credit_Note_Entry_N(val) {
    w = '1200';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Credit Note Entry', 'iframe', '../Accounts_Sales/GST_Credit_Note_Entry.aspx', '', settings)
}

function open_GST_Credit_Note_Entry_Upd(val, val2, val3) {
    w = '1200';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Credit Note Entry', 'iframe', '../Accounts_Sales/GST_Credit_Note_Entry.aspx?Page=' + val + '&IMP_EXP=' + val2 + '&Billinvno=' + escape(val3) + '', '', settings)
}

function open_Receipt_Entry_RC_N(val) {

    w = '1150'//'1100';
    h = '570';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Bank Receipt Entry', 'iframe', '../Accounts_Bank/ReceiptEntry.aspx', '', settings)
}
function open_Receipt_Entry_RC_N_Upd(val, val2) {
    w = '1150'; //'1100';
    h = '570'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Receipt Entry', 'iframe', '../Accounts_Bank/ReceiptEntry.aspx?R_ID=' + escape(val) + '&R_Billinvno=' + val2 + '', '', settings)
}
function open_Receipt_Entry_Upd(val, val2) {
    w = '1290'; //'1100';
    h = '570'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Receipt Entry', 'iframe', '../Accounts_Bank/ReceiptEntry.aspx?R_ID=' + escape(val) + '&R_Billinvno=' + val2 + '', '', settings)
}

//------------------------Sales End-------------------------------------------
function open_Imp_Exp_Expense_Amt(val) {
    w = '1100'; //'1100';
    h = '500'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 5 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 80 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    var Job_no;
    var InvoiceNo = document.getElementById("txtInvoiceNo").value;
    var I_E = document.getElementById("HDupdate_IMP_EXP_id").value;
    // adcodewindow = dhtmlmodal.open('Expense', 'iframe', '../Accounts_Sales/Expense_Entry.aspx?Job_no=' + Job_no + ' &Type=' + I_E + '', '', 'width=1100px, height=500px,margin-left=70px,margin-top=20px,resize=0, scrolling=0')
    adcodewindow = dhtmlmodal.open('Expense', 'iframe', '../Accounts_Sales/Expense_Entry.aspx?InvoiceNo=' + InvoiceNo + ' &I_E=' + I_E + '', '', settings)
}
function open_Imp_Exp_Annexure_Amt(val) {
    w = '1100'; 
    h = '500';
    LeftPosition = (screen.width) ? (screen.width - w) / 5 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 80 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
   
    var Inv_no = document.getElementById("txtInvoiceNo").value;
    var I_E = document.getElementById("Hd_I_E").value;
    adcodewindow = dhtmlmodal.open('Expense', 'iframe', '../Accounts_Sales/GST_Annexure_Entry.aspx?Inv_no=' + Inv_no + ' &IMP_EXP=' + I_E + '', '', settings)
}

function GST_Billing_Job_Rpt() {
    var Job_Id = document.getElementById("HDupdate_id").value;
    var Imp_Exp = document.getElementById("HDupdate_IMP_EXP_id").value;
    var Bill_Inv_No = document.getElementById("txtInvoiceNo").value;

    if (Job_Id != '') {
        NewWindow1('../Accounts_Sales_Inv_Rpt/GST_Imp_Exp_rpt.aspx?Job_Id=' + Job_Id + '&Imp_Exp=' + Imp_Exp + '&Bill_Inv_No=' + Bill_Inv_No + '', 'List', '870', '1024', 'yes');
    }
    else {
        jAlert('Save Report after Generate', 'Bill Invoice', function (r) { document.getElementById("ddlCus_name").focus(); });
    }
}
function GST_Billing_Cr_Inv_Rpt() {
    var Job_Id = document.getElementById("HDupdate_id").value;
    var Imp_Exp = document.getElementById("HDupdate_IMP_EXP_id").value;
    var Bill_Inv_No = document.getElementById("txtInvoiceNo").value;

    if (Job_Id != '') {
        NewWindow1('../Accounts_Invoice_Rpt/GST_Credit_Note_rpt.aspx?Job_Id=' + Job_Id + '&Imp_Exp=' + Imp_Exp + '&Bill_Inv_No=' + Bill_Inv_No + '', 'List', '870', '1024', 'yes');
    }
    else {
        jAlert('Save Report after Generate', 'Bill Invoice', function (r) { document.getElementById("ddlCus_name").focus(); });
    }
}
//---------------------------------------------

function open_GST_Quotation_N(val) {
    w = '1200';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Quotation Master Entry', 'iframe', '../Accounts_Master/Quotation_Master_Entry.aspx', '', settings)
}
function open_GST_Quotation_Upd(val, val2, val3) {
    w = '1200';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Quotation Master Entry', 'iframe', '../Accounts_Master/Quotation_Master_Entry.aspx?Page=' + val + '&IMP_EXP=' + val2 + '&TR_MODE=' + val3 + '', '', settings)
}
function open_GST_Combined_Pending_Bill(Val) {
    w = '925';
    h = '550';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Billing', 'iframe', '../Accounts_Sales/Pending_Invoice_ListPopup.aspx?Page=' + Val + '', '', settings)
}
function open_Capital_Acc_Master_N() {
    adcodewindow = dhtmlmodal.open('Capital Account Master', 'iframe', '../Accounts_Master/Capital_Account_Master.aspx', '', NewWindow('500', '500'))
}
function open_Capital_Acc_Master_Upd(val) {
    adcodewindow = dhtmlmodal.open('Capital Account Master', 'iframe', '../Accounts_Master/Capital_Account_Master.aspx?C_ID=' + val + '', '', NewWindow('500', '500'))
}

function open_groupmaster_N() {
    adcodewindow = dhtmlmodal.open('Group Master', 'iframe', '../Accounts_Master/Group_Master.aspx', '', NewWindow('500', '500'))
}

function open_groupmaster_Upd(val) {

    adcodewindow = dhtmlmodal.open('Group Master', 'iframe', '../Accounts_Master/Group_Master.aspx?Page=' + escape(val) + '&GROUP_ID=' + val + '', '', NewWindow('500', '500'))
}

function open_bankmaster_N() {
    adcodewindow = dhtmlmodal.open('Bank Master', 'iframe', '../Accounts_Master/Bank_Master.aspx', '', NewWindow('800', '600'))
}

function open_bankmaster_Upd(val) {
    adcodewindow = dhtmlmodal.open('Bank Master', 'iframe', '../Accounts_Master/Bank_Master.aspx?Page=' + escape(val) + '&BANK_ID=' + val + '', '', NewWindow('800', '600'))
}

function open_JournalEntry_Upd(val, val2) {
    w = '1150';
    h = '600';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Journal Entry', 'iframe', '../Accounts_Expense/Journal_Entry.aspx?Page=' + escape(val) + '&Voc_no=' + val2 + '', '', settings)
}
function open_JournalEntry_N() {
    w = '1150';
    h = '600';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Journal Entry', 'iframe', '../Accounts_Expense/Journal_Entry.aspx', '', settings)
}


function open_Company_Master_N(val) {
    w = '1203';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Company Master', 'iframe', '../Accounts_Master/Acc_Company_Info.aspx', '', settings)
}
function open_Company_Master_Upd(val) {
    w = '1203';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Company Master', 'iframe', '../Accounts_Master/Acc_Company_Info.aspx?C_ID=' + escape(val) + '', '', settings)
}

function open_Staff_Master_N() {
    adcodewindow = dhtmlmodal.open('Staff Master', 'iframe', '../Accounts_Master/Staff_Master.aspx', '', NewWindow('765', '440'))
}

function open_Staff_Master_UPD(val) {
    adcodewindow = dhtmlmodal.open('Staff Master', 'iframe', '../Accounts_Master/Staff_Master.aspx?STAFF_ID=' + val + '', '', NewWindow('765', '440'))
}

function opennew_Staff_Suspense_Entry_N() {
    adcodewindow = dhtmlmodal.open('Suspense Entry', 'iframe', '../Accounts_Master/Staff_Suspense_Entry.aspx', '', NewWindow('550', '350'))
}
function opennew_Staff_Suspense_Entry_Upd(val) {
    adcodewindow = dhtmlmodal.open('Suspense Entry', 'iframe', '../Accounts_Master/Staff_Suspense_Entry.aspx?SUSP_ID=' + val + '', '', NewWindow('550', '350'))
}
function open_GST_Sales_Inv_Edit(val) {
    w = '760';
    h = '280';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Sales Billing', 'iframe', '../Accounts_Sales/GST_Invoice_No_Edit.aspx', '', settings)
}

function open_Billing_Party_Master_N(val) {
    w = '1160';
    h = '550';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Party Master', 'iframe', '../Accounts_Master/Billing_Party.aspx', '', settings)
}
function open_Billing_Party_Master_Upd(val) {
    w = '1160';
    h = '550';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Party Master', 'iframe', '../Accounts_Master/Billing_Party.aspx?Partyname=' + escape(val) + '', '', settings)
}

function open_Billing_Party_Master_PN(val) {
    w = '1160';
    h = '550';
    LeftPosition = (screen.width) ? (screen.width - w) / 7 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Party Master', 'iframe', '../Accounts_Master/Billing_Party.aspx', '', settings)
}
//-----------------------Cash----------------------------------------
function open_Cash_PaymentEntry_N() {
    w = '1150';
    h = '570';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Cash Payment Entry', 'iframe', '../Accounts_Cash/Cash_Payment_Entry.aspx', '', settings)
}
function open_Cash_PaymentEntry_Upd(val) {
    w = '1150';
    h = '570';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Cash Payment Entry', 'iframe', '../Accounts_Cash/Cash_Payment_Entry.aspx?CP_ID=' + escape(val) + '', '', settings)
}
//-----------------------Receipt----------------------------------------
function open_Receipt_PaymentEntry_N() {
    w = '1150';
    h = '570';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Receipt Payment Entry', 'iframe', '../Accounts_Cash/Receipt_Payment_Entry.aspx', '', settings)
}
function open_Receipt_PaymentEntry_Upd(val) {
    w = '1150';
    h = '570';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Receipt Payment Entry', 'iframe', '../Accounts_Cash/Receipt_Payment_Entry.aspx?RP_ID=' + escape(val) + '', '', settings)
}
//-----------------------Other----------------------------------------
function open_Journal_Entry_N() {
    w = '1150';
    h = '570';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Journal Entry', 'iframe', '../Accounts_Others/Journal_Entry.aspx', '', settings)
}
function open_Journal_Entry_Upd(val) {
    w = '1150';
    h = '570';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Journal Entry', 'iframe', '../Accounts_Others/Journal_Entry.aspx?JV_ID=' + escape(val) + '', '', settings)
}

function GST_Billing_Job_CR_Rpt() {
    var Job_Id = document.getElementById("HDupdate_id").value;
    var Imp_Exp = document.getElementById("HDupdate_IMP_EXP_id").value;
    var Bill_Inv_No = document.getElementById("txtInvoiceNo").value;

    if (Job_Id != '') {
        NewWindow1('../Accounts_Sales_Inv_Rpt/GST_Imp_Exp_CR_rpt.aspx?Job_Id=' + Job_Id + '&Imp_Exp=' + Imp_Exp + '&Bill_Inv_No=' + Bill_Inv_No + '', 'List', '870', '1024', 'yes');
    }
    else {
        jAlert('Save Report after Generate', 'Credit Bill Invoice', function (r) { document.getElementById("ddlCus_name").focus(); });
    }
}


function open_Receipt_Entry_Others() {

    w = '1150'//'1100';
    h = '570';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Bank Receipt Entry', 'iframe', '../Accounts_Bank/Other_Receipt_Entry.aspx', '', settings)
}

function open_Receipt_Entry_Others_Upd(val, val2) {
    w = '1150'; //'1100';
    h = '570'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Receipt Entry', 'iframe', '../Accounts_Bank/Other_Receipt_Entry.aspx?R_ID=' + escape(val) + '&R_Billinvno=' + val2 + '', '', settings)
}
function open_Receipt_Entry_Cash_Dep() {

    w = '1150'//'1100';
    h = '270';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Bank Receipt Entry', 'iframe', '../Accounts_Bank/Receipt_Entry_Cash_Deposite.aspx', '', settings)
}

function open_Receipt_Entry_Cash_Dep_Upd(val, val2) {
    w = '1150'; //'1100';
    h = '270'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Receipt Entry', 'iframe', '../Accounts_Bank/Receipt_Entry_Cash_Deposite.aspx?R_ID=' + escape(val) + '&R_Billinvno=' + val2 + '', '', settings)
}

function open_PaymentEntry_Deb(val, val2) {
    w = '1150'//'1100';
    h = '570';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Bank Receipt Entry', 'iframe', '../Accounts_Bank/Payment_Entry_Debitors.aspx', '', settings)
}
function open_PaymentEntry_Deb_Upd(val, val2) {
    w = '1150'; //'1100';
    h = '570'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Payment Entry', 'iframe', '../Accounts_Bank/Payment_Entry_Debitors.aspx?R_ID=' + escape(val) + '&R_Billinvno=' + val2 + '', '', settings)
}

function open_Payment_Entry_Others() {

    w = '1150'//'1100';
    h = '570';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Payment Entry', 'iframe', '../Accounts_Bank/Payment_Entry_Other.aspx', '', settings)
}

function open_Payment_Entry_Others_Upd(val, val2) {
    w = '1150'; //'1100';
    h = '570'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Payment Entry', 'iframe', '../Accounts_Bank/Payment_Entry_Other.aspx?R_ID=' + escape(val) + '&R_Billinvno=' + val2 + '', '', settings)
}

function open_Payment_Entry_Cash_withdrawal() {

    w = '1150'//'1100';
    h = '270';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Bank Receipt Entry', 'iframe', '../Accounts_Bank/Payment_Entry_Cash_Withdrawal.aspx', '', settings)
}

function open_Payment_Entry_Cash_withdrawal_Upd(val, val2) {
    w = '1150'; //'1100';
    h = '270'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Receipt Entry', 'iframe', '../Accounts_Bank/Payment_Entry_Cash_Withdrawal.aspx?R_ID=' + escape(val) + '&R_Billinvno=' + val2 + '', '', settings)
}


function open_Imp_Rpt_Annexure_Amt(val) {
    w = '1100';
    h = '500';
    LeftPosition = (screen.width) ? (screen.width - w) / 5 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 80 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    var Inv_no = document.getElementById("txtInvoiceNo").value;
    var I_E = document.getElementById("HDupdate_IMP_EXP_id").value;
    if (I_E == "E") {
        adcodewindow = dhtmlmodal.open('Sales Rpt Annexure', 'iframe', '../Accounts_Sales/Gst_Rpt_Annexure_Entry_Exp.aspx?Inv_no=' + Inv_no + ' &IMP_EXP=' + I_E + '', '', settings)
    } else {
        adcodewindow = dhtmlmodal.open('Sales Rpt Annexure', 'iframe', '../Accounts_Sales/Gst_Rpt_Annexure_Entry_Imp.aspx?Inv_no=' + Inv_no + ' &IMP_EXP=' + I_E + '', '', settings)

    }
}
function open_Bank_Reconciliation(val) {

    w = '1160';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Bank Reconciliation', 'iframe', '../Accounts_Bank/Bank_Reconciliation_Entry.aspx', '', settings)
}
/*
function open_Rec_Cancel(val) {
    w = '1120'//'1100';
    h = '270';
    LeftPosition = (screen.width) ? (screen.width - w) / 15 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Bank Receipt Entry', 'iframe', '../Accounts_Bank/Receipt_Entry_Cash_Deposite.aspx', '', settings)
}
*/

function open_Bank_N_RC_Receipt_Entry_Upd(val, val2) {
    w = '1120'; //'1100';
    h = '570'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 15 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Receipt Entry', 'iframe', '../Accounts_Bank/ReceiptEntry.aspx?R_ID=' + escape(val) + '&R_Billinvno=' + val2 + '', '', settings)
}
function open_Bank_N_RC_Receipt_Entry_Others_Upd(val, val2) {
    w = '1120'; //'1100';
    h = '540'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 15 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Receipt Entry', 'iframe', '../Accounts_Bank/Other_Receipt_Entry.aspx?R_ID=' + escape(val) + '&R_Billinvno=' + val2 + '', '', settings)
}
function open_Bank_N_RC_Receipt_Entry_Cash_Upd(val, val2) {
    w = '1120'; //'1100';
    h = '270'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 15 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Receipt Entry', 'iframe', '../Accounts_Bank/Receipt_Entry_Cash_Deposite.aspx?R_ID=' + escape(val) + '&R_Billinvno=' + val2 + '', '', settings)
}

function open_Bank_N_RC_Payment_Entry_Upd(val, val2) {
    w = '1120'; //'1100';
    h = '570'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 15 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Payment Entry', 'iframe', '../Accounts_Bank/Payment_Entry_Debitors.aspx?R_ID=' + escape(val) + '&R_Billinvno=' + val2 + '', '', settings)
}
function open_Bank_N_RC_Payment_Entry_Others_Upd(val, val2) {
    w = '1120'; //'1100';
    h = '570'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 15 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Payment Entry', 'iframe', '../Accounts_Bank/Payment_Entry_Other.aspx?R_ID=' + escape(val) + '&R_Billinvno=' + val2 + '', '', settings)
}

function open_Bank_N_RC_Payment_Entry_Cash_Upd(val, val2) {
    w = '1120'; //'1100';
    h = '270'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 15 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Payment Entry', 'iframe', '../Accounts_Bank/Payment_Entry_Cash_Withdrawal.aspx?R_ID=' + escape(val) + '&R_Billinvno=' + val2 + '', '', settings)
}

/* 
function open_PaymentEntry_Deb_Upd(val, val2) {
    w = '1150'; //'1100';
    h = '570'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Payment Entry', 'iframe', '../Accounts_Bank/Payment_Entry_Debitors.aspx?R_ID=' + escape(val) + '&R_Billinvno=' + val2 + '', '', settings)
}
*/
function open_Bank_RC_Receipt_Entry_Upd(val, val2) {
    w = '1150'; //'1100';
    h = '570'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Receipt Entry', 'iframe', '../Accounts_Bank/ReceiptEntry.aspx?R_ID=' + escape(val) + '&R_Billinvno=' + val2 + '', '', settings)
}
function open_Bank_RC_Receipt_Entry_Others_Upd(val, val2) {
    w = '1150'; //'1100';
    h = '540'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Receipt Entry', 'iframe', '../Accounts_Bank/Other_Receipt_Entry.aspx?R_ID=' + escape(val) + '&R_Billinvno=' + val2 + '', '', settings)
}
function open_Bank_RC_Receipt_Entry_Cash_Upd(val, val2) {
    w = '1150'; //'1100';
    h = '270'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Receipt Entry', 'iframe', '../Accounts_Bank/Receipt_Entry_Cash_Deposite.aspx?R_ID=' + escape(val) + '&R_Billinvno=' + val2 + '', '', settings)
}

function open_Bank_RC_Payment_Entry_Upd(val, val2) {
    w = '1150'; //'1100';
    h = '570'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Payment Entry', 'iframe', '../Accounts_Bank/Payment_Entry_Debitors.aspx?R_ID=' + escape(val) + '&R_Billinvno=' + val2 + '', '', settings)
}
function open_Bank_RC_Payment_Entry_Others_Upd(val, val2) {
    w = '1150'; //'1100';
    h = '570'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Payment Entry', 'iframe', '../Accounts_Bank/Payment_Entry_Other.aspx?R_ID=' + escape(val) + '&R_Billinvno=' + val2 + '', '', settings)
}

function open_Bank_RC_Payment_Entry_Cash_Upd(val, val2) {
    w = '1150'; //'1100';
    h = '270'; //'630';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Payment Entry', 'iframe', '../Accounts_Bank/Payment_Entry_Cash_Withdrawal.aspx?R_ID=' + escape(val) + '&R_Billinvno=' + val2 + '', '', settings)
}
//------------------------Sales Start-------------------------------------------
function Open_E_Inv_Cancellation_Entry_N(val) {
    w = '1200';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Sales Entry', 'iframe', '../Accounts_Sales/E_Inv_Cancellation_Entry.aspx', '', settings)
}
function Open_E_Inv_Cancellation_Entry_Upd(val, val2, val3) {
    w = '1200';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Sales Entry', 'iframe', '../Accounts_Sales/E_Inv_Cancellation_Entry.aspx?Page=' + val + '&IMP_EXP=' + val2 + '&Billinvno=' + escape(val3) + '', '', settings)
}
function Open_Other_Entry(val) {
    w = '990';
    h = '500';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Sales Entry', 'iframe', '../Accounts_Others_Entry/Acc_Bill_To_Party.aspx?Bill_id=' + val + '', '', settings)
}
function open_Cash_Excel_Upload() {
    w = '1020';
    h = '400';
    LeftPosition = (screen.width) ? (screen.width - w) / 5 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 80 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    var CP_P = document.getElementById("txt_Cp_No_F").value;
    var CP_NO = document.getElementById("txt_Cp_No_M").value;
    var CP_S = document.getElementById("txt_Cp_No_L").value;
    var Charge = document.getElementById("ddl_Expense_Charges").value
    var Amt = document.getElementById("txtTotSubExpAmt").value
    adcodewindow = dhtmlmodal.open('Cash', 'iframe', '../Accounts_Cash/Cash_Payment_Entry_Excel_Upload.aspx?CP_P=' + CP_P + '&CP_NO=' + CP_NO + '&CP_S=' + CP_S + '&Charge=' + Charge + '&Exp_Amt=' + Amt + '', '', settings)
}

function open_Receipt_Excel_Upload() {
    w = '1020';
    h = '400';
    LeftPosition = (screen.width) ? (screen.width - w) / 5 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 80 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    var RP_P = document.getElementById("txt_Rp_No_F").value;
    var RP_NO = document.getElementById("txt_Rp_No_M").value;
    var RP_S = document.getElementById("txt_Rp_No_L").value;
    var Charge = document.getElementById("ddl_Expense_Charges").value
    var Amt = document.getElementById("txtTotSubExpAmt").value
    adcodewindow = dhtmlmodal.open('Receipt', 'iframe', '../Accounts_Cash/Receipt_Payment_Entry_Excel_Upload.aspx?RP_P=' + RP_P + '&RP_NO=' + RP_NO + '&RP_S=' + RP_S + '&Charge=' + Charge + '&Exp_Amt=' + Amt + '', '', settings)
}

function open_Journal_Excel_Upload() {
    w = '1020';
    h = '400';
    LeftPosition = (screen.width) ? (screen.width - w) / 5 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 80 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    var JV_P = document.getElementById("txt_JV_No_F").value;
    var JV_NO = document.getElementById("txt_JV_No_M").value;
    var JV_S = document.getElementById("txt_JV_No_L").value;
    var Charge = document.getElementById("ddl_Expense_Charges").value
    var Amt = document.getElementById("txtTotSubExpAmt").value
    adcodewindow = dhtmlmodal.open('Journal', 'iframe', '../Accounts_Others/Journal_Entry_Excel_Upload.aspx?JV_P=' + JV_P + '&JV_NO=' + JV_NO + '&JV_S=' + JV_S + '&Charge=' + Charge + '&Exp_Amt=' + Amt + '', '', settings)
}
function open_Expense_Excel_Upload() {
    w = '1020';
    h = '400';
    LeftPosition = (screen.width) ? (screen.width - w) / 5 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 80 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    var VoucherNo = document.getElementById("txtExpVoucherNo").value;
    var Charge = document.getElementById("ddl_Expense_Charges").value
    var selected = document.querySelector('input[name="Rd_Imp_Exp"]:checked');
    var Imp_Exp = selected ? selected.value : "";
    var Amt = document.getElementById("txtTotSubExpAmt").value
    adcodewindow = dhtmlmodal.open('Expense', 'iframe', '../Accounts_Expense/Expense_Payment_Entry_Excel_Upload.aspx?VoucherNo=' + VoucherNo + '&Charge=' + Charge + '&Imp_Exp=' + Imp_Exp + '&Exp_Amt=' + Amt + '', '', settings)
}

function open_Charge_Annexure_Amt(val) {
    w = '1100';
    h = '500';
    LeftPosition = (screen.width) ? (screen.width - w) / 5 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 80 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    var Inv_no = document.getElementById("txtInvoiceNo").value;
    var Rd_selected = document.querySelector('input[name="Rd_Imp_Exp"]:checked');
    var I_E = Rd_selected ? Rd_selected.value : ""; ;
    var selected = document.querySelector('input[name="Rd_Royal_Other"]:checked');
    var R_Oth = selected ? selected.value : "";
    adcodewindow = dhtmlmodal.open('CHA Ledger', 'iframe', '../Accounts_Sales/Gst_Charge_Annexure_Entry_Exp.aspx?Inv_no=' + Inv_no + '&IMP_EXP=' + I_E + '&Royal_Other=' + R_Oth + '', '', settings)
}

function open_Bank_Reconciliation_Update(val) {
    w = '1160';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Bank Reconciliation', 'iframe', '../Accounts_Bank/Bank_Reconciliation_Entry.aspx?RECON_ID=' + escape(val) + '', '', settings)
}

function open_Job_Journal_Entry_View(val) {
    w = '700';
    h = '350';
    LeftPosition = (screen.width) ? (screen.width - w) / 3 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    var Inv_Id = document.getElementById("HDupdate_id").value;
    adcodewindow = dhtmlmodal.open('Journal Entry', 'iframe', '../Accounts_Sales/Job_Journal_View.aspx?Inv_Id=' + Inv_Id + '', '', settings)
}

function open_groupmaster_Ledger_Update_N() {
    adcodewindow = dhtmlmodal.open('Group Master Updation', 'iframe', '../Accounts_Master/Ledger_Update.aspx', '', NewWindow('460', '350'))
}

function Open_Payment_Request_Entry() {
    w = '1150';
    h = '570';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Payment Request', 'iframe', '../Accounts_Others/Payment_Request_Entry.aspx', '', settings)
}
function Open_Payment_Request_Upd(val) {
    w = '1150';
    h = '570';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Payment Request', 'iframe', '../Accounts_Others/Payment_Request_Entry.aspx?BP_R_ID=' + val + '', '', settings)
}
function Open_ChargeMaster(val) {
    w = '1025';
    h = '420';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Charge Master', 'iframe', '../Accounts_Master/Acc_Charge_Master.aspx?CHARGE_ID=' + val + '', '', settings)
}
function open_Leg_Group_Type_Upd(val) {
    adcodewindow = dhtmlmodal.open('Charge Master', 'iframe', '../Accounts_Master/Acc_Group_Type.aspx?Type_ID=' + val + '', '', NewWindow('400', '200'))
}
function open_Leg_Group_Category_Upd(val) {
    adcodewindow = dhtmlmodal.open('Category Master', 'iframe', '../Accounts_Master/Acc_Group_Category.aspx?Cat_ID=' + val + '', '', NewWindow('500', '200'))
}
function open_Leg_Groups_List_Upd(val) {
    adcodewindow = dhtmlmodal.open('Groups List Master', 'iframe', '../Accounts_Master/Acc_Groups_List.aspx?G_List_ID=' + val + '', '', NewWindow('500', '200'))
}
function open_Leg_Sub_Group_Upd(val) {
    adcodewindow = dhtmlmodal.open('Sub Group Master', 'iframe', '../Accounts_Master/Acc_Sub_Group.aspx?S_Group_ID=' + val + '', '', NewWindow('500', '200'))
}

function open_Imp_Exp_Charge_Upd(val, val2, val3) {
    var w = 1200;
    var h = 400;
    var left = (screen.width - w) / 2;
    var top = (screen.height - h) / 2;

    var childWindow = window.open('../Accounts_CHA_Import/Acc_Imp_Exp_Charges.aspx?JOBNO=' + encodeURIComponent(val) + '&CHARGE_ID=' + encodeURIComponent(val2) + '&I_E=' + encodeURIComponent(val3),
        'ChargeEntryWindow', 'width=' + w + ',height=' + h + ',left=' + left + ',top=' + top + ',resizable=yes,scrollbars=yes');

    var checkWindowClosed = setInterval(function () {
        if (childWindow.closed) {
            clearInterval(checkWindowClosed);
            triggerParentButton();
        }
    }, 100);
}

function triggerParentButton() {
    if (window.opener) {
        window.opener.document.getElementById('Button1').click();
    }
}

function Open_COA_Master(val) {
    w = '1025';
    h = '420';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('COA Master', 'iframe', '../Accounts_Master/Acc_COA_Master.aspx?CHARGE_ID=' + val + '', '', settings)
}

//---6June-2026 //from prasad
function open_Journal_Entry() {
    w = '1150';
    h = '570';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Journal Entry', 'iframe', '../Accounts_Others/Acc_Journal_Entry.aspx', '', settings)
}

function open_Journal_Entry_Update(val) {
    w = '1150';
    h = '570';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Journal Entry', 'iframe', '../Accounts_Others/Acc_Journal_Entry.aspx?JV_ID=' + escape(val) + '', '', settings)
}

function open_Journal_Entry_Details_Update(val) {
    var w = 1450;
    var h = 700;
    var left = (screen.width - w) / 2;
    var top = (screen.height - h) / 2;

    var childWindow = window.open('../Accounts_Others/Acc_Journal_Entry_Details.aspx?JL_ID=' + encodeURIComponent(val) + '&AB=' + encodeURIComponent(val) + '&I_E=' + encodeURIComponent(val),
        'Journal Entry', 'width=' + w + ',height=' + h + ',left=' + left + ',top=' + top + ',resizable=yes,scrollbars=yes');

    var checkWindowClosed = setInterval(function () {
        if (childWindow.closed) {
            clearInterval(checkWindowClosed);
            triggerParentButton();
        }
    }, 100);
}
//benjamin 27-06-2026 charge master screen is added
function open_Charge_Master_N(val) {
    w = '1060';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Charge Master', 'iframe', '../Accounts_Master/Acc_Charges_Master_N.aspx', '', settings)
}

function open_Charge_Master_N_Upd(val) {
    w = '1060';
    h = '585';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Charge Master', 'iframe', '../Accounts_Master/Acc_Charges_Master_N.aspx?CHRG_ID=' + escape(val) + '', '', settings)
}


//---6June-2026 //from prasad
function open_Journal_Entry() {
    w = '1150';
    h = '570';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Journal Entry', 'iframe', '../Accounts_Others/Acc_Journal_Entry.aspx', '', settings)
}

function open_Journal_Entry_Update(val) {
    w = '1150';
    h = '570';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Journal Entry', 'iframe', '../Accounts_Others/Acc_Journal_Entry.aspx?JV_ID=' + escape(val) + '', '', settings)
}

function open_Journal_Entry_Details_Update(val) {
    var w = '1270';
    var h = '600';
    var left = (screen.width - w) / 2;
    var top = (screen.height - h) / 2;

    var childWindow = window.open('../Accounts_Others/Acc_Journal_Entry_Details.aspx?JL_ID=' + encodeURIComponent(val) + '&AB=' + encodeURIComponent(val) + '&I_E=' + encodeURIComponent(val),
        'Journal Entry', 'width=' + w + ',height=' + h + ',left=' + left + ',top=' + top + ',resizable=yes,scrollbars=yes');

    var checkWindowClosed = setInterval(function () {
        if (childWindow.closed) {
            clearInterval(checkWindowClosed);
            triggerParentButton();
        }
    }, 100);
}




//07-07-2026 Purchasebill functions PRASAD
function open_PurchaseEntry_New() {
    w = '1150';
    h = '597';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Purchase Bill Entry', 'iframe', '../Accounts_Purchase/Acc_PurchaseBill_Entry.aspx', '', settings)
}

function open_Purchase_Entry_Update(val) {
    w = '1150';
    h = '597';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Purchase Bill Entry', 'iframe', '../Accounts_Purchase/Acc_PurchaseBill_Entry.aspx?PC_ID=' + escape(val) + '', '', settings)
}

//25june Purchasebill functions-prasad
function open_Purchase_Entry_Details_Update_old(val) {
    var w = '1270';
    var h = '600';
    var left = (screen.width - w) / 2;
    var top = (screen.height - h) / 2;

    var childWindow = window.open('../Accounts_Purchase/Acc_PurchaseBill_Entry_Details.aspx?PCL_ID=' + encodeURIComponent(val) + '&AB=' + encodeURIComponent(val) + '&I_E=' + encodeURIComponent(val),
        'Purchase Bill', 'width=' + w + ',height=' + h + ',left=' + left + ',top=' + top + ',resizable=yes,scrollbars=yes');

    var checkWindowClosed = setInterval(function () {
        if (childWindow.closed) {
            clearInterval(checkWindowClosed);
            triggerParentButton();
        }
    }, 100);
}


//09july bank other receipts
function open_Receipt_Entry_Others_v1() {
    w = '1150'
    h = '570';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Bank Receipt Entry', 'iframe', '../Accounts_Bank/Acc_Other_Receipt_Entry.aspx', '', settings)
}

function open_OthersReceiptEntry_Upd_v1(val, val2) {
    w = '1150'; //'1100';
    h = '570'; //'630';    
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Receipt Entry', 'iframe', '../Accounts_Bank/Acc_Other_Receipt_Entry.aspx?BR_O_ID=' + escape(val) + '&R_Billinvno=' + val2 + '', '', settings)
}


function open_OtherReceipts_Details_Update(val) {
    var w = '1270';
    var h = '600';
    var left = (screen.width - w) / 2;
    var top = (screen.height - h) / 2;

    var childWindow = window.open('../Accounts_Bank/Acc_BOReceiptEntry_Details.aspx?BORL_ID=' + encodeURIComponent(val) + '&AB=' + encodeURIComponent(val) + '&I_E=' + encodeURIComponent(val),
        'Other Receipts Details', 'width=' + w + ',height=' + h + ',left=' + left + ',top=' + top + ',resizable=yes,scrollbars=yes');

    var checkWindowClosed = setInterval(function () {
        if (childWindow.closed) {
            clearInterval(checkWindowClosed);
            triggerParentButton();
        }
    }, 100);
}



//14 july Cash deposits 
function open_CashDeposit_v1() {
    w = '1150'
    h = '570';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Bank Receipt Entry', 'iframe', '../Accounts_Bank/Acc_CashDeposit_Entry.aspx', '', settings)
}
function open_CashDepositEntry_Upd_v1(val, val2) {
    w = '1150'; //'1100';
    h = '570'; //'630';    
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Cash Deposit', 'iframe', '../Accounts_Bank/Acc_CashDeposit_Entry.aspx?BR_O_ID=' + escape(val) + '&R_Billinvno=' + val2 + '', '', settings)
}

function open_Cashdeposit_Details_Update(val) {
    var w = '1270';
    var h = '600';
    var left = (screen.width - w) / 2;
    var top = (screen.height - h) / 2;

    var childWindow = window.open('../Accounts_Bank/Acc_CashDeposit_Details.aspx?BORL_ID=' + encodeURIComponent(val) + '&AB=' + encodeURIComponent(val) + '&I_E=' + encodeURIComponent(val),
        'Cash Deposit', 'width=' + w + ',height=' + h + ',left=' + left + ',top=' + top + ',resizable=yes,scrollbars=yes');

    var checkWindowClosed = setInterval(function () {
        if (childWindow.closed) {
            clearInterval(checkWindowClosed);
            triggerParentButton();
        }
    }, 100);
}


//15 cash withdrawal 

function open_Payment_Entry_Cash_withdrawal_v1() {
    w = '1150'
    h = '570';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Payment Entry', 'iframe', '../Accounts_Bank/Acc_CashWithdrawal_Entry.aspx', '', settings)
}


function open_CashWithdrawal_Update_v1(val, val2) {
    w = '1150';
    h = '570';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Payment Entry', 'iframe', '../Accounts_Bank/Acc_CashWithdrawal_Entry.aspx?R_ID=' + escape(val) + '&R_Billinvno=' + val2 + '', '', settings)
}



function open_CashWithdraw_Details_Update(val) {
    var w = '1270';
    var h = '600';
    var left = (screen.width - w) / 2;
    var top = (screen.height - h) / 2;

    var childWindow = window.open('../Accounts_Bank/Acc_CashWithdraw_Details.aspx?BPL_ID=' + encodeURIComponent(val) + '&AB=' + encodeURIComponent(val) + '&I_E=' + encodeURIComponent(val),
        'Payment Entry', 'width=' + w + ',height=' + h + ',left=' + left + ',top=' + top + ',resizable=yes,scrollbars=yes');

    var checkWindowClosed = setInterval(function () {
        if (childWindow.closed) {
            clearInterval(checkWindowClosed);
            triggerParentButton();
        }
    }, 100);
}


//18 OTHER PAYMENTS AND EXPENSES

function open_Payment_Entry_Others_v1() {
    w = '1150'
    h = '570';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';

    adcodewindow = dhtmlmodal.open('Payment Entry', 'iframe', '../Accounts_Bank/Acc_Payments_Others_Entry.aspx', '', settings)
}


function open_OtherPayment_entry_Update_v1(val, val2) {
    w = '1150';
    h = '570';
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
    settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
    adcodewindow = dhtmlmodal.open('Payment Entry', 'iframe', '../Accounts_Bank/Acc_Payments_Others_Entry.aspx?R_ID=' + escape(val) + '&R_Billinvno=' + val2 + '', '', settings)
}

function open_OtherpaymentsDetails_Update(val) {
    var w = '1270';
    var h = '600';
    var left = (screen.width - w) / 2;
    var top = (screen.height - h) / 2;

    var childWindow = window.open('../Accounts_Bank/Acc_Payments_Others_Entry_Details.aspx?BPL_ID=' + encodeURIComponent(val) + '&AB=' + encodeURIComponent(val) + '&I_E=' + encodeURIComponent(val),
        'Payment Entry', 'width=' + w + ',height=' + h + ',left=' + left + ',top=' + top + ',resizable=yes,scrollbars=yes');

    var checkWindowClosed = setInterval(function () {
        if (childWindow.closed) {
            clearInterval(checkWindowClosed);
            triggerParentButton();
        }
    }, 100);
}
  


