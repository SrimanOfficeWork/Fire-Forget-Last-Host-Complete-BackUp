<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User_Job_Release.aspx.cs" Inherits="Users_User_Job_Release" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
         .hideGridColumn
        {
            display: none;
        }
                
    </style>


    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>


    <script src="../js/Export_Jscript/Export_Joblock.js" type="text/javascript"></script>
    <script type = "text/javascript">
        //<!--
        function Check_Click(objRef) {
            //Get the Row based on checkbox
            var row = objRef.parentNode.parentNode;

            //Get the reference of GridView
            var GridView = row.parentNode;

            //Get all input elements in Gridview
            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {
                //The First element is the Header Checkbox
                var headerCheckBox = inputList[0];

                //Based on all or none checkboxes
                //are checked check/uncheck Header Checkbox
                var checked = true;
                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                    if (!inputList[i].checked) {
                        checked = false;
                        break;
                    }
                }
            }
            headerCheckBox.checked = checked;

        }
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }
                    else {
                        if (row.rowIndex % 2 == 0) {
                            //                              row.style.backgroundColor = "#C2D69B";
                        }
                        else {
                            //                              row.style.backgroundColor = "white";
                        }
                        inputList[i].checked = false;
                    }
                }
            }
        }
        //-->

        function win_close1() {
            window.parent.document.getElementById('interVeil').style.display = 'none';
            window.parent.adcodewindow.hide();
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>

    <div>
           
        
               <%-- <div id="ere" style=" height:950px;">--%>


               <div id="pop_text_area_transac_popup_inn_container_new" style="float:left;width:980px;height:734px;margin-top:1px;margin-left:0px;background-color : #FFFFFF;" >
               
                <div class="content active" id="page-1" style="padding-top:0px;">
                   
                   <div id="tag_transact_src_inner" style="width:905px;">
               <div id="tag_transaction_inner_new" style="margin-left:20px; width:850px; ">

                      <%-- Row-1  --%>

                    <div id="tag_Exchange_lft_in1_new1" >
                        <div id="tag_label_transaction_Src_new">
                         Job Type
                        </div>
                        <div id="txtcon-m_transaction_code">
                              <asp:DropDownList ID="ddlJobType" runat="server" CssClass="listtxt_transac_src1" ClientIDMode="Static">
       
                            <asp:ListItem>Import</asp:ListItem>
                            <asp:ListItem>Export</asp:ListItem>
                            <asp:ListItem>Both</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                            <div id="tag_label_transact_Src">
                        
                            Select Branch
                        </div>
                        
                        <div id="txtcon-m_transaction_list1_bondtype">
                        <asp:DropDownList ID="ddlBranch" runat="server" CssClass="listtxt_transac_bondtype"  Width="150px">
                        </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                         
                        <div id="tag_label_transaction_Src_new" >
                        User Name
                        </div>
                        <div id="txtcon-m_transaction_list1_bondtype">
                          <asp:DropDownList ID="ddlUserName" runat="server" CssClass="listtxt_transac_src1"  Width="150px" ClientIDMode="Static">
                         </asp:DropDownList>
                        </div>

                        
                    </div>


                     <%-- Row-2  --%>
                    <div id="tag_label_transaction_popup_IGM2_empty_gen">
                    </div>
                  
                    <%-- Row-3  --%>
<%--                    <div id="tag_Exchange_lft_in1_new1">
                    <div id="tag_label_transaction_Src">
                           Need Job
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                   <asp:DropDownList ID="ddlneedjob" runat="server" CssClass="listtxt_transac_src1" >
                                     <asp:ListItem Text="Lock"></asp:ListItem>
                                      <asp:ListItem Text="UnLock"></asp:ListItem>
                                     </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_no_empty">
                        </div>--%>
                     
                     <%--  ROW-4--%>
                     
                       
                    </div>

                    <div id="tag_label_transaction_popup_mode_empty" style="padding-left:300px;">
                    </div>
                  <div id="tag_label_transaction_Src_longlabel" style="padding-top:05px;" >
                                          
                                           <div id="small-butt-left" >
                                <a href="#" class="srcbu" id="btnSearch"  runat="server" onserverclick="btnSearch_Click"     tabindex="10">   </a>                                             
                               
                              </div>
                            </div>


                        <div id="txtcon-m_transaction_mode" style="padding-top:05px;" >
                        <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="11"></a>
                        </div>

                       <div id="joblockoption" runat="server"> 
                         <div id="txtcon-m_transaction_mode" style="padding-left:30px;padding-top:05px;">

                            
                             <asp:Button ID="btnJobRelease" runat="server"  CausesValidation="false" onclick="btnJobRelease_Click"
                                 UseSubmitBehavior="false" CssClass="autowidmovebut" Text="Job Release" />
                                   

                        </div>

                        </div>
                </div> 
                
                
            </div>
           <%-- innerbox_MidMain_Grid--%>

                  <%--  <div id="test" style="min-width:800px; margin-top:0px;height: 562px;">--%>
                        
                        <%--<div id="tag_srcinner1grid_table_Container">--%>

                            <div id="Main_Grid_Container" style="overflow: scroll; height: 553px; width:925px; " runat="server">
                                <asp:GridView ID="gv_details" runat="server" AllowPaging="false" AutoGenerateColumns="true"
                                    BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                                    CssClass="grid-view" DataKeyNames="JOBID" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
                                    Width="100%" OnRowCreated="gv_details_RowCreated" OnRowDataBound="gv_details_RowDataBound">
                                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                        CssClass="column_style_right" BorderWidth="1px" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk" runat="server" onclick="Check_Click(this)" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                       <%-- </div>--%>
                   <%-- </div>--%>

                </div>

               
                 
                </div>
                </div>
                <%-- </div>--%>
                    
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2']);
            </script>
               
       
  
    <asp:HiddenField runat="server" ID="hdn_Server" />

    <asp:HiddenField runat="server" ID="HD_imp_exp" />
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
     <script src="../js/Import_Jscript/Import_General.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script src="../js/MaskedEditFix.js" type="text/javascript"></script>

    <script src="../js/Export_Jscript/Export_Joblock.js" type="text/javascript"></script>

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
            //document.getElementById("btnCancel").click();
            document.getElementById("General").click();
        }

    </script>
    <script type="text/javascript">
        // Select/Deselect checkboxes based on header checkbox
        function SelectheaderCheckboxes(headerchk, gv) {

            var gvcheck = document.getElementById(gv);


            var i;
            //Condition to check header checkbox selected or not if that is true checked all checkboxes
            if (headerchk.checked) {
                for (i = 0; i < gvcheck.rows.length; i++) {
                    var inputs = gvcheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = true;

                }


            }
            //if condition fails uncheck all checkboxes in gridview
            else {
                for (i = 0; i < gvcheck.rows.length; i++) {
                    var inputs = gvcheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = false;
                }
            }
        }
        //function to check header checkbox based on child checkboxes condition
        function Selectchildcheckboxes(header, gv) {

            var ck = header;
            var count = 0;
            var gvcheck = document.getElementById(gv);
            var headerchk = document.getElementById(header);
            var rowcount = gvcheck.rows.length;
            //By using this for loop we will count how many checkboxes has checked
            for (i = 1; i < gvcheck.rows.length; i++) {
                var inputs = gvcheck.rows[i].getElementsByTagName('input');
                if (inputs[0].checked) {

                    count++;
                }
            }
            //Condition to check all the checkboxes selected or not
            if (count == rowcount - 1) {
                headerchk.checked = true;

            }
            else {
                headerchk.checked = false;
            }
        }
