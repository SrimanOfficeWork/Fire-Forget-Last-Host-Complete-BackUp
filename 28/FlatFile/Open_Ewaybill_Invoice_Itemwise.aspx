<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Open_Ewaybill_Invoice_Itemwise.aspx.cs"
    Inherits="Open_Ewaybill_Invoice_Itemwise" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Export-BL Generation</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script language="javascript">

        function CheckAll() {

            var intIndex = 0;

            var rowCount = document.getElementById('cbList').getElementsByTagName("input").length;

            for (i = 0; i < rowCount; i++) {

                if (document.getElementById('cbAll').checked == true) {

                    if (document.getElementById("cbList" + "_" + i)) {

                        if (document.getElementById("cbList" + "_" + i).disabled != true)

                            document.getElementById("cbList" + "_" + i).checked = true;

                    }

                }

                else {

                    if (document.getElementById("cbList" + "_" + i)) {

                        if (document.getElementById("cbList" + "_" + i).disabled != true)

                            document.getElementById("cbList" + "_" + i).checked = false;

                    }

                }

            }


            var intIndex_Itm = 0;

            var rowCount_Itm = document.getElementById('chkItemInv').getElementsByTagName("input").length;

            for (i = 0; i < rowCount; i++) {

                if (document.getElementById('cbAll').checked == true) {

                    if (document.getElementById("chkItemInv" + "_" + i)) {

                        if (document.getElementById("chkItemInv" + "_" + i).disabled != true)

                            document.getElementById("chkItemInv" + "_" + i).checked = true;

                    }

                }

                else {

                    if (document.getElementById("chkItemInv" + "_" + i)) {

                        if (document.getElementById("chkItemInv" + "_" + i).disabled != true)

                            document.getElementById("chkItemInv" + "_" + i).checked = false;

                    }

                }

            }


        }



        function UnCheckAll() {

            var intIndex = 0;

            var flag = 0;

            var rowCount = document.getElementById('cbList').getElementsByTagName("input").length;

            for (i = 0; i < rowCount; i++) {

                if (document.getElementById("cbList" + "_" + i)) {

                    if (document.getElementById("cbList" + "_" + i).checked == true) {

                        flag = 1;

                    }

                    else {

                        flag = 0;

                        break;

                    }

                }

            }

            if (flag == 0)

                document.getElementById('cbAll').checked = false;

            else

                document.getElementById('cbAll').checked = true;
        }

    </script>

     <script type="text/javascript">

         function Child_Parent_close_button1_Trigger_AnotherPage1(val, pagename) {

             document.getElementById("page-10").style.display = 'none';
             
             alert(val);
             alert(pagename);
             window.parent.close_button_Trigger_AnotherPage(val, pagename);
         }

         function close_button_Trigger_AnotherPage(val, pagename) {
             //document.getElementById("hdn_source").value = 'E_Way_Bill_Generation';
             document.getElementById("hdn_source").value = pagename;
             document.getElementById(val).click();
         }

         function ewayopen_Old() {
             
            win_hide();
            parent.adcodewindow.hide();           
            return false;
         }

         function ewayopen() {
             alert('jj');
//             window.close();
//             alert('kj');
//             window.parent.close_button();
//            // window.open("E_Way_Bill_Generation.aspx", "mywindow1", "modal=1,status=1,resizable=0,width=875,height=530,top=150,menubar=0,left=200,top=40,bottom=160,ScrollBars=0");
            
//             win_hide();
//             parent.adcodewindow.hide();
             window.open("E_Way_Bill_Generation.aspx", "mywindow1", "modal=0,status=1,resizable=0,width=875,height=530,top=150,menubar=0,left=200,top=40,bottom=160,ScrollBars=0");
             return false;
         }
   </script>

    <script language="jscript" type="text/javascript">

        function tab_page1() {

            document.getElementById("page-1").style.display = 'Block';
            document.getElementById("page-2").style.display = 'none';
            document.getElementById("page-3").style.display = 'none';
            document.getElementById("page-4").style.display = 'none';
        }
        /*
        function tab_page2() {

        document.getElementById("page-1").style.display = 'none';
        document.getElementById("page-2").style.display = 'Block';
        document.getElementById("page-3").style.display = 'none';
        document.getElementById("page-4").style.display = 'none';
        }*/
        function tab_page3() {

            document.getElementById("page-1").style.display = 'none';
            document.getElementById("page-2").style.display = 'none';
            document.getElementById("page-3").style.display = 'Block';
            document.getElementById("page-4").style.display = 'none';
        }
        function tab_page4() {

            document.getElementById("page-1").style.display = 'none';
            document.getElementById("page-2").style.display = 'none';
            document.getElementById("page-3").style.display = 'none';
            document.getElementById("page-4").style.display = 'Block';
        }

        function tab_page2(url, val, val2) {

            if (document.getElementById('hd_Combine_jobs').value != '') {
                document.getElementById("page-1").style.display = 'none';
                document.getElementById("page-2").style.display = 'Block';
                document.getElementById("page-3").style.display = 'none';
                document.getElementById("page-4").style.display = 'none';
                //document.getElementById("Flatfile").src = url + val + val2 + document.getElementById('hd_Combine_jobs').value;
                document.getElementById("Flatfile").src = url + val + val2 + document.getElementById('hd_Combine_jobs').value + '&jobnops=' + $("#ddlJobNo option:selected").text();

            }
            else {
                jAlert('Combine a job First', 'Combine Checklist');
            }


        }

    </script>
    <script type="text/javascript">
        function open_jobno() {

            if (document.getElementById('ddlJobNo').value != 'Select' && document.getElementById('ddlJobNo').value != '') {

                var f = document.getElementById('ddlJobNo').value;
                var f1 = document.getElementById('hdn_Annexure_Mode').value;
                var f2 = document.getElementById('hdn_STR_Code').value;
                var f3 = 'Y';
                NewWindow1('../Report/Export_ReportViewer.aspx?jobno=' + f + '&Annexure_Mode=' + f1 + '&STR_CODE=' + f2 + '&Combine_CH=' + f3 + '', 'List', '810', '1024', 'yes');
                return false
            }
            else {
                jAlert('Job No cannot be blank', 'Combine Checklist');
            }

        }
    </script>
    <style type="text/css">
        .ListControl input[type=radio] + label
        {
            display: table-cell;
            width: 7.5em;
            height: 5em;
            line-height: 0em;
            text-align: left;
        }
        
        .ListControlWidth input[type=radio] + label
        {
            display: table-cell;
            width: 10em;
            height: 5em;
            line-height: 0em;
            text-align: left;
        }
    </style>
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_Transact_popup_new" style="height: 100px;">
                <div id="Div_listbox" runat="server">
                    <div id="tag_transact_src_inner" style="width: 960px;">
                        <div id="innerbox_MidMain_Trans_new" style="width: 980px; height: 25px; margin-left: -10px;
                            border-bottom-style: solid;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 850px; height: 25px;">
                                <asp:CheckBox ID="cbAll" runat="server" ForeColor="White" Font-Bold="true" Font-Size="14px" AutoPostBack="true"
                                    Text="Select All" oncheckedchanged="cbAll_CheckedChanged"   />
                               
                                     </div>
                                       <div id="tag_label_transaction_exp_jobb" style="width: 50px; height: 25px;">
                       <input type="close" value="Submit" class="clsicon_new"   onclick="ewayopen_Old()" />
                        
                 <asp:Button ID="btnGotoEWayBill" runat="server" CausesValidation="false"  
                      CssClass="autowidmovebut" Text="Close" UseSubmitBehavior="false" OnClick="btnGotoEWayBill_Click" Visible="false"  />


                            </div>
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width: 970px; overflow: auto; height: 60px;">
                         <div id="tag_label_transaction_popup_IGM" style="width: 50px;">
                                Invoice  
                            </div>
                             <div id="tag_label_transaction_popup_IGM" style="width: 103px;">
                           
                            <asp:CheckBoxList ID="cbList" runat="server" ValidationGroup="VGroup"   AutoPostBack="true"
                             OnSelectedIndexChanged="cbList_SelectedIndexChanged"
                                CssClass=" txtbox_none_Mid_transac_pop_gen" Width="951px" Height="22px" RepeatColumns="10"
                                RepeatDirection="Horizontal">
                            </asp:CheckBoxList>
                             </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="innerbox_MidMain_Trans_IGM_Invoice" style="width: 990px; height: 380px;">
            <div id="tag_label_transaction_popup_IGM" style="width: 200px; height:25px">
                                Item  - <asp:CheckBox ID="chkAllItem" runat="server" ForeColor="White" Font-Bold="true" Font-Size="14px" AutoPostBack="true"
                                    Text="Select All-Item" oncheckedchanged="chkAllItem_CheckedChanged"   />
                            </div>
              
               <asp:CheckBoxList ID="chkItemInv" runat="server" ValidationGroup="VGroup"  AutoPostBack="true"
                             OnSelectedIndexChanged="chkItemInv_SelectedIndexChanged"
                                CssClass=" txtbox_none_Mid_transac_pop_gen" Width="951px" Height="22px" RepeatColumns="10" 
                                RepeatDirection="Horizontal">
                            </asp:CheckBoxList>

            </div> 
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script type="text/javascript">
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });

        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }
        function close_button() {
            //document.getElementById("btn_cancel").click();
            document.getElementById("General").click();
        }
        
    </script>
</body>
</html>
