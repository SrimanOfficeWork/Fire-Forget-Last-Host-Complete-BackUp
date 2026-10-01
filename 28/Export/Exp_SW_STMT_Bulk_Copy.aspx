<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Exp_SW_STMT_Bulk_Copy.aspx.cs" Inherits="Imp_Inv_Copy" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Export SW- Statement Bulk</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />

    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>

    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />

    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
  
     <style type="text/css">
         .datagrid table { border-collapse: collapse; text-align: left; width: 100%; } 
         .datagrid {font: normal 12px/150% Arial, Helvetica, sans-serif; background: #fff; overflow: hidden; border: 1px solid #8C8C8C; -webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; }
         .datagrid table td, .datagrid table th { padding: 3px 10px; }
         .datagrid table thead th {background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );background:-moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');background-color:#8C8C8C; color:#FFFFFF; font-size: 15px; font-weight: bold; border-left: 1px solid gray; } 
         .datagrid table thead th:first-child { border: none; }
         .datagrid table tbody td { /*color: #7D7D7D;*/ border-left: 1px solid #DBDBDB;font-size: 12px;font-weight: normal; }
         .datagrid table tbody .alt td { background: #EBEBEB; color: #7D7D7D; }
         .datagrid table tbody td:first-child { border-left: none; }
         .datagrid table tbody tr:last-child td { border-bottom: none; }
         .datagrid table tfoot td div { border-top: 1px solid #8C8C8C;background: #EBEBEB;} 
         .datagrid table tfoot td { padding: 0; font-size: 12px } 
         .datagrid table tfoot td div{ padding: 2px; }
         .datagrid table tfoot td ul { margin: 0; padding:0; list-style: none; text-align: right; }
         .datagrid table tfoot  li { display: inline; }
         .datagrid table tfoot li a { text-decoration: none; display: inline-block;  padding: 2px 8px; margin: 1px;color: #F5F5F5;border: 1px solid #8C8C8C;-webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );background:-moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');background-color:#8C8C8C; }
         .datagrid table tfoot ul.active, .datagrid table tfoot ul a:hover { text-decoration: none;border-color: #7D7D7D; color: #F5F5F5; background: none; background-color:#8C8C8C;}
         div.dhtmlx_window_active, div.dhx_modal_cover_dv { position: fixed !important; }
    
     /*td:nth-of-type(1) {display: none;}*/
     </style>
    



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
            <div id="innerbox_MidMain" style="height: 83px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 70px;">
                       Stmt. Bulk</div>
                    <div id="verslic">
                    </div>

                     <div id="txt_container_Transact_Main_l" style="width: 130px;">
                        <div id="tag_label_transact_Src" style="width: 35px;">
                            Type
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 65px;">
                            <asp:DropDownList ID="ddl_Type" CssClass="listtxt_transac_item_gen_notn" 
                                Width="65px" runat="server" TabIndex="1" Font-Size="12px" AutoPostBack="true"
                                onselectedindexchanged="ddl_Type_SelectedIndexChanged" >
                                <asp:ListItem Text="New" Value="N"></asp:ListItem>
                                <asp:ListItem Text="Modify" Value="U"></asp:ListItem>
                                <asp:ListItem Text="Delete" Value="D"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>.
                      <div id="verslic"></div>

                      <div id="txt_container_Transact_Main_l" style="width: 140px;">
                        <div id="tag_label_transact_Src" style="width: 60px;">
                            Stmt.Code
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 75px;">
                            <asp:DropDownList ID="ddl_Dec_Type" CssClass="listtxt_transac_item_gen_notn" 
                                Width="75px" runat="server" TabIndex="1" Font-Size="12px"  AutoPostBack="true"
                                onselectedindexchanged="ddl_Dec_Type_SelectedIndexChanged" >
                                <asp:ListItem Text="DB001" Value="DB001"></asp:ListItem>
                                <asp:ListItem Text="DB002" Value="DB002"></asp:ListItem>
                                <asp:ListItem Text="DB003" Value="DB003"></asp:ListItem>
                                <asp:ListItem Text="DB004" Value="DB004"></asp:ListItem>
                                <asp:ListItem Text="DB005" Value="DB005"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>

                      <div id="verslic">
                    </div>
                     <div id="txt_container_Transact_Main_l" style="width: 225px;">
                        <div id="tag_label_transact_Src" style="width: 60px;">
                            Inv. SlNo
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 140px;">
                            <asp:DropDownList ID="ddlInv_slno" CssClass="listtxt_transac_item_gen_notn" 
                                AutoPostBack="true" Width="140px" runat="server" TabIndex="1" Font-Size="12px" 
                                onselectedindexchanged="ddlInv_slno_SelectedIndexChanged" >
                            </asp:DropDownList>
                        </div>
                    </div>
                      <div id="verslic">
                    </div>
                    <span id="dbk" runat="server">
                    <div id="txt_container_Transact_Main_l" style="width: 225px;">
                        <div id="tag_label_transact_Src" style="width: 100px;">
                            Drawback SlNo
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 90px;">
                            <asp:DropDownList ID="ddl_DbkSlNo" CssClass="listtxt_transac_item_gen_notn" Width="90px"
                                runat="server" TabIndex="1" AutoPostBack="true" Font-Size="12px" OnSelectedIndexChanged="ddl_DbkSlNo_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    </span>

                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>


                <div id="tag_transact_lft_in1" style="width: 1085px; height: 30px;">
                            <div id="txt_container_Transact_Main_l" style="width: 490px;">

                                <span id="lbl_Convert_to_Stmt_Code" runat="server">
                                    <div id="tag_label_transact_Src" style="width: 150px;">
                                        &nbsp;&nbsp;Update Stmt.Code
                                    </div>
                                    <div id="txtcon-m_Exchange">
                                        <asp:DropDownList ID="ddl_Update_To_Stmt_Code" CssClass="listtxt_transac_item_gen_notn"
                                            Width="75px" runat="server" TabIndex="1" Font-Size="12px">
                                            <asp:ListItem Text="DB001" Value="DB001"></asp:ListItem>
                                            <asp:ListItem Text="DB002" Value="DB002"></asp:ListItem>
                                            <asp:ListItem Text="DB003" Value="DB003"></asp:ListItem>
                                            <asp:ListItem Text="DB004" Value="DB004"></asp:ListItem>
                                            <asp:ListItem Text="DB005" Value="DB005"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </span>

                               <%--  <span id="lbl_Convert_Delete_to_Stmt_Code" runat="server">
                                    <div id="tag_label_transact_Src" style="width: 150px;">
                                        &nbsp;&nbsp; Delete To Stmt.Code
                                    </div>
                                    <div id="txtcon-m_Exchange">
                                        <asp:DropDownList ID="ddl_Delete_To_Stmt_Code" CssClass="listtxt_transac_item_gen_notn"
                                            Width="75px" runat="server" TabIndex="1" Font-Size="12px">
                                            <asp:ListItem Text="DB001" Value="DB001"></asp:ListItem>
                                            <asp:ListItem Text="DB002" Value="DB002"></asp:ListItem>
                                            <asp:ListItem Text="DB003" Value="DB003"></asp:ListItem>
                                            <asp:ListItem Text="DB004" Value="DB004"></asp:ListItem>
                                            <asp:ListItem Text="DB005" Value="DB005"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </span>--%>

                            </div>

                            
                        </div>


                
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>

            <div id="innerbox_MidMain_Trans" style="width: 1104px; height: 5px; margin-top: -12px;">
             </div>

                <div class="content" id="page-1" style="margin-left:-30px; margin-top:0px; width:888px;">
                <div class="content" id="page-6" >
               
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 200px; width:890px; margin-top: -16px; overflow:hidden;">
                        <div id="tag_transac_lft_Item_maindet_Grid_area"   style="overflow-x: hidden;overflow-y: auto; height:200px; width:850px; ">
                       

                               <asp:GridView ID="gv_Details" runat="server" AllowPaging="false" AutoGenerateColumns="true"
                                    BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                                    CssClass="grid-view" DataKeyNames="ITEM_SLNO" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
                                    Width="100%" OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
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
                        <%-----------------------Test------------------------------------------------------%>
                    </div>
                </div>
                  <%-------------------------------------------------------------------------------%>
                  <%-- --------------------Test Start----------------------------%>
                  <div id="innerbox_MidMain_bot_transact" runat="server" style="height:20px; margin-left:20px; margin-top:-14px;">
                    <div id="innerbox_transac_bot_inn">
                       
                        <div id="editbu">
                            <asp:Button ID="btnSMD" runat="server" CausesValidation="false" UseSubmitBehavior="false" 
                            CssClass="autowidmovebut" onclick="btnSMD_Click" />
                        </div>

                        <div id="editbu" style="width:400px">
                        </div>

                        <%--<div id="editbu">
                              <asp:Button ID="btnDelete" runat="server"  TabIndex="82" CausesValidation="false"
                              UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'INVOICE', function(r) {
                              var i = r + 'ok';
                              if(i == 'trueok')
                              {
                                  document.getElementById('btn').click();
            
                              }
                              else {
                              }
    
                            });return false;" />
                                                <asp:Button ID="btn" runat="server" TabIndex="82" CausesValidation="false" UseSubmitBehavior="false"
                                                    OnClientClick="jQuery('#form1').validationEngine('hideAll');" OnClick="btnDelete_Click"
                                                    CssClass="dlete" Style="display: none;" />
                                            </div>

                                                     <div id="editbu">
                                                <asp:Button ID="btnDeleteAll" runat="server"  TabIndex="82" CausesValidation="false" Text="Delete All" CssClass="autowidmovebut"
                                                    UseSubmitBehavior="false"  OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'INVOICE', function(r) {
                                              var i = r + 'ok';
                                      if(i == 'trueok')
                                      {
                                          document.getElementById('btndel_All').click();
            
                                      }
                                      else {
                                      }
    
                            });return false;" />
                    <asp:Button ID="btndel_All" runat="server" TabIndex="82" CausesValidation="false" UseSubmitBehavior="false"
                        OnClientClick="jQuery('#form1').validationEngine('hideAll');" OnClick="btnDeleteAll_Click"
                        CssClass="dlete" Style="display: none;" />
                </div>--%>
                      
                    </div>
                </div>
                   <%-- --------------------Test End----------------------------%>
                 
                 </div>
                <%-----------------------------------END----------------------------------------------------------------%>
            
           </ContentTemplate>
    </asp:UpdatePanel>



    </form>
  
   <script  src="../js/Billing/Billing_Invoice_auto_Search.js" type="text/javascript"></script>
    <script src="../js/Import_Jscript/IMP_Single_Window.js" type="text/javascript"></script>

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
            document.getElementById("General").click();
        }
        
    </script>
         <script type="text/javascript">

             function HideModalPopup_U() {

                 $find("MP_U").hide();
                 return false;
             }
    </script>
    
    
    <script type="text/javascript">
        function RefreshParent() {
            window.parent.location.reload();
        }
        
    </script>
    
</body>
</html>