</script>
<script type="text/javascript">
    // Select/Deselect checkboxes based on header checkbox
    function SelectheaderCheckboxes_file(headerchk, gv, button) {
        debugger
        var gvcheck = document.getElementById(gv);
        var i;
        //Condition to check header checkbox selected or not if that is true checked all checkboxes
        if (headerchk.checked) {
            for (i = 0; i < gvcheck.rows.length; i++) {
                var inputs = gvcheck.rows[i].getElementsByTagName('input');
                inputs[0].checked = true;
            }
            document.getElementById(button).click();

        }
        //if condition fails uncheck all checkboxes in gridview
        else {
            for (i = 0; i < gvcheck.rows.length; i++) {
                var inputs = gvcheck.rows[i].getElementsByTagName('input');
                inputs[0].checked = false;
            }
        }
    }
    //function to check header checkbox based on child checkboxes condition
    function Selectchildcheckboxes_file(header, gv, button) {
        var ck = header;
        var count = 0;
        var gvcheck = document.getElementById(gv);
        var headerchk = document.getElementById(header);
        var rowcount = gvcheck.rows.length;
        //By using this for loop we will count how many checkboxes has checked
        for (i = 1; i < gvcheck.rows.length; i++) {
            var inputs = gvcheck.rows[i].getElementsByTagName('input');
            if (inputs[0].checked) {
                document.getElementById(button).click();
                count++;
            }
        }
        //Condition to check all the checkboxes selected or not
        if (count == rowcount - 1) {
            headerchk.checked = true;

        }
        else {
            headerchk.checked = false;
        }
    }
</script>
</body>
</html>
