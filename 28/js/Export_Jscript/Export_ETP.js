function tab_page1(val) {
    document.getElementById('page-1').style.display = 'Block';
    document.getElementById('page-2').style.display = 'none';
    //document.getElementById("trans_IGM_details_Main_Cont_iframe").src = "../Transaction/IGM_Main.aspx";
}
function tab_page2(val) {
    document.getElementById('page-1').style.display = 'none';
    document.getElementById('page-2').style.display = 'Block';
    document.getElementById("trans_ETP_Container_iframe").src = "../Export_ETP/ETP_Container_Details.aspx";
}
//-------- Specila Character check - Chithra on 22-08-2023
function containsSpecialChars(str) {
    // Define a regular expression to match special characters
    var specialCharsRegex = /[!@#$%^&*() _+\-=\[\]{};':"\\|,.<>\/?]+/;
    return specialCharsRegex.test(str);
}
//-----------------end-------------------------------------