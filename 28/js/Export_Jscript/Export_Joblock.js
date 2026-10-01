window.onload = happycode;
function happycode() {
    document.getElementById("General").click();
}
function tab_page1() {

    document.getElementById('page-1').style.display = 'Block';
    document.getElementById('page-2').style.display = 'none';
}
function tab_page2() {

        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'Block';
        document.getElementById("UserJob_Release").src = "../Users/User_Job_Release.aspx";
}