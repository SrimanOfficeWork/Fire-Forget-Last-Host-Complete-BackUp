<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Item_SingleWindow_Entry_2016.aspx.cs" Inherits="Item_SingleWindow_Entry_2016" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Item Single Window Entry 2016</title>
    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>


    
<script type="text/javascript">
    window.onload = function () {

        var scroll = document.getElementById("hdn_grid_scroll_retain").value;
        // alert(scroll);

        if (scroll == 'true') {
            var strCook = document.cookie;
            // alert(strCook);

            if (strCook.indexOf("!~") != 0) {
                var intS = strCook.indexOf("!~");
                var intE = strCook.indexOf("~!");
                var strPos = strCook.substring(intS + 2, intE);
                document.getElementById("tag_transac_export_lft_item_gen_Grid_area_new1").scrollTop = strPos;
            }
        }
    }
    function SetDivPosition() {
        var intY = document.getElementById("tag_transac_export_lft_item_gen_Grid_area_new1").scrollTop;
        document.cookie = "yPos=!~" + intY + "~!";
    }

</script>


<script type="text/javascript">

    $(document).ready(function () {

        var info_Type = document.getElementById("ddl_info_type").value;
        var Info_Qualifier = document.getElementById("ddl_Info_Qualifier").value;

        if (info_Type == 'OTH' && Info_Qualifier=='DTA') {
            BindControls();
        }
    });

    function BindControls() {
        var Notn = ['IEC', 'SEZ'];

        $('#txt_Info_Text').autocomplete({
            source: Notn,
            minLength: 0,
            scroll: true
        }).focus(function () {
            $(this).autocomplete("search", "");
        });
    }

  </script>


 <style type="text/css">
        .modalPopup12
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
    </style>

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
            <div id="popupwindow_closebut_right_new" runat="server" visible="false">
                       <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
            
              <div id="open_item" runat="server">
            <div id="innerbox_MidMain_Trans_Item_Main" style="height:357px;">
                <ol id="toc">
                    <li  style=" height:15px;" ><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll'); tab_page1('0');"
                        id="ItemMain"><span> SW info. Type  </span></a></li>
                    
                    <li  style=" height:15px;"><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll'); tab_SWConstituent('0');"
                        id="RE_IMPORT" runat="server" ><span> SW Constituent </span></a></li>

                        <li  style=" height:15px;"><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll'); tab_SWProduction('0');"
                        id="A1" runat="server" ><span>SW Production</span></a></li>

                       <li  style=" height:15px;"><a href="#page-4" onclick="jQuery('#form1').validationEngine('hideAll'); tab_SW_Control('0');"
                        id="A2" runat="server" ><span>SW Control</span></a></li>

                        <li  style=" height:15px;"><a href="#page-5" onclick="jQuery('#form1').validationEngine('hideAll'); tab_SW_Statement('0');"
                        id="A3" runat="server" ><span>Statement </span></a></li>

                        <%--<li  style=" height:15px;"><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll'); tab_SW_Sup_Doc('0');"
                        id="A4" runat="server" ><span>Sup. Doc </span></a></li>--%>
                   
                </ol>

                
               
                <div class="content" id="page-1" style="height:600px;">
                   <div id="pop_text_area_transac_popup_inn_container_left_IGM_invoice_Supplier" >
                   <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width:710px;">

                   <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width:80px;">
                   Aval. Dept.
                   </div>
                   <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width:90px;">
                      <asp:DropDownList ID="ddldept" Width="80px" CssClass="listtxt_transac_item_gen_notn" 
                      runat="server"> </asp:DropDownList>
                   </div>
                        
                   <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width:60px;">
                    <span style="color:Blue; font-weight:bold;" > RITC No.  </span>
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width:100px;">
                    <asp:TextBox ID="txt_RITCNO" runat="server"  Enabled="false" Font-Bold="true"  CssClass="txtbox_none_Mid_transac_Supp_Name" Width="90px" ></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty"></div>

                     <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width:80px;">
                      <span style="color:Blue; font-weight:bold;" >  Aval. Dept.  </span>
                     </div>
                     <div id="txtcon-m_transaction_Supp_code_Re_Import" style="font-size:small;width:290px; font-weight:bold;margin-top:3px;" >
                      <asp:Literal ID="lbl_avl_det" runat="server"></asp:Literal>
                     </div>
                    </div>



                    
                    
                 <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width:660px;">
                    

                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width:80px;">
                        Info Type 
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import">
                       
                          <asp:DropDownList ID="ddl_info_type" runat="server" TabIndex="1" 
                             class="chosen-select-deselect" Style="width: 215px; font-family:Arial,Helvetica,sans-serif; " 
                             data-placeholder="Choose a Info. Type"  AutoPostBack="true"
                             onselectedindexchanged="ddl_info_type_SelectedIndexChanged">
                         </asp:DropDownList>
                        

                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" >
                        Info Qualifier 
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">

                         <asp:DropDownList ID="ddl_Info_Qualifier" runat="server" TabIndex="2" 
                             class="chosen-select-deselect" Style="width: 215px; font-family:Arial,Helvetica,sans-serif; " 
                             data-placeholder="Choose a Info. Qualifier"  AutoPostBack="true"
                            onselectedindexchanged="ddl_Info_Qualifier_SelectedIndexChanged">
                          </asp:DropDownList>

                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width:660px;">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width:80px;">
                        Info code</div>
                    <div id="ddl_Info_Code_Import" runat="server">
                          <asp:DropDownList ID="ddl_Info_Code" runat="server" TabIndex="3" 
                             class="chosen-select-deselect" Style="width: 580px; font-family:Arial,Helvetica,sans-serif; " 
                             data-placeholder="Choose a Info. Code" >
                          </asp:DropDownList>
                    </div>
                      <div id="txt_Info_Code_Custom_Import" runat="server" style="display:none">
                      
                             <asp:TextBox ID="txt_Info_Code_Custom" runat="server"
                            Style="width: 580px; margin-left:80px; Arial, Helvetica, sans-serif;margin-top: -13px;"
                           placeholder="Enter Info. Code">
                            </asp:TextBox>

                    </div>
                   
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width:660px;">

                   <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width:80px;">
                       Info Text                  
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import">
                        <asp:TextBox ID="txt_Info_Text" runat="server"  
                            CssClass="txtbox_none_Mid_transac_Supp_Name" Width="220px" TabIndex="4" MaxLength="100"></asp:TextBox>
                    </div>


                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width:60px;">
                       Info MSR                  
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width:85px;">
                        <asp:TextBox ID="txt_Info_Msr" runat="server" MaxLength="28" width="70px"  CssClass="txtbox_none_Mid_transac_Supp_Name"
                                      TabIndex="5" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                      onkeypress="return blockNonNumbers(this, event, true, false);" ></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others"  style="width:75px;">
                        Info UQC                  
                    </div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_Info_Uqc" runat="server" CssClass="validate[minSize[3],custom[onlyLetterSp] txtbox_none_Mid_transac_item_maindet"
                         ClientIDMode="Static" Onkeypress="return char1(event)" onkeyup="return ChangeCase(this);"
                            TabIndex="6" MaxLength="3"></asp:TextBox>
                             
                    </div>
                </div>

                 <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>

             
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty_Re_import">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                            OnClientClick="jQuery('#form1').validationEngine('hide');" OnClick="btnNew_Click" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="12"
                            OnClientClick=" return validate_Import_Reimport()" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="updates" OnClick="btnUpdate_Click"
                            TabIndex="12" OnClientClick=" return validate_Import_Reimport()" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="13" Visible="false" CssClass="dlete"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'SW Constituent', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="13" OnClick="btnDelete_Click" OnClientClick="return validate();"
                            CssClass="dlete" Style="display: none;" />
                    </div>
                    <div id="editbu">
                      <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Child_Parent_close_button1('ItemMain');return false;"
                        tabindex="14" CausesValidation="false"
                        UseSubmitBehavior="false" />
                     </div>

                     <div id="editbu" style="width:64px;">
                                
                     </div>

                     <div id="editbu">
                      <div id="tag_label_transaction_popup_IGM_invoice_Supp_others"  style="width:61px;">
                        Sr. No                   
                      </div>
                       
                     </div>

                     <div id="editbu">
                          <div id="txtcon-m_transaction_item_maindet">
                         <asp:TextBox ID="txt_Sr_No" runat="server" CssClass="txtbox_none_Mid_transac_item_maindet"
                         ClientIDMode="Static"
                            TabIndex="7" MaxLength="4"></asp:TextBox>
                            </div>
                     </div>

                </div>
                <div id="tag_transac_export_lft_item_gen_Grid_area_new1" onscroll="SetDivPosition()" style=" overflow:auto; height:170px; width:685px;">
                    <asp:GridView ID="gv_ReImport" runat="server" DataKeyNames="SW_INFO_TYPE_ID" EmptyDataText="NO RECORD FOUND"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%" 
                        ShowHeaderWhenEmpty="True" OnRowDataBound="gv_ReImport_RowDataBound" 
                        OnSelectedIndexChanged="gv_ReImport_SelectedIndexChanged"  AllowPaging="false"
                         BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1" OnRowCreated="gv_ReImport_RowCreated">
                        <Columns>

                              <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="26px">
                                        <ItemTemplate>
                                        <asp:Label ID="lblitemslno"   runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle  HorizontalAlign="Center"  Width="26px"  />
                                    </asp:TemplateField>
                              <asp:BoundField DataField="DEPARTMENT" HeaderText="Dept." ControlStyle-Width="30px">
                                <ItemStyle CssClass="column_style_left5" Width="30px" />
                            </asp:BoundField>

                            <asp:BoundField DataField="INFO_TYPE" HeaderText=" Type" ControlStyle-Width="35px">
                                <ItemStyle CssClass="column_style_left5" Width="35px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="INFO_QUALIFIER" HeaderText="Qualifier" ControlStyle-Width="60px">
                                <ItemStyle CssClass="column_style_left5" Width="60px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="INFO_CODE" HeaderText="Code" ControlStyle-Width="60px">
                                <ItemStyle CssClass="column_style_left5" Width="60px"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="INFO_TEXT" HeaderText="Text" ControlStyle-Width="100px">
                                <ItemStyle CssClass="column_style_left5" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="INFO_MSR" HeaderText="MSR" ControlStyle-Width="20px">
                                <ItemStyle CssClass="column_style_left5" Width="20px"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="INFO_UQC" HeaderText="UQC" ControlStyle-Width="45px">
                                <ItemStyle CssClass="column_style_left5"  Width="45px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="SLNO" HeaderText="Sr. No" ControlStyle-Width="40px">
                                <ItemStyle CssClass="column_style_left5"  Width="40px" />
                            </asp:BoundField>
                          
                        </Columns>

                    </asp:GridView>
                </div>
            </div>
            <asp:HiddenField ID="hdn_update_Reimport" runat="server" />
            <asp:HiddenField ID="hdfTransport_mode" runat="server" />
            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />

            <asp:HiddenField ID="hdn_dept_code" runat="server" />
                </div>
                
                 <div class="content" id="page-2" style="display: none;">
                    <iframe  name="trans_item_reimport" scrolling="no" id="Trans_product_SWConstituent_iframe">
                    </iframe>
                </div>
                <div class="content" id="page-3" style="display: none;">
                    <iframe name="trans_item_licence" scrolling="no" id="Trans_product_SWProduction_iframe">
                    </iframe>
                </div>

                 <div class="content" id="page-4" style="display: none;">
                    <iframe  name="trans_item_licence" scrolling="no" id="Trans_product_SWControl_iframe">
                    </iframe>
                </div>
                 <div class="content" id="page-5" style="display: none;">
                    <iframe  name="trans_item_licence" scrolling="no" id="Trans_product_Statement_iframe">
                    </iframe>
                 </div>
                  <div class="content" id="page-6" style="display: none; ">
                    <iframe name="trans_item_licence" scrolling="no" id="Trans_product_Sup_doc_iframe" width="700px" height="400px">
                    </iframe>
                 </div>

                 </div>
                 </div>
              

                 
              
            
        </ContentTemplate>
    </asp:UpdatePanel>

      
       <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>

       <asp:modalpopupextender ID="MP_U" runat="server" TargetControlID="HDU"
        PopupControlID="MessageDivupdated_U" 
        BackgroundCssClass="modalBackground" DropShadow="false"   >
    </asp:modalpopupextender>
 
    <asp:HiddenField ID="HDU" runat="server" />

    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"  BorderColor="Transparent">
   
     <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width:300px; height:80px; ">
         <table width="100%" style="padding-top: 10px;">
             <tr>
                 <td align="center">
                     <asp:Label ID="lblUser_Msg" runat="server" Text=""></asp:Label>
                 </td>
             </tr>
             
             <tr>
                 <td style="padding-left: 125px; padding-top:10px;">
                     <asp:Button ID="Button2" runat="server" Text="Ok" OnClientClick="return HideModalPopup_U()"
                         CausesValidation="false" UseSubmitBehavior="false" />
                 </td>
             </tr>
         </table>
     </div>
    
    </asp:Panel>
     <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>
     <asp:HiddenField ID="hdn_Normal_Bulk" runat="server" />
     <asp:HiddenField ID="hdn_grid_scroll_retain" runat="server" />

    </form>
    </body>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
     
    <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8', 'page-9', 'page-15']);
            </script>
   
     <script  type="text/javascript">
         $(document).ready(function () {
             $(function () {
                 var dataSrc = ["IDT", "CHR", "CTG", "PNM", "PEC", "ORC"];

                 $("#txt_info_type").autocomplete({
                     source: dataSrc
                 });
             });
         });
 </script>
    <script src="../js/Import_Jscript/IMP_Single_Window.js" type="text/javascript"></script>
    <script src="../js/Export_Jscript/EXP_Single_Window_Tab.js" type="text/javascript"></script>



    <link rel="Stylesheet" href="../Dropdown/chosen.css" />
    <link rel="Stylesheet" href="../Dropdown/chosen.min.css" />
    <script src="../Dropdown/chosen.jquery.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.jquery.min.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../js/Grid_header_script/gridviewScroll.min.js"></script>


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
    </script>
     
    <script type="text/javascript">
            var config = {
                '.chosen-select': {},
                '.chosen-select-deselect': { allow_single_deselect: true },
                '.chosen-select-no-single': { disable_search_threshold: 10 },
                '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
                '.chosen-select-width': { width: "95%" }
                 
            }
            for (var selector in config) {
                $(selector).chosen(config[selector]);
            }

        </script>


       <%-- <script type="text/javascript">
            $(document).ready(function () {
                /* gridviewScroll();*/

                var totalRows = $("#<%=gv_ReImport.ClientID %> tr").length;
                var lastProductId = $("#<%=gv_ReImport.ClientID %> tr:last").children("td:first").html();


                if (totalRows > 2) {

                    gridviewScroll();

                }
                else {

                    if (lastProductId > 0) {
                        gridviewScroll();
                    }
                    else {
                        if (lastProductId > 0) {
                            gridviewScroll();
                        }
                        else {

                            document.getElementById('<%=gv_ReImport.ClientID %>').style.width = "100%";
                            document.getElementById('<%=gv_ReImport.ClientID %>').style.overflow = "100%";
                        }

                    }
                }
            });

            function gridviewScroll() {
                gridView1 = $('#<%=gv_ReImport.ClientID %>').gridviewScroll({

                    width: 720,
                    height: 182,
                    railcolor: "#F0F0F0",
                    barcolor: "#CDCDCD",
                    barhovercolor: "#606060",
                    bgcolor: "#F0F0F0",
                    freezesize: 1,
                    arrowsize: 30,
                    varrowtopimg: "../GridScroll_Images/arrowvt.png",
                    varrowbottomimg: "../GridScroll_Images/arrowvb.png",
                    harrowleftimg: "../GridScroll_Images/arrowhl.png",
                    harrowrightimg: "../GridScroll_Images/arrowhr.png",
                    headerrowcount: 1,
                    railsize: 16,
                    barsize: 15

                });
            }

	</script>--%>


    <!-- VALIDATION SCRIPT -->

</html>
