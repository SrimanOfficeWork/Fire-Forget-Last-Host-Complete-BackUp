
//-------------------------AUTO CENTER---------------------------------------------------
var win = null;
function NewWindow1(mypage, myname, w, h, scroll) {
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
    settings ='height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
    win = window.open(mypage, myname, settings);
    win.focus();

    return false;
}

function RefreshParent() {
    window.parent.location.href = window.parent.location.href;
}

function opennewHSNSACcode(val) {
    NewWindow1('../Accounts_ListPopup/Acc_Hsn_Sac_Listpopup.aspx?Name=' + val + '', 'List', '810', '470', 'yes');
}

function opennewGLLedger(val) {
    NewWindow1('../Accounts_ListPopup/Acc_GL_ListPopup.aspx?Name=' + val + '', 'List', '810', '470', 'yes');
}

function opennewCustomerGL(val) {
    NewWindow1('../Accounts_ListPopup/Acc_GL_ListPopup_Orgainzation.aspx?Name=' + encodeURIComponent(val) + '', 'List', '810', '470', 'yes');
}

function openOrganizationClientName(val) {
    NewWindow1('../Accounts_ListPopup/Acc_OrganizationList.aspx?Name=' + encodeURIComponent(val) + '', 'Organization List', '810', '470', 'yes');
}

function openOrganizationName(val) {
    NewWindow1('../Accounts_ListPopup/Acc_OrganizationList.aspx?Name=' + encodeURIComponent(val) + '', 'Organization List', '810', '470', 'yes');
}




